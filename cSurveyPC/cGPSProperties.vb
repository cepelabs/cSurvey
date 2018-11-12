Imports System.Xml

Namespace cSurvey
    Public Class cGPSProperties
        Private oSurvey As cSurvey

        Private bRefPointOnOrigin As Boolean
        Private sCustomRefPoint As String

        Private sSystem As String
        Private sBand As String
        Private sZone As String
        Private sFormat As String

        Private bSendToTherion As Boolean

        Private bEnabled As Boolean

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            bEnabled = False
            bRefPointOnOrigin = True
            sCustomRefPoint = ""
            sSystem = "WGS84"
            sFormat = ""
            sZone = ""
            sBand = ""
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal GPSProperties As XmlElement)
            oSurvey = Survey
            bEnabled = modXML.GetAttributeValue(GPSProperties, "enabled", False)
            bRefPointOnOrigin = modXML.GetAttributeValue(GPSProperties, "refpointonorigin", False)
            sCustomRefPoint = modXML.GetAttributeValue(GPSProperties, "customrefpoint", "")
            sSystem = modXML.GetAttributeValue(GPSProperties, "geo", "WGS84")
            Select Case sSystem
                Case "WGS84/UTM"
                    sBand = modXML.GetAttributeValue(GPSProperties, "band", "")
                    sZone = modXML.GetAttributeValue(GPSProperties, "zone", "")
                Case Else
                    sFormat = modXML.GetAttributeValue(GPSProperties, "format", "")
            End Select
            bSendToTherion = modXML.GetAttributeValue(GPSProperties, "sendtotherion", False)
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlGPSProperties As XmlElement = Document.CreateElement("gps")
            If bEnabled Then Call oXmlGPSProperties.SetAttribute("enabled", "1")
            If bRefPointOnOrigin Then Call oXmlGPSProperties.SetAttribute("refpointonorigin", "1")
            If sCustomRefPoint <> "" Then Call oXmlGPSProperties.SetAttribute("customrefpoint", sCustomRefPoint)
            If sSystem <> "WGS84" Then Call oXmlGPSProperties.SetAttribute("geo", sSystem)
            Select Case sSystem
                Case "WGS84/UTM"
                    Call oXmlGPSProperties.SetAttribute("zone", szone)
                    Call oXmlGPSProperties.SetAttribute("band", sband)
                Case Else
                    Call oXmlGPSProperties.SetAttribute("format", sFormat)
            End Select
            If bSendToTherion Then oXmlGPSProperties.SetAttribute("sendtotherion", "1")
            Call Parent.AppendChild(oXmlGPSProperties)
            Return oXmlGPSProperties
        End Function

        Public Property Band() As String
            Get
                Return sBand
            End Get
            Set(ByVal value As String)
                sBand = value
            End Set
        End Property

        Public Property Zone() As String
            Get
                Return szone
            End Get
            Set(ByVal value As String)
                sZone = value
            End Set
        End Property

        Public Property Format() As String
            Get
                Return sFormat
            End Get
            Set(ByVal value As String)
                sFormat = value
            End Set
        End Property

        Public Property System() As String
            Get
                Return sSystem
            End Get
            Set(ByVal value As String)
                sSystem = value
            End Set
        End Property

        Public Property SendToTherion As Boolean
            Get
                Return bSendToTherion
            End Get
            Set(ByVal value As Boolean)
                bSendToTherion = value
            End Set
        End Property

        Public Property Enabled As Boolean
            Get
                Return bEnabled
            End Get
            Set(ByVal value As Boolean)
                bEnabled = value
            End Set
        End Property

        Public Property RefPointOnOrigin As Boolean
            Get
                Return bRefPointOnOrigin
            End Get
            Set(ByVal value As Boolean)
                bRefPointOnOrigin = value
            End Set
        End Property

        Friend Sub RenameCustomRefPoint(NewName As String)
            sCustomRefPoint = NewName
        End Sub

        Public Function GetRefPoint() As String
            If bRefPointOnOrigin Then
                Return oSurvey.Properties.Origin
            Else
                Return sCustomRefPoint
            End If
        End Function

        Public Property CustomRefPoint As String
            Get
                Return sCustomRefPoint
            End Get
            Set(ByVal value As String)
                sCustomRefPoint = value
            End Set
        End Property

        Public Sub Clear()
            bRefPointOnOrigin = True
            sCustomRefPoint = ""
            sSystem = "WGS84"
            sFormat = ""
            sBand = ""
            sZone = ""
        End Sub
    End Class
End Namespace