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
        Implements cIUIBaseInteractions

        Private oSurvey As cSurvey

        Private bDrawTranslationsLine As Boolean
        Private bDrawOriginalPosition As Boolean

        'translationbase have to implements UIBaseInteractions but, ad now, translation can be defined only once for plan and once for profile. Not for print/export profile. I will change this when this behaviour change.
        Private oOriginalPositionTranslation As cTranslationBase

        Public Event OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Implements cIUIBaseInteractions.OnPropertyChanged

        Public Sub PropertyChanged(Name As String) Implements cIUIBaseInteractions.PropertyChanged
            RaiseEvent OnPropertyChanged(Me, New PropertyChangeEventArgs(Name))
        End Sub

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
                    Call PropertyChanged("DrawTranslationsLine")
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
                    Call PropertyChanged("DrawOriginalPosition")
                End If
            End Set
        End Property

        Friend Sub New(ByVal TranslationsOptions As cTranslationsOptions)
            Call CopyFrom(TranslationsOptions)
        End Sub

        Private iOriginalPositionColorMode As cOptionsDesign.CombineColorModeEnum
        Private bOriginalPositionColorGray As Boolean
        Private bOriginalPositionOnlyTranslated As Boolean
        Private bOriginalPositionOverDesign As Boolean
        Private sTranslationsThreshold As Single

        Public Property OriginalPositionOverDesign As Boolean
            Get
                Return bOriginalPositionOverDesign
            End Get
            Set(value As Boolean)
                If bOriginalPositionOverDesign <> value Then
                    bOriginalPositionOverDesign = value
                    Call PropertyChanged("OriginalPositionOverDesign")
                End If
            End Set
        End Property

        Public Overridable Property OriginalPositionColorMode As cOptionsDesign.CombineColorModeEnum
            Get
                Return iOriginalPositionColorMode
            End Get
            Set(value As cOptionsDesign.CombineColorModeEnum)
                If iOriginalPositionColorMode <> value Then
                    iOriginalPositionColorMode = value
                    Call PropertyChanged("OriginalPositionColorMode")
                End If
            End Set
        End Property

        Public Overridable Property TranslationsThreshold As Single
            Get
                Return sTranslationsThreshold
            End Get
            Set(value As Single)
                If sTranslationsThreshold <> value Then
                    sTranslationsThreshold = value
                    Call PropertyChanged("TranslationsThreshold")
                End If
            End Set
        End Property

        Public Overridable Property OriginalPositionOnlyTranslated As Boolean
            Get
                Return bOriginalPositionOnlyTranslated
            End Get
            Set(value As Boolean)
                If bOriginalPositionOnlyTranslated <> value Then
                    bOriginalPositionOnlyTranslated = value
                    Call PropertyChanged("OriginalPositionOnlyTranslated")
                End If
            End Set
        End Property

        Public Overridable Property OriginalPositionColorGray As Boolean
            Get
                Return bOriginalPositionColorGray
            End Get
            Set(value As Boolean)
                If bOriginalPositionColorGray <> value Then
                    bOriginalPositionColorGray = value
                    Call PropertyChanged("OriginalPositionColorGray")
                End If
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
            iOriginalPositionColorMode = cOptionsDesign.CombineColorModeEnum.OnlyCaves
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
            iOriginalPositionColorMode = modXML.GetAttributeValue(TranslationsOptions, "originalpositioncolormode", cOptionsDesign.CombineColorModeEnum.OnlyCaves)
            bOriginalPositionColorGray = modXML.GetAttributeValue(TranslationsOptions, "originalpositioncolorgray", True)
            bOriginalPositionOnlyTranslated = modXML.GetAttributeValue(TranslationsOptions, "originalpositiononlytranslated", False)
            bOriginalPositionOverDesign = modXML.GetAttributeValue(TranslationsOptions, "originalpositionoverdesign", False)
            sTranslationsThreshold = modNumbers.StringToSingle(modXML.GetAttributeValue(TranslationsOptions, "tth", 0))
            If sTranslationsThreshold > 10000.0F Then sTranslationsThreshold = 0F
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

        Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
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
