friend Class frmImportPocketTopo

    Private Sub pSettingsLoad()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
                txtPrefix.Text = oReg.GetValue("data.import.pockettopo.prefix", "")
                txtCaveName.Text = oReg.GetValue("data.import.pockettopo.cavename", "")

                chkPocketTopoImportData.Checked = oReg.GetValue("data.import.pockettopo.importdata", 1)
                chkPocketTopoImportGraphics.Checked = oReg.GetValue("data.import.pockettopo.importgraphics", 0)
                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Private Sub pSettingsSave()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
                Call oReg.SetValue("data.import.pockettopo.prefix", txtPrefix.Text)
                Call oReg.SetValue("data.import.pockettopo.cavename", txtCaveName.Text)

                Call oReg.SetValue("data.import.pockettopo.importdata", IIf(chkPocketTopoImportData.Checked, 1, 0))
                Call oReg.SetValue("data.import.pockettopo.importgraphics", IIf(chkPocketTopoImportGraphics.Checked, 1, 0))
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