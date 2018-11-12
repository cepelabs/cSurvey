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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.tabSettings = New System.Windows.Forms.TabControl()
        Me.tabMain = New System.Windows.Forms.TabPage()
        Me.grdFileAssociation = New System.Windows.Forms.GroupBox()
        Me.cmdFileAssociationCreate = New System.Windows.Forms.Button()
        Me.cmdFileAssociationRemove = New System.Windows.Forms.Button()
        Me.cmdDefaultFolder = New System.Windows.Forms.Button()
        Me.txtDefaultFolder = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDefaultDesigner = New System.Windows.Forms.TextBox()
        Me.lblDefaultDesigner = New System.Windows.Forms.Label()
        Me.txtDefaultTeam = New System.Windows.Forms.TextBox()
        Me.lblDefaultTeam = New System.Windows.Forms.Label()
        Me.txtDefaultClub = New System.Windows.Forms.TextBox()
        Me.lblDefaultClub = New System.Windows.Forms.Label()
        Me.tabOptions = New System.Windows.Forms.TabPage()
        Me.chkCalculateMode = New System.Windows.Forms.CheckBox()
        Me.lblDefaultCalculateMode = New System.Windows.Forms.Label()
        Me.cboDefaultCalculateType = New System.Windows.Forms.ComboBox()
        Me.tabTherion = New System.Windows.Forms.TabPage()
        Me.chkTherionLochEnabled = New System.Windows.Forms.CheckBox()
        Me.cmdTherionPathBrowse = New System.Windows.Forms.Button()
        Me.txtTherionPath = New System.Windows.Forms.TextBox()
        Me.lblTherionPath = New System.Windows.Forms.Label()
        Me.chkTherionEnabled = New System.Windows.Forms.CheckBox()
        Me.frmTherionAdvancedSettings = New System.Windows.Forms.GroupBox()
        Me.chkTherionSegmentForcePath = New System.Windows.Forms.CheckBox()
        Me.chkTherionSegmentForceDirection = New System.Windows.Forms.CheckBox()
        Me.chkTherionTrigpointSafename = New System.Windows.Forms.CheckBox()
        Me.chkTherionBackgroundProcess = New System.Windows.Forms.CheckBox()
        Me.chkTherionDeleteTempFiles = New System.Windows.Forms.CheckBox()
        Me.tabInterface = New System.Windows.Forms.TabPage()
        Me.chkAlwaysUseShellForAttchments = New System.Windows.Forms.CheckBox()
        Me.txtDesignAnchorScale = New System.Windows.Forms.NumericUpDown()
        Me.lblBaseLineWidthScaleFactor = New System.Windows.Forms.Label()
        Me.chkAllowResizablePanel = New System.Windows.Forms.CheckBox()
        Me.chkShowLastUsedToolsInDesignBar = New System.Windows.Forms.CheckBox()
        Me.cboMaxDrawItemCount = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkLayersShowItemPreview = New System.Windows.Forms.CheckBox()
        Me.cboLanguage = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkClipboardLocalFormat = New System.Windows.Forms.CheckBox()
        Me.chkClipboardCleanPastedStation = New System.Windows.Forms.CheckBox()
        Me.lblClipboardFormats = New System.Windows.Forms.Label()
        Me.lvClipboardFormats = New System.Windows.Forms.ListView()
        Me.colClipboardFormat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chkSetDesignToolsEnabledByLevel = New System.Windows.Forms.CheckBox()
        Me.chkSetDesignToolsHiddenByLevel = New System.Windows.Forms.CheckBox()
        Me.cboDesignBarPosition = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tabDesign = New System.Windows.Forms.TabPage()
        Me.cboDesignSelectionMode = New System.Windows.Forms.ComboBox()
        Me.lblDesignSelectionMode = New System.Windows.Forms.Label()
        Me.chkDesignShowLegacyExtraPrintAndExportObjects = New System.Windows.Forms.CheckBox()
        Me.txtDesignMetricGridOpacity = New System.Windows.Forms.NumericUpDown()
        Me.lblDesignMetricGridOpacity = New System.Windows.Forms.Label()
        Me.cboDesignShowMetricGrid = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDefaultFont = New System.Windows.Forms.TextBox()
        Me.cmdDefaultFont = New System.Windows.Forms.Button()
        Me.lblDefaultFont = New System.Windows.Forms.Label()
        Me.chkDesignUseOnlyAnchorToMove = New System.Windows.Forms.CheckBox()
        Me.cboDesignZoomType = New System.Windows.Forms.ComboBox()
        Me.lblDesignZoomType = New System.Windows.Forms.Label()
        Me.cboDesignShowRulersStyle = New System.Windows.Forms.ComboBox()
        Me.cboDesignClipBorder = New System.Windows.Forms.ComboBox()
        Me.lblClipping = New System.Windows.Forms.Label()
        Me.cboDesignLineType = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cboDesignQuality = New System.Windows.Forms.ComboBox()
        Me.lblDesignQuality = New System.Windows.Forms.Label()
        Me.chkDesignShowRulers = New System.Windows.Forms.CheckBox()
        Me.cboDesignMode = New System.Windows.Forms.ComboBox()
        Me.lblDesignMode = New System.Windows.Forms.Label()
        Me.tabGrids = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.chkShotsGridExportSplayNames = New System.Windows.Forms.CheckBox()
        Me.tabSVG = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblSVGExportDPI = New System.Windows.Forms.Label()
        Me.txtSVGExportDPI = New System.Windows.Forms.NumericUpDown()
        Me.chkSVGExportNoClipartBrushes = New System.Windows.Forms.CheckBox()
        Me.chkSVGExportNoClipping = New System.Windows.Forms.CheckBox()
        Me.lblSVGExportScale = New System.Windows.Forms.Label()
        Me.txtSVGExportScale = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSVGImportPathMaxLen = New System.Windows.Forms.NumericUpDown()
        Me.chkSVGImportAutodivide = New System.Windows.Forms.CheckBox()
        Me.cboSVGImportLineType = New System.Windows.Forms.ComboBox()
        Me.lblSVGImportScale = New System.Windows.Forms.Label()
        Me.lblSVGImportLineType = New System.Windows.Forms.Label()
        Me.lblPlotSelectedPointSize = New System.Windows.Forms.Label()
        Me.txtSVGImportScale = New System.Windows.Forms.NumericUpDown()
        Me.tabVTopo = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkVTopoImportSetAsBranch = New System.Windows.Forms.CheckBox()
        Me.chkVTopoImportIncompatibleSet = New System.Windows.Forms.CheckBox()
        Me.tabLinkedSurveys = New System.Windows.Forms.TabPage()
        Me.chkLinkedSurveysRecursiveLoad = New System.Windows.Forms.CheckBox()
        Me.chkLinkedSurveysShowInCaveInfo = New System.Windows.Forms.CheckBox()
        Me.chkLinkedSurveysSelectOnAdd = New System.Windows.Forms.CheckBox()
        Me.tabWMS = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtWMSFromOrthoPhotoMaxHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdWMSFromOrthoPhotoBackgroundColor = New System.Windows.Forms.Button()
        Me.lblPlotNoteTextColor = New System.Windows.Forms.Label()
        Me.picWMSFromOrthoPhotoBackgroundColor = New System.Windows.Forms.PictureBox()
        Me.txtWMSFromOrthoPhotoMaxWidth = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnWMSBrowse = New System.Windows.Forms.Button()
        Me.lblWMSCacheCurrentSizeValue = New System.Windows.Forms.Label()
        Me.lblWMSCacheCurrentSize = New System.Windows.Forms.Label()
        Me.btnWMSClearCache = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtWMSCacheMaxSize = New System.Windows.Forms.NumericUpDown()
        Me.lblWMSCacheMaxSize = New System.Windows.Forms.Label()
        Me.chkWMSCacheEnabled = New System.Windows.Forms.CheckBox()
        Me.tabHistory = New System.Windows.Forms.TabPage()
        Me.tabHistorySettings = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chkHistoryArchiveOnSave = New System.Windows.Forms.CheckBox()
        Me.lblHistoryMaxCopies = New System.Windows.Forms.Label()
        Me.txtHistoryFolder = New System.Windows.Forms.TextBox()
        Me.txtHistoryMaxCopies = New System.Windows.Forms.NumericUpDown()
        Me.lblHistoryFolder = New System.Windows.Forms.Label()
        Me.lblHistoryDailyCopies = New System.Windows.Forms.Label()
        Me.cmdHistoryFolderBrowse = New System.Windows.Forms.Button()
        Me.txtHistoryDailyCopies = New System.Windows.Forms.NumericUpDown()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.chkHistoryWebArchiveOnSave = New System.Windows.Forms.CheckBox()
        Me.chkHistoryWebAuthReq = New System.Windows.Forms.CheckBox()
        Me.lblHistoryWebMaxCopies = New System.Windows.Forms.Label()
        Me.txtHistoryWebMaxCopies = New System.Windows.Forms.NumericUpDown()
        Me.lblHistoryWebDailyCopies = New System.Windows.Forms.Label()
        Me.txtHistoryWebDailyCopies = New System.Windows.Forms.NumericUpDown()
        Me.cmdHistoryWebCheck = New System.Windows.Forms.Button()
        Me.txtHistoryWebURL = New System.Windows.Forms.TextBox()
        Me.lblHistoryWebPassword = New System.Windows.Forms.Label()
        Me.lblHistoryWebAddress = New System.Windows.Forms.Label()
        Me.txtHistoryWebPassword = New System.Windows.Forms.TextBox()
        Me.txtHistoryWebUsername = New System.Windows.Forms.TextBox()
        Me.lblHistoryWebUsername = New System.Windows.Forms.Label()
        Me.chkAutosaveUseHistorySettings = New System.Windows.Forms.CheckBox()
        Me.lblHistoryMode = New System.Windows.Forms.Label()
        Me.chkHistory = New System.Windows.Forms.CheckBox()
        Me.chkAutosave = New System.Windows.Forms.CheckBox()
        Me.cboHistoryMode = New System.Windows.Forms.ComboBox()
        Me.tabDebug = New System.Windows.Forms.TabPage()
        Me.cboFunctionLanguage = New System.Windows.Forms.ComboBox()
        Me.lblFunctionLanguage = New System.Windows.Forms.Label()
        Me.txtMachineID = New System.Windows.Forms.TextBox()
        Me.lblMachineID = New System.Windows.Forms.Label()
        Me.chkMultiThreading = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.chkCheckNewVersion = New System.Windows.Forms.CheckBox()
        Me.lblSendExceptionWarning = New System.Windows.Forms.Label()
        Me.picSendExceptionWarning = New System.Windows.Forms.PictureBox()
        Me.chkSendException = New System.Windows.Forms.CheckBox()
        Me.chkLogEnabled = New System.Windows.Forms.CheckBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.tipStandard = New System.Windows.Forms.ToolTip(Me.components)
        Me.tabSettings.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.grdFileAssociation.SuspendLayout()
        Me.tabOptions.SuspendLayout()
        Me.tabTherion.SuspendLayout()
        Me.frmTherionAdvancedSettings.SuspendLayout()
        Me.tabInterface.SuspendLayout()
        CType(Me.txtDesignAnchorScale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.tabDesign.SuspendLayout()
        CType(Me.txtDesignMetricGridOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabGrids.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.tabSVG.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtSVGExportDPI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSVGExportScale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtSVGImportPathMaxLen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSVGImportScale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabVTopo.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.tabLinkedSurveys.SuspendLayout()
        Me.tabWMS.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.txtWMSFromOrthoPhotoMaxHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picWMSFromOrthoPhotoBackgroundColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWMSFromOrthoPhotoMaxWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.txtWMSCacheMaxSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabHistory.SuspendLayout()
        Me.tabHistorySettings.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.txtHistoryMaxCopies, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHistoryDailyCopies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.txtHistoryWebMaxCopies, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHistoryWebDailyCopies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDebug.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSendExceptionWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabSettings
        '
        resources.ApplyResources(Me.tabSettings, "tabSettings")
        Me.tabSettings.Controls.Add(Me.tabMain)
        Me.tabSettings.Controls.Add(Me.tabOptions)
        Me.tabSettings.Controls.Add(Me.tabTherion)
        Me.tabSettings.Controls.Add(Me.tabInterface)
        Me.tabSettings.Controls.Add(Me.tabDesign)
        Me.tabSettings.Controls.Add(Me.tabGrids)
        Me.tabSettings.Controls.Add(Me.tabSVG)
        Me.tabSettings.Controls.Add(Me.tabVTopo)
        Me.tabSettings.Controls.Add(Me.tabLinkedSurveys)
        Me.tabSettings.Controls.Add(Me.tabWMS)
        Me.tabSettings.Controls.Add(Me.tabHistory)
        Me.tabSettings.Controls.Add(Me.tabDebug)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.SelectedIndex = 0
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.grdFileAssociation)
        Me.tabMain.Controls.Add(Me.cmdDefaultFolder)
        Me.tabMain.Controls.Add(Me.txtDefaultFolder)
        Me.tabMain.Controls.Add(Me.Label3)
        Me.tabMain.Controls.Add(Me.txtDefaultDesigner)
        Me.tabMain.Controls.Add(Me.lblDefaultDesigner)
        Me.tabMain.Controls.Add(Me.txtDefaultTeam)
        Me.tabMain.Controls.Add(Me.lblDefaultTeam)
        Me.tabMain.Controls.Add(Me.txtDefaultClub)
        Me.tabMain.Controls.Add(Me.lblDefaultClub)
        resources.ApplyResources(Me.tabMain, "tabMain")
        Me.tabMain.Name = "tabMain"
        Me.tabMain.UseVisualStyleBackColor = True
        '
        'grdFileAssociation
        '
        resources.ApplyResources(Me.grdFileAssociation, "grdFileAssociation")
        Me.grdFileAssociation.Controls.Add(Me.cmdFileAssociationCreate)
        Me.grdFileAssociation.Controls.Add(Me.cmdFileAssociationRemove)
        Me.grdFileAssociation.Name = "grdFileAssociation"
        Me.grdFileAssociation.TabStop = False
        '
        'cmdFileAssociationCreate
        '
        resources.ApplyResources(Me.cmdFileAssociationCreate, "cmdFileAssociationCreate")
        Me.cmdFileAssociationCreate.Image = Global.cSurveyPC.My.Resources.Resources.accept
        Me.cmdFileAssociationCreate.Name = "cmdFileAssociationCreate"
        Me.cmdFileAssociationCreate.UseVisualStyleBackColor = True
        '
        'cmdFileAssociationRemove
        '
        resources.ApplyResources(Me.cmdFileAssociationRemove, "cmdFileAssociationRemove")
        Me.cmdFileAssociationRemove.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.cmdFileAssociationRemove.Name = "cmdFileAssociationRemove"
        Me.cmdFileAssociationRemove.UseVisualStyleBackColor = True
        '
        'cmdDefaultFolder
        '
        resources.ApplyResources(Me.cmdDefaultFolder, "cmdDefaultFolder")
        Me.cmdDefaultFolder.Name = "cmdDefaultFolder"
        Me.cmdDefaultFolder.UseVisualStyleBackColor = True
        '
        'txtDefaultFolder
        '
        resources.ApplyResources(Me.txtDefaultFolder, "txtDefaultFolder")
        Me.txtDefaultFolder.Name = "txtDefaultFolder"
        Me.txtDefaultFolder.ReadOnly = True
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
        'tabOptions
        '
        Me.tabOptions.Controls.Add(Me.chkCalculateMode)
        Me.tabOptions.Controls.Add(Me.lblDefaultCalculateMode)
        Me.tabOptions.Controls.Add(Me.cboDefaultCalculateType)
        resources.ApplyResources(Me.tabOptions, "tabOptions")
        Me.tabOptions.Name = "tabOptions"
        Me.tabOptions.UseVisualStyleBackColor = True
        '
        'chkCalculateMode
        '
        resources.ApplyResources(Me.chkCalculateMode, "chkCalculateMode")
        Me.chkCalculateMode.Name = "chkCalculateMode"
        Me.chkCalculateMode.UseVisualStyleBackColor = True
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
        'tabTherion
        '
        Me.tabTherion.Controls.Add(Me.chkTherionLochEnabled)
        Me.tabTherion.Controls.Add(Me.cmdTherionPathBrowse)
        Me.tabTherion.Controls.Add(Me.txtTherionPath)
        Me.tabTherion.Controls.Add(Me.lblTherionPath)
        Me.tabTherion.Controls.Add(Me.chkTherionEnabled)
        Me.tabTherion.Controls.Add(Me.frmTherionAdvancedSettings)
        resources.ApplyResources(Me.tabTherion, "tabTherion")
        Me.tabTherion.Name = "tabTherion"
        Me.tabTherion.UseVisualStyleBackColor = True
        '
        'chkTherionLochEnabled
        '
        resources.ApplyResources(Me.chkTherionLochEnabled, "chkTherionLochEnabled")
        Me.chkTherionLochEnabled.Image = Global.cSurveyPC.My.Resources.Resources.layer_raster_3d
        Me.chkTherionLochEnabled.Name = "chkTherionLochEnabled"
        Me.tipStandard.SetToolTip(Me.chkTherionLochEnabled, resources.GetString("chkTherionLochEnabled.ToolTip"))
        Me.chkTherionLochEnabled.UseVisualStyleBackColor = True
        '
        'cmdTherionPathBrowse
        '
        resources.ApplyResources(Me.cmdTherionPathBrowse, "cmdTherionPathBrowse")
        Me.cmdTherionPathBrowse.Name = "cmdTherionPathBrowse"
        Me.cmdTherionPathBrowse.UseVisualStyleBackColor = True
        '
        'txtTherionPath
        '
        resources.ApplyResources(Me.txtTherionPath, "txtTherionPath")
        Me.txtTherionPath.Name = "txtTherionPath"
        Me.tipStandard.SetToolTip(Me.txtTherionPath, resources.GetString("txtTherionPath.ToolTip"))
        '
        'lblTherionPath
        '
        resources.ApplyResources(Me.lblTherionPath, "lblTherionPath")
        Me.lblTherionPath.Name = "lblTherionPath"
        '
        'chkTherionEnabled
        '
        resources.ApplyResources(Me.chkTherionEnabled, "chkTherionEnabled")
        Me.chkTherionEnabled.Name = "chkTherionEnabled"
        Me.tipStandard.SetToolTip(Me.chkTherionEnabled, resources.GetString("chkTherionEnabled.ToolTip"))
        Me.chkTherionEnabled.UseVisualStyleBackColor = True
        '
        'frmTherionAdvancedSettings
        '
        resources.ApplyResources(Me.frmTherionAdvancedSettings, "frmTherionAdvancedSettings")
        Me.frmTherionAdvancedSettings.Controls.Add(Me.chkTherionSegmentForcePath)
        Me.frmTherionAdvancedSettings.Controls.Add(Me.chkTherionSegmentForceDirection)
        Me.frmTherionAdvancedSettings.Controls.Add(Me.chkTherionTrigpointSafename)
        Me.frmTherionAdvancedSettings.Controls.Add(Me.chkTherionBackgroundProcess)
        Me.frmTherionAdvancedSettings.Controls.Add(Me.chkTherionDeleteTempFiles)
        Me.frmTherionAdvancedSettings.Name = "frmTherionAdvancedSettings"
        Me.frmTherionAdvancedSettings.TabStop = False
        '
        'chkTherionSegmentForcePath
        '
        resources.ApplyResources(Me.chkTherionSegmentForcePath, "chkTherionSegmentForcePath")
        Me.chkTherionSegmentForcePath.Name = "chkTherionSegmentForcePath"
        Me.tipStandard.SetToolTip(Me.chkTherionSegmentForcePath, resources.GetString("chkTherionSegmentForcePath.ToolTip"))
        Me.chkTherionSegmentForcePath.UseVisualStyleBackColor = True
        '
        'chkTherionSegmentForceDirection
        '
        resources.ApplyResources(Me.chkTherionSegmentForceDirection, "chkTherionSegmentForceDirection")
        Me.chkTherionSegmentForceDirection.Name = "chkTherionSegmentForceDirection"
        Me.tipStandard.SetToolTip(Me.chkTherionSegmentForceDirection, resources.GetString("chkTherionSegmentForceDirection.ToolTip"))
        Me.chkTherionSegmentForceDirection.UseVisualStyleBackColor = True
        '
        'chkTherionTrigpointSafename
        '
        resources.ApplyResources(Me.chkTherionTrigpointSafename, "chkTherionTrigpointSafename")
        Me.chkTherionTrigpointSafename.Name = "chkTherionTrigpointSafename"
        Me.tipStandard.SetToolTip(Me.chkTherionTrigpointSafename, resources.GetString("chkTherionTrigpointSafename.ToolTip"))
        Me.chkTherionTrigpointSafename.UseVisualStyleBackColor = True
        '
        'chkTherionBackgroundProcess
        '
        resources.ApplyResources(Me.chkTherionBackgroundProcess, "chkTherionBackgroundProcess")
        Me.chkTherionBackgroundProcess.Name = "chkTherionBackgroundProcess"
        Me.tipStandard.SetToolTip(Me.chkTherionBackgroundProcess, resources.GetString("chkTherionBackgroundProcess.ToolTip"))
        Me.chkTherionBackgroundProcess.UseVisualStyleBackColor = True
        '
        'chkTherionDeleteTempFiles
        '
        resources.ApplyResources(Me.chkTherionDeleteTempFiles, "chkTherionDeleteTempFiles")
        Me.chkTherionDeleteTempFiles.Name = "chkTherionDeleteTempFiles"
        Me.tipStandard.SetToolTip(Me.chkTherionDeleteTempFiles, resources.GetString("chkTherionDeleteTempFiles.ToolTip"))
        Me.chkTherionDeleteTempFiles.UseVisualStyleBackColor = True
        '
        'tabInterface
        '
        Me.tabInterface.Controls.Add(Me.chkAlwaysUseShellForAttchments)
        Me.tabInterface.Controls.Add(Me.txtDesignAnchorScale)
        Me.tabInterface.Controls.Add(Me.lblBaseLineWidthScaleFactor)
        Me.tabInterface.Controls.Add(Me.chkAllowResizablePanel)
        Me.tabInterface.Controls.Add(Me.chkShowLastUsedToolsInDesignBar)
        Me.tabInterface.Controls.Add(Me.cboMaxDrawItemCount)
        Me.tabInterface.Controls.Add(Me.Label5)
        Me.tabInterface.Controls.Add(Me.chkLayersShowItemPreview)
        Me.tabInterface.Controls.Add(Me.cboLanguage)
        Me.tabInterface.Controls.Add(Me.Label1)
        Me.tabInterface.Controls.Add(Me.GroupBox3)
        Me.tabInterface.Controls.Add(Me.chkSetDesignToolsEnabledByLevel)
        Me.tabInterface.Controls.Add(Me.chkSetDesignToolsHiddenByLevel)
        Me.tabInterface.Controls.Add(Me.cboDesignBarPosition)
        Me.tabInterface.Controls.Add(Me.Label10)
        resources.ApplyResources(Me.tabInterface, "tabInterface")
        Me.tabInterface.Name = "tabInterface"
        Me.tabInterface.UseVisualStyleBackColor = True
        '
        'chkAlwaysUseShellForAttchments
        '
        resources.ApplyResources(Me.chkAlwaysUseShellForAttchments, "chkAlwaysUseShellForAttchments")
        Me.chkAlwaysUseShellForAttchments.Name = "chkAlwaysUseShellForAttchments"
        Me.tipStandard.SetToolTip(Me.chkAlwaysUseShellForAttchments, resources.GetString("chkAlwaysUseShellForAttchments.ToolTip"))
        Me.chkAlwaysUseShellForAttchments.UseVisualStyleBackColor = True
        '
        'txtDesignAnchorScale
        '
        Me.txtDesignAnchorScale.DecimalPlaces = 2
        Me.txtDesignAnchorScale.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtDesignAnchorScale, "txtDesignAnchorScale")
        Me.txtDesignAnchorScale.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.txtDesignAnchorScale.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtDesignAnchorScale.Name = "txtDesignAnchorScale"
        Me.tipStandard.SetToolTip(Me.txtDesignAnchorScale, resources.GetString("txtDesignAnchorScale.ToolTip"))
        Me.txtDesignAnchorScale.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblBaseLineWidthScaleFactor
        '
        resources.ApplyResources(Me.lblBaseLineWidthScaleFactor, "lblBaseLineWidthScaleFactor")
        Me.lblBaseLineWidthScaleFactor.Name = "lblBaseLineWidthScaleFactor"
        '
        'chkAllowResizablePanel
        '
        resources.ApplyResources(Me.chkAllowResizablePanel, "chkAllowResizablePanel")
        Me.chkAllowResizablePanel.Name = "chkAllowResizablePanel"
        Me.tipStandard.SetToolTip(Me.chkAllowResizablePanel, resources.GetString("chkAllowResizablePanel.ToolTip"))
        Me.chkAllowResizablePanel.UseVisualStyleBackColor = True
        '
        'chkShowLastUsedToolsInDesignBar
        '
        resources.ApplyResources(Me.chkShowLastUsedToolsInDesignBar, "chkShowLastUsedToolsInDesignBar")
        Me.chkShowLastUsedToolsInDesignBar.Name = "chkShowLastUsedToolsInDesignBar"
        Me.chkShowLastUsedToolsInDesignBar.UseVisualStyleBackColor = True
        '
        'cboMaxDrawItemCount
        '
        Me.cboMaxDrawItemCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaxDrawItemCount.DropDownWidth = 200
        resources.ApplyResources(Me.cboMaxDrawItemCount, "cboMaxDrawItemCount")
        Me.cboMaxDrawItemCount.Items.AddRange(New Object() {resources.GetString("cboMaxDrawItemCount.Items"), resources.GetString("cboMaxDrawItemCount.Items1"), resources.GetString("cboMaxDrawItemCount.Items2"), resources.GetString("cboMaxDrawItemCount.Items3")})
        Me.cboMaxDrawItemCount.Name = "cboMaxDrawItemCount"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'chkLayersShowItemPreview
        '
        resources.ApplyResources(Me.chkLayersShowItemPreview, "chkLayersShowItemPreview")
        Me.chkLayersShowItemPreview.Name = "chkLayersShowItemPreview"
        Me.tipStandard.SetToolTip(Me.chkLayersShowItemPreview, resources.GetString("chkLayersShowItemPreview.ToolTip"))
        Me.chkLayersShowItemPreview.UseVisualStyleBackColor = True
        '
        'cboLanguage
        '
        Me.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLanguage.DropDownWidth = 240
        Me.cboLanguage.FormattingEnabled = True
        Me.cboLanguage.Items.AddRange(New Object() {resources.GetString("cboLanguage.Items"), resources.GetString("cboLanguage.Items1"), resources.GetString("cboLanguage.Items2"), resources.GetString("cboLanguage.Items3")})
        resources.ApplyResources(Me.cboLanguage, "cboLanguage")
        Me.cboLanguage.Name = "cboLanguage"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'GroupBox3
        '
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Controls.Add(Me.chkClipboardLocalFormat)
        Me.GroupBox3.Controls.Add(Me.chkClipboardCleanPastedStation)
        Me.GroupBox3.Controls.Add(Me.lblClipboardFormats)
        Me.GroupBox3.Controls.Add(Me.lvClipboardFormats)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        '
        'chkClipboardLocalFormat
        '
        resources.ApplyResources(Me.chkClipboardLocalFormat, "chkClipboardLocalFormat")
        Me.chkClipboardLocalFormat.Name = "chkClipboardLocalFormat"
        Me.tipStandard.SetToolTip(Me.chkClipboardLocalFormat, resources.GetString("chkClipboardLocalFormat.ToolTip"))
        Me.chkClipboardLocalFormat.UseVisualStyleBackColor = True
        '
        'chkClipboardCleanPastedStation
        '
        resources.ApplyResources(Me.chkClipboardCleanPastedStation, "chkClipboardCleanPastedStation")
        Me.chkClipboardCleanPastedStation.Name = "chkClipboardCleanPastedStation"
        Me.tipStandard.SetToolTip(Me.chkClipboardCleanPastedStation, resources.GetString("chkClipboardCleanPastedStation.ToolTip"))
        Me.chkClipboardCleanPastedStation.UseVisualStyleBackColor = True
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
        Me.chkSetDesignToolsEnabledByLevel.UseVisualStyleBackColor = True
        '
        'chkSetDesignToolsHiddenByLevel
        '
        resources.ApplyResources(Me.chkSetDesignToolsHiddenByLevel, "chkSetDesignToolsHiddenByLevel")
        Me.chkSetDesignToolsHiddenByLevel.Name = "chkSetDesignToolsHiddenByLevel"
        Me.chkSetDesignToolsHiddenByLevel.UseVisualStyleBackColor = True
        '
        'cboDesignBarPosition
        '
        Me.cboDesignBarPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDesignBarPosition.DropDownWidth = 400
        Me.cboDesignBarPosition.FormattingEnabled = True
        Me.cboDesignBarPosition.Items.AddRange(New Object() {resources.GetString("cboDesignBarPosition.Items"), resources.GetString("cboDesignBarPosition.Items1"), resources.GetString("cboDesignBarPosition.Items2"), resources.GetString("cboDesignBarPosition.Items3")})
        resources.ApplyResources(Me.cboDesignBarPosition, "cboDesignBarPosition")
        Me.cboDesignBarPosition.Name = "cboDesignBarPosition"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'tabDesign
        '
        resources.ApplyResources(Me.tabDesign, "tabDesign")
        Me.tabDesign.Controls.Add(Me.cboDesignSelectionMode)
        Me.tabDesign.Controls.Add(Me.lblDesignSelectionMode)
        Me.tabDesign.Controls.Add(Me.chkDesignShowLegacyExtraPrintAndExportObjects)
        Me.tabDesign.Controls.Add(Me.txtDesignMetricGridOpacity)
        Me.tabDesign.Controls.Add(Me.lblDesignMetricGridOpacity)
        Me.tabDesign.Controls.Add(Me.cboDesignShowMetricGrid)
        Me.tabDesign.Controls.Add(Me.Label6)
        Me.tabDesign.Controls.Add(Me.txtDefaultFont)
        Me.tabDesign.Controls.Add(Me.cmdDefaultFont)
        Me.tabDesign.Controls.Add(Me.lblDefaultFont)
        Me.tabDesign.Controls.Add(Me.chkDesignUseOnlyAnchorToMove)
        Me.tabDesign.Controls.Add(Me.cboDesignZoomType)
        Me.tabDesign.Controls.Add(Me.lblDesignZoomType)
        Me.tabDesign.Controls.Add(Me.cboDesignShowRulersStyle)
        Me.tabDesign.Controls.Add(Me.cboDesignClipBorder)
        Me.tabDesign.Controls.Add(Me.lblClipping)
        Me.tabDesign.Controls.Add(Me.cboDesignLineType)
        Me.tabDesign.Controls.Add(Me.Label27)
        Me.tabDesign.Controls.Add(Me.cboDesignQuality)
        Me.tabDesign.Controls.Add(Me.lblDesignQuality)
        Me.tabDesign.Controls.Add(Me.chkDesignShowRulers)
        Me.tabDesign.Controls.Add(Me.cboDesignMode)
        Me.tabDesign.Controls.Add(Me.lblDesignMode)
        Me.tabDesign.Name = "tabDesign"
        Me.tabDesign.UseVisualStyleBackColor = True
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
        Me.tipStandard.SetToolTip(Me.lblDesignSelectionMode, resources.GetString("lblDesignSelectionMode.ToolTip"))
        '
        'chkDesignShowLegacyExtraPrintAndExportObjects
        '
        resources.ApplyResources(Me.chkDesignShowLegacyExtraPrintAndExportObjects, "chkDesignShowLegacyExtraPrintAndExportObjects")
        Me.chkDesignShowLegacyExtraPrintAndExportObjects.Name = "chkDesignShowLegacyExtraPrintAndExportObjects"
        Me.chkDesignShowLegacyExtraPrintAndExportObjects.UseVisualStyleBackColor = True
        '
        'txtDesignMetricGridOpacity
        '
        resources.ApplyResources(Me.txtDesignMetricGridOpacity, "txtDesignMetricGridOpacity")
        Me.txtDesignMetricGridOpacity.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.txtDesignMetricGridOpacity.Name = "txtDesignMetricGridOpacity"
        Me.tipStandard.SetToolTip(Me.txtDesignMetricGridOpacity, resources.GetString("txtDesignMetricGridOpacity.ToolTip"))
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
        Me.tipStandard.SetToolTip(Me.txtDefaultFont, resources.GetString("txtDefaultFont.ToolTip"))
        '
        'cmdDefaultFont
        '
        resources.ApplyResources(Me.cmdDefaultFont, "cmdDefaultFont")
        Me.cmdDefaultFont.Name = "cmdDefaultFont"
        Me.cmdDefaultFont.UseVisualStyleBackColor = True
        '
        'lblDefaultFont
        '
        resources.ApplyResources(Me.lblDefaultFont, "lblDefaultFont")
        Me.lblDefaultFont.Name = "lblDefaultFont"
        '
        'chkDesignUseOnlyAnchorToMove
        '
        resources.ApplyResources(Me.chkDesignUseOnlyAnchorToMove, "chkDesignUseOnlyAnchorToMove")
        Me.chkDesignUseOnlyAnchorToMove.Name = "chkDesignUseOnlyAnchorToMove"
        Me.tipStandard.SetToolTip(Me.chkDesignUseOnlyAnchorToMove, resources.GetString("chkDesignUseOnlyAnchorToMove.ToolTip"))
        Me.chkDesignUseOnlyAnchorToMove.UseVisualStyleBackColor = True
        '
        'cboDesignZoomType
        '
        Me.cboDesignZoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDesignZoomType.DropDownWidth = 400
        resources.ApplyResources(Me.cboDesignZoomType, "cboDesignZoomType")
        Me.cboDesignZoomType.Items.AddRange(New Object() {resources.GetString("cboDesignZoomType.Items"), resources.GetString("cboDesignZoomType.Items1")})
        Me.cboDesignZoomType.Name = "cboDesignZoomType"
        Me.tipStandard.SetToolTip(Me.cboDesignZoomType, resources.GetString("cboDesignZoomType.ToolTip"))
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
        Me.chkDesignShowRulers.UseVisualStyleBackColor = True
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
        'tabGrids
        '
        Me.tabGrids.Controls.Add(Me.GroupBox7)
        resources.ApplyResources(Me.tabGrids, "tabGrids")
        Me.tabGrids.Name = "tabGrids"
        Me.tabGrids.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.chkShotsGridExportSplayNames)
        resources.ApplyResources(Me.GroupBox7, "GroupBox7")
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.TabStop = False
        '
        'chkShotsGridExportSplayNames
        '
        resources.ApplyResources(Me.chkShotsGridExportSplayNames, "chkShotsGridExportSplayNames")
        Me.chkShotsGridExportSplayNames.Name = "chkShotsGridExportSplayNames"
        Me.tipStandard.SetToolTip(Me.chkShotsGridExportSplayNames, resources.GetString("chkShotsGridExportSplayNames.ToolTip"))
        Me.chkShotsGridExportSplayNames.UseVisualStyleBackColor = True
        '
        'tabSVG
        '
        Me.tabSVG.Controls.Add(Me.GroupBox2)
        Me.tabSVG.Controls.Add(Me.GroupBox1)
        resources.ApplyResources(Me.tabSVG, "tabSVG")
        Me.tabSVG.Name = "tabSVG"
        Me.tabSVG.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblSVGExportDPI)
        Me.GroupBox2.Controls.Add(Me.txtSVGExportDPI)
        Me.GroupBox2.Controls.Add(Me.chkSVGExportNoClipartBrushes)
        Me.GroupBox2.Controls.Add(Me.chkSVGExportNoClipping)
        Me.GroupBox2.Controls.Add(Me.lblSVGExportScale)
        Me.GroupBox2.Controls.Add(Me.txtSVGExportScale)
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
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
        Me.tipStandard.SetToolTip(Me.txtSVGExportDPI, resources.GetString("txtSVGExportDPI.ToolTip"))
        Me.txtSVGExportDPI.Value = New Decimal(New Integer() {90, 0, 0, 0})
        '
        'chkSVGExportNoClipartBrushes
        '
        resources.ApplyResources(Me.chkSVGExportNoClipartBrushes, "chkSVGExportNoClipartBrushes")
        Me.chkSVGExportNoClipartBrushes.Name = "chkSVGExportNoClipartBrushes"
        Me.tipStandard.SetToolTip(Me.chkSVGExportNoClipartBrushes, resources.GetString("chkSVGExportNoClipartBrushes.ToolTip"))
        Me.chkSVGExportNoClipartBrushes.UseVisualStyleBackColor = True
        '
        'chkSVGExportNoClipping
        '
        resources.ApplyResources(Me.chkSVGExportNoClipping, "chkSVGExportNoClipping")
        Me.chkSVGExportNoClipping.Name = "chkSVGExportNoClipping"
        Me.tipStandard.SetToolTip(Me.chkSVGExportNoClipping, resources.GetString("chkSVGExportNoClipping.ToolTip"))
        Me.chkSVGExportNoClipping.UseVisualStyleBackColor = True
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
        Me.tipStandard.SetToolTip(Me.txtSVGExportScale, resources.GetString("txtSVGExportScale.ToolTip"))
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
        Me.GroupBox1.TabStop = False
        '
        'txtSVGImportPathMaxLen
        '
        Me.txtSVGImportPathMaxLen.Increment = New Decimal(New Integer() {500, 0, 0, 0})
        resources.ApplyResources(Me.txtSVGImportPathMaxLen, "txtSVGImportPathMaxLen")
        Me.txtSVGImportPathMaxLen.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.txtSVGImportPathMaxLen.Name = "txtSVGImportPathMaxLen"
        Me.tipStandard.SetToolTip(Me.txtSVGImportPathMaxLen, resources.GetString("txtSVGImportPathMaxLen.ToolTip"))
        '
        'chkSVGImportAutodivide
        '
        resources.ApplyResources(Me.chkSVGImportAutodivide, "chkSVGImportAutodivide")
        Me.chkSVGImportAutodivide.Name = "chkSVGImportAutodivide"
        Me.tipStandard.SetToolTip(Me.chkSVGImportAutodivide, resources.GetString("chkSVGImportAutodivide.ToolTip"))
        Me.chkSVGImportAutodivide.UseVisualStyleBackColor = True
        '
        'cboSVGImportLineType
        '
        Me.cboSVGImportLineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSVGImportLineType.DropDownWidth = 400
        Me.cboSVGImportLineType.FormattingEnabled = True
        Me.cboSVGImportLineType.Items.AddRange(New Object() {resources.GetString("cboSVGImportLineType.Items"), resources.GetString("cboSVGImportLineType.Items1"), resources.GetString("cboSVGImportLineType.Items2")})
        resources.ApplyResources(Me.cboSVGImportLineType, "cboSVGImportLineType")
        Me.cboSVGImportLineType.Name = "cboSVGImportLineType"
        Me.tipStandard.SetToolTip(Me.cboSVGImportLineType, resources.GetString("cboSVGImportLineType.ToolTip"))
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
        Me.tipStandard.SetToolTip(Me.txtSVGImportScale, resources.GetString("txtSVGImportScale.ToolTip"))
        Me.txtSVGImportScale.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'tabVTopo
        '
        Me.tabVTopo.Controls.Add(Me.GroupBox4)
        resources.ApplyResources(Me.tabVTopo, "tabVTopo")
        Me.tabVTopo.Name = "tabVTopo"
        Me.tabVTopo.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkVTopoImportSetAsBranch)
        Me.GroupBox4.Controls.Add(Me.chkVTopoImportIncompatibleSet)
        resources.ApplyResources(Me.GroupBox4, "GroupBox4")
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.TabStop = False
        '
        'chkVTopoImportSetAsBranch
        '
        resources.ApplyResources(Me.chkVTopoImportSetAsBranch, "chkVTopoImportSetAsBranch")
        Me.chkVTopoImportSetAsBranch.Name = "chkVTopoImportSetAsBranch"
        Me.tipStandard.SetToolTip(Me.chkVTopoImportSetAsBranch, resources.GetString("chkVTopoImportSetAsBranch.ToolTip"))
        Me.chkVTopoImportSetAsBranch.UseVisualStyleBackColor = True
        '
        'chkVTopoImportIncompatibleSet
        '
        resources.ApplyResources(Me.chkVTopoImportIncompatibleSet, "chkVTopoImportIncompatibleSet")
        Me.chkVTopoImportIncompatibleSet.Name = "chkVTopoImportIncompatibleSet"
        Me.tipStandard.SetToolTip(Me.chkVTopoImportIncompatibleSet, resources.GetString("chkVTopoImportIncompatibleSet.ToolTip"))
        Me.chkVTopoImportIncompatibleSet.UseVisualStyleBackColor = True
        '
        'tabLinkedSurveys
        '
        Me.tabLinkedSurveys.Controls.Add(Me.chkLinkedSurveysRecursiveLoad)
        Me.tabLinkedSurveys.Controls.Add(Me.chkLinkedSurveysShowInCaveInfo)
        Me.tabLinkedSurveys.Controls.Add(Me.chkLinkedSurveysSelectOnAdd)
        resources.ApplyResources(Me.tabLinkedSurveys, "tabLinkedSurveys")
        Me.tabLinkedSurveys.Name = "tabLinkedSurveys"
        Me.tabLinkedSurveys.UseVisualStyleBackColor = True
        '
        'chkLinkedSurveysRecursiveLoad
        '
        resources.ApplyResources(Me.chkLinkedSurveysRecursiveLoad, "chkLinkedSurveysRecursiveLoad")
        Me.chkLinkedSurveysRecursiveLoad.Name = "chkLinkedSurveysRecursiveLoad"
        Me.chkLinkedSurveysRecursiveLoad.UseVisualStyleBackColor = True
        '
        'chkLinkedSurveysShowInCaveInfo
        '
        resources.ApplyResources(Me.chkLinkedSurveysShowInCaveInfo, "chkLinkedSurveysShowInCaveInfo")
        Me.chkLinkedSurveysShowInCaveInfo.Name = "chkLinkedSurveysShowInCaveInfo"
        Me.chkLinkedSurveysShowInCaveInfo.UseVisualStyleBackColor = True
        '
        'chkLinkedSurveysSelectOnAdd
        '
        resources.ApplyResources(Me.chkLinkedSurveysSelectOnAdd, "chkLinkedSurveysSelectOnAdd")
        Me.chkLinkedSurveysSelectOnAdd.Name = "chkLinkedSurveysSelectOnAdd"
        Me.chkLinkedSurveysSelectOnAdd.UseVisualStyleBackColor = True
        '
        'tabWMS
        '
        Me.tabWMS.Controls.Add(Me.GroupBox6)
        Me.tabWMS.Controls.Add(Me.GroupBox5)
        resources.ApplyResources(Me.tabWMS, "tabWMS")
        Me.tabWMS.Name = "tabWMS"
        Me.tabWMS.UseVisualStyleBackColor = True
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
        Me.GroupBox6.TabStop = False
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
        Me.cmdWMSFromOrthoPhotoBackgroundColor.UseVisualStyleBackColor = True
        '
        'lblPlotNoteTextColor
        '
        resources.ApplyResources(Me.lblPlotNoteTextColor, "lblPlotNoteTextColor")
        Me.lblPlotNoteTextColor.Name = "lblPlotNoteTextColor"
        '
        'picWMSFromOrthoPhotoBackgroundColor
        '
        resources.ApplyResources(Me.picWMSFromOrthoPhotoBackgroundColor, "picWMSFromOrthoPhotoBackgroundColor")
        Me.picWMSFromOrthoPhotoBackgroundColor.Name = "picWMSFromOrthoPhotoBackgroundColor"
        Me.picWMSFromOrthoPhotoBackgroundColor.TabStop = False
        Me.tipStandard.SetToolTip(Me.picWMSFromOrthoPhotoBackgroundColor, resources.GetString("picWMSFromOrthoPhotoBackgroundColor.ToolTip"))
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
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.txtWMSCacheMaxSize)
        Me.GroupBox5.Controls.Add(Me.lblWMSCacheMaxSize)
        Me.GroupBox5.Controls.Add(Me.chkWMSCacheEnabled)
        resources.ApplyResources(Me.GroupBox5, "GroupBox5")
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.TabStop = False
        '
        'btnWMSBrowse
        '
        resources.ApplyResources(Me.btnWMSBrowse, "btnWMSBrowse")
        Me.btnWMSBrowse.Image = Global.cSurveyPC.My.Resources.Resources.folder
        Me.btnWMSBrowse.Name = "btnWMSBrowse"
        Me.tipStandard.SetToolTip(Me.btnWMSBrowse, resources.GetString("btnWMSBrowse.ToolTip"))
        Me.btnWMSBrowse.UseVisualStyleBackColor = True
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
        Me.btnWMSClearCache.Image = Global.cSurveyPC.My.Resources.Resources.draw_eraser
        Me.btnWMSClearCache.Name = "btnWMSClearCache"
        Me.tipStandard.SetToolTip(Me.btnWMSClearCache, resources.GetString("btnWMSClearCache.ToolTip"))
        Me.btnWMSClearCache.UseVisualStyleBackColor = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
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
        Me.tipStandard.SetToolTip(Me.chkWMSCacheEnabled, resources.GetString("chkWMSCacheEnabled.ToolTip"))
        Me.chkWMSCacheEnabled.UseVisualStyleBackColor = True
        '
        'tabHistory
        '
        Me.tabHistory.Controls.Add(Me.tabHistorySettings)
        Me.tabHistory.Controls.Add(Me.chkAutosaveUseHistorySettings)
        Me.tabHistory.Controls.Add(Me.lblHistoryMode)
        Me.tabHistory.Controls.Add(Me.chkHistory)
        Me.tabHistory.Controls.Add(Me.chkAutosave)
        Me.tabHistory.Controls.Add(Me.cboHistoryMode)
        resources.ApplyResources(Me.tabHistory, "tabHistory")
        Me.tabHistory.Name = "tabHistory"
        Me.tabHistory.UseVisualStyleBackColor = True
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
        Me.chkHistoryArchiveOnSave.UseVisualStyleBackColor = True
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
        Me.tipStandard.SetToolTip(Me.txtHistoryMaxCopies, resources.GetString("txtHistoryMaxCopies.ToolTip"))
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
        Me.cmdHistoryFolderBrowse.UseVisualStyleBackColor = True
        '
        'txtHistoryDailyCopies
        '
        Me.txtHistoryDailyCopies.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        resources.ApplyResources(Me.txtHistoryDailyCopies, "txtHistoryDailyCopies")
        Me.txtHistoryDailyCopies.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.txtHistoryDailyCopies.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtHistoryDailyCopies.Name = "txtHistoryDailyCopies"
        Me.tipStandard.SetToolTip(Me.txtHistoryDailyCopies, resources.GetString("txtHistoryDailyCopies.ToolTip"))
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
        Me.chkHistoryWebArchiveOnSave.UseVisualStyleBackColor = True
        '
        'chkHistoryWebAuthReq
        '
        resources.ApplyResources(Me.chkHistoryWebAuthReq, "chkHistoryWebAuthReq")
        Me.chkHistoryWebAuthReq.Name = "chkHistoryWebAuthReq"
        Me.chkHistoryWebAuthReq.UseVisualStyleBackColor = True
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
        Me.tipStandard.SetToolTip(Me.txtHistoryWebMaxCopies, resources.GetString("txtHistoryWebMaxCopies.ToolTip"))
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
        Me.tipStandard.SetToolTip(Me.txtHistoryWebDailyCopies, resources.GetString("txtHistoryWebDailyCopies.ToolTip"))
        Me.txtHistoryWebDailyCopies.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'cmdHistoryWebCheck
        '
        Me.cmdHistoryWebCheck.Image = Global.cSurveyPC.My.Resources.Resources.world_link
        resources.ApplyResources(Me.cmdHistoryWebCheck, "cmdHistoryWebCheck")
        Me.cmdHistoryWebCheck.Name = "cmdHistoryWebCheck"
        Me.cmdHistoryWebCheck.UseVisualStyleBackColor = True
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
        Me.chkAutosaveUseHistorySettings.UseVisualStyleBackColor = True
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
        Me.tipStandard.SetToolTip(Me.chkHistory, resources.GetString("chkHistory.ToolTip"))
        Me.chkHistory.UseVisualStyleBackColor = True
        '
        'chkAutosave
        '
        resources.ApplyResources(Me.chkAutosave, "chkAutosave")
        Me.chkAutosave.Name = "chkAutosave"
        Me.chkAutosave.UseVisualStyleBackColor = True
        '
        'cboHistoryMode
        '
        Me.cboHistoryMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHistoryMode.DropDownWidth = 400
        resources.ApplyResources(Me.cboHistoryMode, "cboHistoryMode")
        Me.cboHistoryMode.FormattingEnabled = True
        Me.cboHistoryMode.Items.AddRange(New Object() {resources.GetString("cboHistoryMode.Items"), resources.GetString("cboHistoryMode.Items1"), resources.GetString("cboHistoryMode.Items2")})
        Me.cboHistoryMode.Name = "cboHistoryMode"
        '
        'tabDebug
        '
        Me.tabDebug.Controls.Add(Me.cboFunctionLanguage)
        Me.tabDebug.Controls.Add(Me.lblFunctionLanguage)
        Me.tabDebug.Controls.Add(Me.txtMachineID)
        Me.tabDebug.Controls.Add(Me.lblMachineID)
        Me.tabDebug.Controls.Add(Me.chkMultiThreading)
        Me.tabDebug.Controls.Add(Me.Label4)
        Me.tabDebug.Controls.Add(Me.PictureBox1)
        Me.tabDebug.Controls.Add(Me.chkCheckNewVersion)
        Me.tabDebug.Controls.Add(Me.lblSendExceptionWarning)
        Me.tabDebug.Controls.Add(Me.picSendExceptionWarning)
        Me.tabDebug.Controls.Add(Me.chkSendException)
        Me.tabDebug.Controls.Add(Me.chkLogEnabled)
        resources.ApplyResources(Me.tabDebug, "tabDebug")
        Me.tabDebug.Name = "tabDebug"
        Me.tabDebug.UseVisualStyleBackColor = True
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
        Me.txtMachineID.ReadOnly = True
        Me.tipStandard.SetToolTip(Me.txtMachineID, resources.GetString("txtMachineID.ToolTip"))
        '
        'lblMachineID
        '
        resources.ApplyResources(Me.lblMachineID, "lblMachineID")
        Me.lblMachineID.Name = "lblMachineID"
        '
        'chkMultiThreading
        '
        resources.ApplyResources(Me.chkMultiThreading, "chkMultiThreading")
        Me.chkMultiThreading.Name = "chkMultiThreading"
        Me.tipStandard.SetToolTip(Me.chkMultiThreading, resources.GetString("chkMultiThreading.ToolTip"))
        Me.chkMultiThreading.UseVisualStyleBackColor = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.cSurveyPC.My.Resources.Resources._error
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'chkCheckNewVersion
        '
        resources.ApplyResources(Me.chkCheckNewVersion, "chkCheckNewVersion")
        Me.chkCheckNewVersion.Name = "chkCheckNewVersion"
        Me.tipStandard.SetToolTip(Me.chkCheckNewVersion, resources.GetString("chkCheckNewVersion.ToolTip"))
        Me.chkCheckNewVersion.UseVisualStyleBackColor = True
        '
        'lblSendExceptionWarning
        '
        resources.ApplyResources(Me.lblSendExceptionWarning, "lblSendExceptionWarning")
        Me.lblSendExceptionWarning.Name = "lblSendExceptionWarning"
        '
        'picSendExceptionWarning
        '
        Me.picSendExceptionWarning.Image = Global.cSurveyPC.My.Resources.Resources._error
        resources.ApplyResources(Me.picSendExceptionWarning, "picSendExceptionWarning")
        Me.picSendExceptionWarning.Name = "picSendExceptionWarning"
        Me.picSendExceptionWarning.TabStop = False
        '
        'chkSendException
        '
        resources.ApplyResources(Me.chkSendException, "chkSendException")
        Me.chkSendException.Name = "chkSendException"
        Me.tipStandard.SetToolTip(Me.chkSendException, resources.GetString("chkSendException.ToolTip"))
        Me.chkSendException.UseVisualStyleBackColor = True
        '
        'chkLogEnabled
        '
        resources.ApplyResources(Me.chkLogEnabled, "chkLogEnabled")
        Me.chkLogEnabled.Name = "chkLogEnabled"
        Me.tipStandard.SetToolTip(Me.chkLogEnabled, resources.GetString("chkLogEnabled.ToolTip"))
        Me.chkLogEnabled.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.tabSettings)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.tabSettings.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.tabMain.PerformLayout()
        Me.grdFileAssociation.ResumeLayout(False)
        Me.tabOptions.ResumeLayout(False)
        Me.tabOptions.PerformLayout()
        Me.tabTherion.ResumeLayout(False)
        Me.tabTherion.PerformLayout()
        Me.frmTherionAdvancedSettings.ResumeLayout(False)
        Me.frmTherionAdvancedSettings.PerformLayout()
        Me.tabInterface.ResumeLayout(False)
        Me.tabInterface.PerformLayout()
        CType(Me.txtDesignAnchorScale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.tabDesign.ResumeLayout(False)
        Me.tabDesign.PerformLayout()
        CType(Me.txtDesignMetricGridOpacity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabGrids.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.tabSVG.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtSVGExportDPI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSVGExportScale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtSVGImportPathMaxLen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSVGImportScale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabVTopo.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.tabLinkedSurveys.ResumeLayout(False)
        Me.tabLinkedSurveys.PerformLayout()
        Me.tabWMS.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.txtWMSFromOrthoPhotoMaxHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picWMSFromOrthoPhotoBackgroundColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWMSFromOrthoPhotoMaxWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.txtWMSCacheMaxSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabHistory.ResumeLayout(False)
        Me.tabHistory.PerformLayout()
        Me.tabHistorySettings.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.txtHistoryMaxCopies, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHistoryDailyCopies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.txtHistoryWebMaxCopies, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHistoryWebDailyCopies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDebug.ResumeLayout(False)
        Me.tabDebug.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSendExceptionWarning, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabSettings As System.Windows.Forms.TabControl
    Friend WithEvents tabMain As System.Windows.Forms.TabPage
    Friend WithEvents tabTherion As System.Windows.Forms.TabPage
    Friend WithEvents cmdTherionPathBrowse As System.Windows.Forms.Button
    Friend WithEvents txtTherionPath As System.Windows.Forms.TextBox
    Friend WithEvents lblTherionPath As System.Windows.Forms.Label
    Friend WithEvents chkTherionEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents tabDesign As System.Windows.Forms.TabPage
    Friend WithEvents cboDesignMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblDesignMode As System.Windows.Forms.Label
    Friend WithEvents chkTherionBackgroundProcess As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents chkDesignShowRulers As System.Windows.Forms.CheckBox
    Friend WithEvents cboDesignQuality As System.Windows.Forms.ComboBox
    Friend WithEvents lblDesignQuality As System.Windows.Forms.Label
    Friend WithEvents txtDefaultTeam As System.Windows.Forms.TextBox
    Friend WithEvents lblDefaultTeam As System.Windows.Forms.Label
    Friend WithEvents txtDefaultClub As System.Windows.Forms.TextBox
    Friend WithEvents lblDefaultClub As System.Windows.Forms.Label
    Friend WithEvents chkTherionTrigpointSafename As System.Windows.Forms.CheckBox
    Friend WithEvents chkLogEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents tabOptions As System.Windows.Forms.TabPage
    Friend WithEvents lblDefaultCalculateMode As System.Windows.Forms.Label
    Friend WithEvents cboDefaultCalculateType As System.Windows.Forms.ComboBox
    Friend WithEvents tabSVG As System.Windows.Forms.TabPage
    Friend WithEvents txtSVGImportPathMaxLen As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPlotSelectedPointSize As System.Windows.Forms.Label
    Friend WithEvents chkSVGImportAutodivide As System.Windows.Forms.CheckBox
    Friend WithEvents lblSVGImportScale As System.Windows.Forms.Label
    Friend WithEvents txtSVGImportScale As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSVGImportLineType As System.Windows.Forms.Label
    Friend WithEvents cboSVGImportLineType As System.Windows.Forms.ComboBox
    Friend WithEvents chkSetDesignToolsEnabledByLevel As System.Windows.Forms.CheckBox
    Friend WithEvents chkSetDesignToolsHiddenByLevel As System.Windows.Forms.CheckBox
    Friend WithEvents tabVTopo As System.Windows.Forms.TabPage
    Friend WithEvents chkVTopoImportIncompatibleSet As System.Windows.Forms.CheckBox
    Friend WithEvents cboDesignLineType As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cboDesignClipBorder As System.Windows.Forms.ComboBox
    Friend WithEvents lblClipping As System.Windows.Forms.Label
    Friend WithEvents chkAutosave As System.Windows.Forms.CheckBox
    Friend WithEvents chkTherionLochEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents chkTherionDeleteTempFiles As System.Windows.Forms.CheckBox
    Friend WithEvents chkCalculateMode As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSVGExportScale As System.Windows.Forms.Label
    Friend WithEvents txtSVGExportScale As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkSVGExportNoClipping As System.Windows.Forms.CheckBox
    Friend WithEvents chkSVGExportNoClipartBrushes As System.Windows.Forms.CheckBox
    Friend WithEvents tipStandard As System.Windows.Forms.ToolTip
    Friend WithEvents lblSVGExportDPI As System.Windows.Forms.Label
    Friend WithEvents txtSVGExportDPI As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblClipboardFormats As System.Windows.Forms.Label
    Friend WithEvents lvClipboardFormats As System.Windows.Forms.ListView
    Friend WithEvents colClipboardFormat As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDesignShowRulersStyle As System.Windows.Forms.ComboBox
    Friend WithEvents chkClipboardCleanPastedStation As System.Windows.Forms.CheckBox
    Friend WithEvents txtDefaultDesigner As System.Windows.Forms.TextBox
    Friend WithEvents lblDefaultDesigner As System.Windows.Forms.Label
    Friend WithEvents tabHistory As System.Windows.Forms.TabPage
    Friend WithEvents lblHistoryMode As System.Windows.Forms.Label
    Friend WithEvents chkHistory As System.Windows.Forms.CheckBox
    Friend WithEvents cboHistoryMode As System.Windows.Forms.ComboBox
    Friend WithEvents cmdHistoryFolderBrowse As System.Windows.Forms.Button
    Friend WithEvents txtHistoryFolder As System.Windows.Forms.TextBox
    Friend WithEvents lblHistoryFolder As System.Windows.Forms.Label
    Friend WithEvents frmTherionAdvancedSettings As System.Windows.Forms.GroupBox
    Friend WithEvents chkTherionSegmentForcePath As System.Windows.Forms.CheckBox
    Friend WithEvents chkTherionSegmentForceDirection As System.Windows.Forms.CheckBox
    Friend WithEvents chkVTopoImportSetAsBranch As System.Windows.Forms.CheckBox
    Friend WithEvents cboDesignZoomType As System.Windows.Forms.ComboBox
    Friend WithEvents lblDesignZoomType As System.Windows.Forms.Label
    Friend WithEvents chkDesignUseOnlyAnchorToMove As System.Windows.Forms.CheckBox
    Friend WithEvents cboLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkAutosaveUseHistorySettings As System.Windows.Forms.CheckBox
    Friend WithEvents lblHistoryDailyCopies As System.Windows.Forms.Label
    Friend WithEvents txtHistoryDailyCopies As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblHistoryMaxCopies As System.Windows.Forms.Label
    Friend WithEvents txtHistoryMaxCopies As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmdDefaultFolder As System.Windows.Forms.Button
    Friend WithEvents txtDefaultFolder As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tabInterface As System.Windows.Forms.TabPage
    Friend WithEvents tabDebug As System.Windows.Forms.TabPage
    Friend WithEvents chkSendException As System.Windows.Forms.CheckBox
    Friend WithEvents lblSendExceptionWarning As System.Windows.Forms.Label
    Friend WithEvents picSendExceptionWarning As System.Windows.Forms.PictureBox
    Friend WithEvents chkClipboardLocalFormat As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents chkCheckNewVersion As System.Windows.Forms.CheckBox
    Friend WithEvents chkLayersShowItemPreview As System.Windows.Forms.CheckBox
    Friend WithEvents chkMultiThreading As System.Windows.Forms.CheckBox
    Friend WithEvents txtMachineID As System.Windows.Forms.TextBox
    Friend WithEvents lblMachineID As System.Windows.Forms.Label
    Friend WithEvents cboFunctionLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents lblFunctionLanguage As System.Windows.Forms.Label
    Friend WithEvents txtDefaultFont As System.Windows.Forms.TextBox
    Friend WithEvents cmdDefaultFont As System.Windows.Forms.Button
    Friend WithEvents lblDefaultFont As System.Windows.Forms.Label
    Friend WithEvents cboMaxDrawItemCount As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboDesignShowMetricGrid As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblHistoryWebPassword As System.Windows.Forms.Label
    Friend WithEvents txtHistoryWebPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblHistoryWebUsername As System.Windows.Forms.Label
    Friend WithEvents txtHistoryWebUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtHistoryWebURL As System.Windows.Forms.TextBox
    Friend WithEvents lblHistoryWebAddress As System.Windows.Forms.Label
    Friend WithEvents cmdHistoryWebCheck As System.Windows.Forms.Button
    Friend WithEvents tabHistorySettings As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lblHistoryWebMaxCopies As System.Windows.Forms.Label
    Friend WithEvents txtHistoryWebMaxCopies As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblHistoryWebDailyCopies As System.Windows.Forms.Label
    Friend WithEvents txtHistoryWebDailyCopies As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkHistoryWebAuthReq As System.Windows.Forms.CheckBox
    Friend WithEvents chkHistoryArchiveOnSave As System.Windows.Forms.CheckBox
    Friend WithEvents chkHistoryWebArchiveOnSave As System.Windows.Forms.CheckBox
    Friend WithEvents tabWMS As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtWMSCacheMaxSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblWMSCacheMaxSize As System.Windows.Forms.Label
    Friend WithEvents chkWMSCacheEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents btnWMSClearCache As System.Windows.Forms.Button
    Friend WithEvents lblWMSCacheCurrentSizeValue As System.Windows.Forms.Label
    Friend WithEvents lblWMSCacheCurrentSize As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtWMSFromOrthoPhotoMaxWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdWMSFromOrthoPhotoBackgroundColor As System.Windows.Forms.Button
    Friend WithEvents lblPlotNoteTextColor As System.Windows.Forms.Label
    Friend WithEvents picWMSFromOrthoPhotoBackgroundColor As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtWMSFromOrthoPhotoMaxHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnWMSBrowse As System.Windows.Forms.Button
    Friend WithEvents txtDesignMetricGridOpacity As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblDesignMetricGridOpacity As System.Windows.Forms.Label
    Friend WithEvents cboDesignBarPosition As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents chkShowLastUsedToolsInDesignBar As CheckBox
    Friend WithEvents chkAllowResizablePanel As CheckBox
    Friend WithEvents txtDesignAnchorScale As NumericUpDown
    Friend WithEvents lblBaseLineWidthScaleFactor As Label
    Friend WithEvents tabGrids As TabPage
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents chkShotsGridExportSplayNames As CheckBox
    Friend WithEvents chkDesignShowLegacyExtraPrintAndExportObjects As CheckBox
    Friend WithEvents cboDesignSelectionMode As ComboBox
    Friend WithEvents lblDesignSelectionMode As Label
    Friend WithEvents chkAlwaysUseShellForAttchments As CheckBox
    Friend WithEvents tabLinkedSurveys As TabPage
    Friend WithEvents chkLinkedSurveysSelectOnAdd As CheckBox
    Friend WithEvents chkLinkedSurveysShowInCaveInfo As CheckBox
    Friend WithEvents chkLinkedSurveysRecursiveLoad As CheckBox
    Friend WithEvents grdFileAssociation As GroupBox
    Friend WithEvents cmdFileAssociationCreate As Button
    Friend WithEvents cmdFileAssociationRemove As Button
End Class
