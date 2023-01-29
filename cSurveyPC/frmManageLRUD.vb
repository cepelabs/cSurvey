Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Data

friend Class frmManageLRUD
    Private oSurvey As cSurvey.cSurvey

    Private Sub pSettingsLoad()
        cboAction.SelectedIndex = My.Application.Settings.GetSetting("editor.managelrud.option", "0")
        Call pRadioButtonEnabled()

        Select Case My.Application.Settings.GetSetting("editor.managelrud.option0", "0")
            Case 0
                RadioButton1a.Checked = True
            Case 1
                RadioButton1b.Checked = True
        End Select
        chkRestoreDeleteBackupAfterRestore.Checked = My.Application.Settings.GetSetting("editor.managelrud.deleteafterrestore", "0")
        chkBackup.Checked = My.Application.Settings.GetSetting("editor.managelrud.backup", "0")

        chkMode2OnlyCutSplay.Checked = My.Application.Settings.GetSetting("editor.managelrud.option1onlycutsplay", "0")
        txtMode2H.Value = modNumbers.StringToInteger(My.Application.Settings.GetSetting("editor.managelrud.option1h", "45"))
        txtMode2V.Value = modNumbers.StringToInteger(My.Application.Settings.GetSetting("editor.managelrud.option1v", "45"))
        cboMode2Mode.SelectedIndex = My.Application.Settings.GetSetting("editor.managelrud.option1mode", "0")

        chkMarkAsCalculated.Checked = My.Application.Settings.GetSetting("editor.managelrud.markascalculated", "1")

        chkShotWithLRUD.Checked = My.Application.Settings.GetSetting("editor.managelrud.shotwithlrud", "0")
        chkShotWithCalculatedLRUD.Checked = My.Application.Settings.GetSetting("editor.managelrud.shotwithcalculatedlrud", "1")
        chkShotWithoutLRUD.Checked = My.Application.Settings.GetSetting("editor.managelrud.shotwithoutlrud", "1")
    End Sub

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("editor.managelrud.option", cboAction.SelectedIndex)
        Call My.Application.Settings.SetSetting("editor.managelrud.option0", If(RadioButton1a.Checked, "0", IIf(RadioButton1b.Checked, "1", "")))
        Call My.Application.Settings.SetSetting("editor.managelrud.deleteafterrestore", IIf(chkRestoreDeleteBackupAfterRestore.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("editor.managelrud.backup", If(chkBackup.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("editor.managelrud.option1onlycutsplay", If(chkMode2OnlyCutSplay.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("editor.managelrud.option1h", modNumbers.NumberToString(txtMode2H.Value, "0"))
        Call My.Application.Settings.SetSetting("editor.managelrud.option1v", modNumbers.NumberToString(txtMode2V.Value, "0"))
        Call My.Application.Settings.SetSetting("editor.managelrud.option1mode", modNumbers.NumberToString(cboMode2Mode.SelectedIndex, "0"))
        Call My.Application.Settings.SetSetting("editor.managelrud.markascalculated", If(chkMarkAsCalculated.Checked, "1", "0"))

        Call My.Application.Settings.SetSetting("editor.managelrud.shotwithlrud", If(chkShotWithLRUD.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("editor.managelrud.shotwithcalculatedlrud", If(chkShotWithCalculatedLRUD.Checked, "1", "0"))
        Call My.Application.Settings.SetSetting("editor.managelrud.shotwithoutlrud", If(chkShotWithoutLRUD.Checked, "1", "0"))
    End Sub

    Public Sub New(Survey As cSurveyPC.cSurvey.cSurvey, Optional Session As cSession = Nothing, Optional Cave As cCaveInfo = Nothing, Optional CaveBranch As cCaveInfoBranch = Nothing, Optional Rows As Integer = 1)
        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey

        TableLayoutPanel1.AutoScroll = False

        If Rows > 0 Then
            cboReplicateTo.SelectedIndex = 3
        Else
            cboReplicateTo.SelectedIndex = 2
        End If
        cboMode2Mode.SelectedIndex = 0
        For Each oProperty As cDataField In oSurvey.Properties.DataTables.Segments
            If oProperty.Name.StartsWith(sBackupBasename) Then
                Call cboBackupName.Items.Add(oProperty.Name.Replace(sBackupBasename, ""))
                Call cboRestoreName.Items.Add(oProperty.Name.Replace(sBackupBasename, ""))
            End If
        Next
        If cboRestoreName.Items.Count > 0 Then cboRestoreName.SelectedIndex = cboRestoreName.Items.Count - 1

        Call pSettingsLoad()
    End Sub

    Private Const sBackupBasename As String = "backup_LRUD_"

    Public Sub Backup(Segment As cSegment)
        Dim sProfile As String = sBackupBasename & cboBackupName.Text
        Call oSurvey.Properties.DataTables.Segments.Add(sProfile, Data.cDataFields.TypeEnum.Text)
        Call Segment.DataProperties.SetValue(sProfile, modNumbers.NumberToString(Segment.Left) & ";" & modNumbers.NumberToString(Segment.Right) & ";" & modNumbers.NumberToString(Segment.Up) & ";" & modNumbers.NumberToString(Segment.Down))
    End Sub

    'Public Sub Backup()
    '    Dim sProfile As String = sBackupBasename & cboBackupName.Text
    '    Call oSurvey.Properties.DataTables.Segments.Add(sProfile, Data.cDataFields.TypeEnum.Text)
    '    For Each oSegment As cSegment In oSurvey.Segments
    '        If oSegment.IsValid Then
    '            If oSegment.Left <> 0 Or oSegment.Right <> 0 Or oSegment.Up <> 0 Or oSegment.Down <> 0 Then
    '                Call oSegment.DataProperties.SetValue(sProfile, modNumbers.NumberToString(oSegment.Left) & ";" & modNumbers.NumberToString(oSegment.Right) & ";" & modNumbers.NumberToString(oSegment.Up) & ";" & modNumbers.NumberToString(oSegment.Down))
    '            End If
    '        End If
    '    Next
    'End Sub

    Public Sub Restore()
        Dim sProfile As String = sBackupBasename & cboRestoreName.Text
        If oSurvey.Properties.DataTables.Segments.Contains(sProfile) Then
            For Each oSegment As cSegment In oSurvey.Segments
                If oSegment.IsValid Then
                    Dim sLRUD As String = oSegment.DataProperties.GetValue(sProfile, "")
                    If sLRUD <> "" Then
                        Dim sLRUDParts() As String = sLRUD.Split(";")
                        If sLRUDParts.Length = 4 Then
                            oSegment.Left = modNumbers.StringToDecimal(sLRUDParts(0))
                            oSegment.Right = modNumbers.StringToDecimal(sLRUDParts(1))
                            oSegment.Up = modNumbers.StringToDecimal(sLRUDParts(2))
                            oSegment.Down = modNumbers.StringToDecimal(sLRUDParts(3))
                        End If
                    End If
                End If
            Next
            If chkRestoreDeleteBackupAfterRestore.Checked Then
                Call oSurvey.Properties.DataTables.Segments.Remove(sProfile)
            End If
        End If
    End Sub

    Private Function pValidate() As Boolean
        If cboBackupName.Enabled AndAlso cboBackupName.Text = "" Then
            Call cSurvey.UIHelpers.Dialogs.Msgbox(modMain.GetLocalizedString("managelrud.warning2"), MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical, modMain.GetLocalizedString("main.warningtitle"))
            Return False
        ElseIf cboRestoreName.Enabled AndAlso cboRestoreName.Text = "" Then
            Call cSurvey.UIHelpers.Dialogs.Msgbox(modMain.GetLocalizedString("managelrud.warning1"), MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical, modMain.GetLocalizedString("main.warningtitle"))
            Return False
        End If
        Return True
    End Function

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        If pvalidate Then
            DialogResult = DialogResult.OK
            Close()
        End If
    End Sub

    Private Sub pRadioButtonEnabled()
        If cboAction.SelectedIndex = 0 Then
            frmRestore.Enabled = False
            chkBackup.Enabled = True
            frmBackup.Enabled = True
            chkMarkAsCalculated.Enabled = True

            frmMode1.Enabled = True
            frmMode2.Enabled = False
        ElseIf cboAction.SelectedIndex = 1 Then
            frmRestore.Enabled = False
            chkBackup.Enabled = True
            frmBackup.Enabled = True
            chkMarkAsCalculated.Enabled = True

            frmMode1.Enabled = False
            frmMode2.Enabled = True
        ElseIf cboAction.SelectedIndex = 2 Then
            frmRestore.Enabled = False
            chkBackup.Enabled = True
            frmBackup.Enabled = True
            chkMarkAsCalculated.Enabled = True

            frmMode1.Enabled = False
            frmMode2.Enabled = False
        Else
            Dim bEnabled As Boolean = cboAction.SelectedIndex = 3
            frmRestore.Enabled = bEnabled
            chkBackup.Enabled = False
            frmBackup.Enabled = False
            chkMarkAsCalculated.Enabled = False

            frmMode1.Enabled = False
            frmMode2.Enabled = False
        End If
        If chkBackup.Enabled Then
            frmBackup.Enabled = chkBackup.Checked
        End If
    End Sub

    Private Sub chkBackup_CheckedChanged(sender As Object, e As EventArgs) Handles chkBackup.CheckedChanged
        Call pRadioButtonEnabled()
    End Sub

    Private Sub frmManageLRUD_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Call pSettingsSave()
    End Sub

    Private Sub cboAction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAction.SelectedIndexChanged
        Select Case cboAction.SelectedIndex
            Case 0
                pnlOption0.Visible = True
                pnlOption1.Visible = False
                pnlOption3.Visible = False
            Case 1
                pnlOption0.Visible = False
                pnlOption1.Visible = True
                pnlOption3.Visible = False
            Case 2
                pnlOption0.Visible = False
                pnlOption1.Visible = False
                pnlOption3.Visible = False
            Case 3
                pnlOption0.Visible = False
                pnlOption1.Visible = False
                pnlOption3.Visible = True
        End Select
        Call pRadioButtonEnabled()
    End Sub
End Class