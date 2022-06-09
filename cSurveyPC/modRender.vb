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
            'Dim oPointsColl As List(Of PointF) = New List(Of PointF)
            'Dim oArrowPoint As PointF = PaintPoint
            'Call oPointsColl.Add(oArrowPoint)
            'Call oPointsColl.Add(New PointF(oArrowPoint.X - sSize, oArrowPoint.Y - sSize * 2))
            'Call oPointsColl.Add(New PointF(oArrowPoint.X - sSize * 2, oArrowPoint.Y - sSize))
            'Dim oPoints As PointF() = oPointsColl.ToArray
            Using oBrush As SolidBrush = New SolidBrush(Color.DimGray)
                Dim oItem As cDrawCacheItem = Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, Nothing, Nothing, Nothing, oBrush)
                Call oItem.AddPolygon({PaintPoint, New PointF(PaintPoint.X - sSize, PaintPoint.Y - sSize * 2), New PointF(PaintPoint.X - sSize * 2, PaintPoint.Y - sSize)})
            End Using
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
                Using oBrush As Brush = If(.Colors.Length = 1, New SolidBrush(.GetColors(0)), New LinearGradientBrush(FromPaintPoint, ToPaintPoint, .GetColors(0), .GetColors(1)))
                    Using oPen As Pen = New Pen(oBrush, .Size / 2)
                        oPen.EndCap = LineCap.Round
                        oPen.StartCap = LineCap.Round
                        Dim oItem As cDrawCacheItem = Cache.Add(cDrawCacheItem.cDrawCacheItemType.Filler, Nothing, oPen)
                        Call oItem.AddLine(FromPaintPoint, ToPaintPoint)
                    End Using
                End Using
            End With
        End If
    End Sub

    Friend Sub RenderHighlightStation(Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, PaintPoint As PointF, Cache As cDrawCache, HighlightDetailMeters As Properties.cHighlightsDetailMeters)
        With HighlightDetailMeters
            Using oBrush1 As SolidBrush = New SolidBrush(Color.FromArgb(.Opacity / 3, .Color))
                Dim oItem As cDrawCacheItem = Cache.Add(cDrawCacheItem.cDrawCacheItemType.Filler, Nothing, Nothing, Nothing, oBrush1)
                Call oItem.AddEllipse(modPaint.GetRectanglefFomPoint(PaintPoint, .Size))
            End Using
            Using oBrush2 As SolidBrush = New SolidBrush(Color.FromArgb(.Opacity, .Color))
                Dim oItem As cDrawCacheItem = Cache.Add(cDrawCacheItem.cDrawCacheItemType.Filler, Nothing, Nothing, Nothing, oBrush2)
                Call oItem.AddEllipse(modPaint.GetRectanglefFomPoint(PaintPoint, .Size / 3))
            End Using
        End With
    End Sub

    Friend Sub RenderTrigPointName(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal TrigPoint As cTrigPoint, ByVal Position As PointF, ByVal Cache As cDrawCache)
        Dim oDrawingObject As cOptionsDrawingObjects = PaintOptions.DrawingObjects
        Dim sName As String = TrigPoint.Name
        If TrigPoint.IsSpecial Then
            sName = PaintOptions.Survey.Properties.GetFormattedSpecialTrigpointText(TrigPoint)
        Else
            sName = PaintOptions.Survey.Properties.GetFormattedTrigpointText(TrigPoint)
        End If
        Dim oLabelPosition As PointF = GetLabelPosition(Graphics, oDrawingObject.Font, sName, TrigPoint, Position, oDrawingObject.Font.GetHeight(Graphics) * (TrigPoint.LabelDistance / 10) / 2, oDrawingObject.Font.GetHeight(Graphics) * (TrigPoint.LabelDistance / 10) / 2)

        Dim oItem As cDrawCacheItem = Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, Nothing, Nothing, Nothing, oDrawingObject.TextBrush)
        Call oItem.AddString(sName, oDrawingObject.Font, oLabelPosition)
        'Dim oItem As cDrawCacheItem = Cache.AddString(sName, oDrawingObject.Font, oLabelPosition)
        'Call oItem.SetBrush(oDrawingObject.TextBrush)
    End Sub

    Friend Sub RenderTrigPoint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal TrigPoint As cTrigPoint, ByVal Position As PointF, ByVal PointSize As Single, ByVal PointBrush As Brush, ByVal PointPen As Pen, ByVal Cache As cDrawCache)
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
            Case cTrigPoint.TrigPointLabelSymbolEnum.EmptyTriangle
                Call oItem.SetPen(PointPen)
                Dim sR As Single = PointSize / 1.1!
                Dim oSize As SizeF = modPaint.Trigo(sR, 30)
                Dim oPoints() As PointF = {New PointF(Position.X, Position.Y - sR), New PointF(Position.X - oSize.Height, Position.Y + oSize.Width), New PointF(Position.X + oSize.Height, Position.Y + oSize.Width), New PointF(Position.X, Position.Y - sR)}
                Call oItem.AddPolygon(oPoints)
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
                Call oItem.StartFigure()
                Call oItem.AddLine(New PointF(Position.X, Position.Y - (PointSize / 2)), New PointF(Position.X, Position.Y + (PointSize / 2)))
            Case cTrigPoint.TrigPointLabelSymbolEnum.Cross
                Call oItem.SetPen(PointPen)
                Call oItem.AddLine(New PointF(Position.X - (PointSize / 2), Position.Y - (PointSize / 2)), New PointF(Position.X + (PointSize / 2), Position.Y + (PointSize / 2)))
                Call oItem.StartFigure()
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
