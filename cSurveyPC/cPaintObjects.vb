Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace cSurvey.Design
    Public Class cPaintObjects
        Private oSurvey As cSurvey

        Private oGenericFonts As cItemFonts
        Private oFonts As cItemFonts

        'Private oPens As cPens
        'Private oGenericPens As cPens

        Private oBrushes As cBrushes
        'Private oGenericBrushes As cBrushes

        Private oNearProfileBorderPen As Pen
        Private oFarProfileBorderPen As Pen
        Private oMarkerProfileBorderPen As Pen
        Private oProfileCrossPen As Pen

        Private oPrintOrExportBounds As Pen
        Private oPrintOrExportMarginsBounds As Pen

        Public Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey

            oGenericFonts = New cItemFonts(oSurvey)
            oFonts = New cItemFonts(oSurvey)

            'oPens = New cPens(oSurvey)
            'oGenericPens = New cPens(oSurvey)

            oBrushes = New cBrushes(oSurvey)
            'oGenericBrushes = New cBrushes(oSurvey)

            oMarkerProfileBorderPen = New Pen(Color.FromArgb(230, Color.IndianRed), cEditPaintObjects.FilettoPenWidth)
            oMarkerProfileBorderPen.DashStyle = DashStyle.Dot

            oNearProfileBorderPen = New Pen(Color.FromArgb(230, Color.Gray), cEditPaintObjects.FilettoPenWidth)
            oNearProfileBorderPen.DashStyle = DashStyle.Dot

            oFarProfileBorderPen = New Pen(Color.FromArgb(230, Color.DimGray), cEditPaintObjects.FilettoPenWidth)
            oFarProfileBorderPen.DashStyle = DashStyle.Dot

            oProfileCrossPen = New Pen(Color.Black, cEditPaintObjects.FilettoPenWidth)

            oPrintOrExportBounds = New Pen(Color.DarkRed, cEditPaintObjects.FilettoPenWidth)
            oPrintOrExportBounds.DashStyle = DashStyle.Dot
            oPrintOrExportMarginsBounds = New Pen(Color.IndianRed, cEditPaintObjects.FilettoPenWidth)
            oPrintOrExportMarginsBounds.DashStyle = DashStyle.Dot
        End Sub

        Public ReadOnly Property PrintOrExportMarginsBounds As Pen
            Get
                Return oPrintOrExportMarginsBounds
            End Get
        End Property

        Public ReadOnly Property PrintOrExportBounds As Pen
            Get
                Return oPrintOrExportBounds
            End Get
        End Property

        Public ReadOnly Property MarkerProfileBorderPen As Pen
            Get
                Return oMarkerProfileBorderPen
            End Get
        End Property

        Public ReadOnly Property NearProfileBorderPen As Pen
            Get
                Return oNearProfileBorderPen
            End Get
        End Property

        Public ReadOnly Property FarProfileBorderPen As Pen
            Get
                Return oFarProfileBorderPen
            End Get
        End Property

        Public ReadOnly Property ProfileCrossPen As Pen
            Get
                Return oProfileCrossPen
            End Get
        End Property

        'Public ReadOnly Property GenericBrushes As cBrushes
        '    Get
        '        Return oGenericBrushes
        '    End Get
        'End Property

        Public ReadOnly Property Brushes As cBrushes
            Get
                Return oBrushes
            End Get
        End Property

        'Public ReadOnly Property GenericPens As cPens
        '    Get
        '        Return oGenericPens
        '    End Get
        'End Property

        'Public ReadOnly Property Pens As cPens
        '    Get
        '        Return oPens
        '    End Get
        'End Property

        Public ReadOnly Property Fonts As cItemFonts
            Get
                Return oFonts
            End Get
        End Property

        Public ReadOnly Property GenericFonts As cItemFonts
            Get
                Return oGenericFonts
            End Get
        End Property
    End Class
End Namespace