Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Friend Class cItemPointSegmentBindingPropertyControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Shadows Sub Rebind(Point As cPoint)
        MyBase.Rebind(Point)
        Enabled = (Item.Cave <> "")
        Call pRefresh()
        chkPropSegmentLocked.Checked = Me.Point.SegmentLocked
    End Sub

    Private Sub pRefresh()
        Dim oSegments As SortedList(Of String, cISegment) = New SortedList(Of String, cISegment)
        Dim oSegment As cISegment = Me.Point.BindedSegment
        If Not oSegment Is Nothing Then
            If Not oSegments.ContainsKey(oSegment.ID) Then
                Call oSegments.Add(oSegment.ID, oSegment)
            End If
        End If
        grdSegmentsBinded.Rebind(Item.Survey, oSegments.Values.Cast(Of cSegment).ToList, New cSegmentsGrid.cSegmentGridParameters(False, True, True, True))
    End Sub

    Private Sub chkPropSegmentLocked_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropSegmentLocked.CheckedChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo43"))
            Me.Point.SegmentLocked = chkPropSegmentLocked.Checked
            chkPropSegmentLocked.ImageOptions.SvgImage = If(chkPropSegmentLocked.Checked, My.Resources.Security_Lock, My.Resources.Security_Unlock)
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("PointSegmentLocked")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub grdSegmentsBinded_DoubleClick(sender As Object, e As EventArgs) Handles grdSegmentsBinded.DoubleClick
        Call btnPropObjectsSelect.PerformClick()
    End Sub

    Private Sub grdSegmentsBinded_SelectionChanged(sender As Object, e As cSegmentsGrid.cSelectionChangedEventArgs) Handles grdSegmentsBinded.SelectionChanged
        If e.SelectedItem Is Nothing Then
            btnPropObjectsSelect.Enabled = False
        Else
            btnPropObjectsSelect.Enabled = True
        End If
    End Sub

    Private Sub btnPropObjectsSelect_Click(sender As Object, e As EventArgs) Handles btnPropObjectsSelect.Click
        If grdSegmentsBinded.SelectedItem IsNot Nothing Then
            Call DoCommand("selectshot", grdSegmentsBinded.SelectedItem)
        End If
    End Sub
End Class
