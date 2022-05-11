Imports cSurveyPC.cSurvey.Design.Options
Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design
    Public Class cOptionsExport
        Inherits cOptions
        Implements cIOptionsPreview

        Private iAdvancedClippingMode As cIOptionsPreview.AdvancedClippingModeEnum
        Private sFileFormat As String

        Private sImageWidth As Single
        Private sImageHeight As Single
        Private sImageUnit As String

        Private iDPI As Integer
        Private oMargins As Drawing.Printing.Margins

        Private bTransparentBackground As Boolean

        Private iScaleMode As cIOptionsPreview.ScaleModeEnum
        Private iScale As Integer

        Private oGPS As cGPSOptions

        'Private bDrawSolidRock As Boolean

        'Public Overridable Property DrawSolidRock As Boolean Implements cIOptionsPreview.DrawSolidRock
        '    Get
        '        Return bDrawSolidRock
        '    End Get
        '    Set(value As Boolean)
        '        bDrawSolidRock = value
        '    End Set
        'End Property

        Public Property ScaleMode() As cIOptionsPreview.ScaleModeEnum Implements cIOptionsPreview.ScaleMode
            Get
                Return iScaleMode
            End Get
            Set(ByVal value As cIOptionsPreview.ScaleModeEnum)
                iScaleMode = value
            End Set
        End Property

        Public Property Scale() As Integer Implements cIOptionsPreview.Scale
            Get
                Return iScale
            End Get
            Set(ByVal value As Integer)
                iScale = value
            End Set
        End Property

        Public ReadOnly Property GPS As cGPSOptions
            Get
                Return oGPS
            End Get
        End Property

        Public Property Margins As Drawing.Printing.Margins
            Get
                Return oMargins
            End Get
            Set(ByVal value As Drawing.Printing.Margins)
                oMargins = value
            End Set
        End Property

        Public Property DPI As Integer
            Get
                Return iDPI
            End Get
            Set(ByVal value As Integer)
                If iDPI <> value AndAlso value > 10 Then
                    iDPI = value
                End If
            End Set
        End Property

        Public Property ImageUnit As String
            Get
                Return sImageUnit
            End Get
            Set(value As String)
                Dim svalue As String = value.ToLower.Trim
                Select Case svalue
                    Case "mm"
                        sImageUnit = "mm"
                    Case "cm"
                        sImageUnit = "cm"
                    Case "in", "inch"
                        sImageUnit = "in"
                    Case Else
                        sImageUnit = "px"
                End Select
                sImageUnit = value
            End Set
        End Property

        Public Property ImageWidth As Single
            Get
                Return sImageWidth
            End Get
            Set(ByVal value As Single)
                sImageWidth = value
            End Set
        End Property

        Public Property ImageHeight As Single
            Get
                Return sImageHeight
            End Get
            Set(ByVal value As Single)
                sImageHeight = value
            End Set
        End Property

        Public Property FileFormat() As String
            Get
                Return sfileformat
            End Get
            Set(ByVal value As String)
                sfileformat = value
            End Set
        End Property

        Public Property TransparentBackground As Boolean
            Get
                Return bTransparentBackground
            End Get
            Set(ByVal value As Boolean)
                bTransparentBackground = value
            End Set
        End Property

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLOptions As XmlElement = MyBase.SaveTo(File, Document, Parent)

            Call oXMLOptions.SetAttribute("fileformat", sfileformat)
            Call oXMLOptions.SetAttribute("imagewidth", modNumbers.NumberToString(sImageWidth, ""))
            Call oXMLOptions.SetAttribute("imageheight", modNumbers.NumberToString(sImageHeight, ""))
            If sImageUnit <> "px" Then Call oXMLOptions.SetAttribute("imageunit", sImageUnit)
            If iDPI <> 96 Then Call oXMLOptions.SetAttribute("dpi", iDPI)

            If bTransparentBackground Then Call oXMLOptions.SetAttribute("transparentbackground", 1)

            Dim oConverter As Drawing.Printing.MarginsConverter = New Drawing.Printing.MarginsConverter
            Call oXMLOptions.SetAttribute("margins", oConverter.ConvertToString(oMargins))

            Call oXMLOptions.SetAttribute("scalemode", iScaleMode)
            Call oXMLOptions.SetAttribute("scale", iScale)

            Call oXMLOptions.SetAttribute("advancedclippingmode", iAdvancedClippingMode)

            Call oGPS.SaveTo(File, Document, oXMLOptions, "gps")

            'Call oXMLOptions.SetAttribute("drawsolidrock", IIf(bDrawSolidRock, 1, 0))

            Return oXMLOptions
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Name As String)
            Call MyBase.New(Survey, Name, cIOptions.ModeEnum.Preview)
            CompassStyle = CompassStyleEnum.Advanced
            ScaleStyle = ScaleStyleEnum.Advanced
            sImageWidth = 4096.0F
            sImageHeight = 3072.0F
            sImageUnit = "px"
            iDPI = 96
            bTransparentBackground = False
            oMargins = New Drawing.Printing.Margins(32, 32, 32, 32)
            sfileformat = "JPG"
            oGPS = New cGPSOptions
            'bDrawSolidRock = False
        End Sub

        Public Overrides Sub Import(Options As XmlElement)
            Call MyBase.Import(Options)
            sfileformat = modXML.GetAttributeValue(Options, "fileformat")
            sImageWidth = modXML.GetAttributeValue(Options, "imagewidth")
            sImageHeight = modXML.GetAttributeValue(Options, "imageheight")
            sImageUnit = modXML.GetAttributeValue(Options, "imageunit")
            iDPI = modXML.GetAttributeValue(Options, "dpi", 96)
            If sImageWidth = 0F Then
                sImageWidth = 4096.0F
            End If
            If sImageHeight = 0F Then
                sImageHeight = 3072.0F
            End If
            bTransparentBackground = modXML.GetAttributeValue(Options, "transparentbackground", 0)
            Dim oConverter As Drawing.Printing.MarginsConverter = New Drawing.Printing.MarginsConverter
            Try : oMargins = oConverter.ConvertFromString(modXML.GetAttributeValue(Options, "margins")) : Catch : End Try
            If oMargins Is Nothing Then oMargins = New Drawing.Printing.Margins(32, 32, 32, 32)
            iScaleMode = modXML.GetAttributeValue(Options, "scalemode")
            iScale = modXML.GetAttributeValue(Options, "scale")
            iAdvancedClippingMode = modXML.GetAttributeValue(Options, "advancedclippingmode")
            If modXML.ChildElementExist(Options, "gps") Then
                oGPS = New cGPSOptions(Options.Item("gps"))
            Else
                oGPS = New cGPSOptions
            End If
            'bDrawSolidRock = modXML.GetAttributeValue(Options, "drawsolidrock", False)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Options As XmlElement)
            Call MyBase.New(Survey, Options, cIOptions.ModeEnum.Preview)
            CompassStyle = CompassStyleEnum.Advanced
            ScaleStyle = ScaleStyleEnum.Advanced
            sfileformat = modXML.GetAttributeValue(Options, "fileformat")
            sImageWidth = modXML.GetAttributeValue(Options, "imagewidth")
            sImageHeight = modXML.GetAttributeValue(Options, "imageheight")
            sImageUnit = modXML.GetAttributeValue(Options, "imageunit", "px")
            iDPI = modXML.GetAttributeValue(Options, "dpi", 96)
            If sImageWidth = 0F Then
                sImageWidth = 4096.0F
            End If
            If sImageHeight = 0F Then
                sImageHeight = 3072.0F
            End If
            bTransparentBackground = modXML.GetAttributeValue(Options, "transparentbackground")
            Dim oConverter As Drawing.Printing.MarginsConverter = New Drawing.Printing.MarginsConverter
            Try : oMargins = oConverter.ConvertFromString(modXML.GetAttributeValue(Options, "margins")) : Catch : End Try
            If oMargins Is Nothing Then oMargins = New Drawing.Printing.Margins(32, 32, 32, 32)
            iScaleMode = modXML.GetAttributeValue(Options, "scalemode")
            iScale = modXML.GetAttributeValue(Options, "scale")
            iAdvancedClippingMode = modXML.GetAttributeValue(Options, "advancedclippingmode")
            If modXML.ChildElementExist(Options, "gps") Then
                oGPS = New cGPSOptions(Options.Item("gps"))
            Else
                oGPS = New cGPSOptions
            End If
            'bDrawSolidRock = modXML.GetAttributeValue(Options, "drawsolidrock", False)
        End Sub

        Public Property AdvancedClippingMode As cIOptionsPreview.AdvancedClippingModeEnum Implements cIOptionsPreview.AdvancedClippingMode
            Get
                Return iAdvancedClippingMode
            End Get
            Set(value As cIOptionsPreview.AdvancedClippingModeEnum)
                iAdvancedClippingMode = value
            End Set
        End Property
    End Class
End Namespace