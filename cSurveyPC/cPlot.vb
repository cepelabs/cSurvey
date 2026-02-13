Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq.Expressions
Imports System.Security
Imports System.Xml
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.XSystem.Linq.Dynamic

Namespace cSurvey.Design
    Friend Class cPointCacheItem
        Public Point As PointD

        Public RightBearing As Decimal
        Public LeftBearing As Decimal

        Public RightPoint As PointD
        Public LeftPoint As PointD

        Public UpPoint As PointD
        Public DownPoint As PointD

        Public Function HaveValidLR() As Boolean
            Return (Point <> RightPoint) OrElse (Point <> LeftPoint)
        End Function

        Public Function HaveValidUD() As Boolean
            Return (Point <> UpPoint) OrElse (Point <> DownPoint)
        End Function

        Friend Sub New()

        End Sub

        Friend Sub New(Point As PointD)
            Me.Point = Point
            Me.LeftPoint = Point
            Me.RightPoint = Point
            Me.UpPoint = Point
            Me.DownPoint = Point
        End Sub
    End Class

    Friend Class cTranslatedTrigPointPoint
        Private oPoint As PointF
        Private sOriginalName As String
        Private sCalculateName As String

        Public ReadOnly Property CalculateName As String
            Get
                Return sCalculateName
            End Get
        End Property

        Public ReadOnly Property OriginalName As String
            Get
                Return sOriginalName
            End Get
        End Property

        Public ReadOnly Property Point As PointF
            Get
                Return oPoint
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return sOriginalName & ": " & MyBase.ToString
        End Function

        Public Sub New(CalculateName As String, OriginalName As String, Point As PointF)
            sCalculateName = CalculateName
            sOriginalName = OriginalName
            oPoint = Point
        End Sub
    End Class

    Friend Class cTranslatedTrigPoint
        Implements IEnumerable

        Private oColl As List(Of cTranslatedTrigPointPoint)
        Private sName As String

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        'Public Function Add(TranslatedTrigPoint As cTranslatedTrigPoint)
        '    For Each oPoint As PointF In TranslatedTrigPoint
        '        Return Add(oPoint)
        '    Next
        '    Return True
        'End Function

        'Public Function Add(ByVal X As Single, ByVal Y As Single) As Boolean
        '    Return Add(New PointF(X, Y))
        'End Function

        Public Function Add(CalculateName As String, OriginalName As String, ByVal Point As PointF) As Boolean
            If Not Exist(CalculateName, Point) Then
                Call oColl.Add(New cTranslatedTrigPointPoint(CalculateName, OriginalName, Point))
                Return True
            End If
            Return False
        End Function

        Public Function Remove(Point As cTranslatedTrigPointPoint) As Boolean
            If Exist(Point) Then
                Call oColl.Remove(Point)
            End If
        End Function

        'Public Function Exist(ByVal X As Single, ByVal Y As Single) As Boolean
        '    Return Exist(New PointF(X, Y))
        'End Function

        Public Function Exist(CalculateName As String, ByVal Point As PointF) As Boolean
            Return oColl.Exists(Function(oItem) oItem.Point.Equals(Point) And oItem.CalculateName = CalculateName)
        End Function

        Public Function Exist(ByVal Point As PointF) As Boolean
            For Each oPoint As PointF In oColl.Select(Function(oItem) oItem.Point)
                If oPoint.Equals(Point) Then
                    Return True
                End If
            Next
        End Function

        Public Function Exist(ByVal Point As cTranslatedTrigPointPoint) As Boolean
            For Each oPoint As PointF In oColl.Select(Function(oItem) oItem.Point)
                If oPoint.Equals(Point.Point) Then
                    Return True
                End If
            Next
        End Function

        Default Public ReadOnly Property Item(ByVal index As Integer) As cTranslatedTrigPointPoint
            Get
                Return oColl(index)
            End Get
        End Property

        Public ReadOnly Property Count As Integer
            Get
                Return oColl.Count
            End Get
        End Property

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oColl.GetEnumerator
        End Function

        Public Overrides Function ToString() As String
            Return String.Join(";", oColl.Select(Function(item) item.ToString))
        End Function

        Friend Sub New(ByVal Name As String)
            sName = Name
            oColl = New List(Of cTranslatedTrigPointPoint)
        End Sub
    End Class

    Friend Class cTranslatedTrigPoints
        Implements IEnumerable

        Private oColl As Dictionary(Of String, cTranslatedTrigPoint)

        Public Function Add(ByVal Name As String, CalculateName As String, OriginalName As String, ByVal X As Single, ByVal Y As Single)
            Return Add(Name, CalculateName, OriginalName, New PointF(X, Y))
        End Function

        'Public Function AddRange(Names As IEnumerable(Of String), Point As PointF) As List(Of cTranslatedTrigPoint)
        '    Dim oResults As List(Of cTranslatedTrigPoint) = New List(Of cTranslatedTrigPoint)
        '    For Each sName As String In Names
        '        oResults.Add(Add(sName, OriginalName, Point))
        '    Next
        '    Return oResults
        'End Function

        Public Function Add(ByVal Name As String, CalculateName As String, OriginalName As String, ByVal Point As PointF)
            Dim oItem As cTranslatedTrigPoint
            If oColl.ContainsKey(Name) Then
                oItem = oColl(Name)
            Else
                oItem = New cTranslatedTrigPoint(Name)
                Call oColl.Add(Name, oItem)
            End If
            Call oItem.Add(CalculateName, OriginalName, Point)
            Return oItem
        End Function

        Default Public ReadOnly Property Item(ByVal Name As String) As cTranslatedTrigPoint
            Get
                Return oColl(Name)
            End Get
        End Property

        Public ReadOnly Property Count As Integer
            Get
                Return oColl.Count
            End Get
        End Property

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oColl.Values.GetEnumerator
        End Function

        Friend Sub New()
            oColl = New Dictionary(Of String, cTranslatedTrigPoint)
        End Sub

        Public Sub Remove(ByVal Name As String)
            Call oColl.Remove(Name)
        End Sub

        Public Sub Clear()
            Call oColl.Clear()
        End Sub

        Public Function Contains(Name As String) As Boolean
            Return oColl.ContainsKey(Name)
        End Function

        Public Function Contains(Item As cTranslatedTrigPoint) As Boolean
            Return oColl.ContainsValue(Item)
        End Function
    End Class

    Public MustInherit Class cPlot
        Private oSurvey As cSurvey

        'Private oCaches As cDrawCaches

        Private oCompass As cDesignCompass
        Private oInfoBox As cDesignInfoBox
        Private oScale As cDesignScale

        Public ReadOnly Property Survey() As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public Class cPlotHitTestResult
            Private oSegment As cSegment
            Private oTrigPoint As cTrigPoint

            Public ReadOnly Property Segment As cSegment
                Get
                    Return oSegment
                End Get
            End Property

            Public ReadOnly Property TrigPoint As cTrigPoint
                Get
                    Return oTrigPoint
                End Get
            End Property

            Friend Sub New(ByVal Segment As cSegment, ByVal TrigPoint As cTrigPoint)
                oSegment = Segment
                oTrigPoint = TrigPoint
            End Sub
        End Class

        Friend MustOverride Function ToSvgItem(ByVal SVG As cSVGWriter, ByVal PaintOptions As cOptionsCenterline) As XmlElement
        Friend MustOverride Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, Selection As Helper.Editor.cIEditSelection)

        Friend Overridable Sub Render(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, Selection As Helper.Editor.cIEditDesignSelection)
            oTranslationDrawnH = New Dictionary(Of Single, List(Of Tuple(Of Single, Single)))
            oTranslationDrawnV = New Dictionary(Of Single, List(Of Tuple(Of Single, Single)))
        End Sub

        Friend ReadOnly Property Compass As cDesignCompass
            Get
                Return oCompass
            End Get
        End Property

        Friend ReadOnly Property InfoBox As cDesignInfoBox
            Get
                Return oInfoBox
            End Get
        End Property

        Friend ReadOnly Property Scale As cDesignScale
            Get
                Return oScale
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            'oCaches = New cDrawCaches

            oCompass = New cDesignCompass(oSurvey)
            oInfoBox = New cDesignInfoBox(oSurvey)
            oScale = New cDesignScale(oSurvey)
        End Sub

        Public MustOverride Sub Redraw(Segment As cSegment)
        Public MustOverride Sub Redraw(Trigpoint As cTrigPoint)
        Public MustOverride Sub Redraw(Optional Options As cOptionsCenterline = Nothing)

        ''' <summary>
        ''' Set the tollerance for translation lines optimization
        ''' </summary>
        Public Const EPS As Single = 0.0001F

        Private oTranslationDrawnH As Dictionary(Of Single, List(Of Tuple(Of Single, Single)))
        Private oTranslationDrawnV As Dictionary(Of Single, List(Of Tuple(Of Single, Single)))

        Private Function N(v As Single) As Single
            Return v 'CSng(Math.Round(v / EPS) * EPS)
        End Function

        Private Sub Swap(ByRef a As Single, ByRef b As Single)
            Dim t = a : a = b : b = t
        End Sub

        Private Function pTranslationsSubtractInterval(startV As Single, endV As Single, covered As List(Of Tuple(Of Single, Single))) As List(Of Tuple(Of Single, Single))
            Dim oResult As New List(Of Tuple(Of Single, Single)) From {Tuple.Create(startV, endV)}

            For Each c In covered
                Dim oNewResult As New List(Of Tuple(Of Single, Single))

                For Each r In oResult
                    Dim a1 = r.Item1, a2 = r.Item2
                    Dim b1 = c.Item1, b2 = c.Item2

                    If a2 <= b1 + EPS OrElse a1 >= b2 - EPS Then
                        oNewResult.Add(r)
                    Else
                        If a1 < b1 - EPS Then oNewResult.Add(Tuple.Create(a1, b1))
                        If a2 > b2 + EPS Then oNewResult.Add(Tuple.Create(b2, a2))
                    End If
                Next

                oResult = oNewResult
                If oResult.Count = 0 Then Exit For
            Next

            Return oResult
        End Function

        Private Sub pTranslationsMergeIntervals(ByRef intervals As List(Of Tuple(Of Single, Single)))
            If intervals.Count < 2 Then Exit Sub

            intervals.Sort(Function(a, b) a.Item1.CompareTo(b.Item1))

            Dim oMerged As New List(Of Tuple(Of Single, Single))
            Dim cur = intervals(0)

            For i = 1 To intervals.Count - 1
                Dim nxt = intervals(i)
                If nxt.Item1 <= cur.Item2 + EPS Then
                    cur = Tuple.Create(cur.Item1, Math.Max(cur.Item2, nxt.Item2))
                Else
                    oMerged.Add(cur)
                    cur = nxt
                End If
            Next

            oMerged.Add(cur)
            intervals = oMerged
        End Sub

        Private Sub pTranslationsDrawHorizontal(y As Single, x1 As Single, x2 As Single, CacheItem As cDrawCacheItem, Pen As Pen)
            y = N(y) : x1 = N(x1) : x2 = N(x2)
            If x1 > x2 Then Swap(x1, x2)

            If Not oTranslationDrawnH.ContainsKey(y) Then
                oTranslationDrawnH(y) = New List(Of Tuple(Of Single, Single))
            End If

            Dim oMissing = pTranslationsSubtractInterval(x1, x2, oTranslationDrawnH(y))
            If oMissing.Count = 0 Then Exit Sub

            CacheItem.SetPen(Pen)
            For Each m In oMissing
                CacheItem.AddLine(New PointF(m.Item1, y), New PointF(m.Item2, y))
                oTranslationDrawnH(y).Add(m)
            Next

            pTranslationsMergeIntervals(oTranslationDrawnH(y))
        End Sub

        Private Sub pTranslationsDrawVertical(x As Single, y1 As Single, y2 As Single, CacheItem As cDrawCacheItem, Pen As Pen)
            x = N(x) : y1 = N(y1) : y2 = N(y2)
            If y1 > y2 Then Swap(y1, y2)

            If Not oTranslationDrawnV.ContainsKey(x) Then
                oTranslationDrawnV(x) = New List(Of Tuple(Of Single, Single))
            End If

            Dim oMissing = pTranslationsSubtractInterval(y1, y2, oTranslationDrawnV(x))
            If oMissing.Count = 0 Then Exit Sub

            CacheItem.SetPen(Pen)
            For Each m In oMissing
                CacheItem.AddLine(New PointF(x, m.Item1), New PointF(x, m.Item2))
                oTranslationDrawnV(x).Add(m)
            Next

            pTranslationsMergeIntervals(oTranslationDrawnV(x))
        End Sub

        Friend Sub RenderTrigpointTranslations(PaintOptions As cOptionsCenterline, DrawingObject As cOptionsDrawingObjects, TrigpointCache As cDrawCache, ByRef TranslationTrigPoint As cTranslatedTrigPoint)
            'Dim oMainTrigpoint As cTrigPoint = oSurvey.TrigPoints(TranslationTrigPoint.Name)
            Dim oMainTrigpoint As cTrigPoint = oSurvey.TrigPoints(TranslationTrigPoint.Name)
            For Each oTranslatedTrigpoint As cTranslatedTrigPointPoint In TranslationTrigPoint
                Dim oTrigpoint As cTrigPoint = oSurvey.TrigPoints(oTranslatedTrigpoint.OriginalName)
                If oTrigpoint.MainEquate Then
                    oMainTrigpoint = oTrigpoint
                End If
            Next

            If (Not PaintOptions.IsDesign AndAlso PaintOptions.DrawTranslation AndAlso PaintOptions.TranslationsOptions.DrawTranslationsLine AndAlso TranslationTrigPoint.Count > 1 AndAlso oMainTrigpoint.DrawTranslationsLine) OrElse (PaintOptions.IsDesign AndAlso oMainTrigpoint.DrawTranslationsLine) Then
                Dim sTTH As Single = PaintOptions.TranslationsOptions.TranslationsThreshold
                Dim oFromPoint As PointF = TranslationTrigPoint(0).Point
                Dim i As Integer = 1

                Do While i < TranslationTrigPoint.Count
                    Dim oToTranslationTrigpointPoint As cTranslatedTrigPointPoint = TranslationTrigPoint(i)
                    Dim oToPoint As PointF = oToTranslationTrigpointPoint.Point
                    If (sTTH = 0 OrElse modPaint.DistancePointToPoint(oToPoint, oFromPoint) > sTTH) Then
                        Dim oCacheItem = TrigpointCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                        If (oToPoint.X <> oFromPoint.X) AndAlso (oToPoint.Y <> oFromPoint.Y) Then
                            Dim oMidPoint As New PointF(oFromPoint.X, oToPoint.Y)
                            pTranslationsDrawVertical(oFromPoint.X, oFromPoint.Y, oMidPoint.Y, oCacheItem, DrawingObject.TranslationPen)
                            pTranslationsDrawHorizontal(oMidPoint.Y, oMidPoint.X, oToPoint.X, oCacheItem, DrawingObject.TranslationPen)
                        Else
                            If oFromPoint.X = oToPoint.X Then
                                pTranslationsDrawVertical(oFromPoint.X, oFromPoint.Y, oToPoint.Y, oCacheItem, DrawingObject.TranslationPen)
                            ElseIf oFromPoint.Y = oToPoint.Y Then
                                pTranslationsDrawHorizontal(oFromPoint.Y, oFromPoint.X, oToPoint.X, oCacheItem, DrawingObject.TranslationPen)
                            End If
                        End If
                        i += 1
                    Else
                        TranslationTrigPoint.Remove(oToTranslationTrigpointPoint)
                    End If
                Loop
            End If
        End Sub

        'Friend Sub RenderTrigpointTranslations(PaintOptions As cOptionsCenterline, DrawingObject As cOptionsDrawingObjects, TrigpointCache As cDrawCache, ByRef TranslationTrigPoint As cTranslatedTrigPoint)
        '    Dim oMainTrigpoint As cTrigPoint = oSurvey.TrigPoints(TranslationTrigPoint.Name)
        '    'For Each oTranslatedTrigpoint As cTranslatedTrigPointPoint In TranslationTrigPoint
        '    '    Dim oTrigpoint As cTrigPoint = oSurvey.TrigPoints(oTranslatedTrigpoint.OriginalName)
        '    '    If oTrigpoint.MasterInEquate Then
        '    '        oMainTrigpoint = oTrigpoint
        '    '    End If
        '    'Next

        '    If (Not PaintOptions.IsDesign AndAlso PaintOptions.DrawTranslation AndAlso PaintOptions.TranslationsOptions.DrawTranslationsLine AndAlso TranslationTrigPoint.Count > 1 AndAlso oMainTrigpoint.DrawTranslationsLine) OrElse (PaintOptions.IsDesign AndAlso oMainTrigpoint.DrawTranslationsLine) Then
        '        Dim sTTH As Single = PaintOptions.TranslationsOptions.TranslationsThreshold
        '        Dim oFromPoint As PointF = TranslationTrigPoint(0).Point
        '        Dim i As Integer = 1
        '        Do While i < TranslationTrigPoint.Count
        '            Dim oCacheItem = TrigpointCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
        '            Dim oToTranslationTrigpointPoint As cTranslatedTrigPointPoint = TranslationTrigPoint(i)
        '            Dim oToPoint As PointF = oToTranslationTrigpointPoint.Point
        '            If (sTTH = 0 OrElse modPaint.DistancePointToPoint(oToPoint, oFromPoint) > sTTH) Then
        '                If (oToPoint.X <> oFromPoint.X) AndAlso (oToPoint.Y <> oFromPoint.Y) Then
        '                    Dim oMidPoint As PointF = New PointF(oFromPoint.X, oToPoint.Y)
        '                    Call oCacheItem.SetPen(DrawingObject.TranslationPen)
        '                    Call oCacheItem.AddLine(oFromPoint, oMidPoint)
        '                    Call oCacheItem.AddLine(oMidPoint, oToPoint)
        '                Else
        '                    Call oCacheItem.SetPen(DrawingObject.TranslationPen)
        '                    Call oCacheItem.AddLine(oFromPoint, oToPoint)
        '                End If
        '                i += 1
        '            Else
        '                Call TranslationTrigPoint.Remove(oToTranslationTrigpointPoint)
        '            End If
        '        Loop
        '    End If
        'End Sub


        Friend MustOverride Sub Calculate(ByVal SegmentsColl As List(Of cSegment), Optional ByVal PerformWarping As Boolean = True)
        Friend MustOverride Sub CalculateSplay()
        Friend MustOverride Sub ResetChanges()

        Friend Function GetAllSegments(PaintOptions As cOptionsCenterline) As List(Of cISegment)
            Dim oSegments As List(Of cISegment) = New List(Of cISegment)
            For Each oSegment As cSegment In oSurvey.Segments.GetSurveySegments
                If Not oSegment.IsSelfDefined AndAlso Not oSegment.IsEquate AndAlso Not oSegment.Splay Then
                    Dim bVisible As Boolean = True
                    If oSegment.Surface Then
                        bVisible = (PaintOptions.DrawSegmentsOptions And cOptionsCenterline.DrawSegmentsOptionsEnum.Surface) = cOptionsCenterline.DrawSegmentsOptionsEnum.Surface
                    End If
                    If oSegment.Duplicate Then
                        bVisible = (PaintOptions.DrawSegmentsOptions And cOptionsCenterline.DrawSegmentsOptionsEnum.Duplicate) = cOptionsCenterline.DrawSegmentsOptionsEnum.Duplicate
                    End If
                    If bVisible Then
                        Call oSegments.Add(oSegment)
                    End If
                End If
            Next
            Return oSegments
        End Function

        Friend Function GetAllVisibleSegments(PaintOptions As cOptionsCenterline) As List(Of cISegment)
            Dim oVisibleSegments As List(Of cISegment) = New List(Of cISegment)
            Dim oSegments As cISegmentCollection = oSurvey.Segments.GetSurveySegments
            Dim sCurrentProfile As String = PaintOptions.CurrentCaveVisibilityProfile
            If sCurrentProfile = "" Then
                For Each oSegment As cSegment In oSegments
                    If Not oSegment.IsSelfDefined AndAlso Not oSegment.IsEquate AndAlso Not oSegment.Splay AndAlso ((PaintOptions.IsDesign AndAlso Not oSegment.HiddenInDesign) OrElse ((PaintOptions.IsPreview OrElse PaintOptions.IsViewer) AndAlso Not oSegment.HiddenInPreview)) Then
                        Dim bVisible As Boolean = True
                        If oSegment.Surface Then
                            bVisible = (PaintOptions.DrawSegmentsOptions And cOptionsCenterline.DrawSegmentsOptionsEnum.Surface) = cOptionsCenterline.DrawSegmentsOptionsEnum.Surface
                        End If
                        If oSegment.Duplicate Then
                            bVisible = (PaintOptions.DrawSegmentsOptions And cOptionsCenterline.DrawSegmentsOptionsEnum.Duplicate) = cOptionsCenterline.DrawSegmentsOptionsEnum.Duplicate
                        End If
                        If bVisible Then
                            Call oVisibleSegments.Add(oSegment)
                        End If
                    End If
                Next
            Else
                Dim sSegmentsQuery As String = oSurvey.Properties.CaveVisibilityProfiles.GetSegmentsQuery(sCurrentProfile)
                If sSegmentsQuery = "" Then
                    For Each oSegment As cSegment In oSegments
                        If oSegment.IsValid AndAlso Not oSegment.IsSelfDefined AndAlso Not oSegment.IsEquate AndAlso Not oSegment.Splay AndAlso ((PaintOptions.IsDesign AndAlso Not oSegment.HiddenInDesign) OrElse ((PaintOptions.IsPreview OrElse PaintOptions.IsViewer) AndAlso Not oSegment.HiddenInPreview)) Then
                            Dim bVisible As Boolean = True
                            If oSegment.Surface Then
                                bVisible = (PaintOptions.DrawSegmentsOptions And cOptionsCenterline.DrawSegmentsOptionsEnum.Surface) = cOptionsCenterline.DrawSegmentsOptionsEnum.Surface
                            End If
                            If oSegment.Duplicate Then
                                bVisible = (PaintOptions.DrawSegmentsOptions And cOptionsCenterline.DrawSegmentsOptionsEnum.Duplicate) = cOptionsCenterline.DrawSegmentsOptionsEnum.Duplicate
                            End If
                            If bVisible Then
                                If oSurvey.Properties.CaveVisibilityProfiles.GetVisible(sCurrentProfile, oSegment.Cave, oSegment.Branch) Then
                                    Call oVisibleSegments.Add(oSegment)
                                End If
                            End If
                        End If
                    Next
                Else
                    Try
                        Dim oQuerySegments = From oSegment As cSegment In oSegments.ToArray.AsQueryable.Where(sSegmentsQuery) Select oSegment
                        For Each oSegment As cSegment In oQuerySegments
                            If oSegment.IsValid AndAlso Not oSegment.IsEquate AndAlso Not oSegment.IsSelfDefined AndAlso Not oSegment.Splay AndAlso ((PaintOptions.IsDesign AndAlso Not oSegment.HiddenInDesign) OrElse ((PaintOptions.IsPreview OrElse PaintOptions.IsViewer) AndAlso Not oSegment.HiddenInPreview)) Then
                                Dim bVisible As Boolean = True
                                If oSegment.Surface Then
                                    bVisible = (PaintOptions.DrawSegmentsOptions And cOptionsCenterline.DrawSegmentsOptionsEnum.Surface) = cOptionsCenterline.DrawSegmentsOptionsEnum.Surface
                                End If
                                If oSegment.Duplicate Then
                                    bVisible = (PaintOptions.DrawSegmentsOptions And cOptionsCenterline.DrawSegmentsOptionsEnum.Duplicate) = cOptionsCenterline.DrawSegmentsOptionsEnum.Duplicate
                                End If
                                If bVisible Then
                                    If oSurvey.Properties.CaveVisibilityProfiles.GetVisible(sCurrentProfile, oSegment.Cave, oSegment.Branch) Then
                                        Call oVisibleSegments.Add(oSegment)
                                    End If
                                End If
                            End If
                        Next
                    Catch ex As Exception
                        Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Error, ex.Message)
                    End Try
                End If
            End If
            Return oVisibleSegments
        End Function

        Public MustOverride Function HitTest(ByVal PaintOptions As cOptionsCenterline, ByVal CurrentCave As String, ByVal CurrentBranch As String, ByVal Point As PointF, Optional Wide As Decimal = Decimal.MaxValue) As cPlotHitTestResult

        Public Overridable Function HitTest(ByVal PaintOptions As cOptionsCenterline, ByVal CurrentCave As String, ByVal CurrentBranch As String, ByVal X As Single, ByVal Y As Single, Optional Wide As Decimal = Decimal.MaxValue) As cPlotHitTestResult
            Return HitTest(PaintOptions, CurrentCave, CurrentBranch, New PointF(X, Y), Wide)
        End Function

        Public MustOverride Function GetBounds(PaintOptions As cOptionsCenterline) As RectangleF
        Public MustOverride Function GetVisibleBounds(PaintOptions As cOptionsCenterline) As RectangleF
        Public MustOverride Function GetCaveBounds(PaintOptions As cOptionsCenterline, ByVal Cave As String, Branch As String) As RectangleF
        Public MustOverride Function GetVisibleCaveBounds(PaintOptions As cOptionsCenterline, ByVal Cave As String, Branch As String) As RectangleF

    End Class

    Public Class cValue(Of T)
        Private oValue As T

        Public Property Value As T
            Get
                Return oValue
            End Get
            Set(value As T)
                oValue = value
            End Set
        End Property

        Public Sub New(Value As T)
            oValue = Value
        End Sub
    End Class
End Namespace