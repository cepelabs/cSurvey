Imports System.ComponentModel
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports DevExpress.XtraEditors.Controls
Imports Microsoft.SqlServer
Imports NAudio

Friend Class frmSurveyCleanUpUndefinedCaves

    Private oSurvey As cSurveyPC.cSurvey.cSurvey

    Private oListOfUndefinedCaves As Dictionary(Of String, cDesign.cCleanUpUndefinedCaveAndBranchItem)

    Friend Class cCaveBag
        Public Property Cave As String
        Public Property Branch As String
        Public Property NewCave As cCaveInfo
        Public Property NewBranch As cCaveInfoBranch
        Public Sub New(Cave As String, Branch As String, NewCave As cCaveInfo, NewBranch As cCaveInfoBranch)
            Me.Cave = Cave
            Me.Branch = Branch
            Me.NewCave = NewCave
            Me.NewBranch = NewBranch
        End Sub
    End Class

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.Column Is colNewCave1 Then
            If e.Value IsNot Nothing Then
                Dim oCaveInfo As cCaveInfo = DirectCast(e.Value, cCaveInfo)
                Dim sCave As String = cCaveInfo.EditToString(oCaveInfo)
                If sCave = "" Then
                    grdNewBranch.DataSource = New List(Of cCaveInfoBranch)({oSurvey.Properties.CaveInfos.GetEmptyCaveInfoBranch(sCave)})
                    GridView1.GetFocusedRow.NewBranch = grdNewBranch.DataSource(0)
                    'editvalue?
                Else
                    grdNewBranch.DataSource = oSurvey.Properties.CaveInfos(sCave).Branches.GetAllBranchesWithEmpty.Select(Function(oitem) oitem.Value).ToList
                    GridView1.GetFocusedRow.NewBranch = grdNewBranch.DataSource(0)
                    'editvalue?
                End If
            End If
        End If
    End Sub

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

        Dim oItems As IEnumerable(Of cSurvey.cCaveInfo) = Survey.Properties.CaveInfos.GetWithEmpty.Select(Function(oitem) oitem.Value)
        grdNewCave.DataSource = oItems.ToList

        Dim oBags As BindingList(Of cCaveBag) = New BindingList(Of cCaveBag)
        For Each oItem As cDesign.cCleanUpUndefinedCaveAndBranchItem In ListOfUndefinedCaves.Values
            Dim oCaves As SortedDictionary(Of String, cCaveInfo) = oSurvey.Properties.CaveInfos.GetWithEmpty()
            Dim oCaveInfo As cCaveInfo = oCaves(oItem.NewCave)
            Dim oBranchInfo As cCaveInfoBranch = oCaveInfo.Branches.GetWithEmpty(oItem.NewBranch)
            oBags.Add(New cCaveBag(oItem.Cave, oItem.Branch, oCaveInfo, oBranchInfo))

            'Dim oData(3) As Object
            'oData(0) = oItem.Cave
            'oData(1) = oItem.Branch
            'oData(2) = oItem.NewCave
            'oData(3) = ""

            'Dim iRowIndex As Integer = grdUndefinedCaves.Rows.Add(oData)
            'Dim oRow As DataGridViewRow = grdUndefinedCaves.Rows(iRowIndex)
            'Call pSurveyFillCaveBranchList(oItem.NewCave, oRow.Cells(3))
            'oRow.Cells(3).Value = oItem.NewBranch
        Next

        GridControl1.DataSource = oBags

        'For Each oRow As DataGridViewRow In grdUndefinedCaves.Rows
        '    Dim oCell As DataGridViewComboBoxCell = oRow.Cells(2)
        '    Call pSurveyFillCaveList(oCell)
        'Next
    End Sub

    'Private Sub pSurveyFillCaveBranchList(Cave As String, BranchesCombo As DataGridViewComboBoxCell)
    '    Try
    '        Dim oEmptyCaveInfoBranch As cCaveInfoBranch = oSurvey.Properties.CaveInfos.GetEmptyCaveInfoBranch(Cave)
    '        If Cave = "" Then
    '            Call BranchesCombo.Items.Clear()
    '            Call BranchesCombo.Items.Add("")
    '            'BranchesCombo.Enabled = False
    '        Else
    '            Dim sCurrentBranch As String = BranchesCombo.Value
    '            Call BranchesCombo.Items.Clear()
    '            Call BranchesCombo.Items.Add("")
    '            For Each oBranch As cCaveInfoBranch In oSurvey.Properties.CaveInfos(Cave).Branches.GetAllBranches.Values
    '                Call BranchesCombo.Items.Add(oBranch.Path)
    '            Next
    '            If BranchesCombo.Items.Count > 0 Then
    '                Try
    '                    BranchesCombo.Value = sCurrentBranch
    '                Catch
    '                    BranchesCombo.Value = ""
    '                End Try
    '                'BranchesCombo.Enabled = True
    '            Else
    '                'BranchesCombo.Enabled = False
    '            End If
    '        End If
    '    Catch
    '    End Try
    'End Sub

    'Private Sub pSurveyFillCaveList(CaveCombo As DataGridViewComboBoxCell)
    '    Dim oEmptyCaveInfo As cCaveInfo = oSurvey.Properties.CaveInfos.GetEmptyCaveInfo

    '    Dim sMainCaveList As String = CaveCombo.Value
    '    Call CaveCombo.Items.Clear()
    '    Call CaveCombo.Items.Add(oEmptyCaveInfo)

    '    For Each oCaveInfo As cCaveInfo In oSurvey.Properties.CaveInfos
    '        Call CaveCombo.Items.Add(oCaveInfo.Name)
    '    Next

    '    Try
    '        CaveCombo.Value = sMainCaveList
    '    Catch
    '        CaveCombo.Value = ""
    '    End Try
    'End Sub

    'Private Sub grdUndefinedCaves_CellValidated(sender As Object, e As DataGridViewCellEventArgs)
    '    If e.ColumnIndex = 2 Or e.ColumnIndex = 3 Then
    '        Dim oCurrentRow As DataGridViewRow = grdUndefinedCaves.Rows(e.RowIndex)
    '        Dim oCell As DataGridViewComboBoxCell = oCurrentRow.Cells(e.ColumnIndex)
    '        If e.ColumnIndex = 2 Then
    '            Call pSurveyFillCaveBranchList("" & oCell.Value, oCurrentRow.Cells(3))
    '        End If
    '    End If
    'End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        For Each oBag As cCaveBag In GridControl1.DataSource
            Dim sCave As String = oBag.Cave
            Dim sBranch As String = oBag.Branch

            Dim sNewCave As String = oBag.NewCave.Name
            Dim sNewBranch As String = oBag.NewBranch.Path

            With oListOfUndefinedCaves(cDesign.cCleanUpUndefinedCaveAndBranchItem.GetKey(sCave, sBranch))
                .NewCave = sNewCave
                .NewBranch = sNewBranch
            End With
        Next
        'For Each oRow As DataGridViewRow In grdUndefinedCaves.Rows
        '    Dim sCave As String = oRow.Cells(0).Value
        '    Dim sBranch As String = oRow.Cells(1).Value

        '    Dim sNewCave As String = "" & oRow.Cells(2).Value
        '    Dim sNewBranch As String = "" & oRow.Cells(3).Value

        '    With oListOfUndefinedCaves(cDesign.cCleanUpUndefinedCaveAndBranchItem.GetKey(sCave, sBranch))
        '        .NewCave = sNewCave
        '        .NewBranch = sNewBranch
        '    End With
        'Next
    End Sub

    Private Sub grdNewCave_EditValueChanged(sender As Object, e As EventArgs) Handles grdNewCave.EditValueChanged

        'Dim editor = TryCast(sender, DevExpress.XtraEditors.GridLookUpEdit)
        'If editor Is Nothing Then Return

        'Dim nuovo = TryCast(editor.EditValue, cCaveInfo)
        'Dim attuale = TryCast(
        'GridView1.GetFocusedRowCellValue(colNewCave1), cCaveInfo)

        'Debug.WriteLine("Editor: " &
        'If(nuovo Is Nothing, "<Nothing>", nuovo.Name))

        'Debug.WriteLine("Cella prima: " &
        'If(attuale Is Nothing, "<Nothing>", attuale.Name))

        'Debug.WriteLine("Stessa istanza: " &
        'Object.ReferenceEquals(nuovo, attuale).ToString())

        'Dim esito As Boolean = GridView1.PostEditor()
        'Debug.WriteLine("PostEditor: " & esito.ToString())

    End Sub
End Class