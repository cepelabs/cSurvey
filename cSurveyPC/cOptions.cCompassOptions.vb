Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Scale
Imports cSurveyPC.cSurvey.Design.Items

Imports System.Xml
Imports System.Collections.ObjectModel

Namespace cSurvey.Design.Options
    Public Class cCompassOptions
        Private oSurvey As cSurvey

        Private oColor As Color

        Private oClipart As cDrawClipArt
        Private sClipartZoomFactor As Single

        Private WithEvents oFont As cItemFont
        Private sText As String

        'Friend Event OnChange(ByVal Sender As cCompassOptions)

        Friend Sub CopyFrom(ByVal CompassOptions As cCompassOptions)
            oSurvey = CompassOptions.Survey
            oClipart = CompassOptions.Clipart.Clone
            sClipartZoomFactor = CompassOptions.ClipartZoomFactor
            oFont = CompassOptions.Font.Clone
            sText = CompassOptions.Text
            'RaiseEvent OnChange(Me)
        End Sub

        Friend Function Clone() As cCompassOptions
            Return New cCompassOptions(Me)
        End Function

        Friend Sub New(ByVal CompassOptions As cCompassOptions)
            Call CopyFrom(CompassOptions)
        End Sub

        Friend ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public Property Clipart() As cDrawClipArt
            Get
                Return oClipart
            End Get
            Set(ByVal value As cDrawClipArt)
                If Not oClipart Is value Then
                    oClipart = value
                    'RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public Property ClipartZoomFactor() As Single
            Get
                Return sClipartZoomFactor
            End Get
            Set(ByVal value As Single)
                If sClipartZoomFactor <> value And sClipartZoomFactor > 0 Then
                    sClipartZoomFactor = value
                    'RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public Property Color() As Color
            Get
                Return oColor
            End Get
            Set(ByVal value As Color)
                If Color <> value Then
                    oColor = value
                    'RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public Property Text() As String
            Get
                Return sText
            End Get
            Set(ByVal value As String)
                If sText <> value Then
                    sText = value
                    'RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public ReadOnly Property Font As cItemFont
            Get
                Return oFont
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.Title)
            sText = "N"
            oClipart = modPenClipart.ClipartCompass
            oColor = Drawing.Color.Black
            sClipartZoomFactor = 1
        End Sub

        Friend Sub Import(ByVal CompassOptions As XmlElement)
            On Error Resume Next
            Dim oImportedFont As cItemFont = New cItemFont(oSurvey, CompassOptions.Item("font"))
            Call oFont.CopyFrom(oImportedFont)
            oColor = Color.FromArgb(CompassOptions.GetAttribute("color"))
            oClipart = New cDrawClipArt(CompassOptions.Item("clipart"))
            sClipartZoomFactor = modNumbers.StringToSingle(modXML.GetAttributeValue(CompassOptions, "clipartzoomfactor", 0))
            sText = CompassOptions.GetAttribute("text")
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal CompassOptions As XmlElement)
            oSurvey = Survey
            Try
                oFont = New cItemFont(oSurvey, CompassOptions.Item("font"))
            Catch
                oFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.Title)
            End Try
            oColor = Color.FromArgb(CompassOptions.GetAttribute("color"))
            Try
                oClipart = New cDrawClipArt(CompassOptions.Item("clipart"))
            Catch
                oClipart = New cDrawClipArt()
            End Try
            sClipartZoomFactor = modNumbers.StringToSingle(modXML.GetAttributeValue(CompassOptions, "clipartzoomfactor", 0))
            sText = CompassOptions.GetAttribute("text")
            Call Import(CompassOptions)
        End Sub

        Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLCompassOptions As XmlElement = Document.CreateElement("compassoptions")
            Call oFont.SaveTo(File, Document, oXMLCompassOptions, "font")
            Call oXMLCompassOptions.SetAttribute("text", sText)
            Call oXMLCompassOptions.SetAttribute("color", oColor.ToArgb)
            Call oClipart.SaveTo(File, Document, oXMLCompassOptions)
            Call oXMLCompassOptions.SetAttribute("clipartzoomfactor", modNumbers.NumberToString(sClipartZoomFactor))
            Call Parent.AppendChild(oXMLCompassOptions)
            Return oXMLCompassOptions
        End Function

        'Private Sub oFont_OnChanged(ByVal Sender As cItemFont) Handles oFont.OnChanged
        '    RaiseEvent OnChange(Me)
        'End Sub
    End Class
End Namespace
