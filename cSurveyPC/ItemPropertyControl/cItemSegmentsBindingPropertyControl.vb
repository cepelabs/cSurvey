Imports System.ComponentModel
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraTreeList

Friend Class cItemSegmentsBindingPropertyControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() 
        Enabled = False
    End Sub

    Public Shadows Sub Rebind(Item As cItem)
        MyBase.Rebind(Item)
        Enabled = (Item.Cave <> "")
        Call pRefresh()
    End Sub

    Private Sub pRefresh()
        Dim oSegments As SortedList(Of String, cISegment) = New SortedList(Of String, cISegment)
        For Each oPoint As cPoint In Item.Points
            Dim oSegment As cISegment = oPoint.BindedSegment
            If Not oSegment Is Nothing Then
                If Not oSegments.ContainsKey(oSegment.ID) Then
                    Call oSegments.Add(oSegment.ID, oSegment)
                End If
            End If
        Next
        grdSegmentsBinded.Rebind(Item.Survey, oSegments.Values.Cast(Of cSegment).ToList, New cSegmentsGrid.cSegmentGridParameters(False, True, True, True))
    End Sub

    Private Sub cmdPropSegmentsRebind_Click(sender As Object, e As EventArgs) Handles cmdPropSegmentsRebind.Click
        If Not DisabledObjectProperty() Then
            Call Item.BindSegments()
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cmdPropSegmentsUnlock_Click(sender As Object, e As EventArgs) Handles cmdPropSegmentsUnlock.Click
        If Not DisabledObjectProperty() Then
            Item.UnlockSegments()
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cmdPropSegmentsLock_Click(sender As Object, e As EventArgs) Handles cmdPropSegmentsLock.Click
        If Not DisabledObjectProperty() Then
            Item.LockSegments()
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub grdSegmentsBinded_DoubleClick(sender As Object, e As EventArgs) Handles grdSegmentsBinded.DoubleClick
        Call btnPropObjectsSelect.PerformClick()
    End Sub

    Private Sub btnPropObjectsRefresh_Click(sender As Object, e As EventArgs) Handles btnPropObjectsRefresh.Click
        Call pRefresh()
    End Sub

    Private Sub btnPropObjectsSelect_Click(sender As Object, e As EventArgs) Handles btnPropObjectsSelect.Click
        If grdSegmentsBinded.SelectedItem IsNot Nothing Then
            Call DoCommand("selectshot", grdSegmentsBinded.SelectedItem)
        End If
    End Sub

    Private Sub grdSegmentsBinded_SelectionChanged(sender As Object, e As cSegmentsGrid.cSelectionChangedEventArgs) Handles grdSegmentsBinded.SelectionChanged
        If e.SelectedItem Is Nothing Then
            btnPropObjectsSelect.Enabled = False
        Else
            btnPropObjectsSelect.Enabled = True
        End If
    End Sub

    'Private Sub lvPropSegmentsBinded_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvPropSegmentsBinded.DoubleClick
    '    If lvPropSegmentsBinded.SelectedItems.Count > 0 Then
    '        Call pFieldDataShow(True)
    '    End If
    'End Sub

    'Private Sub lvPropSegmentsBinded_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPropSegmentsBinded.SelectedIndexChanged
    '    If Not bDisabledObjectPropertyEvent Then
    '        Try
    '            Dim oSegment As cSegment = lvPropSegmentsBinded.SelectedItems(0).Tag
    '            Call pSegmentSelect(oSegment, False, False)
    '        Catch
    '        End Try
    '    End If
    'End Sub
End Class
