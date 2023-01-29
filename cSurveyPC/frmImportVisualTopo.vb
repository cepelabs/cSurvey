friend Class frmImportVisualTopo

    Private Sub pSettingsLoad()
        txtPrefix.Text = My.Application.Settings.GetSetting("data.import.visualtopo.prefix", "")
        txtCaveName.Text = My.Application.Settings.GetSetting("data.import.visualtopo.cavename", "")
    End Sub

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("data.import.visualtopo.prefix", txtPrefix.Text)
        Call My.Application.Settings.SetSetting("data.import.visualtopo.cavename", txtCaveName.Text)
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