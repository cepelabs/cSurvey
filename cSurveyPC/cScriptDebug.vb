Namespace cSurvey.Scripting
    Public Class cScriptDebug
        Friend Class cPrintEventArgs
            Private sText As String

            Public ReadOnly Property Text As String
                Get
                    Return sText
                End Get
            End Property

            Friend Sub New(Text As String)
                sText = Text
            End Sub
        End Class

        Friend Event OnPrint(Sender As cScriptDebug, PrintEventArgs As cPrintEventArgs)

        Public Sub Print(ParamArray Text() As String)
            Dim sText As String = Strings.Join(Text, vbTab)
            RaiseEvent OnPrint(Me, New cPrintEventArgs(sText))
        End Sub
    End Class
End Namespace
