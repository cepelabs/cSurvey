Imports System.ComponentModel
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Helper.Editor

Friend Class frmItemsFilter
    Private oSurvey As cSurveyPC.cSurvey.cSurvey
    Private oSourceFilter As cFilter
    Private oFilter As cFilter

    Private Class cFilterCategoryItem
        Private iValue As cIItem.cItemCategoryEnum?

        Public ReadOnly Property Value As cIItem.cItemCategoryEnum
            Get
                Return iValue
            End Get
        End Property

        Public Overrides Function ToString() As String
            If iValue Is Nothing Then
                Return ""
            Else
                Return iValue.ToString
            End If
        End Function

        Public Sub New(Value As cIItem.cItemCategoryEnum?)
            iValue = Value
        End Sub
    End Class

    Friend Sub New(Survey As cSurveyPC.cSurvey.cSurvey, Filter As cFilter)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey

        oSourceFilter = Filter
        oFilter = oSourceFilter.Clone

        Call cboCategories.Properties.Items.Clear()
        Call cboCategories.Properties.Items.Add("")
        For Each iCategory As cIItem.cItemCategoryEnum In [Enum].GetValues(GetType(cIItem.cItemCategoryEnum))
            Call cboCategories.Properties.Items.Add(New cFilterCategoryItem(iCategory))
        Next

        txtName.Text = "" & oFilter.Name
        cboCategories.Text = New cFilterCategoryItem(oFilter.Category).ToString

        Call pFillCaveList()
        cboCaveList.EditValue = oSurvey.Properties.GetCaveInfo(oFilter.Cave, "")
        cboCaveBranchList.EditValue = oSurvey.Properties.GetCaveInfo(oFilter.Cave, oFilter.Branch)

        prpDataProperties.SelectedObject = oFilter.DataProperties.GetClass

        chkReversed.Checked = oFilter.Reversed
    End Sub

    Private Sub prpPropDesignDataProperties_MouseUp(sender As Object, e As MouseEventArgs) Handles prpDataProperties.MouseUp
        If (e.Button And MouseButtons.Right) = MouseButtons.Right Then
            mnuDataProperties.Tag = prpDataProperties
            Call mnuDataProperties.ShowPopup(prpDataProperties.PointToScreen(e.Location))
        End If
    End Sub
    'Private Sub cboCaveList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call pFillCaveBranchList(CType(cboCaveList.SelectedItem, cCaveInfo))
    'End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Call pSave()
    End Sub

    Private Sub pSave()
        oFilter.Name = txtName.Text
        If cboCategories.SelectedIndex = 0 Then
            oFilter.Category = Nothing
        Else
            oFilter.Category = cboCategories.SelectedItem.value
        End If
        oFilter.Cave = "" & If(cboCaveList.EditValue Is Nothing, "", cboCaveList.EditValue.name)
        oFilter.Branch = "" & If(cboCaveBranchList.EditValue Is Nothing, "", cboCaveBranchList.EditValue.path)
        oFilter.Reversed = chkReversed.Checked
        Call oSourceFilter.CopyFrom(oFilter)
    End Sub

    Private Sub pFillCaveList()
        cboCaveList.Enabled = True
        cboCaveList.Properties.DataSource = oSurvey.Properties.CaveInfos.GetWithEmpty.Select(Function(oitem) oitem.Value).ToList
        cboCaveList.EditValue = cboCaveList.Properties.DataSource(0)
    End Sub

    'Private Sub pFillCaveBranchList(ByVal Cave As cCaveInfo)
    '    Dim sCave As String = ""
    '    If Not Cave Is Nothing Then
    '        sCave = "" & Cave.Name
    '    End If
    '    Call pFillCaveBranchList(sCave)
    'End Sub

    'Private Sub pFillCaveBranchList(ByVal Cave As String)
    '    Try
    '        Dim oEmptyCaveInfoBranch As cCaveInfoBranch = oSurvey.Properties.CaveInfos.GetEmptyCaveInfoBranch(Cave)
    '        If Cave = "" Then
    '            Call cboCaveBranchList.Items.Clear()
    '            Call cboCaveBranchList.Items.Add(oEmptyCaveInfoBranch)
    '            cboCaveBranchList.Enabled = False
    '        Else
    '            Dim oCurrentBranch As cCaveInfoBranch = cboCaveBranchList.SelectedItem
    '            Call cboCaveBranchList.Items.Clear()
    '            Call cboCaveBranchList.Items.Add(oEmptyCaveInfoBranch)
    '            For Each oBranch As cCaveInfoBranch In oSurvey.Properties.CaveInfos(Cave).Branches.GetAllBranches.Values
    '                Call cboCaveBranchList.Items.Add(oBranch)
    '            Next

    '            If cboCaveBranchList.Items.Count > 0 Then
    '                Try
    '                    If oCurrentBranch Is Nothing Then
    '                        cboCaveBranchList.SelectedIndex = 0
    '                    Else
    '                        cboCaveBranchList.SelectedItem = oCurrentBranch
    '                    End If
    '                Catch
    '                    cboCaveBranchList.SelectedIndex = 0
    '                End Try
    '                cboCaveBranchList.Enabled = True
    '            Else
    '                cboCaveBranchList.Enabled = False
    '            End If
    '        End If
    '    Catch
    '    End Try
    'End Sub

    Private Sub btnDeleteValue_Click(sender As Object, e As EventArgs) Handles btnDeleteValue.ItemClick
        Dim oOwner As DevExpress.XtraVerticalGrid.PropertyGridControl = mnuDataProperties.Tag
        If Not oOwner.FocusedRow Is Nothing Then
            Dim oDescriptor As PropertyDescriptor = oOwner.GetPropertyDescriptor(oOwner.FocusedRow)
            If Not oDescriptor Is Nothing Then
                Call oDescriptor.ResetValue(oOwner.SelectedObject)
                Call oOwner.Refresh()
            End If
        End If
    End Sub

    Friend Event OnApply(Sender As frmItemsFilter)

    Private Sub cmdApply_Click(sender As System.Object, e As System.EventArgs) Handles cmdApply.Click
        Call pSave()
        RaiseEvent OnApply(Me)
    End Sub

    Private Sub cboCaveList_EditValueChanged(sender As Object, e As EventArgs) Handles cboCaveList.EditValueChanged
        Dim oCave As cCaveInfo = cboCaveList.EditValue
        Dim oBranch As cCaveInfoBranch = cboCaveBranchList.EditValue
        Dim sCave As String = "" & If(cboCaveList.EditValue Is Nothing, "", cboCaveList.EditValue.name)
        Dim sCurrentBranch As String = "" & If(cboCaveBranchList.EditValue Is Nothing, "", cboCaveBranchList.EditValue.path)
        Call pRefreshCaveBranchList(oSurvey, sCave, cboCaveBranchList)
    End Sub

    Private Sub pRefreshCaveBranchList(Survey As cSurvey.cSurvey, ByVal Cave As String, ByVal BranchesCombo As DevExpress.XtraEditors.GridLookUpEdit)
        If Cave = "" Then
            BranchesCombo.Properties.DataSource = New List(Of cCaveInfoBranch)({oSurvey.Properties.CaveInfos.GetEmptyCaveInfoBranch(Cave)})
            BranchesCombo.EditValue = BranchesCombo.Properties.DataSource(0)
            BranchesCombo.Enabled = False
        Else
            BranchesCombo.Properties.DataSource = Survey.Properties.CaveInfos(Cave).Branches.GetAllBranchesWithEmpty.Select(Function(oitem) oitem.Value).ToList
            If BranchesCombo.Properties.DataSource.Count > 0 Then
                BranchesCombo.EditValue = BranchesCombo.Properties.DataSource(0)
                BranchesCombo.Enabled = True
            Else
                BranchesCombo.Enabled = False
            End If
        End If
    End Sub
End Class