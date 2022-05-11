Imports cSurveyPC.cSurvey.Design

Public Class cDesignLinkedSurveySelectorPropertyControl

    Public Overloads ReadOnly Property Options As cIOptionLinkedSurveys
        Get
            Return MyBase.Options
        End Get
    End Property

    Public Overrides Sub Rebind(Design As cIDesign, Options As cOptions)
        MyBase.Rebind(Design, Options)

        chkDesignDrawLinkedSurveys.Checked = Me.Options.DrawLinkedSurveys
        linkedSurveys.Enabled = chkDesignDrawLinkedSurveys.Checked

        Dim sDesignType As String = ""
        Select Case Design.Type
            Case cIDesign.cDesignTypeEnum.Plan
                sDesignType = "plan"
            Case cIDesign.cDesignTypeEnum.Profile
                sDesignType = "profile"
            Case cIDesign.cDesignTypeEnum.ThreeDModel
                sDesignType = "3d"
        End Select
        Call linkedSurveys.Rebind(MyBase.Design.Survey.LinkedSurveys, "design." & sDesignType)

        Visible = MyBase.Design.Survey.LinkedSurveys.Count > 0
    End Sub

    Private Sub chkDesignDrawLinkedSurveys_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignDrawLinkedSurveys.CheckedChanged
        If Not DisabledObjectProperty() Then
            Me.Options.DrawLinkedSurveys = chkDesignDrawLinkedSurveys.Checked
            linkedSurveys.Enabled = chkDesignDrawLinkedSurveys.Checked
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("DrawLinkedSurveys")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub linkedSurveys_OnItemCheck(Sender As Object, e As cLinkedSurveySelectorControl.cItemCheckEventArgs) Handles linkedSurveys.OnItemCheck
        If Not DisabledObjectProperty() Then
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("DrawLinkedSurveys")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cmdDesignLinkedSurveys_Click(sender As Object, e As EventArgs) Handles cmdDesignLinkedSurveys.Click
        Call MyBase.DoCommand("linkedsurveys")
    End Sub
End Class
