Imports System.Drawing.Drawing2D
Imports System.Threading.Tasks
Imports DevExpress.Pdf.Native.BouncyCastle.Asn1.Tsp

Public Class cClipperHelper

    Public Shared Function GetPoint(Point As IntPoint, Optional Scale As Single = 1000.0F) As PointF
        Dim sX As Single = Point.X
        Dim sY As Single = Point.Y
        Return New PointF(sX / Scale, sY / Scale)
    End Function

    Public Shared Function GetIntPoint(Point As PointF, Optional Scale As Single = 1000.0F) As IntPoint
        Return New IntPoint(Point.X * Scale, Point.Y * Scale)
    End Function

    'Public Shared Function PointsToIntPath(Points As PointF()) As List(Of List(Of IntPoint))
    '    Dim oIntPaths As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
    '    Dim oIntPath As List(Of IntPoint) = New List(Of IntPoint)
    '    Call oIntPath.AddRange(Points)
    '    oIntPaths.Add(oIntPath)
    '    Return oIntPaths
    'End Function

    Public Shared Function IntPathsToGraphicsPath(intPaths As List(Of List(Of IntPoint)), Optional Scale As Single = 1000.0F) As GraphicsPath
        Dim oPath As GraphicsPath = New GraphicsPath
        If intPaths Is Nothing OrElse intPaths.Count = 0 Then
            Return oPath
        Else
            Dim invScale As Single = 1.0F / Scale
            For Each oSubpath As List(Of IntPoint) In intPaths
                If oSubpath Is Nothing OrElse oSubpath.Count = 0 Then
                    Continue For
                End If
                Dim oPoints As New List(Of PointF)(oSubpath.Count)
                For Each ip In oSubpath
                    oPoints.Add(New PointF(ip.X * invScale, ip.Y * invScale))
                Next
                oPath.StartFigure()
                If oPoints.Count = 1 Then
                    oPath.AddLine(oPoints(0), oPoints(0))
                Else
                    oPath.AddLines(oPoints.ToArray())
                End If
                oPath.CloseFigure()
            Next
            Return oPath
        End If
    End Function

    Public Shared Function GraphicsPathToIntPaths(path As GraphicsPath, Optional Scale As Single = 1000.0F, Optional Accurancy As Single = 0.1F) As List(Of List(Of IntPoint))
        Dim result As New List(Of List(Of IntPoint))()
        Using oBaseMatrix As Matrix = New Matrix
            Call oBaseMatrix.Scale(Scale, Scale)
            Using gp As GraphicsPath = CType(path.Clone(), GraphicsPath)
                gp.Flatten(Nothing, Accurancy)
                gp.Transform(oBaseMatrix)

                Dim pts = gp.PathPoints
                Dim types = gp.PathTypes
                Dim count = gp.PointCount

                ' 1) Trova gli indici di inizio dei subpath
                Dim starts As New List(Of Integer)
                For i As Integer = 0 To count - 1
                    If types(i) = PathPointType.Start Then
                        starts.Add(i)
                    End If
                Next

                If starts.Count = 0 Then
                    Return result
                End If

                ' 2) Crea gli intervalli (start, end)
                Dim ranges As New List(Of (Start As Integer, [End] As Integer))

                For i As Integer = 0 To starts.Count - 1
                    Dim s = starts(i)
                    Dim e = If(i = starts.Count - 1, count - 1, starts(i + 1) - 1)
                    ranges.Add((s, e))
                Next

                ' 3) Se c'è un solo subpath → versione singolo thread (più veloce)
                If ranges.Count = 1 Then
                    Dim r = ranges(0)
                    Dim list As New List(Of IntPoint)(r.[End] - r.Start + 1)

                    For j As Integer = r.Start To r.[End]
                        Dim p = pts(j)
                        list.Add(New IntPoint(CLng(p.X), CLng(p.Y)))
                    Next

                    result.Add(list)
                    Return result
                End If

                ' 4) MULTI-PATH → usa il parallelismo per ogni subpath indipendente
                Dim output(ranges.Count - 1) As List(Of IntPoint)

                Parallel.For(0, ranges.Count,
                    Sub(idx)
                        Dim r = ranges(idx)
                        Dim localList As New List(Of IntPoint)(r.[End] - r.Start + 1)

                        For j As Integer = r.Start To r.[End]
                            Dim p = pts(j)
                            localList.Add(New IntPoint(CLng(p.X), CLng(p.Y)))
                        Next

                        output(idx) = localList
                    End Sub
                )

                ' 5) Mantieni l'ordine dei subpath originali
                result.AddRange(output)
            End Using
        End Using

        Return result
    End Function

    'Public Shared Function GraphicsPathToIntPaths(Path As GraphicsPath, Optional Precision As Single = 10000.0F) As List(Of List(Of IntPoint))
    '    Dim oIntPaths As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
    '    Using oFlattenedPath As GraphicsPath = Path.Clone
    '        Call oFlattenedPath.Flatten(Nothing, Precision)
    '        Dim oIntPath As List(Of IntPoint) = Nothing
    '        For i As Integer = 0 To oFlattenedPath.PointCount - 1
    '            Dim oPoint As PointF = oFlattenedPath.PathPoints(i)
    '            Dim bType As Byte = oFlattenedPath.PathTypes(i)
    '            If (bType = PathPointType.Start) Then
    '                If oIntPath IsNot Nothing Then
    '                    Call oIntPaths.Add(oIntPath)
    '                End If
    '                oIntPath = New List(Of IntPoint)
    '            End If
    '            oIntPath.Add(GetIntPoint(oPoint, Precision))
    '        Next
    '        If oIntPath IsNot Nothing Then
    '            Call oIntPaths.Add(oIntPath)
    '        End If
    '    End Using
    '    Return oIntPaths
    'End Function

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
