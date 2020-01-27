Imports cSurveyPC.cSurvey.Design.Options
Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design
    Public Class cOptionsExport
        Inherits cOptions
        Implements cIOptionsPreview

        Private iAdvancedClippingMode As cIOptionsPreview.AdvancedClippingModeEnum
        Private sfileformat As String

        Private iImageWidth As Integer
        Private iImageHeight As Integer
        Private iDPIx As Integer
        Private iDPIy As Integer
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

        Public Property DPIy As Integer
            Get
                Return iDPIy
            End Get
            Set(ByVal value As Integer)
                iDPIy = value
            End Set
        End Property

        Public Property DPIx As Integer
            Get
                Return iDPIx
            End Get
            Set(ByVal value As Integer)
                iDPIx = value
            End Set
        End Property

        Public Property ImageWidth As Integer
            Get
                Return iImageWidth
            End Get
            Set(ByVal value As Integer)
                iImageWidth = value
            End Set
        End Property

        Public Property ImageHeight As Integer
            Get
                Return iImageHeight
            End Get
            Set(ByVal value As Integer)
                iImageHeight = value
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

        Friend Overrides Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLOptions As XmlElement = MyBase.SaveTo(File, Document, Parent)

            Call oXMLOptions.SetAttribute("fileformat", sfileformat)
            Call oXMLOptions.SetAttribute("imagewidth", iImageWidth)
            Call oXMLOptions.SetAttribute("imageheight", iImageHeight)
            Call oXMLOptions.SetAttribute("dpix", iDPIx)
            Call oXMLOptions.SetAttribute("dpiy", iDPIy)

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
            iImageWidth = 4096
            iImageHeight = 3072
            iDPIx = 96
            iDPIy = 96
            bTransparentBackground = False
            oMargins = New Drawing.Printing.Margins(32, 32, 32, 32)
            sfileformat = "JPG"
            oGPS = New cGPSOptions
            'bDrawSolidRock = False
        End Sub

        Public Overrides Sub Import(Options As XmlElement)
            Call MyBase.Import(Options)
            sfileformat = modXML.GetAttributeValue(Options, "fileformat")
            iImageWidth = modXML.GetAttributeValue(Options, "imagewidth")
            iImageHeight = modXML.GetAttributeValue(Options, "imageheight")
            iDPIx = modXML.GetAttributeValue(Options, "dpix")
            iDPIy = modXML.GetAttributeValue(Options, "dpiy")
            If iImageWidth = 0 Then
                iImageWidth = 4096
            End If
            If iImageHeight = 0 Then
                iImageHeight = 3072
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
            iImageWidth = modXML.GetAttributeValue(Options, "imagewidth")
            iImageHeight = modXML.GetAttributeValue(Options, "imageheight")
            iDPIx = modXML.GetAttributeValue(Options, "dpix")
            iDPIy = modXML.GetAttributeValue(Options, "dpiy")
            If iImageWidth = 0 Then
                iImageWidth = 4096
            End If
            If iImageHeight = 0 Then
                iImageHeight = 3072
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