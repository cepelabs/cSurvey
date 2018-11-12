Namespace cSurvey
    Public Interface cICaveInfo
        Property ID As String
        ReadOnly Property Name As String
        Property Description As String
    End Interface

    Public Interface cICaveBranch
        ReadOnly Property Cave As String
        ReadOnly Property Branch As String
    End Interface
End Namespace