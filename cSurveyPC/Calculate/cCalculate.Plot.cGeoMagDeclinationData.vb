Imports System.Xml

Namespace cSurvey.Calculate
    Public Class cGeoMagDeclinationData
        Implements IEnumerable

        Private oSurvey As cSurvey

        Private dMeridianConvergence As Decimal
        Private dMeridianConvergenceRadians As Decimal

        Private oItems As SortedDictionary(Of Date, Decimal)

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlMDD As XmlElement = Document.CreateElement("mdd")
            Call oXmlMDD.SetAttribute("mc", modNumbers.NumberToString(dMeridianConvergence, ""))
            For Each dDate As Date In oItems.Keys
                Dim oXmlMDDData As XmlElement = Document.CreateElement("data")
                Call oXmlMDDData.SetAttribute("d", dDate.ToString("O"))
                oXmlMDDData.InnerText = modNumbers.NumberToString(oItems(dDate), "")
                Call oXmlMDD.AppendChild(oXmlMDDData)
            Next
            Call Parent.AppendChild(oXmlMDD)
            Return oXmlMDD
        End Function

        Friend Sub New(Survey As cSurvey, ByVal Item As XmlElement)
            oSurvey = Survey
            oItems = New SortedDictionary(Of Date, Decimal)
            dMeridianConvergence = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "mc", 0))
            dMeridianConvergenceRadians = modPaint.DegreeToRadians(dMeridianConvergence)
            For Each oXMLItem As XmlElement In Item.ChildNodes
                Dim dDate As Date = modXML.GetAttributeValue(oXMLItem, "d")    '<---------AAAAAAAAAAAAAAAAAAAAHHHHHHHHHHH ERRORE?
                Call oItems.Add(dDate, modNumbers.StringToDecimal(oXMLItem.InnerText))
            Next
        End Sub

        Friend Sub Clear()
            dMeridianConvergence = 0
            Call oItems.Clear()
        End Sub

        Public ReadOnly Property MeridianConvergence As Decimal
            Get
                Return dMeridianConvergence
            End Get
        End Property

        Friend ReadOnly Property MeridianConvergenceRadians As Decimal
            Get
                'serve per il calcoli...
                Return dMeridianConvergenceRadians
            End Get
        End Property

        Public Function GetDates() As List(Of Date)
            Dim oDates As List(Of Date) = New List(Of Date)
            For Each dDate As Date In oItems.Keys
                Call oDates.Add(dDate)
            Next
            Call oDates.Sort()
            Return oDates
        End Function

        Default Public ReadOnly Property Item([Date] As Date) As Decimal
            Get
                If oItems.ContainsKey([Date]) Then
                    Return oItems([Date])
                Else
                    Return Decimal.MinValue
                End If
            End Get
        End Property

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Function GetValue([Date] As Date) As Decimal
            Dim dLastdate As Date = Date.MinValue
            For Each dDate In oItems.Keys
                If dDate > [Date] Then
                    Return oItems(dLastdate)
                End If
                dLastdate = dDate
            Next
            Return Decimal.MinValue
        End Function

        Private Function pTherionDateToDate(Text As String) As Date
            Dim sDatePart() As String = Text.Split(".")
            Return New Date(sDatePart(0), sDatePart(1), sDatePart(2))
        End Function

        Friend Sub Append(ByVal TherionLog As String)
            Dim sLineData() As String = TherionLog.Trim.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            Dim dDeclinationDate As Date = pTherionDateToDate(sLineData(0))
            Dim dDeclinationValue As Decimal = modNumbers.StringToDecimal(sLineData(1))
            Call Append(dDeclinationDate, dDeclinationValue)
        End Sub

        Friend Sub SetMeridianConvergence(MeridianConvergence As Decimal)
            dMeridianConvergence = MeridianConvergence
            dMeridianConvergenceRadians = modPaint.DegreeToRadians(dMeridianConvergence)
        End Sub

        Friend Sub Append(ByVal [Date] As Date, ByVal Value As Decimal)
            If Not oItems.ContainsKey([Date]) Then
                Call oItems.Add([Date], Value)
            End If
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oItems = New SortedDictionary(Of Date, Decimal)
        End Sub
    End Class
End Namespace
