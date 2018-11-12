Imports System.Xml

Namespace cSurvey
    Public Class cTrigPointCollection
        Implements IEnumerable
        Implements IEnumerable(Of cTrigPoint)
        Implements cITrigPointCollection

        Private oSurvey As cSurvey

        Private oTrigPoints As SortedList(Of String, cTrigPoint)

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oTrigPoints = New SortedList(Of String, cTrigPoint)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, Trigpoints As IDictionary(Of String, cTrigPoint))
            oSurvey = Survey
            oTrigPoints = New SortedList(Of String, cTrigPoint)(Trigpoints)
        End Sub

        Friend Sub Append(ByVal Trigpoint As cTrigPoint)
            Call oTrigPoints.Add(trigpoint.Name, trigpoint)
        End Sub

        Public ReadOnly Property Count() As Integer Implements cItrigpointCollection.Count
            Get
                Return otrigpoints.Count
            End Get
        End Property

        Public Function GetAllEntrances() As cTrigPointCollection Implements cITrigPointCollection.GetAllEntrances
            Return New cTrigPointCollection(oSurvey, oTrigPoints.Values.Where(Function(TrigPoint) TrigPoint.Entrance > cTrigPoint.EntranceTypeEnum.None And TrigPoint.Entrance < cTrigPoint.EntranceTypeEnum.OutSide).ToDictionary(Function(trigpoint) trigpoint.Name))
        End Function

        Public Function GetCaveFirstEntrance(CaveInfo As cCaveInfo, ByVal Entrance As cTrigPoint.EntranceTypeEnum) As cTrigPoint Implements cITrigPointCollection.GetCaveFirstEntrance
            Return GetCaveFirstEntrance(CaveInfo.Name, Entrance)
        End Function

        Public Function GetCaveFirstEntrance(Cave As String, ByVal Entrance As cTrigPoint.EntranceTypeEnum) As cTrigPoint Implements cITrigPointCollection.GetCaveFirstEntrance
            Return oSurvey.Segments.GetCaveSegments(Cave).GetTrigPoints.ToList.FirstOrDefault(Function(TrigPoint) TrigPoint.Entrance >= Entrance And TrigPoint.Entrance < cTrigPoint.EntranceTypeEnum.OutSide)
        End Function

        Public Function GetFirstEntrance(ByVal Entrance As cTrigPoint.EntranceTypeEnum) As cTrigPoint Implements cITrigPointCollection.GetFirstEntrance
            Return oTrigPoints.Values.FirstOrDefault(Function(TrigPoint) TrigPoint.Entrance >= Entrance And TrigPoint.Entrance < cTrigPoint.EntranceTypeEnum.OutSide)
        End Function

        Public Function GetEntrances(ByVal Entrance As cTrigPoint.EntranceTypeEnum) As cTrigPointCollection Implements cITrigPointCollection.GetEntrances
            Return New cTrigPointCollection(oSurvey, oTrigPoints.Values.Where(Function(TrigPoint) TrigPoint.Entrance >= Entrance And TrigPoint.Entrance < cTrigPoint.EntranceTypeEnum.OutSide).ToDictionary(Function(trigpoint) trigpoint.Name))
        End Function

        Public Function GetCaveAllEntrances(CaveInfo As cCaveInfo) As cTrigPointCollection Implements cITrigPointCollection.GetCaveAllEntrances
            Return GetCaveAllEntrances(CaveInfo.Name)
        End Function

        Public Function GetCaveAllEntrances(Cave As String) As cTrigPointCollection Implements cITrigPointCollection.GetCaveAllEntrances
            Return oSurvey.Segments.GetCaveSegments(Cave).GetTrigPoints.ToList.Where(Function(TrigPoint) TrigPoint.Entrance > cTrigPoint.EntranceTypeEnum.None And TrigPoint.Entrance < cTrigPoint.EntranceTypeEnum.OutSide)
        End Function

        Public Function ToArray() As cTrigPoint() Implements cITrigPointCollection.ToArray
            Return oTrigPoints.Values.ToArray
        End Function

        Public Function ToList() As List(Of cTrigPoint) Implements cITrigPointCollection.ToList
            Return oTrigPoints.Values.ToList
        End Function

        Public Function GetNames() As List(Of String) Implements cITrigPointCollection.GetNames
            Return New List(Of String)(oTrigPoints.Keys)
        End Function

        Public Function Contains(ByVal trigpoint As cTrigPoint) As Boolean Implements cITrigPointCollection.Contains
            Return otrigpoints.ContainsValue(trigpoint)
        End Function

        Public Function Contains(ByVal Name As String) As Boolean Implements cITrigPointCollection.Contains
            Return otrigpoints.ContainsKey(Name)
        End Function

        Default Public ReadOnly Property Item(ByVal Name As String) As cTrigPoint Implements cITrigPointCollection.Item
            Get
                Return otrigpoints(Name)
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal Index As Integer) As cTrigPoint Implements cITrigPointCollection.Item
            Get
                Return otrigpoints.ElementAt(Index).Value
            End Get
        End Property

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return otrigpoints.Values.GetEnumerator
        End Function

        Private Function cTrigpoint_GetEnumerator() As IEnumerator(Of cTrigPoint) Implements IEnumerable(Of cTrigPoint).GetEnumerator
            Return oTrigPoints.Values.GetEnumerator
        End Function
    End Class
End Namespace
