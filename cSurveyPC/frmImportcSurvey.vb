Imports cSurveyPC.cSurvey

Public Class frmImportcSurvey

    Private Sub pSettingsLoad()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
                chkcSurveyImportData.Checked = oReg.GetValue("data.import.csurvey.data", 1)
                chkcSurveyImportDuplicates.Checked = oReg.GetValue("data.import.csurvey.duplicates", 1)
                chkcSurveyImportDuplicatesOverwrite.Checked = oReg.GetValue("data.import.csurvey.duplicates.overwrite", 0)
                chkcSurveyImportDuplicatesOverwriteOnlyUsed.Checked = oReg.GetValue("data.import.csurvey.duplicates.overwrite.onlyused", 0)
                cbocSurveyImportDuplicatesMode.SelectedIndex = oReg.GetValue("data.import.csurvey.duplicates.findmode", 0)
                chkcSurveyImportDuplicatesStations.Checked = oReg.GetValue("data.import.csurvey.duplicatesstations", 1)

                chkcSurveyImportGraphics.Checked = oReg.GetValue("data.import.csurvey.graphics", 1)
                chkcSurveyImportPlan.Checked = oReg.GetValue("data.import.csurvey.importplan", 1)
                chkcSurveyImportProfile.Checked = oReg.GetValue("data.import.csurvey.importprofile", 1)
                chkcSurveyImportSurface.Checked = oReg.GetValue("data.import.csurvey.importsurface", 1)
                chkcSurveyImportCaveBranchFromDesign.Checked = oReg.GetValue("data.import.csurvey.importcavebranchfromdesign", 1)

                cbocSurveyImportWarpingMode.SelectedIndex = oReg.GetValue("data.import.csurvey.warpingmode", 0)

                chkcSurveyImportDesignProperties.Checked = oReg.GetValue("data.import.csurvey.designproperties", 1)
                chkcSurveyImportScaleRules.Checked = oReg.GetValue("data.import.csurvey.scalerules", 1)

                chkcSurveyImportCreateNewBranch.Checked = oReg.GetValue("data.import.csurvey.createasnewbranch", 1)
                chkcSurveyImportUpdateCaveBranchPriority.Checked = oReg.GetValue("data.import.csurvey.updatepriority", 1)
                chkcSurveyDisableOriginAsExtendstart.Checked = oReg.GetValue("data.import.csurvey.disableoriginasextendstart", 0)
                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Private Sub pSettingsSave()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
                Call oReg.SetValue("data.import.csurvey.data", IIf(chkcSurveyImportData.Checked, 1, 0))
                Call oReg.SetValue("data.import.csurvey.duplicates", IIf(chkcSurveyImportDuplicates.Checked, 1, 0))
                Call oReg.SetValue("data.import.csurvey.duplicates.overwrite", IIf(chkcSurveyImportDuplicatesOverwrite.Checked, 1, 0))
                Call oReg.SetValue("data.import.csurvey.duplicates.overwrite.onlyused", IIf(chkcSurveyImportDuplicatesOverwriteOnlyUsed.Checked, 1, 0))
                Call oReg.SetValue("data.import.csurvey.duplicates.findmode", cbocSurveyImportDuplicatesMode.SelectedIndex)
                Call oReg.SetValue("data.import.csurvey.duplicatesstations", IIf(chkcSurveyImportDuplicatesStations.Checked, 1, 0))
                Call oReg.SetValue("data.import.csurvey.disableoriginasextendstart", IIf(chkcSurveyDisableOriginAsExtendstart.Checked, 1, 0))

                Call oReg.SetValue("data.import.csurvey.graphics", IIf(chkcSurveyImportGraphics.Checked, 1, 0))
                Call oReg.SetValue("data.import.csurvey.importplan", IIf(chkcSurveyImportPlan.Checked, 1, 0))
                Call oReg.SetValue("data.import.csurvey.importprofile", IIf(chkcSurveyImportProfile.Checked, 1, 0))
                Call oReg.SetValue("data.import.csurvey.importsurface", IIf(chkcSurveyImportSurface.Checked, 1, 0))
                Call oReg.SetValue("data.import.csurvey.importcavebranchfromdesign", IIf(chkcSurveyImportCaveBranchFromDesign.Checked, 1, 0))

                Call oReg.SetValue("data.import.csurvey.warpingmode", cbocSurveyImportWarpingMode.SelectedIndex)

                Call oReg.SetValue("data.import.csurvey.designproperties", IIf(chkcSurveyImportDesignProperties.Checked, 1, 0))
                Call oReg.SetValue("data.import.csurvey.scalerules", IIf(chkcSurveyImportScaleRules.Checked, 1, 0))

                Call oReg.SetValue("data.import.csurvey.createasnewbranch", IIf(chkcSurveyImportCreateNewBranch.Checked, 1, 0))
                Call oReg.SetValue("data.import.csurvey.updatepriority", IIf(chkcSurveyImportUpdateCaveBranchPriority.Checked, 1, 0))

                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Public Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()
        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Call pSettingsLoad()
    End Sub

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        Call pSettingsSave()
    End Sub

    Private Sub chkcSurveyImportGraphics_CheckedChanged(sender As Object, e As EventArgs) Handles chkcSurveyImportGraphics.CheckedChanged
        Dim bEnabled As Boolean = chkcSurveyImportGraphics.Checked
        chkcSurveyImportPlan.Enabled = bEnabled
        chkcSurveyImportProfile.Enabled = bEnabled
        chkcSurveyImportCaveBranchFromDesign.Enabled = bEnabled AndAlso chkcSurveyImportData.Enabled AndAlso Not chkcSurveyImportData.Checked
        lblcSurveyImportWarpingMode.Enabled = bEnabled
        cbocSurveyImportWarpingMode.Enabled = bEnabled
    End Sub

    Private Sub chkcSurveyImportData_CheckedChanged(sender As Object, e As EventArgs) Handles chkcSurveyImportData.CheckedChanged
        chkcSurveyImportCaveBranchFromDesign.Enabled = chkcSurveyImportGraphics.Checked AndAlso chkcSurveyImportData.Enabled AndAlso Not chkcSurveyImportData.Checked
        Dim bEnabled As Boolean = chkcSurveyImportData.Checked
        chkcSurveyImportDuplicates.Enabled = bEnabled
        lblcSurveyImportDuplicatesMode.Enabled = bEnabled
        cbocSurveyImportDuplicatesMode.Enabled = bEnabled
        chkcSurveyImportDuplicatesStations.Enabled = bEnabled
        chkImportAsBranchOf.Enabled = bEnabled
        cboImportAsBranchOfCave.Enabled = chkImportAsBranchOf.Checked And bEnabled
        cboImportAsBranchOfBranch.Enabled = chkImportAsBranchOf.Checked And bEnabled
        Call chkcSurveyImportDuplicates_CheckedChanged(Nothing, Nothing)
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

    Private Sub cboImportAsBranchOfCave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboImportAsBranchOfCave.SelectedIndexChanged
        Call cboImportAsBranchOfBranch.Rebind(CType(cboImportAsBranchOfCave.SelectedItem, cICaveInfoBranches), False)
    End Sub

    Private Sub chkcSurveyImportDuplicatesOverwrite_CheckedChanged(sender As Object, e As EventArgs) Handles chkcSurveyImportDuplicatesOverwrite.CheckedChanged
        chkcSurveyImportDuplicatesOverwriteOnlyUsed.Enabled = chkcSurveyImportDuplicatesOverwrite.Checked AndAlso chkcSurveyImportDuplicatesOverwrite.Enabled
    End Sub

End Class