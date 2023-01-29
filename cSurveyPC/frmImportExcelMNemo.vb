Imports System.ComponentModel
Imports cSurveyPC.cSurvey.UIHelpers.Import
Imports DevExpress.XtraTreeList

Friend Class frmImportExcelMNemo

    Private Sub pSettingsLoad()
        txtPrefix.Text = My.Application.Settings.GetSetting("data.import.xlsx.mnemo.prefix", "")
        txtCaveName.Text = My.Application.Settings.GetSetting("data.import.xlsx.mnemo.cavename", "")
        cboBearingPolicy.SelectedIndex = My.Application.Settings.GetSetting("data.import.xlsx.mnemo.bearingpolicy", 0)
        cboDepthPolicy.SelectedIndex = My.Application.Settings.GetSetting("data.import.xlsx.mnemo.depthpolicy", 0)
    End Sub

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("data.import.xlsx.mnemo.prefix", txtPrefix.Text)
        Call My.Application.Settings.SetSetting("data.import.xlsx.mnemo.cavename", txtCaveName.Text)
        Call My.Application.Settings.SetSetting("data.import.xlsx.mnemo.bearingpolicy", cboBearingPolicy.SelectedIndex)
        Call My.Application.Settings.SetSetting("data.import.xlsx.mnemo.depthpolicy", cboDepthPolicy.SelectedIndex)
    End Sub

    Private oSurvey As cSurvey.cSurvey

    Private WithEvents oSourceFields As cSourceFields

    Public Sub New(Survey As cSurvey.cSurvey)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey

        Call cboSession.Rebind(oSurvey, True, True, AddressOf pFilterSession)

        Call pSettingsLoad()
    End Sub

    Private Function pFilterSession(Session As cSurvey.cSession) As Boolean
        Return Session.DataFormat = cSurvey.cSegment.DataFormatEnum.Diving AndAlso Session.DepthType = cSurvey.cSegment.DepthTypeEnum.AbsoluteAtEnd AndAlso Session.InclinationDirection = cSurvey.cSegment.MeasureDirectionEnum.Inverted
    End Function

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        Call pSettingsSave()
    End Sub

End Class