Namespace cSurvey
    Public Class cActionResult
        Private bResult As Boolean
        Private sExceptionSource As String
        Private oException As Exception

        Public ReadOnly Property Result As Boolean
            Get
                Return bResult
            End Get
        End Property

        Public ReadOnly Property ExceptionSource As String
            Get
                Return sExceptionSource
            End Get
        End Property

        Public ReadOnly Property Exception As Exception
            Get
                Return oException
            End Get
        End Property

        Friend Sub New()
            bResult = True
            sExceptionSource = ""
        End Sub

        Friend Sub New(ByVal Result As Boolean, ByVal ExceptionSource As String, ByVal Exception As Exception)
            bResult = Result
            sExceptionSource = ExceptionSource
            oException = Exception
        End Sub

        Friend Sub New(ByVal Result As Boolean, ByVal ExceptionSource As String, ByVal ExceptionMessage As String)
            bResult = Result
            sExceptionSource = ExceptionSource
            oException = New Exception(ExceptionMessage)
        End Sub
    End Class
End Namespace