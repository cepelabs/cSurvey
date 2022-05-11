<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLinkedSurveysRelink
    Inherits cForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLinkedSurveysRelink))
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions2 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject8 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.tvLinkedSurveys = New BrightIdeasSoftware.ObjectListView()
        Me.colLinkedSurveysIcon = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLinkedSurveysFilename = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLinkedSurveysNewIcon = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLinkedSurveysNewFilename = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.txtCurrentPath = New System.Windows.Forms.TextBox()
        Me.lblCurrentPath = New System.Windows.Forms.Label()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnChangePath = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSelectAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSelectAllBrokenLink = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDeselectAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnChangeFile = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCancel = New DevExpress.XtraBars.BarButtonItem()
        Me.btnChangeCommonPath = New DevExpress.XtraBars.BarButtonItem()
        Me.txtReplacePath = New DevExpress.XtraEditors.Repository.RepositoryItemBreadCrumbEdit()
        Me.mnuRelink = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.tvLinkedSurveys, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReplacePath, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuRelink, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'tvLinkedSurveys
        '
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysIcon)
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysFilename)
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysNewIcon)
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysNewFilename)
        Me.tvLinkedSurveys.AllowDrop = True
        Me.tvLinkedSurveys.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvLinkedSurveys.CellEditUseWholeCell = False
        Me.tvLinkedSurveys.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colLinkedSurveysIcon, Me.colLinkedSurveysFilename, Me.colLinkedSurveysNewIcon, Me.colLinkedSurveysNewFilename})
        Me.tvLinkedSurveys.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.tvLinkedSurveys, "tvLinkedSurveys")
        Me.tvLinkedSurveys.FullRowSelect = True
        Me.tvLinkedSurveys.HideSelection = False
        Me.tvLinkedSurveys.IsSimpleDragSource = True
        Me.tvLinkedSurveys.IsSimpleDropSink = True
        Me.tvLinkedSurveys.Name = "tvLinkedSurveys"
        Me.tvLinkedSurveys.ShowGroups = False
        Me.tvLinkedSurveys.UseCompatibleStateImageBehavior = False
        Me.tvLinkedSurveys.View = System.Windows.Forms.View.Details
        Me.tvLinkedSurveys.VirtualMode = True
        '
        'colLinkedSurveysIcon
        '
        Me.colLinkedSurveysIcon.IsEditable = False
        resources.ApplyResources(Me.colLinkedSurveysIcon, "colLinkedSurveysIcon")
        '
        'colLinkedSurveysFilename
        '
        Me.colLinkedSurveysFilename.IsEditable = False
        resources.ApplyResources(Me.colLinkedSurveysFilename, "colLinkedSurveysFilename")
        '
        'colLinkedSurveysNewIcon
        '
        Me.colLinkedSurveysNewIcon.IsEditable = False
        resources.ApplyResources(Me.colLinkedSurveysNewIcon, "colLinkedSurveysNewIcon")
        '
        'colLinkedSurveysNewFilename
        '
        Me.colLinkedSurveysNewFilename.IsEditable = False
        resources.ApplyResources(Me.colLinkedSurveysNewFilename, "colLinkedSurveysNewFilename")
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdOk)
        Me.Panel1.Controls.Add(Me.cmdCancel)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.txtCurrentPath)
        Me.pnlHeader.Controls.Add(Me.lblCurrentPath)
        resources.ApplyResources(Me.pnlHeader, "pnlHeader")
        Me.pnlHeader.Name = "pnlHeader"
        '
        'txtCurrentPath
        '
        resources.ApplyResources(Me.txtCurrentPath, "txtCurrentPath")
        Me.txtCurrentPath.Name = "txtCurrentPath"
        Me.txtCurrentPath.ReadOnly = True
        '
        'lblCurrentPath
        '
        resources.ApplyResources(Me.lblCurrentPath, "lblCurrentPath")
        Me.lblCurrentPath.Name = "lblCurrentPath"
        '
        'BarManager
        '
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnChangePath, Me.btnSelectAll, Me.btnSelectAllBrokenLink, Me.btnDeselectAll, Me.btnChangeFile, Me.btnCancel, Me.btnChangeCommonPath})
        Me.BarManager.MaxItemId = 8
        Me.BarManager.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtReplacePath})
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
        'btnChangePath
        '
        resources.ApplyResources(Me.btnChangePath, "btnChangePath")
        Me.btnChangePath.Id = 0
        Me.btnChangePath.Name = "btnChangePath"
        '
        'btnSelectAll
        '
        resources.ApplyResources(Me.btnSelectAll, "btnSelectAll")
        Me.btnSelectAll.Id = 2
        Me.btnSelectAll.Name = "btnSelectAll"
        '
        'btnSelectAllBrokenLink
        '
        resources.ApplyResources(Me.btnSelectAllBrokenLink, "btnSelectAllBrokenLink")
        Me.btnSelectAllBrokenLink.Id = 3
        Me.btnSelectAllBrokenLink.Name = "btnSelectAllBrokenLink"
        '
        'btnDeselectAll
        '
        resources.ApplyResources(Me.btnDeselectAll, "btnDeselectAll")
        Me.btnDeselectAll.Id = 4
        Me.btnDeselectAll.Name = "btnDeselectAll"
        '
        'btnChangeFile
        '
        resources.ApplyResources(Me.btnChangeFile, "btnChangeFile")
        Me.btnChangeFile.Id = 5
        Me.btnChangeFile.Name = "btnChangeFile"
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Id = 6
        Me.btnCancel.Name = "btnCancel"
        '
        'btnChangeCommonPath
        '
        resources.ApplyResources(Me.btnChangeCommonPath, "btnChangeCommonPath")
        Me.btnChangeCommonPath.Id = 7
        Me.btnChangeCommonPath.Name = "btnChangeCommonPath"
        '
        'txtReplacePath
        '
        Me.txtReplacePath.AllowEdit = False
        resources.ApplyResources(Me.txtReplacePath, "txtReplacePath")
        resources.ApplyResources(EditorButtonImageOptions1, "EditorButtonImageOptions1")
        resources.ApplyResources(EditorButtonImageOptions2, "EditorButtonImageOptions2")
        Me.txtReplacePath.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtReplacePath.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtReplacePath.Buttons1"), CType(resources.GetObject("txtReplacePath.Buttons2"), Integer), CType(resources.GetObject("txtReplacePath.Buttons3"), Boolean), CType(resources.GetObject("txtReplacePath.Buttons4"), Boolean), CType(resources.GetObject("txtReplacePath.Buttons5"), Boolean), EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, resources.GetString("txtReplacePath.Buttons6"), CType(resources.GetObject("txtReplacePath.Buttons7"), Object), CType(resources.GetObject("txtReplacePath.Buttons8"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtReplacePath.Buttons9"), DevExpress.Utils.ToolTipAnchor)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtReplacePath.Buttons10"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtReplacePath.Buttons11"), CType(resources.GetObject("txtReplacePath.Buttons12"), Integer), CType(resources.GetObject("txtReplacePath.Buttons13"), Boolean), CType(resources.GetObject("txtReplacePath.Buttons14"), Boolean), CType(resources.GetObject("txtReplacePath.Buttons15"), Boolean), EditorButtonImageOptions2, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, SerializableAppearanceObject6, SerializableAppearanceObject7, SerializableAppearanceObject8, resources.GetString("txtReplacePath.Buttons16"), CType(resources.GetObject("txtReplacePath.Buttons17"), Object), CType(resources.GetObject("txtReplacePath.Buttons18"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtReplacePath.Buttons19"), DevExpress.Utils.ToolTipAnchor))})
        Me.txtReplacePath.Name = "txtReplacePath"
        Me.txtReplacePath.ShowRootGlyph = False
        '
        'mnuRelink
        '
        Me.mnuRelink.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnSelectAll), New DevExpress.XtraBars.LinkPersistInfo(Me.btnSelectAllBrokenLink), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDeselectAll), New DevExpress.XtraBars.LinkPersistInfo(Me.btnChangePath, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnChangeCommonPath), New DevExpress.XtraBars.LinkPersistInfo(Me.btnChangeFile), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCancel, True)})
        Me.mnuRelink.Manager = Me.BarManager
        Me.mnuRelink.Name = "mnuRelink"
        '
        'frmLinkedSurveysRelink
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tvLinkedSurveys)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.Icon = CType(resources.GetObject("frmLinkedSurveysRelink.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.linktoprevious
        Me.MinimizeBox = False
        Me.Name = "frmLinkedSurveysRelink"
        CType(Me.tvLinkedSurveys, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReplacePath, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuRelink, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdOk As Button
    Friend WithEvents cmdCancel As Button
    Friend WithEvents tvLinkedSurveys As BrightIdeasSoftware.ObjectListView
    Friend WithEvents colLinkedSurveysIcon As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLinkedSurveysFilename As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLinkedSurveysNewFilename As BrightIdeasSoftware.OLVColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents txtCurrentPath As TextBox
    Friend WithEvents lblCurrentPath As Label
    Friend WithEvents colLinkedSurveysNewIcon As BrightIdeasSoftware.OLVColumn
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnChangePath As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents txtReplacePath As DevExpress.XtraEditors.Repository.RepositoryItemBreadCrumbEdit
    Friend WithEvents mnuRelink As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnSelectAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnSelectAllBrokenLink As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnDeselectAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnChangeFile As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCancel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnChangeCommonPath As DevExpress.XtraBars.BarButtonItem
End Class
