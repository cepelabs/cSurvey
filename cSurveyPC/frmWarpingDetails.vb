Imports cSurveyPC.cSurvey.Calculate.Plot.cData
Imports cSurveyPC.cSurvey.Design

Public Class frmWarpingDetails
    Private sDeltaSizeLimit As Single = 0.05
    Private sDeltaXYLimit As Single = 0.05
    Private sDeltaAngleLimit As Single = 0.05

    Public Sub New(Segments As cSurvey.cISegmentCollection, DesignType As cIDesign.cDesignTypeEnum)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        For Each oSegment As cSurvey.cSegment In Segments
            Dim oFactor As cIWarpingFactor
            If DesignType = cIDesign.cDesignTypeEnum.Plan Then
                oFactor = oSegment.Data.PlanWarpingFactor
            Else
                oFactor = oSegment.Data.ProfileWarpingFactor
            End If
            Dim oData() = {oSegment.From, oSegment.To, oFactor.DeltaSize, oFactor.DeltaX, oFactor.DeltaY, oFactor.DeltaAngle}
            Dim iRow As Integer = grdStations.Rows.Add(oData)
            If oFactor.DeltaSize <> 1 Then
                If Math.Abs(1 - oFactor.DeltaSize) > sDeltaSizeLimit Then
                    grdStations.Rows(iRow).Cells(2).Style.BackColor = Color.PeachPuff
                Else
                    grdStations.Rows(iRow).Cells(2).Style.BackColor = Color.LightGreen
                End If
            End If
            If oFactor.DeltaX <> 0 Then
                If Math.Abs(oFactor.DeltaX / oSegment.Data.Data.Distance) > sDeltaXYLimit Then
                    grdStations.Rows(iRow).Cells(3).Style.BackColor = Color.PeachPuff
                Else
                    grdStations.Rows(iRow).Cells(3).Style.BackColor = Color.LightGreen
                End If
            End If
            If oFactor.DeltaY <> 0 Then
                If Math.Abs(oFactor.DeltaX / oSegment.Data.Data.Distance) > sDeltaXYLimit Then
                    grdStations.Rows(iRow).Cells(4).Style.BackColor = Color.PeachPuff
                Else
                    grdStations.Rows(iRow).Cells(4).Style.BackColor = Color.LightGreen
                End If
            End If
            If oFactor.DeltaAngle <> 0 Then
                If Math.Abs(oFactor.DeltaAngle / oSegment.Data.Data.Bearing) > sDeltaAngleLimit Then
                    grdStations.Rows(iRow).Cells(5).Style.BackColor = Color.PeachPuff
                Else
                    grdStations.Rows(iRow).Cells(5).Style.BackColor = Color.LightGreen
                End If
            End If
        Next
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
End Class