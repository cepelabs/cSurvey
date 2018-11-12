Imports cSurveyPC.cSurvey.Design

Public Class cDesignLinkedSurveySelectorPropertyControl
    Private oDesign As cDesign
    Private oOptions As cIOptionLinkedSurveys

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Overrides Sub Rebind(Design As cIDesign, Options As cOptions)
        oDesign = Design
        oOptions = Options

        chkDesignDrawLinkedSurveys.Checked = oOptions.DrawLinkedSurveys
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
        Call linkedSurveys.Rebind(oDesign.Survey.LinkedSurveys, "design." & sDesignType)
    End Sub

    Private Sub chkDesignDrawLinkedSurveys_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignDrawLinkedSurveys.CheckedChanged
        If Not DisabledObjectProperty() Then
            oOptions.DrawLinkedSurveys = chkDesignDrawLinkedSurveys.Checked
            linkedSurveys.Enabled = chkDesignDrawLinkedSurveys.Checked
            Call MyBase.takeundosnapshot
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
