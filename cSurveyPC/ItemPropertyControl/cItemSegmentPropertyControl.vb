Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraBars
Imports DevExpress.XtraVerticalGrid.Events
Imports DevExpress.XtraVerticalGrid.Rows

Friend Class cItemSegmentPropertyControl
    Private Sub grdSegmentInfo_CustomUnboundData(sender As Object, e As CustomDataEventArgs) Handles grdSegmentInfo.CustomUnboundData
        If e.IsGetData Then
            Select Case e.RowProperties.FieldName.ToLower
                Case "cave"
                    e.Value = oSegment.Cave
                Case "branch"
                    e.Value = oSegment.Branch
                Case "session.desc"
                    If oSession Is Nothing Then
                        e.Value = "N/D"
                    Else
                        e.Value = oSession.Description
                    End If
                Case "session.date"
                    If oSession Is Nothing Then
                        e.Value = "N/D"
                    Else
                        e.Value = Strings.Format(oSession.Date, "dd/MM/yyyy")
                    End If
                Case "from"
                    e.Value = oSegment.From
                Case "to"
                    e.Value = oSegment.To

                Case "d1"
                    Dim dCalculatedDistance As Decimal = modNumbers.MathRound(oSegment.Data.Data.Distance, 2)
                    e.Value = Strings.Format(oSegment.Distance, "0.00") & " " & cSegment.GetDistanceSimbol(oSegment.GetDistanceType) & " " & If(oSegment.Distance <> dCalculatedDistance, " (" & Strings.Format(dCalculatedDistance, "0.00") & " m" & ")", "")
                Case "d2"
                    Dim dCalculatedBearing As Decimal = modNumbers.MathRound(oSegment.Data.Data.Bearing, 2)
                    Select Case oSegment.GetDataFormat
                        Case cSegment.DataFormatEnum.Cartesian
                            e.Value = Strings.Format(oSegment.Bearing, "0.00") & " " & cSegment.GetDistanceSimbol(oSegment.GetDistanceType) & " (" & Strings.Format(dCalculatedBearing, "0.00") & "° " & ")"
                        Case cSegment.DataFormatEnum.Diving, cSegment.DataFormatEnum.Normal
                            e.Value = Strings.Format(oSegment.Bearing, "0.00") & " " & cSegment.GetBearingSimbol(oSegment.GetBearingType) & " " & If(oSegment.Bearing <> dCalculatedBearing, " (" & Strings.Format(dCalculatedBearing, "0.00") & "° " & ")", "")
                    End Select
                Case "d3"
                    Dim dCalculatedInclination As Decimal = modNumbers.MathRound(oSegment.Data.Data.Inclination, 2)
                    Select Case oSegment.GetDataFormat
                        Case cSegment.DataFormatEnum.Cartesian
                            e.Value = Strings.Format(oSegment.Inclination, "0.00") & " " & cSegment.GetDistanceSimbol(oSegment.GetDistanceType) & " (" & Strings.Format(dCalculatedInclination, "0.00") & "° " & ")"
                        Case cSegment.DataFormatEnum.Diving
                            e.Value = Strings.Format(oSegment.Inclination, "0.00") & " " & cSegment.GetDistanceSimbol(oSegment.GetDistanceType) & " (" & Strings.Format(dCalculatedInclination, "0.00") & "° " & ")"
                        Case cSegment.DataFormatEnum.Normal
                            e.Value = Strings.Format(oSegment.Inclination, "0.00") & " " & cSegment.GetInclinationSimbol(oSegment.GetInclinationType) & " " & If(oSegment.Inclination <> dCalculatedInclination, " (" & Strings.Format(dCalculatedInclination, "0.00") & "° " & ")", "")
                    End Select

                Case "distance"
                    e.Value = modNumbers.MathRound(modPaint.DistancePointToPoint(oSegment.Data.Plan.FromPoint, oSegment.Data.Plan.ToPoint), 3) & " m"
                Case "drop"
                    e.Value = modNumbers.MathRound(oSegment.Data.Profile.FromPoint.Y - oSegment.Data.Profile.ToPoint.Y, 3) & " m"

                Case "reversed"
                    e.Value = If(oSegment.Data.Data.Reversed, GetLocalizedString("main.textpart19a"), GetLocalizedString("main.textpart19b"))
                Case "direction"
                    e.Value = If(oSegment.Data.Data.Direction = cSurvey.cSurvey.DirectionEnum.Left, GetLocalizedString("main.textpart20a"), If(oSegment.Data.Data.Direction = cSurvey.cSurvey.DirectionEnum.Right, GetLocalizedString("main.textpart20b"), GetLocalizedString("main.textpart20e")))

                Case "excluded"
                    e.Value = If(oSegment.Exclude, GetLocalizedString("main.textpart22"), GetLocalizedString("main.textpart23"))
                Case "splay"
                    e.Value = If(oSegment.Splay, GetLocalizedString("main.textpart22"), GetLocalizedString("main.textpart23"))
                Case "calibration"
                    e.Value = If(oSegment.Calibration, GetLocalizedString("main.textpart22"), GetLocalizedString("main.textpart23"))
                Case "ring"
                    e.Value = If(oSegment.Data.IsInRing, GetLocalizedString("main.textpart22"), GetLocalizedString("main.textpart23"))
            End Select
        End If
    End Sub

    Public Shadows ReadOnly Property Item As cItemSegment
        Get
            Return MyBase.Item
        End Get
    End Property

    Private oSegment As cSegment
    Private oSession As cSession

    Public Shadows Sub Rebind(Item As cItemSegment)
        MyBase.Rebind(Item)

        oSegment = Me.Item.Segment
        If oSegment Is Nothing Then
            oSession = Nothing
            cmdPropSegmentBeginShot.Visible = False
            cmdPropSegmentEndShot.Visible = False
            cmdPropSegmentGoto.Visible = False
        Else
            oSession = Me.Item.Survey.Properties.Sessions(oSegment.Session)

            If oSegment.From = "" Then
                cmdPropSegmentBeginShot.Visible = False
            Else
                cmdPropSegmentBeginShot.Text = oSegment.From
                cmdPropSegmentBeginShot.Visible = True
            End If

            If oSegment.To = "" Then
                cmdPropSegmentEndShot.Visible = False
            Else
                cmdPropSegmentEndShot.Text = oSegment.To
                cmdPropSegmentEndShot.Visible = True
            End If
            cmdPropSegmentGoto.Visible = True
        End If

        If grdSegmentInfo.Rows.Count = 0 Then
            grdSegmentInfo.Rows.Clear()

            Call grdSegmentInfo.RowAdd("cave", GetLocalizedString("main.textpart11"), DevExpress.Data.UnboundColumnType.String)
            Call grdSegmentInfo.RowAdd("branch", GetLocalizedString("main.textpart12"), DevExpress.Data.UnboundColumnType.String)

            Call grdSegmentInfo.RowAdd("session.desc", GetLocalizedString("main.textpart13"), DevExpress.Data.UnboundColumnType.String)
            Call grdSegmentInfo.RowAdd("session.date", GetLocalizedString("main.textpart14"), DevExpress.Data.UnboundColumnType.DateTime)

            Call grdSegmentInfo.RowAdd("from", GetLocalizedString("main.textpart15"), DevExpress.Data.UnboundColumnType.String)
            Call grdSegmentInfo.RowAdd("to", GetLocalizedString("main.textpart16"), DevExpress.Data.UnboundColumnType.String)

            Call grdSegmentInfo.RowAdd("d1", GetMeasureName(oSegment, MeasureEnum.Distance), DevExpress.Data.UnboundColumnType.String)
            Call grdSegmentInfo.RowAdd("d2", GetMeasureName(oSegment, MeasureEnum.Bearing), DevExpress.Data.UnboundColumnType.String)
            Call grdSegmentInfo.RowAdd("d3", GetMeasureName(oSegment, MeasureEnum.Inclination), DevExpress.Data.UnboundColumnType.String)

            Call grdSegmentInfo.RowAdd("distance", GetLocalizedString("main.textpart17"), DevExpress.Data.UnboundColumnType.String)
            Call grdSegmentInfo.RowAdd("drop", GetLocalizedString("main.textpart18"), DevExpress.Data.UnboundColumnType.String)

            Call grdSegmentInfo.RowAdd("reversed", GetLocalizedString("main.textpart19"), DevExpress.Data.UnboundColumnType.String)

            Call grdSegmentInfo.RowAdd("direction", GetLocalizedString("main.textpart20"), DevExpress.Data.UnboundColumnType.String)

            Call grdSegmentInfo.RowAdd("excluded", GetLocalizedString("main.textpart21"), DevExpress.Data.UnboundColumnType.String)
            Call grdSegmentInfo.RowAdd("splay", GetLocalizedString("main.textpart24"), DevExpress.Data.UnboundColumnType.String)
            Call grdSegmentInfo.RowAdd("calibration", GetLocalizedString("main.textpart102"), DevExpress.Data.UnboundColumnType.String)
            Call grdSegmentInfo.RowAdd("ring", GetLocalizedString("main.textpart91"), DevExpress.Data.UnboundColumnType.String)
        Else
            Call grdSegmentInfo.RowSetCaption("d2", GetMeasureName(oSegment, MeasureEnum.Bearing))
            Call grdSegmentInfo.RowSetCaption("d3", GetMeasureName(oSegment, MeasureEnum.Inclination))
        End If

        Call pRefresh()
    End Sub

    Private Sub pRefresh()
        grdSegmentInfo.DataSource = New List(Of cSegment)({oSegment})
    End Sub

    Private Sub cmdPropSegmentBeginShot_Click(sender As Object, e As EventArgs) Handles cmdPropSegmentBeginShot.Click
        If oSegment IsNot Nothing Then
            MyBase.DoCommand("selectstation", oSegment.GetFromTrigPoint)
        End If
    End Sub

    Private Sub cmdPropSegmentEndShot_Click(sender As Object, e As EventArgs) Handles cmdPropSegmentEndShot.Click
        If oSegment IsNot Nothing Then
            MyBase.DoCommand("selectstation", oSegment.GetToTrigPoint)
        End If
    End Sub

    Private Sub cmdPropSegmentGoto_Click(sender As Object, e As EventArgs) Handles cmdPropSegmentGoto.Click
        If oSegment IsNot Nothing Then
            MyBase.DoCommand("selectshot", oSegment)
        End If
    End Sub

    Private Sub cmdSegmentSetCaveBranch_Click(sender As Object, e As EventArgs) Handles cmdSegmentSetCaveBranch.Click
        If oSegment IsNot Nothing Then
            MyBase.DoCommand("segmentsetcavebranchtocurrent")
        End If
    End Sub

    Private Sub cmdSegmentSetCurrentCaveBranch_Click(sender As Object, e As EventArgs) Handles cmdSegmentSetCurrentCaveBranch.Click
        If oSegment IsNot Nothing Then
            MyBase.DoCommand("currentcaveandbranchsettocurrent")
        End If
    End Sub

    Private Sub grdSegmentInfo_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles grdSegmentInfo.PopupMenuShowing
        'e.Menu.Enabled = False
        e.Menu.Items.Remove(e.Menu.Items.FirstOrDefault(Function(oitem) oitem.Tag = DevExpress.XtraVerticalGrid.Localization.VGridStringId.MenuRowCustomization))
        Call mnuContext.ShowPopup(Cursor.Position)
    End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnRefresh.ItemClick
        Call pRefresh()
    End Sub

    Private Sub btnCopy_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopy.ItemClick
        Call grdSegmentInfo.CopyRow
    End Sub

    Private Sub btnCopyAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyAll.ItemClick
        Call grdSegmentInfo.CopyRows
    End Sub

    Private Sub btnCopyValue_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyValue.ItemClick
        Call grdSegmentInfo.CopyRowValue
    End Sub

    Private Sub btnCopyValues_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyValues.ItemClick
        Call grdSegmentInfo.CopyRowValues
    End Sub
End Class
