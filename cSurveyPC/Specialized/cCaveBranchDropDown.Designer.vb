<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cCaveBranchDropDown
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.cboCaveBranchList = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.cboCaveBranchListView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCaveBranchListName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtCaveBranchListName = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        CType(Me.cboCaveBranchList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCaveBranchListView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaveBranchListName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboCaveBranchList
        '
        Me.cboCaveBranchList.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboCaveBranchList.Location = New System.Drawing.Point(0, 0)
        Me.cboCaveBranchList.Name = "cboCaveBranchList"
        Me.cboCaveBranchList.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboCaveBranchList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "Edit...", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.cboCaveBranchList.Properties.DisplayMember = "ToHTMLString"
        Me.cboCaveBranchList.Properties.NullText = ""
        Me.cboCaveBranchList.Properties.PopupView = Me.cboCaveBranchListView
        Me.cboCaveBranchList.Properties.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtCaveBranchListName})
        Me.cboCaveBranchList.Size = New System.Drawing.Size(346, 20)
        Me.cboCaveBranchList.TabIndex = 115
        '
        'cboCaveBranchListView
        '
        Me.cboCaveBranchListView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCaveBranchListName})
        Me.cboCaveBranchListView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.cboCaveBranchListView.Name = "cboCaveBranchListView"
        Me.cboCaveBranchListView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.cboCaveBranchListView.OptionsView.ShowColumnHeaders = False
        Me.cboCaveBranchListView.OptionsView.ShowGroupPanel = False
        Me.cboCaveBranchListView.OptionsView.ShowIndicator = False
        '
        'colCaveBranchListName
        '
        Me.colCaveBranchListName.Caption = "Name"
        Me.colCaveBranchListName.ColumnEdit = Me.txtCaveBranchListName
        Me.colCaveBranchListName.FieldName = "ToHTMLString"
        Me.colCaveBranchListName.Name = "colCaveBranchListName"
        Me.colCaveBranchListName.OptionsColumn.AllowEdit = False
        Me.colCaveBranchListName.OptionsColumn.ReadOnly = True
        Me.colCaveBranchListName.Visible = True
        Me.colCaveBranchListName.VisibleIndex = 0
        '
        'txtCaveBranchListName
        '
        Me.txtCaveBranchListName.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtCaveBranchListName.AutoHeight = False
        Me.txtCaveBranchListName.Name = "txtCaveBranchListName"
        '
        'cCaveBranchDropDown
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cboCaveBranchList)
        Me.Name = "cCaveBranchDropDown"
        Me.Size = New System.Drawing.Size(346, 60)
        CType(Me.cboCaveBranchList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCaveBranchListView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaveBranchListName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboCaveBranchList As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents cboCaveBranchListView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCaveBranchListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtCaveBranchListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class
