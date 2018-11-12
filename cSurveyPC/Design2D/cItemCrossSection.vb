Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Design.cLayers

Namespace cSurvey.Design.Items
    Public Class cItemCrossSection
        Inherits cItem
        Implements cIItemText
        Implements cIItemCrossSection
        Implements cIItemCrossSectionSplayBorder
        Implements cIItemSegment

        Private oSurvey As cSurvey

        Private oCrossSection As cDesignCrossSection

        Private oSegment As cSegment
        Private iDirection As cIItemCrossSection.DirectionEnum
        Private sText As String

        Private WithEvents oFont As cItemFont
        Private iTextSize As cIItemText.TextSizeEnum
        Private iTextPosition As cIItemCrossSection.TextPositionEnum
        Private sTextDistance As Single

        Private sCrossWidth As Single
        Private sCrossHeight As Single

        Private bMoveBindedObjects As Boolean

        Private bShowSplayBorder As Boolean
        Private iSplayBorderProjectionAngle As Integer
        Private iSplayBorderLineStyle As cOptions.SplayStyleEnum
        Private sSplayBorderMaxAngleVariation As Single
        Private bShowSplayText As Boolean
        Private bShowOnlyCutSplay As Boolean
        Private iRefStation As cIItemCrossSection.RefStationEnum

        Private sMarkerPosition As Single

        Friend Sub RebindCrossSection(CrossSection As cDesignCrossSection)
            oCrossSection = CrossSection
        End Sub

        Public ReadOnly Property CrossSection() As cDesignCrossSection Implements cIItemCrossSection.CrossSection
            Get
                Return oCrossSection
            End Get
        End Property

        Public Property MarkerPosition As Single Implements cIItemCrossSection.MarkerPosition
            Get
                Return sMarkerPosition
            End Get
            Set(value As Single)
                If value <> sMarkerPosition Then
                    sMarkerPosition = value
                    Call MyBase.Caches.Invalidate()

                    If oCrossSection.HavePlanMarker Then Call oCrossSection.PlanMarker.Caches.Invalidate()
                    If oCrossSection.HaveProfileMarker Then Call oCrossSection.ProfileMarker.Caches.Invalidate()
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
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeSendedToOtherDesign As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeDeleted As Boolean
            Get
                Return True
            End Get
        End Property

        Public Property CrossWidth As Single Implements cIItemCrossSection.CrossWidth
            Get
                Return sCrossWidth
            End Get
            Set(value As Single)
                If sCrossWidth <> value Then
                    sCrossWidth = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property CrossHeight As Single Implements cIItemCrossSection.CrossHeight
            Get
                Return sCrossHeight
            End Get
            Set(value As Single)
                If sCrossHeight <> value Then
                    sCrossHeight = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property CrossSize As SizeF Implements cIItemCrossSection.CrossSize
            Get
                Return New SizeF(sCrossWidth, sCrossHeight)
            End Get
            Set(value As SizeF)
                Dim bInvalidate As Boolean
                If sCrossWidth <> value.Width Then
                    sCrossWidth = value.Width
                    bInvalidate = True
                End If
                If sCrossHeight <> value.Height Then
                    sCrossHeight = value.Height
                    bInvalidate = True
                End If
                If bInvalidate Then
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Overrides ReadOnly Property CanBeReduced As Boolean
            Get
                Return False
            End Get
        End Property

        Public Property SplayBorderLineStyle As cOptions.SplayStyleEnum Implements cIItemCrossSectionSplayBorder.SplayBorderLineStyle
            Get
                Return iSplayBorderLineStyle
            End Get
            Set(value As cOptions.SplayStyleEnum)
                If iSplayBorderLineStyle <> value Then
                    iSplayBorderLineStyle = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property SplayBorderMaxAngleVariation As Single Implements cIItemCrossSectionSplayBorder.SplayBorderMaxAngleVariation
            Get
                Return sSplayBorderMaxAngleVariation
            End Get
            Set(value As Single)
                If sSplayBorderMaxAngleVariation <> value Then
                    sSplayBorderMaxAngleVariation = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property SplayBorderProjectionAngle As Integer Implements cIItemCrossSectionSplayBorder.SplayBorderProjectionAngle
            Get
                Return iSplayBorderProjectionAngle
            End Get
            Set(value As Integer)
                If iSplayBorderProjectionAngle <> value Then
                    iSplayBorderProjectionAngle = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property RefStation As cIItemCrossSection.RefStationEnum Implements cIItemCrossSection.RefStation
            Get
                Return iRefStation
            End Get
            Set(value As cIItemCrossSection.RefStationEnum)
                If iRefStation <> value Then
                    iRefStation = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property ShowSplayBorder As Boolean Implements cIItemCrossSectionSplayBorder.ShowSplayBorder
            Get
                Return bShowSplayBorder
            End Get
            Set(value As Boolean)
                If bShowSplayBorder <> value Then
                    bShowSplayBorder = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property ShowSplayText As Boolean Implements cIItemCrossSectionSplayBorder.ShowSplayText
            Get
                Return bShowSplayText
            End Get
            Set(value As Boolean)
                If bShowSplayText <> value Then
                    bShowSplayText = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property ShowOnlyCutSplay As Boolean Implements cIItemCrossSectionSplayBorder.ShowOnlyCutSplay
            Get
                Return bShowOnlyCutSplay
            End Get
            Set(value As Boolean)
                If bShowOnlyCutSplay <> value Then
                    bShowOnlyCutSplay = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Overrides Sub SetBindDesignType(ByVal BindDesignType As BindDesignTypeEnum, Optional ByVal BindSegment As Boolean = True)
            If CanBeBinded Then
                Call MyBase.SetBindDesignType(BindDesignTypeEnum.MainDesign, False)
            End If
        End Sub

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

        Private Function pGetChangeText()
            Dim bChangeText As Boolean = False
            If Not oSegment Is Nothing Then
                bChangeText = (iDirection = cIItemCrossSection.DirectionEnum.Direct And sText = oSegment.To) Or (iDirection = cIItemCrossSection.DirectionEnum.Inverted And sText = oSegment.From)
            End If
            Return bChangeText
        End Function

        Private Sub pChangeText()
            If iDirection = cIItemCrossSection.DirectionEnum.Direct Then
                sText = oSegment.To
            Else
                sText = oSegment.From
            End If
        End Sub

        Public Property Segment As cSegment Implements cIItemSegment.Segment
            Get
                Return oSegment
            End Get
            Set(ByVal value As cSegment)
                If Not value Is oSegment Then
                    Dim bChangeText As Boolean = pGetChangeText()
                    oSegment = value
                    If bChangeText Then pChangeText()
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
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
                Return oSurvey.Properties.BindCrossSection
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

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum, ByVal Segment As cSegment)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.CrossSection, Category)
            oSurvey = Survey
            oSegment = Segment
            sCrossWidth = 4
            sCrossHeight = 4
            iDirection = cIItemCrossSection.DirectionEnum.Direct
            oFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.TrigPoint)
            If oSegment Is Nothing Then
                sText = GetLocalizedString("itemcrosssection.textpart1")
            Else
                sText = oSegment.To
            End If
            iTextPosition = cIItemCrossSection.TextPositionEnum.TopLeft
            sTextDistance = sCrossWidth / 2

            iSplayBorderProjectionAngle = 0
            iSplayBorderLineStyle = cOptions.SplayStyleEnum.PointsAndRays
            sSplayBorderMaxAngleVariation = 20
            bShowSplayBorder = False
            bShowSplayText = False
            bShowOnlyCutSplay = False
            iRefStation = cIItemCrossSection.RefStationEnum.Automatic

            sMarkerPosition = 0.5

            oCrossSection = oSurvey.CrossSections.Add(Me)

            bMoveBindedObjects = True
        End Sub

        Friend Overrides Sub SetDeleted()
            If oCrossSection.HavePlanMarker Then
                Call MyBase.Survey.Plan.Layers(LayerTypeEnum.Signs).Items.Remove(oCrossSection.PlanMarker)
            End If
            If oCrossSection.HaveProfileMarker Then
                Call MyBase.Survey.Profile.Layers(LayerTypeEnum.Signs).Items.Remove(oCrossSection.ProfileMarker)
            End If
        End Sub

        Private Function pGetScaleFactor() As Single
            Dim sBaseTextScaleFactor As Single = oSurvey.Properties.DesignProperties.GetValue("DesignTextScaleFactor", 0.05)
            Select Case iTextSize
                Case cIItemText.TextSizeEnum.Default
                    Return 1 * sBaseTextScaleFactor
                Case cIItemText.TextSizeEnum.VerySmall
                    Return 0.25 * sBaseTextScaleFactor
                Case cIItemText.TextSizeEnum.Small
                    Return 0.5 * sBaseTextScaleFactor
                Case cIItemText.TextSizeEnum.Medium
                    Return 1 * sBaseTextScaleFactor
                Case cIItemText.TextSizeEnum.Large
                    Return 2 * sBaseTextScaleFactor
                Case cIItemText.TextSizeEnum.VeryLarge
                    Return 4 * sBaseTextScaleFactor
            End Select
        End Function

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
                    Dim oCacheItem As Drawings.cDrawCacheItem
                    Dim oDrawingObject As cOptionsDrawingObjects = PaintOptions.DrawingObjects

                    Dim oBasePoint As PointF
                    Dim oSize1 As SizeF
                    Dim oPoint1 As PointF

                    Dim sLeft As Single
                    Dim sRight As Single
                    Dim sUp As Single
                    Dim sDown As Single

                    Dim sTrigPoint As String
                    oBasePoint = MyBase.Points(0).Point

                    If oSegment Is Nothing Then
                        oPoint1 = oBasePoint
                    Else
                        Dim bNearOrFarStation As Boolean
                        Select Case iRefStation
                            Case cIItemCrossSection.RefStationEnum.Automatic, cIItemCrossSection.RefStationEnum.FarStation
                                bNearOrFarStation = iDirection = cIItemCrossSection.DirectionEnum.Direct Xor oSegment.Data.Data.Reversed
                            Case cIItemCrossSection.RefStationEnum.NearStation
                                bNearOrFarStation = Not (iDirection = cIItemCrossSection.DirectionEnum.Direct Xor oSegment.Data.Data.Reversed)
                        End Select

                        If bNearOrFarStation Then
                            'posizione dal caposaldo...
                            sTrigPoint = oSegment.Data.Data.[To]

                            If oSegment.Data.Data.Reversed Then
                                sLeft = modPaint.DistancePointToPoint(oSegment.Data.Plan.ToSidePointRight, oSegment.Data.Plan.ToPoint)
                                sRight = modPaint.DistancePointToPoint(oSegment.Data.Plan.ToSidePointLeft, oSegment.Data.Plan.ToPoint)
                            Else
                                sLeft = modPaint.DistancePointToPoint(oSegment.Data.Plan.ToSidePointLeft, oSegment.Data.Plan.ToPoint)
                                sRight = modPaint.DistancePointToPoint(oSegment.Data.Plan.ToSidePointRight, oSegment.Data.Plan.ToPoint)
                            End If
                            sUp = modPaint.DistancePointToPoint(oSegment.Data.Profile.ToSidePointUp, oSegment.Data.Profile.ToPoint)
                            sDown = modPaint.DistancePointToPoint(oSegment.Data.Profile.ToSidePointDown, oSegment.Data.Profile.ToPoint)
                            oPoint1 = New PointF(oBasePoint.X - sLeft, oBasePoint.Y - sUp)
                            oSize1 = New SizeF(sLeft + sRight, sUp + sDown)
                        Else
                            sTrigPoint = oSegment.Data.Data.[From]

                            If oSegment.Data.Data.Reversed Then
                                sLeft = modPaint.DistancePointToPoint(oSegment.Data.Plan.FromSidePointRight, oSegment.Data.Plan.FromPoint)
                                sRight = modPaint.DistancePointToPoint(oSegment.Data.Plan.FromSidePointLeft, oSegment.Data.Plan.FromPoint)
                            Else
                                sLeft = modPaint.DistancePointToPoint(oSegment.Data.Plan.FromSidePointLeft, oSegment.Data.Plan.FromPoint)
                                sRight = modPaint.DistancePointToPoint(oSegment.Data.Plan.FromSidePointRight, oSegment.Data.Plan.FromPoint)
                            End If
                            sUp = modPaint.DistancePointToPoint(oSegment.Data.Profile.FromSidePointUp, oSegment.Data.Profile.FromPoint)
                            sDown = modPaint.DistancePointToPoint(oSegment.Data.Profile.FromSidePointDown, oSegment.Data.Profile.FromPoint)

                            oPoint1 = New PointF(oBasePoint.X - sLeft, oBasePoint.Y - sUp)
                            oSize1 = New SizeF(sLeft + sRight, sUp + sDown)
                        End If

                        oNearRect = New RectangleF(oPoint1, oSize1)

                        If PaintOptions.IsDesign Then
                            If oNearRect.Width > 0 OrElse oNearRect.Height > 0 Then
                                Using oPath As GraphicsPath = New GraphicsPath
                                    Call oPath.AddRectangle(oNearRect)
                                    Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oPath, PaintOptions.PaintObjects.NearProfileBorderPen, PaintOptions.PaintObjects.NearProfileBorderPen, Nothing)
                                End Using
                            End If

                            Using oPath As GraphicsPath = New GraphicsPath
                                Dim sMarkerX As Single
                                Dim sMarkerWidth As Single
                                Dim sMarkerY As Single
                                Dim sMarkerHeight As Single
                                If oCrossSection.HavePlanMarker Then
                                    If iDirection = cIItemCrossSection.DirectionEnum.Direct Then
                                        'If oSegment.Data.Data.Reversed Then
                                        '    sMarkerX = oBasePoint.X - oCrossSection.PlanMarker.Right
                                        'Else
                                        sMarkerX = oBasePoint.X - oCrossSection.PlanMarker.Left
                                        'End If
                                    Else
                                        'If oSegment.Data.Data.Reversed Then
                                        '    sMarkerX = oBasePoint.X - oCrossSection.PlanMarker.Left
                                        'Else
                                        sMarkerX = oBasePoint.X - oCrossSection.PlanMarker.Right
                                        'End If
                                    End If
                                    sMarkerWidth = oCrossSection.PlanMarker.Left + oCrossSection.PlanMarker.Right
                                Else
                                    sMarkerX = oBasePoint.X - 0.5
                                    sMarkerWidth = 1
                                End If
                                If oCrossSection.HaveProfileMarker Then
                                    sMarkerY = oBasePoint.Y - oCrossSection.ProfileMarker.Up
                                    sMarkerHeight = oCrossSection.ProfileMarker.Up + oCrossSection.ProfileMarker.Down
                                Else
                                    sMarkerY = oBasePoint.Y - 0.5
                                    sMarkerHeight = 1
                                End If
                                Call oPath.AddRectangle(New RectangleF(sMarkerX, sMarkerY, sMarkerWidth, sMarkerHeight))
                                Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oPath, PaintOptions.PaintObjects.MarkerProfileBorderPen, PaintOptions.PaintObjects.MarkerProfileBorderPen, Nothing)
                            End Using

                            If bShowSplayBorder Then
                                Dim oPoints As List(Of PointF) = New List(Of PointF)
                                Dim sPlaneDirection As Single
                                Dim sPlainDirectionInverted As Single

                                If iDirection = cIItemCrossSection.DirectionEnum.Direct Then
                                    sPlaneDirection = modPaint.NormalizeAngle(oSegment.Data.Data.Bearing - 90)
                                Else
                                    sPlaneDirection = modPaint.NormalizeAngle(oSegment.Data.Data.Bearing + 90)
                                End If
                                sPlaneDirection = sPlaneDirection + iSplayBorderProjectionAngle

                                If sPlaneDirection > 180 Then
                                    sPlainDirectionInverted = sPlaneDirection - 180
                                Else
                                    sPlainDirectionInverted = sPlaneDirection + 180
                                End If

                                Dim oSplaySegments As cISegmentCollection = oSurvey.Segments.GetSplaySegments(sTrigPoint)
                                If oSplaySegments.Count > 0 Then
                                    For Each oSplaySegment As cSegment In oSplaySegments
                                        If (bShowOnlyCutSplay AndAlso oSplaySegment.Cut) OrElse (Not bShowOnlyCutSplay) Then
                                            Dim sSplayBearing As Single = oSplaySegment.Data.Data.Bearing
                                            If modPaint.IsAngleBetween(sSplayBearing, sPlaneDirection - sSplayBorderMaxAngleVariation, sPlaneDirection + sSplayBorderMaxAngleVariation) Or modPaint.IsAngleBetween(sSplayBearing, sPlainDirectionInverted - sSplayBorderMaxAngleVariation, sPlainDirectionInverted + sSplayBorderMaxAngleVariation) Then
                                                Dim sDeltaAngle As Single = modPaint.NormalizeAngle(oSplaySegment.Data.Data.Bearing - sPlaneDirection)
                                                Dim oSegmentCateti As SizeF = modPaint.Trigo(oSplaySegment.Data.Data.Distance, oSplaySegment.Data.Data.Inclination)
                                                Dim sSegmentY As Single = oSegmentCateti.Width
                                                Dim sSegmentX As Single = -modPaint.Trigo(oSegmentCateti.Height, sDeltaAngle).Height
                                                Dim oCurrentPoint As PointF = New PointF(oBasePoint.X + sSegmentX, oBasePoint.Y - sSegmentY)
                                                Call oPoints.Add(oCurrentPoint)
                                                If bShowSplayText Then
                                                    oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                                    Call oCacheItem.SetBrush(oDrawingObject.SplayBrush)
                                                    Call oCacheItem.AddString(oSplaySegment.To, oDrawingObject.SplayFont, oCurrentPoint)
                                                End If
                                            End If
                                        End If
                                    Next

                                    If oPoints.Count > 0 Then
                                        Dim sPointSize As Single = 0.3

                                        Using oCrossPath As GraphicsPath = New GraphicsPath
                                            For Each oPoint As PointF In oPoints
                                                Call modPaint.PathAddCrossFromPoint(oCrossPath, oPoint, sPointSize)
                                            Next
                                            oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                            Dim oColor As Color = oSurvey.Properties.CaveInfos.GetColor(oSegment, oDrawingObject.SplayPenColor)
                                            oDrawingObject.SplayPen.Color = oColor
                                            Call oCacheItem.SetPen(oDrawingObject.SplayPen)
                                            Call oCacheItem.SetWireframePen(oDrawingObject.SplayPen)
                                            Call oCacheItem.AddPath(oCrossPath)
                                        End Using

                                        If iSplayBorderLineStyle <> cOptions.SplayStyleEnum.Points Then
                                            Using oBorderPath As GraphicsPath = New GraphicsPath
                                                For Each oPoint As PointF In oPoints
                                                    Call oBorderPath.StartFigure()
                                                    Call oBorderPath.AddLine(oBasePoint, oPoint)
                                                Next
                                                oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                                Call oCacheItem.SetPen(oDrawingObject.SplayPen)
                                                Call oCacheItem.SetWireframePen(oDrawingObject.SplayPen)
                                                Call oCacheItem.AddPath(oBorderPath)
                                            End Using
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If

                    If sCrossWidth <> 0 OrElse sCrossHeight <> 0 Then
                        Using oPath As GraphicsPath = New GraphicsPath
                            If sCrossWidth <> 0 Then
                                Dim sWidth As Single = sCrossWidth / 2
                                Call oPath.AddLine(oBasePoint, New PointF(oBasePoint.X - sWidth, oBasePoint.Y))
                                Call oPath.AddLine(oBasePoint, New PointF(oBasePoint.X + sWidth, oBasePoint.Y))
                            End If
                            If sCrossHeight <> 0 Then
                                Dim sHeight As Single = sCrossHeight / 2
                                Call oPath.AddLine(oBasePoint, New PointF(oBasePoint.X, oBasePoint.Y - sHeight))
                                Call oPath.AddLine(oBasePoint, New PointF(oBasePoint.X, oBasePoint.Y + sHeight))
                            End If
                            Call oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oPath, PaintOptions.PaintObjects.ProfileCrossPen, PaintOptions.PaintObjects.NearProfileBorderPen, Nothing)
                        End Using
                    End If

                    Using oPath As GraphicsPath = New GraphicsPath
                        Using oSF As StringFormat = New StringFormat
                            Call oFont.AddToPath(PaintOptions, oPath, sText, New PointF(0, 0), oSF)
                        End Using

                        Dim sScale As Single = pGetScaleFactor()
                        Using oMatrix As Matrix = New Matrix
                            Call oMatrix.Scale(sScale, sScale, MatrixOrder.Append)
                            Call oPath.Transform(oMatrix)
                        End Using

                        Dim oTextPoint As PointF = pGetLabelPosition(Graphics, oBasePoint, oPath.GetBounds.Size)
                        Using oMatrix As Matrix = New Matrix
                            Call oMatrix.Translate(oTextPoint.X, oTextPoint.Y, MatrixOrder.Append)
                            Call oPath.Transform(oMatrix)
                        End Using

                        Call oFont.Render(Graphics, PaintOptions, Options, oPath, oCache)
                    End Using

                    Call .Rendered()
                End If
            End With
        End Sub

        Public Overrides Function GetCenterPoint() As PointF
            Return MyBase.Points(0).Point
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
            If MyBase.Points.Count > 1 Or ForceBound Then
                Dim oxPoints() As PointF = MyBase.Points.GetPoints()
                Dim oRect As RectangleF
                For Each oxPoint As PointF In oxPoints
                    If modPaint.IsRectangleEmpty(oRect) Then
                        oRect = New RectangleF(oxPoint.X, oxPoint.Y, 0, 0)
                    Else
                        oRect = RectangleF.Union(oRect, New RectangleF(oxPoint.X, oxPoint.Y, 0, 0))
                    End If
                Next
                Call MyBase.Points.Clear()
                Call MyBase.Points.AddFromPaintPoint(oRect.Left + oRect.Width / 2, oRect.Top + oRect.Height / 2)
            End If
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As Storage.cFile, ByVal item As XmlElement)
            Call MyBase.New(Survey, Design, Layer, File, item)
            oSurvey = Survey
            oSegment = oSurvey.GetSegment(modXML.GetAttributeValue(item, "segment", ""))
            Try
                oFont = New cItemFont(oSurvey, item.Item("font"))
            Catch ex As Exception
                oFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.TrigPoint)
            End Try
            iDirection = modXML.GetAttributeValue(item, "direction")
            sText = modXML.GetAttributeValue(item, "text", "")
            iTextSize = modXML.GetAttributeValue(item, "textsize")
            sCrossWidth = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "crosswidth", 4))
            sCrossHeight = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "crossheight", 4))
            sTextDistance = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "textdistance", sCrossWidth / 2))
            iTextPosition = modXML.GetAttributeValue(item, "textposition", cIItemCrossSection.TextPositionEnum.TopLeft)

            bShowSplayBorder = modXML.GetAttributeValue(item, "showsplayborder", False)
            iSplayBorderProjectionAngle = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "splayborderprojectionangle", -1))
            iSplayBorderLineStyle = modXML.GetAttributeValue(item, "splayborderlinestyle", cOptions.SplayStyleEnum.PointsAndRays)
            If iSplayBorderLineStyle > cOptions.SplayStyleEnum.PointsAndRays Then iSplayBorderLineStyle = cOptions.SplayStyleEnum.PointsAndRays
            sSplayBorderMaxAngleVariation = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "splaybordermaxanglevariation", 20))
            bShowSplayText = modXML.GetAttributeValue(item, "showsplaytext", False)
            bShowOnlyCutSplay = modXML.GetAttributeValue(item, "showonlycutsplay", False)
            iRefStation = modXML.GetAttributeValue(item, "refstation", cIItemCrossSection.RefStationEnum.Automatic)

            sMarkerPosition = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "markerposition", 0.5))
            If sMarkerPosition > 1 Then sMarkerPosition = 0.5

            Call oSurvey.CrossSections.Add(Me)
            Call FixBound()

            bMoveBindedObjects = True
        End Sub

        Public ReadOnly Property Font As cItemFont Implements cIItemText.Font
            Get
                Return oFont
            End Get
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

        Public Property TextPosition() As cIItemCrossSection.TextPositionEnum Implements cIItemCrossSection.TextPosition
            Get
                Return iTextPosition
            End Get
            Set(ByVal value As cIItemCrossSection.TextPositionEnum)
                If iTextPosition <> value Then
                    iTextPosition = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property TextDistance() As Single Implements cIItemCrossSection.TextDistance
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

        Public Overrides ReadOnly Property HaveCrossSection As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HaveSplayBorder As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeConverted As Boolean
            Get
                Return False
            End Get
        End Property

        Friend Overrides Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oItem As XmlElement = MyBase.SaveTo(File, Document, Parent, Options)
            Call oItem.SetAttribute("direction", iDirection)
            Call oItem.SetAttribute("text", sText)
            Call oFont.SaveTo(File, Document, oItem, "font")
            If iTextSize <> cIItemText.TextSizeEnum.Default Then Call oItem.SetAttribute("textsize", iTextSize)
            If iTextPosition <> cIItemCrossSection.TextPositionEnum.TopLeft Then
                Call oItem.SetAttribute("textposition", iTextPosition)
            End If

            Call oItem.SetAttribute("textdistance", modNumbers.NumberToString(sTextDistance))
            Call oItem.SetAttribute("crosswidth", modNumbers.NumberToString(sCrossWidth))
            Call oItem.SetAttribute("crossheight", modNumbers.NumberToString(sCrossHeight))
            If Not oSegment Is Nothing Then
                Call oItem.SetAttribute("segment", oSegment.ID)
            End If

            If bShowSplayBorder Then Call oItem.SetAttribute("showsplayborder", 1)
            If iSplayBorderProjectionAngle <> -1 Then Call oItem.SetAttribute("splayborderprojectionangle", iSplayBorderProjectionAngle)
            If iSplayBorderLineStyle <> cOptions.SplayStyleEnum.PointsAndRays Then Call oItem.SetAttribute("splayborderlinestyle", iSplayBorderLineStyle.ToString("D"))
            If sSplayBorderMaxAngleVariation <> 20 Then Call oItem.SetAttribute("splaybordermaxanglevariation", modNumbers.NumberToString(sSplayBorderMaxAngleVariation))
            If bShowSplayText Then Call oItem.SetAttribute("showsplaytext", 1)
            If bShowOnlyCutSplay Then Call oItem.SetAttribute("showonlycutsplay", 1)
            If iRefStation <> cIItemCrossSection.RefStationEnum.Automatic Then Call oItem.SetAttribute("refstation", iRefStation.ToString("D"))

            'If bShowMarker Then oItem.SetAttribute("showmarker", "1")
            If sMarkerPosition <> 0.5 Then Call oItem.SetAttribute("markerposition", modNumbers.NumberToString(sMarkerPosition))
            'If sMarkerPlanDeltaAngle <> 0 Then Call oItem.SetAttribute("markerplandelta", modNumbers.NumberToString(sMarkerPlanDeltaAngle))
            'If iMarkerPlanAlignment <> 0 Then Call oItem.SetAttribute("markerplanalign", iMarkerPlanAlignment)
            'If iMarkerProfileAlignment <> 0 Then Call oItem.SetAttribute("markerprofilealign", iMarkerProfileAlignment)
            'If sMarkerL <> 0 Then Call oItem.SetAttribute("markerl", modNumbers.NumberToString(sMarkerL))
            'If sMarkerR <> 0 Then Call oItem.SetAttribute("markerr", modNumbers.NumberToString(sMarkerR))
            'If sMarkerU <> 0 Then Call oItem.SetAttribute("markeru", modNumbers.NumberToString(sMarkerU))
            'If sMarkerD <> 0 Then Call oItem.SetAttribute("markerd", modNumbers.NumberToString(sMarkerD))

            Return oItem
        End Function

        Private Function pGetLabelPosition(ByVal Graphics As Graphics, ByVal Point As PointF, ByVal Size As SizeF) As PointF
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

        Friend Sub Calculate(Optional ByVal PerformWarping As Boolean = True)
            Dim oFromSidePointRight As PointF
            Dim oFromSidePointLeft As PointF
            Dim oToSidePointRight As PointF
            Dim oToSidePointLeft As PointF

            Try
                Dim oFromPoint As PointF = Points(0).Point
                Dim oToPoint As PointF = oFromPoint
                Call oCrossSection.Data.Profile.SetPoints("", "", oFromPoint, oToPoint, oFromSidePointRight, oFromSidePointLeft, oToSidePointRight, oToSidePointLeft)
                Call oCrossSection.Data.ResetWarpingFactor()
            Catch ex As Exception
            End Try

            'e fare la warp per i punti associati ai segmenti cambiati...
            If PerformWarping Then
                If oSurvey.Properties.DesignWarpingMode = cSurvey.DesignWarpingModeEnum.Default Then
                    'Dim oCrossSections As cDesignCrossSectionsCollection = GetChangedCrossSections(cIDesign.cDesignTypeEnum.Profile, True)
                    'Dim iIndex As Integer = 0
                    'Dim iCount As Integer = oCrossSections.Count
                    'If iCount > 0 Then
                    'Call oSurvey.RaiseOnProgressEvent("warping.crosssection", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, "Warping crosssections...", 0)
                    'For Each oCrossSection As cDesignCrossSection In oCrossSections
                    'If (iIndex Mod 20) = 0 Then Call oSurvey.RaiseOnProgressEvent("warping.crosssection", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Warping crosssections...", iIndex / iCount)
                    If oCrossSection.Data.Profile.Changed AndAlso oCrossSection.Data.ProfileWarpingFactor.IsChanged Then
                        'Call oSurvey.Profile.WarpItems(oCrossSection)
                        Call oCrossSection.WarpItems()
                        Call oCrossSection.Data.Profile.ResetChange()
                    End If
                    'iIndex += 1
                    'Next
                    'Call oSurvey.RaiseOnProgressEvent("warping.crosssection", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)
                    'End If
                End If
            End If
        End Sub

        Public Overrides Sub MoveBy(ByVal OffsetX As Single, ByVal OffsetY As Single)
            Call MyBase.MoveBy(OffsetX, OffsetY)
            Call Calculate(bMoveBindedObjects)
        End Sub

        Public Overrides Sub MoveBy(ByVal Size As System.Drawing.SizeF)
            Call MyBase.MoveBy(Size)
            Call Calculate(bMoveBindedObjects)
        End Sub

        Public Overrides Sub MoveTo(ByVal X As Single, ByVal Y As Single)
            Call MyBase.MoveTo(X, Y)
            Call Calculate(bMoveBindedObjects)
        End Sub

        Public Overrides Sub MoveTo(ByVal Point As System.Drawing.PointF)
            Call MyBase.MoveTo(Point)
            Call Calculate(bMoveBindedObjects)
        End Sub

        Public Property Direction As cIItemCrossSection.DirectionEnum Implements cIItemCrossSection.Direction
            Get
                Return iDirection
            End Get
            Set(ByVal value As cIItemCrossSection.DirectionEnum)
                If value <> iDirection Then
                    Dim bChangeText As Boolean = pGetChangeText()
                    iDirection = value
                    If bChangeText Then pChangeText()
                    Call MyBase.Caches.Invalidate()

                    If oCrossSection.HavePlanMarker Then Call oCrossSection.PlanMarker.Caches.Invalidate()
                    If oCrossSection.HaveProfileMarker Then Call oCrossSection.ProfileMarker.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property MoveBindedObjects As Boolean Implements cIItemCrossSection.MoveBindedObjects
            Get
                Return bMoveBindedObjects
            End Get
            Set(ByVal value As Boolean)
                bMoveBindedObjects = value
            End Set
        End Property

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

        Public ReadOnly Property AvaiableTextProperties As cIItemText.AvaiableTextPropertiesEnum Implements cIItemText.AvaiableTextProperties
            Get
                Return cIItemText.AvaiableTextPropertiesEnum.None
            End Get
        End Property

        Private Sub oFont_OnRender(sender As cItemFont, RenderArgs As cItemFont.cRenderArgs) Handles oFont.OnRender
            If HaveTransparency Then
                RenderArgs.Transparency = MyBase.Transparency
            End If
        End Sub
    End Class
End Namespace
