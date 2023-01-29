friend Class frmImportGPSTrack

    Private Sub pSettingsLoad()
        chkGPSImportWaypoint.Checked = My.Application.Settings.GetSetting("data.import.gps.importwaypoint", 1)
        cboGPSImportWaypointMode.SelectedIndex = My.Application.Settings.GetSetting("data.import.gps.waypointmode", 0)
        chkGPSImportCreateCaveForWaypoint.Checked = My.Application.Settings.GetSetting("data.import.gps.createcaveforwaypoint", 1)
        chkGPSImportCreateStationLinks.Checked = My.Application.Settings.GetSetting("data.import.gps.createstationlink", 1)
    End Sub

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("data.import.gps.importwaypoint", If(chkGPSImportWaypoint.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.gps.waypointmode", cboGPSImportWaypointMode.SelectedIndex)
        Call My.Application.Settings.SetSetting("data.import.gps.createcaveforwaypoint", If(chkGPSImportCreateCaveForWaypoint.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.gps.createstationlink", If(chkGPSImportCreateStationLinks.Checked, 1, 0))
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
End Class