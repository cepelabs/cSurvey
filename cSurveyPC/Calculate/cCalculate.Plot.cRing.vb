Imports cSurveyPC.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate
    Public Class cRing
        Implements IEnumerable

        Private oSurvey As cSurvey

        Private oItems As List(Of String)
        'oRow(0) = oData.Value.Substring(0, 7).Trim   'errore %
        'oRow(1) = oData.Value.Substring(7, 8).Trim   'errore ass
        'oRow(2) = oData.Value.Substring(27, 8).Trim  'x
        'oRow(3) = oData.Value.Substring(35, 8).Trim  'y
        'oRow(4) = oData.Value.Substring(43, 8).Trim  'z
        'oRow(5) = oData.Value.Substring(15, 8).Trim  'lung anello
        'oRow(6) = oData.Value.Substring(23, 4).Trim  'n°stazioni

        Private dErrorPercent As Decimal
        Private dError As Decimal
        Private dX As Decimal
        Private dY As Decimal
        Private dZ As Decimal
        Private dLength As Decimal

        Private bSelected As Boolean
        Private oColor As Color

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlSM As XmlElement = Document.CreateElement("rng")
            Call oXmlSM.SetAttribute("ep", modNumbers.NumberToString(dErrorPercent, ""))
            Call oXmlSM.SetAttribute("e", modNumbers.NumberToString(dError, ""))
            Call oXmlSM.SetAttribute("x", modNumbers.NumberToString(dX, ""))
            Call oXmlSM.SetAttribute("y", modNumbers.NumberToString(dY, ""))
            Call oXmlSM.SetAttribute("z", modNumbers.NumberToString(dZ, ""))
            Call oXmlSM.SetAttribute("l", modNumbers.NumberToString(dLength, ""))
            For Each sItem As String In oItems
                Dim oXmlSMData As XmlElement = Document.CreateElement("t")
                oXmlSMData.InnerText = sItem
                Call oXmlSM.AppendChild(oXmlSMData)
            Next
            If bSelected Then Call oXmlSM.SetAttribute("sel", "1")
            If oColor <> Drawing.Color.Transparent Then oXmlSM.SetAttribute("color", Color.ToArgb)
            Call Parent.AppendChild(oXmlSM)
            Return oXmlSM
        End Function

        Friend Sub New(Survey As cSurvey, ByVal Item As XmlElement)
            oSurvey = Survey
            oItems = New List(Of String)

            dErrorPercent = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "ep", 0))
            dError = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "e", 0))
            dX = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "x", 0))
            dY = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "y", 0))
            dZ = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "z", 0))
            dLength = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "l", 0))

            For Each oXMLItem As XmlElement In Item.ChildNodes
                Call oItems.Add(oXMLItem.InnerText)
            Next

            bSelected = modXML.GetAttributeValue(Item, "sel", 0)
            oColor = modXML.GetAttributeColor(Item, "color", Drawing.Color.Transparent)
        End Sub

        Public Property Selected As Boolean
            Get
                Return bSelected
            End Get
            Set(value As Boolean)
                bSelected = value
            End Set
        End Property

        Public Property Color As Color
            Get
                Return oColor
            End Get
            Set(value As Color)
                oColor = value
            End Set
        End Property

        Public ReadOnly Property ErrorPercent As Decimal
            Get
                Return dErrorPercent
            End Get
        End Property

        Public ReadOnly Property [Error] As Decimal
            Get
                Return dError
            End Get
        End Property

        Public ReadOnly Property X As Decimal
            Get
                Return dX
            End Get
        End Property

        Public ReadOnly Property Y As Decimal
            Get
                Return dY
            End Get
        End Property

        Public ReadOnly Property Z As Decimal
            Get
                Return dZ
            End Get
        End Property

        Public ReadOnly Property Length As Decimal
            Get
                Return dLength
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oItems = New List(Of String)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal TherionLog As String, Optional ByVal Dictionary As IDictionary(Of String, String) = Nothing)
            oSurvey = Survey
            oItems = New List(Of String)
            dErrorPercent = modNumbers.StringToDecimal(TherionLog.Substring(0, 7).Trim.Replace("%", ""))   'errore %
            dError = modNumbers.StringToDecimal(TherionLog.Substring(7, 8).Trim.Replace("m", ""))   'errore ass
            dX = modNumbers.StringToDecimal(TherionLog.Substring(27, 8).Trim.Replace("m", ""))  'x
            dY = modNumbers.StringToDecimal(TherionLog.Substring(35, 8).Trim.Replace("m", ""))  'y
            dZ = modNumbers.StringToDecimal(TherionLog.Substring(43, 8).Trim.Replace("m", ""))  'z
            dLength = modNumbers.StringToDecimal(TherionLog.Substring(15, 8).Trim.Replace("m", ""))  'lung anello
            Dim sStations As String = TherionLog.Substring(51).Trim ' TherionLog.Substring(23, 4).Trim  'n°stazioni
            If sStations.StartsWith("[") Then sStations = sStations.Substring(1)
            If sStations.EndsWith("]") Then sStations = sStations.Substring(0, sStations.Length - 1)
            Dim bFirst As Boolean = True
            For Each sTrigPoint As String In Strings.Split(sStations, " - ")
                If bFirst Then
                    bFirst = False
                Else
                    sTrigPoint = sTrigPoint.Trim.ToUpper
                    If sTrigPoint.Contains(" = ") Then
                        sTrigPoint = sTrigPoint.Substring(0, sTrigPoint.IndexOf(" = "))
                    End If
                    If sTrigPoint.Contains("@") Then
                        sTrigPoint = sTrigPoint.Substring(0, sTrigPoint.IndexOf("@"))
                    End If
                    If Not Dictionary Is Nothing Then
                        If Dictionary.ContainsKey(sTrigPoint) Then
                            sTrigPoint = Dictionary(sTrigPoint)
                        End If
                    End If
                    If Not oItems.Contains(sTrigPoint) Then Call oItems.Add(sTrigPoint)
                End If
            Next
            'Call pSortStations()
            oColor = Drawing.Color.Transparent
            bSelected = False
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Stations As String, ByVal Separator As String)
            oSurvey = Survey
            oItems = New List(Of String)
            For Each sTrigPoint As String In Stations.ToUpper.Split(Separator)
                If Not oItems.Contains(sTrigPoint) Then Call oItems.Add(sTrigPoint)
            Next
            'Call pSortStations()
            oColor = Drawing.Color.Transparent
            bSelected = False
        End Sub

        'Private Sub pSortStations()
        '    If oItems.Count > 1 Then
        '        Dim oList As List(Of String) = New List(Of String)(oItems)
        '        Call oItems.Clear()
        '        Call oItems.AddRange(oList.OrderBy(Function(item) item).ToArray)
        '    End If
        'End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal ErrorPercent As Decimal, ByVal [Error] As Double, ByVal X As Decimal, ByVal Y As Decimal, ByVal Z As Decimal, ByVal Length As Decimal, ByVal Stations As String, ByVal Separator As String)
            oSurvey = Survey
            oItems = New List(Of String)
            dErrorPercent = ErrorPercent
            dError = [Error]
            dX = X
            dY = Y
            dZ = Z
            dLength = Length
            For Each sTrigPoint As String In Stations.ToUpper.Split(Separator)
                If Not oItems.Contains(sTrigPoint) Then Call oItems.Add(sTrigPoint)
            Next
            'Call pSortStations()
            oColor = Drawing.Color.Transparent
            bSelected = False
        End Sub

        Public Function GetStations() As String()
            Return oItems.OrderBy(Function(item) item).ToArray
        End Function

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Function Contains(ByVal TrigPoint As String) As Boolean
            Return oItems.Contains(TrigPoint)
        End Function

        Default Public ReadOnly Property Item(ByVal Index As Integer) As String
            Get
                Return oItems(Index)
            End Get
        End Property

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace
