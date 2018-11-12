Imports cSurveyPC.cSurvey.CaveRegister
Imports cSurveyPC.cSurvey

Public Class frmCaveRegisterAddMulti
    Private oSurvey As cSurvey.cSurvey

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Dim bOk As Boolean = True
        For Each oItem As ListViewItem In lvIDs.CheckedItems
            If oItem.Text.Trim = "" Or oItem.SubItems(1).Text.Trim = "" Then
                bOk = False
                Exit For
            End If
        Next

        If bOk Then
            DialogResult = Windows.Forms.DialogResult.OK
        Else
            Call MsgBox("Alcune voci non presentano un nome valido. Rimuovere le voci o verificare che l'ID indicato sia corretto.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Attenzione:")
        End If
    End Sub

    Public Sub New(Survey As cSurvey.cSurvey, Settings As cCaveRegisterSettings)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey

        Call pLoadSettings(Settings, Nothing)
        Call pLoadIDs()
    End Sub

    Private Sub pLoadIDs()
        Dim oIDs As List(Of String) = oSurvey.CaveRegister.GetCaveIDs(False)
        For Each sID As String In oIDs
            Dim oItem As ListViewItem = New ListViewItem()
            oItem.Text = sID
            Call oItem.SubItems.Add("")
            Call lvIDs.Items.Add(oItem)
        Next
    End Sub

    Private Sub pLoadSettings(Settings As cCaveRegisterSettings, Setting As cCaveRegisterSetting)
        For Each oSetting As cICaveRegisterSetting In Settings
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
        For Each oItem As ListViewItem In lvIDs.CheckedItems
            Dim sID As String = oItem.Text
            Dim sName As String = oSurvey.CaveRegister.GetDataName(oSetting, sID)
            oItem.SubItems(1).Text = sName
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub lvIDs_AfterLabelEdit(sender As Object, e As LabelEditEventArgs) Handles lvIDs.AfterLabelEdit

    End Sub

    Private Sub mnuIDsInvertSelection_Click(sender As Object, e As EventArgs) Handles mnuIDsInvertSelection.Click
        For Each oItem As ListViewItem In lvIDs.Items
            oItem.Selected = Not oItem.Selected
        Next
    End Sub

    Private Sub mnuIDsDeselectAll_Click(sender As Object, e As EventArgs) Handles mnuIDsDeselectAll.Click
        For Each oItem As ListViewItem In lvIDs.Items
            oItem.Selected = False
        Next
    End Sub

    Private Sub mnuIDsSelectAll_Click(sender As Object, e As EventArgs) Handles mnuIDsSelectAll.Click
        For Each oItem As ListViewItem In lvIDs.Items
            oItem.Selected = True
        Next
    End Sub

    Private Sub mnuIDsCheckSelected_Click(sender As Object, e As EventArgs) Handles mnuIDsCheckSelected.Click
        For Each oItem As ListViewItem In lvIDs.Items
            oItem.Checked = oItem.Selected
        Next
    End Sub
End Class