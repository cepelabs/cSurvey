Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design.Layers
    Public Class cLayerWaterAndFloorMorphologies
        Inherits cLayer

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal File As Storage.cFile, ByVal Layer As XmlElement)
            MyBase.new(Survey, Design, File, Layer)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Name As String)
            MyBase.new(Survey, Design, Name, cLayers.LayerTypeEnum.WaterAndFloorMorphologies)
        End Sub

        Public Function CreateNotStandardWaterArea(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandArea
            Dim oItem As cItemFreeHandArea = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandArea, cIItem.cItemCategoryEnum.WaterArea)
            oItem.Pen.Type = cPen.PenTypeEnum.Pen
            oItem.Brush.Type = cBrush.BrushTypeEnum.NotStandardWater
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateWaterArea(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandArea
            Dim oItem As cItemFreeHandArea = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandArea, cIItem.cItemCategoryEnum.WaterArea)
            oItem.Pen.Type = cPen.PenTypeEnum.Pen
            oItem.Brush.Type = cBrush.BrushTypeEnum.Water
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateBorder(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandLine
            Dim oItem As cItemFreeHandLine = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandLine, cIItem.cItemCategoryEnum.LevelLine)
            oItem.Pen.Type = cPen.PenTypeEnum.Pen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreatePresumedBorder(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandLine
            Dim oItem As cItemFreeHandLine = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandLine, cIItem.cItemCategoryEnum.LevelLine)
            oItem.Pen.Type = cPen.PenTypeEnum.PresumedPen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateLevelCurve(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandLine
            Dim oItem As cItemFreeHandLine = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandLine, cIItem.cItemCategoryEnum.LevelLine)
            oItem.Pen.Type = cPen.PenTypeEnum.GradientDownPen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreatePresumedLevelCurve(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandLine
            Dim oItem As cItemFreeHandLine = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandLine, cIItem.cItemCategoryEnum.LevelLine)
            oItem.Pen.Type = cPen.PenTypeEnum.PresumedGradientDownPen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateOverhangCurve(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandLine
            Dim oItem As cItemFreeHandLine = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandLine, cIItem.cItemCategoryEnum.LevelLine)
            oItem.Pen.Type = cPen.PenTypeEnum.OverhangDownPen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreatePresumedOverhangCurve(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandLine
            Dim oItem As cItemFreeHandLine = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandLine, cIItem.cItemCategoryEnum.LevelLine)
            oItem.Pen.Type = cPen.PenTypeEnum.PresumedOverhangDownPen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateCliffCurve(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandLine
            Dim oItem As cItemFreeHandLine = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandLine, cIItem.cItemCategoryEnum.LevelLine)
            oItem.Pen.Type = cPen.PenTypeEnum.CliffDownPen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreatePresumedCliffCurve(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandLine
            Dim oItem As cItemFreeHandLine = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandLine, cIItem.cItemCategoryEnum.LevelLine)
            oItem.Pen.Type = cPen.PenTypeEnum.PresumedCliffDownPen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateMeander(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandLine
            Dim oItem As cItemFreeHandLine = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandLine, cIItem.cItemCategoryEnum.LevelLine)
            oItem.Pen.Type = cPen.PenTypeEnum.MeanderPen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreatePresumedMeander(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandLine
            Dim oItem As cItemFreeHandLine = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandLine, cIItem.cItemCategoryEnum.LevelLine)
            oItem.Pen.Type = cPen.PenTypeEnum.PresumedMeanderPen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function
    End Class
End Namespace
