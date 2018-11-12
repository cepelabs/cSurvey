Imports System.Xml

Namespace cSurvey.Calculate
    Public Class cSegments
        Implements IEnumerable
        Implements IEnumerable(Of Plot.cData)

        Private oSurvey As cSurvey

        Private oItems As Dictionary(Of String, Plot.cData)

        Friend Sub New(Survey As cSurvey, ByVal Item As XmlElement)
            oSurvey = Survey
            oItems = New Dictionary(Of String, Plot.cData)(StringComparer.OrdinalIgnoreCase)
        End Sub

        Friend Sub New(Survey As cSurvey)
            oSurvey = Survey
            oItems = New Dictionary(Of String, Plot.cData)(StringComparer.OrdinalIgnoreCase)
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlSegments As XmlElement = Document.CreateElement("sgs")
            For Each oItem As KeyValuePair(Of String, Plot.cData) In oItems
                Dim oXmlSegment As XmlElement = oItem.Value.SaveTo(File, Document, oXmlSegments)
                Call oXmlSegment.SetAttribute("sgid", oItem.Key)
            Next
            Call Parent.AppendChild(oXmlSegments)
            Return oXmlSegments
        End Function

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function

        Private Function cData_GetEnumerator() As IEnumerator(Of Plot.cData) Implements IEnumerable(Of Plot.cData).GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Function Contains(Segment As cSegment) As Boolean
            Return oItems.ContainsKey(Segment.ID)
        End Function

        Public Function Contains(SegmentID As String) As Boolean
            Return oItems.ContainsKey(SegmentID)
        End Function

        Default Public ReadOnly Property Item(SegmentID As String) As Plot.cData
            Get
                If oItems.ContainsKey(SegmentID) Then
                    Return oItems(SegmentID)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Default Public ReadOnly Property Item(Segment As cSegment) As Plot.cData
            Get
                If oItems.ContainsKey(Segment.ID) Then
                    Return oItems(Segment.ID)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Function Find(From As String, [To] As String) As List(Of Plot.cData)
            If IsNothing([To]) AndAlso Not IsNothing(From) Then
                Return New List(Of Plot.cData)(oItems.Where(Function(oItem) oItem.Value.Data.From = From).Select(Function(oitem) oitem.Value))
            ElseIf Not IsNothing([To]) AndAlso IsNothing(From) Then
                Return New List(Of Plot.cData)(oItems.Where(Function(oItem) oItem.Value.Data.To = [To]).Select(Function(oitem) oitem.Value))
            ElseIf Not IsNothing([To]) AndAlso Not IsNothing(From) Then
                Return New List(Of Plot.cData)(oItems.Where(Function(oItem) oItem.Value.Data.From = From AndAlso oItem.Value.Data.To = [To]).Select(Function(oitem) oitem.Value))
            Else
                Return Nothing
            End If
        End Function

        Public Function FindFirst(From As String, [To] As String) As Plot.cData
            If IsNothing([To]) AndAlso Not IsNothing(From) Then
                Return oItems.FirstOrDefault(Function(oItem) oItem.Value.Data.From = From).Value
            ElseIf Not IsNothing([To]) AndAlso IsNothing(From) Then
                Return oItems.FirstOrDefault(Function(oItem) oItem.Value.Data.To = [To]).Value
            ElseIf Not IsNothing([To]) AndAlso Not IsNothing(From) Then
                Return oItems.FirstOrDefault(Function(oItem) oItem.Value.Data.From = From AndAlso oItem.Value.Data.To = [To]).Value
            Else
                Return Nothing
            End If
        End Function

        Friend Sub Clear()
            Call oItems.Clear()
        End Sub

        Friend Function Append(ByVal Segment As cSegment) As Plot.cData
            Call oItems.Add(Segment.ID, Segment.Data)
            Return Segment.Data
        End Function
    End Class
End Namespace
