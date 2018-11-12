Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Drawings

Module modMetapost
    Private Function pPointToMetapostString(ByVal X As Single, ByVal Y As Single) As String
        Return "(" & modNumbers.NumberToString(X, "0.000") & "u," & modNumbers.NumberToString(-Y, "0.000") & "u)"
    End Function

    Private Function pPointToMetapostString(ByVal Point As PointF) As String
        Return pPointToMetapostString(Point.X, Point.Y)
    End Function

    Private Function pPathToMetapost(Path As GraphicsPath, IsFilled As Boolean) As List(Of String)
        Dim oPaths As List(Of String) = New List(Of String)
        Dim oPath As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim iLastPaintTypeLine As PathPointType = PathPointType.Start
        Dim iSubPathIndex As Integer = 0
        Dim oFirstPoint As PointF
        For i As Integer = 0 To Path.PointCount - 1
            Dim oPaintPoint As PointF = Path.PathPoints(i)
            Dim iPaintType As PathPointType = Path.PathTypes(i)
            If iPaintType = PathPointType.Start Then
                If i > 0 Then
                    If IsFilled Then
                        Call oPath.Append("--" & pPointToMetapostString(oPaintPoint))
                    Else
                        Call oPaths.Add(oPath.ToString)
                        Call oPath.Clear()
                        Call oPath.Append(pPointToMetapostString(oPaintPoint))
                    End If
                Else
                    Call oPath.Append(pPointToMetapostString(oPaintPoint))
                End If
                iLastPaintTypeLine = iPaintType
                oFirstPoint = oPaintPoint
            Else
                Dim iPaintTypeLine As PathPointType = (iPaintType And PathPointType.PathTypeMask)
                If iPaintTypeLine = PathPointType.Line Then
                    Call oPath.Append("--" & pPointToMetapostString(oPaintPoint))
                Else
                    If iPaintTypeLine <> iLastPaintTypeLine Then
                        iSubPathIndex = 1
                    End If
                    Select Case (iSubPathIndex Mod 3)
                        Case 0
                            Call oPath.Append(".." & pPointToMetapostString(oPaintPoint))
                        Case 1
                            Call oPath.Append("..controls " & pPointToMetapostString(oPaintPoint))
                        Case Else
                            Call oPath.Append(" and " & pPointToMetapostString(oPaintPoint) & vbCrLf)
                    End Select
                End If
                iLastPaintTypeLine = iPaintTypeLine
                iSubPathIndex += 1

                If (iPaintType And PathPointType.CloseSubpath) = PathPointType.CloseSubpath Then
                    If IsFilled Then
                        If oFirstPoint <> oPaintPoint Then
                            Call oPath.Append("--" & pPointToMetapostString(oFirstPoint))
                        End If
                    Else
                        If oFirstPoint = oPaintPoint Then
                            If iPaintTypeLine = PathPointType.Line Then
                                Call oPath.Append("--cycle")
                            Else
                                Call oPath.Append("..cycle")
                            End If
                        End If
                    End If
                End If
            End If
        Next
        If oPath.Length > 0 Then Call oPaths.Add(oPath.ToString)
        Return oPaths
    End Function

    Private sFromReplaceChars() As Char = "0123456789".ToCharArray
    Private sToReplaceChars() As Char = "abcdefghij".ToCharArray

    Private Function pRemoveNumbers(ByVal Text As String) As String
        For i As Integer = 0 To sFromReplaceChars.GetUpperBound(0)
            Text = Text.Replace(sFromReplaceChars(i), sToReplaceChars(i))
        Next
        Return Text
    End Function

    Public Function GetUniqueMetapostName(Survey As cSurveyPC.cSurvey.cSurvey, Cliparts As cClipartsCollection, Clipart As cClipart, Optional Prefix As String = "")
        Return pRemoveNumbers(Prefix & Cliparts.IndexOf(Clipart).ToString).ToLower
    End Function

    Public Sub ClipartToMetapostFile(Survey As cSurveyPC.cSurvey.cSurvey, Clipart As cClipart, Filename As String, Name As String)
        Dim oTS As IO.TextWriter = My.Computer.FileSystem.OpenTextFileWriter(Filename, False, modExport.TextFileEncoder)
        Call oTS.Write(ClipartToMetapost(Survey, Clipart, name))
        Call oTS.Close()
        Call oTS.Dispose()
    End Sub

    Public Function ClipartToMetapost(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Clipart As cClipart, Name As String, Optional Comment As String = "") As String
        Dim oMetapost As System.Text.StringBuilder = New System.Text.StringBuilder
        'Call oMetapost.AppendLine("layout " & Name)
        Call oMetapost.AppendLine("code metapost")
        If Comment <> "" Then Call oMetapost.AppendLine("%" & Comment & ";")
        Call oMetapost.AppendLine("def p_u_" & Name & "(expr P,R,S,A) =")
        Call oMetapost.AppendLine("if known ATTR_scale:")
        Call oMetapost.AppendLine("  uS := scantokens( ATTR_scale );")
        Call oMetapost.AppendLine("fi;")
        Call oMetapost.AppendLine("if known ATTR_rotate:")
        Call oMetapost.AppendLine("  uR := scantokens( ATTR_rotate );")
        Call oMetapost.AppendLine("fi;")
        Call oMetapost.AppendLine("T:=identity scaled uS rotated uR shifted P;")
        Dim oBounds As RectangleF = Clipart.Clipart.GetBounds
        Dim oMatrix As Matrix = New Matrix
        Call oMatrix.Translate(-oBounds.Width / 2, -oBounds.Height / 2)
        For Each oDrawPath As cDrawPath In Clipart.Clipart.TransformPaths(oMatrix)
            Dim oMetapostPath As List(Of String)
            Dim sFill As String = oDrawPath.GetStyle("fill", "none")
            If sFill <> "none" Then
                'riempimento  
                oMetapostPath = pPathToMetapost(oDrawPath.Path, True)
                For Each sMetaPostPath As String In oMetapostPath
                    'solo per le aree chiuse...
                    'If sMetaPostPath.EndsWith("cycle") Then
                    'Dim sLine As String = "thfill " & sMetaPostPath & " withcolor (1.0, 1.0, 1.0);"

                    Dim sLine As String
                        Dim oColor As Color = Color.Transparent
                        Try
                            oColor = ColorTranslator.FromHtml(sFill)
                        Catch
                        End Try
                        If oColor.ToArgb = Color.White.ToArgb Then
                            sLine = "thfill " & sMetaPostPath & "--cycle withcolor (1.0, 1.0, 1.0);"
                        Else
                            sLine = "thfill " & sMetaPostPath & "--cycle withcolor (0, 0, 0);"
                        End If

                        Call pAppendPathLines(oMetapost, pSplitPathLine(sLine, 128))
                    'End If
                Next
            End If
            'contorno
            oMetapostPath = pPathToMetapost(oDrawPath.Path, False)
            For Each sMetaPostPath As String In oMetapostPath
                Dim sLine As String = "thdraw " & sMetaPostPath & ";"
                Call pAppendPathLines(oMetapost, pSplitPathLine(sLine, 128))
            Next
        Next
        Call oMatrix.Dispose()

        Call oMetapost.AppendLine("enddef;")
        Call oMetapost.AppendLine("endcode")
        'Call oMetapost.AppendLine("endlayout")

        Return oMetapost.ToString
    End Function

    Private Sub pAppendPathLines(Builder As System.Text.StringBuilder, Lines As String())
        For Each sLine As String In Lines
            Call Builder.AppendLine(sLine)
        Next
    End Sub

    Private Function pSplitPathLine(Line As String, MaxLen As Integer) As String()
        Dim oLines As List(Of String) = New List(Of String)
        Dim sParts() As String = Line.Split("--")
        Dim sLine As String
        Dim iCount As Integer = 0

        Dim iPos As Integer
        Do
            iPos = Line.IndexOf("--")
            If iPos = -1 Then
                sLine = sLine & Line
                Call oLines.Add(sLine)
                Line = ""
            Else
                sLine = sLine & Line.Substring(0, iPos + 2)
                Line = Line.Substring(iPos + 2)
                iCount += 1
                If iCount > 10 Then
                    Call oLines.Add(sLine)
                    sLine = ""
                    iCount = 0
                End If
            End If
        Loop While Line <> ""
        Return oLines.ToArray
        'Dim oLines As List(Of String) = New List(Of String)
        'Do While Line <> ""
        '    Dim sLinePart As String
        '    If Line.Length > 128 Then
        '        sLinePart = Line.Substring(0, MaxLen)
        '    Else
        '        sLinePart = Line
        '    End If
        '    Call oLines.Add(sLinePart)
        '    If Line.Length > MaxLen Then
        '        Line = Line.Substring(MaxLen)
        '    Else
        '        Line = ""
        '    End If
        'Loop
        'Return oLines.ToArray
    End Function
End Module
