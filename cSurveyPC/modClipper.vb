Module modClipper
    Public Function ToIntPolygon(Polygon As List(Of PointD), Scale As Integer) As List(Of IntPoint)
        Dim oResPolygon As List(Of IntPoint) = New List(Of IntPoint)
        For Each oPoint As PointD In Polygon
            Call oResPolygon.Add(New IntPoint(oPoint.X * Scale, oPoint.Y * 1000))
        Next
        Return oResPolygon
    End Function

    Public Function ToIntPolygons(Polygons As List(Of List(Of PointD)), Scale As Integer) As List(Of List(Of IntPoint))
        Dim oResPolygons As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
        For Each oPolygon As List(Of PointD) In Polygons
            Dim oResPolygon As List(Of IntPoint) = New List(Of IntPoint)
            For Each oPoint As PointD In oPolygon
                Call oResPolygon.Add(New IntPoint(oPoint.X * Scale, oPoint.Y * 1000))
            Next
        Next
        Return oResPolygons
    End Function

    Public Function FromIntPolygon(Polygon As List(Of IntPoint), Scale As Integer) As List(Of PointD)
        Dim oResPolygon As List(Of PointD) = New List(Of PointD)
        For Each oPoint As IntPoint In Polygon
            Call oResPolygon.Add(New PointD(Convert.ToDecimal(oPoint.X) / Scale, Convert.ToDecimal(oPoint.Y) / 1000))
        Next
        Return oResPolygon
    End Function

    Public Function FromIntPolygons(Polygons As List(Of List(Of IntPoint)), Scale As Integer) As List(Of List(Of PointD))
        Dim oResPolygons As List(Of List(Of PointD)) = New List(Of List(Of PointD))
        For Each oPolygon As List(Of IntPoint) In Polygons
            Dim oResPolygon As List(Of PointD) = New List(Of PointD)
            For Each oPoint As IntPoint In oPolygon
                Call oResPolygon.Add(New PointD(Convert.ToDecimal(oPoint.X) / Scale, Convert.ToDecimal(oPoint.Y) / 1000))
            Next
            Call oResPolygons.Add(oResPolygon)
        Next
        Return oResPolygons
    End Function
End Module
