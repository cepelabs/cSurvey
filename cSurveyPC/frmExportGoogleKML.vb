Public Class frmExportGoogleKML
    Private oSurvey As cSurvey.cSurvey

    Private Sub pSettingsLoad()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
                chkExportWaypoint.Checked = oReg.GetValue("data.export.googlekml.waypoint", "1")
                chkExportTrack.Checked = oReg.GetValue("data.export.googlekml.track", "0")
                chkExportCaveBorders.Checked = oReg.GetValue("data.export.googlekml.caveborders", "0")
                chkExportLinkedSurveys.Checked = oReg.GetValue("data.export.googlekml.linkedsurveys", "0")
                txtCaveBordersTransparency.Value = oReg.GetValue("data.export.googlekml.caveborders.opacity", 0.471) * 255
                chkExportUseCadastralIDInCaveNames.Checked = oReg.GetValue("data.export.googlekml.usecadastralidincavenames", "0")
                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Private Sub pSettingsSave()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
                Call oReg.SetValue("data.export.googlekml.waypoint", If(chkExportWaypoint.Checked, "1", "0"))
                Call oReg.SetValue("data.export.googlekml.track", If(chkExportTrack.Checked, "1", "0"))
                Call oReg.SetValue("data.export.googlekml.caveborders", If(chkExportCaveBorders.Checked, "1", "0"))
                Call oReg.SetValue("data.export.googlekml.linkedsurveys", If(chkExportLinkedSurveys.Checked, "1", "0"))
                Call oReg.SetValue("data.export.googlekml.caveborders.opacity", txtCaveBordersTransparency.Value / 255)
                Call oReg.SetValue("data.export.googlekml.usecadastralidincavenames", If(chkExportUseCadastralIDInCaveNames.Checked, "1", "0"))
                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Public Sub New(Survey As cSurvey.cSurvey)
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()
        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey
        Call pSettingsLoad()
        Call linkedSurveys.Rebind(oSurvey.LinkedSurveys, "export.kml")
    End Sub

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        Call pSettingsSave()
    End Sub

    Private Sub chkExportLinkedSurveys_CheckedChanged(sender As Object, e As EventArgs) Handles chkExportLinkedSurveys.CheckedChanged
        'If chkExportLinkedSurvey.Checked Then
        '    Call TabControl1.TabPages.Add(TabPage2)
        'Else
        '    Call TabControl1.TabPages.Remove(TabPage2)
        'End If
        linkedSurveys.Enabled = chkExportLinkedSurveys.Checked
    End Sub

    Private Sub chkExportCaveBorders_CheckedChanged(sender As Object, e As EventArgs) Handles chkExportCaveBorders.CheckedChanged
        pnlCaveBordersTransparency.Enabled = chkExportCaveBorders.Checked
    End Sub
End Class