<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemScaleVisibility
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItemScaleVisibility))
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.imlScale = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.iml = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.grdVisibility = New DevExpress.XtraGrid.GridControl()
        Me.grdVisibilityView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colVisibiltyIcon = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cboVisibilityIcon = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colVisibiltyScale = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVisibiltyVisibility = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cboVisibiltyVisibility = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        CType(Me.imlScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVisibility, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVisibilityView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboVisibilityIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboVisibiltyVisibility, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'imlScale
        '
        Me.imlScale.Add("icon_scale", "icon_scale", GetType(cSurveyPC.My.Resources.Resources))
        '
        'iml
        '
        Me.iml.Add("levelup", "levelup", GetType(cSurveyPC.My.Resources.Resources))
        Me.iml.Add("security_visibility", "security_visibility", GetType(cSurveyPC.My.Resources.Resources))
        Me.iml.Add("security_visibilityoff", "security_visibilityoff", GetType(cSurveyPC.My.Resources.Resources))
        '
        'grdVisibility
        '
        resources.ApplyResources(Me.grdVisibility, "grdVisibility")
        Me.grdVisibility.MainView = Me.grdVisibilityView
        Me.grdVisibility.Name = "grdVisibility"
        Me.grdVisibility.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cboVisibiltyVisibility, Me.cboVisibilityIcon})
        Me.grdVisibility.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVisibilityView})
        '
        'grdVisibilityView
        '
        Me.grdVisibilityView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colVisibiltyIcon, Me.colVisibiltyScale, Me.colVisibiltyVisibility})
        Me.grdVisibilityView.GridControl = Me.grdVisibility
        Me.grdVisibilityView.Name = "grdVisibilityView"
        Me.grdVisibilityView.OptionsView.ShowGroupPanel = False
        Me.grdVisibilityView.OptionsView.ShowIndicator = False
        '
        'colVisibiltyIcon
        '
        resources.ApplyResources(Me.colVisibiltyIcon, "colVisibiltyIcon")
        Me.colVisibiltyIcon.ColumnEdit = Me.cboVisibilityIcon
        Me.colVisibiltyIcon.FieldName = "Type"
        Me.colVisibiltyIcon.MaxWidth = 24
        Me.colVisibiltyIcon.MinWidth = 24
        Me.colVisibiltyIcon.Name = "colVisibiltyIcon"
        Me.colVisibiltyIcon.OptionsColumn.AllowEdit = False
        Me.colVisibiltyIcon.OptionsColumn.FixedWidth = True
        Me.colVisibiltyIcon.OptionsColumn.ReadOnly = True
        '
        'cboVisibilityIcon
        '
        resources.ApplyResources(Me.cboVisibilityIcon, "cboVisibilityIcon")
        Me.cboVisibilityIcon.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboVisibilityIcon.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboVisibilityIcon.Name = "cboVisibilityIcon"
        Me.cboVisibilityIcon.SmallImages = Me.imlScale
        '
        'colVisibiltyScale
        '
        resources.ApplyResources(Me.colVisibiltyScale, "colVisibiltyScale")
        Me.colVisibiltyScale.FieldName = "Scale"
        Me.colVisibiltyScale.Name = "colVisibiltyScale"
        Me.colVisibiltyScale.OptionsColumn.AllowEdit = False
        Me.colVisibiltyScale.OptionsColumn.ReadOnly = True
        '
        'colVisibiltyVisibility
        '
        resources.ApplyResources(Me.colVisibiltyVisibility, "colVisibiltyVisibility")
        Me.colVisibiltyVisibility.ColumnEdit = Me.cboVisibiltyVisibility
        Me.colVisibiltyVisibility.FieldName = "Visibility"
        Me.colVisibiltyVisibility.Name = "colVisibiltyVisibility"
        '
        'cboVisibiltyVisibility
        '
        resources.ApplyResources(Me.cboVisibiltyVisibility, "cboVisibiltyVisibility")
        Me.cboVisibiltyVisibility.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboVisibiltyVisibility.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboVisibiltyVisibility.Name = "cboVisibiltyVisibility"
        Me.cboVisibiltyVisibility.SmallImages = Me.iml
        '
        'frmItemScaleVisibility
        '
        Me.AcceptButton = Me.cmdOk
        Me.Appearance.Options.UseFont = True
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.grdVisibility)
        Me.IconOptions.Icon = CType(resources.GetObject("frmItemScaleVisibility.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.icon_scale
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItemScaleVisibility"
        CType(Me.imlScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVisibility, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVisibilityView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboVisibilityIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboVisibiltyVisibility, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents imlScale As DevExpress.Utils.SvgImageCollection
    Friend WithEvents iml As DevExpress.Utils.SvgImageCollection
    Friend WithEvents grdVisibility As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVisibilityView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colVisibiltyIcon As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cboVisibilityIcon As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents colVisibiltyScale As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVisibiltyVisibility As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cboVisibiltyVisibility As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
End Class
