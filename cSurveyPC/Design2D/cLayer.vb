Imports System.Xml
Imports System.Drawing.Drawing2D

Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Imports cSurveyPC.XSystem.Linq.Dynamic
Imports System.Linq.Expressions

Namespace cSurvey.Design
    Public Class cLayer
        Implements cILayer
        Private oSurvey As cSurvey
        Private oDesign As cDesign

        Private sName As String
        Private iType As cLayers.LayerTypeEnum
        Private oItems As cItems

        Private bHiddenInDesign As Boolean
        Private bHiddenInPreview As Boolean

#Region "SVG"

        Friend Overridable Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
            Dim oSVGLayer As XmlElement = modSVG.CreateLayer(SVG, iType, iType.ToString)
            Dim oVisibleItems As List(Of cItem) = GetAllVisibleItems(PaintOptions)
            Dim iIndex As Integer = 0
            Dim iCount As Integer = oVisibleItems.Count
            Dim iStep As Integer = IIf(iCount > 20, iCount \ 20, 1)
            For Each oItem As cItem In oVisibleItems
                iIndex += 1
                If (Options And cItem.SVGOptionsEnum.Silent) = 0 Then If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("svg", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Esportazione livello " & iType & "...", iIndex / iCount)
                'If GetIfItemVisible(PaintOptions, oItem) Then
                If modDesign.GetIfItemMustBeDrawedByCaveAndBranch(PaintOptions, oItem, "", "") Then
                    Dim oSVGItem As XmlElement = oItem.ToSvgItem(SVG, PaintOptions, Options)
                    'occhio qua devo definire come clippare l'oggetto....
                    Dim iClipBorder As cClippingRegions.ClipBorderEnum = oSurvey.Properties.DesignProperties.GetValue("ClipBorder", oSurvey.GetGlobalSetting("design.clipborder", cClippingRegions.ClipBorderEnum.ClipBorder))
                    If oItem.ClippingType = cItem.cItemClippingTypeEnum.Default Then
                        If (oItem.Type = cIItem.cItemTypeEnum.InvertedFreeHandArea And iType = cLayers.LayerTypeEnum.Borders) Or (iType > cLayers.LayerTypeEnum.Borders) Or (iClipBorder = cClippingRegions.ClipBorderEnum.DontClipBorder And iType = cLayers.LayerTypeEnum.Borders) Then
                            'nulla
                        Else
                            Dim sClippingKey As String = "clip_" & modExport.FormatCaveBranchName(oItem.Cave, oItem.Branch)
                            Call oSVGItem.SetAttribute("clip-path", "url(#" & sClippingKey & ")")
                        End If
                    Else
                        Select Case oItem.ClippingType
                            Case cItem.cItemClippingTypeEnum.None
                                'senza clipping restituisco sempre TUTTO
                            Case cItem.cItemClippingTypeEnum.InsideBorder
                                Dim sClippingKey As String = "clip_" & modExport.FormatCaveBranchName(oItem.Cave, oItem.Branch)
                                Call oSVGItem.SetAttribute("clip-path", "url(#" & sClippingKey & ")")
                            Case cItem.cItemClippingTypeEnum.OutsideBorder
                                'ops...qua non so come fare.......quindi, per ora, non faccio niente...
                        End Select
                    End If

                    Call modSVG.AppendItem(SVG, oSVGLayer, oSVGItem)
                End If
            Next
            Return oSVGLayer
        End Function

        Friend Overridable Function ToSvg(ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlDocument
            Dim oSVG As XmlDocument = modSVG.CreateSVG
            Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions, Options))
            Return oSVG
        End Function

#End Region

        Public Function CreateGeneric(ByVal Cave As String, ByVal Branch As String, ByVal Clipart As cDrawClipArt, Optional ByVal Options As cItemGeneric.cItemGenericOptions = Nothing) As cItemGeneric
            Dim oItem As cItemGeneric = New cItemGeneric(oSurvey, oDesign, Me, cIItem.cItemCategoryEnum.None, Clipart, Options)
            oItem.Pen.Type = cPen.PenTypeEnum.GenericPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.None
            Call oItem.SetCave(Cave, Branch)
            Call oItems.Add(oItem)
            Return oItem
        End Function

        Public Function CreateGeneric(ByVal Cave As String, ByVal Branch As String, ByVal Data As Object, ByVal DataFormat As cItemGeneric.cItemGenericDataFormatEnum) As cItemGeneric
            Dim oItem As cItemGeneric = New cItemGeneric(oSurvey, oDesign, Me, cIItem.cItemCategoryEnum.None, Data, DataFormat)
            oItem.Pen.Type = cPen.PenTypeEnum.GenericPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.None
            Call oItem.SetCave(Cave, Branch)
            Call oItems.Add(oItem)
            Return oItem
        End Function

        Public Property HiddenInDesign As Boolean Implements cILayer.HiddenInDesign
            Get
                Return bHiddenInDesign
            End Get
            Set(ByVal value As Boolean)
                bHiddenInDesign = value
            End Set
        End Property

        Public Property HiddenInPreview As Boolean Implements cILayer.HiddenInPreview
            Get
                Return bHiddenInPreview
            End Get
            Set(ByVal value As Boolean)
                bHiddenInPreview = value
            End Set
        End Property

        Public ReadOnly Property Design() As cIDesign Implements cILayer.Design
            Get
                Return oDesign
            End Get
        End Property

        Public ReadOnly Property Name() As String Implements cILayer.Name
            Get
                Return sName
            End Get
        End Property

        Public ReadOnly Property Type() As cLayers.LayerTypeEnum Implements cILayer.Type
            Get
                Return iType
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal File As Storage.cFile, ByVal Layer As XmlElement)
            oSurvey = Survey
            oDesign = Design
            sName = modXML.GetAttributeValue(Layer, "name")
            iType = modXML.GetAttributeValue(Layer, "type")
            bHiddenInDesign = modXML.GetAttributeValue(Layer, "hiddenindesign")
            bHiddenInPreview = modXML.GetAttributeValue(Layer, "hiddeninpreview")
            oItems = New cItems(oSurvey, Design, Me, File, Layer.Item("items"))
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXmlLayer As XmlElement = Document.CreateElement("layer")
            Call oXmlLayer.SetAttribute("name", sName)
            Call oXmlLayer.SetAttribute("type", iType)
            If bHiddenInDesign Then Call oXmlLayer.SetAttribute("hiddenindesign", IIf(bHiddenInDesign, 1, 0))
            If bHiddenInPreview Then Call oXmlLayer.SetAttribute("hiddeninpreview", IIf(bHiddenInPreview, 1, 0))
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

        Friend Function GetItemsByRectangle(ByVal Rectangle As RectangleF, ByVal PaintOptions As cOptions, ByVal CurrentCave As String, ByVal CurrentBranch As String) As List(Of cItem)
            Dim oResultItems As List(Of cItem) = New List(Of cItem)
            If Not bHiddenInDesign Then
                For Each oItem As cItem In oItems
                    If modDesign.GetIfItemMustBeDrawedByHiddenFlag(PaintOptions, oItem) Then
                        If modDesign.GetIfItemMustBeDrawedByCaveAndBranch(PaintOptions, oItem, CurrentCave, CurrentBranch) Then
                            If Rectangle.Contains(oItem.GetBounds) Then
                                Call oResultItems.Add(oItem)
                            End If
                        End If
                    End If
                Next
            End If
            Return oResultItems
        End Function

        Friend Function GetItemsByRectangle(ByVal Rectangle As RectangleF, ByVal PaintOptions As cOptions) As List(Of cItem)
            Dim oResultItems As List(Of cItem) = New List(Of cItem)
            If Not bHiddenInDesign Then
                For Each oItem As cItem In oItems
                    If modDesign.GetIfItemMustBeDrawedByHiddenFlag(PaintOptions, oItem) Then
                        If Rectangle.Contains(oItem.GetBounds) Then
                            Call oResultItems.Add(oItem)
                        End If
                    End If
                Next
            End If
            Return oResultItems
        End Function

        Friend Function CreateItem(ByVal File As Storage.cFile, ByVal Item As XmlElement) As cItem
            Dim oItem As cItem = Nothing
            Select Case Item.GetAttribute("type")
                Case cIItem.cItemTypeEnum.Generic
                    oItem = New cItemGeneric(oSurvey, oDesign, Me, File, Item)
                Case cIItem.cItemTypeEnum.FreeHandArea
                    oItem = New cItemFreeHandArea(oSurvey, oDesign, Me, File, Item)
                Case cIItem.cItemTypeEnum.FreeHandLine
                    oItem = New cItemFreeHandLine(oSurvey, oDesign, Me, File, Item)
                Case cIItem.cItemTypeEnum.InvertedFreeHandArea
                    oItem = New cItemInvertedFreeHandArea(oSurvey, oDesign, Me, File, Item)
                Case cIItem.cItemTypeEnum.Sign
                    oItem = New cItemSign(oSurvey, oDesign, Me, File, Item)
                Case cIItem.cItemTypeEnum.Clipart
                    oItem = New cItemClipart(oSurvey, oDesign, Me, File, Item)
                    If DirectCast(oItem, cItemClipart).Clipart Is Nothing Then
                        oItem = Nothing
                    End If
                Case cIItem.cItemTypeEnum.Text
                    oItem = New cItemText(oSurvey, oDesign, Me, File, Item)
                Case cIItem.cItemTypeEnum.Image
                    oItem = New cItemImage(oSurvey, oDesign, Me, File, Item)
                Case cIItem.cItemTypeEnum.CrossSection
                    oItem = New cItemCrossSection(oSurvey, oDesign, Me, File, Item)
                Case cIItem.cItemTypeEnum.Quota
                    oItem = New cItemQuota(oSurvey, oDesign, Me, File, Item)
                Case cIItem.cItemTypeEnum.Sketch
                    oItem = New cItemSketch(oSurvey, oDesign, Me, File, Item)
            End Select
            If Not oItem Is Nothing Then
                Call oItems.Add(oItem)
            End If
            Return oItem
        End Function

        Friend Function CreateItem(ByVal Type As cIItem.cItemTypeEnum, ByVal Category As cIItem.cItemCategoryEnum, ByVal Segment As cSegment) As cItem
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

        Friend Function CreateItem(ByVal Type As cIItem.cItemTypeEnum, ByVal Category As cIItem.cItemCategoryEnum, ByVal Data As Image) As cItem
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

        Friend Function CreateItem(ByVal Type As cIItem.cItemTypeEnum, ByVal Category As cIItem.cItemCategoryEnum, ByVal Data As String) As cItem
            Dim oItem As cItem = Nothing
            Select Case Type
                Case cIItem.cItemTypeEnum.Quota
                    oItem = New cItemQuota(oSurvey, oDesign, Me, Category, Data)
                Case cIItem.cItemTypeEnum.Text
                    oItem = New cItemText(oSurvey, oDesign, Me, Category, Data)
            End Select
            If Not oItem Is Nothing Then
                Call oItems.Add(oItem)
            End If
            Return oItem
        End Function

        Friend Function CreateItem(ByVal Type As cIItem.cItemTypeEnum, ByVal Category As cIItem.cItemCategoryEnum) As cItem
            Dim oItem As cItem = Nothing
            Select Case Type
                Case cIItem.cItemTypeEnum.FreeHandArea
                    oItem = New cItemFreeHandArea(oSurvey, oDesign, Me, Category)
                Case cIItem.cItemTypeEnum.FreeHandLine
                    oItem = New cItemFreeHandLine(oSurvey, oDesign, Me, Category)
                Case cIItem.cItemTypeEnum.InvertedFreeHandArea
                    oItem = New cItemInvertedFreeHandArea(oSurvey, oDesign, Me, Category)
            End Select
            If Not oItem Is Nothing Then
                Call oItems.Add(oItem)
            End If
            Return oItem
        End Function

        Friend Function CreateItem(ByVal Type As cIItem.cItemTypeEnum, ByVal Category As cIItem.cItemCategoryEnum, ByVal Data As Object, ByVal DataFormat As cItemClipart.cItemClipartDataFormatEnum) As cItem
            Dim oItem As cItem = Nothing
            Select Case Type
                Case cIItem.cItemTypeEnum.Generic
                    oItem = New cItemGeneric(oSurvey, oDesign, Me, Category, Data, DataFormat)
                Case cIItem.cItemTypeEnum.Clipart
                    oItem = New cItemClipart(oSurvey, oDesign, Me, Category, Data, DataFormat)
                Case cIItem.cItemTypeEnum.Sign
                    oItem = New cItemSign(oSurvey, oDesign, Me, Category, Data, DataFormat)
            End Select
            If Not oItem Is Nothing Then
                Call oItems.Add(oItem)
            End If
            Return oItem
        End Function

        Public ReadOnly Property Items() As cItems
            Get
                Return oItems
            End Get
        End Property

        Friend Overridable Function GetAllVisibleItems(PaintOptions As cOptions, ByVal CurrentCave As String, ByVal CurrentBranch As String) As List(Of cItem)
            Dim oResultItems As List(Of cItem) = New List(Of cItem)
            For Each oItem As cItem In GetAllVisibleItems(PaintOptions)
                If modDesign.GetIfItemMustBeDrawedByCaveAndBranch(PaintOptions, oItem, CurrentCave, CurrentBranch) Then
                    Call oResultItems.Add(oItem)
                End If
            Next
            Return oResultItems
        End Function

        Friend Overridable Function GetAllVisibleItems(PaintOptions As cOptions) As List(Of cItem)
            Dim oVisibleItems As List(Of cItem) = New List(Of cItem)
            Dim sCurrentProfile As String = PaintOptions.CurrentCaveVisibilityProfile
            If sCurrentProfile = "" Then
                For Each oItem As cItem In oItems
                    If modDesign.GetIfItemMustBeDrawedByHiddenFlag(PaintOptions, oItem) Then
                        Call oVisibleItems.Add(oItem)
                    End If
                Next
            Else
                Dim sItemsQuery As String = oSurvey.Properties.CaveVisibilityProfiles.GetItemsQuery(sCurrentProfile)
                If sItemsQuery = "" Then
                    For Each oItem As cItem In oItems
                        If oSurvey.Properties.CaveVisibilityProfiles.GetVisible(sCurrentProfile, oItem.Cave, oItem.Branch) Then
                            If modDesign.GetIfItemMustBeDrawedByHiddenFlag(PaintOptions, oItem) Then
                                Call oVisibleItems.Add(oItem)
                            End If
                        End If
                    Next
                Else
                    Try
                        Dim oQueryItems = From oItem As cItem In oItems.ToArray.AsQueryable.Where(sItemsQuery) Select oItem
                        For Each oItem As cItem In oQueryItems
                            If oSurvey.Properties.CaveVisibilityProfiles.GetVisible(sCurrentProfile, oItem.Cave, oItem.Branch) Then
                                If modDesign.GetIfItemMustBeDrawedByHiddenFlag(PaintOptions, oItem) Then
                                    Call oVisibleItems.Add(oItem)
                                End If
                            End If
                        Next
                    Catch 'ex As Exception
                        'MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Attenzione:")
                    End Try
                End If
            End If
            Return oVisibleItems
        End Function

        Friend Overridable Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Clipping As cClippingRegions, ByVal CurrentCave As String, ByVal CurrentBranch As String)
            Try
                Dim oItems As List(Of cItem) = GetAllVisibleItems(PaintOptions)
                If oItems.Count > 0 Then
                    Dim oVisibleBounds As RectangleF
                    Dim oBaseVisibleBounds As RectangleF = Graphics.VisibleClipBounds
                    Dim bTraslation As Boolean = Not PaintOptions.IsDesign And PaintOptions.DrawTranslation

                    Dim oCurrentItem As cItem = Nothing
                    Dim bCurrentItem As Boolean
                    Dim bCurrentItemIsInEdit As Boolean
                    If PaintOptions.IsDesign Then
                        oCurrentItem = oDesign.Tool.CurrentItem
                        bCurrentItemIsInEdit = oDesign.Tool.IsInEdit Or oDesign.Tool.IsInPointEdit Or oDesign.Tool.Started
                    End If

                    For Each oItem As cItem In oItems
                        If modDesign.GetIfItemMustBeDrawedByHiddenFlag(PaintOptions, oItem) Then
                            If modDesign.GetIfItemMustBeDrawedByCaveAndBranch(PaintOptions, oItem, CurrentCave, CurrentBranch) Then
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
                        End If
                    Next
                End If
            Catch ex As Exception
                Debug.Print("cLayer.Paint>" & ex.Message)
            End Try
        End Sub

        Public Overridable Function HitTest(ByVal PaintOptions As cOptions, ByVal CurrentCave As String, ByVal CurrentBranch As String, ByVal Point As PointF, ByVal Wide As Single, First As Boolean) As List(Of cItem)
            Dim oHitTestItems As List(Of cItem) = New List(Of cItem)
            If Not bHiddenInDesign Then
                Dim oReversedItems() As cItem = oItems.ToArray
                Call Array.Reverse(oReversedItems)
                For Each oItem As cItem In oReversedItems
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
    End Class
End Namespace