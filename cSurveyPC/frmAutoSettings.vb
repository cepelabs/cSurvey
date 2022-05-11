Imports System.IO

Imports System.Globalization
Imports System.Threading
Imports System.ComponentModel

friend Class frmAutoSettings
    Private sCurrentLanguage As String

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
            sCurrentLanguage = oReg.GetValue("language", "")
            Select Case sCurrentLanguage
                Case "it"
                    cboLanguage.SelectedIndex = 3
                Case "ru"
                    cboLanguage.SelectedIndex = 2
                Case "en"
                    cboLanguage.SelectedIndex = 1
                Case Else
                    cboLanguage.SelectedIndex = 0
            End Select
            Call oReg.Close()
        End Using
    End Sub

    Private Sub cmdAutoConfig_Click(sender As System.Object, e As System.EventArgs) Handles cmdAutoConfig.Click
        Call pAutoConfig()
    End Sub

    Private Function pFindTherion() As String
        Dim sTherionPath As String = ""
        Dim sDefaultPaths As List(Of String) = New List(Of String)
        'per i sistemi italiani accelero la ricerca mettendo i path standard...
        Call sDefaultPaths.Add("%SYSTEMDRIVE%\Program Files (x86)\Therion")
        Call sDefaultPaths.Add("%SYSTEMDRIVE%\Program Files\Therion")
        Call sDefaultPaths.Add("%SYSTEMDRIVE%\Programmi\Therion")
        'questi path dovrebbero essere 'sempre' quelli giusti...
        Call sDefaultPaths.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Therion"))
        Call sDefaultPaths.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Therion"))

        For Each sPath As String In sDefaultPaths
            Try
                sPath = Environment.ExpandEnvironmentVariables(sPath)
                Call pSetProgress(String.Format(modMain.GetLocalizedString("autosettigs.findtherion"), sPath))
                sTherionPath = Path.Combine(sPath, "therion.exe")
                If My.Computer.FileSystem.FileExists(sTherionPath) Then
                    Return sTherionPath
                End If
            Catch
            End Try
        Next

        For Each odrive As DriveInfo In My.Computer.FileSystem.Drives
            If odrive.IsReady Then
                sTherionPath = pFindTherionInSubFolder(odrive.RootDirectory)
                If sTherionPath <> "" Then
                    Return sTherionPath
                End If
            End If
        Next

        Return ""
    End Function

    Private Sub pSetProgress(Text As String)
        lblProgressInfo.Text = Text
        lblProgressInfo.Refresh()
    End Sub

    Private Function pFindTherionInSubFolder(Path As DirectoryInfo) As String
        Try
            Call pSetProgress(String.Format(modMain.GetLocalizedString("autosettigs.findtherion"), Path.FullName))
            For Each fl As FileInfo In Path.GetFiles("therion.exe")
                Return fl.FullName
            Next
            For Each fd As DirectoryInfo In Path.GetDirectories
                Dim sTherionPath As String = pFindTherionInSubFolder(fd)
                If sTherionPath <> "" Then
                    Return sTherionPath
                End If
            Next
            Return ""
        Catch
            Return ""
        End Try
    End Function

    Private Sub pAutoConfig()
        cmdAutoConfig.Enabled = False
        cmdAutoConfig.Visible = False
        pnlProgress.Visible = True

        Dim sTherionPath As String = pFindTherion()

        If sTherionPath = "" Then
            Call MsgBox(GetLocalizedString("autosettigs.warning1"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("autosettigs.warningtitle"))
            DialogResult = Windows.Forms.DialogResult.Cancel
            Call Close()
        Else
            Call pSetProgress(GetLocalizedString("autosettigs.steptitle1"))
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)

                Call oReg.SetValue("default.calculatemode", 1)
                Call oReg.SetValue("default.calculatetype", 2)

                Call oReg.SetValue("design.quality", 1)
                Call oReg.SetValue("design.rulers", 1)
                Call oReg.SetValue("design.rulers.style", 1)
                Call oReg.SetValue("design.metricgrid", 0)
                Call oReg.SetValue("design.multithreading", 0)
                Call oReg.SetValue("design.clipborder", 1)
                Call oReg.SetValue("design.linetype", 2)
                Call oReg.SetValue("design.useonlyanchortomove", 1)

                Call oReg.SetValue("therion.enabled", 1)
                Call oReg.SetValue("therion.path", sTherionPath)
                Call oReg.SetValue("therion.lock.enabled", 1)

                Call oReg.SetValue("therion.backgroundprocess", 1)
                Call oReg.SetValue("therion.trigpointsafename", 1)
                Call oReg.SetValue("therion.deletetempfiles", 1)
                Call oReg.SetValue("therion.segmentforcedirection", 1)
                Call oReg.SetValue("therion.segmentforcepath", 1)

                Call oReg.SetValue("zoom.type", 1)

                Call oReg.SetValue("debug.autosave", 1)

                Dim sLanguage As String = pGetLanguage()
                Call oReg.SetValue("language", sLanguage)
                sCurrentLanguage = sLanguage

                Call oReg.Close()
            End Using

            Call pSetProgress(GetLocalizedString("autosettigs.steptitle2"))

            Call MsgBox(GetLocalizedString("autosettings.warning2"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, GetLocalizedString("autosettigs.warningtitle"))

            cmdAutoConfig.Enabled = True
            cmdAutoConfig.Visible = True
            pnlProgress.Visible = False

            DialogResult = Windows.Forms.DialogResult.OK
            Call Close()
        End If
    End Sub

    Private Sub cboLanguage_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboLanguage.SelectedIndexChanged
        Dim sLanguage As String = pGetLanguage()
        Call pChangeLanguage(sLanguage)
    End Sub

    Private Sub pChangeLanguage(ByVal Language As String)
        For Each oControl As Control In Me.Controls
            Dim oResources As ComponentResourceManager = New ComponentResourceManager(GetType(frmAutoSettings))
            Call oResources.ApplyResources(oControl, oControl.Name, New CultureInfo(Language))
        Next
    End Sub

    Private Function pGetLanguage() As String
        Select Case cboLanguage.SelectedIndex
            Case 0
                Return ""
            Case 1
                Return "en"
            Case 2
                Return "ru"
            Case 3
                Return "it"
        End Select
    End Function

    Private Sub frmAutoSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Dim sLanguage As String = pGetLanguage()
            If sCurrentLanguage <> sLanguage Then
                Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
                    Call oReg.SetValue("language", sLanguage)
                    Call oReg.Close()
                End Using

                Call MsgBox(GetLocalizedString("autosettings.warning2"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, GetLocalizedString("autosettigs.warningtitle"))
            End If
        End If
    End Sub
End Class