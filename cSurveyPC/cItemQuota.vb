Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings

Namespace cSurvey.Design.Items
    Public Class cItemQuota
        Inherits cItem
        Implements cIItemQuota

        Public Enum TextRotateModeEnum
            Rotable = 0
            Fixed = 1
        End Enum

        Private oSurvey As cSurvey

        Private sText As String
        Private WithEvents oFont As cItemFont

        Private iTextSize As cIItemText.TextSizeEnum

        Private sAngle As Single

        Private sQuotaFormat As String
        Private iQuotaType As cIItemQuota.QuotaTypeEnum
        Private iQuotaAlign As cIItemQuota.QuotaAlignEnum
        Private iQuotaTextPosition As cIItemQuota.QuotaTextPositionEnum
        Private iQuotaValue As cIItemQuota.QuotaValueEnum
        Private iQuotaValueType As cIItemQuota.QuotaValueTypeEnum

        Private iQuotaTickFrequency As Integer
        Private iQuotaTickLabelFrequency As Integer
        Private sQuotaTickSize As Single

        Private sQuotaRelativeTrigPoint As String

        Private iQuotaCapDecoration As cIItemQuota.QuotaCapDecorationEnum
        Private sQuotaLeftRefPercent As Single
        Private sQuotaRightRefPercent As Single

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

        Public ReadOnly Property AvaiableTextProperties As cIItemText.AvaiableTextPropertiesEnum Implements cIItemText.AvaiableTextProperties
            Get
                Return cIItemText.AvaiableTextPropertiesEnum.None
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeReduced As Boolean
            Get
                Return False
            End Get
        End Property

        Public Property QuotaCapDecoration As cIItemQuota.QuotaCapDecorationEnum Implements cIItemQuota.QuotaCapDecoration
            Get
                Return iQuotaCapDecoration
            End Get
            Set(value As cIItemQuota.QuotaCapDecorationEnum)
                If iQuotaCapDecoration <> value Then
                    iQuotaCapDecoration = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property QuotaRightRefPercent As Single Implements cIItemQuota.QuotaRightRefPercent
            Get
                Return sQuotaRightRefPercent
            End Get
            Set(value As Single)
                If sQuotaRightRefPercent <> value Then
                    sQuotaRightRefPercent = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Overrides ReadOnly Property HaveTransparency As Boolean
            Get
                Return True
            End Get
        End Property

        Public Property QuotaLeftRefPercent As Single Implements cIItemQuota.QuotaLeftRefPercent
            Get
                Return sQuotaLeftRefPercent
            End Get
            Set(value As Single)
                If sQuotaLeftRefPercent <> value Then
                    sQuotaLeftRefPercent = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
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

        Public Overrides ReadOnly Property HaveSketch As Boolean
            Get
                Return False
            End Get

        End Property
        Public Overrides ReadOnly Property HaveQuota As Boolean
            Get
                Return True
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
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveText As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property BindMode As cItem.BindModeEnum
            Get
                Return BindModeEnum.CenterPoint
            End Get
        End Property

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

        Public Overrides ReadOnly Property HaveLineType As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveFont As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeRotated As Boolean
            Get
                Return iQuotaType = cIItemQuota.QuotaTypeEnum.Oblique  ' iTextRotateMode = TextRotateModeEnum.Rotable
            End Get
        End Property

        Public Overrides ReadOnly Property HaveEditablePoints As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveBrush As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HavePen As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property MaxPointsCount As Integer
            Get
                Return 2
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeResized() As Boolean
            Get
                Return iQuotaType <> cIItemQuota.QuotaTypeEnum.Drop And iQuotaType <> cIItemQuota.QuotaTypeEnum.Altitude
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

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum, ByVal Text As String)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.Quota, Category)
            oSurvey = Survey
            oFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.Generic)
            sText = "" & Text

            sQuotaFormat = ""
            iQuotaAlign = cIItemQuota.QuotaAlignEnum.Center
            iQuotaTextPosition = cIItemQuota.QuotaTextPositionEnum.RightBottom
            iQuotaValue = cIItemQuota.QuotaValueEnum.Automatic
            iQuotaType = cIItemQuota.QuotaTypeEnum.Vertical
            iQuotaValueType = cIItemQuota.QuotaValueTypeEnum.Default

            sQuotaRelativeTrigPoint = ""

            iQuotaTickFrequency = 1
            iQuotaTickLabelFrequency = 5
            sQuotaTickSize = 0.3

            sQuotaLeftRefPercent = 100
            sQuotaRightRefPercent = 100
            iQuotaCapDecoration = cIItemQuota.QuotaCapDecorationEnum.Arrow
        End Sub

        Friend Overrides Function GetTextScaleFactor(PaintOptions As cOptions) As Single
            Dim sTextScaleFactor As Single = MyBase.GetTextScaleFactor(PaintOptions)
            Select Case iTextSize
                Case cIItemText.TextSizeEnum.Default
                    Return 1 * sTextScaleFactor
                Case cIItemText.TextSizeEnum.VerySmall
                    Return 0.25 * sTextScaleFactor
                Case cIItemText.TextSizeEnum.Small
                    Return 0.5 * sTextScaleFactor
                Case cIItemText.TextSizeEnum.Medium
                    Return 1 * sTextScaleFactor
                Case cIItemText.TextSizeEnum.Large
                    Return 2 * sTextScaleFactor
                Case cIItemText.TextSizeEnum.VeryLarge
                    Return 4 * sTextScaleFactor
            End Select
        End Function

        Public Overrides Sub Rotate(ByVal Angle As Single)
            sAngle += Angle
            Call MyBase.Caches.Invalidate()
        End Sub

        Public Overrides Sub RotateAt(ByVal Center As PointF, ByVal Angle As Single)
            sAngle += Angle
            Call MyBase.RotateAt(Center, Angle)
            Call MyBase.Caches.Invalidate()
        End Sub

        Friend Overrides Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
            Using oMatrix As Matrix = New Matrix
                If PaintOptions.DrawTranslation Then
                    Dim oTranslation As SizeF = MyBase.Design.GetItemTranslation(Me)
                    Call oMatrix.Translate(oTranslation.Width, oTranslation.Height)
                End If
                Dim oSVGItem As XmlElement = MyBase.Caches(PaintOptions).ToSvgItem(SVG, PaintOptions, Options, oMatrix)
                Call oSVGItem.SetAttribute("name", MyBase.Name)
                Return oSVGItem
            End Using
        End Function

        Public Overrides Sub ResizeBy(ByVal ScaleWidth As Single, ByVal ScaleHeight As Single)
            Select Case iQuotaType
                Case cIItemQuota.QuotaTypeEnum.Horizontal, cIItemQuota.QuotaTypeEnum.HorizontalScale
                    'ScaleHeight = 1
                    Call MyBase.ResizeBy(ScaleWidth, ScaleHeight)
                Case cIItemQuota.QuotaTypeEnum.Vertical, cIItemQuota.QuotaTypeEnum.VerticalScale
                    'ScaleWidth = 1
                    Call MyBase.ResizeBy(ScaleWidth, ScaleHeight)
                Case cIItemQuota.QuotaTypeEnum.GridScale, cIItemQuota.QuotaTypeEnum.Oblique
                    Call MyBase.ResizeBy(ScaleWidth, ScaleHeight)
                Case Else
            End Select
        End Sub

        Public Overrides Sub ResizeTo(ByVal Width As Single, ByVal Height As Single)
            Select Case iQuotaType
                Case cIItemQuota.QuotaTypeEnum.Horizontal, cIItemQuota.QuotaTypeEnum.HorizontalScale
                    Call MyBase.ResizeTo(Width, Height)
                Case cIItemQuota.QuotaTypeEnum.Vertical, cIItemQuota.QuotaTypeEnum.VerticalScale
                    Call MyBase.ResizeTo(Width, Height)
                Case cIItemQuota.QuotaTypeEnum.GridScale, cIItemQuota.QuotaTypeEnum.Oblique
                    Call MyBase.ResizeTo(Width, Height)
                Case Else
            End Select
        End Sub

        Public Overrides Sub ResizeTo(ByVal Size As SizeF)
            Call ResizeTo(Size.Width, Size.Height)
        End Sub

        Public Overrides Sub ResizeBy(ByVal Size As SizeF)
            Call ResizeBy(Size.Width, Size.Height)
        End Sub

        Public Overrides Sub MoveTo(X As Single, Y As Single)
            MyBase.MoveTo(X, Y)
            Call MyBase.Caches.Invalidate()
        End Sub

        Public Overrides Sub MoveTo(Point As PointF)
            MyBase.MoveTo(Point)
            Call MyBase.Caches.Invalidate()
        End Sub

        Public Overrides Sub MoveBy(Size As SizeF)
            MyBase.MoveBy(Size)
            Call MyBase.Caches.Invalidate()
        End Sub

        Public Overrides Sub MoveBy(OffsetX As Single, OffsetY As Single)
            MyBase.MoveBy(OffsetX, OffsetY)
            Call MyBase.Caches.Invalidate()
        End Sub

        Friend Overrides Function ToSvg(ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlDocument
            Dim oSVG As XmlDocument = modSVG.CreateSVG
            Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions, Options))
            Return oSVG
        End Function

        Friend Overrides Sub Render(ByVal Graphics As System.Drawing.Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            Dim oCache As cDrawCache = MyBase.Caches(PaintOptions)
            With oCache
                If .Invalidated Then
                    Call .Clear()

                    Using oPen As Pen = New Pen(Color.FromArgb((1 - MyBase.Transparency) * 255, Color.Black))
                        oPen.Width = 0.01 ' -1
                        Using oWireframePen As Pen = oPen.Clone
                            oWireframePen.DashStyle = DashStyle.Dot
                            Using oBoundPath As GraphicsPath = New GraphicsPath
                                'If MyBase.Points.Count > 1 Then
                                Call oBoundPath.AddLine(MyBase.Points(0).Point.X, MyBase.Points(0).Point.Y, MyBase.Points(1).Point.X, MyBase.Points(1).Point.Y)
                                'Else
                                '    Call oBoundPath.AddLine(MyBase.Points(0).Point.X - 0.5F, MyBase.Points(0).Point.Y + 0.5F, MyBase.Points(0).Point.X + 1.0F, MyBase.Points(0).Point.Y + 1.0F)
                                'End If
                                Dim oBounds As RectangleF = oBoundPath.GetBounds

                                Dim oCenterPoint As PointF = New PointF(oBounds.Left + oBounds.Width / 2, oBounds.Top + oBounds.Height / 2)
                                Dim sWidth As Single = oBounds.Width
                                Dim sHalfWidth As Single = oBounds.Width / 2
                                Dim sHeight As Single = oBounds.Height
                                Dim sHalfHeight As Single = oBounds.Height / 2

                                Using oPath As GraphicsPath = New GraphicsPath
                                    Using oSF As StringFormat = New StringFormat
                                        If iQuotaType <> cIItemQuota.QuotaTypeEnum.VerticalScale And iQuotaType <> cIItemQuota.QuotaTypeEnum.HorizontalScale And iQuotaType <> cIItemQuota.QuotaTypeEnum.GridScale Then
                                            If iQuotaValue = cIItemQuota.QuotaValueEnum.Automatic Then
                                                sText = ""
                                                Try
                                                    Dim sValue As Single
                                                    Select Case iQuotaType
                                                        Case cIItemQuota.QuotaTypeEnum.Vertical
                                                            sValue = oBounds.Height
                                                        Case cIItemQuota.QuotaTypeEnum.Horizontal
                                                            sValue = oBounds.Width
                                                        Case cIItemQuota.QuotaTypeEnum.Oblique
                                                            sValue = modPaint.DistancePointToPoint(MyBase.Points(0).Point, MyBase.Points(1).Point)
                                                        Case cIItemQuota.QuotaTypeEnum.Drop
                                                            If MyBase.Design.Type = cIDesign.cDesignTypeEnum.Plan Then
                                                                sText = GetLocalizedString("itemquota.textpart1")
                                                            Else
                                                                If sQuotaRelativeTrigPoint = "" Then
                                                                    Try
                                                                        sQuotaRelativeTrigPoint = oSurvey.TrigPoints.GetCaveFirstEntrance(MyBase.Cave, cTrigPoint.EntranceTypeEnum.MainCaveEntrace).Name
                                                                    Catch
                                                                        sQuotaRelativeTrigPoint = ""
                                                                    End Try
                                                                End If
                                                                If sQuotaRelativeTrigPoint = "" Then
                                                                    sText = GetLocalizedString("itemquota.textpart2")
                                                                Else
                                                                    sValue = oSurvey.TrigPoints(sQuotaRelativeTrigPoint).Data.Z - oCenterPoint.Y
                                                                End If
                                                            End If
                                                        Case cIItemQuota.QuotaTypeEnum.Altitude
                                                            If MyBase.Design.Type = cIDesign.cDesignTypeEnum.Plan Or Not oSurvey.Properties.GPS.Enabled Then
                                                                sText = GetLocalizedString("itemquota.textpart1")
                                                                sValue = 0
                                                            Else
                                                                sText = ""
                                                                Dim oGPSTrigpoint As cTrigPoint = oSurvey.TrigPoints.GetGPSBaseReferencePoint
                                                                sValue = oGPSTrigpoint.Coordinate.GetAltitude + oGPSTrigpoint.Data.Z - oCenterPoint.Y 'oSurvey.TrigPoints.OffsetZ - oCenterPoint.Y
                                                            End If
                                                    End Select
                                                    If Not sText.StartsWith("#") Then
                                                        Dim sFormat As String = sQuotaFormat
                                                        Select Case iQuotaValueType
                                                            Case cIItemQuota.QuotaValueTypeEnum.Default, cIItemQuota.QuotaValueTypeEnum.Meters
                                                                If sFormat = "" Then sFormat = "+0;-0;0" '"+0.00;-0.00;0.00"
                                                                sText = Strings.Format(sValue, sFormat) & " " & cSegment.GetDistanceSimbol(cSegment.DistanceTypeEnum.Meters)
                                                            Case cIItemQuota.QuotaValueTypeEnum.Feet
                                                                If sFormat = "" Then sFormat = "+0;-0;0" '"+0.00;-0.00;0.00"
                                                                sValue = modConversion.MetersToFeet(sValue)
                                                                sText = Strings.Format(sValue, sFormat) & " " & cSegment.GetDistanceSimbol(cSegment.DistanceTypeEnum.Feet)
                                                            Case cIItemQuota.QuotaValueTypeEnum.Yards
                                                                If sFormat = "" Then sFormat = "+0;-0;0" '"+0.00;-0.00;0.00"
                                                                sValue = modConversion.MetersToYards(sValue)
                                                                sText = Strings.Format(sValue, sFormat) & " " & cSegment.GetDistanceSimbol(cSegment.DistanceTypeEnum.Yards)
                                                            Case Else
                                                                If sFormat = "" Then sFormat = "+0;-0;0" '"+0.00;-0.00;0.00"
                                                                sText = Strings.Format(sValue, sFormat)
                                                        End Select
                                                        'Else
                                                        '    sText = ""
                                                    End If
                                                Catch ex As Exception
                                                    sText = String.Format(GetLocalizedString("itemquota.textpart3"), ex.Message)
                                                End Try
                                            End If
                                            Call oFont.AddToPath(PaintOptions, oPath, sText, New PointF(0, 0), oSF)
                                        End If

                                        'dimensiono la clipart se rischiesto (il fattore di scala sarà da parametrizzare in qualche modo)
                                        Dim sScale As Single = GetTextScaleFactor(PaintOptions)
                                        Using oScaleMatrix As Matrix = New Matrix
                                            Call oScaleMatrix.Scale(sScale, sScale, MatrixOrder.Append)
                                            Call oPath.Transform(oScaleMatrix)
                                        End Using

                                        Dim sTextHeight As Single = oPath.GetBounds.Height * 2
                                        Dim sTextWidth As Single = oPath.GetBounds.Width * 1.3
                                        Select Case iQuotaType
                                            Case cIItemQuota.QuotaTypeEnum.Vertical
                                                Using oArrowPen As Pen = oPen.Clone
                                                    Select Case iQuotaCapDecoration
                                                        Case cIItemQuota.QuotaCapDecorationEnum.Arrow
                                                            oArrowPen.EndCap = LineCap.Custom
                                                            oArrowPen.CustomEndCap = New AdjustableArrowCap(5, 5, True)
                                                        Case cIItemQuota.QuotaCapDecorationEnum.Bars
                                                            oArrowPen.EndCap = LineCap.NoAnchor
                                                    End Select

                                                    Dim sQuotaGap As Single = oBounds.Width / 20.0F
                                                    Select Case iQuotaAlign
                                                        Case cIItemQuota.QuotaAlignEnum.Left
                                                            Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Left, oBounds.Top), New PointF(oBounds.Left + oBounds.Width * sQuotaLeftRefPercent / 100, oBounds.Top))
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Left, oBounds.Bottom), New PointF(oBounds.Left + oBounds.Width * sQuotaRightRefPercent / 100, oBounds.Bottom))
                                                                Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                            End Using

                                                            If iQuotaCapDecoration = cIItemQuota.QuotaCapDecorationEnum.Bars Then
                                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                    Call oQuotaPath.AddLine(New PointF(oBounds.Left + sQuotaGap - sHalfWidth / 10, oBounds.Top), New PointF(oBounds.Left + sQuotaGap + sHalfWidth / 10, oBounds.Top))
                                                                    Using oMatrix As Matrix = New Matrix
                                                                        Call oMatrix.RotateAt(-45.0F, New PointF(oBounds.Left + sQuotaGap, oBounds.Top))
                                                                        Call oQuotaPath.Transform(oMatrix)
                                                                    End Using
                                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                                End Using
                                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                    Call oQuotaPath.AddLine(New PointF(oBounds.Left + sQuotaGap - sHalfWidth / 10, oBounds.Bottom), New PointF(oBounds.Left + sQuotaGap + sHalfWidth / 10, oBounds.Bottom))
                                                                    Using oMatrix As Matrix = New Matrix
                                                                        Call oMatrix.RotateAt(45.0F, New PointF(oBounds.Left + sQuotaGap, oBounds.Bottom))
                                                                        Call oQuotaPath.Transform(oMatrix)
                                                                    End Using
                                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                                End Using
                                                            End If

                                                            Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Left + sQuotaGap, oBounds.Top + sHalfHeight - sTextHeight / 2), New PointF(oBounds.Left + sQuotaGap, oBounds.Top))
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Left + sQuotaGap, oBounds.Top + sHalfHeight + sTextHeight / 2), New PointF(oBounds.Left + sQuotaGap, oBounds.Bottom))
                                                                oCenterPoint = New PointF(oBounds.Left + sQuotaGap, oBounds.Top + sHalfHeight)
                                                                Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oArrowPen, oArrowPen, Nothing)
                                                            End Using
                                                        Case cIItemQuota.QuotaAlignEnum.Right
                                                            Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Right - oBounds.Width * sQuotaLeftRefPercent / 100, oBounds.Top), New PointF(oBounds.Right, oBounds.Top))
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Right - oBounds.Width * sQuotaRightRefPercent / 100, oBounds.Bottom), New PointF(oBounds.Right, oBounds.Bottom))
                                                                Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                            End Using

                                                            If iQuotaCapDecoration = cIItemQuota.QuotaCapDecorationEnum.Bars Then
                                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                    Call oQuotaPath.AddLine(New PointF(oBounds.Right - sQuotaGap - sHalfWidth / 10, oBounds.Top), New PointF(oBounds.Right - sQuotaGap + sHalfWidth / 10, oBounds.Top))
                                                                    Using oMatrix As Matrix = New Matrix
                                                                        Call oMatrix.RotateAt(45.0F, New PointF(oBounds.Right - sQuotaGap, oBounds.Top))
                                                                        Call oQuotaPath.Transform(oMatrix)
                                                                    End Using
                                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                                End Using
                                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                    Call oQuotaPath.AddLine(New PointF(oBounds.Right - sQuotaGap - sHalfWidth / 10, oBounds.Bottom), New PointF(oBounds.Right - sQuotaGap + sHalfWidth / 10, oBounds.Bottom))
                                                                    Using oMatrix As Matrix = New Matrix
                                                                        Call oMatrix.RotateAt(-45.0F, New PointF(oBounds.Right - sQuotaGap, oBounds.Bottom))
                                                                        Call oQuotaPath.Transform(oMatrix)
                                                                    End Using
                                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                                End Using
                                                            End If

                                                            Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Right - sQuotaGap, oBounds.Top + sHalfHeight - sTextHeight / 2), New PointF(oBounds.Right - sQuotaGap, oBounds.Top))
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Right - sQuotaGap, oBounds.Top + sHalfHeight + sTextHeight / 2), New PointF(oBounds.Right - sQuotaGap, oBounds.Bottom))
                                                                oCenterPoint = New PointF(oBounds.Right - sQuotaGap, oBounds.Top + sHalfHeight)
                                                                Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oArrowPen, oArrowPen, Nothing)
                                                            End Using
                                                        Case Else
                                                            Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                Dim sRefWidth As Single
                                                                Dim sRefLeft As Single
                                                                sRefWidth = oBounds.Width * sQuotaLeftRefPercent / 100
                                                                sRefLeft = oBounds.Left + (oBounds.Width - sRefWidth) / 2
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(sRefLeft, oBounds.Top), New PointF(sRefLeft + sRefWidth, oBounds.Top))
                                                                sRefWidth = oBounds.Width * sQuotaRightRefPercent / 100
                                                                sRefLeft = oBounds.Left + (oBounds.Width - sRefWidth) / 2
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(sRefLeft, oBounds.Bottom), New PointF(sRefLeft + sRefWidth, oBounds.Bottom))
                                                                Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                            End Using

                                                            If iQuotaCapDecoration = cIItemQuota.QuotaCapDecorationEnum.Bars Then
                                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                    Call oQuotaPath.AddLine(New PointF(oBounds.Left + sHalfWidth - sHalfWidth / 10, oBounds.Top), New PointF(oBounds.Left + sHalfWidth + sHalfWidth / 10, oBounds.Top))
                                                                    Using oMatrix As Matrix = New Matrix
                                                                        Call oMatrix.RotateAt(45.0F, New PointF(oBounds.Left + sHalfWidth, oBounds.Top))
                                                                        Call oQuotaPath.Transform(oMatrix)
                                                                    End Using
                                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                                End Using
                                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                    Call oQuotaPath.AddLine(New PointF(oBounds.Left + sHalfWidth - sHalfWidth / 10, oBounds.Top), New PointF(oBounds.Left + sHalfWidth + sHalfWidth / 10, oBounds.Top))
                                                                    Using oMatrix As Matrix = New Matrix
                                                                        Call oMatrix.RotateAt(-45.0F, New PointF(oBounds.Left + sHalfWidth, oBounds.Top))
                                                                        Call oQuotaPath.Transform(oMatrix)
                                                                    End Using
                                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                                End Using
                                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                    Call oQuotaPath.AddLine(New PointF(oBounds.Left + sHalfWidth - sHalfWidth / 10, oBounds.Bottom), New PointF(oBounds.Left + sHalfWidth + sHalfWidth / 10, oBounds.Bottom))
                                                                    Using oMatrix As Matrix = New Matrix
                                                                        Call oMatrix.RotateAt(45.0F, New PointF(oBounds.Left + sHalfWidth, oBounds.Bottom))
                                                                        Call oQuotaPath.Transform(oMatrix)
                                                                    End Using
                                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                                End Using
                                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                    Call oQuotaPath.AddLine(New PointF(oBounds.Left + sHalfWidth - sHalfWidth / 10, oBounds.Bottom), New PointF(oBounds.Left + sHalfWidth + sHalfWidth / 10, oBounds.Bottom))
                                                                    Using oMatrix As Matrix = New Matrix
                                                                        Call oMatrix.RotateAt(-45.0F, New PointF(oBounds.Left + sHalfWidth, oBounds.Bottom))
                                                                        Call oQuotaPath.Transform(oMatrix)
                                                                    End Using
                                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                                End Using
                                                            End If

                                                            Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Left + sHalfWidth, oBounds.Top + sHalfHeight - sTextHeight / 2), New PointF(oBounds.Left + sHalfWidth, oBounds.Top))
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Left + sHalfWidth, oBounds.Top + sHalfHeight - sTextHeight / 2), New PointF(oBounds.Left + sHalfWidth, oBounds.Top))
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Left + sHalfWidth, oBounds.Top + sHalfHeight + sTextHeight / 2), New PointF(oBounds.Left + sHalfWidth, oBounds.Bottom))
                                                                oCenterPoint = New PointF(oBounds.Left + sHalfWidth, oBounds.Top + sHalfHeight)
                                                                Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oArrowPen, oArrowPen, Nothing)
                                                            End Using
                                                    End Select

                                                End Using
                                            Case cIItemQuota.QuotaTypeEnum.Horizontal
                                                Using oArrowPen As Pen = oPen.Clone
                                                    Select Case iQuotaCapDecoration
                                                        Case cIItemQuota.QuotaCapDecorationEnum.Arrow
                                                            oArrowPen.EndCap = LineCap.Custom
                                                            oArrowPen.CustomEndCap = New AdjustableArrowCap(5, 5, True)
                                                        Case cIItemQuota.QuotaCapDecorationEnum.Bars
                                                            oArrowPen.EndCap = LineCap.NoAnchor
                                                    End Select

                                                    Dim sQuotaGap As Single = oBounds.Height / 20.0F
                                                    Select Case iQuotaAlign
                                                        Case cIItemQuota.QuotaAlignEnum.Left
                                                            Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Left, oBounds.Top), New PointF(oBounds.Left, oBounds.Top + oBounds.Height * sQuotaLeftRefPercent / 100))
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Right, oBounds.Top), New PointF(oBounds.Right, oBounds.Top + oBounds.Height * sQuotaRightRefPercent / 100))
                                                                Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                            End Using

                                                            If iQuotaCapDecoration = cIItemQuota.QuotaCapDecorationEnum.Bars Then
                                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                    Call oQuotaPath.AddLine(New PointF(oBounds.Left, oBounds.Top + sQuotaGap - sHalfWidth / 10), New PointF(oBounds.Left, oBounds.Top + sQuotaGap + sHalfWidth / 10))
                                                                    Using oMatrix As Matrix = New Matrix
                                                                        Call oMatrix.RotateAt(45.0F, New PointF(oBounds.Left, oBounds.Top + sQuotaGap))
                                                                        Call oQuotaPath.Transform(oMatrix)
                                                                    End Using
                                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                                End Using
                                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                    Call oQuotaPath.AddLine(New PointF(oBounds.Right, oBounds.Top + sQuotaGap - sHalfWidth / 10), New PointF(oBounds.Right, oBounds.Top + sQuotaGap + sHalfWidth / 10))
                                                                    Using oMatrix As Matrix = New Matrix
                                                                        Call oMatrix.RotateAt(-45.0F, New PointF(oBounds.Right, oBounds.Top + sQuotaGap))
                                                                        Call oQuotaPath.Transform(oMatrix)
                                                                    End Using
                                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                                End Using
                                                            End If

                                                            Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Left + sHalfWidth - sTextWidth / 2, oBounds.Top + sQuotaGap), New PointF(oBounds.Left, oBounds.Top + sQuotaGap))
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Left + sHalfWidth + sTextWidth / 2, oBounds.Top + sQuotaGap), New PointF(oBounds.Right, oBounds.Top + sQuotaGap))
                                                                oCenterPoint = New PointF(oBounds.Left + sHalfWidth, oBounds.Top + sQuotaGap)
                                                                Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oArrowPen, oArrowPen, Nothing)
                                                            End Using
                                                        Case cIItemQuota.QuotaAlignEnum.Right
                                                            Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Left, oBounds.Bottom - oBounds.Height * sQuotaLeftRefPercent / 100), New PointF(oBounds.Left, oBounds.Bottom))
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Right, oBounds.Bottom - oBounds.Height * sQuotaRightRefPercent / 100), New PointF(oBounds.Right, oBounds.Bottom))
                                                                Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                            End Using

                                                            If iQuotaCapDecoration = cIItemQuota.QuotaCapDecorationEnum.Bars Then
                                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                    Call oQuotaPath.AddLine(New PointF(oBounds.Left, oBounds.Bottom - sQuotaGap - sHalfWidth / 10), New PointF(oBounds.Left, oBounds.Bottom - sQuotaGap + sHalfWidth / 10))
                                                                    Using oMatrix As Matrix = New Matrix
                                                                        Call oMatrix.RotateAt(-45.0F, New PointF(oBounds.Left, oBounds.Bottom - sQuotaGap))
                                                                        Call oQuotaPath.Transform(oMatrix)
                                                                    End Using
                                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                                End Using
                                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                    Call oQuotaPath.AddLine(New PointF(oBounds.Right, oBounds.Bottom - sQuotaGap - sHalfWidth / 10), New PointF(oBounds.Right, oBounds.Bottom - sQuotaGap + sHalfWidth / 10))
                                                                    Using oMatrix As Matrix = New Matrix
                                                                        Call oMatrix.RotateAt(45.0F, New PointF(oBounds.Right, oBounds.Bottom - sQuotaGap))
                                                                        Call oQuotaPath.Transform(oMatrix)
                                                                    End Using
                                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                                End Using
                                                            End If

                                                            Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Left + sHalfWidth - sTextWidth / 2, oBounds.Bottom - sQuotaGap), New PointF(oBounds.Left, oBounds.Bottom - sQuotaGap))
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Left + sHalfWidth + sTextWidth / 2, oBounds.Bottom - sQuotaGap), New PointF(oBounds.Right, oBounds.Bottom - sQuotaGap))
                                                                oCenterPoint = New PointF(oBounds.Left + sHalfWidth, oBounds.Bottom - sQuotaGap)
                                                                Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oArrowPen, oArrowPen, Nothing)

                                                            End Using
                                                        Case Else
                                                            Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                Dim sRefHeight As Single
                                                                Dim sRefTop As Single
                                                                sRefHeight = oBounds.Height * sQuotaLeftRefPercent / 100
                                                                sRefTop = oBounds.Top + (oBounds.Height - sRefHeight) / 2
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Left, sRefTop), New PointF(oBounds.Left, sRefTop + sRefHeight))
                                                                sRefHeight = oBounds.Height * sQuotaRightRefPercent / 100
                                                                sRefTop = oBounds.Top + (oBounds.Height - sRefHeight) / 2
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Right, sRefTop), New PointF(oBounds.Right, sRefTop + sRefHeight))
                                                                Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                            End Using

                                                            If iQuotaCapDecoration = cIItemQuota.QuotaCapDecorationEnum.Bars Then
                                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                    Call oQuotaPath.AddLine(New PointF(oBounds.Left, oBounds.Top + sHalfHeight - sHalfWidth / 10), New PointF(oBounds.Left, oBounds.Top + sHalfHeight + sHalfWidth / 10))
                                                                    Using oMatrix As Matrix = New Matrix
                                                                        Call oMatrix.RotateAt(45.0F, New PointF(oBounds.Left, oBounds.Top + sHalfHeight))
                                                                        Call oQuotaPath.Transform(oMatrix)
                                                                    End Using
                                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                                End Using
                                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                    Call oQuotaPath.AddLine(New PointF(oBounds.Left, oBounds.Top + sHalfHeight - sHalfWidth / 10), New PointF(oBounds.Left, oBounds.Top + sHalfHeight + sHalfWidth / 10))
                                                                    Using oMatrix As Matrix = New Matrix
                                                                        Call oMatrix.RotateAt(-45.0F, New PointF(oBounds.Left, oBounds.Top + sHalfHeight))
                                                                        Call oQuotaPath.Transform(oMatrix)
                                                                    End Using
                                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                                End Using
                                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                    Call oQuotaPath.AddLine(New PointF(oBounds.Right, oBounds.Top + sHalfHeight - sHalfWidth / 10), New PointF(oBounds.Right, oBounds.Top + sHalfHeight + sHalfWidth / 10))
                                                                    Using oMatrix As Matrix = New Matrix
                                                                        Call oMatrix.RotateAt(45.0F, New PointF(oBounds.Right, oBounds.Top + sHalfHeight))
                                                                        Call oQuotaPath.Transform(oMatrix)
                                                                    End Using
                                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                                End Using
                                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                    Call oQuotaPath.AddLine(New PointF(oBounds.Right, oBounds.Top + sHalfHeight - sHalfWidth / 10), New PointF(oBounds.Right, oBounds.Top + sHalfHeight + sHalfWidth / 10))
                                                                    Using oMatrix As Matrix = New Matrix
                                                                        Call oMatrix.RotateAt(-45.0F, New PointF(oBounds.Right, oBounds.Top + sHalfHeight))
                                                                        Call oQuotaPath.Transform(oMatrix)
                                                                    End Using
                                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                                End Using
                                                            End If

                                                            Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Left + sHalfWidth - sTextWidth / 2, oBounds.Top + sHalfHeight), New PointF(oBounds.Left, oBounds.Top + sHalfHeight))
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(New PointF(oBounds.Left + sHalfWidth + sTextWidth / 2, oBounds.Top + sHalfHeight), New PointF(oBounds.Right, oBounds.Top + sHalfHeight))
                                                                oCenterPoint = New PointF(oBounds.Left + sHalfWidth, oBounds.Top + sHalfHeight)
                                                                Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oArrowPen, oArrowPen, Nothing)
                                                            End Using
                                                    End Select

                                                End Using
                                            Case cIItemQuota.QuotaTypeEnum.Oblique
                                                Using oArrowPen As Pen = oPen.Clone
                                                    Select Case iQuotaCapDecoration
                                                        Case cIItemQuota.QuotaCapDecorationEnum.Arrow
                                                            oArrowPen.EndCap = LineCap.Custom
                                                            oArrowPen.CustomEndCap = New AdjustableArrowCap(5, 5, True)
                                                        Case cIItemQuota.QuotaCapDecorationEnum.Bars
                                                            'not supported...
                                                            oArrowPen.EndCap = LineCap.NoAnchor
                                                    End Select

                                                    Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                        Dim oMiddlePoint As PointF = modPaint.GetMediumPoint(MyBase.Points(0).Point, MyBase.Points(1).Point)
                                                        Dim sTextMaxSize As Single = If(sTextWidth > sTextHeight, sTextWidth, sTextHeight) / 2
                                                        Dim sHalfSize As Single = modPaint.DistancePointToPoint(oMiddlePoint, MyBase.Points(0).Point)
                                                        Dim sPercentage As Single = sTextMaxSize / sHalfSize

                                                        If MyBase.Points(1).X < MyBase.Points(0).X Then
                                                            If MyBase.Points(1).Y < MyBase.Points(0).Y Then
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(modPaint.PointOnLineByPercentage(oMiddlePoint, New PointF(oBounds.Right, oBounds.Bottom), sPercentage), New PointF(oBounds.Right, oBounds.Bottom))
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(modPaint.PointOnLineByPercentage(oMiddlePoint, New PointF(oBounds.Left, oBounds.Top), sPercentage), New PointF(oBounds.Left, oBounds.Top))
                                                            Else
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(modPaint.PointOnLineByPercentage(oMiddlePoint, New PointF(oBounds.Right, oBounds.Top), sPercentage), New PointF(oBounds.Right, oBounds.Top))
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(modPaint.PointOnLineByPercentage(oMiddlePoint, New PointF(oBounds.Left, oBounds.Bottom), sPercentage), New PointF(oBounds.Left, oBounds.Bottom))
                                                            End If
                                                        Else
                                                            If MyBase.Points(1).Y < MyBase.Points(0).Y Then
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(modPaint.PointOnLineByPercentage(oMiddlePoint, New PointF(oBounds.Left, oBounds.Bottom), sPercentage), New PointF(oBounds.Left, oBounds.Bottom))
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(modPaint.PointOnLineByPercentage(oMiddlePoint, New PointF(oBounds.Right, oBounds.Top), sPercentage), New PointF(oBounds.Right, oBounds.Top))
                                                            Else
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(modPaint.PointOnLineByPercentage(oMiddlePoint, New PointF(oBounds.Left, oBounds.Top), sPercentage), New PointF(oBounds.Left, oBounds.Top))
                                                                Call oQuotaPath.StartFigure()
                                                                Call oQuotaPath.AddLine(modPaint.PointOnLineByPercentage(oMiddlePoint, New PointF(oBounds.Right, oBounds.Bottom), sPercentage), New PointF(oBounds.Right, oBounds.Bottom))
                                                            End If
                                                        End If

                                                        Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oArrowPen, oArrowPen, Nothing)
                                                    End Using
                                                End Using
                                            Case cIItemQuota.QuotaTypeEnum.Drop
                                                oCenterPoint = New PointF(oBounds.Left + sHalfWidth, oBounds.Top + sHalfHeight)
                                            Case cIItemQuota.QuotaTypeEnum.Altitude
                                                oCenterPoint = New PointF(oBounds.Left + sHalfWidth, oBounds.Top + sHalfHeight)

                                                Dim oTextBounds As RectangleF = oPath.GetBounds
                                                Dim oCircleSize As SizeF = oTextBounds.Size
                                                Dim sCircleWidth As Single = oCircleSize.Height
                                                Dim oCircleLocation As PointF = New PointF(oCenterPoint.X - oTextBounds.Width / 2 - sCircleWidth * 5, oCenterPoint.Y - oTextBounds.Height / 2)

                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                    Call oQuotaPath.StartFigure()
                                                    Call oQuotaPath.AddEllipse(oCircleLocation.X, oCircleLocation.Y, sCircleWidth * 2, sCircleWidth * 2)
                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                End Using

                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                    Call oQuotaPath.StartFigure()
                                                    Call oQuotaPath.AddLine(oCircleLocation.X - sCircleWidth * 2, oCircleLocation.Y + sCircleWidth, oCircleLocation.X, oCircleLocation.Y + sCircleWidth)
                                                    Call oQuotaPath.StartFigure()
                                                    Call oQuotaPath.AddLine(oCircleLocation.X + sCircleWidth * 2, oCircleLocation.Y + sCircleWidth, oCircleLocation.X + sCircleWidth * 4, oCircleLocation.Y + sCircleWidth)
                                                    Call oQuotaPath.StartFigure()
                                                    Call oQuotaPath.AddLine(oCircleLocation.X + sCircleWidth, oCircleLocation.Y - sCircleWidth * 2, oCircleLocation.X + sCircleWidth, oCircleLocation.Y)
                                                    Call oQuotaPath.StartFigure()
                                                    Call oQuotaPath.AddLine(oCircleLocation.X + sCircleWidth, oCircleLocation.Y + sCircleWidth * 2, oCircleLocation.X + sCircleWidth, oCircleLocation.Y + sCircleWidth * 4)
                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                End Using
                                            Case cIItemQuota.QuotaTypeEnum.GridScale
                                                Dim sXOffset As Single
                                                Try
                                                    If sQuotaRelativeTrigPoint = "" Then
                                                        sXOffset = 0
                                                    Else
                                                        If oSurvey.Calculate.TrigPoints.Contains(sQuotaRelativeTrigPoint) Then
                                                            If MyBase.Design.Type = cIDesign.cDesignTypeEnum.Plan Then
                                                                sXOffset = oSurvey.Calculate.TrigPoints(sQuotaRelativeTrigPoint).Point.To2DPoint(Calculate.cTrigPointPoint.ProjectionEnum.FromTop).X - oBounds.Left
                                                            Else
                                                                sXOffset = oSurvey.Calculate.TrigPoints(sQuotaRelativeTrigPoint).Point.To2DPoint(Calculate.cTrigPointPoint.ProjectionEnum.Perpendicular).X - oBounds.Left
                                                            End If
                                                        Else
                                                            sXOffset = 0
                                                        End If
                                                    End If
                                                Catch
                                                    sXOffset = 0
                                                End Try
                                                Dim iXTickValue As Integer
                                                Dim sXFirstTick As Single = oBounds.Left + (sXOffset - pTruncateToTickFrequency(sXOffset))
                                                Dim sXLastTick As Single = sXFirstTick + pTruncateToTickFrequency(oBounds.Width)

                                                Dim sYOffset As Single
                                                Try
                                                    If sQuotaRelativeTrigPoint = "" Then
                                                        sYOffset = 0
                                                    Else
                                                        If oSurvey.Calculate.TrigPoints.Contains(sQuotaRelativeTrigPoint) Then
                                                            If MyBase.Design.Type = cIDesign.cDesignTypeEnum.Plan Then
                                                                sYOffset = oSurvey.Calculate.TrigPoints(sQuotaRelativeTrigPoint).Point.To2DPoint(Calculate.cTrigPointPoint.ProjectionEnum.FromTop).Y - oBounds.Top
                                                            Else
                                                                sYOffset = oSurvey.Calculate.TrigPoints(sQuotaRelativeTrigPoint).Point.To2DPoint(Calculate.cTrigPointPoint.ProjectionEnum.Perpendicular).Y - oBounds.Top
                                                            End If
                                                        Else
                                                            sYOffset = 0
                                                        End If
                                                    End If
                                                Catch
                                                    sYOffset = 0
                                                End Try
                                                Dim iYTickValue As Integer
                                                Dim sYFirstTick As Single = oBounds.Top + (sYOffset - pTruncateToTickFrequency(sYOffset))
                                                Dim sYLastTick As Single = sYFirstTick + pTruncateToTickFrequency(oBounds.Height)

                                                'calcolo la spaziatura tra le tacche e il numero (la larghezza di mezzo '0')
                                                Dim sSpace As Single
                                                Using oQuotaSpaceTextPath As GraphicsPath = New GraphicsPath
                                                    Call oFont.AddToPath(PaintOptions, oQuotaSpaceTextPath, "0", New PointF(0, 0), oSF)
                                                    sSpace = oQuotaSpaceTextPath.GetBounds.Width * sScale / 2
                                                End Using

                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                    Dim sTextTop As Single
                                                    If iQuotaTextPosition = cIItemQuota.QuotaTextPositionEnum.LeftTop Then
                                                        sTextTop = sYFirstTick - sQuotaTickSize
                                                    Else
                                                        sTextTop = sYLastTick + sQuotaTickSize
                                                    End If

                                                    iXTickValue = -1 * pTruncateToTickFrequency(sXOffset)
                                                    For sMeter As Single = sXFirstTick To sXLastTick Step 1 'iQuotaTickFrequency
                                                        If iXTickValue Mod iQuotaTickFrequency = 0 Then
                                                            Call oQuotaPath.StartFigure()
                                                            Call oQuotaPath.AddLine(New PointF(sMeter, sYFirstTick), New PointF(sMeter, sYLastTick))
                                                            Select Case iQuotaTextPosition
                                                                Case cIItemQuota.QuotaTextPositionEnum.LeftTop
                                                                    Call oQuotaPath.AddLine(New PointF(sMeter, sYFirstTick - sQuotaTickSize), New PointF(sMeter, sYFirstTick))
                                                                Case cIItemQuota.QuotaTextPositionEnum.RightBottom
                                                                    Call oQuotaPath.AddLine(New PointF(sMeter, sYLastTick), New PointF(sMeter, sYLastTick + sQuotaTickSize))
                                                            End Select
                                                        End If
                                                        If iXTickValue Mod iQuotaTickLabelFrequency = 0 Then
                                                            Using oQuotaTickTextPath As GraphicsPath = New GraphicsPath
                                                                Call oFont.AddToPath(PaintOptions, oQuotaTickTextPath, iXTickValue, New PointF(0, 0), oSF)
                                                                Using oMatrix As Matrix = New Matrix
                                                                    Call oMatrix.Scale(sScale, sScale, MatrixOrder.Append)
                                                                    Call oQuotaTickTextPath.Transform(oMatrix)
                                                                End Using

                                                                Dim oQuotaTickTextBounds As RectangleF = oQuotaTickTextPath.GetBounds
                                                                Using oMatrix As Matrix = New Matrix
                                                                    Call oMatrix.Translate(-oQuotaTickTextBounds.Left, -oQuotaTickTextBounds.Top, MatrixOrder.Append)
                                                                    If iQuotaTextPosition = cIItemQuota.QuotaTextPositionEnum.LeftTop Then
                                                                        Call oMatrix.Translate(sMeter - oQuotaTickTextPath.GetBounds.Width / 2, sTextTop - oQuotaTickTextPath.GetBounds.Height - sSpace, MatrixOrder.Append)
                                                                    Else
                                                                        Call oMatrix.Translate(sMeter - oQuotaTickTextPath.GetBounds.Width / 2, sTextTop + sSpace, MatrixOrder.Append)
                                                                    End If
                                                                    Call oQuotaTickTextPath.Transform(oMatrix)
                                                                End Using

                                                                Call oFont.Render(Graphics, PaintOptions, Options, oQuotaTickTextPath, oCache)
                                                            End Using
                                                        End If
                                                        iXTickValue += 1
                                                    Next

                                                    Dim sTextLeft As Single
                                                    If iQuotaTextPosition = cIItemQuota.QuotaTextPositionEnum.LeftTop Then
                                                        sTextLeft = sXFirstTick - sQuotaTickSize
                                                    Else
                                                        sTextLeft = sXLastTick + sQuotaTickSize
                                                    End If

                                                    iYTickValue = pTruncateToTickFrequency(sYOffset)
                                                    For sMeter As Single = sYFirstTick To sYLastTick Step 1 'iQuotaTickFrequency ' oBounds.Bottom Step 1
                                                        If iYTickValue Mod iQuotaTickFrequency = 0 Then
                                                            Call oQuotaPath.StartFigure()
                                                            Call oQuotaPath.AddLine(New PointF(sXFirstTick, sMeter), New PointF(sXLastTick, sMeter))
                                                            Select Case iQuotaTextPosition
                                                                Case cIItemQuota.QuotaTextPositionEnum.LeftTop
                                                                    Call oQuotaPath.AddLine(New PointF(sXFirstTick - sQuotaTickSize, sMeter), New PointF(sXLastTick, sMeter))
                                                                Case cIItemQuota.QuotaTextPositionEnum.RightBottom
                                                                    Call oQuotaPath.AddLine(New PointF(sXFirstTick, sMeter), New PointF(sXLastTick + sQuotaTickSize, sMeter))
                                                            End Select
                                                        End If
                                                        If iYTickValue Mod iQuotaTickLabelFrequency = 0 Then
                                                            Using oQuotaTickTextPath As GraphicsPath = New GraphicsPath
                                                                Call oFont.AddToPath(PaintOptions, oQuotaTickTextPath, iYTickValue, New PointF(0, 0), oSF)

                                                                Using oMatrix As Matrix = New Matrix
                                                                    Call oMatrix.Scale(sScale, sScale, MatrixOrder.Append)
                                                                    Call oQuotaTickTextPath.Transform(oMatrix)
                                                                End Using

                                                                Dim oQuotaTickTextBounds As RectangleF = oQuotaTickTextPath.GetBounds
                                                                Using oMatrix As Matrix = New Matrix
                                                                    Call oMatrix.Translate(-oQuotaTickTextBounds.Left, -oQuotaTickTextBounds.Top, MatrixOrder.Append)
                                                                    If iQuotaTextPosition = cIItemQuota.QuotaTextPositionEnum.LeftTop Then
                                                                        Call oMatrix.Translate(sTextLeft - oQuotaTickTextBounds.Width - sSpace, sMeter - oQuotaTickTextBounds.Height / 2, MatrixOrder.Append)
                                                                    Else
                                                                        Call oMatrix.Translate(sTextLeft + sSpace, sMeter - oQuotaTickTextBounds.Height / 2, MatrixOrder.Append)
                                                                    End If
                                                                    Call oQuotaTickTextPath.Transform(oMatrix)
                                                                End Using

                                                                Call oFont.Render(Graphics, PaintOptions, Options, oQuotaTickTextPath, oCache)
                                                            End Using
                                                        End If
                                                        iYTickValue -= 1
                                                    Next

                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                End Using
                                            Case cIItemQuota.QuotaTypeEnum.VerticalScale
                                                Dim sYOffset As Single
                                                Try
                                                    If sQuotaRelativeTrigPoint <> "" Then
                                                        If oSurvey.Calculate.TrigPoints.Contains(sQuotaRelativeTrigPoint) Then
                                                            If MyBase.Design.Type = cIDesign.cDesignTypeEnum.Plan Then
                                                                sYOffset = oSurvey.Calculate.TrigPoints(sQuotaRelativeTrigPoint).Point.To2DPoint(Calculate.cTrigPointPoint.ProjectionEnum.FromTop).Y - oBounds.Top
                                                            Else
                                                                sYOffset = oSurvey.Calculate.TrigPoints(sQuotaRelativeTrigPoint).Point.To2DPoint(Calculate.cTrigPointPoint.ProjectionEnum.Perpendicular).Y - oBounds.Top
                                                            End If
                                                        Else
                                                            sYOffset = 0
                                                        End If
                                                    Else
                                                        sYOffset = 0
                                                    End If
                                                Catch
                                                    sYOffset = 0
                                                End Try
                                                Dim iYTickValue As Integer
                                                Dim sYFirstTick As Single = oBounds.Top + (sYOffset - pTruncateToTickFrequency(sYOffset))
                                                Dim sYLastTick As Single = sYFirstTick + pTruncateToTickFrequency(oBounds.Height)

                                                Dim sXFirstTick As Single = oBounds.Left

                                                'calcolo la spaziatura tra le tacche e il numero (la larghezza di mezzo '0')
                                                Dim sSpace As Single
                                                Using oQuotaSpaceTextPath As GraphicsPath = New GraphicsPath
                                                    Call oFont.AddToPath(PaintOptions, oQuotaSpaceTextPath, "0", New PointF(0, 0), oSF)
                                                    sSpace = oQuotaSpaceTextPath.GetBounds.Width * sScale / 2
                                                End Using

                                                Using oQuotaPath As GraphicsPath = New GraphicsPath
                                                    Dim sTextLeft As Single
                                                    If iQuotaTextPosition = cIItemQuota.QuotaTextPositionEnum.LeftTop Then
                                                        sTextLeft = sXFirstTick
                                                    Else
                                                        sTextLeft = sXFirstTick + sQuotaTickSize
                                                    End If

                                                    Select Case iQuotaAlign
                                                        Case cIItemQuota.QuotaAlignEnum.Left
                                                            Call oQuotaPath.AddLine(New PointF(sXFirstTick, sYFirstTick), New PointF(sXFirstTick, sYLastTick))
                                                        Case cIItemQuota.QuotaAlignEnum.Center
                                                            Call oQuotaPath.AddLine(New PointF(sXFirstTick + sQuotaTickSize / 2, sYFirstTick), New PointF(sXFirstTick + sQuotaTickSize / 2, sYLastTick))
                                                        Case cIItemQuota.QuotaAlignEnum.Right
                                                            Call oQuotaPath.AddLine(New PointF(sXFirstTick + sQuotaTickSize, sYFirstTick), New PointF(sXFirstTick + sQuotaTickSize, sYLastTick))
                                                    End Select

                                                    iYTickValue = pTruncateToTickFrequency(sYOffset)
                                                    For sMeter As Single = sYFirstTick To sYLastTick Step 1 'iQuotaTickFrequency ' oBounds.Bottom Step 1
                                                        If iYTickValue Mod iQuotaTickFrequency = 0 Then
                                                            Call oQuotaPath.StartFigure()
                                                            Call oQuotaPath.AddLine(New PointF(sXFirstTick, sMeter), New PointF(sXFirstTick + sQuotaTickSize, sMeter))
                                                        End If
                                                        If iYTickValue Mod iQuotaTickLabelFrequency = 0 Then
                                                            Dim oQuotaTickTextPath As GraphicsPath = New GraphicsPath
                                                            Call oFont.AddToPath(PaintOptions, oQuotaTickTextPath, iYTickValue, New PointF(0, 0), oSF)

                                                            Using oMatrix As Matrix = New Matrix
                                                                Call oMatrix.Scale(sScale, sScale, MatrixOrder.Append)
                                                                Call oQuotaTickTextPath.Transform(oMatrix)
                                                            End Using

                                                            Dim oQuotaTickTextBounds As RectangleF = oQuotaTickTextPath.GetBounds
                                                            Using oMatrix As Matrix = New Matrix
                                                                Call oMatrix.Translate(-oQuotaTickTextBounds.Left, -oQuotaTickTextBounds.Top, MatrixOrder.Append)
                                                                If iQuotaTextPosition = cIItemQuota.QuotaTextPositionEnum.LeftTop Then
                                                                    Call oMatrix.Translate(sTextLeft - oQuotaTickTextBounds.Width - sSpace, sMeter - oQuotaTickTextBounds.Height / 2, MatrixOrder.Append)
                                                                Else
                                                                    Call oMatrix.Translate(sTextLeft + sSpace, sMeter - oQuotaTickTextBounds.Height / 2, MatrixOrder.Append)
                                                                End If
                                                                Call oQuotaTickTextPath.Transform(oMatrix)
                                                            End Using

                                                            Call oFont.Render(Graphics, PaintOptions, Options, oQuotaTickTextPath, oCache)
                                                            Call oQuotaTickTextPath.Dispose()
                                                        End If
                                                        iYTickValue -= 1
                                                    Next

                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                End Using
                                            Case cIItemQuota.QuotaTypeEnum.HorizontalScale
                                                Dim sXOffset As Single
                                                Try
                                                    If sQuotaRelativeTrigPoint <> "" Then
                                                        If oSurvey.Calculate.TrigPoints.Contains(sQuotaRelativeTrigPoint) Then
                                                            If MyBase.Design.Type = cIDesign.cDesignTypeEnum.Plan Then
                                                                sXOffset = oSurvey.Calculate.TrigPoints(sQuotaRelativeTrigPoint).Point.To2DPoint(Calculate.cTrigPointPoint.ProjectionEnum.FromTop).X - oBounds.Left
                                                            Else
                                                                sXOffset = oSurvey.Calculate.TrigPoints(sQuotaRelativeTrigPoint).Point.To2DPoint(Calculate.cTrigPointPoint.ProjectionEnum.Perpendicular).X - oBounds.Left
                                                            End If
                                                        Else
                                                            sXOffset = 0
                                                        End If
                                                    Else
                                                        sXOffset = 0
                                                    End If
                                                Catch
                                                    sXOffset = 0
                                                End Try
                                                Dim iXTickValue As Integer
                                                Dim sXFirstTick As Single = oBounds.Left + (sXOffset - pTruncateToTickFrequency(sXOffset))
                                                Dim sXLastTick As Single = sXFirstTick + pTruncateToTickFrequency(oBounds.Width)

                                                Dim sYFirstTick As Single = oBounds.Top

                                                'calcolo la spaziatura tra le tacche e il numero (la larghezza di mezzo '0')
                                                Dim oQuotaSpaceTextPath As GraphicsPath = New GraphicsPath
                                                Call oFont.AddToPath(PaintOptions, oQuotaSpaceTextPath, "0", New PointF(0, 0), oSF)
                                                Dim sSpace As Single = oQuotaSpaceTextPath.GetBounds.Width * sScale / 2
                                                Call oQuotaSpaceTextPath.Dispose()

                                                Using oQuotaPath As GraphicsPath = New GraphicsPath

                                                    Dim sTextTop As Single
                                                    If iQuotaTextPosition = cIItemQuota.QuotaTextPositionEnum.LeftTop Then
                                                        sTextTop = sYFirstTick
                                                    Else
                                                        sTextTop = sYFirstTick + sQuotaTickSize
                                                    End If

                                                    Select Case iQuotaAlign
                                                        Case cIItemQuota.QuotaAlignEnum.Left
                                                            Call oQuotaPath.AddLine(New PointF(sXFirstTick, sYFirstTick), New PointF(sXLastTick, sYFirstTick))
                                                        Case cIItemQuota.QuotaAlignEnum.Center
                                                            Call oQuotaPath.AddLine(New PointF(sXFirstTick, sYFirstTick + sQuotaTickSize / 2), New PointF(sXLastTick, sYFirstTick + sQuotaTickSize / 2))
                                                        Case cIItemQuota.QuotaAlignEnum.Right
                                                            Call oQuotaPath.AddLine(New PointF(sXFirstTick, sYFirstTick + sQuotaTickSize), New PointF(sXLastTick, sYFirstTick + sQuotaTickSize))
                                                    End Select

                                                    iXTickValue = -1 * pTruncateToTickFrequency(sXOffset)
                                                    For sMeter As Single = sXFirstTick To sXLastTick Step 1 'iQuotaTickFrequency
                                                        If iXTickValue Mod iQuotaTickFrequency = 0 Then
                                                            Call oQuotaPath.StartFigure()
                                                            Call oQuotaPath.AddLine(New PointF(sMeter, sYFirstTick), New PointF(sMeter, sYFirstTick + sQuotaTickSize))
                                                        End If
                                                        If iXTickValue Mod iQuotaTickLabelFrequency = 0 Then
                                                            Using oQuotaTickTextPath As GraphicsPath = New GraphicsPath
                                                                Call oFont.AddToPath(PaintOptions, oQuotaTickTextPath, iXTickValue, New PointF(0, 0), oSF)
                                                                Using oMatrix As Matrix = New Matrix
                                                                    Call oMatrix.Scale(sScale, sScale, MatrixOrder.Append)
                                                                    Call oQuotaTickTextPath.Transform(oMatrix)
                                                                End Using

                                                                Dim oQuotaTickTextBounds As RectangleF = oQuotaTickTextPath.GetBounds
                                                                Using oMatrix As Matrix = New Matrix
                                                                    Call oMatrix.Translate(-oQuotaTickTextBounds.Left, -oQuotaTickTextBounds.Top, MatrixOrder.Append)
                                                                    If iQuotaTextPosition = cIItemQuota.QuotaTextPositionEnum.LeftTop Then
                                                                        Call oMatrix.Translate(sMeter - oQuotaTickTextPath.GetBounds.Width / 2, sTextTop - oQuotaTickTextPath.GetBounds.Height - sSpace, MatrixOrder.Append)
                                                                    Else
                                                                        Call oMatrix.Translate(sMeter - oQuotaTickTextPath.GetBounds.Width / 2, sTextTop + sSpace, MatrixOrder.Append)
                                                                    End If
                                                                    Call oQuotaTickTextPath.Transform(oMatrix)
                                                                End Using

                                                                Call oFont.Render(Graphics, PaintOptions, Options, oQuotaTickTextPath, oCache)
                                                            End Using
                                                        End If
                                                        iXTickValue += 1
                                                    Next

                                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oQuotaPath, oPen, oWireframePen, Nothing)
                                                End Using
                                        End Select

                                        'sposto la clipart scalata nel punto di disegno
                                        Dim oPathRect As RectangleF = oPath.GetBounds
                                        Dim oTranslatePoint As PointF = New PointF(oCenterPoint.X - oPathRect.Width / 2, oCenterPoint.Y - oPathRect.Height / 2)
                                        Using oMatrix As Matrix = New Matrix
                                            Call oMatrix.Translate(oTranslatePoint.X, oTranslatePoint.Y, MatrixOrder.Append)
                                            Call oPath.Transform(oMatrix)
                                        End Using

                                        Call oFont.Render(Graphics, PaintOptions, Options, oPath, oCache)
                                    End Using
                                End Using
                            End Using
                        End Using
                    End Using

                    Call .Rendered()
                End If
            End With
        End Sub

        Friend Overrides Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            If MyBase.Points.Count > 1 Then
                Call Render(Graphics, PaintOptions, Options, Selected)
                If Not PaintOptions.IsDesign Or (PaintOptions.IsDesign And Not MyBase.HiddenInDesign) Then '
                    MyBase.HavePaintProblem = Not MyBase.Caches(PaintOptions).Paint(Graphics, PaintOptions, Options)
                    If PaintOptions.ShowSegmentBindings Then
                        Call modPaint.PaintPointToSegmentBindings(Graphics, oSurvey, Me, Selected)
                    End If
                End If
            End If
        End Sub

        Private Function pTruncateToTickFrequency(Value As Single) As Single
            Dim sValue As Single = (Value \ iQuotaTickFrequency) * iQuotaTickFrequency
            Return sValue
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As Storage.cFile, ByVal item As XmlElement)
            Call MyBase.New(Survey, Design, Layer, File, item)
            oSurvey = Survey
            sText = modXML.GetAttributeValue(item, "text", "")
            Try
                oFont = New cItemFont(oSurvey, item.Item("font"))
            Catch ex As Exception
                oFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.Generic)
            End Try
            iTextSize = modXML.GetAttributeValue(item, "textsize")
            'iTextRotateMode = modXML.GetAttributeValue(item, "textrotatemode")
            'iTextAlignment = modXML.GetAttributeValue(item, "textalignment", cIItemText.TextAlignmentEnum.Center)

            iQuotaAlign = modXML.GetAttributeValue(item, "quotaalign")
            iQuotaTextPosition = modXML.GetAttributeValue(item, "quotatextposition", cIItemQuota.QuotaTextPositionEnum.RightBottom)
            sQuotaFormat = modXML.GetAttributeValue(item, "quotaformat")
            iQuotaType = modXML.GetAttributeValue(item, "quotatype")
            iQuotaValue = modXML.GetAttributeValue(item, "quotavalue")
            iQuotaValueType = modXML.GetAttributeValue(item, "quotavaluetype")

            sQuotaRelativeTrigPoint = modXML.GetAttributeValue(item, "quotarelativetrigpoint", "")

            If iQuotaType = cIItemQuota.QuotaTypeEnum.HorizontalScale Or iQuotaType = cIItemQuota.QuotaTypeEnum.VerticalScale Or iQuotaType = cIItemQuota.QuotaTypeEnum.GridScale Then
                'Try
                iQuotaTickFrequency = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "quotatickfrequency", 1))
                iQuotaTickLabelFrequency = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "quotaticklabelfrequency", 5))
                sQuotaTickSize = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "quotaticksize", 0.3))
                'Catch ex As Exception
                '    iQuotaTickFrequency = 1
                '    iQuotaTickLabelFrequency = 5
                '    sQuotaTickSize = 0.3
                'End Try
            End If

            If iQuotaType = cIItemQuota.QuotaTypeEnum.Horizontal Or iQuotaType = cIItemQuota.QuotaTypeEnum.Vertical Then
                'Try
                iQuotaCapDecoration = modXML.GetAttributeValue(item, "quotacapdecoration", cIItemQuota.QuotaCapDecorationEnum.Arrow)
                sQuotaLeftRefPercent = modNumbers.StringToDecimal(modXML.GetAttributeValue(item, "quotaleftrefpercent", 100))
                sQuotaRightRefPercent = modNumbers.StringToDecimal(modXML.GetAttributeValue(item, "quotarightrefpercent", 100))
                'Catch ex As Exception
                '    iQuotaCapDecoration = cIItemQuota.QuotaCapDecorationEnum.Arrow
                '    sQuotaLeftRefPercent = 100
                '    sQuotaRightRefPercent = 100
                'End Try
            End If

            sAngle = modNumbers.StringToDecimal(modXML.GetAttributeValue(item, "angle", 0))
        End Sub

        Friend Overrides Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oItem As XmlElement = MyBase.SaveTo(File, Document, Parent, Options)
            Call oItem.SetAttribute("text", "" & sText)
            Call oFont.SaveTo(File, Document, oItem, "font")
            If iTextSize <> cIItemText.TextSizeEnum.Default Then Call oItem.SetAttribute("textsize", iTextSize.ToString("D"))

            If sAngle <> 0 Then Call oItem.SetAttribute("angle", modNumbers.NumberToString(sAngle))

            Call oItem.SetAttribute("quotaalign", iQuotaAlign.ToString("D"))
            Call oItem.SetAttribute("quotatextposition", iQuotaTextPosition.ToString("D"))
            Call oItem.SetAttribute("quotaformat", sQuotaFormat)
            Call oItem.SetAttribute("quotatype", iQuotaType.ToString("D"))
            Call oItem.SetAttribute("quotavalue", iQuotaValue.ToString("D"))
            Call oItem.SetAttribute("quotavaluetype", iQuotaValueType.ToString("D"))

            Call oItem.SetAttribute("quotarelativetrigpoint", sQuotaRelativeTrigPoint)

            If iQuotaType = cIItemQuota.QuotaTypeEnum.HorizontalScale Or iQuotaType = cIItemQuota.QuotaTypeEnum.VerticalScale Or iQuotaType = cIItemQuota.QuotaTypeEnum.GridScale Then
                Call oItem.SetAttribute("quotatickfrequency", modNumbers.NumberToString(iQuotaTickFrequency))
                Call oItem.SetAttribute("quotaticklabelfrequency", modNumbers.NumberToString(iQuotaTickLabelFrequency))
                Call oItem.SetAttribute("quotaticksize", modNumbers.NumberToString(sQuotaTickSize))
            End If
            If iQuotaType = cIItemQuota.QuotaTypeEnum.Horizontal Or iQuotaType = cIItemQuota.QuotaTypeEnum.Vertical Then
                Call oItem.SetAttribute("quotacapdecoration", iQuotaCapDecoration.ToString("D"))
                Call oItem.SetAttribute("quotaleftrefpercent", modNumbers.NumberToString(sQuotaLeftRefPercent))
                Call oItem.SetAttribute("quotarightrefpercent", modNumbers.NumberToString(sQuotaRightRefPercent))
            End If

            Return oItem
        End Function

        'Public Property TextRotateMode() As cIItemText.TextRotateModeEnum Implements cIItemText.TextRotateMode
        '    Get
        '        Return cIItemText.TextRotateModeEnum.Fixed
        '    End Get
        '    Set(ByVal value As cIItemText.TextRotateModeEnum)

        '    End Set
        'End Property

        Public Property TextSize() As cIItemText.TextSizeEnum Implements cIItemText.TextSize
            Get
                Return iTextSize
            End Get
            Set(ByVal value As cIItemText.TextSizeEnum)
                If iTextSize <> value Then
                    iTextSize = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property Text As String Implements cIItemText.Text
            Get
                Return sText
            End Get
            Set(ByVal value As String)
                If value <> sText Then
                    sText = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public ReadOnly Property Font As cItemFont Implements cIItemText.Font
            Get
                Return oFont
            End Get
        End Property

        Friend Overrides Sub BindSegments()
            If MyBase.Cave = "" Then
                For Each oPoint As cPoint In MyBase.Points
                    oPoint.SegmentLocked = False
                    Call oPoint.BindSegment(Nothing)
                Next
            Else
                Dim oCenterPoint As PointF = GetCenterPoint()
                Dim oSegment As cISegment = MyBase.Design.GetNearestSegment(MyBase.Cave, MyBase.Branch, MyBase.CrossSection, oCenterPoint.X, oCenterPoint.Y, MyBase.BindDesignType)
                For Each oPoint As cPoint In MyBase.Points
                    If Not oPoint.SegmentLocked Then
                        Call oPoint.BindSegment(oSegment)
                    End If
                Next
            End If
        End Sub

        Public Overrides ReadOnly Property CanImportGeneric As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Function FromGeneric(ByVal Item As cItemGeneric, Optional ByVal Clear As Boolean = False) As Boolean
            Return False
        End Function

        Private Sub oFont_OnChanged(ByVal Sender As cItemFont) Handles oFont.OnChanged
            Call MyBase.Caches.Invalidate()
        End Sub

        Public Property QuotaAlign As cIItemQuota.QuotaAlignEnum Implements cIItemQuota.QuotaAlign
            Get
                Return iQuotaAlign
            End Get
            Set(ByVal value As cIItemQuota.QuotaAlignEnum)
                If iQuotaAlign <> value Then
                    iQuotaAlign = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property QuotaTextPosition As cIItemQuota.QuotaTextPositionEnum Implements cIItemQuota.QuotaTextPosition
            Get
                Return iQuotaTextPosition
            End Get
            Set(ByVal value As cIItemQuota.QuotaTextPositionEnum)
                If iQuotaTextPosition <> value Then
                    iQuotaTextPosition = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property QuotaFormat As String Implements cIItemQuota.QuotaFormat
            Get
                Return sQuotaFormat
            End Get
            Set(ByVal value As String)
                If sQuotaFormat <> value Then
                    sQuotaFormat = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property QuotaType As cIItemQuota.QuotaTypeEnum Implements cIItemQuota.QuotaType
            Get
                Return iQuotaType
            End Get
            Set(ByVal value As cIItemQuota.QuotaTypeEnum)
                If iQuotaType <> value Then
                    iQuotaType = value
                    Select Case iQuotaType
                        Case cIItemQuota.QuotaTypeEnum.Horizontal, cIItemQuota.QuotaTypeEnum.Vertical
                        Case Else
                            sQuotaFormat = ""
                    End Select
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property QuotaValue As cIItemQuota.QuotaValueEnum Implements cIItemQuota.QuotaValue
            Get
                Return iQuotaValue
            End Get
            Set(ByVal value As cIItemQuota.QuotaValueEnum)
                If iQuotaValue <> value Then
                    iQuotaValue = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property QuotaValueType As cIItemQuota.QuotaValueTypeEnum Implements cIItemQuota.QuotaValueType
            Get
                Return iQuotaValueType
            End Get
            Set(ByVal value As cIItemQuota.QuotaValueTypeEnum)
                If iQuotaValueType <> value Then
                    iQuotaValueType = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property QuotaRelativeTrigpoint As String Implements cIItemQuota.QuotaRelativeTrigPoint
            Get
                Return sQuotaRelativeTrigPoint
            End Get
            Set(value As String)
                If sQuotaRelativeTrigPoint <> value Then
                    If value = "" Then
                        Dim oTrigPoint As cTrigPoint = oSurvey.TrigPoints.GetCaveFirstEntrance(MyBase.Cave, cTrigPoint.EntranceTypeEnum.MainCaveEntrace)
                        If oTrigPoint Is Nothing Then
                            sQuotaRelativeTrigPoint = ""
                        Else
                            sQuotaRelativeTrigPoint = oTrigPoint.Name
                        End If
                    Else
                        sQuotaRelativeTrigPoint = value
                    End If
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property QuotaTickFrequency As Integer Implements cIItemQuota.QuotaTickFrequency
            Get
                Return iQuotaTickFrequency
            End Get
            Set(value As Integer)
                If iQuotaTickFrequency <> value Then
                    iQuotaTickFrequency = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property QuotaTickLabelFrequency As Integer Implements cIItemQuota.QuotaTickLabelFrequency
            Get
                Return iQuotaTickLabelFrequency
            End Get
            Set(value As Integer)
                If iQuotaTickLabelFrequency <> value Then
                    iQuotaTickLabelFrequency = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property QuotaTickSize As Single Implements cIItemQuota.QuotaTickSize
            Get
                Return sQuotaTickSize
            End Get
            Set(value As Single)
                If sQuotaTickSize <> value Then
                    sQuotaTickSize = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Overrides Property Transparency As Single
            Get
                Return MyBase.Transparency
            End Get
            Set(value As Single)
                If MyBase.Transparency <> value Then
                    MyBase.Transparency = value
                    Call oFont.Invalidate()
                End If
            End Set
        End Property

        Private Sub oFont_OnRender(sender As cItemFont, RenderArgs As cItemFont.cRenderArgs) Handles oFont.OnRender
            If HaveTransparency Then
                RenderArgs.Transparency = MyBase.Transparency
            End If
        End Sub
    End Class

End Namespace



