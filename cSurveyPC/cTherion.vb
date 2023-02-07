Imports System.IO
Imports System.Text
Imports System.Windows.Controls
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports DevExpress.Data.Async.Helpers
Imports DevExpress.Utils.Extensions
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

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

    Public Shared Sub SurveyImportTherionFile(Survey As cSurveyPC.cSurvey.cSurvey, Filename As String)
        Dim iIsInSurvey As Integer
        Dim iInCenterline As Integer
        Dim oDataStack As Stack(Of List(Of String)) = New Stack(Of List(Of String))
        Dim oSessionStack As Stack(Of cSession) = New Stack(Of cSession)
        Dim oCaveBranchStack As Stack(Of cICaveInfo) = New Stack(Of cICaveInfo)
        Dim oCaveNamesStack As Stack(Of String) = New Stack(Of String)
        Using sr As StreamReader = New StreamReader(Filename, True)
            Do Until sr.EndOfStream
                Dim sLine As String = sr.ReadLine.TrimStart({" "c, Chr(9)}).Trim
                Dim sLineParts As String() = pTherionLineSplit(sLine)
                If sLineParts.Count > 0 Then
                    If sLineParts(0) = "encoding" Then
                        Dim oEncoding = Encoding.GetEncoding(sLineParts(1))
                        Debug.Print(oEncoding.BodyName)
                    End If
                    Dim sFirstTag As String = sLineParts(0).ToLower
                    Select Case sFirstTag
                        Case "survey"
                            Dim sName As String = sLineParts(1)
                            Call oCaveNamesStack.Push(sName)
                            Dim sTitle As String = pTherionGetOption(sLineParts, "title", sName)
                            Dim oCave As cICaveInfo = Survey.Properties.CaveInfos.Add(sTitle)
                            Call oCaveBranchStack.Push(oCave)
                            iIsInSurvey += 1
                        Case "endsurvey"
                            iIsInSurvey -= 1
                        Case "centerline"
                            Dim oSession As cSession = Survey.Properties.Sessions.Add(Date.Today, Guid.NewGuid.ToString)
                            oSessionStack.Push(oSession)
                            iInCenterline += 1
                        Case "endcenterline"
                            oSessionStack.Pop()
                            oDataStack.Pop()
                            iInCenterline -= 1
                        Case "date"
                            Dim oSession As cSession = oSessionStack.Peek
                            Dim oNewDate As Date = sLineParts(1)
                            Call Survey.Properties.Sessions.Rename(oSession, oNewDate, oSession.Description)
                        Case "data"
                            If sLineParts(1) = "normal" Then
                                Dim oFields As List(Of String) = New List(Of String)
                                For iData As Integer = 2 To sLineParts.Count - 1
                                    oFields.Add(sLineParts(iData))
                                Next
                                Call oDataStack.Push(oFields)
                            End If
                        Case "team"
                            If sLineParts.Count > 0 Then
                                Dim oSession As cSession = oSessionStack.Peek
                                If oSession.Team <> "" Then oSessionStack.Peek.Team &= ", "
                                oSessionStack.Peek.Team &= sLineParts(1)
                            End If
                        Case "calibrate"
                        Case "units"
                        Case Else
                            'my be data?
                            If iInCenterline > 0 Then
                                Dim sData As String() = sLine.Split({" "c, Chr(9)}, StringSplitOptions.RemoveEmptyEntries)
                                Dim oSegment As cSegment = Survey.Segments.Append()
                                Dim sName As String = oCaveNamesStack.peek
                                Dim oCave As cICaveInfo = oCaveBranchStack.Peek
                                Dim oSession As cSession = oSessionStack.Peek
                                Dim oFields As List(Of String) = oDataStack.Peek
                                oSegment.SetSession(oSession)
                                If TypeOf oCave Is cCaveInfoBranch Then
                                    Dim oRealBrach As cCaveInfoBranch = oCave
                                    Dim oRealCave As cCaveInfo = oRealBrach.GetCave
                                    oSegment.SetCave(oRealCave, oRealBrach)
                                Else
                                    Dim oRealCave As cCaveInfo = oCave
                                    oSegment.SetCave(oRealCave)
                                End If
                                oSegment.From = sData(oFields.IndexOf("from")) & "@" & sName
                                oSegment.To = sData(oFields.IndexOf("to")) & "@" & sName
                                oSegment.Distance = modNumbers.StringToDecimal(sData(oFields.IndexOf("length")))
                                oSegment.Bearing = modNumbers.StringToDecimal(sData(oFields.IndexOf("compass")))
                                oSegment.Inclination = modNumbers.StringToDecimal(sData(oFields.IndexOf("clino")))
                                oSegment.Save()
                            End If
                    End Select
                End If
            Loop
        End Using
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
