﻿Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Data

Public Class frmManageLRUD
    Private oSurvey As cSurvey.cSurvey

    Private Sub pSettingsLoad()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
                Select Case oReg.GetValue("editor.managelrud.option", "0")
                    Case 0
                        RadioButton1.Checked = True
                    Case 1
                        RadioButton2.Checked = True
                    Case 2
                        RadioButton3.Checked = True
                    Case 3
                        RadioButton4.Checked = True
                End Select
                Select Case oReg.GetValue("editor.managelrud.option0", "0")
                    Case 0
                        RadioButton1a.Checked = True
                    Case 1
                        RadioButton1b.Checked = True
                End Select
                chkRestoreDeleteBackupAfterRestore.Checked = oReg.GetValue("editor.managelrud.deleteafterrestore", "0")
                chkBackup.Checked = oReg.GetValue("editor.managelrud.backup", "0")

                chkMode2OnlyCutSplay.Checked = oReg.GetValue("editor.managelrud.option1onlycutsplay", "0")
                txtMode2H.Value = modNumbers.StringToInteger(oReg.GetValue("editor.managelrud.option1h", "45"))
                txtMode2V.Value = modNumbers.StringToInteger(oReg.GetValue("editor.managelrud.option1v", "45"))
                cboMode2Mode.SelectedIndex = oReg.GetValue("editor.managelrud.option1mode", "0")

                chkMarkAsCalculated.Checked = oReg.GetValue("editor.managelrud.markascalculated", "1")

                chkShotWithLRUD.Checked = oReg.GetValue("editor.managelrud.shotwithlrud", "0")
                chkShotWithCalculatedLRUD.Checked = oReg.GetValue("editor.managelrud.shotwithcalculatedlrud", "1")
                chkShotWithoutLRUD.Checked = oReg.GetValue("editor.managelrud.shotwithoutlrud", "1")

                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Private Sub pSettingsSave()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
                Call oReg.SetValue("editor.managelrud.option", If(RadioButton1.Checked, 0, IIf(RadioButton2.Checked, 1, IIf(RadioButton3.Checked, 2, IIf(RadioButton4.Checked, 4, "")))))
                Call oReg.SetValue("editor.managelrud.option0", If(RadioButton1a.Checked, "0", IIf(RadioButton1b.Checked, "1", "")))
                Call oReg.SetValue("editor.managelrud.deleteafterrestore", IIf(chkRestoreDeleteBackupAfterRestore.Checked, "1", "0"))
                Call oReg.SetValue("editor.managelrud.backup", If(chkBackup.Checked, "1", "0"))
                Call oReg.SetValue("editor.managelrud.option1onlycutsplay", If(chkMode2OnlyCutSplay.Checked, "1", "0"))
                Call oReg.SetValue("editor.managelrud.option1h", modNumbers.NumberToString(txtMode2H.Value, "0"))
                Call oReg.SetValue("editor.managelrud.option1v", modNumbers.NumberToString(txtMode2V.Value, "0"))
                Call oReg.SetValue("editor.managelrud.option1mode", modNumbers.NumberToString(cboMode2Mode.SelectedIndex, "0"))
                Call oReg.SetValue("editor.managelrud.markascalculated", If(chkMarkAsCalculated.Checked, "1", "0"))

                Call oReg.SetValue("editor.managelrud.shotwithlrud", If(chkShotWithLRUD.Checked, "1", "0"))
                Call oReg.SetValue("editor.managelrud.shotwithcalculatedlrud", If(chkShotWithCalculatedLRUD.Checked, "1", "0"))
                Call oReg.SetValue("editor.managelrud.shotwithoutlrud", If(chkShotWithoutLRUD.Checked, "1", "0"))
                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Public Sub New(Survey As cSurveyPC.cSurvey.cSurvey, Optional Session As cSession = Nothing, Optional Cave As cCaveInfo = Nothing, Optional CaveBranch As cCaveInfoBranch = Nothing, Optional Rows As Integer = 1)
        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey

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
        'Call oSurvey.Properties.DataTables.Segments.Add(sProfile, Data.cDataFields.TypeEnum.Text)
        'For Each oSegment As cSegment In oSurvey.Segments
        '    If oSegment.IsValid Then
        '        If oSegment.Left <> 0 Or oSegment.Right <> 0 Or oSegment.Up <> 0 Or oSegment.Down <> 0 Then
        Call Segment.DataProperties.SetValue(sProfile, modNumbers.NumberToString(Segment.Left) & ";" & modNumbers.NumberToString(Segment.Right) & ";" & modNumbers.NumberToString(Segment.Up) & ";" & modNumbers.NumberToString(Segment.Down))
        '        End If
        '    End If
        'Next
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
        Dim sProfile As String = sBackupBasename & cboBackupName.Text
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
            Call MsgBox("Indicare un nome per la proprietà in cui archiviare i dati salvati.")
            Return False
        ElseIf cboRestoreName.Enabled AndAlso cboRestoreName.Text = "" Then
            Call MsgBox("Selezionare una proprietà da cui ripristinare i dati salvati.")
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

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        Call pRadioButtonEnabled()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Call pRadioButtonEnabled()
    End Sub

    Private Sub pRadioButtonEnabled()
        If RadioButton1.Checked Then
            frmRestore.Enabled = False
            chkBackup.Enabled = True
            frmBackup.Enabled = True
            chkMarkAsCalculated.Enabled = True

            frmMode1.Enabled = True
            frmMode2.Enabled = False
        ElseIf RadioButton2.Checked Then
            frmRestore.Enabled = False
            chkBackup.Enabled = True
            frmBackup.Enabled = True
            chkMarkAsCalculated.Enabled = True

            frmMode1.Enabled = False
            frmMode2.Enabled = True
        ElseIf RadioButton3.Checked Then
            frmRestore.Enabled = False
            chkBackup.Enabled = True
            frmBackup.Enabled = True
            chkMarkAsCalculated.Enabled = True

            frmMode1.Enabled = False
            frmMode2.Enabled = False
        Else
            Dim bEnabled As Boolean = RadioButton4.Checked
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

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Call pRadioButtonEnabled()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Call pRadioButtonEnabled()
    End Sub

    Private Sub chkBackup_CheckedChanged(sender As Object, e As EventArgs) Handles chkBackup.CheckedChanged
        Call pRadioButtonEnabled()
    End Sub

    Private Sub frmManageLRUD_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Call pSettingsSave()
    End Sub
End Class