Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Scale
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Imports System.Xml
Imports System.Collections.ObjectModel

Namespace cSurvey.Design.Options
    Public Class cHighlightsOptions
        Implements IEnumerable

        Private oSurvey As cSurvey

        Private oItems As List(Of String)

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oItems = New List(Of String)
        End Sub

        Public Function [Get](Name As String) As Boolean
            Return oItems.Contains(Name, StringComparer.OrdinalIgnoreCase)
        End Function

        Public Function [Get](Item As Properties.cHighlightsDetail) As Boolean
            Return oItems.Contains(Item.ID, StringComparer.OrdinalIgnoreCase)
        End Function

        Public Sub [Set](Item As Properties.cHighlightsDetail, Value As Boolean)
            Call [Set](Item.ID, Value)
        End Sub

        Public Sub [Set](Name As String, Value As Boolean)
            If Value Then
                Call Add(Name)
            Else
                Call Remove(Name)
            End If
        End Sub

        Default Public ReadOnly Property Item(Index As Integer) As String
            Get
                If Index >= 0 And Index < oItems.Count Then
                    Return oItems(Index)
                Else
                    Return ""
                End If
            End Get
        End Property

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Sub Add(Item As Properties.cHighlightsDetail)
            Call Add(Item.ID)
        End Sub

        Public Sub Add(Name As String)
            If Not oItems.Contains(Name, StringComparer.OrdinalIgnoreCase) Then
                Call oItems.Add(Name)
            End If
        End Sub

        Public Sub Clear()
            Call oItems.Clear()
        End Sub

        Public Sub Remove(Item As Properties.cHighlightsDetail)
            Call Remove(Item.ID)
        End Sub

        Public Sub Remove(Name As String)
            If oItems.Contains(Name, StringComparer.OrdinalIgnoreCase) Then
                Call oItems.Remove(Name)
            End If
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal HighlightsOptions As XmlElement)
            oSurvey = Survey
            oItems = New List(Of String)
            For Each sName As String In modXML.GetAttributeValue(HighlightsOptions, "v", "").ToString.Split({"|"}, System.StringSplitOptions.RemoveEmptyEntries)
                Call oItems.Add(sName)
            Next
        End Sub

        Friend Sub Rebind()
            oItems = New List(Of String)(oItems.Where(Function(item) oSurvey.Properties.HighlightsDetails.Contains(item)))
        End Sub

        Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Call Rebind()
            Dim oXMLHighlightsOptions As XmlElement = Document.CreateElement("hlsoptions")
            Call oXMLHighlightsOptions.SetAttribute("v", String.Join("|", oItems))
            Call Parent.AppendChild(oXMLHighlightsOptions)
            Return oXMLHighlightsOptions
        End Function

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace
