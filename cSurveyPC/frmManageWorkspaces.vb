Imports System.Linq
Imports System.ComponentModel
Imports BrightIdeasSoftware
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports System.IO
Imports System.Xml
Imports System.Collections.ObjectModel
Imports DevExpress.XtraGrid.Views.Base

Friend Class frmManageWorkspaces
    'Public Class cManageWorkspacesStateEventArgs
    '    Inherits EventArgs

    '    'Private sName As String
    '    Private oXml As XmlDocument

    '    'Public ReadOnly Property Name As String
    '    '    Get
    '    '        Return sName
    '    '    End Get
    '    'End Property

    '    Public ReadOnly Property Document As XmlDocument
    '        Get
    '            Return oXml
    '        End Get
    '    End Property

    '    Friend Sub New() '(Name As String)
    '        'sName = Name
    '        oXml = New XmlDocument
    '        Dim oxmlRoot As XmlElement = oXml.CreateElement("workspace")
    '        'oxmlRoot.SetAttribute("n", sName)
    '        Call oXml.AppendChild(oxmlRoot)
    '    End Sub

    '    Friend Sub New(Xml As XmlDocument)
    '        oXml = Xml
    '        'sName = oXml.DocumentElement.GetAttribute("n")
    '    End Sub
    'End Class

    'Friend Event OnGetWorkspaceState(Sender As Object, e As cManageWorkspacesStateEventArgs)
    'Friend Event OnSetWorkspaceState(Sender As Object, e As cManageWorkspacesStateEventArgs)

    'Friend Event OnRestoreDefaultWorkspace(sender As Object, e As EventArgs)

    'Private Class cWorkspacesCollection
    '    Inherits KeyedCollection(Of String, cWorkspace)

    '    Protected Overrides Function GetKeyForItem(ByVal item As cWorkspace) As String
    '        Return item.Name
    '    End Function
    'End Class
    'Private oWorkspaces As cWorkspacesCollection

    'Private Class cWorkspace
    '    Public Name As String
    '    Public Document As XmlDocument
    '    Public ShowInToolbar As Boolean

    '    Public Sub Rename(NewName As String)
    '        Me.Name = NewName
    '    End Sub

    '    Public Sub New(Name As String, Document As XmlDocument)
    '        Me.Name = Name
    '        Me.Document = Document
    '    End Sub
    'End Class

    Private oWorkspaceManager As DevExpress.Utils.WorkspaceManager

    Public Sub New(WorkspaceManager As DevExpress.Utils.WorkspaceManager)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        oWorkspaceManager = WorkspaceManager
        grdWorkspaces.DataSource = WorkspaceManager.Workspaces
        'oWorkspaces = New cWorkspacesCollection
        'Call pSetupWorkspaces()
        'Call pLoadWorkspaces()
    End Sub

    'Private Sub pLoadWorkspaces()
    '    Call oWorkspaces.Clear()

    '    Dim oShowInToolbar As List(Of String) = New List(Of String)
    '    Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
    '        Call oShowInToolbar.AddRange(oReg.GetValue("workspaces.showintoolbar", "").ToString.Split({";"}, StringSplitOptions.RemoveEmptyEntries))
    '    End Using

    '    Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey\Workspaces", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
    '        'load workspaces from registry
    '        For Each sWorkspace As String In oReg.GetValueNames
    '            If sWorkspace <> "." Then
    '                Dim oXml As XmlDocument = New XmlDocument
    '                Call oXml.LoadXml(oReg.GetValue(sWorkspace))
    '                Dim oWorkspace As cWorkspace = New cWorkspace(sWorkspace, oXml)
    '                oWorkspace.ShowInToolbar = oShowInToolbar.Contains(sWorkspace)
    '                Call oWorkspaces.Add(oWorkspace)
    '            End If
    '        Next
    '    End Using

    '    Call tvWorkspaces.BeginUpdate()
    '    tvWorkspaces.VirtualMode = False
    '    Call tvWorkspaces.SetObjects(oWorkspaces)
    '    Call tvWorkspaces.EndUpdate()
    'End Sub

    'Friend Shared Function LoadWorkspace(Name As String) As XmlDocument
    '    Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey\Workspaces", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
    '        Dim oXml As XmlDocument = New XmlDocument
    '        Call oXml.LoadXml(oReg.GetValue(Name))
    '        Return oXml
    '    End Using
    'End Function

    'Private Function pLoadWorkspace(Name As String) As XmlDocument
    '    Return LoadWorkspace(Name)
    'End Function

    'Private Sub pSetupWorkspaces()
    '    tvWorkspaces.IsSimpleDragSource = True
    '    tvWorkspaces.IsSimpleDropSink = True
    '    Dim oDropSink As SimpleDropSink = New SimpleDropSink
    '    oDropSink.EnableFeedback = False
    '    tvWorkspaces.DropSink = oDropSink
    '    tvWorkspaces.AllowDrop = True


    '    colWorkspacesName.AspectGetter = Function(Value As Object)
    '                                         Return DirectCast(Value, cWorkspace).Name
    '                                     End Function

    '    colWorkspacesShowOnToolbar.ImageGetter = Function(Value As Object)
    '                                                 Return If(DirectCast(Value, cWorkspace).ShowInToolbar, My.Resources.asterisk_yellow, Nothing)
    '                                             End Function

    '    tvWorkspaces.DragSource = New SimpleDragSource()

    '    Call tvWorkspaces.RebuildColumns()
    'End Sub

    'Private Sub tvWorkspaces_CanDrop(sender As Object, e As OlvDropEventArgs) Handles tvWorkspaces.CanDrop
    '    Try
    '        If e.DataObject.ContainsFileDropList Then
    '            Dim sFiles As System.Collections.Specialized.StringCollection = e.DataObject.GetFileDropList()
    '            For Each sFile As String In sFiles
    '                Dim sExtension As String = IO.Path.GetExtension(sFile).ToLower
    '                If sExtension = ".cworkspace" Then
    '                    e.Effect = DragDropEffects.Copy
    '                    e.Handled = True
    '                    Return
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception
    '    End Try
    '    e.Effect = DragDropEffects.None
    'End Sub

    'Private Sub tvWorkspaces_Dropped(sender As Object, e As OlvDropEventArgs) Handles tvWorkspaces.Dropped
    '    If e.DataObject.ContainsFileDropList Then
    '        Dim sFiles As System.Collections.Specialized.StringCollection = e.DataObject.GetFileDropList()
    '        For Each sFile As String In sFiles
    '            Dim sExtension As String = IO.Path.GetExtension(sFile).ToLower
    '            If sExtension = ".cworkspace" Then
    '                Call pImportWorkspace(sFile)
    '            End If
    '        Next
    '        Call tvWorkspaces.BuildList(True)
    '    End If
    'End Sub

    Public Shared Function GetNewWorkspaceName(WorkspaceManager As DevExpress.Utils.WorkspaceManager) As String
        Dim sNewWorkspaceBaseName As String = modMain.GetLocalizedString("manageworkspace.newworkspacename")
        Dim sNewWorkspaceName As String
        Dim iIndex As Integer = 0
        Do
            iIndex += 1
            sNewWorkspaceName = sNewWorkspaceBaseName & iIndex
        Loop While pExist(WorkspaceManager, sNewWorkspaceName)
        Return sNewWorkspaceName
    End Function

    Private Shared Function pExist(WorkspaceManager As DevExpress.Utils.WorkspaceManager, WorkspaceName As String) As Boolean
        Return WorkspaceManager.Workspaces.FirstOrDefault(Function(oItem) oItem.Name.ToLower = WorkspaceName.ToLower) IsNot Nothing
    End Function

    'Private Sub pDeleteWorkspace(Name As String)
    '    Call oWorkspaces.Remove(Name)
    '    Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey\Workspaces", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
    '        Call oReg.DeleteValue(Name, False)
    '        Call oReg.Close()
    '    End Using
    'End Sub

    'Private sCurrentWorkspace As String

    'Private Sub pSaveWorkspace(Optional Name As String = "", Optional Document As XmlDocument = Nothing)
    '    Dim oXml As XmlDocument
    '    If Document Is Nothing Then
    '        Dim oArgs As cManageWorkspacesStateEventArgs = New cManageWorkspacesStateEventArgs()
    '        RaiseEvent OnGetWorkspaceState(Me, oArgs)
    '        oXml = oArgs.Document
    '    Else
    '        oXml = Document
    '    End If
    '    Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey\Workspaces", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
    '        Call oReg.SetValue(Name, oXml.OuterXml, Microsoft.Win32.RegistryValueKind.String)
    '        If Not oWorkspaces.Contains(Name) Then
    '            Call oWorkspaces.Add(New cWorkspace(Name, oXml))
    '        End If
    '        Call oReg.Close()
    '    End Using
    'End Sub

    'Private Sub cmdRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdRefresh.ItemClick
    '    Call pRefresh()
    'End Sub

    'Private Sub pRefresh()
    '    Cursor = Cursors.WaitCursor
    '    Call pLoadWorkspaces()
    '    Cursor = Cursors.Default
    'End Sub

    'Private Sub pImportWorkspace(Filename As String)
    '    Dim oXml As XmlDocument = New XmlDocument
    '    Call oXml.Load(Filename)
    '    Dim sName As String = IO.Path.GetFileNameWithoutExtension(Filename)
    '    Call pSaveWorkspace(sName, oXml)
    'End Sub

    'Private Sub cmdImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdImport.ItemClick
    '    Using oofd As OpenFileDialog = New OpenFileDialog
    '        With oofd
    '            .Filter = GetLocalizedString("main.filetypeCWORKSPACE") & " (*.CWORKSPACE)|*.CWORKSPACE"
    '            .FilterIndex = 1
    '            .DefaultExt = "CWORKSPACE"
    '            If .ShowDialog(Me) = DialogResult.OK Then
    '                Call pImportWorkspace(.FileName)
    '            End If
    '        End With
    '    End Using
    'End Sub

    Private Sub cmdExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdExport.ItemClick
        Dim oWorkspace As DevExpress.Utils.IWorkspace = grdWorkspacesView.GetFocusedObject
        If oWorkspace IsNot Nothing Then
            Using osfd As SaveFileDialog = New SaveFileDialog
                Dim sName As String = oWorkspace.Name
                With osfd
                    .Filter = GetLocalizedString("main.filetypeCWORKSPACE") & " (*.CWORKSPACE)|*.CWORKSPACE"
                    .FilterIndex = 1
                    .FileName = sName
                    .DefaultExt = "CWORKSPACE"
                    If .ShowDialog(Me) = DialogResult.OK Then
                        Call oWorkspaceManager.SaveWorkspace(sName, .FileName, True)
                    End If
                End With
            End Using
        End If
    End Sub

    'Private Sub tvWorkspaces_SelectionChanged(sender As Object, e As EventArgs) Handles tvWorkspaces.SelectionChanged
    '    Dim bEnabled As Boolean = Not tvWorkspaces.SelectedObject Is Nothing
    '    cmdApply.Enabled = bEnabled
    '    cmdExport.Enabled = bEnabled
    '    cmdDelete.Enabled = bEnabled
    'End Sub

    Private Sub cmdDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdDelete.ItemClick
        Dim oWorkspace As DevExpress.Utils.IWorkspace = grdWorkspacesView.GetFocusedObject
        If oWorkspace IsNot Nothing Then
            If cSurvey.UIHelpers.Dialogs.Msgbox(modMain.GetLocalizedString("manageworkspace.warning4"), MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical, modMain.GetLocalizedString("manageworkspace.warningtitle")) = MsgBoxResult.Ok Then
                Dim sName As String = oWorkspace.Name
                Call oWorkspaceManager.RemoveWorkspace(sName)
                Call My.Computer.FileSystem.DeleteFile(oWorkspace.Path)
                Call grdWorkspaces.RefreshDataSource()
            End If
        End If
    End Sub

    'Private Sub tvWorkspaces_CellEditFinished(sender As Object, e As CellEditEventArgs) Handles tvWorkspaces.CellEditFinished
    '    Dim sName As String = e.NewValue
    '    sName = sName.Trim
    '    Dim sOldName As String = e.Value
    '    Dim oWorkspace As cWorkspace = oWorkspaces(sOldName)
    '    Call oWorkspace.Rename(sName)
    '    Dim iIndex As Integer = oWorkspaces.IndexOf(oWorkspace)
    '    Call oWorkspaces.RemoveAt(iIndex)
    '    Call oWorkspaces.Insert(iIndex, oWorkspace)
    '    Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey\Workspaces", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
    '        Dim sValue As String = oReg.GetValue(sOldName)
    '        Call oReg.DeleteValue(sOldName)
    '        Call oReg.SetValue(sName, sValue)
    '        Call oReg.Close()
    '    End Using
    '    Call tvWorkspaces.RefreshObject(oWorkspace)
    'End Sub

    'Private Sub tvWorkspaces_CellEditValidating(sender As Object, e As CellEditEventArgs) Handles tvWorkspaces.CellEditValidating
    '    Dim sNewValue As String = e.NewValue.ToString.Trim
    '    e.Cancel = sNewValue = "." OrElse (oWorkspaces.Contains(sNewValue) AndAlso (Not oWorkspaces(sNewValue) Is e.RowObject))
    'End Sub

    'Private Sub tvWorkspaces_DoubleClick(sender As Object, e As EventArgs) Handles tvWorkspaces.DoubleClick
    '    If Not tvWorkspaces.FocusedObject Is Nothing Then
    '        Call cmdApply.PerformClick()
    '    End If
    'End Sub

    Private Sub cmdRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdRestore.ItemClick
        Dim oWorkspace As DevExpress.Utils.IWorkspace = grdWorkspacesView.GetFocusedObject
        If oWorkspace IsNot Nothing Then
            oWorkspaceManager.ApplyWorkspace(oWorkspace.Name)
        End If
    End Sub

    'Private Sub tvWorkspaces_CellClick(sender As Object, e As CellClickEventArgs) Handles tvWorkspaces.CellClick
    '    If e.Column Is colWorkspacesShowOnToolbar Then
    '        Dim oWorkspace As cWorkspace = DirectCast(e.Model, cWorkspace)
    '        oWorkspace.ShowInToolbar = Not oWorkspace.ShowInToolbar
    '        Call tvWorkspaces.RefreshObject(oWorkspace)
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub frmManageWorkspaces_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '    Dim sShowInToolbar As String = String.Join(";", oWorkspaces.Where(Function(oitem) oitem.ShowInToolbar).Select(Function(oitem) oitem.Name))
    '    Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
    '        Call oReg.SetValue("workspaces.showintoolbar", sShowInToolbar)
    '    End Using
    'End Sub

    Public Shared Function CaptureWorkspace(Owner As IWin32Window, WorkspaceManager As DevExpress.Utils.WorkspaceManager) As DevExpress.Utils.IWorkspace
        Dim sName As String = GetNewWorkspaceName(WorkspaceManager)
        sName = sName.Trim
        If sName <> "" Then
            Dim bOk As Boolean
            sName = DevExpress.XtraEditors.XtraInputBox.Show(Owner, modMain.GetLocalizedString("manageworkspace.warning5"), modMain.GetLocalizedString("manageworkspace.warningtitle"), sName)
            If pExist(WorkspaceManager, sName) Then
                bOk = MsgBox(modMain.GetLocalizedString("manageworkspace.warning3"), MsgBoxStyle.OkCancel, modMain.GetLocalizedString("manageworkspace.warningtitle")) = MsgBoxResult.Ok
            Else
                bOk = True
            End If
            If bOk Then
                Dim sFilename As String = IO.Path.Combine(modMain.GetUserApplicationPath, sName & ".cworkspace")
                If pExist(WorkspaceManager, sName) Then
                    Call WorkspaceManager.RemoveWorkspace(sName)
                    If My.Computer.FileSystem.FileExists(sFilename) Then
                        Call My.Computer.FileSystem.DeleteFile(sFilename)
                    End If
                End If
                WorkspaceManager.CaptureWorkspace(sName)
                Dim oWorkspace As DevExpress.Utils.IWorkspace = WorkspaceManager.GetWorkspace(sName)
                WorkspaceManager.SaveWorkspace(sName, sFilename, True)
                Return oWorkspace
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

    Private Sub cmdSaveAs_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdSaveAs.ItemClick
        Dim oWorkspace As DevExpress.Utils.IWorkspace = CaptureWorkspace(Me, oWorkspaceManager)
        If oWorkspace IsNot Nothing Then
            Call grdWorkspaces.RefreshDataSource()
        End If
        'Dim sName As String = GetNewWorkspaceName(oWorkspaceManager)
        'sName = sName.Trim
        'If sName <> "" Then
        '    Dim bOk As Boolean
        '    sName = DevExpress.XtraEditors.XtraInputBox.Show(Me, modMain.GetLocalizedString("manageworkspace.warning5"), modMain.GetLocalizedString("manageworkspace.warningtitle"), sName)
        '    If pExist(oWorkspaceManager, sName) Then
        '        bOk = MsgBox(modMain.GetLocalizedString("manageworkspace.warning3"), MsgBoxStyle.OkCancel, modMain.GetLocalizedString("manageworkspace.warningtitle")) = MsgBoxResult.Ok
        '    Else
        '        bOk = True
        '    End If
        '    If bOk Then
        '        Dim sFilename As String = IO.Path.Combine(modMain.GetUserApplicationPath, sName & ".cworkspace")
        '        If pExist(oWorkspaceManager, sName) Then
        '            Call oWorkspaceManager.RemoveWorkspace(sName)
        '            If My.Computer.FileSystem.FileExists(sFilename) Then
        '                Call My.Computer.FileSystem.DeleteFile(sFilename)
        '            End If
        '        End If
        '        oWorkspaceManager.CaptureWorkspace(sName)
        '        Dim oWorkspace As DevExpress.Utils.IWorkspace = oWorkspaceManager.GetWorkspace(sName)
        '        oWorkspaceManager.SaveWorkspace(sName, sFilename, True)
        '        Call grdWorkspaces.RefreshDataSource()
        '    End If
        'End If
    End Sub

    Private Sub cmdImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdImport.ItemClick
        Using oofd As OpenFileDialog = New OpenFileDialog
            With oofd
                .Filter = GetLocalizedString("main.filetypeCWORKSPACE") & " (*.CWORKSPACE)|*.CWORKSPACE"
                .FilterIndex = 1
                .DefaultExt = "CWORKSPACE"
                If .ShowDialog(Me) = DialogResult.OK Then
                    Dim sFromFilename As String = .FileName
                    Dim sName As String = IO.Path.GetFileNameWithoutExtension(sFromFilename)
                    Dim sFilename As String = IO.Path.Combine(modMain.GetUserApplicationPath, sName & ".cworkspace")
                    If sFromFilename.ToLower <> sFilename.ToLower Then
                        My.Computer.FileSystem.CopyFile(sFromFilename, sFilename, True)
                        Call oWorkspaceManager.LoadWorkspace(sName, IO.Path.Combine(modMain.GetUserApplicationPath, sName & ".cworkspace"), False)
                        Call grdWorkspaces.RefreshDataSource()
                    End If
                End If
            End With
        End Using
    End Sub

    Private Sub grdWorkspacesView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grdWorkspacesView.FocusedRowChanged
        Dim oWorkspace As DevExpress.Utils.IWorkspace = grdWorkspacesView.GetFocusedObject
        Dim bEnabled As Boolean = oWorkspace IsNot Nothing
        cmdRestore.Enabled = bEnabled
        cmdDelete.Enabled = bEnabled
        cmdExport.Enabled = bEnabled
    End Sub

    Private Sub grdWorkspacesView_CustomRowFilter(sender As Object, e As RowFilterEventArgs) Handles grdWorkspacesView.CustomRowFilter
        Dim sName As String = oWorkspaceManager.Workspaces(e.ListSourceRow).Name
        If sName.StartsWith("_") OrElse sName.ToLower = "default" Then
            e.Visible = False
            e.Handled = True
        End If
    End Sub
End Class