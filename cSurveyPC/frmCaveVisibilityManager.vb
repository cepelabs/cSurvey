Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design

Imports cSurveyPC.XSystem.Linq.Dynamic
Imports System.Linq.Expressions

Public Class frmCaveVisibilityManager
    Friend Event OnChangeVisibility(ByVal Sender As Object, ByVal CaveVisibilityProfiles As cCaveVisibilityProfiles, CurrentProfile As String)

    Private oSurvey As cSurvey.cSurvey
    Private sCurrentProfile As String
    Private oCaveVisibilityProfiles As cCaveVisibilityProfiles

    Private bEventDisabled As Boolean

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Call pGridToProfile()
        RaiseEvent OnChangeVisibility(Me, oCaveVisibilityProfiles, sCurrentProfile)
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Call pGridToProfile()
        RaiseEvent OnChangeVisibility(Me, oCaveVisibilityProfiles, sCurrentProfile)
        Call Close()
    End Sub

    Private Sub pGridToProfile()
        Dim oProfile As cCaveVisibilityProfile = oCaveVisibilityProfiles(sCurrentProfile)
        For Each oRow As DataGridViewRow In grdProfile.Rows
            Dim sCaveInfo As String = oRow.Cells(0).Value
            Dim sCaveInfoBranch As String = oRow.Cells(1).Value
            Dim bVisible As Boolean = oRow.Cells(2).Value
            Call oProfile.SetVisible(sCaveInfo, sCaveInfoBranch, bVisible)

            oProfile.SegmentsQuery = txtSegments.Text
            oProfile.ItemsQuery = txtItems.Text
        Next
    End Sub

    Private Sub pProfileToGrid()
        sCurrentProfile = cboProfiles.Text
        Dim oProfile As cCaveVisibilityProfile = oCaveVisibilityProfiles(sCurrentProfile)
        For Each oRow As DataGridViewRow In grdProfile.Rows
            Dim sCaveInfo As String = oRow.Cells(0).Value
            Dim sCaveInfoBranch As String = oRow.Cells(1).Value
            Dim bVisible As Boolean = oProfile.GetVisible(sCaveInfo, sCaveInfoBranch)
            oRow.Cells(2).Value = bVisible
        Next
        txtSegments.Text = oProfile.SegmentsQuery
        txtItems.Text = oProfile.ItemsQuery

        If sCurrentProfile = "" Then
            grdProfile.Enabled = False
            txtSegments.Enabled = False
            txtItems.Enabled = False
        Else
            grdProfile.Enabled = True
            txtSegments.Enabled = True
            txtItems.Enabled = True
        End If
        Call pQueryToolsEnabled()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Call Close()
    End Sub

    Public Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey, CaveVisibilityProfiles As cCaveVisibilityProfiles, Optional CurrentProfile As String = "")

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey
        sCurrentProfile = CurrentProfile
        oCaveVisibilityProfiles = New cCaveVisibilityProfiles(oSurvey)
        Call oCaveVisibilityProfiles.CopyFrom(CaveVisibilityProfiles)

        Call cboProfiles.Items.Add("")
        For Each oProfile As cCaveVisibilityProfile In oCaveVisibilityProfiles
            Dim iIndex As Integer = cboProfiles.Items.Add(oProfile.Name)
        Next

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
        Try
            cboProfiles.SelectedItem = sCurrentProfile
        Catch
            cboProfiles.SelectedIndex = 0
            Call cboProfiles_SelectedIndexChanged(Nothing, Nothing)
        End Try
        Call pProfileToGrid()
        bEventDisabled = False
    End Sub

    Private Sub cboProfiles_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboProfiles.SelectedIndexChanged
        If Not bEventDisabled Then
            Call pGridToProfile()
            Call pProfileToGrid()
        End If
        If cboProfiles.SelectedIndex = 0 Then
            btnAddAsCopy.Enabled = False
            btnRemove.Enabled = False
        Else
            btnAddAsCopy.Enabled = True
            btnRemove.Enabled = True
        End If
    End Sub

    Private Sub tbMain_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbMain.ItemClicked

    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Dim sNewName As String
        Do
            sNewName = InputBox(GetLocalizedString("cavevisibilitymanager.adddialog"), GetLocalizedString("cavevisibilitymanager.adddialogtitle"), "")
            sNewName = sNewName.Trim
        Loop Until sNewName = "" Or Not oCaveVisibilityProfiles.Contains(sNewName)
        If sNewName <> "" Then
            Call oCaveVisibilityProfiles.Add(sNewName)
            Dim iIndex As Integer = cboProfiles.Items.Add(sNewName)
            cboProfiles.SelectedIndex = iIndex
        End If
    End Sub

    Private Sub btnAddAsCopy_Click(sender As System.Object, e As System.EventArgs) Handles btnAddAsCopy.Click
        Dim sNewName As String
        Do
            sNewName = InputBox(GetLocalizedString("cavevisibilitymanager.adddialogtitle"), GetLocalizedString("cavevisibilitymanager.adddialog"), "")
            sNewName = sNewName.Trim
        Loop Until sNewName = "" Or Not oCaveVisibilityProfiles.Contains(sNewName)
        If sNewName <> "" Then
            Call pGridToProfile()
            Call oCaveVisibilityProfiles.AddAsCopy(sCurrentProfile, sNewName)
            Dim iIndex As Integer = cboProfiles.Items.Add(sNewName)
            cboProfiles.SelectedIndex = iIndex
        End If
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        If sCurrentProfile = "" Then
            Call MsgBox(GetLocalizedString("cavevisibilitymanager.warning1"), vbOKOnly Or MsgBoxStyle.Exclamation, GetLocalizedString("cavevisibilitymanager.warningtitle"))
        Else
            If MsgBox(String.Format(GetLocalizedString("cavevisibilitymanager.removedialog"), sCurrentProfile), vbYesNo Or MsgBoxStyle.Question, GetLocalizedString("cavevisibilitymanager.warningtitle")) = MsgBoxResult.Yes Then
                Call oCaveVisibilityProfiles.Remove(sCurrentProfile)
                Call cboProfiles.Items.Remove(sCurrentProfile)
                sCurrentProfile = ""
                Call pProfileToGrid()
            End If
        End If
    End Sub

    Private Sub btnRemoveAll_Click(sender As System.Object, e As System.EventArgs) Handles btnRemoveAll.Click
        If MsgBox(GetLocalizedString("cavevisibilitymanager.removedialog2"), vbYesNo Or MsgBoxStyle.Question, GetLocalizedString("cavevisibilitymanager.warningtitle")) = MsgBoxResult.Yes Then
            Call oCaveVisibilityProfiles.Clear()
            Call cboProfiles.Items.Clear()
            Call cboProfiles.Items.Add("")
            sCurrentProfile = ""
            Call pProfileToGrid()
        End If
    End Sub

    Private Sub pCleanSegments()
        Call txtSegments.Clear()
    End Sub

    Private Sub pCheckSintaxSegments()
        Cursor = Cursors.WaitCursor
        Try
            Dim sSegmentsQuery As String = txtSegments.Text
            If sSegmentsQuery <> "" Then
                Dim oSegments As cISegmentCollection = oSurvey.Segments
                Dim oQuerySegments = From oSegment As cISegment In oSegments.ToArray.AsQueryable.Where(sSegmentsQuery) Select oSegment
                Call MsgBox(GetLocalizedString("cavevisibilitymanager.warning3"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, GetLocalizedString("cavevisibilitymanager.warningtitle"))
            Else
                Call MsgBox(GetLocalizedString("cavevisibilitymanager.warning2"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, GetLocalizedString("cavevisibilitymanager.warningtitle"))
            End If
        Catch ex As Exception
            Call MsgBox(String.Format(GetLocalizedString("cavevisibilitymanager.warning4"), ex.Message), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("cavevisibilitymanager.warningtitle"))
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub pCleanItems()
        Call txtItems.Clear()
    End Sub

    Private Sub pCheckSintaxItems()
        Cursor = Cursors.WaitCursor
        Try
            Dim sItemsQuery As String = txtItems.Text
            If sItemsQuery <> "" Then
                Dim oItems As List(Of cItem) = New List(Of cItem)
                Dim oQueryItems = From oItem As cItem In oItems.ToArray.AsQueryable.Where(sItemsQuery) Select oItem
                Call MsgBox(GetLocalizedString("cavevisibilitymanager.warning3"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, GetLocalizedString("cavevisibilitymanager.warningtitle"))
            Else
                Call MsgBox(GetLocalizedString("cavevisibilitymanager.warning2"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, GetLocalizedString("cavevisibilitymanager.warningtitle"))
            End If
        Catch ex As Exception
            Call MsgBox(String.Format(GetLocalizedString("cavevisibilitymanager.warning4"), ex.Message), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("cavevisibilitymanager.warningtitle"))
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub tabProfile_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles tabProfile.SelectedIndexChanged
        Call pQueryToolsEnabled()
    End Sub

    Private Sub pQueryToolsEnabled()
        If (tabProfile.SelectedTab Is tabSegment Or tabProfile.SelectedTab Is tabItems) And sCurrentProfile <> "" Then
            btnCheckQuerySintax.Enabled = True
            btnCleanQuerySintax.Enabled = True
        Else
            btnCheckQuerySintax.Enabled = False
            btnCleanQuerySintax.Enabled = False
        End If
    End Sub

    Private Sub btnCheckQuerySintax_Click(sender As System.Object, e As System.EventArgs) Handles btnCheckQuerySintax.Click
        If tabProfile.SelectedTab Is tabSegment Then
            Call pCheckSintaxSegments()
        End If
        If tabProfile.SelectedTab Is tabItems Then
            Call pCheckSintaxItems()
        End If
    End Sub

    Private Sub btnCleanQuerySintax_Click(sender As System.Object, e As System.EventArgs) Handles btnCleanQuerySintax.Click
        If tabProfile.SelectedTab Is tabSegment Then
            Call pCleanSegments()
        End If
        If tabProfile.SelectedTab Is tabItems Then
            Call pCleanItems()
        End If
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