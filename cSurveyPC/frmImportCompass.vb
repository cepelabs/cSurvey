friend Class frmImportCompass

    Private Sub pSettingsLoad()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
                txtPrefix.Text = oReg.GetValue("data.import.compass.prefix", "")
                chkCompassCreateBrachForSession.Checked = oReg.GetValue("data.import.compass.branchforsession", 1)
                chkCompassImportFlagX.Checked = oReg.GetValue("data.import.compass.importflagx", 1)
                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Private Sub pSettingsSave()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
                Call oReg.SetValue("data.import.compass.prefix", txtPrefix.Text)
                Call oReg.SetValue("data.import.compass.branchforsession", IIf(chkCompassCreateBrachForSession.Checked, 1, 0))
                Call oReg.SetValue("data.import.compass.importflagx", IIf(chkCompassImportFlagX.Checked, 1, 0))
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