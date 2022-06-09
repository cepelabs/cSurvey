<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cDockDistances
    Inherits DevExpress.XtraEditors.XtraUserControl

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDockDistances))
        Me.pnlData = New DevExpress.XtraEditors.PanelControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDistances = New DevExpress.XtraBars.Bar()
        Me.btnFilter = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDistanceMode = New DevExpress.XtraBars.BarEditItem()
        Me.cboDistanceMode = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.btnRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.barView = New DevExpress.XtraBars.Bar()
        Me.btnViewGrid = New DevExpress.XtraBars.BarCheckItem()
        Me.btnViewHeatmap = New DevExpress.XtraBars.BarCheckItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.HeatmapControl1 = New DevExpress.XtraCharts.Heatmap.HeatmapControl()
        Me.toolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.pnlFooter = New DevExpress.XtraEditors.PanelControl()
        CType(Me.pnlData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlData.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDistanceMode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlFooter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlData
        '
        Me.pnlData.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlData.Controls.Add(Me.GridControl1)
        Me.pnlData.Controls.Add(Me.HeatmapControl1)
        Me.pnlData.Controls.Add(Me.StandaloneBarDockControl1)
        resources.ApplyResources(Me.pnlData, "pnlData")
        Me.pnlData.Name = "pnlData"
        '
        'GridControl1
        '
        resources.ApplyResources(Me.GridControl1, "GridControl1")
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.MenuManager = Me.BarManager
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'BarManager
        '
        Me.BarManager.AllowCustomization = False
        Me.BarManager.AllowQuickCustomization = False
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.barDistances, Me.barView})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.DockControls.Add(Me.StandaloneBarDockControl1)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnRefresh, Me.btnFilter, Me.btnDistanceMode, Me.btnViewHeatmap, Me.btnViewGrid})
        Me.BarManager.MaxItemId = 6
        Me.BarManager.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cboDistanceMode})
        '
        'barDistances
        '
        Me.barDistances.BarName = "Tools"
        Me.barDistances.DockCol = 0
        Me.barDistances.DockRow = 0
        Me.barDistances.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.barDistances.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnFilter), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDistanceMode, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRefresh)})
        Me.barDistances.OptionsBar.AllowQuickCustomization = False
        Me.barDistances.OptionsBar.DisableClose = True
        Me.barDistances.OptionsBar.DisableCustomization = True
        Me.barDistances.OptionsBar.DrawDragBorder = False
        Me.barDistances.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.barDistances, "barDistances")
        '
        'btnFilter
        '
        resources.ApplyResources(Me.btnFilter, "btnFilter")
        Me.btnFilter.Id = 2
        Me.btnFilter.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.distance_filter
        Me.btnFilter.Name = "btnFilter"
        '
        'btnDistanceMode
        '
        resources.ApplyResources(Me.btnDistanceMode, "btnDistanceMode")
        Me.btnDistanceMode.Edit = Me.cboDistanceMode
        Me.btnDistanceMode.Id = 3
        Me.btnDistanceMode.Name = "btnDistanceMode"
        Me.btnDistanceMode.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption
        '
        'cboDistanceMode
        '
        resources.ApplyResources(Me.cboDistanceMode, "cboDistanceMode")
        Me.cboDistanceMode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboDistanceMode.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboDistanceMode.Items.AddRange(New Object() {resources.GetString("cboDistanceMode.Items"), resources.GetString("cboDistanceMode.Items1"), resources.GetString("cboDistanceMode.Items2"), resources.GetString("cboDistanceMode.Items3"), resources.GetString("cboDistanceMode.Items4"), resources.GetString("cboDistanceMode.Items5"), resources.GetString("cboDistanceMode.Items6")})
        Me.cboDistanceMode.Name = "cboDistanceMode"
        Me.cboDistanceMode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'btnRefresh
        '
        resources.ApplyResources(Me.btnRefresh, "btnRefresh")
        Me.btnRefresh.Id = 0
        Me.btnRefresh.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_refresh
        Me.btnRefresh.Name = "btnRefresh"
        '
        'barView
        '
        Me.barView.BarName = "View"
        Me.barView.DockCol = 0
        Me.barView.DockRow = 0
        Me.barView.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.barView.FloatLocation = New System.Drawing.Point(286, 395)
        Me.barView.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnViewGrid), New DevExpress.XtraBars.LinkPersistInfo(Me.btnViewHeatmap)})
        Me.barView.OptionsBar.AllowQuickCustomization = False
        Me.barView.OptionsBar.DisableClose = True
        Me.barView.OptionsBar.DisableCustomization = True
        Me.barView.OptionsBar.DrawDragBorder = False
        Me.barView.OptionsBar.UseWholeRow = True
        Me.barView.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        resources.ApplyResources(Me.barView, "barView")
        '
        'btnViewGrid
        '
        Me.btnViewGrid.BindableChecked = True
        resources.ApplyResources(Me.btnViewGrid, "btnViewGrid")
        Me.btnViewGrid.Checked = True
        Me.btnViewGrid.GroupIndex = 1
        Me.btnViewGrid.Id = 5
        Me.btnViewGrid.Name = "btnViewGrid"
        '
        'btnViewHeatmap
        '
        resources.ApplyResources(Me.btnViewHeatmap, "btnViewHeatmap")
        Me.btnViewHeatmap.GroupIndex = 1
        Me.btnViewHeatmap.Id = 4
        Me.btnViewHeatmap.Name = "btnViewHeatmap"
        '
        'StandaloneBarDockControl1
        '
        resources.ApplyResources(Me.StandaloneBarDockControl1, "StandaloneBarDockControl1")
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Manager = Me.BarManager
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        resources.ApplyResources(Me.barDockControlTop, "barDockControlTop")
        Me.barDockControlTop.Manager = Me.BarManager
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        resources.ApplyResources(Me.barDockControlBottom, "barDockControlBottom")
        Me.barDockControlBottom.Manager = Me.BarManager
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        resources.ApplyResources(Me.barDockControlLeft, "barDockControlLeft")
        Me.barDockControlLeft.Manager = Me.BarManager
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        resources.ApplyResources(Me.barDockControlRight, "barDockControlRight")
        Me.barDockControlRight.Manager = Me.BarManager
        '
        'HeatmapControl1
        '
        Me.HeatmapControl1.EnableAxisXScrolling = True
        Me.HeatmapControl1.EnableAxisXZooming = True
        Me.HeatmapControl1.EnableAxisYScrolling = True
        Me.HeatmapControl1.EnableAxisYZooming = True
        Me.HeatmapControl1.HighlightMode = DevExpress.XtraCharts.Heatmap.HeatmapHighlightMode.RowAndColumn
        Me.HeatmapControl1.Label.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.HeatmapControl1.Label.Pattern = "{V:N2}"
        Me.HeatmapControl1.Label.Visible = True
        Me.HeatmapControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[False]
        resources.ApplyResources(Me.HeatmapControl1, "HeatmapControl1")
        Me.HeatmapControl1.Name = "HeatmapControl1"
        Me.HeatmapControl1.ToolTipController = Me.toolTipController1
        Me.HeatmapControl1.ToolTipEnabled = True
        '
        'toolTipController1
        '
        '
        'pnlFooter
        '
        Me.pnlFooter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        resources.ApplyResources(Me.pnlFooter, "pnlFooter")
        Me.pnlFooter.Name = "pnlFooter"
        '
        'cDockDistances
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.pnlData)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "cDockDistances"
        CType(Me.pnlData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlData.ResumeLayout(False)
        Me.pnlData.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDistanceMode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlFooter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlData As DevExpress.XtraEditors.PanelControl
    Friend WithEvents HeatmapControl1 As DevExpress.XtraCharts.Heatmap.HeatmapControl
    Private WithEvents toolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDistances As DevExpress.XtraBars.Bar
    Friend WithEvents btnRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnFilter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnDistanceMode As DevExpress.XtraBars.BarEditItem
    Friend WithEvents cboDistanceMode As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pnlFooter As DevExpress.XtraEditors.PanelControl
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents barView As DevExpress.XtraBars.Bar
    Friend WithEvents btnViewHeatmap As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnViewGrid As DevExpress.XtraBars.BarCheckItem
End Class
