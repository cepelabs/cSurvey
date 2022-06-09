Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design

Public Class cDesignStyleControl

    Public Shadows ReadOnly Property Options As cOptionsDesign
        Get
            Return MyBase.Options
        End Get
    End Property

    Public Shadows Sub Rebind(Design As cIDesign, Options As cOptions)
        MyBase.Rebind(Design, Options)

        chkDesignStyle0.Checked = Me.Options.DesignStyle = cOptionsDesign.DesignStyleEnum.Design
        chkDesignStyle1.Checked = Me.Options.DesignStyle = cOptionsDesign.DesignStyleEnum.Areas
        chkDesignStyle2.Checked = Me.Options.DesignStyle = cOptionsDesign.DesignStyleEnum.Combined

        pnlDesignCombineColorMode.Enabled = (Me.Options.DesignStyle = cOptionsDesign.DesignStyleEnum.Areas Or Me.Options.DesignStyle = cOptionsDesign.DesignStyleEnum.Combined)
        cboDesignCombineColorMode.SelectedIndex = Me.Options.CombineColorMode
        chkDesignCombineColorGray.Checked = Me.Options.CombineColorGray

        chkDesignUnselectedLevelDrawingMode0.Checked = Me.Options.UnselectedLevelDrawingMode = cOptionsDesign.UnselectedLevelDrawingModeEnum.Wireframe
        chkDesignUnselectedLevelDrawingMode1.Checked = Me.Options.UnselectedLevelDrawingMode = cOptionsDesign.UnselectedLevelDrawingModeEnum.OnlyCaveBorders
        chkDesignUnselectedLevelDrawingMode2.Checked = Me.Options.UnselectedLevelDrawingMode = cOptionsDesign.UnselectedLevelDrawingModeEnum.None
    End Sub

    Private Sub chkDesignStyle0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDesignStyle0.CheckedChanged
        If Not DisabledObjectProperty() Then
            If Me.Options.DesignStyle <> cOptionsDesign.DesignStyleEnum.Design And chkDesignStyle0.Checked Then
                Me.Options.DesignStyle = cOptionsDesign.DesignStyleEnum.Design
                pnlDesignCombineColorMode.Enabled = False
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub chkDesignStyle1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDesignStyle1.CheckedChanged
        If Not DisabledObjectProperty() Then
            If Me.Options.DesignStyle <> cOptionsDesign.DesignStyleEnum.Areas And chkDesignStyle1.Checked Then
                Me.Options.DesignStyle = cOptionsDesign.DesignStyleEnum.Areas
                pnlDesignCombineColorMode.Enabled = True
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub chkDesignStyle2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDesignStyle2.CheckedChanged
        If Not DisabledObjectProperty() Then
            If Me.Options.DesignStyle <> cOptionsDesign.DesignStyleEnum.Combined And chkDesignStyle2.Checked Then
                Me.Options.DesignStyle = cOptionsDesign.DesignStyleEnum.Combined
                pnlDesignCombineColorMode.Enabled = True
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub cboDesignCombineColorMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDesignCombineColorMode.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Me.Options.CombineColorMode = cboDesignCombineColorMode.SelectedIndex
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    Private Sub chkDesignCombineColorGray_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignCombineColorGray.CheckedChanged
        If Not DisabledObjectProperty() Then
            Me.Options.CombineColorGray = chkDesignCombineColorGray.Checked
            Call MyBase.DrawInvalidate()
        End If
    End Sub


    Private Sub chkDesignUnselectedLevelDrawingMode0_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDesignUnselectedLevelDrawingMode0.CheckedChanged
        If Not DisabledObjectProperty() Then
            If Me.Options.UnselectedLevelDrawingMode <> cOptionsDesign.UnselectedLevelDrawingModeEnum.Wireframe And chkDesignUnselectedLevelDrawingMode0.Checked Then
                Me.Options.UnselectedLevelDrawingMode = cOptionsDesign.UnselectedLevelDrawingModeEnum.Wireframe
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub chkDesignUnselectedLevelDrawingMode1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDesignUnselectedLevelDrawingMode1.CheckedChanged
        If Not DisabledObjectProperty() Then
            If Me.Options.UnselectedLevelDrawingMode <> cOptionsDesign.UnselectedLevelDrawingModeEnum.OnlyCaveBorders And chkDesignUnselectedLevelDrawingMode1.Checked Then
                Me.Options.UnselectedLevelDrawingMode = cOptionsDesign.UnselectedLevelDrawingModeEnum.OnlyCaveBorders
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub chkDesignUnselectedLevelDrawingMode2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDesignUnselectedLevelDrawingMode2.CheckedChanged
        If Not DisabledObjectProperty() Then
            If Me.Options.UnselectedLevelDrawingMode <> cOptionsDesign.UnselectedLevelDrawingModeEnum.None And chkDesignUnselectedLevelDrawingMode2.Checked Then
                Me.Options.UnselectedLevelDrawingMode = cOptionsDesign.UnselectedLevelDrawingModeEnum.None
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub
End Class
