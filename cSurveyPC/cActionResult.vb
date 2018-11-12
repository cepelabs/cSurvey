Namespace cSurvey
    Public Class cActionResult
        Private bResult As Boolean
        Private sErrorSource As String
        Private sErrorMessage As String

        Public ReadOnly Property Result As Boolean
            Get
                Return bResult
            End Get
        End Property

        Public ReadOnly Property ErrorSource As String
            Get
                Return sErrorSource
            End Get
        End Property

        Public ReadOnly Property ErrorMessage As String
            Get
                Return sErrorMessage
            End Get
        End Property

        Friend Sub New()
            bResult = True
            sErrorSource = ""
            sErrorMessage = ""
        End Sub

        Friend Sub New(ByVal Result As Boolean, ByVal ErrorSource As String, ByVal ErrorMessage As String)
            bResult = Result
            sErrorSource = ErrorSource
            sErrorMessage = ErrorMessage
        End Sub
    End Class
End Namespace