Imports System.Xml

Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Editor
    Friend Class cFilter
        Private oSurvey As cSurvey

        Private sName As String
        Private iCategory As cIItem.cItemCategoryEnum?
        Private oDataProperties As Data.cDataProperties

        Private sCave As String
        Private sBranch As String

        Private bReversed As Boolean

        Friend Function Apply(Item As cItem) As Boolean
            Dim bOk As Boolean = True
            If "" & sName <> "" Then
                bOk = bOk And Item.Name Like sName
            End If
            If iCategory.HasValue Then
                bOk = bOk And Item.Category = iCategory.Value
            End If
            If sCave <> "" Then
                bOk = bOk And Item.Cave.ToLower = sCave.ToLower
            End If
            If sBranch <> "" Then
                bOk = bOk And Item.Branch.ToLower = sBranch.ToLower
            End If
            For Each oField As Data.cDataField In oDataProperties.Fields
                Dim oValue As Object = oDataProperties.GetValue(oField.Name, Nothing)
                If Not oValue Is Nothing Then
                    If oField.Type = Data.cDataFields.TypeEnum.Text Then
                        Dim sItemValue As String = Item.DataProperties.GetValue(oField.Name, Nothing)
                        Dim sValue As String = oValue.ToString
                        bOk = bOk And sItemValue Like sValue
                    Else
                        Dim oItemValue As Object = Item.DataProperties.GetValue(oField.Name, Nothing)
                        bOk = bOk And oItemValue = oValue
                    End If
                End If
            Next
            If bReversed Then bOk = Not bOk
            Return bOk
        End Function

        Public Property Reversed As Boolean
            Get
                Return bReversed
            End Get
            Set(value As Boolean)
                bReversed = value
            End Set
        End Property

        Public Property Name As String
            Get
                Return sName
            End Get
            Set(value As String)
                sName = value
            End Set
        End Property

        Public Property Cave As String
            Get
                Return sCave
            End Get
            Set(value As String)
                sCave = value
            End Set
        End Property

        Public Property Branch As String
            Get
                Return sBranch
            End Get
            Set(value As String)
                sBranch = value
            End Set
        End Property

        Public Property Category As cIItem.cItemCategoryEnum?
            Get
                Return iCategory
            End Get
            Set(value As cIItem.cItemCategoryEnum?)
                iCategory = value
            End Set
        End Property

        Public ReadOnly Property DataProperties As Data.cDataProperties
            Get
                Return oDataProperties
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            sName = ""
            sCave = ""
            sBranch = ""
            oDataProperties = New Data.cDataProperties(oSurvey, oSurvey.Properties.DataTables.DesignItems)
        End Sub

        Public Function Clone() As cFilter
            Dim oFilter As cFilter = New cFilter(oSurvey)
            'oFilter.FilterType = iType
            oFilter.sName = sName
            oFilter.iCategory = iCategory
            oFilter.sCave = sCave
            oFilter.sBranch = sBranch
            oFilter.bReversed = bReversed
            Call oFilter.DataProperties.CopyFrom(oDataProperties)
            Return oFilter
        End Function

        Public Sub CopyFrom(Filter As cFilter)
            'iType = Filter.iType
            sName = Filter.sName
            iCategory = Filter.iCategory
            sCave = Filter.sCave
            sBranch = Filter.sBranch
            Call oDataProperties.CopyFrom(Filter.oDataProperties)
            bReversed = Filter.bReversed
        End Sub
    End Class

    Friend Class cEdit2DTools
        Inherits cEditTools
        Public LastPoint As PointF
        Public CurrentPoint As PointF
        Public LastCenterPoint As PointF
        Public LastBounds As RectangleF
        Public LastAngle As Single
        Public LastAnchor As AnchorRectangleTypeEnum

        Private bIsNewItem As Boolean
        Private bStarted As Boolean

        Private bIsInPointEdit As Boolean
        Private bIsNewPoint As Boolean
        Private oNewPointRelative As cPoint
        Private bIsInEdit As Boolean
        Private bIsInCombine As Boolean

        Private oCurrentLayer As cLayer
        Private oCurrentItem As cItem
        Private oCurrentItemPoint As cPoint

        Private sCurrentCave As String = ""
        Private sCurrentBranch As String = ""
        Private iCurrentBindDesignType As cItem.BindDesignTypeEnum

        Private WithEvents oCurrentMarkedDesktopPoint As cMarkedDesktopPoint

        Private oFilter As cFilter
        Private bIsFiltered As Boolean

        Friend Event OnFilterApplied(ByVal Sender As Object, ByVal ToolEventArgs As EventArgs)
        Friend Event OnFilterRemoved(ByVal Sender As Object, ByVal ToolEventArgs As EventArgs)

        Public Sub FilterApply() Implements cIEditTools.FilterApply
            bIsFiltered = True
            RaiseEvent OnFilterApplied(Me, New EventArgs)
        End Sub

        Public Sub FilterRemove() Implements cIEditTools.FilterRemove
            bIsFiltered = False
            RaiseEvent OnFilterRemoved(Me, New EventArgs)
        End Sub

        Public Sub FilterToggle() Implements cIEditTools.FilterToggle
            If bIsFiltered Then
                Call FilterRemove()
            Else
                Call FilterApply()
            End If
        End Sub

        Public ReadOnly Property IsFiltered As Boolean Implements cIEditTools.IsFiltered
            Get
                Return bIsFiltered
            End Get
        End Property

        Public ReadOnly Property Filter As cFilter Implements cIEditTools.Filter
            Get
                Return oFilter
            End Get
        End Property

        Public ReadOnly Property CurrentMarkedDesktopPoint() As cMarkedDesktopPoint
            Get
                Return oCurrentMarkedDesktopPoint
            End Get
        End Property

        Public ReadOnly Property IsNewItem() As Boolean
            Get
                Return bIsNewItem
            End Get
        End Property

        Friend Event OnItemSelect(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs)
        Friend Event OnItemCombine(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs)
        Friend Event OnItemEdit(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs)
        Friend Event OnItemDelete(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs)
        Friend Event OnItemPointDelete(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs)
        Friend Event OnItemPointEdit(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs)
        Friend Event OnItemPointEnd(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs)
        Friend Event OnItemEnd(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs)
        Friend Event OnLayerSelect(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs)

        Friend Event OnCaveBranchSelect(ByVal Sender As Object, ByVal ToolEventArgs As cCaveBranchSelectEventArgs)

        Private Function pCreateEventArgs() As cEditToolsEventArgs
            Return New cEditToolsEventArgs(oCurrentLayer, oCurrentItem, oCurrentItemPoint, bIsNewItem)
        End Function

        Public Sub SelectLayer(ByVal Layer As cILayer) Implements cIEditTools.SelectLayer
            If Not Layer Is oCurrentLayer Then
                Call [EndItem]()
                oCurrentLayer = Layer
                RaiseEvent OnLayerSelect(Me, pCreateEventArgs)
            End If
        End Sub

        Public Sub Refresh() Implements cIEditTools.Refresh
            If Not oCurrentItem Is Nothing Then
                LastCenterPoint = oCurrentItem.GetCenterPoint
                LastBounds = oCurrentItem.GetBounds
            End If
        End Sub

        Public Sub [SelectItem](ByVal Item As cIItem) Implements cIEditTools.SelectItem
            If oCurrentItem Is Item Then
                If Not oCurrentItem Is Nothing Then
                    If oCurrentItem.HaveEditablePoints Then
                        bIsInPointEdit = Not bIsInPointEdit
                    Else
                        bIsInPointEdit = False
                    End If
                Else
                    bIsInPointEdit = False
                End If
            Else
                Call [EndItem]()
                bIsInPointEdit = False
                If Not Item Is Nothing AndAlso Not oCurrentLayer Is Item.Layer AndAlso Not Item.Layer Is Nothing Then
                    oCurrentLayer = Item.Layer
                    RaiseEvent OnLayerSelect(Me, pCreateEventArgs)
                End If
                oCurrentItem = Item
            End If

            Call Refresh()
            bIsInEdit = False
            bIsInCombine = False
            bIsNewItem = False
            bStarted = False
            RaiseEvent OnItemSelect(Me, pCreateEventArgs)
            If Not oCurrentItem Is Nothing Then
                Call oSurvey.Undo.Push("Modifica oggetto", cUndo.ActionEnum.Update, oCurrentLayer, oCurrentItem, oCurrentLayer.Items.IndexOf(oCurrentItem))
            End If
        End Sub

        Public Sub SelectBindDesignType(ByVal BindDesignType As cItem.BindDesignTypeEnum)
            If iCurrentBindDesignType <> BindDesignType Then
                iCurrentBindDesignType = BindDesignType
            End If
        End Sub

        Public Overrides Sub EditItem(ByVal Item As cIItem, Optional ByVal IsNewItem As Boolean = False)
            Call [EndItem]()
            oCurrentItem = Item
            If Not oCurrentLayer Is Item.Layer And Not Item.Layer Is Nothing Then
                oCurrentLayer = Item.Layer
                RaiseEvent OnLayerSelect(Me, pCreateEventArgs)
            End If
            oCurrentItemPoint = Nothing
            bIsInEdit = True
            bIsInCombine = False
            If IsNewItem Then
                bIsNewItem = True
                bStarted = False
            Else
                bIsNewItem = False
                bStarted = False
                Call oSurvey.Undo.Push("Modifica oggetto", cUndo.ActionEnum.Update, oCurrentLayer, oCurrentItem, oCurrentLayer.Items.IndexOf(oCurrentItem))
            End If
            RaiseEvent OnItemEdit(Me, pCreateEventArgs)
        End Sub

        Public Sub CombineItem(ByVal Item As cIItem)
            Call [EndItem]()
            oCurrentItem = Item
            oCurrentItemPoint = Nothing
            'bIsInEdit = False
            bIsInCombine = True
            'bIsNewItem = False
            'bStarted = False
            RaiseEvent OnItemCombine(Me, pCreateEventArgs)
        End Sub

        Public Overrides Sub EndAndSelectItem()
            Dim oItem As cItem = oCurrentItem
            Call EndItem()
            If Not oItem Is Nothing Then
                If Not oItem.Deleted Then
                    Call SelectItem(oItem)
                    Call oSurvey.Undo.Push("Modifica oggetto", cUndo.ActionEnum.Update, oCurrentLayer, oCurrentItem, oCurrentLayer.Items.IndexOf(oCurrentItem))
                End If
            End If
        End Sub

        Private Function pItemFromStorage(XML As XmlDocument, Design As cDesign, PerformSelectItem As Boolean, Optional PerformEditItem As Boolean = True) As cItem
            Dim oPastedItem As cItem = Nothing
            Dim oXMLItem As XmlElement = XML.Item("parent").FirstChild
            Dim iType As cIItem.cItemTypeEnum = oXMLItem.GetAttribute("type")
            If iType = cIItem.cItemTypeEnum.Items Then
                Dim oItems As Items.cItemItems = New Items.cItemItems(oSurvey, oCurrentLayer.Design, oCurrentLayer, cIItem.cItemCategoryEnum.None)
                For Each oXmlSubItem As XmlElement In oXMLItem.Item("items")
                    Try
                        Dim iLayerType As cLayers.LayerTypeEnum = oXmlSubItem.GetAttribute("layer")
                        Dim oFile As Storage.cFile = New Storage.cFile(Storage.cFile.FileFormatEnum.CSX)
                        Dim oItem As cItem = DirectCast(Design.Layers(iLayerType), cLayer).CreateItem(oFile, oXmlSubItem)
                        If PerformEditItem Then Call EditItem(oItem, True)  'simulo un edit cosi da scatenare l'undo e tutto il resto...
                        Call oItems.Add(oItem)
                        Call EndItem()
                    Catch ex As Exception
                        Call oSurvey.RaiseOnLogEvent("pasteitem.error", ex.Message, False)
                    End Try
                Next
                oPastedItem = oItems
                If PerformSelectItem Then
                    oCurrentItem = Nothing
                    Call SelectItem(oItems)
                End If
            Else
                Dim iLayerType As cLayers.LayerTypeEnum = oXMLItem.GetAttribute("layer")
                Dim oFile As Storage.cFile = New Storage.cFile(Storage.cFile.FileFormatEnum.CSX)
                Dim oItem As cItem = DirectCast(Design.Layers(iLayerType), cLayer).CreateItem(oFile, oXMLItem)
                If PerformEditItem Then Call EditItem(oItem, True)
                Call EndItem()
                oPastedItem = oItem
                If PerformSelectItem Then
                    oCurrentItem = Nothing
                    Call SelectItem(oItem)
                End If
            End If
            Return oPastedItem
        End Function

        Public Enum PasteSpecialEnum
            None = 0
            Pen = 1
            Brush = 2
        End Enum

        Public Function PasteItem(Optional ByVal Format As String = "", Optional ByVal Location As PointF = Nothing, Optional Special As PasteSpecialEnum = PasteSpecialEnum.None) As cItem
            Dim oPastedItem As cItem = Nothing
            Try
                If Format = "" Then
                    If Clipboard.ContainsData("csurvey.item") Then
                        Dim oXML As XmlDocument = New XmlDocument
                        Call oXML.LoadXml(Clipboard.GetText)
                        If Special And PasteSpecialEnum.Pen Then
                            Dim oLastItem As cItem = oCurrentItem
                            oPastedItem = pItemFromStorage(oXML, oCurrentLayer.Design, False, False)
                            Call oCurrentItem.Pen.CopyFrom(oPastedItem.Pen)
                            Call oPastedItem.Layer.Items.Remove(oPastedItem)
                            oPastedItem = oLastItem
                        ElseIf Special And PasteSpecialEnum.Brush Then
                            Dim oLastItem As cItem = oCurrentItem
                            oPastedItem = pItemFromStorage(oXML, oCurrentLayer.Design, False, False)
                            Call oLastItem.Brush.CopyFrom(oPastedItem.Brush)
                            Call oPastedItem.Layer.Items.Remove(oPastedItem)
                            oPastedItem = oLastItem
                            Call SelectItem(oPastedItem)
                        Else
                            oPastedItem = pItemFromStorage(oXML, oCurrentLayer.Design, True)
                            If Not Location.IsEmpty Then Call oPastedItem.MoveTo(Location)
                            Call oPastedItem.SetCave(sCurrentCave, sCurrentBranch)
                            Call SelectItem(oPastedItem)
                        End If
                    ElseIf Clipboard.ContainsData("image/svg+xml") Then
                        'si tratta di svg...
                        'tento la creazione di un oggetto GENERIC...
                        Dim sData As String = modSVG.GetSVGDataFromClipboard
                        Dim oItem As Items.cItemGeneric = oCurrentLayer.CreateGeneric(sCurrentCave, sCurrentBranch, sData, Items.cItemGeneric.cItemGenericDataFormatEnum.SVGData)
                        Call oItem.MoveTo(Location)
                        Call EditItem(oItem, True)  'simulo un edit cosi da scatenare l'undo e tutto il resto...
                        Call EndItem()
                        oPastedItem = oItem
                        Call SelectItem(oPastedItem)
                    ElseIf Clipboard.ContainsText Then
                        Dim oLayer As Layers.cLayerSigns = oCurrentLayer.Design.Layers(cLayers.LayerTypeEnum.Signs)
                        Call SelectLayer(oLayer)
                        Dim sText As String = Clipboard.GetText
                        sText = sText.Trim
                        If sText <> "" Then
                            Dim oItem As Items.cItemText = oLayer.CreateText(sCurrentCave, sCurrentBranch, sText)
                            Call oItem.FixBound(True)
                            Call oItem.MoveTo(Location)
                            Call EditItem(oItem, True)  'simulo un edit cosi da scatenare l'undo e tutto il resto...
                            Call EndItem()
                            oPastedItem = oItem
                            Call SelectItem(oPastedItem)
                        End If
                    End If
                Else
                    Select Case Format
                        Case "rock", "concretion"
                            If Clipboard.ContainsData("image/svg+xml") Then
                                'si tratta di svg importato...
                                'tento la creazione di un oggetto GENERIC...
                                Dim sData As String = modSVG.GetSVGDataFromClipboard

                                Dim oLayerRocks As Layers.cLayerRocks = oCurrentLayer.Design.Layers(cLayers.LayerTypeEnum.RocksAndConcretion)
                                Call SelectLayer(oLayerRocks)
                                Dim oItem As Items.cItemClipart = oLayerRocks.CreateRockFromClipart(sCurrentCave, sCurrentBranch, sData, Items.cItemClipart.cItemClipartDataFormatEnum.SVGData)
                                Call oItem.FixBound(True)
                                Call oItem.MoveTo(Location)
                                Call EditItem(oItem, True)  'simulo un edit cosi da scatenare l'undo e tutto il resto...
                                Call EndItem()
                                oPastedItem = oItem
                                Call SelectItem(oItem)
                            End If
                        Case "text"
                            If Clipboard.ContainsText Then
                                Dim oLayerSigns As Layers.cLayerSigns = oCurrentLayer.Design.Layers(cLayers.LayerTypeEnum.Signs)
                                Call SelectLayer(oLayerSigns)
                                Dim sText As String = Clipboard.GetText.Trim
                                If sText <> "" Then
                                    Dim oItem As Items.cItemText = oLayerSigns.CreateText(sCurrentCave, sCurrentBranch, sText)
                                    Call oItem.FixBound(True)
                                    Call oItem.MoveTo(Location)
                                    Call EditItem(oItem, True)  'simulo un edit cosi da scatenare l'undo e tutto il resto...
                                    Call EndItem()
                                    oPastedItem = oItem
                                    Call SelectItem(oItem)
                                End If
                            End If
                        Case "generic"
                            If Clipboard.ContainsData("image/svg+xml") Then
                                'si tratta di svg importato...
                                'tento la creazione di un oggetto GENERIC...
                                Dim oOptions As Items.cItemGeneric.cItemGenericOptions = New Items.cItemGeneric.cItemGenericOptions(oSurvey)
                                Dim sData As String = modSVG.GetSVGDataFromClipboard
                                Dim oClipart As cDrawClipArt = New cDrawClipArt(sData)
                                Dim oItem As Items.cItemGeneric = oCurrentLayer.CreateGeneric(sCurrentCave, sCurrentBranch, oClipart, oOptions)
                                Call oItem.MoveTo(Location)
                                Call EditItem(oItem, True)  'simulo un edit cosi da scatenare l'undo e tutto il resto...
                                Call EndItem()
                                oPastedItem = oItem
                                Call SelectItem(oItem)
                            End If
                    End Select
                End If
            Catch
            End Try
            Return oPastedItem
        End Function

        Private Function pItemToStorage() As XmlDocument
            Dim oFile As Storage.cFile = New Storage.cFile(Storage.cFile.FileFormatEnum.CSX, Storage.cFile.FileOptionsEnum.EmbedClipartResource)
            Dim oXML As XmlDocument = oFile.Document
            Dim oXMLParent As XmlElement = oXML.CreateElement("parent")
            Call oCurrentItem.SaveTo(oFile, oXML, oXMLParent, cSurvey.SaveOptionsEnum.Silent)
            Call oXML.AppendChild(oXMLParent)
            Return oXML
        End Function

        Public Function CloneItem(Design As cDesign) As cItem
            Dim oXMl As XmlDocument = pItemToStorage()
            Return pItemFromStorage(oXMl, Design, False)
        End Function

        Public Sub CopyItem()
            Dim oXMl As XmlDocument = pItemToStorage()

            Dim oDataObject As DataObject = New DataObject
            Call oDataObject.SetText(oXMl.InnerXml)
            Call oDataObject.SetData("csurvey.item", oXMl.InnerXml)

            Dim sExtFormats As String = oSurvey.GetGlobalSetting("clipboard.designitems.extformats", "")
            If sExtFormats.Contains("xml") Then
                Dim oXMLMS As IO.MemoryStream = New IO.MemoryStream
                Call oXMl.Save(oXMLMS)
                Call oDataObject.SetData("xml", oXMLMS)
            End If
            If sExtFormats.Contains("svg") Then
                Dim oSVGMS As IO.MemoryStream = New IO.MemoryStream
                Call oCurrentItem.ToSvg(oSurvey.Options("_design.plan"), cItem.SVGOptionsEnum.None).Save(oSVGMS)
                Call oDataObject.SetData("image/svg+xml", oSVGMS)
            End If
            Call Clipboard.SetDataObject(oDataObject)
        End Sub

        Public Sub CutItem()
            'Dim oFile As Storage.cFile = New Storage.cFile
            'Dim oXML As XmlDocument = oFile.Document
            'Dim oXMLParent As XmlElement = oXML.CreateElement("parent")
            'Call oCurrentItem.SaveTo(oFile, oXML, oXMLParent)
            'Call oXML.AppendChild(oXMLParent)
            Dim oXMl As XmlDocument = pItemToStorage()

            Dim oDataObject As DataObject = New DataObject
            Call oDataObject.SetText(oXMl.InnerXml)
            Call oDataObject.SetData("csurvey.item", oXMl.InnerXml)
            Dim sExtFormats As String = oSurvey.GetGlobalSetting("clipboard.designitems.extformats", "")

            If sExtFormats.Contains("xml") Then
                Dim oXMLMS As IO.MemoryStream = New IO.MemoryStream
                Call oXMl.Save(oXMLMS)
                Call oDataObject.SetData("xml", oXMLMS)
            End If
            If sExtFormats.Contains("svg") Then
                Dim oSVGMS As IO.MemoryStream = New IO.MemoryStream
                Call oCurrentItem.ToSvg(oSurvey.Options("_design.plan"), cItem.SVGOptionsEnum.None).Save(oSVGMS)
                Call oDataObject.SetData("image/svg+xml", oSVGMS)
            End If
            Call Clipboard.SetDataObject(oDataObject)

            Call DeleteItem()
        End Sub

        Public Sub DeleteItemPoint()
            If oCurrentItem IsNot Nothing Then
                If oCurrentItem.Points.Count > 1 Then
                    Call oSurvey.Undo.Push("Modifica oggetto", cUndo.ActionEnum.Update, oCurrentLayer, oCurrentItem, oCurrentLayer.Items.IndexOf(oCurrentItem))
                    Dim iPointIndex As Integer = oCurrentItem.Points.IndexOf(oCurrentItemPoint)
                    If oCurrentItem.Points.Remove(oCurrentItemPoint) Then
                        RaiseEvent OnItemPointDelete(Me, pCreateEventArgs)
                        Dim iCount As Integer = oCurrentItem.Points.Count
                        If iCount > 0 Then
                            If iPointIndex >= iCount Then
                                Call EditPoint(oCurrentItem.Points(iCount - 1))
                            Else
                                Call EditPoint(oCurrentItem.Points(iPointIndex))
                            End If
                        Else
                            Call DeleteItem()
                        End If
                    End If
                Else
                    Call DeleteItem()
                End If
            End If
        End Sub

        Public Sub DeleteItem() Implements cIEditTools.DeleteItem
            If oCurrentItem IsNot Nothing Then
                If oCurrentItem.Type = cIItem.cItemTypeEnum.Items Then
                    Call oSurvey.Undo.Push("Elimina oggetti", cUndo.ActionEnum.Delete, oCurrentLayer, oCurrentItem, oCurrentLayer.Items.IndexOf(oCurrentItem))
                    Call oCurrentLayer.Items.Remove(oCurrentItem)
                    Dim oItems As cSurveyPC.cSurvey.Design.Items.cItemItems = oCurrentItem
                    For Each oItem As cItem In oItems
                        Call DirectCast(oCurrentLayer.Design, cDesign).RemoveItem(oItem)
                    Next
                Else
                    Call oSurvey.Undo.Push("Elimina oggetto", cUndo.ActionEnum.Delete, oCurrentLayer, oCurrentItem, oCurrentLayer.Items.IndexOf(oCurrentItem))
                    Call oCurrentLayer.Items.Remove(oCurrentItem)
                End If
                RaiseEvent OnItemDelete(Me, pCreateEventArgs)
                oCurrentItem = Nothing
                Call EndItem()
                Call SelectItem(Nothing)
            End If
        End Sub

        Public Sub TakeUndoSnapshot()
            If oCurrentItem IsNot Nothing And oCurrentLayer IsNot Nothing Then
                If oCurrentItem.Type = cIItem.cItemTypeEnum.Items Then
                    'DA FARE....BOH!
                Else
                    Call oSurvey.Undo.Push("Modifica oggetto", cUndo.ActionEnum.Update, oCurrentLayer, oCurrentItem, oCurrentLayer.Items.IndexOf(oCurrentItem))
                End If
            End If
        End Sub

        Public Sub [EndItem]() Implements cIEditTools.EndItem
            Dim bRaiseEvent As Boolean
            If Not oCurrentItem Is Nothing Then
                Call oCurrentItem.Points.CleanUp()
                Call oCurrentItem.BindSegments()
                bRaiseEvent = True
            End If
            bIsInEdit = False
            bIsInCombine = False
            bIsInPointEdit = False
            bStarted = False
            If bRaiseEvent Then
                RaiseEvent OnItemEnd(Me, pCreateEventArgs)
                If Not oCurrentItem Is Nothing Then
                    If bIsNewItem Then
                        Call oSurvey.Undo.Push("Aggiunta oggetto", cUndo.ActionEnum.Insert, oCurrentLayer, oCurrentItem, oCurrentLayer.Items.IndexOf(oCurrentItem))
                    End If
                End If
            End If
            bIsNewItem = False
            oCurrentItem = Nothing
            oCurrentItemPoint = Nothing
        End Sub

        Public Sub EndPoint() Implements cIEditTools.EndPoint
            If Not oCurrentItem Is Nothing Then
                If Not oCurrentItemPoint Is Nothing Then
                    RaiseEvent OnItemPointEnd(Me, pCreateEventArgs)
                    oCurrentItemPoint = Nothing
                End If
            End If
        End Sub

        Public Sub SelectPoint(ByVal Point As cPoint, Optional IsNewPoint As Boolean = False, Optional NewPointRelative As cPoint = Nothing) Implements cIEditTools.SelectPoint
            Call EditPoint(Point, IsNewPoint, NewPointRelative)
        End Sub

        Public Sub EditPoint(ByVal Point As cPoint, Optional IsNewPoint As Boolean = False, Optional NewPointRelative As cPoint = Nothing) Implements cIEditTools.EditPoint
            If Not oCurrentItem Is Nothing Then
                If Not oCurrentItemPoint Is Point Then
                    bIsNewPoint = IsNewPoint
                    If bIsNewPoint Then
                        oNewPointRelative = NewPointRelative
                    End If
                    oCurrentItemPoint = Point
                    RaiseEvent OnItemPointEdit(Me, pCreateEventArgs)
                End If
            End If
        End Sub

        Public ReadOnly Property CurrentNewPointRelative As cPoint Implements cIEditTools.CurrentNewPointRelative
            Get
                Return oNewPointRelative
            End Get
        End Property

        Public Sub StartEditItem()
            If bIsNewItem Then
                bStarted = True
            End If
        End Sub

        Public ReadOnly Property Started As Boolean
            Get
                Return bStarted
            End Get
        End Property

        Public ReadOnly Property IsInEdit() As Boolean Implements cIEditTools.IsInEdit
            Get
                Return bIsInEdit
            End Get
        End Property

        Public ReadOnly Property IsNewPoint() As Boolean Implements cIEditTools.IsNewPoint
            Get
                Return bIsNewPoint AndAlso Not IsNothing(oCurrentItemPoint)
            End Get
        End Property

        Public ReadOnly Property IsInPointEdit() As Boolean Implements cIEditTools.IsInPointEdit
            Get
                Return bIsInPointEdit
            End Get
        End Property

        Public ReadOnly Property IsInCombine() As Boolean
            Get
                Return bIsInCombine
            End Get
        End Property

        Public ReadOnly Property CurrentLayer() As cLayer Implements cIEditTools.CurrentLayer
            Get
                Return oCurrentLayer
            End Get
        End Property

        Public ReadOnly Property CurrentItem() As cItem Implements cIEditTools.CurrentItem
            Get
                Return oCurrentItem
            End Get
        End Property

        Public ReadOnly Property CurrentItemPoint() As cPoint Implements cIEditTools.CurrentItemPoint
            Get
                Return oCurrentItemPoint
            End Get
        End Property


        Public ReadOnly Property CurrentBindDesignType As cItem.BindDesignTypeEnum
            Get
                Return iCurrentBindDesignType
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey)
            MyBase.New(Survey)
            oSurvey = Survey
            oCurrentMarkedDesktopPoint = New cMarkedDesktopPoint()
            oFilter = New cFilter(oSurvey)
        End Sub

        Friend Event OnMarkedDesktopPointGetPaintInfo(Sender As Object, Args As cMarkedDesktopPointPaintInfoEventArgs)
        Friend Event OnMarkedDesktopPointMove(Sender As Object, Args As cMarkedDesktopPointMoveEventArgs)
        Friend Event OnMarkedDesktopPointSet(Sender As Object, Args As EventArgs)

        Friend Class cMarkedDesktopPointMoveEventArgs
            Inherits cMarkedDesktopPoint.cMoveEventArgs

            Private oMarkedDesktopPoint As cMarkedDesktopPoint

            Public ReadOnly Property MarkedDesktopPoint As cMarkedDesktopPoint
                Get
                    Return oMarkedDesktopPoint
                End Get
            End Property

            Public Sub New(MarkedDesktopPoint As cMarkedDesktopPoint, Args As cMarkedDesktopPoint.cMoveEventArgs)
                Call MyBase.New(Args.NewPoint)
                oMarkedDesktopPoint = MarkedDesktopPoint
            End Sub
        End Class

        Friend Class cMarkedDesktopPointPaintInfoEventArgs
            Inherits cMarkedDesktopPoint.cPaintInfoEventArgs

            Private oMarkedDesktopPoint As cMarkedDesktopPoint

            Public ReadOnly Property MarkedDesktopPoint As cMarkedDesktopPoint
                Get
                    Return oMarkedDesktopPoint
                End Get
            End Property

            Public Sub New(MarkedDesktopPoint As cMarkedDesktopPoint, Args As cMarkedDesktopPoint.cPaintInfoEventArgs)
                MyBase.New()
                oMarkedDesktopPoint = MarkedDesktopPoint
            End Sub
        End Class

        Private Sub oCurrentMarkedDesktopPoint_OnGetPaintInfo(Sender As cMarkedDesktopPoint, Args As cMarkedDesktopPoint.cPaintInfoEventArgs) Handles oCurrentMarkedDesktopPoint.OnGetPaintInfo
            Dim oArgs As cMarkedDesktopPointPaintInfoEventArgs = New cMarkedDesktopPointPaintInfoEventArgs(Sender, Args)
            RaiseEvent OnMarkedDesktopPointGetPaintInfo(Me, oArgs)
            Args.Scale = oArgs.Scale
        End Sub

        Private Sub oCurrentMarkedDesktopPoint_OnMove(Sender As cMarkedDesktopPoint, Args As cMarkedDesktopPoint.cMoveEventArgs) Handles oCurrentMarkedDesktopPoint.OnMove
            Dim oArgs As cMarkedDesktopPointMoveEventArgs = New cMarkedDesktopPointMoveEventArgs(Sender, Args)
            RaiseEvent OnMarkedDesktopPointMove(Me, oArgs)
        End Sub

        Private Sub oCurrentMarkedDesktopPoint_OnSet(Sender As cMarkedDesktopPoint, Args As EventArgs) Handles oCurrentMarkedDesktopPoint.OnSet
            RaiseEvent OnMarkedDesktopPointSet(Me, Args)
        End Sub
    End Class
End Namespace
