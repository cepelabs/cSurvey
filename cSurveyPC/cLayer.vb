Imports System.Xml
Imports System.Drawing.Drawing2D

Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Imports cSurveyPC.XSystem.Linq.Dynamic
Imports System.Linq.Expressions
Imports System.ComponentModel
Imports DevExpress.XtraLayout.Customization

Namespace cSurvey.Design
    Public Class cLayer
        Private oSurvey As cSurvey
        Private oDesign As cDesign

        Private sName As String
        Private iType As cLayers.LayerTypeEnum
        Private oItems As cItems

        Private bHiddenInDesign As Boolean
        Private bHiddenInPreview As Boolean

#Region "SVG"

        Friend Overridable Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
            Dim oSVGLayer As XmlElement = modSVG.CreateLayer(SVG, "layer" & iType.ToString("D"), iType.ToString)
            Dim oVisibleItems As List(Of cItem) = GetAllVisibleItems(PaintOptions)
            Dim iIndex As Integer = 0
            Dim iCount As Integer = oVisibleItems.Count
            Dim iStep As Integer = If(iCount > 20, iCount \ 20, 1)
            For Each oItem As cItem In oVisibleItems
                iIndex += 1
                If (Options And cItem.SVGOptionsEnum.Silent) = 0 Then If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("svg", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Esportazione livello " & iType & "...", iIndex / iCount)
                If modDesign.GetIfItemMustBeDrawedByCaveAndBranch(PaintOptions, oItem, "", "") Then
                    Dim oSVGItem As XmlElement = oItem.ToSvgItem(SVG, PaintOptions, Options)
                    If oItem.CanBeClipped Then
                        Dim iClipBorder As cClippingRegions.ClipBorderEnum = oSurvey.Properties.DesignProperties.GetValue("ClipBorder", My.Application.Settings.GetSetting("design.clipborder", cClippingRegions.ClipBorderEnum.ClipBorder))
                        If oItem.ClippingType = cItem.cItemClippingTypeEnum.Default Then
                            If (oItem.Type = cIItem.cItemTypeEnum.InvertedFreeHandArea AndAlso iType = cLayers.LayerTypeEnum.Borders) OrElse (iType > cLayers.LayerTypeEnum.Borders) OrElse (iClipBorder = cClippingRegions.ClipBorderEnum.DontClipBorder AndAlso iType = cLayers.LayerTypeEnum.Borders) Then
                                'nothing
                            Else
                                If oItem.Type = cIItem.cItemTypeEnum.FreeHandArea AndAlso oItem.Category = cIItem.cItemCategoryEnum.Soil AndAlso oItem.Design.Type = cIDesign.cDesignTypeEnum.Profile Then
                                    Dim sClippingKey As String = "invmask_" & modExport.FormatCaveBranchNameForSVG(oItem.Cave, oItem.Branch)
                                    Call oSVGItem.SetAttribute("mask", "url(#" & sClippingKey & ")")
                                Else
                                    Dim sClippingKey As String = "mask_" & modExport.FormatCaveBranchNameForSVG(oItem.Cave, oItem.Branch)
                                    Call oSVGItem.SetAttribute("mask", "url(#" & sClippingKey & ")")
                                End If
                            End If
                        Else
                            Select Case oItem.ClippingType
                                Case cItem.cItemClippingTypeEnum.None
                                    'without clipping...
                                Case cItem.cItemClippingTypeEnum.InsideBorder
                                    Dim sClippingKey As String = "mask_" & modExport.FormatCaveBranchNameForSVG(oItem.Cave, oItem.Branch)
                                    Call oSVGItem.SetAttribute("mask", "url(#" & sClippingKey & ")")
                                Case cItem.cItemClippingTypeEnum.OutsideBorder
                                    Dim sClippingKey As String = "invmask_" & modExport.FormatCaveBranchNameForSVG(oItem.Cave, oItem.Branch)
                                    Call oSVGItem.SetAttribute("mask", "url(#" & sClippingKey & ")")
                            End Select
                        End If
                    End If
                    Call modSVG.AppendItem(SVG, oSVGLayer, oSVGItem)
                End If
            Next
            Return oSVGLayer
        End Function

        Friend Overridable Function ToSvg(ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.SVGOptionsEnum) As XmlDocument
            Dim oSVG As XmlDocument = modSVG.CreateSVG
            Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions, Options))
            Return oSVG
        End Function

#End Region

        Public Overridable ReadOnly Property ItemsList() As BindingList(Of cItem)
            Get
                Return oItems.List
            End Get
        End Property

        Public ReadOnly Property Survey() As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public Overridable Function CreateGeneric(ByVal Cave As String, ByVal Branch As String, Optional ByVal Options As cItemGeneric.cItemGenericOptions = Nothing) As cItemGeneric
            Dim oItem As cItemGeneric = New cItemGeneric(oSurvey, oDesign, Me, cIItem.cItemCategoryEnum.None)
            oItem.Pen.Type = cPen.PenTypeEnum.GenericPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.None
            Call oItem.SetCave(Cave, Branch)
            Call oItems.Add(oItem)
            Return oItem
        End Function

        Public Overridable Function CreateGeneric(ByVal Cave As String, ByVal Branch As String, ByVal Clipart As cDrawClipArt, Optional ByVal Options As cItemGeneric.cItemGenericOptions = Nothing) As cItemGeneric
            Dim oItem As cItemGeneric = New cItemGeneric(oSurvey, oDesign, Me, cIItem.cItemCategoryEnum.None, Clipart, Options)
            oItem.Pen.Type = cPen.PenTypeEnum.GenericPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.None
            Call oItem.SetCave(Cave, Branch)
            Call oItems.Add(oItem)
            Return oItem
        End Function

        Public Overridable Function CreateGeneric(ByVal Cave As String, ByVal Branch As String, ByVal Data As Object, ByVal DataFormat As cItemGeneric.cItemGenericDataFormatEnum) As cItemGeneric
            Dim oItem As cItemGeneric = New cItemGeneric(oSurvey, oDesign, Me, cIItem.cItemCategoryEnum.None, Data, DataFormat)
            oItem.Pen.Type = cPen.PenTypeEnum.GenericPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.None
            Call oItem.SetCave(Cave, Branch)
            Call oItems.Add(oItem)
            Return oItem
        End Function

        Public Overridable ReadOnly Property CanBeHiddenInDesign As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overridable ReadOnly Property CanBeHiddenInPreview As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overridable Property HiddenInDesign As Boolean
            Get
                Return bHiddenInDesign
            End Get
            Set(ByVal value As Boolean)
                bHiddenInDesign = value
            End Set
        End Property

        Public Overridable Property HiddenInPreview As Boolean
            Get
                Return bHiddenInPreview
            End Get
            Set(ByVal value As Boolean)
                bHiddenInPreview = value
            End Set
        End Property

        Public Overridable ReadOnly Property Design() As cDesign
            Get
                Return oDesign
            End Get
        End Property

        Public Overridable ReadOnly Property Name() As String
            Get
                Return sName
            End Get
        End Property

        Public Overridable ReadOnly Property Type() As cLayers.LayerTypeEnum
            Get
                Return iType
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal File As cFile, ByVal Layer As XmlElement)
            oSurvey = Survey
            oDesign = Design
            sName = modXML.GetAttributeValue(Layer, "name")
            iType = modXML.GetAttributeValue(Layer, "type")
            bHiddenInDesign = modXML.GetAttributeValue(Layer, "hiddenindesign")
            bHiddenInPreview = modXML.GetAttributeValue(Layer, "hiddeninpreview")
            oItems = New cItems(oSurvey, Design, Me, File, Layer.Item("items"))
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXmlLayer As XmlElement = Document.CreateElement("layer")
            Call oXmlLayer.SetAttribute("name", sName)
            Call oXmlLayer.SetAttribute("type", iType)
            If bHiddenInDesign Then Call oXmlLayer.SetAttribute("hiddenindesign", If(bHiddenInDesign, 1, 0))
            If bHiddenInPreview Then Call oXmlLayer.SetAttribute("hiddeninpreview", If(bHiddenInPreview, 1, 0))
            Call oItems.SaveTo(File, Document, oXmlLayer, Options)
            Call Parent.AppendChild(oXmlLayer)
            Return oXmlLayer
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Name As String, ByVal Type As cLayers.LayerTypeEnum)
            oSurvey = Survey
            oDesign = Design
            sName = Name
            iType = Type
            oItems = New cItems(oSurvey, Design, Me)
        End Sub

        Friend Overridable Function GetItemsByRectangle(ByVal Rectangle As RectangleF, ByVal PaintOptions As cOptions, ByVal CurrentCave As String, ByVal CurrentBranch As String) As List(Of cItem)
            If bHiddenInDesign Then
                Return New List(Of cItem)
            Else
                Return oItems.Where(Function(oItem) modDesign.GetIfItemMustBeDrawedByHiddenFlag(PaintOptions, oItem) AndAlso modDesign.GetIfItemMustBeDrawedByCaveAndBranch(PaintOptions, oItem, CurrentCave, CurrentBranch) AndAlso Rectangle.Contains(oItem.GetBounds)).ToList
            End If
        End Function

        Friend Overridable Function GetItemsByRectangle(ByVal Rectangle As RectangleF, ByVal PaintOptions As cOptionsCenterline) As List(Of cItem)
            If bHiddenInDesign Then
                Return New List(Of cItem)
            Else
                Return oItems.Where(Function(oItem) modDesign.GetIfItemMustBeDrawedByHiddenFlag(PaintOptions, oItem) AndAlso Rectangle.Contains(oItem.GetBounds)).ToList
            End If
        End Function

        Friend Shared Function CreateItem(Survey As cSurvey, Design As cDesign, Layer As cLayer, File As cFile, Item As XmlElement) As cItem
            Dim oItem As cItem = Nothing
            Select Case Item.GetAttribute("type")
                Case cIItem.cItemTypeEnum.Generic
                    oItem = New cItemGeneric(Survey, Design, Layer, File, Item)
                Case cIItem.cItemTypeEnum.FreeHandArea
                    oItem = New cItemFreeHandArea(Survey, Design, Layer, File, Item)
                Case cIItem.cItemTypeEnum.FreeHandLine
                    oItem = New cItemFreeHandLine(Survey, Design, Layer, File, Item)
                Case cIItem.cItemTypeEnum.InvertedFreeHandArea
                    oItem = New cItemInvertedFreeHandArea(Survey, Design, Layer, File, Item)
                Case cIItem.cItemTypeEnum.Sign
                    oItem = New cItemSign(Survey, Design, Layer, File, Item)
                Case cIItem.cItemTypeEnum.Clipart
                    oItem = New cItemClipart(Survey, Design, Layer, File, Item)
                Case cIItem.cItemTypeEnum.Text
                    oItem = New cItemText(Survey, Design, Layer, File, Item)
                Case cIItem.cItemTypeEnum.Image
                    oItem = New cItemImage(Survey, Design, Layer, File, Item)
                Case cIItem.cItemTypeEnum.CrossSection
                    oItem = New cItemCrossSection(Survey, Design, Layer, File, Item)
                Case cIItem.cItemTypeEnum.CrossSectionMarker
                    If Design.Type = cIDesign.cDesignTypeEnum.Plan Then
                        oItem = New cItemPlanCrossSectionMarker(Survey, Design, Layer, File, Item)
                    Else
                        oItem = New cItemProfileCrossSectionMarker(Survey, Design, Layer, File, Item)
                    End If
                Case cIItem.cItemTypeEnum.Quota
                    oItem = New cItemQuota(Survey, Design, Layer, File, Item)
                Case cIItem.cItemTypeEnum.Legend
                    oItem = New cItemLegend(Survey, Design, Layer, File, Item)
                Case cIItem.cItemTypeEnum.Scale
                    oItem = New cItemScale(Survey, Design, Layer, File, Item)
                Case cIItem.cItemTypeEnum.Compass
                    oItem = New cItemCompass(Survey, Design, Layer, File, Item)
                Case cIItem.cItemTypeEnum.InformationBoxText
                    oItem = New cItemInformationBoxText(Survey, Design, Layer, File, Item)
                Case cIItem.cItemTypeEnum.Sketch
                    oItem = New cItemSketch(Survey, Design, Layer, File, Item)
                Case cIItem.cItemTypeEnum.Attachment
                    oItem = New cItemAttachment(Survey, Design, Layer, File, Item)
                    If DirectCast(oItem, cItemAttachment).Attachment Is Nothing Then
                        oItem = Nothing
                    End If

                Case cIItem.cItemTypeEnum.Chunk3D
                    oItem = New cItemChunk3D(Survey, Design, Layer, File, Item)

                Case cIItem.cItemTypeEnum.Items
                    oItem = New cItemItems(Survey, Design, Layer, File, Item)
            End Select
            Return oItem
        End Function

        ''' <summary>
        ''' Create a design item from xml
        ''' </summary>
        ''' <param name="File">File container</param>
        ''' <param name="Item">XML Element</param>
        ''' <returns>The new design item</returns>
        Friend Overridable Function CreateItem(ByVal File As cFile, ByVal Item As XmlElement) As cItem
            Dim oItem As cItem = cLayer.CreateItem(oSurvey, oDesign, Me, File, Item)
            If Not oItem Is Nothing Then
                If TypeOf oItem Is cItemItems Then
                    For Each oSubItem As cItem In DirectCast(oItem, cItemItems)
                        oSubItem.Layer.Items.Add(oSubItem)
                    Next
                Else
                    Call oItems.Add(oItem)
                End If
            End If
            Return oItem
        End Function

        Friend Overridable Function CreateItem(ByVal Type As cIItem.cItemTypeEnum, ByVal Category As cIItem.cItemCategoryEnum, ByVal Segment As cSegment) As cItem
            Dim oItem As cItem = Nothing
            Select Case Type
                Case cIItem.cItemTypeEnum.CrossSection
                    oItem = New cItemCrossSection(oSurvey, oDesign, Me, Category, Segment)
            End Select
            If Not oItem Is Nothing Then
                Call oItems.Add(oItem)
            End If
            Return oItem
        End Function

        Friend Overridable Function CreateItem(ByVal Type As cIItem.cItemTypeEnum, ByVal Category As cIItem.cItemCategoryEnum, ByVal Data As Image) As cItem
            Dim oItem As cItem = Nothing
            Select Case Type
                Case cIItem.cItemTypeEnum.Image
                    oItem = New cItemImage(oSurvey, oDesign, Me, Category, Data)
                Case cIItem.cItemTypeEnum.Sketch
                    oItem = New cItemSketch(oSurvey, oDesign, Me, Category, Data)
            End Select
            If Not oItem Is Nothing Then
                Call oItems.Add(oItem)
            End If
            Return oItem
        End Function

        Friend Overridable Function CreateItem(ByVal Type As cIItem.cItemTypeEnum, ByVal Category As cIItem.cItemCategoryEnum, ByVal Data As String) As cItem
            Dim oItem As cItem = Nothing
            Select Case Type
                Case cIItem.cItemTypeEnum.Quota
                    oItem = New cItemQuota(oSurvey, oDesign, Me, Category, Data)
                Case cIItem.cItemTypeEnum.Text
                    oItem = New cItemText(oSurvey, oDesign, Me, Category, Data)
                Case cIItem.cItemTypeEnum.Attachment
                    oItem = New cItemAttachment(oSurvey, oDesign, Me, Category, Data)
                Case cIItem.cItemTypeEnum.Legend
                    oItem = New cItemLegend(oSurvey, oDesign, Me, Category, Data)
                Case cIItem.cItemTypeEnum.Scale
                    oItem = New cItemScale(oSurvey, oDesign, Me, Category, Data)
            End Select
            If Not oItem Is Nothing Then
                Call oItems.Add(oItem)
            End If
            Return oItem
        End Function

        Friend Overridable Function CreateItem(ByVal Type As cIItem.cItemTypeEnum, ByVal Category As cIItem.cItemCategoryEnum) As cItem
            Dim oItem As cItem = Nothing
            Select Case Type
                Case cIItem.cItemTypeEnum.FreeHandArea
                    oItem = New cItemFreeHandArea(oSurvey, oDesign, Me, Category)
                Case cIItem.cItemTypeEnum.FreeHandLine
                    oItem = New cItemFreeHandLine(oSurvey, oDesign, Me, Category)
                Case cIItem.cItemTypeEnum.InvertedFreeHandArea
                    oItem = New cItemInvertedFreeHandArea(oSurvey, oDesign, Me, Category)
                Case cIItem.cItemTypeEnum.InformationBoxText
                    oItem = New cItemInformationBoxText(oSurvey, oDesign, Me, Category)
            End Select
            If Not oItem Is Nothing Then
                Call oItems.Add(oItem)
            End If
            Return oItem
        End Function

        Friend Overridable Function CreateItem(ByVal Type As cIItem.cItemTypeEnum, ByVal Category As cIItem.cItemCategoryEnum, ByVal Data As Object, ByVal DataFormat As cAttachmentsLinks.cAttachmentDataFormatEnum) As cItem
            Dim oItem As cItem = Nothing
            Select Case Type
                Case cIItem.cItemTypeEnum.Attachment
                    oItem = New cItemAttachment(oSurvey, oDesign, Me, Category, Data, DataFormat)
            End Select
            If Not oItem Is Nothing Then
                Call oItems.Add(oItem)
            End If
            Return oItem
        End Function

        Friend Overridable Function CreateItem(ByVal Type As cIItem.cItemTypeEnum, ByVal Category As cIItem.cItemCategoryEnum, ByVal Data As Object, ByVal DataFormat As cIItemClipartBase.cClipartDataFormatEnum) As cItem
            Dim oItem As cItem = Nothing
            Select Case Type
                Case cIItem.cItemTypeEnum.Compass
                    oItem = New cItemCompass(oSurvey, oDesign, Me, Category, Data, DataFormat)
                Case cIItem.cItemTypeEnum.Sign
                    oItem = New cItemSign(oSurvey, oDesign, Me, Category, Data, DataFormat)
                Case cIItem.cItemTypeEnum.Generic
                    oItem = New cItemGeneric(oSurvey, oDesign, Me, Category, Data, DataFormat)
                Case cIItem.cItemTypeEnum.Clipart
                    oItem = New cItemClipart(oSurvey, oDesign, Me, Category, Data, DataFormat)
            End Select
            If Not oItem Is Nothing Then
                Call oItems.Add(oItem)
            End If
            Return oItem
        End Function

        Public Overridable ReadOnly Property Items() As cItems
            Get
                Return oItems
            End Get
        End Property

        Friend Overridable Function GetAllDesignVisibleItems(PaintOptions As cOptionsCenterline, ByVal CurrentCave As String, ByVal CurrentBranch As String) As List(Of cItem)
            Return GetAllDesignVisibleItems(PaintOptions).Where(Function(oitem) modDesign.GetIfItemMustBeDrawedByCaveAndBranch(PaintOptions, oitem, CurrentCave, CurrentBranch)).ToList
        End Function

        Friend Overridable Function GetAllVisibleItems(PaintOptions As cOptionsCenterline, ByVal CurrentCave As String, ByVal CurrentBranch As String) As List(Of cItem)
            Return GetAllVisibleItems(PaintOptions).Where(Function(oitem) modDesign.GetIfItemMustBeDrawedByCaveAndBranch(PaintOptions, oitem, CurrentCave, CurrentBranch)).ToList
        End Function

        Friend Overridable Function GetAllDesignVisibleItems(PaintOptions As cOptionsCenterline) As List(Of cItem)
            Return GetAllVisibleItems(PaintOptions).Where(Function(item) item.DesignAffinity = cItem.DesignAffinityEnum.Design).ToList
        End Function

        Friend Overridable Function GetAllVisibleItems(PaintOptions As cOptionsCenterline) As List(Of cItem)
            Dim oVisibleItems As List(Of cItem) = New List(Of cItem)
            Dim sCurrentProfile As String = PaintOptions.CurrentCaveVisibilityProfile
            If sCurrentProfile = "" Then
                Call oVisibleItems.AddRange(oItems.Where(Function(oitem) modDesign.GetIfItemMustBeDrawedByHiddenFlag(PaintOptions, oitem)))
            Else
                Dim sItemsQuery As String = oSurvey.Properties.CaveVisibilityProfiles.GetItemsQuery(sCurrentProfile)
                If sItemsQuery = "" Then
                    Call oVisibleItems.AddRange(oItems.Where(Function(oitem) oSurvey.Properties.CaveVisibilityProfiles.GetVisible(sCurrentProfile, oitem.Cave, oitem.Branch) AndAlso modDesign.GetIfItemMustBeDrawedByHiddenFlag(PaintOptions, oitem)))
                Else
                    Try
                        Dim oQueryItems = From oItem As cItem In oItems.ToArray.AsQueryable.Where(sItemsQuery) Select oItem
                        Call oVisibleItems.AddRange(oQueryItems.Where(Function(oitem) oSurvey.Properties.CaveVisibilityProfiles.GetVisible(sCurrentProfile, oitem.Cave, oitem.Branch) AndAlso modDesign.GetIfItemMustBeDrawedByHiddenFlag(PaintOptions, oitem)))
                    Catch ex As Exception
                        Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Error, "cLayer.GetAllVisibleItems -> " & ex.Message)
                    End Try
                End If
            End If
            Return oVisibleItems
        End Function

        Friend Overridable Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Clipping As cClippingRegions, Selection As Helper.Editor.cIEditDesignSelection)
            'Try
            Dim oItems As List(Of cItem) = GetAllVisibleItems(PaintOptions)
                If oItems.Count > 0 Then
                    Dim oVisibleBounds As RectangleF
                    Dim oBaseVisibleBounds As RectangleF = Graphics.VisibleClipBounds
                    Dim bTraslation As Boolean = Not PaintOptions.IsDesign And PaintOptions.DrawTranslation

                    Dim oCurrentItem As cItem = Nothing
                    Dim bCurrentItem As Boolean
                    Dim bCurrentItemIsInEdit As Boolean
                    If PaintOptions.IsDesign Then
                        oCurrentItem = Selection.CurrentItem
                        bCurrentItemIsInEdit = Selection.IsInEditing
                    End If

                    For Each oItem As cItem In oItems
                        If modDesign.GetIfItemMustBeDrawedByCaveAndBranch(PaintOptions, oItem, Selection.CurrentCave, Selection.CurrentBranch) Then
                            Dim iSelectionMode As cItem.SelectionModeEnum
                            If PaintOptions.IsDesign Then
                                If TypeOf oCurrentItem Is cItemItems Then
                                    If DirectCast(oCurrentItem, cItemItems).Contains(oItem) Then
                                        iSelectionMode = cItem.SelectionModeEnum.Selected
                                        bCurrentItem = True
                                    Else
                                        iSelectionMode = cItem.SelectionModeEnum.None
                                        bCurrentItem = False
                                    End If
                                Else
                                    If oItem Is oCurrentItem Then
                                        If bCurrentItemIsInEdit Then
                                            iSelectionMode = cItem.SelectionModeEnum.InEdit
                                        Else
                                            iSelectionMode = cItem.SelectionModeEnum.Selected
                                        End If
                                        bCurrentItem = True
                                    Else
                                        iSelectionMode = cItem.SelectionModeEnum.None
                                        bCurrentItem = False
                                    End If
                                End If
                            End If

                            oVisibleBounds = oBaseVisibleBounds

                            Dim oState As GraphicsState = Graphics.Save()
                            If bTraslation Then
                                Dim oTranslation As PointF = oDesign.GetItemTranslation(oItem)
                                If Not oTranslation.IsEmpty Then
                                    Call Graphics.TranslateTransform(oTranslation.X, oTranslation.Y, Drawing2D.MatrixOrder.Prepend)
                                    Call oVisibleBounds.Offset(-oTranslation.X, -oTranslation.Y)
                                End If
                            End If

                            Dim bDraw As Boolean = False
                            If PaintOptions.IsPreview Then
                                bDraw = True
                            Else
                                If bCurrentItem Then
                                    bDraw = True
                                Else
                                    If oItem.IsInvalidated(PaintOptions) Then
                                        bDraw = True
                                    Else
                                        If oVisibleBounds.IntersectsWith(oItem.GetBounds) Then
                                            bDraw = True
                                        End If
                                    End If
                                End If
                            End If

                            If bDraw Then
                                Call Graphics.SetClip(Clipping.GetClip(Graphics, Me, oItem), CombineMode.Replace)
                                Call oItem.Paint(Graphics, PaintOptions, Options, iSelectionMode)
                            End If
                            Call Graphics.Restore(oState)
                        End If
                        'End If
                    Next
                End If
            'Catch ex As Exception
            '    Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Error, "cLayer.Paint -> " & ex.Message)
            'End Try
        End Sub

        Public Overridable Function HitTest(ByVal PaintOptions As cOptions, ByVal CurrentCave As String, ByVal CurrentBranch As String, ByVal Point As PointF, ByVal Wide As Single, First As Boolean) As List(Of cItem)
            Dim oHitTestItems As List(Of cItem) = New List(Of cItem)
            If Not bHiddenInDesign Then
                For i = oItems.Count - 1 To 0 Step -1
                    Dim oItem As cItem = oItems(i)
                    If modDesign.GetIfItemMustBeDrawedByHiddenFlag(PaintOptions, oItem) Then
                        If modDesign.GetIfItemMustBeDrawedByCaveAndBranch(PaintOptions, oItem, CurrentCave, CurrentBranch) Then
                            If oItem.HitTest(PaintOptions, Point, Wide) Then
                                Call oHitTestItems.Add(oItem)
                                If First Then Exit For
                            End If
                        End If
                    End If
                Next
            End If
            Return oHitTestItems
        End Function

        Public Overridable Function HitTest(ByVal PaintOptions As cOptions, ByVal CurrentCave As String, ByVal CurrentBranch As String, ByVal X As Single, ByVal Y As Single, ByVal Wide As Single, First As Boolean) As List(Of cItem)
            Return HitTest(PaintOptions, CurrentCave, CurrentBranch, New PointF(X, Y), Wide, First)
        End Function

        Friend Function GetAllItems() As List(Of cItem)
            Return oItems.ToList
        End Function

        Friend Function GetAllItems(Type As cIItem.cItemTypeEnum) As List(Of cItem)
            Return oItems.Where(Function(oItem) oItem.Type = Type).ToList
        End Function
    End Class
End Namespace