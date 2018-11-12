Imports cSurveyPC.cSurvey.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate.Plot
    Public Class cProfileSubData
        'gestisce i capisaldi dell'oversampling della battuta di poligonale 'parent'
        'i dati LRUD SONO SEMPRE PERPENDICOLARI ALLA BATTUTA!!!!!!!!!!!
        Implements cISpatialData
        Implements cIProfileProjectedData

        Private oParent As cSubData

        Private oFromPoint As PointF
        Private oToPoint As PointF

        Private oFromSidePointUp As PointD
        Private oFromSidePointDown As PointD
        Private oToSidePointUp As PointD
        Private oToSidePointDown As PointD
        Private dFromUp As Decimal
        Private dFromDown As Decimal
        Private dToUp As Decimal
        Private dToDown As Decimal

        Friend Sub New(Parent As cSubData, ByVal Item As XmlElement)
            oParent = Parent

            oFromPoint = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fpx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fpy", 0)))
            oToPoint = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tpx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tpy", 0)))

            oFromSidePointUp = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fspux", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fspuy", 0)))
            oFromSidePointDown = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fspdx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fspdy", 0)))
            oToSidePointUp = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tspux", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tspuy", 0)))
            oToSidePointDown = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tspdx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tspdy", 0)))

            dFromUp = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fu", 0))
            dFromDown = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fd", 0))
            dToUp = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tu", 0))
            dToDown = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "td", 0))
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlPlanSD As XmlElement = Document.CreateElement("profilesd")

            Call oXmlPlanSD.SetAttribute("fpx", modNumbers.NumberToString(oFromPoint.X, ""))
            Call oXmlPlanSD.SetAttribute("fpy", modNumbers.NumberToString(oFromPoint.Y, ""))
            Call oXmlPlanSD.SetAttribute("tpx", modNumbers.NumberToString(oToPoint.X, ""))
            Call oXmlPlanSD.SetAttribute("tpy", modNumbers.NumberToString(oToPoint.Y, ""))

            Call oXmlPlanSD.SetAttribute("fspux", modNumbers.NumberToString(oFromSidePointUp.X, ""))
            Call oXmlPlanSD.SetAttribute("fspuy", modNumbers.NumberToString(oFromSidePointUp.Y, ""))
            Call oXmlPlanSD.SetAttribute("fspdx", modNumbers.NumberToString(oFromSidePointDown.X, ""))
            Call oXmlPlanSD.SetAttribute("fspdy", modNumbers.NumberToString(oFromSidePointDown.Y, ""))
            Call oXmlPlanSD.SetAttribute("tspux", modNumbers.NumberToString(oToSidePointUp.X, ""))
            Call oXmlPlanSD.SetAttribute("tspuy", modNumbers.NumberToString(oToSidePointUp.Y, ""))
            Call oXmlPlanSD.SetAttribute("tspdx", modNumbers.NumberToString(oToSidePointDown.X, ""))
            Call oXmlPlanSD.SetAttribute("tspdy", modNumbers.NumberToString(oToSidePointDown.Y, ""))

            Call oXmlPlanSD.SetAttribute("fu", modNumbers.NumberToString(dFromUp, ""))
            Call oXmlPlanSD.SetAttribute("fd", modNumbers.NumberToString(dFromDown, ""))
            Call oXmlPlanSD.SetAttribute("tu", modNumbers.NumberToString(dToUp, ""))
            Call oXmlPlanSD.SetAttribute("td", modNumbers.NumberToString(dToDown, ""))

            Call Parent.AppendChild(oXmlPlanSD)
            Return oXmlPlanSD
        End Function

        Public ReadOnly Property ToUp As Decimal
            Get
                Return dToUp
            End Get
        End Property

        Public ReadOnly Property ToDown As Decimal
            Get
                Return dToDown
            End Get
        End Property

        Public ReadOnly Property FromUp As Decimal
            Get
                Return dFromUp
            End Get
        End Property

        Public ReadOnly Property FromDown As Decimal
            Get
                Return dFromDown
            End Get
        End Property

        Public Function GetCenterPoint() As PointD Implements cIProfileProjectedData.GetCenterPoint
            Return New PointD(oFromPoint.X - (oFromPoint.X - oToPoint.X) / 2, oFromPoint.Y - (oFromPoint.Y - oToPoint.Y) / 2)
        End Function

        Public ReadOnly Property FromSidePointDown() As PointD Implements cIProfileProjectedData.FromSidePointDown
            Get
                Return oFromSidePointDown
            End Get
        End Property

        Public ReadOnly Property FromSidePointUp() As PointD Implements cIProfileProjectedData.FromSidePointUp
            Get
                Return oFromSidePointUp
            End Get
        End Property

        Public ReadOnly Property ToSidePointDown() As PointD Implements cIProfileProjectedData.ToSidePointDown
            Get
                Return oToSidePointDown
            End Get
        End Property

        Public ReadOnly Property ToSidePointUp() As PointD Implements cIProfileProjectedData.ToSidePointUp
            Get
                Return oToSidePointUp
            End Get
        End Property

        Public ReadOnly Property FromPoint() As PointD Implements cIProfileProjectedData.FromPoint
            Get
                Return oFromPoint
            End Get
        End Property

        Public ReadOnly Property ToPoint() As PointD Implements cIProfileProjectedData.ToPoint
            Get
                Return oToPoint
            End Get
        End Property

        Private Sub pUpdateSidePoints()
            'dati del caposaldo di inizio
            oFromSidePointDown = New PointF(oFromPoint.X, oFromPoint.Y + dFromDown)
            oFromSidePointUp = New PointF(oFromPoint.X, oFromPoint.Y - dFromUp)
            'e di fine
            oToSidePointDown = New PointF(oToPoint.X, oToPoint.Y + dToDown)
            oToSidePointUp = New PointF(oToPoint.X, oToPoint.Y - dToUp)
        End Sub

        Public ReadOnly Property Distance As Decimal Implements cISpatialData.Distance
            Get
                Return oParent.Distance
            End Get
        End Property

        Public ReadOnly Property Inclination As Decimal Implements cISpatialData.Inclination
            Get
                Return oParent.Inclination
            End Get
        End Property

        Public ReadOnly Property Bearing As Decimal Implements cISpatialData.Bearing
            Get
                Return oParent.Bearing
            End Get
        End Property

        Public ReadOnly Property [To] As String Implements cISpatialData.To, cIProfileProjectedData.To
            Get
                Return oParent.To
            End Get
        End Property

        Public ReadOnly Property From As String Implements cISpatialData.From, cIProfileProjectedData.From
            Get
                Return oParent.From
            End Get
        End Property

        Friend Sub SetUD(FromUp As Decimal, FromDown As Decimal, ToUp As Decimal, ToDown As Decimal)
            dFromUp = FromUp
            dFromDown = FromDown
            dToUp = ToUp
            dToDown = ToDown
            Call pUpdateSidePoints()
        End Sub

        Friend Sub New(Parent As cSubData, FromPoint As PointD, ToPoint As PointD)
            oParent = Parent
            oFromPoint = FromPoint
            oToPoint = ToPoint
        End Sub

        Friend Sub New(Parent As cSubData, FromPoint As PointD, ToPoint As PointD, FromUp As Decimal, FromDown As Decimal, ToUp As Decimal, ToDown As Decimal)
            oParent = Parent
            oFromPoint = FromPoint
            oToPoint = ToPoint
            dFromUp = FromUp
            dFromDown = FromDown
            dToUp = ToUp
            dToDown = ToDown
            Call pUpdateSidePoints()
        End Sub

        Public ReadOnly Property Reversed As Boolean Implements cISpatialData.Reversed ', cIProfileProjectedData.Reversed
            Get
                Return oParent.Reversed
            End Get
        End Property

        Public ReadOnly Property Direction As DirectionEnum Implements cISpatialData.Direction ', cIProfileProjectedData.Direction
            Get
                Return oParent.Direction
            End Get
        End Property
    End Class
End Namespace
