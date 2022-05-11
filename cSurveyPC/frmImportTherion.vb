friend Class frmImportTherion

    Private Sub pSettingsLoad()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
                txtPrefix.Text = oReg.GetValue("data.import.pockettopo.prefix", "")
                txtCaveName.Text = oReg.GetValue("data.import.pockettopo.cavename", "")

                chkTherionImportplan.Checked = oReg.GetValue("data.import.therion.importplan", 1)
                chkTherionImportprofile.Checked = oReg.GetValue("data.import.therion.importprofile", 1)

                chkTherionMergeAndReorderBorders.Checked = oReg.GetValue("data.import.therion.mergeandreorderborders", 1)
                chktherionConvertBezierToSpline.Checked = oReg.GetValue("data.import.therion.beziertospline", 0)

                txtTherionScaleFactor.Value = modNumbers.StringToSingle(oReg.GetValue("data.import.therion.scalefactor", 1))
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

                Call oReg.SetValue("data.import.therion.importplan", IIf(chkTherionImportplan.Checked, 1, 0))
                Call oReg.SetValue("data.import.therion.importprofile", IIf(chkTherionImportprofile.Checked, 1, 0))

                Call oReg.SetValue("data.import.therion.mergeandreorderborders", IIf(chkTherionMergeAndReorderBorders.Checked, 1, 0))
                Call oReg.SetValue("data.import.therion.beziertospline", IIf(chktherionConvertBezierToSpline.Checked, 1, 0))

                Call oReg.SetValue("data.import.therion.scalefactor", modNumbers.NumberToString(txtTherionScaleFactor.Value, "0.00"))

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