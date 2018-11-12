Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design.Layers
    Public Class cLayerCeilingMorphologies
        Inherits cLayer

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal File As Storage.cFile, ByVal Layer As XmlElement)
            MyBase.new(Survey, Design, File, Layer)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Name As String)
            MyBase.new(Survey, Design, Name, cLayers.LayerTypeEnum.CeilingMorphologies)
        End Sub

        Public Function CreateCeilingBorder(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandLine
            Dim oItem As cItemFreeHandLine = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandLine, cIItem.cItemCategoryEnum.LevelLine)
            oItem.Pen.Type = cPen.PenTypeEnum.PresumedPen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateCeilingLevelCurve(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandLine
            Dim oItem As cItemFreeHandLine = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandLine, cIItem.cItemCategoryEnum.LevelLine)
            oItem.Pen.Type = cPen.PenTypeEnum.PresumedGradientDownPen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateCeilingOverhangCurve(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandLine
            Dim oItem As cItemFreeHandLine = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandLine, cIItem.cItemCategoryEnum.LevelLine)
            oItem.Pen.Type = cPen.PenTypeEnum.PresumedOverhangDownPen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateCeilingCliffCurve(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandLine
            Dim oItem As cItemFreeHandLine = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandLine, cIItem.cItemCategoryEnum.LevelLine)
            oItem.Pen.Type = cPen.PenTypeEnum.PresumedCliffDownPen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateCeilingMeander(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandLine
            Dim oItem As cItemFreeHandLine = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandLine, cIItem.cItemCategoryEnum.LevelLine)
            oItem.Pen.Type = cPen.PenTypeEnum.PresumedMeanderPen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

    End Class
End Namespace
