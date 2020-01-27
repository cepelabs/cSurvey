Imports System.Drawing.Drawing2D

Public Class cClipperHelper
    Public Const Precision As Integer = 10 ^ 3

    Public Shared Function GetIntPoint(Point As PointF) As IntPoint
        Return New IntPoint(Point.X * Precision, Point.Y * Precision)
    End Function

    Public Shared Function GetIntPath(Path As GraphicsPath) As List(Of IntPoint)
        Dim oPath As List(Of IntPoint) = New List(Of IntPoint)
        For Each oPoint As PointF In Path.PathPoints
            Call oPath.Add(GetIntPoint(oPoint))
        Next
        Return oPath
    End Function

    Public Class cClipperMetaPath
        Private oPath As List(Of IntPoint)

        Public Sub New(Path As GraphicsPath)
            oPath = New List(Of IntPoint)
        End Sub

        Public Sub Add(Path As GraphicsPath)
            Call oPath.AddRange(cClipperHelper.GetIntPath(Path))
        End Sub

        Public Sub Union(Path As GraphicsPath, Closed As Boolean)
            Dim oClipper As Clipper = New Clipper
            Call oClipper.AddPath(oPath, PolyType.ptSubject, Closed)
            Call oClipper.AddPath(cClipperHelper.GetIntPath(Path), PolyType.ptClip, Closed)
            Dim oResults As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
            Call oClipper.Execute(ClipType.ctUnion, oResults)
            'oPath = oResults
        End Sub
    End Class
End Class
