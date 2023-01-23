Imports System.Runtime.CompilerServices
Imports System.Xml
Imports DevExpress.XtraCharts.Sankey
Imports DevExpress.XtraEditors

Module modXML

    Public Class cLocalizedStrings
        Private sCaption As String
        Private sTooltip As String

        Public ReadOnly Property Tooltip As String
            Get
                Return sTooltip
            End Get
        End Property

        Public ReadOnly Property Caption As String
            Get
                Return sCaption
            End Get
        End Property

        Public Sub New(Caption As String, Tooltip As String)
            sCaption = Caption
            sTooltip = Tooltip
        End Sub
    End Class

    Public Function GetLocalizedStrings(Node As XmlElement) As cLocalizedStrings
        Dim sCaption As String
        Dim sTooltip As String
        Dim oXmlCaption As XmlElement = Node.SelectSingleNode("caption[@lang='" & My.Application.CurrentLanguage & "']")
        If oXmlCaption Is Nothing Then
            oXmlCaption = Node.SelectSingleNode("caption[@lang='en']")
        End If
        If oXmlCaption Is Nothing Then
            sCaption = ""
            sTooltip = ""
        Else
            sCaption = GetAttributeValue(oXmlCaption, "caption", "")
            sTooltip = GetAttributeValue(oXmlCaption, "tooltip", "")
        End If
        Return New cLocalizedStrings(sCaption, sTooltip)
    End Function

    <Extension>
    Public Function IsEmptyRow(Sheet As OfficeOpenXml.ExcelWorksheet, r As Integer) As Boolean
        For c As Integer = Sheet.Dimension.Start.Column To Sheet.Dimension.End.Column
            If Not Sheet.Cells(r, c).Value Is Nothing OrElse Not String.IsNullOrEmpty(Sheet.Cells(r, c).Value) Then
                Return False
            End If
        Next
        Return True
    End Function
    Public Function RenameElement(Node As XmlElement, NewName As String) As XmlElement
        Dim oNewNode As XmlElement = Node.OwnerDocument.CreateElement(NewName)
        Do While Node.HasAttributes
            Call oNewNode.SetAttributeNode(Node.RemoveAttributeNode(Node.Attributes(0)))
        Loop
        Do While Node.HasChildNodes
            Call oNewNode.AppendChild(Node.FirstChild)
        Loop
        Try
            Call Node.ParentNode.ReplaceChild(oNewNode, Node)
            Return oNewNode
        Catch
            Return oNewNode
        End Try
    End Function

    Public Function ChildElementExist(Node As XmlElement, ChildName As String) As Boolean
        If Node Is Nothing Then
            Return False
        Else
            Return Not Node(ChildName) Is Nothing
        End If
    End Function

    Public Function HasAttribute(Node As XmlElement, Name As String) As Boolean
        Return Node.HasAttribute(Name)
    End Function

    Public Function GetAttributeValue(Node As XmlElement, Name As String, Optional DefaultValue As Object = Nothing) As Object
        If Node.HasAttribute(Name) Then
            Return Node.GetAttribute(Name)
        Else
            Return DefaultValue
        End If
    End Function

    Public Function GetAttributeColor(Node As XmlElement, Name As String, DefaultColor As Color) As Color
        If Node.HasAttribute(Name) Then
            Return Color.FromArgb(Node.GetAttribute(Name))
        Else
            Return DefaultColor
        End If
    End Function

    Public Function GetAttributeColors(Node As XmlElement, Name As String, DefaultColors As Color()) As Color()
        If Node.HasAttribute(Name) Then
            Return Node.GetAttribute(Name).Split(New [Char]() {";"}).Select(Function(item) Color.FromArgb(item)).ToArray
        Else
            Return DefaultColors
        End If
    End Function

End Module
