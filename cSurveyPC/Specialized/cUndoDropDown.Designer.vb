Imports DevExpress.XtraEditors

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cUndoDropDown
    Inherits XtraUserControl

    'UserControl overrides dispose to clean up the component list.
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tvUndoItems = New DevExpress.XtraTreeList.TreeList()
        Me.colText = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colArea = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cboArea = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.iml = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.txtUndoInfo = New DevExpress.XtraEditors.TextEdit()
        CType(Me.tvUndoItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUndoInfo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tvUndoItems
        '
        Me.tvUndoItems.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colText, Me.colArea})
        Me.tvUndoItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvUndoItems.Location = New System.Drawing.Point(0, 0)
        Me.tvUndoItems.Name = "tvUndoItems"
        Me.tvUndoItems.OptionsBehavior.Editable = False
        Me.tvUndoItems.OptionsBehavior.ReadOnly = True
        Me.tvUndoItems.OptionsSelection.KeepSelectedOnClick = True
        Me.tvUndoItems.OptionsSelection.MultiSelect = True
        Me.tvUndoItems.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus
        Me.tvUndoItems.OptionsView.ShowColumns = False
        Me.tvUndoItems.OptionsView.ShowIndentAsRowStyle = True
        Me.tvUndoItems.OptionsView.ShowIndicator = False
        Me.tvUndoItems.OptionsView.ShowRoot = False
        Me.tvUndoItems.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.tvUndoItems.OptionsView.ShowVertLines = False
        Me.tvUndoItems.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cboArea})
        Me.tvUndoItems.Size = New System.Drawing.Size(196, 259)
        Me.tvUndoItems.TabIndex = 0
        '
        'colText
        '
        Me.colText.Caption = "Text"
        Me.colText.FieldName = "Text"
        Me.colText.Name = "colText"
        Me.colText.OptionsColumn.AllowEdit = False
        Me.colText.OptionsColumn.ReadOnly = True
        Me.colText.Visible = True
        Me.colText.VisibleIndex = 0
        Me.colText.Width = 56
        '
        'colArea
        '
        Me.colArea.Caption = "Area"
        Me.colArea.ColumnEdit = Me.cboArea
        Me.colArea.FieldName = "Area"
        Me.colArea.MaxWidth = 24
        Me.colArea.MinWidth = 24
        Me.colArea.Name = "colArea"
        Me.colArea.OptionsColumn.AllowEdit = False
        Me.colArea.OptionsColumn.FixedWidth = True
        Me.colArea.OptionsColumn.ReadOnly = True
        Me.colArea.Visible = True
        Me.colArea.VisibleIndex = 1
        Me.colArea.Width = 24
        '
        'cboArea
        '
        Me.cboArea.AutoHeight = False
        Me.cboArea.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboArea.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Data", 1, 0), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Design", 0, 1)})
        Me.cboArea.Name = "cboArea"
        Me.cboArea.SmallImages = Me.iml
        '
        'iml
        '
        Me.iml.Add("inserttable", "inserttable", GetType(cSurveyPC.My.Resources.Resources))
        Me.iml.Add("designer", "designer", GetType(cSurveyPC.My.Resources.Resources))
        '
        'txtUndoInfo
        '
        Me.txtUndoInfo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtUndoInfo.Location = New System.Drawing.Point(0, 259)
        Me.txtUndoInfo.Name = "txtUndoInfo"
        Me.txtUndoInfo.Properties.Appearance.Options.UseTextOptions = True
        Me.txtUndoInfo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtUndoInfo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.txtUndoInfo.Properties.ReadOnly = True
        Me.txtUndoInfo.Size = New System.Drawing.Size(196, 18)
        Me.txtUndoInfo.TabIndex = 1
        '
        'cUndoDropDown
        '
        Me.Controls.Add(Me.tvUndoItems)
        Me.Controls.Add(Me.txtUndoInfo)
        Me.Name = "cUndoDropDown"
        Me.Size = New System.Drawing.Size(196, 277)
        CType(Me.tvUndoItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUndoInfo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tvUndoItems As DevExpress.XtraTreeList.TreeList
    Friend WithEvents colText As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents txtUndoInfo As TextEdit
    Friend WithEvents colArea As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cboArea As Repository.RepositoryItemImageComboBox
    Friend WithEvents iml As DevExpress.Utils.SvgImageCollection
End Class
