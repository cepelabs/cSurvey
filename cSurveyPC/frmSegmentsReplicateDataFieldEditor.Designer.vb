<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSegmentsReplicateDataFieldEditor
    Inherits cForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSegmentsReplicateDataFieldEditor))
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.grdVisibility = New DevExpress.XtraGrid.GridControl()
        Me.grdPropertiesView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colPropertySet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkBooleanPropertySet = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colPropertyName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPropertyValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtTextPropertySet = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.txtNumericPropertySet = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.iml = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.imlProfiles = New DevExpress.Utils.SvgImageCollection(Me.components)
        CType(Me.grdVisibility, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPropertiesView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkBooleanPropertySet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTextPropertySet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumericPropertySet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imlProfiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'grdVisibility
        '
        resources.ApplyResources(Me.grdVisibility, "grdVisibility")
        Me.grdVisibility.MainView = Me.grdPropertiesView
        Me.grdVisibility.Name = "grdVisibility"
        Me.grdVisibility.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chkBooleanPropertySet, Me.txtTextPropertySet, Me.txtNumericPropertySet})
        Me.grdVisibility.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdPropertiesView})
        '
        'grdPropertiesView
        '
        Me.grdPropertiesView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colPropertySet, Me.colPropertyName, Me.colPropertyValue})
        Me.grdPropertiesView.GridControl = Me.grdVisibility
        Me.grdPropertiesView.Name = "grdPropertiesView"
        Me.grdPropertiesView.OptionsView.ShowGroupPanel = False
        Me.grdPropertiesView.OptionsView.ShowIndicator = False
        '
        'colPropertySet
        '
        resources.ApplyResources(Me.colPropertySet, "colPropertySet")
        Me.colPropertySet.ColumnEdit = Me.chkBooleanPropertySet
        Me.colPropertySet.FieldName = "Set"
        Me.colPropertySet.MaxWidth = 32
        Me.colPropertySet.MinWidth = 24
        Me.colPropertySet.Name = "colPropertySet"
        '
        'chkBooleanPropertySet
        '
        resources.ApplyResources(Me.chkBooleanPropertySet, "chkBooleanPropertySet")
        Me.chkBooleanPropertySet.Name = "chkBooleanPropertySet"
        '
        'colPropertyName
        '
        resources.ApplyResources(Me.colPropertyName, "colPropertyName")
        Me.colPropertyName.FieldName = "Name"
        Me.colPropertyName.Name = "colPropertyName"
        Me.colPropertyName.OptionsColumn.AllowEdit = False
        Me.colPropertyName.OptionsColumn.ReadOnly = True
        '
        'colPropertyValue
        '
        resources.ApplyResources(Me.colPropertyValue, "colPropertyValue")
        Me.colPropertyValue.FieldName = "Value"
        Me.colPropertyValue.Name = "colPropertyValue"
        '
        'txtTextPropertySet
        '
        resources.ApplyResources(Me.txtTextPropertySet, "txtTextPropertySet")
        Me.txtTextPropertySet.Name = "txtTextPropertySet"
        '
        'txtNumericPropertySet
        '
        resources.ApplyResources(Me.txtNumericPropertySet, "txtNumericPropertySet")
        Me.txtNumericPropertySet.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtNumericPropertySet.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtNumericPropertySet.Name = "txtNumericPropertySet"
        '
        'iml
        '
        Me.iml.Add("levelup", "levelup", GetType(cSurveyPC.My.Resources.Resources))
        Me.iml.Add("security_visibility", "security_visibility", GetType(cSurveyPC.My.Resources.Resources))
        Me.iml.Add("security_visibilityoff", "security_visibilityoff", GetType(cSurveyPC.My.Resources.Resources))
        '
        'imlProfiles
        '
        Me.imlProfiles.Add("documentprint", "documentprint", GetType(cSurveyPC.My.Resources.Resources))
        Me.imlProfiles.Add("documentexport", "documentexport", GetType(cSurveyPC.My.Resources.Resources))
        '
        'frmSegmentsReplicateDataFieldEditor
        '
        Me.AcceptButton = Me.cmdOk
        Me.Appearance.Options.UseFont = True
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.grdVisibility)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.edit
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSegmentsReplicateDataFieldEditor"
        CType(Me.grdVisibility, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPropertiesView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkBooleanPropertySet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTextPropertySet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumericPropertySet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imlProfiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdVisibility As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdPropertiesView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPropertyName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPropertySet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents iml As DevExpress.Utils.SvgImageCollection
    Friend WithEvents imlProfiles As DevExpress.Utils.SvgImageCollection
    Friend WithEvents chkBooleanPropertySet As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colPropertyValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtTextPropertySet As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents txtNumericPropertySet As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
End Class
