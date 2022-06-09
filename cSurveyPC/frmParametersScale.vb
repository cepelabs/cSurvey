Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Options
Imports cSurveyPC.cSurvey.Drawings
Imports DevExpress.XtraEditors.Controls

Friend Class frmParametersScale
    'Friend Event OnChangeOptions(ByVal Sender As Object, ByVal Options As cOptions)

    Private oOptions As cOptionsCenterline
    Private oScaleOptions As cScaleOptions
    Private bEventDisabled As Boolean

    Private Sub txtScaleMeters_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScaleMeters.ValueChanged
        Try
            If Not oScaleOptions Is Nothing AndAlso Not bEventDisabled Then
                oScaleOptions.Meters = txtScaleMeters.Value
            End If
        Catch
        End Try
    End Sub

    Private Sub txtScaleSteps_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScaleSteps.ValueChanged
        Try
            If Not oScaleOptions Is Nothing AndAlso Not bEventDisabled Then
                oScaleOptions.Steps = txtScaleSteps.Value
            End If
        Catch
        End Try
    End Sub

    Public Sub New(ByVal Options As cOptionsCenterline)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oOptions = Options
        oScaleOptions = oOptions.ScaleOptions '.Clone

        bEventDisabled = True

        txtScaleMeters.Value = oScaleOptions.Meters
        txtScaleSteps.Value = oScaleOptions.Steps
        txtScaleStep.Value = oScaleOptions.Step

        txtScaleColor.Color = oScaleOptions.Color

        If oScaleOptions.Font.FontName = "" Then
            cboScaleTextFontChar.EditValue = Nothing
            'cboScaleTextFontChar.SelectedIndex = 0
        Else
            cboScaleTextFontChar.Text = oScaleOptions.Font.FontName
        End If
        If oScaleOptions.Font.FontSize = 0 Then
            cboScaleTextFontSize.EditValue = Nothing
        Else
            cboScaleTextFontSize.EditValue = oScaleOptions.Font.FontSize
        End If
        chkScaleTextFontBold.Checked = oScaleOptions.Font.FontBold
        chkScaleTextFontItalic.Checked = oScaleOptions.Font.FontItalic
        chkScaleTextFontUnderline.Checked = oScaleOptions.Font.FontUnderline

        txtScaleText.Text = oScaleOptions.Text

        chkHideScaleValue.Checked = oScaleOptions.HideScaleValue

        bEventDisabled = False
    End Sub

    Private Sub chkScaleTextFontBold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkScaleTextFontBold.CheckedChanged
        Try
            If Not oScaleOptions Is Nothing AndAlso Not bEventDisabled Then
                oScaleOptions.Font.FontBold = chkScaleTextFontBold.Checked
            End If
        Catch
        End Try
    End Sub

    Private Sub chkScaleTextFontItalic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkScaleTextFontItalic.CheckedChanged
        Try
            If Not oScaleOptions Is Nothing AndAlso Not bEventDisabled Then
                oScaleOptions.Font.FontItalic = chkScaleTextFontItalic.Checked
            End If
        Catch
        End Try
    End Sub

    Private Sub chkScaleTextFontUnderline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkScaleTextFontUnderline.CheckedChanged
        Try
            If Not oScaleOptions Is Nothing AndAlso Not bEventDisabled Then
                oScaleOptions.Font.FontUnderline = chkScaleTextFontUnderline.Checked
            End If
        Catch
        End Try
    End Sub

    Private Sub txtScaleText_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtScaleText.Validated
        If Not oScaleOptions Is Nothing AndAlso Not bEventDisabled Then
            oScaleOptions.Text = txtScaleText.Text
        End If
    End Sub

    Private Sub txtScaleStep_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScaleStep.ValueChanged
        If Not oScaleOptions Is Nothing AndAlso Not bEventDisabled Then
            oScaleOptions.Step = txtScaleStep.Value
        End If
    End Sub

    Private Sub chkHideScaleValue_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkHideScaleValue.CheckedChanged
        If Not oScaleOptions Is Nothing AndAlso Not bEventDisabled Then
            oScaleOptions.HideScaleValue = chkHideScaleValue.Checked
        End If
    End Sub

    Private Sub cboScaleTextFontSize_TextChanged(sender As Object, e As System.EventArgs) Handles cboScaleTextFontSize.TextChanged
        If Not oScaleOptions Is Nothing AndAlso Not bEventDisabled Then
            If cboScaleTextFontSize.EditValue Is Nothing Then
                oScaleOptions.Font.FontSize = 0
            Else
                oScaleOptions.Font.FontSize = cboScaleTextFontSize.EditValue
            End If
        End If
    End Sub

    Private Sub cboScaleTextFontChar_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboScaleTextFontChar.ButtonClick
        If e.Button.Index = 1 Then
            cboScaleTextFontChar.EditValue = Nothing
        End If
    End Sub

    Private Sub cboScaleTextFontChar_EditValueChanged(sender As Object, e As EventArgs) Handles cboScaleTextFontChar.EditValueChanged
        If Not oScaleOptions Is Nothing AndAlso Not bEventDisabled Then
            If cboScaleTextFontChar.EditValue Is Nothing Then
                oScaleOptions.Font.FontName = ""
            Else
                oScaleOptions.Font.FontName = cboScaleTextFontChar.Text
            End If
        End If
    End Sub

    Private Sub txtScaleColor_EditValueChanged(sender As Object, e As EventArgs) Handles txtScaleColor.EditValueChanged
        If Not oScaleOptions Is Nothing AndAlso Not bEventDisabled Then
            oScaleOptions.Color = txtScaleColor.EditValue
        End If
    End Sub

    Private Sub cboScaleTextFontSize_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles cboScaleTextFontSize.EditValueChanging
        If Not e.NewValue Is Nothing Then
            Dim sValue As String = e.NewValue.ToString.Trim
            e.NewValue = sValue
            e.Cancel = Not IsNumeric(sValue)
        End If
    End Sub

    Private Sub cboScaleTextFontSize_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboScaleTextFontSize.ButtonClick
        If e.Button.Index = 1 Then
            cboScaleTextFontSize.EditValue = Nothing
        End If
    End Sub
End Class