Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design.Layers
    Public Class cLayerSigns
        Inherits cLayer

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal File As Storage.cFile, ByVal Layer As XmlElement)
            MyBase.new(Survey, Design, File, Layer)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Name As String)
            MyBase.new(Survey, Design, Name, cLayers.LayerTypeEnum.Signs)
        End Sub

        Friend Sub AppenCrossSectionMarker(Marker As cIItemCrossSectionMarker)
            Call MyBase.Items.Add(Marker)
        End Sub

        Public Function CreateCrossSection(ByVal Cave As String, ByVal Branch As String, ByVal Segment As cSegment) As cItemCrossSection
            Dim oItem As cItemCrossSection = MyBase.CreateItem(cIItem.cItemTypeEnum.CrossSection, cIItem.cItemCategoryEnum.CrossSection, Segment)
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateSign(ByVal Cave As String, ByVal Branch As String, ByVal Data As Object, ByVal DataFormat As cItemSign.cItemSignDataFormatEnum) As cItemSign
            Dim oItem As cItemSign = MyBase.CreateItem(cIItem.cItemTypeEnum.Sign, cIItem.cItemCategoryEnum.Sign, Data, DataFormat)
            oItem.Pen.Type = cPen.PenTypeEnum.TightPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.SignSolid
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateText(ByVal Cave As String, ByVal Branch As String, ByVal Text As String) As cItemText
            Dim oItem As cItemText = MyBase.CreateItem(cIItem.cItemTypeEnum.Text, cIItem.cItemCategoryEnum.Text, Text)
            oItem.Pen.Type = cPen.PenTypeEnum.TightPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.SignSolid
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateGenericQuota(ByVal Cave As String, ByVal Branch As String, ByVal Text As String) As cItemQuota
            Dim oItem As cItemQuota = MyBase.CreateItem(cIItem.cItemTypeEnum.Quota, cIItem.cItemCategoryEnum.Quota, Text)
            oItem.Pen.Type = cPen.PenTypeEnum.TightPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.SignSolid
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateVerticalQuota(ByVal Cave As String, ByVal Branch As String, ByVal Text As String) As cItemQuota
            Dim oItem As cItemQuota = MyBase.CreateItem(cIItem.cItemTypeEnum.Quota, cIItem.cItemCategoryEnum.Quota, Text)
            oItem.Pen.Type = cPen.PenTypeEnum.TightPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.SignSolid
            oItem.QuotaType = cIItemQuota.QuotaTypeEnum.Vertical
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateHorizontalQuota(ByVal Cave As String, ByVal Branch As String, ByVal Text As String) As cItemQuota
            Dim oItem As cItemQuota = MyBase.CreateItem(cIItem.cItemTypeEnum.Quota, cIItem.cItemCategoryEnum.Quota, Text)
            oItem.Pen.Type = cPen.PenTypeEnum.TightPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.SignSolid
            oItem.QuotaType = cIItemQuota.QuotaTypeEnum.Horizontal
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateAltitudeQuota(ByVal Cave As String, ByVal Branch As String, ByVal Text As String) As cItemQuota
            Dim oItem As cItemQuota = MyBase.CreateItem(cIItem.cItemTypeEnum.Quota, cIItem.cItemCategoryEnum.Quota, Text)
            oItem.Pen.Type = cPen.PenTypeEnum.TightPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.SignSolid
            oItem.QuotaType = cIItemQuota.QuotaTypeEnum.Altitude
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateDropQuota(ByVal Cave As String, ByVal Branch As String, ByVal Text As String) As cItemQuota
            Dim oItem As cItemQuota = MyBase.CreateItem(cIItem.cItemTypeEnum.Quota, cIItem.cItemCategoryEnum.Quota, Text)
            oItem.Pen.Type = cPen.PenTypeEnum.TightPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.SignSolid
            oItem.QuotaType = cIItemQuota.QuotaTypeEnum.Drop
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateVerticalScaleQuota(ByVal Cave As String, ByVal Branch As String, ByVal Text As String) As cItemQuota
            Dim oItem As cItemQuota = MyBase.CreateItem(cIItem.cItemTypeEnum.Quota, cIItem.cItemCategoryEnum.Quota, Text)
            oItem.Pen.Type = cPen.PenTypeEnum.TightPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.SignSolid
            oItem.QuotaType = cIItemQuota.QuotaTypeEnum.VerticalScale
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateHorizontalScaleQuota(ByVal Cave As String, ByVal Branch As String, ByVal Text As String) As cItemQuota
            Dim oItem As cItemQuota = MyBase.CreateItem(cIItem.cItemTypeEnum.Quota, cIItem.cItemCategoryEnum.Quota, Text)
            oItem.Pen.Type = cPen.PenTypeEnum.TightPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.SignSolid
            oItem.QuotaType = cIItemQuota.QuotaTypeEnum.HorizontalScale
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateGridScaleQuota(ByVal Cave As String, ByVal Branch As String, ByVal Text As String) As cItemQuota
            Dim oItem As cItemQuota = MyBase.CreateItem(cIItem.cItemTypeEnum.Quota, cIItem.cItemCategoryEnum.Quota, Text)
            oItem.Pen.Type = cPen.PenTypeEnum.TightPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.SignSolid
            oItem.QuotaType = cIItemQuota.QuotaTypeEnum.GridScale
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function
    End Class
End Namespace
