Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports System.IO
Imports System.Xml

Namespace cSurvey.Calculate
    Friend Class cTrigPointLeftRightSideMeasure
        Private sConnection As String
        Private dLeft As Decimal
        Private dRight As Decimal
        Private iSideMeasureType As cSegment.SideMeasuresTypeEnum

        Public ReadOnly Property Connection As String
            Get
                Return sConnection
            End Get
        End Property

        Friend Sub New(ByVal Item As XmlElement)
            sConnection = Item.GetAttribute("c")
            dLeft = modNumbers.StringToDecimal(Item.GetAttribute("l"))
            dRight = modNumbers.StringToDecimal(Item.GetAttribute("r"))
            iSideMeasureType = modXML.GetAttributeValue(Item, "smt", cSegment.SideMeasuresTypeEnum.PerpendicularToPrevious)
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlTrigPointLeftRightSideMeasure As XmlElement = Document.CreateElement("smlr")
            Call oXmlTrigPointLeftRightSideMeasure.SetAttribute("c", sConnection)
            Call oXmlTrigPointLeftRightSideMeasure.SetAttribute("l", modNumbers.NumberToString(dLeft, ""))
            Call oXmlTrigPointLeftRightSideMeasure.SetAttribute("r", modNumbers.NumberToString(dRight, ""))
            If iSideMeasureType <> cSegment.SideMeasuresTypeEnum.PerpendicularToPrevious Then Call oXmlTrigPointLeftRightSideMeasure.SetAttribute("smt", iSideMeasureType.ToString("D"))
            Call Parent.AppendChild(oXmlTrigPointLeftRightSideMeasure)
            Return oXmlTrigPointLeftRightSideMeasure
        End Function

        Public ReadOnly Property Left As Decimal
            Get
                Return dLeft
            End Get
        End Property

        Public ReadOnly Property Right As Decimal
            Get
                Return dRight
            End Get
        End Property

        Public Function GetSize() As SizeD
            Return New SizeD(dLeft, dRight)
        End Function

        Public ReadOnly Property SideMeasureType As cSegment.SideMeasuresTypeEnum
            Get
                Return iSideMeasureType
            End Get
        End Property

        Friend Sub New(Connection As String, ByVal Left As Decimal, ByVal Right As Decimal, ByVal SideMeasureType As cSegment.SideMeasuresTypeEnum)
            sConnection = Connection
            dLeft = Left
            dRight = Right
            iSideMeasureType = SideMeasureType
        End Sub
    End Class
End Namespace