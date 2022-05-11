<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmExportTherion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExportTherion))
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkExportDesign = New DevExpress.XtraEditors.CheckEdit()
        Me.chkExportThconfig = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.chkExportDesign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkExportThconfig.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'chkExportDesign
        '
        resources.ApplyResources(Me.chkExportDesign, "chkExportDesign")
        Me.chkExportDesign.Name = "chkExportDesign"
        Me.chkExportDesign.Properties.AutoWidth = True
        Me.chkExportDesign.Properties.Caption = resources.GetString("chkExportDesign.Properties.Caption")
        '
        'chkExportThconfig
        '
        resources.ApplyResources(Me.chkExportThconfig, "chkExportThconfig")
        Me.chkExportThconfig.Name = "chkExportThconfig"
        Me.chkExportThconfig.Properties.AutoWidth = True
        Me.chkExportThconfig.Properties.Caption = resources.GetString("chkExportThconfig.Properties.Caption")
        '
        'frmExportTherion
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.chkExportThconfig)
        Me.Controls.Add(Me.chkExportDesign)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.exportfile
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExportTherion"
        CType(Me.chkExportDesign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkExportThconfig.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents chkExportDesign As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkExportThconfig As DevExpress.XtraEditors.CheckEdit
End Class
