Imports cSurveyPC.cSurvey.cSurvey

Namespace cSurvey.Calculate.Plot
    Friend Class cProfileProjectedSubDatas
        Implements IEnumerable

        Private oItems As List(Of cProfileProjectedSubData)

        Friend Function Add(Parent As cData, [From] As String, [To] As String, Distance As Decimal) As cProfileProjectedSubData
            Dim oItem As cProfileProjectedSubData = New cProfileProjectedSubData(Parent, [From], [To], Distance)
            Call oItems.Add(oItem)
            Return oItem
        End Function

        Friend Function Add(Parent As cData, [From] As String, [To] As String, Distance As Decimal, FromUp As Decimal, FromDown As Decimal, ToUp As Decimal, ToDown As Decimal) As cProfileProjectedSubData
            Dim oItem As cProfileProjectedSubData = New cProfileProjectedSubData(Parent, [From], [To], Distance, FromUp, FromDown, ToUp, ToDown)
            Call oItems.Add(oItem)
            Return oItem
        End Function

        Friend Sub Clear()
            Call oItems.Clear()
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Default Public ReadOnly Property Item(Index As Integer) As cProfileProjectedSubData
            Get
                Return oItems(Index)
            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Friend Sub New()
            oItems = New List(Of cProfileProjectedSubData)
        End Sub
    End Class
End Namespace
