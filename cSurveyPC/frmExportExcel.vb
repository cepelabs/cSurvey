friend Class frmExportExcel

    Private Sub pSettingsLoad()
        chkExportCalculatedData.Checked = My.Application.Settings.GetSetting("data.export.excel.calculateddata", "1")
        chkExportColor.Checked = My.Application.Settings.GetSetting("data.export.excel.color", "0")
        chkExportNamedSplayStations.Checked = My.Application.Settings.GetSetting("data.export.excel.splaystations", "0")
        chkExportNamedSplayStationsData.Checked = My.Application.Settings.GetSetting("data.export.excel.splaystationsdata", "0")
    End Sub

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("data.export.excel.calculateddata", If(chkExportCalculatedData.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("data.export.excel.color", If(chkExportColor.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("data.export.excel.splaystations", If(chkExportNamedSplayStations.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("data.export.excel.splaystationsdata", If(chkExportNamedSplayStationsData.Checked, "1", "0"))
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