Imports System.Xml
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Public Class cImportTopoDroidHelper
    Public Class cTopodroidVersion
        Private iMajor As Integer
        Private iMinor As Integer
        Private sRevision As String

        Public Overrides Function ToString() As String
            Return iMajor.ToString & "." & iMinor.ToString & "." & sRevision
        End Function

        Public Sub New(Version As String)
            Dim sParts As String() = Version.Split({"."c})
            iMajor = sParts(0)
            iMinor = sParts(1)
            sRevision = sParts(2)
        End Sub

        Shared Operator >(operand1 As cTopodroidVersion, operand2 As cTopodroidVersion) As Boolean
            Return operand1.iMajor > operand2.iMajor OrElse (operand1.iMajor = operand2.iMajor AndAlso operand1.iMinor > operand2.iMinor) OrElse (operand1.iMajor = operand2.iMajor AndAlso operand1.iMinor = operand2.iMinor AndAlso operand1.sRevision > operand2.sRevision)
        End Operator

        Shared Operator <(operand1 As cTopodroidVersion, operand2 As cTopodroidVersion) As Boolean
            Return operand1.iMajor < operand2.iMajor OrElse (operand1.iMajor = operand2.iMajor AndAlso operand1.iMinor < operand2.iMinor) OrElse (operand1.iMajor = operand2.iMajor AndAlso operand1.iMinor = operand2.iMinor AndAlso operand1.sRevision < operand2.sRevision)
        End Operator

        Public ReadOnly Property Revision As String
            Get
                Return sRevision
            End Get
        End Property

        Public ReadOnly Property Minor As Integer
            Get
                Return iMinor
            End Get
        End Property

        Public ReadOnly Property Major As Integer
            Get
                Return iMajor
            End Get
        End Property
    End Class

    Public Shared Function GetTopodroidVersion(Xml As XmlDocument) As cTopodroidVersion
        Return New cTopodroidVersion(Xml.Item("csurvey").Item("properties").GetAttribute("creatversion").ToString)
    End Function

    Public Shared Sub ConvertDesign(Survey As cSurvey.cSurvey, Layers As cLayers, Items As XmlElement)
        For Each oItem As XmlElement In Items.SelectNodes("item")
            Call cImportTopoDroidHelper.ConvertItem(Survey, Layers, oItem, cItem.BindDesignTypeEnum.MainDesign)
        Next
    End Sub

    Public Shared Sub ConvertCrossSection(Survey As cSurvey.cSurvey, Layers As cLayers, CrossSection As cDesignCrossSection, Items As XmlElement, Location As SizeF)
        For Each oItem As XmlElement In Items.SelectNodes("item")
            Call cImportTopoDroidHelper.ConvertItem(Survey, Layers, oItem, cItem.BindDesignTypeEnum.CrossSections, CrossSection, Location)
        Next
    End Sub

    Private Shared Sub pConvertItem(Survey As cSurvey.cSurvey, XMLItem As XmlElement, Item As cItem)
        Dim bReversed As Boolean = modXML.GetAttributeValue(XMLItem, "reversed", 0)
        If Not bReversed Then
            Call Item.Points.Revert()
        End If
        Dim bClosed As Boolean = modXML.GetAttributeValue(XMLItem, "closed", 0)
        If bClosed Then
            Call Item.Points.CloseSequences()
        End If
    End Sub

    Private Shared Sub pConvertSign(Survey As cSurvey.cSurvey, XMLItem As XmlElement, Item As cItem)
        Dim sOrientation As Single = modNumbers.StringToSingle(modXML.GetAttributeValue(XMLItem, "orientation", 0))
        If sOrientation <> 0 Then
            If TypeOf Item Is cIItemRotable Then
                DirectCast(Item, cIItemRotable).RotateMode = cIItemRotable.RotateModeEnum.Rotable
                Call Item.Rotate(sOrientation)
            End If
        End If
        Dim iScale As Integer = modNumbers.StringToInteger(modXML.GetAttributeValue(XMLItem, "scale", 0))
        If iScale <> 0 Then
            If TypeOf Item Is cIItemSizable Then
                DirectCast(Item, cIItemSizable).Size = pTopodroidscaleToSize(iScale)
            End If
        End If
    End Sub

    Private Shared Function pTopodroidscaleToSize(Scale As Integer) As cIItemSizable.SizeEnum
        Select Case Scale
            Case -2
                Return cIItemSizable.SizeEnum.VerySmall
            Case -1
                Return cIItemSizable.SizeEnum.Small
            Case 0
                Return cIItemSizable.SizeEnum.Medium
            Case 1
                Return cIItemSizable.SizeEnum.Large
            Case 2
                Return cIItemSizable.SizeEnum.VeryLarge
            Case Else
                Return cIItemSizable.SizeEnum.Default
        End Select
    End Function

    Public Shared Function ConvertItem(Survey As cSurvey.cSurvey, Layers As cLayers, XMLItem As XmlElement, BindDesignType As cItem.BindDesignTypeEnum, Optional CrossSection As cDesignCrossSection = Nothing, Optional Location As SizeF = Nothing) As cItem
        Dim sCave As String = XMLItem.GetAttribute("cave")
        Dim sBranch As String = XMLItem.GetAttribute("branch")
        Dim sType As String = XMLItem.GetAttribute("type").ToLower
        Dim sName As String = XMLItem.GetAttribute("name").ToLower
        Select Case sType
            Case "line"
                Select Case sName
                    Case "water-flow"
                        'csurvey has no water flow element
                        Dim oItem As cItemFreeHandLine = Layers.WaterAndFloorMorphologiesLayer.CreateBorder(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        oItem.Pen.Color = Drawing.Color.Blue
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        Call pConvertItem(Survey, XMLItem, oItem)
                        Return oItem

                        'this way is more usefull...but give ugly result
                        'Dim oBaseItem As cItemFreeHandLine = Layers.WaterAndFloorMorphologiesLayer.CreateBorder(sCave, sBranch)
                        'Call oBaseItem.SetBindDesignType(BindDesignType, CrossSection)
                        'oBaseItem.LineType = cIItemLine.LineTypeEnum.Lines
                        'Call oBaseItem.Points.Parse(XMLItem.Item("points"))
                        'If Not Location.IsEmpty Then oBaseItem.MoveBy(Location)
                        'Call pConvertItem(Survey, XMLItem, oBaseItem)

                        'Dim oNewSequence As cSequence = modPaint.WidenSequence(oBaseItem, oBaseItem.Points.First, 0.1, 0.1)
                        'Dim oItem As cItemFreeHandArea = Layers.WaterAndFloorMorphologiesLayer.CreateWaterArea(sCave, sBranch)
                        'Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        'oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        'Call oItem.Points.AddRange(oNewSequence)
                        'If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        'Call pConvertItem(Survey, XMLItem, oItem)

                        'Call Layers.WaterAndFloorMorphologiesLayer.Items.Remove(oBaseItem)
                        'Return oItem
                    Case "rock-border"
                        Dim oItem As cItemFreeHandArea = Layers.RocksAndConcretionLayer.CreateRockArea(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        Call pConvertItem(Survey, XMLItem, oItem)
                        Return oItem
                    Case "wall:presumed"
                        Dim oItem As cItemInvertedFreeHandArea = Layers.BordersLayer.CreatePresumedCaveBorder(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        Call pConvertItem(Survey, XMLItem, oItem)
                        Return oItem
                    Case "overhang"
                        Dim oItem As cItemFreeHandLine = Layers.WaterAndFloorMorphologiesLayer.CreateOverhangCurve(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        Call pConvertItem(Survey, XMLItem, oItem)
                        Return oItem
                    Case "wall"
                        Dim iOutline As Integer = modXML.GetAttributeValue(XMLItem, "outline", 1)
                        If iOutline = 1 OrElse iOutline = -1 Then
                            Dim oItem As cItemInvertedFreeHandArea = Layers.BordersLayer.CreateCaveBorder(sCave, sBranch)
                            Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                            oItem.LineType = cIItemLine.LineTypeEnum.Lines
                            Call oItem.Points.Parse(XMLItem.Item("points"))
                            If Not Location.IsEmpty Then oItem.MoveBy(Location)
                            Call pConvertItem(Survey, XMLItem, oItem)
                            If iOutline = -1 Then oItem.MergeMode = cIItemMergeableArea.MergeModeEnum.Subtract
                            Return oItem
                        Else
                            Dim oItem As cItemFreeHandLine = Layers.BordersLayer.CreateBorder(sCave, sBranch)
                            Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                            oItem.LineType = cIItemLine.LineTypeEnum.Lines
                            Call oItem.Points.Parse(XMLItem.Item("points"))
                            If Not Location.IsEmpty Then oItem.MoveBy(Location)
                            Call pConvertItem(Survey, XMLItem, oItem)
                            Return oItem
                        End If
                    Case "presumed"
                        Dim oItem As cItemFreeHandLine = Layers.BordersLayer.CreatePresumedBorder(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        Call pConvertItem(Survey, XMLItem, oItem)
                        Return oItem
                    Case "pit"
                        Dim oItem As cItemFreeHandLine = Layers.WaterAndFloorMorphologiesLayer.CreateCliffCurve(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        Call pConvertItem(Survey, XMLItem, oItem)
                        'Call oItem.Points.Revert()
                        Return oItem
                    Case "chimney"
                        Dim oItem As cItemFreeHandLine = Layers.CeilingMorphologiesLayer.CreateCeilingCliffCurve(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        Call pConvertItem(Survey, XMLItem, oItem)
                        Return oItem
                    Case "slope"
                        Dim oItem As cItemFreeHandLine = Layers.WaterAndFloorMorphologiesLayer.CreateLevelCurve(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        Call pConvertItem(Survey, XMLItem, oItem)
                        Return oItem
                    Case "section"
                        'this is not correct: the equivalent object in csurvey is crosssection reference but topodroid put this object before xsection and, more, csurvey crosssection reference have 
                        'to be placed on percentage relative to a shot. It's possibile to do this but, for now, I follow a more simple solution...
                        Dim oItem As cItemFreeHandLine = Layers.WaterAndFloorMorphologiesLayer.CreatePresumedBorder(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        oItem.Name = "xsection " & modXML.GetAttributeValue(XMLItem, "options", "")
                        Call pConvertItem(Survey, XMLItem, oItem)
                        Return oItem

                    Case "floor-meander"
                        Dim oItem As cItemFreeHandLine = Layers.WaterAndFloorMorphologiesLayer.CreateMeander(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        Call pConvertItem(Survey, XMLItem, oItem)
                        Return oItem
                    Case "ceiling-meander"
                        Dim oItem As cItemFreeHandLine = Layers.CeilingMorphologiesLayer.CreateCeilingMeander(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        Call pConvertItem(Survey, XMLItem, oItem)
                        Return oItem
                    Case "border"
                        Dim oItem As cItemFreeHandLine = Layers.BordersLayer.CreateBorder(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        Call pConvertItem(Survey, XMLItem, oItem)
                        Return oItem

                    Case Else
                        Dim oItem As cItemFreeHandLine = Layers.BordersLayer.CreateBorder(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        Call pConvertItem(Survey, XMLItem, oItem)
                        Return oItem
                End Select
            Case "area"
                Select Case sName
                    Case "water"
                        Dim oItem As cItemFreeHandArea = Layers.WaterAndFloorMorphologiesLayer.CreateWaterArea(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        Call pConvertItem(Survey, XMLItem, oItem)
                        Return oItem
                    Case "sand"
                        Dim oItem As cItemFreeHandArea = Layers.SoilLayer.CreateSandSoil(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        Call pConvertItem(Survey, XMLItem, oItem)
                        Return oItem
                    Case "debris"
                        Dim oItem As cItemFreeHandArea = Layers.SoilLayer.CreateSmallDebritsSoil(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        Call pConvertItem(Survey, XMLItem, oItem)
                        Return oItem
                    Case "blocks"
                        Dim oItem As cItemFreeHandArea = Layers.SoilLayer.CreateBigDebritsSoil(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        Call pConvertItem(Survey, XMLItem, oItem)
                        Return oItem
                    Case "pebbles"
                        Dim oItem As cItemFreeHandArea = Layers.SoilLayer.CreatePebblesSoil(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        Call pConvertItem(Survey, XMLItem, oItem)
                        Return oItem
                    Case "clay"
                        Dim oItem As cItemFreeHandArea = Layers.SoilLayer.CreateSandSoil(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        Call pConvertItem(Survey, XMLItem, oItem)
                        Return oItem

                    Case Else
                        Dim oItem As cItemFreeHandArea = Layers.SoilLayer.CreateSoil(sCave, sBranch)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        oItem.LineType = cIItemLine.LineTypeEnum.Lines
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        Call pConvertItem(Survey, XMLItem, oItem)
                        Return oItem
                End Select
            Case "point"
                Select Case sName
                    Case "water-flow", "air-draught"
                        Dim sOrientation As Single = modNumbers.StringToSingle(modXML.GetAttributeValue(XMLItem, "orientation", 0))
                        XMLItem.SetAttribute("orientation", sOrientation + 90)
                End Select

                Select Case sName
'                    Case "audio"
''    'Dim oItem As cItemAttachment = Layers.SignsLayer.CreateAttachment(sCave, sBranch, )
''    'Return oItem
'                    Case "photo"
'                        '    'Dim oItem As cItemAttachment = Layers.SignsLayer.CreateAttachment(sCave, sBranch, )
'                        '    'Return oItem
                    Case "label"
                        Dim sText As String = modXML.GetAttributeValue(XMLItem, "text", "")
                        Dim oItem As cItemText = Layers.SignsLayer.CreateText(sCave, sBranch, sText)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        If Not Location.IsEmpty Then oItem.MoveBy(Location)
                        Call pConvertSign(Survey, XMLItem, oItem)
                        Return oItem
                    Case "section"
                        Dim sStationFrom As String = modXML.GetAttributeValue(XMLItem, "stationfrom", "")
                        Dim sStationTo As String = modXML.GetAttributeValue(XMLItem, "stationto", "")
                        Dim oSegment As cSegment = Nothing
                        If sStationFrom <> "" AndAlso sStationTo <> "" Then
                            oSegment = Survey.Segments.Find(sStationFrom, sStationTo, True)
                        End If
                        Dim oItem As cItemCrossSection = Layers.SignsLayer.CreateCrossSection(sCave, sBranch, oSegment)
                        Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                        Call oItem.Points.Parse(XMLItem.Item("points"))
                        Call pConvertSign(Survey, XMLItem, oItem)
                        oItem.Name = modXML.GetAttributeValue(XMLItem, "sectionname", "")
                        oItem.Text = modXML.GetAttributeValue(XMLItem, "sectiontext", "")

                        Call ConvertCrossSection(Survey, Layers, oItem.DesignCrossSection, XMLItem.Item("crosssection"), New SizeF(0, 0)) ' New SizeF(oItem.Points(0).Point.X, oItem.Points(0).Point.Y))

                        If modXML.ChildElementExist(XMLItem, "crosssectionfile") Then
                            Dim oXMLFile As XmlElement = XMLItem.Item("crosssectionfile")
                            Dim oData As Byte() = Convert.FromBase64String(oXMLFile.Item("attachment").GetAttribute("data"))
                            Dim iDataFormat As Integer = oXMLFile.Item("attachment").GetAttribute("dataformat")
                            Dim sMimeType As String = oXMLFile.Item("attachment").GetAttribute("type")
                            Dim oAttachment As cAttachment = Survey.Attachments.Add(sMimeType, oData, "", "")
                            Dim oAttachmentItem As cItemAttachment = Layers.SignsLayer.CreateAttachment(sCave, sBranch, oAttachment.ID, cAttachmentsLinks.cAttachmentDataFormatEnum.Resource)
                            Call oAttachmentItem.SetBindDesignType(BindDesignType, CrossSection)
                            Call oAttachmentItem.Points.Parse(XMLItem.Item("points"))
                        End If

                        Return oItem
                    Case Else
                        Dim iItemType As cIItemSign.SignEnum
                        If System.Enum.TryParse(Of cIItemSign.SignEnum)(sName.Replace("-", "").Replace("_", ""), True, iItemType) Then
                            Dim oItem As cItemSign = Layers.SignsLayer.CreateSign(sCave, sBranch, iItemType)
                            Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                            Call oItem.Points.Parse(XMLItem.Item("points"))
                            If Not Location.IsEmpty Then oItem.MoveBy(Location)
                            oItem.Sign = iItemType
                            Call pConvertSign(Survey, XMLItem, oItem)
                            Return oItem
                        Else
                            'point not recognized in csurvey enum...
                            Dim oItem As cItemSign = Layers.SignsLayer.CreateSign(sCave, sBranch, cIItemSign.SignEnum.Undefined)
                            Call oItem.SetBindDesignType(BindDesignType, CrossSection)
                            Call oItem.Points.Parse(XMLItem.Item("points"))
                            If Not Location.IsEmpty Then oItem.MoveBy(Location)
                            Call pConvertSign(Survey, XMLItem, oItem)
                            Return oItem
                        End If
                End Select
        End Select
    End Function

End Class
