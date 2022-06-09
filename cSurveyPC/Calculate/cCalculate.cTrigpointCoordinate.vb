Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports System.IO
Imports System.Xml

Namespace cSurvey.Calculate
    Public Class cTrigPointCoordinate
        Private dLatitude As Decimal
        Private dLongitude As Decimal
        Private dAltitude As Decimal

        Public Sub New(ByVal Latitude As Decimal, Longitude As Decimal, Altitude As Decimal)
            dlatitude = Latitude
            dLongitude = Longitude
            dAltitude = Altitude
        End Sub

        Public ReadOnly Property IsEmpty(Optional ByVal CheckAltitude As Boolean = False) As Boolean
            Get
                'in realta...non andrebbe bene ma cambia poco
                Return dLatitude = 0 AndAlso dLongitude = 0 AndAlso (Not CheckAltitude OrElse (CheckAltitude AndAlso dAltitude = 0))
            End Get
        End Property

        Friend Sub New(ByVal Item As XmlElement)
            dlatitude = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "lat", 0))
            dLongitude = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "lon", 0))
            dAltitude = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "alt", 0))
        End Sub

        Public Sub New(ByVal Coordinate As cTrigPointCoordinate)
            With Coordinate
                dlatitude = .Latitude
                dLongitude = .Longitude
                dAltitude = .Altitude
            End With
        End Sub

        Public Sub New(ByVal Coordinate As cCoordinate)
            With Coordinate
                dlatitude = .GetLatitude
                dLongitude = .GetLongitude
                dAltitude = .GetAltitude
            End With
        End Sub

        Public Property Altitude As Decimal
            Get
                Return dAltitude
            End Get
            Set(value As Decimal)
                dAltitude = value
            End Set
        End Property

        Public Property Latitude As Decimal
            Get
                Return dLatitude
            End Get
            Set(value As Decimal)
                dLatitude = value
            End Set
        End Property

        Public Property Longitude As Decimal
            Get
                Return dLongitude
            End Get
            Set(value As Decimal)
                dLongitude = value
            End Set
        End Property

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, ByVal Name As String) As XmlElement
            Dim oXmlCoordinate As XmlElement = Document.CreateElement(Name)
            Call oXmlCoordinate.SetAttribute("alt", modNumbers.NumberToString(dAltitude, ""))
            Call oXmlCoordinate.SetAttribute("lat", modNumbers.NumberToString(dLatitude, ""))
            Call oXmlCoordinate.SetAttribute("lon", modNumbers.NumberToString(dLongitude, ""))
            Call Parent.AppendChild(oXmlCoordinate)
            Return oXmlCoordinate
        End Function
    End Class
End Namespace
