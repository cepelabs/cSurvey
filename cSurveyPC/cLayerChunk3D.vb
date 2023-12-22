Imports System.Xml
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design
    Public Class cLayerChunk3D
        Inherits cLayer3D

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D, ByVal File As cFile, ByVal Layer As XmlElement)
            Call MyBase.New(Survey, Design, File, Layer)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D, ByVal Name As String)
            Call MyBase.New(Survey, Design, Name, cLayers3D.Layer3DTypeEnum.Chunks)
        End Sub

        Public Function CreateChunk(ByVal Cave As String, ByVal Branch As String, Filename As String) As cItemChunk3D
            Dim oItem As cItemChunk3D = MyBase.CreateItem(cIItem.cItemTypeEnum.Chunk3D, cIItem.cItemCategoryEnum.None, Filename)
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function
    End Class
End Namespace
