Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Module modDesignLRUD

#Region "GetLRUDFromDesign"
    Public Enum GetDesignStationEnum
        [From] = 0
        [To] = 1
    End Enum

    Private Function GetCaveAndBranchList(Survey As cSurvey.cSurvey, Segment As cSegment, SegmentData As cSurveyPC.cSurvey.Calculate.Plot.cIProjectedData, FromOrTo As GetDesignStationEnum) As Dictionary(Of String, modCaveAndBranch.cCaveBranchPlaceholder)
        'CREO UN ELENCO DELLE GROTTE/RAMI DA DISEGNARE...dovrebbe essere elencato l'insieme grotte/ramo delle battute che partono dal caposaldo indicato...
        Dim oCaveAndBraches As Dictionary(Of String, modCaveAndBranch.cCaveBranchPlaceholder) = New Dictionary(Of String, cCaveBranchPlaceholder)
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim sKey As String = Segment.Cave & "|" & Segment.Branch
        Call oCaveAndBraches.Add(sKey, New modCaveAndBranch.cCaveBranchPlaceholder(Segment.Cave, Segment.Branch))
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim sStation As String
        If FromOrTo = GetDesignStationEnum.From Then
            sStation = SegmentData.From
        Else
            sStation = SegmentData.To
        End If
        If Survey.TrigPoints.Contains(sStation) Then
            Dim oSegments As cSegmentCollection = Survey.TrigPoints(sStation).GetSegments
            For Each oSegment As cSegment In oSegments
                sKey = oSegment.Cave & "|" & oSegment.Branch
                If Not oCaveAndBraches.ContainsKey(sKey) Then
                    Call oCaveAndBraches.Add(sKey, New modCaveAndBranch.cCaveBranchPlaceholder(oSegment.Cave, oSegment.Branch))
                End If
            Next
        End If
        Return oCaveAndBraches
    End Function

    Friend Class cLRFromDesignCache
        Implements IDisposable

        Private oSurvey As cSurvey.cSurvey

        Private oItems As List(Of Design.Items.cItemInvertedFreeHandArea)
        Private oAllItems As List(Of Design.Items.cItemInvertedFreeHandArea)

        Private bIsEmpty As Boolean

        Private sFlatness As Single

        Public Function Intersect(Point1 As PointF, point2 As PointF, ByRef IntersectionPoint As PointF, ByRef Distance As Single) As Boolean
            Dim sMinDistance As Single = Single.MaxValue
            Dim oMinResult As PointF
            Dim bIntersect As Boolean
            For Each oItem As cItemInvertedFreeHandArea In oItems
                For Each oSequence As cSequence In oItem.Points.GetSequences
                    Dim oFlatSequence As List(Of PointF) = modPaint.ToStraightLinePoints(oItem.Survey, oSequence, DirectCast(oItem, Items.cIItemLine).LineType, sFlatness)
                    For i As Integer = 0 To oFlatSequence.Count - 2
                        Dim oPoint1 As PointF = oFlatSequence(i)
                        Dim oPoint2 As PointF = oFlatSequence(i + 1)
                        Dim oResult As PointF = modPaint.FindSegmentIntersection(Point1, point2, oPoint1, oPoint2, bIntersect)
                        If bIntersect Then
                            Dim sDistance As Single = modPaint.DistancePointToPoint(Point1, oResult)
                            If sDistance < sMinDistance Then
                                sMinDistance = sDistance
                                oMinResult = oResult
                            End If
                        End If
                    Next
                Next
            Next
            If sMinDistance < Single.MaxValue Then
                IntersectionPoint = oMinResult
                Distance = sMinDistance
                Return True
            Else
                Return False
            End If
        End Function

        Public Sub PreparePath(CaveAndBraches As Dictionary(Of String, modCaveAndBranch.cCaveBranchPlaceholder))
            If Not bIsEmpty Then
                Call oItems.Clear()
                Dim bDone As Boolean
                For Each oCaveBranchPlaceholder As cCaveBranchPlaceholder In CaveAndBraches.Values
                    Dim sCave As String = oCaveBranchPlaceholder.Cave.ToLower
                    Dim sBranch As String = oCaveBranchPlaceholder.Branch.ToLower
                    Do
                        For Each oItem As cItemInvertedFreeHandArea In oAllItems
                            If oItem.Cave.ToLower = sCave AndAlso oItem.Branch.ToLower = sBranch AndAlso Not oItems.Contains(oItem) Then
                                Call oItems.Add(oItem)
                            End If
                        Next

                        If sBranch = "" Then
                            bDone = True
                        Else
                            If Not bDone Then
                                Dim oBranch As cCaveInfoBranch = oSurvey.Properties.CaveInfos(sCave).Branches(sBranch)
                                If IsNothing(oBranch) Then
                                    sBranch = ""
                                Else
                                    If IsNothing(oBranch.Parent) Then
                                        sBranch = ""
                                    Else
                                        sBranch = oBranch.Parent.Path
                                    End If
                                End If
                            End If
                        End If
                    Loop Until bDone
                Next
            End If
        End Sub

        Public ReadOnly Property IsEmpty As Boolean
            Get
                Return bIsEmpty
            End Get
        End Property

        Public Sub New(Survey As cSurvey.cSurvey, Plan As cDesignPlan, PaintOptions As cOptions, Optional Flatness As Single = 0.01)
            oSurvey = Survey

            Dim oRealBounds As RectangleF = Plan.GetBounds(PaintOptions)
            oItems = New List(Of cItemInvertedFreeHandArea)
            sFlatness = Flatness
            If modPaint.IsRectangleEmpty(oRealBounds) Then
                bIsEmpty = True
            Else
                Dim oLayer As Layers.cLayerBorders = Plan.Layers.Item(cLayers.LayerTypeEnum.Borders)

                Dim bInclude As Boolean
                Dim oAddItems As List(Of Design.Items.cItemInvertedFreeHandArea) = New List(Of Design.Items.cItemInvertedFreeHandArea)
                Dim oSubtractItems As List(Of Design.Items.cItemInvertedFreeHandArea) = New List(Of Design.Items.cItemInvertedFreeHandArea)
                For Each oItem As cItem In oLayer.GetAllVisibleItems(PaintOptions)
                    If oItem.Type = cIItem.cItemTypeEnum.InvertedFreeHandArea Then
                        If oItem.BindDesignType = cItem.BindDesignTypeEnum.CrossSections Then
                            bInclude = False
                        Else
                            bInclude = True
                        End If
                        If bInclude Then
                            Dim oCaveBorder As Design.Items.cItemInvertedFreeHandArea = oItem
                            If oCaveBorder.MergeMode = Items.cIItemMergeableArea.MergeModeEnum.Add Then
                                Call oAddItems.Add(oCaveBorder)
                            Else
                                Call oSubtractItems.Add(oCaveBorder)
                            End If
                        End If
                    End If
                Next

                oAllItems = oAddItems
                Call oAllItems.AddRange(oSubtractItems)
                If oAllItems.Count = 0 Then
                    bIsEmpty = True
                Else
                    bIsEmpty = False
                End If
            End If
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    Call oItems.Clear()
                    Call oAllItems.Clear()
                End If
            End If
            Me.disposedValue = True
        End Sub

        ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(disposing As Boolean).
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    '    Friend Class cLRUDDesignCacheItem
    '        Implements cICaveBranch

    '        Private sCave As String
    '        Private sBranch As String
    '        Private oSequence As cSequence

    '        Public ReadOnly Property Sequence As cSequence
    '            Get
    '                Return oSequence
    '            End Get
    '        End Property

    '        Public ReadOnly Property Branch As String Implements cICaveBranch.Branch
    '            Get
    '                Return sBranch
    '            End Get
    '        End Property

    '        Public ReadOnly Property Cave As String Implements cICaveBranch.Cave
    '            Get
    '                Return sCave
    '            End Get
    '        End Property

    '        Public Sub New(Cave As String, Branch As String, Sequence As cSequence)
    '            sCave = Cave
    '            sBranch = Branch
    '            oSequence = Sequence
    '        End Sub
    '    End Class

    '    Friend Class cLRFromDesignCache
    '        Implements IDisposable

    '        Private oSurvey As cSurvey.cSurvey

    '        Private oAllItems As List(Of cItemInvertedFreeHandArea)
    '        Private oAllSequences As List(Of cLRUDDesignCacheItem)
    '        Private oSequences As List(Of cSequence)

    '        Private bIsEmpty As Boolean

    '        Private sFlatness As Single

    '        Public Function Intersect(Point1 As PointF, point2 As PointF, ByRef IntersectionPoint As PointF, ByRef Distance As Single) As Boolean
    '            Dim sMinDistance As Single = Single.MaxValue
    '            Dim oMinResult As PointF
    '            Dim bIntersect As Boolean
    '            For Each oSequence As cSequence In oSequences
    '                For i As Integer = 0 To oSequence.Count - 2
    '                    Dim oPoint1 As PointF = oSequence(i).Point
    '                    Dim oPoint2 As PointF = oSequence(i + 1).Point
    '                    Dim oResult As PointF = modPaint.FindSegmentIntersection(Point1, point2, oPoint1, oPoint2, bIntersect)
    '                    If bIntersect Then
    '                        Dim sDistance As Single = modPaint.DistancePointToPoint(Point1, oResult)
    '                        If sDistance < sMinDistance Then
    '                            sMinDistance = sDistance
    '                            oMinResult = oResult
    '                        End If
    '                    End If
    '                Next
    '            Next
    '            If sMinDistance < Single.MaxValue Then
    '                IntersectionPoint = oMinResult
    '                Distance = sMinDistance
    '                Return True
    '            Else
    '                Return False
    '            End If
    '        End Function

    '        Private Sub pPreparePathItem(Item As cItemInvertedFreeHandArea)
    '            For Each oSequence As cSequence In Item.Points.GetSequences
    '                Dim oFlatSequence As cSequence = modPaint.ToStraightLineForced(Item.Survey, oSequence, DirectCast(Item, Items.cIItemLine).LineType, sFlatness)
    '                Call oAllSequences.Add(New cLRUDDesignCacheItem(Item.Cave, Item.Branch, oFlatSequence))
    '                Call oSequences.Add(oFlatSequence)
    '            Next
    '        End Sub

    '        Public Sub PreparePath(CaveAndBraches As Dictionary(Of String, modCaveAndBranch.cCaveBranchPlaceholder))
    '            If Not bIsEmpty Then
    '                Call oSequences.Clear()
    '                Dim bDone As Boolean
    '                For Each oCaveBranchPlaceholder As cCaveBranchPlaceholder In CaveAndBraches.Values
    '                    Dim sCave As String = oCaveBranchPlaceholder.Cave
    '                    Dim sBranch As String = oCaveBranchPlaceholder.Branch

    '                    'process items in global collection and remove from global collection after sequence conversion
    '                    bDone = False
    '                    Do
    '                        Dim oItems As List(Of cItemInvertedFreeHandArea) = New List(Of cItemInvertedFreeHandArea)
    '                        For Each oItem As cItemInvertedFreeHandArea In oAllItems
    '                            If oItem.Cave = sCave AndAlso oItem.Branch = sBranch AndAlso Not oItems.Contains(oItem) Then
    '                                Call oItems.Add(oItem)
    '                                Call pPreparePathItem(oItem)
    '                            End If
    '                        Next
    '                        oAllItems = oAllItems.Except(oItems).ToList

    '                        If sBranch = "" Then
    '                            bDone = True
    '                        Else
    '                            If Not bDone Then
    '                                Dim oBranch As cCaveInfoBranch = oSurvey.Properties.CaveInfos(sCave).Branches(sBranch)
    '                                If IsNothing(oBranch) Then
    '                                    sBranch = ""
    '                                Else
    '                                    If IsNothing(oBranch.Parent) Then
    '                                        sBranch = ""
    '                                    Else
    '                                        sBranch = oBranch.Parent.Path
    '                                    End If
    '                                End If
    '                            End If
    '                        End If
    '                    Loop Until bDone

    '                    'process sequences in cache...
    '                    bDone = False
    '                    Do
    '                        For Each oItem As cLRUDDesignCacheItem In oAllSequences
    '                            If oItem.Cave = sCave AndAlso oItem.Branch = sBranch AndAlso Not oSequences.Contains(oItem.Sequence) Then
    '                                Call oSequences.Add(oItem.Sequence)
    '                            End If
    '                        Next

    '                        If sBranch = "" Then
    '                            bDone = True
    '                        Else
    '                            If Not bDone Then
    '                                Dim oBranch As cCaveInfoBranch = oSurvey.Properties.CaveInfos(sCave).Branches(sBranch)
    '                                If IsNothing(oBranch) Then
    '                                    sBranch = ""
    '                                Else
    '                                    If IsNothing(oBranch.Parent) Then
    '                                        sBranch = ""
    '                                    Else
    '                                        sBranch = oBranch.Parent.Path
    '                                    End If
    '                                End If
    '                            End If
    '                        End If
    '                    Loop Until bDone
    '                Next
    '            End If
    '        End Sub

    '        Public ReadOnly Property IsEmpty As Boolean
    '            Get
    '                Return bIsEmpty
    '            End Get
    '        End Property

    '        Public Sub New(Survey As cSurvey.cSurvey, Plan As cDesignPlan, PaintOptions As cOptions, Optional Flatness As Single = 0.1)
    '            oSurvey = Survey

    '            Dim oRealBounds As RectangleF = Plan.GetBounds(PaintOptions)
    '            oAllSequences = New List(Of cLRUDDesignCacheItem)
    '            oSequences = New List(Of cSequence)
    '            sFlatness = Flatness
    '            If modPaint.IsRectangleEmpty(oRealBounds) Then
    '                bIsEmpty = True
    '            Else
    '                Dim oLayer As Layers.cLayerBorders = Plan.Layers.Item(cLayers.LayerTypeEnum.Borders)

    '                Dim bInclude As Boolean
    '                Dim oAddItems As List(Of Design.Items.cItemInvertedFreeHandArea) = New List(Of Design.Items.cItemInvertedFreeHandArea)
    '                Dim oSubtractItems As List(Of Design.Items.cItemInvertedFreeHandArea) = New List(Of Design.Items.cItemInvertedFreeHandArea)
    '                For Each oItem As cItem In oLayer.GetAllVisibleItems(PaintOptions)
    '                    If oItem.Type = cIItem.cItemTypeEnum.InvertedFreeHandArea Then
    '                        If oItem.BindDesignType = cItem.BindDesignTypeEnum.CrossSections Then
    '                            bInclude = False
    '                        Else
    '                            bInclude = True
    '                        End If
    '                        If bInclude Then
    '                            Dim oCaveBorder As Design.Items.cItemInvertedFreeHandArea = oItem
    '                            If oCaveBorder.MergeMode = Items.cIItemMergeableArea.MergeModeEnum.Add Then
    '                                Call oAddItems.Add(oCaveBorder)
    '                            Else
    '                                Call oSubtractItems.Add(oCaveBorder)
    '                            End If
    '                        End If
    '                    End If
    '                Next

    '                oAllItems = oAddItems
    '                Call oAllItems.AddRange(oSubtractItems)
    '                If oAllItems.Count = 0 Then
    '                    bIsEmpty = True
    '                Else
    '                    bIsEmpty = False
    '                End If
    '            End If
    '        End Sub

    '#Region "IDisposable Support"
    '        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

    '        ' IDisposable
    '        Protected Overridable Sub Dispose(disposing As Boolean)
    '            If Not Me.disposedValue Then
    '                If disposing Then
    '                    Call oSequences.Clear()
    '                    Call oAllSequences.Clear()
    '                    Call oAllItems.Clear()
    '                End If
    '            End If
    '            Me.disposedValue = True
    '        End Sub

    '        ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
    '        Public Sub Dispose() Implements IDisposable.Dispose
    '            ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(disposing As Boolean).
    '            Dispose(True)
    '            GC.SuppressFinalize(Me)
    '        End Sub
    '#End Region

    '    End Class

    Public Function GetLRFromDesign(PaintOptions As cOptions, Segment As cSegment, FromOrTo As GetDesignStationEnum) As SizeF
        Dim oPoint As PointF
        If FromOrTo = GetDesignStationEnum.From Then
            oPoint = Segment.Data.Plan.FromPoint
        Else
            oPoint = Segment.Data.Plan.ToPoint
        End If
        Return GetLRFromDesign(PaintOptions, Segment, oPoint, FromOrTo)
    End Function

    Friend Function GetLRFromDesign(Survey As cSurvey.cSurvey, Cache As cLRFromDesignCache, Segment As cSegment, SegmentData As cSurveyPC.cSurvey.Calculate.Plot.cIPlanProjectedData, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
        If Cache.IsEmpty Then
            Return New SizeF(0, 0)
        Else
            Call Cache.PreparePath(GetCaveAndBranchList(Survey, Segment, SegmentData, FromOrTo))

            Dim dMaxWidth As Decimal = 200

            Dim dBearingLeft As Decimal
            Dim dBearingRight As Decimal

            If FromOrTo = GetDesignStationEnum.From Then
                dBearingLeft = SegmentData.FromBearingLeft
                dBearingRight = SegmentData.FromBearingRight
            Else
                dBearingLeft = SegmentData.ToBearingLeft
                dBearingRight = SegmentData.ToBearingRight
            End If

            Dim oResultPoint As PointF
            Dim sResult As Single
            Dim oLeftPoint As PointF = GenericPoint + modPaint.Trigo(dMaxWidth, dBearingLeft)
            Dim sLeft As Single = 0
            If Cache.Intersect(GenericPoint, oLeftPoint, oResultPoint, sResult) Then
                sLeft = sResult
            End If

            Dim oRightPoint As PointF = GenericPoint + modPaint.Trigo(dMaxWidth, dBearingRight)
            Dim sRight As Single = 0
            If Cache.Intersect(GenericPoint, oRightPoint, oResultPoint, sResult) Then
                sRight = sResult
            End If

            Return New SizeF(sLeft, sRight)
        End If
    End Function

    Public Function GetLRFromDesign(PaintOptions As cOptions, Segment As cSegment, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
        Dim oSurvey As cSurvey.cSurvey = Segment.Survey
        Dim oCache As cLRFromDesignCache = New cLRFromDesignCache(oSurvey, oSurvey.Plan, PaintOptions)
        Return GetLRFromDesign(oSurvey, oCache, Segment, Segment.Data.Plan, GenericPoint, FromOrTo)
    End Function

    Friend Class cUDFromDesignCache
        Implements IDisposable

        Private oSurvey As cSurvey.cSurvey

        Private oItems As List(Of Design.Items.cItemInvertedFreeHandArea)
        Private oAllItems As List(Of Design.Items.cItemInvertedFreeHandArea)

        Private bIsEmpty As Boolean

        Private sFlatness As Single

        Public Function Intersect(Point1 As PointF, point2 As PointF, ByRef IntersectionPoint As PointF, ByRef Distance As Single) As Boolean
            Dim sMinDistance As Single = Single.MaxValue
            Dim oMinResult As PointF
            Dim bIntersect As Boolean
            For Each oItem As cItemInvertedFreeHandArea In oItems
                For Each oSequence As cSequence In oItem.Points.GetSequences
                    Dim oFlatSequence As List(Of PointF) = modPaint.ToStraightLinePoints(oItem.Survey, oSequence, DirectCast(oItem, Items.cIItemLine).LineType, sFlatness)
                    For i As Integer = 0 To oFlatSequence.Count - 2
                        Dim oPoint1 As PointF = oFlatSequence(i)
                        Dim oPoint2 As PointF = oFlatSequence(i + 1)
                        Dim oResult As PointF = modPaint.FindSegmentIntersection(Point1, point2, oPoint1, oPoint2, bIntersect)
                        If bIntersect Then
                            Dim sDistance As Single = modPaint.DistancePointToPoint(Point1, oResult)
                            If sDistance < sMinDistance Then
                                sMinDistance = sDistance
                                oMinResult = oResult
                            End If
                        End If
                    Next
                Next
            Next
            If sMinDistance < Single.MaxValue Then
                IntersectionPoint = oMinResult
                Distance = sMinDistance
                Return True
            Else
                Return False
            End If
        End Function

        Public Sub PreparePath(CaveAndBraches As Dictionary(Of String, modCaveAndBranch.cCaveBranchPlaceholder))
            If Not bIsEmpty Then
                Call oItems.Clear()
                Dim bDone As Boolean
                For Each oCaveBranchPlaceholder As cCaveBranchPlaceholder In CaveAndBraches.Values
                    Dim sCave As String = oCaveBranchPlaceholder.Cave.ToLower
                    Dim sBranch As String = oCaveBranchPlaceholder.Branch.ToLower
                    Do
                        For Each oItem As cItemInvertedFreeHandArea In oAllItems
                            If oItem.Cave.ToLower = sCave AndAlso oItem.Branch.ToLower = sBranch AndAlso Not oItems.Contains(oItem) Then
                                Call oItems.Add(oItem)
                            End If
                        Next
                        If sBranch = "" Then
                            bDone = True
                        Else
                            If Not bDone Then
                                Dim oBranch As cCaveInfoBranch = oSurvey.Properties.CaveInfos(sCave).Branches(sBranch)
                                If IsNothing(oBranch) Then
                                    sBranch = ""
                                Else
                                    If IsNothing(oBranch.Parent) Then
                                        sBranch = ""
                                    Else
                                        sBranch = oBranch.Parent.Path
                                    End If
                                End If
                            End If
                        End If
                    Loop Until bDone
                Next
            End If
        End Sub

        Public ReadOnly Property IsEmpty As Boolean
            Get
                Return bIsEmpty
            End Get
        End Property

        Public Sub New(Survey As cSurvey.cSurvey, Profile As cDesignProfile, PaintOptions As cOptions, Optional Flatness As Single = 0.01)
            oSurvey = Survey

            Dim oRealBounds As RectangleF = Profile.GetBounds(PaintOptions)
            oItems = New List(Of cItemInvertedFreeHandArea)
            sFlatness = Flatness
            If modPaint.IsRectangleEmpty(oRealBounds) Then
                bIsEmpty = True
            Else
                Dim oLayer As Layers.cLayerBorders = Profile.Layers.Item(cLayers.LayerTypeEnum.Borders)

                Dim bInclude As Boolean
                Dim oAddItems As List(Of Design.Items.cItemInvertedFreeHandArea) = New List(Of Design.Items.cItemInvertedFreeHandArea)
                Dim oSubtractItems As List(Of Design.Items.cItemInvertedFreeHandArea) = New List(Of Design.Items.cItemInvertedFreeHandArea)
                For Each oItem As cItem In oLayer.GetAllVisibleItems(PaintOptions)
                    If oItem.Type = cIItem.cItemTypeEnum.InvertedFreeHandArea Then
                        If oItem.BindDesignType = cItem.BindDesignTypeEnum.CrossSections Then
                            bInclude = False
                        Else
                            bInclude = True
                        End If
                        If bInclude Then
                            Dim oCaveBorder As Design.Items.cItemInvertedFreeHandArea = oItem
                            If oCaveBorder.MergeMode = Items.cIItemMergeableArea.MergeModeEnum.Add Then
                                Call oAddItems.Add(oCaveBorder)
                            Else
                                Call oSubtractItems.Add(oCaveBorder)
                            End If
                        End If
                    End If
                Next

                oAllItems = oAddItems
                Call oAllItems.AddRange(oSubtractItems)
                If oAllItems.Count = 0 Then
                    bIsEmpty = True
                Else
                    bIsEmpty = False
                End If
            End If
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    Call oItems.Clear()
                    Call oAllItems.Clear()
                End If
            End If
            Me.disposedValue = True
        End Sub

        ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(disposing As Boolean).
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Public Function GetUDFromDesign(PaintOptions As cOptions, Segment As cSegment, FromOrTo As GetDesignStationEnum) As SizeF
        Dim oPoint As PointF
        If FromOrTo = GetDesignStationEnum.From Then
            oPoint = Segment.Data.Profile.FromPoint
        Else
            oPoint = Segment.Data.Profile.ToPoint
        End If
        Return GetUDFromDesign(PaintOptions, Segment, oPoint, FromOrTo)
    End Function

    Friend Function GetUDFromDesign(Survey As cSurvey.cSurvey, Cache As cUDFromDesignCache, Segment As cSegment, SegmentData As cSurveyPC.cSurvey.Calculate.Plot.cIProfileProjectedData, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
        If Cache.IsEmpty Then
            Return New SizeF(0, 0)
        Else
            Call Cache.PreparePath(GetCaveAndBranchList(Survey, Segment, SegmentData, FromOrTo))

            Dim iMaxWidth As Integer = 200

            Dim oResultPoint As PointF
            Dim sResult As Single
            Dim oUpPoint As PointF = New PointF(GenericPoint.X, GenericPoint.Y - iMaxWidth)
            Dim sUp As Single = 0
            If Cache.Intersect(GenericPoint, oUpPoint, oResultPoint, sResult) Then
                sUp = sResult
            End If

            Dim oDownPoint As PointF = New PointF(GenericPoint.X, GenericPoint.Y + iMaxWidth)
            Dim sDown As Single = 0
            If Cache.Intersect(GenericPoint, oDownPoint, oResultPoint, sResult) Then
                sDown = sResult
            End If

            Return New SizeF(sUp, sDown)
        End If
    End Function

    Public Function GetUDFromDesign(PaintOptions As cOptions, Segment As cSegment, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
        Dim oSurvey As cSurvey.cSurvey = Segment.Survey
        Dim oCache As cUDFromDesignCache = New cUDFromDesignCache(oSurvey, oSurvey.Profile, PaintOptions)
        Return GetUDFromDesign(oSurvey, oCache, Segment, Segment.Data.Profile, GenericPoint, FromOrTo)
    End Function

    Public Function GetFBFromDesign(PaintOptions As cOptions, Segment As cSegment, FromOrTo As GetDesignStationEnum) As SizeF
        Dim oPoint As PointF
        If FromOrTo = GetDesignStationEnum.From Then
            oPoint = Segment.Data.Profile.FromPoint
        Else
            oPoint = Segment.Data.Profile.ToPoint
        End If
        Return GetFBFromDesign(PaintOptions, Segment, oPoint, FromOrTo)
    End Function

    Friend Function GetFBFromDesign(Survey As cSurvey.cSurvey, Cache As cUDFromDesignCache, Segment As cSegment, SegmentData As cSurveyPC.cSurvey.Calculate.Plot.cISpatialData, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
        'TODO....
        Return New SizeF(0, 0)
    End Function

    Public Function GetFBFromDesign(PaintOptions As cOptions, Segment As cSegment, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
        Dim oSurvey As cSurvey.cSurvey = Segment.Survey
        Dim oCache As cUDFromDesignCache = New cUDFromDesignCache(oSurvey, oSurvey.Profile, PaintOptions)
        Return GetFBFromDesign(oSurvey, oCache, Segment, Segment.Data.Data, GenericPoint, FromOrTo)
    End Function

#End Region

End Module
