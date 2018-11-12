Imports System.Xml
Imports cSurveyPC.cSurvey.Calculate

Namespace cSurvey
    Public Class cConnection
        Private sTrigPoint As String
        Private bIgnore As Boolean

        Friend Event OnChanged(ByVal Sender As cConnection)

        Friend Sub New(ByVal TrigPoint As String)
            If TrigPoint.StartsWith("!") Then
                sTrigPoint = TrigPoint.Substring(1)
                bIgnore = True
            Else
                sTrigPoint = TrigPoint
                bIgnore = False
            End If
        End Sub

        Public ReadOnly Property TrigPoint As String
            Get
                Return sTrigPoint
            End Get
        End Property

        Public Property Ignore As Boolean
            Get
                Return bIgnore
            End Get
            Set(ByVal value As Boolean)
                If value <> bIgnore Then
                    bIgnore = value
                    RaiseEvent OnChanged(Me)
                End If
            End Set
        End Property

        Public Overrides Function ToString() As String
            If bIgnore Then
                Return "!" & sTrigPoint
            Else
                Return sTrigPoint
            End If
        End Function
    End Class
End Namespace