<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemBrushStylePropertyControl
    Inherits cItemPropertyControl

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemBrushStylePropertyControl))
        Me.cboPropBrushPattern = New cSurveyPC.cBrushStyleDropDown()
        Me.cmdPropBrushReseed = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPropBrushClipartPosition = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropBrushClipartPosition = New System.Windows.Forms.ComboBox()
        Me.lblPropBrushClipartImage = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropBrushAlternativeBrushColor = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropBrushColor = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropBrushClipartAngle = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropBrushClipartAngleMode = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropBrushClipartAngleMode = New System.Windows.Forms.ComboBox()
        Me.lblPattern = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropBrushClipartZoomFactor = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropBrushClipartDensity = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropBrushPatternType = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropBrushPatternType = New System.Windows.Forms.ComboBox()
        Me.cboPropBrushClipartCrop = New System.Windows.Forms.ComboBox()
        Me.lblPropBrushClipartCrop = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropBrushPatternPen = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropBrushPatternPen = New System.Windows.Forms.ComboBox()
        Me.txtPropBrushColor = New cSurveyPC.cColorSelector()
        Me.txtPropBrushAlternativeBrushColor = New cSurveyPC.cColorSelector()
        Me.lblBrush = New DevExpress.XtraEditors.LabelControl()
        Me.cmdPropBrushBrowseClipart = New DevExpress.XtraEditors.SimpleButton()
        Me.picPropBrushClipartImage = New DevExpress.XtraEditors.PictureEdit()
        Me.mnuSaveAs = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.btnPropSaveToFile = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPropSaveToSurvey = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPropImport = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPropExport = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.mnuContext = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.btnPropCustomize = New DevExpress.XtraBars.BarButtonItem()
        Me.barPattern = New DevExpress.XtraBars.Bar()
        Me.btnPropPatternAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPropPatternDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPropPatternPrevious = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPropPatternNext = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPropPatternMoveDown = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPropPatternMoveUp = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.cmdPropSave = New DevExpress.XtraEditors.DropDownButton()
        Me.txtPropBrushClipartZoomFactor = New DevExpress.XtraEditors.SpinEdit()
        Me.txtPropBrushClipartDensity = New DevExpress.XtraEditors.SpinEdit()
        Me.txtPropBrushClipartAngle = New DevExpress.XtraEditors.SpinEdit()
        Me.pnlBrushStyle = New DevExpress.XtraEditors.PanelControl()
        Me.cboPropBrushHatch = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.pnlBrushClipart = New DevExpress.XtraEditors.PanelControl()
        Me.pnlBrushPattern = New DevExpress.XtraEditors.PanelControl()
        Me.pnlBrushAlternativeColor = New DevExpress.XtraEditors.PanelControl()
        Me.pnlBrushClipartSettings = New DevExpress.XtraEditors.PanelControl()
        Me.pnlBrushTexture = New DevExpress.XtraEditors.PanelControl()
        Me.picPropBrushTextureImage = New DevExpress.XtraEditors.PictureEdit()
        Me.lblPropBrushTextureImage = New DevExpress.XtraEditors.LabelControl()
        Me.cmdPropBrushBrowseTexture = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlBrushPatternSettings = New DevExpress.XtraEditors.PanelControl()
        Me.lblPropBrushPatternParameters = New DevExpress.XtraEditors.LabelControl()
        Me.prpPropBrushPatterParameters = New DevExpress.XtraVerticalGrid.PropertyGridControl()
        Me.txtPropBrushPatternDeltaY = New DevExpress.XtraEditors.SpinEdit()
        Me.lblPropBrushPatternDeltaXY = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropBrushPatternDeltaX = New DevExpress.XtraEditors.SpinEdit()
        Me.lblPropBrushPatternZoomFactor = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropBrushPatternZoomFactor = New DevExpress.XtraEditors.SpinEdit()
        Me.txtPropBrushPatternDensity = New DevExpress.XtraEditors.SpinEdit()
        Me.lblPropBrushPatternAngleMode = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropBrushPatternAngleMode = New System.Windows.Forms.ComboBox()
        Me.txtPropBrushPatternAngle = New DevExpress.XtraEditors.SpinEdit()
        Me.lblPropBrushPatternDensity = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropBrushPatternAngle = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropBrushBackcolor = New cSurveyPC.cColorSelector()
        Me.lblPropBrushPatternBackcolor = New DevExpress.XtraEditors.LabelControl()
        Me.pnlBrushBackgroundColor = New DevExpress.XtraEditors.PanelControl()
        CType(Me.txtPropBrushColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropBrushAlternativeBrushColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPropBrushClipartImage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuSaveAs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropBrushClipartZoomFactor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropBrushClipartDensity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropBrushClipartAngle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlBrushStyle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBrushStyle.SuspendLayout()
        CType(Me.cboPropBrushHatch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlBrushClipart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBrushClipart.SuspendLayout()
        CType(Me.pnlBrushPattern, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBrushPattern.SuspendLayout()
        CType(Me.pnlBrushAlternativeColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBrushAlternativeColor.SuspendLayout()
        CType(Me.pnlBrushClipartSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBrushClipartSettings.SuspendLayout()
        CType(Me.pnlBrushTexture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBrushTexture.SuspendLayout()
        CType(Me.picPropBrushTextureImage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlBrushPatternSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBrushPatternSettings.SuspendLayout()
        CType(Me.prpPropBrushPatterParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropBrushPatternDeltaY.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropBrushPatternDeltaX.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropBrushPatternZoomFactor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropBrushPatternDensity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropBrushPatternAngle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropBrushBackcolor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlBrushBackgroundColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBrushBackgroundColor.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboPropBrushPattern
        '
        resources.ApplyResources(Me.cboPropBrushPattern, "cboPropBrushPattern")
        Me.cboPropBrushPattern.EditValue = "BigDebrits"
        Me.cboPropBrushPattern.Name = "cboPropBrushPattern"
        '
        'cmdPropBrushReseed
        '
        resources.ApplyResources(Me.cmdPropBrushReseed, "cmdPropBrushReseed")
        Me.cmdPropBrushReseed.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropBrushReseed.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_refresh
        Me.cmdPropBrushReseed.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdPropBrushReseed.Name = "cmdPropBrushReseed"
        '
        'lblPropBrushClipartPosition
        '
        resources.ApplyResources(Me.lblPropBrushClipartPosition, "lblPropBrushClipartPosition")
        Me.lblPropBrushClipartPosition.Name = "lblPropBrushClipartPosition"
        '
        'cboPropBrushClipartPosition
        '
        Me.cboPropBrushClipartPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBrushClipartPosition.DropDownWidth = 120
        Me.cboPropBrushClipartPosition.FormattingEnabled = True
        Me.cboPropBrushClipartPosition.Items.AddRange(New Object() {resources.GetString("cboPropBrushClipartPosition.Items"), resources.GetString("cboPropBrushClipartPosition.Items1")})
        resources.ApplyResources(Me.cboPropBrushClipartPosition, "cboPropBrushClipartPosition")
        Me.cboPropBrushClipartPosition.Name = "cboPropBrushClipartPosition"
        '
        'lblPropBrushClipartImage
        '
        resources.ApplyResources(Me.lblPropBrushClipartImage, "lblPropBrushClipartImage")
        Me.lblPropBrushClipartImage.Name = "lblPropBrushClipartImage"
        '
        'lblPropBrushAlternativeBrushColor
        '
        resources.ApplyResources(Me.lblPropBrushAlternativeBrushColor, "lblPropBrushAlternativeBrushColor")
        Me.lblPropBrushAlternativeBrushColor.Name = "lblPropBrushAlternativeBrushColor"
        '
        'lblPropBrushColor
        '
        resources.ApplyResources(Me.lblPropBrushColor, "lblPropBrushColor")
        Me.lblPropBrushColor.Name = "lblPropBrushColor"
        '
        'lblPropBrushClipartAngle
        '
        resources.ApplyResources(Me.lblPropBrushClipartAngle, "lblPropBrushClipartAngle")
        Me.lblPropBrushClipartAngle.Name = "lblPropBrushClipartAngle"
        '
        'lblPropBrushClipartAngleMode
        '
        resources.ApplyResources(Me.lblPropBrushClipartAngleMode, "lblPropBrushClipartAngleMode")
        Me.lblPropBrushClipartAngleMode.Name = "lblPropBrushClipartAngleMode"
        '
        'cboPropBrushClipartAngleMode
        '
        Me.cboPropBrushClipartAngleMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBrushClipartAngleMode.FormattingEnabled = True
        Me.cboPropBrushClipartAngleMode.Items.AddRange(New Object() {resources.GetString("cboPropBrushClipartAngleMode.Items"), resources.GetString("cboPropBrushClipartAngleMode.Items1")})
        resources.ApplyResources(Me.cboPropBrushClipartAngleMode, "cboPropBrushClipartAngleMode")
        Me.cboPropBrushClipartAngleMode.Name = "cboPropBrushClipartAngleMode"
        '
        'lblPattern
        '
        resources.ApplyResources(Me.lblPattern, "lblPattern")
        Me.lblPattern.Name = "lblPattern"
        '
        'lblPropBrushClipartZoomFactor
        '
        resources.ApplyResources(Me.lblPropBrushClipartZoomFactor, "lblPropBrushClipartZoomFactor")
        Me.lblPropBrushClipartZoomFactor.Name = "lblPropBrushClipartZoomFactor"
        '
        'lblPropBrushClipartDensity
        '
        resources.ApplyResources(Me.lblPropBrushClipartDensity, "lblPropBrushClipartDensity")
        Me.lblPropBrushClipartDensity.Name = "lblPropBrushClipartDensity"
        '
        'lblPropBrushPatternType
        '
        resources.ApplyResources(Me.lblPropBrushPatternType, "lblPropBrushPatternType")
        Me.lblPropBrushPatternType.Name = "lblPropBrushPatternType"
        '
        'cboPropBrushPatternType
        '
        Me.cboPropBrushPatternType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBrushPatternType.FormattingEnabled = True
        Me.cboPropBrushPatternType.Items.AddRange(New Object() {resources.GetString("cboPropBrushPatternType.Items"), resources.GetString("cboPropBrushPatternType.Items1"), resources.GetString("cboPropBrushPatternType.Items2"), resources.GetString("cboPropBrushPatternType.Items3"), resources.GetString("cboPropBrushPatternType.Items4"), resources.GetString("cboPropBrushPatternType.Items5"), resources.GetString("cboPropBrushPatternType.Items6"), resources.GetString("cboPropBrushPatternType.Items7"), resources.GetString("cboPropBrushPatternType.Items8"), resources.GetString("cboPropBrushPatternType.Items9"), resources.GetString("cboPropBrushPatternType.Items10"), resources.GetString("cboPropBrushPatternType.Items11"), resources.GetString("cboPropBrushPatternType.Items12"), resources.GetString("cboPropBrushPatternType.Items13"), resources.GetString("cboPropBrushPatternType.Items14"), resources.GetString("cboPropBrushPatternType.Items15"), resources.GetString("cboPropBrushPatternType.Items16")})
        resources.ApplyResources(Me.cboPropBrushPatternType, "cboPropBrushPatternType")
        Me.cboPropBrushPatternType.Name = "cboPropBrushPatternType"
        '
        'cboPropBrushClipartCrop
        '
        Me.cboPropBrushClipartCrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBrushClipartCrop.FormattingEnabled = True
        Me.cboPropBrushClipartCrop.Items.AddRange(New Object() {resources.GetString("cboPropBrushClipartCrop.Items"), resources.GetString("cboPropBrushClipartCrop.Items1"), resources.GetString("cboPropBrushClipartCrop.Items2")})
        resources.ApplyResources(Me.cboPropBrushClipartCrop, "cboPropBrushClipartCrop")
        Me.cboPropBrushClipartCrop.Name = "cboPropBrushClipartCrop"
        '
        'lblPropBrushClipartCrop
        '
        resources.ApplyResources(Me.lblPropBrushClipartCrop, "lblPropBrushClipartCrop")
        Me.lblPropBrushClipartCrop.Name = "lblPropBrushClipartCrop"
        '
        'lblPropBrushPatternPen
        '
        resources.ApplyResources(Me.lblPropBrushPatternPen, "lblPropBrushPatternPen")
        Me.lblPropBrushPatternPen.Name = "lblPropBrushPatternPen"
        '
        'cboPropBrushPatternPen
        '
        Me.cboPropBrushPatternPen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBrushPatternPen.FormattingEnabled = True
        Me.cboPropBrushPatternPen.Items.AddRange(New Object() {resources.GetString("cboPropBrushPatternPen.Items"), resources.GetString("cboPropBrushPatternPen.Items1"), resources.GetString("cboPropBrushPatternPen.Items2"), resources.GetString("cboPropBrushPatternPen.Items3"), resources.GetString("cboPropBrushPatternPen.Items4")})
        resources.ApplyResources(Me.cboPropBrushPatternPen, "cboPropBrushPatternPen")
        Me.cboPropBrushPatternPen.Name = "cboPropBrushPatternPen"
        '
        'txtPropBrushColor
        '
        Me.txtPropBrushColor.DefaultColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.txtPropBrushColor, "txtPropBrushColor")
        Me.txtPropBrushColor.Name = "txtPropBrushColor"
        Me.txtPropBrushColor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropBrushColor.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropBrushColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtPropBrushColor.Properties.NullColor = System.Drawing.Color.Empty
        Me.txtPropBrushColor.Properties.ShowSystemColors = False
        Me.txtPropBrushColor.Properties.ShowWebColors = False
        '
        'txtPropBrushAlternativeBrushColor
        '
        Me.txtPropBrushAlternativeBrushColor.DefaultColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.txtPropBrushAlternativeBrushColor, "txtPropBrushAlternativeBrushColor")
        Me.txtPropBrushAlternativeBrushColor.Name = "txtPropBrushAlternativeBrushColor"
        Me.txtPropBrushAlternativeBrushColor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropBrushAlternativeBrushColor.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropBrushAlternativeBrushColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtPropBrushAlternativeBrushColor.Properties.NullColor = System.Drawing.Color.Empty
        Me.txtPropBrushAlternativeBrushColor.Properties.ShowSystemColors = False
        Me.txtPropBrushAlternativeBrushColor.Properties.ShowWebColors = False
        '
        'lblBrush
        '
        resources.ApplyResources(Me.lblBrush, "lblBrush")
        Me.lblBrush.Name = "lblBrush"
        '
        'cmdPropBrushBrowseClipart
        '
        Me.cmdPropBrushBrowseClipart.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropBrushBrowseClipart.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.open
        Me.cmdPropBrushBrowseClipart.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdPropBrushBrowseClipart, "cmdPropBrushBrowseClipart")
        Me.cmdPropBrushBrowseClipart.Name = "cmdPropBrushBrowseClipart"
        '
        'picPropBrushClipartImage
        '
        resources.ApplyResources(Me.picPropBrushClipartImage, "picPropBrushClipartImage")
        Me.picPropBrushClipartImage.Name = "picPropBrushClipartImage"
        Me.picPropBrushClipartImage.Properties.NullText = resources.GetString("picPropBrushClipartImage.Properties.NullText")
        Me.picPropBrushClipartImage.Properties.ReadOnly = True
        Me.picPropBrushClipartImage.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.[False]
        Me.picPropBrushClipartImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        '
        'mnuSaveAs
        '
        Me.mnuSaveAs.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnPropSaveToFile), New DevExpress.XtraBars.LinkPersistInfo(Me.btnPropSaveToSurvey), New DevExpress.XtraBars.LinkPersistInfo(Me.btnPropImport, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnPropExport)})
        Me.mnuSaveAs.Manager = Me.BarManager
        Me.mnuSaveAs.Name = "mnuSaveAs"
        '
        'btnPropSaveToFile
        '
        resources.ApplyResources(Me.btnPropSaveToFile, "btnPropSaveToFile")
        Me.btnPropSaveToFile.Id = 23
        Me.btnPropSaveToFile.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.saveas
        Me.btnPropSaveToFile.Name = "btnPropSaveToFile"
        '
        'btnPropSaveToSurvey
        '
        resources.ApplyResources(Me.btnPropSaveToSurvey, "btnPropSaveToSurvey")
        Me.btnPropSaveToSurvey.Id = 24
        Me.btnPropSaveToSurvey.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.savedialog
        Me.btnPropSaveToSurvey.Name = "btnPropSaveToSurvey"
        '
        'btnPropImport
        '
        resources.ApplyResources(Me.btnPropImport, "btnPropImport")
        Me.btnPropImport.Enabled = False
        Me.btnPropImport.Id = 26
        Me.btnPropImport.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.import
        Me.btnPropImport.Name = "btnPropImport"
        '
        'btnPropExport
        '
        resources.ApplyResources(Me.btnPropExport, "btnPropExport")
        Me.btnPropExport.Id = 25
        Me.btnPropExport.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.exportfile
        Me.btnPropExport.Name = "btnPropExport"
        '
        'BarManager
        '
        Me.BarManager.AllowCustomization = False
        Me.BarManager.AllowQuickCustomization = False
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.barPattern})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.DockControls.Add(Me.StandaloneBarDockControl1)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnPropSaveToFile, Me.btnPropSaveToSurvey, Me.btnPropExport, Me.btnPropImport, Me.btnPropPatternAdd, Me.btnPropPatternDelete, Me.btnPropPatternPrevious, Me.btnPropPatternNext, Me.btnPropPatternMoveDown, Me.btnPropPatternMoveUp, Me.btnPropCustomize})
        Me.BarManager.MaxItemId = 35
        '
        'mnuContext
        '
        Me.mnuContext.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnPropCustomize)})
        Me.mnuContext.Manager = Me.BarManager
        Me.mnuContext.Name = "mnuContext"
        '
        'btnPropCustomize
        '
        resources.ApplyResources(Me.btnPropCustomize, "btnPropCustomize")
        Me.btnPropCustomize.Id = 33
        Me.btnPropCustomize.Name = "btnPropCustomize"
        '
        'barPattern
        '
        Me.barPattern.BarName = "Pattern"
        Me.barPattern.DockCol = 0
        Me.barPattern.DockRow = 0
        Me.barPattern.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.barPattern.FloatLocation = New System.Drawing.Point(331, 191)
        Me.barPattern.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnPropPatternAdd), New DevExpress.XtraBars.LinkPersistInfo(Me.btnPropPatternDelete), New DevExpress.XtraBars.LinkPersistInfo(Me.btnPropPatternPrevious, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnPropPatternNext), New DevExpress.XtraBars.LinkPersistInfo(Me.btnPropPatternMoveDown, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnPropPatternMoveUp)})
        Me.barPattern.OptionsBar.DisableClose = True
        Me.barPattern.OptionsBar.DisableCustomization = True
        Me.barPattern.OptionsBar.DrawBorder = False
        Me.barPattern.OptionsBar.DrawDragBorder = False
        Me.barPattern.OptionsBar.RotateWhenVertical = False
        Me.barPattern.OptionsBar.UseWholeRow = True
        Me.barPattern.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        resources.ApplyResources(Me.barPattern, "barPattern")
        '
        'btnPropPatternAdd
        '
        Me.btnPropPatternAdd.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.btnPropPatternAdd, "btnPropPatternAdd")
        Me.btnPropPatternAdd.Id = 27
        Me.btnPropPatternAdd.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_add
        Me.btnPropPatternAdd.Name = "btnPropPatternAdd"
        '
        'btnPropPatternDelete
        '
        Me.btnPropPatternDelete.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.btnPropPatternDelete, "btnPropPatternDelete")
        Me.btnPropPatternDelete.Enabled = False
        Me.btnPropPatternDelete.Id = 28
        Me.btnPropPatternDelete.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.delete1
        Me.btnPropPatternDelete.Name = "btnPropPatternDelete"
        '
        'btnPropPatternPrevious
        '
        Me.btnPropPatternPrevious.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.btnPropPatternPrevious, "btnPropPatternPrevious")
        Me.btnPropPatternPrevious.Enabled = False
        Me.btnPropPatternPrevious.Id = 29
        Me.btnPropPatternPrevious.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_arrow4left
        Me.btnPropPatternPrevious.Name = "btnPropPatternPrevious"
        '
        'btnPropPatternNext
        '
        Me.btnPropPatternNext.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.btnPropPatternNext, "btnPropPatternNext")
        Me.btnPropPatternNext.Enabled = False
        Me.btnPropPatternNext.Id = 30
        Me.btnPropPatternNext.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_arrow4right
        Me.btnPropPatternNext.Name = "btnPropPatternNext"
        '
        'btnPropPatternMoveDown
        '
        Me.btnPropPatternMoveDown.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.btnPropPatternMoveDown, "btnPropPatternMoveDown")
        Me.btnPropPatternMoveDown.Enabled = False
        Me.btnPropPatternMoveDown.Id = 31
        Me.btnPropPatternMoveDown.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.layers2
        Me.btnPropPatternMoveDown.Name = "btnPropPatternMoveDown"
        '
        'btnPropPatternMoveUp
        '
        Me.btnPropPatternMoveUp.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.btnPropPatternMoveUp, "btnPropPatternMoveUp")
        Me.btnPropPatternMoveUp.Enabled = False
        Me.btnPropPatternMoveUp.Id = 32
        Me.btnPropPatternMoveUp.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.layers11
        Me.btnPropPatternMoveUp.Name = "btnPropPatternMoveUp"
        '
        'StandaloneBarDockControl1
        '
        resources.ApplyResources(Me.StandaloneBarDockControl1, "StandaloneBarDockControl1")
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Manager = Me.BarManager
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
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
        'cmdPropSave
        '
        resources.ApplyResources(Me.cmdPropSave, "cmdPropSave")
        Me.cmdPropSave.DropDownControl = Me.mnuSaveAs
        Me.cmdPropSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropSave.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.savedialog
        Me.cmdPropSave.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdPropSave.Name = "cmdPropSave"
        '
        'txtPropBrushClipartZoomFactor
        '
        resources.ApplyResources(Me.txtPropBrushClipartZoomFactor, "txtPropBrushClipartZoomFactor")
        Me.txtPropBrushClipartZoomFactor.MenuManager = Me.BarManager
        Me.txtPropBrushClipartZoomFactor.Name = "txtPropBrushClipartZoomFactor"
        Me.txtPropBrushClipartZoomFactor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropBrushClipartZoomFactor.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropBrushClipartZoomFactor.Properties.DisplayFormat.FormatString = "N2"
        Me.txtPropBrushClipartZoomFactor.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropBrushClipartZoomFactor.Properties.EditFormat.FormatString = "N2"
        Me.txtPropBrushClipartZoomFactor.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropBrushClipartZoomFactor.Properties.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtPropBrushClipartZoomFactor.Properties.MaskSettings.Set("mask", "N2")
        Me.txtPropBrushClipartZoomFactor.Properties.MaxValue = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtPropBrushClipartZoomFactor.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 131072})
        '
        'txtPropBrushClipartDensity
        '
        resources.ApplyResources(Me.txtPropBrushClipartDensity, "txtPropBrushClipartDensity")
        Me.txtPropBrushClipartDensity.MenuManager = Me.BarManager
        Me.txtPropBrushClipartDensity.Name = "txtPropBrushClipartDensity"
        Me.txtPropBrushClipartDensity.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropBrushClipartDensity.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropBrushClipartDensity.Properties.DisplayFormat.FormatString = "N2"
        Me.txtPropBrushClipartDensity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropBrushClipartDensity.Properties.EditFormat.FormatString = "N2"
        Me.txtPropBrushClipartDensity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropBrushClipartDensity.Properties.MaskSettings.Set("mask", "N2")
        Me.txtPropBrushClipartDensity.Properties.MaxValue = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtPropBrushClipartDensity.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 131072})
        '
        'txtPropBrushClipartAngle
        '
        resources.ApplyResources(Me.txtPropBrushClipartAngle, "txtPropBrushClipartAngle")
        Me.txtPropBrushClipartAngle.MenuManager = Me.BarManager
        Me.txtPropBrushClipartAngle.Name = "txtPropBrushClipartAngle"
        Me.txtPropBrushClipartAngle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropBrushClipartAngle.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropBrushClipartAngle.Properties.DisplayFormat.FormatString = "N2"
        Me.txtPropBrushClipartAngle.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropBrushClipartAngle.Properties.EditFormat.FormatString = "N2"
        Me.txtPropBrushClipartAngle.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropBrushClipartAngle.Properties.MaskSettings.Set("mask", "N2")
        Me.txtPropBrushClipartAngle.Properties.MaxValue = New Decimal(New Integer() {35999, 0, 0, 131072})
        '
        'pnlBrushStyle
        '
        Me.pnlBrushStyle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlBrushStyle.Controls.Add(Me.lblPattern)
        Me.pnlBrushStyle.Controls.Add(Me.lblPropBrushColor)
        Me.pnlBrushStyle.Controls.Add(Me.txtPropBrushColor)
        Me.pnlBrushStyle.Controls.Add(Me.cboPropBrushHatch)
        resources.ApplyResources(Me.pnlBrushStyle, "pnlBrushStyle")
        Me.pnlBrushStyle.Name = "pnlBrushStyle"
        '
        'cboPropBrushHatch
        '
        resources.ApplyResources(Me.cboPropBrushHatch, "cboPropBrushHatch")
        Me.cboPropBrushHatch.MenuManager = Me.BarManager
        Me.cboPropBrushHatch.Name = "cboPropBrushHatch"
        Me.cboPropBrushHatch.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPropBrushHatch.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPropBrushHatch.Properties.Items.AddRange(New Object() {resources.GetString("cboPropBrushHatch.Properties.Items"), resources.GetString("cboPropBrushHatch.Properties.Items1"), resources.GetString("cboPropBrushHatch.Properties.Items2"), resources.GetString("cboPropBrushHatch.Properties.Items3"), resources.GetString("cboPropBrushHatch.Properties.Items4")})
        Me.cboPropBrushHatch.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'pnlBrushClipart
        '
        Me.pnlBrushClipart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlBrushClipart.Controls.Add(Me.picPropBrushClipartImage)
        Me.pnlBrushClipart.Controls.Add(Me.lblPropBrushClipartImage)
        Me.pnlBrushClipart.Controls.Add(Me.cmdPropBrushBrowseClipart)
        resources.ApplyResources(Me.pnlBrushClipart, "pnlBrushClipart")
        Me.pnlBrushClipart.Name = "pnlBrushClipart"
        '
        'pnlBrushPattern
        '
        Me.pnlBrushPattern.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.pnlBrushPattern.Appearance.Options.UseBackColor = True
        Me.pnlBrushPattern.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlBrushPattern.Controls.Add(Me.StandaloneBarDockControl1)
        Me.pnlBrushPattern.Controls.Add(Me.cboPropBrushPatternType)
        Me.pnlBrushPattern.Controls.Add(Me.lblPropBrushPatternType)
        Me.pnlBrushPattern.Controls.Add(Me.cboPropBrushPatternPen)
        Me.pnlBrushPattern.Controls.Add(Me.lblPropBrushPatternPen)
        resources.ApplyResources(Me.pnlBrushPattern, "pnlBrushPattern")
        Me.pnlBrushPattern.Name = "pnlBrushPattern"
        '
        'pnlBrushAlternativeColor
        '
        Me.pnlBrushAlternativeColor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlBrushAlternativeColor.Controls.Add(Me.txtPropBrushAlternativeBrushColor)
        Me.pnlBrushAlternativeColor.Controls.Add(Me.lblPropBrushAlternativeBrushColor)
        resources.ApplyResources(Me.pnlBrushAlternativeColor, "pnlBrushAlternativeColor")
        Me.pnlBrushAlternativeColor.Name = "pnlBrushAlternativeColor"
        '
        'pnlBrushClipartSettings
        '
        Me.pnlBrushClipartSettings.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlBrushClipartSettings.Controls.Add(Me.txtPropBrushClipartDensity)
        Me.pnlBrushClipartSettings.Controls.Add(Me.lblPropBrushClipartAngleMode)
        Me.pnlBrushClipartSettings.Controls.Add(Me.lblPropBrushClipartZoomFactor)
        Me.pnlBrushClipartSettings.Controls.Add(Me.cboPropBrushClipartAngleMode)
        Me.pnlBrushClipartSettings.Controls.Add(Me.txtPropBrushClipartZoomFactor)
        Me.pnlBrushClipartSettings.Controls.Add(Me.txtPropBrushClipartAngle)
        Me.pnlBrushClipartSettings.Controls.Add(Me.cboPropBrushClipartPosition)
        Me.pnlBrushClipartSettings.Controls.Add(Me.lblPropBrushClipartDensity)
        Me.pnlBrushClipartSettings.Controls.Add(Me.cboPropBrushClipartCrop)
        Me.pnlBrushClipartSettings.Controls.Add(Me.lblPropBrushClipartAngle)
        Me.pnlBrushClipartSettings.Controls.Add(Me.lblPropBrushClipartCrop)
        Me.pnlBrushClipartSettings.Controls.Add(Me.lblPropBrushClipartPosition)
        resources.ApplyResources(Me.pnlBrushClipartSettings, "pnlBrushClipartSettings")
        Me.pnlBrushClipartSettings.Name = "pnlBrushClipartSettings"
        '
        'pnlBrushTexture
        '
        Me.pnlBrushTexture.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlBrushTexture.Controls.Add(Me.picPropBrushTextureImage)
        Me.pnlBrushTexture.Controls.Add(Me.lblPropBrushTextureImage)
        Me.pnlBrushTexture.Controls.Add(Me.cmdPropBrushBrowseTexture)
        resources.ApplyResources(Me.pnlBrushTexture, "pnlBrushTexture")
        Me.pnlBrushTexture.Name = "pnlBrushTexture"
        '
        'picPropBrushTextureImage
        '
        resources.ApplyResources(Me.picPropBrushTextureImage, "picPropBrushTextureImage")
        Me.picPropBrushTextureImage.Name = "picPropBrushTextureImage"
        Me.picPropBrushTextureImage.Properties.NullText = resources.GetString("picPropBrushTextureImage.Properties.NullText")
        Me.picPropBrushTextureImage.Properties.ReadOnly = True
        Me.picPropBrushTextureImage.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.[False]
        Me.picPropBrushTextureImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        '
        'lblPropBrushTextureImage
        '
        resources.ApplyResources(Me.lblPropBrushTextureImage, "lblPropBrushTextureImage")
        Me.lblPropBrushTextureImage.Name = "lblPropBrushTextureImage"
        '
        'cmdPropBrushBrowseTexture
        '
        Me.cmdPropBrushBrowseTexture.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropBrushBrowseTexture.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.open
        Me.cmdPropBrushBrowseTexture.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdPropBrushBrowseTexture, "cmdPropBrushBrowseTexture")
        Me.cmdPropBrushBrowseTexture.Name = "cmdPropBrushBrowseTexture"
        '
        'pnlBrushPatternSettings
        '
        Me.pnlBrushPatternSettings.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlBrushPatternSettings.Controls.Add(Me.lblPropBrushPatternParameters)
        Me.pnlBrushPatternSettings.Controls.Add(Me.prpPropBrushPatterParameters)
        Me.pnlBrushPatternSettings.Controls.Add(Me.txtPropBrushPatternDeltaY)
        Me.pnlBrushPatternSettings.Controls.Add(Me.lblPropBrushPatternDeltaXY)
        Me.pnlBrushPatternSettings.Controls.Add(Me.txtPropBrushPatternDeltaX)
        Me.pnlBrushPatternSettings.Controls.Add(Me.lblPropBrushPatternZoomFactor)
        Me.pnlBrushPatternSettings.Controls.Add(Me.txtPropBrushPatternZoomFactor)
        Me.pnlBrushPatternSettings.Controls.Add(Me.txtPropBrushPatternDensity)
        Me.pnlBrushPatternSettings.Controls.Add(Me.lblPropBrushPatternAngleMode)
        Me.pnlBrushPatternSettings.Controls.Add(Me.cboPropBrushPatternAngleMode)
        Me.pnlBrushPatternSettings.Controls.Add(Me.txtPropBrushPatternAngle)
        Me.pnlBrushPatternSettings.Controls.Add(Me.lblPropBrushPatternDensity)
        Me.pnlBrushPatternSettings.Controls.Add(Me.lblPropBrushPatternAngle)
        resources.ApplyResources(Me.pnlBrushPatternSettings, "pnlBrushPatternSettings")
        Me.pnlBrushPatternSettings.Name = "pnlBrushPatternSettings"
        '
        'lblPropBrushPatternParameters
        '
        resources.ApplyResources(Me.lblPropBrushPatternParameters, "lblPropBrushPatternParameters")
        Me.lblPropBrushPatternParameters.Name = "lblPropBrushPatternParameters"
        '
        'prpPropBrushPatterParameters
        '
        Me.prpPropBrushPatterParameters.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.prpPropBrushPatterParameters, "prpPropBrushPatterParameters")
        Me.prpPropBrushPatterParameters.MenuManager = Me.BarManager
        Me.prpPropBrushPatterParameters.Name = "prpPropBrushPatterParameters"
        Me.prpPropBrushPatterParameters.OptionsView.AllowReadOnlyRowAppearance = DevExpress.Utils.DefaultBoolean.[True]
        Me.prpPropBrushPatterParameters.OptionsView.LevelIndent = 0
        Me.prpPropBrushPatterParameters.OptionsView.ShowRootCategories = False
        Me.prpPropBrushPatterParameters.OptionsView.ShowRootLevelIndent = False
        '
        'txtPropBrushPatternDeltaY
        '
        resources.ApplyResources(Me.txtPropBrushPatternDeltaY, "txtPropBrushPatternDeltaY")
        Me.txtPropBrushPatternDeltaY.MenuManager = Me.BarManager
        Me.txtPropBrushPatternDeltaY.Name = "txtPropBrushPatternDeltaY"
        Me.txtPropBrushPatternDeltaY.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropBrushPatternDeltaY.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropBrushPatternDeltaY.Properties.DisplayFormat.FormatString = "N1"
        Me.txtPropBrushPatternDeltaY.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropBrushPatternDeltaY.Properties.EditFormat.FormatString = "N1"
        Me.txtPropBrushPatternDeltaY.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropBrushPatternDeltaY.Properties.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtPropBrushPatternDeltaY.Properties.MaskSettings.Set("mask", "N1")
        Me.txtPropBrushPatternDeltaY.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'lblPropBrushPatternDeltaXY
        '
        resources.ApplyResources(Me.lblPropBrushPatternDeltaXY, "lblPropBrushPatternDeltaXY")
        Me.lblPropBrushPatternDeltaXY.Name = "lblPropBrushPatternDeltaXY"
        '
        'txtPropBrushPatternDeltaX
        '
        resources.ApplyResources(Me.txtPropBrushPatternDeltaX, "txtPropBrushPatternDeltaX")
        Me.txtPropBrushPatternDeltaX.MenuManager = Me.BarManager
        Me.txtPropBrushPatternDeltaX.Name = "txtPropBrushPatternDeltaX"
        Me.txtPropBrushPatternDeltaX.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropBrushPatternDeltaX.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropBrushPatternDeltaX.Properties.DisplayFormat.FormatString = "N1"
        Me.txtPropBrushPatternDeltaX.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropBrushPatternDeltaX.Properties.EditFormat.FormatString = "N1"
        Me.txtPropBrushPatternDeltaX.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropBrushPatternDeltaX.Properties.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtPropBrushPatternDeltaX.Properties.MaskSettings.Set("mask", "N1")
        Me.txtPropBrushPatternDeltaX.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'lblPropBrushPatternZoomFactor
        '
        resources.ApplyResources(Me.lblPropBrushPatternZoomFactor, "lblPropBrushPatternZoomFactor")
        Me.lblPropBrushPatternZoomFactor.Name = "lblPropBrushPatternZoomFactor"
        '
        'txtPropBrushPatternZoomFactor
        '
        resources.ApplyResources(Me.txtPropBrushPatternZoomFactor, "txtPropBrushPatternZoomFactor")
        Me.txtPropBrushPatternZoomFactor.MenuManager = Me.BarManager
        Me.txtPropBrushPatternZoomFactor.Name = "txtPropBrushPatternZoomFactor"
        Me.txtPropBrushPatternZoomFactor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropBrushPatternZoomFactor.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropBrushPatternZoomFactor.Properties.DisplayFormat.FormatString = "N2"
        Me.txtPropBrushPatternZoomFactor.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropBrushPatternZoomFactor.Properties.EditFormat.FormatString = "N2"
        Me.txtPropBrushPatternZoomFactor.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropBrushPatternZoomFactor.Properties.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtPropBrushPatternZoomFactor.Properties.MaskSettings.Set("mask", "N2")
        Me.txtPropBrushPatternZoomFactor.Properties.MaxValue = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtPropBrushPatternZoomFactor.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 131072})
        '
        'txtPropBrushPatternDensity
        '
        resources.ApplyResources(Me.txtPropBrushPatternDensity, "txtPropBrushPatternDensity")
        Me.txtPropBrushPatternDensity.MenuManager = Me.BarManager
        Me.txtPropBrushPatternDensity.Name = "txtPropBrushPatternDensity"
        Me.txtPropBrushPatternDensity.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropBrushPatternDensity.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropBrushPatternDensity.Properties.DisplayFormat.FormatString = "N2"
        Me.txtPropBrushPatternDensity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropBrushPatternDensity.Properties.EditFormat.FormatString = "N2"
        Me.txtPropBrushPatternDensity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropBrushPatternDensity.Properties.MaskSettings.Set("mask", "N2")
        Me.txtPropBrushPatternDensity.Properties.MaxValue = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtPropBrushPatternDensity.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'lblPropBrushPatternAngleMode
        '
        resources.ApplyResources(Me.lblPropBrushPatternAngleMode, "lblPropBrushPatternAngleMode")
        Me.lblPropBrushPatternAngleMode.Name = "lblPropBrushPatternAngleMode"
        '
        'cboPropBrushPatternAngleMode
        '
        Me.cboPropBrushPatternAngleMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBrushPatternAngleMode.FormattingEnabled = True
        Me.cboPropBrushPatternAngleMode.Items.AddRange(New Object() {resources.GetString("cboPropBrushPatternAngleMode.Items")})
        resources.ApplyResources(Me.cboPropBrushPatternAngleMode, "cboPropBrushPatternAngleMode")
        Me.cboPropBrushPatternAngleMode.Name = "cboPropBrushPatternAngleMode"
        '
        'txtPropBrushPatternAngle
        '
        resources.ApplyResources(Me.txtPropBrushPatternAngle, "txtPropBrushPatternAngle")
        Me.txtPropBrushPatternAngle.MenuManager = Me.BarManager
        Me.txtPropBrushPatternAngle.Name = "txtPropBrushPatternAngle"
        Me.txtPropBrushPatternAngle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropBrushPatternAngle.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropBrushPatternAngle.Properties.DisplayFormat.FormatString = "N0"
        Me.txtPropBrushPatternAngle.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropBrushPatternAngle.Properties.EditFormat.FormatString = "N2"
        Me.txtPropBrushPatternAngle.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropBrushPatternAngle.Properties.MaskSettings.Set("mask", "N2")
        Me.txtPropBrushPatternAngle.Properties.MaxValue = New Decimal(New Integer() {35999, 0, 0, 131072})
        '
        'lblPropBrushPatternDensity
        '
        resources.ApplyResources(Me.lblPropBrushPatternDensity, "lblPropBrushPatternDensity")
        Me.lblPropBrushPatternDensity.Name = "lblPropBrushPatternDensity"
        '
        'lblPropBrushPatternAngle
        '
        resources.ApplyResources(Me.lblPropBrushPatternAngle, "lblPropBrushPatternAngle")
        Me.lblPropBrushPatternAngle.Name = "lblPropBrushPatternAngle"
        '
        'txtPropBrushBackcolor
        '
        Me.txtPropBrushBackcolor.DefaultColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.txtPropBrushBackcolor, "txtPropBrushBackcolor")
        Me.txtPropBrushBackcolor.Name = "txtPropBrushBackcolor"
        Me.txtPropBrushBackcolor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropBrushBackcolor.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropBrushBackcolor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtPropBrushBackcolor.Properties.NullColor = System.Drawing.Color.Empty
        Me.txtPropBrushBackcolor.Properties.ShowSystemColors = False
        Me.txtPropBrushBackcolor.Properties.ShowWebColors = False
        '
        'lblPropBrushPatternBackcolor
        '
        resources.ApplyResources(Me.lblPropBrushPatternBackcolor, "lblPropBrushPatternBackcolor")
        Me.lblPropBrushPatternBackcolor.Name = "lblPropBrushPatternBackcolor"
        '
        'pnlBrushBackgroundColor
        '
        Me.pnlBrushBackgroundColor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlBrushBackgroundColor.Controls.Add(Me.txtPropBrushBackcolor)
        Me.pnlBrushBackgroundColor.Controls.Add(Me.lblPropBrushPatternBackcolor)
        resources.ApplyResources(Me.pnlBrushBackgroundColor, "pnlBrushBackgroundColor")
        Me.pnlBrushBackgroundColor.Name = "pnlBrushBackgroundColor"
        '
        'cItemBrushStylePropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.pnlBrushStyle)
        Me.Controls.Add(Me.pnlBrushAlternativeColor)
        Me.Controls.Add(Me.cmdPropBrushReseed)
        Me.Controls.Add(Me.cboPropBrushPattern)
        Me.Controls.Add(Me.lblBrush)
        Me.Controls.Add(Me.cmdPropSave)
        Me.Controls.Add(Me.pnlBrushBackgroundColor)
        Me.Controls.Add(Me.pnlBrushPattern)
        Me.Controls.Add(Me.pnlBrushTexture)
        Me.Controls.Add(Me.pnlBrushClipart)
        Me.Controls.Add(Me.pnlBrushClipartSettings)
        Me.Controls.Add(Me.pnlBrushPatternSettings)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "cItemBrushStylePropertyControl"
        CType(Me.txtPropBrushColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropBrushAlternativeBrushColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPropBrushClipartImage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuSaveAs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropBrushClipartZoomFactor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropBrushClipartDensity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropBrushClipartAngle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlBrushStyle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBrushStyle.ResumeLayout(False)
        Me.pnlBrushStyle.PerformLayout()
        CType(Me.cboPropBrushHatch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlBrushClipart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBrushClipart.ResumeLayout(False)
        Me.pnlBrushClipart.PerformLayout()
        CType(Me.pnlBrushPattern, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBrushPattern.ResumeLayout(False)
        Me.pnlBrushPattern.PerformLayout()
        CType(Me.pnlBrushAlternativeColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBrushAlternativeColor.ResumeLayout(False)
        Me.pnlBrushAlternativeColor.PerformLayout()
        CType(Me.pnlBrushClipartSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBrushClipartSettings.ResumeLayout(False)
        Me.pnlBrushClipartSettings.PerformLayout()
        CType(Me.pnlBrushTexture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBrushTexture.ResumeLayout(False)
        Me.pnlBrushTexture.PerformLayout()
        CType(Me.picPropBrushTextureImage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlBrushPatternSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBrushPatternSettings.ResumeLayout(False)
        Me.pnlBrushPatternSettings.PerformLayout()
        CType(Me.prpPropBrushPatterParameters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropBrushPatternDeltaY.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropBrushPatternDeltaX.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropBrushPatternZoomFactor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropBrushPatternDensity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropBrushPatternAngle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropBrushBackcolor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlBrushBackgroundColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBrushBackgroundColor.ResumeLayout(False)
        Me.pnlBrushBackgroundColor.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboPropBrushPattern As cBrushStyleDropDown
    Friend WithEvents cmdPropBrushReseed As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPropBrushClipartPosition As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropBrushClipartPosition As ComboBox
    Friend WithEvents lblPropBrushClipartImage As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropBrushAlternativeBrushColor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropBrushColor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropBrushClipartAngle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropBrushClipartAngleMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropBrushClipartAngleMode As ComboBox
    Friend WithEvents lblPattern As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropBrushClipartZoomFactor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropBrushClipartDensity As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropBrushPatternType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropBrushPatternType As ComboBox
    Friend WithEvents cboPropBrushClipartCrop As ComboBox
    Friend WithEvents lblPropBrushClipartCrop As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropBrushPatternPen As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropBrushPatternPen As ComboBox
    Friend WithEvents txtPropBrushColor As cColorSelector
    Friend WithEvents txtPropBrushAlternativeBrushColor As cColorSelector
    Friend WithEvents lblBrush As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdPropBrushBrowseClipart As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents picPropBrushClipartImage As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents mnuSaveAs As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnPropSaveToFile As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPropSaveToSurvey As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPropImport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPropExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents cmdPropSave As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents txtPropBrushClipartZoomFactor As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtPropBrushClipartDensity As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtPropBrushClipartAngle As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents pnlBrushStyle As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlBrushClipart As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlBrushPattern As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlBrushAlternativeColor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlBrushClipartSettings As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cboPropBrushHatch As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents pnlBrushTexture As DevExpress.XtraEditors.PanelControl
    Friend WithEvents picPropBrushTextureImage As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents lblPropBrushTextureImage As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdPropBrushBrowseTexture As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlBrushPatternSettings As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtPropBrushPatternDensity As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblPropBrushPatternAngleMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropBrushPatternAngleMode As ComboBox
    Friend WithEvents txtPropBrushPatternAngle As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblPropBrushPatternDensity As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropBrushPatternAngle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropBrushPatternZoomFactor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropBrushPatternZoomFactor As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtPropBrushPatternDeltaY As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblPropBrushPatternDeltaXY As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropBrushPatternDeltaX As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblPropBrushPatternParameters As DevExpress.XtraEditors.LabelControl
    Friend WithEvents prpPropBrushPatterParameters As DevExpress.XtraVerticalGrid.PropertyGridControl
    Friend WithEvents barPattern As DevExpress.XtraBars.Bar
    Friend WithEvents btnPropPatternAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPropPatternDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPropPatternPrevious As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPropPatternNext As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPropPatternMoveDown As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPropPatternMoveUp As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents txtPropBrushBackcolor As cColorSelector
    Friend WithEvents lblPropBrushPatternBackcolor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnlBrushBackgroundColor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents mnuContext As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnPropCustomize As DevExpress.XtraBars.BarButtonItem
End Class
