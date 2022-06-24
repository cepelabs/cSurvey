<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPreview
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreview))
        Me.pnlOptions = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.pnlMainOptions = New DevExpress.XtraEditors.PanelControl()
        Me.chkPrintTrigpointText = New DevExpress.XtraEditors.CheckEdit()
        Me.cboPrintCenterlineColorMode = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblPrintCenterlineColorMode = New DevExpress.XtraEditors.LabelControl()
        Me.chkPrintSplay = New DevExpress.XtraEditors.CheckEdit()
        Me.btnSegmentDetails = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDesignDetails = New DevExpress.XtraEditors.SimpleButton()
        Me.chkPrintCombineColorGray = New DevExpress.XtraEditors.CheckEdit()
        Me.cboPrintCombineColorMode = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblPrintCombineColorMode = New DevExpress.XtraEditors.LabelControl()
        Me.chkPrintSketches = New DevExpress.XtraEditors.CheckEdit()
        Me.chkUseDrawingZOrder = New DevExpress.XtraEditors.CheckEdit()
        Me.btnZOrderDetails = New DevExpress.XtraEditors.SimpleButton()
        Me.chkPrintDesignAdvancedBrushes = New DevExpress.XtraEditors.CheckEdit()
        Me.chkTranslations = New DevExpress.XtraEditors.CheckEdit()
        Me.btnTranslationsDetails = New DevExpress.XtraEditors.SimpleButton()
        Me.cboPrintDesignStyle = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.chkPrintDesignStyle = New DevExpress.XtraEditors.LabelControl()
        Me.cboGPSData = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblGPSData = New DevExpress.XtraEditors.LabelControl()
        Me.chkExportGPS = New DevExpress.XtraEditors.CheckEdit()
        Me.chkPrintDesignSpecialPoint = New DevExpress.XtraEditors.CheckEdit()
        Me.chkPrintImages = New DevExpress.XtraEditors.CheckEdit()
        Me.chkPrintDesign = New DevExpress.XtraEditors.CheckEdit()
        Me.chkPrintCentrelineColorGray = New DevExpress.XtraEditors.CheckEdit()
        Me.chkPrintLRUD = New DevExpress.XtraEditors.CheckEdit()
        Me.chkPrintStations = New DevExpress.XtraEditors.CheckEdit()
        Me.chkPrintShots = New DevExpress.XtraEditors.CheckEdit()
        Me.chkPrintCentreline = New DevExpress.XtraEditors.CheckEdit()
        Me.pnlCompass = New DevExpress.XtraEditors.PanelControl()
        Me.chkPrintCompass = New DevExpress.XtraEditors.CheckEdit()
        Me.Label4 = New DevExpress.XtraEditors.LabelControl()
        Me.cboCompassPosition = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btnCompassDetails = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlScale = New DevExpress.XtraEditors.PanelControl()
        Me.chkPrintScale = New DevExpress.XtraEditors.CheckEdit()
        Me.Label3 = New DevExpress.XtraEditors.LabelControl()
        Me.cboScalePosition = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btnScaleDetails = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlInformationBox = New DevExpress.XtraEditors.PanelControl()
        Me.chkPrintBox = New DevExpress.XtraEditors.CheckEdit()
        Me.Label2 = New DevExpress.XtraEditors.LabelControl()
        Me.cboBoxPosition = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btnInfoBoxDetails = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlProfile = New DevExpress.XtraEditors.PanelControl()
        Me.txtCurrentProfile = New DevExpress.XtraEditors.TextEdit()
        Me.cmdManageProfile = New DevExpress.XtraEditors.SimpleButton()
        Me.lblCurrentProfile = New DevExpress.XtraEditors.LabelControl()
        Me.pnlScaleOptions = New DevExpress.XtraEditors.PanelControl()
        Me.lblScale = New DevExpress.XtraEditors.LabelControl()
        Me.cboScale = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblScale1 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdScaleTools = New DevExpress.XtraEditors.SimpleButton()
        Me.txtScaleManual = New DevExpress.XtraEditors.SpinEdit()
        Me.pnlExportOptionsOther = New DevExpress.XtraEditors.PanelControl()
        Me.lblImageResolutionUM = New DevExpress.XtraEditors.LabelControl()
        Me.lblImageResolution = New DevExpress.XtraEditors.LabelControl()
        Me.txtImageDPI = New System.Windows.Forms.NumericUpDown()
        Me.chkBackgroundTransparent = New DevExpress.XtraEditors.CheckEdit()
        Me.pnlExportOptionsSize = New DevExpress.XtraEditors.PanelControl()
        Me.txtImageWidth = New System.Windows.Forms.NumericUpDown()
        Me.lblSize = New DevExpress.XtraEditors.LabelControl()
        Me.cboImageUM = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtImageHeight = New System.Windows.Forms.NumericUpDown()
        Me.pnlExportOptionsPage = New DevExpress.XtraEditors.PanelControl()
        Me.lblImageOrientation = New DevExpress.XtraEditors.LabelControl()
        Me.chkImageOrientationLandscape = New DevExpress.XtraEditors.CheckButton()
        Me.cmdSetImageMargins = New DevExpress.XtraEditors.SimpleButton()
        Me.chkImageOrientationPortrait = New DevExpress.XtraEditors.CheckButton()
        Me.Label1 = New DevExpress.XtraEditors.LabelControl()
        Me.cboSize = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.SvgImageCollection = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.pnlExportOptionsFormat = New DevExpress.XtraEditors.PanelControl()
        Me.cboFileFormat = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label7 = New DevExpress.XtraEditors.LabelControl()
        Me.pnlPrintOptions = New DevExpress.XtraEditors.PanelControl()
        Me.cboPageFormat = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.chkPageHorizontal = New DevExpress.XtraEditors.CheckButton()
        Me.chkPageVertical = New DevExpress.XtraEditors.CheckButton()
        Me.cmdSetMargins = New DevExpress.XtraEditors.SimpleButton()
        Me.cboPrinter = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblPrinter = New DevExpress.XtraEditors.LabelControl()
        Me.lblPageFormat = New DevExpress.XtraEditors.LabelControl()
        Me.pPreview = New cPrintController.PrintPreviewControl()
        Me.prDialog = New System.Windows.Forms.PrintDialog()
        Me.pnlExport = New DevExpress.XtraEditors.PanelControl()
        Me.picExport = New System.Windows.Forms.PictureBox()
        Me.picMap = New System.Windows.Forms.PictureBox()
        Me.pnlMap = New DevExpress.XtraEditors.PanelControl()
        Me.trkZoom = New System.Windows.Forms.TrackBar()
        Me.pnlMain = New DevExpress.XtraEditors.PanelControl()
        Me.cDesignMessageCorner = New cSurveyPC.cMessageCorner()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btnProfilesAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.btnProfilesDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.btnProperties = New DevExpress.XtraBars.BarButtonItem()
        Me.btnBaseRule = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExport = New DevExpress.XtraBars.BarButtonItem()
        Me.btnClose = New DevExpress.XtraBars.BarButtonItem()
        Me.btnZoomIn = New DevExpress.XtraBars.BarButtonItem()
        Me.btnZoomOut = New DevExpress.XtraBars.BarButtonItem()
        Me.btnZoomToFit = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSidePanel = New DevExpress.XtraBars.BarCheckItem()
        Me.btnDesignGraphicsQuality = New DevExpress.XtraBars.BarSubItem()
        Me.btnDesignGraphics0 = New DevExpress.XtraBars.BarCheckItem()
        Me.btnDesignGraphics1 = New DevExpress.XtraBars.BarCheckItem()
        Me.btnDesignGraphics2 = New DevExpress.XtraBars.BarCheckItem()
        Me.btnStop = New DevExpress.XtraBars.BarButtonItem()
        Me.btnManualRefresh = New DevExpress.XtraBars.BarCheckItem()
        Me.btnRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.pnlStatusText = New DevExpress.XtraBars.BarStaticItem()
        Me.pnlStatusDesignZoom = New DevExpress.XtraBars.BarStaticItem()
        Me.btnStatusDesignZoom100 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnStatusDesignZoom200 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnStatusDesignZoom250 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnStatusDesignZoom500 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnStatusDesignZoom1000 = New DevExpress.XtraBars.BarButtonItem()
        Me.pnlStatusCurrentRule = New DevExpress.XtraBars.BarStaticItem()
        Me.pnlStatusProgress = New DevExpress.XtraBars.BarEditItem()
        Me.pbProgress = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.btnProfileImportFromFile = New DevExpress.XtraBars.BarButtonItem()
        Me.btnProfileExportToFile = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.grpProfiles = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.grpFile = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.grpView = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.grpOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.NavBarControl1 = New DevExpress.XtraNavBar.NavBarControl()
        Me.grpMain = New DevExpress.XtraNavBar.NavBarGroup()
        Me.mnuProfiles = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.pnlForm = New DevExpress.XtraEditors.PanelControl()
        Me.flyParameters = New DevExpress.Utils.FlyoutPanel()
        Me.pnlParameters = New DevExpress.Utils.FlyoutPanelControl()
        Me.pnlOptions.SuspendLayout()
        CType(Me.pnlMainOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMainOptions.SuspendLayout()
        CType(Me.chkPrintTrigpointText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPrintCenterlineColorMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPrintSplay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPrintCombineColorGray.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPrintCombineColorMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPrintSketches.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUseDrawingZOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPrintDesignAdvancedBrushes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTranslations.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPrintDesignStyle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboGPSData.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkExportGPS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPrintDesignSpecialPoint.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPrintImages.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPrintDesign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPrintCentrelineColorGray.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPrintLRUD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPrintStations.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPrintShots.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPrintCentreline.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCompass, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCompass.SuspendLayout()
        CType(Me.chkPrintCompass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCompassPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlScale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlScale.SuspendLayout()
        CType(Me.chkPrintScale.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboScalePosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlInformationBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInformationBox.SuspendLayout()
        CType(Me.chkPrintBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBoxPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProfile.SuspendLayout()
        CType(Me.txtCurrentProfile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlScaleOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlScaleOptions.SuspendLayout()
        CType(Me.cboScale.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScaleManual.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlExportOptionsOther, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExportOptionsOther.SuspendLayout()
        CType(Me.txtImageDPI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkBackgroundTransparent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlExportOptionsSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExportOptionsSize.SuspendLayout()
        CType(Me.txtImageWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboImageUM.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImageHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlExportOptionsPage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExportOptionsPage.SuspendLayout()
        CType(Me.cboSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SvgImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlExportOptionsFormat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExportOptionsFormat.SuspendLayout()
        CType(Me.cboFileFormat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlPrintOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPrintOptions.SuspendLayout()
        CType(Me.cboPageFormat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPrinter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlExport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExport.SuspendLayout()
        CType(Me.picExport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMap.SuspendLayout()
        CType(Me.trkZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbProgress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuProfiles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlForm.SuspendLayout()
        CType(Me.flyParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flyParameters.SuspendLayout()
        CType(Me.pnlParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlOptions
        '
        Me.pnlOptions.Controls.Add(Me.pnlMainOptions)
        Me.pnlOptions.Controls.Add(Me.pnlCompass)
        Me.pnlOptions.Controls.Add(Me.pnlScale)
        Me.pnlOptions.Controls.Add(Me.pnlInformationBox)
        Me.pnlOptions.Controls.Add(Me.pnlProfile)
        Me.pnlOptions.Controls.Add(Me.pnlScaleOptions)
        Me.pnlOptions.Controls.Add(Me.pnlExportOptionsOther)
        Me.pnlOptions.Controls.Add(Me.pnlExportOptionsSize)
        Me.pnlOptions.Controls.Add(Me.pnlExportOptionsPage)
        Me.pnlOptions.Controls.Add(Me.pnlExportOptionsFormat)
        Me.pnlOptions.Controls.Add(Me.pnlPrintOptions)
        resources.ApplyResources(Me.pnlOptions, "pnlOptions")
        Me.pnlOptions.Name = "pnlOptions"
        '
        'pnlMainOptions
        '
        Me.pnlMainOptions.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlMainOptions.Controls.Add(Me.chkPrintTrigpointText)
        Me.pnlMainOptions.Controls.Add(Me.cboPrintCenterlineColorMode)
        Me.pnlMainOptions.Controls.Add(Me.lblPrintCenterlineColorMode)
        Me.pnlMainOptions.Controls.Add(Me.chkPrintSplay)
        Me.pnlMainOptions.Controls.Add(Me.btnSegmentDetails)
        Me.pnlMainOptions.Controls.Add(Me.btnDesignDetails)
        Me.pnlMainOptions.Controls.Add(Me.chkPrintCombineColorGray)
        Me.pnlMainOptions.Controls.Add(Me.cboPrintCombineColorMode)
        Me.pnlMainOptions.Controls.Add(Me.lblPrintCombineColorMode)
        Me.pnlMainOptions.Controls.Add(Me.chkPrintSketches)
        Me.pnlMainOptions.Controls.Add(Me.chkUseDrawingZOrder)
        Me.pnlMainOptions.Controls.Add(Me.btnZOrderDetails)
        Me.pnlMainOptions.Controls.Add(Me.chkPrintDesignAdvancedBrushes)
        Me.pnlMainOptions.Controls.Add(Me.chkTranslations)
        Me.pnlMainOptions.Controls.Add(Me.btnTranslationsDetails)
        Me.pnlMainOptions.Controls.Add(Me.cboPrintDesignStyle)
        Me.pnlMainOptions.Controls.Add(Me.chkPrintDesignStyle)
        Me.pnlMainOptions.Controls.Add(Me.cboGPSData)
        Me.pnlMainOptions.Controls.Add(Me.lblGPSData)
        Me.pnlMainOptions.Controls.Add(Me.chkExportGPS)
        Me.pnlMainOptions.Controls.Add(Me.chkPrintDesignSpecialPoint)
        Me.pnlMainOptions.Controls.Add(Me.chkPrintImages)
        Me.pnlMainOptions.Controls.Add(Me.chkPrintDesign)
        Me.pnlMainOptions.Controls.Add(Me.chkPrintCentrelineColorGray)
        Me.pnlMainOptions.Controls.Add(Me.chkPrintLRUD)
        Me.pnlMainOptions.Controls.Add(Me.chkPrintStations)
        Me.pnlMainOptions.Controls.Add(Me.chkPrintShots)
        Me.pnlMainOptions.Controls.Add(Me.chkPrintCentreline)
        resources.ApplyResources(Me.pnlMainOptions, "pnlMainOptions")
        Me.pnlMainOptions.Name = "pnlMainOptions"
        '
        'chkPrintTrigpointText
        '
        resources.ApplyResources(Me.chkPrintTrigpointText, "chkPrintTrigpointText")
        Me.chkPrintTrigpointText.Name = "chkPrintTrigpointText"
        Me.chkPrintTrigpointText.Properties.AutoWidth = True
        Me.chkPrintTrigpointText.Properties.Caption = resources.GetString("chkPrintTrigpointText.Properties.Caption")
        '
        'cboPrintCenterlineColorMode
        '
        resources.ApplyResources(Me.cboPrintCenterlineColorMode, "cboPrintCenterlineColorMode")
        Me.cboPrintCenterlineColorMode.Name = "cboPrintCenterlineColorMode"
        Me.cboPrintCenterlineColorMode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPrintCenterlineColorMode.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPrintCenterlineColorMode.Properties.Items.AddRange(New Object() {resources.GetString("cboPrintCenterlineColorMode.Properties.Items"), resources.GetString("cboPrintCenterlineColorMode.Properties.Items1"), resources.GetString("cboPrintCenterlineColorMode.Properties.Items2")})
        Me.cboPrintCenterlineColorMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblPrintCenterlineColorMode
        '
        Me.lblPrintCenterlineColorMode.Appearance.Font = CType(resources.GetObject("lblPrintCenterlineColorMode.Appearance.Font"), System.Drawing.Font)
        Me.lblPrintCenterlineColorMode.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPrintCenterlineColorMode, "lblPrintCenterlineColorMode")
        Me.lblPrintCenterlineColorMode.Name = "lblPrintCenterlineColorMode"
        '
        'chkPrintSplay
        '
        resources.ApplyResources(Me.chkPrintSplay, "chkPrintSplay")
        Me.chkPrintSplay.Name = "chkPrintSplay"
        Me.chkPrintSplay.Properties.Appearance.Font = CType(resources.GetObject("chkPrintSplay.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkPrintSplay.Properties.Appearance.Options.UseFont = True
        Me.chkPrintSplay.Properties.AutoWidth = True
        Me.chkPrintSplay.Properties.Caption = resources.GetString("chkPrintSplay.Properties.Caption")
        '
        'btnSegmentDetails
        '
        Me.btnSegmentDetails.ImageOptions.Image = Global.cSurveyPC.My.Resources.Resources.application_form_edit
        Me.btnSegmentDetails.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnSegmentDetails.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.edit
        Me.btnSegmentDetails.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.btnSegmentDetails, "btnSegmentDetails")
        Me.btnSegmentDetails.Name = "btnSegmentDetails"
        '
        'btnDesignDetails
        '
        Me.btnDesignDetails.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnDesignDetails.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.edit
        Me.btnDesignDetails.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.btnDesignDetails, "btnDesignDetails")
        Me.btnDesignDetails.Name = "btnDesignDetails"
        '
        'chkPrintCombineColorGray
        '
        resources.ApplyResources(Me.chkPrintCombineColorGray, "chkPrintCombineColorGray")
        Me.chkPrintCombineColorGray.Name = "chkPrintCombineColorGray"
        Me.chkPrintCombineColorGray.Properties.Appearance.Font = CType(resources.GetObject("chkPrintCombineColorGray.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkPrintCombineColorGray.Properties.Appearance.Options.UseFont = True
        Me.chkPrintCombineColorGray.Properties.AutoWidth = True
        Me.chkPrintCombineColorGray.Properties.Caption = resources.GetString("chkPrintCombineColorGray.Properties.Caption")
        '
        'cboPrintCombineColorMode
        '
        resources.ApplyResources(Me.cboPrintCombineColorMode, "cboPrintCombineColorMode")
        Me.cboPrintCombineColorMode.Name = "cboPrintCombineColorMode"
        Me.cboPrintCombineColorMode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPrintCombineColorMode.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPrintCombineColorMode.Properties.Items.AddRange(New Object() {resources.GetString("cboPrintCombineColorMode.Properties.Items"), resources.GetString("cboPrintCombineColorMode.Properties.Items1"), resources.GetString("cboPrintCombineColorMode.Properties.Items2")})
        Me.cboPrintCombineColorMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblPrintCombineColorMode
        '
        Me.lblPrintCombineColorMode.Appearance.Font = CType(resources.GetObject("lblPrintCombineColorMode.Appearance.Font"), System.Drawing.Font)
        Me.lblPrintCombineColorMode.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPrintCombineColorMode, "lblPrintCombineColorMode")
        Me.lblPrintCombineColorMode.Name = "lblPrintCombineColorMode"
        '
        'chkPrintSketches
        '
        resources.ApplyResources(Me.chkPrintSketches, "chkPrintSketches")
        Me.chkPrintSketches.Name = "chkPrintSketches"
        Me.chkPrintSketches.Properties.Appearance.Font = CType(resources.GetObject("chkPrintSketches.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkPrintSketches.Properties.Appearance.Options.UseFont = True
        Me.chkPrintSketches.Properties.AutoWidth = True
        Me.chkPrintSketches.Properties.Caption = resources.GetString("chkPrintSketches.Properties.Caption")
        '
        'chkUseDrawingZOrder
        '
        resources.ApplyResources(Me.chkUseDrawingZOrder, "chkUseDrawingZOrder")
        Me.chkUseDrawingZOrder.Name = "chkUseDrawingZOrder"
        Me.chkUseDrawingZOrder.Properties.Appearance.Font = CType(resources.GetObject("chkUseDrawingZOrder.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkUseDrawingZOrder.Properties.Appearance.Options.UseFont = True
        Me.chkUseDrawingZOrder.Properties.AutoWidth = True
        Me.chkUseDrawingZOrder.Properties.Caption = resources.GetString("chkUseDrawingZOrder.Properties.Caption")
        '
        'btnZOrderDetails
        '
        Me.btnZOrderDetails.ImageOptions.Image = CType(resources.GetObject("btnZOrderDetails.ImageOptions.Image"), System.Drawing.Image)
        Me.btnZOrderDetails.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.sortdesc
        Me.btnZOrderDetails.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.btnZOrderDetails, "btnZOrderDetails")
        Me.btnZOrderDetails.Name = "btnZOrderDetails"
        '
        'chkPrintDesignAdvancedBrushes
        '
        resources.ApplyResources(Me.chkPrintDesignAdvancedBrushes, "chkPrintDesignAdvancedBrushes")
        Me.chkPrintDesignAdvancedBrushes.Name = "chkPrintDesignAdvancedBrushes"
        Me.chkPrintDesignAdvancedBrushes.Properties.Appearance.Font = CType(resources.GetObject("chkPrintDesignAdvancedBrushes.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkPrintDesignAdvancedBrushes.Properties.Appearance.Options.UseFont = True
        Me.chkPrintDesignAdvancedBrushes.Properties.AutoWidth = True
        Me.chkPrintDesignAdvancedBrushes.Properties.Caption = resources.GetString("chkPrintDesignAdvancedBrushes.Properties.Caption")
        '
        'chkTranslations
        '
        resources.ApplyResources(Me.chkTranslations, "chkTranslations")
        Me.chkTranslations.Name = "chkTranslations"
        Me.chkTranslations.Properties.Appearance.Font = CType(resources.GetObject("chkTranslations.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkTranslations.Properties.Appearance.Options.UseFont = True
        Me.chkTranslations.Properties.AutoWidth = True
        Me.chkTranslations.Properties.Caption = resources.GetString("chkTranslations.Properties.Caption")
        '
        'btnTranslationsDetails
        '
        Me.btnTranslationsDetails.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnTranslationsDetails.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.edit
        Me.btnTranslationsDetails.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.btnTranslationsDetails, "btnTranslationsDetails")
        Me.btnTranslationsDetails.Name = "btnTranslationsDetails"
        '
        'cboPrintDesignStyle
        '
        resources.ApplyResources(Me.cboPrintDesignStyle, "cboPrintDesignStyle")
        Me.cboPrintDesignStyle.Name = "cboPrintDesignStyle"
        Me.cboPrintDesignStyle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPrintDesignStyle.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPrintDesignStyle.Properties.Items.AddRange(New Object() {resources.GetString("cboPrintDesignStyle.Properties.Items"), resources.GetString("cboPrintDesignStyle.Properties.Items1"), resources.GetString("cboPrintDesignStyle.Properties.Items2")})
        Me.cboPrintDesignStyle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'chkPrintDesignStyle
        '
        Me.chkPrintDesignStyle.Appearance.Font = CType(resources.GetObject("chkPrintDesignStyle.Appearance.Font"), System.Drawing.Font)
        Me.chkPrintDesignStyle.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.chkPrintDesignStyle, "chkPrintDesignStyle")
        Me.chkPrintDesignStyle.Name = "chkPrintDesignStyle"
        '
        'cboGPSData
        '
        resources.ApplyResources(Me.cboGPSData, "cboGPSData")
        Me.cboGPSData.Name = "cboGPSData"
        Me.cboGPSData.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboGPSData.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboGPSData.Properties.Items.AddRange(New Object() {resources.GetString("cboGPSData.Properties.Items")})
        Me.cboGPSData.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblGPSData
        '
        Me.lblGPSData.Appearance.Font = CType(resources.GetObject("lblGPSData.Appearance.Font"), System.Drawing.Font)
        Me.lblGPSData.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblGPSData, "lblGPSData")
        Me.lblGPSData.Name = "lblGPSData"
        '
        'chkExportGPS
        '
        resources.ApplyResources(Me.chkExportGPS, "chkExportGPS")
        Me.chkExportGPS.Name = "chkExportGPS"
        Me.chkExportGPS.Properties.Appearance.Font = CType(resources.GetObject("chkExportGPS.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkExportGPS.Properties.Appearance.Options.UseFont = True
        Me.chkExportGPS.Properties.AutoWidth = True
        Me.chkExportGPS.Properties.Caption = resources.GetString("chkExportGPS.Properties.Caption")
        '
        'chkPrintDesignSpecialPoint
        '
        resources.ApplyResources(Me.chkPrintDesignSpecialPoint, "chkPrintDesignSpecialPoint")
        Me.chkPrintDesignSpecialPoint.Name = "chkPrintDesignSpecialPoint"
        Me.chkPrintDesignSpecialPoint.Properties.Appearance.Font = CType(resources.GetObject("chkPrintDesignSpecialPoint.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkPrintDesignSpecialPoint.Properties.Appearance.Options.UseFont = True
        Me.chkPrintDesignSpecialPoint.Properties.AutoWidth = True
        Me.chkPrintDesignSpecialPoint.Properties.Caption = resources.GetString("chkPrintDesignSpecialPoint.Properties.Caption")
        '
        'chkPrintImages
        '
        resources.ApplyResources(Me.chkPrintImages, "chkPrintImages")
        Me.chkPrintImages.Name = "chkPrintImages"
        Me.chkPrintImages.Properties.Appearance.Font = CType(resources.GetObject("chkPrintImages.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkPrintImages.Properties.Appearance.Options.UseFont = True
        Me.chkPrintImages.Properties.AutoWidth = True
        Me.chkPrintImages.Properties.Caption = resources.GetString("chkPrintImages.Properties.Caption")
        '
        'chkPrintDesign
        '
        resources.ApplyResources(Me.chkPrintDesign, "chkPrintDesign")
        Me.chkPrintDesign.Name = "chkPrintDesign"
        Me.chkPrintDesign.Properties.Appearance.Font = CType(resources.GetObject("chkPrintDesign.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkPrintDesign.Properties.Appearance.Options.UseFont = True
        Me.chkPrintDesign.Properties.AutoWidth = True
        Me.chkPrintDesign.Properties.Caption = resources.GetString("chkPrintDesign.Properties.Caption")
        '
        'chkPrintCentrelineColorGray
        '
        resources.ApplyResources(Me.chkPrintCentrelineColorGray, "chkPrintCentrelineColorGray")
        Me.chkPrintCentrelineColorGray.Name = "chkPrintCentrelineColorGray"
        Me.chkPrintCentrelineColorGray.Properties.Appearance.Font = CType(resources.GetObject("chkPrintCentrelineColorGray.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkPrintCentrelineColorGray.Properties.Appearance.Options.UseFont = True
        Me.chkPrintCentrelineColorGray.Properties.AutoWidth = True
        Me.chkPrintCentrelineColorGray.Properties.Caption = resources.GetString("chkPrintCentrelineColorGray.Properties.Caption")
        '
        'chkPrintLRUD
        '
        resources.ApplyResources(Me.chkPrintLRUD, "chkPrintLRUD")
        Me.chkPrintLRUD.Name = "chkPrintLRUD"
        Me.chkPrintLRUD.Properties.Appearance.Font = CType(resources.GetObject("chkPrintLRUD.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkPrintLRUD.Properties.Appearance.Options.UseFont = True
        Me.chkPrintLRUD.Properties.AutoWidth = True
        Me.chkPrintLRUD.Properties.Caption = resources.GetString("chkPrintLRUD.Properties.Caption")
        '
        'chkPrintStations
        '
        resources.ApplyResources(Me.chkPrintStations, "chkPrintStations")
        Me.chkPrintStations.Name = "chkPrintStations"
        Me.chkPrintStations.Properties.Appearance.Font = CType(resources.GetObject("chkPrintStations.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkPrintStations.Properties.Appearance.Options.UseFont = True
        Me.chkPrintStations.Properties.AutoWidth = True
        Me.chkPrintStations.Properties.Caption = resources.GetString("chkPrintStations.Properties.Caption")
        '
        'chkPrintShots
        '
        resources.ApplyResources(Me.chkPrintShots, "chkPrintShots")
        Me.chkPrintShots.Name = "chkPrintShots"
        Me.chkPrintShots.Properties.Appearance.Font = CType(resources.GetObject("chkPrintShots.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkPrintShots.Properties.Appearance.Options.UseFont = True
        Me.chkPrintShots.Properties.AutoWidth = True
        Me.chkPrintShots.Properties.Caption = resources.GetString("chkPrintShots.Properties.Caption")
        '
        'chkPrintCentreline
        '
        resources.ApplyResources(Me.chkPrintCentreline, "chkPrintCentreline")
        Me.chkPrintCentreline.Name = "chkPrintCentreline"
        Me.chkPrintCentreline.Properties.Appearance.Font = CType(resources.GetObject("chkPrintCentreline.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkPrintCentreline.Properties.Appearance.Options.UseFont = True
        Me.chkPrintCentreline.Properties.AutoWidth = True
        Me.chkPrintCentreline.Properties.Caption = resources.GetString("chkPrintCentreline.Properties.Caption")
        '
        'pnlCompass
        '
        Me.pnlCompass.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlCompass.Controls.Add(Me.chkPrintCompass)
        Me.pnlCompass.Controls.Add(Me.Label4)
        Me.pnlCompass.Controls.Add(Me.cboCompassPosition)
        Me.pnlCompass.Controls.Add(Me.btnCompassDetails)
        resources.ApplyResources(Me.pnlCompass, "pnlCompass")
        Me.pnlCompass.Name = "pnlCompass"
        '
        'chkPrintCompass
        '
        resources.ApplyResources(Me.chkPrintCompass, "chkPrintCompass")
        Me.chkPrintCompass.Name = "chkPrintCompass"
        Me.chkPrintCompass.Properties.Appearance.Font = CType(resources.GetObject("chkPrintCompass.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkPrintCompass.Properties.Appearance.Options.UseFont = True
        Me.chkPrintCompass.Properties.AutoWidth = True
        Me.chkPrintCompass.Properties.Caption = resources.GetString("chkPrintCompass.Properties.Caption")
        '
        'Label4
        '
        Me.Label4.Appearance.Font = CType(resources.GetObject("Label4.Appearance.Font"), System.Drawing.Font)
        Me.Label4.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'cboCompassPosition
        '
        resources.ApplyResources(Me.cboCompassPosition, "cboCompassPosition")
        Me.cboCompassPosition.Name = "cboCompassPosition"
        Me.cboCompassPosition.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboCompassPosition.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboCompassPosition.Properties.Items.AddRange(New Object() {resources.GetString("cboCompassPosition.Properties.Items"), resources.GetString("cboCompassPosition.Properties.Items1"), resources.GetString("cboCompassPosition.Properties.Items2"), resources.GetString("cboCompassPosition.Properties.Items3")})
        Me.cboCompassPosition.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'btnCompassDetails
        '
        Me.btnCompassDetails.ImageOptions.Image = Global.cSurveyPC.My.Resources.Resources.application_form_edit
        Me.btnCompassDetails.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnCompassDetails.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.edit
        Me.btnCompassDetails.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.btnCompassDetails, "btnCompassDetails")
        Me.btnCompassDetails.Name = "btnCompassDetails"
        '
        'pnlScale
        '
        Me.pnlScale.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlScale.Controls.Add(Me.chkPrintScale)
        Me.pnlScale.Controls.Add(Me.Label3)
        Me.pnlScale.Controls.Add(Me.cboScalePosition)
        Me.pnlScale.Controls.Add(Me.btnScaleDetails)
        resources.ApplyResources(Me.pnlScale, "pnlScale")
        Me.pnlScale.Name = "pnlScale"
        '
        'chkPrintScale
        '
        resources.ApplyResources(Me.chkPrintScale, "chkPrintScale")
        Me.chkPrintScale.Name = "chkPrintScale"
        Me.chkPrintScale.Properties.Appearance.Font = CType(resources.GetObject("chkPrintScale.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkPrintScale.Properties.Appearance.Options.UseFont = True
        Me.chkPrintScale.Properties.AutoWidth = True
        Me.chkPrintScale.Properties.Caption = resources.GetString("chkPrintScale.Properties.Caption")
        '
        'Label3
        '
        Me.Label3.Appearance.Font = CType(resources.GetObject("Label3.Appearance.Font"), System.Drawing.Font)
        Me.Label3.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'cboScalePosition
        '
        resources.ApplyResources(Me.cboScalePosition, "cboScalePosition")
        Me.cboScalePosition.Name = "cboScalePosition"
        Me.cboScalePosition.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboScalePosition.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboScalePosition.Properties.Items.AddRange(New Object() {resources.GetString("cboScalePosition.Properties.Items"), resources.GetString("cboScalePosition.Properties.Items1"), resources.GetString("cboScalePosition.Properties.Items2"), resources.GetString("cboScalePosition.Properties.Items3")})
        Me.cboScalePosition.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'btnScaleDetails
        '
        Me.btnScaleDetails.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnScaleDetails.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.edit
        Me.btnScaleDetails.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.btnScaleDetails, "btnScaleDetails")
        Me.btnScaleDetails.Name = "btnScaleDetails"
        '
        'pnlInformationBox
        '
        Me.pnlInformationBox.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlInformationBox.Controls.Add(Me.chkPrintBox)
        Me.pnlInformationBox.Controls.Add(Me.Label2)
        Me.pnlInformationBox.Controls.Add(Me.cboBoxPosition)
        Me.pnlInformationBox.Controls.Add(Me.btnInfoBoxDetails)
        resources.ApplyResources(Me.pnlInformationBox, "pnlInformationBox")
        Me.pnlInformationBox.Name = "pnlInformationBox"
        '
        'chkPrintBox
        '
        resources.ApplyResources(Me.chkPrintBox, "chkPrintBox")
        Me.chkPrintBox.Name = "chkPrintBox"
        Me.chkPrintBox.Properties.Appearance.Font = CType(resources.GetObject("chkPrintBox.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkPrintBox.Properties.Appearance.Options.UseFont = True
        Me.chkPrintBox.Properties.AutoWidth = True
        Me.chkPrintBox.Properties.Caption = resources.GetString("chkPrintBox.Properties.Caption")
        '
        'Label2
        '
        Me.Label2.Appearance.Font = CType(resources.GetObject("Label2.Appearance.Font"), System.Drawing.Font)
        Me.Label2.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'cboBoxPosition
        '
        resources.ApplyResources(Me.cboBoxPosition, "cboBoxPosition")
        Me.cboBoxPosition.Name = "cboBoxPosition"
        Me.cboBoxPosition.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboBoxPosition.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboBoxPosition.Properties.Items.AddRange(New Object() {resources.GetString("cboBoxPosition.Properties.Items"), resources.GetString("cboBoxPosition.Properties.Items1"), resources.GetString("cboBoxPosition.Properties.Items2"), resources.GetString("cboBoxPosition.Properties.Items3")})
        Me.cboBoxPosition.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'btnInfoBoxDetails
        '
        Me.btnInfoBoxDetails.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnInfoBoxDetails.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.edit
        Me.btnInfoBoxDetails.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.btnInfoBoxDetails, "btnInfoBoxDetails")
        Me.btnInfoBoxDetails.Name = "btnInfoBoxDetails"
        '
        'pnlProfile
        '
        Me.pnlProfile.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlProfile.Controls.Add(Me.txtCurrentProfile)
        Me.pnlProfile.Controls.Add(Me.cmdManageProfile)
        Me.pnlProfile.Controls.Add(Me.lblCurrentProfile)
        resources.ApplyResources(Me.pnlProfile, "pnlProfile")
        Me.pnlProfile.Name = "pnlProfile"
        '
        'txtCurrentProfile
        '
        resources.ApplyResources(Me.txtCurrentProfile, "txtCurrentProfile")
        Me.txtCurrentProfile.Name = "txtCurrentProfile"
        Me.txtCurrentProfile.Properties.ReadOnly = True
        '
        'cmdManageProfile
        '
        Me.cmdManageProfile.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdManageProfile.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.profileview
        Me.cmdManageProfile.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdManageProfile, "cmdManageProfile")
        Me.cmdManageProfile.Name = "cmdManageProfile"
        '
        'lblCurrentProfile
        '
        Me.lblCurrentProfile.Appearance.Font = CType(resources.GetObject("lblCurrentProfile.Appearance.Font"), System.Drawing.Font)
        Me.lblCurrentProfile.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblCurrentProfile, "lblCurrentProfile")
        Me.lblCurrentProfile.Name = "lblCurrentProfile"
        '
        'pnlScaleOptions
        '
        Me.pnlScaleOptions.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlScaleOptions.Controls.Add(Me.lblScale)
        Me.pnlScaleOptions.Controls.Add(Me.cboScale)
        Me.pnlScaleOptions.Controls.Add(Me.lblScale1)
        Me.pnlScaleOptions.Controls.Add(Me.cmdScaleTools)
        Me.pnlScaleOptions.Controls.Add(Me.txtScaleManual)
        resources.ApplyResources(Me.pnlScaleOptions, "pnlScaleOptions")
        Me.pnlScaleOptions.Name = "pnlScaleOptions"
        '
        'lblScale
        '
        Me.lblScale.Appearance.Font = CType(resources.GetObject("lblScale.Appearance.Font"), System.Drawing.Font)
        Me.lblScale.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblScale, "lblScale")
        Me.lblScale.Name = "lblScale"
        '
        'cboScale
        '
        resources.ApplyResources(Me.cboScale, "cboScale")
        Me.cboScale.Name = "cboScale"
        Me.cboScale.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboScale.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboScale.Properties.Items.AddRange(New Object() {resources.GetString("cboScale.Properties.Items"), resources.GetString("cboScale.Properties.Items1"), resources.GetString("cboScale.Properties.Items2"), resources.GetString("cboScale.Properties.Items3"), resources.GetString("cboScale.Properties.Items4"), resources.GetString("cboScale.Properties.Items5"), resources.GetString("cboScale.Properties.Items6"), resources.GetString("cboScale.Properties.Items7"), resources.GetString("cboScale.Properties.Items8"), resources.GetString("cboScale.Properties.Items9"), resources.GetString("cboScale.Properties.Items10"), resources.GetString("cboScale.Properties.Items11")})
        Me.cboScale.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblScale1
        '
        Me.lblScale1.Appearance.Font = CType(resources.GetObject("lblScale1.Appearance.Font"), System.Drawing.Font)
        Me.lblScale1.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblScale1, "lblScale1")
        Me.lblScale1.Name = "lblScale1"
        '
        'cmdScaleTools
        '
        Me.cmdScaleTools.ImageOptions.Image = Global.cSurveyPC.My.Resources.Resources.scale_image
        Me.cmdScaleTools.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdScaleTools.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.scale
        Me.cmdScaleTools.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdScaleTools, "cmdScaleTools")
        Me.cmdScaleTools.Name = "cmdScaleTools"
        '
        'txtScaleManual
        '
        resources.ApplyResources(Me.txtScaleManual, "txtScaleManual")
        Me.txtScaleManual.Name = "txtScaleManual"
        Me.txtScaleManual.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtScaleManual.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtScaleManual.Properties.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        Me.txtScaleManual.Properties.IsFloatValue = False
        Me.txtScaleManual.Properties.MaskSettings.Set("mask", "N00")
        Me.txtScaleManual.Properties.MaxValue = New Decimal(New Integer() {50000, 0, 0, 0})
        Me.txtScaleManual.Properties.MinValue = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'pnlExportOptionsOther
        '
        Me.pnlExportOptionsOther.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlExportOptionsOther.Controls.Add(Me.lblImageResolutionUM)
        Me.pnlExportOptionsOther.Controls.Add(Me.lblImageResolution)
        Me.pnlExportOptionsOther.Controls.Add(Me.txtImageDPI)
        Me.pnlExportOptionsOther.Controls.Add(Me.chkBackgroundTransparent)
        resources.ApplyResources(Me.pnlExportOptionsOther, "pnlExportOptionsOther")
        Me.pnlExportOptionsOther.Name = "pnlExportOptionsOther"
        '
        'lblImageResolutionUM
        '
        resources.ApplyResources(Me.lblImageResolutionUM, "lblImageResolutionUM")
        Me.lblImageResolutionUM.Name = "lblImageResolutionUM"
        '
        'lblImageResolution
        '
        resources.ApplyResources(Me.lblImageResolution, "lblImageResolution")
        Me.lblImageResolution.Name = "lblImageResolution"
        '
        'txtImageDPI
        '
        resources.ApplyResources(Me.txtImageDPI, "txtImageDPI")
        Me.txtImageDPI.Maximum = New Decimal(New Integer() {65536, 0, 0, 0})
        Me.txtImageDPI.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.txtImageDPI.Name = "txtImageDPI"
        Me.txtImageDPI.Value = New Decimal(New Integer() {96, 0, 0, 0})
        '
        'chkBackgroundTransparent
        '
        resources.ApplyResources(Me.chkBackgroundTransparent, "chkBackgroundTransparent")
        Me.chkBackgroundTransparent.Name = "chkBackgroundTransparent"
        Me.chkBackgroundTransparent.Properties.AutoWidth = True
        Me.chkBackgroundTransparent.Properties.Caption = resources.GetString("chkBackgroundTransparent.Properties.Caption")
        '
        'pnlExportOptionsSize
        '
        Me.pnlExportOptionsSize.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlExportOptionsSize.Controls.Add(Me.txtImageWidth)
        Me.pnlExportOptionsSize.Controls.Add(Me.lblSize)
        Me.pnlExportOptionsSize.Controls.Add(Me.cboImageUM)
        Me.pnlExportOptionsSize.Controls.Add(Me.txtImageHeight)
        resources.ApplyResources(Me.pnlExportOptionsSize, "pnlExportOptionsSize")
        Me.pnlExportOptionsSize.Name = "pnlExportOptionsSize"
        '
        'txtImageWidth
        '
        resources.ApplyResources(Me.txtImageWidth, "txtImageWidth")
        Me.txtImageWidth.Maximum = New Decimal(New Integer() {65536, 0, 0, 0})
        Me.txtImageWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtImageWidth.Name = "txtImageWidth"
        Me.txtImageWidth.Value = New Decimal(New Integer() {4096, 0, 0, 0})
        '
        'lblSize
        '
        resources.ApplyResources(Me.lblSize, "lblSize")
        Me.lblSize.Name = "lblSize"
        '
        'cboImageUM
        '
        resources.ApplyResources(Me.cboImageUM, "cboImageUM")
        Me.cboImageUM.Name = "cboImageUM"
        Me.cboImageUM.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboImageUM.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboImageUM.Properties.Items.AddRange(New Object() {resources.GetString("cboImageUM.Properties.Items"), resources.GetString("cboImageUM.Properties.Items1"), resources.GetString("cboImageUM.Properties.Items2"), resources.GetString("cboImageUM.Properties.Items3")})
        Me.cboImageUM.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'txtImageHeight
        '
        resources.ApplyResources(Me.txtImageHeight, "txtImageHeight")
        Me.txtImageHeight.Maximum = New Decimal(New Integer() {65536, 0, 0, 0})
        Me.txtImageHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtImageHeight.Name = "txtImageHeight"
        Me.txtImageHeight.Value = New Decimal(New Integer() {3072, 0, 0, 0})
        '
        'pnlExportOptionsPage
        '
        Me.pnlExportOptionsPage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlExportOptionsPage.Controls.Add(Me.lblImageOrientation)
        Me.pnlExportOptionsPage.Controls.Add(Me.chkImageOrientationLandscape)
        Me.pnlExportOptionsPage.Controls.Add(Me.cmdSetImageMargins)
        Me.pnlExportOptionsPage.Controls.Add(Me.chkImageOrientationPortrait)
        Me.pnlExportOptionsPage.Controls.Add(Me.Label1)
        Me.pnlExportOptionsPage.Controls.Add(Me.cboSize)
        resources.ApplyResources(Me.pnlExportOptionsPage, "pnlExportOptionsPage")
        Me.pnlExportOptionsPage.Name = "pnlExportOptionsPage"
        '
        'lblImageOrientation
        '
        resources.ApplyResources(Me.lblImageOrientation, "lblImageOrientation")
        Me.lblImageOrientation.Name = "lblImageOrientation"
        '
        'chkImageOrientationLandscape
        '
        Me.chkImageOrientationLandscape.GroupIndex = 1
        Me.chkImageOrientationLandscape.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkImageOrientationLandscape.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.landscape
        Me.chkImageOrientationLandscape.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkImageOrientationLandscape, "chkImageOrientationLandscape")
        Me.chkImageOrientationLandscape.Name = "chkImageOrientationLandscape"
        Me.chkImageOrientationLandscape.TabStop = False
        '
        'cmdSetImageMargins
        '
        Me.cmdSetImageMargins.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdSetImageMargins.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.richeditpagemargins
        Me.cmdSetImageMargins.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdSetImageMargins, "cmdSetImageMargins")
        Me.cmdSetImageMargins.Name = "cmdSetImageMargins"
        '
        'chkImageOrientationPortrait
        '
        Me.chkImageOrientationPortrait.Checked = True
        Me.chkImageOrientationPortrait.GroupIndex = 1
        Me.chkImageOrientationPortrait.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkImageOrientationPortrait.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.page1
        Me.chkImageOrientationPortrait.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkImageOrientationPortrait, "chkImageOrientationPortrait")
        Me.chkImageOrientationPortrait.Name = "chkImageOrientationPortrait"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'cboSize
        '
        resources.ApplyResources(Me.cboSize, "cboSize")
        Me.cboSize.Name = "cboSize"
        Me.cboSize.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboSize.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboSize.Properties.LargeImages = Me.SvgImageCollection
        Me.cboSize.Properties.SmallImages = Me.SvgImageCollection
        '
        'SvgImageCollection
        '
        Me.SvgImageCollection.ImageSize = New System.Drawing.Size(32, 32)
        Me.SvgImageCollection.Add("page1", "page1", GetType(cSurveyPC.My.Resources.Resources))
        '
        'pnlExportOptionsFormat
        '
        Me.pnlExportOptionsFormat.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlExportOptionsFormat.Controls.Add(Me.cboFileFormat)
        Me.pnlExportOptionsFormat.Controls.Add(Me.Label7)
        resources.ApplyResources(Me.pnlExportOptionsFormat, "pnlExportOptionsFormat")
        Me.pnlExportOptionsFormat.Name = "pnlExportOptionsFormat"
        '
        'cboFileFormat
        '
        resources.ApplyResources(Me.cboFileFormat, "cboFileFormat")
        Me.cboFileFormat.Name = "cboFileFormat"
        Me.cboFileFormat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboFileFormat.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboFileFormat.Properties.Items.AddRange(New Object() {resources.GetString("cboFileFormat.Properties.Items"), resources.GetString("cboFileFormat.Properties.Items1"), resources.GetString("cboFileFormat.Properties.Items2"), resources.GetString("cboFileFormat.Properties.Items3"), resources.GetString("cboFileFormat.Properties.Items4")})
        Me.cboFileFormat.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'Label7
        '
        Me.Label7.Appearance.Font = CType(resources.GetObject("Label7.Appearance.Font"), System.Drawing.Font)
        Me.Label7.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'pnlPrintOptions
        '
        Me.pnlPrintOptions.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlPrintOptions.Controls.Add(Me.cboPageFormat)
        Me.pnlPrintOptions.Controls.Add(Me.LabelControl1)
        Me.pnlPrintOptions.Controls.Add(Me.chkPageHorizontal)
        Me.pnlPrintOptions.Controls.Add(Me.chkPageVertical)
        Me.pnlPrintOptions.Controls.Add(Me.cmdSetMargins)
        Me.pnlPrintOptions.Controls.Add(Me.cboPrinter)
        Me.pnlPrintOptions.Controls.Add(Me.lblPrinter)
        Me.pnlPrintOptions.Controls.Add(Me.lblPageFormat)
        resources.ApplyResources(Me.pnlPrintOptions, "pnlPrintOptions")
        Me.pnlPrintOptions.Name = "pnlPrintOptions"
        '
        'cboPageFormat
        '
        resources.ApplyResources(Me.cboPageFormat, "cboPageFormat")
        Me.cboPageFormat.Name = "cboPageFormat"
        Me.cboPageFormat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPageFormat.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPageFormat.Properties.LargeImages = Me.SvgImageCollection
        Me.cboPageFormat.Properties.SmallImages = Me.SvgImageCollection
        '
        'LabelControl1
        '
        resources.ApplyResources(Me.LabelControl1, "LabelControl1")
        Me.LabelControl1.Name = "LabelControl1"
        '
        'chkPageHorizontal
        '
        Me.chkPageHorizontal.GroupIndex = 2
        Me.chkPageHorizontal.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkPageHorizontal.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.landscape
        Me.chkPageHorizontal.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkPageHorizontal, "chkPageHorizontal")
        Me.chkPageHorizontal.Name = "chkPageHorizontal"
        Me.chkPageHorizontal.TabStop = False
        '
        'chkPageVertical
        '
        Me.chkPageVertical.Checked = True
        Me.chkPageVertical.GroupIndex = 2
        Me.chkPageVertical.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkPageVertical.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.page1
        Me.chkPageVertical.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkPageVertical, "chkPageVertical")
        Me.chkPageVertical.Name = "chkPageVertical"
        '
        'cmdSetMargins
        '
        Me.cmdSetMargins.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdSetMargins.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.richeditpagemargins
        Me.cmdSetMargins.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdSetMargins, "cmdSetMargins")
        Me.cmdSetMargins.Name = "cmdSetMargins"
        '
        'cboPrinter
        '
        resources.ApplyResources(Me.cboPrinter, "cboPrinter")
        Me.cboPrinter.Name = "cboPrinter"
        Me.cboPrinter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPrinter.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPrinter.Properties.Sorted = True
        Me.cboPrinter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblPrinter
        '
        Me.lblPrinter.Appearance.Font = CType(resources.GetObject("lblPrinter.Appearance.Font"), System.Drawing.Font)
        Me.lblPrinter.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPrinter, "lblPrinter")
        Me.lblPrinter.Name = "lblPrinter"
        '
        'lblPageFormat
        '
        Me.lblPageFormat.Appearance.Font = CType(resources.GetObject("lblPageFormat.Appearance.Font"), System.Drawing.Font)
        Me.lblPageFormat.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPageFormat, "lblPageFormat")
        Me.lblPageFormat.Name = "lblPageFormat"
        '
        'pPreview
        '
        Me.pPreview.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pPreview.ForeColor = System.Drawing.Color.White
        resources.ApplyResources(Me.pPreview, "pPreview")
        Me.pPreview.Name = "pPreview"
        Me.pPreview.UseAntiAlias = True
        '
        'prDialog
        '
        Me.prDialog.UseEXDialog = True
        '
        'pnlExport
        '
        Me.pnlExport.Appearance.BackColor = System.Drawing.Color.White
        Me.pnlExport.Appearance.Options.UseBackColor = True
        Me.pnlExport.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlExport.Controls.Add(Me.picExport)
        resources.ApplyResources(Me.pnlExport, "pnlExport")
        Me.pnlExport.Name = "pnlExport"
        '
        'picExport
        '
        resources.ApplyResources(Me.picExport, "picExport")
        Me.picExport.Name = "picExport"
        Me.picExport.TabStop = False
        '
        'picMap
        '
        Me.picMap.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.picMap, "picMap")
        Me.picMap.Name = "picMap"
        Me.picMap.TabStop = False
        '
        'pnlMap
        '
        Me.pnlMap.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlMap.Controls.Add(Me.picMap)
        resources.ApplyResources(Me.pnlMap, "pnlMap")
        Me.pnlMap.Name = "pnlMap"
        '
        'trkZoom
        '
        resources.ApplyResources(Me.trkZoom, "trkZoom")
        Me.trkZoom.LargeChange = 10
        Me.trkZoom.Maximum = 4000
        Me.trkZoom.Minimum = 2
        Me.trkZoom.Name = "trkZoom"
        Me.trkZoom.TickFrequency = 200
        Me.trkZoom.TickStyle = System.Windows.Forms.TickStyle.None
        Me.trkZoom.Value = 20
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlMain.Controls.Add(Me.cDesignMessageCorner)
        Me.pnlMain.Controls.Add(Me.pnlMap)
        Me.pnlMain.Controls.Add(Me.pnlExport)
        Me.pnlMain.Controls.Add(Me.pPreview)
        resources.ApplyResources(Me.pnlMain, "pnlMain")
        Me.pnlMain.Name = "pnlMain"
        '
        'cDesignMessageCorner
        '
        Me.cDesignMessageCorner.AllowClick = False
        Me.cDesignMessageCorner.Appearance.BackColor = System.Drawing.Color.LemonChiffon
        Me.cDesignMessageCorner.Appearance.Options.UseBackColor = True
        Me.cDesignMessageCorner.CustomButtonCaption = "Refresh"
        Me.cDesignMessageCorner.CustomButtonTooltip = ""
        resources.ApplyResources(Me.cDesignMessageCorner, "cDesignMessageCorner")
        Me.cDesignMessageCorner.Name = "cDesignMessageCorner"
        '
        'RibbonControl1
        '
        Me.RibbonControl1.AutoHideEmptyItems = True
        Me.RibbonControl1.Categories.AddRange(New DevExpress.XtraBars.BarManagerCategory() {CType(resources.GetObject("RibbonControl1.Categories"), DevExpress.XtraBars.BarManagerCategory), CType(resources.GetObject("RibbonControl1.Categories1"), DevExpress.XtraBars.BarManagerCategory), CType(resources.GetObject("RibbonControl1.Categories2"), DevExpress.XtraBars.BarManagerCategory)})
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.btnProfilesAdd, Me.btnProfilesDelete, Me.btnProperties, Me.btnBaseRule, Me.btnPrint, Me.btnExport, Me.btnClose, Me.btnZoomIn, Me.btnZoomOut, Me.btnZoomToFit, Me.btnSidePanel, Me.btnDesignGraphicsQuality, Me.btnStop, Me.btnDesignGraphics0, Me.btnDesignGraphics1, Me.btnDesignGraphics2, Me.btnManualRefresh, Me.btnRefresh, Me.pnlStatusText, Me.pnlStatusDesignZoom, Me.btnStatusDesignZoom100, Me.btnStatusDesignZoom200, Me.btnStatusDesignZoom250, Me.btnStatusDesignZoom500, Me.btnStatusDesignZoom1000, Me.pnlStatusCurrentRule, Me.pnlStatusProgress, Me.btnProfileImportFromFile, Me.btnProfileExportToFile})
        resources.ApplyResources(Me.RibbonControl1, "RibbonControl1")
        Me.RibbonControl1.MaxItemId = 30
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.QuickToolbarItemLinks.Add(Me.btnExport)
        Me.RibbonControl1.QuickToolbarItemLinks.Add(Me.btnPrint)
        Me.RibbonControl1.QuickToolbarItemLinks.Add(Me.btnProperties, True)
        Me.RibbonControl1.QuickToolbarItemLinks.Add(Me.btnManualRefresh, True)
        Me.RibbonControl1.QuickToolbarItemLinks.Add(Me.btnStop, True)
        Me.RibbonControl1.QuickToolbarItemLinks.Add(Me.btnRefresh, True)
        Me.RibbonControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.pbProgress})
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.ShowOnMultiplePages
        Me.RibbonControl1.StatusBar = Me.RibbonStatusBar1
        '
        'btnProfilesAdd
        '
        resources.ApplyResources(Me.btnProfilesAdd, "btnProfilesAdd")
        Me.btnProfilesAdd.CategoryGuid = New System.Guid("80636958-5eeb-4fe0-9ba8-e829c0d551af")
        Me.btnProfilesAdd.Id = 1
        Me.btnProfilesAdd.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_add
        Me.btnProfilesAdd.Name = "btnProfilesAdd"
        '
        'btnProfilesDelete
        '
        resources.ApplyResources(Me.btnProfilesDelete, "btnProfilesDelete")
        Me.btnProfilesDelete.CategoryGuid = New System.Guid("80636958-5eeb-4fe0-9ba8-e829c0d551af")
        Me.btnProfilesDelete.Enabled = False
        Me.btnProfilesDelete.Id = 2
        Me.btnProfilesDelete.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.delete1
        Me.btnProfilesDelete.Name = "btnProfilesDelete"
        '
        'btnProperties
        '
        resources.ApplyResources(Me.btnProperties, "btnProperties")
        Me.btnProperties.CategoryGuid = New System.Guid("274e18f2-42b6-4ff2-84a6-446354866455")
        Me.btnProperties.Id = 3
        Me.btnProperties.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.properties
        Me.btnProperties.Name = "btnProperties"
        '
        'btnBaseRule
        '
        resources.ApplyResources(Me.btnBaseRule, "btnBaseRule")
        Me.btnBaseRule.CategoryGuid = New System.Guid("274e18f2-42b6-4ff2-84a6-446354866455")
        Me.btnBaseRule.Id = 4
        Me.btnBaseRule.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.scale
        Me.btnBaseRule.Name = "btnBaseRule"
        '
        'btnPrint
        '
        resources.ApplyResources(Me.btnPrint, "btnPrint")
        Me.btnPrint.CategoryGuid = New System.Guid("80636958-5eeb-4fe0-9ba8-e829c0d551af")
        Me.btnPrint.Id = 5
        Me.btnPrint.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.print
        Me.btnPrint.Name = "btnPrint"
        '
        'btnExport
        '
        resources.ApplyResources(Me.btnExport, "btnExport")
        Me.btnExport.CategoryGuid = New System.Guid("80636958-5eeb-4fe0-9ba8-e829c0d551af")
        Me.btnExport.Id = 6
        Me.btnExport.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.exportfile
        Me.btnExport.Name = "btnExport"
        '
        'btnClose
        '
        resources.ApplyResources(Me.btnClose, "btnClose")
        Me.btnClose.Id = 7
        Me.btnClose.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.close
        Me.btnClose.Name = "btnClose"
        '
        'btnZoomIn
        '
        resources.ApplyResources(Me.btnZoomIn, "btnZoomIn")
        Me.btnZoomIn.CategoryGuid = New System.Guid("d65b7d25-b6f0-49fa-8847-69b0c824ef21")
        Me.btnZoomIn.Id = 8
        Me.btnZoomIn.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.zoomin
        Me.btnZoomIn.Name = "btnZoomIn"
        Me.btnZoomIn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText
        '
        'btnZoomOut
        '
        resources.ApplyResources(Me.btnZoomOut, "btnZoomOut")
        Me.btnZoomOut.CategoryGuid = New System.Guid("d65b7d25-b6f0-49fa-8847-69b0c824ef21")
        Me.btnZoomOut.Id = 9
        Me.btnZoomOut.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.zoomout
        Me.btnZoomOut.Name = "btnZoomOut"
        Me.btnZoomOut.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText
        '
        'btnZoomToFit
        '
        resources.ApplyResources(Me.btnZoomToFit, "btnZoomToFit")
        Me.btnZoomToFit.CategoryGuid = New System.Guid("d65b7d25-b6f0-49fa-8847-69b0c824ef21")
        Me.btnZoomToFit.Id = 10
        Me.btnZoomToFit.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.panandzoompanel
        Me.btnZoomToFit.ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4)
        Me.btnZoomToFit.Name = "btnZoomToFit"
        Me.btnZoomToFit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText
        '
        'btnSidePanel
        '
        resources.ApplyResources(Me.btnSidePanel, "btnSidePanel")
        Me.btnSidePanel.CategoryGuid = New System.Guid("d65b7d25-b6f0-49fa-8847-69b0c824ef21")
        Me.btnSidePanel.Id = 11
        Me.btnSidePanel.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.folderpanel
        Me.btnSidePanel.Name = "btnSidePanel"
        Me.btnSidePanel.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText
        '
        'btnDesignGraphicsQuality
        '
        resources.ApplyResources(Me.btnDesignGraphicsQuality, "btnDesignGraphicsQuality")
        Me.btnDesignGraphicsQuality.Id = 142
        Me.btnDesignGraphicsQuality.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.gaugestylehalfcircular
        Me.btnDesignGraphicsQuality.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnDesignGraphics0), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDesignGraphics1), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDesignGraphics2)})
        Me.btnDesignGraphicsQuality.Name = "btnDesignGraphicsQuality"
        '
        'btnDesignGraphics0
        '
        resources.ApplyResources(Me.btnDesignGraphics0, "btnDesignGraphics0")
        Me.btnDesignGraphics0.GroupIndex = 1
        Me.btnDesignGraphics0.Id = 14
        Me.btnDesignGraphics0.Name = "btnDesignGraphics0"
        '
        'btnDesignGraphics1
        '
        resources.ApplyResources(Me.btnDesignGraphics1, "btnDesignGraphics1")
        Me.btnDesignGraphics1.GroupIndex = 1
        Me.btnDesignGraphics1.Id = 15
        Me.btnDesignGraphics1.Name = "btnDesignGraphics1"
        '
        'btnDesignGraphics2
        '
        resources.ApplyResources(Me.btnDesignGraphics2, "btnDesignGraphics2")
        Me.btnDesignGraphics2.GroupIndex = 1
        Me.btnDesignGraphics2.Id = 16
        Me.btnDesignGraphics2.Name = "btnDesignGraphics2"
        '
        'btnStop
        '
        resources.ApplyResources(Me.btnStop, "btnStop")
        Me.btnStop.Id = 12
        Me.btnStop.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources._stop
        Me.btnStop.Name = "btnStop"
        '
        'btnManualRefresh
        '
        resources.ApplyResources(Me.btnManualRefresh, "btnManualRefresh")
        Me.btnManualRefresh.Id = 17
        Me.btnManualRefresh.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.manualrefresh
        Me.btnManualRefresh.Name = "btnManualRefresh"
        '
        'btnRefresh
        '
        resources.ApplyResources(Me.btnRefresh, "btnRefresh")
        Me.btnRefresh.Id = 18
        Me.btnRefresh.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_refresh
        Me.btnRefresh.Name = "btnRefresh"
        '
        'pnlStatusText
        '
        Me.pnlStatusText.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring
        Me.pnlStatusText.Id = 19
        Me.pnlStatusText.Name = "pnlStatusText"
        '
        'pnlStatusDesignZoom
        '
        Me.pnlStatusDesignZoom.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.pnlStatusDesignZoom, "pnlStatusDesignZoom")
        Me.pnlStatusDesignZoom.Id = 20
        Me.pnlStatusDesignZoom.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.zoom
        Me.pnlStatusDesignZoom.Name = "pnlStatusDesignZoom"
        Me.pnlStatusDesignZoom.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'btnStatusDesignZoom100
        '
        Me.btnStatusDesignZoom100.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.btnStatusDesignZoom100, "btnStatusDesignZoom100")
        Me.btnStatusDesignZoom100.Id = 21
        Me.btnStatusDesignZoom100.Name = "btnStatusDesignZoom100"
        '
        'btnStatusDesignZoom200
        '
        Me.btnStatusDesignZoom200.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.btnStatusDesignZoom200, "btnStatusDesignZoom200")
        Me.btnStatusDesignZoom200.Id = 22
        Me.btnStatusDesignZoom200.Name = "btnStatusDesignZoom200"
        '
        'btnStatusDesignZoom250
        '
        Me.btnStatusDesignZoom250.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.btnStatusDesignZoom250, "btnStatusDesignZoom250")
        Me.btnStatusDesignZoom250.Id = 23
        Me.btnStatusDesignZoom250.Name = "btnStatusDesignZoom250"
        '
        'btnStatusDesignZoom500
        '
        Me.btnStatusDesignZoom500.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.btnStatusDesignZoom500, "btnStatusDesignZoom500")
        Me.btnStatusDesignZoom500.Id = 24
        Me.btnStatusDesignZoom500.Name = "btnStatusDesignZoom500"
        '
        'btnStatusDesignZoom1000
        '
        Me.btnStatusDesignZoom1000.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.btnStatusDesignZoom1000, "btnStatusDesignZoom1000")
        Me.btnStatusDesignZoom1000.Id = 25
        Me.btnStatusDesignZoom1000.Name = "btnStatusDesignZoom1000"
        '
        'pnlStatusCurrentRule
        '
        Me.pnlStatusCurrentRule.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.pnlStatusCurrentRule, "pnlStatusCurrentRule")
        Me.pnlStatusCurrentRule.Id = 26
        Me.pnlStatusCurrentRule.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.scale
        Me.pnlStatusCurrentRule.Name = "pnlStatusCurrentRule"
        Me.pnlStatusCurrentRule.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'pnlStatusProgress
        '
        Me.pnlStatusProgress.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.pnlStatusProgress.Edit = Me.pbProgress
        resources.ApplyResources(Me.pnlStatusProgress, "pnlStatusProgress")
        Me.pnlStatusProgress.Id = 27
        Me.pnlStatusProgress.Name = "pnlStatusProgress"
        Me.pnlStatusProgress.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'pbProgress
        '
        Me.pbProgress.Name = "pbProgress"
        '
        'btnProfileImportFromFile
        '
        resources.ApplyResources(Me.btnProfileImportFromFile, "btnProfileImportFromFile")
        Me.btnProfileImportFromFile.Enabled = False
        Me.btnProfileImportFromFile.Id = 28
        Me.btnProfileImportFromFile.Name = "btnProfileImportFromFile"
        '
        'btnProfileExportToFile
        '
        resources.ApplyResources(Me.btnProfileExportToFile, "btnProfileExportToFile")
        Me.btnProfileExportToFile.Enabled = False
        Me.btnProfileExportToFile.Id = 29
        Me.btnProfileExportToFile.Name = "btnProfileExportToFile"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.grpProfiles, Me.grpFile, Me.grpView, Me.grpOptions, Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        resources.ApplyResources(Me.RibbonPage1, "RibbonPage1")
        '
        'grpProfiles
        '
        Me.grpProfiles.ItemLinks.Add(Me.btnProfilesAdd)
        Me.grpProfiles.ItemLinks.Add(Me.btnProfilesDelete)
        Me.grpProfiles.ItemLinks.Add(Me.btnExport, True)
        Me.grpProfiles.ItemLinks.Add(Me.btnPrint)
        Me.grpProfiles.Name = "grpProfiles"
        resources.ApplyResources(Me.grpProfiles, "grpProfiles")
        '
        'grpFile
        '
        Me.grpFile.ItemLinks.Add(Me.btnProperties)
        Me.grpFile.Name = "grpFile"
        resources.ApplyResources(Me.grpFile, "grpFile")
        '
        'grpView
        '
        Me.grpView.ItemLinks.Add(Me.btnZoomIn)
        Me.grpView.ItemLinks.Add(Me.btnZoomOut)
        Me.grpView.ItemLinks.Add(Me.btnZoomToFit)
        Me.grpView.ItemLinks.Add(Me.btnSidePanel, True)
        Me.grpView.Name = "grpView"
        resources.ApplyResources(Me.grpView, "grpView")
        '
        'grpOptions
        '
        Me.grpOptions.ItemLinks.Add(Me.btnDesignGraphicsQuality)
        Me.grpOptions.ItemLinks.Add(Me.btnManualRefresh, True)
        Me.grpOptions.Name = "grpOptions"
        resources.ApplyResources(Me.grpOptions, "grpOptions")
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnBaseRule)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnStop, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnRefresh, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnClose, True)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        resources.ApplyResources(Me.RibbonPageGroup1, "RibbonPageGroup1")
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.ItemLinks.Add(Me.pnlStatusText)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.pnlStatusProgress, True)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.pnlStatusCurrentRule)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.pnlStatusDesignZoom, True)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.btnStatusDesignZoom100, True)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.btnStatusDesignZoom200)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.btnStatusDesignZoom250)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.btnStatusDesignZoom500)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.btnStatusDesignZoom1000)
        resources.ApplyResources(Me.RibbonStatusBar1, "RibbonStatusBar1")
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.RibbonControl1
        '
        'NavBarControl1
        '
        Me.NavBarControl1.ActiveGroup = Me.grpMain
        Me.NavBarControl1.AllowHtmlString = True
        Me.NavBarControl1.Appearance.ItemActive.BackColor = System.Drawing.SystemColors.Highlight
        Me.NavBarControl1.Appearance.ItemActive.Options.UseBackColor = True
        Me.NavBarControl1.Appearance.ItemPressed.BackColor = System.Drawing.SystemColors.Highlight
        Me.NavBarControl1.Appearance.ItemPressed.Options.UseBackColor = True
        resources.ApplyResources(Me.NavBarControl1, "NavBarControl1")
        Me.NavBarControl1.ExplorerBarShowGroupButtons = False
        Me.NavBarControl1.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.grpMain})
        Me.NavBarControl1.LinkSelectionMode = DevExpress.XtraNavBar.LinkSelectionModeType.OneInControl
        Me.NavBarControl1.MenuManager = Me.RibbonControl1
        Me.NavBarControl1.Name = "NavBarControl1"
        Me.NavBarControl1.OptionsNavPane.ExpandedWidth = CType(resources.GetObject("resource.ExpandedWidth"), Integer)
        Me.NavBarControl1.OptionsNavPane.ShowOverflowButton = False
        Me.NavBarControl1.OptionsNavPane.ShowOverflowPanel = False
        Me.NavBarControl1.OptionsNavPane.ShowSplitter = False
        Me.NavBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane
        Me.RibbonControl1.SetPopupContextMenu(Me.NavBarControl1, Me.mnuProfiles)
        Me.NavBarControl1.StoreDefaultPaintStyleName = True
        '
        'grpMain
        '
        Me.grpMain.AllowHtmlString = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.grpMain, "grpMain")
        Me.grpMain.Expanded = True
        Me.grpMain.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText
        Me.grpMain.Name = "grpMain"
        Me.grpMain.NavigationPaneVisible = False
        '
        'mnuProfiles
        '
        Me.mnuProfiles.ItemLinks.Add(Me.btnProfilesAdd)
        Me.mnuProfiles.ItemLinks.Add(Me.btnProfilesDelete)
        Me.mnuProfiles.ItemLinks.Add(Me.btnProfileImportFromFile, True)
        Me.mnuProfiles.ItemLinks.Add(Me.btnProfileExportToFile)
        Me.mnuProfiles.Name = "mnuProfiles"
        Me.mnuProfiles.Ribbon = Me.RibbonControl1
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Name = "RibbonPage2"
        resources.ApplyResources(Me.RibbonPage2, "RibbonPage2")
        '
        'pnlForm
        '
        Me.pnlForm.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlForm.Controls.Add(Me.pnlMain)
        Me.pnlForm.Controls.Add(Me.pnlOptions)
        Me.pnlForm.Controls.Add(Me.NavBarControl1)
        resources.ApplyResources(Me.pnlForm, "pnlForm")
        Me.pnlForm.Name = "pnlForm"
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
        'frmPreview
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.flyParameters)
        Me.Controls.Add(Me.pnlForm)
        Me.Controls.Add(Me.trkZoom)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.print
        Me.KeyPreview = True
        Me.Name = "frmPreview"
        Me.Ribbon = Me.RibbonControl1
        Me.StatusBar = Me.RibbonStatusBar1
        Me.pnlOptions.ResumeLayout(False)
        CType(Me.pnlMainOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMainOptions.ResumeLayout(False)
        Me.pnlMainOptions.PerformLayout()
        CType(Me.chkPrintTrigpointText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPrintCenterlineColorMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPrintSplay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPrintCombineColorGray.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPrintCombineColorMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPrintSketches.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUseDrawingZOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPrintDesignAdvancedBrushes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTranslations.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPrintDesignStyle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboGPSData.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkExportGPS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPrintDesignSpecialPoint.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPrintImages.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPrintDesign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPrintCentrelineColorGray.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPrintLRUD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPrintStations.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPrintShots.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPrintCentreline.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCompass, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCompass.ResumeLayout(False)
        Me.pnlCompass.PerformLayout()
        CType(Me.chkPrintCompass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCompassPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlScale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlScale.ResumeLayout(False)
        Me.pnlScale.PerformLayout()
        CType(Me.chkPrintScale.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboScalePosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlInformationBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInformationBox.ResumeLayout(False)
        Me.pnlInformationBox.PerformLayout()
        CType(Me.chkPrintBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBoxPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlProfile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProfile.ResumeLayout(False)
        Me.pnlProfile.PerformLayout()
        CType(Me.txtCurrentProfile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlScaleOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlScaleOptions.ResumeLayout(False)
        Me.pnlScaleOptions.PerformLayout()
        CType(Me.cboScale.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScaleManual.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlExportOptionsOther, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExportOptionsOther.ResumeLayout(False)
        Me.pnlExportOptionsOther.PerformLayout()
        CType(Me.txtImageDPI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkBackgroundTransparent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlExportOptionsSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExportOptionsSize.ResumeLayout(False)
        Me.pnlExportOptionsSize.PerformLayout()
        CType(Me.txtImageWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboImageUM.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImageHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlExportOptionsPage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExportOptionsPage.ResumeLayout(False)
        Me.pnlExportOptionsPage.PerformLayout()
        CType(Me.cboSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SvgImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlExportOptionsFormat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExportOptionsFormat.ResumeLayout(False)
        Me.pnlExportOptionsFormat.PerformLayout()
        CType(Me.cboFileFormat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlPrintOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPrintOptions.ResumeLayout(False)
        Me.pnlPrintOptions.PerformLayout()
        CType(Me.cboPageFormat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPrinter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlExport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExport.ResumeLayout(False)
        CType(Me.picExport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMap.ResumeLayout(False)
        CType(Me.trkZoom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbProgress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuProfiles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlForm.ResumeLayout(False)
        CType(Me.flyParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flyParameters.ResumeLayout(False)
        CType(Me.pnlParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlOptions As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents pPreview As cPrintController.PrintPreviewControl 'System.Windows.Forms.PrintPreviewControl 
    Friend WithEvents chkPrintBox As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboScalePosition As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboBoxPosition As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkPrintScale As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkPrintCentreline As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkPrintLRUD As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkPrintStations As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkPrintShots As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboCompassPosition As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkPrintCompass As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkPrintCentrelineColorGray As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkPrintDesign As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboPrinter As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblPrinter As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkPrintImages As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents prDialog As System.Windows.Forms.PrintDialog
    Friend WithEvents cboScale As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblScale As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtScaleManual As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblScale1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPageFormat As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdSetMargins As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlPrintOptions As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlExportOptionsOther As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cboFileFormat As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnlExport As DevExpress.XtraEditors.PanelControl
    Friend WithEvents picExport As System.Windows.Forms.PictureBox
    Friend WithEvents btnInfoBoxDetails As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCompassDetails As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnScaleDetails As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkPrintDesignSpecialPoint As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboGPSData As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblGPSData As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkExportGPS As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkBackgroundTransparent As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cmdSetImageMargins As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboPrintDesignStyle As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents chkPrintDesignStyle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkTranslations As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnTranslationsDetails As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdScaleTools As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkPrintDesignAdvancedBrushes As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cmdManageProfile As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtCurrentProfile As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblCurrentProfile As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkUseDrawingZOrder As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnZOrderDetails As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkPrintSketches As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents pnlMainOptions As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlScaleOptions As DevExpress.XtraEditors.PanelControl
    Friend WithEvents picMap As System.Windows.Forms.PictureBox
    Friend WithEvents pnlMap As DevExpress.XtraEditors.PanelControl
    Friend WithEvents chkPrintCombineColorGray As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboPrintCombineColorMode As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblPrintCombineColorMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnDesignDetails As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSegmentDetails As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkPrintSplay As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents trkZoom As System.Windows.Forms.TrackBar
    Friend WithEvents cboPrintCenterlineColorMode As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblPrintCenterlineColorMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtImageHeight As NumericUpDown
    Friend WithEvents txtImageWidth As NumericUpDown
    Friend WithEvents cboImageUM As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtImageDPI As NumericUpDown
    Friend WithEvents lblImageResolutionUM As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblImageResolution As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SvgImageCollection As DevExpress.Utils.SvgImageCollection
    Friend WithEvents Label1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboSize As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents lblImageOrientation As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkImageOrientationLandscape As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkImageOrientationPortrait As DevExpress.XtraEditors.CheckButton
    Friend WithEvents cboPageFormat As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkPageHorizontal As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkPageVertical As DevExpress.XtraEditors.CheckButton
    Friend WithEvents pnlMain As DevExpress.XtraEditors.PanelControl
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents grpProfiles As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents grpFile As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents cDesignMessageCorner As cMessageCorner
    Friend WithEvents btnProfilesAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnProfilesDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnProperties As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnBaseRule As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents grpView As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnZoomIn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnZoomOut As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnZoomToFit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnSidePanel As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents grpOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnDesignGraphicsQuality As DevExpress.XtraBars.BarSubItem
    Friend WithEvents btnStop As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnDesignGraphics0 As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnDesignGraphics1 As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnDesignGraphics2 As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnManualRefresh As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pnlStatusText As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents pnlStatusDesignZoom As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents btnStatusDesignZoom100 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnStatusDesignZoom200 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnStatusDesignZoom250 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnStatusDesignZoom500 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnStatusDesignZoom1000 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pnlStatusCurrentRule As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents pnlStatusProgress As DevExpress.XtraBars.BarEditItem
    Friend WithEvents pbProgress As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents pnlForm As DevExpress.XtraEditors.PanelControl
    Friend WithEvents NavBarControl1 As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents grpMain As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents pnlCompass As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlScale As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlInformationBox As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlProfile As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlExportOptionsFormat As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlExportOptionsPage As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlExportOptionsSize As DevExpress.XtraEditors.PanelControl
    Friend WithEvents flyParameters As DevExpress.Utils.FlyoutPanel
    Friend WithEvents pnlParameters As DevExpress.Utils.FlyoutPanelControl
    Friend WithEvents btnProfileImportFromFile As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnProfileExportToFile As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuProfiles As DevExpress.XtraBars.PopupMenu
    Friend WithEvents chkPrintTrigpointText As DevExpress.XtraEditors.CheckEdit
End Class
