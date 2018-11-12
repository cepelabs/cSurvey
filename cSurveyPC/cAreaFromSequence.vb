Imports cSurveyPC.cSurvey.Design.Items

Public Class cAreaFromSequence
    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Call pSettingsLoad()
    End Sub

    Private Sub pSettingsLoad()
        Try
            Dim oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
            cboLineType.SelectedIndex = oReg.GetValue("sequencetoarea.linetype", 0)
            txtWidth.Value = modNumbers.StringToSingle(oReg.GetValue("sequencetoarea.width", 1))
            txtReductionFactor.Value = modNumbers.StringToSingle(oReg.GetValue("sequencetoarea.reductionfactor", 1))
            Dim sItem As String = oReg.GetValue("sequencetoarea.objecttype", "")
            If sItem <> "" Then
                Dim oItems() As ListViewItem = lvItemToCreate.Items.Find(sItem, True)
                If oItems.Count = 1 Then
                    oItems(0).Selected = True
                End If
            End If
            Call oReg.Close()
            Call oReg.Dispose()
        Catch
        End Try
    End Sub

    Private Sub pSettingsSave()
        Try
            Dim oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
            Call oReg.SetValue("sequencetoarea.linetype", cboLineType.SelectedIndex)
            Call oReg.SetValue("sequencetoarea.width", modNumbers.NumberToString(txtWidth.Value))
            Call oReg.SetValue("sequencetoarea.reductionfactor", modNumbers.NumberToString(txtReductionFactor.Value))
            If lvItemToCreate.SelectedItems.Count = 0 Then
                Call oReg.SetValue("sequencetoarea.objecttype", "")
            Else
                Call oReg.SetValue("sequencetoarea.objecttype", lvItemToCreate.SelectedItems(0).Name)
            End If

            Call oReg.Close()
            Call oReg.Dispose()
        Catch
        End Try
    End Sub


    Friend Event OnCreate(Sender As cAreaFromSequence, Args As EventArgs)

    Private Sub cmdCreate_Click(sender As Object, e As EventArgs) Handles cmdCreate.Click
        Call pSettingsSave()
        RaiseEvent OnCreate(Me, New EventArgs)
    End Sub

    Private Sub lvItemToCreate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvItemToCreate.SelectedIndexChanged
        cmdCreate.Enabled = lvItemToCreate.SelectedItems.Count > 0
    End Sub
End Class
