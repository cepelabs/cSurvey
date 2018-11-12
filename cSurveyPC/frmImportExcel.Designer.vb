<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImportExcel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportExcel))
        Me.lstSourceFields = New System.Windows.Forms.ListBox()
        Me.txtCaveName = New System.Windows.Forms.TextBox()
        Me.lblCaveName = New System.Windows.Forms.Label()
        Me.txtPrefix = New System.Windows.Forms.TextBox()
        Me.lblPrefix = New System.Windows.Forms.Label()
        Me.btnRemoveAll = New System.Windows.Forms.Button()
        Me.btnAddAll = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.chkFirstline = New System.Windows.Forms.CheckBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.txtFilename = New System.Windows.Forms.TextBox()
        Me.lblFilename = New System.Windows.Forms.Label()
        Me.grdDestField = New cSurveyPC.cGrid()
        Me.colFieldName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFieldType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colFieldValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkAutoSplay = New System.Windows.Forms.CheckBox()
        Me.chkSplaySymbol = New System.Windows.Forms.CheckBox()
        Me.chkCutSplaySymbol = New System.Windows.Forms.CheckBox()
        Me.txtSplayMarker = New System.Windows.Forms.TextBox()
        Me.txtCutSplayMarker = New System.Windows.Forms.TextBox()
        Me.chkZeroPlaceholders = New System.Windows.Forms.CheckBox()
        Me.txtZeroPlaceholders = New System.Windows.Forms.TextBox()
        Me.chkCommentSymbols = New System.Windows.Forms.CheckBox()
        Me.txtCommentSymbols = New System.Windows.Forms.TextBox()
        Me.lblSourceFields = New System.Windows.Forms.Label()
        Me.lblDestinationFields = New System.Windows.Forms.Label()
        CType(Me.grdDestField, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstSourceFields
        '
        resources.ApplyResources(Me.lstSourceFields, "lstSourceFields")
        Me.lstSourceFields.FormattingEnabled = True
        Me.lstSourceFields.Name = "lstSourceFields"
        '
        'txtCaveName
        '
        resources.ApplyResources(Me.txtCaveName, "txtCaveName")
        Me.txtCaveName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCaveName.Name = "txtCaveName"
        '
        'lblCaveName
        '
        resources.ApplyResources(Me.lblCaveName, "lblCaveName")
        Me.lblCaveName.Name = "lblCaveName"
        '
        'txtPrefix
        '
        resources.ApplyResources(Me.txtPrefix, "txtPrefix")
        Me.txtPrefix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrefix.Name = "txtPrefix"
        '
        'lblPrefix
        '
        resources.ApplyResources(Me.lblPrefix, "lblPrefix")
        Me.lblPrefix.Name = "lblPrefix"
        '
        'btnRemoveAll
        '
        resources.ApplyResources(Me.btnRemoveAll, "btnRemoveAll")
        Me.btnRemoveAll.Name = "btnRemoveAll"
        Me.btnRemoveAll.UseVisualStyleBackColor = True
        '
        'btnAddAll
        '
        resources.ApplyResources(Me.btnAddAll, "btnAddAll")
        Me.btnAddAll.Name = "btnAddAll"
        Me.btnAddAll.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        resources.ApplyResources(Me.btnRemove, "btnRemove")
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'chkFirstline
        '
        resources.ApplyResources(Me.chkFirstline, "chkFirstline")
        Me.chkFirstline.Name = "chkFirstline"
        Me.chkFirstline.UseVisualStyleBackColor = True
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
        'txtFilename
        '
        Me.txtFilename.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtFilename, "txtFilename")
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.ReadOnly = True
        '
        'lblFilename
        '
        resources.ApplyResources(Me.lblFilename, "lblFilename")
        Me.lblFilename.Name = "lblFilename"
        '
        'grdDestField
        '
        Me.grdDestField.AllowUserToAddRows = False
        Me.grdDestField.AllowUserToResizeRows = False
        resources.ApplyResources(Me.grdDestField, "grdDestField")
        Me.grdDestField.BackgroundColor = System.Drawing.SystemColors.Control
        Me.grdDestField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdDestField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDestField.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFieldName, Me.colFieldType, Me.colFieldValue})
        Me.grdDestField.Name = "grdDestField"
        Me.grdDestField.RowHeadersVisible = False
        '
        'colFieldName
        '
        resources.ApplyResources(Me.colFieldName, "colFieldName")
        Me.colFieldName.Name = "colFieldName"
        Me.colFieldName.ReadOnly = True
        '
        'colFieldType
        '
        resources.ApplyResources(Me.colFieldType, "colFieldType")
        Me.colFieldType.Items.AddRange(New Object() {"Campo nel file di testo", "Valore fisso"})
        Me.colFieldType.Name = "colFieldType"
        '
        'colFieldValue
        '
        resources.ApplyResources(Me.colFieldValue, "colFieldValue")
        Me.colFieldValue.Name = "colFieldValue"
        '
        'chkAutoSplay
        '
        resources.ApplyResources(Me.chkAutoSplay, "chkAutoSplay")
        Me.chkAutoSplay.Name = "chkAutoSplay"
        Me.chkAutoSplay.UseVisualStyleBackColor = True
        '
        'chkSplaySymbol
        '
        resources.ApplyResources(Me.chkSplaySymbol, "chkSplaySymbol")
        Me.chkSplaySymbol.Name = "chkSplaySymbol"
        Me.chkSplaySymbol.UseVisualStyleBackColor = True
        '
        'chkCutSplaySymbol
        '
        resources.ApplyResources(Me.chkCutSplaySymbol, "chkCutSplaySymbol")
        Me.chkCutSplaySymbol.Name = "chkCutSplaySymbol"
        Me.chkCutSplaySymbol.UseVisualStyleBackColor = True
        '
        'txtSplayMarker
        '
        resources.ApplyResources(Me.txtSplayMarker, "txtSplayMarker")
        Me.txtSplayMarker.Name = "txtSplayMarker"
        '
        'txtCutSplayMarker
        '
        resources.ApplyResources(Me.txtCutSplayMarker, "txtCutSplayMarker")
        Me.txtCutSplayMarker.Name = "txtCutSplayMarker"
        '
        'chkZeroPlaceholders
        '
        resources.ApplyResources(Me.chkZeroPlaceholders, "chkZeroPlaceholders")
        Me.chkZeroPlaceholders.Name = "chkZeroPlaceholders"
        Me.chkZeroPlaceholders.UseVisualStyleBackColor = True
        '
        'txtZeroPlaceholders
        '
        resources.ApplyResources(Me.txtZeroPlaceholders, "txtZeroPlaceholders")
        Me.txtZeroPlaceholders.Name = "txtZeroPlaceholders"
        '
        'chkCommentSymbols
        '
        resources.ApplyResources(Me.chkCommentSymbols, "chkCommentSymbols")
        Me.chkCommentSymbols.Name = "chkCommentSymbols"
        Me.chkCommentSymbols.UseVisualStyleBackColor = True
        '
        'txtCommentSymbols
        '
        resources.ApplyResources(Me.txtCommentSymbols, "txtCommentSymbols")
        Me.txtCommentSymbols.Name = "txtCommentSymbols"
        '
        'lblSourceFields
        '
        resources.ApplyResources(Me.lblSourceFields, "lblSourceFields")
        Me.lblSourceFields.Name = "lblSourceFields"
        '
        'lblDestinationFields
        '
        resources.ApplyResources(Me.lblDestinationFields, "lblDestinationFields")
        Me.lblDestinationFields.Name = "lblDestinationFields"
        '
        'frmImportExcel
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.lblDestinationFields)
        Me.Controls.Add(Me.lblSourceFields)
        Me.Controls.Add(Me.txtCommentSymbols)
        Me.Controls.Add(Me.chkCommentSymbols)
        Me.Controls.Add(Me.txtZeroPlaceholders)
        Me.Controls.Add(Me.chkZeroPlaceholders)
        Me.Controls.Add(Me.txtCutSplayMarker)
        Me.Controls.Add(Me.txtSplayMarker)
        Me.Controls.Add(Me.chkCutSplaySymbol)
        Me.Controls.Add(Me.chkSplaySymbol)
        Me.Controls.Add(Me.chkAutoSplay)
        Me.Controls.Add(Me.grdDestField)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.chkFirstline)
        Me.Controls.Add(Me.btnRemoveAll)
        Me.Controls.Add(Me.btnAddAll)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtCaveName)
        Me.Controls.Add(Me.lblCaveName)
        Me.Controls.Add(Me.txtPrefix)
        Me.Controls.Add(Me.lblPrefix)
        Me.Controls.Add(Me.lstSourceFields)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportExcel"
        CType(Me.grdDestField, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstSourceFields As System.Windows.Forms.ListBox
    Friend WithEvents txtCaveName As System.Windows.Forms.TextBox
    Friend WithEvents lblCaveName As System.Windows.Forms.Label
    Friend WithEvents txtPrefix As System.Windows.Forms.TextBox
    Friend WithEvents lblPrefix As System.Windows.Forms.Label
    Friend WithEvents btnRemoveAll As System.Windows.Forms.Button
    Friend WithEvents btnAddAll As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents chkFirstline As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Friend WithEvents lblFilename As System.Windows.Forms.Label
    Friend WithEvents grdDestField As cSurveyPC.cGrid
    Friend WithEvents chkAutoSplay As System.Windows.Forms.CheckBox
    Friend WithEvents colFieldName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFieldType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colFieldValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkSplaySymbol As CheckBox
    Friend WithEvents chkCutSplaySymbol As CheckBox
    Friend WithEvents txtSplayMarker As TextBox
    Friend WithEvents txtCutSplayMarker As TextBox
    Friend WithEvents chkZeroPlaceholders As CheckBox
    Friend WithEvents txtZeroPlaceholders As TextBox
    Friend WithEvents chkCommentSymbols As CheckBox
    Friend WithEvents txtCommentSymbols As TextBox
    Friend WithEvents lblSourceFields As Label
    Friend WithEvents lblDestinationFields As Label
End Class
