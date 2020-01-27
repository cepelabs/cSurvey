Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design.Items
    Public Class cItemPlanCrossSectionMarker
        Inherits cItem
        Implements cIItemPlanCrossSectionMarker

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

        Private sLeft As Single
        Private sRight As Single
        Private sLeftWidth As Single
        Private sRightWidth As Single
        Private bAutoLeftWidth As Boolean
        Private bAutoRightWidth As Boolean

        Private bPlanDeltaAngleEnabled As Single
        Private sPlanDeltaAngle As Single
        Private iPlanAlignment As cIItemPlanCrossSectionMarker.PlanAlignmentEnum

        Private bArrowSizeEnabled As Boolean
        Private iArrowSize As cIItemSizable.SizeEnum

        Public Property TextRotateMode As cIItemPlanCrossSectionMarker.RotateModeEnum Implements cIItemPlanCrossSectionMarker.RotateMode
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

        Public Sub SetLRFromDesign(ByVal PaintOptions As cOptions) Implements cIItemPlanCrossSectionMarker.SetLRFromDesign
            If Not oCrossSectionItem.Segment Is Nothing Then
                Dim oSegment As cSegment = oCrossSectionItem.Segment
                Dim iSegmentSign As Integer = IIf(oCrossSectionItem.Direction = cIItemCrossSection.DirectionEnum.Direct, 1, -1) '* IIf(oSegment.Data.Data.Reversed, -1, 1)
                Dim sAngle As Single = oSegment.Data.Data.Bearing - 90 + PlanDeltaAngle
                Dim oFromPoint As PointF = oSegment.Data.Plan.FromPoint
                Dim oToPoint As PointF = oSegment.Data.Plan.ToPoint
                Dim oMarkerCenterPoint As PointF
                If oSegment.Data.Data.Reversed Then
                    oMarkerCenterPoint = modPaint.PointOnLineByPercentage(oFromPoint, oToPoint, 1 - oCrossSectionItem.MarkerPosition)
                Else
                    oMarkerCenterPoint = modPaint.PointOnLineByPercentage(oFromPoint, oToPoint, oCrossSectionItem.MarkerPosition)
                End If
                Dim oLR As SizeF = modDesignLRUD.GetLRFromDesign(PaintOptions, oSegment, oMarkerCenterPoint, GetDesignStationEnum.From)
                sRight = oLR.Height * 1.1
                sLeft = oLR.Width * 1.1
                Call MyBase.Caches.Invalidate()
            End If
        End Sub

        Public Property PlanDeltaAngleEnabled As Boolean Implements cIItemPlanCrossSectionMarker.PlanDeltaAngleEnabled
            Get
                Return bPlanDeltaAngleEnabled
            End Get
            Set(value As Boolean)
                If bPlanDeltaAngleEnabled <> value Then
                    bPlanDeltaAngleEnabled = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property PlanDeltaAngle As Single Implements cIItemPlanCrossSectionMarker.PlanDeltaAngle
            Get
                If bPlanDeltaAngleEnabled Then
                    Return sPlanDeltaAngle
                Else
                    Return oCrossSectionItem.SplayBorderProjectionAngle
                End If
            End Get
            Set(value As Single)
                If PlanDeltaAngle <> value Then
                    If bPlanDeltaAngleEnabled Then
                        sPlanDeltaAngle = value
                    Else
                        oCrossSectionItem.SplayBorderProjectionAngle = value
                    End If
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property PlanAlignment As cIItemPlanCrossSectionMarker.PlanAlignmentEnum Implements cIItemPlanCrossSectionMarker.PlanAlignment
            Get
                Return iPlanAlignment
            End Get
            Set(value As cIItemPlanCrossSectionMarker.PlanAlignmentEnum)
                If iPlanAlignment <> value Then
                    iPlanAlignment = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property Position As Single Implements cIItemPlanCrossSectionMarker.Position
            Get
                Return oCrossSectionItem.MarkerPosition
            End Get
            Set(value As Single)
                oCrossSectionItem.MarkerPosition = value
            End Set
        End Property

        Public Property Right As Single Implements cIItemPlanCrossSectionMarker.Right
            Get
                Return sRight
            End Get
            Set(value As Single)
                If sRight <> value Then
                    sRight = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property Left As Single Implements cIItemPlanCrossSectionMarker.Left
            Get
                Return sLeft
            End Get
            Set(value As Single)
                If sLeft <> value Then
                    sLeft = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property RightWidth As Single Implements cIItemPlanCrossSectionMarker.RightWidth
            Get
                Return sRightWidth
            End Get
            Set(value As Single)
                If sRightWidth <> value Then
                    sRightWidth = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property LeftWidth As Single Implements cIItemPlanCrossSectionMarker.LeftWidth
            Get
                Return sLeftWidth
            End Get
            Set(value As Single)
                If sLeftWidth <> value Then
                    sLeftWidth = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property AutoRightWidth As Boolean Implements cIItemPlanCrossSectionMarker.AutoRightWidth
            Get
                Return bAutoRightWidth
            End Get
            Set(value As Boolean)
                If bAutoRightWidth <> value Then
                    bAutoRightWidth = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property AutoLeftWidth As Boolean Implements cIItemPlanCrossSectionMarker.AutoLeftWidth
            Get
                Return bAutoLeftWidth
            End Get
            Set(value As Boolean)
                If bAutoLeftWidth <> value Then
                    bAutoLeftWidth = value
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

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum, CrossSection As cDesignCrossSection)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.CrossSectionMarker, Category)
            oSurvey = Survey

            oCrossSection = CrossSection
            oCrossSectionItem = oCrossSection.CrossSection
            oFont = oCrossSectionItem.Font

            bTextShow = True
            iTextPosition = cIItemCrossSection.TextPositionEnum.TopLeft
            sTextDistance = 0
            iTextRotateMode = cIItemRotable.RotateModeEnum.Fixed

            bAutoLeftWidth = True
            bAutoRightWidth = True

            Call FixBound()
        End Sub

        Friend Overrides Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
            Dim oMatrix As Matrix = New Matrix
            If PaintOptions.DrawTranslation Then
                Dim oTranslation As SizeF = MyBase.Design.GetItemTranslation(Me)
                Call oMatrix.Translate(oTranslation.Width, oTranslation.Height)
            End If
            Dim oSVGItem As XmlElement = MyBase.Caches(PaintOptions).ToSvgItem(SVG, PaintOptions, Options, oMatrix)
            Call oSVGItem.SetAttribute("name", MyBase.Name)
            Return oSVGItem
        End Function

        Friend Overrides Function ToSvg(ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlDocument
            Dim oSVG As XmlDocument = modSVG.CreateSVG
            Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions, Options))
            Return oSVG
        End Function

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
                        If oCrossSectionItem.SplayBorderProjectionVerticalAngle = 0 Then
                            Dim oCacheItem As Drawings.cDrawCacheItem
                            Dim oDrawingObject As cOptionsDrawingObjects = PaintOptions.DrawingObjects
                            Dim sScale As Single = GetTextScaleFactor(PaintOptions)

                            'Dim sArrowSize As Single = PaintOptions.DrawingObjects.CrossSectionMarkerArrowSize * sScale / MyBase.GetTextScaleFactor(PaintOptions)
                            Dim sArrowSize As Single = PaintOptions.DrawingObjects.CrossSectionMarkerArrowSize * If(bArrowSizeEnabled, GetArrowScaleFactor(PaintOptions) / MyBase.GetTextScaleFactor(PaintOptions), sScale / MyBase.GetTextScaleFactor(PaintOptions))

                            Dim sRefLeftWidth As Single
                            If bAutoLeftWidth Then
                                sRefLeftWidth = sArrowSize * 4
                            Else
                                sRefLeftWidth = sLeftWidth
                            End If
                            Dim sRefRightWidth As Single
                            If bAutoRightWidth Then
                                sRefRightWidth = sArrowSize * 4
                            Else
                                sRefRightWidth = sRightWidth
                            End If

                            Dim oSegment As cSegment = oCrossSectionItem.Segment
                            Dim iSegmentSign As Integer = If(oCrossSectionItem.Direction = cIItemCrossSection.DirectionEnum.Direct, 1, -1)
                            Dim sAngle As Single = oSegment.Data.Data.Bearing - 90 + PlanDeltaAngle
                            Dim oFromPoint As PointF = oSegment.Data.Plan.FromPoint
                            Dim oToPoint As PointF = oSegment.Data.Plan.ToPoint
                            Dim oMarkerCenterPoint As PointF
                            If oSegment.Data.Data.Reversed Then
                                oMarkerCenterPoint = modPaint.PointOnLineByPercentage(oToPoint, oFromPoint, oCrossSectionItem.MarkerPosition)
                            Else
                                oMarkerCenterPoint = modPaint.PointOnLineByPercentage(oFromPoint, oToPoint, oCrossSectionItem.MarkerPosition)
                            End If
                            Using oRotateMatrix As Matrix = New Matrix()
                                Call oRotateMatrix.RotateAt(sAngle, oMarkerCenterPoint)
                                Dim sL As Single = sLeft
                                Dim sR As Single = sRight

                                Dim oStartPointL As PointF = oMarkerCenterPoint + New SizeF(0, -sL)
                                Dim oEndPointL As PointF = oMarkerCenterPoint + New SizeF(0, -sL - sRefLeftWidth)
                                Dim oStartPointR As PointF = oMarkerCenterPoint + New SizeF(0, sR)
                                Dim oEndPointR As PointF = oMarkerCenterPoint + New SizeF(0, sR + sRefRightWidth)
                                Dim oArrowPoint As PointF

                                oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                Call oCacheItem.SetPen(PaintOptions.DrawingObjects.CrossSectionMarkerPen)
                                Call oCacheItem.SetWireframePen(PaintOptions.PaintObjects.Pens.GenericPen.WireframePen)
                                If iPlanAlignment = cIItemPlanCrossSectionMarker.PlanAlignmentEnum.Left Then
                                    oArrowPoint = New PointF(oEndPointL.X + iSegmentSign * sArrowSize, oEndPointL.Y)
                                    Call oCacheItem.AddLines({oStartPointL, oEndPointL, oArrowPoint})
                                    Call oCacheItem.Transform(oRotateMatrix)
                                    oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Filler)
                                    Call oCacheItem.Transform(oRotateMatrix)
                                    Call oCacheItem.SetBrush(PaintOptions.DrawingObjects.CrossSectionMarkerBrush)
                                    Call oCacheItem.AddPolygon({oArrowPoint, New PointF(oArrowPoint.X, oArrowPoint.Y + sArrowSize / 2), New PointF(oArrowPoint.X + iSegmentSign * sArrowSize, oArrowPoint.Y), New PointF(oArrowPoint.X, oArrowPoint.Y - sArrowSize / 2), oArrowPoint})
                                    Call oCacheItem.Transform(oRotateMatrix)
                                Else
                                    If sRefLeftWidth > 0 Then
                                        Call oCacheItem.AddLine(oStartPointL, oEndPointL)
                                        Call oCacheItem.Transform(oRotateMatrix)
                                    End If
                                End If
                                oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                Call oCacheItem.SetPen(PaintOptions.DrawingObjects.CrossSectionMarkerPen)
                                Call oCacheItem.SetWireframePen(PaintOptions.PaintObjects.Pens.GenericPen.WireframePen)
                                If iPlanAlignment = cIItemPlanCrossSectionMarker.PlanAlignmentEnum.Right Then
                                    oArrowPoint = New PointF(oEndPointR.X + iSegmentSign * sArrowSize, oEndPointR.Y)
                                    Call oCacheItem.AddLines({oStartPointR, oEndPointR, oArrowPoint})
                                    Call oCacheItem.Transform(oRotateMatrix)
                                    oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Filler)
                                    'Call oCacheItem.Transform(oRotateMatrix)
                                    Call oCacheItem.SetBrush(PaintOptions.DrawingObjects.CrossSectionMarkerBrush)
                                    Call oCacheItem.AddPolygon({oArrowPoint, New PointF(oArrowPoint.X, oArrowPoint.Y + sArrowSize / 2), New PointF(oArrowPoint.X + iSegmentSign * sArrowSize, oArrowPoint.Y), New PointF(oArrowPoint.X, oArrowPoint.Y - sArrowSize / 2), oArrowPoint})
                                    Call oCacheItem.Transform(oRotateMatrix)
                                Else
                                    If sRefRightWidth > 0 Then
                                        Call oCacheItem.AddLine(oStartPointR, oEndPointR)
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
                                                    If iPlanAlignment = cIItemPlanCrossSectionMarker.PlanAlignmentEnum.Left Then
                                                        oTextPoint = modPaint.GetCenterPoint(oArrowPoint, oEndPointL)
                                                    Else
                                                        oTextPoint = modPaint.GetCenterPoint(oArrowPoint, oEndPointR)
                                                    End If
                                                    oTextPoint.X = oTextPoint.X - sTextWidth / 2
                                                Case cIItemCrossSectionMarker.TextPositionEnum.OppositeSide
                                                    If iPlanAlignment = cIItemPlanCrossSectionMarker.PlanAlignmentEnum.Left Then
                                                        oTextPoint = oEndPointL
                                                    Else
                                                        oTextPoint = oEndPointR
                                                    End If
                                                    If iSegmentSign > 0 Then
                                                        oTextPoint.X = oTextPoint.X - sTextDistance - sArrowSize / 2 - sTextWidth
                                                    Else
                                                        oTextPoint.X = oTextPoint.X + sTextDistance + sArrowSize / 2
                                                    End If
                                            End Select
                                            If iPlanAlignment = cIItemPlanCrossSectionMarker.PlanAlignmentEnum.Left Then
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
                        Else
                            'with not vertical xsection this marker is not allowed...
                            'in design I draw some king of 'reminder'
                            If PaintOptions.IsDesign Then
                                Dim oCacheItem As Drawings.cDrawCacheItem

                                Dim sScale As Single = GetTextScaleFactor(PaintOptions)

                                Dim sArrowSize As Single = PaintOptions.DrawingObjects.CrossSectionMarkerArrowSize * sScale / MyBase.GetTextScaleFactor(PaintOptions)
                                Dim sRefLeftWidth As Single = sArrowSize * 4
                                Dim sRefRightWidth As Single = sArrowSize * 4

                                Dim oSegment As cSegment = oCrossSectionItem.Segment
                                Dim iSegmentSign As Integer = IIf(oCrossSectionItem.Direction = cIItemCrossSection.DirectionEnum.Direct, 1, -1)
                                Dim sAngle As Single = oSegment.Data.Data.Bearing - 90 + PlanDeltaAngle
                                Dim oFromPoint As PointF = oSegment.Data.Plan.FromPoint
                                Dim oToPoint As PointF = oSegment.Data.Plan.ToPoint
                                Dim oMarkerCenterPoint As PointF
                                If oSegment.Data.Data.Reversed Then
                                    oMarkerCenterPoint = modPaint.PointOnLineByPercentage(oToPoint, oFromPoint, oCrossSectionItem.MarkerPosition)
                                Else
                                    oMarkerCenterPoint = modPaint.PointOnLineByPercentage(oFromPoint, oToPoint, oCrossSectionItem.MarkerPosition)
                                End If
                                Using oRotateMatrix As Matrix = New Matrix()
                                    Call oRotateMatrix.RotateAt(sAngle, oMarkerCenterPoint)
                                    Dim sL As Single = sLeft
                                    Dim sR As Single = sRight

                                    Dim oStartPointL As PointF = oMarkerCenterPoint + New SizeF(0, -sL)
                                    Dim oEndPointL As PointF = oMarkerCenterPoint + New SizeF(0, -sL - sRefLeftWidth)
                                    Dim oStartPointR As PointF = oMarkerCenterPoint + New SizeF(0, sR)
                                    Dim oEndPointR As PointF = oMarkerCenterPoint + New SizeF(0, sR + sRefRightWidth)

                                    oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                    Call oCacheItem.SetPen(PaintOptions.DrawingObjects.InvalidPen) 'PaintOptions.DrawingObjects.CrossSectionMarkerPen)
                                    Call oCacheItem.SetWireframePen(PaintOptions.PaintObjects.Pens.GenericPen.WireframePen)

                                    Call oCacheItem.AddLine(oStartPointR, oEndPointR)
                                    Call oCacheItem.StartFigure()
                                    Call oCacheItem.AddLine(oStartPointL, oEndPointL)
                                    Call oCacheItem.Transform(oRotateMatrix)
                                End Using
                            End If
                        End If
                        Call .Rendered()
                    End If
                End If
            End With
        End Sub

        Friend Function GetArrowScaleFactor(PaintOptions As cOptions) As Single
            Dim sTextScaleFactor As Single = MyBase.GetTextScaleFactor(PaintOptions)
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
            Dim sTextScaleFactor As Single = MyBase.GetTextScaleFactor(PaintOptions)
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

        Friend Overrides Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            If MyBase.Points.Count > 0 Then
                Call Render(Graphics, PaintOptions, Options, Selected)
                If Not PaintOptions.IsDesign Or (PaintOptions.IsDesign And Not MyBase.HiddenInDesign) Then
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
                    Dim iSegmentSign As Integer = IIf(oCrossSectionItem.Direction = cIItemCrossSection.DirectionEnum.Direct, 1, -1)
                    Dim sAngle As Single = oSegment.Data.Data.Bearing - 90 + PlanDeltaAngle
                    Dim oFromPoint As PointF = oSegment.Data.Plan.FromPoint
                    Dim oToPoint As PointF = oSegment.Data.Plan.ToPoint
                    Dim oMarkerCenterPoint As PointF = modPaint.PointOnLineByPercentage(oFromPoint, oToPoint, oCrossSectionItem.MarkerPosition)
                    Call MyBase.Points.BeginUpdate()
                    Call MyBase.Points.Clear()
                    Call MyBase.Points.AddFromPaintPoint(oMarkerCenterPoint)
                    Call MyBase.Points.EndUpdate()
                End If
            End If
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As Storage.cFile, ByVal item As XmlElement)
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

            bPlanDeltaAngleEnabled = modXML.GetAttributeValue(item, "plandeltaenabled", "1")
            If bPlanDeltaAngleEnabled Then
                sPlanDeltaAngle = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "plandelta", 0.0))
            End If
            iPlanAlignment = modXML.GetAttributeValue(item, "planalign", 0)
            sLeft = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "left", 0))
            sRight = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "right", 0))
            If modXML.HasAttribute(item, "leftw") Then
                bAutoLeftWidth = False
                sLeftWidth = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "leftw", 0))
            Else
                bAutoLeftWidth = True
            End If
            If modXML.HasAttribute(item, "rightw") Then
                bAutoRightWidth = False
                sRightWidth = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "rightw", 0))
            Else
                bAutoRightWidth = True
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

        Friend Overrides Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
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

            If bPlanDeltaAngleEnabled Then
                Call oItem.SetAttribute("plandeltaenabled", "1")
                If sPlanDeltaAngle <> 0 Then Call oItem.SetAttribute("plandelta", modNumbers.NumberToString(sPlanDeltaAngle))
            End If
            If iPlanAlignment <> 0 Then Call oItem.SetAttribute("planalign", iPlanAlignment)
            If sLeft <> 0 Then Call oItem.SetAttribute("left", modNumbers.NumberToString(sLeft))
            If sRight <> 0 Then Call oItem.SetAttribute("right", modNumbers.NumberToString(sRight))
            If Not bAutoLeftWidth Then Call oItem.SetAttribute("leftw", modNumbers.NumberToString(sLeftWidth))
            If Not bAutoRightWidth Then Call oItem.SetAttribute("rightw", modNumbers.NumberToString(sRightWidth))

            Return oItem
        End Function

        'Private Function pGetLabelPosition(ByVal Graphics As Graphics, ByVal Font As Font, ByVal Point As PointF, ByVal Size As SizeF) As PointF
        '    Select Case iTextPosition
        '        Case cTrigPoint.TrigPointLabelPositionEnum.TopLeft
        '            Return New PointF(Point.X - sTextDistance - Size.Width / 2, Point.Y - sTextDistance - Size.Height / 2)
        '        Case cTrigPoint.TrigPointLabelPositionEnum.TopMiddle
        '            Return New PointF(Point.X - Size.Width / 2, Point.Y - sTextDistance - Size.Height / 2)
        '        Case cTrigPoint.TrigPointLabelPositionEnum.TopRight
        '            Return New PointF(Point.X + sTextDistance - Size.Width / 2, Point.Y - sTextDistance - Size.Height / 2)
        '        Case cTrigPoint.TrigPointLabelPositionEnum.CenterLeft
        '            Return New PointF(Point.X - sTextDistance - Size.Width / 2, Point.Y - Size.Height / 2)
        '        Case cTrigPoint.TrigPointLabelPositionEnum.Center
        '            Return New PointF(Point.X - Size.Width / 2, Point.Y - Size.Height / 2)
        '        Case cTrigPoint.TrigPointLabelPositionEnum.CenterRight
        '            Return New PointF(Point.X + sTextDistance - Size.Width / 2, Point.Y - Size.Height / 2)
        '        Case cTrigPoint.TrigPointLabelPositionEnum.BottomLeft
        '            Return New PointF(Point.X - sTextDistance - Size.Width / 2, Point.Y + sTextDistance - Size.Height / 2)
        '        Case cTrigPoint.TrigPointLabelPositionEnum.BottomCenter
        '            Return New PointF(Point.X - Size.Width / 2, Point.Y + sTextDistance - Size.Height / 2)
        '        Case cTrigPoint.TrigPointLabelPositionEnum.BottomRight
        '            Return New PointF(Point.X + sTextDistance - Size.Width / 2, Point.Y + sTextDistance - Size.Height / 2)
        '    End Select
        'End Function

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
