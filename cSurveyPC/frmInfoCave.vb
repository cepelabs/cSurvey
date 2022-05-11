Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design

friend Class frmInfoCave
    Private oSurvey As cSurvey.cSurvey

    Friend Sub New(ByVal Survey As cSurvey.cSurvey, ShowLinkedSurveys As Boolean, Optional ByVal Cave As String = "", Optional Branch As String = "")
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        pnlLinkedSurveys.Visible = ShowLinkedSurveys AndAlso oSurvey.LinkedSurveys.Count > 0
        Call pRefreshSurveyList()
        Call pRefreshCaveList(oSurvey)
        Call pSetCurrentCave(Cave)
        Call pSetCurrentbranch(Branch)
    End Sub

    Private Sub cboSurveyInfoCave_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSurveyInfoCave.SelectedIndexChanged
        Dim oSurveyItem As cSurveyPlaceholder = cboSurveyInfoFilename.SelectedItem
        Dim sCave As String = "" & cboSurveyInfoCave.Text
        Dim sCurrentBranch As String = "" & cboSurveyInfoCaveBranch.Text
        Call pRefreshCaveBranchList(oSurveyItem.Survey, sCave, cboSurveyInfoCaveBranch)
        If "" & cboSurveyInfoCaveBranch.Text = sCurrentBranch Or Not cboSurveyInfoCaveBranch.Enabled Then
            Call pRefreshInfo()
        End If
    End Sub

    Private Sub pRefreshCaveBranchList(Survey As cSurvey.cSurvey, ByVal Cave As String, ByVal BranchesCombo As ComboBox)
        Try
            If IsNothing(Survey) Then
                cboSurveyInfoCaveBranch.Items.Clear()
                cboSurveyInfoCaveBranch.Enabled = False
            End If
            cboSurveyInfoCaveBranch.Enabled = True
            Dim oEmptyCaveInfoBranch As cCaveInfoBranch = Survey.Properties.CaveInfos.GetEmptyCaveInfoBranch(Cave)
            If Cave = "" Then
                Call BranchesCombo.Items.Clear()
                Call BranchesCombo.Items.Add(oEmptyCaveInfoBranch)
                BranchesCombo.Enabled = False
            Else
                Dim oCurrentBranch As cCaveInfoBranch = BranchesCombo.SelectedItem
                Call BranchesCombo.Items.Clear()
                Call BranchesCombo.Items.Add(oEmptyCaveInfoBranch)
                For Each oBranch As cCaveInfoBranch In Survey.Properties.CaveInfos(Cave).Branches.GetAllBranches.Values
                    Call BranchesCombo.Items.Add(oBranch)
                Next
                If BranchesCombo.Items.Count > 0 Then
                    Try
                        If oCurrentBranch Is Nothing Then
                            BranchesCombo.SelectedIndex = 0
                        Else
                            BranchesCombo.SelectedItem = oCurrentBranch
                        End If
                    Catch
                        BranchesCombo.SelectedIndex = 0
                    End Try
                    BranchesCombo.Enabled = True
                Else
                    BranchesCombo.Enabled = False
                End If
            End If
        Catch
        End Try
    End Sub

    Private Class cSurveyPlaceholder
        Private bIsLinked As Boolean
        Private oLinkedSurvey As cLinkedSurvey
        Private oSurvey As cSurvey.cSurvey

        Public ReadOnly Property Survey As cSurvey.cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public ReadOnly Property LinkedSurvey As cLinkedSurvey
            Get
                Return oLinkedSurvey
            End Get
        End Property

        Public Function IsLinked() As Boolean
            Return Not IsNothing(oLinkedSurvey)
        End Function

        Public Function IsSystem() As Boolean
            Return oSurvey Is Nothing
        End Function

        Public Overrides Function ToString() As String
            If IsNothing(oSurvey) Then
                Return ""
            Else
                If IsNothing(oLinkedSurvey) Then
                    Return oSurvey.Name
                Else
                    Return oLinkedSurvey.ToString
                End If
            End If
        End Function

        Public Sub New(Survey As cSurvey.cSurvey)
            oSurvey = Survey
        End Sub

        Public Sub New(LinkedSurvey As cSurvey.cLinkedSurvey)
            oLinkedSurvey = LinkedSurvey
            oSurvey = oLinkedSurvey.LinkedSurvey
        End Sub

        Public Sub New()

        End Sub

        Public Shared Function Empty() As cSurveyPlaceholder
            Return New cSurveyPlaceholder()
        End Function
    End Class

    Private Sub pRefreshSurveyList()
        Call cboSurveyInfoFilename.Items.Clear()
        cboSurveyInfoFilename.Items.Add(cSurveyPlaceholder.Empty)
        cboSurveyInfoFilename.Items.Add(New cSurveyPlaceholder(oSurvey))
        For Each oLinkedSurvey As cLinkedSurvey In oSurvey.LinkedSurveys.GetUsable
            Call cboSurveyInfoFilename.Items.Add(New cSurveyPlaceholder(oLinkedSurvey))
        Next
        cboSurveyInfoFilename.SelectedIndex = 1
    End Sub

    Private Sub pSetCurrentCave(CurrentCave As String)
        Dim oCurrentSurvey As cSurvey.cSurvey = cboSurveyInfoFilename.SelectedItem.survey
        If Not IsNothing(oSurvey) Then
            Dim sCurrentCave As String = "" & CurrentCave
            cboSurveyInfoCave.SelectedItem = oCurrentSurvey.Properties.CaveInfos(sCurrentCave)
        Else
            cboSurveyInfoCaveBranch.SelectedIndex = 0
        End If
    End Sub

    Private Sub pSetCurrentBranch(CurrentBranch As String)
        Dim oCurrentCave As cCaveInfo = cboSurveyInfoCave.SelectedItem
        If Not IsNothing(oCurrentCave) Then
            cboSurveyInfoCaveBranch.SelectedItem = oCurrentCave.Branches.Item(CurrentBranch)
        Else
            cboSurveyInfoCaveBranch.SelectedIndex = 0
        End If
    End Sub

    Private Sub pRefreshCaveList(Survey As cSurvey.cSurvey)
        If IsNothing(Survey) Then
            Call cboSurveyInfoCave.Items.Clear()
            cboSurveyInfoCave.Enabled = False
            Call cboSurveyInfoCaveBranch.Items.Clear()
            cboSurveyInfoCaveBranch.Enabled = False
        Else
            cboSurveyInfoCave.Enabled = True
            Dim oEmptyCaveInfo As cCaveInfo = Survey.Properties.CaveInfos.GetEmptyCaveInfo
            Call cboSurveyInfoCave.Items.Clear()
            Call cboSurveyInfoCave.Items.Add(oEmptyCaveInfo)
            For Each oCaveInfo As cCaveInfo In Survey.Properties.CaveInfos
                Call cboSurveyInfoCave.Items.Add(oCaveInfo)
            Next
            cboSurveyInfoCave.SelectedIndex = 0
        End If
    End Sub

    Private Sub pRefreshInfo()
        Cursor = Cursors.WaitCursor

        Call grdSurveyInfo.Rows.Clear()

        Dim bSystem As Boolean = cboSurveyInfoFilename.SelectedIndex = 0 Or cboSurveyInfoFilename.SelectedIndex = -1
        Dim bComplex As Boolean = Not bSystem AndAlso (cboSurveyInfoCave.SelectedIndex = 0 Or cboSurveyInfoCave.SelectedIndex = -1)
        Dim bBranch As Boolean

        Dim oCurrentSurvey As cSurvey.cSurvey = cboSurveyInfoFilename.SelectedItem.survey
        Dim sCurrentCave As String = "" & cboSurveyInfoCave.Text
        Dim sCurrentBranch As String = "" & cboSurveyInfoCaveBranch.Text

        If bSystem Then
            Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart19"), cboSurveyInfoFilename.Items.Count - 1)
        Else
            If bComplex Then
                Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart1"), oCurrentSurvey.Name)
            Else
                Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart1"), oCurrentSurvey.Name)
                Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart2"), sCurrentCave)
                If sCurrentBranch <> "" Then
                    Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart3"), sCurrentBranch)
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
            For Each oSurveyItem As cSurveyPlaceholder In cboSurveyInfoFilename.Items
                If Not oSurveyItem.IsSystem Then
                    Try
                        Dim oSpeleometric As Calculate.Plot.cSpeleometric = oSurveyItem.Survey.Calculate.Speleometrics(sCurrentCave, sCurrentBranch)
                        If oSpeleometric Is Nothing Then
                            'old survey file...do nothing...or show warning...?
                            iSurveyWithoutData += 1
                            Call oSurveyWithoutData.add(oSurveyItem.Survey.Name)
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
                        Call oSurvey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Error, "Error in " & oSurveyItem.Survey.Name & "/" & sCurrentCave & "/" & sCurrentBranch & ":" & ex.Message, True)
                    End Try
                End If
            Next
            If dQuotaMax.HasValue Then Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart20"), modNumbers.MathRound(dQuotaMax.Value, iDistanceDecimalPlace) & " " & sDistanceSimbol)
            If dQuotaMin.HasValue Then Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart21"), modNumbers.MathRound(dQuotaMin.Value, iDistanceDecimalPlace) & " " & sDistanceSimbol)
            If dQuotaMax.HasValue AndAlso dQuotaMin.HasValue Then Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart22"), modNumbers.MathRound(dQuotaMax.Value - dQuotaMin.Value, iDistanceDecimalPlace) & " " & sDistanceSimbol)

            Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart13"), modNumbers.MathRound(dLenght, iDistanceDecimalPlace) & " " & sDistanceSimbol)
            Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart14"), modNumbers.MathRound(dPlanimetricLength, iDistanceDecimalPlace) & " " & sDistanceSimbol)
            Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart15"), modNumbers.MathRound(dMeasuredLength, iDistanceDecimalPlace) & " " & sDistanceSimbol)
            Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart16"), dSegmentCount)
            Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart17"), dExcludedSegmentCount)

            If iSurveyWithoutQuota > 0 Then Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart23"), iSurveyWithoutQuota & " (" & Strings.Join(oSurveyWithoutQuota.ToArray, ";") & ")")
            If iSurveyWithoutData > 0 Then Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart24"), iSurveyWithoutData & " (" & Strings.Join(oSurveyWithoutData.ToArray, ";") & ")")
        Else
            Try
                Dim oSpeleometric As Calculate.Plot.cSpeleometric = oCurrentSurvey.Calculate.Speleometrics(sCurrentCave, sCurrentBranch)
                If oSpeleometric Is Nothing Then
                    'old survey file...do nothing...or show warning...?
                Else
                    If Not bBranch Then
                        Dim sMainCaveEntrance As String = oSpeleometric.EntranceStation
                        If sMainCaveEntrance = "" Then
                            Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart4"), GetLocalizedString("infocave.textpart4a"))
                        Else
                            Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart4"), sMainCaveEntrance)
                            If Not oSpeleometric.EntranceCoordinate Is Nothing Then
                                Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart5"), modNumbers.NumberToCoordinate(oSpeleometric.EntranceCoordinate.Latitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S"))
                                Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart6"), modNumbers.NumberToCoordinate(oSpeleometric.EntranceCoordinate.Longitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W"))
                                Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart7"), modNumbers.MathRound(oSpeleometric.EntranceCoordinate.Altitude, iDistanceDecimalPlace) & " " & sDistanceSimbol)
                            End If
                        End If
                        If oSpeleometric.DefaultPositiveVerticalRange.HasValue Then
                            Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart8"), modNumbers.MathRound(Math.Abs(oSpeleometric.DefaultPositiveVerticalRange.Value), iDistanceDecimalPlace) & " " & sDistanceSimbol)
                        Else
                            Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart8"), GetLocalizedString("infocave.textpart8a"))
                        End If
                        If oSpeleometric.DefaultNegativeVerticalRange.HasValue Then
                            Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart9"), modNumbers.MathRound(Math.Abs(oSpeleometric.DefaultNegativeVerticalRange.Value), iDistanceDecimalPlace) & " " & sDistanceSimbol)
                        Else
                            Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart9"), GetLocalizedString("infocave.textpart8a"))
                        End If
                    End If
                    Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart18"), modNumbers.MathRound(oSpeleometric.DefaultVerticalRange, iDistanceDecimalPlace) & " " & sDistanceSimbol)

                    If oSpeleometric.QuotaMax.HasValue Then Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart20"), modNumbers.MathRound(oSpeleometric.QuotaMax.Value, iDistanceDecimalPlace) & " " & sDistanceSimbol)
                    If oSpeleometric.QuotaMin.HasValue Then Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart21"), modNumbers.MathRound(oSpeleometric.QuotaMin.Value, iDistanceDecimalPlace) & " " & sDistanceSimbol)

                    Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart13"), modNumbers.MathRound(oSpeleometric.DefaultLength, iDistanceDecimalPlace) & " " & sDistanceSimbol)
                    Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart14"), modNumbers.MathRound(oSpeleometric.DefaultPlanimetricLength, iDistanceDecimalPlace) & " " & sDistanceSimbol)
                    Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart15"), modNumbers.MathRound(oSpeleometric.DefaultMeasuredLength, iDistanceDecimalPlace) & " " & sDistanceSimbol)
                    Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart16"), oSpeleometric.SegmentCount)
                        Call grdSurveyInfo.Rows.Add(GetLocalizedString("infocave.textpart17"), oSpeleometric.ExcludedSegmentCount)
                    End If
            Catch ex As Exception
                Call oSurvey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Error, "Error in " & oCurrentSurvey.Name & "/" & sCurrentCave & "/" & sCurrentBranch & ":" & ex.Message, True)
            End Try
        End If
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

    Private Sub cboSurveyInfoCaveBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSurveyInfoCaveBranch.SelectedIndexChanged
        Call pRefreshInfo()
    End Sub

    Private Sub mnuSurveyInfoExport_Click(sender As Object, e As EventArgs) Handles mnuSurveyInfoExport.Click
        Call modExport.GridExportTo(oSurvey, grdSurveyInfo, Text, "", Me)
    End Sub

    Private Sub cboSurveyInfoFilename_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSurveyInfoFilename.SelectedIndexChanged
        Dim oSurveyItem As cSurveyPlaceholder = cboSurveyInfoFilename.SelectedItem
        Call pRefreshCaveList(oSurveyItem.Survey)
        Call pRefreshInfo()
    End Sub
End Class