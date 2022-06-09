Imports cSurveyPC.cSurvey
Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class cCaveBranchSelectorGrid
    Private sFieldname As String

    Public Sub RefreshData()
        GridView1.RefreshData()
    End Sub

    Public Function GetFocusedObject() As UIHelpers.cCaveBranchSelectorPlaceholder
        Return GridView1.GetFocusedObject
    End Function

    Public Sub Rebind(Survey As cSurvey.cSurvey, Items As Object, FieldType As UnboundColumnType, FieldCaption As String, FieldName As String)
        GridControl1.DataSource = Items
        colCaveBranchValue.Caption = FieldCaption
        colCaveBranchValue.UnboundType = FieldType
        sFieldname = FieldName
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Dim oItem As UIHelpers.cCaveBranchSelectorPlaceholder = GridView1.GetRow(e.RowHandle)
        If Not oItem Is Nothing Then
            If e.Column Is colCaveBranchCaveColor Then
                If Not oItem.CaveInfo Is Nothing Then
                    e.Appearance.BackColor = oItem.CaveInfo.GetColor(Color.LightGray)
                End If
            ElseIf e.Column Is colCaveBranchBranchColor Then
                If oItem.CaveInfoBranch Is Nothing Then
                    If Not oItem.CaveInfo Is Nothing Then
                        e.Appearance.BackColor = oItem.CaveInfo.GetColor(Color.LightGray)
                    End If
                Else
                    e.Appearance.BackColor = oItem.CaveInfoBranch.GetColor(Color.LightGray)
                End If
            End If
        End If
    End Sub

    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs) Handles GridView1.CustomUnboundColumnData
        If e.Column Is colCaveBranchValue Then
            If e.IsGetData Then
                e.Value = CallByName(e.Row, sFieldname, CallType.Get)
            Else
                CallByName(e.Row, sFieldname, CallType.Let, e.Value)
            End If
        End If
    End Sub

    Public Event PopupMenuShowing As PopupMenuShowingEventHandler

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        RaiseEvent PopupMenuShowing(Me, e)
    End Sub

    Public Event FocusedRowChanged As FocusedRowChangedEventHandler

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        RaiseEvent FocusedRowChanged(Me, e)
    End Sub
End Class
