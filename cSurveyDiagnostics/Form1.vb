Public Class Form1
    Private Sub btnRunTest_Click(sender As Object, e As EventArgs) Handles btnRunTest.Click
        Try
            Call paddlog("Run main form")
            Dim frmM As frmMainTestForm = New frmMainTestForm
            frmM.Show()
            Call paddlog("Main form ok")
        Catch ex As Exception
            pAddLog("Error:" & ex.Message)
            Dim oEx As cSurveyPC.frmExceptionManager = New cSurveyPC.frmExceptionManager(Nothing, "", ex)
            Call oEx.ShowDialog()
        End Try
    End Sub

    Private Sub pAddLog(Text As String)
        TextBox1.AppendText(Text & vbCrLf)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            Dim sBackupFilename As String = "backup.reg"
            pAddLog("Backup impostazioni su " & sbackupfilename)
            Call Shell("reg export HKCU\Software\Cepelabs\cSurvey " & sBackupFilename)
        Catch ex As Exception
            pAddLog("Error:" & ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Try
            Dim sBackupFilename As String = "backup.reg"
            If My.Computer.FileSystem.FileExists(sBackupFilename) Then
                pAddLog("Ripristino impostazioni da " & sBackupFilename)
                Call Shell("reg import " & sBackupFilename)
            Else
                pAddLog("File " & sBackupFilename & " non trovato")
            End If
        Catch ex As Exception
            pAddLog("Error:" & ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try
            Dim sBackupFilename As String = "backup.reg"
            If My.Computer.FileSystem.FileExists(sBackupFilename) Then
                pAddLog("Reimpostazione parametri")
                Call Shell("reg delete HKCU\Software\Cepelabs\cSurvey /f")
            Else
                pAddLog("Reimpostazione annullata perchè backup non trovato")
            End If
        Catch ex As Exception
            pAddLog("Error:" & ex.Message)
        End Try
    End Sub
End Class
