<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cSegmentsGrid
    Inherits DevExpress.XtraEditors.XtraUserControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cSegmentsGrid))
        Me.grdSegments = New DevExpress.XtraGrid.GridControl()
        Me.grdViewSegments = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSegmentsSessionColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSegmentsSession = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSegmentsBranchCaveColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSegmentsBranchCave = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSegmentsBranchBranchColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSegmentsBranchBranch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSegmentsFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSegmentsTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtGridCaveName = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colSegmentsListCaveBranch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSegmentsCave = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.grdSegments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdViewSegments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGridCaveName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdSegments
        '
        resources.ApplyResources(Me.grdSegments, "grdSegments")
        Me.grdSegments.MainView = Me.grdViewSegments
        Me.grdSegments.Name = "grdSegments"
        Me.grdSegments.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdViewSegments})
        '
        'grdViewSegments
        '
        Me.grdViewSegments.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSegmentsSessionColor, Me.colSegmentsSession, Me.colSegmentsBranchCaveColor, Me.colSegmentsBranchCave, Me.colSegmentsBranchBranchColor, Me.colSegmentsBranchBranch, Me.colSegmentsFrom, Me.colSegmentsTo})
        Me.grdViewSegments.GridControl = Me.grdSegments
        Me.grdViewSegments.Name = "grdViewSegments"
        Me.grdViewSegments.OptionsBehavior.AutoPopulateColumns = False
        Me.grdViewSegments.OptionsBehavior.Editable = False
        Me.grdViewSegments.OptionsBehavior.ReadOnly = True
        Me.grdViewSegments.OptionsView.ColumnAutoWidth = False
        Me.grdViewSegments.OptionsView.ShowGroupPanel = False
        Me.grdViewSegments.OptionsView.ShowIndicator = False
        '
        'colSegmentsSessionColor
        '
        resources.ApplyResources(Me.colSegmentsSessionColor, "colSegmentsSessionColor")
        Me.colSegmentsSessionColor.MaxWidth = 10
        Me.colSegmentsSessionColor.MinWidth = 10
        Me.colSegmentsSessionColor.Name = "colSegmentsSessionColor"
        Me.colSegmentsSessionColor.OptionsColumn.AllowEdit = False
        Me.colSegmentsSessionColor.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colSegmentsSessionColor.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.colSegmentsSessionColor.OptionsColumn.FixedWidth = True
        Me.colSegmentsSessionColor.OptionsColumn.ReadOnly = True
        '
        'colSegmentsSession
        '
        resources.ApplyResources(Me.colSegmentsSession, "colSegmentsSession")
        Me.colSegmentsSession.FieldName = "Session"
        Me.colSegmentsSession.Name = "colSegmentsSession"
        Me.colSegmentsSession.OptionsColumn.AllowEdit = False
        Me.colSegmentsSession.OptionsColumn.ReadOnly = True
        '
        'colSegmentsBranchCaveColor
        '
        resources.ApplyResources(Me.colSegmentsBranchCaveColor, "colSegmentsBranchCaveColor")
        Me.colSegmentsBranchCaveColor.FieldName = "CaveColor"
        Me.colSegmentsBranchCaveColor.MaxWidth = 10
        Me.colSegmentsBranchCaveColor.MinWidth = 10
        Me.colSegmentsBranchCaveColor.Name = "colSegmentsBranchCaveColor"
        Me.colSegmentsBranchCaveColor.OptionsColumn.AllowEdit = False
        Me.colSegmentsBranchCaveColor.OptionsColumn.AllowMove = False
        Me.colSegmentsBranchCaveColor.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.colSegmentsBranchCaveColor.OptionsColumn.FixedWidth = True
        Me.colSegmentsBranchCaveColor.OptionsColumn.ReadOnly = True
        Me.colSegmentsBranchCaveColor.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'colSegmentsBranchCave
        '
        resources.ApplyResources(Me.colSegmentsBranchCave, "colSegmentsBranchCave")
        Me.colSegmentsBranchCave.FieldName = "Cave"
        Me.colSegmentsBranchCave.Name = "colSegmentsBranchCave"
        Me.colSegmentsBranchCave.OptionsColumn.AllowEdit = False
        Me.colSegmentsBranchCave.OptionsColumn.AllowMove = False
        Me.colSegmentsBranchCave.OptionsColumn.ReadOnly = True
        '
        'colSegmentsBranchBranchColor
        '
        resources.ApplyResources(Me.colSegmentsBranchBranchColor, "colSegmentsBranchBranchColor")
        Me.colSegmentsBranchBranchColor.FieldName = "BranchColor"
        Me.colSegmentsBranchBranchColor.MaxWidth = 10
        Me.colSegmentsBranchBranchColor.MinWidth = 10
        Me.colSegmentsBranchBranchColor.Name = "colSegmentsBranchBranchColor"
        Me.colSegmentsBranchBranchColor.OptionsColumn.AllowEdit = False
        Me.colSegmentsBranchBranchColor.OptionsColumn.AllowMove = False
        Me.colSegmentsBranchBranchColor.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.colSegmentsBranchBranchColor.OptionsColumn.FixedWidth = True
        Me.colSegmentsBranchBranchColor.OptionsColumn.ReadOnly = True
        Me.colSegmentsBranchBranchColor.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'colSegmentsBranchBranch
        '
        resources.ApplyResources(Me.colSegmentsBranchBranch, "colSegmentsBranchBranch")
        Me.colSegmentsBranchBranch.FieldName = "Branch"
        Me.colSegmentsBranchBranch.Name = "colSegmentsBranchBranch"
        Me.colSegmentsBranchBranch.OptionsColumn.AllowEdit = False
        Me.colSegmentsBranchBranch.OptionsColumn.AllowMove = False
        Me.colSegmentsBranchBranch.OptionsColumn.ReadOnly = True
        '
        'colSegmentsFrom
        '
        resources.ApplyResources(Me.colSegmentsFrom, "colSegmentsFrom")
        Me.colSegmentsFrom.FieldName = "From"
        Me.colSegmentsFrom.Name = "colSegmentsFrom"
        Me.colSegmentsFrom.OptionsColumn.AllowEdit = False
        Me.colSegmentsFrom.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.colSegmentsFrom.OptionsColumn.ReadOnly = True
        '
        'colSegmentsTo
        '
        resources.ApplyResources(Me.colSegmentsTo, "colSegmentsTo")
        Me.colSegmentsTo.FieldName = "To"
        Me.colSegmentsTo.Name = "colSegmentsTo"
        Me.colSegmentsTo.OptionsColumn.AllowEdit = False
        Me.colSegmentsTo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.colSegmentsTo.OptionsColumn.ReadOnly = True
        '
        'txtGridCaveName
        '
        Me.txtGridCaveName.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.txtGridCaveName, "txtGridCaveName")
        Me.txtGridCaveName.Name = "txtGridCaveName"
        '
        'colSegmentsListCaveBranch
        '
        resources.ApplyResources(Me.colSegmentsListCaveBranch, "colSegmentsListCaveBranch")
        Me.colSegmentsListCaveBranch.MaxWidth = 10
        Me.colSegmentsListCaveBranch.MinWidth = 10
        Me.colSegmentsListCaveBranch.Name = "colSegmentsListCaveBranch"
        Me.colSegmentsListCaveBranch.OptionsColumn.AllowEdit = False
        Me.colSegmentsListCaveBranch.OptionsColumn.AllowFocus = False
        Me.colSegmentsListCaveBranch.OptionsColumn.AllowSize = False
        Me.colSegmentsListCaveBranch.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.colSegmentsListCaveBranch.OptionsColumn.FixedWidth = True
        Me.colSegmentsListCaveBranch.OptionsColumn.ReadOnly = True
        '
        'colSegmentsCave
        '
        resources.ApplyResources(Me.colSegmentsCave, "colSegmentsCave")
        Me.colSegmentsCave.FieldName = "Cave"
        Me.colSegmentsCave.Name = "colSegmentsCave"
        Me.colSegmentsCave.OptionsColumn.AllowEdit = False
        Me.colSegmentsCave.OptionsColumn.ReadOnly = True
        '
        'cSegmentsGrid
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.grdSegments)
        Me.Name = "cSegmentsGrid"
        CType(Me.grdSegments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdViewSegments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGridCaveName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grdSegments As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdViewSegments As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colSegmentsListCaveBranch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSegmentsCave As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSegmentsFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSegmentsTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSegmentsSession As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSegmentsBranchCaveColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSegmentsBranchCave As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtGridCaveName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents colSegmentsBranchBranchColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSegmentsBranchBranch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSegmentsSessionColor As DevExpress.XtraGrid.Columns.GridColumn
End Class
