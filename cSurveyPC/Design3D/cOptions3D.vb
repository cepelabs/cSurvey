Imports cSurveyPC.cSurvey.Design.Options
Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design
    Public Class cOptions3D
        Inherits cOptionsDesign

        Private oSurvey As cSurvey
        Private oSurfaceOptions As cSurface3DOptions
        Private bDrawModel As Boolean

        Private iDrawModelMode As DotNetCaveModel.RenderMode
        Private iDrawModelColoringMode As DotNetCaveModel.ColoringMode
        Private bModelColorGray As Boolean
        Private bModelExtendedElevation As Boolean

        Public Overridable Property ModelExtendedElevation As Boolean
            Get
                Return bModelExtendedElevation
            End Get
            Set(value As Boolean)
                If bModelExtendedElevation <> value Then
                    bModelExtendedElevation = value
                    Call MyBase.Rebind()
                End If
            End Set
        End Property

        Public Overridable Property ModelColorGray As Boolean
            Get
                Return bModelColorGray
            End Get
            Set(value As Boolean)
                If bModelColorGray <> value Then
                    bModelColorGray = value
                    Call MyBase.Rebind()
                End If
            End Set
        End Property

        Public Overridable Property DrawModel() As Boolean
            Get
                Return bDrawModel
            End Get
            Set(ByVal value As Boolean)
                bDrawModel = value
            End Set
        End Property

        Public Property DrawModelMode As RenderMode
            Get
                Return iDrawModelMode
            End Get
            Set(value As RenderMode)
                iDrawModelMode = value
            End Set
        End Property

        Public Property DrawModelColoringMode As ColoringMode

            Get
                Return iDrawModelColoringMode
            End Get
            Set(value As ColoringMode)
                iDrawModelColoringMode = value
            End Set
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Name As String)
            Call MyBase.New(Survey, Name)
            oSurvey = Survey
            oSurfaceOptions = New cSurface3DOptions(oSurvey)
            MyBase.DrawPoints = False
            MyBase.ShowPointText = False

            bDrawModel = True
            iDrawModelMode = RenderMode.SM_ROUGH_WALLS
            iDrawModelColoringMode = ColoringMode.CM_CAVEBRANCH
            bModelColorGray = False
        End Sub

        Public Overloads ReadOnly Property SurfaceOptions As cSurface3DOptions
            Get
                Return oSurfaceOptions
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Options As XmlElement)
            Call MyBase.New(Survey, Options)
            oSurvey = Survey
            Call Import(Options)
            'Try
            '    oSurfaceOptions = New cSurface3DOptions(oSurvey, Options.Item("surface3doptions"))
            'Catch ex As Exception
            '    oSurfaceOptions = New cSurface3DOptions(oSurvey)
            'End Try
            'bDrawModel = modXML.GetAttributeValue(Options, "drawmodel")
            'iDrawModelMode = modXML.GetAttributeValue(Options, "drawmodelmode", RenderMode.SM_ROUGH_WALLS)
            'iDrawModelColoringMode = modXML.GetAttributeValue(Options, "drawmodelcoloringmode", ColoringMode.CM_CAVEBRANCH)
            'bModelColorGray = modXML.GetAttributeValue(Options, "modelcolorgray")
        End Sub

        Friend Overrides Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLOptions As XmlElement = MyBase.SaveTo(File, Document, Parent)
            Call oSurfaceOptions.SaveTo(File, Document, oXMLOptions)
            oXMLOptions.SetAttribute("drawmodel", IIf(bDrawModel, 1, 0))
            oXMLOptions.SetAttribute("drawmodelmode", iDrawModelMode.ToString("D"))
            oXMLOptions.SetAttribute("drawmodelcoloringmode", iDrawModelColoringMode.ToString("D"))
            Call oXMLOptions.SetAttribute("modelcolorgray", IIf(bModelColorGray, 1, 0))
            Return oXMLOptions
        End Function

        Public Overrides Sub Import(Options As XmlElement)
            MyBase.Import(Options)
            Try
                oSurfaceOptions = New cSurface3DOptions(oSurvey, Options.Item("surface3doptions"))
            Catch ex As Exception
                oSurfaceOptions = New cSurface3DOptions(oSurvey)
            End Try
            bDrawModel = modXML.GetAttributeValue(Options, "drawmodel")
            iDrawModelMode = modXML.GetAttributeValue(Options, "drawmodelmode", RenderMode.SM_ROUGH_WALLS)
            iDrawModelColoringMode = modXML.GetAttributeValue(Options, "drawmodelcoloringmode", ColoringMode.CM_CAVEBRANCH)
            bModelColorGray = modXML.GetAttributeValue(Options, "modelcolorgray")
        End Sub
    End Class
End Namespace
