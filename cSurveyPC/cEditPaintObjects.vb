Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace cSurvey
    Public Class cEditPaintObjects
        Inherits Design.cPaintObjects

        Private oSurvey As cSurvey

        Private oBezierControlPointBrush As Brush
        Private oBezierControlPointPen As Pen
        Private oBezierControlLinePen As Pen

        Private oGenericPointBrush As Brush
        Private oGenericPointPen As Pen

        Private oEndPointBrush As Brush
        Private oEndPointPen As Pen

        Private oStartPointBrush As Brush
        Private oStartPointPen As Pen

        Private oRotatorBrush As Brush
        Private oRotatorPen As Pen

        Private oMarkedPointBrush As Brush
        Private oMarkedPointPen As Pen

        Private oLastPointBrush As Brush
        Private oLastPointPen As Pen

        Private oNewPointBrush As Brush
        Private oNewPointPen As Pen

        Private oSpecialPointBrush As Brush
        Private oSpecialPointPen As Pen

        Private oTopLeftCornerBrush As Brush
        Private oTopLeftCornerPen As Pen

        Private oLockedTopLeftCornerBrush As Brush
        Private oLockedTopLeftCornerPen As Pen

        Private oUnmovableTopLeftCornerBrush As Brush
        Private oUnmovableTopLeftCornerPen As Pen

        Private oCenterPointBrush As Brush
        Private oCenterPointPen As Pen

        Private oCenterOfRotationPointBrush As Brush
        Private oCenterOfRotationPointPen As Pen

        Private oOtherPointBrush As Brush
        Private oOtherPointPen As Pen

        Private oSelectedBoundsPen As Pen
        Private oSelectedBoundsExtraBrush As Brush

        Private oSegmentLockedPen As Pen
        Private oSegmentUnlockedPen As Pen

        Private oSelectedSegmentLockedPen As Pen
        Private oSelectedSegmentUnlockedPen As Pen

        Private oRulersUnitPen As Pen
        Private oRulersDecimalPen As Pen
        Private oRulersFontUnitBrush As SolidBrush
        Private oRulersFont As Font
        Private oRulersBackgroundBrush As SolidBrush
        Private oRulersUsedBackgroundBrush As SolidBrush
        Private oRulersCurrentBackgroundBrush As SolidBrush
        Private oRulersCurrentItemBackgroundBrush As SolidBrush

        Private oGridPen As Pen
        Private oDetailedGridPen As Pen
        Private oAxisPen As Pen

        Public Const FilettoPenWidth As Single = 0.001F

        Public Sub New(ByVal Survey As cSurvey)
            Call MyBase.New(Survey)

            oSurvey = Survey

            'le penne degli strumenti di selezione non sono soggette a zoom....
            oGenericPointBrush = Drawing.Brushes.LightGray
            oGenericPointPen = New Pen(Color.Black, FilettoPenWidth)

            oBezierControlPointBrush = Drawing.Brushes.Beige
            oBezierControlPointPen = New Pen(Color.Gray, FilettoPenWidth)
            oBezierControlLinePen = New Pen(Color.Gray, FilettoPenWidth)
            oBezierControlLinePen.DashStyle = DashStyle.Dot

            oEndPointBrush = Drawing.Brushes.Green
            oEndPointPen = New Pen(Color.Black, FilettoPenWidth)

            oStartPointBrush = Drawing.Brushes.Orange
            oStartPointPen = New Pen(Color.Black, FilettoPenWidth)

            oSpecialPointBrush = Drawing.Brushes.Blue
            oSpecialPointPen = New Pen(Color.Black, FilettoPenWidth)

            oNewPointBrush = New SolidBrush(Color.FromArgb(100, Color.DarkSlateBlue))
            oNewPointPen = New Pen(Color.FromArgb(200, Color.DarkSlateBlue), FilettoPenWidth)

            oLastPointBrush = New SolidBrush(Color.FromArgb(100, Color.Orange))
            oLastPointPen = New Pen(Color.FromArgb(200, Color.Orange), FilettoPenWidth)

            oRotatorBrush = Drawing.Brushes.Green
            oRotatorPen = New Pen(Color.Black, FilettoPenWidth)

            oMarkedPointBrush = Drawing.Brushes.Gray
            oMarkedPointPen = New Pen(Color.DimGray, FilettoPenWidth)

            oTopLeftCornerBrush = Drawing.Brushes.Black
            oTopLeftCornerPen = New Pen(Color.Black, FilettoPenWidth)

            oLockedTopLeftCornerBrush = Drawing.Brushes.Orange
            oLockedTopLeftCornerPen = New Pen(Color.Black, FilettoPenWidth)

            oUnmovableTopLeftCornerBrush = Drawing.Brushes.OrangeRed
            oUnmovableTopLeftCornerPen = New Pen(Color.Black, FilettoPenWidth)

            oCenterPointBrush = Drawing.Brushes.Blue
            oCenterPointPen = New Pen(Color.FromArgb(160, Color.Black), FilettoPenWidth)

            oCenterOfRotationPointBrush = Drawing.Brushes.Green
            oCenterOfRotationPointPen = New Pen(Color.Black, FilettoPenWidth)

            oOtherPointBrush = Drawing.Brushes.Gray
            oOtherPointPen = New Pen(Color.Black, FilettoPenWidth)

            oSelectedBoundsPen = New Pen(Color.FromArgb(150, Color.Gray), FilettoPenWidth)
            oSelectedBoundsPen.DashStyle = DashStyle.Dot
            oSelectedBoundsExtraBrush = New SolidBrush(Color.FromArgb(200, Color.Gray))

            oSegmentUnlockedPen = New Pen(Color.FromArgb(40, Color.Blue), FilettoPenWidth)
            oSegmentUnlockedPen.EndCap = LineCap.ArrowAnchor
            oSegmentUnlockedPen.StartCap = LineCap.RoundAnchor

            oSegmentLockedPen = New Pen(Color.FromArgb(40, Color.Orange), FilettoPenWidth)
            oSegmentLockedPen.EndCap = LineCap.ArrowAnchor
            oSegmentLockedPen.StartCap = LineCap.RoundAnchor

            oSelectedSegmentUnlockedPen = New Pen(Color.FromArgb(210, Color.Blue), FilettoPenWidth)
            oSelectedSegmentUnlockedPen.EndCap = LineCap.ArrowAnchor
            oSelectedSegmentUnlockedPen.StartCap = LineCap.RoundAnchor

            oSelectedSegmentLockedPen = New Pen(Color.FromArgb(210, Color.Orange), FilettoPenWidth)
            oSelectedSegmentLockedPen.EndCap = LineCap.ArrowAnchor
            oSelectedSegmentLockedPen.StartCap = LineCap.RoundAnchor

            oRulersUnitPen = New Pen(Drawing.Brushes.Black, FilettoPenWidth)
            oRulersDecimalPen = New Pen(Drawing.Brushes.DimGray, FilettoPenWidth)
            oRulersFontUnitBrush = New SolidBrush(Color.FromArgb(200, Color.Black))
            oRulersFont = New Font("Courier New", 6)
            oRulersBackgroundBrush = New SolidBrush(Color.FromArgb(100, 230, 230, 230))
            oRulersUsedBackgroundBrush = New SolidBrush(Color.FromArgb(100, Color.LightBlue))
            oRulersCurrentBackgroundBrush = New SolidBrush(Color.FromArgb(150, Color.LightBlue))
            oRulersCurrentItemBackgroundBrush = New SolidBrush(Color.FromArgb(150, Color.Red))

            Dim iGridOpacity As Integer = My.Application.Settings.GetSetting("design.metricgrid.opacity", 50)
            oGridPen = New Pen(Color.FromArgb(iGridOpacity, Color.Gray), FilettoPenWidth)
            oDetailedGridPen = New Pen(Color.FromArgb(iGridOpacity * 0.8, Color.Gray), FilettoPenWidth)
            oAxisPen = New Pen(Drawing.Brushes.Gray, FilettoPenWidth)
        End Sub

        Public ReadOnly Property AxisPen As Pen
            Get
                Return oAxisPen
            End Get
        End Property

        Public ReadOnly Property GridPen As Pen
            Get
                Return oGridPen
            End Get
        End Property

        Public ReadOnly Property DetailedGridPen As Pen
            Get
                Return oDetailedGridPen
            End Get
        End Property

        Public ReadOnly Property RulersBackgroundBrush As SolidBrush
            Get
                Return oRulersBackgroundBrush
            End Get
        End Property
        Public ReadOnly Property RulersUsedBackgroundBrush As SolidBrush
            Get
                Return oRulersUsedBackgroundBrush
            End Get
        End Property
        Public ReadOnly Property RulersCurrentBackgroundBrush As SolidBrush
            Get
                Return oRulersCurrentBackgroundBrush
            End Get
        End Property
        Public ReadOnly Property RulersCurrentItemBackgroundBrush As SolidBrush
            Get
                Return oRulersCurrentItemBackgroundBrush
            End Get
        End Property

        Public ReadOnly Property RulersUnitPen As Pen
            Get
                Return oRulersUnitPen
            End Get
        End Property

        Public ReadOnly Property RulersFont As Font
            Get
                Return oRulersFont
            End Get
        End Property

        Public ReadOnly Property RulersDecimalPen As Pen
            Get
                Return oRulersDecimalPen
            End Get
        End Property

        Public ReadOnly Property RulersFontUnitBrush As SolidBrush
            Get
                Return oRulersFontUnitBrush
            End Get
        End Property

        Public ReadOnly Property SelectedSegmentUnlockedPen As Pen
            Get
                Return oSelectedSegmentUnlockedPen
            End Get
        End Property

        Public ReadOnly Property SelectedSegmentLockedPen As Pen
            Get
                Return oSelectedSegmentLockedPen
            End Get
        End Property

        Public ReadOnly Property SegmentUnlockedPen As Pen
            Get
                Return oSegmentUnlockedPen
            End Get
        End Property

        Public ReadOnly Property SegmentLockedPen As Pen
            Get
                Return oSegmentLockedPen
            End Get
        End Property

        Public ReadOnly Property BezierControlPointBrush As Brush
            Get
                Return oBezierControlPointBrush
            End Get
        End Property

        Public ReadOnly Property BezierControlPointPen As Pen
            Get
                Return oBezierControlPointPen
            End Get
        End Property

        Public ReadOnly Property BezierControlLinePen As Pen
            Get
                Return oBezierControlLinePen
            End Get
        End Property

        Public ReadOnly Property GenericPointBrush As Brush
            Get
                Return oGenericPointBrush
            End Get
        End Property

        Public ReadOnly Property GenericPointPen As Pen
            Get
                Return oGenericPointPen
            End Get
        End Property

        Public ReadOnly Property EndPointBrush As Brush
            Get
                Return oEndPointBrush
            End Get
        End Property

        Public ReadOnly Property EndPointPen As Pen
            Get
                Return oEndPointPen
            End Get
        End Property

        Public ReadOnly Property StartPointBrush As Brush
            Get
                Return oStartPointBrush
            End Get
        End Property

        Public ReadOnly Property StartPointPen As Pen
            Get
                Return oStartPointPen
            End Get
        End Property

        Public ReadOnly Property MarkedPointBrush As Brush
            Get
                Return oMarkedPointBrush
            End Get
        End Property

        Public ReadOnly Property MarkedPointPen As Pen
            Get
                Return oMarkedPointPen
            End Get
        End Property

        Public ReadOnly Property RotatorBrush As Brush
            Get
                Return oRotatorBrush
            End Get
        End Property

        Public ReadOnly Property RotatorPen As Pen
            Get
                Return oRotatorPen
            End Get
        End Property

        Public ReadOnly Property NewPointBrush As Brush
            Get
                Return oNewPointBrush
            End Get
        End Property

        Public ReadOnly Property LastPointBrush As Brush
            Get
                Return oLastPointBrush
            End Get
        End Property

        Public ReadOnly Property LastPointPen As Pen
            Get
                Return oLastPointPen
            End Get
        End Property

        Public ReadOnly Property NewPointPen As Pen
            Get
                Return oNewPointPen
            End Get
        End Property

        Public ReadOnly Property SpecialPointBrush As Brush
            Get
                Return oSpecialPointBrush
            End Get
        End Property

        Public ReadOnly Property SpecialPointPen As Pen
            Get
                Return oSpecialPointPen
            End Get
        End Property

        Public ReadOnly Property LockedTopLeftCornerBrush As Brush
            Get
                Return oLockedTopLeftCornerBrush
            End Get
        End Property

        Public ReadOnly Property UnmovableTopLeftCornerBrush As Brush
            Get
                Return oUnmovableTopLeftCornerBrush
            End Get
        End Property

        Public ReadOnly Property LockedTopLeftCornerpen As Pen
            Get
                Return oLockedTopLeftCornerPen
            End Get
        End Property

        Public ReadOnly Property TopLeftCornerBrush As Brush
            Get
                Return oTopLeftCornerBrush
            End Get
        End Property

        Public ReadOnly Property TopLeftCornerpen As Pen
            Get
                Return oTopLeftCornerPen
            End Get
        End Property

        Public ReadOnly Property CenterOfRotationPointBrush As Brush
            Get
                Return oCenterOfRotationPointBrush
            End Get
        End Property

        Public ReadOnly Property CenterOfRotationPointPen As Pen
            Get
                Return oCenterOfRotationPointPen
            End Get
        End Property

        Public ReadOnly Property CenterPointBrush As Brush
            Get
                Return oCenterPointBrush
            End Get
        End Property

        Public ReadOnly Property CenterPointPen As Pen
            Get
                Return oCenterPointPen
            End Get
        End Property

        Public ReadOnly Property OtherPointBrush As Brush
            Get
                Return oOtherPointBrush
            End Get
        End Property

        Public ReadOnly Property OtherPointPen As Pen
            Get
                Return oOtherPointPen
            End Get
        End Property

        Public ReadOnly Property SelectedBoundsPen As Pen
            Get
                Return oSelectedBoundsPen
            End Get
        End Property

        Public ReadOnly Property SelectedBoundsExtraBrush As SolidBrush
            Get
                Return oSelectedBoundsExtraBrush
            End Get
        End Property
    End Class
End Namespace
