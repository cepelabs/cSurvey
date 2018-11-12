Imports cSurveyPC.cSurvey.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate.Plot
    Friend Class cProfileSubDatas
        Implements IEnumerable
        Implements IEnumerable(Of cProfileSubData)

        Private oItems As List(Of cProfileSubData)

        Friend Sub New(Parent As cSubData, ByVal Item As XmlElement)
            For Each oXMLItem As XmlElement In Item.ChildNodes
                Dim oItem As cProfileSubData = New cProfileSubData(Parent, oXMLItem)
                Call oItems.Add(oItem)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlProfileSDS As XmlElement = Document.CreateElement("profilesds")
            For Each oItem As cProfileSubData In oItems
                Call oItem.SaveTo(File, Document, oXmlProfileSDS)
            Next
            Call Parent.AppendChild(oXmlProfileSDS)
            Return oXmlProfileSDS
        End Function

        Friend Sub Append(Item As cProfileSubData)
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

        Default Public ReadOnly Property Item(Index As Integer) As cProfileSubData
            Get
                Return oItems(Index)
            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Friend Sub New()
            oItems = New List(Of cProfileSubData)
        End Sub

        Private Function cProfileSubData_GetEnumerator() As IEnumerator(Of cProfileSubData) Implements IEnumerable(Of cProfileSubData).GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace