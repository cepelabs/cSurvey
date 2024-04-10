Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports DevExpress.XtraGrid.Views.Base

Public Class cDesign3DModelControl

    Public Shadows ReadOnly Property Options As cOptions3D
        Get
            Return MyBase.Options
        End Get
    End Property

    Public Shadows Sub Rebind(Design As cIDesign, Options As cOptions)
        MyBase.Rebind(Design, Options)

        chkDesignPlot.Checked = Me.Options.DrawPlot

        pnlDesignPlot.Enabled = Me.Options.DrawPlot
        chkDesignPlotShowSegment.Checked = Me.Options.DrawSegments
        chkDesignPlotShowSegmentDuplicate.Enabled = Me.Options.DrawSegments
        chkDesignPlotShowSegmentSurface.Enabled = Me.Options.DrawSegments

        chkDesignPlotShowLRUD.Checked = Me.Options.DrawLRUD
        cboDesignPlotSegmentsPaintStyle.Enabled = chkDesignPlotShowLRUD.Checked 'oCurrentOptions.DrawSegments And chkDesignPlotShowLRUD.Checked
        cboDesignPlotSegmentsPaintStyle.SelectedIndex = Me.Options.DrawStyle

        cboDesignPlotColorMode.SelectedIndex = Me.Options.CenterlineColorMode

        chkDesignPlotShowSplay.Checked = Me.Options.DrawSplay
        cboDesignPlotSplayStyle.Enabled = Me.Options.DrawSplay
        chkDesignPlotShowSplayLabel.Enabled = Me.Options.DrawSplay

        cboDesignPlotSplayStyle.SelectedIndex = Me.Options.SplayStyle
        chkDesignPlotShowSplayLabel.Checked = Me.Options.ShowSplayText
        chkDesignPlotShowTrigpoint.Checked = Me.Options.DrawPoints
        chkDesignPlotShowTrigpointText.Checked = Me.Options.ShowPointText

        chkShowModel.Checked = Me.Options.DrawModel
        pnlModel.Enabled = chkShowModel.Checked
        cboModelMode.SelectedIndex = Me.Options.DrawModelMode - 1
        cboModelColoringMode.SelectedIndex = Me.Options.DrawModelColoringMode
        chkModelColorGray.Checked = Me.Options.CenterlineColorGray

        chkShowChunks.Checked = Me.Options.DrawChunks
        pnlChunk.Enabled = chkShowChunks.Checked
        cboChunkColoringMode.SelectedIndex = Me.Options.DrawChunkColoringMode
        chkChunkColorGray.Enabled = Me.Options.DrawChunkColoringMode = cOptions3D.ChunkColoringMode.CavesAndBranches
        chkChunkColorGray.Checked = Me.Options.ChunkColorGray

        chk3dPlotModelExtendedElevation.Visible = bIsInDebug
    End Sub

    Private Sub chkDesignPlotShowTrigpointText_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotShowTrigpointText.CheckedChanged
        If Not DisabledObjectProperty() Then
            Me.Options.ShowPointText = chkDesignPlotShowTrigpointText.Checked
            Call MyBase.PropertyChanged("3DPlotShowTrigpointText")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.Caves))
        End If
    End Sub

    Private Sub chkDesignPlotShowTrigpoint_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotShowTrigpoint.CheckedChanged
        If Not DisabledObjectProperty() Then
            Me.Options.DrawPoints = chkDesignPlotShowTrigpoint.Checked
            Call MyBase.PropertyChanged("3DPlotShowTrigpoint")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.Caves))
        End If
    End Sub

    Private Sub chkDesignPlotShowSplayLabel_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotShowSplayLabel.CheckedChanged
        If Not DisabledObjectProperty() Then
            Me.Options.ShowSplayText = chkDesignPlotShowSplayLabel.Checked
            Call MyBase.PropertyChanged("3DPlotShowSplayLabel")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.Caves))
        End If
    End Sub

    Private Sub chkDesignPlotShowLRUD_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotShowLRUD.CheckedChanged
        If Not DisabledObjectProperty() Then
            Me.Options.DrawLRUD = chkDesignPlotShowLRUD.Checked
            cboDesignPlotSegmentsPaintStyle.Enabled = Me.Options.DrawSegments And chkDesignPlotShowLRUD.Checked
            Call MyBase.PropertyChanged("3DPlotShowLRUD")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.Caves))
        End If
    End Sub

    Private Sub chkDesignPlotShowSegment_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotShowSegment.CheckedChanged
        If Not DisabledObjectProperty() Then
            Me.Options.DrawSegments = chkDesignPlotShowSegment.Checked
            chkDesignPlotShowSegmentDuplicate.Enabled = Me.Options.DrawSegments
            chkDesignPlotShowSegmentSurface.Enabled = Me.Options.DrawSegments
            Call MyBase.PropertyChanged("3DPlotShowSegment")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.Caves))
        End If
    End Sub

    Private Sub chkDesignPlotShowSurface_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotShowSegmentSurface.CheckedChanged
        If Not DisabledObjectProperty() Then
            Me.Options.DrawSegmentsOptions = Me.Options.DrawSegmentsOptions Or If(chkDesignPlotShowSegmentSurface.Checked, cOptionsDesign.DrawSegmentsOptionsEnum.Surface, Not cOptionsDesign.DrawSegmentsOptionsEnum.Surface)
            Call MyBase.PropertyChanged("3DPlotShowSegmentSurface")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.Caves))
        End If
    End Sub

    Private Sub chkDesignPlotShowSegmentDuplicate_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotShowSegmentDuplicate.CheckedChanged
        If Not DisabledObjectProperty() Then
            Me.Options.DrawSegmentsOptions = Me.Options.DrawSegmentsOptions Or If(chkDesignPlotShowSegmentDuplicate.Checked, cOptionsDesign.DrawSegmentsOptionsEnum.Duplicate, Not cOptionsDesign.DrawSegmentsOptionsEnum.Duplicate)
            Call MyBase.PropertyChanged("3DPlotShowSegmentDuplicate")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.Caves))
        End If
    End Sub

    Private Sub cboDesignPlotSegmentsPaintStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDesignPlotSegmentsPaintStyle.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Me.Options.DrawStyle = cboDesignPlotSegmentsPaintStyle.SelectedIndex
            Call Me.Options.DrawingObjects.Rebind()
            Call MyBase.PropertyChanged("3DPlotSegmentsPaintStyle")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.Caves))
        End If
    End Sub

    Private Sub cboDesignPlotSplayStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDesignPlotSplayStyle.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Me.Options.SplayStyle = cboDesignPlotSplayStyle.SelectedIndex
            Call MyBase.PropertyChanged("3DPlotSplayStyle")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.Caves))
        End If
    End Sub

    Private Sub chkDesignPlot_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlot.CheckedChanged
        If Not DisabledObjectProperty() Then
            Me.Options.DrawPlot = chkDesignPlot.Checked
            pnlDesignPlot.Enabled = Me.Options.DrawPlot
            Call MyBase.PropertyChanged("3DPlotDrawPlot")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.Caves))
        End If
    End Sub

    Private Sub cboDesignPlotColorMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDesignPlotColorMode.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Me.Options.CenterlineColorMode = cboDesignPlotColorMode.SelectedIndex
            Call MyBase.PropertyChanged("3DPlotColorMode")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.Caves))
        End If
    End Sub

    Private Sub chkDesignPlotColorGray_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotColorGray.CheckedChanged
        If Not DisabledObjectProperty() Then
            Me.Options.CenterlineColorGray = chkDesignPlotColorGray.Checked
            Call MyBase.PropertyChanged("3DPlotColorGray")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.Caves))
        End If
    End Sub

    Private Sub chkShowModel_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowModel.CheckedChanged
        If Not DisabledObjectProperty Then
            Me.Options.DrawModel = chkShowModel.Checked
            pnlModel.Enabled = Me.Options.DrawModel
            Call MyBase.PropertyChanged("3DShowModel")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.ModelMode))
        End If
    End Sub

    Private Sub chk3dModelColorGray_CheckedChanged(sender As Object, e As EventArgs) Handles chkModelColorGray.CheckedChanged
        If Not DisabledObjectProperty Then
            Me.Options.ModelColorGray = chkModelColorGray.Checked
            Call MyBase.PropertyChanged("3DModelColorGray")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.ModelMode))
        End If
    End Sub

    Private Sub cboModelColoringMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboModelColoringMode.SelectedIndexChanged
        If Not DisabledObjectProperty Then
            Me.Options.DrawModelColoringMode = cboModelColoringMode.SelectedIndex
            Call MyBase.PropertyChanged("3DModelColoringMode")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.ModelMode))
        End If
    End Sub

    Private Sub cboModelMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboModelMode.SelectedIndexChanged
        If Not DisabledObjectProperty Then
            Me.Options.DrawModelMode = cboModelMode.SelectedIndex + 1
            Call MyBase.PropertyChanged("3DModelMode")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.ModelMode))
        End If
    End Sub

    Private Sub chkDesignPlotShowSplay_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotShowSplay.CheckedChanged
        If Not DisabledObjectProperty Then
            Dim bEnabled As Boolean = chkDesignPlotShowSplay.Checked
            Me.Options.DrawSplay = bEnabled
            cboDesignPlotSplayStyle.Enabled = bEnabled
            chkDesignPlotShowSplayLabel.Enabled = bEnabled
            Call MyBase.PropertyChanged("3DModelShowSplay")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.ModelMode))
        End If
    End Sub

    Private Sub chkShowChunks_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowChunks.CheckedChanged
        If Not DisabledObjectProperty Then
            Me.Options.DrawChunks = chkShowChunks.Checked
            pnlChunk.Enabled = Me.Options.DrawChunks
            Call MyBase.PropertyChanged("3DShowChunks")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.Chunks))
        End If
    End Sub

    Private Sub cboChunkColoringMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboChunkColoringMode.SelectedIndexChanged
        If Not DisabledObjectProperty Then
            Me.Options.DrawChunkColoringMode = cboChunkColoringMode.SelectedIndex
            chkChunkColorGray.Enabled = Me.Options.DrawChunkColoringMode = cOptions3D.ChunkColoringMode.CavesAndBranches
            Call MyBase.PropertyChanged("3DChunkColoringMode")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.Chunks))
        End If
    End Sub

    Private Sub chkChunkColorGray_CheckedChanged(sender As Object, e As EventArgs) Handles chkChunkColorGray.CheckedChanged
        If Not DisabledObjectProperty Then
            Me.Options.ChunkColorGray = chkChunkColorGray.Checked
            Call MyBase.PropertyChanged("ChunkColorGray")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.Chunks))
        End If
    End Sub

End Class
