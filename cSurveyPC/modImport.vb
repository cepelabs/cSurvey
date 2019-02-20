Imports System.Xml
Imports System.IO
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Layers
Imports cSurveyPC.cSurvey.Design.Items

Module modImport

    Public Function ImportWaypointGPX(Filename As String) As cCoordinate
        Dim oXml As XmlDocument = New XmlDocument
        Call oXml.Load(Filename)
        Dim oNodes As XmlNodeList
        oNodes = oXml.GetElementsByTagName("wpt")
        If oNodes.Count > 0 Then
            Dim oXMLPlaceMark As XmlElement = oNodes(0)
            Dim sLon As String = ""
            Dim sLat As String = ""
            Dim sAlt As String = ""
            sLon = oXMLPlaceMark.GetAttribute("lon")
            sLat = oXMLPlaceMark.GetAttribute("lat")
            sAlt = oXMLPlaceMark.Item("ele").InnerText
            Return New cCoordinate(StringToDecimal(sLat), StringToDecimal(sLon), StringToDecimal(sAlt))
        Else
            Return Nothing
        End If
    End Function

    Public Function ImportWaypointKML(Filename As String) As cCoordinate
        Dim oXml As XmlDocument = New XmlDocument
        Call oXml.Load(Filename)
        Dim oNodes As XmlNodeList
        oNodes = oXml.GetElementsByTagName("Placemark")
        If oNodes.Count > 0 Then
            Dim oXMLPlaceMark As XmlElement = oNodes(0)
            Dim sLon As String = ""
            Dim sLat As String = ""
            Dim sAlt As String = ""
            Dim sCoordinate As String = oXMLPlaceMark.Item("Point").Item("coordinates").InnerText
            Dim sCoordinateParts() As String = sCoordinate.Split(",")
            sLon = sCoordinateParts(0)
            sLat = sCoordinateParts(1)
            sAlt = sCoordinateParts(2)
            Return New cCoordinate(StringToDecimal(sLat), StringToDecimal(sLon), StringToDecimal(sAlt))
        Else
            Return Nothing
        End If
    End Function

    Friend Class cImportSegments
        Private oItems As List(Of cImportSegment)

        Public Sub New()
            oItems = New List(Of cImportSegment)
        End Sub

        Public Sub Append(Item As cImportSegment)
            Call oItems.Add(Item)
        End Sub

        Public Sub ProcessSplay()
            Dim oTempItems As List(Of cImportSegment) = New List(Of cImportSegment)
            Dim oTempSplayItems As List(Of cImportSegment) = New List(Of cImportSegment)
            For Each oItem As cImportSegment In oItems
                If oItem.To = "" Then
                    Call oTempSplayItems.Add(oItem)
                Else
                    Call oTempItems.Add(oItem)
                End If
            Next

            For Each oTempSplayItem As cImportSegment In oTempSplayItems
                Dim oParentItem As cImportSegment = oTempItems.LastOrDefault(Function(segment) segment.From = oTempSplayItem.From And segment.To <> "")
                If oParentItem Is Nothing Then
                    oParentItem = oTempItems.LastOrDefault(Function(segment) segment.To = oTempSplayItem.From)
                    If oParentItem Is Nothing Then
                        'non ho inserito battute con questo from o to...inserisco la battuta come se non fosse splay (eventuali errori di poligonale non sono gestiti qui)
                        Call oTempItems.Add(oTempSplayItem)
                    Else
                        Call oParentItem.Splay.Add(oTempSplayItem)
                    End If
                Else
                    Call oParentItem.Splay.Add(oTempSplayItem)
                End If
            Next
        End Sub
    End Class

    Friend Class cImportSplaySegment
        Public Session As cSession
        Public [From] As String
        Public [To] As String
        Public Distance As Decimal
        Public Bearing As Decimal
        Public Inclination As Decimal
        Public Note As String

        Public Sub New()
        End Sub

        Public Sub New(Session As cSession, [From] As String, [To] As String, Distance As Decimal, Bearing As Decimal, Inclination As Decimal, Note As String)
            Me.Session = Session
            Me.From = From
            Me.[To] = [To]
            Me.Distance = Distance
            Me.Bearing = Bearing
            Me.Inclination = Inclination
            Me.Note = Note
        End Sub
    End Class

    Friend Class cImportSegment
        Inherits cImportSplaySegment
        Private oSplay As List(Of cImportSplaySegment)
        Public Direction As Integer

        Public Left As Decimal
        Public Right As Decimal
        Public Up As Decimal
        Public Down As Decimal

        Public ReadOnly Property Splay As List(Of cImportSplaySegment)
            Get
                Return oSplay
            End Get
        End Property

        Public Sub New()
            oSplay = New List(Of cImportSplaySegment)
        End Sub

        Public Sub New(Session As cSession, [From] As String, [To] As String, Distance As Decimal, Bearing As Decimal, Inclination As Decimal, Note As String, Direction As Integer, Left As Decimal, Right As Decimal, Up As Decimal, Down As Decimal)
            MyBase.New(Session, From, [To], Distance, Bearing, Inclination, Note)
            oSplay = New List(Of cImportSplaySegment)
            Me.Direction = Direction
            Me.Left = Left
            Me.Right = Right
            Me.Up = Up
            Me.Down = Down
        End Sub
    End Class

    Private Class cTherionScrapLine
        Private oValues As List(Of String)
        Private oParameters As Dictionary(Of String, String)

        Private Function pGetSecondChar(Text As String) As Char
            If Text.Length > 1 Then
                Return Text(1)
            Else
                Return " "
            End If
        End Function

        Public Sub New(Line As String)
            oValues = New List(Of String)
            oParameters = New Dictionary(Of String, String)

            Dim sCharItem As String = ""
            Dim sLastChar As Char
            Dim iParentesi As Integer
            Dim bOpenQuota As Boolean
            Dim sLastParametersKey As String = ""
            Dim bNextIsParametersValue As Boolean = False
            For Each sChar As Char In Line
                If iParentesi = 0 And Not bOpenQuota Then
                    If sChar = " " Then
                        If sCharItem.StartsWith("-") And Not Char.IsNumber(pGetSecondChar(sCharItem)) Then
                            If bNextIsParametersValue Then
                                Call oParameters.Add(sLastParametersKey, sCharItem)
                                bNextIsParametersValue = False
                                sCharItem = ""
                            Else
                                sLastParametersKey = sCharItem
                                bNextIsParametersValue = True
                                sCharItem = ""
                            End If
                        Else
                            If bNextIsParametersValue Then
                                Call oParameters.Add(sLastParametersKey, sCharItem)
                                bNextIsParametersValue = False
                                sCharItem = ""
                            Else
                                Call oValues.Add(sCharItem)
                                sCharItem = ""
                            End If
                        End If
                    ElseIf sChar = "[" Then
                        iParentesi += 1
                    ElseIf sChar = "]" Then
                        iParentesi -= 1
                    ElseIf sChar = """" Then
                        bOpenQuota = Not bOpenQuota
                    Else
                        sCharItem &= sChar
                    End If
                Else
                    If sChar = "]" Then
                        iParentesi -= 1
                    ElseIf sChar = """" Then
                        bOpenQuota = Not bOpenQuota
                    Else
                        sCharItem &= sChar

                    End If
                    sLastChar = sChar
                End If
            Next
            If sCharItem <> "" Then
                If bNextIsParametersValue Then
                    Call oParameters.Add(sLastParametersKey, sCharItem)
                    bNextIsParametersValue = False
                    sCharItem = ""
                Else
                    Call oValues.Add(sCharItem)
                    sCharItem = ""
                End If
            End If
        End Sub

        Public ReadOnly Property Values As List(Of String)
            Get
                Return oValues
            End Get
        End Property

        Public ReadOnly Property Parameters As Dictionary(Of String, String)
            Get
                Return oParameters
            End Get
        End Property

        Public Function GetValue(Index As Integer) As String
            Return oValues(Index)
        End Function

        Public Function GetParameters(key As String, DefaultValue As String) As String
            If oParameters.ContainsKey(key) Then
                Return oParameters(key)
            Else
                Return DefaultValue
            End If
        End Function
    End Class

    <Flags> Public Enum TherionImportOptionsEnum
        None = 0
        ImportPlan = &H1
        ImportProfile = &H2
        MergeAndReorderBorders = &H10
        ConvertBezierToSpline = &H20
    End Enum

    Private Function pTherionDrawingScaleToTextSize(Scale As String) As Items.cIItemText.TextSizeEnum
        Select Case Scale.ToLower
            Case "xl"
                Return cIItemText.TextSizeEnum.VeryLarge
            Case "l"
                Return cIItemText.TextSizeEnum.Large
            Case "s"
                Return cIItemText.TextSizeEnum.Small
            Case "xs"
                Return cIItemText.TextSizeEnum.VerySmall
            Case Else
                Return cIItemText.TextSizeEnum.Default
        End Select
    End Function

    Private Function pTherionDrawingScaleToSignSize(Scale As String) As Items.cIItemSign.SignSizeEnum
        Select Case Scale.ToLower
            Case "xl"
                Return cIItemSign.SignSizeEnum.VeryLarge
            Case "l"
                Return cIItemSign.SignSizeEnum.Large
            Case "s"
                Return cIItemSign.SignSizeEnum.Small
            Case "xs"
                Return cIItemSign.SignSizeEnum.VerySmall
            Case Else
                Return cIItemSign.SignSizeEnum.Default
        End Select
    End Function

    Private Function pTherionAlignToTextVerticalAlignment(Align As String) As Items.cIItemVerticalLineableText.TextVerticalAlignmentEnum
        Select Case Align
            Case "center", "c"
                Return cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle
            Case "top", "t"
                Return cIItemVerticalLineableText.TextVerticalAlignmentEnum.Top
            Case "bottom", "b"
                Return cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
            Case "left", "l"
                Return cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle
            Case "right", "r"
                Return cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle
            Case "top-left", "tl"
                Return cIItemVerticalLineableText.TextVerticalAlignmentEnum.Top
            Case "top-right", "tr"
                Return cIItemVerticalLineableText.TextVerticalAlignmentEnum.Top
            Case "bottom-left", "bl"
                Return cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
            Case "bottom-right", "br"
                Return cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
        End Select
    End Function

    Private Function pTherionAlignToTextAlignment(Align As String) As Items.cIItemLineableText.TextAlignmentEnum
        Select Case Align
            Case "center", "c"
                Return cIItemLineableText.TextAlignmentEnum.Center
            Case "top", "t"
                Return cIItemLineableText.TextAlignmentEnum.Center
            Case "bottom", "b"
                Return cIItemLineableText.TextAlignmentEnum.Center
            Case "left", "l"
                Return cIItemLineableText.TextAlignmentEnum.Left
            Case "right", "r"
                Return cIItemLineableText.TextAlignmentEnum.Right
            Case "top-left", "tl"
                Return cIItemLineableText.TextAlignmentEnum.Left
            Case "top-right", "tr"
                Return cIItemLineableText.TextAlignmentEnum.Right
            Case "bottom-left", "bl"
                Return cIItemLineableText.TextAlignmentEnum.Left
            Case "bottom-right", "br"
                Return cIItemLineableText.TextAlignmentEnum.Right
        End Select
    End Function

    Public Sub FixTopodroidSurvey(Survey As cSurvey.cSurvey)
        If Not Survey.Properties.DataTables.Segments.Contains("import_source") AndAlso Not Survey.Properties.DataTables.Segments.Contains("import_date") Then
            Dim sID As String = If(Survey.Properties.CreatorID = "", "topodroid", Survey.Properties.CreatorID)
            Dim dDate As Date = If(Survey.Properties.CreationDate.HasValue, Survey.Properties.CreationDate.Value, Now)

            Call Survey.Properties.DataTables.Segments.Add("import_source", Data.cDataFields.TypeEnum.Text)
            Call Survey.Properties.DataTables.Segments.Add("import_date", Data.cDataFields.TypeEnum.Date)

            For Each oSegment As cSegment In Survey.Segments
                Call oSegment.DataProperties.SetValue("import_source", sID)
                Call oSegment.DataProperties.SetValue("import_date", dDate)
            Next

            Call Survey.Properties.DataTables.DesignItems.Add("import_source", Data.cDataFields.TypeEnum.Text)
            Call Survey.Properties.DataTables.DesignItems.Add("import_date", Data.cDataFields.TypeEnum.Date)
            For Each oItem As cItem In Survey.GetAllDesignItems
                Call oItem.DataProperties.SetValue("import_source", sID)
                Call oItem.DataProperties.SetValue("import_date", dDate)
            Next

            For Each oItem As cItem In Survey.GetAllDesignItems
                'check for meta commands...
                If Not IsNothing(oItem.Points.Metas) Then
                    'if points have meta commands read it...
                    'at now only C meta command is supported:
                    'C=close all point's sequences
                    If oItem.Points.Metas.Where(Function(ometa) ometa.Text = "C" AndAlso Not ometa.PointIndex.HasValue).Count > 0 Then
                        Call oItem.Points.CloseSequences()
                    End If
                    Call oItem.Points.Metas.Clear()
                End If
                'force rebinding of all design item to centerline...topodroid don't do it itself
                Call oItem.BindSegments()
            Next

        End If
    End Sub

    Public Sub FixTopodroidCSX(Document As XmlDocument)
        Dim oXMLRoot As XmlElement = Document.DocumentElement

        Dim oXMLProperties As XmlElement = oXMLRoot.Item("properties")
        If oXMLProperties.HasAttribute("origin") Then
            Call oXMLProperties.SetAttribute("origin", oXMLProperties.GetAttribute("origin").ToString.ToUpper)
        End If

        'search for segment with not guid id
        Dim oSegmentIDs As Dictionary(Of String, String) = New Dictionary(Of String, String)
        For Each oXMLSegment As XmlElement In oXMLRoot.Item("segments").ChildNodes
            Dim oGuid As Guid
            Dim sID As String = modXML.GetAttributeValue(oXMLSegment, "id", "")
            If sID <> "" Then
                Dim sNewGUid As String = Guid.NewGuid.ToString
                If Not Guid.TryParse(sID, oGuid) Then
                    Call oSegmentIDs.Add(sID, sNewGUid)
                    Call oXMLSegment.SetAttribute("id", sNewGUid)
                End If
            End If
            Call oXMLSegment.SetAttribute("from", oXMLSegment.GetAttribute("from").ToString.ToUpper)
            Call oXMLSegment.SetAttribute("to", oXMLSegment.GetAttribute("to").ToString.ToUpper)
        Next

        'search for segment with not guid id
        If modXML.ChildElementExist(oXMLRoot, "crosssections") Then
            For Each oXMLCrossSection As XmlElement In oXMLRoot.Item("crosssections").ChildNodes
                Dim oGuid As Guid
                Dim sID As String = modXML.GetAttributeValue(oXMLCrossSection, "id", "")
                If sID <> "" Then
                    Dim sNewGUid As String = Guid.NewGuid.ToString
                    If Not Guid.TryParse(sID, oGuid) Then
                        Call oSegmentIDs.Add(sID, sNewGUid)
                        Call oXMLCrossSection.SetAttribute("id", sNewGUid)
                    End If
                End If
            Next
        End If

        If modXML.ChildElementExist(oXMLRoot, "plan") Then
            Call pFixTopodroidCSXReplaceID(Document, oSegmentIDs, oXMLRoot.Item("plan").Item("layers"))
        End If
        If modXML.ChildElementExist(oXMLRoot, "profile") Then
            Call pFixTopodroidCSXReplaceID(Document, oSegmentIDs, oXMLRoot.Item("profile").Item("layers"))
        End If
    End Sub

    Private Function pFixTopodoirdCSXReplaceID(Data As String, SegmentIDs As Dictionary(Of String, String)) As String
        If Not Data.EndsWith(" ") Then Data = Data & " "
        For Each sSegmentID As String In SegmentIDs.Keys
            Data = Data.Replace("S" & sSegmentID & " ", "S" & SegmentIDs(sSegmentID) & " ")
        Next
        Return Data
    End Function

    Public Sub ReplaceIDItem(XMLItem As XmlElement, SegmentIDs As Dictionary(Of String, String))
        If modXML.HasAttribute(XMLItem, "crosssection") Then
            Dim sCrosssectionID As String = modXML.GetAttributeValue(XMLItem, "crosssection", "")
            If SegmentIDs.ContainsKey(sCrosssectionID) Then
                Call XMLItem.SetAttribute("crosssection", SegmentIDs(sCrosssectionID))
            Else
                Call XMLItem.RemoveAttribute("crosssection")
            End If
        End If
        If XMLItem.GetAttribute("type") = cIItem.cItemTypeEnum.CrossSection Then
            If modXML.HasAttribute(XMLItem, "segment") Then
                Dim sSegmentID As String = modXML.GetAttributeValue(XMLItem, "segment", "")
                If SegmentIDs.ContainsKey(sSegmentID) Then
                    Call XMLItem.SetAttribute("segment", SegmentIDs(sSegmentID))
                Else
                    Call XMLItem.RemoveAttribute("segment")
                End If
            End If
        End If
        If modXML.ChildElementExist(XMLItem, "points") Then
            Dim oXMLPoints As XmlElement = XMLItem.Item("points")
            Dim sData As String = oXMLPoints.GetAttribute("data")
            If sData <> "" Then
                Dim sNewData As String = pFixTopodoirdCSXReplaceID(sData, SegmentIDs)
                If sNewData <> sData Then
                    oXMLPoints.SetAttribute("data", sNewData)
                End If
            End If
        End If
    End Sub

    Private Sub pFixTopodroidCSXReplaceID(Document As XmlDocument, SegmentIDs As Dictionary(Of String, String), Design As XmlElement)
        For Each oXMLLayer As XmlElement In Design.ChildNodes
            For Each oXMLItem As XmlElement In oXMLLayer.Item("items").ChildNodes
                Call ReplaceIDItem(oXMLItem, SegmentIDs)
            Next
        Next
    End Sub

    Public Sub TherionThImportFrom(Survey As cSurvey.cSurvey, Filename As String, Optional CaveName As String = "", Optional Options As TherionImportOptionsEnum = TherionImportOptionsEnum.None, Optional ScaleFactor As Single = 1)
        Dim bImportPlan As Boolean = (Options And TherionImportOptionsEnum.ImportPlan) = TherionImportOptionsEnum.ImportPlan
        Dim bImportProfile As Boolean = (Options And TherionImportOptionsEnum.ImportProfile) = TherionImportOptionsEnum.ImportProfile
        Dim bMergeAndReorderBorders As Boolean = (Options And TherionImportOptionsEnum.MergeAndReorderBorders) = TherionImportOptionsEnum.MergeAndReorderBorders
        'Dim bConvertBezierToSpline As Boolean = (Options And TherionImportOptionsEnum.ConvertBezierToSpline) = TherionImportOptionsEnum.ConvertBezierToSpline

        Dim oBorders As List(Of cItemInvertedFreeHandArea)
        If bMergeAndReorderBorders Then oBorders = New List(Of cItemInvertedFreeHandArea)
        Dim oIds As Dictionary(Of String, cItem) = New Dictionary(Of String, cItem)

        Dim fi As FileInfo = New FileInfo(Filename)

        Dim sCave As String
        If CaveName = "" Then
            sCave = Path.GetFileNameWithoutExtension(Filename)
        Else
            sCave = CaveName
        End If
        Dim oCurrentCave As cCaveInfo
        If Survey.Properties.CaveInfos.Contains(sCave) Then
            oCurrentCave = Survey.Properties.CaveInfos(sCave)
        Else
            oCurrentCave = Survey.Properties.CaveInfos.Add(sCave)
        End If
        Dim sBranch As String

        Dim sr As StreamReader = New StreamReader(fi.FullName, System.Text.Encoding.ASCII)
        Dim bScrapStarted As Boolean
        Dim bLineStarted As Boolean
        Dim bAreaStarted As Boolean
        Dim oDesign As cDesign
        Dim oItem As cItem
        Dim iLineType As cIItemLine.LineTypeEnum
        Dim iLastLineType As cIItemLine.LineTypeEnum
        Dim bBeginSequence As Boolean
        Dim bReverse As Boolean
        Dim bFirstPoint As Boolean
        Dim sScaleFactor As Single = 1
        Dim oPoint As cPoint
        Dim olastpoint As cPoint
        Do Until sr.EndOfStream
            Dim sLine As String = sr.ReadLine
            sLine = sLine.Trim
            If sLine.Contains("#") Then
                sLine = sLine.Substring(0, sLine.IndexOf("#"))
            End If

            If sLine Like "input *" Then
                Dim oScrapLine As cTherionScrapLine = New cTherionScrapLine(sLine)
                Dim sNextFilename As String = Path.Combine(Path.GetDirectoryName(Filename), oScrapLine.GetValue(1))
                If My.Computer.FileSystem.FileExists(sNextFilename) Then
                    Call TherionThImportFrom(Survey, sNextFilename, sCave, Options, ScaleFactor)
                End If
            End If

            If sLine Like "scrap *" Then
                Dim oScrapLine As cTherionScrapLine = New cTherionScrapLine(sLine)
                sBranch = oScrapLine.GetValue(1) 'sLineParameters(1).ToLower
                Dim oCurrentBranch As cCaveInfoBranch
                If oCurrentCave.Branches.Contains(sBranch) Then
                    oCurrentBranch = oCurrentCave.Branches(sBranch)
                Else
                    oCurrentBranch = oCurrentCave.Branches.Add(sBranch)
                End If
                Select Case oScrapLine.GetParameters("-projection", "")
                    Case "extended"
                        oDesign = Survey.Profile
                    Case Else
                        oDesign = Survey.Plan
                End Select
                Dim sScale As String = oScrapLine.GetParameters("-scale", "")
                If sScale <> "" Then
                    Dim sScaleItem() As String = sScale.Split({" "}, StringSplitOptions.None)
                    If sScaleItem.Length > 7 Then
                        Dim oPoint1a As PointF = New PointF(modNumbers.StringToSingle(sScaleItem(0)), modNumbers.StringToSingle(sScaleItem(1)))
                        Dim oPoint2a As PointF = New PointF(modNumbers.StringToSingle(sScaleItem(2)), modNumbers.StringToSingle(sScaleItem(3)))
                        Dim oPoint1b As PointF = New PointF(modNumbers.StringToSingle(sScaleItem(4)), modNumbers.StringToSingle(sScaleItem(5)))
                        Dim oPoint2b As PointF = New PointF(modNumbers.StringToSingle(sScaleItem(6)), modNumbers.StringToSingle(sScaleItem(7)))
                        Dim sScaleA As Single = modPaint.DistancePointToPoint(oPoint1a, oPoint2a)
                        Dim sScaleB As Single = modPaint.DistancePointToPoint(oPoint1b, oPoint2b)
                        sScaleFactor = ScaleFactor * (sScaleB / sScaleA)
                    End If
                End If
                bScrapStarted = True
            End If
            If bScrapStarted Then
                If sLine Like "endscrap" Then
                    bScrapStarted = False

                    If bMergeAndReorderBorders Then
                        If oBorders.Count > 0 Then
                            Dim oFirstborder As cItemInvertedFreeHandArea = oBorders(0)
                            For i As Integer = 1 To oBorders.Count - 1
                                'Call oDesign.Layers(cLayers.LayerTypeEnum.Borders).Items.Combine(oBorders(i), oFirstborder)
                                oFirstborder.Combine(oBorders(i))
                            Next
                            Call oFirstborder.Points.ReorderSequences()
                        End If
                        Call oBorders.Clear()
                    End If
                End If

                If bLineStarted Then
                    If sLine Like "endline" Then
                        bLineStarted = False

                        'If bReverse Then oItem.Points.Revert()
                        'If bConvertBezierToSpline Then
                        '    If oItem.HaveLineType Then
                        '        Call modPaint.ConvertSequences(oItem)
                        '    End If
                        'End If
                    Else
                        If Char.IsNumber(sLine.Substring(1, 1)) Then
                            Dim sPointData() As String = sLine.Split({" "}, System.StringSplitOptions.RemoveEmptyEntries)
                            If bFirstPoint Then
                                oPoint = New cPoint(Survey, modNumbers.StringToSingle(sPointData(0)) * sScaleFactor, -1 * modNumbers.StringToSingle(sPointData(1)) * sScaleFactor)
                                'Call oItem.Points.Add(oPoint)
                                olastpoint = oPoint
                                iLastLineType = -2
                                bFirstPoint = False
                            Else
                                iLineType = IIf(sPointData.Length = 2, cIItemLine.LineTypeEnum.Lines, cIItemLine.LineTypeEnum.Beziers)
                                If iLineType <> iLastLineType Then
                                    bBeginSequence = True
                                Else
                                    bBeginSequence = False
                                End If
                                For i As Integer = 0 To sPointData.Length - 1 Step 2
                                    oPoint = New cPoint(Survey, modNumbers.StringToSingle(sPointData(i)) * sScaleFactor, -1 * modNumbers.StringToSingle(sPointData(i + 1)) * sScaleFactor)
                                    If bBeginSequence Then
                                        If oItem.Points.First Is olastpoint Then
                                            DirectCast(oItem, cIItemLine).LineType = iLineType
                                        End If
                                        Dim oNewpoint As cPoint = olastpoint.Clone
                                        oNewpoint.BeginSequence = bBeginSequence
                                        oNewpoint.LineType = iLineType
                                        Call oItem.Points.Add(oNewpoint)
                                        iLastLineType = iLineType
                                        bBeginSequence = False
                                    End If
                                    Call oItem.Points.Add(oPoint)
                                    olastpoint = oPoint
                                Next
                            End If
                        Else
                        End If
                    End If
                End If

                If bAreaStarted Then
                    If sLine Like "endarea" Then
                        'If bReverse Then oItem.Points.Revert()
                        bAreaStarted = False
                    Else
                        Dim sID As String = sLine
                        If oIds.ContainsKey(sID) Then
                            For Each oSourcePoint As cPoint In oIds(sID).Points
                                Call oItem.Points.Add(oSourcePoint.Clone)
                            Next
                        End If
                    End If
                End If

                If sLine Like "point *" Then
                    Dim oScrapLine As cTherionScrapLine = New cTherionScrapLine(sLine)
                    Select Case oScrapLine.GetValue(3).ToLower
                        Case "entrance"
                            oPoint = New cPoint(Survey, modNumbers.StringToSingle(oScrapLine.GetValue(1)) * sScaleFactor, -1 * modNumbers.StringToSingle(oScrapLine.GetValue(2)) * sScaleFactor)
                            Dim oLayerSigns As cLayerSigns = oDesign.Layers(cLayers.LayerTypeEnum.Signs)
                            oItem = oLayerSigns.CreateSign(sCave, sBranch, "Objects\Cliparts\Signs\ingresso.svg", cIItemClipartBase.cClipartDataFormatEnum.SVGFile)
                            Call oItem.DataProperties.SetValue("import_source", "therion")
                            Call oItem.Points.Add(oPoint)
                            Dim oItemSign As cItemSign = oItem
                            oItemSign.Rotate(modNumbers.StringToSingle(oScrapLine.GetParameters("-orientation", "0")))
                            oItemSign.SignSize = pTherionDrawingScaleToSignSize(oScrapLine.GetParameters("-scale", ""))
                        Case "label"
                            Dim sText As String = oScrapLine.GetParameters("-text", "")
                            If sText <> "" Then
                                oPoint = New cPoint(Survey, modNumbers.StringToSingle(oScrapLine.GetValue(1)) * sScaleFactor, -1 * modNumbers.StringToSingle(oScrapLine.GetValue(2)) * sScaleFactor)
                                Dim oLayerSigns As cLayerSigns = oDesign.Layers(cLayers.LayerTypeEnum.Signs)
                                oItem = oLayerSigns.CreateText(sCave, sBranch, sText)
                                Call oItem.DataProperties.SetValue("import_source", "therion")
                                Call oItem.Points.Add(oPoint)
                                Dim oItemText As cItemText = oItem
                                Call oItemText.Rotate(modNumbers.StringToSingle(oScrapLine.GetParameters("-orientation", "0")))
                                oItemText.TextSize = pTherionDrawingScaleToTextSize(oScrapLine.GetParameters("-scale", ""))
                                DirectCast(oItemText, cIItemLineableText).TextAlignment = pTherionAlignToTextAlignment(oScrapLine.GetParameters("-align", ""))
                                DirectCast(oItemText, cIItemVerticalLineableText).TextVerticalAlignment = pTherionAlignToTextVerticalAlignment(oScrapLine.GetParameters("-align", ""))
                            End If
                        Case "water-flow"
                            oPoint = New cPoint(Survey, modNumbers.StringToSingle(oScrapLine.GetValue(1)) * sScaleFactor, -1 * modNumbers.StringToSingle(oScrapLine.GetValue(2)) * sScaleFactor)
                            Dim oLayerSigns As cLayerSigns = oDesign.Layers(cLayers.LayerTypeEnum.Signs)
                            oItem = oLayerSigns.CreateSign(sCave, sBranch, "Objects\Cliparts\Signs\acqua.svg", cIItemClipartBase.cClipartDataFormatEnum.SVGFile)
                            Call oItem.DataProperties.SetValue("import_source", "therion")
                            Call oItem.Points.Add(oPoint)
                            Dim oItemSign As cItemSign = oItem
                            oItemSign.Rotate(modNumbers.StringToSingle(oScrapLine.GetParameters("-orientation", "0")) + 90)
                            oItemSign.SignSize = pTherionDrawingScaleToSignSize(oScrapLine.GetParameters("-scale", ""))
                    End Select
                End If

                If sLine Like "area *" Then
                    'inizia un oggetto area...
                    Dim oScrapLine As cTherionScrapLine = New cTherionScrapLine(sLine)
                    Dim sAreaType As String = oScrapLine.GetValue(1)
                    Select Case sAreaType
                        Case "water"
                            Dim oLayerFloor As cLayerWaterAndFloorMorphologies = oDesign.Layers(cLayers.LayerTypeEnum.WaterAndFloorMorphologies)
                            oItem = oLayerFloor.CreateWaterArea(sCave, sBranch)
                            Call oItem.DataProperties.SetValue("import_source", "therion")
                            bAreaStarted = True
                        Case "sand", "clay"
                            Dim oLayerSoil As cLayerSoil = oDesign.Layers(cLayers.LayerTypeEnum.Soil)
                            oItem = oLayerSoil.CreateSandSoil(sCave, sBranch)
                            Call oItem.DataProperties.SetValue("import_source", "therion")
                            bAreaStarted = True
                        Case "pebbles"
                            Dim oLayerSoil As cLayerSoil = oDesign.Layers(cLayers.LayerTypeEnum.Soil)
                            oItem = oLayerSoil.CreatePebblesSoil(sCave, sBranch)
                            Call oItem.DataProperties.SetValue("import_source", "therion")
                            bAreaStarted = True
                        Case "debrits"
                            Dim oLayerSoil As cLayerSoil = oDesign.Layers(cLayers.LayerTypeEnum.Soil)
                            oItem = oLayerSoil.CreateSmallDebritsSoil(sCave, sBranch)
                            Call oItem.DataProperties.SetValue("import_source", "therion")
                            bAreaStarted = True
                        Case "blocks"
                            Dim oLayerSoil As cLayerSoil = oDesign.Layers(cLayers.LayerTypeEnum.Soil)
                            oItem = oLayerSoil.CreateBigDebritsSoil(sCave, sBranch)
                            Call oItem.DataProperties.SetValue("import_source", "therion")
                            bAreaStarted = True
                        Case "flowstone"
                            Dim oLayerSoil As cLayerSoil = oDesign.Layers(cLayers.LayerTypeEnum.Soil)
                            oItem = oLayerSoil.CreateFlowSoil(sCave, sBranch)
                            Call oItem.DataProperties.SetValue("import_source", "therion")
                            bAreaStarted = True
                        Case Else
                            Dim oLayerSoil As cLayerSoil = oDesign.Layers(cLayers.LayerTypeEnum.Soil)
                            oItem = oLayerSoil.CreateSoil(sCave, sBranch)
                            Call oItem.DataProperties.SetValue("import_source", "therion")
                            bAreaStarted = True
                    End Select
                    If bAreaStarted Then
                        Dim sPlace As String = oScrapLine.GetParameters("-place", "default")
                        Select Case sPlace
                            Case "bottom"
                                Call oItem.Layer.Items.SendToBottom(oItem)
                            Case "top"
                                Call oItem.Layer.Items.BringToTop(oItem)
                        End Select

                        Dim bClipping As Boolean = oScrapLine.GetParameters("-clip", "on") = "on"
                        If Not bClipping Then
                            oItem.ClippingType = cItem.cItemClippingTypeEnum.None
                        End If
                        bFirstPoint = True
                    End If
                End If

                If sLine Like "line *" Then
                    'inizia un oggetto linea...
                    Dim oScrapLine As cTherionScrapLine = New cTherionScrapLine(sLine)
                    Dim sLineType As String = oScrapLine.GetValue(1)
                    Select Case sLineType
                        Case "wall"
                            Dim oLayerBorders As cLayerBorders = oDesign.Layers(cLayers.LayerTypeEnum.Borders)
                            oItem = oLayerBorders.CreateCaveBorder(sCave, sBranch)
                            bLineStarted = True
                            Select Case oScrapLine.GetParameters("-subtype", "")
                                Case "presumed"
                                    oItem.Pen.Type = cPen.PenTypeEnum.PresumedCavePen
                                Case "invisible"
                                    oItem.Pen.Type = cPen.PenTypeEnum.None
                                Case Else
                            End Select
                            Select Case oScrapLine.GetParameters("-outline", "out")
                                Case "in"
                                    Dim oCaveBorderItem As cItemInvertedFreeHandArea = oItem
                                    oCaveBorderItem.MergeMode = cIItemMergeableArea.MergeModeEnum.Subtract
                                Case "none"
                                Case Else
                                    If bMergeAndReorderBorders Then Call oBorders.Add(oItem)
                            End Select
                        Case "label"
                            'azz...questo non ce l'ho...un testo sul tracciato...interessante...
                        Case "border"
                            Dim oLayerBorders As cLayerBorders = oDesign.Layers(cLayers.LayerTypeEnum.Borders)
                            oItem = oLayerBorders.CreateBorder(sCave, sBranch)
                            bLineStarted = True
                            Select Case oScrapLine.GetParameters("-subtype", "")
                                Case "presumed"
                                    oItem.Pen.Type = cPen.PenTypeEnum.PresumedPen
                                Case "invisible"
                                    oItem.Pen.Type = cPen.PenTypeEnum.None
                                Case Else
                            End Select
                        Case "rock-border"
                            Dim oLayerFloor As cLayerWaterAndFloorMorphologies = oDesign.Layers(cLayers.LayerTypeEnum.WaterAndFloorMorphologies)
                            oItem = oLayerFloor.CreateBorder(sCave, sBranch)
                            bLineStarted = True
                        Case "pit"
                            Dim oLayerFloor As cLayerWaterAndFloorMorphologies = oDesign.Layers(cLayers.LayerTypeEnum.WaterAndFloorMorphologies)
                            oItem = oLayerFloor.CreateCliffCurve(sCave, sBranch)
                            bReverse = oScrapLine.GetParameters("-reverse", "on") <> "on"
                            If bReverse Then
                                oItem.Pen.Type = cPen.PenTypeEnum.CliffDownPen
                            Else
                                oItem.Pen.Type = cPen.PenTypeEnum.CliffUpPen
                            End If
                            Select Case oScrapLine.GetParameters("-subtype", "")
                                Case "presumed"
                                    oItem.Pen.Type = cPen.PenTypeEnum.PresumedPen
                                Case "invisible"
                                    oItem.Pen.Type = cPen.PenTypeEnum.None
                                Case Else
                            End Select
                            bLineStarted = True
                        Case "chimney"
                            Dim oLayerFloor As cLayerWaterAndFloorMorphologies = oDesign.Layers(cLayers.LayerTypeEnum.WaterAndFloorMorphologies)
                            oItem = oLayerFloor.CreateCliffCurve(sCave, sBranch)
                            bReverse = oScrapLine.GetParameters("-reverse", "on") <> "on"
                            If bReverse Then
                                oItem.Pen.Type = cPen.PenTypeEnum.PresumedCliffDownPen
                            Else
                                oItem.Pen.Type = cPen.PenTypeEnum.PresumedCliffUpPen
                            End If
                            bLineStarted = True
                    End Select
                    If bLineStarted Then
                        Dim sID As String = oScrapLine.GetParameters("-id", "")
                        If sID <> "" Then
                            Call oIds.Add(sID, oItem)
                        End If

                        Dim sPlace As String = oScrapLine.GetParameters("-place", "default")
                        Select Case sPlace
                            Case "bottom"
                                Call oItem.Layer.Items.SendToBottom(oItem)
                            Case "top"
                                Call oItem.Layer.Items.BringToTop(oItem)
                        End Select

                        Dim bClipping As Boolean = oScrapLine.GetParameters("-clip", "on") = "on"
                        If Not bClipping Then
                            oItem.ClippingType = cItem.cItemClippingTypeEnum.None
                        End If
                        bFirstPoint = True
                    End If
                End If
            End If
        Loop
        Call sr.Close()
        Call sr.Dispose()
    End Sub
End Module
