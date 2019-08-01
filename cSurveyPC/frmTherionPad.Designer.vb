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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTherionPad))
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
        resources.ApplyResources(Me.cmdExportPlan, "cmdExportPlan")
        Me.cmdExportPlan.Name = "cmdExportPlan"
        Me.cmdExportPlan.UseVisualStyleBackColor = True
        '
        'cmdExportProfile
        '
        Me.cmdExportProfile.Image = Global.cSurveyPC.My.Resources.Resources.map_go
        resources.ApplyResources(Me.cmdExportProfile, "cmdExportProfile")
        Me.cmdExportProfile.Name = "cmdExportProfile"
        Me.cmdExportProfile.UseVisualStyleBackColor = True
        '
        'cdmExport3D
        '
        Me.cdmExport3D.Image = Global.cSurveyPC.My.Resources.Resources.layer_raster_3d1
        resources.ApplyResources(Me.cdmExport3D, "cdmExport3D")
        Me.cdmExport3D.Name = "cdmExport3D"
        Me.cdmExport3D.UseVisualStyleBackColor = True
        '
        'chkCloseAfterAction
        '
        resources.ApplyResources(Me.chkCloseAfterAction, "chkCloseAfterAction")
        Me.chkCloseAfterAction.Name = "chkCloseAfterAction"
        Me.chkCloseAfterAction.UseVisualStyleBackColor = True
        '
        'pnlCommands
        '
        Me.pnlCommands.Controls.Add(Me.cmdExportPlan)
        Me.pnlCommands.Controls.Add(Me.cmdExportProfile)
        Me.pnlCommands.Controls.Add(Me.chkCloseAfterAction)
        Me.pnlCommands.Controls.Add(Me.cdmExport3D)
        resources.ApplyResources(Me.pnlCommands, "pnlCommands")
        Me.pnlCommands.Name = "pnlCommands"
        '
        'frmTherionPad
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.pnlCommands)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTherionPad"
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
