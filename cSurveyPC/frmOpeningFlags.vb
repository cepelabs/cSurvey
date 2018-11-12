Public Class frmOpeningFlags
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        cboDesignWarpingMode.SelectedIndex = 1
    End Sub

    Private Sub chkMorphingDisableEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles chkMorphingDisableEnabled.CheckedChanged
        chkMorphingDisable.Enabled = chkMorphingDisableEnabled.Checked
    End Sub

    Private Sub chkDesignWarpingModeEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignWarpingModeEnabled.CheckedChanged
        lblDesignWarpingMode.Enabled = chkDesignWarpingModeEnabled.Checked
        cboDesignWarpingMode.Enabled = chkDesignWarpingModeEnabled.Checked
        lblDesignWarpingModeEnabledIn.Enabled = chkDesignWarpingModeEnabled.Checked
        chkPlanWarpingEnabled.Enabled = chkDesignWarpingModeEnabled.Checked
        chkProfileWarpingEnabled.Enabled = chkDesignWarpingModeEnabled.Checked
    End Sub

    Private Sub chkCalculateModeEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles chkCalculateModeEnabled.CheckedChanged
        chkCalculateMode.Enabled = chkCalculateModeEnabled.Checked
    End Sub

    Private Sub chkUpgradeCalculateVersionEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles chkUpgradeCalculateVersionEnabled.CheckedChanged
        chkUpgradeCalculateVersion.Enabled = chkUpgradeCalculateVersionEnabled.Checked
        Call pUpgradeInversionModeCheckFlags()
    End Sub

    Private Sub chkUpgradeInversionModeEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles chkUpgradeInversionModeEnabled.CheckedChanged
        Call pUpgradeInversionModeCheckFlags()
    End Sub

    Private Sub chkUpgradeCalculateVersion_CheckedChanged(sender As Object, e As EventArgs) Handles chkUpgradeCalculateVersion.CheckedChanged
        Call pUpgradeInversionModeCheckFlags()
    End Sub

    Private Sub pUpgradeInversionModeCheckFlags()
        Dim bEnabled As Boolean = Not chkUpgradeCalculateVersion.Enabled OrElse (chkUpgradeCalculateVersion.Enabled AndAlso Not chkUpgradeCalculateVersion.Checked)
        chkUpgradeInversionModeEnabled.Enabled = bEnabled
        chkUpgradeInversionMode.Enabled = chkUpgradeInversionModeEnabled.Checked AndAlso bEnabled
    End Sub

    Private Sub chkRegenerateSegmentsIDEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles chkRegenerateSegmentsIDEnabled.CheckedChanged
        chkRegenerateSegmentsID.Enabled = chkRegenerateSegmentsIDEnabled.Checked
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click

    End Sub
End Class