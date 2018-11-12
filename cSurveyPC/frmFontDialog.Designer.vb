<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFontDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFontDialog))
        Me.lblFontchar = New System.Windows.Forms.Label()
        Me.chkFontUnderline = New System.Windows.Forms.CheckBox()
        Me.cboFontChar = New System.Windows.Forms.ComboBox()
        Me.chkFontBold = New System.Windows.Forms.CheckBox()
        Me.lblFontSize = New System.Windows.Forms.Label()
        Me.cboFontSize = New System.Windows.Forms.ComboBox()
        Me.chkFontItalic = New System.Windows.Forms.CheckBox()
        Me.pnlPreview = New System.Windows.Forms.Panel()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblFontchar
        '
        resources.ApplyResources(Me.lblFontchar, "lblFontchar")
        Me.lblFontchar.Name = "lblFontchar"
        '
        'chkFontUnderline
        '
        resources.ApplyResources(Me.chkFontUnderline, "chkFontUnderline")
        Me.chkFontUnderline.Image = Global.cSurveyPC.My.Resources.Resources.text_underline
        Me.chkFontUnderline.Name = "chkFontUnderline"
        Me.chkFontUnderline.UseVisualStyleBackColor = True
        '
        'cboFontChar
        '
        resources.ApplyResources(Me.cboFontChar, "cboFontChar")
        Me.cboFontChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFontChar.FormattingEnabled = True
        Me.cboFontChar.Name = "cboFontChar"
        '
        'chkFontBold
        '
        resources.ApplyResources(Me.chkFontBold, "chkFontBold")
        Me.chkFontBold.Image = Global.cSurveyPC.My.Resources.Resources.text_bold
        Me.chkFontBold.Name = "chkFontBold"
        Me.chkFontBold.UseVisualStyleBackColor = True
        '
        'lblFontSize
        '
        resources.ApplyResources(Me.lblFontSize, "lblFontSize")
        Me.lblFontSize.Name = "lblFontSize"
        '
        'cboFontSize
        '
        resources.ApplyResources(Me.cboFontSize, "cboFontSize")
        Me.cboFontSize.FormattingEnabled = True
        Me.cboFontSize.Items.AddRange(New Object() {resources.GetString("cboFontSize.Items"), resources.GetString("cboFontSize.Items1"), resources.GetString("cboFontSize.Items2"), resources.GetString("cboFontSize.Items3"), resources.GetString("cboFontSize.Items4"), resources.GetString("cboFontSize.Items5"), resources.GetString("cboFontSize.Items6"), resources.GetString("cboFontSize.Items7"), resources.GetString("cboFontSize.Items8"), resources.GetString("cboFontSize.Items9"), resources.GetString("cboFontSize.Items10"), resources.GetString("cboFontSize.Items11"), resources.GetString("cboFontSize.Items12"), resources.GetString("cboFontSize.Items13"), resources.GetString("cboFontSize.Items14"), resources.GetString("cboFontSize.Items15"), resources.GetString("cboFontSize.Items16")})
        Me.cboFontSize.Name = "cboFontSize"
        '
        'chkFontItalic
        '
        resources.ApplyResources(Me.chkFontItalic, "chkFontItalic")
        Me.chkFontItalic.Image = Global.cSurveyPC.My.Resources.Resources.text_italic
        Me.chkFontItalic.Name = "chkFontItalic"
        Me.chkFontItalic.UseVisualStyleBackColor = True
        '
        'pnlPreview
        '
        resources.ApplyResources(Me.pnlPreview, "pnlPreview")
        Me.pnlPreview.BackColor = System.Drawing.Color.White
        Me.pnlPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPreview.Name = "pnlPreview"
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmFontDialog
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.pnlPreview)
        Me.Controls.Add(Me.lblFontchar)
        Me.Controls.Add(Me.chkFontUnderline)
        Me.Controls.Add(Me.cboFontChar)
        Me.Controls.Add(Me.chkFontBold)
        Me.Controls.Add(Me.lblFontSize)
        Me.Controls.Add(Me.cboFontSize)
        Me.Controls.Add(Me.chkFontItalic)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFontDialog"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFontchar As System.Windows.Forms.Label
    Friend WithEvents chkFontUnderline As System.Windows.Forms.CheckBox
    Friend WithEvents cboFontChar As System.Windows.Forms.ComboBox
    Friend WithEvents chkFontBold As System.Windows.Forms.CheckBox
    Friend WithEvents lblFontSize As System.Windows.Forms.Label
    Friend WithEvents cboFontSize As System.Windows.Forms.ComboBox
    Friend WithEvents chkFontItalic As System.Windows.Forms.CheckBox
    Friend WithEvents pnlPreview As System.Windows.Forms.Panel
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
