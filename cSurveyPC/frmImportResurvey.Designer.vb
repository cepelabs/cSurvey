<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportResurvey
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportResurvey))
        Me.txtPrefix = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtCaveName = New System.Windows.Forms.TextBox()
        Me.lblCaveName = New System.Windows.Forms.Label()
        Me.lblPrefix = New System.Windows.Forms.Label()
        Me.lblNordType = New System.Windows.Forms.Label()
        Me.cboNordType = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPrefix
        '
        Me.txtPrefix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtPrefix, "txtPrefix")
        Me.txtPrefix.Name = "txtPrefix"
        Me.tipDefault.SetToolTip(Me.txtPrefix, resources.GetString("txtPrefix.ToolTip"))
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
        'txtCaveName
        '
        resources.ApplyResources(Me.txtCaveName, "txtCaveName")
        Me.txtCaveName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCaveName.Name = "txtCaveName"
        Me.tipDefault.SetToolTip(Me.txtCaveName, resources.GetString("txtCaveName.ToolTip"))
        '
        'lblCaveName
        '
        resources.ApplyResources(Me.lblCaveName, "lblCaveName")
        Me.lblCaveName.Name = "lblCaveName"
        '
        'lblPrefix
        '
        resources.ApplyResources(Me.lblPrefix, "lblPrefix")
        Me.lblPrefix.Name = "lblPrefix"
        '
        'lblNordType
        '
        resources.ApplyResources(Me.lblNordType, "lblNordType")
        Me.lblNordType.Name = "lblNordType"
        '
        'cboNordType
        '
        Me.cboNordType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNordType.DropDownWidth = 240
        resources.ApplyResources(Me.cboNordType, "cboNordType")
        Me.cboNordType.Items.AddRange(New Object() {resources.GetString("cboNordType.Items"), resources.GetString("cboNordType.Items1")})
        Me.cboNordType.Name = "cboNordType"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.cSurveyPC.My.Resources.Resources.error3
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'frmImportResurvey
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblNordType)
        Me.Controls.Add(Me.cboNordType)
        Me.Controls.Add(Me.txtCaveName)
        Me.Controls.Add(Me.lblCaveName)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.lblPrefix)
        Me.Controls.Add(Me.txtPrefix)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportResurvey"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPrefix As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents txtCaveName As System.Windows.Forms.TextBox
    Friend WithEvents lblCaveName As System.Windows.Forms.Label
    Friend WithEvents lblPrefix As System.Windows.Forms.Label
    Friend WithEvents lblNordType As System.Windows.Forms.Label
    Friend WithEvents cboNordType As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
