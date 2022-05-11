Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Options
Imports cSurveyPC.cSurvey.Drawings

friend Class frmParametersCompass
    Friend Event OnChangeOptions(ByVal Sender As Object, ByVal Options As cOptions)

    Private oOptions As cOptions
    Private oCompassOptions As cCompassOptions
    Private bDisabledEvent As Boolean

    Private Sub cmdCompassColorBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCompassColorBrowse.Click
        Dim oCD As ColorDialog = New ColorDialog
        With oCD
            .FullOpen = True
            .AnyColor = True
            .Color = picCompassColor.BackColor
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                picCompassColor.BackColor = .Color
                oCompassOptions.Color = .Color
                'RaiseEvent OnChangeOptions(Me)
            End If
        End With
    End Sub

    Private Sub cmdCompassBrowseClipart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCompassBrowseClipart.Click
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
                'RaiseEvent OnChangeOptions(Me)
            End If
        End With
    End Sub

    Public Sub New(ByVal Options As cOptions)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent()
        oOptions = options
        oCompassOptions = oOptions.CompassOptions.Clone

        bDisabledEvent = True
        Dim oFonts As System.Drawing.Text.InstalledFontCollection = New System.Drawing.Text.InstalledFontCollection
        For Each oFontFamily As FontFamily In oFonts.Families
            Call cboCompassTextFontChar.Items.Add(oFontFamily.Name)
        Next

        txtCompassText.Text = oCompassOptions.Text

        cboCompassTextFontChar.Text = oCompassOptions.Font.FontName
        chkCompassTextFontBold.Checked = oCompassOptions.Font.FontBold
        chkCompassTextFontItalic.Checked = oCompassOptions.Font.FontItalic
        chkCompassTextFontUnderline.Checked = oCompassOptions.Font.FontUnderline
        cboCompassTextFontSize.Text = oCompassOptions.Font.FontSize

        picCompassColor.BackColor = oCompassOptions.Color
        picCompassClipartImage.Image = oCompassOptions.Clipart.GetThumbnailImage(picCompassClipartImage.Width, picCompassClipartImage.Height)
        txtCompassClipartZoomFactor.Value = oCompassOptions.ClipartZoomFactor

        bDisabledEvent = False
    End Sub

    Private Sub txtCompassClipartZoomFactor_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCompassClipartZoomFactor.ValueChanged
        Try
            If Not bDisabledEvent Then
                oCompassOptions.ClipartZoomFactor = txtCompassClipartZoomFactor.Value
            End If
        Catch
        End Try
    End Sub

    Private Sub chkCompassTextFontBold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCompassTextFontBold.CheckedChanged
        Try
            If Not bDisabledEvent Then
                oCompassOptions.Font.FontBold = chkCompassTextFontBold.Checked
            End If
        Catch
        End Try
    End Sub

    Private Sub chkCompassTextFontItalic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCompassTextFontItalic.CheckedChanged
        Try
            If Not bDisabledEvent Then
                oCompassOptions.Font.FontItalic = chkCompassTextFontItalic.Checked
            End If
        Catch
        End Try
    End Sub

    Private Sub chkCompassTextFontUnderline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCompassTextFontUnderline.CheckedChanged
        Try
            If Not bDisabledEvent Then
                oCompassOptions.Font.FontUnderline = chkCompassTextFontUnderline.Checked
            End If
        Catch
        End Try
    End Sub

    Private Sub cboCompassTextFontChar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCompassTextFontChar.SelectedIndexChanged
        Try
            If Not bDisabledEvent Then
                oCompassOptions.Font.FontName = cboCompassTextFontChar.Text
            End If
        Catch
        End Try
    End Sub

    Private Sub txtCompassText_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCompassText.Validating
        Try
            If Not bDisabledEvent Then
                oCompassOptions.Text = txtCompassText.Text
            End If
        Catch
        End Try
    End Sub

    Private Sub pSave()
        Call oOptions.CompassOptions.CopyFrom(oCompassOptions)
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Call psave()
        RaiseEvent OnChangeOptions(Me, oOptions)
        Call Close()
        Call Dispose()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Call Close()
        Call Dispose()
    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Call psave()
        RaiseEvent OnChangeOptions(Me, oOptions)
    End Sub

    Private Sub cboCompassTextFontSize_TextChanged(sender As Object, e As System.EventArgs) Handles cboCompassTextFontSize.TextChanged
        Try
            If Not bDisabledEvent Then
                oCompassOptions.Font.FontSize = cboCompassTextFontSize.Text
                'RaiseEvent OnChangeOptions(Me)
            End If
        Catch
        End Try
    End Sub
End Class