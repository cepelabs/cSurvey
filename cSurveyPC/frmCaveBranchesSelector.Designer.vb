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
        Me.cmdApply = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.colCave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBranch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Visibile = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.mnuContextProfile = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuContextProfileSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextProfileDeselectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuContextProfileInvertSelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuContextProfileSelectCurrentCave = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextProfileDeselectCurrentCave = New System.Windows.Forms.ToolStripMenuItem()
        Me.cGrid = New cSurveyPC.cCaveBranchSelectorGrid()
        Me.mnuContextProfile.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.Name = "cmdApply"
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
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
        'mnuContextProfile
        '
        resources.ApplyResources(Me.mnuContextProfile, "mnuContextProfile")
        Me.mnuContextProfile.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuContextProfileSelectAll, Me.mnuContextProfileDeselectAll, Me.ToolStripMenuItem1, Me.mnuContextProfileInvertSelection, Me.ToolStripMenuItem2, Me.mnuContextProfileSelectCurrentCave, Me.mnuContextProfileDeselectCurrentCave})
        Me.mnuContextProfile.Name = "mnuContextProfile"
        '
        'mnuContextProfileSelectAll
        '
        Me.mnuContextProfileSelectAll.Name = "mnuContextProfileSelectAll"
        resources.ApplyResources(Me.mnuContextProfileSelectAll, "mnuContextProfileSelectAll")
        '
        'mnuContextProfileDeselectAll
        '
        Me.mnuContextProfileDeselectAll.Name = "mnuContextProfileDeselectAll"
        resources.ApplyResources(Me.mnuContextProfileDeselectAll, "mnuContextProfileDeselectAll")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuContextProfileInvertSelection
        '
        Me.mnuContextProfileInvertSelection.Name = "mnuContextProfileInvertSelection"
        resources.ApplyResources(Me.mnuContextProfileInvertSelection, "mnuContextProfileInvertSelection")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'mnuContextProfileSelectCurrentCave
        '
        Me.mnuContextProfileSelectCurrentCave.Name = "mnuContextProfileSelectCurrentCave"
        resources.ApplyResources(Me.mnuContextProfileSelectCurrentCave, "mnuContextProfileSelectCurrentCave")
        '
        'mnuContextProfileDeselectCurrentCave
        '
        Me.mnuContextProfileDeselectCurrentCave.Name = "mnuContextProfileDeselectCurrentCave"
        resources.ApplyResources(Me.mnuContextProfileDeselectCurrentCave, "mnuContextProfileDeselectCurrentCave")
        '
        'cGrid
        '
        resources.ApplyResources(Me.cGrid, "cGrid")
        Me.cGrid.Name = "cGrid"
        '
        'frmCaveBranchesSelector
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cGrid)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "frmCaveBranchesSelector"
        Me.mnuContextProfile.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents colCave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBranch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Visibile As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cmdApply As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents mnuContextProfile As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuContextProfileSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuContextProfileDeselectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuContextProfileInvertSelection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuContextProfileSelectCurrentCave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuContextProfileDeselectCurrentCave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cGrid As cCaveBranchSelectorGrid
End Class
