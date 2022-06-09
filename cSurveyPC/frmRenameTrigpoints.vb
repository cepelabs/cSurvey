Imports cSurveyPC.cSurvey

Friend Class frmRenameTrigpoints
    Private oSurvey As cSurvey.cSurvey

    Private Function pValidate() As Boolean
        Dim bCancel As Boolean
        Dim sNew As String = txtNew.Text.ToUpper
        If sNew = "" Then
            bCancel = True
            Call cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("renametrigpoints.warning2"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("renametrigpoints.warningtitle"))
        Else
            bCancel = cboOld.ContainsValue(sNew)
            If bCancel Then
                Call cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("renametrigpoints.warning1"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("renametrigpoints.warningtitle"))
            End If
        End If
        Return bCancel
    End Function

    Private Sub txtNew_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNew.Validating
        'e.Cancel = pValidate()
        'txtNew.EditValue = txtNew.EditValue.trim
    End Sub

    Public Sub New(ByVal Survey As cSurvey.cSurvey, Optional Trigpoint As String = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        Dim sTrigpoint As String = "" & Trigpoint
        Call cboOld.Rebind(Survey, sTrigpoint, True, True)
        If sTrigpoint <> "" Then
            AddHandler Me.Shown, Sub(sender As Object, e As EventArgs)
                                     Call txtNew.Focus()
                                 End Sub
        End If
    End Sub

    Private Sub cboOld_Popup(sender As Object, e As cTrigpointDropDown.PopupEventArgs) Handles cboOld.Popup
        Call e.AddRange(oSurvey.Segments.GetTrigPoints.ToList)
    End Sub

    Private Sub cboOld_EditValueChanged(sender As Object, e As EventArgs) Handles cboOld.EditValueChanged
        cmdOk.Enabled = "" & cboOld.EditValue <> ""
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        If pValidate() Then
            DialogResult = DialogResult.None
        End If
    End Sub
End Class