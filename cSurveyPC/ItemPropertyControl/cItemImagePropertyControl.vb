Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Friend Class cItemImagePropertyControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() 

    End Sub

    Public Shadows ReadOnly Property Item As cItemImage
        Get
            Return MyBase.Item
        End Get
    End Property

    Public Shadows Sub Rebind(Item As cItemImage)
        MyBase.Rebind(Item)

        picPropImage.Image = Me.Item.Image
        Call pRefreshImageInfo()
        cboPropImageResizeMode.SelectedIndex = Me.Item.ImageResizeMode
        txtPropImageRotateAngle.EditValue = Me.Item.RotateBy
    End Sub

    Private Sub pRefreshImageInfo()
        txtPropImageResolution.Text = Me.Item.ImageSize.Width & "x" & Me.Item.ImageSize.Height & "px " & Me.Item.ImageResolution.X & "x" & Me.Item.ImageResolution.Y & " dpi"
    End Sub

    Public Sub Edit()
        If Not DisabledObjectProperty() Then
            Using frmSB As frmImageEdit = New frmImageEdit(Item)
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo42"))
                If frmSB.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    picPropImage.Image = Me.Item.Image
                    Call pRefreshImageInfo()
                    Call MyBase.CommitUndoSnapshot()
                    Call MyBase.PropertyChanged("Image")
                    Call MyBase.MapInvalidate()
                Else
                    Call MyBase.CancelUndoSnapshot()
                End If
            End Using
        End If
    End Sub

    Private Sub cmdPropSketchEdit_Click(sender As Object, e As EventArgs) Handles cmdPropImageEdit.Click
        Call Edit()
    End Sub

    Private Sub cmdPropSketchView_Click(sender As Object, e As EventArgs) Handles cmdPropImageView.Click
        Call MyBase.DoCommand("imageviewer", Item)
    End Sub

    Private Sub cboPropImageResizeMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPropImageResizeMode.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo42"), "ImageResizeMode")
            Me.Item.ImageResizeMode = cboPropImageResizeMode.SelectedIndex
            Call MyBase.PropertyChanged("ImageResizeMode")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub pItemImageRealSize(ByVal Scale As Integer)
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo42"))
            Dim oSize As SizeF = Me.Item.ImageSize
            Dim oRes As PointF = Me.Item.ImageResolution
            oSize.Width = (oSize.Width / oRes.X) * 0.0254F * Scale
            oSize.Height = (oSize.Height / oRes.Y) * 0.0254F * Scale
            Call Me.Item.ResizeTo(oSize)
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("ImageScaleToRealSize")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cmdPropImageScale100_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPropImageScale100.Click
        Call pItemImageRealSize(100)
    End Sub

    Private Sub cmdPropImageScale250_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPropImageScale250.Click
        Call pItemImageRealSize(250)
    End Sub

    Private Sub cmdPropImageScale500_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPropImageScale500.Click
        Call pItemImageRealSize(500)
    End Sub

    Private Sub txtPropImageScaleFree_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropImageScaleFree.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call pItemImageRealSize(txtPropImageScaleFree.EditValue)
        End If
    End Sub

    Private Sub txtPropImageRotateAngle_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropImageRotateAngle.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo42"), "RotateBy")
            Me.Item.RotateBy = txtPropImageRotateAngle.EditValue
            Call MyBase.PropertyChanged("ImageRotateAngle")
            Call MyBase.MapInvalidate()
        End If
    End Sub
End Class
