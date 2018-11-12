Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design

Public Class frmSurveyCleanUpUndefinedCaves

    Private oSurvey As cSurveyPC.cSurvey.cSurvey

    Private oListOfUndefinedCaves As Dictionary(Of String, cDesign.cCleanUpUndefinedCaveAndBranchItem)

    Public Sub New(Survey As cSurveyPC.cSurvey.cSurvey, Design As cDesign, ListOfUndefinedCaves As Dictionary(Of String, cDesign.cCleanUpUndefinedCaveAndBranchItem))

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        oSurvey = Survey
        oListOfUndefinedCaves = ListOfUndefinedCaves
        If Design.Type = cIDesign.cDesignTypeEnum.Plan Then
            Text = Text & " (" & GetLocalizedString("cleanupundefinedcaves.textpart1") & ")"
        Else
            Text = Text & " (" & GetLocalizedString("cleanupundefinedcaves.textpart2") & ")"
        End If

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        For Each oItem As cDesign.cCleanUpUndefinedCaveAndBranchItem In ListOfUndefinedCaves.Values
            Dim oData(3) As Object
            oData(0) = oItem.Cave
            oData(1) = oItem.Branch
            oData(2) = oItem.NewCave
            oData(3) = ""
            Dim iRowIndex As Integer = grdUndefinedCaves.Rows.Add(oData)
            Dim oRow As DataGridViewRow = grdUndefinedCaves.Rows(iRowIndex)
            Call pSurveyFillCaveBranchList(oItem.NewCave, oRow.Cells(3))
            oRow.Cells(3).Value = oItem.NewBranch
        Next

        For Each oRow As DataGridViewRow In grdUndefinedCaves.Rows
            Dim oCell As DataGridViewComboBoxCell = oRow.Cells(2)
            Call pSurveyFillCaveList(oCell)
        Next
    End Sub

    Private Sub pSurveyFillCaveBranchList(Cave As String, BranchesCombo As DataGridViewComboBoxCell)
        Try
            Dim oEmptyCaveInfoBranch As cCaveInfoBranch = oSurvey.Properties.CaveInfos.GetEmptyCaveInfoBranch(Cave)
            If Cave = "" Then
                Call BranchesCombo.Items.Clear()
                Call BranchesCombo.Items.Add("")
                'BranchesCombo.Enabled = False
            Else
                Dim sCurrentBranch As String = BranchesCombo.Value
                Call BranchesCombo.Items.Clear()
                Call BranchesCombo.Items.Add("")
                For Each oBranch As cCaveInfoBranch In oSurvey.Properties.CaveInfos(Cave).Branches.GetAllBranches.Values
                    Call BranchesCombo.Items.Add(oBranch.Path)
                Next
                If BranchesCombo.Items.Count > 0 Then
                    Try
                        BranchesCombo.Value = sCurrentBranch
                    Catch
                        BranchesCombo.Value = ""
                    End Try
                    'BranchesCombo.Enabled = True
                Else
                    'BranchesCombo.Enabled = False
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub pSurveyFillCaveList(CaveCombo As DataGridViewComboBoxCell)
        Dim oEmptyCaveInfo As cCaveInfo = oSurvey.Properties.CaveInfos.GetEmptyCaveInfo

        Dim sMainCaveList As String = CaveCombo.Value
        Call CaveCombo.Items.Clear()
        Call CaveCombo.Items.Add(oEmptyCaveInfo)

        For Each oCaveInfo As cCaveInfo In oSurvey.Properties.CaveInfos
            Call CaveCombo.Items.Add(oCaveInfo.Name)
        Next

        Try
            CaveCombo.Value = sMainCaveList
        Catch
            CaveCombo.Value = ""
        End Try
    End Sub

    Private Sub grdUndefinedCaves_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles grdUndefinedCaves.CellValidated
        If e.ColumnIndex = 2 Or e.ColumnIndex = 3 Then
            Dim oCurrentRow As DataGridViewRow = grdUndefinedCaves.Rows(e.RowIndex)
            Dim oCell As DataGridViewComboBoxCell = oCurrentRow.Cells(e.ColumnIndex)
            If e.ColumnIndex = 2 Then
                Call pSurveyFillCaveBranchList("" & oCell.Value, oCurrentRow.Cells(3))
            End If
        End If
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        For Each oRow As DataGridViewRow In grdUndefinedCaves.Rows
            Dim sCave As String = oRow.Cells(0).Value
            Dim sBranch As String = oRow.Cells(1).Value

            Dim sNewCave As String = "" & oRow.Cells(2).Value
            Dim sNewBranch As String = "" & oRow.Cells(3).Value

            With oListOfUndefinedCaves(cDesign.cCleanUpUndefinedCaveAndBranchItem.GetKey(sCave, sBranch))
                .NewCave = sNewCave
                .NewBranch = sNewBranch
            End With
        Next
    End Sub

    Private Sub grdUndefinedCaves_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles grdUndefinedCaves.DataError
        'non cancellare
    End Sub
End Class