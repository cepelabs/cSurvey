Imports System.Windows.Shapes
Imports System.Windows.Media.Media3D
Imports System.Windows
Imports System.Xml
Imports System.IO
Imports HelixToolkit.Wpf.cSurveySpecialized

Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports HelixToolkit.Wpf
Imports System.Windows.Controls
Imports DotNetCaveModel.DNetCMCave
Imports CM
Imports System.Collections.Generic
Imports DevExpress.XtraBars.Painters
Imports cSurveyPC.cSurvey.Design3D
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports System.Windows.Markup
Imports DevExpress.Utils.Extensions
Imports DevExpress.XtraEditors.TextEdit
Imports cSurveyPC.cSurvey.Design.Items
Imports System.Windows.Input
Imports System.Windows.Media

Friend Class cHolosViewer
    Private Const iHotSpotFillAlpha As Integer = 100
    Private Const iHotSpotSelectedFillAlpha As Integer = 255
    Private Const iHotSpotBorderAlpha As Integer = 160

    Private i3DScale As Integer = 200

    Private oSurvey As cSurvey.cSurvey

    Friend Class cItemSelectEventArgs
        Inherits EventArgs

        Public SelectedItem As Object

        Public Sub New(SelectedItem As Object)
            Me.SelectedItem = SelectedItem
        End Sub

        Public Sub New()
        End Sub
    End Class

    Friend Class cSceneInfoChangeEventArgs
        Inherits EventArgs

        Public Bearing As Single
        Public Inclination As Single

        Public Sub New(Bearing As Single, Inclination As Single)
            Me.Bearing = Bearing
            Me.Inclination = Inclination
        End Sub
    End Class

    Friend Event OnSceneInfoChange(Sender As cHolosViewer, Args As cSceneInfoChangeEventArgs)

    Friend Event OnItemSelect(Sender As cHolosViewer, Args As cItemSelectEventArgs)
    Friend Event OnDoubleClick(Sender As cHolosViewer, Args As EventArgs)

    Friend Event OnRedrawRequest(Sender As cHolosViewer, Args As EventArgs)
    Friend Event OnRedrawComplete(Sender As cHolosViewer, Args As EventArgs)

    Friend Event OnInvalidate(sender As cHolosViewer, Args As EventArgs)

    Private oCaves As List(Of ModelVisual3D)
    Private oSelectors As ModelVisual3D
    Private oModels As List(Of ModelVisual3D)
    Private oChunks As Dictionary(Of cItemChunk3D, ModelVisual3D)
    Private oPlots As List(Of ModelVisual3D)
    Private oSurfaces As List(Of ModelVisual3D)
    Private oSurfaceModel As HelixToolkit.Wpf.cSurveySpecialized.TerrainVisual3D
    Private bModelOutline As Boolean
    Private bModelOutlineDisabled As Boolean
    Private oModelOutline As List(Of LinesVisual3D)
    Private oAll As SortingVisual3D

    Private oHotSpots As Dictionary(Of ModelVisual3D, cHotSpot)
    Private oCavesHotSpots As Dictionary(Of ModelVisual3D, cHotSpot)
    Private oSurfacesHotSpots As Dictionary(Of ModelVisual3D, cHotSpot)
    Private oChunksHotSpots As Dictionary(Of ModelVisual3D, cHotSpot)

    'Private cmCave As DNetCMCave
    Dim oCmCaves As Dictionary(Of cSurvey.cSurvey, DNetCMCave)
    Private oOutlineUpdateTimer As System.Windows.Forms.Timer

    Public Class cHolosHitTestResult
        Private oSegment As cSegment
        Private oTrigPoint As cTrigPoint

        Public ReadOnly Property Segment As cSegment
            Get
                Return oSegment
            End Get
        End Property

        Public ReadOnly Property TrigPoint As cTrigPoint
            Get
                Return oTrigPoint
            End Get
        End Property

        Friend Sub New(ByVal Segment As cSegment, ByVal TrigPoint As cTrigPoint)
            oSegment = Segment
            oTrigPoint = TrigPoint
        End Sub
    End Class

    Private Class cHotSpot
        Private oSourceItem As Object
        Private oModel As ModelVisual3D

        Public ReadOnly Property SourceItem As Object
            Get
                Return oSourceItem
            End Get
        End Property

        Public ReadOnly Property Model As ModelVisual3D
            Get
                Return oModel
            End Get
        End Property

        Friend Sub New(Model As ModelVisual3D, Chunk As cItemChunk3D)
            oModel = Model
            oSourceItem = Chunk
        End Sub

        Friend Sub New(Model As ModelVisual3D, Segment As cSegment)
            oModel = Model
            oSourceItem = Segment
        End Sub

        Friend Sub New(Model As ModelVisual3D, Trigpoint As cTrigPoint)
            oModel = Model
            oSourceItem = Trigpoint
        End Sub
    End Class

    Public Class cElevation
        Implements cITerrainElevation
        Implements IDisposable

        Private iLod As Integer

        Private iHeight As Integer
        Private iWidth As Integer

        Private sMaximum As Single
        Private sMinimum As Single

        Private sScale As Single

        Private oImage As Bitmap
        Private sOpacity As Single

        Private oData As Single()

        Public ReadOnly Property Data As Single() Implements cITerrainElevation.Data
            Get
                Return oData
            End Get
        End Property

        Public ReadOnly Property Height As Integer Implements cITerrainElevation.Height
            Get
                Return iHeight
            End Get
        End Property

        Public ReadOnly Property Maximum As Single Implements cITerrainElevation.Maximum
            Get
                Return sMaximum
            End Get
        End Property

        Public ReadOnly Property Minimum As Single Implements cITerrainElevation.Minimum
            Get
                Return sMinimum
            End Get
        End Property

        Public ReadOnly Property Width As Integer Implements cITerrainElevation.Width
            Get
                Return iWidth
            End Get
        End Property

        Public ReadOnly Property Scale As Single Implements cITerrainElevation.Scale
            Get
                Return sScale
            End Get
        End Property

        Friend Sub New(Width As Integer, Height As Integer, Scale As Single, Data As Single(), Minimum As Single, Maximum As Single, Image As Bitmap, Opacity As Double, Lod As Integer)
            iWidth = Width
            iHeight = Height
            sMinimum = Minimum
            sMaximum = Maximum
            sScale = Scale
            oData = Data
            oImage = Image
            sOpacity = Opacity
            iLod = Lod
        End Sub

        Public Property Image As Bitmap Implements cITerrainElevation.Image
            Get
                Return oImage
            End Get
            Set(value As Bitmap)
                oImage = Image
            End Set
        End Property

        Public ReadOnly Property Opacity As Single Implements cITerrainElevation.Opacity
            Get
                Return sOpacity
            End Get
        End Property

        Public ReadOnly Property Lod As Integer Implements cITerrainElevation.Lod
            Get
                Return iLod
            End Get
        End Property

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    If Not oImage Is Nothing Then Call oImage.Dispose()
                End If
                Erase oData
            End If
            Me.disposedValue = True
        End Sub

        ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(disposing As Boolean).
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Private Sub pSurface(ByVal PaintOptions As cOptions3D)
        'oSurfaceModel = Nothing
        'Call oSurfaces.Clear()
        'Call oSurfacesHotSpots.Clear()

        Dim iWidth As Integer
        Dim iHeight As Integer
        Dim sMax As Single
        Dim sMin As Single
        Dim dHeightScale As Double = PaintOptions.SurfaceOptions.Elevation.AltitudeAmplification  'sldHeightScale.Value

        If PaintOptions.SurfaceOptions.Elevation.ID <> "" Then
            Dim oSurface As cSurvey.Surface.cElevation = oSurvey.Surface(PaintOptions.SurfaceOptions.Elevation.ID)
            If Not oSurface Is Nothing Then
                Dim dRows As Decimal = oSurface.Rows
                Dim dColumns As Decimal = oSurface.Columns
                If dColumns > 0 And dRows > 0 Then
                    Dim sNoDataValue As Single = oSurface.NoDataValue
                    Dim dXSize As Decimal = oSurface.XSize
                    Dim dYSize As Decimal = oSurface.YSize

                    Dim oData(dRows * dColumns) As Single

                    Dim iIndex As Integer = 0
                    For dY As Decimal = dRows - 1 To 0 Step -1
                        For dX As Decimal = 0 To dColumns - 1
                            Dim sAlt As Single = oSurface.Data(dY, dX)
                            If sAlt = sNoDataValue Then
                                oData(iIndex) = 0
                            Else
                                oData(iIndex) = sAlt * dHeightScale
                            End If
                            iIndex += 1
                        Next
                    Next
                    iWidth = dColumns
                    iHeight = dRows
                    sMax = oData.Max
                    sMin = oData.Min

                    Dim oTerrainElevation As Surface.cElevation = DirectCast(oSurvey.Surface(PaintOptions.SurfaceOptions.Elevation.ID), Surface.cElevation)
                    Dim oTerrainStation As PointF = oTerrainElevation.GetTLPoint   ' cSurvey.cTrigPoint = oSurvey.TrigPoints(cSurvey.Calculate.cCalculate.SurfaceElevationTrigpointName1)
                    Dim sOffsetX As Single = oTerrainStation.X
                    Dim sOffsetY As Single = oTerrainStation.Y + (iHeight - 1) * dYSize
                    Dim sOffsetZ As Single = oTerrainElevation.GetElevation(oTerrainStation)
                    If sOffsetZ = oTerrainElevation.NoDataValue Then sOffsetZ = 0

                    'creo la texture combinando i vari layer selezionati...
                    Dim oImage As Bitmap = GetSurfaceImage(oSurvey, PaintOptions.SurfaceOptions, oSurvey.Properties.ThreeDSurfaceTextureLod)
                    Using oElevation As cElevation = New cElevation(dColumns, dRows, dXSize, oData, sMin, sMax, oImage, 1 - PaintOptions.SurfaceOptions.Elevation.Transparency, oSurvey.Properties.ThreeDSurfaceModelLod)
                        oSurfaceModel = New HelixToolkit.Wpf.cSurveySpecialized.TerrainVisual3D
                        oSurfaceModel.SetValue(HelixToolkit.Wpf.cSurveySpecialized.TerrainVisual3D.SourceProperty, oElevation)
                        Dim oSurfaceTrasform As Media.Media3D.Transform3DGroup = New Media.Media3D.Transform3DGroup
                        oSurfaceTrasform.Children.Add(New Media.Media3D.ScaleTransform3D(1, dYSize / dXSize, 1))
                        oSurfaceTrasform.Children.Add(New Media.Media3D.TranslateTransform3D(sOffsetX, -1 * sOffsetY, 0))
                        'oSurfaceModel.Transform = New Media.Media3D.ScaleTransform3D(1, dYSize / dXSize, 1)
                        'oSurfaceModel.Transform = New Media.Media3D.TranslateTransform3D(sOffsetX, -1 * sOffsetY, 0)
                        oSurfaceModel.Transform = oSurfaceTrasform
                        Call oSurfaces.Add(oSurfaceModel)
                    End Using

                    Width = iWidth * dXSize
                    Height = iHeight * dYSize

                    Dim oTopLeft As Point3D = New Point3D(0, 0, 0)
                    Dim oTopRight As Point3D = New Point3D(Width, 0, 0)
                    Dim oBottomLeft As Point3D = New Point3D(0, Height, 0)
                    Dim oBottomRight As Point3D = New Point3D(Width, Height, 0)

                    Dim oSeaLevelBoundingColor As System.Drawing.Color = System.Drawing.Color.LightBlue
                    Dim oSeaLevelBoundingMediaColor As Media.Color = Media.Color.FromArgb(oSeaLevelBoundingColor.A, oSeaLevelBoundingColor.R, oSeaLevelBoundingColor.G, oSeaLevelBoundingColor.B)
                    Dim oSeaLevelBoundingMediaBrush As Media.Brush = New Media.SolidColorBrush(Media.Color.FromArgb(20, oSeaLevelBoundingColor.R, oSeaLevelBoundingColor.G, oSeaLevelBoundingColor.B))
                    Dim oSeaLevelBoundingPlan As HelixToolkit.Wpf.QuadVisual3D = New HelixToolkit.Wpf.QuadVisual3D
                    oSeaLevelBoundingPlan.Point1 = oTopLeft
                    oSeaLevelBoundingPlan.Point2 = oBottomLeft
                    oSeaLevelBoundingPlan.Point3 = oBottomRight
                    oSeaLevelBoundingPlan.Point4 = oTopRight
                    oSeaLevelBoundingPlan.Fill = oSeaLevelBoundingMediaBrush
                    oSeaLevelBoundingPlan.Transform = New Media.Media3D.TranslateTransform3D(sOffsetX, -1 * sOffsetY, 0)
                    Call oSurfaces.Add(oSeaLevelBoundingPlan)

                    Dim oSeaLevelBounding As HelixToolkit.Wpf.LinesVisual3D = New HelixToolkit.Wpf.LinesVisual3D
                    oSeaLevelBounding.Points.Add(oTopLeft)
                    oSeaLevelBounding.Points.Add(oBottomLeft)
                    oSeaLevelBounding.Points.Add(oBottomLeft)
                    oSeaLevelBounding.Points.Add(oBottomRight)
                    oSeaLevelBounding.Points.Add(oBottomRight)
                    oSeaLevelBounding.Points.Add(oTopRight)
                    oSeaLevelBounding.Points.Add(oTopRight)
                    oSeaLevelBounding.Points.Add(oTopLeft)
                    oSeaLevelBounding.Transform = New Media.Media3D.TranslateTransform3D(sOffsetX, -1 * sOffsetY, 0)
                    oSeaLevelBounding.Thickness = 1
                    oSeaLevelBounding.Color = oSeaLevelBoundingMediaColor
                    Call oSurfaces.Add(oSeaLevelBounding)

                    'For iAltLevel As Integer = (sMax \ 100) * 100 To 0 Step -100
                    '    Dim oAltTopLeft As Point3D = New Point3D(0, 0, 0)
                    '    Dim oAltTopRight As Point3D = New Point3D(Width, 0, 0)
                    '    Dim oAltBottomLeft As Point3D = New Point3D(0, Height, 0)
                    '    Dim oAltBottomRight As Point3D = New Point3D(Width, Height, 0)

                    '    Dim oAltBoundingColor As System.Drawing.Color = System.Drawing.Color.WhiteSmoke
                    '    Dim oAltBoundingMediaColor As Media.Color = Media.Color.FromArgb(oAltBoundingColor.A, oAltBoundingColor.R, oAltBoundingColor.G, oAltBoundingColor.B)
                    '    Dim oAltBoundingMediaBrush As Media.Brush = New Media.SolidColorBrush(Media.Color.FromArgb(150, oAltBoundingColor.R, oAltBoundingColor.G, oAltBoundingColor.B))
                    '    Dim oAltBoundingPlan As HelixToolkit.Wpf.QuadVisual3D = New HelixToolkit.Wpf.QuadVisual3D
                    '    oAltBoundingPlan.Point1 = oTopLeft
                    '    oAltBoundingPlan.Point2 = oBottomLeft
                    '    oAltBoundingPlan.Point3 = oBottomRight
                    '    oAltBoundingPlan.Point4 = oTopRight
                    '    oAltBoundingPlan.Fill = oAltBoundingMediaBrush
                    '    oAltBoundingPlan.Transform = New Media.Media3D.TranslateTransform3D(sOffsetX, -1 * sOffsetY, iAltLevel)
                    '    Call oList.Add(oAltBoundingPlan)

                    '    Dim oAltBounding As HelixToolkit.Wpf.LinesVisual3D = New HelixToolkit.Wpf.LinesVisual3D
                    '    oAltBounding.Points.Add(oTopLeft)
                    '    oAltBounding.Points.Add(oBottomLeft)
                    '    oAltBounding.Points.Add(oBottomLeft)
                    '    oAltBounding.Points.Add(oBottomRight)
                    '    oAltBounding.Points.Add(oBottomRight)
                    '    oAltBounding.Points.Add(oTopRight)
                    '    oAltBounding.Points.Add(oTopRight)
                    '    oAltBounding.Points.Add(oTopLeft)
                    '    oAltBounding.Transform = New Media.Media3D.TranslateTransform3D(sOffsetX, -1 * sOffsetY, iAltLevel)
                    '    oAltBounding.Thickness = 1
                    '    oAltBounding.Color = oAltBoundingMediaColor
                    '    Call oList.Add(oAltBounding)
                    'Next
                End If
            End If
        End If
    End Sub

    Public Enum ViewFromEnum
        FromTop = 0
        FromBottom = 1
        FromEast = 2
        FromWest = 3
        FromNord = 4
        FromSouth = 5
    End Enum

    Public Enum CameraTypeEnum
        Perspective = 0
        Orthographic = 1
    End Enum

    Public Enum cameraModeEnum
        Inspect = 0
        Walkaround = 1
    End Enum

    Public Property CameraMode As cameraModeEnum
        Get
            Return mainViewport.CameraController.CameraMode
        End Get
        Set(value As cameraModeEnum)
            mainViewport.CameraController.CameraMode = value
        End Set
    End Property

    Public Property CameraType As CameraTypeEnum
        Get
            If TypeOf mainViewport.Camera Is PerspectiveCamera Then
                Return CameraTypeEnum.Perspective
            Else
                Return CameraTypeEnum.Orthographic
            End If
        End Get
        Set(value As CameraTypeEnum)
            If value <> CameraType Then
                If value = CameraTypeEnum.Perspective Then
                    Dim oOldCamera As ProjectionCamera = mainViewport.Camera.Clone
                    Dim oCamera As PerspectiveCamera = New PerspectiveCamera(oOldCamera.Position, oOldCamera.LookDirection, oOldCamera.UpDirection, 60)
                    oCamera.NearPlaneDistance = oOldCamera.NearPlaneDistance
                    oCamera.FarPlaneDistance = oOldCamera.FarPlaneDistance
                    mainViewport.Camera = oCamera
                Else
                    Dim oOldCamera As ProjectionCamera = mainViewport.Camera.Clone
                    Dim oCamera As OrthographicCamera = New OrthographicCamera(oOldCamera.Position, oOldCamera.LookDirection, oOldCamera.UpDirection, 60)
                    oCamera.NearPlaneDistance = oOldCamera.NearPlaneDistance
                    oCamera.FarPlaneDistance = oOldCamera.FarPlaneDistance
                    mainViewport.Camera = oCamera
                End If
            End If
        End Set
    End Property

    Public Sub SetView(View As ViewFromEnum)
        Select Case View
            Case ViewFromEnum.FromBottom
                Call mainViewport.CameraController.ChangeDirection(New Vector3D(0, 0, 1), New Vector3D(0, -1, 0))
            Case ViewFromEnum.FromTop
                Call mainViewport.CameraController.ChangeDirection(New Vector3D(0, 0, -1), New Vector3D(0, 1, 0))
            Case ViewFromEnum.FromEast
                Call mainViewport.CameraController.ChangeDirection(New Vector3D(1, 0, 0), New Vector3D(0, 0, 1))
            Case ViewFromEnum.FromWest
                Call mainViewport.CameraController.ChangeDirection(New Vector3D(-1, 0, 0), New Vector3D(0, 0, 1))
            Case ViewFromEnum.FromNord
                Call mainViewport.CameraController.ChangeDirection(New Vector3D(0, -1, 0), New Vector3D(0, 0, 1))
            Case ViewFromEnum.FromSouth
                Call mainViewport.CameraController.ChangeDirection(New Vector3D(0, 1, 0), New Vector3D(0, 0, 1))
        End Select


        ' void cube_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        '{
        '    DateTime currentTime = DateTime.Now;

        '    Vector3D normalVector = this.m_dicNormalVectors[sender];
        '    Vector3D upVector = this.m_dicUpVectors[sender];

        '    //check if this was a double click or a normal click
        'If ((currentTime - lastClick).TotalSeconds < 0.5) Then
        '    {
        '        //this was a double click, so scroll to the opposite side of the cube
        '        normalVector = this.m_dicOppositeNormalVectors[sender];
        '        upVector = this.m_dicOppositeUpVectors[sender];
        '    }
        '    lastClick = currentTime;

        '    var camera = this.MainViewport.Camera as ProjectionCamera;
        '    Point3D target = camera.Position + camera.LookDirection;
        '    double distance = camera.LookDirection.Length;

        '    Vector3D lookDirection = -normalVector;
        '    lookDirection.Normalize();
        '    lookDirection = lookDirection * distance;

        '    Point3D pos = target - lookDirection;
        '    Vector3D upDirection = upVector;
        '    upDirection.Normalize();

        '    Helper.AnimateTo(camera, pos, lookDirection, upDirection, 500);
        '}
    End Sub

    'Public Sub Rotate(AngleX As Single, AngleY As Single, AngleZ As Single)
    '    mainViewport.CameraController.AddRotateForce(AngleX, AngleY)

    '    Dim oPoint1 As Point3D = mainViewport.Camera.Position
    '    Dim oV1 As Vector3D = mainViewport.Camera.LookDirection
    '    Dim c1 As Single = Math.Sqrt(oV1.X ^ 2 + oV1.Y ^ 2)
    '    Dim sAngle As Single = Math.Atan(c1 / oV1.Z)
    '    Debug.Print("ANGOLO: " & RadiansToDegree(sAngle))
    '    'Dim i As Single = Math.Sqrt(c1 ^ 2 + oV1.Z ^ 2)


    '    'Dim sX As Single
    '    'Dim sY As Single
    '    'Dim sZ As Single
    '    'GetRotation(sX, sY, sZ)
    '    'sX = RadiansToDegree(sX)
    '    'sY = RadiansToDegree(sY)
    '    'sZ = RadiansToDegree(sZ)
    '    'Debug.Print(sX & "-" & sY & "- " & sZ)

    '    'If Not oAll Is Nothing Then
    '    '    Dim oTransformGroup As Transform3DGroup = New Transform3DGroup()
    '    '    Call oTransformGroup.Children.Add(New RotateTransform3D(New Media.Media3D.AxisAngleRotation3D(New Media.Media3D.Vector3D(1, 0, 0), AngleX)))
    '    '    Call oTransformGroup.Children.Add(New RotateTransform3D(New Media.Media3D.AxisAngleRotation3D(New Media.Media3D.Vector3D(0, 1, 0), AngleY)))
    '    '    Call oTransformGroup.Children.Add(New RotateTransform3D(New Media.Media3D.AxisAngleRotation3D(New Media.Media3D.Vector3D(0, 0, 1), AngleZ)))

    '    '    oAll.Transform = oTransformGroup
    '    '    mainViewport.Camera.Transform = oTransformGroup
    '    'End If

    'End Sub

    Public Sub GetRotation(ByRef X As Single, ByRef Y As Single, ByRef Z As Single)
        Dim oMatrix As Matrix3D = HelixToolkit.Wpf.Viewport3DHelper.GetCameraTransform(mainViewport.Viewport)
        If oMatrix.M11 = 1.0F Then
            X = Math.Atan2(oMatrix.M13, oMatrix.M34)
            Y = 0
            Z = 0
        ElseIf oMatrix.M11 = -1.0F Then
            X = Math.Atan2(oMatrix.M13, oMatrix.M34)
            Y = 0
            Z = 0
        Else
            X = Math.Atan2(-oMatrix.M31, oMatrix.M11)
            Y = Math.Asin(oMatrix.M21)
            Z = Math.Atan2(-oMatrix.M23, oMatrix.M22)
        End If
    End Sub

    Public Sub ZoomExtents()
        Call mainViewport.ZoomExtents()
    End Sub

    Friend Class cDrawInvalidateEventArgs
        Inherits EventArgs

        Private iInvalidate As cHolosViewer.InvalidateType

        Public ReadOnly Property Invalidate As cHolosViewer.InvalidateType
            Get
                Return iInvalidate
            End Get
        End Property

        Public Sub New(Invalidate As cHolosViewer.InvalidateType)
            iInvalidate = Invalidate
        End Sub
    End Class

    <Flags> Public Enum InvalidateType
        None = 0
        Selection = 0
        SurfaceTexture = 1
        SurfaceModel = 3
        Caves = 4
        ModelMode = 8
        Chunks = 9
        CameraMove = 16
        All = 255
        [Error] = 256
    End Enum

    Private iInvalidated As InvalidateType = InvalidateType.All

    Public Sub Invalidate(Optional Invalidate As InvalidateType = InvalidateType.All)
        If iInvalidated <> (iInvalidated Or Invalidate) Then
            iInvalidated = iInvalidated Or Invalidate

            If iInvalidated = InvalidateType.CameraMove Then
                If (oOutlineUpdateTimer Is Nothing) Then
                    oOutlineUpdateTimer = New System.Windows.Forms.Timer
                    oOutlineUpdateTimer.Interval = 250
                    AddHandler oOutlineUpdateTimer.Tick, AddressOf Me.drawOutlineTimerCallback
                    oOutlineUpdateTimer.Start()
                End If
            End If

            'If iInvalidated = InvalidateType.None Then
            '    pnlInvalidated.Visibility = Windows.Visibility.Hidden
            'ElseIf iInvalidated = InvalidateType.CameraMove Then
            '    If (oOutlineUpdateTimer Is Nothing) Then
            '        oOutlineUpdateTimer = New System.Windows.Forms.Timer
            '        oOutlineUpdateTimer.Interval = 250
            '        AddHandler oOutlineUpdateTimer.Tick, AddressOf Me.drawOutlineTimerCallback
            '        oOutlineUpdateTimer.Start()
            '    End If
            'Else
            '    'imgInvalidatedCaption.Source = warning
            '    'imgInvalidatedCaption.Source = New Media.Imaging.BitmapImage(New Uri("pack://application:,,,/Resources/error32.png"))
            '    imgWarning.Visibility = Visibility.Visible
            '    imgError.Visibility = Visibility.Hidden
            '    lblInvalidatedCaption.Content = modMain.GetLocalizedString("holos.invalidate")
            '    pnlInvalidated.Background = System.Windows.Media.Brushes.LemonChiffon
            '    pnlInvalidated.Visibility = Windows.Visibility.Visible
            'End If
            RaiseEvent OnInvalidate(Me, New EventArgs)
        End If
    End Sub

    'Public Sub [Error]([Error] As Boolean)
    '    If [Error] Then
    '        'imgInvalidatedCaption.Source = New Media.Imaging.BitmapImage(New Uri("pack://application:,,,/Resources/cross32.png"))
    '        imgWarning.Visibility = Visibility.Hidden
    '        imgError.Visibility = Visibility.Visible
    '        lblInvalidatedCaption.Content = modMain.GetLocalizedString("holos.error")
    '        pnlInvalidated.Background = System.Windows.Media.Brushes.PeachPuff
    '        pnlInvalidated.Visibility = Windows.Visibility.Visible
    '    Else
    '        pnlInvalidated.Visibility = Windows.Visibility.Hidden
    '    End If
    'End Sub

    Public ReadOnly Property IsInvalidated() As Boolean
        Get
            Return iInvalidated <> InvalidateType.None AndAlso Not (iInvalidated = InvalidateType.CameraMove)
        End Get
    End Property

    Public ReadOnly Property IsInError() As Boolean
        Get
            Return (iInvalidated And InvalidateType.Error) = InvalidateType.Error
        End Get
    End Property

    Private iRedrawCount As Integer = 0

    Public Sub RedrawRequest()
        RaiseEvent OnRedrawRequest(Me, New EventArgs)
    End Sub

    Public Property SceneBackgroundcolor As Color
        Get
            Return modPaint.MediaColorToDrawingColor(DirectCast(mainViewport.Background, Media.SolidColorBrush).Color)
        End Get
        Set(value As Color)
            mainViewport.Background = New Windows.Media.SolidColorBrush(modPaint.DrawingColorToMediaColor(value))
        End Set
    End Property

    Public ReadOnly Property RedrawCount As Integer
        Get
            Return iRedrawCount
        End Get
    End Property

    Public Sub Reset()
        iRedrawCount = 0
        iInvalidated = InvalidateType.All
        Call pClearViewport()
    End Sub

    Private bFirstComposition As Boolean

    Private Sub pCalculateSubData(Survey As cSurveyPC.cSurvey.cSurvey, ThreeDModelMode As cProperties.ThreeDModelModeEnum)
        Dim oTrigPointsToElaborate As List(Of String) = Survey.Segments.GetTrigPointsNames.ToList
        Dim iTrigPointsCount As Integer = oTrigPointsToElaborate.Count
        Dim iSegmentsCount As Integer = Survey.Segments.GetValidSegments.Count
        If iTrigPointsCount > 1 AndAlso iSegmentsCount > 0 Then
            Call Survey.Calculate.CalculateDataFromDesigns(oTrigPointsToElaborate, ThreeDModelMode)
        End If
    End Sub

    Public Sub Redraw(Survey As cSurvey.cSurvey, ByVal PaintOptions As cOptions3D, Selection As Helper.Editor.cIEditDesignSelection)
        If Survey Is oSurvey Then
            iRedrawCount += 1
        Else
            oSurvey = Survey
            iRedrawCount = 1
            bFirstComposition = True
        End If
        Call pClearViewport()

        Call oCaves.Clear()
        Call oCavesHotSpots.Clear()
        Call oPlots.Clear()
        oSelectors = Nothing
        Call oModels.Clear()

        Call oChunks.Clear()
        Call oChunksHotSpots.Clear()

        bModelOutline = False
        bModelOutlineDisabled = False
        Call oModelOutline.Clear()

        oSurfaceModel = Nothing
        Call oSurfaces.Clear()
        Call oSurfacesHotSpots.Clear()

        Try
            If oSurvey.Properties.Origin <> "" Then
                Dim oList As List(Of ModelVisual3D) = New List(Of ModelVisual3D)
                If PaintOptions.DrawPlot OrElse PaintOptions.DrawModel Then
                    'how do this with linked survey...the options is taken from this survey...add a parameter to use linked survey settings...
                    Dim iThreeDModelMode As cProperties.ThreeDModelModeEnum = oSurvey.Properties.ThreeDModelMode
                    If iThreeDModelMode > cProperties.ThreeDModelModeEnum.Simple AndAlso (PaintOptions.DrawLRUD OrElse PaintOptions.DrawModel) Then
                        Call pCalculateSubData(oSurvey, iThreeDModelMode)
                        If PaintOptions.DrawLinkedSurveys Then
                            For Each oLinkedSurvey As cSurveyPC.cSurvey.cSurvey In oSurvey.LinkedSurveys.GetSelected("design.3d").Select(Function(oItem) oItem.LinkedSurvey).ToList
                                Call pCalculateSubData(oLinkedSurvey, iThreeDModelMode)
                            Next
                        End If
                    End If
                    Call pCaves(PaintOptions, Selection)
                    Call oList.AddRange(oCaves)
                End If

                If PaintOptions.SurfaceOptions.DrawSurface Then
                    Call pSurface(PaintOptions)
                    Call oList.AddRange(oSurfaces)
                End If

                Call oList.AddRange(oModels)
                Call oList.AddRange(oPlots)
                Call oList.AddRange(oModelOutline)

                Call oList.AddRange(oChunks.Values)

                'selectors model contains object for hittest...this objects have to be hittested but not visible...is it possible?
                If Not IsNothing(oSelectors) Then Call oList.Add(oSelectors)

                If oAll IsNot Nothing Then Call oAll.Children.Clear()

                oAll = New SortingVisual3D
                oAll.CheckForOpaqueVisuals = True
                oAll.Method = SortingMethod.BoundingBoxCenter
                oAll.SortingFrequency = 0.25
                For Each oModel As ModelVisual3D In oList
                    Call oAll.Children.Add(oModel)
                Next
                Call mainViewport.Children.Add(oAll)

                'refresh hotspot collection...
                Call oHotSpots.Clear()
                For Each ohotspot As cHotSpot In oCavesHotSpots.Values
                    Call oHotSpots.Add(ohotspot.Model, ohotspot)
                Next
                For Each ohotspot As cHotSpot In oSurfacesHotSpots.Values
                    Call oHotSpots.Add(ohotspot.Model, ohotspot)
                Next
                For Each ohotspot As cHotSpot In oChunksHotSpots.Values
                    Call oHotSpots.Add(ohotspot.Model, ohotspot)
                Next
            End If

            Call pSetCamera()

            If iRedrawCount = 1 Then Dim oTimer As System.Threading.Timer = New System.Threading.Timer(AddressOf pResetSceneCallback, Nothing, 2000, System.Threading.Timeout.Infinite)

            RaiseEvent OnRedrawComplete(Me, New EventArgs)
            iInvalidated = InvalidateType.None
            pnlInvalidated.Visibility = Windows.Visibility.Hidden
            RaiseEvent OnInvalidate(Me, EventArgs.Empty)
        Catch ex As Exception
            Call oSurvey.RaiseOnErrorLogEvent(modMain.GetLocalizedString("holos.textpart2"), ex)
            Call Invalidate(InvalidateType.Error)
            RaiseEvent OnRedrawComplete(Me, EventArgs.Empty)
        End Try
    End Sub

    Private Function pGetPoint3d(X As Double, Y As Double, Z As Double, Optional fX As Double = 1, Optional fY As Double = 1, Optional fZ As Double = 1) As Point3D
        Return New Point3D(X * fX, Y * fY, Z * fZ)
    End Function

    Private Function pChunk(Chunk As cItemChunk3D, PaintOptions As cOptions3D) As ModelVisual3D
        Dim oChunkModel As Model3DGroup = Chunk.GetModel '.Clone
        Dim oChunkGroup As ModelVisual3D = New ModelVisual3D

        Dim dHeightScale As Double = PaintOptions.SurfaceOptions.Elevation.AltitudeAmplification

        Dim oResultTransformGroup As Transform3DGroup = New Transform3DGroup()
        Call oResultTransformGroup.Children.Add(New ScaleTransform3D(Chunk.ModelTransform.XScale, Chunk.ModelTransform.YScale, Chunk.ModelTransform.ZScale))
        Call oResultTransformGroup.Children.Add(New RotateTransform3D(New Media.Media3D.AxisAngleRotation3D(New Media.Media3D.Vector3D(1, 0, 0), Chunk.ModelTransform.XRotate)))
        Call oResultTransformGroup.Children.Add(New RotateTransform3D(New Media.Media3D.AxisAngleRotation3D(New Media.Media3D.Vector3D(0, 1, 0), Chunk.ModelTransform.YRotate)))
        Call oResultTransformGroup.Children.Add(New RotateTransform3D(New Media.Media3D.AxisAngleRotation3D(New Media.Media3D.Vector3D(0, 0, 1), Chunk.ModelTransform.ZRotate)))

        Dim sMainOriginX As Single = 0
        Dim sMainOriginY As Single = 0
        Dim sMainOriginZ As Single = 0
        Dim oMainCoordinate As Calculate.cTrigPointCoordinate = oSurvey.Calculate.TrigPoints(oSurvey.TrigPoints.GetOrigin).Coordinate
        If Not oMainCoordinate Is Nothing Then
            With oMainCoordinate
                Dim oUTM As modUTM.UTM = New modUTM.UTM(oMainCoordinate)
                sMainOriginX = oUTM.East
                sMainOriginY = oUTM.North
                sMainOriginZ = .Altitude()
            End With
        End If

        Dim sOriginX As Single = 0
        Dim sOriginY As Single = 0
        Dim sOriginZ As Single = 0
        Dim oCoordinate As Calculate.cTrigPointCoordinate = oSurvey.Calculate.TrigPoints(oSurvey.TrigPoints.GetOrigin).Coordinate
        If Not oCoordinate Is Nothing Then
            With oCoordinate
                Dim oUTM As modUTM.UTM = New modUTM.UTM(oCoordinate)
                sOriginX = oUTM.East
                sOriginY = oUTM.North
                Dim oSizePoint As SizeF = New SizeD(sOriginX - sMainOriginX, sOriginY - sMainOriginY)
                Dim oMovePoint As PointD = modPaint.RotatePointByRadians(New PointD(oSizePoint.Width, oSizePoint.Height), oSurvey.Calculate.GeoMagDeclinationData.MeridianConvergenceRadians)
                sOriginX = oMovePoint.X
                sOriginY = oMovePoint.Y
                sOriginZ = .Altitude()
            End With
        End If


        Dim oPoints As Dictionary(Of String, List(Of Point3D)) = GetStations3DPoints(oSurvey, sOriginX, sOriginY, sOriginZ, dHeightScale)
        Dim oStation1 As Point3D = oPoints(Chunk.Stations.Station1.TrigPoint.Name)(0)
        'reset model coordinate
        Call oResultTransformGroup.Children.Add(New TranslateTransform3D(-Chunk.Stations.Station1.Point.X, -Chunk.Stations.Station1.Point.Y, -Chunk.Stations.Station1.Point.Z))
        Dim oStation2 As Point3D = oPoints(Chunk.Stations.Station2.TrigPoint.Name)(0)

        'Dim dDistance1 As Double = oStation1.DistanceTo(oStation2)
        'Dim dDistance2 As Double = oModelEdit.Point1.DistanceTo(oModelEdit.Point2)
        'Dim dFinalScale As Double = dDistance1 / dDistance2

        Dim sBearingStation As Decimal = modPaint.GetBearing(New PointD(oStation1.X, -oStation1.Y), New PointD(oStation2.X, -oStation2.Y))
        Dim sBearingModel As Decimal = modPaint.GetBearing(New PointD(Chunk.Stations.Station1.Point.X, -Chunk.Stations.Station1.Point.Y), New PointD(Chunk.Stations.Station2.Point.X, -Chunk.Stations.Station2.Point.Y))
        Dim sAngle As Decimal = modPaint.NormalizeAngle(sBearingModel - sBearingStation)  ' modPaint.GetAngleBetweenSegment(New PointD(oStation1.X, -oStation1.Y), New PointD(oStation2.X, -oStation2.Y), New PointD(oModelEdit.Point1.X, oModelEdit.Point1.Y), New PointD(oModelEdit.Point2.X, oModelEdit.Point2.Y))
        Call oResultTransformGroup.Children.Add(New RotateTransform3D(New Media.Media3D.AxisAngleRotation3D(New Media.Media3D.Vector3D(0, 0, 1), sAngle)))
        Call oResultTransformGroup.Children.Add(New ScaleTransform3D(1.0 / Chunk.ModelTransform.XScale, 1.0 / Chunk.ModelTransform.YScale, (1.0 / Chunk.ModelTransform.ZScale) * dHeightScale))
        Call oResultTransformGroup.Children.Add(New TranslateTransform3D(oStation1.X, oStation1.Y, oStation1.Z))

        Dim oModelPointTransformGroup As Transform3DGroup = New Transform3DGroup()
        Call oModelPointTransformGroup.Children.Add(New RotateTransform3D(New Media.Media3D.AxisAngleRotation3D(New Media.Media3D.Vector3D(0, 0, 1), sAngle)))
        Call oModelPointTransformGroup.Children.Add(New ScaleTransform3D(1.0 / Chunk.ModelTransform.XScale, 1.0 / Chunk.ModelTransform.YScale, (1.0 / Chunk.ModelTransform.ZScale) * dHeightScale))
        Call oModelPointTransformGroup.Children.Add(New TranslateTransform3D(oStation1.X, oStation1.Y, oStation1.Z))

        Dim oModelPoint1 As Point3D = oModelPointTransformGroup.Transform(Chunk.Stations.Station1.Point)
        Dim oModelPoint2 As Point3D = oModelPointTransformGroup.Transform(Chunk.Stations.Station2.Point)

        'adjust x, y and z or adjust only plan distance and z?
        'TODO: this code work can be right only each delta have same sign of model station placeholder delta
        'if not model will be inverted and this is not correct
        'I don't know how to fix this...skew?
        Dim sXScale As Double = Math.Abs((oStation2.X - oStation1.X) / (oModelPoint2.X - oModelPoint1.X))
        Dim sYScale As Double = Math.Abs((oStation2.Y - oStation1.Y) / (oModelPoint2.Y - oModelPoint1.Y))
        Dim sZScale As Double = Math.Abs((oStation2.Z - oStation1.Z) / (oModelPoint2.Z - oModelPoint1.Z))
        Call oResultTransformGroup.Children.Add(New ScaleTransform3D(sXScale, sYScale, sZScale, oStation1.X, oStation1.Y, oStation1.Z))

        oChunkGroup.Transform = oResultTransformGroup
        oChunkGroup.Content = oChunkModel

        Return oChunkGroup
    End Function

    'Public Sub Import(Optional Filename As String = "")
    '    Using ofd As OpenFileDialog = New OpenFileDialog
    '        If ofd.ShowDialog() = DialogResult.OK Then
    '            Dim sFilename As String = ofd.FileName

    '            Dim oM As ModelImporter = New ModelImporter
    '            Dim oModel As Model3DGroup = oM.Load(sFilename)
    '            Dim oGroup As ModelVisual3D = New ModelVisual3D

    '            Dim oTransformGroup As Transform3DGroup = New Transform3DGroup()
    '            oGroup.Transform = oTransformGroup
    '            oGroup.Content = oModel

    '            Using frmHIE As frmHolosItemEdit = New frmHolosItemEdit(oSurvey)
    '                Call frmHIE.AddGroup(sFilename, oGroup)
    '                If frmHIE.ShowDialog = DialogResult.OK Then

    '                    Dim oImportModel As Model3DGroup = oM.Load(sFilename)
    '                    'My.Computer.FileSystem.WriteAllText("d:\prova.xaml", XamlWriter.Save(oImportModel.Clone), False)
    '                    'Using s As FileStream = New FileStream("d:\prova.xaml", FileMode.Open)
    '                    '    oImportModel = XamlReader.Load(s)
    '                    'End Using
    '                    Dim oImportGroup As ModelVisual3D = New ModelVisual3D
    '                    oImportGroup.Content = oImportModel

    '                    Dim oModelEdit As frmHolosItemEdit.cModelEdit = frmHIE.Result

    '                    '------------------------------------
    '                    Dim oItem3D As cItemChunk3D = oSurvey.[ThreeD].Layers.ChunkLayer.CreateChunk("", "", sFilename)
    '                    oItem3D.ModelTransform.XScale = oModelEdit.Scale
    '                    oItem3D.ModelTransform.YScale = oModelEdit.Scale
    '                    oItem3D.ModelTransform.ZScale = oModelEdit.Scale

    '                    oItem3D.ModelTransform.XRotate = oModelEdit.RotateX
    '                    oItem3D.ModelTransform.YRotate = oModelEdit.RotateY
    '                    oItem3D.ModelTransform.ZRotate = oModelEdit.RotateZ

    '                    Dim oTrigpoint1 As cTrigPoint = oSurvey.TrigPoints(oModelEdit.Station1)
    '                    oItem3D.Stations.SetStation1(oModelEdit.Point1, oTrigpoint1)
    '                    Dim oTrigpoint2 As cTrigPoint = oSurvey.TrigPoints(oModelEdit.Station2)
    '                    oItem3D.Stations.SetStation2(oModelEdit.Point2, oTrigpoint2)

    '                    '------------------------------------

    '                    'Dim oResultTransformGroup As Transform3DGroup = New Transform3DGroup()
    '                    'Call oResultTransformGroup.Children.Add(New ScaleTransform3D(oModelEdit.Scale, oModelEdit.Scale, oModelEdit.Scale))
    '                    'Call oResultTransformGroup.Children.Add(New RotateTransform3D(New Media.Media3D.AxisAngleRotation3D(New Media.Media3D.Vector3D(1, 0, 0), oModelEdit.RotateX)))
    '                    'Call oResultTransformGroup.Children.Add(New RotateTransform3D(New Media.Media3D.AxisAngleRotation3D(New Media.Media3D.Vector3D(0, 1, 0), oModelEdit.RotateY)))
    '                    'Call oResultTransformGroup.Children.Add(New RotateTransform3D(New Media.Media3D.AxisAngleRotation3D(New Media.Media3D.Vector3D(0, 0, 1), oModelEdit.RotateZ)))

    '                    'Dim sMainOriginX As Single = 0
    '                    'Dim sMainOriginY As Single = 0
    '                    'Dim sMainOriginZ As Single = 0
    '                    'Dim oMainCoordinate As Calculate.cTrigPointCoordinate = oSurvey.Calculate.TrigPoints(oSurvey.TrigPoints.GetOrigin).Coordinate
    '                    'If Not oMainCoordinate Is Nothing Then
    '                    '    With oMainCoordinate
    '                    '        Dim oUTM As modUTM.UTM = New modUTM.UTM(oMainCoordinate)
    '                    '        sMainOriginX = oUTM.East
    '                    '        sMainOriginY = oUTM.North
    '                    '        sMainOriginZ = .Altitude()
    '                    '    End With
    '                    'End If

    '                    'Dim sOriginX As Single = 0
    '                    'Dim sOriginY As Single = 0
    '                    'Dim sOriginZ As Single = 0
    '                    'Dim oCoordinate As Calculate.cTrigPointCoordinate = oSurvey.Calculate.TrigPoints(oSurvey.TrigPoints.GetOrigin).Coordinate
    '                    'If Not oCoordinate Is Nothing Then
    '                    '    With oCoordinate
    '                    '        Dim oUTM As modUTM.UTM = New modUTM.UTM(oCoordinate)
    '                    '        sOriginX = oUTM.East
    '                    '        sOriginY = oUTM.North
    '                    '        Dim oSizePoint As SizeF = New SizeD(sOriginX - sMainOriginX, sOriginY - sMainOriginY)
    '                    '        Dim oMovePoint As PointD = modPaint.RotatePointByRadians(New PointD(oSizePoint.Width, oSizePoint.Height), oSurvey.Calculate.GeoMagDeclinationData.MeridianConvergenceRadians)
    '                    '        sOriginX = oMovePoint.X
    '                    '        sOriginY = oMovePoint.Y
    '                    '        sOriginZ = .Altitude()
    '                    '    End With
    '                    'End If

    '                    ''TODO: fix this
    '                    'Dim dHeightScale As Double = 1 ' PaintOptions.SurfaceOptions.Elevation.AltitudeAmplification

    '                    'Dim oPoints As Dictionary(Of String, List(Of Point3D)) = GetStations3DPoints(oSurvey, sOriginX, sOriginY, sOriginZ, dHeightScale)
    '                    'Dim oStation1 As Point3D = oPoints(oModelEdit.Station1)(0)
    '                    ''reset model coordinate
    '                    'Call oResultTransformGroup.Children.Add(New TranslateTransform3D(-oModelEdit.X1, -oModelEdit.Y1, -oModelEdit.Z1))
    '                    'Dim oStation2 As Point3D = oPoints(oModelEdit.Station2)(0)

    '                    ''Dim dDistance1 As Double = oStation1.DistanceTo(oStation2)
    '                    ''Dim dDistance2 As Double = oModelEdit.Point1.DistanceTo(oModelEdit.Point2)
    '                    ''Dim dFinalScale As Double = dDistance1 / dDistance2

    '                    'Dim sBearingStation As Decimal = modPaint.GetBearing(New PointD(oStation1.X, -oStation1.Y), New PointD(oStation2.X, -oStation2.Y))
    '                    'Dim sBearingModel As Decimal = modPaint.GetBearing(New PointD(oModelEdit.Point1.X, -oModelEdit.Point1.Y), New PointD(oModelEdit.Point2.X, -oModelEdit.Point2.Y))
    '                    'Dim sAngle As Decimal = modPaint.NormalizeAngle(sBearingModel - sBearingStation)  ' modPaint.GetAngleBetweenSegment(New PointD(oStation1.X, -oStation1.Y), New PointD(oStation2.X, -oStation2.Y), New PointD(oModelEdit.Point1.X, oModelEdit.Point1.Y), New PointD(oModelEdit.Point2.X, oModelEdit.Point2.Y))
    '                    'Call oResultTransformGroup.Children.Add(New RotateTransform3D(New Media.Media3D.AxisAngleRotation3D(New Media.Media3D.Vector3D(0, 0, 1), sAngle)))
    '                    'Call oResultTransformGroup.Children.Add(New ScaleTransform3D(1.0 / oModelEdit.Scale, 1.0 / oModelEdit.Scale, 1.0 / oModelEdit.Scale))
    '                    'Call oResultTransformGroup.Children.Add(New TranslateTransform3D(oStation1.X, oStation1.Y, oStation1.Z))

    '                    'Dim oModelPointTransformGroup As Transform3DGroup = New Transform3DGroup()
    '                    'Call oModelPointTransformGroup.Children.Add(New RotateTransform3D(New Media.Media3D.AxisAngleRotation3D(New Media.Media3D.Vector3D(0, 0, 1), sAngle)))
    '                    'Call oModelPointTransformGroup.Children.Add(New ScaleTransform3D(1.0 / oModelEdit.Scale, 1.0 / oModelEdit.Scale, 1.0 / oModelEdit.Scale))
    '                    'Call oModelPointTransformGroup.Children.Add(New TranslateTransform3D(oStation1.X, oStation1.Y, oStation1.Z))

    '                    'Dim oModelPoint1 As Point3D = oModelPointTransformGroup.Transform(oModelEdit.Point1)
    '                    'Dim oModelPoint2 As Point3D = oModelPointTransformGroup.Transform(oModelEdit.Point2)

    '                    ''adjust x, y and z or adjust only plan distance and z?
    '                    'Dim sXScale As Double = (oStation2.X - oStation1.X) / (oModelPoint2.X - oModelPoint1.X)
    '                    'Dim sYScale As Double = (oStation2.Y - oStation1.Y) / (oModelPoint2.Y - oModelPoint1.Y)
    '                    'Dim sZScale As Double = (oStation2.Z - oStation1.Z) / (oModelPoint2.Z - oModelPoint1.Z)
    '                    'Call oResultTransformGroup.Children.Add(New ScaleTransform3D(sXScale, sYScale, sZScale))

    '                    'oImportGroup.Transform = oResultTransformGroup
    '                    'oImportGroup.Content = oModel

    '                    'mainViewport.Children.Add(oImportGroup)
    '                End If
    '            End Using
    '        End If
    '    End Using
    'End Sub

    Public Sub Export(Optional Filename As String = "")
        Try
            Dim sSaveFilename As String = Filename
            If sSaveFilename = "" Then
                Using osfd As SaveFileDialog = New SaveFileDialog
                    With osfd
                        .FileName = sSaveFilename
                        .Filter = GetLocalizedString("holos.filetypeSTL") & " (*.STL)|*.STL|" & GetLocalizedString("holos.filetypeDAE") & " (*.DAE)|*.DAE|" & GetLocalizedString("holos.filetypeX3D") & " (*.X3D)|*.X3D|" & GetLocalizedString("holos.filetypeOBJ") & " (*.OBJ)|*.OBJ|" & GetLocalizedString("holos.filetypePNG") & " (*.PNG)|*.PNG|" & GetLocalizedString("holos.filetypeJPG") & " (*.JPG)|*.JPG"
                        .FilterIndex = modMain.FilterRestoreLast("export.3d", 1)
                        If .ShowDialog = Windows.Forms.DialogResult.OK Then
                            Call modMain.FilterSaveLast("export.3d", .FilterIndex)
                            sSaveFilename = .FileName
                        End If
                    End With
                End Using
            End If
            If sSaveFilename <> "" Then
                Select Case IO.Path.GetExtension(sSaveFilename).ToLower
                    Case ".png"
                        Call Viewport3DHelper.SaveBitmap(mainViewport.Viewport, sSaveFilename, Nothing, oSurvey.Properties.ThreeDExportAsImageOversamplingFactor, BitmapExporter.OutputFormat.Png)
                    Case ".jpg"
                        Call Viewport3DHelper.SaveBitmap(mainViewport.Viewport, sSaveFilename, Nothing, oSurvey.Properties.ThreeDExportAsImageOversamplingFactor, BitmapExporter.OutputFormat.Jpg)
                    Case Else
                        Call Viewport3DHelper.Export(mainViewport.Viewport, sSaveFilename)
                End Select
            End If
        Catch ex As Exception
            Call cSurvey.UIHelpers.Dialogs.Msgbox(modMain.GetLocalizedString("holos.warning1"), vbOKOnly, modMain.GetLocalizedString("holos.warningtitle"))
        End Try
    End Sub

    Public Enum SubPointIndexEnum
        Center = 0
        Left = 1
        Right = 2
        Up = 3
        Down = 4
    End Enum

    Private Shared Sub pAppend3DPoints(Points As Dictionary(Of String, PointF), Name As String, Point As PointF)
        If Points.ContainsKey(Name) Then
            Dim oOldPoint As PointF = Points(Name)
            If oOldPoint.IsEmpty Then
                Call Points.Remove(Name)
                Call Points.Add(Name, Point)
            End If
        Else
            Call Points.Add(Name, Point)
        End If
    End Sub

    Public Shared Function Get3DPoints(Survey As cSurveyPC.cSurvey.cSurvey, ByVal PaintOptions As cOptions3D, dX As Decimal, dY As Decimal, dZ As Decimal, HeightScale As Decimal) As Dictionary(Of String, List(Of Point3D))
        Dim oResPoints As Dictionary(Of String, List(Of Point3D)) = New Dictionary(Of String, List(Of Point3D))
        Dim oTrigpoints As HashSet(Of String) = New HashSet(Of String)

        Dim oPointPlans As Dictionary(Of String, PointF) = New Dictionary(Of String, PointF)
        Dim oPointProfiles As Dictionary(Of String, PointF) = New Dictionary(Of String, PointF)

        Dim oPointUps As Dictionary(Of String, PointF) = New Dictionary(Of String, PointF)
        Dim oPointDowns As Dictionary(Of String, PointF) = New Dictionary(Of String, PointF)
        Dim oPointLefts As Dictionary(Of String, PointF) = New Dictionary(Of String, PointF)
        Dim oPointRights As Dictionary(Of String, PointF) = New Dictionary(Of String, PointF)

        If Survey.Properties.ThreeDModelMode > cProperties.ThreeDModelModeEnum.Simple AndAlso (PaintOptions.DrawLRUD OrElse PaintOptions.DrawModel) Then
            For Each oSegment As cSegment In Survey.Segments
                If oSegment.IsValid AndAlso Not oSegment.IsSelfDefined Then
                    If oSegment.Data.SubDatas.Count = 0 Then
                        'for performance here may be usefull to detect if shot is a splay or is a shot without subdata...
                        'if is splay the stations have to be calculate only if splay are visible in paintoptions...
                        Dim sFrom As String = oSegment.From
                        Dim sTo As String = oSegment.To

                        If Not oTrigpoints.Contains(sFrom) Then oTrigpoints.Add(sFrom)
                        If Not oTrigpoints.Contains(sTo) Then oTrigpoints.Add(sTo)

                        If oSegment.Data.Data.Reversed Then
                            'If Not oPointPlans.ContainsKey(sTo) Then
                            Call pAppend3DPoints(oPointPlans, sTo, oSegment.Data.Plan.FromPoint)
                            Call pAppend3DPoints(oPointProfiles, sTo, oSegment.Data.Profile.FromPoint)
                            'End If
                            'If Not oPointUps.ContainsKey(sTo) Then
                            Call pAppend3DPoints(oPointUps, sTo, oSegment.Data.Profile.FromSidePointUp)
                            Call pAppend3DPoints(oPointDowns, sTo, oSegment.Data.Profile.FromSidePointDown)
                            Call pAppend3DPoints(oPointLefts, sTo, oSegment.Data.Plan.FromSidePointLeft)
                            Call pAppend3DPoints(oPointRights, sTo, oSegment.Data.Plan.FromSidePointRight)
                            'End If

                            'If Not oPointPlans.ContainsKey(sFrom) Then
                            Call pAppend3DPoints(oPointPlans, sFrom, oSegment.Data.Plan.ToPoint)
                            Call pAppend3DPoints(oPointProfiles, sFrom, oSegment.Data.Profile.ToPoint)
                            'End If
                            'If Not oPointUps.ContainsKey(sFrom) Then
                            Call pAppend3DPoints(oPointUps, sFrom, oSegment.Data.Profile.ToSidePointUp)
                            Call pAppend3DPoints(oPointDowns, sFrom, oSegment.Data.Profile.ToSidePointDown)
                            Call pAppend3DPoints(oPointLefts, sFrom, oSegment.Data.Plan.ToSidePointLeft)
                            Call pAppend3DPoints(oPointRights, sFrom, oSegment.Data.Plan.ToSidePointRight)
                            'End If
                        Else
                            'If Not oPointPlans.ContainsKey(sFrom) Then
                            Call pAppend3DPoints(oPointPlans, sFrom, oSegment.Data.Plan.FromPoint)
                            Call pAppend3DPoints(oPointProfiles, sFrom, oSegment.Data.Profile.FromPoint)
                            'End If
                            'If Not oPointUps.ContainsKey(sFrom) Then
                            Call pAppend3DPoints(oPointUps, sFrom, oSegment.Data.Profile.FromSidePointUp)
                            Call pAppend3DPoints(oPointDowns, sFrom, oSegment.Data.Profile.FromSidePointDown)
                            Call pAppend3DPoints(oPointLefts, sFrom, oSegment.Data.Plan.FromSidePointLeft)
                            Call pAppend3DPoints(oPointRights, sFrom, oSegment.Data.Plan.FromSidePointRight)
                            'End If

                            'If Not oPointPlans.ContainsKey(sTo) Then
                            Call pAppend3DPoints(oPointPlans, sTo, oSegment.Data.Plan.ToPoint)
                            Call pAppend3DPoints(oPointProfiles, sTo, oSegment.Data.Profile.ToPoint)
                            '    End If
                            'If Not oPointUps.ContainsKey(sTo) Then
                            Call pAppend3DPoints(oPointUps, sTo, oSegment.Data.Profile.ToSidePointUp)
                            Call pAppend3DPoints(oPointDowns, sTo, oSegment.Data.Profile.ToSidePointDown)
                            Call pAppend3DPoints(oPointLefts, sTo, oSegment.Data.Plan.ToSidePointLeft)
                            Call pAppend3DPoints(oPointRights, sTo, oSegment.Data.Plan.ToSidePointRight)
                            'End If
                        End If
                    Else
                        For Each oSubData As Calculate.Plot.cSubData In oSegment.Data.SubDatas
                            Dim sFrom As String
                            Dim sTo As String
                            If oSubData.Reversed Then
                                sFrom = oSubData.To
                                sTo = oSubData.From
                            Else
                                sFrom = oSubData.From
                                sTo = oSubData.To
                            End If

                            If Not oTrigpoints.Contains(sFrom) Then oTrigpoints.Add(sFrom)
                            If Not oTrigpoints.Contains(sTo) Then oTrigpoints.Add(sTo)

                            If oSubData.Reversed Then
                                'If Not oPointPlans.ContainsKey(sTo) Then
                                Call pAppend3DPoints(oPointPlans, sTo, oSubData.Plan.FromPoint)
                                Call pAppend3DPoints(oPointProfiles, sTo, oSubData.Profile.FromPoint)
                                'End If
                                'If Not oPointUps.ContainsKey(sTo) Then
                                Call pAppend3DPoints(oPointUps, sTo, oSubData.Profile.FromSidePointUp)
                                Call pAppend3DPoints(oPointDowns, sTo, oSubData.Profile.FromSidePointDown)
                                Call pAppend3DPoints(oPointLefts, sTo, oSubData.Plan.FromSidePointLeft)
                                Call pAppend3DPoints(oPointRights, sTo, oSubData.Plan.FromSidePointRight)
                                'End If

                                'If Not oPointPlans.ContainsKey(sFrom) Then
                                Call pAppend3DPoints(oPointPlans, sFrom, oSubData.Plan.ToPoint)
                                Call pAppend3DPoints(oPointProfiles, sFrom, oSubData.Profile.ToPoint)
                                'End If
                                'If Not oPointUps.ContainsKey(sFrom) Then
                                Call pAppend3DPoints(oPointUps, sFrom, oSubData.Profile.ToSidePointUp)
                                Call pAppend3DPoints(oPointDowns, sFrom, oSubData.Profile.ToSidePointDown)
                                Call pAppend3DPoints(oPointLefts, sFrom, oSubData.Plan.ToSidePointLeft)
                                Call pAppend3DPoints(oPointRights, sFrom, oSubData.Plan.ToSidePointRight)
                                'End If
                            Else
                                'If Not oPointPlans.ContainsKey(sFrom) Then
                                Call pAppend3DPoints(oPointPlans, sFrom, oSubData.Plan.FromPoint)
                                Call pAppend3DPoints(oPointProfiles, sFrom, oSubData.Profile.FromPoint)
                                'End If
                                'If Not oPointUps.ContainsKey(sFrom) Then
                                Call pAppend3DPoints(oPointUps, sFrom, oSubData.Profile.FromSidePointUp)
                                Call pAppend3DPoints(oPointDowns, sFrom, oSubData.Profile.FromSidePointDown)
                                Call pAppend3DPoints(oPointLefts, sFrom, oSubData.Plan.FromSidePointLeft)
                                Call pAppend3DPoints(oPointRights, sFrom, oSubData.Plan.FromSidePointRight)
                                'End If

                                'If Not oPointPlans.ContainsKey(sTo) Then
                                Call pAppend3DPoints(oPointPlans, sTo, oSubData.Plan.ToPoint)
                                Call pAppend3DPoints(oPointProfiles, sTo, oSubData.Profile.ToPoint)
                                'End If
                                'If Not oPointUps.ContainsKey(sTo) Then
                                Call pAppend3DPoints(oPointUps, sTo, oSubData.Profile.ToSidePointUp)
                                Call pAppend3DPoints(oPointDowns, sTo, oSubData.Profile.ToSidePointDown)
                                Call pAppend3DPoints(oPointLefts, sTo, oSubData.Plan.ToSidePointLeft)
                                Call pAppend3DPoints(oPointRights, sTo, oSubData.Plan.ToSidePointRight)
                                'End If
                            End If
                        Next
                    End If
                End If
            Next
        Else
            For Each oSegment As cSegment In Survey.Segments
                If oSegment.IsValid And Not oSegment.IsSelfDefined Then
                    Dim sFrom As String = oSegment.From
                    Dim sTo As String = oSegment.To

                    If Not oTrigpoints.Contains(sFrom) Then oTrigpoints.Add(sFrom)
                    If Not oTrigpoints.Contains(sTo) Then oTrigpoints.Add(sTo)

                    If oSegment.Data.Data.Reversed Then
                        'If Not oPointPlans.ContainsKey(sTo) Then
                        Call pAppend3DPoints(oPointPlans, sTo, oSegment.Data.Plan.FromPoint)
                        Call pAppend3DPoints(oPointProfiles, sTo, oSegment.Data.Profile.FromPoint)
                        'End If
                        'If Not oPointUps.ContainsKey(sTo) Then
                        Call pAppend3DPoints(oPointUps, sTo, oSegment.Data.Profile.FromSidePointUp)
                        Call pAppend3DPoints(oPointDowns, sTo, oSegment.Data.Profile.FromSidePointDown)
                        Call pAppend3DPoints(oPointLefts, sTo, oSegment.Data.Plan.FromSidePointLeft)
                        Call pAppend3DPoints(oPointRights, sTo, oSegment.Data.Plan.FromSidePointRight)
                        'End If

                        'If Not oPointPlans.ContainsKey(sFrom) Then
                        Call pAppend3DPoints(oPointPlans, sFrom, oSegment.Data.Plan.ToPoint)
                        Call pAppend3DPoints(oPointProfiles, sFrom, oSegment.Data.Profile.ToPoint)
                        'End If
                        'If Not oPointUps.ContainsKey(sFrom) Then
                        Call pAppend3DPoints(oPointUps, sFrom, oSegment.Data.Profile.ToSidePointUp)
                        Call pAppend3DPoints(oPointDowns, sFrom, oSegment.Data.Profile.ToSidePointDown)
                        Call pAppend3DPoints(oPointLefts, sFrom, oSegment.Data.Plan.ToSidePointLeft)
                        Call pAppend3DPoints(oPointRights, sFrom, oSegment.Data.Plan.ToSidePointRight)
                        'End If
                    Else
                        'If Not oPointPlans.ContainsKey(sFrom) Then
                        Call pAppend3DPoints(oPointPlans, sFrom, oSegment.Data.Plan.FromPoint)
                        Call pAppend3DPoints(oPointProfiles, sFrom, oSegment.Data.Profile.FromPoint)
                        'End If
                        'If Not oPointUps.ContainsKey(sFrom) Then
                        Call pAppend3DPoints(oPointUps, sFrom, oSegment.Data.Profile.FromSidePointUp)
                        Call pAppend3DPoints(oPointDowns, sFrom, oSegment.Data.Profile.FromSidePointDown)
                        Call pAppend3DPoints(oPointLefts, sFrom, oSegment.Data.Plan.FromSidePointLeft)
                        Call pAppend3DPoints(oPointRights, sFrom, oSegment.Data.Plan.FromSidePointRight)
                        'End If

                        'If Not oPointPlans.ContainsKey(sTo) Then
                        Call pAppend3DPoints(oPointPlans, sTo, oSegment.Data.Plan.ToPoint)
                        Call pAppend3DPoints(oPointProfiles, sTo, oSegment.Data.Profile.ToPoint)
                        '    End If
                        'If Not oPointUps.ContainsKey(sTo) Then
                        Call pAppend3DPoints(oPointUps, sTo, oSegment.Data.Profile.ToSidePointUp)
                        Call pAppend3DPoints(oPointDowns, sTo, oSegment.Data.Profile.ToSidePointDown)
                        Call pAppend3DPoints(oPointLefts, sTo, oSegment.Data.Plan.ToSidePointLeft)
                        Call pAppend3DPoints(oPointRights, sTo, oSegment.Data.Plan.ToSidePointRight)
                        'End If
                    End If
                End If
            Next
        End If

        For Each sTrigPoint As String In oTrigpoints
            Dim oResPoint As List(Of Point3D) = New List(Of Point3D)()
            Dim sName As String = sTrigPoint

            Dim oPointPlan As PointF = oPointPlans(sName)
            Dim oPointProfile As PointF = oPointProfiles(sName)
            Dim x As Decimal = oPointPlan.X + dX
            Dim y As Decimal = -oPointPlan.Y + dY
            Dim z As Decimal = -oPointProfile.Y + dZ ' oPos.Altitude - oOriginPos.Altitude
            Call oResPoint.Add(New Point3D(x, y, z * HeightScale))

            Dim oPointLeft As PointF = oPointLefts(sName)
            Call oResPoint.Add(New Point3D(x + (oPointLeft.X - oPointPlan.X), y - (oPointLeft.Y - oPointPlan.Y), z * HeightScale))
            Dim oPointRight As PointF = oPointRights(sName)
            Call oResPoint.Add(New Point3D(x + (oPointRight.X - oPointPlan.X), y - (oPointRight.Y - oPointPlan.Y), z * HeightScale))
            Dim oPointUp As PointF = oPointUps(sName)
            Call oResPoint.Add(New Point3D(x, y, (z - (oPointUp.Y - oPointProfile.Y)) * HeightScale))
            Dim oPointDown As PointF = oPointDowns(sName)
            Call oResPoint.Add(New Point3D(x, y, (z - (oPointDown.Y - oPointProfile.Y)) * HeightScale))

            Call oResPoints.Add(sName, oResPoint)
        Next
        'Next
        Return oResPoints
    End Function

    Public Shared Function GetStations3DPoints(Survey As cSurveyPC.cSurvey.cSurvey, ByVal dX As Decimal, dY As Decimal, dZ As Decimal, HeightScale As Decimal) As Dictionary(Of String, List(Of Point3D))
        Dim oResPoints As Dictionary(Of String, List(Of Point3D)) = New Dictionary(Of String, List(Of Point3D))
        Dim oTrigpoints As HashSet(Of String) = New HashSet(Of String)

        Dim oPointPlans As Dictionary(Of String, PointF) = New Dictionary(Of String, PointF)
        Dim oPointProfiles As Dictionary(Of String, PointF) = New Dictionary(Of String, PointF)

        For Each oSegment As cSegment In Survey.Segments
            If oSegment.IsValid AndAlso Not oSegment.IsSelfDefined AndAlso Not oSegment.Splay Then
                Dim sFrom As String = oSegment.From
                Dim sTo As String = oSegment.To

                If Not oTrigpoints.Contains(sFrom) Then oTrigpoints.Add(sFrom)
                If Not oTrigpoints.Contains(sTo) Then oTrigpoints.Add(sTo)

                If oSegment.Data.Data.Reversed Then
                    Call pAppend3DPoints(oPointPlans, sTo, oSegment.Data.Plan.FromPoint)
                    Call pAppend3DPoints(oPointProfiles, sTo, oSegment.Data.Profile.FromPoint)

                    Call pAppend3DPoints(oPointPlans, sFrom, oSegment.Data.Plan.ToPoint)
                    Call pAppend3DPoints(oPointProfiles, sFrom, oSegment.Data.Profile.ToPoint)
                Else
                    Call pAppend3DPoints(oPointPlans, sFrom, oSegment.Data.Plan.FromPoint)
                    Call pAppend3DPoints(oPointProfiles, sFrom, oSegment.Data.Profile.FromPoint)

                    Call pAppend3DPoints(oPointPlans, sTo, oSegment.Data.Plan.ToPoint)
                    Call pAppend3DPoints(oPointProfiles, sTo, oSegment.Data.Profile.ToPoint)
                End If
            End If
        Next

        For Each sTrigPoint As String In oTrigpoints
            Dim oResPoint As List(Of Point3D) = New List(Of Point3D)
            Dim sName As String = sTrigPoint

            Dim oPointPlan As PointF = oPointPlans(sName)
            Dim oPointProfile As PointF = oPointProfiles(sName)
            Dim x As Decimal = oPointPlan.X + dX
            Dim y As Decimal = -oPointPlan.Y + dY
            Dim z As Decimal = -oPointProfile.Y + dZ
            Call oResPoint.Add(New Point3D(x, y, z * HeightScale))

            Call oResPoints.Add(sName, oResPoint)
        Next
        'Next
        Return oResPoints
    End Function

    Private Class cFromTo
        Private sFrom As String
        Private sTo As String

        Public ReadOnly Property From As String
            Get
                Return sFrom
            End Get
        End Property

        Public ReadOnly Property [To] As String
            Get
                Return sTo
            End Get
        End Property

        Public Sub New(From As String, [To] As String)
            sFrom = [From]
            sTo = [To]
        End Sub

        Public Sub New(Segment As cSegment)
            sFrom = Segment.[From]
            sTo = Segment.[To]
        End Sub

        Public Sub New(SubData As Calculate.Plot.cSubData)
            sFrom = SubData.[From]
            sTo = SubData.[To]
        End Sub
    End Class

    Private Sub pCaves(ByVal PaintOptions As cOptions3D, Selection As Helper.Editor.cIEditDesignSelection)
        Dim dHeightScale As Double = PaintOptions.SurfaceOptions.Elevation.AltitudeAmplification
        Dim iMinSize As Integer = 1

        Dim sMainOriginX As Single = 0
        Dim sMainOriginY As Single = 0
        Dim sMainOriginZ As Single = 0
        Dim oMainCoordinate As Calculate.cTrigPointCoordinate = oSurvey.Calculate.TrigPoints(oSurvey.TrigPoints.GetOrigin).Coordinate
        If Not oMainCoordinate Is Nothing Then
            With oMainCoordinate
                Dim oUTM As modUTM.UTM = New modUTM.UTM(oMainCoordinate)
                sMainOriginX = oUTM.East
                sMainOriginY = oUTM.North
                sMainOriginZ = .Altitude()
            End With
        End If

        Dim oSurveys As List(Of cSurveyPC.cSurvey.cSurvey) = New List(Of cSurveyPC.cSurvey.cSurvey)
        If PaintOptions.DrawLinkedSurveys Then
            Call oSurveys.AddRange(oSurvey.LinkedSurveys.GetSelected("design.3d").Select(Function(oItem) oItem.LinkedSurvey).ToList)
        End If
        Call oSurveys.Add(oSurvey)

        Call oCmCaves.Clear()
        Call oModels.Clear()
        For Each oCurrentSurvey As cSurveyPC.cSurvey.cSurvey In oSurveys
            Dim bIsThisSurvey As Boolean = oCurrentSurvey Is oSurvey

            Dim sOriginX As Single = 0
            Dim sOriginY As Single = 0
            Dim sOriginZ As Single = 0
            Dim oCoordinate As Calculate.cTrigPointCoordinate = oCurrentSurvey.Calculate.TrigPoints(oCurrentSurvey.TrigPoints.GetOrigin).Coordinate
            If Not oCoordinate Is Nothing Then
                With oCoordinate
                    Dim oUTM As modUTM.UTM = New modUTM.UTM(oCoordinate)
                    sOriginX = oUTM.East
                    sOriginY = oUTM.North
                    Dim oSizePoint As SizeF = New SizeD(sOriginX - sMainOriginX, sOriginY - sMainOriginY)
                    Dim oMovePoint As PointD = modPaint.RotatePointByRadians(New PointD(oSizePoint.Width, oSizePoint.Height), oSurvey.Calculate.GeoMagDeclinationData.MeridianConvergenceRadians)
                    sOriginX = oMovePoint.X
                    sOriginY = oMovePoint.Y
                    sOriginZ = .Altitude()
                End With
            End If
            Dim oPoints As Dictionary(Of String, List(Of Point3D)) = Get3DPoints(oCurrentSurvey, PaintOptions, sOriginX, sOriginY, sOriginZ, dHeightScale)

            Dim oDrawingObject As cOptionsDrawingObjects = PaintOptions.DrawingObjects
            Dim oShotByColor As Dictionary(Of Color, List(Of cSurvey.cSegment)) = New Dictionary(Of Color, List(Of cSurvey.cSegment))()
            Dim oSplayShotByColor As Dictionary(Of Color, List(Of cSurvey.cSegment)) = New Dictionary(Of Color, List(Of cSurvey.cSegment))()
            For Each oCaveInfo As cSurvey.cCaveInfo In oCurrentSurvey.Properties.CaveInfos.GetWithEmpty.Values
                For Each oCaveInfoBranch As cSurvey.cCaveInfoBranch In oCaveInfo.Branches.GetAllBranchesWithEmpty.Values
                    For Each oShot As cSurvey.cSegment In oCaveInfoBranch.GetSegments
                        If modDesign.GetIfSegmentMustBeDrawedByCaveAndBranch(PaintOptions, oShot, Selection.CurrentCave, Selection.CurrentBranch) Then
                            If oShot.IsValid AndAlso Not oShot.IsSelfDefined Then
                                Dim bVisible As Boolean = True
                                If oShot.Splay Then
                                    bVisible = PaintOptions.DrawSplay
                                End If
                                If oShot.Surface Then
                                    bVisible = (PaintOptions.DrawSegmentsOptions And cOptionsDesign.DrawSegmentsOptionsEnum.Surface) = cOptionsDesign.DrawSegmentsOptionsEnum.Surface
                                End If
                                If oShot.Duplicate Then
                                    bVisible = (PaintOptions.DrawSegmentsOptions And cOptionsDesign.DrawSegmentsOptionsEnum.Duplicate) = cOptionsDesign.DrawSegmentsOptionsEnum.Duplicate
                                End If
                                If bVisible Then
                                    Dim oColor As Drawing.Color
                                    Dim oCaveColor As Color
                                    If oShot.Splay Then
                                        If oShot.Data.SegmentColor = Color.Transparent Then
                                            Select Case PaintOptions.CenterlineColorMode
                                                Case cOptionsDesign.CenterlineColorModeEnum.CavesAndBranches
                                                    oCaveColor = oCurrentSurvey.Properties.CaveInfos.GetColor(oShot, oDrawingObject.PenColor)
                                                Case cOptionsDesign.CenterlineColorModeEnum.OnlyCaves
                                                    oCaveColor = oCurrentSurvey.Properties.CaveInfos.GetColor(oShot.Cave, "", oDrawingObject.PenColor)
                                                Case cOptionsDesign.CenterlineColorModeEnum.ExtendStart
                                                    oCaveColor = oCurrentSurvey.Properties.CaveInfos.GetOriginColor(oShot, oDrawingObject.PenColor)
                                            End Select
                                            oColor = modPaint.LightColor(oCaveColor, 0.3)
                                        Else
                                            oColor = modPaint.LightColor(oShot.Data.SegmentColor, 0.3)
                                        End If
                                        If PaintOptions.CenterlineColorGray Then
                                            oColor = modPaint.GrayColor(oColor)
                                        End If

                                        If PaintOptions.DrawSplay AndAlso (PaintOptions.SplayStyle = cOptionsDesign.SplayStyleEnum.PointsAndRays OrElse PaintOptions.SplayStyle = cOptionsDesign.SplayStyleEnum.Rays) Then
                                            oColor = modPaint.LightColor(oColor, 0.3)
                                            If oSplayShotByColor.ContainsKey(oColor) Then
                                                Dim oShots As List(Of cSurvey.cSegment) = oSplayShotByColor(oColor)
                                                If Not oShots.Contains(oShot) Then oShots.Add(oShot)
                                            Else
                                                Dim oShots As List(Of cSurvey.cSegment) = New List(Of cSurvey.cSegment)
                                                Call oShots.Add(oShot)
                                                Call oSplayShotByColor.Add(oColor, oShots)
                                            End If
                                        End If
                                    Else
                                        If oShot.Data.SegmentColor = Color.Transparent Then
                                            Select Case PaintOptions.CenterlineColorMode
                                                Case 0
                                                    oCaveColor = oCurrentSurvey.Properties.CaveInfos.GetColor(oShot, oDrawingObject.PenColor)
                                                Case 1
                                                    oCaveColor = oCurrentSurvey.Properties.CaveInfos.GetColor(oShot.Cave, "", oDrawingObject.PenColor)
                                            End Select
                                            oColor = modPaint.DarkColor(oCaveColor, 0.2)
                                        Else
                                            oColor = modPaint.DarkColor(oShot.Data.SegmentColor, 0.2)
                                        End If
                                        'End If
                                        If PaintOptions.CenterlineColorGray Then
                                            oColor = modPaint.GrayColor(oColor)
                                        End If

                                        If oShotByColor.ContainsKey(oColor) Then
                                            Dim oShots As List(Of cSurvey.cSegment) = oShotByColor(oColor)
                                            If Not oShots.Contains(oShot) Then oShots.Add(oShot)
                                        Else
                                            Dim oShots As List(Of cSurvey.cSegment) = New List(Of cSurvey.cSegment)
                                            Call oShots.Add(oShot)
                                            Call oShotByColor.Add(oColor, oShots)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next
            Next

            If PaintOptions.DrawPlot Then
                oSelectors = New ModelVisual3D
                Dim oTransparentMaterial As EmissiveMaterial = New EmissiveMaterial(Media.Brushes.Transparent)

                Dim iIndex As Integer = 0
                Dim iCount As Integer = oShotByColor.Sum(Function(item) item.Value.Count)
                Call oSurvey.RaiseOnProgressEvent("3dmodel", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("holos.progressbegin1"), 0, cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.Image3D Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow)

                For Each oColor As Color In oShotByColor.Keys
                    Dim oFinalColor As Color
                    If Not bIsThisSurvey Then
                        oFinalColor = modPaint.LightColor(oColor, 0.5) ' Color.FromArgb(150, oColor)
                    Else
                        oFinalColor = oColor
                    End If
                    Dim oMediaColor As Media.Color = Media.Color.FromArgb(oFinalColor.A, oFinalColor.R, oFinalColor.G, oFinalColor.B)

                    Dim oPlot As HelixToolkit.Wpf.LinesVisual3D = New HelixToolkit.Wpf.LinesVisual3D
                    oPlot.Color = oMediaColor
                    oPlot.Thickness = 2

                    Dim oLRUDPlot As HelixToolkit.Wpf.LinesVisual3D
                    Dim oLRUDPlotFishbone As MeshGeometry3D
                    Select Case PaintOptions.DrawStyle
                        Case cOptionsDesign.DrawStyleEnum.OnlySegment
                            oLRUDPlot = New HelixToolkit.Wpf.LinesVisual3D
                            oLRUDPlot.Color = oMediaColor
                        Case cOptionsDesign.DrawStyleEnum.Solid
                            oLRUDPlotFishbone = New MeshGeometry3D
                            oLRUDPlot = New HelixToolkit.Wpf.LinesVisual3D
                            oLRUDPlot.Color = oMediaColor
                        Case cOptionsDesign.DrawStyleEnum.Transparent
                            oLRUDPlotFishbone = New MeshGeometry3D
                            oLRUDPlot = New HelixToolkit.Wpf.LinesVisual3D
                            oLRUDPlot.Color = oMediaColor
                        Case cOptionsDesign.DrawStyleEnum.Light
                            oLRUDPlot = New HelixToolkit.Wpf.LinesVisual3D
                            oLRUDPlot.Color = oMediaColor
                    End Select

                    For Each oShot As cSurvey.cSegment In oShotByColor(oColor)
                        iIndex += 1
                        If iIndex Mod 20 = 0 Then Call oSurvey.RaiseOnProgressEvent("3dmodel", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("holos.progress1"), iIndex / iCount)
                        Dim oFromToList As List(Of cFromTo) = New List(Of cFromTo)
                        If oCurrentSurvey.Properties.ThreeDModelMode > cProperties.ThreeDModelModeEnum.Simple AndAlso PaintOptions.DrawLRUD Then
                            For Each oSubData As Calculate.Plot.cSubData In oShot.Data.SubDatas
                                Call oFromToList.Add(New cFromTo(oSubData))
                            Next
                        Else
                            Call oFromToList.Add(New cFromTo(oShot))
                        End If
                        For Each oFromTo As cFromTo In oFromToList
                            Dim sFrom As String = oFromTo.From ' oShot.From
                            Dim sTo As String = oFromTo.To
                            Dim oFrom As List(Of Point3D) = oPoints(sFrom)
                            Dim oTo As List(Of Point3D) = oPoints(sTo)
                            If PaintOptions.DrawSegments Then
                                Call oPlot.Points.Add(oFrom(SubPointIndexEnum.Center))
                                Call oPlot.Points.Add(oTo(SubPointIndexEnum.Center))

                                If bIsThisSurvey Then
                                    Dim oHotSpotPlot As HelixToolkit.Wpf.TubeVisual3D = New HelixToolkit.Wpf.TubeVisual3D
                                    Call oHotSpotPlot.Path.Add(oFrom(SubPointIndexEnum.Center))
                                    Call oHotSpotPlot.Path.Add(oTo(SubPointIndexEnum.Center))
                                    oHotSpotPlot.Material = oTransparentMaterial
                                    oHotSpotPlot.BackMaterial = oTransparentMaterial
                                    Call oSelectors.Children.Add(oHotSpotPlot)
                                    Call oCavesHotSpots.Add(oHotSpotPlot, New cHotSpot(oHotSpotPlot, oShot))
                                End If
                            End If

                            If PaintOptions.DrawLRUD Then
                                Dim bFromDrawLR As Boolean = oFrom(SubPointIndexEnum.Center).DistanceTo(oFrom(SubPointIndexEnum.Left)) > 0.001 OrElse oFrom(SubPointIndexEnum.Center).DistanceTo(oFrom(SubPointIndexEnum.Right)) > 0.001
                                Dim bFromDrawUD As Boolean = oFrom(SubPointIndexEnum.Center).DistanceTo(oFrom(SubPointIndexEnum.Up)) > 0.001 OrElse oFrom(SubPointIndexEnum.Center).DistanceTo(oFrom(SubPointIndexEnum.Down)) > 0.001
                                Dim bToDrawLR As Boolean = oTo(SubPointIndexEnum.Center).DistanceTo(oTo(SubPointIndexEnum.Left)) > 0.001 OrElse oTo(SubPointIndexEnum.Center).DistanceTo(oTo(SubPointIndexEnum.Right)) > 0.001
                                Dim bToDrawUD As Boolean = oTo(SubPointIndexEnum.Center).DistanceTo(oTo(SubPointIndexEnum.Up)) > 0.001 OrElse oTo(SubPointIndexEnum.Center).DistanceTo(oTo(SubPointIndexEnum.Down)) > 0.001

                                Select Case PaintOptions.DrawStyle
                                    Case cOptionsDesign.DrawStyleEnum.OnlySegment
                                        If bFromDrawLR Then
                                            Call oLRUDPlot.Points.Add(oFrom(SubPointIndexEnum.Left))
                                            Call oLRUDPlot.Points.Add(oFrom(SubPointIndexEnum.Right))
                                        End If
                                        If bToDrawLR Then
                                            Call oLRUDPlot.Points.Add(oTo(SubPointIndexEnum.Left))
                                            Call oLRUDPlot.Points.Add(oTo(SubPointIndexEnum.Right))
                                        End If
                                        If bFromDrawUD Then
                                            Call oLRUDPlot.Points.Add(oFrom(SubPointIndexEnum.Up))
                                            Call oLRUDPlot.Points.Add(oFrom(SubPointIndexEnum.Down))
                                        End If
                                        If bToDrawUD Then
                                            Call oLRUDPlot.Points.Add(oTo(SubPointIndexEnum.Up))
                                            Call oLRUDPlot.Points.Add(oTo(SubPointIndexEnum.Down))
                                        End If

                                    Case cOptionsDesign.DrawStyleEnum.Solid, cOptionsDesign.DrawStyleEnum.Transparent
                                        If bFromDrawLR OrElse bToDrawLR Then
                                            oLRUDPlotFishbone.Positions.Add(oFrom(SubPointIndexEnum.Left))
                                            oLRUDPlotFishbone.Positions.Add(oTo(SubPointIndexEnum.Left))
                                            oLRUDPlotFishbone.Positions.Add(oTo(SubPointIndexEnum.Right))
                                            oLRUDPlotFishbone.Positions.Add(oFrom(SubPointIndexEnum.Left))
                                            oLRUDPlotFishbone.Positions.Add(oTo(SubPointIndexEnum.Right))
                                            oLRUDPlotFishbone.Positions.Add(oFrom(SubPointIndexEnum.Right))
                                        End If

                                        If bFromDrawUD OrElse bToDrawUD Then
                                            oLRUDPlotFishbone.Positions.Add(oFrom(SubPointIndexEnum.Up))
                                            oLRUDPlotFishbone.Positions.Add(oTo(SubPointIndexEnum.Up))
                                            oLRUDPlotFishbone.Positions.Add(oTo(SubPointIndexEnum.Down))
                                            oLRUDPlotFishbone.Positions.Add(oFrom(SubPointIndexEnum.Up))
                                            oLRUDPlotFishbone.Positions.Add(oTo(SubPointIndexEnum.Down))
                                            oLRUDPlotFishbone.Positions.Add(oFrom(SubPointIndexEnum.Down))
                                        End If

                                    Case cOptionsDesign.DrawStyleEnum.Light
                                        If bFromDrawLR OrElse bToDrawLR Then
                                            Call oLRUDPlot.Points.Add(oFrom(SubPointIndexEnum.Left))
                                            Call oLRUDPlot.Points.Add(oTo(SubPointIndexEnum.Left))
                                            Call oLRUDPlot.Points.Add(oTo(SubPointIndexEnum.Left))
                                            Call oLRUDPlot.Points.Add(oTo(SubPointIndexEnum.Right))
                                            Call oLRUDPlot.Points.Add(oTo(SubPointIndexEnum.Right))
                                            Call oLRUDPlot.Points.Add(oFrom(SubPointIndexEnum.Right))
                                            Call oLRUDPlot.Points.Add(oFrom(SubPointIndexEnum.Right))
                                            Call oLRUDPlot.Points.Add(oFrom(SubPointIndexEnum.Left))
                                        End If
                                        If bFromDrawUD OrElse bToDrawUD Then
                                            Call oLRUDPlot.Points.Add(oFrom(SubPointIndexEnum.Up))
                                            Call oLRUDPlot.Points.Add(oTo(SubPointIndexEnum.Up))
                                            Call oLRUDPlot.Points.Add(oTo(SubPointIndexEnum.Up))
                                            Call oLRUDPlot.Points.Add(oTo(SubPointIndexEnum.Down))
                                            Call oLRUDPlot.Points.Add(oTo(SubPointIndexEnum.Down))
                                            Call oLRUDPlot.Points.Add(oFrom(SubPointIndexEnum.Down))
                                            Call oLRUDPlot.Points.Add(oFrom(SubPointIndexEnum.Down))
                                            Call oLRUDPlot.Points.Add(oFrom(SubPointIndexEnum.Up))
                                        End If
                                End Select
                            End If
                        Next
                    Next
                    If Not IsNothing(oPlot) AndAlso oPlot.Points.Count > 0 Then Call oPlots.Add(oPlot)
                    If Not IsNothing(oLRUDPlot) AndAlso oLRUDPlot.Points.Count > 0 Then Call oPlots.Add(oLRUDPlot)
                    If Not IsNothing(oLRUDPlotFishbone) AndAlso oLRUDPlotFishbone.Positions.Count > 0 Then
                        Dim oLRUDPlotFishboneVisual As MeshGeometryVisual3D = New MeshGeometryVisual3D
                        oLRUDPlotFishboneVisual.MeshGeometry = oLRUDPlotFishbone
                        Dim oMaterial As Material
                        Select Case PaintOptions.DrawStyle
                            Case cOptionsDesign.DrawStyleEnum.Solid
                                oMaterial = New DiffuseMaterial(New Media.SolidColorBrush(oMediaColor))
                            Case cOptionsDesign.DrawStyleEnum.Transparent
                                oMaterial = New DiffuseMaterial(New Media.SolidColorBrush(Media.Color.FromArgb(oColor.A * 0.4, oColor.R, oColor.G, oColor.B)))
                        End Select
                        oLRUDPlotFishboneVisual.Material = oMaterial
                        oLRUDPlotFishboneVisual.BackMaterial = oMaterial
                        Call oPlots.Add(oLRUDPlotFishboneVisual)
                    End If
                Next

                Call oSurvey.RaiseOnProgressEvent("3dmodel", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)
                If PaintOptions.DrawSplay Then
                    If PaintOptions.SplayStyle = cOptionsDesign.SplayStyleEnum.PointsAndRays OrElse PaintOptions.SplayStyle = cOptionsDesign.SplayStyleEnum.Rays Then
                        Dim iSplayIndex As Integer = 0
                        Dim iSplayCount As Integer = oSplayShotByColor.Sum(Function(item) item.Value.Count)
                        Call oSurvey.RaiseOnProgressEvent("3dmodel", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("holos.progressbegin2"), 0, cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.Image3D Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow)

                        For Each oColor As Color In oSplayShotByColor.Keys
                            Dim oMediaColor As Media.Color = Media.Color.FromArgb(oColor.A, oColor.R, oColor.G, oColor.B)
                            Dim oPlot As HelixToolkit.Wpf.LinesVisual3D = New HelixToolkit.Wpf.LinesVisual3D
                            oPlot.Color = oMediaColor
                            oPlot.Thickness = 0.5
                            For Each oShot As cSurvey.cSegment In oSplayShotByColor(oColor)
                                iSplayIndex += 1
                                If iSplayIndex Mod 20 = 0 Then Call oSurvey.RaiseOnProgressEvent("3dmodel", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("holos.progress2"), iSplayIndex / iSplayCount)

                                Dim sFrom As String = oShot.From
                                Dim sTo As String = oShot.To
                                If oPoints.ContainsKey(sFrom) AndAlso oPoints.ContainsKey(sTo) Then
                                    Dim oFrom As List(Of Point3D) = oPoints(sFrom)
                                    Dim oTo As List(Of Point3D) = oPoints(sTo)
                                    Call oPlot.Points.Add(oFrom(SubPointIndexEnum.Center))
                                    Call oPlot.Points.Add(oTo(SubPointIndexEnum.Center))
                                End If
                            Next
                            If oPlot.Points.Count > 0 Then Call oPlots.Add(oPlot)
                        Next
                        Call oSurvey.RaiseOnProgressEvent("3dmodel", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)
                    End If
                End If

                Dim oStationLabelList As List(Of HelixToolkit.Wpf.BillboardTextItem) = New List(Of HelixToolkit.Wpf.BillboardTextItem)

                'create a list of stations to draw...
                Dim oStations As HashSet(Of String) = New HashSet(Of String)
                For Each oCaveInfo As cSurvey.cCaveInfo In oCurrentSurvey.Properties.CaveInfos.GetWithEmpty.Values
                    For Each oCaveInfoBranch As cSurvey.cCaveInfoBranch In oCaveInfo.Branches.GetAllBranchesWithEmpty.Values
                        For Each oShot As cSurvey.cSegment In oCaveInfoBranch.GetSegments
                            If modDesign.GetIfSegmentMustBeDrawedByCaveAndBranch(PaintOptions, oShot, Selection.CurrentCave, Selection.CurrentBranch) Then
                                If oShot.IsValid AndAlso Not oShot.IsSelfDefined Then
                                    Dim bVisible As Boolean = True
                                    If oShot.Splay Then
                                        bVisible = (PaintOptions.DrawSplay AndAlso (PaintOptions.SplayStyle = cOptionsDesign.SplayStyleEnum.Points OrElse PaintOptions.SplayStyle = cOptionsDesign.SplayStyleEnum.PointsAndRays))
                                    End If
                                    If oShot.Surface Then
                                        bVisible = (PaintOptions.DrawSegmentsOptions And cOptionsDesign.DrawSegmentsOptionsEnum.Surface) = cOptionsDesign.DrawSegmentsOptionsEnum.Surface
                                    End If
                                    If oShot.Duplicate Then
                                        bVisible = (PaintOptions.DrawSegmentsOptions And cOptionsDesign.DrawSegmentsOptionsEnum.Duplicate) = cOptionsDesign.DrawSegmentsOptionsEnum.Duplicate
                                    End If
                                    If bVisible Then
                                        If Not oStations.Contains(oShot.From) Then oStations.Add(oShot.From)
                                        If Not oStations.Contains(oShot.To) Then oStations.Add(oShot.To)
                                    End If
                                End If
                            End If
                        Next
                    Next
                Next

                Dim iStationsIndex As Integer = 0
                Dim iStationsCount As Integer = oStations.Count
                Call oSurvey.RaiseOnProgressEvent("3dmodel", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("holos.progressbegin3"), 0, cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.Image3D Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow)

                'and draw it
                Dim oStationPoints As HelixToolkit.Wpf.PointsVisual3D = New HelixToolkit.Wpf.PointsVisual3D
                oStationPoints.Color = Media.Colors.Gray
                oStationPoints.Size = 0.5
                For Each sStation As String In oStations
                    iStationsIndex += 1
                    If iStationsIndex Mod 20 = 0 Then Call oSurvey.RaiseOnProgressEvent("3dmodel", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("holos.progress3"), iStationsIndex / iStationsCount)

                    Dim oStation As cTrigPoint = oCurrentSurvey.TrigPoints(sStation)
                    If Not oStation.IsSystem AndAlso oPoints.ContainsKey(oStation.Name) Then
                        If oStation.Data.IsSplay Then
                            If PaintOptions.DrawSplay Then
                                Call oStationPoints.Points.Add(oPoints(oStation.Name)(0))
                                If bIsThisSurvey Then
                                    Dim oStationPointSelector As HelixToolkit.Wpf.CubeVisual3D = New HelixToolkit.Wpf.CubeVisual3D
                                    oStationPointSelector.Center = oPoints(oStation.Name)(0)
                                    oStationPointSelector.SideLength = 0.2
                                    oStationPointSelector.Material = oTransparentMaterial
                                    oStationPointSelector.BackMaterial = oTransparentMaterial
                                    Call oCavesHotSpots.Add(oStationPointSelector, New cHotSpot(oStationPointSelector, oStation))
                                    Call oSelectors.Children.Add(oStationPointSelector)
                                End If
                            End If
                        Else
                            If PaintOptions.DrawPoints Then
                                oStationPoints.Points.Add(oPoints(oStation.Name)(0))
                                If bIsThisSurvey Then
                                    Dim oStationPointSelector As HelixToolkit.Wpf.CubeVisual3D = New HelixToolkit.Wpf.CubeVisual3D
                                    oStationPointSelector.Center = oPoints(oStation.Name)(0)
                                    oStationPointSelector.SideLength = 0.5
                                    oStationPointSelector.Material = oTransparentMaterial
                                    oStationPointSelector.BackMaterial = oTransparentMaterial
                                    Call oCavesHotSpots.Add(oStationPointSelector, New cHotSpot(oStationPointSelector, oStation))
                                    Call oSelectors.Children.Add(oStationPointSelector)
                                End If
                            End If
                        End If

                        If oStation.Data.IsSplay Then
                            If PaintOptions.DrawSplay AndAlso PaintOptions.ShowSplayText Then
                                Dim oStationLabel As HelixToolkit.Wpf.BillboardTextItem = New HelixToolkit.Wpf.BillboardTextItem
                                oStationLabel.Text = oStation.Name
                                oStationLabel.Position = oPoints(oStation.Name)(0)
                                oStationLabel.DepthOffset = 0
                                Call oStationLabelList.Add(oStationLabel)
                            End If
                        Else
                            If PaintOptions.ShowPointText Then
                                Dim oStationLabel As HelixToolkit.Wpf.BillboardTextItem = New HelixToolkit.Wpf.BillboardTextItem
                                oStationLabel.Text = oStation.Name
                                oStationLabel.Position = oPoints(oStation.Name)(0)
                                oStationLabel.DepthOffset = 0
                                Call oStationLabelList.Add(oStationLabel)
                            End If
                        End If
                    End If
                Next
                Call oSurvey.RaiseOnProgressEvent("3dmodel", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)

                If oStationLabelList.Count > 0 Then
                    Dim oStationLabels As HelixToolkit.Wpf.BillboardTextGroupVisual3D = New HelixToolkit.Wpf.BillboardTextGroupVisual3D
                    oStationLabels.Background = Windows.Media.Brushes.Transparent
                    oStationLabels.FontSize = 10
                    oStationLabels.Items = oStationLabelList
                    Call oCaves.Add(oStationLabels)
                End If
                If oStationPoints.Points.Count > 0 Then Call oCaves.Add(oStationPoints)
            End If

            If PaintOptions.DrawModel Then
                Dim oStationToPiketDict = New Dictionary(Of String, Integer)
                'If bIsThisSurvey Then
                Dim cmCave As DNetCMCave = New DNetCMCave
                'Else
                'End If

                Dim addStationFunc = Sub(Station As String, extendedElevationX As Double)
                                         If Not oStationToPiketDict.ContainsKey(Station) Then
                                             Dim oStation As cTrigPoint = oCurrentSurvey.TrigPoints(Station)
                                             Dim piket As DNPiketInfo = New DNPiketInfo
                                             Dim pos3D As Point3D = oPoints(Station)(SubPointIndexEnum.Center)
                                             piket.name = Station
                                             piket.label = Station
                                             piket.x = pos3D.X
                                             piket.y = pos3D.Y
                                             piket.z = pos3D.Z
                                             piket.extendedElevationX = extendedElevationX
                                             ' piket.r = 0
                                             'piket.g = 0
                                             'piket.b = 0
                                             'If (zSurvey) Then piket.priz = piket.priz Or DNPike(tMark.MARK_Z_SURVEY

                                             'if ostation is nothing is because is not a real station but a subdata station...so 
                                             'it cannot be zturn station...
                                             If Not IsNothing(oStation) AndAlso oStation.ZTurn Then piket.priz = piket.priz Or DNPiketMark.MARK_Z_TURN

                                             cmCave.addVertice(piket, 0)

                                             Dim left As Point3D = oPoints(Station)(SubPointIndexEnum.Left)
                                             Dim right As Point3D = oPoints(Station)(SubPointIndexEnum.Right)
                                             Dim up As Point3D = oPoints(Station)(SubPointIndexEnum.Up)
                                             Dim down As Point3D = oPoints(Station)(SubPointIndexEnum.Down)
                                             If pos3D.DistanceTo(left) > 0.001 Then
                                                 cmCave.addWall(left.X, left.Y, left.Z, piket.id, piket.id)
                                             End If
                                             If pos3D.DistanceTo(right) > 0.001 Then
                                                 cmCave.addWall(right.X, right.Y, right.Z, piket.id, piket.id)
                                             End If
                                             If pos3D.DistanceTo(up) > 0.001 Then
                                                 cmCave.addWall(up.X, up.Y, up.Z, piket.id, piket.id)
                                             End If
                                             If pos3D.DistanceTo(down) > 0.001 Then
                                                 cmCave.addWall(down.X, down.Y, down.Z, piket.id, piket.id)
                                             End If

                                             oStationToPiketDict(Station) = piket.id
                                         End If
                                     End Sub

                Dim oShots As List(Of cSurvey.cSegment) = New List(Of cSurvey.cSegment)
                For Each oCaveInfo As cSurvey.cCaveInfo In oCurrentSurvey.Properties.CaveInfos.GetWithEmpty.Values
                    For Each oCaveInfoBranch As cSurvey.cCaveInfoBranch In oCaveInfo.Branches.GetAllBranchesWithEmpty.Values
                        For Each oShot As cSurvey.cSegment In oCaveInfoBranch.GetSegments
                            Call oShots.Add(oShot)
                        Next
                    Next
                Next

                Dim iEdgeIndex As Integer = 0
                Dim iEdgeCount As Integer = oShots.Count
                Call oSurvey.RaiseOnProgressEvent("3dmodel", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("holos.progressbegin5"), 0, cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.Image3D Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow)

                'For Each oCaveInfo As cSurvey.cCaveInfo In oCurrentSurvey.Properties.CaveInfos.GetWithEmpty.Values
                'For Each oCaveInfoBranch As cSurvey.cCaveInfoBranch In oCaveInfo.Branches.GetAllBranchesWithEmpty.Values
                For Each oShot As cSurvey.cSegment In oShots
                    If modDesign.GetIfSegmentMustBeDrawedByCaveAndBranch(PaintOptions, oShot, Selection.CurrentCave, Selection.CurrentBranch) Then
                        iEdgeIndex += 1
                        If iEdgeIndex Mod 50 = 0 Then Call oSurvey.RaiseOnProgressEvent("3dmodel", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("holos.progress5"), iEdgeIndex / iEdgeCount)

                        If oShot.IsValid AndAlso Not oShot.IsSelfDefined Then
                            If oShot.Cut Then
                                addStationFunc(oShot.Data.Data.From, oShot.Data.Profile.FromPoint.X)
                                Dim toPos As Point3D = oPoints(oShot.Data.Data.To)(0)
                                cmCave.addWall(toPos.X, toPos.Y, toPos.Z, oStationToPiketDict(oShot.From))
                            ElseIf Not oShot.Surface AndAlso Not oShot.Duplicate AndAlso Not oShot.Splay Then
                                If oCurrentSurvey.Properties.ThreeDModelMode > cProperties.ThreeDModelModeEnum.Simple Then
                                    For Each oSubData As Calculate.Plot.cSubData In oShot.Data.SubDatas
                                        addStationFunc(oSubData.From, oSubData.Profile.FromPoint.X)
                                        addStationFunc(oSubData.To, oSubData.Profile.ToPoint.X)
                                        'IN FUTURE: replace lightgray with color from settings or properties...
                                        Dim oShotColor As Color = oCurrentSurvey.Properties.CaveInfos.GetColor(oShot, Color.LightGray)
                                        If PaintOptions.ModelColorGray Then
                                            oShotColor = modPaint.GrayColor(oShotColor)
                                        End If
                                        cmCave.addEdge(oStationToPiketDict(oSubData.From), oStationToPiketDict(oSubData.To), oShot.ZSurvey, oShotColor.R / 255.0F, oShotColor.G / 255.0F, oShotColor.B / 255.0F)
                                    Next
                                Else
                                    addStationFunc(oShot.Data.Data.From, oShot.Data.Profile.FromPoint.X)
                                    addStationFunc(oShot.Data.Data.To, oShot.Data.Profile.ToPoint.X)
                                    'IN FUTURE: replace lightgray with color from settings or properties...
                                    Dim oShotColor As Color = oCurrentSurvey.Properties.CaveInfos.GetColor(oShot, Color.LightGray)
                                    If PaintOptions.ModelColorGray Then
                                        oShotColor = modPaint.GrayColor(oShotColor)
                                    End If
                                    cmCave.addEdge(oStationToPiketDict(oShot.Data.Data.From), oStationToPiketDict(oShot.Data.Data.To), oShot.ZSurvey, oShotColor.R / 255.0F, oShotColor.G / 255.0F, oShotColor.B / 255.0F)
                                End If
                            End If
                        End If
                    End If
                Next
                'Next
                'Next
                Call oSurvey.RaiseOnProgressEvent("3dmodel", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)

                cmCave.setMode(PaintOptions.DrawModelMode)
                cmCave.setColoringMode(PaintOptions.DrawModelColoringMode, PaintOptions.ModelColorGray)

                'is usefull?
                If (PaintOptions.DrawModelMode = RenderMode.SM_OUTLINE) Then
                    Dim lookDirection = mainViewport.Camera.LookDirection
                    cmCave.setLookDirection(lookDirection.X, lookDirection.Y, lookDirection.Z)
                End If

                Dim outputToEnable = DMOuputType.OT_DEBUG
                If (PaintOptions.DrawModelMode = RenderMode.SM_ROUGH_WALLS) Then
                    outputToEnable = outputToEnable & DMOuputType.OT_WALL
                ElseIf (PaintOptions.DrawModelMode = RenderMode.SM_SMOOTH_WALLS) Then
                    outputToEnable = outputToEnable & DMOuputType.OT_WALL
                ElseIf (PaintOptions.DrawModelMode = RenderMode.SM_CUTS) Then
                    outputToEnable = outputToEnable & DMOuputType.OT_WALL_CUTS
                ElseIf (PaintOptions.DrawModelMode = RenderMode.SM_OUTLINE) Then
                    outputToEnable = outputToEnable & DMOuputType.OT_OUTLINE_CUT & DMOuputType.OT_OUTLINE ' & DMOuputType.OT_THREAD
                End If

                If (PaintOptions.ModelExtendedElevation) Then cmCave.setShouldConvertToExtendedElevation(True)

                cmCave.finishInit(outputToEnable)

                Dim oMesheBags As Dictionary(Of Media.Color, Point3DCollection) = New Dictionary(Of Media.Color, Point3DCollection)

                Dim i As DMOuputType = 1
                Do While i < DMOuputType.OT_NUM
                    If cmCave.isOutputEnabled(i) Then
                        For Each poly As DNOutputPoly In cmCave.getOutputPoly(i)
                            Dim a = (poly.color(0, 3) + poly.color(1, 3) + poly.color(2, 3)) / 3.0 * 255.0
                            Dim r = (poly.color(0, 0) + poly.color(1, 0) + poly.color(2, 0)) / 3.0 * 255.0
                            Dim g = (poly.color(0, 1) + poly.color(1, 1) + poly.color(2, 1)) / 3.0 * 255.0
                            Dim b = (poly.color(0, 2) + poly.color(1, 2) + poly.color(2, 2)) / 3.0 * 255.0

                            Dim oPositions As Point3DCollection
                            Dim oColor As Media.Color = Media.Color.FromArgb(a, r, g, b)
                            If oMesheBags.ContainsKey(oColor) Then
                                oPositions = oMesheBags(oColor)
                            Else
                                oPositions = New Point3DCollection
                                Call oMesheBags.Add(oColor, oPositions)
                            End If
                            Call oPositions.Add(New Point3D(poly.vertice(0, 0), poly.vertice(0, 1), poly.vertice(0, 2)))
                            Call oPositions.Add(New Point3D(poly.vertice(2, 0), poly.vertice(2, 1), poly.vertice(2, 2)))
                            Call oPositions.Add(New Point3D(poly.vertice(1, 0), poly.vertice(1, 1), poly.vertice(1, 2)))
                        Next

                        If (i = DMOuputType.OT_WALL_CUTS Or i = DMOuputType.OT_DEBUG Or i = DMOuputType.OT_OUTLINE_CUT Or i = DMOuputType.OT_THREAD) Then

                            Dim lineView As HelixToolkit.Wpf.LinesVisual3D = Nothing
                            Dim lines = cmCave.getOutputLine(i)

                            For Each line As DMOutputLine In lines
                                Dim a = (line.color(0, 3) + line.color(1, 3)) / 2.0 * 255.0
                                Dim r = (line.color(0, 0) + line.color(1, 0)) / 2.0 * 255.0
                                Dim g = (line.color(0, 1) + line.color(1, 1)) / 2.0 * 255.0
                                Dim b = (line.color(0, 2) + line.color(1, 2)) / 2.0 * 255.0

                                Dim col = Media.Color.FromArgb(a, r, g, b)
                                If lineView Is Nothing OrElse Not lineView.Color = col Then
                                    If Not lineView Is Nothing Then Call oModels.Add(lineView)
                                    lineView = New HelixToolkit.Wpf.LinesVisual3D
                                    lineView.Color = col
                                    If (i = DMOuputType.OT_WALL_CUTS) Then
                                        lineView.Thickness = 2
                                    Else
                                        lineView.Thickness = 1
                                    End If
                                End If

                                Call lineView.Points.Add(New Point3D(line.vertice(0, 0), line.vertice(0, 1), line.vertice(0, 2)))
                                Call lineView.Points.Add(New Point3D(line.vertice(1, 0), line.vertice(1, 1), line.vertice(1, 2)))

                            Next
                            If (lineView IsNot Nothing) Then
                                Call oModels.Add(lineView)
                            End If
                        End If
                    End If

                    i = i * 2
                Loop

                Dim iModelIndex As Integer = 0
                Dim iModelCount As Integer = oMesheBags.Count
                Call oSurvey.RaiseOnProgressEvent("3dmodel", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("holos.progressbegin4"), 0, cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.Image3D Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow)

                For Each oMeshColor As Media.Color In oMesheBags.Keys
                    iModelIndex += 1
                    If iModelIndex Mod 20 = 0 Then Call oSurvey.RaiseOnProgressEvent("3dmodel", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("holos.progress4"), iModelIndex / iModelCount)

                    Dim material = New DiffuseMaterial(New Media.SolidColorBrush(oMeshColor))
                    Dim oMesh As MeshGeometry3D = New MeshGeometry3D
                    oMesh.Positions = oMesheBags(oMeshColor)
                    For v As Integer = 0 To oMesh.Positions.Count - 1
                        Call oMesh.TriangleIndices.Add(v)
                    Next
                    Dim oVisual As MeshGeometryVisual3D = New MeshGeometryVisual3D
                    oVisual.MeshGeometry = oMesh
                    oVisual.Material = material
                    oVisual.BackMaterial = material
                    Call oModels.Add(oVisual)
                Next
                Call oSurvey.RaiseOnProgressEvent("3dmodel", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)

                Call oCmCaves.Add(oCurrentSurvey, cmCave)
            End If

            If PaintOptions.DrawChunks Then
                For Each oChunk As cItemChunk3D In oSurvey.ThreeD.Layers.ChunkLayer.Items
                    If GetIfItemMustBeDrawedByCaveAndBranch(PaintOptions, oChunk, Selection.CurrentCave, Selection.CurrentBranch) Then
                        If oChunk.Stations.IsValid Then
                            Dim oChunkModel As ModelVisual3D = pChunk(oChunk, PaintOptions)
                            Dim oChunkHotSpot As cHotSpot = New cHotSpot(oChunkModel, oChunk)
                            oChunksHotSpots.Add(oChunkModel, oChunkHotSpot)
                            oChunks.Add(oChunk, oChunkModel)
                        End If
                    End If
                Next
            End If
        Next

        If PaintOptions.DrawModel Then
            If (PaintOptions.DrawModelMode = RenderMode.SM_OUTLINE) Then
                bModelOutline = True
                Call pCavesOutline()
            Else
                bModelOutline = False
            End If
        End If
    End Sub

    Private Class cLinesBag
        Private oColor As Media.Color
        Private oLine As LinesVisual3D

        Public ReadOnly Property Color As Media.Color
            Get
                Return oColor
            End Get
        End Property

        Public ReadOnly Property Line As LinesVisual3D
            Get
                Return oLine
            End Get
        End Property

        Public Sub New(Color As Media.Color)
            oColor = Color
            oLine = New HelixToolkit.Wpf.LinesVisual3D
            oLine.Color = oColor
            oLine.Thickness = 2
        End Sub
    End Class

    Sub drawOutlineTimerCallback(sender As Object, e As EventArgs)
        If (oOutlineUpdateTimer IsNot Nothing) Then
            oOutlineUpdateTimer.Stop()
            oOutlineUpdateTimer.Dispose()
            oOutlineUpdateTimer = Nothing
        End If

        Call pCavesOutline()
    End Sub

    Private Sub pCavesOutline()
        If bModelOutline AndAlso Not bModelOutlineDisabled Then
            Call oSurvey.RaiseOnProgressEvent("3dmodel", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("holos.outlinerenderingtext"), 0)
            For Each line As HelixToolkit.Wpf.LinesVisual3D In oModelOutline
                Call oAll.Children.Remove(line)
            Next
            Call oModelOutline.Clear()

            Dim oLines As Dictionary(Of Media.Color, cLinesBag) = New Dictionary(Of Media.Color, cLinesBag)
            For Each CmCave As DNetCMCave In oCmCaves.Values
                If CmCave IsNot Nothing AndAlso CmCave.getMode() = RenderMode.SM_OUTLINE Then
                    Dim lookDirection = mainViewport.Camera.LookDirection
                    CmCave.setLookDirection(lookDirection.X, lookDirection.Y, lookDirection.Z)

                    Dim lines = CmCave.getOutputLine(DMOuputType.OT_OUTLINE)
                    For Each line As DMOutputLine In lines
                        Dim a = (line.color(0, 3) + line.color(1, 3)) / 2.0 * 255.0
                        Dim r = (line.color(0, 0) + line.color(1, 0)) / 2.0 * 255.0
                        Dim g = (line.color(0, 1) + line.color(1, 1)) / 2.0 * 255.0
                        Dim b = (line.color(0, 2) + line.color(1, 2)) / 2.0 * 255.0

                        Dim col = Media.Color.FromArgb(a, r, g, b)
                        If Not oLines.ContainsKey(col) Then
                            Dim oLineBag As cLinesBag = New cLinesBag(col)
                            Call oLines.Add(col, oLineBag)
                        End If
                        Call oLines(col).Line.Points.Add(New Point3D(line.vertice(0, 0), line.vertice(0, 1), line.vertice(0, 2)))
                        Call oLines(col).Line.Points.Add(New Point3D(line.vertice(1, 0), line.vertice(1, 1), line.vertice(1, 2)))
                        If modWindow.GetAsyncKeyState(Keys.Escape) Then bModelOutlineDisabled = True
                        If bModelOutlineDisabled Then Exit For
                    Next
                End If
            Next

            For Each oLine As cLinesBag In oLines.Values
                Call oModelOutline.Add(oLine.Line)
                If oAll IsNot Nothing Then Call oAll.Children.Add(oLine.Line)
            Next

            iInvalidated = iInvalidated And Not InvalidateType.CameraMove
            Call oSurvey.RaiseOnProgressEvent("3dmodel", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "", 0)
        End If
    End Sub

    Private Class Overlay
        Inherits DependencyObject

        Public Shared ReadOnly Position3DProperty As DependencyProperty = DependencyProperty.Register("Position3D", GetType(Point3D), GetType(Overlay))

        Public Shared Function GetPosition3D([Object] As Object) As Point3D
            Return DirectCast([Object].GetValue(Position3DProperty), Point3D)
        End Function

        Public Shared Sub SetPosition3D([Object] As Object, Value As Point3D)
            Call [Object].SetValue(Position3DProperty, Value)
        End Sub
    End Class

    Private Sub pAppendTrianglePoint(Dictionary As Dictionary(Of Point3D, Integer), Mesh As MeshGeometry3D, Point As Point3D, ByRef Index As Integer)
        If Dictionary.ContainsKey(Point) Then
            Call Mesh.TriangleIndices.Add(Dictionary(Point))
        Else
            Call Mesh.Positions.Add(Point)
            Call Dictionary.Add(Point, Index)
            Call Mesh.TriangleIndices.Add(Index)
            Index += 1
        End If
    End Sub

    'Private Sub pCreateTriangleModel2(Dictionary As Dictionary(Of Point3D, Integer), Mesh As MeshGeometry3D, p0 As Point3D, p1 As Point3D, p2 As Point3D, ByRef Index As Integer)
    '    Call pAppendTrianglePoint(Dictionary, Mesh, p0, Index)
    '    Call pAppendTrianglePoint(Dictionary, Mesh, p1, Index)
    '    Call pAppendTrianglePoint(Dictionary, Mesh, p2, Index)
    'End Sub

    Private Sub pClearViewport()
        oSurfaceModel = Nothing
        mainViewport.Children.Clear()
        'mainViewport.Background = Media.Brushes.Black
        'mainViewport.Foreground = Media.Brushes.White
        'mainViewport.CoordinateSystemLabelForeground = Media.Brushes.White
        'add lights to view...
        For Each oModel As ModelVisual3D In pLights()
            Call mainViewport.Children.Add(oModel)
        Next
    End Sub

    Private Function pLights() As List(Of ModelVisual3D)
        'Call oLights.Clear()
        Dim oLights As List(Of ModelVisual3D) = New List(Of ModelVisual3D)
        Dim oLight As HelixToolkit.Wpf.SunLight = New HelixToolkit.Wpf.SunLight
        'oLight.Ambient = 80
        oLight.Altitude = 40000
        oLight.Azimuth = 45
        Call oLights.Add(oLight)
        Return oLights
    End Function

    Private Sub pSetCamera()
        mainViewport.CameraController.RotateAroundMouseDownPoint = True
        Dim iCurrentCameraMode As cameraModeEnum = mainViewport.CameraController.CameraMode
        mainViewport.CameraController.CameraMode = HelixToolkit.Wpf.CameraMode.FixedPosition
        mainViewport.CameraController.CameraMode = iCurrentCameraMode
        'Dim oCamera As PerspectiveCamera = DirectCast(mainViewport.Camera, PerspectiveCamera)
        'oCamera.Position = New Point3D(0, 0, 1000)
        'oCamera.LookDirection = New Vector3D(0, 0, 0)
    End Sub

    Public Function pHitTestResult(ByVal Result As Media.HitTestResult) As Media.HitTestResultBehavior
        If TypeOf Result.VisualHit Is ModelVisual3D Then
            Dim oModel As ModelVisual3D = Result.VisualHit
            If Not oSurfaceModel Is Nothing AndAlso oModel.IsDescendantOf(oSurfaceModel) Then
                Return Media.HitTestResultBehavior.Continue
            Else
                If oSurfaces.Contains(oModel) Then
                    Return Media.HitTestResultBehavior.Continue
                Else
                    Call oHitTestResult.Add(oModel)
                    Return Media.HitTestResultBehavior.Stop
                End If
            End If
        End If
    End Function

    Private oHitTestResult As List(Of Visual3D) = New List(Of Visual3D)

    Private Function pHitTest(Point As Windows.Point) As ModelVisual3D
        Call oHitTestResult.Clear()
        Call Media.VisualTreeHelper.HitTest(mainViewport, Nothing, New Media.HitTestResultCallback(AddressOf pHitTestResult), New Media.PointHitTestParameters(Point))
        If oHitTestResult.Count Then
            Dim oModel As ModelVisual3D = oHitTestResult(0)
            Return oModel
        Else
            Return Nothing
        End If
    End Function

    Public Sub Zoom(Factor As Single)
        mainViewport.CameraController.Zoom(Factor)
    End Sub

    Private Sub mainViewport_CameraChanged(sender As Object, e As RoutedEventArgs) Handles mainViewport.CameraChanged
        Dim oPoint1 As Point3D = mainViewport.Camera.Position
        Dim oV1 As Vector3D = mainViewport.Camera.LookDirection
        Dim c1 As Single = Math.Sqrt(oV1.X ^ 2 + oV1.Y ^ 2)
        Dim sInclination As Single = RadiansToDegree(Math.Atan(c1 / oV1.Z))
        Dim sBearing As Single = modPaint.GetBearing(New PointF(oV1.X, oV1.Y), New PointF(0, 0))
        RaiseEvent OnSceneInfoChange(Me, New cSceneInfoChangeEventArgs(sBearing, sInclination))
        Call Invalidate(InvalidateType.CameraMove)
    End Sub

    Private Sub mainViewport_Loaded(sender As Object, e As RoutedEventArgs) Handles mainViewport.Loaded
        'Call mainViewport.CameraController.ChangeDirection(New Vector3D(0, 0, -1), New Vector3D(0, 1, 0))
    End Sub

    Private Sub mainViewport_MouseDoubleClick(sender As Object, e As Input.MouseButtonEventArgs) Handles mainViewport.MouseDoubleClick
        RaiseEvent OnDoubleClick(Me, New EventArgs)
    End Sub

    Private Sub mainViewport_MouseLeftButtonDown(sender As Object, e As Input.MouseButtonEventArgs) Handles mainViewport.MouseLeftButtonDown
        Dim oModel As ModelVisual3D = pHitTest(e.GetPosition(mainViewport))
        If oModel Is Nothing Then
            Dim oItemSelectEventsArgs As cItemSelectEventArgs = New cItemSelectEventArgs(Nothing)
            RaiseEvent OnItemSelect(Me, oItemSelectEventsArgs)
        Else
            If oHotSpots.ContainsKey(oModel) Then
                Dim oItemSelectEventsArgs As cItemSelectEventArgs = New cItemSelectEventArgs(oHotSpots(oModel).SourceItem)
                RaiseEvent OnItemSelect(Me, oItemSelectEventsArgs)
            Else
                Dim oItemSelectEventsArgs As cItemSelectEventArgs = New cItemSelectEventArgs(Nothing)
                RaiseEvent OnItemSelect(Me, oItemSelectEventsArgs)
            End If
        End If
    End Sub

    Private Sub mainViewport_MouseMove(sender As Object, e As Input.MouseEventArgs) Handles mainViewport.MouseMove
        Dim oModel As ModelVisual3D = pHitTest(e.GetPosition(mainViewport))
        If oModel Is Nothing Then
            Cursor = System.Windows.Input.Cursors.Arrow
        Else
            If oHotSpots.ContainsKey(oModel) Then
                Cursor = System.Windows.Input.Cursors.Hand
            Else
                Cursor = System.Windows.Input.Cursors.Arrow
            End If
        End If
    End Sub

    Friend Sub DeleteChunk(Chunk As cItemChunk3D)
        Dim oModel As ModelVisual3D = oChunks(Chunk)
        Call oAll.Children.Remove(oModel)
    End Sub

    Public Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oHotSpots = New Dictionary(Of ModelVisual3D, cHotSpot)
        oCavesHotSpots = New Dictionary(Of ModelVisual3D, cHotSpot)
        oSurfacesHotSpots = New Dictionary(Of ModelVisual3D, cHotSpot)

        oCaves = New List(Of ModelVisual3D)
        oSurfaces = New List(Of ModelVisual3D)

        oModels = New List(Of ModelVisual3D)

        oPlots = New List(Of ModelVisual3D)
        oModelOutline = New List(Of LinesVisual3D)

        oChunks = New Dictionary(Of cItemChunk3D, ModelVisual3D)
        oChunksHotSpots = New Dictionary(Of ModelVisual3D, cHotSpot)

        oCmCaves = New Dictionary(Of cSurvey.cSurvey, DNetCMCave)

        'aggiungo le luci al viewport...queste dovrebbero restare uguali sempre...
        For Each oModel As ModelVisual3D In pLights()
            Call mainViewport.Children.Add(oModel)
        Next

        Try
            mainViewport.ViewCubeTopText = GetLocalizedString("holos.top")
            mainViewport.ViewCubeBottomText = GetLocalizedString("holos.bottom")
            mainViewport.ViewCubeLeftText = GetLocalizedString("holos.front")
            mainViewport.ViewCubeRightText = GetLocalizedString("holos.back")
            mainViewport.ViewCubeFrontText = GetLocalizedString("holos.left")
            mainViewport.ViewCubeBackText = GetLocalizedString("holos.right")
            lblRefresh.Content = GetLocalizedString("holos.textpart1")
        Catch
        End Try


        'AddHandler System.Windows.Media.CompositionTarget.Rendering, AddressOf CompositionTargetRendering
    End Sub

    Private Delegate Sub pResetSceneDelegate()

    Private Sub pResetSceneCallback(State As Object)
        Try
            If Not Application.Current Is Nothing Then
                Call Application.Current.Dispatcher.BeginInvoke(New pResetSceneDelegate(AddressOf ResetScene), Threading.DispatcherPriority.Normal, Nothing)
            End If
        Catch
        End Try
    End Sub

    Public Sub ResetScene()
        Call pSetCamera()
        Call ZoomExtents()
        Call SetView(ViewFromEnum.FromTop)
    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As RoutedEventArgs) Handles cmdRefresh.Click
        RaiseEvent OnRedrawRequest(Me, New EventArgs)
    End Sub

    Private Sub mainViewport_LookAtChanged(sender As Object, e As RoutedEventArgs) Handles mainViewport.LookAtChanged
        '!!!
    End Sub

    Public Event OnKeyUp(sender As Object, e As Forms.KeyEventArgs)

    Private Sub cHolosViewer_PreviewKeyUp(sender As Object, e As Input.KeyEventArgs) Handles Me.PreviewKeyUp
        If e.Key = Key.Delete Then
            Dim iKey As Forms.Keys = KeyInterop.VirtualKeyFromKey(e.Key)
            RaiseEvent OnKeyUp(Me, New Forms.KeyEventArgs(iKey))
        End If
    End Sub

    'Public Event OnContextMenuRequest(Sender As Object, e As Windows.Forms.MouseEventArgs)

    'Private Sub cHolosViewer_PreviewMouseRightButtonUp(sender As Object, e As MouseButtonEventArgs) Handles Me.PreviewMouseRightButtonUp
    '    If My.Computer.Keyboard.AltKeyDown Then
    '        Dim oPoint As Point = e.GetPosition(mainViewport)
    '        RaiseEvent OnContextMenuRequest(Me, New Windows.Forms.MouseEventArgs(MouseButtons.Right, 1, oPoint.X, oPoint.Y, 0))
    '        e.Handled = True
    '    End If
    'End Sub
End Class
