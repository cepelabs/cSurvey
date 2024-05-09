Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports System.Windows.Media.Media3D
Imports cSurveyPC.cSurvey.Design.Items
Imports HelixToolkit.Wpf

Public Class frmItemChunk3DPlanRenderer

    Private oHolosView As cHolosItemView
    Public Sub New(Item As cItemChunk3D, Width As Integer, Height As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Size = New Size(Width, Height)
        oHolosView = New cHolosItemView
        h3D.Child = oHolosView

        oHolosView.mainViewport.ShowViewCube = True
        oHolosView.mainViewport.ShowCoordinateSystem = True

        Dim oGroup As ModelVisual3D = New ModelVisual3D
        Dim oTransformGroup As Transform3DGroup = New Transform3DGroup()

        Dim oResultTransformGroup As Transform3DGroup = New Transform3DGroup()
        Call oResultTransformGroup.Children.Add(New ScaleTransform3D(Item.ModelTransform.XScale, Item.ModelTransform.YScale, Item.ModelTransform.ZScale))
        Call oResultTransformGroup.Children.Add(New RotateTransform3D(New AxisAngleRotation3D(New Vector3D(1, 0, 0), Item.ModelTransform.XRotate)))
        Call oResultTransformGroup.Children.Add(New RotateTransform3D(New AxisAngleRotation3D(New Vector3D(0, 1, 0), Item.ModelTransform.YRotate)))
        Call oResultTransformGroup.Children.Add(New RotateTransform3D(New AxisAngleRotation3D(New Vector3D(0, 0, 1), Item.ModelTransform.ZRotate)))
        oGroup.Transform = oResultTransformGroup
        oGroup.Content = Item.LoadModel
        oHolosView.mainViewport.Children.Add(oGroup)
        oHolosView.mainViewport.ZoomExtents(0)
        'oHolosView.mainViewport.Camera.Position = New Point3D(0, 0, 1000)
        'oHolosView.mainViewport.Camera.LookAt(New Point3D(0, 0, 0), 0)
        'oHolosView.mainViewport.LookAt(New Point3D(0, 0, 0), New Vector3D(0, 0, 100), 0)

    End Sub

    Private Sub frmItemChunk3DPlanRenderer_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        oHolosView.mainViewport.ZoomExtents(0)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Call Viewport3DHelper.SaveBitmap(oHolosView.mainViewport.Viewport, "d:\test.png", Nothing, 2, BitmapExporter.OutputFormat.Png)
    End Sub
End Class