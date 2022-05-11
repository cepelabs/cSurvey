friend Class frmExportExcel

    Private Sub pSettingsLoad()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
                chkExportCalculatedData.Checked = oReg.GetValue("data.export.excel.calculateddata", "1")
                chkExportColor.Checked = oReg.GetValue("data.export.excel.color", "0")
                chkExportNamedSplayStations.Checked = oReg.GetValue("data.export.excel.splaystations", "0")
                chkExportNamedSplayStationsData.Checked = oReg.GetValue("data.export.excel.splaystationsdata", "0")
                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Private Sub pSettingsSave()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
                Call oReg.SetValue("data.export.excel.calculateddata", If(chkExportCalculatedData.Checked, "1", "0"))
                Call oReg.SetValue("data.export.excel.color", If(chkExportColor.Checked, "1", "0"))
                Call oReg.SetValue("data.export.excel.splaystations", If(chkExportNamedSplayStations.Checked, "1", "0"))
                Call oReg.SetValue("data.export.excel.splaystationsdata", If(chkExportNamedSplayStationsData.Checked, "1", "0"))
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

    Private Sub chkExportNamedSplayStations_CheckedChanged(sender As Object, e As EventArgs) Handles chkExportNamedSplayStations.CheckedChanged
        chkExportNamedSplayStationsData.Enabled = chkExportNamedSplayStations.Checked
    End Sub
End Class