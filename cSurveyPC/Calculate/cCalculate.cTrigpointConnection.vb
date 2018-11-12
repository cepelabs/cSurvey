Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports System.IO
Imports System.Xml

Namespace cSurvey.Calculate
    Public Class cTrigPointConnection
        Private sName As String
        Private dDistance As Decimal
        Private oPoint As cTrigPointPoint
        Private bSplay As Boolean

        Friend Sub New(ByVal Name As String, ByVal Distance As Decimal, Optional Splay As Boolean = False)
            sName = Name
            dDistance = Distance
            bSplay = Splay
            oPoint = New cTrigPointPoint(0, 0, 0)
        End Sub

        Friend Sub New(ByVal Item As XmlElement)
            sName = Item.GetAttribute("n")
            dDistance = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "dst", 0))
            If modXML.ChildElementExist(Item, "p") Then
                oPoint = New cTrigPointPoint(Item.Item("p"))
            Else
                oPoint = New cTrigPointPoint(0, 0, 0)
            End If
            bSplay = modXML.GetAttributeValue(Item, "s", 0)
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlTrigpointConnection As XmlElement = Document.CreateElement("tcon")
            Call oXmlTrigpointConnection.SetAttribute("n", sName)
            Call oXmlTrigpointConnection.SetAttribute("dst", modNumbers.NumberToString(dDistance, ""))
            If Not oPoint Is Nothing Then Call oPoint.SaveTo(File, Document, oXmlTrigpointConnection, "p")
            If bSplay Then Call oXmlTrigpointConnection.SetAttribute("s", "1")
            Call Parent.AppendChild(oXmlTrigpointConnection)
            Return oXmlTrigpointConnection
        End Function

        Public Function IsEmpty()
            Return oPoint.IsEmpty
        End Function

        Public Function GetPoint() As cTrigPointPoint
            Return oPoint
        End Function

        Friend Function SetPoint(ByVal Point As cTrigPointPoint, Optional ByVal IfNotEmpty As Boolean = False) As cTrigPointPoint
            If (IfNotEmpty AndAlso oPoint.IsEmpty) OrElse (Not IfNotEmpty) Then
                oPoint = New cTrigPointPoint(Point)
                Return oPoint
            End If
        End Function

        Friend Function SetPoint(ByVal X As Decimal, ByVal Y As Decimal, ByVal Z As Decimal, Optional ByVal D As Decimal = 0, Optional ByVal IfNotEmpty As Boolean = False) As cTrigPointPoint
            If (IfNotEmpty AndAlso oPoint.IsEmpty) OrElse (Not IfNotEmpty) Then
                oPoint = New cTrigPointPoint(X, Y, Z, D)
                Return oPoint
            End If
        End Function

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public ReadOnly Property Distance As Decimal
            Get
                Return dDistance
            End Get
        End Property

        Public ReadOnly Property Splay() As Boolean
            Get
                Return bSplay
            End Get
        End Property
    End Class
End Namespace