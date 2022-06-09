Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Friend Class cItemScalePropertyControl
    Public Shadows ReadOnly Property Item As cItemScale
        Get
            Return MyBase.Item
        End Get
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Shadows Sub Rebind(Item As cItemScale)
        Call MyBase.Rebind(Item)

        txtScaleMeters.Value = Me.Item.Length
        txtScaleSteps.Value = Me.Item.Steps
        txtScaleStep.Value = Me.Item.StepLength
        txtScaleScaleHeightFactor.Value = Me.Item.ScaleHeightFactor
        chkHideScaleValue.Checked = Me.Item.HideScaleValue
        cboPropScaleFillStyle.SelectedIndex = Me.Item.ScaleFillStyle
        'txtScaleColor.EditValue = Me.Item.Pen.Color
    End Sub

    Private Sub txtScaleMeters_ValueChanged(sender As Object, e As EventArgs) Handles txtScaleMeters.ValueChanged
        Try
            If Not DisabledObjectProperty() Then
                Item.Length = txtScaleMeters.Value
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
                Item.Steps = txtScaleSteps.Value
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
                Item.StepLength = txtScaleStep.Value
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
                Item.HideScaleValue = chkHideScaleValue.Checked
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("hidescalevalue")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    'Private Sub cmdScaleColorBrowse_Click(sender As Object, e As EventArgs)
    '    Using oCD As ColorDialog = New ColorDialog
    '        oCD.FullOpen = True
    '        oCD.AnyColor = True
    '        oCD.Color = picScaleColor.BackColor
    '        If oCD.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
    '            picScaleColor.BackColor = oCD.Color
    '            'Item.Color = oCD.Color
    '            'Call MyBase.PropertyChanged("color")
    '            'Call MyBase.MapInvalidate()
    '        End If
    '    End Using
    'End Sub

    Private Sub txtScaleScaleHeightFactor_ValueChanged(sender As Object, e As EventArgs) Handles txtScaleScaleHeightFactor.ValueChanged
        Try
            If Not DisabledObjectProperty() Then
                Item.ScaleHeightFactor = txtScaleScaleHeightFactor.Value
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("scaleheightfactor")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub cboPropScaleFillStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropScaleFillStyle.SelectedIndexChanged
        Try
            If Not DisabledObjectProperty() Then
                Item.ScaleFillStyle = cboPropScaleFillStyle.SelectedIndex
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("ScaleFillStyle")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub txtScaleColor_EditValueChanged(sender As Object, e As EventArgs) Handles txtScaleColor.EditValueChanged
        If Not DisabledObjectProperty() Then
            'Item.Pen.Color = txtScaleColor.EditValue
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("ScaleColor")
            Call MyBase.MapInvalidate()
        End If
    End Sub
End Class
