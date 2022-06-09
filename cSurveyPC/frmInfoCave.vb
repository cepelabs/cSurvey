Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.UIHelpers
Imports DevExpress.XtraBars

Friend Class frmInfoCave
    Private oSurvey As cSurvey.cSurvey

    Friend Sub New(ByVal Survey As cSurvey.cSurvey, ShowLinkedSurveys As Boolean, Optional ByVal Cave As String = "", Optional Branch As String = "")
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        'MsgBox("ShowLinkedSurveys=" & ShowLinkedSurveys & vbCrLf & "Survey.LinkedSurveys.Count=" & oSurvey.LinkedSurveys.Count)
        pnlLinkedSurveys.Visible = ShowLinkedSurveys AndAlso oSurvey.LinkedSurveys.Count > 0

        Call pRefreshSurveyList()
        Call pRefreshCaveList(oSurvey, Cave)
        Call pSetCurrentCave(Cave)
        Call pSetCurrentBranch(Branch)
    End Sub

    Private Sub pRefreshCaveBranchList(Survey As cSurvey.cSurvey, ByVal Cave As String, ByVal BranchesCombo As DevExpress.XtraEditors.GridLookUpEdit)
        If Cave = "" Then
            BranchesCombo.Properties.DataSource = New List(Of cCaveInfoBranch)({oSurvey.Properties.CaveInfos.GetEmptyCaveInfoBranch(Cave)})
            BranchesCombo.EditValue = BranchesCombo.Properties.DataSource(0)
            BranchesCombo.Enabled = False

        Else
            BranchesCombo.Properties.DataSource = Survey.Properties.CaveInfos(Cave).Branches.GetAllBranchesWithEmpty.Select(Function(oitem) oitem.Value).ToList
            If BranchesCombo.Properties.DataSource.Count > 0 Then
                BranchesCombo.EditValue = BranchesCombo.Properties.DataSource(0)
                BranchesCombo.Enabled = True
            Else
                BranchesCombo.Enabled = False
            End If
        End If
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

    Private Sub pSetCurrentCave(CurrentCave As String)
        Dim oCurrentSurvey As cSurvey.cSurvey = cboSurveyInfoFilename.SelectedItem.survey
        If Not IsNothing(oSurvey) Then
            Dim sCurrentCave As String = "" & CurrentCave
            cboSurveyInfoCave.EditValue = oCurrentSurvey.Properties.CaveInfos(sCurrentCave)
        Else
            cboSurveyInfoCave.EditValue = cboSurveyInfoCave.Properties.DataSource(0)
        End If
    End Sub

    Private Sub pSetCurrentBranch(CurrentBranch As String)
        Dim oCurrentCave As cCaveInfo = cboSurveyInfoCave.EditValue
        If Not IsNothing(oCurrentCave) Then
            cboSurveyInfoCaveBranch.EditValue = oCurrentCave.Branches.Item(CurrentBranch)
        Else
            cboSurveyInfoCaveBranch.EditValue = cboSurveyInfoCaveBranch.Properties.DataSource(0)
        End If
    End Sub

    Private Sub pRefreshCaveList(Survey As cSurvey.cSurvey, Optional Cave As String = Nothing)
        If IsNothing(Survey) Then
            cboSurveyInfoCave.Enabled = False
            cboSurveyInfoCaveBranch.Properties.DataSource = Nothing
            cboSurveyInfoCaveBranch.Enabled = False
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
        Call grdSurveyInfo.Rows.Clear()

        Dim bSystem As Boolean = cboSurveyInfoFilename.SelectedIndex = 0 Or cboSurveyInfoFilename.SelectedIndex = -1
        Dim bComplex As Boolean = Not bSystem AndAlso (cboSurveyInfoCave.EditValue Is cboSurveyInfoCave.Properties.DataSource(0))
        Dim bBranch As Boolean

        Dim oCurrentSurvey As cSurvey.cSurvey = cboSurveyInfoFilename.SelectedItem.survey
        Dim sCurrentCave As String = "" & If(cboSurveyInfoCave.EditValue Is Nothing, "", cboSurveyInfoCave.EditValue.name)
        Dim sCurrentBranch As String = "" & If(cboSurveyInfoCaveBranch.EditValue Is Nothing, "", cboSurveyInfoCaveBranch.EditValue.path)

        If bSystem Then
            Call grdSurveyInfo.RowAdd("filecount", GetLocalizedString("infocave.textpart19"), cboSurveyInfoFilename.Properties.Items.Count - 1)
        Else
            If cboSurveyInfoFilename.Visible Then
                If Not cboSurveyInfoFilename.SelectedItem.linkedsurvey Is Nothing Then
                    Call grdSurveyInfo.RowAdd("file", GetLocalizedString("infocave.textpart25"), cboSurveyInfoFilename.SelectedItem.linkedsurvey.getfilename)
                End If
            End If
            If bComplex Then
                Call grdSurveyInfo.RowAdd("surveyname", GetLocalizedString("infocave.textpart1"), oCurrentSurvey.Name)
            Else
                Call grdSurveyInfo.RowAdd("surveyname", GetLocalizedString("infocave.textpart1"), oCurrentSurvey.Name)
                'html is good to see but ugly in export...for now disabled
                'Call grdSurveyInfo.RowAdd("cavename", GetLocalizedString("infocave.textpart2"), If(cboSurveyInfoCave.EditValue Is Nothing, "", cboSurveyInfoCave.EditValue.ToHTMLString))
                Call grdSurveyInfo.RowAdd("cavename", GetLocalizedString("infocave.textpart2"), If(cboSurveyInfoCave.EditValue Is Nothing, "", cboSurveyInfoCave.EditValue.name))
                If sCurrentBranch <> "" Then
                    Call grdSurveyInfo.RowAdd("branchname", GetLocalizedString("infocave.textpart3"), sCurrentBranch)
                    bBranch = True
                End If
            End If
        End If

        Dim sDistanceSimbol As String = cSegment.GetDistanceSimbol(oSurvey.Properties.DistanceType)
        Dim iDistanceDecimalPlace As Integer = modConversion.GetDistanceTypeDecimalPlaces(oSurvey.Properties.DistanceType)

        If bSystem Then
            Dim dLenght As Decimal
            Dim dPlanimetricLength As Decimal
            Dim dMeasuredLength As Decimal
            Dim dSegmentCount As Decimal
            Dim dExcludedSegmentCount As Decimal
            Dim dQuotaMin As Decimal?
            Dim dQuotaMax As Decimal?
            Dim iSurveyWithoutQuota As Integer
            Dim iSurveyWithoutData As Integer
            Dim oSurveyWithoutData As List(Of String) = New List(Of String)
            Dim oSurveyWithoutQuota As List(Of String) = New List(Of String)
            For Each oSurveyItem As cSurveyPlaceholder In cboSurveyInfoFilename.Properties.Items
                If Not oSurveyItem.IsSystem Then
                    Try
                        Dim oSpeleometric As Calculate.Plot.cSpeleometric = oSurveyItem.Survey.Calculate.Speleometrics(sCurrentCave, sCurrentBranch)
                        If oSpeleometric Is Nothing Then
                            'old survey file...do nothing...or show warning...?
                            iSurveyWithoutData += 1
                            Call oSurveyWithoutData.Add(oSurveyItem.Survey.Name)
                        Else
                            If oSpeleometric.QuotaMax.HasValue AndAlso oSpeleometric.QuotaMin.HasValue Then
                                Dim dSurveyQuotaMax As Decimal = oSpeleometric.QuotaMax
                                Dim dSurveyQuotaMin As Decimal = oSpeleometric.QuotaMin
                                If dQuotaMax.HasValue Then
                                    If dSurveyQuotaMax > dQuotaMax Then dQuotaMax = dSurveyQuotaMax
                                Else
                                    dQuotaMax = dSurveyQuotaMax
                                End If
                                If dQuotaMin.HasValue Then
                                    If dSurveyQuotaMin < dQuotaMin Then dQuotaMin = dSurveyQuotaMin
                                Else
                                    dQuotaMin = dSurveyQuotaMin
                                End If
                            Else
                                'for old speleometrics that does not have quota try using caveentrance and drop...
                                Dim sMainCaveEntrance As String = oSpeleometric.EntranceStation
                                If (sMainCaveEntrance = "") OrElse IsNothing(oSpeleometric.EntranceCoordinate) Then
                                    iSurveyWithoutQuota += 1
                                    Call oSurveyWithoutQuota.Add(oSurveyItem.Survey.Name)
                                Else
                                    Dim dQuota As Decimal = modConversion.ConvertBaseToDefaultDistance(oSpeleometric.EntranceCoordinate.Altitude, oSurvey)
                                    'if there is an entrace there are also positive and negative range...
                                    Dim dSurveyQuotaMax As Decimal = dQuota + modConversion.ConvertBaseToDefaultDistance(oSpeleometric.PositiveVerticalRange.GetValueOrDefault(0), oSurvey)
                                    Dim dSurveyQuotaMin As Decimal = dQuota - modConversion.ConvertBaseToDefaultDistance(oSpeleometric.NegativeVerticalRange.GetValueOrDefault(0), oSurvey)
                                    If dSurveyQuotaMax > dQuotaMax Then dQuotaMax = dSurveyQuotaMax
                                    If dSurveyQuotaMin < dQuotaMin Then dQuotaMin = dSurveyQuotaMin
                                End If
                            End If

                            dLenght += oSpeleometric.DefaultLength
                            dPlanimetricLength += oSpeleometric.DefaultPlanimetricLength
                            dMeasuredLength += oSpeleometric.DefaultMeasuredLength
                            dSegmentCount += oSpeleometric.SegmentCount
                            dExcludedSegmentCount += oSpeleometric.ExcludedSegmentCount
                        End If
                    Catch ex As Exception
                        Call oSurvey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Error, "Error in " & oSurveyItem.Survey.Name & "/" & sCurrentCave & "/" & sCurrentBranch & ":" & ex.Message)
                    End Try
                End If
            Next
            If dQuotaMax.HasValue Then Call grdSurveyInfo.RowAdd("qmax", GetLocalizedString("infocave.textpart20"), modNumbers.MathRound(dQuotaMax.Value, iDistanceDecimalPlace) & " " & sDistanceSimbol)
            If dQuotaMin.HasValue Then Call grdSurveyInfo.RowAdd("qmin", GetLocalizedString("infocave.textpart21"), modNumbers.MathRound(dQuotaMin.Value, iDistanceDecimalPlace) & " " & sDistanceSimbol)
            If dQuotaMax.HasValue AndAlso dQuotaMin.HasValue Then Call grdSurveyInfo.RowAdd("qdelta", GetLocalizedString("infocave.textpart22"), modNumbers.MathRound(dQuotaMax.Value - dQuotaMin.Value, iDistanceDecimalPlace) & " " & sDistanceSimbol)

            Call grdSurveyInfo.RowAdd("l", GetLocalizedString("infocave.textpart13"), modNumbers.MathRound(dLenght, iDistanceDecimalPlace) & " " & sDistanceSimbol)
            Call grdSurveyInfo.RowAdd("pl", GetLocalizedString("infocave.textpart14"), modNumbers.MathRound(dPlanimetricLength, iDistanceDecimalPlace) & " " & sDistanceSimbol)
            Call grdSurveyInfo.RowAdd("ml", GetLocalizedString("infocave.textpart15"), modNumbers.MathRound(dMeasuredLength, iDistanceDecimalPlace) & " " & sDistanceSimbol)
            Call grdSurveyInfo.RowAdd("sc", GetLocalizedString("infocave.textpart16"), dSegmentCount)
            Call grdSurveyInfo.RowAdd("esc", GetLocalizedString("infocave.textpart17"), dExcludedSegmentCount)

            If iSurveyWithoutQuota > 0 Then Call grdSurveyInfo.RowAdd("nqc", GetLocalizedString("infocave.textpart23"), iSurveyWithoutQuota & " (" & Strings.Join(oSurveyWithoutQuota.ToArray, ";") & ")")
            If iSurveyWithoutData > 0 Then Call grdSurveyInfo.RowAdd("ndc", GetLocalizedString("infocave.textpart24"), iSurveyWithoutData & " (" & Strings.Join(oSurveyWithoutData.ToArray, ";") & ")")
        Else
            Try
                Dim oSpeleometric As Calculate.Plot.cSpeleometric = oCurrentSurvey.Calculate.Speleometrics(sCurrentCave, sCurrentBranch)
                If oSpeleometric Is Nothing Then
                    'old survey file...do nothing...or show warning...?
                Else
                    If Not bBranch Then
                        Dim sMainCaveEntrance As String = oSpeleometric.EntranceStation
                        If sMainCaveEntrance = "" Then
                            Call grdSurveyInfo.RowAdd("mainentrance", GetLocalizedString("infocave.textpart4"), GetLocalizedString("infocave.textpart4a"))
                        Else
                            Call grdSurveyInfo.RowAdd("mainentrance", GetLocalizedString("infocave.textpart4"), sMainCaveEntrance)
                            If Not oSpeleometric.EntranceCoordinate Is Nothing Then
                                Call grdSurveyInfo.RowAdd("lat", GetLocalizedString("infocave.textpart5"), modNumbers.NumberToCoordinate(oSpeleometric.EntranceCoordinate.Latitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S"))
                                Call grdSurveyInfo.RowAdd("lon", GetLocalizedString("infocave.textpart6"), modNumbers.NumberToCoordinate(oSpeleometric.EntranceCoordinate.Longitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W"))
                                Call grdSurveyInfo.RowAdd("alt", GetLocalizedString("infocave.textpart7"), modNumbers.MathRound(oSpeleometric.EntranceCoordinate.Altitude, iDistanceDecimalPlace) & " " & sDistanceSimbol)
                            End If
                        End If
                        If oSpeleometric.DefaultPositiveVerticalRange.HasValue Then
                            Call grdSurveyInfo.RowAdd("pvr", GetLocalizedString("infocave.textpart8"), modNumbers.MathRound(Math.Abs(oSpeleometric.DefaultPositiveVerticalRange.Value), iDistanceDecimalPlace) & " " & sDistanceSimbol)
                        Else
                            Call grdSurveyInfo.RowAdd("pvr", GetLocalizedString("infocave.textpart8"), GetLocalizedString("infocave.textpart8a"))
                        End If
                        If oSpeleometric.DefaultNegativeVerticalRange.HasValue Then
                            Call grdSurveyInfo.RowAdd("nvr", GetLocalizedString("infocave.textpart9"), modNumbers.MathRound(Math.Abs(oSpeleometric.DefaultNegativeVerticalRange.Value), iDistanceDecimalPlace) & " " & sDistanceSimbol)
                        Else
                            Call grdSurveyInfo.RowAdd("nvr", GetLocalizedString("infocave.textpart9"), GetLocalizedString("infocave.textpart8a"))
                        End If
                    End If
                    Call grdSurveyInfo.RowAdd("vr", GetLocalizedString("infocave.textpart18"), modNumbers.MathRound(oSpeleometric.DefaultVerticalRange, iDistanceDecimalPlace) & " " & sDistanceSimbol)

                    If oSpeleometric.QuotaMax.HasValue Then Call grdSurveyInfo.RowAdd("qmax", GetLocalizedString("infocave.textpart20"), modNumbers.MathRound(oSpeleometric.QuotaMax.Value, iDistanceDecimalPlace) & " " & sDistanceSimbol)
                    If oSpeleometric.QuotaMin.HasValue Then Call grdSurveyInfo.RowAdd("qmin", GetLocalizedString("infocave.textpart21"), modNumbers.MathRound(oSpeleometric.QuotaMin.Value, iDistanceDecimalPlace) & " " & sDistanceSimbol)

                    Call grdSurveyInfo.RowAdd("l", GetLocalizedString("infocave.textpart13"), modNumbers.MathRound(oSpeleometric.DefaultLength, iDistanceDecimalPlace) & " " & sDistanceSimbol)
                    Call grdSurveyInfo.RowAdd("pl", GetLocalizedString("infocave.textpart14"), modNumbers.MathRound(oSpeleometric.DefaultPlanimetricLength, iDistanceDecimalPlace) & " " & sDistanceSimbol)
                    Call grdSurveyInfo.RowAdd("ml", GetLocalizedString("infocave.textpart15"), modNumbers.MathRound(oSpeleometric.DefaultMeasuredLength, iDistanceDecimalPlace) & " " & sDistanceSimbol)
                    Call grdSurveyInfo.RowAdd("sc", GetLocalizedString("infocave.textpart16"), oSpeleometric.SegmentCount)
                    Call grdSurveyInfo.RowAdd("esc", GetLocalizedString("infocave.textpart17"), oSpeleometric.ExcludedSegmentCount)
                End If
            Catch ex As Exception
                Call oSurvey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Error, "Error in " & oCurrentSurvey.Name & "/" & sCurrentCave & "/" & sCurrentBranch & ":" & ex.Message)
            End Try
        End If
        Call grdSurveyInfo.RefreshDataSource()
        Call grdSurveyInfo.EndUpdate()
        Cursor = Cursors.Default
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

    Private Sub cboSurveyInfoCave_EditValueChanged(sender As Object, e As EventArgs) Handles cboSurveyInfoCave.EditValueChanged
        Dim oSurveyItem As cSurveyPlaceholder = cboSurveyInfoFilename.SelectedItem
        Dim oCave As cCaveInfo = cboSurveyInfoCave.EditValue
        Dim oBranch As cCaveInfoBranch = cboSurveyInfoCaveBranch.EditValue
        Dim sCave As String = "" & If(cboSurveyInfoCave.EditValue Is Nothing, "", cboSurveyInfoCave.EditValue.name)
        Dim sCurrentBranch As String = "" & If(cboSurveyInfoCaveBranch.EditValue Is Nothing, "", cboSurveyInfoCaveBranch.EditValue.path)
        Call pRefreshCaveBranchList(oSurveyItem.Survey, sCave, cboSurveyInfoCaveBranch)
        If cboSurveyInfoCaveBranch.EditValue.path = sCurrentBranch Or Not cboSurveyInfoCaveBranch.Enabled Then
            Call pRefresh()
        End If
    End Sub

    Private Sub cboSurveyInfoCaveBranch_EditValueChanged(sender As Object, e As EventArgs) Handles cboSurveyInfoCaveBranch.EditValueChanged
        Call pRefresh()
    End Sub

    Private Sub grdSurveyInfo_PopupMenuShowing(sender As Object, e As DevExpress.XtraVerticalGrid.Events.PopupMenuShowingEventArgs) Handles grdSurveyInfo.PopupMenuShowing
        If grdSurveyInfo.CalcHitInfo(grdSurveyInfo.PointToClient(Cursor.Position)).HitInfoType = DevExpress.XtraVerticalGrid.HitInfoTypeEnum.ValueCell Then
            e.Menu.Enabled = False
            Call mnuContext.ShowPopup(Cursor.Position)
        End If
    End Sub

    Private Sub cboSurveyInfoFilename_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSurveyInfoFilename.SelectedIndexChanged
        Dim oSurveyItem As cSurveyPlaceholder = cboSurveyInfoFilename.SelectedItem
        Call pRefreshCaveList(oSurveyItem.Survey)
        Call pRefresh()
    End Sub
End Class