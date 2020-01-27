Imports System.Xml
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Scale
Imports cSurveyPC.cSurvey.Calculate

Namespace cSurvey
    Public Class cVisibilityItems
        Private oSurvey As cSurvey
        Private oItems As Dictionary(Of cItem, Boolean)

        Public Function Count() As Integer
            Return oItems.Count
        End Function

        Public Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oItems = New Dictionary(Of cItem, Boolean)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Items As XmlElement)
            oSurvey = Survey
            oItems = New Dictionary(Of cItem, Boolean)
            For Each oXmlItem As XmlElement In Items.ChildNodes
                Dim iDesignIndex As Integer = oXmlItem.GetAttribute("d")
                Dim iLayerIndex As Integer = oXmlItem.GetAttribute("l")
                Dim iItemIndex As Integer = oXmlItem.GetAttribute("i")
                Dim oItem As cItem = If(iDesignIndex = 0, oSurvey.Plan, oSurvey.Profile).layers(iLayerIndex).items(iItemIndex)
                If Not IsNothing(oItem) Then
                    Dim bVisible As Boolean = oXmlItem.GetAttribute("v")
                    Call oItems.Add(oItem, bVisible)
                End If
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlItems As XmlElement = Document.CreateElement("vis")
            For Each oItem As cItem In oItems.Keys
                Dim bVisible As Boolean = oItems(oItem)
                Dim oXMLItem As XmlElement = Document.CreateElement("vi")
                Call oXMLItem.SetAttribute("d", oItem.Design.Type.ToString("D"))
                Call oXMLItem.SetAttribute("l", oItem.Layer.Type.ToString("D"))
                Call oXMLItem.SetAttribute("i", oItem.Layer.Items.IndexOf(oItem))
                Call oXMLItem.SetAttribute("v", If(bVisible, "1", "0"))
                Call oXmlItems.AppendChild(oXMLItem)
            Next
            Call Parent.AppendChild(oXmlItems)
            Return oXmlItems
        End Function

        Public Enum VisibilityEnum
            [Default] = 0
            Visible = 1
            Hidden = 2
            Multiple = 3
        End Enum

        Public Function Contains(Item As cItem) As Boolean
            If Item.Type = Items.cIItem.cItemTypeEnum.Items Then
                Return False
            Else
                Return oItems.ContainsKey(Item)
            End If
        End Function

        Public Function IsVisible(Item As cItem, [Default] As Boolean) As Boolean
            If Item.Type = Items.cIItem.cItemTypeEnum.Items Then
                'is not usefull for items...
                Return [Default]
            Else
                If oItems.ContainsKey(Item) Then
                    Return oItems(Item)
                Else
                    Return [Default]
                End If
            End If
        End Function

        Public Function GetVisibility(Item As cItem) As VisibilityEnum
            If Item.Type = Items.cIItem.cItemTypeEnum.Items Then
                Dim iResult As VisibilityEnum = VisibilityEnum.Multiple
                Dim bFirst As Boolean = True
                For Each oSubitem As cItem In DirectCast(Item, Items.cItemItems)
                    If bFirst Then
                        iResult = GetVisibility(oSubitem)
                        bFirst = False
                    Else
                        If GetVisibility(oSubitem) <> iResult Then
                            Return VisibilityEnum.Multiple
                        End If
                    End If
                Next
                Return iResult
            Else
                If oItems.ContainsKey(Item) Then
                    If oItems(Item) Then
                        Return VisibilityEnum.Visible
                    Else
                        Return VisibilityEnum.Hidden
                    End If
                Else
                    Return VisibilityEnum.Default
                End If
            End If
        End Function

        Public Sub SetVisibility(Item As cItem, Visibility As VisibilityEnum)
            If Visibility <> VisibilityEnum.Multiple Then
                If Item.Type = Items.cIItem.cItemTypeEnum.Items Then
                    For Each oSubitem As cItem In DirectCast(Item, Items.cItemItems)
                        Call SetVisibility(oSubitem, Visibility)
                    Next
                Else
                    If oItems.ContainsKey(Item) Then oItems.Remove(Item)
                    Select Case Visibility
                        Case VisibilityEnum.Default
                        Case VisibilityEnum.Visible
                            Call oItems.Add(Item, True)
                        Case VisibilityEnum.Hidden
                            Call oItems.Add(Item, False)
                    End Select
                End If
            End If
        End Sub
    End Class
End Namespace

