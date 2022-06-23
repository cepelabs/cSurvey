﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemPenStylePropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemPenStylePropertyControl))
        Me.lblPropPenColor = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropPenDecorationScale = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropPenDecorationSpacePercentage = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropPenWidth = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropPenDecorationAlignment = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropPenStyle = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropPenDecoration = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropPenPattern = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropPenPattern = New cSurveyPC.cPenStyleDropDown()
        Me.txtPropPenColor = New cSurveyPC.cColorSelector()
        Me.cmdPropSave = New DevExpress.XtraEditors.DropDownButton()
        Me.mnuSaveAs = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.btnPropSaveToFile = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPropSaveToSurvey = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPropImport = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPropExport = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.cmdPropPenBrowseClipart = New DevExpress.XtraEditors.SimpleButton()
        Me.picPropPenClipartImage = New DevExpress.XtraEditors.PictureEdit()
        Me.lblPropPenClipartImage = New DevExpress.XtraEditors.LabelControl()
        Me.pnlPenClipartSettings = New DevExpress.XtraEditors.PanelControl()
        Me.cboPropPenDecorationPosition = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblPenPropDecorationPosition = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropPenClipartPenMode = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblPropPenClipartPen = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropPenDecorationScale = New DevExpress.XtraEditors.SpinEdit()
        Me.txtPropPenDecorationSpacePercentage = New DevExpress.XtraEditors.SpinEdit()
        Me.cboPropPenDecorationAlignment = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboPropPenClipartPenStyle = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblPropPenClipartPenStyle = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropPenClipartPenWidth = New DevExpress.XtraEditors.SpinEdit()
        Me.lblPropPenClipartPenColor = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropPenClipartPenWidth = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropPenClipartPenColor = New cSurveyPC.cColorSelector()
        Me.pnlPenClipart = New DevExpress.XtraEditors.PanelControl()
        Me.cmdPropPenCleanClipart = New DevExpress.XtraEditors.SimpleButton()
        Me.cboPropPenDecoration = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboPropPenStyle = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtPropPenWidth = New DevExpress.XtraEditors.SpinEdit()
        Me.pnlPenStyle = New DevExpress.XtraEditors.PanelControl()
        Me.pnlPenClipartSettingsPen = New DevExpress.XtraEditors.PanelControl()
        CType(Me.txtPropPenColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuSaveAs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPropPenClipartImage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlPenClipartSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPenClipartSettings.SuspendLayout()
        CType(Me.cboPropPenDecorationPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPropPenClipartPenMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropPenDecorationScale.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropPenDecorationSpacePercentage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPropPenDecorationAlignment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPropPenClipartPenStyle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropPenClipartPenWidth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropPenClipartPenColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlPenClipart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPenClipart.SuspendLayout()
        CType(Me.cboPropPenDecoration.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPropPenStyle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropPenWidth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlPenStyle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPenStyle.SuspendLayout()
        CType(Me.pnlPenClipartSettingsPen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPenClipartSettingsPen.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblPropPenColor
        '
        resources.ApplyResources(Me.lblPropPenColor, "lblPropPenColor")
        Me.lblPropPenColor.Name = "lblPropPenColor"
        '
        'lblPropPenDecorationScale
        '
        resources.ApplyResources(Me.lblPropPenDecorationScale, "lblPropPenDecorationScale")
        Me.lblPropPenDecorationScale.Name = "lblPropPenDecorationScale"
        '
        'lblPropPenDecorationSpacePercentage
        '
        resources.ApplyResources(Me.lblPropPenDecorationSpacePercentage, "lblPropPenDecorationSpacePercentage")
        Me.lblPropPenDecorationSpacePercentage.Name = "lblPropPenDecorationSpacePercentage"
        '
        'lblPropPenWidth
        '
        resources.ApplyResources(Me.lblPropPenWidth, "lblPropPenWidth")
        Me.lblPropPenWidth.Name = "lblPropPenWidth"
        '
        'lblPropPenDecorationAlignment
        '
        resources.ApplyResources(Me.lblPropPenDecorationAlignment, "lblPropPenDecorationAlignment")
        Me.lblPropPenDecorationAlignment.Name = "lblPropPenDecorationAlignment"
        '
        'lblPropPenStyle
        '
        resources.ApplyResources(Me.lblPropPenStyle, "lblPropPenStyle")
        Me.lblPropPenStyle.Name = "lblPropPenStyle"
        '
        'lblPropPenDecoration
        '
        resources.ApplyResources(Me.lblPropPenDecoration, "lblPropPenDecoration")
        Me.lblPropPenDecoration.Name = "lblPropPenDecoration"
        '
        'lblPropPenPattern
        '
        resources.ApplyResources(Me.lblPropPenPattern, "lblPropPenPattern")
        Me.lblPropPenPattern.Name = "lblPropPenPattern"
        '
        'cboPropPenPattern
        '
        resources.ApplyResources(Me.cboPropPenPattern, "cboPropPenPattern")
        Me.cboPropPenPattern.EditValue = "_9"
        Me.cboPropPenPattern.Name = "cboPropPenPattern"
        '
        'txtPropPenColor
        '
        Me.txtPropPenColor.DefaultColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.txtPropPenColor, "txtPropPenColor")
        Me.txtPropPenColor.Name = "txtPropPenColor"
        Me.txtPropPenColor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropPenColor.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropPenColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtPropPenColor.Properties.ShowSystemColors = False
        Me.txtPropPenColor.Properties.ShowWebColors = False
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
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnPropSaveToFile, Me.btnPropSaveToSurvey, Me.btnPropExport, Me.btnPropImport})
        Me.BarManager.MaxItemId = 27
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
        'cmdPropPenBrowseClipart
        '
        Me.cmdPropPenBrowseClipart.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropPenBrowseClipart.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.open
        Me.cmdPropPenBrowseClipart.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdPropPenBrowseClipart, "cmdPropPenBrowseClipart")
        Me.cmdPropPenBrowseClipart.Name = "cmdPropPenBrowseClipart"
        '
        'picPropPenClipartImage
        '
        resources.ApplyResources(Me.picPropPenClipartImage, "picPropPenClipartImage")
        Me.picPropPenClipartImage.Name = "picPropPenClipartImage"
        Me.picPropPenClipartImage.Properties.NullText = resources.GetString("picPropPenClipartImage.Properties.NullText")
        Me.picPropPenClipartImage.Properties.ReadOnly = True
        Me.picPropPenClipartImage.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.[False]
        Me.picPropPenClipartImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        '
        'lblPropPenClipartImage
        '
        resources.ApplyResources(Me.lblPropPenClipartImage, "lblPropPenClipartImage")
        Me.lblPropPenClipartImage.Name = "lblPropPenClipartImage"
        '
        'pnlPenClipartSettings
        '
        Me.pnlPenClipartSettings.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlPenClipartSettings.Controls.Add(Me.cboPropPenDecorationPosition)
        Me.pnlPenClipartSettings.Controls.Add(Me.lblPenPropDecorationPosition)
        Me.pnlPenClipartSettings.Controls.Add(Me.cboPropPenClipartPenMode)
        Me.pnlPenClipartSettings.Controls.Add(Me.lblPropPenClipartPen)
        Me.pnlPenClipartSettings.Controls.Add(Me.txtPropPenDecorationScale)
        Me.pnlPenClipartSettings.Controls.Add(Me.txtPropPenDecorationSpacePercentage)
        Me.pnlPenClipartSettings.Controls.Add(Me.cboPropPenDecorationAlignment)
        Me.pnlPenClipartSettings.Controls.Add(Me.lblPropPenDecorationAlignment)
        Me.pnlPenClipartSettings.Controls.Add(Me.lblPropPenDecorationSpacePercentage)
        Me.pnlPenClipartSettings.Controls.Add(Me.lblPropPenDecorationScale)
        resources.ApplyResources(Me.pnlPenClipartSettings, "pnlPenClipartSettings")
        Me.pnlPenClipartSettings.Name = "pnlPenClipartSettings"
        '
        'cboPropPenDecorationPosition
        '
        resources.ApplyResources(Me.cboPropPenDecorationPosition, "cboPropPenDecorationPosition")
        Me.cboPropPenDecorationPosition.MenuManager = Me.BarManager
        Me.cboPropPenDecorationPosition.Name = "cboPropPenDecorationPosition"
        Me.cboPropPenDecorationPosition.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPropPenDecorationPosition.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPropPenDecorationPosition.Properties.Items.AddRange(New Object() {resources.GetString("cboPropPenDecorationPosition.Properties.Items"), resources.GetString("cboPropPenDecorationPosition.Properties.Items1")})
        Me.cboPropPenDecorationPosition.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblPenPropDecorationPosition
        '
        resources.ApplyResources(Me.lblPenPropDecorationPosition, "lblPenPropDecorationPosition")
        Me.lblPenPropDecorationPosition.Name = "lblPenPropDecorationPosition"
        '
        'cboPropPenClipartPenMode
        '
        resources.ApplyResources(Me.cboPropPenClipartPenMode, "cboPropPenClipartPenMode")
        Me.cboPropPenClipartPenMode.MenuManager = Me.BarManager
        Me.cboPropPenClipartPenMode.Name = "cboPropPenClipartPenMode"
        Me.cboPropPenClipartPenMode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPropPenClipartPenMode.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPropPenClipartPenMode.Properties.Items.AddRange(New Object() {resources.GetString("cboPropPenClipartPenMode.Properties.Items"), resources.GetString("cboPropPenClipartPenMode.Properties.Items1")})
        Me.cboPropPenClipartPenMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblPropPenClipartPen
        '
        resources.ApplyResources(Me.lblPropPenClipartPen, "lblPropPenClipartPen")
        Me.lblPropPenClipartPen.Name = "lblPropPenClipartPen"
        '
        'txtPropPenDecorationScale
        '
        resources.ApplyResources(Me.txtPropPenDecorationScale, "txtPropPenDecorationScale")
        Me.txtPropPenDecorationScale.MenuManager = Me.BarManager
        Me.txtPropPenDecorationScale.Name = "txtPropPenDecorationScale"
        Me.txtPropPenDecorationScale.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropPenDecorationScale.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropPenDecorationScale.Properties.DisplayFormat.FormatString = "N1"
        Me.txtPropPenDecorationScale.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropPenDecorationScale.Properties.EditFormat.FormatString = "N1"
        Me.txtPropPenDecorationScale.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropPenDecorationScale.Properties.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtPropPenDecorationScale.Properties.MaskSettings.Set("mask", "N1")
        Me.txtPropPenDecorationScale.Properties.MaxValue = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtPropPenDecorationScale.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtPropPenDecorationSpacePercentage
        '
        resources.ApplyResources(Me.txtPropPenDecorationSpacePercentage, "txtPropPenDecorationSpacePercentage")
        Me.txtPropPenDecorationSpacePercentage.MenuManager = Me.BarManager
        Me.txtPropPenDecorationSpacePercentage.Name = "txtPropPenDecorationSpacePercentage"
        Me.txtPropPenDecorationSpacePercentage.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropPenDecorationSpacePercentage.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropPenDecorationSpacePercentage.Properties.DisplayFormat.FormatString = "N0"
        Me.txtPropPenDecorationSpacePercentage.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropPenDecorationSpacePercentage.Properties.EditFormat.FormatString = "N0"
        Me.txtPropPenDecorationSpacePercentage.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropPenDecorationSpacePercentage.Properties.IsFloatValue = False
        Me.txtPropPenDecorationSpacePercentage.Properties.MaskSettings.Set("mask", "N0")
        Me.txtPropPenDecorationSpacePercentage.Properties.MaxValue = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtPropPenDecorationSpacePercentage.Properties.MinValue = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'cboPropPenDecorationAlignment
        '
        resources.ApplyResources(Me.cboPropPenDecorationAlignment, "cboPropPenDecorationAlignment")
        Me.cboPropPenDecorationAlignment.MenuManager = Me.BarManager
        Me.cboPropPenDecorationAlignment.Name = "cboPropPenDecorationAlignment"
        Me.cboPropPenDecorationAlignment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPropPenDecorationAlignment.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPropPenDecorationAlignment.Properties.Items.AddRange(New Object() {resources.GetString("cboPropPenDecorationAlignment.Properties.Items"), resources.GetString("cboPropPenDecorationAlignment.Properties.Items1"), resources.GetString("cboPropPenDecorationAlignment.Properties.Items2")})
        Me.cboPropPenDecorationAlignment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'cboPropPenClipartPenStyle
        '
        resources.ApplyResources(Me.cboPropPenClipartPenStyle, "cboPropPenClipartPenStyle")
        Me.cboPropPenClipartPenStyle.MenuManager = Me.BarManager
        Me.cboPropPenClipartPenStyle.Name = "cboPropPenClipartPenStyle"
        Me.cboPropPenClipartPenStyle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPropPenClipartPenStyle.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPropPenClipartPenStyle.Properties.Items.AddRange(New Object() {resources.GetString("cboPropPenClipartPenStyle.Properties.Items"), resources.GetString("cboPropPenClipartPenStyle.Properties.Items1"), resources.GetString("cboPropPenClipartPenStyle.Properties.Items2"), resources.GetString("cboPropPenClipartPenStyle.Properties.Items3"), resources.GetString("cboPropPenClipartPenStyle.Properties.Items4"), resources.GetString("cboPropPenClipartPenStyle.Properties.Items5"), resources.GetString("cboPropPenClipartPenStyle.Properties.Items6"), resources.GetString("cboPropPenClipartPenStyle.Properties.Items7"), resources.GetString("cboPropPenClipartPenStyle.Properties.Items8")})
        Me.cboPropPenClipartPenStyle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblPropPenClipartPenStyle
        '
        resources.ApplyResources(Me.lblPropPenClipartPenStyle, "lblPropPenClipartPenStyle")
        Me.lblPropPenClipartPenStyle.Name = "lblPropPenClipartPenStyle"
        '
        'txtPropPenClipartPenWidth
        '
        resources.ApplyResources(Me.txtPropPenClipartPenWidth, "txtPropPenClipartPenWidth")
        Me.txtPropPenClipartPenWidth.MenuManager = Me.BarManager
        Me.txtPropPenClipartPenWidth.Name = "txtPropPenClipartPenWidth"
        Me.txtPropPenClipartPenWidth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropPenClipartPenWidth.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropPenClipartPenWidth.Properties.DisplayFormat.FormatString = "N1"
        Me.txtPropPenClipartPenWidth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropPenClipartPenWidth.Properties.EditFormat.FormatString = "N1"
        Me.txtPropPenClipartPenWidth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropPenClipartPenWidth.Properties.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtPropPenClipartPenWidth.Properties.MaxValue = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'lblPropPenClipartPenColor
        '
        resources.ApplyResources(Me.lblPropPenClipartPenColor, "lblPropPenClipartPenColor")
        Me.lblPropPenClipartPenColor.Name = "lblPropPenClipartPenColor"
        '
        'lblPropPenClipartPenWidth
        '
        resources.ApplyResources(Me.lblPropPenClipartPenWidth, "lblPropPenClipartPenWidth")
        Me.lblPropPenClipartPenWidth.Name = "lblPropPenClipartPenWidth"
        '
        'txtPropPenClipartPenColor
        '
        Me.txtPropPenClipartPenColor.DefaultColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.txtPropPenClipartPenColor, "txtPropPenClipartPenColor")
        Me.txtPropPenClipartPenColor.Name = "txtPropPenClipartPenColor"
        Me.txtPropPenClipartPenColor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropPenClipartPenColor.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropPenClipartPenColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtPropPenClipartPenColor.Properties.ShowSystemColors = False
        Me.txtPropPenClipartPenColor.Properties.ShowWebColors = False
        '
        'pnlPenClipart
        '
        Me.pnlPenClipart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlPenClipart.Controls.Add(Me.cmdPropPenCleanClipart)
        Me.pnlPenClipart.Controls.Add(Me.cmdPropPenBrowseClipart)
        Me.pnlPenClipart.Controls.Add(Me.picPropPenClipartImage)
        Me.pnlPenClipart.Controls.Add(Me.lblPropPenClipartImage)
        resources.ApplyResources(Me.pnlPenClipart, "pnlPenClipart")
        Me.pnlPenClipart.Name = "pnlPenClipart"
        '
        'cmdPropPenCleanClipart
        '
        Me.cmdPropPenCleanClipart.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropPenCleanClipart.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.clearall
        Me.cmdPropPenCleanClipart.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdPropPenCleanClipart, "cmdPropPenCleanClipart")
        Me.cmdPropPenCleanClipart.Name = "cmdPropPenCleanClipart"
        '
        'cboPropPenDecoration
        '
        resources.ApplyResources(Me.cboPropPenDecoration, "cboPropPenDecoration")
        Me.cboPropPenDecoration.MenuManager = Me.BarManager
        Me.cboPropPenDecoration.Name = "cboPropPenDecoration"
        Me.cboPropPenDecoration.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPropPenDecoration.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPropPenDecoration.Properties.Items.AddRange(New Object() {resources.GetString("cboPropPenDecoration.Properties.Items"), resources.GetString("cboPropPenDecoration.Properties.Items1"), resources.GetString("cboPropPenDecoration.Properties.Items2"), resources.GetString("cboPropPenDecoration.Properties.Items3"), resources.GetString("cboPropPenDecoration.Properties.Items4"), resources.GetString("cboPropPenDecoration.Properties.Items5"), resources.GetString("cboPropPenDecoration.Properties.Items6"), resources.GetString("cboPropPenDecoration.Properties.Items7"), resources.GetString("cboPropPenDecoration.Properties.Items8"), resources.GetString("cboPropPenDecoration.Properties.Items9"), resources.GetString("cboPropPenDecoration.Properties.Items10")})
        Me.cboPropPenDecoration.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'cboPropPenStyle
        '
        resources.ApplyResources(Me.cboPropPenStyle, "cboPropPenStyle")
        Me.cboPropPenStyle.MenuManager = Me.BarManager
        Me.cboPropPenStyle.Name = "cboPropPenStyle"
        Me.cboPropPenStyle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPropPenStyle.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPropPenStyle.Properties.Items.AddRange(New Object() {resources.GetString("cboPropPenStyle.Properties.Items"), resources.GetString("cboPropPenStyle.Properties.Items1"), resources.GetString("cboPropPenStyle.Properties.Items2"), resources.GetString("cboPropPenStyle.Properties.Items3"), resources.GetString("cboPropPenStyle.Properties.Items4"), resources.GetString("cboPropPenStyle.Properties.Items5"), resources.GetString("cboPropPenStyle.Properties.Items6"), resources.GetString("cboPropPenStyle.Properties.Items7"), resources.GetString("cboPropPenStyle.Properties.Items8")})
        Me.cboPropPenStyle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'txtPropPenWidth
        '
        resources.ApplyResources(Me.txtPropPenWidth, "txtPropPenWidth")
        Me.txtPropPenWidth.MenuManager = Me.BarManager
        Me.txtPropPenWidth.Name = "txtPropPenWidth"
        Me.txtPropPenWidth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropPenWidth.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropPenWidth.Properties.DisplayFormat.FormatString = "N1"
        Me.txtPropPenWidth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropPenWidth.Properties.EditFormat.FormatString = "N1"
        Me.txtPropPenWidth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropPenWidth.Properties.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtPropPenWidth.Properties.MaxValue = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'pnlPenStyle
        '
        Me.pnlPenStyle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlPenStyle.Controls.Add(Me.cboPropPenStyle)
        Me.pnlPenStyle.Controls.Add(Me.lblPropPenStyle)
        Me.pnlPenStyle.Controls.Add(Me.txtPropPenWidth)
        Me.pnlPenStyle.Controls.Add(Me.txtPropPenColor)
        Me.pnlPenStyle.Controls.Add(Me.lblPropPenWidth)
        Me.pnlPenStyle.Controls.Add(Me.cboPropPenDecoration)
        Me.pnlPenStyle.Controls.Add(Me.lblPropPenColor)
        Me.pnlPenStyle.Controls.Add(Me.lblPropPenDecoration)
        resources.ApplyResources(Me.pnlPenStyle, "pnlPenStyle")
        Me.pnlPenStyle.Name = "pnlPenStyle"
        '
        'pnlPenClipartSettingsPen
        '
        Me.pnlPenClipartSettingsPen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlPenClipartSettingsPen.Controls.Add(Me.cboPropPenClipartPenStyle)
        Me.pnlPenClipartSettingsPen.Controls.Add(Me.lblPropPenClipartPenStyle)
        Me.pnlPenClipartSettingsPen.Controls.Add(Me.txtPropPenClipartPenWidth)
        Me.pnlPenClipartSettingsPen.Controls.Add(Me.lblPropPenClipartPenColor)
        Me.pnlPenClipartSettingsPen.Controls.Add(Me.lblPropPenClipartPenWidth)
        Me.pnlPenClipartSettingsPen.Controls.Add(Me.txtPropPenClipartPenColor)
        resources.ApplyResources(Me.pnlPenClipartSettingsPen, "pnlPenClipartSettingsPen")
        Me.pnlPenClipartSettingsPen.Name = "pnlPenClipartSettingsPen"
        '
        'cItemPenStylePropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.pnlPenStyle)
        Me.Controls.Add(Me.pnlPenClipart)
        Me.Controls.Add(Me.lblPropPenPattern)
        Me.Controls.Add(Me.cboPropPenPattern)
        Me.Controls.Add(Me.cmdPropSave)
        Me.Controls.Add(Me.pnlPenClipartSettings)
        Me.Controls.Add(Me.pnlPenClipartSettingsPen)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "cItemPenStylePropertyControl"
        CType(Me.txtPropPenColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuSaveAs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPropPenClipartImage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlPenClipartSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPenClipartSettings.ResumeLayout(False)
        Me.pnlPenClipartSettings.PerformLayout()
        CType(Me.cboPropPenDecorationPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPropPenClipartPenMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropPenDecorationScale.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropPenDecorationSpacePercentage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPropPenDecorationAlignment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPropPenClipartPenStyle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropPenClipartPenWidth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropPenClipartPenColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlPenClipart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPenClipart.ResumeLayout(False)
        Me.pnlPenClipart.PerformLayout()
        CType(Me.cboPropPenDecoration.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPropPenStyle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropPenWidth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlPenStyle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPenStyle.ResumeLayout(False)
        Me.pnlPenStyle.PerformLayout()
        CType(Me.pnlPenClipartSettingsPen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPenClipartSettingsPen.ResumeLayout(False)
        Me.pnlPenClipartSettingsPen.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPropPenColor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropPenColor As cColorSelector
    Friend WithEvents lblPropPenDecorationScale As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropPenDecorationSpacePercentage As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropPenWidth As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropPenDecorationAlignment As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropPenStyle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropPenDecoration As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropPenPattern As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropPenPattern As cPenStyleDropDown
    Friend WithEvents cmdPropSave As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents mnuSaveAs As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnPropSaveToFile As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPropSaveToSurvey As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnPropExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPropImport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdPropPenBrowseClipart As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents picPropPenClipartImage As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents lblPropPenClipartImage As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnlPenClipartSettings As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlPenClipart As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cboPropPenDecoration As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cmdPropPenCleanClipart As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboPropPenDecorationAlignment As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboPropPenStyle As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtPropPenWidth As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtPropPenDecorationScale As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtPropPenDecorationSpacePercentage As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents cboPropPenClipartPenStyle As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblPropPenClipartPenStyle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropPenClipartPenMode As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblPropPenClipartPen As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropPenClipartPenWidth As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblPropPenClipartPenColor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropPenClipartPenWidth As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropPenClipartPenColor As cColorSelector
    Friend WithEvents cboPropPenDecorationPosition As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblPenPropDecorationPosition As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnlPenStyle As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlPenClipartSettingsPen As DevExpress.XtraEditors.PanelControl
End Class