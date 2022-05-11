Imports System.Linq
Imports System.ComponentModel
Imports BrightIdeasSoftware
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraBars
Imports DevExpress.XtraTreeList

Friend Class cDockLinkedSurveys
    'Private oSurvey As cSurveyPC.cSurvey.cSurvey
    Private WithEvents oSurvey As cSurvey.cSurvey

    Private sDefaultFolder As String

    Friend Class cFilenameRequestEventArgs
        Inherits EventArgs

        Public Property Filename As String
    End Class

    Friend Event OnFilenameRequest(sender As Object, e As cFilenameRequestEventArgs)

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
            sDefaultFolder = oReg.GetValue("default.folder", "")
        End Using

        'Call pSetupLinkedSurveys()
    End Sub

    'Private Sub pSetupLinkedSurveys()
    '    tvLinkedSurveys.IsSimpleDragSource = True
    '    tvLinkedSurveys.IsSimpleDropSink = True
    '    Dim oDropSink As SimpleDropSink = New SimpleDropSink
    '    oDropSink.EnableFeedback = False
    '    tvLinkedSurveys.DropSink = oDropSink
    '    tvLinkedSurveys.AllowDrop = True

    '    tvLinkedSurveys.CanExpandGetter = Function(value As Object) As Boolean
    '                                          Return DirectCast(value, cLinkedSurvey).HasChildren
    '                                      End Function

    '    tvLinkedSurveys.ChildrenGetter = Function(value As Object) As IEnumerable
    '                                         Return DirectCast(value, cLinkedSurvey).GetChildren
    '                                     End Function

    '    colLinkedSurveysName.ImageGetter = Function(Value As Object)
    '                                           Return If(DirectCast(Value, cLinkedSurvey).IsValid, My.Resources.page_white_link, My.Resources.link_break)
    '                                       End Function
    '    colLinkedSurveysGPSState.ImageGetter = Function(Value As Object)
    '                                               Return If(DirectCast(Value, cLinkedSurvey).IsGeoreferenced, My.Resources.map, My.Resources.error2)
    '                                           End Function
    '    colLinkedSurveysName.AspectGetter = Function(Value As Object)
    '                                            Return DirectCast(Value, cLinkedSurvey).GetName
    '                                        End Function
    '    colLinkedSurveysFilename.AspectGetter = Function(Value As Object)
    '                                                Return DirectCast(Value, cLinkedSurvey).GetFilename
    '                                            End Function
    '    colLinkedSurveysFolder.AspectGetter = Function(Value As Object)
    '                                              Return DirectCast(Value, cLinkedSurvey).GetFolder
    '                                          End Function
    '    colLinkedSurveysNote.AspectGetter = Function(Value As Object)
    '                                            Return DirectCast(Value, cLinkedSurvey).Note
    '                                        End Function
    '    colLinkedSurveysNote.AspectPutter = Sub(rowObject As Object, newValue As Object)
    '                                            DirectCast(rowObject, cLinkedSurvey).Note = newValue
    '                                        End Sub
    '    colLinkedSurveysLastException.AspectGetter = Function(Value As Object)
    '                                                     Dim oItem As cLinkedSurvey = DirectCast(Value, cLinkedSurvey)
    '                                                     If IsNothing(oItem.LastException) Then
    '                                                         Return ""
    '                                                     Else
    '                                                         Return oItem.LastException.Message
    '                                                     End If
    '                                                 End Function
    '    colLinkedSurveysParent.AspectGetter = Function(Value As Object)
    '                                              Dim oParent As cLinkedSurvey = DirectCast(Value, cLinkedSurvey).Parent
    '                                              Return If(oParent Is Nothing, "", oParent.GetFilename)
    '                                          End Function

    '    tvLinkedSurveys.DragSource = New SimpleDragSource()

    '    Call tvLinkedSurveys.RebuildColumns()
    'End Sub

    Private Sub tvLinkedSurveys_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraTreeList.TreeListCustomColumnDataEventArgs) Handles TreeList1.CustomUnboundColumnData
        If e.IsGetData Then
            If e.Column Is colLinkName Then
                e.Value = DirectCast(e.Row, cLinkedSurvey).GetName
            ElseIf e.Column Is colLinkFilename Then
                e.Value = DirectCast(e.Row, cLinkedSurvey).GetFilename
            ElseIf e.Column Is colLinkFolder Then
                e.Value = DirectCast(e.Row, cLinkedSurvey).GetFolder
            End If
        End If
    End Sub

    Private Sub oSurvey_OnLinkedSurveysRefresh(Sender As cSurvey.cSurvey, Args As EventArgs) Handles oSurvey.OnLinkedSurveysRefresh
        Call pRefresh()
    End Sub

    Private Sub tvLinkedSurveys_CanDrop(sender As Object, e As OlvDropEventArgs)
        Try
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
        Catch ex As Exception
        End Try
        e.Effect = DragDropEffects.None
    End Sub

    'Private Sub tvSegmentAttachments_Dropped(sender As Object, e As OlvDropEventArgs)
    '    If e.DataObject.ContainsFileDropList Then
    '        Dim iWarning As Integer
    '        Dim sFiles As System.Collections.Specialized.StringCollection = e.DataObject.GetFileDropList()
    '        For Each sFile As String In sFiles
    '            Dim sExtension As String = IO.Path.GetExtension(sFile).ToLower
    '            If sExtension = ".csz" OrElse sExtension = ".csx" Then
    '                Dim oItem As cLinkedSurvey = oSurvey.LinkedSurveys.Add(sFile)
    '                If IsNothing(oItem) Then
    '                    iWarning += 1
    '                End If
    '            End If
    '        Next
    '        If iWarning > 0 Then
    '            'show a message in topbar (to be done)
    '        End If
    '        tvLinkedSurveys.Roots = oSurvey.LinkedSurveys.GetParents
    '    End If
    'End Sub

    Public Sub SetSurvey(Survey As cSurveyPC.cSurvey.cSurvey)
        oSurvey = Survey

        'Call tvLinkedSurveys.BeginUpdate()
        ''tvLinkedSurveys.VirtualMode = False
        ''tvLinkedSurveys.SetObjects(oSurvey.LinkedSurveys)
        'tvLinkedSurveys.Roots = oSurvey.LinkedSurveys.GetParents
        'Call tvLinkedSurveys.ExpandAll()
        ''Call tvLinkedSurveys.BuildList(False)
        'Call tvLinkedSurveys.EndUpdate()

        TreeList1.BeginUpdate()
        TreeList1.DataSource = New UIHelpers.cLinkedSurveysBindingList(oSurvey.LinkedSurveys)
        TreeList1.EndUpdate()
    End Sub

    'Private Sub tvLinkedSurveys_SelectionChanged(sender As Object, e As EventArgs) Handles tvLinkedSurveys.SelectionChanged
    '    If IsNothing(tvLinkedSurveys.FocusedObject) Then
    '        btnUnlink.Enabled = False
    '        btnOpen.Enabled = False
    '        btnCalculate.Enabled = False
    '    Else
    '        btnUnlink.Enabled = DirectCast(tvLinkedSurveys.FocusedObject, cLinkedSurvey).Parent Is Nothing
    '        btnOpen.Enabled = True
    '        btnCalculate.Enabled = True
    '    End If
    '    Dim bEnabled As Boolean = tvLinkedSurveys.Items.Count > 0
    '    btnManageLinks.Enabled = tvLinkedSurveys.Items.Count > 0
    '    btnUnlinkAll.Enabled = tvLinkedSurveys.Items.Count > 0
    'End Sub

    'Private Sub pRefresh()
    '    Call TreeList1.BeginUpdate()
    '    Call TreeList1.DataSource.Refresh
    '    Call TreeList1.EndUpdate()
    'End Sub

    Private Sub pRefresh(Optional RefreshSurveys As Boolean = False)
        Cursor = Cursors.WaitCursor
        If RefreshSurveys Then Call oSurvey.LinkedSurveys.Refresh()
        'tvLinkedSurveys.Roots = oSurvey.LinkedSurveys.GetParents
        'tvLinkedSurveys.Refresh()
        Call TreeList1.BeginUpdate()
        Call TreeList1.DataSource.Refresh
        Call TreeList1.EndUpdate()
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuContext_Opening(sender As Object, e As CancelEventArgs)
        'Dim oCurrentItem As cLinkedSurvey = tvLinkedSurveys.FocusedObject
        'Dim bCurrentItem As Boolean = Not oCurrentItem Is Nothing
        'mnuContextUnlink.Enabled = btnUnlink.Enabled
        'mnuContextOpen.Enabled = bCurrentItem
        'mnucontextCalculate.Enabled = bCurrentItem
        'mnucontextRefresh.Enabled = cmdRefresh.Enabled
        'Dim bEnabled As Boolean = tvLinkedSurveys.Items.Count > 0
        'mnuContextUnlinkAll.Enabled = bEnabled
        'Dim oArgs As cFilenameRequestEventArgs = New cFilenameRequestEventArgs()
        'RaiseEvent OnFilenameRequest(Me, oArgs)
        'mnuContextManageLinks.Enabled = bEnabled AndAlso oArgs.Filename <> ""
    End Sub

    Private Sub tvLinkedSurveys_DoubleClick(sender As Object, e As EventArgs)
        Call pOpen()
    End Sub

    Private Sub pOpen()
        Dim oLinkedSurvey As cLinkedSurvey = TreeList1.GetFocusedObject
        If Not IsNothing(oLinkedSurvey) Then
            Call Process.Start(Application.ExecutablePath, Chr(34) & oLinkedSurvey.Filename & Chr(34))
        End If
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
        Dim oLinkedSurvey As cLinkedSurvey = TreeList1.GetFocusedObject
        If Not IsNothing(oLinkedSurvey) Then
            Call oSurvey.RaiseOnProgressEvent("calculatelinkedsurvey", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, String.Format(modMain.GetLocalizedString("linkedsurveys.textpart2"), oLinkedSurvey.GetFilename), 0)
            Call oLinkedSurvey.LinkedSurvey.Calculate.Calculate()
            Call oSurvey.RaiseOnProgressEvent("calculatelinkedsurvey", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub cmdCalculate_DropDownOpening(sender As Object, e As EventArgs)
        'Dim oLinkedSurvey As cLinkedSurvey = tvLinkedSurveys.FocusedObject
        'If IsNothing(oLinkedSurvey) Then
        '    btnCalculateSelected.Enabled = False
        'Else
        '    btnCalculateSelected.Enabled = True
        'End If
        'btnCalculateAll.Enabled = tvLinkedSurveys.GetItemCount > 0
    End Sub

    Private Sub tvLinkedSurveys_ModelCanDrop(sender As Object, e As ModelDropEventArgs)
        If TypeOf e.TargetModel Is cLinkedSurvey Then
            Dim oLinkedSurvey As cLinkedSurvey = e.TargetModel
            If Not oLinkedSurvey.Survey Is oSurvey Then
                Call oSurvey.LinkedSurveys.Add(oLinkedSurvey.Filename)
            End If
        End If
    End Sub

    Private Sub btnAdd_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnAdd.ItemClick
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
                    End If
                End If
            End With
        End Using
    End Sub

    Private Sub btnOpen_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnOpen.ItemClick
        Call pOpen()
    End Sub

    Private Sub btnCalculateAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCalculateAll.ItemClick
        Call pCalculateAll()
    End Sub

    Private Sub btnCalculateSelected_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCalculateSelected.ItemClick
        Call pCalculate()
    End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnRefresh.ItemClick
        Call pRefresh(True)
    End Sub

    Private Sub btnUnlink_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnUnlink.ItemClick
        Dim oLinkedSurvey As cLinkedSurvey = TreeList1.GetFocusedObject
        If Not IsNothing(oLinkedSurvey) Then
            Call oSurvey.LinkedSurveys.Remove(oLinkedSurvey)
            'Call pRefresh()
            'tvLinkedSurveys.Roots = oSurvey.LinkedSurveys.GetParents
            'Call tvLinkedSurveys_SelectionChanged(tvLinkedSurveys, EventArgs.Empty)
        End If
    End Sub

    Private Sub btnUnlinkAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnUnlinkAll.ItemClick
        If MsgBox(GetLocalizedString("linkedsurveys.warning1"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("linkedsurveys.warningtitle")) = MsgBoxResult.Yes Then
            Call oSurvey.LinkedSurveys.Clear()
            'tvLinkedSurveys.Roots = oSurvey.LinkedSurveys.GetParents
            'Call tvLinkedSurveys_SelectionChanged(tvLinkedSurveys, EventArgs.Empty)
        End If
    End Sub

    Private Sub btnManageLinks_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnManageLinks.ItemClick
        Dim oArgs As cFilenameRequestEventArgs = New cFilenameRequestEventArgs()
        RaiseEvent OnFilenameRequest(Me, oArgs)
        Using frmLSR As frmLinkedSurveysRelink = New frmLinkedSurveysRelink(oSurvey, oArgs.Filename, sDefaultFolder)
            If frmLSR.ShowDialog(Me) = DialogResult.OK Then
                Call pRefresh(False)
            End If
        End Using
    End Sub

    Private Sub TreeList1_DoubleClick(sender As Object, e As EventArgs) Handles TreeList1.DoubleClick
        If Not TreeList1.GetFocusedObject Is Nothing Then
            Call pOpen()
        End If
    End Sub

    Private Sub TreeList1_PopupMenuShowing(sender As Object, e As DevExpress.XtraTreeList.PopupMenuShowingEventArgs) Handles TreeList1.PopupMenuShowing
        If e.HitInfo.InRowCell Then
            e.Allow = False
            Call mnuContext.ShowPopup(TreeList1.PointToScreen(e.Point))
        End If
    End Sub

    Private Sub TreeList1_DragOver(sender As Object, e As DragEventArgs) Handles TreeList1.DragOver
        e.Effect = If(e.Data.GetDataPresent(DataFormats.FileDrop), DragDropEffects.Copy, DragDropEffects.None)
    End Sub

    Private Sub TreeList1_DragDrop(sender As Object, e As DragEventArgs) Handles TreeList1.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim iWarning As Integer
            Dim sFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            For Each sFile As String In sFiles
                Dim sExtension As String = IO.Path.GetExtension(sFile).ToLower
                If sExtension = ".csz" OrElse sExtension = ".csx" Then
                    Dim oItem As cLinkedSurvey = oSurvey.LinkedSurveys.Add(sFile)
                    If IsNothing(oItem) Then
                        iWarning += 1
                    End If
                End If
            Next
            If iWarning > 0 Then
                'show a message in topbar (to be done)
            End If
        End If
    End Sub

    Private Sub TreeList1_FocusedNodeChanged(sender As Object, e As FocusedNodeChangedEventArgs) Handles TreeList1.FocusedNodeChanged
        Dim oLinkedSurvey As cLinkedSurvey = DirectCast(TreeList1.GetFocusedObject, cLinkedSurvey)
        If IsNothing(oLinkedSurvey) Then
            btnUnlink.Enabled = False
            btnOpen.Enabled = False
            btnCalculate.Enabled = False
        Else
            btnUnlink.Enabled = oLinkedSurvey.Parent Is Nothing
            btnOpen.Enabled = True
            btnCalculate.Enabled = True
        End If
        Dim bEnabled As Boolean = TreeList1.Nodes.Count > 0
        btnManageLinks.Enabled = TreeList1.Nodes.Count > 0
        btnUnlinkAll.Enabled = TreeList1.Nodes.Count > 0
    End Sub
End Class