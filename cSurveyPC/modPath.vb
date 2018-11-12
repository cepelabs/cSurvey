Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports ClipperLib

Module modPath
    'http://www.angusj.com/delphi/clipper.php
    'Public Function Contains(Path1 As GraphicsPath, Path2 As GraphicsPath, Optional Accurancy As Single = 0.01) As Boolean
    '    Dim bRes As Boolean

    '    Dim oPath1 As GraphicsPath = Path1.Clone
    '    Call oPath1.Flatten(Nothing, Accurancy)

    '    Dim oPath2 As GraphicsPath = Path2.Clone
    '    Call oPath2.Flatten(Nothing, Accurancy)

    '    Dim oLastPoint1 As PointF
    '    Dim i1 As Integer = 0
    '    For Each oPoint1 As PointF In oPath1.PathPoints
    '        Dim oLastPoint2 As PointF
    '        Dim i2 As Integer = 0
    '        If i1 > 0 Then
    '            Dim oSize1 As SizeF = New SizeF(oPoint1.X - oLastPoint1.X, oPoint1.Y - oLastPoint1.Y)
    '            Dim oRect1 As RectangleF = New RectangleF(oPoint1, oSize1)
    '            For Each oPoint2 As PointF In oPath2.PathPoints
    '                If i1 > 0 Then
    '                    Dim oSize2 As SizeF = New SizeF(oPoint2.X - oLastPoint2.X, oPoint2.Y - oLastPoint2.Y)
    '                    Dim oRect2 As RectangleF = New RectangleF(oPoint2, oSize2)
    '                    If oRect1.Contains(oRect2) Then
    '                        bRes = True
    '                    End If
    '                End If
    '                If bRes = True Then Exit For
    '                i1 += 1
    '            Next
    '        End If
    '        If bRes = True Then Exit For
    '        i2 += 1
    '    Next

    '    Call oPath1.Dispose()
    '    Call oPath2.Dispose()

    '    Return bRes
    'End Function

    'path1 intersect path2
    Public Function Intersect(Path1 As GraphicsPath, Path2 As GraphicsPath, Optional Accurancy As Single = 0.01) As Boolean
        Dim oClipper As Clipper = New Clipper
        Dim oPaths As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
        Dim oPath1 As List(Of IntPoint) = New List(Of IntPoint)
        For Each oPoint As PointF In Path1.PathPoints
            Call oPath1.Add(New IntPoint(oPoint.X * 1000, oPoint.Y * 1000))
        Next
        Call oPaths.Add(oPath1)
        Dim oPath2 As List(Of IntPoint) = New List(Of IntPoint)
        For Each oPoint As PointF In Path2.PathPoints
            Call oPath2.Add(New IntPoint(oPoint.X * 1000, oPoint.Y * 1000))
        Next
        Call oPaths.Add(oPath2)
        Call oClipper.Execute(ClipType.ctIntersection, oPaths)
        Return oPaths.Count > 0
    End Function

    'path1 contains path2
    Public Function Contains(Path1 As GraphicsPath, Path2 As GraphicsPath, Optional Accurancy As Single = 1) As Boolean
        Dim oMatrix As Matrix = New Matrix
        Call oMatrix.Scale(1000, 1000)

        Dim oPath1 As GraphicsPath = Path1.Clone
        Call oPath1.Flatten(oMatrix, 10)
        Dim oPath2 As GraphicsPath = Path2.Clone
        Call oPath2.Flatten(oMatrix, 10)

        Dim oClipper As Clipper = New Clipper
        Dim oClippingPaths1 As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
        Dim oClippingPath1 As List(Of IntPoint) = New List(Of IntPoint)
        For Each oPoint As PointF In oPath1.PathPoints
            Call oClippingPath1.Add(New IntPoint(oPoint.X, oPoint.Y))
        Next
        Call oClippingPaths1.Add(oClippingPath1)
        Dim oClippingPaths2 As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
        Dim oClippingPath2 As List(Of IntPoint) = New List(Of IntPoint)
        For Each oPoint As PointF In oPath2.PathPoints
            Call oClippingPath2.Add(New IntPoint(oPoint.X, oPoint.Y))
        Next
        Call oClippingPaths2.Add(oClippingPath2)
        Call oClipper.AddPaths(oClippingPaths1, PolyType.ptClip, False)
        Call oClipper.AddPaths(oClippingPaths2, PolyType.ptSubject, False)
        Dim oPaths As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))

        Call oMatrix.Dispose()
        Call oPath1.Dispose()
        Call oPath2.Dispose()

        Call oClipper.Execute(ClipType.ctDifference, oPaths)

        Return oPaths.Count = 0
    End Function
End Module
