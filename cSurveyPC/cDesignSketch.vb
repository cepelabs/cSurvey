Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings

Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design
    Public Class cDesignSketch

        Private oSurvey As cSurvey

        Private sID As String
        Private iDesignType As cIDesign.cDesignTypeEnum
        Private iSketch As Integer '= -1
        Private oSketch As cItemSketch

        Public ReadOnly Property ID As String
            Get
                Return sID
            End Get
        End Property

        Public ReadOnly Property Sketch As cItemSketch
            Get
                Return oSketch
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Sketch As cItemSketch)
            oSurvey = Survey
            sID = Guid.NewGuid.ToString
            iSketch = -1
            oSketch = Sketch
            iDesignType = oSketch.Design.Type
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Sketch As XmlElement)
            oSurvey = Survey
            sID = Sketch.GetAttribute("id")
            iDesignType = Sketch.GetAttribute("designtype")
            iSketch = Sketch.GetAttribute("sketch")
        End Sub

        Friend Sub RebindSketch()
            If iSketch <> -1 Then
                If iDesignType = cIDesign.cDesignTypeEnum.Plan Then
                    oSketch = oSurvey.Plan.Layers(cLayers.LayerTypeEnum.Base).Items(iSketch)
                Else
                    oSketch = oSurvey.Profile.Layers(cLayers.LayerTypeEnum.Base).Items(iSketch)
                End If
                iSketch = -1
            End If
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlSketch As XmlElement = Document.CreateElement("sketch")
            Call oXmlSketch.SetAttribute("id", sID)
            Call oXmlSketch.SetAttribute("designtype", iDesignType)
            If iDesignType = cIDesign.cDesignTypeEnum.Plan Then
                Call oXmlSketch.SetAttribute("sketch", oSurvey.Plan.Layers(cLayers.LayerTypeEnum.Base).Items.IndexOf(oSketch))
            Else
                Call oXmlSketch.SetAttribute("sketch", oSurvey.Profile.Layers(cLayers.LayerTypeEnum.Base).Items.IndexOf(oSketch))
            End If
            Call Parent.AppendChild(oXmlSketch)
            Return oXmlSketch
        End Function
    End Class
End Namespace
