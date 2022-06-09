<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDataFieldsEditor
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDataFieldsEditor))
        Me.txtDataFieldName = New DevExpress.XtraEditors.TextEdit()
        Me.lblDataFieldName = New DevExpress.XtraEditors.LabelControl()
        Me.txtDataFieldDescription = New DevExpress.XtraEditors.TextEdit()
        Me.lblDataFieldDescription = New DevExpress.XtraEditors.LabelControl()
        Me.cboDataFieldType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.BarMain = New DevExpress.XtraBars.Bar()
        Me.btnDataFieldAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDataFieldDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnLayerSync = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExpandAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCollapseAll = New DevExpress.XtraBars.BarButtonItem()
        Me.lblDataFieldType = New DevExpress.XtraEditors.LabelControl()
        Me.pnlDataFieldEnum = New DevExpress.XtraEditors.PanelControl()
        Me.Label11 = New DevExpress.XtraEditors.LabelControl()
        Me.iml = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.txtDataFieldEnumValues = New DevExpress.XtraEditors.MemoEdit()
        Me.lblDataFieldEnumValues = New DevExpress.XtraEditors.LabelControl()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlDataField = New DevExpress.XtraEditors.PanelControl()
        Me.txtDataFieldCategory = New DevExpress.XtraEditors.TextEdit()
        Me.lblDataFieldCategory = New DevExpress.XtraEditors.LabelControl()
        Me.pnlMain = New DevExpress.XtraEditors.PanelControl()
        Me.tvDataFields = New DevExpress.XtraTreeList.TreeList()
        Me.colName = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        CType(Me.txtDataFieldName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataFieldDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDataFieldType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDataFieldEnum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDataFieldEnum.SuspendLayout()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataFieldEnumValues.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDataField, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDataField.SuspendLayout()
        CType(Me.txtDataFieldCategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        CType(Me.tvDataFields, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        resources.ApplyResources(Me.cboDataFieldType, "cboDataFieldType")
        Me.cboDataFieldType.MenuManager = Me.BarManager
        Me.cboDataFieldType.Name = "cboDataFieldType"
        Me.cboDataFieldType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboDataFieldType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboDataFieldType.Properties.Items.AddRange(New Object() {resources.GetString("cboDataFieldType.Properties.Items"), resources.GetString("cboDataFieldType.Properties.Items1"), resources.GetString("cboDataFieldType.Properties.Items2"), resources.GetString("cboDataFieldType.Properties.Items3"), resources.GetString("cboDataFieldType.Properties.Items4"), resources.GetString("cboDataFieldType.Properties.Items5"), resources.GetString("cboDataFieldType.Properties.Items6"), resources.GetString("cboDataFieldType.Properties.Items7"), resources.GetString("cboDataFieldType.Properties.Items8")})
        Me.cboDataFieldType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'BarManager
        '
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.BarMain})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnLayerSync, Me.btnExpandAll, Me.btnCollapseAll, Me.btnDataFieldAdd, Me.btnDataFieldDelete})
        Me.BarManager.MaxItemId = 13
        '
        'BarMain
        '
        Me.BarMain.BarName = "Tools"
        Me.BarMain.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Me.BarMain.DockCol = 0
        Me.BarMain.DockRow = 0
        Me.BarMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.BarMain.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnDataFieldAdd, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDataFieldDelete, True)})
        Me.BarMain.OptionsBar.AllowQuickCustomization = False
        Me.BarMain.OptionsBar.DisableCustomization = True
        Me.BarMain.OptionsBar.DrawDragBorder = False
        Me.BarMain.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.BarMain, "BarMain")
        '
        'btnDataFieldAdd
        '
        resources.ApplyResources(Me.btnDataFieldAdd, "btnDataFieldAdd")
        Me.btnDataFieldAdd.Id = 11
        Me.btnDataFieldAdd.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_add
        Me.btnDataFieldAdd.Name = "btnDataFieldAdd"
        '
        'btnDataFieldDelete
        '
        resources.ApplyResources(Me.btnDataFieldDelete, "btnDataFieldDelete")
        Me.btnDataFieldDelete.Enabled = False
        Me.btnDataFieldDelete.Id = 12
        Me.btnDataFieldDelete.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.delete1
        Me.btnDataFieldDelete.Name = "btnDataFieldDelete"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        resources.ApplyResources(Me.barDockControlTop, "barDockControlTop")
        Me.barDockControlTop.Manager = Me.BarManager
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        resources.ApplyResources(Me.barDockControlBottom, "barDockControlBottom")
        Me.barDockControlBottom.Manager = Me.BarManager
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        resources.ApplyResources(Me.barDockControlLeft, "barDockControlLeft")
        Me.barDockControlLeft.Manager = Me.BarManager
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        resources.ApplyResources(Me.barDockControlRight, "barDockControlRight")
        Me.barDockControlRight.Manager = Me.BarManager
        '
        'btnLayerSync
        '
        Me.btnLayerSync.Id = 6
        Me.btnLayerSync.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.productquickcomparisons
        Me.btnLayerSync.Name = "btnLayerSync"
        '
        'btnExpandAll
        '
        resources.ApplyResources(Me.btnExpandAll, "btnExpandAll")
        Me.btnExpandAll.Id = 9
        Me.btnExpandAll.Name = "btnExpandAll"
        '
        'btnCollapseAll
        '
        resources.ApplyResources(Me.btnCollapseAll, "btnCollapseAll")
        Me.btnCollapseAll.Id = 10
        Me.btnCollapseAll.Name = "btnCollapseAll"
        '
        'lblDataFieldType
        '
        resources.ApplyResources(Me.lblDataFieldType, "lblDataFieldType")
        Me.lblDataFieldType.Name = "lblDataFieldType"
        '
        'pnlDataFieldEnum
        '
        Me.pnlDataFieldEnum.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlDataFieldEnum.Controls.Add(Me.Label11)
        Me.pnlDataFieldEnum.Controls.Add(Me.txtDataFieldEnumValues)
        Me.pnlDataFieldEnum.Controls.Add(Me.lblDataFieldEnumValues)
        resources.ApplyResources(Me.pnlDataFieldEnum, "pnlDataFieldEnum")
        Me.pnlDataFieldEnum.Name = "pnlDataFieldEnum"
        '
        'Label11
        '
        Me.Label11.AllowHtmlString = True
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Appearance.Options.UseTextOptions = True
        Me.Label11.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.Label11.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.Label11.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.Label11.HtmlImages = Me.iml
        Me.Label11.Name = "Label11"
        '
        'iml
        '
        Me.iml.Add("field", "field", GetType(cSurveyPC.My.Resources.Resources))
        Me.iml.Add("fielddeleted", "fielddeleted", GetType(cSurveyPC.My.Resources.Resources))
        Me.iml.Add("warning", "warning", GetType(cSurveyPC.My.Resources.Resources))
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
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'pnlDataField
        '
        Me.pnlDataField.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlDataField.Controls.Add(Me.txtDataFieldCategory)
        Me.pnlDataField.Controls.Add(Me.lblDataFieldCategory)
        Me.pnlDataField.Controls.Add(Me.cboDataFieldType)
        Me.pnlDataField.Controls.Add(Me.txtDataFieldDescription)
        Me.pnlDataField.Controls.Add(Me.txtDataFieldName)
        Me.pnlDataField.Controls.Add(Me.lblDataFieldType)
        Me.pnlDataField.Controls.Add(Me.lblDataFieldName)
        Me.pnlDataField.Controls.Add(Me.lblDataFieldDescription)
        Me.pnlDataField.Controls.Add(Me.pnlDataFieldEnum)
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
        'pnlMain
        '
        Me.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlMain.Controls.Add(Me.pnlDataField)
        Me.pnlMain.Controls.Add(Me.tvDataFields)
        resources.ApplyResources(Me.pnlMain, "pnlMain")
        Me.pnlMain.Name = "pnlMain"
        '
        'tvDataFields
        '
        Me.tvDataFields.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colName})
        resources.ApplyResources(Me.tvDataFields, "tvDataFields")
        Me.tvDataFields.MenuManager = Me.BarManager
        Me.tvDataFields.Name = "tvDataFields"
        Me.tvDataFields.OptionsBehavior.Editable = False
        Me.tvDataFields.OptionsBehavior.ReadOnly = True
        Me.tvDataFields.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus
        Me.tvDataFields.OptionsView.ShowColumns = False
        Me.tvDataFields.OptionsView.ShowIndicator = False
        Me.tvDataFields.OptionsView.ShowRoot = False
        Me.tvDataFields.SelectImageList = Me.iml
        '
        'colName
        '
        resources.ApplyResources(Me.colName, "colName")
        Me.colName.FieldName = "Name"
        Me.colName.Name = "colName"
        '
        'frmDataFieldsEditor
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.editdatasource
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDataFieldsEditor"
        CType(Me.txtDataFieldName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataFieldDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDataFieldType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDataFieldEnum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDataFieldEnum.ResumeLayout(False)
        Me.pnlDataFieldEnum.PerformLayout()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataFieldEnumValues.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDataField, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDataField.ResumeLayout(False)
        Me.pnlDataField.PerformLayout()
        CType(Me.txtDataFieldCategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        CType(Me.tvDataFields, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDataFieldName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblDataFieldName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDataFieldDescription As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblDataFieldDescription As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboDataFieldType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblDataFieldType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnlDataFieldEnum As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtDataFieldEnumValues As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lblDataFieldEnumValues As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlDataField As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtDataFieldCategory As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblDataFieldCategory As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents BarMain As DevExpress.XtraBars.Bar
    Friend WithEvents btnLayerSync As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnExpandAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCollapseAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnDataFieldAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnDataFieldDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pnlMain As DevExpress.XtraEditors.PanelControl
    Friend WithEvents tvDataFields As DevExpress.XtraTreeList.TreeList
    Friend WithEvents colName As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents iml As DevExpress.Utils.SvgImageCollection
End Class
