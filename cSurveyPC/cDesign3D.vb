Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design
    'Public Class cDesign3D
    '    Implements cIDesign

    '    Private oSurvey As cSurvey

    '    Public Sub New(Survey As cSurvey)
    '        oSurvey = Survey
    '    End Sub

    '    Public ReadOnly Property Type As cIDesign.cDesignTypeEnum Implements cIDesign.Type
    '        Get
    '            Return cIDesign.cDesignTypeEnum.ThreeDModel
    '        End Get
    '    End Property
    'End Class

    Public Class cDesign3D
        Inherits cDesign

        Private oSurvey As cSurvey

        Public Sub New(Survey As cSurvey)
            Call MyBase.New(Survey)
            oSurvey = Survey
        End Sub

        Friend Overrides Sub AppendSvgItem(SVG As XmlDocument, Parent As XmlElement, PaintOptions As cOptions, Options As cItem.SVGOptionsEnum, ViewArea As RectangleF, Zoom As Single, Translate As PointF)

        End Sub

        Public Overrides Sub Clear()

        End Sub

        Public Overloads Overrides Function GetNearestSegment(Cave As String, Branch As String, CrossSection As String, X As Single, Y As Single, BindDesignType As cItem.BindDesignTypeEnum) As cISegment

        End Function

        Public Overloads Overrides Function GetNearestSegment(Cave As String, Branch As String, CrossSection As String, Point As PointF, BindDesignType As cItem.BindDesignTypeEnum) As cISegment

        End Function

        Friend Overrides Function GetSegmentPointData(Segment As cISegment) As Calculate.Plot.cIProjectedData

        End Function

        Public Overrides ReadOnly Property Plot As cPlot
            Get

            End Get
        End Property

        Friend Overrides Function ToSvg(PaintOptions As cOptions, Options As cItem.SVGOptionsEnum, ViewArea As RectangleF, Zoom As Single, Translate As PointF) As XmlDocument

        End Function

        Friend Overrides Function ToSvgItem(SVG As XmlDocument, PaintOptions As cOptions, Options As cItem.SVGOptionsEnum, ViewArea As RectangleF, Zoom As Single, Translate As PointF) As XmlElement

        End Function

        Public Overrides ReadOnly Property Type As cIDesign.cDesignTypeEnum
            Get
                Return cIDesign.cDesignTypeEnum.ThreeDModel
            End Get
        End Property

        Friend Overrides Sub WarpItems(Segment As cISegment)

        End Sub
    End Class
End Namespace
