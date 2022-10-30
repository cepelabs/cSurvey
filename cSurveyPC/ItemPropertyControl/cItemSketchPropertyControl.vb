Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Friend Class cItemSketchPropertyControl

    Public Shadows ReadOnly Property Item As cItemSketch
        Get
            Return MyBase.Item
        End Get
    End Property

    Public Shadows Sub Rebind(Item As cItemSketch)
        MyBase.Rebind(Item)

        picPropSketch.Image = Me.Item.Image
        txtPropSketchResolution.Text = Me.Item.ImageSize.Width & "x" & Me.Item.ImageSize.Height & "px " & Me.Item.ImageResolution.X & "x" & Me.Item.ImageResolution.Y & " dpi"
        chkPropSketchManualAdjust.Checked = Me.Item.ManualAdjust
        chkPropSketchMorphingDisabled.Checked = Me.Item.MorphingDisabled
    End Sub

    Public Sub Edit()
        If Not DisabledObjectProperty() Then
            Using frmSB As frmSketchEdit = New frmSketchEdit(Item)
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo51"))
                If frmSB.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    picPropSketch.Image = Me.Item.Image
                    Call MyBase.CommitUndoSnapshot()
                    Call MyBase.PropertyChanged("Sketch")
                    Call MyBase.MapInvalidate()
                Else
                    Call MyBase.CancelUndoSnapshot()
                End If
            End Using
        End If
    End Sub

    Private Sub cmdPropSketchEdit_Click(sender As Object, e As EventArgs) Handles cmdPropSketchEdit.Click
        Call Edit()
    End Sub

    Private Sub cmdPropSketchView_Click(sender As Object, e As EventArgs) Handles cmdPropSketchView.Click
        Call MyBase.DoCommand("imageviewer", Item)
    End Sub

    Private Sub chkPropSketchManualAdjust_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPropSketchManualAdjust.CheckedChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo51"), "ManualAdjust")
            Me.Item.ManualAdjust = chkPropSketchManualAdjust.Checked
            Call MyBase.PropertyChanged("SketchManualAdjust")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkPropSketchMorphingDisabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPropSketchMorphingDisabled.CheckedChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo51"), "MorphingDisabled")
            Me.Item.MorphingDisabled = chkPropSketchMorphingDisabled.Checked
            Call MyBase.PropertyChanged("SketchMorphingDisabled")
            Call MyBase.MapInvalidate()
        End If
    End Sub
End Class
