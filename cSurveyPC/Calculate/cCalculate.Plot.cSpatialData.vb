Imports cSurveyPC.cSurvey.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate.Plot
    Friend Class cSpatialData
        Implements cISpatialData

        Private sTo As String
        Private sFrom As String

        Private dDistance As Decimal
        Private dInclination As Decimal
        Private dBearing As Decimal

        Private iDirection As cSurvey.DirectionEnum

        Private bReversed As Boolean

        Friend Sub New(ByVal Item As XmlElement)
            sTo = Item.GetAttribute("st")
            sFrom = Item.GetAttribute("sf")
            dDistance = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "d", 0))
            dInclination = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "i", 0))
            dBearing = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "b", 0))
            iDirection = modNumbers.StringToInteger(modXML.GetAttributeValue(Item, "dr", 0))
            bReversed = modXML.GetAttributeValue(Item, "r", "0")
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Name As String) As XmlElement
            Dim oXmlSM As XmlElement = Document.CreateElement(Name)
            Call oXmlSM.SetAttribute("st", sTo)
            Call oXmlSM.SetAttribute("sf", sFrom)
            Call oXmlSM.SetAttribute("d", modNumbers.NumberToString(dDistance, ""))
            Call oXmlSM.SetAttribute("i", modNumbers.NumberToString(dInclination, ""))
            Call oXmlSM.SetAttribute("b", modNumbers.NumberToString(dBearing, ""))
            Call oXmlSM.SetAttribute("dr", iDirection.ToString("D"))
            If bReversed Then Call oXmlSM.SetAttribute("r", "1")
            Call Parent.AppendChild(oXmlSM)
            Return oXmlSM
        End Function

        Friend Sub SetData(Distance As Decimal, Inclination As Decimal, Bearing As Decimal, Direction As cSurvey.DirectionEnum)
            dDistance = Distance
            dInclination = Inclination
            dBearing = Bearing
            iDirection = Direction
        End Sub

        Friend Sub SetData([From] As String, [To] As String, Direction As cSurvey.DirectionEnum, Reversed As Boolean)
            sFrom = [From]
            sTo = [To]
            'dDistance = Data.dDistance
            'dInclination = Data.dInclination
            'dBearing = Data.dBearing
            iDirection = Direction
            bReversed = Reversed
        End Sub

        Friend Sub SetData([From] As String, [To] As String, Distance As Decimal, Inclination As Decimal, Bearing As Decimal, Direction As cSurvey.DirectionEnum, Reversed As Boolean)
            sFrom = [From]
            sTo = [To]
            dDistance = Distance
            dInclination = Inclination
            dBearing = Bearing
            iDirection = Direction
            bReversed = Reversed
        End Sub

        Friend Sub RenameFrom(NewName As String)
            sFrom = NewName
        End Sub

        Friend Sub RenameTo(NewName As String)
            sTo = NewName
        End Sub

        Public ReadOnly Property Bearing As Decimal Implements cISpatialData.Bearing
            Get
                Return dBearing
            End Get
        End Property

        Public ReadOnly Property Direction As DirectionEnum Implements cISpatialData.Direction
            Get
                Return iDirection
            End Get
        End Property

        Public ReadOnly Property Distance As Decimal Implements cISpatialData.Distance
            Get
                Return dDistance
            End Get
        End Property

        Public ReadOnly Property From As String Implements cISpatialData.From
            Get
                Return sFrom
            End Get
        End Property

        Public ReadOnly Property Inclination As Decimal Implements cISpatialData.Inclination
            Get
                Return dInclination
            End Get
        End Property

        Public ReadOnly Property Reversed As Boolean Implements cISpatialData.Reversed
            Get
                Return bReversed
            End Get
        End Property

        Public ReadOnly Property [To] As String Implements cISpatialData.To
            Get
                Return sTo
            End Get
        End Property

        Friend Sub New()
            sFrom = ""
            sTo = ""
        End Sub

        Friend Sub New([From] As String, [To] As String, Distance As Decimal, Inclination As Decimal, Bearing As Decimal, Direction As cSurvey.DirectionEnum, Reversed As Boolean)
            sFrom = [From]
            sTo = [To]
            dDistance = Distance
            dInclination = Inclination
            dBearing = Bearing
            iDirection = Direction
            bReversed = Reversed
        End Sub
    End Class
End Namespace
