friend Class frmSurfaceImportASCOptions

    Private Sub cboCoordinateSystem_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCoordinateSystem.SelectedIndexChanged
        If cboCoordinateSystem.EditValue.Contains("UTM") Then    'to do better in future...
            frmUTM.Visible = True
        Else
            frmUTM.Visible = False
        End If
        Dim bVisible As Boolean = cboCoordinateSystem.SelectedIndex = 0
        lblCheckWarning.Visible = bVisible
    End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        For i As Integer = 1 To 60
            Call cboUTMZone.Properties.Items.Add(i)
        Next
        For i As Integer = Asc("A") To Asc("Z")
            Call cboUTMBand.Properties.Items.Add(Chr(i))
        Next

        Call pSettingsLoad()
    End Sub

    Private Sub pSettingsLoad()
        cboCoordinateSystem.Text = My.Application.Settings.GetSetting("surface.import.ascoptions", "WGS84")
        cboUTMZone.Text = My.Application.Settings.GetSetting("surface.import.utmzone", "32")
        cboUTMBand.Text = My.Application.Settings.GetSetting("surface.import.utmband", "T")
    End Sub

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("surface.import.ascoptions", cboCoordinateSystem.Text)
        Call My.Application.Settings.SetSetting("surface.import.utmzone", cboUTMZone.Text)
        Call My.Application.Settings.SetSetting("surface.import.utmband", cboUTMBand.Text)
    End Sub

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        Call pSettingsSave()
    End Sub
End Class