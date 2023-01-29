Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.UIHelpers
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports DevExpress.XtraBars
Imports cSurveyPC.cSurvey.Helper.Editor

Friend Class frmInfoDepth
    Private oSurvey As cSurvey.cSurvey
    Private bEventDisabled As Boolean

    Friend Sub New(ByVal Survey As cSurvey.cSurvey, ShowLinkedSurveys As Boolean, Optional ByVal Cave As String = "")
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        pnlLinkedSurveys.Visible = oSurvey.Properties.GPS.Enabled AndAlso ShowLinkedSurveys AndAlso oSurvey.LinkedSurveys.Count > 0

        bEventDisabled = True
        txtDepthStep.EditValue = modNumbers.StringToDecimal(oSurvey.SharedSettings.GetValue("chart.depth.step", "1"))
        chkSplay.Checked = oSurvey.SharedSettings.GetValue("chart.depth.splay", "0")
        cboCountType.SelectedIndex = oSurvey.SharedSettings.GetValue("chart.depth.counttype", "0")
        bEventDisabled = False

        Call pRefreshSurveyList()
        Call pRefreshCaveList(Survey, Cave)
        Call pRefreshQuoteInfo()
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

    Private Sub pRefreshQuoteInfo()
        Cursor = Cursors.WaitCursor

        Cursor = Cursors.Default
    End Sub

    Friend Class cQuota
        Private oSegment As cSegment
        Private dQuota As Decimal
        Private dValue As Decimal

        Public ReadOnly Property Quota As Decimal
            Get
                Return dQuota
            End Get
        End Property

        Public ReadOnly Property Value As Decimal
            Get
                Return dValue
            End Get
        End Property

        Public ReadOnly Property Segment As cSegment
            Get
                Return oSegment
            End Get
        End Property

        Public Sub Add(Value As Decimal)
            dValue += Value
        End Sub

        Public Sub New(Segment As cSegment, Quota As Decimal, Value As Decimal)
            oSegment = Segment
            dQuota = Quota
            dValue = Value
        End Sub
    End Class
    Private Sub pRefreshChart()
        If oSurvey.Properties.Origin <> "" Then
            Cursor = Cursors.WaitCursor
            Dim oDataSource As List(Of cQuota) = New List(Of cQuota)

            Dim dHBlock As Decimal = txtDepthStep.EditValue
            Dim bSplay As Boolean = chkSplay.Checked
            Dim iCountType As Integer = cboCountType.SelectedIndex

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

            Dim oQuotes As Dictionary(Of Decimal, Decimal) = New Dictionary(Of Decimal, Decimal)
            Dim oSerie As DevExpress.XtraCharts.Series
            'Try
            Call chrtBearings.Series.Clear()
            Call chrtBearings.Legends.Clear()

            Dim oLegend As DevExpress.XtraCharts.Legend = New DevExpress.XtraCharts.Legend(modMain.GetLocalizedString("infoorientation.textpart6"))
            Call chrtBearings.Legends.Add(oLegend)
            oLegend.Visibility = DevExpress.Utils.DefaultBoolean.True

            For Each oSurvey As cSurvey.cSurvey In oSurveys.Keys
                Dim dBaseZ As Decimal = oSurvey.Calculate.TrigPoints(oSurvey.Properties.Origin).Coordinate.Altitude

                If bShowFileDistinct AndAlso Not bShowCaveDistinct Then
                    If oQuotes.Count > 0 Then
                        For Each dKey As Decimal In oQuotes.Keys
                            oSerie.Points.AddPoint(dKey, oQuotes(dKey))
                        Next
                        Call oQuotes.Clear()
                    Else
                        If oSerie IsNot Nothing Then oSerie.Visible = False
                    End If
                    Dim sSerieName As String = oSurvey.Name
                    If sSerieName = "" Then sSerieName = GetLocalizedString("infoorientation.textpart5")
                    oSerie = chrtBearings.Series(chrtBearings.Series.Add(sSerieName, DevExpress.XtraCharts.ViewType.Bar))
                    Dim oView As DevExpress.XtraCharts.BarSeriesView = oSerie.View
                End If
                For Each oCaveInfo As cCaveInfo In oSurveys(oSurvey)
                    If bShowCaveDistinct Then
                        If oQuotes.Count > 0 Then
                            For Each dKey As Decimal In oQuotes.Keys
                                oSerie.Points.AddPoint(dKey, oQuotes(dKey))
                            Next
                            Call oQuotes.Clear()
                        Else
                            If oSerie IsNot Nothing Then oSerie.Visible = False
                        End If
                        Dim sSerieName As String = oSurvey.Name & " - " & oCaveInfo.Name
                        If sSerieName = "" Then sSerieName = GetLocalizedString("infoorientation.textpart5")
                        oSerie = chrtBearings.Series(chrtBearings.Series.Add(sSerieName, DevExpress.XtraCharts.ViewType.Bar))
                        Dim oView As DevExpress.XtraCharts.BarSeriesView = oSerie.View
                    End If

                    For Each oSegment As cSegment In oSurvey.Segments.GetSurveySegments.GetCaveSegments(oCaveInfo)
                        If oSegment.IsValid AndAlso Not oSegment.IsSelfDefined AndAlso (bSplay OrElse (Not bSplay AndAlso Not oSegment.Splay)) Then
                            Dim dZ1 As Decimal = dBaseZ + -oSegment.Data.Profile.FromPoint.Y
                            Dim dZ2 As Decimal = dBaseZ + -oSegment.Data.Profile.ToPoint.Y
                            If dZ1 > dZ2 Then
                                Dim dTemp As Decimal = dZ1
                                dZ1 = dZ2
                                dZ2 = dTemp
                            End If

                            Dim dDistance As Decimal
                            Select Case iCountType
                                Case 0
                                    dDistance = oSegment.Data.Data.Distance
                                Case 1
                                    dDistance = oSegment.Data.Plan.GetProjectedDistance
                            End Select
                            If dDistance > 0D Then
                                Dim oQuotesTemp As Dictionary(Of Decimal, Decimal) = New Dictionary(Of Decimal, Decimal)
                                If dZ2 = dZ1 Then
                                    Dim dH As Decimal = Math.Floor(dZ1 / dHBlock)
                                    oQuotesTemp.Add(dH * dHBlock, dDistance)
                                Else
                                    Dim dVDrop As Decimal = dZ2 - dZ1
                                    Dim dFactor As Decimal = dDistance / dVDrop
                                    Dim iIndex As Integer = 0
                                    Do
                                        Dim dH As Decimal = Math.Floor(dZ1 / dHBlock)
                                        Dim dR As Decimal = dZ1 Mod dHBlock
                                        If dR = 0 Then
                                            If dZ1 + dHBlock > dZ2 Then
                                                oQuotesTemp.Add(dH * dHBlock, Math.Abs((dZ2 - dZ1) * dFactor))
                                            Else
                                                oQuotesTemp.Add(dH * dHBlock, Math.Abs(dHBlock * dFactor))
                                            End If
                                            dZ1 += dHBlock
                                        Else
                                            If iIndex = 0 Then
                                                dR = dHBlock - dR
                                            End If
                                            If dZ1 + dR > dZ2 Then
                                                oQuotesTemp.Add(dH * dHBlock, Math.Abs((dZ2 - dZ1) * dFactor))
                                            Else
                                                oQuotesTemp.Add(dH * dHBlock, Math.Abs(dR * dFactor))
                                            End If
                                            dZ1 += dR
                                        End If
                                        iIndex += 1
                                    Loop Until dZ1 >= dZ2
                                End If

                                For Each dQuota As Decimal In oQuotesTemp.Keys
                                    Dim dValue As Decimal = oQuotesTemp(dQuota)
                                    If oQuotes.ContainsKey(dQuota) Then
                                        Dim dTemp As Decimal = oQuotes(dQuota)
                                        oQuotes.Remove(dQuota)
                                        oQuotes.Add(dQuota, dTemp + dValue)
                                    Else
                                        Call oQuotes.Add(dQuota, dValue)
                                    End If
                                    Call oDataSource.Add(New cQuota(oSegment, dQuota, dValue))
                                Next
                            End If
                        End If
                    Next
                Next
            Next
            If Not bShowCaveDistinct Then
                If oSerie Is Nothing Then
                    Dim sSerieName As String = GetLocalizedString("infoorientation.textpart7")
                    oSerie = chrtBearings.Series(chrtBearings.Series.Add(sSerieName, DevExpress.XtraCharts.ViewType.Bar))
                    Dim oView As DevExpress.XtraCharts.BarSeriesView = oSerie.View
                End If
            End If
            If oQuotes.Count > 0 Then
                For Each dKey As Decimal In oQuotes.Keys
                    oSerie.Points.AddPoint(dKey, oQuotes(dKey))
                Next
                Call oQuotes.Clear()
            Else
                If oSerie IsNot Nothing Then oSerie.Visible = False
            End If

            grdData.DataSource = oDataSource

            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Call Close()
    End Sub

    Private Sub chkShowCaveDistinct_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowCaveDistinct.CheckedChanged
        Call pRefreshChart()
    End Sub

    Private Sub frmInfoOrientation_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Call pRefreshQuoteInfo()
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

    Private Sub chkSplay_CheckedChanged(sender As Object, e As EventArgs) Handles chkSplay.CheckedChanged
        If Not bEventDisabled AndAlso oSurvey IsNot Nothing Then
            Call oSurvey.SharedSettings.SetValue("chart.depth.splay", If(chkSplay.Checked, "1", "0"))
            Call pRefreshChart()
        End If
    End Sub

    Private Sub txtDepthStep_EditValueChanged(sender As Object, e As EventArgs) Handles txtDepthStep.EditValueChanged
        If Not bEventDisabled AndAlso oSurvey IsNot Nothing Then
            Call oSurvey.SharedSettings.SetValue("chart.depth.step", modNumbers.NumberToString(txtDepthStep.EditValue, "0"))
            Call pRefreshChart()
        End If
    End Sub

    Private Sub cboCountType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCountType.SelectedIndexChanged
        If Not bEventDisabled AndAlso oSurvey IsNot Nothing Then
            Call oSurvey.SharedSettings.SetValue("chart.depth.counttype", cboCountType.SelectedIndex)
            Call pRefreshChart()
        End If
    End Sub

    Private Sub grdDataView_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles grdDataView.PopupMenuShowing
        If e.HitInfo.InRowCell OrElse e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.EmptyRow Then
            e.Allow = False
            Call mnuContext.ShowPopup(Cursor.Position)
        End If
    End Sub

    Private Sub btnCopy_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopy.ItemClick
        Call grdDataView.CopyRow
    End Sub

    Private Sub btnCopyAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyAll.ItemClick
        Call grdDataView.CopyRows
    End Sub

    Private Sub btnCopyValue_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyValue.ItemClick
        Call grdDataView.CopyRowValue
    End Sub

    Private Sub btnCopyValues_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCopyValues.ItemClick
        Call grdDataView.CopyRowValues
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnExport.ItemClick
        Call modExport.GridExportTo(oSurvey, grdData, Text, "", Me)
    End Sub

    Private Sub grdDataView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles grdDataView.RowCellStyle
        Dim oQuota As cQuota = grdDataView.GetRow(e.RowHandle)
        If Not oQuota Is Nothing Then
            Dim oSegment As cSegment = oQuota.Segment
            If e.Column Is colSegmentsBranchBranchColor Then
                e.Appearance.BackColor = oSurvey.Properties.CaveInfos.GetColor(oSegment.Cave, oSegment.Branch, System.Drawing.Color.LightGray)
            ElseIf e.Column Is colDataBranchCaveColor Then
                e.Appearance.BackColor = oSurvey.Properties.CaveInfos.GetColor(oSegment.Cave, "", System.Drawing.Color.LightGray)
                'ElseIf e.Column Is coldataSessionColor Then
                '    e.Appearance.BackColor = oSurvey.Properties.Sessions.GetColor(oSegment.Session, System.Drawing.Color.LightGray)
            ElseIf e.Column Is colDataSegmentTo Then
                If oSegment.To Like "*(*)" Then
                    If My.Application.RuntimeSettings.GetSetting("isdarkskin") Then
                        e.Appearance.ForeColor = modPaint.LightColor(My.Application.RuntimeSettings.GetSetting("backcolor"), 0.25)
                    Else
                        e.Appearance.ForeColor = modPaint.DarkColor(My.Application.RuntimeSettings.GetSetting("backcolor"), 0.25)
                    End If
                End If
            ElseIf e.Column Is colDataSegmentFrom Then
                If oSegment.From Like "*(*)" Then
                    If My.Application.RuntimeSettings.GetSetting("isdarkskin") Then
                        e.Appearance.ForeColor = modPaint.LightColor(My.Application.RuntimeSettings.GetSetting("backcolor"), 0.25)
                    Else
                        e.Appearance.ForeColor = modPaint.DarkColor(My.Application.RuntimeSettings.GetSetting("backcolor"), 0.25)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        Call modExport.ChartExportTo(oSurvey, chrtBearings, Text, "", Me)
    End Sub
End Class