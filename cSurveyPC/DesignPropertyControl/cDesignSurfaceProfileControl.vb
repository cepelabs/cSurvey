Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design

Public Class cDesignSurfaceProfileControl

    Public Shadows Sub Rebind(Design As cIDesign, Options As cOptions)
        Call MyBase.Rebind(Design, Options)

        If MyBase.Design.Type = cIDesign.cDesignTypeEnum.Profile Then
            If MyBase.Design.Survey.Properties.GPS.Enabled AndAlso MyBase.Design.Survey.Properties.SurfaceProfile Then
                MyBase.Visible = True
                chkDesignSurfaceProfile.Checked = MyBase.Options.DrawSurfaceProfile
            Else
                MyBase.Visible = False
            End If
        Else
            MyBase.Visible = False
        End If
    End Sub

    Private Sub chkDesignSurfaceProfile_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignSurfaceProfile.CheckedChanged
        If Not DisabledObjectProperty() Then
            MyBase.Options.DrawSurfaceProfile = chkDesignSurfaceProfile.Checked
            Call MyBase.PropertyChanged("DrawSurfaceProfile")
            Call MyBase.DrawInvalidate()
        End If
    End Sub
End Class
