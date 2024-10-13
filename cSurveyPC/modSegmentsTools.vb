Imports System.Windows.Media.Media3D
Imports cSurveyPC
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Calculate
Imports cSurveyPC.cSurvey.Design
Imports HelixToolkit.Wpf

Module modSegmentsTools
    Private oDefaultPlanSplayBorderInclinationRange As SizeF = New SizeF(-90, 90)
    Private oDefaultProfileSplayBorderPosInclinationRange As SizeF = New SizeF(0, 90)
    Private oDefaultProfileSplayBorderNegInclinationRange As SizeF = New SizeF(-90, 0)

    Public Function GetDefaultPlanSplayBorderInclinationRange() As SizeF
        Return oDefaultPlanSplayBorderInclinationRange
    End Function

    Public Function GetDefaultProfileSplayBorderPosInclinationRange() As SizeF
        Return oDefaultProfileSplayBorderPosInclinationRange
    End Function

    Public Function GetDefaultProfileSplayBorderNegInclinationRange() As SizeF
        Return oDefaultProfileSplayBorderNegInclinationRange
    End Function

    Public Function GetVisibleSegments(Survey As cSurvey.cSurvey, Segments As cISegmentCollection, PaintOptions As Design.cOptionsDesign) As cSegmentCollection
        Dim oSegmentColl As cSegmentCollection = New cSegmentCollection(Survey)
        For Each oSegment As cSegment In Segments
            If Survey.Properties.CaveVisibilityProfiles.GetVisible(PaintOptions.CurrentCaveVisibilityProfile, oSegment.Cave, oSegment.Branch) Then
                Call oSegmentColl.Append(oSegment)
            End If
        Next
        Return oSegmentColl
    End Function

    Public Function GetVisibleCaveSegments(Survey As cSurvey.cSurvey, Segments As cISegmentCollection, PaintOptions As Design.cOptionsDesign, ByVal Cave As String, Optional ByVal Branch As String = "") As cSegmentCollection
        Dim oSegmentColl As cSegmentCollection = New cSegmentCollection(Survey)
        Dim sCave As String = ("" & Cave).ToLower
        Dim sBranch As String = ("" & Branch).ToLower
        If Survey.Properties.CaveVisibilityProfiles.GetVisible(PaintOptions.CurrentCaveVisibilityProfile, sCave, sBranch) Then
            If sBranch = "" Then
                If sCave = "" Then
                    For Each oSegment As cSegment In Segments
                        Call oSegmentColl.Append(oSegment)
                    Next
                Else
                    For Each oSegment As cSegment In Segments
                        If oSegment.Cave.ToLower = sCave Then
                            Call oSegmentColl.Append(oSegment)
                        End If
                    Next
                End If
            Else
                For Each oSegment As cSegment In Segments
                    If modDesign.GetIfSegmentMustBeDrawedByCaveAndBranch(PaintOptions, oSegment, Cave, Branch) Then
                        Call oSegmentColl.Append(oSegment)
                    End If
                Next
            End If
        End If
        Return oSegmentColl
    End Function

    Public Function GetCaveSegments(Survey As cSurvey.cSurvey, Segments As cISegmentCollection, ByVal Cave As String, Optional ByVal Branch As String = "") As cSegmentCollection
        Dim oSegmentColl As cSegmentCollection = New cSegmentCollection(Survey)
        Dim sCave As String = ("" & Cave).ToLower
        Dim sBranch As String = ("" & Branch).ToLower
        If sBranch = "" Then
            If sCave = "" Then
                For Each oSegment As cSegment In Segments
                    Call oSegmentColl.Append(oSegment)
                Next
            Else
                For Each oSegment As cSegment In Segments
                    If oSegment.Cave.ToLower = sCave Then
                        Call oSegmentColl.Append(oSegment)
                    End If
                Next
            End If
        Else
            For Each oSegment As cSegment In Segments
                If oSegment.Cave.ToLower = sCave AndAlso (oSegment.Branch.ToLower = sBranch OrElse oSegment.Branch.ToLower.StartsWith(sBranch & cCaveInfoBranches.sBranchSeparator)) Then
                    Call oSegmentColl.Append(oSegment)
                End If
            Next
        End If
        Return oSegmentColl
    End Function

    Public Function GetCaveSegments(Survey As cSurvey.cSurvey, Segments As cISegmentCollection, ByVal CaveInfoBranch As cCaveInfoBranch) As cSegmentCollection
        If CaveInfoBranch Is Nothing Then
            Return GetCaveSegments(Survey, Segments, "")
        Else
            Return GetCaveSegments(Survey, Segments, CaveInfoBranch.Cave, CaveInfoBranch.Path)
        End If
    End Function

    Public Function GetCaveSegments(Survey As cSurvey.cSurvey, Segments As cISegmentCollection, ByVal CaveInfo As cCaveInfo) As cSegmentCollection
        If CaveInfo Is Nothing Then
            Return GetCaveSegments(Survey, Segments, "")
        Else
            Return GetCaveSegments(Survey, Segments, CaveInfo.Name)
        End If
    End Function

    Public Function GetSessionSegments(Survey As cSurvey.cSurvey, Segments As cISegmentCollection, ByVal SessionID As String, Optional Flags As cISegmentCollection.SessionSegmentsFlagEnum = cISegmentCollection.SessionSegmentsFlagEnum.SurveyShots) As cSegmentCollection
        Return New cSegmentCollection(Survey, Segments.Where(Function(item) item.IsValid AndAlso item.Session = SessionID AndAlso Not item.Virtual AndAlso
                                                                 (((Flags = cISegmentCollection.SessionSegmentsFlagEnum.CalibrationShots AndAlso item.Calibration)) OrElse
                                                                 ((Flags = cISegmentCollection.SessionSegmentsFlagEnum.SurveyShots AndAlso Not item.Calibration)))))
    End Function

    Public Function GetSessionSegments(Survey As cSurvey.cSurvey, Segments As cISegmentCollection, ByVal Session As cSession, Optional Flags As cISegmentCollection.SessionSegmentsFlagEnum = cISegmentCollection.SessionSegmentsFlagEnum.SurveyShots) As cSegmentCollection
        If Session Is Nothing Then
            Return GetSessionSegments(Survey, Segments, "", Flags)
        Else
            Return GetSessionSegments(Survey, Segments, Session.ID, Flags)
        End If
    End Function

    Public Function GetBindedItems(Survey As cSurvey.cSurvey, Segments As cISegmentCollection) As List(Of Design.cItem)
        Dim oItems As List(Of Design.cItem) = New List(Of Design.cItem)
        For Each oItem As Design.cItem In Survey.GetAllDesignItems
            For Each oPoint As Design.cPoint In oItem.Points
                If Segments.Contains(oPoint.BindedSegment) Then
                    Call oItems.Add(oItem)
                    Exit For
                End If
            Next
        Next
        Return oItems
    End Function

    Public Function GetBindedItems(Survey As cSurvey.cSurvey, Segments As cISegmentCollection, Design As cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum) As List(Of Design.cItem)
        Dim oItems As List(Of Design.cItem) = New List(Of Design.cItem)
        Dim oDesign As Design.cDesign
        Select Case Design
            Case cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum.Plan
                oDesign = Survey.Plan
            Case cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum.Profile
                oDesign = Survey.Profile
        End Select
        For Each oItem As Design.cItem In oDesign.GetAllItems
            For Each oPoint As Design.cPoint In oItem.Points
                If Segments.Contains(oPoint.BindedSegment) Then
                    Call oItems.Add(oItem)
                    Exit For
                End If
            Next
        Next
        Return oItems
    End Function

    Public Function GetBindedSegments(Survey As cSurvey.cSurvey, Segments As cISegmentCollection) As cSegmentCollection
        Dim oSegmentColl As cSegmentCollection = New cSegmentCollection(Survey)
        For Each oitem As Design.cItem In Survey.GetAllDesignItems
            For Each oPoint As Design.cPoint In oitem.Points
                Dim oSegment As cISegment = oPoint.BindedSegment
                If Not oSegment Is Nothing Then
                    If Not oSegmentColl.Contains(oSegment) Then
                        Call oSegmentColl.Append(oSegment)
                    End If
                End If
            Next
        Next
        Return oSegmentColl
    End Function

    Public Function GetBindedSegments(Survey As cSurvey.cSurvey, Segments As cISegmentCollection, Design As cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum) As cSegmentCollection
        Dim oSegmentColl As cSegmentCollection = New cSegmentCollection(Survey)
        Dim oDesign As Design.cDesign
        Select Case Design
            Case cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum.Plan
                oDesign = Survey.Plan
            Case cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum.Profile
                oDesign = Survey.Profile
        End Select
        For Each oitem As Design.cItem In oDesign.GetAllItems
            For Each oPoint As Design.cPoint In oitem.Points
                Dim oSegment As cISegment = oPoint.BindedSegment
                If Not oSegment Is Nothing Then
                    If Not oSegmentColl.Contains(oSegment) Then
                        Call oSegmentColl.Append(oSegment)
                    End If
                End If
            Next
        Next
        Return oSegmentColl
    End Function

    Public Enum MeasureEnum
        Distance = 0
        Bearing = 1
        Inclination = 2
    End Enum

    Public Function GetMeasureName(Session As cSession, Measure As MeasureEnum) As String
        Select Case Session.DataFormat
            Case cSegment.DataFormatEnum.Normal
                Select Case Measure
                    Case MeasureEnum.Distance
                        Return GetLocalizedString("main.textpart34")
                    Case MeasureEnum.Bearing
                        Return GetLocalizedString("main.textpart35")
                    Case MeasureEnum.Inclination
                        Return GetLocalizedString("main.textpart36")
                End Select
            Case cSegment.DataFormatEnum.Cartesian
                Select Case Measure
                    Case MeasureEnum.Distance
                        Return GetLocalizedString("main.textpart37")
                    Case MeasureEnum.Bearing
                        Return GetLocalizedString("main.textpart38")
                    Case MeasureEnum.Inclination
                        Return GetLocalizedString("main.textpart39")
                End Select
            Case cSegment.DataFormatEnum.Diving
                Select Case Measure
                    Case MeasureEnum.Distance
                        Return GetLocalizedString("main.textpart63")
                    Case MeasureEnum.Bearing
                        Return GetLocalizedString("main.textpart64")
                    Case MeasureEnum.Inclination
                        Return GetLocalizedString("main.textpart65")
                End Select
            Case cSegment.DataFormatEnum.Cylpolar
                Select Case Measure
                    Case MeasureEnum.Distance
                        Return GetLocalizedString("main.textpart66")
                    Case MeasureEnum.Bearing
                        Return GetLocalizedString("main.textpart67")
                    Case MeasureEnum.Inclination
                        Return GetLocalizedString("main.textpart68")
                End Select
        End Select
    End Function

    Public Function GetMeasureName(Segment As cSegment, Measure As MeasureEnum) As String
        Select Case Segment.GetDataFormat
            Case cSegment.DataFormatEnum.Normal
                Select Case Measure
                    Case MeasureEnum.Distance
                        Return GetLocalizedString("main.textpart34")
                    Case MeasureEnum.Bearing
                        Return GetLocalizedString("main.textpart35")
                    Case MeasureEnum.Inclination
                        Return GetLocalizedString("main.textpart36")
                End Select
            Case cSegment.DataFormatEnum.Cartesian
                Select Case Measure
                    Case MeasureEnum.Distance
                        Return GetLocalizedString("main.textpart37")
                    Case MeasureEnum.Bearing
                        Return GetLocalizedString("main.textpart38")
                    Case MeasureEnum.Inclination
                        Return GetLocalizedString("main.textpart39")
                End Select
            Case cSegment.DataFormatEnum.Diving
                Select Case Measure
                    Case MeasureEnum.Distance
                        Return GetLocalizedString("main.textpart63")
                    Case MeasureEnum.Bearing
                        Return GetLocalizedString("main.textpart64")
                    Case MeasureEnum.Inclination
                        Return GetLocalizedString("main.textpart65")
                End Select
            Case cSegment.DataFormatEnum.Cylpolar
                Select Case Measure
                    Case MeasureEnum.Distance
                        Return GetLocalizedString("main.textpart66")
                    Case MeasureEnum.Bearing
                        Return GetLocalizedString("main.textpart67")
                    Case MeasureEnum.Inclination
                        Return GetLocalizedString("main.textpart68")
                End Select
        End Select
    End Function

    Public Enum BorderHullEnum
        None = 0
        ConvexHull = 1
    End Enum

    Private Const dMinSize As Decimal = 0.3

    Private Function pGetShape(Center As PointD, Width As Decimal, Height As Decimal, Optional ByVal NumberOfSides As Integer = 3, Optional ByVal OffsetAngleInDegrees As Double = 0) As List(Of PointD)
        Dim oRes As List(Of PointD) = New List(Of PointD)
        If NumberOfSides < 3 Then Throw New Exception("Number of sides can only be 3 or more.")
        Dim dAngle As Decimal = OffsetAngleInDegrees / (180 / Math.PI)
        Dim dRadius1 As Decimal = Height / 2
        Dim dRadius2 As Decimal = Width / 2
        For angle As Double = dAngle To ((2 * Math.PI) + dAngle) Step ((2 * Math.PI) / NumberOfSides)
            Dim x As Decimal = Center.X - Width / 2 + (dRadius2 * Math.Cos(angle) + dRadius2)
            Dim y As Decimal = Center.Y - Height / 2 + (dRadius1 * Math.Sin(angle) + dRadius1)
            Call oRes.Add(New PointD(x, y))
        Next
        Return oRes
    End Function

    'add point in the process collection
    Private Sub pCreateBorderPathFromSplayAddPoint(SortedSplayPoints As SortedDictionary(Of Decimal, PointD), FromPoint As PointD, SplayPoint As PointD, AngularPrecision As Decimal)
        Dim dBearing As Decimal = modPaint.GetBearing(FromPoint, SplayPoint)
        If AngularPrecision > 1 Then
            dBearing = (dBearing \ AngularPrecision) * AngularPrecision
        End If
        If SortedSplayPoints.ContainsKey(dBearing) Then
            Dim dNewDistance As Decimal = modPaint.DistancePointToPoint(FromPoint, SplayPoint)
            Dim dOldDistance As Decimal = modPaint.DistancePointToPoint(FromPoint, SortedSplayPoints(dBearing))
            If dNewDistance > dOldDistance Then
                Call SortedSplayPoints.Remove(dBearing)
                Call SortedSplayPoints.Add(dBearing, SplayPoint)
            End If
        Else
            Call SortedSplayPoints.Add(dBearing, SplayPoint)
        End If
    End Sub

    Private Function pCreatePlanBorderPathFromSplay(Segment As cSegment, AngularPrecision As Decimal, UseHull As BorderHullEnum) As List(Of PointD)
        Dim oFromPoint As PointD = Segment.Data.Plan.FromPoint
        Dim oToPoint As PointD = Segment.Data.Plan.ToPoint
        Dim bUseConvexHull As Boolean = (UseHull And BorderHullEnum.ConvexHull) = BorderHullEnum.ConvexHull

        Dim oClipper As ClipperLib.Clipper = New ClipperLib.Clipper
        Dim bFirst As Boolean

        Dim oSplayPolygon As List(Of PointD) = New List(Of PointD)
        'add a minimun shape around a station...
        Call oClipper.AddPolygon(modClipper.ToIntPolygon(pGetShape(oFromPoint, dMinSize, dMinSize, 8), 100), PolyType.ptSubject)
        If Segment.Data.Plan.FromSplays.Count > 0 Then
            bFirst = True
            'add splay points...
            Dim oSortedSplayPoints As SortedDictionary(Of Decimal, PointD) = New SortedDictionary(Of Decimal, PointD)
            For Each oItem As Plot.cSplayPlanProjectedData In Segment.Data.Plan.FromSplays
                Call pCreateBorderPathFromSplayAddPoint(oSortedSplayPoints, oFromPoint, oItem.ToPoint, AngularPrecision)
            Next
            'add to point...
            Call pCreateBorderPathFromSplayAddPoint(oSortedSplayPoints, oFromPoint, oToPoint, AngularPrecision)
            'add other segment's stations connected with this
            '(without a shape)
            For Each oSegment As cSegment In Segment.Survey.Segments.Find(Segment.Data.Data.From)
                If oSegment.IsValid AndAlso Not oSegment.Splay Then
                    If oSegment.Data.Data.From = Segment.Data.Data.From Then
                        Call pCreateBorderPathFromSplayAddPoint(oSortedSplayPoints, oFromPoint, oSegment.Data.Plan.ToPoint, AngularPrecision)
                    End If
                    If oSegment.Data.Data.To = Segment.Data.Data.From Then
                        Call pCreateBorderPathFromSplayAddPoint(oSortedSplayPoints, oFromPoint, oSegment.Data.Plan.FromPoint, AngularPrecision)
                    End If
                End If
            Next
            For Each oPoint In oSortedSplayPoints.Values
                Call oSplayPolygon.Add(oPoint)
            Next
            If Not modPaint.PointInPolygon(oFromPoint, oSplayPolygon) Then
                Call oSplayPolygon.Add(oFromPoint)
            End If
        End If
        If bUseConvexHull Then
            oSplayPolygon = pConvexHull(oSplayPolygon, True)
        End If
        Call oClipper.AddPolygon(modClipper.ToIntPolygon(oSplayPolygon, 100), PolyType.ptSubject)

        Call oSplayPolygon.Clear()
        'add a minimun shape around a station...
        Call oClipper.AddPolygon(modClipper.ToIntPolygon(pGetShape(oToPoint, dMinSize, dMinSize, 8), 100), PolyType.ptSubject)
        If Segment.Data.Plan.ToSplays.Count > 0 Then
            bFirst = True
            Dim oSortedSplayPoints As SortedDictionary(Of Decimal, PointD) = New SortedDictionary(Of Decimal, PointD)
            For Each oItem As Plot.cSplayPlanProjectedData In Segment.Data.Plan.ToSplays
                Call pCreateBorderPathFromSplayAddPoint(oSortedSplayPoints, oToPoint, oItem.ToPoint, AngularPrecision)
            Next
            Call pCreateBorderPathFromSplayAddPoint(oSortedSplayPoints, oToPoint, oFromPoint, AngularPrecision)
            For Each oSegment As cSegment In Segment.Survey.Segments.Find(Segment.Data.Data.To)
                If oSegment.IsValid AndAlso Not oSegment.Splay Then
                    If oSegment.Data.Data.From = Segment.Data.Data.To Then
                        Call pCreateBorderPathFromSplayAddPoint(oSortedSplayPoints, oToPoint, oSegment.Data.Plan.ToPoint, AngularPrecision)
                    End If
                    If oSegment.Data.Data.To = Segment.Data.Data.To Then
                        Call pCreateBorderPathFromSplayAddPoint(oSortedSplayPoints, oToPoint, oSegment.Data.Plan.FromPoint, AngularPrecision)
                    End If
                End If
            Next

            For Each oPoint In oSortedSplayPoints.Values
                Call oSplayPolygon.Add(oPoint)
            Next
            If Not modPaint.PointInPolygon(oToPoint, oSplayPolygon) Then
                Call oSplayPolygon.Add(oToPoint)
            End If
        End If
        If bUseConvexHull Then
            oSplayPolygon = pConvexHull(oSplayPolygon, True)
        End If
        Call oClipper.AddPolygon(modClipper.ToIntPolygon(oSplayPolygon, 100), PolyType.ptSubject)

        Dim oSolution As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
        If oClipper.Execute(ClipType.ctUnion, oSolution, PolyFillType.pftNonZero, PolyFillType.pftNonZero) Then
            Return modClipper.FromIntPolygonToPointD(oSolution(0), 100)
        End If
        Return Nothing
    End Function

    Private Function pCreatePlanBorderFromSplay(Survey As cSurvey.cSurvey, Cave As String, Branch As String, AngularPrecision As Decimal, UseHull As BorderHullEnum) As List(Of List(Of PointD))
        Dim oSegmentColl As cSegmentCollection
        If Branch = "" Then
            oSegmentColl = Survey.Properties.CaveInfos(Cave).GetSegments
        Else
            oSegmentColl = Survey.Properties.CaveInfos(Cave).Branches(Branch).GetSegments
        End If
        Dim oClipper As ClipperLib.Clipper = New ClipperLib.Clipper
        For Each oSegment As cSegment In oSegmentColl
            If oSegment.IsValid AndAlso Not oSegment.Splay AndAlso Not oSegment.Surface AndAlso Not oSegment.Duplicate Then
                Dim oSegmentPoly As List(Of PointD) = pCreatePlanBorderPathFromSplay(oSegment, AngularPrecision, UseHull)
                If Not IsNothing(oSegmentPoly) Then
                    Dim oRegion As Region = New Region()
                    Call oClipper.AddPolygon(modClipper.ToIntPolygon(oSegmentPoly, 100), PolyType.ptSubject)
                End If
            End If
        Next
        Dim oSolution As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
        If oClipper.Execute(ClipType.ctUnion, oSolution, PolyFillType.pftNonZero, PolyFillType.pftNonZero) Then
            Return modClipper.FromIntPolygonsToPointD(oSolution, 100)
        End If
        Return Nothing
    End Function

    Public Function CreatePlanBorderFromSplay(Survey As cSurvey.cSurvey, Cave As String, Branch As String, LineType As Design.Items.cIItemLine.LineTypeEnum, AngularPrecision As Decimal, UseHull As BorderHullEnum) As List(Of Design.Items.cItemInvertedFreeHandArea)
        Dim oPolygons As List(Of List(Of PointD)) = pCreatePlanBorderFromSplay(Survey, Cave, Branch, AngularPrecision, UseHull)
        If Not IsNothing(oPolygons) Then
            Dim oItem As Design.Items.cItemInvertedFreeHandArea = DirectCast(Survey.Plan.Layers.Item(Design.cLayers.LayerTypeEnum.Borders), Design.Layers.cLayerBorders).CreateCaveBorder(Cave, Branch)
            oItem.LineType = LineType
            For Each oPolygon As List(Of PointD) In oPolygons
                Call oItem.Points.StartSequence()
                Dim oFirstPoint As PointD = oPolygon.FirstOrDefault
                For Each oPoint As PointD In oPolygon
                    Call oItem.Points.AddFromPaintPoint(oPoint)
                Next
                Call oItem.Points.AddFromPaintPoint(oFirstPoint)
            Next
            Dim oResult As List(Of Design.Items.cItemInvertedFreeHandArea) = New List(Of Design.Items.cItemInvertedFreeHandArea)
            Call oResult.Add(oItem)
            Return oResult
        End If
    End Function

    Public Function CreateBorder3DOutline(Survey As cSurvey.cSurvey, Cave As String, Branch As String, PlanOrProfile As Boolean) As List(Of Design.Items.cItemInvertedFreeHandArea)
        Return pCreateBorder3DOutline(Survey, Cave, Branch, Nothing, PlanOrProfile)
    End Function

    Public Function CreateBorder3DOutline(Survey As cSurvey.cSurvey, Segment As cSegment, PlanOrProfile As Boolean) As List(Of Design.Items.cItemInvertedFreeHandArea)
        Return pCreateBorder3DOutline(Survey, "", "", Segment, PlanOrProfile)
    End Function

    Private Function pCreateBorder3DOutline(Survey As cSurvey.cSurvey, Cave As String, Branch As String, Segment As cSegment, PlanOrProfile As Boolean) As List(Of Design.Items.cItemInvertedFreeHandArea)
        Dim oCurrentOptions As cOptions3D = Survey.Options("_design.3d")
        Dim oStationToCMPiketDict = New Dictionary(Of String, Integer)
        Dim oCMPiketToStationDict = New Dictionary(Of Integer, String)
        Dim cmCave = New DNetCMCave
        Dim oPoints = cHolosViewer.Get3DPoints(Survey, oCurrentOptions, 0, 0, 0, 1)
        Dim addStationFunc = Sub(Station As String, extendedElevationX As Double)
                                 If Not oStationToCMPiketDict.ContainsKey(Station) Then
                                     Dim oStation As cSurvey.cTrigPoint = Survey.TrigPoints(Station)
                                     Dim piket As DNPiketInfo = New DNPiketInfo
                                     Dim pos3D As Point3D = oPoints(Station)(cHolosViewer.SubPointIndexEnum.Center)
                                     piket.name = Station
                                     piket.label = Station
                                     piket.x = pos3D.X
                                     piket.y = pos3D.Y
                                     piket.z = pos3D.Z
                                     piket.extendedElevationX = extendedElevationX
                                     'piket.r = 0
                                     'piket.g = 0
                                     'piket.b = 0
                                     'If (zSurvey) Then piket.priz = piket.priz Or DNPike(tMark.MARK_Z_SURVEY

                                     'if ostation is nothing is because is not a real station but a subdata station...so 
                                     'it cannot be zturn station...
                                     If Not IsNothing(oStation) AndAlso oStation.ZTurn Then piket.priz = piket.priz Or DNPiketMark.MARK_Z_TURN

                                     cmCave.addVertice(piket, 0)

                                     Dim left As Point3D = oPoints(Station)((cHolosViewer.SubPointIndexEnum.Left))
                                     Dim right As Point3D = oPoints(Station)((cHolosViewer.SubPointIndexEnum.Right))
                                     Dim up As Point3D = oPoints(Station)((cHolosViewer.SubPointIndexEnum.Up))
                                     Dim down As Point3D = oPoints(Station)((cHolosViewer.SubPointIndexEnum.Down))
                                     If pos3D.DistanceTo(left) > 0.001 Then
                                         cmCave.addWall(left.X, left.Y, left.Z, piket.id, piket.id)
                                     End If
                                     If pos3D.DistanceTo(right) > 0.001 Then
                                         cmCave.addWall(right.X, right.Y, right.Z, piket.id, piket.id)
                                     End If
                                     If pos3D.DistanceTo(up) > 0.001 Then
                                         cmCave.addWall(up.X, up.Y, up.Z, piket.id, piket.id)
                                     End If
                                     If pos3D.DistanceTo(down) > 0.001 Then
                                         cmCave.addWall(down.X, down.Y, down.Z, piket.id, piket.id)
                                     End If

                                     oStationToCMPiketDict(Station) = piket.id
                                     oCMPiketToStationDict(piket.id) = Station
                                 End If
                             End Sub

        For Each oCaveInfo As cSurvey.cCaveInfo In Survey.Properties.CaveInfos.GetWithEmpty.Values
            For Each oCaveInfoBranch As cSurvey.cCaveInfoBranch In oCaveInfo.Branches.GetAllBranchesWithEmpty.Values
                For Each oShot As cSurvey.cSegment In oCaveInfoBranch.GetSegments
                    If Cave = "" OrElse oShot.Cave = Cave Then
                        If Branch = "" OrElse oShot.Branch = Branch Then
                            If IsNothing(Segment) OrElse oShot Is Segment Then
                                If oShot.IsValid AndAlso Not oShot.IsSelfDefined Then
                                    If oShot.Cut Then
                                        addStationFunc(oShot.Data.Data.From, oShot.Data.Profile.FromPoint.X)
                                        Dim toPos As Point3D = oPoints(oShot.Data.Data.To)(0)
                                        cmCave.addWall(toPos.X, toPos.Y, toPos.Z, oStationToCMPiketDict(oShot.Data.Data.From))
                                    ElseIf Not oShot.Surface AndAlso Not oShot.Duplicate AndAlso Not oShot.Splay Then
                                        addStationFunc(oShot.Data.Data.From, oShot.Data.Profile.FromPoint.X)
                                        addStationFunc(oShot.Data.Data.To, oShot.Data.Profile.ToPoint.X)
                                        cmCave.addEdge(oStationToCMPiketDict(oShot.Data.Data.From), oStationToCMPiketDict(oShot.Data.Data.To), oShot.ZSurvey, 0.5F, 0.5F, 0.5F)
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next
            Next
        Next

        If (PlanOrProfile) Then
            cmCave.setShouldConvertToExtendedElevation(True)
            cmCave.setLookDirection(0, -1, 0)
        Else
            cmCave.setLookDirection(0, 0, -1)
        End If

        cmCave.finishInit(DMOuputType.OT_NONE)

        Dim outline As List(Of DNCrossPiketLineBesier3) = cmCave.calcOutineBesier()

        Dim oBordersByShot As Dictionary(Of String, List(Of Object)) = New Dictionary(Of String, List(Of Object))
        For Each lineBezier In outline
            Dim fromStation = oCMPiketToStationDict(lineBezier.aid)
            Dim toStation = oCMPiketToStationDict(lineBezier.bid)

            'lineBezier.points { {ax, ay, az}, { acx, acy, acz }, { bcx, bcy, bcz }, {bx, by, bz} };
            Dim secondAxis As Integer
            If (PlanOrProfile) Then
                secondAxis = 2
            Else
                secondAxis = 1
            End If

            Dim start = New PointF(lineBezier.points(0, 0), -lineBezier.points(0, secondAxis))
            Dim startControl = New PointF(lineBezier.points(1, 0), -lineBezier.points(1, secondAxis))
            Dim finishControl = New PointF(lineBezier.points(2, 0), -lineBezier.points(2, secondAxis))
            Dim finish = New PointF(lineBezier.points(3, 0), -lineBezier.points(3, secondAxis))

            Dim sKey As String = fromStation & "::" & toStation
            If Not oBordersByShot.ContainsKey(sKey) Then
                Call oBordersByShot.Add(sKey, New List(Of Object))
            End If
            Call oBordersByShot(sKey).Add({start, startControl, finishControl, finish})

        Next

        Dim oPointsToJoint As Dictionary(Of PointF, cPoint) = New Dictionary(Of PointF, cPoint)

        Dim oResult As List(Of Design.Items.cItemInvertedFreeHandArea) = New List(Of Design.Items.cItemInvertedFreeHandArea)
        For Each sShot As String In oBordersByShot.Keys
            Dim oItem As Design.Items.cItemInvertedFreeHandArea
            If PlanOrProfile Then
                oItem = DirectCast(Survey.Profile.Layers.Item(Design.cLayers.LayerTypeEnum.Borders), Design.Layers.cLayerBorders).CreateCaveBorder("", "")
            Else
                oItem = DirectCast(Survey.Plan.Layers.Item(Design.cLayers.LayerTypeEnum.Borders), Design.Layers.cLayerBorders).CreateCaveBorder("", "")
            End If
            If IsNothing(Segment) Then
                Call oItem.SetCave(Cave, Branch)
            Else
                Call oItem.SetCave(Segment.Cave, Segment.Branch)
            End If
            oItem.LineType = Items.cIItemLine.LineTypeEnum.Beziers

            Dim oList As List(Of Object) = oBordersByShot(sShot)
            Dim start1 As PointF = oList(0)(0)
            Dim startControl1 As PointF = oList(0)(1)
            Dim finishControl1 As PointF = oList(0)(2)
            Dim finish1 As PointF = oList(0)(3)
            Dim oFirstPoint1 As cPoint = oItem.Points.AddFromPaintPoint(start1)
            oFirstPoint1.BeginSequence = True
            oItem.Points.AddFromPaintPoint(startControl1)
            oItem.Points.AddFromPaintPoint(finishControl1)
            Dim oLastPoint1 As cPoint = oItem.Points.AddFromPaintPoint(finish1)

            If oPointsToJoint.ContainsKey(oFirstPoint1.Point) Then
                Call oFirstPoint1.Join(oPointsToJoint(oFirstPoint1.Point))
            Else
                Call oPointsToJoint.Add(oFirstPoint1.Point, oFirstPoint1)
            End If
            If oPointsToJoint.ContainsKey(oLastPoint1.Point) Then
                Call oLastPoint1.Join(oPointsToJoint(oLastPoint1.Point))
            Else
                Call oPointsToJoint.Add(oLastPoint1.Point, oLastPoint1)
            End If

            Dim start2 As PointF = oList(1)(0)
            Dim startControl2 As PointF = oList(1)(1)
            Dim finishControl2 As PointF = oList(1)(2)
            Dim finish2 As PointF = oList(1)(3)
            Dim oFirstPoint2 As cPoint = oItem.Points.AddFromPaintPoint(finish2)
            oFirstPoint2.BeginSequence = True
            oItem.Points.AddFromPaintPoint(finishControl2)
            oItem.Points.AddFromPaintPoint(startControl2)
            Dim oLastPoint2 As cPoint = oItem.Points.AddFromPaintPoint(start2)
            Call oResult.Add(oItem)

            If oPointsToJoint.ContainsKey(oFirstPoint2.Point) Then
                Call oFirstPoint2.Join(oPointsToJoint(oFirstPoint2.Point))
            Else
                Call oPointsToJoint.Add(oFirstPoint2.Point, oFirstPoint2)
            End If
            If oPointsToJoint.ContainsKey(oLastPoint2.Point) Then
                Call oLastPoint2.Join(oPointsToJoint(oLastPoint2.Point))
            Else
                Call oPointsToJoint.Add(oLastPoint2.Point, oLastPoint2)
            End If
        Next

        Return oResult
    End Function

    Public Function CreatePlanBorderFromSplay(Survey As cSurvey.cSurvey, Segment As cSegment, LineType As Design.Items.cIItemLine.LineTypeEnum, AngularPrecision As Decimal, UseHull As BorderHullEnum) As Design.Items.cItemInvertedFreeHandArea
        Dim oPoints As List(Of PointD) = pCreatePlanBorderPathFromSplay(Segment, AngularPrecision, UseHull)
        If Not IsNothing(oPoints) Then
            Dim oItem As Design.Items.cItemInvertedFreeHandArea = DirectCast(Survey.Plan.Layers.Item(Design.cLayers.LayerTypeEnum.Borders), Design.Layers.cLayerBorders).CreateCaveBorder(Segment.Cave, Segment.Branch)
            oItem.LineType = LineType
            Dim oFirstPoint As PointD = oPoints.FirstOrDefault
            For Each oPoint As PointD In oPoints
                Call oItem.Points.AddFromPaintPoint(oPoint)
            Next
            Call oItem.Points.AddFromPaintPoint(oFirstPoint)
            Return oItem
        End If
    End Function

    Private Function pCreateProfileBorderPathFromSplay() As PointD()

    End Function

    Public Function CreateProfileBorderFromSplay() As Design.Items.cItemInvertedFreeHandArea

    End Function

    'Returns the CrossProduct of P1 and P2 with the current Point being the Vertex
    Public Function CrossProduct(ByRef P0 As PointD, ByRef P1 As PointD, ByRef P2 As PointD) As Double
        'Ax * By - Bx * Ay
        Return (P1.X - P0.X) * (P2.Y - P0.Y) - (P2.X - P0.X) * (P1.Y - P0.Y)
    End Function

    'Returns the DotProduct of P1 and P2 with the current Point being the Vertex
    Public Function DotProduct(ByRef P0 As PointD, ByRef P1 As PointD, ByRef P2 As PointD) As Double
        'Ax * Bx + Ay * Cy
        Return (P1.X - P0.X) * (P2.X - P0.X) + (P1.Y - P0.Y) * (P2.Y - P0.Y)
    End Function

    Private Function pFindNearest(Points As List(Of PointD), Point As PointD, MaxDistance As Decimal, MaxElements As Integer, StationFrom As PointD, StationTo As PointD) As List(Of PointD)
        Do
            Dim oPointsByDistance As SortedDictionary(Of Decimal, PointD) = New SortedDictionary(Of Decimal, PointD)
            For Each oPoint As PointD In Points
                If oPoint = StationFrom OrElse Point = StationFrom OrElse oPoint = StationTo OrElse Point = StationTo OrElse Not modPaint.SegmentsIntersect(Point, oPoint, StationFrom, StationTo) Then
                    Dim dDistance As Decimal = modPaint.DistancePointToPoint(oPoint, Point)
                    If dDistance > 0.1 AndAlso dDistance <= MaxDistance Then
                        Call oPointsByDistance.Add(modPaint.DistancePointToPoint(oPoint, Point), oPoint)
                    End If
                End If
            Next
            If oPointsByDistance.Count > 0 Then
                If oPointsByDistance.Count > MaxElements Then
                    Return oPointsByDistance.Values.ToList.GetRange(0, MaxElements)
                Else
                    Return oPointsByDistance.Values.ToList
                End If
            Else
                MaxDistance += 1
            End If
        Loop
    End Function

    Private Function pConcaveHull(Polygon As List(Of PointD), MaxDistance As Decimal, K As Integer, StationFrom As PointD, StationTo As PointD) As List(Of PointD)
        If Polygon.Count < 4 Then
            Return Polygon
        Else
            Do
                Dim oHull As List(Of PointD) = New List(Of PointD)
                Dim oPoints As List(Of PointD) = New List(Of PointD)(Polygon)
                'find the y lowest point...
                Dim oFirstPoint As PointD = Polygon.OrderBy(Function(item) item.Y).LastOrDefault
                Call oHull.Add(oFirstPoint)
                Dim oPoint As PointD = oFirstPoint
                Dim dBearing As Decimal = 180
                Do
                    Dim oNearestPoints As List(Of PointD) = pFindNearest(oPoints, oPoint, MaxDistance, K, StationFrom, StationTo)
                    Dim oNearestPointsByAngle As SortedDictionary(Of Decimal, PointD) = New SortedDictionary(Of Decimal, PointD)
                    For Each oNearestPoint As PointD In oNearestPoints
                        Dim dNearestBearing As Decimal = modPaint.NormalizeAngle(modPaint.GetBearing(oPoint, oNearestPoint) - dBearing)
                        If Not oNearestPointsByAngle.ContainsKey(dNearestBearing) Then
                            Call oNearestPointsByAngle.Add(dNearestBearing, oNearestPoint)
                        End If
                    Next
                    Dim oNextPoint As PointD = oNearestPointsByAngle.Values.LastOrDefault
                    Dim dNextBearing As Decimal = oNearestPointsByAngle.Keys.LastOrDefault
                    If oNextPoint = oFirstPoint Then
                        Call oHull.Add(oNextPoint)
                        Exit Do
                    End If
                    Call oHull.Add(oNextPoint)
                    oPoint = oNextPoint
                    dBearing = dNextBearing
                    Call oPoints.Remove(oPoint)
                Loop
                'If modPaint.PointsInPolygon(Polygon, oHull) Then
                Return oHull
                'Else
                'K = K + 1
                'End If
            Loop
        End If
    End Function

    Private Function pConvexHull(Poligon As List(Of PointD), Optional ByVal OnBorder As Boolean = False) As List(Of PointD)
        'The Convex Hull will be the current points (unless there are three co-linear points and OnBorder = False... we will ignore this case)
        If Poligon.Count <= 3 Then Return Poligon

        Dim Res As List(Of PointD) = New List(Of PointD)
        Dim StartIndex As Integer = 0

        'Find the starting index of the hull by finding the leftmost point in the polygon
        Dim I As Long
        For I = 1 To Poligon.Count - 1
            If Poligon(I).X < Poligon(StartIndex).X Then
                'Point is Left Most
                StartIndex = I
            ElseIf Poligon(I).X = Poligon(StartIndex).X Then
                'Point is tied for left most, see if it's higher
                If Poligon(I).Y < Poligon(StartIndex).Y Then
                    StartIndex = I
                End If
            End If
        Next

        Dim InHull(Poligon.Count - 1) As Boolean

        'Sort until we get back to StartIndex
        Dim LastIndex As Integer = StartIndex
        Do
            Dim Selected As Integer = -1
            For I = 0 To Poligon.Count - 1
                If Not InHull(I) And I <> LastIndex Then
                    If Selected = -1 Then
                        'No point has been selected yet, select this one
                        Selected = I
                    Else
                        Dim Cross As Double = CrossProduct(Poligon(I), Poligon(LastIndex), Poligon(Selected))
                        If Cross = 0.0 Then
                            'On the line
                            If OnBorder Then
                                'Since we want the points on the border, take the one closer to LastIndex
                                If DotProduct(Poligon(LastIndex), Poligon(I), Poligon(I)) <
                                   DotProduct(Poligon(LastIndex), Poligon(Selected), Poligon(Selected)) Then
                                    Selected = I
                                End If
                                'Since we don't want the points on the border, take the one further from LastIndex
                            ElseIf DotProduct(Poligon(LastIndex), Poligon(I), Poligon(I)) >
                                    DotProduct(Poligon(LastIndex), Poligon(Selected), Poligon(Selected)) Then
                                Selected = I
                            End If
                        ElseIf Cross < 0.0 Then
                            'GetPoint(I) is more counter-clockwise
                            Selected = I
                        End If
                    End If
                End If
            Next
            'Set LastIndex to the final Selected point
            LastIndex = Selected

            'Update the InHull array to know this point has been added to the hull
            InHull(LastIndex) = True

            'Add the point
            Res.Add(Poligon(LastIndex))
        Loop While LastIndex <> StartIndex 'Check if we're back to the starting point

        Return Res
    End Function
End Module
