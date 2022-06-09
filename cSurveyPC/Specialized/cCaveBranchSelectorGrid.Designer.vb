<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cCaveBranchSelectorGrid
    Inherits DevExpress.XtraEditors.XtraUserControl

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
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCaveBranchCaveColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCaveBranchCave = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtGridCaveName = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colCaveBranchBranchColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCaveBranchBranch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCaveBranchValue = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGridCaveName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtGridCaveName})
        Me.GridControl1.Size = New System.Drawing.Size(452, 394)
        Me.GridControl1.TabIndex = 165
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCaveBranchCaveColor, Me.colCaveBranchCave, Me.colCaveBranchBranchColor, Me.colCaveBranchBranch, Me.colCaveBranchValue})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OptionsView.ShowIndicator = False
        '
        'colCaveBranchCaveColor
        '
        Me.colCaveBranchCaveColor.Caption = " "
        Me.colCaveBranchCaveColor.FieldName = "CaveColor"
        Me.colCaveBranchCaveColor.MaxWidth = 10
        Me.colCaveBranchCaveColor.MinWidth = 10
        Me.colCaveBranchCaveColor.Name = "colCaveBranchCaveColor"
        Me.colCaveBranchCaveColor.OptionsColumn.AllowEdit = False
        Me.colCaveBranchCaveColor.OptionsColumn.AllowMove = False
        Me.colCaveBranchCaveColor.OptionsColumn.FixedWidth = True
        Me.colCaveBranchCaveColor.OptionsColumn.ReadOnly = True
        Me.colCaveBranchCaveColor.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.colCaveBranchCaveColor.Visible = True
        Me.colCaveBranchCaveColor.VisibleIndex = 0
        Me.colCaveBranchCaveColor.Width = 10
        '
        'colCaveBranchCave
        '
        Me.colCaveBranchCave.Caption = "Cave"
        Me.colCaveBranchCave.ColumnEdit = Me.txtGridCaveName
        Me.colCaveBranchCave.FieldName = "Cave"
        Me.colCaveBranchCave.Name = "colCaveBranchCave"
        Me.colCaveBranchCave.OptionsColumn.AllowEdit = False
        Me.colCaveBranchCave.OptionsColumn.AllowMove = False
        Me.colCaveBranchCave.OptionsColumn.ReadOnly = True
        Me.colCaveBranchCave.Visible = True
        Me.colCaveBranchCave.VisibleIndex = 1
        Me.colCaveBranchCave.Width = 120
        '
        'txtGridCaveName
        '
        Me.txtGridCaveName.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtGridCaveName.AutoHeight = False
        Me.txtGridCaveName.Name = "txtGridCaveName"
        '
        'colCaveBranchBranchColor
        '
        Me.colCaveBranchBranchColor.Caption = " "
        Me.colCaveBranchBranchColor.FieldName = "BranchColor"
        Me.colCaveBranchBranchColor.MaxWidth = 10
        Me.colCaveBranchBranchColor.MinWidth = 10
        Me.colCaveBranchBranchColor.Name = "colCaveBranchBranchColor"
        Me.colCaveBranchBranchColor.OptionsColumn.AllowEdit = False
        Me.colCaveBranchBranchColor.OptionsColumn.AllowMove = False
        Me.colCaveBranchBranchColor.OptionsColumn.FixedWidth = True
        Me.colCaveBranchBranchColor.OptionsColumn.ReadOnly = True
        Me.colCaveBranchBranchColor.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.colCaveBranchBranchColor.Visible = True
        Me.colCaveBranchBranchColor.VisibleIndex = 2
        Me.colCaveBranchBranchColor.Width = 10
        '
        'colCaveBranchBranch
        '
        Me.colCaveBranchBranch.Caption = "Branch"
        Me.colCaveBranchBranch.ColumnEdit = Me.txtGridCaveName
        Me.colCaveBranchBranch.FieldName = "Branch"
        Me.colCaveBranchBranch.Name = "colCaveBranchBranch"
        Me.colCaveBranchBranch.OptionsColumn.AllowEdit = False
        Me.colCaveBranchBranch.OptionsColumn.AllowMove = False
        Me.colCaveBranchBranch.OptionsColumn.ReadOnly = True
        Me.colCaveBranchBranch.Visible = True
        Me.colCaveBranchBranch.VisibleIndex = 3
        Me.colCaveBranchBranch.Width = 209
        '
        'colCaveBranchValue
        '
        Me.colCaveBranchValue.Caption = "[value]"
        Me.colCaveBranchValue.FieldName = "_value"
        Me.colCaveBranchValue.MaxWidth = 70
        Me.colCaveBranchValue.MinWidth = 70
        Me.colCaveBranchValue.Name = "colCaveBranchValue"
        Me.colCaveBranchValue.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colCaveBranchValue.UnboundType = DevExpress.Data.UnboundColumnType.[Object]
        Me.colCaveBranchValue.Visible = True
        Me.colCaveBranchValue.VisibleIndex = 4
        Me.colCaveBranchValue.Width = 70
        '
        'cCaveBranchSelectorGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.GridControl1)
        Me.Name = "cCaveBranchSelectorGrid"
        Me.Size = New System.Drawing.Size(452, 394)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGridCaveName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCaveBranchCaveColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCaveBranchCave As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtGridCaveName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents colCaveBranchBranchColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCaveBranchBranch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCaveBranchValue As DevExpress.XtraGrid.Columns.GridColumn
End Class
