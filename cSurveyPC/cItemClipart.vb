Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports cSurveyPC.cSurvey.Drawings

Namespace cSurvey.Design.Items
    Public Class cItemClipart
        Inherits cItem
        Implements cIItemClipart

        Private oClipart As cClipart

        Private oDataBounds As RectangleF

        Private oSurvey As cSurvey
        Private iClipartResizeMode As cIItemClipart.ClipartResizeModeEnum

        Public Overrides ReadOnly Property HaveAffinity As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeCopied As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeHiddenInDesign As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeHiddenInPreview As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeLocked As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeSendedToOtherDesign As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeDeleted As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeReduced As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeWarped As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeMoved As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HaveQuota As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveSketch As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveCrossSection As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveSplayBorder As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeConverted As Boolean
            Get
                Return False
            End Get

        End Property

        Public Overrides ReadOnly Property HaveSign As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveImage As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeClipped As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HaveLineType As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveText As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveFont As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeRotated() As Boolean
            Get
                Return True
            End Get
        End Property

        'Friend Overrides Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
        '    Using oMatrix As Matrix = New Matrix
        '        If PaintOptions.DrawTranslation Then
        '            Dim oTranslation As SizeF = MyBase.Design.GetItemTranslation(Me)
        '            Call oMatrix.Translate(oTranslation.Width, oTranslation.Height)
        '        End If
        '        Dim oSVGItem As XmlElement = MyBase.Caches(PaintOptions).ToSvgItem(SVG, PaintOptions, Options, oMatrix)
        '        If MyBase.Name <> "" Then Call oSVGItem.SetAttribute("name", MyBase.Name)
        '        Return oSVGItem
        '    End Using
        'End Function

        'Friend Overrides Function ToSvg(ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlDocument
        '    Dim oSVG As XmlDocument = modSVG.CreateSVG
        '    Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions, Options))
        '    Return oSVG
        'End Function

        Public Overrides ReadOnly Property HaveEditablePoints As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveBrush As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HavePen As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HaveTransparency As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property MaxPointsCount As Integer
            Get
                Return 2
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeResized() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeDivided() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeCombined() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeBinded() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property BindMode As cItem.BindModeEnum
            Get
                Return BindModeEnum.CenterPoint
            End Get
        End Property

        Public Overrides ReadOnly Property CanImportGeneric As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Function FromGeneric(ByVal Item As cItemGeneric, Optional ByVal Clear As Boolean = False) As Boolean
            Return False
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum, ByVal Data As Object, ByVal DataFormat As cIItemClipartBase.cClipartDataFormatEnum)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.Clipart, Category)
            oSurvey = Survey
            Select Case DataFormat
                Case cIItemClipartBase.cClipartDataFormatEnum.SVGFile
                    oClipart = oSurvey.Cliparts.Cliparts.Add(Data)
                Case cIItemClipartBase.cClipartDataFormatEnum.SVGData
                    oClipart = oSurvey.Cliparts.Cliparts.Add("", Data)
                Case Else
                    oClipart = oSurvey.Cliparts.Cliparts(Data)
            End Select
            Call pLoadData()
        End Sub

        Public Overrides Function GetBounds() As RectangleF
            If MyBase.Points.Count > 0 Then
                Dim oDesignBounds As RectangleF = MyBase.Caches.GetBounds
                If modPaint.IsRectangleEmpty(oDesignBounds) Then
                    Return MyBase.GetBounds()
                Else
                    Return oDesignBounds
                End If
            End If
        End Function

        Friend Overrides Function GetClipartScaleFactor(PaintOptions As cOptionsCenterline) As Single
            Return MyBase.GetClipartScaleFactor(PaintOptions)
        End Function

        Public ReadOnly Property Clipart As cClipart Implements cIItemClipart.Clipart
            Get
                Return oClipart
            End Get
        End Property

        Friend Sub GetScaleAndRotateFactors(PaintOptions As cOptions, ByRef Scale As Single, ByRef Angle As Single)
            Dim oBounds As RectangleF = MyBase.GetBounds
            Dim oWarpPoint(3) As PointF
            If MyBase.Points.Count = 2 Then
                oWarpPoint(0) = New PointF(oBounds.Left, oBounds.Top)
                oWarpPoint(1) = New PointF(oBounds.Right, oBounds.Top)
                oWarpPoint(2) = New PointF(oBounds.Left, oBounds.Bottom)
                oWarpPoint(3) = New PointF(oBounds.Right, oBounds.Bottom)
            Else
                Dim oxPoints() As PointF = MyBase.Points.GetPoints()
                oWarpPoint(0) = oxPoints(0)
                oWarpPoint(1) = oxPoints(1)
                oWarpPoint(2) = oxPoints(3)
                oWarpPoint(3) = oxPoints(2)
            End If

            Dim sScale As Single = GetClipartScaleFactor(PaintOptions)

            Using oPath As GraphicsPath = New GraphicsPath
                Dim oPoint1 As PointF = New PointF(0, 0)
                Dim oPoint2 As PointF = New PointF(0, 1)
                Call oPath.AddLine(oPoint1, oPoint2)
                Call oPath.Warp(oWarpPoint, oDataBounds)

                Dim oPoint3 As PointF = New PointF(oPath.PathPoints(1).X - oPath.PathPoints(0).X, oPath.PathPoints(1).Y - oPath.PathPoints(0).Y)
                Scale = sScale * modPaint.DistancePointToPoint(oPoint1, oPoint3)
                Angle = modPaint.NormalizeAngle(modPaint.GetBearing(oPoint1, oPoint3) - 180.0F) ' modPaint.GetAngleBetweenSegment(oPoint1, oPoint2, oPoint1, oPoint3)
            End Using
        End Sub

        Friend Overrides Sub Render(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            Dim oCache As cDrawCache = MyBase.Caches(PaintOptions)
            With oCache
                If .Invalidated Then
                    Call .Clear()
                    Dim oBounds As RectangleF = MyBase.GetBounds
                    Dim oWarpPoint(3) As PointF
                    If MyBase.Points.Count = 2 Then
                        oWarpPoint(0) = New PointF(oBounds.Left, oBounds.Top)
                        oWarpPoint(1) = New PointF(oBounds.Right, oBounds.Top)
                        oWarpPoint(2) = New PointF(oBounds.Left, oBounds.Bottom)
                        oWarpPoint(3) = New PointF(oBounds.Right, oBounds.Bottom)
                    Else
                        Dim oxPoints() As PointF = MyBase.Points.GetPoints()
                        oWarpPoint(0) = oxPoints(0)
                        oWarpPoint(1) = oxPoints(1)
                        oWarpPoint(2) = oxPoints(3)
                        oWarpPoint(3) = oxPoints(2)
                    End If
                    Using oPaths As cDrawPaths = oClipart.Clipart.ClonePaths
                        'apply default scale factor
                        Using oScaleMatrix = New Matrix
                            Dim sScale As Single = GetClipartScaleFactor(PaintOptions)
                            Call oScaleMatrix.Scale(sScale, sScale, MatrixOrder.Append)
                            Call oPaths.Transform(oScaleMatrix)
                        End Using
                        'warping clipart
                        Call oPaths.Warp(oWarpPoint, oDataBounds)
                        Call oPaths.Render(Me, Graphics, PaintOptions, Options, SelectionModeEnum.Selected, oCache)
                    End Using

                    Call .Rendered()
                End If
            End With
        End Sub

        Friend Overrides Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            If MyBase.Points.Count > 1 Then
                Call Render(Graphics, PaintOptions, Options, Selected)
                If Not PaintOptions.IsDesign OrElse (PaintOptions.IsDesign And Not MyBase.HiddenInDesign) Then '
                    Call MyBase.Caches(PaintOptions).Paint(Graphics, PaintOptions, Options)
                    If PaintOptions.ShowSegmentBindings Then
                        Call modPaint.PaintPointToSegmentBindings(Graphics, MyBase.Survey, Me, Selected)
                    End If
                End If
            End If
        End Sub

        Public Sub FixBound(Optional ByVal ForceBound As Boolean = False)
            If (MyBase.Points.Count > 1 And MyBase.Points.Count < 3) Then
                Dim oxPoints() As PointF = MyBase.Points.GetPoints()
                Dim oSize As SizeF = New SizeF(oxPoints(1).X - oxPoints(0).X, oxPoints(1).Y - oxPoints(0).Y)
                Dim oRect As RectangleF = New RectangleF(oxPoints(0), oSize)
                With MyBase.Points
                    Call .BeginUpdate()
                    Call .Clear()
                    Call .AddFromPaintPoint(oRect.Left, oRect.Top)
                    Call .AddFromPaintPoint(oRect.Right, oRect.Top)
                    Call .AddFromPaintPoint(oRect.Right, oRect.Bottom)
                    Call .AddFromPaintPoint(oRect.Left, oRect.Bottom)
                    Call .EndUpdate()
                End With
            ElseIf MyBase.Points.Count < 1 Or ForceBound Then
                Dim oRect As RectangleF = oDataBounds
                With MyBase.Points
                    Call .BeginUpdate()
                    Call .Clear()
                    Call .AddFromPaintPoint(oRect.Left, oRect.Top)
                    Call .AddFromPaintPoint(oRect.Right, oRect.Top)
                    Call .AddFromPaintPoint(oRect.Right, oRect.Bottom)
                    Call .AddFromPaintPoint(oRect.Left, oRect.Bottom)
                    Call .EndUpdate()
                End With
            End If
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As cFile, ByVal item As XmlElement)
            Call MyBase.New(Survey, Design, Layer, File, item)
            oSurvey = Survey
            Dim sData As String = modXML.GetAttributeValue(item, "data", "")
            Dim iDataFormat As cIItemClipartBase.cClipartDataFormatEnum = modXML.GetAttributeValue(item, "dataformat", cIItemClipartBase.cClipartDataFormatEnum.SVGResource)
            Select Case iDataFormat
                Case cIItemClipartBase.cClipartDataFormatEnum.SVGFile
                    oClipart = oSurvey.Cliparts.Cliparts.Add(sData)
                Case cIItemClipartBase.cClipartDataFormatEnum.SVGData
                    oClipart = oSurvey.Cliparts.Cliparts.Add("", sData)
                Case cIItemClipartBase.cClipartDataFormatEnum.SVGResource
                    oClipart = oSurvey.Cliparts.Cliparts(sData)
            End Select
            If IsNothing(oClipart) Then
                oClipart = oSurvey.Signs.Cliparts.Add("", My.Resources.clipart_error)
            End If
            iClipartResizeMode = modXML.GetAttributeValue(item, "clipartresizemode", cIItemClipart.ClipartResizeModeEnum.Stretched)
            Call pLoadData()
            Call FixBound()
        End Sub

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oItem As XmlElement = MyBase.SaveTo(File, Document, Parent, Options)
            If (File.Options And cFile.FileOptionsEnum.[EmbedResource]) = cFile.FileOptionsEnum.[EmbedResource] Then
                Call oItem.SetAttribute("data", oClipart.Clipart.Data)
                Call oItem.SetAttribute("dataformat", cIItemClipartBase.cClipartDataFormatEnum.SVGData.ToString("D"))
            Else
                Call oItem.SetAttribute("data", oClipart.ID)
                Call oItem.SetAttribute("dataformat", cIItemClipartBase.cClipartDataFormatEnum.SVGResource.ToString("D"))
            End If
            'Select Case File.FileFormat
            '    Case cFile.FileFormatEnum.CSX
            '        Call oItem.SetAttribute("data", oClipart.ID)
            '        Call oItem.SetAttribute("dataformat", cItemClipartDataFormatEnum.SVGResource.ToString("D"))
            '    Case Else
            '        Call oItem.SetAttribute("data", oClipart.ID)
            '        Call oItem.SetAttribute("dataformat", cItemClipartDataFormatEnum.SVGResource.ToString("D"))
            'End Select
            If iClipartResizeMode <> cIItemClipart.ClipartResizeModeEnum.Stretched Then Call oItem.SetAttribute("clipartresizemode", iClipartResizeMode.ToString("D"))
            Return oItem
        End Function

        Private Sub pLoadData()
            oDataBounds = oClipart.Clipart.GetBounds
        End Sub

        Public Property ClipartResizeMode() As cIItemClipart.ClipartResizeModeEnum Implements cIItemClipart.ClipartResizeMode
            Get
                Return iClipartResizeMode
            End Get
            Set(ByVal value As cIItemClipart.ClipartResizeModeEnum)
                If iClipartResizeMode <> value Then
                    iClipartResizeMode = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Friend Overrides Sub BindSegments()
            If MyBase.Cave = "" Then
                For Each oPoint As cPoint In MyBase.Points
                    oPoint.SegmentLocked = False
                    Call oPoint.BindSegment(Nothing)
                Next
            Else
                If MyBase.Points.Count > 0 Then
                    Dim oCenterPoint As PointF = GetCenterPoint()
                    Dim oSegment As cISegment = MyBase.Design.GetNearestSegment(MyBase.Cave, MyBase.Branch, MyBase.CrossSection, oCenterPoint.X, oCenterPoint.Y, MyBase.BindDesignType)
                    For Each oPoint As cPoint In MyBase.Points
                        If Not oPoint.SegmentLocked Then
                            Call oPoint.BindSegment(oSegment)
                        End If
                    Next
                End If
            End If
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class

End Namespace
