Namespace cSurvey
    Public Interface cITrigPointCollection
        Inherits IEnumerable
        Inherits IEnumerable(Of cTrigPoint)

        ReadOnly Property Count() As Integer

        Function GetStations(Splay As Boolean) As cTrigPointCollection
        'Function GetCaveFirstEntrance(Cave As String, ByVal Entrance As cTrigPoint.EntranceTypeEnum) As cTrigPoint
        'Function GetCaveFirstEntrance(CaveInfo As cCaveInfo, ByVal Entrance As cTrigPoint.EntranceTypeEnum) As cTrigPoint
        Function GetFirstEntrance(ByVal Entrance As cTrigPoint.EntranceTypeEnum) As cTrigPoint
        Function GetEntrances(ByVal Entrance As cTrigPoint.EntranceTypeEnum) As cTrigPointCollection
        Function GetAllEntrances() As cTrigPointCollection
        'Function GetCaveAllEntrances(CaveInfo As cCaveInfo) As cTrigPointCollection
        'Function GetCaveAllEntrances(Cave As String) As cTrigPointCollection

        Function Contains(ByVal trigpoint As cTrigPoint) As Boolean
        Function Contains(ByVal Name As String) As Boolean

        Default ReadOnly Property Item(ByVal Name As String) As cTrigPoint
        Default ReadOnly Property Item(ByVal Index As Integer) As cTrigPoint

        Function ToArray() As cTrigPoint()
        Function ToList() As List(Of cTrigPoint)

        Function GetNames() As List(Of String)
    End Interface
End Namespace
