Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Imports cSurveyPC
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraBars

Friend Class frmImageEdit
    Private oSurvey As cSurvey.cSurvey
    Private oImage As cItemImage
    Private iDesignType As cIDesign.cDesignTypeEnum
    Private oLastMousePoint As Point

    Private sZoomFactor As Single

    Private iMaxWidth As Integer = 3096
    Private iMaxHeight As Integer = 3096

    Private oSourceImage As Bitmap
    Private oCurrentImage As Bitmap
    Private oRubberPoint As PointF
    Private iRubberSize As Integer = 32

    Private oTransparentColor As Color
    Private sTransparencyThreshold As Single

    Private iBorderX As Integer
    Private iBorderY As Integer

    Private iCurrentTool As ToolEnum
    Private oCutRect As RectangleF

    'Private Class cTrigpointPlaceholder
    '    Private oPoint As Point
    '    Private sName As String
    '    Private oArea As Rectangle
    '    Private oHotSpot As Rectangle

    '    Public ReadOnly Property Point As Point
    '        Get
    '            Return oPoint
    '        End Get
    '    End Property

    '    Public ReadOnly Property Name As String
    '        Get
    '            Return sName
    '        End Get
    '    End Property

    '    Public ReadOnly Property Area As Rectangle
    '        Get
    '            Return oArea
    '        End Get
    '    End Property

    '    Public ReadOnly Property HotSpot As Rectangle
    '        Get
    '            Return oHotSpot
    '        End Get
    '    End Property

    '    Public Sub New(Name As String, Point As PointF, Optional NameWidth As Integer = 0)
    '        Dim iSize As Integer = 8
    '        sName = Name
    '        oPoint = New Point(Point.X, Point.Y)
    '        oArea = New Rectangle(oPoint.X, oPoint.Y, iSize * 2, iSize * 2)
    '        oHotSpot = New Rectangle(oPoint.X, oPoint.Y, NameWidth + iSize * 2, iSize * 2)
    '    End Sub
    'End Class

    'Private oTrigpointsPlaceholders As Dictionary(Of String, cTrigpointPlaceholder)

    Private Enum ToolEnum
        None = 0
        Rubber = 1
        Cut = 2
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
        picPreview.Size = oCurrentImage.Size
        picPreview.Refresh()
    End Sub

    Private Sub pFlipYImage()
        Call oCurrentImage.RotateFlip(RotateFlipType.RotateNoneFlipY)
        oCurrentImage = oCurrentImage.Clone
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

            'Else
            '    Dim oNewImage As Bitmap = New Bitmap(oTmpImage.Width, oTmpImage.Height, oCurrentImage.PixelFormat)
            '    Using oGraphics As Graphics = Graphics.FromImage(oNewImage)
            '        Call oGraphics.DrawImage(oTmpImage, 0, 0, oTmpImage.Width, oTmpImage.Height)
            '    End Using
            '    oCurrentImage = oNewImage
        End If
        picPreview.Size = oCurrentImage.Size
        picPreview.Refresh()
    End Sub

    Public Function pGrayScaleImage()
        oCurrentImage = modPaint.GrayScaleImage(oCurrentImage)
    End Function

    Public Sub New(ByVal Image As cItemImage)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Image.Survey
        oImage = Image

        'oTrigpointsPlaceholders = New Dictionary(Of String, cTrigpointPlaceholder)

        iDesignType = oImage.Design.Type

        oSourceImage = modPaint.ImageExifRotate(oImage.Image)
        oCurrentImage = oSourceImage.Clone
        oTransparentColor = oImage.TransparentColor
        sTransparencyThreshold = oImage.TransparencyThreshold
        btnTransparentThreshold.EditValue = sTransparencyThreshold * 100.0F

        Call pRescaleImage(iMaxWidth, iMaxHeight)

        'picPreview.Image = oCurrentImage
        picPreview.Size = oCurrentImage.Size

        sZoomFactor = 1
    End Sub

    Private Sub picPreview_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles picPreview.DoubleClick
        If iCurrentTool = ToolEnum.None Then

        Else
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

    'Private Sub mnuPreview_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    If iCurrentTool = ToolEnum.None Then
    '        For Each oItem As ToolStripItem In mnuPreview.Items
    '            If oItem Is mnuPreviewStop Then
    '                oItem.Visible = False
    '            Else
    '                oItem.Visible = True
    '            End If
    '        Next
    '    Else
    '        For Each oItem As ToolStripItem In mnuPreview.Items
    '            If oItem Is mnuPreviewStop Then
    '                oItem.Visible = True
    '            Else
    '                oItem.Visible = False
    '            End If
    '        Next
    '    End If
    'End Sub

    Private Sub picPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picPreview.Click
        Call pnlPreview.Focus()
    End Sub

    Private Sub btnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sZoomFactor = sZoomFactor * 1.1
        picPreview.Width = oCurrentImage.Width * sZoomFactor
        picPreview.Height = oCurrentImage.Height * sZoomFactor
        Call picPreview.Invalidate()
    End Sub

    Private Sub btnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sZoomFactor = sZoomFactor * 0.909
        picPreview.Width = oCurrentImage.Width * sZoomFactor
        picPreview.Height = oCurrentImage.Height * sZoomFactor
        Call picPreview.Invalidate()
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

            'Call oGraphics.ScaleTransform(sZoomFactor, sZoomFactor)

            Using imgAttributes As System.Drawing.Imaging.ImageAttributes = New System.Drawing.Imaging.ImageAttributes
                If Not oTransparentColor = Color.Transparent Then
                    Call imgAttributes.SetColorKey(modPaint.DarkColor(oTransparentColor, 1.0F - sTransparencyThreshold), modPaint.LightColor(oTransparentColor, 1.0F - sTransparencyThreshold))
                End If
                Call oGraphics.DrawImage(oCurrentImage, New Rectangle(0, 0, picPreview.Width, picPreview.Height), 0, 0, oCurrentImage.Width, oCurrentImage.Height, GraphicsUnit.Pixel, imgAttributes)
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

        cmdok.Enabled = False
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
        cmdok.Enabled = True
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

    Private Sub pPreviewCrop()
        Dim oRect As RectangleF = modPaint.FullScaleRectangle(oCutRect, sZoomFactor)
        If oRect.IsEmpty OrElse oRect.Width = 0 OrElse oRect.Height = 0 Then
            Call cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("imageedit.warning7"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("imageedit.warningtitle"))
        Else
            If cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("imageedit.warning3"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("imageedit.warningtitle")) = MsgBoxResult.Yes Then
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

    Private Sub btnRescale0_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRescale0.ItemClick
        If cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("imageedit.warning4"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("imageedit.warningtitle")) = MsgBoxResult.Yes Then
            Call pRescaleImage(3096, 3096)
        End If
    End Sub

    Private Sub btnRescale1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRescale1.ItemClick
        If cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("imageedit.warning4"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("imageedit.warningtitle")) = MsgBoxResult.Yes Then
            Call pRescaleImage(2048, 2048)
        End If
    End Sub

    Private Sub btnRescale2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRescale2.ItemClick
        If cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("imageedit.warning4"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("imageedit.warningtitle")) = MsgBoxResult.Yes Then
            Call pRescaleImage(1024, 1024)
        End If
    End Sub

    Private Sub btnRescale3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRescale3.ItemClick
        If cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("imageedit.warning4"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("imageedit.warningtitle")) = MsgBoxResult.Yes Then
            Call pRescaleImage(512, 512)
        End If
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

    Private Sub picPreview_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles picPreview.MouseUp
        If iCurrentTool = ToolEnum.Cut AndAlso (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
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
            Dim oPoint As Point = e.Location
            Call picPreview.Invalidate()
            If (e.Button And Windows.Forms.MouseButtons.Right) = Windows.Forms.MouseButtons.Right Then
                Call mnuPreview.ShowPopup(picPreview.PointToScreen(oPoint))
            End If
        End If
    End Sub

    Private Sub cmdok_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdok.ItemClick
        oImage.Image = oCurrentImage
        oImage.TransparentColor = oTransparentColor
        oImage.TransparencyThreshold = sTransparencyThreshold

        DialogResult = DialogResult.OK
        Call Close()
    End Sub

    Private Sub cmdCancel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdCancel.ItemClick
        DialogResult = DialogResult.Cancel
        Call Close()
    End Sub

    Private Sub btnRotate_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRotate.ItemClick
        If cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("imageedit.warning5"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("imageedit.warningtitle")) = MsgBoxResult.Yes Then
            Call pRotateImage()
        End If
    End Sub

    Private Sub btnFlipH_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnFlipH.ItemClick
        If cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("imageedit.warning5"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("imageedit.warningtitle")) = MsgBoxResult.Yes Then
            Call pFlipXImage()
        End If
    End Sub

    Private Sub btnFlipV_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnFlipV.ItemClick
        If cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("imageedit.warning5"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("imageedit.warningtitle")) = MsgBoxResult.Yes Then
            Call pFlipYImage()
        End If
    End Sub

    Private Sub btnToGrayscale_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnToGrayscale.ItemClick
        If cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("imageedit.warning2"), MsgBoxStyle.OkCancel Or MsgBoxStyle.Exclamation, GetLocalizedString("imageedit.warningtitle")) = MsgBoxResult.Ok Then
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
        If cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("imageedit.warning1"), MsgBoxStyle.OkCancel Or MsgBoxStyle.Exclamation, GetLocalizedString("imageedit.warningtitle")) = MsgBoxResult.Ok Then
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
                        Call cSurvey.UIHelpers.Dialogs.Msgbox(String.Format(GetLocalizedString("imageedit.warning6"), ex.Message), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("imageedit.warningtitle"))
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

    'Private Sub picPreview_MouseWheel(sender As Object, e As MouseEventArgs) Handles picPreview.MouseWheel
    '    If e.Delta > 0 Then
    '        btnZoomIn_Click(Nothing, Nothing)
    '    Else
    '        btnZoomOut_Click(Nothing, Nothing)
    '    End If
    'End Sub
End Class
