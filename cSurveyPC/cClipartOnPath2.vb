Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings

Public Class cClipartOnPath2
    Public Enum ClipartIntersectModeEnum
        None = 0
        CheckIfIntersectNearby = 1
    End Enum
    Public Enum ClipartScaleModeEnum
        None = 0
        OnX = 1
        OnY = 2
        OnBoth = 3
    End Enum
    Public Enum ClipartPositionEnum
        OverPath = 0
        CenterPath = 1
        UnderPath = 2
    End Enum

    Private Const sFlattenFactor As Single = 0.01
    Private Const iMaxPointCount As Integer = 20000

    Public Shared Function ClipartOnPath(ByVal Graphics As Graphics, ByVal Pathdata As PathData, ByVal Clipart As cDrawClipArt, ClipartPosition As ClipartPositionEnum, ByVal ClipartSpacePercentage As Integer, ClipartScaleMode As ClipartScaleModeEnum, ClipartIntersectMode As ClipartIntersectModeEnum, ByVal Color As Color, ByVal FillColor As Color, ByVal Zoom As Single) As GraphicsPath
        Dim sZoom As Single = Zoom / 3
        Dim oTransformedPath As cDrawPaths
        Dim oBounds As RectangleF = Clipart.GetBounds
        Dim oStandardBounds As RectangleF = New RectangleF(0, 0, 1, 1)
        Dim sBaseScaleFactor As Single = modPaint.ScaleToFit(oBounds, oStandardBounds)
        Using oTransformMatrix As Matrix = New Matrix
            Call oTransformMatrix.Scale(sZoom * 1 / sBaseScaleFactor, sZoom * 1 / sBaseScaleFactor)
            oTransformedPath = Clipart.TransformPaths(oTransformMatrix)
        End Using
        Dim sClipartSpacePercentage As Single = ClipartSpacePercentage / 2000
        If sClipartSpacePercentage < 0.51 Then sClipartSpacePercentage = 0.51

        'Using oTransformMatrix As Matrix = New Matrix
        '    Call oTransformMatrix.Scale(sZoom, sZoom)
        '    oTransformedPath = Clipart.TransformPaths(oTransformMatrix)
        'End Using
        'Dim sClipartSpacePercentage As Single = ClipartSpacePercentage '/ 50

        Dim oPoints As List(Of PointF) = New List(Of PointF)
        Dim oResultPoints As List(Of PointF) = New List(Of PointF)
        Using oPath As GraphicsPath = New GraphicsPath(Pathdata.Points, Pathdata.Types)
            If oPath.PointCount > 1 Then
                oPath.FillMode = FillMode.Winding
                Call oPath.Flatten(Nothing, sFlattenFactor)
                Dim oPoint As PointF = oPath.PathPoints(0)
                For i As Integer = 0 To oPath.PathPoints.Length - 2
                    If oPath.PathTypes(i + 1) = PathPointType.Start Or (oPath.PathTypes(i) And PathPointType.CloseSubpath) = PathPointType.CloseSubpath Then
                        Call oResultPoints.AddRange(pGetLinePoints(oPath.PathPoints(i), oPoint))
                        oPoint = oPath.PathPoints(i + 1)
                    Else
                        Call oResultPoints.AddRange(pGetLinePoints(oPath.PathPoints(i), oPath.PathPoints(i + 1)))
                    End If
                Next
                oResultPoints = pCleanPoints(oResultPoints)
            End If
        End Using
        Return pDrawClipart(Graphics, oBounds, oTransformedPath, oResultPoints, ClipartPosition, sClipartSpacePercentage, ClipartScaleMode, ClipartIntersectMode)
    End Function

    Private Shared Function pCleanPoints(ByVal Points As List(Of PointF)) As List(Of PointF)
        Dim oPointResults As List(Of PointF) = New List(Of PointF)
        Dim oLastPoint As PointF
        Dim i As Integer = 0
        For Each oPoint As PointF In Points
            If i = 0 Or oPoint.X <> oLastPoint.X Or oPoint.Y <> oLastPoint.Y Then
                Call oPointResults.Add(oPoint)
            End If
            oLastPoint = oPoint
            i += 1
        Next
        Return oPointResults
    End Function

    Private Shared Function pDrawClipart(ByVal Graphics As Graphics, Bounds As RectangleF, TransformedPath As cDrawPaths, ByVal Points As List(Of PointF), ClipartPosition As ClipartPositionEnum, ClipartSpacePercentage As Single, ClipartScaleMode As ClipartScaleModeEnum, ClipartIntersectMode As ClipartIntersectModeEnum) As GraphicsPath
        Dim oPath As GraphicsPath = New GraphicsPath
        'Call oPath.AddLines(Points.ToArray)
        'Call oPath.StartFigure()

        Dim iPointCount As Integer = Points.Count - 1
        Dim sCount As Single = 1
        Dim oPoint1 As PointF '= Points(0)
        Dim oPoint2 As PointF
        Dim oPoint As PointF

        Dim sAngle As Single
        Dim sScaleX As Single
        Dim sScaleY As Single
        Dim sWidth As Single
        'Dim sAvgWidthClipart As Single = (TransformedPath.GetBounds.Width) * ClipartSpacePercentage '/ 100
        'If sAvgWidthClipart < 0.1 Then sAvgWidthClipart = 0.1
        Dim sAvgWidth As Single = TransformedPath.GetBounds.Width
        If sAvgWidth < 0.1 Then sAvgWidth = 0.1
        Dim sSpace As Single = (sAvgWidth * ClipartSpacePercentage) - sAvgWidth

        Dim oLastRegion As Region = Nothing

        Dim iIndex As Integer = 0
        Dim iNextIndex As Integer = 0
        Dim iCount As Integer = Points.Count - 1
        Try
            Do
                If ClipartScaleMode = ClipartScaleModeEnum.None Then
                    sScaleX = 1
                    sScaleY = 1
                ElseIf ClipartScaleMode = ClipartScaleModeEnum.OnX Then
                    sScaleX = (1 + (-0.4 + Rnd(1) * 0.8))
                    sScaleY = 1
                ElseIf ClipartScaleMode = ClipartScaleModeEnum.OnY Then
                    sScaleX = 1
                    sScaleY = (1 + (-0.4 + Rnd(1) * 0.8))
                ElseIf ClipartScaleMode = ClipartScaleModeEnum.OnBoth Then
                    sScaleX = (1 + (-0.4 + Rnd(1) * 0.8))
                    sScaleY = (1 + (-0.4 + Rnd(1) * 0.8))
                End If
                sWidth = (sAvgWidth * sScaleX) + sSpace * 2
                Do
                    iNextIndex = iIndex + sWidth / sFlattenFactor
                    If iNextIndex > iCount - 1 Then Exit Do
                    oPoint1 = Points(iIndex)
                    oPoint2 = Points(iNextIndex)
                    'If modPaint.DistancePointToPoint(oPoint1, oPoint2) >= sWidth Then
                    'Dim iCenterIndex1 As Integer = (iIndex + iNextIndex / 2) - 5
                    'Dim iCenterIndex2 As Integer = (iIndex + iNextIndex / 2) + 5
                    'Dim oCenterPoint1 As PointF = Points(iCenterIndex1)
                    'Dim oCenterPoint2 As PointF = Points(iCenterIndex2)
                    'oPoint = pGetMiddlePoint(oCenterPoint1, oCenterPoint2)
                    oPoint = Points(iIndex + (iNextIndex - iIndex) / 2)
                    'sAngle = pGetAngle(oCenterPoint1, oCenterPoint2)
                    sAngle = pGetAngle(oPoint1, oPoint2)
                    Using oClipartPath As GraphicsPath = pDrawRotatedClipart(Graphics, TransformedPath, ClipartPosition, sScaleX, sScaleY, sAngle, oPoint)
                        Dim bOk As Boolean = False
                        If ClipartIntersectMode = ClipartIntersectModeEnum.None Then
                            bOk = True
                        ElseIf ClipartIntersectMode = ClipartIntersectModeEnum.CheckIfIntersectNearby Then
                            If IsNothing(oLastRegion) Then
                                bOk = True
                            Else
                                Using oIntersectRegion As Region = oLastRegion.Clone
                                    oIntersectRegion.Intersect(oClipartPath)
                                    If Not oIntersectRegion.IsEmpty(Graphics) Then
                                        Graphics.FillRegion(Brushes.Red, oIntersectRegion)
                                    End If
                                    bOk = oIntersectRegion.IsEmpty(Graphics)
                                End Using
                            End If
                        End If
                        If bOk Then
                            If Not IsNothing(oLastRegion) Then oLastRegion.Dispose()
                            oLastRegion = New Region(oClipartPath)
                            Call oPath.AddPath(oClipartPath, False)
                            iIndex = iNextIndex
                            Exit Do
                        End If
                    End Using
                    'End If
                Loop While iNextIndex < iCount
            Loop While iIndex < iCount - 1 And iNextIndex < iCount
            If Not IsNothing(oLastRegion) Then oLastRegion.Dispose()
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try


        'Dim sWidth As Single = sMaxWidthClipart + sMaxWidthClipart * ClipartSpacePercentage / 100
        'If sWidth < 1 Then sWidth = 1

        'Do While sCount < iPointCount
        '    If (sCount + sWidth \ 2) >= 0 And (sCount + sWidth) < iPointCount Then
        '        sCount += sWidth
        '        oPoint2 = Points(sCount)
        '        oPoint = Points(sCount - sWidth \ 2)
        '        sAngle = pGetAngle(oPoint1, oPoint2)
        '        Call oPath.AddPath(pDrawRotatedClipart(Graphics, TransformedPath, ClipartPosition, sAngle, oPoint), False)
        '        oPoint1 = Points(sCount)
        '    Else
        '        sCount += sWidth
        '    End If
        'Loop
        Return oPath
    End Function

    Private Shared Function pGetMiddlePoint(ByVal P1 As PointF, ByVal P2 As PointF) As PointF
        Return New PointF(P1.X + (P2.X - P1.X) / 2, P1.Y + (P2.Y - P1.Y) / 2)
    End Function

    Private Shared Function pGetAngle(ByVal P1 As PointF, ByVal P2 As PointF) As Single
        Dim c As Single = Math.Sqrt((P2.X - P1.X) ^ 2 + (P2.Y - P1.Y) ^ 2)
        If c = 0 Then
            Return 0
        Else
            If P1.X > P2.X Then
                Return Math.Asin((P1.Y - P2.Y) / c) * 180 / Math.PI - 180
            Else
                Return Math.Asin((P2.Y - P1.Y) / c) * 180 / Math.PI
            End If
        End If
    End Function

    Private Shared Function pDrawRotatedClipart(ByVal Graphics As Graphics, TransformedPath As cDrawPaths, ClipartPosition As ClipartPositionEnum, ScaleX As Single, ScaleY As Single, ByVal Angle As Single, ByVal Center As PointF) As GraphicsPath
        Dim oBasePath As GraphicsPath = New GraphicsPath(Drawing.Drawing2D.FillMode.Winding)
        Dim x As Single = Center.X
        Dim y As Single = Center.Y
        Using oMatrix As Matrix = New Matrix
            If ScaleX <> 1 And ScaleY <> 1 Then
                Call oMatrix.Scale(ScaleX, ScaleY, MatrixOrder.Append)
            End If
            Select Case ClipartPosition
                Case ClipartPositionEnum.OverPath
                    Call oMatrix.Translate(x - TransformedPath.GetBounds.Width * ScaleX / 2, y - TransformedPath.GetBounds.Height * ScaleY, MatrixOrder.Append)
                Case ClipartPositionEnum.CenterPath
                    Call oMatrix.Translate(x - TransformedPath.GetBounds.Width * ScaleX / 2, y - TransformedPath.GetBounds.Height * ScaleY / 2, MatrixOrder.Append)
                Case ClipartPositionEnum.UnderPath
                    Call oMatrix.Translate(x - TransformedPath.GetBounds.Width * ScaleX / 2, y, MatrixOrder.Append)
            End Select
            Call oMatrix.RotateAt(Angle, Center, MatrixOrder.Append)
            For Each oDrawPath As cDrawPath In TransformedPath
                Call oBasePath.AddPath(oDrawPath.Path, False)
            Next
            Call oBasePath.Transform(oMatrix)
        End Using
        Return oBasePath
    End Function

    Private Shared Function pGetLinePoints(ByVal P1 As PointF, ByVal P2 As PointF) As List(Of PointF)
        Dim oPoints As List(Of PointF) = New List(Of PointF)
        Dim sDistance As Single = modPaint.DistancePointToPoint(P1, P2)
        If sDistance = 0 Then
            Return oPoints
        Else
            Dim sSteps As Single = sDistance / sFlattenFactor
            Dim sStepX As Single = (P2.X - P1.X) / sSteps
            Dim sStepY As Single = (P2.Y - P1.Y) / sSteps
            Dim iSteps As Integer = sSteps
            Dim oNextPoint As PointF = P1
            For iStep = 0 To iSteps - 1
                oNextPoint.X += +sStepX
                oNextPoint.Y += +sStepY
                Call oPoints.Add(oNextPoint)
            Next
            Return oPoints
        End If

        'Dim iCount As Integer = 0
        ''Dim oPoints(iMaxPointCount) As PointF
        'Dim oPoints As List(Of PointF) = New List(Of PointF)
        'Dim sX As Single
        'Dim sY As Single
        'Dim sIncrement As Single = sFlattenFactor
        'Dim sWidth As Single = P2.X - P1.X
        'Dim sHeight As Single = P2.Y - P1.Y

        'Dim sDW As Single
        'Dim sDH As Single
        'Dim sStep As Single = StepWidth

        'Dim d As Single = 0

        'If sWidth < 0 Then
        '    sWidth = -sWidth
        '    sX = -sIncrement
        'Else
        '    sX = sIncrement
        'End If

        'If sHeight < 0 Then
        '    sHeight = -sHeight
        '    sY = -sIncrement
        'Else
        '    sY = sIncrement
        'End If

        'If sWidth > sHeight Then
        '    sDW = sWidth + sWidth
        '    sDH = sHeight + sHeight

        '    Do
        '        If sStep = StepWidth Then
        '            Call oPoints.Add(P1)
        '        Else
        '            sStep += StepWidth
        '        End If
        '        If modNumbers.MathRound(P1.X, 3) = modNumbers.MathRound(P2.X, 3) Then Exit Do
        '        P1.X += sX
        '        d += sDH
        '        If d > sWidth Then
        '            P1.Y += sY
        '            d -= sDW
        '        End If
        '    Loop

        'Else
        '    sDW = sHeight + sHeight
        '    sDH = sWidth + sWidth
        '    Do
        '        If sStep = StepWidth Then
        '            Call oPoints.Add(P1)
        '        Else
        '            sStep += StepWidth
        '        End If
        '        If modNumbers.MathRound(P1.Y, 3) = modNumbers.MathRound(P2.Y, 3) Then Exit Do
        '        P1.Y += sY
        '        d += sDH
        '        If d > sHeight Then
        '            P1.X += sX
        '            d -= sDW
        '        End If
        '    Loop
        'End If

        'Dim oPoints2 As PointF()
        'ReDim oPoints2(iCount)
        'Call Array.Copy(oPoints, oPoints2, iCount)
        'Return oPoints2
        Return oPoints
    End Function

End Class
