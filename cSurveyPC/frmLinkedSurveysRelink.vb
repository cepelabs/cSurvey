Imports BrightIdeasSoftware
Imports cSurveyPC.cSurvey
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors.Controls

friend Class frmLinkedSurveysRelink
    Private oSurvey As cSurveyPC.cSurvey.cSurvey
    Private sFilename As String
    Private sCurrentPath As String
    Private sDefaultFolder As String

    Private Class cAction
        Public Filename As String
        Public Folder As String

        Public Sub New(Folder As String, Filename As String)
            Me.Folder = Folder
            Me.Filename = Filename
        End Sub

        Public Function Fullname() As String
            Return IO.Path.Combine(Folder, Filename)
        End Function
    End Class

    Private oActions As Dictionary(Of cLinkedSurvey, cAction) = New Dictionary(Of cLinkedSurvey, cAction)

    Public Sub New(Survey As cSurveyPC.cSurvey.cSurvey, Filename As String, DefaultFolder As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        sFilename = Filename
        sDefaultFolder = DefaultFolder
        sCurrentPath = IO.Path.GetDirectoryName(sFilename)
        txtCurrentPath.Text = sCurrentPath
        oActions = New Dictionary(Of cLinkedSurvey, cAction)

        tvLinkedSurveys.IsSimpleDragSource = False
        tvLinkedSurveys.IsSimpleDropSink = False
        tvLinkedSurveys.AllowDrop = True

        colLinkedSurveysIcon.ImageGetter = Function(Value As Object)
                                               Dim oItem As cLinkedSurvey = DirectCast(Value, cLinkedSurvey)
                                               Dim sFullFilename As String = IO.Path.Combine(oItem.GetFolder, oItem.GetFilename)
                                               sFullFilename = modWindow.RelativeToAbsolutePath(sFullFilename, sCurrentPath)
                                               If My.Computer.FileSystem.FileExists(sFullFilename) Then
                                                   Return My.Resources.page_white_link
                                               Else
                                                   Return My.Resources.link_break
                                               End If
                                           End Function
        colLinkedSurveysFilename.AspectGetter = Function(Value As Object)
                                                    Dim oItem As cLinkedSurvey = DirectCast(Value, cLinkedSurvey)
                                                    Dim sFullFilename As String = IO.Path.Combine(oItem.GetFolder, oItem.GetFilename)
                                                    Return modWindow.RelativeToAbsolutePath(sFullFilename, sCurrentPath)
                                                End Function
        colLinkedSurveysNewIcon.ImageGetter = Function(Value As Object)
                                                  Dim oItem As cLinkedSurvey = DirectCast(Value, cLinkedSurvey)
                                                  If oActions.ContainsKey(oItem) Then
                                                      Dim sFullFilename As String = oActions(oItem).Fullname
                                                      If My.Computer.FileSystem.FileExists(sFullFilename) Then
                                                          Return My.Resources.page_white_link
                                                      Else
                                                          Return My.Resources.link_break
                                                      End If
                                                  Else
                                                      Return Nothing
                                                  End If
                                              End Function
        colLinkedSurveysNewFilename.AspectGetter = Function(Value As Object)
                                                       Dim oItem As cLinkedSurvey = DirectCast(Value, cLinkedSurvey)
                                                       Dim sFilename As String = oItem.GetFilename
                                                       Dim sFullFilename As String = ""
                                                       If oActions.ContainsKey(oItem) Then
                                                           Return oActions(oItem).Fullname
                                                       Else
                                                           Return ""
                                                       End If
                                                   End Function

        Call tvLinkedSurveys.RebuildColumns()

        Call tvLinkedSurveys.BeginUpdate()
        tvLinkedSurveys.VirtualMode = False
        tvLinkedSurveys.SetObjects(oSurvey.LinkedSurveys.GetParents)
        'Call tvLinkedSurveys.BuildList(True)
        Call tvLinkedSurveys.EndUpdate()
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        If oActions.Count > 0 Then
            For Each oLinkedSurvey As cLinkedSurvey In oActions.Keys
                Dim sNewFilename As String = oActions(oLinkedSurvey).Fullname
                Call oLinkedSurvey.Relink(sNewFilename)
            Next
        End If
    End Sub

    'Private Sub mnuRelinkChangePath_Click(sender As Object, e As EventArgs)
    '    Using oFB As FolderBrowserDialog = New FolderBrowserDialog()
    '        oFB.SelectedPath = sCurrentPath
    '        oFB.Description = modMain.GetLocalizedString("linkedsurveys.relinktitle")
    '        If oFB.ShowDialog(Me) = DialogResult.OK Then
    '            Dim sNewPath As String = oFB.SelectedPath
    '            For Each oLinkedSurvey As cLinkedSurvey In tvLinkedSurveys.SelectedObjects
    '                If oActions.ContainsKey(oLinkedSurvey) Then
    '                    Call oActions.Remove(oLinkedSurvey)
    '                End If
    '                Call oActions.Add(oLinkedSurvey, New cAction(sNewPath, oLinkedSurvey.GetFilename))
    '            Next
    '            Call tvLinkedSurveys.BuildList(True)
    '        End If
    '    End Using
    'End Sub

    'Private Sub mnuRelinkSelectAll_Click(sender As Object, e As EventArgs)
    '    Call tvLinkedSurveys.SelectAll()
    'End Sub

    'Private Sub mnuRelinkSelectAllBrokenLink_Click(sender As Object, e As EventArgs)
    '    Dim oSelectedItems As List(Of cLinkedSurvey) = New List(Of cLinkedSurvey)
    '    For Each oItem As cLinkedSurvey In tvLinkedSurveys.Objects
    '        If oActions.ContainsKey(oItem) Then
    '            If Not My.Computer.FileSystem.FileExists(oActions(oItem).Fullname) Then
    '                Call oSelectedItems.Add(oItem)
    '            End If
    '        Else
    '            If Not oItem.IsValid Then
    '                Call oSelectedItems.Add(oItem)
    '            End If
    '        End If
    '    Next
    '    Call tvLinkedSurveys.SelectObjects(oSelectedItems)
    'End Sub

    'Private Sub mnuRelinkDeselectAll_Click(sender As Object, e As EventArgs)
    '    Call tvLinkedSurveys.DeselectAll()
    'End Sub

    'Private Sub mnuRelink_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs)
    '    mnuRelinkChangePath.Enabled = tvLinkedSurveys.SelectedItems.Count > 0
    '    mnuRelinkChangeFile.Enabled = Not tvLinkedSurveys.FocusedObject Is Nothing
    '    mnuRelinkCancel.Enabled = mnuRelinkChangeFile.Enabled AndAlso oActions.ContainsKey(tvLinkedSurveys.FocusedObject)
    '    Dim sCommonPath As String = pGetCommonPathFromSelectedItem()
    '    If sCommonPath = "" Then
    '        mnuRelinkChangeCommonPath.Visible = False
    '    Else
    '        mnuRelinkChangeCommonPath.Text = String.Format(modMain.GetLocalizedString("linkedsurveys.changecommonpath"), sCommonPath)
    '        mnuRelinkChangeCommonPath.Visible = True
    '        mnuRelinkChangeCommonPath.Tag = sCommonPath
    '    End If
    'End Sub

    Private Function pGetCommonPathFromSelectedItem() As String
        If tvLinkedSurveys.SelectedObjects.Count < 2 Then
            Return ""
        Else
            Dim iIndex As Integer = 0
            Dim sCommonPath As String = ""
            For Each oLinkedSurvey As cLinkedSurvey In tvLinkedSurveys.SelectedObjects
                Dim sFullFilename As String = IO.Path.Combine(oLinkedSurvey.GetFolder, oLinkedSurvey.GetFilename)
                Dim sFolder As String = IO.Path.GetDirectoryName(modWindow.RelativeToAbsolutePath(sFullFilename, sCurrentPath))
                If iIndex = 0 Then
                    sCommonPath = sFolder
                    If Not sCommonPath.EndsWith(IO.Path.DirectorySeparatorChar) Then sCommonPath &= IO.Path.DirectorySeparatorChar
                Else
                    sCommonPath = pGetCommonPathPart(sFolder, sCommonPath)
                End If
                iIndex += 1
            Next
            Return sCommonPath
        End If
    End Function

    Private Function pGetCommonPathPart(Folder1 As String, Folder2 As String) As String
        Dim sFolder1Parts As List(Of String) = New List(Of String)(Folder1.ToLowerInvariant.Split({IO.Path.DirectorySeparatorChar}))
        Dim sFolder2Parts As List(Of String) = New List(Of String)(Folder2.ToLowerInvariant.Split({IO.Path.DirectorySeparatorChar}))
        Dim iIndex As Integer = 0
        Dim sCommonPath As String = ""
        Do While sFolder1Parts(iIndex) = sFolder2Parts(iIndex)
            If sCommonPath = "" Then
                sCommonPath = sFolder1Parts(iIndex)
                If sCommonPath.EndsWith(IO.Path.VolumeSeparatorChar) Then sCommonPath &= IO.Path.DirectorySeparatorChar
            Else
                sCommonPath = IO.Path.Combine(sCommonPath, sFolder1Parts(iIndex))
            End If
            iIndex += 1
            If iIndex >= sFolder1Parts.Count OrElse iIndex >= sFolder2Parts.Count Then Exit Do
        Loop
        If Not sCommonPath.EndsWith(IO.Path.DirectorySeparatorChar) Then sCommonPath &= IO.Path.DirectorySeparatorChar
        Return sCommonPath
    End Function

    Private Sub pChangeFile()
        Using olfd As OpenFileDialog = New OpenFileDialog
            With olfd
                .Filter = GetLocalizedString("main.filetypeCSURVEY") & " (*.CSZ;*.CSX)|*.CSZ;*.CSX|" & GetLocalizedString("main.filetypeALL") & " (*.*)|*.*"
                .FilterIndex = 1
                .DefaultExt = ".CSZ"
                If sDefaultFolder <> "" Then .InitialDirectory = sDefaultFolder
                If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Dim oLinkedSurvey As cLinkedSurvey = tvLinkedSurveys.FocusedObject
                    Dim sNewPath As String = IO.Path.GetDirectoryName(.FileName)
                    Dim sNewFilename As String = IO.Path.GetFileName(.FileName)
                    Call oActions.Add(oLinkedSurvey, New cAction(sNewPath, sNewFilename))
                    Call tvLinkedSurveys.BuildList(True)
                End If
            End With
        End Using
    End Sub

    Private Sub tvLinkedSurveys_DoubleClick(sender As Object, e As EventArgs) Handles tvLinkedSurveys.DoubleClick
        If Not tvLinkedSurveys.FocusedObject Is Nothing Then
            Call pChangeFile()
        End If
    End Sub

    'Private Sub mnuRelinkCancel_Click(sender As Object, e As EventArgs)
    '    Dim oLinkedSurvey As cLinkedSurvey = tvLinkedSurveys.FocusedObject
    '    Call oActions.Remove(oLinkedSurvey)
    '    Call tvLinkedSurveys.RefreshObject(oLinkedSurvey)
    'End Sub

    Private Sub mnuRelink_Popup(sender As Object, e As EventArgs) Handles mnuRelink.Popup
        btnChangePath.Enabled = tvLinkedSurveys.SelectedObjects.Count > 0
        Dim bEnabled As Boolean = Not tvLinkedSurveys.FocusedObject Is Nothing
        btnChangeFile.Enabled = bEnabled
        btnCancel.Enabled = btnChangeFile.Enabled AndAlso oActions.ContainsKey(tvLinkedSurveys.FocusedObject)
        Dim sCommonPath As String = pGetCommonPathFromSelectedItem()
        If sCommonPath = "" Then
            btnChangeCommonPath.Visibility = BarItemVisibility.Never
        Else
            btnChangeCommonPath.Caption = String.Format(modMain.GetLocalizedString("linkedsurveys.changecommonpath"), sCommonPath)
            btnChangeCommonPath.Visibility = BarItemVisibility.Always
            btnChangeCommonPath.Tag = sCommonPath
        End If
    End Sub

    Private Sub btnDeselectAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnDeselectAll.ItemClick
        Call tvLinkedSurveys.DeselectAll()
    End Sub

    Private Sub btnSelectAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnSelectAll.ItemClick
        Call tvLinkedSurveys.SelectAll()
    End Sub

    Private Sub btnChangeFile_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnChangeFile.ItemClick
        Call pChangeFile()
        'Using olfd As OpenFileDialog = New OpenFileDialog
        '    With olfd
        '        .Filter = GetLocalizedString("main.filetypeCSURVEY") & " (*.CSZ;*.CSX)|*.CSZ;*.CSX|" & GetLocalizedString("main.filetypeALL") & " (*.*)|*.*"
        '        .FilterIndex = 1
        '        .DefaultExt = ".CSZ"
        '        If sDefaultFolder <> "" Then .InitialDirectory = sDefaultFolder
        '        If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        '            Dim oLinkedSurvey As cLinkedSurvey = tvLinkedSurveys.FocusedObject
        '            Dim sNewPath As String = IO.Path.GetDirectoryName(.FileName)
        '            Dim sNewFilename As String = IO.Path.GetFileName(.FileName)
        '            Call oActions.Add(oLinkedSurvey, New cAction(sNewPath, sNewFilename))
        '            Call tvLinkedSurveys.RefreshObject(oLinkedSurvey)
        '        End If
        '    End With
        'End Using
    End Sub

    Private Sub btnChangePath_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnChangePath.ItemClick
        Using oFB As FolderBrowserDialog = New FolderBrowserDialog()
            oFB.SelectedPath = sCurrentPath
            oFB.Description = modMain.GetLocalizedString("linkedsurveys.relinktitle")
            If oFB.ShowDialog(Me) = DialogResult.OK Then
                Dim sNewPath As String = oFB.SelectedPath
                For Each oLinkedSurvey As cLinkedSurvey In tvLinkedSurveys.SelectedObjects
                    If oActions.ContainsKey(oLinkedSurvey) Then
                        Call oActions.Remove(oLinkedSurvey)
                    End If
                    Call oActions.Add(oLinkedSurvey, New cAction(sNewPath, oLinkedSurvey.GetFilename))
                Next
                Call tvLinkedSurveys.BuildList(True)
            End If
        End Using
    End Sub

    Private Sub btnSelectAllBrokenLink_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnSelectAllBrokenLink.ItemClick
        Dim oSelectedItems As List(Of cLinkedSurvey) = New List(Of cLinkedSurvey)
        For Each oItem As cLinkedSurvey In tvLinkedSurveys.Objects
            If oActions.ContainsKey(oItem) Then
                If Not My.Computer.FileSystem.FileExists(oActions(oItem).Fullname) Then
                    Call oSelectedItems.Add(oItem)
                End If
            Else
                If Not oItem.IsValid Then
                    Call oSelectedItems.Add(oItem)
                End If
            End If
        Next
        Call tvLinkedSurveys.SelectObjects(oSelectedItems)
    End Sub

    Private Sub btnCancel_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCancel.ItemClick
        Dim oLinkedSurvey As cLinkedSurvey = tvLinkedSurveys.FocusedObject
        Call oActions.Remove(oLinkedSurvey)
        Call tvLinkedSurveys.RefreshObject(oLinkedSurvey)
    End Sub

    'Private Sub mnuRelinkChangeCommonPath_Click(sender As Object, e As EventArgs)
    '    Dim sCommonPath As String = mnuRelinkChangeCommonPath.Tag
    '    Using oFB As FolderBrowserDialog = New FolderBrowserDialog()
    '        oFB.SelectedPath = sCurrentPath
    '        oFB.Description = modMain.GetLocalizedString("linkedsurveys.relinktitle")
    '        If oFB.ShowDialog(Me) = DialogResult.OK Then
    '            For Each oLinkedSurvey As cLinkedSurvey In tvLinkedSurveys.SelectedObjects
    '                Dim sFullFilename As String = IO.Path.Combine(oLinkedSurvey.GetFolder, oLinkedSurvey.GetFilename)
    '                Dim sFolder As String = IO.Path.GetDirectoryName(modWindow.RelativeToAbsolutePath(sFullFilename, sCurrentPath))
    '                Dim sOldPath As String = sFolder.Replace(sCommonPath, "")
    '                Dim sNewPath As String = IO.Path.Combine(oFB.SelectedPath, sOldPath)
    '                If oActions.ContainsKey(oLinkedSurvey) Then
    '                    Call oActions.Remove(oLinkedSurvey)
    '                End If
    '                Call oActions.Add(oLinkedSurvey, New cAction(sNewPath, oLinkedSurvey.GetFilename))
    '            Next
    '            Call tvLinkedSurveys.BuildList(True)
    '        End If
    '    End Using
    'End Sub

    Private Sub btnChangeCommonPath_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnChangeCommonPath.ItemClick
        Dim sCommonPath As String = btnChangeCommonPath.Tag
        Using oFB As FolderBrowserDialog = New FolderBrowserDialog()
            oFB.SelectedPath = sCurrentPath
            oFB.Description = modMain.GetLocalizedString("linkedsurveys.relinktitle")
            If oFB.ShowDialog(Me) = DialogResult.OK Then
                For Each oLinkedSurvey As cLinkedSurvey In tvLinkedSurveys.SelectedObjects
                    Dim sFullFilename As String = IO.Path.Combine(oLinkedSurvey.GetFolder, oLinkedSurvey.GetFilename)
                    Dim sFolder As String = IO.Path.GetDirectoryName(modWindow.RelativeToAbsolutePath(sFullFilename, sCurrentPath))
                    Dim sOldPath As String = sFolder.Replace(sCommonPath, "")
                    Dim sNewPath As String = IO.Path.Combine(oFB.SelectedPath, sOldPath)
                    If oActions.ContainsKey(oLinkedSurvey) Then
                        Call oActions.Remove(oLinkedSurvey)
                    End If
                    Call oActions.Add(oLinkedSurvey, New cAction(sNewPath, oLinkedSurvey.GetFilename))
                Next
                Call tvLinkedSurveys.BuildList(True)
            End If
        End Using
    End Sub

    'Private Sub TreeList1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraTreeList.TreeListCustomColumnDataEventArgs)
    '    If e.IsGetData Then
    '        Select Case e.Column.FieldName.ToLower
    '            Case "icon"
    '                Dim oItem As cLinkedSurvey = DirectCast(e.Row, cLinkedSurvey)
    '                Dim sFullFilename As String = IO.Path.Combine(oItem.GetFolder, oItem.GetFilename)
    '                sFullFilename = modWindow.RelativeToAbsolutePath(sFullFilename, sCurrentPath)
    '                If My.Computer.FileSystem.FileExists(sFullFilename) Then
    '                    e.Value = DirectCast(My.Resources.page_white_link, Image)
    '                Else
    '                    e.Value = DirectCast(My.Resources.link_break, Image)
    '                End If
    '            Case "filename"
    '                Dim oItem As cLinkedSurvey = DirectCast(e.Row, cLinkedSurvey)
    '                Dim sFullFilename As String = IO.Path.Combine(oItem.GetFolder, oItem.GetFilename)
    '                e.Value = modWindow.RelativeToAbsolutePath(sFullFilename, sCurrentPath)
    '            Case "newicon"
    '                Dim oItem As cLinkedSurvey = DirectCast(e.Row, cLinkedSurvey)
    '                If oActions.ContainsKey(oItem) Then
    '                    Dim sFullFilename As String = oActions(oItem).Fullname
    '                    If My.Computer.FileSystem.FileExists(sFullFilename) Then
    '                        e.Value = My.Resources.page_white_link
    '                    Else
    '                        e.Value = My.Resources.link_break
    '                    End If
    '                Else
    '                    e.Value = Nothing
    '                End If
    '            Case "newfilename"
    '                Dim oItem As cLinkedSurvey = DirectCast(e.Row, cLinkedSurvey)
    '                Dim sFilename As String = oItem.GetFilename
    '                Dim sFullFilename As String = ""
    '                If oActions.ContainsKey(oItem) Then
    '                    e.Value = oActions(oItem).Fullname
    '                Else
    '                    e.Value = ""
    '                End If
    '        End Select
    '    End If
    'End Sub

    Private Sub tvLinkedSurveys_MouseUp(sender As Object, e As MouseEventArgs) Handles tvLinkedSurveys.MouseUp
        If (e.Button And MouseButtons.Right) = MouseButtons.Right Then
            Call mnuRelink.ShowPopup(tvLinkedSurveys.PointToScreen(e.Location))
        End If
    End Sub
End Class