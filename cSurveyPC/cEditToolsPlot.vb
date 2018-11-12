Imports System.Xml

Namespace cSurvey.Design
    Friend Class cEditToolsPlot
        Private oSurvey As cSurvey

        Private oCurrentSegment As cSegment
        Private oCurrentSegments As cISegmentCollection
        Private oCurrentTrigpoint As cTrigPoint

        Public Class cEditToolsPlotEventArgs
            Private oCurrentSegment As cSegment
            Private oCurrentTrigpoint As cTrigPoint

            Private oPreviousSegment As cSegment
            Private oPreviousTrigpoint As cTrigPoint

            Friend Sub New(ByVal Tool As cEditToolsPlot, PreviousSegment As cSegment, PreviousTrigpoint As cTrigPoint)
                oCurrentSegment = Tool.CurrentSegment
                oCurrentTrigpoint = Tool.CurrentTrigpoint
                oPreviousSegment = PreviousSegment
                oPreviousTrigpoint = PreviousTrigpoint
            End Sub

            Friend Sub New(ByVal CurrentSegment As cSegment, ByVal CurrentTrigpoint As cTrigPoint, PreviousSegment As cSegment, PreviousTrigpoint As cTrigPoint)
                oCurrentSegment = CurrentSegment
                oCurrentTrigpoint = CurrentTrigpoint
                oPreviousSegment = PreviousSegment
                oPreviousTrigpoint = PreviousTrigpoint
            End Sub

            Public ReadOnly Property Currentsegment() As cSegment
                Get
                    Return oCurrentSegment
                End Get
            End Property

            Public ReadOnly Property CurrentTrigpoint() As cTrigPoint
                Get
                    Return oCurrentTrigpoint
                End Get
            End Property

            Public ReadOnly Property PreviousSegment() As cSegment
                Get
                    Return oPreviousSegment
                End Get
            End Property

            Public ReadOnly Property PreviousTrigpoint() As cTrigPoint
                Get
                    Return oPreviousTrigpoint
                End Get
            End Property
        End Class

        Friend Event OnSegmentSelect(ByVal Sender As cEditToolsPlot, ByVal ToolEventArgs As cEditToolsPlotEventArgs)
        Friend Event OnTrigPointSelect(ByVal Sender As cEditToolsPlot, ByVal ToolEventArgs As cEditToolsPlotEventArgs)

        Public Sub SelectTrigpoint(ByVal Trigpoint As cTrigPoint)
            If Not Trigpoint Is oCurrentTrigpoint Then
                Dim oPreviousTrigpoint As cTrigPoint = oCurrentTrigpoint
                oCurrentTrigpoint = Trigpoint
                Dim oArgs As cEditToolsPlotEventArgs = New cEditToolsPlotEventArgs(Me, Nothing, oPreviousTrigpoint)
                RaiseEvent OnTrigPointSelect(Me, oArgs)
            End If
        End Sub

        Public Sub SelectSegment(ByVal Segment As cSegment)
            If Not Segment Is oCurrentSegment Then
                Dim oPreviousSegment As cSegment = oCurrentSegment
                oCurrentSegment = Segment
                Dim oArgs As cEditToolsPlotEventArgs = New cEditToolsPlotEventArgs(Me, oPreviousSegment, Nothing)
                RaiseEvent OnSegmentSelect(Me, oArgs)
            End If
        End Sub

        Public ReadOnly Property CurrentTrigpoint() As cTrigPoint
            Get
                Return oCurrentTrigpoint
            End Get
        End Property

        Public ReadOnly Property CurrentSegment() As cSegment
            Get
                Return oCurrentSegment
            End Get
        End Property

        Friend Overridable Sub Clear()
            oCurrentSegment = Nothing
            oCurrentTrigpoint = Nothing
        End Sub

        Public ReadOnly Property CurrentSegments() As cISegmentCollection
            Get
                Return oCurrentSegments
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oCurrentSegments = oSurvey.Segments
        End Sub

        Public Sub DeleteSegment(Segment As cSegment)
            If Not Segment Is Nothing Then
                Call oSurvey.Undo.Push("Elimina segmento", cUndo.ActionEnum.Delete, Segment)
                Call oSurvey.Segments.Remove(Segment)
                If Segment Is oCurrentSegment Then
                    Call SelectSegment(Nothing)
                End If
            End If
        End Sub

        Public Sub DeleteSegment()
            If Not oCurrentSegment Is Nothing Then
                Call oSurvey.Undo.Push("Elimina segmento", cUndo.ActionEnum.Delete, oCurrentSegment)
                Call oSurvey.Segments.Remove(oCurrentSegment)
            End If
        End Sub

        Friend Function PasteSegments(Optional ByVal Format As String = "", Optional ByVal InsertAt As Integer = -1) As List(Of cSegment)
            Dim oPastedSegments As List(Of cSegment) = New List(Of cSegment)
            If InsertAt = -1 Then
                InsertAt = oSurvey.Segments.Count - 1
            End If
            Try
                If Clipboard.ContainsData("csurvey.segments") Then
                    Dim bCleanPastedStation As Boolean = oSurvey.GetGlobalSetting("clipboard.cleanpastedstation", 0)
                    Dim oXML As XmlDocument = New XmlDocument
                    oXML.LoadXml(Clipboard.GetData("csurvey.segments"))
                    Dim oXMLParent As XmlElement = oXML.Item("parent")
                    Dim bIsSameSurvey As Boolean = oXMLParent.GetAttribute("_id") = oSurvey.ID
                    For Each oXMLItem As XmlElement In oXMLParent
                        Dim oSegment As cSegment = New cSegment(oSurvey, oXMLItem)
                        If Not oSurvey.Segments.Find(oSegment.To, oSegment.From) Is Nothing And bCleanPastedStation Then
                            oSegment.From = ""
                            oSegment.To = ""
                        End If
                        If Not oSurvey.Properties.CaveInfos.Contains(oSegment.Cave) Then
                            Call oSegment.SetCave("", "", False)
                        Else
                            If Not oSurvey.Properties.CaveInfos(oSegment.Cave).Branches.Contains(oSegment.Branch) Then
                                Call oSegment.SetCave(oSegment.Cave, "", False)
                            End If
                        End If
                        If Not bIsSameSurvey Then
                            Call oSegment.SetSession("")
                        End If
                        If InsertAt = -1 Then
                            Call oSurvey.Segments.Append(oSegment)
                        Else
                            Call oSurvey.Segments.Insert(InsertAt, oSegment)
                            InsertAt += 1
                        End If
                        Call oPastedSegments.Add(oSegment)
                    Next
                    'ElseIf Clipboard.ContainsText(TextDataFormat.CommaSeparatedValue) Then
                    '    Dim sText As String = Clipboard.GetText()
                    '    Dim oMS As IO.MemoryStream = New IO.MemoryStream(System.Text.ASCIIEncoding.ASCII.GetBytes(sText))
                    '    Dim oTFP As FileIO.TextFieldParser = New FileIO.TextFieldParser(oMS)
                    '    oTFP.Delimiters = {";"}
                    '    oTFP.HasFieldsEnclosedInQuotes = True
                    '    Do Until oTFP.EndOfData
                    '        Dim sData() As String = oTFP.ReadFields

                    '    Loop
                ElseIf Clipboard.ContainsText Then
                    Dim sLines() As Object = Strings.Split(Clipboard.GetText, vbCrLf)
                    For Each sLine As String In sLines
                        Dim sValues() As String = Strings.Split(sLine, vbTab)

                        Dim sDeformattedValues() As String = sValues.Clone
                        Dim iValueIndex As Integer = 0
                        For Each sValue As String In sValues
                            If sValue.StartsWith("""") Then
                                sValue = sValue.Substring(1)
                            End If
                            If sValue.EndsWith("""") Then
                                sValue = sValue.Substring(0, sValue.Length - 1)
                            End If
                            sDeformattedValues(iValueIndex) = sValue
                            iValueIndex += 1
                        Next

                        Dim oSegment As cSegment = New cSegment(oSurvey)
                        Dim iColumn As Integer = -1
                        iColumn = pFindNextValue(sDeformattedValues, iColumn)
                        If Not iColumn = -1 Then
                            Dim sFrom As String = sDeformattedValues(iColumn)
                            iColumn = pFindNextValue(sDeformattedValues, iColumn)
                            If Not iColumn = -1 Then
                                Dim sTo As String = sDeformattedValues(iColumn)

                                If oSurvey.Segments.Find(sFrom, sTo) Is Nothing Then
                                    oSegment.From = sFrom
                                    oSegment.To = sTo
                                Else
                                    oSegment.From = ""
                                    oSegment.To = ""
                                End If

                                iColumn = pFindNextValue(sDeformattedValues, iColumn)
                                If Not iColumn = -1 Then
                                    Try : oSegment.Distance = modNumbers.StringToDecimal(sDeformattedValues(iColumn)) : Catch : End Try
                                    iColumn = pFindNextValue(sDeformattedValues, iColumn)
                                    If Not iColumn = -1 Then
                                        Try : oSegment.Bearing = modNumbers.StringToDecimal(sDeformattedValues(iColumn)) : Catch : End Try
                                        iColumn = pFindNextValue(sDeformattedValues, iColumn)
                                        If Not iColumn = -1 Then
                                            Try : oSegment.Inclination = modNumbers.StringToDecimal(sDeformattedValues(iColumn)) : Catch : End Try

                                            iColumn = pFindNextValue(sDeformattedValues, iColumn)
                                            If Not iColumn = -1 Then
                                                Try : oSegment.Left = modNumbers.StringToDecimal(sDeformattedValues(iColumn)) : Catch : End Try
                                                iColumn = pFindNextValue(sDeformattedValues, iColumn)
                                                If Not iColumn = -1 Then
                                                    Try : oSegment.Right = modNumbers.StringToDecimal(sDeformattedValues(iColumn)) : Catch : End Try
                                                    iColumn = pFindNextValue(sDeformattedValues, iColumn)
                                                    If Not iColumn = -1 Then
                                                        Try : oSegment.Up = modNumbers.StringToDecimal(sDeformattedValues(iColumn)) : Catch : End Try
                                                        iColumn = pFindNextValue(sDeformattedValues, iColumn)
                                                        If Not iColumn = -1 Then
                                                            Try : oSegment.Down = modNumbers.StringToDecimal(sDeformattedValues(iColumn)) : Catch : End Try
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                                Call oSurvey.Segments.Insert(InsertAt, oSegment)
                            End If
                        End If
                        InsertAt += 1
                        Call oPastedSegments.Add(oSegment)
                    Next
                End If
            Catch
            End Try
            Return oPastedSegments
        End Function

        Private Function pFindNextValue(ByVal Values() As String, ByVal Index As Integer) As Integer
            If Index < Values.Length - 1 Then
                Index += 1
                Do
                    Dim sValue As String = Values(Index)
                    If sValue <> "" Then Return Index
                    Index += 1
                Loop While Index < Values.Length
                Return -1
            Else
                Return -1
            End If
        End Function

        Public Sub CopySegments(ByVal Segments As cSegmentCollection)
            Dim oFile As Storage.cFile = New Storage.cFile(Storage.cFile.FileFormatEnum.CSX)
            Dim oXML As XmlDocument = oFile.Document
            Dim oXMLParent As XmlElement = oXML.CreateElement("parent")
            Call oXMLParent.SetAttribute("_id", oSurvey.ID)
            For Each oSegment As cSegment In Segments
                Call oSegment.SaveTo(oFile, oXML, oXMLParent)
            Next
            Call oXML.AppendChild(oXMLParent)

            Dim oDataObject As DataObject = New DataObject
            Call oDataObject.SetData("csurvey.segments", oXML.InnerXml)

            Dim sExtFormats As String = oSurvey.GetGlobalSetting("clipboard.segments.extformats", "")
            Dim bUseLocalFormat As Boolean = oSurvey.GetGlobalSetting("clipboard.uselocalformat", False)
            If sExtFormats.Contains("csv") Then
                Dim bBuffer() As Byte = System.Text.Encoding.UTF8.GetBytes(Segments.ToCSV(bUseLocalFormat))
                Dim oMS As System.IO.MemoryStream = New System.IO.MemoryStream(bBuffer)
                Call oDataObject.SetData(System.Windows.Forms.DataFormats.CommaSeparatedValue, oMS)
                'Call oDataObject.SetText(Segments.ToCSV(bUseLocalFormat), TextDataFormat.CommaSeparatedValue)
            End If
            If sExtFormats.Contains("txt") Then
                Call oDataObject.SetText(Segments.ToTSV(bUseLocalFormat), TextDataFormat.Text)
            End If
            Call Clipboard.SetDataObject(oDataObject)
        End Sub

        Public Sub CutSegments(ByVal Segments As cSegmentCollection)
            Dim oFile As Storage.cFile = New Storage.cFile
            Dim oXML As XmlDocument = oFile.Document
            Dim oXMLParent As XmlElement = oXML.CreateElement("parent")
            Call oXMLParent.SetAttribute("_id", oSurvey.ID)
            For Each oSegment As cSegment In Segments
                Call oSegment.SaveTo(oFile, oXML, oXMLParent)
            Next
            Call oXML.AppendChild(oXMLParent)

            Dim oDataObject As DataObject = New DataObject
            Call oDataObject.SetData("csurvey.segments", oXML.InnerXml)

            Dim sExtFormats As String = oSurvey.GetGlobalSetting("clipboard.segments.extformats", "")
            Dim bUseLocalFormat As Boolean = oSurvey.GetGlobalSetting("clipboard.uselocalformat", False)
            If sExtFormats.Contains("csv") Then
                Dim bBuffer() As Byte = System.Text.Encoding.UTF8.GetBytes(Segments.ToCSV(bUseLocalFormat))
                Dim oMS As System.IO.MemoryStream = New System.IO.MemoryStream(bBuffer)
                Call oDataObject.SetData(System.Windows.Forms.DataFormats.CommaSeparatedValue, oMS)
                'Call oDataObject.SetText(Segments.ToCSV(bUseLocalformat), TextDataFormat.CommaSeparatedValue)
            End If
            If sExtFormats.Contains("txt") Then
                Call oDataObject.SetText(Segments.ToTSV(bUseLocalFormat), TextDataFormat.Text)
            End If
            Call Clipboard.SetDataObject(oDataObject)
            Call DeleteSegment()
        End Sub
    End Class
End Namespace