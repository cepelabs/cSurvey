Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Net
Imports System.Drawing.Imaging

Imports cSurveyPC
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Options
Imports cSurveyPC.cSurvey.Drawings

Module modRender

    Friend Sub RenderEntrancePoint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, ByVal PaintPoint As PointF, ByVal Cache As cDrawCache, ShowEntrance As Boolean)
        If ShowEntrance Then
            Dim sSize As Single = 0.5
            Dim oPointsColl As List(Of PointF) = New List(Of PointF)
            Dim oArrowPoint As PointF = PaintPoint
            Call oPointsColl.Add(oArrowPoint)
            Call oPointsColl.Add(New PointF(oArrowPoint.X - sSize, oArrowPoint.Y - sSize * 2))
            Call oPointsColl.Add(New PointF(oArrowPoint.X - sSize * 2, oArrowPoint.Y - sSize))
            Dim oPoints As PointF() = oPointsColl.ToArray
            Dim oBrush As SolidBrush = New SolidBrush(Color.DimGray)
            Dim oItem As cDrawCacheItem = Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
            Call oItem.SetBrush(oBrush)
            Call oItem.AddPolygon(oPoints)
            Call oBrush.Dispose()
        End If
        'If PaintOptions.DrawHighlights AndAlso PaintOptions.HighlightsOptions.Entrance Then
        '    With PaintOptions.Survey.Properties.HighlightsDetails(Properties.cHighlightsDetails.EntranceKey)
        '        Call RenderSpot(Graphics, PaintPoint, Cache, .Color, .Size, .Opacity)
        '    End With
        'End If
    End Sub

    Friend Sub RenderHighlightShot(Graphics As Graphics, ByVal PaintOptions As cOptions, FromPaintPoint As PointF, ToPaintPoint As PointF, Cache As cDrawCache, HighlightDetailMeters As Properties.cHighlightsDetailMeters)
        If FromPaintPoint <> ToPaintPoint Then
            With HighlightDetailMeters
                Dim oBrush As Brush
                If .Colors.Length = 1 Then
                    oBrush = New SolidBrush(.Color)
                Else
                    oBrush = New LinearGradientBrush(FromPaintPoint, ToPaintPoint, .Colors(0), .Colors(1))
                End If
                Dim oSegmentItem As cDrawCacheItem = Cache.Add(cDrawCacheItem.cDrawCacheItemType.Filler)
                Dim oPen As Pen = New Pen(oBrush, .Size / 2)
                'oPen.StartCap = LineCap.Round
                'oPen.EndCap = LineCap.Round
                Call oSegmentItem.SetPen(oPen)
                Call oSegmentItem.AddLine(FromPaintPoint, ToPaintPoint)
                Call oBrush.Dispose()
                Call oPen.Dispose()
            End With
        End If
    End Sub

    Friend Sub RenderHighlightStation(Graphics As Graphics, ByVal PaintOptions As cOptions, PaintPoint As PointF, Cache As cDrawCache, HighlightDetailMeters As Properties.cHighlightsDetailMeters)
        With HighlightDetailMeters
            Dim oBrush1 As SolidBrush = New SolidBrush(Color.FromArgb(.Opacity / 3, .Color))
            Dim oRect1 As RectangleF = modPaint.GetRectanglefFomPoint(PaintPoint, .Size)
            Dim oBrush2 As SolidBrush = New SolidBrush(Color.FromArgb(.Opacity, .Color))
            Dim oRect2 As RectangleF = modPaint.GetRectanglefFomPoint(PaintPoint, .Size / 3)
            Dim oSpotItem1 As cDrawCacheItem = Cache.Add(cDrawCacheItem.cDrawCacheItemType.Filler)
            Call oSpotItem1.SetBrush(oBrush1)
            Call oSpotItem1.AddEllipse(oRect1)
            Dim oSpotItem2 As cDrawCacheItem = Cache.Add(cDrawCacheItem.cDrawCacheItemType.Filler)
            Call oSpotItem2.SetBrush(oBrush2)
            Call oSpotItem2.AddEllipse(oRect2)
            Call oBrush1.Dispose()
            Call oBrush2.Dispose()
        End With
    End Sub

    'Friend Sub RenderSpot(Graphics As Graphics, PaintPoint As PointF, Cache As cDrawCache, Color As Color, Size As Single, Opacity As Byte)
    '    Dim oBrush1 As SolidBrush = New SolidBrush(Color.FromArgb(Opacity / 3, Color))
    '    Dim oRect1 As RectangleF = modPaint.GetRectanglefFomPoint(PaintPoint, Size)
    '    Dim oBrush2 As SolidBrush = New SolidBrush(Color.FromArgb(Opacity, Color))
    '    Dim oRect2 As RectangleF = modPaint.GetRectanglefFomPoint(PaintPoint, Size / 3)
    '    Dim oSpotItem1 As cDrawCacheItem = Cache.Add(cDrawCacheItem.cDrawCacheItemType.Filler)
    '    Call oSpotItem1.SetBrush(oBrush1)
    '    Call oSpotItem1.AddEllipse(oRect1)
    '    Dim oSpotItem2 As cDrawCacheItem = Cache.Add(cDrawCacheItem.cDrawCacheItemType.Filler)
    '    Call oSpotItem2.SetBrush(oBrush2)
    '    Call oSpotItem2.AddEllipse(oRect2)
    '    Call oBrush1.Dispose()
    '    Call oBrush2.Dispose()
    'End Sub

    'Friend Sub RenderGPSPoint(Graphics As Graphics, ByVal PaintOptions As cOptions, PaintPoint As PointF, Cache As cDrawCache, Fix As cCoordinate.FixEnum)
    '    If PaintOptions.DrawHighlights Then
    '        If PaintOptions.HighlightsOptions.StationWithGPSDefaultFix AndAlso Fix = cCoordinate.FixEnum.Default Then
    '            With PaintOptions.Survey.Properties.HighlightsDetails(Properties.cHighlightsDetails.GPSDefaultFix)
    '                Call RenderSpot(Graphics, PaintPoint, Cache, .Color, .Size, .Opacity)
    '            End With
    '        ElseIf PaintOptions.HighlightsOptions.StationWithGPSManualFix AndAlso Fix = cCoordinate.FixEnum.Manual Then
    '            With PaintOptions.Survey.Properties.HighlightsDetails(Properties.cHighlightsDetails.GPSManualFix)
    '                Call RenderSpot(Graphics, PaintPoint, Cache, .Color, .Size, .Opacity)
    '            End With
    '        End If
    '    End If
    'End Sub

    'Friend Sub RenderPointWithNote(Graphics As Graphics, ByVal PaintOptions As cOptions, PaintPoint As PointF, Cache As cDrawCache)
    '    If PaintOptions.DrawHighlights AndAlso PaintOptions.HighlightsOptions.StationWithNote Then
    '        With PaintOptions.Survey.Properties.HighlightsDetails(Properties.cHighlightsDetails.StationWithNote)
    '            Call RenderSpot(Graphics, PaintPoint, Cache, .Color, .Size, .Opacity)
    '        End With
    '    End If
    'End Sub

    'Friend Sub RenderExplorationPoint(Graphics As Graphics, ByVal PaintOptions As cOptions, PaintPoint As PointF, Cache As cDrawCache)
    '    If PaintOptions.DrawHighlights AndAlso PaintOptions.HighlightsOptions.Exploration Then
    '        With PaintOptions.Survey.Properties.HighlightsDetails(Properties.cHighlightsDetails.ExplorationKey)
    '            Call RenderSpot(Graphics, PaintPoint, Cache, .Color, .Size, .Opacity)
    '        End With
    '    End If
    'End Sub

    Friend Sub RenderTrigPointName(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, ByVal TrigPoint As cTrigPoint, ByVal Position As PointF, ByVal Cache As cDrawCache)
        Dim oDrawingObject As cOptionsDrawingObjects = PaintOptions.DrawingObjects
        Dim sName As String = TrigPoint.Name
        If TrigPoint.IsSpecial Then
            sName = PaintOptions.Survey.Properties.GetFormattedSpecialTrigpointText(TrigPoint)
        Else
            sName = PaintOptions.Survey.Properties.GetFormattedTrigpointText(TrigPoint)
        End If
        Dim oLabelPosition As PointF = GetLabelPosition(Graphics, oDrawingObject.Font, sName, TrigPoint, Position, oDrawingObject.Font.GetHeight(Graphics) * (TrigPoint.LabelDistance / 10) / 2, oDrawingObject.Font.GetHeight(Graphics) * (TrigPoint.LabelDistance / 10) / 2)
        Dim oItem As cDrawCacheItem = Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
        Call oItem.SetBrush(oDrawingObject.TextBrush)
        Call oItem.AddString(sName, oDrawingObject.Font, oLabelPosition)
    End Sub

    Friend Sub RenderTrigPoint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, ByVal TrigPoint As cTrigPoint, ByVal Position As PointF, ByVal PointSize As Single, ByVal PointBrush As Brush, ByVal PointPen As Pen, ByVal Cache As cDrawCache)
        Dim iLabelSymbol As cTrigPoint.TrigPointLabelSymbolEnum
        If TrigPoint.LabelSymbol = cTrigPoint.TrigPointLabelSymbolEnum.Default Then
            iLabelSymbol = PaintOptions.Survey.Properties.DesignProperties.GetValue("PlotPointSymbol", cTrigPoint.TrigPointLabelSymbolEnum.Triangle)
        Else
            iLabelSymbol = TrigPoint.LabelSymbol
        End If
        Dim oItem As cDrawCacheItem = Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
        Select Case iLabelSymbol
            Case cTrigPoint.TrigPointLabelSymbolEnum.Triangle
                Call oItem.SetPen(PointPen)
                Call oItem.SetBrush(PointBrush)
                Dim sR As Single = PointSize / 1.1!
                Dim oSize As SizeF = modPaint.Trigo(sR, 30)
                Dim oPoints() As PointF = {New PointF(Position.X, Position.Y - sR), New PointF(Position.X - oSize.Height, Position.Y + oSize.Width), New PointF(Position.X + oSize.Height, Position.Y + oSize.Width), New PointF(Position.X, Position.Y - sR)}
                Call oItem.AddPolygon(oPoints)
                'Call oItem.AddLine(New PointF(Position.X - oSize.Height, Position.Y + oSize.Width), New PointF(Position.X + oSize.Height, Position.Y + oSize.Width))
                'Call oItem.AddLine(New PointF(Position.X + oSize.Height, Position.Y + oSize.Width), New PointF(Position.X, Position.Y - (PointSize / 2)))
            Case cTrigPoint.TrigPointLabelSymbolEnum.EmptyTriangle
                Call oItem.SetPen(PointPen)
                Dim sR As Single = PointSize / 1.1!
                Dim oSize As SizeF = modPaint.Trigo(sR, 30)
                Dim oPoints() As PointF = {New PointF(Position.X, Position.Y - sR), New PointF(Position.X - oSize.Height, Position.Y + oSize.Width), New PointF(Position.X + oSize.Height, Position.Y + oSize.Width), New PointF(Position.X, Position.Y - sR)}
                Call oItem.AddPolygon(oPoints)
                'Call oItem.AddLine(New PointF(Position.X, Position.Y - (PointSize / 2)), New PointF(Position.X - oSize.Height, Position.Y + oSize.Width))
                'Call oItem.AddLine(New PointF(Position.X - oSize.Height, Position.Y + oSize.Width), New PointF(Position.X + oSize.Height, Position.Y + oSize.Width))
                'Call oItem.AddLine(New PointF(Position.X + oSize.Height, Position.Y + oSize.Width), New PointF(Position.X, Position.Y - (PointSize / 2)))
            Case cTrigPoint.TrigPointLabelSymbolEnum.Square
                Dim oRect As RectangleF = New RectangleF(Position.X - (PointSize / 2), Position.Y - (PointSize / 2), PointSize, PointSize)
                Call oItem.SetBrush(PointBrush)
                Call oItem.SetPen(PointPen)
                Call oItem.AddRectangle(oRect)
            Case cTrigPoint.TrigPointLabelSymbolEnum.Circle
                Dim oRect As RectangleF = New RectangleF(Position.X - (PointSize / 2), Position.Y - (PointSize / 2), PointSize, PointSize)
                Call oItem.SetBrush(PointBrush)
                Call oItem.SetPen(PointPen)
                Call oItem.AddEllipse(oRect)
            Case cTrigPoint.TrigPointLabelSymbolEnum.Plus
                Call oItem.SetPen(PointPen)
                Call oItem.AddLine(New PointF(Position.X - (PointSize / 2), Position.Y), New PointF(Position.X + (PointSize / 2), Position.Y))
                Call oItem.AddLine(New PointF(Position.X, Position.Y - (PointSize / 2)), New PointF(Position.X, Position.Y + (PointSize / 2)))
            Case cTrigPoint.TrigPointLabelSymbolEnum.Cross
                Call oItem.SetPen(PointPen)
                Call oItem.AddLine(New PointF(Position.X - (PointSize / 2), Position.Y - (PointSize / 2)), New PointF(Position.X + (PointSize / 2), Position.Y + (PointSize / 2)))
                Call oItem.AddLine(New PointF(Position.X + (PointSize / 2), Position.Y - (PointSize / 2)), New PointF(Position.X - (PointSize / 2), Position.Y + (PointSize / 2)))
            Case cTrigPoint.TrigPointLabelSymbolEnum.EmptySquare
                Dim oRect As RectangleF = New RectangleF(Position.X - (PointSize / 2), Position.Y - (PointSize / 2), PointSize, PointSize)
                Call oItem.SetPen(PointPen)
                Call oItem.AddRectangle(oRect)
            Case cTrigPoint.TrigPointLabelSymbolEnum.EmptyCircle
                Dim oRect As RectangleF = New RectangleF(Position.X - (PointSize / 2), Position.Y - (PointSize / 2), PointSize, PointSize)
                Call oItem.SetPen(PointPen)
                Call oItem.AddEllipse(oRect)
        End Select
    End Sub

    Friend Function GetLabelPosition(ByVal Graphics As Graphics, ByVal Font As Font, ByVal Text As String, ByVal TrigPoint As cTrigPoint, ByVal Point As PointF, ByVal OffsetX As Single, ByVal OffSetY As Single) As PointF
        Return GetLabelPosition(Graphics, Font, Text, TrigPoint, Point.X, Point.Y, OffsetX, OffSetY)
    End Function

    Friend Function GetLabelPosition(ByVal Graphics As Graphics, ByVal Font As Font, ByVal Text As String, ByVal Segment As cSegment, ByVal Point As PointF, ByVal OffsetX As Single, ByVal OffSetY As Single) As PointF
        Return GetLabelPosition(Graphics, Font, Text, Segment, Point.X, Point.Y, OffsetX, OffSetY)
    End Function

    Friend Function GetLabelPosition(ByVal Graphics As Graphics, ByVal Font As Font, ByVal Text As String, ByVal Segment As cSegment, ByVal X As Single, ByVal Y As Single, ByVal OffsetX As Single, ByVal OffSetY As Single) As PointF
        Return GetLabelPosition(Graphics, Font, Text, Segment.GetToTrigPoint, X, Y, OffsetX, OffSetY)
    End Function

    Friend Function GetLabelPosition(ByVal Graphics As Graphics, ByVal Font As Font, ByVal Text As String, ByVal TrigPoint As cTrigPoint, ByVal X As Single, ByVal Y As Single, ByVal OffsetX As Single, ByVal OffSetY As Single) As PointF
        Dim oSize As SizeF = Graphics.MeasureString(Text, Font, 200)
        Select Case TrigPoint.LabelPosition
            Case cTrigPoint.TrigPointLabelPositionEnum.TopLeft
                Return New PointF(X - OffsetX - oSize.Width / 2, Y - OffSetY - oSize.Height / 2)
            Case cTrigPoint.TrigPointLabelPositionEnum.TopMiddle
                Return New PointF(X - oSize.Width / 2, Y - OffSetY - oSize.Height / 2)
            Case cTrigPoint.TrigPointLabelPositionEnum.TopRight
                Return New PointF(X + OffsetX - oSize.Width / 2, Y - OffSetY - oSize.Height / 2)
            Case cTrigPoint.TrigPointLabelPositionEnum.CenterLeft
                Return New PointF(X - OffsetX - oSize.Width / 2, Y - oSize.Height / 2)
            Case cTrigPoint.TrigPointLabelPositionEnum.Center
                Return New PointF(X - oSize.Width / 2, Y - oSize.Height / 2)
            Case cTrigPoint.TrigPointLabelPositionEnum.CenterRight
                Return New PointF(X + OffsetX - oSize.Width / 2, Y - oSize.Height / 2)
            Case cTrigPoint.TrigPointLabelPositionEnum.BottomLeft
                Return New PointF(X - OffsetX - oSize.Width / 2, Y + OffSetY - oSize.Height / 2)
            Case cTrigPoint.TrigPointLabelPositionEnum.BottomCenter
                Return New PointF(X - oSize.Width / 2, Y + OffSetY - oSize.Height / 2)
            Case cTrigPoint.TrigPointLabelPositionEnum.BottomRight
                Return New PointF(X + OffsetX - oSize.Width / 2, Y + OffSetY - oSize.Height / 2)
        End Select
    End Function
End Module
