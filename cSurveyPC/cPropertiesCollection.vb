Imports System.Xml

Namespace cSurvey
    Public Interface cIDesignProperties
        ReadOnly Property DesignProperties As cPropertiesCollection
    End Interface

    Public Class cPropertiesCollection
        Implements IEnumerable

        Private oSurvey As cSurvey

        Public Class cGetParentEventArgs
            Inherits EventArgs

            Private oParent As cPropertiesCollection

            Public Property Parent As cPropertiesCollection
                Get
                    Return oParent
                End Get
                Set(value As cPropertiesCollection)
                    oParent = value
                End Set
            End Property

            Public Sub New()
            End Sub

            Public Sub New(Parent As cPropertiesCollection)
                oParent = Parent
            End Sub
        End Class
        Public Event OnGetParent(sender As Object, e As cGetParentEventArgs)

        Private oItems As Dictionary(Of String, Object)

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oItems = New Dictionary(Of String, Object)(StringComparer.OrdinalIgnoreCase)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal PropertiesCollections As XmlElement)
            oSurvey = Survey
            oItems = New Dictionary(Of String, Object)(StringComparer.OrdinalIgnoreCase)
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

        Public Sub MergeWith(ByVal PropertyCollection As cPropertiesCollection)
            If Not PropertyCollection Is Me Then
                For Each oItem As KeyValuePair(Of String, Object) In PropertyCollection.oItems
                    Dim sName As String = oItem.Key
                    If Not oItems.ContainsKey(sName) Then
                        Call oItems.Add(sName, oItem.Value)
                    End If
                Next
            End If
        End Sub

        Public Sub CopyFrom(ByVal PropertyCollection As cPropertiesCollection)
            If Not PropertyCollection Is Me Then
                Call oItems.Clear()
                For Each oItem As KeyValuePair(Of String, Object) In PropertyCollection.oItems
                    Call oItems.Add(oItem.Key, oItem.Value)
                Next
            End If
        End Sub

        Public Sub Add(ByVal Name As String, ByVal Value As Object)
            If oItems.ContainsKey(Name) Then
                Call oItems.Remove(Name)
            End If
            If Not Value Is Nothing Then
                Call oItems.Add(Name, Value)
            End If
        End Sub

        Public Sub Clear()
            Call oItems.Clear()
        End Sub

        Public Sub Remove(ByVal Name As String)
            If oItems.ContainsKey(Name) Then
                Call oItems.Remove(Name)
            End If
        End Sub

        Default Public Property Item(ByVal Name As String) As Object
            Get
                If oItems.ContainsKey(Name) Then
                    Return oItems(Name)
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
            If oItems.ContainsKey(Name) Then
                Return oItems(Name)
            Else
                Dim oArgs As cgetparenteventargs = New cGetParentEventArgs
                RaiseEvent OnGetParent(Me, oArgs)
                If oArgs.Parent Is Nothing Then
                    Return DefaultValue
                Else
                    Return oArgs.Parent.GetValue(Name, DefaultValue)
                End If
            End If
        End Function

        Public Function HasValues() As Boolean
            Return oItems.Count > 0
        End Function

        Public Function HasValue(Name As String) As Boolean
            Return oItems.ContainsKey(Name)
        End Function

        Public Sub SetValue(ByVal Name As String, ByVal Value As Object)
            Call Add(Name, Value)
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Name As String, ByVal Parent As XmlElement) As XmlElement
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
                        oXmlPropertiesCollectionItem.InnerText = modNumbers.NumberToString(oValue, "")
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