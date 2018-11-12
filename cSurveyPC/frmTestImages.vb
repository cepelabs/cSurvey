Public Class frmTestImages

    Private Sub frmTestImages_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim oGrid As cImagesGrid = New cImagesGrid(New cSurvey.cSegmentImages)
        Controls.Add(oGrid)
        oGrid.Dock = DockStyle.Fill
    End Sub
End Class