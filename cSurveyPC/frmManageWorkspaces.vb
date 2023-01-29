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
    End Sub

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

    Private Sub cmdRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdRestore.ItemClick
        Dim oWorkspace As DevExpress.Utils.IWorkspace = grdWorkspacesView.GetFocusedObject
        If oWorkspace IsNot Nothing Then
            oWorkspaceManager.ApplyWorkspace(oWorkspace.Name)
        End If
    End Sub

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