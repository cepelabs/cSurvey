<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cFontStyleDropDown
    Inherits System.Windows.Forms.UserControl

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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cboFontStyle = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.cboFontStyleView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colFontStyle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        CType(Me.cboFontStyle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFontStyleView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboFontStyle
        '
        Me.cboFontStyle.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboFontStyle.Location = New System.Drawing.Point(0, 0)
        Me.cboFontStyle.Name = "cboFontStyle"
        Me.cboFontStyle.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboFontStyle.Properties.AutoHeight = False
        Me.cboFontStyle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboFontStyle.Properties.NullText = ""
        Me.cboFontStyle.Properties.PopupSizeable = False
        Me.cboFontStyle.Properties.PopupView = Me.cboFontStyleView
        Me.cboFontStyle.Properties.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.cboFontStyle.Size = New System.Drawing.Size(150, 38)
        Me.cboFontStyle.TabIndex = 200
        '
        'cboFontStyleView
        '
        Me.cboFontStyleView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colFontStyle})
        Me.cboFontStyleView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.cboFontStyleView.Name = "cboFontStyleView"
        Me.cboFontStyleView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.cboFontStyleView.OptionsView.ShowColumnHeaders = False
        Me.cboFontStyleView.OptionsView.ShowGroupPanel = False
        Me.cboFontStyleView.OptionsView.ShowIndicator = False
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        Me.RepositoryItemTextEdit2.ReadOnly = True
        '
        'colFontStyle
        '
        Me.colFontStyle.Caption = " "
        Me.colFontStyle.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colFontStyle.FieldName = "_tohtmlstring"
        Me.colFontStyle.Name = "colFontStyle"
        Me.colFontStyle.OptionsColumn.AllowEdit = False
        Me.colFontStyle.OptionsColumn.ReadOnly = True
        Me.colFontStyle.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.colFontStyle.Visible = True
        Me.colFontStyle.VisibleIndex = 0
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.ReadOnly = True
        '
        'cFontStyleDropDown
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cboFontStyle)
        Me.Name = "cFontStyleDropDown"
        CType(Me.cboFontStyle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFontStyleView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cboFontStyle As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents cboFontStyleView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colFontStyle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class
