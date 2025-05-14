Imports System.ComponentModel
Imports cSurveyPC.cSurvey.UIHelpers.Import
Imports DevExpress.XtraTreeList

Friend Class frmImportExcelcSurvey

    Private Sub pSettingsLoad()
        chkExcelcSurveyCavesAndBranches.Checked = My.Application.Settings.GetSetting("data.import.xlsx.csurvey.cavesandbraches", 1)
        chkExcelcSurveySessions.Checked = My.Application.Settings.GetSetting("data.import.xlsx.csurvey.sessions", 1)
        chkExcelColor.Checked = My.Application.Settings.GetSetting("data.import.xlsx.csurvey.colors", 1)
    End Sub

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("data.import.xlsx.csurvey.cavesandbraches", If(chkExcelcSurveyCavesAndBranches.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.xlsx.csurvey.sessions", If(chkExcelcSurveySessions.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.xlsx.csurvey.colors", If(chkExcelColor.Checked, 1, 0))
    End Sub

    Private oSurvey As cSurvey.cSurvey

    Private WithEvents oSourceFields As cSourceFields

    Public Sub New(Survey As cSurvey.cSurvey)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey

        Call pSettingsLoad()
    End Sub

    Private Function pFilterSession(Session As cSurvey.cSession) As Boolean
        Return Session.DataFormat = cSurvey.cSegment.DataFormatEnum.Diving AndAlso Session.DepthType = cSurvey.cSegment.DepthTypeEnum.AbsoluteAtEnd AndAlso Session.InclinationDirection = cSurvey.cSegment.MeasureDirectionEnum.Inverted
    End Function

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        Call pSettingsSave()
    End Sub

End Class