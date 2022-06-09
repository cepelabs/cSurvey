Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design.Layers
    Public Class cLayerSigns
        Inherits cLayer

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal File As cFile, ByVal Layer As XmlElement)
            MyBase.new(Survey, Design, File, Layer)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Name As String)
            MyBase.new(Survey, Design, Name, cLayers.LayerTypeEnum.Signs)
        End Sub

        Friend Sub CreateCrossSectionMarker(Marker As cIItemCrossSectionMarker)
            Call MyBase.Items.Add(Marker)
        End Sub

        Public Function CreateCrossSection(ByVal Cave As String, ByVal Branch As String, ByVal Segment As cSegment) As cItemCrossSection
            Dim oItem As cItemCrossSection = MyBase.CreateItem(cIItem.cItemTypeEnum.CrossSection, cIItem.cItemCategoryEnum.CrossSection, Segment)
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateAttachment(ByVal Cave As String, ByVal Branch As String, ByVal Data As Object, ByVal DataFormat As cAttachmentsLinks.cAttachmentDataFormatEnum) As cItemAttachment
            Dim oItem As cItemAttachment = MyBase.CreateItem(cIItem.cItemTypeEnum.Attachment, cIItem.cItemCategoryEnum.Sign, Data, DataFormat)
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateSign(ByVal Cave As String, ByVal Branch As String, Sign As cIItemSign.SignEnum) As cItemSign
            Dim oItem As cItemSign
            If Sign = cIItemSign.SignEnum.Undefined Then
                oItem = MyBase.CreateItem(cIItem.cItemTypeEnum.Sign, cIItem.cItemCategoryEnum.Sign, My.Resources.clipart_error, cIItemClipartBase.cClipartDataFormatEnum.SVGData)
            Else
                Dim oData As cClipartPlaceholder = cClipartHelper.FindByAttribute(cClipartHelper.GetGallery("signs"), "sign", Sign.ToString("D")).FirstOrDefault
                If oData Is Nothing Then
                    oItem = MyBase.CreateItem(cIItem.cItemTypeEnum.Sign, cIItem.cItemCategoryEnum.Sign, My.Resources.clipart_error, cIItemClipartBase.cClipartDataFormatEnum.SVGData)
                Else
                    oItem = MyBase.CreateItem(cIItem.cItemTypeEnum.Sign, cIItem.cItemCategoryEnum.Sign, oData.Filename, cIItemClipartBase.cClipartDataFormatEnum.SVGFile)
                End If
            End If
            oItem.Pen.Type = cPen.PenTypeEnum.TightPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.SignSolid
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateSign(ByVal Cave As String, ByVal Branch As String, ByVal Data As Object, ByVal DataFormat As cIItemClipartBase.cClipartDataFormatEnum) As cItemSign
            Dim oItem As cItemSign = MyBase.CreateItem(cIItem.cItemTypeEnum.Sign, cIItem.cItemCategoryEnum.Sign, Data, DataFormat)
            oItem.Pen.Type = cPen.PenTypeEnum.TightPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.SignSolid
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateInformationBoxText(ByVal Cave As String, ByVal Branch As String) As cItemInformationBoxText
            Dim oItem As cItemInformationBoxText = MyBase.CreateItem(cIItem.cItemTypeEnum.InformationBoxText, cIItem.cItemCategoryEnum.Text)
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

        Public Function CreateScale(ByVal Cave As String, ByVal Branch As String) As cItemScale
            Dim oItem As cItemScale = MyBase.CreateItem(cIItem.cItemTypeEnum.Scale, cIItem.cItemCategoryEnum.Sign, "")
            oItem.Pen.Type = cPen.PenTypeEnum.TightPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.SignSolid
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateLegend(ByVal Cave As String, ByVal Branch As String, ByVal Text As String) As cItemLegend
            Dim oItem As cItemLegend = MyBase.CreateItem(cIItem.cItemTypeEnum.Legend, cIItem.cItemCategoryEnum.Sign, Text)
            oItem.Pen.Type = cPen.PenTypeEnum.TightPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.SignSolid
            Call oItem.SetCave(Cave, Branch)
            Call oItem.AutoFill(False, cIItemLegend.AutoFillFlagsEnum.None)
            Return oItem
        End Function

        Public Function CreateImage(ByVal Cave As String, ByVal Branch As String, ByVal Image As Image) As cItemImage
            Dim oItem As cItemImage = MyBase.CreateItem(cIItem.cItemTypeEnum.Image, cIItem.cItemCategoryEnum.LogoImage, Image)
            Call oItem.SetCave(Cave, Branch)
            oItem.DesignAffinity = cItem.DesignAffinityEnum.Extra
            Return oItem
        End Function
        Public Function CreateCompass(ByVal Cave As String, ByVal Branch As String, ByVal Data As Object, ByVal DataFormat As cIItemClipartBase.cClipartDataFormatEnum) As cItemCompass
            Dim oItem As cItemCompass = MyBase.CreateItem(cIItem.cItemTypeEnum.Compass, cIItem.cItemCategoryEnum.Compass, Data, DataFormat)
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

        Public Function CreateObliqueQuota(ByVal Cave As String, ByVal Branch As String, ByVal Text As String) As cItemQuota
            Dim oItem As cItemQuota = MyBase.CreateItem(cIItem.cItemTypeEnum.Quota, cIItem.cItemCategoryEnum.Quota, Text)
            oItem.Pen.Type = cPen.PenTypeEnum.TightPen
            oItem.Brush.Type = cBrush.BrushTypeEnum.SignSolid
            oItem.QuotaType = cIItemQuota.QuotaTypeEnum.Oblique
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
