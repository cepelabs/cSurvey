Imports cSurveyPC.cSurvey.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate.Plot
    Public Class cPlanSubData
        Implements cISpatialData
        Implements cIPlanProjectedData
        'gestisce i capisaldi dell'oversampling della battuta di poligonale 'parent'
        'i dati LRUD SONO SEMPRE PERPENDICOLARI ALLA BATTUTA!!!!!!!!!!!

        Private oParent As cSubData

        Private oFromPoint As PointD
        Private oToPoint As PointD

        Private oFromSidePointRight As PointD
        Private oFromSidePointLeft As PointD
        Private oToSidePointRight As PointD
        Private oToSidePointLeft As PointD

        Private dFromBearingRight As Decimal
        Private dFromBearingLeft As Decimal
        Private dToBearingRight As Decimal
        Private dToBearingLeft As Decimal

        Private dFromRight As Decimal
        Private dFromLeft As Decimal
        Private dToRight As Decimal
        Private dToLeft As Decimal

        Friend Sub New(Parent As cSubData, ByVal Item As XmlElement)
            oParent = Parent

            oFromPoint = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fpx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fpy", 0)))
            oToPoint = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tpx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tpy", 0)))

            oFromSidePointRight = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fsprx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fspry", 0)))
            oFromSidePointLeft = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fsplx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fsply", 0)))
            oToSidePointRight = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tsprx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tspry", 0)))
            oToSidePointLeft = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tsplx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tsply", 0)))

            dFromBearingRight = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fbr", 0))
            dFromBearingLeft = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fbl", 0))
            dToBearingRight = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tbr", 0))
            dToBearingLeft = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tbl", 0))

            dFromRight = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fr", 0))
            dFromLeft = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fl", 0))
            dToRight = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tr", 0))
            dToLeft = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tl", 0))
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlPlanSD As XmlElement = Document.CreateElement("plansd")

            Call oXmlPlanSD.SetAttribute("fpx", modNumbers.NumberToString(oFromPoint.X, ""))
            Call oXmlPlanSD.SetAttribute("fpy", modNumbers.NumberToString(oFromPoint.Y, ""))
            Call oXmlPlanSD.SetAttribute("tpx", modNumbers.NumberToString(oToPoint.X, ""))
            Call oXmlPlanSD.SetAttribute("tpy", modNumbers.NumberToString(oToPoint.Y, ""))

            Call oXmlPlanSD.SetAttribute("fsprx", modNumbers.NumberToString(oFromSidePointRight.X, ""))
            Call oXmlPlanSD.SetAttribute("fspry", modNumbers.NumberToString(oFromSidePointRight.Y, ""))
            Call oXmlPlanSD.SetAttribute("fsplx", modNumbers.NumberToString(oFromSidePointLeft.X, ""))
            Call oXmlPlanSD.SetAttribute("fsply", modNumbers.NumberToString(oFromSidePointLeft.Y, ""))
            Call oXmlPlanSD.SetAttribute("tsprx", modNumbers.NumberToString(oToSidePointRight.X, ""))
            Call oXmlPlanSD.SetAttribute("tspry", modNumbers.NumberToString(oToSidePointRight.Y, ""))
            Call oXmlPlanSD.SetAttribute("tsplx", modNumbers.NumberToString(oToSidePointLeft.X, ""))
            Call oXmlPlanSD.SetAttribute("tsply", modNumbers.NumberToString(oToSidePointLeft.Y, ""))

            Call oXmlPlanSD.SetAttribute("fbr", modNumbers.NumberToString(dFromBearingRight, ""))
            Call oXmlPlanSD.SetAttribute("fbl", modNumbers.NumberToString(dFromBearingLeft, ""))
            Call oXmlPlanSD.SetAttribute("tbr", modNumbers.NumberToString(dToBearingRight, ""))
            Call oXmlPlanSD.SetAttribute("tbl", modNumbers.NumberToString(dToBearingLeft, ""))

            Call oXmlPlanSD.SetAttribute("fr", modNumbers.NumberToString(dFromRight, ""))
            Call oXmlPlanSD.SetAttribute("fl", modNumbers.NumberToString(dFromLeft, ""))
            Call oXmlPlanSD.SetAttribute("tr", modNumbers.NumberToString(dToRight, ""))
            Call oXmlPlanSD.SetAttribute("tl", modNumbers.NumberToString(dToLeft, ""))

            Call Parent.AppendChild(oXmlPlanSD)
            Return oXmlPlanSD
        End Function

        Public ReadOnly Property ToLeft As Decimal
            Get
                Return dToLeft
            End Get
        End Property

        Public ReadOnly Property ToRight As Decimal
            Get
                Return dToRight
            End Get
        End Property

        Public ReadOnly Property FromLeft As Decimal
            Get
                Return dFromLeft
            End Get
        End Property

        Public ReadOnly Property FromRight As Decimal
            Get
                Return dFromRight
            End Get
        End Property

        Public ReadOnly Property FromPoint() As PointD Implements cIPlanProjectedData.FromPoint
            Get
                Return oFromPoint
            End Get
        End Property

        Public ReadOnly Property ToPoint() As PointD Implements cIPlanProjectedData.ToPoint
            Get
                Return oToPoint
            End Get
        End Property

        Public Function GetCenterPoint() As PointD Implements cIPlanProjectedData.GetCenterPoint
            Return New PointD(oFromPoint.X - (oFromPoint.X - oToPoint.X) / 2, oFromPoint.Y - (oFromPoint.Y - oToPoint.Y) / 2)
        End Function

        Public ReadOnly Property FromSidePointRight() As PointD Implements cIPlanProjectedData.FromSidePointRight
            Get
                Return oFromSidePointRight
            End Get
        End Property

        Public ReadOnly Property FromSidePointLeft() As PointD Implements cIPlanProjectedData.FromSidePointLeft
            Get
                Return oFromSidePointLeft
            End Get
        End Property

        Public ReadOnly Property ToSidePointRight() As PointD Implements cIPlanProjectedData.ToSidePointRight
            Get
                Return oToSidePointRight
            End Get
        End Property

        Public ReadOnly Property ToSidePointLeft() As PointD Implements cIPlanProjectedData.ToSidePointLeft
            Get
                Return oToSidePointLeft
            End Get
        End Property

        Public ReadOnly Property FromBearingRight As Decimal Implements cIPlanProjectedData.FromBearingRight
            Get
                Return dFromBearingRight
            End Get
        End Property

        Public ReadOnly Property FromBearingLeft As Decimal Implements cIPlanProjectedData.FromBearingLeft
            Get
                Return dFromBearingLeft
            End Get
        End Property

        Public ReadOnly Property ToBearingRight As Decimal Implements cIPlanProjectedData.ToBearingRight
            Get
                Return dToBearingRight
            End Get
        End Property

        Public ReadOnly Property ToBearingLeft As Decimal Implements cIPlanProjectedData.ToBearingLeft
            Get
                Return dToBearingLeft
            End Get
        End Property

        Private Sub pUpdateSidePoints()
            Dim dBearing As Decimal = oParent.Bearing
            Dim oDiff As SizeD

            If dFromLeft = 0 Then
                oFromSidePointLeft = oFromPoint
            Else
                'oDiff = modPaint.Trigo(dFromLeft, modPaint.AddAngle(dBearing, -90))
                oDiff = modPaint.Trigo(dFromLeft, dFromBearingLeft)
                oFromSidePointLeft = New PointD(oFromPoint.X + oDiff.Width, oFromPoint.Y + oDiff.Height)
            End If
            If dFromRight = 0 Then
                oFromSidePointRight = oFromPoint
            Else
                'oDiff = modPaint.Trigo(dFromRight, modPaint.AddAngle(dBearing, +90))
                oDiff = modPaint.Trigo(dFromRight, dFromBearingRight)
                oFromSidePointRight = New PointD(oFromPoint.X + oDiff.Width, oFromPoint.Y + oDiff.Height)
            End If

            If dToLeft = 0 Then
                oToSidePointLeft = oToPoint
            Else
                'oDiff = modPaint.Trigo(dToLeft, modPaint.AddAngle(dBearing, -90))
                oDiff = modPaint.Trigo(dToLeft, dToBearingLeft)
                oToSidePointLeft = New PointD(oToPoint.X + oDiff.Width, oToPoint.Y + oDiff.Height)
            End If
            If dToRight = 0 Then
                oToSidePointRight = oToPoint
            Else
                'oDiff = modPaint.Trigo(dToRight, modPaint.AddAngle(dBearing, +90))
                oDiff = modPaint.Trigo(dToRight, dToBearingRight)
                oToSidePointRight = New PointD(oToPoint.X + oDiff.Width, oToPoint.Y + oDiff.Height)
            End If
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

        Public ReadOnly Property [To] As String Implements cISpatialData.To, cIPlanProjectedData.To
            Get
                Return oParent.To
            End Get
        End Property

        Public ReadOnly Property From As String Implements cISpatialData.From, cIPlanProjectedData.From
            Get
                Return oParent.From
            End Get
        End Property

        Friend Sub SetLR(FromLeft As Decimal, FromRight As Decimal, ToLeft As Decimal, ToRight As Decimal)
            dFromLeft = FromLeft
            dFromRight = FromRight
            dToLeft = ToLeft
            dToRight = ToRight
            Call pUpdateSidePoints()
        End Sub

        Friend Sub SetLR(FromLeft As Decimal, FromRight As Decimal, ToLeft As Decimal, ToRight As Decimal, FromBearingLeft As Decimal, FromBearingRight As Decimal, ToBearingLeft As Decimal, ToBearingRight As Decimal)
            dFromBearingLeft = FromBearingLeft
            dFromBearingRight = FromBearingRight
            dToBearingLeft = ToBearingLeft
            dToBearingRight = ToBearingRight
            Call SetLR(FromLeft, FromRight, ToLeft, ToRight)
        End Sub

        Public Sub New(Parent As cSubData, FromPoint As PointD, ToPoint As PointD)
            oParent = Parent
            oFromPoint = FromPoint
            oToPoint = ToPoint
        End Sub

        Public Sub New(Parent As cSubData, FromPoint As PointD, ToPoint As PointD, FromLeft As Decimal, FromRight As Decimal, ToLeft As Decimal, ToRight As Decimal)
            oParent = Parent
            oFromPoint = FromPoint
            oToPoint = ToPoint
            dFromLeft = FromLeft
            dFromRight = FromRight
            dToLeft = ToLeft
            dToRight = ToRight

            Call pUpdateSidePoints()
        End Sub

        Public Sub New(Parent As cSubData, FromPoint As PointD, ToPoint As PointD, FromLeft As Decimal, FromRight As Decimal, ToLeft As Decimal, ToRight As Decimal, FromBearingLeft As Decimal, FromBearingRight As Decimal, ToBearingLeft As Decimal, ToBearingRight As Decimal)
            oParent = Parent
            oFromPoint = FromPoint
            oToPoint = ToPoint
            dFromLeft = FromLeft
            dFromRight = FromRight
            dToLeft = ToLeft
            dToRight = ToRight

            dFromBearingLeft = FromBearingLeft
            dFromBearingRight = FromBearingRight
            dToBearingLeft = ToBearingLeft
            dToBearingRight = ToBearingRight

            Call pUpdateSidePoints()
        End Sub

        Public ReadOnly Property Reversed As Boolean Implements cISpatialData.Reversed ', cIPlanProjectedData.Reversed
            Get
                Return oParent.Reversed
            End Get
        End Property

        Public ReadOnly Property Direction As DirectionEnum Implements cISpatialData.Direction
            Get
                Return oParent.Direction
            End Get
        End Property
    End Class
End Namespace
