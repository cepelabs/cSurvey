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
Imports System.Windows.Input

Public Class cHolosItemEdit
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Try
            mainViewport.ViewCubeTopText = GetLocalizedString("holos.top")
            mainViewport.ViewCubeBottomText = GetLocalizedString("holos.bottom")
            mainViewport.ViewCubeLeftText = GetLocalizedString("holos.front")
            mainViewport.ViewCubeRightText = GetLocalizedString("holos.back")
            mainViewport.ViewCubeFrontText = GetLocalizedString("holos.left")
            mainViewport.ViewCubeBackText = GetLocalizedString("holos.right")
        Catch
        End Try
    End Sub

    Dim oStation1Color As Media.Color = Windows.Media.ColorConverter.ConvertFromString("#B24CCD32")
    Dim oStation1Brush As Media.Brush = New Media.SolidColorBrush(oStation1Color)
    Dim oStation2Color As Media.Color = Windows.Media.ColorConverter.ConvertFromString("#B2EA2E04")
    Dim oStation2Brush As Media.Brush = New Media.SolidColorBrush(oStation2Color)

    Dim oSelectionColor As Media.Color = Windows.Media.ColorConverter.ConvertFromString("#B23399FF")
    Dim oSelectionBrush As Media.Brush = New Media.SolidColorBrush(oSelectionColor)

    Private Sub cHolosItemEdit_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles Me.MouseLeftButtonDown
        Dim oModel As ModelVisual3D = pHitTest(e.GetPosition(mainViewport))
        oSelected = oModel
        If oSelected Is cube_station1 Then
            cube_station1.Fill = oSelectionBrush
            cube_station2.Fill = oStation2Brush
        ElseIf oSelected Is cube_station2 Then
            cube_station1.Fill = oStation1Brush
            cube_station2.Fill = oSelectionBrush
        Else
            cube_station1.Fill = oStation1Brush
            cube_station2.Fill = oStation2Brush
        End If
    End Sub

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

    Private oSelected As ModelVisual3D

    Public Function pHitTestResult(ByVal Result As Media.HitTestResult) As Media.HitTestResultBehavior
        If TypeOf Result.VisualHit Is ModelVisual3D Then
            Dim oModel As ModelVisual3D = Result.VisualHit
            If oModel Is cube_station1 OrElse oModel Is cube_station2 Then
                Call oHitTestResult.Add(oModel)
                Return Media.HitTestResultBehavior.Stop
            End If
        End If
    End Function

    Public ReadOnly Property station2manipulator As CombinedManipulator
        Get
            Return cube_station2_manipulator
        End Get
    End Property

    Public ReadOnly Property station1manipulator As CombinedManipulator
        Get
            Return cube_station1_manipulator
        End Get
    End Property

    Public ReadOnly Property station2 As CubeVisual3D
        Get
            Return cube_station2
        End Get
    End Property

    Public ReadOnly Property station1 As CubeVisual3D
        Get
            Return cube_station1
        End Get
    End Property

    Public ReadOnly Property Selected As CubeVisual3D
        Get
            Return oSelected
        End Get
    End Property

    Public Class cOnManualMoveEventArgs
        Inherits EventArgs

        Private oSelection As ModelVisual3D
        Private dX As Decimal
        Private dY As Decimal
        Private dZ As Decimal

        Public ReadOnly Property X As Decimal
            Get
                Return dX
            End Get
        End Property

        Public ReadOnly Property Y As Decimal
            Get
                Return dY
            End Get
        End Property

        Public ReadOnly Property Z As Decimal
            Get
                Return dZ
            End Get
        End Property

        Public ReadOnly Property Selected As ModelVisual3D
            Get
                Return oSelection
            End Get
        End Property

        Public Sub New(Selection As ModelVisual3D, X As Decimal, Y As Decimal, Z As Decimal)
            oSelection = Selection
            dX = X
            dY = Y
            dZ = Z
        End Sub
    End Class

    Public Event OnManualMove(sender As Object, e As cOnManualMoveEventArgs)

    Private Sub cHolosItemEdit_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles Me.PreviewKeyDown
        If oSelected IsNot Nothing Then
            Dim dDelta As Decimal
            If e.KeyboardDevice.Modifiers = ModifierKeys.Shift Then
                dDelta = 0.1
            Else
                dDelta = 0.01
            End If
            Debug.Print("PREVIEW " & e.Key.ToString & " MOD " & e.KeyboardDevice.Modifiers.ToString)
            If e.Key = System.Windows.Input.Key.Up Then
                If oSelected Is cube_station1 OrElse oSelected Is cube_station2 Then
                    RaiseEvent OnManualMove(Me, New cOnManualMoveEventArgs(oSelected, 0, dDelta, 0))
                    e.Handled = True
                End If
            ElseIf e.Key = System.Windows.Input.Key.Down Then
                If oSelected Is cube_station1 OrElse oSelected Is cube_station2 Then
                    RaiseEvent OnManualMove(Me, New cOnManualMoveEventArgs(oSelected, 0, -dDelta, 0))
                    e.Handled = True
                End If
            ElseIf e.Key = System.Windows.Input.Key.Right Then
                If oSelected Is cube_station1 OrElse oSelected Is cube_station2 Then
                    RaiseEvent OnManualMove(Me, New cOnManualMoveEventArgs(oSelected, dDelta, 0, 0))
                    e.Handled = True
                End If
            ElseIf e.Key = System.Windows.Input.Key.Left Then
                If oSelected Is cube_station1 OrElse oSelected Is cube_station2 Then
                    RaiseEvent OnManualMove(Me, New cOnManualMoveEventArgs(oSelected, -dDelta, 0, 0))
                    e.Handled = True
                End If
            ElseIf e.Key = System.Windows.Input.Key.OemPlus OrElse e.Key = System.Windows.Input.Key.Add Then
                If oSelected Is cube_station1 OrElse oSelected Is cube_station2 Then
                    RaiseEvent OnManualMove(Me, New cOnManualMoveEventArgs(oSelected, 0, 0, dDelta))
                    e.Handled = True
                End If
            ElseIf e.Key = System.Windows.Input.Key.OemMinus OrElse e.Key = System.Windows.Input.Key.Subtract Then
                If oSelected Is cube_station1 OrElse oSelected Is cube_station2 Then
                    RaiseEvent OnManualMove(Me, New cOnManualMoveEventArgs(oSelected, 0, 0, -dDelta))
                    e.Handled = True
                End If
            End If
        End If
    End Sub
End Class
