<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAutoSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAutoSettings))
        Me.cmdAutoConfig = New DevExpress.XtraEditors.SimpleButton()
        Me.lblTitle = New DevExpress.XtraEditors.LabelControl()
        Me.pnlProgress = New DevExpress.XtraEditors.PanelControl()
        Me.lblProgressInfo = New DevExpress.XtraEditors.LabelControl()
        Me.cboLanguage = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblLanguage = New DevExpress.XtraEditors.LabelControl()
        CType(Me.pnlProgress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProgress.SuspendLayout()
        CType(Me.cboLanguage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdAutoConfig
        '
        resources.ApplyResources(Me.cmdAutoConfig, "cmdAutoConfig")
        Me.cmdAutoConfig.Appearance.Options.UseTextOptions = True
        Me.cmdAutoConfig.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.cmdAutoConfig.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.cmdAutoConfig.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.autoconfig
        Me.cmdAutoConfig.Name = "cmdAutoConfig"
        '
        'lblTitle
        '
        resources.ApplyResources(Me.lblTitle, "lblTitle")
        Me.lblTitle.Appearance.Options.UseTextOptions = True
        Me.lblTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.lblTitle.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lblTitle.Name = "lblTitle"
        '
        'pnlProgress
        '
        resources.ApplyResources(Me.pnlProgress, "pnlProgress")
        Me.pnlProgress.Controls.Add(Me.lblProgressInfo)
        Me.pnlProgress.Name = "pnlProgress"
        '
        'lblProgressInfo
        '
        resources.ApplyResources(Me.lblProgressInfo, "lblProgressInfo")
        Me.lblProgressInfo.Name = "lblProgressInfo"
        '
        'cboLanguage
        '
        resources.ApplyResources(Me.cboLanguage, "cboLanguage")
        Me.cboLanguage.Name = "cboLanguage"
        Me.cboLanguage.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboLanguage.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboLanguage.Properties.Items.AddRange(New Object() {resources.GetString("cboLanguage.Properties.Items"), resources.GetString("cboLanguage.Properties.Items1"), resources.GetString("cboLanguage.Properties.Items2"), resources.GetString("cboLanguage.Properties.Items3")})
        Me.cboLanguage.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblLanguage
        '
        resources.ApplyResources(Me.lblLanguage, "lblLanguage")
        Me.lblLanguage.Name = "lblLanguage"
        '
        'frmAutoSettings
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cmdAutoConfig)
        Me.Controls.Add(Me.cboLanguage)
        Me.Controls.Add(Me.lblLanguage)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.pnlProgress)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAutoSettings"
        CType(Me.pnlProgress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProgress.ResumeLayout(False)
        CType(Me.cboLanguage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAutoConfig As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnlProgress As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblProgressInfo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboLanguage As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblLanguage As DevExpress.XtraEditors.LabelControl
End Class
