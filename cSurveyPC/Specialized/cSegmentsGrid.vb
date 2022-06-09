Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Helper.Editor
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class cSegmentsGrid
    Private oSurvey As cSurvey.cSurvey

    Public Class cSegmentGridParameters
        Private bShowSessions As Boolean
        Private bShowCaveBranch As Boolean
        Private bShowCaveBranchColor As Boolean

        Private bBestFitColumns As Boolean

        Public Property ShowSessions As Boolean
            Get
                Return bShowSessions
            End Get
            Set(value As Boolean)
                bShowSessions = value
            End Set
        End Property

        Public Property ShowCaveBranch As Boolean
            Get
                Return bShowCaveBranch
            End Get
            Set(value As Boolean)
                bShowCaveBranch = value
            End Set
        End Property

        Public Property ShowCaveBranchColor As Boolean
            Get
                Return bShowCaveBranchColor
            End Get
            Set(value As Boolean)
                bShowCaveBranchColor = value
            End Set
        End Property

        Public Property BestFitColumns As Boolean
            Get
                Return bBestFitColumns
            End Get
            Set(value As Boolean)
                bBestFitColumns = value
            End Set
        End Property

        Public Sub New(ShowSessions As Boolean, ShowCaveBranch As Boolean, ShowCaveBranchColor As Boolean, Optional BestFitColumns As Boolean = False)
            bShowSessions = ShowSessions
            bShowCaveBranch = ShowCaveBranch
            bShowCaveBranchColor = ShowCaveBranchColor
            bBestFitColumns = BestFitColumns
        End Sub
    End Class

    Public Sub Unbind()
        oSurvey = Nothing
        Call grdSegments.BeginUpdate()
        grdSegments.DataSource = Nothing
        Call grdSegments.EndUpdate()
    End Sub

    Public Sub RefreshDataSource()
        Call grdSegments.RefreshDataSource()
    End Sub

    Public Sub BeginUpdate()
        Call grdSegments.BeginUpdate()
    End Sub

    Public Sub EndUpdate()
        Call grdSegments.EndUpdate()
    End Sub

    Public Sub Rebind(Survey As cSurvey.cSurvey, Segments As IList(Of cSegment), Parameters As cSegmentGridParameters)
        oSurvey = Survey
        Call grdSegments.BeginUpdate()
        grdSegments.DataSource = Segments

        colSegmentsSession.Visible = Parameters.ShowSessions
        colSegmentsSessionColor.Visible = Parameters.ShowSessions

        colSegmentsBranchCave.Visible = Parameters.ShowCaveBranch
        colSegmentsBranchBranch.Visible = Parameters.ShowCaveBranch
        colSegmentsBranchCaveColor.Visible = Parameters.ShowCaveBranchColor
        colSegmentsBranchBranchColor.Visible = Parameters.ShowCaveBranchColor

        If Parameters.BestFitColumns Then grdViewSegments.BestFitColumns()

        Call grdSegments.EndUpdate()
    End Sub

    Public ReadOnly Property Count As Integer
        Get
            Return grdViewSegments.RowCount
        End Get
    End Property

    Private Sub grdViewSegments_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles grdViewSegments.RowCellStyle
        Dim oSegment As cSegment = grdViewSegments.GetRow(e.RowHandle)
        If Not oSegment Is Nothing Then
            If e.Column Is colSegmentsBranchBranchColor Then
                e.Appearance.BackColor = oSurvey.Properties.CaveInfos.GetColor(oSegment.Cave, oSegment.Branch, System.Drawing.Color.LightGray)
            ElseIf e.Column Is colSegmentsBranchCaveColor Then
                e.Appearance.BackColor = oSurvey.Properties.CaveInfos.GetColor(oSegment.Cave, "", System.Drawing.Color.LightGray)
            ElseIf e.Column Is colSegmentsSessionColor Then
                e.Appearance.BackColor = oSurvey.Properties.Sessions.GetColor(oSegment.Session, System.Drawing.Color.LightGray)
            ElseIf e.Column Is colSegmentsTo Then
                If oSegment.To Like "*(*)" Then
                    If cEditDesignEnvironment.GetSetting("isdarkskin") Then
                        e.Appearance.ForeColor = modPaint.LightColor(cEditDesignEnvironment.GetSetting("backcolor"), 0.25)
                    Else
                        e.Appearance.ForeColor = modPaint.DarkColor(cEditDesignEnvironment.GetSetting("backcolor"), 0.25)
                    End If
                End If
            ElseIf e.Column Is colSegmentsFrom Then
                If oSegment.From Like "*(*)" Then
                    If cEditDesignEnvironment.GetSetting("isdarkskin") Then
                        e.Appearance.ForeColor = modPaint.LightColor(cEditDesignEnvironment.GetSetting("backcolor"), 0.25)
                    Else
                        e.Appearance.ForeColor = modPaint.DarkColor(cEditDesignEnvironment.GetSetting("backcolor"), 0.25)
                    End If
                End If
            End If
        End If
    End Sub

    Public ReadOnly Property SelectedItem As cSegment
        Get
            Return grdViewSegments.GetFocusedObject
        End Get
    End Property

    Public Class cSelectionChangedEventArgs
        Inherits EventArgs

        Private oSelectedItem As cSegment

        Public Sub New(SelectedItem As cSegment)
            oSelectedItem = SelectedItem
        End Sub

        Public ReadOnly Property SelectedItem As cSegment
            Get
                Return oSelectedItem
            End Get
        End Property
    End Class

    Public Event SelectionChanged(sender As Object, e As cselectionchangedeventargs)

    Private Sub grdViewSegments_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles grdViewSegments.FocusedRowChanged
        RaiseEvent SelectionChanged(Me, New cSelectionChangedEventArgs(grdViewSegments.GetFocusedObject))
    End Sub

    Public Event ContextMenuShowing(sender As Object, e As MouseEventArgs)

    Private Sub grdViewSegments_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles grdViewSegments.PopupMenuShowing
        If e.HitInfo.InRowCell OrElse e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.EmptyRow Then
            e.Allow = False
            Dim oScreenPoint As Point = grdSegments.PointToScreen(e.Point)
            RaiseEvent ContextMenuShowing(sender, New MouseEventArgs(MouseButtons.Right, 1, oScreenPoint.X, oScreenPoint.Y, 0))
        End If
    End Sub

    Public Event DoubleClick As EventHandler

    Private Sub grdViewSegments_DoubleClick(sender As Object, e As EventArgs) Handles grdViewSegments.DoubleClick
        RaiseEvent DoubleClick(Me, e)
    End Sub
End Class
