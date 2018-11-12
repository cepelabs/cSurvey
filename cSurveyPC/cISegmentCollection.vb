Namespace cSurvey
    Public Interface cISegmentCollection
        Inherits IEnumerable
        Inherits IEnumerable(Of cISegment)

        Enum SessionSegmentsFlagEnum
            SurveyShots = 0
            CalibrationShots = 1
        End Enum

        ReadOnly Property Count() As Integer

        Function GetTrigpoints() As cITrigPointCollection
        Function GetTrigpointsNames() As SortedSet(Of String)
        Function Find(ByVal Text As String) As cISegmentCollection

        Function GetBindedItems() As List(Of Design.cItem)
        Function GetBindedItems(Design As cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum) As List(Of Design.cItem)
        Function GetVisibleSegments(PaintOptions As Design.cOptions) As cSegmentCollection
        Function GetVisibleCaveSegments(PaintOptions As Design.cOptions, ByVal Cave As String, Optional ByVal Branch As String = "") As cSegmentCollection
        Function GetCaveSegments(ByVal Cave As String, Optional ByVal Branch As String = "") As cSegmentCollection
        Function GetCaveSegments(ByVal CaveInfoBranch As cCaveInfoBranch) As cSegmentCollection
        Function GetCaveSegments(ByVal CaveInfo As cCaveInfo) As cSegmentCollection
        Function GetSessionSegments(ByVal SessionID As String, Optional Flags As SessionSegmentsFlagEnum = cISegmentCollection.SessionSegmentsFlagEnum.SurveyShots) As cSegmentCollection
        Function GetSessionSegments(ByVal Session As cSession, Optional Flags As SessionSegmentsFlagEnum = cISegmentCollection.SessionSegmentsFlagEnum.SurveyShots) As cSegmentCollection
        Function GetSessions() As List(Of cSession)
        Function GetBindedSegments() As cSegmentCollection
        Function GetBindedSegments(Design As cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum) As cSegmentCollection

        Function IndexOf(ByVal Segment As cISegment) As Integer
        Function IndexOf(ByVal ID As String) As Integer
        Default ReadOnly Property Item(ByVal Index As Integer) As cISegment
        Default ReadOnly Property Item(ByVal ID As String) As cISegment
        Function Contains(ByVal Segment As cISegment) As Boolean
        Function Contains(ByVal ID As String) As Boolean
        Function Intersect(Segments As cISegmentCollection) As cISegmentCollection

        Function ToCSV(Optional UseLocalFormat As Boolean = False) As String
        Function ToTSV(Optional UseLocalFormat As Boolean = False) As String
        Function ToArray() As cISegment()
        Function ToList() As List(Of cISegment)

        Function GetSurveySegments() As cSegmentCollection
        Function GetCalibrationSegments() As cSegmentCollection
    End Interface
End Namespace