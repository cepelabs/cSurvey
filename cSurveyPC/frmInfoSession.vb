Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design

friend Class frmInfoSession
    Private oSurvey As cSurvey.cSurvey

    Friend Sub New(ByVal Survey As cSurvey.cSurvey, Optional ByVal Session As String = "")
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        Call pRefreshSessionList(Session)
    End Sub

    Private Sub cboSurveyInfoSession_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSurveyInfoSession.SelectedIndexChanged
        Call pRefreshInfo()
    End Sub

    Private Sub pRefreshSessionList(ByVal CurrentSession As String)
        Dim sCurrentSession As String = "" & CurrentSession
        Dim oEmptyInfoSession As cSession = oSurvey.Properties.Sessions.GetEmptySession
        Dim oSurveyInfoSession As cSession
        Try
            If sCurrentSession = "" Then
                oSurveyInfoSession = cboSurveyInfoSession.SelectedItem
            Else
                oSurveyInfoSession = oSurvey.Properties.Sessions(sCurrentSession)
            End If
        Catch
        End Try
        Call cboSurveyInfoSession.Items.Clear()
        Call cboSurveyInfoSession.Items.Add(oEmptyInfoSession)
        For Each oSessionInfo As cSession In oSurvey.Properties.Sessions
            Call cboSurveyInfoSession.Items.Add(oSessionInfo)
        Next
        Try
            If oSurveyInfoSession Is Nothing Then
                cboSurveyInfoSession.SelectedIndex = 0
            Else
                cboSurveyInfoSession.SelectedItem = oSurveyInfoSession
            End If
        Catch
            cboSurveyInfoSession.SelectedIndex = 0
        End Try
    End Sub

    Private Sub pRefreshInfo()
        Cursor = Cursors.WaitCursor

        Call grdSurveyInfo.Rows.Clear()

        Call grdSurveyInfo.Rows.Add(GetLocalizedString("infosession.textpart1"), cboSurveyInfoSession.Text)
        Dim oSegments As cISegmentCollection = oSurvey.Segments.GetSessionSegments(cboSurveyInfoSession.SelectedItem)
        Dim oCalibrationSegments As cISegmentCollection = oSurvey.Segments.GetSessionSegments(cboSurveyInfoSession.SelectedItem, cISegmentCollection.SessionSegmentsFlagEnum.CalibrationShots)
        Try
            Dim dDistance As Single = 0
            Dim dPlan As Single = 0
            Dim dFullDistance As Single = 0
            Dim dFullPlan As Single = 0
            Dim dFullDistanceSplay As Single = 0
            Dim dFullPlanSplay As Single = 0

            Dim dShot As Decimal
            Dim dPlanShot As Decimal

            Dim iSegmentCount As Integer = 0
            Dim iSegmentExcludedCount As Integer = 0
            For Each oSegment As cSegment In oSegments
                dShot = oSegment.Data.Data.Distance
                dPlanShot = modPaint.DistancePointToPoint(oSegment.Data.Plan.FromPoint, oSegment.Data.Plan.ToPoint)
                If oSegment.Exclude Then
                    iSegmentExcludedCount += 1
                Else
                    dDistance += dShot
                    dPlan += dPlanShot
                    iSegmentCount += 1
                End If
            Next

            Call grdSurveyInfo.Rows.Add(GetLocalizedString("infosession.textpart2"), modNumbers.MathRound(modConversion.ConvertBaseToDefaultDistance(dDistance, oSurvey), 2) & " " & cSegment.GetDistanceSimbol(oSurvey.Properties.DistanceType))
            Call grdSurveyInfo.Rows.Add(GetLocalizedString("infosession.textpart3"), modNumbers.MathRound(modConversion.ConvertBaseToDefaultDistance(dPlan, oSurvey), 2) & " " & cSegment.GetDistanceSimbol(oSurvey.Properties.DistanceType))
            Call grdSurveyInfo.Rows.Add(GetLocalizedString("infosession.textpart4"), iSegmentCount)
            'Call grdSurveyInfo.Rows.Add(GetLocalizedString("infosession.textpart2a"), modNumbers.MathRound(modConversion.ConvertBaseToDefaultDistance(dFullDistance, oSurvey), 2) & " " & cSegment.GetDistanceSimbol(oSurvey.Properties.DistanceType))
            'Call grdSurveyInfo.Rows.Add(GetLocalizedString("infosession.textpart3a"), modNumbers.MathRound(modConversion.ConvertBaseToDefaultDistance(dFullPlan, oSurvey), 2) & " " & cSegment.GetDistanceSimbol(oSurvey.Properties.DistanceType))
            Call grdSurveyInfo.Rows.Add(GetLocalizedString("infosession.textpart5"), iSegmentExcludedCount)
            Call grdSurveyInfo.Rows.Add(GetLocalizedString("infosession.textpart6"), oCalibrationSegments.Count)
        Catch
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub pUpdateChart()
        Cursor = Cursors.WaitCursor
        Dim oDatas As Dictionary(Of Date, Single) = New Dictionary(Of Date, Single)

        Call chrSessions.Series.Clear()
        Dim oSeries As DataVisualization.Charting.Series = chrSessions.Series.Add("")
        For Each oSession As cSession In oSurvey.Properties.Sessions
            Dim oSegments As cISegmentCollection = oSurvey.Segments.GetSessionSegments(oSession)
            Try
                Dim dDistance As Single = 0
                Dim dPlan As Single = 0
                Dim iSegmentCount As Integer = 0
                Dim iSegmentExcludedCount As Integer = 0
                For Each oSegment As cSegment In oSegments
                    If oSegment.Exclude Then
                        iSegmentExcludedCount += 1
                    Else
                        dDistance += oSegment.Data.Data.Distance
                        dPlan += modPaint.DistancePointToPoint(oSegment.Data.Plan.FromPoint, oSegment.Data.Plan.ToPoint)
                        iSegmentCount += 1
                    End If
                Next
                Dim dDate As Date
                Select Case cboChartType.SelectedIndex
                    Case 0, 3
                        dDate = oSession.Date
                    Case 1, 4
                        dDate = New Date(oSession.Date.Year, oSession.Date.Month, 1)
                    Case 2, 5
                        dDate = New Date(oSession.Date.Year, 1, 1)
                End Select
                Dim sValue As Single
                Select Case cboChartType.SelectedIndex
                    Case 0, 1, 2
                        sValue = modNumbers.MathRound(modConversion.ConvertBaseToDefaultDistance(dDistance, oSurvey), 2)
                    Case 3, 4, 5
                        sValue = modNumbers.MathRound(iSegmentCount, 2)
                End Select

                If oDatas.ContainsKey(dDate) Then
                    Dim sOldValue As Single = oDatas(dDate)
                    oDatas(dDate) = sOldValue + sValue
                Else
                    Call oDatas.Add(dDate, sValue)
                End If
            Catch
            End Try
        Next
        For Each oData As Date In oDatas.Keys
            Dim sValue As Single = modnumbers.mathround(oDatas(oData), 2)
            Dim iIndex As Integer = oSeries.Points.AddXY(oData, sValue)
            Select Case cboChartType.SelectedIndex
                Case 0
                    oSeries.Points(iIndex).Label = Microsoft.VisualBasic.Strings.Format(sValue, "#,##0.00 m")
                Case 1
                    oSeries.Points(iIndex).Label = Microsoft.VisualBasic.Strings.Format(sValue, "#,##0.00 m")
                    oSeries.Points(iIndex).AxisLabel = Microsoft.VisualBasic.Strings.Format(oData, "MM/yyyy")
                Case 2
                    oSeries.Points(iIndex).Label = Microsoft.VisualBasic.Strings.Format(sValue, "#,##0.00 m")
                    oSeries.Points(iIndex).AxisLabel = Microsoft.VisualBasic.Strings.Format(oData, "yyyy")
                Case 3
                    oSeries.Points(iIndex).Label = Microsoft.VisualBasic.Strings.Format(sValue, "0")
                Case 4
                    oSeries.Points(iIndex).Label = Microsoft.VisualBasic.Strings.Format(sValue, "0")
                    oSeries.Points(iIndex).AxisLabel = Microsoft.VisualBasic.Strings.Format(oData, "MM/yyyy")
                Case 5
                    oSeries.Points(iIndex).Label = Microsoft.VisualBasic.Strings.Format(sValue, "0")
                    oSeries.Points(iIndex).AxisLabel = Microsoft.VisualBasic.Strings.Format(oData, "yyyy")
            End Select
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Call Close()
    End Sub

    Private Sub mnuSurveyInfoCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSurveyInfoCopy.Click
        Cursor = Cursors.WaitCursor
        Call modCaveInfoTools.CopyGridData(grdSurveyInfo.SelectedRows)
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuSurveyInfoCopyAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSurveyInfoCopyAll.Click
        Cursor = Cursors.WaitCursor
        Call modCaveInfoTools.CopyGridData(grdSurveyInfo.Rows)
        Cursor = Cursors.Default
    End Sub

    Private Sub cboChartType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboChartType.SelectedIndexChanged
        Call pUpdateChart()
    End Sub

    Private Sub mnuSurveyInfoExport_Click(sender As Object, e As EventArgs) Handles mnuSurveyInfoExport.Click
        Call modExport.GridExportTo(oSurvey, grdSurveyInfo, Text, "", Me)
    End Sub
End Class