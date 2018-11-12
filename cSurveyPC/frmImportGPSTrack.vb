Public Class frmImportGPSTrack

    Private Sub pSettingsLoad()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
                chkGPSImportWaypoint.Checked = oReg.GetValue("data.import.gps.importwaypoint", 1)
                cboGPSImportWaypointMode.SelectedIndex = oReg.GetValue("data.import.gps.waypointmode", 0)
                chkGPSImportCreateCaveForWaypoint.Checked = oReg.GetValue("data.import.gps.createcaveforwaypoint", 1)
                chkGPSImportCreateStationLinks.Checked = oReg.GetValue("data.import.gps.createstationlink", 1)
                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Private Sub pSettingsSave()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
                Call oReg.SetValue("data.import.gps.importwaypoint", IIf(chkGPSImportWaypoint.Checked, 1, 0))
                Call oReg.SetValue("data.import.gps.waypointmode", cboGPSImportWaypointMode.SelectedIndex)
                Call oReg.SetValue("data.import.gps.createcaveforwaypoint", IIf(chkGPSImportCreateCaveForWaypoint.Checked, 1, 0))
                Call oReg.SetValue("data.import.gps.createstationlink", IIf(chkGPSImportCreateStationLinks.Checked, 1, 0))
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
End Class