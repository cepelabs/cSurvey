Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Properties
Imports DevExpress.XtraGrid.Views.Base

Friend Class frmParametersSegments
    Private oOptions As cOptionsCenterline
    Private iApplyTo As cSurvey.Design.cIDesign.cDesignTypeEnum

    Private bEventDisabled As Boolean

    Public Sub New(ByVal Options As cOptionsCenterline, ByVal ApplyTo As cSurvey.Design.cIDesign.cDesignTypeEnum)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oOptions = Options
        iApplyTo = ApplyTo

        bEventDisabled = True

        chkSurface.Checked = (oOptions.DrawSegmentsOptions And cOptionsDesign.DrawSegmentsOptionsEnum.Surface) = cOptionsDesign.DrawSegmentsOptionsEnum.Surface
        chkDuplicate.Checked = (oOptions.DrawSegmentsOptions And cOptionsDesign.DrawSegmentsOptionsEnum.Duplicate) = cOptionsDesign.DrawSegmentsOptionsEnum.Duplicate
        cboSegmentsPaintStyle.SelectedIndex = oOptions.DrawStyle

        grpsplay.enabled = Options.DrawSplay
        cboSplayStyle.SelectedIndex = oOptions.SplayStyle
        chkShowSplayLabel.Checked = oOptions.ShowSplayText

        If iApplyTo = cIDesign.cDesignTypeEnum.Profile Then
            grpSurface.Enabled = True
            chkSurfaceProfile.Checked = oOptions.DrawSurfaceProfile
        Else
            grpSurface.Enabled = False
        End If

        chkShowHLs.Checked = oOptions.DrawHighlights
        grdHighlights.Enabled = oOptions.DrawHighlights
        grdHighlights.DataSource = oOptions.Survey.Properties.HighlightsDetails

        bEventDisabled = False
    End Sub

    Private Sub grdViewHighlights_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs) Handles grdViewHighlights.CustomUnboundColumnData
        If e.IsGetData Then
            If e.Column Is colHLSelected Then
                e.Value = oOptions.HighlightsOptions.Get(DirectCast(e.Row, Properties.cHighlightsDetail))
            End If
        Else
            If e.Column Is colHLSelected Then
                Call oOptions.HighlightsOptions.Set(DirectCast(e.Row, Properties.cHighlightsDetail), e.Value)
            End If
        End If
    End Sub

    'Public Sub Save() Implements cIPrintExportParameters.Save
    '    oOptions.DrawSegmentsOptions = cOptions.DrawSegmentsOptionsEnum.None
    '    If chkSurface.Checked Then oOptions.DrawSegmentsOptions = oOptions.DrawSegmentsOptions Or cOptions.DrawSegmentsOptionsEnum.Surface
    '    If chkDuplicate.Checked Then oOptions.DrawSegmentsOptions = oOptions.DrawSegmentsOptions Or cOptions.DrawSegmentsOptionsEnum.Duplicate
    '    oOptions.DrawStyle = cboSegmentsPaintStyle.SelectedIndex
    '    oOptions.DrawHighlights = chkShowHLs.Checked
    '    oOptions.SplayStyle = cboSplayStyle.SelectedIndex
    'End Sub

    Private Sub chkShowHLs_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowHLs.CheckedChanged
        grdHighlights.Enabled = chkShowHLs.Checked
        If Not oOptions Is Nothing AndAlso Not bEventDisabled Then
            oOptions.DrawHighlights = chkShowHLs.Checked
        End If
    End Sub

    Private Sub chkDesignSurfaceProfile_CheckedChanged(sender As Object, e As EventArgs) Handles chkSurfaceProfile.CheckedChanged
        If Not oOptions Is Nothing AndAlso Not bEventDisabled Then
            oOptions.DrawSurfaceProfile = chkSurfaceProfile.Checked
        End If
    End Sub

    Private Sub cboSplayStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSplayStyle.SelectedIndexChanged
        If Not oOptions Is Nothing AndAlso Not bEventDisabled Then
            oOptions.SplayStyle = cboSplayStyle.SelectedIndex
        End If
    End Sub

    Private Sub cboSegmentsPaintStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSegmentsPaintStyle.SelectedIndexChanged
        If Not oOptions Is Nothing AndAlso Not bEventDisabled Then
            oOptions.DrawStyle = cboSegmentsPaintStyle.SelectedIndex
        End If
    End Sub

    Private Sub chkSurface_CheckedChanged(sender As Object, e As EventArgs) Handles chkSurface.CheckedChanged
        If Not oOptions Is Nothing AndAlso Not bEventDisabled Then
            If chkSurface.Checked Then
                oOptions.DrawSegmentsOptions = oOptions.DrawSegmentsOptions Or cOptionsDesign.DrawSegmentsOptionsEnum.Surface
            Else
                oOptions.DrawSegmentsOptions = oOptions.DrawSegmentsOptions And Not cOptionsDesign.DrawSegmentsOptionsEnum.Surface
            End If
        End If
    End Sub

    Private Sub chkDuplicate_CheckedChanged(sender As Object, e As EventArgs) Handles chkDuplicate.CheckedChanged
        If chkDuplicate.Checked Then
            oOptions.DrawSegmentsOptions = oOptions.DrawSegmentsOptions Or cOptionsDesign.DrawSegmentsOptionsEnum.Duplicate
        Else
            oOptions.DrawSegmentsOptions = oOptions.DrawSegmentsOptions And Not cOptionsDesign.DrawSegmentsOptionsEnum.Duplicate
        End If
    End Sub

    Private Sub chkDesignPlotShowSplayLabel_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowSplayLabel.CheckedChanged
        If Not oOptions Is Nothing AndAlso Not bEventDisabled Then
            oOptions.ShowSplayText = chkShowSplayLabel.Checked
        End If
    End Sub
End Class