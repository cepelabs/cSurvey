Imports System.Drawing.Printing
Imports cSurveyPC.cSurvey.Design

Friend Class frmPreviewMargins
    Private oMargins As cMargins

    'Public Sub ConvertToMillimeter()
    '    Margins = PrinterUnitConvert.Convert(Margins, PrinterUnit.ThousandthsOfAnInch, PrinterUnit.TenthsOfAMillimeter)
    'End Sub

    'Public Sub ConvertToThousandthsOfAnInch()
    '    Margins = PrinterUnitConvert.Convert(Margins, PrinterUnit.TenthsOfAMillimeter, PrinterUnit.ThousandthsOfAnInch)
    'End Sub

    Private bEventDisabled As Boolean

    Public Sub New(Margins As cMargins, Optional UnitText As String = "mm")
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Call pChangeUnitText(UnitText)

        bEventDisabled = True
        oMargins = Margins

        txtLeft.Text = oMargins.Left
        txtTop.Text = oMargins.Top
        txtRight.Text = oMargins.Right
        txtBottom.Text = oMargins.Bottom

        bEventDisabled = False
    End Sub

    Private Sub pChangeUnitText(ByVal UnitText As String)
        frmMargins.Text = GetLocalizedString("previewmargin.textpart1") & " (" & UnitText & "):"
    End Sub

    Private Sub txtTop_EditValueChanged(sender As Object, e As EventArgs) Handles txtTop.EditValueChanged
        If Not oMargins Is Nothing AndAlso Not bEventDisabled Then
            oMargins.Top = txtTop.EditValue
        End If
    End Sub

    Private Sub txtLeft_EditValueChanged(sender As Object, e As EventArgs) Handles txtLeft.EditValueChanged
        If Not oMargins Is Nothing AndAlso Not bEventDisabled Then
            oMargins.Left = txtLeft.EditValue
        End If
    End Sub

    Private Sub txtRight_EditValueChanged(sender As Object, e As EventArgs) Handles txtRight.EditValueChanged
        If Not oMargins Is Nothing AndAlso Not bEventDisabled Then
            oMargins.Right = txtRight.EditValue
        End If
    End Sub

    Private Sub txtBottom_EditValueChanged(sender As Object, e As EventArgs) Handles txtBottom.EditValueChanged
        If Not oMargins Is Nothing AndAlso Not bEventDisabled Then
            oMargins.Bottom = txtBottom.EditValue
        End If
    End Sub
End Class