Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design
    Public Class cOptionsPreview
        Inherits cOptionsCenterline
        Implements cIOptionsPreview

        Private iAdvancedClippingMode As cIOptionsPreview.AdvancedClippingModeEnum
        Private sPrinterName As String

        Private bPageLandScape As Boolean
        Private WithEvents oPageMargins As cMargins
        Private sPageformat As String

        Private iScaleMode As cIOptionsPreview.ScaleModeEnum
        Private iScale As Integer

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

        Public Property PageMargins As cMargins
            Get
                Return oPageMargins
            End Get
            Set(ByVal value As cMargins)
                If oPageMargins <> value Then
                    oPageMargins = value
                    Call PropertyChanged("PageMargins")
                End If
            End Set
        End Property

        Public Property PageFormat() As String
            Get
                Return sPageformat
            End Get
            Set(ByVal value As String)
                If sPageformat <> value Then
                    sPageformat = value
                    Call PropertyChanged("PageFormat")
                End If
            End Set
        End Property

        Public Property PageLandscape() As Boolean
            Get
                Return bPageLandScape
            End Get
            Set(ByVal value As Boolean)
                If bPageLandScape <> value Then
                    bPageLandScape = value
                    Call PropertyChanged("PageLandscape")
                End If
            End Set
        End Property

        Public Property PrinterName() As String
            Get
                Return sPrinterName
            End Get
            Set(ByVal value As String)
                If sPrinterName <> value Then
                    sPrinterName = value
                    Call PropertyChanged("PrinterName")
                End If
            End Set
        End Property

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLOptions As XmlElement = MyBase.SaveTo(File, Document, Parent)
            Call oXMLOptions.SetAttribute("printername", sPrinterName)
            If bPageLandScape Then
                Call oXMLOptions.SetAttribute("pagelandscape", 1)
            End If
            Call oXMLOptions.SetAttribute("pagemargins", oPageMargins.ToString)
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
            oPageMargins = New cMargins(modXML.GetAttributeValue(Options, "pagemargins", "10;10;10;10"))
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
            oPageMargins = New cMargins(10, 10, 10, 10)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Options As XmlElement)
            Call MyBase.New(Survey, Options, cIOptions.ModeEnum.Preview)
            CompassStyle = CompassStyleEnum.Advanced
            ScaleStyle = ScaleStyleEnum.Advanced
            sPrinterName = modXML.GetAttributeValue(Options, "printername", "")
            bPageLandScape = modXML.GetAttributeValue(Options, "pagelandscape")
            oPageMargins = New cMargins(modXML.GetAttributeValue(Options, "pagemargins", "10;10;10;10"))
            sPageformat = modXML.GetAttributeValue(Options, "pageformat")
            iScaleMode = modXML.GetAttributeValue(Options, "scalemode")
            iScale = modXML.GetAttributeValue(Options, "scale")
            iAdvancedClippingMode = modXML.GetAttributeValue(Options, "advancedclippingmode")
            'bDrawSolidRock = modXML.GetAttributeValue(Options, "drawsolidrock", False)
        End Sub

        Private Sub oPageMargins_OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Handles oPageMargins.OnPropertyChanged
            Call PropertyChanged("PageMargins." & e.Name)
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
