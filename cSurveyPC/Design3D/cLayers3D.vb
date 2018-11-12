Imports System.Xml
Imports cSurveyPC.cSurvey.Design.Design3D.Layers

Namespace cSurvey.Design.Design3D
    Public Class cLayers3D
        Implements cILayers
        Implements IEnumerable

        Private oSurvey As cSurvey
        Private oDesign As cDesign3D

        Private oLayers As List(Of cILayer)

        Public Sub Clear() Implements cILayers.Clear
            For Each oLayer As cLayer3D In oLayers
                Call oLayer.Items.Clear()
            Next
        End Sub

        Private Function pAdd(ByVal LayerType As cILayers.LayerTypeEnum, ByVal File As Storage.cFile, ByVal Layer As XmlElement) As cLayer3D
            Dim oLayer As cLayer3D
            Select Case LayerType
                Case cILayers.LayerTypeEnum.Base
                    oLayer = New cLayerBase3D(oSurvey, oDesign, File, Layer)
            End Select
            Call oLayers.Add(oLayer)
            Return oLayer
        End Function

        Private Function pAdd(ByVal LayerType As cILayers.LayerTypeEnum) As cLayer3D
            Dim sName As String
            Dim oLayer As cLayer3D
            Select Case LayerType
                Case cILayers.LayerTypeEnum.Base
                    sName = "Base"
                    oLayer = New cLayerBase3D(oSurvey, oDesign, sName)
            End Select
            Call oLayers.Add(oLayer)
            Return oLayer
        End Function

        Default Public ReadOnly Property Item(ByVal Index As cILayers.LayerTypeEnum) As cILayer Implements cILayers.Item
            Get
                Return oLayers(Index)
            End Get
        End Property

        Public Function IndexOf(ByVal Layer As cILayer) As Integer Implements cILayers.IndexOf
            Return oLayers.IndexOf(Layer)
        End Function

        Public ReadOnly Property Count() As Integer Implements cILayers.Count
            Get
                Return oLayers.Count
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D, ByVal File As Storage.cFile, ByVal Layers As XmlElement)
            oSurvey = Survey
            oDesign = Design
            oLayers = New List(Of cILayer)

            Dim oLayerColl As SortedList(Of cILayer.LayerTypeEnum, cLayer3D) = New SortedList(Of cILayer.LayerTypeEnum, cLayer3D)

            For Each oXMLLayer As XmlElement In Layers.ChildNodes
                Dim iType As cILayer.LayerTypeEnum = oXMLLayer.GetAttribute("type")
                Dim oLayer As cLayer3D
                Select Case iType
                    Case cILayer.LayerTypeEnum.Base
                        oLayer = New cLayerBase3D(oSurvey, oDesign, File, oXMLLayer)
                End Select
                If Not oLayerColl.ContainsKey(iType) Then
                    Call oLayerColl.Add(iType, oLayer)
                End If
            Next
            For iLayerType As cILayer.LayerTypeEnum = cILayer.LayerTypeEnum.Base To cILayer.LayerTypeEnum.Base
                If oLayerColl.ContainsKey(iLayerType) Then
                    Call oLayers.Add(oLayerColl(iLayerType))
                Else
                    Call pAdd(iLayerType)
                End If
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum)
            Dim oXmlLayers As XmlElement = Document.CreateElement("layers")
            For Each oLayer As cLayer3D In oLayers
                Call oLayer.SaveTo(File, Document, oXmlLayers, Options)
            Next
            Call Parent.AppendChild(oXmlLayers)
            Return oXmlLayers
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D)
            oSurvey = Survey
            oDesign = Design
            oLayers = New List(Of cILayer)
            Call pAdd(cILayers.LayerTypeEnum.Base)
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oLayers.GetEnumerator
        End Function

        Public Function ToArray() As cILayer() Implements cILayers.ToArray
            Return oLayers.ToArray
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator(Of cLayer3D) Implements IEnumerable(Of cILayers).GetEnumerator
            Return oLayers.GetEnumerator
        End Function
    End Class
End Namespace
