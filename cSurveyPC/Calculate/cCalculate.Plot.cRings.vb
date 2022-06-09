Imports cSurveyPC.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate
    Public Class cRings
        Implements IEnumerable

        Private oSurvey As cSurvey

        Private dAverageErrorPercent As Decimal

        Public ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Private Class cHash
            Private sHash As String

            Private oColor As Color
            Private bSelected As Boolean

            Public ReadOnly Property Hash As String
                Get
                    Return sHash
                End Get
            End Property

            Public ReadOnly Property Color As Color
                Get
                    Return oColor
                End Get
            End Property

            Public ReadOnly Property Selected As Boolean
                Get
                    Return bSelected
                End Get
            End Property

            Public Sub New(Hash As String, Selected As Boolean, Color As Color)
                sHash = Hash
                bSelected = Selected
                oColor = Color
            End Sub
        End Class

        Private oHashes As Dictionary(Of String, cHash)
        Private oItems As List(Of cRing)

        Friend Function GetSegmentColor(Segment As cSegment, DefaultColor As Color) As Color
            Dim oRing As cRing = oItems.FirstOrDefault(Function(ring) ring.Selected AndAlso ring.Contains(Segment.From) AndAlso ring.Contains(Segment.To))
            If oRing Is Nothing Then
                Return DefaultColor
            Else
                If oRing.Color = Color.Transparent Then
                    Return DefaultColor
                Else
                    Return Drawing.Color.FromArgb(DefaultColor.A, oRing.Color)
                End If
            End If
        End Function

        Public Function IsSegmentInSelectedRing(Segment As cSegment) As Boolean
            Return oItems.Any(Function(ring) ring.Selected And ring.Contains(Segment.From) And ring.Contains(Segment.To))
        End Function

        Public Function IsSegmentInRing(Segment As cSegment) As Boolean
            Return oItems.Any(Function(ring) ring.Contains(Segment.From) And ring.Contains(Segment.To))
        End Function

        Friend Sub New(Survey As cSurvey, ByVal Item As XmlElement)
            oSurvey = Survey
            oItems = New List(Of cRing)
            oHashes = New Dictionary(Of String, cHash)(StringComparer.CurrentCultureIgnoreCase)
            dAverageErrorPercent = modNumbers.StringToDecimal(Item.GetAttribute("aep"))
            For Each oXMLItem As XmlElement In Item.ChildNodes
                Dim oItem As cRing = New cRing(oSurvey, oXMLItem)
                Call oItems.Add(oItem)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlRings As XmlElement = Document.CreateElement("rngs")
            Call oXmlRings.SetAttribute("aep", modNumbers.NumberToString(dAverageErrorPercent, ""))
            For Each oItem As cRing In oItems
                Call oItem.SaveTo(File, Document, oXmlRings)
            Next
            Call Parent.AppendChild(oXmlRings)
            Return oXmlRings
        End Function

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal Index As Integer) As cRing
            Get
                Return oItems(Index)
            End Get
        End Property

        Public Function Contains(ByVal Ring As cRing) As Boolean
            Return oItems.Contains(Ring)
        End Function

        Friend Function Append(ByVal TherionLog As String, Optional ByVal Dictionary As IDictionary(Of String, String) = Nothing) As cRing
            Dim oRing As cRing = New cRing(oSurvey, TherionLog, Dictionary)
            Call oItems.Add(oRing)
            Dim sHash As String = pGetRingHash(oRing)
            If oHashes.ContainsKey(sHash) Then
                With oHashes(sHash)
                    oRing.Selected = .selected
                    oRing.Color = .color
                End With
            End If
            Return oRing
        End Function

        Friend Function Append(ByVal Stations As String, ByVal Separator As String) As cRing
            Dim oRing As cRing = New cRing(oSurvey, Stations, Separator)
            Call oItems.Add(oRing)
            Dim sHash As String = pGetRingHash(oRing)
            If oHashes.ContainsKey(sHash) Then
                With oHashes(sHash)
                    oRing.Selected = .Selected
                    oRing.Color = .Color
                End With
            End If
            Return oRing
        End Function

        Friend Function Append(ByVal ErrorPercent As Decimal, ByVal [Error] As Double, ByVal X As Decimal, ByVal Y As Decimal, ByVal Z As Decimal, ByVal Length As Decimal, ByVal Stations As String, ByVal Separator As String) As cRing
            Dim oRing As cRing = New cRing(oSurvey, ErrorPercent, [Error], X, Y, Z, Length, Stations, Separator)
            Call oItems.Add(oRing)
            Dim sHash As String = pGetRingHash(oRing)
            If oHashes.ContainsKey(sHash) Then
                With oHashes(sHash)
                    oRing.Selected = .Selected
                    oRing.Color = .Color
                End With
            End If
            Return oRing
        End Function

        Friend Sub Clear(Optional KeepHashes As Boolean = True)
            Call oHashes.Clear()
            For Each oRing As cRing In oItems.Where(Function(ring) ring.Selected)
                Dim oHash As cHash = New cHash(pGetRingHash(oRing), oRing.Selected, oRing.Color)
                If Not oHashes.ContainsKey(oHash.Hash) Then
                    Call oHashes.Add(oHash.Hash, oHash)
                End If
            Next
            Call oItems.Clear()
        End Sub

        Private Function pGetRingHash(Ring As cRing) As String
            Return String.Join("|", Ring.GetStations)
        End Function

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oItems = New List(Of cRing)
            oHashes = New Dictionary(Of String, cHash)(StringComparer.CurrentCultureIgnoreCase)
        End Sub

        Friend Sub SetAverageErrorPercent(AverageErrorPercent As Decimal)
            dAverageErrorPercent = AverageErrorPercent
        End Sub

        Public Function LinearAverageErrorPercent() As Decimal
            Dim dValue As Decimal = 0
            Dim dLength As Decimal = 0
            If oItems.Count > 0 Then
                For Each oRing As cRing In oItems
                    dValue = dValue + oRing.ErrorPercent
                    dLength += 1
                Next
                Return modNumbers.MathRound(dValue / dLength, 2)
            Else
                Return 0
            End If
        End Function

        Public Function AverageErrorPercent() As Decimal
            Return dAverageErrorPercent
        End Function

        Public Function LengthAverageErrorPercent() As Decimal
            Dim dValue As Decimal = 0
            Dim dLength As Decimal = 0
            If oItems.Count > 0 Then
                For Each oRing As cRing In oItems
                    dValue += oRing.Length * oRing.ErrorPercent / 100
                    dLength += oRing.Length
                Next
                Return modNumbers.MathRound(100 * dValue / dLength, 2)
            Else
                Return 0
            End If
        End Function

        'Public Function AverageError() As Decimal
        '    Dim dValue As Decimal = 0
        '    If oItems.Count > 0 Then
        '        For Each oRing As cRing In oItems
        '            dValue += oRing.Error
        '        Next
        '        Return modNumbers.MathRound(dValue / oItems.Count, 3)
        '    Else
        '        Return 0
        '    End If
        'End Function
    End Class
End Namespace