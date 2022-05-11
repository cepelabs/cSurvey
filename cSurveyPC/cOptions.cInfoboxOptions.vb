Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Scale
Imports cSurveyPC.cSurvey.Design.Items

Imports System.Xml
Imports System.Collections.ObjectModel

Namespace cSurvey.Design.Options
    Public Class cInfoBoxOptions
        Private oSurvey As cSurvey

        Private WithEvents oIDFont As cItemFont
        Private WithEvents oTitleFont As cItemFont
        Private WithEvents oTextFont As cItemFont

        Private bIDVisible As Boolean
        Private bTitleVisible As Boolean
        Private bTextVisible As Boolean

        Private sWidth As Single

        'Friend Event OnChange(ByVal sender As cInfoBoxOptions)

        Public ReadOnly Property IDFont As cItemFont
            Get
                Return oIDFont
            End Get
        End Property

        Public ReadOnly Property TextFont As cItemFont
            Get
                Return oTextFont
            End Get
        End Property

        Public ReadOnly Property TitleFont As cItemFont
            Get
                Return oTitleFont
            End Get
        End Property

        Public Property Width As Single
            Get
                Return sWidth
            End Get
            Set(value As Single)
                If sWidth <> value Then
                    sWidth = value
                End If
            End Set
        End Property

        Public Overridable Property TitleVisible As Boolean
            Get
                Return bTitleVisible
            End Get
            Set(ByVal value As Boolean)
                If bTitleVisible <> value Then
                    bTitleVisible = value
                    'RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public Overridable Property TextVisible As Boolean
            Get
                Return bTextVisible
            End Get
            Set(ByVal value As Boolean)
                If bTextVisible <> value Then
                    bTextVisible = value
                    'RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public Overridable Property IDVisible As Boolean
            Get
                Return bIDVisible
            End Get
            Set(ByVal value As Boolean)
                If bIDVisible <> value Then
                    bIDVisible = value
                    'RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Friend Function Clone() As cInfoBoxOptions
            Return New cInfoBoxOptions(Me)
        End Function

        Friend Sub CopyFrom(ByVal InfoBoxOptions As cInfoBoxOptions)
            oSurvey = InfoBoxOptions.Survey
            oIDFont = InfoBoxOptions.IDFont.Clone
            oTitleFont = InfoBoxOptions.TitleFont.Clone
            oTextFont = InfoBoxOptions.TextFont.Clone
            bIDVisible = InfoBoxOptions.bIDVisible
            bTitleVisible = InfoBoxOptions.bTitleVisible
            bTextVisible = InfoBoxOptions.bTextVisible
            sWidth = InfoBoxOptions.sWidth
            'RaiseEvent OnChange(Me)
        End Sub

        Friend Sub New(ByVal InfoBoxOptions As cInfoBoxOptions)
            Call CopyFrom(InfoBoxOptions)
        End Sub

        Friend ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oIDFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.CaveComplexName)
            oTitleFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.CaveComplexName)
            oTextFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.Generic)
            bIDVisible = True
            bTitleVisible = True
            bTextVisible = True
            sWidth = 0
        End Sub

        Friend Sub Import(ByVal InfoBoxOptions As XmlElement)
            On Error Resume Next
            Dim oTmpIDFont As cItemFont = New cItemFont(oSurvey, InfoBoxOptions.Item("idfont"))
            oIDFont.CopyFrom(oTmpIDFont)
            Dim oTmpTitleFont As cItemFont = New cItemFont(oSurvey, InfoBoxOptions.Item("titlefont"))
            oTitleFont.CopyFrom(oTmpTitleFont)
            Dim oTmpTextFont As cItemFont = New cItemFont(oSurvey, InfoBoxOptions.Item("textfont"))
            oTextFont.CopyFrom(oTmpTextFont)
            bIDVisible = InfoBoxOptions.GetAttribute("idvisible")
            bTitleVisible = InfoBoxOptions.GetAttribute("titlevisible")
            bTextVisible = InfoBoxOptions.GetAttribute("textvisible")

            sWidth = modNumbers.StringToSingle(modXML.GetAttributeValue(InfoBoxOptions, "width", 0))
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal InfoBoxOptions As XmlElement)
            oSurvey = Survey
            Try
                oIDFont = New cItemFont(oSurvey, InfoBoxOptions.Item("idfont"))
            Catch
                oIDFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.CaveComplexName)
            End Try

            Try
                oTitleFont = New cItemFont(oSurvey, InfoBoxOptions.Item("titlefont"))
            Catch
                oTitleFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.CaveComplexName)
            End Try

            Try
                oTextFont = New cItemFont(oSurvey, InfoBoxOptions.Item("textfont"))
            Catch
                oTextFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.Generic)
            End Try

            bIDVisible = InfoBoxOptions.GetAttribute("idvisible")
            bTitleVisible = InfoBoxOptions.GetAttribute("titlevisible")
            bTextVisible = InfoBoxOptions.GetAttribute("textvisible")

            sWidth = modNumbers.StringToSingle(modXML.GetAttributeValue(InfoBoxOptions, "width", 0))
        End Sub

        Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLInfoBoxOptions As XmlElement = Document.CreateElement("infoboxoptions")
            Call oXMLInfoBoxOptions.SetAttribute("idvisible", IIf(bIDVisible, 1, 0))
            Call oXMLInfoBoxOptions.SetAttribute("titlevisible", IIf(bTitleVisible, 1, 0))
            Call oXMLInfoBoxOptions.SetAttribute("textvisible", IIf(bTextVisible, 1, 0))
            Call oXMLInfoBoxOptions.SetAttribute("width", modNumbers.NumberToString(sWidth))
            Call oIDFont.SaveTo(File, Document, oXMLInfoBoxOptions, "idfont")
            Call oTitleFont.SaveTo(File, Document, oXMLInfoBoxOptions, "titlefont")
            Call oTextFont.SaveTo(File, Document, oXMLInfoBoxOptions, "textfont")
            Call Parent.AppendChild(oXMLInfoBoxOptions)
            Return oXMLInfoBoxOptions
        End Function
    End Class
End Namespace
