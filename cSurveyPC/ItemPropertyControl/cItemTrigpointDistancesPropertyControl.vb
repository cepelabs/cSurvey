Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Calculate.Plot
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.UIHelpers
Imports DevExpress.XtraBars

Friend Class cItemTrigpointDistancesPropertyControl
    Private oTrigpoint As cTrigPoint
    Private oCalculatedTrigpoint As Calculate.cTrigPoint
    Private oSurvey As Object

    Public Shadows ReadOnly Property Item As cItemTrigpoint
        Get
            Return MyBase.Item
        End Get
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() 
    End Sub

    Public Shadows Sub Rebind(Item As cItemTrigpoint)
        MyBase.Rebind(Item)

        oTrigpoint = Me.Item.Trigpoint
        If oTrigpoint Is Nothing Then
            Me.Enabled = False
        Else
            If oTrigpoint.Survey.Calculate.TrigPoints.Contains(oTrigpoint.Name) Then
                oCalculatedTrigpoint = oTrigpoint.Survey.Calculate.TrigPoints(oTrigpoint.Name)
                Me.Enabled = True
            Else
                Me.Enabled = False
            End If
        End If

        Call pInvalidate()
    End Sub

    Private Sub chkPropTrigpointDistancesLinkedSurveys_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropTrigpointDistancesLinkedSurveys.CheckedChanged
        Try
            If Not DisabledObjectProperty() Then
                Call pInvalidate()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdPropTrigpointDistancesCalculate_Click(sender As Object, e As EventArgs) Handles cmdPropTrigpointDistancesCalculate.Click
        Call pRefresh()
    End Sub

    Private Sub pInvalidate()
        If grdViewDistance.ViewCaption.Trim <> "" Then
            If Not bInvalidated Then
                bInvalidated = True
                grdViewDistance.ViewCaption = "<i>" & sLastStation & "</i>"
            End If
        End If
    End Sub

    Private bInvalidated As Boolean = False
    Private sLastStation As String = ""

    Private Sub pRefresh()
        bInvalidated = False
        sLastStation = oTrigpoint.Name
        grdViewDistance.ViewCaption = sLastStation

        Dim sOrigin As String = Me.Item.Survey.Properties.Origin

        Dim bSplay As Boolean = chkPropTrigpointDistancesSplays.Checked
        Dim bLinkedSurveys As Boolean = chkPropTrigpointDistancesLinkedSurveys.Checked
        Call grdDistance.BeginUpdate()

        colDistanceFilename.Visible = bLinkedSurveys

        Dim oPlanPoint As PointD = New PointD(oCalculatedTrigpoint.Point.X, oCalculatedTrigpoint.Point.Y)
        Dim oValues As List(Of cStationValue) = New List(Of cStationValue)
        Call pAppendDistances(oPlanPoint, oValues, "", Me.Item.Survey.TrigPoints, 0, 0, 0, bSplay)
        For Each oLinkedSurvey As cLinkedSurvey In Me.Item.Survey.LinkedSurveys.GetSelected("design." & If(Me.Item.Design.Type = cIDesign.cDesignTypeEnum.Plan, "plan", "profile"))

            Dim oThis As Calculate.cTrigPointCoordinate = Me.Item.Survey.Calculate.TrigPoints(sOrigin).Coordinate
            Dim oLinked As Calculate.cTrigPointCoordinate = oLinkedSurvey.LinkedSurvey.Calculate.TrigPoints(oLinkedSurvey.LinkedSurvey.Properties.Origin).Coordinate
            Dim oThisOrigin As UTM = modUTM.WGS84ToUTM(oThis)
            Dim oLinkedOrigin As UTM = modUTM.WGS84ToUTM(oLinked)

            Dim oSizePoint As SizeD = New SizeD(oLinkedOrigin.East - oThisOrigin.East, oLinkedOrigin.North - oThisOrigin.North)
            Dim oMovePoint As PointD = modPaint.RotatePointByRadians(New PointD(oSizePoint.Width, oSizePoint.Height), Me.Item.Survey.Calculate.GeoMagDeclinationData.MeridianConvergenceRadians)
            Dim dMoveZ As Decimal = oLinked.Altitude - oThis.Altitude
            Call pAppendDistances(oPlanPoint, oValues, oLinkedSurvey.GetFilename, oLinkedSurvey.LinkedSurvey.TrigPoints, oMovePoint.X, oMovePoint.Y, dMoveZ, bSplay)
        Next
        oValues = oValues.OrderBy(Function(item) item.Value).Take(1000).ToList
        grdDistance.DataSource = oValues
        grdDistance.EndUpdate()
    End Sub

    Private Sub pAppendDistances(PlanPoint As PointD, Values As List(Of cStationValue), Filename As String, Stations As cTrigPoints, DeltaX As Decimal, DeltaY As Decimal, DeltaZ As Decimal, Splay As Boolean)
        For Each oStation As cTrigPoint In Stations
            If Not oStation Is oTrigpoint Then
                If (Splay AndAlso oStation.Data.IsSplay) OrElse Not oStation.Data.IsSplay Then
                    Dim oPlanPoint2 As PointD = New PointD(oStation.Data.X + DeltaX, oStation.Data.Y + DeltaY)
                    Dim dPlanDistance As Decimal = modPaint.DistancePointToPoint(PlanPoint, oPlanPoint2)
                    Dim sDrop As Single = oTrigpoint.Data.Z + DeltaZ - oStation.Data.Z
                    Dim sDistance As Single = Math.Sqrt(dPlanDistance ^ 2 + sDrop ^ 2)
                    Call Values.Add(New cStationValue(Filename, oStation, sDistance))
                End If
            End If
        Next
    End Sub

    Private Sub grdViewDistance_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grdViewDistance.FocusedRowChanged
        Dim oValue As cStationValue = grdViewDistance.GetFocusedObject
        btnSelectStation.Enabled = oValue IsNot Nothing AndAlso oValue.Filename = ""
    End Sub

    Private Sub grdViewDistance_DoubleClick(sender As Object, e As EventArgs) Handles grdViewDistance.DoubleClick
        Call pSelectStation()
    End Sub

    Private Sub pSelectStation()
        Dim oValue As cStationValue = grdViewDistance.GetFocusedObject
        If oValue IsNot Nothing AndAlso oValue.Filename = "" Then
            MyBase.DoCommand("selectstation", oValue.Station)
        End If
    End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnRefresh.ItemClick
        Call pRefresh()
    End Sub

    Private Sub btnCopy_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopy.ItemClick
        Call grdViewDistance.CopyRow
    End Sub

    Private Sub btnCopyAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyAll.ItemClick
        Call grdViewDistance.CopyRows
    End Sub

    Private Sub btnCopyValue_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyValue.ItemClick
        Call grdViewDistance.CopyRowValue
    End Sub

    Private Sub btnCopyValues_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyValues.ItemClick
        Call grdViewDistance.CopyRowValues
    End Sub

    Private Sub grdViewDistance_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles grdViewDistance.PopupMenuShowing
        If e.HitInfo.InRowCell Then
            e.Allow = False
            Call mnuContext.ShowPopup(Cursor.Position)
        End If
    End Sub

    Private Sub btnSelectStation_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnSelectStation.ItemClick
        Call pSelectStation()
    End Sub

    Private Sub chkPropTrigpointDistancesSplays_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropTrigpointDistancesSplays.CheckedChanged
        Call pInvalidate()
    End Sub
End Class
