﻿Imports System.Xml
Imports System.IO
Imports cSurveyPC.cSurvey.Net

Public Class frmHistory
    Private oSurvey As cSurvey.cSurvey
    Private sFilename As String

    Private bHistory As Boolean
    Private iHistoryMode As frmMain.HistoryModeEnum
    Private sHistoryWebURL As String
    Private bHistoryWebAuthReq As Boolean
    Private sHistoryWebUsername As String
    Private sHistoryWebPassword As String
    Private sHistoryFolder As String
    Private iHistoryDailyCopies As Integer
    Private iHistoryWebDailyCopies As Integer
    Private iHistoryMaxCopies As Integer
    Private iHistoryWebMaxCopies As Integer

    Friend Class OnAddEventArgs
        Inherits EventArgs

        Private iHistoryMode As frmMain.HistoryModeEnum
        Private oLastException As Exception
        Private bCancelled As Boolean

        Public ReadOnly Property HistoryMode As frmMain.HistoryModeEnum
            Get
                Return iHistoryMode
            End Get
        End Property

        Public Property LastException As Exception
            Get
                Return oLastException
            End Get
            Set(value As Exception)
                oLastException = value
            End Set
        End Property

        Public Property Cancelled As Boolean
            Get
                Return bCancelled
            End Get
            Set(value As Boolean)
                bCancelled = value
            End Set
        End Property

        Public Sub New(HistoryMode As frmMain.HistoryModeEnum)
            iHistoryMode = HistoryMode
        End Sub
    End Class

    Friend Event OnRestore(Sender As frmHistory, Args As EventArgs)
    Friend Event OnAdd(Sender As frmHistory, Args As OnAddEventArgs)

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call pRefresh()
    End Sub

    Private Sub pRefresh(Optional Mode As frmMain.HistoryModeEnum = frmMain.HistoryModeEnum.Both)
        Cursor = Cursors.WaitCursor

        Dim oCurrentFile As FileInfo
        If sFilename <> "" Then
            If My.Computer.FileSystem.FileExists(sFilename) Then
                oCurrentFile = My.Computer.FileSystem.GetFileInfo(sFilename)
            End If
        End If

        Call lvItems.Items.Clear()
        If btnShowLocal.Checked And btnShowLocal.Enabled Then
            If sHistoryFolder <> "" Then
                If My.Computer.FileSystem.DirectoryExists(sHistoryFolder) Then
                    Dim sSurveyHistoryFolder As String = IO.Path.Combine(sHistoryFolder, oSurvey.ID)
                    Try
                        If My.Computer.FileSystem.DirectoryExists(sSurveyHistoryFolder) Then
                            Dim oFolder As IO.DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(sSurveyHistoryFolder)
                            For Each oFile As IO.FileInfo In oFolder.GetFiles("*.CSZ").OrderBy(Function(fileinfo) fileinfo.LastWriteTime)
                                Dim sName As String
                                Dim sOrigin As String
                                Dim dDateStamp As DateTime
                                Dim sUsername As String

                                Dim oDetailsFile As IO.FileInfo = My.Computer.FileSystem.GetFileInfo(IO.Path.Combine(oFile.DirectoryName, IO.Path.GetFileNameWithoutExtension(oFile.Name) & ".xml"))
                                If oDetailsFile.Exists Then
                                    Dim oXML As XmlDocument = New XmlDocument
                                    oXML.Load(oDetailsFile.FullName)
                                    With oXML.Item("csurvey").Item("historydetails").Item("item")
                                        sName = .GetAttribute("name")
                                        sOrigin = .GetAttribute("origin")
                                        dDateStamp = .GetAttribute("datestamp")
                                        sUsername = .GetAttribute("username")
                                    End With
                                Else
                                    sName = oFile.Name
                                    sOrigin = "N/D"
                                    dDateStamp = oFile.LastWriteTime
                                    sUsername = "N/D"
                                End If

                                Dim oItem As ListViewItem = New ListViewItem
                                oItem.Group = lvItems.Groups("local")
                                oItem.ImageKey = "local"
                                oItem.Tag = oFile.FullName
                                oItem.Text = sName
                                Call oItem.SubItems.Add(sOrigin)
                                Call oItem.SubItems.Add(Strings.Format(oFile.Length, "#,##0"))
                                Call oItem.SubItems.Add(dDateStamp)
                                Call oItem.SubItems.Add(sUsername)
                                Call lvItems.Items.Add(oItem)

                                If Not oCurrentFile Is Nothing Then
                                    If oCurrentFile.LastWriteTime < oFile.LastWriteTime Then
                                        oItem.ForeColor = Color.Red
                                    End If
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        Call pLogAdd("error", String.Format(modMain.GetLocalizedString("history.textpart5"), ex.Message))
                        btnShowLocal.Checked = False
                        btnShowLocal.Enabled = False
                    End Try
                Else
                    Call pLogAdd("error", modMain.GetLocalizedString("history.textpart4"))
                    btnShowLocal.Checked = False
                    btnShowLocal.Enabled = False
                End If
            Else
                Call pLogAdd("error", modMain.GetLocalizedString("history.textpart6"))
                btnShowLocal.Checked = False
                btnShowLocal.Enabled = False
            End If
        End If
        If btnShowWeb.Checked And btnShowWeb.Enabled Then
            If sHistoryWebURL <> "" Then
                Try
                    Dim oNetHistory As cNetHistory = New cNetHistory(sHistoryWebURL, iHistoryMaxCopies, iHistoryDailyCopies)
                    If bHistoryWebAuthReq Then oNetHistory.SetCredential(sHistoryWebUsername, sHistoryWebPassword)
                    If oNetHistory.Login(sHistoryWebUsername, sHistoryWebPassword) Then
                        Dim oResult As List(Of cNetHistorySet)
                        If oNetHistory.GetSets(oSurvey.ID, oResult) Then
                            For Each oNetSet As cNetHistorySet In oResult
                                Dim sName As String = oNetSet.Name
                                Dim sOrigin As String = oNetSet.Origin
                                Dim iSize As Integer = oNetSet.Size
                                Dim dDateStamp As DateTime = oNetSet.DateStamp
                                Dim sUsername As String = oNetSet.Username

                                Dim oItem As ListViewItem = New ListViewItem
                                oItem.Group = lvItems.Groups("web")
                                oItem.ImageKey = "web"
                                oItem.Tag = oNetSet.ID
                                oItem.Text = sName
                                Call oItem.SubItems.Add(sOrigin)
                                Call oItem.SubItems.Add(Strings.Format(iSize, "#,##0"))
                                Call oItem.SubItems.Add(dDateStamp)
                                Call oItem.SubItems.Add(sUsername)
                                Call lvItems.Items.Add(oItem)

                                If Not oCurrentFile Is Nothing Then
                                    If oCurrentFile.LastWriteTime < oNetSet.DateStamp Then
                                        oItem.ForeColor = Color.Red
                                    End If
                                End If
                            Next
                        End If
                    Else
                        Call pLogAdd("error", modMain.GetLocalizedString("history.textpart1"))
                        btnShowWeb.Checked = False
                        btnShowWeb.Enabled = False
                    End If
                Catch ex As Exception
                    Call pLogAdd("error", String.Format(modMain.GetLocalizedString("history.textpart2"), ex.Message))
                    btnShowWeb.Checked = False
                    btnShowWeb.Enabled = False
                End Try
            Else
                Call pLogAdd("error", modMain.GetLocalizedString("history.textpart3"))
                btnShowWeb.Checked = False
                btnShowWeb.Enabled = False
            End If
        End If

        Call pButtonsEnabled()

        Cursor = Cursors.Default
    End Sub

    Private Sub pLogAdd(Type As String, Text As String)
        Dim oItem As ListViewItem = New ListViewItem(Text)
        If Type <> "" Then
            oItem.ImageKey = Type
        Else
            oItem.ImageKey = "info"
        End If
        Call oItem.SubItems.Add(Now.ToString)
        Call lvLog.Items.Add(oItem)
        Call oItem.EnsureVisible()
        lvLog.FocusedItem = oItem
    End Sub

    Public Sub New(Survey As cSurvey.cSurvey, Filename As String)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey
        sFilename = Filename

        Dim oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
        bHistory = oReg.GetValue("history.enabled", 0)
        iHistoryMode = oReg.GetValue("history.mode", 0)
        Select Case iHistoryMode
            Case 0
                btnShowLocal.Visible = True
                btnShowLocal.Enabled = True
                btnShowWeb.Visible = False
                btnShowWeb.Enabled = False
            Case 1
                btnShowLocal.Visible = False
                btnShowLocal.Enabled = False
                btnShowWeb.Visible = True
                btnShowWeb.Enabled = True
            Case 2
                btnShowLocal.Visible = True
                btnShowLocal.Enabled = True
                btnShowWeb.Visible = True
                btnShowWeb.Visible = True
        End Select

        sHistoryWebURL = oReg.GetValue("history.web.url", "")
        bHistoryWebAuthReq = oReg.GetValue("history.web.authreq", "0")
        sHistoryWebUsername = oReg.GetValue("history.web.username", "")
        sHistoryWebPassword = oReg.GetValue("history.web.password", "")
        If sHistoryWebPassword <> "" Then
            sHistoryWebPassword = New cLocalSecurity("csurvey").DecryptData(sHistoryWebPassword)
        End If
        sHistoryFolder = oReg.GetValue("history.folder", "")
        iHistoryDailyCopies = oReg.GetValue("history.maxdailycopies", 4)
        iHistoryWebDailyCopies = oReg.GetValue("history.web.maxdailycopies", 4)
        iHistoryMaxCopies = oReg.GetValue("history.maxcopies", 20)
        iHistoryWebMaxCopies = oReg.GetValue("history.web.maxcopies", 20)

        Call oReg.Close()
        Call oReg.Dispose()

        Call lvItems.Groups.Add(New ListViewGroup("local", "Revisioni locali"))
        Call lvItems.Groups.Add(New ListViewGroup("web", "Revisioni web"))

        Call pRefresh()
    End Sub

    Private Sub btnShowWeb_Click(sender As Object, e As EventArgs) Handles btnShowWeb.Click
        If btnShowLocal.Enabled Then
            btnShowWeb.Checked = Not btnShowWeb.Checked
            If Not btnShowWeb.Checked And Not btnShowLocal.Checked Then btnShowLocal.Checked = True
            Call pRefresh()
        Else
            btnShowWeb.Checked = True
        End If
    End Sub

    Private Sub btnShowLocal_Click(sender As Object, e As EventArgs) Handles btnShowLocal.Click
        If btnShowWeb.Enabled Then
            btnShowLocal.Checked = Not btnShowLocal.Checked
            If Not btnShowLocal.Checked And Not btnShowWeb.Checked Then btnShowWeb.Checked = True
            Call pRefresh()
        Else
            btnShowLocal.Checked = True
        End If
    End Sub

    Private Sub lvItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvItems.SelectedIndexChanged
        Call pButtonsEnabled()
    End Sub

    Private Sub pButtonsEnabled()
        Dim bEnabled As Boolean = Not lvItems.FocusedItem Is Nothing
        btnDelete.Enabled = bEnabled
        mnuItemsDelete.Enabled = bEnabled
        btnRestore.Enabled = bEnabled
        mnuItemsRestore.Enabled = bEnabled
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not lvItems.FocusedItem Is Nothing Then
            Dim oItem As ListViewItem = lvItems.FocusedItem
            Try
                Select Case oItem.Group.Name
                    Case "local"
                        Dim sFilename As String = oItem.Tag
                        Call My.Computer.FileSystem.DeleteFile(sFilename)
                        Try
                            Call My.Computer.FileSystem.DeleteFile(Path.Combine(Path.GetDirectoryName(sFilename), Path.GetFileNameWithoutExtension(sFilename) & ".xml"))
                            Call pLogAdd("", String.Format(modMain.GetLocalizedString("history.textpart12"), sFilename))
                        Catch ex As Exception
                            Call pLogAdd("error", String.Format(modMain.GetLocalizedString("history.textpart7"), ex.Message))
                            Call MsgBox(String.Format(modMain.GetLocalizedString("history.warning1"), ex.Message), MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, modMain.GetLocalizedString("history.warningtitle"))
                        End Try
                    Case "web"
                        Try
                            Dim iSetID As Integer = oItem.Tag
                            Dim oNetHistory As cNetHistory = New cNetHistory(sHistoryWebURL, iHistoryMaxCopies, iHistoryDailyCopies)
                            If oNetHistory.Login(sHistoryWebUsername, sHistoryWebPassword) Then
                                Dim iResult As Integer
                                If oNetHistory.DeleteSet(iSetID, iResult) Then
                                    Call pLogAdd("", String.Format(modMain.GetLocalizedString("history.textpart12"), oItem.Text))
                                Else
                                    Call pLogAdd("error", String.Format(modMain.GetLocalizedString("history.textpart7"), oNetHistory.LastMessage))
                                    Call MsgBox(String.Format(modmain.GetLocalizedString("history.warning1"), oNetHistory.LastMessage), MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, modMain.GetLocalizedString("history.warningtitle"))
                                End If
                            End If
                        Catch ex As Exception
                            Call pLogAdd("error", String.Format(modMain.GetLocalizedString("history.textpart7"), ex.Message))
                            Call MsgBox(String.Format(modMain.GetLocalizedString("history.warning1"), ex.Message), MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, modMain.GetLocalizedString("history.warningtitle"))
                        End Try
                End Select
                Call lvItems.Items.Remove(oItem)
                If Not lvItems.FocusedItem Is Nothing Then
                    lvItems.FocusedItem.Selected = True
                End If
            Catch ex As Exception
                Call pLogAdd("error", String.Format(modmain.GetLocalizedString("history.textpart7"), ex.Message))
                Call MsgBox(String.Format(modmain.GetLocalizedString("history.warning1"), ex.Message), MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, modMain.GetLocalizedString("history.warningtitle"))
            End Try
        End If
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        If Not lvItems.FocusedItem Is Nothing Then
            If MsgBox(modMain.GetLocalizedString("history.warning2"), MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, modMain.GetLocalizedString("history.warningtitle")) = MsgBoxResult.Yes Then
                Dim oItem As ListViewItem = lvItems.FocusedItem
                Try
                    Select Case oItem.Group.Name
                        Case "local"
                            Dim sTempFilename As String = oItem.Tag
                            Call My.Computer.FileSystem.MoveFile(sFilename, Path.Combine(Path.GetDirectoryName(sFilename), Path.GetFileNameWithoutExtension(sFilename) & "_restored" & Path.GetExtension(sFilename)), True)
                            Call My.Computer.FileSystem.CopyFile(sTempFilename, sFilename, True)

                            Call pLogAdd("", String.Format(modmain.GetLocalizedString("history.textpart11"), sTempFilename))
                        Case "web"
                            Dim iSetID As Integer = oItem.Tag
                            Dim oNetHistory As cNetHistory = New cNetHistory(sHistoryWebURL, iHistoryMaxCopies, iHistoryDailyCopies)
                            If oNetHistory.Login(sHistoryWebUsername, sHistoryWebPassword) Then
                                Dim oResult As List(Of cNetHistoryItem)
                                Call oNetHistory.GetFolder(iSetID, 0, oResult)
                                For Each oResultItem As cNetHistoryItem In oResult
                                    Dim sTempFilename As String
                                    If oNetHistory.Download(iSetID, oResultItem.DataID, sTempFilename) Then
                                        Call My.Computer.FileSystem.MoveFile(sFilename, Path.Combine(Path.GetDirectoryName(sFilename), Path.GetFileNameWithoutExtension(sFilename) & "_restored" & Path.GetExtension(sFilename)), True)
                                        Call My.Computer.FileSystem.MoveFile(sTempFilename, sFilename, True)
                                        RaiseEvent OnRestore(Me, New EventArgs)
                                        Call pLogAdd("", String.Format(modmain.GetLocalizedString("history.textpart11"), oItem.Text))
                                    Else
                                        Call pLogAdd("error", String.Format(modmain.GetLocalizedString("history.textpart10"), oNetHistory.LastMessage))
                                        Call MsgBox(String.Format(modmain.GetLocalizedString("history.warning3"), oNetHistory.LastMessage), MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, modMain.GetLocalizedString("history.warningtitle"))
                                    End If
                                Next
                            End If
                    End Select
                Catch ex As Exception
                    Call pLogAdd("error", String.Format(modmain.GetLocalizedString("history.textpart10"), ex.Message))
                    Call MsgBox(String.Format(modmain.GetLocalizedString("history.warning3"), ex.Message), MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, modMain.GetLocalizedString("history.warningtitle"))
                End Try
            End If
        End If
    End Sub

    Private Sub mnuItemsRefresh_Click(sender As Object, e As EventArgs) Handles mnuItemsRefresh.Click
        Call pRefresh()
    End Sub

    Private Sub mnuItemsDelete_Click(sender As Object, e As EventArgs) Handles mnuItemsDelete.Click
        Call btnDelete_Click(Nothing, Nothing)
    End Sub

    Private Sub mnuItemsRestore_Click(sender As Object, e As EventArgs) Handles mnuItemsRestore.Click
        Call btnRestore_Click(Nothing, Nothing)
    End Sub

    Private Sub mnuLogClean_Click(sender As Object, e As EventArgs) Handles mnuLogClean.Click
        Call lvLog.Items.Clear()
    End Sub

    Private Sub btnHistoryAdd_DropDownOpening(sender As Object, e As EventArgs) Handles btnHistoryAdd.DropDownOpening
        btnAddLocal.Enabled = btnShowLocal.Enabled
        btnAddWeb.Enabled = btnShowWeb.Enabled
    End Sub

    Private Sub btnAddLocal_Click(sender As Object, e As EventArgs) Handles btnAddLocal.Click
        Call pHistoryAdd(frmMain.HistoryModeEnum.Folder)
    End Sub

    Private Sub btnAddWeb_Click(sender As Object, e As EventArgs) Handles btnAddWeb.Click
        Call pHistoryAdd(frmMain.HistoryModeEnum.WebStorage)
    End Sub

    Private Sub pHistoryAdd(Mode As frmMain.HistoryModeEnum)
        Dim oEvent As OnAddEventArgs = New OnAddEventArgs(Mode)
        Cursor = Cursors.WaitCursor
        RaiseEvent OnAdd(Me, oEvent)
        If oEvent.Cancelled Then
            Call pLogAdd("error", String.Format(modMain.GetLocalizedString("history.textpart8"), oEvent.LastException.Message))
            Call MsgBox(String.Format(modmain.GetLocalizedString("history.warning4"), oEvent.LastException.Message), MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, modMain.GetLocalizedString("history.warningtitle"))
        Else
            Call pLogAdd("", modMain.GetLocalizedString("history.textpart9"))
            Call pRefresh(frmMain.HistoryModeEnum.WebStorage)
        End If
        Cursor = Cursors.Default
    End Sub

    'Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
    '    Dim iSetID As Integer = 94
    '    Dim iDataID As Integer = 56
    '    Dim oNetHistory As cNetHistory = New cNetHistory(sHistoryWebURL, iHistoryMaxCopies, iHistoryDailyCopies)
    '    If oNetHistory.Login(sHistoryWebUsername, sHistoryWebPassword) Then
    '        Call oNetHistory.Explode(iSetID, iDataID, 0)
    '    End If
    'End Sub

    'Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
    '    Dim iSetID As Integer = 94
    '    Dim iDataID As Integer = 56
    '    Dim oNetHistory As cNetHistory = New cNetHistory(sHistoryWebURL, iHistoryMaxCopies, iHistoryDailyCopies)
    '    If oNetHistory.Login(sHistoryWebUsername, sHistoryWebPassword) Then
    '        Call oNetHistory.Implode(iSetID, iDataID, 0)
    '    End If
    'End Sub
End Class