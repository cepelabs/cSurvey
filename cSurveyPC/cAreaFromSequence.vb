Imports cSurveyPC.cSurvey.Design.Items

Public Class cAreaFromSequence
    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Call pSettingsLoad()
    End Sub

    Private Sub pSettingsLoad()
        cboLineType.SelectedIndex = My.Application.Settings.GetSetting("sequencetoarea.linetype", 0)
        txtWidth.Value = modNumbers.StringToSingle(My.Application.Settings.GetSetting("sequencetoarea.width", 1))
        txtReductionFactor.Value = modNumbers.StringToSingle(My.Application.Settings.GetSetting("sequencetoarea.reductionfactor", 1))
        Dim sItem As String = My.Application.Settings.GetSetting("sequencetoarea.objecttype", "")
        If sItem <> "" Then
            Dim oItems() As ListViewItem = lvItemToCreate.Items.Find(sItem, True)
            If oItems.Count = 1 Then
                oItems(0).Selected = True
            End If
        End If
    End Sub

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("sequencetoarea.linetype", cboLineType.SelectedIndex)
        Call My.Application.Settings.SetSetting("sequencetoarea.width", modNumbers.NumberToString(txtWidth.Value))
        Call My.Application.Settings.SetSetting("sequencetoarea.reductionfactor", modNumbers.NumberToString(txtReductionFactor.Value))
        If lvItemToCreate.SelectedItems.Count = 0 Then
            Call My.Application.Settings.SetSetting("sequencetoarea.objecttype", "")
        Else
            Call My.Application.Settings.SetSetting("sequencetoarea.objecttype", lvItemToCreate.SelectedItems(0).Name)
        End If
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
