Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Helper.Editor

Public Class frmItemsFilter
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

        Call cboCategories.Items.Clear()
        Call cboCategories.Items.Add("")
        For Each iCategory As cIItem.cItemCategoryEnum In [Enum].GetValues(GetType(cIItem.cItemCategoryEnum))
            Call cboCategories.Items.Add(New cFilterCategoryItem(iCategory))
        Next

        txtName.Text = "" & oFilter.Name
        cboCategories.Text = New cFilterCategoryItem(oFilter.Category).ToString

        Call pFillCaveList()
        cboCaveList.Text = oFilter.Cave
        cboCaveBranchList.Text = oFilter.Branch

        prpDataProperties.SelectedObject = oFilter.DataProperties.GetClass

        chkReversed.Checked = oFilter.Reversed
    End Sub

    Private Sub cboCaveList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCaveList.SelectedIndexChanged
        Call pFillCaveBranchList(CType(cboCaveList.SelectedItem, cCaveInfo))
    End Sub

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
        oFilter.Cave = cboCaveList.Text
        oFilter.Branch = cboCaveBranchList.Text
        oFilter.Reversed = chkReversed.Checked
        Call oSourceFilter.CopyFrom(oFilter)
    End Sub

    Private Sub pFillCaveList()
        Dim oEmptyCaveInfo As cCaveInfo = oSurvey.Properties.CaveInfos.GetEmptyCaveInfo

        Dim oCaveList As cCaveInfo = cboCaveList.SelectedItem
        Call cboCaveList.Items.Clear()
        Call cboCaveList.Items.Add(oEmptyCaveInfo)

        For Each oCaveInfo As cCaveInfo In oSurvey.Properties.CaveInfos
            Call cboCaveList.Items.Add(oCaveInfo)
        Next

        Try
            If oCaveList Is Nothing Then
                cboCaveList.SelectedIndex = 0
            Else
                cboCaveList.SelectedItem = oCaveList
            End If
        Catch
            cboCaveList.SelectedIndex = 0
        End Try

        Call pFillCaveBranchList(CType(cboCaveList.SelectedItem, cCaveInfo))
    End Sub

    Private Sub pFillCaveBranchList(ByVal Cave As cCaveInfo)
        Dim sCave As String = ""
        If Not Cave Is Nothing Then
            sCave = "" & Cave.Name
        End If
        Call pFillCaveBranchList(sCave)
    End Sub

    Private Sub pFillCaveBranchList(ByVal Cave As String)
        Try
            Dim oEmptyCaveInfoBranch As cCaveInfoBranch = oSurvey.Properties.CaveInfos.GetEmptyCaveInfoBranch(Cave)
            If Cave = "" Then
                Call cboCaveBranchList.Items.Clear()
                Call cboCaveBranchList.Items.Add(oEmptyCaveInfoBranch)
                cboCaveBranchList.Enabled = False
            Else
                Dim oCurrentBranch As cCaveInfoBranch = cboCaveBranchList.SelectedItem
                Call cboCaveBranchList.Items.Clear()
                Call cboCaveBranchList.Items.Add(oEmptyCaveInfoBranch)
                For Each oBranch As cCaveInfoBranch In oSurvey.Properties.CaveInfos(Cave).Branches.GetAllBranches.Values
                    Call cboCaveBranchList.Items.Add(oBranch)
                Next

                If cboCaveBranchList.Items.Count > 0 Then
                    Try
                        If oCurrentBranch Is Nothing Then
                            cboCaveBranchList.SelectedIndex = 0
                        Else
                            cboCaveBranchList.SelectedItem = oCurrentBranch
                        End If
                    Catch
                        cboCaveBranchList.SelectedIndex = 0
                    End Try
                    cboCaveBranchList.Enabled = True
                Else
                    cboCaveBranchList.Enabled = False
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub mnuDesignDataPropertiesDelete_Click(sender As Object, e As EventArgs) Handles mnuDesignDataPropertiesDelete.Click
        Call prpDataProperties.SelectedGridItem.PropertyDescriptor.ResetValue(prpDataProperties.SelectedObject)
        Call prpDataProperties.Refresh()
    End Sub

    Friend Event OnApply(Sender As frmItemsFilter)

    Private Sub cmdApply_Click(sender As System.Object, e As System.EventArgs) Handles cmdApply.Click
        Call pSave()
        RaiseEvent OnApply(Me)
    End Sub
End Class