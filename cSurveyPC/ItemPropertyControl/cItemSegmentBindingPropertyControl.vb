Imports System.ComponentModel
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraTreeList

Friend Class cItemSegmentBindingPropertyControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() 
        Enabled = False
    End Sub

    Public Shadows Sub Rebind(Item As cItem)
        MyBase.Rebind(Item)
        If Item.Survey.MasterSlave.IsLocked(Item) Then
            cmdPropSegmentsLock.Enabled = False
            cmdPropSegmentsUnlock.Enabled = False
            cmdPropSegmentsRebind.Enabled = False
        Else
            cmdPropSegmentsLock.Enabled = True
            cmdPropSegmentsUnlock.Enabled = True
            cmdPropSegmentsRebind.Enabled = True
        End If
        Enabled = IsAvailable
        Call pRefresh()
    End Sub

    Public ReadOnly Property IsAvailable()
        Get
            If Item Is Nothing Then
                Return False
            Else
                Return (Item.Cave <> "")
            End If
        End Get
    End Property

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
        grdSegmentsBinded.Rebind(Item.Survey, oSegments.Values.Cast(Of cISegment).ToList, New cSegmentsGrid.cSegmentGridParameters(False, True, True, True))
    End Sub

    Public Sub DoSegmentsLock()
        Call pSegmentsLock()
    End Sub

    Public Sub DoSegmentsRebind()
        Call pSegmentsRebind()
    End Sub

    Public Sub DoSegmentsUnlock()
        Call pSegmentsUnlock()
    End Sub

    Private Sub cmdPropSegmentsRebind_Click(sender As Object, e As EventArgs) Handles cmdPropSegmentsRebind.Click
        Call pSegmentsRebind()
    End Sub

    Private Sub cmdPropSegmentsUnlock_Click(sender As Object, e As EventArgs) Handles cmdPropSegmentsUnlock.Click
        Call pSegmentsUnlock()
    End Sub

    Private Sub pSegmentsUnlock()
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot("Segments unlock")
            Item.UnlockSegments()
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub pSegmentsRebind()
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot("Segments rebind")
            Call Item.BindSegments()
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub pSegmentsLock()
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot("Segments lock")
            Item.LockSegments()
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cmdPropSegmentsLock_Click(sender As Object, e As EventArgs) Handles cmdPropSegmentsLock.Click
        Call pSegmentsLock
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
End Class
