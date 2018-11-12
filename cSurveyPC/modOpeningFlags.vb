Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.cSurvey

Module modOpeningFlags

    Public OFCalculateModeEnabled As Boolean
    Public OFCalculateMode As CalculateModeEnum

    Public OFDesignWarpingModeEnabled As Boolean
    Public OFDesignWarpingMode As DesignWarpingModeEnum
    Public OFDesignWarlingPlanDisable As Boolean
    Public OFDesignWarlingProfileDisable As Boolean

    Public OFMorphingDisabledEnabled As Boolean
    Public OFMorphingDisabled As Boolean

    Public OFUpgradeCalculateVersion As Boolean
    Public OFUpgradeInversionMode As Boolean

    Public OFRegenerateSegmentsID As Boolean

    Public Sub SetFlags(Optional Parent As IWin32Window = Nothing)
        If My.Computer.Keyboard.ShiftKeyDown And My.Computer.Keyboard.CtrlKeyDown Then
            Dim frmOF As frmOpeningFlags = New frmOpeningFlags
            If frmOF.ShowDialog() = DialogResult.OK Then
                OFCalculateModeEnabled = frmOF.chkCalculateModeEnabled.Checked
                If frmOF.chkCalculateMode.Checked Then
                    OFCalculateMode = CalculateModeEnum.Automatic
                Else
                    OFCalculateMode = CalculateModeEnum.Manual
                End If
                OFDesignWarpingModeEnabled = frmOF.chkDesignWarpingModeEnabled.Checked
                OFDesignWarpingMode = frmOF.cboDesignWarpingMode.SelectedIndex
                OFDesignWarlingPlanDisable = Not frmOF.chkPlanWarpingEnabled.Checked
                OFDesignWarlingProfileDisable = Not frmOF.chkProfileWarpingEnabled.Checked
                OFMorphingDisabledEnabled = frmOF.chkMorphingDisableEnabled.Checked
                OFMorphingDisabled = frmOF.chkMorphingDisable.Checked
                OFUpgradeCalculateVersion = frmOF.chkUpgradeCalculateVersion.Checked
                If frmOF.chkUpgradeInversionMode.Enabled Then
                    OFUpgradeInversionMode = frmOF.chkUpgradeInversionMode.Checked
                End If
                OFRegenerateSegmentsID = frmOF.chkRegenerateSegmentsID.Checked
            End If
            End If
    End Sub

    Public Sub ResetFlags()
        OFCalculateModeEnabled = False
        OFDesignWarpingModeEnabled = False
        OFMorphingDisabledEnabled = False
    End Sub

End Module
