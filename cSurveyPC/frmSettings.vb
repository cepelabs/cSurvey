Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Helper.Editor
Imports cSurveyPC.cSurvey.Net
Imports cSurveyPC.cSurvey.UIHelpers
Imports DevExpress.XtraCharts.Sankey

Friend Class frmSettings

    Private Sub cmdTherionPathBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTherionPathBrowse.Click
        Dim oOFD As OpenFileDialog = New OpenFileDialog
        With oOFD
            .Title = GetLocalizedString("settings.selecttheriondialog")
            .Filter = GetLocalizedString("settings.filetypeEXE") & " (*.EXE)|*.EXE"
            .FilterIndex = 1
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                txtTherionPath.Text = .FileName
            End If
        End With
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Call My.Application.Settings.SetSetting("default.club", txtDefaultClub.Text)
        Call My.Application.Settings.SetSetting("default.team", txtDefaultTeam.Text)
        Call My.Application.Settings.SetSetting("default.designer", txtDefaultDesigner.Text)

        Call My.Application.Settings.SetSetting("default.calculatemode", If(chkCalculateMode.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("default.calculatetype", cboDefaultCalculateType.SelectedIndex)

        Call My.Application.Settings.SetSetting("design.quality", Integer.Parse(cboDesignQuality.SelectedIndex))
        Call My.Application.Settings.SetSetting("design.rulers", If(chkDesignShowRulers.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("design.rulers.style", cboDesignShowRulersStyle.SelectedIndex)
        Call My.Application.Settings.SetSetting("design.metricgrid", cboDesignShowMetricGrid.SelectedIndex)
        Call My.Application.Settings.SetSetting("design.metricgrid.opacity", txtDesignMetricGridOpacity.Value)
        Call My.Application.Settings.SetSetting("design.clipborder", cboDesignClipBorder.SelectedIndex)
        Call My.Application.Settings.SetSetting("design.linetype", cboDesignLineType.SelectedIndex)
        Call My.Application.Settings.SetSetting("design.useonlyanchortomove", If(chkDesignUseOnlyAnchorToMove.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("design.selectionmode", cboDesignSelectionMode.SelectedIndex)
        Call My.Application.Settings.SetSetting("design.anchorscale", modNumbers.NumberToString(txtDesignAnchorScale.Value))
        Call My.Application.Settings.SetSetting("design.showlegacyextraprintandexportobjects", If(chkDesignShowLegacyExtraPrintAndExportObjects.Checked, 1, 0))

        Call My.Application.Settings.SetSetting("grid.shotsgrid.exportsplaynames", If(chkShotsGridExportSplayNames.Checked, 1, 0))

        Call My.Application.Settings.SetSetting("svg.importmaxpathlen", txtSVGImportPathMaxLen.Value)
        Call My.Application.Settings.SetSetting("svg.importscale", modNumbers.NumberToString(txtSVGImportScale.Value))
        Call My.Application.Settings.SetSetting("svg.importlinetype", cboSVGImportLineType.SelectedIndex)
        Call My.Application.Settings.SetSetting("svg.importautodivide", chkSVGImportAutodivide.Checked)

        'call  My.Application.Settings.SetSetting("svg.exportscale", modNumbers.NumberToString(txtSVGExportScale.Value))
        'call  My.Application.Settings.SetSetting("svg.exportdpi", txtSVGExportDPI.Value)
        Call My.Application.Settings.SetSetting("svg.exportnoclipartbrushes", If(chkSVGExportNoClipartBrushes.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("svg.exportnoclipping", If(chkSVGExportNoClipping.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("svg.exportcsurveyreferences", If(chkSVGExportcSurveyReference.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("svg.exportimages", If(chkSVGExportImages.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("svg.exporttextaspath", If(chkSVGExportTextAsPath.Checked, 1, 0))

        Call My.Application.Settings.SetSetting("therion.path", txtTherionPath.Text)
        Call My.Application.Settings.SetSetting("therion.lock.enabled", If(chkTherionLochEnabled.Checked, 1, 0))

        Call My.Application.Settings.SetSetting("therion.usecadastralidincavenames", If(chkTherionUseCadastralIDInCaveNames.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("therion.backgroundprocess", If(chkTherionBackgroundProcess.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("therion.trigpointsafename", If(chkTherionTrigpointSafename.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("therion.deletetempfiles", If(chkTherionDeleteTempFiles.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("therion.segmentforcedirection", If(chkTherionSegmentForceDirection.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("therion.segmentforcepath", If(chkTherionSegmentForcePath.Checked, 1, 0))

        Call My.Application.Settings.SetSetting("environment.setdesigntoolsenabledbylevel", If(chkSetDesignToolsEnabledByLevel.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("environment.setdesigntoolshiddenbylevel", If(chkSetDesignToolsHiddenByLevel.Checked, 1, 0))

        Dim oDefaultFont As cIFont = txtDefaultFont.Tag
        Call My.Application.Settings.SetSetting("design.defaultfont.name", oDefaultFont.FontName)
        Call My.Application.Settings.SetSetting("design.defaultfont.size", modNumbers.NumberToString(oDefaultFont.FontSize))
        Call My.Application.Settings.SetSetting("design.defaultfont.bold", If(oDefaultFont.FontBold, 1, 0))
        Call My.Application.Settings.SetSetting("design.defaultfont.italic", If(oDefaultFont.FontItalic, 1, 0))
        Call My.Application.Settings.SetSetting("design.defaultfont.underline", If(oDefaultFont.FontUnderline, 1, 0))

        Call My.Application.Settings.SetSetting("design.maxdrawitemcount", cboMaxDrawItemCount.Text)

        'call  My.Application.Settings.SetSetting("design.designbar.showlastusedtools", If(chkShowLastUsedToolsInDesignBar.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("design.designbar.defaultposition", cboDesignBarPosition.SelectedIndex)
        'call  My.Application.Settings.SetSetting("design.designbar.size", cboDesignBarSize.SelectedIndex)

        Call My.Application.Settings.SetSetting("environment.alwaysuseshellforattachments", If(chkAlwaysUseShellForAttchments.Checked, 1, 0))

        Call My.Application.Settings.SetSetting("environment.functionlanguage", cboFunctionLanguage.SelectedIndex)

        Call My.Application.Settings.SetSetting("vtopo.importincompatibleset", If(chkVTopoImportIncompatibleSet.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("vtopo.importsetasbranch", If(chkVTopoImportSetAsBranch.Checked, 1, 0))

        Call My.Application.Settings.SetSetting("zoom.type", cboDesignZoomType.SelectedIndex)

        Call My.Application.Settings.SetSetting("debug.log.verbose", If(chkLogVerbose.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("debug.log.writeonfile", If(chkLogOnFile.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("debug.log.maxlinecount", txtLogMaxLine.EditValue)
        Call My.Application.Settings.SetSetting("debug.forcegc", If(chkForceGarbaceCollect.Checked, 1, 0))

        Call My.Application.Settings.SetSetting("debug.autosave", If(chkAutosave.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("debug.autosave.usehistorysettings", IIf(chkAutosaveUseHistorySettings.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("debug.sendexception", If(chkSendException.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("debug.checknewversion", If(chkCheckNewVersion.Checked, 1, 0))

        Call My.Application.Settings.SetSetting("clipboard.segments.extformats", pGetClipboardFormats("segments"))
        Call My.Application.Settings.SetSetting("clipboard.designitems.extformats", pGetClipboardFormats("designitems"))
        Call My.Application.Settings.SetSetting("clipboard.cleanpastedstation", If(chkClipboardCleanPastedStation.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("clipboard.uselocalformat", If(chkClipboardLocalFormat.Checked, 1, 0))

        Call My.Application.Settings.SetSetting("history.enabled", If(chkHistory.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("history.mode", cboHistoryMode.SelectedIndex)
        Call My.Application.Settings.SetSetting("history.web.authreq", If(chkHistoryWebAuthReq.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("history.web.url", txtHistoryWebURL.Text)
        Call My.Application.Settings.SetSetting("history.web.username", txtHistoryWebUsername.Text)
        Call My.Application.Settings.SetSetting("history.web.password", New cLocalSecurity("csurvey").EncryptData(txtHistoryWebPassword.Text))
        Call My.Application.Settings.SetSetting("history.web.maxdailycopies", txtHistoryWebDailyCopies.Value)
        Call My.Application.Settings.SetSetting("history.web.maxcopies", txtHistoryWebMaxCopies.Value)
        Call My.Application.Settings.SetSetting("history.folder", txtHistoryFolder.Text)
        Call My.Application.Settings.SetSetting("history.maxdailycopies", txtHistoryDailyCopies.Value)
        Call My.Application.Settings.SetSetting("history.maxcopies", txtHistoryMaxCopies.Value)
        Call My.Application.Settings.SetSetting("history.createonsave", If(chkHistoryArchiveOnSave.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("history.web.createonsave", If(chkHistoryWebArchiveOnSave.Checked, "1", "0"))

        Call My.Application.Settings.SetSetting("wms.cache.enabled", If(chkWMSCacheEnabled.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("wms.cache.maxsize", txtWMSCacheMaxSize.Value)

        Call My.Application.Settings.SetSetting("default.folder", txtDefaultFolder.Text)

        Call My.Application.Settings.SetSetting("linkedsurveys.selectonadd", If(chkLinkedSurveysSelectOnAdd.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("linkedsurveys.showincaveinfo", If(chkLinkedSurveysShowInCaveInfo.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("linkedsurveys.recursiveload", If(chkLinkedSurveysRecursiveLoad.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("linkedsurveys.recursiveload.prioritizechildren", If(chkLinkedSurveysRecursiveLoadPrioritizeChildren.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("linkedsurveys.refreshonload", If(chkLinkedSurveysRefreshOnLoad.Checked, "1", "0"))

        Select Case cboLanguage.SelectedIndex
            Case 0
                Call My.Application.Settings.DeleteSetting("language")
            Case 1
                Call My.Application.Settings.SetSetting("language", "en")
            Case 2
                Call My.Application.Settings.SetSetting("language", "ru")
            Case 3
                Call My.Application.Settings.SetSetting("language", "it")
        End Select

        Call My.Application.Settings.SetSetting("keys.changedecimalkey", If(chkITChangeDecimalKey.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("keys.changeperiodkey", If(chkITChangePeriodKey.Checked, "1", "0"))

        For Each oValue As cNameAndValue In tvDefaultPenPattern.DataSource
            If oValue.Value <> "" Then
                Call My.Application.Settings.SetSetting("design.penstylepattern." & oValue.Name, oValue.Value, oValue.DefaultValue)
            End If
        Next

        Call My.Application.Settings.Save()
    End Sub

    Private Function pFindItemByTag(ByVal Group As String, ByVal Text As String) As ListViewItem
        Dim sGroup As String = "grp" & Group.ToLower
        Dim sText As String = Text.ToLower
        For Each oItem In lvClipboardFormats.Items
            If oItem.Group.Name.ToLower = sGroup Then
                If oItem.tag.tolower = sText Then
                    Return oItem
                End If
            End If
        Next
        Return Nothing
    End Function

    Private Sub pSetClipboardFormats(ByVal Group As String, ByVal Formats As String)
        Dim sGroup As String = "grp" & Group.ToLower
        For Each oItem As ListViewItem In lvClipboardFormats.CheckedItems
            If oItem.Group.Name.ToLower = sGroup Then
                oItem.Checked = False
            End If
        Next
        For Each sFormat As String In Formats.Split({","}, StringSplitOptions.RemoveEmptyEntries)
            Try
                Dim oItem As ListViewItem = pFindItemByTag(Group, sFormat)
                oItem.Checked = True
            Catch
            End Try
        Next
    End Sub

    Private Function pGetClipboardFormats(ByVal Group As String) As String
        Dim sGroup As String = "grp" & Group.ToLower
        Dim sFormats As String = ""
        For Each oItem As ListViewItem In lvClipboardFormats.CheckedItems
            If oItem.Group.Name.ToLower = sGroup Then
                If sFormats <> "" Then sFormats = sFormats & ","
                sFormats = sFormats & oItem.Tag
            End If
        Next
        Return sFormats
    End Function

    Private Sub pFillClipboardItems()
        Dim oGroup As ListViewGroup
        Dim oItem As ListViewItem

        oGroup = lvClipboardFormats.Groups.Add("grpsegments", GetLocalizedString("settings.clipboardgroup1"))
        oItem = New ListViewItem(GetLocalizedString("settings.clipboarditem1"), "", oGroup)
        oItem.Tag = "csv"
        Call lvClipboardFormats.Items.Add(oItem)
        oItem = New ListViewItem(GetLocalizedString("settings.clipboarditem2"), "", oGroup)
        oItem.Tag = "txt"
        Call lvClipboardFormats.Items.Add(oItem)

        oGroup = lvClipboardFormats.Groups.Add("grpdesignitems", GetLocalizedString("settings.clipboardgroup2"))
        oItem = New ListViewItem(GetLocalizedString("settings.clipboarditem3"), "", oGroup)
        oItem.Tag = "svg"
        Call lvClipboardFormats.Items.Add(oItem)
        oItem = New ListViewItem(GetLocalizedString("settings.clipboarditem4"), "", oGroup)
        oItem.Tag = "xml"
        Call lvClipboardFormats.Items.Add(oItem)
    End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Call tabMain.BeginUpdate()
        tabMain.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False
        For Each oTabControl As DevExpress.XtraTab.XtraTabPage In tabMain.TabPages
            Dim oPanel As DevExpress.XtraEditors.PanelControl = New DevExpress.XtraEditors.PanelControl
            Me.Controls.Add(oPanel)
            oPanel.Name = "_" & oTabControl.Name
            oPanel.Size = oTabControl.ClientSize
            Dim oControls As List(Of Control) = New List(Of Control)
            For Each oControl As Control In oTabControl.Controls
                Call oControls.Add(oControl)
            Next
            For Each oControl As Control In oControls
                Try
                    oPanel.Controls.Add(oControl)
                Catch ex As Exception
                End Try
            Next
            oPanel.Tag = tabMain.TabPages.IndexOf(oTabControl)
            oPanel.Dock = DockStyle.Fill
            oPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            oPanel.Visible = False
        Next
        tabMain.Visible = False
        Call tabMain.EndUpdate()

        Call pFillClipboardItems()

        Call pFillPenPatternItems()

        'preparo la tab delle impostazioni di history
        oTabHistory0 = tabHistorySettings.TabPages(0)
        oTabHistory1 = tabHistorySettings.TabPages(1)
        Call tabHistorySettings.TabPages.Clear()

        'leggo i valori dal registro
        Dim bFirstRun As Boolean = My.Application.Settings.Count = 0

        txtDefaultClub.Text = My.Application.Settings.GetSetting("default.club", "")
        txtDefaultTeam.Text = My.Application.Settings.GetSetting("default.team", "")
        txtDefaultDesigner.Text = My.Application.Settings.GetSetting("default.designer", "")

        chkCalculateMode.Checked = If(My.Application.Settings.GetSetting("default.calculatemode", 0) = cSurvey.cSurvey.CalculateModeEnum.Automatic, True, False)
        cboDefaultCalculateType.SelectedIndex = My.Application.Settings.GetSetting("default.calculatetype", cSurvey.cSurvey.CalculateTypeEnum.Therion)

        cboDesignMode.SelectedIndex = 0
        cboDesignQuality.SelectedIndex = My.Application.Settings.GetSetting("design.quality", 0)
        chkDesignShowRulers.Checked = My.Application.Settings.GetSetting("design.rulers", 1)
        cboDesignShowRulersStyle.SelectedIndex = My.Application.Settings.GetSetting("design.rulers.style", frmMain2.RulersStyleEnum.Simple)
        cboDesignShowMetricGrid.SelectedIndex = My.Application.Settings.GetSetting("design.metricgrid", 0)
        txtDesignMetricGridOpacity.Value = My.Application.Settings.GetSetting("design.metricgrid.opacity", 50)
        cboDesignClipBorder.SelectedIndex = My.Application.Settings.GetSetting("design.clipborder", cSurvey.Design.cClippingRegions.ClipBorderEnum.ClipBorder)
        cboDesignLineType.SelectedIndex = My.Application.Settings.GetSetting("design.linetype", cSurvey.Design.Items.cIItemLine.LineTypeEnum.Splines)
        chkDesignUseOnlyAnchorToMove.Checked = My.Application.Settings.GetSetting("design.useonlyanchortomove", 1)
        cboDesignSelectionMode.SelectedIndex = My.Application.Settings.GetSetting("design.selectionmode", 0)
        Dim sAnchorScale As Single = modNumbers.StringToSingle(My.Application.Settings.GetSetting("design.anchorscale", 1))
        If sAnchorScale < 1.0F Then sAnchorScale = 1.0F
        txtDesignAnchorScale.Value = sAnchorScale
        chkDesignShowLegacyExtraPrintAndExportObjects.Checked = My.Application.Settings.GetSetting("design.showlegacyextraprintandexportobjects", Not bFirstRun)

        chkShotsGridExportSplayNames.Checked = My.Application.Settings.GetSetting("grid.shotsgrid.exportsplaynames", 1)

        'chkShowLastUsedToolsInDesignBar.Checked =My.Application.Settings.GetSetting("design.designbar.showlastusedtools", 1)
        cboDesignBarPosition.SelectedIndex = My.Application.Settings.GetSetting("design.designbar.defaultposition", 0)
        ' cboDesignBarSize.SelectedIndex =My.Application.Settings.GetSetting("design.designbar.size", 0)

        cboMaxDrawItemCount.Text = My.Application.Settings.GetSetting("design.maxdrawitemcount", 20)

        txtSVGImportPathMaxLen.Value = My.Application.Settings.GetSetting("svg.importmaxpathlen", 2000)
        txtSVGImportScale.Value = modNumbers.StringToDecimal(My.Application.Settings.GetSetting("svg.importscale", 0.05))
        cboSVGImportLineType.SelectedIndex = My.Application.Settings.GetSetting("svg.importlinetype", cSurvey.Design.Items.cIItemLine.LineTypeEnum.Splines)
        chkSVGImportAutodivide.Checked = My.Application.Settings.GetSetting("svg.importautodivide", False)

        'txtSVGExportScale.Value = modNumbers.StringToDecimal(oReg.GetValue("svg.exportscale", 1))
        chkSVGExportNoClipartBrushes.Checked = My.Application.Settings.GetSetting("svg.exportnoclipartbrushes", 0)
        chkSVGExportNoClipping.Checked = My.Application.Settings.GetSetting("svg.exportnoclipping", 0)
        chkSVGExportcSurveyReference.Checked = My.Application.Settings.GetSetting("svg.exportcsurveyreferences", 1)
        chkSVGExportImages.Checked = My.Application.Settings.GetSetting("svg.exportimages", 1)
        chkSVGExportTextAsPath.Checked = My.Application.Settings.GetSetting("svg.exporttextaspath", 0)

        'txtSVGExportDPI.Value =My.Application.Settings.GetSetting("svg.exportdpi", 90)
        txtTherionPath.Text = My.Application.Settings.GetSetting("therion.path", "")
        chkTherionLochEnabled.Checked = My.Application.Settings.GetSetting("therion.loch.enabled", 1)
        chkTherionUseCadastralIDInCaveNames.Checked = My.Application.Settings.GetSetting("therion.usecadastralidincavenames", 0)
        chkTherionBackgroundProcess.Checked = My.Application.Settings.GetSetting("therion.backgroundprocess", 1)
        chkTherionTrigpointSafename.Checked = My.Application.Settings.GetSetting("therion.trigpointsafename", 1)
        chkTherionDeleteTempFiles.Checked = My.Application.Settings.GetSetting("therion.deletetempfiles", 1)
        chkTherionSegmentForceDirection.Checked = My.Application.Settings.GetSetting("therion.segmentforcedirection", 1)
        chkTherionSegmentForcePath.Checked = My.Application.Settings.GetSetting("therion.segmentforcepath", 1)

        cboDesignZoomType.SelectedIndex = My.Application.Settings.GetSetting("zoom.type", 1)

        chkSetDesignToolsEnabledByLevel.Checked = My.Application.Settings.GetSetting("environment.setdesigntoolsenabledbylevel", 1)
        Call chkSetDesignToolsEnabledByLevel_CheckedChanged(Nothing, Nothing)
        chkSetDesignToolsHiddenByLevel.Checked = My.Application.Settings.GetSetting("environment.setdesigntoolshiddenbylevel", 0)
        Dim oDefaultFont As cIFont = modPaint.GetDefaultFont  'New cFont(Nothing,My.Application.Settings.GetSetting("design.defaultfont.name", "Segoe UI"), modNumbers.StringToSingle(oReg.GetValue("design.defaultfont.size", 8.0F)), Color.Black,My.Application.Settings.GetSetting("design.defaultfont.bold", 0),My.Application.Settings.GetSetting("design.defaultfont.italic", 0),My.Application.Settings.GetSetting("design.defaultfont.underline", 0))
        txtDefaultFont.Tag = oDefaultFont
        txtDefaultFont.Text = oDefaultFont.ToString

        chkAlwaysUseShellForAttchments.Checked = My.Application.Settings.GetSetting("environment.alwaysuseshellforattachments", 0)

        cboFunctionLanguage.SelectedIndex = My.Application.Settings.GetSetting("environment.functionlanguage", 0)

        chkVTopoImportIncompatibleSet.Checked = My.Application.Settings.GetSetting("vtopo.importincompatibleset", 0)
        chkVTopoImportSetAsBranch.Checked = My.Application.Settings.GetSetting("vtopo.importsetasbranch", 1)

        chkLogVerbose.Checked = My.Application.Settings.GetSetting("debug.log.verbose", 0)
        chkLogOnFile.Checked = My.Application.Settings.GetSetting("debug.log.writeonfile", 0)
        txtLogMaxLine.EditValue = My.Application.Settings.GetSetting("debug.log.maxlinecount", 512)
        chkForceGarbaceCollect.Checked = My.Application.Settings.GetSetting("debug.forcegc", 0)

        chkAutosave.Checked = My.Application.Settings.GetSetting("debug.autosave", 0)
        chkAutosaveUseHistorySettings.Checked = My.Application.Settings.GetSetting("debug.autosave.usehistorysettings", 0)
        chkSendException.Checked = My.Application.Settings.GetSetting("debug.sendexception", 0)
        chkCheckNewVersion.Checked = My.Application.Settings.GetSetting("debug.checknewversion", 0)
        txtMachineID.Text = My.Application.Settings.GetSetting("debug.machineid", "")

        Call pSetClipboardFormats("segments", My.Application.Settings.GetSetting("clipboard.segments.extformats", ""))
        Call pSetClipboardFormats("designitems", My.Application.Settings.GetSetting("clipboard.designitems.extformats", ""))
        chkClipboardCleanPastedStation.Checked = My.Application.Settings.GetSetting("clipboard.cleanpastedstation", 0)
        chkClipboardLocalFormat.Checked = My.Application.Settings.GetSetting("clipboard.uselocalformat", 0)

        chkHistory.Checked = My.Application.Settings.GetSetting("history.enabled", 0)
        cboHistoryMode.SelectedIndex = My.Application.Settings.GetSetting("history.mode", 0)
        txtHistoryWebURL.Text = My.Application.Settings.GetSetting("history.web.url", "")
        chkHistoryWebAuthReq.Checked = My.Application.Settings.GetSetting("history.web.authreq", "0")
        txtHistoryWebUsername.Text = My.Application.Settings.GetSetting("history.web.username", "")
        Dim sHistoryWebPassword As String = My.Application.Settings.GetSetting("history.web.password", "")
        If sHistoryWebPassword <> "" Then
            txtHistoryWebPassword.Text = New cLocalSecurity("csurvey").DecryptData(sHistoryWebPassword)
        End If
        txtHistoryWebDailyCopies.Value = My.Application.Settings.GetSetting("history.web.maxdailycopies", 4)
        txtHistoryWebMaxCopies.Value = My.Application.Settings.GetSetting("history.web.maxcopies", 20)
        txtHistoryFolder.Text = My.Application.Settings.GetSetting("history.folder", "")
        txtHistoryDailyCopies.Value = My.Application.Settings.GetSetting("history.maxdailycopies", 4)
        txtHistoryMaxCopies.Value = My.Application.Settings.GetSetting("history.maxcopies", 20)
        chkHistoryArchiveOnSave.Checked = My.Application.Settings.GetSetting("history.createonsave", "0")
        chkHistoryWebArchiveOnSave.Checked = My.Application.Settings.GetSetting("history.web.createonsave", "0")

        txtDefaultFolder.Text = My.Application.Settings.GetSetting("default.folder", "")

        chkWMSCacheEnabled.Checked = My.Application.Settings.GetSetting("wms.cache.enabled", 1)
        txtWMSCacheMaxSize.Value = My.Application.Settings.GetSetting("wms.cache.maxsize", 512)

        chkLinkedSurveysSelectOnAdd.Checked = My.Application.Settings.GetSetting("linkedsurveys.selectonadd", "0")
        chkLinkedSurveysShowInCaveInfo.Checked = My.Application.Settings.GetSetting("linkedsurveys.showincaveinfo", "1")
        chkLinkedSurveysRecursiveLoad.Checked = My.Application.Settings.GetSetting("linkedsurveys.recursiveload", "1")
        chkLinkedSurveysRecursiveLoadPrioritizeChildren.Checked = My.Application.Settings.GetSetting("linkedsurveys.recursiveload.prioritizechildren", "0")
        chkLinkedSurveysRefreshOnLoad.Checked = My.Application.Settings.GetSetting("linkedsurveys.refreshonload", "1")

        Dim sLanguage As String = My.Application.Settings.GetSetting("language", "")
        Select Case sLanguage
            Case "it"
                cboLanguage.SelectedIndex = 3
            Case "ru"
                cboLanguage.SelectedIndex = 2
            Case "en"
                cboLanguage.SelectedIndex = 1
            Case Else
                cboLanguage.SelectedIndex = 0
        End Select

        chkITChangeDecimalKey.Checked = My.Application.Settings.GetSetting("keys.changedecimalkey", "1")
        chkITChangePeriodKey.Checked = My.Application.Settings.GetSetting("keys.changeperiodkey", "0")


        Call pVisibilityByLanguage()

        Call pWMSRefreshCacheSize()

        AddHandler Me.Shown, Sub(sender As Object, e As EventArgs)
                                 Call pSelectTabByIndex(0)
                             End Sub
    End Sub

    Private Function pSelectTabByIndex(TabIndex As Integer) As Boolean
        Try
            Dim sName As String = tabMain.TabPages(TabIndex).Name
            For Each oElement In AccordionControl1.GetElements
                If oElement.Tag IsNot Nothing AndAlso oElement.Tag.tolower = sName.ToLower Then
                    Call AccordionControl1.SelectElement(oElement)
                    Call AccordionControl1.MakeElementVisible(oElement)
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub pWMSRefreshCacheSize()
        Cursor = Cursors.WaitCursor
        lblWMSCacheCurrentSizeValue.Text = Strings.Format(modWMSManager.WMSGetCacheSize() / 1048576, "0") & " Mb"
        Cursor = Cursors.Default
    End Sub

    Private Sub chkSetDesignToolsEnabledByLevel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSetDesignToolsEnabledByLevel.CheckedChanged
        Dim bEnabled As Boolean = chkSetDesignToolsEnabledByLevel.Checked
        chkSetDesignToolsHiddenByLevel.Enabled = bEnabled
    End Sub

    Private Sub chkDesignShowRulers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDesignShowRulers.CheckedChanged
        Dim bEnabled As Boolean = chkDesignShowRulers.Checked
        cboDesignShowRulersStyle.Enabled = bEnabled
    End Sub

    Private Sub chkHistory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHistory.CheckedChanged
        Dim bEnabled As Boolean = chkHistory.Checked
        lblHistoryMode.Enabled = bEnabled
        cboHistoryMode.Enabled = bEnabled
        tabHistorySettings.Enabled = bEnabled
    End Sub

    Private Sub cmdHistoryFolderBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHistoryFolderBrowse.Click
        Dim oFB As FolderBrowserDialog = New FolderBrowserDialog
        With oFB
            .SelectedPath = txtHistoryFolder.Text
            .ShowNewFolderButton = True
            .Description = GetLocalizedString("settings.historyfolderdialog")
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                txtHistoryFolder.Text = .SelectedPath
            End If
        End With
    End Sub

    Private Sub chkAutosave_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAutosave.CheckedChanged
        chkAutosaveUseHistorySettings.Enabled = chkAutosave.Checked
    End Sub

    Private Sub cmdDefaultFolder_Click(sender As Object, e As EventArgs) Handles cmdDefaultFolder.Click
        Using oFB As FolderBrowserDialog = New FolderBrowserDialog
            With oFB
                .SelectedPath = txtDefaultFolder.Text
                .ShowNewFolderButton = True
                .Description = GetLocalizedString("settings.backupfolderdialog")
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    txtDefaultFolder.Text = .SelectedPath
                End If
            End With
        End Using
    End Sub

    Private Sub cmdDefaultFont_Click(sender As Object, e As EventArgs) Handles cmdDefaultFont.Click
        Using oFD As frmFontDialog = New frmFontDialog(CType(txtDefaultFont.Tag, cIFont))
            With oFD
                If .ShowDialog = vbOK Then
                    txtDefaultFont.Tag = .CurrentFont
                    txtDefaultFont.Text = .CurrentFont.ToString
                End If
            End With
        End Using
    End Sub

    Private Sub cmdHistoryWebCheck_Click(sender As Object, e As EventArgs) Handles cmdHistoryWebCheck.Click
        Try
            Dim oNetHistory As cNetHistory = New cNetHistory(txtHistoryWebURL.Text, 0, 0)
            If oNetHistory.Login(txtHistoryWebUsername.Text, txtHistoryWebPassword.Text) Then
                Call cSurvey.UIHelpers.Dialogs.Msgbox(modMain.GetLocalizedString("settings.warning1"), vbOKOnly Or vbInformation, modMain.GetLocalizedString("settings.warningtitle"))
            Else
                Call cSurvey.UIHelpers.Dialogs.Msgbox(String.Format(modMain.GetLocalizedString("settings.warning2"), oNetHistory.LastMessage), vbOKOnly Or vbCritical, modMain.GetLocalizedString("settings.warningtitle"))
            End If
        Catch ex As Exception
            Call cSurvey.UIHelpers.Dialogs.Msgbox(String.Format(modMain.GetLocalizedString("settings.warning2"), ex.Message), vbOKOnly Or vbCritical, modMain.GetLocalizedString("settings.warningtitle"))
        End Try
    End Sub

    Dim oTabHistory0 As TabPage
    Dim oTabHistory1 As TabPage

    Private Sub cboHistoryMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboHistoryMode.SelectedIndexChanged
        Select Case cboHistoryMode.SelectedIndex
            Case 0
                Call tabHistorySettings.TabPages.Clear()
                Call tabHistorySettings.TabPages.Add(oTabHistory0)
            Case 1
                Call tabHistorySettings.TabPages.Clear()
                Call tabHistorySettings.TabPages.Add(oTabHistory1)
            Case 2
                Call tabHistorySettings.TabPages.Clear()
                Call tabHistorySettings.TabPages.Add(oTabHistory0)
                Call tabHistorySettings.TabPages.Add(oTabHistory1)
        End Select
    End Sub

    Private Sub btnWMSClearCache_Click(sender As Object, e As EventArgs) Handles btnWMSClearCache.Click
        Cursor = Cursors.WaitCursor
        Call modWMSManager.WMSClearCache()
        Cursor = Cursors.Default
        Call pWMSRefreshCacheSize()
    End Sub

    Private Sub chkWMSCacheEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles chkWMSCacheEnabled.CheckedChanged
        Dim bEnabled As Boolean = chkWMSCacheEnabled.Checked
        lblWMSCacheMaxSize.Enabled = bEnabled
        txtWMSCacheMaxSize.Enabled = bEnabled
        lblWMSCacheCurrentSize.Enabled = bEnabled
        lblWMSCacheCurrentSizeValue.Enabled = bEnabled
    End Sub

    Private Sub btnWMSBrowse_Click(sender As Object, e As EventArgs) Handles btnWMSBrowse.Click
        Call Shell("explorer """ & modWMSManager.WMSCachePath & """", AppWinStyle.NormalFocus, False)
    End Sub

    Private Sub cboDesignShowMetricGrid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDesignShowMetricGrid.SelectedIndexChanged
        txtDesignMetricGridOpacity.Enabled = cboDesignShowMetricGrid.SelectedIndex > 0
    End Sub

    Private Sub chkLinkedSurveysRecursiveLoad_CheckedChanged(sender As Object, e As EventArgs) Handles chkLinkedSurveysRecursiveLoad.CheckedChanged
        chkLinkedSurveysRecursiveLoadPrioritizeChildren.Enabled = chkLinkedSurveysRecursiveLoad.Checked
    End Sub

    'Private Sub cmdFileAssociationCreate_Click(sender As Object, e As EventArgs) Handles cmdFileAssociationCreate.Click
    '    Call pAssociateExtension("csx")
    '    Call pAssociateExtension("csz")
    'End Sub

    'Private Sub pRemoveAssociatedExtension(Extension As String)
    '    Dim oFai As FileAssociationInfo = New FileAssociationInfo("." & Extension)
    'End Sub

    'Private Sub pAssociateExtension(Extension As String)
    '    Dim oFai As FileAssociationInfo = New FileAssociationInfo("." & Extension)
    '    If oFai.Exists Then oFai.Delete()
    '    Call oFai.Create("csurvey")
    '    oFai.OpenWithList = {"cSurvey"}
    '    Dim oPai As ProgramAssociationInfo = New ProgramAssociationInfo(oFai.ProgID)
    '    If oPai.Exists Then oPai.Delete()
    '    Call oPai.Create("Open cSurvey file", New ProgramVerb("Open", Chr(34) & Application.ExecutablePath & Chr(34) & " " & Chr(34) & "%1" & Chr(34)))
    '    oPai.DefaultIcon = New ProgramIcon(Application.ExecutablePath, 0)
    'End Sub
    Private Sub AccordionControl1_SelectedElementChanged(sender As Object, e As DevExpress.XtraBars.Navigation.SelectedElementChangedEventArgs) Handles AccordionControl1.SelectedElementChanged
        Dim sControlName As String = "" & e.Element.Tag
        If sControlName <> "" Then
            If Controls.ContainsKey("_" & sControlName) Then
                Call Controls("_" & sControlName).BringToFront()
                Controls("_" & sControlName).Visible = True
            End If
        End If
    End Sub

    Private Sub cboLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLanguage.SelectedIndexChanged
        Call pVisibilityByLanguage()
    End Sub

    Private Sub pVisibilityByLanguage()
        Dim bITVisible As Boolean = (cboLanguage.SelectedIndex = 0 AndAlso My.Application.CurrentLanguage = "it") OrElse (cboLanguage.SelectedIndex = 3)
        chkITChangeDecimalKey.Visible = bITVisible
        chkITChangePeriodKey.Visible = bITVisible
    End Sub

    Private Sub pFillPenPatternItems()
        Dim oList As List(Of UIHelpers.cNameAndValue) = New List(Of UIHelpers.cNameAndValue)
        oList.Add(New UIHelpers.cNameAndValue("underlyingcavepen", My.Application.Settings.GetSetting("design.penstylepattern.underlyingcavepen", "6.0 6.0"), "6.0 6.0"))
        oList.Add(New UIHelpers.cNameAndValue("toonarrowcavepen", My.Application.Settings.GetSetting("design.penstylepattern.toonarrowcavepen", "6.0 4.0"), "6.0 4.0"))
        oList.Add(New UIHelpers.cNameAndValue("presumedcavepen", My.Application.Settings.GetSetting("design.penstylepattern.presumedcavepen", "6.0 2.0"), "6.0 2.0"))
        tvDefaultPenPattern.DataSource = oList
    End Sub

    Private Sub txtDefaultPenPattern_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtDefaultPenPattern.ButtonClick
        Select Case e.Button.Index
            Case 0
                Dim oParameters As frmDashPatternEditor
                If pnlParameters.Controls.Count = 0 Then
                    oParameters = New frmDashPatternEditor()
                    pnlParameters.Controls.Add(oParameters)
                Else
                    oParameters = pnlParameters.Controls(0)
                End If
                flyParameters.OwnerControl = tvDefaultPenPattern
                oParameters.Dock = DockStyle.None

                Dim oValue As cNameAndValue = tvDefaultPenPattern.GetFocusedObject
                Dim sName As String = oValue.Name
                Call oParameters.Rebind(cDashPatternBindingList.StringToValues(oValue.Value), Sub(Values As Single())
                                                                                                  oValue.Value = cDashPatternBindingList.ValuesToString(Values)
                                                                                              End Sub)
                flyParameters.Size = oParameters.Size
                oParameters.Dock = DockStyle.Fill
                flyParameters.ShowBeakForm(True)
            Case 1
                Call DirectCast(tvDefaultPenPattern.GetFocusedObject, cNameAndValue).Reset()
        End Select

    End Sub

End Class
