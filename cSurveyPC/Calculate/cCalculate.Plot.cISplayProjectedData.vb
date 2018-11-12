Namespace cSurvey.Calculate.Plot
    Public Interface cISplayProjectedData
        ReadOnly Property Parent As cIProjectedData

        ReadOnly Property [To] As String
        Function GetSplaySegment() As cSegment

        ReadOnly Property ToPoint As PointD
        ReadOnly Property LorUPoint As PointD
        ReadOnly Property RorDPoint As PointD

        ReadOnly Property InRange As Boolean
    End Interface
End Namespace