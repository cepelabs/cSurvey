Imports cSurveyPC.cSurvey.Design

Friend Class cDesign3DElevationFactor

    Public Shadows ReadOnly Property Options As cOptions3D
        Get
            Return MyBase.Options
        End Get
    End Property

    Public Shadows Sub Rebind(Design As cIDesign, Options As cOptions)
        Call MyBase.Rebind(Design, Options)

        trk3DSurfaceElevationAmp.Value = Me.Options.SurfaceOptions.Elevation.AltitudeAmplification * 10.0F
    End Sub

    Private Sub trk3DSurfaceElevationAmp_EditValueChanged(sender As Object, e As EventArgs) Handles trk3DSurfaceElevationAmp.EditValueChanged
        If Not DisabledObjectProperty() Then
            Me.Options.SurfaceOptions.Elevation.AltitudeAmplification = trk3DSurfaceElevationAmp.Value / 10.0F
            Call MyBase.PropertyChanged("3DAltitudeAmplification")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.All))
        End If
    End Sub
End Class
