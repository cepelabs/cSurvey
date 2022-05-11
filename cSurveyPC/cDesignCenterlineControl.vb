Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports DevExpress.XtraGrid.Views.Base

Public Class cDesignCenterlineControl
    Public Overrides Sub Rebind(Design As cIDesign, Options As cOptions)
        Call MyBase.Rebind(Design, Options)

        chkDesignPlot.Checked = MyBase.Options.DrawPlot

        pnlDesignPlot.Enabled = MyBase.Options.DrawPlot
        chkDesignPlotShowSegment.Checked = MyBase.Options.DrawSegments
        chkDesignPlotShowSegmentDuplicate.Enabled = MyBase.Options.DrawSegments
        chkDesignPlotShowSegmentSurface.Enabled = MyBase.Options.DrawSegments

        chkDesignPlotShowLRUD.Checked = MyBase.Options.DrawLRUD
        cboDesignPlotSegmentsPaintStyle.Enabled = chkDesignPlotShowLRUD.Checked 'oCurrentOptions.DrawSegments And chkDesignPlotShowLRUD.Checked
        cboDesignPlotSegmentsPaintStyle.SelectedIndex = MyBase.Options.DrawStyle

        cboDesignPlotColorMode.SelectedIndex = MyBase.Options.CenterlineColorMode

        chkDesignPlotShowSplay.Checked = MyBase.Options.DrawSplay
        cboDesignPlotSplayStyle.Enabled = MyBase.Options.DrawSplay
        chkDesignPlotShowSplayLabel.Enabled = MyBase.Options.DrawSplay
        chkDesignPlotShowSplayMode.Enabled = MyBase.Options.DrawSplay

        cboDesignPlotSplayStyle.SelectedIndex = MyBase.Options.SplayStyle
        chkDesignPlotShowSplayMode.Checked = MyBase.Options.ShowSplayMode = cOptions.ShowSplayModeEnum.All
        chkDesignPlotShowSplayLabel.Checked = MyBase.Options.ShowSplayText
        chkDesignPlotShowTrigpoint.Checked = MyBase.Options.DrawPoints
        chkDesignPlotShowTrigpointText.Checked = MyBase.Options.ShowPointText

        chkDesignPlotShowHLs.Checked = MyBase.Options.DrawHighlights
        grdHighlights.Enabled = MyBase.Options.DrawHighlights

        grdHighlights.DataSource = MyBase.Design.Survey.Properties.HighlightsDetails
        grdHighlights.Enabled = MyBase.Options.DrawHighlights

        'lvDesignPlotShowHLsDett.Items.Clear()
        'For Each oDetail As cHighlightsDetail In mybase.Design.Survey.Properties.HighlightsDetails
        '    Dim oItem As ListViewItem = New ListViewItem()
        '    oItem.Name = oDetail.ID
        '    oItem.Text = oDetail.Name
        '    oItem.Checked = mybase.options.HighlightsOptions.Get(oDetail)
        '    Call lvDesignPlotShowHLsDett.Items.Add(oItem)
        'Next

        'chkDesignPrintOrExportArea.Checked = mybase.options.DrawPrintOrExportArea
        'pnlDesignPrintOrExportArea.Enabled = chkDesignPrintOrExportArea.Checked
        'Call cboDesignPrintOrExportAreaProfile.Items.Clear()
        'For Each oProfile In mybase.options.Survey.PreviewProfiles.ToList.Where(Function(item) item.Design = mybase.Design.Type)
        '    Call cboDesignPrintOrExportAreaProfile.Items.Add(oProfile)
        'Next
        'For Each oProfile In mybase.options.Survey.ExportProfiles.ToList.Where(Function(item) item.Design = mybase.Design.Type)
        '    Call cboDesignPrintOrExportAreaProfile.Items.Add(oProfile)
        'Next
        'cboDesignPrintOrExportAreaProfile.SelectedItem = mybase.options.GetPrintOrExportProfile(mybase.Design)
        'cboDesignPrintOrExportAreaProfileDesignStyle.SelectedIndex = mybase.options.DrawPrintOrExportAreaDesignStyle
    End Sub

    Private Sub chkDesignPlotShowTrigpointText_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotShowTrigpointText.CheckedChanged
        If Not DisabledObjectProperty() Then
            MyBase.Options.ShowPointText = chkDesignPlotShowTrigpointText.Checked
            Call MyBase.PropertyChanged("PlotShowTrigpointText")
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    Private Sub chkDesignPlotShowTrigpoint_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotShowTrigpoint.CheckedChanged
        If Not DisabledObjectProperty() Then
            MyBase.Options.DrawPoints = chkDesignPlotShowTrigpoint.Checked
            Call MyBase.PropertyChanged("PlotShowTrigpoint")
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    Private Sub chkDesignPlotShowHLs_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotShowHLs.CheckedChanged
        If Not DisabledObjectProperty() Then
            MyBase.Options.DrawHighlights = chkDesignPlotShowHLs.Checked
            grdHighlights.Enabled = MyBase.Options.DrawHighlights
            Call MyBase.PropertyChanged("PlotShowHLs")
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    Private Sub chkDesignPlotShowSplayLabel_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotShowSplayLabel.CheckedChanged
        If Not DisabledObjectProperty() Then
            MyBase.Options.ShowSplayText = chkDesignPlotShowSplayLabel.Checked
            Call MyBase.PropertyChanged("PlotShowSplayLabel")
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    Private Sub chkDesignPlotShowSplayMode_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotShowSplayMode.CheckedChanged
        If Not DisabledObjectProperty() Then
            MyBase.Options.ShowSplayMode = If(chkDesignPlotShowSplayMode.Checked, cOptions.ShowSplayModeEnum.All, cOptions.ShowSplayModeEnum.OnlyInRange)
            Call MyBase.PropertyChanged("PlotShowSplayMode")
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    Private Sub chkDesignPlotShowSplay_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotShowSplay.CheckedChanged
        If Not DisabledObjectProperty() Then
            MyBase.Options.DrawSplay = chkDesignPlotShowSplay.Checked
            cboDesignPlotSplayStyle.Enabled = MyBase.Options.DrawSplay
            chkDesignPlotShowSplayLabel.Enabled = MyBase.Options.DrawSplay
            chkDesignPlotShowSplayMode.Enabled = MyBase.Options.DrawSplay
            Call MyBase.PropertyChanged("PlotShowSplay")
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    Private Sub chkDesignPlotShowLRUD_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotShowLRUD.CheckedChanged
        If Not DisabledObjectProperty() Then
            MyBase.Options.DrawLRUD = chkDesignPlotShowLRUD.Checked
            cboDesignPlotSegmentsPaintStyle.Enabled = MyBase.Options.DrawSegments And chkDesignPlotShowLRUD.Checked
            Call MyBase.PropertyChanged("PlotShowLRUD")
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    Private Sub chkDesignPlotShowSegment_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotShowSegment.CheckedChanged
        If Not DisabledObjectProperty() Then
            MyBase.Options.DrawSegments = chkDesignPlotShowSegment.Checked
            chkDesignPlotShowSegmentDuplicate.Enabled = MyBase.Options.DrawSegments
            chkDesignPlotShowSegmentSurface.Enabled = MyBase.Options.DrawSegments
            Call MyBase.PropertyChanged("PlotShowSegment")
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    Private Sub chkDesignPlotShowSurface_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotShowSegmentSurface.CheckedChanged
        If Not DisabledObjectProperty() Then
            MyBase.Options.DrawSegmentsOptions = MyBase.Options.DrawSegmentsOptions Or If(chkDesignPlotShowSegmentSurface.Checked, cOptions.DrawSegmentsOptionsEnum.Surface, Not cOptions.DrawSegmentsOptionsEnum.Surface)
            Call MyBase.PropertyChanged("PlotShowSegmentSurface")
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    Private Sub chkDesignPlotShowSegmentDuplicate_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotShowSegmentDuplicate.CheckedChanged
        If Not DisabledObjectProperty() Then
            MyBase.Options.DrawSegmentsOptions = MyBase.Options.DrawSegmentsOptions Or If(chkDesignPlotShowSegmentDuplicate.Checked, cOptions.DrawSegmentsOptionsEnum.Duplicate, Not cOptions.DrawSegmentsOptionsEnum.Duplicate)
            Call MyBase.PropertyChanged("PlotShowSegmentDuplicate")
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    Private Sub cboDesignPlotSegmentsPaintStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDesignPlotSegmentsPaintStyle.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            MyBase.Options.DrawStyle = cboDesignPlotSegmentsPaintStyle.SelectedIndex
            Call MyBase.Options.DrawingObjects.Rebind()
            Call MyBase.PropertyChanged("PlotSegmentsPaintStyle")
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    Private Sub cboDesignPlotSplayStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDesignPlotSplayStyle.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            MyBase.Options.SplayStyle = cboDesignPlotSplayStyle.SelectedIndex
            Call MyBase.PropertyChanged("PlotSplayStyle")
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    Private Sub btnDesignRings_Click(sender As Object, e As EventArgs) Handles btnDesignRings.Click
        Call MyBase.DoCommand("RingsDetails")
    End Sub

    Private Sub btnDesignHighlights_Click(sender As Object, e As EventArgs) Handles btnDesignHighlights.Click
        Call MyBase.DoCommand("EditHighlights")
    End Sub

    Private Sub btnDesignPlotSplay_Click(sender As Object, e As EventArgs) Handles btnDesignPlotSplay.Click
        Call MyBase.DoCommand("SplayReplicateData")
    End Sub

    Private Sub chkDesignPlot_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlot.CheckedChanged
        If Not DisabledObjectProperty() Then
            MyBase.Options.DrawPlot = chkDesignPlot.Checked
            pnlDesignPlot.Enabled = MyBase.Options.DrawPlot
            Call MyBase.PropertyChanged("PlotDrawPlot")
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    Private Sub grdViewHighlights_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs) Handles grdViewHighlights.CustomUnboundColumnData
        If e.IsGetData Then
            If e.Column Is colHLSelected Then
                e.Value = MyBase.Options.HighlightsOptions.Get(DirectCast(e.Row, Properties.cHighlightsDetail))
            End If
        Else
            If e.Column Is colHLSelected Then
                Call MyBase.Options.HighlightsOptions.Set(DirectCast(e.Row, Properties.cHighlightsDetail), e.Value)
                Call MyBase.DrawInvalidate()
            End If
        End If
    End Sub

    Private Sub cboDesignPlotColorMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDesignPlotColorMode.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            MyBase.Options.CenterlineColorMode = cboDesignPlotColorMode.SelectedIndex
            Call MyBase.PropertyChanged("PlotColorMode")
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    Private Sub chkDesignPlotColorGray_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotColorGray.CheckedChanged
        If Not DisabledObjectProperty() Then
            MyBase.Options.CenterlineColorGray = chkDesignPlotColorGray.Checked
            Call MyBase.PropertyChanged("PlotColorGray")
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    'Private Sub chkDesignPrintOrExportArea_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPrintOrExportArea.CheckedChanged
    '    If Not DisabledObjectProperty() Then
    '        mybase.options.DrawPrintOrExportArea = chkDesignPrintOrExportArea.Checked
    '        pnlDesignPrintOrExportArea.Enabled = chkDesignPrintOrExportArea.Checked
    '        Call MyBase.TakeUndoSnapshot()
    '        Call MyBase.PropertyChanged("DrawPrintOrExportArea")
    '        Call MyBase.DrawInvalidate()
    '    End If
    'End Sub

    'Private Sub cboDesignPrintOrExportAreaProfile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDesignPrintOrExportAreaProfile.SelectedIndexChanged
    '    If Not DisabledObjectProperty() Then
    '        Call mybase.options.SetPrintOrExportProfile(cboDesignPrintOrExportAreaProfile.SelectedItem)
    '        Call MyBase.TakeUndoSnapshot()
    '        Call MyBase.PropertyChanged("PrintOrExportProfile")
    '        Call MyBase.DrawInvalidate()
    '    End If
    'End Sub

    'Private Sub cboDesignPrintOrExportAreaProfile_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cboDesignPrintOrExportAreaProfile.DrawItem
    '    Try
    '        Dim oGr As Graphics = e.Graphics
    '        e.DrawBackground()
    '        Dim bSelected As Boolean = (e.State And DrawItemState.Selected) = DrawItemState.Selected
    '        Dim sZoom As Single = 0.1
    '        Dim oProfile As cIProfile = cboDesignPrintOrExportAreaProfile.Items(e.Index)

    '        If TypeOf oProfile Is cExportProfile Then
    '            Call oGr.DrawImageUnscaled(My.Resources.page_white_put, e.Bounds.Left, e.Bounds.Top)
    '        Else
    '            Call oGr.DrawImageUnscaled(My.Resources.printer, e.Bounds.Left, e.Bounds.Top)
    '        End If
    '        Dim oLabelRect As RectangleF = New RectangleF(e.Bounds.Left + e.Bounds.Height + 2, e.Bounds.Top, e.Bounds.Right - (e.Bounds.Left + e.Bounds.Height + 2), e.Bounds.Height)

    '        Using oSF As StringFormat = New StringFormat
    '            oSF.LineAlignment = StringAlignment.Center
    '            oSF.Trimming = StringTrimming.EllipsisCharacter
    '            If bSelected Then
    '                Call oGr.DrawString(oProfile.Name, cboDesignPrintOrExportAreaProfile.Font, SystemBrushes.HighlightText, oLabelRect, oSF)
    '            Else
    '                Call oGr.DrawString(oProfile.Name, cboDesignPrintOrExportAreaProfile.Font, SystemBrushes.WindowText, oLabelRect, oSF)
    '            End If
    '        End Using
    '        If cboDesignPrintOrExportAreaProfile.Focused Then
    '            e.DrawFocusRectangle()
    '        End If
    '    Catch
    '    End Try
    'End Sub

    'Private Sub cboDesignPrintOrExportAreaProfileDesignStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDesignPrintOrExportAreaProfileDesignStyle.SelectedIndexChanged
    '    If Not DisabledObjectProperty() Then
    '        mybase.options.DrawPrintOrExportAreaDesignStyle = cboDesignPrintOrExportAreaProfileDesignStyle.SelectedIndex
    '        Call MyBase.TakeUndoSnapshot()
    '        Call MyBase.PropertyChanged("PrintOrExportProfile")
    '        Call MyBase.DrawInvalidate()
    '    End If
    'End Sub

    'Private Sub cmdDesignBaseRule_Click(sender As Object, e As EventArgs) Handles cmdDesignBaseRule.Click
    '    Using frmSR As frmScaleRules = New frmScaleRules(mybase.Design.Survey, frmScaleRules.EditStyleEnum.BaseRule, mybase.options.GetOption)
    '        If frmSR.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
    '            Call MyBase.DrawInvalidate()
    '        End If
    '    End Using
    'End Sub
End Class
