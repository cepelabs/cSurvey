<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cDesignSurfaceControl
    Inherits cDesignPropertyControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDesignSurfaceControl))
        Me.chkSurface = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdSurfaceEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlSurface = New DevExpress.XtraEditors.PanelControl()
        Me.pnlLayers = New DevExpress.XtraEditors.PanelControl()
        Me.grdSurfaceLayers = New DevExpress.XtraGrid.GridControl()
        Me.grdViewSurfaceLayers = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colLayerVisible = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkLayerVisible = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colLayerImage = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.picLayerImage = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.colLayerName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdSurfaceLayersEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdSurfaceLayersDown = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdSurfaceLayersUp = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlElevations = New DevExpress.XtraEditors.PanelControl()
        Me.cboSurfaceElevationsLayers = New cSurveyPC.cElevationDropDown()
        Me.lbl3dSurfaceTransparency = New DevExpress.XtraEditors.LabelControl()
        Me.trkTransparency = New DevExpress.XtraEditors.TrackBarControl()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnSelectAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDeselectAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.btnEdit = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSurface = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuContext = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.chkSurface.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSurface, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSurface.SuspendLayout()
        CType(Me.pnlLayers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLayers.SuspendLayout()
        CType(Me.grdSurfaceLayers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdViewSurfaceLayers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLayerVisible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLayerImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlElevations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlElevations.SuspendLayout()
        CType(Me.trkTransparency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkTransparency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkSurface
        '
        resources.ApplyResources(Me.chkSurface, "chkSurface")
        Me.chkSurface.Name = "chkSurface"
        Me.chkSurface.Properties.Caption = resources.GetString("chkSurface.Properties.Caption")
        '
        'cmdSurfaceEdit
        '
        resources.ApplyResources(Me.cmdSurfaceEdit, "cmdSurfaceEdit")
        Me.cmdSurfaceEdit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdSurfaceEdit.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.soilmodel
        Me.cmdSurfaceEdit.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdSurfaceEdit.Name = "cmdSurfaceEdit"
        '
        'pnlSurface
        '
        resources.ApplyResources(Me.pnlSurface, "pnlSurface")
        Me.pnlSurface.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlSurface.Controls.Add(Me.pnlLayers)
        Me.pnlSurface.Controls.Add(Me.pnlElevations)
        Me.pnlSurface.Name = "pnlSurface"
        '
        'pnlLayers
        '
        Me.pnlLayers.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlLayers.Controls.Add(Me.grdSurfaceLayers)
        Me.pnlLayers.Controls.Add(Me.cmdSurfaceLayersEdit)
        Me.pnlLayers.Controls.Add(Me.cmdSurfaceLayersDown)
        Me.pnlLayers.Controls.Add(Me.cmdSurfaceLayersUp)
        resources.ApplyResources(Me.pnlLayers, "pnlLayers")
        Me.pnlLayers.Name = "pnlLayers"
        '
        'grdSurfaceLayers
        '
        resources.ApplyResources(Me.grdSurfaceLayers, "grdSurfaceLayers")
        Me.grdSurfaceLayers.MainView = Me.grdViewSurfaceLayers
        Me.grdSurfaceLayers.Name = "grdSurfaceLayers"
        Me.grdSurfaceLayers.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chkLayerVisible, Me.picLayerImage})
        Me.grdSurfaceLayers.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdViewSurfaceLayers})
        '
        'grdViewSurfaceLayers
        '
        Me.grdViewSurfaceLayers.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colLayerVisible, Me.colLayerImage, Me.colLayerName})
        Me.grdViewSurfaceLayers.GridControl = Me.grdSurfaceLayers
        Me.grdViewSurfaceLayers.Name = "grdViewSurfaceLayers"
        Me.grdViewSurfaceLayers.OptionsCustomization.AllowGroup = False
        Me.grdViewSurfaceLayers.OptionsCustomization.AllowSort = False
        Me.grdViewSurfaceLayers.OptionsView.ShowGroupPanel = False
        Me.grdViewSurfaceLayers.OptionsView.ShowIndicator = False
        '
        'colLayerVisible
        '
        resources.ApplyResources(Me.colLayerVisible, "colLayerVisible")
        Me.colLayerVisible.ColumnEdit = Me.chkLayerVisible
        Me.colLayerVisible.FieldName = "Visible"
        Me.colLayerVisible.MaxWidth = 24
        Me.colLayerVisible.MinWidth = 24
        Me.colLayerVisible.Name = "colLayerVisible"
        Me.colLayerVisible.OptionsColumn.FixedWidth = True
        '
        'chkLayerVisible
        '
        resources.ApplyResources(Me.chkLayerVisible, "chkLayerVisible")
        Me.chkLayerVisible.Name = "chkLayerVisible"
        '
        'colLayerImage
        '
        resources.ApplyResources(Me.colLayerImage, "colLayerImage")
        Me.colLayerImage.ColumnEdit = Me.picLayerImage
        Me.colLayerImage.FieldName = "Image"
        Me.colLayerImage.MaxWidth = 24
        Me.colLayerImage.MinWidth = 24
        Me.colLayerImage.Name = "colLayerImage"
        Me.colLayerImage.OptionsColumn.AllowEdit = False
        Me.colLayerImage.OptionsColumn.FixedWidth = True
        Me.colLayerImage.OptionsColumn.ReadOnly = True
        Me.colLayerImage.UnboundType = DevExpress.Data.UnboundColumnType.[Object]
        '
        'picLayerImage
        '
        Me.picLayerImage.Name = "picLayerImage"
        Me.picLayerImage.SvgImageSize = New System.Drawing.Size(16, 16)
        '
        'colLayerName
        '
        resources.ApplyResources(Me.colLayerName, "colLayerName")
        Me.colLayerName.FieldName = "Name"
        Me.colLayerName.Name = "colLayerName"
        Me.colLayerName.OptionsColumn.AllowEdit = False
        Me.colLayerName.OptionsColumn.ReadOnly = True
        Me.colLayerName.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'cmdSurfaceLayersEdit
        '
        resources.ApplyResources(Me.cmdSurfaceLayersEdit, "cmdSurfaceLayersEdit")
        Me.cmdSurfaceLayersEdit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdSurfaceLayersEdit.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.edit
        Me.cmdSurfaceLayersEdit.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdSurfaceLayersEdit.Name = "cmdSurfaceLayersEdit"
        '
        'cmdSurfaceLayersDown
        '
        resources.ApplyResources(Me.cmdSurfaceLayersDown, "cmdSurfaceLayersDown")
        Me.cmdSurfaceLayersDown.ImageOptions.Image = CType(resources.GetObject("cmdSurfaceLayersDown.ImageOptions.Image"), System.Drawing.Image)
        Me.cmdSurfaceLayersDown.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdSurfaceLayersDown.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.movedown
        Me.cmdSurfaceLayersDown.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdSurfaceLayersDown.Name = "cmdSurfaceLayersDown"
        '
        'cmdSurfaceLayersUp
        '
        resources.ApplyResources(Me.cmdSurfaceLayersUp, "cmdSurfaceLayersUp")
        Me.cmdSurfaceLayersUp.ImageOptions.Image = CType(resources.GetObject("cmdSurfaceLayersUp.ImageOptions.Image"), System.Drawing.Image)
        Me.cmdSurfaceLayersUp.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdSurfaceLayersUp.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.moveup
        Me.cmdSurfaceLayersUp.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdSurfaceLayersUp.Name = "cmdSurfaceLayersUp"
        '
        'pnlElevations
        '
        Me.pnlElevations.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlElevations.Controls.Add(Me.cboSurfaceElevationsLayers)
        Me.pnlElevations.Controls.Add(Me.lbl3dSurfaceTransparency)
        Me.pnlElevations.Controls.Add(Me.trkTransparency)
        resources.ApplyResources(Me.pnlElevations, "pnlElevations")
        Me.pnlElevations.Name = "pnlElevations"
        '
        'cboSurfaceElevationsLayers
        '
        resources.ApplyResources(Me.cboSurfaceElevationsLayers, "cboSurfaceElevationsLayers")
        Me.cboSurfaceElevationsLayers.Name = "cboSurfaceElevationsLayers"
        '
        'lbl3dSurfaceTransparency
        '
        resources.ApplyResources(Me.lbl3dSurfaceTransparency, "lbl3dSurfaceTransparency")
        Me.lbl3dSurfaceTransparency.Name = "lbl3dSurfaceTransparency"
        '
        'trkTransparency
        '
        resources.ApplyResources(Me.trkTransparency, "trkTransparency")
        Me.trkTransparency.Name = "trkTransparency"
        Me.trkTransparency.Properties.AutoSize = False
        Me.trkTransparency.Properties.LabelAppearance.Options.UseTextOptions = True
        Me.trkTransparency.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.trkTransparency.Properties.Maximum = 255
        Me.trkTransparency.Properties.TickFrequency = 15
        '
        'BarManager
        '
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnSelectAll, Me.btnDeselectAll, Me.btnRefresh, Me.btnEdit, Me.btnSurface})
        Me.BarManager.MaxItemId = 5
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
        'btnSelectAll
        '
        Me.btnSelectAll.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left
        resources.ApplyResources(Me.btnSelectAll, "btnSelectAll")
        Me.btnSelectAll.Id = 0
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'btnDeselectAll
        '
        Me.btnDeselectAll.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left
        resources.ApplyResources(Me.btnDeselectAll, "btnDeselectAll")
        Me.btnDeselectAll.Id = 1
        Me.btnDeselectAll.Name = "btnDeselectAll"
        Me.btnDeselectAll.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'btnRefresh
        '
        Me.btnRefresh.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left
        resources.ApplyResources(Me.btnRefresh, "btnRefresh")
        Me.btnRefresh.Id = 2
        Me.btnRefresh.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_refresh
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'btnEdit
        '
        resources.ApplyResources(Me.btnEdit, "btnEdit")
        Me.btnEdit.Id = 3
        Me.btnEdit.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.edit
        Me.btnEdit.Name = "btnEdit"
        '
        'btnSurface
        '
        resources.ApplyResources(Me.btnSurface, "btnSurface")
        Me.btnSurface.Id = 4
        Me.btnSurface.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.soilmodel
        Me.btnSurface.Name = "btnSurface"
        '
        'mnuContext
        '
        Me.mnuContext.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnSurface), New DevExpress.XtraBars.LinkPersistInfo(Me.btnEdit, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnSelectAll, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDeselectAll), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRefresh, True)})
        Me.mnuContext.Manager = Me.BarManager
        Me.mnuContext.Name = "mnuContext"
        '
        'cDesignSurfaceControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.chkSurface)
        Me.Controls.Add(Me.cmdSurfaceEdit)
        Me.Controls.Add(Me.pnlSurface)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "cDesignSurfaceControl"
        CType(Me.chkSurface.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSurface, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSurface.ResumeLayout(False)
        CType(Me.pnlLayers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLayers.ResumeLayout(False)
        CType(Me.grdSurfaceLayers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdViewSurfaceLayers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLayerVisible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLayerImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlElevations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlElevations.ResumeLayout(False)
        Me.pnlElevations.PerformLayout()
        CType(Me.trkTransparency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkTransparency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkSurface As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cmdSurfaceEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlSurface As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lbl3dSurfaceTransparency As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdSurfaceLayersEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSurfaceLayersUp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSurfaceLayersDown As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlLayers As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlElevations As DevExpress.XtraEditors.PanelControl
    Friend WithEvents grdSurfaceLayers As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdViewSurfaceLayers As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colLayerVisible As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLayerName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkLayerVisible As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents trkTransparency As DevExpress.XtraEditors.TrackBarControl
    Friend WithEvents colLayerImage As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents picLayerImage As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnSelectAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnDeselectAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuContext As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnEdit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnSurface As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cboSurfaceElevationsLayers As cElevationDropDown
End Class
