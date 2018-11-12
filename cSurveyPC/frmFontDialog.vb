Imports cSurveyPC.cSurvey

Public Class frmFontDialog

    Private oFont As cIFont

    Private bDisabledEvent As Boolean

    Public Sub New(ByVal Font As cIFont)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        bDisabledEvent = True
        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Dim oFonts As System.Drawing.Text.InstalledFontCollection = New System.Drawing.Text.InstalledFontCollection
        For Each oFontFamily As FontFamily In oFonts.Families
            Call cboFontChar.Items.Add(oFontFamily.Name)
        Next

        oFont = Font.Clone

        cboFontChar.Text = oFont.FontName
        chkFontBold.Checked = oFont.FontBold
        chkFontItalic.Checked = oFont.FontItalic
        chkFontUnderline.Checked = oFont.FontUnderline
        cboFontSize.Text = oFont.FontSize

        bDisabledEvent = False

        Call pDrawPreview()
    End Sub

    Public ReadOnly Property CurrentFont As cIFont
        Get
            Return oFont
        End Get
    End Property

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Call Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Call Close()
    End Sub

    Private Sub cboFontChar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFontChar.SelectedIndexChanged
        Call pDrawPreview()
    End Sub

    Private Sub pDrawPreview()
        If Not bDisabledEvent Then
            Try
                oFont.FontName = cboFontChar.Text
                oFont.FontBold = chkFontBold.Checked
                oFont.FontItalic = chkFontItalic.Checked
                oFont.FontUnderline = chkFontUnderline.Checked
                oFont.FontSize = cboFontSize.Text
                Dim sText As String = "AbCdEfGhIi"
                Using oGraphics As Graphics = pnlPreview.CreateGraphics
                    'oGraphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                    'oGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    'oGraphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
                    Call oGraphics.Clear(Color.White)
                    Dim oSF As StringFormat = New StringFormat
                    oSF.Alignment = StringAlignment.Center
                    oSF.LineAlignment = StringAlignment.Center
                    oSF.FormatFlags = StringFormatFlags.NoWrap
                    Call oGraphics.DrawString(sText, oFont.GetSampleFont, Brushes.Black, pnlPreview.ClientRectangle, oSF)
                    Call oSF.Dispose()
                End Using
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub chkFontBold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFontBold.CheckedChanged
        Call pDrawPreview()
    End Sub

    Private Sub chkFontItalic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFontItalic.CheckedChanged
        Call pDrawPreview()
    End Sub

    Private Sub chkFontUnderline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFontUnderline.CheckedChanged
        Call pDrawPreview()
    End Sub

    Private Sub pnlPreview_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlPreview.Paint
        Call pDrawPreview()
    End Sub

    Private Sub cboFontSize_TextChanged(sender As Object, e As System.EventArgs) Handles cboFontSize.TextChanged
        Call pDrawPreview()
    End Sub
End Class