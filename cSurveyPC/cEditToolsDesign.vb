Imports System.Xml

Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design
    Friend Class cEditToolsDesign
        Private oSurvey As cSurvey

        Public LastPoint As PointF
        Public CurrentPoint As PointF
        Public LastCenterPoint As PointF
        Public LastBounds As RectangleF
        Public LastAngle As Single
        Public LastAnchor As AnchorRectangleTypeEnum

        Private bIsNewItem As Boolean
        Private bStarted As Boolean

        Private bIsInPointEdit As Boolean
        Private bIsInEdit As Boolean
        Private bIsInCombine As Boolean

        Private oCurrentLayer As cLayer
        Private oCurrentItem As cItem
        Private oCurrentItemPoint As cPoint

        Private sCurrentCave As String = ""
        Private sCurrentBranch As String = ""
        Private iCurrentBindDesignType As cItem.BindDesignTypeEnum

        Private WithEvents oCurrentMarkedDesktopPoint As cMarkedDesktopPoint

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

        Public Class cPasteSpecialEventArgs
            Private oBag As Object
            Private oLocation As PointF

            Private oItems As List(Of cItem)

            Public ReadOnly Property Bag As Object
                Get
                    Return oBag
                End Get
            End Property

            Public ReadOnly Property Location As PointF
                Get
                    Return oLocation
                End Get
            End Property

            Public ReadOnly Property Items As List(Of cItem)
                Get
                    Return oItems
                End Get
            End Property

            Friend Sub New(ByVal Bag As Object, ByVal Location As PointF)
                oBag = Bag
                oLocation = Location
                oItems = New List(Of cItem)
            End Sub
        End Class

        Public Class cEditToolsDesignEventArgs
            Private oCurrentLayer As cLayer
            Private oCurrentItem As cItem
            Private oCurrentItemPoint As cPoint
            Private bIsNewItem As Boolean

            Friend Sub New(ByVal Tool As cEditToolsDesign)
                oCurrentLayer = Tool.CurrentLayer
                oCurrentItem = Tool.CurrentItem
                oCurrentItemPoint = Tool.CurrentItemPoint
                bIsNewItem = Tool.IsNewItem
            End Sub

            Friend Sub New(ByVal CurrentLayer As cLayer, ByVal CurrentItem As cItem, ByVal CurrentItemPoint As cPoint, ByVal IsNewItem As Boolean)
                oCurrentLayer = CurrentLayer
                oCurrentItem = CurrentItem
                oCurrentItemPoint = CurrentItemPoint
                bIsNewItem = IsNewItem
            End Sub

            Public ReadOnly Property IsNewItem As Boolean
                Get
                    Return bIsNewItem
                End Get
            End Property

            Public ReadOnly Property CurrentLayer() As cLayer
                Get
                    Return oCurrentLayer
                End Get
            End Property

            Public ReadOnly Property CurrentItem() As cItem
                Get
                    Return oCurrentItem
                End Get
            End Property

            Public ReadOnly Property CurrentItemPoint() As cPoint
                Get
                    Return oCurrentItemPoint
                End Get
            End Property
        End Class

        Friend Event OnItemSelect(ByVal Sender As cEditToolsDesign, ByVal ToolEventArgs As cEditToolsDesignEventArgs)
        Friend Event OnItemCombine(ByVal Sender As cEditToolsDesign, ByVal ToolEventArgs As cEditToolsDesignEventArgs)
        Friend Event OnItemEdit(ByVal Sender As cEditToolsDesign, ByVal ToolEventArgs As cEditToolsDesignEventArgs)
        Friend Event OnItemDelete(ByVal Sender As cEditToolsDesign, ByVal ToolEventArgs As cEditToolsDesignEventArgs)
        Friend Event OnItemPointDelete(ByVal Sender As cEditToolsDesign, ByVal ToolEventArgs As cEditToolsDesignEventArgs)
        Friend Event OnItemPointEdit(ByVal Sender As cEditToolsDesign, ByVal ToolEventArgs As cEditToolsDesignEventArgs)
        Friend Event OnItemPointEnd(ByVal Sender As cEditToolsDesign, ByVal ToolEventArgs As cEditToolsDesignEventArgs)
        Friend Event OnItemEnd(ByVal Sender As cEditToolsDesign, ByVal ToolEventArgs As cEditToolsDesignEventArgs)
        Friend Event OnLayerSelect(ByVal Sender As cEditToolsDesign, ByVal ToolEventArgs As cEditToolsDesignEventArgs)

        'Friend Event OnPasteSpecial(ByVal Sender As cEditToolsDesign, ByVal PasteSpecialEventArgs As cPasteSpecialEventArgs)

        Public Sub SelectLayer(ByVal Layer As cLayer)
            If Not Layer Is oCurrentLayer Then
                Call [EndItem]()
                oCurrentLayer = Layer
                RaiseEvent OnLayerSelect(Me, New cEditToolsDesignEventArgs(Me))
            End If
        End Sub

        Public Sub RefreshTools()
            If Not oCurrentItem Is Nothing Then
                LastCenterPoint = oCurrentItem.GetCenterPoint
                LastBounds = oCurrentItem.GetBounds
            End If
        End Sub

        Public Sub [SelectItem](ByVal Item As cItem)
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
                If Not oCurrentLayer Is Item.Layer And Not Item.Layer Is Nothing Then
                    oCurrentLayer = Item.Layer
                    RaiseEvent OnLayerSelect(Me, New cEditToolsDesignEventArgs(Me))
                End If
                oCurrentItem = Item
            End If

            Call RefreshTools()
            bIsInEdit = False
            bIsInCombine = False
            bIsNewItem = False
            bStarted = False
            RaiseEvent OnItemSelect(Me, New cEditToolsDesignEventArgs(Me))
            If Not oCurrentItem Is Nothing Then
                Call oSurvey.Undo.Push("Modifica oggetto", cUndo.ActionEnum.Update, oCurrentLayer, oCurrentItem, oCurrentLayer.Items.IndexOf(oCurrentItem))
            End If
        End Sub

        Public Sub SelectBindDesignType(ByVal BindDesignType As cItem.BindDesignTypeEnum)
            If iCurrentBindDesignType <> BindDesignType Then
                iCurrentBindDesignType = BindDesignType
            End If
        End Sub

        Public Sub [SelectCave](ByVal CaveBranch As cCaveInfoBranch)
            If CaveBranch Is Nothing Then
                sCurrentCave = ""
                sCurrentBranch = ""
            Else
                If (sCurrentCave <> CaveBranch.Cave) And (sCurrentBranch <> CaveBranch.Name) Then
                    sCurrentCave = CaveBranch.Cave
                    sCurrentBranch = CaveBranch.Name
                End If
            End If
        End Sub

        Public Sub [SelectCave](ByVal Cave As cCaveInfo)
            If Cave Is Nothing Then
                sCurrentCave = ""
                sCurrentBranch = ""
            Else
                If (sCurrentCave <> Cave.Name) Then
                    sCurrentCave = Cave.Name
                    sCurrentBranch = ""
                End If
            End If
        End Sub

        Public Sub [SelectCave](ByVal Cave As String, Optional ByVal CaveBranch As String = "")
            If (Cave <> sCurrentCave) Or (CaveBranch <> sCurrentBranch) Then
                sCurrentCave = Cave
                If sCurrentCave <> "" Then
                    sCurrentBranch = CaveBranch
                Else
                    sCurrentBranch = ""
                End If
            End If
        End Sub

        Public Sub EditItem(ByVal Item As cItem, Optional ByVal IsNewItem As Boolean = False)
            Call [EndItem]()
            oCurrentItem = Item
            If Not oCurrentLayer Is Item.Layer And Not Item.Layer Is Nothing Then
                oCurrentLayer = Item.Layer
                RaiseEvent OnLayerSelect(Me, New cEditToolsDesignEventArgs(Me))
            End If
            oCurrentItemPoint = Nothing
            bIsInEdit = True
            bIsInCombine = False
            If IsNewItem Then
                bIsNewItem = True
                bStarted = False
                'Call oSurvey.Undo.Push("Nuovo oggetto", cUndo.ActionEnum.Insert, oCurrentLayer, oCurrentItem, oCurrentLayer.Items.IndexOf(oCurrentItem))
            Else
                bIsNewItem = False
                bStarted = False
                Call oSurvey.Undo.Push("Modifica oggetto", cUndo.ActionEnum.Update, oCurrentLayer, oCurrentItem, oCurrentLayer.Items.IndexOf(oCurrentItem))
            End If
            RaiseEvent OnItemEdit(Me, New cEditToolsDesignEventArgs(Me))
        End Sub

        Public Sub CombineItem(ByVal Item As cItem)
            Call [EndItem]()
            oCurrentItem = Item
            oCurrentItemPoint = Nothing
            'bIsInEdit = False
            bIsInCombine = True
            'bIsNewItem = False
            'bStarted = False
            RaiseEvent OnItemCombine(Me, New cEditToolsDesignEventArgs(Me))
        End Sub

        Public Sub EndAndSelectItem()
            Dim oItem As cItem = oCurrentItem
            Call EndItem()
            If Not oItem Is Nothing Then
                If Not oItem.Deleted Then
                    Call SelectItem(oItem)
                    Call oSurvey.Undo.Push("Modifica oggetto", cUndo.ActionEnum.Update, oCurrentLayer, oCurrentItem, oCurrentLayer.Items.IndexOf(oCurrentItem))
                End If
            End If
        End Sub

        Private Function pItemFromStorage(XML As XmlDocument, Design As cDesign, PerformSelectItem As Boolean) As cItem
            Dim oPastedItem As cItem = Nothing
            Dim oXMLItem As XmlElement = XML.Item("parent").FirstChild
            Dim iType As cIItem.cItemTypeEnum = oXMLItem.GetAttribute("type")
            If iType = cIItem.cItemTypeEnum.Items Then
                Dim oItems As Items.cItemItems = New Items.cItemItems(oSurvey, oCurrentLayer.Design, oCurrentLayer, cIItem.cItemCategoryEnum.None)
                For Each oXmlSubItem As XmlElement In oXMLItem.Item("items")
                    Try
                        Dim iLayerType As cLayers.LayerTypeEnum = oXmlSubItem.GetAttribute("layer")
                        Dim oFile As Storage.cFile = New Storage.cFile(Storage.cFile.FileFormatEnum.CSX)
                        Dim oItem As cItem = Design.Layers(iLayerType).CreateItem(oFile, oXmlSubItem)
                        Call EditItem(oItem, True)  'simulo un edit cosi da scatenare l'undo e tutto il resto...
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
                Dim oItem As cItem = Design.Layers(iLayerType).CreateItem(oFile, oXMLItem)
                Call EditItem(oItem, True)
                Call EndItem()
                oPastedItem = oItem
                If PerformSelectItem Then
                    oCurrentItem = Nothing
                    Call SelectItem(oItem)
                End If
            End If
            Return oPastedItem
        End Function

        Public Function PasteItem(Optional ByVal Format As String = "", Optional ByVal Location As PointF = Nothing) As cItem
            Dim oPastedItem As cItem = Nothing
            Try
                If Format = "" Then
                    If Clipboard.ContainsData("csurvey.item") Then
                        Dim oXML As XmlDocument = New XmlDocument
                        Call oXML.LoadXml(Clipboard.GetText)
                        oPastedItem = pItemFromStorage(oXML, oCurrentLayer.Design, True)
                    ElseIf Clipboard.ContainsData("image/svg+xml") Then
                        'si tratta di svg...
                        'tento la creazione di un oggetto GENERIC...
                        Dim sData As String = modSVG.GetSVGDataFromClipboard
                        Dim oItem As Items.cItemGeneric = oCurrentLayer.CreateGeneric(sCurrentCave, sCurrentBranch, sData, Items.cItemGeneric.cItemGenericDataFormatEnum.SVGData)
                        Call oItem.MoveTo(Location)
                        Call EditItem(oItem, True)  'simulo un edit cosi da scatenare l'undo e tutto il resto...
                        Call EndItem()
                        oPastedItem = oItem
                        Call SelectItem(oItem)
                    ElseIf Clipboard.ContainsText Then
                        Dim oLayer As Layers.cLayerSigns = oCurrentLayer.Design.Layers(cLayers.LayerTypeEnum.Signs)
                        Call SelectLayer(oLayer)
                        Dim sText As String = Clipboard.GetText
                        sText = sText.Trim
                        If sText <> "" Then
                            Dim oitem As Items.cItemText = oLayer.CreateText(sCurrentCave, sCurrentBranch, sText)
                            Call oitem.MoveTo(Location)
                            Call EditItem(oitem, True)  'simulo un edit cosi da scatenare l'undo e tutto il resto...
                            Call EndItem()
                            oPastedItem = oitem
                            Call SelectItem(oitem)
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
                                Dim oItem As Items.cItemClipart = oLayerRocks.CreateRock(sCurrentCave, sCurrentBranch, sData, Items.cItemClipart.cItemClipartDataFormatEnum.SVGData)
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
            Call oCurrentItem.SaveTo(oFile, oXML, oXMLParent)
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
                        RaiseEvent OnItemPointDelete(Me, New cEditToolsDesignEventArgs(Me))
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

        Public Sub DeleteItem()
            If oCurrentItem IsNot Nothing Then
                If oCurrentItem.Type = cIItem.cItemTypeEnum.Items Then
                    Call oSurvey.Undo.Push("Elimina oggetti", cUndo.ActionEnum.Delete, oCurrentLayer, oCurrentItem, oCurrentLayer.Items.IndexOf(oCurrentItem))
                    Call oCurrentLayer.Items.Remove(oCurrentItem)
                    Dim oItems As cSurveyPC.cSurvey.Design.Items.cItemItems = oCurrentItem
                    For Each oItem As cItem In oItems
                        Call oCurrentLayer.Design.RemoveItem(oItem)
                    Next
                Else
                    Call oSurvey.Undo.Push("Elimina oggetto", cUndo.ActionEnum.Delete, oCurrentLayer, oCurrentItem, oCurrentLayer.Items.IndexOf(oCurrentItem))
                    Call oCurrentLayer.Items.Remove(oCurrentItem)
                End If
                RaiseEvent OnItemDelete(Me, New cEditToolsDesignEventArgs(Me))
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

        Public Sub [EndItem]()
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
                RaiseEvent OnItemEnd(Me, New cEditToolsDesignEventArgs(oCurrentLayer, oCurrentItem, oCurrentItemPoint, bIsNewItem))
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

        Public Sub EndPoint()
            If Not oCurrentItem Is Nothing Then
                If Not oCurrentItemPoint Is Nothing Then
                    'Call oSurvey.Undo.Push("Fine modifica punti", cUndo.ActionEnum.Update, oCurrentLayer, oCurrentItem, oCurrentLayer.Items.IndexOf(oCurrentItem))
                    RaiseEvent OnItemPointEnd(Me, New cEditToolsDesignEventArgs(oCurrentLayer, oCurrentItem, oCurrentItemPoint, bIsNewItem))
                    oCurrentItemPoint = Nothing
                End If
            End If
        End Sub

        Public Sub SelectPoint(ByVal Point As cPoint)
            Call EditPoint(Point)
        End Sub

        Public Sub EditPoint(ByVal Point As cPoint)
            If Not oCurrentItem Is Nothing Then
                If Not oCurrentItemPoint Is Point Then
                    oCurrentItemPoint = Point
                    RaiseEvent OnItemPointEdit(Me, New cEditToolsDesignEventArgs(Me))
                End If
            End If
        End Sub

        Public Sub StartEditItem()
            If bIsNewItem Then
                'bIsNewItem = False
                bStarted = True
            End If
        End Sub

        Public ReadOnly Property Started As Boolean
            Get
                Return bStarted
            End Get
        End Property

        Public ReadOnly Property IsInEdit() As Boolean
            Get
                Return bIsInEdit
            End Get
        End Property

        Public ReadOnly Property IsInPointEdit() As Boolean
            Get
                Return bIsInPointEdit
            End Get
        End Property

        Public ReadOnly Property IsInCombine() As Boolean
            Get
                Return bIsInCombine
            End Get
        End Property

        Public ReadOnly Property CurrentLayer() As cLayer
            Get
                Return oCurrentLayer
            End Get
        End Property

        Public ReadOnly Property CurrentItem() As cItem
            Get
                Return oCurrentItem
            End Get
        End Property

        Public ReadOnly Property CurrentItemPoint() As cPoint
            Get
                Return oCurrentItemPoint
            End Get
        End Property

        Public ReadOnly Property CurrentCave() As String
            Get
                Return sCurrentCave
            End Get
        End Property

        Public ReadOnly Property CurrentBranch() As String
            Get
                Return sCurrentBranch
            End Get
        End Property

        Public ReadOnly Property CurrentBindDesignType As cItem.BindDesignTypeEnum
            Get
                Return iCurrentBindDesignType
            End Get
        End Property

        Friend Sub Reset()
            oCurrentItem = Nothing
            oCurrentItemPoint = Nothing
            bIsInEdit = False
            bIsInCombine = False
        End Sub

        Friend Sub Clear()
            oCurrentLayer = Nothing
            oCurrentItem = Nothing
            oCurrentItemPoint = Nothing
            bIsInEdit = False
            bIsInCombine = False
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oCurrentMarkedDesktopPoint = New cMarkedDesktopPoint()
        End Sub

        Friend Event OnMarkedDesktopPointGetPaintInfo(Sender As cEditToolsDesign, Args As cMarkedDesktopPointPaintInfoEventArgs)
        Friend Event OnMarkedDesktopPointMove(Sender As cEditToolsDesign, Args As cMarkedDesktopPointMoveEventArgs)
        Friend Event OnMarkedDesktopPointSet(Sender As cEditToolsDesign, Args As EventArgs)

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
