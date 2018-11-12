Imports cSurveyPC.cSurvey.cSurvey

Namespace cSurvey.Calculate.Plot
    Friend Class cPlanProjectedSubDatas
        Implements IEnumerable

        Private oItems As List(Of cPlanProjectedSubData)

        Friend Function Add(Parent As cData, Distance As Single) As cPlanProjectedSubData
            Dim oItem As cPlanProjectedSubData = New cPlanProjectedSubData(Parent, Distance)
            Call oItems.Add(oItem)
            Return oItem
        End Function

        Friend Function Add(Parent As cData, Distance As Single, FromLeft As Decimal, FromRight As Decimal, ToLeft As Decimal, ToRight As Decimal) As cPlanProjectedSubData
            Dim oItem As cPlanProjectedSubData = New cPlanProjectedSubData(Parent, [From], [To], Distance, FromLeft, FromRight, ToLeft, ToRight)
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

        Default Public ReadOnly Property Item(Index As Integer) As cPlanProjectedSubData
            Get
                Return oItems(Index)
            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Friend Sub New()
            oItems = New List(Of cPlanProjectedSubData)
        End Sub
    End Class
End Namespace
