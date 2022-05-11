Imports System.Drawing.Printing

friend Class frmPreviewMargins
    Public Margins As Drawing.Printing.Margins

    Public Sub ConvertToMillimeter()
        Margins = PrinterUnitConvert.Convert(Margins, PrinterUnit.ThousandthsOfAnInch, PrinterUnit.TenthsOfAMillimeter)
    End Sub

    Public Sub ConvertToThousandthsOfAnInch()
        Margins = PrinterUnitConvert.Convert(Margins, PrinterUnit.TenthsOfAMillimeter, PrinterUnit.ThousandthsOfAnInch)
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error Resume Next
        Margins.Left = txtLeft.Text
        Margins.Top = txtTop.Text
        Margins.Right = txtRight.Text
        Margins.Bottom = txtBottom.Text
    End Sub

    Private Sub frmPreviewMargins_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtLeft.Text = Margins.Left
        txtTop.Text = Margins.Top
        txtRight.Text = Margins.Right
        txtBottom.Text = Margins.Bottom
    End Sub

    Public Sub New(Optional ByVal UnitText As String = "mm")
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Call ChangeUnitText(UnitText)
    End Sub

    Public Sub ChangeUnitText(ByVal UnitText As String)
        frmMargins.Text = GetLocalizedString("previewmargin.textpart1") & " (" & UnitText & "):"
    End Sub
End Class