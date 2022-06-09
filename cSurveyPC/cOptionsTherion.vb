Imports cSurveyPC.cSurvey.Design.Options
Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design
    Public Class cOptionsTherion
        Inherits cOptions

        Private oSurfaceOptions As cSurfaceTherionOptions

        Friend Sub New(ByVal Survey As cSurvey, ByVal Name As String)
            Call MyBase.New(Survey, Name, cIOptions.ModeEnum.Preview)
            oSurfaceOptions = New cSurfaceTherionOptions(MyBase.Survey)
        End Sub

        Public Overloads ReadOnly Property SurfaceOptions As cSurfaceTherionOptions
            Get
                Return oSurfaceOptions
            End Get
        End Property

        Public Overrides ReadOnly Property DefaultOptions As cOptions
            Get
                Return Nothing
            End Get
        End Property

        Public Overrides ReadOnly Property Mode() As cIOptions.ModeEnum
            Get
                Return cIOptions.ModeEnum.Preview
            End Get
        End Property

        Public Overrides Function IsViewer() As Boolean
            Return False
        End Function

        Public Overrides Function IsPreview() As Boolean
            Return True
        End Function

        Public Overrides Function IsDesign() As Boolean
            Return False
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Options As XmlElement)
            Call MyBase.New(Survey, Options.Name, cIOptions.ModeEnum.Preview)
            Call Import(Options)
        End Sub

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlOptions As XmlElement = MyBase.SaveTo(File, Document, Parent)
            Call oSurfaceOptions.SaveTo(File, Document, oXmlOptions)
            Return oXmlOptions
        End Function

        Public Sub Import(Options As XmlElement)
            Try
                oSurfaceOptions = New cSurfaceTherionOptions(MyBase.Survey, Options.Item("surfacetherionoptions"))
            Catch ex As Exception
                oSurfaceOptions = New cSurfaceTherionOptions(MyBase.Survey)
            End Try
        End Sub

        Public Overrides Function GetParent() As cIProfile
            Return Nothing
        End Function

        Public Overrides Function GetOption() As cIOptions
            Return Me
        End Function

    End Class
End Namespace
