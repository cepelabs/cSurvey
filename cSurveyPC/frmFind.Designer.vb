<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFind
    Inherits cDockContentWindow

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFind))
        Me.lblFind = New System.Windows.Forms.Label()
        Me.cboFind = New System.Windows.Forms.ComboBox()
        Me.grpFindOptions = New System.Windows.Forms.GroupBox()
        Me.lblFindWhere = New System.Windows.Forms.Label()
        Me.cboFindWhere = New System.Windows.Forms.ComboBox()
        Me.chkFindJolly = New System.Windows.Forms.CheckBox()
        Me.chkFindWholeWord = New System.Windows.Forms.CheckBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.grpFindOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblFind
        '
        resources.ApplyResources(Me.lblFind, "lblFind")
        Me.lblFind.Name = "lblFind"
        '
        'cboFind
        '
        resources.ApplyResources(Me.cboFind, "cboFind")
        Me.cboFind.FormattingEnabled = True
        Me.cboFind.Name = "cboFind"
        '
        'grpFindOptions
        '
        resources.ApplyResources(Me.grpFindOptions, "grpFindOptions")
        Me.grpFindOptions.Controls.Add(Me.lblFindWhere)
        Me.grpFindOptions.Controls.Add(Me.cboFindWhere)
        Me.grpFindOptions.Controls.Add(Me.chkFindJolly)
        Me.grpFindOptions.Controls.Add(Me.chkFindWholeWord)
        Me.grpFindOptions.Name = "grpFindOptions"
        Me.grpFindOptions.TabStop = False
        '
        'lblFindWhere
        '
        resources.ApplyResources(Me.lblFindWhere, "lblFindWhere")
        Me.lblFindWhere.Name = "lblFindWhere"
        '
        'cboFindWhere
        '
        Me.cboFindWhere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFindWhere.FormattingEnabled = True
        Me.cboFindWhere.Items.AddRange(New Object() {resources.GetString("cboFindWhere.Items"), resources.GetString("cboFindWhere.Items1")})
        resources.ApplyResources(Me.cboFindWhere, "cboFindWhere")
        Me.cboFindWhere.Name = "cboFindWhere"
        '
        'chkFindJolly
        '
        resources.ApplyResources(Me.chkFindJolly, "chkFindJolly")
        Me.chkFindJolly.Name = "chkFindJolly"
        Me.chkFindJolly.UseVisualStyleBackColor = True
        '
        'chkFindWholeWord
        '
        resources.ApplyResources(Me.chkFindWholeWord, "chkFindWholeWord")
        Me.chkFindWholeWord.Name = "chkFindWholeWord"
        Me.chkFindWholeWord.UseVisualStyleBackColor = True
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
        'frmFind
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.grpFindOptions)
        Me.Controls.Add(Me.cboFind)
        Me.Controls.Add(Me.lblFind)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFind"
        Me.TopMost = True
        Me.grpFindOptions.ResumeLayout(False)
        Me.grpFindOptions.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFind As System.Windows.Forms.Label
    Friend WithEvents cboFind As System.Windows.Forms.ComboBox
    Friend WithEvents grpFindOptions As System.Windows.Forms.GroupBox
    Friend WithEvents chkFindWholeWord As System.Windows.Forms.CheckBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents chkFindJolly As System.Windows.Forms.CheckBox
    Friend WithEvents lblFindWhere As System.Windows.Forms.Label
    Friend WithEvents cboFindWhere As System.Windows.Forms.ComboBox
End Class
