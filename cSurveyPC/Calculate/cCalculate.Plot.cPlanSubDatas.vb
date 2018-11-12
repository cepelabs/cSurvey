Imports cSurveyPC.cSurvey.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate.Plot
    Friend Class cPlanSubDatas
        Implements IEnumerable
        Implements IEnumerable(Of cPlanSubData)

        Private oItems As List(Of cPlanSubData)

        Friend Sub New(Parent As cSubData, ByVal Item As XmlElement)
            For Each oXMLItem As XmlElement In Item.ChildNodes
                Dim oItem As cPlanSubData = New cPlanSubData(Parent, oXMLItem)
                Call oItems.Add(oItem)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlProfileSDS As XmlElement = Document.CreateElement("plansds")
            For Each oItem As cPlanSubData In oItems
                Call oItem.SaveTo(File, Document, oXmlProfileSDS)
            Next
            Call Parent.AppendChild(oXmlProfileSDS)
            Return oXmlProfileSDS
        End Function

        Friend Sub Append(Item As cPlanSubData)
            Call oItems.Add(Item)
        End Sub

        Friend Sub Clear()
            Call oItems.Clear()
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Default Public ReadOnly Property Item(Index As Integer) As cPlanSubData
            Get
                Return oItems(Index)
            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Friend Sub New()
            oItems = New List(Of cPlanSubData)
        End Sub

        Private Function cPlanSubData_GetEnumerator() As IEnumerator(Of cPlanSubData) Implements IEnumerable(Of cPlanSubData).GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace