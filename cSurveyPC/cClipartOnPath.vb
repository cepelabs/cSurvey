Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Imports cSurveyPC.cSurvey.Drawings
Imports System.Windows.Media.Animation
Imports OfficeOpenXml.FormulaParsing.Excel.Functions.Math

Class cClipartOnPath
    Public Enum ClipartPositionEnum
        OverPath = 0
        CenterPath = 1
        UnderPath = 2
    End Enum

    Private Const iMaxPointCount As Integer = 20000

    Public Shared Function ClipartOnPath(ByVal Graphics As Graphics, Path As GraphicsPath) As GraphicsPath
        Call Path.Flatten(Nothing, 0.4)


    End Function

    Private Shared Function pIsPathLine(PathData As PathData) As Boolean
        Return Not PathData.Types.Where(Function(oType) oType <> PathPointType.Start AndAlso (oType And PathPointType.PathTypeMask) <> PathPointType.Line).Count > 0
    End Function

    Public Shared Function ClipartOnPath(ByVal Pathdata As PathData, ByVal Clipart As cDrawClipArt, ClipartPosition As ClipartPositionEnum, ByVal ClipartSpacePercentage As Single, ByVal ClipartDistancePercentage As Single, ByVal Color As Color, ByVal FillColor As Color, ByVal Zoom As Single) As GraphicsPath
        Dim sZoom As Single = Zoom / 40.0F
        Dim oTransformedPath As cDrawPaths
        Using oTransformMatrix As Matrix = New Matrix
            Call oTransformMatrix.Scale(sZoom, sZoom)
            oTransformedPath = Clipart.TransformPaths(oTransformMatrix)
        End Using
        Dim sClipartSpacePercentage As Single = ClipartSpacePercentage * 10.0F
        Dim sClipartDistancePercentage As Single = ClipartDistancePercentage / 100.0F

        Dim oPoints As List(Of PointF) = New List(Of PointF)
        Dim oResultPoints As List(Of PointF) = New List(Of PointF)
        If pIsPathLine(Pathdata) Then
            'the path in already a sequence of straight line
            oResultPoints.AddRange(Pathdata.Points)
            'Dim oPoint As PointF = Pathdata.Points(0)
            'For i As Integer = 0 To Pathdata.Points.Length - 2
            '    If Pathdata.Types(i + 1) = PathPointType.Start Or (Pathdata.Types(i) And PathPointType.CloseSubpath) = PathPointType.CloseSubpath Then
            '        Call oResultPoints.AddRange(pGetLinePoints(Pathdata.Points(i), oPoint, 1))
            '        oPoint = Pathdata.Points(i + 1)
            '    Else
            '        Call oResultPoints.AddRange(pGetLinePoints(Pathdata.Points(i), Pathdata.Points(i + 1), 1))
            '    End If
            'Next
            oResultPoints = pCleanPoints(oResultPoints)
            Return pDrawClipartOnLines(oTransformedPath, oResultPoints, ClipartPosition, sClipartSpacePercentage, sClipartDistancePercentage)
        Else
            Using oPath As GraphicsPath = New GraphicsPath(Pathdata.Points, Pathdata.Types)
                If oPath.PointCount > 1 Then
                    oPath.FillMode = FillMode.Winding
                    Call oPath.Flatten(Nothing, 0.04)
                    Dim oPoint As PointF = oPath.PathPoints(0)
                    For i As Integer = 0 To oPath.PathPoints.Length - 2
                        If oPath.PathTypes(i + 1) = PathPointType.Start Or (oPath.PathTypes(i) And PathPointType.CloseSubpath) = PathPointType.CloseSubpath Then
                            Call oResultPoints.AddRange(pGetLinePoints(oPath.PathPoints(i), oPoint, 1))
                            oPoint = oPath.PathPoints(i + 1)
                        Else
                            Call oResultPoints.AddRange(pGetLinePoints(oPath.PathPoints(i), oPath.PathPoints(i + 1), 1))
                        End If
                    Next
                    oResultPoints = pCleanPoints(oResultPoints)
                End If
            End Using
            Return pDrawClipart(oTransformedPath, oResultPoints, ClipartPosition, sClipartSpacePercentage, sClipartDistancePercentage)
        End If
    End Function

    Private Shared Function pCleanPoints(ByVal Points As List(Of PointF)) As List(Of PointF)
        Dim oPointResults As List(Of PointF) = New List(Of PointF)
        Dim oLastPoint As PointF
        Dim i As Integer = 0
        For Each oPoint As PointF In Points
            If i = 0 OrElse oPoint.X <> oLastPoint.X OrElse oPoint.Y <> oLastPoint.Y Then
                Call oPointResults.Add(oPoint)
            End If
            oLastPoint = oPoint
            i += 1
        Next
        Return oPointResults
    End Function

    Private Shared Function pDrawClipartOnLines(TransformedPath As cDrawPaths, ByVal Points As List(Of PointF), ClipartPosition As ClipartPositionEnum, ClipartSpacePercentage As Single, ClipartDistancePercentage As Single) As GraphicsPath
        Dim oPath As GraphicsPath = New GraphicsPath

        Dim sMaxWidthClipart As Single = TransformedPath.GetBounds.Width
        If sMaxWidthClipart < 0.1F Then sMaxWidthClipart = 0.1F '* sZoom '/ 40

        Dim sWidth As Single = sMaxWidthClipart + sMaxWidthClipart * ClipartSpacePercentage / 17800.0F
        If sWidth < 1.0F Then sWidth = 1.0F

        Dim iIndex As Integer = 0
        Dim oLastPoint As PointF
        For Each oPoint As PointF In Points
            If iIndex > 0 Then
                Dim sDistance As Single = modPaint.DistancePointToPoint(oPoint, oLastPoint)
                If sDistance > sWidth Then
                    Dim sStep As Single = 0
                    Do
                        Dim sAngle As Single = pGetAngle(oLastPoint, oPoint)
                        Dim oCenter As PointF = modPaint.PointOnLineByDistance(oLastPoint, oPoint, sStep + sWidth / 2)
                        Call oPath.AddPath(pDrawRotatedClipart(TransformedPath, ClipartPosition, sAngle, oCenter, ClipartDistancePercentage), False)
                        sStep += sWidth
                    Loop While (sStep + sWidth) <= sDistance
                End If
            End If
            oLastPoint = oPoint
            iIndex += 1
        Next

        Return oPath
    End Function

    Private Shared Function pDrawClipart(TransformedPath As cDrawPaths, ByVal Points As List(Of PointF), ClipartPosition As ClipartPositionEnum, ClipartSpacePercentage As Single, ClipartDistancePercentage As Single) As GraphicsPath
        Dim oPath As GraphicsPath = New GraphicsPath
        Dim iPointCount As Integer = Points.Count - 1
        Dim sCount As Single = 1
        Dim oPoint1 As PointF = Points(0)
        Dim oPoint2 As PointF
        Dim oPoint As PointF

        Dim sAngle As Single
        'Dim sLastAngle As Single?

        Dim sMaxWidthClipart As Single = TransformedPath.GetBounds.Width
        If sMaxWidthClipart < 0.1F Then sMaxWidthClipart = 0.1F '* sZoom '/ 40

        Dim sWidth As Single = sMaxWidthClipart + sMaxWidthClipart * ClipartSpacePercentage / 100.0F
        If sWidth < 1.0F Then sWidth = 1.0F

        Do While sCount < iPointCount
            If (sCount + sWidth \ 2) >= 0F AndAlso (sCount + sWidth) < iPointCount Then
                sCount += sWidth
                Dim iCenter As Integer = sCount - sWidth \ 2.0F
                oPoint1 = Points(iCenter - sWidth \ 2.0F)
                oPoint2 = Points(iCenter + sWidth \ 2.0F)
                oPoint = Points(iCenter)

                sAngle = pGetAngle(oPoint1, oPoint2)
                Call oPath.AddPath(pDrawRotatedClipart(TransformedPath, ClipartPosition, sAngle, oPoint, ClipartDistancePercentage), False)
            Else
                sCount += sWidth
            End If
        Loop
        Return oPath
    End Function

    Private Shared Function pGetAngle(ByVal P1 As PointF, ByVal P2 As PointF) As Single
        Dim c As Single = Math.Sqrt((P2.X - P1.X) ^ 2.0F + (P2.Y - P1.Y) ^ 2.0F)
        If c = 0F Then
            Return 0F
        Else
            If P1.X > P2.X Then
                Return Math.Asin((P1.Y - P2.Y) / c) * 180.0F / Math.PI - 180.0F
            Else
                Return Math.Asin((P2.Y - P1.Y) / c) * 180.0F / Math.PI
            End If
        End If
    End Function

    Private Shared Function pDrawRotatedClipart(TransformedPath As cDrawPaths, ClipartPosition As ClipartPositionEnum, ByVal Angle As Single, ByVal Center As PointF, DistancePercentage As Single) As GraphicsPath
        Dim oBasePath As GraphicsPath = New GraphicsPath(Drawing.Drawing2D.FillMode.Winding)
        Dim x As Single = Center.X
        Dim y As Single = Center.Y
        Using oMatrix As Matrix = New Matrix
            Dim sDelta As Single = TransformedPath.GetBounds.Height * DistancePercentage
            Select Case ClipartPosition
                Case ClipartPositionEnum.OverPath
                    Call oMatrix.Translate(x - TransformedPath.GetBounds.Width / 2.0F, y - TransformedPath.GetBounds.Height - sDelta, MatrixOrder.Append)
                Case ClipartPositionEnum.CenterPath
                    Call oMatrix.Translate(x - TransformedPath.GetBounds.Width / 2.0F, y - TransformedPath.GetBounds.Height / 2.0F, MatrixOrder.Append)
                Case ClipartPositionEnum.UnderPath
                    Call oMatrix.Translate(x - TransformedPath.GetBounds.Width / 2.0F, y + sDelta, MatrixOrder.Append)
            End Select
            Call oMatrix.RotateAt(Angle, Center, MatrixOrder.Append)
            For Each oDrawPath As cDrawPath In TransformedPath
                Call oBasePath.AddPath(oDrawPath.Path, False)
            Next
            Call oBasePath.Transform(oMatrix)
        End Using
        Return oBasePath
    End Function

    Private Shared Function pGetLinePoints(ByVal P1 As PointF, ByVal P2 As PointF, ByVal StepWidth As Integer) As List(Of PointF)
        Dim iCount As Integer = 0
        Dim oPoints As List(Of PointF) = New List(Of PointF)
        Dim sX As Single
        Dim sY As Single

        Dim sIncrement As Single = 0.01
        Dim sWidth As Single = P2.X - P1.X
        Dim sHeight As Single = P2.Y - P1.Y

        Dim sDW As Single
        Dim sDH As Single
        Dim iStep As Integer = StepWidth
        Dim d As Single = 0

        If sWidth < 0 Then
            sWidth = -sWidth
            sX = -sIncrement
        Else
            sX = sIncrement
        End If

        If sHeight < 0 Then
            sHeight = -sHeight
            sY = -sIncrement
        Else
            sY = sIncrement
        End If

        If sWidth > sHeight Then
            sDW = sWidth + sWidth
            sDH = sHeight + sHeight

            Do
                If iStep = StepWidth Then
                    Call oPoints.Add(P1)
                Else
                    iStep += StepWidth
                End If
                If modNumbers.MathRound(P1.X, 1) = modNumbers.MathRound(P2.X, 1) Then Exit Do
                P1.X += sX
                d += sDH
                If d > sWidth Then
                    P1.Y += sY
                    d -= sDW
                End If
            Loop

        Else
            sDW = sHeight + sHeight
            sDH = sWidth + sWidth
            Do
                If iStep = StepWidth Then
                    Call oPoints.Add(P1)
                Else
                    iStep += StepWidth
                End If
                If modNumbers.MathRound(P1.Y, 1) = modNumbers.MathRound(P2.Y, 1) Then Exit Do
                P1.Y += sY
                d += sDH
                If d > sHeight Then
                    P1.X += sX
                    d -= sDW
                End If
            Loop
        End If

        'Dim oPoints2 As PointF()
        'ReDim oPoints2(iCount)
        'Call Array.Copy(oPoints, oPoints2, iCount)
        'Return oPoints2
        Return oPoints
    End Function

End Class
