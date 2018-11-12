<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCaveRegisterSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCaveRegisterSettings))
        Me.tbSessions = New System.Windows.Forms.ToolStrip()
        Me.btnServiceAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnServiceDelete = New System.Windows.Forms.ToolStripButton()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.tvSettings = New System.Windows.Forms.TreeView()
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.pnlDataField = New System.Windows.Forms.Panel()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.lblURL = New System.Windows.Forms.Label()
        Me.tbSessions.SuspendLayout()
        Me.pnlDataField.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbSessions
        '
        resources.ApplyResources(Me.tbSessions, "tbSessions")
        Me.tbSessions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbSessions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnServiceAdd, Me.ToolStripSeparator2, Me.btnServiceDelete})
        Me.tbSessions.Name = "tbSessions"
        '
        'btnServiceAdd
        '
        Me.btnServiceAdd.Image = Global.cSurveyPC.My.Resources.Resources.add
        resources.ApplyResources(Me.btnServiceAdd, "btnServiceAdd")
        Me.btnServiceAdd.Name = "btnServiceAdd"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'btnServiceDelete
        '
        Me.btnServiceDelete.Image = Global.cSurveyPC.My.Resources.Resources.cross
        resources.ApplyResources(Me.btnServiceDelete, "btnServiceDelete")
        Me.btnServiceDelete.Name = "btnServiceDelete"
        '
        'txtID
        '
        resources.ApplyResources(Me.txtID, "txtID")
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        '
        'lblID
        '
        resources.ApplyResources(Me.lblID, "lblID")
        Me.lblID.Name = "lblID"
        '
        'tvSettings
        '
        resources.ApplyResources(Me.tvSettings, "tvSettings")
        Me.tvSettings.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvSettings.HideSelection = False
        Me.tvSettings.ImageList = Me.iml
        Me.tvSettings.Name = "tvSettings"
        '
        'iml
        '
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.Transparent
        Me.iml.Images.SetKeyName(0, "setting")
        Me.iml.Images.SetKeyName(1, "deleted")
        '
        'txtName
        '
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.Name = "txtName"
        '
        'lblName
        '
        resources.ApplyResources(Me.lblName, "lblName")
        Me.lblName.Name = "lblName"
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
        'pnlDataField
        '
        Me.pnlDataField.Controls.Add(Me.txtPassword)
        Me.pnlDataField.Controls.Add(Me.lblPassword)
        Me.pnlDataField.Controls.Add(Me.txtUsername)
        Me.pnlDataField.Controls.Add(Me.lblUsername)
        Me.pnlDataField.Controls.Add(Me.txtURL)
        Me.pnlDataField.Controls.Add(Me.lblURL)
        Me.pnlDataField.Controls.Add(Me.txtName)
        Me.pnlDataField.Controls.Add(Me.txtID)
        Me.pnlDataField.Controls.Add(Me.lblID)
        Me.pnlDataField.Controls.Add(Me.lblName)
        resources.ApplyResources(Me.pnlDataField, "pnlDataField")
        Me.pnlDataField.Name = "pnlDataField"
        '
        'txtPassword
        '
        resources.ApplyResources(Me.txtPassword, "txtPassword")
        Me.txtPassword.Name = "txtPassword"
        '
        'lblPassword
        '
        resources.ApplyResources(Me.lblPassword, "lblPassword")
        Me.lblPassword.Name = "lblPassword"
        '
        'txtUsername
        '
        resources.ApplyResources(Me.txtUsername, "txtUsername")
        Me.txtUsername.Name = "txtUsername"
        '
        'lblUsername
        '
        resources.ApplyResources(Me.lblUsername, "lblUsername")
        Me.lblUsername.Name = "lblUsername"
        '
        'txtURL
        '
        resources.ApplyResources(Me.txtURL, "txtURL")
        Me.txtURL.Name = "txtURL"
        '
        'lblURL
        '
        resources.ApplyResources(Me.lblURL, "lblURL")
        Me.lblURL.Name = "lblURL"
        '
        'frmCaveRegisterSettings
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.tbSessions)
        Me.Controls.Add(Me.tvSettings)
        Me.Controls.Add(Me.pnlDataField)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCaveRegisterSettings"
        Me.tbSessions.ResumeLayout(False)
        Me.tbSessions.PerformLayout()
        Me.pnlDataField.ResumeLayout(False)
        Me.pnlDataField.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbSessions As System.Windows.Forms.ToolStrip
    Friend WithEvents btnServiceAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnServiceDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents tvSettings As System.Windows.Forms.TreeView
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents pnlDataField As System.Windows.Forms.Panel
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents lblURL As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblUsername As System.Windows.Forms.Label
End Class
