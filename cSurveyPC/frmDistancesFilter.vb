Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.UIHelpers

Friend Class frmDistancesFilter

    Private oSurvey As cSurveyPC.cSurvey.cSurvey
    Private oTrigpoints As List(Of cTrigPoint)
    Public Sub New(Survey As cSurveyPC.cSurvey.cSurvey, Trigpoints As List(Of cTrigPoint), Splay As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        oTrigpoints = Trigpoints

        Call pRefreshSurveyList()
    End Sub
    Private Sub cboSurveyInfoFilename_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSurveyInfoFilename.SelectedIndexChanged
        Call pUpdateTrigpoints()
        Dim oSurveyItem As cSurveyPlaceholder = cboSurveyInfoFilename.SelectedItem
        Dim oSourceSurvey As cSurvey.cSurvey = If(oSurveyItem.IsLinked, oSurveyItem.LinkedSurvey.LinkedSurvey, oSurvey)
        Dim oTrigpointsBySurvey As List(Of cTrigPoint) = oTrigpoints.Where(Function(oTrigpoint)
                                                                               If oSurveyItem.IsLinked Then
                                                                                   Return oTrigpoint.Survey Is oSurveyItem.LinkedSurvey.LinkedSurvey
                                                                               Else
                                                                                   Return oTrigpoint.Survey Is oSurvey
                                                                               End If
                                                                           End Function).ToList
        tmsFilters.Rebind(oSourceSurvey, oTrigpointsBySurvey, Splay)
    End Sub
    Private Sub pRefreshSurveyList()
        Call cboSurveyInfoFilename.Properties.Items.Clear()
        cboSurveyInfoFilename.Properties.Items.Add(New cSurveyPlaceholder(oSurvey))
        For Each oLinkedSurvey As cLinkedSurvey In oSurvey.LinkedSurveys.GetUsable
            Call cboSurveyInfoFilename.Properties.Items.Add(New cSurveyPlaceholder(oLinkedSurvey))
        Next
        cboSurveyInfoFilename.SelectedIndex = 0
    End Sub

    Private Sub pUpdateTrigpoints()
        If tmsFilters.Survey IsNot Nothing Then
            oTrigpoints.RemoveAll(Function(oTrigpoint)
                                      Return oTrigpoint.Survey Is tmsFilters.Survey
                                  End Function)
            oTrigpoints.AddRange(tmsFilters.Trigpoints)
        End If
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Call pUpdateTrigpoints()
    End Sub

    Public ReadOnly Property Splay As Boolean
        Get
            Return tmsFilters.Splay
        End Get
    End Property
    Public ReadOnly Property Trigpoints As List(Of cTrigPoint)
        Get
            Return oTrigpoints
        End Get
    End Property
End Class