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
        Me.tbMain = New System.Windows.Forms.ToolStrip()
        Me.cmdSaveAs = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdImport = New System.Windows.Forms.ToolStripButton()
        Me.cmdExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdRestore = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdRefresh = New System.Windows.Forms.ToolStripButton()
        Me.tvWorkspaces = New BrightIdeasSoftware.ObjectListView()
        Me.colWorkspacesName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colWorkspacesShowOnToolbar = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.mnuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuContextImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuContextDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnucontextRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.tbMain.SuspendLayout()
        CType(Me.tvWorkspaces, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuContext.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbMain
        '
        resources.ApplyResources(Me.tbMain, "tbMain")
        Me.tbMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdSaveAs, Me.ToolStripSeparator1, Me.cmdDelete, Me.ToolStripSeparator3, Me.cmdImport, Me.cmdExport, Me.ToolStripSeparator2, Me.cmdRestore, Me.ToolStripSeparator4, Me.cmdRefresh})
        Me.tbMain.Name = "tbMain"
        '
        'cmdSaveAs
        '
        Me.cmdSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdSaveAs.Image = Global.cSurveyPC.My.Resources.Resources.save_as1
        resources.ApplyResources(Me.cmdSaveAs, "cmdSaveAs")
        Me.cmdSaveAs.Name = "cmdSaveAs"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'cmdDelete
        '
        Me.cmdDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.cmdDelete, "cmdDelete")
        Me.cmdDelete.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.cmdDelete.Name = "cmdDelete"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'cmdImport
        '
        Me.cmdImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.cmdImport, "cmdImport")
        Me.cmdImport.Name = "cmdImport"
        '
        'cmdExport
        '
        Me.cmdExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.cmdExport, "cmdExport")
        Me.cmdExport.Name = "cmdExport"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'cmdRestore
        '
        Me.cmdRestore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.cmdRestore, "cmdRestore")
        Me.cmdRestore.Name = "cmdRestore"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        '
        'cmdRefresh
        '
        Me.cmdRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdRefresh.Image = Global.cSurveyPC.My.Resources.Resources.arrow_refresh
        resources.ApplyResources(Me.cmdRefresh, "cmdRefresh")
        Me.cmdRefresh.Name = "cmdRefresh"
        '
        'tvWorkspaces
        '
        Me.tvWorkspaces.AllColumns.Add(Me.colWorkspacesName)
        Me.tvWorkspaces.AllColumns.Add(Me.colWorkspacesShowOnToolbar)
        Me.tvWorkspaces.AllowDrop = True
        resources.ApplyResources(Me.tvWorkspaces, "tvWorkspaces")
        Me.tvWorkspaces.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick
        Me.tvWorkspaces.CellEditUseWholeCell = False
        Me.tvWorkspaces.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colWorkspacesName, Me.colWorkspacesShowOnToolbar})
        Me.tvWorkspaces.ContextMenuStrip = Me.mnuContext
        Me.tvWorkspaces.Cursor = System.Windows.Forms.Cursors.Default
        Me.tvWorkspaces.FullRowSelect = True
        Me.tvWorkspaces.HideSelection = False
        Me.tvWorkspaces.IsSimpleDragSource = True
        Me.tvWorkspaces.IsSimpleDropSink = True
        Me.tvWorkspaces.MultiSelect = False
        Me.tvWorkspaces.Name = "tvWorkspaces"
        Me.tvWorkspaces.ShowGroups = False
        Me.tvWorkspaces.UseCompatibleStateImageBehavior = False
        Me.tvWorkspaces.View = System.Windows.Forms.View.Details
        Me.tvWorkspaces.VirtualMode = True
        '
        'colWorkspacesName
        '
        resources.ApplyResources(Me.colWorkspacesName, "colWorkspacesName")
        '
        'colWorkspacesShowOnToolbar
        '
        resources.ApplyResources(Me.colWorkspacesShowOnToolbar, "colWorkspacesShowOnToolbar")
        '
        'mnuContext
        '
        resources.ApplyResources(Me.mnuContext, "mnuContext")
        Me.mnuContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuContextImport, Me.mnuContextExport, Me.ToolStripMenuItem2, Me.mnuContextDelete, Me.ToolStripMenuItem1, Me.mnucontextRefresh})
        Me.mnuContext.Name = "mnuContext"
        '
        'mnuContextImport
        '
        Me.mnuContextImport.Name = "mnuContextImport"
        resources.ApplyResources(Me.mnuContextImport, "mnuContextImport")
        '
        'mnuContextExport
        '
        Me.mnuContextExport.Name = "mnuContextExport"
        resources.ApplyResources(Me.mnuContextExport, "mnuContextExport")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'mnuContextDelete
        '
        Me.mnuContextDelete.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.mnuContextDelete.Name = "mnuContextDelete"
        resources.ApplyResources(Me.mnuContextDelete, "mnuContextDelete")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnucontextRefresh
        '
        Me.mnucontextRefresh.Image = Global.cSurveyPC.My.Resources.Resources.arrow_refresh
        Me.mnucontextRefresh.Name = "mnucontextRefresh"
        resources.ApplyResources(Me.mnucontextRefresh, "mnucontextRefresh")
        '
        'cmdExit
        '
        resources.ApplyResources(Me.cmdExit, "cmdExit")
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'frmManageWorkspaces
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdExit
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.tvWorkspaces)
        Me.Controls.Add(Me.tbMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmManageWorkspaces"
        Me.ShowIcon = False
        Me.TopMost = True
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        CType(Me.tvWorkspaces, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuContext.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbMain As ToolStrip
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents cmdSaveAs As ToolStripButton
    Friend WithEvents colWorkspacesName As BrightIdeasSoftware.OLVColumn
    Friend WithEvents tvWorkspaces As BrightIdeasSoftware.ObjectListView
    Friend WithEvents cmdRefresh As ToolStripButton
    Friend WithEvents mnuContext As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents mnucontextRefresh As ToolStripMenuItem
    Friend WithEvents mnuContextImport As ToolStripMenuItem
    Friend WithEvents mnuContextExport As ToolStripMenuItem
    Friend WithEvents cmdImport As ToolStripButton
    Friend WithEvents cmdExport As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents cmdExit As Button
    Friend WithEvents cmdApply As Button
    Friend WithEvents cmdDelete As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents mnuContextDelete As ToolStripMenuItem
    Friend WithEvents cmdRestore As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents colWorkspacesShowOnToolbar As BrightIdeasSoftware.OLVColumn
End Class
