Imports BrightIdeasSoftware
Imports cSurveyPC.cSurvey
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors.Controls

Friend Class frmLinkedSurveysRelink
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
        grdLS.DataSource = New UIHelpers.cLinkedSurveyRelinker(oSurvey.LinkedSurveys.GetParents)

        'tvLinkedSurveys.IsSimpleDragSource = False
        'tvLinkedSurveys.IsSimpleDropSink = False
        'tvLinkedSurveys.AllowDrop = True



        'Call tvLinkedSurveys.RebuildColumns()

        'Call tvLinkedSurveys.BeginUpdate()
        'tvLinkedSurveys.VirtualMode = False
        'tvLinkedSurveys.SetObjects(oSurvey.LinkedSurveys.GetParents)
        ''Call tvLinkedSurveys.BuildList(True)
        'Call tvLinkedSurveys.EndUpdate()
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        If oActions.Count > 0 Then
            For Each oLinkedSurvey As cLinkedSurvey In oActions.Keys
                Dim sNewFilename As String = oActions(oLinkedSurvey).Fullname
                Call oLinkedSurvey.Relink(sNewFilename)
            Next
        End If
    End Sub

    Private Function pGetCommonPathFromSelectedItem() As String
        Dim oItems As UIHelpers.cLinkedSurveyRelinker = grdLS.DataSource
        If oItems.GetSelected.Count < 2 Then
            Return ""
        Else
            Dim iIndex As Integer = 0
            Dim sCommonPath As String = ""
            For Each oLinkedSurvey As cLinkedSurvey In oItems.GetSelected
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
                    Dim oPlaceholder As UIHelpers.cLinkedSurveyRelinkerPlaceholder = grdViewLS.GetFocusedObject
                    Dim sNewPath As String = IO.Path.GetDirectoryName(.FileName)
                    Dim sNewFilename As String = IO.Path.GetFileName(.FileName)
                    Call oActions.Add(oPlaceholder.LinkedSurvey, New cAction(sNewPath, sNewFilename))
                    Call grdLS.RefreshDataSource()
                End If
            End With
        End Using
    End Sub

    Private Sub tvLinkedSurveys_DoubleClick(sender As Object, e As EventArgs)
        Dim oPlaceholder As UIHelpers.cLinkedSurveyRelinkerPlaceholder = grdViewLS.GetFocusedObject
        If oPlaceholder IsNot Nothing Then
            Call pChangeFile()
        End If
    End Sub

    Private Sub mnuRelink_Popup(sender As Object, e As EventArgs) Handles mnuRelink.Popup
        Dim oItems As UIHelpers.cLinkedSurveyRelinker = grdLS.DataSource
        btnChangePath.Enabled = oItems.GetSelected.Count > 0
        Dim oPlaceholder As UIHelpers.cLinkedSurveyRelinkerPlaceholder = grdViewLS.GetFocusedObject
        Dim bEnabled As Boolean = Not oPlaceholder Is Nothing
        btnChangeFile.Enabled = bEnabled
        btnCancel.Enabled = btnChangeFile.Enabled AndAlso oActions.ContainsKey(oPlaceholder.LinkedSurvey)
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
        Dim oItems As UIHelpers.cLinkedSurveyRelinker = grdLS.DataSource
        Call oItems.DeselectAll()
        Call grdLS.RefreshDataSource()
    End Sub

    Private Sub btnSelectAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnSelectAll.ItemClick
        Dim oItems As UIHelpers.cLinkedSurveyRelinker = grdLS.DataSource
        Call oItems.SelectAll()
        Call grdLS.RefreshDataSource()
    End Sub

    Private Sub btnChangeFile_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnChangeFile.ItemClick
        Call pChangeFile()
    End Sub

    Private Sub btnChangePath_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnChangePath.ItemClick
        Dim oItems As UIHelpers.cLinkedSurveyRelinker = grdLS.DataSource
        Using oFB As FolderBrowserDialog = New FolderBrowserDialog()
            oFB.SelectedPath = sCurrentPath
            oFB.Description = modMain.GetLocalizedString("linkedsurveys.relinktitle")
            If oFB.ShowDialog(Me) = DialogResult.OK Then
                Dim sNewPath As String = oFB.SelectedPath
                For Each oLinkedSurvey As cLinkedSurvey In oItems.GetSelected
                    If oActions.ContainsKey(oLinkedSurvey) Then
                        Call oActions.Remove(oLinkedSurvey)
                    End If
                    Call oActions.Add(oLinkedSurvey, New cAction(sNewPath, oLinkedSurvey.GetFilename))
                Next
                Call grdLS.RefreshDataSource()
            End If
        End Using
    End Sub

    Private Sub btnSelectAllBrokenLink_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnSelectAllBrokenLink.ItemClick
        Dim oItems As UIHelpers.cLinkedSurveyRelinker = grdLS.DataSource
        Dim oSelectedItems As List(Of cLinkedSurvey) = New List(Of cLinkedSurvey)
        For Each oPlaceholder As UIHelpers.cLinkedSurveyRelinkerPlaceholder In oItems
            If oActions.ContainsKey(oPlaceholder.LinkedSurvey) Then
                If Not My.Computer.FileSystem.FileExists(oActions(oPlaceholder.LinkedSurvey).Fullname) Then
                    Call oSelectedItems.Add(oPlaceholder.LinkedSurvey)
                End If
            Else
                If Not oPlaceholder.LinkedSurvey.IsValid Then
                    Call oSelectedItems.Add(oPlaceholder.LinkedSurvey)
                End If
            End If
        Next
        Call oItems.Select(oSelectedItems)
        Call grdLS.RefreshDataSource()
    End Sub

    Private Sub btnCancel_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCancel.ItemClick
        Dim oPlaceholder As UIHelpers.cLinkedSurveyRelinkerPlaceholder = grdViewLS.GetFocusedObject
        If oPlaceholder IsNot Nothing Then
            Dim oLinkedsurvey As cLinkedSurvey = oPlaceholder.LinkedSurvey
            Call oActions.Remove(oLinkedsurvey)
            Call grdViewLS.RefreshRow(grdViewLS.FindRow(oPlaceholder))
        End If
    End Sub

    Private Sub btnChangeCommonPath_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnChangeCommonPath.ItemClick
        Dim oItems As UIHelpers.cLinkedSurveyRelinker = grdLS.DataSource
        Dim sCommonPath As String = btnChangeCommonPath.Tag
        Using oFB As FolderBrowserDialog = New FolderBrowserDialog()
            oFB.SelectedPath = sCurrentPath
            oFB.Description = modMain.GetLocalizedString("linkedsurveys.relinktitle")
            If oFB.ShowDialog(Me) = DialogResult.OK Then
                For Each oLinkedSurvey As cLinkedSurvey In oItems.GetSelected
                    Dim sFullFilename As String = IO.Path.Combine(oLinkedSurvey.GetFolder, oLinkedSurvey.GetFilename)
                    Dim sFolder As String = IO.Path.GetDirectoryName(modWindow.RelativeToAbsolutePath(sFullFilename, sCurrentPath))
                    Dim sOldPath As String = sFolder.Replace(sCommonPath, "")
                    Dim sNewPath As String = IO.Path.Combine(oFB.SelectedPath, sOldPath)
                    If oActions.ContainsKey(oLinkedSurvey) Then
                        Call oActions.Remove(oLinkedSurvey)
                    End If
                    Call oActions.Add(oLinkedSurvey, New cAction(sNewPath, oLinkedSurvey.GetFilename))
                Next
                Call grdLS.RefreshDataSource()
            End If
        End Using
    End Sub

    Private Sub grdViewLS_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles grdViewLS.PopupMenuShowing
        If e.HitInfo.InRowCell OrElse e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.EmptyRow Then
            e.Allow = False
            Call mnuRelink.ShowPopup(grdLS.PointToScreen(e.Point))
        End If
    End Sub

    Private Sub grdViewLS_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles grdViewLS.CustomUnboundColumnData
        Dim oPlaceholder As UIHelpers.cLinkedSurveyRelinkerPlaceholder = DirectCast(e.Row, UIHelpers.cLinkedSurveyRelinkerPlaceholder)
        If oPlaceholder IsNot Nothing Then
            If e.IsGetData Then
                Select Case e.Column.FieldName
                    Case "_selected"
                        e.Value = oPlaceholder.Selected
                    Case "_icon"
                        Dim oItem As cLinkedSurvey = oPlaceholder.LinkedSurvey
                        Dim sFullFilename As String = IO.Path.Combine(oItem.GetFolder, oItem.GetFilename)
                        sFullFilename = modWindow.RelativeToAbsolutePath(sFullFilename, sCurrentPath)
                        If My.Computer.FileSystem.FileExists(sFullFilename) Then
                            e.Value = My.Resources.linkedfile
                        Else
                            e.Value = My.Resources.unlinkedfile
                        End If
                    Case "_filename"
                        Dim oItem As cLinkedSurvey = oPlaceholder.LinkedSurvey
                        Dim sFullFilename As String = IO.Path.Combine(oItem.GetFolder, oItem.GetFilename)
                        e.Value = modWindow.RelativeToAbsolutePath(sFullFilename, sCurrentPath)
                    Case "_newicon"
                        Dim oItem As cLinkedSurvey = oPlaceholder.LinkedSurvey
                        If oActions.ContainsKey(oItem) Then
                            Dim sFullFilename As String = oActions(oItem).Fullname
                            If My.Computer.FileSystem.FileExists(sFullFilename) Then
                                e.Value = My.Resources.linkedfile
                            Else
                                e.Value = My.Resources.unlinkedfile
                            End If
                        Else
                            e.Value = Nothing
                        End If
                    Case "_newfilename"
                        Dim oItem As cLinkedSurvey = oPlaceholder.LinkedSurvey
                        Dim sFilename As String = oItem.GetFilename
                        Dim sFullFilename As String = ""
                        If oActions.ContainsKey(oItem) Then
                            e.Value = oActions(oItem).Fullname
                        Else
                            e.Value = ""
                        End If
                End Select
            Else
                Select Case e.Column.FieldName
                    Case "_selected"
                        oPlaceholder.Selected = e.Value
                End Select
            End If
        End If
    End Sub

End Class