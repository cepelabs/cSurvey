Imports System.Runtime.CompilerServices
Imports System.Xml

Module modXML

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
