Imports System.Xml
Imports System.IO
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Drawings
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Text.RegularExpressions
Imports Diacritics.Extensions
Imports BrightIdeasSoftware

Module modExport
    Public Sub CreateStationDictionary(TrigPointsToElaborate As List(Of String), KeyToExclude As List(Of Integer), ByRef InputDictionary As Dictionary(Of String, String), ByRef OutputDictionary As Dictionary(Of String, String))
        ''---------------------------------------------------------------------------------------------------------
        'InputDictionary = New Dictionary(Of String, String)
        'OutputDictionary = New Dictionary(Of String, String)

        'Dim iIndex As Integer = 0
        'For Each sTrigPoint As String In TrigPointsToElaborate
        '    Call InputDictionary.Add(sTrigPoint, iIndex.ToString)
        '    Call OutputDictionary.Add(iIndex.ToString, sTrigPoint)
        '    iIndex += 1
        'Next

        InputDictionary = New Dictionary(Of String, String)
        OutputDictionary = New Dictionary(Of String, String)
        Dim iIndex As Integer = 0
        For Each sTrigPoint As String In TrigPointsToElaborate
            Do While KeyToExclude.Contains(iIndex)
                iIndex += 1
            Loop
            Call InputDictionary.Add(sTrigPoint, iIndex)
            Call OutputDictionary.Add(iIndex, sTrigPoint)
            iIndex += 1
        Next
    End Sub

    Public Function GetTherionDepthType(Type As cSegment.DepthTypeEnum) As String
        Select Case Type
            Case cSegment.DepthTypeEnum.AbsoluteAtBegin
                Return "fromdepth"
            Case cSegment.DepthTypeEnum.AbsoluteAtEnd
                Return "todepth"
            Case cSegment.DepthTypeEnum.Difference
                Return "depthchange"
        End Select
    End Function

    Public Function GetTherionDepthUnit(Unit As cSegment.DistanceTypeEnum) As String
        Select Case Unit
            Case cSegment.DistanceTypeEnum.Meters
                Return "metres"
            Case cSegment.DistanceTypeEnum.Feet
                Return "feet"
            Case cSegment.DistanceTypeEnum.Yards
                Return "yards"
        End Select
    End Function

    Public Function GetTherionDistanceUnit(Unit As cSegment.DistanceTypeEnum) As String
        Select Case Unit
            Case cSegment.DistanceTypeEnum.Meters
                Return "metres"
            Case cSegment.DistanceTypeEnum.Feet
                Return "feet"
            Case cSegment.DistanceTypeEnum.Yards
                Return "yards"
        End Select
    End Function

    Public Function GetTherionBearingUnit(Unit As cSegment.BearingTypeEnum) As String
        Select Case Unit
            Case cSegment.BearingTypeEnum.DecimalDegree
                Return "degrees"
            Case cSegment.BearingTypeEnum.CentesimalDegree
                Return "grad"
        End Select
    End Function

    Public Function GetTherionInclinationUnit(Unit As cSegment.InclinationTypeEnum) As String
        Select Case Unit
            Case cSegment.InclinationTypeEnum.DecimalDegree
                Return "degrees"
            Case cSegment.InclinationTypeEnum.CentesimalDegree
                Return "grad"
            Case cSegment.InclinationTypeEnum.Percentage
                Return "percent"
        End Select
    End Function

    'Public Sub GoogleKmlAppendStyleMap(ByVal XML As XmlDocument, ByVal parent As XmlElement, ByVal ID As String, ByVal Normal As String, ByVal Highlight As String)
    '    Dim xmlNode As XmlElement = XML.CreateElement("StyleMap")
    '    xmlNode.SetAttribute("id", ID)
    '    Dim xmlNodeStyle As XmlElement
    '    xmlNodeStyle = XML.CreateElement("Pair")
    '    Call GoogleKmlAppendNode(XML, xmlNodeStyle, "key", "normal")
    '    Call GoogleKmlAppendNode(XML, xmlNodeStyle, "styleURL", "#" & Normal)
    '    Call xmlNode.AppendChild(xmlNodeStyle)
    '    xmlNodeStyle = XML.CreateElement("Pair")
    '    Call GoogleKmlAppendNode(XML, xmlNodeStyle, "key", "highlight")
    '    Call GoogleKmlAppendNode(XML, xmlNodeStyle, "styleURL", "#" & Highlight)
    '    Call xmlNode.AppendChild(xmlNodeStyle)
    '    Call parent.AppendChild(xmlNode)
    'End Sub

    Public Sub GoogleKmlAppendIconStyle(ByVal XML As XmlDocument, ByVal parent As XmlElement, ByVal ID As String, ByVal LabelScale As String, ByVal Icon As String, ByVal IconScale As String)
        Dim xmlNode As XmlElement = XML.CreateElement("Style")
        xmlNode.SetAttribute("id", ID)
        If LabelScale <> "" Then
            Dim xmlLabelStyle As XmlElement = XML.CreateElement("LabelStyle")
            Call GoogleKmlAppendNode(XML, xmlLabelStyle, "scale", LabelScale)
            Call xmlNode.AppendChild(xmlLabelStyle)
        End If
        If IconScale <> "" AndAlso Icon <> "" Then
            Dim xmlIconStyle As XmlElement = XML.CreateElement("IconStyle")
            If IconScale <> "" Then
                Call GoogleKmlAppendNode(XML, xmlIconStyle, "scale", IconScale)
            End If
            Dim xmlIconStyleIcon As XmlElement = XML.CreateElement("Icon")
            Call GoogleKmlAppendNode(XML, xmlIconStyleIcon, "href", Icon)
            Call xmlIconStyle.AppendChild(xmlIconStyleIcon)
            Call xmlNode.AppendChild(xmlIconStyle)
        End If
        Call parent.AppendChild(xmlNode)
    End Sub

    Public Sub GoogleKmlAppendLineStyle(ByVal XML As XmlDocument, ByVal parent As XmlElement, ByVal ID As String, ByVal Color As String, ByVal Width As String)
        Dim xmlNode As XmlElement = XML.CreateElement("Style")
        xmlNode.SetAttribute("id", ID)
        Dim xmlNodeStyle As XmlElement = XML.CreateElement("LineStyle")
        Call GoogleKmlAppendNode(XML, xmlNodeStyle, "color", Color)
        Call GoogleKmlAppendNode(XML, xmlNodeStyle, "width", Width)
        Call xmlNode.AppendChild(xmlNodeStyle)
        Call parent.AppendChild(xmlNode)
    End Sub

    Public Sub GoogleKmlAppendPoligonStyle(ByVal XML As XmlDocument, ByVal parent As XmlElement, ByVal ID As String, ByVal BorderColor As String, ByVal BorderWidth As String, FillerColor As String)
        Dim xmlNode As XmlElement = XML.CreateElement("Style")
        xmlNode.SetAttribute("id", ID)
        If Not BorderColor Is Nothing Then
            Dim xmlNodeStyle As XmlElement = XML.CreateElement("LineStyle")
            Call GoogleKmlAppendNode(XML, xmlNodeStyle, "color", BorderColor)
            Call GoogleKmlAppendNode(XML, xmlNodeStyle, "width", BorderWidth)
            Call xmlNode.AppendChild(xmlNodeStyle)
        End If
        If Not FillerColor Is Nothing Then
            Dim xmlNodeStyle As XmlElement = XML.CreateElement("PolyStyle")
            Call GoogleKmlAppendNode(XML, xmlNodeStyle, "color", FillerColor)
            If BorderColor Is Nothing Then
                Call GoogleKmlAppendNode(XML, xmlNodeStyle, "outline", "0")
            End If
            Call xmlNode.AppendChild(xmlNodeStyle)
        End If
        Call parent.AppendChild(xmlNode)
    End Sub

    Public Sub GoogleKmlAppendNode(ByVal XML As XmlDocument, ByVal parent As XmlElement, ByVal NodeName As String, ByVal NodeText As String)
        Dim xmlNode As XmlElement = XML.CreateElement(NodeName)
        xmlNode.InnerText = NodeText
        Call parent.AppendChild(xmlNode)
    End Sub

    Public Sub GoogleKmlOverlayExportTo(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal ImageFilename As String, ByVal [TopLeftLat] As Decimal, ByVal [TopLeftLong] As Decimal, ByVal [BottomRightLat] As Decimal, ByVal [BottomRightLong] As Decimal)
        Dim sFilename As String = IO.Path.GetFileNameWithoutExtension(ImageFilename) & ".kml"
        Dim sTempFilename As String = IO.Path.Combine(IO.Path.GetDirectoryName(ImageFilename), sFilename)

        Dim xml As XmlDocument = New XmlDocument
        Dim xmlRoot As XmlElement = xml.CreateElement("kml")
        Dim xmlGroundOverlay As XmlElement = xml.CreateElement("GroundOverlay")
        Call GoogleKmlAppendNode(xml, xmlGroundOverlay, "name", Survey.Name)
        Dim xmlIcon As XmlElement = xml.CreateElement("Icon")
        Call GoogleKmlAppendNode(xml, xmlIcon, "href", IO.Path.GetFileName(ImageFilename))
        Call GoogleKmlAppendNode(xml, xmlIcon, "viewBoundScale", "1")
        Call xmlGroundOverlay.AppendChild(xmlIcon)

        Dim xmlLatLonBox As XmlElement = xml.CreateElement("LatLonBox")
        Call GoogleKmlAppendNode(xml, xmlLatLonBox, "north", modNumbers.NumberToString(TopLeftLat, ""))
        Call GoogleKmlAppendNode(xml, xmlLatLonBox, "south", modNumbers.NumberToString(BottomRightLat, ""))
        Call GoogleKmlAppendNode(xml, xmlLatLonBox, "west", modNumbers.NumberToString(TopLeftLong, ""))
        Call GoogleKmlAppendNode(xml, xmlLatLonBox, "east", modNumbers.NumberToString(BottomRightLong, ""))
        Call xmlGroundOverlay.AppendChild(xmlLatLonBox)
        Call xml.AppendChild(xmlGroundOverlay)
        Call XMLAddDeclaration(xml)
        Call xml.Save(sTempFilename)
    End Sub

    Public Function FormatCaveBranchNameForSVG(ByVal Cave As String, ByVal Branch As String) As String
        Return UnAccent(FormatCaveBranchName(Cave, Branch).Replace("\\", "_"))
    End Function

    Public Function FormatCaveBranchName(ByVal Cave As String, ByVal Branch As String) As String
        Dim sKey As String = Cave & If(Branch = "", "", cCaveInfoBranches.sBranchSeparator & Branch)
        sKey = sKey.ToLower
        sKey = sKey.Replace("\", "\\")
        sKey = sKey.Replace(" ", "_")
        sKey = sKey.Replace("/", "")
        sKey = sKey.Replace(")", "")
        sKey = sKey.Replace("(", "")
        Return sKey
    End Function

    Public Sub XMLAddDeclaration(XML As XmlDocument)
        If Not XML.FirstChild.NodeType = XmlNodeType.XmlDeclaration Then
            Dim oXMLDecl As XmlDeclaration = XML.CreateXmlDeclaration("1.0", "UTF-8", "yes")
            Dim oRoot As XmlElement = XML.DocumentElement
            Call XML.InsertBefore(oXMLDecl, oRoot)
        End If
    End Sub

    Public Sub GoogleKmlExportToPoint(Survey As cSurveyPC.cSurvey.cSurvey, Trigpoint As cTrigPoint, Filename As String)
        Dim xml As XmlDocument = New XmlDocument
        Dim xmlRoot As XmlElement = xml.CreateElement("kml")
        Dim xmlDocument As XmlElement = xml.CreateElement("Document")
        Call modExport.GoogleKmlAppendNode(xml, xmlDocument, "name", Survey.Name)

        Call modExport.GoogleKmlAppendIconStyle(xml, xmlDocument, "entrance", "1", "http://maps.google.com/mapfiles/kml/pushpin/red-pushpin.png", "1")

        Dim xmlPlacemark As XmlElement = xml.CreateElement("Placemark")
        Call GoogleKmlAppendNode(xml, xmlPlacemark, "name", Trigpoint.Name)
        Call GoogleKmlAppendNode(xml, xmlPlacemark, "visibility", "1")

        Dim xmlPoint As XmlElement = xml.CreateElement("Point")
        Dim sCoordinates As String = ""
        Dim oPoint As Calculate.cTrigPoint = Survey.Calculate.TrigPoints(Trigpoint)
        sCoordinates = sCoordinates & modNumbers.NumberToString(oPoint.Coordinate.Longitude, DefaultCoordinateFormat) & "," & modNumbers.NumberToString(oPoint.Coordinate.Latitude, DefaultCoordinateFormat) & "," & modNumbers.NumberToString(oPoint.Coordinate.Altitude, DefaultAltitudeFormat) & vbCrLf
        Call GoogleKmlAppendNode(xml, xmlPoint, "coordinates", sCoordinates)
        Call xmlPlacemark.AppendChild(xmlPoint)

        Call GoogleKmlAppendNode(xml, xmlPlacemark, "styleUrl", "#entrance")

        Call xmlDocument.AppendChild(xmlPlacemark)

        Call xmlRoot.AppendChild(xmlDocument)
        Call xml.AppendChild(xmlRoot)
        Call XMLAddDeclaration(xml)
        Call xml.Save(Filename)
    End Sub

    Public Sub GoogleKmlAppendDocumentDetails(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Xml As XmlDocument, Parent As XmlElement, Options As GoogleKMLExportOptionsEnum, Optional BorderTransparency As Single = 0)
        Dim bUseCadastralIDInCaveNames As Boolean = (Options And GoogleKMLExportOptionsEnum.UseCadastralIDInCaveNames) = GoogleKMLExportOptionsEnum.UseCadastralIDInCaveNames

        If (Options And GoogleKMLExportOptionsEnum.Waypoint) = GoogleKMLExportOptionsEnum.Waypoint Then
            Dim xmlFolderStations As XmlElement = Xml.CreateElement("Folder")
            Call GoogleKmlAppendNode(Xml, xmlFolderStations, "name", modMain.GetLocalizedString("export.textpart1"))

            Dim xmlFolderStationsGeneric As XmlElement = Xml.CreateElement("Folder")
            Call GoogleKmlAppendNode(Xml, xmlFolderStationsGeneric, "name", modMain.GetLocalizedString("export.textpart2"))
            Call GoogleKmlAppendNode(Xml, xmlFolderStationsGeneric, "visibility", "0")

            Dim xmlFolderStationsEntrances As XmlElement = Xml.CreateElement("Folder")
            Call GoogleKmlAppendNode(Xml, xmlFolderStationsEntrances, "name", modMain.GetLocalizedString("export.textpart3"))

            Dim xmlFolderStationsSplay As XmlElement = Xml.CreateElement("Folder")
            Call GoogleKmlAppendNode(Xml, xmlFolderStationsSplay, "name", modMain.GetLocalizedString("export.textpart4"))
            Call GoogleKmlAppendNode(Xml, xmlFolderStationsSplay, "visibility", "0")

            For Each oTrigpoint As cTrigPoint In Survey.Segments.GetTrigPoints
                If Survey.Calculate.TrigPoints.Contains(oTrigpoint) Then
                    If Not oTrigpoint.IsSystem Then
                        Dim xmlPlacemark As XmlElement = Xml.CreateElement("Placemark")
                        Call GoogleKmlAppendNode(Xml, xmlPlacemark, "name", oTrigpoint.Name)
                        Call GoogleKmlAppendNode(Xml, xmlPlacemark, "visibility", "0")

                        Dim xmlPoint As XmlElement = Xml.CreateElement("Point")
                        Dim oPoint As Calculate.cTrigPoint = Survey.Calculate.TrigPoints(oTrigpoint)
                        Dim sCoordinates As String = modNumbers.NumberToString(oPoint.Coordinate.Longitude, DefaultCoordinateFormat) & "," & modNumbers.NumberToString(oPoint.Coordinate.Latitude, DefaultCoordinateFormat) & "," & modNumbers.NumberToString(oPoint.Coordinate.Altitude, DefaultAltitudeFormat)
                        Call GoogleKmlAppendNode(Xml, xmlPoint, "coordinates", sCoordinates)
                        Call xmlPlacemark.AppendChild(xmlPoint)

                        If oTrigpoint.Data.IsSplay Then
                            Call GoogleKmlAppendNode(Xml, xmlPlacemark, "styleUrl", "#splay")
                            Call xmlFolderStationsSplay.AppendChild(xmlPlacemark)
                        Else
                            If oTrigpoint.Entrance <> cTrigPoint.EntranceTypeEnum.None Then
                                Call GoogleKmlAppendNode(Xml, xmlPlacemark, "styleUrl", "#entrance")
                                Call xmlFolderStationsEntrances.AppendChild(xmlPlacemark)
                            Else
                                Call GoogleKmlAppendNode(Xml, xmlPlacemark, "styleUrl", "#station")
                                Call xmlFolderStationsGeneric.AppendChild(xmlPlacemark)
                            End If
                        End If
                    End If
                End If
            Next
            Call xmlFolderStations.AppendChild(xmlFolderStationsGeneric)
            Call xmlFolderStations.AppendChild(xmlFolderStationsEntrances)
            Call xmlFolderStations.AppendChild(xmlFolderStationsSplay)
            Call Parent.AppendChild(xmlFolderStations)
        End If

        If (Options And GoogleKMLExportOptionsEnum.Track) = GoogleKMLExportOptionsEnum.Track Then
            Dim xmlFolderCenterlines As XmlElement = Xml.CreateElement("Folder")
            Call GoogleKmlAppendNode(Xml, xmlFolderCenterlines, "name", modMain.GetLocalizedString("export.textpart5"))

            Dim xmlFolderCenterlinesGeneric As XmlElement = Xml.CreateElement("Folder")
            Call GoogleKmlAppendNode(Xml, xmlFolderCenterlinesGeneric, "name", modMain.GetLocalizedString("export.textpart6"))
            For Each oCave As cCaveInfo In Survey.Properties.CaveInfos.GetWithEmpty.Values
                Dim xmlFolderCenterline As XmlElement = Xml.CreateElement("Folder")
                Call GoogleKmlAppendNode(Xml, xmlFolderCenterline, "name", If(bUseCadastralIDInCaveNames AndAlso oCave.ID <> "", oCave.ID & " - ", "") & oCave.Name)
                For Each oBranch As cCaveInfoBranch In oCave.Branches.GetAllBranchesWithEmpty.Values
                    Dim oSegments As cISegmentCollection = oBranch.GetSegments(cOptionsDesign.HighlightModeEnum.ExactMatch)
                    If oSegments.Count > 0 Then
                        Dim oColor As Color = oBranch.GetColor(Color.White)
                        Dim sMainLineStyle As String = "line_" & FormatCaveBranchName(oCave.Name, oBranch.Path)
                        Call modExport.GoogleKmlAppendLineStyle(Xml, Parent, sMainLineStyle, pGetGoogleColor(oColor), 2)
                        Dim xmlMainPlacemark As XmlElement = Xml.CreateElement("Placemark")
                        Call GoogleKmlAppendNode(Xml, xmlMainPlacemark, "name", oCave.Name & cCaveInfoBranches.sBranchSeparator & oBranch.Path)
                        Call GoogleKmlAppendNode(Xml, xmlMainPlacemark, "description", oBranch.Description)
                        Call GoogleKmlAppendNode(Xml, xmlMainPlacemark, "styleUrl", "#" & sMainLineStyle)
                        Dim xmlMainMultiGeometry As XmlElement = Xml.CreateElement("MultiGeometry")
                        For Each oSegment As cSegment In oSegments
                            If oSegment.IsValid AndAlso Not oSegment.Splay Then
                                Dim xmlMainLineString As XmlElement = Xml.CreateElement("LineString")
                                Call GoogleKmlAppendNode(Xml, xmlMainLineString, "tessellate", "1")
                                Dim oFrom As Calculate.cTrigPoint = Survey.Calculate.TrigPoints(oSegment.From)
                                Dim oTo As Calculate.cTrigPoint = Survey.Calculate.TrigPoints(oSegment.To)
                                Dim sCoordinates As String = modNumbers.NumberToString(oFrom.Coordinate.Longitude, DefaultCoordinateFormat) & "," & modNumbers.NumberToString(oFrom.Coordinate.Latitude, DefaultCoordinateFormat) & "," & modNumbers.NumberToString(oFrom.Coordinate.Altitude, DefaultAltitudeFormat) & vbCrLf
                                sCoordinates = sCoordinates & modNumbers.NumberToString(oTo.Coordinate.Longitude, DefaultCoordinateFormat) & "," & modNumbers.NumberToString(oTo.Coordinate.Latitude, DefaultCoordinateFormat) & "," & modNumbers.NumberToString(oTo.Coordinate.Altitude, DefaultAltitudeFormat) & vbCrLf
                                Call GoogleKmlAppendNode(Xml, xmlMainLineString, "coordinates", sCoordinates)
                                Call xmlMainMultiGeometry.AppendChild(xmlMainLineString)
                            End If
                        Next
                        If xmlMainMultiGeometry.HasChildNodes Then xmlMainPlacemark.AppendChild(xmlMainMultiGeometry)
                        Call xmlFolderCenterline.AppendChild(xmlMainPlacemark)
                    End If
                Next
                Call xmlFolderCenterlinesGeneric.AppendChild(xmlFolderCenterline)
            Next
            Call xmlFolderCenterlines.AppendChild(xmlFolderCenterlinesGeneric)

            Dim xmlFolderCenterlinesSplay As XmlElement = Xml.CreateElement("Folder")
            Call GoogleKmlAppendNode(Xml, xmlFolderCenterlinesSplay, "name", modMain.GetLocalizedString("export.textpart4"))
            For Each oCave As cCaveInfo In Survey.Properties.CaveInfos.GetWithEmpty.Values
                Dim xmlFolderCenterline As XmlElement = Xml.CreateElement("Folder")
                Call GoogleKmlAppendNode(Xml, xmlFolderCenterline, "name", If(bUseCadastralIDInCaveNames AndAlso oCave.ID <> "", oCave.ID & " - ", "") & oCave.Name)
                For Each oBranch As cCaveInfoBranch In oCave.Branches.GetAllBranchesWithEmpty.Values
                    Dim oSegments As cISegmentCollection = oBranch.GetSegments(cOptionsCenterline.HighlightModeEnum.ExactMatch)
                    If oSegments.Count > 0 Then
                        Dim oColor As Color = oBranch.GetColor(Color.White)
                        Dim sSplayLineStyle As String = "splay_" & FormatCaveBranchName(oCave.Name, oBranch.Path)
                        Call modExport.GoogleKmlAppendLineStyle(Xml, Parent, sSplayLineStyle, pGetGoogleColor(Color.FromArgb(180, oColor)), 1)
                        Dim xmlSplayPlacemark As XmlElement = Xml.CreateElement("Placemark")
                        Call GoogleKmlAppendNode(Xml, xmlSplayPlacemark, "name", oCave.Name & cCaveInfoBranches.sBranchSeparator & oBranch.Path)
                        Call GoogleKmlAppendNode(Xml, xmlSplayPlacemark, "description", oBranch.Description)
                        Call GoogleKmlAppendNode(Xml, xmlSplayPlacemark, "styleUrl", "#" & sSplayLineStyle)
                        If oSegments.Count > 0 Then
                            Dim xmlSplayMultiGeometry As XmlElement = Xml.CreateElement("MultiGeometry")
                            For Each oSegment As cSegment In oSegments
                                If oSegment.IsValid AndAlso oSegment.Splay Then
                                    Dim xmlSplayLineString As XmlElement = Xml.CreateElement("LineString")
                                    Call GoogleKmlAppendNode(Xml, xmlSplayLineString, "tessellate", "1")
                                    Dim oFrom As Calculate.cTrigPoint = Survey.Calculate.TrigPoints(oSegment.From)
                                    Dim oTo As Calculate.cTrigPoint = Survey.Calculate.TrigPoints(oSegment.To)
                                    Dim sCoordinates As String = modNumbers.NumberToString(oFrom.Coordinate.Longitude, DefaultCoordinateFormat) & "," & modNumbers.NumberToString(oFrom.Coordinate.Latitude, DefaultCoordinateFormat) & "," & modNumbers.NumberToString(oFrom.Coordinate.Altitude, DefaultAltitudeFormat) & vbCrLf
                                    sCoordinates = sCoordinates & modNumbers.NumberToString(oTo.Coordinate.Longitude, DefaultCoordinateFormat) & "," & modNumbers.NumberToString(oTo.Coordinate.Latitude, DefaultCoordinateFormat) & "," & modNumbers.NumberToString(oTo.Coordinate.Altitude, DefaultAltitudeFormat) & vbCrLf
                                    Call GoogleKmlAppendNode(Xml, xmlSplayLineString, "coordinates", sCoordinates)
                                    Call xmlSplayMultiGeometry.AppendChild(xmlSplayLineString)
                                End If
                            Next
                            If xmlSplayMultiGeometry.HasChildNodes Then Call xmlSplayPlacemark.AppendChild(xmlSplayMultiGeometry)
                        End If
                        Call xmlFolderCenterline.AppendChild(xmlSplayPlacemark)
                    End If
                Next
                Call xmlFolderCenterlinesSplay.AppendChild(xmlFolderCenterline)
            Next
            Call xmlFolderCenterlines.AppendChild(xmlFolderCenterlinesSplay)
            Call Parent.AppendChild(xmlFolderCenterlines)
        End If

        Dim oOrigin As cTrigPoint = Survey.TrigPoints.GetOrigin
        Dim oUTMOrigin As modUTM.UTM = modUTM.WGS84ToUTM(Survey.Calculate.TrigPoints(oOrigin).Coordinate)
        If (Options And GoogleKMLExportOptionsEnum.CaveBorders) = GoogleKMLExportOptionsEnum.CaveBorders Then
            Dim xmlFolderBorders As XmlElement = Xml.CreateElement("Folder")
            Call GoogleKmlAppendNode(Xml, xmlFolderBorders, "name", modMain.GetLocalizedString("export.textpart7"))

            Dim oClipperBorder As Clipper = New Clipper
            Dim oHoleClipperBorder As Clipper = New Clipper

            Dim sMC As Single = Survey.Calculate.GeoMagDeclinationData.MeridianConvergenceRadians
            For Each oCave As cCaveInfo In Survey.Properties.CaveInfos.GetWithEmpty.Values
                Dim xmlFolderBorder As XmlElement = Xml.CreateElement("Folder")
                Call GoogleKmlAppendNode(Xml, xmlFolderBorder, "name", If(bUseCadastralIDInCaveNames AndAlso oCave.ID <> "", oCave.ID & " - ", "") & oCave.Name)

                Dim oColor As Color
                For Each oBranch As cCaveInfoBranch In oCave.Branches.GetAllBranchesWithEmpty.Values
                    oClipperBorder.Clear()
                    oHoleClipperBorder.Clear()

                    Dim oItems As List(Of cItem) = oBranch.GetItems(cIDesign.cDesignTypeEnum.Plan)
                    Dim oBordersItems As List(Of cItem) = New List(Of cItem)
                    Dim oHoleBordersItems As List(Of cItem) = New List(Of cItem)
                    For Each oItem As cItem In oItems
                        If Not oItem.Deleted Then
                            If oItem.Type = Items.cIItem.cItemTypeEnum.InvertedFreeHandArea Then
                                If oItem.BindDesignType = cItem.BindDesignTypeEnum.MainDesign Then
                                    Dim oBorderItem As Items.cItemInvertedFreeHandArea = oItem
                                    If oBorderItem.MergeMode = Items.cIItemMergeableArea.MergeModeEnum.Add Then
                                        Call oBordersItems.Add(oBorderItem)
                                    Else
                                        Call oHoleBordersItems.Add(oBorderItem)
                                    End If
                                End If
                            End If
                        End If
                    Next

                    If oBordersItems.Count > 0 Then
                        oColor = oBranch.GetColor(Color.White)
                        oColor = Color.FromArgb(255 - BorderTransparency, oColor)
                        Dim sBorderStyle As String = "borders_" & FormatCaveBranchName(oCave.Name, oBranch.Path)
                        Call modExport.GoogleKmlAppendPoligonStyle(Xml, Parent, sBorderStyle, Nothing, 0, pGetGoogleColor(oColor))

                        Dim xmlPlacemark As XmlElement = Xml.CreateElement("Placemark")
                        Call GoogleKmlAppendNode(Xml, xmlPlacemark, "name", oCave.Name & cCaveInfoBranches.sBranchSeparator & oBranch.Path)
                        Call GoogleKmlAppendNode(Xml, xmlPlacemark, "description", oBranch.Description)
                        Call GoogleKmlAppendNode(Xml, xmlPlacemark, "styleUrl", "#" & sBorderStyle)

                        Dim xmlMultiGeometry As XmlElement = Xml.CreateElement("MultiGeometry")

                        For Each oItem As Items.cItemInvertedFreeHandArea In oBordersItems
                            Dim oPoints As List(Of PointF) = New List(Of PointF)
                            If oItem.Points.Count > 1 Then
                                For Each oSequence As cSequence In oItem.Points.GetSequences()
                                    Dim oSequencePoints() As PointF = oSequence.GetPoints
                                    If oSequencePoints.Length > 1 Then
                                        Using oPath As GraphicsPath = New GraphicsPath
                                            Select Case oSequence.GetLineType(oItem.LineType)
                                                Case Items.cIItemLine.LineTypeEnum.Beziers
                                                    Call modPaint.PointsToBeziers(oSequencePoints, oPath)
                                                Case Items.cIItemLine.LineTypeEnum.Splines
                                                    Call oPath.AddCurve(oSequencePoints, sDefaultSplineTension)
                                                Case Else
                                                    Call oPath.AddLines(oSequencePoints)
                                            End Select
                                            Call oPath.Flatten(Nothing, 0.01)
                                            Call oPoints.AddRange(oPath.PathPoints)
                                        End Using
                                    End If
                                Next
                            End If
                            Call oClipperBorder.AddPath(modClipper.ToIntPolygon(oPoints, 100), PolyType.ptSubject, True)
                        Next

                        For Each oItem As Items.cItemInvertedFreeHandArea In oHoleBordersItems
                            Dim oPoints As List(Of PointF) = New List(Of PointF)
                            If oItem.Points.Count > 1 Then
                                For Each oSequence As cSequence In oItem.Points.GetSequences()
                                    Dim oSequencePoints() As PointF = oSequence.GetPoints
                                    If oSequencePoints.Length > 1 Then
                                        Using oPath As GraphicsPath = New GraphicsPath
                                            Select Case oSequence.GetLineType(oItem.LineType)
                                                Case Items.cIItemLine.LineTypeEnum.Beziers
                                                    Call modPaint.PointsToBeziers(oSequencePoints, oPath)
                                                Case Items.cIItemLine.LineTypeEnum.Splines
                                                    Call oPath.AddCurve(oSequencePoints, sDefaultSplineTension)
                                                Case Else
                                                    Call oPath.AddLines(oSequencePoints)
                                            End Select
                                            Call oPath.Flatten(Nothing, 0.01)
                                            Call oPoints.AddRange(oPath.PathPoints)
                                        End Using
                                    End If
                                Next
                            End If
                            Call oHoleClipperBorder.AddPath(modClipper.ToIntPolygon(oPoints, 100), PolyType.ptSubject, True)
                        Next

                        Dim oResPoly As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
                        oClipperBorder.Execute(ClipType.ctUnion, oResPoly, PolyFillType.pftNonZero, PolyFillType.pftNonZero)
                        Dim oResPoints As List(Of List(Of PointF)) = modClipper.FromIntPolygonsToPointF(oResPoly, 100)

                        Dim oHoleResPoly As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
                        oHoleClipperBorder.Execute(ClipType.ctUnion, oHoleResPoly, PolyFillType.pftNonZero, PolyFillType.pftNonZero)
                        Dim oHoleResPoints As List(Of List(Of PointF)) = modClipper.FromIntPolygonsToPointF(oHoleResPoly, 100)

                        For Each oResSubpoints As List(Of PointF) In oResPoints
                            Dim xmlPolygon As XmlElement = Xml.CreateElement("Polygon")
                            Call GoogleKmlAppendNode(Xml, xmlPolygon, "tessellate", "1")
                            Dim xmlouterBoundaryIs As XmlElement = Xml.CreateElement("outerBoundaryIs")

                            Dim xmlLinearRing As XmlElement = Xml.CreateElement("LinearRing")

                            Dim oCoordinates As System.Text.StringBuilder = New System.Text.StringBuilder
                            For iPoint As Integer = 0 To oResSubpoints.Count - 1
                                Dim oPoint As PointF = modPaint.RotatePointByRadians(oResSubpoints(iPoint), sMC)
                                Dim oRefPoint As modUTM.UTM = New modUTM.UTM(oUTMOrigin)
                                oRefPoint.East = oRefPoint.East + CDec(oPoint.X)
                                oRefPoint.North = oRefPoint.North - CDec(oPoint.Y)
                                Dim oRefPointWGS84 As modUTM.WGS84 = modUTM.UTMToWGS84(oRefPoint)
                                Call oCoordinates.AppendLine(modNumbers.NumberToString(oRefPointWGS84.Longitude, DefaultCoordinateFormat) & "," & modNumbers.NumberToString(oRefPointWGS84.Latitude, DefaultCoordinateFormat) & "," & modNumbers.NumberToString(0, DefaultAltitudeFormat))
                            Next

                            Call GoogleKmlAppendNode(Xml, xmlLinearRing, "coordinates", oCoordinates.ToString)
                            Call xmlouterBoundaryIs.AppendChild(xmlLinearRing)
                            Call xmlPolygon.AppendChild(xmlouterBoundaryIs)

                            For Each oHoleResSubpoints As List(Of PointF) In oHoleResPoints
                                If modPath.Contains(oResSubpoints, oHoleResSubpoints) Then
                                    Dim xmlInnerBoundaryIs As XmlElement = Xml.CreateElement("innerBoundaryIs")
                                    Dim xmlInnerLinearRing As XmlElement = Xml.CreateElement("LinearRing")
                                    Dim oInnerCoordinates As System.Text.StringBuilder = New System.Text.StringBuilder
                                    For iPoint As Integer = 0 To oHoleResSubpoints.Count - 1
                                        Dim oPoint As PointF = modPaint.RotatePointByRadians(oHoleResSubpoints(iPoint), sMC)
                                        Dim oRefPoint As modUTM.UTM = New modUTM.UTM(oUTMOrigin)
                                        oRefPoint.East = oRefPoint.East + CDec(oPoint.X)
                                        oRefPoint.North = oRefPoint.North - CDec(oPoint.Y)
                                        Dim oRefPointWGS84 As modUTM.WGS84 = modUTM.UTMToWGS84(oRefPoint)
                                        Call oInnerCoordinates.AppendLine(modNumbers.NumberToString(oRefPointWGS84.Longitude, DefaultCoordinateFormat) & "," & modNumbers.NumberToString(oRefPointWGS84.Latitude, DefaultCoordinateFormat) & "," & modNumbers.NumberToString(0, DefaultAltitudeFormat))
                                    Next
                                    Call GoogleKmlAppendNode(Xml, xmlInnerLinearRing, "coordinates", oInnerCoordinates.ToString)
                                    Call xmlInnerBoundaryIs.AppendChild(xmlInnerLinearRing)
                                    Call xmlPolygon.AppendChild(xmlInnerBoundaryIs)
                                End If
                            Next

                            xmlMultiGeometry.AppendChild(xmlPolygon)
                        Next

                        Call xmlPlacemark.AppendChild(xmlMultiGeometry)
                        Call xmlFolderBorder.AppendChild(xmlPlacemark)
                    End If
                Next
                Call xmlFolderBorders.AppendChild(xmlFolderBorder)
            Next
            Call Parent.AppendChild(xmlFolderBorders)
        End If

    End Sub

    Public Sub GoogleKmlExportTo2(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Filename As String, Optional Options As GoogleKMLExportOptionsEnum = GoogleKMLExportOptionsEnum.Track Or GoogleKMLExportOptionsEnum.Waypoint, Optional BorderTransparency As Single = 0)
        'Try
        Dim oGPSBase As cTrigPoint = Survey.TrigPoints.GetGPSBaseReferencePoint
        If Not Survey.Properties.GPS.Enabled OrElse oGPSBase Is Nothing OrElse oGPSBase.Coordinate.IsEmpty Then
            Call MsgBox(modMain.GetLocalizedString("export.warning1"), MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, modMain.GetLocalizedString("export.warningtitle"))
        Else
            Dim xml As XmlDocument = New XmlDocument
            Dim xmlRoot As XmlElement = xml.CreateElement("kml")

            Dim xmlDocuments As XmlElement = xml.CreateElement("Folder")
            Call GoogleKmlAppendNode(xml, xmlDocuments, "name", modMain.GetLocalizedString("export.textpart8"))
            Call GoogleKmlAppendNode(xml, xmlDocuments, "visibility", "1")
            Call GoogleKmlAppendNode(xml, xmlDocuments, "open", "1")

            Dim oSurveys As List(Of cSurveyPC.cSurvey.cSurvey) = New List(Of cSurveyPC.cSurvey.cSurvey)
            Call oSurveys.Add(Survey)
            If (Options And GoogleKMLExportOptionsEnum.LinkedSurveys) = GoogleKMLExportOptionsEnum.LinkedSurveys Then
                Call oSurveys.AddRange(Survey.LinkedSurveys.Where(Function(oItem) oItem.IsUsable).Select(Function(oItem) oItem.LinkedSurvey))
            End If

            Dim bUseCadastralIDInCaveNames As Boolean = (Options And GoogleKMLExportOptionsEnum.UseCadastralIDInCaveNames) = GoogleKMLExportOptionsEnum.UseCadastralIDInCaveNames

            For Each oSurvey As cSurveyPC.cSurvey.cSurvey In oSurveys
                Dim xmlDocument As XmlElement = xml.CreateElement("Document")
                Call modExport.GoogleKmlAppendNode(xml, xmlDocument, "name", If(bUseCadastralIDInCaveNames AndAlso oSurvey.Properties.ID <> "", oSurvey.Properties.ID & " - ", "") & oSurvey.Name)
                If oSurvey.Properties.Description <> "" Then Call modExport.GoogleKmlAppendNode(xml, xmlDocument, "description", oSurvey.Properties.Description)
                Call modExport.GoogleKmlAppendIconStyle(xml, xmlDocument, "splay", "0.4", "http://maps.google.com/mapfiles/kml/pushpin/wht-pushpin.png", "0.4")
                Call modExport.GoogleKmlAppendIconStyle(xml, xmlDocument, "station", "0.4", "http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png", "0.4")
                Call modExport.GoogleKmlAppendIconStyle(xml, xmlDocument, "entrance", "0.5", "http://maps.google.com/mapfiles/kml/pushpin/red-pushpin.png", "0.5")
                Call GoogleKmlAppendDocumentDetails(oSurvey, xml, xmlDocument, Options, BorderTransparency)
                Call xmlDocuments.AppendChild(xmlDocument)
            Next
            Call xmlRoot.AppendChild(xmlDocuments)

            Call xml.AppendChild(xmlRoot)
            Call XMLAddDeclaration(xml)
            Call xml.Save(Filename)
        End If
    End Sub

    Public Sub CalculateCoordinatesFromXYZ(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Lat As Decimal, ByVal [Long] As Decimal, ByVal Alt As Decimal, ByVal DeltaX As Decimal, ByVal DeltaY As Decimal, DeltaZ As Decimal, ByRef [NewLat] As Decimal, ByRef [NewLong] As Decimal, ByRef NewAlt As Decimal)
        Dim oWGS84 As modUTM.WGS84 = New modUTM.WGS84([Long], Lat)
        Dim dMC As Decimal = Survey.Calculate.GeoMagDeclinationData.MeridianConvergenceRadians
        Dim oUTM As modUTM.UTM = modUTM.WGS84ToUTM(oWGS84)
        oUTM.East = oUTM.East + DeltaX
        oUTM.North = oUTM.North - DeltaY
        oWGS84 = modUTM.UTMToWGS84(oUTM)
        Dim sAlt As Decimal = Alt + DeltaZ

        NewLat = oWGS84.Latitude
        NewLong = oWGS84.Longitude
        NewAlt = sAlt
    End Sub

    Public Sub CalculateCoordinatesFromTrigpoint(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Lat As Decimal, ByVal [Long] As Decimal, ByVal Alt As Decimal, ByVal From As String, ByVal [To] As String, ByRef [NewLat] As Decimal, ByRef [NewLong] As Decimal, ByRef NewAlt As Decimal)
        Dim oWGS84 As modUTM.WGS84 = New modUTM.WGS84([Long], Lat)
        Dim oPointFrom As PointD
        Dim oPointTo As PointD
        Dim dMC As Decimal = Survey.Calculate.GeoMagDeclinationData.MeridianConvergenceRadians
        oPointFrom = modPaint.RotatePointByRadians(Survey.Calculate.TrigPoints([From]).Point.To2DPoint(cSurvey.Calculate.cTrigPointPoint.ProjectionEnum.FromTop), dMC)
        oPointTo = modPaint.RotatePointByRadians(Survey.Calculate.TrigPoints([To]).Point.To2DPoint(cSurvey.Calculate.cTrigPointPoint.ProjectionEnum.FromTop), dMC)
        Dim dX As Decimal = oPointTo.X - oPointFrom.X
        Dim dy As Decimal = oPointTo.Y - oPointFrom.Y
        Dim oUTM As modUTM.UTM = modUTM.WGS84ToUTM(oWGS84)
        oUTM.East = oUTM.East + dX
        oUTM.North = oUTM.North - dy
        oWGS84 = modUTM.UTMToWGS84(oUTM)
        oPointFrom = Survey.Calculate.TrigPoints([From]).Point.To2DPoint(cSurvey.Calculate.cTrigPointPoint.ProjectionEnum.Perpendicular)
        oPointTo = Survey.Calculate.TrigPoints([To]).Point.To2DPoint(cSurvey.Calculate.cTrigPointPoint.ProjectionEnum.Perpendicular)
        Dim sAlt As Decimal = -1 * (oPointTo.Y - oPointFrom.Y)

        NewLat = oWGS84.Latitude
        NewLong = oWGS84.Longitude
        NewAlt = Alt + sAlt
    End Sub

    Public Sub CalculateCoordinates(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Lat As Decimal, ByVal [Lon] As Decimal, ByVal Distance As Decimal, ByVal Bearing As Decimal, ByRef [NewLat] As Decimal, ByRef [NewLong] As Decimal)
        'calcolo le coordinate del nuovo punto partendo da quelle del precedente...
        Dim dLat As Decimal = [Lat]
        Dim dLong As Decimal = [Lon]

        Dim dR As Decimal = 6378137 '6371.01 * 1000
        Dim dlat1 As Decimal = modPaint.DegreeToRadians(dLat)
        Dim dlong1 As Decimal = modPaint.DegreeToRadians(dLong)
        Dim dDist As Decimal = Distance '/ 1000 '/ dR  'ORA SONO METRI 'ATTENZIONE...le distanze ora sono in KM...cosi vedo bene gli errori!
        Dim dMG As Decimal = modUTM.GetMeridianConvergence(dLong, dLat)
        Dim dbrng As Decimal = modPaint.DegreeToRadians(Bearing + dMG)
        Dim dLat2 As Decimal = Math.Asin(Math.Sin(dlat1) * Math.Cos(dDist / dR) + Math.Cos(dlat1) * Math.Sin(dDist / dR) * Math.Cos(dbrng))
        Dim dlong2 As Decimal = dlong1 + Math.Atan2(Math.Sin(dbrng) * Math.Sin(dDist / dR) * Math.Cos(dlat1), Math.Cos(dDist / dR) - Math.Sin(dlat1) * Math.Sin(dLat2))

        NewLat = modPaint.RadiansToDegree(dLat2)
        NewLong = modPaint.RadiansToDegree(dlong2)
    End Sub

    <FlagsAttribute()> Public Enum GoogleKMLExportOptionsEnum
        [Waypoint] = &H1
        [Track] = &H2
        CaveBorders = &H4
        LinkedSurveys = &H8
        UseCadastralIDInCaveNames = &H10
    End Enum

    <FlagsAttribute()> Public Enum VTopoExportOptionsEnum
        [Default] = &H0
        [OneFileForEachCave] = &H1
    End Enum

    <FlagsAttribute()> Public Enum TherionExportOptionsEnum
        [Default] = &H0
        ExportSplay = &H1
        ExportSplayFlag = &H2
        CalculateSplay = &H3
        SegmentID = &H4
        Loch = &H8

        ExportSketch = &H10
        ExportSurfaceElevationsData = &H20
        'ExportSurfaceElevationsReferences = &H40

        TrigpointExportDictionary = &H100
        TrigpointExportNameAsComment = &H200
        UseCadastralIDinCaveNames = &H400

        SegmentForceDirection = &H2000
        SegmentForcePath = &H4000

        Scrap = &H10000
        ScrapFor3D = &H20000

        LegacyCalculation = &H100000

        UseSubData = &H1000000
        Oversample3D = &H1000000
    End Enum

    Public Sub TherionCreateConfig(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Filename As String, ByVal DataFilenames As List(Of String), ByVal Command As String)
        Call TherionCreateConfig(Survey, Filename, DataFilenames.ToArray, Command)
    End Sub

    Public Sub TherionCreateConfig(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Filename As String, ByVal DataFilenames As String(), ByVal Command As String)
        Dim fi As FileInfo = New FileInfo(Filename)
        Using st As StreamWriter = fi.CreateText
            Call st.WriteLine("encoding  utf-8")
            For Each sDataFilename As String In DataFilenames
                Call st.WriteLine("source " & Chr(34) & sDataFilename & Chr(34))
            Next
            Call st.WriteLine(Command)
            Call st.Close()
        End Using
    End Sub

    Public Sub TherionCreateConfig(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Filename As String, ByVal DataFilename As String, ByVal Command As String)
        Call TherionCreateConfig(Survey, Filename, {DataFilename}, Command)
    End Sub

    Private Function GetVTopoInclinationMeasure(InclinationType As cSegment.InclinationTypeEnum) As String
        Select Case InclinationType
            Case cSegment.InclinationTypeEnum.CentesimalDegree
                Return "Gra"
            Case cSegment.InclinationTypeEnum.DecimalDegree
                Return "Degd"
            Case cSegment.InclinationTypeEnum.Percentage
                Return "%"
        End Select
    End Function

    Private Function GetVTopoBearingMeasure(BearingType As cSegment.BearingTypeEnum) As String
        Select Case BearingType
            Case cSegment.BearingTypeEnum.CentesimalDegree
                Return "Gra"
            Case cSegment.BearingTypeEnum.DecimalDegree
                Return "Degd"
        End Select
    End Function

    Public Sub VTopoTroExportTo(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Filename As String, Optional ByVal Dictionary As IDictionary(Of String, String) = Nothing, Optional ByVal Options As VTopoExportOptionsEnum = VTopoExportOptionsEnum.Default)
        If (Options And VTopoExportOptionsEnum.OneFileForEachCave) = VTopoExportOptionsEnum.OneFileForEachCave Then

        Else
            Dim fi As FileInfo = New FileInfo(Filename)
            Using st As StreamWriter = fi.CreateText
                Call st.WriteLine("Version 5.02")
                Call st.WriteLine()
                Dim sName As String = "" & Survey.Name
                sName = sName.Replace(" ", "_")
                sName = sName.Replace("(", "")
                sName = sName.Replace(")", "")
                sName = sName.Replace(".", "")
                sName = sName.Replace("'", " ")
                If sName = "" Then sName = "csurvey_unnamed"

                Dim sOrigin As String = Survey.Properties.Origin
                If Not Dictionary Is Nothing Then
                    sOrigin = DictionaryTranslate(Dictionary, sOrigin)
                End If

                'ATTENZIONE...ci andrebbero le coordinate ma per ora glisso...do priorità ai dati della poligonale...
                Call st.WriteLine("Trou " & sName & " ,0.000,0.000," & sOrigin & ",UTM32")
                If Survey.Properties.Club <> "" Then Call st.WriteLine("Club " & Survey.Properties.Club)
                For Each oTrigpoint As cTrigPoint In Survey.TrigPoints.GetEntrances(cTrigPoint.EntranceTypeEnum.OtherCaveEntrance)
                    Dim sEntrance As String = oTrigpoint.Name
                    sEntrance = DictionaryTranslate(Dictionary, sEntrance)
                    Call st.WriteLine("Entree " & sEntrance)
                Next

                'fixed shot per origin...
                'is not perfect but visualtopo export could not be perfect due to the different approach to survey of the two software
                Call st.WriteLine("Param Deca Degd Clino Degd 0.0000 Dir,Dir,Dir Arr Std")

                Dim sFrom As String
                Dim sTo As String

                Using Nothing
                    sFrom = DictionaryTranslate(Dictionary, Survey.Properties.Origin)
                    sTo = sFrom
                    Call st.Write(modText.AlignLeft(sFrom, 10) & " " & modText.AlignLeft(sTo, 10) & " ")
                    Call st.Write(modText.AlignLeft("", 12))
                    Call st.Write(modText.AlignRight(modText.FormatNumber(0, "0.00"), 7) & " " & modText.AlignRight(modText.FormatNumber(0, "0.00"), 7) & " " & modText.AlignRight(modText.FormatNumber(0, "0.00"), 7))
                    Call st.Write(modText.AlignRight(modText.FormatNumber(0, "0.00"), 7) & modText.AlignRight(modText.FormatNumber(0, "0.00"), 7) & modText.AlignRight(modText.FormatNumber(0, "0.00"), 7) & modText.AlignRight(modText.FormatNumber(0, "0.00"), 7))
                    Call st.Write(" " & "N" & " " & "I")
                    Call st.WriteLine()
                End Using

                Dim bFirst As Boolean
                For Each oSession As cSession In Survey.Properties.Sessions.GetWithEmpty.Values
                    Dim oSegments As cSegmentCollection = Survey.Segments.GetSessionSegments(oSession)
                    If oSegments.Count > 0 Then
                        bFirst = True
                        For Each oSegment As cSegment In oSegments
                            If oSegment.IsValid Then
                                If bFirst Then
                                    Dim sLRUDRef As String
                                    Select Case oSession.SideMeasuresReferTo
                                        Case cSegment.SideMeasuresReferToEnum.EndPoint
                                            sLRUDRef = "Arr"
                                        Case cSegment.SideMeasuresReferToEnum.StartPoint
                                            sLRUDRef = "Dep"
                                        Case Else
                                            sLRUDRef = "Inc"
                                    End Select
                                    Call st.WriteLine("Param Deca " & GetVTopoBearingMeasure(oSession.BearingType) & " Clino " & GetVTopoInclinationMeasure(oSession.InclinationType) & " 0.0000 Dir,Dir,Dir " & sLRUDRef & " Std")
                                    bFirst = False
                                End If
                                sFrom = DictionaryTranslate(Dictionary, oSegment.[From])
                                sTo = DictionaryTranslate(Dictionary, oSegment.[To])
                                Call st.Write(modText.AlignLeft(sFrom, 10) & " " & modText.AlignLeft(sTo, 10) & " ")
                                Call st.Write(modText.AlignLeft("", 12))
                                Dim sDistance As Single = modConversion.ConvertSegmentToBaseDistance(oSegment.Distance, oSegment)
                                Call st.Write(modText.AlignRight(modText.FormatNumber(sDistance, "0.00"), 7) & " " & modText.AlignRight(modText.FormatNumber(oSegment.Bearing, "0.00"), 7) & " " & modText.AlignRight(modText.FormatNumber(oSegment.Inclination, "0.00"), 7))
                                Call st.Write(modText.AlignRight(modText.FormatNumber(oSegment.Left, "0.00"), 7) & modText.AlignRight(modText.FormatNumber(oSegment.Right, "0.00"), 7) & modText.AlignRight(modText.FormatNumber(oSegment.Up, "0.00"), 7) & modText.AlignRight(modText.FormatNumber(oSegment.Down, "0.00"), 7))
                                Call st.Write(" " & "N" & " " & IIf(oSegment.Exclude, "E", "I"))
                                Call st.WriteLine()
                            End If
                        Next
                    End If
                Next

                Call st.WriteLine("[Configuration 5.02]")
                'ATTENZIONE: non so a cosa servano questi dati...penso siano dati di posizione di finestre o roba simile...
                Call st.WriteLine("Visual Topo = 2, 3, -1, -1, -1, -1, 197, 226, 1157, 780")
                Call st.WriteLine("Options=1,1")

                'ATTENZIONE: qua andrebbe riportato come sono prese le misure laterali ma
                'non vi è compatilibità diretta tra questo flag e la modalità di gestione dei dati di csurvey
                'quindi metto fisso un valore...
                Call st.WriteLine("Calcul=2,3,-1,-1,-8,-30,0,0,840,211")
                Call st.WriteLine("Options=29,0,0,1,1")

                'ATTENZIONE: non conosco come compilare questi dati...li ometto visto che sembrano facoltativi
                'Call st.WriteLine("ExportDxf=0,100,391,0,0,1,6,7,4,4,3,3,2,7,9")

                'ATTENZIONE: non conosco come compilare questi dati...li imposto a valori fissi...
                Call st.WriteLine("Colonnes=8.00,8.00,8.00,8.00,8.00,8.00,8.00,8.00,8.00,8.00,8.00,2.00,2.00,4.00,0.38,8.00,8.00,8.00,8.00,8.00,0.38,0.00,0.00")

                Call st.WriteLine()
                Call st.Close()
            End Using
        End If
    End Sub

    'Private Function pHolosExportIndexAddNode(XML As XmlDocument, Parent As XmlElement, Name As String, Text As String) As XmlElement
    '    Dim oNode As XmlElement = XML.CreateElement(Name)
    '    oNode.InnerText = Text
    '    Call Parent.AppendChild(oNode)
    '    Return oNode
    'End Function

    'Private Class cHolosExportOptions
    '    Public ScaleFactor As Single
    '    Public ScaleStep As Integer
    '    Public Profile As HolosProfileEnum
    '    Public Options As HolosExportOptionsEnum
    'End Class

    'Private Sub pHolosExportIndex(Survey As cSurvey.cSurvey, Filename As String, Options As cHolosExportOptions)
    '    Dim oXML As XmlDocument = New XmlDocument
    '    Dim oXMLRoot As XmlElement = oXML.CreateElement("holos")
    '    Dim sBaseFilename As String = Path.GetFileName(Filename)
    '    '<name>Gessi di Rontana</name>
    '    '<description>Vena del Gesso romagnola - Gessi di Rontana</description>
    '    '<url>http://www.venadelgesso.org/</url>
    '    '<utmref zone="32" band="T" /> 
    '    '<terrain files="rontana.elevation.xml" />
    '    '<contourlines files="rontana.contourlines.100.xml;rontana.contourlines.25.xml;rontana.contourlines.1.xml" />
    '    '<points files="rontana.points.xml" />
    '    '<caves files="fantinigaribaldi.cave.xml;faenza.cave.xml;rontana.cave.xml" />
    '    Call pHolosExportIndexAddNode(oXML, oXMLRoot, "name", Survey.Name)
    '    Call pHolosExportIndexAddNode(oXML, oXMLRoot, "description", Survey.Properties.Description)
    '    Call pHolosExportIndexAddNode(oXML, oXMLRoot, "url", "")

    '    Dim oXMLTerrain As XmlElement = pHolosExportIndexAddNode(oXML, oXMLRoot, "terrain", "")
    '    Call oXMLTerrain.SetAttribute("files", sBaseFilename & ".elevation.xml")
    '    For Each oOrtophoto As cSurvey.Surface.cOrthoPhoto In Survey.Surface.OrthoPhotos
    '        'If oOrtophoto.ShowIn3D Then
    '        Dim oXMLTerrainOrtophoto As XmlElement = pHolosExportIndexAddNode(oXML, oXMLTerrain, "texture", sBaseFilename & "." & pHolosGetSafeFilename(oOrtophoto.Name) & "_%STEP%.jpg")
    '        Call oXMLTerrainOrtophoto.SetAttribute("name", oOrtophoto.Name)
    '        'End If
    '    Next

    '    Call pHolosExportIndexAddNode(oXML, oXMLRoot, "contourlines", "")

    '    Call pHolosExportIndexAddNode(oXML, oXMLRoot, "points", "")

    '    Dim oXMLCaves As XmlElement = pHolosExportIndexAddNode(oXML, oXMLRoot, "caves", "")
    '    Dim sCaves As String = ""
    '    For Each oCaveInfo As cCaveInfo In Survey.Properties.CaveInfos
    '        If sCaves <> "" Then sCaves &= ";"
    '        sCaves &= sBaseFilename & "." & pHolosGetSafeFilename(oCaveInfo.Name) & ".cave.xml"
    '    Next
    '    Call oXMLCaves.SetAttribute("files", sCaves)

    '    Call oXML.AppendChild(oXMLRoot)
    '    Call XMLAddDeclaration(oXML)
    '    Call oXML.Save(Filename & ".index.xml")
    'End Sub

    'Private Sub pHolosExportElevation(Survey As cSurvey.cSurvey, Filename As String)
    '    Dim oXML As XmlDocument = New XmlDocument
    '    Dim oXMLRoot As XmlElement = oXML.CreateElement("holos")
    '    Dim oXMLElevation As XmlElement = oXML.CreateElement("elevation")
    '    If Survey.Surface.Elevations.Default Is Nothing Then
    '        Dim sOrigin As String = Survey.TrigPoints.GetOrigin.Name
    '        Dim oOriginPos As Calculate.cTrigPointCoordinate = Survey.Calculate.TrigPoints(sOrigin).Coordinate
    '        Dim oOriginUTM As modUTM.UTM = modUTM.WGS84ToUTM(oOriginPos)
    '        Call oXMLElevation.SetAttribute("c", modNumbers.NumberToString(oOriginUTM.East) & ";" & modNumbers.NumberToString(oOriginUTM.North) & ";" & modNumbers.NumberToString(oOriginPos.Altitude))
    '        Call oXMLElevation.SetAttribute("rows", 1)
    '        Call oXMLElevation.SetAttribute("cols", 1)
    '        Call oXMLElevation.SetAttribute("sizex", 5)
    '        Call oXMLElevation.SetAttribute("sizey", 5)
    '        Call oXMLElevation.SetAttribute("nodatavalue", -99999)
    '        oXMLElevation.InnerText = "-99999"
    '    Else
    '        Dim oDefault As cSurvey.Surface.cElevation = Survey.Surface.Elevations.Default
    '        Dim oOriginPos As cSurvey.cCoordinate = oDefault.GetCoordinate(Surface.cElevation.GetCoordinateCornerEnum.TopLeft)
    '        Dim oOriginUTM As modUTM.UTM = modUTM.WGS84ToUTM(oOriginPos)
    '        'da cambiare con i dati corretti
    '        Call oXMLElevation.SetAttribute("c", modNumbers.NumberToString(oOriginUTM.East) & ";" & modNumbers.NumberToString(oOriginUTM.North) & ";" & modNumbers.NumberToString(0))
    '        Call oXMLElevation.SetAttribute("rows", oDefault.Rows)
    '        Call oXMLElevation.SetAttribute("cols", oDefault.Columns)
    '        Call oXMLElevation.SetAttribute("sizex", modNumbers.NumberToString(oDefault.XSize))
    '        Call oXMLElevation.SetAttribute("sizey", modNumbers.NumberToString(oDefault.YSize))
    '        Call oXMLElevation.SetAttribute("nodatavalue", modNumbers.NumberToString(modNumbers.MathRound(oDefault.NoDataValue, 0)))
    '        Dim oData As System.Text.StringBuilder = New System.Text.StringBuilder
    '        For iRow As Integer = 0 To oDefault.Rows - 1
    '            For iCol As Integer = 0 To oDefault.Columns - 1
    '                Call oData.Append(modNumbers.NumberToString(modNumbers.MathRound(oDefault(iRow, iCol), 0)) & " ")
    '            Next
    '            Call oData.AppendLine()
    '        Next
    '        oXMLElevation.InnerText = oData.ToString
    '    End If
    '    Call oXMLRoot.AppendChild(oXMLElevation)
    '    Call oXML.AppendChild(oXMLRoot)
    '    Call XMLAddDeclaration(oXML)
    '    Call oXML.Save(Filename & ".elevation.xml")
    'End Sub

    'Private Sub pHolosExportTexture(Survey As cSurvey.cSurvey, Filename As String, Options As cHolosExportOptions)
    '    Dim oElevation As cSurvey.Surface.cElevation = Survey.Surface.Elevations.Default
    '    If Not oElevation Is Nothing Then
    '        Dim oPos As cSurvey.cCoordinate = oElevation.GetCoordinate(Surface.cElevation.GetCoordinateCornerEnum.TopLeft)
    '        Dim oPosUTM As modUTM.UTM = modUTM.WGS84ToUTM(oPos)
    '        Dim iWidth As Integer = oElevation.Columns
    '        Dim iHeight As Integer = oElevation.Rows
    '        Dim sXSize As Single = oElevation.XSize
    '        Dim sYSize As Single = oElevation.YSize
    '        For Each oOrtophoto As cSurvey.Surface.cOrthoPhoto In Survey.Surface.OrthoPhotos
    '            'If oOrtophoto.ShowIn3D Then
    '            Dim oTextureImage As Image = oOrtophoto.Photo
    '            Dim oTexturePos1 As cSurvey.cCoordinate = oOrtophoto.GetCoordinate(Surface.cElevation.GetCoordinateCornerEnum.TopLeft)
    '            Dim oTexturePos2 As cSurvey.cCoordinate = oOrtophoto.GetCoordinate(Surface.cElevation.GetCoordinateCornerEnum.BottomRight)
    '            Dim oTextureUTM1 As modUTM.UTM = modUTM.WGS84ToUTM(oTexturePos1)
    '            Dim oTextureUTM2 As modUTM.UTM = modUTM.WGS84ToUTM(oTexturePos2)
    '            Dim iTextureLeft As Integer = (oTextureUTM1.East - oPosUTM.East) / sXSize
    '            Dim iTextureTop As Integer = (oPosUTM.North - oTextureUTM1.North) / sYSize
    '            Dim iTextureWidth As Integer = (oTextureUTM2.East - oTextureUTM1.East) / sXSize
    '            Dim iTextureHeight As Integer = (oTextureUTM1.North - oTextureUTM2.North) / sYSize

    '            For iScale As Integer = 1 To Options.ScaleStep - 1
    '                Dim sScaleFactor As Single = Options.ScaleFactor ^ iScale
    '                Dim sTextureFilename As String = Filename & "." & pHolosGetSafeFilename(oOrtophoto.Name) & "_" & iScale & ".jpg"

    '                Dim sScale As Single = (oTextureImage.Width / iTextureWidth) / sScaleFactor
    '                Dim iScaledWidth As Integer = iWidth * sScale
    '                Dim iScaledHeight As Integer = iHeight * sScale

    '                Using oImage As Image = New Bitmap(iScaledWidth, iScaledHeight)
    '                    Using oGr As Graphics = Graphics.FromImage(oImage)
    '                        Call oGr.DrawImage(oTextureImage, iTextureLeft * sScale, iTextureTop * sScale, iTextureWidth * sScale, iTextureHeight * sScale)
    '                        Call oImage.Save(sTextureFilename)
    '                    End Using
    '                End Using
    '            Next
    '            'End If
    '        Next
    '    End If
    'End Sub

    'Private Sub pHolosExportCave(Survey As cSurvey.cSurvey, Filename As String, Options As cHolosExportOptions)
    '    Dim bLRUD As Boolean = (Options.Options And HolosExportOptionsEnum.LRUDdata) = HolosExportOptionsEnum.LRUDdata
    '    Dim bColor As Boolean = (Options.Options And HolosExportOptionsEnum.Colors) = HolosExportOptionsEnum.Colors
    '    For Each oCaveInfo As cCaveInfo In Survey.Properties.CaveInfos
    '        Dim oXML As XmlDocument = New XmlDocument
    '        Dim oXMLRoot As XmlElement = oXML.CreateElement("holos")
    '        Call oXMLRoot.SetAttribute("version", "1")
    '        Dim oXMLCave As XmlElement = oXML.CreateElement("cave")
    '        Call oXMLCave.SetAttribute("name", oCaveInfo.Name)
    '        Call oXMLCave.SetAttribute("id", oCaveInfo.ID)
    '        Dim oColor As Color = oCaveInfo.Color
    '        Call oXMLCave.SetAttribute("color", ColorTranslator.ToHtml(oColor))
    '        Call oXMLCave.SetAttribute("lrud", IIf(bLRUD, "1", "0"))

    '        Dim oTrigpoints As cTrigPointCollection = New cTrigPointCollection(Survey)
    '        Dim oSegments As cSegmentCollection = Survey.Segments.GetCaveSegments(oCaveInfo)

    '        Dim oXMLPlot As XmlElement = oXML.CreateElement("plot")

    '        Dim oEntrance As cTrigPoint = Survey.TrigPoints.GetCaveFirstEntrance(oCaveInfo, cTrigPoint.EntranceTypeEnum.MainCaveEntrace)
    '        If oEntrance Is Nothing Then
    '            oEntrance = Survey.TrigPoints.GetOrigin
    '        End If
    '        Dim sOrigin As String = oEntrance.Name
    '        Call oXMLPlot.SetAttribute("origin", sOrigin)
    '        Dim oOriginPos As Calculate.cTrigPointCoordinate = Survey.Calculate.TrigPoints(sOrigin).Coordinate
    '        Dim oOriginUTM As modUTM.UTM = modUTM.WGS84ToUTM(oOriginPos.Longitude, oOriginPos.Latitude)
    '        Call oXMLPlot.SetAttribute("c", modNumbers.NumberToString(oOriginUTM.East) & ";" & modNumbers.NumberToString(oOriginUTM.North) & ";" & modNumbers.NumberToString(oOriginPos.Altitude))

    '        Dim oXMLPoints As XmlElement = oXML.CreateElement("stations")
    '        Dim oXMLSegments As XmlElement = oXML.CreateElement("shots")

    '        Dim oPointPlans As Dictionary(Of String, PointF) = New Dictionary(Of String, PointF)
    '        Dim oPointProfiles As Dictionary(Of String, PointF) = New Dictionary(Of String, PointF)

    '        Dim oPointUps As Dictionary(Of String, PointF) = New Dictionary(Of String, PointF)
    '        Dim oPointDowns As Dictionary(Of String, PointF) = New Dictionary(Of String, PointF)
    '        Dim oPointLefts As Dictionary(Of String, PointF) = New Dictionary(Of String, PointF)
    '        Dim oPointRights As Dictionary(Of String, PointF) = New Dictionary(Of String, PointF)

    '        For Each oSegment As cSegment In oSegments
    '            If oSegment.IsValid Then
    '                Dim oFrom As cTrigPoint = oSegment.GetFromTrigPoint
    '                Dim oTo As cTrigPoint = oSegment.GetToTrigPoint
    '                If Not oTrigpoints.Contains(oFrom) Then oTrigpoints.Append(oFrom)
    '                If Not oTrigpoints.Contains(oTo) Then oTrigpoints.Append(oTo)
    '                If Not oSegment.IsSelfDefined Then
    '                    Dim oXMLSegment As XmlElement = oXML.CreateElement("shot")
    '                    Dim sFrom As String = oFrom.Name
    '                    Dim sTo As String = oTo.Name

    '                    Call oXMLSegment.SetAttribute("f", sFrom)
    '                    Call oXMLSegment.SetAttribute("t", sTo)
    '                    If bColor Then Call oXMLSegment.SetAttribute("color", ColorTranslator.ToHtml(Survey.Properties.CaveInfos.GetColor(oSegment, oColor)))
    '                    Call oXMLSegments.AppendChild(oXMLSegment)

    '                    If Not oPointPlans.ContainsKey(sFrom) Then
    '                        Call oPointPlans.Add(sFrom, oSegment.Data.Plan.FromPoint)
    '                        Call oPointProfiles.Add(sFrom, oSegment.Data.Profile.FromPoint)
    '                        'End If
    '                        'If Not oPointUps.ContainsKey(sFrom) Then
    '                        If bLRUD Then
    '                            Call oPointUps.Add(sFrom, oSegment.Data.Profile.FromSidePointUp)
    '                            Call oPointDowns.Add(sFrom, oSegment.Data.Profile.FromSidePointDown)
    '                            Call oPointLefts.Add(sFrom, oSegment.Data.Plan.FromSidePointLeft)
    '                            Call oPointRights.Add(sFrom, oSegment.Data.Plan.FromSidePointRight)
    '                        End If
    '                    End If

    '                    If Not oPointPlans.ContainsKey(sTo) Then
    '                        Call oPointPlans.Add(sTo, oSegment.Data.Plan.ToPoint)
    '                        Call oPointProfiles.Add(sTo, oSegment.Data.Profile.ToPoint)
    '                        'End If
    '                        'If Not oPointLefts.ContainsKey(sTo) Then
    '                        If bLRUD Then
    '                            Call oPointUps.Add(sTo, oSegment.Data.Profile.ToSidePointUp)
    '                            Call oPointDowns.Add(sTo, oSegment.Data.Profile.ToSidePointDown)
    '                            Call oPointLefts.Add(sTo, oSegment.Data.Plan.ToSidePointLeft)
    '                            Call oPointRights.Add(sTo, oSegment.Data.Plan.ToSidePointRight)
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        Next

    '        Dim oEntrancePoint As Calculate.cTrigPointPoint = Survey.Calculate.TrigPoints(oEntrance).Point
    '        For Each oTrigPoint As cTrigPoint In oTrigpoints
    '            Dim oXMLPoint As XmlElement = oXML.CreateElement("station")
    '            Dim sName As String = oTrigPoint.Name
    '            Call oXMLPoint.SetAttribute("name", sName)
    '            Dim oPoint As Calculate.cTrigPointPoint = Survey.Calculate.TrigPoints(sName).Point

    '            Dim x As Decimal = -(oEntrancePoint.X - oPoint.X) ' oUTM.East - oOriginUTM.East
    '            Dim y As Decimal = oEntrancePoint.Y - oPoint.Y  'oUTM.North - oOriginUTM.North
    '            Dim z As Decimal = oEntrancePoint.Z - oPoint.Z ' oPos.Altitude - oOriginPos.Altitude
    '            Call oXMLPoint.SetAttribute("c", modNumbers.NumberToString(x) & ";" & modNumbers.NumberToString(y) & ";" & modNumbers.NumberToString(z))

    '            Dim oPointPlan As PointF = oPointPlans(sName)
    '            Dim oPointProfile As PointF = oPointProfiles(sName)

    '            'If oPointLefts.ContainsKey(sName) Then
    '            If bLRUD Then
    '                Dim oPointLeft As PointF = oPointLefts(sName)
    '                Dim xLeft As Decimal = oPointLeft.X - oPointPlan.X
    '                Dim yLeft As Decimal = oPointLeft.Y - oPointPlan.Y
    '                Dim zLeft As Decimal = 0
    '                If xLeft <> 0 Or yLeft <> 0 Or zLeft <> 0 Then
    '                    Call oXMLPoint.SetAttribute("l", modNumbers.NumberToString(xLeft) & ";" & modNumbers.NumberToString(yLeft) & ";" & modNumbers.NumberToString(zLeft))
    '                End If

    '                Dim oPointRight As PointF = oPointRights(sName)
    '                Dim xRight As Decimal = oPointRight.X - oPointPlan.X
    '                Dim yRight As Decimal = oPointRight.Y - oPointPlan.Y
    '                Dim zRight As Decimal = 0
    '                If xRight <> 0 Or yRight <> 0 Or zRight <> 0 Then
    '                    Call oXMLPoint.SetAttribute("r", modNumbers.NumberToString(xRight) & ";" & modNumbers.NumberToString(yRight) & ";" & modNumbers.NumberToString(zRight))
    '                End If

    '                Dim oPointUp As PointF = oPointUps(sName)
    '                Dim xUp As Decimal = 0
    '                Dim yUp As Decimal = 0
    '                Dim zUp As Decimal = -(oPointUp.Y - oPointProfile.Y)
    '                If xUp <> 0 Or yUp <> 0 Or zUp <> 0 Then
    '                    Call oXMLPoint.SetAttribute("u", modNumbers.NumberToString(xUp) & ";" & modNumbers.NumberToString(yUp) & ";" & modNumbers.NumberToString(zUp))
    '                End If

    '                Dim oPointDown As PointF = oPointDowns(sName)
    '                Dim xDown As Decimal = 0
    '                Dim yDown As Decimal = 0
    '                Dim zDown As Decimal = -(oPointDown.Y - oPointProfile.Y)
    '                If xDown <> 0 Or yDown <> 0 Or zDown <> 0 Then
    '                    Call oXMLPoint.SetAttribute("d", modNumbers.NumberToString(xDown) & ";" & modNumbers.NumberToString(yDown) & ";" & modNumbers.NumberToString(zDown))
    '                End If
    '            End If

    '            Call oXMLPoints.AppendChild(oXMLPoint)
    '        Next

    '        Call oXMLPlot.AppendChild(oXMLPoints)
    '        Call oXMLPlot.AppendChild(oXMLSegments)
    '        Call oXMLCave.AppendChild(oXMLPlot)
    '        Call oXMLRoot.AppendChild(oXMLCave)

    '        Call oXML.AppendChild(oXMLRoot)
    '        Call XMLAddDeclaration(oXML)
    '        Call oXML.Save(Filename & "." & pHolosGetSafeFilename(oCaveInfo.Name) & ".cave.xml")
    '    Next
    'End Sub

    'Private Function pHolosGetSafeFilename(Text As String) As String
    '    Text = Text.Replace(" ", "_")
    '    Text = Text.Replace("'", "")
    '    Text = Text.Replace("-", "")
    '    Text = Text.Replace(".", "")
    '    Text = Text.Replace("(", "_")
    '    Text = Text.Replace(")", "_")
    '    Text = Text.ToLower
    '    Return Text
    'End Function

    '    main.textpart15=Da
    'main.textpart16=A
    'main.textpart17=Distanza planimetrica
    'main.textpart18=Dislivello
    'main.textpart19=Vettore di disegno
    'main.textpart19a=Inverso
    'main.textpart19b=Diretto
    'main.textpart20=Verso battuta in sezione
    'main.textpart20a=Sinistra
    'main.textpart20b=Destra
    'main.textpart21=Escluso dai calcoli
    'main.textpart22=Si
    'main.textpart23=No
    'main.textpart24=Splay
    'main.textpart25=Nome
    'main.textpart26=X
    'main.textpart27=Y
    'main.textpart28=Z/Dislivello (da origine)
    'main.textpart29=Ingresso
    'main.textpart30=Punto esterno
    'main.textpart31=Latitudine
    'main.textpart32=Longitudine
    'main.textpart33=Altitudine
    'main.textpart34=Distanza
    'main.textpart35=Azimut
    'main.textpart36=Inclinazione
    'main.textpart37=X
    'main.textpart38=Y
    'main.textpart39=Z
    'main.textpart40=[Predefinito]
    'main.textpart41=Personalizzato

    Public Delegate Sub GetGridCellValueDelegate(Cell As DataGridViewCell, ByRef Value As Object)
    Public Delegate Sub GetGridHeaderValueDelegate(Column As DataGridViewColumn, ByRef Value As Object)

    Public Sub GridExportToCSV(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Grid As DataGridView, Name As String, ByVal Filename As String, Optional GetCellValueDelegate As GetGridCellValueDelegate = Nothing, Optional GetHeaderValueDelegate As GetGridHeaderValueDelegate = Nothing)
        Dim oFileinfo As IO.FileInfo = New IO.FileInfo(Filename)
        If oFileinfo.Exists Then oFileinfo.Delete()

        Using oSW As StreamWriter = oFileinfo.CreateText
            Dim r As Integer = 1
            Dim c As Integer = 1
            For Each oColumn As DataGridViewColumn In Grid.Columns
                Dim oValue As Object = oColumn.HeaderText
                If Not IsNothing(GetHeaderValueDelegate) Then
                    Call GetHeaderValueDelegate(oColumn, oValue)
                End If
                Call oSW.Write(String.Format("""{0}"";", oValue.ToString.Replace("""", """""")))
                c += 1
            Next
            Call oSW.WriteLine("")
            r += 1
            c = 1
            For Each oRow As DataGridViewRow In Grid.Rows
                If Not oRow.IsNewRow Then
                    For Each oCell As DataGridViewCell In oRow.Cells
                        Dim oValue As Object = oCell.Value
                        If Not IsNothing(GetCellValueDelegate) Then
                            Call GetCellValueDelegate(oCell, oValue)
                        End If
                        Dim sValue As String
                        If oValue Is Nothing Then
                            sValue = ""
                        Else
                            sValue = oValue.ToString
                        End If
                        Call oSW.Write(String.Format("""{0}"";", sValue.Replace("""", """""")))
                        c += 1
                    Next
                    Call oSW.WriteLine("")
                End If
                c = 1
                r += 1
            Next
            Call oSW.Close()
        End Using
    End Sub

    'Public Sub ListviewExportToCSV(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Listview As BrightIdeasSoftware.ObjectListView, Name As String, ByVal Filename As String, Optional GetCellValueDelegate As GetOLVCellValueDelegate = Nothing, Optional GetHeaderValueDelegate As GetOLVHeaderValueDelegate = Nothing)
    '    Dim oFileinfo As IO.FileInfo = New IO.FileInfo(Filename)
    '    If oFileinfo.Exists Then oFileinfo.Delete()

    '    Using oSW As StreamWriter = oFileinfo.CreateText
    '        Dim r As Integer = 1
    '        Dim c As Integer = 1
    '        For Each oColumn As OLVColumn In Listview.Columns
    '            Dim oValue As Object = oColumn.Text
    '            If Not IsNothing(GetHeaderValueDelegate) Then
    '                Call GetHeaderValueDelegate(oColumn, oValue)
    '            End If
    '            Call oSW.Write(String.Format("""{0}"";", oValue.ToString.Replace("""", """""")))
    '            c += 1
    '        Next
    '        Call oSW.WriteLine("")
    '        r += 1
    '        c = 1
    '        Dim iIndex As Integer
    '        Do While iIndex < Listview.GetItemCount()
    '            Dim oItem As OLVListItem = Listview.GetItem(iIndex)
    '            For Each oColumn As OLVColumn In Listview.Columns
    '                Dim oValue As Object = oItem.SubItems(oColumn.Index).Text
    '                If Not IsNothing(GetCellValueDelegate) Then
    '                    Call GetCellValueDelegate(oItem.RowObject, oColumn, oValue)
    '                End If
    '                Dim sValue As String
    '                If oValue Is Nothing Then
    '                    sValue = ""
    '                Else
    '                    sValue = oValue.ToString
    '                End If
    '                Call oSW.Write(String.Format("""{0}"";", sValue.Replace("""", """""")))
    '                c += 1
    '            Next
    '            Call oSW.WriteLine("")
    '            c = 1
    '            r += 1
    '            iIndex += 1
    '        Loop
    '        Call oSW.Close()
    '    End Using
    'End Sub

    'Public Sub ListviewExportTo(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Listview As BrightIdeasSoftware.ObjectListView, Name As String, Optional ByVal Filename As String = "", Optional Owner As IWin32Window = Nothing, Optional GetCellValueDelegate As GetOLVCellValueDelegate = Nothing, Optional GetHeaderValueDelegate As GetOLVHeaderValueDelegate = Nothing)
    '    If Filename = "" Then
    '        Using oSFD As SaveFileDialog = New SaveFileDialog
    '            With oSFD
    '                .Title = GetLocalizedString("main.exportgriddialog")
    '                .Filter = GetLocalizedString("main.filetypeXLSX") & " (*.XLSX)|*.XLSX|" & GetLocalizedString("main.filetypeCSV") & " (*.CSV)|*.CSV"
    '                .FilterIndex = 1
    '                .OverwritePrompt = True
    '                .CheckPathExists = True
    '                If .ShowDialog(Owner) = Windows.Forms.DialogResult.OK Then
    '                    Filename = .FileName
    '                End If
    '            End With
    '        End Using
    '    End If
    '    If Filename <> "" Then
    '        Select Case IO.Path.GetExtension(Filename).ToLower
    '            Case ".xlsx"
    '                Call ListViewExportToExcel(Survey, Listview, Name, Filename, GetCellValueDelegate, GetHeaderValueDelegate)
    '            Case Else
    '                Call ListViewExportToCSV(Survey, Listview, Name, Filename, GetCellValueDelegate, GetHeaderValueDelegate)
    '        End Select
    '    End If
    'End Sub

    'Public Delegate Sub GetOLVCellValueDelegate(Item As Object, Column As OLVColumn, ByRef Value As Object)
    'Public Delegate Sub GetOLVHeaderValueDelegate(Column As OLVColumn, ByRef Value As Object)

    'Public Sub ListViewExportToExcel(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Listview As BrightIdeasSoftware.ObjectListView, Name As String, ByVal Filename As String, Optional GetCellValueDelegate As GetOLVCellValueDelegate = Nothing, Optional GetHeaderValueDelegate As GetOLVHeaderValueDelegate = Nothing)
    '    Dim oFileinfo As IO.FileInfo = New IO.FileInfo(Filename)
    '    If oFileinfo.Exists Then oFileinfo.Delete()
    '    Using oXLS As OfficeOpenXml.ExcelPackage = New OfficeOpenXml.ExcelPackage(oFileinfo)
    '        Using oXLSSheet As OfficeOpenXml.ExcelWorksheet = oXLS.Workbook.Worksheets.Add(Name)
    '            Dim r As Integer = 1
    '            Dim c As Integer = 1
    '            For Each oColumn As OLVColumn In Listview.Columns
    '                Dim oValue As Object = oColumn.Text
    '                If Not IsNothing(GetHeaderValueDelegate) Then
    '                    Call GetHeaderValueDelegate(oColumn, oValue)
    '                End If
    '                oXLSSheet.Cells(r, c).Value = oValue
    '                c += 1
    '            Next
    '            oXLSSheet.Row(r).Style.Font.Bold = True
    '            r += 1
    '            c = 1
    '            Dim iIndex As Integer = 0
    '            Do While iIndex < Listview.GetItemCount()
    '                Dim oItem As OLVListItem = Listview.GetItem(iIndex)
    '                For Each oColumn As OLVColumn In Listview.Columns
    '                    Dim oValue As Object = oItem.SubItems(oColumn.Index).Text
    '                    If Not IsNothing(GetCellValueDelegate) Then
    '                        Call GetCellValueDelegate(oItem.RowObject, oColumn, oValue)
    '                    End If
    '                    oXLSSheet.Cells(r, c).Value = oValue
    '                    c += 1
    '                Next
    '                c = 1
    '                r += 1
    '                iIndex += 1
    '            Loop
    '            Call oXLS.Save()
    '        End Using
    '    End Using
    'End Sub

    Public Sub GridExportToExcel(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Grid As DataGridView, Name As String, ByVal Filename As String, Optional GetCellValueDelegate As GetGridCellValueDelegate = Nothing, Optional GetHeaderValueDelegate As GetGridHeaderValueDelegate = Nothing)
        Dim oFileinfo As IO.FileInfo = New IO.FileInfo(Filename)
        If oFileinfo.Exists Then oFileinfo.Delete()
        Using oXLS As OfficeOpenXml.ExcelPackage = New OfficeOpenXml.ExcelPackage(oFileinfo)
            Using oXLSSheet As OfficeOpenXml.ExcelWorksheet = oXLS.Workbook.Worksheets.Add(Name)
                Dim r As Integer = 1
                Dim c As Integer = 1
                For Each oColumn As DataGridViewColumn In Grid.Columns
                    Dim oValue As Object = oColumn.HeaderCell.Value
                    If Not IsNothing(GetHeaderValueDelegate) Then
                        Call GetHeaderValueDelegate(oColumn, oValue)
                    End If
                    oXLSSheet.Cells(r, c).Value = oValue
                    c += 1
                Next
                oXLSSheet.Row(r).Style.Font.Bold = True
                r += 1
                c = 1
                For Each oRow As DataGridViewRow In Grid.Rows
                    If Not oRow.IsNewRow Then
                        For Each oCell As DataGridViewCell In oRow.Cells
                            Dim oValue As Object = oCell.Value
                            If Not IsNothing(GetCellValueDelegate) Then
                                Call GetCellValueDelegate(oCell, oValue)
                            End If
                            oXLSSheet.Cells(r, c).Value = oValue
                            c += 1
                        Next
                    End If
                    c = 1
                    r += 1
                Next
                Call oXLS.Save()
            End Using
        End Using
    End Sub

    Public Sub GridExportTo(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Grid As DevExpress.XtraVerticalGrid.VGridControl, Name As String, Optional ByVal Filename As String = "", Optional Owner As IWin32Window = Nothing)
        If Filename = "" Then
            Using oSFD As SaveFileDialog = New SaveFileDialog
                With oSFD
                    .Title = GetLocalizedString("main.exportgriddialog")
                    .Filter = GetLocalizedString("main.filetypeXLSX") & " (*.XLSX)|*.XLSX|" & GetLocalizedString("main.filetypeCSV") & " (*.CSV)|*.CSV"
                    .FilterIndex = 1
                    .OverwritePrompt = True
                    .CheckPathExists = True
                    If .ShowDialog(Owner) = Windows.Forms.DialogResult.OK Then
                        Filename = .FileName
                    End If
                End With
            End Using
        End If
        If Filename <> "" Then
            Select Case IO.Path.GetExtension(Filename).ToLower
                Case ".xls"
                    Grid.ExportToXls(Filename)
                Case ".xlsx"
                    Grid.ExportToXlsx(Filename)
                Case ".txt"
                    Grid.ExportToText(Filename)
                Case Else
                    Grid.ExportToCSV(Filename)
            End Select
        End If
    End Sub

    Public Sub ChartExportTo(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Chart As DevExpress.XtraCharts.ChartControl, Name As String, Optional ByVal Filename As String = "", Optional Owner As IWin32Window = Nothing)
        If Filename = "" Then
            Using oSFD As SaveFileDialog = New SaveFileDialog
                With oSFD
                    .Title = GetLocalizedString("main.exportchartdialog")
                    .Filter = GetLocalizedString("main.filetypePDF") & " (*.PDF)|*.PDF|" & GetLocalizedString("main.filetypeJPG") & " (*.JPG)|*.JPG|" & GetLocalizedString("main.filetypePNG") & " (*.PNG)|*.PNG|" & GetLocalizedString("main.filetypeTIF") & " (*.TIF)|*.TIF|" & GetLocalizedString("main.filetypeXLSX") & " (*.XLSX)|*.XLSX|" & GetLocalizedString("main.filetypeDOCX") & " (*.DOCX)|*.DOCX|" & GetLocalizedString("main.filetypeSVG") & " (*.SVG)|*.SVG"
                    .FilterIndex = 1
                    .OverwritePrompt = True
                    .CheckPathExists = True
                    If .ShowDialog(Owner) = Windows.Forms.DialogResult.OK Then
                        Filename = .FileName
                    End If
                End With
            End Using
        End If
        If Filename <> "" Then
            Select Case IO.Path.GetExtension(Filename).ToLower
                Case ".docx"
                    Chart.ExportToDocx(Filename)
                Case ".pdf"
                    Chart.ExportToPdf(Filename)
                Case ".xls"
                    Chart.ExportToXls(Filename)
                Case ".xlsx"
                    Chart.ExportToXlsx(Filename)
                Case ".svg"
                    Chart.ExportToSvg(Filename)
                Case ".png"
                    Chart.ExportToImage(Filename, Imaging.ImageFormat.Png)
                Case ".jpg", ".jpeg"
                    Chart.ExportToImage(Filename, Imaging.ImageFormat.Jpeg)
                Case ".tif", ".tiff"
                    Chart.ExportToImage(Filename, Imaging.ImageFormat.Tiff)
                Case Else
                    Chart.ExportToDocx(Filename)
            End Select
        End If
    End Sub

    Public Sub GridExportTo(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Grid As DevExpress.XtraGrid.GridControl, Name As String, Optional ByVal Filename As String = "", Optional Owner As IWin32Window = Nothing)
        If Filename = "" Then
            Using oSFD As SaveFileDialog = New SaveFileDialog
                With oSFD
                    .Title = GetLocalizedString("main.exportgriddialog")
                    .Filter = GetLocalizedString("main.filetypeXLSX") & " (*.XLSX)|*.XLSX|" & GetLocalizedString("main.filetypeCSV") & " (*.CSV)|*.CSV"
                    .FilterIndex = 1
                    .OverwritePrompt = True
                    .CheckPathExists = True
                    If .ShowDialog(Owner) = Windows.Forms.DialogResult.OK Then
                        Filename = .FileName
                    End If
                End With
            End Using
        End If
        If Filename <> "" Then
            Select Case IO.Path.GetExtension(Filename).ToLower
                Case ".xls"
                    Grid.ExportToXls(Filename)
                Case ".xlsx"
                    Grid.ExportToXlsx(Filename)
                Case ".txt"
                    Grid.ExportToText(Filename)
                Case Else
                    Grid.ExportToCsv(Filename)
            End Select
        End If
    End Sub

    Public Sub GridExportTo(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Grid As DataGridView, Name As String, Optional ByVal Filename As String = "", Optional Owner As IWin32Window = Nothing, Optional GetCellValueDelegate As GetGridCellValueDelegate = Nothing, Optional GetHeaderValueDelegate As GetGridHeaderValueDelegate = Nothing)
        If Filename = "" Then
            Using oSFD As SaveFileDialog = New SaveFileDialog
                With oSFD
                    .Title = GetLocalizedString("main.exportgriddialog")
                    .Filter = GetLocalizedString("main.filetypeXLSX") & " (*.XLSX)|*.XLSX|" & GetLocalizedString("main.filetypeCSV") & " (*.CSV)|*.CSV"
                    .FilterIndex = 1
                    .OverwritePrompt = True
                    .CheckPathExists = True
                    If .ShowDialog(Owner) = Windows.Forms.DialogResult.OK Then
                        Filename = .FileName
                    End If
                End With
            End Using
        End If
        If Filename <> "" Then
            Select Case IO.Path.GetExtension(Filename).ToLower
                Case ".xlsx"
                    Call GridExportToExcel(Survey, Grid, Name, Filename, GetCellValueDelegate, GetHeaderValueDelegate)
                Case Else
                    Call GridExportToCSV(Survey, Grid, Name, Filename, GetCellValueDelegate, GetHeaderValueDelegate)
            End Select
        End If
    End Sub

    <Flags> Public Enum ExcelExportOptionsEnum
        CalculatedData = &H1
        NamedSplayStation = &H2
        NamedSplayStationData = &H4
        Colors = &H100
    End Enum

    Private Function pExcelNextColumn(ByRef Column As Integer, Optional Increment As Integer = 1) As Integer
        Column += Increment
        Return Column
    End Function

    Public Sub ExcelExportTo(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Filename As String, Options As ExcelExportOptionsEnum)
        Dim oFileinfo As IO.FileInfo = New IO.FileInfo(Filename)
        If oFileinfo.Exists Then oFileinfo.Delete()
        Dim bColors As Boolean = (Options And ExcelExportOptionsEnum.Colors) = ExcelExportOptionsEnum.Colors
        Dim bCalculatedData As Boolean = (Options And ExcelExportOptionsEnum.CalculatedData) = ExcelExportOptionsEnum.CalculatedData
        Dim bNamedSplayStation As Boolean = (Options And ExcelExportOptionsEnum.NamedSplayStation) = ExcelExportOptionsEnum.NamedSplayStation
        Dim bNamedSplayStationData As Boolean = (Options And ExcelExportOptionsEnum.NamedSplayStationData) = ExcelExportOptionsEnum.NamedSplayStationData
        Using oXLS As OfficeOpenXml.ExcelPackage = New OfficeOpenXml.ExcelPackage(oFileinfo)
            Using oXLSSegment As OfficeOpenXml.ExcelWorksheet = oXLS.Workbook.Worksheets.Add(modMain.GetLocalizedString("main.textpart110"))
                Dim sLastSession As String = "@@@@@@@@"

                Dim r As Integer = 1
                Dim c As Integer = 0
                For Each oSegment As cSegment In Survey.Segments
                    If sLastSession <> oSegment.Session Then
                        c = 0

                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart13")
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart11")
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart12")
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart15")
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart16")
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = GetMeasureName(oSegment, MeasureEnum.Distance)
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = GetMeasureName(oSegment, MeasureEnum.Bearing)
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = GetMeasureName(oSegment, MeasureEnum.Inclination)
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart20a")
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart20b")
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart20c")
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart20d")

                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart134")
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart135")
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart136")
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart137")
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart138")

                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart139")
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart140")

                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart141")

                        If bCalculatedData Then
                            oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = GetLocalizedString("main.textpart34")
                            oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = GetLocalizedString("main.textpart35")
                            oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = GetLocalizedString("main.textpart36")
                        End If

                        For Each oDataField As Data.cDataField In Survey.Properties.DataTables.Segments
                            oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = If(oDataField.Category = "", "", oDataField.Category & "/") & oDataField.Name
                        Next

                        oXLSSegment.Row(r).Style.Font.Bold = True

                        r += 1
                    End If

                    c = 0
                    oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = oSegment.Session
                    If bColors Then
                        Dim oSessionColor As Color = Survey.Properties.Sessions.GetColor(oSegment, Color.Transparent)
                        If Not (oSessionColor = Color.Transparent) Then
                            oXLSSegment.Cells(r, c).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                            oXLSSegment.Cells(r, c).Style.Fill.BackgroundColor.SetColor(oSessionColor)
                        End If
                    End If
                    oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = oSegment.Cave
                    If bColors Then
                        Dim oCaveBranchColor As Color = Survey.Properties.CaveInfos.GetColor(oSegment, Color.Transparent)
                        If Not (oCaveBranchColor = Color.Transparent) Then
                            oXLSSegment.Cells(r, c).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                            oXLSSegment.Cells(r, c).Style.Fill.BackgroundColor.SetColor(oCaveBranchColor)
                        End If
                    End If
                    oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = oSegment.Branch
                    If bColors Then
                        Dim oCaveBranchColor As Color = Survey.Properties.CaveInfos.GetColor(oSegment, Color.Transparent)
                        If Not (oCaveBranchColor = Color.Transparent) Then
                            oXLSSegment.Cells(r, c).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                            oXLSSegment.Cells(r, c).Style.Fill.BackgroundColor.SetColor(oCaveBranchColor)
                        End If
                    End If

                    oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = oSegment.[From]
                    If (oSegment.Splay AndAlso bNamedSplayStation) OrElse (Not oSegment.Splay) Then
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = oSegment.[To]
                    Else
                        pExcelNextColumn(c)
                    End If

                    oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = oSegment.Distance
                    oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = oSegment.Bearing
                    oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = oSegment.Inclination

                    oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = oSegment.Left
                    oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = oSegment.Right
                    oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = oSegment.Up
                    oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = oSegment.Down

                    oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = If(oSegment.Direction = cSurvey.cSurvey.DirectionEnum.Right, modMain.GetLocalizedString("main.textpart20a"), If(oSegment.Direction = cSurvey.cSurvey.DirectionEnum.Left, modMain.GetLocalizedString("main.textpart20b"), modMain.GetLocalizedString("main.textpart20e")))
                    oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = If(oSegment.Exclude, "✔", "")
                    oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = If(oSegment.Splay, "✔", "")
                    oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = If(oSegment.Surface, "✔", "")
                    oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = If(oSegment.Duplicate, "✔", "")

                    oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = If(oSegment.Virtual, "✔", "")
                    oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = If(oSegment.Calibration, "✔", "")

                    oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = oSegment.Note

                    If bCalculatedData Then
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modNumbers.MathRound(oSegment.Data.Data.Distance, 2)
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modNumbers.MathRound(oSegment.Data.Data.Bearing, 2)
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = modNumbers.MathRound(oSegment.Data.Data.Inclination, 2)
                    End If

                    For Each oDataField As Data.cDataField In Survey.Properties.DataTables.Segments
                        oXLSSegment.Cells(r, pExcelNextColumn(c)).Value = oSegment.DataProperties.GetValue(oDataField.Name)
                    Next

                    sLastSession = oSegment.Session

                    r += 1
                Next

                r = 2
                c = 0
                Dim oXLSTrigpoint As OfficeOpenXml.ExcelWorksheet = oXLS.Workbook.Worksheets.Add(modMain.GetLocalizedString("main.textpart111"))
                oXLSTrigpoint.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart142")

                oXLSTrigpoint.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart113")
                oXLSTrigpoint.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart114")
                oXLSTrigpoint.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart115")
                oXLSTrigpoint.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart151")

                oXLSTrigpoint.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart150")
                oXLSTrigpoint.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart146")
                oXLSTrigpoint.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart147")
                oXLSTrigpoint.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart148")
                oXLSTrigpoint.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart149")

                oXLSTrigpoint.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart37")
                oXLSTrigpoint.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart38")
                oXLSTrigpoint.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart39")

                oXLSTrigpoint.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart116")
                oXLSTrigpoint.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart117")
                oXLSTrigpoint.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart118")

                For Each oDataField As Data.cDataField In Survey.Properties.DataTables.Trigpoints
                    oXLSTrigpoint.Cells(r, pExcelNextColumn(c)).Value = If(oDataField.Category = "", "", oDataField.Category & "/") & oDataField.Name
                Next

                oXLSTrigpoint.Row(1).Style.Font.Bold = True
                For Each oTrigpoint As cTrigPoint In Survey.TrigPoints
                    If Not oTrigpoint.Data.IsOrphan Then
                        If (Not oTrigpoint.Data.IsSplay) OrElse (oTrigpoint.Data.IsSplay AndAlso bNamedSplayStation AndAlso bNamedSplayStationData) Then
                            c = 0
                            oXLSTrigpoint.Cells(r, pExcelNextColumn(c)).Value = oTrigpoint.Name
                            If oTrigpoint.Coordinate.IsEmpty Then
                                pExcelNextColumn(c, 4)
                            Else
                                oXLSTrigpoint.Cells(r, pExcelNextColumn(c)).Value = oTrigpoint.Coordinate.Latitude
                                oXLSTrigpoint.Cells(r, pExcelNextColumn(c)).Value = oTrigpoint.Coordinate.Longitude
                                oXLSTrigpoint.Cells(r, pExcelNextColumn(c)).Value = oTrigpoint.Coordinate.Altitude
                                oXLSTrigpoint.Cells(r, pExcelNextColumn(c)).Value = oTrigpoint.Coordinate.Fix.ToString
                            End If
                            oXLSTrigpoint.Cells(r, pExcelNextColumn(c)).Value = oTrigpoint.Entrance.ToString
                            oXLSTrigpoint.Cells(r, pExcelNextColumn(c)).Value = oTrigpoint.Type.ToString
                            oXLSTrigpoint.Cells(r, pExcelNextColumn(c)).Value = If(oTrigpoint.IsSpecial, "✔", "")
                            oXLSTrigpoint.Cells(r, pExcelNextColumn(c)).Value = If(oTrigpoint.IsInExploration, "✔", "")
                            oXLSTrigpoint.Cells(r, pExcelNextColumn(c)).Value = oTrigpoint.Note

                            If bCalculatedData Then
                                oXLSTrigpoint.Cells(r, pExcelNextColumn(c)).Value = modNumbers.MathRound(oTrigpoint.Data.X, 2)
                                oXLSTrigpoint.Cells(r, pExcelNextColumn(c)).Value = modNumbers.MathRound(oTrigpoint.Data.Y, 2)
                                oXLSTrigpoint.Cells(r, pExcelNextColumn(c)).Value = modNumbers.MathRound(oTrigpoint.Data.Z, 2)
                                If Survey.Calculate.TrigPoints.Contains(oTrigpoint) Then
                                    Dim oCalculatedTrigpoint As Calculate.cTrigPoint = Survey.Calculate.TrigPoints(oTrigpoint)
                                    If oCalculatedTrigpoint.Coordinate.IsEmpty Then
                                        pExcelNextColumn(c, 3)
                                    Else
                                        oXLSTrigpoint.Cells(r, pExcelNextColumn(c)).Value = oCalculatedTrigpoint.Coordinate.Latitude
                                        oXLSTrigpoint.Cells(r, pExcelNextColumn(c)).Value = oCalculatedTrigpoint.Coordinate.Longitude
                                        oXLSTrigpoint.Cells(r, pExcelNextColumn(c)).Value = oCalculatedTrigpoint.Coordinate.Altitude
                                    End If
                                End If
                            End If

                            For Each oDataField As Data.cDataField In Survey.Properties.DataTables.Trigpoints
                                oXLSTrigpoint.Cells(r, pExcelNextColumn(c)).Value = oTrigpoint.DataProperties.GetValue(oDataField.Name)
                            Next

                            r += 1
                        End If
                    End If
                Next

                r = 2
                c = 0
                Dim oXLSSession As OfficeOpenXml.ExcelWorksheet = oXLS.Workbook.Worksheets.Add(modMain.GetLocalizedString("main.textpart112"))
                oXLSSession.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart119")
                oXLSSession.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart120")
                oXLSSession.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart121")
                oXLSSession.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart122")
                oXLSSession.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart123")
                oXLSSession.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart124")
                oXLSSession.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart125")
                oXLSSession.Row(1).Style.Font.Bold = True
                For Each oSession As cSession In Survey.Properties.Sessions
                    c = 0
                    oXLSSession.Cells(r, pExcelNextColumn(c)).Value = oSession.ID
                    If bColors Then
                        Dim oSessionColor As Color = Survey.Properties.Sessions.GetColor(oSession, Color.Transparent)
                        If Not (oSessionColor = Color.Transparent) Then
                            oXLSSession.Cells(r, c).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                            oXLSSession.Cells(r, c).Style.Fill.BackgroundColor.SetColor(oSessionColor)
                        End If
                    End If
                    oXLSSession.Cells(r, pExcelNextColumn(c)).Value = oSession.Date
                    oXLSSession.Cells(r, c).Style.Numberformat.Format = "dd/mm/yyyy"
                    oXLSSession.Cells(r, pExcelNextColumn(c)).Value = oSession.Description
                    oXLSSession.Cells(r, pExcelNextColumn(c)).Value = oSession.Note
                    oXLSSession.Cells(r, pExcelNextColumn(c)).Value = oSession.Club
                    oXLSSession.Cells(r, pExcelNextColumn(c)).Value = oSession.Team
                    oXLSSession.Cells(r, pExcelNextColumn(c)).Value = oSession.Designer
                    r += 1
                Next

                'caves and branches
                r = 2
                c = 0
                Dim oXLSCaves As OfficeOpenXml.ExcelWorksheet = oXLS.Workbook.Worksheets.Add(modMain.GetLocalizedString("main.textpart126"))
                oXLSCaves.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart131")
                oXLSCaves.Column(2).Hidden = True
                oXLSCaves.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart127")
                oXLSCaves.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart128")
                oXLSCaves.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart129")
                oXLSCaves.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart130")
                oXLSCaves.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart132")
                oXLSCaves.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart133")
                oXLSCaves.Row(1).Style.Font.Bold = True
                For Each oCave As cCaveInfo In Survey.Properties.CaveInfos
                    c = 0
                    oXLSCaves.Cells(r, pExcelNextColumn(c)).Value = oCave.Name
                    If bColors Then
                        Dim oCaveBranchColor As Color = oCave.GetColor(Color.Transparent)
                        If Not (oCaveBranchColor = Color.Transparent) Then
                            oXLSCaves.Cells(r, c).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                            oXLSCaves.Cells(r, c).Style.Fill.BackgroundColor.SetColor(oCaveBranchColor)
                        End If
                    End If
                    oXLSCaves.Cells(r, pExcelNextColumn(c)).Value = oCave.Name
                    oXLSCaves.Cells(r, pExcelNextColumn(c)).Value = oCave.ID
                    oXLSCaves.Cells(r, pExcelNextColumn(c)).Value = oCave.Description
                    oXLSCaves.Cells(r, pExcelNextColumn(c)).Value = oCave.ExtendStart
                    If IsNothing(oCave.ParentConnection) Then
                        pExcelNextColumn(c)
                    Else
                        oXLSCaves.Cells(r, pExcelNextColumn(c)).Value = oCave.ParentConnection.ToString
                    End If
                    If IsNothing(oCave.Connection) Then
                        pExcelNextColumn(c)
                    Else
                        oXLSCaves.Cells(r, pExcelNextColumn(c)).Value = oCave.Connection.ToString
                    End If

                    r += 1

                    Call pExportBranches(Survey, oXLSCaves, oCave, r, 1)
                Next

                If bCalculatedData Then
                    r = 2
                    c = 0
                    If Survey.Calculate.GeoMagDeclinationData.Count > 0 Then
                        Dim oXLSGeoData As OfficeOpenXml.ExcelWorksheet = oXLS.Workbook.Worksheets.Add(modMain.GetLocalizedString("main.textpart145"))
                        oXLSGeoData.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart143")
                        oXLSGeoData.Cells(1, pExcelNextColumn(c)).Value = modMain.GetLocalizedString("main.textpart144")
                        oXLSGeoData.Row(1).Style.Font.Bold = True
                        For Each oGeoDataDate As Date In Survey.Calculate.GeoMagDeclinationData.GetDates
                            c = 0
                            oXLSGeoData.Cells(r, pExcelNextColumn(c)).Value = oGeoDataDate
                            oXLSGeoData.Cells(r, c).Style.Numberformat.Format = "dd/mm/yyyy"
                            oXLSGeoData.Cells(r, pExcelNextColumn(c)).Value = Survey.Calculate.GeoMagDeclinationData.GetValue(oGeoDataDate)

                            r += 1
                        Next
                    End If
                End If

                Call oXLS.Save()
            End Using
        End Using
    End Sub

    Private Sub pExportBranches(Survey As cSurveyPC.cSurvey.cSurvey, XLSCaves As OfficeOpenXml.ExcelWorksheet, Parent As cICaveInfoBranches, ByRef r As Integer, Indent As Integer)
        Dim c As Integer
        For Each oBranch As cCaveInfoBranch In Parent.Branches
            c = 0
            XLSCaves.Cells(r, pExcelNextColumn(c)).Value = Space(Indent * 2) & "└ " & oBranch.Name
            Dim oCaveBranchColor As Color = oBranch.GetColor(Color.Transparent)
            If Not (oCaveBranchColor = Color.Transparent) Then
                XLSCaves.Cells(r, c).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                XLSCaves.Cells(r, c).Style.Fill.BackgroundColor.SetColor(oCaveBranchColor)
            End If
            XLSCaves.Cells(r, pExcelNextColumn(c)).Value = oBranch.Name
            XLSCaves.Cells(r, pExcelNextColumn(c)).Value = oBranch.Description
            XLSCaves.Cells(r, pExcelNextColumn(c)).Value = oBranch.ExtendStart
            If IsNothing(oBranch.ParentConnection) Then
                pExcelNextColumn(c)
            Else
                XLSCaves.Cells(r, pExcelNextColumn(c)).Value = oBranch.ParentConnection.ToString
            End If
            If IsNothing(oBranch.Connection) Then
                pExcelNextColumn(c)
            Else
                XLSCaves.Cells(r, pExcelNextColumn(c)).Value = oBranch.Connection.ToString
            End If

            r += 1

            Call pExportBranches(Survey, XLSCaves, oBranch, r, Indent + 1)
        Next
    End Sub

    '<Flags> Public Enum HolosExportOptionsEnum
    '    SurfaceData = &H1
    '    LRUDdata = &H10
    '    Colors = &H100
    'End Enum

    'Public Enum HolosProfileEnum
    '    ForRegister = 0
    '    ForStandAlone = 1
    'End Enum

    'Public Sub HolosExportTo(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Filename As String, Profile As HolosProfileEnum, Options As HolosExportOptionsEnum)
    '    Dim oOptions As cHolosExportOptions = New cHolosExportOptions
    '    oOptions.ScaleFactor = 1.5
    '    oOptions.ScaleStep = 3
    '    oOptions.Profile = Profile
    '    oOptions.Options = Options
    '    Dim sBaseFilename As String = Path.Combine(Path.GetDirectoryName(Filename), Path.GetFileNameWithoutExtension(Filename))
    '    If Profile = HolosProfileEnum.ForStandAlone Then
    '        Call pHolosExportIndex(Survey, sBaseFilename, oOptions)
    '        Call pHolosExportElevation(Survey, sBaseFilename)
    '        Call pHolosExportTexture(Survey, sBaseFilename, oOptions)
    '    End If
    '    Call pHolosExportCave(Survey, sBaseFilename, oOptions)
    'End Sub

    Public Function DictionaryTranslate(Dictionary As IDictionary(Of String, String), Index As String) As String
        If Dictionary Is Nothing Then
            Return Index
        Else
            If Dictionary.ContainsKey(Index) Then
                Return Dictionary(Index)
            Else
                Return Index
            End If
        End If
    End Function

    Private Function pTherionGetPoint(Point As PointF, Traslation As SizeF, Scale As Single) As PointF
        Return New PointF((Point.X + Traslation.Width) * Scale, (-1 * Point.Y + Traslation.Height) * Scale)
    End Function

    Private Function pTherionGetPoint(Point As cPoint, Traslation As SizeF, Scale As Single) As PointF
        Return New PointF((Point.Point.X + Traslation.Width) * Scale, (-1 * Point.Point.Y + Traslation.Height) * Scale)
        'Dim oPoint As PointF = Point.Point
        'oPoint.Y = -1 * oPoint.Y
        'oPoint = PointF.Add(oPoint, Traslation)
        'oPoint.X = oPoint.X * Scale
        'oPoint.Y = oPoint.Y * Scale
        'Return oPoint
    End Function

    Public Function GetTherionAreaType(Item As cItem) As String
        Select Case Item.Brush.Type
            Case cBrush.BrushTypeEnum.Water, cBrush.BrushTypeEnum.NotStandardWater
                Return "water"
            Case cBrush.BrushTypeEnum.Sand
                Return "sand"
            Case cBrush.BrushTypeEnum.SmallDebrits
                Return "debris"
            Case cBrush.BrushTypeEnum.BigDebrits
                Return "blocks"
            Case cBrush.BrushTypeEnum.Flow
                Return "flowstone"
            Case cBrush.BrushTypeEnum.Pebbles
                Return "pebbles"
            Case Else
                Return "bedrock"
        End Select
    End Function

    Public Function GetTherionReverseOption(Item As cItem) As String
        Select Case Item.Pen.Type
            Case cPen.PenTypeEnum.GradientDownPen, cPen.PenTypeEnum.CliffDownPen, cPen.PenTypeEnum.OverhangDownPen
                Return " -reverse on"
            Case cPen.PenTypeEnum.PresumedCliffDownPen, cPen.PenTypeEnum.PresumedGradientDownPen, cPen.PenTypeEnum.PresumedOverhangDownPen
                Return " -reverse on"
            Case Else
                Return ""
        End Select
    End Function

    Public Function GetTherionGradientOption(Item As cItem) As String
        Return ""
        Select Case Item.Pen.Type
            Case cPen.PenTypeEnum.GradientDownPen, cPen.PenTypeEnum.GradientUpPen
                Return " -gradient point"
            Case Else
                Return ""
        End Select
    End Function

    Public Function GetTherionLSizeOption(Item As cItem) As String
        Return ""
        'Select Case Item.Pen.Type
        '    Case cPen.PenTypeEnum.GradientDownPen, cPen.PenTypeEnum.GradientUpPen
        '        Return " -l-size 1"
        '    Case Else
        '        Return ""
        'End Select
    End Function

    Public Function GetTherionLineType(Item As cItem) As String
        If (Item.Category = Items.cIItem.cItemCategoryEnum.Rock OrElse Item.Category = Items.cIItem.cItemCategoryEnum.Concretion) AndAlso Item.Type = Items.cIItem.cItemTypeEnum.FreeHandArea Then
            Return "rock-border"
        ElseIf (Item.Category = Items.cIItem.cItemCategoryEnum.Rock OrElse Item.Category = Items.cIItem.cItemCategoryEnum.Concretion) AndAlso Item.Type = Items.cIItem.cItemTypeEnum.FreeHandLine Then
            Return "rock-edge"
        Else
            Select Case Item.Pen.Type
                Case cPen.PenTypeEnum.None
                    Return "border:invisible"
                Case cPen.PenTypeEnum.GenericPen
                    Return "contour"
                Case cPen.PenTypeEnum.CavePen
                    Return "wall"
                Case cPen.PenTypeEnum.GradientDownPen, cPen.PenTypeEnum.GradientUpPen
                    Return "contour"
                Case cPen.PenTypeEnum.CliffDownPen, cPen.PenTypeEnum.CliffUpPen
                    Return "floor-step"
                Case cPen.PenTypeEnum.OverhangDownPen, cPen.PenTypeEnum.OverhangUpPen
                    Return "overhang"
                Case Else
                    Return "border"
            End Select
        End If
    End Function

    Private Function pGetOption([Option] As String, Value As String) As String
        If Value = "" Then
            Return ""
        Else
            Return " -" & [Option] & " " & Value
        End If
    End Function

    Public Function GetTherionOutlineOption(Item As cItem) As String
        Return pGetOption("outline", GetTherionOutline(Item))
    End Function

    Public Function GetTherionOutline(Item As cItem) As String
        If Item.Type = Items.cIItem.cItemTypeEnum.InvertedFreeHandArea Then
            Select Case DirectCast(Item, Items.cItemInvertedFreeHandArea).MergeMode
                Case Items.cIItemMergeableArea.MergeModeEnum.Add
                    Return "out"
                Case Items.cIItemMergeableArea.MergeModeEnum.Subtract
                    Return "in"
            End Select
        Else
            Return ""
        End If
    End Function

    Public Function GetTherionItemIDOption(Item As cItem) As String
        Return pGetOption("id", GetTherionItemID(Item))
    End Function

    Public Function GetTherionItemID(Item As cItem) As String
        Return Item.Design.Type.ToString("D") & "-" & Item.Layer.Type.ToString("D") & "-" & Item.Layer.Items.IndexOf(Item)
    End Function

    Private Function pGetTherionPointMark(Point As cPoint) As String
        Return Point.GetHashCode().ToString
    End Function

    Private Sub pTherionAppendPointMark(SB As System.Text.StringBuilder, Point As cPoint, ID As String, ByRef PointID As Dictionary(Of cPoint, String))
        If Point.IsJoined Then
            Call SB.AppendLine("mark " & pGetTherionPointMark(Point))
            Call PointID.Add(Point, ID)
        End If
    End Sub

    Private Function pTherionExportToScraps(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Filename As String, DesignType As cIDesign.cDesignTypeEnum, Cave As String, Path As String, TrigpointFirstSession As IDictionary(Of String, String), Optional ByVal Dictionary As IDictionary(Of String, String) = Nothing) As List(Of String)
        Dim oFiles As List(Of String) = New List(Of String)

        Dim sCave As String = Cave.ToLower
        Dim sPath As String = Path.ToLower

        Dim oCave As cCaveInfo = Survey.Properties.CaveInfos(sCave)
        Dim oBranch As cCaveInfoBranch = Nothing
        If sPath <> "" Then
            oBranch = oCave.Branches(sPath)
            For Each oCaveBranch As cCaveInfoBranch In oBranch.Branches
                Call oFiles.AddRange(pTherionExportToScraps(Survey, Filename, DesignType, sCave, oCaveBranch.Path, TrigpointFirstSession, Dictionary))
            Next
        End If

        Dim sPointFormat As String = "0.00"

        Dim oTrigpoints As cITrigPointCollection
        If oBranch Is Nothing Then
            oTrigpoints = oCave.GetSegments.GetTrigpoints
        Else
            oTrigpoints = oBranch.GetSegments.GetTrigpoints
        End If

        If oTrigpoints.Count > 0 Then
            Dim oItems As List(Of cItem) = New List(Of cItem)
            Dim oDesign As cDesign
            Dim oOptions As cOptionsPreview
            If DesignType = cIDesign.cDesignTypeEnum.Plan Then
                oDesign = Survey.Plan
                oOptions = Survey.Options("_preview.plan")
            Else
                oDesign = Survey.Profile
                oOptions = Survey.Options("_preview.profile")
            End If
            For Each oItem As cItem In oDesign.GetAllItems
                If (oItem.Cave.ToLower = Cave.ToLower AndAlso oItem.Branch.ToLower = Path.ToLower) AndAlso Not oItem.HiddenInPreview Then
                    Call oItems.Add(oItem)
                End If
            Next
            Call oItems.Reverse()

            'processo il ramo corrente come fosse uno scrap
            Dim sProjection As String = IIf(DesignType = cIDesign.cDesignTypeEnum.Plan, "plan", "extended")
            Dim sScrapName As String = FormatTextFor(IO.Path.GetFileNameWithoutExtension(Filename) & "_" & sProjection & "_" & sCave & IIf(Path = "", "", "_" & Path), FormatTextForEnum.BaseWithoutSpacesAndSlash)
            Dim sScrapFilename As String = IO.Path.Combine(IO.Path.GetDirectoryName(Filename), sScrapName & ".th2")

            Dim oSB As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim oPoint As PointF

            Dim oTraslation As SizeF = New SizeF(0, 0)
            Dim sScale As Single = 4

            Dim oPoints As List(Of PointF) = New List(Of PointF)
            For Each oTrigPoint As cTrigPoint In oTrigpoints
                If DesignType = cIDesign.cDesignTypeEnum.Plan Then
                    oPoint = Survey.Calculate.TrigPoints(oTrigPoint.Name).Point.To2DPoint(Calculate.cTrigPointPoint.ProjectionEnum.FromTop)
                Else
                    oPoint = Survey.Calculate.TrigPoints(oTrigPoint.Name).Point.To2DPoint(Calculate.cTrigPointPoint.ProjectionEnum.Perpendicular)
                End If
                oPoint = pTherionGetPoint(oPoint, oTraslation, sScale)
                Dim sName As String = DictionaryTranslate(Dictionary, oTrigPoint.Name)
                If TrigpointFirstSession.ContainsKey(oTrigPoint.Name) Then
                    Call oSB.AppendLine("point " & NumberToString(oPoint.X, "0.0000000") & " " & NumberToString(oPoint.Y, "0.0000000") & " station -name " & sName & "@" & TrigpointFirstSession(oTrigPoint.Name))
                End If
            Next

            Dim oPointsJoins As Dictionary(Of cPoint, String) = New Dictionary(Of cPoint, String)
            For Each oItem As cItem In oItems
                Dim iSequenceIndex As Integer = 0
                Dim oItemIDs As List(Of String) = New List(Of String)
                Select Case oItem.Type
                    Case Items.cIItem.cItemTypeEnum.FreeHandArea, Items.cIItem.cItemTypeEnum.FreeHandLine, Items.cIItem.cItemTypeEnum.InvertedFreeHandArea
                        Dim iLineType As Items.cIItemLine.LineTypeEnum = DirectCast(oItem, Items.cIItemLine).LineType
                        Dim oSequences As List(Of cSequence) = oItem.Points.GetSequences
                        For Each oSequence As cSequence In oSequences
                            Dim oNewSequence As cSequence
                            Dim iSequenceLineType As Items.cIItemLine.LineTypeEnum = oSequence.GetLineType(iLineType)
                            If iSequenceLineType = Items.cIItemLine.LineTypeEnum.Splines Or iSequenceLineType = Items.cIItemLine.LineTypeEnum.Beziers Then
                                If iSequenceLineType = Items.cIItemLine.LineTypeEnum.Splines Then
                                    oNewSequence = modPaint.ToBezier(Survey, oSequence, iLineType)
                                Else
                                    oNewSequence = oSequence
                                End If
                                If Not IsNothing(oNewSequence) Then
                                    iSequenceIndex += 1
                                    Dim sID As String = GetTherionItemID(oItem) & "-" & iSequenceIndex
                                    Call oItemIDs.Add(sID)

                                    Call oSB.AppendLine("line " & GetTherionLineType(oItem) & " -id " & sID & GetTherionOutlineOption(oItem) & GetTherionReverseOption(oItem) & GetTherionGradientOption(oItem))
                                    oPoint = pTherionGetPoint(oNewSequence(0), oTraslation, sScale)
                                    Call oPoints.Add(oPoint)
                                    Call oSB.AppendLine(NumberToString(oPoint.X, sPointFormat) & " " & NumberToString(oPoint.Y, sPointFormat))
                                    Call pTherionAppendPointMark(oSB, oNewSequence(0), sID, oPointsJoins)

                                    For i As Integer = 1 To oNewSequence.Count - 4 Step 3
                                        'For i As Integer = 1 To oNewSequence.Count - 1 Step 3
                                        oPoint = pTherionGetPoint(oNewSequence(i), oTraslation, sScale)
                                        Call oPoints.Add(oPoint)
                                        Call oSB.Append(NumberToString(oPoint.X, sPointFormat) & " " & NumberToString(oPoint.Y, sPointFormat) & " ")

                                        oPoint = pTherionGetPoint(oNewSequence(i + 1), oTraslation, sScale)
                                        Call oPoints.Add(oPoint)
                                        Call oSB.Append(NumberToString(oPoint.X, sPointFormat) & " " & NumberToString(oPoint.Y, sPointFormat) & " ")

                                        oPoint = pTherionGetPoint(oNewSequence(i + 2), oTraslation, sScale)
                                        Call oPoints.Add(oPoint)
                                        Call oSB.Append(NumberToString(oPoint.X, sPointFormat) & " " & NumberToString(oPoint.Y, sPointFormat))
                                        Call oSB.AppendLine()
                                        Call pTherionAppendPointMark(oSB, oNewSequence(i + 2), sID, oPointsJoins)
                                    Next
                                    Call oSB.AppendLine("endline")
                                End If
                            Else
                                oNewSequence = oSequence

                                iSequenceIndex += 1
                                Dim sID As String = GetTherionItemID(oItem) & "-" & iSequenceIndex
                                Call oItemIDs.Add(sID)

                                Call oSB.AppendLine("line " & GetTherionLineType(oItem) & " -id " & sID & GetTherionOutlineOption(oItem) & GetTherionReverseOption(oItem) & GetTherionGradientOption(oItem))
                                For i As Integer = 0 To oNewSequence.Count - 1
                                    oPoint = pTherionGetPoint(oNewSequence(i), oTraslation, sScale)
                                    Call oPoints.Add(oPoint)
                                    Call oSB.AppendLine(NumberToString(oPoint.X, sPointFormat) & " " & NumberToString(oPoint.Y, sPointFormat))
                                    Call pTherionAppendPointMark(oSB, oNewSequence(i), sID, oPointsJoins)
                                Next
                                Call oSB.AppendLine("endline")
                            End If
                            'End If
                        Next
                        If oItem.Type = Items.cIItem.cItemTypeEnum.FreeHandArea Then
                            If oItemIDs.Count > 0 Then
                                Call oSB.AppendLine("area " & GetTherionAreaType(oItem))
                                For Each sItemID As String In oItemIDs
                                    Call oSB.AppendLine(sItemID)
                                Next
                                Call oSB.AppendLine("endarea")
                            End If
                        End If
                    Case Items.cIItem.cItemTypeEnum.Clipart
                        Dim oItemClipart As Items.cItemClipart = oItem
                        Call oSB.Append("point ")
                        oPoint = pTherionGetPoint(oItemClipart.GetCenterPoint, oTraslation, sScale)
                        Call oPoints.Add(oPoint)
                        Call oSB.Append(NumberToString(oPoint.X, sPointFormat) & " " & NumberToString(oPoint.Y, sPointFormat))
                        Dim sMetapostname As String = modMetapost.GetUniqueMetapostName(Survey, Survey.Cliparts.Cliparts, oItemClipart.Clipart, "clip")
                        Dim sItemScale As Single
                        Dim sItemRotate As Single
                        Call oItemClipart.GetScaleAndRotateFactors(oOptions, sItemScale, sItemRotate)
                        Call oSB.Append(" u:" & sMetapostname & " " & GetTherionClipping(oItem) & " " & "-attr scale " & modNumbers.NumberToString(sItemScale, "0.000") & " -attr rotate " & modNumbers.NumberToString(sItemRotate, "0.0") & "")
                        Call oSB.AppendLine()
                        'Call modMetapost.ClipartToMetapostFile(Survey, oItemClipart.Clipart, sMetapostFilename, sMetapostname)
                        'If Not oFiles.Contains(sMetapostFilename) Then oFiles.Add(sMetapostFilename)
                    Case Items.cIItem.cItemTypeEnum.Sign
                        Dim oSignItem As Items.cItemSign = oItem
                        Call oSB.Append("point ")
                        oPoint = pTherionGetPoint(oItem.Points(0), oTraslation, sScale)
                        Call oPoints.Add(oPoint)
                        Call oSB.Append(NumberToString(oPoint.X, sPointFormat) & " " & NumberToString(oPoint.Y, sPointFormat))
                        Dim sSign As String = GetTherionSign(oSignItem.Sign)
                        If oSignItem.Sign = Items.cIItemSign.SignEnum.Undefined Or sSign = "" Then
                            Dim sMetapostname As String = modMetapost.GetUniqueMetapostName(Survey, Survey.Signs.Cliparts, oSignItem.Clipart, "symbol")
                            Dim sItemScale As Single
                            Dim sItemRotate As Single
                            Call oSignItem.GetScaleAndRotateFactors(oOptions, sItemScale, sItemRotate)
                            sItemRotate = modPaint.NormalizeAngle(sItemRotate + oSignItem.SignRotationAngleDelta)
                            Call oSB.Append(" u:" & sMetapostname & " " & GetTherionClipping(oItem) & " " & "-attr scale " & modNumbers.NumberToString(sItemScale, "0.000") & " -attr rotate " & modNumbers.NumberToString(sItemRotate, "0.0") & "")
                            Call oSB.AppendLine()
                        Else
                            Dim sItemScale As Single
                            Dim sItemRotate As Single
                            Call oSignItem.GetScaleAndRotateFactors(oOptions, sItemScale, sItemRotate)
                            sItemRotate = modPaint.NormalizeAngle(sItemRotate + oSignItem.SignRotationAngleDelta)
                            Call oSB.Append(" " & sSign & " -orient " & modNumbers.NumberToString(sItemRotate, "0.0") & " " & GetTherionSignScaleOption(oItem))
                        End If
                        Call oSB.AppendLine()

                    Case Items.cIItem.cItemTypeEnum.Text
                        Dim oTextItem As Items.cItemText = oItem
                        Call oSB.Append("point ")
                        oPoint = pTherionGetPoint(oItem.Points(0), oTraslation, sScale)
                        Call oPoints.Add(oPoint)
                        Call oSB.Append(NumberToString(oPoint.X, sPointFormat) & " " & NumberToString(oPoint.Y, sPointFormat))
                        Dim sText As String = modPaint.ReplaceGlobalTags(Survey, oTextItem.Text)
                        Call oSB.Append(" label -text " & FormatTextFor(sText, FormatTextForEnum.TherionText) & GetTherionTextAlignOption(oItem) & GetTherionTextScaleOption(oItem))
                        Call oSB.AppendLine()
                End Select
            Next

            'disabled...
            'point in therion file may be not the same of original drawing so this code in not correct 
            'If oPointsJoins.Count > 1 Then
            '    For Each oJoin As cPointsJoin In oDesign.PointsJoins
            '        If Not oJoin.IsEmpty Then
            '            Dim bFirst As Boolean = True
            '            Dim iPointsCount As Integer = 0
            '            For Each oJoinPoint As cPoint In oJoin
            '                If oPointsJoins.ContainsKey(oJoinPoint) Then
            '                    If bFirst Then
            '                        Call oSB.Append("join ")
            '                        bFirst = False
            '                    End If
            '                    Call oSB.Append(oPointsJoins(oJoinPoint) & ":" & pGetTherionPointMark(oJoinPoint) & " ")
            '                    iPointsCount += 1
            '                End If
            '            Next
            '            If iPointsCount = 1 Then Stop
            '            If Not bFirst Then Call oSB.AppendLine()
            '        End If
            '    Next
            'End If

            If oPoints.Count > 1 Then
                Dim oBounds As RectangleF
                Using oPath As GraphicsPath = New GraphicsPath
                    Call oPath.AddPolygon(oPoints.ToArray)
                    oBounds = oPath.GetBounds
                End Using
                Call oBounds.Inflate(1.5, 1.5)

                If Not modPaint.IsRectangleEmpty(oBounds) Then
                    Using oTS As IO.TextWriter = My.Computer.FileSystem.OpenTextFileWriter(sScrapFilename, False, TextFileEncoder)
                        Call oTS.WriteLine(pGetTherionTextEncorderDef(oTS.Encoding))
                        Call oTS.WriteLine("##XTHERION## xth_me_area_adjust " & modNumbers.NumberToString(oBounds.Left) & " " & modNumbers.NumberToString(oBounds.Top) & " " & modNumbers.NumberToString(oBounds.Right) & " " & modNumbers.NumberToString(oBounds.Bottom) & "")
                        Call oTS.WriteLine("##XTHERION## xth_me_area_zoom_to 100")
                        'scala: 2 punti scrap->2 punti realtà
                        'Call oTS.WriteLine("scrap " & sScrapName & " -projection " & sProjection & " -scale 1 ") ' [0 0 1600 0 0.0 0.0 40.64 0.0 m]")
                        Call oTS.WriteLine("scrap " & sScrapName & " -projection " & sProjection) ' & " -scale [0 0 " & modNumbers.NumberToString(oBounds.Width) & " " & modNumbers.NumberToString(-oBounds.Height) & " " & modNumbers.NumberToString(oBounds.Left) & " " & modNumbers.NumberToString(oBounds.Top) & " " & modNumbers.NumberToString(oBounds.Width) & " " & modNumbers.NumberToString(-oBounds.Height) & " m]")
                        Call oTS.Write(oSB.ToString)
                        Call oTS.WriteLine("endscrap")
                        Call oTS.Close()
                    End Using
                    Call oFiles.Add(sScrapFilename)
                End If
            End If
        End If
        Return oFiles
    End Function

    Public Function GetTherionSign(Sign As Items.cIItemSign.SignEnum) As String
        Select Case Sign
            Case Items.cIItemSign.SignEnum.AirDraught
                Return "air-draught"
            Case Items.cIItemSign.SignEnum.AirDraughtSummer
                Return "air-draught:summer"
            Case Items.cIItemSign.SignEnum.AirDraughtWinter
                Return "air-draught:winter"
            Case Items.cIItemSign.SignEnum.Anastomosis
                Return "anastomosis"
            Case Items.cIItemSign.SignEnum.Anchor
                Return "anchor"
            Case Items.cIItemSign.SignEnum.Aragonite
                Return "aragonite"
            Case Items.cIItemSign.SignEnum.ArcheoMaterial
                Return "archeo-material"
            Case Items.cIItemSign.SignEnum.Blocks
                Return "blocks"
            Case Items.cIItemSign.SignEnum.Bridge
                Return "bridge"
            Case Items.cIItemSign.SignEnum.Camp
                Return "camp"
            Case Items.cIItemSign.SignEnum.CavePearl
                Return "cavepearl"
            Case Items.cIItemSign.SignEnum.Continuation
                Return "continuation"
            Case Items.cIItemSign.SignEnum.Crystal
                Return "crystal"
            Case Items.cIItemSign.SignEnum.Curtain
                Return "curtain"
            Case Items.cIItemSign.SignEnum.Debrits
                Return "debrits"
            Case Items.cIItemSign.SignEnum.Dig
                Return "dig"
            Case Items.cIItemSign.SignEnum.Disk
                Return "disk"
            Case Items.cIItemSign.SignEnum.Entrance
                Return "entrance"
            Case Items.cIItemSign.SignEnum.FixedLadder
                Return "fixed-ladder"
            Case Items.cIItemSign.SignEnum.FlowStone
                Return "flowstone"
            Case Items.cIItemSign.SignEnum.Flute
                Return "flute"
            Case Items.cIItemSign.SignEnum.Gradient
                Return "gradient"
            Case Items.cIItemSign.SignEnum.Guano
                Return "guano"
            Case Items.cIItemSign.SignEnum.Gypsum
                Return "gypsum"
            Case Items.cIItemSign.SignEnum.GypsumFlower
                Return "gypsum-flower"
            Case Items.cIItemSign.SignEnum.Handrail
                Return "handrail"
            Case Items.cIItemSign.SignEnum.Helictite
                Return "helictite"
            Case Items.cIItemSign.SignEnum.Ice
                Return "ice"
            Case Items.cIItemSign.SignEnum.Karren
                Return "karren"
            Case Items.cIItemSign.SignEnum.Moonmilk
                Return "moonmilk"
            Case Items.cIItemSign.SignEnum.NarrowEnd
                Return "narrow-end"
            Case Items.cIItemSign.SignEnum.PaleoMaterial
                Return "paleo-material"
            Case Items.cIItemSign.SignEnum.Pebbles
                Return "pebbles"
            Case Items.cIItemSign.SignEnum.Pillar
                Return "pillar"
            Case Items.cIItemSign.SignEnum.Pillars
                Return "pillars"
            Case Items.cIItemSign.SignEnum.Popcorn
                Return "popcorn"
            Case Items.cIItemSign.SignEnum.Rock
                Return "rock"
            Case Items.cIItemSign.SignEnum.Root
                Return "root"
            Case Items.cIItemSign.SignEnum.Rope
                Return "rope"
            Case Items.cIItemSign.SignEnum.RopeLadder
                Return "rope-ladder"
            Case Items.cIItemSign.SignEnum.Sand
                Return "sand"
            Case Items.cIItemSign.SignEnum.Scallop
                Return "scallop"
            Case Items.cIItemSign.SignEnum.SodaStraw
                Return "soda-straw"
            Case Items.cIItemSign.SignEnum.Stalactite
                Return "stalactite"
            Case Items.cIItemSign.SignEnum.Stalactites
                Return "stalactites"
            Case Items.cIItemSign.SignEnum.Traverse
                Return "traverse"
            Case Items.cIItemSign.SignEnum.Undefined
                Return "label"
            Case Items.cIItemSign.SignEnum.VegetableDebris
                Return "vegetable-debrits"
            Case Items.cIItemSign.SignEnum.ViaFerrata
                Return "via-ferrata"
            Case Items.cIItemSign.SignEnum.WallCalcite
                Return "wallcalcite"
            Case Items.cIItemSign.SignEnum.Waterfall
                Return ""
            Case Items.cIItemSign.SignEnum.WaterFlow
                Return "water-flow:permanent"
            Case Items.cIItemSign.SignEnum.WaterFlowIntermittent
                Return "water-flow:intermittent"
            Case Items.cIItemSign.SignEnum.WaterFlowPaleo
                Return "water-flow:paleo"
            Case Else
                Return ""
        End Select
    End Function

    Public Function GetTherionClipping(Item As cItem) As String
        If Item.ClippingType = cItem.cItemClippingTypeEnum.Default Then
            If Item.Layer.Type < cLayers.LayerTypeEnum.Borders Then
                Return "-clip on"
            Else
                Return "-clip off"
            End If
        Else
            If Item.ClippingType = cItem.cItemClippingTypeEnum.InsideBorder Then
                Return "-clip on"
            Else
                Return "-clip off"
            End If
        End If
    End Function

    Public Function GetTherionSignScaleOption(Item As cItem) As String
        Return pGetOption("scale", GetTherionSignScale(Item))
    End Function

    Public Function GetTherionSignScale(Item As cItem) As String
        If Item.Type = Items.cIItem.cItemTypeEnum.Sign Then
            Dim sScale As String = ""
            Select Case DirectCast(Item, Items.cItemSign).SignSize
                Case Items.cIItemSizable.SizeEnum.VerySmall
                    sScale = "xs"
                Case Items.cIItemSizable.SizeEnum.Small
                    sScale = "s"
                Case Items.cIItemSizable.SizeEnum.Medium, Items.cIItemSizable.SizeEnum.Default
                    sScale = "m"
                Case Items.cIItemSizable.SizeEnum.Large
                    sScale = "l"
                Case Else ' Items.ciItemSizable.sizeenum.VeryLarge
                    'da rivedere...mancano gli altri fattori di scala 'aggiuntivi'
                    sScale = "xl"
            End Select
            Return sScale
        Else
            Return ""
        End If
    End Function

    Public Function GetTherionTextScaleOption(Item As cItem) As String
        Return pGetOption("scale", GetTherionTextScale(Item))
    End Function

    Public Function GetTherionTextScale(Item As cItem) As String
        If Item.Type = Items.cIItem.cItemTypeEnum.Text Then
            Dim oTextItem As Items.cItemText = Item
            Dim sScale As String
            Select Case oTextItem.TextSize
                Case Items.cIItemSizable.SizeEnum.VerySmall
                    sScale = "xs"
                Case Items.cIItemSizable.SizeEnum.Small
                    sScale = "s"
                Case Items.cIItemSizable.SizeEnum.Medium, Items.cIItemSizable.SizeEnum.Default
                    sScale = "m"
                Case Items.cIItemSizable.SizeEnum.Large
                    sScale = "l"
                Case Items.cIItemSizable.SizeEnum.VeryLarge
                    sScale = "xl"
            End Select
            Return sScale
        Else
            Return ""
        End If
    End Function

    Public Function GetTherionTextAlignOption(Item As cItem) As String
        Return pGetOption("align", GetTherionTextAlign(Item))
    End Function

    Public Function GetTherionTextAlign(Item As cItem) As String
        If Item.Type = Items.cIItem.cItemTypeEnum.Text Then
            Dim oTextItem As Items.cItemText = Item
            Dim sAlign As String = ""
            Select Case oTextItem.TextAlignment
                Case Items.cIItemVerticalLineableText.TextVerticalAlignmentEnum.Top
                    sAlign = "top"
                Case Items.cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
                    sAlign = "bottom"
            End Select
            Select Case oTextItem.TextVerticalAlignment
                Case Items.cIItemLineableText.TextAlignmentEnum.Left
                    If sAlign <> "" Then sAlign &= "-"
                    sAlign &= "left"
                Case Items.cIItemLineableText.TextAlignmentEnum.Right
                    If sAlign <> "" Then sAlign &= "-"
                    sAlign &= "right"
            End Select
            Return sAlign
        Else
            Return ""
        End If
    End Function

    Private Function pTherionExportToScraps(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Filename As String, DesignType As cIDesign.cDesignTypeEnum, Cave As String, TrigpointFirstSession As IDictionary(Of String, String), Optional ByVal Dictionary As IDictionary(Of String, String) = Nothing) As List(Of String)
        Dim oFiles As List(Of String) = New List(Of String)
        Dim oCave As cCaveInfo = Survey.Properties.CaveInfos(Cave)
        For Each oCaveBranch As cCaveInfoBranch In oCave.Branches.GetAllBranchesWithEmpty(False).Values
            Call oFiles.AddRange(pTherionExportToScraps(Survey, Filename, DesignType, Cave, oCaveBranch.Path, TrigpointFirstSession, Dictionary))
        Next
        Return oFiles
    End Function

    Private Function pTherionExportToScraps(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Filename As String, DesignType As cIDesign.cDesignTypeEnum, TrigpointFirstSession As IDictionary(Of String, String), Optional ByVal Dictionary As IDictionary(Of String, String) = Nothing) As List(Of String)
        Dim oFiles As List(Of String) = New List(Of String)
        For Each oCave As cCaveInfo In Survey.Properties.CaveInfos
            Call oFiles.AddRange(pTherionExportToScraps(Survey, Filename, DesignType, oCave.Name, TrigpointFirstSession, Dictionary))
        Next
        Return oFiles
    End Function

    Private Function pTherionExportMapConfig(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Filename As String) As List(Of String)
        Dim oFiles As List(Of String) = New List(Of String)

        Dim sBaseName As String = IO.Path.GetFileNameWithoutExtension(Filename)
        Dim sLayoutConfigName As String = FormatTextFor(sBaseName & "_thconfig", FormatTextForEnum.BaseWithoutSpacesAndSlash)
        Dim sLayoutConfigFilename As String = IO.Path.Combine(IO.Path.GetDirectoryName(Filename), sLayoutConfigName & ".thconfig")

        Using oTS As IO.TextWriter = My.Computer.FileSystem.OpenTextFileWriter(sLayoutConfigFilename, False, TextFileEncoder)
            Call oTS.WriteLine(pGetTherionTextEncorderDef(oTS.Encoding))
            Call oTS.WriteLine("source " & sBaseName)
            Call oTS.WriteLine()
            Call oTS.WriteLine("layout defaultlayout")

            For Each oClipart As cClipart In Survey.Cliparts.Cliparts
                Dim sMetapostname As String = modMetapost.GetUniqueMetapostName(Survey, Survey.Cliparts.Cliparts, oClipart, "clip")
                Call oTS.WriteLine(modMetapost.ClipartToMetapost(Survey, oClipart, sMetapostname, "clipart:" & oClipart.Name & " (" & oClipart.ID & ")"))
            Next
            'attenzione: i simboli non vanno esportati tutti...andrebbo esportati solo quelli collegati a tipi non definiti ma nel dubbio li esporto tutti...
            For Each oClipart As cClipart In Survey.Signs.Cliparts
                Dim sMetapostname As String = modMetapost.GetUniqueMetapostName(Survey, Survey.Signs.Cliparts, oClipart, "symbol")
                Call oTS.WriteLine(modMetapost.ClipartToMetapost(Survey, oClipart, sMetapostname, "symbol:" & oClipart.Name & " (" & oClipart.ID & ")"))
            Next

            Call oTS.WriteLine("scale 1 250")
            Call oTS.WriteLine("transparency on")
            Call oTS.WriteLine("opacity 90")
            Call oTS.WriteLine("language it")
            Call oTS.WriteLine("statistics topo-length on")
            Call oTS.WriteLine("statistics explo-length on")
            Call oTS.WriteLine("legend on")
            Call oTS.WriteLine("map-header 8 50 e")
            Call oTS.WriteLine("layers off")
            Call oTS.WriteLine("endlayout ")
            Call oTS.WriteLine()
            Call oTS.WriteLine("export map -o " & sBaseName & "_pianta.pdf -layout defaultlayout")
            Call oTS.WriteLine("export map -proj extended -o " & sBaseName & "_sezione.pdf -layout defaultlayout")

            Call oTS.Close()
        End Using
        Call oFiles.Add(sLayoutConfigFilename)

        Return oFiles
    End Function

    Private Function pTherionExportToScrapsFor3D(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Filename As String, DesignType As cIDesign.cDesignTypeEnum, Items As List(Of Items.cItemInvertedFreeHandArea), Cave As String, Path As String, TrigpointFirstSession As IDictionary(Of String, String), Optional ByVal Dictionary As IDictionary(Of String, String) = Nothing) As List(Of String)
        Dim oFiles As List(Of String) = New List(Of String)

        Dim sCave As String = Cave.ToLower
        Dim sPath As String = Path.ToLower

        Dim oCave As cCaveInfo = Survey.Properties.CaveInfos(sCave)
        Dim oBranch As cCaveInfoBranch = Nothing
        If sPath <> "" Then
            oBranch = oCave.Branches(sPath)
            For Each oCaveBranch As cCaveInfoBranch In oBranch.Branches
                Call oFiles.AddRange(pTherionExportToScrapsFor3D(Survey, Filename, DesignType, Items, sCave, oCaveBranch.Path, TrigpointFirstSession, Dictionary))
            Next
        End If

        Dim sPointFormat As String = "0.00"

        Dim oTrigpoints As cITrigPointCollection
        If oBranch Is Nothing Then
            oTrigpoints = oCave.GetSegments.GetTrigpoints
        Else
            oTrigpoints = oBranch.GetSegments.GetTrigpoints
        End If

        Dim oItems As List(Of Items.cItemInvertedFreeHandArea) = New List(Of Items.cItemInvertedFreeHandArea)
        For Each oItem As Items.cItemInvertedFreeHandArea In Items
            If (oItem.Cave.ToLower = sCave) Then 'And (oItem.Cave = Cave And oItem.Branch = Path) Then
                Call oItems.Add(oItem)
            End If
        Next

        If oTrigpoints.Count > 0 Then
            'processo il ramo corrente come fosse uno scrap
            Dim sProjection As String = IIf(DesignType = cIDesign.cDesignTypeEnum.Plan, "plan", "extended")
            Dim sScrapName As String = FormatTextFor(IO.Path.GetFileNameWithoutExtension(Filename) & "_" & sProjection & "_" & sCave & IIf(Path = "", "", "_" & Path), FormatTextForEnum.BaseWithoutSpacesAndSlash)
            Dim sScrapFilename As String = IO.Path.Combine(IO.Path.GetDirectoryName(Filename), sScrapName & ".th2")

            Dim oSB As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim oPoint As PointF
            Dim oBounds As RectangleF = New RectangleF

            'For Each oItem As Items.cItemInvertedFreeHandArea In oItems
            '    If modPaint.IsRectangleEmpty(oBounds) Then
            '        oBounds = oItem.GetBounds
            '    Else
            '        oBounds = RectangleF.Union(oBounds, oItem.GetBounds)
            '    End If
            'Next
            'Dim oTraslation As SizeF = New SizeF(-oBounds.Left, -oBounds.Top + oBounds.Height)
            Dim oTraslation As SizeF = New SizeF(0, 0)
            Dim sScale As Single = 4

            Dim oPoints As List(Of PointF) = New List(Of PointF)
            For Each oTrigPoint As cTrigPoint In oTrigpoints
                If DesignType = cIDesign.cDesignTypeEnum.Plan Then
                    oPoint = Survey.Calculate.TrigPoints(oTrigPoint.Name).Point.To2DPoint(Calculate.cTrigPointPoint.ProjectionEnum.FromTop)
                Else
                    oPoint = Survey.Calculate.TrigPoints(oTrigPoint.Name).Point.To2DPoint(Calculate.cTrigPointPoint.ProjectionEnum.Perpendicular)
                End If
                oPoint = pTherionGetPoint(oPoint, oTraslation, sScale)
                Call oPoints.Add(oPoint)
                Dim sName As String = DictionaryTranslate(Dictionary, oTrigPoint.Name)
                If TrigpointFirstSession.ContainsKey(oTrigPoint.Name) Then
                    Call oSB.AppendLine("point " & NumberToString(oPoint.X, "0.0000000") & " " & NumberToString(oPoint.Y, "0.0000000") & " station -name " & sName & "@" & TrigpointFirstSession(oTrigPoint.Name))
                End If
            Next

            For Each oItem As Items.cItemInvertedFreeHandArea In oItems
                Dim oSequences As List(Of cSequence) = oItem.Points.GetSequencesByCaveAndBranch(sCave, sPath)
                For Each oSequence As cSequence In oSequences
                    If Not oSequence.GetPen(oItem.Pen).Type = cPen.PenTypeEnum.None Then
                        Dim oNewSequence As cSequence = modPaint.ToStraightLine(Survey, oSequence, oItem.LineType)
                        Call modPaint.ReducePoints(oNewSequence, 0.05, cSurvey.Design.Items.cIItemLine.LineTypeEnum.Lines)
                        Call oSB.AppendLine("line wall")
                        For i As Integer = 0 To oNewSequence.Count - 1
                            oPoint = pTherionGetPoint(oNewSequence(i), oTraslation, sScale)
                            Call oPoints.Add(oPoint)
                            Call oSB.AppendLine(NumberToString(oPoint.X, sPointFormat) & " " & NumberToString(oPoint.Y, sPointFormat))
                        Next
                        Call oSB.AppendLine("endline")
                    End If
                Next
            Next

            Using oPath As GraphicsPath = New GraphicsPath
                Call oPath.AddPolygon(oPoints.ToArray)
                oBounds = oPath.GetBounds
            End Using
            Call oBounds.Inflate(1.5, 1.5)

            If Not modPaint.IsRectangleEmpty(oBounds) Then
                Using oTS As IO.TextWriter = My.Computer.FileSystem.OpenTextFileWriter(sScrapFilename, False, TextFileEncoder)
                    Call oTS.WriteLine(pGetTherionTextEncorderDef(oTS.Encoding))
                    Call oTS.WriteLine("##XTHERION## xth_me_area_adjust " & modNumbers.NumberToString(oBounds.Left) & " " & modNumbers.NumberToString(oBounds.Top) & " " & modNumbers.NumberToString(oBounds.Right) & " " & modNumbers.NumberToString(oBounds.Bottom) & "")
                    Call oTS.WriteLine("##XTHERION## xth_me_area_zoom_to 100")
                    'scala: 2 punti scrap->2 punti realtà
                    'Call oTS.WriteLine("scrap " & sScrapName & " -projection " & sProjection & " -scale 1 ") ' [0 0 1600 0 0.0 0.0 40.64 0.0 m]")
                    Call oTS.WriteLine("scrap " & sScrapName & " -projection " & sProjection) ' & " -scale [0 0 " & modNumbers.NumberToString(oBounds.Width) & " " & modNumbers.NumberToString(-oBounds.Height) & " " & modNumbers.NumberToString(oBounds.Left) & " " & modNumbers.NumberToString(oBounds.Top) & " " & modNumbers.NumberToString(oBounds.Width) & " " & modNumbers.NumberToString(-oBounds.Height) & " m]")
                    Call oTS.Write(oSB.ToString)
                    Call oTS.WriteLine("endscrap")
                    Call oTS.Close()
                End Using
                Call oFiles.Add(sScrapFilename)
            End If
        End If
        Return oFiles
    End Function

    Private Function pTherionExportToScrapsFor3D(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Filename As String, DesignType As cIDesign.cDesignTypeEnum, Items As List(Of Items.cItemInvertedFreeHandArea), Cave As String, TrigpointFirstSession As IDictionary(Of String, String), Optional ByVal Dictionary As IDictionary(Of String, String) = Nothing) As List(Of String)
        Dim oFiles As List(Of String) = New List(Of String)
        Dim oCave As cCaveInfo = Survey.Properties.CaveInfos(Cave)
        For Each oCaveBranch As cCaveInfoBranch In oCave.Branches.GetAllBranchesWithEmpty(False).Values
            Call oFiles.AddRange(pTherionExportToScrapsFor3D(Survey, Filename, DesignType, Items, Cave, oCaveBranch.Path, TrigpointFirstSession, Dictionary))
        Next
        Return oFiles
    End Function

    Private Function pTherionExportToScrapsFor3D(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Filename As String, DesignType As cIDesign.cDesignTypeEnum, Items As List(Of Items.cItemInvertedFreeHandArea), TrigpointFirstSession As IDictionary(Of String, String), Optional ByVal Dictionary As IDictionary(Of String, String) = Nothing) As List(Of String)
        Dim oFiles As List(Of String) = New List(Of String)
        For Each oCave As cCaveInfo In Survey.Properties.CaveInfos
            Call oFiles.AddRange(pTherionExportToScrapsFor3D(Survey, Filename, DesignType, Items, oCave.Name, TrigpointFirstSession, Dictionary))
        Next
        Return oFiles
    End Function

    Public Function GetNewStationName(Trigpoints As cTrigPoints, Optional Prefix As String = "") As String
        Dim sName As String = ""
        Dim iIndex As Integer
        Do
            iIndex += 1
            sName = Prefix & Strings.Format(iIndex, "0")
        Loop While Trigpoints.Contains(sName)
        Return sName.ToUpper
    End Function

    Public Function GetStationPrexifFromText(Text As String) As String
        Dim sText As String = FormatTextFor(Text, FormatTextForEnum.Base)
        Dim sStation As String = ""
        For Each sWord As String In sText.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            sStation &= sWord(0)
        Next
        Return sStation.ToUpper
    End Function

    Public Enum FormatTextForEnum
        Base = 0
        BaseWithoutSpaces = 1
        BaseWithoutSpacesAndSlash = 2
        TherionFile = 10
        TherionText = 11
        TherionStationName = 12
    End Enum

    'Private sFromReplaceChars() As Char = "àèìòùÀÈÌÒÙ äëïöüÄËÏÖÜ âêîôûÂÊÎÔÛ áéíóúÁÉÍÓÚðÐýÝ ãñõÃÑÕšŠžŽçÇåÅøØ".ToCharArray
    'Private sToReplaceChars() As Char = "aeiouAEIOU aeiouAEIOU aeiouAEIOU aeiouAEIOUdDyY anoANOsSzZcCaAoO".ToCharArray

    Public Function UnAccent(ByVal Text As String) As String
        Return Text.RemoveDiacritics
        'Return System.Web.HttpUtility.UrlDecode(System.Web.HttpUtility.UrlEncode(Text, System.Text.Encoding.GetEncoding("ISO-8859-8")))
        'For i As Integer = 0 To sFromReplaceChars.GetUpperBound(0)
        '    Text = Text.Replace(sFromReplaceChars(i), sToReplaceChars(i))
        'Next
        'Return Text
    End Function

    Public Function FormatTextFor(Text As String, Format As FormatTextForEnum) As String
        Dim sText As String = Text
        Select Case Format
            Case FormatTextForEnum.Base
                sText = UnAccent(Text)
                'sText = Web.HttpUtility.UrlEncode(Text)
                sText = sText.Replace("(", "")
                sText = sText.Replace(")", "")
                sText = sText.Replace(".", "")
                sText = sText.Replace(",", "")
                sText = sText.Replace(";", "")
                sText = sText.Replace(":", "")
                sText = sText.Replace("+", "")
                sText = sText.Replace("-", "")
                sText = sText.Replace("'", "_")
                sText = sText.Replace("@", "")
                sText = sText.Replace("#", "")
                sText = sText.Replace("[", "")
                sText = sText.Replace("]", "")
                sText = sText.Replace("{", "")
                sText = sText.Replace("}", "")
                sText = sText.Replace("^", "")
                sText = sText.Replace("?", "")
                sText = sText.Replace("=", "")
                sText = sText.Replace("&", "")
                sText = sText.Replace("%", "")
                sText = sText.Replace("$", "")
                sText = sText.Replace("£", "")
                sText = sText.Replace("!", "")
                sText = sText.Replace("<", "")
                sText = sText.Replace(">", "")
                sText = sText.Replace("°", "")
                sText = sText.Replace("§", "")
                sText = sText.Replace("’", "_")
                sText = sText.Replace(Chr(34), "")
            Case FormatTextForEnum.BaseWithoutSpaces
                sText = FormatTextFor(sText, FormatTextForEnum.Base)
                sText = sText.Replace(" ", "_")
            Case FormatTextForEnum.BaseWithoutSpacesAndSlash
                sText = FormatTextFor(sText, FormatTextForEnum.BaseWithoutSpaces)
                sText = sText.Replace("\", "_")
                sText = sText.Replace("/", "_")
                sText = sText.Replace("|", "_")
            Case FormatTextForEnum.TherionText
                sText = sText.Replace(vbCrLf, "<br>")
                sText = Chr(34) & sText.Replace(Chr(34), Chr(34) & Chr(34)) & Chr(34)
            Case FormatTextForEnum.TherionFile
                sText = Chr(34) & sText.Replace(Chr(34), Chr(34) & Chr(34)) & Chr(34)
            Case FormatTextForEnum.TherionStationName
                sText = sText.Replace(")", "_")
                sText = sText.Replace("(", "_")
                sText = sText.Replace(" ", "_")
        End Select
        Return sText
    End Function

    Public Function TherionGetSavenameDictionary(Survey As cSurveyPC.cSurvey.cSurvey) As IDictionary(Of String, String)
        Dim oDictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)
        For Each oTrigpoint As cTrigPoint In Survey.TrigPoints
            oDictionary.Add(oTrigpoint.Name, FormatTextFor(oTrigpoint.Name, FormatTextForEnum.TherionStationName))
        Next
        Return oDictionary
    End Function

    Public Function TherionThExportTo_Version1(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Filename As String, Optional ByVal Dictionary As IDictionary(Of String, String) = Nothing, Optional ByVal Options As TherionExportOptionsEnum = TherionExportOptionsEnum.Default Or TherionExportOptionsEnum.ExportSketch) As cTherionCalculateResult
        '                           GPS Enabled	    GPS Disabled
        'Declinazione manuale       No	            Si
        'Declinazione automatica    Si	            No
        'Correzione nord	        Si, automatica	Si, tramite opzione

        Dim oResult As cTherionCalculateResult = New cTherionCalculateResult(Survey, Dictionary)

        Using st As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(Filename, False, TextFileEncoder)
            Call st.WriteLine(pGetTherionTextEncorderDef(TextFileEncoder))
            Call st.WriteLine("#csurvey " & modMain.GetReleaseVersion & " legacy1")
            Dim sName As String = FormatTextFor(Survey.Name, FormatTextForEnum.BaseWithoutSpacesAndSlash)
            If sName = "" Then sName = "csurvey_unnamed"
            Call st.Write("survey " & sName & " -title " & Chr(34) & If((Options And TherionExportOptionsEnum.UseCadastralIDinCaveNames) = TherionExportOptionsEnum.UseCadastralIDinCaveNames AndAlso Survey.Properties.ID <> "", Survey.Properties.ID & " " & Survey.Properties.Name, Survey.Properties.Name) & Chr(34))

            If Survey.Properties.NordCorrectionMode = cSurvey.cSurvey.NordCorrectionModeEnum.None Then
                Call st.Write(" -declination [0.00 deg]")
            Else
                If Survey.Properties.DeclinationEnabled And Survey.Properties.NordType = cSegment.NordTypeEnum.Magnetic Then
                    Call st.Write(" -declination [" & modText.FormatNumber(Survey.Properties.Declination, "0.00") & " deg]")
                End If
            End If
            Call st.WriteLine("")

            If Survey.Properties.GPS.Enabled Then
                If (Options And TherionExportOptionsEnum.ExportSurfaceElevationsData) = TherionExportOptionsEnum.ExportSurfaceElevationsData Then
                    Dim sOptionsName As String = If(Options And TherionExportOptionsEnum.Loch, "_loch", "_therion")
                    Dim sSurfaceFile As String = Survey.Surface.CreateTherionSurfaceDataFile(sOptionsName, Path.GetDirectoryName(Filename), Filename, oResult)
                    Call st.WriteLine("input " & Chr(34) & sSurfaceFile & Chr(34))
                End If
            End If

            For Each oGrade As cGrade In Survey.Grades
                Dim sGrade As String = oGrade.CreateTherionGradeTextBlock
                If sGrade <> "" Then
                    Call st.WriteLine(sGrade)
                End If
            Next
            Call st.WriteLine("grade null" & vbCrLf & "endgrade")

            Call st.WriteLine("centerline")

            Dim sOrigin As String = DictionaryTranslate(Dictionary, Survey.Properties.Origin)
            Call st.WriteLine("extend start " & sOrigin)

            For Each oSession As cSession In Survey.Properties.Sessions.GetWithEmpty.Values
                Call st.WriteLine("group")
                Call st.WriteLine("date " & Strings.Format(oSession.Date, "yyyy.MM.dd"))

                Call st.WriteLine("vthreshold 90 deg")

                If Survey.Properties.NordCorrectionMode = cSurvey.cSurvey.NordCorrectionModeEnum.None Then
                    Call st.WriteLine("declination 0.00 deg")
                Else
                    If oSession.DeclinationEnabled And oSession.NordType = cSegment.NordTypeEnum.Magnetic Then
                        Call st.WriteLine("declination " & modText.FormatNumber(oSession.GetDeclination.GetValueOrDefault, "0.00") & " deg")
                    End If
                End If

                Dim oSegments As cSegmentCollection = Survey.Segments.GetSessionSegments(oSession)
                Select Case oSession.DataFormat
                    Case cSegment.DataFormatEnum.Normal
                        Call st.WriteLine("units length " & GetTherionDistanceUnit(oSession.DistanceType))
                        Call st.WriteLine("units compass " & GetTherionBearingUnit(oSession.BearingType))
                        Call st.WriteLine("units clino " & GetTherionInclinationUnit(oSession.InclinationType))
                        Call st.WriteLine("data normal from to compass clino length left right up down")
                    Case cSegment.DataFormatEnum.Cartesian
                        Call st.WriteLine("units length " & GetTherionDistanceUnit(oSession.DistanceType))
                        Call st.WriteLine("data cartesian from to northing altitude easting left right up down")
                End Select

                If oSession.Grade <> "" Then Call st.WriteLine("grade " & oSession.Grade)

                Dim sFlags As String = ""
                Dim sPreviousFlags As String = ""
                For Each oSegment As cSegment In oSegments
                    If oSegment.IsValid And Not oSegment.IsSelfDefined Then
                        Dim sFrom As String = DictionaryTranslate(Dictionary, oSegment.Data.Data.[From])
                        Dim sTo As String = DictionaryTranslate(Dictionary, oSegment.Data.Data.[To])

                        sFlags = ""
                        If oSegment.Splay AndAlso ((Options And TherionExportOptionsEnum.CalculateSplay) = TherionExportOptionsEnum.CalculateSplay) Then sFlags = sFlags & " splay" Else sFlags = sFlags & " not splay"
                        If oSegment.Duplicate Then sFlags = sFlags & " duplicate" Else sFlags = sFlags & " not duplicate"
                        If oSegment.Surface Then sFlags = sFlags & " surface" Else sFlags = sFlags & " not surface"
                        If sFlags <> sPreviousFlags Then
                            Call st.WriteLine("flags " & sFlags)
                            sPreviousFlags = sFlags
                        End If
                        Call st.WriteLine(sFrom & " " & sTo & " " & modText.FormatNumber(oSegment.Data.SourceData.Bearing, "0.00") & " " & modText.FormatNumber(oSegment.Data.SourceData.Inclination, "0.00") & " " & modText.FormatNumber(oSegment.Data.SourceData.Distance, "0.00") & " " & modText.FormatNumber(oSegment.Left, "0.00") & " " & modText.FormatNumber(oSegment.Right, "0.00") & " " & modText.FormatNumber(oSegment.Up, "0.00") & " " & modText.FormatNumber(oSegment.Down, "0.00"))

                        If (Options And TherionExportOptionsEnum.SegmentForceDirection) = TherionExportOptionsEnum.SegmentForceDirection Then
                            'forzo esplicitamente la direzione di ogni segmento...
                            If oSegment.Data.SourceData.Direction = cSurvey.cSurvey.DirectionEnum.Left Then
                                Call st.WriteLine("extend left " & sFrom & " " & sTo)
                            Else
                                Call st.WriteLine("extend right " & sFrom & " " & sTo)
                            End If
                        End If
                    End If
                Next
                Call st.WriteLine("endgroup")
            Next

            For Each oTrigPoint As cTrigPoint In Survey.TrigPoints
                With oTrigPoint
                    Dim sIndex As String = DictionaryTranslate(Dictionary, .Name)

                    If oTrigPoint.Type <> cTrigPoint.TrigPointTypeEnum.Undefined Then
                        Dim sThType As String = ""
                        Select Case oTrigPoint.Type
                            Case cTrigPoint.TrigPointTypeEnum.Temporary
                                sThType = "temporary"
                            Case cTrigPoint.TrigPointTypeEnum.Fixed
                                sThType = "fixed"
                            Case cTrigPoint.TrigPointTypeEnum.Painted
                                sThType = "painted"
                        End Select
                        Call st.WriteLine("mark " & sIndex & " " & sThType)
                    End If

                    If Not .Coordinate.IsEmpty And Survey.Properties.GPS.SendToTherion And Survey.Properties.GPS.Enabled Then
                        Call st.WriteLine("cs lat-long")
                        Call st.WriteLine("fix " & sIndex & " " & modText.FormatNumber(.Coordinate.GetLatitude, "0.0000000") & "    " & modText.FormatNumber(.Coordinate.GetLongitude, "0.0000000") & "    " & modText.FormatNumber(.Coordinate.GetAltitude, "0.00"))
                    End If

                    If (Options And TherionExportOptionsEnum.TrigpointExportNameAsComment) = TherionExportOptionsEnum.TrigpointExportNameAsComment Then
                        Call st.WriteLine("station " & sIndex & " " & FormatTextFor(Survey.Properties.GetFormattedTrigpointText(oTrigPoint), FormatTextForEnum.TherionFile))
                    End If
                End With
            Next

            If Not Survey.Properties.GPS.SendToTherion And Survey.Properties.GPS.Enabled Then
                Dim oTrigPoint As cTrigPoint = Survey.TrigPoints.GetGPSBaseReferencePoint
                If Not oTrigPoint Is Nothing Then
                    With oTrigPoint
                        If Not .Coordinate.IsEmpty Then
                            Dim sIndex As String = DictionaryTranslate(Dictionary, .Name)
                            Call st.WriteLine("cs lat-long")
                            Call st.WriteLine("fix " & sIndex & " " & modText.FormatNumber(.Coordinate.GetLatitude, "0.0000000") & "    " & modText.FormatNumber(.Coordinate.GetLongitude, "0.0000000") & "    " & modText.FormatNumber(.Coordinate.GetAltitude, "0.00"))
                        End If
                    End With
                End If

                'If Survey.Surface.Elevations.ShowIn3D Then
                'Dim sSurfaceElevationTrigpointName1 As String = cSurvey.Calculate.cCalculate.SurfaceElevationTrigpointName1
                'oTrigPoint = Survey.TrigPoints(sSurfaceElevationTrigpointName1)
                'If Not oTrigPoint Is Nothing Then
                '    With oTrigPoint
                '        If Not .Coordinate.IsEmpty Then
                '            Dim sIndex As String = DictionaryTranslate(Dictionary, .Name)
                '            Call st.WriteLine("cs lat-long")
                '            Call st.WriteLine("fix " & sIndex & " " & modText.FormatNumber(.Coordinate.GetLatitude, "0.0000000") & "    " & modText.FormatNumber(.Coordinate.GetLongitude, "0.0000000") & "    " & modText.FormatNumber(.Coordinate.GetAltitude, "0.00"))
                '        End If
                '    End With
                'End If
                'End If
            End If
            If (Options And TherionExportOptionsEnum.ScrapFor3D) = TherionExportOptionsEnum.ScrapFor3D Then
                Call st.WriteLine("walls off")
            End If
            Call st.WriteLine("endcenterline")

            If (Options And TherionExportOptionsEnum.ExportSketch) = TherionExportOptionsEnum.ExportSketch Then
                For Each oSketch As cDesignSketch In Survey.Sketches
                    If Not oSketch.Sketch.Deleted And Not oSketch.Sketch.MorphingDisabled And oSketch.Sketch.Stations.Count > 1 Then

                        Dim sTh2BaseFilename As String = Path.GetFileNameWithoutExtension(Filename) & "_" & oSketch.ID & ".th2"
                        Dim sTh2Filename As String = Path.Combine(Path.GetDirectoryName(Filename), sTh2BaseFilename)
                        Call oResult.Files.Add(sTh2Filename)
                        Dim sTh2BaseImageFilename As String = Path.GetFileNameWithoutExtension(Filename) & "_" & oSketch.ID & ".jpg"
                        Dim sTh2ImageFilename As String = Path.Combine(Path.GetDirectoryName(Filename), sTh2BaseImageFilename)
                        Call oResult.Files.Add(sTh2ImageFilename)

                        Using oSW As FileStream = New FileStream(sTh2ImageFilename, FileMode.OpenOrCreate)
                            Using oImage As Image = oSketch.Sketch.Image.Clone
                                Call oImage.Save(oSW, Drawing.Imaging.ImageFormat.Jpeg)
                            End Using
                            Call oSW.Flush(True)
                            Call oSW.Close()
                        End Using

                        'genero il file th2 corrispondente a questo sketch
                        Using th2st As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(sTh2Filename, False, TextFileEncoder)
                            Call th2st.WriteLine(pGetTherionTextEncorderDef(th2st.Encoding))
                            Call th2st.WriteLine("scrap " & Guid.NewGuid.ToString & " -scale 1 -projection " & IIf(oSketch.Sketch.Design.Type = cIDesign.cDesignTypeEnum.Plan, "plan", "extended") & " -sketch " & sTh2BaseImageFilename & " 0 -" & oSketch.Sketch.Image.Height)
                            For Each oStation As Items.cItemSketch.cStation In oSketch.Sketch.Stations
                                If Not oStation.IsOrphan Then
                                    Dim sStationName As String = DictionaryTranslate(Dictionary, oStation.Name)
                                    Call th2st.WriteLine("point " & oStation.Point.X & " -" & oStation.Point.Y & " station -name " & sStationName)
                                End If
                            Next
                            Call th2st.WriteLine("endscrap" & vbCrLf)
                            Call th2st.Flush()
                            Call th2st.Close()
                        End Using

                        Call st.WriteLine("input " & Chr(34) & sTh2BaseFilename & Chr(34))
                    End If
                Next
            End If

            Dim oScrapFiles As List(Of String) = New List(Of String)
            If (Options And TherionExportOptionsEnum.ScrapFor3D) = TherionExportOptionsEnum.ScrapFor3D Then
                Dim oPlanItems As List(Of Items.cItemInvertedFreeHandArea) = New List(Of Items.cItemInvertedFreeHandArea)
                For Each oItem As cItem In Survey.Plan.Layers(cLayers.LayerTypeEnum.Borders).Items
                    If Not oItem.Deleted Then
                        If oItem.Type = Items.cIItem.cItemTypeEnum.InvertedFreeHandArea And (oItem.Cave.ToLower <> "") Then 'And (oItem.Cave = Cave And oItem.Branch = Path) Then
                            If oItem.BindDesignType = cItem.BindDesignTypeEnum.MainDesign Then
                                Dim oBorderItem As Items.cItemInvertedFreeHandArea = oItem
                                If oBorderItem.MergeMode = Items.cIItemMergeableArea.MergeModeEnum.Add Then
                                    Call oPlanItems.Add(oBorderItem)
                                End If
                            End If
                        End If
                    End If
                Next
                Call oScrapFiles.AddRange(pTherionExportToScrapsFor3D(Survey, Filename, cIDesign.cDesignTypeEnum.Plan, oPlanItems, Dictionary))
                'Call oScrapFiles.AddRange(pTherionExportToScrapsFor3D(Survey, Filename, Survey.Profile, Dictionary))
            End If
            For Each sScrapFile As String In oScrapFiles
                Call st.WriteLine("input " & Chr(34) & sScrapFile & Chr(34))
            Next
            Call oResult.Files.AddRange(oScrapFiles)

            Call st.WriteLine("endsurvey " & sName)
            Call st.Flush()
            Call st.Close()
        End Using

        Return oResult
    End Function

    Public TextFileEncoder As System.Text.Encoding = New System.Text.UTF8Encoding(False)

    Private Function pGetTherionTextEncorderDef(Encoder As System.Text.Encoding) As String
        Return "encoding " & Encoder.WebName & vbCrLf
    End Function

    Private Function pGetDepthValue(Depths As Dictionary(Of String, Decimal), Station As String) As Decimal
        Dim dValue As Decimal
        If Depths.TryGetValue(Station, dValue) Then
            Return dValue
        Else
            Return 0
        End If
    End Function

    Private Function pFormatTextFor(Text As String) As String
        Return FormatTextFor(Text, FormatTextForEnum.BaseWithoutSpacesAndSlash)
    End Function

    Private Function pGetTherionCaveBranchID(Branch As cICaveInfoBranches) As String
        If TypeOf Branch Is cCaveInfo Then
            Return Branch.GetPath(cICaveInfoBranches.PathDirectionEnum.ChildToParent, AddressOf pFormatTextFor, ".", "unnamed")
        Else
            Return If(Branch.Name = "", "unnamed", Branch.GetPath(cICaveInfoBranches.PathDirectionEnum.ChildToParent, AddressOf pFormatTextFor, ".", "unnamed")) & "." & If(Branch.Cave = "", "unnamed", FormatTextFor(Branch.Cave, FormatTextForEnum.BaseWithoutSpacesAndSlash))
        End If
    End Function

    Private Sub pTherionThExportToCaveBranch(ByVal Survey As cSurveyPC.cSurvey.cSurvey, St As StreamWriter, Indent As Integer, Dictionary As IDictionary(Of String, String), Branch As cICaveInfoBranches, TrigpointFirstSession As Dictionary(Of String, String), TrigpointOtherSessions As Dictionary(Of String, List(Of String)), Depths As Dictionary(Of String, Decimal), ByVal Options As TherionExportOptionsEnum)
        Dim iIndent As Integer = Indent
        Dim oBranchSegments As cSegmentCollection = Branch.GetSegments(cOptionsCenterline.HighlightModeEnum.ExactMatch)
        Dim sCaveBranchID As String = pGetTherionCaveBranchID(Branch)
        Dim sRelativeCaveBranchID As String = If(Branch.Name = "", "unnamed", FormatTextFor(Branch.Name, FormatTextForEnum.BaseWithoutSpacesAndSlash))
        iIndent += 1
        Call St.WriteLine(Space(iIndent) & "survey " & sRelativeCaveBranchID & " -title " & FormatTextFor(If((Options And TherionExportOptionsEnum.UseCadastralIDinCaveNames) = TherionExportOptionsEnum.UseCadastralIDinCaveNames AndAlso Survey.Properties.ID <> "", Survey.Properties.ID & " " & Survey.Properties.Name, Survey.Properties.Name), FormatTextForEnum.TherionText))
        If oBranchSegments.Count > 0 Then
            Dim oSessions As List(Of cSession) = oBranchSegments.GetSessions
            For Each oSession As cSession In oSessions
                Dim oSegments As cSegmentCollection = oBranchSegments.GetSessionSegments(oSession)
                If oSegments.Count > 0 Then
                    Call St.WriteLine(Space(iIndent) & "centerline")
                    iIndent += 1

                    If oSession.Date <> CDate(Nothing) Then
                        Call St.WriteLine(Space(iIndent) & "date " & Strings.Format(oSession.Date, "yyyy.MM.dd"))
                    End If

                    Call St.WriteLine(Space(iIndent) & "vthreshold " & oSession.GetVThreshold & " deg")

                    If Survey.Properties.GPS.Enabled Then
                        'with geo function north is always corrected
                        'for geographic north and cartesian data I set declination to 0
                        If oSession.DataFormat = cSegment.DataFormatEnum.Cartesian Then
                            'this may be redundant
                            Call St.WriteLine(Space(iIndent) & "declination 0.00 deg")
                        Else
                            If oSession.NordType = cSegment.NordTypeEnum.Geographic Then
                                Call St.WriteLine(Space(iIndent) & "declination 0.00 deg")
                            Else
                                If Survey.Properties.CalculateVersion < 2 Then
                                    'nothing...was wrong...declination is mandatory (or date...but there was no date)
                                Else
                                    If oSession.Date = CDate(Nothing) Then
                                        'this is a strange case...I don't remember when program go here
                                        Call St.WriteLine(Space(iIndent) & "declination " & modText.FormatNumber(oSession.GetDeclination.GetValueOrDefault, "0.00") & " deg")
                                    ElseIf Survey.Properties.GPS.AllowManualDeclinations AndAlso oSession.GetDeclination.HasValue Then
                                        'if is magnetic nord and geofunction enable use manual declination if allowed
                                        Call St.WriteLine(Space(iIndent) & "declination " & modText.FormatNumber(oSession.GetDeclination.GetValueOrDefault, "0.00") & " deg")
                                    End If
                                End If
                            End If
                        End If
                    Else
                        'se non ho dati geografici...
                        'se il rilievo non prevede correzione metto tutto a 0
                        If Survey.Properties.NordCorrectionMode = cSurvey.cSurvey.NordCorrectionModeEnum.None Then
                            Call St.WriteLine(Space(iIndent) & "declination 0.00 deg")
                        Else
                            'se il rilievo prevede correzioni e ho messo una declinazione per la sessione la metto altrimenti
                            If oSession.NordType = cSegment.NordTypeEnum.Magnetic Then
                                'se ho una declinazione manuale la imposto...altrimenti dovrebbe prendere quella associata al tag 'survey'
                                If oSession.DeclinationEnabled Then
                                    Call St.WriteLine(Space(iIndent) & "declination " & modText.FormatNumber(oSession.GetDeclination.GetValueOrDefault, "0.00") & " deg")
                                End If
                            Else
                                'geographic north
                                Call St.WriteLine(Space(iIndent) & "declination 0.00 deg")
                            End If
                        End If
                    End If

                    Select Case oSession.DataFormat
                        Case cSegment.DataFormatEnum.Normal
                            Call St.WriteLine(Space(iIndent) & "units length " & GetTherionDistanceUnit(oSession.DistanceType))
                            Call St.WriteLine(Space(iIndent) & "units compass " & GetTherionBearingUnit(oSession.BearingType))
                            Call St.WriteLine(Space(iIndent) & "units clino " & GetTherionInclinationUnit(oSession.InclinationType))
                            Call St.WriteLine(Space(iIndent) & "data normal from to compass clino length left right up down")
                        Case cSegment.DataFormatEnum.Cartesian
                            Call St.WriteLine(Space(iIndent) & "units length " & GetTherionDistanceUnit(oSession.DistanceType))
                            'Call St.WriteLine(Space(iIndent) & "data cartesian from to northing altitude easting left right up down")
                            Call St.WriteLine(Space(iIndent) & "data cartesian from to dy dz dx left right up down")
                        Case cSegment.DataFormatEnum.Diving
                            Call St.WriteLine(Space(iIndent) & "units length " & GetTherionDistanceUnit(oSession.DistanceType))
                            Call St.WriteLine(Space(iIndent) & "units compass " & GetTherionBearingUnit(oSession.BearingType))
                            Call St.WriteLine(Space(iIndent) & "units depth " & GetTherionDepthUnit(oSession.DistanceType))
                            Select Case oSession.DepthType
                                Case cSegment.DepthTypeEnum.AbsoluteAtBegin
                                    Call St.WriteLine(Space(iIndent) & "data diving from to compass fromdepth todepth length left right up down")
                                Case cSegment.DepthTypeEnum.AbsoluteAtEnd
                                    Call St.WriteLine(Space(iIndent) & "data diving from to compass fromdepth todepth length left right up down")
                                Case cSegment.DepthTypeEnum.Difference
                                    Call St.WriteLine(Space(iIndent) & "data diving from to compass depthchange length left right up down")
                            End Select
                    End Select

                    If oSession.Grade <> "" Then Call St.WriteLine(Space(iIndent) & "grade " & oSession.Grade)

                    Dim sFlags As String = ""
                    Dim sPreviousFlags As String = ""
                    For Each oSegment As cSegment In oSegments
                        If oSegment.IsValid AndAlso Not oSegment.IsSelfDefined Then
                            If (Not oSegment.Splay OrElse (oSegment.Splay AndAlso (Options And TherionExportOptionsEnum.ExportSplay) = TherionExportOptionsEnum.ExportSplay)) OrElse (Not oSegment.Splay AndAlso Not oSegment.IsEquate AndAlso Survey.Properties.CalculateVersion > 2) Then
                                If ((Options And TherionExportOptionsEnum.Oversample3D) = TherionExportOptionsEnum.Oversample3D) AndAlso oSegment.Data.SubDatas.Count > 0 Then ' AndAlso Not oSegment.Splay Then
                                    For Each oSubData As cSurvey.Calculate.Plot.cSubData In oSegment.Data.SubDatas
                                        With oSubData
                                            Dim sFrom As String = .[From]
                                            Dim sTo As String = .[To]

                                            If TrigpointFirstSession.ContainsKey(sFrom) Then
                                                If TrigpointOtherSessions.ContainsKey(sFrom) Then
                                                    Call TrigpointOtherSessions(sFrom).Add(sCaveBranchID)
                                                Else
                                                    Call TrigpointOtherSessions.Add(sFrom, New List(Of String))
                                                    Call TrigpointOtherSessions(sFrom).Add(sCaveBranchID)
                                                End If
                                            Else
                                                TrigpointFirstSession.Add(sFrom, sCaveBranchID)
                                            End If
                                            If TrigpointFirstSession.ContainsKey(sTo) Then
                                                If TrigpointOtherSessions.ContainsKey(sTo) Then
                                                    Call TrigpointOtherSessions(sTo).Add(sCaveBranchID)
                                                Else
                                                    Call TrigpointOtherSessions.Add(sTo, New List(Of String))
                                                    Call TrigpointOtherSessions(sTo).Add(sCaveBranchID)
                                                End If
                                            Else
                                                Call TrigpointFirstSession.Add(sTo, sCaveBranchID)
                                            End If

                                            sFrom = DictionaryTranslate(Dictionary, sFrom)
                                            sTo = DictionaryTranslate(Dictionary, sTo)

                                            sFlags = ""
                                            If oSegment.Splay AndAlso ((Options And TherionExportOptionsEnum.CalculateSplay) = TherionExportOptionsEnum.CalculateSplay) Then sFlags = sFlags & " splay" Else sFlags = sFlags & " not splay"
                                            If oSegment.Duplicate Then sFlags = sFlags & " duplicate" Else sFlags = sFlags & " not duplicate"
                                            If oSegment.Surface Then sFlags = sFlags & " surface" Else sFlags = sFlags & " not surface"
                                            'therion does not allow generic exclusion...passed as 'surface'
                                            If oSegment.Exclude AndAlso (Not oSegment.Splay AndAlso Not oSegment.Duplicate AndAlso Not oSegment.Surface) Then sFlags = sFlags & " surface"

                                            If sFlags <> sPreviousFlags Then
                                                Call St.WriteLine(Space(iIndent) & "flags " & sFlags)
                                                sPreviousFlags = sFlags
                                            End If
                                            If oSession.DataFormat = cSegment.DataFormatEnum.Diving Then
                                                Select Case oSession.DepthType
                                                    Case cSegment.DepthTypeEnum.AbsoluteAtBegin
                                                        Dim dDepthFrom As Decimal = pGetDepthValue(Depths, sFrom)
                                                        Dim dDepthTo As Decimal = pGetDepthValue(Depths, sTo)
                                                        Call St.WriteLine(Space(iIndent) & sFrom & " " & sTo & " " & modText.FormatNumber(oSegment.Data.SourceData.Bearing, "0.00") & " " & modText.FormatNumber(dDepthFrom, "0.00") & " " & modText.FormatNumber(dDepthTo, "0.00") & " " & modText.FormatNumber(oSegment.Data.SourceData.Distance, "0.00") & " " & modText.FormatNumber(oSegment.Left, "0.00") & " " & modText.FormatNumber(oSegment.Right, "0.00") & " " & modText.FormatNumber(oSegment.Up, "0.00") & " " & modText.FormatNumber(oSegment.Down, "0.00"))
                                                    Case cSegment.DepthTypeEnum.AbsoluteAtEnd
                                                        Dim dDepthFrom As Decimal = pGetDepthValue(Depths, sFrom)
                                                        Dim dDepthTo As Decimal = pGetDepthValue(Depths, sTo)
                                                        Call St.WriteLine(Space(iIndent) & sFrom & " " & sTo & " " & modText.FormatNumber(oSegment.Data.SourceData.Bearing, "0.00") & " " & modText.FormatNumber(dDepthFrom, "0.00") & " " & modText.FormatNumber(dDepthTo, "0.00") & " " & modText.FormatNumber(oSegment.Data.SourceData.Distance, "0.00") & " " & modText.FormatNumber(oSegment.Left, "0.00") & " " & modText.FormatNumber(oSegment.Right, "0.00") & " " & modText.FormatNumber(oSegment.Up, "0.00") & " " & modText.FormatNumber(oSegment.Down, "0.00"))
                                                    Case Else
                                                        Call St.WriteLine(Space(iIndent) & sFrom & " " & sTo & " " & modText.FormatNumber(oSegment.Data.SourceData.Bearing, "0.00") & " " & modText.FormatNumber(oSegment.Data.SourceData.Inclination, "0.00") & " " & modText.FormatNumber(oSegment.Data.SourceData.Distance, "0.00") & " " & modText.FormatNumber(oSegment.Left, "0.00") & " " & modText.FormatNumber(oSegment.Right, "0.00") & " " & modText.FormatNumber(oSegment.Up, "0.00") & " " & modText.FormatNumber(oSegment.Down, "0.00"))
                                                End Select
                                            ElseIf oSession.DataFormat = cSegment.DataFormatEnum.Cartesian Then
                                                Call St.WriteLine(Space(iIndent) & sFrom & " " & sTo & " " & modText.FormatNumber(.Bearing, "0.00") & " " & modText.FormatNumber(.Inclination, "0.00") & " " & modText.FormatNumber(.Distance, "0.00") & " [" & modText.FormatNumber(.FromLeft, "0.00") & " " & modText.FormatNumber(.ToLeft, "0.00") & "] [" & modText.FormatNumber(.FromRight, "0.00") & " " & modText.FormatNumber(.ToRight, "0.00") & "] [" & modText.FormatNumber(.FromUp, "0.00") & " " & modText.FormatNumber(.ToUp, "0.00") & "] [" & modText.FormatNumber(.FromDown, "0.00") & " " & modText.FormatNumber(.ToDown, "0.00") & "]")
                                            Else
                                                Call St.WriteLine(Space(iIndent) & sFrom & " " & sTo & " " & modText.FormatNumber(.Bearing, "0.00") & " " & modText.FormatNumber(modPaint.NormalizeInclination(.Inclination), "0.00") & " " & modText.FormatNumber(.Distance, "0.00") & " [" & modText.FormatNumber(.FromLeft, "0.00") & " " & modText.FormatNumber(.ToLeft, "0.00") & "] [" & modText.FormatNumber(.FromRight, "0.00") & " " & modText.FormatNumber(.ToRight, "0.00") & "] [" & modText.FormatNumber(.FromUp, "0.00") & " " & modText.FormatNumber(.ToUp, "0.00") & "] [" & modText.FormatNumber(.FromDown, "0.00") & " " & modText.FormatNumber(.ToDown, "0.00") & "]")
                                            End If

                                            If (Options And TherionExportOptionsEnum.SegmentForceDirection) = TherionExportOptionsEnum.SegmentForceDirection Then
                                                'force segment direction
                                                If oSegment.Data.SourceData.Direction = cSurvey.cSurvey.DirectionEnum.Left Then
                                                    Call St.WriteLine(Space(iIndent) & "extend left " & sFrom & " " & sTo)
                                                ElseIf oSegment.Data.SourceData.Direction = cSurvey.cSurvey.DirectionEnum.Right Then
                                                    Call St.WriteLine(Space(iIndent) & "extend right " & sFrom & " " & sTo)
                                                Else
                                                    Call St.WriteLine(Space(iIndent) & "extend vertical " & sFrom & " " & sTo)
                                                End If
                                            End If
                                        End With
                                    Next
                                Else
                                    Dim sFrom As String = oSegment.Data.SourceData.[From]
                                    Dim sTo As String = oSegment.Data.SourceData.[To]

                                    If TrigpointFirstSession.ContainsKey(sFrom) Then
                                        If TrigpointOtherSessions.ContainsKey(sFrom) Then
                                            Call TrigpointOtherSessions(sFrom).Add(sCaveBranchID)
                                        Else
                                            Call TrigpointOtherSessions.Add(sFrom, New List(Of String))
                                            Call TrigpointOtherSessions(sFrom).Add(sCaveBranchID)
                                        End If
                                    Else
                                        TrigpointFirstSession.Add(sFrom, sCaveBranchID)
                                    End If
                                    If TrigpointFirstSession.ContainsKey(sTo) Then
                                        If TrigpointOtherSessions.ContainsKey(sTo) Then
                                            Call TrigpointOtherSessions(sTo).Add(sCaveBranchID)
                                        Else
                                            Call TrigpointOtherSessions.Add(sTo, New List(Of String))
                                            Call TrigpointOtherSessions(sTo).Add(sCaveBranchID)
                                        End If
                                    Else
                                        Call TrigpointFirstSession.Add(sTo, sCaveBranchID)
                                    End If

                                    sFrom = DictionaryTranslate(Dictionary, sFrom)
                                    sTo = DictionaryTranslate(Dictionary, sTo)

                                    If oSegment.IsEquate AndAlso Survey.Properties.CalculateVersion > 2 Then
                                        Call St.WriteLine("equate " & sFrom & " " & sTo)
                                    Else
                                        sFlags = ""
                                        If oSegment.Splay AndAlso ((Options And TherionExportOptionsEnum.CalculateSplay) = TherionExportOptionsEnum.CalculateSplay) Then sFlags = sFlags & " splay" Else sFlags = sFlags & " not splay"
                                        If oSegment.Duplicate Then sFlags = sFlags & " duplicate" Else sFlags = sFlags & " not duplicate"
                                        If oSegment.Surface Then sFlags = sFlags & " surface" Else sFlags = sFlags & " not surface"
                                        'therion does not allow generic exclusion...passed as 'surface'
                                        If oSegment.Exclude AndAlso (Not oSegment.Splay AndAlso Not oSegment.Duplicate AndAlso Not oSegment.Surface) Then sFlags = sFlags & " surface"
                                        If sFlags <> sPreviousFlags Then
                                            Call St.WriteLine(Space(iIndent) & "flags " & sFlags)
                                            sPreviousFlags = sFlags
                                        End If
                                        If oSession.DataFormat = cSegment.DataFormatEnum.Diving Then
                                            Select Case oSession.DepthType
                                                Case cSegment.DepthTypeEnum.AbsoluteAtBegin
                                                    Dim dDepthFrom As Decimal = pGetDepthValue(Depths, sFrom)
                                                    Dim dDepthTo As Decimal = pGetDepthValue(Depths, sTo)
                                                    Call St.Write(Space(iIndent) & sFrom & " " & sTo & " " & modText.FormatNumber(oSegment.Data.SourceData.Bearing, "0.00") & " " & modText.FormatNumber(dDepthFrom, "0.00") & " " & modText.FormatNumber(dDepthTo, "0.00") & " " & modText.FormatNumber(oSegment.Data.SourceData.Distance, "0.00") & " " & modText.FormatNumber(oSegment.Left, "0.00") & " " & modText.FormatNumber(oSegment.Right, "0.00") & " " & modText.FormatNumber(oSegment.Up, "0.00") & " " & modText.FormatNumber(oSegment.Down, "0.00"))
                                                Case cSegment.DepthTypeEnum.AbsoluteAtEnd
                                                    Dim dDepthFrom As Decimal = pGetDepthValue(Depths, sFrom)
                                                    Dim dDepthTo As Decimal = pGetDepthValue(Depths, sTo)
                                                    Call St.Write(Space(iIndent) & sFrom & " " & sTo & " " & modText.FormatNumber(oSegment.Data.SourceData.Bearing, "0.00") & " " & modText.FormatNumber(dDepthFrom, "0.00") & " " & modText.FormatNumber(dDepthTo, "0.00") & " " & modText.FormatNumber(oSegment.Data.SourceData.Distance, "0.00") & " " & modText.FormatNumber(oSegment.Left, "0.00") & " " & modText.FormatNumber(oSegment.Right, "0.00") & " " & modText.FormatNumber(oSegment.Up, "0.00") & " " & modText.FormatNumber(oSegment.Down, "0.00"))
                                                Case Else
                                                    Call St.Write(Space(iIndent) & sFrom & " " & sTo & " " & modText.FormatNumber(oSegment.Data.SourceData.Bearing, "0.00") & " " & modText.FormatNumber(oSegment.Data.SourceData.Inclination, "0.00") & " " & modText.FormatNumber(oSegment.Data.SourceData.Distance, "0.00") & " " & modText.FormatNumber(oSegment.Left, "0.00") & " " & modText.FormatNumber(oSegment.Right, "0.00") & " " & modText.FormatNumber(oSegment.Up, "0.00") & " " & modText.FormatNumber(oSegment.Down, "0.00"))
                                            End Select
                                        Else
                                            Call St.Write(Space(iIndent) & sFrom & " " & sTo & " " & modText.FormatNumber(oSegment.Data.SourceData.Bearing, "0.00") & " " & modText.FormatNumber(oSegment.Data.SourceData.Inclination, "0.00") & " " & modText.FormatNumber(oSegment.Data.SourceData.Distance, "0.00") & " " & modText.FormatNumber(oSegment.Left, "0.00") & " " & modText.FormatNumber(oSegment.Right, "0.00") & " " & modText.FormatNumber(oSegment.Up, "0.00") & " " & modText.FormatNumber(oSegment.Down, "0.00"))
                                        End If
                                        If (Options And TherionExportOptionsEnum.SegmentID) = TherionExportOptionsEnum.SegmentID Then
                                            Call St.WriteLine(" #s:" & oSegment.ID)
                                        Else
                                            Call St.WriteLine("")
                                        End If

                                        If (Options And TherionExportOptionsEnum.SegmentForceDirection) = TherionExportOptionsEnum.SegmentForceDirection Then
                                            'forzo esplicitamente la direzione di ogni segmento...
                                            If oSegment.Data.SourceData.Direction = cSurvey.cSurvey.DirectionEnum.Left Then
                                                If oSegment.Data.SourceData.Reversed Then
                                                    Call St.WriteLine(Space(iIndent) & "extend left " & sTo & " " & sFrom)
                                                Else
                                                    Call St.WriteLine(Space(iIndent) & "extend left " & sFrom & " " & sTo)
                                                End If
                                            ElseIf oSegment.Data.SourceData.Direction = cSurvey.cSurvey.DirectionEnum.Right Then
                                                If oSegment.Data.SourceData.Reversed Then
                                                    Call St.WriteLine(Space(iIndent) & "extend right " & sTo & " " & sFrom)
                                                Else
                                                    Call St.WriteLine(Space(iIndent) & "extend right " & sFrom & " " & sTo)
                                                End If
                                            Else
                                                If oSegment.Data.SourceData.Reversed Then
                                                    Call St.WriteLine(Space(iIndent) & "extend vertical " & sTo & " " & sFrom)
                                                Else
                                                    Call St.WriteLine(Space(iIndent) & "extend vertical " & sFrom & " " & sTo)
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next
                    iIndent -= 1
                    Call St.WriteLine(Space(iIndent) & "endcenterline")
                End If
            Next
        End If

        For Each oBranch As cICaveInfoBranches In Branch.Branches
            Call pTherionThExportToCaveBranch(Survey, St, iIndent, Dictionary, oBranch, TrigpointFirstSession, TrigpointOtherSessions, Depths, Options)
        Next

        'Dim sExtendStart As String = Branch.ExtendStart
        'If sExtendStart <> "" Then
        '    Call St.WriteLine(Space(iIndent) & "centerline")
        '    Dim sIndex As String = DictionaryTranslate(Dictionary, sExtendStart)
        '    Call St.WriteLine(Space(iIndent + 1) & "extend start " & sIndex & "@" & TrigpointFirstSession(sExtendStart))
        '    Call St.WriteLine(Space(iIndent) & "endcenterline")
        'End If

        Call St.WriteLine(Space(iIndent) & "endsurvey")
        iIndent -= 1
    End Sub

    Private Function pTherionGetDepths(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Optional ByVal Dictionary As IDictionary(Of String, String) = Nothing) As Dictionary(Of String, Decimal)
        Dim oDepths As Dictionary(Of String, Decimal) = New Dictionary(Of String, Decimal)
        For Each oSession As cSession In Survey.Properties.Sessions
            If oSession.DataFormat = cSegment.DataFormatEnum.Diving Then
                Select Case oSession.DepthType
                    Case cSegment.DepthTypeEnum.AbsoluteAtBegin
                        For Each oSegment As cSegment In oSession.GetSegments
                            If Not oSegment.IsEquate Then
                                Dim sStation As String = If(oSegment.Data.SourceData.Reversed, oSegment.Data.SourceData.To, oSegment.Data.SourceData.From)
                                sStation = DictionaryTranslate(Dictionary, sStation)
                                Dim dDepth As Decimal = If(oSegment.Data.SourceData.Reversed, -oSegment.Data.SourceData.Inclination, oSegment.Data.SourceData.Inclination)
                                If oDepths.ContainsKey(sStation) Then
                                    Dim dPrevDepth As Decimal = oDepths(sStation)
                                    Dim dNewDepth As Decimal = (dPrevDepth + dDepth) / 2D
                                    Call oDepths.Remove(sStation)
                                    Call oDepths.Add(sStation, dNewDepth)
                                    Call Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Warning, "Depth for station " & sStation & ": AVG(" & modNumbers.NumberToString(dPrevDepth) & ", " & modNumbers.NumberToString(dDepth) & ") = " & modNumbers.NumberToString(dNewDepth))
                                Else
                                    Call oDepths.Add(sStation, dDepth)
                                End If
                            End If
                        Next
                    Case cSegment.DepthTypeEnum.AbsoluteAtEnd
                        For Each oSegment As cSegment In oSession.GetSegments
                            If Not oSegment.IsEquate Then
                                Dim sStation As String = If(oSegment.Data.SourceData.Reversed, oSegment.Data.SourceData.From, oSegment.Data.SourceData.To)
                                Dim sStationIndex As String = DictionaryTranslate(Dictionary, sStation)
                                Dim dDepth As Decimal = If(oSegment.Data.SourceData.Reversed, -oSegment.Data.SourceData.Inclination, oSegment.Data.SourceData.Inclination)
                                If oDepths.ContainsKey(sStationIndex) Then
                                    Dim dPrevDepth As Decimal = oDepths(sStationIndex)
                                    Dim dNewDepth As Decimal = (dPrevDepth + dDepth) / 2D
                                    Call oDepths.Remove(sStationIndex)
                                    Call oDepths.Add(sStationIndex, dNewDepth)
                                    Call Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Warning, "Depth for station " & sStation & ": AVG(" & modNumbers.NumberToString(dPrevDepth) & ", " & modNumbers.NumberToString(dDepth) & ") = " & modNumbers.NumberToString(dNewDepth))
                                Else
                                    Call oDepths.Add(sStationIndex, dDepth)
                                End If
                            End If
                        Next
                End Select
            End If
        Next
        'reprocess segments for valid equate
        For Each oSegment As cSegment In Survey.Segments.Where(Function(oItem) oItem.IsValid AndAlso Not oItem.Virtual AndAlso Not oItem.Calibration AndAlso oItem.IsEquate)
            Dim sFrom As String = oSegment.Data.SourceData.From
            Dim sTo As String = oSegment.Data.SourceData.To
            Dim sFromIndex As String = DictionaryTranslate(Dictionary, oSegment.Data.SourceData.From)
            Dim sToIndex As String = DictionaryTranslate(Dictionary, oSegment.Data.SourceData.To)
            If oDepths.ContainsKey(sFromIndex) AndAlso oDepths.ContainsKey(sToIndex) Then
                Dim dFromDepth As Decimal = oDepths(sFromIndex)
                Dim dToDepth As Decimal = oDepths(sToIndex)
                If dFromDepth <> dToDepth Then
                    Dim dNewDepth As Decimal = (dFromDepth + dToDepth) / 2D
                    Call oDepths.Remove(sFromIndex)
                    Call oDepths.Remove(sToIndex)
                    Call oDepths.Add(sFromIndex, dNewDepth)
                    Call oDepths.Add(sToIndex, dNewDepth)
                    Call Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Warning, "Depth for stations " & sFrom & " AND " & sTo & ": AVG(" & modNumbers.NumberToString(dFromDepth) & ", " & modNumbers.NumberToString(dToDepth) & ") = " & modNumbers.NumberToString(dNewDepth))
                End If
            End If
        Next
        Return oDepths
    End Function

    Public Class cTherionCalculateResult
        Private oDepth As Dictionary(Of String, Decimal)

        Private oFiles As List(Of String)

        Public ReadOnly Property Depth As Dictionary(Of String, Decimal)
            Get
                Return oDepth
            End Get
        End Property

        Public ReadOnly Property Files As List(Of String)
            Get
                Return oFiles
            End Get
        End Property

        Public Sub New(Survey As cSurveyPC.cSurvey.cSurvey, Dictionary As IDictionary(Of String, String))
            oDepth = pTherionGetDepths(Survey, Dictionary)
            oFiles = New List(Of String)
        End Sub
    End Class

    Public Function TherionThExportTo(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Filename As String, Optional ByVal Dictionary As IDictionary(Of String, String) = Nothing, Optional ByVal Options As TherionExportOptionsEnum = TherionExportOptionsEnum.Default Or TherionExportOptionsEnum.ExportSketch Or TherionExportOptionsEnum.SegmentForceDirection) As cTherionCalculateResult
        '                           GPS Enabled	    GPS Disabled
        'Declinazione manuale       No	            Si
        'Declinazione automatica    Si	            No
        'Correzione nord	        Si, automatica	Si, tramite opzione

        Dim oResult As cTherionCalculateResult = New cTherionCalculateResult(Survey, Dictionary)

        Using st As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(Filename, False, TextFileEncoder)
            Call st.WriteLine(pGetTherionTextEncorderDef(TextFileEncoder))
            Call st.WriteLine("#csurvey " & modMain.GetReleaseVersion)
            Dim sName As String = FormatTextFor(If(Survey.Properties.Name = "", "csurvey_unnamed", Survey.Properties.Name), FormatTextForEnum.BaseWithoutSpacesAndSlash)
            Call st.Write("survey " & sName & " -title " & FormatTextFor(If((Options And TherionExportOptionsEnum.UseCadastralIDinCaveNames) = TherionExportOptionsEnum.UseCadastralIDinCaveNames AndAlso Survey.Properties.ID <> "", Survey.Properties.ID & " " & Survey.Properties.Name, Survey.Properties.Name), FormatTextForEnum.TherionText))

            If Not Survey.Properties.GPS.Enabled Then
                'se il rilievo prevede correzioni del nord metto il valore della declinazione globale se presente...
                If Not Survey.Properties.NordCorrectionMode = cSurvey.cSurvey.NordCorrectionModeEnum.None Then
                    If Survey.Properties.GlobalDeclinationEnabled Then
                        Call st.Write(" -declination [" & modText.FormatNumber(Survey.Properties.GlobalDeclination, "0.00") & " deg]")
                    End If
                End If
            End If
            Call st.WriteLine("")

            If Survey.Properties.GPS.Enabled Then
                If (Options And TherionExportOptionsEnum.ExportSurfaceElevationsData) = TherionExportOptionsEnum.ExportSurfaceElevationsData Then
                    'If Survey.Surface.Elevations.ShowIn3D Then
                    Dim sOptionsName As String = If(Options And TherionExportOptionsEnum.Loch, "_loch", "_therion")
                    Dim sSurfaceFile As String = Survey.Surface.CreateTherionSurfaceDataFile(sOptionsName, Path.GetDirectoryName(Filename), Filename, oResult)
                    Call st.WriteLine("input " & Chr(34) & sSurfaceFile & Chr(34))
                    'End If
                End If
            End If

            For Each oGrade As cGrade In Survey.Grades
                Dim sGrade As String = oGrade.CreateTherionGradeTextBlock
                If sGrade <> "" Then
                    Call st.WriteLine(sGrade)
                End If
            Next
            Call st.WriteLine("grade null" & vbCrLf & "endgrade")

            'Dim oDepths As Dictionary(Of String, Decimal) = pTherionGetDepths(Survey, Dictionary)

            Dim oTrigpointFirstSession As Dictionary(Of String, String) = New Dictionary(Of String, String)
            Dim oTrigpointOtherSessions As Dictionary(Of String, List(Of String)) = New Dictionary(Of String, List(Of String))
            Dim iIndent As Integer = 1
            For Each oCave As cCaveInfo In Survey.Properties.CaveInfos.GetWithEmpty.Values
                Call pTherionThExportToCaveBranch(Survey, st, iIndent, Dictionary, oCave, oTrigpointFirstSession, oTrigpointOtherSessions, oResult.Depth, Options)
            Next

            'generic centerline section...for extendstart based on origin
            'additional extendstart have to be managed but I don't know how without breaking apart survey by extendstart 
            Call st.WriteLine("centerline")
            With Survey.Properties
                Dim sIndex As String = DictionaryTranslate(Dictionary, .Origin)
                Call st.WriteLine("extend start " & sIndex & "@" & oTrigpointFirstSession(.Origin))
            End With

            For Each sTrigpoint As String In oTrigpointFirstSession.Keys
                If Survey.TrigPoints.Contains(sTrigpoint) Then
                    Dim oTrigpoint As cTrigPoint = Survey.TrigPoints(sTrigpoint)
                    With oTrigpoint
                        Dim sIndex As String = DictionaryTranslate(Dictionary, .Name)
                        Dim sSessionID As String = oTrigpointFirstSession(sTrigpoint)
                        If .Type <> cTrigPoint.TrigPointTypeEnum.Undefined Then
                            Dim sThType As String = ""
                            Select Case .Type
                                Case cTrigPoint.TrigPointTypeEnum.Temporary
                                    sThType = "temporary"
                                Case cTrigPoint.TrigPointTypeEnum.Fixed
                                    sThType = "fixed"
                                Case cTrigPoint.TrigPointTypeEnum.Painted
                                    sThType = "painted"
                            End Select
                            Call st.WriteLine("mark " & sIndex & "@" & sSessionID & " " & sThType)
                        End If

                        'is oversample is enabled, now, could not be set extend (reason: the shot is 'broken' in subshot...so the original shot is not valid)
                        If ((Options And TherionExportOptionsEnum.Oversample3D) = 0) Then
                            For Each sConnectedTrigPoint As String In .Connections
                                If .Connections.Get(sConnectedTrigPoint) Then
                                    Call st.WriteLine("extend ignore " & sIndex & "@" & sSessionID & " " & DictionaryTranslate(Dictionary, sConnectedTrigPoint) & "@" & oTrigpointFirstSession(sConnectedTrigPoint))
                                End If
                            Next
                        End If

                        If Not .Coordinate.IsEmpty And Survey.Properties.GPS.SendToTherion And Survey.Properties.GPS.Enabled Then
                            Call st.WriteLine("cs lat-long")
                            Call st.WriteLine("fix " & sIndex & "@" & sSessionID & " " & modText.FormatNumber(.Coordinate.GetLatitude, "0.0000000") & "    " & modText.FormatNumber(.Coordinate.GetLongitude, "0.0000000") & "    " & modText.FormatNumber(.Coordinate.GetAltitude, "0.00"))
                        End If

                        If (Options And TherionExportOptionsEnum.TrigpointExportNameAsComment) = TherionExportOptionsEnum.TrigpointExportNameAsComment Then
                            Call st.WriteLine("station " & sIndex & "@" & sSessionID & " " & FormatTextFor(Survey.Properties.GetFormattedTrigpointText(oTrigpoint), FormatTextForEnum.TherionFile))
                        End If

                        If oTrigpoint.IsEntrance Then
                            Call st.WriteLine("station " & sIndex & "@" & sSessionID & " """ & oTrigpoint.GetSegments.ToArray.Select(Function(item) item.Cave).Where(Function(item) item <> "").FirstOrDefault() & """" & " entrance")
                        End If

                        If oTrigpointOtherSessions.ContainsKey(sTrigpoint) Then
                            For Each sOtherSessionID As String In oTrigpointOtherSessions(sTrigpoint)
                                If sSessionID <> sOtherSessionID Then
                                    Call st.WriteLine("equate " & sIndex & "@" & sSessionID & " " & sIndex & "@" & sOtherSessionID)
                                End If
                            Next
                        End If
                    End With
                End If
            Next

            If Not Survey.Properties.GPS.SendToTherion And Survey.Properties.GPS.Enabled Then
                Dim oTrigPoint As cTrigPoint = Survey.TrigPoints.GetGPSBaseReferencePoint
                If Not oTrigPoint Is Nothing Then
                    With oTrigPoint
                        If Not .Coordinate.IsEmpty Then
                            Dim sIndex As String = DictionaryTranslate(Dictionary, .Name)
                            Call st.WriteLine("cs lat-long")
                            Call st.WriteLine("fix " & sIndex & "@" & oTrigpointFirstSession(.Name) & " " & modText.FormatNumber(.Coordinate.GetLatitude, "0.0000000") & "    " & modText.FormatNumber(.Coordinate.GetLongitude, "0.0000000") & "    " & modText.FormatNumber(.Coordinate.GetAltitude, "0.00"))
                        End If
                    End With
                End If
            End If
            If (Options And TherionExportOptionsEnum.ScrapFor3D) = TherionExportOptionsEnum.ScrapFor3D Then
                Call st.WriteLine("walls off")
            End If
            Call st.WriteLine("endcenterline")

            If (Options And TherionExportOptionsEnum.ExportSketch) = TherionExportOptionsEnum.ExportSketch Then
                For Each oSketch As cDesignSketch In Survey.Sketches
                    If Not oSketch.Sketch.Deleted AndAlso Not oSketch.Sketch.MorphingDisabled AndAlso oSketch.Sketch.Stations.HasValidStations Then

                        Dim sTh2BaseFilename As String = Path.GetFileNameWithoutExtension(Filename) & "_" & oSketch.ID & ".th2"
                        Dim sTh2Filename As String = Path.Combine(Path.GetDirectoryName(Filename), sTh2BaseFilename)
                        Call oResult.Files.Add(sTh2Filename)
                        Dim sTh2BaseImageFilename As String = Path.GetFileNameWithoutExtension(Filename) & "_" & oSketch.ID & ".jpg"
                        Dim sTh2ImageFilename As String = Path.Combine(Path.GetDirectoryName(Filename), sTh2BaseImageFilename)
                        Call oResult.Files.Add(sTh2ImageFilename)

                        Using oSW As FileStream = New FileStream(sTh2ImageFilename, FileMode.OpenOrCreate)
                            Using oImage As Image = oSketch.Sketch.Image.Clone
                                Call oImage.Save(oSW, Drawing.Imaging.ImageFormat.Jpeg)
                            End Using
                            Call oSW.Flush(True)
                            Call oSW.Close()
                        End Using

                        'genero il file th2 corrispondente a questo sketch
                        Using th2st As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(sTh2Filename, False, TextFileEncoder)
                            Call th2st.WriteLine(pGetTherionTextEncorderDef(th2st.Encoding))
                            Call th2st.WriteLine("scrap " & Guid.NewGuid.ToString & " -scale 1 -projection " & IIf(oSketch.Sketch.Design.Type = cIDesign.cDesignTypeEnum.Plan, "plan", "extended") & " -sketch " & sTh2BaseImageFilename & " 0 -" & oSketch.Sketch.Image.Height)
                            For Each oStation As Items.cItemSketch.cStation In oSketch.Sketch.Stations.GetValidStations
                                If TypeOf oStation Is Items.cItemSketch.cExtraStation Then
                                    Dim oExtraStation As Items.cItemSketch.cExtraStation = oStation
                                    Dim sStationName As String = DictionaryTranslate(Dictionary, oExtraStation.Name)
                                    Call th2st.WriteLine("point " & oExtraStation.Point.X & " -" & oExtraStation.Point.Y & " extra -from " & sStationName & "@" & oTrigpointFirstSession(oExtraStation.Name) & " -dist " & modNumbers.NumberToString(oExtraStation.Distance))
                                Else
                                    Dim sStationName As String = DictionaryTranslate(Dictionary, oStation.Name)
                                    Call th2st.WriteLine("point " & oStation.Point.X & " -" & oStation.Point.Y & " station -name " & sStationName & "@" & oTrigpointFirstSession(oStation.Name))
                                End If
                            Next
                            Call th2st.WriteLine("endscrap" & vbCrLf)
                            Call th2st.Flush()
                            Call th2st.Close()
                        End Using

                        Call st.WriteLine("input " & Chr(34) & sTh2BaseFilename & Chr(34))
                    End If
                Next
            End If

            Dim oScrapFiles As List(Of String) = New List(Of String)
            If (Options And TherionExportOptionsEnum.ScrapFor3D) = TherionExportOptionsEnum.ScrapFor3D Then
                Dim oPlanItems As List(Of Items.cItemInvertedFreeHandArea) = New List(Of Items.cItemInvertedFreeHandArea)
                For Each oItem As cItem In Survey.Plan.Layers(cLayers.LayerTypeEnum.Borders).Items
                    If Not oItem.Deleted Then
                        If oItem.Type = Items.cIItem.cItemTypeEnum.InvertedFreeHandArea AndAlso (oItem.Cave.ToLower <> "") Then 'And (oItem.Cave = Cave And oItem.Branch = Path) Then
                            If oItem.BindDesignType = cItem.BindDesignTypeEnum.MainDesign Then
                                Dim oBorderItem As Items.cItemInvertedFreeHandArea = oItem
                                If oBorderItem.MergeMode = Items.cIItemMergeableArea.MergeModeEnum.Add Then
                                    Call oPlanItems.Add(oBorderItem)
                                End If
                            End If
                        End If
                    End If
                Next
                Call oScrapFiles.AddRange(pTherionExportToScrapsFor3D(Survey, Filename, cIDesign.cDesignTypeEnum.Plan, oPlanItems, oTrigpointFirstSession, Dictionary))
            End If

            If (Options And TherionExportOptionsEnum.Scrap) = TherionExportOptionsEnum.Scrap Then
                If Not Survey.Plan.IsEmpty Then Call oScrapFiles.AddRange(pTherionExportToScraps(Survey, Filename, cIDesign.cDesignTypeEnum.Plan, oTrigpointFirstSession, Dictionary))
                If Not Survey.Profile.IsEmpty Then Call oScrapFiles.AddRange(pTherionExportToScraps(Survey, Filename, cIDesign.cDesignTypeEnum.Profile, oTrigpointFirstSession, Dictionary))
                Call oResult.Files.AddRange(pTherionExportMapConfig(Survey, Filename))
            End If

            For Each sScrapFile As String In oScrapFiles
                Call st.WriteLine("input " & Chr(34) & sScrapFile & Chr(34))
            Next

            Call oResult.Files.AddRange(oScrapFiles)

            Call st.WriteLine("endsurvey " & sName)
            Call st.Flush()
            Call st.Close()
        End Using

        Return oResult
    End Function

    'Public Sub GarminTrkExportTo(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal Filename As String)
    '    Try
    '        Dim oOrigin As cTrigPoint = Survey.TrigPoints.GetGPSBaseReferencePoint
    '        If oOrigin Is Nothing Then
    '            Call MsgBox("Il rilievo non presenta un origine definita. Impossibile esportare i dati come traccia GPS.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Attenzione: ")
    '        Else
    '            Dim dLat As Decimal = oOrigin.Coordinate.GetLatitude
    '            Dim dLong As Decimal = oOrigin.Coordinate.GetLongitude
    '            Dim sAlt As Decimal = oOrigin.Coordinate.GetAltitude

    '            If dLat = 0 And dLong = 0 Then
    '                Call MsgBox("Il rilievo non presenta le coordinate indicate per l'origine. Impossibile esportare i dati come traccia GPS.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Attenzione:")
    '            Else
    '                'Dim oSFD As SaveFileDialog = New SaveFileDialog
    '                'With oSFD
    '                '    Dim sTrkFilename As String
    '                '    If sFilename = "" Then
    '                '        If oSurvey.Name <> "" Then
    '                '            sTrkFilename = oSurvey.Name & ".trk"
    '                '        Else
    '                '            sTrkFilename = "track"
    '                '        End If
    '                '    Else
    '                '        sTrkFilename = Path.GetFileNameWithoutExtension(sFilename) & ".trk"
    '                '    End If
    '                '    .FileName = sTrkFilename
    '                '    .Filter = "File Garmin PCX 5 (*.trk)|*.trk"
    '                '    If .ShowDialog = vbOK Then
    '                '        sTrkFilename = .FileName

    '                Dim fi As FileInfo = New FileInfo(Filename)
    '                Dim st As StreamWriter = fi.CreateText

    '                Call st.WriteLine("")
    '                Call st.WriteLine("H  SOFTWARE NAME & VERSION")
    '                Call st.WriteLine("I  PCX5 2.09")
    '                Call st.WriteLine("")
    '                Call st.WriteLine("H  R DATUM                IDX DA             DF             DX             DY             DZ")
    '                Call st.WriteLine("M  G WGS 84               121 +0.000000e+000 +0.000000e+000 +0.000000e+000 +0.000000e+000 +0.000000e+000")
    '                Call st.WriteLine("")
    '                Call st.WriteLine("H  COORDINATE SYSTEM")
    '                Call st.WriteLine("U  LAT LON DEG")
    '                Call st.WriteLine("")

    '                Dim sTo As String = oOrigin.Name
    '                Dim oProcessedTrigPoint As List(Of String) = New List(Of String)
    '                Dim oTo As cSurvey.Calculate.cTrigPoint = Survey.Calculate.TrigPoints(sTo)

    '                For Each oConnection As cSurvey.Calculate.cTrigPointConnection In oTo.Connections
    '                    Call modExport.GarminTrkExportTo(Survey, dLat, dLong, sAlt, oTo, oConnection, st, oProcessedTrigPoint)
    '                Next

    '                Call st.Close()
    '                Call GC.Collect()
    '                'End If
    '                '    End With
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Function pGetGoogleColor(ByVal Color As System.Drawing.Color) As String
        Dim sA As String = Hex(Color.A)
        If sA.Length < 2 Then sA = "0" & sA

        Dim sR As String = Hex(Color.R)
        If sR.Length < 2 Then sR = "0" & sR
        Dim sG As String = Hex(Color.G)
        If sG.Length < 2 Then sG = "0" & sG
        Dim sB As String = Hex(Color.B)
        If sB.Length < 2 Then sB = "0" & sB
        Return "#" & sA & sB & sG & sR
    End Function

    Public Function VTopoParseLine(ByVal Line As String) As String()
        Dim oItems As List(Of String) = New List(Of String)
        Dim sValue As String = ""
        Dim bIsComment As Boolean = False
        Dim bFirstSpace As Boolean = False
        For i As Integer = 0 To Line.Length - 1
            Dim c As Char = Line.Chars(i)
            If bIsComment Then
                sValue = sValue & c
            Else
                If c = " " Then
                    If bFirstSpace Then
                        oItems.Add(sValue)
                        sValue = ""
                        bFirstSpace = False
                    End If
                ElseIf c = ";" Then
                    bIsComment = True
                Else
                    sValue = sValue & c
                    bFirstSpace = True
                End If
            End If
        Next
        Call oItems.Add(sValue)
        Return oItems.ToArray
    End Function

End Module
