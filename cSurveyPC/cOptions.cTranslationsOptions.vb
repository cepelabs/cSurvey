Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Scale
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Imports System.Xml
Imports System.Collections.ObjectModel

Namespace cSurvey.Design.Options
    Public Class cTraslationsStation
        Private sName As String
        Private bHide As Boolean

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public Property Hide As Boolean
            Get
                Return bHide
            End Get
            Set(value As Boolean)
                bHide = value
            End Set
        End Property
    End Class

    Public Class cTranslationsOptions
        Private oSurvey As cSurvey

        Private bDrawTranslationsLine As Boolean
        Private bDrawOriginalPosition As Boolean
        Private oOriginalPositionTranslation As cTranslationBase

        Public Property Stations As List(Of cTraslationsStation)

        Public ReadOnly Property OriginalPositionTranslation As cTranslationBase
            Get
                Return oOriginalPositionTranslation
            End Get
        End Property

        Public Property DrawTranslationsLine As Boolean
            Get
                Return bDrawTranslationsLine
            End Get
            Set(ByVal value As Boolean)
                If value <> bDrawTranslationsLine Then
                    bDrawTranslationsLine = value
                End If
            End Set
        End Property

        Public Property DrawOriginalPosition As Boolean
            Get
                Return bDrawOriginalPosition
            End Get
            Set(ByVal value As Boolean)
                If value <> bDrawOriginalPosition Then
                    bDrawOriginalPosition = value
                End If
            End Set
        End Property

        Friend Sub New(ByVal TranslationsOptions As cTranslationsOptions)
            Call CopyFrom(TranslationsOptions)
        End Sub

        Private iOriginalPositionColorMode As cOptions.CombineColorModeEnum
        Private bOriginalPositionColorGray As Boolean
        Private bOriginalPositionOnlyTranslated As Boolean
        Private bOriginalPositionOverDesign As Boolean
        Private sTranslationsThreshold As Single

        Public Property OriginalPositionOverDesign As Boolean
            Get
                Return bOriginalPositionOverDesign
            End Get
            Set(value As Boolean)
                bOriginalPositionOverDesign = value
            End Set
        End Property

        Public Overridable Property OriginalPositionColorMode As cOptions.CombineColorModeEnum
            Get
                Return iOriginalPositionColorMode
            End Get
            Set(value As cOptions.CombineColorModeEnum)
                iOriginalPositionColorMode = value
            End Set
        End Property

        Public Overridable Property TranslationsThreshold As Single
            Get
                Return sTranslationsThreshold
            End Get
            Set(value As Single)
                sTranslationsThreshold = value
            End Set
        End Property

        Public Overridable Property OriginalPositionOnlyTranslated As Boolean
            Get
                Return bOriginalPositionOnlyTranslated
            End Get
            Set(value As Boolean)
                bOriginalPositionOnlyTranslated = value
            End Set
        End Property

        Public Overridable Property OriginalPositionColorGray As Boolean
            Get
                Return bOriginalPositionColorGray
            End Get
            Set(value As Boolean)
                bOriginalPositionColorGray = value
            End Set
        End Property

        Friend Sub CopyFrom(ByVal TranslationsOptions As cTranslationsOptions)
            bDrawTranslationsLine = TranslationsOptions.bDrawTranslationsLine
            bDrawOriginalPosition = TranslationsOptions.bDrawOriginalPosition
            iOriginalPositionColorMode = TranslationsOptions.iOriginalPositionColorMode
            bOriginalPositionColorGray = TranslationsOptions.bOriginalPositionColorGray
            bOriginalPositionOnlyTranslated = TranslationsOptions.bOriginalPositionOnlyTranslated
            bOriginalPositionOverDesign = TranslationsOptions.bOriginalPositionOverDesign
            sTranslationsThreshold = TranslationsOptions.sTranslationsThreshold
            oOriginalPositionTranslation = New cTranslationBase(TranslationsOptions.oOriginalPositionTranslation)
        End Sub

        Friend Function Clone() As cTranslationsOptions
            Return New cTranslationsOptions(Me)
        End Function

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            bDrawTranslationsLine = True
            bDrawOriginalPosition = False
            iOriginalPositionColorMode = cOptions.CombineColorModeEnum.OnlyCaves
            bOriginalPositionColorGray = True
            bOriginalPositionOnlyTranslated = False
            bOriginalPositionOverDesign = False
            oOriginalPositionTranslation = New cTranslationBase(0, 0)
        End Sub

        Friend ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Friend Sub Import(ByVal TranslationsOptions As XmlElement)
            bDrawTranslationsLine = modXML.GetAttributeValue(TranslationsOptions, "drawtranslationsline")
            bDrawOriginalPosition = modXML.GetAttributeValue(TranslationsOptions, "draworiginalposition")
            iOriginalPositionColorMode = modXML.GetAttributeValue(TranslationsOptions, "originalpositioncolormode", cOptions.CombineColorModeEnum.OnlyCaves)
            bOriginalPositionColorGray = modXML.GetAttributeValue(TranslationsOptions, "originalpositioncolorgray", True)
            bOriginalPositionOnlyTranslated = modXML.GetAttributeValue(TranslationsOptions, "originalpositiononlytranslated", False)
            bOriginalPositionOverDesign = modXML.GetAttributeValue(TranslationsOptions, "originalpositionoverdesign", False)
            sTranslationsThreshold = modXML.GetAttributeValue(TranslationsOptions, "tth", 0)
            If ChildElementExist(TranslationsOptions, "optx") Then
                oOriginalPositionTranslation = New cTranslationBase(TranslationsOptions.Item("optx"))
            Else
                oOriginalPositionTranslation = New cTranslationBase(0, 0)
            End If
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal TranslationsOptions As XmlElement)
            oSurvey = Survey
            Call Import(TranslationsOptions)
        End Sub

        Friend Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLTranslationsOptions As XmlElement = Document.CreateElement("translationsoptions")
            If bDrawTranslationsLine Then Call oXMLTranslationsOptions.SetAttribute("drawtranslationsline", "1")
            If bDrawOriginalPosition Then Call oXMLTranslationsOptions.SetAttribute("draworiginalposition", "1")
            If Not bOriginalPositionColorGray Then Call oXMLTranslationsOptions.SetAttribute("originalpositioncolorgray", "0")
            If bOriginalPositionOnlyTranslated Then Call oXMLTranslationsOptions.SetAttribute("originalpositiononlytranslated", "1")
            If bOriginalPositionOverDesign Then Call oXMLTranslationsOptions.SetAttribute("originalpositionoverdesign", "1")

            If sTranslationsThreshold <> 0 Then oXMLTranslationsOptions.SetAttribute("tth", modNumbers.NumberToString(sTranslationsThreshold, "0.0"))

            If Not oOriginalPositionTranslation.IsEmpty Then
                oOriginalPositionTranslation.SaveTo(File, Document, oXMLTranslationsOptions, "optx")
            End If

            Call Parent.AppendChild(oXMLTranslationsOptions)
            Return oXMLTranslationsOptions
        End Function
    End Class
End Namespace
