Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Public Class cItemTextPropertyControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call cboPropTextFontChar.Items.Clear()
        Dim oFonts As System.Drawing.Text.InstalledFontCollection = New System.Drawing.Text.InstalledFontCollection
        Call cboPropTextFontChar.Items.Add(GetLocalizedString("main.textpart40"))
        For Each oFontFamily As FontFamily In oFonts.Families
            Call cboPropTextFontChar.Items.Add(oFontFamily.Name)
        Next
    End Sub

    Private oSurvey As cSurveyPC.cSurvey.cSurvey

    Public Overrides Sub Rebind(Item As cItem)
        Call MyBase.Rebind(Item)

        If Not oSurvey Is Item.Survey Then
            oSurvey = Item.Survey
            Call cboPropTextStyle.Items.Clear()
            Call cboPropTextStyle.Items.Add(Item.Survey.EditPaintObjects.GenericFonts.Generic)
            Call cboPropTextStyle.Items.Add(Item.Survey.EditPaintObjects.GenericFonts.Title)
            Call cboPropTextStyle.Items.Add(Item.Survey.EditPaintObjects.GenericFonts.CaveName)
            Call cboPropTextStyle.Items.Add(Item.Survey.EditPaintObjects.GenericFonts.CaveComplexName)
            Call cboPropTextStyle.Items.Add(Item.Survey.EditPaintObjects.GenericFonts.TrigPoint)
            Call cboPropTextStyle.Items.Add(Item.Survey.EditPaintObjects.GenericFonts.Note)
            Call cboPropTextStyle.Items.Add(Item.Survey.EditPaintObjects.GenericFonts.FromCustom("", 0, Color.Black, False, False, False))
        End If

        If TypeOf Item Is cIItemText Then
            With DirectCast(Item, cIItemText)
                txtPropText.Text = .Text

                If .Font.Type = cItemFont.FontTypeEnum.Custom Then
                    cboPropTextStyle.SelectedIndex = cboPropTextStyle.Items.Count - 1
                    If .Font.FontName = "" Then
                        cboPropTextFontChar.SelectedIndex = 0
                    Else
                        cboPropTextFontChar.Text = .Font.FontName
                    End If
                    If .Font.FontSize = 0 Then
                        cboPropTextFontSize.SelectedIndex = 0
                    Else
                        cboPropTextFontSize.Text = .Font.FontSize
                    End If
                    chkPropTextFontBold.Checked = .Font.FontBold
                    chkPropTextFontItalic.Checked = .Font.FontItalic
                    chkPropTextFontUnderline.Checked = .Font.FontUnderline
                    picPropFontColor.BackColor = .Font.Color
                    pnlPropTextFont.Visible = True
                Else
                    cboPropTextStyle.SelectedIndex = .Font.Type
                    pnlPropTextFont.Visible = False
                End If

                If (.AvaiableTextProperties And cIItemText.AvaiableTextPropertiesEnum.Rotable) Then
                    cboPropTextRotateMode.SelectedIndex = DirectCast(Item, cIItemRotable).RotateMode
                    cboPropTextRotateMode.Enabled = True
                Else
                    cboPropTextRotateMode.Enabled = False
                End If
                If (.AvaiableTextProperties And cIItemText.AvaiableTextPropertiesEnum.Lineable) Then
                    Dim oItemLineableText As cIItemLineableText = Item
                    optPropTextAlignLeft.Enabled = True
                    optPropTextAlignCenter.Enabled = True
                    optPropTextAlignRight.Enabled = True
                    Select Case oItemLineableText.TextAlignment
                        Case cIItemLineableText.TextAlignmentEnum.Left
                            optPropTextAlignLeft.Checked = True
                            optPropTextAlignCenter.Checked = False
                            optPropTextAlignRight.Checked = False
                        Case cIItemLineableText.TextAlignmentEnum.Center
                            optPropTextAlignLeft.Checked = False
                            optPropTextAlignCenter.Checked = True
                            optPropTextAlignRight.Checked = False
                        Case cIItemLineableText.TextAlignmentEnum.Right
                            optPropTextAlignLeft.Checked = False
                            optPropTextAlignCenter.Checked = False
                            optPropTextAlignRight.Checked = True
                    End Select
                Else
                    optPropTextAlignLeft.Checked = False
                    optPropTextAlignCenter.Checked = False
                    optPropTextAlignRight.Checked = False
                    optPropTextAlignLeft.Enabled = False
                    optPropTextAlignCenter.Enabled = False
                    optPropTextAlignRight.Enabled = False
                End If
                If (.AvaiableTextProperties And cIItemText.AvaiableTextPropertiesEnum.VerticalLineable) Then
                    Dim oItemVerticalLineableText As cIItemVerticalLineableText = Item
                    optPropTextVAlignTop.Enabled = True
                    optPropTextVAlignCenter.Enabled = True
                    optPropTextVAlignBottom.Enabled = True
                    Select Case oItemVerticalLineableText.TextVerticalAlignment
                        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Top
                            optPropTextVAlignTop.Checked = True
                            optPropTextVAlignCenter.Checked = False
                            optPropTextVAlignBottom.Checked = False
                        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle
                            optPropTextVAlignTop.Checked = False
                            optPropTextVAlignCenter.Checked = True
                            optPropTextVAlignBottom.Checked = False
                        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
                            optPropTextVAlignTop.Checked = False
                            optPropTextVAlignCenter.Checked = False
                            optPropTextVAlignBottom.Checked = True
                    End Select
                Else
                    optPropTextVAlignTop.Checked = False
                    optPropTextVAlignCenter.Checked = False
                    optPropTextVAlignBottom.Checked = False
                    optPropTextVAlignTop.Enabled = False
                    optPropTextVAlignCenter.Enabled = False
                    optPropTextVAlignBottom.Enabled = False
                End If
            End With
            If TypeOf Item Is cIItemSizable Then
                cboPropTextSize.SelectedIndex = DirectCast(Item, cIItemSizable).Size
                cboPropTextSize.Enabled = True
            Else
                cboPropTextSize.Enabled = False
            End If
        End If
    End Sub

    'Private Sub chkVisibleInPreview_CheckedChanged(sender As Object, e As EventArgs) 
    '    Try
    '        If Not DisabledObjectProperty() Then
    '            Item.HiddenInPreview = Not chkPropVisibleInPreview.Checked
    '            Call MyBase.TakeUndoSnapshot()
    '            Call MyBase.PropertyChanged("HiddenInPreview")
    '            Call MyBase.MapInvalidate()
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    'Private Sub chkVisibleInDesign_CheckedChanged(sender As Object, e As EventArgs) 
    '    Try
    '        If Not DisabledObjectProperty() Then
    '            Item.HiddenInDesign = Not chkPropVisibleInDesign.Checked
    '            Call MyBase.TakeUndoSnapshot()
    '            Call MyBase.PropertyChanged("HiddenInDesign")
    '            Call MyBase.MapInvalidate()
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    'Private Sub cboPropAffinity_SelectedIndexChanged(sender As Object, e As EventArgs) 
    '    Try
    '        Item.DesignAffinity = cboPropAffinity.SelectedIndex
    '        Call MyBase.TakeUndoSnapshot()
    '        Call MyBase.PropertyChanged("DesignAffinity")
    '        Call MyBase.MapInvalidate()
    '    Catch
    '    End Try
    'End Sub

    'Private Function pScaleRulestemScaleVisibilityEdit(Item As cItem) As Boolean
    '    Dim frmSR As frmItemScaleVisibility = New frmItemScaleVisibility(Item)
    '    If frmSR.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

    'Private Sub chkPropVisibleByScale_Click(sender As Object, e As EventArgs) 
    '    Try
    '        If pScaleRulestemScaleVisibilityEdit(oItem) Then
    '            Call MyBase.MapInvalidate()
    '        End If
    '    Catch
    '    End Try
    'End Sub

    Private Sub cboPropTextStyle_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboPropTextStyle.DrawItem
        Try
            Dim oGr As Graphics = e.Graphics
            oGr.CompositingQuality = CompositingQuality.HighQuality
            oGr.InterpolationMode = InterpolationMode.HighQualityBicubic
            oGr.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
            Dim bSelected As Boolean = (e.State And DrawItemState.Selected) = DrawItemState.Selected
            If bSelected Then
                Call oGr.FillRectangle(SystemBrushes.Highlight, e.Bounds)
            Else
                Call oGr.FillRectangle(SystemBrushes.Window, e.Bounds)
            End If

            Dim oFont As cItemFont = cboPropTextStyle.Items(e.Index)

            Using oPath As GraphicsPath = New GraphicsPath
                Dim oLabelRect As RectangleF = New RectangleF(e.Bounds.Left + 2, e.Bounds.Top, e.Bounds.Right - 2, e.Bounds.Height)
                Using oSF As StringFormat = New StringFormat
                    oSF.LineAlignment = StringAlignment.Center
                    oSF.Trimming = StringTrimming.EllipsisCharacter
                    oSF.FormatFlags = StringFormatFlags.NoWrap
                    If bSelected Then
                        Call oGr.DrawString(oFont.Name, oFont.GetSampleFont, SystemBrushes.HighlightText, oLabelRect, oSF)
                    Else
                        Call oGr.DrawString(oFont.Name, oFont.GetSampleFont, SystemBrushes.WindowText, oLabelRect, oSF)
                    End If
                End Using
            End Using
        Catch
        End Try
    End Sub

    Private Sub txtPropText_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPropText.Validated
        If TypeOf Item Is cIItemText Then
            With DirectCast(Item, cIItemText)
                .Text = txtPropText.Text
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("Text")
                Call MyBase.MapInvalidate()
            End With
        End If
    End Sub

    Private Sub txtPropText_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtPropText.PreviewKeyDown
        If e.Control And e.KeyCode = Keys.Enter Then ' And Not e.Shift And Not e.Control And Not e.Alt Then
            If TypeOf Item Is cIItemText Then
                With DirectCast(Item, cIItemText)
                    .Text = txtPropText.Text
                    Call MyBase.TakeUndoSnapshot()
                    Call MyBase.PropertyChanged("Text")
                    Call MyBase.MapInvalidate()
                End With
            End If
        End If
    End Sub

    Private Sub cboPropTextRotateMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropTextRotateMode.SelectedIndexChanged
        Try
            If Not DisabledObjectProperty() Then
                If TypeOf Item Is cIItemRotable Then
                    With DirectCast(Item, cIItemRotable)
                        .RotateMode = cboPropTextRotateMode.SelectedIndex
                        Call MyBase.TakeUndoSnapshot()
                        Call MyBase.PropertyChanged("RotateMode")
                        Call MyBase.MapInvalidate()
                    End With
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub cboPropTextSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPropTextSize.SelectedIndexChanged
        Try
            If Not DisabledObjectProperty() Then
                If TypeOf Item Is cIItemText Then
                    With DirectCast(Item, cIItemText)
                        .Size = cboPropTextSize.SelectedIndex
                        Call MyBase.TakeUndoSnapshot()
                        Call MyBase.PropertyChanged("TextSize")
                        Call MyBase.MapInvalidate()
                    End With
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub cboPropTextStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropTextStyle.SelectedIndexChanged
        Try
            If TypeOf Item Is cIItemText Then
                With DirectCast(Item, cIItemText)
                    .Font.Type = cboPropTextStyle.SelectedItem.type
                    Call MyBase.TakeUndoSnapshot()
                    Call MyBase.PropertyChanged("FontType")
                    Call MyBase.MapInvalidate()
                End With
            End If
        Catch
        End Try
    End Sub

    Private Sub cItemTextPropertyControl_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Dim iHeight As Integer = If(pnlPropTextFont.Visible, pnlPropTextFont.Height, 0) + If(pnlPropTextStyle.Visible, pnlPropTextStyle.Height, 0) + If(pnlPropTextAlignmentAndRotation.Visible, pnlPropTextAlignmentAndRotation.Height, 0)
        If Size.Height <> iHeight Then
            Size = New Size(Size.Width, iHeight)
        End If
    End Sub

    Private Sub cboPropTextFontChar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPropTextFontChar.SelectedIndexChanged
        Try
            If Not DisabledObjectProperty() Then
                If TypeOf Item Is cIItemText Then
                    With DirectCast(Item, cIItemFont)
                        If cboPropTextFontChar.SelectedIndex = 0 Then
                            .Font.FontName = ""
                        Else
                            .Font.FontName = cboPropTextFontChar.Text
                        End If
                        Call MyBase.TakeUndoSnapshot()
                        Call MyBase.PropertyChanged("Font")
                        Call MyBase.MapInvalidate()
                    End With
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub chkPropTextFontBold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPropTextFontBold.CheckedChanged
        Try
            If Not DisabledObjectProperty() Then
                If TypeOf Item Is cIItemText Then
                    With DirectCast(Item, cIItemFont)
                        .Font.FontBold = chkPropTextFontBold.Checked
                        Call MyBase.TakeUndoSnapshot()
                        Call MyBase.PropertyChanged("FontBold")
                        Call MyBase.MapInvalidate()
                    End With
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub chkPropTextFontItalic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPropTextFontItalic.CheckedChanged
        Try
            If Not DisabledObjectProperty() Then
                If TypeOf Item Is cIItemText Then
                    With DirectCast(Item, cIItemFont)
                        .Font.FontBold = chkPropTextFontBold.Checked
                        Call MyBase.TakeUndoSnapshot()
                        Call MyBase.PropertyChanged("FontItalic")
                        Call MyBase.MapInvalidate()
                    End With
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub chkPropTextFontUnderline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPropTextFontUnderline.CheckedChanged
        Try
            If Not DisabledObjectProperty() Then
                If TypeOf Item Is cIItemText Then
                    With DirectCast(Item, cIItemFont)
                        .Font.FontBold = chkPropTextFontUnderline.Checked
                        Call MyBase.TakeUndoSnapshot()
                        Call MyBase.PropertyChanged("FontUnderline")
                        Call MyBase.MapInvalidate()
                    End With
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub cboPropTextFontSize_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPropTextFontSize.TextChanged
        Try
            If Not DisabledObjectProperty() Then
                If TypeOf Item Is cIItemText Then
                    With DirectCast(Item, cIItemFont)
                        If cboPropTextFontSize.SelectedIndex = 0 Then
                            .Font.FontSize = 0
                        Else
                            .Font.FontSize = cboPropTextFontSize.Text
                        End If
                        Call MyBase.TakeUndoSnapshot()
                        Call MyBase.PropertyChanged("FontSize")
                        Call MyBase.MapInvalidate()
                    End With
                End If
            End If
        Catch
        End Try
    End Sub
End Class
