Imports System.Xml
Imports cSurveyPC.cSurvey.Design3D
Imports DevExpress.XtraGauges.Core.Model

Namespace cSurvey.Design
    Public Class cDesign3D
        Inherits cDesign

        Private oSurvey As cSurvey

        Private WithEvents oLayers As cLayers3D

        'Private oChunks As cChunks3D

        'Public ReadOnly Property Chunks As cChunks3D
        '    Get
        '        Return oChunks
        '    End Get
        'End Property

        Public Shadows ReadOnly Property Layers() As cLayers3D
            Get
                Return oLayers
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal Design As XmlElement)
            Call MyBase.New(Survey, File, Design)
            oSurvey = Survey

            If modXML.ChildElementExist(Design, "layers3d") Then
                oLayers = New cLayers3D(oSurvey, Me, File, Design.Item("layers3d"))
            Else
                oLayers = New cLayers3D(oSurvey, Me)
            End If
        End Sub

        Public Sub New(Survey As cSurvey)
            Call MyBase.New(Survey)
            oSurvey = Survey
            oLayers = New cLayers3D(oSurvey, Me)
        End Sub

        'Public Function Add(Filename As String) As cChunk3D
        '    Return oChunks.Add(Filename)
        'End Function

        Public Overrides Sub Clear()
            'Call oChunks.Clear()
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

        Friend Overrides Function ToSvg(PaintOptions As cOptionsCenterline, Options As cItem.SVGOptionsEnum, Size As SizeF, PageBox As RectangleF, Unit As SizeUnit, ByVal ViewBox As RectangleF) As XmlDocument
        End Function

        Public Overrides ReadOnly Property Type As cIDesign.cDesignTypeEnum
            Get
                Return cIDesign.cDesignTypeEnum.ThreeDModel
            End Get
        End Property

        Friend Overrides Sub WarpItems(Segment As cISegment)
        End Sub

        Friend Overrides Function ToSvgItem(SVG As XmlDocument, PaintOptions As cOptionsCenterline, Options As cItem.SVGOptionsEnum) As XmlElement
        End Function

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXmlDesign As XmlElement = Document.CreateElement("model3d")
            If oXmlDesign.Item("layer") IsNot Nothing Then Call oXmlDesign.RemoveChild(oXmlDesign.Item("layer"))
            Call oLayers.SaveTo(File, Document, oXmlDesign, Options)
            Call Parent.AppendChild(oXmlDesign)
            Return oXmlDesign
        End Function
    End Class
End Namespace
