Public Class cPanel
    Private sText As String

    Public Overrides Property Text As String
        Get
            Return sText
        End Get
        Set(value As String)
            sText = value
        End Set
    End Property
End Class
