Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Options
Imports cSurveyPC.cSurvey.Drawings
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors.Controls

Friend Class frmParametersInfoBox
    Private oOptions As cOptionsCenterline
    Private oInfoboxOptions As cInfoBoxOptions
    Private bDisabledEvent As Boolean

    Public Sub New(Options As cOptionsCenterline, Optional ByVal UnitText As String = "mm")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent()
        oOptions = Options
        oInfoboxOptions = oOptions.InfoBoxOptions

        bDisabledEvent = True

        GroupControl1.CustomHeaderButtons(0).Properties.Checked = True
        Call pLoadFontOptions()

        chkUnlock.Checked = pIsUnlocked()

        txtWidth.EditValue = oInfoboxOptions.Width
        lblWidthUnit.Text = UnitText

        bDisabledEvent = False
    End Sub

    Private Function pIsUnlocked() As Boolean
        Return Not ((oInfoboxOptions.IDFont.FontName = oInfoboxOptions.TextFont.FontName) And (oInfoboxOptions.TextFont.FontName = oInfoboxOptions.TitleFont.FontName))
    End Function

    Private Sub pSave()
        Call oOptions.InfoBoxOptions.CopyFrom(oInfoboxOptions)
    End Sub

    'Private Sub cmdFontColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim oCD As ColorDialog = New ColorDialog
    '    With oCD
    '        .FullOpen = True
    '        .AnyColor = True
    '        .Color = picFontColor.BackColor
    '        If .ShowDialog = Windows.Forms.DialogResult.OK Then
    '            picFontColor.BackColor = .Color
    '            Select Case tabInfoBoxPart.SelectedIndex
    '                Case 0
    '                    oInfoboxOptions.IDFont.Color = .Color
    '                Case 1
    '                    oInfoboxOptions.TitleFont.Color = .Color
    '                Case 2
    '                    oInfoboxOptions.TextFont.Color = .Color
    '            End Select
    '        End If
    '    End With
    'End Sub

    Private Sub chkTextFontBold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTextFontBold.CheckedChanged
        Try
            If Not oInfoboxOptions Is Nothing AndAlso Not bDisabledEvent Then
                Select Case pGetCurrentTab()
                    Case 0
                        oInfoboxOptions.IDFont.FontBold = chkTextFontBold.Checked
                    Case 1
                        oInfoboxOptions.TitleFont.FontBold = chkTextFontBold.Checked
                    Case 2
                        oInfoboxOptions.TextFont.FontBold = chkTextFontBold.Checked
                End Select
            End If
        Catch
        End Try
    End Sub

    Private Sub chkTextFontItalic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTextFontItalic.CheckedChanged
        Try
            If Not oInfoboxOptions Is Nothing AndAlso Not bDisabledEvent Then
                Select Case pGetCurrentTab()
                    Case 0
                        oInfoboxOptions.IDFont.FontItalic = chkTextFontItalic.Checked
                    Case 1
                        oInfoboxOptions.TitleFont.FontItalic = chkTextFontItalic.Checked
                    Case 2
                        oInfoboxOptions.TextFont.FontItalic = chkTextFontItalic.Checked
                End Select
            End If
        Catch
        End Try
    End Sub

    Private Sub chkTextFontUnderline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTextFontUnderline.CheckedChanged
        Try
            If Not oInfoboxOptions Is Nothing AndAlso Not bDisabledEvent Then
                Select Case pGetCurrentTab()
                    Case 0
                        oInfoboxOptions.IDFont.FontUnderline = chkTextFontUnderline.Checked
                    Case 1
                        oInfoboxOptions.TitleFont.FontUnderline = chkTextFontUnderline.Checked
                    Case 2
                        oInfoboxOptions.TextFont.FontUnderline = chkTextFontUnderline.Checked
                End Select
            End If
        Catch
        End Try
    End Sub

    Private Function pGetCurrentTab() As Integer
        Return GroupControl1.CustomHeaderButtons.IndexOf(GroupControl1.CustomHeaderButtons.FirstOrDefault(Function(oItem) oItem.IsChecked))
    End Function

    Private Sub chkVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVisible.CheckedChanged
        Try
            If Not oInfoboxOptions Is Nothing AndAlso Not bDisabledEvent Then
                Select Case pGetCurrentTab()
                    Case 0
                        oInfoboxOptions.IDVisible = chkVisible.Checked
                    Case 1
                        oInfoboxOptions.TitleVisible = chkVisible.Checked
                    Case 2
                        oInfoboxOptions.TextVisible = chkVisible.Checked
                End Select
            End If
        Catch
        End Try
    End Sub

    Private Sub pLoadFontOptions()
        bDisabledEvent = True
        Try
            Select Case pGetCurrentTab()
                Case 0
                    txtColor.EditValue = oInfoboxOptions.IDFont.Color
                    chkTextFontBold.Checked = oInfoboxOptions.IDFont.FontBold
                    chkTextFontItalic.Checked = oInfoboxOptions.IDFont.FontItalic
                    chkTextFontUnderline.Checked = oInfoboxOptions.IDFont.FontUnderline
                    If oInfoboxOptions.IDFont.FontName = "" Then
                        cboTextFontChar.EditValue = Nothing
                    Else
                        cboTextFontChar.EditValue = oInfoboxOptions.IDFont.FontName
                    End If
                    If oInfoboxOptions.IDFont.FontSize = 0 Then
                        cboTextFontSize.EditValue = Nothing
                    Else
                        cboTextFontSize.EditValue = oInfoboxOptions.IDFont.FontSize
                    End If
                    chkVisible.Checked = oInfoboxOptions.IDVisible

                    chkUnlock.Visible = False
                Case 1
                    txtColor.EditValue = oInfoboxOptions.TitleFont.Color
                    chkTextFontBold.Checked = oInfoboxOptions.TitleFont.FontBold
                    chkTextFontItalic.Checked = oInfoboxOptions.TitleFont.FontItalic
                    chkTextFontUnderline.Checked = oInfoboxOptions.TitleFont.FontUnderline
                    If oInfoboxOptions.TitleFont.FontName = "" Then
                        cboTextFontChar.EditValue = Nothing
                    Else
                        cboTextFontChar.EditValue = oInfoboxOptions.TitleFont.FontName
                    End If
                    If oInfoboxOptions.TitleFont.FontSize = 0 Then
                        cboTextFontSize.EditValue = Nothing
                    Else
                        cboTextFontSize.EditValue = oInfoboxOptions.TitleFont.FontSize
                    End If
                    chkVisible.Checked = oInfoboxOptions.TitleVisible

                    chkUnlock.Visible = True
                    cboTextFontChar.Enabled = chkUnlock.Checked
                Case 2
                    txtColor.EditValue = oInfoboxOptions.TextFont.Color
                    chkTextFontBold.Checked = oInfoboxOptions.TextFont.FontBold
                    chkTextFontItalic.Checked = oInfoboxOptions.TextFont.FontItalic
                    chkTextFontUnderline.Checked = oInfoboxOptions.TextFont.FontUnderline
                    If oInfoboxOptions.TextFont.FontName = "" Then
                        cboTextFontChar.EditValue = Nothing
                    Else
                        cboTextFontChar.EditValue = oInfoboxOptions.TextFont.FontName
                    End If
                    If oInfoboxOptions.TextFont.FontSize = 0 Then
                        cboTextFontSize.EditValue = Nothing
                    Else
                        cboTextFontSize.EditValue = oInfoboxOptions.TextFont.FontSize
                    End If
                    chkVisible.Checked = oInfoboxOptions.TextVisible

                    chkUnlock.Visible = True
                    cboTextFontChar.Enabled = chkUnlock.Checked
            End Select
        Catch
        End Try
        bDisabledEvent = False
    End Sub

    Private Sub cboTextFontChar_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboTextFontChar.ButtonClick
        If e.Button.Index = 1 Then
            cboTextFontChar.EditValue = Nothing
        End If
    End Sub

    Private Sub cboTextFontChar_EditValueChanged(sender As Object, e As EventArgs) Handles cboTextFontChar.EditValueChanged
        If Not oInfoboxOptions Is Nothing AndAlso Not bDisabledEvent Then
            Select Case pGetCurrentTab()
                Case 0
                    If cboTextFontChar.EditValue Is Nothing Then
                        oInfoboxOptions.IDFont.FontName = ""
                        If pIsUnlocked() Then
                            oInfoboxOptions.TitleFont.FontName = ""
                            oInfoboxOptions.TextFont.FontName = ""
                        End If
                    Else
                        oInfoboxOptions.IDFont.FontName = cboTextFontChar.EditValue
                        If pIsUnlocked() Then
                            oInfoboxOptions.TitleFont.FontName = cboTextFontChar.EditValue
                            oInfoboxOptions.TextFont.FontName = cboTextFontChar.EditValue
                        End If
                    End If
                        Case 1
                    If cboTextFontChar.EditValue Is Nothing Then
                        oInfoboxOptions.TitleFont.FontName = ""
                    Else
                        oInfoboxOptions.TitleFont.FontName = cboTextFontChar.EditValue
                    End If
                Case 2
                    If cboTextFontChar.EditValue Is Nothing Then
                        oInfoboxOptions.TextFont.FontName = ""
                    Else
                        oInfoboxOptions.TextFont.FontName = cboTextFontChar.EditValue
                    End If
            End Select
        End If
    End Sub

    Private Sub cboTextFontSize_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles cboTextFontSize.EditValueChanging
        If Not e.NewValue Is Nothing Then
            Dim sValue As String = e.NewValue.ToString.Trim
            e.NewValue = sValue
            e.Cancel = Not IsNumeric(sValue)
        End If
    End Sub

    Private Sub cboTextFontSize_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboTextFontSize.ButtonClick
        If e.Button.Index = 1 Then
            cboTextFontSize.EditValue = Nothing
        End If
    End Sub

    Private Sub cboTextFontSize_EditValueChanged(sender As Object, e As EventArgs) Handles cboTextFontSize.EditValueChanged
        Try
            If Not oInfoboxOptions Is Nothing AndAlso Not bDisabledEvent Then
                Select Case pGetCurrentTab()
                    Case 0
                        If cboTextFontSize.EditValue Is Nothing Then
                            oInfoboxOptions.IDFont.FontSize = 0
                        Else
                            oInfoboxOptions.IDFont.FontSize = cboTextFontSize.EditValue
                        End If
                    Case 1
                        If cboTextFontSize.EditValue Is Nothing Then
                            oInfoboxOptions.TitleFont.FontSize = 0
                        Else
                            oInfoboxOptions.TitleFont.FontSize = cboTextFontSize.EditValue
                        End If
                    Case 2
                        If cboTextFontSize.EditValue Is Nothing Then
                            oInfoboxOptions.TextFont.FontSize = 0
                        Else
                            oInfoboxOptions.TextFont.FontSize = cboTextFontSize.EditValue
                        End If
                End Select
            End If
        Catch
        End Try
    End Sub

    Private Sub txtWidth_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtWidth.ValueChanged
        Try
            If Not oInfoboxOptions Is Nothing AndAlso Not bDisabledEvent Then
                oInfoboxOptions.Width = txtWidth.EditValue
            End If
        Catch
        End Try
    End Sub

    Private Sub GroupControl1_CustomButtonChecked(sender As Object, e As BaseButtonEventArgs) Handles GroupControl1.CustomButtonChecked
        Call pLoadFontOptions()
    End Sub

    Private Sub txtColor_EditValueChanged(sender As Object, e As EventArgs) Handles txtColor.EditValueChanged
        If Not oInfoboxOptions Is Nothing AndAlso Not bDisabledEvent Then
            Select Case pGetCurrentTab()
                Case 0
                    oInfoboxOptions.IDFont.Color = txtColor.EditValue
                Case 1
                    oInfoboxOptions.TitleFont.Color = txtColor.EditValue
                Case 2
                    oInfoboxOptions.TextFont.Color = txtColor.EditValue
            End Select
        End If
    End Sub

    Private Sub chkUnlock_CheckedChanged(sender As Object, e As EventArgs) Handles chkUnlock.CheckedChanged
        If Not oInfoboxOptions Is Nothing AndAlso Not bDisabledEvent Then
            Select Case pGetCurrentTab()
                Case 1, 2
                    cboTextFontChar.Enabled = chkUnlock.Checked
            End Select
        End If
    End Sub
End Class