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
        sCurrentLanguage = My.Application.Settings.GetSetting("language", "")
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
            Call cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("autosettigs.warning1"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("autosettigs.warningtitle"))
            DialogResult = Windows.Forms.DialogResult.Cancel
            Call Close()
        Else
            Call pSetProgress(GetLocalizedString("autosettigs.steptitle1"))

            Call My.Application.Settings.SetSetting("default.calculatemode", 1)
            Call My.Application.Settings.SetSetting("default.calculatetype", 2)

            Call My.Application.Settings.SetSetting("design.quality", 1)
            Call My.Application.Settings.SetSetting("design.rulers", 1)
            Call My.Application.Settings.SetSetting("design.rulers.style", 1)
            Call My.Application.Settings.SetSetting("design.metricgrid", 0)
            Call My.Application.Settings.SetSetting("design.multithreading", 0)
            Call My.Application.Settings.SetSetting("design.clipborder", 1)
            Call My.Application.Settings.SetSetting("design.linetype", 2)
            Call My.Application.Settings.SetSetting("design.useonlyanchortomove", 1)

            Call My.Application.Settings.SetSetting("therion.enabled", 1)
            Call My.Application.Settings.SetSetting("therion.path", sTherionPath)
            Call My.Application.Settings.SetSetting("therion.lock.enabled", 1)

            Call My.Application.Settings.SetSetting("therion.backgroundprocess", 1)
            Call My.Application.Settings.SetSetting("therion.trigpointsafename", 1)
            Call My.Application.Settings.SetSetting("therion.deletetempfiles", 1)
            Call My.Application.Settings.SetSetting("therion.segmentforcedirection", 1)
            Call My.Application.Settings.SetSetting("therion.segmentforcepath", 1)

            Call My.Application.Settings.SetSetting("zoom.type", 1)

            Call My.Application.Settings.SetSetting("debug.autosave", 1)

            Dim sLanguage As String = pGetLanguage()
            Call My.Application.Settings.SetSetting("language", sLanguage)
            sCurrentLanguage = sLanguage

            Call pSetProgress(GetLocalizedString("autosettigs.steptitle2"))

            Call cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("autosettings.warning2"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, GetLocalizedString("autosettigs.warningtitle"))

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
                Call My.Application.Settings.SetSetting("language", sLanguage)

                Call cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("autosettings.warning2"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, GetLocalizedString("autosettigs.warningtitle"))
            End If
        End If
    End Sub
End Class