Imports cSurveyPC.cSurvey

Friend Class frmImportTherion

    Private Sub pSettingsLoad()
        txtPrefix.Text = My.Application.Settings.GetSetting("data.import.therion.prefix", "")
    End Sub

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("data.import.therion.prefix", txtPrefix.Text)
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