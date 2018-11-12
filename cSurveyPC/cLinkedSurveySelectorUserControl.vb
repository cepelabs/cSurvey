Imports cSurveyPC.cSurvey

Public Class cLinkedSurveySelectorControl
    Private sContext As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call pSetupLinkedSurveys()
    End Sub

    Public Sub Rebind(LinkedSurveys As cLinkedSurveys, Context As String)
        If Not IsNothing(tvLinkedSurveys.Objects) Then
            Dim oLinkedSurveys As cLinkedSurveys = tvLinkedSurveys.Objects
            RemoveHandler oLinkedSurveys.Survey.OnLinkedSurveysRefresh, AddressOf oSurvey_OnLinkedSurveysRefresh
        End If

        sContext = Context
        Call tvLinkedSurveys.BeginUpdate()
        tvLinkedSurveys.VirtualMode = False
        tvLinkedSurveys.SetObjects(LinkedSurveys)
        Call tvLinkedSurveys.BuildList(True)
        Call tvLinkedSurveys.EndUpdate()

        AddHandler LinkedSurveys.Survey.OnLinkedSurveysRefresh, AddressOf oSurvey_OnLinkedSurveysRefresh
    End Sub

    Private Sub oSurvey_OnLinkedSurveysRefresh(Sender As Object, e As EventArgs)
        Call tvLinkedSurveys.BeginUpdate()
        Call tvLinkedSurveys.BuildList(True)
        Call tvLinkedSurveys.EndUpdate()
    End Sub

    Private Sub pSetupLinkedSurveys()
        tvLinkedSurveys.BooleanCheckStateGetter = Function(Value As Object)
                                                      Return DirectCast(Value, cLinkedSurvey).GetSelected(sContext)
                                                  End Function
        tvLinkedSurveys.BooleanCheckStatePutter = Function(rowObject As Object, newValue As Boolean)
                                                      Call DirectCast(rowObject, cLinkedSurvey).SetSelected(sContext, newValue)
                                                  End Function
        colLinkedSurveysIcon.ImageGetter = Function(Value As Object)
                                               Return If(DirectCast(Value, cLinkedSurvey).IsValid, My.Resources.page_white_link, My.Resources.link_break)
                                           End Function
        colLinkedSurveysGPS.ImageGetter = Function(Value As Object)
                                              Return If(DirectCast(Value, cLinkedSurvey).IsGeoreferenced, My.Resources.map, My.Resources._error)
                                          End Function
        colLinkedSurveysName.AspectGetter = Function(Value As Object)
                                                Return DirectCast(Value, cLinkedSurvey).GetName
                                            End Function
        colLinkedSurveysFilename.AspectGetter = Function(Value As Object)
                                                    Return DirectCast(Value, cLinkedSurvey).GetFilename
                                                End Function

        Call tvLinkedSurveys.RebuildColumns()
    End Sub

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

    Private Sub tvLinkedSurveys_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles tvLinkedSurveys.ItemCheck
        'here put an event to validate check...
        Dim oArgs As cItemCheckEventArgs = New cItemCheckEventArgs(tvLinkedSurveys.GetModelObject(e.Index), e.NewValue)
        RaiseEvent OnItemCheck(sender, oArgs)
        If oArgs.Cancel Then
            e.NewValue = e.CurrentValue
        End If
    End Sub

    Private Sub mnuContextSelectAll_Click(sender As Object, e As EventArgs) Handles mnuContextSelectAll.Click
        Call tvLinkedSurveys.CheckAll()
    End Sub

    Private Sub mnuContextDeselectAll_Click(sender As Object, e As EventArgs) Handles mnuContextDeselectAll.Click
        Call tvLinkedSurveys.UncheckAll()
    End Sub

    Private Sub mnuContextRefresh_Click(sender As Object, e As EventArgs) Handles mnuContextRefresh.Click
        Call tvLinkedSurveys.BuildList()
    End Sub
End Class
