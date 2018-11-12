Imports cSurveyPC.cSurvey.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate.Plot
    Friend Class cSplayProjectedDatas
        Implements IEnumerable
        Implements IEnumerable(Of cSplayProjectedData)

        Friend Enum SplayFromPointEnum
            [From] = 0
            [To] = 1
        End Enum

        Private oParent As cIProjectedData
        Private iFromPoint As SplayFromPointEnum
        Private oItems As List(Of cSplayProjectedData)

        Friend Sub New(Parent As cIProjectedData, ByVal Item As XmlElement)
            oParent = Parent
            oItems = New List(Of cSplayProjectedData)
            iFromPoint = modNumbers.StringToInteger(Item.GetAttribute("fp"))
            For Each oXMLItem As XmlElement In Item.ChildNodes
                Dim oItem As cSplayProjectedData = New cSplayProjectedData(oParent, oXMLItem)
                Call oItems.Add(oItem)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Name As String) As XmlElement
            Dim oXmlSPD As XmlElement = Document.CreateElement(Name)

            'for now I save also data required in older version...this data are not used now
            Call oXmlSPD.SetAttribute("fp", "0")
            '--------------

            For Each oItem As cSplayProjectedData In oItems
                Call oItem.SaveTo(File, Document, oXmlSPD)
            Next
            Call Parent.AppendChild(oXmlSPD)
            Return oXmlSPD
        End Function

        Friend Function Add(Segment As cSegment, ToPoint As PointF) As cSplayProjectedData
            Dim oItem As cSplayProjectedData = New cSplayProjectedData(oParent, Segment.ID, Segment.To, iFromPoint, ToPoint)
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

        Default Public ReadOnly Property Item(Index As Integer) As cSplayProjectedData
            Get
                Return oItems(Index)
            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Friend Sub New(Parent As cIProjectedData, FromPoint As SplayFromPointEnum)
            oParent = Parent
            iFromPoint = FromPoint
            oItems = New List(Of cSplayProjectedData)
        End Sub

        Private Function IEnumerable_GetEnumerator() As IEnumerator(Of cSplayProjectedData) Implements IEnumerable(Of cSplayProjectedData).GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace
