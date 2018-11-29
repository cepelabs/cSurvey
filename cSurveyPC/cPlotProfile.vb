Imports System.Drawing.Drawing2D

Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Calculate

Imports System.Xml

Namespace cSurvey.Design
    Public Class cPlotProfile
        Inherits cPlot

        Private oSurvey As cSurvey

        Friend Overrides Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
            Dim oMatrix As Matrix = New Matrix
            Dim oSVGItem As XmlElement = MyBase.Caches(PaintOptions).ToSvgItem(SVG, PaintOptions, Options, oMatrix)
            Call oSVGItem.SetAttribute("name", "plot.profile")
            Return oSVGItem
        End Function

        Friend Overrides Function ToSvg(ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlDocument
            Dim oSVG As XmlDocument = modSVG.CreateSVG
            Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions, Options))
            Return oSVG
        End Function

        Public Overrides Function HitTest(ByVal PaintOptions As cOptions, ByVal CurrentCave As String, ByVal CurrentBranch As String, ByVal Point As PointF, Optional Wide As Decimal = Decimal.MaxValue) As cPlotHitTestResult
            If PaintOptions.DrawPlot Then
                Dim oFoundSegment As cSegment
                Dim oFoundTrigpoint As cTrigPoint
                Dim dMinDistance As Decimal = Wide

                Dim oVisibleSegments As List(Of cISegment) = MyBase.GetAllVisibleSegments(PaintOptions)
                For Each oSegment As cSegment In oVisibleSegments
                    If modDesign.GetIfSegmentMustBeDrawedByCaveAndBranch(PaintOptions, oSegment, CurrentCave, CurrentBranch) Then
                        If oSegment.IsValid AndAlso Not oSegment.IsSelfDefined AndAlso Not oSegment.Splay Then
                            Dim oPoints() As PointF = oSegment.Data.Profile.GetVectorLine
                            Dim dDistance As Decimal = modPaint.DistancePointToSegment(Point, oPoints(0), oPoints(1))
                            If dDistance < dMinDistance Then
                                oFoundSegment = oSegment
                                dMinDistance = dDistance
                            End If
                        End If
                    End If
                Next

                If Not oFoundSegment Is Nothing Then
                    Dim sTrigpointDistance As Single = 0.5
                    Dim oPoints() As PointF = oFoundSegment.Data.Profile.GetVectorLine
                    Dim dDistance0 As Decimal = modPaint.DistancePointToPoint(Point, oPoints(0))
                    Dim dDistance1 As Decimal = modPaint.DistancePointToPoint(Point, oPoints(1))
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
                        Return New cPlotHitTestResult(oFoundSegment, Nothing)
                    End If
                End If
                Return New cPlotHitTestResult(Nothing, Nothing)
            Else
                Return New cPlotHitTestResult(Nothing, Nothing)
            End If
        End Function

        Public Overrides Function GetVisibleCaveBounds(PaintOptions As cOptions, ByVal Cave As String, Branch As String) As RectangleF
            Dim oMinPoint As PointF = New PointF(Single.MaxValue, Single.MaxValue)
            Dim oMaxPoint As PointF = New PointF(Single.MinValue, Single.MinValue)
            Dim oOrigin As cTrigPoint = oSurvey.TrigPoints.GetOrigin
            If Not oOrigin Is Nothing Then
                Dim oSegments As cSegmentCollection = oSurvey.Segments.GetVisibleCaveSegments(PaintOptions, Cave, Branch)
                If oSegments.Count Then
                    For Each oSegment As cSegment In oSegments
                        If Not oSegment.IsSelfDefined AndAlso oSegment.IsValid Then
                            Dim bVisible As Boolean = True
                            If oSegment.Splay Then
                                bVisible = PaintOptions.DrawSplay
                            End If
                            If oSegment.Surface Then
                                bVisible = (PaintOptions.DrawSegmentsOptions And cOptions.DrawSegmentsOptionsEnum.Surface) = cOptions.DrawSegmentsOptionsEnum.Surface
                            End If
                            If oSegment.Duplicate Then
                                bVisible = (PaintOptions.DrawSegmentsOptions And cOptions.DrawSegmentsOptionsEnum.Duplicate) = cOptions.DrawSegmentsOptionsEnum.Duplicate
                            End If
                            If bVisible Then
                                Call modPlot.ProfileTranslateAndComparePoint(oSurvey, oSegment.Data.Profile.ToPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                                Call modPlot.ProfileTranslateAndComparePoint(oSurvey, oSegment.Data.Profile.FromPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                            End If
                        End If
                    Next
                    Return New RectangleF(oMinPoint, New SizeF(oMaxPoint.X - oMinPoint.X, oMaxPoint.Y - oMinPoint.Y))
                Else
                    Return New RectangleF(0, 0, 0, 0)
                End If
            Else
                Return New RectangleF(0, 0, 0, 0)
            End If
        End Function

        Public Overrides Function GetCaveBounds(PaintOptions As cOptions, ByVal Cave As String, Branch As String) As RectangleF
            Dim oMinPoint As PointF = New PointF(Single.MaxValue, Single.MaxValue)
            Dim oMaxPoint As PointF = New PointF(Single.MinValue, Single.MinValue)
            Dim oOrigin As cTrigPoint = oSurvey.TrigPoints.GetOrigin
            If Not oOrigin Is Nothing Then
                Dim oSegments As cSegmentCollection = oSurvey.Segments.GetCaveSegments(Cave, Branch)
                If oSegments.Count Then
                    For Each oSegment As cSegment In oSegments
                        If Not oSegment.IsSelfDefined AndAlso oSegment.IsValid Then
                            Dim bVisible As Boolean = True
                            If oSegment.Splay Then
                                bVisible = PaintOptions.DrawSplay
                            End If
                            If oSegment.Surface Then
                                bVisible = (PaintOptions.DrawSegmentsOptions And cOptions.DrawSegmentsOptionsEnum.Surface) = cOptions.DrawSegmentsOptionsEnum.Surface
                            End If
                            If oSegment.Duplicate Then
                                bVisible = (PaintOptions.DrawSegmentsOptions And cOptions.DrawSegmentsOptionsEnum.Duplicate) = cOptions.DrawSegmentsOptionsEnum.Duplicate
                            End If
                            If bVisible Then
                                Call modPlot.ProfileTranslateAndComparePoint(oSurvey, oSegment.Data.Profile.ToPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                                Call modPlot.ProfileTranslateAndComparePoint(oSurvey, oSegment.Data.Profile.FromPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                            End If
                        End If
                    Next
                    Return New RectangleF(oMinPoint, New SizeF(oMaxPoint.X - oMinPoint.X, oMaxPoint.Y - oMinPoint.Y))
                Else
                    Return New RectangleF(0, 0, 0, 0)
                End If
            Else
                Return New RectangleF(0, 0, 0, 0)
            End If
        End Function

        Public Overrides Function GetVisibleBounds(PaintOptions As cOptions) As RectangleF
            Dim oMinPoint As PointF = New Point(Integer.MaxValue, Integer.MaxValue)
            Dim oMaxPoint As PointF = New Point(Integer.MinValue, Integer.MinValue)
            Dim oOrigin As cTrigPoint = oSurvey.TrigPoints.GetOrigin
            If Not oOrigin Is Nothing Then
                For Each oSegment As cSegment In MyBase.GetAllVisibleSegments(PaintOptions)
                    If Not oSegment.IsSelfDefined AndAlso oSegment.IsValid Then
                        Dim bVisible As Boolean = True
                        If oSegment.Splay Then
                            bVisible = PaintOptions.DrawSplay
                        End If
                        If oSegment.Surface Then
                            bVisible = (PaintOptions.DrawSegmentsOptions And cOptions.DrawSegmentsOptionsEnum.Surface) = cOptions.DrawSegmentsOptionsEnum.Surface
                        End If
                        If oSegment.Duplicate Then
                            bVisible = (PaintOptions.DrawSegmentsOptions And cOptions.DrawSegmentsOptionsEnum.Duplicate) = cOptions.DrawSegmentsOptionsEnum.Duplicate
                        End If
                        If bVisible Then
                            Call modPlot.ProfileTranslateAndComparePoint(oSurvey, oSegment.Data.Profile.ToPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                            Call modPlot.ProfileTranslateAndComparePoint(oSurvey, oSegment.Data.Profile.FromPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                        End If
                    End If
                Next
                Return New RectangleF(oMinPoint, New SizeF(oMaxPoint.X - oMinPoint.X, oMaxPoint.Y - oMinPoint.Y))
            Else
                Return New RectangleF(0, 0, 0, 0)
            End If
        End Function

        Public Overrides Function GetBounds(PaintOptions As cOptions) As RectangleF
            Dim oMinPoint As PointF = New Point(Integer.MaxValue, Integer.MaxValue)
            Dim oMaxPoint As PointF = New Point(Integer.MinValue, Integer.MinValue)
            Dim oOrigin As cTrigPoint = oSurvey.TrigPoints.GetOrigin
            If Not oOrigin Is Nothing Then
                For Each oSegment As cSegment In oSurvey.Segments
                    If Not oSegment.IsSelfDefined AndAlso oSegment.IsValid Then
                        Dim bVisible As Boolean = True
                        If oSegment.Splay Then
                            bVisible = PaintOptions.DrawSplay
                        End If
                        If oSegment.Surface Then
                            bVisible = (PaintOptions.DrawSegmentsOptions And cOptions.DrawSegmentsOptionsEnum.Surface) = cOptions.DrawSegmentsOptionsEnum.Surface
                        End If
                        If oSegment.Duplicate Then
                            bVisible = (PaintOptions.DrawSegmentsOptions And cOptions.DrawSegmentsOptionsEnum.Duplicate) = cOptions.DrawSegmentsOptionsEnum.Duplicate
                        End If
                        If bVisible Then
                            Call modPlot.ProfileTranslateAndComparePoint(oSurvey, oSegment.Data.Profile.ToPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                            Call modPlot.ProfileTranslateAndComparePoint(oSurvey, oSegment.Data.Profile.FromPoint, oSegment, PaintOptions.DrawTranslation, oMinPoint, oMaxPoint)
                        End If
                    End If
                Next
                Return New RectangleF(oMinPoint, New SizeF(oMaxPoint.X - oMinPoint.X, oMaxPoint.Y - oMinPoint.Y))
            Else
                Return New RectangleF(0, 0, 0, 0)
            End If
        End Function

        Friend Overrides Sub CalculateSplay()
            Dim oSplaySegments As List(Of cISegment) = New List(Of cISegment)(oSurvey.Segments.GetSplaySegments())
            For Each oSegment As cSegment In oSurvey.Segments
                If oSegment.IsValid AndAlso Not oSegment.IsSelfDefined AndAlso Not oSegment.Splay Then
                    With oSegment.Data.Profile
                        Dim sFrom As String = .From
                        Dim sTo As String = .To
                        Dim oFromPoint As PointD = .FromPoint
                        Dim oToPoint As PointD = .ToPoint
                        '------------------------------------------------------------------------------------------------------------------------------------------------------
                        'set splay shot projected data
                        'WARNING: splay are always calculated as normal shot...normal data are usefull for projected data calculation
                        Dim oSplayToPoint As PointF
                        Dim oSplayFromPoint As PointF
                        Dim sSplayTo As String
                        Dim sSplayFrom As String
                        Dim iSplayDir As Integer
                        'If oSegment.Data.Data.Reversed Then
                        '    oSplayToPoint = oFromPoint
                        '    sSplayTo = sFrom
                        '    oSplayFromPoint = oToPoint
                        '    sSplayFrom = sTo
                        '    iSplayDir = IIf(oSegment.Data.Data.Direction = cSurvey.DirectionEnum.Right, 1, -1)
                        'Else
                        oSplayToPoint = oToPoint
                        sSplayTo = sTo
                        oSplayFromPoint = oFromPoint
                        sSplayFrom = sFrom
                        iSplayDir = IIf(oSegment.Data.Data.Direction = cSurvey.DirectionEnum.Right, 1, -1)
                        'Dim dBearing As Decimal
                        'If oSegment.Data.Data.Reversed Then
                        '    dBearing = modPaint.NormalizeAngle(oSegment.Data.Data.Bearing + 180)
                        'Else
                        '    dBearing = modPaint.NormalizeAngle(oSegment.Data.Data.Bearing)
                        'End If
                        'End If

                        Dim dPlaneDirection As Decimal = modPaint.NormalizeAngle(oSegment.Data.Data.Bearing) + IIf(oSegment.Data.Data.Direction = cSurvey.DirectionEnum.Right, -oSegment.ProfileSplayBorderProjectionAngle, oSegment.ProfileSplayBorderProjectionAngle)
                        Dim dPlaneDirectionForRange As Decimal = modPaint.NormalizeAngle(If(oSegment.Data.Data.Reversed, 180 + dPlaneDirection, dPlaneDirection))
                        'FROM
                        Call .FromSplays.Clear()
                        'Dim oSplaySegments As cSegmentCollection = oSurvey.Segments.GetSplaySegments(sSplayFrom)
                        Dim oFromSplaySegment As List(Of cISegment) = oSplaySegments.Where(Function(segment) segment.From = sFrom OrElse segment.To = sFrom).ToList
                        If oFromSplaySegment.Count > 0 Then
                            For Each oSplaySegment As cSegment In oFromSplaySegment
                                Dim bInRange As Boolean = (oSegment.ProfileSplayBorderPosInclinationRange = modSegmentsTools.GetDefaultProfileSplayBorderPosInclinationRange OrElse (oSplaySegment.Data.Data.Inclination >= oSegment.ProfileSplayBorderPosInclinationRange.Width AndAlso oSplaySegment.Data.Data.Inclination <= oSegment.ProfileSplayBorderPosInclinationRange.Height)) _
                                    OrElse (oSegment.ProfileSplayBorderNegInclinationRange = modSegmentsTools.GetDefaultProfileSplayBorderNegInclinationRange OrElse (oSplaySegment.Data.Data.Inclination >= oSegment.ProfileSplayBorderNegInclinationRange.Width AndAlso oSplaySegment.Data.Data.Inclination <= oSegment.ProfileSplayBorderNegInclinationRange.Height))
                                Dim sSplayBearing As Single = oSplaySegment.Data.Data.Bearing
                                bInRange = bInRange And modPaint.IsAngleBetween(sSplayBearing, dPlaneDirectionForRange - oSegment.ProfileSplayBorderMaxAngleVariation, dPlaneDirectionForRange + oSegment.ProfileSplayBorderMaxAngleVariation)
                                Dim sSegmentAngle As Single = oSplaySegment.Data.Data.Bearing - dPlaneDirection
                                Dim oSegmentCateti As SizeF = modPaint.Trigo(oSplaySegment.Data.Data.Distance, oSplaySegment.Data.Data.Inclination)
                                'Dim oSegmentCateti As SizeF = modPaint.Trigo(oSplaySegment.Data.Data.Distance, oSplaySegment.Data.Data.Inclination)
                                Dim sSegmentY As Single = oSegmentCateti.Width
                                Dim sSegmentX As Single = modPaint.Trigo(oSegmentCateti.Height, sSegmentAngle).Height * iSplayDir
                                'Dim sSegmentX As Single = modPaint.Trigo(oSegmentCateti.Height, sSegmentAngle).Height * IIf(oSegment.Data.Data.Direction = cSurvey.DirectionEnum.Right, 1, -1)
                                Dim oCurrentPoint As PointF = New PointF(oSplayFromPoint.X + sSegmentX, oSplayFromPoint.Y - sSegmentY)
                                Dim oUpPoint As PointF = New PointF(oCurrentPoint.X, oCurrentPoint.Y - oSplaySegment.Up)
                                Dim oDownPoint As PointF = New PointF(oCurrentPoint.X, oCurrentPoint.Y + oSplaySegment.Down)
                                Call .FromSplays.Add(oSplaySegment, oCurrentPoint, oUpPoint, oDownPoint, bInRange)
                                'Call oSplaySegments.Remove(oSplaySegment)
                            Next
                        End If

                        dPlaneDirection = dPlaneDirection - 180
                        dPlaneDirection = modPaint.NormalizeAngle(dPlaneDirection)
                        dPlaneDirectionForRange = modPaint.NormalizeAngle(If(oSegment.Data.Data.Reversed, 180 + dPlaneDirection, dPlaneDirection))
                        'TO
                        Call .ToSplays.Clear()
                        'oSplaySegments = oSurvey.Segments.GetSplaySegments(sSplayTo)
                        Dim oToSplaySegment As List(Of cISegment) = oSplaySegments.Where(Function(segment) segment.From = sTo OrElse segment.To = sTo).ToList
                        If oToSplaySegment.Count > 0 Then
                            For Each oSplaySegment As cSegment In oToSplaySegment
                                Dim bInRange As Boolean = (oSegment.ProfileSplayBorderPosInclinationRange = modSegmentsTools.GetDefaultProfileSplayBorderPosInclinationRange OrElse (oSplaySegment.Data.Data.Inclination >= oSegment.ProfileSplayBorderPosInclinationRange.Width AndAlso oSplaySegment.Data.Data.Inclination <= oSegment.ProfileSplayBorderPosInclinationRange.Height)) _
                                    OrElse (oSegment.ProfileSplayBorderNegInclinationRange = modSegmentsTools.GetDefaultProfileSplayBorderNegInclinationRange OrElse (oSplaySegment.Data.Data.Inclination >= oSegment.ProfileSplayBorderNegInclinationRange.Width AndAlso oSplaySegment.Data.Data.Inclination <= oSegment.ProfileSplayBorderNegInclinationRange.Height))
                                Dim sSplayBearing As Single = oSplaySegment.Data.Data.Bearing
                                bInRange = bInRange And modPaint.IsAngleBetween(sSplayBearing, dPlaneDirectionForRange - oSegment.ProfileSplayBorderMaxAngleVariation, dPlaneDirectionForRange + oSegment.ProfileSplayBorderMaxAngleVariation)
                                Dim sSegmentAngle As Single = oSplaySegment.Data.Data.Bearing - dPlaneDirection '- IIf(oSplaySegment.Data.Data.Bearing > 180, 360 - dPlaneDirection, dPlaneDirection)
                                Dim oSegmentCateti As SizeF = modPaint.Trigo(oSplaySegment.Data.Data.Distance, oSplaySegment.Data.Data.Inclination)
                                Dim sSegmentY As Single = oSegmentCateti.Width
                                Dim sSegmentX As Single = -modPaint.Trigo(oSegmentCateti.Height, sSegmentAngle).Height * iSplayDir ' IIf(oSegment.Data.Data.Direction = cSurvey.DirectionEnum.Right, 1, -1)
                                Dim oCurrentPoint As PointF = New PointF(oSplayToPoint.X + sSegmentX, oSplayToPoint.Y - sSegmentY)
                                Dim oUpPoint As PointF = New PointF(oCurrentPoint.X, oCurrentPoint.Y - oSplaySegment.Up)
                                Dim oDownPoint As PointF = New PointF(oCurrentPoint.X, oCurrentPoint.Y + oSplaySegment.Down)
                                Call .ToSplays.Add(oSplaySegment, oCurrentPoint, oUpPoint, oDownPoint, bInRange)
                                'Call oSplaySegments.remove(oSplaySegment)
                            Next
                        End If
                    End With
                End If
            Next
        End Sub

        Friend Sub Render(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, Selection As Helper.Editor.cIEditDesignSelection)
            Dim oCache As cDrawCache = MyBase.Caches(PaintOptions)
            With oCache
                If .Invalidated Then
                    Call .Clear()
                    Dim oCacheItem As Drawings.cDrawCacheItem
                    Dim oStartSurveySegment As cSegment = oSurvey.Segments.GetOrigin
                    'disegno SOLO se ho l'orgine definita...altrimenti non verrebbe nulla
                    If Not oStartSurveySegment Is Nothing Then
                        Dim iSplayEditMode As cOptionsDesign.SplayEditModeEnum
                        If TypeOf PaintOptions Is cOptionsDesign Then
                            iSplayEditMode = DirectCast(PaintOptions, cOptionsDesign).SplayEditMode
                        Else
                            iSplayEditMode = cOptionsDesign.SplayEditModeEnum.All
                        End If

                        Dim oCurrentSegment As cSegment = IIf(PaintOptions.IsDesign, Selection.CurrentSegment, Nothing)
                        Dim oCurrentTrigpoint As cTrigPoint = IIf(PaintOptions.IsDesign, Selection.CurrentTrigpoint, Nothing)
                        Dim oDrawingObject As cOptionsDrawingObjects = PaintOptions.DrawingObjects
                        Dim oTranslationTrigPoints As cTranslatedTrigPoints = New cTranslatedTrigPoints
                        Dim sTTH As Single = PaintOptions.TranslationsOptions.TranslationsThreshold

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
                                    Using oTranslationMatrix As Matrix = New Matrix
                                        If Not PaintOptions.IsDesign AndAlso PaintOptions.DrawTranslation Then
                                            Dim oTranslation As PointF = modPlot.GetProfileSegmentTranslation(oSurvey, oSegment)
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
                                                If PaintOptions.CenterlineColorGray Then
                                                    oColor = modPaint.GrayColor(oColor)
                                                End If
                                            End If

                                            Dim oToPoint As PointF = oSegment.Data.Profile.ToPoint
                                            Dim oFromPoint As PointF = oSegment.Data.Profile.FromPoint

                                            Dim oFromSplay As List(Of Plot.cSplayProfileProjectedData)
                                            If PaintOptions.ShowSplayMode = cOptions.ShowSplayModeEnum.All Then
                                                oFromSplay = oSegment.Data.Profile.FromSplays.GetNotInRangeSplays
                                                If oFromSplay.Count > 0 Then
                                                    Call modPaint.PaintStationSplays(PaintOptions, oCache, oCurrentSegment, oSegment, oFromPoint, modPaint.LightColor(oColor, 0.85), oTranslationMatrix, "-U", "-D", oFromSplay)
                                                End If
                                            End If
                                            oFromSplay = oSegment.Data.Profile.FromSplays.GetInRangeSplays
                                            If oFromSplay.Count > 0 Then
                                                Call modPaint.PaintStationSplays(PaintOptions, oCache, oCurrentSegment, oSegment, oFromPoint, oColor, oTranslationMatrix, "-U", "-D", oFromSplay)
                                            End If

                                            Dim oToSplays As List(Of Plot.cSplayProfileProjectedData)
                                            If PaintOptions.ShowSplayMode = cOptions.ShowSplayModeEnum.All Then
                                                oToSplays = oSegment.Data.Profile.ToSplays.GetNotInRangeSplays
                                                If oToSplays.Count > 0 Then
                                                    Call modPaint.PaintStationSplays(PaintOptions, oCache, oCurrentSegment, oSegment, oToPoint, modPaint.LightColor(oColor, 0.85), oTranslationMatrix, "-U", "-D", oToSplays)
                                                End If
                                            End If
                                            oToSplays = oSegment.Data.Profile.ToSplays.GetInRangeSplays
                                            If oToSplays.Count > 0 Then
                                                Call modPaint.PaintStationSplays(PaintOptions, oCache, oCurrentSegment, oSegment, oToPoint, oColor, oTranslationMatrix, "-U", "-D", oToSplays)
                                            End If
                                        End If

                                        'segmenti laterali e aree
                                        If PaintOptions.DrawPlot AndAlso PaintOptions.DrawLRUD Then
                                            'va aggiunto un paintoption.drawlrudforsplay
                                            'per gli splay lrud vanno disegnati solo se presenti...
                                            Dim oColor As Color
                                            If oSegment.Data.SegmentColor = Color.Transparent Then
                                                oColor = modPaint.LightColor(oCaveColor, 0.3)
                                            Else
                                                oColor = modPaint.LightColor(oSegment.Data.SegmentColor, 0.3)
                                                If PaintOptions.CenterlineColorGray Then
                                                    oColor = modPaint.GrayColor(oColor)
                                                End If
                                            End If

                                            'If Not oColor = Color.White Then
                                            If PaintOptions.DrawStyle = cOptions.DrawStyleEnum.OnlySegment Then
                                                Using oAreaLine As GraphicsPath = modPlot.GetProfileAreaLine(oSegment)
                                                    If Not oAreaLine Is Nothing Then
                                                        oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
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
                                                Using oAreaPoly As GraphicsPath = modPlot.GetProfileAreaPolygon(oSegment)
                                                    If Not oAreaPoly Is Nothing Then
                                                        oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
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

                                        'superficie
                                        If oSurvey.Properties.SurfaceProfile AndAlso PaintOptions.DrawSurfaceProfile AndAlso Not oSegment.Splay AndAlso oSegment.GetSurfaceProfileShow Then
                                            With oSegment.Data
                                                Dim oSurfacePoints As PointF() = .Profile.SurfaceProfile.ToArray
                                                If oSurfacePoints.Count > 1 Then
                                                    Dim oColor As Color
                                                    If .SegmentColor = Color.Transparent Then
                                                        oColor = modPaint.LightColor(oCaveColor, 0.6)
                                                    Else
                                                        oColor = modPaint.LightColor(.SegmentColor, 0.6)
                                                        If PaintOptions.CenterlineColorGray Then
                                                            oColor = modPaint.GrayColor(oColor)
                                                        End If
                                                    End If

                                                    oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                                    If oCurrentSegment Is oSegment Then
                                                        oDrawingObject.SelectedSurfaceProfilePen.Color = oColor
                                                        Call oCacheItem.SetPen(oDrawingObject.SelectedSurfaceProfilePen)
                                                    Else
                                                        oDrawingObject.SurfaceProfilePen.Color = oColor
                                                        Call oCacheItem.SetPen(oDrawingObject.SurfaceProfilePen)
                                                    End If


                                                    Call oCacheItem.AddLines(oSurfacePoints)
                                                    Call oCacheItem.Transform(oTranslationMatrix)
                                                End If
                                            End With
                                        End If

                                        'segmenti
                                        With oSegment.Data
                                            If PaintOptions.DrawPlot AndAlso PaintOptions.DrawSegments AndAlso Not oSegment.Splay Then
                                                Dim oColor As Color
                                                If oDrawingObject.CenterlineForceColor Then
                                                    If .SegmentColor = Color.Transparent Then
                                                        oColor = oDrawingObject.PenColor
                                                    Else
                                                        oColor = modPaint.DarkColor(.SegmentColor, 0.2)
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

                                                oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                                If oCurrentSegment Is oSegment Then
                                                    oDrawingObject.SelectedPen.Color = oColor
                                                    Call oCacheItem.SetPen(oDrawingObject.SelectedPen)
                                                Else
                                                    oDrawingObject.Pen.Color = oColor
                                                    Call oCacheItem.SetPen(oDrawingObject.Pen)
                                                End If
                                                Call oCacheItem.AddLine(CType(.Profile.FromPoint, PointF), CType(.Profile.ToPoint, PointF))
                                                Call oCacheItem.Transform(oTranslationMatrix)

                                                If PaintOptions.DrawHighlights Then
                                                    If PaintOptions.HighlightsOptions.Get(Properties.cHighlightsDetails.RingKey) AndAlso oSegment.Data.IsInRing AndAlso oSurvey.Calculate.Rings.IsSegmentInSelectedRing(oSegment) Then
                                                        oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                                        oDrawingObject.SelectedRingPen.Color = oSurvey.Calculate.Rings.GetSegmentColor(oSegment, oDefaultRingColor)
                                                        oDrawingObject.SelectedRingPen.Width = sDefaultRingPenWidth
                                                        Call oCacheItem.SetPen(oDrawingObject.SelectedRingPen)
                                                        Call oCacheItem.AddLine(.Profile.FromPoint, .Profile.ToPoint)
                                                        Call oCacheItem.Transform(oTranslationMatrix)
                                                    End If
                                                    For Each sID As String In PaintOptions.HighlightsOptions
                                                        If oSurvey.Properties.HighlightsDetails.Contains(sID) Then
                                                            With oSurvey.Properties.HighlightsDetails(sID)
                                                                If .ApplyTo = Properties.cHighlightsDetail.ApplyToEnum.Shots Then
                                                                    Dim oMeters As Properties.cHighlightsDetailMeters = .GetMetres
                                                                    If .GetScript.Eval("GetHighlight", {New Properties.cShotHighlightDetails(oSurvey, oSegment, oMeters)}) Then
                                                                        Call modRender.RenderHighlightShot(Graphics, PaintOptions, oSegment.Data.Plan.FromPoint, oSegment.Data.Plan.ToPoint, oCache, oMeters)
                                                                    End If
                                                                End If
                                                            End With
                                                        End If
                                                    Next
                                                End If
                                            End If
                                            If PaintOptions.DrawPlot AndAlso PaintOptions.ShowPointInformation AndAlso Not oSegment.Splay Then
                                                oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                                Dim oTrigPoint As cTrigPoint = oSegment.GetToTrigPoint
                                                Dim sInfo As String = .Data.From & " -> " & .Data.To & vbCrLf & ": " & modNumbers.MathRound(.Data.Distance, 2) & " " & cSegment.GetDistanceSimbol(oSegment.GetDistanceType) & "/" & modNumbers.MathRound(.Data.Inclination, 2) & " " & cSegment.GetInclinationSimbol(oSegment.GetInclinationType) & "/" & modNumbers.MathRound(.Data.Bearing, 2) & " " & cSegment.GetBearingSimbol(oSegment.GetBearingType) & vbCrLf & "Δ: " & modNumbers.MathRound(- .Profile.ToPoint.Y, 2) & " m" & vbCrLf & oTrigPoint.Note
                                                Call oCacheItem.SetBrush(oDrawingObject.InfoBrush)
                                                Call oCacheItem.AddString(sInfo, oDrawingObject.InfoFont, New PointF(.Profile.ToPoint.X + oDrawingObject.InfoFont.Height * (oTrigPoint.LabelDistance / 10) / 5, .Profile.ToPoint.Y + oDrawingObject.InfoFont.Height * (oTrigPoint.LabelDistance / 10) / 5))
                                                Call oCacheItem.Transform(oTranslationMatrix)
                                            End If
                                        End With
                                    End Using

                                    'linee di riporto (traslazioni)
                                    If Not oSegment.Splay Then
                                        If Not PaintOptions.IsDesign AndAlso PaintOptions.DrawTranslation Then
                                            With oSegment.Data
                                                Dim oTranslation As SizeF = modPlot.GetProfileSegmentTranslation(oSurvey, oSegment)
                                                If oTranslation.IsEmpty Then
                                                    Call oTranslationTrigPoints.Add(.Data.From, .Profile.FromPoint)
                                                    Call oTranslationTrigPoints.Add(.Data.To, .Profile.ToPoint)
                                                Else
                                                    Call oTranslationTrigPoints.Add(.Data.From, PointF.Add(.Profile.FromPoint, oTranslation))
                                                    Call oTranslationTrigPoints.Add(.Data.To, PointF.Add(.Profile.ToPoint, oTranslation))
                                                End If
                                            End With
                                        Else
                                            With oSegment.Data
                                                Call oTranslationTrigPoints.Add(.Data.From, .Profile.FromPoint)
                                                Call oTranslationTrigPoints.Add(.Data.To, .Profile.ToPoint)
                                            End With
                                        End If
                                    End If
                                End If
                            End If
                        Next

                        Dim oDrawedTrigPoint As List(Of String) = New List(Of String)
                        For Each oSegment As cSegment In oVisibleSegments
                            If modDesign.GetIfSegmentMustBeDrawedByCaveAndBranch(PaintOptions, oSegment, Selection.CurrentCave, Selection.CurrentBranch) Then
                                Dim oTranslationTrigpointsToDraw As List(Of cTranslatedTrigPoint) = New List(Of cTranslatedTrigPoint)
                                If oTranslationTrigPoints.Contains(oSegment.From) Then Call oTranslationTrigpointsToDraw.Add(oTranslationTrigPoints(oSegment.From))
                                If oTranslationTrigPoints.Contains(oSegment.To) Then Call oTranslationTrigpointsToDraw.Add(oTranslationTrigPoints(oSegment.To))
                                For Each oTranslationTrigPoint As cTranslatedTrigPoint In oTranslationTrigpointsToDraw
                                    If Not oDrawedTrigPoint.Contains(oTranslationTrigPoint.Name) Then
                                        'linee di traslazione
                                        If (Not PaintOptions.IsDesign AndAlso PaintOptions.DrawTranslation AndAlso PaintOptions.TranslationsOptions.DrawTranslationsLine AndAlso oTranslationTrigPoint.Count > 1 AndAlso oSurvey.TrigPoints(oTranslationTrigPoint.Name).DrawTranslationsLine) OrElse (PaintOptions.IsDesign AndAlso oSurvey.TrigPoints(oTranslationTrigPoint.Name).DrawTranslationsLine) Then
                                            Dim oFromPoint As PointF = oTranslationTrigPoint(0)
                                            For i As Integer = 1 To oTranslationTrigPoint.Count - 1
                                                oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                                Dim oToPoint As PointF = oTranslationTrigPoint(i)
                                                If (oToPoint.X <> oFromPoint.X) AndAlso (oToPoint.Y <> oFromPoint.Y) Then
                                                    Dim oMidPoint As PointF = New PointF(oFromPoint.X, oToPoint.Y)
                                                    Call oCacheItem.SetPen(oDrawingObject.TranslationPen)
                                                    Call oCacheItem.AddLine(oFromPoint, oMidPoint)
                                                    Call oCacheItem.AddLine(oMidPoint, oToPoint)
                                                Else
                                                    Call oCacheItem.SetPen(oDrawingObject.TranslationPen)
                                                    Call oCacheItem.AddLine(oFromPoint, oToPoint)
                                                End If
                                            Next
                                        End If

                                        Dim oTrigPoint As cTrigPoint = oSurvey.TrigPoints(oTranslationTrigPoint.Name)
                                        If oSurvey.TrigPoints.Contains(oTranslationTrigPoint.Name) Then
                                            For Each oPoint As PointF In oTranslationTrigPoint
                                                If oTrigPoint.IsEntrance Then
                                                    Call RenderEntrancePoint(Graphics, PaintOptions, oPoint, oCache, oTrigPoint.ShowEntrance)
                                                End If
                                                If PaintOptions.DrawHighlights Then
                                                    For Each sID As String In PaintOptions.HighlightsOptions
                                                        If oSurvey.Properties.HighlightsDetails.Contains(sID) Then
                                                            With oSurvey.Properties.HighlightsDetails(sID)
                                                                If .ApplyTo = Properties.cHighlightsDetail.ApplyToEnum.Stations Then
                                                                    Dim oMeters As Properties.cHighlightsDetailMeters = .GetMetres
                                                                    If .GetScript.Eval("GetHighlight", {New Properties.cStationHighlightDetails(oSurvey, oTrigPoint, oMeters)}) Then
                                                                        Call modRender.RenderHighlightStation(Graphics, PaintOptions, oPoint, oCache, oMeters)
                                                                    End If
                                                                End If
                                                            End With
                                                        End If
                                                    Next
                                                End If

                                                'disegno il punto e il nome del caposaldo
                                                If Not oTrigPoint.Data.IsSplay Then
                                                    If (oTranslationTrigPoint.Count > 1 AndAlso PaintOptions.DrawTranslation AndAlso oTrigPoint.DrawTranslationsLine) OrElse (PaintOptions.DrawPlot AndAlso PaintOptions.DrawPoints) OrElse (PaintOptions.DrawDesign AndAlso PaintOptions.DrawSpecialPoints AndAlso oTrigPoint.IsSpecial) Then
                                                        If oTrigPoint Is oCurrentTrigpoint Then
                                                            Call RenderTrigPoint(Graphics, PaintOptions, oTrigPoint, oPoint, oDrawingObject.SelectedPointSize, oDrawingObject.SelectedPointBrush, oDrawingObject.SelectedPointPen, oCache)
                                                        Else
                                                            Call RenderTrigPoint(Graphics, PaintOptions, oTrigPoint, oPoint, oDrawingObject.PointSize, oDrawingObject.PointBrush, oDrawingObject.PointPen, oCache)
                                                        End If
                                                    End If
                                                    If (PaintOptions.DrawPlot AndAlso PaintOptions.DrawPointNames) OrElse (PaintOptions.DrawDesign AndAlso PaintOptions.DrawSpecialPoints AndAlso oTrigPoint.IsSpecial) Then
                                                        'e il nome del punto
                                                        If (PaintOptions.ShowPointText AndAlso Not PaintOptions.DrawSpecialPoints) OrElse (PaintOptions.DrawSpecialPoints AndAlso oTrigPoint.IsSpecial) Then
                                                            Call RenderTrigPointName(Graphics, PaintOptions, oTrigPoint, oPoint, oCache)
                                                        End If
                                                    End If
                                                End If
                                            Next
                                            Call oDrawedTrigPoint.Add(oTranslationTrigPoint.Name)
                                        End If
                                    End If
                                Next
                            End If
                            'End If
                        Next
                    End If

                    'Dim sArrowSize As Single = PaintOptions.DrawingObjects.CrossSectionMarkerArrowSize
                    'Dim sRefLineLen As Single = sArrowSize * 4
                    'For Each oItem As cItemCrossSection In oSurvey.Profile.Layers(LayerTypeEnum.Signs).Items.ToArray.Where(Function(item) item.Type = cIItem.cItemTypeEnum.CrossSection)
                    '    If Not oItem.Segment Is Nothing AndAlso oItem.ShowMarker Then
                    '        Dim oSegment As cSegment = oItem.Segment
                    '        Dim iSegmentSign As Integer = IIf(oSegment.Direction = cSegment.DirectionEnum.Left, -1, 1) * IIf(oItem.Direction = cIItemCrossSection.DirectionEnum.Direct, 1, -1)
                    '        Dim oFromPoint As PointF = oSegment.Data.Profile.FromPoint
                    '        Dim oToPoint As PointF = oSegment.Data.Profile.ToPoint
                    '        Dim oMarkerCenterPoint As PointF = modPaint.PointOnLineByPercentage(oFromPoint, oToPoint, oItem.MarkerPosition)
                    '        Dim sU As Single = -1 * oItem.MarkerU
                    '        Dim sD As Single = oItem.MarkerD
                    '        'If sU = 0 Or sD = 0 Then
                    '        '    Dim oUD As SizeF = modDesign.GetUDFromDesign(PaintOptions, oSegment, oMarkerCenterPoint, GetDesignStationEnum.From)
                    '        '    If sU = 0 Then
                    '        '        sU = oUD.Width * 1.1
                    '        '    End If
                    '        '    If sD = 0 Then
                    '        '        sD = oUD.Height * 1.1
                    '        '    End If
                    '        'End If
                    '        Dim oStartPointU As PointF = oMarkerCenterPoint + New SizeF(0, sU)
                    '        Dim oEndPointU As PointF = oMarkerCenterPoint + New SizeF(0, sU - sRefLineLen)
                    '        Dim oStartPointD As PointF = oMarkerCenterPoint + New SizeF(0, sD)
                    '        Dim oEndPointD As PointF = oMarkerCenterPoint + New SizeF(0, sD + sRefLineLen)

                    '        oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                    '        Call oCacheItem.SetPen(PaintOptions.DrawingObjects.CrossSectionMarkerPen)
                    '        If oItem.MarkerProfileAlignment = cIItemCrossSection.MarkerProfileAlignmentEnum.Up Then
                    '            Dim oArrowPoint As PointF = New PointF(oEndPointU.X + iSegmentSign * sArrowSize, oEndPointU.Y)
                    '            Call oCacheItem.AddLines({oStartPointU, oEndPointU, oArrowPoint})
                    '            oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Filler)
                    '            Call oCacheItem.SetBrush(PaintOptions.DrawingObjects.CrossSectionMarkerBrush)
                    '            Call oCacheItem.AddPolygon({oArrowPoint, New PointF(oArrowPoint.X, oArrowPoint.Y + sArrowSize / 2), New PointF(oArrowPoint.X + iSegmentSign * sArrowSize, oArrowPoint.Y), New PointF(oArrowPoint.X, oArrowPoint.Y - sArrowSize / 2), oArrowPoint})
                    '        Else
                    '            Call oCacheItem.AddLine(oStartPointU, oEndPointU)
                    '        End If
                    '        oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                    '        Call oCacheItem.SetPen(PaintOptions.DrawingObjects.CrossSectionMarkerPen)
                    '        If oItem.MarkerProfileAlignment = cIItemCrossSection.MarkerProfileAlignmentEnum.Down Then
                    '            Dim oArrowPoint As PointF = New PointF(oEndPointD.X + iSegmentSign * sArrowSize, oEndPointD.Y)
                    '            Call oCacheItem.AddLines({oStartPointD, oEndPointD, oArrowPoint})
                    '            oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Filler)
                    '            Call oCacheItem.SetBrush(PaintOptions.DrawingObjects.CrossSectionMarkerBrush)
                    '            Call oCacheItem.AddPolygon({oArrowPoint, New PointF(oArrowPoint.X, oArrowPoint.Y + sArrowSize / 2), New PointF(oArrowPoint.X + iSegmentSign * sArrowSize, oArrowPoint.Y), New PointF(oArrowPoint.X, oArrowPoint.Y - sArrowSize / 2), oArrowPoint})
                    '        Else
                    '            Call oCacheItem.AddLine(oStartPointD, oEndPointD)
                    '        End If
                    '    End If
                    'Next

                    Call .Rendered()
                End If
            End With
        End Sub

        Friend Overrides Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, Selection As Helper.Editor.cIEditSelection)
            If Not PaintOptions.IsDesign Then
                PaintOptions.HighlightCurrentCave = False
                PaintOptions.HighlightMode = cOptions.HighlightModeEnum.Default
            End If
            Call Render(Graphics, PaintOptions, Selection)
            Call MyBase.Caches(PaintOptions).Paint(Graphics, PaintOptions, cItem.PaintOptionsEnum.None)
        End Sub

        Friend Overrides Sub Calculate(ByVal SegmentsColl As List(Of cSegment), Optional ByVal PerformWarping As Boolean = True)
            'Try
            For Each oSegment As cSegment In SegmentsColl 'oSurvey.Segments
                Dim iSideMeasureReferTo As cSegment.SideMeasuresReferToEnum

                If oSegment.Splay Then
                    'splay are always managed with LRUD at end station and perpedicular to shot
                    iSideMeasureReferTo = cSegment.SideMeasuresReferToEnum.EndPoint
                Else
                    iSideMeasureReferTo = oSegment.GetSideMeasuresReferTo
                End If

                Dim sFrom As String = oSegment.Data.Data.From
                Dim sTo As String = oSegment.Data.Data.To
                'If oSegment.Data.Data.Reversed Then
                '    sFrom = oSegment.Data.Data.To
                '    sTo = oSegment.Data.Data.From
                'Else
                '    sFrom = oSegment.Data.Data.From
                '    sTo = oSegment.Data.Data.To
                'End If

                Dim oFromTrigpoint As Calculate.cTrigPoint = oSurvey.Calculate.TrigPoints(sFrom)
                Dim oToTrigpoint As Calculate.cTrigPoint = oSurvey.Calculate.TrigPoints(sTo)

                Dim oFromPoint As PointD = oFromTrigpoint.Connections(sTo).GetPoint.To2DPoint(cTrigPointPoint.ProjectionEnum.Perpendicular)
                'Dim oFromPoint As PointD = oFromTrigpoint.Point.To2DPoint(cTrigPointPoint.ProjectionEnum.Perpendicular)
                Dim oToPoint As PointD
                If oSegment.IsSelfDefined Then
                    oToPoint = oFromPoint
                Else
                    oToPoint = oToTrigpoint.Connections(sFrom).GetPoint.To2DPoint(cTrigPointPoint.ProjectionEnum.Perpendicular)
                End If

                Dim sD As Decimal = oToPoint.X
                oToPoint = oToTrigpoint.Point.To2DPoint(cTrigPointPoint.ProjectionEnum.Perpendicular)
                oToPoint.X = sD

                'calcolo i sidepoints
                Dim oFromSidePointDown As PointD
                Dim oFromSidePointUp As PointD
                Dim oToSidePointDown As PointD
                Dim oToSidePointUp As PointD
                'Try
                Dim [sTop] As Decimal
                Dim [sBottom] As Decimal
                With oFromTrigpoint
                    Dim oTopBottom As SizeD = .SideMeasure.GetUpDown
                    [sTop] = oTopBottom.Width
                    [sBottom] = oTopBottom.Height
                    oFromSidePointDown = New PointD(oFromPoint.X, oFromPoint.Y + [sBottom])
                    oFromSidePointUp = New PointD(oFromPoint.X, oFromPoint.Y - [sTop])
                End With
                With oToTrigpoint
                    Dim oTopBottom As SizeD = .SideMeasure.GetUpDown
                    [sTop] = oTopBottom.Width
                    [sBottom] = oTopBottom.Height
                    oToSidePointDown = New PointD(oToPoint.X, oToPoint.Y + [sBottom])
                    oToSidePointUp = New PointD(oToPoint.X, oToPoint.Y - [sTop])
                End With

                'set calculated points...here, in future, top and bottom have to be calculated using vthreshold (also in plan)
                Call oSegment.Data.Profile.SetPoints(sFrom, sTo, oFromPoint, oToPoint)
                Call oSegment.Data.Profile.SetSidePoints(oFromSidePointDown, oFromSidePointUp, oToSidePointDown, oToSidePointUp)

                'calculate surface profile...
                Call oSegment.Data.Profile.SurfaceProfile.Clear()
                If Not oSurvey.Properties.SurfaceProfileElevation Is Nothing Then ' And oSegment.From = "GB0" And oSegment.To = "GB1" Then
                    Dim sBaseAlt As Decimal = oSurvey.Calculate.TrigPoints(oSurvey.Properties.Origin).Coordinate.Altitude  ' oSurvey.Properties.SurfaceProfileElevation.GetElevation(oSurvey.TrigPoints.GetOrigin)
                    Dim oPlanFromPoint As PointD = oSegment.Data.Plan.FromPoint
                    Dim oPlanToPoint As PointD = oSegment.Data.Plan.ToPoint

                    Dim oProfileFromPoint As PointD = oSegment.Data.Profile.FromPoint
                    Dim oProfileToPoint As PointD = oSegment.Data.Profile.ToPoint
                    Dim sSign As Decimal
                    If oSegment.Data.Data.Direction = cSurvey.DirectionEnum.Left Then
                        sSign = -1
                    Else
                        sSign = 1
                    End If

                    Dim sTotProfileDistance As Decimal = oSegment.Data.Data.Distance
                    Dim sTotPlanDistance As Decimal = modPaint.DistancePointToPoint(oPlanFromPoint, oPlanToPoint)
                    Dim oPlanSubPoint As PointD
                    Dim sStep As Decimal = 2    '1 surface point every 2 shot meters (plan projected)...in future set as parameters...
                    Dim sPlanDistance As Decimal = -sStep
                    Do
                        sPlanDistance += sStep
                        If sPlanDistance > sTotPlanDistance Then sPlanDistance = sTotPlanDistance
                        If oPlanFromPoint = oPlanToPoint Then
                            oPlanSubPoint = oPlanFromPoint
                        Else
                            oPlanSubPoint = modPaint.PointOnLineByPercentage(oPlanFromPoint, oPlanToPoint, sPlanDistance / sTotPlanDistance)
                        End If
                        Dim sAlt As Decimal = oSurvey.Properties.SurfaceProfileElevation.GetElevation(oPlanSubPoint)
                        If sAlt <> Surface.cElevation.NoDataValue Then
                            Call oSegment.Data.Profile.SurfaceProfile.Append(New PointD(oProfileFromPoint.X + sPlanDistance * sSign, -1 * (sAlt - sBaseAlt)))
                        End If
                    Loop Until sPlanDistance = sTotPlanDistance
                End If
            Next

            'warping design...
            If PerformWarping Then
                Dim iIndex As Integer
                Dim iCount As Integer
                If oSurvey.Properties.DesignWarpingMode = cSurvey.DesignWarpingModeEnum.Default AndAlso Not oSurvey.Properties.ProfileWarpingDisabled Then
                    If Not oSurvey.Profile.IsEmpty Then
                        Dim oSegments As cSegmentCollection = oSurvey.Segments.GetChangedSegments(cIDesign.cDesignTypeEnum.Profile, True)
                        Dim oBindedSegments As cISegmentCollection = oSurvey.Segments.GetBindedSegments(cIDesign.cDesignTypeEnum.Profile)
                        Dim oSegmentsToProcess As cISegmentCollection = oSegments.Intersect(oBindedSegments)
                        iIndex = 0
                        iCount = oSegmentsToProcess.Count
                        If iCount > 0 Then
                            Dim iResult As DialogResult
                            If oSurvey.Properties.ShowWarpingDetails Then
                                iResult = oSurvey.RaiseOnWarpingDetailsEvent(oSegmentsToProcess, cIDesign.cDesignTypeEnum.Profile)
                            Else
                                iResult = DialogResult.OK
                            End If
                            If iResult = DialogResult.OK OrElse iResult = DialogResult.Cancel Then
                                Dim iStep As Integer = IIf(iCount > 20, iCount \ 20, 1)
                                Call oSurvey.RaiseOnProgressEvent("calculate.plot.profile", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("plotprofile.progressbegin1"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageWarping OrElse cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow)
                                For Each oSegment As cSegment In oSegmentsToProcess
                                    iIndex += 1
                                    If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("calculate.plot.profile", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("plotprofile.progress1"), iIndex / iCount)
                                    Call oSurvey.Profile.WarpItems(oSegment)
                                    Call oSegment.Data.Profile.ResetChange()
                                Next
                                Call oSurvey.RaiseOnProgressEvent("calculate.plot.profile", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, GetLocalizedString("plotprofile.progressend1"), 0)
                            ElseIf iResult = DialogResult.Abort Then
                                oSurvey.Properties.DesignWarpingMode = cSurvey.DesignWarpingModeEnum.None
                            End If
                        End If
                    End If

                    For Each oCrossSection As cDesignCrossSection In oSurvey.CrossSections
                        If oCrossSection.CrossSection.Points.Count > 0 Then
                            Dim oFromPoint As PointD = oCrossSection.CrossSection.Points(0).Point
                            Dim oToPoint As PointD = oFromPoint
                            Call oCrossSection.Data.Profile.SetPoints("", "", oFromPoint, oToPoint)
                            Call oCrossSection.Data.ResetWarpingFactor()
                        End If
                    Next

                    If oSurvey.Properties.DesignWarpingMode = cSurvey.DesignWarpingModeEnum.Default Then
                        Dim oCrossSections As cDesignCrossSectionsCollection = oSurvey.CrossSections.GetChangedCrossSections(cIDesign.cDesignTypeEnum.Profile, True)
                        iIndex = 0
                        iCount = oCrossSections.Count
                        If iCount > 0 Then
                            Dim iStep As Integer = IIf(iCount > 20, iCount \ 20, 1)
                            Call oSurvey.RaiseOnProgressEvent("calculate.plot.profile", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("plotprofile.progressbegin2"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageWarping OrElse cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow)
                            For Each oCrossSection As cDesignCrossSection In oCrossSections
                                iIndex += 1
                                If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("calculate.plot.profile", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("plotprofile.progress2"), iIndex / iCount)
                                Call oCrossSection.WarpItems()
                                Call oCrossSection.Data.Profile.ResetChange()
                            Next
                            Call oSurvey.RaiseOnProgressEvent("calculate.plot.profile", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, GetLocalizedString("plotprofile.progressend2"), 0)
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

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement)
            Dim oXmlPlot As XmlElement = Document.CreateElement("plot")
            Call Parent.AppendChild(oXmlPlot)
            Return oXmlPlot
        End Function
    End Class
End Namespace

