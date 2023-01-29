friend Class frmExportGoogleKML
    Private oSurvey As cSurvey.cSurvey

    Private Sub pSettingsLoad()
        chkExportWaypoint.Checked = My.Application.Settings.GetSetting("data.export.googlekml.waypoint", "1")
        chkExportTrack.Checked = My.Application.Settings.GetSetting("data.export.googlekml.track", "0")
        chkExportCaveBorders.Checked = My.Application.Settings.GetSetting("data.export.googlekml.caveborders", "0")
        chkExportLinkedSurveys.Checked = My.Application.Settings.GetSetting("data.export.googlekml.linkedsurveys", "0")
        txtCaveBordersTransparency.Value = My.Application.Settings.GetSetting("data.export.googlekml.caveborders.opacity", 0.471) * 255
        chkExportUseCadastralIDInCaveNames.Checked = My.Application.Settings.GetSetting("data.export.googlekml.usecadastralidincavenames", "0")
    End Sub

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("data.export.googlekml.waypoint", If(chkExportWaypoint.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("data.export.googlekml.track", If(chkExportTrack.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("data.export.googlekml.caveborders", If(chkExportCaveBorders.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("data.export.googlekml.linkedsurveys", If(chkExportLinkedSurveys.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("data.export.googlekml.caveborders.opacity", txtCaveBordersTransparency.Value / 255)
        Call My.Application.Settings.SetSetting("data.export.googlekml.usecadastralidincavenames", If(chkExportUseCadastralIDInCaveNames.Checked, "1", "0"))
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
        linkedSurveys.Enabled = chkExportLinkedSurveys.Checked
    End Sub

    Private Sub chkExportCaveBorders_CheckedChanged(sender As Object, e As EventArgs) Handles chkExportCaveBorders.CheckedChanged
        pnlCaveBordersTransparency.Enabled = chkExportCaveBorders.Checked
    End Sub
End Class