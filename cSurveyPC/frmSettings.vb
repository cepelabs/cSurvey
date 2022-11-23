Imports BrendanGrant.Helpers.FileAssociation
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Net

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
        Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)

            Call oReg.SetValue("default.club", txtDefaultClub.Text)
            Call oReg.SetValue("default.team", txtDefaultTeam.Text)
            Call oReg.SetValue("default.designer", txtDefaultDesigner.Text)

            Call oReg.SetValue("default.calculatemode", If(chkCalculateMode.Checked, 1, 0))
            Call oReg.SetValue("default.calculatetype", cboDefaultCalculateType.SelectedIndex)

            Call oReg.SetValue("design.quality", Integer.Parse(cboDesignQuality.SelectedIndex))
            Call oReg.SetValue("design.rulers", If(chkDesignShowRulers.Checked, 1, 0))
            Call oReg.SetValue("design.rulers.style", cboDesignShowRulersStyle.SelectedIndex)
            Call oReg.SetValue("design.metricgrid", cboDesignShowMetricGrid.SelectedIndex)
            Call oReg.SetValue("design.metricgrid.opacity", txtDesignMetricGridOpacity.Value)
            Call oReg.SetValue("design.clipborder", cboDesignClipBorder.SelectedIndex)
            Call oReg.SetValue("design.linetype", cboDesignLineType.SelectedIndex)
            Call oReg.SetValue("design.useonlyanchortomove", If(chkDesignUseOnlyAnchorToMove.Checked, 1, 0))
            Call oReg.SetValue("design.selectionmode", cboDesignSelectionMode.SelectedIndex)
            Call oReg.SetValue("design.anchorscale", modNumbers.NumberToString(txtDesignAnchorScale.Value))
            Call oReg.SetValue("design.showlegacyextraprintandexportobjects", If(chkDesignShowLegacyExtraPrintAndExportObjects.Checked, 1, 0))

            Call oReg.SetValue("grid.shotsgrid.exportsplaynames", If(chkShotsGridExportSplayNames.Checked, 1, 0))

            Call oReg.SetValue("svg.importmaxpathlen", txtSVGImportPathMaxLen.Value)
            Call oReg.SetValue("svg.importscale", modNumbers.NumberToString(txtSVGImportScale.Value))
            Call oReg.SetValue("svg.importlinetype", cboSVGImportLineType.SelectedIndex)
            Call oReg.SetValue("svg.importautodivide", chkSVGImportAutodivide.Checked)

            'Call oReg.SetValue("svg.exportscale", modNumbers.NumberToString(txtSVGExportScale.Value))
            'Call oReg.SetValue("svg.exportdpi", txtSVGExportDPI.Value)
            Call oReg.SetValue("svg.exportnoclipartbrushes", If(chkSVGExportNoClipartBrushes.Checked, 1, 0))
            Call oReg.SetValue("svg.exportnoclipping", If(chkSVGExportNoClipping.Checked, 1, 0))
            Call oReg.SetValue("svg.exportcsurveyreferences", If(chkSVGExportcSurveyReference.Checked, 1, 0))
            Call oReg.SetValue("svg.exportimages", If(chkSVGExportImages.Checked, 1, 0))
            Call oReg.SetValue("svg.exporttextaspath", If(chkSVGExportTextAsPath.Checked, 1, 0))

            Call oReg.SetValue("therion.path", txtTherionPath.Text)
            Call oReg.SetValue("therion.lock.enabled", If(chkTherionLochEnabled.Checked, 1, 0))

            Call oReg.SetValue("therion.usecadastralidincavenames", If(chkTherionUseCadastralIDInCaveNames.Checked, 1, 0))
            Call oReg.SetValue("therion.backgroundprocess", If(chkTherionBackgroundProcess.Checked, 1, 0))
            Call oReg.SetValue("therion.trigpointsafename", If(chkTherionTrigpointSafename.Checked, 1, 0))
            Call oReg.SetValue("therion.deletetempfiles", If(chkTherionDeleteTempFiles.Checked, 1, 0))
            Call oReg.SetValue("therion.segmentforcedirection", If(chkTherionSegmentForceDirection.Checked, 1, 0))
            Call oReg.SetValue("therion.segmentforcepath", If(chkTherionSegmentForcePath.Checked, 1, 0))

            Call oReg.SetValue("environment.setdesigntoolsenabledbylevel", If(chkSetDesignToolsEnabledByLevel.Checked, 1, 0))
            Call oReg.SetValue("environment.setdesigntoolshiddenbylevel", If(chkSetDesignToolsHiddenByLevel.Checked, 1, 0))

            Dim oDefaultFont As cIFont = txtDefaultFont.Tag
            Call oReg.SetValue("design.defaultfont.name", oDefaultFont.FontName)
            Call oReg.SetValue("design.defaultfont.size", modNumbers.NumberToString(oDefaultFont.FontSize))
            Call oReg.SetValue("design.defaultfont.bold", If(oDefaultFont.FontBold, 1, 0))
            Call oReg.SetValue("design.defaultfont.italic", If(oDefaultFont.FontItalic, 1, 0))
            Call oReg.SetValue("design.defaultfont.underline", If(oDefaultFont.FontUnderline, 1, 0))

            Call oReg.SetValue("design.maxdrawitemcount", cboMaxDrawItemCount.Text)

            'Call oReg.SetValue("design.designbar.showlastusedtools", If(chkShowLastUsedToolsInDesignBar.Checked, 1, 0))
            Call oReg.SetValue("design.designbar.defaultposition", cboDesignBarPosition.SelectedIndex)
            'Call oReg.SetValue("design.designbar.size", cboDesignBarSize.SelectedIndex)

            Call oReg.SetValue("environment.alwaysuseshellforattachments", If(chkAlwaysUseShellForAttchments.Checked, 1, 0))

            Call oReg.SetValue("environment.functionlanguage", cboFunctionLanguage.SelectedIndex)

            Call oReg.SetValue("vtopo.importincompatibleset", If(chkVTopoImportIncompatibleSet.Checked, 1, 0))
            Call oReg.SetValue("vtopo.importsetasbranch", If(chkVTopoImportSetAsBranch.Checked, 1, 0))

            Call oReg.SetValue("zoom.type", cboDesignZoomType.SelectedIndex)

            Call oReg.SetValue("debug.log.verbose", If(chkLogVerbose.Checked, 1, 0))
            Call oReg.SetValue("debug.log.writeonfile", If(chkLogOnFile.Checked, 1, 0))
            Call oReg.SetValue("debug.log.maxlinecount", txtLogMaxLine.EditValue)
            Call oReg.SetValue("debug.forcegc", If(chkForceGarbaceCollect.Checked, 1, 0))

            Call oReg.SetValue("debug.autosave", If(chkAutosave.Checked, 1, 0))
            Call oReg.SetValue("debug.autosave.usehistorysettings", IIf(chkAutosaveUseHistorySettings.Checked, 1, 0))
            Call oReg.SetValue("debug.sendexception", If(chkSendException.Checked, 1, 0))
            Call oReg.SetValue("debug.checknewversion", If(chkCheckNewVersion.Checked, 1, 0))

            Call oReg.SetValue("clipboard.segments.extformats", pGetClipboardFormats("segments"))
            Call oReg.SetValue("clipboard.designitems.extformats", pGetClipboardFormats("designitems"))
            Call oReg.SetValue("clipboard.cleanpastedstation", If(chkClipboardCleanPastedStation.Checked, 1, 0))
            Call oReg.SetValue("clipboard.uselocalformat", If(chkClipboardLocalFormat.Checked, 1, 0))

            Call oReg.SetValue("history.enabled", If(chkHistory.Checked, 1, 0))
            Call oReg.SetValue("history.mode", cboHistoryMode.SelectedIndex)
            Call oReg.SetValue("history.web.authreq", If(chkHistoryWebAuthReq.Checked, "1", "0"))
            Call oReg.SetValue("history.web.url", txtHistoryWebURL.Text)
            Call oReg.SetValue("history.web.username", txtHistoryWebUsername.Text)
            Call oReg.SetValue("history.web.password", New cLocalSecurity("csurvey").EncryptData(txtHistoryWebPassword.Text))
            Call oReg.SetValue("history.web.maxdailycopies", txtHistoryWebDailyCopies.Value)
            Call oReg.SetValue("history.web.maxcopies", txtHistoryWebMaxCopies.Value)
            Call oReg.SetValue("history.folder", txtHistoryFolder.Text)
            Call oReg.SetValue("history.maxdailycopies", txtHistoryDailyCopies.Value)
            Call oReg.SetValue("history.maxcopies", txtHistoryMaxCopies.Value)
            Call oReg.SetValue("history.createonsave", If(chkHistoryArchiveOnSave.Checked, "1", "0"))
            Call oReg.SetValue("history.web.createonsave", If(chkHistoryWebArchiveOnSave.Checked, "1", "0"))

            Call oReg.SetValue("wms.cache.enabled", If(chkWMSCacheEnabled.Checked, "1", "0"))
            Call oReg.SetValue("wms.cache.maxsize", txtWMSCacheMaxSize.Value)

            Call oReg.SetValue("default.folder", txtDefaultFolder.Text)

            Call oReg.SetValue("linkedsurveys.selectonadd", If(chkLinkedSurveysSelectOnAdd.Checked, "1", "0"))
            Call oReg.SetValue("linkedsurveys.showincaveinfo", If(chkLinkedSurveysShowInCaveInfo.Checked, "1", "0"))
            Call oReg.SetValue("linkedsurveys.recursiveload", If(chkLinkedSurveysRecursiveLoad.Checked, "1", "0"))
            Call oReg.SetValue("linkedsurveys.recursiveload.prioritizechildren", If(chkLinkedSurveysRecursiveLoadPrioritizeChildren.Checked, "1", "0"))
            Call oReg.SetValue("linkedsurveys.refreshonload", If(chkLinkedSurveysRefreshOnLoad.Checked, "1", "0"))

            Select Case cboLanguage.SelectedIndex
                Case 0
                    Call oReg.DeleteValue("language", False)
                Case 1
                    Call oReg.SetValue("language", "en")
                Case 2
                    Call oReg.SetValue("language", "ru")
                Case 3
                    Call oReg.SetValue("language", "it")
            End Select

            Call oReg.SetValue("keys.changedecimalkey", If(chkITChangeDecimalKey.Checked, "1", "0"))
            Call oReg.SetValue("keys.changeperiodkey", If(chkITChangePeriodKey.Checked, "1", "0"))

            Call oReg.Close()
        End Using
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

        'preparo la tab delle impostazioni di history
        oTabHistory0 = tabHistorySettings.TabPages(0)
        oTabHistory1 = tabHistorySettings.TabPages(1)
        Call tabHistorySettings.TabPages.Clear()

        'leggo i valori dal registro
        Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
            Dim bFirstRun As Boolean = oReg.ValueCount = 0

            txtDefaultClub.Text = oReg.GetValue("default.club", "")
            txtDefaultTeam.Text = oReg.GetValue("default.team", "")
            txtDefaultDesigner.Text = oReg.GetValue("default.designer", "")

            chkCalculateMode.Checked = IIf(oReg.GetValue("default.calculatemode", 0) = cSurvey.cSurvey.CalculateModeEnum.Automatic, True, False)
            cboDefaultCalculateType.SelectedIndex = oReg.GetValue("default.calculatetype", cSurvey.cSurvey.CalculateTypeEnum.Therion)

            cboDesignMode.SelectedIndex = 0
            cboDesignQuality.SelectedIndex = oReg.GetValue("design.quality", 0)
            chkDesignShowRulers.Checked = oReg.GetValue("design.rulers", 1)
            cboDesignShowRulersStyle.SelectedIndex = oReg.GetValue("design.rulers.style", frmMain2.RulersStyleEnum.Simple)
            cboDesignShowMetricGrid.SelectedIndex = oReg.GetValue("design.metricgrid", 0)
            txtDesignMetricGridOpacity.Value = oReg.GetValue("design.metricgrid.opacity", 50)
            cboDesignClipBorder.SelectedIndex = oReg.GetValue("design.clipborder", cSurvey.Design.cClippingRegions.ClipBorderEnum.ClipBorder)
            cboDesignLineType.SelectedIndex = oReg.GetValue("design.linetype", cSurvey.Design.Items.cIItemLine.LineTypeEnum.Splines)
            chkDesignUseOnlyAnchorToMove.Checked = oReg.GetValue("design.useonlyanchortomove", 1)
            cboDesignSelectionMode.SelectedIndex = oReg.GetValue("design.selectionmode", 0)
            txtDesignAnchorScale.Value = modNumbers.StringToSingle(oReg.GetValue("design.anchorscale", 1))
            chkDesignShowLegacyExtraPrintAndExportObjects.Checked = oReg.GetValue("design.showlegacyextraprintandexportobjects", Not bFirstRun)

            chkShotsGridExportSplayNames.Checked = oReg.GetValue("grid.shotsgrid.exportsplaynames", 1)

            'chkShowLastUsedToolsInDesignBar.Checked = oReg.GetValue("design.designbar.showlastusedtools", 1)
            cboDesignBarPosition.SelectedIndex = oReg.GetValue("design.designbar.defaultposition", 0)
            ' cboDesignBarSize.SelectedIndex = oReg.GetValue("design.designbar.size", 0)

            cboMaxDrawItemCount.Text = oReg.GetValue("design.maxdrawitemcount", 20)

            txtSVGImportPathMaxLen.Value = oReg.GetValue("svg.importmaxpathlen", 2000)
            txtSVGImportScale.Value = modNumbers.StringToDecimal(oReg.GetValue("svg.importscale", 0.05))
            cboSVGImportLineType.SelectedIndex = oReg.GetValue("svg.importlinetype", cSurvey.Design.Items.cIItemLine.LineTypeEnum.Splines)
            chkSVGImportAutodivide.Checked = oReg.GetValue("svg.importautodivide", False)

            'txtSVGExportScale.Value = modNumbers.StringToDecimal(oReg.GetValue("svg.exportscale", 1))
            chkSVGExportNoClipartBrushes.Checked = oReg.GetValue("svg.exportnoclipartbrushes", 0)
            chkSVGExportNoClipping.Checked = oReg.GetValue("svg.exportnoclipping", 0)
            chkSVGExportcSurveyReference.Checked = oReg.GetValue("svg.exportcsurveyreferences", 1)
            chkSVGExportImages.Checked = oReg.GetValue("svg.exportimages", 1)
            chkSVGExportTextAsPath.Checked = oReg.GetValue("svg.exporttextaspath", 0)

            'txtSVGExportDPI.Value = oReg.GetValue("svg.exportdpi", 90)
            txtTherionPath.Text = oReg.GetValue("therion.path", "")
            chkTherionLochEnabled.Checked = oReg.GetValue("therion.loch.enabled", 1)
            chkTherionUseCadastralIDInCaveNames.Checked = oReg.GetValue("therion.usecadastralidincavenames", 0)
            chkTherionBackgroundProcess.Checked = oReg.GetValue("therion.backgroundprocess", 1)
            chkTherionTrigpointSafename.Checked = oReg.GetValue("therion.trigpointsafename", 1)
            chkTherionDeleteTempFiles.Checked = oReg.GetValue("therion.deletetempfiles", 1)
            chkTherionSegmentForceDirection.Checked = oReg.GetValue("therion.segmentforcedirection", 1)
            chkTherionSegmentForcePath.Checked = oReg.GetValue("therion.segmentforcepath", 1)

            cboDesignZoomType.SelectedIndex = oReg.GetValue("zoom.type", 1)

            chkSetDesignToolsEnabledByLevel.Checked = oReg.GetValue("environment.setdesigntoolsenabledbylevel", 1)
            Call chkSetDesignToolsEnabledByLevel_CheckedChanged(Nothing, Nothing)
            chkSetDesignToolsHiddenByLevel.Checked = oReg.GetValue("environment.setdesigntoolshiddenbylevel", 0)
            Dim oDefaultFont As cIFont = modPaint.GetDefaultFont  'New cFont(Nothing, oReg.GetValue("design.defaultfont.name", "Segoe UI"), modNumbers.StringToSingle(oReg.GetValue("design.defaultfont.size", 8.0F)), Color.Black, oReg.GetValue("design.defaultfont.bold", 0), oReg.GetValue("design.defaultfont.italic", 0), oReg.GetValue("design.defaultfont.underline", 0))
            txtDefaultFont.Tag = oDefaultFont
            txtDefaultFont.Text = oDefaultFont.ToString

            chkAlwaysUseShellForAttchments.Checked = oReg.GetValue("environment.alwaysuseshellforattachments", 0)

            cboFunctionLanguage.SelectedIndex = oReg.GetValue("environment.functionlanguage", 0)

            chkVTopoImportIncompatibleSet.Checked = oReg.GetValue("vtopo.importincompatibleset", 0)
            chkVTopoImportSetAsBranch.Checked = oReg.GetValue("vtopo.importsetasbranch", 1)

            chkLogVerbose.Checked = oReg.GetValue("debug.log.verbose", 0)
            chkLogOnFile.Checked = oReg.GetValue("debug.log.writeonfile", 0)
            txtLogMaxLine.EditValue = oReg.GetValue("debug.log.maxlinecount", 512)
            chkForceGarbaceCollect.Checked = oReg.GetValue("debug.forcegc", 0)

            chkAutosave.Checked = oReg.GetValue("debug.autosave", 0)
            chkAutosaveUseHistorySettings.Checked = oReg.GetValue("debug.autosave.usehistorysettings", 0)
            chkSendException.Checked = oReg.GetValue("debug.sendexception", 0)
            chkCheckNewVersion.Checked = oReg.GetValue("debug.checknewversion", 0)
            txtMachineID.Text = oReg.GetValue("debug.machineid", "")

            Call pSetClipboardFormats("segments", oReg.GetValue("clipboard.segments.extformats", ""))
            Call pSetClipboardFormats("designitems", oReg.GetValue("clipboard.designitems.extformats", ""))
            chkClipboardCleanPastedStation.Checked = oReg.GetValue("clipboard.cleanpastedstation", 0)
            chkClipboardLocalFormat.Checked = oReg.GetValue("clipboard.uselocalformat", 0)

            chkHistory.Checked = oReg.GetValue("history.enabled", 0)
            cboHistoryMode.SelectedIndex = oReg.GetValue("history.mode", 0)
            txtHistoryWebURL.Text = oReg.GetValue("history.web.url", "")
            chkHistoryWebAuthReq.Checked = oReg.GetValue("history.web.authreq", "0")
            txtHistoryWebUsername.Text = oReg.GetValue("history.web.username", "")
            Dim sHistoryWebPassword As String = oReg.GetValue("history.web.password", "")
            If sHistoryWebPassword <> "" Then
                txtHistoryWebPassword.Text = New cLocalSecurity("csurvey").DecryptData(sHistoryWebPassword)
            End If
            txtHistoryWebDailyCopies.Value = oReg.GetValue("history.web.maxdailycopies", 4)
            txtHistoryWebMaxCopies.Value = oReg.GetValue("history.web.maxcopies", 20)
            txtHistoryFolder.Text = oReg.GetValue("history.folder", "")
            txtHistoryDailyCopies.Value = oReg.GetValue("history.maxdailycopies", 4)
            txtHistoryMaxCopies.Value = oReg.GetValue("history.maxcopies", 20)
            chkHistoryArchiveOnSave.Checked = oReg.GetValue("history.createonsave", "0")
            chkHistoryWebArchiveOnSave.Checked = oReg.GetValue("history.web.createonsave", "0")

            txtDefaultFolder.Text = oReg.GetValue("default.folder", "")

            chkWMSCacheEnabled.Checked = oReg.GetValue("wms.cache.enabled", 1)
            txtWMSCacheMaxSize.Value = oReg.GetValue("wms.cache.maxsize", 512)

            chkLinkedSurveysSelectOnAdd.Checked = oReg.GetValue("linkedsurveys.selectonadd", "0")
            chkLinkedSurveysShowInCaveInfo.Checked = oReg.GetValue("linkedsurveys.showincaveinfo", "1")
            chkLinkedSurveysRecursiveLoad.Checked = oReg.GetValue("linkedsurveys.recursiveload", "1")
            chkLinkedSurveysRecursiveLoadPrioritizeChildren.Checked = oReg.GetValue("linkedsurveys.recursiveload.prioritizechildren", "0")
            chkLinkedSurveysRefreshOnLoad.Checked = oReg.GetValue("linkedsurveys.refreshonload", "1")

            Dim sLanguage As String = oReg.GetValue("language", "")
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

            chkITChangeDecimalKey.Checked = oReg.GetValue("keys.changedecimalkey", "1")
            chkITChangePeriodKey.Checked = oReg.GetValue("keys.changeperiodkey", "0")

            Call oReg.Close()
        End Using

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
        Call pVisibilityByLanguage
    End Sub

    Private Sub pVisibilityByLanguage()
        Dim bITVisible As Boolean = (cboLanguage.SelectedIndex = 0 AndAlso My.Application.CurrentLanguage = "it") OrElse (cboLanguage.SelectedIndex = 3)
        chkITChangeDecimalKey.Visible = bITVisible
        chkITChangePeriodKey.Visible = bITVisible
    End Sub
End Class
