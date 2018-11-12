Namespace cSurvey
    Public Interface cISegment
        Inherits cICaveBranch

        Enum SegmentTypeEnum
            Segment = 0
            CrossSection = 1
        End Enum

        ReadOnly Property ID As String
        ReadOnly Property Session As String

        Property [From] As String
        Property [To] As String
        ReadOnly Property Type As SegmentTypeEnum
        ReadOnly Property Data As Calculate.Plot.cData

        Function IsSelfDefined() As Boolean
        Function IsValid() As Boolean
        Function IsEquate() As Boolean
        Function IsUnbindable() As Boolean

        Property Exclude() As Boolean
        Property Splay() As Boolean
        Property Surface() As Boolean
        Property Duplicate() As Boolean
        Property Calibration() As Boolean
        Property Virtual() As Boolean

        Function GetLocked() As Boolean

        Function ToCSV(Optional UseLocalFormat As Boolean = False) As String
        Function ToTSV(Optional UseLocalFormat As Boolean = False) As String
    End Interface
End Namespace