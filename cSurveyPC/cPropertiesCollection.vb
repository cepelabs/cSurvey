Imports System.Xml

Namespace cSurvey
    Public Class cPropertiesCollection
        Implements IEnumerable

        Private oSurvey As cSurvey

        Private oItems As Dictionary(Of String, Object)

        Friend Sub New(ByVal Survey As cSurvey)
            osurvey = Survey
            oItems = New Dictionary(Of String, Object)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal PropertiesCollections As XmlElement)
            oSurvey = Survey
            oItems = New Dictionary(Of String, Object)
            For Each oXMLItem As XmlElement In PropertiesCollections.ChildNodes
                Dim sName As String = oXMLItem.GetAttribute("name")
                Dim sType As String = oXMLItem.GetAttribute("type")
                Dim sValue As String = oXMLItem.InnerText
                Dim oValue As Object
                Select Case sType.ToLower
                    Case "cfont"
                        oValue = New cFont(oSurvey, oXMLItem.Item("font"))
                    Case "citemfont"
                        oValue = New Design.cItemFont(oSurvey, oXMLItem.Item("font"))
                    Case "color"
                        oValue = Color.FromArgb(sValue)
                    Case "single"
                        oValue = modNumbers.StringToSingle(sValue)
                    Case "double"
                        oValue = modNumbers.StringToDouble(sValue)
                    Case "integer"
                        oValue = CInt(sValue)
                    Case "decimal"
                        oValue = CDec(modNumbers.StringToDecimal(sValue))
                    Case "long"
                        oValue = CLng(sValue)
                    Case "date"
                        oValue = CDate(sValue)
                    Case Else
                        oValue = sValue
                End Select
                Call oItems.Add(sName, oValue)
            Next
        End Sub

        Public Sub CopyFrom(ByVal PropertyCollection As cPropertiesCollection)
            For Each oItem As KeyValuePair(Of String, Object) In PropertyCollection.oItems
                Dim sName As String = oItem.Key
                If oItems.ContainsKey(sName) Then
                    Call oItems.Remove(sname)
                End If
                Call oItems.Add(sName, oItem.Value)
            Next
        End Sub

        Public Sub Add(ByVal Name As String, ByVal Value As Object)
            Dim sName As String = Name.ToLower
            If oItems.ContainsKey(sName) Then
                Call oItems.Remove(sName)
            End If
            If Not Value Is Nothing Then
                Call oItems.Add(sName, Value)
            End If
        End Sub

        Public Sub Clear()
            Call oItems.Clear()
        End Sub

        Public Sub Remove(ByVal Name As String)
            Dim sName As String = Name.ToLower
            If oItems.ContainsKey(sName) Then
                Call oItems.Remove(sName)
            End If
        End Sub

        Default Public Property Item(ByVal Name As String) As Object
            Get
                Dim sName As String = Name.ToLower
                If oItems.ContainsKey(sName) Then
                    Return oItems(sName)
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As Object)
                Call Add(Name, value)
            End Set
        End Property

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Function GetValue(ByVal Name As String, Optional ByVal DefaultValue As Object = Nothing) As Object
            Dim sName As String = Name.ToLower
            If oItems.ContainsKey(sName) Then
                Return oItems(sName)
            Else
                Return DefaultValue
            End If
        End Function

        Public Sub SetValue(ByVal Name As String, ByVal Value As Object)
            Call Add(Name, Value)
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Name As String, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlPropertiesCollection As XmlElement = Document.CreateElement(Name)
            For Each sName As String In oItems.Keys
                Dim oValue As Object = oItems(sName)
                Dim sType As String = oValue.GetType.Name
                Dim oXmlPropertiesCollectionItem As XmlElement = Document.CreateElement("item")
                Call oXmlPropertiesCollectionItem.SetAttribute("name", sName)
                Call oXmlPropertiesCollectionItem.SetAttribute("type", sType)
                Select Case sType.ToLower
                    Case "citemfont"
                        Dim oValueFont As Design.cItemFont = oValue
                        Call oValueFont.SaveTo(File, Document, oXmlPropertiesCollectionItem, "font")
                    Case "cfont"
                        Dim oValueFont As cFont = oValue
                        Call oValueFont.SaveTo(File, Document, oXmlPropertiesCollectionItem, "font")
                    Case "color"
                        Dim oValueColor As Color = oValue
                        oXmlPropertiesCollectionItem.InnerText = oValueColor.ToArgb
                    Case "single", "double", "decimal"
                        oXmlPropertiesCollectionItem.InnerText = modNumbers.NumberToString(oValue)
                    Case Else
                        oXmlPropertiesCollectionItem.InnerText = oValue
                End Select
                Call oXmlPropertiesCollection.AppendChild(oXmlPropertiesCollectionItem)
            Next
            Call Parent.AppendChild(oXmlPropertiesCollection)
            Return oXmlPropertiesCollection
        End Function
    End Class
End Namespace