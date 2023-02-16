friend Class frmImportTherion2

    Private Sub pSettingsLoad()
        txtPrefix.Text = My.Application.Settings.GetSetting("data.import.pockettopo.prefix", "")
        txtCaveName.Text = My.Application.Settings.GetSetting("data.import.pockettopo.cavename", "")

        chkTherionImportplan.Checked = My.Application.Settings.GetSetting("data.import.therion.importplan", 1)
        chkTherionImportprofile.Checked = My.Application.Settings.GetSetting("data.import.therion.importprofile", 1)

        chkTherionMergeAndReorderBorders.Checked = My.Application.Settings.GetSetting("data.import.therion.mergeandreorderborders", 1)
        chktherionConvertBezierToSpline.Checked = My.Application.Settings.GetSetting("data.import.therion.beziertospline", 0)

        txtTherionScaleFactor.EditValue = modNumbers.StringToSingle(My.Application.Settings.GetSetting("data.import.therion.scalefactor", 1))
    End Sub

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("data.import.pockettopo.prefix", txtPrefix.Text)
        Call My.Application.Settings.SetSetting("data.import.pockettopo.cavename", txtCaveName.Text)

        Call My.Application.Settings.SetSetting("data.import.therion.importplan", If(chkTherionImportplan.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.therion.importprofile", If(chkTherionImportprofile.Checked, 1, 0))

        Call My.Application.Settings.SetSetting("data.import.therion.mergeandreorderborders", If(chkTherionMergeAndReorderBorders.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.therion.beziertospline", If(chktherionConvertBezierToSpline.Checked, 1, 0))

        Call My.Application.Settings.SetSetting("data.import.therion.scalefactor", modNumbers.NumberToString(txtTherionScaleFactor.EditValue, "0.00"))
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