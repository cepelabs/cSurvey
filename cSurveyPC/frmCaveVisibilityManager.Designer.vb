<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCaveVisibilityManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCaveVisibilityManager))
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.tbMain = New System.Windows.Forms.ToolStrip()
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.btnAddAsCopy = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRemove = New System.Windows.Forms.ToolStripButton()
        Me.btnRemoveAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCheckQuerySintax = New System.Windows.Forms.ToolStripButton()
        Me.btnCleanQuerySintax = New System.Windows.Forms.ToolStripButton()
        Me.cboProfiles = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.colCave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBranch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Visibile = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.grdProfile = New cSurveyPC.cGrid()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.mnuContextProfile = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuContextProfileSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextProfileDeselectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuContextProfileInvertSelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuContextProfileSelectCurrentCave = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextProfileDeselectCurrentCave = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabProfile = New System.Windows.Forms.TabControl()
        Me.TabCaves = New System.Windows.Forms.TabPage()
        Me.tabSegment = New System.Windows.Forms.TabPage()
        Me.txtSegments = New System.Windows.Forms.RichTextBox()
        Me.tabItems = New System.Windows.Forms.TabPage()
        Me.txtItems = New System.Windows.Forms.RichTextBox()
        Me.tbMain.SuspendLayout()
        CType(Me.grdProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuContextProfile.SuspendLayout()
        Me.tabProfile.SuspendLayout()
        Me.TabCaves.SuspendLayout()
        Me.tabSegment.SuspendLayout()
        Me.tabItems.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.UseVisualStyleBackColor = True
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
        'tbMain
        '
        resources.ApplyResources(Me.tbMain, "tbMain")
        Me.tbMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.btnAddAsCopy, Me.ToolStripSeparator1, Me.btnRemove, Me.btnRemoveAll, Me.ToolStripSeparator2, Me.btnCheckQuerySintax, Me.btnCleanQuerySintax})
        Me.tbMain.Name = "tbMain"
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Image = Global.cSurveyPC.My.Resources.Resources.add
        Me.btnAdd.Name = "btnAdd"
        '
        'btnAddAsCopy
        '
        resources.ApplyResources(Me.btnAddAsCopy, "btnAddAsCopy")
        Me.btnAddAsCopy.Image = Global.cSurveyPC.My.Resources.Resources.add
        Me.btnAddAsCopy.Name = "btnAddAsCopy"
        '
        'ToolStripSeparator1
        '
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        '
        'btnRemove
        '
        resources.ApplyResources(Me.btnRemove, "btnRemove")
        Me.btnRemove.Name = "btnRemove"
        '
        'btnRemoveAll
        '
        resources.ApplyResources(Me.btnRemoveAll, "btnRemoveAll")
        Me.btnRemoveAll.Name = "btnRemoveAll"
        '
        'ToolStripSeparator2
        '
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        '
        'btnCheckQuerySintax
        '
        resources.ApplyResources(Me.btnCheckQuerySintax, "btnCheckQuerySintax")
        Me.btnCheckQuerySintax.Name = "btnCheckQuerySintax"
        '
        'btnCleanQuerySintax
        '
        resources.ApplyResources(Me.btnCleanQuerySintax, "btnCleanQuerySintax")
        Me.btnCleanQuerySintax.Name = "btnCleanQuerySintax"
        '
        'cboProfiles
        '
        resources.ApplyResources(Me.cboProfiles, "cboProfiles")
        Me.cboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProfiles.FormattingEnabled = True
        Me.cboProfiles.Name = "cboProfiles"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'colCave
        '
        Me.colCave.FillWeight = 162.4366!
        resources.ApplyResources(Me.colCave, "colCave")
        Me.colCave.Name = "colCave"
        Me.colCave.ReadOnly = True
        Me.colCave.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCave.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colBranch
        '
        Me.colBranch.FillWeight = 225.1904!
        resources.ApplyResources(Me.colBranch, "colBranch")
        Me.colBranch.Name = "colBranch"
        Me.colBranch.ReadOnly = True
        '
        'Visibile
        '
        resources.ApplyResources(Me.Visibile, "Visibile")
        Me.Visibile.Name = "Visibile"
        '
        'grdProfile
        '
        resources.ApplyResources(Me.grdProfile, "grdProfile")
        Me.grdProfile.AllowUserToAddRows = False
        Me.grdProfile.AllowUserToDeleteRows = False
        Me.grdProfile.AllowUserToResizeRows = False
        Me.grdProfile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdProfile.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewCheckBoxColumn1})
        Me.grdProfile.ContextMenuStrip = Me.mnuContextProfile
        Me.grdProfile.Name = "grdProfile"
        Me.grdProfile.RowHeadersVisible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 162.4366!
        resources.ApplyResources(Me.DataGridViewTextBoxColumn1, "DataGridViewTextBoxColumn1")
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 225.1904!
        resources.ApplyResources(Me.DataGridViewTextBoxColumn2, "DataGridViewTextBoxColumn2")
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewCheckBoxColumn1
        '
        resources.ApplyResources(Me.DataGridViewCheckBoxColumn1, "DataGridViewCheckBoxColumn1")
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        '
        'mnuContextProfile
        '
        resources.ApplyResources(Me.mnuContextProfile, "mnuContextProfile")
        Me.mnuContextProfile.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuContextProfileSelectAll, Me.mnuContextProfileDeselectAll, Me.ToolStripMenuItem1, Me.mnuContextProfileInvertSelection, Me.ToolStripMenuItem2, Me.mnuContextProfileSelectCurrentCave, Me.mnuContextProfileDeselectCurrentCave})
        Me.mnuContextProfile.Name = "mnuContextProfile"
        '
        'mnuContextProfileSelectAll
        '
        resources.ApplyResources(Me.mnuContextProfileSelectAll, "mnuContextProfileSelectAll")
        Me.mnuContextProfileSelectAll.Name = "mnuContextProfileSelectAll"
        '
        'mnuContextProfileDeselectAll
        '
        resources.ApplyResources(Me.mnuContextProfileDeselectAll, "mnuContextProfileDeselectAll")
        Me.mnuContextProfileDeselectAll.Name = "mnuContextProfileDeselectAll"
        '
        'ToolStripMenuItem1
        '
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        '
        'mnuContextProfileInvertSelection
        '
        resources.ApplyResources(Me.mnuContextProfileInvertSelection, "mnuContextProfileInvertSelection")
        Me.mnuContextProfileInvertSelection.Name = "mnuContextProfileInvertSelection"
        '
        'ToolStripMenuItem2
        '
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        '
        'mnuContextProfileSelectCurrentCave
        '
        resources.ApplyResources(Me.mnuContextProfileSelectCurrentCave, "mnuContextProfileSelectCurrentCave")
        Me.mnuContextProfileSelectCurrentCave.Name = "mnuContextProfileSelectCurrentCave"
        '
        'mnuContextProfileDeselectCurrentCave
        '
        resources.ApplyResources(Me.mnuContextProfileDeselectCurrentCave, "mnuContextProfileDeselectCurrentCave")
        Me.mnuContextProfileDeselectCurrentCave.Name = "mnuContextProfileDeselectCurrentCave"
        '
        'tabProfile
        '
        resources.ApplyResources(Me.tabProfile, "tabProfile")
        Me.tabProfile.Controls.Add(Me.TabCaves)
        Me.tabProfile.Controls.Add(Me.tabSegment)
        Me.tabProfile.Controls.Add(Me.tabItems)
        Me.tabProfile.Name = "tabProfile"
        Me.tabProfile.SelectedIndex = 0
        '
        'TabCaves
        '
        resources.ApplyResources(Me.TabCaves, "TabCaves")
        Me.TabCaves.Controls.Add(Me.grdProfile)
        Me.TabCaves.Name = "TabCaves"
        Me.TabCaves.UseVisualStyleBackColor = True
        '
        'tabSegment
        '
        resources.ApplyResources(Me.tabSegment, "tabSegment")
        Me.tabSegment.Controls.Add(Me.txtSegments)
        Me.tabSegment.Name = "tabSegment"
        Me.tabSegment.UseVisualStyleBackColor = True
        '
        'txtSegments
        '
        resources.ApplyResources(Me.txtSegments, "txtSegments")
        Me.txtSegments.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSegments.DetectUrls = False
        Me.txtSegments.Name = "txtSegments"
        '
        'tabItems
        '
        resources.ApplyResources(Me.tabItems, "tabItems")
        Me.tabItems.Controls.Add(Me.txtItems)
        Me.tabItems.Name = "tabItems"
        Me.tabItems.UseVisualStyleBackColor = True
        '
        'txtItems
        '
        resources.ApplyResources(Me.txtItems, "txtItems")
        Me.txtItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtItems.DetectUrls = False
        Me.txtItems.Name = "txtItems"
        '
        'frmCaveVisibilityManager
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboProfiles)
        Me.Controls.Add(Me.tbMain)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.tabProfile)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "frmCaveVisibilityManager"
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        CType(Me.grdProfile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuContextProfile.ResumeLayout(False)
        Me.tabProfile.ResumeLayout(False)
        Me.TabCaves.ResumeLayout(False)
        Me.tabSegment.ResumeLayout(False)
        Me.tabItems.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdProfile As cSurveyPC.cGrid
    Friend WithEvents colCave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBranch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Visibile As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents tbMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAddAsCopy As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRemove As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRemoveAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboProfiles As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabProfile As System.Windows.Forms.TabControl
    Friend WithEvents TabCaves As System.Windows.Forms.TabPage
    Friend WithEvents tabSegment As System.Windows.Forms.TabPage
    Friend WithEvents tabItems As System.Windows.Forms.TabPage
    Friend WithEvents txtSegments As System.Windows.Forms.RichTextBox
    Friend WithEvents txtItems As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCheckQuerySintax As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCleanQuerySintax As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents mnuContextProfile As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuContextProfileSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuContextProfileDeselectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuContextProfileInvertSelection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuContextProfileSelectCurrentCave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuContextProfileDeselectCurrentCave As System.Windows.Forms.ToolStripMenuItem
End Class
