Imports cSurveyPC.cSurvey.Design.Options
Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design
    Public Class cOptionsExport
        Inherits cOptionsCenterline
        Implements cIOptionsPreview

        Private iAdvancedClippingMode As cIOptionsPreview.AdvancedClippingModeEnum
        Private sFileFormat As String

        Private sImageWidth As Single
        Private sImageHeight As Single
        Private sImageUnit As String

        Private iDPI As Integer
        Private WithEvents oMargins As cMargins

        Private bTransparentBackground As Boolean

        Private iScaleMode As cIOptionsPreview.ScaleModeEnum
        Private iScale As Integer

        Private oGPS As cGPSOptions

        Public Property ScaleMode() As cIOptionsPreview.ScaleModeEnum Implements cIOptionsPreview.ScaleMode
            Get
                Return iScaleMode
            End Get
            Set(ByVal value As cIOptionsPreview.ScaleModeEnum)
                If iScaleMode <> value Then
                    iScaleMode = value
                    Call PropertyChanged("ScaleMode")
                End If
            End Set
        End Property

        Public Property Scale() As Integer Implements cIOptionsPreview.Scale
            Get
                Return iScale
            End Get
            Set(ByVal value As Integer)
                If iScale <> value Then
                    iScale = value
                    Call PropertyChanged("Scale")
                End If
            End Set
        End Property

        Public ReadOnly Property GPS As cGPSOptions
            Get
                Return oGPS
            End Get
        End Property

        Public Property Margins As cMargins
            Get
                Return oMargins
            End Get
            Set(ByVal value As cMargins)
                If oMargins <> value Then
                    oMargins = value
                    Call PropertyChanged("Margins")
                End If
            End Set
        End Property

        Public Property DPI As Integer
            Get
                Return iDPI
            End Get
            Set(ByVal value As Integer)
                If iDPI <> value AndAlso value > 10 Then
                    iDPI = value
                    Call PropertyChanged("DPI")
                End If
            End Set
        End Property

        Public Property ImageUnit As String
            Get
                Return sImageUnit
            End Get
            Set(value As String)
                Dim svalue As String = value.ToLower.Trim
                Dim sNewImageUnit As String
                Select Case svalue
                    Case "mm"
                        sNewImageUnit = "mm"
                    Case "cm"
                        sNewImageUnit = "cm"
                    Case "in", "inch"
                        sNewImageUnit = "in"
                    Case Else
                        sNewImageUnit = "px"
                End Select
                If sNewImageUnit <> sImageUnit Then
                    sImageUnit = sNewImageUnit
                    Call PropertyChanged("ImageUnit")
                End If
            End Set
        End Property

        Public Property ImageWidth As Single
            Get
                Return sImageWidth
            End Get
            Set(ByVal value As Single)
                If sImageWidth <> value Then
                    sImageWidth = value
                    Call PropertyChanged("ImageWidth")
                End If
            End Set
        End Property

        Public Property ImageHeight As Single
            Get
                Return sImageHeight
            End Get
            Set(ByVal value As Single)
                If sImageHeight <> value Then
                    sImageHeight = value
                    Call PropertyChanged("ImageHeight")
                End If
            End Set
        End Property

        Public Property FileFormat() As String
            Get
                Return sfileformat
            End Get
            Set(ByVal value As String)
                If sFileFormat <> value Then
                    sFileFormat = value
                    Call PropertyChanged("FileFormat")
                End If
            End Set
        End Property

        Public Property TransparentBackground As Boolean
            Get
                Return bTransparentBackground
            End Get
            Set(ByVal value As Boolean)
                If bTransparentBackground <> value Then
                    bTransparentBackground = value
                    Call PropertyChanged("TransparentBackground")
                End If
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
            Call oXMLOptions.SetAttribute("margins", oMargins.ToString)

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
            oMargins = New cMargins(32, 32, 32, 32)
            sFileFormat = "JPG"
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
            oMargins = New cMargins(modXML.GetAttributeValue(Options, "margins", "32;32;32;32"))
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
            oMargins = New cMargins(modXML.GetAttributeValue(Options, "margins", "32;32;32;32"))
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

        Private Sub oMargins_OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Handles oMargins.OnPropertyChanged
            Call PropertyChanged("Margins." & e.Name)
        End Sub

        Public Property AdvancedClippingMode As cIOptionsPreview.AdvancedClippingModeEnum Implements cIOptionsPreview.AdvancedClippingMode
            Get
                Return iAdvancedClippingMode
            End Get
            Set(value As cIOptionsPreview.AdvancedClippingModeEnum)
                If iAdvancedClippingMode <> value Then
                    iAdvancedClippingMode = value
                    Call PropertyChanged("AdvancedClippingMode")
                End If
            End Set
        End Property
    End Class
End Namespace