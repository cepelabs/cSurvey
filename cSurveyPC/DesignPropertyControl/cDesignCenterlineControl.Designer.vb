<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cDesignCenterlineControl
    Inherits cDesignPropertyControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDesignCenterlineControl))
        Me.chkDesignPlot = New DevExpress.XtraEditors.CheckEdit()
        Me.pnlDesignPlot = New DevExpress.XtraEditors.PanelControl()
        Me.chkDesignPlotShowSegmentSurface = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDesignPlotShowSegmentDuplicate = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDesignPlotShowSplayMode = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDesignPlotColorGray = New DevExpress.XtraEditors.CheckEdit()
        Me.btnDesignRings = New DevExpress.XtraEditors.SimpleButton()
        Me.cboDesignPlotSegmentsPaintStyle = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.chkDesignPlotShowHLs = New DevExpress.XtraEditors.CheckEdit()
        Me.cboDesignPlotColorMode = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblDesignPlotColorMode = New DevExpress.XtraEditors.LabelControl()
        Me.chkDesignPlotShowTrigpointText = New DevExpress.XtraEditors.CheckEdit()
        Me.btnDesignPlotSplay = New DevExpress.XtraEditors.SimpleButton()
        Me.chkDesignPlotShowTrigpoint = New DevExpress.XtraEditors.CheckEdit()
        Me.btnDesignHighlights = New DevExpress.XtraEditors.SimpleButton()
        Me.chkDesignPlotShowLRUD = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDesignPlotShowSplayLabel = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDesignPlotShowSegment = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDesignPlotShowSplay = New DevExpress.XtraEditors.CheckEdit()
        Me.cboDesignPlotSplayStyle = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.grdHighlights = New DevExpress.XtraGrid.GridControl()
        Me.grdViewHighlights = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colHLSelected = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkHLSelected = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colHLName = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.chkDesignPlot.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDesignPlot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDesignPlot.SuspendLayout()
        CType(Me.chkDesignPlotShowSegmentSurface.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPlotShowSegmentDuplicate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPlotShowSplayMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPlotColorGray.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDesignPlotSegmentsPaintStyle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPlotShowHLs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDesignPlotColorMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPlotShowTrigpointText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPlotShowTrigpoint.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPlotShowLRUD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPlotShowSplayLabel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPlotShowSegment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPlotShowSplay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDesignPlotSplayStyle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdHighlights, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdViewHighlights, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHLSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkDesignPlot
        '
        resources.ApplyResources(Me.chkDesignPlot, "chkDesignPlot")
        Me.chkDesignPlot.Name = "chkDesignPlot"
        Me.chkDesignPlot.Properties.AutoWidth = True
        Me.chkDesignPlot.Properties.Caption = resources.GetString("chkDesignPlot.Properties.Caption")
        '
        'pnlDesignPlot
        '
        resources.ApplyResources(Me.pnlDesignPlot, "pnlDesignPlot")
        Me.pnlDesignPlot.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowSegmentSurface)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowSegmentDuplicate)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowSplayMode)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotColorGray)
        Me.pnlDesignPlot.Controls.Add(Me.btnDesignRings)
        Me.pnlDesignPlot.Controls.Add(Me.cboDesignPlotSegmentsPaintStyle)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowHLs)
        Me.pnlDesignPlot.Controls.Add(Me.cboDesignPlotColorMode)
        Me.pnlDesignPlot.Controls.Add(Me.lblDesignPlotColorMode)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowTrigpointText)
        Me.pnlDesignPlot.Controls.Add(Me.btnDesignPlotSplay)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowTrigpoint)
        Me.pnlDesignPlot.Controls.Add(Me.btnDesignHighlights)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowLRUD)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowSplayLabel)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowSegment)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowSplay)
        Me.pnlDesignPlot.Controls.Add(Me.cboDesignPlotSplayStyle)
        Me.pnlDesignPlot.Controls.Add(Me.grdHighlights)
        Me.pnlDesignPlot.Name = "pnlDesignPlot"
        '
        'chkDesignPlotShowSegmentSurface
        '
        resources.ApplyResources(Me.chkDesignPlotShowSegmentSurface, "chkDesignPlotShowSegmentSurface")
        Me.chkDesignPlotShowSegmentSurface.Name = "chkDesignPlotShowSegmentSurface"
        Me.chkDesignPlotShowSegmentSurface.Properties.AutoWidth = True
        Me.chkDesignPlotShowSegmentSurface.Properties.Caption = resources.GetString("chkDesignPlotShowSegmentSurface.Properties.Caption")
        '
        'chkDesignPlotShowSegmentDuplicate
        '
        resources.ApplyResources(Me.chkDesignPlotShowSegmentDuplicate, "chkDesignPlotShowSegmentDuplicate")
        Me.chkDesignPlotShowSegmentDuplicate.Name = "chkDesignPlotShowSegmentDuplicate"
        Me.chkDesignPlotShowSegmentDuplicate.Properties.AutoWidth = True
        Me.chkDesignPlotShowSegmentDuplicate.Properties.Caption = resources.GetString("chkDesignPlotShowSegmentDuplicate.Properties.Caption")
        '
        'chkDesignPlotShowSplayMode
        '
        resources.ApplyResources(Me.chkDesignPlotShowSplayMode, "chkDesignPlotShowSplayMode")
        Me.chkDesignPlotShowSplayMode.Name = "chkDesignPlotShowSplayMode"
        Me.chkDesignPlotShowSplayMode.Properties.AutoWidth = True
        Me.chkDesignPlotShowSplayMode.Properties.Caption = resources.GetString("chkDesignPlotShowSplayMode.Properties.Caption")
        '
        'chkDesignPlotColorGray
        '
        resources.ApplyResources(Me.chkDesignPlotColorGray, "chkDesignPlotColorGray")
        Me.chkDesignPlotColorGray.Name = "chkDesignPlotColorGray"
        Me.chkDesignPlotColorGray.Properties.Appearance.Font = CType(resources.GetObject("chkDesignPlotColorGray.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkDesignPlotColorGray.Properties.Appearance.Options.UseFont = True
        Me.chkDesignPlotColorGray.Properties.AutoWidth = True
        Me.chkDesignPlotColorGray.Properties.Caption = resources.GetString("chkDesignPlotColorGray.Properties.Caption")
        '
        'btnDesignRings
        '
        resources.ApplyResources(Me.btnDesignRings, "btnDesignRings")
        Me.btnDesignRings.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnDesignRings.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.bo_statemachine
        Me.btnDesignRings.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.btnDesignRings.Name = "btnDesignRings"
        '
        'cboDesignPlotSegmentsPaintStyle
        '
        resources.ApplyResources(Me.cboDesignPlotSegmentsPaintStyle, "cboDesignPlotSegmentsPaintStyle")
        Me.cboDesignPlotSegmentsPaintStyle.Name = "cboDesignPlotSegmentsPaintStyle"
        Me.cboDesignPlotSegmentsPaintStyle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboDesignPlotSegmentsPaintStyle.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboDesignPlotSegmentsPaintStyle.Properties.Items.AddRange(New Object() {resources.GetString("cboDesignPlotSegmentsPaintStyle.Properties.Items"), resources.GetString("cboDesignPlotSegmentsPaintStyle.Properties.Items1"), resources.GetString("cboDesignPlotSegmentsPaintStyle.Properties.Items2"), resources.GetString("cboDesignPlotSegmentsPaintStyle.Properties.Items3")})
        Me.cboDesignPlotSegmentsPaintStyle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'chkDesignPlotShowHLs
        '
        resources.ApplyResources(Me.chkDesignPlotShowHLs, "chkDesignPlotShowHLs")
        Me.chkDesignPlotShowHLs.Name = "chkDesignPlotShowHLs"
        Me.chkDesignPlotShowHLs.Properties.AutoWidth = True
        Me.chkDesignPlotShowHLs.Properties.Caption = resources.GetString("chkDesignPlotShowHLs.Properties.Caption")
        '
        'cboDesignPlotColorMode
        '
        resources.ApplyResources(Me.cboDesignPlotColorMode, "cboDesignPlotColorMode")
        Me.cboDesignPlotColorMode.Name = "cboDesignPlotColorMode"
        Me.cboDesignPlotColorMode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboDesignPlotColorMode.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboDesignPlotColorMode.Properties.Items.AddRange(New Object() {resources.GetString("cboDesignPlotColorMode.Properties.Items"), resources.GetString("cboDesignPlotColorMode.Properties.Items1"), resources.GetString("cboDesignPlotColorMode.Properties.Items2")})
        Me.cboDesignPlotColorMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblDesignPlotColorMode
        '
        Me.lblDesignPlotColorMode.Appearance.Font = CType(resources.GetObject("lblDesignPlotColorMode.Appearance.Font"), System.Drawing.Font)
        Me.lblDesignPlotColorMode.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblDesignPlotColorMode, "lblDesignPlotColorMode")
        Me.lblDesignPlotColorMode.Name = "lblDesignPlotColorMode"
        '
        'chkDesignPlotShowTrigpointText
        '
        resources.ApplyResources(Me.chkDesignPlotShowTrigpointText, "chkDesignPlotShowTrigpointText")
        Me.chkDesignPlotShowTrigpointText.Name = "chkDesignPlotShowTrigpointText"
        Me.chkDesignPlotShowTrigpointText.Properties.AutoWidth = True
        Me.chkDesignPlotShowTrigpointText.Properties.Caption = resources.GetString("chkDesignPlotShowTrigpointText.Properties.Caption")
        '
        'btnDesignPlotSplay
        '
        Me.btnDesignPlotSplay.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnDesignPlotSplay.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.replicatesplaydata
        Me.btnDesignPlotSplay.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.btnDesignPlotSplay, "btnDesignPlotSplay")
        Me.btnDesignPlotSplay.Name = "btnDesignPlotSplay"
        '
        'chkDesignPlotShowTrigpoint
        '
        resources.ApplyResources(Me.chkDesignPlotShowTrigpoint, "chkDesignPlotShowTrigpoint")
        Me.chkDesignPlotShowTrigpoint.Name = "chkDesignPlotShowTrigpoint"
        Me.chkDesignPlotShowTrigpoint.Properties.AutoWidth = True
        Me.chkDesignPlotShowTrigpoint.Properties.Caption = resources.GetString("chkDesignPlotShowTrigpoint.Properties.Caption")
        '
        'btnDesignHighlights
        '
        resources.ApplyResources(Me.btnDesignHighlights, "btnDesignHighlights")
        Me.btnDesignHighlights.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnDesignHighlights.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.highlightfields
        Me.btnDesignHighlights.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.btnDesignHighlights.Name = "btnDesignHighlights"
        '
        'chkDesignPlotShowLRUD
        '
        resources.ApplyResources(Me.chkDesignPlotShowLRUD, "chkDesignPlotShowLRUD")
        Me.chkDesignPlotShowLRUD.Name = "chkDesignPlotShowLRUD"
        Me.chkDesignPlotShowLRUD.Properties.AutoWidth = True
        Me.chkDesignPlotShowLRUD.Properties.Caption = resources.GetString("chkDesignPlotShowLRUD.Properties.Caption")
        '
        'chkDesignPlotShowSplayLabel
        '
        resources.ApplyResources(Me.chkDesignPlotShowSplayLabel, "chkDesignPlotShowSplayLabel")
        Me.chkDesignPlotShowSplayLabel.Name = "chkDesignPlotShowSplayLabel"
        Me.chkDesignPlotShowSplayLabel.Properties.AutoWidth = True
        Me.chkDesignPlotShowSplayLabel.Properties.Caption = resources.GetString("chkDesignPlotShowSplayLabel.Properties.Caption")
        '
        'chkDesignPlotShowSegment
        '
        resources.ApplyResources(Me.chkDesignPlotShowSegment, "chkDesignPlotShowSegment")
        Me.chkDesignPlotShowSegment.Name = "chkDesignPlotShowSegment"
        Me.chkDesignPlotShowSegment.Properties.AutoWidth = True
        Me.chkDesignPlotShowSegment.Properties.Caption = resources.GetString("chkDesignPlotShowSegment.Properties.Caption")
        '
        'chkDesignPlotShowSplay
        '
        resources.ApplyResources(Me.chkDesignPlotShowSplay, "chkDesignPlotShowSplay")
        Me.chkDesignPlotShowSplay.Name = "chkDesignPlotShowSplay"
        Me.chkDesignPlotShowSplay.Properties.AutoWidth = True
        Me.chkDesignPlotShowSplay.Properties.Caption = resources.GetString("chkDesignPlotShowSplay.Properties.Caption")
        '
        'cboDesignPlotSplayStyle
        '
        resources.ApplyResources(Me.cboDesignPlotSplayStyle, "cboDesignPlotSplayStyle")
        Me.cboDesignPlotSplayStyle.Name = "cboDesignPlotSplayStyle"
        Me.cboDesignPlotSplayStyle.Properties.Appearance.Font = CType(resources.GetObject("cboDesignPlotSplayStyle.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cboDesignPlotSplayStyle.Properties.Appearance.Options.UseFont = True
        Me.cboDesignPlotSplayStyle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboDesignPlotSplayStyle.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboDesignPlotSplayStyle.Properties.Items.AddRange(New Object() {resources.GetString("cboDesignPlotSplayStyle.Properties.Items"), resources.GetString("cboDesignPlotSplayStyle.Properties.Items1"), resources.GetString("cboDesignPlotSplayStyle.Properties.Items2")})
        Me.cboDesignPlotSplayStyle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
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
        Me.grdViewHighlights.OptionsCustomization.AllowSort = False
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
        'cDesignCenterlineControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.chkDesignPlot)
        Me.Controls.Add(Me.pnlDesignPlot)
        Me.Name = "cDesignCenterlineControl"
        CType(Me.chkDesignPlot.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDesignPlot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDesignPlot.ResumeLayout(False)
        Me.pnlDesignPlot.PerformLayout()
        CType(Me.chkDesignPlotShowSegmentSurface.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPlotShowSegmentDuplicate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPlotShowSplayMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPlotColorGray.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDesignPlotSegmentsPaintStyle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPlotShowHLs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDesignPlotColorMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPlotShowTrigpointText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPlotShowTrigpoint.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPlotShowLRUD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPlotShowSplayLabel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPlotShowSegment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPlotShowSplay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDesignPlotSplayStyle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdHighlights, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdViewHighlights, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHLSelected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkDesignPlot As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents pnlDesignPlot As DevExpress.XtraEditors.PanelControl
    Friend WithEvents chkDesignPlotShowSplayMode As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignPlotColorGray As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnDesignRings As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboDesignPlotSegmentsPaintStyle As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents chkDesignPlotShowHLs As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboDesignPlotColorMode As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblDesignPlotColorMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkDesignPlotShowTrigpointText As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnDesignPlotSplay As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkDesignPlotShowTrigpoint As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnDesignHighlights As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkDesignPlotShowLRUD As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignPlotShowSplayLabel As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignPlotShowSegment As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignPlotShowSplay As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboDesignPlotSplayStyle As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents chkDesignPlotShowSegmentSurface As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignPlotShowSegmentDuplicate As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents grdHighlights As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdViewHighlights As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colHLSelected As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHLName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkHLSelected As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
