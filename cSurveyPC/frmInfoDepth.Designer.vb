<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInfoDepth
    Inherits cForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInfoDepth))
        Dim XyDiagram2 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series2 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
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
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.grdData = New DevExpress.XtraGrid.GridControl()
        Me.grdDataView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDataBranchCaveColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDataBranchCave = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSegmentsBranchBranchColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDataBranchBranch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDataSegmentFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDataSegmentTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDataDepth = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDataValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkSplay = New DevExpress.XtraEditors.CheckEdit()
        Me.txtDepthStep = New DevExpress.XtraEditors.SpinEdit()
        Me.lblDepthStep = New DevExpress.XtraEditors.LabelControl()
        Me.flyParameters = New DevExpress.Utils.FlyoutPanel()
        Me.pnlParameters = New DevExpress.Utils.FlyoutPanelControl()
        Me.lblCountType = New DevExpress.XtraEditors.LabelControl()
        Me.cboCountType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblDepthStepUM = New DevExpress.XtraEditors.LabelControl()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnCopyValue = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCopyValues = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCopyAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCopy = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExport = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuContext = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.chkShowCaveDistinct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chrtBearings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.XtraTabPage3.SuspendLayout()
        CType(Me.grdData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSplay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDepthStep.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flyParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flyParameters.SuspendLayout()
        CType(Me.pnlParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParameters.SuspendLayout()
        CType(Me.cboCountType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).BeginInit()
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
        XyDiagram2.AxisX.MinorCount = 5
        XyDiagram2.AxisX.NumericScaleOptions.AggregateFunction = DevExpress.XtraCharts.AggregateFunction.Sum
        XyDiagram2.AxisX.NumericScaleOptions.AutoGrid = False
        XyDiagram2.AxisX.NumericScaleOptions.GridSpacing = 5.0R
        XyDiagram2.AxisX.NumericScaleOptions.MinGridSpacingLength = 5
        XyDiagram2.AxisX.NumericScaleOptions.ProcessMissingPoints = DevExpress.XtraCharts.ProcessMissingPointsMode.InsertEmptyPoints
        XyDiagram2.AxisX.NumericScaleOptions.ScaleMode = DevExpress.XtraCharts.ScaleMode.Manual
        XyDiagram2.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram2.AxisY.VisibleInPanesSerializable = "-1"
        XyDiagram2.EnableAxisXScrolling = True
        XyDiagram2.EnableAxisXZooming = True
        XyDiagram2.EnableAxisYScrolling = True
        XyDiagram2.EnableAxisYZooming = True
        XyDiagram2.Rotated = True
        Me.chrtBearings.Diagram = XyDiagram2
        Me.chrtBearings.Legend.AlignmentHorizontal = CType(resources.GetObject("chrtBearings.Legend.AlignmentHorizontal"), DevExpress.XtraCharts.LegendAlignmentHorizontal)
        Me.chrtBearings.Legend.AlignmentVertical = CType(resources.GetObject("chrtBearings.Legend.AlignmentVertical"), DevExpress.XtraCharts.LegendAlignmentVertical)
        Me.chrtBearings.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBox
        Me.chrtBearings.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.chrtBearings.Name = "chrtBearings"
        resources.ApplyResources(Series2, "Series2")
        Me.chrtBearings.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series2}
        '
        'XtraTabControl1
        '
        resources.ApplyResources(Me.XtraTabControl1, "XtraTabControl1")
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage2, Me.XtraTabPage1, Me.XtraTabPage3})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.grdSurveyInfo)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.PageVisible = False
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
        'XtraTabPage3
        '
        Me.XtraTabPage3.Controls.Add(Me.grdData)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        resources.ApplyResources(Me.XtraTabPage3, "XtraTabPage3")
        '
        'grdData
        '
        resources.ApplyResources(Me.grdData, "grdData")
        Me.grdData.MainView = Me.grdDataView
        Me.grdData.Name = "grdData"
        Me.grdData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdDataView})
        '
        'grdDataView
        '
        Me.grdDataView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDataBranchCaveColor, Me.colDataBranchCave, Me.colSegmentsBranchBranchColor, Me.colDataBranchBranch, Me.colDataSegmentFrom, Me.colDataSegmentTo, Me.colDataDepth, Me.colDataValue})
        Me.grdDataView.GridControl = Me.grdData
        Me.grdDataView.Name = "grdDataView"
        Me.grdDataView.OptionsBehavior.Editable = False
        Me.grdDataView.OptionsBehavior.ReadOnly = True
        Me.grdDataView.OptionsSelection.MultiSelect = True
        Me.grdDataView.OptionsView.ShowGroupPanel = False
        '
        'colDataBranchCaveColor
        '
        resources.ApplyResources(Me.colDataBranchCaveColor, "colDataBranchCaveColor")
        Me.colDataBranchCaveColor.FieldName = "CaveColor"
        Me.colDataBranchCaveColor.MaxWidth = 10
        Me.colDataBranchCaveColor.MinWidth = 10
        Me.colDataBranchCaveColor.Name = "colDataBranchCaveColor"
        Me.colDataBranchCaveColor.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colDataBranchCaveColor.OptionsColumn.AllowMove = False
        Me.colDataBranchCaveColor.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.colDataBranchCaveColor.OptionsColumn.FixedWidth = True
        Me.colDataBranchCaveColor.UnboundDataType = GetType(String)
        '
        'colDataBranchCave
        '
        resources.ApplyResources(Me.colDataBranchCave, "colDataBranchCave")
        Me.colDataBranchCave.FieldName = "Segment.Cave"
        Me.colDataBranchCave.Name = "colDataBranchCave"
        Me.colDataBranchCave.OptionsColumn.AllowMove = False
        '
        'colSegmentsBranchBranchColor
        '
        resources.ApplyResources(Me.colSegmentsBranchBranchColor, "colSegmentsBranchBranchColor")
        Me.colSegmentsBranchBranchColor.FieldName = "BranchColor"
        Me.colSegmentsBranchBranchColor.MaxWidth = 10
        Me.colSegmentsBranchBranchColor.MinWidth = 10
        Me.colSegmentsBranchBranchColor.Name = "colSegmentsBranchBranchColor"
        Me.colSegmentsBranchBranchColor.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colSegmentsBranchBranchColor.OptionsColumn.AllowMove = False
        Me.colSegmentsBranchBranchColor.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.colSegmentsBranchBranchColor.OptionsColumn.FixedWidth = True
        Me.colSegmentsBranchBranchColor.UnboundDataType = GetType(String)
        '
        'colDataBranchBranch
        '
        resources.ApplyResources(Me.colDataBranchBranch, "colDataBranchBranch")
        Me.colDataBranchBranch.FieldName = "Segment.Branch"
        Me.colDataBranchBranch.Name = "colDataBranchBranch"
        Me.colDataBranchBranch.OptionsColumn.AllowMove = False
        '
        'colDataSegmentFrom
        '
        resources.ApplyResources(Me.colDataSegmentFrom, "colDataSegmentFrom")
        Me.colDataSegmentFrom.FieldName = "Segment.From"
        Me.colDataSegmentFrom.Name = "colDataSegmentFrom"
        '
        'colDataSegmentTo
        '
        resources.ApplyResources(Me.colDataSegmentTo, "colDataSegmentTo")
        Me.colDataSegmentTo.FieldName = "Segment.To"
        Me.colDataSegmentTo.Name = "colDataSegmentTo"
        '
        'colDataDepth
        '
        resources.ApplyResources(Me.colDataDepth, "colDataDepth")
        Me.colDataDepth.DisplayFormat.FormatString = "N0"
        Me.colDataDepth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDataDepth.FieldName = "Quota"
        Me.colDataDepth.Name = "colDataDepth"
        '
        'colDataValue
        '
        resources.ApplyResources(Me.colDataValue, "colDataValue")
        Me.colDataValue.DisplayFormat.FormatString = "N3"
        Me.colDataValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDataValue.FieldName = "Value"
        Me.colDataValue.Name = "colDataValue"
        '
        'chkSplay
        '
        resources.ApplyResources(Me.chkSplay, "chkSplay")
        Me.chkSplay.Name = "chkSplay"
        Me.chkSplay.Properties.AutoWidth = True
        Me.chkSplay.Properties.Caption = resources.GetString("chkSplay.Properties.Caption")
        '
        'txtDepthStep
        '
        resources.ApplyResources(Me.txtDepthStep, "txtDepthStep")
        Me.txtDepthStep.Name = "txtDepthStep"
        Me.txtDepthStep.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtDepthStep.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtDepthStep.Properties.DisplayFormat.FormatString = "N0"
        Me.txtDepthStep.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtDepthStep.Properties.EditFormat.FormatString = "N0"
        Me.txtDepthStep.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtDepthStep.Properties.IsFloatValue = False
        Me.txtDepthStep.Properties.MaskSettings.Set("mask", "N00")
        Me.txtDepthStep.Properties.MaxValue = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtDepthStep.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblDepthStep
        '
        resources.ApplyResources(Me.lblDepthStep, "lblDepthStep")
        Me.lblDepthStep.Name = "lblDepthStep"
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
        Me.pnlParameters.Controls.Add(Me.lblCountType)
        Me.pnlParameters.Controls.Add(Me.cboCountType)
        Me.pnlParameters.Controls.Add(Me.lblDepthStepUM)
        Me.pnlParameters.Controls.Add(Me.chkSplay)
        Me.pnlParameters.Controls.Add(Me.lblDepthStep)
        Me.pnlParameters.Controls.Add(Me.txtDepthStep)
        resources.ApplyResources(Me.pnlParameters, "pnlParameters")
        Me.pnlParameters.FlyoutPanel = Me.flyParameters
        Me.pnlParameters.Name = "pnlParameters"
        '
        'lblCountType
        '
        resources.ApplyResources(Me.lblCountType, "lblCountType")
        Me.lblCountType.Name = "lblCountType"
        '
        'cboCountType
        '
        resources.ApplyResources(Me.cboCountType, "cboCountType")
        Me.cboCountType.Name = "cboCountType"
        Me.cboCountType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboCountType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboCountType.Properties.Items.AddRange(New Object() {resources.GetString("cboCountType.Properties.Items"), resources.GetString("cboCountType.Properties.Items1")})
        Me.cboCountType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblDepthStepUM
        '
        resources.ApplyResources(Me.lblDepthStepUM, "lblDepthStepUM")
        Me.lblDepthStepUM.Name = "lblDepthStepUM"
        '
        'BarManager
        '
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnCopyValue, Me.btnCopyValues, Me.btnCopyAll, Me.btnCopy, Me.btnExport})
        Me.BarManager.MaxItemId = 8
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        resources.ApplyResources(Me.barDockControlTop, "barDockControlTop")
        Me.barDockControlTop.Manager = Me.BarManager
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        resources.ApplyResources(Me.barDockControlBottom, "barDockControlBottom")
        Me.barDockControlBottom.Manager = Me.BarManager
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        resources.ApplyResources(Me.barDockControlLeft, "barDockControlLeft")
        Me.barDockControlLeft.Manager = Me.BarManager
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        resources.ApplyResources(Me.barDockControlRight, "barDockControlRight")
        Me.barDockControlRight.Manager = Me.BarManager
        '
        'btnCopyValue
        '
        resources.ApplyResources(Me.btnCopyValue, "btnCopyValue")
        Me.btnCopyValue.Id = 3
        Me.btnCopyValue.Name = "btnCopyValue"
        '
        'btnCopyValues
        '
        resources.ApplyResources(Me.btnCopyValues, "btnCopyValues")
        Me.btnCopyValues.Id = 4
        Me.btnCopyValues.Name = "btnCopyValues"
        '
        'btnCopyAll
        '
        resources.ApplyResources(Me.btnCopyAll, "btnCopyAll")
        Me.btnCopyAll.Id = 5
        Me.btnCopyAll.Name = "btnCopyAll"
        '
        'btnCopy
        '
        resources.ApplyResources(Me.btnCopy, "btnCopy")
        Me.btnCopy.Id = 6
        Me.btnCopy.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.copy
        Me.btnCopy.Name = "btnCopy"
        '
        'btnExport
        '
        resources.ApplyResources(Me.btnExport, "btnExport")
        Me.btnExport.Id = 7
        Me.btnExport.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.exportfile
        Me.btnExport.Name = "btnExport"
        '
        'mnuContext
        '
        Me.mnuContext.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopyValue, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopyValues), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopy, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopyAll), New DevExpress.XtraBars.LinkPersistInfo(Me.btnExport, True)})
        Me.mnuContext.Manager = Me.BarManager
        Me.mnuContext.Name = "mnuContext"
        '
        'frmInfoDepth
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.flyParameters)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.bar
        Me.MinimizeBox = False
        Me.Name = "frmInfoDepth"
        CType(Me.chkShowCaveDistinct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(XyDiagram2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.XtraTabPage3.ResumeLayout(False)
        CType(Me.grdData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSplay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDepthStep.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flyParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flyParameters.ResumeLayout(False)
        CType(Me.pnlParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParameters.ResumeLayout(False)
        Me.pnlParameters.PerformLayout()
        CType(Me.cboCountType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents cmdOptions As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkSplay As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtDepthStep As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblDepthStep As DevExpress.XtraEditors.LabelControl
    Friend WithEvents flyParameters As DevExpress.Utils.FlyoutPanel
    Friend WithEvents pnlParameters As DevExpress.Utils.FlyoutPanelControl
    Friend WithEvents lblDepthStepUM As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCountType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboCountType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents grdData As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdDataView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colDataDepth As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDataValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDataSegmentFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDataSegmentTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnCopyValue As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopyValues As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopyAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopy As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuContext As DevExpress.XtraBars.PopupMenu
    Friend WithEvents colDataBranchCave As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDataBranchBranch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDataBranchCaveColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSegmentsBranchBranchColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdExport As DevExpress.XtraEditors.SimpleButton
End Class
