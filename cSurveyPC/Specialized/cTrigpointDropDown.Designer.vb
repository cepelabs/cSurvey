<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cTrigpointDropDown
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cTrigpointDropDown))
        Me.cboIsSplay = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.svgImages = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.cboTrigpoint = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.cboTrigpointView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIsSplay = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.cboIsSplay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.svgImages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTrigpoint.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTrigpointView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboIsSplay
        '
        Me.cboIsSplay.AutoHeight = False
        Me.cboIsSplay.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboIsSplay.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cboIsSplay.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Splay end", True, -1), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Station", False, 0)})
        Me.cboIsSplay.Name = "cboIsSplay"
        Me.cboIsSplay.SmallImages = Me.svgImages
        '
        'svgImages
        '
        Me.svgImages.Add("station", CType(resources.GetObject("svgImages.station"), DevExpress.Utils.Svg.SvgImage))
        Me.svgImages.Add("prioritized", "prioritized", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgImages.Add("caveentrance", "caveentrance", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgImages.Add("outside", CType(resources.GetObject("svgImages.outside"), DevExpress.Utils.Svg.SvgImage))
        Me.svgImages.Add("bo_localization", "bo_localization", GetType(cSurveyPC.My.Resources.Resources))
        '
        'cboTrigpoint
        '
        Me.cboTrigpoint.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboTrigpoint.Location = New System.Drawing.Point(0, 0)
        Me.cboTrigpoint.Name = "cboTrigpoint"
        Me.cboTrigpoint.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboTrigpoint.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboTrigpoint.Properties.DisplayMember = "Name"
        Me.cboTrigpoint.Properties.NullText = ""
        Me.cboTrigpoint.Properties.PopupView = Me.cboTrigpointView
        Me.cboTrigpoint.Properties.ShowClearButton = False
        Me.cboTrigpoint.Properties.ValueMember = "Name"
        Me.cboTrigpoint.Size = New System.Drawing.Size(346, 20)
        Me.cboTrigpoint.TabIndex = 114
        '
        'cboTrigpointView
        '
        Me.cboTrigpointView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colName, Me.colIsSplay})
        Me.cboTrigpointView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.cboTrigpointView.Images = Me.svgImages
        Me.cboTrigpointView.Name = "cboTrigpointView"
        Me.cboTrigpointView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.cboTrigpointView.OptionsView.ShowGroupPanel = False
        Me.cboTrigpointView.OptionsView.ShowIndicator = False
        '
        'colName
        '
        Me.colName.Caption = "Name"
        Me.colName.FieldName = "Name"
        Me.colName.Name = "colName"
        Me.colName.OptionsColumn.AllowEdit = False
        Me.colName.OptionsColumn.ReadOnly = True
        Me.colName.Visible = True
        Me.colName.VisibleIndex = 0
        '
        'colIsSplay
        '
        Me.colIsSplay.ColumnEdit = Me.cboIsSplay
        Me.colIsSplay.FieldName = "_IsSplay"
        Me.colIsSplay.ImageOptions.Alignment = System.Drawing.StringAlignment.Center
        Me.colIsSplay.ImageOptions.ImageIndex = 0
        Me.colIsSplay.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.colIsSplay.MaxWidth = 28
        Me.colIsSplay.MinWidth = 28
        Me.colIsSplay.Name = "colIsSplay"
        Me.colIsSplay.OptionsColumn.FixedWidth = True
        Me.colIsSplay.ToolTip = "Station"
        Me.colIsSplay.UnboundDataType = GetType(Boolean)
        Me.colIsSplay.Visible = True
        Me.colIsSplay.VisibleIndex = 1
        Me.colIsSplay.Width = 24
        '
        'cTrigpointDropDown
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cboTrigpoint)
        Me.Name = "cTrigpointDropDown"
        Me.Size = New System.Drawing.Size(346, 60)
        CType(Me.cboIsSplay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.svgImages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTrigpoint.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTrigpointView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents svgImages As DevExpress.Utils.SvgImageCollection
    Friend WithEvents cboTrigpoint As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents cboTrigpointView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIsSplay As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cboIsSplay As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
End Class
