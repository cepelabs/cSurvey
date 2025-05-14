<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImportExcelcSurvey
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportExcelcSurvey))
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.txtFilename = New DevExpress.XtraEditors.TextEdit()
        Me.lblFilename = New DevExpress.XtraEditors.LabelControl()
        Me.chkExcelcSurveyCavesAndBranches = New DevExpress.XtraEditors.CheckEdit()
        Me.chkExcelcSurveySessions = New DevExpress.XtraEditors.CheckEdit()
        Me.chkExcelColor = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.txtFilename.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkExcelcSurveyCavesAndBranches.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkExcelcSurveySessions.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkExcelColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'txtFilename
        '
        resources.ApplyResources(Me.txtFilename, "txtFilename")
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Properties.ReadOnly = True
        '
        'lblFilename
        '
        Me.lblFilename.Appearance.Font = CType(resources.GetObject("lblFilename.Appearance.Font"), System.Drawing.Font)
        Me.lblFilename.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblFilename, "lblFilename")
        Me.lblFilename.Name = "lblFilename"
        '
        'chkExcelcSurveyCavesAndBranches
        '
        resources.ApplyResources(Me.chkExcelcSurveyCavesAndBranches, "chkExcelcSurveyCavesAndBranches")
        Me.chkExcelcSurveyCavesAndBranches.Name = "chkExcelcSurveyCavesAndBranches"
        Me.chkExcelcSurveyCavesAndBranches.Properties.AutoWidth = True
        Me.chkExcelcSurveyCavesAndBranches.Properties.Caption = resources.GetString("chkExcelcSurveyCavesAndBranches.Properties.Caption")
        '
        'chkExcelcSurveySessions
        '
        resources.ApplyResources(Me.chkExcelcSurveySessions, "chkExcelcSurveySessions")
        Me.chkExcelcSurveySessions.Name = "chkExcelcSurveySessions"
        Me.chkExcelcSurveySessions.Properties.AutoWidth = True
        Me.chkExcelcSurveySessions.Properties.Caption = resources.GetString("chkExcelcSurveySessions.Properties.Caption")
        '
        'chkExcelColor
        '
        resources.ApplyResources(Me.chkExcelColor, "chkExcelColor")
        Me.chkExcelColor.Name = "chkExcelColor"
        Me.chkExcelColor.Properties.AutoWidth = True
        Me.chkExcelColor.Properties.Caption = resources.GetString("chkExportColor.Properties.Caption")
        '
        'frmImportExcelcSurvey
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.chkExcelColor)
        Me.Controls.Add(Me.chkExcelcSurveySessions)
        Me.Controls.Add(Me.chkExcelcSurveyCavesAndBranches)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmImportExcelcSurvey.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.import
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportExcelcSurvey"
        CType(Me.txtFilename.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkExcelcSurveyCavesAndBranches.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkExcelcSurveySessions.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkExcelColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtFilename As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblFilename As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkExcelcSurveyCavesAndBranches As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkExcelcSurveySessions As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkExcelColor As DevExpress.XtraEditors.CheckEdit
End Class
