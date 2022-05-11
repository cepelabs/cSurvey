Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design.Layers
    Public Class cLayerRocks
        Inherits cLayer

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal File As cFile, ByVal Layer As XmlElement)
            MyBase.new(Survey, Design, File, Layer)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Name As String)
            MyBase.new(Survey, Design, Name, cLayers.LayerTypeEnum.RocksAndConcretion)
        End Sub

        Public Function CreateRockBorder(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandLine
            Dim oitem As cItemFreeHandLine = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandLine, cIItem.cItemCategoryEnum.Rock)
            oitem.Pen.Type = cPen.PenTypeEnum.Pen
            Call oitem.SetCave(Cave, Branch)
            Return oitem
        End Function

        Public Function CreateRockArea(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandArea
            Dim oitem As cItemFreeHandArea = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandArea, cIItem.cItemCategoryEnum.Rock)
            oitem.Pen.Type = cPen.PenTypeEnum.Pen
            oitem.Brush.Type = cBrush.BrushTypeEnum.Solid
            Call oitem.SetCave(Cave, Branch)
            Return oitem
        End Function

        Public Function CreateRockFromClipart(ByVal Cave As String, ByVal Branch As String, ByVal Data As Object, ByVal DataFormat As cIItemClipartBase.cClipartDataFormatEnum) As cItemClipart
            Dim oItem As cItemClipart = MyBase.CreateItem(cIItem.cItemTypeEnum.Clipart, cIItem.cItemCategoryEnum.Rock, Data, DataFormat)
            oItem.Pen.Type = cPen.PenTypeEnum.Pen
            oItem.Brush.Type = cBrush.BrushTypeEnum.Solid
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateConcretionBorder(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandLine
            Dim oitem As cItemFreeHandLine = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandLine, cIItem.cItemCategoryEnum.Concretion)
            oitem.Pen.Type = cPen.PenTypeEnum.Pen
            Call oitem.SetCave(Cave, Branch)
            Return oitem
        End Function

        Public Function CreateConcretionBorderWithFilling(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandArea
            Dim oitem As cItemFreeHandArea = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandArea, cIItem.cItemCategoryEnum.Concretion)
            oitem.Pen.Type = cPen.PenTypeEnum.Pen
            oitem.Brush.Type = cBrush.BrushTypeEnum.Solid
            Call oitem.SetCave(Cave, Branch)
            Return oitem
        End Function

        Public Function CreateConcretionFromClipart(ByVal Cave As String, ByVal Branch As String, ByVal Data As Object, ByVal DataFormat As cIItemClipartBase.cClipartDataFormatEnum) As cItemClipart
            Dim oItem As cItemClipart = MyBase.CreateItem(cIItem.cItemTypeEnum.Clipart, cIItem.cItemCategoryEnum.Concretion, Data, DataFormat)
            oItem.Pen.Type = cPen.PenTypeEnum.Pen
            oItem.Brush.Type = cBrush.BrushTypeEnum.Solid
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

    End Class
End Namespace
