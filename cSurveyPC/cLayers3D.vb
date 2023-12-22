Imports System.ComponentModel
Imports System.Xml
Imports cSurveyPC.cSurvey.Design.Layers
Imports cSurveyPC.cSurvey.Design3D
Imports DevExpress.XtraGauges.Core.Model

Namespace cSurvey.Design
    Public Class cLayers3D
        Inherits cLayers

        Public Enum Layer3DTypeEnum
            Chunks = 0
        End Enum

        Public Shadows ReadOnly Property Design As cDesign3D
            Get
                Return MyBase.Design
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D, ByVal File As cFile, ByVal Layers As XmlElement)
            MyBase.New(Survey, Design)

            Call MyBase.List.Clear()

            Dim oLayerColl As SortedList(Of Layer3DTypeEnum, cLayer3D) = New SortedList(Of Layer3DTypeEnum, cLayer3D)

            For Each oXMLLayer As XmlElement In Layers.ChildNodes
                Dim iType As Layer3DTypeEnum = oXMLLayer.GetAttribute("type")
                Dim oLayer As cLayer3D
                Select Case iType
                    Case Layer3DTypeEnum.Chunks
                        oLayer = New cLayerChunk3D(Survey, Design, File, oXMLLayer)
                End Select
                If Not oLayerColl.ContainsKey(iType) Then
                    Call oLayerColl.Add(iType, oLayer)
                End If
            Next
            For iLayerType As Layer3DTypeEnum = Layer3DTypeEnum.Chunks To Layer3DTypeEnum.Chunks
                If oLayerColl.ContainsKey(iLayerType) Then
                    Call MyBase.List.Add(oLayerColl(iLayerType))
                Else
                    Call pAdd(iLayerType)
                End If
            Next
        End Sub

        Private Function pAdd(ByVal LayerType As Layer3DTypeEnum, ByVal File As cFile, ByVal Layer As XmlElement) As cLayer3D
            Dim oLayer As cLayer3D
            Select Case LayerType
                Case Layer3DTypeEnum.Chunks
                    oLayer = New cLayerChunk3D(Survey, Design, File, Layer)
            End Select
            Call MyBase.List.Add(oLayer)
            Return oLayer
        End Function

        Private Function pAdd(ByVal LayerType As Layer3DTypeEnum) As cLayer3D
            Dim sName As String
            Dim oLayer As cLayer
            Select Case LayerType
                Case Layer3DTypeEnum.Chunks
                    sName = "Chunks"
                    oLayer = New cLayerChunk3D(Survey, Design, sName)
            End Select
            Call MyBase.List.Add(oLayer)
            Return oLayer
        End Function

        Public Sub New(Survey As cSurvey, Design As cDesign3D)
            MyBase.New(Survey, Design)
            MyBase.List.Clear()
            Call pAdd(Layer3DTypeEnum.Chunks)
        End Sub

        Public Shadows ReadOnly Property BaseLayer() As cLayerChunk3D
            Get
                Return MyBase.Item(Layer3DTypeEnum.Chunks)
            End Get
        End Property

        Public ReadOnly Property ChunkLayer() As cLayerChunk3D
            Get
                Return MyBase.Item(Layer3DTypeEnum.Chunks)
            End Get
        End Property

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum)
            Dim oXmlLayers As XmlElement = Document.CreateElement("layers3d")
            For Each oLayer As cLayer In Me
                Call oLayer.SaveTo(File, Document, oXmlLayers, Options)
            Next
            Call Parent.AppendChild(oXmlLayers)
            Return oXmlLayers
        End Function
    End Class
End Namespace
