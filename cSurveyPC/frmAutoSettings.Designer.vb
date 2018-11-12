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
        Me.cmdAutoConfig = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlProgress = New System.Windows.Forms.Panel()
        Me.lblProgressInfo = New System.Windows.Forms.Label()
        Me.cboLanguage = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlProgress.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdAutoConfig
        '
        resources.ApplyResources(Me.cmdAutoConfig, "cmdAutoConfig")
        Me.cmdAutoConfig.Name = "cmdAutoConfig"
        Me.cmdAutoConfig.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        resources.ApplyResources(Me.lblTitle, "lblTitle")
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
        Me.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLanguage.FormattingEnabled = True
        Me.cboLanguage.Items.AddRange(New Object() {resources.GetString("cboLanguage.Items"), resources.GetString("cboLanguage.Items1"), resources.GetString("cboLanguage.Items2"), resources.GetString("cboLanguage.Items3")})
        Me.cboLanguage.Name = "cboLanguage"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'frmAutoSettings
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cboLanguage)
        Me.Controls.Add(Me.cmdAutoConfig)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.pnlProgress)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAutoSettings"
        Me.pnlProgress.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAutoConfig As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlProgress As System.Windows.Forms.Panel
    Friend WithEvents lblProgressInfo As System.Windows.Forms.Label
    Friend WithEvents cboLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
