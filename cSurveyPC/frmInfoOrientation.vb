Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design

Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class frmInfoOrientation
    Private oSurvey As cSurvey.cSurvey

    Friend Sub New(ByVal Survey As cSurvey.cSurvey, Optional ByVal Cave As String = "")
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        Call pRefreshCaveList(Cave)
        Call pRefreshNordInfo()
    End Sub

    Private Sub pDrawCompass(TrueNord As Boolean, Year As Integer)
        Dim oImage As Image = New Bitmap(picNord.Width, picNord.Height)
        Dim oGr As Graphics = Graphics.FromImage(oImage)
        oGr.SmoothingMode = SmoothingMode.AntiAlias
        oGr.CompositingQuality = CompositingQuality.HighQuality
        oGr.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim oPath As GraphicsPath = New GraphicsPath

        Dim iX As Integer = picNord.Width / 2
        Dim iY As Integer = picNord.Height - picNord.Height / 3

        Dim iBorder As Integer = 4
        Dim iRadius As Integer = picNord.Height * 30 / 100
        Dim iRadiusFactor As Integer = 5
        Dim iSize As Integer = iRadius * 2
        Dim oArrowPen As Pen = New Pen(Color.Black, -1)
        Dim oArrowBrush As Brush = New SolidBrush(Color.Black)
        Dim iPosX As Integer = iX + iRadiusFactor + iBorder
        Dim iPosY As Integer = iY
        Dim oPoints(3) As PointF
        oPoints(0) = New Point(iPosX, iPosY - iRadius)
        oPoints(1) = New Point(iPosX - iRadius / iRadiusFactor, iPosY + iRadius / iRadiusFactor)
        oPoints(2) = New Point(iPosX, iPosY)
        oPoints(3) = New Point(iPosX + iRadius / iRadiusFactor, iPosY + iRadius / iRadiusFactor)
        Call oGr.FillPolygon(oArrowBrush, oPoints)
        Call oGr.DrawPolygon(oArrowPen, oPoints)

        Dim oSF As StringFormat = New StringFormat
        oSF.Alignment = StringAlignment.Center
        oSF.LineAlignment = StringAlignment.Center
        Dim sNord As String
        If TrueNord Then
            sNord = "N"
        Else
            sNord = "Nm " & Year
        End If
        Call oGr.DrawString(sNord, New Font("Arial", 18, FontStyle.Bold), oArrowBrush, New RectangleF(iPosX - iRadius, iPosY - iRadius - 16, iRadius * 2, 16), oSF)

        picNord.Image = oImage
    End Sub

    Private Sub pRefreshNordInfo()
        Call grdNordInfo.Rows.Clear()
        Dim bTrueNord As Boolean = oSurvey.Properties.GPS.Enabled Or (oSurvey.Properties.NordCorrectionMode = cSurvey.cSurvey.NordCorrectionModeEnum.DeclinationBySession)
        If bTrueNord Then
            Call grdNordInfo.Rows.Add(GetLocalizedString("infoorientation.textpart1"), GetLocalizedString("infoorientation.textpart2"))
        Else
            Call grdNordInfo.Rows.Add(GetLocalizedString("infoorientation.textpart1"), GetLocalizedString("infoorientation.textpart3"))
        End If
        Call grdNordInfo.Rows.Add(GetLocalizedString("infoorientation.textpart4"), Strings.Format(oSurvey.Calculate.GeoMagDeclinationData.MeridianConvergence, "0.000") & "°")

        Dim oSurveyYears As List(Of Integer) = oSurvey.Properties.Sessions.GetSurveyYears
        Call grdDecMagValues.Rows.Clear()
        With oSurvey.Calculate.GeoMagDeclinationData
            For Each oDate As Date In .GetDates
                Dim iRowIndex As Integer = grdDecMagValues.Rows.Add(Strings.Format(oDate, "dd/MM/yyyy"), Strings.Format(.Item(oDate), "0.000") & "°")
                If oSurveyYears.Contains(oDate.Year) Then
                    grdDecMagValues.Rows(iRowIndex).DefaultCellStyle.BackColor = Color.LightGreen
                End If
            Next
        End With

        Dim iYear As Integer
        Try
            iYear = oSurveyYears.Last
        Catch ex As Exception
            iYear = Today.Year
        End Try
        Call pDrawCompass(bTrueNord, iYear)
    End Sub

    Private Sub cboSurveyInfoCave_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSurveyInfoCave.SelectedIndexChanged
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
        Dim iStep As Integer = 10

        Dim sCurrentCave As String = cboSurveyInfoCave.Text
        Dim bShowDistinct As Boolean = chkShowCaveDistinct.Checked
        If sCurrentCave = "" And bShowDistinct Then
            Try
                Call chrtBearings.Series.Clear()
                Call chrtBearings.Legends.Clear()
                Dim oLegend As DataVisualization.Charting.Legend = chrtBearings.Legends.Add(GetLocalizedString("infoorientation.textpart6"))
                oLegend.Docking = DataVisualization.Charting.Docking.Bottom
                oLegend.Font = Font

                For Each oCaveInfo As cCaveInfo In oSurvey.Properties.CaveInfos.GetWithEmpty.Values
                    Dim sSerieName As String = oCaveInfo.Name
                    If sSerieName = "" Then sSerieName = GetLocalizedString("infoorientation.textpart5")
                    Dim oSerie As DataVisualization.Charting.Series = chrtBearings.Series.Add(sSerieName)
                    oSerie.ChartType = DataVisualization.Charting.SeriesChartType.Polar
                    oSerie.Font = Font
                    oSerie.BorderWidth = 2
                    Dim oAngles As SortedList = New SortedList
                    For Each oSegment As cSegment In oSurvey.Segments.GetSurveySegments.GetCaveSegments(oCaveInfo)
                        If oSegment.IsValid And Not oSegment.IsSelfDefined Then
                            Dim iAngle As Integer = (modPaint.NormalizeAngle(oSegment.Bearing) / iStep) * iStep
                            If oAngles.Contains(iAngle) Then
                                Dim iDistance As Integer = oAngles(iAngle)
                                Call oAngles.Remove(iAngle)
                                Call oAngles.Add(iAngle, oSegment.Distance + iDistance)
                            Else
                                Call oAngles.Add(iAngle, oSegment.Distance)
                            End If
                        End If
                    Next

                    For iAngle = 0 To 359 Step iStep
                        Dim iValue As Integer = 0
                        If oAngles.Contains(iAngle) Then
                            iValue = oAngles(iAngle)
                        Else
                            iValue = 0
                        End If
                        For iSubAngle = iAngle To iAngle + iStep - 1
                            Call oSerie.Points.AddXY(iSubAngle, iValue)
                        Next
                    Next
                Next
            Catch ex As Exception
            End Try
        Else
            Try
                Call chrtBearings.Series.Clear()
                Call chrtBearings.Legends.Clear()
                Dim oLegend As DataVisualization.Charting.Legend = chrtBearings.Legends.Add(GetLocalizedString("infoorientation.textpart6"))
                oLegend.Docking = DataVisualization.Charting.Docking.Bottom
                oLegend.Font = Font

                Dim sSerieName As String = sCurrentCave
                If sSerieName = "" Then sSerieName = GetLocalizedString("infoorientation.textpart7")

                Dim oSerie As DataVisualization.Charting.Series = chrtBearings.Series.Add(sSerieName)
                oSerie.ChartType = DataVisualization.Charting.SeriesChartType.Polar
                oSerie.Font = Font
                oSerie.BorderWidth = 2
                Dim oAngles As SortedList = New SortedList
                Dim oSegments As cISegmentCollection
                If sCurrentCave = "" Then
                    oSegments = oSurvey.Segments.GetSurveySegments
                Else
                    oSegments = oSurvey.Segments.GetSurveySegments.GetCaveSegments(sCurrentCave)
                End If
                For Each oSegment As cSegment In oSegments
                    If oSegment.IsValid And Not oSegment.IsSelfDefined Then
                        Dim iAngle As Integer = (modPaint.NormalizeAngle(oSegment.Bearing) / iStep) * iStep
                        If oAngles.Contains(iAngle) Then
                            Dim iDistance As Integer = oAngles(iAngle)
                            Call oAngles.Remove(iAngle)
                            Call oAngles.Add(iAngle, oSegment.Distance + iDistance)
                        Else
                            Call oAngles.Add(iAngle, oSegment.Distance)
                        End If
                    End If
                Next

                For iAngle = 0 To 359 Step iStep
                    Dim iValue As Integer = 0
                    If oAngles.Contains(iAngle) Then
                        iValue = oAngles(iAngle)
                    Else
                        iValue = 0
                    End If
                    For iSubAngle = iAngle To iAngle + iStep - 1
                        Call oSerie.Points.AddXY(iSubAngle, iValue)
                    Next
                Next
            Catch ex As Exception
            End Try

        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Call Close()
    End Sub

    Private Sub chkShowCaveDistinct_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowCaveDistinct.CheckedChanged
        Call pRefreshInfo()
    End Sub

    Private Sub frmInfoOrientation_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Call pRefreshNordInfo()
        End If
    End Sub
End Class