Imports System.Runtime.CompilerServices
Imports System.Text
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraVerticalGrid.Rows
Imports DevExpress.Utils
Imports DevExpress.XtraNavBar
Imports DevExpress.XtraNavBar.ViewInfo
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraEditors

Public Module modDevExpress
    Public Sub PrepareSkinMenu(SkinGallery As DevExpress.XtraBars.Ribbon.Gallery.GalleryControlGallery)
        'SkinGallery.Groups.ToList.ForEach(Sub(oGroup) oGroup.Items.ToList.ForEach(Sub(oItem) oItem.Visible = (oItem.Caption.ToLower = "the bezier" OrElse oItem.Caption.ToLower Like "*office 2019 *" OrElse oItem.Caption.ToLower Like "*visual studio*")))
    End Sub

    Public Function SkinBackcolor(Color As Color) As Color
        If cSurvey.Helper.Editor.cEditDesignEnvironment.GetSetting("isdarkskin") Then
            Return modPaint.DarkColor(Color, 0.35)
        Else
            Return modPaint.LightColor(Color, 0.85)
        End If
    End Function

    Public Sub UpdateFloatingForm(MainForm As XtraForm, DockManager As DevExpress.XtraBars.Docking.DockManager)
        For Each oPanel As DevExpress.XtraBars.Docking.DockPanel In DockManager.Panels
            Call UpdateFloatingForm(MainForm, oPanel.FloatForm)
        Next
    End Sub

    Public Sub UpdateFloatingForm(MainForm As XtraForm, Form As DevExpress.XtraBars.Docking.FloatForm)
        If Form IsNot Nothing Then
            Form.Text = Form.Controls(0).Text
            Form.IconOptions.SvgImage = MainForm.IconOptions.SvgImage
            Form.ShowInTaskbar = True
        End If
    End Sub
    Public Sub RestoreDockPanel(DockManager As DevExpress.XtraBars.Docking.DockManager, DockPanel As DevExpress.XtraBars.Docking.DockPanel, Dock As DevExpress.XtraBars.Docking.DockingStyle)
        If DockPanel.DockManager Is Nothing Then
            DockManager.AddPanel(Dock, DockPanel)
            DockPanel.Visible = False
        End If
    End Sub

    <Extension>
    Public Function FullFocusRow(Grid As DevExpress.XtraGrid.Views.Grid.GridView, RowHandle As Integer) As Boolean
        If RowHandle <> Grid.FocusedRowHandle Then
            Grid.FocusedRowHandle = RowHandle
        End If
        Grid.ClearSelection()
        Grid.SelectRow(Grid.FocusedRowHandle)
        Grid.MakeRowVisible(Grid.FocusedRowHandle)
    End Function

    <Extension>
    Public Function AddBoundColumn(Grid As DevExpress.XtraGrid.Views.Grid.GridView, Name As String, Caption As String, FieldName As String, Width As Integer) As DevExpress.XtraGrid.Columns.GridColumn
        Dim oColumn As DevExpress.XtraGrid.Columns.GridColumn = New DevExpress.XtraGrid.Columns.GridColumn
        oColumn.Name = Name
        oColumn.Caption = Caption
        oColumn.FieldName = FieldName
        If Width >= 0 Then oColumn.Width = Width
        oColumn.Visible = True
        Call Grid.Columns.Add(oColumn)
        Return oColumn
    End Function

    <Extension>
    Public Function RefreshFocusedRow(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        If Grid.FocusedRowHandle >= 0 Then
            Call Grid.RefreshRow(Grid.FocusedRowHandle)
            Return True
        Else
            Return False
        End If
    End Function

    <Extension>
    Public Function ValidateIfNull(BaseEdit As DevExpress.XtraEditors.BaseEdit) As Boolean
        If ("" & BaseEdit.EditValue).ToString.Trim = "" Then
            BaseEdit.ErrorText = modMain.GetLocalizedString("main.genericvalidateerror")
            BaseEdit.ErrorImageOptions.Assign(DevExpress.XtraEditors.BaseEdit.DefaultErrorImageOptions)
            Return False
        Else
            BaseEdit.ErrorText = ""
            BaseEdit.ErrorImageOptions.SvgImage = Nothing
            Return True
        End If
    End Function

    <Extension>
    Public Function AppendHyperlink(RichEditControl As DevExpress.XtraRichEdit.RichEditControl, Text As String, URI As String)
        Dim oRange As DevExpress.XtraRichEdit.API.Native.DocumentRange = RichEditControl.AppendText(Text)
        Dim oHyperlink As Hyperlink = RichEditControl.Document.Hyperlinks.Create(oRange)
        oHyperlink.NavigateUri = URI
        Return oRange
    End Function

    <Extension>
    Public Function AppendHyperlink(RichEditControl As DevExpress.XtraRichEdit.RichEditControl, Text As String, ForeColor As System.Drawing.Color, URI As String)
        Dim oRange As DevExpress.XtraRichEdit.API.Native.DocumentRange = RichEditControl.AppendText(Text, ForeColor)
        Dim oHyperlink As Hyperlink = RichEditControl.Document.Hyperlinks.Create(oRange)
        oHyperlink.NavigateUri = URI
        RichEditControl.Document.Paragraphs.Append()
        Return oRange
    End Function

    <Extension>
    Public Function AppendText(RichEditControl As DevExpress.XtraRichEdit.RichEditControl, Text As String) As DevExpress.XtraRichEdit.API.Native.DocumentRange
        Return RichEditControl.Document.AppendText(Text)
    End Function

    <Extension>
    Public Function AppendText(RichEditControl As DevExpress.XtraRichEdit.RichEditControl, Text As String, ForeColor As System.Drawing.Color) As DevExpress.XtraRichEdit.API.Native.DocumentRange
        Dim oRange As DevExpress.XtraRichEdit.API.Native.DocumentRange = RichEditControl.Document.AppendText(Text)
        Dim oCP As DevExpress.XtraRichEdit.API.Native.CharacterProperties = RichEditControl.Document.BeginUpdateCharacters(oRange)
        oCP.ForeColor = ForeColor
        RichEditControl.Document.EndUpdateCharacters(oCP)
        RichEditControl.Document.Paragraphs.Append()
        Return oRange
    End Function

    <Extension>
    Public Sub SetSelectionForecolor(RichEditControl As DevExpress.XtraRichEdit.RichEditControl, ForeColor As System.Drawing.Color)
        Dim oCP As DevExpress.XtraRichEdit.API.Native.CharacterProperties = RichEditControl.Document.BeginUpdateCharacters(RichEditControl.Document.Selection)
        oCP.ForeColor = ForeColor
        RichEditControl.Document.EndUpdateCharacters(oCP)
    End Sub

    Public Function SvgImageToClipart(SvgImage As DevExpress.Utils.Svg.SvgImage) As cSurvey.Drawings.cDrawClipArt
        If SvgImage Is Nothing Then
            Return Nothing
        Else
            Using oMS As IO.MemoryStream = New IO.MemoryStream
                Call SvgImage.Save(oMS)
                oMS.Position = 0
                Return New cSurvey.Drawings.cDrawClipArt(oMS)
            End Using
        End If
    End Function

    Public Function SvgImageFromClipart(Clipart As cSurvey.Drawings.cDrawClipArt) As DevExpress.Utils.Svg.SvgImage
        Using oMS As IO.MemoryStream = New IO.MemoryStream
            Call Clipart.Save(oMS)
            oMS.Position = 0
            Return DevExpress.Utils.Svg.SvgImage.FromStream(oMS)
        End Using
    End Function

    Public Function SvgBitmapFromClipart(Clipart As cSurvey.Drawings.cDrawClipArt) As DevExpress.Utils.Svg.SvgBitmap
        If Clipart Is Nothing Then
            Return Nothing
        Else
            Using oMS As IO.MemoryStream = New IO.MemoryStream
                Call Clipart.Save(oMS)
                oMS.Position = 0
                Return DevExpress.Utils.Svg.SvgBitmap.FromStream(oMS)
            End Using
        End If
    End Function

    Public Function GetSkinForecolor() As Color
        Dim oSkin As DevExpress.Skins.Skin = DevExpress.Skins.CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default)
        Return oSkin.Colors("ControlText")
    End Function

    Public Function GetSkinPanelBackcolor() As Color
        Dim oElement As DevExpress.Skins.SkinElement = DevExpress.Skins.SkinManager.GetSkinElement(DevExpress.Skins.SkinProductId.Common, DevExpress.LookAndFeel.UserLookAndFeel.Default, "GroupPanel")
        Using oSkinBitmap As Bitmap = New Bitmap(oElement.Image.Image)
            Return oSkinBitmap.GetPixel(oSkinBitmap.Width / 2, oSkinBitmap.Height / 2)
        End Using
    End Function

    Public Function CreateSuperTip(Title As String, TitleImage As Svg.SvgImage, TitleImageSize As Size?, Contents As String, ContentsImage As Svg.SvgImage, ContentsImageSize As Size?, Footer As String, FooterImage As Svg.SvgImage, FooterImageSize As Size?) As SuperToolTip
        Dim oTooltip As SuperToolTip = New SuperToolTip
        Dim args As SuperToolTipSetupArgs = New SuperToolTipSetupArgs
        oTooltip.AllowHtmlText = DefaultBoolean.True
        If Title <> "" Then
            args.Title.Text = Title
            If TitleImage IsNot Nothing Then
                args.Title.ImageOptions.SvgImage = TitleImage
                If TitleImageSize.HasValue Then args.Title.ImageOptions.SvgImageSize = TitleImageSize.Value
            End If
        End If
        If Contents <> "" Then
            args.Contents.Text = Contents
            If ContentsImage IsNot Nothing Then
                args.Contents.ImageOptions.SvgImage = ContentsImage
                If ContentsImageSize.HasValue Then args.Contents.ImageOptions.SvgImageSize = ContentsImageSize.Value
            End If
        End If
        If Footer <> "" Then
            args.ShowFooterSeparator = True
            args.Footer.Text = "<href=cmd>" & Footer & "</href>"
            If FooterImage IsNot Nothing Then
                args.Footer.ImageOptions.SvgImage = FooterImage
                If FooterImageSize.HasValue Then args.Footer.ImageOptions.SvgImageSize = FooterImageSize.Value
            End If
        End If
        oTooltip.Setup(args)
        ' Assign the created SuperToolTip to a BarItem.
        Return oTooltip

    End Function

    <Extension>
    Public Sub RowSetVisible(Grid As DevExpress.XtraVerticalGrid.VGridControl, FieldName As String, Visible As Boolean)
        Grid.Rows.ColumnByFieldName(FieldName).Visible = Visible
    End Sub

    <Extension>
    Public Sub RowSetCaption(Grid As DevExpress.XtraVerticalGrid.VGridControl, FieldName As String, Caption As String)
        Grid.Rows.ColumnByFieldName(FieldName).Properties.Caption = Caption
    End Sub

    <Extension>
    Public Sub RowAdd(Grid As DevExpress.XtraVerticalGrid.VGridControl, FieldName As String, Caption As String, Type As DevExpress.Data.UnboundColumnType)
        Dim oRow As EditorRow = New EditorRow(FieldName)
        oRow.Properties.Caption = Caption
        oRow.Properties.ReadOnly = True
        'oRow.Properties.AllowEdit = False
        oRow.Properties.UnboundType = Type
        Grid.Rows.Add(oRow)
    End Sub

    <Extension>
    Public Sub CopyRow(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim oText As StringBuilder = New StringBuilder
        For Each oColumn As DevExpress.XtraGrid.Columns.GridColumn In Grid.VisibleColumns
            oText.Append(oColumn.Caption & vbTab)
        Next
        oText.AppendLine()
        Dim i As Integer = Grid.FocusedRowHandle
        If i >= 0 Then
            For Each oColumn As DevExpress.XtraGrid.Columns.GridColumn In Grid.VisibleColumns
                oText.Append(Grid.GetRowCellDisplayText(i, oColumn) & vbTab)
            Next
            oText.AppendLine()
            Call Clipboard.SetText(oText.ToString)
        End If
    End Sub

    <Extension>
    Public Sub CopyRows(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim oText As StringBuilder = New StringBuilder
        For Each oColumn As DevExpress.XtraGrid.Columns.GridColumn In Grid.VisibleColumns
            oText.Append(oColumn.Caption & vbTab)
        Next
        oText.AppendLine()
        For i As Integer = 0 To Grid.DataRowCount - 1
            If i >= 0 Then
                For Each oColumn As DevExpress.XtraGrid.Columns.GridColumn In Grid.VisibleColumns
                    oText.Append(Grid.GetRowCellDisplayText(i, oColumn) & vbTab)
                Next
                oText.AppendLine()
            End If
        Next
        Call Clipboard.SetText(oText.ToString)
    End Sub

    <Extension>
    Public Sub CopyRowValue(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim oText As StringBuilder = New StringBuilder
        Dim i As Integer = Grid.FocusedRowHandle
        If i >= 0 Then
            For Each oColumn As DevExpress.XtraGrid.Columns.GridColumn In Grid.VisibleColumns
                oText.Append(Grid.GetRowCellDisplayText(i, oColumn) & vbTab)
            Next
            oText.AppendLine()
            Call Clipboard.SetText(oText.ToString)
        End If
    End Sub

    <Extension>
    Public Sub CopyRowValues(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim oText As StringBuilder = New StringBuilder
        For i As Integer = 0 To Grid.DataRowCount - 1
            If i >= 0 Then
                For Each oColumn As DevExpress.XtraGrid.Columns.GridColumn In Grid.VisibleColumns
                    oText.Append(Grid.GetRowCellDisplayText(i, oColumn) & vbTab)
                Next
                oText.AppendLine()
            End If
        Next
        Call Clipboard.SetText(oText.ToString)
    End Sub

    <Extension>
    Public Sub CopyRowValue(Grid As DevExpress.XtraVerticalGrid.VGridControl)
        Clipboard.SetText(Grid.FocusedRow.Properties.Value.ToString)
    End Sub

    <Extension>
    Public Sub CopyRowValues(Grid As DevExpress.XtraVerticalGrid.VGridControl)
        Dim oText As StringBuilder = New StringBuilder
        For Each oRow As BaseRow In Grid.Rows
            oText.AppendLine(oRow.Properties.Value.ToString)
        Next
        Call Clipboard.SetText(oText.ToString)
    End Sub

    <Extension>
    Public Sub CopyRow(Grid As DevExpress.XtraVerticalGrid.VGridControl)
        Clipboard.SetText(Grid.FocusedRow.Properties.Caption & vbTab & Grid.FocusedRow.Properties.Value.ToString)
    End Sub

    <Extension>
    Public Sub CopyRows(Grid As DevExpress.XtraVerticalGrid.VGridControl)
        Dim oText As StringBuilder = New StringBuilder
        For Each oRow As BaseRow In Grid.Rows
            oText.AppendLine(oRow.Properties.Caption & vbTab & oRow.Properties.Value.ToString)
        Next
        Call Clipboard.SetText(oText.ToString)
    End Sub

    <Extension>
    Public Sub ExportToCSV(Grid As DevExpress.XtraVerticalGrid.VGridControl, Filename As String)
        Using oTW As IO.TextWriter = New IO.StreamWriter(Filename)
            'Dim oConfiguration As CsvHelper.CsvWriter.
            Dim oCsvWriter As CsvHelper.CsvWriter = New CsvHelper.CsvWriter(oTW, Globalization.CultureInfo.InvariantCulture)
            'oCsvWriter.Configuration.Delimiter = ";"
            For Each oRow As BaseRow In Grid.Rows
                Call oCsvWriter.WriteField(oRow.Properties.Caption)
                Call oCsvWriter.WriteField(oRow.Properties.Value.ToString)
                Call oCsvWriter.NextRecord()
            Next
        End Using

        Dim oText As StringBuilder = New StringBuilder
        For Each oRow As BaseRow In Grid.Rows
            oText.AppendLine(oRow.Properties.Caption & ";" & oRow.Properties.Value.ToString)
        Next
        My.Computer.FileSystem.WriteAllText(Filename, oText.ToString, False)
    End Sub

    <Extension>
    Public Sub ClearItems(Item As DevExpress.XtraBars.BarSubItem)
        For Each oLink As DevExpress.XtraBars.BarItemLink In Item.ItemLinks.ToList
            Call Item.Manager.Items.Remove(oLink.Item)
        Next
    End Sub

    <Extension>
    Public Function FindByName(Items As DevExpress.XtraBars.Ribbon.RibbonBarItems, Name As String) As DevExpress.XtraBars.BarItem
        Dim sName As String = Name.ToLower
        Return Items.Where(Function(oitem) oitem.Name.ToLower = sName).FirstOrDefault
    End Function

    <Extension> Public Function GetFocusedObject(Control As DevExpress.XtraGrid.Views.Grid.GridView) As Object
        Return Control.GetFocusedRow
    End Function

    <Extension> Public Function SetFocusedRow(Control As DevExpress.XtraGrid.Views.Grid.GridView, FocusedObject As Object) As Boolean
        Return SetFocusedObject(Control, FocusedObject)
    End Function

    <Extension> Public Function SetFocusedObject(Control As DevExpress.XtraGrid.Views.Grid.GridView, FocusedObject As Object) As Boolean
        Dim iHandle As Integer = Control.FindRow(FocusedObject)
        If iHandle >= 0 Then
            Control.FocusedRowHandle = iHandle
            Return True
        Else
            Return False
        End If
    End Function

    <Extension> Public Function [Objects](Control As TreeList) As Object
        Return Control.DataSource
    End Function

    <Extension> Public Function SelectedObjects(Control As TreeList) As Object
        Dim oResult As List(Of Object) = New List(Of Object)
        For Each oNode As TreeListNode In Control.Selection
            oResult.Add(Control.GetDataRecordByNode(oNode))
        Next
        Return oResult
    End Function

    <Extension> Public Function SetFocusedObject(Control As TreeList, FocusedObject As Object) As Boolean

        Dim oFoundNode As TreeListNode = Control.FindNode(Function(oNode)
                                                              Return Control.GetRow(oNode.Id) Is FocusedObject
                                                          End Function)
        If oFoundNode Is Nothing Then
            Return False
        Else
            Control.FocusedNode = oFoundNode
            'Control.MakeNodeVisible(oFoundNode)
            Return True
        End If
    End Function

    <Extension> Public Function GetNodeByDataRecord(Control As TreeList, DataRow As Object) As TreeListNode
        'very ugly...but seem to be the only way to do this...
        Return Control.NodesIterator.All.FirstOrDefault(Function(oNode) Control.GetDataRecordByNode(oNode) Is DataRow)
    End Function

    <Extension> Public Function GetFocusedObject(Control As TreeList) As Object
        Return Control.GetFocusedRow()
    End Function

    <Extension> Public Sub RefreshFocusedObject(Control As TreeList)
        If Not Control.FocusedNode Is Nothing Then
            Control.RefreshNode(Control.FocusedNode)
        End If
    End Sub

    <Extension> Public Sub DeselectAll(Control As TreeList)
        Call Control.BeginUpdate()
        Call Control.Selection.UnselectAll()
        Call Control.EndUpdate()
    End Sub

    <Extension> Public Sub SelectObjects(Control As TreeList, items As IList)
        Call Control.BeginUpdate()
        For Each oNode As TreeListNode In Control.Nodes
            If items.Contains(Control.GetDataRecordByNode(oNode)) Then
                Control.SelectNode(oNode)
            End If
        Next
        Call Control.EndUpdate()
    End Sub
End Module


Namespace cNavigationPanel
    Public Class CustomNavPaneViewInfo
        Inherits SkinNavigationPaneViewInfo

        Public Sub New(ByVal navBar As NavBarControl)
            MyBase.New(navBar)
        End Sub
        Protected Overrides Function CreateNavPaneHeaderPainter() As NavigationPaneHeaderPainter
            Return New CustomNavPaneHeaderPainter(Me)
        End Function
    End Class

    Public Class CustomNavPaneHeaderPainter
        Inherits SkinNavigationPaneHeaderPainter

        Public Sub New(ByVal npvi As NavigationPaneViewInfo)
            MyBase.New(npvi)
        End Sub

        Public Overrides Function CalcObjectMinBounds(ByVal e As ObjectInfoArgs) As Rectangle
            Return Rectangle.Empty
        End Function
    End Class

    Public Class CustomNavPaneViewInfoRegistrator
        Inherits SkinNavigationPaneViewInfoRegistrator

        Public Overrides ReadOnly Property ViewName() As String
            Get
                Return "cNavigationPanel"
            End Get
        End Property

        Public Overrides Function CreateViewInfo(ByVal navBar As NavBarControl) As NavBarViewInfo
            Return New CustomNavPaneViewInfo(navBar)
        End Function
    End Class
End Namespace