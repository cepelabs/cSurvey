Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design
    Public Class cOptionsViewer
        Inherits cOptionsDesign

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLOptions As XmlElement = MyBase.SaveTo(File, Document, Parent)
            Return oXMLOptions
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Name As String)
            Call MyBase.New(Survey, Name, cIOptions.ModeEnum.Viewer)
            CompassStyle = CompassStyleEnum.Simple
            ScaleStyle = ScaleStyleEnum.Simple
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Options As XmlElement)
            Call MyBase.New(Survey, Options, cIOptions.ModeEnum.Viewer)
            CompassStyle = CompassStyleEnum.Simple
            ScaleStyle = ScaleStyleEnum.Simple
        End Sub

        Public Overrides Sub Import(Options As XmlElement)
            Call MyBase.Import(Options)
            '---------------------
            CompassStyle = CompassStyleEnum.Simple
            ScaleStyle = ScaleStyleEnum.Simple
        End Sub
    End Class
End Namespace