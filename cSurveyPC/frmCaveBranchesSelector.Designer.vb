<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCaveBranchesSelector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCaveBranchesSelector))
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
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
        CType(Me.grdProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuContextProfile.SuspendLayout()
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
        'frmCaveBranchesSelector
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.grdProfile)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "frmCaveBranchesSelector"
        CType(Me.grdProfile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuContextProfile.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdProfile As cSurveyPC.cGrid
    Friend WithEvents colCave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBranch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Visibile As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents mnuContextProfile As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuContextProfileSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuContextProfileDeselectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuContextProfileInvertSelection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuContextProfileSelectCurrentCave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuContextProfileDeselectCurrentCave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
