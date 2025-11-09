Imports System.Drawing.Drawing2D
Imports DevExpress.Pdf.Native.BouncyCastle.Asn1.Tsp

Public Class cClipperHelper

    Public Shared Function GetPoint(Point As IntPoint, Optional Precision As Single = 10000.0F) As PointF
        Dim sX As Single = Point.X
        Dim sY As Single = Point.Y
        Return New PointF(sX / Precision, sY / Precision)
    End Function

    Public Shared Function GetIntPoint(Point As PointF, Optional Precision As Single = 10000.0F) As IntPoint
        Return New IntPoint(Point.X * Precision, Point.Y * Precision)
    End Function

    'Public Shared Function GetIntPath(Path As GraphicsPath) As List(Of IntPoint)
    '    Dim oPath As List(Of IntPoint) = New List(Of IntPoint)
    '    For Each oPoint As PointF In Path.PathPoints
    '        Call oPath.Add(GetIntPoint(oPoint))
    '    Next
    '    Return oPath
    'End Function

    Public Shared Function PointsToIntPath(Points As PointF(), Optional Precision As Single = 10000.0F) As List(Of List(Of IntPoint))
        Dim oIntPaths As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
        Dim oIntPath As List(Of IntPoint) = New List(Of IntPoint)
        Call oIntPath.AddRange(Points)
        oIntPaths.Add(oIntPath)
        Return oIntPaths
    End Function
    Public Shared Function GraphicsPathToIntPaths(Path As GraphicsPath, Optional Precision As Single = 10000.0F) As List(Of List(Of IntPoint))
        Dim oIntPaths As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
        Using oFlattenedPath As GraphicsPath = Path.Clone
            Call oFlattenedPath.Flatten(Nothing, Precision)
            Dim oIntPath As List(Of IntPoint) = Nothing
            For i As Integer = 0 To oFlattenedPath.PointCount - 1
                Dim oPoint As PointF = oFlattenedPath.PathPoints(i)
                Dim bType As Byte = oFlattenedPath.PathTypes(i)
                If (bType = PathPointType.Start) Then
                    If oIntPath IsNot Nothing Then
                        Call oIntPaths.Add(oIntPath)
                    End If
                    oIntPath = New List(Of IntPoint)
                End If
                oIntPath.Add(GetIntPoint(oPoint, Precision))
            Next
            If oIntPath IsNot Nothing Then
                Call oIntPaths.Add(oIntPath)
            End If
        End Using
        Return oIntPaths
    End Function

    'Public Class cClipperMetaPath
    '    Private oPath As List(Of IntPoint)

    '    Public Sub New(Path As GraphicsPath)
    '        oPath = New List(Of IntPoint)
    '    End Sub

    '    Public Sub Add(Path As GraphicsPath)
    '        Call oPath.AddRange(cClipperHelper.GetIntPath(Path))
    '    End Sub

    '    Public Sub Union(Path As GraphicsPath, Closed As Boolean)
    '        Dim oClipper As Clipper = New Clipper
    '        Call oClipper.AddPath(oPath, PolyType.ptSubject, Closed)
    '        Call oClipper.AddPath(cClipperHelper.GetIntPath(Path), PolyType.ptClip, Closed)
    '        Dim oResults As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
    '        Call oClipper.Execute(ClipType.ctUnion, oResults)
    '    End Sub
    'End Class
End Class
