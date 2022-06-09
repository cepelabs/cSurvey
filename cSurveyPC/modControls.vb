Imports System.Collections.Specialized
Imports System.Drawing.Drawing2D
Imports System.Reflection
Imports System.ComponentModel
Imports DevExpress.XtraBars

Module modControls
    'Public SystemDPIRatio As Single

    <System.Runtime.CompilerServices.Extension>
    Public Function HasMethod(Control As Control, MethodName As String) As Boolean
        Try
            Return Control.GetType.GetMethod("ForceInitialize") IsNot Nothing
        Catch ex As AmbiguousMatchException
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Class cComboItem(Of T)
        Private oValue As T
        Private sDescription As String

        Public Overrides Function ToString() As String
            Return sDescription
        End Function

        Public Sub New(Description As String, Value As T)
            sDescription = Description
            oValue = Value
        End Sub

        Public ReadOnly Property Value As T
            Get
                Return oValue
            End Get
        End Property

        Public ReadOnly Property Description As String
            Get
                Return sDescription
            End Get
        End Property
    End Class

    <System.Runtime.CompilerServices.Extension>
    Public Function CreateOrGetButton(RibbonControl As Ribbon.RibbonControl, Name As String) As BarButtonItem
        Dim oItem As BarItem = RibbonControl.Items(Name)
        If oItem Is Nothing Then
            oItem = New BarButtonItem(RibbonControl.Manager, "")
        End If
        Return oItem
    End Function

    <System.Runtime.CompilerServices.Extension>
    Public Sub AddRange(ItemLinks As BarItemLinkCollection, items As BarItem(), RibbonItemStyles As Ribbon.RibbonItemStyles, BarItemStyle As BarItemPaintStyle)
        items.ToList.ForEach(Sub(oitem)
                                 Dim oLink As BarItemLink = ItemLinks.Add(oitem)
                                 oLink.UserRibbonStyle = RibbonItemStyles
                                 oLink.UserPaintStyle = BarItemStyle
                             End Sub)
    End Sub

    <System.Runtime.CompilerServices.Extension>
    Public Function Add(ItemLinks As BarItemLinkCollection, item As BarItem, BeginGroup As Boolean, RibbonItemStyles As Ribbon.RibbonItemStyles) As BarItemLink
        Dim oLink As BarItemLink = ItemLinks.Add(item)
        oLink.BeginGroup = BeginGroup
        oLink.UserRibbonStyle = RibbonItemStyles
        Return oLink
    End Function

    <System.Runtime.CompilerServices.Extension>
    Public Function Add(ItemLinks As BarItemLinkCollection, item As BarItem, BeginGroup As Boolean, RibbonItemStyles As Ribbon.RibbonItemStyles, BarItemStyle As BarItemPaintStyle) As BarItemLink
        Dim oLink As BarItemLink = ItemLinks.Add(item)
        oLink.BeginGroup = BeginGroup
        oLink.UserRibbonStyle = RibbonItemStyles
        oLink.UserPaintStyle = BarItemStyle
        Return oLink
    End Function

    <System.Runtime.CompilerServices.Extension>
    Public Function Add(ItemLinks As BarItemLinkCollection, item As BarItem, RibbonItemStyles As Ribbon.RibbonItemStyles) As BarItemLink
        Dim oLink As BarItemLink = ItemLinks.Add(item)
        oLink.UserRibbonStyle = RibbonItemStyles
        Return oLink
    End Function

    <System.Runtime.CompilerServices.Extension>
    Public Sub ClearItems(Menu As PopupMenu)
        For Each oLink As BarItemLink In Menu.ItemLinks.ToList
            Call oLink.Manager.Items.Remove(oLink.Item)
        Next
    End Sub

    <System.Runtime.CompilerServices.Extension>
    Public Sub ClearItems(Group As Ribbon.RibbonPageGroup)
        For Each oLink As BarItemLink In Group.ItemLinks.ToList
            Call oLink.Manager.Items.Remove(oLink.Item)
        Next
    End Sub

    Public Function VisibleToVisibility(Visible As Boolean) As DevExpress.XtraBars.BarItemVisibility
        If Visible Then
            Return DevExpress.XtraBars.BarItemVisibility.Always
        Else
            Return DevExpress.XtraBars.BarItemVisibility.Never
        End If
    End Function

    <System.Runtime.CompilerServices.Extension>
    Public Function Components(Form As Form) As List(Of Component)
        Dim oComponents As List(Of Component) = New List(Of Component)
        Dim fieldInfos() As FieldInfo = Form.GetType.GetFields(BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
        For Each oField As FieldInfo In fieldInfos
            If oField.FieldType.BaseType Is GetType(Component) Then
                Dim oComponent As Component = TryCast(oField.GetValue(Form), Component)
                If Not IsNothing(oComponent) Then oComponents.Add(oComponent)
            End If
        Next
        Return oComponents
    End Function

    '<System.Runtime.CompilerServices.Extension>
    'Public Sub AdjustThroughtDPI(Form As Form, DPIRatio As Single)
    '    If DPIRatio > 1.0F Then
    '        Call pAdjustComponentsThroughDPI(Form.Components, DPIRatio)
    '        Call pAdjustControlsThroughDPI(Form.Controls, DPIRatio)
    '    End If
    'End Sub

    'Private Sub pAdjustControlsThroughDPI(Listview As ListView, DPIRatio As Single)
    '    For Each oColumn As ColumnHeader In Listview.Columns
    '        oColumn.Width = oColumn.Width * DPIRatio
    '    Next
    'End Sub

    'Private Sub pAdjustControlsThroughDPI(ComboBox As ComboBox, DPIRatio As Single)
    '    If ComboBox.DrawMode = DrawMode.OwnerDrawFixed Then
    '        ComboBox.ItemHeight = ComboBox.ItemHeight * DPIRatio
    '    End If
    '    If ComboBox.DropDownWidth <> 0 Then ComboBox.DropDownWidth = ComboBox.DropDownWidth * DPIRatio
    'End Sub

    'Private Sub pAdjustControlsThroughDPI(TabControl As TabControl, DPIRatio As Single)
    '    For Each oTabPage In DirectCast(TabControl, TabControl).TabPages
    '        If oTabPage.Controls.Count > 0 Then
    '            Call pAdjustControlsThroughDPI(oTabPage.Controls, DPIRatio)
    '        End If
    '    Next
    'End Sub

    'Private Sub pAdjustControlsThroughDPI(Splitter As SplitContainer, DPIRatio As Single)
    '    Splitter.SplitterWidth = Splitter.SplitterWidth * DPIRatio
    'End Sub

    'Private Sub pAdjustControlsThroughDPI(StatusStrip As StatusStrip, DPIRatio As Single)
    '    StatusStrip.ImageScalingSize = New Size(StatusStrip.ImageScalingSize.Width * DPIRatio, StatusStrip.ImageScalingSize.Height * DPIRatio)
    '    For Each oPanel As ToolStripItem In StatusStrip.Items
    '        Dim oLabel As ToolStripStatusLabel = TryCast(oPanel, ToolStripStatusLabel)
    '        If oLabel IsNot Nothing Then
    '            If Not oLabel.AutoSize Then
    '                If oLabel.Spring Then
    '                    oLabel.Size = New Size(oLabel.Width, oLabel.Height * DPIRatio)
    '                Else
    '                    oLabel.Size = New Size(oLabel.Width * DPIRatio, oLabel.Height * DPIRatio)
    '                End If
    '                Continue For
    '            End If
    '        End If
    '        If Not oPanel.AutoSize Then
    '            oPanel.Size = New Size(oPanel.Width * DPIRatio, oPanel.Height * DPIRatio)
    '        End If
    '    Next
    '    Call StatusStrip.Refresh()
    'End Sub

    'Private Sub pAdjustControlsThroughDPI(Grid As DataGridView, DPIRatio As Single)
    '    For Each oColumn As DataGridViewColumn In Grid.Columns
    '        oColumn.Width = oColumn.Width * DPIRatio
    '    Next
    'End Sub

    'Private Sub pAdjustControlsThroughDPI(Toolbar As ToolStrip, DPIRatio As Single)
    '    Toolbar.ImageScalingSize = New Size(Toolbar.ImageScalingSize.Width * DPIRatio, Toolbar.ImageScalingSize.Height * DPIRatio)
    '    '----------------------------------------------------
    '    Dim iBackup = Toolbar.GripStyle
    '    If Toolbar.GripStyle = ToolStripGripStyle.Hidden Then
    '        Toolbar.GripStyle = ToolStripGripStyle.Visible
    '    Else
    '        Toolbar.GripStyle = ToolStripGripStyle.Hidden
    '    End If
    '    Toolbar.GripStyle = iBackup
    '    '----------------------------------------------------
    '    Call Toolbar.Invalidate()
    'End Sub

    Private Class cImageBag
        Public Key As String
        Public Image As Image

        Public Sub New(Key As String, Image As Image)
            Me.Key = Key
            Me.Image = Image
        End Sub
    End Class

    Private Sub pAdjustComponentsThroughDPI(Imagelist As ImageList, DPIRatio As Single)
        Dim oImages As List(Of cImageBag) = New List(Of cImageBag)
        Dim sKeys As StringCollection = Imagelist.Images.Keys
        Dim iIndex As Integer = 0
        For Each oImage As Image In Imagelist.Images
            Call oImages.Add(New cImageBag(sKeys(iIndex), oImage))
            iIndex += 0
        Next
        Imagelist.ImageSize = New Size(Imagelist.ImageSize.Width * DPIRatio, Imagelist.ImageSize.Height * DPIRatio)
        For Each oImageBag As cImageBag In oImages
            If oImageBag.Key <> "" Then
                Imagelist.Images.Add(oImageBag.Key, oImageBag.Image)
            Else
                Imagelist.Images.Add(oImageBag.Image)
            End If
        Next
    End Sub

    'Private Sub pAdjustComponentsThroughDPI(Components As List(Of Component), DPIRatio As Single)
    '    For Each oComponent As Component In Components
    '        If Not IsNothing(oComponent) Then
    '            Try
    '                If TypeOf oComponent Is ImageList Then
    '                    Call pAdjustComponentsThroughDPI(DirectCast(oComponent, ImageList), DPIRatio)
    '                End If
    '            Catch ex As Exception
    '                Call Debug.Print("  error>" & ex.Message)
    '            End Try
    '        End If
    '    Next
    'End Sub

    'Private Sub pAdjustControlsThroughDPI(controls As Control.ControlCollection, DPIRatio As Single)
    '    For Each oControl As Control In controls
    '        If Not IsNothing(oControl) Then
    '            Call Debug.Print("-->" & oControl.Name & " type>" & oControl.GetType.ToString)
    '            Try
    '                If TypeOf oControl Is ButtonBase Then
    '                    Call Debug.Print("  type:ButtonBase>" & oControl.Name)
    '                    Call pAdjustControlsThroughDPI(DirectCast(oControl, ButtonBase), DPIRatio)
    '                ElseIf TypeOf oControl Is StatusStrip Then
    '                    Call Debug.Print("  type:StatusBar>" & oControl.Name)
    '                    Call pAdjustControlsThroughDPI(DirectCast(oControl, StatusStrip), DPIRatio)
    '                ElseIf TypeOf oControl Is ToolStrip Then
    '                    Call Debug.Print("  type:ToolStrip>" & oControl.Name)
    '                    Call pAdjustControlsThroughDPI(DirectCast(oControl, ToolStrip), DPIRatio)
    '                ElseIf TypeOf oControl Is DataGridView Then
    '                    Call Debug.Print("  type:DataGridView>" & oControl.Name)
    '                    Call pAdjustControlsThroughDPI(DirectCast(oControl, DataGridView), DPIRatio)
    '                ElseIf TypeOf oControl Is ListView Then
    '                    Call Debug.Print("  type:ListView>" & oControl.Name)
    '                    Call pAdjustControlsThroughDPI(DirectCast(oControl, ListView), DPIRatio)
    '                ElseIf TypeOf oControl Is ComboBox Then
    '                    Call Debug.Print("  type:ComboBox>" & oControl.Name)
    '                    Call pAdjustControlsThroughDPI(DirectCast(oControl, ComboBox), DPIRatio)
    '                ElseIf TypeOf oControl Is SplitContainer Then
    '                    Call Debug.Print("  type:SplitContainer>" & oControl.Name)
    '                    Call pAdjustControlsThroughDPI(DirectCast(oControl, SplitContainer), DPIRatio)
    '                ElseIf TypeOf oControl Is TabControl Then
    '                    Call pAdjustControlsThroughDPI(DirectCast(oControl, TabControl), DPIRatio)
    '                End If
    '            Catch ex As Exception
    '                Call Debug.Print("  error>" & ex.Message)
    '            End Try
    '            'controls parent of other controls...
    '            If oControl.Controls.Count > 0 Then
    '                Call pAdjustControlsThroughDPI(oControl.Controls, DPIRatio)
    '            End If
    '        End If
    '    Next
    'End Sub

    'Private Sub pAdjustControlsThroughDPI(Button As ButtonBase, DPIRatio As Single)
    '    Dim oImage As Image = Button.Image
    '    If oImage IsNot Nothing Then
    '        Button.Image = pGetImageStretchedDPI(oImage, DPIRatio)
    '    End If
    'End Sub

    'Private Function pGetImageStretchedDPI(imageIn As Image, DPIRatio As Single) As Image
    '    Dim iNewWidth As Integer = imageIn.Width * DPIRatio
    '    Dim iNewHeight As Integer = imageIn.Height * DPIRatio
    '    Dim newBitmap = New Bitmap(iNewWidth, iNewHeight)

    '    Using g = Graphics.FromImage(newBitmap)
    '        ' According to this blog post http://blogs.msdn.com/b/visualstudio/archive/2014/03/19/improving-high-dpi-support-for-visual-studio-2013.aspx
    '        ' NearestNeighbor is more adapted for 200% and 200%+ DPI
    '        Dim interpolationMode__1 = InterpolationMode.HighQualityBicubic
    '        If DPIRatio >= 2.0F Then
    '            interpolationMode__1 = InterpolationMode.NearestNeighbor
    '        End If
    '        g.InterpolationMode = interpolationMode__1
    '        g.DrawImage(imageIn, New Rectangle(0, 0, iNewWidth, iNewHeight))
    '    End Using

    '    Call imageIn.Dispose()
    '    Return newBitmap
    'End Function

    Public Sub RemoveTableLayoutCellPadding(Table As TableLayoutPanel)
        For Each oControl As Control In Table.Controls
            If TypeOf oControl Is Panel Then
                oControl.Margin = New Padding(0, 0, 0, 2)
            End If
        Next
    End Sub

    Public Function FindToolbarButtonByName(ToolbarItems As ToolStripItemCollection, Name As String) As ToolStripItem
        For Each oToolbarItem As ToolStripItem In ToolbarItems
            If oToolbarItem.Name = Name Then
                Return oToolbarItem
            Else
                If TypeOf oToolbarItem Is ToolStripDropDownButton Then
                    Dim oSubItem As ToolStripItem = FindToolbarButtonByName(DirectCast(oToolbarItem, ToolStripDropDownButton).DropDownItems, Name)
                    If Not IsNothing(oSubItem) Then
                        Return oSubItem
                    End If
                End If
            End If
        Next
    End Function
End Module
