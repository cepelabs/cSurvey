Imports cSurveyPC.cSurvey.CaveRegister
Imports cSurveyPC.cSurvey

friend Class frmCaveRegisterAdd
    Private oSurvey As cSurvey.cSurvey

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        If txtName.Text <> "" And cboID.Text <> "" Then
            DialogResult = Windows.Forms.DialogResult.OK
        Else
            Call MsgBox("Compilare i campi Nome e ID di riferimento.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Attenzione:")
        End If
    End Sub

    Public Sub New(Survey As cSurvey.cSurvey, Settings As cCaveRegisterSettings)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey

        Call pLoadIDs()
        Call pLoadSettings(Settings, Nothing)
    End Sub

    Public Sub New(Survey As cSurvey.cSurvey, Settings As cCaveRegisterSettings, Data As cCaveRegisterData)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey

        Call pLoadIDs()
        cboID.Text = Data.CaveID
        txtName.Text = Data.Name
        Call pLoadSettings(Settings, Data.GetSetting)
    End Sub

    Private Sub pLoadIDs()
        Dim oIDs As List(Of String) = oSurvey.CaveRegister.GetCaveIDs(False)
        Call cboID.Items.AddRange(oIDs.ToArray)
    End Sub

    Private Sub pLoadSettings(Settings As cCaveRegisterSettings, Setting As cCaveRegisterSetting)
        For Each oSetting As cCaveRegisterSetting In Settings
            Call cboSetting.Items.Add(oSetting)
        Next
        If Setting Is Nothing Then
            cboSetting.SelectedItem = cboSetting.Items(0)
        Else
            cboSetting.SelectedItem = Setting
        End If
    End Sub

    Private Sub btnNameRefresh_Click(sender As Object, e As EventArgs) Handles btnNameRefresh.Click
        Cursor = Cursors.WaitCursor
        Dim oSetting As cCaveRegisterSetting = cboSetting.SelectedItem
        Dim sID As String = cboID.Text
        Dim sName As String = oSurvey.CaveRegister.GetDataName(oSetting, sID)
        txtName.Text = sName
        Cursor = Cursors.Default
    End Sub
End Class