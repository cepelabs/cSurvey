Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings
Imports System.ComponentModel

Namespace cSurvey.Design.Items
    Public Class cItemLegend
        Inherits cItem
        Implements cIItemText
        Implements cIItemVerticalLineableText
        Implements cIItemLineableText
        Implements cIItemLegend

        Private oSurvey As cSurvey

        Private sText As String
        Private WithEvents oFont As cItemFont

        Private iTextSize As cIItemSizable.SizeEnum
        Private iTextVerticalAlignment As cIItemVerticalLineableText.TextVerticalAlignmentEnum
        Private iTextAlignment As cIItemLineableText.TextAlignmentEnum

        Private iItemAlignment As cIItemLegend.ItemAlignmentEnum
        Private iFlowDirection As cIItemLegend.FlowDirectionEnum
        Private iMaxItems As Integer

        Private sItemWidth As Single
        Private sItemHeight As Single

        Private sItemVPadding As Single
        Private sItemHPadding As Single

        Private sItemScale As Single

        Public Overrides ReadOnly Property HaveAffinity As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeCopied As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeHiddenInDesign As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeHiddenInPreview As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeLocked As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeSendedToOtherDesign As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeDeleted As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeReduced As Boolean
            Get
                Return False
            End Get
        End Property

        Public Property ItemAlignment As cIItemLegend.ItemAlignmentEnum Implements cIItemLegend.ItemAlignment
            Get
                Return iItemAlignment
            End Get
            Set(value As cIItemLegend.ItemAlignmentEnum)
                If iItemAlignment <> value Then
                    iItemAlignment = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property FlowDirection As cIItemLegend.FlowDirectionEnum Implements cIItemLegend.FlowDirection
            Get
                Return iFlowDirection
            End Get
            Set(value As cIItemLegend.FlowDirectionEnum)
                If iFlowDirection <> value Then
                    iFlowDirection = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property MaxItems As Integer Implements cIItemLegend.MaxItems
            Get
                Return iMaxItems
            End Get
            Set(value As Integer)
                If iMaxItems <> value Then
                    iMaxItems = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Overrides ReadOnly Property HaveTransparency As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeWarped As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeMoved As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HaveSketch As Boolean
            Get
                Return False
            End Get

        End Property
        Public Overrides ReadOnly Property HaveQuota As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveCrossSection As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveSplayBorder As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeConverted As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveSign As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveImage As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeClipped As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveText As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property BindMode As cItem.BindModeEnum
            Get
                Return BindModeEnum.CenterPoint
            End Get
        End Property

        Public Overrides Function GetBounds() As RectangleF
            If MyBase.Points.Count > 0 Then
                Dim oDesignBounds As RectangleF = MyBase.Caches.GetBounds
                If modPaint.IsRectangleEmpty(oDesignBounds) Then
                    Return MyBase.GetBounds()
                Else
                    Return oDesignBounds
                End If
            End If
        End Function

        Public Overrides ReadOnly Property HaveLineType As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveFont As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeRotated As Boolean
            Get
                Return False ' iTextRotateMode = TextRotateModeEnum.Rotable
            End Get
        End Property

        Public Overrides ReadOnly Property HaveEditablePoints As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveBrush As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HavePen As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property MaxPointsCount As Integer
            Get
                Return 1
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeResized() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeDivided() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeCombined() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeBinded() As Boolean
            Get
                Return True
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum, ByVal Text As String)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.Legend, Category)
            oSurvey = Survey
            oItems = New List(Of cLegendItem)
            oFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.Generic)
            sText = "" & Text
            iTextSize = cIItemSizable.SizeEnum.Default
            iTextAlignment = cIItemLineableText.TextAlignmentEnum.Left
            iTextVerticalAlignment = cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle
            iItemAlignment = cIItemLegend.ItemAlignmentEnum.Left
            iFlowDirection = cIItemLegend.FlowDirectionEnum.Vertical
            iMaxItems = 8
            sItemWidth = 5
            sItemHeight = 0.5
            sItemVPadding = 0.1
            sItemHPadding = 0.1
            sItemScale = 1

            MyBase.DesignAffinity = DesignAffinityEnum.Extra
        End Sub

        Friend Overrides Function GetTextScaleFactor(PaintOptions As cOptionsCenterline) As Single
            Dim sTextScaleFactor As Single = MyBase.GetTextScaleFactor(PaintOptions)
            Select Case iTextSize
                Case cIItemSizable.SizeEnum.Default
                    Return 1 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.VerySmall
                    Return 0.25 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.Small
                    Return 0.5 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.Medium
                    Return 1 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.Large
                    Return 2 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.VeryLarge
                    Return 4 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x6
                    Return 6 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x8
                    Return 8 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x10
                    Return 10 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x12
                    Return 12 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x16
                    Return 16 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x20
                    Return 20 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x24
                    Return 24 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x32
                    Return 32 * sTextScaleFactor
            End Select
        End Function

        'Friend Overrides Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
        '    Using oMatrix As Matrix = New Matrix
        '        If PaintOptions.DrawTranslation Then
        '            Dim oTranslation As SizeF = MyBase.Design.GetItemTranslation(Me)
        '            Call oMatrix.Translate(oTranslation.Width, oTranslation.Height)
        '        End If
        '        Dim oSVGItem As XmlElement = MyBase.Caches(PaintOptions).ToSvgItem(SVG, PaintOptions, Options, oMatrix)
        '        If MyBase.Name <> "" Then Call oSVGItem.SetAttribute("name", MyBase.Name)
        '        Return oSVGItem
        '    End Using
        'End Function

        Public Overrides Sub ResizeTo(ByVal Size As SizeF)
            Call ResizeTo(Size.Width, Size.Height)
        End Sub

        Public Overrides Sub ResizeBy(ByVal Size As SizeF)
            Call ResizeBy(Size.Width, Size.Height)
        End Sub

        'Friend Overrides Function ToSvg(ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlDocument
        '    Dim oSVG As XmlDocument = modSVG.CreateSVG
        '    Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions, Options))
        '    Return oSVG
        'End Function

        Public Class cLegendItem
            Public Enum ItemTypeEnum
                <Description("Line")>
                LineItem = 0
                <Description("Area")>
                AreaItem = 1
                <Description("Sign")>
                SignItem = 2
            End Enum

            Private sText As String
            Private iType As ItemTypeEnum
            Private sScale As Single
            Private ilayerIndex As Integer
            Private iItemIndex As Integer
            Private oItem As cItem

            Friend Event ResolveItem(Sender As Object, e As ResolveItemEventArgs)
            Friend Event OnChanged(Sender As Object, e As EventArgs)

            Public Sub CopyFrom(ByVal Item As cLegendItem)
                sText = Item.sText
                Type = Item.iType
                sScale = Item.sScale
                ilayerIndex = Item.ilayerIndex
                iItemIndex = Item.iItemIndex
            End Sub

            Friend Class ResolveItemEventArgs
                Inherits EventArgs

                Private ilayerIndex As cLayers.LayerTypeEnum
                Private iItemIndex As Integer
                Public Item As cItem

                Public ReadOnly Property LayerIndex As Integer
                    Get
                        Return ilayerIndex
                    End Get
                End Property

                Public ReadOnly Property ItemIndex As Integer
                    Get
                        Return iItemIndex
                    End Get
                End Property

                Public Sub New(layerIndex As cLayers.LayerTypeEnum, ItemIndex As Integer)
                    ilayerIndex = layerIndex
                    iItemIndex = ItemIndex
                End Sub
            End Class

            Public ReadOnly Property Item As cItem
                Get
                    If iItemIndex >= 0 Then
                        Dim oArgs As ResolveItemEventArgs = New ResolveItemEventArgs(ilayerIndex, iItemIndex)
                        RaiseEvent ResolveItem(Me, oArgs)
                        iItemIndex = -1
                        oItem = oArgs.Item
                    End If
                    Return oItem
                End Get
            End Property

            Public Property Scale As Single
                Get
                    Return sScale
                End Get
                Set(value As Single)
                    If sScale <> value Then
                        sScale = value
                        RaiseEvent OnChanged(Me, New EventArgs)
                    End If
                End Set
            End Property

            Public Property Text As String
                Get
                    Return sText
                End Get
                Set(value As String)
                    If sText <> value Then
                        sText = value
                        RaiseEvent OnChanged(Me, New EventArgs)
                    End If
                End Set
            End Property

            Public Property Type As ItemTypeEnum
                Get
                    Return iType
                End Get
                Set(value As ItemTypeEnum)
                    If iType <> value Then
                        iType = value
                        RaiseEvent OnChanged(Me, New EventArgs)
                    End If
                End Set
            End Property

            Public Sub New(Item As cItem, Type As ItemTypeEnum, Optional Text As String = "", Optional Scale As Single = 1)
                oItem = Item
                iItemIndex = -1
                ilayerIndex = -1
                iType = Type
                sText = Text
                sScale = 1
            End Sub

            Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal item As XmlElement)
                sText = modXML.GetAttributeValue(item, "text", "")
                iType = modXML.GetAttributeValue(item, "type")
                sScale = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "scale", 1))
                ilayerIndex = modXML.GetAttributeValue(item, "l")
                iItemIndex = modXML.GetAttributeValue(item, "i")
            End Sub

            Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
                Dim oXMLItem As XmlElement = Document.CreateElement("item")
                Call oXMLItem.SetAttribute("text", "" & sText)
                Call oXMLItem.SetAttribute("type", iType.ToString("D"))
                If sScale <> 1 Then Call oXMLItem.SetAttribute("scale", modNumbers.NumberToString(sScale, "0.00"))
                Call oXMLItem.SetAttribute("l", oItem.Layer.Type.ToString("D"))
                Call oXMLItem.SetAttribute("i", oItem.Layer.Items.IndexOf(oItem))
                Call Parent.AppendChild(oXMLItem)
                Return oXMLItem
            End Function
        End Class

        Private Sub oitem_resolveitem(Sender As Object, e As cLegendItem.ResolveItemEventArgs)
            Try
                e.Item = MyBase.Design.Layers(e.LayerIndex).Items.Item(e.ItemIndex)
            Catch ex As Exception
            End Try
        End Sub

        Private Sub oitem_onchanged(Sender As Object, e As EventArgs)
            Call MyBase.Caches.Invalidate()
        End Sub

        Private oItems As List(Of cLegendItem)

        Public Sub AddItemRange(Items As List(Of cItem), Type As cLegendItem.ItemTypeEnum) Implements cIItemLegend.AddItemRange
            For Each oItem As cItem In Items
                Call AddItem(oItem, Type, "{" & oItem.Name & "}")
            Next
        End Sub

        Public Sub ClearItems()
            Call oItems.Clear()
            Call MyBase.Caches.Invalidate()
        End Sub

        Public Sub RemoveItem(Index As Integer)
            If Index >= 0 And Index < oItems.Count Then
                Call oItems.RemoveAt(Index)
                Call MyBase.Caches.Invalidate()
            End If
        End Sub

        Public Sub RemoveItem(Item As cItem)
            Call oItems.RemoveAll(Function(oItem) oItem.Item Is Item)
            Call MyBase.Caches.Invalidate()
        End Sub

        Public Sub RemoveItem(Item As cLegendItem)
            If oItems.Contains(Item) Then
                Call oItems.Remove(Item)
                Call MyBase.Caches.Invalidate()
            End If
        End Sub

        Public Sub MoveItem(Item As cLegendItem, NewIndex As Integer)
            If oItems.Contains(Item) Then
                Call oItems.Remove(Item)
                If NewIndex < 0 Then
                    Call oItems.Insert(0, Item)
                Else
                    If NewIndex >= oItems.Count Then
                        Call oItems.Add(Item)
                    Else
                        Call oItems.Insert(NewIndex, Item)
                    End If
                End If
            End If
        End Sub

        Public Function AddItem(Item As cItem) As cLegendItem Implements cIItemLegend.AddItem
            If TypeOf Item Is cIItemClipartBase Then
                Dim sName As String = Item.Name
                If sName = "" Then
                    If TypeOf Item Is cItemClipart Then
                        sName = Item.Category.ToString
                    ElseIf TypeOf Item Is cItemSign Then
                        sName = DirectCast(Item, cItemSign).Sign.ToString
                    End If
                End If
                Return AddItem(Item, cLegendItem.ItemTypeEnum.SignItem, sName)
            ElseIf Item.HaveBrush Then
                Return AddItem(Item, cLegendItem.ItemTypeEnum.AreaItem, Item.Brush.Name)
            ElseIf Item.HavePen Then
                Return AddItem(Item, cLegendItem.ItemTypeEnum.LineItem, Item.Pen.Name)
            End If
        End Function

        Public Function ContainsItem(Item As cItem) As Boolean
            Return oItems.Exists(Function(oItem) oItem.Item Is Item)
        End Function

        Public Function ValidateItem(Item As cItem) As Boolean Implements cIItemLegend.ValidateItem
            If TypeOf Item Is cIItemClipartBase Then
                Return True
            ElseIf TypeOf Item Is cIItemLegend Then
                Return False
            ElseIf TypeOf Item Is cIItemCrossSection Then
                Return False
            ElseIf Item.HaveBrush Then
                Return True
            ElseIf Item.HavePen Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function AddItem(Item As cItem, Type As cLegendItem.ItemTypeEnum, Text As String) As cLegendItem Implements cIItemLegend.AddItem
            Dim oItem As cLegendItem = New cLegendItem(Item, Type, Text)
            AddHandler oItem.OnChanged, AddressOf oitem_onchanged
            AddHandler oItem.ResolveItem, AddressOf oitem_resolveitem
            Call oItems.Add(oItem)
            Call MyBase.Caches.Invalidate()
            Return oItem
        End Function

        Public Sub AutoFill(Append As Boolean, Flags As cIItemLegend.AutoFillFlagsEnum) Implements cIItemLegend.AutoFill
            Dim oPenList As List(Of cPen.PenTypeEnum) = New List(Of cPen.PenTypeEnum)
            Dim oBrushList As List(Of cBrush.BrushTypeEnum) = New List(Of cBrush.BrushTypeEnum)
            Dim oClipartList As List(Of String) = New List(Of String)
            Dim oNames As List(Of String) = New List(Of String)

            If Append Then
                For Each oItem As cLegendItem In oItems
                    If Not IsNothing(oItem) AndAlso Not IsNothing(oItem.Item) Then
                        If oItem.Item.HavePen AndAlso oItem.Item.Pen IsNot Nothing Then
                            Dim iPenType As cPen.PenTypeEnum = oItem.Item.Pen.Type
                            If oItem.Type = cLegendItem.ItemTypeEnum.LineItem AndAlso (Not oPenList.Contains(iPenType) OrElse iPenType = cPen.PenTypeEnum.Custom) Then
                                Call oPenList.Add(iPenType)
                                Dim sName As String = oItem.Item.Pen.Name   'some doubt...name for custom is not editable...may be better use item name?
                                If Not oNames.Contains(sName.ToLower) Then Call oNames.Add(sName.ToLower)
                            End If
                        End If
                        If oItem.Item.HaveBrush AndAlso oItem.Item.Brush IsNot Nothing Then
                            Dim iBrushType As cBrush.BrushTypeEnum = oItem.Item.Brush.Type
                            If oItem.Type = cLegendItem.ItemTypeEnum.AreaItem AndAlso (Not oBrushList.Contains(iBrushType) OrElse iBrushType = cPen.PenTypeEnum.Custom) Then
                                Call oBrushList.Add(oItem.Item.Brush.Type)
                                Dim sName As String = oItem.Item.Brush.Name
                                If Not oNames.Contains(sName.ToLower) Then Call oNames.Add(sName.ToLower)
                            End If
                        End If
                        If oItem.Type = cLegendItem.ItemTypeEnum.SignItem Then
                            Dim sClipartID As String = DirectCast(oItem.Item, cIItemClipartBase).Clipart.ID
                            If Not oClipartList.Contains(sClipartID) Then Call oClipartList.Add(sClipartID)
                            Dim sName As String = oItem.Item.Name
                            If sName = "" Then
                                If TypeOf oItem.Item Is cItemClipart Then
                                    sName = oItem.Item.Category.ToString
                                ElseIf TypeOf oItem.Item Is cItemSign Then
                                    sName = "" & [Enum].GetName(GetType(cIItemSign.SignEnum), DirectCast(oItem.Item, cItemSign).Sign)
                                    If sName = "" Then
                                        sName = DirectCast(oItem.Item, cItemSign).Sign.ToString
                                    End If
                                End If
                                If Not oNames.Contains(sName.ToLower) Then Call oNames.Add(sName.ToLower)
                            End If
                        End If
                    End If
                Next
            Else
                Call oItems.Clear()
            End If

            For Each oLayer As cLayer In MyBase.Design.Layers.Where(Function(layer) Not (layer.Type = cLayers.LayerTypeEnum.RocksAndConcretion)) 'OrElse layer.Type = cLayers.LayerTypeEnum.Signs))
                For Each oItem As cItem In oLayer.Items
                    If Not oItem.HiddenInDesign AndAlso Not oItem.HiddenInPreview AndAlso Not TypeOf oItem Is cItemLegend Then
                        If oItem.HavePen Then
                            Dim iPenType As cPen.PenTypeEnum = oItem.Pen.Type
                            If iPenType <> cPen.PenTypeEnum.None AndAlso Not (oItem.Layer.Type = cLayers.LayerTypeEnum.Signs And iPenType = cPen.PenTypeEnum.TightPen) Then
                                If Not oPenList.Contains(iPenType) OrElse iPenType = cPen.PenTypeEnum.Custom Then
                                    Dim sName As String = oItem.Pen.Name
                                    If ((Flags And cIItemLegend.AutoFillFlagsEnum.AllowDuplicatedNames) = cIItemLegend.AutoFillFlagsEnum.AllowDuplicatedNames) OrElse ((Flags And cIItemLegend.AutoFillFlagsEnum.AllowDuplicatedNames) = 0 AndAlso Not oNames.Contains(sName.ToLower)) Then
                                        Call AddItem(oItem, cLegendItem.ItemTypeEnum.LineItem, sName)
                                        If Not oNames.Contains(sName.ToLower) Then Call oNames.Add(sName.ToLower)
                                        If iPenType <> cPen.PenTypeEnum.Custom Then oPenList.Add(iPenType)
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next
            Next

            For Each oLayer As cLayer In MyBase.Design.Layers.Where(Function(layer) Not (layer.Type = cLayers.LayerTypeEnum.RocksAndConcretion)) 'OrElse layer.Type = cLayers.LayerTypeEnum.Signs))
                For Each oItem As cItem In oLayer.Items
                    If Not oItem.HiddenInDesign AndAlso Not oItem.HiddenInPreview AndAlso Not TypeOf oItem Is cItemLegend Then
                        If oItem.HaveBrush Then
                            Dim iBrushType As cBrush.BrushTypeEnum = oItem.Brush.Type
                            If iBrushType <> cBrush.BrushTypeEnum.None AndAlso Not (oItem.Layer.Type = cLayers.LayerTypeEnum.Signs And iBrushType = cBrush.BrushTypeEnum.SignSolid) Then
                                If Not oBrushList.Contains(iBrushType) OrElse iBrushType = cBrush.BrushTypeEnum.Custom Then
                                    Dim sName As String = oItem.Brush.Name
                                    If ((Flags And cIItemLegend.AutoFillFlagsEnum.AllowDuplicatedNames) = cIItemLegend.AutoFillFlagsEnum.AllowDuplicatedNames) OrElse ((Flags And cIItemLegend.AutoFillFlagsEnum.AllowDuplicatedNames) = 0 AndAlso Not oNames.Contains(sName.ToLower)) Then
                                        Call AddItem(oItem, cLegendItem.ItemTypeEnum.AreaItem, sName)
                                        If Not oNames.Contains(sName.ToLower) Then Call oNames.Add(sName.ToLower)
                                        If iBrushType <> cBrush.BrushTypeEnum.Custom Then oBrushList.Add(iBrushType)
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next
            Next

            For Each oLayer As cLayer In MyBase.Design.Layers.Where(Function(layer) layer.Type = cLayers.LayerTypeEnum.RocksAndConcretion OrElse layer.Type = cLayers.LayerTypeEnum.Signs)
                For Each oItem As cItem In oLayer.Items
                    If Not oItem.HiddenInDesign AndAlso Not oItem.HiddenInPreview AndAlso Not TypeOf oItem Is cItemLegend Then
                        If TypeOf oItem Is cIItemClipartBase Then
                            Dim oItemClipart As cIItemClipartBase = oItem
                            If Not oClipartList.Contains(oItemClipart.Clipart.ID) Then
                                Dim sName As String = oItem.Name
                                If sName = "" Then
                                    If TypeOf oItem Is cItemClipart Then
                                        sName = oItem.Category.ToString
                                    ElseIf TypeOf oItem Is cItemSign Then
                                        sName = "" & [Enum].GetName(GetType(cIItemSign.SignEnum), DirectCast(oItem, cItemSign).Sign)
                                        If sName = "" Then
                                            sName = DirectCast(oItem, cItemSign).Sign.ToString
                                        End If
                                    End If
                                End If
                                If ((Flags And cIItemLegend.AutoFillFlagsEnum.AllowDuplicatedNames) = cIItemLegend.AutoFillFlagsEnum.AllowDuplicatedNames) OrElse ((Flags And cIItemLegend.AutoFillFlagsEnum.AllowDuplicatedNames) = 0 AndAlso Not oNames.Contains(sName.ToLower)) Then
                                    Call AddItem(oItem, cLegendItem.ItemTypeEnum.SignItem, sName)
                                    If Not oNames.Contains(sName.ToLower) Then Call oNames.Add(sName.ToLower)
                                    Call oClipartList.Add(oItemClipart.Clipart.ID)
                                End If
                            End If
                        End If
                    End If
                Next
            Next
        End Sub

        Public ReadOnly Property Items As List(Of cLegendItem) Implements cIItemLegend.Items
            Get
                Return oItems
            End Get
        End Property

        Public Property ItemHPadding() As Single Implements cIItemLegend.ItemHPadding
            Get
                Return sItemHPadding
            End Get
            Set(ByVal Value As Single)
                If sItemHPadding <> Value Then
                    sItemHPadding = Value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property ItemVPadding() As Single Implements cIItemLegend.ItemVPadding
            Get
                Return sItemVPadding
            End Get
            Set(ByVal Value As Single)
                If sItemVPadding <> Value Then
                    sItemVPadding = Value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property ItemScale() As Single Implements cIItemLegend.ItemScale
            Get
                Return sItemScale
            End Get
            Set(ByVal Value As Single)
                If sItemScale <> Value Then
                    sItemScale = Value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property ItemHeight() As Single Implements cIItemLegend.ItemHeight
            Get
                Return sItemHeight
            End Get
            Set(ByVal Value As Single)
                If sItemHeight <> Value Then
                    sItemHeight = Value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property ItemWidth() As Single Implements cIItemLegend.ItemWidth
            Get
                Return sItemWidth
            End Get
            Set(ByVal Value As Single)
                If sItemWidth <> Value Then
                    sItemWidth = Value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Friend Overrides Sub Render(ByVal Graphics As System.Drawing.Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            Dim oCache As cDrawCache = MyBase.Caches(PaintOptions)
            With oCache
                If .Invalidated Then
                    Call .Clear()

                    Dim sScale As Single = GetTextScaleFactor(PaintOptions)

                    Dim oBasePoint As PointF = MyBase.Points(0).Point
                    Dim sItemLeft As Single = 0 'ìoBasePoint.X
                    Dim sItemTop As Single = 0 'oBasePoint.Y
                    Dim sItemItemTop As Single = sItemTop
                    Dim sItemItemleft As Single = sItemLeft
                    Dim sItemItemWidth As Single = sItemWidth * sScale * 20  'parameters???
                    Dim sItemItemHeight As Single = sItemHeight * sScale * 20

                    Dim sItemItemVPadding As Single = sItemVPadding * sScale * 20
                    Dim sItemItemHPadding As Single = sItemHPadding * sScale * 20

                    If sText <> "" Then
                        Using oSF As StringFormat = New StringFormat
                            oSF.LineAlignment = StringAlignment.Near
                            oSF.Alignment = StringAlignment.Near
                            oSF.FormatFlags = StringFormatFlags.NoClip
                            Using oTextPath As GraphicsPath = New GraphicsPath
                                Using oScaleMatrix = New Matrix
                                    Call oFont.AddToPath(PaintOptions, oTextPath, modPaint.ReplaceGlobalTags(oSurvey, sText), New Point(0, 0), oSF)
                                    Call oScaleMatrix.Scale(sScale, sScale, MatrixOrder.Append)
                                    Call oTextPath.Transform(oScaleMatrix)
                                End Using
                                Using oTranslateMatrix = New Matrix
                                    Call oTranslateMatrix.Translate(sItemLeft, sItemTop, MatrixOrder.Append)
                                    Call oTextPath.Transform(oTranslateMatrix)
                                End Using
                                Call oFont.Render(Graphics, PaintOptions, Options, oTextPath, oCache)
                                sItemItemTop += oTextPath.GetBounds.Height + sItemVPadding * 2
                                sItemTop = sItemItemTop
                            End Using
                        End Using
                    End If

                    Dim oBorderPen As cCustomPen = oSurvey.Pens.GenericPen

                    Dim iIndex As Integer = 0
                    SyncLock oItems
                        For Each oItem As cLegendItem In oItems
                            If modDesign.GetIfItemMustBeDrawedByHiddenFlag(PaintOptions, oItem.Item) Then
                                Dim sItemItemScale As Single = oItem.Scale * sItemScale
                                Dim oBordersBounds As RectangleF
                                If iItemAlignment = cIItemLegend.ItemAlignmentEnum.Left Then
                                    oBordersBounds = New RectangleF(sItemLeft, sItemTop, sItemItemHeight, sItemItemHeight)
                                Else
                                    oBordersBounds = New RectangleF(sItemLeft + sItemItemWidth - sItemItemHeight, sItemTop, sItemItemHeight, sItemItemHeight)
                                End If
                                Using oClippingPath As GraphicsPath = New GraphicsPath
                                    Call oClippingPath.AddRectangle(oBordersBounds)
                                    Call oCache.AddSetClip(oClippingPath)
                                    If oItem.Type = cLegendItem.ItemTypeEnum.LineItem AndAlso oItem.Item.HavePen Then
                                        Dim oPen As cPen = oItem.Item.Pen
                                        If Not IsNothing(oPen) Then
                                            Using oDesignPen As cCustomPen = New cCustomPen(oSurvey, oPen)
                                                oDesignPen.LocalLineWidth = oPen.GetBasePen.GetPaintLineWidth(PaintOptions) * sItemItemScale
                                                oDesignPen.LocalZoomFactor = oPen.GetBasePen.GetPaintZoomFactor(PaintOptions) * sItemItemScale
                                                Using oPath As GraphicsPath = New GraphicsPath
                                                    Dim oP0 As PointF = New PointF(oBordersBounds.Left, oBordersBounds.Top + oBordersBounds.Height * 2 / 3)
                                                    Dim oP1 As PointF = New PointF(oBordersBounds.Right, oBordersBounds.Top + oBordersBounds.Height * 1 / 3)
                                                    Call oPath.AddLine(oP0, oP1)
                                                    Call oDesignPen.Render(PaintOptions, Options, False, oPath, oCache)
                                                End Using
                                            End Using
                                        End If
                                    ElseIf oItem.Type = cLegendItem.ItemTypeEnum.AreaItem AndAlso oItem.Item.HaveBrush Then
                                        Dim oBrush As cCustomBrush = oItem.Item.Brush.GetBaseBrush
                                        If Not IsNothing(oBrush) Then
                                            Using oDesignBrush As cCustomBrush = New cCustomBrush(oSurvey)
                                                Call oDesignBrush.CopyFrom(oBrush)
                                                oDesignBrush.LocalLineWidth = oDesignBrush.GetPaintLineWidth(PaintOptions) * sItemItemScale
                                                oDesignBrush.LocalZoomFactor = oDesignBrush.GetPaintZoomFactor(PaintOptions) * sItemItemScale
                                                oDesignBrush.ClipartCrop = cBrush.ClipartCropEnum.None
                                                Using oPath As GraphicsPath = New GraphicsPath
                                                    Call oPath.AddPolygon({New PointF(oBordersBounds.X, oBordersBounds.Y), New PointF(oBordersBounds.Right, oBordersBounds.Y), New PointF(oBordersBounds.Right, oBordersBounds.Bottom), New PointF(oBordersBounds.X, oBordersBounds.Bottom), New PointF(oBordersBounds.X, oBordersBounds.Y)})
                                                    Call oDesignBrush.Render(Graphics, PaintOptions, Options, False, oPath, oCache)
                                                End Using
                                            End Using
                                        End If
                                    ElseIf oItem.Type = cLegendItem.ItemTypeEnum.SignItem AndAlso TypeOf oItem.Item Is cIItemClipartBase Then
                                        Dim oSign As cClipart = DirectCast(oItem.Item, cIItemClipartBase).Clipart
                                        If Not IsNothing(oSign) Then
                                            Using oDesignSignPaths As cDrawPaths = oSign.Clipart.ClonePaths
                                                Using oScaleMatrix As Matrix = New Matrix
                                                    Dim oOriginalBounds As RectangleF = oDesignSignPaths.GetBounds()
                                                    If sItemItemScale <> 1 Then oOriginalBounds = modPaint.FullScaleRectangle(oOriginalBounds, 1.0F / sItemItemScale)
                                                    Dim oPaddedBounds As RectangleF = oBordersBounds
                                                    Call oPaddedBounds.Inflate(-0.1, -0.1)
                                                    Dim sClipScale As Single = modPaint.ScaleToFit(oPaddedBounds, oOriginalBounds)
                                                    oOriginalBounds = modPaint.FullScaleRectangle(oOriginalBounds, sClipScale)
                                                    Dim sOffsetX As Single = oPaddedBounds.X - oOriginalBounds.X + oPaddedBounds.Width / 2.0F - oOriginalBounds.Width / 2.0F
                                                    Dim sOffsetY As Single = oPaddedBounds.Y - oOriginalBounds.Y + oPaddedBounds.Height / 2.0F - oOriginalBounds.Height / 2.0F

                                                    Call oScaleMatrix.Scale(sClipScale, sClipScale, MatrixOrder.Append)
                                                    Call oScaleMatrix.Translate(sOffsetX, sOffsetY, MatrixOrder.Append)
                                                    Call oDesignSignPaths.Transform(oScaleMatrix)
                                                End Using
                                                Call oDesignSignPaths.Render(oItem.Item, Graphics, PaintOptions, Options, Selected, oCache)
                                            End Using
                                        End If
                                    End If
                                    Call oCache.AddResetclip()
                                End Using

                                Using oBordersPath As GraphicsPath = New GraphicsPath
                                    Call oBordersPath.AddRectangle(oBordersBounds)
                                    Call oBorderPen.Render(PaintOptions, Options, False, oBordersPath, oCache)
                                End Using

                                Using oSF As StringFormat = New StringFormat
                                    Dim oTextBounds As RectangleF
                                    oSF.LineAlignment = StringAlignment.Center
                                    If iItemAlignment = cIItemLegend.ItemAlignmentEnum.Left Then
                                        oSF.Alignment = StringAlignment.Near
                                        oTextBounds = New RectangleF(sItemLeft + sItemItemHeight, sItemTop, sItemItemWidth - sItemItemHeight, sItemItemHeight)
                                    Else
                                        oSF.Alignment = StringAlignment.Far
                                        oTextBounds = New RectangleF(sItemLeft, sItemTop, sItemItemWidth - sItemItemHeight, sItemItemHeight)
                                    End If
                                    oSF.FormatFlags = StringFormatFlags.NoClip
                                    Using oTextPath As GraphicsPath = New GraphicsPath
                                        Using oScaleMatrix = New Matrix
                                            Dim oTextScaledBounds As RectangleF = modPaint.FullScaleRectangle(oTextBounds, 1.0 / sScale, 1.0 / sScale)
                                            Call oFont.AddToPath(PaintOptions, oTextPath, modPaint.ReplaceGlobalTags(oSurvey, oItem.Text), oTextScaledBounds, oSF)
                                            Call oScaleMatrix.Scale(sScale, sScale, MatrixOrder.Append)
                                            Call oTextPath.Transform(oScaleMatrix)
                                        End Using
                                        Call oFont.Render(Graphics, PaintOptions, Options, oTextPath, oCache)
                                    End Using
                                End Using

                                iIndex += 1
                                Select Case iFlowDirection
                                    Case cIItemLegend.FlowDirectionEnum.Vertical
                                        If iIndex Mod iMaxItems = 0 Then
                                            sItemLeft += sItemItemWidth + sItemItemHPadding
                                            sItemTop = sItemItemTop
                                        Else
                                            sItemTop += sItemItemHeight + sItemItemVPadding
                                        End If
                                    Case cIItemLegend.FlowDirectionEnum.Horizontal
                                        If iIndex Mod iMaxItems = 0 Then
                                            sItemTop += sItemItemHeight + sItemItemVPadding
                                            sItemLeft = sItemItemleft
                                        Else
                                            sItemLeft += sItemItemWidth + sItemItemHPadding
                                        End If
                                End Select
                            End If
                        Next
                    End SyncLock

                    Dim sY As Single
                    Dim sX As Single
                    Select Case iTextAlignment
                        Case cIItemLineableText.TextAlignmentEnum.Center
                            sX = oBasePoint.X - oCache.GetBounds.Width / 2
                        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
                            sX = oBasePoint.X - oCache.GetBounds.Right
                        Case Else
                            sX = oBasePoint.X
                    End Select
                    Select Case iTextVerticalAlignment
                        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle
                            sY = oBasePoint.Y - oCache.GetBounds.Height / 2
                        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
                            sY = oBasePoint.Y - oCache.GetBounds.Height
                        Case Else
                            sY = oBasePoint.Y
                    End Select
                    Using oTraslateMatix As Matrix = New Matrix
                        Call oTraslateMatix.Translate(sX, sY)
                        Call oCache.Trasform(oTraslateMatix)
                    End Using

                    Call .Rendered()
                End If
            End With
        End Sub

        Friend Overrides Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            If MyBase.Points.Count > 0 Then
                Call Render(Graphics, PaintOptions, Options, Selected)
                If Not PaintOptions.IsDesign OrElse (PaintOptions.IsDesign And Not MyBase.HiddenInDesign) Then '
                    MyBase.HavePaintProblem = Not MyBase.Caches(PaintOptions).Paint(Graphics, PaintOptions, Options)
                    If PaintOptions.ShowSegmentBindings Then
                        Call modPaint.PaintPointToSegmentBindings(Graphics, oSurvey, Me, Selected)
                    End If
                End If
            End If
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As cFile, ByVal item As XmlElement)
            Call MyBase.New(Survey, Design, Layer, File, item)
            oSurvey = Survey
            oItems = New List(Of cLegendItem)
            sText = modXML.GetAttributeValue(item, "text", "")
            Try
                oFont = New cItemFont(oSurvey, item.Item("font"))
            Catch ex As Exception
                oFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.Generic)
            End Try
            iTextSize = modXML.GetAttributeValue(item, "textsize")
            iTextAlignment = modXML.GetAttributeValue(item, "textalignment", cIItemLineableText.TextAlignmentEnum.Center)
            iTextVerticalAlignment = modXML.GetAttributeValue(item, "textverticalalignment", cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle)
            iMaxItems = modXML.GetAttributeValue(item, "maxitems", 8)
            iFlowDirection = modXML.GetAttributeValue(item, "flowdirection", cIItemLegend.FlowDirectionEnum.Vertical)

            For Each oChildItem As XmlElement In item("legenditems").ChildNodes
                Dim oLegendItem As cLegendItem = New cLegendItem(Survey, File, oChildItem)
                AddHandler oLegendItem.OnChanged, AddressOf oitem_onchanged
                AddHandler oLegendItem.ResolveItem, AddressOf oitem_resolveitem
                Call oItems.Add(oLegendItem)
            Next

            sItemWidth = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "itemwidth", 5))
            sItemHeight = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "itemheight", 0.5))
            sItemVPadding = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "itemvpadding", 0.1))
            sItemHPadding = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "itemhpadding", 0.1))
            iItemAlignment = modXML.GetAttributeValue(item, "itemalignment", cIItemLegend.ItemAlignmentEnum.Left)

            sItemScale = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "itemscale", 1))
        End Sub

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oItem As XmlElement = MyBase.SaveTo(File, Document, Parent, Options)
            If "" & sText <> "" Then Call oItem.SetAttribute("text", "" & sText)
            Call oFont.SaveTo(File, Document, oItem, "font")
            If iTextSize <> cIItemSizable.SizeEnum.Default Then
                Call oItem.SetAttribute("textsize", iTextSize)
            End If
            If iTextAlignment <> cIItemLineableText.TextAlignmentEnum.Center Then
                Call oItem.SetAttribute("textalignment", iTextAlignment)
            End If
            If iTextVerticalAlignment <> cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle Then
                Call oItem.SetAttribute("textverticalalignment", iTextVerticalAlignment)
            End If
            If iMaxItems <> 8 Then Call oItem.SetAttribute("maxitems", iMaxItems)
            If iFlowDirection <> cIItemLegend.FlowDirectionEnum.Vertical Then Call oItem.SetAttribute("flowdirection", iFlowDirection.ToString("D"))

            Dim oLegendItems As XmlElement = Document.CreateElement("legenditems")
            For Each oLegendItem As cLegendItem In oItems
                If Not IsNothing(oLegendItem.Item) AndAlso Not oLegendItem.Item.Deleted Then
                    Call oLegendItem.SaveTo(File, Document, oLegendItems, Options)
                End If
            Next

            If sItemWidth <> 5 Then Call oItem.SetAttribute("itemwidth", modNumbers.NumberToString(sItemWidth, "0.00"))
            If sItemHeight <> 0.5 Then Call oItem.SetAttribute("itemheight", modNumbers.NumberToString(sItemHeight, "0.00"))
            If sItemVPadding <> 0.1 Then Call oItem.SetAttribute("itemvpadding", modNumbers.NumberToString(sItemVPadding, "0.00"))
            If sItemHPadding <> 0.1 Then Call oItem.SetAttribute("itemhpadding", modNumbers.NumberToString(sItemHPadding, "0.00"))
            If iItemAlignment <> cIItemLegend.ItemAlignmentEnum.Left Then Call oItem.SetAttribute("itemalignment", iItemAlignment.ToString("D"))

            If sItemScale <> 1 Then Call oItem.SetAttribute("itemscale", modNumbers.NumberToString(sItemScale, "0.00"))

            Call oItem.AppendChild(oLegendItems)
            Return oItem
        End Function

        Public Property TextSize() As cIItemSizable.SizeEnum Implements cIItemSizable.Size
            Get
                Return iTextSize
            End Get
            Set(ByVal value As cIItemSizable.SizeEnum)
                If iTextSize <> value Then
                    iTextSize = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property Text As String Implements cIItemText.Text
            Get
                Return sText
            End Get
            Set(ByVal value As String)
                If value <> sText Then
                    sText = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public ReadOnly Property Font As cItemFont Implements cIItemText.Font
            Get
                Return oFont
            End Get
        End Property

        Friend Overrides Sub BindSegments()
            If MyBase.Cave = "" Then
                For Each oPoint As cPoint In MyBase.Points
                    oPoint.SegmentLocked = False
                    Call oPoint.BindSegment(Nothing)
                Next
            Else
                Dim oCenterPoint As PointF = GetCenterPoint()
                Dim oSegment As cISegment = MyBase.Design.GetNearestSegment(MyBase.Cave, MyBase.Branch, MyBase.CrossSection, oCenterPoint.X, oCenterPoint.Y, MyBase.BindDesignType)
                For Each oPoint As cPoint In MyBase.Points
                    If Not oPoint.SegmentLocked Then
                        Call oPoint.BindSegment(oSegment)
                    End If
                Next
            End If
        End Sub

        Public Overrides ReadOnly Property CanImportGeneric As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Function FromGeneric(ByVal Item As cItemGeneric, Optional ByVal Clear As Boolean = False) As Boolean
            Return False
        End Function

        Private Sub oFont_OnChanged(ByVal Sender As cItemFont) Handles oFont.OnChanged
            Call MyBase.Caches.Invalidate()
        End Sub

        Public Overrides Property Transparency As Single
            Get
                Return MyBase.Transparency
            End Get
            Set(value As Single)
                If MyBase.Transparency <> value Then
                    MyBase.Transparency = value
                    Call oFont.Invalidate()
                End If
            End Set
        End Property

        Public ReadOnly Property AvaiableTextProperties As cIItemText.AvaiableTextPropertiesEnum Implements cIItemText.AvaiableTextProperties
            Get
                Return cIItemText.AvaiableTextPropertiesEnum.VerticalLineable Or cIItemText.AvaiableTextPropertiesEnum.Lineable Or cIItemText.AvaiableTextPropertiesEnum.Text
            End Get
        End Property

        Public Property TextAlignment As cIItemLineableText.TextAlignmentEnum Implements cIItemLineableText.TextAlignment
            Get
                Return iTextAlignment
            End Get
            Set(value As cIItemLineableText.TextAlignmentEnum)
                If iTextAlignment <> value Then
                    iTextAlignment = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property TextVerticalAlignment As cIItemVerticalLineableText.TextVerticalAlignmentEnum Implements cIItemVerticalLineableText.TextVerticalAlignment
            Get
                Return iTextVerticalAlignment
            End Get
            Set(value As cIItemVerticalLineableText.TextVerticalAlignmentEnum)
                If value <> iTextVerticalAlignment Then
                    iTextVerticalAlignment = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Private Sub oFont_OnRender(sender As cItemFont, RenderArgs As cItemFont.cRenderArgs) Handles oFont.OnRender
            If HaveTransparency Then
                RenderArgs.Transparency = MyBase.Transparency
            End If
        End Sub
    End Class

End Namespace



