friend Class frmtest
    Private oSurvey As cSurvey.cSurvey

    Public Sub New(Survey As cSurvey.cSurvey)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey

        CCaveInfoCombobox1.Rebind(oSurvey.Properties.CaveInfos, False)
    End Sub

    Private Sub frmtest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CCaveInfoCombobox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CCaveInfoCombobox1.SelectedIndexChanged
        CCaveInfoBranchesCombobox1.Rebind(CCaveInfoCombobox1.SelectedItem, False)
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Call pChangeWorkMode
    End Sub

    Private Sub pChangeWorkmode()
        If RadioButton2.Checked Then
            CCaveInfoCombobox1.Workmode = cCaveInfoCombobox.WorkmodeEnum.Edit
            CCaveInfoBranchesCombobox1.Workmode = cCaveInfoCombobox.WorkmodeEnum.Edit
        Else
            CCaveInfoCombobox1.Workmode = cCaveInfoCombobox.WorkmodeEnum.View
            CCaveInfoBranchesCombobox1.Workmode = cCaveInfoCombobox.WorkmodeEnum.View
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Call pChangeWorkmode()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        CCaveInfoCombobox1.Enabled = CheckBox1.Checked
        CCaveInfoBranchesCombobox1.Enabled = CheckBox1.Checked
    End Sub
End Class