Imports System.Linq
Imports System.ComponentModel
Imports BrightIdeasSoftware
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Public Class frmLinkedSurveys
    Private oSurvey As cSurveyPC.cSurvey.cSurvey

    Private sDefaultFolder As String

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
            sDefaultFolder = oReg.GetValue("default.folder", "")
        End Using

        Call pSetupLinkedSurveys()
    End Sub

    Protected Overrides Function GetPersistString() As String
        Return "linkedsurveys"
    End Function

    Private Sub pSetupLinkedSurveys()
        tvLinkedSurveys.IsSimpleDragSource = True
        tvLinkedSurveys.IsSimpleDropSink = True
        Dim oDropSink As SimpleDropSink = New SimpleDropSink
        oDropSink.EnableFeedback = False
        tvLinkedSurveys.DropSink = oDropSink
        tvLinkedSurveys.AllowDrop = True

        colLinkedSurveysIcon.ImageGetter = Function(Value As Object)
                                               Return If(DirectCast(Value, cLinkedSurvey).IsValid, My.Resources.page_white_link, My.Resources.link_break)
                                           End Function
        colLinkedSurveysGPSState.ImageGetter = Function(Value As Object)
                                                   Return If(DirectCast(Value, cLinkedSurvey).IsGeoreferenced, My.Resources.map, My.Resources._error)
                                               End Function
        colLinkedSurveysName.AspectGetter = Function(Value As Object)
                                                Return DirectCast(Value, cLinkedSurvey).GetName
                                            End Function
        colLinkedSurveysFilename.AspectGetter = Function(Value As Object)
                                                    Return DirectCast(Value, cLinkedSurvey).GetFilename
                                                End Function
        colLinkedSurveysFolder.AspectGetter = Function(Value As Object)
                                                  Return DirectCast(Value, cLinkedSurvey).GetFolder
                                              End Function
        colLinkedSurveysNote.AspectGetter = Function(Value As Object)
                                                Return DirectCast(Value, cLinkedSurvey).Note
                                            End Function
        colLinkedSurveysNote.AspectPutter = Sub(rowObject As Object, newValue As Object)
                                                DirectCast(rowObject, cLinkedSurvey).Note = newValue
                                            End Sub
        colLinkedSurveysLastException.AspectGetter = Function(Value As Object)
                                                         Dim oItem As cLinkedSurvey = DirectCast(Value, cLinkedSurvey)
                                                         If IsNothing(oItem.LastException) Then
                                                             Return ""
                                                         Else
                                                             Return oItem.LastException.Message
                                                         End If
                                                     End Function

        Call tvLinkedSurveys.RebuildColumns()
    End Sub

    Private Sub tvLinkedSurveys_CanDrop(sender As Object, e As OlvDropEventArgs) Handles tvLinkedSurveys.CanDrop
        If e.DataObject.ContainsFileDropList Then
            Dim sFiles As System.Collections.Specialized.StringCollection = e.DataObject.GetFileDropList()
            For Each sFile As String In sFiles
                Dim sExtension As String = IO.Path.GetExtension(sFile).ToLower
                If sExtension = ".csz" OrElse sExtension = ".csx" Then
                    e.Effect = DragDropEffects.Copy
                    e.Handled = True
                    Return
                End If
            Next
        End If
        e.Effect = DragDropEffects.None
    End Sub

    Private Sub tvSegmentAttachments_Dropped(sender As Object, e As OlvDropEventArgs) Handles tvLinkedSurveys.Dropped
        If e.DataObject.ContainsFileDropList Then
            Dim iWarning As Integer
            Dim sFiles As System.Collections.Specialized.StringCollection = e.DataObject.GetFileDropList()
            For Each sFile As String In sFiles
                Dim sExtension As String = IO.Path.GetExtension(sFile).ToLower
                If sExtension = ".csz" OrElse sExtension = ".csx" Then
                    Dim oItem As cLinkedSurvey = oSurvey.LinkedSurveys.Add(sFile)
                    If IsNothing(oItem) Then
                        iWarning += 1
                    Else
                        Call tvLinkedSurveys.BuildList(True)
                    End If
                End If
            Next
            If iwarning > 0 Then
                'show a message in topbar (to be done)
            End If
            Call tvLinkedSurveys.BuildList(True)
        End If
    End Sub

    Public Sub SetSurvey(Survey As cSurveyPC.cSurvey.cSurvey)
        oSurvey = Survey
        Call tvLinkedSurveys.BeginUpdate()
        tvLinkedSurveys.VirtualMode = False
        tvLinkedSurveys.SetObjects(oSurvey.LinkedSurveys)
        Call tvLinkedSurveys.BuildList(True)
        Call tvLinkedSurveys.EndUpdate()
    End Sub

    Private Sub cmdUnlink_Click(sender As Object, e As EventArgs) Handles cmdUnlink.Click
        If Not IsNothing(tvLinkedSurveys.FocusedObject) Then
            Dim oLinkedSurvey As cLinkedSurvey = tvLinkedSurveys.FocusedObject
            If Not IsNothing(oLinkedSurvey) Then
                Call oSurvey.LinkedSurveys.Remove(oLinkedSurvey)
                'Call tvLinkedSurveys.RemoveObject(oLinkedSurvey)
                Call tvLinkedSurveys.BuildList(True)
                Call tvLinkedSurveys_SelectionChanged(tvLinkedSurveys, EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        Using olfd As OpenFileDialog = New OpenFileDialog
            With olfd
                .Filter = GetLocalizedString("main.filetypeCSURVEY") & " (*.CSZ;*.CSX)|*.CSZ;*.CSX|" & GetLocalizedString("main.filetypeALL") & " (*.*)|*.*"
                .FilterIndex = 1
                .DefaultExt = ".CSZ"
                If sDefaultFolder <> "" Then .InitialDirectory = sDefaultFolder
                If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Dim oItem As cLinkedSurvey = oSurvey.LinkedSurveys.Add(.FileName)
                    If IsNothing(oItem) Then
                        'show a message in topbar (to be done)
                    Else
                        Call tvLinkedSurveys.BuildList(True)
                    End If
                End If
            End With
        End Using
    End Sub

    Private Sub tvLinkedSurveys_SelectionChanged(sender As Object, e As EventArgs) Handles tvLinkedSurveys.SelectionChanged
        If IsNothing(tvLinkedSurveys.FocusedObject) Then
            cmdUnlink.Enabled = False
            mnucontextCalculate.Enabled = False
        Else
            cmdUnlink.Enabled = True
            mnucontextCalculate.Enabled = True
        End If
    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        Call pRefresh()
    End Sub

    Private Sub pRefresh()
        Cursor = Cursors.WaitCursor
        Call oSurvey.LinkedSurveys.Refresh()
        Cursor = Cursors.Default
        Call tvLinkedSurveys.BuildList(True)
    End Sub

    Private Sub mnuContextRefresh_Click(sender As Object, e As EventArgs) Handles mnucontextRefresh.Click
        Call pRefresh()
    End Sub

    Private Sub mnuContextUnlink_Click(sender As Object, e As EventArgs) Handles mnuContextUnlink.Click
        Call cmdUnlink_Click(mnuContextUnlink, EventArgs.Empty)
    End Sub

    Private Sub mnuContext_Opening(sender As Object, e As CancelEventArgs) Handles mnuContext.Opening
        mnuContextUnlink.Enabled = cmdUnlink.Enabled
        mnuContextOpen.Enabled = cmdUnlink.Enabled
        mnucontextCalculate.Enabled = cmdUnlink.Enabled
        mnucontextRefresh.enabled = cmdRefresh.Enabled
    End Sub

    Private Sub mnuContextAdd_Click(sender As Object, e As EventArgs) Handles mnuContextAdd.Click
        Call cmdAdd_Click(mnuContext, EventArgs.Empty)
    End Sub

    Private Sub tvLinkedSurveys_DoubleClick(sender As Object, e As EventArgs) Handles tvLinkedSurveys.DoubleClick
        Call pOpen()
    End Sub

    Private Sub pOpen()
        Dim oLinkedSurvey As cLinkedSurvey = tvLinkedSurveys.FocusedObject
        If Not IsNothing(oLinkedSurvey) Then
            Call Process.Start(Application.ExecutablePath, Chr(34) & oLinkedSurvey.Filename & Chr(34))
        End If
    End Sub

    Private Sub mnucontextCalculate_Click(sender As Object, e As EventArgs) Handles mnucontextCalculate.Click
        Call pCalculate
    End Sub

    Private Sub mnuContextOpen_Click(sender As Object, e As EventArgs) Handles mnuContextOpen.Click
        Call pOpen
    End Sub

    Private Sub cmdCalculateSelected_Click(sender As Object, e As EventArgs) Handles cmdCalculateSelected.Click
        Call pCalculate()
    End Sub

    Private Sub pCalculateAll()
        Cursor = Cursors.WaitCursor
        For Each oLinkedSurvey In oSurvey.LinkedSurveys.GetUsable
            Call oSurvey.RaiseOnProgressEvent("calculatelinkedsurvey", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, String.Format(modMain.GetLocalizedString("linkedsurveys.textpart2"), oLinkedSurvey.GetFilename), 0)
            Try
                Call oLinkedSurvey.LinkedSurvey.Calculate.Calculate()
            Catch ex As Exception
                oSurvey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Error, "linkedsurvey.calculate error: " & ex.Message, True)
            End Try
            Call oSurvey.RaiseOnProgressEvent("calculatelinkedsurvey", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub pCalculate()
        Cursor = Cursors.WaitCursor
        Dim oLinkedSurvey As cLinkedSurvey = tvLinkedSurveys.FocusedObject
        If Not IsNothing(oLinkedSurvey) Then
            Call oSurvey.RaiseOnProgressEvent("calculatelinkedsurvey", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, String.Format(modMain.GetLocalizedString("linkedsurveys.textpart2"), oLinkedSurvey.GetFilename), 0)
            Call oLinkedSurvey.LinkedSurvey.Calculate.Calculate()
            Call oSurvey.RaiseOnProgressEvent("calculatelinkedsurvey", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub cmdCalculate_DropDownOpening(sender As Object, e As EventArgs) Handles cmdCalculate.DropDownOpening
        Dim oLinkedSurvey As cLinkedSurvey = tvLinkedSurveys.FocusedObject
        If IsNothing(oLinkedSurvey) Then
            cmdCalculateSelected.Enabled = False
        Else
            cmdCalculateSelected.Enabled = True
        End If
        cmdCalculateAll.Enabled = tvLinkedSurveys.GetItemCount > 0
    End Sub

    Private Sub cmdCalculateAll_Click(sender As Object, e As EventArgs) Handles cmdCalculateAll.Click
        Call pCalculateAll()
    End Sub
End Class