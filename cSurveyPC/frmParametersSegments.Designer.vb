<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmParametersSegments
    Inherits DevExpress.XtraEditors.XtraUserControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParametersSegments))
        Me.grpShots = New DevExpress.XtraEditors.GroupControl()
        Me.chkDuplicate = New DevExpress.XtraEditors.CheckEdit()
        Me.chkSurface = New DevExpress.XtraEditors.CheckEdit()
        Me.grpLRUD = New DevExpress.XtraEditors.GroupControl()
        Me.cboSegmentsPaintStyle = New System.Windows.Forms.ComboBox()
        Me.Label1 = New DevExpress.XtraEditors.LabelControl()
        Me.cboSplayStyle = New System.Windows.Forms.ComboBox()
        Me.lblSplayStyle = New DevExpress.XtraEditors.LabelControl()
        Me.grpSplay = New DevExpress.XtraEditors.GroupControl()
        Me.chkDesignPlotShowSplayMode = New DevExpress.XtraEditors.CheckEdit()
        Me.chkShowSplayLabel = New DevExpress.XtraEditors.CheckEdit()
        Me.GroupBox4 = New DevExpress.XtraEditors.GroupControl()
        Me.grdHighlights = New DevExpress.XtraGrid.GridControl()
        Me.grdViewHighlights = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colHLSelected = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkHLSelected = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colHLName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkShowHLs = New DevExpress.XtraEditors.CheckEdit()
        Me.chkSurfaceProfile = New DevExpress.XtraEditors.CheckEdit()
        Me.grpSurface = New DevExpress.XtraEditors.GroupControl()
        CType(Me.grpShots, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpShots.SuspendLayout()
        CType(Me.chkDuplicate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSurface.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpLRUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpLRUD.SuspendLayout()
        CType(Me.grpSplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSplay.SuspendLayout()
        CType(Me.chkDesignPlotShowSplayMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowSplayLabel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.grdHighlights, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdViewHighlights, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHLSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowHLs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSurfaceProfile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpSurface, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSurface.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpShots
        '
        resources.ApplyResources(Me.grpShots, "grpShots")
        Me.grpShots.Controls.Add(Me.chkDuplicate)
        Me.grpShots.Controls.Add(Me.chkSurface)
        Me.grpShots.Name = "grpShots"
        '
        'chkDuplicate
        '
        resources.ApplyResources(Me.chkDuplicate, "chkDuplicate")
        Me.chkDuplicate.Name = "chkDuplicate"
        Me.chkDuplicate.Properties.AutoWidth = True
        Me.chkDuplicate.Properties.Caption = resources.GetString("chkDuplicate.Properties.Caption")
        '
        'chkSurface
        '
        resources.ApplyResources(Me.chkSurface, "chkSurface")
        Me.chkSurface.Name = "chkSurface"
        Me.chkSurface.Properties.AutoWidth = True
        Me.chkSurface.Properties.Caption = resources.GetString("chkSurface.Properties.Caption")
        '
        'grpLRUD
        '
        resources.ApplyResources(Me.grpLRUD, "grpLRUD")
        Me.grpLRUD.Controls.Add(Me.cboSegmentsPaintStyle)
        Me.grpLRUD.Controls.Add(Me.Label1)
        Me.grpLRUD.Name = "grpLRUD"
        '
        'cboSegmentsPaintStyle
        '
        Me.cboSegmentsPaintStyle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboSegmentsPaintStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSegmentsPaintStyle.Items.AddRange(New Object() {resources.GetString("cboSegmentsPaintStyle.Items"), resources.GetString("cboSegmentsPaintStyle.Items1"), resources.GetString("cboSegmentsPaintStyle.Items2"), resources.GetString("cboSegmentsPaintStyle.Items3")})
        resources.ApplyResources(Me.cboSegmentsPaintStyle, "cboSegmentsPaintStyle")
        Me.cboSegmentsPaintStyle.Name = "cboSegmentsPaintStyle"
        '
        'Label1
        '
        Me.Label1.Appearance.Font = CType(resources.GetObject("Label1.Appearance.Font"), System.Drawing.Font)
        Me.Label1.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'cboSplayStyle
        '
        Me.cboSplayStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboSplayStyle, "cboSplayStyle")
        Me.cboSplayStyle.Items.AddRange(New Object() {resources.GetString("cboSplayStyle.Items"), resources.GetString("cboSplayStyle.Items1"), resources.GetString("cboSplayStyle.Items2")})
        Me.cboSplayStyle.Name = "cboSplayStyle"
        '
        'lblSplayStyle
        '
        resources.ApplyResources(Me.lblSplayStyle, "lblSplayStyle")
        Me.lblSplayStyle.Name = "lblSplayStyle"
        '
        'grpSplay
        '
        resources.ApplyResources(Me.grpSplay, "grpSplay")
        Me.grpSplay.Controls.Add(Me.chkDesignPlotShowSplayMode)
        Me.grpSplay.Controls.Add(Me.chkShowSplayLabel)
        Me.grpSplay.Controls.Add(Me.cboSplayStyle)
        Me.grpSplay.Controls.Add(Me.lblSplayStyle)
        Me.grpSplay.Name = "grpSplay"
        '
        'chkDesignPlotShowSplayMode
        '
        resources.ApplyResources(Me.chkDesignPlotShowSplayMode, "chkDesignPlotShowSplayMode")
        Me.chkDesignPlotShowSplayMode.Name = "chkDesignPlotShowSplayMode"
        Me.chkDesignPlotShowSplayMode.Properties.AutoWidth = True
        Me.chkDesignPlotShowSplayMode.Properties.Caption = resources.GetString("chkDesignPlotShowSplayMode.Properties.Caption")
        '
        'chkShowSplayLabel
        '
        resources.ApplyResources(Me.chkShowSplayLabel, "chkShowSplayLabel")
        Me.chkShowSplayLabel.Name = "chkShowSplayLabel"
        Me.chkShowSplayLabel.Properties.AutoWidth = True
        Me.chkShowSplayLabel.Properties.Caption = resources.GetString("chkShowSplayLabel.Properties.Caption")
        '
        'GroupBox4
        '
        resources.ApplyResources(Me.GroupBox4, "GroupBox4")
        Me.GroupBox4.Controls.Add(Me.grdHighlights)
        Me.GroupBox4.Controls.Add(Me.chkShowHLs)
        Me.GroupBox4.Name = "GroupBox4"
        '
        'grdHighlights
        '
        resources.ApplyResources(Me.grdHighlights, "grdHighlights")
        Me.grdHighlights.MainView = Me.grdViewHighlights
        Me.grdHighlights.Name = "grdHighlights"
        Me.grdHighlights.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chkHLSelected})
        Me.grdHighlights.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdViewHighlights})
        '
        'grdViewHighlights
        '
        Me.grdViewHighlights.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colHLSelected, Me.colHLName})
        Me.grdViewHighlights.GridControl = Me.grdHighlights
        Me.grdViewHighlights.Name = "grdViewHighlights"
        Me.grdViewHighlights.OptionsView.ShowColumnHeaders = False
        Me.grdViewHighlights.OptionsView.ShowGroupPanel = False
        Me.grdViewHighlights.OptionsView.ShowIndicator = False
        '
        'colHLSelected
        '
        resources.ApplyResources(Me.colHLSelected, "colHLSelected")
        Me.colHLSelected.ColumnEdit = Me.chkHLSelected
        Me.colHLSelected.FieldName = "Selected"
        Me.colHLSelected.MaxWidth = 24
        Me.colHLSelected.MinWidth = 24
        Me.colHLSelected.Name = "colHLSelected"
        Me.colHLSelected.OptionsColumn.FixedWidth = True
        Me.colHLSelected.UnboundType = DevExpress.Data.UnboundColumnType.[Boolean]
        '
        'chkHLSelected
        '
        resources.ApplyResources(Me.chkHLSelected, "chkHLSelected")
        Me.chkHLSelected.Name = "chkHLSelected"
        '
        'colHLName
        '
        resources.ApplyResources(Me.colHLName, "colHLName")
        Me.colHLName.FieldName = "Name"
        Me.colHLName.Name = "colHLName"
        Me.colHLName.OptionsColumn.AllowEdit = False
        Me.colHLName.OptionsColumn.ReadOnly = True
        '
        'chkShowHLs
        '
        resources.ApplyResources(Me.chkShowHLs, "chkShowHLs")
        Me.chkShowHLs.Name = "chkShowHLs"
        Me.chkShowHLs.Properties.AutoWidth = True
        Me.chkShowHLs.Properties.Caption = resources.GetString("chkShowHLs.Properties.Caption")
        '
        'chkSurfaceProfile
        '
        resources.ApplyResources(Me.chkSurfaceProfile, "chkSurfaceProfile")
        Me.chkSurfaceProfile.Name = "chkSurfaceProfile"
        Me.chkSurfaceProfile.Properties.AutoWidth = True
        Me.chkSurfaceProfile.Properties.Caption = resources.GetString("chkSurfaceProfile.Properties.Caption")
        '
        'grpSurface
        '
        resources.ApplyResources(Me.grpSurface, "grpSurface")
        Me.grpSurface.Controls.Add(Me.chkSurfaceProfile)
        Me.grpSurface.Name = "grpSurface"
        '
        'frmParametersSegments
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.grpSurface)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.grpSplay)
        Me.Controls.Add(Me.grpLRUD)
        Me.Controls.Add(Me.grpShots)
        Me.Name = "frmParametersSegments"
        CType(Me.grpShots, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpShots.ResumeLayout(False)
        Me.grpShots.PerformLayout()
        CType(Me.chkDuplicate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSurface.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpLRUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpLRUD.ResumeLayout(False)
        Me.grpLRUD.PerformLayout()
        CType(Me.grpSplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSplay.ResumeLayout(False)
        Me.grpSplay.PerformLayout()
        CType(Me.chkDesignPlotShowSplayMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowSplayLabel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.grdHighlights, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdViewHighlights, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHLSelected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowHLs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSurfaceProfile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpSurface, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSurface.ResumeLayout(False)
        Me.grpSurface.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpShots As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkDuplicate As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkSurface As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents grpLRUD As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cboSegmentsPaintStyle As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboSplayStyle As System.Windows.Forms.ComboBox
    Friend WithEvents lblSplayStyle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents grpSplay As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupBox4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkShowHLs As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkSurfaceProfile As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents grdHighlights As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdViewHighlights As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colHLSelected As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkHLSelected As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colHLName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grpSurface As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkShowSplayLabel As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignPlotShowSplayMode As DevExpress.XtraEditors.CheckEdit
End Class
