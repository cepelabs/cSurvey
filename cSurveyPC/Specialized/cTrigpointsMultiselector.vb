Imports System.ComponentModel
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.UIHelpers
Imports DevExpress.XtraBars

Public Class cTrigpointsMultiselector
    Private oSurvey As cSurveyPC.cSurvey.cSurvey
    Public ReadOnly Property Trigpoints As List(Of cTrigPoint)
        Get
            Return cDestTrigpoints.Items
        End Get
    End Property

    Public ReadOnly Property Splay As Boolean
        Get
            Return cSourceTrigpoints.Splay
        End Get
    End Property

    Public ReadOnly Property Survey As cSurveyPC.cSurvey.cSurvey
        Get
            Return oSurvey
        End Get
    End Property

    Public Sub Rebind(Survey As cSurveyPC.cSurvey.cSurvey, Trigpoints As List(Of cTrigPoint), Splay As Boolean)
        oSurvey = Survey
        Dim oSourceTrigpoint As cTrigpointByCaveBindinglist = New cTrigpointByCaveBindinglist(cTrigpointByCaveBindinglist.StyleEnum.ByCaveBranch)
        Call cSourceTrigpoints.Rebind(oSurvey, oSourceTrigpoint, New cTrigpointsGrid.cTrigpointsGridParameters(cTrigpointsGrid.cTrigpointsGridParameters.SelectionStyleEnum.Multiple, Splay))
        Call cSourceTrigpoints.AddRange(oSurvey.TrigPoints.ToList)
        Call cSourceTrigpoints.UseRange(Trigpoints)

        Dim oDestTrigpoint As cTrigpointByCaveBindinglist = New cTrigpointByCaveBindinglist(cTrigpointByCaveBindinglist.StyleEnum.UniquelistWithCaveAndBranch)
        Call cDestTrigpoints.Rebind(oSurvey, oDestTrigpoint, New cTrigpointsGrid.cTrigpointsGridParameters(cTrigpointsGrid.cTrigpointsGridParameters.SelectionStyleEnum.Multiple, True))
        Call cDestTrigpoints.AddRange(Trigpoints)
    End Sub

    Private Sub btnAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAdd.ItemClick
        Dim oItems As List(Of cTrigPoint) = cSourceTrigpoints.SelectedItems
        Call cDestTrigpoints.AddRange(oItems)
        Call cSourceTrigpoints.UseRange(oItems)
    End Sub

    Private Sub btnRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRemove.ItemClick
        Dim oItems As List(Of cTrigPoint) = cDestTrigpoints.SelectedItems
        Call cDestTrigpoints.RemoveRange(oItems)
        Call cSourceTrigpoints.UnuseRange(oItems)
    End Sub

    Private Sub btnRemoveAll_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRemoveAll.ItemClick
        Call cDestTrigpoints.Clear()
        Call cSourceTrigpoints.UnuseAll()
    End Sub

    Public Event SourceSelectionChanged(sender As Object, e As cTrigpointsGrid.cSelectionChangedEventArgs)
    Public Event DestinationSelectionChanged(sender As Object, e As cTrigpointsGrid.cSelectionChangedEventArgs)

    Private Sub cSourceTrigpoints_SelectionChanged(sender As Object, e As cTrigpointsGrid.cSelectionChangedEventArgs) Handles cSourceTrigpoints.SelectionChanged
        Dim bEnabled As Boolean = e.SelectedItem IsNot Nothing
        btnAdd.Enabled = bEnabled
        RaiseEvent SourceSelectionChanged(Me, e)
    End Sub

    Private Sub cDestTrigpoints_SelectionChanged(sender As Object, e As cTrigpointsGrid.cSelectionChangedEventArgs) Handles cDestTrigpoints.SelectionChanged
        Dim bEnabled As Boolean = e.SelectedItem IsNot Nothing
        btnRemove.Enabled = bEnabled
        btnRemoveAll.Enabled = bEnabled
        RaiseEvent DestinationSelectionChanged(Me, e)
    End Sub

    Private Sub cSourceTrigpoints_ContextMenuShowing(sender As Object, e As MouseEventArgs) Handles cSourceTrigpoints.ContextMenuShowing
        Call mnuSource.ShowPopup(e.Location)
    End Sub

    Private Sub cDestTrigpoints_ContextMenuShowing(sender As Object, e As MouseEventArgs) Handles cDestTrigpoints.ContextMenuShowing
        Call mnuDest.ShowPopup(e.Location)
    End Sub

    Private Sub btnSplay_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles btnSplay.CheckedChanged
        cSourceTrigpoints.Splay = btnSplay.Checked
    End Sub

    Private Sub mnuSource_BeforePopup(sender As Object, e As CancelEventArgs) Handles mnuSource.BeforePopup
        btnSplay.Checked = cSourceTrigpoints.Splay
    End Sub

    Private Sub cDestTrigpoints_DoubleClick(sender As Object, e As EventArgs) Handles cDestTrigpoints.DoubleClick
        Call btnRemove.PerformClick()
    End Sub

    Private Sub cSourceTrigpoints_DoubleClick(sender As Object, e As EventArgs) Handles cSourceTrigpoints.DoubleClick
        Call btnAdd.PerformClick()
    End Sub
End Class
