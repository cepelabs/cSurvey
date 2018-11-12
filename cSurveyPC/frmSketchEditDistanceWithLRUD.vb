Public Class frmSketchEditDistanceWithLRUD
    Public Sub New(PlanOrProfile As Boolean, Optional Value As Single = 0.1)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If PlanOrProfile Then
            optLeftUp.Text = modMain.GetLocalizedString("sketcheditdistance.up")
            optRightDown.Text = modMain.GetLocalizedString("sketcheditdistance.down")
        Else
            optLeftUp.Text = modMain.GetLocalizedString("sketcheditdistance.left")
            optRightDown.Text = modMain.GetLocalizedString("sketcheditdistance.right")
        End If

        If Value = -1 Then
            optLeftUp.Checked = True
        ElseIf Value = -2 Then
            optRightDown.Checked = True
        Else
            optManual.Checked = True
            txtDistance.Value = Value
        End If
    End Sub

    Public Function GetDistance() As Single
        If optLeftUp.Checked Then
            Return -1
        ElseIf optRightDown.Checked Then
            Return -2
        Else
            Return txtDistance.Value
        End If
    End Function

    Private Sub optManual_CheckedChanged(sender As Object, e As EventArgs) Handles optManual.CheckedChanged
        Dim bEnabled As Boolean = optManual.Checked
        lblDistance.Enabled = bEnabled
        txtDistance.Enabled = bEnabled
        lblDistanceUM.Enabled = bEnabled
    End Sub
End Class