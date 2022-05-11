Imports cSurveyPC.cSurvey.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate.Plot
    Friend Class cSurfaceProfileProjectedData
        Implements IEnumerable

        Private oParent As cProfileProjectedData
        Private oItems As List(Of PointF)

        Friend Sub New(Parent As cProfileProjectedData, ByVal Item As XmlElement)
            oParent = Parent
            oItems = New List(Of PointF)
            For Each oXMLItem As XmlElement In Item.ChildNodes
                Dim oPoint As PointF = New PointF(modNumbers.StringToSingle(oXMLItem.GetAttribute("x")), modNumbers.StringToSingle(oXMLItem.GetAttribute("y")))
                Call oItems.Add(oPoint)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlSurfaceProfilePD As XmlElement = Document.CreateElement("surfaceprofilepd")
            For Each oItem As PointF In oItems
                Dim oXMLProfilePDPoint As XmlElement = Document.CreateElement("p")
                Call oXMLProfilePDPoint.SetAttribute("x", modNumbers.NumberToString(oItem.X, ""))
                Call oXMLProfilePDPoint.SetAttribute("y", modNumbers.NumberToString(oItem.Y, ""))
                Call oXmlSurfaceProfilePD.AppendChild(oXMLProfilePDPoint)
            Next
            Call Parent.AppendChild(oXmlSurfaceProfilePD)
            Return oXmlSurfaceProfilePD
        End Function

        Public Function ToArray() As PointF()
            Return oItems.ToArray
        End Function

        Friend Sub Append(Point As PointF)
            Call oItems.Add(Point)
        End Sub

        Default Public ReadOnly Property Items(Index As Integer) As PointF
            Get
                Return oItems(Index)
            End Get
        End Property

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Sub Clear()
            Call oItems.Clear()
        End Sub

        Friend Sub New(Parent As cProfileProjectedData)
            oParent = Parent
            oItems = New List(Of PointF)
        End Sub

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace