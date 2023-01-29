Imports cSurveyPC
Imports cSurveyPC.cSurvey.Calculate.Plot.cData
Imports cSurveyPC.cSurvey.Design
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Grid

friend Class frmWarpingDetails
    Private iDesignType As cIDesign.cDesignTypeEnum
    Private sDeltaSizeLimit As Single = 0.05
    Private sDeltaXYLimit As Single = 0.05
    Private sDeltaAngleLimit As Single = 0.05

    Private Class cWarpingDetails
        Private oSegment As cSurvey.cSegment
        Private oDetails As cIWarpingFactor

        Public ReadOnly Property Segment As cSurvey.cSegment
            Get
                Return oSegment
            End Get
        End Property

        Public ReadOnly Property Details As cIWarpingFactor
            Get
                Return oDetails
            End Get
        End Property

        Public Sub New(Segment As cSurvey.cSegment, Details As cIWarpingFactor)
            oSegment = Segment
            oDetails = Details
        End Sub
    End Class

    Private Sub gridviewDetails_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles gridviewDetails.RowCellStyle
        If e.Column Is colDetailsDeltaSize Then
            Dim oDetail As cWarpingDetails = gridviewDetails.GetRow(e.RowHandle)
            If oDetail.Details.DeltaSize <> 1 Then
                If Math.Abs(oDetail.Details.DeltaSize) > 0 Then
                    If Math.Abs(1 - oDetail.Details.DeltaSize) > sDeltaSizeLimit Then
                        e.Appearance.BackColor = modDevExpress.SkinBackcolor(Color.PeachPuff)
                    Else
                        e.Appearance.BackColor = modDevExpress.SkinBackcolor(Color.LightGreen)
                    End If
                End If
            End If
        ElseIf e.Column Is colDetailsDeltaX Then
            Dim oDetail As cWarpingDetails = gridviewDetails.GetRow(e.RowHandle)
            If Math.Abs(oDetail.Details.DeltaX) > 0 Then
                If Math.Abs(oDetail.Details.DeltaX) > sDeltaXYLimit Then
                    e.Appearance.BackColor = modDevExpress.SkinBackcolor(Color.PeachPuff)
                Else
                    e.Appearance.BackColor = modDevExpress.SkinBackcolor(Color.LightGreen)
                End If
            End If
        ElseIf e.Column Is colDetailsDeltaY Then
            Dim oDetail As cWarpingDetails = gridviewDetails.GetRow(e.RowHandle)
            If Math.Abs(oDetail.Details.DeltaX) > 0 Then
                If Math.Abs(oDetail.Details.DeltaX) > sDeltaXYLimit Then
                    e.Appearance.BackColor = modDevExpress.SkinBackcolor(Color.PeachPuff)
                Else
                    e.Appearance.BackColor = modDevExpress.SkinBackcolor(Color.LightGreen)
                End If
            End If
        ElseIf e.Column Is colDetailsDeltaAngle Then
            Dim oDetail As cWarpingDetails = gridviewDetails.GetRow(e.RowHandle)
            If Math.Abs(oDetail.Details.DeltaAngle) > 0 Then
                If Math.Abs(oDetail.Details.DeltaAngle) > sDeltaAngleLimit Then
                    e.Appearance.BackColor = modDevExpress.SkinBackcolor(Color.PeachPuff)
                Else
                    e.Appearance.BackColor = modDevExpress.SkinBackcolor(Color.LightGreen)
                End If
            End If
        ElseIf e.Column Is colDetailsNewSize OrElse e.Column Is colDetailsOldSize Then
            Dim oDetail As cWarpingDetails = gridviewDetails.GetRow(e.RowHandle)
            If oDetail.Details.IsCritical Then e.Appearance.BackColor = modDevExpress.SkinBackcolor(Color.PeachPuff)
        End If
    End Sub

    Public Sub New(Segments As cSurvey.cISegmentCollection, DesignType As cIDesign.cDesignTypeEnum)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        iDesignType = DesignType
        grdDetails.DataSource = Segments.ToList.Select(Function(oSegment)
                                                           If DesignType = cIDesign.cDesignTypeEnum.Plan Then
                                                               Return New cWarpingDetails(oSegment, oSegment.Data.PlanWarpingFactor)
                                                           Else
                                                               Return New cWarpingDetails(oSegment, oSegment.Data.ProfileWarpingFactor)
                                                           End If
                                                       End Function).ToList
    End Sub

    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click
        DialogResult = DialogResult.OK
        Call Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        DialogResult = DialogResult.Abort
        Call Close()
    End Sub

    Private Sub cmdCancelAndPause_Click(sender As Object, e As EventArgs) Handles cmdCancelAndPause.Click
        DialogResult = DialogResult.Ignore
        Call Close()
    End Sub

    Private Sub gridviewDetails_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles gridviewDetails.PopupMenuShowing
        e.Allow = False
        Call mnuDetails.ShowPopup(grdDetails.PointToScreen(e.Point))
    End Sub

    Private Sub btnShowMoreDetails_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles btnShowMoreDetails.CheckedChanged
        Dim bVisible As Boolean = btnShowMoreDetails.Checked
        colDetailsNewSize.Visible = bVisible
        colDetailsOldSize.Visible = bVisible
        colDetailsNewX.Visible = bVisible
        colDetailsOldX.Visible = bVisible
        colDetailsNewY.Visible = bVisible
        colDetailsOldY.Visible = bVisible
        colDetailsNewAngle.Visible = bVisible
        colDetailsOldAngle.Visible = bVisible
    End Sub

    Private Sub frmWarpingDetails_FormSettingsLoad(Sender As Object, e As FormSettingsEventArgs) Handles Me.FormSettingsLoad
        btnShowMoreDetails.Checked = e.GetSetting("showmoredetails", 0)
    End Sub

    Private Sub frmWarpingDetails_FormSettingsSave(Sender As Object, e As FormSettingsEventArgs) Handles Me.FormSettingsSave
        Call e.SetSetting("showmoredetails", If(btnShowMoreDetails.Checked, "1", "0"))
    End Sub

    Private Sub gridviewDetails_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles gridviewDetails.CustomUnboundColumnData
        If e.IsGetData Then
            If e.Column Is colDetailsState Then
                Dim oDetail As cWarpingDetails = e.Row
                e.Value = If(oDetail.Details.IsCritical, My.Resources.error2, Nothing)
            End If
        End If
    End Sub

    Private Sub gridviewDetails_RowStyle(sender As Object, e As RowStyleEventArgs) Handles gridviewDetails.RowStyle
        Dim oDetail As cWarpingDetails = gridviewDetails.GetRow(e.RowHandle)
        If Not IsNothing(oDetail) Then
            If oDetail.Details.IsCritical Then e.Appearance.BackColor = Color.FromArgb(200, Color.PeachPuff)
        End If
    End Sub
End Class