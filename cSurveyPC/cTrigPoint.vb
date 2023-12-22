Imports System.Xml
Imports cSurveyPC.cSurvey.Calculate

Namespace cSurvey
    Public Class cTrigPoint
        Implements Data.cIObjectDataProperties

        Public Class cAliases
            Implements IEnumerable

            Private oItems As List(Of String)

            Public Sub CopyFrom(Aliases As cAliases)
                Call oItems.Clear()
                For Each sAlias As String In Aliases
                    Call oItems.Add(sAlias)
                Next
            End Sub

            Public Function ToArray() As String()
                Return oItems.ToArray
            End Function

            Public Overrides Function ToString() As String
                Return Strings.Join(oItems.ToArray, ",")
            End Function

            Friend Sub New(ByVal Aliases As cAliases)
                oItems = New List(Of String)(Aliases.ToArray)
            End Sub

            Friend Sub New(ByVal Aliases As List(Of String))
                oItems = New List(Of String)(Aliases)
            End Sub

            Friend Sub New(ByVal Aliases As XmlElement)
                oItems = New List(Of String)
                For Each oAlias As XmlElement In Aliases.ChildNodes
                    Call oItems.Add(oAlias.GetAttribute("value"))
                Next
            End Sub

            Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
                Dim oXmlAliases As XmlElement = Document.CreateElement("aliases")
                For Each sAlias As String In oItems
                    Dim oXMLAlias As XmlElement = Document.CreateElement("alias")
                    Call oXMLAlias.SetAttribute("value", sAlias)
                    Call oXmlAliases.AppendChild(oXMLAlias)
                Next
                Call Parent.AppendChild(oXmlAliases)
                Return oXmlAliases
            End Function

            Friend Sub New()
                oItems = New List(Of String)
            End Sub

            Public ReadOnly Property Count As Integer
                Get
                    Return oItems.Count
                End Get
            End Property

            Public Sub Clear()
                Call oItems.Clear()
            End Sub

            Public Sub AddRange(Aliases As IEnumerable(Of String))
                For Each sAlias In Aliases
                    Call oItems.Add(sAlias)
                Next
            End Sub

            Public Function Add(ByVal [Alias] As String) As Integer
                Dim sAlias As String = ("" & [Alias]).Trim
                If sAlias <> "" Then
                    Call oItems.Add(sAlias)
                    Return oItems.Count - 1
                Else
                    Return -1
                End If
            End Function

            Public Sub Remove(ByVal [Alias] As String)
                Call oItems.Remove([Alias])
            End Sub

            Public Sub Remove(ByVal Index As Integer)
                Call oItems.RemoveAt(Index)
            End Sub

            Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
                Return oItems.GetEnumerator
            End Function
        End Class

        Private oSurvey As cSurvey

        Public Enum TrigPointTypeEnum
            Undefined = 0
            Fixed = 1
            Painted = 2
            Temporary = 3
        End Enum

        Public Enum EntranceTypeEnum
            None = 0
            OtherCaveEntrance = 1
            MainCaveEntrace = 2
            MainComplexEntrance = 3
            OutSide = 4
        End Enum

        Public Enum TrigPointLabelSymbolEnum
            [Default] = 0
            Square = 1
            Circle = 2
            Plus = 3
            Cross = 4
            EmptySquare = 5
            EmptyCircle = 6
            Triangle = 7
            EmptyTriangle = 8
        End Enum

        Public Enum TrigPointLabelPositionEnum
            TopLeft = 0
            TopMiddle = 1
            TopRight = 2
            CenterLeft = 3
            Center = 4
            CenterRight = 5
            BottomLeft = 6
            BottomCenter = 7
            BottomRight = 8
        End Enum

        Public Enum TrigPointFixEnum
            [Default] = 0
            Forced = 1
        End Enum

        'Friend Structure cData
        '    Public Distance As Decimal
        'End Structure

        'Private oTempData As cData
        'Private oCurrentData As cData
        'Private oOldData As cData

        Private iEntrance As EntranceTypeEnum
        Private iType As TrigPointTypeEnum

        Private bShowEntrance As Boolean
        Private bIsSpecial As Boolean

        Private iLabelPosition As TrigPointLabelPositionEnum
        Private iLabelDistance As Integer
        Private iLabelSymbol As TrigPointLabelSymbolEnum
        Private bDrawTranslationsLine As Boolean

        Private WithEvents oCoordinate As cCoordinate
        Private iCoordinateFix As TrigPointFixEnum

        Private sName As String
        'Private sX As Decimal
        'Private sY As Decimal
        'Private sZ As Decimal
        Private bIsSystem As Boolean

        Private bIsInExploration As Boolean
        Private bZTurn As Boolean
        Private sNote As String

        Private bChanged As Boolean
        Private iInvalidated As cCalculate.InvalidateEnum

        Private oAliases As cAliases
        Private WithEvents oConnections As cConnections

        Private oDataProperties As Data.cDataProperties

        Private oPlotData As Calculate.Plot.cStationData

        Friend Event OnChange(ByVal Sender As Object, e As EventArgs)

        Private bHiddenInDesign As Boolean
        Private bHiddenInPreview As Boolean

        Public Overridable Property HiddenInDesign As Boolean
            Get
                Return bHiddenInDesign
            End Get
            Set(ByVal value As Boolean)
                If bHiddenInDesign <> value Then
                    bHiddenInDesign = value
                    RaiseEvent OnChange(Me, EventArgs.Empty)
                End If
            End Set
        End Property

        Public Overridable Property HiddenInPreview As Boolean
            Get
                Return bHiddenInPreview
            End Get
            Set(value As Boolean)
                If bHiddenInPreview <> value Then
                    bHiddenInPreview = value
                    RaiseEvent OnChange(Me, EventArgs.Empty)
                End If
            End Set
        End Property

        Friend ReadOnly Property Data() As Calculate.Plot.cStationData
            Get
                Return oPlotData
            End Get
        End Property

        Public ReadOnly Property DataProperties As Data.cDataProperties Implements Data.cIObjectDataProperties.DataProperties
            Get
                Return oDataProperties
            End Get
        End Property

        Friend Sub Rename(Name As String)
            sName = Name
        End Sub

        Public Overrides Function ToString() As String
            Return sName & If(oAliases.Count, " (" & oAliases.ToString & ")", "")
        End Function

        Public ReadOnly Property Aliases As cAliases
            Get
                Return oAliases
            End Get
        End Property

        Public ReadOnly Property Connections As cConnections
            Get
                Return oConnections
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal TrigPoint As cTrigPoint)
            oSurvey = Survey
            oAliases = New cAliases(TrigPoint.oAliases)
            oConnections = New cConnections

            sName = TrigPoint.sName

            iEntrance = False
            iType = TrigPointTypeEnum.Undefined

            bShowEntrance = TrigPoint.bShowEntrance

            iLabelPosition = TrigPoint.iLabelPosition
            iLabelDistance = TrigPoint.iLabelDistance
            iLabelSymbol = TrigPoint.iLabelSymbol
            bDrawTranslationsLine = TrigPoint.bDrawTranslationsLine

            oCoordinate = New cCoordinate(TrigPoint.oCoordinate)
            iCoordinateFix = TrigPoint.iCoordinateFix

            bIsInExploration = TrigPoint.bIsInExploration
            bIsSpecial = TrigPoint.bIsSpecial
            bIsSystem = TrigPoint.bIsSystem
            bZTurn = TrigPoint.bZTurn
            'bIsSplay = False
            'bIsOrphan = False

            sNote = TrigPoint.sNote

            oDataProperties = New Data.cDataProperties(oSurvey, oSurvey.Properties.DataTables.Trigpoints)
            Call oDataProperties.CopyFrom(TrigPoint.oDataProperties)

            oPlotData = New Calculate.Plot.cStationData(TrigPoint.Data)
        End Sub

        Public Property IsInExploration As Boolean
            Get
                Return bIsInExploration
            End Get
            Set(ByVal value As Boolean)
                If value <> bIsInExploration Then
                    bIsInExploration = value
                    bChanged = True
                End If
            End Set
        End Property

        Public Property ZTurn As Boolean
            Get
                Return bZTurn
            End Get
            Set(ByVal value As Boolean)
                If value <> bZTurn Then
                    bZTurn = value
                    bChanged = True
                End If
            End Set
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Name As String, ByVal TrigPoint As cTrigPoint)
            oSurvey = Survey
            oAliases = New cAliases(TrigPoint.oAliases)
            oConnections = New cConnections

            sName = sName.ToUpper
            'sX = TrigPoint.sX
            'sY = TrigPoint.sY
            'sZ = TrigPoint.sZ

            iEntrance = TrigPoint.iEntrance
            iType = TrigPoint.iType

            bShowEntrance = TrigPoint.bShowEntrance
            bIsSpecial = TrigPoint.bIsSpecial

            iLabelPosition = TrigPoint.iLabelPosition
            iLabelDistance = TrigPoint.iLabelDistance
            iLabelSymbol = TrigPoint.iLabelSymbol
            bDrawTranslationsLine = TrigPoint.bDrawTranslationsLine

            bIsInExploration = TrigPoint.bIsInExploration
            bIsSpecial = TrigPoint.bIsSpecial
            bIsSystem = TrigPoint.bIsSystem
            bZTurn = TrigPoint.bZTurn
            'bIsOrphan = False
            'bIsSplay = False

            sNote = TrigPoint.sNote

            oCoordinate = New cCoordinate(TrigPoint.oCoordinate)
            iCoordinateFix = TrigPoint.iCoordinateFix

            oDataProperties = New Data.cDataProperties(oSurvey, oSurvey.Properties.DataTables.Trigpoints)

            oPlotData = New Calculate.Plot.cStationData(TrigPoint.Data)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Name As String, Optional ByVal X As Decimal = 0, Optional ByVal Y As Decimal = 0, Optional ByVal Z As Decimal = 0, Optional IsSystem As Boolean = False)
            oSurvey = Survey
            oAliases = New cAliases()
            oConnections = New cConnections

            sName = Name.ToUpper
            'sX = X
            'sY = Y
            'sZ = Z

            iEntrance = False
            iType = TrigPointTypeEnum.Undefined

            bShowEntrance = False
            bIsSpecial = False

            iLabelPosition = TrigPointLabelPositionEnum.BottomRight
            iLabelDistance = 10
            iLabelSymbol = TrigPointLabelSymbolEnum.Default
            bDrawTranslationsLine = True

            bIsInExploration = False
            bIsSpecial = False
            bIsSystem = IsSystem
            bZTurn = False
            'bIsSplay = False
            'bIsOrphan = False

            sNote = ""

            oCoordinate = New cCoordinate
            With oCoordinate
                .System = oSurvey.Properties.GPS.System
                Select Case .System
                    Case "WGS84/UTM"
                        If oSurvey.Properties.GPS.Band <> "" Then .Band = oSurvey.Properties.GPS.Band
                        If oSurvey.Properties.GPS.Zone <> "" Then .Zone = oSurvey.Properties.GPS.Zone
                    Case Else
                        If oSurvey.Properties.GPS.Format <> "" Then .Format = oSurvey.Properties.GPS.Format
                End Select
            End With
            iCoordinateFix = TrigPointFixEnum.Default

            oDataProperties = New Data.cDataProperties(oSurvey, oSurvey.Properties.DataTables.Trigpoints)

            oPlotData = New Calculate.Plot.cStationData(X, Y, Z, False, False, False)
        End Sub

        Public ReadOnly Property Index As Integer
            Get
                Return oSurvey.TrigPoints.IndexOf(Me)
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal TrigPoint As XmlElement)
            oSurvey = Survey

            Dim oXMLAliases As XmlElement = TrigPoint.Item("aliases")
            If oXMLAliases Is Nothing Then
                oAliases = New cAliases
            Else
                oAliases = New cAliases(oXMLAliases)
            End If

            Dim oXMLConnection As XmlElement = TrigPoint.Item("connections")
            If oXMLConnection Is Nothing Then
                oConnections = New cConnections
            Else
                oConnections = New cConnections(oXMLConnection)
            End If

            sName = modXML.GetAttributeValue(TrigPoint, "name")

            iEntrance = modXML.GetAttributeValue(TrigPoint, "entrance")
            iType = modXML.GetAttributeValue(TrigPoint, "type")

            bShowEntrance = modXML.GetAttributeValue(TrigPoint, "showentrance")

            iLabelPosition = modXML.GetAttributeValue(TrigPoint, "labelposition", TrigPointLabelPositionEnum.BottomRight)
            iLabelSymbol = modXML.GetAttributeValue(TrigPoint, "labelsymbol")
            iLabelDistance = modXML.GetAttributeValue(TrigPoint, "labeldistance", 10)
            bDrawTranslationsLine = modXML.GetAttributeValue(TrigPoint, "drawtranslationsline", True)

            Dim oXMLCoordinate As XmlElement = TrigPoint.Item("coordinate")
            If oXMLCoordinate Is Nothing Then
                oCoordinate = New cCoordinate
            Else
                oCoordinate = New cCoordinate(oXMLCoordinate)
            End If
            iCoordinateFix = modXML.GetAttributeValue(TrigPoint, "coordinatefix")

            bIsInExploration = modXML.GetAttributeValue(TrigPoint, "isinexploration")
            bIsSpecial = modXML.GetAttributeValue(TrigPoint, "isspecial")
            bIsSystem = modXML.GetAttributeValue(TrigPoint, "issystem")
            bZTurn = modXML.GetAttributeValue(TrigPoint, "zturn")

            sNote = modXML.GetAttributeValue(TrigPoint, "note", "")

            If modXML.ChildElementExist(TrigPoint, "datarow") Then
                oDataProperties = New Data.cDataProperties(oSurvey, oSurvey.Properties.DataTables.Trigpoints, TrigPoint.Item("datarow"))
            Else
                oDataProperties = New Data.cDataProperties(oSurvey, oSurvey.Properties.DataTables.Trigpoints)
            End If

            If modXML.ChildElementExist(TrigPoint, "data") Then
                oPlotData = New Calculate.Plot.cStationData(TrigPoint.Item("data"))
            Else
                oPlotData = New Calculate.Plot.cStationData()
            End If
        End Sub

        Public Property ShowEntrance() As Boolean
            Get
                Return bShowEntrance
            End Get
            Set(ByVal value As Boolean)
                If bShowEntrance <> value Then
                    bShowEntrance = value
                    bChanged = True
                End If
            End Set
        End Property

        'Friend Function GetBearing(ByVal Bearing As Decimal, ByVal Session As String) As Decimal
        '    Return GetBearing(Bearing, oSurvey.Properties.Sessions(Session))
        'End Function

        'Friend Function GetBearing(ByVal Bearing As Decimal, ByVal Session As cSession) As Decimal
        '    If Session Is Nothing Then
        '        If oSurvey.Properties.NordType = cSegment.NordTypeEnum.Geographic Then
        '            Return Bearing
        '        Else
        '            Return Bearing + IIf(oSurvey.Properties.declinationenabled, oSurvey.Properties.Declination, 0)
        '        End If
        '    Else
        '        If Session.NordType = cSegment.NordTypeEnum.Geographic Then
        '            Return Bearing
        '        Else
        '            Return Bearing + IIf(Session.declinationenabled, Session.Declination, 0)
        '        End If
        '    End If
        'End Function

        'Public Property Declination As Decimal
        '    Get
        '        Return sDeclination
        '    End Get
        '    Set(ByVal value As Decimal)
        '        sDeclination = value
        '    End Set
        'End Property

        Public Property Note() As String
            Get
                Return sNote
            End Get
            Set(ByVal value As String)
                If sNote <> value Then
                    sNote = value
                    bChanged = True
                End If
            End Set
        End Property

        Public Property Entrance() As EntranceTypeEnum
            Get
                Return iEntrance
            End Get
            Set(ByVal value As EntranceTypeEnum)
                If iEntrance <> value Then
                    iEntrance = value
                    bChanged = True
                End If
            End Set
        End Property

        Public Property Type() As TrigPointTypeEnum
            Get
                Return iType
            End Get
            Set(ByVal value As TrigPointTypeEnum)
                If iType <> value Then
                    iType = value
                    bChanged = True
                End If
            End Set
        End Property

        Public ReadOnly Property Coordinate() As cCoordinate
            Get
                Return oCoordinate
            End Get
        End Property

        Public Function IsEntrance() As Boolean
            Return iEntrance > EntranceTypeEnum.None And iEntrance <= EntranceTypeEnum.MainComplexEntrance
        End Function

        Public Function IsOutside() As Boolean
            Return iEntrance <> EntranceTypeEnum.None
        End Function

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXmlTrigPoint As XmlElement = Document.CreateElement("trigpoint")
            If oAliases.Count > 0 Then Call oAliases.SaveTo(File, Document, oXmlTrigPoint)
            If oConnections.Count > 0 Then Call oConnections.SaveTo(File, Document, oXmlTrigPoint)
            Call oXmlTrigPoint.SetAttribute("name", sName)
            'Call oXmlTrigPoint.SetAttribute("x", modNumbers.NumberToString(sX))
            'Call oXmlTrigPoint.SetAttribute("y", modNumbers.NumberToString(sY))
            'Call oXmlTrigPoint.SetAttribute("z", modNumbers.NumberToString(sZ))
            If iEntrance <> EntranceTypeEnum.None Then Call oXmlTrigPoint.SetAttribute("entrance", iEntrance)
            If iType <> TrigPointTypeEnum.Undefined Then Call oXmlTrigPoint.SetAttribute("type", iType.ToString("D"))
            If bShowEntrance Then Call oXmlTrigPoint.SetAttribute("showentrance", 1)
            If sNote <> "" Then Call oXmlTrigPoint.SetAttribute("note", sNote)
            If iLabelPosition <> TrigPointLabelPositionEnum.BottomRight Then Call oXmlTrigPoint.SetAttribute("labelposition", iLabelPosition.ToString("D"))
            If iLabelDistance <> 10 Then Call oXmlTrigPoint.SetAttribute("labeldistance", iLabelDistance)
            If iLabelSymbol <> TrigPointLabelSymbolEnum.Square Then Call oXmlTrigPoint.SetAttribute("labelsymbol", iLabelSymbol.ToString("D"))
            If Not bDrawTranslationsLine Then Call oXmlTrigPoint.SetAttribute("drawtranslationsline", "0")
            If Not oCoordinate.IsEmpty Then Call oCoordinate.SaveTo(File, Document, oXmlTrigPoint)
            If bIsInExploration Then Call oXmlTrigPoint.SetAttribute("isinexploration", 1)
            If bZTurn Then Call oXmlTrigPoint.SetAttribute("zturn", 1)
            If bIsSystem Then Call oXmlTrigPoint.SetAttribute("issystem", 1)
            If bIsSpecial Then Call oXmlTrigPoint.SetAttribute("isspecial", 1)
            If oDataProperties.Count <> 0 Then Call oDataProperties.SaveTo(File, Document, oXmlTrigPoint, Options)
            Call oPlotData.SaveTo(File, Document, oXmlTrigPoint)
            Call Parent.AppendChild(oXmlTrigPoint)
            Return oXmlTrigPoint
        End Function

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public ReadOnly Property IsSystem As Boolean
            Get
                Return bIsSystem
            End Get
        End Property

        Public ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public Sub Cancel()
            bChanged = False
        End Sub

        Public Sub Save()
            If bChanged Then
                RaiseEvent OnChange(Me, EventArgs.Empty)
                bChanged = False
                iInvalidated = cCalculate.InvalidateEnum.None
            End If
        End Sub

        Public ReadOnly Property Changed() As Boolean
            Get
                Return bChanged
            End Get
        End Property

        Public Function Clone(Optional ByVal Name As String = "") As cTrigPoint
            If Name = "" Then
                Return New cTrigPoint(oSurvey, Me)
            Else
                Return New cTrigPoint(oSurvey, Name, Me)
            End If
        End Function

        'Friend Sub MoveTo(ByVal X As Decimal, ByVal Y As Decimal, ByVal Z As Decimal)
        '    sX = X
        '    sY = Y
        '    sZ = Z
        'End Sub

        'Friend Sub MoveBy(ByVal X As Decimal, ByVal Y As Decimal, ByVal Z As Decimal)
        '    sX += X
        '    sY += Y
        '    sZ += Z
        'End Sub
        Public Property DrawTranslationsLine As Boolean
            Get
                Return bDrawTranslationsLine
            End Get
            Set(ByVal value As Boolean)
                If bDrawTranslationsLine <> value Then
                    bDrawTranslationsLine = value
                    bChanged = True
                End If
            End Set
        End Property

        Public Property LabelSymbol As TrigPointLabelSymbolEnum
            Get
                Return iLabelSymbol
            End Get
            Set(ByVal value As TrigPointLabelSymbolEnum)
                If iLabelSymbol <> value Then
                    iLabelSymbol = value
                    bChanged = True
                End If
            End Set
        End Property

        Public Property LabelDistance As Decimal
            Get
                Return iLabelDistance
            End Get
            Set(ByVal value As Decimal)
                If iLabelDistance <> value Then
                    iLabelDistance = value
                    bChanged = True
                End If
            End Set
        End Property

        Public Property LabelPosition As TrigPointLabelPositionEnum
            Get
                Return iLabelPosition
            End Get
            Set(ByVal value As TrigPointLabelPositionEnum)
                If iLabelPosition <> value Then
                    iLabelPosition = value
                    bChanged = True
                End If
            End Set
        End Property

        Public Property IsSpecial() As Boolean
            Get
                Return bIsSpecial
            End Get
            Set(ByVal value As Boolean)
                If bIsSpecial <> value Then
                    bIsSpecial = value
                    bChanged = True
                End If
            End Set
        End Property

        Public Function GetSegments() As cSegmentCollection
            Return oSurvey.Segments.Find(sName)
        End Function

        Private Sub oCoordinate_OnChange(ByVal Sender As cCoordinate) Handles oCoordinate.OnChange
            bChanged = True
            iInvalidated = cCalculate.InvalidateEnum.FullCalculate
            RaiseEvent OnChange(Me, EventArgs.Empty)
        End Sub

        Private Sub oConnections_OnConnectionChanged(ByVal Sender As cConnections, ByVal e As cConnections.cConnectionsEventArgs) Handles oConnections.OnConnectionChanged
            bChanged = True
            iInvalidated = cCalculate.InvalidateEnum.FullCalculate
            RaiseEvent OnChange(Me, EventArgs.Empty)
        End Sub

        Private Sub oConnections_OnGetOwnerStation(ByVal Sender As cConnections, ByVal e As cConnections.cGetOwnerEventArgs) Handles oConnections.OnGetOwnerStation
            e.TrigPoint = sName
        End Sub

        Public Function IsPlanBinded() As Boolean
            For Each oSegment As cSegment In GetSegments()
                If oSegment.IsPlanBinded Then
                    Return True
                End If
            Next
            Return False
        End Function

        Public Function IsProfileBinded() As Boolean
            For Each oSegment As cSegment In GetSegments()
                If oSegment.IsProfileBinded Then
                    Return True
                End If
            Next
            Return False
        End Function

        Public Function IsBinded() As Boolean
            For Each oSegment As cSegment In GetSegments()
                If oSegment.IsPlanBinded Or oSegment.IsProfileBinded Then
                    Return True
                End If
            Next
            Return False
        End Function

        Friend ReadOnly Property Invalidated As cCalculate.InvalidateEnum
            Get
                Return iInvalidated
            End Get
        End Property
    End Class
End Namespace