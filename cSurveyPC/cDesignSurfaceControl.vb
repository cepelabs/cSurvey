Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Options
Imports DevExpress.XtraGrid.Views.Base

Public Class cDesignSurfaceControl
    Public Overrides Sub Rebind(Design As cIDesign, Options As cOptions)
        MyBase.Rebind(Design, Options)

        If MyBase.Design.Survey.Properties.GPS.Enabled Then
            If TypeOf MyBase.Design Is cDesign3D Then
                Dim oSurfaceOptions As cSurface3DOptions = DirectCast(MyBase.Options, cOptions3D).SurfaceOptions
                chkSurface.Checked = oSurfaceOptions.DrawSurface

                trkTransparency.EditValue = oSurfaceOptions.Elevation.Transparency * 255

                cboSurfaceElevationsLayers.Properties.Items.Clear()
                Dim iElevation As Integer
                For Each oElevation As Surface.cISurfaceItem In MyBase.Design.Survey.Surface.Elevations
                    Dim oItem As DevExpress.XtraEditors.Controls.ImageComboBoxItem = New DevExpress.XtraEditors.Controls.ImageComboBoxItem(oElevation.Name, oElevation, iElevation)
                    oItem.ImageIndex = 0
                    Dim iElevationIndex As Integer = cboSurfaceElevationsLayers.Properties.Items.Add(oItem)
                    If Not oSurfaceOptions.Elevation Is Nothing AndAlso oSurfaceOptions.Elevation.ID = oElevation.ID Then
                        cboSurfaceElevationsLayers.SelectedIndex = iElevationIndex
                    End If
                    iElevation += 1
                Next
                If iElevation > 0 AndAlso cboSurfaceElevationsLayers.SelectedIndex < 0 Then
                    cboSurfaceElevationsLayers.SelectedIndex = 0
                End If
                pnlElevations.Visible = iElevation > 0

                Call oSurfaceOptions.Rebind()
                grdSurfaceLayers.DataSource = oSurfaceOptions

                MyBase.Visible = True
            ElseIf TypeOf MyBase.Design Is cDesignPlan Then
                Dim oSurfaceOptions As cSurfaceOptions = DirectCast(MyBase.Options, cOptions).SurfaceOptions
                chkSurface.Checked = oSurfaceOptions.DrawSurface

                Call oSurfaceOptions.Rebind()
                grdSurfaceLayers.DataSource = oSurfaceOptions

                pnlElevations.Visible = False
                MyBase.Visible = True
            Else
                MyBase.Visible = False
            End If
        Else
            MyBase.Visible = False
        End If
    End Sub

    Private Sub cmdSurfaceEdit_Click(sender As Object, e As EventArgs) Handles cmdSurfaceEdit.Click
        Call MyBase.DoCommand("SurfaceDetails")
    End Sub

    Private Sub cmdSurfaceLayersEdit_Click(sender As Object, e As EventArgs) Handles cmdSurfaceLayersEdit.Click
        If TypeOf MyBase.Design Is cDesign3D Then
            Dim oItem As cSurface3DOptions.cSurface3DOptionsItem = grdViewSurfaceLayers.GetFocusedObject
            If Not oItem Is Nothing Then
                Dim oCurrentOptions As cOptions3D = DirectCast(MyBase.Options, cOptions3D)
                Using frmSLP As frmSurface3DLayerProperties = New frmSurface3DLayerProperties(oItem)
                    If frmSLP.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.SurfaceTexture))
                    End If
                End Using
            End If
        Else
            Dim oItem As cSurfaceOptions.cSurfaceOptionsItem = grdViewSurfaceLayers.GetFocusedObject
            If Not oItem Is Nothing Then
                Using frmSLP As frmSurfaceLayerProperties = New frmSurfaceLayerProperties(oItem)
                    If frmSLP.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Call MyBase.DrawInvalidate()
                    End If
                End Using
            End If
        End If
    End Sub

    Private Sub grdViewSurfaceLayers_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs) Handles grdViewSurfaceLayers.CustomUnboundColumnData
        If e.IsGetData Then
            If e.Column Is colLayerName Then
                e.Value = MyBase.Design.Survey.Surface(DirectCast(e.Row, cISurfaceOptionsItem).ID).Name
            ElseIf e.Column Is colLayerImage Then
                Dim oItem As Surface.cISurfaceItem = MyBase.Design.Survey.Surface(DirectCast(e.Row, cISurfaceOptionsItem).ID)
                If TypeOf oItem Is Surface.cOrthoPhoto Then
                    e.Value = My.Resources.map_raster
                ElseIf TypeOf oItem Is Surface.cWMS Then
                    e.Value = My.Resources.map_wms
                ElseIf TypeOf oItem Is Surface.cElevation Then
                    e.Value = My.Resources.soilmodeldata
                End If
            End If
        End If
    End Sub

    Private Sub cmdSurfaceLayersUp_Click(sender As Object, e As EventArgs) Handles cmdSurfaceLayersUp.Click
        Call grdSurfaceLayers.BeginUpdate()
        If TypeOf MyBase.Design Is cDesign3D Then
            Dim oSurfaceOptions As cSurface3DOptions = DirectCast(MyBase.Options, cOptions3D).SurfaceOptions
            Dim oItem As cISurfaceOptionsItem = DirectCast(grdViewSurfaceLayers.GetFocusedObject, cISurfaceOptionsItem)
            If oSurfaceOptions.MoveUp(oItem) Then
                grdSurfaceLayers.DataSource = Nothing
                grdSurfaceLayers.DataSource = oSurfaceOptions
                Call grdViewSurfaceLayers.SetFocusedObject(oItem)
                Call MyBase.DrawInvalidate()
            End If
        Else
            Dim oSurfaceOptions As cSurfaceOptions = DirectCast(MyBase.Options, cOptions).SurfaceOptions
            Dim oItem As cISurfaceOptionsItem = DirectCast(grdViewSurfaceLayers.GetFocusedObject, cISurfaceOptionsItem)
            If oSurfaceOptions.MoveUp(oItem) Then
                grdSurfaceLayers.DataSource = Nothing
                grdSurfaceLayers.DataSource = oSurfaceOptions
                Call grdViewSurfaceLayers.SetFocusedObject(oItem)
                Call MyBase.DrawInvalidate()
            End If
        End If
        Call grdSurfaceLayers.EndUpdate()
    End Sub

    Private Sub cmdSurfaceLayersDown_Click(sender As Object, e As EventArgs) Handles cmdSurfaceLayersDown.Click
        Call grdSurfaceLayers.BeginUpdate()
        If TypeOf MyBase.Design Is cDesign3D Then
            Dim oSurfaceOptions As cSurface3DOptions = DirectCast(MyBase.Options, cOptions3D).SurfaceOptions
            Dim oItem As cISurfaceOptionsItem = DirectCast(grdViewSurfaceLayers.GetFocusedObject, cISurfaceOptionsItem)
            If oSurfaceOptions.MoveDown(oItem) Then
                grdSurfaceLayers.DataSource = Nothing
                grdSurfaceLayers.DataSource = oSurfaceOptions
                Call grdViewSurfaceLayers.SetFocusedObject(oItem)
                Call MyBase.DrawInvalidate()
            End If
        Else
            Dim oSurfaceOptions As cSurfaceOptions = DirectCast(MyBase.Options, cOptions).SurfaceOptions
            Dim oItem As cISurfaceOptionsItem = DirectCast(grdViewSurfaceLayers.GetFocusedObject, cISurfaceOptionsItem)
            If oSurfaceOptions.MoveDown(oItem) Then
                grdSurfaceLayers.DataSource = Nothing
                grdSurfaceLayers.DataSource = oSurfaceOptions
                Call grdViewSurfaceLayers.SetFocusedObject(oItem)
                Call MyBase.DrawInvalidate()
            End If
        End If
        Call grdSurfaceLayers.EndUpdate()
    End Sub

    Private Sub grdViewSurfaceLayers_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles grdViewSurfaceLayers.CellValueChanged
        If e.Column Is colLayerVisible Then
            If TypeOf MyBase.Design Is cDesign3D Then
                Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.SurfaceModel))
            Else
                Call MyBase.DrawInvalidate()
            End If
        End If
    End Sub

    Private Sub chkSurface_CheckedChanged(sender As Object, e As EventArgs) Handles chkSurface.CheckedChanged
        If Not DisabledObjectProperty() Then
            If TypeOf MyBase.Design Is cDesign3D Then
                Dim oOptions3D As cOptions3D = DirectCast(MyBase.Options, cOptions3D)
                oOptions3D.SurfaceOptions.DrawSurface = chkSurface.Checked
                pnlSurface.Enabled = oOptions3D.SurfaceOptions.DrawSurface
                Call MyBase.PropertyChanged("DrawSurface")
                Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.SurfaceModel))
            Else
                MyBase.Options.SurfaceOptions.DrawSurface = chkSurface.Checked
                pnlSurface.Enabled = MyBase.Options.SurfaceOptions.DrawSurface
                Call MyBase.PropertyChanged("DrawSurface")
                Call MyBase.DrawInvalidate()
            End If
        End If
    End Sub

    Private Sub chkLayerVisible_EditValueChanged(sender As Object, e As EventArgs) Handles chkLayerVisible.EditValueChanged
        Call grdViewSurfaceLayers.PostEditor()
    End Sub

    Private Sub trkLayerTransparency_EditValueChanged(sender As Object, e As EventArgs)
        Call grdViewSurfaceLayers.PostEditor()
    End Sub

    Private Sub grdViewSurfaceLayers_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles grdViewSurfaceLayers.FocusedRowChanged
        Dim oItem As cISurfaceOptionsItem = grdViewSurfaceLayers.GetFocusedObject
        Dim bEnabled As Boolean = Not oItem Is Nothing
        If bEnabled Then
            If TypeOf MyBase.Design Is cDesign3D Then
                Dim oOptions3D As cOptions3D = DirectCast(MyBase.Options, cOptions3D)
                cmdSurfaceLayersUp.Enabled = oOptions3D.SurfaceOptions.IndexOf(oItem) > 0
                cmdSurfaceLayersDown.Enabled = oOptions3D.SurfaceOptions.IndexOf(oItem) < oOptions3D.SurfaceOptions.Count - 1
            Else
                cmdSurfaceLayersUp.Enabled = MyBase.Options.SurfaceOptions.IndexOf(oItem) > 0
                cmdSurfaceLayersDown.Enabled = MyBase.Options.SurfaceOptions.IndexOf(oItem) < MyBase.Options.SurfaceOptions.Count - 1
            End If
            cmdSurfaceLayersEdit.Enabled = True
            btnEdit.Enabled = True
        Else
            cmdSurfaceLayersUp.Enabled = False
            cmdSurfaceLayersDown.Enabled = False
            cmdSurfaceLayersEdit.Enabled = False
            btnEdit.Enabled = False
        End If
    End Sub

    Private Sub trkTransparency_EditValueChanged(sender As Object, e As EventArgs) Handles trkTransparency.EditValueChanged
        If Not DisabledObjectProperty() Then
            DirectCast(MyBase.Options, cOptions3D).SurfaceOptions.Elevation.Transparency = trkTransparency.Value / 255
            Call MyBase.PropertyChanged("3DTransparency")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.SurfaceModel))
        End If
    End Sub

    Private Sub cboSurfaceElevationsLayers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSurfaceElevationsLayers.SelectedIndexChanged
        Call DirectCast(MyBase.Options, cOptions3D).SurfaceOptions.SetElevation(cboSurfaceElevationsLayers.SelectedItem.value)
        Call MyBase.PropertyChanged("3DElevationModel")
        Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.SurfaceModel))
    End Sub

    Private Sub grdViewSurfaceLayers_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles grdViewSurfaceLayers.PopupMenuShowing
        If e.HitInfo.InRowCell OrElse e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.EmptyRow Then
            e.Allow = False
            Call mnuContext.ShowPopup(grdSurfaceLayers.PointToScreen(e.Point))
        End If
    End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRefresh.ItemClick
        Call grdSurfaceLayers.BeginUpdate()
        If TypeOf MyBase.Design Is cDesign3D Then
            Dim oSurfaceOptions As cSurface3DOptions = DirectCast(MyBase.Options, cOptions3D).SurfaceOptions
            grdSurfaceLayers.DataSource = Nothing
            grdSurfaceLayers.DataSource = oSurfaceOptions
        Else
            Dim oSurfaceOptions As cSurfaceOptions = MyBase.Options.SurfaceOptions
            grdSurfaceLayers.DataSource = Nothing
            grdSurfaceLayers.DataSource = oSurfaceOptions
        End If
        Call grdSurfaceLayers.EndUpdate()
    End Sub

    Private Sub btnSelectAll_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSelectAll.ItemClick
        Call grdSurfaceLayers.BeginUpdate()
        If TypeOf MyBase.Design Is cDesign3D Then
            Dim oOptions3D As cOptions3D = DirectCast(MyBase.Options, cOptions3D)
            For Each oItem As cISurfaceOptionsItem In oOptions3D.SurfaceOptions
                oItem.Visible = True
            Next
        Else
            For Each oItem As cISurfaceOptionsItem In MyBase.Options.SurfaceOptions
                oItem.Visible = True
            Next
        End If
        Call grdSurfaceLayers.EndUpdate()
        Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.SurfaceTexture))
    End Sub

    Private Sub btnDeselectAll_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDeselectAll.ItemClick
        Call grdSurfaceLayers.BeginUpdate()
        If TypeOf MyBase.Design Is cDesign3D Then
            Dim oOptions3D As cOptions3D = DirectCast(MyBase.Options, cOptions3D)
            For Each oItem As cISurfaceOptionsItem In oOptions3D.SurfaceOptions
                oItem.Visible = False
            Next
        Else
            For Each oItem As cISurfaceOptionsItem In MyBase.Options.SurfaceOptions
                oItem.Visible = False
            Next
        End If
        Call grdSurfaceLayers.EndUpdate()
        Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.SurfaceTexture))
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        Call cmdSurfaceLayersEdit.PerformClick()
    End Sub

    Private Sub btnSurface_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSurface.ItemClick
        cmdSurfaceEdit.PerformClick()
    End Sub

    'Private Sub chkDesignPlotShowTrigpointText_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPlotShowTrigpointText.CheckedChanged
    '    If Not DisabledObjectProperty() Then
    '        mybase.options.ShowPointText = chkDesignPlotShowTrigpointText.Checked
    '        Call MyBase.PropertyChanged("PlotShowTrigpointText")
    '        Call MyBase.DrawInvalidate()
    '    End If
    'End Sub

    'Private Sub btnDesignRings_Click(sender As Object, e As EventArgs) Handles btnDesignRings.Click
    '    Call MyBase.DoCommand("RingsDetails")
    'End Sub
End Class
