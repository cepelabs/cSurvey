Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Xml

Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Imports cSurveyPC.XSystem.Linq.Dynamic
Imports System.Linq.Expressions

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
            Return (Point <> RightPoint) Or (Point <> LeftPoint)
        End Function

        Public Function HaveValidUD() As Boolean
            Return (Point <> UpPoint) Or (Point <> DownPoint)
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

    Friend Class cTranslatedTrigPoint
        Implements IEnumerable

        Private oColl As List(Of PointF)
        Private sName As String

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public Function Add(ByVal X As Single, ByVal Y As Single) As Boolean
            Return Add(New PointF(X, Y))
        End Function

        Public Function Add(ByVal Point As PointF) As Boolean
            If Not Exist(Point) Then
                Call oColl.Add(Point)
                Return True
            End If
            Return False
        End Function

        Public Function Remove(Point As PointF) As Boolean
            If Exist(Point) Then
                Call oColl.Remove(Point)
            End If
        End Function

        Public Function Exist(ByVal X As Single, ByVal Y As Single) As Boolean
            Return Exist(New PointF(X, Y))
        End Function

        Public Function Exist(ByVal Point As PointF) As Boolean
            For Each oPoint As PointF In oColl
                If oPoint.Equals(Point) Then
                    Return True
                End If
            Next
        End Function

        Default Public ReadOnly Property Item(ByVal index As Integer) As PointF
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
            oColl = New List(Of PointF)
        End Sub
    End Class

    Friend Class cTranslatedTrigPoints
        Implements IEnumerable

        Private oColl As Dictionary(Of String, cTranslatedTrigPoint)

        Public Function Add(ByVal Name As String, ByVal X As Single, ByVal Y As Single)
            Return Add(Name, New PointF(X, Y))
        End Function

        Public Function Add(ByVal Name As String, ByVal Point As PointF)
            Dim oItem As cTranslatedTrigPoint
            If oColl.ContainsKey(Name) Then
                oItem = oColl(Name)
            Else
                oItem = New cTranslatedTrigPoint(Name)
                Call oColl.Add(Name, oItem)
            End If
            Call oItem.Add(Point)
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

        Private oCaches As cDrawCaches

        Private oCompass As cDesignCompass
        Private oInfoBox As cDesignInfoBox
        Private oScale As cDesignScale

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

        Friend MustOverride Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
        'Friend MustOverride Function ToSvg(ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum, Size As SizeF, PageBox As RectangleF, ByVal ViewBox As RectangleF) As XmlDocument
        Friend MustOverride Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, Selection As Helper.Editor.cIEditSelection)

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
            oCaches = New cDrawCaches

            oCompass = New cDesignCompass(oSurvey)
            oInfoBox = New cDesignInfoBox(oSurvey)
            oScale = New cDesignScale(oSurvey)
        End Sub

        Public Overridable Sub Redraw(Optional Options As cOptionsCenterline = Nothing)
            Call oCaches.Invalidate(Options)
        End Sub

        Friend ReadOnly Property Caches As cDrawCaches
            Get
                Return oCaches
            End Get
        End Property

        Friend MustOverride Sub Calculate(ByVal SegmentsColl As List(Of cSegment), Optional ByVal PerformWarping As Boolean = True)
        Friend MustOverride Sub CalculateSplay()
        Friend MustOverride Sub ResetChanges()

        Friend Function GetAllSegments(PaintOptions As cOptionsCenterline) As List(Of cISegment)
            Dim oSegments As List(Of cISegment) = New List(Of cISegment)
            For Each oSegment As cSegment In oSurvey.Segments.GetSurveySegments
                If Not oSegment.IsSelfDefined AndAlso Not oSegment.Splay Then
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
                    If Not oSegment.IsSelfDefined AndAlso Not oSegment.Splay AndAlso ((PaintOptions.IsDesign AndAlso Not oSegment.HiddenInDesign) OrElse ((PaintOptions.IsPreview OrElse PaintOptions.IsViewer) AndAlso Not oSegment.HiddenInPreview)) Then
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
                        If oSegment.IsValid AndAlso Not oSegment.IsSelfDefined AndAlso Not oSegment.Splay AndAlso ((PaintOptions.IsDesign AndAlso Not oSegment.HiddenInDesign) OrElse ((PaintOptions.IsPreview OrElse PaintOptions.IsViewer) AndAlso Not oSegment.HiddenInPreview)) Then
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
                            If oSegment.IsValid AndAlso Not oSegment.IsSelfDefined AndAlso Not oSegment.Splay AndAlso ((PaintOptions.IsDesign AndAlso Not oSegment.HiddenInDesign) OrElse ((PaintOptions.IsPreview OrElse PaintOptions.IsViewer) AndAlso Not oSegment.HiddenInPreview)) Then
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