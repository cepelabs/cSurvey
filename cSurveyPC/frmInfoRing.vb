Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Calculate
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors.Controls

Friend Class frmInfoRing
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

            Call grdRings.BeginUpdate()
            grdRings.DataSource = New UIHelpers.cRingsEditBindingList(oSurvey.Calculate.Rings)
            Call grdRings.EndUpdate()
        Catch
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Close()
    End Sub

    'Private Sub mnuInfoRingSelectAll_Click(sender As Object, e As EventArgs)
    '    Call grdSurveyRing.CancelEdit()
    '    For Each oRow As DataGridViewRow In grdSurveyRing.Rows
    '        oRow.Cells(0).Value = True
    '    Next
    'End Sub

    'Private Sub mnuInfoRingDeselectAll_Click(sender As Object, e As EventArgs)
    '    Call grdSurveyRing.CancelEdit()
    '    For Each oRow As DataGridViewRow In grdSurveyRing.Rows
    '        oRow.Cells(0).Value = False
    '    Next
    'End Sub

    'Private Sub mnuInfoRingRevertSelect_Click(sender As Object, e As EventArgs)
    '    Call grdSurveyRing.CancelEdit()
    '    For Each oRow As DataGridViewRow In grdSurveyRing.Rows
    '        oRow.Cells(0).Value = Not oRow.Cells(0).Value
    '    Next
    'End Sub

    Friend Event OnApply(Sender As frmInfoRing)

    Private Sub pSave()
        DirectCast(grdRings.DataSource, UIHelpers.cRingsEditBindingList).Save()
    End Sub

    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click
        Call pSave()
        RaiseEvent OnApply(Me)
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Call pSave()
        RaiseEvent OnApply(Me)
    End Sub

    Private Sub grdRingsView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles grdRingsView.CustomUnboundColumnData
        If e.IsGetData Then
            If e.Column Is colRingsStations Then
                e.Value = String.Join(",", DirectCast(e.Row, UIHelpers.cRingPlaceholder).Ring.GetStations)
            End If
        End If
    End Sub

    Private Sub grdRingsView_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles grdRingsView.PopupMenuShowing
        If e.HitInfo.InRowCell Then
            e.Allow = False
            Call mnuContext.ShowPopup(grdRings.PointToScreen(e.Point))
        End If
    End Sub

    Private Sub btnCopy_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopy.ItemClick
        Call grdRingsView.CopyRow
    End Sub

    Private Sub btnCopyAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyAll.ItemClick
        Call grdRingsView.CopyRows
    End Sub

    Private Sub btnCopyValue_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyValue.ItemClick
        Call grdRingsView.CopyRowValue
    End Sub

    Private Sub btnCopyValues_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyValues.ItemClick
        Call grdRingsView.CopyRowValues
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnExport.ItemClick
        Call modExport.GridExportTo(oSurvey, grdRings, Text, "", Me)
    End Sub

    Private Sub btnSelectAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnSelectAll.ItemClick
        grdRings.BeginUpdate()
        DirectCast(grdRings.DataSource, UIHelpers.cRingsEditBindingList).SelectAll()
        grdRings.EndUpdate()
    End Sub

    Private Sub btnInvertSelection_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnInvertSelection.ItemClick
        grdRings.BeginUpdate()
        DirectCast(grdRings.DataSource, UIHelpers.cRingsEditBindingList).InvertSelection()
        grdRings.EndUpdate()
    End Sub

    Private Sub btnDeselectAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnDeselectAll.ItemClick
        grdRings.BeginUpdate()
        DirectCast(grdRings.DataSource, UIHelpers.cRingsEditBindingList).DeselectAll()
        grdRings.EndUpdate()
    End Sub

    Private Sub txtRingsColor_EditValueChanged(sender As Object, e As EventArgs) Handles txtRingsColor.EditValueChanged
        If grdRingsView.PostEditor() Then
            grdRingsView.UpdateCurrentRow()
        End If
    End Sub

    Private Sub chkRingsSelect_EditValueChanged(sender As Object, e As EventArgs) Handles chkRingsSelect.EditValueChanged
        If grdRingsView.PostEditor() Then
            grdRingsView.UpdateCurrentRow()
        End If
    End Sub

    Private Sub txtRingsColor_CustomDisplayText(sender As Object, e As CustomDisplayTextEventArgs) Handles txtRingsColor.CustomDisplayText
        e.DisplayText = ""
    End Sub
End Class