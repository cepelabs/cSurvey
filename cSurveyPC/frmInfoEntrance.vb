Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design

friend Class frmInfoEntrance
    Private oSurvey As cSurvey.cSurvey

    Friend Sub New(ByVal Survey As cSurvey.cSurvey, Optional ByVal Cave As String = "", Optional Branch As String = "")
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        Call pRefreshCaveList(Cave)
    End Sub

    Private Sub cboSurveyInfoCave_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSurveyInfoCave.SelectedIndexChanged
        Dim sCave As String = "" & cboSurveyInfoCave.Text
        Call pRefreshInfo()
    End Sub

    Private Sub pRefreshCaveList(ByVal CurrentCave As String)
        Dim sCurrentCave As String = "" & CurrentCave
        Dim oEmptyCaveInfo As cCaveInfo = oSurvey.Properties.CaveInfos.GetEmptyCaveInfo
        Dim oSurveyInfoCave As cCaveInfo
        Try
            If sCurrentCave = "" Then
                oSurveyInfoCave = cboSurveyInfoCave.SelectedItem
            Else
                oSurveyInfoCave = oSurvey.Properties.CaveInfos(sCurrentCave)
            End If
        Catch
        End Try
        Call cboSurveyInfoCave.Items.Clear()
        Call cboSurveyInfoCave.Items.Add(oEmptyCaveInfo)
        For Each oCaveInfo As cCaveInfo In oSurvey.Properties.CaveInfos
            Call cboSurveyInfoCave.Items.Add(oCaveInfo)
        Next
        Try
            If oSurveyInfoCave Is Nothing Then
                cboSurveyInfoCave.SelectedIndex = 0
            Else
                cboSurveyInfoCave.SelectedItem = oSurveyInfoCave
            End If
        Catch
            cboSurveyInfoCave.SelectedIndex = 0
        End Try
    End Sub

    Private Sub pRefreshInfo()
        Cursor = Cursors.WaitCursor

        Call grdSurveyInfo.Rows.Clear()

        Dim oOptions As cOptionsDesign = New cOptionsDesign(oSurvey, "_info")
        oOptions.DrawSplay = False
        oOptions.DrawSegmentsOptions = cOptions.DrawSegmentsOptionsEnum.None

        Dim bComplex As Boolean = cboSurveyInfoCave.SelectedIndex = 0 Or cboSurveyInfoCave.SelectedIndex = -1

        Dim sCave As String = "" & cboSurveyInfoCave.Text

        Dim oTrigpoints As cTrigPointCollection
        Dim oData(7) As Object
        If bComplex Then
            'Call grdSurveyInfo.Rows.Add(GetLocalizedString("infoentrance.textpart1"), oSurvey.Name)
            oTrigpoints = oSurvey.TrigPoints.GetAllEntrances()
        Else
            'Call grdSurveyInfo.Rows.Add(GetLocalizedString("infoentrance.textpart1"), oSurvey.Name)
            'Call grdSurveyInfo.Rows.Add(GetLocalizedString("infoentrance.textpart2"), sCave)
            oTrigpoints = oSurvey.TrigPoints.GetCaveAllEntrances(sCave)
        End If

        For Each oTrigpoint As cTrigPoint In oTrigpoints
            Dim oSegments As cSegmentCollection = oTrigpoint.GetSegments
            If oSegments.Count = 0 Then
                oData(0) = GetLocalizedString("infoentrance.textpart3")
            Else
                oData(0) = String.Join("; ", oTrigpoint.GetSegments.ToArray.Select(Function(item) item.Cave).Distinct())
            End If
            oData(1) = oTrigpoint.Name
            oData(2) = GetLocalizedString("infoentrance.textpart" & oTrigpoint.Entrance - cTrigPoint.EntranceTypeEnum.OtherCaveEntrance + 4)
            oData(6) = oTrigpoint.Note
            oData(7) = "..."
            If oSurvey.Calculate.TrigPoints.Contains(oTrigpoint) Then
                With oSurvey.Calculate.TrigPoints(oTrigpoint).Coordinate
                    oData(3) = modNumbers.NumberToCoordinate(.Latitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S")
                    oData(4) = modNumbers.NumberToCoordinate(.Longitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W")
                    oData(5) = modNumbers.MathRound(.Altitude, 0)
                End With
            Else
                oData(3) = GetLocalizedString("infoentrance.textpart3")
                oData(4) = GetLocalizedString("infoentrance.textpart3")
                oData(5) = GetLocalizedString("infoentrance.textpart3")
            End If
            Dim iRowIndex As Integer = grdSurveyInfo.Rows.Add(oData)
            grdSurveyInfo.Rows(iRowIndex).Tag = oTrigpoint
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Call Close()
    End Sub

    Private Sub mnuSurveyInfoCopy_Click(sender As System.Object, e As System.EventArgs) Handles mnuSurveyInfoCopy.Click
        Call pSurveyInfoCopy(grdSurveyInfo.SelectedRows)
    End Sub

    Private Sub pSurveyInfoCopy(Rows As IEnumerable)
        Try
            Cursor = Cursors.WaitCursor
            Dim sText As String = ""
            For Each oRow As DataGridViewRow In Rows
                For Each oCell As DataGridViewCell In oRow.Cells
                    sText = sText & oCell.FormattedValue & vbTab
                Next
                sText = sText & vbCrLf
            Next
            Call My.Computer.Clipboard.SetText(sText)
            Cursor = Cursors.Default
        Catch ex As Exception
        End Try
    End Sub

    Private Sub mnuSurveyInfoCopyAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuSurveyInfoCopyAll.Click
        Call pSurveyInfoCopy(grdSurveyInfo.Rows)
    End Sub

    Private Sub cboSurveyInfoCaveBranch_SelectedIndexChanged(sender As Object, e As EventArgs)
        Call pRefreshInfo()
    End Sub

    Private Sub mnuSurveyInfoExport_Click(sender As Object, e As EventArgs) Handles mnuSurveyInfoExport.Click
        Call modExport.GridExportTo(oSurvey, grdSurveyInfo, Text, "", Me)
    End Sub

    Private Sub mnuSurveyInfoCopyCell_Click(sender As Object, e As EventArgs) Handles mnuSurveyInfoCopyCell.Click
        My.Computer.Clipboard.SetText(grdSurveyInfo.CurrentCell.FormattedValue)
    End Sub

    Private Sub grdSurveyInfo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdSurveyInfo.CellContentClick
        If e.ColumnIndex = 7 Then
            Dim oSFD As SaveFileDialog = New SaveFileDialog
            With oSFD
                .Title = GetLocalizedString("infoentrance.exportkmldialog")
                .Filter = GetLocalizedString("main.filetypeKML") & " (*.KML)|*.KML"
                .FilterIndex = 1
                .OverwritePrompt = True
                .CheckPathExists = True
                If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Select Case .FilterIndex
                        Case 1
                            Call modExport.GoogleKmlExportToPoint(oSurvey, grdSurveyInfo.CurrentRow.Tag, .FileName)
                    End Select
                End If
            End With
        End If
    End Sub
End Class