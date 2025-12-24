Imports System.Linq
Imports System.ComponentModel
Imports BrightIdeasSoftware
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraRichEdit.API.Native
Imports cSurveyPC.cSurvey.Helper.Editor
Imports DevExpress.XtraGrid.Views.Grid

Friend Class cDockConsole
    Private oSurvey As cSurveyPC.cSurvey.cSurvey

    Private iMaxLogCount As Integer = 512

    Private Class cLogItem
        Private dLogDateTime As Date
        Private iLogType As cSurvey.cSurvey.LogEntryType
        Private sLogText As String
        Private sHTMLText As String
        Private sLogURI As String

        Public ReadOnly Property HTMLText As String
            Get
                Return sHTMLText
            End Get
        End Property

        Public Sub New(LogDateTime As Date, LogType As cSurvey.cSurvey.LogEntryType, LogText As String, HTMLText As String, LogURI As String)
            dLogDateTime = LogDateTime
            iLogType = LogType
            sLogText = LogText
            sHTMLText = HTMLText
            sLogURI = LogURI
        End Sub

        Public ReadOnly Property LogType As cSurvey.cSurvey.LogEntryType
            Get
                Return iLogType
            End Get
        End Property

        Public ReadOnly Property LogURI As String
            Get
                Return sLogURI
            End Get
        End Property

        Public ReadOnly Property LogText As String
            Get
                Return sLogText
            End Get
        End Property

        Public ReadOnly Property LogDateTime As Date
            Get
                Return dLogDateTime
            End Get
        End Property
    End Class

    Private bLogVerbose As Boolean
    Private oLog As BindingList(Of cLogItem)
    Private sLogFilename As String = Nothing
    Private oLogWriter As IO.StreamWriter
    Private bLogEnabled As Boolean

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(Me, False)
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(GridView1, False)
        BarManager.ForceInitialize()

        oLog = New BindingList(Of cLogItem)
        GridControl1.DataSource = oLog

        RestoreSettings()
    End Sub

    Public Sub SetSurvey(Survey As cSurveyPC.cSurvey.cSurvey)
        oSurvey = Survey
    End Sub

    Public Sub RestoreSettings()
        btnOpenFileLog.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        bLogVerbose = My.Application.Settings.GetSetting("debug.log.verbose", False)
        bLogEnabled = False
        If oLogWriter IsNot Nothing Then
            Call oLogWriter.Flush()
            Call oLogWriter.Close()
            Call oLogWriter.Dispose()
        End If
        If My.Application.Settings.GetSetting("debug.log.writeonfile", False) Then
            sLogFilename = IO.Path.Combine(modMain.GetUserApplicationPath(), Now.ToString("yyyyMMddhhmmssfff") & ".log")
        Else
            sLogFilename = Nothing
        End If
        oLogWriter = Nothing
        iMaxLogCount = My.Application.Settings.GetSetting("debug.log.maxlinecount", 512)
    End Sub

    Private Sub pLogEnable()
        bLogEnabled = True
        btnOpenFileLog.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        oLogWriter = My.Computer.FileSystem.OpenTextFileWriter(sLogFilename, False)
    End Sub

    Public Sub Clear()
        Call oLog.Clear()
    End Sub

    Public Sub Append(ByVal Type As cSurvey.cSurvey.LogEntryType, Text As String)
        Call Append(Type, Text, "")
    End Sub

    Public Sub Append(ByVal Type As cSurvey.cSurvey.LogEntryType, Text As String, URI As String)
        If Not GridControl1.IsDisposed Then
            If Text <> "" Then
                Dim sLines As String() = Text.Split(vbCr)
                For Each sLine As String In sLines
                    sLine = sLine.Replace(vbCr, "").Replace(vbLf, "")

                    Dim iBaseType As cSurvey.cSurvey.LogEntryType = Type And cSurvey.cSurvey.LogEntryType.BaseMask
                    Dim bIsImportant As Boolean = (Type And cSurvey.cSurvey.LogEntryType.Important) = cSurvey.cSurvey.LogEntryType.Important
                    Dim iSource As cSurvey.cSurvey.LogEntryType = Type And cSurvey.cSurvey.LogEntryType.SourceMask

                    Dim bAboveInfo As Boolean = False
                    If bIsImportant OrElse iBaseType = cSurvey.cSurvey.LogEntryType.Warning OrElse iBaseType = cSurvey.cSurvey.LogEntryType.Error OrElse (iBaseType = cSurvey.cSurvey.LogEntryType.Unknown AndAlso (Text Like "* error -- *")) Then
                        bAboveInfo = True
                    End If
                    If bLogVerbose OrElse bAboveInfo Then
                        Dim dNow As Date = Now

                        GridControl1.BeginUpdate()

                        Do While oLog.Count > iMaxLogCount
                            Call oLog.RemoveAt(0)
                        Loop

                        Dim oColor As System.Drawing.Color
                        If iBaseType = cSurvey.cSurvey.LogEntryType.Error OrElse (iBaseType = cSurvey.cSurvey.LogEntryType.Unknown AndAlso (sLine Like "* error -- *")) Then
                            oColor = Color.DarkRed
                        ElseIf iBaseType = cSurvey.cSurvey.LogEntryType.Warning Then
                            oColor = Color.Orange
                        Else
                            oColor = My.Application.RuntimeSettings.GetSetting("forecolor", SystemColors.WindowText)
                        End If
                        Dim sHTMLLine As String
                        Dim sHTMLLinePrefix As String = ""
                        If iSource = cSurvey.cSurvey.LogEntryType.SourceConsole Then
                            sHTMLLinePrefix = "<image=#console1;size=16,16>"
                        End If
                        If URI = "" Then
                            sHTMLLine = sHTMLLinePrefix & "<color=" & ColorTranslator.ToHtml(oColor) & ">" & sLine & "</color>"
                        Else
                            sHTMLLine = sHTMLLinePrefix & "<href=""" & URI & """><color=" & ColorTranslator.ToHtml(oColor) & ">" & sLine & "</color><</href>"
                        End If
                        oLog.Add(New cLogItem(dNow, Type, sLine, sHTMLLine, URI))

                        GridControl1.EndUpdate()
                        GridView1.MoveLastVisible()

                        If sLogFilename IsNot Nothing Then
                            If Not bLogEnabled Then pLogEnable()
                            Call oLogWriter.WriteLine(dNow.ToString("yyyy-MM-dd hh:mm:ss.fff") & vbTab & Type.ToString("D") & vbTab & sLine)
                            Call oLogWriter.Flush()
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    'Private Sub txtConsole_DocumentLoaded(sender As Object, e As EventArgs) Handles txtConsole.DocumentLoaded
    '    txtConsole.Document.DefaultCharacterProperties.FontName = "Lucida Console"
    '    txtConsole.Document.DefaultCharacterProperties.FontSize = 8
    '    txtConsole.Document.DefaultParagraphProperties.LineSpacingType = ParagraphLineSpacing.Single
    'End Sub

    Private Sub btnClear_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClear.ItemClick
        Call Clear()
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        Using oSFD As SaveFileDialog = New SaveFileDialog
            With oSFD
                .OverwritePrompt = True
                .Filter = GetLocalizedString("main.filetypeTXT") & " (*.TXT)|*.TXT|" & GetLocalizedString("main.filetypeDOCX") & " (*.DOCX)|*.DOCX"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Select Case IO.Path.GetExtension(.FileName)
                        Case ".docx"
                            GridControl1.ExportToDocx(.FileName)
                        Case Else
                            GridControl1.ExportToText(.FileName)
                    End Select
                End If
            End With
        End Using
    End Sub

    Public Event ConsoleLinkClick(Sender As Object, e As cInternalLinkEventArgs)
    'Private Sub txtConsole_HyperlinkClick(sender As Object, e As DevExpress.XtraRichEdit.HyperlinkClickEventArgs)
    '    RaiseEvent ConsoleLinkClick(Me, New cInternalLinkEventArgs(e.Hyperlink.NavigateUri))
    'End Sub

    Private Sub mnuConsole_BeforePopup(sender As Object, e As CancelEventArgs) Handles mnuConsole.BeforePopup
        'btnCopy.Enabled = txtConsole.Document.GetText(txtConsole.Document.Selection).Trim <> ""
        btnCopy.Enabled = GridView1.GetFocusedRow IsNot Nothing
    End Sub

    'Private Sub txtConsole_PopupMenuShowing(sender As Object, e As DevExpress.XtraRichEdit.PopupMenuShowingEventArgs)
    '    e.Menu.Items.Clear()
    '    mnuConsole.ShowPopup(Cursor.Position)
    'End Sub

    Private Sub btnCopy_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCopy.ItemClick
        'Call txtConsole.Copy()
        Dim oItem As cLogItem = DirectCast(GridView1.GetFocusedRow, cLogItem)
        If oItem IsNot Nothing Then
            Clipboard.SetText(oItem.LogText)
        End If
    End Sub

    Private Sub GridView1_HyperlinkClick(sender As Object, e As GridHyperlinkClickEventArgs) Handles GridView1.HyperlinkClick
        RaiseEvent ConsoleLinkClick(Me, New cInternalLinkEventArgs(e.Link))
    End Sub

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        e.Menu.Items.Clear()
        mnuConsole.ShowPopup(Cursor.Position)
    End Sub

    Private Sub btnOpenFileLog_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnOpenFileLog.ItemClick
        If sLogFilename IsNot Nothing Then
            Call Shell("EXPLORER " & Chr(34) & sLogFilename & Chr(34))
        End If
    End Sub
End Class