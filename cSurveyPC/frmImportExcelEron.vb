Imports System.ComponentModel
Imports cSurveyPC.cSurvey.UIHelpers.Import
Imports DevExpress.XtraTreeList

Friend Class frmImportExcelEron

    Private Sub pSettingsLoad()
        txtPrefix.Text = My.Application.Settings.GetSetting("data.import.xlsx.eron.prefix", "")
        txtCaveName.Text = My.Application.Settings.GetSetting("data.import.xlsx.eron.cavename", "")
        chkCleanNoDistanceData.Checked = My.Application.Settings.GetSetting("data.import.xlsx.eron.cleannodistancedata", 1)
    End Sub

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("data.import.xlsx.eron.prefix", txtPrefix.Text)
        Call My.Application.Settings.SetSetting("data.import.xlsx.eron.cavename", txtCaveName.Text)
        Call My.Application.Settings.SetSetting("data.import.xlsx.eron.cleannodistancedata", If(chkCleanNoDistanceData.Checked, 1, 0))
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