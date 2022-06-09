Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Scale
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Imports System.Xml
Imports System.Collections.ObjectModel

Namespace cSurvey.Design.Options
    Public Class cHighlightsOptions
        Implements IEnumerable
        Implements cIUIBaseInteractions

        Private oSurvey As cSurvey

        Private oItems As List(Of String)

        Public Event OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Implements cIUIBaseInteractions.OnPropertyChanged

        Public Sub PropertyChanged(Name As String) Implements cIUIBaseInteractions.PropertyChanged
            RaiseEvent OnPropertyChanged(Me, New PropertyChangeEventArgs(Name))
        End Sub

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

        ''' <summary>
        ''' Set options value
        ''' </summary>
        ''' <param name="Item">Option to change</param>
        ''' <param name="Value">Option's value</param>
        ''' <returns>Return True if option was changed, false if not</returns>
        Public Function [Set](Item As Properties.cHighlightsDetail, Value As Boolean) As Boolean
            Return [Set](Item.ID, Value)
        End Function

        ''' <summary>
        ''' Set options value
        ''' </summary>
        ''' <param name="Name">Option's name</param>
        ''' <param name="Value">Option's value</param>
        ''' <returns>Return True if option was changed, false if not</returns>
        Public Function [Set](Name As String, Value As Boolean) As Boolean
            If Value Then
                Return Add(Name)
            Else
                Return Remove(Name)
            End If
        End Function

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

        Friend Function Add(Item As Properties.cHighlightsDetail) As Boolean
            Return Add(Item.ID)
        End Function

        Friend Function Add(Name As String) As Boolean
            If oItems.Contains(Name, StringComparer.OrdinalIgnoreCase) Then
                Return False
            Else
                Call oItems.Add(Name)
                Call PropertyChanged(Name)
                Return True
            End If
        End Function

        Public Sub Clear()
            Call oItems.Clear()
            Call PropertyChanged("Clear")
        End Sub

        Friend Function Remove(Item As Properties.cHighlightsDetail) As Boolean
            Return Remove(Item.ID)
        End Function

        Friend Function Remove(Name As String) As Boolean
            If oItems.Contains(Name, StringComparer.OrdinalIgnoreCase) Then
                Call oItems.Remove(Name)
                Call PropertyChanged(Name)
                Return True
            Else
                Return False
            End If
        End Function

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
