<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRefineFixData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRefineFixData))
        Me.grdFix = New cSurveyPC.cGrid()
        Me.colStation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEast = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNorth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colZone = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colBand = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colAlt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mnuFix = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuFixApplyCurrentToAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFixDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        CType(Me.grdFix, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuFix.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdFix
        '
        Me.grdFix.AllowUserToAddRows = False
        Me.grdFix.AllowUserToDeleteRows = False
        Me.grdFix.AllowUserToResizeRows = False
        Me.grdFix.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdFix.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdFix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFix.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colStation, Me.colEast, Me.colNorth, Me.colZone, Me.colBand, Me.colAlt})
        Me.grdFix.ContextMenuStrip = Me.mnuFix
        Me.grdFix.Location = New System.Drawing.Point(12, 12)
        Me.grdFix.Name = "grdFix"
        Me.grdFix.RowHeadersVisible = False
        Me.grdFix.Size = New System.Drawing.Size(515, 167)
        Me.grdFix.TabIndex = 13
        '
        'colStation
        '
        Me.colStation.FillWeight = 162.4366!
        Me.colStation.HeaderText = "Station"
        Me.colStation.Name = "colStation"
        Me.colStation.ReadOnly = True
        Me.colStation.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colStation.Width = 139
        '
        'colEast
        '
        Me.colEast.FillWeight = 225.1904!
        Me.colEast.HeaderText = "X"
        Me.colEast.Name = "colEast"
        Me.colEast.Width = 60
        '
        'colNorth
        '
        Me.colNorth.HeaderText = "Y"
        Me.colNorth.Name = "colNorth"
        Me.colNorth.Width = 60
        '
        'colZone
        '
        Me.colZone.HeaderText = "Zona"
        Me.colZone.Name = "colZone"
        Me.colZone.Width = 80
        '
        'colBand
        '
        Me.colBand.HeaderText = "Banda"
        Me.colBand.Name = "colBand"
        Me.colBand.Width = 80
        '
        'colAlt
        '
        Me.colAlt.HeaderText = "Altitudine"
        Me.colAlt.Name = "colAlt"
        Me.colAlt.Width = 60
        '
        'mnuFix
        '
        Me.mnuFix.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFixApplyCurrentToAll, Me.ToolStripMenuItem1, Me.mnuFixDelete})
        Me.mnuFix.Name = "mnuFix"
        Me.mnuFix.Size = New System.Drawing.Size(274, 54)
        '
        'mnuFixApplyCurrentToAll
        '
        Me.mnuFixApplyCurrentToAll.Name = "mnuFixApplyCurrentToAll"
        Me.mnuFixApplyCurrentToAll.Size = New System.Drawing.Size(273, 22)
        Me.mnuFixApplyCurrentToAll.Text = "Applica a tutti la zona/banda corrente"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(270, 6)
        '
        'mnuFixDelete
        '
        Me.mnuFixDelete.Name = "mnuFixDelete"
        Me.mnuFixDelete.Size = New System.Drawing.Size(273, 22)
        Me.mnuFixDelete.Text = "Elimina"
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCancel.Location = New System.Drawing.Point(447, 190)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 25)
        Me.cmdCancel.TabIndex = 12
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdOk.Location = New System.Drawing.Point(361, 190)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(80, 25)
        Me.cmdOk.TabIndex = 11
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'frmRefineFixData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(539, 227)
        Me.Controls.Add(Me.grdFix)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frmRefineFixData"
        Me.Text = "Rivedi posizionamento geografico:"
        CType(Me.grdFix, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuFix.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdFix As cSurveyPC.cGrid
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents mnuFix As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuFixApplyCurrentToAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFixDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colStation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEast As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNorth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colZone As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colBand As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colAlt As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
