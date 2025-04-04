﻿Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Calculate

Imports System.Xml
Imports cSurveyPC.cSurvey.Design.cLayers
Imports cSurveyPC.cResurvey

Namespace cSurvey.Design
    Public Class cPlotPlan
        Inherits cPlot

        Private oSurvey As cSurvey

        Public Overrides Function HitTest(ByVal PaintOptions As cOptionsCenterline, ByVal CurrentCave As String, ByVal CurrentBranch As String, ByVal Point As PointF, Optional Wide As Decimal = Decimal.MaxValue) As cPlotHitTestResult
            If PaintOptions.DrawPlot Then
                Dim oFoundSegment As cSegment = Nothing
                Dim oFoundTrigpoint As cTrigPoint = Nothing
                Dim dMinDistance As Decimal = Wide

                Dim oVisibleSegments As List(Of cISegment) = MyBase.GetAllVisibleSegments(PaintOptions)
                For Each oSegment As cSegment In oVisibleSegments
                    If modDesign.GetIfSegmentMustBeDrawedByCaveAndBranch(PaintOptions, oSegment, CurrentCave, CurrentBranch) Then
                        If oSegment.IsValid AndAlso Not oSegment.IsSelfDefined AndAlso Not oSegment.Splay Then
                            Dim oPoints() As PointD = oSegment.Data.Plan.GetVectorLine
                            Dim dDistance As Decimal = modPaint.DistancePointToSegment(CType(Point, PointD), oPoints(0), oPoints(1))
                            If dDistance < dMinDistance Then
                                oFoundSegment = oSegment
                                dMinDistance = dDistance
                            End If
                        End If
                    End If
                Next

                If Not oFoundSegment Is Nothing Then
                    Dim sTrigpointDistance As Single = 0.5
                    Dim oPoints() As PointD = oFoundSegment.Data.Plan.GetVectorLine
                    Dim dDistance0 As Decimal = modPaint.DistancePointToPoint(CType(Point, PointD), oPoints(0))
                    Dim dDistance1 As Decimal = modPaint.DistancePointToPoint(CType(Point, PointD), oPoints(1))
                    If PaintOptions.DrawPoints AndAlso (dDistance0 < sTrigpointDistance OrElse dDistance1 < sTrigpointDistance) Then
                        If dDistance0 < dDistance1 Then
                            If oFoundSegment.Data.Data.Reversed Then
                                oFoundTrigpoint = oFoundSegment.GetToTrigPoint
                                Return New cPlotHitTestResult(Nothing, oFoundTrigpoint)
                            Else
                                oFoundTrigpoint = oFoundSegment.GetFromTrigPoint
                                Return New cPlotHitTestResult(Nothing, oFoundTrigpoint)
                            End If
                        Else
                            If oFoundSegment.Data.Data.Reversed Then
                                oFoundTrigpoint = oFoundSegment.GetFromTrigPoint
                                Return New cPlotHitTestResult(Nothing, oFoundTrigpoint)
                            Else
                                oFoundTrigpoint = oFoundSegment.GetToTrigPoint
                                Return New cPlotHitTestResult(Nothing, oFoundTrigpoint)
                            End If
                        End If
                    Else
                        If PaintOptions.DrawSegments Then
                            Return New cPlotHitTestResult(oFoundSegment, Nothing)
                        Else
                            Return New cPlotHitTestResult(Nothing, Nothing)
                        End If
                    End If
                End If
                Return New cPlotHitTestResult(Nothing, Nothing)
            Else
                Return New cPlotHitTestResult(Nothing, Nothing)
            End If
        End Function

        Public Overrides Function GetVisibleCaveBounds(PaintOptions As cOptionsCenterline, ByVal Cave As String, Branch As String) As RectangleF
            Dim oOrigin As cTrigPoint = oSurvey.TrigPoints.GetOrigin
            If Not oOrigin Is Nothing Then
                Dim oSegments As IEnumerable(Of cISegment) = oSurvey.Segments.GetVisibleCaveSegments(PaintOptions, Cave, Branch).Where(Function(oSegment)
                                                                                                                                           If Not oSegment.IsSelfDefined AndAlso oSegment.IsValid Then
                                                                                                                                               Dim bVisible As Boolean = True
                                                                                                                                               If oSegment.Surface Then
                                                                                                                                                   bVisible = (PaintOptions.DrawSegmentsOptions And cOptionsCenterline.DrawSegmentsOptionsEnum.Surface) = cOptionsCenterline.DrawSegmentsOptionsEnum.Surface
                                                                                                                                               End If
                                                                                                                                               If bVisible Then
                                                                                                                                                   If oSegment.Duplicate Then
                                                                                                                                                       bVisible = (PaintOptions.DrawSegmentsOptions And cOptionsCenterline.DrawSegmentsOptionsEnum.Duplicate) = cOptionsCenterline.DrawSegmentsOptionsEnum.Duplicate
                                                                                                                                                   End If
                                                                                                                                               End If
                                                                                                                                               Return bVisible
                                                                                                                                           End If
                                                                                                                                       End Function)
                If oSegments.Count = 0 Then
                    Return New RectangleF(0, 0, 0, 0)
                Else
                    Dim oMinPoint As PointF = New Point(Integer.MaxValue, Integer.MaxValue)
                    Dim oMaxPoint As PointF = New Point(Integer.MinValue, Integer.MinValue)
                    For Each oSegment As cISegment In oSegments
                        Call modPlot.PlanTranslateAndComparePoint(oSurvey, oSegment.Data.Plan.ToPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                        Call modPlot.PlanTranslateAndComparePoint(oSurvey, oSegment.Data.Plan.FromPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                        If PaintOptions.DrawSplay Then
                            For Each oSplayPoint As Plot.cSplayPlanProjectedData In oSegment.Data.Plan.FromSplays.Where(Function(oitem) oitem.InRange)
                                Call modPlot.PlanTranslateAndComparePoint(oSurvey, oSplayPoint.ToPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                            Next
                            For Each oSplayPoint As Plot.cSplayPlanProjectedData In oSegment.Data.Plan.ToSplays.Where(Function(oitem) oitem.InRange)
                                Call modPlot.PlanTranslateAndComparePoint(oSurvey, oSplayPoint.ToPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                            Next
                        End If
                    Next
                    Return New RectangleF(oMinPoint, New SizeF(oMaxPoint.X - oMinPoint.X, oMaxPoint.Y - oMinPoint.Y))
                End If
            Else
                Return New RectangleF(0, 0, 0, 0)
            End If
        End Function

        Public Overrides Function GetCaveBounds(PaintOptions As cOptionsCenterline, ByVal Cave As String, Branch As String) As RectangleF
            Dim oOrigin As cTrigPoint = oSurvey.TrigPoints.GetOrigin
            If Not oOrigin Is Nothing Then
                Dim oSegments As IEnumerable(Of cISegment) = oSurvey.Segments.GetCaveSegments(Cave, Branch).Where(Function(oSegment)
                                                                                                                      Dim bVisible As Boolean = True
                                                                                                                      If oSegment.Surface Then
                                                                                                                          bVisible = (PaintOptions.DrawSegmentsOptions AndAlso cOptionsCenterline.DrawSegmentsOptionsEnum.Surface) = cOptionsCenterline.DrawSegmentsOptionsEnum.Surface
                                                                                                                      End If
                                                                                                                      If bVisible Then
                                                                                                                          If oSegment.Duplicate Then
                                                                                                                              bVisible = (PaintOptions.DrawSegmentsOptions AndAlso cOptionsCenterline.DrawSegmentsOptionsEnum.Duplicate) = cOptionsCenterline.DrawSegmentsOptionsEnum.Duplicate
                                                                                                                          End If
                                                                                                                      End If
                                                                                                                      Return bVisible
                                                                                                                  End Function)
                If oSegments.Count = 0 Then
                    Return New RectangleF(0, 0, 0, 0)
                Else
                    Dim oMinPoint As PointF = New Point(Integer.MaxValue, Integer.MaxValue)
                    Dim oMaxPoint As PointF = New Point(Integer.MinValue, Integer.MinValue)
                    For Each oSegment As cSegment In oSegments
                        Call modPlot.PlanTranslateAndComparePoint(oSurvey, oSegment.Data.Plan.ToPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                        Call modPlot.PlanTranslateAndComparePoint(oSurvey, oSegment.Data.Plan.FromPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                    Next
                    Return New RectangleF(oMinPoint, New SizeF(oMaxPoint.X - oMinPoint.X, oMaxPoint.Y - oMinPoint.Y))
                End If
            Else
                Return New RectangleF(0, 0, 0, 0)
            End If
        End Function

        Public Overrides Function GetVisibleBounds(PaintOptions As cOptionsCenterline) As RectangleF
            Dim oOrigin As cTrigPoint = oSurvey.TrigPoints.GetOrigin
            If Not oOrigin Is Nothing Then
                Dim oSegments As IEnumerable(Of cISegment) = MyBase.GetAllVisibleSegments(PaintOptions)
                If oSegments.Count = 0 Then
                    Return New RectangleF(0, 0, 0, 0)
                Else
                    Dim oMinPoint As PointF = New Point(Integer.MaxValue, Integer.MaxValue)
                    Dim oMaxPoint As PointF = New Point(Integer.MinValue, Integer.MinValue)
                    For Each oSegment As cSegment In oSegments
                        Call modPlot.PlanTranslateAndComparePoint(oSurvey, oSegment.Data.Plan.ToPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                        Call modPlot.PlanTranslateAndComparePoint(oSurvey, oSegment.Data.Plan.FromPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                        If PaintOptions.DrawSplay Then
                            For Each oSplayPoint As Plot.cSplayPlanProjectedData In oSegment.Data.Plan.FromSplays.Where(Function(oitem) oitem.InRange)
                                Call modPlot.PlanTranslateAndComparePoint(oSurvey, oSplayPoint.ToPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                            Next
                            For Each oSplayPoint As Plot.cSplayPlanProjectedData In oSegment.Data.Plan.ToSplays.Where(Function(oitem) oitem.InRange)
                                Call modPlot.PlanTranslateAndComparePoint(oSurvey, oSplayPoint.ToPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                            Next
                        End If
                    Next
                    Return New RectangleF(oMinPoint, New SizeF(oMaxPoint.X - oMinPoint.X, oMaxPoint.Y - oMinPoint.Y))
                End If
            Else
                Return New RectangleF(0, 0, 0, 0)
            End If
        End Function

        Public Overrides Function GetBounds(PaintOptions As cOptionsCenterline) As RectangleF
            Dim oOrigin As cTrigPoint = oSurvey.TrigPoints.GetOrigin
            If Not oOrigin Is Nothing Then
                Dim oSegments As IEnumerable(Of cISegment) = MyBase.GetAllSegments(PaintOptions).Where(Function(oSegment)
                                                                                                           Dim bVisible As Boolean = True
                                                                                                           If oSegment.Surface Then
                                                                                                               bVisible = (PaintOptions.DrawSegmentsOptions AndAlso cOptionsCenterline.DrawSegmentsOptionsEnum.Surface) = cOptionsCenterline.DrawSegmentsOptionsEnum.Surface
                                                                                                           End If
                                                                                                           If bVisible Then
                                                                                                               If oSegment.Duplicate Then
                                                                                                                   bVisible = (PaintOptions.DrawSegmentsOptions AndAlso cOptionsCenterline.DrawSegmentsOptionsEnum.Duplicate) = cOptionsCenterline.DrawSegmentsOptionsEnum.Duplicate
                                                                                                               End If
                                                                                                           End If
                                                                                                           Return bVisible
                                                                                                       End Function)
                If oSegments.Count = 0 Then
                    Return New RectangleF(0, 0, 0, 0)
                Else
                    Dim oMinPoint As PointF = New Point(Integer.MaxValue, Integer.MaxValue)
                    Dim oMaxPoint As PointF = New Point(Integer.MinValue, Integer.MinValue)
                    For Each oSegment As cSegment In oSegments
                        Call modPlot.PlanTranslateAndComparePoint(oSurvey, oSegment.Data.Plan.ToPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                        Call modPlot.PlanTranslateAndComparePoint(oSurvey, oSegment.Data.Plan.FromPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                    Next
                    Return New RectangleF(oMinPoint, New SizeF(oMaxPoint.X - oMinPoint.X, oMaxPoint.Y - oMinPoint.Y))
                End If
            Else
                Return New RectangleF(0, 0, 0, 0)
            End If
        End Function

        Private oSegmentsCaches As Dictionary(Of cSegment, cDrawCaches) = New Dictionary(Of cSegment, cDrawCaches)
        Private oTrigpointsCaches As Dictionary(Of cTrigPoint, cDrawCaches) = New Dictionary(Of cTrigPoint, cDrawCaches)

        Private Function pGetOrCreateTrigpointFromCache(TrigPoint As cTrigPoint, PaintOptions As cOptionsCenterline) As cDrawCache
            If oTrigpointsCaches.ContainsKey(TrigPoint) Then
                Return oTrigpointsCaches(TrigPoint)(PaintOptions)
            Else
                Dim oValue As cDrawCaches = New cDrawCaches
                oTrigpointsCaches.Add(TrigPoint, oValue)
                Return oValue(PaintOptions)
            End If
        End Function

        Private Function pGetOrCreateSegmentFromCache(Segment As cSegment, PaintOptions As cOptionsCenterline) As cDrawCache
            If oSegmentsCaches.ContainsKey(Segment) Then
                Return oSegmentsCaches(Segment)(PaintOptions)
            Else
                Dim oValue As cDrawCaches = New cDrawCaches
                oSegmentsCaches.Add(Segment, oValue)
                Return oValue(PaintOptions)
            End If
        End Function

        Public Overrides Sub Redraw(Trigpoint As cTrigPoint)
            If Trigpoint IsNot Nothing Then
                If oTrigpointsCaches.ContainsKey(Trigpoint) Then
                    oTrigpointsCaches(Trigpoint).Invalidate()
                End If
            End If
        End Sub

        Public Overrides Sub Redraw(Segment As cSegment)
            If Segment IsNot Nothing Then
                If oSegmentsCaches.ContainsKey(Segment) Then
                    oSegmentsCaches(Segment).Invalidate()
                End If
            End If
        End Sub

        Public Overrides Sub Redraw(Optional Options As cOptionsCenterline = Nothing)
            Threading.Tasks.Parallel.ForEach(Of cDrawCaches)(oTrigpointsCaches.Values, Sub(oCaches)
                                                                                           Call oCaches.Invalidate(Options)
                                                                                       End Sub)
            Threading.Tasks.Parallel.ForEach(Of cDrawCaches)(oSegmentsCaches.Values, Sub(oCaches)
                                                                                         Call oCaches.Invalidate(Options)
                                                                                     End Sub)
        End Sub

        Friend Sub Render(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, Selection As Helper.Editor.cIEditDesignSelection)
            'Dim oCache As cDrawCache = MyBase.Caches(PaintOptions)
            'With oCache
            'If .Invalidated Then
            '        Call .Clear()
            Dim oCacheItem As Drawings.cDrawCacheItem
            Dim oStartSurveySegment As cISegment = oSurvey.Segments.GetOrigin
            'disegno SOLO se ho l'orgine definita...altrimenti non verrebbe nulla
            If Not oStartSurveySegment Is Nothing Then
                Dim iSplayEditMode As cOptionsDesign.SplayEditModeEnum
                If TypeOf PaintOptions Is cOptionsDesign Then
                    iSplayEditMode = DirectCast(PaintOptions, cOptionsDesign).SplayEditMode
                Else
                    iSplayEditMode = cOptionsDesign.SplayEditModeEnum.All
                End If

                Dim oCurrentSegment As cISegment = If(PaintOptions.IsDesign, Selection.CurrentSegment, Nothing)
                Dim oCurrentTrigpoint As cTrigPoint = If(PaintOptions.IsDesign, Selection.CurrentTrigpoint, Nothing)
                'Dim oDrawedSplaySegment As List(Of String) = New List(Of String)
                Dim oDrawingObject As cOptionsDrawingObjects = PaintOptions.DrawingObjects
                Dim oTranslationTrigPoints As cTranslatedTrigPoints = New cTranslatedTrigPoints

                Dim oDefaultRingColor As Color
                Dim sDefaultRingPenWidth As Single
                With oSurvey.Properties.HighlightsDetails(Properties.cHighlightsDetails.RingKey)
                    oDefaultRingColor = Color.FromArgb(.Opacity, .Color)
                    sDefaultRingPenWidth = .Size
                End With

                Dim oVisibleSegments As List(Of cISegment) = MyBase.GetAllVisibleSegments(PaintOptions)
                For Each oSegment As cSegment In oVisibleSegments
                    If Not oSegment.Splay Then
                        If modDesign.GetIfSegmentMustBeDrawedByCaveAndBranch(PaintOptions, oSegment, Selection.CurrentCave, Selection.CurrentBranch) Then
                            Dim oSegmentCache As cDrawCache = pGetOrCreateSegmentFromCache(oSegment, PaintOptions)
                            If oSegmentCache.Invalidated Then
                                With oSegmentCache
                                    Using oTranslationMatrix As Matrix = New Matrix
                                        If Not PaintOptions.IsDesign AndAlso PaintOptions.DrawTranslation Then
                                            Dim oTranslation As PointF = modPlot.GetPlanSegmentTranslation(oSurvey, oSegment)
                                            If Not oTranslation.IsEmpty Then
                                                oTranslationMatrix.Translate(oTranslation.X, oTranslation.Y, Drawing2D.MatrixOrder.Prepend)
                                            End If
                                        End If

                                        Dim oCaveColor As Color
                                        Select Case PaintOptions.CenterlineColorMode
                                            Case 0
                                                oCaveColor = oSurvey.Properties.CaveInfos.GetColor(oSegment, oDrawingObject.PenColor)
                                            Case 1
                                                oCaveColor = oSurvey.Properties.CaveInfos.GetColor(oSegment.Cave, "", oDrawingObject.PenColor)
                                            Case 2
                                                oCaveColor = oSurvey.Properties.CaveInfos.GetOriginColor(oSegment, oDrawingObject.PenColor)
                                        End Select
                                        If PaintOptions.CenterlineColorGray Then
                                            oCaveColor = modPaint.GrayColor(oCaveColor)
                                        End If

                                        If (iSplayEditMode = cOptionsDesign.SplayEditModeEnum.All OrElse (iSplayEditMode = cOptionsDesign.SplayEditModeEnum.OnlyCurrentSegment And oSegment Is Selection.CurrentSegment)) AndAlso PaintOptions.DrawPlot AndAlso PaintOptions.DrawSegments AndAlso PaintOptions.DrawSplay Then
                                            Dim oColor As Color
                                            If oSegment.Data.SegmentColor = Color.Transparent Then
                                                oColor = modPaint.LightColor(oCaveColor, 0.3)
                                            Else
                                                oColor = modPaint.LightColor(oSegment.Data.SegmentColor, 0.3)
                                            End If
                                            If PaintOptions.CenterlineColorGray Then
                                                oColor = modPaint.GrayColor(oColor)
                                            End If

                                            Dim oToPoint As PointF = oSegment.Data.Plan.ToPoint
                                            Dim oFromPoint As PointF = oSegment.Data.Plan.FromPoint

                                            Dim oFromSplay As List(Of Plot.cSplayPlanProjectedData)
                                            If PaintOptions.ShowSplayMode = cOptionsCenterline.ShowSplayModeEnum.All Then
                                                oFromSplay = oSegment.Data.Plan.FromSplays.GetNotInRangeSplays
                                                If oFromSplay.Count > 0 Then
                                                    Call modPaint.PaintStationSplays(PaintOptions, oSegmentCache, oCurrentSegment, oSegment, oFromPoint, modPaint.LightColor(oColor, 0.85), oTranslationMatrix, "-L", "-R", oFromSplay)
                                                End If
                                            End If
                                            oFromSplay = oSegment.Data.Plan.FromSplays.GetInRangeSplays
                                            If oFromSplay.Count > 0 Then
                                                Call modPaint.PaintStationSplays(PaintOptions, oSegmentCache, oCurrentSegment, oSegment, oFromPoint, oColor, oTranslationMatrix, "-L", "-R", oFromSplay)
                                            End If

                                            Dim oToSplays As List(Of Plot.cSplayPlanProjectedData)
                                            If PaintOptions.ShowSplayMode = cOptionsCenterline.ShowSplayModeEnum.All Then
                                                oToSplays = oSegment.Data.Plan.ToSplays.GetNotInRangeSplays
                                                If oToSplays.Count > 0 Then
                                                    Call modPaint.PaintStationSplays(PaintOptions, oSegmentCache, oCurrentSegment, oSegment, oToPoint, modPaint.LightColor(oColor, 0.85), oTranslationMatrix, "-L", "-R", oToSplays)
                                                End If
                                            End If
                                            oToSplays = oSegment.Data.Plan.ToSplays.GetInRangeSplays
                                            If oToSplays.Count > 0 Then
                                                Call modPaint.PaintStationSplays(PaintOptions, oSegmentCache, oCurrentSegment, oSegment, oToPoint, oColor, oTranslationMatrix, "-L", "-R", oToSplays)
                                            End If
                                        End If

                                        'segmenti laterali, aree
                                        If PaintOptions.DrawPlot AndAlso PaintOptions.DrawLRUD Then
                                            Dim oColor As Color
                                            If oSegment.Data.SegmentColor = Color.Transparent Then
                                                oColor = modPaint.LightColor(oCaveColor, 0.3)
                                            Else
                                                oColor = modPaint.LightColor(oSegment.Data.SegmentColor, 0.3)
                                            End If
                                            If PaintOptions.CenterlineColorGray Then
                                                oColor = modPaint.GrayColor(oColor)
                                            End If

                                            If Not oColor = Color.White Then
                                                If PaintOptions.DrawStyle = cOptionsCenterline.DrawStyleEnum.OnlySegment Then
                                                    Using oAreaLine As GraphicsPath = modPlot.GetPlanAreaLine(oSegment)
                                                        If Not oAreaLine Is Nothing Then
                                                            oCacheItem = oSegmentCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                                            If oCurrentSegment Is oSegment Then
                                                                oDrawingObject.LRUDSelectedPen.Color = oColor
                                                                Call oCacheItem.SetPen(oDrawingObject.LRUDSelectedPen)
                                                                Call oCacheItem.AddPath(oAreaLine)
                                                            Else
                                                                oDrawingObject.LRUDPen.Color = oColor
                                                                Call oCacheItem.SetPen(oDrawingObject.LRUDPen)
                                                                Call oCacheItem.AddPath(oAreaLine)
                                                            End If
                                                            Call oCacheItem.Transform(oTranslationMatrix)
                                                        End If
                                                    End Using
                                                Else
                                                    Using oAreaPoly As GraphicsPath = modPlot.GetPlanAreaPolygon(oSegment)
                                                        If Not oAreaPoly Is Nothing Then
                                                            oCacheItem = oSegmentCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                                            If oCurrentSegment Is oSegment Then
                                                                If oDrawingObject.EnableBrushes Then
                                                                    If oDrawingObject.EnableTransparence Then
                                                                        oDrawingObject.LRUDSelectedBrush.Color = modPaint.TransparentColor(modPaint.LightColor(oColor, 0.5), oDrawingObject.DarkTransparentLevel)
                                                                    Else
                                                                        oDrawingObject.LRUDSelectedBrush.Color = modPaint.LightColor(oColor, 0.5)
                                                                    End If
                                                                    Call oCacheItem.SetBrush(oDrawingObject.LRUDSelectedBrush)
                                                                End If
                                                                oDrawingObject.LRUDSelectedPen.Color = oColor
                                                                Call oCacheItem.SetPen(oDrawingObject.LRUDSelectedPen)
                                                                Call oCacheItem.AddPath(oAreaPoly)
                                                            Else
                                                                If oDrawingObject.EnableBrushes Then
                                                                    If oDrawingObject.EnableTransparence Then
                                                                        oDrawingObject.LRUDBrush.Color = modPaint.TransparentColor(modPaint.LightColor(oColor, 0.8), oDrawingObject.LightTransparentLevel)
                                                                    Else
                                                                        oDrawingObject.LRUDBrush.Color = modPaint.LightColor(oColor, 0.8)
                                                                    End If
                                                                    Call oCacheItem.SetBrush(oDrawingObject.LRUDBrush)
                                                                End If
                                                                oDrawingObject.LRUDPen.Color = oColor
                                                                Call oCacheItem.SetPen(oDrawingObject.LRUDPen)
                                                                Call oCacheItem.AddPath(oAreaPoly)
                                                            End If
                                                            Call oCacheItem.Transform(oTranslationMatrix)
                                                        End If
                                                    End Using
                                                End If
                                            End If
                                        End If

                                        'segmenti
                                        With oSegment.Data
                                            If PaintOptions.DrawPlot AndAlso PaintOptions.DrawSegments Then
                                                Dim oColor As Color
                                                If oDrawingObject.CenterlineForceColor Then
                                                    If .SegmentColor = Color.Transparent Then
                                                        oColor = oDrawingObject.PenColor
                                                    Else
                                                        oColor = modPaint.LightColor(.SegmentColor, 0.3)
                                                    End If
                                                Else
                                                    If .SegmentColor = Color.Transparent Then
                                                        oColor = modPaint.DarkColor(oCaveColor, 0.2)
                                                    Else
                                                        oColor = modPaint.DarkColor(.SegmentColor, 0.2)
                                                    End If
                                                End If
                                                If PaintOptions.CenterlineColorGray Then
                                                    oColor = modPaint.GrayColor(oColor)
                                                End If

                                                oCacheItem = oSegmentCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                                If oCurrentSegment Is oSegment Then
                                                    oDrawingObject.SelectedPen.Color = oColor
                                                    Call oCacheItem.SetPen(oDrawingObject.SelectedPen)
                                                Else
                                                    oDrawingObject.Pen.Color = oColor
                                                    Call oCacheItem.SetPen(oDrawingObject.Pen)
                                                End If

                                                Call oCacheItem.AddLine(.Plan.FromPoint, .Plan.ToPoint)
                                                Call oCacheItem.Transform(oTranslationMatrix)

                                                If PaintOptions.DrawHighlights Then
                                                    If PaintOptions.HighlightsOptions.Get(Properties.cHighlightsDetails.RingKey) AndAlso oSegment.Data.IsInRing AndAlso oSurvey.Calculate.Rings.IsSegmentInSelectedRing(oSegment) Then
                                                        oCacheItem = oSegmentCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                                        oDrawingObject.SelectedRingPen.Color = oSurvey.Calculate.Rings.GetSegmentColor(oSegment, oDefaultRingColor)
                                                        oDrawingObject.SelectedRingPen.Width = sDefaultRingPenWidth
                                                        Call oCacheItem.SetPen(oDrawingObject.SelectedRingPen)
                                                        Call oCacheItem.AddLine(.Plan.FromPoint, .Plan.ToPoint)
                                                        Call oCacheItem.Transform(oTranslationMatrix)
                                                    End If
                                                    For Each sID As String In PaintOptions.HighlightsOptions
                                                        If oSurvey.Properties.HighlightsDetails.Contains(sID) Then
                                                            With oSurvey.Properties.HighlightsDetails(sID)
                                                                If .ApplyTo = Properties.cHighlightsDetail.ApplyToEnum.Shots Then
                                                                    Dim oMeters As Properties.cHighlightsDetailMeters = .GetMetres
                                                                    If .GetScript.Eval("GetHighlight", {New Properties.cShotHighlightDetails(oSurvey, oSegment, oMeters)}) Then
                                                                        Call modRender.RenderHighlightShot(Graphics, PaintOptions, oSegment.Data.Plan.FromPoint, oSegment.Data.Plan.ToPoint, oSegmentCache, oMeters)
                                                                    End If
                                                                End If
                                                            End With
                                                        End If
                                                    Next
                                                End If
                                            End If
                                            If PaintOptions.DrawPlot AndAlso PaintOptions.ShowPointInformation Then
                                                oCacheItem = oSegmentCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                                Dim oTrigPoint As cTrigPoint = oSegment.GetToTrigPoint
                                                Dim sInfo As String = .Data.From & " -> " & .Data.To & vbCrLf & ": " & modNumbers.MathRound(.Data.Distance, 2) & " " & cSegment.GetDistanceSimbol(oSegment.GetDistanceType) & "/" & modNumbers.MathRound(.Data.Inclination, 2) & " " & cSegment.GetInclinationSimbol(oSegment.GetInclinationType) & "/" & modNumbers.MathRound(.Data.Bearing, 2) & " " & cSegment.GetBearingSimbol(oSegment.GetBearingType) & vbCrLf & "Δ: " & modNumbers.MathRound(- .Profile.ToPoint.Y, 2) & " m" & vbCrLf & oTrigPoint.Note
                                                Call oCacheItem.SetBrush(oDrawingObject.InfoBrush)
                                                Call oCacheItem.AddString(sInfo, oDrawingObject.InfoFont, New PointF(.Plan.ToPoint.X + oDrawingObject.InfoFont.Height * (oTrigPoint.LabelDistance / 10) / 5, .Plan.ToPoint.Y + oDrawingObject.InfoFont.Height * (oTrigPoint.LabelDistance / 10) / 5))
                                                Call oCacheItem.Transform(oTranslationMatrix)
                                            End If
                                        End With
                                    End Using
                                    .Rendered()
                                End With
                            End If
                            'linee di riporto (traslazioni)
                            If Not PaintOptions.IsDesign AndAlso PaintOptions.DrawTranslation Then
                                With oSegment.Data
                                    Dim oTranslation As SizeF = modPlot.GetPlanSegmentTranslation(oSurvey, oSegment)
                                    If oTranslation.IsEmpty Then
                                        Call oTranslationTrigPoints.Add(.Data.From, .Plan.FromPoint)
                                        Call oTranslationTrigPoints.Add(.Data.To, .Plan.ToPoint)
                                    Else
                                        Call oTranslationTrigPoints.Add(.Data.From, PointF.Add(.Plan.FromPoint, oTranslation))
                                        Call oTranslationTrigPoints.Add(.Data.To, PointF.Add(.Plan.ToPoint, oTranslation))
                                    End If
                                End With
                            Else
                                With oSegment.Data
                                    Call oTranslationTrigPoints.Add(.Data.From, .Plan.FromPoint)
                                    Call oTranslationTrigPoints.Add(.Data.To, .Plan.ToPoint)
                                End With
                            End If
                        End If
                    End If
                Next

                Dim sTTH As Single = PaintOptions.TranslationsOptions.TranslationsThreshold
                Dim oDrawedTrigPoint As List(Of String) = New List(Of String)
                Dim oLabelInSamePosition As Dictionary(Of PointF, cValue(Of Integer)) = New Dictionary(Of PointF, cValue(Of Integer))

                For Each oSegment As cSegment In oVisibleSegments
                    If Not oSegment.Splay Then
                        If modDesign.GetIfSegmentMustBeDrawedByCaveAndBranch(PaintOptions, oSegment, Selection.CurrentCave, Selection.CurrentBranch) Then
                            Dim oTranslationTrigpointsToDraw As List(Of cTranslatedTrigPoint) = New List(Of cTranslatedTrigPoint)
                            If oTranslationTrigPoints.Contains(oSegment.From) Then Call oTranslationTrigpointsToDraw.Add(oTranslationTrigPoints(oSegment.From))
                            If oTranslationTrigPoints.Contains(oSegment.To) Then Call oTranslationTrigpointsToDraw.Add(oTranslationTrigPoints(oSegment.To))
                            For Each oTranslationTrigPoint As cTranslatedTrigPoint In oTranslationTrigpointsToDraw
                                If Not oDrawedTrigPoint.Contains(oTranslationTrigPoint.Name) Then
                                    If oSurvey.TrigPoints.Contains(oTranslationTrigPoint.Name) Then
                                        Dim oTrigPoint As cTrigPoint = oSurvey.TrigPoints(oTranslationTrigPoint.Name)
                                        If ((PaintOptions.IsDesign AndAlso Not oTrigPoint.HiddenInDesign) OrElse ((PaintOptions.IsPreview OrElse PaintOptions.IsViewer) AndAlso Not oTrigPoint.HiddenInPreview)) Then
                                            Dim oTrigpointCache As cDrawCache = pGetOrCreateTrigpointFromCache(oTrigPoint, PaintOptions)
                                            If oTrigpointCache.Invalidated Then
                                                With oTrigpointCache
                                                    'linee di traslazione
                                                    If Not PaintOptions.IsDesign AndAlso PaintOptions.DrawTranslation AndAlso PaintOptions.TranslationsOptions.DrawTranslationsLine AndAlso oTranslationTrigPoint.Count > 1 AndAlso oTrigPoint.DrawTranslationsLine Then
                                                        Dim oFromPoint As PointF = oTranslationTrigPoint(0)
                                                        Dim i As Integer = 1
                                                        Do While i < oTranslationTrigPoint.Count
                                                            oCacheItem = .Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                                            Dim oToPoint As PointF = oTranslationTrigPoint(i)
                                                            If (sTTH = 0 OrElse modPaint.DistancePointToPoint(oToPoint, oFromPoint) > sTTH) Then
                                                                If (oToPoint.X <> oFromPoint.X) AndAlso (oToPoint.Y <> oFromPoint.Y) Then
                                                                    Dim oMidPoint As PointF = New PointF(oFromPoint.X, oToPoint.Y)
                                                                    Call oCacheItem.SetPen(oDrawingObject.TranslationPen)
                                                                    Call oCacheItem.AddLine(oFromPoint, oMidPoint)
                                                                    Call oCacheItem.AddLine(oMidPoint, oToPoint)
                                                                Else
                                                                    Call oCacheItem.SetPen(oDrawingObject.TranslationPen)
                                                                    Call oCacheItem.AddLine(oFromPoint, oToPoint)
                                                                End If
                                                                i += 1
                                                            Else
                                                                Call oTranslationTrigPoint.Remove(oToPoint)
                                                            End If
                                                        Loop
                                                    End If

                                                    For Each oPoint As PointF In oTranslationTrigPoint
                                                        If oTrigPoint.IsEntrance Then
                                                            Call RenderEntrancePoint(Graphics, PaintOptions, oPoint, oTrigpointCache, oTrigPoint.ShowEntrance)
                                                        End If
                                                        If PaintOptions.DrawHighlights Then
                                                            For Each sID As String In PaintOptions.HighlightsOptions
                                                                If oSurvey.Properties.HighlightsDetails.Contains(sID) Then
                                                                    With oSurvey.Properties.HighlightsDetails(sID)
                                                                        If .ApplyTo = Properties.cHighlightsDetail.ApplyToEnum.Stations Then
                                                                            Dim oMeters As Properties.cHighlightsDetailMeters = .GetMetres
                                                                            If .GetScript.Eval("GetHighlight", {New Properties.cStationHighlightDetails(oSurvey, oTrigPoint, oMeters)}) Then
                                                                                Call modRender.RenderHighlightStation(Graphics, PaintOptions, oPoint, oTrigpointCache, oMeters)
                                                                            End If
                                                                        End If
                                                                    End With
                                                                End If
                                                            Next
                                                        End If

                                                        'point and point name
                                                        If pCheckLabelInSamePosition(oLabelInSamePosition, oPoint) Then
                                                            If (oTranslationTrigPoint.Count > 1 AndAlso PaintOptions.DrawTranslation AndAlso oTrigPoint.DrawTranslationsLine) OrElse (PaintOptions.DrawPlot AndAlso PaintOptions.DrawPoints) OrElse (PaintOptions.DrawDesign AndAlso PaintOptions.DrawSpecialPoints AndAlso oTrigPoint.IsSpecial) Then
                                                                If oTrigPoint Is oCurrentTrigpoint Then
                                                                    Call RenderTrigPoint(Graphics, PaintOptions, oTrigPoint, oPoint, oDrawingObject.SelectedPointSize, oDrawingObject.SelectedPointBrush, oDrawingObject.SelectedPointPen, oTrigpointCache)
                                                                Else
                                                                    Call RenderTrigPoint(Graphics, PaintOptions, oTrigPoint, oPoint, oDrawingObject.PointSize, oDrawingObject.PointBrush, oDrawingObject.PointPen, oTrigpointCache)
                                                                End If
                                                            End If
                                                            If PaintOptions.ShowPointText Then
                                                                If (PaintOptions.DrawPlot) OrElse (PaintOptions.DrawDesign AndAlso PaintOptions.DrawSpecialPoints AndAlso oTrigPoint.IsSpecial) Then
                                                                    Call RenderTrigPointName(Graphics, PaintOptions, oTrigPoint, oPoint, oTrigpointCache)
                                                                End If
                                                            End If
                                                        End If
                                                    Next
                                                    Call oDrawedTrigPoint.Add(oTranslationTrigPoint.Name)
                                                    .Rendered()
                                                End With
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
            End If
        End Sub

        Private Function pCheckLabelInSamePosition(LabelInSamePosition As Dictionary(Of PointF, cValue(Of Integer)), Point As PointF) As Boolean
            If LabelInSamePosition.ContainsKey(Point) Then
                LabelInSamePosition(Point).Value += 1
            Else
                Call LabelInSamePosition.Add(Point, New cValue(Of Integer)(1))
            End If
            Return LabelInSamePosition(Point).Value < 5
        End Function

        Friend Overrides Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
            Dim oSVGGroup As XmlElement = modSVG.CreateLayer(SVG, "plot", "plot")
            For Each oCaches As cDrawCaches In oSegmentsCaches.Values
                Call modSVG.AppendItem(SVG, oSVGGroup, oCaches(PaintOptions).ToSvgItem(SVG, PaintOptions, Options))
            Next
            For Each oCaches As cDrawCaches In oTrigpointsCaches.Values
                Call modSVG.AppendItem(SVG, oSVGGroup, oCaches(PaintOptions).ToSvgItem(SVG, PaintOptions, Options))
            Next
            'Call modSVG.AppendItem(SVG, oSVGGroup, MyBase.Caches(PaintOptions).ToSvgItem(SVG, PaintOptions, Options))
            Return oSVGGroup
        End Function

        'Friend Overrides Function ToSvg(ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum, Size As SizeF, PageBox As RectangleF, ByVal ViewBox As RectangleF) As XmlDocument
        '    Dim oSVG As XmlDocument = modSVG.CreateSVG
        '    Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions, Options, Size, ViewBox))
        '    Return oSVG
        'End Function

        Friend Overrides Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, Selection As Helper.Editor.cIEditSelection)
            If Not PaintOptions.IsDesign Then
                PaintOptions.HighlightCurrentCave = False
                PaintOptions.HighlightMode = cOptionsCenterline.HighlightModeEnum.Default
            End If
            Call Render(Graphics, PaintOptions, Selection)
            For Each oCaches As cDrawCaches In oSegmentsCaches.Values
                oCaches(PaintOptions).Paint(Graphics, PaintOptions, cItem.PaintOptionsEnum.None)
            Next
            For Each oCaches As cDrawCaches In oTrigpointsCaches.Values
                oCaches(PaintOptions).Paint(Graphics, PaintOptions, cItem.PaintOptionsEnum.None)
            Next
            'Call MyBase.Caches(PaintOptions).Paint(Graphics, PaintOptions, cItem.PaintOptionsEnum.None)
        End Sub

        Friend Overrides Sub ResetChanges()
            Threading.Tasks.Parallel.ForEach(Of cISegment)(oSurvey.Segments.Where(Function(oSegment) oSegment.Data.Plan.Changed), Sub(oSegment)
                                                                                                                                      Call oSegment.Data.Plan.ResetChange()
                                                                                                                                  End Sub)
        End Sub

        Friend Overrides Sub CalculateSplay()
            'Dim oCalculatedSplaySegment As List(Of cISegment) = New List(Of cISegment)
            Dim oSplaySegments As List(Of cISegment) = New List(Of cISegment)(oSurvey.Segments.GetSplaySegments())

            For Each oSegment As cSegment In oSurvey.Segments
                If oSegment.IsValid AndAlso Not oSegment.IsSelfDefined AndAlso Not oSegment.Splay Then
                    With oSegment.Data.Plan
                        Dim sFrom As String = .From
                        Dim sTo As String = .To
                        Dim oFromPoint As PointD = .FromPoint
                        Dim oToPoint As PointD = .ToPoint

                        '------------------------------------------------------------------------------------------------------------------------------------------------------
                        'imposto i dati dei segmenti splay...
                        'ATTENZIONE: gli splay vengono comunque calcolati come segmenti normali in quanto i dati di calcolo standard servono per poi fare il calcolo come splay
                        'splay
                        Dim oSplayToPoint As PointF
                        Dim oSplayFromPoint As PointF
                        Dim sSplayTo As String
                        Dim sSplayFrom As String
                        If oSegment.Data.Data.Reversed Then
                            oSplayToPoint = oFromPoint
                            sSplayTo = sFrom
                            oSplayFromPoint = oToPoint
                            sSplayFrom = sTo
                        Else
                            oSplayToPoint = oToPoint
                            sSplayTo = sTo
                            oSplayFromPoint = oFromPoint
                            sSplayFrom = sFrom
                        End If

                        Dim iType As cIItemPlanSplayBorder.PlanSplayBorderProjectionTypeEnum = oSegment.PlanSplayBorderProjectionType
                        Dim sPlaneZ As Single = 0
                        Dim sPlaneMinZ As Single
                        Dim sPlaneMaxZ As Single
                        Select Case iType
                            Case cIItemPlanSplayBorder.PlanSplayBorderProjectionTypeEnum.ToAltitude
                                sPlaneZ = oSegment.PlanSplayBorderProjectionDeltaZ * -1
                                sPlaneMinZ = sPlaneZ - oSegment.PlanSplayBorderMaxDeltaVariation
                                sPlaneMaxZ = sPlaneZ + oSegment.PlanSplayBorderMaxDeltaVariation
                            Case cIItemPlanSplayBorder.PlanSplayBorderProjectionTypeEnum.ToCenterOfSegment
                                sPlaneZ = oSegment.PlanSplayBorderProjectionDeltaZ * -1 + oSegment.Data.Profile.ToPoint.Y + (oSegment.Data.Profile.FromPoint.Y - oSegment.Data.Profile.ToPoint.Y) / 2
                                sPlaneMinZ = sPlaneZ - oSegment.PlanSplayBorderMaxDeltaVariation
                                sPlaneMaxZ = sPlaneZ + oSegment.PlanSplayBorderMaxDeltaVariation
                        End Select

                        'FROM
                        Call .FromSplays.Clear()
                        'Dim oSplaySegments As List(Of cISegment) = New List(Of cISegment)
                        'Call oSplaySegments.AddRange(oSurvey.Segments.GetSplaySegments(sSplayFrom).ToArray)
                        Dim oFromSplaySegment As List(Of cISegment) = oSplaySegments.Where(Function(segment) segment.From = sFrom OrElse segment.To = sFrom).ToList
                        'If oSplaySegments.Count > 0 Then
                        If oFromSplaySegment.Count > 0 Then
                            If iType = cIItemPlanSplayBorder.PlanSplayBorderProjectionTypeEnum.All Then
                                For Each oSplaySegment As cISegment In oFromSplaySegment
                                    Dim bInRange As Boolean = oSegment.PlanSplayBorderInclinationRange.IsEmpty OrElse (oSplaySegment.Data.Data.Inclination >= oSegment.PlanSplayBorderInclinationRange.Width AndAlso oSplaySegment.Data.Data.Inclination <= oSegment.PlanSplayBorderInclinationRange.Height)
                                    Dim oCurrentPoint As PointD = oSplaySegment.Data.Plan.ToPoint
                                    Dim oLeftPoint As PointD = oSplaySegment.Data.Plan.ToSidePointLeft
                                    Dim oRightPoint As PointD = oSplaySegment.Data.Plan.ToSidePointRight
                                    Call .FromSplays.Add(oSplaySegment, oCurrentPoint, oLeftPoint, oRightPoint, bInRange)
                                    'Call oSplaySegments.Remove(oSplaySegment)
                                Next
                            Else
                                For Each oSplaySegment As cISegment In oFromSplaySegment
                                    'If oSegment.PlanSplayBorderInclinationRange.IsEmpty OrElse (oSplaySegment.Data.Data.Inclination >= oSegment.PlanSplayBorderInclinationRange.Width AndAlso oSplaySegment.Data.Data.Inclination <= oSegment.PlanSplayBorderInclinationRange.Height) Then
                                    Dim bInRange As Boolean = oSegment.PlanSplayBorderInclinationRange.IsEmpty OrElse (oSplaySegment.Data.Data.Inclination >= oSegment.PlanSplayBorderInclinationRange.Width AndAlso oSplaySegment.Data.Data.Inclination <= oSegment.PlanSplayBorderInclinationRange.Height)
                                    bInRange = bInRange And (oSplaySegment.Data.Profile.ToPoint.Y >= sPlaneMinZ AndAlso oSplaySegment.Data.Profile.ToPoint.Y <= sPlaneMaxZ)
                                    Dim oCurrentPoint As PointD = oSplaySegment.Data.Plan.ToPoint
                                    Dim oLeftPoint As PointD = oSplaySegment.Data.Plan.ToSidePointLeft
                                    Dim oRightPoint As PointD = oSplaySegment.Data.Plan.ToSidePointRight
                                    Call .FromSplays.Add(oSplaySegment, oCurrentPoint, oLeftPoint, oRightPoint, bInRange)
                                    'End If
                                    'Call oSplaySegments.Remove(oSplaySegment)
                                Next
                            End If
                        End If
                        'Call oSplaySegments.Clear()

                        'TO
                        Call .ToSplays.Clear()
                        Dim oToSplaySegment As List(Of cISegment) = oSplaySegments.Where(Function(segment) segment.From = sTo OrElse segment.To = sTo).ToList
                        'Call oSplaySegments.AddRange(oSurvey.Segments.GetSplaySegments(sSplayTo).ToArray)
                        If oToSplaySegment.Count > 0 Then
                            If iType = cIItemPlanSplayBorder.PlanSplayBorderProjectionTypeEnum.All Then
                                For Each oSplaySegment As cISegment In oToSplaySegment
                                    Dim bInRange As Boolean = oSegment.PlanSplayBorderInclinationRange.IsEmpty OrElse (oSplaySegment.Data.Data.Inclination >= oSegment.PlanSplayBorderInclinationRange.Width AndAlso oSplaySegment.Data.Data.Inclination <= oSegment.PlanSplayBorderInclinationRange.Height)
                                    Dim oCurrentPoint As PointD = oSplaySegment.Data.Plan.ToPoint
                                    Dim oLeftPoint As PointD = oSplaySegment.Data.Plan.ToSidePointLeft
                                    Dim oRigthPoint As PointD = oSplaySegment.Data.Plan.ToSidePointRight
                                    Call .ToSplays.Add(oSplaySegment, oCurrentPoint, oLeftPoint, oRigthPoint, bInRange)
                                    'Call oSplaySegments.Remove(oSplaySegment)
                                Next
                            Else
                                For Each oSplaySegment As cISegment In oToSplaySegment
                                    'If oSegment.PlanSplayBorderInclinationRange.IsEmpty OrElse (oSplaySegment.Data.Data.Inclination >= oSegment.PlanSplayBorderInclinationRange.Width AndAlso oSplaySegment.Data.Data.Inclination <= oSegment.PlanSplayBorderInclinationRange.Height) Then
                                    Dim bInRange As Boolean = oSegment.PlanSplayBorderInclinationRange.IsEmpty OrElse (oSplaySegment.Data.Data.Inclination >= oSegment.PlanSplayBorderInclinationRange.Width AndAlso oSplaySegment.Data.Data.Inclination <= oSegment.PlanSplayBorderInclinationRange.Height)
                                    bInRange = bInRange And (oSplaySegment.Data.Profile.ToPoint.Y >= sPlaneMinZ AndAlso oSplaySegment.Data.Profile.ToPoint.Y <= sPlaneMaxZ)
                                    Dim oCurrentPoint As PointD = oSplaySegment.Data.Plan.ToPoint
                                    Dim oLeftPoint As PointD = oSplaySegment.Data.Plan.ToSidePointLeft
                                    Dim oRigthPoint As PointD = oSplaySegment.Data.Plan.ToSidePointRight
                                    Call .ToSplays.Add(oSplaySegment, oCurrentPoint, oLeftPoint, oRigthPoint, bInRange)
                                    'End If
                                    'Call oSplaySegments.Remove(oSplaySegment)
                                Next
                            End If
                            'Call oCalculatedSplaySegment.AddRange(oUncalculatedSplaySegment)
                        End If
                        '------------------------------------------------------------------------------------------------------------------------------------------------------
                    End With
                End If
            Next
        End Sub

        Private Function pGetRelativeSegmentBearing(PointCache As Dictionary(Of String, cPointCacheItem), SegmentList As IEnumerable(Of cISegment), Segment As cSegment, Station As String, PrevOrNext As Boolean) As Decimal
            If Segment.Splay Then
                Dim oFromPoint As PointD = Segment.Data.Plan.FromPoint
                Dim oToPoint As PointD = Segment.Data.Plan.ToPoint
                If Math.Abs(Segment.Data.Data.Inclination) > 89.9 Then
                    Return Segment.GetBaseBearing '<---controllare!!!!
                Else
                    Return modPaint.GetBearing(oFromPoint, oToPoint)
                End If
            Else
                Dim oConnectedSegment As IEnumerable(Of cISegment) = SegmentList.Where(Function(item) Not item.IsSelfDefined AndAlso Not item.Splay AndAlso (item.To = Station OrElse item.From = Station))
                Dim oRelativeSegment As cSegment
                If PrevOrNext Then
                    oRelativeSegment = oConnectedSegment.FirstOrDefault(Function(item) item.From = Station)
                    If oRelativeSegment Is Nothing Then
                        oRelativeSegment = oConnectedSegment.FirstOrDefault(Function(item) item.To = Station)
                    End If
                Else
                    oRelativeSegment = oConnectedSegment.FirstOrDefault(Function(item) item.To = Station)
                    If oRelativeSegment Is Nothing Then
                        oRelativeSegment = oConnectedSegment.FirstOrDefault(Function(item) item.From = Station)
                    End If
                End If
                If Not oRelativeSegment Is Nothing Then
                    Dim oFromPoint As PointD = PointCache(oRelativeSegment.Data.Data.From).Point
                    Dim oToPoint As PointD = PointCache(oRelativeSegment.Data.Data.To).Point
                    If Math.Abs(oRelativeSegment.Data.Data.Inclination) > 89.9 Then
                        Return oRelativeSegment.GetBaseBearing '<---controllare!!!!
                    Else
                        If oRelativeSegment.Data.Data.Reversed Then
                            Return modPaint.GetBearing(oToPoint, oFromPoint)
                        Else
                            Return modPaint.GetBearing(oFromPoint, oToPoint)
                        End If
                    End If
                End If
            End If
        End Function

        Friend Overrides Sub Calculate(ByVal SegmentsColl As List(Of cSegment), Optional ByVal PerformWarping As Boolean = True)
            Dim oPointCache As Dictionary(Of String, cPointCacheItem) = New Dictionary(Of String, cPointCacheItem)
            For Each oSegment As cSegment In SegmentsColl
                If oSegment.IsValid Then
                    Dim iSideMeasureType As cSegment.SideMeasuresTypeEnum
                    Dim iSideMeasureReferTo As cSegment.SideMeasuresReferToEnum

                    If oSegment.Splay Then
                        'splay are always managed with LRUD at end station and perpedicular to shot
                        iSideMeasureType = cSegment.SideMeasuresTypeEnum.PerpendicularToPrevious
                        iSideMeasureReferTo = cSegment.SideMeasuresReferToEnum.EndPoint
                    Else
                        iSideMeasureType = oSegment.GetSideMeasuresType
                        iSideMeasureReferTo = oSegment.GetSideMeasuresReferTo
                    End If

                    If iSideMeasureReferTo = cSegment.SideMeasuresReferToEnum.StartPoint Then
                        'LRUD at start station
                        Dim sFrom As String
                        Dim sTo As String
                        If oSegment.Data.Data.Reversed Then
                            sFrom = oSegment.Data.Data.To
                            sTo = oSegment.Data.Data.From
                        Else
                            sFrom = oSegment.Data.Data.From
                            sTo = oSegment.Data.Data.To
                        End If

                        If Not oPointCache.ContainsKey(sFrom) Then
                            Dim oPoint As PointD = oSurvey.Calculate.TrigPoints(sFrom).Point.To2DPoint(cTrigPointPoint.ProjectionEnum.FromTop)
                            Dim oPointCacheItem As cPointCacheItem = New cPointCacheItem(oPoint)
                            Call oPointCache.Add(sFrom, oPointCacheItem)
                        End If

                        'for other station put a placeholder in collection....
                        If Not oPointCache.ContainsKey(sTo) Then
                            Dim oPoint As PointD = oSurvey.Calculate.TrigPoints(sTo).Point.To2DPoint(cTrigPointPoint.ProjectionEnum.FromTop)
                            Dim oPointCacheItem As cPointCacheItem = New cPointCacheItem(oPoint)
                            Call oPointCache.Add(sTo, oPointCacheItem)
                        End If
                    Else
                        'LRUD at end station
                        Dim sFrom As String
                        Dim sTo As String
                        If oSegment.Data.Data.Reversed Then
                            sFrom = oSegment.Data.Data.To
                            sTo = oSegment.Data.Data.From
                        Else
                            sFrom = oSegment.Data.Data.From
                            sTo = oSegment.Data.Data.To
                        End If
                        If Not oPointCache.ContainsKey(sTo) Then
                            Dim oPoint As PointD = oSurvey.Calculate.TrigPoints(sTo).Point.To2DPoint(cTrigPointPoint.ProjectionEnum.FromTop)
                            Dim oPointCacheItem As cPointCacheItem = New cPointCacheItem(oPoint)
                            Call oPointCache.Add(sTo, oPointCacheItem)
                        End If

                        'for other station put a placeholder in collection....
                        If Not oPointCache.ContainsKey(sFrom) Then
                            Dim oPoint As PointD = oSurvey.Calculate.TrigPoints(sFrom).Point.To2DPoint(cTrigPointPoint.ProjectionEnum.FromTop)
                            Dim oPointCacheItem As cPointCacheItem = New cPointCacheItem(oPoint)
                            Call oPointCache.Add(sFrom, oPointCacheItem)
                        End If
                    End If
                End If
            Next

            'set topoint and frompoint to shots
            Threading.Tasks.Parallel.ForEach(Of cSurveyPC.cSurvey.cSegment)(SegmentsColl, Sub(oSegment)
                                                                                              If oSegment.IsValid AndAlso Not oSegment.IsSelfDefined Then
                                                                                                  Dim sFrom As String = oSegment.Data.Data.From
                                                                                                  Dim sTo As String = oSegment.Data.Data.To
                                                                                                  Dim oFromPointCacheitem As cPointCacheItem = oPointCache(oSegment.Data.Data.From)
                                                                                                  Dim oToPointCacheitem As cPointCacheItem = oPointCache(oSegment.Data.Data.To)
                                                                                                  Dim oFromPoint As PointD = oFromPointCacheitem.Point
                                                                                                  Dim oToPoint As PointD = oToPointCacheitem.Point
                                                                                                  Call oSegment.Data.Plan.SetPoints(sFrom, sTo, oFromPoint, oToPoint)
                                                                                              End If
                                                                                          End Sub)
            'For Each oSegment As cSegment In SegmentsColl
            '    If oSegment.IsValid AndAlso Not oSegment.IsSelfDefined Then
            '        Dim sFrom As String = oSegment.Data.Data.From
            '        Dim sTo As String = oSegment.Data.Data.To
            '        Dim oFromPointCacheitem As cPointCacheItem = oPointCache(oSegment.Data.Data.From)
            '        Dim oToPointCacheitem As cPointCacheItem = oPointCache(oSegment.Data.Data.To)
            '        Dim oFromPoint As PointD = oFromPointCacheitem.Point
            '        Dim oToPoint As PointD = oToPointCacheitem.Point
            '        Call oSegment.Data.Plan.SetPoints(sFrom, sTo, oFromPoint, oToPoint)
            '    End If
            'Next

            'repeat the loop calculating sidepoints
            For Each oSegment As cSegment In SegmentsColl
                If oSegment.IsValid Then
                    Dim iSideMeasureType As cSegment.SideMeasuresTypeEnum
                    Dim iSideMeasureReferTo As cSegment.SideMeasuresReferToEnum

                    If oSegment.Splay Then
                        'splay are always managed with LRUD at end station and perpedicular to shot
                        iSideMeasureType = cSegment.SideMeasuresTypeEnum.PerpendicularToPrevious
                        iSideMeasureReferTo = cSegment.SideMeasuresReferToEnum.EndPoint
                    Else
                        iSideMeasureType = oSegment.GetSideMeasuresType
                        iSideMeasureReferTo = oSegment.GetSideMeasuresReferTo
                    End If

                    If iSideMeasureReferTo = cSegment.SideMeasuresReferToEnum.StartPoint Then
                        'LRUD at start station
                        Dim sFrom As String
                        Dim sTo As String
                        If oSegment.Data.Data.Reversed Then
                            sFrom = oSegment.Data.Data.To
                            sTo = oSegment.Data.Data.From
                        Else
                            sFrom = oSegment.Data.Data.From
                            sTo = oSegment.Data.Data.To
                        End If
                        Dim oLeftRight As SizeD = oSurvey.Calculate.TrigPoints(sFrom).SideMeasure.GetLeftRight(sTo)
                        Dim [sSx] As Decimal = oLeftRight.Width
                        Dim [sDx] As Decimal = oLeftRight.Height
                        Dim dBearing As Decimal

                        Dim oPoint As PointD = oPointCache(sFrom).Point  'oSurvey.Calculate.TrigPoints(sFrom).Point.To2DPoint(cTrigPointPoint.ProjectionEnum.FromTop)

                        Select Case iSideMeasureType
                            Case cSegment.SideMeasuresTypeEnum.Bisection
                                Dim dNextSegmentBearing As Decimal = pGetRelativeSegmentBearing(oPointCache, SegmentsColl, oSegment, sFrom, True)
                                Dim dPrevSegmentBearing As Decimal = pGetRelativeSegmentBearing(oPointCache, SegmentsColl, oSegment, sFrom, False)
                                If dPrevSegmentBearing <> dNextSegmentBearing Then
                                    dBearing = modPaint.NormalizeAngle(modPaint.GetNormalizedBisection(dPrevSegmentBearing, dNextSegmentBearing))
                                Else
                                    dBearing = modPaint.NormalizeAngle(dNextSegmentBearing - 90)
                                End If
                            Case cSegment.SideMeasuresTypeEnum.PerpendicularToNext
                                dBearing = modPaint.NormalizeAngle(pGetRelativeSegmentBearing(oPointCache, SegmentsColl, oSegment, sFrom, True) - 90)
                            Case cSegment.SideMeasuresTypeEnum.PerpendicularToPrevious
                                dBearing = modPaint.NormalizeAngle(pGetRelativeSegmentBearing(oPointCache, SegmentsColl, oSegment, sFrom, False) - 90)
                        End Select

                        Dim oSidePointRight As PointD
                        Dim oSidePointLeft As PointD

                        Dim dBearingLeft As Decimal = dBearing ' modPaint.AddAngle(dBearing, -90)
                        Dim oDiff As SizeD
                        If sSx = 0 Then
                            oSidePointLeft = oPoint
                        Else
                            oDiff = modPaint.Trigo(sSx, dBearingLeft)
                            oSidePointLeft = New PointD(oPoint.X + oDiff.Width, oPoint.Y + oDiff.Height)
                        End If

                        Dim dBearingRight As Decimal = modPaint.NormalizeAngle(dBearing + 180) ' modPaint.AddAngle(dBearing, +90)
                        If sDx = 0 Then
                            oSidePointRight = oPoint
                        Else
                            oDiff = modPaint.Trigo(sDx, dBearingRight)
                            oSidePointRight = New PointD(oPoint.X + oDiff.Width, oPoint.Y + oDiff.Height)
                        End If

                        Dim bUpdate As Boolean
                        If Not oPointCache.ContainsKey(sFrom) Then
                            bUpdate = True
                        Else
                            bUpdate = (Not oPointCache(sFrom).HaveValidLR) 'AndAlso (oPoint <> oSidePointRight OrElse oPoint <> oSidePointLeft)
                            If bUpdate Then
                                oPointCache.Remove(sFrom)
                            End If
                        End If
                        If bUpdate Then
                            Dim oPointCacheItem As cPointCacheItem = New cPointCacheItem
                            oPointCacheItem.Point = oPoint
                            oPointCacheItem.LeftPoint = oSidePointLeft
                            oPointCacheItem.LeftBearing = dBearingLeft
                            oPointCacheItem.RightPoint = oSidePointRight
                            oPointCacheItem.RightBearing = dBearingRight
                            Call oPointCache.Add(sFrom, oPointCacheItem)
                        End If

                        'for other station put a placeholder in collection....
                        If Not oPointCache.ContainsKey(sTo) Then
                            bUpdate = True
                        Else
                            bUpdate = (Not oPointCache(sTo).HaveValidLR) 'AndAlso (oPoint <> oSidePointRight OrElse oPoint <> oSidePointLeft)
                            If bUpdate Then
                                oPointCache.Remove(sTo)
                            End If
                        End If
                        If bUpdate Then 'If Not oPointCache.ContainsKey(sTo) Then
                            oPoint = oSurvey.Calculate.TrigPoints(sTo).Point.To2DPoint(cTrigPointPoint.ProjectionEnum.FromTop)
                            'simple LR direction...
                            dBearing = oSegment.Data.Data.Bearing - 90

                            Dim oPointCacheItem As cPointCacheItem = New cPointCacheItem
                            oPointCacheItem.Point = oPoint
                            oPointCacheItem.LeftPoint = oPoint
                            oPointCacheItem.LeftBearing = dBearing
                            oPointCacheItem.RightPoint = oPoint
                            oPointCacheItem.RightBearing = modPaint.NormalizeAngle(dBearing + 180)
                            Call oPointCache.Add(sTo, oPointCacheItem)
                        End If
                    Else
                        'LRUD at end station
                        Dim sFrom As String
                        Dim sTo As String
                        If oSegment.Data.Data.Reversed Then
                            sFrom = oSegment.Data.Data.To
                            sTo = oSegment.Data.Data.From
                        Else
                            sFrom = oSegment.Data.Data.From
                            sTo = oSegment.Data.Data.To
                        End If
                        Dim oLeftRight As SizeD = oSurvey.Calculate.TrigPoints(sTo).SideMeasure.GetLeftRight(sFrom)
                        Dim [sSx] As Decimal = oLeftRight.Width
                        Dim [sDx] As Decimal = oLeftRight.Height
                        Dim dBearing As Decimal

                        Dim oPoint As PointD = oPointCache(sTo).Point  'oSurvey.Calculate.TrigPoints(sTo).Point.To2DPoint(cTrigPointPoint.ProjectionEnum.FromTop)

                        Select Case iSideMeasureType
                            Case cSegment.SideMeasuresTypeEnum.Bisection
                                Dim dNextSegmentBearing As Decimal = pGetRelativeSegmentBearing(oPointCache, SegmentsColl, oSegment, sTo, True)
                                Dim dPrevSegmentBearing As Decimal = pGetRelativeSegmentBearing(oPointCache, SegmentsColl, oSegment, sTo, False)
                                If dPrevSegmentBearing <> dNextSegmentBearing Then
                                    dBearing = modPaint.NormalizeAngle(modPaint.GetNormalizedBisection(dPrevSegmentBearing, dNextSegmentBearing))
                                Else
                                    dBearing = modPaint.NormalizeAngle(dPrevSegmentBearing - 90)
                                End If
                            Case cSegment.SideMeasuresTypeEnum.PerpendicularToNext
                                dBearing = modPaint.NormalizeAngle(pGetRelativeSegmentBearing(oPointCache, SegmentsColl, oSegment, sTo, True) - 90)
                            Case cSegment.SideMeasuresTypeEnum.PerpendicularToPrevious
                                dBearing = modPaint.NormalizeAngle(pGetRelativeSegmentBearing(oPointCache, SegmentsColl, oSegment, sTo, False) - 90)
                        End Select

                        Dim oSidePointRight As PointD
                        Dim oSidePointLeft As PointD
                        Dim oDiff As SizeD

                        Dim dBearingLeft As Decimal = dBearing ' modPaint.AddAngle(dBearing, -90)
                        If sSx = 0 Then
                            oSidePointLeft = oPoint
                        Else
                            oDiff = modPaint.Trigo(sSx, dBearingLeft)
                            oSidePointLeft = New PointD(oPoint.X + oDiff.Width, oPoint.Y + oDiff.Height)
                        End If

                        Dim dBearingRight As Decimal = dBearing + 180 ' modPaint.AddAngle(dBearing, +90)
                        If sDx = 0 Then
                            oSidePointRight = oPoint
                        Else
                            oDiff = modPaint.Trigo(sDx, dBearingRight)
                            oSidePointRight = New PointD(oPoint.X + oDiff.Width, oPoint.Y + oDiff.Height)
                        End If

                        Dim bUpdate As Boolean
                        If Not oPointCache.ContainsKey(sTo) Then
                            bUpdate = True
                        Else
                            bUpdate = (Not oPointCache(sTo).HaveValidLR) 'AndAlso (oPoint <> oSidePointRight OrElse oPoint <> oSidePointLeft)
                            If bUpdate Then
                                oPointCache.Remove(sTo)
                            End If
                        End If
                        If bUpdate Then
                            Dim oPointCacheItem As cPointCacheItem = New cPointCacheItem
                            oPointCacheItem.Point = oPoint
                            oPointCacheItem.LeftPoint = oSidePointLeft
                            oPointCacheItem.LeftBearing = dBearingLeft
                            oPointCacheItem.RightPoint = oSidePointRight
                            oPointCacheItem.RightBearing = dBearingRight
                            Call oPointCache.Add(sTo, oPointCacheItem)
                        End If

                        'for other station put a placeholder in collection....
                        If Not oPointCache.ContainsKey(sFrom) Then
                            bUpdate = True
                        Else
                            bUpdate = (Not oPointCache(sFrom).HaveValidLR) 'AndAlso (oPoint <> oSidePointRight OrElse oPoint <> oSidePointLeft)
                            If bUpdate Then
                                oPointCache.Remove(sFrom)
                            End If
                        End If
                        If bUpdate Then ' Not oPointCache.ContainsKey(sFrom) Then
                            oPoint = oSurvey.Calculate.TrigPoints(sFrom).Point.To2DPoint(cTrigPointPoint.ProjectionEnum.FromTop)
                            'simple LR direction...
                            dBearing = oSegment.Data.Data.Bearing - 90

                            Dim oPointCacheItem As cPointCacheItem = New cPointCacheItem
                            oPointCacheItem.Point = oPoint
                            oPointCacheItem.LeftPoint = oPoint
                            oPointCacheItem.LeftBearing = dBearing
                            oPointCacheItem.RightPoint = oPoint
                            oPointCacheItem.RightBearing = modPaint.NormalizeAngle(dBearing + 180)
                            Call oPointCache.Add(sFrom, oPointCacheItem)
                        End If
                    End If
                End If
            Next

            'set sidepoints...
            Threading.Tasks.Parallel.ForEach(Of cSurveyPC.cSurvey.cSegment)(SegmentsColl, Sub(oSegment)
                                                                                              If oSegment.IsValid AndAlso Not oSegment.IsSelfDefined Then
                                                                                                  Dim oFromPointCacheitem As cPointCacheItem = oPointCache(oSegment.Data.Data.From)
                                                                                                  Dim oToPointCacheitem As cPointCacheItem = oPointCache(oSegment.Data.Data.To)
                                                                                                  Dim oFromSidePointRight As PointD = oFromPointCacheitem.RightPoint
                                                                                                  Dim dFromBearingRight As Decimal = oFromPointCacheitem.RightBearing
                                                                                                  Dim oFromSidePointLeft As PointD = oFromPointCacheitem.LeftPoint
                                                                                                  Dim dFromBearingLeft As Decimal = oFromPointCacheitem.LeftBearing
                                                                                                  Dim oToSidePointRight As PointD = oToPointCacheitem.RightPoint
                                                                                                  Dim dToBearingRight As Decimal = oToPointCacheitem.RightBearing
                                                                                                  Dim oToSidePointLeft As PointD = oToPointCacheitem.LeftPoint
                                                                                                  Dim dToBearingLeft As Decimal = oToPointCacheitem.LeftBearing
                                                                                                  Call oSegment.Data.Plan.SetSidePoints(oFromSidePointRight, dFromBearingRight, oFromSidePointLeft, dFromBearingLeft, oToSidePointRight, dToBearingRight, oToSidePointLeft, dToBearingLeft)
                                                                                              End If
                                                                                          End Sub)

            'For Each oSegment As cSegment In SegmentsColl
            '    If oSegment.IsValid AndAlso Not oSegment.IsSelfDefined Then
            '        Dim oFromPointCacheitem As cPointCacheItem = oPointCache(oSegment.Data.Data.From)
            '        Dim oToPointCacheitem As cPointCacheItem = oPointCache(oSegment.Data.Data.To)
            '        Dim oFromSidePointRight As PointD = oFromPointCacheitem.RightPoint
            '        Dim dFromBearingRight As Decimal = oFromPointCacheitem.RightBearing
            '        Dim oFromSidePointLeft As PointD = oFromPointCacheitem.LeftPoint
            '        Dim dFromBearingLeft As Decimal = oFromPointCacheitem.LeftBearing
            '        Dim oToSidePointRight As PointD = oToPointCacheitem.RightPoint
            '        Dim dToBearingRight As Decimal = oToPointCacheitem.RightBearing
            '        Dim oToSidePointLeft As PointD = oToPointCacheitem.LeftPoint
            '        Dim dToBearingLeft As Decimal = oToPointCacheitem.LeftBearing
            '        Call oSegment.Data.Plan.SetSidePoints(oFromSidePointRight, dFromBearingRight, oFromSidePointLeft, dFromBearingLeft, oToSidePointRight, dToBearingRight, oToSidePointLeft, dToBearingLeft)
            '    End If
            'Next

            'warping design...
            If PerformWarping Then
                If oSurvey.Properties.DesignWarpingMode = cSurvey.DesignWarpingModeEnum.Default AndAlso Not oSurvey.Properties.PlanWarpingDisabled Then
                    Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information, "Warping profile design")
                    Dim iIndex As Integer
                    Dim iCount As Integer
                    If Not oSurvey.Plan.IsEmpty Then
                        Dim oSegments As cISegmentCollection = oSurvey.Segments.GetChangedSegments(cIDesign.cDesignTypeEnum.Plan, True)
                        Dim oBindedSegments As cISegmentCollection = oSurvey.Segments.GetBindedSegments(cIDesign.cDesignTypeEnum.Plan)
                        Dim oSegmentsToProcess As cISegmentCollection = oSegments.Intersect(oBindedSegments)
                        iIndex = 0
                        iCount = oSegmentsToProcess.Count
                        If iCount > 0 Then
                            Dim iResult As DialogResult
                            If oSurvey.Properties.ShowWarpingDetails Then
                                iResult = oSurvey.RaiseOnWarpingDetailsEvent(oSegmentsToProcess, cIDesign.cDesignTypeEnum.Plan)
                            Else
                                iResult = DialogResult.OK
                            End If
                            If iResult = DialogResult.OK OrElse iResult = DialogResult.Cancel Then
                                Dim iStep As Integer = If(iCount > 20, iCount \ 20, 1)
                                Call oSurvey.RaiseOnProgressEvent("calculate.plot.plan", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("plotplan.progressbegin1"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageWarping OrElse cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow)
                                For Each oSegment As cISegment In oSegmentsToProcess
                                    iIndex += 1
                                    If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("calculate.plot.plan", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("plotplan.progress1"), iIndex / iCount)
                                    Call oSurvey.Plan.WarpItems(oSegment)
                                    Call oSegment.Data.Plan.ResetChange()
                                Next
                                Call oSurvey.RaiseOnProgressEvent("calculate.plot.plan", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, GetLocalizedString("plotplan.progressend1"), 0)
                            ElseIf iResult = DialogResult.Ignore Then
                                oSurvey.Properties.DesignWarpingState = cSurvey.DesignWarpingStateEnum.Paused
                            ElseIf iResult = DialogResult.Abort Then
                                oSurvey.Properties.DesignWarpingMode = cSurvey.DesignWarpingModeEnum.None
                            End If
                        End If
                    End If

                    For Each oCrossSection As cDesignCrossSection In oSurvey.CrossSections
                        If oCrossSection.CrossSection.Points.Count > 0 Then
                            Dim oFromPoint As PointD = oCrossSection.CrossSection.Points(0).Point
                            Dim oToPoint As PointD = oFromPoint
                            Call oCrossSection.Data.Plan.SetPoints("", "", oFromPoint, oToPoint)
                            Call oCrossSection.Data.ResetWarpingFactor()
                        End If
                    Next

                    If oSurvey.Properties.DesignWarpingMode = cSurvey.DesignWarpingModeEnum.Default Then
                        Dim oCrossSections As cDesignCrossSectionsCollection = oSurvey.CrossSections.GetChangedCrossSections(cIDesign.cDesignTypeEnum.Plan, True)
                        iIndex = 0
                        iCount = oCrossSections.Count
                        If iCount > 0 Then
                            Dim iStep As Integer = If(iCount > 20, iCount \ 20, 1)
                            Call oSurvey.RaiseOnProgressEvent("calculate.plot.plan", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("plotprofile.progressbegin2"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageWarping OrElse cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow)
                            For Each oCrossSection As cDesignCrossSection In oCrossSections
                                iIndex += 1
                                If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("calculate.plot.plan", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("plotprofile.progress2"), iIndex / iCount)
                                Call oCrossSection.WarpItems()
                                Call oCrossSection.Data.Plan.ResetChange()
                            Next
                            Call oSurvey.RaiseOnProgressEvent("calculate.plot.plan", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, GetLocalizedString("plotprofile.progressend2"), 0)
                        End If
                    End If
                End If
            End If
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            Call MyBase.New(Survey)
            oSurvey = Survey
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Plot As XmlElement)
            Call MyBase.New(Survey)
            oSurvey = Survey
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement)
            Dim oXmlPlot As XmlElement = Document.CreateElement("plot")
            Call Parent.AppendChild(oXmlPlot)
            Return oXmlPlot
        End Function
    End Class
End Namespace

