friend Class frmExportTherion

    Private Sub pSettingsLoad()
        chkExportDesign.Checked = My.Application.Settings.GetSetting("data.export.therion.design", "0")
        chkExportThconfig.Checked = My.Application.Settings.GetSetting("data.export.holos.createthconfig", "0")
    End Sub

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("data.export.therion.design", If(chkExportDesign.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("data.export.therion.createthconfig", If(chkExportThconfig.Checked, "1", "0"))
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