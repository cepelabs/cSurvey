<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cCaveDropDown
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
        Me.cboCaveList = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.cboCaveListView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCaveListName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtCaveListName = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        CType(Me.cboCaveList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCaveListView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaveListName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboCaveList
        '
        Me.cboCaveList.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboCaveList.Location = New System.Drawing.Point(0, 0)
        Me.cboCaveList.Name = "cboCaveList"
        Me.cboCaveList.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboCaveList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "Edit...", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.cboCaveList.Properties.DisplayMember = "ToHTMLString"
        Me.cboCaveList.Properties.NullText = ""
        Me.cboCaveList.Properties.PopupView = Me.cboCaveListView
        Me.cboCaveList.Properties.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtCaveListName})
        Me.cboCaveList.Size = New System.Drawing.Size(346, 20)
        Me.cboCaveList.TabIndex = 114
        '
        'cboCaveListView
        '
        Me.cboCaveListView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCaveListName})
        Me.cboCaveListView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.cboCaveListView.Name = "cboCaveListView"
        Me.cboCaveListView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.cboCaveListView.OptionsView.ShowColumnHeaders = False
        Me.cboCaveListView.OptionsView.ShowGroupPanel = False
        Me.cboCaveListView.OptionsView.ShowIndicator = False
        '
        'colCaveListName
        '
        Me.colCaveListName.Caption = "Name"
        Me.colCaveListName.ColumnEdit = Me.txtCaveListName
        Me.colCaveListName.FieldName = "ToHTMLString"
        Me.colCaveListName.Name = "colCaveListName"
        Me.colCaveListName.OptionsColumn.AllowEdit = False
        Me.colCaveListName.OptionsColumn.ReadOnly = True
        Me.colCaveListName.Visible = True
        Me.colCaveListName.VisibleIndex = 0
        '
        'txtCaveListName
        '
        Me.txtCaveListName.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtCaveListName.AutoHeight = False
        Me.txtCaveListName.Name = "txtCaveListName"
        '
        'cCaveDropDown
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cboCaveList)
        Me.Name = "cCaveDropDown"
        Me.Size = New System.Drawing.Size(346, 60)
        CType(Me.cboCaveList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCaveListView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaveListName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cboCaveList As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents cboCaveListView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCaveListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtCaveListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class
