Public Class frmSurveyCleanUp

    Private Sub frmSurveyCleanUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboDesignContext.SelectedIndex = 0
    End Sub

    Private Sub chkPointReduction_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPointReduction.CheckedChanged
        txtDesignPointReductionFactor.Enabled = chkDesignPointReduction.Checked
    End Sub
End Class