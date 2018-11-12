Imports System.Drawing.Drawing2D

Namespace cSurvey.Design
    Public Class cSequence
        Implements IEnumerable

        Private oPoints As List(Of cPoint)

        Public Function IndexOf(ByVal Point As cPoint) As Integer
            Return oPoints.IndexOf(Point)
        End Function

        Friend Sub AppendRange(ByVal Points As List(Of cPoint))
            Call oPoints.AddRange(Points)
        End Sub

        Friend Sub Append(ByVal Point As cPoint)
            Call oPoints.Add(Point)
        End Sub

        Friend Sub Clear()
            Call oPoints.Clear()
        End Sub

        Public Function GetNearestPoint(PaintPoint As PointF) As cPoint
            Return oPoints.OrderBy(Function(oPoint) modPaint.DistancePointToPoint(oPoint.Point, PaintPoint)).FirstOrDefault()
        End Function

        Private Class cPathPoint
            Public PaintPoint As PointF
            Public Point As cPoint
            Public RelativePoint As cPoint
            Public Distance As Single
            Public IsInDistanceRange As Boolean
        End Class

        Private Function pGetNearestPaintPoint(PathPoints As List(Of PointF), Point As PointF) As Integer
            Dim dDistance As Single
            Dim iIndex As Integer = -1
            Dim iCurrentIndex As Integer = 0
            Dim iCurrentDistance As Single = Single.MaxValue
            For Each oPathPoint As PointF In PathPoints
                dDistance = modPaint.DistancePointToPoint(opathpoint, Point)
                If dDistance < iCurrentDistance Then
                    iCurrentDistance = dDistance
                    iIndex = iCurrentIndex
                End If
                iCurrentIndex += 1
            Next
            Return iIndex
        End Function

        Public Function GetNearestPaintPoint(PaintPoint As PointF, DefaultLineType As Items.cIItemLine.LineTypeEnum, Closed As Boolean, MaxDistance As Single, ByRef ResultPoint As cPoint, ByRef RelativePoint As cPoint) As Boolean
            Try
                Using oPath As GraphicsPath = New GraphicsPath
                    If modPaint.SequenceToPath(Me, GetLineType(DefaultLineType), oPath) Then
                        If oPath.PointCount = 0 Then
                            Return False
                        Else
                            Call oPath.Flatten(Nothing, 0.01)
                            Dim oPathPoints As List(Of PointF) = New List(Of PointF)(oPath.PathPoints)
                            Dim oSourcePointIndexes As Dictionary(Of Integer, cPoint) = New Dictionary(Of Integer, cPoint)
                            For Each oPoint As cPoint In oPoints
                                Dim iIndex As Integer = pGetNearestPaintPoint(oPathPoints, oPoint.Point)
                                Call oSourcePointIndexes.Add(iIndex, oPoint)
                            Next
                            Dim iPathPointIndex As Integer = 0
                            Dim oPointToCompare As PointF
                            Dim dMinDistance As Single = Single.MaxValue
                            Dim oResult As cPathPoint
                            Dim oNewPoint As cPoint
                            Dim oRelativePoint As cPoint
                            For Each oPathPoint As PointF In oPathPoints
                                If oSourcePointIndexes.ContainsKey(iPathPointIndex) Then
                                    oNewPoint = oSourcePointIndexes(iPathPointIndex)
                                    oRelativePoint = oNewPoint
                                    oPointToCompare = oNewPoint.Point
                                Else
                                    oNewPoint = New cPoint(oPoints.First.Survey, oPathPoint)
                                    oPointToCompare = oPathPoint
                                End If
                                Dim dDistance As Single = modPaint.DistancePointToPoint(PaintPoint, oPointToCompare)
                                If dDistance < dMinDistance AndAlso dDistance < MaxDistance Then
                                    dMinDistance = dDistance

                                    oResult = New cPathPoint()
                                    oResult.Distance = dDistance
                                    oResult.PaintPoint = oPointToCompare
                                    oResult.Point = oNewPoint
                                    oResult.RelativePoint = oRelativePoint
                                End If
                                iPathPointIndex += 1
                            Next

                            If IsNothing(oResult) Then
                                Return False
                            Else
                                ResultPoint = oResult.Point
                                RelativePoint = oResult.RelativePoint
                                Return True
                            End If
                        End If
                    Else
                        Return False
                    End If
                End Using
            Catch ex As Exception
            End Try
        End Function

        Public Function ToLine() As cSequence
            Dim oItem As cItem = oPoints.First.Item
            Dim iLineType As Items.cIItemLine.LineTypeEnum = DirectCast(oItem, Items.cIItemLine).LineType
            Dim iIndex As Integer = oItem.Points.IndexOf(oPoints.First)
            Dim oNewSequence As cSequence = modPaint.ToStraightLine(oItem.Survey, Me, DirectCast(oItem, Items.cIItemLine).LineType)
            If oNewSequence Is Nothing Then
                Return Nothing
            Else
                Call oItem.Points.BeginUpdate()
                If oNewSequence.First.LineType = iLineType Then oNewSequence.First.LineType = Items.cIItemLine.LineTypeEnum.Undefined
                Call oItem.Points.InsertRange(iIndex, oNewSequence)
                Call oItem.Points.DeleteSequence(Me)
                Call oItem.Points.EndUpdate()
                Return oNewSequence
            End If
        End Function

        Public Function ToSpline() As cSequence
            Dim oItem As cItem = oPoints.First.Item
            Dim iLineType As Items.cIItemLine.LineTypeEnum = DirectCast(oItem, Items.cIItemLine).LineType
            Dim iIndex As Integer = oItem.Points.IndexOf(oPoints.First)
            Dim oNewSequence As cSequence = modPaint.ToSpline(oItem.Survey, Me, DirectCast(oItem, Items.cIItemLine).LineType)
            If oNewSequence Is Nothing Then
                Return Nothing
            Else
                Call oItem.Points.BeginUpdate()
                If oNewSequence.First.LineType = iLineType Then oNewSequence.First.LineType = Items.cIItemLine.LineTypeEnum.Undefined
                Call oItem.Points.InsertRange(iIndex, oNewSequence)
                Call oItem.Points.DeleteSequence(Me)
                Call oItem.Points.EndUpdate()
                Return oNewSequence
            End If
        End Function

        Public Function ToBezier() As cSequence
            Dim oItem As cItem = oPoints.First.Item
            Dim iLineType As Items.cIItemLine.LineTypeEnum = DirectCast(oItem, Items.cIItemLine).LineType
            Dim iIndex As Integer = oItem.Points.IndexOf(oPoints.First)
            Dim oNewSequence As cSequence = modPaint.ToBezier(oItem.Survey, Me, DirectCast(oItem, Items.cIItemLine).LineType)
            If oNewSequence Is Nothing Then
                Return Nothing
            Else
                Call oItem.Points.BeginUpdate()
                If oNewSequence.First.LineType = iLineType Then oNewSequence.First.LineType = Items.cIItemLine.LineTypeEnum.Undefined
                Call oItem.Points.InsertRange(iIndex, oNewSequence)
                Call oItem.Points.DeleteSequence(Me)
                Call oItem.Points.EndUpdate()
                Return oNewSequence
            End If
        End Function

        Friend Function GetPoints() As PointF()
            Dim oPaintPoints(oPoints.Count - 1) As PointF
            For i = 0 To oPoints.Count - 1
                oPaintPoints(i) = oPoints(i).Point()
            Next
            Return oPaintPoints
        End Function

        Public Function Contains(ByVal Point As cPoint) As Boolean
            Return oPoints.Contains(Point)
        End Function

        Default Public ReadOnly Property Item(ByVal Index As Integer) As cPoint
            Get
                If Index >= 0 And Index < oPoints.Count Then
                    Return oPoints(Index)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property First() As cPoint
            Get
                Return oPoints.First
            End Get
        End Property

        Public ReadOnly Property Last() As cPoint
            Get
                Return oPoints.Last
            End Get
        End Property

        Public ReadOnly Property Count() As Integer
            Get
                Return oPoints.Count
            End Get
        End Property

        Friend Sub New()
            oPoints = New List(Of cPoint)
        End Sub

        Friend Sub New(ByVal First As cPoint)
            oPoints = New List(Of cPoint)
            Call oPoints.Add(First)
        End Sub

        Friend Function GetPen(ByVal DefaultPen As cPen) As cPen
            Dim oPen As cPen = First.Pen
            If oPen Is Nothing Then
                Return DefaultPen
            Else
                Return oPen
            End If
        End Function

        Friend Function GetLineType(ByVal DefaultLineType As Items.cIItemLine.LineTypeEnum) As Items.cIItemLine.LineTypeEnum
            Dim iFirstLineType As Items.cIItemLine.LineTypeEnum = First.LineType
            If iFirstLineType = Items.cIItemLine.LineTypeEnum.Undefined Then ' Or iFirstLineType <> DefaultLineType Then
                Return DefaultLineType
            Else
                Return iFirstLineType
            End If
        End Function

        Public Sub Reverse()
            Call oPoints.Reverse()
            Dim oLastPoint As cPoint = oPoints.Last
            With oPoints(0)
                .BeginSequence = True
                .Pen = oLastPoint.Pen
                .LineType = oLastPoint.LineType
            End With
            With oLastPoint
                .BeginSequence = False
                .Pen = Nothing
                .LineType = Items.cIItemLine.LineTypeEnum.Undefined
            End With
        End Sub

        Public Function ToArray() As cPoint()
            Return oPoints.ToArray
        End Function

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oPoints.GetEnumerator
        End Function
    End Class
End Namespace