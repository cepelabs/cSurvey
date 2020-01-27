Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports ClipperLib

Module modPath
    'path1 intersect path2
    Public Function Intersect(Path1 As List(Of IntPoint), Path2 As List(Of IntPoint)) As Boolean
        Dim oClipper As Clipper = New Clipper
        Call oClipper.AddPath(Path1, PolyType.ptSubject, True)
        Call oClipper.AddPath(Path2, PolyType.ptClip, True)
        Dim oPaths As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
        Call oClipper.Execute(ClipType.ctIntersection, oPaths, PolyFillType.pftNonZero, PolyFillType.pftNonZero)
        Return oPaths.Count > 0
    End Function

    Public Function Intersect(Path1 As List(Of PointF), Path2 As List(Of PointF), Optional Accurancy As Single = 0.01) As Boolean
        Return modPath.Intersect(modClipper.ToIntPolygon(Path1, 1.0 / Accurancy), modClipper.ToIntPolygon(Path2, 1.0 / Accurancy))
    End Function

    Public Function Intersect(Path1 As GraphicsPath, Path2 As GraphicsPath, Optional Accurancy As Single = 0.01) As Boolean
        Return modPath.Intersect(modClipper.GraphicsPathToIntPolygon(Path1, 1.0 / Accurancy), modClipper.GraphicsPathToIntPolygon(Path2, 1.0 / Accurancy))
    End Function

    'path1 contains path2
    Public Function Contains(Path1 As List(Of IntPoint), Path2 As List(Of IntPoint)) As Boolean
        Using oPath1 As GraphicsPath = New GraphicsPath
            Call oPath1.AddPolygon(Path1.Select(Function(oItem) New Point(oItem.X, oItem.Y)).ToArray)
            For Each oPath2Point As Point In Path2.Select(Function(oItem) New Point(oItem.X, oItem.Y))
                If Not oPath1.IsVisible(oPath2Point) Then
                    Return False
                End If
            Next
            Using oPath2 As GraphicsPath = New GraphicsPath
                Call oPath2.AddPolygon(Path2.Select(Function(oItem) New Point(oItem.X, oItem.Y)).ToArray)
                For Each oPath1Point As Point In Path1.Select(Function(oItem) New Point(oItem.X, oItem.Y))
                    If Not oPath2.IsVisible(oPath1Point) Then
                        Return False
                    End If
                Next
                Return True
            End Using
        End Using
    End Function

    Public Function Contains(Path1 As List(Of PointF), Path2 As List(Of PointF)) As Boolean
        Using oPath1 As GraphicsPath = New GraphicsPath
            Call oPath1.AddPolygon(Path1.ToArray)
            For Each oPath2Point As PointF In Path2
                If Not oPath1.IsVisible(oPath2Point) Then
                    Return False
                End If
            Next
            Using oPath2 As GraphicsPath = New GraphicsPath
                Call oPath2.AddPolygon(Path2.ToArray)
                For Each oPath1point As PointF In Path1
                    If Not oPath2.IsVisible(oPath1point) Then
                        Return False
                    End If
                Next
                Return True
            End Using
        End Using
    End Function

    Public Function Contains(Path1 As GraphicsPath, Path2 As GraphicsPath, Optional Accurancy As Single = 0.01) As Boolean
        Using oPath1 As GraphicsPath = Path1.Clone
            Call oPath1.Flatten(Nothing, Accurancy)
            Using oPath2 As GraphicsPath = Path1.Clone
                Call oPath2.Flatten(Nothing, Accurancy)
                For Each oPath2Point As PointF In oPath2.PathPoints
                    If Not Path1.IsVisible(oPath2Point) Then
                        Return False
                    End If
                Next
                For Each oPath1Point As PointF In oPath1.PathPoints
                    If Not Path2.IsVisible(oPath1Point) Then
                        Return False
                    End If
                Next
                Return True
            End Using
        End Using
    End Function
End Module
