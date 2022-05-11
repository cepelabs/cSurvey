Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design

Imports cSurveyPC.XSystem.Linq.Dynamic
Imports System.Linq.Expressions

friend Class frmCaveBranchesSelector
    Private oSurvey As cSurvey.cSurvey
    Private oSelection As List(Of String)
    Private bEventDisabled As Boolean

    Public Event OnApply(Sender As frmCaveBranchesSelector, Args As EventArgs)

    Public ReadOnly Property Selection As List(Of String)
        Get
            Return oSelection
        End Get
    End Property

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Call pGridToList()
        RaiseEvent OnApply(Me, New EventArgs)
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Call pGridToList()
        Call Close()
    End Sub

    Private Sub pGridToList()
        Call oSelection.Clear()
        For Each oRow As DataGridViewRow In grdProfile.Rows
            Dim bVisible As Boolean = oRow.Cells(2).Value
            If bVisible Then
                Dim sCaveInfo As String = oRow.Cells(0).Value
                Dim sCaveInfoBranch As String = oRow.Cells(1).Value
                Call oSelection.Add(sCaveInfo & cCaveInfoBranches.sBranchSeparator & sCaveInfoBranch)
            End If
        Next
    End Sub

    Private Sub pListToGrid()
        For Each oRow As DataGridViewRow In grdProfile.Rows
            Dim sCaveInfo As String = oRow.Cells(0).Value
            Dim sCaveInfoBranch As String = oRow.Cells(1).Value
            Dim sKey As String = sCaveInfo & cCaveInfoBranches.sBranchSeparator & sCaveInfoBranch
            oRow.Cells(2).Value = oSelection.Contains(sKey)
        Next
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Call Close()
    End Sub

    Public Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Selection As List(Of String))

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey
        oSelection = New List(Of String)(Selection)

        Dim oValues(2) As Object
        oValues(0) = ""
        oValues(1) = ""
        oValues(2) = True
        Call grdProfile.Rows.Add(oValues)
        For Each oCaveInfo As cCaveInfo In oSurvey.Properties.CaveInfos
            oValues(0) = oCaveInfo.Name
            oValues(1) = ""
            oValues(2) = True
            Call grdProfile.Rows.Add(oValues)
            For Each oCaveInfoBranches As cCaveInfoBranch In oCaveInfo.Branches.GetAllBranches.Values
                oValues(0) = oCaveInfo.Name
                oValues(1) = oCaveInfoBranches.Path
                oValues(2) = True
                Call grdProfile.Rows.Add(oValues)
            Next
        Next

        bEventDisabled = True
        Call pListToGrid()
        bEventDisabled = False
    End Sub

    Private Sub mnuContextProfileSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuContextProfileSelectAll.Click
        Call grdProfile.EndEdit()
        For Each oRow As DataGridViewRow In grdProfile.Rows
            oRow.Cells(2).Value = True
        Next
    End Sub

    Private Sub mnuContextProfileDeselectAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuContextProfileDeselectAll.Click
        Call grdProfile.EndEdit()
        For Each oRow As DataGridViewRow In grdProfile.Rows
            oRow.Cells(2).Value = False
        Next
    End Sub

    Private Sub mnuContextProfileInvertSelection_Click(sender As System.Object, e As System.EventArgs) Handles mnuContextProfileInvertSelection.Click
        Call grdProfile.EndEdit()
        For Each oRow As DataGridViewRow In grdProfile.Rows
            oRow.Cells(2).Value = Not oRow.Cells(2).Value
        Next
    End Sub

    Private Sub mnuContextProfileSelectCurrentCave_Click(sender As System.Object, e As System.EventArgs) Handles mnuContextProfileSelectCurrentCave.Click
        Call grdProfile.EndEdit()
        If Not grdProfile.CurrentRow Is Nothing Then
            Dim sCurrentCave As String = grdProfile.CurrentRow.Cells(0).Value
            For Each oRow As DataGridViewRow In grdProfile.Rows
                If oRow.Cells(0).Value = sCurrentCave Then
                    oRow.Cells(2).Value = True
                End If
            Next
        End If
    End Sub

    Private Sub mnuContextProfile_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuContextProfile.Opening
        Dim bEnabled As Boolean = Not grdProfile.CurrentRow Is Nothing
        mnuContextProfileSelectCurrentCave.Enabled = bEnabled
        mnuContextProfileDeselectCurrentCave.Enabled = bEnabled
    End Sub

    Private Sub mnuContextProfileDeselectCurrentCave_Click(sender As System.Object, e As System.EventArgs) Handles mnuContextProfileDeselectCurrentCave.Click
        Call grdProfile.EndEdit()
        If Not grdProfile.CurrentRow Is Nothing Then
            Dim sCurrentCave As String = grdProfile.CurrentRow.Cells(0).Value
            For Each oRow As DataGridViewRow In grdProfile.Rows
                If oRow.Cells(0).Value = sCurrentCave Then
                    oRow.Cells(2).Value = False
                End If
            Next
        End If
    End Sub
End Class