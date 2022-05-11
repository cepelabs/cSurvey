Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Calculate

friend Class frmInfoRing
    Private oSurvey As cSurvey.cSurvey

    Friend Sub New(ByVal Survey As cSurvey.cSurvey, Optional ByVal Cave As String = "")
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        Call pRefreshInfo()
    End Sub

    Private Sub pRefreshInfo()
        Cursor = Cursors.WaitCursor
        Dim sDistanceSimbol As String = cSegment.GetDistanceSimbol(oSurvey.Properties.DistanceType)
        Try
            txtSurveyRingAverageError.Text = oSurvey.Calculate.Rings.AverageErrorPercent & "%"
            Call grdSurveyRing.Rows.Clear()
            For Each oRing As cRing In oSurvey.Calculate.Rings
                Dim oRow(10) As Object
                oRow(0) = oRing.Selected
                oRow(1) = oRing.Item(0) 'stazione 0/nome dell'anello
                oRow(2) = oRing.ErrorPercent & "%"    'errore %
                oRow(3) = modNumbers.MathRound(modConversion.ConvertBaseToDefaultDistance(oRing.Error, oSurvey), 1) & " " & sDistanceSimbol   'errore ass
                oRow(4) = modNumbers.MathRound(modConversion.ConvertBaseToDefaultDistance(oRing.X, oSurvey), 1) & " " & sDistanceSimbol  'x
                oRow(5) = modNumbers.MathRound(modConversion.ConvertBaseToDefaultDistance(oRing.Y, oSurvey), 1) & " " & sDistanceSimbol  'y
                oRow(6) = modNumbers.MathRound(modConversion.ConvertBaseToDefaultDistance(oRing.Z, oSurvey), 1) & " " & sDistanceSimbol  'z
                oRow(7) = modNumbers.MathRound(modConversion.ConvertBaseToDefaultDistance(oRing.Length, oSurvey), 1) & " " & sDistanceSimbol   'lung anello
                oRow(8) = oRing.Count   'n°stazioni
                oRow(9) = String.Join(",", oRing.GetStations)
                Dim iRowIndex As Integer = grdSurveyRing.Rows.Add(oRow)
                With grdSurveyRing.Rows(iRowIndex)
                    .Tag = oRing
                    .Cells(10).Style.BackColor = oRing.Color
                End With
            Next
        Catch
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Close()
    End Sub

    Private Sub mnuInfoRingCopy_Click(sender As Object, e As EventArgs) Handles mnuInfoRingCopy.Click
        Cursor = Cursors.WaitCursor
        Call modCaveInfoTools.CopyGridData(grdSurveyRing.SelectedRows)
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuInfoRingCopyAll_Click(sender As Object, e As EventArgs) Handles mnuInfoRingCopyAll.Click
        Cursor = Cursors.WaitCursor
        Call modCaveInfoTools.CopyGridData(grdSurveyRing.Rows)
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuInfoRingSelectAll_Click(sender As Object, e As EventArgs) Handles mnuInfoRingSelectAll.Click
        Call grdSurveyRing.CancelEdit()
        For Each oRow As DataGridViewRow In grdSurveyRing.Rows
            oRow.Cells(0).Value = True
        Next
    End Sub

    Private Sub mnuInfoRingDeselectAll_Click(sender As Object, e As EventArgs) Handles mnuInfoRingDeselectAll.Click
        Call grdSurveyRing.CancelEdit()
        For Each oRow As DataGridViewRow In grdSurveyRing.Rows
            oRow.Cells(0).Value = False
        Next
    End Sub

    Private Sub mnuInfoRingRevertSelect_Click(sender As Object, e As EventArgs) Handles mnuInfoRingRevertSelect.Click
        Call grdSurveyRing.CancelEdit()
        For Each oRow As DataGridViewRow In grdSurveyRing.Rows
            oRow.Cells(0).Value = Not oRow.Cells(0).Value
        Next
    End Sub

    Friend Event OnApply(Sender As frmInfoRing)

    Private Sub pSave()
        For Each oRow As DataGridViewRow In grdSurveyRing.Rows
            With DirectCast(oRow.Tag, cRing)
                .Selected = oRow.Cells(0).Value
                .Color = oRow.Cells(10).Style.BackColor
            End With
        Next
    End Sub

    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click
        Call pSave()
        RaiseEvent OnApply(Me)
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Call pSave()
        RaiseEvent OnApply(Me)
    End Sub

    Private Sub grdSurveyRing_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdSurveyRing.CellContentDoubleClick
      
    End Sub

    Private Sub grdSurveyRing_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdSurveyRing.CellContentClick
        If e.ColumnIndex = 10 Then
            Call pRingColorEdit(grdSurveyRing.Rows(e.RowIndex).Cells(e.ColumnIndex))
        End If
    End Sub

    Private Sub pRingColorReset(Cell As DataGridViewCell)
        Cell.Style.BackColor = Color.Transparent
    End Sub

    Private Sub pRingColorEdit(Cell As DataGridViewCell)
        oColorDialog.Color = Cell.Style.BackColor
        If oColorDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Cell.Style.BackColor = oColorDialog.Color
        End If
    End Sub

    Private Sub mnuInfoRingColorBrowse_Click(sender As Object, e As EventArgs) Handles mnuInfoRingColorBrowse.Click
        Call pRingColorEdit(grdSurveyRing.CurrentRow.Cells(10))
    End Sub

    Private Sub mnuInfoRingColorReset_Click(sender As Object, e As EventArgs) Handles mnuInfoRingColorReset.Click
        Call pRingColorReset(grdSurveyRing.CurrentRow.Cells(10))
    End Sub

    Private Sub mnuInfoRing_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuInfoRing.Opening
        Dim bColorEnabled As Boolean = Not grdSurveyRing.CurrentRow Is Nothing
        mnuInfoRingColor.Enabled = bColorEnabled
    End Sub

    Private Sub mnuInfoRingExport_Click(sender As Object, e As EventArgs) Handles mnuInfoRingExport.Click
        Call modExport.GridExportTo(oSurvey, grdSurveyRing, Text, "", Me)
    End Sub
End Class