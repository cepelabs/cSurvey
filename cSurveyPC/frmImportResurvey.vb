friend Class frmImportResurvey

    Private Sub pSettingsLoad()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
                txtPrefix.Text = oReg.GetValue("data.import.resurvey.prefix", "")
                txtCaveName.Text = oReg.GetValue("data.import.resurvey.cavename", "")
                cboNordType.SelectedIndex = oReg.GetValue("data.import.resurvey.nordtype", 0)
                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Private Sub pSettingsSave()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
                Call oReg.SetValue("data.import.resurvey.prefix", txtPrefix.Text)
                Call oReg.SetValue("data.import.resurvey.cavename", txtCaveName.Text)
                Call oReg.SetValue("data.import.resurvey.nordtype", cboNordType.SelectedIndex)
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