friend Class frmImportCompass

    Private Sub pSettingsLoad()
        txtPrefix.Text = My.Application.Settings.GetSetting("data.import.compass.prefix", "")
        chkCompassCreateBrachForSession.Checked = My.Application.Settings.GetSetting("data.import.compass.branchforsession", 1)
        chkCompassImportFlagX.Checked = My.Application.Settings.GetSetting("data.import.compass.importflagx", 1)
        chkCompassImportSSShotAsSplay.Checked = My.Application.Settings.GetSetting("data.import.compass.importssshotassplay", 0)
    End Sub

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("data.import.compass.prefix", txtPrefix.Text)
        Call My.Application.Settings.SetSetting("data.import.compass.branchforsession", If(chkCompassCreateBrachForSession.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.compass.importflagx", If(chkCompassImportFlagX.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.compass.importssshotassplay", If(chkCompassImportSSShotAsSplay.Checked, 1, 0))
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