Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports DevExpress.XtraTreeList.Nodes

Friend Class frmParametersZOrder
    Friend Event OnChangeOptions(ByVal Sender As Object, ByVal Options As cOptionsDesign)

    Private oOptions As cOptionsCenterline
    Private oZOrderBag As cZOrderBag

    Private bDisabledEvent As Boolean

    Friend Class cZOrderBagItem
        Implements cIUIBaseInteractions

        Private oCaveInfo As cICaveInfoBranches

        'Private iZOrder As Integer

        Friend Sub New(CaveInfo As cICaveInfoBranches)
            oCaveInfo = CaveInfo
            'iZOrder = ZOrder
        End Sub

        Public ReadOnly Property CaveInfo As cCaveInfo
            Get
                If oCaveInfo Is Nothing Then
                    Return Nothing
                Else
                    Return oCaveInfo.GetRoot
                End If
            End Get
        End Property

        Public ReadOnly Property CaveInfoBranch As cCaveInfoBranch
            Get
                If oCaveInfo Is Nothing Then
                    Return Nothing
                ElseIf TypeOf oCaveInfo Is cCaveInfo Then
                    Return Nothing
                Else
                    Return oCaveInfo
                End If
            End Get
        End Property

        Public ReadOnly Property ToHTMLString() As String
            Get
                If TypeOf oCaveInfo Is cCaveInfo Then
                    Return "<b><backcolor=" & ColorTranslator.ToHtml(oCaveInfo.GetColor(Color.Gray)) & ">  </backcolor></b>  " & oCaveInfo.Cave
                Else
                    Return "<b><backcolor=" & ColorTranslator.ToHtml(oCaveInfo.GetColor(Color.Gray)) & ">  </backcolor></b>  " & oCaveInfo.Cave & cCaveInfoBranches.sBranchSeparator & oCaveInfo.Path
                End If
            End Get
        End Property

        Public ReadOnly Property ToHTMLShortString() As String
            Get
                Return "<b><backcolor=" & ColorTranslator.ToHtml(oCaveInfo.GetColor(Color.Gray)) & ">  </backcolor></b>  " & oCaveInfo.Name
            End Get
        End Property

        Public ReadOnly Property Parent As String
            Get
                If TypeOf oCaveInfo Is cCaveInfo Then
                    Return ""
                Else
                    Return oCaveInfo.Cave & If(oCaveInfo.Parent Is Nothing, "", cCaveInfoBranches.sBranchSeparator & oCaveInfo.Parent.Path)
                End If
            End Get
        End Property

        Public ReadOnly Property Path As String
            Get
                Return If(TypeOf oCaveInfo Is cCaveInfo, oCaveInfo.Path, oCaveInfo.Cave & cCaveInfoBranches.sBranchSeparator & oCaveInfo.Path)
            End Get
        End Property

        'Public ReadOnly Property Cave As String
        '    Get
        '        Return If(oCaveInfo Is Nothing, modMain.GetLocalizedString("translations.originalposition"), oCaveInfo.Cave)
        '    End Get
        'End Property

        'Public ReadOnly Property Branch As String
        '    Get
        '        Return If(oCaveInfo Is Nothing, "", If(TypeOf oCaveInfo Is cCaveInfo, "", oCaveInfo.Path))
        '    End Get
        'End Property

        Public Property ZOrder As Integer
            Get
                If TypeOf oCaveInfo Is cCaveInfo Then
                    Return DirectCast(oCaveInfo, cCaveInfo).DrawingZOrder
                Else
                    Return DirectCast(oCaveInfo, cCaveInfoBranch).DrawingZOrder
                End If
            End Get
            Set(ByVal Value As Integer)
                If TypeOf oCaveInfo Is cCaveInfo Then
                    With DirectCast(oCaveInfo, cCaveInfo)
                        If .DrawingZOrder <> Value Then
                            .DrawingZOrder = Value
                            Call PropertyChanged("ZOrder")
                        End If
                    End With
                Else
                    With DirectCast(oCaveInfo, cCaveInfoBranch)
                        If .DrawingZOrder <> Value Then
                            .DrawingZOrder = Value
                            Call PropertyChanged("ZOrder")
                        End If
                    End With
                End If
            End Set
        End Property

        Public Event OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Implements cIUIBaseInteractions.OnPropertyChanged

        Public Sub PropertyChanged(Name As String) Implements cIUIBaseInteractions.PropertyChanged
            RaiseEvent OnPropertyChanged(Me, New PropertyChangeEventArgs(Name))
        End Sub
    End Class

    Friend Class cZOrderBag
        Inherits List(Of cZOrderBagItem)
        Implements cIUIBaseInteractions

        Public Event OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Implements cIUIBaseInteractions.OnPropertyChanged

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

        Public Overloads Sub Sort()
            Call MyBase.Sort(New cZOrderBagItemComparer)
        End Sub

        Private Sub oItem_OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs)
            Call PropertyChanged("Item." & e.Name)
        End Sub

        'Public Sub Apply(ByVal Survey As cSurvey.cSurvey)
        '    For Each oItem As cZOrderBagItem In oItems
        '        Dim sCave As String = oItem.Cave
        '        Dim sBranch As String = oItem.Branch
        '        Dim iZOrder As Integer = oItem.ZOrder
        '        Try
        '            If sBranch = "" Then
        '                Dim oCaveInfo As cCaveInfo = Survey.Properties.CaveInfos(sCave)
        '                oCaveInfo.DrawingZOrder = iZOrder
        '            Else
        '                Dim oCaveInfoBranch As cCaveInfoBranch = Survey.Properties.CaveInfos(sCave).Branches(sBranch)
        '                oCaveInfoBranch.DrawingZOrder = iZOrder
        '            End If
        '        Catch
        '        End Try
        '    Next
        'End Sub

        Friend Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey)
            For Each oCaveInfo As cCaveInfo In Survey.Properties.CaveInfos
                Call MyBase.Add(New cZOrderBagItem(oCaveInfo))
                Call pAppendBranches(oCaveInfo.Branches)
            Next
        End Sub

        Private Sub pAppendBranches(Branches As cCaveInfoBranches)
            For Each oCaveInfoBranch As cCaveInfoBranch In Branches
                Call MyBase.Add(New cZOrderBagItem(oCaveInfoBranch))
                Call pAppendBranches(oCaveInfoBranch.Branches)
            Next
        End Sub

        'Public ReadOnly Property Item(ByVal Index As Integer) As cZOrderBagItem
        '    Get
        '        Return oItems(Index)
        '    End Get
        'End Property

        'Public ReadOnly Property Count() As Integer
        '    Get
        '        Return oItems.Count
        '    End Get
        'End Property

        'Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        '    Return oItems.GetEnumerator
        'End Function

        Public Sub PropertyChanged(Name As String) Implements cIUIBaseInteractions.PropertyChanged
            RaiseEvent OnPropertyChanged(Me, New PropertyChangeEventArgs(Name))
        End Sub
    End Class

    Public Sub New(ByVal Options As cOptionsCenterline)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oOptions = Options

        bDisabledEvent = True

        oZOrderBag = New cZOrderBag(oOptions.Survey)
        chkKeepCaveAndBranchGrouped.Checked = oOptions.ZOrderMode = cOptionsDesign.zordermodeenum.Hierarchic
        TreeList1.DataSource = oZOrderBag
        Call pRefresh()
        'Call pZorderBagToGrid()

        bDisabledEvent = False
    End Sub

    Private Sub pRefresh()
        TreeList1.BeginUpdate()
        If chkKeepCaveAndBranchGrouped.Checked Then
            TreeList1.ParentFieldName = "Parent"
            colCaveBranch.FieldName = "ToHTMLShortString"
        Else
            TreeList1.ParentFieldName = ""
            colCaveBranch.FieldName = "ToHTMLString"
        End If
        TreeList1.RefreshDataSource()
        TreeList1.ExpandAll()
        TreeList1.Sort(Nothing, colZOrder, SortOrder.Ascending, True)
        TreeList1.EndUpdate()
    End Sub

    'Private Sub pZorderBagToGrid()
    '    Call oZOrderBag.Sort()
    '    Call tvCaveInfos.Nodes.Clear()
    '    If chkKeepCaveAndBranchGrouped.Checked Then
    '        'consente l'ordinamento mantenendo la gerarchia grotta/ramo
    '        For Each oItem As cZOrderBagItem In oZOrderBag
    '            Dim bBranch As Boolean = oItem.Branch <> ""
    '            If Not bBranch Then
    '                Dim oCaveNode As TreeNode = tvCaveInfos.Nodes.Add(oItem.Cave)
    '                oCaveNode.Tag = oItem
    '                oCaveNode.SelectedImageKey = "cave"
    '                oCaveNode.ImageKey = "cave"
    '                Call pCaveBranchesLoad(oItem.Cave, oCaveNode.Nodes)
    '            End If
    '        Next
    '        Call tvCaveInfos.ExpandAll()
    '    Else
    '        'ordinamento completamente libero
    '        For Each oItem As cZOrderBagItem In oZOrderBag
    '            Dim bBranch As Boolean = oItem.Branch <> ""
    '            Dim oCaveNode As TreeNode = tvCaveInfos.Nodes.Add(oItem.Cave & IIf(bBranch, "\" & oItem.Branch, ""))
    '            oCaveNode.Tag = oItem
    '            If bBranch Then
    '                oCaveNode.SelectedImageKey = "branch"
    '                oCaveNode.ImageKey = "branch"
    '            Else
    '                oCaveNode.SelectedImageKey = "cave"
    '                oCaveNode.ImageKey = "cave"
    '            End If
    '        Next
    '    End If
    '    If tvCaveInfos.Nodes.Count > 0 Then
    '        tvCaveInfos.SelectedNode = tvCaveInfos.Nodes(0)
    '    End If
    'End Sub

    'Private Sub pCaveBranchesLoad(ParentCave As String, ParentNodes As TreeNodeCollection)
    '    For Each oItem As cZOrderBagItem In oZOrderBag
    '        If oItem.Cave = ParentCave And oItem.Branch <> "" Then
    '            Dim oBranchNode As TreeNode = ParentNodes.Add(oItem.Branch)
    '            oBranchNode.Tag = oItem
    '            oBranchNode.SelectedImageKey = "branch"
    '            oBranchNode.ImageKey = "branch"
    '        End If
    '    Next
    'End Sub

    'Private Sub pGridToZorderBag()
    '    Dim iIndex As Integer = 0
    '    For Each oNode As TreeNode In tvCaveInfos.Nodes
    '        Dim oItem As cZOrderBagItem = oNode.Tag
    '        oItem.ZOrder = iIndex * 10
    '        iIndex += 1
    '        Call pCaveBranchedUnload(oNode.Nodes, iIndex)
    '    Next
    'End Sub

    'Private Sub pCaveBranchedUnload(ParentNodes As TreeNodeCollection, ByRef Index As Integer)
    '    For Each oNode As TreeNode In ParentNodes
    '        Dim oItem As cZOrderBagItem = oNode.Tag
    '        oItem.ZOrder = Index * 10
    '        Index += 1
    '        Call pCaveBranchedUnload(oNode.Nodes, Index)
    '    Next
    'End Sub

    'Private Sub pSave()
    '    If chkKeepCaveAndBranchGrouped.Checked Then
    '        oOptions.ZOrderMode = cOptions.zordermodeenum.Hierarchic
    '    Else
    '        oOptions.ZOrderMode = cOptions.zordermodeenum.Free
    '    End If
    '    Call pGridToZorderBag()
    '    Call oZOrderBag.Apply(oOptions.Survey)
    'End Sub

    'Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
    '    Call pSave()
    '    RaiseEvent OnChangeOptions(Me, ooptions)
    'End Sub

    'Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
    '    Call pSave()
    '    RaiseEvent OnChangeOptions(Me, ooptions)
    '    Call Close()
    'End Sub

    'Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
    '    Call Close()
    'End Sub

    Private Sub chkKeepCaveAndBranchGrouped_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkKeepCaveAndBranchGrouped.CheckedChanged
        If Not oOptions Is Nothing AndAlso Not bDisabledEvent Then
            If chkKeepCaveAndBranchGrouped.Checked Then
                oOptions.ZOrderMode = cOptionsDesign.zordermodeenum.Hierarchic
            Else
                oOptions.ZOrderMode = cOptionsDesign.zordermodeenum.Free
            End If
            Call pRefresh()
        End If
        'Call pGridToZorderBag()
        'Call pZorderBagToGrid()
    End Sub

    Private Sub pReorderNode(Node As TreeListNode, ByRef ZOrder As Integer)
        For Each oNode As TreeListNode In Node.Nodes
            DirectCast(TreeList1.GetRow(oNode.Id), cZOrderBagItem).ZOrder = ZOrder
            ZOrder += 1
        Next
    End Sub

    Private Sub pReorder()
        Dim iZOrder As Integer = 1
        For Each oNode As TreeListNode In TreeList1.NodesIterator.All
            DirectCast(TreeList1.GetRow(oNode.Id), cZOrderBagItem).ZOrder = iZOrder
            iZOrder += 1
        Next
    End Sub

    Private Sub cmdMoveUp_Click(sender As System.Object, e As System.EventArgs) Handles cmdMoveUp.Click
        Call TreeList1.SetNodeIndex(TreeList1.FocusedNode, TreeList1.GetNodeIndex(TreeList1.FocusedNode) - 1)
        Call TreeList1.MakeNodeVisible(TreeList1.FocusedNode)
        Call pReorder
        'Dim oNode As TreeNode = tvCaveInfos.SelectedNode
        'If Not oNode Is Nothing Then
        '    Dim iCurrentIndex As Integer = oNode.Index
        '    Dim oNodes As TreeNodeCollection
        '    If oNode.Parent Is Nothing Then
        '        oNodes = tvCaveInfos.Nodes
        '    Else
        '        oNodes = oNode.Parent.Nodes
        '    End If
        '    With oNodes
        '        If iCurrentIndex > 0 Then
        '            Call .Remove(oNode)
        '            Call .Insert(iCurrentIndex - 1, oNode)
        '        End If
        '    End With
        '    tvCaveInfos.SelectedNode = oNode
        'End If
    End Sub

    Private Sub cmdMoveDown_Click(sender As System.Object, e As System.EventArgs) Handles cmdMoveDown.Click
        Call TreeList1.SetNodeIndex(TreeList1.FocusedNode, TreeList1.GetNodeIndex(TreeList1.FocusedNode) + 1)
        Call TreeList1.MakeNodeVisible(TreeList1.FocusedNode)
        Call pReorder
        'Dim oNode As TreeNode = tvCaveInfos.SelectedNode
        'If Not oNode Is Nothing Then
        '    Dim iCurrentIndex As Integer = oNode.Index
        '    Dim oNodes As TreeNodeCollection
        '    If oNode.Parent Is Nothing Then
        '        oNodes = tvCaveInfos.Nodes
        '    Else
        '        oNodes = oNode.Parent.Nodes
        '    End If
        '    With oNodes
        '        If iCurrentIndex < .Count Then
        '            Call .Remove(oNode)
        '            Call .Insert(iCurrentIndex + 1, oNode)
        '        End If
        '    End With
        '    tvCaveInfos.SelectedNode = oNode
        'End If
    End Sub
End Class