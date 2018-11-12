Imports cSurveyPC.cSurvey.cSurvey

Namespace cSurvey.Calculate.Plot
    Friend Interface cISpatialData
        ReadOnly Property [To] As String
        ReadOnly Property [From] As String

        ReadOnly Property Distance As Decimal
        ReadOnly Property Inclination As Decimal
        ReadOnly Property Bearing As Decimal

        ReadOnly Property Direction As cSurvey.DirectionEnum

        ReadOnly Property Reversed As Boolean
    End Interface
End Namespace
