Imports cSurveyPC.cSurvey.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate.Plot
    Friend Class cSplayProfileProjectedDatas
        Implements IEnumerable
        Implements IEnumerable(Of cSplayProfileProjectedData)

        Private oParent As cIProfileProjectedData
        Private oItems As List(Of cSplayProfileProjectedData)

        Public Function GetInRangeSplays() As List(Of cSplayProfileProjectedData)
            Return oItems.Where(Function(item) item.InRange).ToList
        End Function

        Public Function GetNotInRangeSplays() As List(Of cSplayProfileProjectedData)
            Return oItems.Where(Function(item) Not item.InRange).ToList
        End Function

        Friend Sub New(ByVal Survey As cSurvey, Parent As cIProjectedData, ByVal Item As XmlElement)
            oParent = Parent
            oItems = New List(Of cSplayProfileProjectedData)
            For Each oXMLItem As XmlElement In Item.ChildNodes
                Dim oItem As cSplayProfileProjectedData = New cSplayProfileProjectedData(Survey, oParent, oXMLItem)
                Call oItems.Add(oItem)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Name As String) As XmlElement
            Dim oXmlSPD As XmlElement = Document.CreateElement(Name)

            'for now I save also data required in older version...this data are not used now
            Call oXmlSPD.SetAttribute("fp", "0")
            '--------------

            For Each oItem As cSplayProfileProjectedData In oItems
                If oItem.isvalid Then
                    Call oItem.SaveTo(File, Document, oXmlSPD)
                End If
            Next
            Call Parent.AppendChild(oXmlSPD)
            Return oXmlSPD
        End Function

        Friend Function Add(Segment As cSegment, Point As PointD, UpPoint As PointD, DownPoint As PointD, InRange As Boolean) As cSplayProfileProjectedData
            Dim oItem As cSplayProfileProjectedData = New cSplayProfileProjectedData(oParent, Segment, Point, UpPoint, DownPoint, InRange)
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

        Default Public ReadOnly Property Item(Index As Integer) As cSplayProfileProjectedData
            Get
                Return oItems(Index)
            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Friend Sub New(ByVal Survey As cSurvey, Parent As cIProfileProjectedData)
            oParent = Parent
            oItems = New List(Of cSplayProfileProjectedData)
        End Sub

        Private Function cSplayProfileProjectedData_GetEnumerator() As IEnumerator(Of cSplayProfileProjectedData) Implements IEnumerable(Of cSplayProfileProjectedData).GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace
