<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSurveyCleanUpUndefinedCaves
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurveyCleanUpUndefinedCaves))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.grdUndefinedCaves = New cSurveyPC.cGrid()
        Me.colCave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBranch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNewCave = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colNewBranch = New System.Windows.Forms.DataGridViewComboBoxColumn()
        CType(Me.grdUndefinedCaves, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'grdUndefinedCaves
        '
        Me.grdUndefinedCaves.AllowUserToAddRows = False
        Me.grdUndefinedCaves.AllowUserToDeleteRows = False
        Me.grdUndefinedCaves.AllowUserToResizeRows = False
        resources.ApplyResources(Me.grdUndefinedCaves, "grdUndefinedCaves")
        Me.grdUndefinedCaves.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdUndefinedCaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdUndefinedCaves.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCave, Me.colBranch, Me.colNewCave, Me.colNewBranch})
        Me.grdUndefinedCaves.Name = "grdUndefinedCaves"
        Me.grdUndefinedCaves.RowHeadersVisible = False
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
        'colNewCave
        '
        resources.ApplyResources(Me.colNewCave, "colNewCave")
        Me.colNewCave.Name = "colNewCave"
        '
        'colNewBranch
        '
        resources.ApplyResources(Me.colNewBranch, "colNewBranch")
        Me.colNewBranch.Name = "colNewBranch"
        '
        'frmSurveyCleanUpUndefinedCaves
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.grdUndefinedCaves)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSurveyCleanUpUndefinedCaves"
        CType(Me.grdUndefinedCaves, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents grdUndefinedCaves As cSurveyPC.cGrid
    Friend WithEvents colCave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBranch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNewCave As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colNewBranch As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
