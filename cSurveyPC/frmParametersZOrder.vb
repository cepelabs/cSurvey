Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design

Public Class frmParametersZOrder
    Friend Event OnChangeOptions(ByVal Sender As Object, ByVal Options As cOptions)

    Private oOptions As cOptions
    Private oZOrderBag As cZOrderBag

    Private bDisabledEvent As Boolean

    Friend Class cZOrderBagItem
        Private sCave As String
        Private sBranch As String
        Private iZOrder As Integer

        Friend Sub New(ByVal Cave As String, ByVal Branch As String, ByVal ZOrder As Integer)
            sCave = Cave
            sBranch = Branch
            iZOrder = ZOrder
        End Sub

        Public ReadOnly Property Cave As String
            Get
                Return sCave
            End Get
        End Property

        Public ReadOnly Property Branch As String
            Get
                Return sBranch
            End Get
        End Property

        Public Property ZOrder As Integer
            Get
                Return iZOrder
            End Get
            Set(ByVal Value As Integer)
                iZOrder = value
            End Set
        End Property
    End Class

    Friend Class cZOrderBag
        Implements IEnumerable

        Private oItems As List(Of cZOrderBagItem)

        Private Class cZOrderBagItemComparer
            Implements IComparer(Of cZOrderBagItem)

            Public Function Compare(x As cZOrderBagItem, y As cZOrderBagItem) As Integer Implements System.Collections.Generic.IComparer(Of cZOrderBagItem).Compare
                If x Is Nothing And y Is Nothing Then
                    Return 0
                ElseIf x Is Nothing And Not y Is Nothing Then
                    Return -1
                ElseIf Not x Is Nothing And y Is Nothing Then
                    Return 1
                Else
                    If x.ZOrder > y.ZOrder Then
                        Return 1
                    ElseIf x.ZOrder = y.ZOrder Then
                        Return 0
                    Else
                        Return -1
                    End If
                End If
            End Function
        End Class

        Public Sub Sort()
            Call oItems.Sort(New cZOrderBagItemComparer)
        End Sub

        Public Sub Apply(ByVal Survey As cSurvey.cSurvey)
            For Each oItem As cZOrderBagItem In oItems
                Dim sCave As String = oItem.Cave
                Dim sBranch As String = oItem.Branch
                Dim iZOrder As Integer = oItem.ZOrder
                Try
                    If sBranch = "" Then
                        Dim oCaveInfo As cCaveInfo = Survey.Properties.CaveInfos(sCave)
                        oCaveInfo.DrawingZOrder = iZOrder
                    Else
                        Dim oCaveInfoBranch As cCaveInfoBranch = Survey.Properties.CaveInfos(sCave).Branches(sBranch)
                        oCaveInfoBranch.DrawingZOrder = iZOrder
                    End If
                Catch
                End Try
            Next
        End Sub

        Friend Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey)
            oItems = New List(Of cZOrderBagItem)
            For Each oCaveInfo As cCaveInfo In Survey.Properties.CaveInfos
                Call oItems.Add(New cZOrderBagItem(oCaveInfo.Name, "", oCaveInfo.DrawingZOrder))
                Call pAppendBranches(oCaveInfo.Branches)
            Next
        End Sub

        Private Sub pAppendBranches(Branches As cCaveInfoBranches)
            For Each oCaveInfoBranch As cCaveInfoBranch In Branches
                Call oItems.Add(New cZOrderBagItem(oCaveInfoBranch.Cave, oCaveInfoBranch.Path, oCaveInfoBranch.DrawingZOrder))
                Call pAppendBranches(oCaveInfoBranch.Branches)
            Next
        End Sub

        Friend Sub New()
            oItems = New List(Of cZOrderBagItem)
        End Sub

        Public ReadOnly Property Item(ByVal Index As Integer) As cZOrderBagItem
            Get
                Return oItems(Index)
            End Get
        End Property

        Public ReadOnly Property Count() As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Friend Function Append(ByVal Cave As String, ByVal Branch As String, ByVal ZOrder As Integer) As cZOrderBagItem
            Dim oItem As cZOrderBagItem = New cZOrderBagItem(Cave, Branch, ZOrder)
            Call oItems.Add(oItem)
            Return oItem
        End Function

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class

    Public Sub New(ByVal Options As cOptions)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oOptions = Options

        bDisabledEvent = True
        oZOrderBag = New cZOrderBag(oOptions.Survey)
        chkKeepCaveAndBranchGrouped.Checked = oOptions.ZOrderMode = cOptions.zordermodeenum.Hierarchic
        Call pZorderBagToGrid()
        bDisabledEvent = False
    End Sub

    Private Sub pZorderBagToGrid()
        Call oZOrderBag.Sort()
        Call tvCaveInfos.Nodes.Clear()
        If chkKeepCaveAndBranchGrouped.Checked Then
            'consente l'ordinamento mantenendo la gerarchia grotta/ramo
            For Each oItem As cZOrderBagItem In oZOrderBag
                Dim bBranch As Boolean = oItem.Branch <> ""
                If Not bBranch Then
                    Dim oCaveNode As TreeNode = tvCaveInfos.Nodes.Add(oItem.Cave)
                    oCaveNode.Tag = oItem
                    oCaveNode.SelectedImageKey = "cave"
                    oCaveNode.ImageKey = "cave"
                    Call pCaveBranchesLoad(oItem.Cave, oCaveNode.Nodes)
                End If
            Next
            Call tvCaveInfos.ExpandAll()
        Else
            'ordinamento completamente libero
            For Each oItem As cZOrderBagItem In oZOrderBag
                Dim bBranch As Boolean = oItem.Branch <> ""
                Dim oCaveNode As TreeNode = tvCaveInfos.Nodes.Add(oItem.Cave & IIf(bBranch, "\" & oItem.Branch, ""))
                oCaveNode.Tag = oItem
                If bBranch Then
                    oCaveNode.SelectedImageKey = "branch"
                    oCaveNode.ImageKey = "branch"
                Else
                    oCaveNode.SelectedImageKey = "cave"
                    oCaveNode.ImageKey = "cave"
                End If
            Next
        End If
        If tvCaveInfos.Nodes.Count > 0 Then
            tvCaveInfos.SelectedNode = tvCaveInfos.Nodes(0)
        End If
    End Sub

    Private Sub pCaveBranchesLoad(ParentCave As String, ParentNodes As TreeNodeCollection)
        For Each oItem As cZOrderBagItem In oZOrderBag
            If oItem.Cave = ParentCave And oItem.Branch <> "" Then
                Dim oBranchNode As TreeNode = ParentNodes.Add(oItem.Branch)
                oBranchNode.Tag = oItem
                oBranchNode.SelectedImageKey = "branch"
                oBranchNode.ImageKey = "branch"
            End If
        Next
    End Sub

    Private Sub pGridToZorderBag()
        Dim iIndex As Integer = 0
        For Each oNode As TreeNode In tvCaveInfos.Nodes
            Dim oItem As cZOrderBagItem = oNode.Tag
            oItem.ZOrder = iIndex * 10
            iIndex += 1
            Call pCaveBranchedUnload(oNode.Nodes, iIndex)
        Next
    End Sub

    Private Sub pCaveBranchedUnload(ParentNodes As TreeNodeCollection, ByRef Index As Integer)
        For Each oNode As TreeNode In ParentNodes
            Dim oItem As cZOrderBagItem = oNode.Tag
            oItem.ZOrder = Index * 10
            Index += 1
            Call pCaveBranchedUnload(oNode.Nodes, Index)
        Next
    End Sub

    Private Sub pSave()
        If chkKeepCaveAndBranchGrouped.Checked Then
            oOptions.ZOrderMode = cOptions.zordermodeenum.Hierarchic
        Else
            oOptions.ZOrderMode = cOptions.zordermodeenum.Free
        End If
        Call pGridToZorderBag()
        Call oZOrderBag.Apply(oOptions.Survey)
    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Call pSave()
        RaiseEvent OnChangeOptions(Me, ooptions)
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Call pSave()
        RaiseEvent OnChangeOptions(Me, ooptions)
        Call Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Call Close()
    End Sub

    Private Sub chkKeepCaveAndBranchGrouped_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkKeepCaveAndBranchGrouped.CheckedChanged
        Call pGridToZorderBag()
        Call pZorderBagToGrid()
    End Sub

    Private Sub cmdMoveUp_Click(sender As System.Object, e As System.EventArgs) Handles cmdMoveUp.Click
        Dim oNode As TreeNode = tvCaveInfos.SelectedNode
        If Not oNode Is Nothing Then
            Dim iCurrentIndex As Integer = oNode.Index
            Dim oNodes As TreeNodeCollection
            If oNode.Parent Is Nothing Then
                oNodes = tvCaveInfos.Nodes
            Else
                oNodes = oNode.Parent.Nodes
            End If
            With oNodes
                If iCurrentIndex > 0 Then
                    Call .Remove(oNode)
                    Call .Insert(iCurrentIndex - 1, oNode)
                End If
            End With
            tvCaveInfos.SelectedNode = oNode
        End If
    End Sub

    Private Sub cmdMoveDown_Click(sender As System.Object, e As System.EventArgs) Handles cmdMoveDown.Click
        Dim oNode As TreeNode = tvCaveInfos.SelectedNode
        If Not oNode Is Nothing Then
            Dim iCurrentIndex As Integer = oNode.Index
            Dim oNodes As TreeNodeCollection
            If oNode.Parent Is Nothing Then
                oNodes = tvCaveInfos.Nodes
            Else
                oNodes = oNode.Parent.Nodes
            End If
            With oNodes
                If iCurrentIndex < .Count Then
                    Call .Remove(oNode)
                    Call .Insert(iCurrentIndex + 1, oNode)
                End If
            End With
            tvCaveInfos.SelectedNode = oNode
        End If
    End Sub
End Class