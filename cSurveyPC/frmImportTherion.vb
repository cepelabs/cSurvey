Imports cSurveyPC.cSurvey

Friend Class frmImportTherion

    Private Sub pSettingsLoad()
        txtPrefix.Text = My.Application.Settings.GetSetting("data.import.therion.prefix", "")
        chkProcessAllFiles.Checked = My.Application.Settings.GetSetting("data.import.therion.allfiles", 0)
        chkLineOfComment.Checked = My.Application.Settings.GetSetting("data.import.therion.lineofcomment", 0)
    End Sub

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("data.import.therion.prefix", txtPrefix.Text)
        Call My.Application.Settings.SetSetting("data.import.therion.allfiles", If(chkProcessAllFiles.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("data.import.therion.lineofcomment", If(chkLineOfComment.Checked, "1", "0"))
    End Sub

    Public Sub New(Survey As cSurvey.cSurvey)
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()
        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        osurvey = Survey
        Call pSettingsLoad()
    End Sub

    Private oSurvey As cSurvey.cSurvey

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        Call pSettingsSave()
    End Sub

    Private Sub chkImportAsBranchOf_CheckedChanged(sender As Object, e As EventArgs) Handles chkImportAsBranchOf.CheckedChanged
        cboImportAsBranchOfCave.Enabled = chkImportAsBranchOf.Checked
        cboImportAsBranchOfBranch.Enabled = chkImportAsBranchOf.Checked
    End Sub

    Private Sub cboImportAsBranchOfCave_EditValueChanged(sender As Object, e As EventArgs) Handles cboImportAsBranchOfCave.EditValueChanged
        Dim oCave As cCaveInfo = cboImportAsBranchOfCave.EditValue
        Dim oBranch As cCaveInfoBranch = cboImportAsBranchOfBranch.EditValue
        Dim sCave As String = "" & If(cboImportAsBranchOfCave.EditValue Is Nothing, "", cboImportAsBranchOfCave.EditValue.Name)
        Dim sCurrentBranch As String = "" & If(cboImportAsBranchOfBranch.EditValue Is Nothing, "", cboImportAsBranchOfBranch.EditValue.Path)
        Call cboImportAsBranchOfBranch.Rebind(oSurvey, cboImportAsBranchOfCave, True)
    End Sub
End Class