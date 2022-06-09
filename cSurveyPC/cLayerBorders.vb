Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design.Layers
    Public Class cLayerBorders
        Inherits cLayer

        Friend Overrides Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Clipping As cClippingRegions, ByVal Selection As Helper.Editor.cIEditDesignSelection)
            'forzo la render dei bordi perché mi serve averli sempre aggiornati per fare il clipping...
            For Each oItem As cItem In MyBase.Items
                If oItem.Type = cIItem.cItemTypeEnum.InvertedFreeHandArea Then
                    Call oItem.Render(Graphics, PaintOptions, Options, cItem.SelectionModeEnum.None)
                End If
            Next
            Call MyBase.Paint(Graphics, PaintOptions, Options, Clipping, Selection)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal File As cFile, ByVal Layer As XmlElement)
            Call MyBase.new(Survey, Design, File, Layer)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Name As String)
            Call MyBase.New(Survey, Design, Name, cLayers.LayerTypeEnum.Borders)
        End Sub

        Public Function CreateExternalBorder(ByVal Cave As String, ByVal Branch As String) As cItemInvertedFreeHandArea
            Dim oItem As cItemInvertedFreeHandArea = MyBase.CreateItem(cIItem.cItemTypeEnum.InvertedFreeHandArea, cIItem.cItemCategoryEnum.CaveBorder)
            oItem.Pen.Type = cPen.PenTypeEnum.None
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateCaveBorder(ByVal Cave As String, ByVal Branch As String) As cItemInvertedFreeHandArea
            Dim oItem As cItemInvertedFreeHandArea = MyBase.CreateItem(cIItem.cItemTypeEnum.InvertedFreeHandArea, cIItem.cItemCategoryEnum.CaveBorder)
            oItem.Pen.Type = cPen.PenTypeEnum.CavePen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreatePresumedCaveBorder(ByVal Cave As String, ByVal Branch As String) As cItemInvertedFreeHandArea
            Dim oItem As cItemInvertedFreeHandArea = MyBase.CreateItem(cIItem.cItemTypeEnum.InvertedFreeHandArea, cIItem.cItemCategoryEnum.CaveBorder)
            oItem.Pen.Type = cPen.PenTypeEnum.PresumedCavePen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateTooNarrowCaveBorder(ByVal Cave As String, ByVal Branch As String) As cItemInvertedFreeHandArea
            Dim oItem As cItemInvertedFreeHandArea = MyBase.CreateItem(cIItem.cItemTypeEnum.InvertedFreeHandArea, cIItem.cItemCategoryEnum.CaveBorder)
            oItem.Pen.Type = cPen.PenTypeEnum.TooNarrowCavePen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateUnderlyingCaveBorder(ByVal Cave As String, ByVal Branch As String) As cItemInvertedFreeHandArea
            Dim oItem As cItemInvertedFreeHandArea = MyBase.CreateItem(cIItem.cItemTypeEnum.InvertedFreeHandArea, cIItem.cItemCategoryEnum.CaveBorder)
            oItem.Pen.Type = cPen.PenTypeEnum.UnderlyingCavePen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateBorder(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandLine
            Dim oItem As cItemFreeHandLine = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandLine, cIItem.cItemCategoryEnum.Border)
            oItem.Pen.Type = cPen.PenTypeEnum.Pen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreatePresumedBorder(ByVal Cave As String, ByVal Branch As String) As cItemFreeHandLine
            Dim oItem As cItemFreeHandLine = MyBase.CreateItem(cIItem.cItemTypeEnum.FreeHandLine, cIItem.cItemCategoryEnum.Border)
            oItem.Pen.Type = cPen.PenTypeEnum.PresumedPen
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

    End Class
End Namespace
