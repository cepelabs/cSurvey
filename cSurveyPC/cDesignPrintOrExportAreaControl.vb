Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design

Public Class cDesignPrintOrExportAreaControl
    Private oDesign As cDesign
    Private oOptions As cIOptionPrintAndExportArea

    Public Overrides Sub Rebind(Design As cIDesign, Options As cOptions)
        oDesign = Design
        oOptions = Options

        chkDesignPrintOrExportArea.Checked = oOptions.DrawPrintOrExportArea
        pnlDesignPrintOrExportArea.Enabled = chkDesignPrintOrExportArea.Checked
        Call cboDesignPrintOrExportAreaProfile.Items.Clear()
        For Each oProfile In oOptions.Survey.PreviewProfiles.ToList.Where(Function(item) item.Design = oDesign.Type)
            Call cboDesignPrintOrExportAreaProfile.Items.Add(oProfile)
        Next
        For Each oProfile In oOptions.Survey.ExportProfiles.ToList.Where(Function(item) item.Design = oDesign.Type)
            Call cboDesignPrintOrExportAreaProfile.Items.Add(oProfile)
        Next
        cboDesignPrintOrExportAreaProfile.SelectedItem = oOptions.GetPrintOrExportProfile(oDesign)
        cboDesignPrintOrExportAreaProfileDesignStyle.SelectedIndex = oOptions.DrawPrintOrExportAreaDesignStyle
    End Sub

    Private Sub chkDesignPrintOrExportArea_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPrintOrExportArea.CheckedChanged
        If Not DisabledObjectProperty() Then
            oOptions.DrawPrintOrExportArea = chkDesignPrintOrExportArea.Checked
            pnlDesignPrintOrExportArea.Enabled = chkDesignPrintOrExportArea.Checked
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("DrawPrintOrExportArea")
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    Private Sub cboDesignPrintOrExportAreaProfile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDesignPrintOrExportAreaProfile.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call oOptions.SetPrintOrExportProfile(cboDesignPrintOrExportAreaProfile.SelectedItem)
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("PrintOrExportProfile")
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    Private Sub cboDesignPrintOrExportAreaProfile_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cboDesignPrintOrExportAreaProfile.DrawItem
        Try
            Dim oGr As Graphics = e.Graphics
            e.DrawBackground()
            Dim bSelected As Boolean = (e.State And DrawItemState.Selected) = DrawItemState.Selected
            Dim sZoom As Single = 0.1
            Dim oProfile As cIProfile = cboDesignPrintOrExportAreaProfile.Items(e.Index)

            If TypeOf oProfile Is cExportProfile Then
                Call oGr.DrawImageUnscaled(My.Resources.page_white_put, e.Bounds.Left, e.Bounds.Top)
            Else
                Call oGr.DrawImageUnscaled(My.Resources.printer, e.Bounds.Left, e.Bounds.Top)
            End If
            Dim oLabelRect As RectangleF = New RectangleF(e.Bounds.Left + e.Bounds.Height + 2, e.Bounds.Top, e.Bounds.Right - (e.Bounds.Left + e.Bounds.Height + 2), e.Bounds.Height)

            Using oSF As StringFormat = New StringFormat
                oSF.LineAlignment = StringAlignment.Center
                oSF.Trimming = StringTrimming.EllipsisCharacter
                If bSelected Then
                    Call oGr.DrawString(oProfile.Name, cboDesignPrintOrExportAreaProfile.Font, SystemBrushes.HighlightText, oLabelRect, oSF)
                Else
                    Call oGr.DrawString(oProfile.Name, cboDesignPrintOrExportAreaProfile.Font, SystemBrushes.WindowText, oLabelRect, oSF)
                End If
            End Using
            If cboDesignPrintOrExportAreaProfile.Focused Then
                e.DrawFocusRectangle()
            End If
        Catch
        End Try
    End Sub

    Private Sub cboDesignPrintOrExportAreaProfileDesignStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDesignPrintOrExportAreaProfileDesignStyle.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            oOptions.DrawPrintOrExportAreaDesignStyle = cboDesignPrintOrExportAreaProfileDesignStyle.SelectedIndex
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("PrintOrExportProfile")
            Call MyBase.DrawInvalidate()
        End If
    End Sub
End Class
