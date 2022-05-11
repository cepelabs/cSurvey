Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design
    Public Class cOptionsPreview
        Inherits cOptions
        Implements cIOptionsPreview

        Private iAdvancedClippingMode As cIOptionsPreview.AdvancedClippingModeEnum
        Private sPrinterName As String

        Private bPageLandScape As Boolean
        Private oPageMargins As Drawing.Printing.Margins
        Private sPageformat As String

        Private iScaleMode As cIOptionsPreview.ScaleModeEnum
        Private iScale As Integer

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

        Public Property PageMargins As Drawing.Printing.Margins
            Get
                Return oPageMargins
            End Get
            Set(ByVal value As Drawing.Printing.Margins)
                oPageMargins = value
            End Set
        End Property

        Public Property PageFormat() As String
            Get
                Return sPageformat
            End Get
            Set(ByVal value As String)
                sPageformat = value
            End Set
        End Property

        Public Property PageLandscape() As Boolean
            Get
                Return bPageLandScape
            End Get
            Set(ByVal value As Boolean)
                bPageLandScape = value
            End Set
        End Property

        Public Property PrinterName() As String
            Get
                Return sPrinterName
            End Get
            Set(ByVal value As String)
                sPrinterName = value
            End Set
        End Property

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLOptions As XmlElement = MyBase.SaveTo(File, Document, Parent)
            Call oXMLOptions.SetAttribute("printername", sPrinterName)
            If bPageLandScape Then
                Call oXMLOptions.SetAttribute("pagelandscape", 1)
            End If
            Dim oConverter As Drawing.Printing.MarginsConverter = New Drawing.Printing.MarginsConverter
            Call oXMLOptions.SetAttribute("pagemargins", oConverter.ConvertToString(oPageMargins))
            Call oXMLOptions.SetAttribute("pageformat", sPageformat)

            Call oXMLOptions.SetAttribute("scalemode", iScaleMode)
            Call oXMLOptions.SetAttribute("scale", iScale)

            Call oXMLOptions.SetAttribute("advancedclippingmode", iAdvancedClippingMode)

            'Call oXMLOptions.SetAttribute("drawsolidrock", If(bDrawSolidRock, 1, 0))

            'If bUseDrawingZOrder Then
            '    Call oXMLOptions.SetAttribute("usedrawingzorder", "1")
            'End If
            Return oXMLOptions
        End Function

        Public Overrides Sub Import(Options As XmlElement)
            Call MyBase.Import(Options)
            sPrinterName = modXML.GetAttributeValue(Options, "printername")
            bPageLandScape = modXML.GetAttributeValue(Options, "pagelandscape", False)
            Dim oConverter As Drawing.Printing.MarginsConverter = New Drawing.Printing.MarginsConverter
            Dim oPageMarginsData() As String = modXML.GetAttributeValue(Options, "pagemargins", "10;10;10;10").Split({";"c, ","c})
            oPageMargins = New Drawing.Printing.Margins(oPageMarginsData(0), oPageMarginsData(1), oPageMarginsData(2), oPageMarginsData(3))
            sPageformat = modXML.GetAttributeValue(Options, "pageformat")
            iScaleMode = modXML.GetAttributeValue(Options, "scalemode")
            iScale = modXML.GetAttributeValue(Options, "scale")
            iAdvancedClippingMode = modXML.GetAttributeValue(Options, "advancedclippingmode")
            'bDrawSolidRock = modXML.GetAttributeValue(Options, "drawsolidrock", False)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Name As String)
            Call MyBase.New(Survey, Name, cIOptions.ModeEnum.Preview)
            sPrinterName = ""
            CompassStyle = CompassStyleEnum.Advanced
            ScaleStyle = ScaleStyleEnum.Advanced
            oPageMargins = New Drawing.Printing.Margins
            'bDrawSolidRock = False
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Options As XmlElement)
            Call MyBase.New(Survey, Options, cIOptions.ModeEnum.Preview)
            CompassStyle = CompassStyleEnum.Advanced
            ScaleStyle = ScaleStyleEnum.Advanced
            sPrinterName = modXML.GetAttributeValue(Options, "printername", "")
            bPageLandScape = modXML.GetAttributeValue(Options, "pagelandscape")
            'Dim oConverter As Drawing.Printing.MarginsConverter = New Drawing.Printing.MarginsConverter
            'oPageMargins = oConverter.ConvertFromString(modXML.GetAttributeValue(Options, "pagemargins"))
            'If oPageMargins Is Nothing Then oPageMargins = New Drawing.Printing.Margins(10, 10, 10, 10)
            Dim oPageMarginsData() As String = modXML.GetAttributeValue(Options, "pagemargins", "10;10;10;10").Split({";"c,","c})
            oPageMargins = New Drawing.Printing.Margins(oPageMarginsData(0), oPageMarginsData(1), oPageMarginsData(2), oPageMarginsData(3))
            sPageformat = modXML.GetAttributeValue(Options, "pageformat")
            iScaleMode = modXML.GetAttributeValue(Options, "scalemode")
            iScale = modXML.GetAttributeValue(Options, "scale")
            iAdvancedClippingMode = modXML.GetAttributeValue(Options, "advancedclippingmode")
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
