friend Class frmImportResurvey

    Private Sub pSettingsLoad()
        txtPrefix.Text = My.Application.Settings.GetSetting("data.import.resurvey.prefix", "")
        txtCaveName.Text = My.Application.Settings.GetSetting("data.import.resurvey.cavename", "")
        cboNordType.SelectedIndex = My.Application.Settings.GetSetting("data.import.resurvey.nordtype", 0)
    End Sub

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("data.import.resurvey.prefix", txtPrefix.Text)
        Call My.Application.Settings.SetSetting("data.import.resurvey.cavename", txtCaveName.Text)
        Call My.Application.Settings.SetSetting("data.import.resurvey.nordtype", cboNordType.SelectedIndex)
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