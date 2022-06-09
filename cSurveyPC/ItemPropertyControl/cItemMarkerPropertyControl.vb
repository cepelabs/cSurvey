Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraBars
Imports DevExpress.XtraVerticalGrid.Events
Imports DevExpress.XtraVerticalGrid.Rows

Friend Class cItemMarkerPropertyControl
    Private Sub grdTrigpointInfo_CustomUnboundData(sender As Object, e As CustomDataEventArgs) Handles grdMarkerInfo.CustomUnboundData
        If e.IsGetData Then
            Select Case e.RowProperties.FieldName.ToLower
                Case "x"
                    e.Value = Strings.Format(modNumbers.MathRound(oPoint.Point.X, 3), "0.00") & " m"
                Case "y"
                    e.Value = Strings.Format(modNumbers.MathRound(-oPoint.Point.Y, 3), "0.00") & " m"
                Case "lat"
                    e.Value = modNumbers.NumberToCoordinate(oPoint.Coordinate.Latitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S")
                Case "lon"
                    e.Value = modNumbers.NumberToCoordinate(oPoint.Coordinate.Longitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W")
                Case "alt"
                    e.Value = modNumbers.MathRound(oPoint.Coordinate.Altitude, 0)
            End Select
        End If
    End Sub

    Public Shadows ReadOnly Property Item As cItemMarker
        Get
            Return MyBase.Item
        End Get
    End Property

    Private oPoint As Helper.Editor.cMarkedDesktopPoint

    Public Shadows Sub Rebind(Item As cItem)
        MyBase.Rebind(Item)

        oPoint = Me.Item.MarkedPoint

        If grdMarkerInfo.Rows.Count = 0 Then
            grdMarkerInfo.Rows.Clear()

            Call grdMarkerInfo.RowAdd("x", GetLocalizedString("main.textpart26"), DevExpress.Data.UnboundColumnType.String)
            Call grdMarkerInfo.RowAdd("y", GetLocalizedString("main.textpart27"), DevExpress.Data.UnboundColumnType.String)

            Call grdMarkerInfo.RowAdd("lat", GetLocalizedString("main.textpart31"), DevExpress.Data.UnboundColumnType.String)
            Call grdMarkerInfo.RowAdd("lon", GetLocalizedString("main.textpart32"), DevExpress.Data.UnboundColumnType.String)
            Call grdMarkerInfo.RowAdd("alt", GetLocalizedString("main.textpart33"), DevExpress.Data.UnboundColumnType.String)
        End If

        Dim bCoordinate As Boolean = Not oPoint.Coordinate Is Nothing
        Call grdMarkerInfo.RowSetVisible("lat", bCoordinate)
        Call grdMarkerInfo.RowSetVisible("lon", bCoordinate)
        Call grdMarkerInfo.RowSetVisible("alt", bCoordinate)

        Call pRefresh()
    End Sub

    Private Sub pRefresh()
        grdMarkerInfo.DataSource = New List(Of Helper.Editor.cMarkedDesktopPoint)({oPoint})
    End Sub

    Private Sub grdMarkerInfo_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles grdMarkerInfo.PopupMenuShowing
        If grdMarkerInfo.CalcHitInfo(grdMarkerInfo.PointToClient(Cursor.Position)).HitInfoType = DevExpress.XtraVerticalGrid.HitInfoTypeEnum.ValueCell Then
            e.Menu.Enabled = False
            Call mnuContext.ShowPopup(Cursor.Position)
        Else
            e.Menu.Items.Remove(e.Menu.Items.FirstOrDefault(Function(oitem) oitem.Tag = DevExpress.XtraVerticalGrid.Localization.VGridStringId.MenuRowCustomization))
        End If
    End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnRefresh.ItemClick
        Call pRefresh()
    End Sub

    Private Sub btnCopy_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopy.ItemClick
        Call grdMarkerInfo.CopyRow
    End Sub

    Private Sub btnCopyAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyAll.ItemClick
        Call grdMarkerInfo.CopyRows
    End Sub

    Private Sub btnCopyValue_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyValue.ItemClick
        Call grdMarkerInfo.CopyRowValue
    End Sub

    Private Sub btnCopyValues_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyValues.ItemClick
        Call grdMarkerInfo.CopyRowValues
    End Sub
End Class
