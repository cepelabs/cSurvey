Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Xml

Namespace cSurvey
    Public Class cTexts
        Implements IEnumerable
        Implements IEnumerable(Of cText)

        Private oitems As cTextBaseCollection

        Private oSurvey As cSurvey

        Public Function GetUniqueName() As String
            Dim sPrefix As String = "text"
            Dim iIndex As Integer = 1
            Do
                Dim sNewName As String = sPrefix & iIndex
                If Not Contains(sNewName) Then
                    Return sNewName
                End If
                iIndex += 1
            Loop
        End Function

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oitems = New cTextBaseCollection
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Texts As XmlElement)
            oSurvey = Survey
            oitems = New cTextBaseCollection
            For Each oXMLText As XmlElement In Texts.ChildNodes
                Dim oText As cText = New cText(oSurvey, Me, oXMLText)
                Call oitems.Add(oText)
            Next
        End Sub

        Public Function Add(Name As String, Text As String) As cText
            If oitems.Contains(Name) Then
                Return Nothing
            Else
                Dim oItem As cText = New cText(oSurvey, Me, Name, Text)
                Call oitems.Add(oItem)
                Return oItem
            End If
        End Function

        Public Sub Clear()
            Call oitems.Clear()
        End Sub

        Public Sub Remove(Name As String)
            Call oitems.Remove(Name)
        End Sub

        Public Sub Remove(Index As Integer)
            Call oitems.Remove(Index)
        End Sub

        Public Function Count() As Integer
            Return oitems.Count
        End Function

        Public Function Contains(Item As cText) As Boolean
            Return oitems.Contains(Item.Name)
        End Function

        Public Function Contains(Name As String) As Boolean
            Return oitems.Contains(Name)
        End Function

        Public Sub MergeWith(Texts As cTexts)
            For Each oText As cText In Texts
                If Not oitems.Contains(oText.Name) Then
                    Call Add(oText.Name, oText.Text)
                End If
            Next
        End Sub

        Default Public ReadOnly Property Item(Name As String) As cText
            Get
                Return oitems(Name)
            End Get
        End Property

        Default Public ReadOnly Property Item(Index As Integer) As cText
            Get
                Return oitems(Index)
            End Get
        End Property

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlTexts As XmlElement = document.CreateElement("txts")
            For Each oItem As cText In oitems
                Call oItem.SaveTo(File, document, oXmlTexts)
            Next
            Call Parent.AppendChild(oXmlTexts)
            Return oXmlTexts
        End Function

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oitems.GetEnumerator
        End Function

        Public Function cText_GetEnumerator() As IEnumerator(Of cText) Implements IEnumerable(Of cText).GetEnumerator
            Return oitems.GetEnumerator
        End Function
    End Class

    Friend Class cTextBaseCollection
        Inherits KeyedCollection(Of String, cText)

        Public Sub New()
            Call MyBase.New(StringComparer.OrdinalIgnoreCase)
        End Sub

        Protected Overrides Function GetKeyForItem(ByVal item As cText) As String
            Return item.Name
        End Function
    End Class

    Public Class cText
        Private sName As String
        Private sText As String
        Private oParent As cTexts

        Private oSurvey As cSurvey

        Friend Sub New(ByVal Survey As cSurvey, Texts As cTexts, ByVal Text As XmlElement)
            oSurvey = Survey
            oParent = Texts
            sName = Text.GetAttribute("n")
            sText = modXML.GetAttributeValue(Text, "t", "")
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, Texts As cTexts, Name As String, Text As String)
            oSurvey = Survey
            oParent = Texts
            sName = Name
            sText = Text
        End Sub

        Public Property Name As String
            Get
                Return sName
            End Get
            Set(value As String)
                If oParent.Contains(value) Then
                    If oParent(value) Is Me Then
                        sName = value
                    End If
                Else
                    sName = value
                End If
            End Set
        End Property

        Public Property Text As String
            Get
                Return sText
            End Get
            Set(Value As String)
                sText = "" & Value
            End Set
        End Property

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlText As XmlElement = document.CreateElement("txt")
            Call oXmlText.SetAttribute("n", sName)
            If sText <> "" Then Call oXmlText.SetAttribute("t", sText)

            Call Parent.AppendChild(oXmlText)
            Return oXmlText
        End Function
    End Class
End Namespace

