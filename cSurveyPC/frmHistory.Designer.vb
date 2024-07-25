<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistory
    Inherits cForm

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHistory))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lvItems = New System.Windows.Forms.ListView()
        Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colOrigine = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDateStamp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUtente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mnuItems = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuItemsRestore = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuItemsDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuItemsRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.lvLog = New System.Windows.Forms.ListView()
        Me.colLogMessage = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLogDateStamp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mnuLog = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuLogClean = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbMain = New System.Windows.Forms.ToolStrip()
        Me.btnShowLocal = New System.Windows.Forms.ToolStripButton()
        Me.btnShowWeb = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnHistoryAdd = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnAddLocal = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAddWeb = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRestore = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.sbMain = New System.Windows.Forms.StatusStrip()
        Me.pnlStatus = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.mnuItems.SuspendLayout()
        Me.mnuLog.SuspendLayout()
        Me.tbMain.SuspendLayout()
        Me.sbMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lvItems)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lvLog)
        '
        'lvItems
        '
        Me.lvItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvItems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colName, Me.colOrigine, Me.colSize, Me.colDateStamp, Me.colUtente})
        Me.lvItems.ContextMenuStrip = Me.mnuItems
        resources.ApplyResources(Me.lvItems, "lvItems")
        Me.lvItems.FullRowSelect = True
        Me.lvItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvItems.HideSelection = False
        Me.lvItems.MultiSelect = False
        Me.lvItems.Name = "lvItems"
        Me.lvItems.SmallImageList = Me.iml
        Me.lvItems.UseCompatibleStateImageBehavior = False
        Me.lvItems.View = System.Windows.Forms.View.Details
        '
        'colName
        '
        resources.ApplyResources(Me.colName, "colName")
        '
        'colOrigine
        '
        resources.ApplyResources(Me.colOrigine, "colOrigine")
        '
        'colSize
        '
        resources.ApplyResources(Me.colSize, "colSize")
        '
        'colDateStamp
        '
        resources.ApplyResources(Me.colDateStamp, "colDateStamp")
        '
        'colUtente
        '
        resources.ApplyResources(Me.colUtente, "colUtente")
        '
        'mnuItems
        '
        resources.ApplyResources(Me.mnuItems, "mnuItems")
        Me.mnuItems.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuItemsRestore, Me.ToolStripMenuItem1, Me.mnuItemsDelete, Me.ToolStripMenuItem2, Me.mnuItemsRefresh})
        Me.mnuItems.Name = "mnuItems"
        '
        'mnuItemsRestore
        '
        Me.mnuItemsRestore.Image = Global.cSurveyPC.My.Resources.Resources.arrow_undo
        Me.mnuItemsRestore.Name = "mnuItemsRestore"
        resources.ApplyResources(Me.mnuItemsRestore, "mnuItemsRestore")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuItemsDelete
        '
        Me.mnuItemsDelete.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.mnuItemsDelete.Name = "mnuItemsDelete"
        resources.ApplyResources(Me.mnuItemsDelete, "mnuItemsDelete")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'mnuItemsRefresh
        '
        Me.mnuItemsRefresh.Image = Global.cSurveyPC.My.Resources.Resources.arrow_refresh
        Me.mnuItemsRefresh.Name = "mnuItemsRefresh"
        resources.ApplyResources(Me.mnuItemsRefresh, "mnuItemsRefresh")
        '
        'iml
        '
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.Transparent
        Me.iml.Images.SetKeyName(0, "web")
        Me.iml.Images.SetKeyName(1, "local")
        Me.iml.Images.SetKeyName(2, "warning")
        Me.iml.Images.SetKeyName(3, "error")
        Me.iml.Images.SetKeyName(4, "info")
        '
        'lvLog
        '
        Me.lvLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colLogMessage, Me.colLogDateStamp})
        Me.lvLog.ContextMenuStrip = Me.mnuLog
        resources.ApplyResources(Me.lvLog, "lvLog")
        Me.lvLog.FullRowSelect = True
        Me.lvLog.HideSelection = False
        Me.lvLog.Name = "lvLog"
        Me.lvLog.SmallImageList = Me.iml
        Me.lvLog.UseCompatibleStateImageBehavior = False
        Me.lvLog.View = System.Windows.Forms.View.Details
        '
        'colLogMessage
        '
        resources.ApplyResources(Me.colLogMessage, "colLogMessage")
        '
        'colLogDateStamp
        '
        resources.ApplyResources(Me.colLogDateStamp, "colLogDateStamp")
        '
        'mnuLog
        '
        resources.ApplyResources(Me.mnuLog, "mnuLog")
        Me.mnuLog.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLogClean})
        Me.mnuLog.Name = "mnuLog"
        '
        'mnuLogClean
        '
        Me.mnuLogClean.Name = "mnuLogClean"
        resources.ApplyResources(Me.mnuLogClean, "mnuLogClean")
        '
        'tbMain
        '
        resources.ApplyResources(Me.tbMain, "tbMain")
        Me.tbMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnShowLocal, Me.btnShowWeb, Me.ToolStripSeparator1, Me.btnHistoryAdd, Me.ToolStripSeparator4, Me.btnRestore, Me.ToolStripSeparator3, Me.btnDelete, Me.ToolStripSeparator2, Me.btnRefresh, Me.ToolStripButton1, Me.ToolStripButton2})
        Me.tbMain.Name = "tbMain"
        '
        'btnShowLocal
        '
        Me.btnShowLocal.Checked = True
        Me.btnShowLocal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnShowLocal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnShowLocal, "btnShowLocal")
        Me.btnShowLocal.Name = "btnShowLocal"
        '
        'btnShowWeb
        '
        Me.btnShowWeb.Checked = True
        Me.btnShowWeb.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnShowWeb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnShowWeb, "btnShowWeb")
        Me.btnShowWeb.Name = "btnShowWeb"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'btnHistoryAdd
        '
        Me.btnHistoryAdd.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAddLocal, Me.btnAddWeb})
        Me.btnHistoryAdd.Image = Global.cSurveyPC.My.Resources.Resources.add
        resources.ApplyResources(Me.btnHistoryAdd, "btnHistoryAdd")
        Me.btnHistoryAdd.Name = "btnHistoryAdd"
        '
        'btnAddLocal
        '
        Me.btnAddLocal.Name = "btnAddLocal"
        resources.ApplyResources(Me.btnAddLocal, "btnAddLocal")
        '
        'btnAddWeb
        '
        Me.btnAddWeb.Name = "btnAddWeb"
        resources.ApplyResources(Me.btnAddWeb, "btnAddWeb")
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        '
        'btnRestore
        '
        Me.btnRestore.Image = Global.cSurveyPC.My.Resources.Resources.arrow_undo
        resources.ApplyResources(Me.btnRestore, "btnRestore")
        Me.btnRestore.Name = "btnRestore"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'btnDelete
        '
        Me.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDelete.Image = Global.cSurveyPC.My.Resources.Resources.cross
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Name = "btnDelete"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'btnRefresh
        '
        Me.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRefresh.Image = Global.cSurveyPC.My.Resources.Resources.arrow_refresh
        resources.ApplyResources(Me.btnRefresh, "btnRefresh")
        Me.btnRefresh.Name = "btnRefresh"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.ToolStripButton1, "ToolStripButton1")
        Me.ToolStripButton1.Name = "ToolStripButton1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.ToolStripButton2, "ToolStripButton2")
        Me.ToolStripButton2.Name = "ToolStripButton2"
        '
        'sbMain
        '
        resources.ApplyResources(Me.sbMain, "sbMain")
        Me.sbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pnlStatus})
        Me.sbMain.Name = "sbMain"
        '
        'pnlStatus
        '
        Me.pnlStatus.Name = "pnlStatus"
        resources.ApplyResources(Me.pnlStatus, "pnlStatus")
        Me.pnlStatus.Spring = True
        '
        'frmHistory
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.sbMain)
        Me.Controls.Add(Me.tbMain)
        Me.IconOptions.Icon = CType(resources.GetObject("frmHistory.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.time
        Me.Name = "frmHistory"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.mnuItems.ResumeLayout(False)
        Me.mnuLog.ResumeLayout(False)
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        Me.sbMain.ResumeLayout(False)
        Me.sbMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvItems As System.Windows.Forms.ListView
    Friend WithEvents colName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colOrigine As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDateStamp As System.Windows.Forms.ColumnHeader
    Friend WithEvents colUtente As System.Windows.Forms.ColumnHeader
    Friend WithEvents tbMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnShowLocal As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnShowWeb As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRestore As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents colSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents sbMain As System.Windows.Forms.StatusStrip
    Friend WithEvents pnlStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lvLog As System.Windows.Forms.ListView
    Friend WithEvents colLogMessage As System.Windows.Forms.ColumnHeader
    Friend WithEvents colLogDateStamp As System.Windows.Forms.ColumnHeader
    Friend WithEvents mnuItems As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuItemsRestore As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuItemsDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuItemsRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLog As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuLogClean As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnHistoryAdd As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnAddLocal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAddWeb As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
End Class
