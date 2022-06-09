Imports System.Data
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports DevExpress.Charts.Heatmap
Imports DevExpress.Utils
Imports DevExpress.XtraCharts
Imports Newtonsoft.Json.Linq

Friend Class cDockDistances
    Private oSurvey As cSurvey.cSurvey

    Public Enum InfoDistanceTypeEnum
        Planimetric = 0
        Drop = 1
        Real = 2
        X = 3
        Y = 4
        Z = 5
        Surface = 6
    End Enum

    Private bEventDisabled As Boolean

    Private Class cElevationItem
        Private oTrigpointFrom As cTrigPoint
        Private sFrom As String
        Private sSurface As Single
        Private sStation As Single
        Private sToSurface As Single

        Public ReadOnly Property TrigpointFrom As cTrigPoint
            Get
                Return oTrigpointFrom
            End Get
        End Property

        Public Sub New(TrigpointFrom As cTrigPoint, Surface As Single, Station As Single, ToSurface As Single)
            oTrigpointFrom = TrigpointFrom
            sFrom = TrigpointFrom.Name
            sSurface = Surface
            sStation = Station
            sToSurface = ToSurface
        End Sub

        Public ReadOnly Property ToSurface As Single
            Get
                Return sToSurface
            End Get
        End Property

        Public ReadOnly Property Station As Single
            Get
                Return sStation
            End Get
        End Property

        Public ReadOnly Property Surface As Single
            Get
                Return sSurface
            End Get
        End Property

        Public ReadOnly Property From As String
            Get
                Return sFrom
            End Get
        End Property
    End Class

    Private Class cDistanceItem
        Private oTrigpointX As cTrigPoint
        Private oTrigpointY As cTrigPoint
        Private sX As String
        Private sY As String
        Private sValue As Single

        Public ReadOnly Property TrigpointX As cTrigPoint
            Get
                Return oTrigpointX
            End Get
        End Property

        Public ReadOnly Property TrigpointY As cTrigPoint
            Get
                Return oTrigpointY
            End Get
        End Property

        Public Sub New(TrigpointX As cTrigPoint, TrigpointY As cTrigPoint, Value As Single)
            oTrigpointX = TrigpointX
            sX = TrigpointX.Name
            oTrigpointY = TrigpointY
            sY = TrigpointY.Name
            sValue = Value
        End Sub

        Public ReadOnly Property Value As Single
            Get
                Return sValue
            End Get
        End Property

        Public ReadOnly Property Y As String
            Get
                Return sY
            End Get
        End Property

        Public ReadOnly Property X As String
            Get
                Return sX
            End Get
        End Property
    End Class

    Public Sub SetSurvey(ByVal Survey As cSurveyPC.cSurvey.cSurvey)
        oSurvey = Survey
        HeatmapControl1.DataAdapter = Nothing
        GridView1.Columns.Clear()
        GridControl1.DataSource = Nothing
        If oSurvey Is Nothing Then
            Enabled = False
        Else
            Enabled = True
            bSplay = oSurvey.SharedSettings.GetValue("info.distance.splays", "0")
            oSelection = pDeserializeSelection(oSurvey.SharedSettings.GetValue("info.distance.filter", ""))
        End If
    End Sub
    Friend Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        bEventDisabled = True
        btnDistanceMode.EditValue = cboDistanceMode.Items(0)
        GridControl1.Dock = DockStyle.Fill
        HeatmapControl1.Dock = DockStyle.Fill
        bEventDisabled = False
    End Sub

    Public Sub pClearDistances()
        HeatmapControl1.DataAdapter = Nothing
    End Sub

    Private iMode As InfoDistanceTypeEnum = InfoDistanceTypeEnum.Planimetric
    Private iView As Integer

    Private Function pSerializeSelection() As String
        Dim oItems As Newtonsoft.Json.Linq.JArray = New Newtonsoft.Json.Linq.JArray
        For Each oTrigpoint As cTrigPoint In oSelection
            Dim oItem As JObject = New Newtonsoft.Json.Linq.JObject
            oItem.Add(New JProperty("s", New JValue(If(oTrigpoint.Survey Is oSurvey, ".", oTrigpoint.Survey.ID))))
            oItem.Add(New JProperty("st", New JValue(oTrigpoint.Name)))
            oItems.Add(oItem)
        Next
        Return oItems.ToString  'String.Join("|", oSelection.Select(Function(oTrigpoint) If(oTrigpoint.Survey Is oSurvey, ".", oTrigpoint.Survey.ID) & "|" & oTrigpoint.Name))
    End Function

    Private Function pDeserializeSelection(Selection As String) As List(Of cTrigPoint)
        Dim oResults As List(Of cTrigPoint) = New List(Of cTrigPoint)
        Try
            Dim oItems As Newtonsoft.Json.Linq.JArray = Newtonsoft.Json.Linq.JArray.Parse(Selection)
            For Each oItem As JObject In oItems
                Dim oResult As cTrigPoint = Nothing
                Dim sSurvey As String = oItem.GetValue("s")
                Dim sTrigpoint As String = oItem.GetValue("st")
                If sSurvey = "." Then
                    If oSurvey.TrigPoints.Contains(sTrigpoint) Then
                        oResult = oSurvey.TrigPoints(sTrigpoint)
                    End If
                Else
                    If oSurvey.LinkedSurveys.Contains(sSurvey) Then
                        Dim oLinkedsurvey As cSurveyPC.cSurvey.cSurvey = oSurvey.LinkedSurveys.GetByID(sSurvey).LinkedSurvey
                        If oLinkedsurvey.TrigPoints.Contains(sTrigpoint) Then
                            oResult = oLinkedsurvey.TrigPoints(sTrigpoint)
                        End If
                    End If
                End If
                If oResult IsNot Nothing Then
                    If Not oResults.Contains(oResult) Then
                        Call oResults.Add(oResult)
                    End If
                End If
            Next
        Catch ex As Exception
            'nothing...old data in some no more supported format...
        End Try
        Return oResults
    End Function

    Private Sub pSettingsSave()
        Call oSurvey.SharedSettings.SetValue("info.distance.mode", iMode.ToString("D"))
        Call oSurvey.SharedSettings.SetValue("info.distance.filter", pSerializeSelection)
        Call oSurvey.SharedSettings.SetValue("info.distance.splays", If(bSplay, "1", "0"))
    End Sub

    Private Function pGetTrigpointBaseTuple(BaseTuples As Dictionary(Of cSurvey.cSurvey, Windows.Media.Media3D.Point3D), Trigpoint As cTrigPoint) As Windows.Media.Media3D.Point3D
        If BaseTuples Is Nothing Then
            Return New Windows.Media.Media3D.Point3D
        Else
            If BaseTuples.ContainsKey(Trigpoint.Survey) Then
                Return BaseTuples(Trigpoint.Survey)
            Else
                Return New Windows.Media.Media3D.Point3D
            End If
        End If
    End Function
    Private Function pGetTrigpointZ(BaseTuples As Dictionary(Of cSurvey.cSurvey, Windows.Media.Media3D.Point3D), Trigpoint As cTrigPoint) As Decimal
        Dim oBaseTuple As Windows.Media.Media3D.Point3D = pGetTrigpointBaseTuple(BaseTuples, Trigpoint)
        Return Trigpoint.Data.Z + oBaseTuple.Z
    End Function
    Private Function pGetTrigpointY(BaseTuples As Dictionary(Of cSurvey.cSurvey, Windows.Media.Media3D.Point3D), Trigpoint As cTrigPoint) As Decimal
        Dim oBaseTuple As Windows.Media.Media3D.Point3D = pGetTrigpointBaseTuple(BaseTuples, Trigpoint)
        Return Trigpoint.Data.Y + oBaseTuple.Y
    End Function

    Private Function pGetTrigpointX(BaseTuples As Dictionary(Of cSurvey.cSurvey, Windows.Media.Media3D.Point3D), Trigpoint As cTrigPoint) As Decimal
        Dim oBaseTuple As Windows.Media.Media3D.Point3D = pGetTrigpointBaseTuple(BaseTuples, Trigpoint)
        Return Trigpoint.Data.X + oBaseTuple.X
    End Function
    Private Sub pRefreshDistances()
        If Not bEventDisabled Then
            bEventDisabled = True

            iMode = cboDistanceMode.Items.IndexOf(btnDistanceMode.EditValue)

            Call pSettingsSave()

            Dim sMin As Single = Single.MaxValue
            Dim sMax As Single = Single.MinValue
            Dim oMaxX As cTrigPoint = Nothing
            Dim oMaxY As cTrigPoint = Nothing
            Dim oMinX As cTrigPoint = Nothing
            Dim oMinY As cTrigPoint = Nothing

            'If oSelection.Count Then
            '    oTmpTrigPoints = oTrigpointsFromSelection.Where(Function(item) Not item.IsSystem AndAlso If(chkSplays.Checked, True, Not item.Data.IsSplay)).ToList
            'Else
            '    oTmpTrigPoints = oSurvey.TrigPoints.ToList.Where(Function(item) Not item.IsSystem AndAlso If(chkSplays.Checked, True, Not item.Data.IsSplay)).ToList
            'End If
            'Dim oTrigPoints As List(Of cTrigPoint)
            'Filter = Filter.Trim.ToUpper

            'If Filter() = "" Then
            '    oTrigPoints = oTmpTrigPoints
            'Else
            '    Dim oFilter As List(Of String) = New List(Of String)
            '    For Each sFilter As String In Filter.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            '        sFilter = sFilter.Trim.ToUpper
            '        If sFilter <> "" Then
            '            Call oFilter.Add(sFilter)
            '        End If
            '    Next
            '    Dim oNewTrigPoints As List(Of cTrigPoint) = New List(Of cTrigPoint)
            '    For Each oTrigpoint As cTrigPoint In oTmpTrigPoints
            '        Dim sName As String = oTrigpoint.Name
            '        For Each sFilter In oFilter
            '            If (sName Like sFilter) Or (sName = sFilter) Then
            '                oNewTrigPoints.Add(oTrigpoint)
            '                Exit For
            '            End If
            '        Next
            '    Next
            '    oTrigPoints = oNewTrigPoints
            'End If
            Dim bThereAreLinkedSurveys As Boolean = oSelection.Any(Function(oTrigpoint) oTrigpoint.Survey IsNot oSurvey)
            Dim oBaseTuples As Dictionary(Of cSurvey.cSurvey, Windows.Media.Media3D.Point3D) = New Dictionary(Of cSurvey.cSurvey, Windows.Media.Media3D.Point3D)
            If bThereAreLinkedSurveys Then
                Dim oPoint As Calculate.cTrigPointCoordinate = oSurvey.Calculate.TrigPoints(oSurvey.Properties.Origin).Coordinate
                Dim oPointUTM As modUTM.UTM = modUTM.WGS84ToUTM(oPoint)
                For Each oLinkedSurvey As cSurvey.cSurvey In oSelection.Select(Function(oTrigpoint) oTrigpoint.Survey).Distinct
                    Dim oLinkedPoint As Calculate.cTrigPointCoordinate = oLinkedSurvey.Calculate.TrigPoints(oLinkedSurvey.Properties.Origin).Coordinate
                    Dim oLinkedPointUTM As modUTM.UTM = modUTM.WGS84ToUTM(oLinkedPoint)
                    oBaseTuples.Add(oLinkedSurvey, New Windows.Media.Media3D.Point3D(oLinkedPointUTM.East - oPointUTM.East, oLinkedPointUTM.North - oPointUTM.North, oLinkedPoint.Altitude - oPoint.Altitude))
                Next
            End If

            Call pClearDistances()

            If oSelection.Count > 200 Then
                Call cSurvey.UIHelpers.Dialogs.Msgbox(modMain.GetLocalizedString("infodistance.warning1"), MsgBoxStyle.OkOnly, modMain.GetLocalizedString("infodistance.warningtitle"))
            Else
                Select Case iMode
                    Case InfoDistanceTypeEnum.Surface
                        Dim oElevation As Surface.cElevation = oSurvey.Properties.SurfaceProfileElevation
                        If Not oElevation Is Nothing Then
                            Dim oData As List(Of cElevationItem) = New List(Of cElevationItem)

                            GridControl1.BeginUpdate()
                            GridControl1.DataSource = Nothing
                            GridView1.Columns.Clear()
                            If bThereAreLinkedSurveys Then GridView1.AddBoundColumn("surveyfrom", modMain.GetLocalizedString("infodistance.textpart11"), "TrigpointFrom.Survey.Name", 80)
                            GridView1.AddBoundColumn("from", modMain.GetLocalizedString("infodistance.textpart1"), "From", 80)
                            GridView1.AddBoundColumn("station", modMain.GetLocalizedString("infodistance.textpart7"), "Station", 80)
                            GridView1.AddBoundColumn("surface", modMain.GetLocalizedString("infodistance.textpart6"), "Surface", 80)
                            GridView1.AddBoundColumn("tosurface", modMain.GetLocalizedString("infodistance.textpart5"), "ToSurface", 80)

                            Dim iCount As Integer = oSelection.Count
                            Dim iIndex As Integer = 0

                            Dim r As Integer = 0
                            Call oSurvey.RaiseOnProgressEvent("info.calculate", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, modMain.GetLocalizedString("infodistance.textpart8"), 0, cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageCalculate Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage)
                            For Each oTrigPointY As cTrigPoint In oSelection
                                iIndex += 1
                                If (iIndex Mod 20) = 0 Then Call oSurvey.RaiseOnProgressEvent("info.calculate", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("infodistance.textpart8"), iIndex / iCount)

                                Dim sValue As Single = 0
                                Dim sSurface As Single = modNumbers.MathRound(oElevation.GetElevation(oTrigPointY), 0)
                                If oTrigPointY.Survey.Calculate.TrigPoints.Contains(oTrigPointY) Then
                                    Dim sAltitude As Single = oTrigPointY.Survey.Calculate.TrigPoints(oTrigPointY).Coordinate.Altitude
                                    sValue = Math.Round(sSurface - sAltitude, 2)
                                    'sValue = modConversion.ConvertBaseToDefaultDistance(sValue, oSurvey)
                                    If sValue < sMin Then
                                        sMin = sValue
                                        oMinY = oTrigPointY
                                    End If
                                    If sValue > sMax Then
                                        sMax = sValue
                                        oMaxY = oTrigPointY
                                    End If
                                    Dim oItem As cElevationItem = New cElevationItem(oTrigPointY, sSurface, sAltitude, sValue)
                                    Call oData.Add(oItem)
                                Else
                                    'oData(r, 0) = 0
                                    'oData(r, 2) = 0
                                    'With oRow.Cells(0)
                                    '    .Style.Format = ";;N/D"
                                    '    .Value = 0.0F
                                    'End With
                                    'With oRow.Cells(2)
                                    '    .Style.Format = ";;N/D"
                                    '    .Value = 0.0F
                                    'End With
                                End If
                                'oData(r, 1) = sSurface
                                'With oRow.Cells(1)
                                '    .Style.Format = "N0"
                                '    .Value = sSurface
                                'End With
                                r += 1
                            Next
                            Call oSurvey.RaiseOnProgressEvent("info.calculate", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 1)

                            GridControl1.DataSource = oData

                            GridControl1.EndUpdate()
                        End If
                        barView.Visible = False
                        HeatmapControl1.Visible = False
                        GridControl1.Visible = True
                    Case Else
                        GridControl1.BeginUpdate()
                        GridControl1.DataSource = Nothing
                        GridView1.Columns.Clear()
                        If bThereAreLinkedSurveys Then GridView1.AddBoundColumn("surveyfrom", modMain.GetLocalizedString("infodistance.textpart11"), "TrigpointX.Survey.Name", 80)
                        GridView1.AddBoundColumn("from", modMain.GetLocalizedString("infodistance.textpart1"), "X", 80)
                        If bThereAreLinkedSurveys Then GridView1.AddBoundColumn("surveyto", modMain.GetLocalizedString("infodistance.textpart12"), "TrigpointY.Survey.Name", 80)
                        GridView1.AddBoundColumn("to", modMain.GetLocalizedString("infodistance.textpart2"), "Y", 80)
                        GridView1.AddBoundColumn("value", modMain.GetLocalizedString("infodistance.textpart9"), "Value", 80)

                        Dim oDataAdapter As DevExpress.XtraCharts.Heatmap.HeatmapDataSourceAdapter = New DevExpress.XtraCharts.Heatmap.HeatmapDataSourceAdapter
                        oDataAdapter.XArgumentDataMember = "X"
                        oDataAdapter.YArgumentDataMember = "Y"
                        oDataAdapter.ColorDataMember = "Value"
                        Dim oData As List(Of cDistanceItem) = New List(Of cDistanceItem)
                        Dim oKeys As HashSet(Of String) = New HashSet(Of String)

                        Dim iCount As Integer = oSelection.Count ^ 2
                        Dim iIndex As Integer = 0

                        Dim r As Integer = 0
                        Call oSurvey.RaiseOnProgressEvent("info.calculate", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, modMain.GetLocalizedString("infodistance.textpart8"), 0, cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageCalculate Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage)
                        For Each oTrigPointX As cTrigPoint In oSelection
                            Dim c As Integer = 0
                            Dim sValue As Single = 0

                            For Each oTrigPointY As cTrigPoint In oSelection
                                iIndex += 1
                                If (iIndex Mod 20) = 0 Then Call oSurvey.RaiseOnProgressEvent("info.calculate", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("infodistance.textpart8"), iIndex / iCount)

                                Dim sKey1 As String = oTrigPointX.Survey.ID & "\" & oTrigPointX.Name & ">" & oTrigPointY.Survey.ID & "\" & oTrigPointY.Name
                                Dim sKey2 As String = oTrigPointY.Survey.ID & "\" & oTrigPointY.Name & ">" & oTrigPointX.Survey.ID & "\" & oTrigPointX.Name
                                If oKeys.Contains(sKey1) OrElse oKeys.Contains(sKey2) Then
                                Else
                                    Call oKeys.Add(sKey1)
                                    Call oKeys.Add(sKey2)
                                    Select Case iMode
                                        Case InfoDistanceTypeEnum.Planimetric
                                            Dim oPlanPointY As PointD = New PointD(pGetTrigpointX(oBaseTuples, oTrigPointY), pGetTrigpointY(oBaseTuples, oTrigPointY))
                                            Dim oPlanPointX As PointD = New PointD(pGetTrigpointX(oBaseTuples, oTrigPointX), pGetTrigpointY(oBaseTuples, oTrigPointX))
                                            sValue = modPaint.DistancePointToPoint(oPlanPointX, oPlanPointY)
                                        Case InfoDistanceTypeEnum.Drop
                                            sValue = Math.Abs(pGetTrigpointZ(oBaseTuples, oTrigPointX) - pGetTrigpointZ(oBaseTuples, oTrigPointY))
                                        Case InfoDistanceTypeEnum.Real
                                            Dim oPlanPointY As PointD = New PointD(pGetTrigpointX(oBaseTuples, oTrigPointY), pGetTrigpointY(oBaseTuples, oTrigPointY))
                                            Dim oPlanPointX As PointD = New PointD(pGetTrigpointX(oBaseTuples, oTrigPointX), pGetTrigpointY(oBaseTuples, oTrigPointX))
                                            Dim sDistance As Single = modPaint.DistancePointToPoint(oPlanPointX, oPlanPointY)
                                            Dim sDrop As Single = pGetTrigpointZ(oBaseTuples, oTrigPointX) - pGetTrigpointZ(oBaseTuples, oTrigPointY)
                                            sValue = Math.Sqrt(sDistance ^ 2 + sDrop ^ 2)
                                        Case InfoDistanceTypeEnum.X
                                            Dim sX As Single = pGetTrigpointX(oBaseTuples, oTrigPointX) - pGetTrigpointX(oBaseTuples, oTrigPointY)
                                            sValue = sX
                                        Case InfoDistanceTypeEnum.Y
                                            Dim sY As Single = pGetTrigpointY(oBaseTuples, oTrigPointX) - pGetTrigpointY(oBaseTuples, oTrigPointY)
                                            sValue = sY
                                        Case InfoDistanceTypeEnum.Z
                                            Dim sZ As Single = pGetTrigpointZ(oBaseTuples, oTrigPointX) - pGetTrigpointZ(oBaseTuples, oTrigPointY)
                                            sValue = sZ
                                    End Select

                                    sValue = Math.Abs(sValue)
                                    sValue = Math.Round(modConversion.ConvertBaseToDefaultDistance(sValue, oSurvey), 2)

                                    Dim oItem As cDistanceItem = New cDistanceItem(oTrigPointX, oTrigPointY, sValue)
                                    Call oData.Add(oItem)

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
                                End If

                                c += 1
                            Next
                            r += 1
                        Next
                        Call oSurvey.RaiseOnProgressEvent("info.calculate", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 1)

                        GridControl1.DataSource = oData
                        oDataAdapter.DataSource = oData
                        HeatmapControl1.DataAdapter = oDataAdapter

                        Dim palette As Palette = New Palette("Custom") From {System.Drawing.Color.White, System.Drawing.Color.DarkBlue}
                        Dim colorProvider As DevExpress.XtraCharts.Heatmap.HeatmapRangeColorProvider = New DevExpress.XtraCharts.Heatmap.HeatmapRangeColorProvider() With {.Palette = palette, .ApproximateColors = True}
                        colorProvider.RangeStops.Add(New DevExpress.XtraCharts.Heatmap.HeatmapRangeStop(0, DevExpress.XtraCharts.Heatmap.HeatmapRangeStopType.Percentage))
                        colorProvider.RangeStops.Add(New DevExpress.XtraCharts.Heatmap.HeatmapRangeStop(1, DevExpress.XtraCharts.Heatmap.HeatmapRangeStopType.Percentage))
                        HeatmapControl1.ColorProvider = colorProvider

                        GridControl1.EndUpdate()

                        barView.Visible = True
                        Call pView(iView)
                End Select

                'Try
                '    If oMaxX Is Nothing Then
                '        txtMaxDistance.Text = GetLocalizedString("infodistance.textpart3") & " " & oMinY.Name & ": " & Strings.Format(sMin, "0.00") & vbCrLf & GetLocalizedString("infodistance.textpart4") & " " & oMaxY.Name & ": " & Strings.Format(sMax, "0.00")
                '    ElseIf oMaxX Is Nothing AndAlso oMinX Is Nothing Then
                '        txtMaxDistance.Text = ""
                '    ElseIf oMinX Is Nothing Then
                '        txtMaxDistance.Text = GetLocalizedString("infodistance.textpart4") & " " & GetLocalizedString("infodistance.textpart1") & " " & oMaxX.Name & " " & GetLocalizedString("infodistance.textpart2") & " " & oMaxY.Name & ": " & Strings.Format(sMax, "0.00")
                '    Else
                '        txtMaxDistance.Text = GetLocalizedString("infodistance.textpart4") & " " & GetLocalizedString("infodistance.textpart1") & " " & oMaxX.Name & " " & GetLocalizedString("infodistance.textpart2") & " " & oMaxY.Name & ": " & Strings.Format(sMax, "0.00") & vbCrLf &
                '                              GetLocalizedString("infodistance.textpart3") & " " & GetLocalizedString("infodistance.textpart1") & " " & oMinX.Name & " " & GetLocalizedString("infodistance.textpart2") & " " & oMinY.Name & ": " & Strings.Format(sMin, "0.00")
                '    End If
                'Catch
                '    txtMaxDistance.Text = ""
                'End Try
            End If

            bEventDisabled = False
        End If
    End Sub

    Private Sub cboDistanceMode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Call pClearDistances()
    End Sub

    Private Sub txtFilter_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)
        If e.KeyValue = Keys.Enter Then
            Call pRefresh()
        End If
    End Sub

    Private Sub pRefresh()
        Call pRefreshDistances()
    End Sub

    Private Sub mnuSurveyDistancesRefresh_Click(sender As Object, e As EventArgs)
        Call pRefresh()
    End Sub

    'Private Sub mnuSurveyDistancesCopyAll_Click(sender As Object, e As EventArgs) Handles mnuSurveyDistancesCopyAll.Click
    '    Cursor = Cursors.WaitCursor
    '    Call modCaveInfoTools.CopyGridData(grdSurveyDistances.Rows)
    '    Cursor = Cursors.Default
    'End Sub

    'Private Sub mnuSurveyDistancesCopy_Click(sender As Object, e As EventArgs) Handles mnuSurveyDistancesCopy.Click
    '    Cursor = Cursors.WaitCursor
    '    Call modCaveInfoTools.CopyGridData(grdSurveyDistances.SelectedRows)
    '    Cursor = Cursors.Default
    'End Sub

    Private oSelection As List(Of cTrigPoint) = New List(Of cTrigPoint)
    Private bSplay As Boolean

    'Private Function oTrigpointsFromSelection() As List(Of cTrigPoint)
    '    Dim oList As List(Of cTrigPoint) = New List(Of cTrigPoint)
    '    For Each sSelection As String In oSelection
    '        Dim p As Integer = sSelection.IndexOf(cCaveInfoBranches.sBranchSeparator)
    '        Dim sCaveInfo As String
    '        Dim sCaveInfoPath As String
    '        If p < 0 Then
    '            sCaveInfo = sSelection
    '            sCaveInfoPath = ""
    '        Else
    '            sCaveInfo = sSelection.Substring(0, p)
    '            sCaveInfoPath = sSelection.Substring(p + 1)
    '        End If

    '        Call oList.AddRange(oSurvey.Properties.CaveInfos.GetWithEmpty()(sCaveInfo).Branches.GetAllBranchesWithEmpty(True)(sCaveInfoPath).GetSegments.GetTrigpoints.ToList)
    '        'If sCaveInfoPath = "" Then
    '        '    Call oList.AddRange(oSurvey.Properties.CaveInfos(sCaveInfo).GetSegments.GetTrigPoints().ToList)
    '        'Else
    '        '    Call oList.AddRange(oSurvey.Properties.CaveInfos(sCaveInfo).Branches(sCaveInfoPath).GetSegments.GetTrigPoints().ToList)
    '        'End If
    '    Next
    '    Return oList
    'End Function

    'Private Sub mnuSurveyDistancesExport_Click(sender As Object, e As EventArgs) Handles mnuSurveyDistancesExport.Click
    '    Call modExport.GridExportTo(oSurvey, grdSurveyDistances, Text, "", Me)
    'End Sub

    Private Sub toolTipController1_BeforeShow(sender As Object, e As DevExpress.Utils.ToolTipControllerShowEventArgs) Handles toolTipController1.BeforeShow
        Dim cell As HeatmapCell = CType(e.SelectedObject, HeatmapCell)
        Dim superToolTip As SuperToolTip = New SuperToolTip()
        superToolTip.Items.Add(New ToolTipItem() With {.Text = String.Format(modMain.GetLocalizedString("infodistance.textpart1") & ": {0}", cell.XArgument)})
        superToolTip.Items.Add(New ToolTipItem() With {.Text = String.Format(modMain.GetLocalizedString("infodistance.textpart2") & ": {0}", cell.YArgument)})
        superToolTip.Items.Add(New ToolTipItem() With {.Text = String.Format(modMain.GetLocalizedString("infodistance.textpart9") & ": {0}", cell.ColorValue)})
        e.SuperTip = superToolTip
    End Sub

    Private Sub pView(View As Integer)
        iView = View
        Select Case iView
            Case 0
                HeatmapControl1.Visible = True
                GridControl1.Visible = False
            Case 1
                HeatmapControl1.Visible = False
                GridControl1.Visible = True
        End Select
    End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRefresh.ItemClick
        Call pRefresh()
    End Sub

    Private Sub btnViewGrid_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnViewGrid.CheckedChanged
        Call pView(1)
    End Sub

    Private Sub btnViewHeatmap_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnViewHeatmap.CheckedChanged
        Call pView(0)
    End Sub

    Private Sub btnFilter_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnFilter.ItemClick
        Using frmDF As frmDistancesFilter = New frmDistancesFilter(oSurvey, oSelection, bSplay)
            If frmDF.ShowDialog(Me) = DialogResult.OK Then
                oSelection = frmDF.Trigpoints
                bSplay = frmDF.Splay
                Call pSettingsSave()
            End If
        End Using
    End Sub
End Class
