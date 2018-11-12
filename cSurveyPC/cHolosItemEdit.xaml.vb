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

Public Class cHolosItemEdit
    Public Sub Import(Optional Filename As String = "")
        Dim ofd As OpenFileDialog = New OpenFileDialog
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim sFilename As String = ofd.FileName

            Dim oM As ModelImporter = New ModelImporter
            Dim oModel As Model3DGroup = oM.Load(sFilename)
            Dim oGroup As ModelVisual3D = New ModelVisual3D

            Dim oTransformGroup As Transform3DGroup = New Transform3DGroup()
            ''Call oTransformGroup.Children.Add(New RotateTransform3D(New Media.Media3D.AxisAngleRotation3D(New Media.Media3D.Vector3D(1, 0, 0), 0)))
            'Call oTransformGroup.Children.Add(New ScaleTransform3D(0.1, 0.1, 0.1))
            Call oTransformGroup.Children.Add(New RotateTransform3D(New Media.Media3D.AxisAngleRotation3D(New Media.Media3D.Vector3D(0, 0, 1), 90)))
            Call oTransformGroup.Children.Add(New RotateTransform3D(New Media.Media3D.AxisAngleRotation3D(New Media.Media3D.Vector3D(0, 1, 0), -90)))
            Call oTransformGroup.Children.Add(New TranslateTransform3D(0, 0, 0))
            oGroup.Transform = oTransformGroup
            oGroup.Content = oModel
            Call mainViewport.Children.Insert(0, oGroup)
        End If
    End Sub
End Class
