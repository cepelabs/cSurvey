Public Class frmSurfaceImportASCOptions

    Private Sub cboCoordinateSystem_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCoordinateSystem.SelectedIndexChanged
        If cboCoordinateSystem.Text.Contains("UTM") Then    'poi cambierù con gli indici degli elementi ma per ora va bene anche cosi...
            frmUTM.Visible = True
        Else
            frmUTM.Visible = False
        End If
        Dim bvisible As Boolean = cboCoordinateSystem.SelectedIndex = 0
        picCheckWarning.Visible = bvisible
        lblCheckWarning.Visible = bvisible
    End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        For i As Integer = 1 To 60
            Call cboUTMZone.Items.Add(i)
        Next
        For i As Integer = Asc("A") To Asc("Z")
            Call cboUTMBand.Items.Add(Chr(i))
        Next

        'cboCoordinateSystem.SelectedIndex = 0   'qua poi caricherò l'ultimo usato...(e anche per i parametri sopra...)
        Call pSettingsLoad()
    End Sub

    Private Sub pSettingsLoad()
        Try
            Dim oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
            cboCoordinateSystem.Text = oReg.GetValue("surface.import.ascoptions", "WGS84")
            cboUTMZone.Text = oReg.GetValue("surface.import.utmzone", "32")
            cboUTMBand.Text = oReg.GetValue("surface.import.utmband", "T")
            Call oReg.Close()
            Call oReg.Dispose()
        Catch
        End Try
    End Sub

    Private Sub pSettingsSave()
        Try
            Dim oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
            Call oReg.SetValue("surface.import.ascoptions", cboCoordinateSystem.Text)
            Call oReg.SetValue("surface.import.utmzone", cboUTMZone.Text)
            Call oReg.SetValue("surface.import.utmband", cboUTMBand.Text)
            Call oReg.Close()
            Call oReg.Dispose()
        Catch
        End Try
    End Sub

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        Call pSettingsSave()
    End Sub
End Class