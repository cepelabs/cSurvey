Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Scale
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Imports System.Xml
Imports System.Collections.ObjectModel
Imports cSurveyPC.cSurvey.Scripting

Namespace cSurvey.Properties
    Public Class cShotHighlightDetails
        Private oSurvey As cSurvey
        Private oElement As cSegment
        Private oMeters As cHighlightsDetailMeters

        Public ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public ReadOnly Property Element As cSegment
            Get
                Return oElement
            End Get
        End Property

        Public ReadOnly Property Meters As cHighlightsDetailMeters
            Get
                Return oMeters
            End Get
        End Property

        Friend Sub New(Survey As cSurvey, Element As cSegment, Meters As cIHighlightsDetailMeters)
            oSurvey = Survey
            oElement = Element
            oMeters = Meters
        End Sub
    End Class

    Public Class cStationHighlightDetails
        Private oSurvey As cSurvey
        Private oElement As cTrigPoint
        Private oMeters As cHighlightsDetailMeters

        Public ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public ReadOnly Property Element As cTrigPoint
            Get
                Return oElement
            End Get
        End Property

        Public ReadOnly Property Meters As cHighlightsDetailMeters
            Get
                Return oMeters
            End Get
        End Property

        Friend Sub New(Survey As cSurvey, Element As cTrigPoint, Meters As cIHighlightsDetailMeters)
            oSurvey = Survey
            oElement = Element
            oMeters = Meters
        End Sub
    End Class

    Public Interface cIHighlightsDetailMeters
        Property Color As Color
        Property Colors As Color()
        Property Size As Single
        Property Opacity As Byte
    End Interface

    Public Class cHighlightsDetailMeters
        Implements cIHighlightsDetailMeters
        Private oColors As Color()
        Private sSize As Single
        Private iOpacity As Byte

        Public Property Color As Color Implements cIHighlightsDetailMeters.Color
            Get
                Return oColors(0)
            End Get
            Set(value As Color)
                oColors(0) = value
            End Set
        End Property

        Public Property Colors As Color() Implements cIHighlightsDetailMeters.Colors
            Get
                Return oColors
            End Get
            Set(value As Color())
                oColors = value
            End Set
        End Property

        Public Property Size As Single Implements cIHighlightsDetailMeters.Size
            Get
                Return sSize
            End Get
            Set(value As Single)
                sSize = value
            End Set
        End Property

        Public Property Opacity As Byte Implements cIHighlightsDetailMeters.Opacity
            Get
                Return iOpacity
            End Get
            Set(value As Byte)
                iOpacity = value
            End Set
        End Property

        Friend Sub New(Colors As Color(), Size As Single, Opacity As Byte)
            oColors = Colors
            sSize = Size
            iOpacity = Opacity
        End Sub

        Friend Sub New(Color As Color, Size As Single, Opacity As Byte)
            oColors = {Color}
            sSize = Size
            iOpacity = Opacity
        End Sub

        Friend Sub New(Details As cIHighlightsDetailMeters)
            oColors = Details.Colors
            sSize = Details.Size
            iOpacity = Details.Opacity
        End Sub
    End Class

    Public Class cHighlightsDetail
        Implements cIHighlightsDetailMeters
        Private oSurvey As cSurvey

        Private sID As String

        Private sName As String
        Private oMeters As cHighlightsDetailMeters
        Private bSystem As Boolean

        Public Enum ApplyToEnum
            Stations = 0
            Shots = 1
            Both = 2
        End Enum
        Private iApplyTo As ApplyToEnum

        Private sCondition As String

        Public Property Condition As String
            Get
                Return sCondition
            End Get
            Set(value As String)
                If Not bSystem AndAlso sCondition <> value Then
                    sCondition = value
                    oScript = Nothing
                End If
            End Set
        End Property

        Public Property ApplyTo As ApplyToEnum
            Get
                Return iApplyTo
            End Get
            Set(value As ApplyToEnum)
                If Not bSystem Then
                    iApplyTo = value
                End If
            End Set
        End Property

        Public ReadOnly Property ID As String
            Get
                Return sID
            End Get
        End Property

        Public ReadOnly Property System As Boolean
            Get
                Return bSystem
            End Get
        End Property

        Public Property Color As Color Implements cIHighlightsDetailMeters.Color
            Get
                Return oMeters.Color
            End Get
            Set(value As Color)
                oMeters.Color = value
            End Set
        End Property

        Public Property Colors As Color() Implements cIHighlightsDetailMeters.Colors
            Get
                Return oMeters.Colors
            End Get
            Set(value As Color())
                oMeters.Colors = value
            End Set
        End Property

        Public Property Size As Single Implements cIHighlightsDetailMeters.Size
            Get
                Return oMeters.Size
            End Get
            Set(value As Single)
                oMeters.Size = value
            End Set
        End Property

        Public Property Opacity As Byte Implements cIHighlightsDetailMeters.Opacity
            Get
                Return oMeters.Opacity
            End Get
            Set(value As Byte)
                oMeters.Opacity = value
            End Set
        End Property

        Public Property Name As String
            Get
                Return sName
            End Get
            Set(value As String)
                sName = Name
            End Set
        End Property

        Friend Sub New(Survey As cSurvey, ID As String, Name As String, Color As Color, Size As Single, Opacity As Byte, ApplyTo As ApplyToEnum, Condition As String, System As Boolean)
            oSurvey = Survey
            sID = ID
            sName = Name
            oMeters = New cHighlightsDetailMeters(Color, Size, Opacity)
            iApplyTo = ApplyTo
            sCondition = Condition
            bSystem = System
        End Sub

        Friend Sub New(Survey As cSurvey, Name As String, Color As Color, Size As Single, Opacity As Byte, ApplyTo As ApplyToEnum, Condition As String, System As Boolean)
            oSurvey = Survey
            sID = Guid.NewGuid.ToString
            sName = Name
            oMeters = New cHighlightsDetailMeters(Color, Size, Opacity)
            iApplyTo = ApplyTo
            sCondition = Condition
            bSystem = System
        End Sub

        Private oScript As Scripting.cScript

        Public Function GetMetres() As cHighlightsDetailMeters
            Return New cHighlightsDetailMeters(Me)
        End Function

        Friend Shared Function GetScriptCode(ScripBag As cScriptBag, ApplyTo As ApplyToEnum) As String
            If ScripBag.Unboxed Then
                Return ScripBag.Code
            Else
                Dim sFullCode As String = ""
                Select Case ScripBag.Language
                    Case LanguageEnum.VisualBasic
                        If ApplyTo = ApplyToEnum.Stations Then
                            sFullCode = "public function GetHighlight(Details as cStationHighlightDetails) as boolean" & vbCrLf & vbTab & "return " & ScripBag.Code & vbCrLf & "end function"
                        Else
                            sFullCode = "public function GetHighlight(Details as cShotHighlightDetails) as boolean" & vbCrLf & vbTab & "return " & ScripBag.Code & vbCrLf & "end function"
                        End If
                    Case LanguageEnum.CSharp
                        If ApplyTo = ApplyToEnum.Stations Then
                            sFullCode = "public bool GetHighlight(cStationHighlightDetails Details) {" & vbCrLf & vbTab & "return " & ScripBag.Code & ";" & vbCrLf & "}"
                        Else
                            sFullCode = "public bool GetHighlight(cShotHighlightDetails Details) {" & vbCrLf & vbTab & "return " & ScripBag.Code & ";" & vbCrLf & "}"
                        End If
                End Select
                Return sFullCode
            End If
        End Function

        Friend Function GetScript() As Scripting.cScript
            If oScript Is Nothing Then
                Dim oScriptBag As cScriptBag = New cScriptBag(sCondition)
                oScript = New Scripting.cScript(oSurvey, GetScriptCode(oScriptBag, iApplyTo), oScriptBag.Language)
            End If
            Return oScript
        End Function

        Friend Sub New(Survey As cSurvey, ByVal HLSDetail As XmlElement)
            oSurvey = Survey
            sID = HLSDetail.GetAttribute("id")
            sName = HLSDetail.GetAttribute("n")
            oMeters = New cHighlightsDetailMeters(modXML.GetAttributeColors(HLSDetail, "colors", {Color.Red}), modNumbers.StringToSingle(modXML.GetAttributeValue(HLSDetail, "sz", 10)), modXML.GetAttributeValue(HLSDetail, "op", 140))
            iApplyTo = modXML.GetAttributeValue(HLSDetail, "at")
            sCondition = modXML.GetAttributeValue(HLSDetail, "cnd")
            bSystem = modXML.GetAttributeValue(HLSDetail, "sys", 0)
        End Sub

        Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLHLDetail As XmlElement = Document.CreateElement("hlsd")
            Call oXMLHLDetail.SetAttribute("id", sID)
            Call oXMLHLDetail.SetAttribute("n", sName)
            Call oXMLHLDetail.SetAttribute("colors", Strings.Join(oMeters.Colors.Select(Function(item) item.ToArgb.ToString).ToArray, ";"))
            If oMeters.Size <> 10 Then Call oXMLHLDetail.SetAttribute("sz", modNumbers.NumberToString(oMeters.Size, "0.00"))
            If oMeters.Opacity <> 140 Then Call oXMLHLDetail.SetAttribute("op", oMeters.Opacity)
            Call oXMLHLDetail.SetAttribute("at", iApplyTo.ToString("D"))
            Call oXMLHLDetail.SetAttribute("cnd", sCondition)
            If bSystem Then oXMLHLDetail.SetAttribute("sys", "1")
            Call Parent.AppendChild(oXMLHLDetail)
            Return oXMLHLDetail
        End Function
    End Class
End Namespace
