<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmManageWorkspaces
    Inherits cForm

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageWorkspaces))
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.cmdSaveAs = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdImport = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdExport = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdRestore = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.mnuWorkspace = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.grdWorkspaces = New DevExpress.XtraGrid.GridControl()
        Me.grdWorkspacesView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colGridWorkspacesName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuWorkspace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdWorkspaces, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdWorkspacesView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        resources.ApplyResources(Me.cmdExit, "cmdExit")
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.Name = "cmdExit"
        '
        'BarManager
        '
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.cmdSaveAs, Me.cmdImport, Me.cmdExport, Me.cmdRestore, Me.cmdDelete})
        Me.BarManager.MaxItemId = 15
        '
        'Bar1
        '
        Me.Bar1.BarName = "Custom 2"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.FloatLocation = New System.Drawing.Point(451, 467)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.cmdSaveAs), New DevExpress.XtraBars.LinkPersistInfo(Me.cmdDelete, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cmdImport, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cmdExport), New DevExpress.XtraBars.LinkPersistInfo(Me.cmdRestore, True)})
        Me.Bar1.OptionsBar.AllowQuickCustomization = False
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.Bar1, "Bar1")
        '
        'cmdSaveAs
        '
        resources.ApplyResources(Me.cmdSaveAs, "cmdSaveAs")
        Me.cmdSaveAs.Id = 9
        Me.cmdSaveAs.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.captureworkspace
        Me.cmdSaveAs.Name = "cmdSaveAs"
        '
        'cmdDelete
        '
        resources.ApplyResources(Me.cmdDelete, "cmdDelete")
        Me.cmdDelete.Enabled = False
        Me.cmdDelete.Id = 14
        Me.cmdDelete.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.delete1
        Me.cmdDelete.Name = "cmdDelete"
        '
        'cmdImport
        '
        resources.ApplyResources(Me.cmdImport, "cmdImport")
        Me.cmdImport.Id = 10
        Me.cmdImport.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.import
        Me.cmdImport.Name = "cmdImport"
        '
        'cmdExport
        '
        resources.ApplyResources(Me.cmdExport, "cmdExport")
        Me.cmdExport.Enabled = False
        Me.cmdExport.Id = 11
        Me.cmdExport.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.exportfile
        Me.cmdExport.Name = "cmdExport"
        '
        'cmdRestore
        '
        resources.ApplyResources(Me.cmdRestore, "cmdRestore")
        Me.cmdRestore.Enabled = False
        Me.cmdRestore.Id = 12
        Me.cmdRestore.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.bo_position
        Me.cmdRestore.Name = "cmdRestore"
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
        'mnuWorkspace
        '
        Me.mnuWorkspace.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.cmdDelete), New DevExpress.XtraBars.LinkPersistInfo(Me.cmdExport, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cmdRestore, True)})
        Me.mnuWorkspace.Manager = Me.BarManager
        Me.mnuWorkspace.Name = "mnuWorkspace"
        '
        'grdWorkspaces
        '
        resources.ApplyResources(Me.grdWorkspaces, "grdWorkspaces")
        Me.grdWorkspaces.MainView = Me.grdWorkspacesView
        Me.grdWorkspaces.MenuManager = Me.BarManager
        Me.grdWorkspaces.Name = "grdWorkspaces"
        Me.grdWorkspaces.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdWorkspacesView})
        '
        'grdWorkspacesView
        '
        Me.grdWorkspacesView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colGridWorkspacesName})
        Me.grdWorkspacesView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        Me.grdWorkspacesView.GridControl = Me.grdWorkspaces
        Me.grdWorkspacesView.Name = "grdWorkspacesView"
        Me.grdWorkspacesView.OptionsBehavior.Editable = False
        Me.grdWorkspacesView.OptionsBehavior.ReadOnly = True
        Me.grdWorkspacesView.OptionsView.ShowGroupPanel = False
        Me.grdWorkspacesView.OptionsView.ShowIndicator = False
        '
        'colGridWorkspacesName
        '
        resources.ApplyResources(Me.colGridWorkspacesName, "colGridWorkspacesName")
        Me.colGridWorkspacesName.FieldName = "Name"
        Me.colGridWorkspacesName.Name = "colGridWorkspacesName"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.cmdExit)
        resources.ApplyResources(Me.PanelControl1, "PanelControl1")
        Me.PanelControl1.Name = "PanelControl1"
        '
        'frmManageWorkspaces
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdExit
        Me.Controls.Add(Me.grdWorkspaces)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.manageworkspaces
        Me.Name = "frmManageWorkspaces"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuWorkspace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdWorkspaces, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdWorkspacesView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents cmdSaveAs As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdImport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdRestore As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents mnuWorkspace As DevExpress.XtraBars.PopupMenu
    Friend WithEvents cmdDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents grdWorkspaces As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdWorkspacesView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colGridWorkspacesName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
End Class
