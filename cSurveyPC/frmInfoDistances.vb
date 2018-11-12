Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design

Public Class frmInfoDistances
    Private oSurvey As cSurvey.cSurvey

    Private oMousePointer As cMousePointer

    Public Enum InfoDistanceTypeEnum
        Planimetric = 0
        Drop = 1
        Real = 2
        X = 3
        Y = 4
        Z = 5
        Surface = 6
    End Enum

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Call Close()
    End Sub

    Private bEventDisabled As Boolean

    Friend Sub New(ByVal Survey As cSurvey.cSurvey, Optional ByVal Cave As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        oMousePointer = New cMousePointer
        bEventDisabled = True
        cboDistanceMode.SelectedIndex = 0
        chkSplays.Checked = oSurvey.SharedSettings.GetValue("info.distance.splays", "0")
        Call oSelection.AddRange(oSurvey.SharedSettings.GetValue("info.distance.tosurface.cavebranchfilter", "").ToString.Split({"|"}, StringSplitOptions.RemoveEmptyEntries))
        bEventDisabled = False
    End Sub

    Public Sub pClearDistances()
        Call grdSurveyDistances.Columns.Clear()
        Call grdSurveyDistances.Rows.Clear()
    End Sub

    Private Sub pRefreshDistances(ByVal Filter As String, ByVal Mode As InfoDistanceTypeEnum)
        If Not bEventDisabled Then
            bEventDisabled = True
            Call oMousePointer.Push(Cursors.WaitCursor)

            Dim sMin As Single = Single.MaxValue
            Dim sMax As Single = Single.MinValue
            Dim oMaxX As cTrigPoint = Nothing
            Dim oMaxY As cTrigPoint = Nothing
            Dim oMinX As cTrigPoint = Nothing
            Dim oMinY As cTrigPoint = Nothing

            grdSurveyDistances.Visible = False
            Call grdSurveyDistances.SuspendLayout()

            Dim oTmpTrigPoints As List(Of cTrigPoint) = New List(Of cTrigPoint)
            If oSelection.Count Then
                oTmpTrigPoints = oTrigpointsFromSelection.Where(Function(item) If(chkSplays.Checked, True, Not item.Data.IsSplay)).ToList
            Else
                oTmpTrigPoints = oSurvey.TrigPoints.ToList.Where(Function(item) If(chkSplays.Checked, True, Not item.Data.IsSplay)).ToList
            End If
            Dim oTrigPoints As List(Of cTrigPoint)
            Filter = Filter.Trim.ToUpper

            If Filter = "" Then
                oTrigPoints = oTmpTrigPoints
            Else
                Dim oFilter As List(Of String) = New List(Of String)
                For Each sFilter As String In Filter.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
                    sFilter = sFilter.Trim.ToUpper
                    If sFilter <> "" Then
                        Call oFilter.Add(sFilter)
                    End If
                Next
                Dim oNewTrigPoints As List(Of cTrigPoint) = New List(Of cTrigPoint)
                For Each oTrigpoint As cTrigPoint In oTmpTrigPoints
                    Dim sName As String = oTrigpoint.Name
                    For Each sFilter In oFilter
                        If (sName Like sFilter) Or (sName = sFilter) Then
                            oNewTrigPoints.Add(oTrigpoint)
                            Exit For
                        End If
                    Next
                Next
                oTrigPoints = oNewTrigPoints
            End If

            Call pClearDistances()

            If oTrigPoints.Count > 500 Then
                Call MsgBox(modMain.GetLocalizedString("infodistance.warning1"), MsgBoxStyle.OkOnly, modMain.GetLocalizedString("infodistance.warningtitle"))
            Else
                Dim h As Integer
                Dim oColumn As DataGridViewColumn

                Select Case Mode
                    Case InfoDistanceTypeEnum.Surface
                        Dim oElevation As Surface.cElevation = oSurvey.Properties.SurfaceProfileElevation
                        If Not oElevation Is Nothing Then
                            h = grdSurveyDistances.Columns.Add("col_tosurface", GetLocalizedString("infodistance.textpart5"))
                            h = grdSurveyDistances.Columns.Add("col_surface", GetLocalizedString("infodistance.textpart6"))
                            h = grdSurveyDistances.Columns.Add("col_station", GetLocalizedString("infodistance.textpart7"))
                            For Each oTrigPointY As cTrigPoint In oTrigPoints
                                If Not oTrigPointY.IsSystem Then
                                    Dim oRow As DataGridViewRow = grdSurveyDistances.Rows(grdSurveyDistances.Rows.Add())
                                    oRow.HeaderCell.Value = oTrigPointY.Name

                                    Dim sValue As Single = 0
                                    Dim sSurface As Single = modNumbers.MathRound(oElevation.GetElevation(oTrigPointY), 0)
                                    If oSurvey.Calculate.TrigPoints.Contains(oTrigPointY) Then
                                        Dim sAltitude As Single = oSurvey.Calculate.TrigPoints(oTrigPointY).Coordinate.Altitude
                                        sValue = sSurface - sAltitude
                                        sValue = modConversion.ConvertBaseToDefaultDistance(sValue, oSurvey)
                                        With oRow.Cells(0)
                                            .Style.Format = "N0"
                                            .Value = sValue
                                        End With
                                        If sValue < sMin Then
                                            sMin = sValue
                                            oMinY = oTrigPointY
                                        End If
                                        If sValue > sMax Then
                                            sMax = sValue
                                            oMaxY = oTrigPointY
                                        End If
                                        With oRow.Cells(2)
                                            .Style.Format = "N0"
                                            .Value = sAltitude
                                        End With
                                    Else
                                        With oRow.Cells(0)
                                            .Style.Format = ";;N/D"
                                            .Value = 0.0F
                                        End With
                                        With oRow.Cells(2)
                                            .Style.Format = ";;N/D"
                                            .Value = 0.0F
                                        End With
                                    End If
                                    With oRow.Cells(1)
                                        .Style.Format = "N0"
                                        .Value = sSurface
                                    End With
                                End If
                            Next
                        End If
                    Case Else
                        For Each oTrigPointX As cTrigPoint In oTrigPoints
                            If Not oTrigPointX.IsSystem Then
                                h = grdSurveyDistances.Columns.Add("col_" & oTrigPointX.Name, oTrigPointX.Name)
                                oColumn = grdSurveyDistances.Columns(h)
                                With oColumn
                                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                                    .Width = 64
                                    .FillWeight = 1
                                    .SortMode = DataGridViewColumnSortMode.NotSortable
                                End With
                            End If
                        Next
                        Dim iCount As Integer = oTrigPoints.Count ^ 2
                        Dim iIndex As Integer = 0

                        Call oSurvey.RaiseOnProgressEvent("info.calculate", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, modMain.GetLocalizedString("infodistance.textpart8"), 0, cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageCalculate Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage)
                        For Each oTrigPointY As cTrigPoint In oTrigPoints
                            If Not oTrigPointY.IsSystem Then
                                Dim oRow As DataGridViewRow = grdSurveyDistances.Rows(grdSurveyDistances.Rows.Add())
                                oRow.HeaderCell.Value = oTrigPointY.Name
                                Dim c As Integer = 0
                                Dim sValue As Single = 0
                                For Each oTrigPointX As cTrigPoint In oTrigPoints
                                    iIndex += 1
                                    If (iIndex Mod 20) = 0 Then Call oSurvey.RaiseOnProgressEvent("info.calculate", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("infodistance.textpart8"), iIndex / iCount)
                                    If Not oTrigPointX.IsSystem Then
                                        Select Case Mode
                                            Case InfoDistanceTypeEnum.Planimetric
                                                Dim oPlanPointY As PointD = New PointD(oTrigPointY.Data.X, oTrigPointY.Data.Y)
                                                Dim oPlanPointX As PointD = New PointD(oTrigPointX.Data.X, oTrigPointX.Data.Y)
                                                'sValue = Strings.Format(modPaint.DistancePointToPoint(oPlanPointX, oPlanPointY), "0.00")
                                                sValue = modPaint.DistancePointToPoint(oPlanPointX, oPlanPointY)
                                            Case InfoDistanceTypeEnum.Drop
                                                Dim sDrop As Single = Math.Abs(oTrigPointX.Data.Z - oTrigPointY.Data.Z)
                                                'sValue = Strings.Format(sDrop, "0.00")
                                                sValue = sDrop
                                            Case InfoDistanceTypeEnum.Real
                                                Dim oPlanPointY As PointD = New PointD(oTrigPointY.Data.X, oTrigPointY.Data.Y)
                                                Dim oPlanPointX As PointD = New PointD(oTrigPointX.Data.X, oTrigPointX.Data.Y)
                                                Dim sDistance As Single = modPaint.DistancePointToPoint(oPlanPointX, oPlanPointY)
                                                Dim sDrop As Single = oTrigPointX.Data.Z - oTrigPointY.Data.Z
                                                'sValue = Strings.Format(Math.Sqrt(sDistance ^ 2 + sDrop ^ 2), "0.00")
                                                sValue = Math.Sqrt(sDistance ^ 2 + sDrop ^ 2)
                                            Case InfoDistanceTypeEnum.X
                                                Dim sX As Single = oTrigPointX.Data.X - oTrigPointY.Data.X
                                                sValue = sX
                                                'sValue = Strings.Format(sX, "0.00")
                                            Case InfoDistanceTypeEnum.Y
                                                Dim sY As Single = oTrigPointX.Data.Y - oTrigPointY.Data.Y
                                                sValue = sY
                                                'sValue = Strings.Format(sY, "0.00")
                                            Case InfoDistanceTypeEnum.Z
                                                Dim sZ As Single = oTrigPointX.Data.Z - oTrigPointY.Data.Z
                                                sValue = sZ
                                                'sValue = Strings.Format(sZ, "0.00")
                                        End Select

                                        sValue = Math.Abs(sValue)
                                        sValue = modConversion.ConvertBaseToDefaultDistance(sValue, oSurvey)

                                        With oRow.Cells(c)
                                            .Style.Format = "N2"
                                            .Value = sValue
                                        End With

                                        If sValue < sMin AndAlso Not oTrigPointX Is oTrigPointY Then
                                            sMin = sValue
                                            oMinX = oTrigPointX
                                            oMinY = oTrigPointY
                                        End If

                                        If sValue > sMax AndAlso Not oTrigPointX Is oTrigPointY Then
                                            sMax = sValue
                                            oMaxX = oTrigPointX
                                            oMaxY = oTrigPointY
                                        End If
                                        c += 1
                                    End If
                                Next
                            End If
                        Next
                        Call oSurvey.RaiseOnProgressEvent("info.calculate", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 1)
                End Select

                Dim oColor As Color = Color.DimGray
                Select Case Mode
                    Case InfoDistanceTypeEnum.Surface
                        Dim sDiff As Single = sMax - sMin
                        For Each oRow As DataGridViewRow In grdSurveyDistances.Rows
                            Dim oCell As DataGridViewCell = oRow.Cells(0)
                            If TypeOf oCell.Value Is Single Then
                                Dim sValue As Single = oCell.Value
                                Dim sPercent As Single = 1 - ((sValue - sMin) / sDiff)
                                Try
                                    oCell.Style.BackColor = modPaint.LightColor(oColor, sPercent)
                                Catch
                                End Try
                            End If
                        Next
                    Case Else
                        Dim sDiff As Single = sMax - sMin
                        For Each oRow As DataGridViewRow In grdSurveyDistances.Rows
                            For Each oCell As DataGridViewCell In oRow.Cells
                                Dim sValue As Single = oCell.Value
                                Dim sPercent As Single = 1 - ((sValue - sMin) / sDiff)
                                Try
                                    oCell.Style.BackColor = modPaint.LightColor(oColor, sPercent)
                                Catch
                                End Try
                            Next
                        Next
                End Select

                Try
                    If oMaxX Is Nothing Then
                        txtMaxDistance.Text = GetLocalizedString("infodistance.textpart3") & " " & oMinY.Name & ": " & Strings.Format(sMin, "0.00") & vbCrLf & GetLocalizedString("infodistance.textpart4") & " " & oMaxY.Name & ": " & Strings.Format(sMax, "0.00")
                    ElseIf oMaxX Is Nothing AndAlso oMinX Is Nothing Then
                        txtMaxDistance.Text = ""
                    ElseIf oMinX Is Nothing Then
                        txtMaxDistance.Text = GetLocalizedString("infodistance.textpart4") & " " & GetLocalizedString("infodistance.textpart1") & " " & oMaxX.Name & " " & GetLocalizedString("infodistance.textpart2") & " " & oMaxY.Name & ": " & Strings.Format(sMax, "0.00")
                    Else
                        txtMaxDistance.Text = GetLocalizedString("infodistance.textpart4") & " " & GetLocalizedString("infodistance.textpart1") & " " & oMaxX.Name & " " & GetLocalizedString("infodistance.textpart2") & " " & oMaxY.Name & ": " & Strings.Format(sMax, "0.00") & vbCrLf &
                                              GetLocalizedString("infodistance.textpart3") & " " & GetLocalizedString("infodistance.textpart1") & " " & oMinX.Name & " " & GetLocalizedString("infodistance.textpart2") & " " & oMinY.Name & ": " & Strings.Format(sMin, "0.00")
                    End If
                Catch
                    txtMaxDistance.Text = ""
                End Try

                Call grdSurveyDistances.ResumeLayout()
                grdSurveyDistances.Visible = True
            End If

            Call oMousePointer.Pop()

            bEventDisabled = False
        End If
    End Sub

    Private Sub cboDistanceMode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDistanceMode.SelectedIndexChanged
        Call pClearDistances()
    End Sub

    Private Sub txtFilter_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtFilter.PreviewKeyDown
        If e.KeyValue = Keys.Enter Then
            Call pRefresh()
        End If
    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        Call pRefresh()
    End Sub

    Private Sub pRefresh()
        Call oSurvey.SharedSettings.SetValue("info.distance.tosurface.cavebranchfilter", Strings.Join(oSelection.ToArray, "|"))
        Call oSurvey.SharedSettings.SetValue("info.distance.splays", If(chkSplays.Checked, "1", "0"))

        Dim iMode As InfoDistanceTypeEnum = cboDistanceMode.SelectedIndex
        Call pRefreshDistances(txtFilter.Text, iMode)
    End Sub

    Private Sub mnuSurveyDistancesRefresh_Click(sender As Object, e As EventArgs) Handles mnuSurveyDistancesRefresh.Click
        Call pRefresh()
    End Sub

    Private Sub mnuSurveyDistancesCopyAll_Click(sender As Object, e As EventArgs) Handles mnuSurveyDistancesCopyAll.Click
        Cursor = Cursors.WaitCursor
        Call modCaveInfoTools.CopyGridData(grdSurveyDistances.Rows)
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuSurveyDistancesCopy_Click(sender As Object, e As EventArgs) Handles mnuSurveyDistancesCopy.Click
        Cursor = Cursors.WaitCursor
        Call modCaveInfoTools.CopyGridData(grdSurveyDistances.SelectedRows)
        Cursor = Cursors.Default
    End Sub

    Private oSelection As List(Of String) = New List(Of String)

    Private Function oTrigpointsFromSelection() As List(Of cTrigPoint)
        Dim oList As List(Of cTrigPoint) = New List(Of cTrigPoint)
        For Each sSelection As String In oSelection
            Dim p As Integer = sSelection.IndexOf(cCaveInfoBranches.sBranchSeparator)
            Dim sCaveInfo As String
            Dim sCaveInfoPath As String
            sCaveInfo = sSelection.Substring(0, p)
            sCaveInfoPath = sSelection.Substring(p + 1)
            Call oList.AddRange(oSurvey.Properties.CaveInfos.GetWithEmpty()(sCaveInfo).Branches.GetAllBranchesWithEmpty(True)(sCaveInfoPath).GetSegments.GetTrigPoints.ToList)
            'If sCaveInfoPath = "" Then
            '    Call oList.AddRange(oSurvey.Properties.CaveInfos(sCaveInfo).GetSegments.GetTrigPoints().ToList)
            'Else
            '    Call oList.AddRange(oSurvey.Properties.CaveInfos(sCaveInfo).Branches(sCaveInfoPath).GetSegments.GetTrigPoints().ToList)
            'End If
        Next
        Return oList
    End Function

    Private Sub cmdFilter_Click(sender As Object, e As EventArgs) Handles cmdFilter.Click
        Dim frmS As frmCaveBranchesSelector = New frmCaveBranchesSelector(oSurvey, oSelection)
        If frmS.ShowDialog Then
            oSelection = frmS.Selection
        End If
    End Sub

    Private Sub mnuSurveyDistancesExport_Click(sender As Object, e As EventArgs) Handles mnuSurveyDistancesExport.Click
        Call modExport.GridExportTo(oSurvey, grdSurveyDistances, Text, "", Me)
    End Sub
End Class