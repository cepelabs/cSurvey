Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.UIHelpers
Imports DevExpress.XtraEditors.Controls
Imports System.Drawing
Imports System.Drawing.Drawing2D

Friend Class frmInfoOrientation
    Private oSurvey As cSurvey.cSurvey
    Private bEventDisabled As Boolean

    Friend Sub New(ByVal Survey As cSurvey.cSurvey, ShowLinkedSurveys As Boolean, Optional ByVal Cave As String = "")
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        pnlLinkedSurveys.Visible = oSurvey.Properties.GPS.Enabled AndAlso ShowLinkedSurveys AndAlso oSurvey.LinkedSurveys.Count > 0

        bEventDisabled = True
        txtPetalsStep.EditValue = modNumbers.StringToDecimal(oSurvey.SharedSettings.GetValue("chart.bearings.step", "10"))
        chkSplay.Checked = oSurvey.SharedSettings.GetValue("chart.bearings.splay", "0")
        bEventDisabled = False

        Call pRefreshSurveyList()
        Call pRefreshCaveList(Survey, Cave)
        Call pRefreshNordInfo()
    End Sub

    Private Sub pRefreshSurveyList()
        Call cboSurveyInfoFilename.Properties.Items.Clear()
        cboSurveyInfoFilename.Properties.Items.Add(cSurveyPlaceholder.Empty)
        cboSurveyInfoFilename.Properties.Items.Add(New cSurveyPlaceholder(oSurvey))
        For Each oLinkedSurvey As cLinkedSurvey In oSurvey.LinkedSurveys.GetUsable
            Call cboSurveyInfoFilename.Properties.Items.Add(New cSurveyPlaceholder(oLinkedSurvey))
        Next
        cboSurveyInfoFilename.SelectedIndex = 1
    End Sub

    Private Sub cboSurveyInfoFilename_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSurveyInfoFilename.SelectedIndexChanged
        Dim oSurveyItem As cSurveyPlaceholder = cboSurveyInfoFilename.SelectedItem
        chkShowFileDistinct.Enabled = oSurveyItem.IsSystem
        Call pRefreshCaveList(oSurveyItem.Survey)
        Call pRefreshChart()
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
        Call cboSurveyInfoCave_EditValueChanged(cboSurveyInfoCave, EventArgs.Empty)
    End Sub

    Private Sub pRefreshNordInfo()
        Cursor = Cursors.WaitCursor

        Call grdSurveyInfo.BeginUpdate()
        Call grdSurveyInfo.ClearAll()

        Dim bTrueNord As Boolean = oSurvey.Properties.GPS.Enabled OrElse (oSurvey.Properties.NordCorrectionMode = cSurvey.cSurvey.NordCorrectionModeEnum.DeclinationBySession)
        If bTrueNord Then
            Call grdSurveyInfo.RowAdd("data0", GetLocalizedString("infoorientation.textpart1"), GetLocalizedString("infoorientation.textpart2"))
        Else
            Call grdSurveyInfo.RowAdd("data0", GetLocalizedString("infoorientation.textpart1"), GetLocalizedString("infoorientation.textpart3"))
        End If
        Call grdSurveyInfo.RowAdd("data1", GetLocalizedString("infoorientation.textpart4"), Strings.Format(oSurvey.Calculate.GeoMagDeclinationData.MeridianConvergence, "0.000") & "°")

        Dim oDecMagRow As DevExpress.XtraVerticalGrid.Rows.EditorRow = grdSurveyInfo.RowAdd("data2", GetLocalizedString("infoorientation.textpart8"), "")
        Dim oSurveyYears As List(Of Integer) = oSurvey.Properties.Sessions.GetSurveyYears
        With oSurvey.Calculate.GeoMagDeclinationData
            For Each oDate As Date In .GetDates
                Dim oRow As DevExpress.XtraVerticalGrid.Rows.EditorRow = grdSurveyInfo.RowAdd(oDecMagRow, "data_" & oDate.ToString("O"), oDate.ToShortDateString, Strings.Format(.Item(oDate), "0.000") & "°")
            Next
        End With

        Call grdSurveyInfo.RefreshDataSource()
        Call grdSurveyInfo.EndUpdate()
        Cursor = Cursors.Default
    End Sub

    Private Sub pRefreshChart()
        Cursor = Cursors.WaitCursor

        Dim iStep As Integer = txtPetalsStep.EditValue
        Dim bSplay As Boolean = chkSplay.Checked

        Dim oCurrentSurvey As cSurvey.cSurvey = cboSurveyInfoFilename.EditValue.survey

        Dim oSurveys As Dictionary(Of cSurvey.cSurvey, List(Of cCaveInfo)) = New Dictionary(Of cSurvey.cSurvey, List(Of cCaveInfo))
        If oCurrentSurvey Is Nothing Then
            For Each oSurveyplaceholder As cSurveyPlaceholder In cboSurveyInfoFilename.Properties.Items
                If Not oSurveyplaceholder.IsSystem Then
                    Call oSurveys.Add(oSurveyplaceholder.Survey, New List(Of cCaveInfo))
                End If
            Next
        Else
            oSurveys.Add(oCurrentSurvey, New List(Of cCaveInfo))
        End If

        Dim bShowFileDistinct As Boolean = chkShowFileDistinct.Enabled AndAlso chkShowFileDistinct.Checked
        Dim bShowCaveDistinct As Boolean = chkShowCaveDistinct.Enabled AndAlso chkShowCaveDistinct.Checked

        Dim sCurrentCave As String = If(cboSurveyInfoCave.Enabled, If(cboSurveyInfoCave.EditValue Is Nothing, "", cboSurveyInfoCave.EditValue.Name), "")
        If sCurrentCave = "" Then
            For Each oSurvey As cSurvey.cSurvey In oSurveys.Keys
                For Each oCaveInfo As cCaveInfo In oSurvey.Properties.CaveInfos.GetAllCaves.Values
                    Call oSurveys(oSurvey).Add(oCaveInfo)
                Next
            Next
        Else
            'for each but survey have to be only one...the one with the current cave
            For Each oSurvey As cSurvey.cSurvey In oSurveys.Keys
                Call oSurveys(oCurrentSurvey).Add(oSurvey.Properties.CaveInfos(sCurrentCave))
            Next
        End If

        Dim oAngles As SortedList = New SortedList
        Dim oSerie As DevExpress.XtraCharts.Series
        'Try
        Call chrtBearings.Series.Clear()
        Call chrtBearings.Legends.Clear()

        Dim oLegend As DevExpress.XtraCharts.Legend = New DevExpress.XtraCharts.Legend(modMain.GetLocalizedString("infoorientation.textpart6"))
        Call chrtBearings.Legends.Add(oLegend)
        oLegend.Visibility = DevExpress.Utils.DefaultBoolean.True

        For Each oSurvey As cSurvey.cSurvey In oSurveys.Keys
            If bShowFileDistinct AndAlso Not bShowCaveDistinct Then
                If oAngles.Count > 0 Then
                    For iAngle = 0 To 359 Step iStep
                        Dim iValue As Integer = 0
                        If oAngles.Contains(iAngle) Then
                            iValue = oAngles(iAngle)
                        Else
                            iValue = 0
                        End If
                        For iSubAngle = iAngle To iAngle + iStep - 1
                            Call oSerie.Points.AddPoint(iSubAngle, iValue)
                        Next
                    Next
                    Call oAngles.Clear()
                Else
                    If oSerie IsNot Nothing Then oSerie.Visible = False
                End If
                Dim sSerieName As String = oSurvey.Name
                If sSerieName = "" Then sSerieName = GetLocalizedString("infoorientation.textpart5")
                oSerie = chrtBearings.Series(chrtBearings.Series.Add(sSerieName, DevExpress.XtraCharts.ViewType.RadarArea))
                Dim oView As DevExpress.XtraCharts.RadarAreaSeriesView = oSerie.View
                oView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.False
            End If
            For Each oCaveInfo As cCaveInfo In oSurveys(oSurvey)
                If bShowCaveDistinct Then
                    If oAngles.Count > 0 Then
                        For iAngle = 0 To 359 Step iStep
                            Dim iValue As Integer = 0
                            If oAngles.Contains(iAngle) Then
                                iValue = oAngles(iAngle)
                            Else
                                iValue = 0
                            End If
                            For iSubAngle = iAngle To iAngle + iStep - 1
                                Call oSerie.Points.AddPoint(iSubAngle, iValue)
                            Next
                        Next
                        Call oAngles.Clear()
                    Else
                        If oSerie IsNot Nothing Then oSerie.Visible = False
                    End If
                    Dim sSerieName As String = oSurvey.Name & " - " & oCaveInfo.Name
                    If sSerieName = "" Then sSerieName = GetLocalizedString("infoorientation.textpart5")
                    oSerie = chrtBearings.Series(chrtBearings.Series.Add(sSerieName, DevExpress.XtraCharts.ViewType.RadarArea))
                    Dim oView As DevExpress.XtraCharts.RadarAreaSeriesView = oSerie.View
                    oView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.False
                End If

                For Each oSegment As cSegment In oSurvey.Segments.GetSurveySegments.GetCaveSegments(oCaveInfo)
                    If oSegment.IsValid AndAlso Not oSegment.IsSelfDefined AndAlso (bSplay OrElse (Not bSplay AndAlso Not oSegment.Splay)) Then
                        Dim iAngle As Integer = (modPaint.NormalizeAngle(oSegment.Data.Data.Bearing) \ iStep) * iStep
                        If oAngles.Contains(iAngle) Then
                            Dim iDistance As Integer = oAngles(iAngle)
                            Call oAngles.Remove(iAngle)
                            Call oAngles.Add(iAngle, oSegment.Data.Data.Distance + iDistance)
                        Else
                            Call oAngles.Add(iAngle, oSegment.Data.Data.Distance)
                        End If
                    End If
                Next
            Next
        Next
        If Not bShowCaveDistinct Then
            If oSerie Is Nothing Then
                Dim sSerieName As String = GetLocalizedString("infoorientation.textpart7") 'oSurveys.Keys.FirstOrDefault.Name
                oSerie = chrtBearings.Series(chrtBearings.Series.Add(sSerieName, DevExpress.XtraCharts.ViewType.RadarArea))
                Dim oView As DevExpress.XtraCharts.RadarAreaSeriesView = oSerie.View
                oView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.False
            End If
        End If
        If oAngles.Count > 0 Then
            For iAngle = 0 To 359 Step iStep
                Dim iValue As Integer = 0
                If oAngles.Contains(iAngle) Then
                    iValue = oAngles(iAngle)
                Else
                    iValue = 0
                End If
                For iSubAngle = iAngle To iAngle + iStep - 1
                    Call oSerie.Points.AddPoint(iSubAngle, iValue)
                Next
            Next
            Call oAngles.Clear()
        Else
            If oSerie IsNot Nothing Then oSerie.Visible = False
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Call Close()
    End Sub

    Private Sub chkShowCaveDistinct_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowCaveDistinct.CheckedChanged
        Call pRefreshChart()
    End Sub

    Private Sub frmInfoOrientation_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Call pRefreshNordInfo()
        End If
    End Sub

    Private Sub cboSurveyInfoCave_EditValueChanged(sender As Object, e As EventArgs) Handles cboSurveyInfoCave.EditValueChanged
        If cboSurveyInfoCave.Enabled Then
            chkShowCaveDistinct.Enabled = If(cboSurveyInfoCave.EditValue Is Nothing, "", cboSurveyInfoCave.EditValue.Name) = ""
        Else
            chkShowCaveDistinct.Enabled = True
        End If
        Call pRefreshChart()
    End Sub

    Private Sub chkShowFileDistinct_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowFileDistinct.CheckedChanged
        Call pRefreshChart()
    End Sub

    Private Sub cmdOptions_Click(sender As Object, e As EventArgs) Handles cmdOptions.Click
        flyParameters.ShowBeakForm(True)
    End Sub

    Private Sub txtPetalsStep_EditValueChanged(sender As Object, e As EventArgs) Handles txtPetalsStep.EditValueChanged
        If Not bEventDisabled AndAlso oSurvey IsNot Nothing Then
            Call oSurvey.SharedSettings.SetValue("chart.bearings.petals", modNumbers.NumberToString(txtPetalsStep.EditValue, "0"))
            Call pRefreshChart()
        End If
    End Sub
    Private Sub chkSplay_CheckedChanged(sender As Object, e As EventArgs) Handles chkSplay.CheckedChanged
        If Not bEventDisabled AndAlso oSurvey IsNot Nothing Then
            Call oSurvey.SharedSettings.SetValue("chart.bearings.splay", If(chkSplay.Checked, "1", "0"))
            Call pRefreshChart()
        End If
    End Sub

    Private Sub txtPetalsStep_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles txtPetalsStep.EditValueChanging
        If 360 Mod e.NewValue <> 0 Then
            Dim iIncrement As Integer = If(e.NewValue > e.OldValue, 1, -1)
            Do
                e.NewValue += iIncrement
            Loop Until 360 Mod e.NewValue = 0 OrElse e.NewValue < 2 OrElse e.NewValue >= 45
        End If
    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        Call modExport.ChartExportTo(oSurvey, chrtBearings, Text, "", Me)
    End Sub
End Class