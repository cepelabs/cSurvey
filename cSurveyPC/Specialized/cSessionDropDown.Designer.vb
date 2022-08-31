<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cSessionDropDown
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
        Me.cboSessionList = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.cboSessionListView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSessionListName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtSessionListName = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        CType(Me.cboSessionList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSessionListView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSessionListName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboSessionList
        '
        Me.cboSessionList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboSessionList.Location = New System.Drawing.Point(0, 0)
        Me.cboSessionList.Name = "cboSessionList"
        Me.cboSessionList.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboSessionList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "Edit...", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "Edit...", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.cboSessionList.Properties.DisplayMember = "ToHTMLString"
        Me.cboSessionList.Properties.NullText = ""
        Me.cboSessionList.Properties.PopupView = Me.cboSessionListView
        Me.cboSessionList.Properties.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtSessionListName})
        Me.cboSessionList.Size = New System.Drawing.Size(346, 20)
        Me.cboSessionList.TabIndex = 113
        '
        'cboSessionListView
        '
        Me.cboSessionListView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSessionListName})
        Me.cboSessionListView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.cboSessionListView.Name = "cboSessionListView"
        Me.cboSessionListView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.cboSessionListView.OptionsView.ShowColumnHeaders = False
        Me.cboSessionListView.OptionsView.ShowGroupPanel = False
        Me.cboSessionListView.OptionsView.ShowIndicator = False
        '
        'colSessionListName
        '
        Me.colSessionListName.Caption = "Name"
        Me.colSessionListName.ColumnEdit = Me.txtSessionListName
        Me.colSessionListName.FieldName = "ToHTMLString"
        Me.colSessionListName.Name = "colSessionListName"
        Me.colSessionListName.OptionsColumn.AllowEdit = False
        Me.colSessionListName.OptionsColumn.ReadOnly = True
        Me.colSessionListName.Visible = True
        Me.colSessionListName.VisibleIndex = 0
        '
        'txtSessionListName
        '
        Me.txtSessionListName.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtSessionListName.AutoHeight = False
        Me.txtSessionListName.Name = "txtSessionListName"
        '
        'cSessionDropDown
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cboSessionList)
        Me.Name = "cSessionDropDown"
        Me.Size = New System.Drawing.Size(346, 60)
        CType(Me.cboSessionList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSessionListView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSessionListName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cboSessionList As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents cboSessionListView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colSessionListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtSessionListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class
