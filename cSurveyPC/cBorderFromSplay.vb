Imports cSurveyPC.cSurvey.Design.Items

Public Class cBorderFromSplay
    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Call pSettingsLoad()
    End Sub

    Private Sub pSettingsLoad()
        Select Case My.Application.Settings.GetSetting("borderfromsplay.mode", "0")
            Case "0"
                optCutAndLRUD.Checked = True
            Case Else
                optAllSplays.Checked = True
        End Select
        cboUseHull.SelectedIndex = My.Application.Settings.GetSetting("borderfromsplay.algtype", 0)
        optCaveBranch.Checked = My.Application.Settings.GetSetting("borderfromsplay.cavebranch", 1)
        cboLineType.SelectedIndex = My.Application.Settings.GetSetting("borderfromsplay.linetype", 0)
        If Not optCaveBranch.Checked Then optSegment.Checked = True
    End Sub

    Private Sub pSettingsSave()
        If optCutAndLRUD.Checked Then
            Call My.Application.Settings.SetSetting("borderfromsplay.mode", "0")
        Else
            Call My.Application.Settings.SetSetting("borderfromsplay.mode", "1")
        End If
        Call My.Application.Settings.SetSetting("borderfromsplay.algtype", cboUseHull.SelectedIndex)
        Call My.Application.Settings.SetSetting("borderfromsplay.cavebranch", If(optCaveBranch.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("borderfromsplay.linetype", cboLineType.SelectedIndex)
    End Sub

    Friend Event OnCreate(Sender As cBorderFromSplay, Args As EventArgs)

    Private Sub cmdCreate_Click(sender As Object, e As EventArgs) Handles cmdCreate.Click
        Call pSettingsSave()
        RaiseEvent OnCreate(Me, New EventArgs)
    End Sub

    Private Sub optCutAndLRUD_CheckedChanged(sender As Object, e As EventArgs) Handles optCutAndLRUD.CheckedChanged
        Call pShowOptions
    End Sub

    Private Sub pShowOptions()
        pnlAllSplays.Visible = optAllSplays.Checked
    End Sub
End Class
