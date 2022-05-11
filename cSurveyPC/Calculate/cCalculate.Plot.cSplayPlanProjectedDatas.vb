Imports cSurveyPC.cSurvey.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate.Plot
    Friend Class cSplayPlanProjectedDatas
        Implements IEnumerable
        Implements IEnumerable(Of cSplayPlanProjectedData)

        Private oParent As cIPlanProjectedData
        Private oItems As List(Of cSplayPlanProjectedData)

        Public Function GetInRangeSplays() As List(Of cSplayPlanProjectedData)
            Return oItems.Where(Function(item) item.InRange).ToList
        End Function

        Public Function GetNotInRangeSplays() As List(Of cSplayPlanProjectedData)
            Return oItems.Where(Function(item) Not item.InRange).ToList
        End Function

        Friend Sub New(ByVal Survey As cSurvey, Parent As cIProjectedData, ByVal Item As XmlElement)
            oParent = Parent
            oItems = New List(Of cSplayPlanProjectedData)
            For Each oXMLItem As XmlElement In Item.ChildNodes
                Dim oItem As cSplayPlanProjectedData = New cSplayPlanProjectedData(Survey, oParent, oXMLItem)
                Call oItems.Add(oItem)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Name As String) As XmlElement
            Dim oXmlSPD As XmlElement = Document.CreateElement(Name)

            'for now I save also data required in older version...this data are not used now
            Call oXmlSPD.SetAttribute("fp", "0")
            '--------------

            For Each oItem As cSplayPlanProjectedData In oItems
                If oItem.IsValid Then
                    Call oItem.SaveTo(File, Document, oXmlSPD)
                End If
            Next
            Call Parent.AppendChild(oXmlSPD)
            Return oXmlSPD
        End Function

        Friend Function Add(Segment As cSegment, Point As PointD, LeftPoint As PointD, RightPoint As PointD, InRange As Boolean) As cSplayPlanProjectedData
            Dim oItem As cSplayPlanProjectedData = New cSplayPlanProjectedData(oParent, Segment, Point, LeftPoint, RightPoint, InRange)
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

        Default Public ReadOnly Property Item(Index As Integer) As cSplayPlanProjectedData
            Get
                Return oItems(Index)
            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Friend Sub New(ByVal Survey As cSurvey, Parent As cIPlanProjectedData)
            oParent = Parent
            oItems = New List(Of cSplayPlanProjectedData)
        End Sub

        Private Function IEnumerable_GetEnumerator() As IEnumerator(Of cSplayPlanProjectedData) Implements IEnumerable(Of cSplayPlanProjectedData).GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace
