<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cTrigpointsMultiselector
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cTrigpointsMultiselector))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.cSourceTrigpoints = New cSurveyPC.cTrigpointsGrid()
        Me.StandaloneBarDockControl2 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDest = New DevExpress.XtraBars.Bar()
        Me.btnRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRemoveAll = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barSource = New DevExpress.XtraBars.Bar()
        Me.btnAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnSplay = New DevExpress.XtraBars.BarCheckItem()
        Me.cboDistanceMode = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.cDestTrigpoints = New cSurveyPC.cTrigpointsGrid()
        Me.mnuSource = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.mnuDest = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel1.SuspendLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel2.SuspendLayout()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDistanceMode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuDest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1
        resources.ApplyResources(Me.SplitContainerControl1, "SplitContainerControl1")
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        '
        'SplitContainerControl1.Panel1
        '
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cSourceTrigpoints)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.StandaloneBarDockControl2)
        resources.ApplyResources(Me.SplitContainerControl1.Panel1, "SplitContainerControl1.Panel1")
        '
        'SplitContainerControl1.Panel2
        '
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.cDestTrigpoints)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.StandaloneBarDockControl1)
        resources.ApplyResources(Me.SplitContainerControl1.Panel2, "SplitContainerControl1.Panel2")
        Me.SplitContainerControl1.SplitterPosition = 362
        '
        'cSourceTrigpoints
        '
        resources.ApplyResources(Me.cSourceTrigpoints, "cSourceTrigpoints")
        Me.cSourceTrigpoints.FocusedItem = Nothing
        Me.cSourceTrigpoints.Name = "cSourceTrigpoints"
        Me.cSourceTrigpoints.Splay = False
        '
        'StandaloneBarDockControl2
        '
        resources.ApplyResources(Me.StandaloneBarDockControl2, "StandaloneBarDockControl2")
        Me.StandaloneBarDockControl2.CausesValidation = False
        Me.StandaloneBarDockControl2.IsVertical = True
        Me.StandaloneBarDockControl2.Manager = Me.BarManager
        Me.StandaloneBarDockControl2.Name = "StandaloneBarDockControl2"
        '
        'BarManager
        '
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.barDest, Me.barSource})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.DockControls.Add(Me.StandaloneBarDockControl1)
        Me.BarManager.DockControls.Add(Me.StandaloneBarDockControl2)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnAdd, Me.btnRemove, Me.btnRemoveAll, Me.btnSplay})
        Me.BarManager.MaxItemId = 11
        Me.BarManager.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cboDistanceMode})
        '
        'barDest
        '
        Me.barDest.BarName = "Destination"
        Me.barDest.DockCol = 0
        Me.barDest.DockRow = 0
        Me.barDest.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.barDest.FloatLocation = New System.Drawing.Point(620, 186)
        Me.barDest.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnRemove, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRemoveAll, True)})
        Me.barDest.OptionsBar.AllowQuickCustomization = False
        Me.barDest.OptionsBar.DisableClose = True
        Me.barDest.OptionsBar.DisableCustomization = True
        Me.barDest.OptionsBar.DrawDragBorder = False
        Me.barDest.OptionsBar.UseWholeRow = True
        Me.barDest.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        resources.ApplyResources(Me.barDest, "barDest")
        '
        'btnRemove
        '
        resources.ApplyResources(Me.btnRemove, "btnRemove")
        Me.btnRemove.Enabled = False
        Me.btnRemove.Id = 7
        Me.btnRemove.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_remove
        Me.btnRemove.Name = "btnRemove"
        '
        'btnRemoveAll
        '
        resources.ApplyResources(Me.btnRemoveAll, "btnRemoveAll")
        Me.btnRemoveAll.Enabled = False
        Me.btnRemoveAll.Id = 9
        Me.btnRemoveAll.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.clearall
        Me.btnRemoveAll.Name = "btnRemoveAll"
        '
        'StandaloneBarDockControl1
        '
        resources.ApplyResources(Me.StandaloneBarDockControl1, "StandaloneBarDockControl1")
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.IsVertical = True
        Me.StandaloneBarDockControl1.Manager = Me.BarManager
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        '
        'barSource
        '
        Me.barSource.BarName = "barSource"
        Me.barSource.DockCol = 0
        Me.barSource.DockRow = 0
        Me.barSource.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.barSource.FloatLocation = New System.Drawing.Point(579, 202)
        Me.barSource.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnAdd)})
        Me.barSource.OptionsBar.AllowQuickCustomization = False
        Me.barSource.OptionsBar.DisableClose = True
        Me.barSource.OptionsBar.DisableCustomization = True
        Me.barSource.OptionsBar.DrawDragBorder = False
        Me.barSource.OptionsBar.UseWholeRow = True
        Me.barSource.StandaloneBarDockControl = Me.StandaloneBarDockControl2
        resources.ApplyResources(Me.barSource, "barSource")
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Enabled = False
        Me.btnAdd.Id = 6
        Me.btnAdd.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_add
        Me.btnAdd.Name = "btnAdd"
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
        'btnSplay
        '
        resources.ApplyResources(Me.btnSplay, "btnSplay")
        Me.btnSplay.Id = 10
        Me.btnSplay.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.splay
        Me.btnSplay.Name = "btnSplay"
        '
        'cboDistanceMode
        '
        resources.ApplyResources(Me.cboDistanceMode, "cboDistanceMode")
        Me.cboDistanceMode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboDistanceMode.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboDistanceMode.Items.AddRange(New Object() {resources.GetString("cboDistanceMode.Items"), resources.GetString("cboDistanceMode.Items1"), resources.GetString("cboDistanceMode.Items2"), resources.GetString("cboDistanceMode.Items3"), resources.GetString("cboDistanceMode.Items4"), resources.GetString("cboDistanceMode.Items5"), resources.GetString("cboDistanceMode.Items6")})
        Me.cboDistanceMode.Name = "cboDistanceMode"
        Me.cboDistanceMode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'cDestTrigpoints
        '
        resources.ApplyResources(Me.cDestTrigpoints, "cDestTrigpoints")
        Me.cDestTrigpoints.FocusedItem = Nothing
        Me.cDestTrigpoints.Name = "cDestTrigpoints"
        Me.cDestTrigpoints.Splay = False
        '
        'mnuSource
        '
        Me.mnuSource.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnAdd), New DevExpress.XtraBars.LinkPersistInfo(Me.btnSplay, True)})
        Me.mnuSource.Manager = Me.BarManager
        Me.mnuSource.Name = "mnuSource"
        '
        'mnuDest
        '
        Me.mnuDest.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnRemove), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRemoveAll, True)})
        Me.mnuDest.Manager = Me.BarManager
        Me.mnuDest.Name = "mnuDest"
        '
        'cTrigpointsMultiselector
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "cTrigpointsMultiselector"
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel1.ResumeLayout(False)
        Me.SplitContainerControl1.Panel1.PerformLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel2.ResumeLayout(False)
        Me.SplitContainerControl1.Panel2.PerformLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDistanceMode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuDest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents cSourceTrigpoints As cTrigpointsGrid
    Friend WithEvents cDestTrigpoints As cTrigpointsGrid
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents cboDistanceMode As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents barDest As DevExpress.XtraBars.Bar
    Friend WithEvents btnAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRemoveAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents StandaloneBarDockControl2 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents barSource As DevExpress.XtraBars.Bar
    Friend WithEvents mnuSource As DevExpress.XtraBars.PopupMenu
    Friend WithEvents mnuDest As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnSplay As DevExpress.XtraBars.BarCheckItem
End Class
