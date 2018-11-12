<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTherionPad
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
        Me.cmdExportPlan = New System.Windows.Forms.Button()
        Me.cmdExportProfile = New System.Windows.Forms.Button()
        Me.cdmExport3D = New System.Windows.Forms.Button()
        Me.chkCloseAfterAction = New System.Windows.Forms.CheckBox()
        Me.pnlCommands = New System.Windows.Forms.Panel()
        Me.pnlCommands.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExportPlan
        '
        Me.cmdExportPlan.Image = Global.cSurveyPC.My.Resources.Resources.map_go
        Me.cmdExportPlan.Location = New System.Drawing.Point(10, 10)
        Me.cmdExportPlan.Name = "cmdExportPlan"
        Me.cmdExportPlan.Size = New System.Drawing.Size(96, 82)
        Me.cmdExportPlan.TabIndex = 0
        Me.cmdExportPlan.Text = "Esporta pianta"
        Me.cmdExportPlan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdExportPlan.UseVisualStyleBackColor = True
        '
        'cmdExportProfile
        '
        Me.cmdExportProfile.Image = Global.cSurveyPC.My.Resources.Resources.map_go
        Me.cmdExportProfile.Location = New System.Drawing.Point(119, 10)
        Me.cmdExportProfile.Name = "cmdExportProfile"
        Me.cmdExportProfile.Size = New System.Drawing.Size(96, 82)
        Me.cmdExportProfile.TabIndex = 1
        Me.cmdExportProfile.Text = "Esporta sezione"
        Me.cmdExportProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdExportProfile.UseVisualStyleBackColor = True
        '
        'cdmExport3D
        '
        Me.cdmExport3D.Image = Global.cSurveyPC.My.Resources.Resources.layer_raster_3d1
        Me.cdmExport3D.Location = New System.Drawing.Point(228, 10)
        Me.cdmExport3D.Name = "cdmExport3D"
        Me.cdmExport3D.Size = New System.Drawing.Size(96, 82)
        Me.cdmExport3D.TabIndex = 2
        Me.cdmExport3D.Text = "Esporta 3D"
        Me.cdmExport3D.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cdmExport3D.UseVisualStyleBackColor = True
        '
        'chkCloseAfterAction
        '
        Me.chkCloseAfterAction.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkCloseAfterAction.AutoSize = True
        Me.chkCloseAfterAction.Location = New System.Drawing.Point(10, 105)
        Me.chkCloseAfterAction.Name = "chkCloseAfterAction"
        Me.chkCloseAfterAction.Size = New System.Drawing.Size(151, 17)
        Me.chkCloseAfterAction.TabIndex = 3
        Me.chkCloseAfterAction.Text = "Chiudi dopo ogni comando"
        Me.chkCloseAfterAction.UseVisualStyleBackColor = True
        '
        'pnlCommands
        '
        Me.pnlCommands.Controls.Add(Me.cmdExportPlan)
        Me.pnlCommands.Controls.Add(Me.cmdExportProfile)
        Me.pnlCommands.Controls.Add(Me.chkCloseAfterAction)
        Me.pnlCommands.Controls.Add(Me.cdmExport3D)
        Me.pnlCommands.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCommands.Location = New System.Drawing.Point(0, 0)
        Me.pnlCommands.Name = "pnlCommands"
        Me.pnlCommands.Size = New System.Drawing.Size(335, 131)
        Me.pnlCommands.TabIndex = 1
        '
        'frmTherionPad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(335, 131)
        Me.Controls.Add(Me.pnlCommands)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTherionPad"
        Me.Text = "Therion tools"
        Me.pnlCommands.ResumeLayout(False)
        Me.pnlCommands.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdExportPlan As System.Windows.Forms.Button
    Friend WithEvents cmdExportProfile As System.Windows.Forms.Button
    Friend WithEvents cdmExport3D As System.Windows.Forms.Button
    Friend WithEvents chkCloseAfterAction As System.Windows.Forms.CheckBox
    Friend WithEvents pnlCommands As System.Windows.Forms.Panel
End Class
