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
        Me.lstSourceFields = New DevExpress.XtraEditors.ListBoxControl()
        Me.txtCaveName = New DevExpress.XtraEditors.TextEdit()
        Me.lblCaveName = New DevExpress.XtraEditors.LabelControl()
        Me.txtPrefix = New DevExpress.XtraEditors.TextEdit()
        Me.lblPrefix = New DevExpress.XtraEditors.LabelControl()
        Me.btnRemoveAll = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAddAll = New DevExpress.XtraEditors.SimpleButton()
        Me.btnRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.chkFirstline = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.txtFilename = New DevExpress.XtraEditors.TextEdit()
        Me.lblFilename = New DevExpress.XtraEditors.LabelControl()
        Me.chkAutoSplay = New DevExpress.XtraEditors.CheckEdit()
        Me.chkSplaySymbol = New DevExpress.XtraEditors.CheckEdit()
        Me.chkCutSplaySymbol = New DevExpress.XtraEditors.CheckEdit()
        Me.txtSplayMarker = New DevExpress.XtraEditors.TextEdit()
        Me.txtCutSplayMarker = New DevExpress.XtraEditors.TextEdit()
        Me.chkZeroPlaceholders = New DevExpress.XtraEditors.CheckEdit()
        Me.txtZeroPlaceholders = New DevExpress.XtraEditors.TextEdit()
        Me.chkCommentSymbols = New DevExpress.XtraEditors.CheckEdit()
        Me.txtCommentSymbols = New DevExpress.XtraEditors.TextEdit()
        Me.lblSourceFields = New DevExpress.XtraEditors.LabelControl()
        Me.lblDestinationFields = New DevExpress.XtraEditors.LabelControl()
        Me.tvDestField = New DevExpress.XtraTreeList.TreeList()
        Me.colFieldsName = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colFieldsType = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cboFieldsType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colFieldsValue = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.btnMoveUp = New DevExpress.XtraEditors.SimpleButton()
        Me.btnMoveDown = New DevExpress.XtraEditors.SimpleButton()
        Me.lblSession = New DevExpress.XtraEditors.LabelControl()
        Me.cboSession = New cSurveyPC.cSessionDropDown()
        Me.tabMain = New DevExpress.XtraTab.XtraTabControl()
        Me.tabFields = New DevExpress.XtraTab.XtraTabPage()
        Me.tabOptions = New DevExpress.XtraTab.XtraTabPage()
        Me.chkProgressiveDistance = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.lstSourceFields, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaveName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrefix.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkFirstline.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFilename.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAutoSplay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSplaySymbol.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCutSplaySymbol.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSplayMarker.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCutSplayMarker.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkZeroPlaceholders.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtZeroPlaceholders.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCommentSymbols.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCommentSymbols.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tvDestField, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFieldsType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMain.SuspendLayout()
        Me.tabFields.SuspendLayout()
        Me.tabOptions.SuspendLayout()
        CType(Me.chkProgressiveDistance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstSourceFields
        '
        resources.ApplyResources(Me.lstSourceFields, "lstSourceFields")
        Me.lstSourceFields.Name = "lstSourceFields"
        '
        'txtCaveName
        '
        resources.ApplyResources(Me.txtCaveName, "txtCaveName")
        Me.txtCaveName.Name = "txtCaveName"
        '
        'lblCaveName
        '
        Me.lblCaveName.Appearance.Font = CType(resources.GetObject("lblCaveName.Appearance.Font"), System.Drawing.Font)
        Me.lblCaveName.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblCaveName, "lblCaveName")
        Me.lblCaveName.Name = "lblCaveName"
        '
        'txtPrefix
        '
        resources.ApplyResources(Me.txtPrefix, "txtPrefix")
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        '
        'lblPrefix
        '
        Me.lblPrefix.Appearance.Font = CType(resources.GetObject("lblPrefix.Appearance.Font"), System.Drawing.Font)
        Me.lblPrefix.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPrefix, "lblPrefix")
        Me.lblPrefix.Name = "lblPrefix"
        '
        'btnRemoveAll
        '
        resources.ApplyResources(Me.btnRemoveAll, "btnRemoveAll")
        Me.btnRemoveAll.Name = "btnRemoveAll"
        '
        'btnAddAll
        '
        resources.ApplyResources(Me.btnAddAll, "btnAddAll")
        Me.btnAddAll.Name = "btnAddAll"
        '
        'btnRemove
        '
        resources.ApplyResources(Me.btnRemove, "btnRemove")
        Me.btnRemove.Name = "btnRemove"
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Name = "btnAdd"
        '
        'chkFirstline
        '
        resources.ApplyResources(Me.chkFirstline, "chkFirstline")
        Me.chkFirstline.Name = "chkFirstline"
        Me.chkFirstline.Properties.AutoWidth = True
        Me.chkFirstline.Properties.Caption = resources.GetString("chkFirstline.Properties.Caption")
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
        'chkAutoSplay
        '
        resources.ApplyResources(Me.chkAutoSplay, "chkAutoSplay")
        Me.chkAutoSplay.Name = "chkAutoSplay"
        Me.chkAutoSplay.Properties.AutoWidth = True
        Me.chkAutoSplay.Properties.Caption = resources.GetString("chkAutoSplay.Properties.Caption")
        '
        'chkSplaySymbol
        '
        resources.ApplyResources(Me.chkSplaySymbol, "chkSplaySymbol")
        Me.chkSplaySymbol.Name = "chkSplaySymbol"
        Me.chkSplaySymbol.Properties.AutoWidth = True
        Me.chkSplaySymbol.Properties.Caption = resources.GetString("chkSplaySymbol.Properties.Caption")
        '
        'chkCutSplaySymbol
        '
        resources.ApplyResources(Me.chkCutSplaySymbol, "chkCutSplaySymbol")
        Me.chkCutSplaySymbol.Name = "chkCutSplaySymbol"
        Me.chkCutSplaySymbol.Properties.AutoWidth = True
        Me.chkCutSplaySymbol.Properties.Caption = resources.GetString("chkCutSplaySymbol.Properties.Caption")
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
        Me.chkZeroPlaceholders.Properties.AutoWidth = True
        Me.chkZeroPlaceholders.Properties.Caption = resources.GetString("chkZeroPlaceholders.Properties.Caption")
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
        Me.chkCommentSymbols.Properties.AutoWidth = True
        Me.chkCommentSymbols.Properties.Caption = resources.GetString("chkCommentSymbols.Properties.Caption")
        '
        'txtCommentSymbols
        '
        resources.ApplyResources(Me.txtCommentSymbols, "txtCommentSymbols")
        Me.txtCommentSymbols.Name = "txtCommentSymbols"
        '
        'lblSourceFields
        '
        Me.lblSourceFields.Appearance.Font = CType(resources.GetObject("lblSourceFields.Appearance.Font"), System.Drawing.Font)
        Me.lblSourceFields.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblSourceFields, "lblSourceFields")
        Me.lblSourceFields.Name = "lblSourceFields"
        '
        'lblDestinationFields
        '
        Me.lblDestinationFields.Appearance.Font = CType(resources.GetObject("lblDestinationFields.Appearance.Font"), System.Drawing.Font)
        Me.lblDestinationFields.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblDestinationFields, "lblDestinationFields")
        Me.lblDestinationFields.Name = "lblDestinationFields"
        '
        'tvDestField
        '
        resources.ApplyResources(Me.tvDestField, "tvDestField")
        Me.tvDestField.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colFieldsName, Me.colFieldsType, Me.colFieldsValue})
        Me.tvDestField.Name = "tvDestField"
        Me.tvDestField.OptionsView.ShowIndicator = False
        Me.tvDestField.OptionsView.ShowRoot = False
        Me.tvDestField.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cboFieldsType})
        '
        'colFieldsName
        '
        resources.ApplyResources(Me.colFieldsName, "colFieldsName")
        Me.colFieldsName.FieldName = "Name"
        Me.colFieldsName.Name = "colFieldsName"
        Me.colFieldsName.OptionsColumn.ReadOnly = True
        '
        'colFieldsType
        '
        resources.ApplyResources(Me.colFieldsType, "colFieldsType")
        Me.colFieldsType.ColumnEdit = Me.cboFieldsType
        Me.colFieldsType.FieldName = "Type"
        Me.colFieldsType.Name = "colFieldsType"
        '
        'cboFieldsType
        '
        resources.ApplyResources(Me.cboFieldsType, "cboFieldsType")
        Me.cboFieldsType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboFieldsType.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboFieldsType.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cboFieldsType.Columns"), resources.GetString("cboFieldsType.Columns1"))})
        Me.cboFieldsType.Name = "cboFieldsType"
        Me.cboFieldsType.ShowFooter = False
        Me.cboFieldsType.ShowHeader = False
        '
        'colFieldsValue
        '
        resources.ApplyResources(Me.colFieldsValue, "colFieldsValue")
        Me.colFieldsValue.FieldName = "Value"
        Me.colFieldsValue.Name = "colFieldsValue"
        '
        'btnMoveUp
        '
        resources.ApplyResources(Me.btnMoveUp, "btnMoveUp")
        Me.btnMoveUp.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnMoveUp.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.moveup
        Me.btnMoveUp.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.btnMoveUp.Name = "btnMoveUp"
        '
        'btnMoveDown
        '
        resources.ApplyResources(Me.btnMoveDown, "btnMoveDown")
        Me.btnMoveDown.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnMoveDown.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.movedown
        Me.btnMoveDown.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.btnMoveDown.Name = "btnMoveDown"
        '
        'lblSession
        '
        Me.lblSession.Appearance.Font = CType(resources.GetObject("lblSession.Appearance.Font"), System.Drawing.Font)
        Me.lblSession.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblSession, "lblSession")
        Me.lblSession.Name = "lblSession"
        '
        'cboSession
        '
        Me.cboSession.EditValue = Nothing
        resources.ApplyResources(Me.cboSession, "cboSession")
        Me.cboSession.Name = "cboSession"
        '
        'tabMain
        '
        resources.ApplyResources(Me.tabMain, "tabMain")
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedTabPage = Me.tabFields
        Me.tabMain.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabFields, Me.tabOptions})
        '
        'tabFields
        '
        Me.tabFields.Controls.Add(Me.lblSourceFields)
        Me.tabFields.Controls.Add(Me.lstSourceFields)
        Me.tabFields.Controls.Add(Me.btnMoveDown)
        Me.tabFields.Controls.Add(Me.btnAdd)
        Me.tabFields.Controls.Add(Me.btnMoveUp)
        Me.tabFields.Controls.Add(Me.btnRemove)
        Me.tabFields.Controls.Add(Me.tvDestField)
        Me.tabFields.Controls.Add(Me.btnAddAll)
        Me.tabFields.Controls.Add(Me.lblDestinationFields)
        Me.tabFields.Controls.Add(Me.btnRemoveAll)
        Me.tabFields.Name = "tabFields"
        resources.ApplyResources(Me.tabFields, "tabFields")
        '
        'tabOptions
        '
        Me.tabOptions.Controls.Add(Me.chkProgressiveDistance)
        Me.tabOptions.Controls.Add(Me.chkAutoSplay)
        Me.tabOptions.Controls.Add(Me.chkSplaySymbol)
        Me.tabOptions.Controls.Add(Me.txtCommentSymbols)
        Me.tabOptions.Controls.Add(Me.chkCommentSymbols)
        Me.tabOptions.Controls.Add(Me.chkCutSplaySymbol)
        Me.tabOptions.Controls.Add(Me.txtZeroPlaceholders)
        Me.tabOptions.Controls.Add(Me.chkZeroPlaceholders)
        Me.tabOptions.Controls.Add(Me.txtSplayMarker)
        Me.tabOptions.Controls.Add(Me.txtCutSplayMarker)
        Me.tabOptions.Name = "tabOptions"
        resources.ApplyResources(Me.tabOptions, "tabOptions")
        '
        'chkProgressiveDistance
        '
        resources.ApplyResources(Me.chkProgressiveDistance, "chkProgressiveDistance")
        Me.chkProgressiveDistance.Name = "chkProgressiveDistance"
        Me.chkProgressiveDistance.Properties.AutoWidth = True
        Me.chkProgressiveDistance.Properties.Caption = resources.GetString("CheckEdit1.Properties.Caption")
        '
        'frmImportExcel
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.cboSession)
        Me.Controls.Add(Me.lblSession)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.chkFirstline)
        Me.Controls.Add(Me.txtCaveName)
        Me.Controls.Add(Me.lblCaveName)
        Me.Controls.Add(Me.txtPrefix)
        Me.Controls.Add(Me.lblPrefix)
        Me.Controls.Add(Me.tabMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmImportExcel.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.import
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportExcel"
        CType(Me.lstSourceFields, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaveName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrefix.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkFirstline.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFilename.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAutoSplay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSplaySymbol.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCutSplaySymbol.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSplayMarker.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCutSplayMarker.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkZeroPlaceholders.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtZeroPlaceholders.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCommentSymbols.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCommentSymbols.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tvDestField, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFieldsType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMain.ResumeLayout(False)
        Me.tabFields.ResumeLayout(False)
        Me.tabFields.PerformLayout()
        Me.tabOptions.ResumeLayout(False)
        Me.tabOptions.PerformLayout()
        CType(Me.chkProgressiveDistance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstSourceFields As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents txtCaveName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblCaveName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPrefix As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPrefix As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnRemoveAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAddAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnRemove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkFirstline As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtFilename As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblFilename As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkAutoSplay As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkSplaySymbol As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkCutSplaySymbol As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtSplayMarker As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCutSplayMarker As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkZeroPlaceholders As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtZeroPlaceholders As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkCommentSymbols As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtCommentSymbols As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblSourceFields As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDestinationFields As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tvDestField As DevExpress.XtraTreeList.TreeList
    Friend WithEvents colFieldsName As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colFieldsType As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colFieldsValue As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cboFieldsType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents btnMoveUp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnMoveDown As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblSession As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboSession As cSessionDropDown
    Friend WithEvents tabMain As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabFields As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabOptions As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents chkProgressiveDistance As DevExpress.XtraEditors.CheckEdit
End Class
