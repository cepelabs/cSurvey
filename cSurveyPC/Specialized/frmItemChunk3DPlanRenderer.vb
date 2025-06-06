Imports System.IO
Imports System.Threading.Tasks
Imports System.Windows.Controls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Threading
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraEditors
Imports HelixToolkit.Wpf

Friend Class frmItemChunk3DPlanRenderer

    Private oHolosView As cHolosItemView
    Private oCube1 As CubeVisual3D
    Private oCube2 As CubeVisual3D

    Private oItem As cItemChunk3D

    Private iWidth As Integer
    Private iHeight As Integer
    Public Sub New(Item As cItemChunk3D, Width As Integer, Height As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        iWidth = Width
        iHeight = Height
        Size = New Size(iWidth, iHeight)
        oHolosView = New cHolosItemView
        h3D.Child = oHolosView

        oHolosView.mainViewport.ShowViewCube = True
        oHolosView.mainViewport.ShowCoordinateSystem = True
        'oHolosView.mainViewport.Orthographic = True

        oItem = Item

        Dim oGroup As ModelVisual3D = New ModelVisual3D
        Dim oTransformGroup As Transform3DGroup = New Transform3DGroup()

        Dim oResultTransformGroup As Transform3DGroup = New Transform3DGroup()
        Call oResultTransformGroup.Children.Add(New ScaleTransform3D(oItem.ModelTransform.XScale, oItem.ModelTransform.YScale, oItem.ModelTransform.ZScale))
        Call oResultTransformGroup.Children.Add(New RotateTransform3D(New AxisAngleRotation3D(New Vector3D(1, 0, 0), oItem.ModelTransform.XRotate)))
        Call oResultTransformGroup.Children.Add(New RotateTransform3D(New AxisAngleRotation3D(New Vector3D(0, 1, 0), oItem.ModelTransform.YRotate)))
        Call oResultTransformGroup.Children.Add(New RotateTransform3D(New AxisAngleRotation3D(New Vector3D(0, 0, 1), oItem.ModelTransform.ZRotate)))
        oGroup.Transform = oResultTransformGroup
        oGroup.Content = oItem.LoadModel
        oHolosView.mainViewport.Children.Add(oGroup)

        Dim oCamera As OrthographicCamera = New OrthographicCamera(New Point3D(0, 1000, 0), New Vector3D(0, 0, -1), New Vector3D(0, 1, 0), 200)
        oCamera.NearPlaneDistance = 0.0001
        oCamera.FarPlaneDistance = Double.PositiveInfinity
        oHolosView.mainViewport.Camera = oCamera

        oHolosView.mainViewport.ZoomExtents(0)
        'oHolosView.mainViewport.Camera.Position = New Point3D(0, 0, 1000)
        'oHolosView.mainViewport.Camera.LookAt(New Point3D(0, 0, 0), 0)
        'oHolosView.mainViewport.LookAt(New Point3D(0, 0, 0), New Vector3D(0, 0, 100), 0)

    End Sub

    Private Sub SaveViewportAsImage(viewport As HelixViewport3D, filename As String, width As Integer, height As Integer)
        Dim bmp As New RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32)
        bmp.Render(viewport)

        Dim encoder As New PngBitmapEncoder()
        encoder.Frames.Add(BitmapFrame.Create(bmp))

        Using fs = New FileStream(filename, FileMode.Create)
            encoder.Save(fs)
        End Using
    End Sub

    Private Delegate Sub pProcessImageDeletegate()

    Private Sub pProcessImage()
        SaveViewportAsImage(oHolosView.mainViewport, "d:\prova.jpg", iWidth, iHeight)
    End Sub

    Private Sub frmItemChunk3DPlanRenderer_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Task.Run(Function()
                     Threading.Thread.Sleep(2000)
                     Invoke(New pProcessImageDeletegate(AddressOf pProcessImage))
                 End Function)
    End Sub

    'Private Async Function pRenderAsync() As Task
    '    Await pRenderAndCaptureAsync()
    'End Function

    'Private Async Function pRenderAndCaptureAsync() As Task
    '    Await pRenderModelAsync()
    '    Call Viewport3DHelper.SaveBitmap(oHolosView.mainViewport.Viewport, "d:\test.png", Nothing, 2, BitmapExporter.OutputFormat.Png)
    'End Function

    'Private Function pRenderModelAsync() As Task
    '    Dim taskCompletionSource As TaskCompletionSource(Of Object) = New TaskCompletionSource(Of Object)
    '    oHolosView.Dispatcher.Invoke(Sub()
    '                                     Call pRenderModel()
    '                                     oHolosView.Dispatcher.BeginInvoke(New Action(Sub()
    '                                                                                      taskCompletionSource.TrySetResult(Nothing)
    '                                                                                  End Sub), DispatcherPriority.ContextIdle)
    '                                 End Sub)
    '    Return taskCompletionSource.Task
    'End Function

    'Private Sub pRenderModel()
    '    Dim oGroup As ModelVisual3D = New ModelVisual3D
    '    Dim oTransformGroup As Transform3DGroup = New Transform3DGroup()

    '    Dim oResultTransformGroup As Transform3DGroup = New Transform3DGroup()
    '    Call oResultTransformGroup.Children.Add(New ScaleTransform3D(oItem.ModelTransform.XScale, oItem.ModelTransform.YScale, oItem.ModelTransform.ZScale))
    '    Call oResultTransformGroup.Children.Add(New RotateTransform3D(New AxisAngleRotation3D(New Vector3D(1, 0, 0), oItem.ModelTransform.XRotate)))
    '    Call oResultTransformGroup.Children.Add(New RotateTransform3D(New AxisAngleRotation3D(New Vector3D(0, 1, 0), oItem.ModelTransform.YRotate)))
    '    Call oResultTransformGroup.Children.Add(New RotateTransform3D(New AxisAngleRotation3D(New Vector3D(0, 0, 1), oItem.ModelTransform.ZRotate)))
    '    oGroup.Transform = oResultTransformGroup
    '    oGroup.Content = oItem.LoadModel

    '    oCube1 = New CubeVisual3D
    '    oHolosView.mainViewport.Children.Add(oCube1)
    '    Dim oCube1Bound As Rect3D = oCube1.FindBounds(oCube1.Transform)
    '    oCube1.Transform = New TranslateTransform3D(oItem.Stations.Station1.Point.X + oCube1Bound.SizeX / 4.0, oItem.Stations.Station1.Point.Y + oCube1Bound.SizeY / 4.0, oItem.Stations.Station1.Point.Z + oCube1Bound.SizeZ / 4.0)

    '    oCube2 = New CubeVisual3D
    '    oHolosView.mainViewport.Children.Add(oCube2)
    '    Dim oCube2Bound As Rect3D = oCube2.FindBounds(oCube2.Transform)
    '    oCube2.Transform = New TranslateTransform3D(oItem.Stations.Station2.Point.X + oCube2Bound.SizeX / 4.0, oItem.Stations.Station2.Point.Y + oCube2Bound.SizeY / 4.0, oItem.Stations.Station2.Point.Z + oCube2Bound.SizeZ / 4.0)

    '    'Dim oOldCamera As ProjectionCamera = oHolosView.mainViewport.Camera.Clone
    '    'Dim oCamera As OrthographicCamera = New OrthographicCamera(oOldCamera.Position, oOldCamera.LookDirection, oOldCamera.UpDirection, 60)
    '    'oCamera.NearPlaneDistance = 0
    '    'oCamera.FarPlaneDistance = oOldCamera.FarPlaneDistance
    '    'oHolosView.mainViewport.Camera = oCamera

    '    oHolosView.mainViewport.Children.Add(oGroup)
    '    oHolosView.mainViewport.CameraController.ChangeDirection(New Vector3D(0, 0, -1), New Vector3D(0, 1, 0))
    '    oHolosView.mainViewport.ZoomExtents(0)
    'End Sub

    'Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
    '    oHolosView.mainViewport.ZoomExtents(0)
    'End Sub

    'Private oButton1 As SimpleButton
    'Private oButton2 As SimpleButton

    'Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
    '    Dim oCube1Bound As Rect3D = oCube1.FindBounds(oCube1.Transform)
    '    Dim oPoint1 As Windows.Point = Viewport3DHelper.Point3DtoPoint2D(oHolosView.mainViewport.Viewport, oCube1Bound.GetCenter)

    '    Dim oCube2Bound As Rect3D = oCube2.FindBounds(oCube2.Transform)
    '    Dim oPoint2 As Windows.Point = Viewport3DHelper.Point3DtoPoint2D(oHolosView.mainViewport.Viewport, oCube2Bound.GetCenter)

    '    Debug.Print(oPoint1.ToString)
    '    Debug.Print(oPoint2.ToString)
    '    If oButton1 Is Nothing Then
    '        oButton1 = New SimpleButton
    '        Controls.Add(oButton1)
    '    End If
    '    oButton1.Location = New Point(oPoint1.X - 4, oPoint1.Y - 4)
    '    oButton1.Size = New Size(8, 8)
    '    oButton1.Visible = True
    '    oButton1.BringToFront()

    '    If oButton2 Is Nothing Then
    '        oButton2 = New SimpleButton
    '        Controls.Add(oButton2)
    '    End If
    '    oButton2.Location = New Point(oPoint2.X - 4, oPoint2.Y - 4)
    '    oButton2.Size = New Size(8, 8)
    '    oButton2.Visible = True
    '    oButton2.BringToFront()

    '    Call Viewport3DHelper.SaveBitmap(oHolosView.mainViewport.Viewport, "d:\test.png", Nothing, 1, BitmapExporter.OutputFormat.Png)

    '    Using oBitmap As Bitmap = Bitmap.FromFile("d:\test.png")
    '        Using oGraphics As Graphics = Graphics.FromImage(oBitmap)
    '            oGraphics.FillRectangle(Brushes.Red, New Rectangle(oPoint1.X - 4, oPoint1.Y - 4, 8, 8))
    '            oGraphics.FillRectangle(Brushes.Blue, New Rectangle(oPoint2.X - 4, oPoint2.Y - 4, 8, 8))
    '        End Using
    '        oBitmap.Save("d:\test2.png", Imaging.ImageFormat.Png)
    '    End Using

    'End Sub

    Private Sub h3D_ChildChanged(sender As Object, e As Integration.ChildChangedEventArgs) Handles h3D.ChildChanged

    End Sub
End Class