Imports System
Imports System.Xml
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Imports cSurveyPC.cSurvey.Design.Items
Imports System.ComponentModel

Namespace cSurvey.Design
    Public Class cItems
        Implements IEnumerable(Of cItem)
        Private oSurvey As cSurvey
        Private oDesign As cDesign
        Private oLayer As cLayer

        Private oItems As BindingList(Of cItem)

        Friend ReadOnly Property List As BindingList(Of cItem)
            Get
                Return oItems
            End Get
        End Property

        Public ReadOnly Property First() As cItem
            Get
                If oItems.Count > 0 Then
                    Return oItems(0)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property Last() As cItem
            Get
                If oItems.Count > 0 Then
                    Return oItems(oItems.Count - 1)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Function [Next](Item As cItem) As cItem
            If Item Is oItems.Last Then
                Return Nothing
            Else
                Return oItems(oItems.IndexOf(Item) + 1)
            End If
        End Function

        Public Function [Previous](Item As cItem) As cItem
            If Item Is oItems.First Then
                Return Nothing
            Else
                Return oItems(oItems.IndexOf(Item) - 1)
            End If
        End Function

        Friend Sub Insert(ByVal Index As Integer, ByVal Item As cItem)
            Call Item.SetParent(oLayer)
            Call oItems.Insert(Index, Item)
        End Sub

        Friend Sub Add(ByVal Item As cItem)
            Call Item.SetParent(oLayer)
            Call oItems.Add(Item)
        End Sub

        Friend Sub AddRange(ByVal Items As IEnumerable(Of cItem))
            For Each oItem As cItem In Items
                Call oItem.SetParent(oLayer)
                Call oItems.Add(oItem)
            Next
        End Sub

        Friend ReadOnly Property Design As cDesign
            Get
                Return oDesign
            End Get
        End Property

        Friend ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public ReadOnly Property Layer As cLayer
            Get
                Return oLayer
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal Index As Integer) As cItem
            Get
                If Index >= 0 AndAlso Index < oItems.Count Then
                    Return oItems(Index)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Sub RemoveRange(Items As IEnumerable(Of cItem))
            For Each oItem As cItem In Items
                If oItems.Contains(oItem) Then
                    Call oItem.SetDeleted()
                    Call oItems.Remove(oItem)
                End If
            Next
        End Sub

        Public Sub Remove(ByVal Item As cItem)
            If Not Item Is Nothing Then
                If oItems.Contains(Item) Then
                    Call Item.SetDeleted()
                    Call oItems.Remove(Item)
                End If
            End If
        End Sub

        Public Sub Remove(ByVal Index As Integer)
            If Index >= 0 AndAlso Index < oItems.Count Then
                Dim oItem As cItem = oItems(Index)
                Call oItem.SetDeleted()
                Call oItems.RemoveAt(Index)
            End If
        End Sub

        Public ReadOnly Property Count() As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Public Function IndexOf(ByVal Item As cItem) As Integer
            Return oItems.IndexOf(Item)
        End Function

        Public Function GetByType(Type As cIItem.cItemTypeEnum) As List(Of cItem)
            Return oItems.Where(Function(item) item.Type = Type).ToList
        End Function

        Public Function Contains(ByVal Item As cItem) As Boolean
            If Item.Type = cIItem.cItemTypeEnum.Items Then
                Dim oItemItems As cItemItems = Item
                Dim bContains As Boolean = True
                For Each oSubItem As cItem In oItemItems
                    bContains = bContains AndAlso oItems.Contains(oSubItem)
                    If Not bContains Then Exit For
                Next
                Return bContains
            Else
                Return oItems.Contains(Item)
            End If
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer)
            oSurvey = Survey
            oDesign = Design
            oLayer = Layer
            oItems = New BindingList(Of cItem)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Items As List(Of cItem))
            oSurvey = Survey
            oDesign = Design
            oLayer = Layer
            oItems = New BindingList(Of cItem)(Items)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As cFile, ByVal Items As XmlElement)
            oSurvey = Survey
            oDesign = Design
            oLayer = Layer
            oItems = New BindingList(Of cItem)
            Dim iIndex As Integer = 0
            Dim iCount As Integer = Items.ChildNodes.Count
            Dim iStep As Integer = IIf(iCount > 20, iCount \ 20, 1)
            For Each oXMLItem As XmlElement In Items.ChildNodes
                iIndex += 1
                If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, String.Format(modMain.GetLocalizedString("items.textpart1"), If(oDesign.Type = cIDesign.cDesignTypeEnum.Plan, modMain.GetLocalizedString("items.textpart3"), modMain.GetLocalizedString("items.textpart4"))), iIndex / iCount)
                Dim oItem As cItem = Nothing
                Select Case oXMLItem.GetAttribute("type")
                    Case cIItem.cItemTypeEnum.Generic
                        oItem = New cItemGeneric(oSurvey, oDesign, oLayer, File, oXMLItem)
                    Case cIItem.cItemTypeEnum.FreeHandArea
                        oItem = New cItemFreeHandArea(oSurvey, oDesign, oLayer, File, oXMLItem)
                    Case cIItem.cItemTypeEnum.FreeHandLine
                        oItem = New cItemFreeHandLine(oSurvey, oDesign, oLayer, File, oXMLItem)
                    Case cIItem.cItemTypeEnum.InvertedFreeHandArea
                        oItem = New cItemInvertedFreeHandArea(oSurvey, oDesign, oLayer, File, oXMLItem)
                    Case cIItem.cItemTypeEnum.Sign
                        oItem = New cItemSign(oSurvey, oDesign, oLayer, File, oXMLItem)
                    Case cIItem.cItemTypeEnum.Clipart
                        oItem = New cItemClipart(oSurvey, oDesign, oLayer, File, oXMLItem)
                    Case cIItem.cItemTypeEnum.Compass
                        oItem = New cItemCompass(oSurvey, oDesign, oLayer, File, oXMLItem)
                    Case cIItem.cItemTypeEnum.Text
                        oItem = New cItemText(oSurvey, oDesign, oLayer, File, oXMLItem)
                    Case cIItem.cItemTypeEnum.Image
                        oItem = New cItemImage(oSurvey, oDesign, oLayer, File, oXMLItem)
                    Case cIItem.cItemTypeEnum.Attachment
                        oItem = New cItemAttachment(oSurvey, oDesign, oLayer, File, oXMLItem)
                        If DirectCast(oItem, cItemAttachment).Attachment Is Nothing Then
                            oItem = Nothing
                        End If
                    Case cIItem.cItemTypeEnum.CrossSection
                        oItem = New cItemCrossSection(oSurvey, oDesign, oLayer, File, oXMLItem)
                    Case cIItem.cItemTypeEnum.CrossSectionMarker
                        If TypeOf oDesign Is cDesignPlan Then
                            oItem = New cItemPlanCrossSectionMarker(oSurvey, oDesign, oLayer, File, oXMLItem)
                        Else
                            oItem = New cItemProfileCrossSectionMarker(oSurvey, oDesign, oLayer, File, oXMLItem)
                        End If
                    Case cIItem.cItemTypeEnum.Sketch
                        oItem = New cItemSketch(oSurvey, oDesign, oLayer, File, oXMLItem)
                    Case cIItem.cItemTypeEnum.Quota
                        oItem = New cItemQuota(oSurvey, oDesign, oLayer, File, oXMLItem)
                    Case cIItem.cItemTypeEnum.Legend
                        oItem = New cItemLegend(oSurvey, oDesign, oLayer, File, oXMLItem)
                    Case cIItem.cItemTypeEnum.InformationBoxText
                        oItem = New cItemInformationBoxText(oSurvey, oDesign, oLayer, File, oXMLItem)
                    Case cIItem.cItemTypeEnum.Scale
                        oItem = New cItemScale(oSurvey, oDesign, oLayer, File, oXMLItem)
                End Select
                If oItem Is Nothing Then
                    Stop
                Else
                    Call oItems.Add(oItem)
                End If
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXmlItems As XmlElement = Document.CreateElement("items")
            Dim iIndex As Integer = 0
            Dim iCount As Integer = oItems.Count
            Dim iStep As Integer = IIf(iCount > 20, iCount \ 20, 1)
            For Each oItem As cItem In oItems
                iIndex += 1
                If (Options AndAlso cSurvey.SaveOptionsEnum.Silent) = 0 Then If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("save", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, String.Format(modMain.GetLocalizedString("items.textpart2"), If(oDesign.Type = cIDesign.cDesignTypeEnum.Plan, modMain.GetLocalizedString("items.textpart3"), modMain.GetLocalizedString("items.textpart4"))), iIndex / iCount)
                Call oItem.SaveTo(File, Document, oXmlItems, Options)
            Next
            Call Parent.AppendChild(oXmlItems)
            Return oXmlItems
        End Function

        Public Function ToList() As List(Of cItem)
            Return oItems.ToList
        End Function

        Public Function ToArray() As cItem()
            Return oItems.ToArray
        End Function

        Public Sub SendToBottom(ByVal Item As cItem)
            If Contains(Item) Then
                If Item.Type = cIItem.cItemTypeEnum.Items Then
                    Dim oItemItems As cItemItems = Item
                    Dim iFirstIndex As Integer = oItems.IndexOf(oItemItems.First)
                    For Each oSubItem As cItem In oItemItems
                        Dim iIndex As Integer = oItems.IndexOf(oSubItem) - iFirstIndex
                        Call oItems.Remove(oSubItem)
                        Call oItems.Insert(iIndex, oSubItem)
                    Next
                Else
                    Call oItems.Remove(Item)
                    Call oItems.Insert(0, Item)
                End If
            End If
        End Sub

        Public Sub BringToTop(ByVal Item As cItem)
            If Contains(Item) Then
                If Item.Type = cIItem.cItemTypeEnum.Items Then
                    Dim oItemItems As cItemItems = Item
                    Dim iDelta As Integer = oItems.Count - oItems.IndexOf(oItemItems.Last) - 1
                    For Each oSubItem As cItem In oItemItems.ToArray.Reverse
                        Dim iIndex As Integer = oItems.IndexOf(oSubItem) + iDelta
                        Call oItems.Remove(oSubItem)
                        Call oItems.Insert(iIndex, oSubItem)
                    Next
                Else
                    Call oItems.Remove(Item)
                    Call oItems.Add(Item)
                End If
            End If
        End Sub

        Public Sub SendBehind(ByVal Item As cItem)
            If Contains(Item) Then
                If Item.Type = cIItem.cItemTypeEnum.Items Then
                    Dim iIndex As Integer = 0
                    For Each oSubItem As cItem In DirectCast(Item, cItemItems)
                        Dim iSubIndex As Integer = oItems.IndexOf(oSubItem)
                        If iSubIndex > 0 Then
                            Call oItems.Remove(oSubItem)
                            Call oItems.Insert(iSubIndex - 1, oSubItem)
                        Else
                            Exit For
                        End If
                    Next
                Else
                    Dim iIndex As Integer = oItems.IndexOf(Item)
                    If iIndex > 0 Then
                        Call oItems.Remove(Item)
                        Call oItems.Insert(iIndex - 1, Item)
                    End If
                End If
            End If
        End Sub

        Public Sub BringAhead(ByVal Item As cItem)
            If Contains(Item) Then
                If Item.Type = cIItem.cItemTypeEnum.Items Then
                    For Each oSubItem As cItem In DirectCast(Item, cItemItems).ToArray.Reverse
                        Dim iSubIndex As Integer = oItems.IndexOf(oSubItem)
                        If iSubIndex < oItems.Count - 1 Then
                            Call oItems.Remove(oSubItem)
                            Call oItems.Insert(iSubIndex + 1, oSubItem)
                        Else
                            Exit For
                        End If
                    Next
                Else
                    Dim iIndex As Integer = oItems.IndexOf(Item)
                    If iIndex < oItems.Count - 1 Then
                        Call oItems.Remove(Item)
                        Call oItems.Insert(iIndex + 1, Item)
                    End If
                End If
            End If
        End Sub

        Public Sub MoveTo(ByVal Index As Integer, ByVal Item As cItem)
            If oItems.Contains(Item) Then
                Dim iIndex As Integer = oItems.IndexOf(Item)
                If Index <> iIndex AndAlso Index >= 0 AndAlso Index < oItems.Count Then
                    Call oItems.Remove(Item)
                    Call oItems.Insert(Index, Item)
                End If
            End If
        End Sub

        Public Sub Clear()
            Call oItems.Clear()
        End Sub

        Public Function DivideOneSequence(ByVal SourceItem As cItem, Point As cPoint, DeleteSequence As Boolean) As cItem
            If oItems.Contains(SourceItem) Then
                If SourceItem.CanBeDivided Then
                    Dim bFirst As Boolean = True
                    Dim oDestItem As cItem = Nothing
                    For Each oSequence As cSequence In SourceItem.Points.GetSequences
                        If oSequence.Contains(Point) Then
                            Select Case SourceItem.Type
                                Case cIItem.cItemTypeEnum.Generic
                                    oDestItem = New cItemGeneric(oSurvey, oDesign, oLayer, SourceItem.Category)
                                Case cIItem.cItemTypeEnum.FreeHandArea
                                    oDestItem = New cItemFreeHandArea(oSurvey, oDesign, oLayer, SourceItem.Category)
                                Case cIItem.cItemTypeEnum.FreeHandLine
                                    oDestItem = New cItemFreeHandLine(oSurvey, oDesign, oLayer, SourceItem.Category)
                                Case cIItem.cItemTypeEnum.InvertedFreeHandArea
                                    oDestItem = New cItemInvertedFreeHandArea(oSurvey, oDesign, oLayer, SourceItem.Category)
                            End Select
                            Call oDestItem.SetCave(SourceItem.Cave, SourceItem.Branch, False)
                            If oDestItem.HaveBrush AndAlso SourceItem.HaveBrush Then Call oDestItem.Brush.CopyFrom(SourceItem.Brush)
                            If oDestItem.HavePen AndAlso SourceItem.HavePen Then oDestItem.Pen.CopyFrom(SourceItem.Pen)
                            'cerco di riportare altre proprietà non comuni a tutti gli oggetti.......
                            If oDestItem.HaveLineType AndAlso SourceItem.HaveLineType Then DirectCast(oDestItem, cIItemLine).LineType = DirectCast(SourceItem, cIItemLine).LineType
                            For Each oPoint As cPoint In oSequence
                                Call oDestItem.Points.Add(oPoint.Clone)
                            Next
                            Call oItems.Add(oDestItem)
                            If DeleteSequence Then
                                Call SourceItem.Points.DeleteSequence(Point)
                            End If
                            Return oDestItem
                        End If
                    Next
                End If
            End If
        End Function

        Public Sub Divide(ByVal SourceItem As cItem)
            If oItems.Contains(SourceItem) Then
                If SourceItem.CanBeDivided Then
                    Dim bFirst As Boolean = True
                    Dim oDestItem As cItem = Nothing
                    For Each opoint As cPoint In SourceItem.Points
                        If bFirst OrElse opoint.BeginSequence Then
                            bFirst = False
                            If Not oDestItem Is Nothing Then
                                Call oItems.Add(oDestItem)
                            End If
                            Select Case SourceItem.Type
                                Case cIItem.cItemTypeEnum.Generic
                                    oDestItem = New cItemGeneric(oSurvey, oDesign, oLayer, SourceItem.Category)
                                Case cIItem.cItemTypeEnum.FreeHandArea
                                    oDestItem = New cItemFreeHandArea(oSurvey, oDesign, oLayer, SourceItem.Category)
                                Case cIItem.cItemTypeEnum.FreeHandLine
                                    oDestItem = New cItemFreeHandLine(oSurvey, oDesign, oLayer, SourceItem.Category)
                                Case cIItem.cItemTypeEnum.InvertedFreeHandArea
                                    oDestItem = New cItemInvertedFreeHandArea(oSurvey, oDesign, oLayer, SourceItem.Category)
                            End Select
                            Call oDestItem.SetCave(SourceItem.Cave, SourceItem.Branch, False)
                            If oDestItem.HaveBrush AndAlso SourceItem.HaveBrush Then Call oDestItem.Brush.CopyFrom(SourceItem.Brush)
                            If oDestItem.HavePen AndAlso SourceItem.HavePen Then oDestItem.Pen.CopyFrom(SourceItem.Pen)
                            'cerco di riportare altre proprietà non comuni a tutti gli oggetti.......
                            If oDestItem.HaveLineType AndAlso SourceItem.HaveLineType Then DirectCast(oDestItem, cIItemLine).LineType = DirectCast(SourceItem, cIItemLine).LineType
                            'e i dati utente
                            Call oDestItem.DataProperties.CopyFrom(SourceItem.DataProperties)
                        End If
                        If Not oDestItem Is Nothing Then
                            Call oDestItem.Points.Add(opoint)
                        End If
                    Next
                    Call oItems.Add(oDestItem)
                    Call Remove(SourceItem)
                End If
            End If
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        Private Function cItem_GetEnumerator() As IEnumerator(Of cItem) Implements IEnumerable(Of cItem).GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace