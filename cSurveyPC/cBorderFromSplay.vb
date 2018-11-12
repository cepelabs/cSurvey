Imports cSurveyPC.cSurvey.Design.Items

Public Class cBorderFromSplay
    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Call pSettingsLoad()
    End Sub

    Private Sub pSettingsLoad()
        Try
            Dim oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
            Select Case oReg.GetValue("borderfromsplay.mode", "0")
                Case "0"
                    optCutAndLRUD.Checked = True
                Case Else
                    optAllSplays.Checked = True
            End Select
            cboUseHull.SelectedIndex = oReg.GetValue("borderfromsplay.algtype", 0)
            optCaveBranch.Checked = oReg.GetValue("borderfromsplay.cavebranch", 1)
            cboLineType.SelectedIndex = oReg.GetValue("borderfromsplay.linetype", 0)
            If Not optCaveBranch.Checked Then optSegment.Checked = True
            Call oReg.Close()
            Call oReg.Dispose()
        Catch
        End Try
    End Sub

    Private Sub pSettingsSave()
        Try
            Dim oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
            If optCutAndLRUD.Checked Then
                Call oReg.SetValue("borderfromsplay.mode", "0")
            Else
                Call oReg.SetValue("borderfromsplay.mode", "1")
            End If
            Call oReg.SetValue("borderfromsplay.algtype", cboUseHull.SelectedIndex)
            Call oReg.SetValue("borderfromsplay.cavebranch", IIf(optCaveBranch.Checked, "1", "0"))
            Call oReg.SetValue("borderfromsplay.linetype", cboLineType.SelectedIndex)

            Call oReg.Close()
            Call oReg.Dispose()
        Catch
        End Try
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
