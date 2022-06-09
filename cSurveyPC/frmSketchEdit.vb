Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Imports cSurveyPC
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports System.ComponentModel
Imports DevExpress.XtraBars
Imports cSurveyPC.cSurvey.UIHelpers

Friend Class frmSketchEdit
    Private oSurvey As cSurvey.cSurvey
    Private oSketch As cItemSketch
    Private iDesignType As cIDesign.cDesignTypeEnum
    Private oLastMousePoint As Point

    Private oLastPlaceholder As cTrigpointPlaceholder

    Private sZoomFactor As Single

    Private iMaxWidth As Integer = 3096
    Private iMaxHeight As Integer = 3096

    Private oSourceImage As Bitmap
    Private oCurrentImage As Bitmap
    Private oRubberPoint As PointF
    Private iRubberSize As Integer = 32

    Private oExtraPlaceholder As cTrigpointPlaceholder
    Private oExtraPoint As PointF

    Private oTransparentColor As Color
    Private sTransparencyThreshold As Single

    Private iBorderX As Integer
    Private iBorderY As Integer

    Private iCurrentTool As ToolEnum
    Private oCutRect As RectangleF

    Private oPlaceholderSelectedPen As Pen
    Private oPlaceholderSelectedbrush As SolidBrush
    Private oPlaceholderPen As Pen
    Private oPlaceholderbrush As SolidBrush

    Private Class cTrigpointExtraPlaceholder
        Inherits cTrigpointPlaceholder

        Private bPlanOrProfile As Boolean
        Private sDistance As Single

        Public Overrides ReadOnly Property Size As Integer
            Get
                Return 6
            End Get
        End Property

        Public Sub New(Name As String, Station As String, Point As PointF, Type As StationTypeEnum, PlanOrProfile As Boolean, Distance As Single)
            Call MyBase.New(Name, Station, Point, Type)
            bPlanOrProfile = PlanOrProfile
            sDistance = Distance
        End Sub

        Public Overrides ReadOnly Property Caption As String
            Get
                'If Distance = -1 Then
                '    If bPlanOrProfile Then
                '        Return "→U"
                '    Else
                '        Return "→L"
                '    End If
                'ElseIf Distance = -2 Then
                '    If bPlanOrProfile Then
                '        Return "→D"
                '    Else
                '        Return "→R"
                '    End If
                'Else
                Return "→" & Distance.ToString
                'End If
            End Get
        End Property

        Public Property Distance As Single
            Get
                Return sDistance
            End Get
            Set(value As Single)
                sDistance = value
            End Set
        End Property

    End Class

    Private Class cTrigpointPlaceholder
        Private oPoint As Point
        Private sName As String
        Private sStation As String
        Private oArea As Rectangle
        'Private oHotSpot As Rectangle
        'Private iNameWidth As Integer

        Friend Enum StationTypeEnum
            [Default] = &H0
            Splay = &H1
        End Enum
        Private iType As StationTypeEnum

        Public Overridable ReadOnly Property Size As Integer
            Get
                Return 8
            End Get
        End Property

        Public ReadOnly Property Type As StationTypeEnum
            Get
                Return iType
            End Get
        End Property

        Public ReadOnly Property Point As Point
            Get
                Return oPoint
            End Get
        End Property

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public Overridable ReadOnly Property Caption As String
            Get
                Return sName
            End Get
        End Property

        Public ReadOnly Property Station As String
            Get
                Return sStation
            End Get
        End Property

        Public ReadOnly Property Area As Rectangle
            Get
                Return oArea
            End Get
        End Property

        'Public ReadOnly Property HotSpot As Rectangle
        '    Get
        '        Return oHotSpot
        '    End Get
        'End Property

        Public Function GetCaptionSize(Graphics As Graphics, Font As Font) As SizeF
            Return Graphics.MeasureString(Caption, Font)
        End Function

        Public Function GetHotSpot(Graphics As Graphics, Font As Font) As Rectangle
            Dim oNameSize As SizeF = Graphics.MeasureString(Caption, Font)
            Return New Rectangle(oPoint.X, oPoint.Y, oNameSize.Width + Size * 2, Size * 2)
        End Function

        Public Sub New(Name As String, Station As String, Point As PointF, Type As StationTypeEnum)
            Dim iSize As Integer = 8
            sName = Name
            sStation = Station
            iType = Type
            Call SetPoint(Point)
        End Sub

        Public Sub SetPoint(Point As PointF)
            'iNameWidth = NameWidth
            oPoint = New Point(Point.X, Point.Y)
            oArea = New Rectangle(oPoint.X, oPoint.Y, Size * 2, Size * 2)
            'oHotSpot = New Rectangle(oPoint.X, oPoint.Y, NameWidth + Size * 2, Size * 2)
        End Sub
    End Class
    Private oTrigpointsPlaceholders As Dictionary(Of String, cTrigpointPlaceholder)

    Private Enum ToolEnum
        None = 0
        Rubber = 1
        Cut = 2
        ExtraPoint = 3
    End Enum

    Private Sub pRotateImage()
        Call oCurrentImage.RotateFlip(RotateFlipType.Rotate90FlipNone)
        oCurrentImage = oCurrentImage.Clone
        picPreview.Size = oCurrentImage.Size
        picPreview.Refresh()
    End Sub

    Private Sub pFlipXImage()
        Call oCurrentImage.RotateFlip(RotateFlipType.RotateNoneFlipX)
        oCurrentImage = oCurrentImage.Clone
        Dim iWidth As Integer = oCurrentImage.Width
        For Each oTP As cTrigpointPlaceholder In oTrigpointsPlaceholders.Values
            Call oTP.SetPoint(New Point(iWidth - oTP.Point.X, oTP.Point.Y))
        Next
        picPreview.Size = oCurrentImage.Size
        picPreview.Refresh()
    End Sub

    Private Sub pFlipYImage()
        Call oCurrentImage.RotateFlip(RotateFlipType.RotateNoneFlipY)
        oCurrentImage = oCurrentImage.Clone
        Dim iHeight As Integer = oCurrentImage.Height
        For Each oTP As cTrigpointPlaceholder In oTrigpointsPlaceholders.Values
            Call oTP.SetPoint(New Point(oTP.Point.X, iHeight - oTP.Point.Y))
        Next
        picPreview.Size = oCurrentImage.Size
        picPreview.Refresh()
    End Sub

    Private Sub pRescaleImage(Width As Integer, Height As Integer)
        Dim oTmpImage As Bitmap = oCurrentImage
        If oTmpImage.Width > Width Or oTmpImage.Height > Height Then
            Dim sScaleX As Single = oTmpImage.Width / Width
            Dim sScaleY As Single = oTmpImage.Height / Height
            Dim sScale As Single = IIf(sScaleX > sScaleY, sScaleX, sScaleY)
            Dim sNewWidth As Single = oTmpImage.Width / sScale
            Dim sNewHeight As Single = oTmpImage.Height / sScale
            Dim oNewImage As Bitmap = New Bitmap(sNewWidth, sNewHeight, oCurrentImage.PixelFormat)
            Using oGraphics As Graphics = Graphics.FromImage(oNewImage)
                Call oGraphics.DrawImage(oTmpImage, 0, 0, sNewWidth, sNewHeight)
            End Using
            oCurrentImage = oNewImage

            For Each oTP As cTrigpointPlaceholder In oTrigpointsPlaceholders.Values
                Call oTP.SetPoint(New Point(oTP.Point.X / sScale, oTP.Point.Y / sScale))
            Next
        End If
        picPreview.Size = oCurrentImage.Size
        picPreview.Refresh()
    End Sub

    Private Sub pGrayScaleImage()
        Try
            Dim cm As ColorMatrix = New ColorMatrix(New Single()() {New Single() {0.299, 0.299, 0.299, 0, 0}, New Single() {0.587, 0.587, 0.587, 0, 0}, New Single() {0.114, 0.114, 0.114, 0, 0}, New Single() {0, 0, 0, 1, 0}, New Single() {0, 0, 0, 0, 1}})
            Dim oNewImage As Bitmap = New Bitmap(oCurrentImage)
            Dim oCurrentImageAttribute As ImageAttributes = New ImageAttributes
            Dim oRect As Rectangle = New Rectangle(0, 0, oNewImage.Width, oNewImage.Height)
            Using oGraphics As Graphics = Graphics.FromImage(oNewImage)
                Call oCurrentImageAttribute.SetColorMatrix(cm)
                Call oGraphics.DrawImage(oNewImage, oRect, 0, 0, oCurrentImage.Width, oCurrentImage.Height, GraphicsUnit.Pixel, oCurrentImageAttribute)
            End Using
            oCurrentImage = oNewImage
        Catch
        End Try
    End Sub

    Public Sub New(ByVal Sketch As cItemSketch)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Sketch.Survey
        oSketch = Sketch

        oPlaceholderSelectedPen = New Pen(Color.FromArgb(210, Color.Red), 2)
        oPlaceholderSelectedbrush = New SolidBrush(Color.FromArgb(210, Color.Red))
        oPlaceholderPen = New Pen(Color.FromArgb(140, Color.Red), 1)
        oPlaceholderbrush = New SolidBrush(Color.FromArgb(140, Color.Red))
        'oPlaceholderSplaySelectedPen = New Pen(Color.FromArgb(210, Color.DarkRed), 2)
        'oPlaceholderSplaySelectedbrush = New SolidBrush(Color.FromArgb(210, Color.DarkRed))
        'oPlaceholderSplayPen = New Pen(Color.FromArgb(140, Color.DarkRed), 1)
        'oPlaceholderSplaybrush = New SolidBrush(Color.FromArgb(140, Color.DarkRed))

        oTrigpointsPlaceholders = New Dictionary(Of String, cTrigpointPlaceholder)

        iDesignType = oSketch.Design.Type

        oSourceImage = modPaint.ImageExifRotate(Sketch.Image)
        oCurrentImage = oSourceImage
        oTransparentColor = Sketch.TransparentColor
        sTransparencyThreshold = Sketch.TransparencyThreshold

        Call pRescaleImage(iMaxWidth, iMaxHeight)

        picPreview.Size = oCurrentImage.Size

        btnShowSplays.Checked = False    'from some experience?!

        For Each oStation As cItemSketch.cStation In oSketch.Stations
            Dim sName As String = oStation.Name
            If oSurvey.TrigPoints.Contains(oStation.TrigPoint) Then
                If TypeOf oStation Is cItemSketch.cExtraStation Then
                    Dim oExtraStation As cItemSketch.cExtraStation = oStation
                    Call pAddExtraPoint(sName, oExtraStation.Point, oExtraStation.Distance)
                Else
                    Call pAddPoint(sName, oStation.Point)
                End If
            End If
        Next

        Call pRefreshTrigpointList()

        sZoomFactor = 1
    End Sub

    Private Sub pRefreshTrigpointList()
        Cursor = Cursors.WaitCursor

        Dim oTrigpoints As UIHelpers.cTrigpointByCaveBindinglist = New UIHelpers.cTrigpointByCaveBindinglist(cTrigpointByCaveBindinglist.StyleEnum.Uniquelist)
        For Each oTrigpoint As cTrigPoint In oSurvey.TrigPoints
            If Not oTrigpoint.IsSystem Then
                If (Not oTrigpoint.Data.IsSplay) OrElse (btnShowSplays.Checked AndAlso oTrigpoint.Data.IsSplay) Then
                    Call oTrigpoints.Add(oTrigpoint, oTrigpointsPlaceholders.ContainsKey(oTrigpoint.Name))
                End If
            End If
        Next
        Call grdStations.Rebind(oSurvey, oTrigpoints, New cTrigpointsGrid.cTrigpointsGridParameters)

        Cursor = Cursors.Default
    End Sub

    Private Sub pAddPoint(ByVal Name As String, ByVal X As Integer, ByVal Y As Integer)
        Call pAddPoint(Name, New Point(X, Y))
    End Sub

    Private Sub pAddExtraPoint(ByVal Name As String, ByVal X As Integer, ByVal Y As Integer, Distance As Single)
        Call pAddExtraPoint(Name, New Point(X, Y), Distance)
    End Sub

    Private Sub pAddPoint(ByVal Name As String, ByVal Location As Point)
        Dim iType As cTrigpointPlaceholder.StationTypeEnum
        If oSurvey.TrigPoints(Name).Data.IsSplay Then
            iType = cTrigpointPlaceholder.StationTypeEnum.Splay
        Else
            iType = cTrigpointPlaceholder.StationTypeEnum.Default
        End If
        Dim sName As String = Name
        Dim oTPH As cTrigpointPlaceholder = New cTrigpointPlaceholder(sName, Name, Location, iType)
        Call oTrigpointsPlaceholders.Add(sName, oTPH)
    End Sub

    Private Sub pAddExtraPoint(ByVal Name As String, ByVal Location As Point, Distance As Single)
        Dim iType As cTrigpointPlaceholder.StationTypeEnum
        If oSurvey.TrigPoints(Name).Data.IsSplay Then
            iType = cTrigpointPlaceholder.StationTypeEnum.Splay
        Else
            iType = cTrigpointPlaceholder.StationTypeEnum.Default
        End If
        Dim sName As String = Name & "_" & Guid.NewGuid.ToString
        Dim oTPH As cTrigpointExtraPlaceholder = New cTrigpointExtraPlaceholder(sName, Name, Location, iType, oSketch.Design.Type = cIDesign.cDesignTypeEnum.Profile, Distance)
        Call oTrigpointsPlaceholders.Add(sName, oTPH)
    End Sub

    Private Sub btnAdd_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.ItemClick
        Call pAddTrigpoint()
        Call grdStations.Focus()
    End Sub

    Private Sub pAddTrigpoint()
        Dim oTrigpoint As cTrigPoint = grdStations.SelectedItem
        If oTrigpoint IsNot Nothing Then
            Dim sTrigPoint As String = oTrigpoint.Name
            If sTrigPoint <> "" Then
                Call pAddPoint(sTrigPoint, oLastMousePoint)
                Call grdStations.use(oTrigpoint)
                Call grdStations.Refresh()
                Call picPreview.Invalidate()
            End If
        End If
    End Sub

    Private Sub picPreview_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles picPreview.DoubleClick
        If iCurrentTool = ToolEnum.None Then
            Call btnAdd_ItemClick(Nothing, EventArgs.Empty)
        Else
            If iCurrentTool = ToolEnum.ExtraPoint Then
                Using frmD As frmSketchEditDistance = New frmSketchEditDistance(oSketch.Design.Type = cIDesign.cDesignTypeEnum.Profile)
                    If frmD.ShowDialog = DialogResult.OK Then
                        Call pAddExtraPoint(oExtraPlaceholder.Name, oExtraPoint.X, oExtraPoint.Y, frmD.GetDistance)
                    End If
                End Using
                Call pToolStop()
            End If
            Call picPreview.Invalidate()
        End If
    End Sub

    Private Sub picPreview_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picPreview.MouseDown
        'If (e.Button And Windows.Forms.MouseButtons.Right) = Windows.Forms.MouseButtons.Right Then
        oLastMousePoint = New Point(e.X, e.Y)
        'End If
        If iCurrentTool = ToolEnum.Cut And (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
            oStartSelPosition = oLastMousePoint
            oEndSelPosition = oLastMousePoint
            Call picPreview.Invalidate()
        End If
    End Sub

    Private Sub pRemoveTrigPoint()
        Try
            If TypeOf oLastPlaceholder Is cTrigpointExtraPlaceholder Then
                Dim sTrigpoint As String = oLastPlaceholder.Name
                If oTrigpointsPlaceholders.ContainsKey(sTrigpoint) Then Call oTrigpointsPlaceholders.Remove(sTrigpoint)
            Else
                Dim sTrigpoint As String = oLastPlaceholder.Name
                If oTrigpointsPlaceholders.ContainsKey(sTrigpoint) Then Call oTrigpointsPlaceholders.Remove(sTrigpoint)
                For Each sKey As String In oTrigpointsPlaceholders.Keys.ToList
                    If sKey.StartsWith(sTrigpoint & "_") Then
                        Call oTrigpointsPlaceholders.Remove(sKey)
                    End If
                Next
                grdStations.Unuse(sTrigpoint)
            End If
            oLastPlaceholder = Nothing
            Call grdStations.Focus()
            Call picPreview.Invalidate()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnRemove_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.ItemClick
        Call pRemoveTrigPoint()
    End Sub

    Private Sub picPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picPreview.Click
        If iCurrentTool = ToolEnum.None Then
            oLastPlaceholder = Nothing
            Call pnlPreview.Focus()
        End If
    End Sub

    Private Sub btnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sZoomFactor = sZoomFactor * 1.1
        picPreview.Width = oCurrentImage.Width * sZoomFactor
        picPreview.Height = oCurrentImage.Height * sZoomFactor
        'Call pnlPreview.Panel2.Scale(New SizeF(1.1, 1.1))
        Call picPreview.Invalidate()
        'oStartSelPosition.X = oStartSelPosition.X * 1.1
        'oStartSelPosition.Y = oStartSelPosition.Y * 1.1
        'oEndSelPosition.X = oEndSelPosition.X * 1.1
        'oEndSelPosition.Y = oEndSelPosition.Y * 1.1
    End Sub

    Private Sub btnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sZoomFactor = sZoomFactor * 0.909
        picPreview.Width = oCurrentImage.Width * sZoomFactor
        picPreview.Height = oCurrentImage.Height * sZoomFactor
        'Call pnlPreview.Panel2.Scale(New SizeF(0.909, 0.909))
        Call picPreview.Invalidate()
        'oStartSelPosition.X = oStartSelPosition.X / 1.1
        'oStartSelPosition.Y = oStartSelPosition.Y / 1.1
        'oEndSelPosition.X = oEndSelPosition.X / 1.1
        'oEndSelPosition.Y = oEndSelPosition.Y / 1.1
    End Sub

    Private oStartSelPosition As PointF
    Private oEndSelPosition As PointF

    Private Function pGetSelRect() As RectangleF
        Dim sLeft As Single = oStartSelPosition.X
        Dim [sTop] As Single = oStartSelPosition.Y
        Dim sWidth As Single = oEndSelPosition.X - oStartSelPosition.X
        Dim sHeight As Single = oEndSelPosition.Y - oStartSelPosition.Y
        If sWidth < 0 Then
            sWidth = -1 * sWidth
            sLeft = sLeft - sWidth
        End If
        If sHeight < 0 Then
            sHeight = -1 * sHeight
            [sTop] = [sTop] - sHeight
        End If
        Return New RectangleF(sLeft, [sTop], sWidth, sHeight)
    End Function

    Private Sub picPreview_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picPreview.Paint
        Try
            Dim oGraphics As Graphics = e.Graphics
            oGraphics.SmoothingMode = SmoothingMode.AntiAlias
            oGraphics.CompositingQuality = CompositingQuality.HighQuality
            oGraphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

            Call oGraphics.ScaleTransform(sZoomFactor, sZoomFactor)

            Using imgAttributes As System.Drawing.Imaging.ImageAttributes = New System.Drawing.Imaging.ImageAttributes
                If Not oTransparentColor = Color.Transparent Then
                    Call imgAttributes.SetColorKey(modPaint.DarkColor(oTransparentColor, 1.0F - sTransparencyThreshold), modPaint.LightColor(oTransparentColor, 1.0F - sTransparencyThreshold))
                End If
                Call oGraphics.DrawImage(oCurrentImage, New Rectangle(0, 0, picPreview.Width, picPreview.Height), 0, 0, oCurrentImage.Width, oCurrentImage.Height, GraphicsUnit.Pixel, imgAttributes)
            End Using

            Using oSF As StringFormat = New StringFormat(Drawing.StringFormatFlags.NoWrap)
                oSF.Alignment = StringAlignment.Center
                oSF.LineAlignment = StringAlignment.Center
                For Each oTPH As cTrigpointPlaceholder In oTrigpointsPlaceholders.Values
                    Dim bIsExtra As Boolean = TypeOf oTPH Is cTrigpointExtraPlaceholder
                    Dim sText As String = oTPH.Caption
                    Dim oHotSpot As Rectangle = oTPH.GetHotSpot(oGraphics, Font)
                    Dim oCaptionSize As SizeF = oTPH.GetCaptionSize(oGraphics, Font)

                    Using oPath As GraphicsPath = New GraphicsPath
                        Call oPath.AddLine(oTPH.Area.Left, oTPH.Area.Top, oTPH.Area.Left, oTPH.Area.Top + oTPH.Area.Height \ 2)
                        Call oPath.AddArc(oTPH.Area, 180, -90)
                        Call oPath.AddLine(oTPH.Area.Left + oTPH.Area.Width \ 2, oTPH.Area.Bottom, oTPH.Area.Left + oTPH.Area.Width \ 2 + oCaptionSize.Width, oTPH.Area.Bottom)
                        Call oPath.AddArc(oTPH.Area.Left + oCaptionSize.Width, oTPH.Area.Top, oTPH.Area.Width, oTPH.Area.Height, 90, -180)
                        Call oPath.AddLine(oTPH.Area.Left + oCaptionSize.Width, oTPH.Area.Top, oTPH.Area.Left + oTPH.Area.Width \ 2, oTPH.Area.Top)
                        Call oPath.AddLine(oTPH.Area.Left + oTPH.Area.Width \ 2, oTPH.Area.Top, oTPH.Area.Left, oTPH.Area.Top)
                        If bIsExtra Then
                            oPlaceholderSelectedbrush.Color = Color.FromArgb(210, Color.Gray)
                            oPlaceholderbrush.Color = Color.FromArgb(140, Color.Gray)
                            oPlaceholderSelectedPen.Color = Color.FromArgb(210, Color.Gray)
                            oPlaceholderPen.Color = Color.FromArgb(140, Color.Gray)
                        Else
                            If oTPH.Type = cTrigpointPlaceholder.StationTypeEnum.Splay Then
                                oPlaceholderSelectedbrush.Color = Color.FromArgb(210, Color.DarkRed)
                                oPlaceholderbrush.Color = Color.FromArgb(140, Color.DarkRed)
                                oPlaceholderSelectedPen.Color = Color.FromArgb(210, Color.DarkRed)
                                oPlaceholderPen.Color = Color.FromArgb(140, Color.DarkRed)
                            Else
                                oPlaceholderSelectedbrush.Color = Color.FromArgb(210, Color.Red)
                                oPlaceholderbrush.Color = Color.FromArgb(140, Color.Red)
                                oPlaceholderSelectedPen.Color = Color.FromArgb(210, Color.Red)
                                oPlaceholderPen.Color = Color.FromArgb(140, Color.Red)
                            End If
                        End If
                        If oTPH Is oLastPlaceholder Then
                            Call oGraphics.FillPath(oPlaceholderSelectedbrush, oPath)
                            Call oGraphics.DrawPath(oPlaceholderSelectedPen, oPath)
                        Else
                            Call oGraphics.FillPath(oPlaceholderbrush, oPath)
                            Call oGraphics.DrawPath(oPlaceholderPen, oPath)
                        End If
                        Call oGraphics.DrawString(sText, Font, Brushes.White, oHotSpot, oSF)
                        If bIsExtra Then
                            Using oSelPen As Pen = New Pen(SystemColors.Highlight, 1)
                                oSelPen.EndCap = LineCap.Custom
                                oSelPen.CustomEndCap = New AdjustableArrowCap(3, 3, True)
                                Call oGraphics.DrawLine(oSelPen, oTrigpointsPlaceholders(oTPH.Station).Point, oTPH.Point)
                            End Using
                        End If
                    End Using
                Next
            End Using

            If btnRubber.Checked Then
                Dim oRubberRect As RectangleF = New RectangleF(oRubberPoint.X - iRubberSize / 2, oRubberPoint.Y - iRubberSize / 2, iRubberSize, iRubberSize) 'New RectangleF(oRubberPoint.X - iRubberSize / 2, oRubberPoint.Y - iRubberSize / 2, iRubberSize, iRubberSize)
                Call oGraphics.DrawEllipse(Pens.Black, oRubberRect)
            End If

            If iCurrentTool = ToolEnum.Cut Then
                If Not oCutRect.IsEmpty Then
                    Using oRegBrush As SolidBrush = New SolidBrush(Color.FromArgb(80, Color.Gray))
                        Dim oBaseRect As RectangleF = oGraphics.ClipBounds
                        Using oBaseReg As Region = New Region(oBaseRect)
                            Call oBaseReg.Exclude(oCutRect)
                            Call oGraphics.FillRegion(oRegBrush, oBaseReg)
                        End Using
                    End Using
                End If

                Dim iAlpha As Integer = 50
                Using oSelBrush As SolidBrush = New SolidBrush(Color.FromArgb(iAlpha, SystemColors.Highlight))
                    Using oSelPen As Pen = New Pen(SystemColors.Highlight)
                        Dim oSelRect As RectangleF = pGetSelRect()
                        Call oGraphics.FillRectangle(oSelBrush, oSelRect)
                        Call oGraphics.DrawRectangle(oSelPen, Rectangle.Truncate(oSelRect))
                    End Using
                End Using
            End If

            If iCurrentTool = ToolEnum.ExtraPoint Then
                Using oSelPen As Pen = New Pen(SystemColors.Highlight, 2)
                    oSelPen.EndCap = LineCap.Custom
                    oSelPen.CustomEndCap = New AdjustableArrowCap(5, 5, True)
                    Call oGraphics.DrawLine(oSelPen, oLastPlaceholder.Point, oExtraPoint)
                End Using
            End If
        Catch
        End Try
    End Sub

    Private Sub picPreview_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picPreview.MouseMove
        If iCurrentTool = ToolEnum.Cut And (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
            oEndSelPosition = e.Location
            Call picPreview.Invalidate()
        End If

        If iCurrentTool = ToolEnum.Rubber Then
            If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
                Using oGr As Graphics = Graphics.FromImage(oCurrentImage)
                    oRubberPoint = e.Location
                    Dim oRubberRect As RectangleF = New RectangleF(oRubberPoint.X / sZoomFactor - iRubberSize / sZoomFactor / 2, oRubberPoint.Y / sZoomFactor - iRubberSize / sZoomFactor / 2, iRubberSize / sZoomFactor, iRubberSize / sZoomFactor)
                    Call oGr.FillEllipse(Brushes.White, oRubberRect)
                End Using
            Else
                oRubberPoint = e.Location
            End If
            Call picPreview.Invalidate()
        End If

        If iCurrentTool = ToolEnum.ExtraPoint Then
            oExtraPoint = e.Location
            Call picPreview.Invalidate()
        End If
    End Sub

    'Private Sub btnRubber0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    btnRubber0.Checked = True
    '    btnRubber1.Checked = False
    '    btnRubber2.Checked = False
    '    btnRubber3.Checked = False
    '    btnRubber.Checked = True
    '    iRubberSize = 16
    'End Sub

    Private Sub pToolStart(Tool As ToolEnum)
        iCurrentTool = Tool

        grdStations.Enabled = False

        cmdOk.Enabled = False
        btnLoadImage.Enabled = False
        btnUndo.Enabled = False
        btnRescale.Enabled = False
        btnRotate.Enabled = False
        btnRubber.Enabled = False
        btnFlipH.Enabled = False
        btnFlipV.Enabled = False
        btnToGrayscale.Enabled = False
        btnCropStart.Enabled = False

        btnStop.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
    End Sub

    Private Sub pToolStop()
        grdStations.Enabled = True

        cmdOk.Enabled = True
        btnLoadImage.Enabled = True
        btnUndo.Enabled = True
        btnRescale.Enabled = True
        btnRotate.Enabled = True
        btnRubber.Enabled = True
        btnFlipH.Enabled = True
        btnFlipV.Enabled = True
        btnToGrayscale.Enabled = True
        btnCropStart.Enabled = True

        Select Case iCurrentTool
            Case ToolEnum.Cut
                oStartSelPosition = Point.Empty
                oEndSelPosition = Point.Empty
                oCutRect = Rectangle.Empty
                btnCropStart.Checked = False
            Case ToolEnum.Rubber
                btnRubber.Checked = False
            Case ToolEnum.ExtraPoint
                oExtraPlaceholder = Nothing
        End Select

        btnStop.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        iCurrentTool = ToolEnum.None

        Call picPreview.Invalidate()
    End Sub

    'Private Sub btnRubber1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    btnRubber0.Checked = False
    '    btnRubber1.Checked = True
    '    btnRubber2.Checked = False
    '    btnRubber3.Checked = False
    '    btnRubber.Checked = True
    '    iRubberSize = 32
    'End Sub

    'Private Sub btnRubber2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    btnRubber0.Checked = False
    '    btnRubber1.Checked = False
    '    btnRubber2.Checked = True
    '    btnRubber3.Checked = False
    '    btnRubber.Checked = True
    '    iRubberSize = 64
    'End Sub

    'Private Sub btnRubber3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    btnRubber0.Checked = False
    '    btnRubber1.Checked = False
    '    btnRubber2.Checked = False
    '    btnRubber3.Checked = True
    '    btnRubber.Checked = True
    '    iRubberSize = 128
    'End Sub

    'Private Sub btnRubber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    btnRubber.Checked = Not btnRubber.Checked
    '    Call picPreview.Invalidate()
    'End Sub

    'Private Sub mnuPreviewDeleteTransparent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    oTransparentColor = Color.Transparent
    '    Call picPreview.Invalidate()
    'End Sub

    'Private Sub mnuPreviewSetTransparent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    oTransparentColor = oCurrentImage.GetPixel(oLastMousePoint.X, oLastMousePoint.Y)
    '    Call picPreview.Invalidate()
    'End Sub

    'Private Sub mnuPreviewTransparentThreshold1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    sTransparencyThreshold = 0.99
    '    Call picPreview.Invalidate()
    'End Sub

    'Private Sub mnuPreviewTransparentThreshold2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    sTransparencyThreshold = 0.95
    '    Call picPreview.Invalidate()
    'End Sub

    'Private Sub mnuPreviewTransparentThreshold3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    sTransparencyThreshold = 0.9
    '    Call picPreview.Invalidate()
    'End Sub

    'Private Sub mnuPreviewTransparentThreshold4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    sTransparencyThreshold = 0.8
    '    Call picPreview.Invalidate()
    'End Sub

    'Private Sub mnuPreviewTransparentThreshold5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    sTransparencyThreshold = 0.7
    '    Call picPreview.Invalidate()
    'End Sub

    'Private Sub mnuPreviewTransparentThreshold6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    sTransparencyThreshold = 0.5
    '    Call picPreview.Invalidate()
    'End Sub

    'Private Sub mnuPreviewTransparentThreshold_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs)
    '    mnuPreviewTransparentThreshold1.Checked = False
    '    mnuPreviewTransparentThreshold2.Checked = False
    '    mnuPreviewTransparentThreshold3.Checked = False
    '    mnuPreviewTransparentThreshold4.Checked = False
    '    mnuPreviewTransparentThreshold5.Checked = False
    '    mnuPreviewTransparentThreshold6.Checked = False
    '    mnuPreviewTransparentThreshold7.Checked = False
    '    mnuPreviewTransparentThreshold8.Checked = False
    '    mnuPreviewTransparentThreshold9.Checked = False
    '    mnuPreviewTransparentThreshold10.Checked = False
    '    mnuPreviewTransparentThreshold11.Checked = False
    '    Select Case sTransparencyThreshold
    '        Case 0.99
    '            mnuPreviewTransparentThreshold1.Checked = True
    '        Case 0.95
    '            mnuPreviewTransparentThreshold2.Checked = True
    '        Case 0.9
    '            mnuPreviewTransparentThreshold3.Checked = True
    '        Case 0.8
    '            mnuPreviewTransparentThreshold4.Checked = True
    '        Case 0.7
    '            mnuPreviewTransparentThreshold5.Checked = True
    '        Case 0.6
    '            mnuPreviewTransparentThreshold6.Checked = True
    '        Case 0.5
    '            mnuPreviewTransparentThreshold7.Checked = True
    '        Case 0.4
    '            mnuPreviewTransparentThreshold8.Checked = True
    '        Case 0.3
    '            mnuPreviewTransparentThreshold9.Checked = True
    '        Case 0.2
    '            mnuPreviewTransparentThreshold10.Checked = True
    '        Case 0.1
    '            mnuPreviewTransparentThreshold11.Checked = True
    '    End Select
    'End Sub

    'Private Sub mnuPreviewTransparentThreshold11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    sTransparencyThreshold = 0
    '    Call picPreview.Invalidate()
    'End Sub

    'Private Sub mnuPreviewTransparentThreshold10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    sTransparencyThreshold = 0.1
    '    Call picPreview.Invalidate()
    'End Sub

    'Private Sub mnuPreviewTransparentThreshold9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    sTransparencyThreshold = 0.2
    '    Call picPreview.Invalidate()
    'End Sub

    'Private Sub mnuPreviewTransparentThreshold8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    sTransparencyThreshold = 0.3
    '    Call picPreview.Invalidate()
    'End Sub

    'Private Sub mnuPreviewTransparentThreshold7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    sTransparencyThreshold = 0.4
    '    Call picPreview.Invalidate()
    'End Sub

    'Private Sub pnlTop_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
    '        iBorderY = pnlTop.Top
    '    End If
    'End Sub

    'Private Sub pnlTop_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
    '        pnlTop.Location = New Point(0, iBorderY + e.Y)
    '        iBorderY = pnlTop.Top
    '        Call picPreview.Invalidate()
    '    End If
    'End Sub

    'Private Sub pnlBottom_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
    '        iBorderY = pnlBottom.Top
    '    End If
    'End Sub

    'Private Sub pnlBottom_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
    '        pnlBottom.Location = New Point(0, iBorderY + e.Y)
    '        iBorderY = pnlBottom.Top
    '        Call picPreview.Invalidate()
    '    End If
    'End Sub

    'Private Sub pnlRight_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
    '        iBorderX = pnlRight.Left
    '    End If
    'End Sub

    'Private Sub pnlRight_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
    '        pnlRight.Location = New Point(iBorderX + e.X, 0)
    '        iBorderX = pnlRight.Left
    '        Call picPreview.Invalidate()
    '    End If
    'End Sub

    'Private Sub pnlLeft_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
    '        iBorderX = pnlLeft.Left
    '    End If
    'End Sub

    'Private Sub pnlLeft_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
    '        pnlLeft.Location = New Point(iBorderX + e.X, 0)
    '        iBorderX = pnlLeft.Left
    '        Call picPreview.Invalidate()
    '    End If
    'End Sub

    'Private Sub btnRubber_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim bVisible As Boolean = btnRubber.Checked
    '    Call pToolStop()

    '    btnRubber0.Visible = bVisible
    '    btnRubber1.Visible = bVisible
    '    btnRubber2.Visible = bVisible
    '    btnRubber3.Visible = bVisible
    '    Select Case iRubberSize
    '        Case 16
    '            btnRubber0.Checked = True
    '        Case 32
    '            btnRubber1.Checked = True
    '        Case 64
    '            btnRubber2.Checked = True
    '        Case Else
    '            btnRubber3.Checked = True
    '    End Select

    '    If bVisible Then
    '        Call pToolStart(ToolEnum.Rubber)
    '    End If
    'End Sub

    'Private Sub btnShowCutBorders_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim bVisible As Boolean = btnShowCutBorders.Checked
    '    Call pToolStop()
    '    btnCut.Visible = bVisible
    '    If bVisible Then
    '        Call pToolStart(ToolEnum.Cut)
    '    End If
    'End Sub

    'Private Sub btnShowCutBorders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    btnShowCutBorders.Checked = Not btnShowCutBorders.Checked
    'End Sub

    Private Sub btnCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call pPreviewCrop()
    End Sub

    Private Sub pPreviewCrop()
        Dim oRect As RectangleF = oCutRect
        If oRect.IsEmpty Or oRect.Width = 0 Or oRect.Height = 0 Then
            Call MsgBox(GetLocalizedString("sketchedit.warning5"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("sketchedit.warningtitle"))
        Else
            If MsgBox(GetLocalizedString("sketchedit.warning6"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("sketchedit.warningtitle")) = MsgBoxResult.Yes Then
                Call pRemoveTrigPoints()

                Dim iWidth As Integer = oRect.Width
                Dim iHeight As Integer = oRect.Height
                Dim oSourceRect As Rectangle = Rectangle.Truncate(oRect)
                Dim oDestRect As Rectangle = New Rectangle(0, 0, iWidth, iHeight)
                Dim oNewImage As Bitmap = New Bitmap(iWidth, iHeight)
                Using oGraphics As Graphics = Graphics.FromImage(oNewImage)
                    Call oGraphics.DrawImage(oCurrentImage, oDestRect, oSourceRect, GraphicsUnit.Pixel)
                End Using

                oCurrentImage = oNewImage
                picPreview.Size = oCurrentImage.Size

                'nascondo i margini di ritaglio....
                Call pToolStop()
            End If
        End If
    End Sub

    Private Sub btnRemoveAll_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAll.ItemClick
        If MsgBox(GetLocalizedString("sketchedit.warning9"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, GetLocalizedString("sketchedit.warningtitle")) = MsgBoxResult.Yes Then
            Call pRemoveTrigPoints()
        End If
    End Sub

    Private Sub pRemoveTrigPoints()
        Try
            Call oTrigpointsPlaceholders.Clear()
            grdStations.UnuseAll()
            oLastPlaceholder = Nothing
            Call grdStations.Focus()
            Call picPreview.Invalidate()
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub btnRescale0_Click(sender As System.Object, e As System.EventArgs)
    '    If MsgBox(GetLocalizedString("sketchedit.warning7"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("sketchedit.warningtitle")) = MsgBoxResult.Yes Then
    '        'Call pRemoveTrigPoints()
    '        Call pRescaleImage(3096, 3096)
    '    End If
    'End Sub

    'Private Sub btnRescale1_Click(sender As System.Object, e As System.EventArgs)
    '    If MsgBox(GetLocalizedString("sketchedit.warning7"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("sketchedit.warningtitle")) = MsgBoxResult.Yes Then
    '        'Call pRemoveTrigPoints()
    '        Call pRescaleImage(2048, 2048)
    '    End If
    'End Sub

    'Private Sub btnRescale2_Click(sender As System.Object, e As System.EventArgs)
    '    If MsgBox(GetLocalizedString("sketchedit.warning7"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("sketchedit.warningtitle")) = MsgBoxResult.Yes Then
    '        'Call pRemoveTrigPoints()
    '        Call pRescaleImage(1024, 1024)
    '    End If
    'End Sub

    'Private Sub btnRescale3_Click(sender As System.Object, e As System.EventArgs)
    '    If MsgBox(GetLocalizedString("sketchedit.warning7"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("sketchedit.warningtitle")) = MsgBoxResult.Yes Then
    '        'Call pRemoveTrigPoints()
    '        Call pRescaleImage(512, 512)
    '    End If
    'End Sub

    'Private Sub btnRescale_Click(sender As System.Object, e As System.EventArgs)

    'End Sub

    'Private Sub btnRescale_DropDownOpening(sender As Object, e As System.EventArgs)
    '    btnRescale0.Enabled = (oCurrentImage.Width > 3096) Or (oCurrentImage.Height > 3096)
    '    btnRescale1.Enabled = (oCurrentImage.Width > 2048) Or (oCurrentImage.Height > 2048)
    '    btnRescale2.Enabled = (oCurrentImage.Width > 1024) Or (oCurrentImage.Height > 1024)
    '    btnRescale3.Enabled = (oCurrentImage.Width > 512) Or (oCurrentImage.Height > 512)
    'End Sub

    'Private Sub btnRotate_Click(sender As System.Object, e As System.EventArgs)
    '    If MsgBox(GetLocalizedString("sketchedit.warning8"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("sketchedit.warningtitle")) = MsgBoxResult.Yes Then
    '        Call pRemoveTrigPoints()
    '        Call pRotateImage()
    '    End If
    'End Sub

    'Private Sub btnFlipH_Click(sender As System.Object, e As System.EventArgs)
    '    Call pFlipXImage()
    'End Sub

    'Private Sub btnFlipV_Click(sender As System.Object, e As System.EventArgs)
    '    Call pFlipYImage()
    'End Sub

    'Private Sub btnStop_Click(sender As System.Object, e As System.EventArgs)
    '    Call pToolStop()
    'End Sub

    'Private Sub mnuPreviewStop_Click(sender As System.Object, e As System.EventArgs)
    '    Call pToolStop()
    'End Sub

    Private Sub frmSketchEdit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Call oPlaceholderSelectedPen.Dispose()
        Call oPlaceholderSelectedbrush.Dispose()
        Call oPlaceholderPen.Dispose()
        Call oPlaceholderbrush.Dispose()

        'Call oPlaceholderSplaySelectedPen.Dispose()
        'Call oPlaceholderSplaySelectedbrush.Dispose()
        'Call oPlaceholderSplayPen.Dispose()
        'Call oPlaceholderSplaybrush.Dispose()
    End Sub

    Private Sub frmSketchEdit_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If iCurrentTool <> ToolEnum.None Then
                    Call pToolStop()
                End If
        End Select
    End Sub

    Private Sub frmSketchEdit_PreviewKeyDown(sender As Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles Me.PreviewKeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If iCurrentTool <> ToolEnum.None Then
                    Call pToolStop()
                End If
        End Select
    End Sub

    Private Sub pSelectPlaceholder(Point As Point)
        Using oGraphics As Graphics = picPreview.CreateGraphics
            For Each oTPH As cTrigpointPlaceholder In oTrigpointsPlaceholders.Values
                If oTPH.GetHotSpot(oGraphics, Font).Contains(Point) Then
                    oLastPlaceholder = oTPH
                    Exit Sub
                End If
            Next
            oLastPlaceholder = Nothing
        End Using
    End Sub

    Private Sub picPreview_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles picPreview.MouseUp
        If iCurrentTool = ToolEnum.Cut And (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
            Dim oTmpRect As RectangleF = pGetSelRect()
            If My.Computer.Keyboard.ShiftKeyDown Then
                If oCutRect.IsEmpty Then
                    oCutRect = oTmpRect
                Else
                    oCutRect = RectangleF.Union(oCutRect, oTmpRect)
                End If
            Else
                oCutRect = oTmpRect
            End If
            oStartSelPosition = Point.Empty
            oEndSelPosition = Point.Empty
            Call picPreview.Invalidate()
        End If

        If iCurrentTool = ToolEnum.None Then
            Dim oPoint As Point = New Point(e.X, e.Y)
            Call pSelectPlaceholder(oPoint)
            Call picPreview.Invalidate()
            If (e.Button And Windows.Forms.MouseButtons.Right) = Windows.Forms.MouseButtons.Right Then
                Call mnuPreview.ShowPopup(picPreview.PointToScreen(oPoint))
            End If
        End If
    End Sub

    'Private Sub mnuTrigpointsFilterBy_KeyDown(sender As Object, e As KeyEventArgs) Handles mnuTrigpointsFilterBy.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        Call pFilter(mnuTrigpointsFilterBy.Text)
    '    End If
    'End Sub

    'Private Sub mnuTrigpointsRemoveFilter_Click(sender As Object, e As EventArgs) Handles mnuTrigpointsRemoveFilter.Click
    '    Call pRemoveFilter()
    'End Sub

    'Private Sub mnuTrigpointsShowSplay_Click(sender As Object, e As EventArgs) Handles mnuTrigpointsShowSplay.Click
    '    bShowSplay = Not bShowSplay
    '    Call pRefreshTrigpointList()
    'End Sub

    Private Sub btnAddExtra_ItemClick(sender As Object, e As EventArgs) Handles btnAddExtra.ItemClick
        Call pToolStop()

        oExtraPlaceholder = oLastPlaceholder
        Call pToolStart(ToolEnum.ExtraPoint)
    End Sub

    Private Sub btnEditDistance_ItemClick(sender As Object, e As EventArgs) Handles btnEditDistance.ItemClick
        Dim oTPH As cTrigpointExtraPlaceholder = oLastPlaceholder
        Using frmD As frmSketchEditDistance = New frmSketchEditDistance(oSketch.Layer.Design.Type = cIDesign.cDesignTypeEnum.Profile, oTPH.Distance)
            If frmD.ShowDialog = DialogResult.OK Then
                oTPH.Distance = frmD.GetDistance
                Call picPreview.Invalidate()
            End If
        End Using
    End Sub

    'Private Sub mnuTrigpoints_Opening(sender As Object, e As CancelEventArgs)
    '    mnuTrigpointsShowSplay.Checked = bShowSplay
    'End Sub

    Private Sub cmdok_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdOk.ItemClick
        If oTrigpointsPlaceholders.Count < 2 Then
            Call MsgBox(GetLocalizedString("sketchedit.warning1"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, GetLocalizedString("sketchedit.warningtitle"))

            DialogResult = Windows.Forms.DialogResult.None
        Else
            oSketch.Image = oCurrentImage
            oSketch.TransparentColor = oTransparentColor
            oSketch.TransparencyThreshold = sTransparencyThreshold
            Call oSketch.Stations.Clear()

            For Each oTPH As cTrigpointPlaceholder In oTrigpointsPlaceholders.Values
                Dim sTrigPoint As String = oTPH.Station
                Dim oPoint As Point = oTPH.Point
                oPoint.X = oPoint.X / sZoomFactor
                oPoint.Y = oPoint.Y / sZoomFactor
                If TypeOf oTPH Is cTrigpointExtraPlaceholder Then
                    Call oSketch.Stations.Add(oPoint, oSurvey.TrigPoints(sTrigPoint), DirectCast(oTPH, cTrigpointExtraPlaceholder).Distance)
                Else
                    Call oSketch.Stations.Add(oPoint, oSurvey.TrigPoints(sTrigPoint))
                End If
            Next

            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        End If
    End Sub

    Private Sub cmdCancel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdCancel.ItemClick
        DialogResult = DialogResult.Cancel
        Call Close()
    End Sub

    Private Sub btnRotate_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRotate.ItemClick
        If MsgBox(GetLocalizedString("imageedit.warning5"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("imageedit.warningtitle")) = MsgBoxResult.Yes Then
            Call pRotateImage()
        End If
    End Sub

    Private Sub btnFlipH_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnFlipH.ItemClick
        If MsgBox(GetLocalizedString("imageedit.warning5"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("imageedit.warningtitle")) = MsgBoxResult.Yes Then
            Call pFlipXImage()
        End If
    End Sub

    Private Sub btnFlipV_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnFlipV.ItemClick
        If MsgBox(GetLocalizedString("imageedit.warning5"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("imageedit.warningtitle")) = MsgBoxResult.Yes Then
            Call pFlipYImage()
        End If
    End Sub

    Private Sub btnToGrayscale_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnToGrayscale.ItemClick
        If MsgBox(GetLocalizedString("imageedit.warning2"), MsgBoxStyle.OkCancel Or MsgBoxStyle.Exclamation, GetLocalizedString("imageedit.warningtitle")) = MsgBoxResult.Ok Then
            Call pGrayScaleImage()
            Call picPreview.Invalidate()
        End If
    End Sub

    Private Sub btnRubber_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRubber.CheckedChanged
        Dim bVisible As Boolean = btnRubber.Checked
        Call pToolStop()
        btnRubberSize.Visibility = If(bVisible, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        If bVisible Then
            iRubberSize = 16 * btnRubberSize.EditValue
            Call pToolStart(ToolEnum.Rubber)
        End If
    End Sub

    Private Sub btnRubberSize_EditValueChanged(sender As Object, e As EventArgs) Handles btnRubberSize.EditValueChanged
        iRubberSize = 16 * btnRubberSize.EditValue
    End Sub

    Private Sub btnStop_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnStop.ItemClick
        Call pToolStop()
    End Sub

    Private Sub btnCropStart_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCropStart.CheckedChanged
        Dim bVisible As Boolean = btnCropStart.Checked
        Call pToolStop()
        btnCrop.Visibility = If(bVisible, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        If bVisible Then
            Call pToolStart(ToolEnum.Cut)
        End If
    End Sub

    Private Sub btnCrop_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCrop.ItemClick
        Call pPreviewCrop()
    End Sub

    Private Sub btnRescale_Popup(sender As Object, e As EventArgs) Handles btnRescale.Popup
        btnRescale0.Enabled = (oCurrentImage.Width > 3096) OrElse (oCurrentImage.Height > 3096)
        btnRescale1.Enabled = (oCurrentImage.Width > 2048) OrElse (oCurrentImage.Height > 2048)
        btnRescale2.Enabled = (oCurrentImage.Width > 1024) OrElse (oCurrentImage.Height > 1024)
        btnRescale3.Enabled = (oCurrentImage.Width > 512) OrElse (oCurrentImage.Height > 512)
    End Sub

    Private Sub btnUndo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnUndo.ItemClick
        If MsgBox(GetLocalizedString("imageedit.warning1"), MsgBoxStyle.OkCancel Or MsgBoxStyle.Exclamation, GetLocalizedString("imageedit.warningtitle")) = MsgBoxResult.Ok Then
            oCurrentImage = oSourceImage.Clone
            Call pRescaleImage(iMaxWidth, iMaxHeight)
            Call picPreview.Invalidate()
        End If
    End Sub

    Private Sub btnTransparentThreshold_EditValueChanged(sender As Object, e As EventArgs) Handles btnTransparentThreshold.EditValueChanged
        Dim sNewTransparencyThreshold As Single = btnTransparentThreshold.EditValue / 100.0F
        If sNewTransparencyThreshold <> sTransparencyThreshold Then
            sTransparencyThreshold = sNewTransparencyThreshold
            Call picPreview.Invalidate()
        End If
    End Sub

    Private Sub btnDeleteTransparent_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnDeleteTransparent.ItemClick
        oTransparentColor = Color.Transparent
        Call picPreview.Invalidate()
    End Sub

    Private Sub btnSetTransparent_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnSetTransparent.ItemClick
        oTransparentColor = oCurrentImage.GetPixel(oLastMousePoint.X, oLastMousePoint.Y)
        Call picPreview.Invalidate()
    End Sub

    Private Sub btnLoadImage_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnLoadImage.ItemClick
        Using oOfd As OpenFileDialog = New OpenFileDialog
            With oOfd
                .Title = GetLocalizedString("imageedit.openimagedialog")
                .Filter = GetLocalizedString("imageedit.filetypeIMAGES") & " (*.JPG;*.PNG;*.TIF;*.BMP;*.GIF)|*.JPG;*.PNG;*.TIF;*.BMP;*.GIF|" & GetLocalizedString("imageedit.filetypeALL") & " (*.*)|*.*"
                .FilterIndex = 1
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Try
                        oSourceImage = modPaint.ImageExifRotate(New Bitmap(.FileName))
                        oCurrentImage = oSourceImage.Clone
                        Call pRescaleImage(iMaxWidth, iMaxHeight)
                        Call picPreview.Invalidate()
                    Catch ex As Exception
                        Call MsgBox(String.Format(GetLocalizedString("imageedit.warning6"), ex.Message), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("imageedit.warningtitle"))
                    End Try
                End If
            End With
        End Using
    End Sub

    Private Sub btnTransparency_Popup(sender As Object, e As EventArgs) Handles btnTransparency.Popup
        If oTransparentColor = Color.Transparent Then
            btnDeleteTransparent.Enabled = False
            btnTransparentThreshold.Enabled = False
        Else
            btnDeleteTransparent.Enabled = True
            btnTransparentThreshold.Enabled = True
        End If
        btnTransparentThreshold.EditValue = sTransparencyThreshold * 100.0F
    End Sub

    Private Sub mnuPreview_Popup(sender As Object, e As EventArgs) Handles mnuPreview.Popup
        If iCurrentTool = ToolEnum.None Then
            If oLastPlaceholder Is Nothing Then
                btnAddExtra.Visibility = BarItemVisibility.Never
                btnEditDistance.Visibility = BarItemVisibility.Never
                btnAdd.Enabled = grdStations.SelectedItem IsNot Nothing
                btnRemove.Enabled = False
                btnRemoveAll.Enabled = oTrigpointsPlaceholders.Count > 0
            Else
                If TypeOf oLastPlaceholder Is cTrigpointExtraPlaceholder Then
                    btnAddExtra.Visibility = BarItemVisibility.Never
                    btnEditDistance.Visibility = BarItemVisibility.Always
                Else
                    btnAddExtra.Visibility = BarItemVisibility.Always
                    btnEditDistance.Visibility = BarItemVisibility.Never
                End If
                btnAdd.Enabled = False
                btnRemove.Enabled = True
                btnRemoveAll.Enabled = oTrigpointsPlaceholders.Count > 0
            End If
        End If
    End Sub

    Private Sub btnRescale0_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRescale0.ItemClick
        If MsgBox(GetLocalizedString("imageedit.warning4"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("imageedit.warningtitle")) = MsgBoxResult.Yes Then
            Call pRescaleImage(3096, 3096)
        End If
    End Sub

    Private Sub btnRescale1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRescale1.ItemClick
        If MsgBox(GetLocalizedString("imageedit.warning4"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("imageedit.warningtitle")) = MsgBoxResult.Yes Then
            Call pRescaleImage(2048, 2048)
        End If
    End Sub

    Private Sub btnRescale2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRescale2.ItemClick
        If MsgBox(GetLocalizedString("imageedit.warning4"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("imageedit.warningtitle")) = MsgBoxResult.Yes Then
            Call pRescaleImage(1024, 1024)
        End If
    End Sub

    Private Sub btnRescale3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRescale3.ItemClick
        If MsgBox(GetLocalizedString("imageedit.warning4"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("imageedit.warningtitle")) = MsgBoxResult.Yes Then
            Call pRescaleImage(512, 512)
        End If
    End Sub

    Private Sub btnShowSplays_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles btnShowSplays.CheckedChanged
        Call pRefreshTrigpointList()
    End Sub

    Private Sub grdStations_ContextMenuShowing(sender As Object, e As MouseEventArgs) Handles grdStations.ContextMenuShowing
        Call mnuStations.ShowPopup(New Point(e.X, e.Y))
    End Sub

End Class
