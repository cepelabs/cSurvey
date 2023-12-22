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

Public Class cHolosItemView
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
End Class
