Imports System.Xml
Imports System.IO
Imports cSurveyPC.cSurvey.Net
Imports DevExpress.XtraTreeList.Nodes
Imports cSurveyPC.cSurvey.UIHelpers

Friend Class frmHistory
    Private oSurvey As cSurvey.cSurvey
    Private sFilename As String

    Private bHistory As Boolean
    Private iHistoryMode As frmMain2.HistoryModeEnum
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

        Private iHistoryMode As frmMain2.HistoryModeEnum
        Private oLastException As Exception
        Private bCancelled As Boolean

        Public ReadOnly Property HistoryMode As frmMain2.HistoryModeEnum
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

        Public Sub New(HistoryMode As frmMain2.HistoryModeEnum)
            iHistoryMode = HistoryMode
        End Sub
    End Class

    Friend Event OnRestore(Sender As frmHistory, Args As EventArgs)
    Friend Event OnAdd(Sender As frmHistory, Args As OnAddEventArgs)

    Private Sub pRefresh(Optional Mode As frmMain2.HistoryModeEnum = frmMain2.HistoryModeEnum.Both)
        If grdItems.DataSource IsNot Nothing Then
            Cursor = Cursors.WaitCursor

            Dim oCurrentFile As FileInfo
            If sFilename <> "" Then
                If My.Computer.FileSystem.FileExists(sFilename) Then
                    oCurrentFile = My.Computer.FileSystem.GetFileInfo(sFilename)
                End If
            End If

            grdItems.BeginUpdate()
            Dim oItems As cHistoryItems = grdItems.DataSource
            oItems.Clear()

            If btnShowLocal.Checked And btnShowLocal.Enabled Then
                If sHistoryFolder <> "" Then
                    If My.Computer.FileSystem.DirectoryExists(sHistoryFolder) Then
                        Dim sSurveyHistoryFolder As String = IO.Path.Combine(sHistoryFolder, oSurvey.ID)
                        Try
                            If My.Computer.FileSystem.DirectoryExists(sSurveyHistoryFolder) Then
                                Dim oFolder As IO.DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(sSurveyHistoryFolder)
                                For Each oFile As IO.FileInfo In oFolder.GetFiles("*.CSZ").OrderBy(Function(fileinfo) fileinfo.LastWriteTime)
                                    oItems.Add(cHistoryItemLocal.Create(oFile))
                                    'If Not oCurrentFile Is Nothing Then
                                    '    If oCurrentFile.LastWriteTime < oFile.LastWriteTime Then
                                    '        oItem.ForeColor = Color.Red
                                    '    End If
                                    'End If
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
                                    oItems.Add(cHistoryItemWeb.Create(oNetSet))

                                    'If Not oCurrentFile Is Nothing Then
                                    '    If oCurrentFile.LastWriteTime < oNetSet.DateStamp Then
                                    '        oItem.ForeColor = Color.Red
                                    '    End If
                                    'End If
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
            grdItems.EndUpdate()

            btnAddLocal.Enabled = btnShowLocal.Enabled
            btnAddWeb.Enabled = btnShowWeb.Enabled

            Call pButtonsEnabled()

            Cursor = Cursors.Default
        End If
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

        grdItems.DataSource = New cHistoryItems

        bHistory = My.Application.Settings.GetSetting("history.enabled", 0)
        iHistoryMode = My.Application.Settings.GetSetting("history.mode", 0)
        Select Case iHistoryMode
            Case 0
                btnShowLocal.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                btnShowLocal.Enabled = True
                btnShowWeb.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                btnShowWeb.Enabled = False
            Case 1
                btnShowLocal.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                btnShowLocal.Enabled = False
                btnShowWeb.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                btnShowWeb.Enabled = True
            Case 2
                btnShowLocal.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                btnShowLocal.Enabled = True
                btnShowWeb.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                btnShowWeb.Enabled = True
        End Select

        sHistoryWebURL = My.Application.Settings.GetSetting("history.web.url", "")
        bHistoryWebAuthReq = My.Application.Settings.GetSetting("history.web.authreq", "0")
        sHistoryWebUsername = My.Application.Settings.GetSetting("history.web.username", "")
        sHistoryWebPassword = My.Application.Settings.GetSetting("history.web.password", "")
        If sHistoryWebPassword <> "" Then
            sHistoryWebPassword = New cLocalSecurity("csurvey").DecryptData(sHistoryWebPassword)
        End If
        sHistoryFolder = My.Application.Settings.GetSetting("history.folder", "")
        iHistoryDailyCopies = My.Application.Settings.GetSetting("history.maxdailycopies", 4)
        iHistoryWebDailyCopies = My.Application.Settings.GetSetting("history.web.maxdailycopies", 4)
        iHistoryMaxCopies = My.Application.Settings.GetSetting("history.maxcopies", 20)
        iHistoryWebMaxCopies = My.Application.Settings.GetSetting("history.web.maxcopies", 20)

        'Call lvItems.Groups.Add(New ListViewGroup("local", "Revisioni locali"))
        'Call lvItems.Groups.Add(New ListViewGroup("web", "Revisioni web"))

        Call pRefresh()
    End Sub

    Private Sub lvItems_SelectedIndexChanged(sender As Object, e As EventArgs)
        Call pButtonsEnabled()
    End Sub

    Private Sub pButtonsEnabled()

        Dim bEnabled As Boolean = Not grdItemsView.GetFocusedObject Is Nothing
        btnDelete.Enabled = bEnabled
        btnRestore.Enabled = bEnabled
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As EventArgs) Handles btnDelete.ItemClick
        If Not grdItemsView.GetFocusedObject Is Nothing Then
            Dim oitems As cHistoryItems = grdItems.DataSource
            Dim oItem As cHistoryItemBase = grdItemsView.GetFocusedObject
            Try
                Select Case oItem.Group
                    Case "local"
                        Dim sFilename As String = oItem.ID
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
                            Dim iSetID As Integer = oItem.ID
                            Dim oNetHistory As cNetHistory = New cNetHistory(sHistoryWebURL, iHistoryMaxCopies, iHistoryDailyCopies)
                            If oNetHistory.Login(sHistoryWebUsername, sHistoryWebPassword) Then
                                Dim iResult As Integer
                                If oNetHistory.DeleteSet(iSetID, iResult) Then
                                    Call pLogAdd("", String.Format(modMain.GetLocalizedString("history.textpart12"), oItem.Name))
                                Else
                                    Call pLogAdd("error", String.Format(modMain.GetLocalizedString("history.textpart7"), oNetHistory.LastMessage))
                                    Call MsgBox(String.Format(modMain.GetLocalizedString("history.warning1"), oNetHistory.LastMessage), MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, modMain.GetLocalizedString("history.warningtitle"))
                                End If
                            End If
                        Catch ex As Exception
                            Call pLogAdd("error", String.Format(modMain.GetLocalizedString("history.textpart7"), ex.Message))
                            Call MsgBox(String.Format(modMain.GetLocalizedString("history.warning1"), ex.Message), MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, modMain.GetLocalizedString("history.warningtitle"))
                        End Try
                End Select
                oItems.remove(oItem)
                If Not grdItemsView.GetFocusedObject Is Nothing Then
                    grdItemsView.GetFocusedObject.Selected = True
                End If
            Catch ex As Exception
                Call pLogAdd("error", String.Format(modMain.GetLocalizedString("history.textpart7"), ex.Message))
                Call MsgBox(String.Format(modMain.GetLocalizedString("history.warning1"), ex.Message), MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, modMain.GetLocalizedString("history.warningtitle"))
            End Try
        End If
    End Sub

    Private Sub mnuItemsRefresh_Click(sender As Object, e As EventArgs)
        Call pRefresh()
    End Sub

    Private Sub mnuItemsDelete_Click(sender As Object, e As EventArgs)
        Call btnDelete_ItemClick(Nothing, Nothing)
    End Sub

    Private Sub mnuItemsRestore_Click(sender As Object, e As EventArgs)
        Call btnRestore.PerformClick()
    End Sub

    Private Sub mnuLogClean_Click(sender As Object, e As EventArgs) Handles mnuLogClean.Click
        Call lvLog.Items.Clear()
    End Sub

    Private Sub btnHistoryAdd_DropDownOpening(sender As Object, e As EventArgs)
        btnAddLocal.Enabled = btnShowLocal.Enabled
        btnAddWeb.Enabled = btnShowWeb.Enabled
    End Sub

    Private Sub pHistoryAdd(Mode As frmMain2.HistoryModeEnum)
        Dim oEvent As OnAddEventArgs = New OnAddEventArgs(Mode)
        Cursor = Cursors.WaitCursor
        RaiseEvent OnAdd(Me, oEvent)
        If oEvent.Cancelled Then
            Call pLogAdd("error", String.Format(modMain.GetLocalizedString("history.textpart8"), oEvent.LastException.Message))
            Call MsgBox(String.Format(modMain.GetLocalizedString("history.warning4"), oEvent.LastException.Message), MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, modMain.GetLocalizedString("history.warningtitle"))
        Else
            Call pLogAdd("", modMain.GetLocalizedString("history.textpart9"))
            Call pRefresh(frmMain2.HistoryModeEnum.WebStorage)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRefresh.ItemClick
        Call pRefresh()
    End Sub

    Private Sub btnShowLocal_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShowLocal.CheckedChanged
        If btnShowWeb.Enabled Then
            Call pRefresh()
        End If
    End Sub

    Private Sub btnShowWeb_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShowWeb.CheckedChanged
        If btnShowLocal.Enabled Then
            Call pRefresh()
        End If
    End Sub

    Private Sub btnAddWeb_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAddWeb.ItemClick
        Call pHistoryAdd(frmMain2.HistoryModeEnum.WebStorage)
    End Sub

    Private Sub btnAddLocal_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAddLocal.ItemClick
        Call pHistoryAdd(frmMain2.HistoryModeEnum.Folder)
    End Sub

    Private Sub btnRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRestore.ItemClick
        If Not grdItemsView.GetFocusedObject Is Nothing Then
            If MsgBox(modMain.GetLocalizedString("history.warning2"), MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, modMain.GetLocalizedString("history.warningtitle")) = MsgBoxResult.Yes Then
                Dim oItem As cHistoryItemBase = grdItemsView.GetFocusedObject
                Try
                    Select Case oItem.Group
                        Case "local"
                            Dim sTempFilename As String = oItem.ID
                            Call My.Computer.FileSystem.MoveFile(sFilename, Path.Combine(Path.GetDirectoryName(sFilename), Path.GetFileNameWithoutExtension(sFilename) & "_restored" & Path.GetExtension(sFilename)), True)
                            Call My.Computer.FileSystem.CopyFile(sTempFilename, sFilename, True)

                            Call pLogAdd("", String.Format(modMain.GetLocalizedString("history.textpart11"), sTempFilename))
                        Case "web"
                            Dim iSetID As Integer = oItem.ID
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
                                        Call pLogAdd("", String.Format(modMain.GetLocalizedString("history.textpart11"), oItem.Name))
                                    Else
                                        Call pLogAdd("error", String.Format(modMain.GetLocalizedString("history.textpart10"), oNetHistory.LastMessage))
                                        Call MsgBox(String.Format(modMain.GetLocalizedString("history.warning3"), oNetHistory.LastMessage), MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, modMain.GetLocalizedString("history.warningtitle"))
                                    End If
                                Next
                            End If
                    End Select
                Catch ex As Exception
                    Call pLogAdd("error", String.Format(modMain.GetLocalizedString("history.textpart10"), ex.Message))
                    Call MsgBox(String.Format(modMain.GetLocalizedString("history.warning3"), ex.Message), MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, modMain.GetLocalizedString("history.warningtitle"))
                End Try
            End If
        End If
    End Sub

    Private Sub tvItems_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs)
        Call pButtonsEnabled()
    End Sub

    Private Sub tvItems_PopupMenuShowing(sender As Object, e As DevExpress.XtraTreeList.PopupMenuShowingEventArgs)
        e.Menu.Items.Clear()
        mnuItems.ShowPopup(e.Point)
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