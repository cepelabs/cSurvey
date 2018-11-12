<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataFieldsEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDataFieldsEditor))
        Me.tbSessions = New System.Windows.Forms.ToolStrip()
        Me.btnDataFieldAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDataFieldDelete = New System.Windows.Forms.ToolStripButton()
        Me.txtDataFieldName = New System.Windows.Forms.TextBox()
        Me.lblDataFieldName = New System.Windows.Forms.Label()
        Me.tvDataFields = New System.Windows.Forms.TreeView()
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.txtDataFieldDescription = New System.Windows.Forms.TextBox()
        Me.lblDataFieldDescription = New System.Windows.Forms.Label()
        Me.cboDataFieldType = New System.Windows.Forms.ComboBox()
        Me.lblDataFieldType = New System.Windows.Forms.Label()
        Me.pnlDataFieldEnum = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtDataFieldEnumValues = New System.Windows.Forms.TextBox()
        Me.lblDataFieldEnumValues = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.pnlDataField = New System.Windows.Forms.Panel()
        Me.txtDataFieldCategory = New System.Windows.Forms.TextBox()
        Me.lblDataFieldCategory = New System.Windows.Forms.Label()
        Me.tbSessions.SuspendLayout()
        Me.pnlDataFieldEnum.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDataField.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbSessions
        '
        resources.ApplyResources(Me.tbSessions, "tbSessions")
        Me.tbSessions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbSessions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnDataFieldAdd, Me.ToolStripSeparator2, Me.btnDataFieldDelete})
        Me.tbSessions.Name = "tbSessions"
        '
        'btnDataFieldAdd
        '
        Me.btnDataFieldAdd.Image = Global.cSurveyPC.My.Resources.Resources.add
        resources.ApplyResources(Me.btnDataFieldAdd, "btnDataFieldAdd")
        Me.btnDataFieldAdd.Name = "btnDataFieldAdd"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'btnDataFieldDelete
        '
        Me.btnDataFieldDelete.Image = Global.cSurveyPC.My.Resources.Resources.cross
        resources.ApplyResources(Me.btnDataFieldDelete, "btnDataFieldDelete")
        Me.btnDataFieldDelete.Name = "btnDataFieldDelete"
        '
        'txtDataFieldName
        '
        resources.ApplyResources(Me.txtDataFieldName, "txtDataFieldName")
        Me.txtDataFieldName.Name = "txtDataFieldName"
        '
        'lblDataFieldName
        '
        resources.ApplyResources(Me.lblDataFieldName, "lblDataFieldName")
        Me.lblDataFieldName.Name = "lblDataFieldName"
        '
        'tvDataFields
        '
        resources.ApplyResources(Me.tvDataFields, "tvDataFields")
        Me.tvDataFields.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvDataFields.HideSelection = False
        Me.tvDataFields.ImageList = Me.iml
        Me.tvDataFields.Name = "tvDataFields"
        '
        'iml
        '
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.Transparent
        Me.iml.Images.SetKeyName(0, "datafield")
        Me.iml.Images.SetKeyName(1, "deleted")
        '
        'txtDataFieldDescription
        '
        resources.ApplyResources(Me.txtDataFieldDescription, "txtDataFieldDescription")
        Me.txtDataFieldDescription.Name = "txtDataFieldDescription"
        '
        'lblDataFieldDescription
        '
        resources.ApplyResources(Me.lblDataFieldDescription, "lblDataFieldDescription")
        Me.lblDataFieldDescription.Name = "lblDataFieldDescription"
        '
        'cboDataFieldType
        '
        Me.cboDataFieldType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDataFieldType.DropDownWidth = 320
        Me.cboDataFieldType.FormattingEnabled = True
        Me.cboDataFieldType.Items.AddRange(New Object() {resources.GetString("cboDataFieldType.Items"), resources.GetString("cboDataFieldType.Items1"), resources.GetString("cboDataFieldType.Items2"), resources.GetString("cboDataFieldType.Items3"), resources.GetString("cboDataFieldType.Items4"), resources.GetString("cboDataFieldType.Items5"), resources.GetString("cboDataFieldType.Items6"), resources.GetString("cboDataFieldType.Items7"), resources.GetString("cboDataFieldType.Items8")})
        resources.ApplyResources(Me.cboDataFieldType, "cboDataFieldType")
        Me.cboDataFieldType.Name = "cboDataFieldType"
        '
        'lblDataFieldType
        '
        resources.ApplyResources(Me.lblDataFieldType, "lblDataFieldType")
        Me.lblDataFieldType.Name = "lblDataFieldType"
        '
        'pnlDataFieldEnum
        '
        Me.pnlDataFieldEnum.Controls.Add(Me.Label11)
        Me.pnlDataFieldEnum.Controls.Add(Me.PictureBox2)
        Me.pnlDataFieldEnum.Controls.Add(Me.txtDataFieldEnumValues)
        Me.pnlDataFieldEnum.Controls.Add(Me.lblDataFieldEnumValues)
        resources.ApplyResources(Me.pnlDataFieldEnum, "pnlDataFieldEnum")
        Me.pnlDataFieldEnum.Name = "pnlDataFieldEnum"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'PictureBox2
        '
        resources.ApplyResources(Me.PictureBox2, "PictureBox2")
        Me.PictureBox2.Image = Global.cSurveyPC.My.Resources.Resources._error
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.TabStop = False
        '
        'txtDataFieldEnumValues
        '
        resources.ApplyResources(Me.txtDataFieldEnumValues, "txtDataFieldEnumValues")
        Me.txtDataFieldEnumValues.Name = "txtDataFieldEnumValues"
        '
        'lblDataFieldEnumValues
        '
        resources.ApplyResources(Me.lblDataFieldEnumValues, "lblDataFieldEnumValues")
        Me.lblDataFieldEnumValues.Name = "lblDataFieldEnumValues"
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
        Me.pnlDataField.Controls.Add(Me.txtDataFieldCategory)
        Me.pnlDataField.Controls.Add(Me.lblDataFieldCategory)
        Me.pnlDataField.Controls.Add(Me.cboDataFieldType)
        Me.pnlDataField.Controls.Add(Me.txtDataFieldDescription)
        Me.pnlDataField.Controls.Add(Me.pnlDataFieldEnum)
        Me.pnlDataField.Controls.Add(Me.txtDataFieldName)
        Me.pnlDataField.Controls.Add(Me.lblDataFieldType)
        Me.pnlDataField.Controls.Add(Me.lblDataFieldName)
        Me.pnlDataField.Controls.Add(Me.lblDataFieldDescription)
        resources.ApplyResources(Me.pnlDataField, "pnlDataField")
        Me.pnlDataField.Name = "pnlDataField"
        '
        'txtDataFieldCategory
        '
        resources.ApplyResources(Me.txtDataFieldCategory, "txtDataFieldCategory")
        Me.txtDataFieldCategory.Name = "txtDataFieldCategory"
        '
        'lblDataFieldCategory
        '
        resources.ApplyResources(Me.lblDataFieldCategory, "lblDataFieldCategory")
        Me.lblDataFieldCategory.Name = "lblDataFieldCategory"
        '
        'frmDataFieldsEditor
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.tbSessions)
        Me.Controls.Add(Me.tvDataFields)
        Me.Controls.Add(Me.pnlDataField)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDataFieldsEditor"
        Me.tbSessions.ResumeLayout(False)
        Me.tbSessions.PerformLayout()
        Me.pnlDataFieldEnum.ResumeLayout(False)
        Me.pnlDataFieldEnum.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDataField.ResumeLayout(False)
        Me.pnlDataField.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbSessions As System.Windows.Forms.ToolStrip
    Friend WithEvents btnDataFieldAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDataFieldDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtDataFieldName As System.Windows.Forms.TextBox
    Friend WithEvents lblDataFieldName As System.Windows.Forms.Label
    Friend WithEvents tvDataFields As System.Windows.Forms.TreeView
    Friend WithEvents txtDataFieldDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblDataFieldDescription As System.Windows.Forms.Label
    Friend WithEvents cboDataFieldType As System.Windows.Forms.ComboBox
    Friend WithEvents lblDataFieldType As System.Windows.Forms.Label
    Friend WithEvents pnlDataFieldEnum As System.Windows.Forms.Panel
    Friend WithEvents txtDataFieldEnumValues As System.Windows.Forms.TextBox
    Friend WithEvents lblDataFieldEnumValues As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents pnlDataField As System.Windows.Forms.Panel
    Friend WithEvents txtDataFieldCategory As System.Windows.Forms.TextBox
    Friend WithEvents lblDataFieldCategory As System.Windows.Forms.Label
End Class
