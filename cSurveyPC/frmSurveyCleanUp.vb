friend Class frmSurveyCleanUp
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call pSettingsLoad()
    End Sub

    Private Sub chkPointReduction_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPointReduction.CheckedChanged
        txtDesignPointReductionFactor.Enabled = chkDesignPointReduction.Checked
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Call pSettingsSave()
    End Sub

    Private Sub pSettingsLoad()
        chkDesignPointReduction.Checked = My.Application.Settings.GetSetting("check.design.pointreduction", 1)
        txtDesignPointReductionFactor.EditValue = modNumbers.StringToSingle(My.Application.Settings.GetSetting("check.design.pointreduction.factor", 0.02))
        chkDesignPointsCleanUp.Checked = My.Application.Settings.GetSetting("check.design.pointscleanup", 1)
        chkDesignCaveBranchCheck.Checked = My.Application.Settings.GetSetting("check.design.cavebranchcheck", 1)
        chkDesignClipart.Checked = My.Application.Settings.GetSetting("check.design.clipart", 1)
        chkDesignSign.Checked = My.Application.Settings.GetSetting("check.design.sign", 1)
        cboDesignContext.SelectedIndex = My.Application.Settings.GetSetting("check.design.context", 0)
        chkPlotSegments.Checked = My.Application.Settings.GetSetting("check.plotsegments", 1)
        chkSplayFlagsAndNames.Checked = My.Application.Settings.GetSetting("check.splayflagsandnames", 1)
        chkSplayNames.Checked = My.Application.Settings.GetSetting("check.splaynames", 1)
        chkDesignRemoveInvalidItem.Checked = My.Application.Settings.GetSetting("check.design.removeinvaliditem", 1)
        chkDesignConnectToCheck.Checked = My.Application.Settings.GetSetting("check.design.connecttocheck", 1)
    End Sub

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("check.design.pointreduction", If(chkDesignPointReduction.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("check.design.pointreduction.factor", modNumbers.NumberToString(txtDesignPointReductionFactor.EditValue))
        Call My.Application.Settings.SetSetting("check.design.pointscleanup", If(chkDesignPointsCleanUp.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("check.design.cavebranchcheck", If(chkDesignCaveBranchCheck.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("check.design.clipart", If(chkDesignClipart.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("check.design.sign", If(chkDesignSign.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("check.plotsegments", If(chkPlotSegments.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("check.design.context", cboDesignContext.SelectedIndex)
        Call My.Application.Settings.SetSetting("check.splayflagsandnames", If(chkSplayFlagsAndNames.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("check.splaynames", If(chkSplayNames.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("check.design.removeinvaliditem", If(chkDesignRemoveInvalidItem.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("check.design.connecttocheck", If(chkDesignConnectToCheck.Checked, 1, 0))
    End Sub
End Class