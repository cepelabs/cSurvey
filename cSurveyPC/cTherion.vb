Imports System.Drawing.Text
Imports System.IO
Imports System.Text
Imports System.Windows.Controls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports System.Windows.Shapes
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports DevExpress.Charts.Native
Imports DevExpress.Data.Async.Helpers
Imports DevExpress.Utils.Drawing.Helpers.NativeMethods
Imports DevExpress.Utils.Extensions
Imports DevExpress.XtraCharts
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.Commands
Imports DevExpress.XtraRichEdit.Fields
Imports DevExpress.XtraRichEdit.Import.Html
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Printing
Imports OfficeOpenXml.FormulaParsing.Excel.Functions.Math
Imports OfficeOpenXml.FormulaParsing.Excel.Functions.Text

Public Class cTherion

    '   encoding ISO8859-2

    'survey nad_pad -title "Nad Padavkou"

    '  centerline
    '    team "Martin Budaj"
    '    team "Stacho Mudrák"
    '    team "Libor ©tubòa"
    '    Date 2000.8.1
    '    calibrate tape 0 0.96
    '    units clino compass grad
    '    data normal from To compass clino length

    '  0      1	181	 44	  6.3
    '  1      2	 83	 -6	  4.7
    '  2      3	 90	 -2	  2.68
    '  3      4	 83	 11	  6.08
    '  4      5	 55	-32	  6.19
    '  2      6	 17	-26	  4.06
    '  3      7	396	-28	  3.64
    '  7      6	290	  1	  1.6
    '  5      8	112	  4	  6.85
    '  8      9	203	 46	  8.66
    '  9     10	222	 62	  3.63

    ' 10     11	294	 -8	  1.72
    ' 11     12	179	 -4	  2.87
    ' 12     13	257	 12	  4.3
    ' 12     14	 99	 17	  2.58

    '  endcenterline
    'endsurvey

    'Private Class cCenterline
    '    Private oTeams As List(Of String)
    '    Private dDate As Date
    '    Private oUnits As List(Of String)
    '    Private oData As List(Of String)

    '    Public Sub New()
    '        oData = New List(Of String)
    '        oData = New List(Of String)

    '        oData = New List(Of String)
    '    End Sub
    'End Class

    Private Shared Function pTherionLineSplit(Line As String) As String()
        Dim sParts As List(Of String) = New List(Of String)
        If Line.Length > 0 Then
            Dim sPart As String = ""
            Dim iIndex As Integer
            Dim bDouble As Boolean
            Do
                Dim sChar As Char = Line(iIndex)
                Select Case sChar
                    Case " "c
                        If bDouble Then
                            sPart &= sChar
                        Else
                            If sPart <> "" Then
                                sParts.Add(sPart)
                                sPart = ""
                            End If
                        End If
                    Case """"c
                        bDouble = Not bDouble
                    Case Else
                        sPart &= sChar
                End Select
                iIndex += 1
            Loop While iIndex < Line.Length
            If sPart <> "" Then
                sParts.Add(sPart)
            End If
        End If
        Return sParts.ToArray
    End Function

    Private Enum TherionCoordinateSystem
        Unknown = 0
        WGS84GEO = 1
        WGS84UTM = 2
    End Enum

    Private Enum TherionExtend
        Right = 0
        Left = 1
        Vertical = 2
    End Enum

    Private Enum TherionDataType
        Normal = 0
        Dimensions = 1
    End Enum

    Private Class cFactor
        Private dFactors As Dictionary(Of String, Decimal)

        Public Sub SetFactor(Measure As String, Value As Decimal)
            If dFactors.ContainsKey(Measure) Then dFactors.Remove(Measure)
            dFactors.Add(Measure, Value)
        End Sub

        Public Function GetFactor(Measure As String) As Decimal
            If dFactors.ContainsKey(Measure) Then
                Return dFactors(Measure)
            Else
                Return 1D
            End If
        End Function

        Public Sub New()
            dFactors = New Dictionary(Of String, Decimal)(StringComparer.OrdinalIgnoreCase)
        End Sub
    End Class

    Private Class cData
        Private oFields As List(Of String)
        Private iType As TherionDataType

        Public ReadOnly Property Fields As List(Of String)
            Get
                Return oFields
            End Get
        End Property

        Public Property Type As TherionDataType
            Get
                Return iType
            End Get
            Set(value As TherionDataType)
                iType = value
            End Set
        End Property

        Public Sub New(Type As TherionDataType)
            iType = Type
            oFields = New List(Of String)
        End Sub
    End Class

    Private Class cTherionImporter
        Private iSplayCount As Long

        Private dNow As Date

        Public ReadOnly Property Now As Date
            Get
                Return dNow
            End Get
        End Property

        Public Function GetSplayCount() As Long
            iSplayCount += 1
            Return iSplayCount
        End Function

        Public CaveCount As Integer

        Public IsInSurvey As Integer
        Public InCenterline As Integer

        Public LastExtend As TherionExtend
        Public LastDuplicate As Boolean
        Public LastSurface As Boolean
        Public LastSplay As Boolean
        Public LastCoordinateSystem As TherionCoordinateSystem
        Public LastCoordinateZone As String
        Public LastCoordinateBand As String

        Private oDataBySession As Dictionary(Of cSession, cData)
        Private oFactorBySession As Dictionary(Of cSession, cFactor)
        Private oSessionStack As Stack(Of cSession)
        Private oCaveBranchStack As Stack(Of cICaveInfoBranches)
        Private oCaveNamesStack As Stack(Of String)

        Public ReadOnly Property CaveNamesStack As Stack(Of String)
            Get
                Return oCaveNamesStack
            End Get
        End Property

        Public ReadOnly Property CaveBranchStack As Stack(Of cICaveInfoBranches)
            Get
                Return oCaveBranchStack
            End Get
        End Property

        Public ReadOnly Property SessionStack As Stack(Of cSession)
            Get
                Return oSessionStack
            End Get
        End Property

        Public ReadOnly Property FactorBySession As Dictionary(Of cSession, cFactor)
            Get
                Return oFactorBySession
            End Get
        End Property

        Public ReadOnly Property DataBySession As Dictionary(Of cSession, cData)
            Get
                Return oDataBySession
            End Get
        End Property

        Public Sub New()
            dNow = Date.Now
            oDataBySession = New Dictionary(Of cSession, cData)
            oFactorBySession = New Dictionary(Of cSession, cFactor)
            oSessionStack = New Stack(Of cSession)
            oCaveBranchStack = New Stack(Of cICaveInfoBranches)
            oCaveNamesStack = New Stack(Of String)
        End Sub

        Private sLastComment As String

        Public Property LastComment As String
            Get
                Return sLastComment
            End Get
            Set(value As String)
                sLastComment = value
            End Set
        End Property

        Private olastSegment As cSegment

        Public Property LastSegment As cSegment
            Get
                Return olastSegment
            End Get
            Set(value As cSegment)
                olastSegment = value
            End Set
        End Property
    End Class

    Private Shared Function pGetColor(Palette As Palette, Index As Integer) As Color
        Dim iIndex As Integer = Index Mod Palette.Count
        Return Palette(iIndex).Color
    End Function

    Public Class cTherionImportOptions
        Private oCave As cCaveInfo
        Private oBranch As cCaveInfoBranch

        Private bImportAsNewcave As Boolean
        Private bImportLineOfComment As Boolean

        Private sStationPrefix As String

        Public Sub New(StationPrefix As String, Cave As cCaveInfo, Branch As cCaveInfoBranch, ImportAsNewcave As Boolean, ImportLineOfComment As Boolean)
            sStationPrefix = StationPrefix
            oCave = Cave
            oBranch = Branch
            bImportAsNewcave = ImportAsNewcave
            bImportLineOfComment = ImportLineOfComment
        End Sub

        Public ReadOnly Property StationPrefix As String
            Get
                Return sStationPrefix
            End Get
        End Property

        Public ReadOnly Property ImportAsNewcave As Boolean
            Get
                Return bImportAsNewcave
            End Get
        End Property

        Public ReadOnly Property ImportLineOfComment As Boolean
            Get
                Return bImportLineOfComment
            End Get
        End Property

        Public ReadOnly Property Cave As cCaveInfo
            Get
                Return oCave
            End Get
        End Property

        Public ReadOnly Property Branch As cCaveInfoBranch
            Get
                Return oBranch
            End Get
        End Property
    End Class

    Private Shared Sub pImport(Survey As cSurveyPC.cSurvey.cSurvey, Importer As cTherionImporter, Filename As String, Options As cTherionImportOptions)
        Debug.Print("TH:IMPORT filename: " & Filename)
        Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Warning, "Processing " & Filename & "")
        Dim iRow As Integer = 0
        Using sr As StreamReader = New StreamReader(Filename, True)
            Do Until sr.EndOfStream
                Dim sLine As String = sr.ReadLine.TrimStart({" "c, Chr(9)}).Trim
                If sLine.StartsWith("#") Then
                    If Options.ImportLineOfComment Then
                        Dim sComment As String = sLine.TrimStart({"#"c}).Trim
                        If Importer.InCenterline > 0 AndAlso sComment <> "" Then
                            If Importer.LastSegment IsNot Nothing Then
                                If Importer.LastSegment.Note <> "" Then Importer.LastSegment.Note &= vbCrLf
                                Importer.LastSegment.Note &= sComment
                            Else
                                If Importer.LastComment IsNot Nothing Then Importer.LastComment &= vbCrLf
                                Importer.LastComment = sComment
                            End If
                        End If
                    End If
                Else
                    Dim sLineParts As String() = pTherionLineSplit(sLine)
                    If sLineParts.Count > 0 Then
                        If sLineParts(0) = "encoding" Then
                            'TODO: ok but how to manage this?
                            Dim oEncoding = Encoding.GetEncoding(sLineParts(1))
                            Debug.Print(oEncoding.BodyName)
                        End If
                        Dim sFirstTag As String = sLineParts(0).ToLower
                        Select Case sFirstTag
                            Case "encoding"
                            'not at first line????

                            Case "map"
                                Do Until sr.ReadLine.TrimStart({" "c, Chr(9)}).Trim = "endmap"
                                Loop

                            Case "scrap"
                                'importing scrap is not really simple (there is a dedicated import to be merged here but therion scrap have to be morphed to centerline...)
                                'at now I skip scrap
                                Do Until sr.ReadLine.TrimStart({" "c, Chr(9)}).Trim = "endscrap"
                                Loop
                            Case "join"
                                'used for scrap...ignored

                            Case "survey"
                                Dim sName As String = sLineParts(1)
                                Call Importer.CaveNamesStack.Push(sName)
                                Dim sTitle As String = pTherionGetOption(sLineParts, "title", sName)
                                If Importer.CaveNamesStack.Count > 1 Then
                                    Dim oCave As cICaveInfoBranches = Importer.CaveBranchStack.Peek
                                    Dim oBranch As cCaveInfoBranch = oCave.Branches.Add(sName)
                                    oBranch.Description = sTitle
                                    Importer.CaveCount += 1
                                    oBranch.Color = pGetColor(Palettes.NatureColors, Importer.CaveCount)
                                    Call Importer.CaveBranchStack.Push(oBranch)
                                Else
                                    Dim oCave As cICaveInfoBranches
                                    If Options.Cave Is Nothing Then
                                        If Options.ImportAsNewcave Then
                                            Dim sFinalName As String = Options.Cave.Branches.GetUniqueName(sName)
                                            oCave = Survey.Properties.CaveInfos.Add(sFinalName)
                                        Else
                                            If Survey.Properties.CaveInfos.Contains(sName) Then
                                                oCave = Survey.Properties.CaveInfos(sName)
                                            Else
                                                oCave = Survey.Properties.CaveInfos.Add(sName)
                                            End If
                                        End If
                                    Else
                                        If Options.ImportAsNewcave Then
                                            If Options.Branch Is Nothing Then
                                                Dim sFinalName As String = Options.Cave.Branches.GetUniqueName(sName)
                                                oCave = Options.Cave.Branches.Add(sFinalName)
                                            Else
                                                Dim sFinalName As String = Options.Branch.Branches.GetUniqueName(sName)
                                                oCave = Options.Branch.Branches.Add(sFinalName)
                                            End If
                                        Else
                                            If Options.Branch Is Nothing Then
                                                If Options.Cave.Branches.Contains(sName) Then
                                                    oCave = Options.Cave.Branches(sName)
                                                Else
                                                    oCave = Options.Cave.Branches.Add(sName)
                                                End If
                                            Else
                                                If Options.Branch.Branches.Contains(sName) Then
                                                    oCave = Options.Branch.Branches(sName)
                                                Else
                                                    oCave = Options.Branch.Branches.Add(sName)
                                                End If
                                            End If
                                        End If
                                    End If
                                    oCave.Description = sTitle
                                    oCave.Color = pGetColor(Palettes.NatureColors, Importer.CaveCount)
                                    Importer.CaveCount += 1
                                    Call Importer.CaveBranchStack.Push(oCave)
                                End If
                                Importer.IsInSurvey += 1
                            Case "endsurvey"
                                Call Importer.CaveBranchStack.Pop()
                                Call Importer.CaveNamesStack.Pop()
                                Importer.IsInSurvey -= 1
                            Case "centerline"
                                Dim oSession As cSession = Survey.Properties.Sessions.Add(Date.Today, Guid.NewGuid.ToString)
                                Importer.SessionStack.Push(oSession)
                                Call Importer.FactorBySession.Add(oSession, New cFactor())
                                Importer.InCenterline += 1

                                Dim oData As cData = New cData(TherionDataType.Normal)
                                oData.Fields.Add("from")
                                oData.Fields.Add("to")
                                oData.Fields.Add("length")
                                oData.Fields.Add("compass")
                                oData.Fields.Add("clino")
                                Call Importer.DataBySession.Add(oSession, oData)
                            Case "endcenterline"
                                Importer.LastSegment = Nothing
                                Importer.LastComment = Nothing

                                Dim oSession As cSession = Importer.SessionStack.Pop()
                                Call Importer.DataBySession.Remove(oSession)
                                Importer.InCenterline -= 1

                            Case "date"
                                Dim oSession As cSession = Importer.SessionStack.Peek
                                Dim oNewDate As Date
                                If Not Date.TryParse(sLineParts(1), oNewDate) Then
                                    oNewDate = New Date(sLineParts(1), 1, 1)
                                End If
                                Call Survey.Properties.Sessions.Rename(oSession, oNewDate, oSession.Description)
                            Case "data"
                                Dim oSession As cSession = Importer.SessionStack.Peek
                                If sLineParts(1) = "normal" Then
                                    Dim oData As cData = New cData(TherionDataType.Normal)
                                    For iData As Integer = 2 To sLineParts.Count - 1
                                        oData.Fields.Add(sLineParts(iData))
                                    Next
                                    'TODO: support back/noback cases
                                    If oData.Fields.Contains("backcompass") Then
                                        oSession.BearingDirection = cSegment.MeasureDirectionEnum.Inverted
                                    End If
                                    If oData.Fields.Contains("backclino") Then
                                        oSession.InclinationDirection = cSegment.MeasureDirectionEnum.Inverted
                                    End If
                                    If Importer.DataBySession.ContainsKey(oSession) Then Importer.DataBySession.Remove(oSession)
                                    Call Importer.DataBySession.Add(oSession, oData)
                                ElseIf sLineParts(1) = "dimensions" Then
                                    Dim oData As cData = New cData(TherionDataType.Dimensions)
                                    For iData As Integer = 2 To sLineParts.Count - 1
                                        oData.Fields.Add(sLineParts(iData))
                                    Next
                                    Call Importer.DataBySession.Add(oSession, oData)
                                End If
                            Case "explo-team"
                                'not supported
                                Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Warning, "Unsupported tag " & sFirstTag & " in " & Filename & "[" & iRow & "]")

                            Case "explo-date"
                                'not supported
                                Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Warning, "Unsupported tag " & sFirstTag & " in " & Filename & "[" & iRow & "]")

                            Case "team"
                                If sLineParts.Count > 0 Then
                                    Dim oSession As cSession = Importer.SessionStack.Peek
                                    If oSession.Team <> "" Then Importer.SessionStack.Peek.Team &= ", "
                                    Importer.SessionStack.Peek.Team &= sLineParts(1)
                                End If

                            Case "break"

                            Case "mark"
                            Case "infer"
                            Case "grid-angle"
                            Case "declination"
                            Case "grade"
                            Case "sd"
                            Case "instrument"
                            Case "calibrate"

                            Case "station-names"

                            Case "units"
                                'meter[s], centimeter[s], inch[es], feet[s], yard[s] (also m, CM, in, ft, yd). Angle units supported: degree[s], Minute[s] (also deg, min), grad[s],mil[s], percent[age]
                                Dim oSession As cSession = Importer.SessionStack.Peek
                                'units length left right up down cm
                                Dim sUnit As String = sLineParts(sLineParts.Length - 1)
                                Dim oUnits As List(Of String) = New List(Of String)
                                For iUnit As Integer = 1 To sLineParts.Length - 2
                                    oUnits.Add(sLineParts(iUnit))
                                Next
                                'length, tape, bearing, compass, gradient, clino, counter, depth, x, y, z, position, easting, dx, northing,
                                If oUnits.Contains("clino") Then
                                    Select Case sUnit.ToLower
                                        Case "degree", "degrees", "deg"
                                            oSession.InclinationType = cSegment.InclinationTypeEnum.DecimalDegree
                                        Case "grad", "grads"
                                            oSession.InclinationType = cSegment.InclinationTypeEnum.CentesimalDegree
                                        Case "percentage", "percent"
                                            oSession.InclinationType = cSegment.InclinationTypeEnum.Percentage
                                        Case Else
                                            Debug.Print("TH:UNITS: unsupported unit " & sUnit & " for inclination")
                                            Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Warning, "Unsupported unit " & sUnit & " for inclination in " & Filename)
                                    End Select
                                End If
                                If oUnits.Contains("bearing") Then
                                    Select Case sUnit.ToLower
                                        Case "degree", "degrees", "deg"
                                            oSession.BearingType = cSegment.BearingTypeEnum.DecimalDegree
                                        Case "grad", "grads"
                                            oSession.BearingType = cSegment.BearingTypeEnum.CentesimalDegree
                                        Case Else
                                            Debug.Print("TH:UNITS: unsupported unit " & sUnit & " for bearing")
                                            Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Warning, "Unsupported unit " & sUnit & " for bearing in " & Filename)
                                    End Select
                                End If
                                If oUnits.Contains("length") Then
                                    Select Case sUnit.ToLower
                                        Case "meter", "meters", "m"
                                            oSession.DistanceType = cSegment.DistanceTypeEnum.Meters
                                        Case "cm", "centimeters"
                                            oSession.DistanceType = cSegment.DistanceTypeEnum.Meters
                                            Importer.FactorBySession(oSession).SetFactor("distance", 0.01D)
                                        Case "feet", "feets", "ft"
                                            oSession.DistanceType = cSegment.DistanceTypeEnum.Feet
                                        Case "yard", "yards", "yd"
                                            oSession.DistanceType = cSegment.DistanceTypeEnum.Yards
                                        Case Else
                                            Debug.Print("TH:UNITS: unsupported unit " & sUnit & " for distance")
                                            Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Warning, "Unsupported unit " & sUnit & " for distance in " & Filename)
                                    End Select
                                End If
                                'If oUnits.Contains("left") Then
                                '    Select Case sUnit.ToLower
                                '        Case "meter", "meters", "m"
                                '            oSession.DistanceTyape = cSegment.DistanceTypeEnum.Meters
                                '        Case "cm", "centimeters"
                                '            oSession.DistanceType = cSegment.DistanceTypeEnum.Meters
                                '            oFactorBySession(oSession).SetFactor("distance", 0.01D)
                                '        Case "feet", "feets", "ft"
                                '            oSession.DistanceType = cSegment.DistanceTypeEnum.Feet
                                '        Case "yard", "yards", "yd"
                                '            oSession.DistanceType = cSegment.DistanceTypeEnum.Yards
                                '        Case Else
                                '            Debug.Print("TH:UNITS: unsupported unit " & sUnit & " for distance")
                                '    End Select
                                'End If
                            Case "input"
                                'jump to another file...
                                Dim sFilename As String = sLineParts(1)
                                sFilename = sFilename.Replace("/", IO.Path.DirectorySeparatorChar)
                                If sFilename.EndsWith(".") Then sFilename = sFilename.TrimEnd({"."c})
                                If IO.Path.GetExtension(sFilename) = "" Then sFilename &= ".th"
                                sFilename = IO.Path.Combine(IO.Path.GetDirectoryName(Filename), sFilename)
                                Call pImport(Survey, Importer, sFilename, Options)
                            Case "equate"
                                Dim sName As String = Importer.CaveNamesStack.Peek
                                Dim oSegment As cSegment = Survey.Segments.Append()
                                Dim sFrom As String = sLineParts(1)
                                Dim sTo As String = sLineParts(2)

                                If Not sFrom.Contains("@") Then sFrom = sFrom & "@" & sName
                                If Not sTo.Contains("@") Then sTo = sTo & "@" & sName

                                If sFrom.Contains(".") Then
                                    Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Warning, "Removed unsupported subsurvey reference from " & sFrom)
                                    sFrom = sFrom.Substring(0, sFrom.IndexOf("."))
                                End If
                                If sTo.Contains(".") Then
                                    Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Warning, "Removed unsupported subsurvey reference from " & sTo)
                                    sTo = sTo.Substring(0, sTo.IndexOf("."))
                                End If

                                oSegment.From = Options.StationPrefix & sFrom
                                oSegment.To = Options.StationPrefix & sTo

                                Call oSegment.DataProperties.SetValue("import_source", "therion")
                                Call oSegment.DataProperties.SetValue("import_date", Importer.Now)
                                Call oSegment.DataProperties.SetValue("import_filename", Filename)
                                Call oSegment.DataProperties.SetValue("import_row", iRow)

                                oSegment.Save()
                                Importer.LastSegment = oSegment
                            Case "extend"
                                Select Case sLineParts(1)
                                    Case "right"
                                        Importer.LastExtend = TherionExtend.Right
                                    Case "left"
                                        Importer.LastExtend = TherionExtend.Left
                                    Case "vertical"
                                        Importer.LastExtend = TherionExtend.Vertical
                                    Case Else
                                        Debug.Print("TH:EXTEND->" & sLineParts(1))
                                        Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Warning, "Unsupported extend " & sLineParts(1) & " in " & Filename & "[" & iRow & "]")
                                End Select
                            Case "flags"
                                Importer.LastDuplicate = sLineParts.Contains("duplicate")
                                Importer.LastSurface = sLineParts.Contains("surface")
                                Importer.LastSplay = sLineParts.Contains("splay")
                            Case "cs"
                                'coordinate system...
                                Dim sCS As String = sLineParts(1).ToLower
                                If sCS = "utm" Then
                                    Importer.LastCoordinateSystem = TherionCoordinateSystem.WGS84UTM
                                    Importer.LastCoordinateZone = Nothing
                                    Importer.LastCoordinateBand = Nothing
                                ElseIf sCS.StartsWith("utm") Then
                                    Dim sZone As String = sCS.Replace("utm", "")
                                    Importer.LastCoordinateSystem = TherionCoordinateSystem.WGS84UTM
                                    Importer.LastCoordinateZone = sZone
                                    If sCS.EndsWith("s") Then
                                        Importer.LastCoordinateBand = "M"
                                    Else
                                        Importer.LastCoordinateBand = "P"
                                    End If
                                Else
                                    Select Case sCS
                                        Case Else
                                            Importer.LastCoordinateSystem = TherionCoordinateSystem.Unknown
                                            Debug.Print("TH:CS->" & sLineParts(1) & " not supported")
                                            Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Warning, "Unsupported coordinate system " & sLineParts(1) & " in " & Filename & "[" & iRow & "]")
                                    End Select
                                End If
                            Case "fix"
                                'station's position
                                Dim sName As String = Importer.CaveNamesStack.Peek
                                Dim sStation As String = sLineParts(1).ToUpper
                                sStation = Options.StationPrefix & sStation & "@" & sName
                                sStation = sStation.ToUpper
                                Select Case Importer.LastCoordinateSystem
                                    Case TherionCoordinateSystem.WGS84UTM
                                        Dim sX As String = sLineParts(2)
                                        Dim sY As String = sLineParts(3)
                                        Dim sAlt As String = sLineParts(4)
                                        Survey.TrigPoints.Rebind()
                                        If Not Survey.TrigPoints.Contains(sStation) Then
                                            Survey.TrigPoints.Add(sStation)
                                        End If
                                        With Survey.TrigPoints(sStation).Coordinate
                                            .System = "WGS84/UTM"
                                            .X = sX
                                            .Y = sY
                                            .Altitude = sAlt
                                            If Importer.LastCoordinateBand IsNot Nothing Then
                                                .Band = Importer.LastCoordinateBand
                                            End If
                                            If Importer.LastCoordinateZone IsNot Nothing Then
                                                .Zone = Importer.LastCoordinateZone
                                            End If
                                        End With
                                        If Not Survey.Properties.GPS.Enabled Then
                                            Survey.Properties.GPS.Enabled = True
                                            Survey.Properties.GPS.SendToTherion = True
                                            Survey.Properties.GPS.RefPointOnOrigin = False
                                            Survey.Properties.GPS.CustomRefPoint = sStation
                                        End If
                                    Case TherionCoordinateSystem.WGS84GEO
                                        Debug.Print("TH:FIX->" & sStation & " in an supported CS but not managed")
                                        Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Warning, "Not managed fix for " & sStation & " in " & Filename & "[" & iRow & "]")
                                    Case TherionCoordinateSystem.Unknown
                                        'CS NOT SUPPORTED
                                        Debug.Print("TH:FIX->" & sStation & " in an unsupported CS")
                                        Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Warning, "Unsupported fix for " & sStation & " in " & Filename & "[" & iRow & "]")
                                End Select
                            Case "station"
                                'TODO
                            Case Else
                                'may be data?
                                If Importer.InCenterline > 0 Then
                                    Dim sData As String() = sLine.Split({" "c, Chr(9)}, StringSplitOptions.RemoveEmptyEntries)
                                    Dim oSegment As cSegment = Survey.Segments.Append()
                                    Dim sName As String = Importer.CaveNamesStack.Peek
                                    Dim oCave As cICaveInfoBranches = Importer.CaveBranchStack.Peek
                                    Dim oSession As cSession = Importer.SessionStack.Peek
                                    Dim oFactor As cFactor = Importer.FactorBySession(oSession)
                                    Dim oData As cData = Importer.DataBySession(oSession)   'TO DO: is there always a data def? I think so...
                                    oSegment.SetSession(oSession)
                                    If TypeOf oCave Is cCaveInfoBranch Then
                                        Dim oRealBrach As cCaveInfoBranch = oCave
                                        Dim oRealCave As cCaveInfo = oRealBrach.GetCave
                                        oSegment.SetCave(oRealCave, oRealBrach)
                                    Else
                                        Dim oRealCave As cCaveInfo = oCave
                                        oSegment.SetCave(oRealCave)
                                    End If
                                    If oData.Type = TherionDataType.Normal Then
                                        Dim sFrom As String = sData(oData.Fields.IndexOf("from"))
                                        Dim sTo As String = sData(oData.Fields.IndexOf("to"))
                                        If (sFrom = "." OrElse sFrom = "-") OrElse (sTo = "." OrElse sTo = "-") Then
                                            'splay shot
                                            If (sFrom = "." OrElse sFrom = "-") Then sFrom = ""
                                            If (sTo = "." OrElse sTo = "-") Then sTo = ""
                                            If sFrom = "" AndAlso sTo = "" Then
                                                'invalid splay...
                                            Else
                                                oSegment.From = Options.StationPrefix & If(sFrom <> "", sFrom & "@" & sName, sTo & "@" & sTo & "(" & Importer.GetSplayCount & ")")
                                                oSegment.To = Options.StationPrefix & If(sTo <> "", sTo & "@" & sName, sFrom & "@" & sName & "(" & Importer.GetSplayCount & ")")
                                                oSegment.Distance = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("length"))) * oFactor.GetFactor("distance")
                                                If oData.Fields.Contains("compass") Then
                                                    oSegment.Bearing = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("compass"))) * oFactor.GetFactor("bearing")
                                                ElseIf oData.Fields.Contains("backcompass") Then
                                                    oSegment.Bearing = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("backcompass"))) * oFactor.GetFactor("bearing")
                                                End If
                                                If oData.Fields.Contains("clino") Then
                                                    oSegment.Inclination = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("clino"))) * oFactor.GetFactor("inclination")
                                                ElseIf oData.Fields.Contains("backclino") Then
                                                    oSegment.Inclination = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("backclino"))) * oFactor.GetFactor("inclination")
                                                End If
                                                oSegment.Splay = True
                                            End If
                                        Else
                                            oSegment.From = Options.StationPrefix & sFrom & "@" & sName
                                            oSegment.To = Options.StationPrefix & sTo & "@" & sName
                                            oSegment.Distance = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("length"))) * oFactor.GetFactor("distance")
                                            If oData.Fields.Contains("compass") Then
                                                oSegment.Bearing = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("compass"))) * oFactor.GetFactor("bearing")
                                            ElseIf oData.Fields.Contains("backcompass") Then
                                                oSegment.Bearing = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("backcompass"))) * oFactor.GetFactor("bearing")
                                            End If
                                            If oData.Fields.Contains("clino") Then
                                                oSegment.Inclination = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("clino"))) * oFactor.GetFactor("inclination")
                                            ElseIf oData.Fields.Contains("backclino") Then
                                                oSegment.Inclination = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("backclino"))) * oFactor.GetFactor("inclination")
                                            End If
                                            Select Case Importer.LastExtend
                                                Case TherionExtend.Right
                                                    oSegment.Direction = cSurvey.cSurvey.DirectionEnum.Right
                                                Case TherionExtend.Left
                                                    oSegment.Direction = cSurvey.cSurvey.DirectionEnum.Left
                                                Case TherionExtend.Vertical
                                                    oSegment.Direction = cSurvey.cSurvey.DirectionEnum.Vertical
                                            End Select
                                            If oData.Fields.Contains("left") Then
                                                oSegment.Left = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("left"))) * oFactor.GetFactor("distance")
                                            End If
                                            If oData.Fields.Contains("right") Then
                                                oSegment.Right = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("right"))) * oFactor.GetFactor("distance")
                                            End If
                                            If oData.Fields.Contains("up") Then
                                                oSegment.Up = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("up"))) * oFactor.GetFactor("distance")
                                            End If
                                            If oData.Fields.Contains("down") Then
                                                oSegment.Down = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("down"))) * oFactor.GetFactor("distance")
                                            End If
                                            oSegment.Duplicate = Importer.LastDuplicate
                                            Importer.LastDuplicate = False
                                            oSegment.Splay = Importer.LastSplay
                                            Importer.LastSplay = False
                                            oSegment.Surface = Importer.LastSurface
                                            Importer.LastSurface = False
                                        End If
                                    ElseIf oData.Type = TherionDataType.Dimensions Then
                                        oSegment.From = Options.StationPrefix & sData(oData.Fields.IndexOf("station")) & "@" & sName
                                        oSegment.To = Options.StationPrefix & oSegment.From
                                        If oData.Fields.Contains("left") Then
                                            oSegment.Left = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("left"))) * oFactor.GetFactor("distance")
                                        End If
                                        If oData.Fields.Contains("right") Then
                                            oSegment.Right = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("right"))) * oFactor.GetFactor("distance")
                                        End If
                                        If oData.Fields.Contains("up") Then
                                            oSegment.Up = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("up"))) * oFactor.GetFactor("distance")
                                        End If
                                        If oData.Fields.Contains("down") Then
                                            oSegment.Down = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("down"))) * oFactor.GetFactor("distance")
                                        End If
                                    End If
                                    Call pSetShotNotes(oSegment, sLineParts)

                                    If Importer.LastComment IsNot Nothing Then
                                        If oSegment.Note <> "" Then oSegment.Note &= vbCrLf
                                        oSegment.Note &= Importer.LastComment
                                        Importer.LastComment = Nothing
                                    End If

                                    Call oSegment.DataProperties.SetValue("import_source", "therion")
                                    Call oSegment.DataProperties.SetValue("import_date", Importer.Now)
                                    Call oSegment.DataProperties.SetValue("import_filename", Filename)
                                    Call oSegment.DataProperties.SetValue("import_row", iRow)

                                    Call oSegment.Save()
                                    Importer.LastSegment = oSegment
                                Else
                                    Debug.Print("TH:" & sFirstTag & ":UNSUPPORTED")
                                    Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Warning, "Unsupported tag " & sFirstTag & " in " & Filename & "[" & iRow & "]")
                                End If
                        End Select
                    End If
                End If
                iRow += 1
            Loop
        End Using
    End Sub

    Private Shared Function pSetShotNotes(Segment As cSegment, LineParts As String())
        If LineParts.Contains("#") Then
            Dim iStart As Integer = LineParts.IndexOf(Function(sLinePart) sLinePart = "#")
            Dim sComment As String = ""
            For iIndex As Integer = iStart + 1 To LineParts.Length - 1
                If sComment <> "" Then sComment &= " "
                sComment &= LineParts(iIndex)
            Next
            sComment = sComment.Trim
            If sComment <> "" Then
                Segment.Note = sComment
            End If
        End If
    End Function

    Public Shared Sub Import(Survey As cSurveyPC.cSurvey.cSurvey, Filename As String, Options As cTherionImportOptions)
        Call Survey.Properties.DataTables.Segments.Add("import_source", Data.cDataFields.TypeEnum.Text)
        Call Survey.Properties.DataTables.Segments.Add("import_date", Data.cDataFields.TypeEnum.Date)
        Call Survey.Properties.DataTables.Segments.Add("import_filename", Data.cDataFields.TypeEnum.Text)
        Call Survey.Properties.DataTables.Segments.Add("import_row", Data.cDataFields.TypeEnum.Integer)

        Call pImport(Survey, New cTherionImporter, Filename, Options)
        'Debug.Print("TH:IMPORT filename: " & Filename)
        'Dim iIsInSurvey As Integer
        'Dim iInCenterline As Integer

        'Dim iLastExtend As TherionExtend = TherionExtend.Right
        'Dim bLastDuplicate As Boolean
        'Dim bLastSurface As Boolean
        'Dim bLastSplay As Boolean
        'Dim iLastCoordinateSystem As TherionCoordinateSystem
        'Dim sLastCoordinateZone As String

        'Dim oDataBySession As Dictionary(Of cSession, cData) = New Dictionary(Of cSession, cData)
        'Dim oFactorBySession As Dictionary(Of cSession, cFactor) = New Dictionary(Of cSession, cFactor)
        'Dim oSessionStack As Stack(Of cSession) = New Stack(Of cSession)
        'Dim oCaveBranchStack As Stack(Of cICaveInfo) = New Stack(Of cICaveInfo)
        'Dim oCaveNamesStack As Stack(Of String) = New Stack(Of String)
        'Using sr As StreamReader = New StreamReader(Filename, True)
        '    Do Until sr.EndOfStream
        '        Dim sLine As String = sr.ReadLine.TrimStart({" "c, Chr(9)}).Trim
        '        If sLine.StartsWith("#") Then
        '            'line of comment...ignored
        '        Else
        '            Dim sLineParts As String() = pTherionLineSplit(sLine)
        '            If sLineParts.Count > 0 Then
        '                If sLineParts(0) = "encoding" Then
        '                    Dim oEncoding = Encoding.GetEncoding(sLineParts(1))
        '                    Debug.Print(oEncoding.BodyName)
        '                End If
        '                Dim sFirstTag As String = sLineParts(0).ToLower
        '                Select Case sFirstTag
        '                    Case "encoding"
        '                    'not at first line????
        '                    Case "survey"
        '                        Dim sName As String = sLineParts(1)
        '                        Call oCaveNamesStack.Push(sName)
        '                        Dim sTitle As String = pTherionGetOption(sLineParts, "title", sName)
        '                        Dim oCave As cICaveInfo = Survey.Properties.CaveInfos.Add(sTitle)
        '                        Call oCaveBranchStack.Push(oCave)
        '                        iIsInSurvey += 1
        '                    Case "endsurvey"
        '                        iIsInSurvey -= 1
        '                    Case "centerline"
        '                        Dim oSession As cSession = Survey.Properties.Sessions.Add(Date.Today, Guid.NewGuid.ToString)
        '                        oSessionStack.Push(oSession)
        '                        Call oFactorBySession.Add(oSession, New cFactor())
        '                        iInCenterline += 1
        '                    Case "endcenterline"
        '                        Dim oSession As cSession = oSessionStack.Pop()
        '                        Call oDataBySession.Remove(oSession)
        '                        iInCenterline -= 1
        '                    Case "date"
        '                        Dim oSession As cSession = oSessionStack.Peek
        '                        Dim oNewDate As Date
        '                        If Not Date.TryParse(sLineParts(1), oNewDate) Then
        '                            oNewDate = New Date(sLineParts(1), 1, 1)
        '                        End If
        '                        Call Survey.Properties.Sessions.Rename(oSession, oNewDate, oSession.Description)
        '                    Case "data"
        '                        Dim oSession As cSession = oSessionStack.Peek
        '                        If sLineParts(1) = "normal" Then
        '                            Dim oData As cData = New cData(TherionDataType.Normal)
        '                            For iData As Integer = 2 To sLineParts.Count - 1
        '                                oData.Fields.Add(sLineParts(iData))
        '                            Next
        '                            'TODO: support back/noback cases
        '                            If oData.Fields.Contains("backcompass") Then
        '                                oSession.BearingDirection = cSegment.MeasureDirectionEnum.Inverted
        '                            End If
        '                            If oData.Fields.Contains("backclino") Then
        '                                oSession.InclinationDirection = cSegment.MeasureDirectionEnum.Inverted
        '                            End If
        '                            If oDataBySession.ContainsKey(oSession) Then oDataBySession.Remove(oSession)
        '                            Call oDataBySession.Add(oSession, oData)
        '                        ElseIf sLineParts(1) = "dimensions" Then
        '                            Dim oData As cData = New cData(TherionDataType.Dimensions)
        '                            For iData As Integer = 2 To sLineParts.Count - 1
        '                                oData.Fields.Add(sLineParts(iData))
        '                            Next
        '                            Call oDataBySession.Add(oSession, oData)
        '                        End If
        '                    Case "team"
        '                        If sLineParts.Count > 0 Then
        '                            Dim oSession As cSession = oSessionStack.Peek
        '                            If oSession.Team <> "" Then oSessionStack.Peek.Team &= ", "
        '                            oSessionStack.Peek.Team &= sLineParts(1)
        '                        End If
        '                    Case "calibrate"
        '                    Case "units"
        '                        'meter[s], centimeter[s], inch[es], feet[s], yard[s] (also m, CM, in, ft, yd). Angle units supported: degree[s], Minute[s] (also deg, min), grad[s],mil[s], percent[age]
        '                        Dim oSession As cSession = oSessionStack.Peek
        '                        'units length left right up down cm
        '                        Dim sUnit As String = sLineParts(sLineParts.Length - 1)
        '                        Dim oUnits As List(Of String) = New List(Of String)
        '                        For iUnit As Integer = 1 To sLineParts.Length - 2
        '                            oUnits.Add(sLineParts(iUnit))
        '                        Next
        '                        'length, tape, bearing, compass, gradient, clino, counter, depth, x, y, z, position, easting, dx, northing,
        '                        If oUnits.Contains("clino") Then
        '                            Select Case sUnit.ToLower
        '                                Case "degree", "degrees", "deg"
        '                                    oSession.InclinationType = cSegment.InclinationTypeEnum.DecimalDegree
        '                                Case "grad", "grads"
        '                                    oSession.InclinationType = cSegment.InclinationTypeEnum.CentesimalDegree
        '                                Case "percentage", "percent"
        '                                    oSession.InclinationType = cSegment.InclinationTypeEnum.Percentage
        '                                Case Else
        '                                    Debug.Print("TH:UNITS: unsupported unit " & sUnit & " for inclination")
        '                            End Select
        '                        End If
        '                        If oUnits.Contains("bearing") Then
        '                            Select Case sUnit.ToLower
        '                                Case "degree", "degrees", "deg"
        '                                    oSession.BearingType = cSegment.BearingTypeEnum.DecimalDegree
        '                                Case "grad", "grads"
        '                                    oSession.BearingType = cSegment.BearingTypeEnum.CentesimalDegree
        '                                Case Else
        '                                    Debug.Print("TH:UNITS: unsupported unit " & sUnit & " for bearing")
        '                            End Select
        '                        End If
        '                        If oUnits.Contains("length") Then
        '                            Select Case sUnit.ToLower
        '                                Case "meter", "meters", "m"
        '                                    oSession.DistanceType = cSegment.DistanceTypeEnum.Meters
        '                                Case "cm", "centimeters"
        '                                    oSession.DistanceType = cSegment.DistanceTypeEnum.Meters
        '                                    oFactorBySession(oSession).SetFactor("distance", 0.01D)
        '                                Case "feet", "feets", "ft"
        '                                    oSession.DistanceType = cSegment.DistanceTypeEnum.Feet
        '                                Case "yard", "yards", "yd"
        '                                    oSession.DistanceType = cSegment.DistanceTypeEnum.Yards
        '                                Case Else
        '                                    Debug.Print("TH:UNITS: unsupported unit " & sUnit & " for distance")
        '                            End Select
        '                        End If
        '                        'If oUnits.Contains("left") Then
        '                        '    Select Case sUnit.ToLower
        '                        '        Case "meter", "meters", "m"
        '                        '            oSession.DistanceTyape = cSegment.DistanceTypeEnum.Meters
        '                        '        Case "cm", "centimeters"
        '                        '            oSession.DistanceType = cSegment.DistanceTypeEnum.Meters
        '                        '            oFactorBySession(oSession).SetFactor("distance", 0.01D)
        '                        '        Case "feet", "feets", "ft"
        '                        '            oSession.DistanceType = cSegment.DistanceTypeEnum.Feet
        '                        '        Case "yard", "yards", "yd"
        '                        '            oSession.DistanceType = cSegment.DistanceTypeEnum.Yards
        '                        '        Case Else
        '                        '            Debug.Print("TH:UNITS: unsupported unit " & sUnit & " for distance")
        '                        '    End Select
        '                        'End If
        '                    Case "input"
        '                        'jump to another file...
        '                        Dim sFilename As String = sLineParts(1)
        '                        sFilename = sFilename.Replace("/", IO.Path.DirectorySeparatorChar)
        '                        sFilename = IO.Path.Combine(IO.Path.GetDirectoryName(Filename), sFilename)
        '                        Call SurveyImportTherionFile(Survey, sFilename)
        '                    Case "equate"
        '                        Dim sName As String = oCaveNamesStack.Peek
        '                        Dim oSegment As cSegment = Survey.Segments.Append()
        '                        Dim sFrom As String = sLineParts(1)
        '                        Dim sTo As String = sLineParts(2)
        '                        If Not sFrom.Contains("@") Then sFrom = sFrom & "@" & sName
        '                        If Not sTo.Contains("@") Then sTo = sTo & "@" & sName
        '                        oSegment.From = sFrom
        '                        oSegment.To = sTo
        '                        oSegment.Save()
        '                    Case "extend"
        '                        Select Case sLineParts(1)
        '                            Case "right"
        '                                iLastExtend = TherionExtend.Right
        '                            Case "left"
        '                                iLastExtend = TherionExtend.Left
        '                            Case "vertical"
        '                                iLastExtend = TherionExtend.Vertical
        '                            Case Else
        '                                Debug.Print("TH:EXTEND->" & sLineParts(1))
        '                        End Select
        '                    Case "flags"
        '                        bLastDuplicate = sLineParts.Contains("duplicate")
        '                        bLastSurface = sLineParts.Contains("surface")
        '                        bLastSplay = sLineParts.Contains("splay")
        '                    Case "cs"
        '                        'coordinate system...
        '                        Select Case sLineParts(1).ToLower
        '                            Case "utm"
        '                                iLastCoordinateSystem = TherionCoordinateSystem.WGS84UTM
        '                                sLastCoordinateZone = Nothing
        '                            Case "utm32"
        '                                iLastCoordinateSystem = TherionCoordinateSystem.WGS84UTM
        '                                sLastCoordinateZone = "32"
        '                            Case Else
        '                                iLastCoordinateSystem = TherionCoordinateSystem.Unknown
        '                                Debug.Print("TH:CS->" & sLineParts(1) & " not supported")
        '                        End Select
        '                    Case "fix"
        '                        'station's position
        '                        Dim sStation As String = sLineParts(1).ToUpper
        '                        Select Case iLastCoordinateSystem
        '                            Case TherionCoordinateSystem.WGS84UTM
        '                                Dim sX As String = sLineParts(2)
        '                                Dim sY As String = sLineParts(3)
        '                                Dim sAlt As String = sLineParts(4)
        '                                Survey.TrigPoints.Rebind()
        '                                With Survey.TrigPoints(sStation).Coordinate
        '                                    .System = "WGS84/UTM"
        '                                    .X = sX
        '                                    .Y = sY
        '                                    .Altitude = sAlt
        '                                    If sLastCoordinateZone IsNot Nothing Then
        '                                        .Zone = sLastCoordinateZone
        '                                        .Band = "A"
        '                                    End If
        '                                End With
        '                            Case TherionCoordinateSystem.WGS84GEO
        '                            Case TherionCoordinateSystem.Unknown
        '                                'CS NOT SUPPORTED
        '                                Debug.Print("TH:FIX->" & sStation & " in an unsupported CS")
        '                        End Select
        '                    Case Else
        '                        'may be data?
        '                        If iInCenterline > 0 Then
        '                            Dim sData As String() = sLine.Split({" "c, Chr(9)}, StringSplitOptions.RemoveEmptyEntries)
        '                            Dim oSegment As cSegment = Survey.Segments.Append()
        '                            Dim sName As String = oCaveNamesStack.Peek
        '                            Dim oCave As cICaveInfo = oCaveBranchStack.Peek
        '                            Dim oSession As cSession = oSessionStack.Peek
        '                            Dim oFactor As cFactor = oFactorBySession(oSession)
        '                            Dim oData As cData = oDataBySession(oSession)   'TO DO: is there always a data def? I think so...
        '                            oSegment.SetSession(oSession)
        '                            If TypeOf oCave Is cCaveInfoBranch Then
        '                                Dim oRealBrach As cCaveInfoBranch = oCave
        '                                Dim oRealCave As cCaveInfo = oRealBrach.GetCave
        '                                oSegment.SetCave(oRealCave, oRealBrach)
        '                            Else
        '                                Dim oRealCave As cCaveInfo = oCave
        '                                oSegment.SetCave(oRealCave)
        '                            End If
        '                            If oData.Type = TherionDataType.Normal Then
        '                                oSegment.From = sData(oData.Fields.IndexOf("from")) & "@" & sName
        '                                oSegment.To = sData(oData.Fields.IndexOf("to")) & "@" & sName
        '                                oSegment.Distance = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("length"))) * oFactor.GetFactor("distance")
        '                                If oData.Fields.Contains("compass") Then
        '                                    oSegment.Bearing = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("compass"))) * oFactor.GetFactor("bearing")
        '                                ElseIf oData.Fields.Contains("backcompass") Then
        '                                    oSegment.Bearing = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("backcompass"))) * oFactor.GetFactor("bearing")
        '                                End If
        '                                If oData.Fields.Contains("clino") Then
        '                                    oSegment.Inclination = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("clino"))) * oFactor.GetFactor("inclination")
        '                                ElseIf oData.Fields.Contains("backclino") Then
        '                                    oSegment.Inclination = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("backclino"))) * oFactor.GetFactor("inclination")
        '                                End If
        '                                Select Case iLastExtend
        '                                    Case TherionExtend.Right
        '                                        oSegment.Direction = cSurvey.cSurvey.DirectionEnum.Right
        '                                    Case TherionExtend.Left
        '                                        oSegment.Direction = cSurvey.cSurvey.DirectionEnum.Left
        '                                    Case TherionExtend.Vertical
        '                                        oSegment.Direction = cSurvey.cSurvey.DirectionEnum.Vertical
        '                                End Select
        '                                If oData.Fields.Contains("left") Then
        '                                    oSegment.Left = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("left"))) * oFactor.GetFactor("distance")
        '                                End If
        '                                If oData.Fields.Contains("right") Then
        '                                    oSegment.Right = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("right"))) * oFactor.GetFactor("distance")
        '                                End If
        '                                If oData.Fields.Contains("up") Then
        '                                    oSegment.Up = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("up"))) * oFactor.GetFactor("distance")
        '                                End If
        '                                If oData.Fields.Contains("down") Then
        '                                    oSegment.Down = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("down"))) * oFactor.GetFactor("distance")
        '                                End If
        '                                oSegment.Duplicate = bLastDuplicate
        '                                bLastDuplicate = False
        '                                oSegment.Splay = bLastSplay
        '                                bLastSplay = False
        '                                oSegment.Surface = bLastSurface
        '                                bLastSurface = False
        '                            ElseIf oData.Type = TherionDataType.Dimensions Then
        '                                oSegment.From = sData(oData.Fields.IndexOf("station")) & "@" & sName
        '                                oSegment.To = oSegment.From
        '                                If oData.Fields.Contains("left") Then
        '                                    oSegment.Left = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("left"))) * oFactor.GetFactor("distance")
        '                                End If
        '                                If oData.Fields.Contains("right") Then
        '                                    oSegment.Right = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("right"))) * oFactor.GetFactor("distance")
        '                                End If
        '                                If oData.Fields.Contains("up") Then
        '                                    oSegment.Up = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("up"))) * oFactor.GetFactor("distance")
        '                                End If
        '                                If oData.Fields.Contains("down") Then
        '                                    oSegment.Down = modNumbers.StringToDecimal(sData(oData.Fields.IndexOf("down"))) * oFactor.GetFactor("distance")
        '                                End If
        '                            End If
        '                            oSegment.Save()
        '                        End If
        '                End Select
        '            End If
        '        End If
        '    Loop
        'End Using
    End Sub

    Private Shared Function pTherionGetOption(LineParts As String(), OptionName As String, DefaultValue As String) As String
        Dim iIndex As Integer = LineParts.IndexOf(Function(sItem) sItem = "-" & OptionName)
        If iIndex >= 0 Then
            Return LineParts(iIndex + 1)
        Else
            Return DefaultValue
        End If
    End Function
End Class
