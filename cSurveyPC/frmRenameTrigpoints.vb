Imports cSurveyPC.cSurvey

Public Class frmRenameTrigpoints
    Private oSurvey As cSurvey.cSurvey
    Private oTrigPoints As SortedSet(Of String)

    Private Sub txtNew_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNew.Validating
        Dim sNew As String = txtNew.Text.ToUpper
        e.Cancel = oTrigPoints.Contains(sNew)
        If e.Cancel Then
            Call MsgBox(GetLocalizedString("renametrigpoints.warning1"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("renametrigpoints.warningtitle"))
        End If
    End Sub

    Public Sub New(ByVal Survey As cSurvey.cSurvey)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        oTrigPoints = oSurvey.Segments.GetTrigPointsNames()
        Call cboOld.Items.AddRange(oTrigPoints.ToArray)
    End Sub
End Class