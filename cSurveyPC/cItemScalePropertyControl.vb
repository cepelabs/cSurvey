Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Friend Class cItemScalePropertyControl
    Private oItem As cItemScale

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Overrides Sub Rebind(Item As cItem)
        oItem = Item

        txtScaleMeters.Value = oItem.Length
        txtScaleSteps.Value = oItem.Steps
        txtScaleStep.Value = oItem.StepLength
        chkHideScaleValue.Checked = oItem.HideScaleValue
    End Sub

    Private Sub txtScaleMeters_ValueChanged(sender As Object, e As EventArgs) Handles txtScaleMeters.ValueChanged
        Try
            If Not DisabledObjectProperty() Then
                oItem.Length = txtScaleMeters.Value
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("meters")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub txtScaleSteps_ValueChanged(sender As Object, e As EventArgs) Handles txtScaleSteps.ValueChanged
        Try
            If Not DisabledObjectProperty() Then
                oItem.Steps = txtScaleSteps.Value
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("steps")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub txtScaleStep_ValueChanged(sender As Object, e As EventArgs) Handles txtScaleStep.ValueChanged
        Try
            If Not DisabledObjectProperty() Then
                oItem.StepLength = txtScaleStep.Value
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("step")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub chkHideScaleValue_CheckedChanged(sender As Object, e As EventArgs) Handles chkHideScaleValue.CheckedChanged
        Try
            If Not DisabledObjectProperty() Then
                oItem.HideScaleValue = chkHideScaleValue.Checked
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("hidescalevalue")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub cmdScaleColorBrowse_Click(sender As Object, e As EventArgs) Handles cmdScaleColorBrowse.Click
        Using oCD As ColorDialog = New ColorDialog
            oCD.FullOpen = True
            oCD.AnyColor = True
            oCD.Color = picScaleColor.BackColor
            If oCD.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                picScaleColor.BackColor = oCD.Color
                'oItem.Color = oCD.Color
                'Call MyBase.PropertyChanged("color")
                'Call MyBase.MapInvalidate()
            End If
        End Using
    End Sub
End Class
