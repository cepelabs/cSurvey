<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreview
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreview))
        Me.pnlOptions = New System.Windows.Forms.Panel()
        Me.tblOptions = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlCompass = New System.Windows.Forms.Panel()
        Me.chkPrintCompass = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCompassPosition = New System.Windows.Forms.ComboBox()
        Me.btnCompassDetails = New System.Windows.Forms.Button()
        Me.pnlScale = New System.Windows.Forms.Panel()
        Me.chkPrintScale = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboScalePosition = New System.Windows.Forms.ComboBox()
        Me.btnScaleDetails = New System.Windows.Forms.Button()
        Me.pnlInformationBox = New System.Windows.Forms.Panel()
        Me.chkPrintBox = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboBoxPosition = New System.Windows.Forms.ComboBox()
        Me.btnInfoBoxDetails = New System.Windows.Forms.Button()
        Me.pnlScaleOptions = New System.Windows.Forms.Panel()
        Me.lblScale = New System.Windows.Forms.Label()
        Me.cboScale = New System.Windows.Forms.ComboBox()
        Me.lblScale1 = New System.Windows.Forms.Label()
        Me.cmdScaleTools = New System.Windows.Forms.Button()
        Me.txtScaleManual = New System.Windows.Forms.NumericUpDown()
        Me.pnlMainOptions = New System.Windows.Forms.Panel()
        Me.cboPrintCenterlineColorMode = New System.Windows.Forms.ComboBox()
        Me.lblPrintCenterlineColorMode = New System.Windows.Forms.Label()
        Me.chkPrintSplay = New System.Windows.Forms.CheckBox()
        Me.btnSegmentDetails = New System.Windows.Forms.Button()
        Me.btnDesignDetails = New System.Windows.Forms.Button()
        Me.chkPrintCombineColorGray = New System.Windows.Forms.CheckBox()
        Me.cboPrintCombineColorMode = New System.Windows.Forms.ComboBox()
        Me.lblPrintCombineColorMode = New System.Windows.Forms.Label()
        Me.chkPrintSketches = New System.Windows.Forms.CheckBox()
        Me.chkUseDrawingZOrder = New System.Windows.Forms.CheckBox()
        Me.btnZOrderDetails = New System.Windows.Forms.Button()
        Me.chkPrintDesignAdvancedBrushes = New System.Windows.Forms.CheckBox()
        Me.chkTranslations = New System.Windows.Forms.CheckBox()
        Me.btnTranslationsDetails = New System.Windows.Forms.Button()
        Me.cboPrintDesignStyle = New System.Windows.Forms.ComboBox()
        Me.chkPrintDesignStyle = New System.Windows.Forms.Label()
        Me.cboGPSData = New System.Windows.Forms.ComboBox()
        Me.lblGPSData = New System.Windows.Forms.Label()
        Me.chkExportGPS = New System.Windows.Forms.CheckBox()
        Me.chkPrintDesignSpecialPoint = New System.Windows.Forms.CheckBox()
        Me.chkPrintImages = New System.Windows.Forms.CheckBox()
        Me.chkPrintDesign = New System.Windows.Forms.CheckBox()
        Me.chkPrintCentrelineColorGray = New System.Windows.Forms.CheckBox()
        Me.chkPrintLRUD = New System.Windows.Forms.CheckBox()
        Me.chkPrintStations = New System.Windows.Forms.CheckBox()
        Me.chkPrintShots = New System.Windows.Forms.CheckBox()
        Me.chkPrintCentreline = New System.Windows.Forms.CheckBox()
        Me.pnlPrintOptions = New System.Windows.Forms.Panel()
        Me.cmdSetMargins = New System.Windows.Forms.Button()
        Me.cboPrinter = New System.Windows.Forms.ComboBox()
        Me.cboPageFormat = New System.Windows.Forms.ComboBox()
        Me.lblPrinter = New System.Windows.Forms.Label()
        Me.lblPageFormat = New System.Windows.Forms.Label()
        Me.grpOrientation = New System.Windows.Forms.GroupBox()
        Me.optPageHorizontal = New System.Windows.Forms.RadioButton()
        Me.optPageVertical = New System.Windows.Forms.RadioButton()
        Me.pnlExportOptions = New System.Windows.Forms.Panel()
        Me.cmdSetImageMargins = New System.Windows.Forms.Button()
        Me.chkBackgroundTransparent = New System.Windows.Forms.CheckBox()
        Me.txtImageWidth = New System.Windows.Forms.TextBox()
        Me.txtImageHeight = New System.Windows.Forms.TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.cboFileFormat = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlProfile = New System.Windows.Forms.Panel()
        Me.txtCurrentProfile = New System.Windows.Forms.TextBox()
        Me.cmdManageProfile = New System.Windows.Forms.Button()
        Me.lblCurrentProfile = New System.Windows.Forms.Label()
        Me.pPreview = New System.Windows.Forms.PrintPreviewControl()
        Me.tbMain = New System.Windows.Forms.ToolStrip()
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.sep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSidePanel = New System.Windows.Forms.ToolStripButton()
        Me.sep6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnProperty = New System.Windows.Forms.ToolStripButton()
        Me.sep7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnZoomIn = New System.Windows.Forms.ToolStripButton()
        Me.btnZoomOut = New System.Windows.Forms.ToolStripButton()
        Me.btnZoomToFit = New System.Windows.Forms.ToolStripButton()
        Me.sep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImportSettings = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnImportSettings0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImportSettings1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImportSettings4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImportSettings5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImportSettings2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImportSettings3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPreviewQuality = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnPreviewQuality0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPreviewQuality1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPreviewQuality2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.sep3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnManualRefresh = New System.Windows.Forms.ToolStripButton()
        Me.btnStop = New System.Windows.Forms.ToolStripButton()
        Me.sep4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPrint = New System.Windows.Forms.ToolStripButton()
        Me.btnExport = New System.Windows.Forms.ToolStripButton()
        Me.sep5 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdClose = New System.Windows.Forms.ToolStripButton()
        Me.prDialog = New System.Windows.Forms.PrintDialog()
        Me.pnlExport = New System.Windows.Forms.Panel()
        Me.picExport = New System.Windows.Forms.PictureBox()
        Me.sbMain = New System.Windows.Forms.StatusStrip()
        Me.pnlStatusText = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlStatusProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.pnlStatusCurrentRule = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlStatusDesignZoom = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlStatusDesignZoom100 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlStatusDesignZoom200 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlStatusDesignZoom250 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlStatusDesignZoom500 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlStatusDesignZoom1000 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lv = New System.Windows.Forms.ListView()
        Me.mnuLvContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuLvContextAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLvContextAddSep = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLvContextDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLvContextDeleteSep = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLvContextImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLvContextExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.picInvalidated = New System.Windows.Forms.PictureBox()
        Me.pnlPopup = New System.Windows.Forms.Panel()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.lblPopupWarning = New System.Windows.Forms.Label()
        Me.picMap = New System.Windows.Forms.PictureBox()
        Me.pnlMap = New System.Windows.Forms.Panel()
        Me.trkZoom = New System.Windows.Forms.TrackBar()
        Me.pnlOptions.SuspendLayout()
        Me.tblOptions.SuspendLayout()
        Me.pnlCompass.SuspendLayout()
        Me.pnlScale.SuspendLayout()
        Me.pnlInformationBox.SuspendLayout()
        Me.pnlScaleOptions.SuspendLayout()
        CType(Me.txtScaleManual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMainOptions.SuspendLayout()
        Me.pnlPrintOptions.SuspendLayout()
        Me.grpOrientation.SuspendLayout()
        Me.pnlExportOptions.SuspendLayout()
        Me.pnlProfile.SuspendLayout()
        Me.tbMain.SuspendLayout()
        Me.pnlExport.SuspendLayout()
        CType(Me.picExport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sbMain.SuspendLayout()
        Me.mnuLvContext.SuspendLayout()
        CType(Me.picInvalidated, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPopup.SuspendLayout()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMap.SuspendLayout()
        CType(Me.trkZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlOptions
        '
        resources.ApplyResources(Me.pnlOptions, "pnlOptions")
        Me.pnlOptions.BackColor = System.Drawing.SystemColors.Window
        Me.pnlOptions.Controls.Add(Me.tblOptions)
        Me.pnlOptions.Name = "pnlOptions"
        '
        'tblOptions
        '
        resources.ApplyResources(Me.tblOptions, "tblOptions")
        Me.tblOptions.Controls.Add(Me.pnlCompass, 0, 7)
        Me.tblOptions.Controls.Add(Me.pnlScale, 0, 6)
        Me.tblOptions.Controls.Add(Me.pnlInformationBox, 0, 5)
        Me.tblOptions.Controls.Add(Me.pnlScaleOptions, 0, 2)
        Me.tblOptions.Controls.Add(Me.pnlMainOptions, 0, 8)
        Me.tblOptions.Controls.Add(Me.pnlPrintOptions, 0, 0)
        Me.tblOptions.Controls.Add(Me.pnlExportOptions, 0, 1)
        Me.tblOptions.Controls.Add(Me.pnlProfile, 0, 4)
        Me.tblOptions.Name = "tblOptions"
        '
        'pnlCompass
        '
        Me.pnlCompass.Controls.Add(Me.chkPrintCompass)
        Me.pnlCompass.Controls.Add(Me.Label4)
        Me.pnlCompass.Controls.Add(Me.cboCompassPosition)
        Me.pnlCompass.Controls.Add(Me.btnCompassDetails)
        resources.ApplyResources(Me.pnlCompass, "pnlCompass")
        Me.pnlCompass.Name = "pnlCompass"
        '
        'chkPrintCompass
        '
        Me.chkPrintCompass.Checked = True
        Me.chkPrintCompass.CheckState = System.Windows.Forms.CheckState.Checked
        resources.ApplyResources(Me.chkPrintCompass, "chkPrintCompass")
        Me.chkPrintCompass.Name = "chkPrintCompass"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'cboCompassPosition
        '
        Me.cboCompassPosition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboCompassPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompassPosition.Items.AddRange(New Object() {resources.GetString("cboCompassPosition.Items"), resources.GetString("cboCompassPosition.Items1"), resources.GetString("cboCompassPosition.Items2"), resources.GetString("cboCompassPosition.Items3")})
        resources.ApplyResources(Me.cboCompassPosition, "cboCompassPosition")
        Me.cboCompassPosition.Name = "cboCompassPosition"
        '
        'btnCompassDetails
        '
        Me.btnCompassDetails.Image = Global.cSurveyPC.My.Resources.Resources.application_form_edit
        resources.ApplyResources(Me.btnCompassDetails, "btnCompassDetails")
        Me.btnCompassDetails.Name = "btnCompassDetails"
        Me.btnCompassDetails.UseVisualStyleBackColor = True
        '
        'pnlScale
        '
        Me.pnlScale.Controls.Add(Me.chkPrintScale)
        Me.pnlScale.Controls.Add(Me.Label3)
        Me.pnlScale.Controls.Add(Me.cboScalePosition)
        Me.pnlScale.Controls.Add(Me.btnScaleDetails)
        resources.ApplyResources(Me.pnlScale, "pnlScale")
        Me.pnlScale.Name = "pnlScale"
        '
        'chkPrintScale
        '
        Me.chkPrintScale.Checked = True
        Me.chkPrintScale.CheckState = System.Windows.Forms.CheckState.Checked
        resources.ApplyResources(Me.chkPrintScale, "chkPrintScale")
        Me.chkPrintScale.Name = "chkPrintScale"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'cboScalePosition
        '
        Me.cboScalePosition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboScalePosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboScalePosition.Items.AddRange(New Object() {resources.GetString("cboScalePosition.Items"), resources.GetString("cboScalePosition.Items1"), resources.GetString("cboScalePosition.Items2"), resources.GetString("cboScalePosition.Items3")})
        resources.ApplyResources(Me.cboScalePosition, "cboScalePosition")
        Me.cboScalePosition.Name = "cboScalePosition"
        '
        'btnScaleDetails
        '
        Me.btnScaleDetails.Image = Global.cSurveyPC.My.Resources.Resources.application_form_edit
        resources.ApplyResources(Me.btnScaleDetails, "btnScaleDetails")
        Me.btnScaleDetails.Name = "btnScaleDetails"
        Me.btnScaleDetails.UseVisualStyleBackColor = True
        '
        'pnlInformationBox
        '
        Me.pnlInformationBox.Controls.Add(Me.chkPrintBox)
        Me.pnlInformationBox.Controls.Add(Me.Label2)
        Me.pnlInformationBox.Controls.Add(Me.cboBoxPosition)
        Me.pnlInformationBox.Controls.Add(Me.btnInfoBoxDetails)
        resources.ApplyResources(Me.pnlInformationBox, "pnlInformationBox")
        Me.pnlInformationBox.Name = "pnlInformationBox"
        '
        'chkPrintBox
        '
        Me.chkPrintBox.Checked = True
        Me.chkPrintBox.CheckState = System.Windows.Forms.CheckState.Checked
        resources.ApplyResources(Me.chkPrintBox, "chkPrintBox")
        Me.chkPrintBox.Name = "chkPrintBox"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'cboBoxPosition
        '
        Me.cboBoxPosition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboBoxPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBoxPosition.Items.AddRange(New Object() {resources.GetString("cboBoxPosition.Items"), resources.GetString("cboBoxPosition.Items1"), resources.GetString("cboBoxPosition.Items2"), resources.GetString("cboBoxPosition.Items3")})
        resources.ApplyResources(Me.cboBoxPosition, "cboBoxPosition")
        Me.cboBoxPosition.Name = "cboBoxPosition"
        '
        'btnInfoBoxDetails
        '
        Me.btnInfoBoxDetails.Image = Global.cSurveyPC.My.Resources.Resources.application_form_edit
        resources.ApplyResources(Me.btnInfoBoxDetails, "btnInfoBoxDetails")
        Me.btnInfoBoxDetails.Name = "btnInfoBoxDetails"
        Me.btnInfoBoxDetails.UseVisualStyleBackColor = True
        '
        'pnlScaleOptions
        '
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
        resources.ApplyResources(Me.lblScale, "lblScale")
        Me.lblScale.Name = "lblScale"
        '
        'cboScale
        '
        Me.cboScale.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboScale.Items.AddRange(New Object() {resources.GetString("cboScale.Items"), resources.GetString("cboScale.Items1"), resources.GetString("cboScale.Items2"), resources.GetString("cboScale.Items3"), resources.GetString("cboScale.Items4"), resources.GetString("cboScale.Items5"), resources.GetString("cboScale.Items6"), resources.GetString("cboScale.Items7"), resources.GetString("cboScale.Items8"), resources.GetString("cboScale.Items9"), resources.GetString("cboScale.Items10"), resources.GetString("cboScale.Items11")})
        resources.ApplyResources(Me.cboScale, "cboScale")
        Me.cboScale.Name = "cboScale"
        '
        'lblScale1
        '
        resources.ApplyResources(Me.lblScale1, "lblScale1")
        Me.lblScale1.Name = "lblScale1"
        '
        'cmdScaleTools
        '
        Me.cmdScaleTools.Image = Global.cSurveyPC.My.Resources.Resources.scale_image
        resources.ApplyResources(Me.cmdScaleTools, "cmdScaleTools")
        Me.cmdScaleTools.Name = "cmdScaleTools"
        Me.cmdScaleTools.UseVisualStyleBackColor = True
        '
        'txtScaleManual
        '
        resources.ApplyResources(Me.txtScaleManual, "txtScaleManual")
        Me.txtScaleManual.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        Me.txtScaleManual.Maximum = New Decimal(New Integer() {50000, 0, 0, 0})
        Me.txtScaleManual.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.txtScaleManual.Name = "txtScaleManual"
        Me.txtScaleManual.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'pnlMainOptions
        '
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
        'cboPrintCenterlineColorMode
        '
        Me.cboPrintCenterlineColorMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboPrintCenterlineColorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrintCenterlineColorMode.Items.AddRange(New Object() {resources.GetString("cboPrintCenterlineColorMode.Items"), resources.GetString("cboPrintCenterlineColorMode.Items1"), resources.GetString("cboPrintCenterlineColorMode.Items2")})
        resources.ApplyResources(Me.cboPrintCenterlineColorMode, "cboPrintCenterlineColorMode")
        Me.cboPrintCenterlineColorMode.Name = "cboPrintCenterlineColorMode"
        '
        'lblPrintCenterlineColorMode
        '
        resources.ApplyResources(Me.lblPrintCenterlineColorMode, "lblPrintCenterlineColorMode")
        Me.lblPrintCenterlineColorMode.Name = "lblPrintCenterlineColorMode"
        '
        'chkPrintSplay
        '
        resources.ApplyResources(Me.chkPrintSplay, "chkPrintSplay")
        Me.chkPrintSplay.Name = "chkPrintSplay"
        '
        'btnSegmentDetails
        '
        Me.btnSegmentDetails.Image = Global.cSurveyPC.My.Resources.Resources.application_form_edit
        resources.ApplyResources(Me.btnSegmentDetails, "btnSegmentDetails")
        Me.btnSegmentDetails.Name = "btnSegmentDetails"
        Me.btnSegmentDetails.UseVisualStyleBackColor = True
        '
        'btnDesignDetails
        '
        Me.btnDesignDetails.Image = Global.cSurveyPC.My.Resources.Resources.application_form_edit
        resources.ApplyResources(Me.btnDesignDetails, "btnDesignDetails")
        Me.btnDesignDetails.Name = "btnDesignDetails"
        Me.btnDesignDetails.UseVisualStyleBackColor = True
        '
        'chkPrintCombineColorGray
        '
        resources.ApplyResources(Me.chkPrintCombineColorGray, "chkPrintCombineColorGray")
        Me.chkPrintCombineColorGray.Name = "chkPrintCombineColorGray"
        '
        'cboPrintCombineColorMode
        '
        Me.cboPrintCombineColorMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboPrintCombineColorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPrintCombineColorMode, "cboPrintCombineColorMode")
        Me.cboPrintCombineColorMode.Items.AddRange(New Object() {resources.GetString("cboPrintCombineColorMode.Items"), resources.GetString("cboPrintCombineColorMode.Items1"), resources.GetString("cboPrintCombineColorMode.Items2")})
        Me.cboPrintCombineColorMode.Name = "cboPrintCombineColorMode"
        '
        'lblPrintCombineColorMode
        '
        resources.ApplyResources(Me.lblPrintCombineColorMode, "lblPrintCombineColorMode")
        Me.lblPrintCombineColorMode.Name = "lblPrintCombineColorMode"
        '
        'chkPrintSketches
        '
        resources.ApplyResources(Me.chkPrintSketches, "chkPrintSketches")
        Me.chkPrintSketches.Name = "chkPrintSketches"
        '
        'chkUseDrawingZOrder
        '
        Me.chkUseDrawingZOrder.Checked = True
        Me.chkUseDrawingZOrder.CheckState = System.Windows.Forms.CheckState.Checked
        resources.ApplyResources(Me.chkUseDrawingZOrder, "chkUseDrawingZOrder")
        Me.chkUseDrawingZOrder.Name = "chkUseDrawingZOrder"
        '
        'btnZOrderDetails
        '
        resources.ApplyResources(Me.btnZOrderDetails, "btnZOrderDetails")
        Me.btnZOrderDetails.Name = "btnZOrderDetails"
        Me.btnZOrderDetails.UseVisualStyleBackColor = True
        '
        'chkPrintDesignAdvancedBrushes
        '
        Me.chkPrintDesignAdvancedBrushes.Checked = True
        Me.chkPrintDesignAdvancedBrushes.CheckState = System.Windows.Forms.CheckState.Checked
        resources.ApplyResources(Me.chkPrintDesignAdvancedBrushes, "chkPrintDesignAdvancedBrushes")
        Me.chkPrintDesignAdvancedBrushes.Name = "chkPrintDesignAdvancedBrushes"
        '
        'chkTranslations
        '
        Me.chkTranslations.Checked = True
        Me.chkTranslations.CheckState = System.Windows.Forms.CheckState.Checked
        resources.ApplyResources(Me.chkTranslations, "chkTranslations")
        Me.chkTranslations.Name = "chkTranslations"
        '
        'btnTranslationsDetails
        '
        Me.btnTranslationsDetails.Image = Global.cSurveyPC.My.Resources.Resources.layer_arrange
        resources.ApplyResources(Me.btnTranslationsDetails, "btnTranslationsDetails")
        Me.btnTranslationsDetails.Name = "btnTranslationsDetails"
        Me.btnTranslationsDetails.UseVisualStyleBackColor = True
        '
        'cboPrintDesignStyle
        '
        Me.cboPrintDesignStyle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboPrintDesignStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrintDesignStyle.Items.AddRange(New Object() {resources.GetString("cboPrintDesignStyle.Items"), resources.GetString("cboPrintDesignStyle.Items1"), resources.GetString("cboPrintDesignStyle.Items2")})
        resources.ApplyResources(Me.cboPrintDesignStyle, "cboPrintDesignStyle")
        Me.cboPrintDesignStyle.Name = "cboPrintDesignStyle"
        '
        'chkPrintDesignStyle
        '
        resources.ApplyResources(Me.chkPrintDesignStyle, "chkPrintDesignStyle")
        Me.chkPrintDesignStyle.Name = "chkPrintDesignStyle"
        '
        'cboGPSData
        '
        Me.cboGPSData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGPSData.Items.AddRange(New Object() {resources.GetString("cboGPSData.Items")})
        resources.ApplyResources(Me.cboGPSData, "cboGPSData")
        Me.cboGPSData.Name = "cboGPSData"
        '
        'lblGPSData
        '
        resources.ApplyResources(Me.lblGPSData, "lblGPSData")
        Me.lblGPSData.Name = "lblGPSData"
        '
        'chkExportGPS
        '
        Me.chkExportGPS.Checked = True
        Me.chkExportGPS.CheckState = System.Windows.Forms.CheckState.Checked
        resources.ApplyResources(Me.chkExportGPS, "chkExportGPS")
        Me.chkExportGPS.Name = "chkExportGPS"
        '
        'chkPrintDesignSpecialPoint
        '
        resources.ApplyResources(Me.chkPrintDesignSpecialPoint, "chkPrintDesignSpecialPoint")
        Me.chkPrintDesignSpecialPoint.Checked = True
        Me.chkPrintDesignSpecialPoint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintDesignSpecialPoint.Name = "chkPrintDesignSpecialPoint"
        '
        'chkPrintImages
        '
        resources.ApplyResources(Me.chkPrintImages, "chkPrintImages")
        Me.chkPrintImages.Name = "chkPrintImages"
        '
        'chkPrintDesign
        '
        Me.chkPrintDesign.Checked = True
        Me.chkPrintDesign.CheckState = System.Windows.Forms.CheckState.Checked
        resources.ApplyResources(Me.chkPrintDesign, "chkPrintDesign")
        Me.chkPrintDesign.Name = "chkPrintDesign"
        '
        'chkPrintCentrelineColorGray
        '
        resources.ApplyResources(Me.chkPrintCentrelineColorGray, "chkPrintCentrelineColorGray")
        Me.chkPrintCentrelineColorGray.Name = "chkPrintCentrelineColorGray"
        '
        'chkPrintLRUD
        '
        resources.ApplyResources(Me.chkPrintLRUD, "chkPrintLRUD")
        Me.chkPrintLRUD.Name = "chkPrintLRUD"
        '
        'chkPrintStations
        '
        resources.ApplyResources(Me.chkPrintStations, "chkPrintStations")
        Me.chkPrintStations.Checked = True
        Me.chkPrintStations.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintStations.Name = "chkPrintStations"
        '
        'chkPrintShots
        '
        resources.ApplyResources(Me.chkPrintShots, "chkPrintShots")
        Me.chkPrintShots.Checked = True
        Me.chkPrintShots.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintShots.Name = "chkPrintShots"
        '
        'chkPrintCentreline
        '
        Me.chkPrintCentreline.Checked = True
        Me.chkPrintCentreline.CheckState = System.Windows.Forms.CheckState.Checked
        resources.ApplyResources(Me.chkPrintCentreline, "chkPrintCentreline")
        Me.chkPrintCentreline.Name = "chkPrintCentreline"
        '
        'pnlPrintOptions
        '
        Me.pnlPrintOptions.Controls.Add(Me.cmdSetMargins)
        Me.pnlPrintOptions.Controls.Add(Me.cboPrinter)
        Me.pnlPrintOptions.Controls.Add(Me.cboPageFormat)
        Me.pnlPrintOptions.Controls.Add(Me.lblPrinter)
        Me.pnlPrintOptions.Controls.Add(Me.lblPageFormat)
        Me.pnlPrintOptions.Controls.Add(Me.grpOrientation)
        resources.ApplyResources(Me.pnlPrintOptions, "pnlPrintOptions")
        Me.pnlPrintOptions.Name = "pnlPrintOptions"
        '
        'cmdSetMargins
        '
        Me.cmdSetMargins.Image = Global.cSurveyPC.My.Resources.Resources.document_margins
        resources.ApplyResources(Me.cmdSetMargins, "cmdSetMargins")
        Me.cmdSetMargins.Name = "cmdSetMargins"
        Me.cmdSetMargins.UseVisualStyleBackColor = True
        '
        'cboPrinter
        '
        Me.cboPrinter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPrinter, "cboPrinter")
        Me.cboPrinter.Name = "cboPrinter"
        '
        'cboPageFormat
        '
        Me.cboPageFormat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboPageFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPageFormat, "cboPageFormat")
        Me.cboPageFormat.Name = "cboPageFormat"
        Me.cboPageFormat.Sorted = True
        '
        'lblPrinter
        '
        resources.ApplyResources(Me.lblPrinter, "lblPrinter")
        Me.lblPrinter.Name = "lblPrinter"
        '
        'lblPageFormat
        '
        resources.ApplyResources(Me.lblPageFormat, "lblPageFormat")
        Me.lblPageFormat.Name = "lblPageFormat"
        '
        'grpOrientation
        '
        Me.grpOrientation.Controls.Add(Me.optPageHorizontal)
        Me.grpOrientation.Controls.Add(Me.optPageVertical)
        resources.ApplyResources(Me.grpOrientation, "grpOrientation")
        Me.grpOrientation.Name = "grpOrientation"
        Me.grpOrientation.TabStop = False
        '
        'optPageHorizontal
        '
        Me.optPageHorizontal.Image = Global.cSurveyPC.My.Resources.Resources.page_white_horizontal
        resources.ApplyResources(Me.optPageHorizontal, "optPageHorizontal")
        Me.optPageHorizontal.Name = "optPageHorizontal"
        Me.optPageHorizontal.UseVisualStyleBackColor = True
        '
        'optPageVertical
        '
        Me.optPageVertical.Checked = True
        Me.optPageVertical.Image = Global.cSurveyPC.My.Resources.Resources.page_white1
        resources.ApplyResources(Me.optPageVertical, "optPageVertical")
        Me.optPageVertical.Name = "optPageVertical"
        Me.optPageVertical.TabStop = True
        Me.optPageVertical.UseVisualStyleBackColor = True
        '
        'pnlExportOptions
        '
        Me.pnlExportOptions.Controls.Add(Me.cmdSetImageMargins)
        Me.pnlExportOptions.Controls.Add(Me.chkBackgroundTransparent)
        Me.pnlExportOptions.Controls.Add(Me.txtImageWidth)
        Me.pnlExportOptions.Controls.Add(Me.txtImageHeight)
        Me.pnlExportOptions.Controls.Add(Me.Label71)
        Me.pnlExportOptions.Controls.Add(Me.Label72)
        Me.pnlExportOptions.Controls.Add(Me.lblSize)
        Me.pnlExportOptions.Controls.Add(Me.cboFileFormat)
        Me.pnlExportOptions.Controls.Add(Me.Label7)
        resources.ApplyResources(Me.pnlExportOptions, "pnlExportOptions")
        Me.pnlExportOptions.Name = "pnlExportOptions"
        '
        'cmdSetImageMargins
        '
        Me.cmdSetImageMargins.Image = Global.cSurveyPC.My.Resources.Resources.document_margins
        resources.ApplyResources(Me.cmdSetImageMargins, "cmdSetImageMargins")
        Me.cmdSetImageMargins.Name = "cmdSetImageMargins"
        Me.cmdSetImageMargins.UseVisualStyleBackColor = True
        '
        'chkBackgroundTransparent
        '
        resources.ApplyResources(Me.chkBackgroundTransparent, "chkBackgroundTransparent")
        Me.chkBackgroundTransparent.Name = "chkBackgroundTransparent"
        Me.chkBackgroundTransparent.UseVisualStyleBackColor = True
        '
        'txtImageWidth
        '
        resources.ApplyResources(Me.txtImageWidth, "txtImageWidth")
        Me.txtImageWidth.Name = "txtImageWidth"
        '
        'txtImageHeight
        '
        resources.ApplyResources(Me.txtImageHeight, "txtImageHeight")
        Me.txtImageHeight.Name = "txtImageHeight"
        '
        'Label71
        '
        resources.ApplyResources(Me.Label71, "Label71")
        Me.Label71.Name = "Label71"
        '
        'Label72
        '
        resources.ApplyResources(Me.Label72, "Label72")
        Me.Label72.Name = "Label72"
        '
        'lblSize
        '
        resources.ApplyResources(Me.lblSize, "lblSize")
        Me.lblSize.Name = "lblSize"
        '
        'cboFileFormat
        '
        Me.cboFileFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboFileFormat, "cboFileFormat")
        Me.cboFileFormat.Items.AddRange(New Object() {resources.GetString("cboFileFormat.Items"), resources.GetString("cboFileFormat.Items1"), resources.GetString("cboFileFormat.Items2"), resources.GetString("cboFileFormat.Items3"), resources.GetString("cboFileFormat.Items4")})
        Me.cboFileFormat.Name = "cboFileFormat"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'pnlProfile
        '
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
        Me.txtCurrentProfile.ReadOnly = True
        '
        'cmdManageProfile
        '
        Me.cmdManageProfile.Image = Global.cSurveyPC.My.Resources.Resources.to_do_list
        resources.ApplyResources(Me.cmdManageProfile, "cmdManageProfile")
        Me.cmdManageProfile.Name = "cmdManageProfile"
        Me.cmdManageProfile.UseVisualStyleBackColor = True
        '
        'lblCurrentProfile
        '
        resources.ApplyResources(Me.lblCurrentProfile, "lblCurrentProfile")
        Me.lblCurrentProfile.Name = "lblCurrentProfile"
        '
        'pPreview
        '
        Me.pPreview.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.pPreview, "pPreview")
        Me.pPreview.Name = "pPreview"
        Me.pPreview.UseAntiAlias = True
        '
        'tbMain
        '
        resources.ApplyResources(Me.tbMain, "tbMain")
        Me.tbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.btnDelete, Me.sep1, Me.btnSidePanel, Me.sep6, Me.btnProperty, Me.sep7, Me.btnZoomIn, Me.btnZoomOut, Me.btnZoomToFit, Me.sep2, Me.btnImportSettings, Me.btnPreviewQuality, Me.sep3, Me.btnManualRefresh, Me.btnStop, Me.sep4, Me.btnPrint, Me.btnExport, Me.sep5, Me.cmdClose})
        Me.tbMain.Name = "tbMain"
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.cSurveyPC.My.Resources.Resources.add
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Name = "btnAdd"
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.btnDelete.Name = "btnDelete"
        '
        'sep1
        '
        Me.sep1.Name = "sep1"
        resources.ApplyResources(Me.sep1, "sep1")
        '
        'btnSidePanel
        '
        Me.btnSidePanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSidePanel.Image = Global.cSurveyPC.My.Resources.Resources.application_side_list
        resources.ApplyResources(Me.btnSidePanel, "btnSidePanel")
        Me.btnSidePanel.Name = "btnSidePanel"
        '
        'sep6
        '
        Me.sep6.Name = "sep6"
        resources.ApplyResources(Me.sep6, "sep6")
        '
        'btnProperty
        '
        Me.btnProperty.Image = Global.cSurveyPC.My.Resources.Resources.application_form
        resources.ApplyResources(Me.btnProperty, "btnProperty")
        Me.btnProperty.Name = "btnProperty"
        '
        'sep7
        '
        Me.sep7.Name = "sep7"
        resources.ApplyResources(Me.sep7, "sep7")
        '
        'btnZoomIn
        '
        Me.btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoomIn.Image = Global.cSurveyPC.My.Resources.Resources.magnifier_zoom_in
        resources.ApplyResources(Me.btnZoomIn, "btnZoomIn")
        Me.btnZoomIn.Name = "btnZoomIn"
        '
        'btnZoomOut
        '
        Me.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoomOut.Image = Global.cSurveyPC.My.Resources.Resources.magifier_zoom_out
        resources.ApplyResources(Me.btnZoomOut, "btnZoomOut")
        Me.btnZoomOut.Name = "btnZoomOut"
        '
        'btnZoomToFit
        '
        Me.btnZoomToFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoomToFit.Image = Global.cSurveyPC.My.Resources.Resources.page_white_magnify
        resources.ApplyResources(Me.btnZoomToFit, "btnZoomToFit")
        Me.btnZoomToFit.Name = "btnZoomToFit"
        '
        'sep2
        '
        Me.sep2.Name = "sep2"
        resources.ApplyResources(Me.sep2, "sep2")
        '
        'btnImportSettings
        '
        Me.btnImportSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnImportSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnImportSettings0, Me.btnImportSettings1, Me.btnImportSettings4, Me.btnImportSettings5, Me.btnImportSettings2, Me.ToolStripMenuItem1, Me.btnImportSettings3})
        resources.ApplyResources(Me.btnImportSettings, "btnImportSettings")
        Me.btnImportSettings.Name = "btnImportSettings"
        '
        'btnImportSettings0
        '
        Me.btnImportSettings0.Name = "btnImportSettings0"
        resources.ApplyResources(Me.btnImportSettings0, "btnImportSettings0")
        '
        'btnImportSettings1
        '
        Me.btnImportSettings1.Name = "btnImportSettings1"
        resources.ApplyResources(Me.btnImportSettings1, "btnImportSettings1")
        '
        'btnImportSettings4
        '
        Me.btnImportSettings4.Name = "btnImportSettings4"
        resources.ApplyResources(Me.btnImportSettings4, "btnImportSettings4")
        '
        'btnImportSettings5
        '
        Me.btnImportSettings5.Name = "btnImportSettings5"
        resources.ApplyResources(Me.btnImportSettings5, "btnImportSettings5")
        '
        'btnImportSettings2
        '
        Me.btnImportSettings2.Name = "btnImportSettings2"
        resources.ApplyResources(Me.btnImportSettings2, "btnImportSettings2")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'btnImportSettings3
        '
        Me.btnImportSettings3.Name = "btnImportSettings3"
        resources.ApplyResources(Me.btnImportSettings3, "btnImportSettings3")
        '
        'btnPreviewQuality
        '
        Me.btnPreviewQuality.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnPreviewQuality.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnPreviewQuality0, Me.btnPreviewQuality1, Me.btnPreviewQuality2})
        resources.ApplyResources(Me.btnPreviewQuality, "btnPreviewQuality")
        Me.btnPreviewQuality.Name = "btnPreviewQuality"
        '
        'btnPreviewQuality0
        '
        Me.btnPreviewQuality0.Name = "btnPreviewQuality0"
        resources.ApplyResources(Me.btnPreviewQuality0, "btnPreviewQuality0")
        '
        'btnPreviewQuality1
        '
        Me.btnPreviewQuality1.Name = "btnPreviewQuality1"
        resources.ApplyResources(Me.btnPreviewQuality1, "btnPreviewQuality1")
        '
        'btnPreviewQuality2
        '
        Me.btnPreviewQuality2.Checked = True
        Me.btnPreviewQuality2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnPreviewQuality2.Name = "btnPreviewQuality2"
        resources.ApplyResources(Me.btnPreviewQuality2, "btnPreviewQuality2")
        '
        'sep3
        '
        Me.sep3.Name = "sep3"
        resources.ApplyResources(Me.sep3, "sep3")
        '
        'btnManualRefresh
        '
        Me.btnManualRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnManualRefresh.Image = Global.cSurveyPC.My.Resources.Resources.page_refresh
        resources.ApplyResources(Me.btnManualRefresh, "btnManualRefresh")
        Me.btnManualRefresh.Name = "btnManualRefresh"
        '
        'btnStop
        '
        Me.btnStop.Image = Global.cSurveyPC.My.Resources.Resources._stop
        resources.ApplyResources(Me.btnStop, "btnStop")
        Me.btnStop.Name = "btnStop"
        '
        'sep4
        '
        Me.sep4.Name = "sep4"
        resources.ApplyResources(Me.sep4, "sep4")
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.cSurveyPC.My.Resources.Resources.printer
        resources.ApplyResources(Me.btnPrint, "btnPrint")
        Me.btnPrint.Name = "btnPrint"
        '
        'btnExport
        '
        Me.btnExport.Image = Global.cSurveyPC.My.Resources.Resources.disk
        resources.ApplyResources(Me.btnExport, "btnExport")
        Me.btnExport.Name = "btnExport"
        '
        'sep5
        '
        Me.sep5.Name = "sep5"
        resources.ApplyResources(Me.sep5, "sep5")
        '
        'cmdClose
        '
        Me.cmdClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.cmdClose, "cmdClose")
        Me.cmdClose.Name = "cmdClose"
        '
        'prDialog
        '
        Me.prDialog.UseEXDialog = True
        '
        'pnlExport
        '
        resources.ApplyResources(Me.pnlExport, "pnlExport")
        Me.pnlExport.BackColor = System.Drawing.Color.White
        Me.pnlExport.Controls.Add(Me.picExport)
        Me.pnlExport.Name = "pnlExport"
        '
        'picExport
        '
        resources.ApplyResources(Me.picExport, "picExport")
        Me.picExport.Name = "picExport"
        Me.picExport.TabStop = False
        '
        'sbMain
        '
        resources.ApplyResources(Me.sbMain, "sbMain")
        Me.sbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pnlStatusText, Me.pnlStatusProgress, Me.pnlStatusCurrentRule, Me.pnlStatusDesignZoom, Me.pnlStatusDesignZoom100, Me.pnlStatusDesignZoom200, Me.pnlStatusDesignZoom250, Me.pnlStatusDesignZoom500, Me.pnlStatusDesignZoom1000})
        Me.sbMain.Name = "sbMain"
        '
        'pnlStatusText
        '
        Me.pnlStatusText.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.pnlStatusText.Name = "pnlStatusText"
        resources.ApplyResources(Me.pnlStatusText, "pnlStatusText")
        Me.pnlStatusText.Spring = True
        '
        'pnlStatusProgress
        '
        resources.ApplyResources(Me.pnlStatusProgress, "pnlStatusProgress")
        Me.pnlStatusProgress.Name = "pnlStatusProgress"
        '
        'pnlStatusCurrentRule
        '
        resources.ApplyResources(Me.pnlStatusCurrentRule, "pnlStatusCurrentRule")
        Me.pnlStatusCurrentRule.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.pnlStatusCurrentRule.DoubleClickEnabled = True
        Me.pnlStatusCurrentRule.Image = Global.cSurveyPC.My.Resources.Resources.layers_map
        Me.pnlStatusCurrentRule.Name = "pnlStatusCurrentRule"
        '
        'pnlStatusDesignZoom
        '
        resources.ApplyResources(Me.pnlStatusDesignZoom, "pnlStatusDesignZoom")
        Me.pnlStatusDesignZoom.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.pnlStatusDesignZoom.Image = Global.cSurveyPC.My.Resources.Resources.magnifier
        Me.pnlStatusDesignZoom.Name = "pnlStatusDesignZoom"
        '
        'pnlStatusDesignZoom100
        '
        Me.pnlStatusDesignZoom100.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.pnlStatusDesignZoom100.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pnlStatusDesignZoom100.Name = "pnlStatusDesignZoom100"
        resources.ApplyResources(Me.pnlStatusDesignZoom100, "pnlStatusDesignZoom100")
        '
        'pnlStatusDesignZoom200
        '
        Me.pnlStatusDesignZoom200.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.pnlStatusDesignZoom200.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pnlStatusDesignZoom200.Name = "pnlStatusDesignZoom200"
        resources.ApplyResources(Me.pnlStatusDesignZoom200, "pnlStatusDesignZoom200")
        '
        'pnlStatusDesignZoom250
        '
        Me.pnlStatusDesignZoom250.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.pnlStatusDesignZoom250.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pnlStatusDesignZoom250.Name = "pnlStatusDesignZoom250"
        resources.ApplyResources(Me.pnlStatusDesignZoom250, "pnlStatusDesignZoom250")
        '
        'pnlStatusDesignZoom500
        '
        Me.pnlStatusDesignZoom500.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.pnlStatusDesignZoom500.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pnlStatusDesignZoom500.Name = "pnlStatusDesignZoom500"
        resources.ApplyResources(Me.pnlStatusDesignZoom500, "pnlStatusDesignZoom500")
        '
        'pnlStatusDesignZoom1000
        '
        Me.pnlStatusDesignZoom1000.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.pnlStatusDesignZoom1000.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pnlStatusDesignZoom1000.Name = "pnlStatusDesignZoom1000"
        resources.ApplyResources(Me.pnlStatusDesignZoom1000, "pnlStatusDesignZoom1000")
        '
        'lv
        '
        Me.lv.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lv.ContextMenuStrip = Me.mnuLvContext
        resources.ApplyResources(Me.lv, "lv")
        Me.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lv.HideSelection = False
        Me.lv.LabelEdit = True
        Me.lv.LargeImageList = Me.iml
        Me.lv.MultiSelect = False
        Me.lv.Name = "lv"
        Me.lv.ShowItemToolTips = True
        Me.lv.UseCompatibleStateImageBehavior = False
        '
        'mnuLvContext
        '
        resources.ApplyResources(Me.mnuLvContext, "mnuLvContext")
        Me.mnuLvContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLvContextAdd, Me.mnuLvContextAddSep, Me.mnuLvContextDelete, Me.mnuLvContextDeleteSep, Me.mnuLvContextImport, Me.mnuLvContextExport})
        Me.mnuLvContext.Name = "mnuLvContext"
        '
        'mnuLvContextAdd
        '
        Me.mnuLvContextAdd.Image = Global.cSurveyPC.My.Resources.Resources.add
        Me.mnuLvContextAdd.Name = "mnuLvContextAdd"
        resources.ApplyResources(Me.mnuLvContextAdd, "mnuLvContextAdd")
        '
        'mnuLvContextAddSep
        '
        Me.mnuLvContextAddSep.Name = "mnuLvContextAddSep"
        resources.ApplyResources(Me.mnuLvContextAddSep, "mnuLvContextAddSep")
        '
        'mnuLvContextDelete
        '
        Me.mnuLvContextDelete.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.mnuLvContextDelete.Name = "mnuLvContextDelete"
        resources.ApplyResources(Me.mnuLvContextDelete, "mnuLvContextDelete")
        '
        'mnuLvContextDeleteSep
        '
        Me.mnuLvContextDeleteSep.Name = "mnuLvContextDeleteSep"
        resources.ApplyResources(Me.mnuLvContextDeleteSep, "mnuLvContextDeleteSep")
        '
        'mnuLvContextImport
        '
        Me.mnuLvContextImport.Name = "mnuLvContextImport"
        resources.ApplyResources(Me.mnuLvContextImport, "mnuLvContextImport")
        '
        'mnuLvContextExport
        '
        Me.mnuLvContextExport.Name = "mnuLvContextExport"
        resources.ApplyResources(Me.mnuLvContextExport, "mnuLvContextExport")
        '
        'iml
        '
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.Transparent
        Me.iml.Images.SetKeyName(0, "preview")
        Me.iml.Images.SetKeyName(1, "export")
        Me.iml.Images.SetKeyName(2, "viewer")
        '
        'picInvalidated
        '
        resources.ApplyResources(Me.picInvalidated, "picInvalidated")
        Me.picInvalidated.Name = "picInvalidated"
        Me.picInvalidated.TabStop = False
        '
        'pnlPopup
        '
        Me.pnlPopup.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.pnlPopup.Controls.Add(Me.cmdRefresh)
        Me.pnlPopup.Controls.Add(Me.picInvalidated)
        Me.pnlPopup.Controls.Add(Me.lblPopupWarning)
        resources.ApplyResources(Me.pnlPopup, "pnlPopup")
        Me.pnlPopup.Name = "pnlPopup"
        '
        'cmdRefresh
        '
        resources.ApplyResources(Me.cmdRefresh, "cmdRefresh")
        Me.cmdRefresh.Image = Global.cSurveyPC.My.Resources.Resources.arrow_refresh_small
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'lblPopupWarning
        '
        resources.ApplyResources(Me.lblPopupWarning, "lblPopupWarning")
        Me.lblPopupWarning.Name = "lblPopupWarning"
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
        'frmPreview
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.trkZoom)
        Me.Controls.Add(Me.pnlMap)
        Me.Controls.Add(Me.pnlExport)
        Me.Controls.Add(Me.pPreview)
        Me.Controls.Add(Me.pnlPopup)
        Me.Controls.Add(Me.pnlOptions)
        Me.Controls.Add(Me.sbMain)
        Me.Controls.Add(Me.lv)
        Me.Controls.Add(Me.tbMain)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "frmPreview"
        Me.pnlOptions.ResumeLayout(False)
        Me.tblOptions.ResumeLayout(False)
        Me.pnlCompass.ResumeLayout(False)
        Me.pnlCompass.PerformLayout()
        Me.pnlScale.ResumeLayout(False)
        Me.pnlScale.PerformLayout()
        Me.pnlInformationBox.ResumeLayout(False)
        Me.pnlInformationBox.PerformLayout()
        Me.pnlScaleOptions.ResumeLayout(False)
        Me.pnlScaleOptions.PerformLayout()
        CType(Me.txtScaleManual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMainOptions.ResumeLayout(False)
        Me.pnlMainOptions.PerformLayout()
        Me.pnlPrintOptions.ResumeLayout(False)
        Me.pnlPrintOptions.PerformLayout()
        Me.grpOrientation.ResumeLayout(False)
        Me.pnlExportOptions.ResumeLayout(False)
        Me.pnlExportOptions.PerformLayout()
        Me.pnlProfile.ResumeLayout(False)
        Me.pnlProfile.PerformLayout()
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        Me.pnlExport.ResumeLayout(False)
        CType(Me.picExport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sbMain.ResumeLayout(False)
        Me.sbMain.PerformLayout()
        Me.mnuLvContext.ResumeLayout(False)
        CType(Me.picInvalidated, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPopup.ResumeLayout(False)
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMap.ResumeLayout(False)
        CType(Me.trkZoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlOptions As System.Windows.Forms.Panel
    Friend WithEvents pPreview As System.Windows.Forms.PrintPreviewControl
    Friend WithEvents chkPrintBox As System.Windows.Forms.CheckBox
    Friend WithEvents cboScalePosition As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboBoxPosition As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkPrintScale As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrintCentreline As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrintLRUD As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrintStations As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrintShots As System.Windows.Forms.CheckBox
    Friend WithEvents cboCompassPosition As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkPrintCompass As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrintCentrelineColorGray As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrintDesign As System.Windows.Forms.CheckBox
    Friend WithEvents cboPrinter As System.Windows.Forms.ComboBox
    Friend WithEvents lblPrinter As System.Windows.Forms.Label
    Friend WithEvents grpOrientation As System.Windows.Forms.GroupBox
    Friend WithEvents optPageHorizontal As System.Windows.Forms.RadioButton
    Friend WithEvents optPageVertical As System.Windows.Forms.RadioButton
    Friend WithEvents tbMain As System.Windows.Forms.ToolStrip
    Friend WithEvents sep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkPrintImages As System.Windows.Forms.CheckBox
    Friend WithEvents prDialog As System.Windows.Forms.PrintDialog
    Friend WithEvents sep5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboScale As System.Windows.Forms.ComboBox
    Friend WithEvents lblScale As System.Windows.Forms.Label
    Friend WithEvents txtScaleManual As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblScale1 As System.Windows.Forms.Label
    Friend WithEvents cboPageFormat As System.Windows.Forms.ComboBox
    Friend WithEvents lblPageFormat As System.Windows.Forms.Label
    Friend WithEvents cmdSetMargins As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlPrintOptions As System.Windows.Forms.Panel
    Friend WithEvents pnlExportOptions As System.Windows.Forms.Panel
    Friend WithEvents cboFileFormat As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnlExport As System.Windows.Forms.Panel
    Friend WithEvents picExport As System.Windows.Forms.PictureBox
    Friend WithEvents btnZoomIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnZoomOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents sep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnZoomToFit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnInfoBoxDetails As System.Windows.Forms.Button
    Friend WithEvents btnCompassDetails As System.Windows.Forms.Button
    Friend WithEvents btnScaleDetails As System.Windows.Forms.Button
    Friend WithEvents chkPrintDesignSpecialPoint As System.Windows.Forms.CheckBox
    Friend WithEvents txtImageWidth As System.Windows.Forms.TextBox
    Friend WithEvents txtImageHeight As System.Windows.Forms.TextBox
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents cboGPSData As System.Windows.Forms.ComboBox
    Friend WithEvents lblGPSData As System.Windows.Forms.Label
    Friend WithEvents chkExportGPS As System.Windows.Forms.CheckBox
    Friend WithEvents chkBackgroundTransparent As System.Windows.Forms.CheckBox
    Friend WithEvents cmdSetImageMargins As System.Windows.Forms.Button
    Friend WithEvents cboPrintDesignStyle As System.Windows.Forms.ComboBox
    Friend WithEvents chkPrintDesignStyle As System.Windows.Forms.Label
    Friend WithEvents chkTranslations As System.Windows.Forms.CheckBox
    Friend WithEvents btnTranslationsDetails As System.Windows.Forms.Button
    Friend WithEvents btnPreviewQuality As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnPreviewQuality0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPreviewQuality1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPreviewQuality2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sep3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents sbMain As System.Windows.Forms.StatusStrip
    Friend WithEvents pnlStatusText As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pnlStatusProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents btnManualRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents sep4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdScaleTools As System.Windows.Forms.Button
    Friend WithEvents chkPrintDesignAdvancedBrushes As System.Windows.Forms.CheckBox
    Friend WithEvents btnImportSettings As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnImportSettings0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImportSettings1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImportSettings2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnImportSettings3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImportSettings4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImportSettings5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdManageProfile As System.Windows.Forms.Button
    Friend WithEvents txtCurrentProfile As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentProfile As System.Windows.Forms.Label
    Friend WithEvents lv As System.Windows.Forms.ListView
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlStatusCurrentRule As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents chkUseDrawingZOrder As System.Windows.Forms.CheckBox
    Friend WithEvents btnZOrderDetails As System.Windows.Forms.Button
    Friend WithEvents picInvalidated As System.Windows.Forms.PictureBox
    Friend WithEvents pnlPopup As System.Windows.Forms.Panel
    Friend WithEvents lblPopupWarning As System.Windows.Forms.Label
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents mnuLvContext As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuLvContextAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLvContextAddSep As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuLvContextDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkPrintSketches As System.Windows.Forms.CheckBox
    Friend WithEvents pnlMainOptions As System.Windows.Forms.Panel
    Friend WithEvents tblOptions As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlScaleOptions As System.Windows.Forms.Panel
    Friend WithEvents picMap As System.Windows.Forms.PictureBox
    Friend WithEvents pnlMap As System.Windows.Forms.Panel
    Friend WithEvents btnSidePanel As System.Windows.Forms.ToolStripButton
    Friend WithEvents sep6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chkPrintCombineColorGray As System.Windows.Forms.CheckBox
    Friend WithEvents cboPrintCombineColorMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblPrintCombineColorMode As System.Windows.Forms.Label
    Friend WithEvents btnProperty As System.Windows.Forms.ToolStripButton
    Friend WithEvents sep7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDesignDetails As System.Windows.Forms.Button
    Friend WithEvents btnSegmentDetails As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuLvContextDeleteSep As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuLvContextImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLvContextExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkPrintSplay As System.Windows.Forms.CheckBox
    Friend WithEvents trkZoom As System.Windows.Forms.TrackBar
    Friend WithEvents pnlStatusDesignZoom As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cboPrintCenterlineColorMode As ComboBox
    Friend WithEvents lblPrintCenterlineColorMode As Label
    Friend WithEvents pnlCompass As Panel
    Friend WithEvents pnlScale As Panel
    Friend WithEvents pnlInformationBox As Panel
    Friend WithEvents pnlProfile As Panel
    Friend WithEvents pnlStatusDesignZoom100 As ToolStripStatusLabel
    Friend WithEvents pnlStatusDesignZoom200 As ToolStripStatusLabel
    Friend WithEvents pnlStatusDesignZoom250 As ToolStripStatusLabel
    Friend WithEvents pnlStatusDesignZoom500 As ToolStripStatusLabel
    Friend WithEvents pnlStatusDesignZoom1000 As ToolStripStatusLabel
End Class
