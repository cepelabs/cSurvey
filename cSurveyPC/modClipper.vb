Imports System.Drawing.Drawing2D

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

    Public Function ToIntPolygon(Polygon As List(Of PointF), Scale As Integer) As List(Of IntPoint)
        Dim oResPolygon As List(Of IntPoint) = New List(Of IntPoint)
        For Each oPoint As PointD In Polygon
            Call oResPolygon.Add(New IntPoint(oPoint.X * Scale, oPoint.Y * Scale))
        Next
        Return oResPolygon
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
