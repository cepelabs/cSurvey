Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Options
Imports DevExpress.XtraGrid.Views.Base

Public Class cDesignSurfaceControl

    'Private Sub oSurvey_OnPropertiesChanged(ByVal Sender As Object, ByVal Args As cSurveyPC.cSurvey.cSurvey.OnPropertiesChangedEventArgs)
    '    'If Args.Source = cSurvey.cSurvey.OnPropertiesChangedEventArgs.PropertiesChangeSourceEnum.DefaultProperties Then
    '    '    grdSurfaceLayers.BeginUpdate()
    '    '    If TypeOf MyBase.Design Is cDesign3D Then
    '    '        Dim oSurfaceOptions As cSurface3DOptions = DirectCast(MyBase.Options, cOptions3D).SurfaceOptions
    '    '        Call oSurfaceOptions.Rebind()
    '    '        grdSurfaceLayers.DataSource = Nothing
    '    '        'grdSurfaceLayers.DataSource = oSurfaceOptions
    '    '    ElseIf TypeOf MyBase.Design Is cDesignPlan Then
    '    '        Dim oSurfaceOptions As cSurfaceOptions = DirectCast(MyBase.Options, cOptionsDesign).SurfaceOptions
    '    '        Call oSurfaceOptions.Rebind()
    '    '        grdSurfaceLayers.DataSource = Nothing
    '    '        'grdSurfaceLayers.DataSource = oSurfaceOptions
    '    '    End If
    '    '    grdSurfaceLayers.EndUpdate()
    '    'End If
    'End Sub
    Public Shadows Sub Rebind(Design As cIDesign, Options As cOptions)
        MyBase.Rebind(Design, Options)

        If MyBase.Design.Survey.Properties.GPS.Enabled Then
            If TypeOf MyBase.Design Is cDesign3D Then
                Dim oSurfaceOptions As cSurface3DOptions = DirectCast(MyBase.Options, cOptions3D).SurfaceOptions
                chkSurface.Checked = oSurfaceOptions.DrawSurface
                Call pRefreshSize()

                trkTransparency.EditValue = oSurfaceOptions.Elevation.Transparency * 255

                cboSurfaceElevationsLayers.Rebind(Design.Survey, True, False)
                cboSurfaceElevationsLayers.SetSelectedElevation(oSurfaceOptions.Elevation.ID)

                pnlElevations.Visible = cboSurfaceElevationsLayers.Count > 0

                Call oSurfaceOptions.Rebind()
                grdSurfaceLayers.DataSource = Nothing
                grdSurfaceLayers.DataSource = oSurfaceOptions

                MyBase.Visible = True

                'AddHandler MyBase.Design.Survey.OnPropertiesChanged, AddressOf oSurvey_OnPropertiesChanged
            ElseIf TypeOf MyBase.Design Is cDesignPlan Then
                Dim oSurfaceOptions As cSurfaceOptions = DirectCast(MyBase.Options, cOptionsDesign).SurfaceOptions
                chkSurface.Checked = oSurfaceOptions.DrawSurface
                Call pRefreshSize()

                Call oSurfaceOptions.Rebind()
                grdSurfaceLayers.DataSource = Nothing
                grdSurfaceLayers.DataSource = oSurfaceOptions

                pnlElevations.Visible = False
                MyBase.Visible = True

                'AddHandler MyBase.Design.Survey.OnPropertiesChanged, AddressOf oSurvey_OnPropertiesChanged
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
        If e.Row IsNot Nothing Then
            If e.IsGetData AndAlso e.Row IsNot Nothing Then
                If e.Column Is colLayerName Then
                    Dim sID As String = DirectCast(e.Row, cISurfaceOptionsItem).ID
                    Dim oItem As Surface.cISurfaceItem = MyBase.Design.Survey.Surface(sID)
                    If oItem IsNot Nothing Then
                        e.Value = oItem.Name
                    End If
                ElseIf e.Column Is colLayerImage Then
                    Dim sID As String = DirectCast(e.Row, cISurfaceOptionsItem).ID
                    Dim oItem As Surface.cISurfaceItem = MyBase.Design.Survey.Surface(sID)
                    If oItem IsNot Nothing Then
                        If TypeOf oItem Is Surface.cOrthoPhoto Then
                            e.Value = My.Resources.map_raster
                        ElseIf TypeOf oItem Is Surface.cWMS Then
                            e.Value = My.Resources.map_wms
                        ElseIf TypeOf oItem Is Surface.cElevation Then
                            e.Value = My.Resources.soilmodeldata
                        End If
                    End If
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
            Dim oSurfaceOptions As cSurfaceOptions = DirectCast(MyBase.Options, cOptionsDesign).SurfaceOptions
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
            Dim oSurfaceOptions As cSurfaceOptions = DirectCast(MyBase.Options, cOptionsDesign).SurfaceOptions
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

    Private Sub pRefreshSize()
        Dim bChecked As Boolean = chkSurface.Checked
        If bChecked Then
            Height = 242 * Me.CurrentAutoScaleDimensions.Height / 96.0F
        Else
            Height = 32 * Me.CurrentAutoScaleDimensions.Height / 96.0F
        End If
    End Sub
    Private Sub chkSurface_CheckedChanged(sender As Object, e As EventArgs) Handles chkSurface.CheckedChanged
        If Not DisabledObjectProperty() Then
            If TypeOf MyBase.Design Is cDesign3D Then
                Dim oOptions3D As cOptions3D = MyBase.Options
                oOptions3D.SurfaceOptions.DrawSurface = chkSurface.Checked
                Call MyBase.PropertyChanged("DrawSurface")
                Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.SurfaceModel))
            Else
                Dim oOptions As cOptionsDesign = MyBase.Options
                oOptions.SurfaceOptions.DrawSurface = chkSurface.Checked
                Call MyBase.PropertyChanged("DrawSurface")
                Call MyBase.DrawInvalidate()
            End If
        End If
        Call pRefreshSize()
        If TypeOf MyBase.Design Is cDesign3D Then
            Dim oOptions3D As cOptions3D = MyBase.Options
            pnlSurface.Enabled = oOptions3D.SurfaceOptions.DrawSurface
        Else
            Dim oOptions As cOptionsDesign = MyBase.Options
            pnlSurface.Enabled = oOptions.SurfaceOptions.DrawSurface
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
                Dim oOptions3D As cOptions3D = MyBase.Options
                cmdSurfaceLayersUp.Enabled = oOptions3D.SurfaceOptions.IndexOf(oItem) > 0
                cmdSurfaceLayersDown.Enabled = oOptions3D.SurfaceOptions.IndexOf(oItem) < oOptions3D.SurfaceOptions.Count - 1
            Else
                Dim oOptions As cOptionsDesign = MyBase.Options
                cmdSurfaceLayersUp.Enabled = oOptions.SurfaceOptions.IndexOf(oItem) > 0
                cmdSurfaceLayersDown.Enabled = oOptions.SurfaceOptions.IndexOf(oItem) < oOptions.SurfaceOptions.Count - 1
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

    Private Sub grdViewSurfaceLayers_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles grdViewSurfaceLayers.PopupMenuShowing
        If e.HitInfo.InRowCell OrElse e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.EmptyRow Then
            e.Allow = False
            Call mnuContext.ShowPopup(grdSurfaceLayers.PointToScreen(e.Point))
        End If
    End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRefresh.ItemClick
        Call grdSurfaceLayers.BeginUpdate()
        If TypeOf MyBase.Design Is cDesign3D Then
            Dim oOptions3D As cOptions3D = MyBase.Options
            Dim oSurfaceOptions As cSurface3DOptions = oOptions3D.SurfaceOptions
            grdSurfaceLayers.DataSource = Nothing
            grdSurfaceLayers.DataSource = oSurfaceOptions
        Else
            Dim oOptions As cOptionsDesign = MyBase.Options
            Dim oSurfaceOptions As cSurfaceOptions = oOptions.SurfaceOptions
            grdSurfaceLayers.DataSource = Nothing
            grdSurfaceLayers.DataSource = oSurfaceOptions
        End If
        Call grdSurfaceLayers.EndUpdate()
    End Sub

    Private Sub btnSelectAll_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSelectAll.ItemClick
        Call grdSurfaceLayers.BeginUpdate()
        If TypeOf MyBase.Design Is cDesign3D Then
            Dim oOptions3D As cOptions3D = MyBase.Options
            For Each oItem As cISurfaceOptionsItem In oOptions3D.SurfaceOptions
                oItem.Visible = True
            Next
        Else
            Dim oOptions As cOptionsDesign = MyBase.Options
            For Each oItem As cISurfaceOptionsItem In oOptions.SurfaceOptions
                oItem.Visible = True
            Next
        End If
        Call grdSurfaceLayers.EndUpdate()
        Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.SurfaceTexture))
    End Sub

    Private Sub btnDeselectAll_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDeselectAll.ItemClick
        Call grdSurfaceLayers.BeginUpdate()
        If TypeOf MyBase.Design Is cDesign3D Then
            Dim oOptions3D As cOptions3D = MyBase.Options
            For Each oItem As cISurfaceOptionsItem In oOptions3D.SurfaceOptions
                oItem.Visible = False
            Next
        Else
            Dim oOptions As cOptionsDesign = MyBase.Options
            For Each oItem As cISurfaceOptionsItem In oOptions.SurfaceOptions
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

    Private Sub grdSurfaceLayers_Resize(sender As Object, e As EventArgs) Handles grdSurfaceLayers.Resize
        grdSurfaceLayers.Width = grdSurfaceLayers.Parent.Width - 38 * Me.CurrentAutoScaleDimensions.Height / 96.0F
    End Sub

    Private Sub cboSurfaceElevationsLayers_Resize(sender As Object, e As EventArgs) Handles cboSurfaceElevationsLayers.Resize
        cboSurfaceElevationsLayers.Width = cboSurfaceElevationsLayers.Parent.Width - 38 * Me.CurrentAutoScaleDimensions.Height / 96.0F
    End Sub

    Private Sub cboSurfaceElevationsLayers_SelectedIndexChanged_1(Sender As Object, e As EventArgs) Handles cboSurfaceElevationsLayers.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call DirectCast(MyBase.Options, cOptions3D).SurfaceOptions.SetElevation(cboSurfaceElevationsLayers.GetSelectedElevation.ID)
            Call MyBase.PropertyChanged("3DElevationModel")
            Call MyBase.DrawInvalidate(New cHolosViewer.cDrawInvalidateEventArgs(cHolosViewer.InvalidateType.SurfaceModel))
        End If
    End Sub

    Private Sub cDesignSurfaceControl_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        pnlSurface.Size = New Size(Width - pnlSurface.Left, Height - pnlSurface.Top)
    End Sub

End Class
