Imports cSurveyPC.cSurvey.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate.Plot
    Public Class cStationData
        Private bIsOrphan As Boolean 'in a perfect world this should be nullable....
        Private bIsSplay As Boolean
        Private bIsCalibration As Boolean

        Private sX As Decimal
        Private sY As Decimal
        Private sZ As Decimal

        Friend Sub New()
        End Sub

        Friend Sub New(X As Decimal, Y As Decimal, Z As Decimal, IsOrphan As Boolean, IsSplay As Boolean, IsCalibration As Boolean)
            sX = X
            sY = Y
            sZ = Z
            bIsOrphan = IsOrphan
            bIsSplay = IsSplay
            'biscalibration = IsCalibration
        End Sub

        Friend Sub New(Item As cStationData)
            sX = Item.sX
            sY = Item.sY
            sZ = Item.sZ
            bIsOrphan = Item.bIsOrphan
            bIsSplay = Item.bIsSplay
            bIsCalibration = Item.bIsCalibration
        End Sub

        Friend Sub New(ByVal Item As XmlElement)
            sX = modNumbers.StringToDecimal(Item.GetAttribute("x"))
            sY = modNumbers.StringToDecimal(Item.GetAttribute("y"))
            sZ = modNumbers.StringToDecimal(Item.GetAttribute("z"))
            bIsOrphan = modNumbers.StringToInteger(modXML.GetAttributeValue(Item, "orph", 0))
            bIsSplay = modNumbers.StringToInteger(modXML.GetAttributeValue(Item, "sply", 0))
            bIsCalibration = modNumbers.StringToInteger(modXML.GetAttributeValue(Item, "cal", 0))
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlSD As XmlElement = Document.CreateElement("data")
            Call oXmlSD.SetAttribute("x", modNumbers.NumberToString(sX, ""))
            Call oXmlSD.SetAttribute("y", modNumbers.NumberToString(sY, ""))
            Call oXmlSD.SetAttribute("z", modNumbers.NumberToString(sZ, ""))
            If bIsOrphan Then oXmlSD.SetAttribute("orph", "1")
            If bIsSplay Then oXmlSD.SetAttribute("sply", "1")
            If bIsCalibration Then oXmlSD.SetAttribute("cal", "1")
            Call Parent.AppendChild(oXmlSD)
            Return oXmlSD
        End Function

        Friend Sub MoveTo(ByVal X As Decimal, ByVal Y As Decimal, ByVal Z As Decimal)
            sX = X
            sY = Y
            sZ = Z
        End Sub

        Friend Sub MoveBy(ByVal X As Decimal, ByVal Y As Decimal, ByVal Z As Decimal)
            sX += X
            sY += Y
            sZ += Z
        End Sub

        Public ReadOnly Property X As Decimal
            Get
                Return sX
            End Get
        End Property

        Public ReadOnly Property Y As Decimal
            Get
                Return sY
            End Get
        End Property

        Public ReadOnly Property Z As Decimal
            Get
                Return sZ
            End Get
        End Property

        Public ReadOnly Property IsOrphan As Boolean
            Get
                Return bIsOrphan
            End Get
        End Property

        Public ReadOnly Property IsSplay As Boolean
            Get
                Return bIsSplay
            End Get
        End Property

        Public ReadOnly Property IsCalibration As Boolean
            Get
                Return bIsCalibration
            End Get
        End Property

        Friend Sub SetSplay(Value As Boolean)
            bIsSplay = Value
        End Sub

        Friend Sub SetCalibration(Value As Boolean)
            bIsCalibration = Value
        End Sub

        Friend Sub SetOrphan(Value As Boolean)
            bIsOrphan = Value
            If bIsOrphan Then
                sX = 0
                sY = 0
                sZ = 0
            End If
        End Sub
    End Class
End Namespace