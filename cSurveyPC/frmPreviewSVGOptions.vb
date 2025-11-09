Imports System.Drawing.Printing
Imports cSurveyPC.cSurvey.Design

Friend Class frmPreviewSVGOptions
    Private oSVGOptions As cSVGOptions

    'Public Sub ConvertToMillimeter()
    '    Margins = PrinterUnitConvert.Convert(Margins, PrinterUnit.ThousandthsOfAnInch, PrinterUnit.TenthsOfAMillimeter)
    'End Sub

    'Public Sub ConvertToThousandthsOfAnInch()
    '    Margins = PrinterUnitConvert.Convert(Margins, PrinterUnit.TenthsOfAMillimeter, PrinterUnit.ThousandthsOfAnInch)
    'End Sub

    Private bEventDisabled As Boolean

    Public Sub New(SVGOptions As cSVGOptions)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        bEventDisabled = True
        oSVGOptions = SVGOptions

        bEventDisabled = False
    End Sub

End Class