Imports cSurveyPC.cSurvey
Imports DevExpress.XtraBars

Public Class cLinkedSurveySelectorControl
    Private sContext As String

    Private WithEvents oSurvey As cSurvey.cSurvey

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Call pSetupLinkedSurveys()
    End Sub

    Public Sub Rebind(LinkedSurveys As cLinkedSurveys, Context As String)
        If Not IsNothing(tvLinkedSurveys.DataSource) Then
            Dim oLinkedSurveys As cLinkedSurveys = tvLinkedSurveys.DataSource
            RemoveHandler oLinkedSurveys.Survey.OnLinkedSurveysRefresh, AddressOf oSurvey_OnLinkedSurveysRefresh
        End If

        sContext = Context

        oSurvey = LinkedSurveys.Survey

        tvLinkedSurveys.BeginUpdate()
        tvLinkedSurveys.DataSource = New UIHelpers.cLinkedSurveysBindingList(LinkedSurveys)
        tvLinkedSurveys.EndUpdate()

        'Call tvLinkedSurveys.BeginUpdate()
        'tvLinkedSurveys.VirtualMode = False
        'tvLinkedSurveys.SetObjects(LinkedSurveys)
        'Call tvLinkedSurveys.BuildList(True)
        'Call tvLinkedSurveys.EndUpdate()

        AddHandler LinkedSurveys.Survey.OnLinkedSurveysRefresh, AddressOf oSurvey_OnLinkedSurveysRefresh
    End Sub

    'Private Sub pSetupLinkedSurveys()

    '    tvLinkedSurveys.BooleanCheckStateGetter = Function(Value As Object)
    '                                                  Return DirectCast(Value, cLinkedSurvey).GetSelected(sContext)
    '                                              End Function
    '    tvLinkedSurveys.BooleanCheckStatePutter = Function(rowObject As Object, newValue As Boolean)
    '                                                  Call DirectCast(rowObject, cLinkedSurvey).SetSelected(sContext, newValue)
    '                                              End Function
    '    colLinkedSurveysIcon.ImageGetter = Function(Value As Object)
    '                                           Return If(DirectCast(Value, cLinkedSurvey).IsValid, My.Resources.page_white_link, My.Resources.link_break)
    '                                       End Function
    '    colLinkedSurveysGPS.ImageGetter = Function(Value As Object)
    '                                          Return If(DirectCast(Value, cLinkedSurvey).IsGeoreferenced, My.Resources.map, My.Resources.error2)
    '                                      End Function
    '    colLinkedSurveysName.AspectGetter = Function(Value As Object)
    '                                            Return DirectCast(Value, cLinkedSurvey).GetName
    '                                        End Function
    '    colLinkedSurveysFilename.AspectGetter = Function(Value As Object)
    '                                                Return DirectCast(Value, cLinkedSurvey).GetFilename
    '                                            End Function

    '    Call tvLinkedSurveys.RebuildColumns()
    'End Sub

    Public Class cItemCheckEventArgs
        Inherits EventArgs

        Public Property Cancel As Boolean

        Public ReadOnly Property RequestedCheckState As Boolean
        Public ReadOnly Property Item As cLinkedSurvey

        Public Sub New(Item As cLinkedSurvey, RequestedCheckState As Boolean)
            Me.Item = Item
            Me.RequestedCheckState = RequestedCheckState
        End Sub
    End Class

    Public Event OnItemCheck(Sender As Object, e As cItemCheckEventArgs)

    'Private Sub tvLinkedSurveys_ItemCheck(sender As Object, e As ItemCheckEventArgs)
    '    'here put an event to validate check...
    '    Dim oArgs As cItemCheckEventArgs = New cItemCheckEventArgs(tvLinkedSurveys.GetModelObject(e.Index), e.NewValue)
    '    RaiseEvent OnItemCheck(sender, oArgs)
    '    If oArgs.Cancel Then
    '        e.NewValue = e.CurrentValue
    '    End If
    'End Sub

    'Private Sub mnuContextSelectAll_Click(sender As Object, e As EventArgs) Handles mnuContextSelectAll.Click
    '    Call tvLinkedSurveys.CheckAll()
    'End Sub

    'Private Sub mnuContextDeselectAll_Click(sender As Object, e As EventArgs) Handles mnuContextDeselectAll.Click
    '    Call tvLinkedSurveys.UncheckAll()
    'End Sub

    'Private Sub mnuContextRefresh_Click(sender As Object, e As EventArgs) Handles mnuContextRefresh.Click
    '    Call tvLinkedSurveys.BuildList()
    'End Sub

    Private Sub tvLinkedSurveys_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraTreeList.TreeListCustomColumnDataEventArgs) Handles tvLinkedSurveys.CustomUnboundColumnData
        If e.IsGetData Then
            If e.Column Is colLinkSelected Then
                e.Value = DirectCast(e.Row, cLinkedSurvey).GetSelected(sContext)
            ElseIf e.Column Is colLinkName Then
                e.Value = DirectCast(e.Row, cLinkedSurvey).GetName
            ElseIf e.Column Is colLinkFilename Then
                e.Value = DirectCast(e.Row, cLinkedSurvey).GetFilename
            End If
        Else
            If e.Column Is colLinkSelected Then
                Dim oLinkedSurvey As cLinkedSurvey = DirectCast(e.Row, cLinkedSurvey)
                Dim oArgs As cItemCheckEventArgs = New cItemCheckEventArgs(oLinkedSurvey, e.Value)
                RaiseEvent OnItemCheck(sender, oArgs)
                If oArgs.Cancel Then
                    e.Value = oLinkedSurvey.GetSelected(sContext)
                Else
                    Call oLinkedSurvey.SetSelected(sContext, e.Value)
                End If
            End If
        End If
    End Sub

    Private Sub tvLinkedSurveys_PopupMenuShowing(sender As Object, e As DevExpress.XtraTreeList.PopupMenuShowingEventArgs) Handles tvLinkedSurveys.PopupMenuShowing
        If e.HitInfo.InRowCell Then
            e.Allow = False
            Call mnuContext.ShowPopup(tvLinkedSurveys.PointToScreen(e.Point))
        End If
    End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnRefresh.ItemClick
        Call pRefresh
    End Sub

    Private Sub oSurvey_OnLinkedSurveysRefresh(Sender As cSurvey.cSurvey, Args As EventArgs) Handles oSurvey.OnLinkedSurveysRefresh
        Call pRefresh
    End Sub

    Private Sub pRefresh()
        Call tvLinkedSurveys.BeginUpdate()
        Call tvLinkedSurveys.DataSource.refresh
        Call tvLinkedSurveys.EndUpdate()
    End Sub

    Private Sub btnDeselectAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnDeselectAll.ItemClick
        Call tvLinkedSurveys.BeginUpdate()
        For Each oLinkedSurvey As cLinkedSurvey In DirectCast(tvLinkedSurveys.DataSource, UIHelpers.cLinkedSurveysBindingList)
            Call oLinkedSurvey.SetSelected(sContext, False)
        Next
        Call tvLinkedSurveys.EndUpdate()
    End Sub

    Private Sub btnSelectAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnSelectAll.ItemClick
        Call tvLinkedSurveys.BeginUpdate()
        For Each oLinkedSurvey As cLinkedSurvey In DirectCast(tvLinkedSurveys.DataSource, UIHelpers.cLinkedSurveysBindingList)
            Call oLinkedSurvey.SetSelected(sContext, True)
        Next
        Call tvLinkedSurveys.EndUpdate()
    End Sub
End Class
