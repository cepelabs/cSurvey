Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Options
Imports cSurveyPC.cSurvey.Drawings

friend Class frmParametersInfoBox
    Friend Event OnChangeOptions(ByVal Sender As Object, Options As cOptions) ' ByVal InfoBoxOptions As cOptionsPreview.cInfoBoxOptions)

    Private oOptions As cOptions
    Private oInfoboxOptions As cInfoBoxOptions
    Private bDisabledEvent As Boolean

    Public Sub New(Options As cOptions, Optional ByVal UnitText As String = "mm")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent()
        oOptions = options
        oInfoboxOptions = oOptions.InfoBoxOptions.Clone

        bDisabledEvent = True
        Dim oFonts As System.Drawing.Text.InstalledFontCollection = New System.Drawing.Text.InstalledFontCollection
        Call cboTextFontChar.Items.Add(GetLocalizedString("parametersinfobox.textpart1"))
        For Each oFontFamily As FontFamily In oFonts.Families
            Call cboTextFontChar.Items.Add(oFontFamily.Name)
        Next
        If oInfoboxOptions.TextFont.FontName = "" Then
            cboTextFontChar.SelectedIndex = 0
        Else
            cboTextFontChar.Text = oInfoboxOptions.TextFont.FontName
        End If

        tabInfoBoxPart.SelectedIndex = 0
        Call pChangeFontOptions()

        txtWidth.Value = oInfoboxOptions.Width
        lblWidthUnit.Text = UnitText

        bDisabledEvent = False
    End Sub

    Private Sub pSave()
        Call oOptions.InfoBoxOptions.CopyFrom(oInfoboxOptions)
    End Sub

    Private Sub cmdFontColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFontColor.Click
        Dim oCD As ColorDialog = New ColorDialog
        With oCD
            .FullOpen = True
            .AnyColor = True
            .Color = picFontColor.BackColor
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                picFontColor.BackColor = .Color
                Select Case tabInfoBoxPart.SelectedIndex
                    Case 0
                        oInfoboxOptions.IDFont.Color = .Color
                    Case 1
                        oInfoboxOptions.TitleFont.Color = .Color
                    Case 2
                        oInfoboxOptions.TextFont.Color = .Color
                End Select
            End If
        End With
    End Sub

    Private Sub chkTextFontBold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTextFontBold.CheckedChanged
        Try
            If Not bDisabledEvent Then
                Select Case tabInfoBoxPart.SelectedIndex
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
            If Not bDisabledEvent Then
                Select Case tabInfoBoxPart.SelectedIndex
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
            If Not bDisabledEvent Then
                Select Case tabInfoBoxPart.SelectedIndex
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

    Private Sub chkVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVisible.CheckedChanged
        Try
            If Not bDisabledEvent Then
                Select Case tabInfoBoxPart.SelectedIndex
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

    Private Sub pChangeFontOptions()
        bDisabledEvent = True
        pnlSub.Parent = tabInfoBoxPart.SelectedTab
        pnlSub.BringToFront()
        Try
            Select Case tabInfoBoxPart.SelectedIndex
                Case 0
                    picFontColor.BackColor = oInfoboxOptions.IDFont.Color
                    chkTextFontBold.Checked = oInfoboxOptions.IDFont.FontBold
                    chkTextFontItalic.Checked = oInfoboxOptions.IDFont.FontItalic
                    chkTextFontUnderline.Checked = oInfoboxOptions.IDFont.FontUnderline
                    If oInfoboxOptions.IDFont.FontSize = 0 Then
                        cboTextFontSize.SelectedIndex = 0
                    Else
                        cboTextFontSize.Text = oInfoboxOptions.IDFont.FontSize
                    End If
                    chkVisible.Checked = oInfoboxOptions.IDVisible
                Case 1
                    picFontColor.BackColor = oInfoboxOptions.TitleFont.Color
                    chkTextFontBold.Checked = oInfoboxOptions.TitleFont.FontBold
                    chkTextFontItalic.Checked = oInfoboxOptions.TitleFont.FontItalic
                    chkTextFontUnderline.Checked = oInfoboxOptions.TitleFont.FontUnderline
                    If oInfoboxOptions.TitleFont.FontSize = 0 Then
                        cboTextFontSize.SelectedIndex = 0
                    Else
                        cboTextFontSize.Text = oInfoboxOptions.TitleFont.FontSize
                    End If
                    chkVisible.Checked = oInfoboxOptions.TitleVisible
                Case 2
                    picFontColor.BackColor = oInfoboxOptions.TextFont.Color
                    chkTextFontBold.Checked = oInfoboxOptions.TextFont.FontBold
                    chkTextFontItalic.Checked = oInfoboxOptions.TextFont.FontItalic
                    chkTextFontUnderline.Checked = oInfoboxOptions.TextFont.FontUnderline
                    If oInfoboxOptions.TextFont.FontSize = 0 Then
                        cboTextFontSize.SelectedIndex = 0
                    Else
                        cboTextFontSize.Text = oInfoboxOptions.TextFont.FontSize
                    End If
                    chkVisible.Checked = oInfoboxOptions.TextVisible
            End Select
        Catch
        End Try
        bDisabledEvent = False
    End Sub

    Private Sub tabInfoBoxPart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabInfoBoxPart.SelectedIndexChanged
        Call pChangeFontOptions()
    End Sub

    Private Sub cboTextFontChar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTextFontChar.SelectedIndexChanged
        Try
            If Not bDisabledEvent Then
                If cboTextFontChar.SelectedIndex = 0 Then
                    oInfoboxOptions.TextFont.FontName = ""
                Else
                    oInfoboxOptions.IDFont.FontName = cboTextFontChar.Text
                    oInfoboxOptions.TitleFont.FontName = cboTextFontChar.Text
                    oInfoboxOptions.TextFont.FontName = cboTextFontChar.Text
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Call pSave()
        RaiseEvent OnChangeOptions(Me, oOptions)
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Call Close()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Call pSave()
        RaiseEvent OnChangeOptions(Me, oOptions)
        Call Close()
    End Sub

    Private Sub cboTextFontSize_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboTextFontSize.SelectedValueChanged
        Try
            If Not bDisabledEvent Then
                Select Case tabInfoBoxPart.SelectedIndex
                    Case 0
                        If cboTextFontSize.SelectedIndex = 0 Then
                            oInfoboxOptions.IDFont.FontSize = 0
                        Else
                            oInfoboxOptions.IDFont.FontSize = cboTextFontSize.Text
                        End If
                    Case 1
                        If cboTextFontSize.SelectedIndex = 0 Then
                            oInfoboxOptions.TitleFont.FontSize = 0
                        Else
                            oInfoboxOptions.TitleFont.FontSize = cboTextFontSize.Text
                        End If
                    Case 2
                        If cboTextFontSize.SelectedIndex = 0 Then
                            oInfoboxOptions.TextFont.FontSize = 0
                        Else
                            oInfoboxOptions.TextFont.FontSize = cboTextFontSize.Text
                        End If
                End Select
            End If
        Catch
        End Try
    End Sub

    Private Sub cboTextFontSize_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTextFontSize.SelectedIndexChanged

    End Sub

    Private Sub cboTextFontSize_TextChanged(sender As Object, e As System.EventArgs) Handles cboTextFontSize.TextChanged
        Try
            If Not bDisabledEvent Then
                Select Case tabInfoBoxPart.SelectedIndex
                    Case 0
                        If cboTextFontSize.SelectedIndex = 0 Then
                            oInfoboxOptions.IDFont.FontSize = 0
                        Else
                            oInfoboxOptions.IDFont.FontSize = cboTextFontSize.Text
                        End If
                    Case 1
                        If cboTextFontSize.SelectedIndex = 0 Then
                            oInfoboxOptions.TitleFont.FontSize = 0
                        Else
                            oInfoboxOptions.TitleFont.FontSize = cboTextFontSize.Text
                        End If
                    Case 2
                        If cboTextFontSize.SelectedIndex = 0 Then
                            oInfoboxOptions.TextFont.FontSize = 0
                        Else
                            oInfoboxOptions.TextFont.FontSize = cboTextFontSize.Text
                        End If
                End Select
            End If
        Catch
        End Try
    End Sub

    Private Sub txtWidth_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtWidth.ValueChanged
        Try
            If Not bDisabledEvent Then
                oInfoboxOptions.Width = txtWidth.Value
            End If
        Catch
        End Try
    End Sub
End Class