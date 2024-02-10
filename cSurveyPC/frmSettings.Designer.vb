<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSettings
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
    '<System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.tabHistorySettings = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chkHistoryArchiveOnSave = New DevExpress.XtraEditors.CheckEdit()
        Me.lblHistoryMaxCopies = New DevExpress.XtraEditors.LabelControl()
        Me.txtHistoryFolder = New System.Windows.Forms.TextBox()
        Me.txtHistoryMaxCopies = New System.Windows.Forms.NumericUpDown()
        Me.lblHistoryFolder = New DevExpress.XtraEditors.LabelControl()
        Me.lblHistoryDailyCopies = New DevExpress.XtraEditors.LabelControl()
        Me.cmdHistoryFolderBrowse = New DevExpress.XtraEditors.SimpleButton()
        Me.txtHistoryDailyCopies = New System.Windows.Forms.NumericUpDown()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.chkHistoryWebArchiveOnSave = New DevExpress.XtraEditors.CheckEdit()
        Me.chkHistoryWebAuthReq = New DevExpress.XtraEditors.CheckEdit()
        Me.lblHistoryWebMaxCopies = New DevExpress.XtraEditors.LabelControl()
        Me.txtHistoryWebMaxCopies = New System.Windows.Forms.NumericUpDown()
        Me.lblHistoryWebDailyCopies = New DevExpress.XtraEditors.LabelControl()
        Me.txtHistoryWebDailyCopies = New System.Windows.Forms.NumericUpDown()
        Me.cmdHistoryWebCheck = New DevExpress.XtraEditors.SimpleButton()
        Me.txtHistoryWebURL = New System.Windows.Forms.TextBox()
        Me.lblHistoryWebPassword = New DevExpress.XtraEditors.LabelControl()
        Me.lblHistoryWebAddress = New DevExpress.XtraEditors.LabelControl()
        Me.txtHistoryWebPassword = New System.Windows.Forms.TextBox()
        Me.txtHistoryWebUsername = New System.Windows.Forms.TextBox()
        Me.lblHistoryWebUsername = New DevExpress.XtraEditors.LabelControl()
        Me.chkAutosaveUseHistorySettings = New DevExpress.XtraEditors.CheckEdit()
        Me.lblHistoryMode = New DevExpress.XtraEditors.LabelControl()
        Me.chkHistory = New DevExpress.XtraEditors.CheckEdit()
        Me.chkAutosave = New DevExpress.XtraEditors.CheckEdit()
        Me.cboHistoryMode = New System.Windows.Forms.ComboBox()
        Me.GroupBox6 = New DevExpress.XtraEditors.GroupControl()
        Me.Label9 = New DevExpress.XtraEditors.LabelControl()
        Me.txtWMSFromOrthoPhotoMaxHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdWMSFromOrthoPhotoBackgroundColor = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPlotNoteTextColor = New DevExpress.XtraEditors.LabelControl()
        Me.picWMSFromOrthoPhotoBackgroundColor = New System.Windows.Forms.PictureBox()
        Me.txtWMSFromOrthoPhotoMaxWidth = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupBox5 = New DevExpress.XtraEditors.GroupControl()
        Me.btnWMSBrowse = New DevExpress.XtraEditors.SimpleButton()
        Me.lblWMSCacheCurrentSizeValue = New DevExpress.XtraEditors.LabelControl()
        Me.lblWMSCacheCurrentSize = New DevExpress.XtraEditors.LabelControl()
        Me.btnWMSClearCache = New DevExpress.XtraEditors.SimpleButton()
        Me.txtWMSCacheMaxSize = New System.Windows.Forms.NumericUpDown()
        Me.lblWMSCacheMaxSize = New DevExpress.XtraEditors.LabelControl()
        Me.chkWMSCacheEnabled = New DevExpress.XtraEditors.CheckEdit()
        Me.cboFunctionLanguage = New System.Windows.Forms.ComboBox()
        Me.lblFunctionLanguage = New DevExpress.XtraEditors.LabelControl()
        Me.txtMachineID = New DevExpress.XtraEditors.TextEdit()
        Me.lblMachineID = New DevExpress.XtraEditors.LabelControl()
        Me.Label4 = New DevExpress.XtraEditors.LabelControl()
        Me.chkCheckNewVersion = New DevExpress.XtraEditors.CheckEdit()
        Me.lblSendExceptionWarning = New DevExpress.XtraEditors.LabelControl()
        Me.chkSendException = New DevExpress.XtraEditors.CheckEdit()
        Me.chkLogVerbose = New DevExpress.XtraEditors.CheckEdit()
        Me.cboDesignSelectionMode = New System.Windows.Forms.ComboBox()
        Me.lblDesignSelectionMode = New DevExpress.XtraEditors.LabelControl()
        Me.chkDesignShowLegacyExtraPrintAndExportObjects = New DevExpress.XtraEditors.CheckEdit()
        Me.txtDesignMetricGridOpacity = New System.Windows.Forms.NumericUpDown()
        Me.lblDesignMetricGridOpacity = New DevExpress.XtraEditors.LabelControl()
        Me.cboDesignShowMetricGrid = New System.Windows.Forms.ComboBox()
        Me.Label6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDefaultFont = New System.Windows.Forms.TextBox()
        Me.cmdDefaultFont = New DevExpress.XtraEditors.SimpleButton()
        Me.lblDefaultFont = New DevExpress.XtraEditors.LabelControl()
        Me.chkDesignUseOnlyAnchorToMove = New DevExpress.XtraEditors.CheckEdit()
        Me.cboDesignZoomType = New System.Windows.Forms.ComboBox()
        Me.lblDesignZoomType = New DevExpress.XtraEditors.LabelControl()
        Me.cboDesignShowRulersStyle = New System.Windows.Forms.ComboBox()
        Me.cboDesignClipBorder = New System.Windows.Forms.ComboBox()
        Me.lblClipping = New DevExpress.XtraEditors.LabelControl()
        Me.cboDesignLineType = New System.Windows.Forms.ComboBox()
        Me.Label27 = New DevExpress.XtraEditors.LabelControl()
        Me.cboDesignQuality = New System.Windows.Forms.ComboBox()
        Me.lblDesignQuality = New DevExpress.XtraEditors.LabelControl()
        Me.chkDesignShowRulers = New DevExpress.XtraEditors.CheckEdit()
        Me.cboDesignMode = New System.Windows.Forms.ComboBox()
        Me.lblDesignMode = New DevExpress.XtraEditors.LabelControl()
        Me.GroupBox7 = New DevExpress.XtraEditors.GroupControl()
        Me.chkShotsGridExportSplayNames = New DevExpress.XtraEditors.CheckEdit()
        Me.GroupBox2 = New DevExpress.XtraEditors.GroupControl()
        Me.chkSVGExportTextAsPath = New DevExpress.XtraEditors.CheckEdit()
        Me.chkSVGExportcSurveyReference = New DevExpress.XtraEditors.CheckEdit()
        Me.chkSVGExportImages = New DevExpress.XtraEditors.CheckEdit()
        Me.lblSVGExportDPI = New DevExpress.XtraEditors.LabelControl()
        Me.txtSVGExportDPI = New System.Windows.Forms.NumericUpDown()
        Me.chkSVGExportNoClipartBrushes = New DevExpress.XtraEditors.CheckEdit()
        Me.chkSVGExportNoClipping = New DevExpress.XtraEditors.CheckEdit()
        Me.lblSVGExportScale = New DevExpress.XtraEditors.LabelControl()
        Me.txtSVGExportScale = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New DevExpress.XtraEditors.GroupControl()
        Me.txtSVGImportPathMaxLen = New System.Windows.Forms.NumericUpDown()
        Me.chkSVGImportAutodivide = New DevExpress.XtraEditors.CheckEdit()
        Me.cboSVGImportLineType = New System.Windows.Forms.ComboBox()
        Me.lblSVGImportScale = New DevExpress.XtraEditors.LabelControl()
        Me.lblSVGImportLineType = New DevExpress.XtraEditors.LabelControl()
        Me.lblPlotSelectedPointSize = New DevExpress.XtraEditors.LabelControl()
        Me.txtSVGImportScale = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox4 = New DevExpress.XtraEditors.GroupControl()
        Me.chkVTopoImportSetAsBranch = New DevExpress.XtraEditors.CheckEdit()
        Me.chkVTopoImportIncompatibleSet = New DevExpress.XtraEditors.CheckEdit()
        Me.chkLinkedSurveysRefreshOnLoad = New DevExpress.XtraEditors.CheckEdit()
        Me.chkLinkedSurveysRecursiveLoadPrioritizeChildren = New DevExpress.XtraEditors.CheckEdit()
        Me.chkLinkedSurveysRecursiveLoad = New DevExpress.XtraEditors.CheckEdit()
        Me.chkLinkedSurveysShowInCaveInfo = New DevExpress.XtraEditors.CheckEdit()
        Me.chkLinkedSurveysSelectOnAdd = New DevExpress.XtraEditors.CheckEdit()
        Me.chkCalculateMode = New DevExpress.XtraEditors.CheckEdit()
        Me.lblDefaultCalculateMode = New DevExpress.XtraEditors.LabelControl()
        Me.cboDefaultCalculateType = New System.Windows.Forms.ComboBox()
        Me.chkAlwaysUseShellForAttchments = New DevExpress.XtraEditors.CheckEdit()
        Me.txtDesignAnchorScale = New System.Windows.Forms.NumericUpDown()
        Me.lblBaseLineWidthScaleFactor = New DevExpress.XtraEditors.LabelControl()
        Me.cboMaxDrawItemCount = New System.Windows.Forms.ComboBox()
        Me.Label5 = New DevExpress.XtraEditors.LabelControl()
        Me.Label1 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupBox3 = New DevExpress.XtraEditors.GroupControl()
        Me.chkClipboardLocalFormat = New DevExpress.XtraEditors.CheckEdit()
        Me.chkClipboardCleanPastedStation = New DevExpress.XtraEditors.CheckEdit()
        Me.lblClipboardFormats = New DevExpress.XtraEditors.LabelControl()
        Me.lvClipboardFormats = New System.Windows.Forms.ListView()
        Me.colClipboardFormat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chkSetDesignToolsEnabledByLevel = New DevExpress.XtraEditors.CheckEdit()
        Me.chkSetDesignToolsHiddenByLevel = New DevExpress.XtraEditors.CheckEdit()
        Me.lblDesignBarPosition = New DevExpress.XtraEditors.LabelControl()
        Me.chkTherionLochEnabled = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdTherionPathBrowse = New DevExpress.XtraEditors.SimpleButton()
        Me.txtTherionPath = New DevExpress.XtraEditors.TextEdit()
        Me.lblTherionPath = New DevExpress.XtraEditors.LabelControl()
        Me.frmTherionAdvancedSettings = New DevExpress.XtraEditors.GroupControl()
        Me.cmdTherionINIDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdTherionINIAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.tvTherionINI = New DevExpress.XtraTreeList.TreeList()
        Me.colTherionIniKey = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colTherionIniValue = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.chkTherionUseCadastralIDInCaveNames = New DevExpress.XtraEditors.CheckEdit()
        Me.chkTherionSegmentForcePath = New DevExpress.XtraEditors.CheckEdit()
        Me.chkTherionSegmentForceDirection = New DevExpress.XtraEditors.CheckEdit()
        Me.chkTherionTrigpointSafename = New DevExpress.XtraEditors.CheckEdit()
        Me.chkTherionBackgroundProcess = New DevExpress.XtraEditors.CheckEdit()
        Me.chkTherionDeleteTempFiles = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdDefaultFolder = New DevExpress.XtraEditors.SimpleButton()
        Me.txtDefaultFolder = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDefaultDesigner = New DevExpress.XtraEditors.MemoEdit()
        Me.lblDefaultDesigner = New DevExpress.XtraEditors.LabelControl()
        Me.txtDefaultTeam = New DevExpress.XtraEditors.MemoEdit()
        Me.lblDefaultTeam = New DevExpress.XtraEditors.LabelControl()
        Me.txtDefaultClub = New DevExpress.XtraEditors.MemoEdit()
        Me.lblDefaultClub = New DevExpress.XtraEditors.LabelControl()
        Me.pnlFooter = New DevExpress.XtraEditors.PanelControl()
        Me.lblSeparator = New DevExpress.XtraEditors.LabelControl()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.AccordionControl1 = New DevExpress.XtraBars.Navigation.AccordionControl()
        Me.btnMain = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement4 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement17 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement18 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement16 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement14 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.btnSurface = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement13 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement7 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement8 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement12 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement10 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement11 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.tabMain = New DevExpress.XtraTab.XtraTabControl()
        Me.tabInfoMain = New DevExpress.XtraTab.XtraTabPage()
        Me.tabInfoTherion = New DevExpress.XtraTab.XtraTabPage()
        Me.tabInfoOptions = New DevExpress.XtraTab.XtraTabPage()
        Me.tabInfoInterface = New DevExpress.XtraTab.XtraTabPage()
        Me.chkITChangePeriodKey = New DevExpress.XtraEditors.CheckEdit()
        Me.chkITChangeDecimalKey = New DevExpress.XtraEditors.CheckEdit()
        Me.cboLanguage = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.tabInfoDesign = New DevExpress.XtraTab.XtraTabPage()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.cboDesignGeoLineType = New System.Windows.Forms.ComboBox()
        Me.flyParameters = New DevExpress.Utils.FlyoutPanel()
        Me.pnlParameters = New DevExpress.Utils.FlyoutPanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.tvDefaultPenPattern = New DevExpress.XtraTreeList.TreeList()
        Me.colDefaultPenPattern = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.txtDefaultPenPattern = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.cboDesignBarPosition = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.tabInfoData = New DevExpress.XtraTab.XtraTabPage()
        Me.tabInfoSVG = New DevExpress.XtraTab.XtraTabPage()
        Me.tabInfoVisualTopo = New DevExpress.XtraTab.XtraTabPage()
        Me.tabInfoLinkedSurveys = New DevExpress.XtraTab.XtraTabPage()
        Me.tabInfoWMS = New DevExpress.XtraTab.XtraTabPage()
        Me.tabInfoHistory = New DevExpress.XtraTab.XtraTabPage()
        Me.tabInfoDebug = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.CheckEdit2 = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.chkEnableMultithreadingPreview = New DevExpress.XtraEditors.CheckEdit()
        Me.chkForceGarbaceCollect = New DevExpress.XtraEditors.CheckEdit()
        Me.lblLogMaxSize = New DevExpress.XtraEditors.LabelControl()
        Me.txtLogMaxLine = New DevExpress.XtraEditors.SpinEdit()
        Me.chkLogOnFile = New DevExpress.XtraEditors.CheckEdit()
        Me.tabHistorySettings.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.chkHistoryArchiveOnSave.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHistoryMaxCopies, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHistoryDailyCopies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.chkHistoryWebArchiveOnSave.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHistoryWebAuthReq.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHistoryWebMaxCopies, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHistoryWebDailyCopies, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAutosaveUseHistorySettings.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHistory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAutosave.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.txtWMSFromOrthoPhotoMaxHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picWMSFromOrthoPhotoBackgroundColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWMSFromOrthoPhotoMaxWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.txtWMSCacheMaxSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkWMSCacheEnabled.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMachineID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCheckNewVersion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSendException.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLogVerbose.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignShowLegacyExtraPrintAndExportObjects.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesignMetricGridOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignUseOnlyAnchorToMove.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignShowRulers.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.chkShotsGridExportSplayNames.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.chkSVGExportTextAsPath.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSVGExportcSurveyReference.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSVGExportImages.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSVGExportDPI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSVGExportNoClipartBrushes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSVGExportNoClipping.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSVGExportScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtSVGImportPathMaxLen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSVGImportAutodivide.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSVGImportScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.chkVTopoImportSetAsBranch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkVTopoImportIncompatibleSet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLinkedSurveysRefreshOnLoad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLinkedSurveysRecursiveLoadPrioritizeChildren.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLinkedSurveysRecursiveLoad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLinkedSurveysShowInCaveInfo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLinkedSurveysSelectOnAdd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCalculateMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAlwaysUseShellForAttchments.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesignAnchorScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.chkClipboardLocalFormat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkClipboardCleanPastedStation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSetDesignToolsEnabledByLevel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSetDesignToolsHiddenByLevel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTherionLochEnabled.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTherionPath.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.frmTherionAdvancedSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmTherionAdvancedSettings.SuspendLayout()
        CType(Me.tvTherionINI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTherionUseCadastralIDInCaveNames.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTherionSegmentForcePath.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTherionSegmentForceDirection.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTherionTrigpointSafename.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTherionBackgroundProcess.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTherionDeleteTempFiles.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDefaultFolder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDefaultDesigner.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDefaultTeam.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDefaultClub.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlFooter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFooter.SuspendLayout()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMain.SuspendLayout()
        Me.tabInfoMain.SuspendLayout()
        Me.tabInfoTherion.SuspendLayout()
        Me.tabInfoOptions.SuspendLayout()
        Me.tabInfoInterface.SuspendLayout()
        CType(Me.chkITChangePeriodKey.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkITChangeDecimalKey.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLanguage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabInfoDesign.SuspendLayout()
        CType(Me.flyParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flyParameters.SuspendLayout()
        CType(Me.pnlParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tvDefaultPenPattern, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDefaultPenPattern, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDesignBarPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabInfoData.SuspendLayout()
        Me.tabInfoSVG.SuspendLayout()
        Me.tabInfoVisualTopo.SuspendLayout()
        Me.tabInfoLinkedSurveys.SuspendLayout()
        Me.tabInfoWMS.SuspendLayout()
        Me.tabInfoHistory.SuspendLayout()
        Me.tabInfoDebug.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.CheckEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkEnableMultithreadingPreview.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkForceGarbaceCollect.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLogMaxLine.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLogOnFile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabHistorySettings
        '
        Me.tabHistorySettings.Controls.Add(Me.TabPage1)
        Me.tabHistorySettings.Controls.Add(Me.TabPage2)
        resources.ApplyResources(Me.tabHistorySettings, "tabHistorySettings")
        Me.tabHistorySettings.Name = "tabHistorySettings"
        Me.tabHistorySettings.SelectedIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chkHistoryArchiveOnSave)
        Me.TabPage1.Controls.Add(Me.lblHistoryMaxCopies)
        Me.TabPage1.Controls.Add(Me.txtHistoryFolder)
        Me.TabPage1.Controls.Add(Me.txtHistoryMaxCopies)
        Me.TabPage1.Controls.Add(Me.lblHistoryFolder)
        Me.TabPage1.Controls.Add(Me.lblHistoryDailyCopies)
        Me.TabPage1.Controls.Add(Me.cmdHistoryFolderBrowse)
        Me.TabPage1.Controls.Add(Me.txtHistoryDailyCopies)
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chkHistoryArchiveOnSave
        '
        resources.ApplyResources(Me.chkHistoryArchiveOnSave, "chkHistoryArchiveOnSave")
        Me.chkHistoryArchiveOnSave.Name = "chkHistoryArchiveOnSave"
        Me.chkHistoryArchiveOnSave.Properties.AutoWidth = True
        Me.chkHistoryArchiveOnSave.Properties.Caption = resources.GetString("chkHistoryArchiveOnSave.Properties.Caption")
        '
        'lblHistoryMaxCopies
        '
        resources.ApplyResources(Me.lblHistoryMaxCopies, "lblHistoryMaxCopies")
        Me.lblHistoryMaxCopies.Name = "lblHistoryMaxCopies"
        '
        'txtHistoryFolder
        '
        resources.ApplyResources(Me.txtHistoryFolder, "txtHistoryFolder")
        Me.txtHistoryFolder.Name = "txtHistoryFolder"
        Me.txtHistoryFolder.ReadOnly = True
        '
        'txtHistoryMaxCopies
        '
        Me.txtHistoryMaxCopies.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        resources.ApplyResources(Me.txtHistoryMaxCopies, "txtHistoryMaxCopies")
        Me.txtHistoryMaxCopies.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtHistoryMaxCopies.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtHistoryMaxCopies.Name = "txtHistoryMaxCopies"
        Me.txtHistoryMaxCopies.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'lblHistoryFolder
        '
        resources.ApplyResources(Me.lblHistoryFolder, "lblHistoryFolder")
        Me.lblHistoryFolder.Name = "lblHistoryFolder"
        '
        'lblHistoryDailyCopies
        '
        resources.ApplyResources(Me.lblHistoryDailyCopies, "lblHistoryDailyCopies")
        Me.lblHistoryDailyCopies.Name = "lblHistoryDailyCopies"
        '
        'cmdHistoryFolderBrowse
        '
        resources.ApplyResources(Me.cmdHistoryFolderBrowse, "cmdHistoryFolderBrowse")
        Me.cmdHistoryFolderBrowse.Name = "cmdHistoryFolderBrowse"
        '
        'txtHistoryDailyCopies
        '
        Me.txtHistoryDailyCopies.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        resources.ApplyResources(Me.txtHistoryDailyCopies, "txtHistoryDailyCopies")
        Me.txtHistoryDailyCopies.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.txtHistoryDailyCopies.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtHistoryDailyCopies.Name = "txtHistoryDailyCopies"
        Me.txtHistoryDailyCopies.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.chkHistoryWebArchiveOnSave)
        Me.TabPage2.Controls.Add(Me.chkHistoryWebAuthReq)
        Me.TabPage2.Controls.Add(Me.lblHistoryWebMaxCopies)
        Me.TabPage2.Controls.Add(Me.txtHistoryWebMaxCopies)
        Me.TabPage2.Controls.Add(Me.lblHistoryWebDailyCopies)
        Me.TabPage2.Controls.Add(Me.txtHistoryWebDailyCopies)
        Me.TabPage2.Controls.Add(Me.cmdHistoryWebCheck)
        Me.TabPage2.Controls.Add(Me.txtHistoryWebURL)
        Me.TabPage2.Controls.Add(Me.lblHistoryWebPassword)
        Me.TabPage2.Controls.Add(Me.lblHistoryWebAddress)
        Me.TabPage2.Controls.Add(Me.txtHistoryWebPassword)
        Me.TabPage2.Controls.Add(Me.txtHistoryWebUsername)
        Me.TabPage2.Controls.Add(Me.lblHistoryWebUsername)
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'chkHistoryWebArchiveOnSave
        '
        resources.ApplyResources(Me.chkHistoryWebArchiveOnSave, "chkHistoryWebArchiveOnSave")
        Me.chkHistoryWebArchiveOnSave.Name = "chkHistoryWebArchiveOnSave"
        Me.chkHistoryWebArchiveOnSave.Properties.Caption = resources.GetString("chkHistoryWebArchiveOnSave.Properties.Caption")
        '
        'chkHistoryWebAuthReq
        '
        resources.ApplyResources(Me.chkHistoryWebAuthReq, "chkHistoryWebAuthReq")
        Me.chkHistoryWebAuthReq.Name = "chkHistoryWebAuthReq"
        Me.chkHistoryWebAuthReq.Properties.Caption = resources.GetString("chkHistoryWebAuthReq.Properties.Caption")
        '
        'lblHistoryWebMaxCopies
        '
        resources.ApplyResources(Me.lblHistoryWebMaxCopies, "lblHistoryWebMaxCopies")
        Me.lblHistoryWebMaxCopies.Name = "lblHistoryWebMaxCopies"
        '
        'txtHistoryWebMaxCopies
        '
        Me.txtHistoryWebMaxCopies.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        resources.ApplyResources(Me.txtHistoryWebMaxCopies, "txtHistoryWebMaxCopies")
        Me.txtHistoryWebMaxCopies.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtHistoryWebMaxCopies.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtHistoryWebMaxCopies.Name = "txtHistoryWebMaxCopies"
        Me.txtHistoryWebMaxCopies.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'lblHistoryWebDailyCopies
        '
        resources.ApplyResources(Me.lblHistoryWebDailyCopies, "lblHistoryWebDailyCopies")
        Me.lblHistoryWebDailyCopies.Name = "lblHistoryWebDailyCopies"
        '
        'txtHistoryWebDailyCopies
        '
        Me.txtHistoryWebDailyCopies.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        resources.ApplyResources(Me.txtHistoryWebDailyCopies, "txtHistoryWebDailyCopies")
        Me.txtHistoryWebDailyCopies.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.txtHistoryWebDailyCopies.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtHistoryWebDailyCopies.Name = "txtHistoryWebDailyCopies"
        Me.txtHistoryWebDailyCopies.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'cmdHistoryWebCheck
        '
        Me.cmdHistoryWebCheck.ImageOptions.Image = Global.cSurveyPC.My.Resources.Resources.world_link
        resources.ApplyResources(Me.cmdHistoryWebCheck, "cmdHistoryWebCheck")
        Me.cmdHistoryWebCheck.Name = "cmdHistoryWebCheck"
        '
        'txtHistoryWebURL
        '
        resources.ApplyResources(Me.txtHistoryWebURL, "txtHistoryWebURL")
        Me.txtHistoryWebURL.Name = "txtHistoryWebURL"
        '
        'lblHistoryWebPassword
        '
        resources.ApplyResources(Me.lblHistoryWebPassword, "lblHistoryWebPassword")
        Me.lblHistoryWebPassword.Name = "lblHistoryWebPassword"
        '
        'lblHistoryWebAddress
        '
        resources.ApplyResources(Me.lblHistoryWebAddress, "lblHistoryWebAddress")
        Me.lblHistoryWebAddress.Name = "lblHistoryWebAddress"
        '
        'txtHistoryWebPassword
        '
        resources.ApplyResources(Me.txtHistoryWebPassword, "txtHistoryWebPassword")
        Me.txtHistoryWebPassword.Name = "txtHistoryWebPassword"
        '
        'txtHistoryWebUsername
        '
        resources.ApplyResources(Me.txtHistoryWebUsername, "txtHistoryWebUsername")
        Me.txtHistoryWebUsername.Name = "txtHistoryWebUsername"
        '
        'lblHistoryWebUsername
        '
        resources.ApplyResources(Me.lblHistoryWebUsername, "lblHistoryWebUsername")
        Me.lblHistoryWebUsername.Name = "lblHistoryWebUsername"
        '
        'chkAutosaveUseHistorySettings
        '
        resources.ApplyResources(Me.chkAutosaveUseHistorySettings, "chkAutosaveUseHistorySettings")
        Me.chkAutosaveUseHistorySettings.Name = "chkAutosaveUseHistorySettings"
        Me.chkAutosaveUseHistorySettings.Properties.AutoWidth = True
        Me.chkAutosaveUseHistorySettings.Properties.Caption = resources.GetString("chkAutosaveUseHistorySettings.Properties.Caption")
        '
        'lblHistoryMode
        '
        resources.ApplyResources(Me.lblHistoryMode, "lblHistoryMode")
        Me.lblHistoryMode.Name = "lblHistoryMode"
        '
        'chkHistory
        '
        resources.ApplyResources(Me.chkHistory, "chkHistory")
        Me.chkHistory.Name = "chkHistory"
        Me.chkHistory.Properties.AutoWidth = True
        Me.chkHistory.Properties.Caption = resources.GetString("chkHistory.Properties.Caption")
        '
        'chkAutosave
        '
        resources.ApplyResources(Me.chkAutosave, "chkAutosave")
        Me.chkAutosave.Name = "chkAutosave"
        Me.chkAutosave.Properties.AutoWidth = True
        Me.chkAutosave.Properties.Caption = resources.GetString("chkAutosave.Properties.Caption")
        '
        'cboHistoryMode
        '
        Me.cboHistoryMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHistoryMode.DropDownWidth = 400
        resources.ApplyResources(Me.cboHistoryMode, "cboHistoryMode")
        Me.cboHistoryMode.FormattingEnabled = True
        Me.cboHistoryMode.Items.AddRange(New Object() {resources.GetString("cboHistoryMode.Items")})
        Me.cboHistoryMode.Name = "cboHistoryMode"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Controls.Add(Me.txtWMSFromOrthoPhotoMaxHeight)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.cmdWMSFromOrthoPhotoBackgroundColor)
        Me.GroupBox6.Controls.Add(Me.lblPlotNoteTextColor)
        Me.GroupBox6.Controls.Add(Me.picWMSFromOrthoPhotoBackgroundColor)
        Me.GroupBox6.Controls.Add(Me.txtWMSFromOrthoPhotoMaxWidth)
        Me.GroupBox6.Controls.Add(Me.Label8)
        resources.ApplyResources(Me.GroupBox6, "GroupBox6")
        Me.GroupBox6.Name = "GroupBox6"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'txtWMSFromOrthoPhotoMaxHeight
        '
        resources.ApplyResources(Me.txtWMSFromOrthoPhotoMaxHeight, "txtWMSFromOrthoPhotoMaxHeight")
        Me.txtWMSFromOrthoPhotoMaxHeight.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtWMSFromOrthoPhotoMaxHeight.Minimum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.txtWMSFromOrthoPhotoMaxHeight.Name = "txtWMSFromOrthoPhotoMaxHeight"
        Me.txtWMSFromOrthoPhotoMaxHeight.Value = New Decimal(New Integer() {4000, 0, 0, 0})
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'cmdWMSFromOrthoPhotoBackgroundColor
        '
        resources.ApplyResources(Me.cmdWMSFromOrthoPhotoBackgroundColor, "cmdWMSFromOrthoPhotoBackgroundColor")
        Me.cmdWMSFromOrthoPhotoBackgroundColor.Name = "cmdWMSFromOrthoPhotoBackgroundColor"
        '
        'lblPlotNoteTextColor
        '
        Me.lblPlotNoteTextColor.Appearance.Font = CType(resources.GetObject("lblPlotNoteTextColor.Appearance.Font"), System.Drawing.Font)
        Me.lblPlotNoteTextColor.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPlotNoteTextColor, "lblPlotNoteTextColor")
        Me.lblPlotNoteTextColor.Name = "lblPlotNoteTextColor"
        '
        'picWMSFromOrthoPhotoBackgroundColor
        '
        resources.ApplyResources(Me.picWMSFromOrthoPhotoBackgroundColor, "picWMSFromOrthoPhotoBackgroundColor")
        Me.picWMSFromOrthoPhotoBackgroundColor.Name = "picWMSFromOrthoPhotoBackgroundColor"
        Me.picWMSFromOrthoPhotoBackgroundColor.TabStop = False
        '
        'txtWMSFromOrthoPhotoMaxWidth
        '
        resources.ApplyResources(Me.txtWMSFromOrthoPhotoMaxWidth, "txtWMSFromOrthoPhotoMaxWidth")
        Me.txtWMSFromOrthoPhotoMaxWidth.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtWMSFromOrthoPhotoMaxWidth.Minimum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.txtWMSFromOrthoPhotoMaxWidth.Name = "txtWMSFromOrthoPhotoMaxWidth"
        Me.txtWMSFromOrthoPhotoMaxWidth.Value = New Decimal(New Integer() {4000, 0, 0, 0})
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnWMSBrowse)
        Me.GroupBox5.Controls.Add(Me.lblWMSCacheCurrentSizeValue)
        Me.GroupBox5.Controls.Add(Me.lblWMSCacheCurrentSize)
        Me.GroupBox5.Controls.Add(Me.btnWMSClearCache)
        Me.GroupBox5.Controls.Add(Me.txtWMSCacheMaxSize)
        Me.GroupBox5.Controls.Add(Me.lblWMSCacheMaxSize)
        Me.GroupBox5.Controls.Add(Me.chkWMSCacheEnabled)
        resources.ApplyResources(Me.GroupBox5, "GroupBox5")
        Me.GroupBox5.Name = "GroupBox5"
        '
        'btnWMSBrowse
        '
        resources.ApplyResources(Me.btnWMSBrowse, "btnWMSBrowse")
        Me.btnWMSBrowse.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnWMSBrowse.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.open
        Me.btnWMSBrowse.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.btnWMSBrowse.Name = "btnWMSBrowse"
        '
        'lblWMSCacheCurrentSizeValue
        '
        resources.ApplyResources(Me.lblWMSCacheCurrentSizeValue, "lblWMSCacheCurrentSizeValue")
        Me.lblWMSCacheCurrentSizeValue.Name = "lblWMSCacheCurrentSizeValue"
        '
        'lblWMSCacheCurrentSize
        '
        resources.ApplyResources(Me.lblWMSCacheCurrentSize, "lblWMSCacheCurrentSize")
        Me.lblWMSCacheCurrentSize.Name = "lblWMSCacheCurrentSize"
        '
        'btnWMSClearCache
        '
        resources.ApplyResources(Me.btnWMSClearCache, "btnWMSClearCache")
        Me.btnWMSClearCache.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnWMSClearCache.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.clearall
        Me.btnWMSClearCache.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.btnWMSClearCache.Name = "btnWMSClearCache"
        '
        'txtWMSCacheMaxSize
        '
        resources.ApplyResources(Me.txtWMSCacheMaxSize, "txtWMSCacheMaxSize")
        Me.txtWMSCacheMaxSize.Maximum = New Decimal(New Integer() {5120, 0, 0, 0})
        Me.txtWMSCacheMaxSize.Minimum = New Decimal(New Integer() {64, 0, 0, 0})
        Me.txtWMSCacheMaxSize.Name = "txtWMSCacheMaxSize"
        Me.txtWMSCacheMaxSize.Value = New Decimal(New Integer() {64, 0, 0, 0})
        '
        'lblWMSCacheMaxSize
        '
        resources.ApplyResources(Me.lblWMSCacheMaxSize, "lblWMSCacheMaxSize")
        Me.lblWMSCacheMaxSize.Name = "lblWMSCacheMaxSize"
        '
        'chkWMSCacheEnabled
        '
        resources.ApplyResources(Me.chkWMSCacheEnabled, "chkWMSCacheEnabled")
        Me.chkWMSCacheEnabled.Name = "chkWMSCacheEnabled"
        Me.chkWMSCacheEnabled.Properties.AutoWidth = True
        Me.chkWMSCacheEnabled.Properties.Caption = resources.GetString("chkWMSCacheEnabled.Properties.Caption")
        '
        'cboFunctionLanguage
        '
        Me.cboFunctionLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFunctionLanguage.FormattingEnabled = True
        Me.cboFunctionLanguage.Items.AddRange(New Object() {resources.GetString("cboFunctionLanguage.Items"), resources.GetString("cboFunctionLanguage.Items1")})
        resources.ApplyResources(Me.cboFunctionLanguage, "cboFunctionLanguage")
        Me.cboFunctionLanguage.Name = "cboFunctionLanguage"
        '
        'lblFunctionLanguage
        '
        resources.ApplyResources(Me.lblFunctionLanguage, "lblFunctionLanguage")
        Me.lblFunctionLanguage.Name = "lblFunctionLanguage"
        '
        'txtMachineID
        '
        resources.ApplyResources(Me.txtMachineID, "txtMachineID")
        Me.txtMachineID.Name = "txtMachineID"
        Me.txtMachineID.Properties.ReadOnly = True
        '
        'lblMachineID
        '
        resources.ApplyResources(Me.lblMachineID, "lblMachineID")
        Me.lblMachineID.Name = "lblMachineID"
        '
        'Label4
        '
        Me.Label4.AllowHtmlString = True
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Appearance.Options.UseTextOptions = True
        Me.Label4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.Label4.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.Label4.Name = "Label4"
        '
        'chkCheckNewVersion
        '
        resources.ApplyResources(Me.chkCheckNewVersion, "chkCheckNewVersion")
        Me.chkCheckNewVersion.Name = "chkCheckNewVersion"
        Me.chkCheckNewVersion.Properties.AutoWidth = True
        Me.chkCheckNewVersion.Properties.Caption = resources.GetString("chkCheckNewVersion.Properties.Caption")
        '
        'lblSendExceptionWarning
        '
        Me.lblSendExceptionWarning.AllowHtmlString = True
        resources.ApplyResources(Me.lblSendExceptionWarning, "lblSendExceptionWarning")
        Me.lblSendExceptionWarning.Appearance.Options.UseTextOptions = True
        Me.lblSendExceptionWarning.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.lblSendExceptionWarning.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lblSendExceptionWarning.Name = "lblSendExceptionWarning"
        '
        'chkSendException
        '
        resources.ApplyResources(Me.chkSendException, "chkSendException")
        Me.chkSendException.Name = "chkSendException"
        Me.chkSendException.Properties.AutoWidth = True
        Me.chkSendException.Properties.Caption = resources.GetString("chkSendException.Properties.Caption")
        '
        'chkLogVerbose
        '
        resources.ApplyResources(Me.chkLogVerbose, "chkLogVerbose")
        Me.chkLogVerbose.Name = "chkLogVerbose"
        Me.chkLogVerbose.Properties.AutoWidth = True
        Me.chkLogVerbose.Properties.Caption = resources.GetString("chkLogVerbose.Properties.Caption")
        '
        'cboDesignSelectionMode
        '
        Me.cboDesignSelectionMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDesignSelectionMode.DropDownWidth = 400
        resources.ApplyResources(Me.cboDesignSelectionMode, "cboDesignSelectionMode")
        Me.cboDesignSelectionMode.Items.AddRange(New Object() {resources.GetString("cboDesignSelectionMode.Items"), resources.GetString("cboDesignSelectionMode.Items1"), resources.GetString("cboDesignSelectionMode.Items2")})
        Me.cboDesignSelectionMode.Name = "cboDesignSelectionMode"
        '
        'lblDesignSelectionMode
        '
        resources.ApplyResources(Me.lblDesignSelectionMode, "lblDesignSelectionMode")
        Me.lblDesignSelectionMode.Name = "lblDesignSelectionMode"
        '
        'chkDesignShowLegacyExtraPrintAndExportObjects
        '
        resources.ApplyResources(Me.chkDesignShowLegacyExtraPrintAndExportObjects, "chkDesignShowLegacyExtraPrintAndExportObjects")
        Me.chkDesignShowLegacyExtraPrintAndExportObjects.Name = "chkDesignShowLegacyExtraPrintAndExportObjects"
        Me.chkDesignShowLegacyExtraPrintAndExportObjects.Properties.AutoWidth = True
        Me.chkDesignShowLegacyExtraPrintAndExportObjects.Properties.Caption = resources.GetString("chkDesignShowLegacyExtraPrintAndExportObjects.Properties.Caption")
        '
        'txtDesignMetricGridOpacity
        '
        resources.ApplyResources(Me.txtDesignMetricGridOpacity, "txtDesignMetricGridOpacity")
        Me.txtDesignMetricGridOpacity.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.txtDesignMetricGridOpacity.Name = "txtDesignMetricGridOpacity"
        '
        'lblDesignMetricGridOpacity
        '
        resources.ApplyResources(Me.lblDesignMetricGridOpacity, "lblDesignMetricGridOpacity")
        Me.lblDesignMetricGridOpacity.Name = "lblDesignMetricGridOpacity"
        '
        'cboDesignShowMetricGrid
        '
        Me.cboDesignShowMetricGrid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDesignShowMetricGrid.DropDownWidth = 320
        resources.ApplyResources(Me.cboDesignShowMetricGrid, "cboDesignShowMetricGrid")
        Me.cboDesignShowMetricGrid.Items.AddRange(New Object() {resources.GetString("cboDesignShowMetricGrid.Items"), resources.GetString("cboDesignShowMetricGrid.Items1"), resources.GetString("cboDesignShowMetricGrid.Items2")})
        Me.cboDesignShowMetricGrid.Name = "cboDesignShowMetricGrid"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'txtDefaultFont
        '
        resources.ApplyResources(Me.txtDefaultFont, "txtDefaultFont")
        Me.txtDefaultFont.Name = "txtDefaultFont"
        Me.txtDefaultFont.ReadOnly = True
        '
        'cmdDefaultFont
        '
        resources.ApplyResources(Me.cmdDefaultFont, "cmdDefaultFont")
        Me.cmdDefaultFont.Name = "cmdDefaultFont"
        '
        'lblDefaultFont
        '
        Me.lblDefaultFont.Appearance.Font = CType(resources.GetObject("lblDefaultFont.Appearance.Font"), System.Drawing.Font)
        Me.lblDefaultFont.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblDefaultFont, "lblDefaultFont")
        Me.lblDefaultFont.Name = "lblDefaultFont"
        '
        'chkDesignUseOnlyAnchorToMove
        '
        resources.ApplyResources(Me.chkDesignUseOnlyAnchorToMove, "chkDesignUseOnlyAnchorToMove")
        Me.chkDesignUseOnlyAnchorToMove.Name = "chkDesignUseOnlyAnchorToMove"
        Me.chkDesignUseOnlyAnchorToMove.Properties.AutoWidth = True
        Me.chkDesignUseOnlyAnchorToMove.Properties.Caption = resources.GetString("chkDesignUseOnlyAnchorToMove.Properties.Caption")
        '
        'cboDesignZoomType
        '
        Me.cboDesignZoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDesignZoomType.DropDownWidth = 400
        resources.ApplyResources(Me.cboDesignZoomType, "cboDesignZoomType")
        Me.cboDesignZoomType.Items.AddRange(New Object() {resources.GetString("cboDesignZoomType.Items"), resources.GetString("cboDesignZoomType.Items1")})
        Me.cboDesignZoomType.Name = "cboDesignZoomType"
        '
        'lblDesignZoomType
        '
        resources.ApplyResources(Me.lblDesignZoomType, "lblDesignZoomType")
        Me.lblDesignZoomType.Name = "lblDesignZoomType"
        '
        'cboDesignShowRulersStyle
        '
        Me.cboDesignShowRulersStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDesignShowRulersStyle.DropDownWidth = 400
        resources.ApplyResources(Me.cboDesignShowRulersStyle, "cboDesignShowRulersStyle")
        Me.cboDesignShowRulersStyle.Items.AddRange(New Object() {resources.GetString("cboDesignShowRulersStyle.Items"), resources.GetString("cboDesignShowRulersStyle.Items1")})
        Me.cboDesignShowRulersStyle.Name = "cboDesignShowRulersStyle"
        '
        'cboDesignClipBorder
        '
        Me.cboDesignClipBorder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDesignClipBorder.DropDownWidth = 400
        resources.ApplyResources(Me.cboDesignClipBorder, "cboDesignClipBorder")
        Me.cboDesignClipBorder.Items.AddRange(New Object() {resources.GetString("cboDesignClipBorder.Items"), resources.GetString("cboDesignClipBorder.Items1"), resources.GetString("cboDesignClipBorder.Items2")})
        Me.cboDesignClipBorder.Name = "cboDesignClipBorder"
        '
        'lblClipping
        '
        resources.ApplyResources(Me.lblClipping, "lblClipping")
        Me.lblClipping.Name = "lblClipping"
        '
        'cboDesignLineType
        '
        Me.cboDesignLineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDesignLineType.DropDownWidth = 400
        Me.cboDesignLineType.FormattingEnabled = True
        Me.cboDesignLineType.Items.AddRange(New Object() {resources.GetString("cboDesignLineType.Items"), resources.GetString("cboDesignLineType.Items1"), resources.GetString("cboDesignLineType.Items2")})
        resources.ApplyResources(Me.cboDesignLineType, "cboDesignLineType")
        Me.cboDesignLineType.Name = "cboDesignLineType"
        '
        'Label27
        '
        resources.ApplyResources(Me.Label27, "Label27")
        Me.Label27.Name = "Label27"
        '
        'cboDesignQuality
        '
        Me.cboDesignQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDesignQuality.DropDownWidth = 400
        Me.cboDesignQuality.FormattingEnabled = True
        Me.cboDesignQuality.Items.AddRange(New Object() {resources.GetString("cboDesignQuality.Items"), resources.GetString("cboDesignQuality.Items1"), resources.GetString("cboDesignQuality.Items2")})
        resources.ApplyResources(Me.cboDesignQuality, "cboDesignQuality")
        Me.cboDesignQuality.Name = "cboDesignQuality"
        '
        'lblDesignQuality
        '
        resources.ApplyResources(Me.lblDesignQuality, "lblDesignQuality")
        Me.lblDesignQuality.Name = "lblDesignQuality"
        '
        'chkDesignShowRulers
        '
        resources.ApplyResources(Me.chkDesignShowRulers, "chkDesignShowRulers")
        Me.chkDesignShowRulers.Name = "chkDesignShowRulers"
        Me.chkDesignShowRulers.Properties.AutoWidth = True
        Me.chkDesignShowRulers.Properties.Caption = resources.GetString("chkDesignShowRulers.Properties.Caption")
        '
        'cboDesignMode
        '
        Me.cboDesignMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDesignMode.DropDownWidth = 400
        resources.ApplyResources(Me.cboDesignMode, "cboDesignMode")
        Me.cboDesignMode.FormattingEnabled = True
        Me.cboDesignMode.Items.AddRange(New Object() {resources.GetString("cboDesignMode.Items"), resources.GetString("cboDesignMode.Items1")})
        Me.cboDesignMode.Name = "cboDesignMode"
        '
        'lblDesignMode
        '
        resources.ApplyResources(Me.lblDesignMode, "lblDesignMode")
        Me.lblDesignMode.Name = "lblDesignMode"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.chkShotsGridExportSplayNames)
        resources.ApplyResources(Me.GroupBox7, "GroupBox7")
        Me.GroupBox7.Name = "GroupBox7"
        '
        'chkShotsGridExportSplayNames
        '
        resources.ApplyResources(Me.chkShotsGridExportSplayNames, "chkShotsGridExportSplayNames")
        Me.chkShotsGridExportSplayNames.Name = "chkShotsGridExportSplayNames"
        Me.chkShotsGridExportSplayNames.Properties.AutoWidth = True
        Me.chkShotsGridExportSplayNames.Properties.Caption = resources.GetString("chkShotsGridExportSplayNames.Properties.Caption")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkSVGExportTextAsPath)
        Me.GroupBox2.Controls.Add(Me.chkSVGExportcSurveyReference)
        Me.GroupBox2.Controls.Add(Me.chkSVGExportImages)
        Me.GroupBox2.Controls.Add(Me.lblSVGExportDPI)
        Me.GroupBox2.Controls.Add(Me.txtSVGExportDPI)
        Me.GroupBox2.Controls.Add(Me.chkSVGExportNoClipartBrushes)
        Me.GroupBox2.Controls.Add(Me.chkSVGExportNoClipping)
        Me.GroupBox2.Controls.Add(Me.lblSVGExportScale)
        Me.GroupBox2.Controls.Add(Me.txtSVGExportScale)
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        '
        'chkSVGExportTextAsPath
        '
        resources.ApplyResources(Me.chkSVGExportTextAsPath, "chkSVGExportTextAsPath")
        Me.chkSVGExportTextAsPath.Name = "chkSVGExportTextAsPath"
        Me.chkSVGExportTextAsPath.Properties.AutoWidth = True
        Me.chkSVGExportTextAsPath.Properties.Caption = resources.GetString("chkSVGExportTextAsPath.Properties.Caption")
        '
        'chkSVGExportcSurveyReference
        '
        resources.ApplyResources(Me.chkSVGExportcSurveyReference, "chkSVGExportcSurveyReference")
        Me.chkSVGExportcSurveyReference.Name = "chkSVGExportcSurveyReference"
        Me.chkSVGExportcSurveyReference.Properties.AutoWidth = True
        Me.chkSVGExportcSurveyReference.Properties.Caption = resources.GetString("chkSVGExportcSurveyReference.Properties.Caption")
        '
        'chkSVGExportImages
        '
        resources.ApplyResources(Me.chkSVGExportImages, "chkSVGExportImages")
        Me.chkSVGExportImages.Name = "chkSVGExportImages"
        Me.chkSVGExportImages.Properties.AutoWidth = True
        Me.chkSVGExportImages.Properties.Caption = resources.GetString("chkSVGExportImages.Properties.Caption")
        '
        'lblSVGExportDPI
        '
        resources.ApplyResources(Me.lblSVGExportDPI, "lblSVGExportDPI")
        Me.lblSVGExportDPI.Name = "lblSVGExportDPI"
        '
        'txtSVGExportDPI
        '
        Me.txtSVGExportDPI.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        resources.ApplyResources(Me.txtSVGExportDPI, "txtSVGExportDPI")
        Me.txtSVGExportDPI.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtSVGExportDPI.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.txtSVGExportDPI.Name = "txtSVGExportDPI"
        Me.txtSVGExportDPI.Value = New Decimal(New Integer() {90, 0, 0, 0})
        '
        'chkSVGExportNoClipartBrushes
        '
        resources.ApplyResources(Me.chkSVGExportNoClipartBrushes, "chkSVGExportNoClipartBrushes")
        Me.chkSVGExportNoClipartBrushes.Name = "chkSVGExportNoClipartBrushes"
        Me.chkSVGExportNoClipartBrushes.Properties.AutoWidth = True
        Me.chkSVGExportNoClipartBrushes.Properties.Caption = resources.GetString("chkSVGExportNoClipartBrushes.Properties.Caption")
        '
        'chkSVGExportNoClipping
        '
        resources.ApplyResources(Me.chkSVGExportNoClipping, "chkSVGExportNoClipping")
        Me.chkSVGExportNoClipping.Name = "chkSVGExportNoClipping"
        Me.chkSVGExportNoClipping.Properties.AutoWidth = True
        Me.chkSVGExportNoClipping.Properties.Caption = resources.GetString("chkSVGExportNoClipping.Properties.Caption")
        '
        'lblSVGExportScale
        '
        resources.ApplyResources(Me.lblSVGExportScale, "lblSVGExportScale")
        Me.lblSVGExportScale.Name = "lblSVGExportScale"
        '
        'txtSVGExportScale
        '
        Me.txtSVGExportScale.DecimalPlaces = 2
        resources.ApplyResources(Me.txtSVGExportScale, "txtSVGExportScale")
        Me.txtSVGExportScale.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtSVGExportScale.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtSVGExportScale.Name = "txtSVGExportScale"
        Me.txtSVGExportScale.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSVGImportPathMaxLen)
        Me.GroupBox1.Controls.Add(Me.chkSVGImportAutodivide)
        Me.GroupBox1.Controls.Add(Me.cboSVGImportLineType)
        Me.GroupBox1.Controls.Add(Me.lblSVGImportScale)
        Me.GroupBox1.Controls.Add(Me.lblSVGImportLineType)
        Me.GroupBox1.Controls.Add(Me.lblPlotSelectedPointSize)
        Me.GroupBox1.Controls.Add(Me.txtSVGImportScale)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        '
        'txtSVGImportPathMaxLen
        '
        Me.txtSVGImportPathMaxLen.Increment = New Decimal(New Integer() {500, 0, 0, 0})
        resources.ApplyResources(Me.txtSVGImportPathMaxLen, "txtSVGImportPathMaxLen")
        Me.txtSVGImportPathMaxLen.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.txtSVGImportPathMaxLen.Name = "txtSVGImportPathMaxLen"
        '
        'chkSVGImportAutodivide
        '
        resources.ApplyResources(Me.chkSVGImportAutodivide, "chkSVGImportAutodivide")
        Me.chkSVGImportAutodivide.Name = "chkSVGImportAutodivide"
        Me.chkSVGImportAutodivide.Properties.AutoWidth = True
        Me.chkSVGImportAutodivide.Properties.Caption = resources.GetString("chkSVGImportAutodivide.Properties.Caption")
        '
        'cboSVGImportLineType
        '
        Me.cboSVGImportLineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSVGImportLineType.DropDownWidth = 400
        Me.cboSVGImportLineType.FormattingEnabled = True
        Me.cboSVGImportLineType.Items.AddRange(New Object() {resources.GetString("cboSVGImportLineType.Items"), resources.GetString("cboSVGImportLineType.Items1"), resources.GetString("cboSVGImportLineType.Items2")})
        resources.ApplyResources(Me.cboSVGImportLineType, "cboSVGImportLineType")
        Me.cboSVGImportLineType.Name = "cboSVGImportLineType"
        '
        'lblSVGImportScale
        '
        resources.ApplyResources(Me.lblSVGImportScale, "lblSVGImportScale")
        Me.lblSVGImportScale.Name = "lblSVGImportScale"
        '
        'lblSVGImportLineType
        '
        resources.ApplyResources(Me.lblSVGImportLineType, "lblSVGImportLineType")
        Me.lblSVGImportLineType.Name = "lblSVGImportLineType"
        '
        'lblPlotSelectedPointSize
        '
        resources.ApplyResources(Me.lblPlotSelectedPointSize, "lblPlotSelectedPointSize")
        Me.lblPlotSelectedPointSize.Name = "lblPlotSelectedPointSize"
        '
        'txtSVGImportScale
        '
        Me.txtSVGImportScale.DecimalPlaces = 2
        Me.txtSVGImportScale.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtSVGImportScale, "txtSVGImportScale")
        Me.txtSVGImportScale.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtSVGImportScale.Name = "txtSVGImportScale"
        Me.txtSVGImportScale.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkVTopoImportSetAsBranch)
        Me.GroupBox4.Controls.Add(Me.chkVTopoImportIncompatibleSet)
        resources.ApplyResources(Me.GroupBox4, "GroupBox4")
        Me.GroupBox4.Name = "GroupBox4"
        '
        'chkVTopoImportSetAsBranch
        '
        resources.ApplyResources(Me.chkVTopoImportSetAsBranch, "chkVTopoImportSetAsBranch")
        Me.chkVTopoImportSetAsBranch.Name = "chkVTopoImportSetAsBranch"
        Me.chkVTopoImportSetAsBranch.Properties.AutoWidth = True
        Me.chkVTopoImportSetAsBranch.Properties.Caption = resources.GetString("chkVTopoImportSetAsBranch.Properties.Caption")
        '
        'chkVTopoImportIncompatibleSet
        '
        resources.ApplyResources(Me.chkVTopoImportIncompatibleSet, "chkVTopoImportIncompatibleSet")
        Me.chkVTopoImportIncompatibleSet.Name = "chkVTopoImportIncompatibleSet"
        Me.chkVTopoImportIncompatibleSet.Properties.AutoWidth = True
        Me.chkVTopoImportIncompatibleSet.Properties.Caption = resources.GetString("chkVTopoImportIncompatibleSet.Properties.Caption")
        '
        'chkLinkedSurveysRefreshOnLoad
        '
        resources.ApplyResources(Me.chkLinkedSurveysRefreshOnLoad, "chkLinkedSurveysRefreshOnLoad")
        Me.chkLinkedSurveysRefreshOnLoad.Name = "chkLinkedSurveysRefreshOnLoad"
        Me.chkLinkedSurveysRefreshOnLoad.Properties.AutoWidth = True
        Me.chkLinkedSurveysRefreshOnLoad.Properties.Caption = resources.GetString("chkLinkedSurveysRefreshOnLoad.Properties.Caption")
        '
        'chkLinkedSurveysRecursiveLoadPrioritizeChildren
        '
        resources.ApplyResources(Me.chkLinkedSurveysRecursiveLoadPrioritizeChildren, "chkLinkedSurveysRecursiveLoadPrioritizeChildren")
        Me.chkLinkedSurveysRecursiveLoadPrioritizeChildren.Name = "chkLinkedSurveysRecursiveLoadPrioritizeChildren"
        Me.chkLinkedSurveysRecursiveLoadPrioritizeChildren.Properties.AutoWidth = True
        Me.chkLinkedSurveysRecursiveLoadPrioritizeChildren.Properties.Caption = resources.GetString("chkLinkedSurveysRecursiveLoadPrioritizeChildren.Properties.Caption")
        '
        'chkLinkedSurveysRecursiveLoad
        '
        resources.ApplyResources(Me.chkLinkedSurveysRecursiveLoad, "chkLinkedSurveysRecursiveLoad")
        Me.chkLinkedSurveysRecursiveLoad.Name = "chkLinkedSurveysRecursiveLoad"
        Me.chkLinkedSurveysRecursiveLoad.Properties.AutoWidth = True
        Me.chkLinkedSurveysRecursiveLoad.Properties.Caption = resources.GetString("chkLinkedSurveysRecursiveLoad.Properties.Caption")
        '
        'chkLinkedSurveysShowInCaveInfo
        '
        resources.ApplyResources(Me.chkLinkedSurveysShowInCaveInfo, "chkLinkedSurveysShowInCaveInfo")
        Me.chkLinkedSurveysShowInCaveInfo.Name = "chkLinkedSurveysShowInCaveInfo"
        Me.chkLinkedSurveysShowInCaveInfo.Properties.AutoWidth = True
        Me.chkLinkedSurveysShowInCaveInfo.Properties.Caption = resources.GetString("chkLinkedSurveysShowInCaveInfo.Properties.Caption")
        '
        'chkLinkedSurveysSelectOnAdd
        '
        resources.ApplyResources(Me.chkLinkedSurveysSelectOnAdd, "chkLinkedSurveysSelectOnAdd")
        Me.chkLinkedSurveysSelectOnAdd.Name = "chkLinkedSurveysSelectOnAdd"
        Me.chkLinkedSurveysSelectOnAdd.Properties.AutoWidth = True
        Me.chkLinkedSurveysSelectOnAdd.Properties.Caption = resources.GetString("chkLinkedSurveysSelectOnAdd.Properties.Caption")
        '
        'chkCalculateMode
        '
        resources.ApplyResources(Me.chkCalculateMode, "chkCalculateMode")
        Me.chkCalculateMode.Name = "chkCalculateMode"
        Me.chkCalculateMode.Properties.AutoWidth = True
        Me.chkCalculateMode.Properties.Caption = resources.GetString("chkCalculateMode.Properties.Caption")
        '
        'lblDefaultCalculateMode
        '
        resources.ApplyResources(Me.lblDefaultCalculateMode, "lblDefaultCalculateMode")
        Me.lblDefaultCalculateMode.Name = "lblDefaultCalculateMode"
        '
        'cboDefaultCalculateType
        '
        Me.cboDefaultCalculateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboDefaultCalculateType, "cboDefaultCalculateType")
        Me.cboDefaultCalculateType.FormattingEnabled = True
        Me.cboDefaultCalculateType.Items.AddRange(New Object() {resources.GetString("cboDefaultCalculateType.Items"), resources.GetString("cboDefaultCalculateType.Items1"), resources.GetString("cboDefaultCalculateType.Items2")})
        Me.cboDefaultCalculateType.Name = "cboDefaultCalculateType"
        '
        'chkAlwaysUseShellForAttchments
        '
        resources.ApplyResources(Me.chkAlwaysUseShellForAttchments, "chkAlwaysUseShellForAttchments")
        Me.chkAlwaysUseShellForAttchments.Name = "chkAlwaysUseShellForAttchments"
        Me.chkAlwaysUseShellForAttchments.Properties.AutoWidth = True
        Me.chkAlwaysUseShellForAttchments.Properties.Caption = resources.GetString("chkAlwaysUseShellForAttchments.Properties.Caption")
        '
        'txtDesignAnchorScale
        '
        Me.txtDesignAnchorScale.DecimalPlaces = 2
        Me.txtDesignAnchorScale.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtDesignAnchorScale, "txtDesignAnchorScale")
        Me.txtDesignAnchorScale.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.txtDesignAnchorScale.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtDesignAnchorScale.Name = "txtDesignAnchorScale"
        Me.txtDesignAnchorScale.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblBaseLineWidthScaleFactor
        '
        resources.ApplyResources(Me.lblBaseLineWidthScaleFactor, "lblBaseLineWidthScaleFactor")
        Me.lblBaseLineWidthScaleFactor.Name = "lblBaseLineWidthScaleFactor"
        '
        'cboMaxDrawItemCount
        '
        Me.cboMaxDrawItemCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaxDrawItemCount.DropDownWidth = 200
        Me.cboMaxDrawItemCount.Items.AddRange(New Object() {resources.GetString("cboMaxDrawItemCount.Items"), resources.GetString("cboMaxDrawItemCount.Items1"), resources.GetString("cboMaxDrawItemCount.Items2"), resources.GetString("cboMaxDrawItemCount.Items3")})
        resources.ApplyResources(Me.cboMaxDrawItemCount, "cboMaxDrawItemCount")
        Me.cboMaxDrawItemCount.Name = "cboMaxDrawItemCount"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkClipboardLocalFormat)
        Me.GroupBox3.Controls.Add(Me.chkClipboardCleanPastedStation)
        Me.GroupBox3.Controls.Add(Me.lblClipboardFormats)
        Me.GroupBox3.Controls.Add(Me.lvClipboardFormats)
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Name = "GroupBox3"
        '
        'chkClipboardLocalFormat
        '
        resources.ApplyResources(Me.chkClipboardLocalFormat, "chkClipboardLocalFormat")
        Me.chkClipboardLocalFormat.Name = "chkClipboardLocalFormat"
        Me.chkClipboardLocalFormat.Properties.AutoWidth = True
        Me.chkClipboardLocalFormat.Properties.Caption = resources.GetString("chkClipboardLocalFormat.Properties.Caption")
        '
        'chkClipboardCleanPastedStation
        '
        resources.ApplyResources(Me.chkClipboardCleanPastedStation, "chkClipboardCleanPastedStation")
        Me.chkClipboardCleanPastedStation.Name = "chkClipboardCleanPastedStation"
        Me.chkClipboardCleanPastedStation.Properties.AutoWidth = True
        Me.chkClipboardCleanPastedStation.Properties.Caption = resources.GetString("chkClipboardCleanPastedStation.Properties.Caption")
        '
        'lblClipboardFormats
        '
        resources.ApplyResources(Me.lblClipboardFormats, "lblClipboardFormats")
        Me.lblClipboardFormats.Name = "lblClipboardFormats"
        '
        'lvClipboardFormats
        '
        Me.lvClipboardFormats.CheckBoxes = True
        Me.lvClipboardFormats.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colClipboardFormat})
        Me.lvClipboardFormats.FullRowSelect = True
        Me.lvClipboardFormats.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvClipboardFormats.HideSelection = False
        resources.ApplyResources(Me.lvClipboardFormats, "lvClipboardFormats")
        Me.lvClipboardFormats.Name = "lvClipboardFormats"
        Me.lvClipboardFormats.ShowItemToolTips = True
        Me.lvClipboardFormats.UseCompatibleStateImageBehavior = False
        Me.lvClipboardFormats.View = System.Windows.Forms.View.Details
        '
        'colClipboardFormat
        '
        resources.ApplyResources(Me.colClipboardFormat, "colClipboardFormat")
        '
        'chkSetDesignToolsEnabledByLevel
        '
        resources.ApplyResources(Me.chkSetDesignToolsEnabledByLevel, "chkSetDesignToolsEnabledByLevel")
        Me.chkSetDesignToolsEnabledByLevel.Name = "chkSetDesignToolsEnabledByLevel"
        Me.chkSetDesignToolsEnabledByLevel.Properties.AutoWidth = True
        Me.chkSetDesignToolsEnabledByLevel.Properties.Caption = resources.GetString("chkSetDesignToolsEnabledByLevel.Properties.Caption")
        '
        'chkSetDesignToolsHiddenByLevel
        '
        resources.ApplyResources(Me.chkSetDesignToolsHiddenByLevel, "chkSetDesignToolsHiddenByLevel")
        Me.chkSetDesignToolsHiddenByLevel.Name = "chkSetDesignToolsHiddenByLevel"
        Me.chkSetDesignToolsHiddenByLevel.Properties.AutoWidth = True
        Me.chkSetDesignToolsHiddenByLevel.Properties.Caption = resources.GetString("chkSetDesignToolsHiddenByLevel.Properties.Caption")
        '
        'lblDesignBarPosition
        '
        resources.ApplyResources(Me.lblDesignBarPosition, "lblDesignBarPosition")
        Me.lblDesignBarPosition.Name = "lblDesignBarPosition"
        '
        'chkTherionLochEnabled
        '
        resources.ApplyResources(Me.chkTherionLochEnabled, "chkTherionLochEnabled")
        Me.chkTherionLochEnabled.Name = "chkTherionLochEnabled"
        Me.chkTherionLochEnabled.Properties.AutoWidth = True
        Me.chkTherionLochEnabled.Properties.Caption = resources.GetString("chkTherionLochEnabled.Properties.Caption")
        '
        'cmdTherionPathBrowse
        '
        Me.cmdTherionPathBrowse.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdTherionPathBrowse.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.open
        Me.cmdTherionPathBrowse.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdTherionPathBrowse, "cmdTherionPathBrowse")
        Me.cmdTherionPathBrowse.Name = "cmdTherionPathBrowse"
        '
        'txtTherionPath
        '
        resources.ApplyResources(Me.txtTherionPath, "txtTherionPath")
        Me.txtTherionPath.Name = "txtTherionPath"
        '
        'lblTherionPath
        '
        resources.ApplyResources(Me.lblTherionPath, "lblTherionPath")
        Me.lblTherionPath.Name = "lblTherionPath"
        '
        'frmTherionAdvancedSettings
        '
        resources.ApplyResources(Me.frmTherionAdvancedSettings, "frmTherionAdvancedSettings")
        Me.frmTherionAdvancedSettings.Controls.Add(Me.cmdTherionINIDelete)
        Me.frmTherionAdvancedSettings.Controls.Add(Me.cmdTherionINIAdd)
        Me.frmTherionAdvancedSettings.Controls.Add(Me.LabelControl3)
        Me.frmTherionAdvancedSettings.Controls.Add(Me.tvTherionINI)
        Me.frmTherionAdvancedSettings.Controls.Add(Me.chkTherionUseCadastralIDInCaveNames)
        Me.frmTherionAdvancedSettings.Controls.Add(Me.chkTherionSegmentForcePath)
        Me.frmTherionAdvancedSettings.Controls.Add(Me.chkTherionSegmentForceDirection)
        Me.frmTherionAdvancedSettings.Controls.Add(Me.chkTherionTrigpointSafename)
        Me.frmTherionAdvancedSettings.Controls.Add(Me.chkTherionBackgroundProcess)
        Me.frmTherionAdvancedSettings.Controls.Add(Me.chkTherionDeleteTempFiles)
        Me.frmTherionAdvancedSettings.Name = "frmTherionAdvancedSettings"
        '
        'cmdTherionINIDelete
        '
        resources.ApplyResources(Me.cmdTherionINIDelete, "cmdTherionINIDelete")
        Me.cmdTherionINIDelete.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdTherionINIDelete.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.delete1
        Me.cmdTherionINIDelete.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdTherionINIDelete.Name = "cmdTherionINIDelete"
        '
        'cmdTherionINIAdd
        '
        resources.ApplyResources(Me.cmdTherionINIAdd, "cmdTherionINIAdd")
        Me.cmdTherionINIAdd.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdTherionINIAdd.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_add
        Me.cmdTherionINIAdd.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdTherionINIAdd.Name = "cmdTherionINIAdd"
        '
        'LabelControl3
        '
        resources.ApplyResources(Me.LabelControl3, "LabelControl3")
        Me.LabelControl3.Name = "LabelControl3"
        '
        'tvTherionINI
        '
        resources.ApplyResources(Me.tvTherionINI, "tvTherionINI")
        Me.tvTherionINI.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colTherionIniKey, Me.colTherionIniValue})
        Me.tvTherionINI.Name = "tvTherionINI"
        Me.tvTherionINI.OptionsView.ShowIndicator = False
        Me.tvTherionINI.OptionsView.ShowRoot = False
        '
        'colTherionIniKey
        '
        resources.ApplyResources(Me.colTherionIniKey, "colTherionIniKey")
        Me.colTherionIniKey.FieldName = "Key"
        Me.colTherionIniKey.Name = "colTherionIniKey"
        '
        'colTherionIniValue
        '
        resources.ApplyResources(Me.colTherionIniValue, "colTherionIniValue")
        Me.colTherionIniValue.FieldName = "Value"
        Me.colTherionIniValue.Name = "colTherionIniValue"
        '
        'chkTherionUseCadastralIDInCaveNames
        '
        resources.ApplyResources(Me.chkTherionUseCadastralIDInCaveNames, "chkTherionUseCadastralIDInCaveNames")
        Me.chkTherionUseCadastralIDInCaveNames.Name = "chkTherionUseCadastralIDInCaveNames"
        Me.chkTherionUseCadastralIDInCaveNames.Properties.AutoWidth = True
        Me.chkTherionUseCadastralIDInCaveNames.Properties.Caption = resources.GetString("chkTherionUseCadastralIDInCaveNames.Properties.Caption")
        '
        'chkTherionSegmentForcePath
        '
        resources.ApplyResources(Me.chkTherionSegmentForcePath, "chkTherionSegmentForcePath")
        Me.chkTherionSegmentForcePath.Name = "chkTherionSegmentForcePath"
        Me.chkTherionSegmentForcePath.Properties.AutoWidth = True
        Me.chkTherionSegmentForcePath.Properties.Caption = resources.GetString("chkTherionSegmentForcePath.Properties.Caption")
        '
        'chkTherionSegmentForceDirection
        '
        resources.ApplyResources(Me.chkTherionSegmentForceDirection, "chkTherionSegmentForceDirection")
        Me.chkTherionSegmentForceDirection.Name = "chkTherionSegmentForceDirection"
        Me.chkTherionSegmentForceDirection.Properties.AutoWidth = True
        Me.chkTherionSegmentForceDirection.Properties.Caption = resources.GetString("chkTherionSegmentForceDirection.Properties.Caption")
        '
        'chkTherionTrigpointSafename
        '
        resources.ApplyResources(Me.chkTherionTrigpointSafename, "chkTherionTrigpointSafename")
        Me.chkTherionTrigpointSafename.Name = "chkTherionTrigpointSafename"
        Me.chkTherionTrigpointSafename.Properties.AutoWidth = True
        Me.chkTherionTrigpointSafename.Properties.Caption = resources.GetString("chkTherionTrigpointSafename.Properties.Caption")
        '
        'chkTherionBackgroundProcess
        '
        resources.ApplyResources(Me.chkTherionBackgroundProcess, "chkTherionBackgroundProcess")
        Me.chkTherionBackgroundProcess.Name = "chkTherionBackgroundProcess"
        Me.chkTherionBackgroundProcess.Properties.AutoWidth = True
        Me.chkTherionBackgroundProcess.Properties.Caption = resources.GetString("chkTherionBackgroundProcess.Properties.Caption")
        '
        'chkTherionDeleteTempFiles
        '
        resources.ApplyResources(Me.chkTherionDeleteTempFiles, "chkTherionDeleteTempFiles")
        Me.chkTherionDeleteTempFiles.Name = "chkTherionDeleteTempFiles"
        Me.chkTherionDeleteTempFiles.Properties.AutoWidth = True
        Me.chkTherionDeleteTempFiles.Properties.Caption = resources.GetString("chkTherionDeleteTempFiles.Properties.Caption")
        '
        'cmdDefaultFolder
        '
        resources.ApplyResources(Me.cmdDefaultFolder, "cmdDefaultFolder")
        Me.cmdDefaultFolder.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdDefaultFolder.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.open
        Me.cmdDefaultFolder.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdDefaultFolder.Name = "cmdDefaultFolder"
        '
        'txtDefaultFolder
        '
        resources.ApplyResources(Me.txtDefaultFolder, "txtDefaultFolder")
        Me.txtDefaultFolder.Name = "txtDefaultFolder"
        Me.txtDefaultFolder.Properties.ReadOnly = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'txtDefaultDesigner
        '
        resources.ApplyResources(Me.txtDefaultDesigner, "txtDefaultDesigner")
        Me.txtDefaultDesigner.Name = "txtDefaultDesigner"
        '
        'lblDefaultDesigner
        '
        resources.ApplyResources(Me.lblDefaultDesigner, "lblDefaultDesigner")
        Me.lblDefaultDesigner.Name = "lblDefaultDesigner"
        '
        'txtDefaultTeam
        '
        resources.ApplyResources(Me.txtDefaultTeam, "txtDefaultTeam")
        Me.txtDefaultTeam.Name = "txtDefaultTeam"
        '
        'lblDefaultTeam
        '
        resources.ApplyResources(Me.lblDefaultTeam, "lblDefaultTeam")
        Me.lblDefaultTeam.Name = "lblDefaultTeam"
        '
        'txtDefaultClub
        '
        resources.ApplyResources(Me.txtDefaultClub, "txtDefaultClub")
        Me.txtDefaultClub.Name = "txtDefaultClub"
        '
        'lblDefaultClub
        '
        resources.ApplyResources(Me.lblDefaultClub, "lblDefaultClub")
        Me.lblDefaultClub.Name = "lblDefaultClub"
        '
        'pnlFooter
        '
        Me.pnlFooter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlFooter.Controls.Add(Me.lblSeparator)
        Me.pnlFooter.Controls.Add(Me.cmdCancel)
        Me.pnlFooter.Controls.Add(Me.cmdOk)
        resources.ApplyResources(Me.pnlFooter, "pnlFooter")
        Me.pnlFooter.Name = "pnlFooter"
        '
        'lblSeparator
        '
        resources.ApplyResources(Me.lblSeparator, "lblSeparator")
        Me.lblSeparator.LineLocation = DevExpress.XtraEditors.LineLocation.Center
        Me.lblSeparator.LineVisible = True
        Me.lblSeparator.Name = "lblSeparator"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'AccordionControl1
        '
        Me.AccordionControl1.AllowItemSelection = True
        Me.AccordionControl1.AnimationType = DevExpress.XtraBars.Navigation.AnimationType.None
        resources.ApplyResources(Me.AccordionControl1, "AccordionControl1")
        Me.AccordionControl1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.btnMain})
        Me.AccordionControl1.Name = "AccordionControl1"
        Me.AccordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch
        Me.AccordionControl1.ShowFilterControl = DevExpress.XtraBars.Navigation.ShowFilterControl.[Auto]
        Me.AccordionControl1.ShowGroupExpandButtons = False
        Me.AccordionControl1.ShowItemExpandButtons = False
        '
        'btnMain
        '
        Me.btnMain.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.AccordionControlElement4, Me.AccordionControlElement17, Me.AccordionControlElement18, Me.AccordionControlElement16, Me.AccordionControlElement14, Me.btnSurface, Me.AccordionControlElement13, Me.AccordionControlElement7, Me.AccordionControlElement8, Me.AccordionControlElement12, Me.AccordionControlElement10, Me.AccordionControlElement11})
        Me.btnMain.Expanded = True
        Me.btnMain.HeaderVisible = False
        Me.btnMain.Name = "btnMain"
        resources.ApplyResources(Me.btnMain, "btnMain")
        '
        'AccordionControlElement4
        '
        Me.AccordionControlElement4.Name = "AccordionControlElement4"
        Me.AccordionControlElement4.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement4.Tag = "tabInfoMain"
        resources.ApplyResources(Me.AccordionControlElement4, "AccordionControlElement4")
        '
        'AccordionControlElement17
        '
        Me.AccordionControlElement17.Name = "AccordionControlElement17"
        Me.AccordionControlElement17.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement17.Tag = "tabInfoOptions"
        resources.ApplyResources(Me.AccordionControlElement17, "AccordionControlElement17")
        '
        'AccordionControlElement18
        '
        Me.AccordionControlElement18.Name = "AccordionControlElement18"
        Me.AccordionControlElement18.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement18.Tag = "tabInfoTherion"
        resources.ApplyResources(Me.AccordionControlElement18, "AccordionControlElement18")
        '
        'AccordionControlElement16
        '
        Me.AccordionControlElement16.Name = "AccordionControlElement16"
        Me.AccordionControlElement16.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement16.Tag = "tabInfoInterface"
        resources.ApplyResources(Me.AccordionControlElement16, "AccordionControlElement16")
        '
        'AccordionControlElement14
        '
        Me.AccordionControlElement14.Name = "AccordionControlElement14"
        Me.AccordionControlElement14.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement14.Tag = "tabInfoDesign"
        resources.ApplyResources(Me.AccordionControlElement14, "AccordionControlElement14")
        '
        'btnSurface
        '
        Me.btnSurface.Name = "btnSurface"
        Me.btnSurface.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.btnSurface.Tag = "tabInfoData"
        resources.ApplyResources(Me.btnSurface, "btnSurface")
        '
        'AccordionControlElement13
        '
        Me.AccordionControlElement13.Name = "AccordionControlElement13"
        Me.AccordionControlElement13.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement13.Tag = "tabInfoSVG"
        resources.ApplyResources(Me.AccordionControlElement13, "AccordionControlElement13")
        '
        'AccordionControlElement7
        '
        Me.AccordionControlElement7.Name = "AccordionControlElement7"
        Me.AccordionControlElement7.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement7.Tag = "tabInfoVisualTopo"
        resources.ApplyResources(Me.AccordionControlElement7, "AccordionControlElement7")
        '
        'AccordionControlElement8
        '
        Me.AccordionControlElement8.Name = "AccordionControlElement8"
        Me.AccordionControlElement8.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement8.Tag = "tabInfoLinkedSurveys"
        resources.ApplyResources(Me.AccordionControlElement8, "AccordionControlElement8")
        '
        'AccordionControlElement12
        '
        Me.AccordionControlElement12.Name = "AccordionControlElement12"
        Me.AccordionControlElement12.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement12.Tag = "tabInfoWMS"
        resources.ApplyResources(Me.AccordionControlElement12, "AccordionControlElement12")
        '
        'AccordionControlElement10
        '
        Me.AccordionControlElement10.Name = "AccordionControlElement10"
        Me.AccordionControlElement10.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement10.Tag = "tabInfoHistory"
        resources.ApplyResources(Me.AccordionControlElement10, "AccordionControlElement10")
        '
        'AccordionControlElement11
        '
        Me.AccordionControlElement11.Name = "AccordionControlElement11"
        Me.AccordionControlElement11.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement11.Tag = "tabInfoDebug"
        resources.ApplyResources(Me.AccordionControlElement11, "AccordionControlElement11")
        '
        'tabMain
        '
        resources.ApplyResources(Me.tabMain, "tabMain")
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedTabPage = Me.tabInfoMain
        Me.tabMain.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabInfoMain, Me.tabInfoTherion, Me.tabInfoOptions, Me.tabInfoInterface, Me.tabInfoDesign, Me.tabInfoData, Me.tabInfoSVG, Me.tabInfoVisualTopo, Me.tabInfoLinkedSurveys, Me.tabInfoWMS, Me.tabInfoHistory, Me.tabInfoDebug})
        '
        'tabInfoMain
        '
        Me.tabInfoMain.Controls.Add(Me.cmdDefaultFolder)
        Me.tabInfoMain.Controls.Add(Me.txtDefaultClub)
        Me.tabInfoMain.Controls.Add(Me.txtDefaultFolder)
        Me.tabInfoMain.Controls.Add(Me.lblDefaultClub)
        Me.tabInfoMain.Controls.Add(Me.Label3)
        Me.tabInfoMain.Controls.Add(Me.lblDefaultTeam)
        Me.tabInfoMain.Controls.Add(Me.txtDefaultDesigner)
        Me.tabInfoMain.Controls.Add(Me.txtDefaultTeam)
        Me.tabInfoMain.Controls.Add(Me.lblDefaultDesigner)
        Me.tabInfoMain.Name = "tabInfoMain"
        resources.ApplyResources(Me.tabInfoMain, "tabInfoMain")
        '
        'tabInfoTherion
        '
        Me.tabInfoTherion.Controls.Add(Me.frmTherionAdvancedSettings)
        Me.tabInfoTherion.Controls.Add(Me.chkTherionLochEnabled)
        Me.tabInfoTherion.Controls.Add(Me.txtTherionPath)
        Me.tabInfoTherion.Controls.Add(Me.cmdTherionPathBrowse)
        Me.tabInfoTherion.Controls.Add(Me.lblTherionPath)
        Me.tabInfoTherion.Name = "tabInfoTherion"
        resources.ApplyResources(Me.tabInfoTherion, "tabInfoTherion")
        '
        'tabInfoOptions
        '
        Me.tabInfoOptions.Controls.Add(Me.chkCalculateMode)
        Me.tabInfoOptions.Controls.Add(Me.cboDefaultCalculateType)
        Me.tabInfoOptions.Controls.Add(Me.lblDefaultCalculateMode)
        Me.tabInfoOptions.Name = "tabInfoOptions"
        resources.ApplyResources(Me.tabInfoOptions, "tabInfoOptions")
        '
        'tabInfoInterface
        '
        Me.tabInfoInterface.Controls.Add(Me.chkITChangePeriodKey)
        Me.tabInfoInterface.Controls.Add(Me.chkITChangeDecimalKey)
        Me.tabInfoInterface.Controls.Add(Me.cboLanguage)
        Me.tabInfoInterface.Controls.Add(Me.GroupBox3)
        Me.tabInfoInterface.Controls.Add(Me.chkAlwaysUseShellForAttchments)
        Me.tabInfoInterface.Controls.Add(Me.Label1)
        Me.tabInfoInterface.Name = "tabInfoInterface"
        resources.ApplyResources(Me.tabInfoInterface, "tabInfoInterface")
        '
        'chkITChangePeriodKey
        '
        resources.ApplyResources(Me.chkITChangePeriodKey, "chkITChangePeriodKey")
        Me.chkITChangePeriodKey.Name = "chkITChangePeriodKey"
        Me.chkITChangePeriodKey.Properties.AutoWidth = True
        Me.chkITChangePeriodKey.Properties.Caption = resources.GetString("chkITChangePeriodKey.Properties.Caption")
        '
        'chkITChangeDecimalKey
        '
        resources.ApplyResources(Me.chkITChangeDecimalKey, "chkITChangeDecimalKey")
        Me.chkITChangeDecimalKey.Name = "chkITChangeDecimalKey"
        Me.chkITChangeDecimalKey.Properties.AutoWidth = True
        Me.chkITChangeDecimalKey.Properties.Caption = resources.GetString("chkITChangeDecimalKey.Properties.Caption")
        '
        'cboLanguage
        '
        resources.ApplyResources(Me.cboLanguage, "cboLanguage")
        Me.cboLanguage.Name = "cboLanguage"
        Me.cboLanguage.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboLanguage.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboLanguage.Properties.Items.AddRange(New Object() {resources.GetString("cboLanguage.Properties.Items"), resources.GetString("cboLanguage.Properties.Items1"), resources.GetString("cboLanguage.Properties.Items2"), resources.GetString("cboLanguage.Properties.Items3")})
        Me.cboLanguage.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'tabInfoDesign
        '
        resources.ApplyResources(Me.tabInfoDesign, "tabInfoDesign")
        Me.tabInfoDesign.Controls.Add(Me.LabelControl2)
        Me.tabInfoDesign.Controls.Add(Me.cboDesignGeoLineType)
        Me.tabInfoDesign.Controls.Add(Me.flyParameters)
        Me.tabInfoDesign.Controls.Add(Me.LabelControl1)
        Me.tabInfoDesign.Controls.Add(Me.tvDefaultPenPattern)
        Me.tabInfoDesign.Controls.Add(Me.cboDesignSelectionMode)
        Me.tabInfoDesign.Controls.Add(Me.cboDesignMode)
        Me.tabInfoDesign.Controls.Add(Me.lblDesignSelectionMode)
        Me.tabInfoDesign.Controls.Add(Me.Label5)
        Me.tabInfoDesign.Controls.Add(Me.cboMaxDrawItemCount)
        Me.tabInfoDesign.Controls.Add(Me.cboDesignBarPosition)
        Me.tabInfoDesign.Controls.Add(Me.chkSetDesignToolsHiddenByLevel)
        Me.tabInfoDesign.Controls.Add(Me.lblDesignBarPosition)
        Me.tabInfoDesign.Controls.Add(Me.chkSetDesignToolsEnabledByLevel)
        Me.tabInfoDesign.Controls.Add(Me.lblBaseLineWidthScaleFactor)
        Me.tabInfoDesign.Controls.Add(Me.txtDesignAnchorScale)
        Me.tabInfoDesign.Controls.Add(Me.lblDesignMode)
        Me.tabInfoDesign.Controls.Add(Me.chkDesignShowLegacyExtraPrintAndExportObjects)
        Me.tabInfoDesign.Controls.Add(Me.chkDesignShowRulers)
        Me.tabInfoDesign.Controls.Add(Me.txtDesignMetricGridOpacity)
        Me.tabInfoDesign.Controls.Add(Me.lblDesignQuality)
        Me.tabInfoDesign.Controls.Add(Me.lblDesignMetricGridOpacity)
        Me.tabInfoDesign.Controls.Add(Me.cboDesignQuality)
        Me.tabInfoDesign.Controls.Add(Me.cboDesignShowMetricGrid)
        Me.tabInfoDesign.Controls.Add(Me.Label27)
        Me.tabInfoDesign.Controls.Add(Me.Label6)
        Me.tabInfoDesign.Controls.Add(Me.cboDesignLineType)
        Me.tabInfoDesign.Controls.Add(Me.txtDefaultFont)
        Me.tabInfoDesign.Controls.Add(Me.lblClipping)
        Me.tabInfoDesign.Controls.Add(Me.cmdDefaultFont)
        Me.tabInfoDesign.Controls.Add(Me.cboDesignClipBorder)
        Me.tabInfoDesign.Controls.Add(Me.lblDefaultFont)
        Me.tabInfoDesign.Controls.Add(Me.cboDesignShowRulersStyle)
        Me.tabInfoDesign.Controls.Add(Me.chkDesignUseOnlyAnchorToMove)
        Me.tabInfoDesign.Controls.Add(Me.lblDesignZoomType)
        Me.tabInfoDesign.Controls.Add(Me.cboDesignZoomType)
        Me.tabInfoDesign.Name = "tabInfoDesign"
        '
        'LabelControl2
        '
        resources.ApplyResources(Me.LabelControl2, "LabelControl2")
        Me.LabelControl2.Name = "LabelControl2"
        '
        'cboDesignGeoLineType
        '
        Me.cboDesignGeoLineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDesignGeoLineType.DropDownWidth = 400
        Me.cboDesignGeoLineType.FormattingEnabled = True
        Me.cboDesignGeoLineType.Items.AddRange(New Object() {resources.GetString("cboDesignGeoLineType.Items"), resources.GetString("cboDesignGeoLineType.Items1"), resources.GetString("cboDesignGeoLineType.Items2")})
        resources.ApplyResources(Me.cboDesignGeoLineType, "cboDesignGeoLineType")
        Me.cboDesignGeoLineType.Name = "cboDesignGeoLineType"
        '
        'flyParameters
        '
        Me.flyParameters.Controls.Add(Me.pnlParameters)
        resources.ApplyResources(Me.flyParameters, "flyParameters")
        Me.flyParameters.Name = "flyParameters"
        '
        'pnlParameters
        '
        Me.pnlParameters.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        resources.ApplyResources(Me.pnlParameters, "pnlParameters")
        Me.pnlParameters.FlyoutPanel = Me.flyParameters
        Me.pnlParameters.Name = "pnlParameters"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = CType(resources.GetObject("LabelControl1.Appearance.Font"), System.Drawing.Font)
        Me.LabelControl1.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.LabelControl1, "LabelControl1")
        Me.LabelControl1.Name = "LabelControl1"
        '
        'tvDefaultPenPattern
        '
        Me.tvDefaultPenPattern.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colDefaultPenPattern})
        resources.ApplyResources(Me.tvDefaultPenPattern, "tvDefaultPenPattern")
        Me.tvDefaultPenPattern.Name = "tvDefaultPenPattern"
        Me.tvDefaultPenPattern.OptionsView.ShowIndentAsRowStyle = True
        Me.tvDefaultPenPattern.OptionsView.ShowIndicator = False
        Me.tvDefaultPenPattern.OptionsView.ShowRoot = False
        Me.tvDefaultPenPattern.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtDefaultPenPattern})
        '
        'colDefaultPenPattern
        '
        resources.ApplyResources(Me.colDefaultPenPattern, "colDefaultPenPattern")
        Me.colDefaultPenPattern.ColumnEdit = Me.txtDefaultPenPattern
        Me.colDefaultPenPattern.FieldName = "Name"
        Me.colDefaultPenPattern.Name = "colDefaultPenPattern"
        '
        'txtDefaultPenPattern
        '
        resources.ApplyResources(Me.txtDefaultPenPattern, "txtDefaultPenPattern")
        EditorButtonImageOptions1.SvgImage = Global.cSurveyPC.My.Resources.Resources.edit
        EditorButtonImageOptions1.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.txtDefaultPenPattern.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtDefaultPenPattern.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtDefaultPenPattern.Buttons1"), CType(resources.GetObject("txtDefaultPenPattern.Buttons2"), Integer), CType(resources.GetObject("txtDefaultPenPattern.Buttons3"), Boolean), CType(resources.GetObject("txtDefaultPenPattern.Buttons4"), Boolean), CType(resources.GetObject("txtDefaultPenPattern.Buttons5"), Boolean), EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, resources.GetString("txtDefaultPenPattern.Buttons6"), CType(resources.GetObject("txtDefaultPenPattern.Buttons7"), Object), CType(resources.GetObject("txtDefaultPenPattern.Buttons8"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtDefaultPenPattern.Buttons9"), DevExpress.Utils.ToolTipAnchor)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtDefaultPenPattern.Buttons10"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtDefaultPenPattern.Name = "txtDefaultPenPattern"
        Me.txtDefaultPenPattern.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'cboDesignBarPosition
        '
        resources.ApplyResources(Me.cboDesignBarPosition, "cboDesignBarPosition")
        Me.cboDesignBarPosition.Name = "cboDesignBarPosition"
        Me.cboDesignBarPosition.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboDesignBarPosition.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboDesignBarPosition.Properties.Items.AddRange(New Object() {resources.GetString("cboDesignBarPosition.Properties.Items"), resources.GetString("cboDesignBarPosition.Properties.Items1"), resources.GetString("cboDesignBarPosition.Properties.Items2"), resources.GetString("cboDesignBarPosition.Properties.Items3")})
        Me.cboDesignBarPosition.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'tabInfoData
        '
        Me.tabInfoData.Controls.Add(Me.GroupBox7)
        Me.tabInfoData.Name = "tabInfoData"
        resources.ApplyResources(Me.tabInfoData, "tabInfoData")
        '
        'tabInfoSVG
        '
        Me.tabInfoSVG.Controls.Add(Me.GroupBox2)
        Me.tabInfoSVG.Controls.Add(Me.GroupBox1)
        Me.tabInfoSVG.Name = "tabInfoSVG"
        resources.ApplyResources(Me.tabInfoSVG, "tabInfoSVG")
        '
        'tabInfoVisualTopo
        '
        Me.tabInfoVisualTopo.Controls.Add(Me.GroupBox4)
        Me.tabInfoVisualTopo.Name = "tabInfoVisualTopo"
        resources.ApplyResources(Me.tabInfoVisualTopo, "tabInfoVisualTopo")
        '
        'tabInfoLinkedSurveys
        '
        Me.tabInfoLinkedSurveys.Controls.Add(Me.chkLinkedSurveysRefreshOnLoad)
        Me.tabInfoLinkedSurveys.Controls.Add(Me.chkLinkedSurveysSelectOnAdd)
        Me.tabInfoLinkedSurveys.Controls.Add(Me.chkLinkedSurveysRecursiveLoadPrioritizeChildren)
        Me.tabInfoLinkedSurveys.Controls.Add(Me.chkLinkedSurveysShowInCaveInfo)
        Me.tabInfoLinkedSurveys.Controls.Add(Me.chkLinkedSurveysRecursiveLoad)
        Me.tabInfoLinkedSurveys.Name = "tabInfoLinkedSurveys"
        resources.ApplyResources(Me.tabInfoLinkedSurveys, "tabInfoLinkedSurveys")
        '
        'tabInfoWMS
        '
        Me.tabInfoWMS.Controls.Add(Me.GroupBox6)
        Me.tabInfoWMS.Controls.Add(Me.GroupBox5)
        Me.tabInfoWMS.Name = "tabInfoWMS"
        resources.ApplyResources(Me.tabInfoWMS, "tabInfoWMS")
        '
        'tabInfoHistory
        '
        Me.tabInfoHistory.Controls.Add(Me.tabHistorySettings)
        Me.tabInfoHistory.Controls.Add(Me.chkHistory)
        Me.tabInfoHistory.Controls.Add(Me.chkAutosaveUseHistorySettings)
        Me.tabInfoHistory.Controls.Add(Me.cboHistoryMode)
        Me.tabInfoHistory.Controls.Add(Me.lblHistoryMode)
        Me.tabInfoHistory.Controls.Add(Me.chkAutosave)
        Me.tabInfoHistory.Name = "tabInfoHistory"
        resources.ApplyResources(Me.tabInfoHistory, "tabInfoHistory")
        '
        'tabInfoDebug
        '
        Me.tabInfoDebug.Controls.Add(Me.GroupControl1)
        Me.tabInfoDebug.Controls.Add(Me.chkEnableMultithreadingPreview)
        Me.tabInfoDebug.Controls.Add(Me.chkForceGarbaceCollect)
        Me.tabInfoDebug.Controls.Add(Me.lblLogMaxSize)
        Me.tabInfoDebug.Controls.Add(Me.txtLogMaxLine)
        Me.tabInfoDebug.Controls.Add(Me.chkLogOnFile)
        Me.tabInfoDebug.Controls.Add(Me.cboFunctionLanguage)
        Me.tabInfoDebug.Controls.Add(Me.chkLogVerbose)
        Me.tabInfoDebug.Controls.Add(Me.lblFunctionLanguage)
        Me.tabInfoDebug.Controls.Add(Me.chkSendException)
        Me.tabInfoDebug.Controls.Add(Me.txtMachineID)
        Me.tabInfoDebug.Controls.Add(Me.lblMachineID)
        Me.tabInfoDebug.Controls.Add(Me.lblSendExceptionWarning)
        Me.tabInfoDebug.Controls.Add(Me.chkCheckNewVersion)
        Me.tabInfoDebug.Controls.Add(Me.Label4)
        Me.tabInfoDebug.Name = "tabInfoDebug"
        resources.ApplyResources(Me.tabInfoDebug, "tabInfoDebug")
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.CheckEdit2)
        Me.GroupControl1.Controls.Add(Me.CheckEdit1)
        resources.ApplyResources(Me.GroupControl1, "GroupControl1")
        Me.GroupControl1.Name = "GroupControl1"
        '
        'CheckEdit2
        '
        resources.ApplyResources(Me.CheckEdit2, "CheckEdit2")
        Me.CheckEdit2.Name = "CheckEdit2"
        Me.CheckEdit2.Properties.Caption = resources.GetString("CheckEdit2.Properties.Caption")
        '
        'CheckEdit1
        '
        resources.ApplyResources(Me.CheckEdit1, "CheckEdit1")
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = resources.GetString("CheckEdit1.Properties.Caption")
        '
        'chkEnableMultithreadingPreview
        '
        resources.ApplyResources(Me.chkEnableMultithreadingPreview, "chkEnableMultithreadingPreview")
        Me.chkEnableMultithreadingPreview.Name = "chkEnableMultithreadingPreview"
        Me.chkEnableMultithreadingPreview.Properties.AutoWidth = True
        Me.chkEnableMultithreadingPreview.Properties.Caption = resources.GetString("chkEnableMultithreadingPreview.Properties.Caption")
        '
        'chkForceGarbaceCollect
        '
        resources.ApplyResources(Me.chkForceGarbaceCollect, "chkForceGarbaceCollect")
        Me.chkForceGarbaceCollect.Name = "chkForceGarbaceCollect"
        Me.chkForceGarbaceCollect.Properties.AutoWidth = True
        Me.chkForceGarbaceCollect.Properties.Caption = resources.GetString("chkForceGarbaceCollect.Properties.Caption")
        '
        'lblLogMaxSize
        '
        resources.ApplyResources(Me.lblLogMaxSize, "lblLogMaxSize")
        Me.lblLogMaxSize.Name = "lblLogMaxSize"
        '
        'txtLogMaxLine
        '
        resources.ApplyResources(Me.txtLogMaxLine, "txtLogMaxLine")
        Me.txtLogMaxLine.Name = "txtLogMaxLine"
        Me.txtLogMaxLine.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtLogMaxLine.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtLogMaxLine.Properties.DisplayFormat.FormatString = "N0"
        Me.txtLogMaxLine.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtLogMaxLine.Properties.EditFormat.FormatString = "N0"
        Me.txtLogMaxLine.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtLogMaxLine.Properties.IsFloatValue = False
        Me.txtLogMaxLine.Properties.MaskSettings.Set("mask", "N00")
        Me.txtLogMaxLine.Properties.MaxValue = New Decimal(New Integer() {4096, 0, 0, 0})
        Me.txtLogMaxLine.Properties.MinValue = New Decimal(New Integer() {64, 0, 0, 0})
        '
        'chkLogOnFile
        '
        resources.ApplyResources(Me.chkLogOnFile, "chkLogOnFile")
        Me.chkLogOnFile.Name = "chkLogOnFile"
        Me.chkLogOnFile.Properties.AutoWidth = True
        Me.chkLogOnFile.Properties.Caption = resources.GetString("chkLogOnFile.Properties.Caption")
        '
        'frmSettings
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.AccordionControl1)
        Me.Controls.Add(Me.pnlFooter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmSettings.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.parameters
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.tabHistorySettings.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.chkHistoryArchiveOnSave.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHistoryMaxCopies, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHistoryDailyCopies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.chkHistoryWebArchiveOnSave.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHistoryWebAuthReq.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHistoryWebMaxCopies, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHistoryWebDailyCopies, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAutosaveUseHistorySettings.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHistory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAutosave.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.txtWMSFromOrthoPhotoMaxHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picWMSFromOrthoPhotoBackgroundColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWMSFromOrthoPhotoMaxWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.txtWMSCacheMaxSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkWMSCacheEnabled.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMachineID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCheckNewVersion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSendException.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLogVerbose.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignShowLegacyExtraPrintAndExportObjects.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesignMetricGridOpacity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignUseOnlyAnchorToMove.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignShowRulers.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.chkShotsGridExportSplayNames.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.chkSVGExportTextAsPath.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSVGExportcSurveyReference.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSVGExportImages.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSVGExportDPI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSVGExportNoClipartBrushes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSVGExportNoClipping.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSVGExportScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtSVGImportPathMaxLen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSVGImportAutodivide.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSVGImportScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.chkVTopoImportSetAsBranch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkVTopoImportIncompatibleSet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLinkedSurveysRefreshOnLoad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLinkedSurveysRecursiveLoadPrioritizeChildren.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLinkedSurveysRecursiveLoad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLinkedSurveysShowInCaveInfo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLinkedSurveysSelectOnAdd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCalculateMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAlwaysUseShellForAttchments.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesignAnchorScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.chkClipboardLocalFormat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkClipboardCleanPastedStation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSetDesignToolsEnabledByLevel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSetDesignToolsHiddenByLevel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTherionLochEnabled.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTherionPath.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.frmTherionAdvancedSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmTherionAdvancedSettings.ResumeLayout(False)
        Me.frmTherionAdvancedSettings.PerformLayout()
        CType(Me.tvTherionINI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTherionUseCadastralIDInCaveNames.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTherionSegmentForcePath.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTherionSegmentForceDirection.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTherionTrigpointSafename.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTherionBackgroundProcess.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTherionDeleteTempFiles.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDefaultFolder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDefaultDesigner.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDefaultTeam.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDefaultClub.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlFooter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFooter.ResumeLayout(False)
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMain.ResumeLayout(False)
        Me.tabInfoMain.ResumeLayout(False)
        Me.tabInfoMain.PerformLayout()
        Me.tabInfoTherion.ResumeLayout(False)
        Me.tabInfoTherion.PerformLayout()
        Me.tabInfoOptions.ResumeLayout(False)
        Me.tabInfoOptions.PerformLayout()
        Me.tabInfoInterface.ResumeLayout(False)
        Me.tabInfoInterface.PerformLayout()
        CType(Me.chkITChangePeriodKey.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkITChangeDecimalKey.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLanguage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabInfoDesign.ResumeLayout(False)
        Me.tabInfoDesign.PerformLayout()
        CType(Me.flyParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flyParameters.ResumeLayout(False)
        CType(Me.pnlParameters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tvDefaultPenPattern, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDefaultPenPattern, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDesignBarPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabInfoData.ResumeLayout(False)
        Me.tabInfoSVG.ResumeLayout(False)
        Me.tabInfoVisualTopo.ResumeLayout(False)
        Me.tabInfoLinkedSurveys.ResumeLayout(False)
        Me.tabInfoLinkedSurveys.PerformLayout()
        Me.tabInfoWMS.ResumeLayout(False)
        Me.tabInfoHistory.ResumeLayout(False)
        Me.tabInfoHistory.PerformLayout()
        Me.tabInfoDebug.ResumeLayout(False)
        Me.tabInfoDebug.PerformLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.CheckEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkEnableMultithreadingPreview.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkForceGarbaceCollect.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLogMaxLine.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLogOnFile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdTherionPathBrowse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblTherionPath As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboDesignMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblDesignMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkTherionBackgroundProcess As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignShowRulers As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboDesignQuality As System.Windows.Forms.ComboBox
    Friend WithEvents lblDesignQuality As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDefaultTeam As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lblDefaultTeam As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDefaultClub As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lblDefaultClub As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkTherionTrigpointSafename As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkLogVerbose As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblDefaultCalculateMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboDefaultCalculateType As System.Windows.Forms.ComboBox
    Friend WithEvents txtSVGImportPathMaxLen As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPlotSelectedPointSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkSVGImportAutodivide As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblSVGImportScale As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSVGImportScale As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSVGImportLineType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboSVGImportLineType As System.Windows.Forms.ComboBox
    Friend WithEvents chkSetDesignToolsEnabledByLevel As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkSetDesignToolsHiddenByLevel As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkVTopoImportIncompatibleSet As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboDesignLineType As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboDesignClipBorder As System.Windows.Forms.ComboBox
    Friend WithEvents lblClipping As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkAutosave As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkTherionLochEnabled As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkTherionDeleteTempFiles As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkCalculateMode As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GroupBox2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblSVGExportScale As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSVGExportScale As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkSVGExportNoClipping As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkSVGExportNoClipartBrushes As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblSVGExportDPI As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSVGExportDPI As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblClipboardFormats As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lvClipboardFormats As System.Windows.Forms.ListView
    Friend WithEvents colClipboardFormat As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cboDesignShowRulersStyle As System.Windows.Forms.ComboBox
    Friend WithEvents chkClipboardCleanPastedStation As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtDefaultDesigner As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lblDefaultDesigner As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblHistoryMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkHistory As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboHistoryMode As System.Windows.Forms.ComboBox
    Friend WithEvents cmdHistoryFolderBrowse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtHistoryFolder As System.Windows.Forms.TextBox
    Friend WithEvents lblHistoryFolder As DevExpress.XtraEditors.LabelControl
    Friend WithEvents frmTherionAdvancedSettings As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkTherionSegmentForcePath As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkTherionSegmentForceDirection As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkVTopoImportSetAsBranch As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboDesignZoomType As System.Windows.Forms.ComboBox
    Friend WithEvents lblDesignZoomType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkDesignUseOnlyAnchorToMove As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkAutosaveUseHistorySettings As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblHistoryDailyCopies As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtHistoryDailyCopies As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblHistoryMaxCopies As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtHistoryMaxCopies As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmdDefaultFolder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtDefaultFolder As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkSendException As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblSendExceptionWarning As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkClipboardLocalFormat As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkCheckNewVersion As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtMachineID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblMachineID As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboFunctionLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents lblFunctionLanguage As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDefaultFont As System.Windows.Forms.TextBox
    Friend WithEvents cmdDefaultFont As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblDefaultFont As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboMaxDrawItemCount As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboDesignShowMetricGrid As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblHistoryWebPassword As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtHistoryWebPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblHistoryWebUsername As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtHistoryWebUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtHistoryWebURL As System.Windows.Forms.TextBox
    Friend WithEvents lblHistoryWebAddress As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdHistoryWebCheck As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tabHistorySettings As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lblHistoryWebMaxCopies As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtHistoryWebMaxCopies As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblHistoryWebDailyCopies As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtHistoryWebDailyCopies As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkHistoryWebAuthReq As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkHistoryArchiveOnSave As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkHistoryWebArchiveOnSave As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GroupBox5 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtWMSCacheMaxSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblWMSCacheMaxSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkWMSCacheEnabled As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnWMSClearCache As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblWMSCacheCurrentSizeValue As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblWMSCacheCurrentSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupBox6 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtWMSFromOrthoPhotoMaxWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdWMSFromOrthoPhotoBackgroundColor As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPlotNoteTextColor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents picWMSFromOrthoPhotoBackgroundColor As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtWMSFromOrthoPhotoMaxHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnWMSBrowse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtDesignMetricGridOpacity As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblDesignMetricGridOpacity As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDesignBarPosition As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDesignAnchorScale As NumericUpDown
    Friend WithEvents lblBaseLineWidthScaleFactor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupBox7 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkShotsGridExportSplayNames As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignShowLegacyExtraPrintAndExportObjects As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboDesignSelectionMode As ComboBox
    Friend WithEvents lblDesignSelectionMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkAlwaysUseShellForAttchments As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkLinkedSurveysSelectOnAdd As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkLinkedSurveysShowInCaveInfo As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkLinkedSurveysRecursiveLoad As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkTherionUseCadastralIDInCaveNames As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkLinkedSurveysRecursiveLoadPrioritizeChildren As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkLinkedSurveysRefreshOnLoad As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkSVGExportcSurveyReference As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkSVGExportImages As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkSVGExportTextAsPath As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents pnlFooter As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblSeparator As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents AccordionControl1 As DevExpress.XtraBars.Navigation.AccordionControl
    Friend WithEvents btnMain As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement4 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement18 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement17 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement16 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement14 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents btnSurface As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement13 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement7 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement8 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement12 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement10 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement11 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents tabMain As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabInfoMain As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabInfoTherion As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabInfoOptions As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabInfoInterface As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabInfoDesign As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabInfoData As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabInfoSVG As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabInfoVisualTopo As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabInfoLinkedSurveys As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabInfoWMS As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabInfoHistory As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabInfoDebug As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents txtTherionPath As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkLogOnFile As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblLogMaxSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtLogMaxLine As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents chkForceGarbaceCollect As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboDesignBarPosition As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboLanguage As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents chkITChangeDecimalKey As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkITChangePeriodKey As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tvDefaultPenPattern As DevExpress.XtraTreeList.TreeList
    Friend WithEvents colDefaultPenPattern As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents txtDefaultPenPattern As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents flyParameters As DevExpress.Utils.FlyoutPanel
    Friend WithEvents pnlParameters As DevExpress.Utils.FlyoutPanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboDesignGeoLineType As ComboBox
    Friend WithEvents chkEnableMultithreadingPreview As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CheckEdit2 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tvTherionINI As DevExpress.XtraTreeList.TreeList
    Friend WithEvents colTherionIniKey As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colTherionIniValue As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cmdTherionINIAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdTherionINIDelete As DevExpress.XtraEditors.SimpleButton
End Class
