Public Class frmExportHolos

    Private Sub pSettingsLoad()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
                cboExportProfile.SelectedIndex = oReg.GetValue("data.export.holos.profile", "0")
                chkExportLRUD.Checked = oReg.GetValue("data.export.holos.LRUD", "0")
                chkExportSurface.Checked = oReg.GetValue("data.export.holos.surface", "0")
                chkExportColors.Checked = oReg.GetValue("data.export.holos.colors", "0")
                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Private Sub pSettingsSave()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
                Call oReg.SetValue("data.export.holos.profile", cboExportProfile.SelectedIndex)
                Call oReg.SetValue("data.export.holos.LRUD", IIf(chkExportLRUD.Checked, "1", "0"))
                Call oReg.SetValue("data.export.holos.surface", IIf(chkExportSurface.Checked, "1", "0"))
                Call oReg.SetValue("data.export.holos.colors", IIf(chkExportColors.Checked, "1", "0"))
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

    Private Sub cboExportProfile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboExportProfile.SelectedIndexChanged
        Select Case cboExportProfile.SelectedIndex
            Case 0
                chkExportSurface.Enabled = False
            Case 1
                chkExportSurface.Enabled = True
        End Select
    End Sub
End Class