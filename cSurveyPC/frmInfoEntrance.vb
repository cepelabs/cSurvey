Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports DevExpress.XtraBars

Friend Class frmInfoEntrance
    Private oSurvey As cSurvey.cSurvey

    Friend Sub New(ByVal Survey As cSurvey.cSurvey, Optional ByVal Cave As String = "")
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        Call pRefreshCaveList(Survey, Cave)
    End Sub

    Private Sub pRefreshCaveList(Survey As cSurvey.cSurvey, Optional Cave As String = Nothing)
        If IsNothing(Survey) Then
            cboSurveyInfoCave.Enabled = False
        Else
            cboSurveyInfoCave.Enabled = True
            cboSurveyInfoCave.Properties.DataSource = Survey.Properties.CaveInfos.GetWithEmpty.Select(Function(oitem) oitem.Value).ToList
            If Cave Is Nothing Then
                cboSurveyInfoCave.EditValue = cboSurveyInfoCave.Properties.DataSource(0)
            Else
                cboSurveyInfoCave.EditValue = Survey.Properties.CaveInfos(Cave)
            End If
        End If
    End Sub

    Private Sub pRefresh()
        Cursor = Cursors.WaitCursor

        Call grdSurveyInfo.BeginUpdate()
        Call grdSurveyInfo.ClearAll()

        Dim oOptions As cOptionsDesign = New cOptionsDesign(oSurvey, "_info")
        oOptions.DrawSplay = False
        oOptions.DrawSegmentsOptions = cOptionsDesign.DrawSegmentsOptionsEnum.None

        Dim bComplex As Boolean = (cboSurveyInfoCave.EditValue Is cboSurveyInfoCave.Properties.DataSource(0))
        Dim sCurrentCave As String = "" & If(cboSurveyInfoCave.EditValue Is Nothing, "", cboSurveyInfoCave.EditValue.name)

        Dim oTrigpoints As cTrigPointCollection
        If bComplex Then
            oTrigpoints = oSurvey.TrigPoints.GetAllEntrances()
        Else
            oTrigpoints = oSurvey.TrigPoints.GetCaveAllEntrances(sCurrentCave)
        End If

        For Each oTrigpoint As cTrigPoint In oTrigpoints
            grdSurveyInfo.CreateValueSet(oTrigpoint)
            Dim oSegments As cSegmentCollection = oTrigpoint.GetSegments
            If oSegments.Count = 0 Then
                Call grdSurveyInfo.RowAdd("data0", GetLocalizedString("infoentrance.textpart8"), GetLocalizedString("infoentrance.textpart3"))
            Else
                Call grdSurveyInfo.RowAdd("data0", GetLocalizedString("infoentrance.textpart8"), String.Join("; ", oTrigpoint.GetSegments.ToArray.Select(Function(item) item.Cave).Distinct()))
            End If
            Call grdSurveyInfo.RowAdd("data1", GetLocalizedString("infoentrance.textpart9"), oTrigpoint.Name)
            Call grdSurveyInfo.RowAdd("data2", GetLocalizedString("infoentrance.textpart10"), GetLocalizedString("infoentrance.textpart" & oTrigpoint.Entrance - cTrigPoint.EntranceTypeEnum.OtherCaveEntrance + 4))

            If oSurvey.Calculate.TrigPoints.Contains(oTrigpoint) Then
                With oSurvey.Calculate.TrigPoints(oTrigpoint).Coordinate
                    Dim oCoordinateRow As DevExpress.XtraVerticalGrid.Rows.EditorRow = grdSurveyInfo.RowAdd("data7", GetLocalizedString("infoentrance.textpart15"), "")
                    Dim oButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = grdSurveyInfo.SetAsButtonEdit(oCoordinateRow, AddressOf grdSurveyInfo_buttonClick)
                    Dim oExportButton As DevExpress.XtraEditors.Controls.EditorButton = New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                    oExportButton.ImageOptions.SvgImage = My.Resources.exportfile
                    oExportButton.ImageOptions.SvgImageSize = New Size(16, 16)
                    oExportButton.Caption = GetLocalizedString("infoentrance.textpart16")
                    oButtonEdit.Buttons.Add(oExportButton)
                    Call grdSurveyInfo.RowAdd(oCoordinateRow, "data3", GetLocalizedString("infoentrance.textpart11"), modNumbers.NumberToCoordinate(.Latitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S"))
                    Call grdSurveyInfo.RowAdd(oCoordinateRow, "data4", GetLocalizedString("infoentrance.textpart12"), modNumbers.NumberToCoordinate(.Longitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W"))
                    Call grdSurveyInfo.RowAdd(oCoordinateRow, "data5", GetLocalizedString("infoentrance.textpart13"), modNumbers.MathRound(.Altitude, 0))
                End With
            Else
                Dim oCoordinateRow As DevExpress.XtraVerticalGrid.Rows.EditorRow = grdSurveyInfo.RowAdd("data7", GetLocalizedString("infoentrance.textpart15"), "")
                Call grdSurveyInfo.RowAdd(oCoordinateRow, "data3", GetLocalizedString("infoentrance.textpart11"), GetLocalizedString("infoentrance.textpart3"))
                Call grdSurveyInfo.RowAdd(oCoordinateRow, "data4", GetLocalizedString("infoentrance.textpart12"), GetLocalizedString("infoentrance.textpart3"))
                Call grdSurveyInfo.RowAdd(oCoordinateRow, "data5", GetLocalizedString("infoentrance.textpart13"), GetLocalizedString("infoentrance.textpart3"))
            End If

            Call grdSurveyInfo.RowAdd("data6", GetLocalizedString("infoentrance.textpart14"), oTrigpoint.Note)
            'oData(7) = "..."

            'Dim iRowIndex As Integer = grdSurveyInfo.Rows.Add(oData)
            'grdSurveyInfo.Rows(iRowIndex).Tag = oTrigpoint
        Next
        Call grdSurveyInfo.RefreshDataSource()
        Call grdSurveyInfo.EndUpdate()
        Cursor = Cursors.Default
    End Sub

    Private Sub grdSurveyInfo_buttonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim oTrigpoint As cTrigPoint = grdSurveyInfo.GetBaseObject(grdSurveyInfo.FocusedRecord)
        Using oSFD As SaveFileDialog = New SaveFileDialog
            With oSFD
                .Title = GetLocalizedString("infoentrance.exportkmldialog")
                .Filter = GetLocalizedString("main.filetypeKML") & " (*.KML)|*.KML"
                .FilterIndex = 1
                .OverwritePrompt = True
                .CheckPathExists = True
                .FileName = oTrigpoint.Name
                If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Select Case .FilterIndex
                        Case 1
                            Call modExport.GoogleKmlExportToPoint(oSurvey, oTrigpoint, .FileName)
                    End Select
                End If
            End With
        End Using
    End Sub

    Private Sub btnCopy_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopy.ItemClick
        Call grdSurveyInfo.CopyRow
    End Sub

    Private Sub btnCopyAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyAll.ItemClick
        Call grdSurveyInfo.CopyRows
    End Sub

    Private Sub btnCopyValue_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyValue.ItemClick
        Call grdSurveyInfo.CopyRowValue
    End Sub

    Private Sub btnCopyValues_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyValues.ItemClick
        Call grdSurveyInfo.CopyRowValues
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnExport.ItemClick
        Call modExport.GridExportTo(oSurvey, grdSurveyInfo, Text, "", Me)
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Call Close()
    End Sub

    Private Sub cboSurveyInfoCave_EditValueChanged(sender As Object, e As EventArgs) Handles cboSurveyInfoCave.EditValueChanged
        Call pRefresh()
    End Sub

    Private Sub grdSurveyInfo_PopupMenuShowing(sender As Object, e As DevExpress.XtraVerticalGrid.Events.PopupMenuShowingEventArgs) Handles grdSurveyInfo.PopupMenuShowing
        If grdSurveyInfo.CalcHitInfo(grdSurveyInfo.PointToClient(Cursor.Position)).HitInfoType = DevExpress.XtraVerticalGrid.HitInfoTypeEnum.ValueCell Then
            e.Menu.Enabled = False
            Call mnuContext.ShowPopup(Cursor.Position)
        End If
    End Sub

    'Private Sub grdSurveyInfo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdSurveyInfo.CellContentClick
    '    If e.ColumnIndex = 7 Then
    '        Dim oSFD As SaveFileDialog = New SaveFileDialog
    '        With oSFD
    '            .Title = GetLocalizedString("infoentrance.exportkmldialog")
    '            .Filter = GetLocalizedString("main.filetypeKML") & " (*.KML)|*.KML"
    '            .FilterIndex = 1
    '            .OverwritePrompt = True
    '            .CheckPathExists = True
    '            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
    '                Select Case .FilterIndex
    '                    Case 1
    '                        Call modExport.GoogleKmlExportToPoint(oSurvey, grdSurveyInfo.CurrentRow.Tag, .FileName)
    '                End Select
    '            End If
    '        End With
    '    End If
    'End Sub
End Class