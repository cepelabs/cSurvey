<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParametersSegments
    Inherits DevExpress.XtraEditors.XtraUserControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParametersSegments))
        Me.GroupBox1 = New DevExpress.XtraEditors.GroupControl()
        Me.chkDuplicate = New DevExpress.XtraEditors.CheckEdit()
        Me.chkSurface = New DevExpress.XtraEditors.CheckEdit()
        Me.GroupBox2 = New DevExpress.XtraEditors.GroupControl()
        Me.cboSegmentsPaintStyle = New System.Windows.Forms.ComboBox()
        Me.Label1 = New DevExpress.XtraEditors.LabelControl()
        Me.cboSplayStyle = New System.Windows.Forms.ComboBox()
        Me.lblSplayStyle = New DevExpress.XtraEditors.LabelControl()
        Me.GroupBox3 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupBox4 = New DevExpress.XtraEditors.GroupControl()
        Me.grdHighlights = New DevExpress.XtraGrid.GridControl()
        Me.grdViewHighlights = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colHLSelected = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkHLSelected = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colHLName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkShowHLs = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDesignSurfaceProfile = New DevExpress.XtraEditors.CheckEdit()
        Me.grpSurface = New DevExpress.XtraEditors.GroupControl()
        CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.chkDuplicate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSurface.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.GroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.grdHighlights, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdViewHighlights, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHLSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowHLs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignSurfaceProfile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpSurface, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSurface.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.chkDuplicate)
        Me.GroupBox1.Controls.Add(Me.chkSurface)
        Me.GroupBox1.Name = "GroupBox1"
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
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Controls.Add(Me.cboSegmentsPaintStyle)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Name = "GroupBox2"
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
        'GroupBox3
        '
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Controls.Add(Me.cboSplayStyle)
        Me.GroupBox3.Controls.Add(Me.lblSplayStyle)
        Me.GroupBox3.Name = "GroupBox3"
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
        'chkDesignSurfaceProfile
        '
        resources.ApplyResources(Me.chkDesignSurfaceProfile, "chkDesignSurfaceProfile")
        Me.chkDesignSurfaceProfile.Name = "chkDesignSurfaceProfile"
        Me.chkDesignSurfaceProfile.Properties.AutoWidth = True
        Me.chkDesignSurfaceProfile.Properties.Caption = resources.GetString("chkDesignSurfaceProfile.Properties.Caption")
        '
        'grpSurface
        '
        resources.ApplyResources(Me.grpSurface, "grpSurface")
        Me.grpSurface.Controls.Add(Me.chkDesignSurfaceProfile)
        Me.grpSurface.Name = "grpSurface"
        '
        'frmParametersSegments
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.grpSurface)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmParametersSegments"
        CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.chkDuplicate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSurface.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.GroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.GroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.grdHighlights, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdViewHighlights, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHLSelected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowHLs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignSurfaceProfile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpSurface, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSurface.ResumeLayout(False)
        Me.grpSurface.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkDuplicate As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkSurface As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GroupBox2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cboSegmentsPaintStyle As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboSplayStyle As System.Windows.Forms.ComboBox
    Friend WithEvents lblSplayStyle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupBox3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupBox4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkShowHLs As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignSurfaceProfile As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents grdHighlights As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdViewHighlights As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colHLSelected As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkHLSelected As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colHLName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grpSurface As DevExpress.XtraEditors.GroupControl
End Class
