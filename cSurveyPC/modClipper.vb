Imports System.Drawing.Drawing2D

Module modClipper2
    Public Function ToPath(Polygon As IEnumerable(Of PointF)) As Clipper2Lib.PathD
        Return New Clipper2Lib.PathD(Polygon.Select(Function(oPoint) New Clipper2Lib.PointD(oPoint.X, oPoint.Y)))
    End Function

    Public Function ToPaths(Polygons As IEnumerable(Of IEnumerable(Of PointF))) As Clipper2Lib.PathsD
        Return New Clipper2Lib.PathsD(Polygons.Select(Function(oPolygon) ToPath(oPolygon)))
    End Function

    Public Function FromPath(Polygon As Clipper2Lib.PathD) As PointF()
        Dim oResults(Polygon.Count - 1) As PointF
        For i As Integer = 0 To Polygon.Count - 1
            oResults(i) = New PointF(Polygon(i).x, Polygon(i).y)
        Next
        Return oResults
    End Function

    Public Function FromPaths(Polygons As Clipper2Lib.PathsD) As PointF()()
        Dim oResults(Polygons.Count - 1)() As PointF
        For i As Integer = 0 To Polygons.Count - 1
            oResults(i) = FromPath(Polygons(i))
        Next
        Return oResults
    End Function

    Public Function Merge(Polygons As Clipper2Lib.PathsD) As Clipper2Lib.PathsD
        Dim oClipper As Clipper2Lib.ClipperD = New Clipper2Lib.ClipperD
        oClipper.AddSubject(Polygons)
        'For Each oPolygon As Clipper2Lib.PathD In Polygons
        '    oClipper.AddSubject(oPolygon)
        'Next
        Dim oResult As Clipper2Lib.PathsD = New Clipper2Lib.PathsD
        oClipper.Execute(Clipper2Lib.ClipType.Union, Clipper2Lib.FillRule.NonZero, oResult)
        Return oResult
    End Function

    Public Function Merge(Polygon1 As Clipper2Lib.PathsD, Polygon2 As Clipper2Lib.PathsD) As Clipper2Lib.PathsD
        Dim oClipper As Clipper2Lib.ClipperD = New Clipper2Lib.ClipperD
        oClipper.AddSubject(Polygon1)
        oClipper.AddSubject(Polygon2)
        Dim oResult As Clipper2Lib.PathsD = New Clipper2Lib.PathsD
        oClipper.Execute(Clipper2Lib.ClipType.Union, Clipper2Lib.FillRule.Positive, oResult)
        Return oResult
    End Function
End Module

Module modClipper
    Public Function ToIntPolygon(Polygon As List(Of PointD), Scale As Integer) As List(Of IntPoint)
        Dim oResPolygon As List(Of IntPoint) = New List(Of IntPoint)
        For Each oPoint As PointD In Polygon
            Call oResPolygon.Add(New IntPoint(oPoint.X * Scale, oPoint.Y * Scale))
        Next
        Return oResPolygon
    End Function

    Public Function GraphicsPathToIntPolygon(Path As GraphicsPath, Scale As Integer) As List(Of IntPoint)
        Using oPath As GraphicsPath = Path.Clone
            Dim sFlatness As Single = 1.0 / Scale
            Call oPath.Flatten(Nothing, sFlatness)
            Dim oResPolygon As List(Of IntPoint) = New List(Of IntPoint)
            For Each oPoint As PointF In oPath.PathPoints
                Call oResPolygon.Add(New IntPoint(oPoint.X * Scale, oPoint.Y * Scale))
            Next
            Return oResPolygon
        End Using
    End Function

    'Public Function ToIntPolygon(Polygon As List(Of PointF), Scale As Integer) As List(Of IntPoint)
    '    Dim oResPolygon As List(Of IntPoint) = New List(Of IntPoint)
    '    For Each oPoint As PointD In Polygon
    '        Call oResPolygon.Add(New IntPoint(oPoint.X * Scale, oPoint.Y * Scale))
    '    Next
    '    Return oResPolygon
    'End Function

    Public Function ToIntPolygon(Polygon As List(Of PointF), Scale As Integer) As List(Of IntPoint)
        Dim oResPolygon(Polygon.Count) As IntPoint
        For i As Integer = 0 To Polygon.Count - 1
            oResPolygon(i) = New IntPoint(Polygon(i).X * Scale, Polygon(i).Y * Scale)
        Next
        Return oResPolygon.ToList
    End Function

    Public Function ToIntPolygons(Polygons As List(Of List(Of PointD)), Scale As Integer) As List(Of List(Of IntPoint))
        Dim oResPolygons As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
        For Each oPolygon As List(Of PointD) In Polygons
            Dim oResPolygon As List(Of IntPoint) = New List(Of IntPoint)
            For Each oPoint As PointD In oPolygon
                Call oResPolygon.Add(New IntPoint(oPoint.X * Scale, oPoint.Y * Scale))
            Next
        Next
        Return oResPolygons
    End Function

    Public Function ToIntPolygons(Polygons As List(Of List(Of PointF)), Scale As Integer) As List(Of List(Of IntPoint))
        Dim oResPolygons As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
        For Each oPolygon As List(Of PointF) In Polygons
            Dim oResPolygon As List(Of IntPoint) = New List(Of IntPoint)
            For Each oPoint As PointD In oPolygon
                Call oResPolygon.Add(New IntPoint(oPoint.X * Scale, oPoint.Y * Scale))
            Next
        Next
        Return oResPolygons
    End Function

    Public Function FromIntPolygonToPointD(Polygon As List(Of IntPoint), Scale As Integer) As List(Of PointD)
        Dim oResPolygon As List(Of PointD) = New List(Of PointD)
        For Each oPoint As IntPoint In Polygon
            Call oResPolygon.Add(New PointD(Convert.ToDecimal(oPoint.X) / Scale, Convert.ToDecimal(oPoint.Y) / Scale))
        Next
        Return oResPolygon
    End Function

    Public Function FromIntPolygonToPointF(Polygon As List(Of IntPoint), Scale As Integer) As List(Of PointF)
        Dim oResPolygon As List(Of PointF) = New List(Of PointF)
        For Each oPoint As IntPoint In Polygon
            Call oResPolygon.Add(New PointF(Convert.ToSingle(oPoint.X) / Scale, Convert.ToSingle(oPoint.Y) / Scale))
        Next
        Return oResPolygon
    End Function

    Public Function FromIntPolygonsToPointF(Polygons As List(Of List(Of IntPoint)), Scale As Integer) As List(Of List(Of PointF))
        Dim oResPolygons As List(Of List(Of PointF)) = New List(Of List(Of PointF))
        For Each oPolygon As List(Of IntPoint) In Polygons
            Dim oResPolygon As List(Of PointF) = New List(Of PointF)
            For Each oPoint As IntPoint In oPolygon
                Call oResPolygon.Add(New PointD(Convert.ToSingle(oPoint.X) / Scale, Convert.ToSingle(oPoint.Y) / Scale))
            Next
            Call oResPolygons.Add(oResPolygon)
        Next
        Return oResPolygons
    End Function

    Public Function FromIntPolygonsToPointD(Polygons As List(Of List(Of IntPoint)), Scale As Integer) As List(Of List(Of PointD))
        Dim oResPolygons As List(Of List(Of PointD)) = New List(Of List(Of PointD))
        For Each oPolygon As List(Of IntPoint) In Polygons
            Dim oResPolygon As List(Of PointD) = New List(Of PointD)
            For Each oPoint As IntPoint In oPolygon
                Call oResPolygon.Add(New PointD(Convert.ToDecimal(oPoint.X) / Scale, Convert.ToDecimal(oPoint.Y) / Scale))
            Next
            Call oResPolygons.Add(oResPolygon)
        Next
        Return oResPolygons
    End Function
End Module
