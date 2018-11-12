Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Options
Imports cSurveyPC.cSurvey.Drawings

Public Class frmParametersScale
    Friend Event OnChangeOptions(ByVal Sender As Object, ByVal Options As cOptions)

    Private oOptions As cOptions
    Private oScaleOptions As cScaleOptions
    Private bDisabledEvent As Boolean

    Private Sub txtScaleMeters_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScaleMeters.ValueChanged
        Try
            If Not bDisabledEvent Then
                oScaleOptions.meters = txtScaleMeters.Value
            End If
        Catch
        End Try
    End Sub

    Private Sub txtScaleSteps_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScaleSteps.ValueChanged
        Try
            If Not bDisabledEvent Then
                oScaleOptions.Steps = txtScaleSteps.Value
            End If
        Catch
        End Try
    End Sub

    Public Sub New(ByVal Options As cOptions)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oOptions = Options
        oScaleOptions = oOptions.ScaleOptions.Clone

        bDisabledEvent = True
        Dim oFonts As System.Drawing.Text.InstalledFontCollection = New System.Drawing.Text.InstalledFontCollection
        Call cboScaleTextFontChar.Items.Add(GetLocalizedString("parametersscale.textpart1"))
        For Each oFontFamily As FontFamily In oFonts.Families
            Call cboScaleTextFontChar.Items.Add(oFontFamily.Name)
        Next

        txtScaleMeters.Value = oScaleOptions.Meters
        txtScaleSteps.Value = oScaleOptions.Steps
        txtScaleStep.Value = oScaleOptions.Step

        picScaleColor.BackColor = oScaleOptions.Color

        If oScaleOptions.Font.FontName = "" Then
            cboScaleTextFontChar.SelectedIndex = 0
        Else
            cboScaleTextFontChar.Text = oScaleOptions.Font.FontName
        End If
        If oScaleOptions.Font.FontSize = 0 Then
            cboScaleTextFontSize.SelectedIndex = 0
        Else
            cboScaleTextFontSize.Text = oScaleOptions.Font.FontSize
        End If
        chkScaleTextFontBold.Checked = oScaleOptions.Font.FontBold
        chkScaleTextFontItalic.Checked = oScaleOptions.Font.FontItalic
        chkScaleTextFontUnderline.Checked = oScaleOptions.Font.FontUnderline

        txtScaleText.Text = oScaleOptions.Text

        chkHideScaleValue.Checked = oScaleOptions.HideScaleValue

        bDisabledEvent = False
    End Sub

    Private Sub cboScaleTextFontChar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboScaleTextFontChar.SelectedIndexChanged
        Try
            If Not bDisabledEvent Then
                If cboScaleTextFontChar.SelectedIndex = 0 Then
                    oScaleOptions.Font.FontName = ""
                Else
                    oScaleOptions.Font.FontName = cboScaleTextFontChar.Text
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub chkScaleTextFontBold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkScaleTextFontBold.CheckedChanged
        Try
            If Not bDisabledEvent Then
                oScaleOptions.Font.FontBold = chkScaleTextFontBold.Checked
            End If
        Catch
        End Try
    End Sub

    Private Sub chkScaleTextFontItalic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkScaleTextFontItalic.CheckedChanged
        Try
            If Not bDisabledEvent Then
                oScaleOptions.Font.FontItalic = chkScaleTextFontItalic.Checked
            End If
        Catch
        End Try
    End Sub

    Private Sub chkScaleTextFontUnderline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkScaleTextFontUnderline.CheckedChanged
        Try
            If Not bDisabledEvent Then
                oScaleOptions.Font.FontUnderline = chkScaleTextFontUnderline.Checked
            End If
        Catch
        End Try
    End Sub

    Private Sub cmdScaleColorBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScaleColorBrowse.Click
        Dim oCD As ColorDialog = New ColorDialog
        With oCD
            .FullOpen = True
            .AnyColor = True
            .Color = picScaleColor.BackColor
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                picScaleColor.BackColor = .Color
                oScaleOptions.Color = .Color
            End If
        End With
    End Sub

    Private Sub pSave()
        Call oOptions.ScaleOptions.CopyFrom(oScaleOptions)
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Call pSave()
        RaiseEvent OnChangeOptions(Me, oOptions)
        Call Close()
        Call Dispose()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Call Close()
        Call Dispose()
    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Call pSave()
        RaiseEvent OnChangeOptions(Me, oOptions)
    End Sub

    Private Sub txtScaleText_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtScaleText.Validated
        oScaleOptions.text = txtScaleText.Text
    End Sub

    Private Sub txtScaleStep_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScaleStep.ValueChanged
        Try
            If Not bDisabledEvent Then
                oScaleOptions.Step = txtScaleStep.Value
            End If
        Catch
        End Try
    End Sub

    Private Sub chkHideScaleValue_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkHideScaleValue.CheckedChanged
        Try
            If Not bDisabledEvent Then
                oScaleOptions.HideScalevalue = chkHideScaleValue.Checked
            End If
        Catch
        End Try
    End Sub

    Private Sub cboScaleTextFontSize_TextChanged(sender As Object, e As System.EventArgs) Handles cboScaleTextFontSize.TextChanged
        Try
            If Not bDisabledEvent Then
                If cboScaleTextFontSize.SelectedIndex = 0 Then
                    oScaleOptions.Font.FontSize = 0
                Else
                    oScaleOptions.Font.FontSize = cboScaleTextFontSize.Text
                End If
            End If
        Catch
        End Try
    End Sub
End Class