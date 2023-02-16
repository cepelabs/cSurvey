Imports cSurveyPC.cSurvey
Imports DevExpress.XtraTreeList

Friend Class frmImportcSurvey

    Public Sub AppendLog(Text As String, Imagename As String)
        tvLog.BeginUpdate()
        Dim oData() As Object = {Text, Imagename}
        Dim oNode As Nodes.TreeListNode = tvLog.Nodes.Add(oData)
        tvLog.FocusedNode = oNode
        tvLog.MakeNodeVisible(oNode)
        tvLog.EndUpdate()
    End Sub

    Private Sub pSettingsLoad()
        chkcSurveyImportData.Checked = My.Application.Settings.GetSetting("data.import.csurvey.data", 1)
        chkcSurveyImportDuplicates.Checked = My.Application.Settings.GetSetting("data.import.csurvey.duplicates", 1)
        chkcSurveyImportDuplicatesOverwrite.Checked = My.Application.Settings.GetSetting("data.import.csurvey.duplicates.overwrite", 0)
        chkcSurveyImportDuplicatesOverwriteOnlyUsed.Checked = My.Application.Settings.GetSetting("data.import.csurvey.duplicates.overwrite.onlyused", 0)
        cbocSurveyImportDuplicatesMode.SelectedIndex = My.Application.Settings.GetSetting("data.import.csurvey.duplicates.findmode", 0)
        chkcSurveyImportDuplicatesStations.Checked = My.Application.Settings.GetSetting("data.import.csurvey.duplicatesstations", 1)

        chkcSurveyImportGraphics.Checked = My.Application.Settings.GetSetting("data.import.csurvey.graphics", 1)
        chkcSurveyImportPlan.Checked = My.Application.Settings.GetSetting("data.import.csurvey.importplan", 1)
        chkcSurveyImportProfile.Checked = My.Application.Settings.GetSetting("data.import.csurvey.importprofile", 1)
        chkcSurveyImportSurface.Checked = My.Application.Settings.GetSetting("data.import.csurvey.importsurface", 1)
        chkcSurveyImportCaveBranchFromDesign.Checked = My.Application.Settings.GetSetting("data.import.csurvey.importcavebranchfromdesign", 1)

        cbocSurveyImportWarpingMode.SelectedIndex = My.Application.Settings.GetSetting("data.import.csurvey.warpingmode", 0)

        chkcSurveyImportDesignProperties.Checked = My.Application.Settings.GetSetting("data.import.csurvey.designproperties", 1)
        chkcSurveyImportScaleRules.Checked = My.Application.Settings.GetSetting("data.import.csurvey.scalerules", 1)

        chkcSurveyImportCreateNewBranch.Checked = My.Application.Settings.GetSetting("data.import.csurvey.createasnewbranch", 1)
        chkcSurveyImportUpdateCaveBranchPriority.Checked = My.Application.Settings.GetSetting("data.import.csurvey.updatepriority", 1)
        chkcSurveyDisableOriginAsExtendstart.Checked = My.Application.Settings.GetSetting("data.import.csurvey.disableoriginasextendstart", 0)

        chkcsurveyimportlinkedsurvey.Checked = My.Application.Settings.GetSetting("data.import.csurvey.linkedsurvey", 1)
    End Sub

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("data.import.csurvey.data", If(chkcSurveyImportData.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.csurvey.duplicates", If(chkcSurveyImportDuplicates.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.csurvey.duplicates.overwrite", If(chkcSurveyImportDuplicatesOverwrite.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.csurvey.duplicates.overwrite.onlyused", If(chkcSurveyImportDuplicatesOverwriteOnlyUsed.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.csurvey.duplicates.findmode", cbocSurveyImportDuplicatesMode.SelectedIndex)
        Call My.Application.Settings.SetSetting("data.import.csurvey.duplicatesstations", If(chkcSurveyImportDuplicatesStations.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.csurvey.disableoriginasextendstart", If(chkcSurveyDisableOriginAsExtendstart.Checked, 1, 0))

        Call My.Application.Settings.SetSetting("data.import.csurvey.graphics", If(chkcSurveyImportGraphics.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.csurvey.importplan", If(chkcSurveyImportPlan.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.csurvey.importprofile", If(chkcSurveyImportProfile.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.csurvey.importsurface", If(chkcSurveyImportSurface.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.csurvey.importcavebranchfromdesign", If(chkcSurveyImportCaveBranchFromDesign.Checked, 1, 0))

        Call My.Application.Settings.SetSetting("data.import.csurvey.warpingmode", cbocSurveyImportWarpingMode.SelectedIndex)

        Call My.Application.Settings.SetSetting("data.import.csurvey.designproperties", If(chkcSurveyImportDesignProperties.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.csurvey.scalerules", If(chkcSurveyImportScaleRules.Checked, 1, 0))

        Call My.Application.Settings.SetSetting("data.import.csurvey.createasnewbranch", If(chkcSurveyImportCreateNewBranch.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.csurvey.updatepriority", If(chkcSurveyImportUpdateCaveBranchPriority.Checked, 1, 0))

        Call My.Application.Settings.SetSetting("data.import.csurvey.linkedsurvey", If(chkcsurveyimportlinkedsurvey.Checked, 1, 0))
    End Sub

    Private oSurvey As cSurvey.cSurvey

    Public Sub New(Survey As cSurvey.cSurvey)
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()
        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        osurvey = Survey
        Call pSettingsLoad()
    End Sub

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        Call pSettingsSave()
    End Sub

    Private Sub pImportGraphicsChanged()
        Dim bEnabled As Boolean = chkcSurveyImportGraphics.Checked AndAlso chkcSurveyImportGraphics.Enabled
        pnlcSurveyImportGraphics.Enabled = bEnabled

        chkcSurveyImportPlan.Enabled = bEnabled
        chkcSurveyImportProfile.Enabled = bEnabled
        chkcSurveyImportCaveBranchFromDesign.Enabled = bEnabled AndAlso chkcSurveyImportData.Enabled AndAlso Not chkcSurveyImportData.Checked
        lblcSurveyImportWarpingMode.Enabled = bEnabled
        cbocSurveyImportWarpingMode.Enabled = bEnabled
    End Sub

    Private Sub chkcSurveyImportGraphics_CheckedChanged(sender As Object, e As EventArgs) Handles chkcSurveyImportGraphics.CheckedChanged
        Call pImportGraphicsChanged()
    End Sub

    Private Sub pImportDataChanged()
        chkcSurveyImportCaveBranchFromDesign.Enabled = chkcSurveyImportGraphics.Checked AndAlso chkcSurveyImportData.Enabled AndAlso Not chkcSurveyImportData.Checked
        Dim bEnabled As Boolean = chkcSurveyImportData.Checked AndAlso chkcSurveyImportData.Enabled
        pnlcSurveyImportData.Enabled = bEnabled

        chkcSurveyImportDuplicates.Enabled = bEnabled
        lblcSurveyImportDuplicatesMode.Enabled = bEnabled
        cbocSurveyImportDuplicatesMode.Enabled = bEnabled
        chkcSurveyImportDuplicatesStations.Enabled = bEnabled
        chkImportAsBranchOf.Enabled = bEnabled
        cboImportAsBranchOfCave.Enabled = chkImportAsBranchOf.Checked And bEnabled
        cboImportAsBranchOfBranch.Enabled = chkImportAsBranchOf.Checked And bEnabled
        Call chkcSurveyImportDuplicates_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub chkcSurveyImportData_CheckedChanged(sender As Object, e As EventArgs) Handles chkcSurveyImportData.CheckedChanged
        Call pImportDataChanged()
    End Sub

    Private Sub chkcSurveyImportDuplicates_CheckedChanged(sender As Object, e As EventArgs) Handles chkcSurveyImportDuplicates.CheckedChanged
        Dim bDuplicatesEnabled As Boolean = chkcSurveyImportDuplicates.Enabled And chkcSurveyImportDuplicates.Checked
        chkcSurveyImportDuplicatesOverwrite.Enabled = bDuplicatesEnabled
        chkcSurveyImportDuplicatesOverwriteOnlyUsed.Enabled = chkcSurveyImportDuplicatesOverwrite.Checked AndAlso bDuplicatesEnabled
    End Sub

    Private Sub chkImportAsBranchOf_CheckedChanged(sender As Object, e As EventArgs) Handles chkImportAsBranchOf.CheckedChanged
        cboImportAsBranchOfCave.Enabled = chkImportAsBranchOf.Checked
        cboImportAsBranchOfBranch.Enabled = chkImportAsBranchOf.Checked
    End Sub

    Private Sub chkcSurveyImportDuplicatesOverwrite_CheckedChanged(sender As Object, e As EventArgs) Handles chkcSurveyImportDuplicatesOverwrite.CheckedChanged
        chkcSurveyImportDuplicatesOverwriteOnlyUsed.Enabled = chkcSurveyImportDuplicatesOverwrite.Checked AndAlso chkcSurveyImportDuplicatesOverwrite.Enabled
    End Sub

    Private Sub chkcSurveyImportData_EnabledChanged(sender As Object, e As EventArgs) Handles chkcSurveyImportData.EnabledChanged
        Call pImportDataChanged()
    End Sub

    Private Sub chkcSurveyImportGraphics_EnabledChanged(sender As Object, e As EventArgs) Handles chkcSurveyImportGraphics.EnabledChanged
        Call pImportGraphicsChanged()
    End Sub

    Private Sub frmImportcSurvey_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call pImportDataChanged()
        Call pImportGraphicsChanged()
    End Sub

    Private Sub tvLog_CustomDrawNodeImages(sender As Object, e As CustomDrawNodeImagesEventArgs) Handles tvLog.CustomDrawNodeImages
        Select Case e.Node.Item(1)
            Case "ok"
                e.SelectImageIndex = 0
            Case "warning"
                e.SelectImageIndex = 1
            Case "error"
                e.SelectImageIndex = 2
            Case "source"
                e.SelectImageIndex = 3
        End Select
    End Sub

    Private Sub cboImportAsBranchOfCave_EditValueChanged(sender As Object, e As EventArgs) Handles cboImportAsBranchOfCave.EditValueChanged
        Dim oCave As cCaveInfo = cboImportAsBranchOfCave.EditValue
        Dim oBranch As cCaveInfoBranch = cboImportAsBranchOfBranch.EditValue
        Dim sCave As String = "" & If(cboImportAsBranchOfCave.EditValue Is Nothing, "", cboImportAsBranchOfCave.EditValue.Name)
        Dim sCurrentBranch As String = "" & If(cboImportAsBranchOfBranch.EditValue Is Nothing, "", cboImportAsBranchOfBranch.EditValue.Path)
        Call cboImportAsBranchOfBranch.Rebind(oSurvey, cboImportAsBranchOfCave, True)
    End Sub
End Class