Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraBars
Imports DevExpress.XtraVerticalGrid.Events
Imports DevExpress.XtraVerticalGrid.Rows

Friend Class cItemTrigpointPropertyControl
    Private Sub pGetEquate(Equates As HashSet(Of String), Station As Calculate.cTrigPoint)
        If oCalculatedTrigpoint IsNot Nothing Then
            For Each sEquate As String In oCalculatedTrigpoint.Connections.GetEquateShots
                If Equates.Add(sEquate) Then
                    Call pGetEquate(Equates, oTrigpoint.Survey.Calculate.TrigPoints(sEquate))
                End If
            Next
        End If
    End Sub

    Private Sub grdTrigpointInfo_CustomUnboundData(sender As Object, e As CustomDataEventArgs) Handles grdTrigpointInfo.CustomUnboundData
        If e.IsGetData Then
            Select Case e.RowProperties.FieldName.ToLower
                Case "name"
                    e.Value = oTrigpoint.Name
                Case "equate"
                    If oCalculatedTrigpoint IsNot Nothing Then
                        Dim oEquates As HashSet(Of String) = New HashSet(Of String)
                        Call pGetEquate(oEquates, oCalculatedTrigpoint)
                        e.Value = String.Join(";", oEquates)
                    End If
                Case "x"
                    e.Value = Strings.Format(modNumbers.MathRound(oTrigpoint.Data.X, 3), "0.00") & " m"
                Case "y"
                    e.Value = Strings.Format(modNumbers.MathRound(-oTrigpoint.Data.Y, 3), "0.00") & " m"
                Case "z"
                    e.Value = Strings.Format(modNumbers.MathRound(-oTrigpoint.Data.Z, 3), "0.00") & " m"
                Case "depth"
                    If oCalculatedTrigpoint IsNot Nothing AndAlso oCalculatedTrigpoint.Depth.HasValue Then
                        e.Value = Strings.Format(modNumbers.MathRound(oCalculatedTrigpoint.Depth.Value, 3), "0.00") & " m"
                    End If
                Case "calibration"
                    e.Value = GetLocalizedString("main.textpart22")
                Case "entrance"
                    e.Value = oTrigpoint.Entrance.ToString
                Case "outside"
                    If oTrigpoint.IsOutside Then
                        e.Value = GetLocalizedString("main.textpart22")
                    Else
                        e.Value = GetLocalizedString("main.textpart23")
                    End If
                Case "lat"
                    If oCalculatedTrigpoint IsNot Nothing Then
                        e.Value = modNumbers.NumberToCoordinate(oCalculatedTrigpoint.Coordinate.Latitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S")
                    End If
                Case "lon"
                    If oCalculatedTrigpoint IsNot Nothing Then
                        e.Value = modNumbers.NumberToCoordinate(oCalculatedTrigpoint.Coordinate.Longitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W")
                    End If
                Case "alt"
                    If oCalculatedTrigpoint IsNot Nothing Then
                        e.Value = modNumbers.MathRound(oCalculatedTrigpoint.Coordinate.Altitude, 0) & " m"
                    End If
                Case "surfacealt"
                    If sAltValue.HasValue Then
                        e.Value = modNumbers.MathRound(sAltValue.Value, 0) & " m"
                    End If
                Case "surfacedelta"
                    If oCalculatedTrigpoint IsNot Nothing AndAlso sAltValue.HasValue Then
                        e.Value = modNumbers.MathRound(sAltValue.Value - oCalculatedTrigpoint.Coordinate.Altitude, 0) & " m"
                    End If
                Case "note"
                    e.Value = oTrigpoint.Note
            End Select
        End If
    End Sub

    Public Shadows ReadOnly Property Item As cItemTrigpoint
        Get
            Return MyBase.Item
        End Get
    End Property

    Private oTrigpoint As cTrigPoint
    Private oCalculatedTrigpoint As Calculate.cTrigPoint
    Private sAltValue As Single?

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(grdTrigpointInfo, False)
    End Sub

    Public Shadows Sub Rebind(Item As cItemTrigpoint)
        MyBase.Rebind(Item)

        oTrigpoint = Me.Item.Trigpoint
        If oTrigpoint Is Nothing Then
            cmdPropTrigpointGoto.Visible = False
        Else
            If oTrigpoint.Survey.Calculate.TrigPoints.Contains(oTrigpoint.Name) Then
                oCalculatedTrigpoint = oTrigpoint.Survey.Calculate.TrigPoints(oTrigpoint.Name)
                If Not oTrigpoint.Survey.Properties.SurfaceProfileElevation Is Nothing Then
                    sAltValue = modPaint.GetSurfaceElevation(oTrigpoint.Survey, oTrigpoint)
                End If
                cmdPropTrigpointGoto.Visible = True
            End If
        End If

        If grdTrigpointInfo.Rows.Count = 0 Then
            grdTrigpointInfo.Rows.Clear()

            Call grdTrigpointInfo.RowAdd("name", GetLocalizedString("main.textpart25"), DevExpress.Data.UnboundColumnType.String)
            Call grdTrigpointInfo.RowAdd("equate", GetLocalizedString("main.textpart166"), DevExpress.Data.UnboundColumnType.String)
            Call grdTrigpointInfo.RowAdd("x", GetLocalizedString("main.textpart26"), DevExpress.Data.UnboundColumnType.String)
            Call grdTrigpointInfo.RowAdd("y", GetLocalizedString("main.textpart27"), DevExpress.Data.UnboundColumnType.String)
            Call grdTrigpointInfo.RowAdd("z", GetLocalizedString("main.textpart28"), DevExpress.Data.UnboundColumnType.String)
            Call grdTrigpointInfo.RowAdd("depth", GetLocalizedString("main.textpart161"), DevExpress.Data.UnboundColumnType.String)

            Call grdTrigpointInfo.RowAdd("calibration", GetLocalizedString("main.textpart103"), DevExpress.Data.UnboundColumnType.String)
            Call grdTrigpointInfo.RowAdd("entrance", GetLocalizedString("main.textpart29"), DevExpress.Data.UnboundColumnType.String)
            Call grdTrigpointInfo.RowAdd("outside", GetLocalizedString("main.textpart29"), DevExpress.Data.UnboundColumnType.String)

            Call grdTrigpointInfo.RowAdd("lat", GetLocalizedString("main.textpart31"), DevExpress.Data.UnboundColumnType.String)
            Call grdTrigpointInfo.RowAdd("lon", GetLocalizedString("main.textpart32"), DevExpress.Data.UnboundColumnType.String)
            Call grdTrigpointInfo.RowAdd("alt", GetLocalizedString("main.textpart33"), DevExpress.Data.UnboundColumnType.String)

            Call grdTrigpointInfo.RowAdd("surfacealt", GetLocalizedString("main.textpart88"), DevExpress.Data.UnboundColumnType.String)
            Call grdTrigpointInfo.RowAdd("surfacedelta", GetLocalizedString("main.textpart87"), DevExpress.Data.UnboundColumnType.String)

            Call grdTrigpointInfo.RowAdd("note", GetLocalizedString("main.textpart93"), DevExpress.Data.UnboundColumnType.String)
        End If

        Call grdTrigpointInfo.RowSetVisible("calibration", oTrigpoint.Data.IsCalibration)
        Call grdTrigpointInfo.RowSetVisible("entrance", oTrigpoint.IsEntrance)

        If oCalculatedTrigpoint IsNot Nothing Then
            Call grdTrigpointInfo.RowSetVisible("equate", oCalculatedTrigpoint.Connections.GetEquateShots.Count > 0)
            If oTrigpoint.Survey.Calculate.TrigPoints.Contains(oTrigpoint.Name) Then
                Dim oCalculatedTrigpoint As Calculate.cTrigPoint = oTrigpoint.Survey.Calculate.TrigPoints(oTrigpoint.Name)

                Call grdTrigpointInfo.RowSetVisible("depth", oCalculatedTrigpoint.Depth.HasValue)

                Dim bVisible As Boolean = Not oCalculatedTrigpoint Is Nothing AndAlso Not oCalculatedTrigpoint.Coordinate Is Nothing AndAlso Not oCalculatedTrigpoint.Coordinate.IsEmpty
                Call grdTrigpointInfo.RowSetVisible("lat", bVisible)
                Call grdTrigpointInfo.RowSetVisible("lon", bVisible)
                Call grdTrigpointInfo.RowSetVisible("alt", bVisible)
                If bVisible AndAlso Not oTrigpoint.Survey.Properties.SurfaceProfileElevation Is Nothing AndAlso modPaint.GetSurfaceElevation(oTrigpoint.Survey, oTrigpoint).HasValue Then
                    Call grdTrigpointInfo.RowSetVisible("surfacealt", True)
                    Call grdTrigpointInfo.RowSetVisible("surfacedelta", True)
                Else
                    Call grdTrigpointInfo.RowSetVisible("surfacealt", False)
                    Call grdTrigpointInfo.RowSetVisible("surfacedelta", False)
                End If
            Else
                Call grdTrigpointInfo.RowSetVisible("equate", False)
                Call grdTrigpointInfo.RowSetVisible("depth", False)

                Call grdTrigpointInfo.RowSetVisible("lat", False)
                Call grdTrigpointInfo.RowSetVisible("lon", False)
                Call grdTrigpointInfo.RowSetVisible("alt", False)
                Call grdTrigpointInfo.RowSetVisible("surfacealt", False)
                Call grdTrigpointInfo.RowSetVisible("surfacedelta", False)
            End If
        End If

        Call grdTrigpointInfo.RowSetVisible("note", oTrigpoint.Note <> "")

        Call pRefresh()
    End Sub

    Private Sub pRefresh()
        grdTrigpointInfo.DataSource = New List(Of cTrigPoint)({oTrigpoint})
    End Sub

    Private Sub cmdPropSegmentGoto_Click(sender As Object, e As EventArgs) Handles cmdPropTrigpointGoto.Click
        If oTrigpoint IsNot Nothing Then
            MyBase.DoCommand("selectstation", oTrigpoint)
        End If
    End Sub

    Private Sub grdSegmentInfo_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles grdTrigpointInfo.PopupMenuShowing
        'e.Menu.Enabled = False
        e.Menu.Items.Remove(e.Menu.Items.FirstOrDefault(Function(oitem) oitem.Tag = DevExpress.XtraVerticalGrid.Localization.VGridStringId.MenuRowCustomization))
        Call mnuContext.ShowPopup(Cursor.Position)
    End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnRefresh.ItemClick
        Call pRefresh()
    End Sub

    Private Sub btnCopy_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopy.ItemClick
        Call grdTrigpointInfo.CopyRow
    End Sub

    Private Sub btnCopyAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyAll.ItemClick
        Call grdTrigpointInfo.CopyRows
    End Sub

    Private Sub btnCopyValue_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyValue.ItemClick
        Call grdTrigpointInfo.CopyRowValue
    End Sub

    Private Sub btnCopyValues_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyValues.ItemClick
        Call grdTrigpointInfo.CopyRowValues
    End Sub
End Class
