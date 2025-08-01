﻿Imports cSurveyPC.cSurvey.Design.Options
Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design
    Public Class cOptions3D
        Inherits cOptionsCenterline
        Implements cIOptionLinkedSurveys
        Implements cIModelOptions3D

        Private oSurvey As cSurvey
        Private oSurfaceOptions As cSurface3DOptions
        Private bDrawModel As Boolean

        'clone of DotNetCaveModel.ColoringMode
        Public Enum ColoringMode
            CaveBranch = 0
            TightnessSmooth = 1
            DepthSmooth = 2
        End Enum

        'clone of DotNetCaveModel.RenderMode
        Public Enum RenderMode
            Original = 0
            RoughWalls = 1
            SmoothWalls = 2
            Cuts = 3
            Outline = 4
            Num = 5
        End Enum

        Private iDrawModelMode As RenderMode
        Private iDrawModelColoringMode As ColoringMode
        Private bModelColorGray As Boolean
        Private bModelExtendedElevation As Boolean

        Private iChunkCutMode As cIModelOptions3D.CutModeEnum

        Public Enum ChunkColoringMode
            OriginalMaterial = 0
            CavesAndBranches = 1
        End Enum

        Private bDrawChunks As Boolean
        Private iDrawChunkColoringMode As ChunkColoringMode
        Private bChunkColorGray As Boolean

        Private bDrawLinkedSurveys As Boolean

        Public Property DrawChunks As Boolean
            Get
                Return bDrawChunks
            End Get
            Set(value As Boolean)
                If bDrawChunks <> value Then
                    bDrawChunks = value
                    Call PropertyChanged("DrawChunks")
                End If
            End Set
        End Property

        Public Property DrawLinkedSurveys As Boolean Implements cIOptionLinkedSurveys.DrawLinkedSurveys
            Get
                Return bDrawLinkedSurveys
            End Get
            Set(value As Boolean)
                If bDrawLinkedSurveys <> value Then
                    bDrawLinkedSurveys = value
                    Call PropertyChanged("DrawLinkedSurveys")
                End If
            End Set
        End Property

        Public Property ChunkCutMode As cIModelOptions3D.CutModeEnum Implements cIModelOptions3D.CutMode
            Get
                Return iChunkCutMode
            End Get
            Set(value As cIModelOptions3D.CutModeEnum)
                If iChunkCutMode <> value Then
                    iChunkCutMode = value
                    Call MyBase.Rebind()
                    Call PropertyChanged("CutMode")
                End If
            End Set
        End Property

        Public Overridable Property ModelExtendedElevation As Boolean
            Get
                Return bModelExtendedElevation
            End Get
            Set(value As Boolean)
                If bModelExtendedElevation <> value Then
                    bModelExtendedElevation = value
                    Call MyBase.Rebind()
                    Call PropertyChanged("ModelExtendedElevation")
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
                    Call PropertyChanged("ModelColorGray")
                End If
            End Set
        End Property

        Public Overridable Property DrawModel() As Boolean
            Get
                Return bDrawModel
            End Get
            Set(ByVal value As Boolean)
                If bDrawModel <> value Then
                    bDrawModel = value
                    Call PropertyChanged("DrawModel")
                End If
            End Set
        End Property

        Public Property DrawModelMode As RenderMode
            Get
                Return iDrawModelMode
            End Get
            Set(value As RenderMode)
                If iDrawModelMode <> value Then
                    iDrawModelMode = value
                    Call PropertyChanged("DrawModelMode")
                End If
            End Set
        End Property

        Public Overridable Property ChunkColorGray As Boolean
            Get
                Return bChunkColorGray
            End Get
            Set(value As Boolean)
                If bChunkColorGray <> value Then
                    bChunkColorGray = value
                    Call MyBase.Rebind()
                    Call PropertyChanged("ChunkColorGray")
                End If
            End Set
        End Property

        Public Property DrawChunkColoringMode As ChunkColoringMode
            Get
                Return iDrawChunkColoringMode
            End Get
            Set(value As ChunkColoringMode)
                If iDrawChunkColoringMode <> value Then
                    iDrawChunkColoringMode = value
                    Call PropertyChanged("DrawChunkColoringMode")
                End If
            End Set
        End Property

        Public Property DrawModelColoringMode As ColoringMode
            Get
                Return iDrawModelColoringMode
            End Get
            Set(value As ColoringMode)
                If iDrawModelColoringMode <> value Then
                    iDrawModelColoringMode = value
                    Call PropertyChanged("DrawModelColoringMode")
                End If
            End Set
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Name As String)
            Call MyBase.New(Survey, Name, cIOptions.ModeEnum.Design)
            oSurvey = Survey
            oSurfaceOptions = New cSurface3DOptions(oSurvey)
            MyBase.DrawPoints = False
            MyBase.ShowPointText = False

            bDrawModel = True
            iDrawModelMode = RenderMode.RoughWalls
            iDrawModelColoringMode = ColoringMode.CaveBranch
            bModelColorGray = False

            iDrawChunkColoringMode = ChunkColoringMode.OriginalMaterial
            bChunkColorGray = False
            iChunkCutMode = cIModelOptions3D.CutModeEnum.None

            bDrawChunks = True
        End Sub

        Public Overloads ReadOnly Property SurfaceOptions As cSurface3DOptions
            Get
                Return oSurfaceOptions
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Options As XmlElement)
            Call MyBase.New(Survey, Options, cIOptions.ModeEnum.Design)
            oSurvey = Survey
            Call Import(Options)
        End Sub

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLOptions As XmlElement = MyBase.SaveTo(File, Document, Parent)
            Call oSurfaceOptions.SaveTo(File, Document, oXMLOptions)
            Call oXMLOptions.SetAttribute("drawmodel", If(bDrawModel, 1, 0))
            Call oXMLOptions.SetAttribute("drawmodelmode", iDrawModelMode.ToString("D"))
            Call oXMLOptions.SetAttribute("drawmodelcoloringmode", iDrawModelColoringMode.ToString("D"))
            Call oXMLOptions.SetAttribute("modelcolorgray", If(bModelColorGray, 1, 0))

            Call oXMLOptions.SetAttribute("drawchunks", If(bDrawChunks, 1, 0))
            Call oXMLOptions.SetAttribute("drawchunkcoloringmode", iDrawChunkColoringMode.ToString("D"))
            Call oXMLOptions.SetAttribute("chunkcolorgray", If(bChunkColorGray, 1, 0))

            Call oXMLOptions.SetAttribute("chunkcutmode", iChunkCutMode.ToString("D"))

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
            iDrawModelMode = modXML.GetAttributeValue(Options, "drawmodelmode", RenderMode.RoughWalls)
            iDrawModelColoringMode = modXML.GetAttributeValue(Options, "drawmodelcoloringmode", ColoringMode.CaveBranch)
            bModelColorGray = modXML.GetAttributeValue(Options, "modelcolorgray")

            bDrawChunks = modXML.GetAttributeValue(Options, "drawchunks")
            iDrawChunkColoringMode = modXML.GetAttributeValue(Options, "drawchunkcoloringmode", ChunkColoringMode.OriginalMaterial)
            bChunkColorGray = modXML.GetAttributeValue(Options, "chunkcolorgray")

            iChunkCutMode = modXML.GetAttributeValue(Options, "chunkcutmode", cIModelOptions3D.CutModeEnum.None)
            '---------------------
            'bDrawLinkedSurveys = modXML.GetAttributeValue(Options, "drawlinkedsurveys", 0)
        End Sub
    End Class
End Namespace
