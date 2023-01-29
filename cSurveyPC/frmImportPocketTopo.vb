friend Class frmImportPocketTopo

    Private Sub pSettingsLoad()
        txtPrefix.Text = My.Application.Settings.GetSetting("data.import.pockettopo.prefix", "")
        txtCaveName.Text = My.Application.Settings.GetSetting("data.import.pockettopo.cavename", "")
        chkPocketTopoImportData.Checked = My.Application.Settings.GetSetting("data.import.pockettopo.importdata", 1)
        chkPocketTopoImportGraphics.Checked = My.Application.Settings.GetSetting("data.import.pockettopo.importgraphics", 0)
    End Sub

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("data.import.pockettopo.prefix", txtPrefix.Text)
        Call My.Application.Settings.SetSetting("data.import.pockettopo.cavename", txtCaveName.Text)
        Call My.Application.Settings.SetSetting("data.import.pockettopo.importdata", IIf(chkPocketTopoImportData.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.pockettopo.importgraphics", IIf(chkPocketTopoImportGraphics.Checked, 1, 0))
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