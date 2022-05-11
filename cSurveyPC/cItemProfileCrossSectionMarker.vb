Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design.Items
    Public Class cItemProfileCrossSectionMarker
        Inherits cItem
        Implements cIItemProfileCrossSectionMarker

        Private oSurvey As cSurvey

        Private oCrossSection As cDesignCrossSection
        Private oCrossSectionItem As cItemCrossSection

        Private WithEvents oFont As cItemFont

        Private iTextPosition As cIItemCrossSectionMarker.TextPositionEnum
        Private sTextDistance As Single
        Private bTextShow As Boolean
        Private bTextSizeEnabled As Boolean
        Private iTextSize As cIItemSizable.SizeEnum
        Private iTextRotateMode As cIItemPlanCrossSectionMarker.RotateModeEnum

        Private sUp As Single
        Private sDown As Single
        Private sUpHeight As Single
        Private sDownHeight As Single
        Private bAutoUpHeight As Boolean
        Private bAutoDownHeight As Boolean

        Private bProfileDeltaAngleEnabled As Single
        Private sProfileDeltaAngle As Single
        Private iProfileAlignment As cIItemProfileCrossSectionMarker.ProfileAlignmentEnum

        Private bArrowSizeEnabled As Boolean
        Private iArrowSize As cIItemSizable.SizeEnum

        Friend Function GetArrowScaleFactor(PaintOptions As cOptions) As Single
            Dim sTextScaleFactor As Single = GetTextScaleFactor(PaintOptions)
            Select Case iArrowSize
                Case cIItemSizable.SizeEnum.Default
                    Return 1 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.VerySmall
                    Return 0.25 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.Small
                    Return 0.5 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.Medium
                    Return 1 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.Large
                    Return 2 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.VeryLarge
                    Return 4 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x6
                    Return 6 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x8
                    Return 8 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x10
                    Return 10 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x12
                    Return 12 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x16
                    Return 16 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x20
                    Return 20 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x24
                    Return 24 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x32
                    Return 32 * sTextScaleFactor
            End Select
        End Function

        Friend Overrides Function GetTextScaleFactor(PaintOptions As cOptions) As Single
            Dim sTextScaleFactor As Single = MyBase.GetTextScaleFactor(PaintOptions) * PaintOptions.GetCurrentDesignPropertiesValue("DesignCrossSectionTextScaleFactor", 1) * PaintOptions.GetCurrentDesignPropertiesValue("DesignCrossSectionMarkerTextScaleFactor", 1)
            Select Case iTextSize
                Case cIItemSizable.SizeEnum.Default
                    Return 1 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.VerySmall
                    Return 0.25 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.Small
                    Return 0.5 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.Medium
                    Return 1 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.Large
                    Return 2 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.VeryLarge
                    Return 4 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x6
                    Return 6 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x8
                    Return 8 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x10
                    Return 10 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x12
                    Return 12 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x16
                    Return 16 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x20
                    Return 20 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x24
                    Return 24 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x32
                    Return 32 * sTextScaleFactor
            End Select
        End Function

        Public Property TextRotateMode As cIItemPlanCrossSectionMarker.RotateModeEnum Implements cIItemProfileCrossSectionMarker.RotateMode
            Get
                Return iTextRotateMode
            End Get
            Set(value As cIItemPlanCrossSectionMarker.RotateModeEnum)
                If iTextRotateMode <> value Then
                    iTextRotateMode = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property TextDistance() As Single Implements cIItemCrossSectionMarker.TextDistance
            Get
                Return sTextDistance
            End Get
            Set(ByVal value As Single)
                If sTextDistance <> value Then
                    sTextDistance = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property TextSizeEnabled As Boolean Implements cIItemCrossSectionMarker.TextSizeEnabled
            Get
                Return bTextSizeEnabled
            End Get
            Set(value As Boolean)
                If bTextSizeEnabled <> value Then
                    bTextSizeEnabled = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property TextSize As cIItemSizable.SizeEnum Implements cIItemCrossSectionMarker.TextSize, cIItemSizable.Size
            Get
                If bTextSizeEnabled Then
                    Return iTextSize
                Else
                    Return oCrossSectionItem.TextSize
                End If
            End Get
            Set(value As cIItemSizable.SizeEnum)
                If value <> TextSize Then
                    If bTextSizeEnabled Then
                        iTextSize = value
                    Else
                        oCrossSectionItem.TextSize = value
                    End If
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property ArrowSizeEnabled As Boolean Implements cIItemCrossSectionMarker.ArrowSizeEnabled
            Get
                Return bArrowSizeEnabled
            End Get
            Set(value As Boolean)
                If bArrowSizeEnabled <> value Then
                    bArrowSizeEnabled = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property ArrowSize As cIItemSizable.SizeEnum Implements cIItemCrossSectionMarker.ArrowSize
            Get
                Return iArrowSize
            End Get
            Set(value As cIItemSizable.SizeEnum)
                If bArrowSizeEnabled AndAlso iArrowSize <> value Then
                    iArrowSize = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property TextShow As Boolean Implements cIItemCrossSectionMarker.TextShow
            Get
                Return bTextShow
            End Get
            Set(value As Boolean)
                If value <> bTextShow Then
                    bTextShow = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public ReadOnly Property DesignCrossSection() As cDesignCrossSection Implements cIItemCrossSectionMarker.DesignCrossSection
            Get
                Return oCrossSection
            End Get
        End Property

        Public ReadOnly Property CrossSectionItem() As cItemCrossSection Implements cIItemCrossSectionMarker.CrossSectionItem
            Get
                Return oCrossSectionItem
            End Get
        End Property

        Friend Sub RebindCrossSection(CrossSection As cDesignCrossSection)
            oCrossSection = CrossSection
            oCrossSectionItem = oCrossSection.CrossSection
            oFont = oCrossSectionItem.Font
            Call FixBound()
        End Sub

        Public Sub SetUDFromDesign(ByVal PaintOptions As cOptions) Implements cIItemProfileCrossSectionMarker.SetUDFromDesign
            If Not oCrossSectionItem.Segment Is Nothing Then
                Dim oSegment As cSegment = oCrossSectionItem.Segment
                Dim iSegmentSign As Integer = If(oSegment.Direction = cSurvey.DirectionEnum.Left, -1, 1) * If(oCrossSectionItem.Direction = cIItemCrossSection.DirectionEnum.Direct, 1, -1)
                Dim oFromPoint As PointF = oSegment.Data.Profile.FromPoint
                Dim oToPoint As PointF = oSegment.Data.Profile.ToPoint
                Dim oMarkerCenterPoint As PointF
                If oSegment.Data.Data.Reversed Then
                    oMarkerCenterPoint = modPaint.PointOnLineByPercentage(oFromPoint, oToPoint, 1 - oCrossSectionItem.MarkerPosition)
                Else
                    oMarkerCenterPoint = modPaint.PointOnLineByPercentage(oFromPoint, oToPoint, oCrossSectionItem.MarkerPosition)
                End If
                Dim oUD As SizeF = modDesignLRUD.GetUDFromDesign(PaintOptions, oSegment, oMarkerCenterPoint, GetDesignStationEnum.From)
                sUp = oUD.Width * 1.1
                sDown = oUD.Height * 1.1
                Call MyBase.Caches.Invalidate()
            End If
        End Sub

        Public Property ProfileDeltaAngleEnabled As Boolean Implements cIItemProfileCrossSectionMarker.ProfileDeltaAngleEnabled
            Get
                Return bProfileDeltaAngleEnabled
            End Get
            Set(value As Boolean)
                If bProfileDeltaAngleEnabled <> value Then
                    bProfileDeltaAngleEnabled = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property ProfileDeltaAngle As Single Implements cIItemProfileCrossSectionMarker.ProfileDeltaAngle
            Get
                If bProfileDeltaAngleEnabled Then
                    Return sProfileDeltaAngle
                Else
                    Return oCrossSectionItem.SplayBorderProjectionVerticalAngle
                End If
            End Get
            Set(value As Single)
                If ProfileDeltaAngle <> value Then
                    If bProfileDeltaAngleEnabled Then
                        sProfileDeltaAngle = value
                    Else
                        oCrossSectionItem.SplayBorderProjectionVerticalAngle = value
                    End If
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property ProfileAlignment As cIItemProfileCrossSectionMarker.ProfileAlignmentEnum Implements cIItemProfileCrossSectionMarker.ProfileAlignment
            Get
                Return iProfileAlignment
            End Get
            Set(value As cIItemProfileCrossSectionMarker.ProfileAlignmentEnum)
                If iProfileAlignment <> value Then
                    iProfileAlignment = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property Position As Single Implements cIItemProfileCrossSectionMarker.Position
            Get
                Return oCrossSectionItem.MarkerPosition
            End Get
            Set(value As Single)
                oCrossSectionItem.MarkerPosition = value
            End Set
        End Property

        Public Property Down As Single Implements cIItemProfileCrossSectionMarker.Down
            Get
                Return sDown
            End Get
            Set(value As Single)
                If sDown <> value Then
                    sDown = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property Up As Single Implements cIItemProfileCrossSectionMarker.Up
            Get
                Return sUp
            End Get
            Set(value As Single)
                If sUp <> value Then
                    sUp = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property DownHeight As Single Implements cIItemProfileCrossSectionMarker.DownHeight
            Get
                Return sDownHeight
            End Get
            Set(value As Single)
                If sDownHeight <> value Then
                    sDownHeight = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property UpHeight As Single Implements cIItemProfileCrossSectionMarker.UpHeight
            Get
                Return sUpHeight
            End Get
            Set(value As Single)
                If sUpHeight <> value Then
                    sUpHeight = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property AutoDownHeight As Boolean Implements cIItemProfileCrossSectionMarker.AutoDownHeight
            Get
                Return bAutoDownHeight
            End Get
            Set(value As Boolean)
                If bAutoDownHeight <> value Then
                    bAutoDownHeight = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property AutoUpHeight As Boolean Implements cIItemProfileCrossSectionMarker.AutoUpHeight
            Get
                Return bAutoUpHeight
            End Get
            Set(value As Boolean)
                If bAutoUpHeight <> value Then
                    bAutoUpHeight = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
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
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeSendedToOtherDesign As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeDeleted As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeReduced As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Sub SetBindDesignType(ByVal BindDesignType As BindDesignTypeEnum, Optional CrossSection As cDesignCrossSection = Nothing, Optional ByVal BindSegment As Boolean = True)
            If CanBeBinded Then
                Call MyBase.SetBindDesignType(BindDesignTypeEnum.MainDesign, Nothing, False)
            End If
        End Sub

        Public Overrides ReadOnly Property CanBeWarped As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeMoved As Boolean
            Get
                Return False
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
                Return False
            End Get
        End Property

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

        Public Overrides ReadOnly Property BindMode As cItem.BindModeEnum
            Get
                Return BindModeEnum.CenterPoint
            End Get
        End Property

        Public Overrides ReadOnly Property HaveEditablePoints As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property MaxPointsCount As Integer
            Get
                Return 1
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeRotated() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeResized() As Boolean
            Get
                Return False
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

        Public Overrides ReadOnly Property HaveTransparency As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides Sub SetCave(Cave As String, Optional Branch As String = "", Optional BindSegment As Boolean = True)
            'nulla...
        End Sub

        Public Overrides ReadOnly Property Cave As String
            Get
                Return oCrossSection.Cave
            End Get
        End Property

        Public Overrides ReadOnly Property Branch As String
            Get
                Return oCrossSection.Branch
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum, CrossSection As cDesignCrossSection)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.CrossSectionMarker, Category)
            oSurvey = Survey

            oCrossSection = CrossSection
            oCrossSectionItem = oCrossSection.CrossSection
            oFont = oCrossSectionItem.Font

            bTextShow = True
            iTextPosition = cIItemCrossSectionMarker.TextPositionEnum.AsArrow
            sTextDistance = 0
            iTextRotateMode = cIItemRotable.RotateModeEnum.Fixed

            bAutoUpHeight = True
            bAutoDownHeight = True

            Call FixBound()
        End Sub

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

        Private oFarRect As RectangleF
        Private oNearRect As RectangleF

        Friend ReadOnly Property FarRectangle As RectangleF
            Get
                Return oFarRect
            End Get
        End Property

        Friend ReadOnly Property NearRectangle As RectangleF
            Get
                Return oNearRect
            End Get
        End Property

        Friend Overrides Sub Render(ByVal Graphics As System.Drawing.Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            Dim oCache As cDrawCache = MyBase.Caches(PaintOptions)
            With oCache
                If .Invalidated Then
                    Call .Clear()
                    If Not oCrossSectionItem.Segment Is Nothing Then
                        Dim oCacheItem As Drawings.cDrawCacheItem
                        Dim oDrawingObject As cOptionsDrawingObjects = PaintOptions.DrawingObjects
                        Dim sScale As Single = GetTextScaleFactor(PaintOptions)

                        Dim sArrowSize As Single = PaintOptions.DrawingObjects.CrossSectionMarkerArrowSize * PaintOptions.GetCurrentDesignPropertiesValue("DesignCrossSectionMarkerArrowScaleFactor", 1) * If(bArrowSizeEnabled, GetArrowScaleFactor(PaintOptions) / GetTextScaleFactor(PaintOptions), sScale / GetTextScaleFactor(PaintOptions))

                        Dim sRefUpHeight As Single
                        If bAutoUpHeight Then
                            sRefUpHeight = sArrowSize * 4
                        Else
                            sRefUpHeight = sUpHeight
                        End If
                        Dim sRefDownHeight As Single
                        If bAutoDownHeight Then
                            sRefDownHeight = sArrowSize * 4
                        Else
                            sRefDownHeight = sDownHeight
                        End If

                        Dim oSegment As cSegment = oCrossSectionItem.Segment
                        Dim iSegmentSign As Integer = If(oCrossSectionItem.Direction = cIItemCrossSection.DirectionEnum.Direct, 1, -1) * If(oSegment.Direction = cSurvey.DirectionEnum.Left, -1, 1)
                        Dim sAngle As Single = ProfileDeltaAngle
                        Dim oFromPoint As PointF = oSegment.Data.Profile.FromPoint
                        Dim oToPoint As PointF = oSegment.Data.Profile.ToPoint
                        Dim oMarkerCenterPoint As PointF
                        If oSegment.Data.Data.Reversed Then
                            oMarkerCenterPoint = modPaint.PointOnLineByPercentage(oToPoint, oFromPoint, oCrossSectionItem.MarkerPosition)
                        Else
                            oMarkerCenterPoint = modPaint.PointOnLineByPercentage(oFromPoint, oToPoint, oCrossSectionItem.MarkerPosition)
                        End If
                        Using oRotateMatrix As Matrix = New Matrix()
                            Call oRotateMatrix.RotateAt(sAngle, oMarkerCenterPoint)
                            Dim sU As Single = -1 * sUp
                            Dim sD As Single = sDown

                            Dim oStartPointU As PointF = oMarkerCenterPoint + New SizeF(0, sU)
                            Dim oEndPointU As PointF = oMarkerCenterPoint + New SizeF(0, sU - sRefUpHeight)
                            Dim oStartPointD As PointF = oMarkerCenterPoint + New SizeF(0, sD)
                            Dim oEndPointD As PointF = oMarkerCenterPoint + New SizeF(0, sD + sRefDownHeight)
                            Dim oArrowPoint As PointF

                            oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                            Call oCacheItem.SetPen(PaintOptions.DrawingObjects.CrossSectionMarkerPen)
                            Call oCacheItem.SetWireframePen(PaintOptions.PaintObjects.Pens.GenericPen.WireframePen)
                            If iProfileAlignment = cIItemProfileCrossSectionMarker.ProfileAlignmentEnum.Up Then
                                oArrowPoint = New PointF(oEndPointU.X + iSegmentSign * sArrowSize, oEndPointU.Y)
                                Call oCacheItem.AddLines({oStartPointU, oEndPointU, oArrowPoint})
                                Call oCacheItem.Transform(oRotateMatrix)
                                oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Filler)
                                Call oCacheItem.SetBrush(PaintOptions.DrawingObjects.CrossSectionMarkerBrush)
                                Call oCacheItem.AddPolygon({oArrowPoint, New PointF(oArrowPoint.X, oArrowPoint.Y + sArrowSize / 2), New PointF(oArrowPoint.X + iSegmentSign * sArrowSize, oArrowPoint.Y), New PointF(oArrowPoint.X, oArrowPoint.Y - sArrowSize / 2), oArrowPoint})
                                Call oCacheItem.Transform(oRotateMatrix)
                            Else
                                If sRefUpHeight > 0 Then
                                    Call oCacheItem.AddLine(oStartPointU, oEndPointU)
                                    Call oCacheItem.Transform(oRotateMatrix)
                                End If
                            End If
                            oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                            Call oCacheItem.SetPen(PaintOptions.DrawingObjects.CrossSectionMarkerPen)
                            Call oCacheItem.SetWireframePen(PaintOptions.PaintObjects.Pens.GenericPen.WireframePen)
                            If iProfileAlignment = cIItemProfileCrossSectionMarker.ProfileAlignmentEnum.Down Then
                                oArrowPoint = New PointF(oEndPointD.X + iSegmentSign * sArrowSize, oEndPointD.Y)
                                Call oCacheItem.AddLines({oStartPointD, oEndPointD, oArrowPoint})
                                Call oCacheItem.Transform(oRotateMatrix)
                                oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Filler)
                                Call oCacheItem.SetBrush(PaintOptions.DrawingObjects.CrossSectionMarkerBrush)
                                Call oCacheItem.AddPolygon({oArrowPoint, New PointF(oArrowPoint.X, oArrowPoint.Y + sArrowSize / 2), New PointF(oArrowPoint.X + iSegmentSign * sArrowSize, oArrowPoint.Y), New PointF(oArrowPoint.X, oArrowPoint.Y - sArrowSize / 2), oArrowPoint})
                                Call oCacheItem.Transform(oRotateMatrix)
                            Else
                                If sRefDownHeight > 0 Then
                                    Call oCacheItem.AddLine(oStartPointD, oEndPointD)
                                    Call oCacheItem.Transform(oRotateMatrix)
                                End If
                            End If

                            If bTextShow Then
                                Using oPath As GraphicsPath = New GraphicsPath
                                    Using oSF As StringFormat = New StringFormat
                                        Call oFont.AddToPath(PaintOptions, oPath, oCrossSectionItem.Text, New PointF(0, 0), oSF)

                                        Using oTextMatrix As Matrix = New Matrix
                                            Call oTextMatrix.Scale(sScale, sScale, MatrixOrder.Append)
                                            Call oPath.Transform(oTextMatrix)
                                        End Using

                                        Dim oTextPoint As PointF
                                        Dim oTextSize As SizeF = oPath.GetBounds.Size
                                        Dim sTextWidth As Single = oTextSize.Width * 1.2
                                        Dim sTextHeight As Single = oTextSize.Height * 1.2
                                        Dim sTextMaxSize As Single = IIf(oTextSize.Width > oTextSize.Height, sTextWidth, sTextHeight)

                                        Select Case iTextPosition
                                            Case cIItemCrossSectionMarker.TextPositionEnum.AsArrow
                                                oTextPoint = oArrowPoint
                                                If iSegmentSign > 0 Then
                                                    oTextPoint.X = oTextPoint.X + sTextDistance + sArrowSize
                                                Else
                                                    oTextPoint.X = oTextPoint.X - sTextDistance - sArrowSize - sTextWidth
                                                End If
                                            Case cIItemCrossSectionMarker.TextPositionEnum.Middle
                                                If iProfileAlignment = cIItemProfileCrossSectionMarker.ProfileAlignmentEnum.Up Then
                                                    oTextPoint = modPaint.GetCenterPoint(oArrowPoint, oEndPointU)
                                                Else
                                                    oTextPoint = modPaint.GetCenterPoint(oArrowPoint, oEndPointD)
                                                End If
                                                oTextPoint.X = oTextPoint.X - sTextWidth / 2
                                            Case cIItemCrossSectionMarker.TextPositionEnum.OppositeSide
                                                If iProfileAlignment = cIItemProfileCrossSectionMarker.ProfileAlignmentEnum.Up Then
                                                    oTextPoint = oEndPointU
                                                Else
                                                    oTextPoint = oEndPointD
                                                End If
                                                If iSegmentSign > 0 Then
                                                    oTextPoint.X = oTextPoint.X - sTextDistance - sArrowSize / 2 - sTextWidth
                                                Else
                                                    oTextPoint.X = oTextPoint.X + sTextDistance + sArrowSize / 2
                                                End If
                                        End Select
                                        If iProfileAlignment = cIItemProfileCrossSectionMarker.ProfileAlignmentEnum.Up Then
                                            oTextPoint.Y = oTextPoint.Y - (sTextDistance + sTextMaxSize)
                                        Else
                                            oTextPoint.Y = oTextPoint.Y + (sTextDistance + sTextMaxSize)
                                        End If

                                        oTextPoint.X = oTextPoint.X - sTextWidth / 2
                                        oTextPoint.Y = oTextPoint.Y - sTextHeight / 2
                                        Dim oTranslatePoint As PointF = oTextPoint
                                        Using oTextMatrix As Matrix = New Matrix
                                            Call oTextMatrix.Translate(oTranslatePoint.X, oTranslatePoint.Y, MatrixOrder.Append)
                                            Call oPath.Transform(oTextMatrix)
                                        End Using

                                        Call oPath.Transform(oRotateMatrix)
                                        If iTextRotateMode = cIItemRotable.RotateModeEnum.Fixed Then
                                            Using oRemoveRotateMatrix As Matrix = New Matrix()
                                                Call oRemoveRotateMatrix.RotateAt(-sAngle, modPaint.GetCenterPoint(oPath.GetBounds))
                                                Call oPath.Transform(oRemoveRotateMatrix)
                                            End Using
                                        End If

                                        Call oFont.Render(Graphics, PaintOptions, Options, oPath, oCache)
                                    End Using
                                End Using
                            End If
                        End Using
                    End If
                    Call .Rendered()
                End If
            End With
        End Sub

        Friend Overrides Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            If MyBase.Points.Count > 0 Then
                Call Render(Graphics, PaintOptions, Options, Selected)
                If Not PaintOptions.IsDesign OrElse (PaintOptions.IsDesign And Not MyBase.HiddenInDesign) Then
                    Call MyBase.Caches(PaintOptions).Paint(Graphics, PaintOptions, Options)
                    If PaintOptions.ShowSegmentBindings Then
                        Call modPaint.PaintPointToSegmentBindings(Graphics, MyBase.Survey, Me, Selected)
                    End If
                End If
            End If
        End Sub

        Public Sub FixBound(Optional ByVal ForceBound As Boolean = False)
            If oCrossSectionItem Is Nothing Then
                Call MyBase.Points.BeginUpdate()
                Call MyBase.Points.Clear()
                Call MyBase.Points.AddFromPaintPoint(New PointF(0, 0))
                Call MyBase.Points.EndUpdate()
            Else
                Dim oSegment As cSegment = oCrossSectionItem.Segment
                If oSegment Is Nothing Then
                    Call MyBase.Points.BeginUpdate()
                    Call MyBase.Points.Clear()
                    Call MyBase.Points.AddFromPaintPoint(New PointF(0, 0))
                    Call MyBase.Points.EndUpdate()
                Else
                    Dim oxPoints() As PointF = MyBase.Points.GetPoints()
                    Dim oRect As RectangleF
                    For Each oxPoint As PointF In oxPoints
                        If modPaint.IsRectangleEmpty(oRect) Then
                            oRect = New RectangleF(oxPoint.X, oxPoint.Y, 0, 0)
                        Else
                            oRect = RectangleF.Union(oRect, New RectangleF(oxPoint.X, oxPoint.Y, 0, 0))
                        End If
                    Next
                    Call MyBase.Points.BeginUpdate()
                    Call MyBase.Points.Clear()
                    Call MyBase.Points.AddFromPaintPoint(oRect.Left + oRect.Width / 2, oRect.Top + oRect.Height / 2)
                    Call MyBase.Points.EndUpdate()
                End If
            End If
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As cFile, ByVal item As XmlElement)
            Call MyBase.New(Survey, Design, Layer, File, item)
            oSurvey = Survey

            iTextPosition = modXML.GetAttributeValue(item, "textposition", cIItemCrossSectionMarker.TextPositionEnum.AsArrow)
            sTextDistance = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "textdistance", 0))
            bTextShow = modXML.GetAttributeValue(item, "textshow", 1)
            bTextSizeEnabled = modXML.GetAttributeValue(item, "textsizeenabled", 0)
            If bTextSizeEnabled Then
                iTextSize = modXML.GetAttributeValue(item, "textsize")
            End If
            iTextRotateMode = modXML.GetAttributeValue(item, "textrotatemode", cIItemPlanCrossSectionMarker.RotateModeEnum.Fixed)

            bArrowSizeEnabled = modXML.GetAttributeValue(item, "arrowsizeenabled", 0)
            If bArrowSizeEnabled Then
                iArrowSize = modXML.GetAttributeValue(item, "arrowsize")
            End If

            bProfileDeltaAngleEnabled = modXML.GetAttributeValue(item, "profiledeltaenabled", "1")
            If bProfileDeltaAngleEnabled Then
                sProfileDeltaAngle = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "profiledelta", 0.0))
            End If
            iProfileAlignment = modXML.GetAttributeValue(item, "profilealign", 0)
            sUp = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "up", 0))
            sDown = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "down", 0))
            If modXML.HasAttribute(item, "uph") Then
                bAutoUpHeight = False
                sUpHeight = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "uph", 0))
            Else
                bAutoUpHeight = True
            End If
            If modXML.HasAttribute(item, "downh") Then
                bAutoDownHeight = False
                sDownHeight = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "downh", 0))
            Else
                bAutoDownHeight = True
            End If
        End Sub

        Public Property TextPosition() As cIItemCrossSectionMarker.TextPositionEnum Implements cIItemCrossSectionMarker.TextPosition
            Get
                Return iTextPosition
            End Get
            Set(ByVal value As cIItemCrossSectionMarker.TextPositionEnum)
                If iTextPosition <> value Then
                    iTextPosition = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
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

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            If (File.Options And cFile.FileOptionsEnum.EmbedResource) <> cFile.FileOptionsEnum.EmbedResource Then
                Dim oItem As XmlElement = MyBase.SaveTo(File, Document, Parent, Options)

                If iTextPosition <> cIItemCrossSectionMarker.TextPositionEnum.AsArrow Then Call oItem.SetAttribute("textposition", iTextPosition.ToString("D"))
                If sTextDistance <> 0 Then Call oItem.SetAttribute("textdistance", modNumbers.NumberToString(sTextDistance))
                If bTextSizeEnabled Then
                    Call oItem.SetAttribute("textsizeenabled", "1")
                    If iTextSize <> cIItemSizable.SizeEnum.Default Then Call oItem.SetAttribute("textsize", iTextSize)
                End If
                If bTextShow Then Call oItem.SetAttribute("textshow", "1")
                If iTextRotateMode <> cIItemRotable.RotateModeEnum.Fixed Then
                    Call oItem.SetAttribute("textrotatemode", iTextRotateMode)
                End If

                If bArrowSizeEnabled Then
                    Call oItem.SetAttribute("arrowsizeenabled", "1")
                    If iArrowSize <> cIItemSizable.SizeEnum.Default Then Call oItem.SetAttribute("arrowsize", iArrowSize)
                End If

                Call oItem.SetAttribute("profiledeltaenabled", IIf(bProfileDeltaAngleEnabled, "1", "0"))
                If sProfileDeltaAngle <> 0 Then Call oItem.SetAttribute("profiledelta", modNumbers.NumberToString(sProfileDeltaAngle))
                If iProfileAlignment <> 0 Then Call oItem.SetAttribute("profilealign", iProfileAlignment.ToString("D"))
                If sUp <> 0 Then Call oItem.SetAttribute("up", modNumbers.NumberToString(sUp))
                If sDown <> 0 Then Call oItem.SetAttribute("down", modNumbers.NumberToString(sDown))
                If Not bAutoUpHeight Then Call oItem.SetAttribute("uph", modNumbers.NumberToString(sUpHeight))
                If Not bAutoDownHeight Then Call oItem.SetAttribute("downh", modNumbers.NumberToString(sDownHeight))

                Return oItem
            End If
        End Function

        Private Function pGetLabelPosition(ByVal Graphics As Graphics, ByVal Font As Font, ByVal Point As PointF, ByVal Size As SizeF) As PointF
            Select Case iTextPosition
                Case cTrigPoint.TrigPointLabelPositionEnum.TopLeft
                    Return New PointF(Point.X - sTextDistance - Size.Width / 2, Point.Y - sTextDistance - Size.Height / 2)
                Case cTrigPoint.TrigPointLabelPositionEnum.TopMiddle
                    Return New PointF(Point.X - Size.Width / 2, Point.Y - sTextDistance - Size.Height / 2)
                Case cTrigPoint.TrigPointLabelPositionEnum.TopRight
                    Return New PointF(Point.X + sTextDistance - Size.Width / 2, Point.Y - sTextDistance - Size.Height / 2)
                Case cTrigPoint.TrigPointLabelPositionEnum.CenterLeft
                    Return New PointF(Point.X - sTextDistance - Size.Width / 2, Point.Y - Size.Height / 2)
                Case cTrigPoint.TrigPointLabelPositionEnum.Center
                    Return New PointF(Point.X - Size.Width / 2, Point.Y - Size.Height / 2)
                Case cTrigPoint.TrigPointLabelPositionEnum.CenterRight
                    Return New PointF(Point.X + sTextDistance - Size.Width / 2, Point.Y - Size.Height / 2)
                Case cTrigPoint.TrigPointLabelPositionEnum.BottomLeft
                    Return New PointF(Point.X - sTextDistance - Size.Width / 2, Point.Y + sTextDistance - Size.Height / 2)
                Case cTrigPoint.TrigPointLabelPositionEnum.BottomCenter
                    Return New PointF(Point.X - Size.Width / 2, Point.Y + sTextDistance - Size.Height / 2)
                Case cTrigPoint.TrigPointLabelPositionEnum.BottomRight
                    Return New PointF(Point.X + sTextDistance - Size.Width / 2, Point.Y + sTextDistance - Size.Height / 2)
            End Select
        End Function

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

        Public Overrides Sub MoveBy(ByVal OffsetX As Single, ByVal OffsetY As Single)
            'nulla
        End Sub

        Public Overrides Sub MoveBy(ByVal Size As System.Drawing.SizeF)
            'nulla
        End Sub

        Public Overrides Sub MoveTo(ByVal X As Single, ByVal Y As Single)
            'nulla
        End Sub

        Public Overrides Sub MoveTo(ByVal Point As System.Drawing.PointF)
            'nulla
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

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
