Imports System.ComponentModel
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Helper.Editor
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors.Events

Friend Class cDockJoinPoints

    Private oSurvey As cSurvey.cSurvey
    Private oTool As cEditDesignTools

    Public Class cPointEventArgs
        Inherits EventArgs

        Private oPoint As cPoint

        Public ReadOnly Property Point As cPoint
            Get
                Return oPoint
            End Get
        End Property

        Public Sub New(Point As cPoint)
            opoint = Point
        End Sub
    End Class

    Friend Event OnPointClear(Sender As Object, e As EventArgs)
    Friend Event OnPointRemoved(Sender As Object, e As cPointEventArgs)
    Friend Event OnPointLink(Sender As Object, e As EventArgs)
    Friend Event OnPointSelect(Sender As Object, e As cPointEventArgs)

    Private oPoints As BindingList(Of cPoint) = New BindingList(Of cPoint)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        tvPoints.DataSource = oPoints

        Call pRefreshButtons()
    End Sub

    Friend Function IsPointInList(Point As cPoint) As Boolean
        Return oPoints.Contains(Point)
    End Function

    Friend Sub SelectPoint()
        If oPoints.Count > 0 Then
            Dim oPoint As cPoint = tvPoints.GetFocusedObject
            RaiseEvent OnPointSelect(Me, New cPointEventArgs(oPoint))
        End If
    End Sub

    Friend Function GetPointsCount()
        Return oPoints.Count
    End Function

    Friend Sub JoinPoints()
        Call btnLink.PerformClick()
    End Sub

    Friend Sub AppendPoint()
        If Not oTool.CurrentItemPoint Is Nothing Then
            Dim oPoint As cPoint = oTool.CurrentItemPoint
            If Not IsPointInList(oPoint) Then
                Call oPoints.Add(oPoint)
                Call tvPoints.RefreshDataSource()
                Call tvPoints.SetFocusedObject(oPoint)
            End If
        End If
        Call pRefreshButtons()
    End Sub

    Private Sub pRefreshButtons()
        Dim bEnabled As Boolean = oPoints.Count > 0
        tvPoints.Enabled = bEnabled
        btnCancel.Enabled = bEnabled

        bEnabled = Not tvPoints.GetFocusedObject Is Nothing
        btnSelect.Enabled = bEnabled

        bEnabled = oPoints.Count > 1 AndAlso bEnabled
        btnLink.Enabled = bEnabled
        btnRemove.Enabled = bEnabled
    End Sub

    Friend Sub SetSurvey(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Tool As cEditDesignTools)
        Call oPoints.Clear()
        oSurvey = Survey
        oTool = Tool

        Dim bEnabled As Boolean = oSurvey IsNot Nothing And oTool IsNot Nothing
        tvPoints.Enabled = False
    End Sub

    Private Sub btnRemove_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnRemove.ItemClick
        Dim oPoint As cPoint = tvPoints.GetFocusedObject
        If Not oPoint Is Nothing Then
            oPoints.Remove(oPoint)
            RaiseEvent OnPointRemoved(Me, New cPointEventArgs(oPoint))
        End If
        Call pRefreshButtons()
    End Sub

    Private Sub btnLink_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnLink.ItemClick
        Dim oPoint As cPoint = tvPoints.GetFocusedObject
        If Not oPoint Is Nothing AndAlso oPoints.Count > 1 Then
            For Each oOtherPoint As cPoint In oPoints.ToList
                If Not oOtherPoint Is oPoint Then
                    Call oPoint.Join(oOtherPoint)
                End If
            Next
            Call oPoints.Clear()
            RaiseEvent OnPointLink(Me, EventArgs.Empty)
        End If
    End Sub

    Private Sub btnCancel_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCancel.ItemClick
        Call oPoints.Clear()
        RaiseEvent OnPointClear(Me, EventArgs.Empty)
    End Sub

    Private Sub tvPoints_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles tvPoints.FocusedNodeChanged
        Call pRefreshButtons()
    End Sub

    Private Sub tvPoints_PopupMenuShowing(sender As Object, e As DevExpress.XtraTreeList.PopupMenuShowingEventArgs) Handles tvPoints.PopupMenuShowing
        If e.HitInfo.InRowCell Then
            e.Allow = False
            Call mnuContext.ShowPopup(tvPoints.PointToScreen(e.Point))
        End If
    End Sub

    Private Sub tvPoints_DoubleClick(sender As Object, e As EventArgs) Handles tvPoints.DoubleClick
        Call SelectPoint()
    End Sub

    Private Sub btnSelect_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnSelect.ItemClick
        Call SelectPoint()
    End Sub
End Class