Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Options
Imports cSurveyPC.cSurvey.Drawings
Imports DevExpress.XtraEditors.Controls

Friend Class frmParametersCompass
    Private oOptions As cOptionsCenterline
    Private oCompassOptions As cCompassOptions
    Private bDisabledEvent As Boolean

    Private Sub cmdCompassBrowseClipart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oOfd As OpenFileDialog = New OpenFileDialog
        With oOfd
            .Title = GetLocalizedString("parameterscompass.openclipartdialog")
            .Filter = GetLocalizedString("parameterscompass.filetypeSVG") & " (*.SVG)|*.SVG|" & GetLocalizedString("parameterscompass.filetypeALL") & " (*.*)|*.*"
            .FilterIndex = 1
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    Dim oClipart As cDrawClipArt = New cDrawClipArt(.FileName)
                    oCompassOptions.Clipart = oClipart
                    picCompassClipartImage.Image = oClipart.GetThumbnailImage(picCompassClipartImage.Width, picCompassClipartImage.Height)
                Catch
                    picCompassClipartImage.Image = Nothing
                End Try
            End If
        End With
    End Sub

    Public Sub New(ByVal Options As cOptionsCenterline)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent()
        oOptions = Options
        oCompassOptions = oOptions.CompassOptions

        bDisabledEvent = True
        txtCompassText.Text = oCompassOptions.Text

        If oCompassOptions.Font.FontName = "" Then
            cboCompassFontChar.EditValue = oCompassOptions.Font.FontName
        Else
            cboCompassFontChar.EditValue = oCompassOptions.Font.FontName
        End If
        chkCompassFontBold.Checked = oCompassOptions.Font.FontBold
        chkCompassFontItalic.Checked = oCompassOptions.Font.FontItalic
        chkCompassFontUnderline.Checked = oCompassOptions.Font.FontUnderline
        cboCompassFontSize.Text = oCompassOptions.Font.FontSize

        txtColor.EditValue = oCompassOptions.Color

        picCompassClipartImage.SvgImage = modDevExpress.SvgImageFromClipart(oCompassOptions.Clipart)
        picCompassClipartImage.Properties.OpenFileDialogFilter = GetLocalizedString("parameterscompass.filetypeSVG") & " (*.SVG)|*.SVG|" & GetLocalizedString("parameterscompass.filetypeALL") & " (*.*)|*.*"

        'picCompassClipartImage.Image = oCompassOptions.Clipart.GetThumbnailImage(picCompassClipartImage.Width, picCompassClipartImage.Height)
        txtCompassClipartZoomFactor.Value = oCompassOptions.ClipartZoomFactor

        bDisabledEvent = False
    End Sub

    Private Sub chkCompassFontBold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCompassFontBold.CheckedChanged
        Try
            If Not oCompassOptions Is Nothing AndAlso Not bDisabledEvent Then
                oCompassOptions.Font.FontBold = chkCompassFontBold.Checked
            End If
        Catch
        End Try
    End Sub

    Private Sub chkCompassFontItalic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCompassFontItalic.CheckedChanged
        Try
            If Not oCompassOptions Is Nothing AndAlso Not bDisabledEvent Then
                oCompassOptions.Font.FontItalic = chkCompassFontItalic.Checked
            End If
        Catch
        End Try
    End Sub

    Private Sub chkCompassFontUnderline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCompassFontUnderline.CheckedChanged
        Try
            If Not oCompassOptions Is Nothing AndAlso Not bDisabledEvent Then
                oCompassOptions.Font.FontUnderline = chkCompassFontUnderline.Checked
            End If
        Catch
        End Try
    End Sub

    Private Sub txtCompass_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCompassText.Validating
        Try
            If Not oCompassOptions Is Nothing AndAlso Not bDisabledEvent Then
                oCompassOptions.Text = txtCompassText.Text
            End If
        Catch
        End Try
    End Sub

    Private Sub cboCompassFontSize_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboCompassFontSize.ButtonClick
        If e.Button.Index = 1 Then
            cboCompassFontSize.EditValue = Nothing
        End If
    End Sub

    Private Sub cboCompassFontSize_EditValueChanged(sender As Object, e As EventArgs) Handles cboCompassFontSize.EditValueChanged
        Try
            If Not oCompassOptions Is Nothing AndAlso Not bDisabledEvent Then
                If cboCompassFontSize.EditValue Is Nothing Then
                    oCompassOptions.Font.FontSize = 0
                Else
                    oCompassOptions.Font.FontSize = cboCompassFontSize.EditValue
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub cboCompassFontChar_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboCompassFontChar.ButtonClick
        If e.Button.Index = 1 Then
            cboCompassFontChar.EditValue = Nothing
        End If
    End Sub

    Private Sub cboCompassFontChar_EditValueChanged(sender As Object, e As EventArgs) Handles cboCompassFontChar.EditValueChanged
        If Not oCompassOptions Is Nothing AndAlso Not bDisabledEvent Then
            If cboCompassFontChar.EditValue Is Nothing Then
                oCompassOptions.Font.FontName = ""
            Else
                oCompassOptions.Font.FontName = cboCompassFontChar.EditValue
            End If
        End If
    End Sub

    Private Sub picCompassClipartImage_EditValueChanged(sender As Object, e As EventArgs) Handles picCompassClipartImage.EditValueChanged
        If Not oCompassOptions Is Nothing AndAlso Not bDisabledEvent Then
            oCompassOptions.Clipart = modDevExpress.SvgImageToClipart(picCompassClipartImage.SvgImage)
        End If
    End Sub

    Private Sub txtColor_EditValueChanged(sender As Object, e As EventArgs) Handles txtColor.EditValueChanged
        If Not oCompassOptions Is Nothing AndAlso Not bDisabledEvent Then
            oCompassOptions.Color = txtColor.EditValue
        End If
    End Sub

    Private Sub txtCompassClipartZoomFactor_EditValueChanged(sender As Object, e As EventArgs) Handles txtCompassClipartZoomFactor.EditValueChanged
        If Not oCompassOptions Is Nothing AndAlso Not bDisabledEvent Then
            oCompassOptions.ClipartZoomFactor = txtCompassClipartZoomFactor.Value
        End If
    End Sub
End Class