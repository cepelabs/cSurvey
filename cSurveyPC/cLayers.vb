Imports System.Xml

Imports cSurveyPC.cSurvey.Design.Layers
Imports System.ComponentModel

Namespace cSurvey.Design
    Public Class cLayers
        Implements IEnumerable
        Implements IEnumerable(Of cLayer)

        Private oSurvey As cSurvey
        Private oDesign As cDesign

        Private oLayers As BindingList(Of cLayer)

        Friend ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Friend Overridable ReadOnly Property Design As cDesign
            Get
                Return oDesign
            End Get
        End Property

        Friend ReadOnly Property List As BindingList(Of cLayer)
            Get
                Return oLayers
            End Get
        End Property

        Public Enum LayerTypeEnum
            Base = 0
            Soil = 1
            WaterAndFloorMorphologies = 2
            RocksAndConcretion = 3
            CeilingMorphologies = 4
            Borders = 5
            Signs = 6
        End Enum

        Public Overridable ReadOnly Property RocksAndConcretionLayer() As cLayerRocks
            Get
                Return oLayers(LayerTypeEnum.RocksAndConcretion)
            End Get
        End Property

        Public Overridable ReadOnly Property CeilingMorphologiesLayer() As cLayerCeilingMorphologies
            Get
                Return oLayers(LayerTypeEnum.CeilingMorphologies)
            End Get
        End Property

        Public Overridable ReadOnly Property BordersLayer() As cLayerBorders
            Get
                Return oLayers(LayerTypeEnum.Borders)
            End Get
        End Property

        Public Overridable ReadOnly Property SignsLayer() As cLayerSigns
            Get
                Return oLayers(LayerTypeEnum.Signs)
            End Get
        End Property

        Public Overridable ReadOnly Property WaterAndFloorMorphologiesLayer() As cLayerWaterAndFloorMorphologies
            Get
                Return oLayers(LayerTypeEnum.WaterAndFloorMorphologies)
            End Get
        End Property

        Public Overridable ReadOnly Property SoilLayer() As cLayerSoil
            Get
                Return oLayers(LayerTypeEnum.Soil)
            End Get
        End Property

        Public Overridable ReadOnly Property BaseLayer() As cLayerBase
            Get
                Return oLayers(LayerTypeEnum.Base)
            End Get
        End Property

        Friend Sub MergeWith(Layers As cLayers)
            For Each oLayer As cLayer In Layers
                Call oLayers(oLayer.Type).Items.AddRange(oLayer.Items)
            Next
        End Sub

        Public Sub Clear()
            For Each oLayer As cLayer In oLayers
                Call oLayer.Items.Clear()
            Next
        End Sub

        Private Function pAdd(ByVal LayerType As LayerTypeEnum, ByVal File As cFile, ByVal Layer As XmlElement) As cLayer
            Dim oLayer As cLayer
            Select Case LayerType
                Case LayerTypeEnum.Base
                    oLayer = New cLayerBase(oSurvey, oDesign, File, Layer)
                Case LayerTypeEnum.Soil
                    oLayer = New cLayerSoil(oSurvey, oDesign, File, Layer)
                Case LayerTypeEnum.WaterAndFloorMorphologies
                    oLayer = New cLayerWaterAndFloorMorphologies(oSurvey, oDesign, File, Layer)
                Case LayerTypeEnum.RocksAndConcretion
                    oLayer = New cLayerRocks(oSurvey, oDesign, File, Layer)
                Case LayerTypeEnum.CeilingMorphologies
                    oLayer = New cLayerCeilingMorphologies(oSurvey, oDesign, File, Layer)
                Case LayerTypeEnum.Borders
                    oLayer = New cLayerBorders(oSurvey, oDesign, File, Layer)
                Case LayerTypeEnum.Signs
                    oLayer = New cLayerSigns(oSurvey, oDesign, File, Layer)
            End Select
            Call oLayers.Add(oLayer)
            Return oLayer
        End Function

        Private Function pAdd(ByVal LayerType As LayerTypeEnum) As cLayer
            Dim sName As String
            Dim oLayer As cLayer
            Select Case LayerType
                Case LayerTypeEnum.Base
                    sName = "Base"
                    oLayer = New cLayerBase(oSurvey, oDesign, sName)
                Case LayerTypeEnum.Soil
                    sName = "Soil"
                    oLayer = New cLayerSoil(oSurvey, oDesign, sName)
                Case LayerTypeEnum.WaterAndFloorMorphologies
                    sName = "Water and floor morphologies"
                    oLayer = New cLayerWaterAndFloorMorphologies(oSurvey, oDesign, sName)
                Case LayerTypeEnum.RocksAndConcretion
                    sName = "Rocks and concretions"
                    oLayer = New cLayerRocks(oSurvey, oDesign, sName)
                Case LayerTypeEnum.CeilingMorphologies
                    sName = "Ceiling morphologies"
                    oLayer = New cLayerCeilingMorphologies(oSurvey, oDesign, sName)
                Case LayerTypeEnum.Borders
                    sName = "Borders"
                    oLayer = New cLayerBorders(oSurvey, oDesign, sName)
                Case LayerTypeEnum.Signs
                    sName = "Signs"
                    oLayer = New cLayerSigns(oSurvey, oDesign, sName)
            End Select
            Call oLayers.Add(oLayer)
            Return oLayer
        End Function

        Default Public ReadOnly Property Item(ByVal Index As LayerTypeEnum) As cLayer
            Get
                Return oLayers(Index)
            End Get
        End Property

        Public Function IndexOf(ByVal Layer As cLayer) As Integer
            Return oLayers.IndexOf(Layer)
        End Function

        Public ReadOnly Property Count() As Integer
            Get
                Return oLayers.Count
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal File As cFile, ByVal Layers As XmlElement)
            oSurvey = Survey
            oDesign = Design
            oLayers = New BindingList(Of cLayer)

            Dim oLayerColl As SortedList(Of LayerTypeEnum, cLayer) = New SortedList(Of LayerTypeEnum, cLayer)

            For Each oXMLLayer As XmlElement In Layers.ChildNodes
                Dim iType As LayerTypeEnum = oXMLLayer.GetAttribute("type")
                Dim oLayer As cLayer
                Select Case iType
                    Case LayerTypeEnum.Base
                        oLayer = New cLayerBase(oSurvey, oDesign, File, oXMLLayer)
                    Case LayerTypeEnum.Soil
                        oLayer = New cLayerSoil(oSurvey, oDesign, File, oXMLLayer)
                    Case LayerTypeEnum.WaterAndFloorMorphologies
                        oLayer = New cLayerWaterAndFloorMorphologies(oSurvey, oDesign, File, oXMLLayer)
                    Case LayerTypeEnum.RocksAndConcretion
                        oLayer = New cLayerRocks(oSurvey, oDesign, File, oXMLLayer)
                    Case LayerTypeEnum.CeilingMorphologies
                        oLayer = New cLayerCeilingMorphologies(oSurvey, oDesign, File, oXMLLayer)
                    Case LayerTypeEnum.Borders
                        oLayer = New cLayerBorders(oSurvey, oDesign, File, oXMLLayer)
                    Case LayerTypeEnum.Signs
                        oLayer = New cLayerSigns(oSurvey, oDesign, File, oXMLLayer)
                End Select
                If Not oLayerColl.ContainsKey(iType) Then
                    Call oLayerColl.Add(iType, oLayer)
                End If
            Next
            For iLayerType As LayerTypeEnum = LayerTypeEnum.Base To LayerTypeEnum.Signs
                If oLayerColl.ContainsKey(iLayerType) Then
                    Call oLayers.Add(oLayerColl(iLayerType))
                Else
                    Call pAdd(iLayerType)
                End If
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum)
            Dim oXmlLayers As XmlElement = Document.CreateElement("layers")
            For Each oLayer As cLayer In oLayers
                Call oLayer.SaveTo(File, Document, oXmlLayers, Options)
            Next
            Call Parent.AppendChild(oXmlLayers)
            Return oXmlLayers
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign)
            oSurvey = Survey
            oDesign = Design
            oLayers = New BindingList(Of cLayer)
            Call pAdd(LayerTypeEnum.Base)
            Call pAdd(LayerTypeEnum.Soil)
            Call pAdd(LayerTypeEnum.WaterAndFloorMorphologies)
            Call pAdd(LayerTypeEnum.RocksAndConcretion)
            Call pAdd(LayerTypeEnum.CeilingMorphologies)
            Call pAdd(LayerTypeEnum.Borders)
            Call pAdd(LayerTypeEnum.Signs)
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oLayers.GetEnumerator
        End Function

        Public Function ToArray() As cLayer()
            Return oLayers.ToArray
        End Function

        Private Function cLayer_GetEnumerator() As IEnumerator(Of cLayer) Implements IEnumerable(Of cLayer).GetEnumerator
            Return oLayers.GetEnumerator
        End Function
    End Class
End Namespace