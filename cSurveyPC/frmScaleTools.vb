Imports System.Drawing.Printing

friend Class frmScaleTools
    Private oSurvey As cSurvey.cSurvey
    Private oDesign As cSurvey.Design.cDesign
    Private oPaintOptions As cSurvey.Design.cOptions
    Private bTranslation As Boolean

    Private iMode As ScaleToolsModeEnum
    Private sCurrentPrinter As String
    Private oCurrentGraphics As Graphics

    Public Enum ScaleToolsModeEnum
        Print = 0
        Export = 1
    End Enum

    Private Function pGetCompatiblePapers(ByVal Rectangle As RectangleF, ByVal Portrait As Boolean) As List(Of PaperSize)
        Dim oItems As List(Of PaperSize) = New List(Of PaperSize)
        Dim oPrinterSettings As PrinterSettings = New PrinterSettings
        For Each oPaperSize As PaperSize In oPrinterSettings.PaperSizes
            Dim oPaperRect As RectangleF
            Dim sPageWidth As Single = PrinterUnitConvert.Convert(oPaperSize.Width / 10, PrinterUnit.ThousandthsOfAnInch, PrinterUnit.TenthsOfAMillimeter) / 100
            Dim sPageHeight As Single = PrinterUnitConvert.Convert(oPaperSize.Height / 10, PrinterUnit.ThousandthsOfAnInch, PrinterUnit.TenthsOfAMillimeter) / 100
            If Portrait Then
                oPaperRect = New RectangleF(0, 0, sPageWidth, sPageHeight)
            Else
                oPaperRect = New RectangleF(0, 0, sPageHeight, sPageWidth)
            End If
            If oPaperRect.Contains(Rectangle) Then
                Call oItems.Add(oPaperSize)
            End If
        Next
        Return oItems
    End Function

    Private Sub cmdCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculate.Click
        Call pCalculate()
    End Sub

    Private Sub pCalculate()
        Call lv.Groups.Clear()
        Call lv.Items.Clear()

        Call lv.Groups.Add("source", GetLocalizedString("scaletools.textpart1"))
        Dim oRect As RectangleF = oDesign.GetVisibleBounds(oPaintOptions)
        Call pScaleAddDetailInfo("source", GetLocalizedString("scaletools.textpart2"), Strings.Format(oRect.Width, "#,##0.00") & " m")
        Call pScaleAddDetailInfo("source", GetLocalizedString("scaletools.textpart3"), Strings.Format(oRect.Height, "#,##0.00") & " m")
        Dim sScale As Single = txtScale.Value
        Dim sScaleGroup As String = GetLocalizedString("scaletools.textpart4") & " 1:" & Strings.Format(sScale, "0")
        Dim sWidth As Single = oRect.Width / sScale
        Dim sHeight As Single = oRect.Height / sScale
        Dim sUnit As String
        Dim oScaledRect As RectangleF = New RectangleF(0, 0, sWidth, sHeight)
        If sWidth < 1 Or sHeight < 1 Then
            sWidth = sWidth * 100
            sHeight = sHeight * 100
            sUnit = "cm"
        Else
            sUnit = "m"
        End If
        Call lv.Groups.Add("scaled", sScaleGroup)
        Call pScaleAddDetailInfo("scaled", GetLocalizedString("scaletools.textpart2"), Strings.Format(sWidth, "#,##0.00") & " " & sUnit)
        Call pScaleAddDetailInfo("scaled", GetLocalizedString("scaletools.textpart3"), Strings.Format(sHeight, "#,##0.00") & " " & sUnit)
        If Not oScaledRect.IsEmpty Then
            Dim sRatio As Single = oScaledRect.Width / oScaledRect.Height
            Call pScaleAddDetailInfo("scaled", GetLocalizedString("scaletools.textpart5"), Strings.Format(sRatio, "0.00"))
            Dim bPortrait As Boolean = sRatio > 1
            Call pScaleAddDetailInfo("scaled", GetLocalizedString("scaletools.textpart6"), IIf(bPortrait, GetLocalizedString("scaletools.textpart6a"), GetLocalizedString("scaletools.textpart6b")))

            Select Case iMode
                Case ScaleToolsModeEnum.Export
                    Call lv.Groups.Add("screen", GetLocalizedString("scaletools.textpart7"))
                    Dim sDPI As Single
                    sDPI = 90
                    Dim sPageWidth As Single
                    Dim sPageHeight As Single
                    sPageWidth = modPaint.MillimetersToPixel(sDPI, oScaledRect.Width * 1000)
                    sPageHeight = modPaint.MillimetersToPixel(sDPI, oScaledRect.Height * 1000)
                    Call pScaleAddDetailInfo("screen", sDPI & " dpi", Strings.Format(sPageWidth, "#,##0") & " x " & Strings.Format(sPageHeight, "#,##0") & " px")
                    sDPI = oCurrentGraphics.DpiX
                    sPageWidth = modPaint.MillimetersToPixel(sDPI, oScaledRect.Width * 1000)
                    sPageHeight = modPaint.MillimetersToPixel(sDPI, oScaledRect.Height * 1000)
                    Call pScaleAddDetailInfo("screen", sDPI & " dpi", Strings.Format(sPageWidth, "#,##0") & " x " & Strings.Format(sPageHeight, "#,##0") & " px")
                Case ScaleToolsModeEnum.Print
                    Call lv.Groups.Add("paper", GetLocalizedString("scaletools.textpart8"))
                    Dim oCompatiblePapers As List(Of PaperSize) = pGetCompatiblePapers(oScaledRect, bPortrait)
                    For Each oPaperSize As PaperSize In oCompatiblePapers
                        Dim sPageWidth As Single = PrinterUnitConvert.Convert(oPaperSize.Width / 10, PrinterUnit.ThousandthsOfAnInch, PrinterUnit.TenthsOfAMillimeter) '/ 100
                        Dim sPageHeight As Single = PrinterUnitConvert.Convert(oPaperSize.Height / 10, PrinterUnit.ThousandthsOfAnInch, PrinterUnit.TenthsOfAMillimeter) '/ 100
                        Call pScaleAddDetailInfo("paper", oPaperSize.PaperName, Strings.Format(sPageWidth, "#,##0.0") & " x " & Strings.Format(sPageHeight, "#,##0.0") & " cm")
                    Next
            End Select
        Else
            'boh...per ora non ci metto nulla...
        End If
    End Sub

    Private Sub pScaleAddDetailInfo(ByVal Group As String, ByVal Name As String, ByVal Value As String)
        Dim oItem As ListViewItem = lv.Items.Add(Name)
        Call oItem.SubItems.Add(Value)
        oItem.Group = lv.Groups(Group)
        'oItem.IndentCount = 1
    End Sub

    Public Sub New(ByVal Survey As cSurvey.cSurvey, ByVal Design As cSurvey.Design.cDesign, ByVal PaintOptions As cSurvey.Design.cOptions, ByVal CurrentScale As Integer, ByVal CurrentPrinter As String)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey
        oDesign = Design
        oPaintOptions = PaintOptions

        txtScale.Value = CurrentScale

        iMode = ScaleToolsModeEnum.Print
        sCurrentPrinter = CurrentPrinter

        Call pCalculate()
    End Sub

    Public Sub New(ByVal Survey As cSurvey.cSurvey, ByVal Design As cSurvey.Design.cDesign, ByVal PaintOptions As cSurvey.Design.cOptions, ByVal CurrentScale As Integer, ByVal CurrentGraphics As Graphics)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey
        oDesign = Design
        oPaintOptions = PaintOptions

        txtScale.Value = CurrentScale

        iMode = ScaleToolsModeEnum.Export
        oCurrentGraphics = CurrentGraphics

        Call pCalculate()
    End Sub
End Class