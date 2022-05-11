Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports System.IO
Imports System.Xml

Namespace cSurvey.Calculate
    Friend Class cTrigPointUpDownSideMeasure
        Private sConnection As String
        Private dUp As Decimal
        Private dDown As Decimal

        Public ReadOnly Property Connection As String
            Get
                Return sConnection
            End Get
        End Property

        Friend Sub New(ByVal Item As XmlElement)
            sConnection = Item.GetAttribute("c")
            dUp = modNumbers.StringToDecimal(Item.GetAttribute("u"))
            dDown = modNumbers.StringToDecimal(Item.GetAttribute("d"))
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlTrigPointUpDownSideMeasure As XmlElement = Document.CreateElement("smud")
            Call oXmlTrigPointUpDownSideMeasure.SetAttribute("c", sConnection)
            Call oXmlTrigPointUpDownSideMeasure.SetAttribute("u", modNumbers.NumberToString(dUp, ""))
            Call oXmlTrigPointUpDownSideMeasure.SetAttribute("d", modNumbers.NumberToString(dDown, ""))
            Call Parent.AppendChild(oXmlTrigPointUpDownSideMeasure)
            Return oXmlTrigPointUpDownSideMeasure
        End Function

        Public ReadOnly Property Up As Decimal
            Get
                Return dUp
            End Get
        End Property

        Public ReadOnly Property Down As Decimal
            Get
                Return dDown
            End Get
        End Property

        Public Function GetSize() As SizeD
            Return New SizeD(dUp, dDown)
        End Function

        Friend Sub New(Connection As String, ByVal Up As Decimal, ByVal Down As Decimal)
            sConnection = Connection
            dUp = Up
            dDown = Down
        End Sub
    End Class
End Namespace