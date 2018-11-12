Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design.Layers
    Public Class cLayerSoil
        Inherits cLayer

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal File As Storage.cFile, ByVal Layer As XmlElement)
            MyBase.new(Survey, Design, File, Layer)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Name As String)
            MyBase.new(Survey, Design, Name, cLayers.LayerTypeEnum.Soil)
        End Sub

        Public Function CreateSmallDebritsSoil(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandArea
            Dim oitem As cItemFreeHandArea = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandArea, cIItem.cItemCategoryEnum.Soil)
            oitem.Pen.Type = cPen.PenTypeEnum.None
            oitem.Brush.Type = cBrush.BrushTypeEnum.SmallDebrits
            Call oitem.SetCave(Cave, Branch)
            Return oitem
        End Function

        Public Function CreateBigDebritsSoil(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandArea
            Dim oitem As cItemFreeHandArea = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandArea, cIItem.cItemCategoryEnum.Soil)
            oitem.Pen.Type = cPen.PenTypeEnum.None
            oitem.Brush.Type = cBrush.BrushTypeEnum.BigDebrits
            Call oitem.SetCave(Cave, Branch)
            Return oitem
        End Function

        Public Function CreateSandSoil(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandArea
            Dim oitem As cItemFreeHandArea = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandArea, cIItem.cItemCategoryEnum.Soil)
            oitem.Pen.Type = cPen.PenTypeEnum.None
            oitem.Brush.Type = cBrush.BrushTypeEnum.Sand
            Call oitem.SetCave(Cave, Branch)
            Return oitem
        End Function

        Public Function CreateSoil(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandArea
            Dim oitem As cItemFreeHandArea = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandArea, cIItem.cItemCategoryEnum.Soil)
            oitem.Pen.Type = cPen.PenTypeEnum.TightPen
            oitem.Brush.Type = cBrush.BrushTypeEnum.Solid
            Call oitem.SetCave(Cave, Branch)
            Return oitem
        End Function

        Public Function CreateFlowSoil(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandArea
            Dim oitem As cItemFreeHandArea = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandArea, cIItem.cItemCategoryEnum.Soil)
            oitem.Pen.Type = cPen.PenTypeEnum.None
            oitem.Brush.Type = cBrush.BrushTypeEnum.Flow
            Call oitem.SetCave(Cave, Branch)
            Return oitem
        End Function

        Public Function CreatePebblesSoil(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandArea
            Dim oitem As cItemFreeHandArea = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandArea, cIItem.cItemCategoryEnum.Soil)
            oitem.Pen.Type = cPen.PenTypeEnum.None
            oitem.Brush.Type = cBrush.BrushTypeEnum.Pebbles
            Call oitem.SetCave(Cave, Branch)
            Return oitem
        End Function


    End Class
End Namespace
