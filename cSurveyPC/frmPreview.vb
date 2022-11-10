Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports System.Drawing.Printing
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq

Imports System.Xml
Imports cSurveyPC
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraBars
Imports DevExpress.XtraNavBar
Imports cSurveyPC.cSurvey.Helper.Editor
Imports System.ComponentModel

Friend Class frmPreview
    'Private WithEvents frmPC As frmParametersCompass
    'Private WithEvents frmPIB As frmParametersInfoBox
    'Private WithEvents frmPS As frmParametersScale
    'Private WithEvents frmSD As frmParametersSegments
    'Private WithEvents frmPD As frmParametersDesign
    'Private WithEvents frmT As frmParametersTranslations
    'Private WithEvents frmZ As frmParametersZOrder

    Private WithEvents oSurvey As cSurveyPC.cSurvey.cSurvey
    Private oSelection As Helper.Editor.cIEditDesignSelection
    Private WithEvents oDoc As Printing.PrintDocument

    Private bEventDisabled As Boolean

    Private bManualRefresh As Boolean = True
    Private bFirstRendering As Boolean = True
    Private bInvalidated As Boolean = True

    Private oMousePointer As cMousePointer

    Private iDesignQuality As frmMain2.DesignQualityLevelEnum = frmMain2.DesignQualityLevelEnum.MediumQuality

    Public Enum ViewModeEnum
        Plan = 0
        Profile = 1
    End Enum

    Public Enum PreviewModeEnum
        Preview = 0
        Export = 1
        Viewer = 2
    End Enum

    Private iMode As PreviewModeEnum

    Private sViewZoom As Single
    Private sLastFilename As String = ""

    Private oStartPaintDrawPosition As PointF

    Private oPaintTranslation As PointF
    Private sPaintZoom As Single

    Private oCurrentProfile As cSurvey.cIProfile
    Private WithEvents oCurrentOptions As cSurvey.Design.cOptionsCenterline

    Private bDisableImageSizeEvent As Boolean

    Public Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Mode As PreviewModeEnum, ByVal View As ViewModeEnum)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call cEditDesignEnvironment.OnPropertyChangedAppend(AddressOf oEditDesignEnvironment_OnChanged)
        Call pDesignEnvironmentSet()

        oMousePointer = New cMousePointer
        NavBarControl1.View = New cNavigationPanel.CustomNavPaneViewInfoRegistrator()

        bEventDisabled = True

        oSurvey = Survey
        oSelection = cSurveyPC.cSurvey.Helper.Editor.cEmptyEditDesignSelection.Empty
        iMode = Mode

        bManualRefresh = (oSurvey.SharedSettings.GetValue("preview.manualrefresh", "0") = "1") Or (My.Computer.Keyboard.AltKeyDown Or My.Computer.Keyboard.CtrlKeyDown)
        btnManualRefresh.Checked = bManualRefresh

        btnSidePanel.Checked = oSurvey.SharedSettings.GetValue("preview.sidepanel.visible", 1) = "1"
        pnlOptions.Visible = btnSidePanel.Checked

        iDesignQuality = oSurvey.SharedSettings.GetValue("preview.designquality", 1)
        If iDesignQuality = frmMain2.DesignQualityLevelEnum.Base Then
            btnDesignGraphics0.Checked = True
        ElseIf iDesignQuality = frmMain2.DesignQualityLevelEnum.MediumQuality Then
            btnDesignGraphics1.Checked = True
        Else
            btnDesignGraphics2.Checked = True
        End If
        sViewZoom = 1

        Call pFillPrintersList()

        pnlPrintOptions.Location = New Point(1, 1)
        pnlExportOptionsOther.Location = New Point(1, 1)
        Select Case iMode
            Case PreviewModeEnum.Viewer
                Me.IconOptions.SvgImage = My.Resources.viewer

                btnProfilesAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                btnProfilesDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                btnProfileExportToFile.Enabled = True
                btnProfileImportFromFile.Enabled = True

                btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                btnExport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

                pPreview.Visible = False
                pnlExport.Visible = False
                pnlMap.Visible = True

                btnProperties.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

                pnlMap.Dock = DockStyle.Fill
                picMap.Dock = DockStyle.Fill
                Text = oSurvey.Name & " - cSurvey - Viewer:"

                '-----------
                Dim sObjectsPath As String = modMain.GetApplicationPath & "\objects"
                oOpenHandCursor = New Cursor(sObjectsPath & "\cursors\openhand.cur")
                oClosedHandCursor = New Cursor(sObjectsPath & "\cursors\closedhand.cur")

                bDrawRulers = True
                bDrawMetricGrid = False

                pnlStatusDesignZoom.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

                sPaintZoom = 500
                trkZoom.Value = sPaintZoom

                Call pnlMap.SuspendLayout()
                Dim oPanelSize As Size = pnlMap.ClientSize
                oVSB = New DevExpress.XtraEditors.VScrollBar
                oHSB = New DevExpress.XtraEditors.HScrollBar
                oVSB.SmallChange = 1
                oVSB.LargeChange = 25
                oVSB.Anchor = AnchorStyles.Right Or AnchorStyles.Top Or AnchorStyles.Bottom
                oVSB.Location = New Point(oPanelSize.Width - oVSB.Width, 0)
                oVSB.Size = New Size(oVSB.Width, oPanelSize.Height - oHSB.Height)
                pnlMap.Controls.Add(oVSB)
                oVSB.SendToBack()
                oHSB.SmallChange = 1
                oHSB.LargeChange = 25
                oHSB.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
                oHSB.Location = New Point(0, oPanelSize.Height - oHSB.Height)
                oHSB.Size = New Size(oPanelSize.Width - oVSB.Width, oHSB.Height)
                pnlMap.Controls.Add(oHSB)
                oHSB.SendToBack()
                picMap.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Bottom
                picMap.Location = New Point(0, 0)
                picMap.Size = New Size(oPanelSize.Width - oVSB.Width, oPanelSize.Height - oHSB.Height)
                Call pnlMap.ResumeLayout()

                trkZoom.BringToFront()
                '-----------

                Text = oSurvey.Name & " - cSurvey - " & GetLocalizedString("preview.viewer.title") & ":"

                'dati gps aggiuntivi
                lblGPSData.Visible = False
                cboGPSData.Visible = False
                chkExportGPS.Visible = False

                For Each oProfile As cViewerProfile In oSurvey.ViewerProfiles
                    Dim oLink As DevExpress.XtraNavBar.NavBarItemLink = grpMain.AddItem
                    oLink.Item.Caption = oProfile.Name
                    oLink.Item.ImageOptions.SvgImage = My.Resources.viewer
                    oLink.Item.Tag = oProfile
                    If oProfile.IsSystem Then
                        oLink.Item.Caption = "<b>" & oLink.Item.Caption & "</b>"
                    Else
                        oLink.Item.Caption = oProfile.Name
                    End If
                Next
                For Each oProfile As cPreviewProfile In oSurvey.PreviewProfiles
                    Dim oLink As DevExpress.XtraNavBar.NavBarItemLink = grpMain.AddItem
                    oLink.Item.Caption = oProfile.Name
                    oLink.Item.ImageOptions.SvgImage = My.Resources.documentprint
                    oLink.Item.Tag = oProfile
                    If oProfile.IsSystem Then
                        oLink.Item.Caption = "<b>" & oLink.Item.Caption & "</b>"
                    Else
                        oLink.Item.Caption = oProfile.Name
                    End If
                Next
                For Each oProfile As cExportProfile In oSurvey.ExportProfiles
                    Dim oLink As DevExpress.XtraNavBar.NavBarItemLink = grpMain.AddItem
                    oLink.Item.Caption = oProfile.Name
                    oLink.Item.ImageOptions.SvgImage = My.Resources.documentexport
                    oLink.Item.Tag = oProfile
                    If oProfile.IsSystem Then
                        oLink.Item.Caption = "<b>" & oLink.Item.Caption & "</b>"
                    Else
                        oLink.Item.Caption = oProfile.Name
                    End If
                Next

                NavBarControl1.SelectedLink = NavBarControl1.Groups(0).ItemLinks(View)

            Case PreviewModeEnum.Export
                Me.IconOptions.SvgImage = My.Resources.exportfile

                btnProfilesAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                btnProfilesDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                btnProfileExportToFile.Enabled = True
                btnProfileImportFromFile.Enabled = True

                btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                btnExport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never = DevExpress.XtraBars.BarItemVisibility.Always

                pPreview.Visible = False
                pnlExport.Visible = True
                pnlMap.Visible = False

                btnProperties.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

                pnlStatusDesignZoom.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

                pnlExport.Dock = DockStyle.Fill
                Text = oSurvey.Name & " - cSurvey - " & GetLocalizedString("preview.export.title") & ":"

                'dati gps aggiuntivi
                lblGPSData.Visible = True
                cboGPSData.Visible = True
                chkExportGPS.Visible = True

                For Each oProfile As cExportProfile In oSurvey.ExportProfiles
                    Dim oLink As DevExpress.XtraNavBar.NavBarItemLink = grpMain.AddItem
                    oLink.Item.Caption = oProfile.Name
                    oLink.Item.ImageOptions.SvgImage = My.Resources.documentexport
                    oLink.Item.Tag = oProfile
                    If oProfile.IsSystem Then
                        oLink.Item.Caption = "<b>" & oLink.Item.Caption & "</b>"
                    Else
                        oLink.Item.Caption = oProfile.Name
                    End If
                Next

                Dim oCustomItem As ImageComboBoxItem = New ImageComboBoxItem({Nothing, Nothing}, 0)
                oCustomItem.Description = "Custom" 'TODO:localize
                cboSize.Properties.Items.Add(oCustomItem)

                Dim oXml As XmlDocument = New XmlDocument
                Call oXml.Load(IO.Path.Combine(modMain.GetApplicationPath, "papersizes.xml"))
                For Each oXMLSize As XmlElement In oXml.DocumentElement.ChildNodes
                    Dim sName As String = oXMLSize.GetAttribute("name")
                    Dim oItemSize As SizeF = New SizeF(modNumbers.StringToDecimal(oXMLSize.GetAttribute("w")), modNumbers.StringToDecimal(oXMLSize.GetAttribute("h")))
                    Dim oItem As ImageComboBoxItem = New ImageComboBoxItem({oItemSize, oXMLSize.GetAttribute("u")}, 0)
                    oItem.Description = sName
                    cboSize.Properties.Items.Add(oItem)
                Next

                NavBarControl1.SelectedLink = NavBarControl1.Groups(0).ItemLinks(View)
            Case PreviewModeEnum.Preview
                Me.IconOptions.SvgImage = My.Resources.print

                btnProfilesAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                btnProfilesDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                btnProfileExportToFile.Enabled = True
                btnProfileImportFromFile.Enabled = True

                btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                btnExport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

                pPreview.Visible = True
                pnlExport.Visible = False
                pnlMap.Visible = False

                btnProperties.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

                pnlStatusDesignZoom.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

                pPreview.Dock = DockStyle.Fill
                Text = oSurvey.Name & " - cSurvey - " & GetLocalizedString("preview.preview.title") & ":"

                'dati gps aggiuntivi
                lblGPSData.Visible = False
                cboGPSData.Visible = False
                chkExportGPS.Visible = False

                'genero l'elenco delle stampanti
                oDoc = New Printing.PrintDocument
                oDoc.DocumentName = oSurvey.Name
                oDoc.PrintController = New cPrintController.PrintControllerNoStatusDialog(oDoc.PrintController)
                pPreview.Document = oDoc

                For Each oProfile As cPreviewProfile In oSurvey.PreviewProfiles
                    Dim oLink As DevExpress.XtraNavBar.NavBarItemLink = grpMain.AddItem
                    oLink.Item.Caption = oProfile.Name
                    oLink.Item.ImageOptions.SvgImage = My.Resources.documentprint
                    oLink.Item.Tag = oProfile
                    If oProfile.IsSystem Then
                        oLink.Item.Caption = "<b>" & oLink.Item.Caption & "</b>"
                    Else
                        oLink.Item.Caption = oProfile.Name
                    End If
                Next

                NavBarControl1.SelectedLink = NavBarControl1.Groups(0).ItemLinks(View)

        End Select

        bEventDisabled = False

        'call pRefresh(False, True)
        Call pProfileSelect(NavBarControl1.SelectedLink.Item.Tag, False, True)
        If Not bManualRefresh Then pRefresh(True, False)
    End Sub

    Private Sub pDesignEnvironmentSet()
        Dim oBackcolor As Color = cEditDesignEnvironment.GetSetting("design.lowerlayersdesignbackcolor", Color.White)
        picMap.BackColor = oBackcolor
        pPreview.BackColor = oBackcolor
    End Sub

    Private Sub oEditDesignEnvironment_OnChanged(Sender As Object, e As PropertyChangeEventArgs)
        Call pDesignEnvironmentSet()
    End Sub

    Private Sub pFillPrintersList()
        Dim sDefaultPrinterName As String = "" & (New PrinterSettings).PrinterName
        For Each sPrinter As String In PrinterSettings.InstalledPrinters
            Call cboPrinter.Properties.Items.Add(sPrinter)
            If sPrinter = sDefaultPrinterName Then
                cboPrinter.SelectedIndex = cboPrinter.Properties.Items.Count - 1
            End If
        Next
    End Sub

    Private Sub pPageFormatRefresh(PrinterSettings As PrinterSettings)
        Dim sCurrentPageFormat As String = PrinterSettings.DefaultPageSettings.PaperSize.PaperName

        Call cboPageFormat.Properties.Items.Clear()
        'Call cboPageFormat.Items.Clear()
        Dim oPageSizes As List(Of String) = New List(Of String)
        For Each oPaperSize As PaperSize In PrinterSettings.PaperSizes
            Call oPageSizes.Add(oPaperSize.PaperName)
            'Call cboPageFormat.Items.Add(oPaperSize.PaperName)

            Dim sName As String = oPaperSize.PaperName
            Dim oItem As ImageComboBoxItem = New ImageComboBoxItem(sName, sName, 0)
            cboPageFormat.Properties.Items.Add(oItem)
        Next
        If sCurrentPageFormat <> "" AndAlso oPageSizes.Contains(sCurrentPageFormat) Then
            'cboPageFormat.Text = sCurrentPageFormat
            cboPageFormat.EditValue = sCurrentPageFormat
        Else
            Dim oPrinterSettings As PrinterSettings = New PrinterSettings
            oPrinterSettings.PrinterName = PrinterSettings.PrinterName
            'cboPageFormat.Text = oPrinterSettings.DefaultPageSettings.PaperSize.PaperName
            cboPageFormat.EditValue = oPrinterSettings.DefaultPageSettings.PaperSize.PaperName
        End If
    End Sub

    Private Function pFromImageUnit(Unit As String) As Integer
        Select Case Unit
            Case "cm"
                Return 1
            Case "mm"
                Return 2
            Case "in"
                Return 3
            Case Else
                Return 0
        End Select
    End Function

    Private Function pToSizeUnit(Index As Integer) As SizeUnit
        Select Case Index
            Case 1
                Return SizeUnit.cm
            Case 2
                Return SizeUnit.mm
            Case 3
                Return SizeUnit.inch
            Case Else
                Return SizeUnit.pixel
        End Select
    End Function

    Private Function pToImageUnit(Index As Integer) As String
        Select Case Index
            Case 1
                Return "cm"
            Case 2
                Return "mm"
            Case 3
                Return "in"
            Case Else
                Return "px"
        End Select
    End Function

    Public Sub pOptionsSave()
        If InvokeRequired Then
            Call Invoke(New pOptionSaveDelegate(AddressOf pOptionsSave))
        Else
            If TypeOf oCurrentOptions Is cSurvey.Design.cOptionsPreview Then
                Dim oOptions As cSurvey.Design.cOptionsPreview = oCurrentOptions
                With oOptions
                    .PrinterName = oCurrentPrinterSettings.PrinterName

                    .PageFormat = oCurrentPrinterSettings.DefaultPageSettings.PaperSize.PaperName
                    .PageLandscape = oCurrentPrinterSettings.DefaultPageSettings.Landscape
                    .PageMargins = oCurrentPrinterSettings.DefaultPageSettings.Margins

                    If cboScale.SelectedIndex = cboScale.Properties.Items.Count - 1 Then
                        .ScaleMode = cSurvey.Design.cIOptionsPreview.ScaleModeEnum.sManual
                    Else
                        .ScaleMode = cboScale.SelectedIndex
                    End If
                    .Scale = txtScaleManual.Value
                    .DrawTranslation = chkTranslations.Checked

                    .UseDrawingZOrder = chkUseDrawingZOrder.Checked

                    .DrawBox = chkPrintBox.Checked
                    .BoxPosition = cboBoxPosition.SelectedIndex
                    .DrawCompass = chkPrintCompass.Checked
                    .CompassPosition = cboCompassPosition.SelectedIndex
                    .DrawScale = chkPrintScale.Checked
                    .ScalePosition = cboScalePosition.SelectedIndex

                    .DrawPlot = chkPrintCentreline.Checked
                    .DrawSegments = chkPrintShots.Checked
                    .DrawPoints = chkPrintStations.Checked
                    '.DrawPointNames = chkPrintStations.Checked
                    .ShowPointText = chkPrintTrigpointText.Checked
                    .DrawLRUD = chkPrintLRUD.Checked
                    .DrawSplay = chkPrintSplay.Checked

                    .DesignStyle = cboPrintDesignStyle.SelectedIndex
                    .CenterlineColorGray = chkPrintCentrelineColorGray.Checked

                    .DrawImages = chkPrintImages.Checked
                    .DrawSketches = chkPrintSketches.Checked
                    .DrawDesign = chkPrintDesign.Checked

                    .DrawSpecialPoints = chkPrintDesignSpecialPoint.Checked

                    .ShowAdvancedBrushes = chkPrintDesignAdvancedBrushes.Checked

                    .CurrentCaveVisibilityProfile = txtCurrentProfile.Text

                    .CombineColorMode = cboPrintCombineColorMode.SelectedIndex
                    .CombineColorGray = chkPrintCombineColorGray.Checked

                    .CenterlineColorMode = cboPrintCenterlineColorMode.SelectedIndex
                    .CenterlineColorGray = chkPrintCentrelineColorGray.Checked

                    Call .DrawingObjects.Rebind()
                End With
            ElseIf TypeOf oCurrentOptions Is cSurvey.Design.cOptionsExport Then
                Dim oOptions As cSurvey.Design.cOptionsExport = oCurrentOptions
                With oOptions
                    .FileFormat = cboFileFormat.Text

                    .ImageWidth = txtImageWidth.Value
                    .ImageHeight = txtImageHeight.Value
                    .ImageUnit = pToImageUnit(cboImageUM.SelectedIndex)
                    .DPI = txtImageDPI.Value

                    .TransparentBackground = chkBackgroundTransparent.Checked

                    If cboScale.SelectedIndex = cboScale.Properties.Items.Count - 1 Then
                        .ScaleMode = cSurvey.Design.cIOptionsPreview.ScaleModeEnum.sManual
                    Else
                        .ScaleMode = cboScale.SelectedIndex
                    End If
                    .Scale = txtScaleManual.Value
                    .DrawTranslation = chkTranslations.Checked

                    .UseDrawingZOrder = chkUseDrawingZOrder.Checked

                    .DrawBox = chkPrintBox.Checked
                    .BoxPosition = cboBoxPosition.SelectedIndex
                    .DrawCompass = chkPrintCompass.Checked
                    .CompassPosition = cboCompassPosition.SelectedIndex
                    .DrawScale = chkPrintScale.Checked
                    .ScalePosition = cboScalePosition.SelectedIndex

                    .DrawPlot = chkPrintCentreline.Checked
                    .DrawSegments = chkPrintShots.Checked
                    .DrawPoints = chkPrintStations.Checked
                    '.DrawPointNames = chkPrintStations.Checked
                    .ShowPointText = chkPrintTrigpointText.Checked
                    .DrawLRUD = chkPrintLRUD.Checked
                    .DrawSplay = chkPrintSplay.Checked

                    .DesignStyle = cboPrintDesignStyle.SelectedIndex
                    .CenterlineColorGray = chkPrintCentrelineColorGray.Checked

                    .DrawImages = chkPrintImages.Checked
                    .DrawSketches = chkPrintSketches.Checked
                    .DrawDesign = chkPrintDesign.Checked

                    .DrawSpecialPoints = chkPrintDesignSpecialPoint.Checked

                    .ShowAdvancedBrushes = chkPrintDesignAdvancedBrushes.Checked

                    .CurrentCaveVisibilityProfile = txtCurrentProfile.Text

                    .CombineColorMode = cboPrintCombineColorMode.SelectedIndex
                    .CombineColorGray = chkPrintCombineColorGray.Checked

                    .CenterlineColorMode = cboPrintCenterlineColorMode.SelectedIndex
                    .CenterlineColorGray = chkPrintCentrelineColorGray.Checked

                    'solo per export...non per preview...
                    .GPS.ExportData = chkExportGPS.Checked
                    .GPS.DataFormat = cboGPSData.SelectedIndex

                    Call .DrawingObjects.Rebind()
                End With
                Dim oExportProfile As cExportProfile = oCurrentProfile
                oExportProfile.Filename = sLastFilename
            ElseIf TypeOf oCurrentOptions Is cSurvey.Design.cOptionsViewer Then
                Dim oOptions As cSurvey.Design.cOptionsViewer = oCurrentOptions
                With oOptions
                    .DrawTranslation = chkTranslations.Checked

                    .UseDrawingZOrder = chkUseDrawingZOrder.Checked

                    .DrawBox = chkPrintBox.Checked
                    .BoxPosition = cboBoxPosition.SelectedIndex
                    .DrawCompass = chkPrintCompass.Checked
                    .CompassPosition = cboCompassPosition.SelectedIndex
                    .DrawScale = chkPrintScale.Checked
                    .ScalePosition = cboScalePosition.SelectedIndex

                    .DrawPlot = chkPrintCentreline.Checked
                    .DrawSegments = chkPrintShots.Checked
                    .DrawPoints = chkPrintStations.Checked
                    '.DrawPointNames = chkPrintStations.Checked
                    .ShowPointText = chkPrintTrigpointText.Checked
                    .DrawLRUD = chkPrintLRUD.Checked
                    .DrawSplay = chkPrintSplay.Checked

                    .DesignStyle = cboPrintDesignStyle.SelectedIndex
                    .CenterlineColorGray = chkPrintCentrelineColorGray.Checked

                    .DrawImages = chkPrintImages.Checked
                    .DrawSketches = chkPrintSketches.Checked
                    .DrawDesign = chkPrintDesign.Checked

                    .DrawSpecialPoints = chkPrintDesignSpecialPoint.Checked

                    .ShowAdvancedBrushes = chkPrintDesignAdvancedBrushes.Checked

                    .CurrentCaveVisibilityProfile = txtCurrentProfile.Text

                    .CombineColorMode = cboPrintCombineColorMode.SelectedIndex
                    .CombineColorGray = chkPrintCombineColorGray.Checked

                    .CenterlineColorMode = cboPrintCenterlineColorMode.SelectedIndex
                    .CenterlineColorGray = chkPrintCentrelineColorGray.Checked

                    Call .DrawingObjects.Rebind()
                End With
            End If
        End If
    End Sub

    Private Delegate Sub pOptionSaveDelegate()

    Private Function pGetCurrentDesign() As cDesign
        If oCurrentProfile.Design = cIDesign.cDesignTypeEnum.Plan Then
            Return oSurvey.Plan
        Else
            Return oSurvey.Profile
        End If
    End Function

    Private Sub pImageSelectPage()
        bDisableImageSizeEvent = True
        Dim oSize As SizeF = New Size(txtImageWidth.Value, txtImageHeight.Value)
        Dim sUM As String = cboImageUM.Text.ToLower
        For Each oItem As ImageComboBoxItem In cboSize.Properties.Items
            If Not oItem.Value(0) Is Nothing Then
                Dim oItemSize As SizeF = oItem.Value(0)
                Dim sItemUM As String = oItem.Value(1)
                If sItemUM.ToLower = sUM Then
                    If oItemSize = oSize Then
                        cboSize.SelectedItem = oItem
                        chkImageOrientationPortrait.Checked = True
                    ElseIf oItemSize.Width = oSize.Height AndAlso oItemSize.Height = oSize.Width Then
                        cboSize.SelectedItem = oItem
                        chkImageOrientationLandscape.Checked = True
                    End If
                End If
            End If
        Next
        If cboSize.SelectedItem Is Nothing Then
            cboSize.SelectedIndex = 0
        End If
        Call pApplySVGSize(False)
        bDisableImageSizeEvent = False
    End Sub

    Private oCurrentPrinterSettings As Printing.PrinterSettings

    Private Function pOptionsRestore() As cSurvey.Design.cOptions
        Dim oReturnOptions As cSurvey.Design.cOptions
        bEventDisabled = True
        If TypeOf oCurrentOptions Is cOptionsPreview Then
            btnStatusDesignZoom100.Visibility = BarItemVisibility.Never
            btnStatusDesignZoom200.Visibility = BarItemVisibility.Never
            btnStatusDesignZoom250.Visibility = BarItemVisibility.Never
            btnStatusDesignZoom500.Visibility = BarItemVisibility.Never
            btnStatusDesignZoom1000.Visibility = BarItemVisibility.Never
            pnlStatusDesignZoom.Visibility = BarItemVisibility.Never

            pnlPrintOptions.Visible = True
            pnlScaleOptions.Visible = True
            pnlExportOptionsFormat.Visible = False
            pnlExportOptionsSize.Visible = False
            pnlExportOptionsPage.Visible = False
            pnlExportOptionsOther.Visible = False
            btnDesignDetails.Visible = True

            pnlProfile.Visible = True
            If oSurvey.Properties.ShowLegacyPrintAndExportObjects Then
                pnlInformationBox.Visible = True
                pnlCompass.Visible = True
                pnlScale.Visible = True
            Else
                pnlInformationBox.Visible = False
                pnlCompass.Visible = False
                pnlScale.Visible = False
            End If

            'cerco la stampante di default
            Dim oPrinters As List(Of String) = New List(Of String)
            Dim sDefaultPrinterName As String = "" & (New PrinterSettings).PrinterName
            Dim sPrinters As PrinterSettings.StringCollection = PrinterSettings.InstalledPrinters
            For Each sPrinter As String In sPrinters
                Call oPrinters.Add(sPrinter)
            Next
            If sDefaultPrinterName = "" Then
                sDefaultPrinterName = sPrinters(0)
            End If

            'imposto tutti i campi ai valori salvati
            Dim oOptions As cSurvey.Design.cOptionsPreview = oCurrentOptions
            With oOptions
                oCurrentPrinterSettings = New Printing.PrinterSettings
                If oOptions.PrinterName <> "" AndAlso oPrinters.Contains(oOptions.PrinterName) Then
                    oCurrentPrinterSettings.PrinterName = oOptions.PrinterName
                Else
                    oCurrentPrinterSettings.PrinterName = sDefaultPrinterName
                End If
                oCurrentPrinterSettings.DefaultPageSettings.PaperSize = modPaint.FindPaperSize(oCurrentPrinterSettings, oOptions.PageFormat)
                oCurrentPrinterSettings.DefaultPageSettings.Landscape = oOptions.PageLandscape
                oCurrentPrinterSettings.DefaultPageSettings.Margins = oOptions.PageMargins.ToMargin

                If Not IsNothing(oDoc) Then
                    oDoc.PrinterSettings = oCurrentPrinterSettings
                    oDoc.DefaultPageSettings = oCurrentPrinterSettings.DefaultPageSettings
                End If

                'If .PrinterName <> "" AndAlso oPrinters.ContainsKey(.PrinterName) Then
                '    oDoc.PrinterSettings.PrinterName = .PrinterName
                'Else
                '    oDoc.PrinterSettings.PrinterName = sDefaultPrinterName
                'End If
                cboPrinter.Text = oCurrentPrinterSettings.PrinterName 'oDoc.PrinterSettings.PrinterName
                Call pPageFormatRefresh(oCurrentPrinterSettings)

                'oDoc.DefaultPageSettings.PaperSize = pFindPaperSize(.PageFormat)
                'Dim sPaperName As String = oDoc.DefaultPageSettings.PaperSize.PaperName
                'oDoc.DefaultPageSettings.Margins = .PageMargins.Clone
                'oDoc.DefaultPageSettings.Landscape = .PageLandscape

                'cboPageFormat.Text = sPaperName
                chkPageVertical.Checked = Not oCurrentPrinterSettings.DefaultPageSettings.Landscape
                chkPageHorizontal.Checked = oCurrentPrinterSettings.DefaultPageSettings.Landscape

                If .ScaleMode = cSurvey.Design.cIOptionsPreview.ScaleModeEnum.sManual Then
                    cboScale.SelectedIndex = cboScale.Properties.Items.Count - 1
                Else
                    cboScale.SelectedIndex = .ScaleMode
                End If
                If .Scale > 0 Then
                    txtScaleManual.Value = .Scale
                End If

                chkTranslations.Enabled = True
                chkTranslations.Checked = .DrawTranslation

                chkUseDrawingZOrder.Enabled = True
                chkUseDrawingZOrder.Checked = .UseDrawingZOrder

                chkPrintBox.Checked = .DrawBox
                cboBoxPosition.SelectedIndex = .BoxPosition
                chkPrintCompass.Checked = .DrawCompass
                cboCompassPosition.SelectedIndex = .CompassPosition
                chkPrintScale.Checked = .DrawScale
                cboScalePosition.SelectedIndex = .ScalePosition

                chkPrintCentreline.Checked = .DrawPlot
                chkPrintShots.Checked = .DrawSegments
                chkPrintStations.Checked = .DrawPoints
                'chkPrintStations.Checked = .DrawPointNames
                chkPrintTrigpointText.Checked = .ShowPointText
                chkPrintLRUD.Checked = .DrawLRUD
                chkPrintSplay.Checked = .DrawSplay

                cboPrintDesignStyle.SelectedIndex = .DesignStyle
                chkPrintCentrelineColorGray.Checked = .CenterlineColorGray

                chkPrintImages.Checked = .DrawImages
                chkPrintSketches.Checked = .DrawSketches
                chkPrintDesign.Checked = .DrawDesign

                chkPrintDesignSpecialPoint.Checked = .DrawSpecialPoints

                chkPrintDesignAdvancedBrushes.Checked = .ShowAdvancedBrushes

                cboPrintCombineColorMode.SelectedIndex = .CombineColorMode
                chkPrintCombineColorGray.Checked = .CombineColorGray

                cboPrintCenterlineColorMode.SelectedIndex = .CenterlineColorMode
                chkPrintCentrelineColorGray.Checked = .CenterlineColorGray

                txtCurrentProfile.Text = .CurrentCaveVisibilityProfile
            End With
            oReturnOptions = oOptions
        ElseIf TypeOf oCurrentOptions Is cSurvey.Design.cOptionsExport Then
            btnStatusDesignZoom100.Visibility = BarItemVisibility.Never
            btnStatusDesignZoom200.Visibility = BarItemVisibility.Never
            btnStatusDesignZoom250.Visibility = BarItemVisibility.Never
            btnStatusDesignZoom500.Visibility = BarItemVisibility.Never
            btnStatusDesignZoom1000.Visibility = BarItemVisibility.Never
            pnlStatusDesignZoom.Visibility = BarItemVisibility.Never

            pnlPrintOptions.Visible = False
            pnlScaleOptions.Visible = True
            pnlExportOptionsOther.Visible = True
            btnDesignDetails.Visible = True

            pnlProfile.Visible = True
            If oSurvey.Properties.ShowLegacyPrintAndExportObjects Then
                pnlInformationBox.Visible = True
                pnlCompass.Visible = True
                pnlScale.Visible = True
            Else
                pnlInformationBox.Visible = False
                pnlCompass.Visible = False
                pnlScale.Visible = False
            End If

            Dim oOptions As cSurvey.Design.cOptionsExport = oCurrentOptions
            With oOptions
                cboFileFormat.Text = .FileFormat
                If cboFileFormat.Text = "" Then
                    cboFileFormat.Text = "JPG"
                End If
                cboImageUM.SelectedIndex = pFromImageUnit(.ImageUnit)
                Call pImageUnitChanged()
                txtImageWidth.Value = .ImageWidth
                txtImageHeight.Value = .ImageHeight
                chkBackgroundTransparent.Checked = .TransparentBackground

                Call cboFileFormat_SelectedIndexChanged(cboFileFormat, EventArgs.Empty)
                Call pImageSelectPage()

                If .ScaleMode = cSurvey.Design.cIOptionsPreview.ScaleModeEnum.sManual Then
                    cboScale.SelectedIndex = cboScale.Properties.Items.Count - 1
                Else
                    cboScale.SelectedIndex = .ScaleMode
                End If
                If .Scale > 0 Then
                    txtScaleManual.Value = .Scale
                End If

                chkTranslations.Enabled = True
                chkTranslations.Checked = .DrawTranslation

                chkUseDrawingZOrder.Enabled = True
                chkUseDrawingZOrder.Checked = .UseDrawingZOrder

                chkPrintBox.Checked = .DrawBox
                cboBoxPosition.SelectedIndex = .BoxPosition
                chkPrintCompass.Checked = .DrawCompass
                cboCompassPosition.SelectedIndex = .CompassPosition
                chkPrintScale.Checked = .DrawScale
                cboScalePosition.SelectedIndex = .ScalePosition

                chkPrintCentreline.Checked = .DrawPlot
                chkPrintShots.Checked = .DrawSegments
                chkPrintStations.Checked = .DrawPoints
                'chkPrintStations.Checked = .DrawPointNames
                chkPrintTrigpointText.Checked = .ShowPointText
                chkPrintLRUD.Checked = .DrawLRUD
                chkPrintSplay.Checked = .DrawSplay

                cboPrintDesignStyle.SelectedIndex = .DesignStyle
                chkPrintCentrelineColorGray.Checked = .CenterlineColorGray

                chkPrintImages.Checked = .DrawImages
                chkPrintSketches.Checked = .DrawSketches
                chkPrintDesign.Checked = .DrawDesign

                chkPrintDesignSpecialPoint.Checked = .DrawSpecialPoints

                chkPrintDesignAdvancedBrushes.Checked = .ShowAdvancedBrushes

                txtCurrentProfile.Text = .CurrentCaveVisibilityProfile

                cboPrintCombineColorMode.SelectedIndex = .CombineColorMode
                chkPrintCombineColorGray.Checked = .CombineColorGray

                cboPrintCenterlineColorMode.SelectedIndex = .CenterlineColorMode
                chkPrintCentrelineColorGray.Checked = .CenterlineColorGray

                If oCurrentProfile.Design = cIDesign.cDesignTypeEnum.Plan Then
                    chkExportGPS.Enabled = True
                    chkExportGPS.Checked = .GPS.ExportData
                    cboGPSData.SelectedIndex = .GPS.DataFormat
                Else
                    chkExportGPS.Enabled = False
                    chkExportGPS.Checked = False
                    cboGPSData.SelectedIndex = 0
                End If
            End With

            Dim oExportProfile As cExportProfile = oCurrentProfile
            sLastFilename = oExportProfile.Filename
            oReturnOptions = oOptions
        ElseIf TypeOf oCurrentOptions Is cSurvey.Design.cOptionsViewer Then
            btnStatusDesignZoom100.Visibility = BarItemVisibility.Always
            btnStatusDesignZoom200.Visibility = BarItemVisibility.Always
            btnStatusDesignZoom250.Visibility = BarItemVisibility.Always
            btnStatusDesignZoom500.Visibility = BarItemVisibility.Always
            btnStatusDesignZoom1000.Visibility = BarItemVisibility.Always
            pnlStatusDesignZoom.Visibility = BarItemVisibility.Always

            pnlPrintOptions.Visible = False
            pnlScaleOptions.Visible = False
            pnlExportOptionsFormat.Visible = False
            pnlExportOptionsSize.Visible = False
            pnlExportOptionsPage.Visible = False
            pnlExportOptionsOther.Visible = False
            btnDesignDetails.Visible = False

            pnlProfile.Visible = True
            pnlInformationBox.Visible = False
            pnlCompass.Visible = False
            pnlScale.Visible = False

            Dim oOptions As cSurvey.Design.cOptionsViewer = oCurrentOptions
            With oOptions
                'pnlProfile.Enabled = Not oOptions.DrawPrintOrExportArea
                chkTranslations.Enabled = False
                chkTranslations.Checked = .DrawTranslation

                chkUseDrawingZOrder.Enabled = False
                chkUseDrawingZOrder.Checked = .UseDrawingZOrder

                chkPrintBox.Checked = .DrawBox
                cboBoxPosition.SelectedIndex = .BoxPosition
                chkPrintCompass.Checked = .DrawCompass
                cboCompassPosition.SelectedIndex = .CompassPosition
                chkPrintScale.Checked = .DrawScale
                cboScalePosition.SelectedIndex = .ScalePosition

                chkPrintCentreline.Checked = .DrawPlot
                chkPrintShots.Checked = .DrawSegments
                chkPrintStations.Checked = .DrawPoints
                'chkPrintStations.Checked = .DrawPointNames
                chkPrintTrigpointText.Checked = .ShowPointText
                chkPrintLRUD.Checked = .DrawLRUD
                chkPrintSplay.Checked = .DrawSplay

                cboPrintDesignStyle.SelectedIndex = .DesignStyle
                chkPrintCentrelineColorGray.Checked = .CenterlineColorGray

                chkPrintImages.Checked = .DrawImages
                chkPrintSketches.Checked = .DrawSketches
                chkPrintDesign.Checked = .DrawDesign

                chkPrintDesignSpecialPoint.Checked = .DrawSpecialPoints

                chkPrintDesignAdvancedBrushes.Checked = .ShowAdvancedBrushes

                txtCurrentProfile.Text = .CurrentCaveVisibilityProfile

                cboPrintCombineColorMode.SelectedIndex = .CombineColorMode
                chkPrintCombineColorGray.Checked = .CombineColorGray

                cboPrintCenterlineColorMode.SelectedIndex = .CenterlineColorMode
                chkPrintCentrelineColorGray.Checked = .CenterlineColorGray
            End With
            oReturnOptions = oOptions
        End If
        bEventDisabled = False
        Return oReturnOptions
    End Function

    Private Function pFindPaperSize(ByVal PaperSize As String) As PaperSize
        For Each oPaperSize As PaperSize In oCurrentPrinterSettings.PaperSizes
            If oPaperSize.PaperName = PaperSize Then
                Return oPaperSize
            End If
        Next
        Return oCurrentPrinterSettings.DefaultPageSettings.PaperSize
    End Function

    Private Sub pDrawExportPreview() ' Optional DrawDesign As Boolean = True)
        oMousePointer.Push(Cursors.WaitCursor)
        bEventDisabled = True
        Call pOptionsSave()
        Dim oOptions As cSurvey.Design.cOptionsExport = oCurrentOptions 'pExportOptionsSave()

        'fallback unit to pixel to generate preview
        Dim iImageWidth As Integer = modPaint.ToPixel(oOptions.ImageUnit, oOptions.ImageWidth)
        Dim iImageHeight As Integer = modPaint.ToPixel(oOptions.ImageUnit, oOptions.ImageHeight)

        Dim oImage As Bitmap
        Try
            If (picExport.Image Is Nothing) OrElse (Not picExport.Image Is Nothing AndAlso ((picExport.Image.Width <> iImageWidth) OrElse (picExport.Image.Height <> iImageHeight))) Then
                Try
                    oImage = New Bitmap(iImageWidth, iImageHeight) ', Drawing.Imaging.PixelFormat.Format32bppArgb)
                Catch
                    iImageWidth = 2048
                    iImageHeight = 2048
                    oImage = New Bitmap(iImageWidth, iImageHeight)
                End Try
            Else
                oImage = picExport.Image
            End If
        Catch
            Try
                oImage = New Bitmap(iImageWidth, iImageHeight) ', Drawing.Imaging.PixelFormat.Format32bppArgb)
            Catch
                iImageWidth = 2048
                iImageHeight = 2048
                oImage = New Bitmap(iImageWidth, iImageHeight)
            End Try
        End Try
        If modMain.Is64Bit OrElse modMain.bIsInDebug Then oImage.SetResolution(txtImageDPI.Value, txtImageDPI.Value)
        picExport.Size = New Size(iImageWidth * sViewZoom, iImageHeight * sViewZoom)

        If bManualRefresh And bFirstRendering Then
            Using oGr As Graphics = Graphics.FromImage(oImage)
                oGr.FillRectangle(Brushes.LightGray, oGr.ClipBounds)
            End Using
        Else
            Using oGr As Graphics = Graphics.FromImage(oImage)
                oGr.PageUnit = GraphicsUnit.Pixel

                If iDesignQuality = frmMain2.DesignQualityLevelEnum.Base Then
                    oGr.CompositingQuality = CompositingQuality.HighSpeed
                    oGr.SmoothingMode = SmoothingMode.HighSpeed
                    oGr.InterpolationMode = InterpolationMode.Low
                    oGr.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
                ElseIf iDesignQuality = frmMain2.DesignQualityLevelEnum.MediumQuality Then
                    oGr.CompositingQuality = CompositingQuality.HighSpeed
                    oGr.SmoothingMode = SmoothingMode.AntiAlias
                    oGr.InterpolationMode = InterpolationMode.Default
                    oGr.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
                Else
                    oGr.CompositingQuality = CompositingQuality.HighQuality
                    oGr.SmoothingMode = SmoothingMode.AntiAlias
                    oGr.InterpolationMode = InterpolationMode.HighQualityBicubic
                    oGr.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
                End If

                If oOptions.TransparentBackground Then
                    Call oGr.Clear(Color.Transparent)
                Else
                    Call oGr.Clear(Color.White)
                End If

                Dim oMargins As System.Drawing.Printing.Margins = New System.Drawing.Printing.Margins(modPaint.ToPixel(oOptions.ImageUnit, oOptions.Margins.Left), modPaint.ToPixel(oOptions.ImageUnit, oOptions.Margins.Top), modPaint.ToPixel(oOptions.ImageUnit, oOptions.Margins.Right), modPaint.ToPixel(oOptions.ImageUnit, oOptions.Margins.Bottom))

                sPaintZoom = 10
                Dim oPageRect As RectangleF = New RectangleF(oMargins.Left, oMargins.Top, iImageWidth - oMargins.Left - oMargins.Right, iImageHeight - oMargins.Top - oMargins.Bottom)
                oPaintTranslation = New PointF(oPageRect.Width / 2, oPageRect.Height / 2)
                Dim oRect As RectangleF
                If oCurrentProfile.Design = cIDesign.cDesignTypeEnum.Plan Then
                    oRect = oSurvey.Plan.GetDesignVisibleBounds(oOptions)
                Else
                    oRect = oSurvey.Profile.GetDesignVisibleBounds(oOptions)
                End If
                oRect = modPaint.AdjustBounds(oRect, 1)

                Dim sMaxZoom As Single = modPaint.GetZoomFactor(oGr, txtScaleManual.Properties.MinValue)
                Dim sMinZoom As Single = modPaint.GetZoomFactor(oGr, txtScaleManual.Properties.MaxValue)

                If cboScale.SelectedIndex = 0 Then
                    Dim sDesignWidth As Single = oRect.Size.Width
                    Dim sDesignHeight As Single = oRect.Size.Height
                    Dim sPageWidth As Single = oPageRect.Size.Width ' (oPageRect.Size.Width / oGr.DpiX) * 0.0254
                    Dim sPageHeight As Single = oPageRect.Size.Height ' (oPageRect.Size.Height / oGr.DpiX) * 0.0254
                    Dim sDeltaX As Single = sPageWidth / sDesignWidth
                    Dim sDeltaY As Single = sPageHeight / sDesignHeight
                    Dim sDelta As Single = If(sDeltaX < sDeltaY, sDeltaX, sDeltaY)
                    If Single.IsInfinity(sDelta) Then sDelta = 100
                    sPaintZoom = sDelta
                    If sPaintZoom < sMinZoom Then sPaintZoom = sMinZoom
                    If sPaintZoom > sMaxZoom Then sPaintZoom = sMaxZoom
                    txtScaleManual.Value = modPaint.GetScaleFactor(oGr, sPaintZoom)
                Else
                    Dim iFactor As Integer
                    If cboScale.SelectedIndex = cboScale.Properties.Items.Count - 1 Then
                        iFactor = txtScaleManual.Value
                    Else
                        Dim sFactor As String = cboScale.Text
                        If sFactor = "" Then
                            iFactor = 250
                        Else
                            iFactor = sFactor.Substring(sFactor.IndexOf(":") + 1)
                        End If
                        txtScaleManual.Value = iFactor
                    End If
                    sPaintZoom = modPaint.GetZoomFactor(oGr, iFactor) ' ((1 / iFactor) / 0.0254) * oGr.DpiX
                End If

                oCurrentOptions.CurrentScale = txtScaleManual.Value

                oPaintTranslation = New PointF(-oRect.Left * sPaintZoom + oPageRect.Left + (oPageRect.Width - (oRect.Width * sPaintZoom)) / 2, -oRect.Top * sPaintZoom + oPageRect.Top + (oPageRect.Height - (oRect.Height * sPaintZoom)) / 2)

                Using oMatrix As Matrix = New Matrix
                    Call oMatrix.Scale(sPaintZoom, sPaintZoom, MatrixOrder.Append)
                    Call oMatrix.Translate(oPaintTranslation.X, oPaintTranslation.Y, MatrixOrder.Append)
                    oGr.Transform = oMatrix
                End Using

                If oCurrentProfile.Design = cIDesign.cDesignTypeEnum.Plan Then
                    Call oSurvey.Plan.Paint(oGr, oOptions, cDrawOptions.Empty, oSelection)

                    Call oGr.ResetTransform()
                    If pnlCompass.Visible AndAlso oOptions.DrawCompass Then
                        Call oSurvey.Plan.Plot.Compass.Rebind(oGr, oOptions, oPageRect, Nothing)
                        Call oSurvey.Plan.Plot.Compass.Paint(oGr, oOptions)
                    End If
                    If pnlScale.Visible AndAlso oOptions.DrawScale Then
                        Call oSurvey.Plan.Plot.Scale.Rebind(oGr, oOptions, oPageRect, New cSurvey.Design.cDesignScale.cParameters(sPaintZoom))
                        Call oSurvey.Plan.Plot.Scale.Paint(oGr, oOptions)
                    End If
                    If pnlInformationBox.Visible AndAlso oOptions.DrawBox Then
                        Call oSurvey.Plan.Plot.InfoBox.Rebind(oGr, oOptions, oPageRect, Nothing)
                        Call oSurvey.Plan.Plot.InfoBox.Paint(oGr, oOptions)
                    End If
                Else
                    Call oSurvey.Profile.Paint(oGr, oOptions, cDrawOptions.Empty, oSelection)

                    Call oGr.ResetTransform()
                    If pnlScale.Visible AndAlso oOptions.DrawScale Then
                        Call oSurvey.Profile.Plot.Scale.Rebind(oGr, oOptions, oPageRect, New cSurvey.Design.cDesignScale.cParameters(sPaintZoom))
                        Call oSurvey.Profile.Plot.Scale.Paint(oGr, oOptions)
                    End If
                    If pnlInformationBox.Visible AndAlso oOptions.DrawBox Then
                        Call oSurvey.Profile.Plot.InfoBox.Rebind(oGr, oOptions, oPageRect, Nothing)
                        Call oSurvey.Profile.Plot.InfoBox.Paint(oGr, oOptions)
                    End If
                End If
            End Using
        End If
        'End If
        picExport.Image = oImage
        bEventDisabled = False
        Call oMousePointer.Pop()
    End Sub

    Private Sub oDoc_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles oDoc.PrintPage
        oMousePointer.Push(Cursors.WaitCursor)
        bEventDisabled = True
        Call pOptionsSave()

        Dim oOptions As cSurvey.Design.cOptionsPreview = oCurrentOptions

        If bManualRefresh And bFirstRendering Then
            Dim oGr As Graphics = e.Graphics
            oGr.FillRectangle(Brushes.LightGray, oGr.ClipBounds)
        Else

            sPaintZoom = 10
            Dim oPageRect As RectangleF = e.MarginBounds

            Dim oGr As Graphics = e.Graphics

            If iDesignQuality = frmMain2.DesignQualityLevelEnum.Base Then
                oGr.CompositingMode = CompositingMode.SourceOver
                oGr.CompositingQuality = CompositingQuality.HighSpeed
                oGr.SmoothingMode = SmoothingMode.HighSpeed
                oGr.InterpolationMode = InterpolationMode.Low
                oGr.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            ElseIf iDesignQuality = frmMain2.DesignQualityLevelEnum.MediumQuality Then
                oGr.CompositingMode = CompositingMode.SourceOver
                oGr.CompositingQuality = CompositingQuality.HighSpeed
                oGr.SmoothingMode = SmoothingMode.AntiAlias
                oGr.InterpolationMode = InterpolationMode.Default
                oGr.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
            Else
                oGr.CompositingMode = CompositingMode.SourceOver
                oGr.CompositingQuality = CompositingQuality.AssumeLinear
                oGr.SmoothingMode = SmoothingMode.AntiAlias
                oGr.InterpolationMode = InterpolationMode.HighQualityBicubic
                oGr.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
            End If

            oPaintTranslation = New PointF(oPageRect.Width / 2, oPageRect.Height / 2)
            Dim oRect As RectangleF
            If oCurrentProfile.Design = cIDesign.cDesignTypeEnum.Plan Then
                oRect = oSurvey.Plan.GetDesignVisibleBounds(oOptions)
            Else
                oRect = oSurvey.Profile.GetDesignVisibleBounds(oOptions)
            End If
            oRect = modPaint.AdjustBounds(oRect, 1)

            Dim sMaxZoom As Single = modPaint.GetZoomFactor(oGr, txtScaleManual.Properties.MinValue)
            Dim sMinZoom As Single = modPaint.GetZoomFactor(oGr, txtScaleManual.Properties.MaxValue)

            If cboScale.SelectedIndex = 0 Then
                Dim sDesignWidth As Single = oRect.Size.Width
                Dim sDesignHeight As Single = oRect.Size.Height
                Dim sPageWidth As Single = oPageRect.Size.Width '* 0.000254
                Dim sPageHeight As Single = oPageRect.Size.Height '* 0.000254
                Dim sDeltaX As Single = sPageWidth / sDesignWidth
                Dim sDeltaY As Single = sPageHeight / sDesignHeight
                Dim sDelta As Single = If(sDeltaX < sDeltaY, sDeltaX, sDeltaY)
                If Single.IsInfinity(sDelta) Then sDelta = 100
                sPaintZoom = sDelta * 0.9
                If sPaintZoom < sMinZoom Then sPaintZoom = sMinZoom
                If sPaintZoom > sMaxZoom Then sPaintZoom = sMaxZoom
                txtScaleManual.Value = modPaint.GetScaleFactor(oGr, sPaintZoom)
            Else
                Dim iFactor As Integer
                If cboScale.SelectedIndex = cboScale.Properties.Items.Count - 1 Then
                    iFactor = txtScaleManual.Value
                Else
                    Dim sFactor As String = cboScale.Text
                    If sFactor = "" Then
                        iFactor = 250
                    Else
                        iFactor = sFactor.Substring(sFactor.IndexOf(":") + 1)
                    End If
                    txtScaleManual.Value = iFactor
                End If
                sPaintZoom = modPaint.GetZoomFactor(oGr, iFactor) '((1 / iFactor) / 0.000254) '* e.Graphics.DpiX
            End If

            oCurrentOptions.CurrentScale = txtScaleManual.Value
            oRect = modPaint.FullScaleRectangle(oRect, sPaintZoom, sPaintZoom)
            oPaintTranslation = New PointF(-oRect.Left + oPageRect.Left + (oPageRect.Width - (oRect.Width)) / 2, -oRect.Top + oPageRect.Top + (oPageRect.Height - (oRect.Height)) / 2)

            Try
                Using oMatrix As Matrix = New Matrix
                    Call oMatrix.Scale(sPaintZoom, sPaintZoom, MatrixOrder.Append)
                    Call oMatrix.Translate(oPaintTranslation.X, oPaintTranslation.Y, MatrixOrder.Append)
                    oGr.Transform = oMatrix
                End Using

                If oCurrentProfile.Design = cIDesign.cDesignTypeEnum.Plan Then
                    Call oSurvey.Plan.Paint(oGr, oOptions, cDrawOptions.Empty, oSelection)
                    'tolgo la matrice del disegno e disegno i gadget aggiuntivi con le apposite classi di servizio (senza matrice)
                    Call oGr.ResetTransform()
                    If pnlCompass.Visible AndAlso oOptions.DrawCompass Then
                        Call oSurvey.Plan.Plot.Compass.Rebind(oGr, oOptions, oPageRect, Nothing)
                        Call oSurvey.Plan.Plot.Compass.Paint(oGr, oOptions)
                    End If
                    If pnlScale.Visible AndAlso oOptions.DrawScale Then
                        Call oSurvey.Plan.Plot.Scale.Rebind(oGr, oOptions, oPageRect, New cSurvey.Design.cDesignScale.cParameters(sPaintZoom))
                        Call oSurvey.Plan.Plot.Scale.Paint(oGr, oOptions)
                    End If
                    If pnlInformationBox.Visible AndAlso oOptions.DrawBox Then
                        Call oSurvey.Plan.Plot.InfoBox.Rebind(oGr, oOptions, oPageRect, Nothing)
                        Call oSurvey.Plan.Plot.InfoBox.Paint(oGr, oOptions)
                    End If
                Else
                    Call oSurvey.Profile.Paint(oGr, oOptions, cDrawOptions.Empty, oSelection)
                    'tolgo la matrice del disegno e disegno i gadget aggiuntivi con le apposite classi di servizio (senza matrice)
                    Call oGr.ResetTransform()
                    If pnlScale.Visible AndAlso oOptions.DrawScale Then
                        Call oSurvey.Profile.Plot.Scale.Rebind(oGr, oOptions, oPageRect, New cSurvey.Design.cDesignScale.cParameters(sPaintZoom))
                        Call oSurvey.Profile.Plot.Scale.Paint(oGr, oOptions)
                    End If
                    If pnlInformationBox.Visible AndAlso oOptions.DrawBox Then
                        Call oSurvey.Profile.Plot.InfoBox.Rebind(oGr, oOptions, oPageRect, Nothing)
                        Call oSurvey.Profile.Plot.InfoBox.Paint(oGr, oOptions)
                    End If
                End If
            Catch ex As Exception
                Debug.Print("oDoc.PrintPage>" & ex.Message)
            End Try
        End If
        bEventDisabled = False
        Call oMousePointer.Pop()
    End Sub

    Private Sub pPrint()
        prDialog.Document = oDoc
        prDialog.AllowPrintToFile = False
        prDialog.UseEXDialog = True
        If prDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If bManualRefresh Then pRefresh(True)
            oDoc.DocumentName = If(oSurvey.Name <> "", oSurvey.Name, GetLocalizedString("preview.textpart1")) & If(oCurrentProfile.IsPlan, " - " & GetLocalizedString("preview.textpart2"), " - " & GetLocalizedString("preview.textpart3"))
            Call oDoc.Print()
            oDoc.DocumentName = oSurvey.Name
        End If
    End Sub

    Private Sub chkPrintSegments1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintShots.CheckedChanged
        Call pRefresh()
    End Sub

    Private Sub pInvalidate()
        bInvalidated = True
        'pnlPopup.Visible = True
        'lblPopupWarning.Text = GetLocalizedString("preview.warning1")

        cDesignMessageCorner.PopupShow("warning", GetLocalizedString("preview.warning1"))
        btnRefresh.Visibility = BarItemVisibility.Always
    End Sub

    Private Sub pInvalidateReset()
        bInvalidated = False
        'pnlPopup.Visible = False

        cDesignMessageCorner.PopupHide()
        btnRefresh.Visibility = BarItemVisibility.Never
    End Sub

    Private Sub pRefresh(Optional ForceRefresh As Boolean = False, Optional FirstRefresh As Boolean = False)
        If (bManualRefresh AndAlso (ForceRefresh OrElse FirstRefresh)) OrElse Not bManualRefresh Then
            If Not bEventDisabled And Not oCurrentProfile Is Nothing Then
                If Not FirstRefresh Then Call pInvalidateReset()
                Call oMousePointer.Push(Cursors.AppStarting)

                Dim bIsPlan As Boolean = oCurrentProfile.IsPlan
                chkPrintCompass.Enabled = bIsPlan
                cboCompassPosition.Enabled = bIsPlan
                btnCompassDetails.Enabled = bIsPlan 'And chkPrintCompass.Checked

                Call oSurvey.Redraw(oCurrentOptions)
                Select Case iMode
                    Case PreviewModeEnum.Preview
                        Call pPreview.InvalidatePreview()
                    Case PreviewModeEnum.Export
                        Call pDrawExportPreview()
                    Case PreviewModeEnum.Viewer
                        Call pMapInvalidate()
                End Select
                Call pScaleUpdate()

                If bFirstRendering And bManualRefresh Then pInvalidate()

                Call oMousePointer.Pop()
            End If
        Else
            Call pInvalidate()
        End If
    End Sub

    Public Sub ProfileInvalidate()
        Call pProfileSelect(NavBarControl1.SelectedLink.Item.Tag)
    End Sub

    Public Sub MapInvalidate()
        Call pRefresh()
    End Sub

    Private Sub chkPrintBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintBox.CheckedChanged
        'btnInfoBoxDetails.Enabled = chkPrintBox.Checked
        Call pRefresh()
    End Sub

    Private Sub cboBoxPosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBoxPosition.SelectedIndexChanged
        Call pRefresh()
    End Sub

    Private Sub cboScalePosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboScalePosition.SelectedIndexChanged
        Call pRefresh()
    End Sub

    Private Sub chkPrintScale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintScale.CheckedChanged
        'btnScaleDetails.Enabled = chkPrintScale.Checked
        Call pRefresh()
    End Sub

    Private Sub chkPrintCompass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintCompass.CheckedChanged
        'btnCompassDetails.Enabled = chkPrintCompass.Checked
        Call pRefresh()
    End Sub

    Private Sub cboCompassPosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCompassPosition.SelectedIndexChanged
        Call pRefresh()
    End Sub

    Private Sub chkPrintCentreline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintCentreline.CheckedChanged
        If chkPrintCentreline.Checked Then
            chkPrintDesignSpecialPoint.Checked = False
        End If
        Dim bEnabled As Boolean = chkPrintCentreline.Checked
        chkPrintShots.Enabled = bEnabled
        chkPrintStations.Enabled = bEnabled
        chkPrintLRUD.Enabled = bEnabled
        chkPrintSplay.Enabled = bEnabled
        chkPrintCentrelineColorGray.Enabled = bEnabled
        chkPrintDesignSpecialPoint.Enabled = Not bEnabled
        chkPrintTrigpointText.Enabled = bEnabled

        lblPrintCenterlineColorMode.Enabled = bEnabled
        cboPrintCenterlineColorMode.Enabled = bEnabled
        chkPrintCentrelineColorGray.Enabled = bEnabled

        Call pRefresh()
    End Sub

    Private Sub chkPrintStations_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintStations.CheckedChanged
        Call pRefresh()
    End Sub

    Private Sub chkPrintLRUD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintLRUD.CheckedChanged
        Call pRefresh()
    End Sub

    Private Sub cboSegmentsPaintStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call pRefresh()
    End Sub

    Private Sub chkPrintSegmentsColor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintCentrelineColorGray.CheckedChanged
        Call pRefresh()
    End Sub

    Private Sub chkPrintDesign_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintDesign.CheckedChanged
        Dim bDesignEnabled As Boolean = chkPrintDesign.Checked
        'btnDesignDetails.Enabled = chkPrintDesign.Checked
        chkPrintImages.Enabled = bDesignEnabled
        chkPrintSketches.Enabled = bDesignEnabled
        chkPrintDesignAdvancedBrushes.Enabled = bDesignEnabled
        Dim bSegmentEnabled As Boolean = chkPrintCentreline.Checked
        chkPrintDesignSpecialPoint.Enabled = Not bSegmentEnabled And bDesignEnabled
        Call pRefresh()
    End Sub

    Private Sub chkPrintImages_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintImages.CheckedChanged
        Call pRefresh()
    End Sub

    Private Sub cboPrinter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrinter.SelectedIndexChanged
        Try
            If Not bEventDisabled Then
                If cboPrinter.Text <> oCurrentPrinterSettings.PrinterName Then
                    oCurrentPrinterSettings.PrinterName = cboPrinter.Text
                    Call pPageFormatRefresh(oCurrentPrinterSettings)
                    Call pRefresh()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboScale_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboScale.SelectedIndexChanged
        If Not bEventDisabled Then
            Dim bEnabled As Boolean = cboScale.SelectedIndex = cboScale.Properties.Items.Count - 1
            txtScaleManual.Enabled = bEnabled
            lblScale1.Enabled = bEnabled
            If Not bEnabled Then
                If cboScale.SelectedIndex > 0 Then
                    Dim sFactor As String = cboScale.Text
                    txtScaleManual.Value = Integer.Parse(sFactor.Substring(sFactor.IndexOf(":") + 1))
                End If
            End If
            Call pRefresh()
        End If
    End Sub

    Private Sub txtScaleManual_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScaleManual.ValueChanged
        If Not bEventDisabled Then
            If txtScaleManual.Enabled Then
                Call pRefresh()
            End If
        End If
    End Sub

    Private Sub pPreview_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pPreview.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            oStartPaintDrawPosition = New PointF(-oPaintTranslation.X + e.X, -oPaintTranslation.Y + e.Y)
        End If
    End Sub

    Private Sub pPreview_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pPreview.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            oPaintTranslation = New PointF(e.X - oStartPaintDrawPosition.X, e.Y - oStartPaintDrawPosition.Y)
        End If
    End Sub

    Private Sub pPreview_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pPreview.MouseWheel
        Dim iVal As Integer = e.Delta / 120
        Dim iAbs As Integer = Math.Abs(iVal)
        Dim iSegno As Integer = If(iAbs <> 0, iVal / iAbs, 0)
        If (iAbs < 20) And (((iSegno > 0) And (pPreview.Zoom > 0.1)) Or ((iSegno < 0) And (pPreview.Zoom < 100))) Then
            For j As Integer = 1 To iAbs
                If iSegno > 0 Then
                    pPreview.Zoom *= 1.1
                Else
                    pPreview.Zoom /= 1.1
                End If
            Next
        End If
    End Sub

    'Private Sub cboPageFormat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Not bEventDisabled Then
    '        Dim oPaperSize As PaperSize = pFindPaperSize(cboPageFormat.Text)
    '        If oPaperSize.PaperName <> oCurrentPrinterSettings.DefaultPageSettings.PaperSize.PaperName Then
    '            oCurrentPrinterSettings.DefaultPageSettings.PaperSize = oPaperSize
    '            Call pRefresh()
    '        End If
    '    End If
    'End Sub

    Private Sub cmdSetMargins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetMargins.Click
        Dim oOptions As cSurvey.Design.cOptionsPreview = oCurrentOptions
        Dim oParameters As frmPreviewMargins = New frmPreviewMargins(oOptions.PageMargins, "mm")
        pnlParameters.Controls.Add(oParameters)
        flyParameters.Size = oParameters.Size
        oParameters.Dock = DockStyle.Fill
        flyParameters.OwnerControl = cmdSetMargins
        flyParameters.ShowBeakForm(True)

        'Using frmPM As frmPreviewMargins = New frmPreviewMargins(PageMargins, "mm")
        '    With frmPM
        '        .Margins = oOptions.PageMargins.Clone
        '        Call .ConvertToMillimeter()
        '        If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        '            Call .ConvertToThousandthsOfAnInch()
        '            oOptions.PageMargins = .Margins.Clone
        '            oDoc.DefaultPageSettings.Margins = oOptions.PageMargins.Clone
        '            Call pRefresh()
        '        End If
        '    End With
        'End Using
    End Sub

    Private Sub pExport()
        Call pOptionsSave()
        Using oSD As SaveFileDialog = New SaveFileDialog
            With oSD
                Dim oOptions As cSurvey.Design.cOptionsExport = oCurrentOptions
                .Title = GetLocalizedString("preview.saveimagedialog")
                Dim sExtension As String = oOptions.FileFormat
                If sLastFilename = "" Then
                    sLastFilename = If(oSurvey.Name <> "", oSurvey.Name, GetLocalizedString("preview.textpart1")) & If(oCurrentProfile.Name <> "", " - " & oCurrentProfile.Name, "") & "." & sExtension
                Else
                    sLastFilename = IO.Path.GetFileNameWithoutExtension(sLastFilename) & "." & sExtension
                End If
                .FileName = sLastFilename
                .Filter = String.Format(GetLocalizedString("preview.filetypeIMAGES"), oOptions.FileFormat) & " (*." & sExtension & ")|*." & sExtension
                .FilterIndex = 1
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    If bInvalidated Then
                        'Call pRefresh(True, False)
                    End If
                    Dim sExt As String = IO.Path.GetExtension(.FileName).ToLower
                        Select Case sExt
                            Case ".jpg", ".tif", ".png", ".bmp"
                                Call oMousePointer.Push(Cursors.WaitCursor)
                                If bManualRefresh Then pRefresh(True)
                                sLastFilename = .FileName
                                Dim iImageFormat As System.Drawing.Imaging.ImageFormat
                                Select Case sExt
                                    Case ".jpg"
                                        iImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg
                                    Case ".tif"
                                        iImageFormat = System.Drawing.Imaging.ImageFormat.Tiff
                                    Case ".png"
                                        iImageFormat = System.Drawing.Imaging.ImageFormat.Png
                                    Case ".bmp"
                                        iImageFormat = System.Drawing.Imaging.ImageFormat.Bmp
                                End Select
                                Call picExport.Image.Save(sLastFilename, iImageFormat)
                                If oOptions.GPS.ExportData Then
                                    Select Case oOptions.GPS.DataFormat
                                        Case Options.cGPSOptions.GPSDataFormatEnum.GoogleEarthImageOverlay
                                            Try
                                                Dim oOrigin As cTrigPoint = oSurvey.TrigPoints.GetGPSBaseReferencePoint
                                                If oOrigin Is Nothing Then
                                                    Call MsgBox(GetLocalizedString("preview.warning2"), MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, GetLocalizedString("preview.warningtitle"))
                                                Else
                                                    Dim dLat As Double = oOrigin.Coordinate.GetLatitude
                                                    Dim dLong As Double = oOrigin.Coordinate.GetLongitude

                                                    If dLat = 0 And dLong = 0 Then
                                                        Call MsgBox(GetLocalizedString("preview.warning3"), MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, GetLocalizedString("preview.warningtitle"))
                                                    Else
                                                        Dim oPoint As PointF = oOrigin.GetSegments(0).Data.Plan.ToPoint
                                                        Dim oTopLeft As PointF = modPaint.FromPaintPoint(New PointF(0, 0), sPaintZoom, oPaintTranslation)
                                                        Dim oBottomRight As PointF = modPaint.FromPaintPoint(New PointF(picExport.Image.Width, picExport.Image.Height), sPaintZoom, oPaintTranslation)

                                                        Dim dMC As Decimal = oSurvey.Calculate.GeoMagDeclinationData.MeridianConvergence
                                                        Dim dTopLeftDistance As Single = modPaint.DistancePointToPoint(oPoint, oTopLeft)
                                                        Dim dBottomRightDistance As Single = modPaint.DistancePointToPoint(oPoint, oBottomRight)
                                                        Dim dTopLeftAngle As Single = modPaint.AddAngle(modPaint.GetBearing(oPoint, oTopLeft), dMC)
                                                        Dim dBottomRightAngle As Single = modPaint.AddAngle(modPaint.GetBearing(oPoint, oBottomRight), dMC)

                                                        Dim dTopLeftLat As Decimal
                                                        Dim dTopLeftLong As Decimal
                                                        Call CalculateCoordinates(oSurvey, dLat, dLong, dTopLeftDistance, dTopLeftAngle, dTopLeftLat, dTopLeftLong)
                                                        Dim dBottomRightLat As Decimal
                                                        Dim dBottomRightLong As Decimal
                                                        Call CalculateCoordinates(oSurvey, dLat, dLong, dBottomRightDistance, dBottomRightAngle, dBottomRightLat, dBottomRightLong)

                                                        Call modExport.GoogleKmlOverlayExportTo(oSurvey, sLastFilename, dTopLeftLat, dTopLeftLong, dBottomRightLat, dBottomRightLong)
                                                    End If
                                                End If
                                            Catch
                                            End Try
                                    End Select
                                End If
                                Call oMousePointer.Pop()
                            Case ".svg"
                                Call oMousePointer.Push(Cursors.WaitCursor)
                                If bManualRefresh Then pRefresh(True)

                                Dim sImageWidth As Single = oOptions.ImageWidth  '4096
                                Dim sImageHeight As Single = oOptions.ImageHeight '4096

                                Dim sPaintZoom As Single = 10
                                Dim oPageRect As RectangleF = New RectangleF(oOptions.Margins.Left, oOptions.Margins.Top, sImageWidth - oOptions.Margins.Left - oOptions.Margins.Right, sImageHeight - oOptions.Margins.Top - oOptions.Margins.Bottom)
                                'oPaintTranslation = New PointF(oPageRect.Width / 2, oPageRect.Height / 2)
                                Dim oRect As RectangleF
                                If oCurrentProfile.Design = cIDesign.cDesignTypeEnum.Plan Then
                                    oRect = oSurvey.Plan.GetDesignVisibleBounds(oOptions)
                                Else
                                    oRect = oSurvey.Profile.GetDesignVisibleBounds(oOptions)
                                End If
                                oRect = modPaint.AdjustBounds(oRect, 1)

                                If cboScale.SelectedIndex = 0 Then
                                    Dim sDesignWidth As Single = oRect.Size.Width
                                    Dim sDesignHeight As Single = oRect.Size.Height
                                    Dim sPageWidth As Single = oPageRect.Size.Width ' (oPageRect.Size.Width / oGr.DpiX) * 0.0254
                                    Dim sPageHeight As Single = oPageRect.Size.Height ' (oPageRect.Size.Height / oGr.DpiX) * 0.0254
                                    Dim sDeltaX As Single = sPageWidth / sDesignWidth
                                    Dim sDeltaY As Single = sPageHeight / sDesignHeight
                                    Dim sDelta As Single = If(sDeltaX < sDeltaY, sDeltaX, sDeltaY)
                                    If Single.IsInfinity(sDelta) Then sDelta = 100
                                    sPaintZoom = sDelta
                                    Using oGr As Graphics = picExport.CreateGraphics
                                        txtScaleManual.Value = modPaint.GetScaleFactor(oGr, sPaintZoom)
                                    End Using
                                Else
                                    Dim iFactor As Integer
                                    If cboScale.SelectedIndex = cboScale.Properties.Items.Count - 1 Then
                                        iFactor = txtScaleManual.Value
                                    Else
                                        Dim sFactor As String = cboScale.Text
                                        If sFactor = "" Then
                                            iFactor = 250
                                        Else
                                            iFactor = sFactor.Substring(sFactor.IndexOf(":") + 1)
                                        End If
                                        txtScaleManual.Value = iFactor
                                    End If
                                    Using oGr As Graphics = picExport.CreateGraphics
                                        sPaintZoom = modPaint.GetZoomFactor(oGr, iFactor) ' ((1 / iFactor) / 0.0254) * oGr.DpiX
                                    End Using
                                End If
                                'oRect = modPaint.ScaleRectangle(oRect, sPaintZoom)

                                Dim oPaintTranslation As PointF = New PointF(-oRect.Left * sPaintZoom + oPageRect.Left + (oPageRect.Width - (oRect.Width * sPaintZoom)) / 2, -oRect.Top * sPaintZoom + oPageRect.Top + (oPageRect.Height - (oRect.Height * sPaintZoom)) / 2)

                                'scale page coordinate to real coordinate (without margins....to prevent some svg viewer cutting objects outside viewbox)
                                Dim oPageInPixels As RectangleF = New RectangleF(0, 0, sImageWidth, sImageHeight)
                                Dim oPageInMeters As RectangleF = New RectangleF(0, 0, sImageWidth, sImageHeight)
                                oPageInMeters = modPaint.FullScaleRectangle(oPageInMeters, 1 / sPaintZoom)
                                oPageInMeters = New RectangleF(oPageInMeters.X - oPaintTranslation.X / sPaintZoom, oPageInMeters.Y - oPaintTranslation.Y / sPaintZoom, oPageInMeters.Width, oPageInMeters.Height)

                                Dim oSize As SizeF = New SizeF(sImageWidth, sImageHeight)
                                Dim iUnit As SizeUnit = pToSizeUnit(cboImageUM.SelectedIndex)

                                sLastFilename = .FileName

                                Dim oXML As XmlDocument
                                Dim oSVGOptions As cSurvey.Design.cItem.SVGOptionsEnum
                                If cEditDesignEnvironment.GetSetting("svg.exporttextaspath", 0) <> 0 Then
                                    oSVGOptions = oSVGOptions Or cSurvey.Design.cItem.SVGOptionsEnum.TextAsPath
                                End If
                                If cEditDesignEnvironment.GetSetting("svg.exportcsurveyreferences", 1) <> 0 Then
                                    oSVGOptions = oSVGOptions Or cSurvey.Design.cItem.SVGOptionsEnum.AddSourceReference
                                End If
                                If cEditDesignEnvironment.GetSetting("svg.exportimages", 1) <> 0 Then
                                    oSVGOptions = oSVGOptions Or cSurvey.Design.cItem.SVGOptionsEnum.Images
                                End If
                                If cEditDesignEnvironment.GetSetting("svg.exportnoclipping", 0) = 0 Then
                                    oSVGOptions = oSVGOptions Or cSurvey.Design.cItem.SVGOptionsEnum.Clipping
                                End If
                                If cEditDesignEnvironment.GetSetting("svg.exportnoclipartbrushes", 0) = 0 Then
                                    oSVGOptions = oSVGOptions Or cSurvey.Design.cItem.SVGOptionsEnum.ClipartBrushes
                                End If

                                If oCurrentProfile.Design = cIDesign.cDesignTypeEnum.Plan Then
                                    oXML = oSurvey.Plan.ToSvg(oOptions, oSVGOptions, oSize, oPageInPixels, iUnit, oPageInMeters)
                                Else
                                    oXML = oSurvey.Profile.ToSvg(oOptions, oSVGOptions, oSize, oPageInPixels, iUnit, oPageInMeters)
                                End If

                                'Call XMLAddDeclaration(oXML)

                                Dim oXMLWriterSettings As XmlWriterSettings = New XmlWriterSettings
                                oXMLWriterSettings.Indent = False
                                oXMLWriterSettings.Encoding = System.Text.Encoding.UTF8
                                Using oXMLWriter As XmlWriter = XmlWriter.Create(.FileName, oXMLWriterSettings)
                                    Call oXML.Save(oXMLWriter)
                                End Using
                                'Call oXML.Save(.FileName)

                                Call oMousePointer.Pop()
                        End Select
                    End If
            End With
        End Using
    End Sub

    Private Sub cboFileFormat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFileFormat.SelectedIndexChanged
        Select Case cboFileFormat.SelectedIndex
            Case 2
                chkBackgroundTransparent.Enabled = True
                chkExportGPS.Enabled = True
                Call chkExportGPS_CheckedChanged(Nothing, Nothing)

                pnlExportOptionsPage.Visible = False
                pnlExportOptionsSize.Visible = True
                pnlExportOptionsOther.Visible = True

                cboImageUM.SelectedItem = 0
                cboImageUM.Enabled = False
                txtImageDPI.Enabled = modMain.Is64Bit OrElse modMain.bIsInDebug
            Case 0, 1, 3
                chkBackgroundTransparent.Enabled = False
                chkExportGPS.Enabled = True
                Call chkExportGPS_CheckedChanged(Nothing, Nothing)

                pnlExportOptionsPage.Visible = False
                pnlExportOptionsSize.Visible = True
                pnlExportOptionsOther.Visible = True

                cboImageUM.SelectedItem = 0
                cboImageUM.Enabled = False
                txtImageDPI.Enabled = modMain.Is64Bit OrElse modMain.bIsInDebug
            Case 4
                chkBackgroundTransparent.Enabled = False
                chkExportGPS.Enabled = False
                Call chkExportGPS_CheckedChanged(Nothing, Nothing)

                pnlExportOptionsPage.Visible = True
                pnlExportOptionsSize.Visible = True
                pnlExportOptionsOther.Visible = False

                cboImageUM.Enabled = True
                txtImageDPI.Enabled = False
        End Select
        'Call pRefresh()
    End Sub

    Private Sub btnZoomToFit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnZoomToFit.ItemClick
        Call pZoomToFit()
    End Sub

    Private Sub pZoomToFit()
        If Not oCurrentProfile Is Nothing Then
            Select Case iMode
                Case PreviewModeEnum.Preview
                    Dim iWidth As Integer = pPreview.Document.DefaultPageSettings.Bounds.Width
                    Dim iHeight As Integer = pPreview.Document.DefaultPageSettings.Bounds.Height
                    If iWidth > iHeight Then
                        sViewZoom = iWidth / pPreview.Width
                    Else
                        sViewZoom = iHeight / pPreview.Height
                    End If

                    'sViewZoom = 1
                    sViewZoom = 1 / sViewZoom
                    pPreview.Zoom = sViewZoom
                Case PreviewModeEnum.Export
                    If pnlExport.Width > pnlExport.Height Then
                        sViewZoom = pnlExport.Width / picExport.Image.Width
                    Else
                        sViewZoom = pnlExport.Height / picExport.Image.Height
                    End If
                    sViewZoom = sViewZoom * 0.85
                    picExport.Size = New Size(picExport.Image.Width * sViewZoom, picExport.Image.Height * sViewZoom)
                    oPaintTranslation = New Point((pnlExport.Width - picExport.Width) / 2, (pnlExport.Height - picExport.Height) / 2)
                    picExport.Location = New Point(oPaintTranslation.X, oPaintTranslation.Y)
                    Call pnlExport.Invalidate()
                Case PreviewModeEnum.Viewer
                    Call pMapCenterAndFit()
            End Select
        End If
    End Sub

    Private Sub picExport_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picExport.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            oStartPaintDrawPosition = New PointF(e.X, e.Y)
        End If
    End Sub

    Private Sub picExport_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picExport.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            oPaintTranslation = New PointF(e.X - oStartPaintDrawPosition.X, e.Y - oStartPaintDrawPosition.Y)
            picExport.Location = New Point(picExport.Location.X + oPaintTranslation.X, picExport.Location.Y + oPaintTranslation.Y)
            Call pnlExport.Invalidate()
            'oStartPaintDrawPosition = picExport.Location
        End If
    End Sub

    Private Sub picExport_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picExport.MouseWheel
        Dim iVal As Integer = e.Delta / 120
        Dim iAbs As Integer = Math.Abs(iVal)
        Dim iSegno As Integer = iVal / iAbs
        If (iAbs < 20) AndAlso (((iSegno > 0) AndAlso (sViewZoom > 0.1F)) OrElse ((iSegno < 0) AndAlso (sViewZoom < 100.0F))) Then
            For j As Integer = 1 To iAbs
                If iSegno > 0 Then
                    sViewZoom *= 1.1F
                Else
                    sViewZoom /= 1.1F
                End If
            Next
            picExport.Size = New Size(picExport.Image.Width * sViewZoom, picExport.Image.Height * sViewZoom)
            Call pnlExport.Invalidate()
        End If
    End Sub

    Private Sub btnInfoBoxDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfoBoxDetails.Click
        Dim sUnitText As String
        If iMode = PreviewModeEnum.Export Then
            sUnitText = "pixel"
        Else
            sUnitText = "mm"
        End If
        Dim oParameters As frmParametersInfoBox = New frmParametersInfoBox(oCurrentOptions, sUnitText)
        pnlParameters.Controls.Add(oParameters)
        flyParameters.Size = oParameters.Size
        oParameters.Dock = DockStyle.Fill
        flyParameters.OwnerControl = btnInfoBoxDetails
        flyParameters.ShowBeakForm(True)
    End Sub

    Private Sub btnScaleDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScaleDetails.Click
        Dim oParameters As frmParametersScale = New frmParametersScale(oCurrentOptions)
        pnlParameters.Controls.Add(oParameters)
        flyParameters.Size = oParameters.Size
        oParameters.Dock = DockStyle.Fill
        flyParameters.OwnerControl = btnScaleDetails
        flyParameters.ShowBeakForm(True)

        'If frmPS Is Nothing Then
        '    frmPS = New frmParametersScale(oCurrentOptions)
        '    frmPS.Show(Me)
        'Else
        '    If Not frmPS.Visible Then frmPS.Show(Me)
        '    Call frmPS.BringToFront()
        'End If
    End Sub

    Private Sub btnCompassDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompassDetails.Click
        'If frmPC Is Nothing Then
        '    frmPC = New frmParametersCompass(oCurrentOptions)
        '    Call frmPC.Show(Me)
        'Else
        '    If Not frmPC.Visible Then frmPC.Show(Me)
        '    Call frmPC.BringToFront()
        'End If
        Dim oParameters As frmParametersCompass = New frmParametersCompass(oCurrentOptions)
        pnlParameters.Controls.Add(oParameters)
        flyParameters.Size = oParameters.Size
        oParameters.Dock = DockStyle.Fill
        flyParameters.OwnerControl = btnCompassDetails
        flyParameters.ShowBeakForm(True)
    End Sub

    'Private Sub frmPIB_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles frmPIB.FormClosed
    '    frmPIB = Nothing
    'End Sub

    'Private Sub frmPIB_OnChangeOptions(ByVal Sender As Object, ByVal InfoBoxOptions As cSurveyPC.cSurvey.Design.cOptions) Handles frmPIB.OnChangeOptions
    '    Call pRefresh()
    'End Sub

    'Private Sub frmPC_Disposed(sender As Object, e As EventArgs) Handles frmPC.Disposed
    '    frmPC = Nothing
    'End Sub

    'Private Sub frmPC_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles frmPC.FormClosed
    '    frmPC = Nothing
    'End Sub

    'Private Sub frmPC_OnChangeOptions(ByVal Sender As Object, ByVal CompassOptions As cSurveyPC.cSurvey.Design.cOptions) Handles frmPC.OnChangeOptions
    '    Call pRefresh()
    'End Sub

    'Private Sub frmPS_Disposed(sender As Object, e As EventArgs) Handles frmPS.Disposed
    '    frmPS = Nothing
    'End Sub

    'Private Sub frmPS_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles frmPS.FormClosed
    '    frmPS = Nothing
    'End Sub

    'Private Sub frmPS_OnChangeOptions(ByVal Sender As Object, ByVal Options As cSurvey.Design.cOptions) Handles frmPS.OnChangeOptions
    '    Call pRefresh()
    'End Sub

    Private Sub frmPreview_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call pDrawingStop(True)

        Call pOptionsSave()
        oSurvey = Nothing

        'If Not frmPIB Is Nothing Then If Not frmPIB.IsDisposed Then Call frmPIB.Close()
        'If Not frmPC Is Nothing Then If Not frmPC.IsDisposed Then Call frmPC.Close()
        'If Not frmPS Is Nothing Then If Not frmPS.IsDisposed Then Call frmPS.Close()
        'If Not frmPD Is Nothing Then If Not frmPD.IsDisposed Then Call frmPD.Close()
        'If Not frmSD Is Nothing Then If Not frmSD.IsDisposed Then Call frmSD.Close()
        'If Not frmT Is Nothing Then If Not frmT.IsDisposed Then Call frmT.Close()
        'If Not frmZ Is Nothing Then If Not frmZ.IsDisposed Then Call frmZ.Close()
    End Sub

    Private Sub chkPrintDesignSpecialPoint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintDesignSpecialPoint.CheckedChanged
        If chkPrintDesignSpecialPoint.Checked Then
            chkPrintCentreline.Checked = False
        End If
        Call pRefresh()
    End Sub

    Private Sub txtImageHeight_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImageHeight.Leave
        Call pRefresh()
    End Sub

    Private Sub chkExportGPS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExportGPS.CheckedChanged
        Dim bEnabled As Boolean = chkExportGPS.Checked And chkExportGPS.Enabled
        lblGPSData.Enabled = bEnabled
        cboGPSData.Enabled = bEnabled
        Call pRefresh()
    End Sub

    Private Sub chkBackgroundTransparent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBackgroundTransparent.CheckedChanged
        Call pRefresh()
    End Sub

    Private Sub cmdSetImageMargins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetImageMargins.Click
        Dim oOptions As cSurvey.Design.cOptionsExport = oCurrentOptions
        Dim oParameters As frmPreviewMargins = New frmPreviewMargins(oOptions.Margins, cboImageUM.Text)
        pnlParameters.Controls.Add(oParameters)
        flyParameters.Size = oParameters.Size
        oParameters.Dock = DockStyle.Fill
        flyParameters.OwnerControl = cmdSetImageMargins
        flyParameters.ShowBeakForm(True)

        'Using frmPM As frmPreviewMargins = New frmPreviewMargins(cboImageUM.Text)
        '    With frmPM
        '        .Margins = oOptions.Margins.Clone
        '        If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        '            oOptions.Margins = .Margins.Clone
        '            Call pRefresh()
        '        End If
        '    End With
        'End Using
    End Sub

    Private Sub cboPrintDesignStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrintDesignStyle.SelectedIndexChanged
        Dim iDesignStyle As cSurvey.Design.cOptionsCenterline.DesignStyleEnum = cboPrintDesignStyle.SelectedIndex
        Select Case iDesignStyle
            Case cSurvey.Design.cOptionsCenterline.DesignStyleEnum.Areas, cSurvey.Design.cOptionsCenterline.DesignStyleEnum.Combined
                lblPrintCombineColorMode.Enabled = True
                cboPrintCombineColorMode.Enabled = True
                chkPrintCombineColorGray.Enabled = True
            Case Else
                lblPrintCombineColorMode.Enabled = False
                cboPrintCombineColorMode.Enabled = False
                chkPrintCombineColorGray.Enabled = False
        End Select
        Call pRefresh()
    End Sub

    Private Sub frmParametersTranslations(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTranslationsDetails.Click
        Dim iApplyTo As cSurvey.Design.cIDesign.cDesignTypeEnum
        If oCurrentProfile.Design = cIDesign.cDesignTypeEnum.Plan Then
            iApplyTo = cSurvey.Design.cIDesign.cDesignTypeEnum.Plan
        Else
            iApplyTo = cSurvey.Design.cIDesign.cDesignTypeEnum.Profile
        End If
        Dim oParameters As frmParametersTranslations = New frmParametersTranslations(oCurrentOptions.TranslationsOptions, iApplyTo)
        pnlParameters.Controls.Add(oParameters)
        flyParameters.Size = oParameters.Size
        oParameters.Dock = DockStyle.Fill
        flyParameters.OwnerControl = btnTranslationsDetails
        flyParameters.ShowBeakForm(True)

        'Dim iApplyTo As cSurvey.Design.cIDesign.cDesignTypeEnum
        'If frmT Is Nothing Then
        '    If oCurrentProfile.Design = cIDesign.cDesignTypeEnum.Plan Then
        '        iApplyTo = cSurvey.Design.cIDesign.cDesignTypeEnum.Plan
        '    Else
        '        iApplyTo = cSurvey.Design.cIDesign.cDesignTypeEnum.Profile
        '    End If
        '    frmT = New frmParametersTranslations(oCurrentOptions, iApplyTo)
        '    Call frmT.Show(Me)
        'Else
        '    If Not frmT.Visible Then frmT.Show(Me)
        '    Call frmT.BringToFront()
        'End If
    End Sub

    'Private Sub frmZ_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles frmZ.FormClosed
    '    frmZ = Nothing
    'End Sub

    'Private Sub frmZ_Disposed(sender As Object, e As EventArgs) Handles frmZ.Disposed
    '    frmZ = Nothing
    'End Sub

    Private Sub chkTranslations_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTranslations.CheckedChanged
        btnTranslationsDetails.Enabled = chkTranslations.Checked
        Call pRefresh()
    End Sub

    Private Sub btnDesignGraphics0_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles btnDesignGraphics0.CheckedChanged
        Call pSettingsSetDesignQuality(frmMain2.DesignQualityLevelEnum.Base)
    End Sub

    Private Sub btnDesignGraphics1_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles btnDesignGraphics1.CheckedChanged
        Call pSettingsSetDesignQuality(frmMain2.DesignQualityLevelEnum.MediumQuality)
    End Sub

    Private Sub btnDesignGraphics2_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles btnDesignGraphics2.CheckedChanged
        Call pSettingsSetDesignQuality(frmMain2.DesignQualityLevelEnum.HighQuality)
    End Sub

    Private Sub pSettingsSetDesignQuality(ByVal Quality As frmMain2.DesignQualityLevelEnum, Optional ByVal ForceSetting As Boolean = False)
        If Not bEventDisabled Then
            If Quality <> iDesignQuality OrElse ForceSetting Then
                iDesignQuality = Quality
                Call oSurvey.SharedSettings.SetValue("preview.designquality", iDesignQuality.ToString("D"))
                Call pRefresh()
            End If
        End If
    End Sub

    Private Sub pExport_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlExport.Paint
        Dim oGr As Graphics = e.Graphics
        oGr.InterpolationMode = InterpolationMode.HighQualityBicubic
        oGr.SmoothingMode = SmoothingMode.AntiAlias
        Call oGr.Clear(Color.White)
        Dim oRect As Rectangle = picExport.Bounds
        Call oRect.Inflate(3, 3)
        Call oGr.FillRectangle(Brushes.Gray, oRect)
    End Sub

    'Private Sub frmPreview_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    '    If e.KeyCode = Keys.F5 Then
    '        If bFirstRendering Then bFirstRendering = False
    '        Call pRefresh(True, False)
    '    End If
    'End Sub

    Private Sub frmPreview_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            Call pZoomToFit()
        End If
    End Sub

    Private Sub oSurvey_OnBeforePropertiesChange(Sender As cSurvey.cSurvey, Args As cSurvey.cSurvey.OnPropertiesChangedEventArgs) Handles oSurvey.OnBeforePropertiesChange
        Call oMousePointer.Push(Cursors.WaitCursor)
    End Sub

    Private Sub oSurvey_OnProgress(ByVal Sender As cSurvey.cSurvey, ByVal Args As cSurvey.cSurvey.OnProgressEventArgs) Handles oSurvey.OnProgress
        Call pStatusProgress(Args.Progress, Args.Text)
    End Sub

    Private Delegate Sub pStatusProgressDelegate(Percent As Single, Text As String)

    Private Sub pStatusProgress(ByVal Percent As Single, Optional ByVal Text As String = "")
        Try
            If InvokeRequired Then
                Call Me.BeginInvoke(New pStatusProgressDelegate(AddressOf pStatusProgress), {Percent, Text})
            Else
                If Percent >= 1 Or Percent <= 0 Then
                    pnlStatusProgress.Visibility = BarItemVisibility.Never
                    'trkZoom.Visible = pnlStatusDesignZoom.Visible
                Else
                    pnlStatusProgress.Visibility = BarItemVisibility.Always
                    pnlStatusProgress.EditValue = Percent * 100
                    Text = Text & " " & Strings.Format(Percent, "percent")
                End If
                Call pStatusSet(Text)
            End If
        Catch
        End Try
    End Sub

    Private Sub pStatusSet(ByVal Text As String)
        pnlStatusText.Caption = Text
        pnlStatusText.Refresh()
    End Sub

    Private Sub btnManualRefresh_CheckedChanged(sender As Object, e As System.EventArgs) Handles btnManualRefresh.CheckedChanged
        If Not bEventDisabled Then
            bManualRefresh = btnManualRefresh.Checked
            Call oSurvey.SharedSettings.SetValue("preview.manualrefresh", If(bManualRefresh, "1", "0"))
            If Not bManualRefresh AndAlso cDesignMessageCorner.Visible Then
                Call pRefresh(True)
            End If
        End If
    End Sub

    Private Sub cmdScaleTools_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScaleTools.Click
        Dim oOptions As cSurvey.Design.cOptions = oCurrentOptions
        Dim oDesign As cSurvey.Design.cDesign
        If oCurrentProfile.Design = cIDesign.cDesignTypeEnum.Plan Then
            oDesign = oSurvey.Plan
        Else
            oDesign = oSurvey.Profile
        End If

        Dim iScale As Integer
        If cboScale.SelectedIndex = 0 Then
            iScale = 250
        Else
            If cboScale.SelectedIndex = cboScale.Properties.Items.Count - 1 Then
                iScale = txtScaleManual.Value
            Else
                Dim sFactor As String = cboScale.Text
                If sFactor = "" Then
                    iScale = 250
                Else
                    iScale = sFactor.Substring(sFactor.IndexOf(":") + 1)
                End If
            End If
        End If

        Dim frmST As frmScaleTools
        If iMode = PreviewModeEnum.Export Then
            Dim oGr As Graphics = Graphics.FromImage(picExport.Image)
            frmST = New frmScaleTools(oSurvey, oDesign, oOptions, iScale, oGr)
        Else
            frmST = New frmScaleTools(oSurvey, oDesign, oOptions, iScale, cboPrinter.Text)
        End If
        If frmST.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub chkPrintDesignAdvancedBrushes_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkPrintDesignAdvancedBrushes.CheckedChanged
        Call pRefresh()
    End Sub

    Private Sub pExportToFile()
        Dim oSFD As SaveFileDialog = New SaveFileDialog
        With oSFD
            .Title = GetLocalizedString("preview.exportsettingsdialog")
            .Filter = GetLocalizedString("preview.filetypeOPX") & " (*.OPX)|*.OPX|" & GetLocalizedString("preview.filetypeALL") & " (*.*)|*.*"
            .FilterIndex = 1
            .DefaultExt = "opx"
            .AddExtension = True
            .CheckPathExists = True
            .FileName = oCurrentProfile.Name
            .AddExtension = True
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim oXML As XmlDocument = New XmlDocument
                Dim oXMLRoot As XmlElement = oXML.CreateElement("options")
                Call oXMLRoot.SetAttribute("name", oCurrentProfile.Name)
                Call oCurrentOptions.SaveTo(Nothing, oXML, oXMLRoot)
                Call oXML.AppendChild(oXMLRoot)
                Call oXML.Save(.FileName)
            End If
        End With
    End Sub

    Private Sub pImportFromFile()
        Dim oOFD As OpenFileDialog = New OpenFileDialog
        With oOFD
            .Title = GetLocalizedString("preview.importsettingsdialog")
            .Filter = GetLocalizedString("preview.filetypeOPX") & " (*.OPX)|*.OPX|" & GetLocalizedString("preview.filetypeALL") & " (*.*)|*.*"
            .FilterIndex = 1
            .DefaultExt = "opx"
            .AddExtension = True
            .CheckPathExists = True
            If .ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim oXML As XmlDocument = New XmlDocument
                Call oXML.Load(.FileName)
                Dim oXMLRoot As XmlElement = oXML.Item("options")
                Call pProfileAdd(oXMLRoot.GetAttribute("name"))
                Call pProfileSelect(NavBarControl1.SelectedLink.Item.Tag)
                Call oCurrentOptions.Import(oXMLRoot.ChildNodes(0))
                Call pOptionsRestore()
            End If
        End With
    End Sub

    'Private Sub btnImportSettings_DropDownOpening(sender As Object, e As System.EventArgs) Handles btnImportSettings.DropDownOpening
    '    If iMode = PreviewModeEnum.Export Then
    '        btnImportSettings0.Visible = True
    '        btnImportSettings1.Visible = False
    '    Else
    '        btnImportSettings0.Visible = False
    '        btnImportSettings1.Visible = True
    '    End If
    '    If oCurrentProfile.Design = cIDesign.cDesignTypeEnum.Plan Then
    '        btnImportSettings4.Visible = False
    '        btnImportSettings5.Visible = True
    '    Else
    '        btnImportSettings4.Visible = True
    '        btnImportSettings5.Visible = False
    '    End If
    'End Sub

    'Private Sub btnImportSettings4_Click(sender As System.Object, e As System.EventArgs) Handles btnImportSettings4.Click
    '    If MsgBox("Importare le impostazioni della pianta?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Attenzione:") = MsgBoxResult.Yes Then
    '        Dim oXML As XmlDocument = New XmlDocument
    '        Dim oXMLRoot As XmlElement = oXML.CreateElement("root")
    '        If iMode = PreviewModeEnum.Export Then
    '            Call oCurrentOptions.Import(oSurvey.Options("_export.plan").SaveTo(Nothing, oXML, oXMLRoot))
    '        Else
    '            Call oCurrentOptions.Import(oSurvey.Options("_preview.plan").SaveTo(Nothing, oXML, oXMLRoot))
    '        End If
    '        Call pOptionsRestore()
    '    End If
    'End Sub

    'Private Sub btnImportSettings5_Click(sender As System.Object, e As System.EventArgs) Handles btnImportSettings5.Click
    '    If MsgBox("Importare le impostazioni della sezione?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Attenzione:") = MsgBoxResult.Yes Then
    '        Dim oXML As XmlDocument = New XmlDocument
    '        Dim oXMLRoot As XmlElement = oXML.CreateElement("root")
    '        If iMode = PreviewModeEnum.Export Then
    '            Call oCurrentOptions.Import(oSurvey.Options("_export.profile").SaveTo(Nothing, oXML, oXMLRoot))
    '        Else
    '            Call oCurrentOptions.Import(oSurvey.Options("_preview.profile").SaveTo(Nothing, oXML, oXMLRoot))
    '        End If
    '        Call pOptionsRestore()
    '    End If
    'End Sub

    'Private Sub btnImportSettings0_Click(sender As System.Object, e As System.EventArgs) Handles btnImportSettings0.Click
    '    If MsgBox("Importare le impostazioni dell'anteprima di stampa?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Attenzione:") = MsgBoxResult.Yes Then
    '        Dim oXML As XmlDocument = New XmlDocument
    '        Dim oXMLRoot As XmlElement = oXML.CreateElement("root")
    '        If oCurrentProfile.Design = cIDesign.cDesignTypeEnum.Plan Then
    '            Call oCurrentOptions.Import(oSurvey.Options("_preview.plan").SaveTo(Nothing, oXML, oXMLRoot))
    '        Else
    '            Call oCurrentOptions.Import(oSurvey.Options("_preview.profile").SaveTo(Nothing, oXML, oXMLRoot))
    '        End If
    '        Call pOptionsRestore()
    '    End If
    'End Sub

    'Private Sub btnImportSettings1_Click(sender As System.Object, e As System.EventArgs) Handles btnImportSettings1.Click
    '    If MsgBox("Importare le impostazioni dell'esportazione come immagine?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Attenzione:") = MsgBoxResult.Yes Then
    '        Dim oXML As XmlDocument = New XmlDocument
    '        Dim oXMLRoot As XmlElement = oXML.CreateElement("root")
    '        If oCurrentProfile.Design = cIDesign.cDesignTypeEnum.Plan Then
    '            Call oCurrentOptions.Import(oSurvey.Options("_export.plan").SaveTo(Nothing, oXML, oXMLRoot))
    '        Else
    '            Call oCurrentOptions.Import(oSurvey.Options("_export.profile").SaveTo(Nothing, oXML, oXMLRoot))
    '        End If
    '        Call pOptionsRestore()
    '    End If
    'End Sub

    Private Sub cmdManageProfile_Click(sender As System.Object, e As System.EventArgs) Handles cmdManageProfile.Click
        Using frmCVM = New frmCaveVisibilityManager(oSurvey, oSurvey.Properties.CaveVisibilityProfiles, txtCurrentProfile.Text)
            AddHandler frmCVM.OnChangeVisibility, AddressOf frmCVM_OnChangeVisibility
            Call frmCVM.ShowDialog()
            RemoveHandler frmCVM.OnChangeVisibility, AddressOf frmCVM_OnChangeVisibility
        End Using
        'If frmCVM.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    txtCurrentProfile.Text = frmCVM.cboProfiles.Text
        '    Call pRefresh()
        'End If
    End Sub

    Private Sub frmCVM_OnChangeVisibility(Sender As Object, CaveVisibilityProfiles As cSurvey.cCaveVisibilityProfiles, CurrentProfile As String)
        Call oSurvey.Properties.CaveVisibilityProfiles.CopyFrom(CaveVisibilityProfiles)
        txtCurrentProfile.Text = CurrentProfile
        Call pRefresh()
    End Sub

    Private Sub pProfileSelect(Item As cIProfile, Optional ForceRefresh As Boolean = False, Optional FirstRefresh As Boolean = False)
        If oCurrentProfile IsNot Item Then
            bEventDisabled = True
            oCurrentProfile = Item
            oCurrentOptions = oCurrentProfile.Options

            If oCurrentProfile.IsSystem Then
                btnProfilesDelete.Enabled = False
            Else
                btnProfilesDelete.Enabled = True
            End If

            Call pOptionsRestore()

            bEventDisabled = False
            bFirstRendering = True

            Call pRefresh(ForceRefresh, FirstRefresh)
            Call pZoomToFit()
        End If
    End Sub

    Private Function pGetCurrentItem() As NavBarItem
        For Each oItem As NavBarItem In NavBarControl1.Items
            If oItem.Tag Is oCurrentProfile Then
                Return oItem
            End If
        Next
        Return Nothing
    End Function

    Private Sub lv_AfterLabelEdit(sender As Object, e As LabelEditEventArgs)
        oCurrentProfile.Name = e.Label
    End Sub

    Private Sub lv_BeforeLabelEdit(sender As Object, e As LabelEditEventArgs)
        If iMode = PreviewModeEnum.Viewer Then
            e.CancelEdit = True
        Else
            e.CancelEdit = oCurrentProfile.IsSystem
        End If
    End Sub

    Private Sub pProfileAdd(Optional Name As String = "")
        Dim sName As String = Name
        If sName = "" Then
            Do
                sName = DevExpress.XtraEditors.XtraInputBox.Show(GetLocalizedString("preview.addprofile"), GetLocalizedString("preview.addprofiletitle"), "")
                'sName = InputBox(GetLocalizedString("preview.addprofile"), GetLocalizedString("preview.addprofiletitle"), "")
                sName = sName.Trim
            Loop Until Not sName.StartsWith("_")
        End If
        If sName <> "" Then
            Select Case iMode
                Case PreviewModeEnum.Export
                    bEventDisabled = True
                    Dim oNewProfile As cExportProfile = oSurvey.ExportProfiles.AddAsCopy(oCurrentProfile, sName)
                    Dim oLink As DevExpress.XtraNavBar.NavBarItemLink = grpMain.AddItem
                    oLink.Item.Caption = oNewProfile.Name
                    oLink.Item.ImageOptions.SvgImage = My.Resources.documentexport
                    oLink.Item.Tag = oNewProfile
                    If oNewProfile.IsSystem Then
                        oLink.Item.Caption = "<b>" & oLink.Item.Caption & "</b>"
                    Else
                        oLink.Item.Caption = oNewProfile.Name
                    End If
                    bEventDisabled = False
                    Call pProfileSelect(oNewProfile, True, True)
                Case PreviewModeEnum.Preview
                    bEventDisabled = True
                    Dim oNewProfile As cPreviewProfile = oSurvey.PreviewProfiles.AddAsCopy(oCurrentProfile, sName)
                    Dim oLink As DevExpress.XtraNavBar.NavBarItemLink = grpMain.AddItem
                    oLink.Item.Caption = oNewProfile.Name
                    oLink.Item.ImageOptions.SvgImage = My.Resources.documentprint
                    oLink.Item.Tag = oNewProfile
                    If oNewProfile.IsSystem Then
                        oLink.Item.Caption = "<b>" & oLink.Item.Caption & "</b>"
                    Else
                        oLink.Item.Caption = oNewProfile.Name
                    End If
                    bEventDisabled = False
                    NavBarControl1.SelectedLink = oLink
                    Call pProfileSelect(oNewProfile, True, True)
            End Select
        End If
    End Sub

    Private Sub pProfileDelete()
        If MsgBox(String.Format(GetLocalizedString("preview.warning4"), oCurrentProfile.Name), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, GetLocalizedString("preview.warningtitle")) = MsgBoxResult.Yes Then
            Dim oItem As NavBarItem = pGetCurrentItem()
            NavBarControl1.Items.Remove(oItem)
            Select Case iMode
                Case PreviewModeEnum.Export
                    Call oSurvey.ExportProfiles.Remove(oCurrentProfile)
                Case PreviewModeEnum.Preview
                    Call oSurvey.PreviewProfiles.Remove(oCurrentProfile)
            End Select
        End If
    End Sub

    Private Sub pScaleUpdate()
        Dim iScale As Integer = oCurrentOptions.GetCurrentScale
        If iScale = 0 Then
            pnlStatusCurrentRule.Caption = GetLocalizedString("preview.textpart4")
        Else
            pnlStatusCurrentRule.Caption = String.Format(GetLocalizedString("preview.textpart5"), Strings.Format(iScale, "#,##0"))
        End If
    End Sub

    Private Sub oSurvey_OnPropertiesChanged(Sender As cSurvey.cSurvey, Args As cSurvey.cSurvey.OnPropertiesChangedEventArgs) Handles oSurvey.OnPropertiesChanged
        If Args.Source = cSurvey.cSurvey.OnPropertiesChangedEventArgs.PropertiesChangeSourceEnum.Scale Then
            Call pScaleUpdate()
        End If
        Call oMousePointer.Pop()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs)
        Call pProfileDelete()
    End Sub

    'Private Sub frmZ_OnChangeOptions(Sender As Object, Options As cSurvey.Design.cOptions) Handles frmZ.OnChangeOptions
    '    Call pRefresh()
    'End Sub

    Private Sub btnZOrderDetails_Click(sender As System.Object, e As System.EventArgs) Handles btnZOrderDetails.Click
        Dim oParameters As frmParametersZOrder = New frmParametersZOrder(oCurrentOptions)
        pnlParameters.Controls.Add(oParameters)
        flyParameters.Size = oParameters.Size
        oParameters.Dock = DockStyle.Fill
        flyParameters.OwnerControl = btnZOrderDetails
        flyParameters.ShowBeakForm(True)
        'If frmZ Is Nothing Then
        '    frmZ = New frmParametersZOrder(oCurrentOptions)
        '    Call frmZ.Show(Me)
        'Else
        '    If Not frmZ.Visible Then frmZ.Show(Me)
        '    Call frmZ.BringToFront()
        'End If
    End Sub

    Private Sub chkUseDrawingZOrder_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkUseDrawingZOrder.CheckedChanged
        btnZOrderDetails.Enabled = chkUseDrawingZOrder.Checked
        Call pRefresh()
    End Sub

    Private Sub mnuLvContextAdd_Click(sender As System.Object, e As System.EventArgs)
        Call pProfileAdd()
    End Sub

    Private Sub mnuLvContextDelete_Click(sender As System.Object, e As System.EventArgs)
        Call pProfileDelete()
    End Sub

    Private Sub chkPrintSketch_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkPrintSketches.CheckedChanged
        Call pRefresh()
    End Sub

    Private Delegate Sub oDrawRefreshThread_callbackDelegate()

    Private Sub oDrawRefreshThread_callback()
        Try
            Call pSurveyDraw(picMap.CreateGraphics)
        Catch ex As Exception
            Call Debug.Print(ex.Message)
        End Try
    End Sub

    Private oDrawRefreshThread As Threading.Thread

    Private oPaintInfo(1) As frmMain2.sPaintInfo

    Private oOpenHandCursor As Cursor
    Private oClosedHandCursor As Cursor

    Private bDisableZoomEvent As Boolean
    Private bCenterOnShow As Boolean

    Private WithEvents oVSB As DevExpress.XtraEditors.VScrollBar
    Private WithEvents oHSB As DevExpress.XtraEditors.HScrollBar

    Private bDrawRulers As Boolean
    Private iDrawRulesStyle As frmMain2.RulersStyleEnum
    Private bDrawMetricGrid As Boolean

    Private bDrawing As Boolean

    Private bShowOptionsPanel As Boolean

    Private oRulerBackgroundBrush As SolidBrush
    Private oRulerUsedBackgroundBrush As SolidBrush
    Private oRulerCurrentBackgroundBrush As SolidBrush

    Private bMousePressed As Boolean

    Private sZoomDefault As Single = 500
    Private sZoomRatio As Single = 15

    Private iZoomType As frmMain2.ZoomTypeEnum = frmMain2.ZoomTypeEnum.ScaleFactor

    Private Enum MultiSelTypeEnum
        None = 0
        Zoom = 3
    End Enum

    Private iMultiSelEnabled As MultiSelTypeEnum
    Private oStartMultiselPosition As PointF
    Private oEndMultiselPosition As PointF

    Private Sub pSurveyDraw(ByVal Graphics As Graphics)
        If Not bDrawing Then
            bDrawing = True
            Call oMousePointer.Push(Cursors.AppStarting)

            Try
                Dim iWidth As Integer = picMap.Width - oVSB.Width
                Dim iHeight As Integer = picMap.Height - oHSB.Height

                If iDesignQuality = frmMain2.DesignQualityLevelEnum.Base Then
                    Graphics.CompositingQuality = CompositingQuality.HighSpeed
                    Graphics.SmoothingMode = SmoothingMode.HighSpeed
                    Graphics.InterpolationMode = InterpolationMode.Low
                    Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
                ElseIf iDesignQuality = frmMain2.DesignQualityLevelEnum.MediumQuality Then
                    Graphics.CompositingQuality = CompositingQuality.HighSpeed
                    Graphics.SmoothingMode = SmoothingMode.AntiAlias
                    Graphics.InterpolationMode = InterpolationMode.Default
                    Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
                Else
                    Graphics.CompositingQuality = CompositingQuality.HighQuality
                    Graphics.SmoothingMode = SmoothingMode.AntiAlias
                    Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
                    Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
                End If

                Using oMatrix As Matrix = New Matrix
                    Call oMatrix.Scale(sPaintZoom, sPaintZoom, MatrixOrder.Append)
                    Call oMatrix.Translate(oPaintTranslation.X, oPaintTranslation.Y, MatrixOrder.Append)
                    Graphics.Transform = oMatrix
                End Using

                Dim oCurrentDesign As cSurvey.Design.cDesign = pGetCurrentDesign()
                Dim oOptions As cSurvey.Design.cOptions = oCurrentOptions

                Call MapDrawPrintOrExportArea(Graphics, oCurrentOptions, oSurvey, oCurrentDesign, sPaintZoom)
                Call oCurrentDesign.Paint(Graphics, oOptions, cDrawOptions.Empty, oSelection)

                Graphics.SmoothingMode = SmoothingMode.None
                If bDrawRulers Then
                    Call modPaint.MapDrawRulers(Graphics, oCurrentOptions, oSurvey, oSelection, iDrawRulesStyle, sPaintZoom)
                End If

                Graphics.SmoothingMode = SmoothingMode.AntiAlias
                Graphics.ResetTransform()
            Catch ex As Exception
            End Try
            Call oMousePointer.Pop()

            bDrawing = False
            Call pHideStopButton()
        End If
    End Sub

    Private Delegate Sub pHideStopButtonDelegate()
    Private Sub pHideStopButton()
        If Not IsDisposed Then
            If Not bDrawing Then
                If InvokeRequired Then
                    Call Invoke(New pHideStopButtonDelegate(AddressOf pHideStopButton))
                Else
                    btnStop.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                End If
            End If
        End If
    End Sub

    Private Function pGetMultiSelRect() As RectangleF
        Dim sLeft As Single = oStartMultiselPosition.X
        Dim [sTop] As Single = oStartMultiselPosition.Y
        Dim sWidth As Single = oEndMultiselPosition.X - oStartMultiselPosition.X
        Dim sHeight As Single = oEndMultiselPosition.Y - oStartMultiselPosition.Y
        If sWidth < 0 Then
            sWidth = -1 * sWidth
            sLeft = sLeft - sWidth
        End If
        If sHeight < 0 Then
            sHeight = -1 * sHeight
            [sTop] = [sTop] - sHeight
        End If
        Return New RectangleF(sLeft, [sTop], sWidth, sHeight)
    End Function

    Private Sub oHSB_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles oHSB.Scroll
        oPaintTranslation = New PointF(-e.NewValue, oPaintTranslation.Y)
        Call pMapInvalidate()
    End Sub

    Private Sub oVSB_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles oVSB.Scroll
        oPaintTranslation = New PointF(oPaintTranslation.X, -e.NewValue)
        Call pMapInvalidate()
    End Sub

    Private Sub pMapInvalidate()
        Call pDrawingStop(True)
        Call picMap.Invalidate()
    End Sub

    Private Sub pMapBindScrollbars()
        Try
            Dim oSize As Size
            If oCurrentProfile.Design = cIDesign.cDesignTypeEnum.Plan Then
                oSize = oSurvey.Plan.GetBounds(oCurrentOptions).Size.ToSize
            Else
                oSize = oSurvey.Profile.GetBounds(oCurrentOptions).Size.ToSize
            End If
            Dim iWidth As Integer = oSize.Width * sPaintZoom * 2
            Dim iHeight As Integer = oSize.Height * sPaintZoom * 2

            oVSB.Minimum = -iHeight
            oVSB.Maximum = iHeight

            oHSB.Minimum = -iWidth
            oHSB.Maximum = iWidth

            oVSB.Value = -oPaintTranslation.Y
            oHSB.Value = -oPaintTranslation.X
        Catch
        End Try
    End Sub

    Private Sub picMap_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picMap.Paint
        Call pMapBindScrollbars()
        Call pDrawingStop(False)
        If Not bDrawing Then
            Call pDrawingStart()
        End If
    End Sub

    Private Sub pDrawingStart()
        Call pOptionsSave()
        Call pDrawingThreadStart()
    End Sub

    Private Sub pDrawingThreadStart()
        If oDrawRefreshThread Is Nothing Then
            oDrawRefreshThread = New Threading.Thread(AddressOf oDrawRefreshThread_callback)
            oDrawRefreshThread.Priority = Threading.ThreadPriority.Lowest
            btnStop.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            Call oDrawRefreshThread.Start()
        End If
    End Sub

    Private Sub pMapZoomOut()
        If trkZoom.Value - 20 >= trkZoom.Minimum Then
            trkZoom.Value -= 20
        End If
    End Sub

    Private Sub pMapZoomIn()
        If trkZoom.Value + 20 <= trkZoom.Maximum Then
            trkZoom.Value += 20
        End If
    End Sub

    Private Sub pMapCenterAndFit()
        Dim oBounds As RectangleF
        If oCurrentProfile.Design = cIDesign.cDesignTypeEnum.Plan Then
            oBounds = oSurvey.Plan.GetVisibleBounds(oCurrentOptions)
        Else
            oBounds = oSurvey.Profile.GetVisibleBounds(oCurrentOptions)
        End If
        Call pMapCenterAndFit(oBounds)
    End Sub

    Private Sub pMapCenterAndFit(ByVal Bounds As RectangleF)
        Try
            Dim iMapWidth As Integer = picMap.Width
            Dim iMapHeight As Integer = picMap.Height
            Dim sWidth As Single = Bounds.Width * 1.1
            Dim sHeight As Single = Bounds.Height * 1.1
            Dim sdX As Single = iMapWidth / sWidth
            Dim sdY As Single = iMapHeight / sHeight
            Dim sD As Single
            If sdY < sdX Then
                sD = sdY
            Else
                sD = sdX
            End If
            If Single.IsInfinity(sD) Then sD = 10

            Call pMapZoom(sD)

            Dim sX As Single = -Bounds.Left * sPaintZoom + 0 + (picMap.Width - (Bounds.Width * sPaintZoom)) / 2
            Dim sY As Single = -Bounds.Top * sPaintZoom + 0 + (picMap.Height - (Bounds.Height * sPaintZoom)) / 2
            oPaintTranslation = New PointF(sX, sY)
        Catch
        End Try

        Call pMapInvalidate()
    End Sub

    Private Sub pMapCenter()
        Try
            Dim oBounds As RectangleF
            If oCurrentProfile.Design = cIDesign.cDesignTypeEnum.Plan Then
                oBounds = oSurvey.Plan.GetBounds(oCurrentOptions)
            Else
                oBounds = oSurvey.Profile.GetBounds(oCurrentOptions)
            End If
            Dim sX As Single = -oBounds.Left * sPaintZoom + 0 + (picMap.Width - (oBounds.Width * sPaintZoom)) / 2
            Dim sY As Single = -oBounds.Top * sPaintZoom + 0 + (picMap.Height - (oBounds.Height * sPaintZoom)) / 2
            oPaintTranslation = New PointF(sX, sY)
        Catch
        End Try
        Call pMapInvalidate()
    End Sub

    Private Sub pMapZoom(ByVal Zoom As Single)
        If sPaintZoom <> Zoom Then
            Dim iNewZoomValue As Integer = Zoom * sZoomRatio
            If iNewZoomValue > trkZoom.Maximum Then
                iNewZoomValue = trkZoom.Maximum
                Zoom = iNewZoomValue / sZoomRatio
            End If
            If iNewZoomValue < trkZoom.Minimum Then
                iNewZoomValue = trkZoom.Minimum
                Zoom = iNewZoomValue / sZoomRatio
            End If

            bDisableZoomEvent = True

            Dim sOldPaintZoom As Single = sPaintZoom
            sPaintZoom = Zoom
            trkZoom.Value = iNewZoomValue

            Dim iScale As Integer = 250
            If Not oCurrentOptions Is Nothing Then
                Using oGr As Graphics = picMap.CreateGraphics
                    iScale = modPaint.GetScaleFactor(oGr, sPaintZoom)
                    oCurrentOptions.CurrentScale = iScale
                End Using
            End If

            Dim sZoomText As String = ""
            Select Case iZoomType
                Case frmMain2.ZoomTypeEnum.ScaleFactor
                    sZoomText = "1:" & modNumbers.MathRound(iScale, 0)
                Case frmMain2.ZoomTypeEnum.ZoomFactor
                    sZoomText = Strings.Format(sPaintZoom, "0.00 x")
            End Select
            pnlStatusDesignZoom.Caption = sZoomText

            Try
                Dim oCurrentTranslation As PointF = New PointF(oPaintTranslation.X * sPaintZoom / sOldPaintZoom, oPaintTranslation.Y * sPaintZoom / sOldPaintZoom)
                Dim sX As Single = (picMap.Width - picMap.Width * sPaintZoom / sOldPaintZoom) / 2
                Dim sY As Single = (picMap.Height - picMap.Height * sPaintZoom / sOldPaintZoom) / 2
                oPaintTranslation = New PointF(sX + oCurrentTranslation.X, sY + oCurrentTranslation.Y)
            Catch
            End Try

            bDisableZoomEvent = False

            Call pMapInvalidate()
        End If
    End Sub

    Private Sub trkZoom_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trkZoom.ValueChanged
        If Not bDisableZoomEvent Then
            Call pMapRepaint()
        End If
    End Sub

    Private Sub pMapRepaint(Optional ByVal ZoomCenter As Boolean = False)
        sZoomRatio = 1 / Math.Log(trkZoom.Value) * 50
        Call pMapZoom(trkZoom.Value / sZoomRatio)
        If ZoomCenter Then
            Call pMapCenter()
        End If
    End Sub

    Private Sub picMap_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseDown
        Try
            Call picMap.Focus()

            Dim bCtrl As Boolean = My.Computer.Keyboard.CtrlKeyDown
            Dim bShift As Boolean = My.Computer.Keyboard.ShiftKeyDown
            Dim bAlt As Boolean = My.Computer.Keyboard.AltKeyDown

            Call pMapSetCursor(bCtrl, bShift, bAlt, e.Button)

            bMousePressed = True

            Dim oPoint As PointF = New PointF(e.X, e.Y)
            Dim oMousePoint As PointF = modPaint.FromPaintPoint(oPoint, sPaintZoom, oPaintTranslation)

            Dim bInvalidate As Boolean = False
            If bShift Then
                If bCtrl Then
                    iMultiSelEnabled = MultiSelTypeEnum.Zoom
                    oStartMultiselPosition = oPoint
                    oEndMultiselPosition = oPoint
                Else
                    ''sto facendo una selezione multipla...
                    'If bAlt Then
                    '    iMultiSelEnabled = MultiSelTypeEnum.MultiLayer
                    'Else
                    '    iMultiSelEnabled = MultiSelTypeEnum.SingleLayer
                    'End If
                    'oStartMultiselPosition = oPoint
                    'oEndMultiselPosition = oPoint
                End If
                bInvalidate = True
            Else
                If bAlt Then
                    If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then

                    End If
                Else
                    If iMultiSelEnabled <> MultiSelTypeEnum.None Then
                        iMultiSelEnabled = MultiSelTypeEnum.None
                        bInvalidate = True
                    End If
                    If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
                        oStartPaintDrawPosition = New PointF(-oPaintTranslation.X + e.X, -oPaintTranslation.Y + e.Y)
                        bInvalidate = True
                    ElseIf (e.Button And Windows.Forms.MouseButtons.Right) = Windows.Forms.MouseButtons.Right Then
                    End If
                End If
            End If
            If bInvalidate Then
                Call pMapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub pMapSetCursor(ByVal Ctrl As Boolean, ByVal Shift As Boolean, ByVal Alt As Boolean, ByVal Button As MouseButtons)
        If Ctrl And Not Alt And Not Shift Then
            If (Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
                picMap.Cursor = oClosedHandCursor
            Else
                picMap.Cursor = oOpenHandCursor
            End If
        Else
            If Alt And Not Shift Then
                picMap.Cursor = Cursors.Default
            Else
                If Ctrl And Shift Then
                    picMap.Cursor = Cursors.Cross
                Else
                    picMap.Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub picMap_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseMove
        Try
            Dim bCtrl As Boolean = My.Computer.Keyboard.CtrlKeyDown
            Dim bShift As Boolean = My.Computer.Keyboard.ShiftKeyDown
            Dim bAlt As Boolean = My.Computer.Keyboard.AltKeyDown

            Call pMapSetCursor(bCtrl, bShift, bAlt, e.Button)

            If e.Button <> Windows.Forms.MouseButtons.None Then
                bMousePressed = True
            End If

            Dim oPoint As PointF = New PointF(e.X, e.Y)
            Dim oMousePoint As PointF = modPaint.FromPaintPoint(oPoint, sPaintZoom, oPaintTranslation)

            'pnlStatusDesignInfo.Text = "X: " & Strings.Format(oMousePoint.X, "0.00") & " m - Y: " & Strings.Format(oMousePoint.Y, "0.00") & " m"

            Dim bInvalidate As Boolean = False
            If iMultiSelEnabled <> MultiSelTypeEnum.None And bShift And (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
                If bCtrl Then
                    iMultiSelEnabled = MultiSelTypeEnum.Zoom
                    oEndMultiselPosition = oPoint
                Else
                    'If bAlt Then
                    '    iMultiSelEnabled = MultiSelTypeEnum.MultiLayer
                    'Else
                    '    iMultiSelEnabled = MultiSelTypeEnum.SingleLayer
                    'End If
                    'oEndMultiselPosition = oPoint
                End If
                bInvalidate = True
            Else
                If bAlt Then
                Else
                    If iMultiSelEnabled <> MultiSelTypeEnum.None Then
                        iMultiSelEnabled = MultiSelTypeEnum.None
                        bInvalidate = True
                    End If
                    If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
                        Dim oOldPaintTranslation As PointF = oPaintTranslation
                        oPaintTranslation = New PointF(e.X - oStartPaintDrawPosition.X, e.Y - oStartPaintDrawPosition.Y)
                        If oOldPaintTranslation <> oPaintTranslation Then
                            bInvalidate = True
                        End If
                    End If
                End If
            End If
            If bInvalidate Then
                Call pMapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub picMap_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseUp
        Dim bCtrl As Boolean = My.Computer.Keyboard.CtrlKeyDown
        Dim bShift As Boolean = My.Computer.Keyboard.ShiftKeyDown
        Dim bAlt As Boolean = My.Computer.Keyboard.AltKeyDown

        Call pMapSetCursor(bCtrl, bShift, bAlt, e.Button)

        bMousePressed = False

        Dim oPoint As PointF = New PointF(e.X, e.Y)
        Dim oMousePoint As PointF = modPaint.FromPaintPoint(oPoint, sPaintZoom, oPaintTranslation)

        Dim bInvalidate As Boolean = False
        If iMultiSelEnabled <> MultiSelTypeEnum.None And bShift And (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
            If bCtrl Then
                'zoom al rettangolo...
                Dim oZoomRect As RectangleF = pGetMultiSelRect()
                oZoomRect = modPaint.FromPaintRectangle(oZoomRect, sPaintZoom, oPaintTranslation)
                Call pMapCenterAndFit(oZoomRect)
                iMultiSelEnabled = MultiSelTypeEnum.None
            End If
            bInvalidate = True
        Else
            If bAlt Then
            Else
                If iMultiSelEnabled <> MultiSelTypeEnum.None Then
                    iMultiSelEnabled = MultiSelTypeEnum.None
                    bInvalidate = True
                End If
            End If
        End If
        If bInvalidate Then
            Call pMapInvalidate()
        End If
    End Sub

    Private Sub picMap_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseWheel
        Try
            Dim iDeltaIncrement As Integer
            If My.Computer.Keyboard.ShiftKeyDown Then
                iDeltaIncrement = trkZoom.Value / 2
            Else
                iDeltaIncrement = trkZoom.Value / 10
            End If
            If iDeltaIncrement = 0 Then iDeltaIncrement = 1
            Dim iDelta As Integer = If(e.Delta > 0, iDeltaIncrement, -iDeltaIncrement)
            If trkZoom.Value + iDelta > trkZoom.Maximum Then
                trkZoom.Value = trkZoom.Maximum
            ElseIf trkZoom.Value + iDelta < trkZoom.Minimum Then
                trkZoom.Value = trkZoom.Minimum
            Else
                trkZoom.Value = trkZoom.Value + iDelta
            End If
        Catch
        End Try
    End Sub

    Private Sub picMap_SizeChanged(sender As Object, e As System.EventArgs) Handles picMap.SizeChanged
        Call pMapInvalidate()
    End Sub

    Private Sub frmPreview_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        oRulerBackgroundBrush = New SolidBrush(Color.FromArgb(100, 230, 230, 230))
        oRulerUsedBackgroundBrush = New SolidBrush(Color.FromArgb(100, Color.LightBlue))
        oRulerCurrentBackgroundBrush = New SolidBrush(Color.FromArgb(100, Color.Blue))

        'trkZoom.Parent = Me
        'trkZoom.BringToFront()
        ''Call pZoomResize()
    End Sub

    Private Sub chkPrintCombineColorGray_CheckedChanged(sender As Object, e As EventArgs) Handles chkPrintCombineColorGray.CheckedChanged
        Call pRefresh()
    End Sub

    Private Sub cboPrintCombineColorMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPrintCombineColorMode.SelectedIndexChanged
        Call pRefresh()
    End Sub

    Friend Event OnPropertyChange(Sender As frmPreview)

    Private Sub frmProperties_OnApply(ByVal Sender As frmProperties)
        Call pRefresh()
        RaiseEvent OnPropertyChange(Me)
    End Sub

    Private Sub btnDesignDetails_Click(sender As Object, e As EventArgs) Handles btnDesignDetails.Click
        'If frmPD Is Nothing Then
        '    frmPD = New frmParametersDesign(oCurrentOptions)
        '    frmPD.Show(Me)
        'Else
        '    If Not frmPD.Visible Then frmPD.Show(Me)
        '    Call frmPD.BringToFront()
        'End If
        Dim oParameters As frmParametersDesign = New frmParametersDesign(oCurrentOptions)
        pnlParameters.Controls.Add(oParameters)
        flyParameters.Size = oParameters.Size
        oParameters.Dock = DockStyle.Fill
        flyParameters.OwnerControl = btnDesignDetails
        flyParameters.ShowBeakForm(True)
    End Sub

    'Private Sub frmPD_Disposed(sender As Object, e As EventArgs) Handles frmPD.Disposed
    '    frmPD = Nothing
    'End Sub

    'Private Sub frmPD_FormClosed(sender As Object, e As FormClosedEventArgs) Handles frmPD.FormClosed
    '    frmPD = Nothing
    'End Sub

    'Private Sub frmPD_OnChangeOptions(Sender As Object, Options As cSurvey.Design.cIOptionsPreview) Handles frmPD.OnChangeOptions
    '    Call pRefresh()
    'End Sub

    Private Sub btnSegmentDetails_Click(sender As Object, e As EventArgs) Handles btnSegmentDetails.Click
        Dim iApplyTo As cSurvey.Design.cIDesign.cDesignTypeEnum
        If oCurrentProfile.Design = cIDesign.cDesignTypeEnum.Plan Then
            iApplyTo = cSurvey.Design.cIDesign.cDesignTypeEnum.Plan
        Else
            iApplyTo = cSurvey.Design.cIDesign.cDesignTypeEnum.Profile
        End If
        Dim oParameters As frmParametersSegments = New frmParametersSegments(oCurrentOptions, iApplyTo)
        pnlParameters.Controls.Add(oParameters)
        flyParameters.Size = oParameters.Size
        oParameters.Dock = DockStyle.Fill
        flyParameters.OwnerControl = btnSegmentDetails
        flyParameters.ShowBeakForm(True) '(New Point(oRect.Right, oRect.Top + oRect.Height / 2), True)
        'Dim iApplyTo As cSurvey.Design.cIDesign.cDesignTypeEnum
        'If frmSD Is Nothing Then
        '    If oCurrentProfile.Design = cIDesign.cDesignTypeEnum.Plan Then
        '        iApplyTo = cSurvey.Design.cIDesign.cDesignTypeEnum.Plan
        '    Else
        '        iApplyTo = cSurvey.Design.cIDesign.cDesignTypeEnum.Profile
        '    End If
        '    frmSD = New frmParametersSegments(oCurrentOptions, iApplyTo)
        '    frmSD.Show(Me)
        'Else
        '    If Not frmSD.Visible Then frmPD.Show(Me)
        '    Call frmSD.BringToFront()
        'End If
    End Sub

    'Private Sub frmSD_Disposed(sender As Object, e As EventArgs) Handles frmSD.Disposed
    '    frmSD = Nothing
    'End Sub

    'Private Sub frmSD_FormClosed(sender As Object, e As FormClosedEventArgs) Handles frmSD.FormClosed
    '    frmSD = Nothing
    'End Sub
    'Private Sub frmSD_OnChangeOptions(Sender As Object, Options As cSurvey.Design.cOptions) Handles frmSD.OnChangeOptions
    '    Call pRefresh()
    'End Sub


    Private Sub pDrawingStop(Force As Boolean)
        If bDrawing OrElse Force Then
            Call pDrawingThreadStop()
            bDrawing = False
            btnStop.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If
    End Sub

    Private Sub pDrawingThreadStop()
        If Not oDrawRefreshThread Is Nothing Then
            If oDrawRefreshThread.ThreadState = Threading.ThreadState.Running Then
                Call oDrawRefreshThread.Abort()
                Call oSurvey.RaiseOnProgressEvent("", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Reset, "", 0)
            End If
            oDrawRefreshThread = Nothing
        End If
    End Sub

    Private Sub chkPrintSplay_CheckedChanged(sender As Object, e As EventArgs) Handles chkPrintSplay.CheckedChanged
        Call pRefresh()
    End Sub

    'Private Sub frmPreview_ResizeBegin(sender As Object, e As System.EventArgs) Handles Me.ResizeBegin
    '    trkZoom.Visible = False
    'End Sub

    'Private Sub frmPreview_ResizeEnd(sender As Object, e As System.EventArgs) Handles Me.ResizeEnd
    '    Call pZoomResize()
    '    'trkZoom.Visible = pnlStatusDesignZoom.Visible
    'End Sub

    'Private Sub pZoomResize()
    '    Dim oRect As Rectangle = sbMain.RectangleToScreen(pnlStatusDesignZoom.Bounds)
    '    oRect = Me.RectangleToClient(oRect)
    '    With trkZoom
    '        .Location = New Point(oRect.Location.X + 60, oRect.Location.Y)
    '        .Size = New Size(oRect.Width - 60 - 2, oRect.Height)
    '    End With
    'End Sub

    'Private Sub frmPreview_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
    '    Call pZoomResize()
    'End Sub

    Private Sub cboPrintCenterlineColorMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPrintCenterlineColorMode.SelectedIndexChanged
        Call pRefresh()
    End Sub

    Private Sub picMap_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles picMap.PreviewKeyDown
        Call frmPreview_PreviewKeyDown(sender, e)
    End Sub

    Private Sub frmPreview_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Me.PreviewKeyDown
        If e.KeyCode = Keys.F5 Then
            If bFirstRendering Then bFirstRendering = False
            Call pRefresh(True, False)
        End If
        If e.KeyCode = Keys.F4 Then
            Call btnZoomToFit_ItemClick(Nothing, Nothing)
        End If
        If e.Control AndAlso (e.KeyCode = Keys.Oemplus OrElse e.KeyCode = Keys.Add) Then
            Call btnZoomIn_ItemClick(Nothing, Nothing)
        End If
        If e.Control AndAlso e.KeyCode = Keys.OemMinus OrElse e.KeyCode = Keys.Subtract Then
            Call btnZoomout_ItemClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub pScaleZoom(Scale)
        Using oGr As Graphics = picMap.CreateGraphics
            Call pMapZoom(modPaint.GetZoomFactor(oGr, Scale))
            Call pMapInvalidate()
        End Using
    End Sub

    Private Sub txtImageWidth_Leave(sender As Object, e As EventArgs) Handles txtImageWidth.Leave
        Call pRefresh()
    End Sub

    Private Sub pImageUnitChanged()
        Dim sWidth As Single = txtImageWidth.Value
        Dim sHeight As Single = txtImageHeight.Value
        Select Case cboImageUM.SelectedIndex
            Case 0
                txtImageWidth.DecimalPlaces = 0
                txtImageHeight.DecimalPlaces = 0
                txtImageWidth.Increment = 1
                txtImageHeight.Increment = 1

                'txtImageWidth.BeginInit()
                'txtImageWidth.Minimum = 120
                'txtImageHeight.Minimum = 120
                'txtImageWidth.Value = txtImageWidth.Minimum
                'txtImageHeight.Value = txtImageHeight.Minimum
                'txtImageWidth.Maximum = 8.192
                'txtImageHeight.Maximum = 8.192
                'txtImageWidth.EndInit()
            Case Else
                txtImageWidth.DecimalPlaces = 2
                txtImageHeight.DecimalPlaces = 2
                txtImageWidth.Increment = 1
                txtImageHeight.Increment = 1

                'txtImageWidth.Value = 1
                'txtImageHeight.Value = 1
                'txtImageWidth.Minimum = 1
                'txtImageHeight.Minimum = 1
                'txtImageWidth.Maximum = 64000
                'txtImageHeight.Maximum = 64000
        End Select

        txtImageWidth.Value = sWidth
        txtImageHeight.Value = sHeight
    End Sub

    Private Sub cboImageUM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboImageUM.SelectedIndexChanged
        Call pImageUnitChanged()
        Call pRefresh()
    End Sub

    Private Sub txtImageDPI_Leave(sender As Object, e As EventArgs) Handles txtImageDPI.Leave
        Call pRefresh()
    End Sub

    'Private Sub cboSize_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboSize.QueryPopUp
    '    Dim oOptions As cSurvey.Design.cOptionsExport = oCurrentOptions
    '    With oOptions
    '        Dim oSize As SizeF = New SizeF(oOptions.ImageWidth, oOptions.ImageHeight)

    '        Dim oCustomItem As ImageComboBoxItem = New ImageComboBoxItem({Nothing, Nothing}, 0)
    '        oCustomItem.Description = "Custom" 'TODO:localize
    '        cboSize.Properties.Items.Add(oCustomItem)

    '        Dim oXml As XmlDocument = New XmlDocument
    '        Call oXml.Load(IO.Path.Combine(modMain.GetApplicationPath, "papersizes.xml"))
    '        For Each oXMLSize As XmlElement In oXml.DocumentElement.ChildNodes
    '            Dim sName As String = oXMLSize.GetAttribute("name")
    '            Dim oItemSize As SizeF = New SizeF(modNumbers.StringToDecimal(oXMLSize.GetAttribute("w")), modNumbers.StringToDecimal(oXMLSize.GetAttribute("h")))
    '            Dim oItem As ImageComboBoxItem = New ImageComboBoxItem({oItemSize, oXMLSize.GetAttribute("u")}, 0)
    '            oItem.Description = sName
    '            cboSize.Properties.Items.Add(oItem)
    '            If oItemSize = oSize Then
    '                cboSize.SelectedItem = oItem
    '                chkImageOrientationPortrait.Checked = True
    '            ElseIf oItemSize.Width = oSize.Height AndAlso oItemSize.Height = oSize.Width Then
    '                cboSize.SelectedItem = oItem
    '                chkImageOrientationLandscape.Checked = True
    '            End If
    '        Next
    '        If cboSize.SelectedItem Is Nothing Then
    '            cboSize.SelectedItem = cboSize.Properties.Items(0)
    '        End If
    '    End With
    'End Sub

    Private Sub pApplySVGSize(ApplySize As Boolean)
        Dim oOptions As cSurvey.Design.cOptionsExport = oCurrentOptions
        With oOptions
            Dim oItem As ImageComboBoxItem = cboSize.SelectedItem
            If Not oItem Is Nothing Then
                If oItem.Value(0) Is Nothing Then
                    lblImageOrientation.Enabled = False
                    chkImageOrientationPortrait.Enabled = False
                    chkImageOrientationLandscape.Enabled = False
                    txtImageWidth.Enabled = True
                    txtImageHeight.Enabled = True
                    cboImageUM.Enabled = True
                Else
                    lblImageOrientation.Enabled = True
                    chkImageOrientationPortrait.Enabled = True
                    chkImageOrientationLandscape.Enabled = True
                    txtImageWidth.Enabled = False
                    txtImageHeight.Enabled = False
                    cboImageUM.Enabled = False

                    If ApplySize Then
                        Dim sW As Single = oItem.Value(0).width
                        Dim sH As Single = oItem.Value(0).height
                        If chkImageOrientationLandscape.Checked Then
                            Dim sT As Single = sW
                            sW = sH
                            sH = sT
                        End If
                        .ImageWidth = sW
                        .ImageHeight = sH
                        .ImageUnit = oItem.Value(1)

                        txtImageWidth.Value = .ImageWidth
                        txtImageHeight.Value = .ImageHeight
                        cboImageUM.SelectedIndex = pFromImageUnit(.ImageUnit)
                        Call pRefresh()
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub cboSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSize.SelectedIndexChanged
        If Not bDisableImageSizeEvent Then
            Call pApplySVGSize(True)
        End If
    End Sub

    Private Sub chkImageOrientationLandscape_CheckedChanged(sender As Object, e As EventArgs) Handles chkImageOrientationLandscape.CheckedChanged
        Call cboSize_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub chkImageOrientationPortrait_CheckedChanged(sender As Object, e As EventArgs) Handles chkImageOrientationPortrait.CheckedChanged
        Call cboSize_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub chkPageVertical_CheckedChanged(sender As Object, e As EventArgs) Handles chkPageVertical.CheckedChanged
        If Not bEventDisabled Then
            Try
                If Not oCurrentPrinterSettings Is Nothing Then
                    oCurrentPrinterSettings.DefaultPageSettings.Landscape = chkPageHorizontal.Checked
                End If
            Catch
            End Try
            Call pRefresh()
        End If
    End Sub

    Private Sub chkPageHorizontal_CheckedChanged(sender As Object, e As EventArgs) Handles chkPageHorizontal.CheckedChanged
        If Not bEventDisabled Then
            Try
                If Not oCurrentPrinterSettings Is Nothing Then
                    oCurrentPrinterSettings.DefaultPageSettings.Landscape = chkPageHorizontal.Checked
                End If
            Catch
            End Try
            Call pRefresh()
        End If
    End Sub

    Private Sub cboPageFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPageFormat.SelectedIndexChanged
        If Not bEventDisabled Then
            Dim oPaperSize As PaperSize = pFindPaperSize(cboPageFormat.Text)
            If oPaperSize.PaperName <> oCurrentPrinterSettings.DefaultPageSettings.PaperSize.PaperName Then
                oCurrentPrinterSettings.DefaultPageSettings.PaperSize = oPaperSize
                Call pRefresh()
            End If
        End If
    End Sub

    Private Sub btnProfilesAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnProfilesAdd.ItemClick
        Call pProfileAdd()
    End Sub

    Private Sub btnProfilesDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnProfilesDelete.ItemClick
        Call pProfileDelete()
    End Sub

    Private Sub btnBaseRule_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnBaseRule.ItemClick
        Call pScaleRules()
    End Sub

    Private Sub pScaleRules()
        Using frmSR As frmScaleRules = New frmScaleRules(oSurvey, frmScaleRules.EditStyleEnum.BaseRule, oCurrentOptions)
            If frmSR.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Call pRefresh()
            End If
        End Using
    End Sub

    Private Sub pProperties()
        Using frmP As frmProperties = New frmProperties(oSurvey)
            AddHandler frmP.OnApply, AddressOf frmProperties_OnApply
            If frmP.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Call pRefresh()
                RaiseEvent OnPropertyChange(Me)
            End If
            RemoveHandler frmP.OnApply, AddressOf frmProperties_OnApply
        End Using
    End Sub

    Private Sub btnProperties_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnProperties.ItemClick
        Call pProperties()
    End Sub

    Private Sub btnZoomIn_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnZoomIn.ItemClick
        Select Case iMode
            Case PreviewModeEnum.Preview
                If (pPreview.Zoom < 100.0F) Then
                    sViewZoom *= 1.1F
                    pPreview.Zoom = sViewZoom
                End If
            Case PreviewModeEnum.Export
                sViewZoom *= 1.1F
                picExport.Size = New Size(picExport.Image.Width * sViewZoom, picExport.Image.Height * sViewZoom)
                Call pnlExport.Invalidate()
            Case PreviewModeEnum.Viewer
                Call pMapZoomIn()
        End Select
    End Sub

    Private Sub btnZoomout_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnZoomOut.ItemClick
        Select Case iMode
            Case PreviewModeEnum.Preview
                If (sViewZoom > 0.1F) Then
                    sViewZoom /= 1.1F
                    pPreview.Zoom = sViewZoom
                End If
            Case PreviewModeEnum.Export
                If (sViewZoom > 0.1F) Then
                    sViewZoom /= 1.1F
                    picExport.Size = New Size(picExport.Image.Width * sViewZoom, picExport.Image.Height * sViewZoom)
                    Call pnlExport.Invalidate()
                End If
            Case PreviewModeEnum.Viewer
                Call pMapZoomOut()
        End Select
    End Sub

    Private Sub btnClose_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnClose.ItemClick
        Call Close()
    End Sub

    Private Sub btnPrint_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnPrint.ItemClick
        Call pPrint()
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnExport.ItemClick
        Call pExport()
    End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnRefresh.ItemClick
        If bFirstRendering Then bFirstRendering = False
        Call pRefresh(True, False)
    End Sub

    Private Sub btnStatusDesignZoom200_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnStatusDesignZoom200.ItemClick
        Call pScaleZoom(200)
    End Sub

    Private Sub btnStatusDesignZoom100_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnStatusDesignZoom100.ItemClick
        Call pScaleZoom(100)
    End Sub

    Private Sub btnStatusDesignZoom250_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnStatusDesignZoom250.ItemClick
        Call pScaleZoom(250)
    End Sub

    Private Sub btnStatusDesignZoom500_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnStatusDesignZoom500.ItemClick
        Call pScaleZoom(500)
    End Sub

    Private Sub btnStatusDesignZoom1000_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnStatusDesignZoom1000.ItemClick
        Call pScaleZoom(1000)
    End Sub

    Private Sub btnStop_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnStop.ItemClick
        Call pDrawingStop(True)
    End Sub

    Private Sub NavBarControl1_SelectedLinkChanged(sender As Object, e As DevExpress.XtraNavBar.ViewInfo.NavBarSelectedLinkChangedEventArgs) Handles NavBarControl1.SelectedLinkChanged
        If Not bEventDisabled Then
            Call pOptionsSave()
            If Not e.Link Is Nothing Then
                Call pProfileSelect(e.Link.Item.Tag, True, True)
            End If
        End If
    End Sub

    Private Sub btnSidePanel_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles btnSidePanel.CheckedChanged
        If Not bEventDisabled Then
            pnlOptions.Visible = btnSidePanel.Checked
            Call oSurvey.SharedSettings.SetValue("preview.sidepanel.visible", If(btnSidePanel.Checked, "1", "0"))
        End If
    End Sub

    Private bRefreshFromParameters As Boolean

    Private Sub flyParameters_BeforeHide(sender As Object, e As CancelEventArgs) Handles flyParameters.BeforeHide
        bRefreshFromParameters = False
    End Sub

    Private Sub oCurrentOptions_OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Handles oCurrentOptions.OnPropertyChanged
        If bRefreshFromParameters Then
            If e.Name.StartsWith("PageMargins.") Then
                oCurrentPrinterSettings.DefaultPageSettings.Margins = DirectCast(oCurrentOptions, cOptionsPreview).PageMargins.ToMargin
            End If
            Call pRefresh()
            End If
    End Sub

    Private Sub flyParameters_BeforeShow(sender As Object, e As CancelEventArgs) Handles flyParameters.BeforeShow
        bRefreshFromParameters = True
    End Sub

    Private Sub flyParameters_Hidden(sender As Object, e As DevExpress.Utils.FlyoutPanelEventArgs) Handles flyParameters.Hidden
        Call pnlParameters.Controls.Clear()
    End Sub

    Private Sub btnProfileImportFromFile_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnProfileImportFromFile.ItemClick
        Call pImportFromFile()
    End Sub

    Private Sub btnProfileExportToFile_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnProfileExportToFile.ItemClick
        Call pExportToFile()
    End Sub

    'Private Sub NavBarControl1_CustomDrawLink(sender As Object, e As DevExpress.XtraNavBar.ViewInfo.CustomDrawNavBarElementEventArgs) Handles NavBarControl1.CustomDrawLink
    '    If e.ObjectInfo.State = DevExpress.Utils.Drawing.ObjectState.Pressed Then
    '        e.Cache.FillRectangle(e.Cache.GetSolidBrush(SystemColors.Highlight), e.RealBounds)
    '        'e.Handled = True
    '    End If
    'End Sub

    'Private Sub pPreview_Paint(sender As Object, e As PaintEventArgs) Handles pPreview.Paint
    '    Using oAngleBrushes As SolidBrush = New SolidBrush(Color.FromArgb(120, Color.LightYellow))
    '        Call e.Graphics.FillPolygon(oAngleBrushes, {New PointF(e.ClipRectangle.X, e.ClipRectangle.Y), New PointF(e.ClipRectangle.X + 96, e.ClipRectangle.Y), New PointF(e.ClipRectangle.X, e.ClipRectangle.Y + 96)})
    '    End Using
    '    Call e.Graphics.DrawImage(modPaint.SVGToBitmap(My.Resources.warning, New Drawing.Size(e.ClipRectangle.X + 32, e.ClipRectangle.Y + 32), LookAndFeel), 8, 8)
    'End Sub

    'Private Sub mnuImageSizeFromPageSize_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuImageSizeFromPageSize.Opening
    '    Call mnuImageSizeFromPageSize.Items.Clear()
    '    Dim oXml As XmlDocument = New XmlDocument
    '    Call oXml.Load(IO.Path.Combine(modMain.GetApplicationPath, "papersizes.xml"))
    '    For Each oXMLSize As XmlElement In oXml.DocumentElement.ChildNodes
    '        Dim oMenuItem As ToolStripMenuItem = New ToolStripMenuItem(oXMLSize.GetAttribute("name"))
    '        oMenuItem.Tag = {modNumbers.StringToDecimal(oXMLSize.GetAttribute("w")), modNumbers.StringToDecimal(oXMLSize.GetAttribute("h")), oXMLSize.GetAttribute("u")}
    '        AddHandler oMenuItem.Click, AddressOf oImageSizeFromPageSizeItem_Click
    '        Call mnuImageSizeFromPageSize.Items.Add(oMenuItem)
    '    Next
    'End Sub

    'Private Sub oImageSizeFromPageSizeItem_Click(sender As Object, e As EventArgs)
    '    cboImageUM.SelectedIndex = pFromImageUnit(sender.tag(2))
    '    txtImageWidth.Value = sender.tag(0)
    '    txtImageHeight.Value = sender.tag(1)
    '    Call pRefresh()
    'End Sub

    'Private Sub cDesignPrintOrExportArea_OnMapInvalidate(Sender As Object, e As EventArgs)
    '    Call pRefresh()
    'End Sub

    'Private Sub cDesignPrintOrExportArea_OnObjectPropertyLoad(Sender As Object, e As EventArgs)
    '    Call pRefresh()
    'End Sub

    'Private Sub cDesignPrintOrExportArea_OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs)
    '    If e.Name = "DrawPrintOrExportArea" Then
    '        Dim oOptions As cSurvey.Design.cOptionsViewer = oCurrentOptions
    '        pnlProfile.Enabled = Not oOptions.DrawPrintOrExportArea
    '    End If
    'End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If My.Application.CurrentLanguage = "it" Then
            If keyData = Keys.Decimal Then
                SendKeys.Send(",")
                Return True
            Else
                Return MyBase.ProcessCmdKey(msg, keyData)
            End If
        End If
    End Function

    Private Sub chkShowTrigpointText_CheckedChanged(sender As Object, e As EventArgs) Handles chkPrintTrigpointText.CheckedChanged
        Call pRefresh()
    End Sub
End Class