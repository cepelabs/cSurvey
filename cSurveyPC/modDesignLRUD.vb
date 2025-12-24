Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Design.cDesign
Imports DevExpress.XtraGauges.Core.Model
Imports System.Collections.ObjectModel
Imports System.Windows.Input
Imports OfficeOpenXml.FormulaParsing.Excel.Functions.Information

Module modDesignLRUD

#Region "GetLRUDFromDesign"
    Public Enum GetDesignStationEnum
        [From] = 0
        [To] = 1
    End Enum

    'Private Function GetCaveAndBranchList(Survey As cSurvey.cSurvey, Segment As cSegment, SegmentData As cSurveyPC.cSurvey.Calculate.Plot.cIProjectedData, FromOrTo As GetDesignStationEnum) As Dictionary(Of String, modCaveAndBranch.cCaveBranchPlaceholder)
    '    'CREO UN ELENCO DELLE GROTTE/RAMI DA DISEGNARE...dovrebbe essere elencato l'insieme grotte/ramo delle battute che partono dal caposaldo indicato...
    '    Dim oCaveAndBraches As Dictionary(Of String, modCaveAndBranch.cCaveBranchPlaceholder) = New Dictionary(Of String, cCaveBranchPlaceholder)(StringComparer.OrdinalIgnoreCase)
    '    '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '    Dim sKey As String = Segment.Cave & "|" & Segment.Branch
    '    Call oCaveAndBraches.Add(sKey, New modCaveAndBranch.cCaveBranchPlaceholder(Segment.Cave, Segment.Branch))
    '    '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '    Dim sStation As String
    '    If FromOrTo = GetDesignStationEnum.From Then
    '        sStation = SegmentData.From
    '    Else
    '        sStation = SegmentData.To
    '    End If
    '    If Survey.TrigPoints.Contains(sStation) Then
    '        Dim oSegments As cSegmentCollection = Survey.TrigPoints(sStation).GetSegments
    '        For Each oSegment As cSegment In oSegments
    '            sKey = oSegment.Cave & "|" & oSegment.Branch
    '            If Not oCaveAndBraches.ContainsKey(sKey) Then
    '                Call oCaveAndBraches.Add(sKey, New modCaveAndBranch.cCaveBranchPlaceholder(oSegment.Cave, oSegment.Branch))
    '            End If
    '        Next
    '    End If
    '    Return oCaveAndBraches
    'End Function

    Friend Class cLRUDFromDesignCacheItems
        Inherits KeyedCollection(Of String, cLRUDFromDesignCacheItem)

        Default Public Overloads ReadOnly Property Item(DesignItem As cItem) As cLRUDFromDesignCacheItem
            Get
                Dim sKey As String = DesignItem.Cave.ToLower & cCaveInfoBranches.sBranchSeparator & DesignItem.Branch.ToLower
                If MyBase.Contains(sKey) Then
                    Return MyBase.Item(sKey)
                End If
            End Get
        End Property

        Default Public Overloads ReadOnly Property Item(Segment As cSegment) As cLRUDFromDesignCacheItem
            Get
                Dim sKey As String = Segment.Cave.ToLower & cCaveInfoBranches.sBranchSeparator & Segment.Branch.ToLower
                If MyBase.Contains(sKey) Then
                    Return MyBase.Item(sKey)
                End If
            End Get
        End Property

        Public Overloads Function Contains(Item As cItem) As Boolean
            Return MyBase.Contains(Item.Cave.ToLower & cCaveInfoBranches.sBranchSeparator & Item.Branch.ToLower)
        End Function

        Protected Overrides Function GetKeyForItem(ByVal item As cLRUDFromDesignCacheItem) As String
            Return item.Path
        End Function
    End Class

    Friend Class cLRUDFromDesignCacheItem
        Private sCave As String
        Private sBranch As String

        Private sFlatness As Single

        Private oPathAdd As GraphicsPath
        Private oPathSubtract As GraphicsPath

        Private oPointsAdd As PointF()()
        Private oPointsSubtract As PointF()()

        Public ReadOnly Property Branch As String
            Get
                Return sBranch
            End Get
        End Property

        Public ReadOnly Property Cave As String
            Get
                Return sCave
            End Get
        End Property

        Public Sub New(Item As cItemInvertedFreeHandArea, Flatness As Single)
            sCave = Item.Cave.ToLower
            sBranch = Item.Branch.ToLower
            sFlatness = Flatness
        End Sub

        Public Function Path() As String
            Return sCave & cCaveInfoBranches.sBranchSeparator & sBranch
        End Function

        Public Function GetPointsSubtract() As PointF()()
            If oPathSubtract Is Nothing Then
                oPointsSubtract = {}
                Return oPointsSubtract
            Else
                SyncLock oPathSubtract
                    If oPointsSubtract Is Nothing Then
                        oPointsSubtract = oPathToPointArray(oPathSubtract)
                    End If
                    Return oPointsSubtract
                End SyncLock
            End If
        End Function

        Public Function GetPointsAdd() As PointF()()
            If oPathAdd Is Nothing Then
                oPointsAdd = {}
                Return oPointsAdd
            Else
                SyncLock oPathAdd
                    If oPointsAdd Is Nothing Then
                        oPointsAdd = oPathToPointArray(oPathAdd)
                    End If
                    Return oPointsAdd
                End SyncLock
            End If
        End Function

        Private Function oPathToPointArray(Path As GraphicsPath) As PointF()()
            Dim oItems As PointF()() = {}
            If Path IsNot Nothing Then
                Dim oItem As PointF() = Path.PathPoints
                Dim iStart As Integer
                For i As Integer = 0 To oItem.Length - 1
                    If Path.PathTypes(i) = Drawing2D.PathPointType.Start Then
                        If i > 0 Then
                            Dim oNewItem(i - iStart) As PointF
                            Array.Copy(oItem, iStart, oNewItem, 0, i - iStart)
                            oNewItem(oNewItem.Length - 1) = oNewItem(0)
                            Array.Resize(oItems, oItems.Length + 1)
                            oItems(oItems.Length - 1) = oNewItem
                        End If
                        iStart = i
                    End If
                Next
                If (oItem.Length - iStart) > 0 Then
                    Dim oNewItem(oItem.Length - iStart) As PointF
                    Array.Copy(oItem, iStart, oNewItem, 0, oItem.Length - iStart)
                    oNewItem(oNewItem.Length - 1) = oNewItem(0)

                    Array.Resize(oItems, oItems.Length + 1)
                    oItems(oItems.Length - 1) = oNewItem
                End If
            End If

            oItems = modClipper2.FromPaths(modClipper2.Merge(modClipper2.ToPaths(oItems)))

            Return oItems
        End Function

        Private Function pItemToPath(Item As cItemInvertedFreeHandArea) As GraphicsPath
            Dim oSequences As List(Of cSequence) = Item.Points.GetSequences
            If oSequences.Count > 0 Then
                Dim oPath As GraphicsPath = New GraphicsPath
                For Each oSequence As cSequence In oSequences
                    Dim iLineType As Items.cIItemLine.LineTypeEnum = oSequence.GetLineType(Item.LineType)
                    If iLineType = cIItemLine.LineTypeEnum.Lines Then
                        oPath.AddLines(oSequence.GetPoints)
                    Else
                        Dim oNewSequence As cSequence = Nothing
                        Dim oSequencePoints() As PointF = oSequence.GetPoints
                        If oSequencePoints.Length > 1 Then
                            Select Case iLineType
                                Case Items.cIItemLine.LineTypeEnum.Beziers
                                    Call modPaint.PointsToBeziers(oSequencePoints, oPath)
                                Case Items.cIItemLine.LineTypeEnum.Splines
                                    Call oPath.AddCurve(oSequencePoints, sDefaultSplineTension)
                            End Select
                            Call oPath.Flatten(Nothing, sFlatness)
                        End If
                    End If
                Next
                Return oPath
            End If
        End Function

        Public Sub AppendAdd(Item As cItemInvertedFreeHandArea)
            Using oPath As GraphicsPath = pItemToPath(Item)
                Call AppendAdd(oPath)
            End Using
        End Sub

        Public Sub AppendSubtract(Item As cItemInvertedFreeHandArea)
            Using oPath As GraphicsPath = pItemToPath(Item)
                Call AppendSubtract(oPath)
            End Using
        End Sub

        Public Sub AppendAdd(Path As GraphicsPath)
            If Path IsNot Nothing Then
                If oPathAdd Is Nothing Then
                    oPathAdd = Path.Clone
                Else
                    Dim oPath As GraphicsPath = Path.Clone
                    oPath.Flatten(Nothing, sFlatness)
                    oPathAdd.AddPath(oPath, False)
                End If
            End If
        End Sub

        Public Sub AppendSubtract(Path As GraphicsPath)
            If Path IsNot Nothing Then
                If oPathSubtract Is Nothing Then
                    oPathSubtract = Path.Clone
                Else
                    Dim oPath As GraphicsPath = Path.Clone
                    oPath.Flatten(Nothing, sFlatness)
                    oPathSubtract.AddPath(oPath, False)
                End If
            End If
        End Sub
    End Class

    'version with list...slower
    'Friend Class cLRUDFromDesignCacheItem
    '    Private sCave As String
    '    Private sBranch As String

    '    Private sFlatness As Single

    '    Private oPathAdd As GraphicsPath
    '    Private oPathSubtract As GraphicsPath

    '    Private oPointsAdd As List(Of List(Of PointF))
    '    Private oPointsSubtract As List(Of List(Of PointF))

    '    Public Sub New(Item As cItemInvertedFreeHandArea, Flatness As Single)
    '        sCave = Item.Cave.ToLower
    '        sBranch = Item.Branch.ToLower
    '        sFlatness = Flatness
    '    End Sub

    '    Public Function Path() As String
    '        Return sCave & cCaveInfoBranches.sBranchSeparator & sBranch
    '    End Function

    '    Public Function GetPointsSubtract() As List(Of List(Of PointF))
    '        SyncLock Me
    '            If oPointsSubtract Is Nothing Then
    '                oPointsSubtract = oPathToPointList(oPathSubtract)
    '            End If
    '            Return oPointsSubtract
    '        End SyncLock
    '    End Function

    '    Public Function GetPointsAdd() As List(Of List(Of PointF))
    '        SyncLock Me
    '            If oPointsAdd Is Nothing Then
    '                oPointsAdd = oPathToPointList(oPathAdd)
    '            End If
    '            Return oPointsAdd
    '        End SyncLock
    '    End Function

    '    Private Function oPathToPointList(Path As GraphicsPath) As List(Of List(Of PointF))
    '        Dim oItems As List(Of List(Of PointF)) = New List(Of List(Of PointF))
    '        If Path IsNot Nothing Then
    '            Dim oItem As List(Of PointF) = New List(Of PointF)
    '            For i As Integer = 0 To Path.PointCount - 1
    '                Dim oPoint As PointF = Path.PathPoints(i)
    '                Dim bType As Byte = Path.PathTypes(i)
    '                If bType = Drawing2D.PathPointType.Start Then
    '                    oItem = New List(Of PointF)
    '                    oItems.Add(oItem)
    '                End If
    '                oItem.Add(oPoint)
    '            Next
    '        End If
    '        For Each oItem As List(Of PointF) In oItems
    '            oItem.Add(oItem(0))
    '        Next
    '        Return oItems
    '    End Function

    '    Private Function pItemToPath(Item As cItemInvertedFreeHandArea) As GraphicsPath
    '        Dim oPath As GraphicsPath = New GraphicsPath
    '        For Each oSequence As cSequence In Item.Points.GetSequences
    '            Dim iLineType As Items.cIItemLine.LineTypeEnum = oSequence.GetLineType(Item.LineType)
    '            If iLineType = cIItemLine.LineTypeEnum.Lines Then
    '                oPath.AddLines(oSequence.GetPoints)
    '            Else
    '                Dim oNewSequence As cSequence = Nothing
    '                Dim oSequencePoints() As PointF = oSequence.GetPoints
    '                If oSequencePoints.Length > 1 Then
    '                    Select Case iLineType
    '                        Case Items.cIItemLine.LineTypeEnum.Beziers
    '                            Call modPaint.PointsToBeziers(oSequencePoints, oPath)
    '                        Case Items.cIItemLine.LineTypeEnum.Splines
    '                            Call oPath.AddCurve(oSequencePoints, sDefaultSplineTension)
    '                    End Select
    '                    Call oPath.Flatten(Nothing, sFlatness)
    '                End If
    '            End If
    '        Next
    '        Return oPath
    '    End Function

    '    Public Sub AppendAdd(Item As cItemInvertedFreeHandArea)
    '        Using oPath As GraphicsPath = pItemToPath(Item)
    '            Call AppendAdd(oPath)
    '        End Using
    '    End Sub

    '    Public Sub AppendSubtract(Item As cItemInvertedFreeHandArea)
    '        Using oPath As GraphicsPath = pItemToPath(Item)
    '            Call AppendSubtract(oPath)
    '        End Using
    '    End Sub

    '    Public Sub AppendAdd(Path As GraphicsPath)
    '        If oPathAdd Is Nothing Then
    '            oPathAdd = Path.Clone
    '        Else
    '            Dim oPath As GraphicsPath = Path.Clone
    '            oPath.Flatten(Nothing, sFlatness)
    '            oPathAdd.FillMode = FillMode.Winding
    '            oPathAdd.AddPath(oPath, False)
    '        End If
    '    End Sub

    '    Public Sub AppendSubtract(Path As GraphicsPath)
    '        If oPathSubtract Is Nothing Then
    '            oPathSubtract = Path.Clone
    '        Else
    '            Dim oPath As GraphicsPath = Path.Clone
    '            oPath.Flatten(Nothing, sFlatness)
    '            oPathSubtract.FillMode = FillMode.Winding
    '            oPathSubtract.AddPath(oPath, False)
    '        End If
    '    End Sub
    'End Class

    Friend Class cLRUDFromDesignCache2
        Implements IDisposable

        Private oSurvey As cSurvey.cSurvey

        Private oAllItems As cLRUDFromDesignCacheItems

        Private bIsEmpty As Boolean

        Private sFlatness As Single

        Public Sub Paint(Graphics As Graphics)
            For Each oitem As cLRUDFromDesignCacheItem In oAllItems
                Try
                    Using oPath As GraphicsPath = New GraphicsPath
                        For Each oPoints As PointF() In oitem.GetPointsAdd
                            oPath.AddPolygon(oPoints)
                        Next
                        Graphics.FillPath(New SolidBrush(oSurvey.Properties.CaveInfos.GetColor(oitem.Cave, oitem.Branch, Color.Gray)), oPath)
                    End Using
                Catch ex As Exception
                End Try
                Try
                    Using oPath As GraphicsPath = New GraphicsPath
                        For Each oPoints As PointF() In oitem.GetPointsSubtract
                            oPath.AddPolygon(oPoints)
                        Next
                        Graphics.FillPath(New SolidBrush(oSurvey.Properties.CaveInfos.GetColor(oitem.Cave, oitem.Branch, Color.Gray)), oPath)
                    End Using
                Catch ex As Exception
                End Try
            Next
        End Sub

        'Public Sub Paint(Graphics As Graphics)
        '    For Each oitem As cLRUDFromDesignCacheItem In oAllItems
        '        Using oPath As GraphicsPath = New GraphicsPath
        '            For Each oPoints As List(Of PointF) In oitem.GetPointsAdd
        '                oPath.AddPolygon(oPoints.ToArray)
        '            Next
        '            Graphics.FillPath(Brushes.Red, oPath)
        '        End Using
        '        Using oPath As GraphicsPath = New GraphicsPath
        '            For Each oPoints As List(Of PointF) In oitem.GetPointsSubtract
        '                oPath.AddPolygon(oPoints.ToArray)
        '            Next
        '            Graphics.FillPath(Brushes.Green, oPath)
        '        End Using
        '    Next
        'End Sub

        Public Function Intersect(Segment As cSegment, Point1 As PointF, point2 As PointF, ByRef IntersectionPoint As PointF, ByRef Distance As Single) As Boolean
            Dim sMinDistance As Single = Single.MaxValue
            Dim oMinResult As PointF
            Dim bIntersect As Boolean
            Dim oItem As cLRUDFromDesignCacheItem = oAllItems(Segment)
            If oItem Is Nothing Then
                Return False
            Else
                For Each oPoints As PointF() In oItem.GetPointsSubtract
                    If modPaint.IsInPolygon(Point1, oPoints) Then
                        Return False
                    End If
                Next

                For Each oPoints As PointF() In oItem.GetPointsAdd
                    If modPaint.IsInPolygon(Point1, oPoints) Then
                        For i As Integer = 0 To oPoints.Count - 2
                            Dim oPoint1 As PointF = oPoints(i)
                            Dim oPoint2 As PointF = oPoints(i + 1)
                            Dim oResult As PointF = modPaint.FindSegmentIntersection(Point1, point2, oPoint1, oPoint2, bIntersect)
                            If bIntersect Then
                                Dim sDistance As Single = modPaint.DistancePointToPoint(Point1, oResult)
                                If sDistance < sMinDistance Then
                                    sMinDistance = sDistance
                                    oMinResult = oResult
                                End If
                            End If
                        Next

                        For Each oSubtractPoints As PointF() In oItem.GetPointsSubtract
                            For i As Integer = 0 To oSubtractPoints.Count - 2
                                Dim oPoint1 As PointF = oSubtractPoints(i)
                                Dim oPoint2 As PointF = oSubtractPoints(i + 1)
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
                    End If
                Next


                If sMinDistance < Single.MaxValue Then
                    IntersectionPoint = oMinResult
                    Distance = sMinDistance
                    Return True
                Else
                    Return False
                End If
            End If
        End Function

        'Public Function Intersect(Segment As cSegment, Point1 As PointF, point2 As PointF, ByRef IntersectionPoint As PointF, ByRef Distance As Single) As Boolean
        '    Dim sMinDistance As Single = Single.MaxValue
        '    Dim oMinResult As PointF
        '    Dim bIntersect As Boolean
        '    Dim oItem As cLRUDFromDesignCacheItem = oAllItems(Segment)
        '    If oItem Is Nothing Then
        '        Return False
        '    Else
        '        For Each oPoints As List(Of PointF) In oItem.GetPointsSubtract
        '            If modPaint.IsInPolygon(Point1, oPoints) Then
        '                Return False
        '            End If
        '        Next

        '        For Each oPoints As List(Of PointF) In oItem.GetPointsAdd
        '            If modPaint.IsInPolygon(Point1, oPoints) Then
        '                For i As Integer = 0 To oPoints.Count - 2
        '                    Dim oPoint1 As PointF = oPoints(i)
        '                    Dim oPoint2 As PointF = oPoints(i + 1)
        '                    Dim oResult As PointF = modPaint.FindSegmentIntersection(Point1, point2, oPoint1, oPoint2, bIntersect)
        '                    If bIntersect Then
        '                        Dim sDistance As Single = modPaint.DistancePointToPoint(Point1, oResult)
        '                        If sDistance < sMinDistance Then
        '                            sMinDistance = sDistance
        '                            oMinResult = oResult
        '                        End If
        '                    End If
        '                Next

        '                For Each oSubtractPoints As List(Of PointF) In oItem.GetPointsSubtract
        '                    For i As Integer = 0 To oSubtractPoints.Count - 2
        '                        Dim oPoint1 As PointF = oSubtractPoints(i)
        '                        Dim oPoint2 As PointF = oSubtractPoints(i + 1)
        '                        Dim oResult As PointF = modPaint.FindSegmentIntersection(Point1, point2, oPoint1, oPoint2, bIntersect)
        '                        If bIntersect Then
        '                            Dim sDistance As Single = modPaint.DistancePointToPoint(Point1, oResult)
        '                            If sDistance < sMinDistance Then
        '                                sMinDistance = sDistance
        '                                oMinResult = oResult
        '                            End If
        '                        End If
        '                    Next
        '                Next
        '            End If
        '        Next


        '        If sMinDistance < Single.MaxValue Then
        '            IntersectionPoint = oMinResult
        '            Distance = sMinDistance
        '            Return True
        '        Else
        '            Return False
        '        End If
        '    End If
        'End Function

        Public ReadOnly Property IsEmpty As Boolean
            Get
                Return bIsEmpty
            End Get
        End Property

        Private Function pCreateCacheItem(CaveBorder As cItemInvertedFreeHandArea, Flatness As Single) As cLRUDFromDesignCacheItem
            Dim oNewItem As cLRUDFromDesignCacheItem = New cLRUDFromDesignCacheItem(CaveBorder, sFlatness)
            oAllItems.Add(oNewItem)
            Return oNewItem
        End Function

        Public Sub New(Survey As cSurvey.cSurvey, Design As cDesign, PaintOptions As cOptions, Optional Flatness As Single = 0.01)
            oSurvey = Survey

            Dim oRealBounds As RectangleF = Design.GetBounds(PaintOptions)
            oAllItems = New cLRUDFromDesignCacheItems
            sFlatness = Flatness
            If modPaint.IsRectangleEmpty(oRealBounds) Then
                bIsEmpty = True
            Else
                Dim oLayer As Layers.cLayerBorders = Design.Layers.Item(cLayers.LayerTypeEnum.Borders)

                Dim bInclude As Boolean
                For Each oItem As cItem In oLayer.GetAllVisibleItems(PaintOptions)
                    If oItem.Type = cIItem.cItemTypeEnum.InvertedFreeHandArea Then
                        If oItem.BindDesignType = cItem.BindDesignTypeEnum.CrossSections Then
                            bInclude = False
                        Else
                            bInclude = True
                        End If
                        If bInclude Then
                            Dim oCaveBorder As Design.Items.cItemInvertedFreeHandArea = oItem
                            Dim oCacheItem As cLRUDFromDesignCacheItem = If(oAllItems.Contains(oCaveBorder), oAllItems(oCaveBorder), pCreateCacheItem(oCaveBorder, sFlatness))
                            If oCaveBorder.MergeMode = Items.cIItemMergeableArea.MergeModeEnum.Add Then
                                oCacheItem.AppendAdd(oCaveBorder)
                            Else
                                oCacheItem.AppendSubtract(oCaveBorder)
                            End If
                        End If
                    End If
                Next
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

    '    Friend Class cLRFromDesignCache
    '        Implements IDisposable

    '        Private oSurvey As cSurvey.cSurvey

    '        Private oItems As List(Of Design.Items.cItemInvertedFreeHandArea)
    '        Private oAllItems As List(Of Design.Items.cItemInvertedFreeHandArea)

    '        Private bIsEmpty As Boolean

    '        Private sFlatness As Single

    '        Public Function Intersect(Point1 As PointF, point2 As PointF, ByRef IntersectionPoint As PointF, ByRef Distance As Single) As Boolean
    '            Dim sMinDistance As Single = Single.MaxValue
    '            Dim oMinResult As PointF
    '            Dim bIntersect As Boolean
    '            For Each oItem As cItemInvertedFreeHandArea In oItems
    '                For Each oSequence As cSequence In oItem.Points.GetSequences
    '                    Dim oFlatSequence As List(Of PointF) = modPaint.ToStraightLinePoints(oItem.Survey, oSequence, DirectCast(oItem, Items.cIItemLine).LineType, sFlatness)
    '                    For i As Integer = 0 To oFlatSequence.Count - 2
    '                        Dim oPoint1 As PointF = oFlatSequence(i)
    '                        Dim oPoint2 As PointF = oFlatSequence(i + 1)
    '                        Dim oResult As PointF = modPaint.FindSegmentIntersection(Point1, point2, oPoint1, oPoint2, bIntersect)
    '                        If bIntersect Then
    '                            Dim sDistance As Single = modPaint.DistancePointToPoint(Point1, oResult)
    '                            If sDistance < sMinDistance Then
    '                                sMinDistance = sDistance
    '                                oMinResult = oResult
    '                            End If
    '                        End If
    '                    Next
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

    '        Public Sub PreparePath(CaveAndBraches As Dictionary(Of String, modCaveAndBranch.cCaveBranchPlaceholder))
    '            If Not bIsEmpty Then
    '                Call oItems.Clear()
    '                Dim bDone As Boolean
    '                For Each oCaveBranchPlaceholder As cCaveBranchPlaceholder In CaveAndBraches.Values
    '                    Dim sCave As String = oCaveBranchPlaceholder.Cave.ToLower
    '                    Dim sBranch As String = oCaveBranchPlaceholder.Branch.ToLower
    '                    Do
    '                        For Each oItem As cItemInvertedFreeHandArea In oAllItems
    '                            If oItem.Cave.ToLower = sCave AndAlso oItem.Branch.ToLower = sBranch AndAlso Not oItems.Contains(oItem) Then
    '                                Call oItems.Add(oItem)
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

    '        Public Sub New(Survey As cSurvey.cSurvey, Plan As cDesignPlan, PaintOptions As cOptions, Optional Flatness As Single = 0.01)
    '            oSurvey = Survey

    '            Dim oRealBounds As RectangleF = Plan.GetBounds(PaintOptions)
    '            oItems = New List(Of cItemInvertedFreeHandArea)
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
    '                    Call oItems.Clear()
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

    'Friend Function GetLRFromDesign(Survey As cSurvey.cSurvey, Cache As cLRUDFromDesignCache2, Segment As cSegment, SegmentData As cSurveyPC.cSurvey.Calculate.Plot.cIPlanProjectedData, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
    '    If Cache.IsEmpty Then
    '        Return New SizeF(0, 0)
    '    Else
    '        Dim dMaxWidth As Decimal = 200

    '        Dim dBearingLeft As Decimal
    '        Dim dBearingRight As Decimal

    '        If FromOrTo = GetDesignStationEnum.From Then
    '            dBearingLeft = SegmentData.FromBearingLeft
    '            dBearingRight = SegmentData.FromBearingRight
    '        Else
    '            dBearingLeft = SegmentData.ToBearingLeft
    '            dBearingRight = SegmentData.ToBearingRight
    '        End If

    '        Dim oResultPoint As PointF
    '        Dim sResult As Single
    '        Dim oLeftPoint As PointF = GenericPoint + modPaint.Trigo(dMaxWidth, dBearingLeft)
    '        Dim sLeft As Single = 0
    '        If Cache.Intersect(GenericPoint, oLeftPoint, oResultPoint, sResult) Then
    '            sLeft = sResult
    '        End If

    '        Dim oRightPoint As PointF = GenericPoint + modPaint.Trigo(dMaxWidth, dBearingRight)
    '        Dim sRight As Single = 0
    '        If Cache.Intersect(GenericPoint, oRightPoint, oResultPoint, sResult) Then
    '            sRight = sResult
    '        End If

    '        Return New SizeF(sLeft, sRight)
    '    End If
    'End Function

    Friend Function GetLRFromDesign(Survey As cSurvey.cSurvey, Cache As cLRUDFromDesignCache2, Segment As cSegment, SegmentData As cSurveyPC.cSurvey.Calculate.Plot.cIPlanProjectedData, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
        If Cache.IsEmpty Then
            Return New SizeF(0, 0)
        Else
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
            If Cache.Intersect(Segment, GenericPoint, oLeftPoint, oResultPoint, sResult) Then
                sLeft = sResult
            End If

            Dim oRightPoint As PointF = GenericPoint + modPaint.Trigo(dMaxWidth, dBearingRight)
            Dim sRight As Single = 0
            If Cache.Intersect(Segment, GenericPoint, oRightPoint, oResultPoint, sResult) Then
                sRight = sResult
            End If

            Return New SizeF(sLeft, sRight)
        End If
    End Function

    Public Function GetLRFromDesign(PaintOptions As cOptions, Segment As cSegment, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
        Dim oSurvey As cSurvey.cSurvey = Segment.Survey
        Dim oCache As cLRUDFromDesignCache2 = New cLRUDFromDesignCache2(oSurvey, oSurvey.Plan, PaintOptions)
        Return GetLRFromDesign(oSurvey, oCache, Segment, Segment.Data.Plan, GenericPoint, FromOrTo)
    End Function

    '    Friend Class cUDFromDesignCache
    '        Implements IDisposable

    '        Private oSurvey As cSurvey.cSurvey

    '        Private oItems As List(Of Design.Items.cItemInvertedFreeHandArea)
    '        Private oAllItems As List(Of Design.Items.cItemInvertedFreeHandArea)

    '        Private bIsEmpty As Boolean

    '        Private sFlatness As Single

    '        Public Function Intersect(Point1 As PointF, point2 As PointF, ByRef IntersectionPoint As PointF, ByRef Distance As Single) As Boolean
    '            Dim sMinDistance As Single = Single.MaxValue
    '            Dim oMinResult As PointF
    '            Dim bIntersect As Boolean
    '            For Each oItem As cItemInvertedFreeHandArea In oItems
    '                For Each oSequence As cSequence In oItem.Points.GetSequences
    '                    Dim oFlatSequence As List(Of PointF) = modPaint.ToStraightLinePoints(oItem.Survey, oSequence, DirectCast(oItem, Items.cIItemLine).LineType, sFlatness)
    '                    For i As Integer = 0 To oFlatSequence.Count - 2
    '                        Dim oPoint1 As PointF = oFlatSequence(i)
    '                        Dim oPoint2 As PointF = oFlatSequence(i + 1)
    '                        Dim oResult As PointF = modPaint.FindSegmentIntersection(Point1, point2, oPoint1, oPoint2, bIntersect)
    '                        If bIntersect Then
    '                            Dim sDistance As Single = modPaint.DistancePointToPoint(Point1, oResult)
    '                            If sDistance < sMinDistance Then
    '                                sMinDistance = sDistance
    '                                oMinResult = oResult
    '                            End If
    '                        End If
    '                    Next
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

    '        Public Sub PreparePath(CaveAndBraches As Dictionary(Of String, modCaveAndBranch.cCaveBranchPlaceholder))
    '            If Not bIsEmpty Then
    '                Call oItems.Clear()
    '                Dim bDone As Boolean
    '                For Each oCaveBranchPlaceholder As cCaveBranchPlaceholder In CaveAndBraches.Values
    '                    Dim sCave As String = oCaveBranchPlaceholder.Cave.ToLower
    '                    Dim sBranch As String = oCaveBranchPlaceholder.Branch.ToLower
    '                    Do
    '                        For Each oItem As cItemInvertedFreeHandArea In oAllItems
    '                            If oItem.Cave.ToLower = sCave AndAlso oItem.Branch.ToLower = sBranch AndAlso Not oItems.Contains(oItem) Then
    '                                Call oItems.Add(oItem)
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

    '        Public Sub New(Survey As cSurvey.cSurvey, Profile As cDesignProfile, PaintOptions As cOptions, Optional Flatness As Single = 0.01)
    '            oSurvey = Survey

    '            Dim oRealBounds As RectangleF = Profile.GetBounds(PaintOptions)
    '            oItems = New List(Of cItemInvertedFreeHandArea)
    '            sFlatness = Flatness
    '            If modPaint.IsRectangleEmpty(oRealBounds) Then
    '                bIsEmpty = True
    '            Else
    '                Dim oLayer As Layers.cLayerBorders = Profile.Layers.Item(cLayers.LayerTypeEnum.Borders)

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
    '                    Call oItems.Clear()
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

    Public Function GetUDFromDesign(PaintOptions As cOptions, Segment As cSegment, FromOrTo As GetDesignStationEnum) As SizeF
        Dim oPoint As PointF
        If FromOrTo = GetDesignStationEnum.From Then
            oPoint = Segment.Data.Profile.FromPoint
        Else
            oPoint = Segment.Data.Profile.ToPoint
        End If
        Return GetUDFromDesign(PaintOptions, Segment, oPoint, FromOrTo)
    End Function

    'Friend Function GetUDFromDesign(Survey As cSurvey.cSurvey, Cache As cUDFromDesignCache, Segment As cSegment, SegmentData As cSurveyPC.cSurvey.Calculate.Plot.cIProfileProjectedData, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
    '    If Cache.IsEmpty Then
    '        Return New SizeF(0, 0)
    '    Else
    '        Call Cache.PreparePath(GetCaveAndBranchList(Survey, Segment, SegmentData, FromOrTo))

    '        Dim iMaxWidth As Integer = 200

    '        Dim oResultPoint As PointF
    '        Dim sResult As Single
    '        Dim oUpPoint As PointF = New PointF(GenericPoint.X, GenericPoint.Y - iMaxWidth)
    '        Dim sUp As Single = 0
    '        If Cache.Intersect(GenericPoint, oUpPoint, oResultPoint, sResult) Then
    '            sUp = sResult
    '        End If

    '        Dim oDownPoint As PointF = New PointF(GenericPoint.X, GenericPoint.Y + iMaxWidth)
    '        Dim sDown As Single = 0
    '        If Cache.Intersect(GenericPoint, oDownPoint, oResultPoint, sResult) Then
    '            sDown = sResult
    '        End If

    '        Return New SizeF(sUp, sDown)
    '    End If
    'End Function

    Friend Function GetUDFromDesign(Survey As cSurvey.cSurvey, Cache As cLRUDFromDesignCache2, Segment As cSegment, SegmentData As cSurveyPC.cSurvey.Calculate.Plot.cIProfileProjectedData, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
        If Cache.IsEmpty Then
            Return New SizeF(0, 0)
        Else
            Dim iMaxWidth As Integer = 200

            Dim oResultPoint As PointF
            Dim sResult As Single
            Dim oUpPoint As PointF = New PointF(GenericPoint.X, GenericPoint.Y - iMaxWidth)
            Dim sUp As Single = 0
            If Cache.Intersect(Segment, GenericPoint, oUpPoint, oResultPoint, sResult) Then
                sUp = sResult
            End If

            Dim oDownPoint As PointF = New PointF(GenericPoint.X, GenericPoint.Y + iMaxWidth)
            Dim sDown As Single = 0
            If Cache.Intersect(Segment, GenericPoint, oDownPoint, oResultPoint, sResult) Then
                sDown = sResult
            End If

            Return New SizeF(sUp, sDown)
        End If
    End Function

    Public Function GetUDFromDesign(PaintOptions As cOptions, Segment As cSegment, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
        Dim oSurvey As cSurvey.cSurvey = Segment.Survey
        Dim oCache As cLRUDFromDesignCache2 = New cLRUDFromDesignCache2(oSurvey, oSurvey.Profile, PaintOptions)
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

    Friend Function GetFBFromDesign(Survey As cSurvey.cSurvey, Cache As cLRUDFromDesignCache2, Segment As cSegment, SegmentData As cSurveyPC.cSurvey.Calculate.Plot.cISpatialData, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
        'TODO....
        Return New SizeF(0, 0)
    End Function

    Public Function GetFBFromDesign(PaintOptions As cOptions, Segment As cSegment, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
        Dim oSurvey As cSurvey.cSurvey = Segment.Survey
        Dim oCache As cLRUDFromDesignCache2 = New cLRUDFromDesignCache2(oSurvey, oSurvey.Profile, PaintOptions)
        Return GetFBFromDesign(oSurvey, oCache, Segment, Segment.Data.Data, GenericPoint, FromOrTo)
    End Function

#End Region

End Module

