
Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design
    Public MustInherit Class cDesignGeneric
        Private oSurvey As cSurvey
        Private sName As String

        Private oCaches As cDrawCaches

        Private oLocation As PointF

        Friend Overridable Function ToSvgItem(ByVal SVG As cSVGWriter, ByVal PaintOptions As cOptionsCenterline) As XmlElement
            Dim oSVGItem As XmlElement = oCaches(PaintOptions).ToSvgItem(SVG, PaintOptions)
            Call oSVGItem.SetAttribute("id", sName)
            Return oSVGItem
        End Function

        Friend Overridable Function ToSvg(ByVal PaintOptions As cOptionsCenterline, ByVal Options As cSVGWriter.SVGOptionsEnum) As XmlDocument
            Dim oSVG As cSVGWriter = modSVG.CreateSVG(Options)
            Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions))
            Return oSVG
        End Function

        Public MustOverride Function GetBounds(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline) As RectangleF

        Public Overridable Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline)
            Call Render(Graphics, PaintOptions)
            Call Caches(PaintOptions).Paint(Graphics, PaintOptions, cItem.PaintOptionsEnum.None)
        End Sub

        Public MustOverride Sub Render(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline)

        Friend Sub New(ByVal Survey As cSurvey, ByVal Name As String)
            oSurvey = Survey
            oCaches = New cDrawCaches

            sName = Name
        End Sub

        Friend Property Location As PointF
            Get
                Return oLocation
            End Get
            Set(ByVal value As PointF)
                oLocation = value
            End Set
        End Property

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Friend ReadOnly Property Caches As cDrawCaches
            Get
                Return oCaches
            End Get
        End Property

        Friend MustOverride Sub Rebind(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal ViewArea As RectangleF, ByVal Parameters As Object)
    End Class
End Namespace