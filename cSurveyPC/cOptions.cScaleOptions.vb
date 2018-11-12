Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Scale
Imports cSurveyPC.cSurvey.Design.Items

Imports System.Xml
Imports System.Collections.ObjectModel

Namespace cSurvey.Design.Options
    Public Class cScaleOptions
        Private oSurvey As cSurvey

        Private oColor As Color

        Private iMeters As Integer
        Private iSteps As Integer
        Private iStep As Integer

        Private bHideScaleValue As Boolean

        Private WithEvents oFont As cItemFont

        Private sText As String

        'Friend Event OnChange(ByVal Sender As cScaleOptions)

        Friend Sub CopyFrom(ByVal ScaleOptions As cScaleOptions)
            oSurvey = ScaleOptions.Survey
            oFont = ScaleOptions.Font.Clone
            iMeters = ScaleOptions.iMeters
            iSteps = ScaleOptions.iSteps
            iStep = ScaleOptions.iStep
            oColor = ScaleOptions.Color
            sText = ScaleOptions.sText
            bHideScaleValue = ScaleOptions.bHideScaleValue
            'RaiseEvent OnChange(Me)
        End Sub

        Friend Function Clone() As cScaleOptions
            Return New cScaleOptions(Me)
        End Function

        Friend Sub New(ByVal ScaleOptions As cScaleOptions)
            Call CopyFrom(ScaleOptions)
        End Sub

        Friend ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.Title)
            oColor = Drawing.Color.Black
            iMeters = 10
            iSteps = 5
            iStep = 1
            sText = modMain.GetLocalizedString("itemscale.defaultscaletext")
            bHideScaleValue = False
        End Sub

        Public Property Meters As Integer
            Get
                Return iMeters
            End Get
            Set(ByVal value As Integer)
                If iMeters <> value Then
                    iMeters = value
                    'RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public Property Steps As Integer
            Get
                Return iSteps
            End Get
            Set(ByVal value As Integer)
                If iSteps <> value Then
                    iSteps = value
                    'RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public Property HideScaleValue As Boolean
            Get
                Return bHideScaleValue
            End Get
            Set(value As Boolean)
                If value <> bHideScaleValue Then
                    bHideScaleValue = value
                End If
            End Set
        End Property

        Public Property [Step] As Integer
            Get
                Return iStep
            End Get
            Set(ByVal value As Integer)
                If iStep <> value Then
                    iStep = value
                    'RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public ReadOnly Property Font As cItemFont
            Get
                Return oFont
            End Get
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

        Friend Sub Import(ByVal ScaleOptions As XmlElement)
            iMeters = modXML.GetAttributeValue(ScaleOptions, "meters")
            iSteps = modXML.GetAttributeValue(ScaleOptions, "steps")
            iStep = modXML.GetAttributeValue(ScaleOptions, "step")
            oColor = modXML.GetAttributeColor(ScaleOptions, "color", Drawing.Color.Black)
            Dim oTmpFont As cItemFont = New cItemFont(oSurvey, ScaleOptions.Item("font"))
            Call oFont.CopyFrom(oTmpFont)
            sText = modXML.GetAttributeValue(ScaleOptions, "text")
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal ScaleOptions As XmlElement)
            oSurvey = Survey
            iMeters = modXML.GetAttributeValue(ScaleOptions, "meters")
            iSteps = modXML.GetAttributeValue(ScaleOptions, "steps")
            iStep = modXML.GetAttributeValue(ScaleOptions, "step", 1)
            oColor = modXML.GetAttributeColor(ScaleOptions, "color", Drawing.Color.Black)
            Try
                oFont = New cItemFont(oSurvey, ScaleOptions.Item("font"))
            Catch
                oFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.Title)
            End Try
            sText = modXML.GetAttributeValue(ScaleOptions, "text", "")
            bHideScaleValue = modXML.GetAttributeValue(ScaleOptions, "hidescalevalue", False)
        End Sub

        Friend Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLScaleOptions As XmlElement = Document.CreateElement("scaleoptions")
            Call oXMLScaleOptions.SetAttribute("meters", iMeters)
            Call oXMLScaleOptions.SetAttribute("steps", iSteps)
            Call oXMLScaleOptions.SetAttribute("step", iStep)
            Call oFont.SaveTo(File, Document, oXMLScaleOptions, "font")
            Call oXMLScaleOptions.SetAttribute("color", oColor.ToArgb)
            If sText <> "" Then
                Call oXMLScaleOptions.SetAttribute("text", sText)
            End If
            If bHideScaleValue Then
                Call oXMLScaleOptions.SetAttribute("hidescalevalue", "1")
            End If
            Call Parent.AppendChild(oXMLScaleOptions)
            Return oXMLScaleOptions
        End Function

        'Private Sub oFont_OnChanged(ByVal Sender As cItemFont) Handles oFont.OnChanged
        '    RaiseEvent OnChange(Me)
        'End Sub
    End Class
End Namespace
