Imports System.Xml

Namespace cSurvey
    Public Class cSharedSettings
        Implements IEnumerable

        Private oSurvey As cSurvey
        Private oItems As Dictionary(Of String, String)

        Public ReadOnly Property Count() As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Function Contains(Name As String) As Boolean
            Return oItems.ContainsKey(Name)
        End Function

        Public Sub SetValue(ByVal Name As String, ByVal Value As String)
            If oItems.ContainsKey(Name) Then
                Call oItems.Remove(Name)
            End If
            If Not Value Is Nothing Then
                Call oItems.Add(Name, Value)
            End If
        End Sub

        Public Function GetValue(ByVal Name As String, Optional ByVal DefaultValue As String = "") As Object
            If oItems.ContainsKey(Name) Then
                Return oItems(Name)
            Else
                Return DefaultValue
            End If
        End Function

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oItems = New Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)
            'legacy options...for loaded settings this must be in the file, for new I set it to avoid legacy behaviour
            Call SetValue("legacycalculation1", "off")
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal SharedSettings As XmlElement)
            oSurvey = Survey
            oItems = New Dictionary(Of String, String)(StringComparer.CurrentCultureIgnoreCase)
            For Each oAttribute As XmlAttribute In SharedSettings.Item("values").Attributes
                Call oItems.Add(oAttribute.Name, oAttribute.Value)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLSharedSettings As XmlElement = Document.CreateElement("sharedsettings")
            Dim oXMLValues As XmlElement = Document.CreateElement("values")
            For Each sName As String In oItems.Keys
                Dim sValue As String = oItems(sName)
                Call oXMLValues.SetAttribute(sName, sValue)
            Next
            Call oXMLSharedSettings.AppendChild(oXMLValues)
            Call Parent.AppendChild(oXMLSharedSettings)
            Return oXMLSharedSettings
        End Function
    End Class
End Namespace