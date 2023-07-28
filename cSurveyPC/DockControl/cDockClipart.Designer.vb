Imports System.ComponentModel
Imports cSurveyPC.cSurvey

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cDockClipart
    Inherits DevExpress.XtraEditors.XtraUserControl

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            For Each oitem As DevExpress.XtraBars.Navigation.TabNavigationPage In tabGallery.Pages
                Dim oItems As BindingList(Of cGalleryItem) = DirectCast(oitem.Tag, cGallery).Grid.DataSource
                Call pDisposeItems(oItems)
            Next
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDockClipart))
        Me.spMain = New DevExpress.XtraEditors.SplitContainerControl()
        Me.tabGallery = New DevExpress.XtraBars.Navigation.TabPane()
        Me.prpProperties = New DevExpress.XtraVerticalGrid.PropertyGridControl()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barMain = New DevExpress.XtraBars.Bar()
        Me.btnAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.btnViewGallery = New DevExpress.XtraBars.BarCheckItem()
        Me.btnViewSurvey = New DevExpress.XtraBars.BarCheckItem()
        Me.btnEditMetadata = New DevExpress.XtraBars.BarCheckItem()
        Me.btnRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnOpenInExplorer = New DevExpress.XtraBars.BarButtonItem()
        Me.btnReplaceWith = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuGridContext = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.spMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spMain.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spMain.Panel1.SuspendLayout()
        CType(Me.spMain.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spMain.Panel2.SuspendLayout()
        Me.spMain.SuspendLayout()
        CType(Me.tabGallery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.prpProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuGridContext, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'spMain
        '
        Me.spMain.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2
        resources.ApplyResources(Me.spMain, "spMain")
        Me.spMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2
        Me.spMain.IsSplitterFixed = True
        Me.spMain.Name = "spMain"
        '
        'spMain.Panel1
        '
        Me.spMain.Panel1.Controls.Add(Me.tabGallery)
        '
        'spMain.Panel2
        '
        Me.spMain.Panel2.Controls.Add(Me.prpProperties)
        Me.spMain.SplitterPosition = 320
        '
        'tabGallery
        '
        resources.ApplyResources(Me.tabGallery, "tabGallery")
        Me.tabGallery.Name = "tabGallery"
        Me.tabGallery.RegularSize = New System.Drawing.Size(676, 432)
        Me.tabGallery.SelectedPage = Nothing
        '
        'prpProperties
        '
        Me.prpProperties.ActiveViewType = DevExpress.XtraVerticalGrid.PropertyGridView.Office
        Me.prpProperties.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.prpProperties, "prpProperties")
        Me.prpProperties.MenuManager = Me.BarManager
        Me.prpProperties.Name = "prpProperties"
        Me.prpProperties.OptionsView.AllowReadOnlyRowAppearance = DevExpress.Utils.DefaultBoolean.[True]
        '
        'BarManager
        '
        Me.BarManager.AllowCustomization = False
        Me.BarManager.AllowQuickCustomization = False
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.barMain})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnAdd, Me.btnRemove, Me.btnRefresh, Me.btnEditMetadata, Me.btnViewGallery, Me.btnViewSurvey, Me.btnOpenInExplorer, Me.btnReplaceWith})
        Me.BarManager.MaxItemId = 9
        '
        'barMain
        '
        Me.barMain.BarName = "Tools"
        Me.barMain.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Me.barMain.DockCol = 0
        Me.barMain.DockRow = 0
        Me.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.barMain.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnAdd), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRemove, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnViewGallery, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnViewSurvey), New DevExpress.XtraBars.LinkPersistInfo(Me.btnEditMetadata, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRefresh, True)})
        Me.barMain.OptionsBar.AllowQuickCustomization = False
        Me.barMain.OptionsBar.DisableClose = True
        Me.barMain.OptionsBar.DisableCustomization = True
        Me.barMain.OptionsBar.DrawDragBorder = False
        Me.barMain.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.barMain, "barMain")
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Enabled = False
        Me.btnAdd.Id = 0
        Me.btnAdd.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.addfile
        Me.btnAdd.Name = "btnAdd"
        '
        'btnRemove
        '
        resources.ApplyResources(Me.btnRemove, "btnRemove")
        Me.btnRemove.Enabled = False
        Me.btnRemove.Id = 1
        Me.btnRemove.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.delete1
        Me.btnRemove.Name = "btnRemove"
        '
        'btnViewGallery
        '
        Me.btnViewGallery.BindableChecked = True
        resources.ApplyResources(Me.btnViewGallery, "btnViewGallery")
        Me.btnViewGallery.Checked = True
        Me.btnViewGallery.Id = 5
        Me.btnViewGallery.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.customercontactdirectory
        Me.btnViewGallery.Name = "btnViewGallery"
        '
        'btnViewSurvey
        '
        resources.ApplyResources(Me.btnViewSurvey, "btnViewSurvey")
        Me.btnViewSurvey.Id = 6
        Me.btnViewSurvey.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.bo_list
        Me.btnViewSurvey.Name = "btnViewSurvey"
        '
        'btnEditMetadata
        '
        resources.ApplyResources(Me.btnEditMetadata, "btnEditMetadata")
        Me.btnEditMetadata.Id = 4
        Me.btnEditMetadata.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.customizemergefield
        Me.btnEditMetadata.Name = "btnEditMetadata"
        '
        'btnRefresh
        '
        resources.ApplyResources(Me.btnRefresh, "btnRefresh")
        Me.btnRefresh.Id = 2
        Me.btnRefresh.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_refresh
        Me.btnRefresh.Name = "btnRefresh"
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
        'btnOpenInExplorer
        '
        resources.ApplyResources(Me.btnOpenInExplorer, "btnOpenInExplorer")
        Me.btnOpenInExplorer.Id = 7
        Me.btnOpenInExplorer.Name = "btnOpenInExplorer"
        '
        'btnReplaceWith
        '
        resources.ApplyResources(Me.btnReplaceWith, "btnReplaceWith")
        Me.btnReplaceWith.Enabled = False
        Me.btnReplaceWith.Id = 8
        Me.btnReplaceWith.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.replace
        Me.btnReplaceWith.Name = "btnReplaceWith"
        Me.btnReplaceWith.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'mnuGridContext
        '
        Me.mnuGridContext.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnAdd), New DevExpress.XtraBars.LinkPersistInfo(Me.btnReplaceWith), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRemove, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnEditMetadata, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnOpenInExplorer, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRefresh, True)})
        Me.mnuGridContext.Manager = Me.BarManager
        Me.mnuGridContext.Name = "mnuGridContext"
        '
        'cDockClipart
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.spMain)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "cDockClipart"
        CType(Me.spMain.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spMain.Panel1.ResumeLayout(False)
        CType(Me.spMain.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spMain.Panel2.ResumeLayout(False)
        CType(Me.spMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spMain.ResumeLayout(False)
        CType(Me.tabGallery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.prpProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuGridContext, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents spMain As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barMain As DevExpress.XtraBars.Bar
    Friend WithEvents btnAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnEditMetadata As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnViewGallery As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnViewSurvey As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents prpProperties As DevExpress.XtraVerticalGrid.PropertyGridControl
    Friend WithEvents btnOpenInExplorer As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuGridContext As DevExpress.XtraBars.PopupMenu
    Friend WithEvents tabGallery As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents btnReplaceWith As DevExpress.XtraBars.BarButtonItem
End Class
