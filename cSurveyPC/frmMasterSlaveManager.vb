Imports cSurveyPC.cSurvey

Public Class frmMasterSlaveManager

    Private oSurvey As cSurvey.cSurvey

    Public Sub New(Survey As cSurvey.cSurvey)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        Call prefresh
    End Sub

    Private Sub pRefresh()
        pnlSetAsMaster.Enabled = Not oSurvey.MasterSlave.IsMaster AndAlso Not oSurvey.MasterSlave.IsSlave
        pnlSetAsSlave.Enabled = oSurvey.MasterSlave.IsMaster AndAlso Not oSurvey.MasterSlave.IsSlave
        pnlJoin.Enabled = oSurvey.MasterSlave.IsMaster
        Call pCavesLoad()
    End Sub

    Private Sub pCavesLoad()
        bGlobalDisableCheckEvent = True
        Call tvCaveInfos.Nodes.Clear()
        For Each oCaveInfo As cCaveInfo In oSurvey.Properties.CaveInfos
            Dim oCaveNode As TreeNode = tvCaveInfos.Nodes.Add(oCaveInfo.Name)
            oCaveNode.Name = oCaveInfo.Name
            oCaveNode.SelectedImageKey = "cave"
            oCaveNode.ImageKey = "cave"
            oCaveNode.Checked = oCaveInfo.Locked
            oCaveNode.Tag = {oCaveNode.Name, "", oSurvey.MasterSlave.Users.GetCaveAndBranchLockInfo(oCaveNode.Name, "")}
            Call pCaveBranchesLoad(oCaveInfo.Branches, oCaveNode.Nodes)
            Call oCaveNode.ExpandAll()
        Next

        If tvCaveInfos.Nodes.Count > 0 Then
            tvCaveInfos.SelectedNode = tvCaveInfos.Nodes(0)
        End If
        bGlobalDisableCheckEvent = False
    End Sub

    Private Sub pCaveBranchesLoad(ParentBranches As cCaveInfoBranches, ParentNodes As TreeNodeCollection)
        For Each oBranch As cCaveInfoBranch In ParentBranches
            Dim oBranchNode As TreeNode = ParentNodes.Add(oBranch.Name)
            oBranchNode.Name = oBranch.Name
            oBranchNode.SelectedImageKey = "branch"
            oBranchNode.ImageKey = "branch"
            oBranchNode.Checked = oBranch.Locked
            oBranchNode.Tag = {oBranch.Cave, oBranch.Path, oSurvey.MasterSlave.Users.GetCaveAndBranchLockInfo(oBranch.Cave, oBranch.Path)}
            Call pCaveBranchesLoad(oBranch.Branches, oBranchNode.Nodes)
        Next
    End Sub

    Private Sub cmdSetAsMaster_Click(sender As Object, e As EventArgs) Handles cmdSetAsMaster.Click
        Call oSurvey.MasterSlave.SetAsMaster()
        Dim oMasterUser As Master.cUser = oSurvey.MasterSlave.Users.Append("ADMIN", "Amministratore", "prova", 0)
        Call pRefresh()
    End Sub

    Private bDisableCheckEvent As Boolean
    Private bGlobalDisableCheckEvent As Boolean

    Private Sub tvCaveInfos_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles tvCaveInfos.AfterCheck
        If Not bGlobalDisableCheckEvent Then
            For Each oChildNode As TreeNode In e.Node.Nodes
                bDisableCheckEvent = True
                oChildNode.Checked = e.Node.Checked
                bDisableCheckEvent = False
            Next
        End If
    End Sub

    Private Sub tvCaveInfos_BeforeCheck(sender As Object, e As TreeViewCancelEventArgs) Handles tvCaveInfos.BeforeCheck
        If Not bGlobalDisableCheckEvent Then
            If Not bDisableCheckEvent Then
                bDisableCheckEvent = True
                Dim bCancel As Boolean
                If Not IsNothing(e.Node.Tag) Then
                    Dim oLockinfo As Master.cCaveAndBrancheLockInfo = e.Node.Tag(2)
                    bCancel = Not IsNothing(oLockinfo)
                End If
                If bCancel Then
                    e.Cancel = True
                Else
                    Dim oParentNode As TreeNode = e.Node.Parent
                    If IsNothing(oParentNode) Then
                        e.Cancel = False
                    Else
                        e.Cancel = oParentNode.Checked
                    End If
                End If
                bDisableCheckEvent = False
            End If
        End If
    End Sub

    Private Sub cmdSetAsSlave_Click(sender As Object, e As EventArgs) Handles cmdSetAsSlave.Click
        Using oSMS As SaveFileDialog = New SaveFileDialog
            oSMS.Title = "Save MASTER survey:"
            oSMS.Filter = "cSurvey File (*.CSZ)|*.CSZ"
            If oSMS.ShowDialog = DialogResult.OK Then
                Call pApplyCaveInfo(oSurvey)

                Dim dDate As Date = Now
                Dim oSlaveUser As Master.cUser = oSurvey.MasterSlave.Users.Append("USER1", "Utente 1", "utente", 1)
                For Each oCaveInfo As cCaveInfo In oSurvey.Properties.CaveInfos
                    If oCaveInfo.Locked Then
                        Call oSlaveUser.CavesAndBranches.Append(oCaveInfo.Name, "", dDate, "ADMIN")
                        Call pAppendBranches(oCaveInfo.Branches, oCaveInfo.Locked, dDate, "ADMIN", oSlaveUser.CavesAndBranches)
                    End If
                Next
                Call oSurvey.SaveTo(oSMS.FileName)

                Using oSFD As SaveFileDialog = New SaveFileDialog
                    oSFD.Title = "Save SLAVE survey:"
                    oSFD.Filter = "cSurvey File (*.CSZ)|*.CSZ"
                    If oSFD.ShowDialog = DialogResult.OK Then
                        Dim oSlaveSurvey As cSurvey.cSurvey = New cSurvey.cSurvey
                        Call oSlaveSurvey.Load(oSFD.FileName)
                        Call oSlaveSurvey.MasterSlave.SetAsSlave("USER1")
                        Call oSlaveSurvey.SaveTo(oSFD.FileName)
                    End If
                End Using
            End If
        End Using
    End Sub

    Private Sub pAppendBranches(Branches As cCaveInfoBranches, ParentLocked As Boolean, [Date] As Date, AssignedBy As String, CavesAndBranches As Master.cCaveAndBrancheLockInfos)
        For Each oBranch As cCaveInfoBranch In Branches
            If oBranch.Locked OrElse ParentLocked Then
                Call CavesAndBranches.Append(oBranch.Cave, oBranch.Path, [Date], AssignedBy)
                Call pAppendBranches(oBranch.Branches, oBranch.Locked Or ParentLocked, [Date], AssignedBy, CavesAndBranches)
            End If
        Next
    End Sub

    Private Sub pApplyCaveInfo(Survey As cSurvey.cSurvey)
        Call pApplyCaveInfo(Survey.Properties, tvCaveInfos.Nodes)
    End Sub

    Private Sub pApplyCaveInfo(Properties As cProperties, Nodes As TreeNodeCollection)
        For Each oNode As TreeNode In Nodes
            Dim sPathParts As Object() = oNode.Tag
            Dim sCave As String = sPathParts(0)
            Dim sBranch As String = sPathParts(1)
            Call Debug.Print(sCave & " " & sBranch & "->" & oNode.Checked)
            Properties.GetCaveInfo(sCave, sBranch).Locked = oNode.Checked
            Call pApplyCaveInfo(Properties, oNode.Nodes)
        Next
    End Sub

    Private Sub cmdJoin_Click(sender As Object, e As EventArgs) Handles cmdJoin.Click
        'get the slave file to join to...
        'load it and check masterid (have to be the same of the current master file)
        'perform join....
    End Sub

    Private Sub tvCaveInfos_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvCaveInfos.AfterSelect
        Dim oLockinfo As Master.cCaveAndBrancheLockInfo = e.Node.Tag(2)
        PropertyGrid1.SelectedObject = oLockinfo
    End Sub
End Class