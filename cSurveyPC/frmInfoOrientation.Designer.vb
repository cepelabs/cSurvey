<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfoOrientation
    Inherits cForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInfoOrientation))
        Dim RadarDiagram1 As DevExpress.XtraCharts.RadarDiagram = New DevExpress.XtraCharts.RadarDiagram()
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim RadarAreaSeriesView1 As DevExpress.XtraCharts.RadarAreaSeriesView = New DevExpress.XtraCharts.RadarAreaSeriesView()
        Me.cmdClose = New DevExpress.XtraEditors.SimpleButton()
        Me.chkShowCaveDistinct = New DevExpress.XtraEditors.CheckEdit()
        Me.chrtBearings = New DevExpress.XtraCharts.ChartControl()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.grdSurveyInfo = New cSurveyPC.cVerticalGrid()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.cmdExport = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOptions = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cboSurveyInfoCave = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCaveListName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtCaveListName = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.pnlLinkedSurveys = New DevExpress.XtraEditors.PanelControl()
        Me.chkShowFileDistinct = New DevExpress.XtraEditors.CheckEdit()
        Me.lblSurveyInfoFilename = New DevExpress.XtraEditors.LabelControl()
        Me.cboSurveyInfoFilename = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.flyParameters = New DevExpress.Utils.FlyoutPanel()
        Me.pnlParameters = New DevExpress.Utils.FlyoutPanelControl()
        Me.lblDepthStepUM = New DevExpress.XtraEditors.LabelControl()
        Me.chkSplay = New DevExpress.XtraEditors.CheckEdit()
        Me.lblPetals = New DevExpress.XtraEditors.LabelControl()
        Me.txtPetalsStep = New DevExpress.XtraEditors.SpinEdit()
        CType(Me.chkShowCaveDistinct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chrtBearings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(RadarDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(RadarAreaSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.grdSurveyInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.cboSurveyInfoCave.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaveListName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlLinkedSurveys, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLinkedSurveys.SuspendLayout()
        CType(Me.chkShowFileDistinct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSurveyInfoFilename.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flyParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flyParameters.SuspendLayout()
        CType(Me.pnlParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParameters.SuspendLayout()
        CType(Me.chkSplay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPetalsStep.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdClose
        '
        resources.ApplyResources(Me.cmdClose, "cmdClose")
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Name = "cmdClose"
        '
        'chkShowCaveDistinct
        '
        resources.ApplyResources(Me.chkShowCaveDistinct, "chkShowCaveDistinct")
        Me.chkShowCaveDistinct.Name = "chkShowCaveDistinct"
        Me.chkShowCaveDistinct.Properties.Caption = resources.GetString("chkShowCaveDistinct.Properties.Caption")
        '
        'chrtBearings
        '
        resources.ApplyResources(Me.chrtBearings, "chrtBearings")
        RadarDiagram1.AxisX.MinorCount = 1
        RadarDiagram1.AxisX.WholeRange.Auto = False
        RadarDiagram1.AxisX.WholeRange.AutoSideMargins = False
        RadarDiagram1.AxisX.WholeRange.EndSideMargin = 0R
        RadarDiagram1.AxisX.WholeRange.MaxValueSerializable = "359"
        RadarDiagram1.AxisX.WholeRange.MinValueSerializable = "0"
        RadarDiagram1.AxisX.WholeRange.StartSideMargin = 0R
        RadarDiagram1.AxisY.Visible = False
        RadarDiagram1.RotationDirection = DevExpress.XtraCharts.RadarDiagramRotationDirection.Clockwise
        Me.chrtBearings.Diagram = RadarDiagram1
        Me.chrtBearings.Legend.AlignmentHorizontal = CType(resources.GetObject("chrtBearings.Legend.AlignmentHorizontal"), DevExpress.XtraCharts.LegendAlignmentHorizontal)
        Me.chrtBearings.Legend.AlignmentVertical = CType(resources.GetObject("chrtBearings.Legend.AlignmentVertical"), DevExpress.XtraCharts.LegendAlignmentVertical)
        Me.chrtBearings.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBox
        Me.chrtBearings.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.chrtBearings.Name = "chrtBearings"
        Series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical
        resources.ApplyResources(Series1, "Series1")
        RadarAreaSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.[False]
        Series1.View = RadarAreaSeriesView1
        Me.chrtBearings.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1}
        '
        'XtraTabControl1
        '
        resources.ApplyResources(Me.XtraTabControl1, "XtraTabControl1")
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.grdSurveyInfo)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        resources.ApplyResources(Me.XtraTabPage1, "XtraTabPage1")
        '
        'grdSurveyInfo
        '
        resources.ApplyResources(Me.grdSurveyInfo, "grdSurveyInfo")
        Me.grdSurveyInfo.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdSurveyInfo.Name = "grdSurveyInfo"
        Me.grdSurveyInfo.OptionsFilter.AllowFilter = False
        Me.grdSurveyInfo.OptionsView.AllowHtmlText = True
        Me.grdSurveyInfo.OptionsView.MinRowAutoHeight = 20
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.PanelControl1)
        Me.XtraTabPage2.Controls.Add(Me.pnlLinkedSurveys)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        resources.ApplyResources(Me.XtraTabPage2, "XtraTabPage2")
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.cmdExport)
        Me.PanelControl1.Controls.Add(Me.cmdOptions)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.cboSurveyInfoCave)
        Me.PanelControl1.Controls.Add(Me.chkShowCaveDistinct)
        Me.PanelControl1.Controls.Add(Me.chrtBearings)
        resources.ApplyResources(Me.PanelControl1, "PanelControl1")
        Me.PanelControl1.Name = "PanelControl1"
        '
        'cmdExport
        '
        resources.ApplyResources(Me.cmdExport, "cmdExport")
        Me.cmdExport.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdExport.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.exportfile
        Me.cmdExport.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdExport.Name = "cmdExport"
        '
        'cmdOptions
        '
        resources.ApplyResources(Me.cmdOptions, "cmdOptions")
        Me.cmdOptions.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdOptions.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.properties
        Me.cmdOptions.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdOptions.Name = "cmdOptions"
        '
        'LabelControl1
        '
        resources.ApplyResources(Me.LabelControl1, "LabelControl1")
        Me.LabelControl1.Name = "LabelControl1"
        '
        'cboSurveyInfoCave
        '
        resources.ApplyResources(Me.cboSurveyInfoCave, "cboSurveyInfoCave")
        Me.cboSurveyInfoCave.Name = "cboSurveyInfoCave"
        Me.cboSurveyInfoCave.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboSurveyInfoCave.Properties.Appearance.Font = CType(resources.GetObject("cboSurveyInfoCave.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cboSurveyInfoCave.Properties.Appearance.Options.UseFont = True
        Me.cboSurveyInfoCave.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboSurveyInfoCave.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboSurveyInfoCave.Properties.DisplayMember = "ToHTMLString"
        Me.cboSurveyInfoCave.Properties.NullText = resources.GetString("cboSurveyInfoCave.Properties.NullText")
        Me.cboSurveyInfoCave.Properties.PopupSizeable = False
        Me.cboSurveyInfoCave.Properties.PopupView = Me.GridLookUpEdit1View
        Me.cboSurveyInfoCave.Properties.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtCaveListName})
        '
        'GridLookUpEdit1View
        '
        Me.GridLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCaveListName})
        Me.GridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridLookUpEdit1View.Name = "GridLookUpEdit1View"
        Me.GridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'colCaveListName
        '
        resources.ApplyResources(Me.colCaveListName, "colCaveListName")
        Me.colCaveListName.ColumnEdit = Me.txtCaveListName
        Me.colCaveListName.FieldName = "ToHTMLString"
        Me.colCaveListName.Name = "colCaveListName"
        Me.colCaveListName.OptionsColumn.AllowEdit = False
        '
        'txtCaveListName
        '
        Me.txtCaveListName.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.txtCaveListName, "txtCaveListName")
        Me.txtCaveListName.Name = "txtCaveListName"
        Me.txtCaveListName.ReadOnly = True
        '
        'pnlLinkedSurveys
        '
        Me.pnlLinkedSurveys.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlLinkedSurveys.Controls.Add(Me.chkShowFileDistinct)
        Me.pnlLinkedSurveys.Controls.Add(Me.lblSurveyInfoFilename)
        Me.pnlLinkedSurveys.Controls.Add(Me.cboSurveyInfoFilename)
        resources.ApplyResources(Me.pnlLinkedSurveys, "pnlLinkedSurveys")
        Me.pnlLinkedSurveys.Name = "pnlLinkedSurveys"
        '
        'chkShowFileDistinct
        '
        resources.ApplyResources(Me.chkShowFileDistinct, "chkShowFileDistinct")
        Me.chkShowFileDistinct.Name = "chkShowFileDistinct"
        Me.chkShowFileDistinct.Properties.Caption = resources.GetString("chkShowFileDistinct.Properties.Caption")
        '
        'lblSurveyInfoFilename
        '
        resources.ApplyResources(Me.lblSurveyInfoFilename, "lblSurveyInfoFilename")
        Me.lblSurveyInfoFilename.Name = "lblSurveyInfoFilename"
        '
        'cboSurveyInfoFilename
        '
        resources.ApplyResources(Me.cboSurveyInfoFilename, "cboSurveyInfoFilename")
        Me.cboSurveyInfoFilename.Name = "cboSurveyInfoFilename"
        Me.cboSurveyInfoFilename.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboSurveyInfoFilename.Properties.Appearance.Font = CType(resources.GetObject("cboSurveyInfoFilename.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cboSurveyInfoFilename.Properties.Appearance.Options.UseFont = True
        Me.cboSurveyInfoFilename.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboSurveyInfoFilename.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboSurveyInfoFilename.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'flyParameters
        '
        Me.flyParameters.Controls.Add(Me.pnlParameters)
        resources.ApplyResources(Me.flyParameters, "flyParameters")
        Me.flyParameters.Name = "flyParameters"
        Me.flyParameters.OwnerControl = Me.cmdOptions
        '
        'pnlParameters
        '
        Me.pnlParameters.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlParameters.Controls.Add(Me.lblDepthStepUM)
        Me.pnlParameters.Controls.Add(Me.chkSplay)
        Me.pnlParameters.Controls.Add(Me.lblPetals)
        Me.pnlParameters.Controls.Add(Me.txtPetalsStep)
        resources.ApplyResources(Me.pnlParameters, "pnlParameters")
        Me.pnlParameters.FlyoutPanel = Me.flyParameters
        Me.pnlParameters.Name = "pnlParameters"
        '
        'lblDepthStepUM
        '
        resources.ApplyResources(Me.lblDepthStepUM, "lblDepthStepUM")
        Me.lblDepthStepUM.Name = "lblDepthStepUM"
        '
        'chkSplay
        '
        resources.ApplyResources(Me.chkSplay, "chkSplay")
        Me.chkSplay.Name = "chkSplay"
        Me.chkSplay.Properties.AutoWidth = True
        Me.chkSplay.Properties.Caption = resources.GetString("chkSplay.Properties.Caption")
        '
        'lblPetals
        '
        resources.ApplyResources(Me.lblPetals, "lblPetals")
        Me.lblPetals.Name = "lblPetals"
        '
        'txtPetalsStep
        '
        resources.ApplyResources(Me.txtPetalsStep, "txtPetalsStep")
        Me.txtPetalsStep.Name = "txtPetalsStep"
        Me.txtPetalsStep.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPetalsStep.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPetalsStep.Properties.DisplayFormat.FormatString = "N0"
        Me.txtPetalsStep.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPetalsStep.Properties.EditFormat.FormatString = "N0"
        Me.txtPetalsStep.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPetalsStep.Properties.IsFloatValue = False
        Me.txtPetalsStep.Properties.MaskSettings.Set("mask", "N00")
        Me.txtPetalsStep.Properties.MaxValue = New Decimal(New Integer() {45, 0, 0, 0})
        Me.txtPetalsStep.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'frmInfoOrientation
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.flyParameters)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.navigation
        Me.MinimizeBox = False
        Me.Name = "frmInfoOrientation"
        CType(Me.chkShowCaveDistinct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(RadarDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(RadarAreaSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chrtBearings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.grdSurveyInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.cboSurveyInfoCave.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaveListName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlLinkedSurveys, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLinkedSurveys.ResumeLayout(False)
        Me.pnlLinkedSurveys.PerformLayout()
        CType(Me.chkShowFileDistinct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSurveyInfoFilename.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flyParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flyParameters.ResumeLayout(False)
        CType(Me.pnlParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParameters.ResumeLayout(False)
        Me.pnlParameters.PerformLayout()
        CType(Me.chkSplay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPetalsStep.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkShowCaveDistinct As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chrtBearings As DevExpress.XtraCharts.ChartControl
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboSurveyInfoCave As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCaveListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtCaveListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents grdSurveyInfo As cVerticalGrid
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlLinkedSurveys As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblSurveyInfoFilename As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboSurveyInfoFilename As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents chkShowFileDistinct As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents flyParameters As DevExpress.Utils.FlyoutPanel
    Friend WithEvents pnlParameters As DevExpress.Utils.FlyoutPanelControl
    Friend WithEvents lblDepthStepUM As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkSplay As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblPetals As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPetalsStep As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents cmdOptions As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdExport As DevExpress.XtraEditors.SimpleButton
End Class
