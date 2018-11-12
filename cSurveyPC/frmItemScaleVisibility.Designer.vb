<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemScaleVisibility
    Inherits cForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItemScaleVisibility))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.mnuScales = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuScalesSelectThisAndNexts = New System.Windows.Forms.ToolStripMenuItem()
        Me.grdVisibility = New cSurveyPC.cGrid()
        Me.colScale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisibility = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.mnuScales.SuspendLayout()
        CType(Me.grdVisibility, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(212, 224)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 25)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Annulla"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Location = New System.Drawing.Point(126, 224)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(80, 25)
        Me.cmdOk.TabIndex = 2
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'mnuScales
        '
        Me.mnuScales.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuScales.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuScalesSelectThisAndNexts})
        Me.mnuScales.Name = "mnuScales"
        Me.mnuScales.Size = New System.Drawing.Size(190, 26)
        '
        'mnuScalesSelectThisAndNexts
        '
        Me.mnuScalesSelectThisAndNexts.Name = "mnuScalesSelectThisAndNexts"
        Me.mnuScalesSelectThisAndNexts.Size = New System.Drawing.Size(189, 22)
        Me.mnuScalesSelectThisAndNexts.Text = "Select this and following"
        '
        'grdVisibility
        '
        Me.grdVisibility.AllowUserToAddRows = False
        Me.grdVisibility.AllowUserToDeleteRows = False
        Me.grdVisibility.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdVisibility.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdVisibility.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colScale, Me.colVisibility})
        Me.grdVisibility.Location = New System.Drawing.Point(12, 12)
        Me.grdVisibility.Name = "grdVisibility"
        Me.grdVisibility.Size = New System.Drawing.Size(280, 198)
        Me.grdVisibility.TabIndex = 6
        '
        'colScale
        '
        Me.colScale.Frozen = True
        Me.colScale.HeaderText = "Scale"
        Me.colScale.Name = "colScale"
        Me.colScale.ReadOnly = True
        '
        'colVisibility
        '
        Me.colVisibility.HeaderText = "Visibility"
        Me.colVisibility.Name = "colVisibility"
        '
        'frmItemScaleVisibility
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(304, 261)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.grdVisibility)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItemScaleVisibility"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Item visibility by scale:"
        Me.mnuScales.ResumeLayout(False)
        CType(Me.grdVisibility, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdOk As Button
    Friend WithEvents mnuScales As ContextMenuStrip
    Friend WithEvents mnuScalesSelectThisAndNexts As ToolStripMenuItem
    Friend WithEvents grdVisibility As cGrid
    Friend WithEvents colScale As DataGridViewTextBoxColumn
    Friend WithEvents colVisibility As DataGridViewComboBoxColumn
End Class
