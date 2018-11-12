Imports cSurveyPC.cSurvey.cSurvey

Namespace cSurvey.Calculate.Plot
    Public Interface cIProjectedData
        ReadOnly Property [From] As String
        ReadOnly Property [To] As String
        ReadOnly Property FromPoint() As PointD
        ReadOnly Property ToPoint() As PointD
        'ReadOnly Property Reversed As Boolean
        Function GetCenterPoint() As PointD
    End Interface
End Namespace