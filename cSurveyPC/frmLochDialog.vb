Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class frmLochDialog
    Private oSurvey As cSurvey.cSurvey

    Public Sub New(Survey As cSurvey.cSurvey)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey

        If oSurvey.Properties.GPS.Enabled Then
            Call cboElevationData.Items.Add(New cComboItem(Nothing, ""))
            For Each oElevation As cSurvey.Surface.cElevation In oSurvey.Surface.Elevations
                'If oElevation.ShowIn3D Then
                Call cboElevationData.Items.Add(New cComboItem(oElevation, oElevation.Name))
                If oElevation.Default Then
                    cboElevationData.SelectedIndex = cboElevationData.Items.Count - 1
                End If
                'End If
            Next
            If cboElevationData.Items.Count > 1 Then
                cboElevationData.Enabled = True
                lblElevationData.Enabled = cboElevationData.Enabled
                Call cboOrthophoto.Items.Add(New cComboItem(Nothing, ""))
                For Each oOrthoPhoto As cSurvey.Surface.cOrthoPhoto In oSurvey.Surface.OrthoPhotos
                    'If oOrthoPhoto.ShowIn3D Then
                    Call cboOrthophoto.Items.Add(New cComboItem(oOrthoPhoto, oOrthoPhoto.Name))
                    If oOrthoPhoto.Default Then
                        cboOrthophoto.SelectedIndex = cboOrthophoto.Items.Count - 1
                    End If
                    'End If
                Next
                cboOrthophoto.Enabled = cboOrthophoto.Items.Count > 0
                lblOrthophoto.Enabled = cboOrthophoto.Enabled
            Else
                cboElevationData.Enabled = False
                lblElevationData.Enabled = cboElevationData.Enabled
                cboOrthophoto.Enabled = False
                lblOrthophoto.Enabled = cboOrthophoto.Enabled
            End If

            Call linkedSurveys.Rebind(oSurvey.LinkedSurveys, "loch")
            linkedSurveys.Enabled = True
        Else
            cboElevationData.Enabled = False
            lblElevationData.Enabled = cboElevationData.Enabled
            cboOrthophoto.Enabled = False
            lblOrthophoto.Enabled = cboOrthophoto.Enabled

            linkedSurveys.Enabled = False
        End If
    End Sub

    Private Sub cboElevationData_DrawItem(sender As Object, e As System.Windows.Forms.DrawItemEventArgs) Handles cboElevationData.DrawItem
        If e.Index >= 0 Then
            Dim oGr As Graphics = e.Graphics
            oGr.CompositingQuality = CompositingQuality.HighQuality
            oGr.InterpolationMode = InterpolationMode.HighQualityBicubic
            oGr.SmoothingMode = SmoothingMode.AntiAlias
            oGr.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
            Dim bSelected As Boolean = (e.State And DrawItemState.Selected) = DrawItemState.Selected
            Dim oBounds As RectangleF = e.Bounds
            If bSelected Then
                Call oGr.FillRectangle(SystemBrushes.Highlight, oBounds)
                Call oGr.DrawRectangle(SystemPens.Highlight, oBounds.Left, oBounds.Top, oBounds.Width, oBounds.Height)
            Else
                Call oGr.FillRectangle(SystemBrushes.Window, oBounds)
                Call oGr.DrawRectangle(SystemPens.Window, oBounds.Left, oBounds.Top, oBounds.Width, oBounds.Height)
            End If

            Dim oItem As cComboItem = cboElevationData.Items(e.Index)
            Dim oElevation As cSurvey.Surface.cElevation = oItem.Source
            If Not oElevation Is Nothing Then
                Dim oImage As Image = oElevation.GetImage(New Size(48, 32))

                Call oGr.DrawImageUnscaled(oImage, e.Bounds.Left + 2, e.Bounds.Top + 2)
                Using oBorderPen As Pen = New Pen(Brushes.DarkGray)
                    Call oGr.DrawRectangle(oBorderPen, e.Bounds.Left + 2, e.Bounds.Top + 2, 48, e.Bounds.Height - 4)
                End Using

                Dim oLabelRect As RectangleF = New RectangleF(e.Bounds.Left + 48 + 2, e.Bounds.Top, e.Bounds.Right - (e.Bounds.Left + 48 + 2), e.Bounds.Height)

                Using oSF As StringFormat = New StringFormat
                    oSF.LineAlignment = StringAlignment.Center
                    oSF.Trimming = StringTrimming.EllipsisCharacter
                    If bSelected Then
                        Call oGr.DrawString(oElevation.Name, cboElevationData.Font, SystemBrushes.HighlightText, oLabelRect, oSF)
                    Else
                        Call oGr.DrawString(oElevation.Name, cboElevationData.Font, SystemBrushes.WindowText, oLabelRect, oSF)
                    End If
                End Using
            End If
        End If
    End Sub

    Private Sub cboElevationData_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboElevationData.SelectedIndexChanged
        cboOrthophoto.Enabled = cboElevationData.SelectedIndex > 0
        lblOrthophoto.Enabled = cboOrthophoto.Enabled
    End Sub

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        Call oSurvey.SharedSettings.SetValue("loch.showdialog", IIf(chkDoNotShow.Checked, "0", "1"))
        If cboElevationData.SelectedIndex > 0 Then
            Dim oElevation As cSurvey.Surface.cElevation = cboElevationData.SelectedItem.Source
            oElevation.Default = True

            If cboOrthophoto.SelectedIndex > 0 Then
                Dim oOrthoPhoto As cSurvey.Surface.cOrthoPhoto = cboOrthophoto.SelectedItem.Source
                oOrthoPhoto.Default = True
            Else
                For Each oOrthoPhoto As cSurvey.Surface.cOrthoPhoto In oSurvey.Surface.OrthoPhotos
                    If oOrthoPhoto.Default Then
                        oOrthoPhoto.Default = False
                    End If
                Next
            End If
        Else
            For Each oElevation As cSurvey.Surface.cElevation In oSurvey.Surface.Elevations
                If oElevation.Default Then
                    oElevation.Default = False
                End If
            Next
        End If
    End Sub

    Private Sub frmLochDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        chkDoNotShow.Checked = Integer.Parse(oSurvey.SharedSettings.GetValue("loch.showdialog", 1)) <> 1
        If My.Computer.Keyboard.ShiftKeyDown Then
            chkDoNotShow.Checked = False
        End If
        If chkDoNotShow.Checked OrElse (Not cboElevationData.Enabled AndAlso Not cboOrthophoto.Enabled AndAlso Not linkedSurveys.Enabled) Then
            DialogResult = Windows.Forms.DialogResult.OK
            Call Close()
        End If
    End Sub

    Private Sub cboOrthophoto_DrawItem(sender As Object, e As System.Windows.Forms.DrawItemEventArgs) Handles cboOrthophoto.DrawItem
        If e.Index >= 0 Then
            Dim oGr As Graphics = e.Graphics
            oGr.CompositingQuality = CompositingQuality.HighQuality
            oGr.InterpolationMode = InterpolationMode.HighQualityBicubic
            oGr.SmoothingMode = SmoothingMode.AntiAlias
            oGr.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
            Dim bSelected As Boolean = (e.State And DrawItemState.Selected) = DrawItemState.Selected
            Dim oBounds As RectangleF = e.Bounds
            If bSelected Then
                Call oGr.FillRectangle(SystemBrushes.Highlight, oBounds)
                Call oGr.DrawRectangle(SystemPens.Highlight, oBounds.Left, oBounds.Top, oBounds.Width, oBounds.Height)
            Else
                Call oGr.FillRectangle(SystemBrushes.Window, oBounds)
                Call oGr.DrawRectangle(SystemPens.Window, oBounds.Left, oBounds.Top, oBounds.Width, oBounds.Height)
            End If

            Dim oItem As cComboItem = cboOrthophoto.Items(e.Index)
            Dim oOrthoPhoto As cSurvey.Surface.cOrthoPhoto = oItem.Source
            If Not oOrthoPhoto Is Nothing Then
                Dim oImage As Image = oOrthoPhoto.GetImage(New Size(48, 32))

                Call oGr.DrawImageUnscaled(oImage, e.Bounds.Left + 2, e.Bounds.Top + 2)
                Using oBorderPen As Pen = New Pen(Brushes.DarkGray)
                    Call oGr.DrawRectangle(oBorderPen, e.Bounds.Left + 2, e.Bounds.Top + 2, 48, e.Bounds.Height - 4)
                End Using

                Dim oLabelRect As RectangleF = New RectangleF(e.Bounds.Left + 48 + 2, e.Bounds.Top, e.Bounds.Right - (e.Bounds.Left + 48 + 2), e.Bounds.Height)

                Using oSF As StringFormat = New StringFormat
                    oSF.LineAlignment = StringAlignment.Center
                    oSF.Trimming = StringTrimming.EllipsisCharacter
                    If bSelected Then
                        Call oGr.DrawString(oOrthoPhoto.Name, cboElevationData.Font, SystemBrushes.HighlightText, oLabelRect, oSF)
                    Else
                        Call oGr.DrawString(oOrthoPhoto.Name, cboElevationData.Font, SystemBrushes.WindowText, oLabelRect, oSF)
                    End If
                End Using
            End If
        End If
    End Sub
End Class