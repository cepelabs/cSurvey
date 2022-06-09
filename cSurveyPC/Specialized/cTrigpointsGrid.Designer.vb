<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cTrigpointsGrid
    Inherits DevExpress.XtraEditors.XtraUserControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cTrigpointsGrid))
        Me.grdTrigpoints = New DevExpress.XtraGrid.GridControl()
        Me.grdViewTrigpoints = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colTrigpointsSelected = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkTrigpointsSelected = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colTrigpointsName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTrigpointsSplay = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cboTrigpointsSplay = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.svgImages = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.colTrigpointsCave = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtTrigpointsCB = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colTrigpointsBranch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTrigpointsCavesAndBranches = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtGridCaveName = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colSegmentsListCaveBranch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSegmentsCave = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.grdTrigpoints, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdViewTrigpoints, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTrigpointsSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTrigpointsSplay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.svgImages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTrigpointsCB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGridCaveName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdTrigpoints
        '
        resources.ApplyResources(Me.grdTrigpoints, "grdTrigpoints")
        Me.grdTrigpoints.MainView = Me.grdViewTrigpoints
        Me.grdTrigpoints.Name = "grdTrigpoints"
        Me.grdTrigpoints.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cboTrigpointsSplay, Me.txtTrigpointsCB, Me.chkTrigpointsSelected})
        Me.grdTrigpoints.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdViewTrigpoints})
        '
        'grdViewTrigpoints
        '
        Me.grdViewTrigpoints.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colTrigpointsSelected, Me.colTrigpointsName, Me.colTrigpointsSplay, Me.colTrigpointsCave, Me.colTrigpointsBranch, Me.colTrigpointsCavesAndBranches})
        Me.grdViewTrigpoints.GridControl = Me.grdTrigpoints
        Me.grdViewTrigpoints.Name = "grdViewTrigpoints"
        Me.grdViewTrigpoints.OptionsBehavior.AutoPopulateColumns = False
        Me.grdViewTrigpoints.OptionsBehavior.Editable = False
        Me.grdViewTrigpoints.OptionsBehavior.ReadOnly = True
        Me.grdViewTrigpoints.OptionsMenu.EnableGroupPanelMenu = False
        Me.grdViewTrigpoints.OptionsView.ShowGroupPanel = False
        Me.grdViewTrigpoints.OptionsView.ShowIndicator = False
        Me.grdViewTrigpoints.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colTrigpointsName, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colTrigpointsSelected
        '
        resources.ApplyResources(Me.colTrigpointsSelected, "colTrigpointsSelected")
        Me.colTrigpointsSelected.ColumnEdit = Me.chkTrigpointsSelected
        Me.colTrigpointsSelected.FieldName = "Selected"
        Me.colTrigpointsSelected.MaxWidth = 24
        Me.colTrigpointsSelected.MinWidth = 24
        Me.colTrigpointsSelected.Name = "colTrigpointsSelected"
        Me.colTrigpointsSelected.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colTrigpointsSelected.OptionsColumn.FixedWidth = True
        '
        'chkTrigpointsSelected
        '
        resources.ApplyResources(Me.chkTrigpointsSelected, "chkTrigpointsSelected")
        Me.chkTrigpointsSelected.Name = "chkTrigpointsSelected"
        '
        'colTrigpointsName
        '
        resources.ApplyResources(Me.colTrigpointsName, "colTrigpointsName")
        Me.colTrigpointsName.FieldName = "Name"
        Me.colTrigpointsName.Name = "colTrigpointsName"
        Me.colTrigpointsName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        '
        'colTrigpointsSplay
        '
        Me.colTrigpointsSplay.ColumnEdit = Me.cboTrigpointsSplay
        Me.colTrigpointsSplay.FieldName = "Splay"
        Me.colTrigpointsSplay.ImageOptions.Alignment = CType(resources.GetObject("colTrigpointsSplay.ImageOptions.Alignment"), System.Drawing.StringAlignment)
        Me.colTrigpointsSplay.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.station
        Me.colTrigpointsSplay.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.colTrigpointsSplay.MaxWidth = 28
        Me.colTrigpointsSplay.MinWidth = 28
        Me.colTrigpointsSplay.Name = "colTrigpointsSplay"
        Me.colTrigpointsSplay.OptionsColumn.FixedWidth = True
        resources.ApplyResources(Me.colTrigpointsSplay, "colTrigpointsSplay")
        '
        'cboTrigpointsSplay
        '
        resources.ApplyResources(Me.cboTrigpointsSplay, "cboTrigpointsSplay")
        Me.cboTrigpointsSplay.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboTrigpointsSplay.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboTrigpointsSplay.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("cboTrigpointsSplay.Items"), CType(resources.GetObject("cboTrigpointsSplay.Items1"), Object), CType(resources.GetObject("cboTrigpointsSplay.Items2"), Integer)), New DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("cboTrigpointsSplay.Items3"), CType(resources.GetObject("cboTrigpointsSplay.Items4"), Object), CType(resources.GetObject("cboTrigpointsSplay.Items5"), Integer))})
        Me.cboTrigpointsSplay.Name = "cboTrigpointsSplay"
        Me.cboTrigpointsSplay.SmallImages = Me.svgImages
        '
        'svgImages
        '
        Me.svgImages.Add("station", CType(resources.GetObject("svgImages.station"), DevExpress.Utils.Svg.SvgImage))
        Me.svgImages.Add("prioritized", "prioritized", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgImages.Add("caveentrance", "caveentrance", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgImages.Add("outside", CType(resources.GetObject("svgImages.outside"), DevExpress.Utils.Svg.SvgImage))
        Me.svgImages.Add("bo_localization", "bo_localization", GetType(cSurveyPC.My.Resources.Resources))
        '
        'colTrigpointsCave
        '
        resources.ApplyResources(Me.colTrigpointsCave, "colTrigpointsCave")
        Me.colTrigpointsCave.ColumnEdit = Me.txtTrigpointsCB
        Me.colTrigpointsCave.FieldName = "CaveHTML"
        Me.colTrigpointsCave.Name = "colTrigpointsCave"
        Me.colTrigpointsCave.OptionsColumn.AllowEdit = False
        Me.colTrigpointsCave.OptionsColumn.ReadOnly = True
        '
        'txtTrigpointsCB
        '
        Me.txtTrigpointsCB.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.txtTrigpointsCB, "txtTrigpointsCB")
        Me.txtTrigpointsCB.Name = "txtTrigpointsCB"
        '
        'colTrigpointsBranch
        '
        resources.ApplyResources(Me.colTrigpointsBranch, "colTrigpointsBranch")
        Me.colTrigpointsBranch.ColumnEdit = Me.txtTrigpointsCB
        Me.colTrigpointsBranch.FieldName = "BranchHTML"
        Me.colTrigpointsBranch.Name = "colTrigpointsBranch"
        Me.colTrigpointsBranch.OptionsColumn.AllowEdit = False
        Me.colTrigpointsBranch.OptionsColumn.ReadOnly = True
        '
        'colTrigpointsCavesAndBranches
        '
        resources.ApplyResources(Me.colTrigpointsCavesAndBranches, "colTrigpointsCavesAndBranches")
        Me.colTrigpointsCavesAndBranches.ColumnEdit = Me.txtTrigpointsCB
        Me.colTrigpointsCavesAndBranches.FieldName = "CavesAndBranchesHTML"
        Me.colTrigpointsCavesAndBranches.Name = "colTrigpointsCavesAndBranches"
        Me.colTrigpointsCavesAndBranches.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        '
        'txtGridCaveName
        '
        Me.txtGridCaveName.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.txtGridCaveName, "txtGridCaveName")
        Me.txtGridCaveName.Name = "txtGridCaveName"
        '
        'colSegmentsListCaveBranch
        '
        resources.ApplyResources(Me.colSegmentsListCaveBranch, "colSegmentsListCaveBranch")
        Me.colSegmentsListCaveBranch.MaxWidth = 10
        Me.colSegmentsListCaveBranch.MinWidth = 10
        Me.colSegmentsListCaveBranch.Name = "colSegmentsListCaveBranch"
        Me.colSegmentsListCaveBranch.OptionsColumn.AllowEdit = False
        Me.colSegmentsListCaveBranch.OptionsColumn.AllowFocus = False
        Me.colSegmentsListCaveBranch.OptionsColumn.AllowSize = False
        Me.colSegmentsListCaveBranch.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.colSegmentsListCaveBranch.OptionsColumn.FixedWidth = True
        Me.colSegmentsListCaveBranch.OptionsColumn.ReadOnly = True
        '
        'colSegmentsCave
        '
        resources.ApplyResources(Me.colSegmentsCave, "colSegmentsCave")
        Me.colSegmentsCave.FieldName = "Cave"
        Me.colSegmentsCave.Name = "colSegmentsCave"
        Me.colSegmentsCave.OptionsColumn.AllowEdit = False
        Me.colSegmentsCave.OptionsColumn.ReadOnly = True
        '
        'cTrigpointsGrid
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.grdTrigpoints)
        Me.Name = "cTrigpointsGrid"
        CType(Me.grdTrigpoints, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdViewTrigpoints, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTrigpointsSelected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTrigpointsSplay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.svgImages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTrigpointsCB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGridCaveName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grdTrigpoints As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdViewTrigpoints As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colSegmentsListCaveBranch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSegmentsCave As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtGridCaveName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents colTrigpointsSplay As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents svgImages As DevExpress.Utils.SvgImageCollection
    Friend WithEvents cboTrigpointsSplay As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents colTrigpointsCave As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtTrigpointsCB As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents colTrigpointsBranch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTrigpointsCavesAndBranches As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTrigpointsSelected As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTrigpointsName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkTrigpointsSelected As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
