Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports cSurveyPC.cResurvey

Public Class frmResurveyMain
    Private oOpenHandCursor As Cursor
    Private oClosedHandCursor As Cursor

    Private iBaseMinDistance As Integer = 16

    Private oOptions As cResurvey.cOptions

    Private oLastMousePoint As Point
    Private oLastPlaceHolder As cResurvey.cTrigpointPlaceholder
    Private oLastLine As cResurvey.cTrigpointPlaceholder()

    Private sPlanImage As String
    Private sProfileImage As String

    Private sFilename As String = ""

    Private sPrevStation As String

    Private oShots As cResurvey.cShots
    Private oStations As Dictionary(Of String, cResurvey.cStation)

    Private oPlanStationPath As GraphicsPath
    Private oPlanShotsPath As GraphicsPath

    Private oProfileStationPath As GraphicsPath
    Private oProfileShotsPath As GraphicsPath

    Private oPlanScalePath As GraphicsPath
    Private oProfileScalePath As GraphicsPath
    Private oProfileDropScalePath As GraphicsPath

    Private oPlanScaleRealPath As GraphicsPath
    Private oProfileScaleRealPath As GraphicsPath
    Private oProfileDropScaleRealPath As GraphicsPath

    Private oPaintThread As Threading.Thread

    Private oPlanTrigpointsPlaceholders As Dictionary(Of String, cResurvey.cTrigpointPlaceholder)
    Private oProfileTrigpointsPlaceholders As Dictionary(Of String, cResurvey.cTrigpointPlaceholder)

    Private oScaleColor As Color = Color.Orange
    Private oDropScaleColor As Color = Color.OrangeRed
    Private oGenericColor As Color = Color.Red
    Private oOriginColor As Color = Color.Blue

    Private oRulesColor As Color = Color.FromArgb(120, Color.Gray)
    Private oRulesPen As Pen
    Private oRulesSecondaryPen
    Private oRulesLabelPen As Pen
    Private oRulesLabelBrush As SolidBrush
    Private oRulesBrush As SolidBrush
    Private oRulesFillBrush As SolidBrush

    Private iDefaultCalculateMode As cResurvey.cOptions.CalculateModeEnum

    Private sPlanZoom As Single = 1
    Private sProfileZoom As Single = 1

    Private WithEvents oPlanVSB As VScrollBar
    Private WithEvents oPlanHSB As HScrollBar

    Private WithEvents oProfileVSB As VScrollBar
    Private WithEvents oProfileHSB As HScrollBar

    Private Function pPointFromString(Text As String) As Point
        Try
            If Text = "" Then
                Return Point.Empty
            Else
                Dim oData() As Object = Text.Split(";")
                Return New Point(oData(0), oData(1))
            End If
        Catch
            Return Point.Empty
        End Try
    End Function

    Private Function pPointToString(Point As Point) As String
        If Point.IsEmpty Then
            Return ""
        Else
            Return Point.X & ";" & Point.Y
        End If
    End Function

    Private Function pImageLoad(BasePath As String, Filename As String) As Image
        Dim oFl As FileInfo = New FileInfo(Filename)
        If oFl.Exists Then
            Return modPaint.ImageExifRotate(New Bitmap(Filename))
        Else
            Dim sFilename As String = Path.Combine(BasePath, Path.GetFileName(Filename))
            oFl = New FileInfo(sFilename)
            If oFl.Exists Then
                Return modPaint.ImageExifRotate(New Bitmap(sFilename))
            Else
                Return Nothing
            End If
        End If
    End Function

    Private Sub pLoad(Filename As String)
        If Filename = "" Then
            Dim oOFD As OpenFileDialog = New OpenFileDialog
            With oOFD
                .Filter = GetLocalizedString("resurvey.filetypeCRSX") & " (*.CRSX)|*.CRSX"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Filename = .FileName
                End If
            End With
        End If

        If Filename <> "" Then
            Cursor = Cursors.WaitCursor

            sFilename = Filename

            Dim oXML As XmlDocument = New XmlDocument
            Call oXML.Load(sFilename)
            Dim oXMLRoot As XmlElement = oXML.Item("cresurvey")

            oOptions.CalculateMode = modXML.GetAttributeValue(oXMLRoot, "calculatemode", cResurvey.cOptions.CalculateModeEnum.Full)
            oOptions.NordCorrection = modNumbers.StringToSingle(modXML.GetAttributeValue(oXMLRoot, "nordcorrection", 0))
            oOptions.SkipInvalidStation = modXML.GetAttributeValue(oXMLRoot, "skipinvalidstation", True)
            oOptions.UseDropForInclination = modXML.GetAttributeValue(oXMLRoot, "usedropforinclination", False)
            oOptions.PlanScaleType = modXML.GetAttributeValue(oXMLRoot, "planscaletype", cResurvey.cOptions.ScaleTypeEnum.Distance)
            oOptions.DropScaleType = modXML.GetAttributeValue(oXMLRoot, "dropscaletype", cResurvey.cOptions.ScaleTypeEnum.DeltaY)

            oOptions.CalculateLRUD = modXML.GetAttributeValue(oXMLRoot, "calculatelrud", 0)
            oOptions.LRUDBorderWidth = modXML.GetAttributeValue(oXMLRoot, "lrudborderwidth", 3)
            oOptions.LRMaxValue = modNumbers.StringToSingle(modXML.GetAttributeValue(oXMLRoot, "lrmaxvalue", 5))
            oOptions.UDMaxValue = modNumbers.StringToSingle(modXML.GetAttributeValue(oXMLRoot, "udmaxvalue", 10))

            Call pSetCalculateMode()

            Text = "cResurvey - " & sFilename

            Dim sBasepath As String = Path.GetDirectoryName(sFilename)

            sPlanZoom = 1
            sPlanImage = oXMLRoot.GetAttribute("planimage")
            If sPlanImage <> "" Then
                Try
                    Dim oPlanImage As Image = pImageLoad(sBasepath, sPlanImage)
                    picPlan.Image = oPlanImage
                    If Not oPlanImage Is Nothing Then
                        picPlan.Size = oPlanImage.Size
                        picPlan.Visible = True
                    End If
                Catch ex As Exception
                End Try
            End If

            sProfileZoom = 1
            sProfileImage = oXMLRoot.GetAttribute("profileimage")
            If sProfileImage <> "" Then
                Try
                    Dim oprofileImage As Image = pImageLoad(sBasepath, sProfileImage)
                    picProfile.Image = oprofileImage
                    If Not oprofileImage Is Nothing Then
                        picProfile.Size = oprofileImage.Size
                        picProfile.Visible = True
                    End If
                Catch ex As Exception
                End Try
            End If
            Call pBindScrollbars()

            Call oShots.Clear()
            Call grdPlot.Rows.Clear()

            Call oPlanTrigpointsPlaceholders.Clear()
            Call oProfileTrigpointsPlaceholders.Clear()

            Call oStations.Clear()
            Call grdStations.Rows.Clear()
            Dim oXMLStations As XmlElement = oXMLRoot.Item("stations")
            For Each oXMLStation As XmlElement In oXMLStations.ChildNodes
                Dim oStation As cResurvey.cStation = New cResurvey.cStation
                oStation.Name = oXMLStation.GetAttribute("name")
                oStation.PlanPoint = pPointFromString(modXML.GetAttributeValue(oXMLStation, "planpoint", ""))
                oStation.ProfilePoint = pPointFromString(modXML.GetAttributeValue(oXMLStation, "profilepoint"))
                oStation.Type = modXML.GetAttributeValue(oXMLStation, "type", "")
                If oXMLStation.HasAttribute("nextname") Then
                    Dim sNextName As String = modXML.GetAttributeValue(oXMLStation, "nextname")
                    If oStation.Type = "SE" OrElse oStation.Type = "DSE" Then
                        oStation.Scale = modNumbers.StringToSingle(sNextName)
                    Else
                        oStation.PlanConnectedTo = sNextName
                        oStation.ProfileConnectedTo = sNextName
                    End If
                Else
                    oStation.PlanConnectedTo = modXML.GetAttributeValue(oXMLStation, "planconnectedto", "")
                    oStation.ProfileConnectedTo = modXML.GetAttributeValue(oXMLStation, "profileconnectedto", "")
                    If oStation.Type = "SE" OrElse oStation.Type = "DSE" Then
                        oStation.Scale = modNumbers.StringToSingle(modXML.GetAttributeValue(oXMLStation, "scale", 1))
                    End If
                End If
                Call oStations.Add(oStation.Name, oStation)
            Next

            For Each oStation As cResurvey.cStation In oStations.Values
                Dim oConnectionsToDelete As List(Of String) = New List(Of String)

                Call oConnectionsToDelete.Clear()
                Dim oConnectedTo As List(Of String) = cResurvey.cStation.GetConnectedToCollection(oStation.PlanConnectedTo)
                For Each sConnectedTo As String In oConnectedTo
                    If Not pPointAsData(sConnectedTo, 0) Then
                        Call oConnectionsToDelete.Add(sConnectedTo)
                    End If
                Next
                For Each sConnectedTo As String In oConnectionsToDelete
                    Call oConnectedTo.Remove(sConnectedTo)
                Next
                oStation.PlanConnectedTo = cResurvey.cStation.SetConnectedToFromCollection(oConnectedTo)

                Call oConnectionsToDelete.Clear()
                oConnectedTo = cResurvey.cStation.GetConnectedToCollection(oStation.ProfileConnectedTo)
                For Each sConnectedTo As String In oConnectedTo
                    If Not pPointAsData(sConnectedTo, 1) Then
                        Call oConnectionsToDelete.Add(sConnectedTo)
                    End If
                Next
                For Each sConnectedTo As String In oConnectionsToDelete
                    Call oConnectedTo.Remove(sConnectedTo)
                Next
                oStation.ProfileConnectedTo = cResurvey.cStation.SetConnectedToFromCollection(oConnectedTo)
            Next

            For Each oStation As cResurvey.cStation In oStations.Values
                Dim oValues(6) As Object
                oValues(1) = oStation.Name
                oValues(2) = pPointToString(oStation.PlanPoint)
                oValues(3) = pPointToString(oStation.ProfilePoint)
                oValues(4) = oStation.PlanConnectedTo
                oValues(5) = oStation.ProfileConnectedTo
                oValues(6) = oStation.Type
                Dim iNewRow As Integer = grdStations.Rows.Add(oValues)
                Dim oRow As DataGridViewRow = grdStations.Rows(iNewRow)
                Select Case oStation.Type
                    Case "O"
                        oRow.Cells(0).Style.BackColor = oOriginColor
                    Case "SB", "SE"
                        oRow.Cells(0).Style.BackColor = oScaleColor
                    Case "DSB", "DSE"
                        oRow.Cells(0).Style.BackColor = oDropScaleColor
                End Select
                oStation.Row = oRow

                If Not oStation.PlanPoint.IsEmpty Then
                    oStation.PlanPlaceholder = pAddPoint(0, oRow, oStation.PlanPoint)
                End If
                If Not oStation.ProfilePoint.IsEmpty Then
                    oStation.ProfilePlaceholder = pAddPoint(1, oRow, oStation.ProfilePoint)
                End If
            Next

            Call pPerformCalculate(False)

            Cursor = Cursors.Default

            Call grdStations_SelectionChanged(Nothing, Nothing)

            Call pPerformPaint()
        End If
    End Sub

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
        Call pLoad("")
    End Sub

    Private Function pAddPoint(PlanOrProfile As Integer, Row As DataGridViewRow, ByVal Location As Point) As cResurvey.cTrigpointPlaceholder
        Dim sStation As String = Row.Cells(1).Value
        Dim sType As String = Row.Cells(6).Value
        Dim oPicture As PictureBox
        If PlanOrProfile = 0 Then
            oPicture = picPlan
        Else
            oPicture = picProfile
        End If
        Dim oGraphics As Graphics = oPicture.CreateGraphics
        Dim oNameSize As SizeF = oGraphics.MeasureString(sStation, Font)
        Dim oTPH As cResurvey.cTrigpointPlaceholder = New cResurvey.cTrigpointPlaceholder(PlanOrProfile, sStation, Location, oNameSize.Width)
        If sType <> "" Then
            Select Case sType
                Case "O"
                    'origin
                    oTPH.BackColor = oOriginColor
                Case "SB", "SE", "DSB", "DSE"
                    'scale point
                    oTPH.BackColor = oScaleColor
                Case "DSB", "DSE"
                    'drop scale point
                    oTPH.BackColor = oDropScaleColor
                Case Else
                    oTPH.BackColor = oGenericColor
            End Select
        Else
            oTPH.BackColor = oGenericColor
        End If
        Select Case PlanOrProfile
            Case 0
                If oPlanTrigpointsPlaceholders.ContainsKey(sStation) Then
                    Call oPlanTrigpointsPlaceholders.Remove(sStation)
                End If
                Call oPlanTrigpointsPlaceholders.Add(sStation, oTPH)
            Case 1
                If oProfileTrigpointsPlaceholders.ContainsKey(sStation) Then
                    Call oProfileTrigpointsPlaceholders.Remove(sStation)
                End If
                Call oProfileTrigpointsPlaceholders.Add(sStation, oTPH)
        End Select
        Return oTPH
    End Function

    Private Sub picPlan_Click(sender As Object, e As EventArgs) Handles picPlan.Click
        Call picPlan.Focus()
    End Sub

    Private Sub picProfile_Click(sender As Object, e As EventArgs) Handles picProfile.Click
        Call picProfile.Focus()
    End Sub

    Private Sub pic_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles picPlan.DoubleClick, picProfile.DoubleClick
        Call pAddStation()
    End Sub

    Private oDragboxFromMouseDown As Rectangle
    Private oDragScreenOffset As Point

    Private Sub picPlan_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picPlan.MouseDown
        Call picPlan.Focus()

        If My.Computer.Keyboard.CtrlKeyDown Or (e.Button And Windows.Forms.MouseButtons.Middle) = Windows.Forms.MouseButtons.Middle Then
            If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Or (e.Button And Windows.Forms.MouseButtons.Middle) = Windows.Forms.MouseButtons.Middle Then
                picPlan.Cursor = oClosedHandCursor
                oDragScreenOffset = e.Location
            Else
                picPlan.Cursor = oOpenHandCursor
            End If
        Else
            picPlan.Cursor = Cursors.Cross

            Dim oPoint As Point = New Point(e.Location.X / sPlanZoom, e.Location.Y / sPlanZoom)
            pnlCoordinates.Text = "X: " & oPoint.X & " px; Y: " & oPoint.Y & " px"

            oLastMousePoint = oPoint
            Try
                Dim oTPH As cResurvey.cTrigpointPlaceholder = pHitTestPlanPlaceholder(oLastMousePoint)
                Dim oLine As cResurvey.cTrigpointPlaceholder()
                If oTPH Is Nothing Then
                    oDragboxFromMouseDown = Rectangle.Empty
                    oLine = pHitTestPlanLine(oPoint)
                Else
                    Dim oDragSize As Size = SystemInformation.DragSize
                    oDragboxFromMouseDown = New Rectangle(New Point(oPoint.X - (oDragSize.Width / 2) / sPlanZoom, oPoint.Y - (oDragSize.Height / 2) / sPlanZoom), oDragSize)
                End If

                If Not oLastPlaceHolder Is oTPH Or Not oLastLine Is oLine Then
                    oLastPlaceHolder = oTPH
                    Call pStationSelectRow()

                    oLastLine = oLine
                    Call pInvalidateCurrentView()
                End If
            Catch
            End Try
        End If
    End Sub

    Private Sub picProfile_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picProfile.MouseDown
        Call picProfile.Focus()

        If My.Computer.Keyboard.CtrlKeyDown Or (e.Button And Windows.Forms.MouseButtons.Middle) = Windows.Forms.MouseButtons.Middle Then
            If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Or (e.Button And Windows.Forms.MouseButtons.Middle) = Windows.Forms.MouseButtons.Middle Then
                picProfile.Cursor = oClosedHandCursor
                oDragScreenOffset = e.Location
            Else
                picProfile.Cursor = oOpenHandCursor
            End If
        Else
            picPlan.Cursor = Cursors.Cross

            Dim oPoint As Point = New Point(e.Location.X / sProfileZoom, e.Location.Y / sProfileZoom)
            pnlCoordinates.Text = "X: " & oPoint.X & " px; Y: " & oPoint.Y & " px"

            oLastMousePoint = oPoint
            Try
                Dim oTPH As cResurvey.cTrigpointPlaceholder = pHitTestProfilePlaceholder(oLastMousePoint)
                Dim oLine As cResurvey.cTrigpointPlaceholder()
                If oTPH Is Nothing Then
                    oDragboxFromMouseDown = Rectangle.Empty
                    oLine = pHitTestProfileLine(oPoint)
                Else
                    Dim oDragSize As Size = SystemInformation.DragSize
                    oDragboxFromMouseDown = New Rectangle(New Point(oPoint.X - (oDragSize.Width / 2) / sProfileZoom, oPoint.Y - (oDragSize.Height / 2) / sProfileZoom), oDragSize)
                End If

                If Not oLastPlaceHolder Is oTPH Or Not oLastLine Is oLine Then
                    oLastPlaceHolder = oTPH
                    Call pStationSelectRow()

                    oLastLine = oLine

                    Call pInvalidateCurrentView()
                End If
            Catch
            End Try
        End If
    End Sub

    Private Sub pStationSelectRow()
        If Not oLastPlaceHolder Is Nothing Then
            Dim oRow As DataGridViewRow = oStations(oLastPlaceHolder.Name).Row
            If Not grdStations.CurrentRow Is oRow Then
                grdStations.CurrentCell = oRow.Cells(0)
                grdStations.FirstDisplayedCell = oRow.Cells(0)
            End If
        End If
    End Sub

    Private Function pContainsType(Type As String) As Boolean
        For Each oStation As cResurvey.cStation In oStations.Values
            If oStation.Type = Type Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function pContainsOrigin() As Boolean
        Return pContainsType("O")
    End Function

    Private Function pContainsFirstDropScale() As Boolean
        Return pContainsType("DSB")
    End Function

    Private Function pContainsSecondDropScale() As Boolean
        Return pContainsType("DSE")
    End Function

    Private Function pContainsFirstScale() As Boolean
        Return pContainsType("SB")
    End Function

    Private Function pContainsSecondScale() As Boolean
        Return pContainsType("SE")
    End Function

    Private Sub pAddStation()
        Dim iPlanOrProfile As Integer = pGetCurrentProjection()

        Dim oRow As DataGridViewRow
        Try
            oRow = grdStations.Rows(grdStations.SelectedRows(0).Index)
        Catch
        End Try

        Dim oNewRow As DataGridViewRow
        Dim sPrevType As String = ""
        If Not oRow Is Nothing Then
            If oRow.IsNewRow Then
                sPrevStation = ""
                sPrevType = ""
            Else
                sPrevStation = "" & oRow.Cells(1).Value
                sPrevType = "" & oRow.Cells(6).Value
                If sPrevType = "SB" Or sPrevType = "SE" Or sPrevType = "DSB" Or sPrevType = "DSE" Then sPrevStation = ""
            End If
        Else
            sPrevStation = ""
            sPrevType = ""
        End If
        Dim frmRAS As frmResurveyAddStation = New frmResurveyAddStation(iPlanOrProfile, oStations, sPrevStation, oLastMousePoint)
        With frmRAS
            If iPlanOrProfile = 0 Then
                Select Case oOptions.CalculateMode
                    Case cResurvey.cOptions.CalculateModeEnum.Full
                        If oOptions.UseDropForInclination Then
                            .optFirstScale.Enabled = Not pContainsFirstScale()
                            .optSecondScale.Enabled = Not pContainsSecondScale()
                        Else
                            .optFirstScale.Enabled = False
                            .optSecondScale.Enabled = False
                        End If
                    Case cResurvey.cOptions.CalculateModeEnum.OnlyPlan
                        .optFirstScale.Enabled = Not pContainsFirstScale()
                        .optSecondScale.Enabled = Not pContainsSecondScale()
                End Select
            Else
                If oOptions.UseDropForInclination Then
                    .optFirstScale.Enabled = Not pContainsFirstDropScale()
                    .optSecondScale.Enabled = Not pContainsSecondDropScale()
                Else
                    .optFirstScale.Enabled = Not pContainsFirstScale()
                    .optSecondScale.Enabled = Not pContainsSecondScale()
                End If
            End If
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim sStation As String = ""
                Dim sType As String = ""
                Dim iScaleLen As Integer

                If .optNewStation.Checked Then
                    sStation = .cboNewStation.Text
                    sType = ""
                End If

                If .optMovedStation.Checked Then
                    sStation = .cboMovedStation.Text
                    Do While oStations.ContainsKey(sStation)
                        sStation &= ">"
                    Loop
                    sPrevStation = pGetRealStation(sStation)
                    If oStations.ContainsKey(sPrevStation) Then sPrevType = oStations(sPrevStation).Type
                    sType = ""
                End If

                If oOptions.UseDropForInclination Then
                    If iPlanOrProfile = 1 Then
                        If .optFirstScale.Checked Then
                            sStation = "_DS1"
                            sType = "DSB"
                        End If
                        If .optSecondScale.Checked Then
                            sStation = "_DS2"
                            sType = "DSE"
                            iScaleLen = .txtScaleSize.Value
                        End If
                    Else
                        If .optFirstScale.Checked Then
                            sStation = "_S1"
                            sType = "SB"
                        End If
                        If .optSecondScale.Checked Then
                            sStation = "_S2"
                            sType = "SE"
                            iScaleLen = .txtScaleSize.Value
                        End If
                    End If
                Else
                    If .optFirstScale.Checked Then
                        sStation = "_S1"
                        sType = "SB"
                    End If
                    If .optSecondScale.Checked Then
                        sStation = "_S2"
                        sType = "SE"
                        iScaleLen = .txtScaleSize.Value
                    End If
                End If

                If oStations.ContainsKey(sStation) Then
                    oNewRow = oStations(sStation).Row
                    Dim oStation As cResurvey.cStation = oStations(sStation)
                    If iPlanOrProfile = 0 Then
                        oNewRow.Cells(2).Value = pPointToString(oLastMousePoint)
                        oStation.PlanPoint = oLastMousePoint
                    Else
                        oNewRow.Cells(3).Value = pPointToString(oLastMousePoint)
                        oStation.ProfilePoint = oLastMousePoint
                    End If

                    If iPlanOrProfile = 0 Then
                        oStation.PlanPlaceholder = pAddPoint(iPlanOrProfile, oNewRow, oLastMousePoint)

                        If sPrevStation <> "" And (sPrevType = "" Or sPrevType = "O") And (sType <> "SB" And sType <> "SE") And (sType <> "DSB" And sType <> "DSE") Then
                            Dim oPrevStation As cResurvey.cStation = oStations(sPrevStation)
                            Dim oPathStations As List(Of String) = cResurvey.cStation.GetConnectedToCollection(oPrevStation.PlanConnectedTo)
                            If Not oPathStations.Contains(sStation) Then
                                Call oPathStations.Add(sStation)
                            End If
                            oPrevStation.PlanConnectedTo = cResurvey.cStation.SetConnectedToFromCollection(oPathStations)
                            oPrevStation.Row.Cells(4).Value = oPrevStation.PlanConnectedTo
                        End If
                    Else
                        oStation.ProfilePlaceholder = pAddPoint(iPlanOrProfile, oNewRow, oLastMousePoint)

                        If sPrevStation <> "" And (sPrevType = "" Or sPrevType = "O") And (sType <> "SB" And sType <> "SE") And (sType <> "DSB" And sType <> "DSE") Then
                            Dim oPrevStation As cResurvey.cStation = oStations(sPrevStation)
                            Dim oPathStations As List(Of String) = cResurvey.cStation.GetConnectedToCollection(oPrevStation.ProfileConnectedTo)
                            If Not oPathStations.Contains(sStation) Then
                                Call oPathStations.Add(sStation)
                            End If
                            oPrevStation.ProfileConnectedTo = cResurvey.cStation.SetConnectedToFromCollection(oPathStations)
                            oPrevStation.Row.Cells(5).Value = oPrevStation.ProfileConnectedTo
                        End If
                    End If
                Else
                    If iPlanOrProfile = 0 Then
                        If sPrevStation <> "" And (sPrevType = "" Or sPrevType = "O") And (sType <> "SB" And sType <> "SE") And (sType <> "DSB" And sType <> "DSE") Then
                            Dim oPrevStation As cResurvey.cStation = oStations(sPrevStation)
                            Dim oPathStations As List(Of String) = cResurvey.cStation.GetConnectedToCollection(oPrevStation.PlanConnectedTo)
                            If Not oPathStations.Contains(sStation) Then
                                Call oPathStations.Add(sStation)
                            End If
                            oPrevStation.PlanConnectedTo = cResurvey.cStation.SetConnectedToFromCollection(oPathStations)
                            oPrevStation.Row.Cells(4).Value = oPrevStation.PlanConnectedTo
                        End If
                    Else
                        If sPrevStation <> "" And (sPrevType = "" Or sPrevType = "O") And (sType <> "SB" And sType <> "SE") And (sType <> "DSB" And sType <> "DSE") Then
                            Dim oPrevStation As cResurvey.cStation = oStations(sPrevStation)
                            Dim oPathStations As List(Of String) = cResurvey.cStation.GetConnectedToCollection(oPrevStation.ProfileConnectedTo)
                            If Not oPathStations.Contains(sStation) Then
                                Call oPathStations.Add(sStation)
                            End If
                            oPrevStation.ProfileConnectedTo = cResurvey.cStation.SetConnectedToFromCollection(oPathStations)
                            oPrevStation.Row.Cells(5).Value = oPrevStation.ProfileConnectedTo
                        End If
                    End If

                    oNewRow = grdStations.Rows(grdStations.Rows.Add())

                    Dim oStation As cResurvey.cStation = New cResurvey.cStation
                    oStation.Name = sStation
                    oNewRow.Cells(1).Value = sStation
                    If iPlanOrProfile = 0 Then
                        oNewRow.Cells(2).Value = pPointToString(oLastMousePoint)
                        oStation.PlanPoint = oLastMousePoint
                    Else
                        oNewRow.Cells(3).Value = pPointToString(oLastMousePoint)
                        oStation.ProfilePoint = oLastMousePoint
                    End If

                    If sType = "SE" Or sType = "DSE" Then
                        oStation.Scale = iScaleLen
                    End If
                    oNewRow.Cells(4).Value = oStation.PlanConnectedTo
                    oNewRow.Cells(5).Value = oStation.ProfileConnectedTo

                    oStation.Type = sType
                    oNewRow.Cells(6).Value = sType
                    oStation.Row = oNewRow

                    Call oStations.Add(sStation, oStation)

                    If iPlanOrProfile = 0 Then
                        oStation.PlanPlaceholder = pAddPoint(iPlanOrProfile, oNewRow, oLastMousePoint)
                    Else
                        oStation.ProfilePlaceholder = pAddPoint(iPlanOrProfile, oNewRow, oLastMousePoint)
                    End If
                End If

                oNewRow.Selected = True
                Call grdStations_SelectionChanged(Nothing, Nothing)

                Call pDelayedPerformPaint()
            End If
        End With
        'End If
    End Sub

    Private Sub mnuPreviewAdd_Click(sender As System.Object, e As System.EventArgs) Handles mnuPreviewAdd.Click
        Call pAddStation()
    End Sub

    Private Sub mnuPreviewRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPreviewRemoveAll.Click
        If MsgBox(GetLocalizedString("resurvey.warning1"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, GetLocalizedString("resurvey.warningtitle")) = MsgBoxResult.Yes Then
            If pGetCurrentProjection() = 0 Then
                Call pRemoveTrigPoints(0)
            Else
                Call pRemoveTrigPoints(1)
            End If
        End If
    End Sub

    Private Sub pHideTrigPoints(PlanOrProfile As Integer)
        If PlanOrProfile = 0 Then
            For Each oTPH As cResurvey.cTrigpointPlaceholder In oPlanTrigpointsPlaceholders.Values
                oTPH.Visible = False
            Next
        Else
            For Each oTPH As cResurvey.cTrigpointPlaceholder In oProfileTrigpointsPlaceholders.Values
                oTPH.Visible = False
            Next
        End If
        Call pInvalidateCurrentView()
    End Sub

    Private Sub pShowHiddenTrigPoints(PlanOrProfile As Integer)
        If PlanOrProfile = 0 Then
            For Each oTPH As cResurvey.cTrigpointPlaceholder In oPlanTrigpointsPlaceholders.Values
                oTPH.Visible = True
            Next
        Else
            For Each oTPH As cResurvey.cTrigpointPlaceholder In oProfileTrigpointsPlaceholders.Values
                oTPH.Visible = True
            Next
        End If
        Call pInvalidateCurrentView()
    End Sub

    Private Sub pRemoveTrigPoints(PlanOrProfile As Integer)
        If PlanOrProfile = 0 Then
            For Each oTPH As cResurvey.cTrigpointPlaceholder In oPlanTrigpointsPlaceholders.Values
                With oStations(oTPH.Name)
                    .PlanPlaceholder = Nothing
                    .PlanPoint = Nothing
                End With
            Next
            Call oPlanTrigpointsPlaceholders.Clear()
        Else
            For Each oTPH As cResurvey.cTrigpointPlaceholder In oProfileTrigpointsPlaceholders.Values
                With oStations(oTPH.Name)
                    .ProfilePlaceholder = Nothing
                    .ProfilePoint = Nothing
                End With
            Next
            Call oProfileTrigpointsPlaceholders.Clear()
        End If
        Call pDelayedPerformPaint()
    End Sub

    Private Sub mnuPreviewRemove_Click(sender As System.Object, e As System.EventArgs) Handles mnuPreviewRemove.Click
        Call pPlaceHolderDelete()
    End Sub

    Private Sub pPlaceHolderDelete()
        Dim sTrigpoint As String = oLastPlaceHolder.Name
        Dim iPlanOrProfile As Integer = pGetCurrentProjection()
        With oStations(sTrigpoint)
            Dim oRow As DataGridViewRow = .Row
            If iPlanOrProfile = 0 Then
                oPlanTrigpointsPlaceholders.Remove(sTrigpoint)
                .PlanPoint = Nothing
                .PlanPlaceholder = Nothing
                oRow.Cells(2).Value = ""
            Else
                oProfileTrigpointsPlaceholders.Remove(sTrigpoint)
                .ProfilePoint = Nothing
                .ProfilePlaceholder = Nothing
                oRow.Cells(3).Value = ""
            End If
        End With
        oLastPlaceHolder = Nothing
        Call pDelayedPerformPaint()
    End Sub

    Private Sub pSetStatus(Text As String)
        pnlStatus.Text = Text
    End Sub

    Private Sub pImageLoad()
        Dim oOFD As OpenFileDialog = New OpenFileDialog
        With oOFD
            .Filter = GetLocalizedString("resurvey.filetypeIMAGES") & " (*.JPG;*.TIF;*.PNG)|*.JPG;*.TIF;*.PNG"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                If pGetCurrentProjection() = 0 Then
                    sPlanImage = .FileName
                    picPlan.Image = modPaint.ImageExifRotate(New Bitmap(sPlanImage))
                    picPlan.AutoSize = False
                    picPlan.Size = picPlan.Image.Size
                    picPlan.SizeMode = PictureBoxSizeMode.Zoom
                    picPlan.Visible = True
                    sPlanZoom = 1
                Else
                    sProfileImage = .FileName
                    picProfile.Image = modPaint.ImageExifRotate(New Bitmap(sProfileImage))
                    picProfile.AutoSize = False
                    picProfile.Size = picProfile.Image.Size
                    picProfile.SizeMode = PictureBoxSizeMode.Zoom
                    picProfile.Visible = True
                    sProfileZoom = 1
                End If
                Call pBindScrollbars()
            End If
        End With
    End Sub

    Private Sub btnLoadImage_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadImage.Click
        Call pImageLoad()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Call pSave(sFilename)
    End Sub

    Private Sub pSave(Filename As String)
        If Filename = "" Then
            Dim oSFD As SaveFileDialog = New SaveFileDialog
            With oSFD
                .OverwritePrompt = True
                .Filter = GetLocalizedString("resurvey.filetypeCRSX") & " (*.CRSX)|*.CRSX"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Filename = .FileName
                End If
            End With
        End If

        If Filename <> "" Then
            Cursor = Cursors.WaitCursor

            sFilename = Filename

            Text = "cResurvey - " & sFilename

            Dim oXML As XmlDocument = New XmlDocument
            Dim oXMLRoot As XmlElement = oXML.CreateElement("cresurvey")

            Call oXMLRoot.SetAttribute("calculatemode", oOptions.CalculateMode)
            Call oXMLRoot.SetAttribute("nordcorrection", modNumbers.NumberToString(oOptions.NordCorrection))
            Call oXMLRoot.SetAttribute("skipinvalidstation", If(oOptions.SkipInvalidStation, "1", "0"))
            Call oXMLRoot.SetAttribute("usedropforinclination", If(oOptions.UseDropForInclination, "1", "0"))
            If oOptions.PlanScaleType <> cOptions.ScaleTypeEnum.Distance Then Call oXMLRoot.SetAttribute("planscaletype", oOptions.PlanScaleType.ToString("D"))
            If oOptions.DropScaleType <> cOptions.ScaleTypeEnum.DeltaY Then Call oXMLRoot.SetAttribute("dropscaletype", oOptions.DropScaleType.ToString("D"))

            Call oXMLRoot.SetAttribute("calculatelrud", If(oOptions.CalculateLRUD, "1", "0"))
            Call oXMLRoot.SetAttribute("lrudborderwidth", oOptions.LRUDBorderWidth, oOptions.LRUDBorderWidth)
            Call oXMLRoot.SetAttribute("lrmaxvalue", oOptions.LRMaxValue, modNumbers.NumberToString(oOptions.LRMaxValue, "0.0"))
            Call oXMLRoot.SetAttribute("udmaxvalue", oOptions.UDMaxValue, modNumbers.NumberToString(oOptions.UDMaxValue, "0.0"))

            Call oXMLRoot.SetAttribute("planimage", sPlanImage)
            Call oXMLRoot.SetAttribute("profileimage", sProfileImage)

            Dim oXMLStations As XmlElement = oXML.CreateElement("stations")
            For Each oStation As cResurvey.cStation In oStations.Values
                Dim oXMLStation As XmlElement = oXML.CreateElement("station")
                Call oXMLStation.SetAttribute("name", oStation.Name)
                Call oXMLStation.SetAttribute("planpoint", pPointToString(oStation.PlanPoint))
                Call oXMLStation.SetAttribute("profilepoint", pPointToString(oStation.ProfilePoint))
                Call oXMLStation.SetAttribute("planconnectedto", oStation.PlanConnectedTo)
                Call oXMLStation.SetAttribute("profileconnectedto", oStation.ProfileConnectedTo)
                Call oXMLStation.SetAttribute("type", oStation.Type)
                If oStation.Type = "SE" OrElse oStation.Type = "DSE" Then
                    Call oXMLStation.SetAttribute("scale", modNumbers.NumberToString(oStation.Scale))
                End If
                Call oXMLStations.AppendChild(oXMLStation)
            Next

            Call oXMLRoot.AppendChild(oXMLStations)

            Call oXML.AppendChild(oXMLRoot)
            Call oXML.Save(sFilename)

            Cursor = Cursors.Default
        End If
    End Sub

    'Private Function pGetPointData(Name As String, Index As Integer) As String
    '    Try
    '        For Each oStation As cResurvey.cStation In oStations.Values
    '            If oStation.Name = Name Then
    '                Select Case Index
    '                    Case 0
    '                        Return oStation.Name
    '                    Case 1
    '                        Return pPointToString(oStation.PlanPoint)
    '                    Case 2
    '                        Return pPointToString(oStation.ProfilePoint)
    '                    Case 4
    '                        Return oStation.Type
    '                    Case 3
    '                        Return oStation.ConnectedTo
    '                End Select
    '            End If
    '        Next
    '        Return ""
    '    Catch
    '        Return ""
    '    End Try
    'End Function

    Private Function pGetPointByType([Type] As String) As String
        For Each oStation As cResurvey.cStation In oStations.Values
            If oStation.Type = [Type] Then
                Return oStation.Name
            End If
        Next
        Return ""
    End Function

    Private Function pGetSecondDropScalePoint() As String
        Return pGetPointByType("DSE")
    End Function

    Private Function pGetFirstDropScalePoint() As String
        Return pGetPointByType("DSB")
    End Function

    Private Function pGetSecondScalePoint() As String
        Return pGetPointByType("SE")
    End Function

    Private Function pGetFirstScalePoint() As String
        Return pGetPointByType("SB")
    End Function

    Private Function pGetFirstStation() As String
        Return pGetPointByType("O")
    End Function

    Private Function pGetNextStation(PlanOrProfile As Integer, Name As String) As List(Of String)
        Dim oConnectedTo As List(Of String) = New List(Of String)
        Dim sConnectedTo As String
        If oStations.ContainsKey(Name) Then
            Dim oStation As cResurvey.cStation = oStations(Name)
            If oStation.Type = "" Or oStation.Type = "O" Then
                If PlanOrProfile = 0 Then
                    sConnectedTo = oStation.PlanConnectedTo
                Else
                    sConnectedTo = oStation.ProfileConnectedTo
                End If
                Call oConnectedTo.AddRange(cResurvey.cStation.GetConnectedToCollection(sConnectedTo))
            End If

            For Each oStation In oStations.Values
                If oStation.Type = "" Or oStation.Type = "O" Then
                    If PlanOrProfile = 0 Then
                        sConnectedTo = oStation.PlanConnectedTo
                    Else
                        sConnectedTo = oStation.ProfileConnectedTo
                    End If
                    Dim oTmpConnectedTo As List(Of String) = New List(Of String)(cResurvey.cStation.GetConnectedToCollection(sConnectedTo))
                    If oTmpConnectedTo.Contains(Name) Then
                        Call oConnectedTo.Add(oStation.Name)
                    End If
                End If
            Next

            Dim bOk As Boolean = False
            Dim oCheckConnectedTo As List(Of String) = New List(Of String)(oConnectedTo)
            For Each sStation As String In oCheckConnectedTo
                If oStations.ContainsKey(sStation) Then
                    bOk = pPointAsData(sStation, PlanOrProfile)
                Else
                    bOk = False
                End If
                If Not bOk Then
                    Call oConnectedTo.Remove(Name)
                End If
            Next

            If oConnectedTo.Contains(Name) Then Call oConnectedTo.Remove(Name)
        End If
        Return oConnectedTo
    End Function

    Private Sub pAppendConnection(Placeholders As Dictionary(Of String, cResurvey.cTrigpointPlaceholder), [From] As String, [To] As String)
        If Placeholders.ContainsKey([From]) And Placeholders.ContainsKey([To]) Then
            Call Placeholders([From]).Connections.Add(Placeholders([To]))
        End If
    End Sub

    'Private Sub pCalculateShot(Processed As List(Of String), Station As String, NextStation As String, Scale As Single)
    '    If NextStation <> "" Then
    '        If NextStation.EndsWith(">") Then
    '            Select Case oOptions.CalculateMode
    '                Case cResurvey.cOptions.CalculateModeEnum.Full
    '                    Call pAppendConnection(oPlanTrigpointsPlaceholders, Station, NextStation)
    '                    Call pAppendConnection(oProfileTrigpointsPlaceholders, Station, NextStation)
    '                Case cResurvey.cOptions.CalculateModeEnum.OnlyPlan
    '                    Call pAppendConnection(oPlanTrigpointsPlaceholders, Station, NextStation)
    '            End Select
    '            'traslazione...salto la riga nel rilievo...
    '            Station = NextStation
    '        Else
    '            Select Case oOptions.CalculateMode
    '                Case cResurvey.cOptions.CalculateModeEnum.Full
    '                    Dim oPlanFromPoint As PointF = pGetPoint(Station, 0)
    '                    Dim oProfileFromPoint As PointF = pGetPoint(Station, 1)

    '                    'If oPlanFromPoint.IsEmpty Or oProfileFromPoint.IsEmpty Then
    '                    '    Exit Sub
    '                    '    'qua ci andrà una qualche segnalazione
    '                    'Else
    '                    Call pAppendConnection(oPlanTrigpointsPlaceholders, Station, NextStation)
    '                    Call pAppendConnection(oProfileTrigpointsPlaceholders, Station, NextStation)

    '                    If Station.EndsWith(">") Then
    '                        Dim sRealStation As String = Station.Substring(0, Station.Length - 1)
    '                        If oPlanFromPoint.IsEmpty Then
    '                            oPlanFromPoint = pGetPoint(sRealStation, 0)
    '                        End If
    '                        If oProfileFromPoint.IsEmpty Then
    '                            oProfileFromPoint = pGetPoint(sRealStation, 1)
    '                        End If

    '                        Call pAppendConnection(oPlanTrigpointsPlaceholders, Station, NextStation)
    '                        Call pAppendConnection(oProfileTrigpointsPlaceholders, Station, NextStation)

    '                        Station = sRealStation
    '                    End If

    '                    Dim oPlanToPoint As PointF = pGetPoint(NextStation, 0)
    '                    Dim oProfileToPoint As PointF = pGetPoint(NextStation, 1)

    '                    Dim sDistance As Single = modPaint.DistancePointToPoint(oProfileFromPoint, oProfileToPoint)
    '                    sDistance = sDistance * Scale
    '                    Dim sBearing As Single = modPaint.GetBearing(oPlanFromPoint, oPlanToPoint)
    '                    Dim sInclination As Single = modPaint.GetBearing(oProfileFromPoint, oProfileToPoint)
    '                    If sInclination >= 0 And sInclination <= 90 Then
    '                        sInclination = 90 - sInclination
    '                    End If
    '                    If sInclination > 90 And sInclination <= 180 Then
    '                        sInclination = 90 - sInclination
    '                    End If
    '                    If sInclination > 180 And sInclination <= 270 Then
    '                        sInclination = sInclination - 270
    '                    End If
    '                    If sInclination > 270 And sInclination < 360 Then
    '                        sInclination = sInclination - 270
    '                    End If
    '                    sDistance = modNumbers.MathRound(sDistance, 2)
    '                    sBearing = modNumbers.MathRound(sBearing, 2)
    '                    sInclination = modNumbers.MathRound(sInclination, 2)
    '                    Call AppendData(Station, NextStation, sDistance, sBearing, sInclination)

    '                    Call Processed.Add(Station & vbTab & NextStation)
    '                    Station = NextStation
    '                    'End If
    '                Case cResurvey.cOptions.CalculateModeEnum.OnlyPlan
    '                    Dim oPlanFromPoint As PointF = pGetPoint(Station, 0)

    '                    'If oPlanFromPoint.IsEmpty Then
    '                    '    'qua ci andrà una qualche segnalazione
    '                    '    Exit Sub
    '                    'Else
    '                    Call pAppendConnection(oPlanTrigpointsPlaceholders, Station, NextStation)

    '                    If Station.EndsWith(">") Then
    '                        Dim sRealStation As String = Station.Substring(0, Station.Length - 1)
    '                        If oPlanFromPoint.IsEmpty Then
    '                            oPlanFromPoint = pGetPoint(sRealStation, 0)
    '                        End If
    '                        Call pAppendConnection(oPlanTrigpointsPlaceholders, Station, NextStation)
    '                        Station = sRealStation
    '                    End If

    '                    Dim oPlanToPoint As PointF = pGetPoint(NextStation, 0)

    '                    Dim sDistance As Single = modPaint.DistancePointToPoint(oPlanFromPoint, oPlanToPoint)
    '                    sDistance = sDistance * Scale
    '                    Dim sBearing As Single = modPaint.GetBearing(oPlanFromPoint, oPlanToPoint)
    '                    Dim sInclination As Single = 0

    '                    sDistance = modNumbers.MathRound(sDistance, 2)
    '                    sBearing = modNumbers.MathRound(sBearing, 2)
    '                    sInclination = modNumbers.MathRound(sInclination, 2)
    '                    Call AppendData(Station, NextStation, sDistance, sBearing, sInclination)

    '                    Call Processed.Add(Station & vbTab & NextStation)
    '                    Station = NextStation
    '                    'End If
    '            End Select
    '        End If
    '        Call pCalculate(Processed, Station, Scale)
    '    End If
    'End Sub

    Private Function pGetRealStation(Station As String) As String
        Return Station.Replace(">", "")
    End Function

    Private Function pJustProcessed(Processed As List(Of String), [From] As String, [To] As String) As Boolean
        Dim sFrom As String = [From]
        Dim sTo As String = [To]
        Dim sDirected As String = cResurvey.cShots.GetKey(sFrom, [sTo])
        Dim sInverted As String = cResurvey.cShots.GetKey([sTo], sFrom)
        Return Processed.Contains(sDirected) Or Processed.Contains(sInverted)
    End Function

    Private Sub pPaintShots(PlanOrProfile As Integer, Processed As List(Of String), Station As String)
        If Station <> "" Then
            Dim oNextStations As List(Of String) = pGetNextStation(PlanOrProfile, Station)
            For Each sNextStation As String In oNextStations
                If Not pJustProcessed(Processed, Station, sNextStation) Then
                    Call pPaintShot(PlanOrProfile, Processed, Station, sNextStation)
                End If
            Next
        End If
    End Sub

    Private Sub pPaintShot(PlanOrProfile As Integer, Processed As List(Of String), Station As String, NextStation As String)
        If NextStation <> "" Then
            Select Case PlanOrProfile
                Case 0
                    Dim oPlanFromPoint As PointF = pGetPoint(Station, 0)
                    Dim oPlanToPoint As Point = pGetPoint(NextStation, 0)
                    If Not oPlanFromPoint.IsEmpty And Not oPlanToPoint.IsEmpty Then
                        Call oPlanShotsPath.StartFigure()
                        Call oPlanShotsPath.AddLine(oPlanFromPoint, oPlanToPoint)
                    End If
                Case 1
                    Dim oProfileFromPoint As PointF = pGetPoint(Station, 1)
                    Dim oProfileToPoint As Point = pGetPoint(NextStation, 1)
                    If Not oProfileFromPoint.IsEmpty And Not oProfileToPoint.IsEmpty Then
                        Call oProfileShotsPath.StartFigure()
                        Call oProfileShotsPath.AddLine(oProfileFromPoint, oProfileToPoint)
                    End If
            End Select
            Call Processed.Add(cResurvey.cShots.GetKey(Station, NextStation))
            Station = NextStation
            Call pPaintShots(PlanOrProfile, Processed, Station)
        End If
    End Sub

    Private Sub btnCalculate_Click(sender As System.Object, e As System.EventArgs) Handles btnCalculate.Click
        Call pPerformCalculate()
        If grdPlot.Rows.Count > 0 Then
            Call btnPlot_Click(Nothing, Nothing)
            btnConfirm.Enabled = True
            btnExport.Enabled = True
        Else
            btnConfirm.Enabled = False
            btnExport.Enabled = False
        End If
    End Sub

    Private Function pGetPoint(Name As String, PlanOrProfile As Integer) As Point
        If oStations.ContainsKey(Name) Then
            Dim oStation As cResurvey.cStation = oStations(Name)
            If PlanOrProfile = 0 Then
                Return oStation.PlanPoint
            Else
                Return oStation.ProfilePoint
            End If
        Else
            Return New Point(0, 0)
        End If
    End Function

    Private Function pPointAsData(Name As String, PlanOrProfile As Integer) As Boolean
        If pGetPoint(Name, PlanOrProfile).IsEmpty Then
            Return False
        Else
            Return True
        End If
    End Function

    Friend Function GetOrigin() As String
        Return pGetFirstStation()
    End Function

    Private Function pGetScale() As cResurvey.cScale
        Dim sPlanScale As Single = 1
        Dim sPlanScaleDistance As Single
        Dim bPlanError As Boolean
        Dim sProfileScale As Single = 1
        Dim sProfileScaleDistance As Single
        Dim bProfileError As Boolean
        Try
            Dim sFirstScalePoint As String = pGetFirstScalePoint()
            Dim sSecondScalePoint As String = pGetSecondScalePoint()
            Dim sScaleSize As Single
            If oOptions.UseDropForInclination Then
                Dim oPlanFirstScalePoint As PointF = pGetPoint(sFirstScalePoint, 0)
                Dim oPlanSecondScalePoint As PointF = pGetPoint(sSecondScalePoint, 0)
                Select Case oOptions.PlanScaleType
                    Case cOptions.ScaleTypeEnum.DeltaX
                        sPlanScaleDistance = Math.Abs(oPlanFirstScalePoint.X - oPlanSecondScalePoint.X)
                    Case cOptions.ScaleTypeEnum.DeltaY
                        sPlanScaleDistance = Math.Abs(oPlanFirstScalePoint.Y - oPlanSecondScalePoint.Y)
                    Case cOptions.ScaleTypeEnum.Distance
                        sPlanScaleDistance = modPaint.DistancePointToPoint(oPlanFirstScalePoint, oPlanSecondScalePoint)
                End Select
                If oStations.ContainsKey(sSecondScalePoint) Then sScaleSize = oStations(sSecondScalePoint).Scale
            Else
                If pPointAsData(sFirstScalePoint, 1) Then
                    Dim oProfileFirstScalePoint As PointF = pGetPoint(sFirstScalePoint, 1)
                    Dim oProfileSecondScalePoint As PointF = pGetPoint(sSecondScalePoint, 1)
                    Select Case oOptions.PlanScaleType
                        Case cOptions.ScaleTypeEnum.DeltaX
                            sPlanScaleDistance = Math.Abs(oProfileFirstScalePoint.X - oProfileSecondScalePoint.X)
                        Case cOptions.ScaleTypeEnum.DeltaY
                            sPlanScaleDistance = Math.Abs(oProfileFirstScalePoint.Y - oProfileSecondScalePoint.Y)
                        Case cOptions.ScaleTypeEnum.Distance
                            sPlanScaleDistance = modPaint.DistancePointToPoint(oProfileFirstScalePoint, oProfileSecondScalePoint)
                    End Select
                    'sPlanScaleDistance = modPaint.DistancePointToPoint(oProfileFirstScalePoint, oProfileSecondScalePoint)
                    If oStations.ContainsKey(sSecondScalePoint) Then sScaleSize = oStations(sSecondScalePoint).Scale
                Else
                    Dim oPlanFirstScalePoint As PointF = pGetPoint(sFirstScalePoint, 0)
                    Dim oPlanSecondScalePoint As PointF = pGetPoint(sSecondScalePoint, 0)
                    Select Case oOptions.PlanScaleType
                        Case cOptions.ScaleTypeEnum.DeltaX
                            sPlanScaleDistance = Math.Abs(oPlanFirstScalePoint.X - oPlanSecondScalePoint.X)
                        Case cOptions.ScaleTypeEnum.DeltaY
                            sPlanScaleDistance = Math.Abs(oPlanFirstScalePoint.Y - oPlanSecondScalePoint.Y)
                        Case cOptions.ScaleTypeEnum.Distance
                            sPlanScaleDistance = modPaint.DistancePointToPoint(oPlanFirstScalePoint, oPlanSecondScalePoint)
                    End Select
                    'sPlanScaleDistance = modPaint.DistancePointToPoint(oPlanFirstScalePoint, oPlanSecondScalePoint)
                    If oStations.ContainsKey(sSecondScalePoint) Then sScaleSize = oStations(sSecondScalePoint).Scale
                End If
            End If
            If sScaleSize = 0 Or sPlanScaleDistance = 0 Then
                bPlanError = True
                sPlanScale = 1
            Else
                sPlanScale = sScaleSize / sPlanScaleDistance
                sPlanScale = sScaleSize / sPlanScaleDistance
                If Math.Round(sPlanScale, 6) = 0 Then
                    bPlanError = True
                    sPlanScale = 1
                End If
            End If
        Catch
            Call pPopupShow("warning", GetLocalizedString("resurvey.warning2"))
            sPlanScale = 1
        End Try

        If oOptions.CalculateMode = cOptions.CalculateModeEnum.Full AndAlso oOptions.UseDropForInclination Then
            Dim sFirstDropScalePoint As String = pGetFirstDropScalePoint()
            Dim sSecondDropScalePoint As String = pGetSecondDropScalePoint()
            Dim sProfileScaleSize As Single

            Dim oProfileFirstDropScalePoint As PointF = pGetPoint(sFirstDropScalePoint, 1)
            Dim oProfileSecondScalePoint As PointF = pGetPoint(sSecondDropScalePoint, 1)
            Select Case oOptions.DropScaleType
                Case cOptions.ScaleTypeEnum.DeltaX
                    sProfileScaleDistance = Math.Abs(oProfileFirstDropScalePoint.X - oProfileSecondScalePoint.X)
                Case cOptions.ScaleTypeEnum.DeltaY
                    sProfileScaleDistance = Math.Abs(oProfileFirstDropScalePoint.Y - oProfileSecondScalePoint.Y)
                Case cOptions.ScaleTypeEnum.Distance
                    sProfileScaleDistance = modPaint.DistancePointToPoint(oProfileFirstDropScalePoint, oProfileSecondScalePoint)
            End Select
            If oStations.ContainsKey(sSecondDropScalePoint) Then sProfileScaleSize = oStations(sSecondDropScalePoint).Scale

            If sProfileScaleSize = 0 Or sProfileScaleDistance = 0 Then
                bProfileError = True
                sProfileScale = 1
            Else
                sProfileScale = sProfileScaleSize / sProfileScaleDistance
                If Math.Round(sProfileScale, 6) = 0 Then
                    bProfileError = True
                    sProfileScale = 1
                End If
            End If
        Else
            sProfileScale = sPlanScale
            sProfileScaleDistance = sPlanScaleDistance
            bProfileError = bPlanError
        End If

        Return New cScale(sPlanScale, sPlanScaleDistance, bPlanError, sProfileScale, sProfileScaleDistance, bProfileError)
    End Function

    Private Sub pPerformCalculate(Optional Paint As Boolean = True)
        Call pPopupHide()
        oLastLine = Nothing

        Call oShots.Clear()
        Call grdPlot.Rows.Clear()

        Dim oScale As cResurvey.cScale = pGetScale()
        If oScale.PlanError Then
            Call pPopupShow("warning", GetLocalizedString("resurvey.warning2"))
        End If
        If oScale.ProfileError Then
            Call pPopupShow("warning", GetLocalizedString("resurvey.warning2a"))
        End If

        For Each oTPH As cResurvey.cTrigpointPlaceholder In oPlanTrigpointsPlaceholders.Values
            Call oTPH.Connections.Clear()
        Next
        For Each oTPH As cResurvey.cTrigpointPlaceholder In oProfileTrigpointsPlaceholders.Values
            Call oTPH.Connections.Clear()
        Next

        Dim sStation As String = "" & pGetFirstStation()
        If sStation = "" Then
            Call pPopupShow("error", GetLocalizedString("resurvey.warning3"))
        Else
            Try
                Call pCalculateFromPlan(sStation, oScale.PlanScale)
                Call pCalculateCleanShots()
                If oOptions.CalculateMode = cResurvey.cOptions.CalculateModeEnum.Full Then
                    Call pCalculateFromProfile(sStation, oScale.ProfileScale)
                    Call pCalculateCleanShots()
                End If
            Catch ex As Exception
                Call pPopupShow("error", String.Format(GetLocalizedString("resurvey.warning4"), ex.Message))
            End Try

            If oOptions.CalculateMode = cOptions.CalculateModeEnum.Full AndAlso oOptions.UseDropForInclination Then
                For Each oShot As cResurvey.cShot In oShots
                    If oShot.From <> oShot.To Then
                        'trigo for real distance
                        oShot.Distance = Math.Sqrt(oShot.PlanimetricDistance ^ 2 + oShot.Drop ^ 2)
                    End If
                Next
            End If

            For Each oShot As cResurvey.cShot In oShots
                Dim oData(10) As Object
                If oShot.From <> oShot.To Then
                    oData(0) = oShot.[From]
                    oData(1) = oShot.[To]

                    oData(2) = Strings.Format(oShot.PlanimetricDistance, "0.00")
                    oData(3) = Strings.Format(oShot.Drop, "0.00")

                    oData(4) = Strings.Format(oShot.Distance, "0.00")
                    oData(5) = Strings.Format(oShot.Bearing, "0.00")
                    oData(6) = Strings.Format(oShot.Inclination, "0.00")

                    oData(7) = Strings.Format(oShot.Left, "0.00")
                    oData(8) = Strings.Format(oShot.Right, "0.00")
                    oData(9) = Strings.Format(oShot.Up, "0.00")
                    oData(10) = Strings.Format(oShot.Down, "0.00")
                    Call grdPlot.Rows.Add(oData)
                End If
            Next
        End If
        If Paint Then Call pDelayedPerformPaint()
    End Sub

    Private Sub pCalculateCleanShots()
        Dim oShotsToDelete As List(Of cResurvey.cShot) = New List(Of cResurvey.cShot)
        For Each oShot As cResurvey.cShot In oShots
            Dim sRealFrom As String = pGetRealStation(oShot.From)
            Dim sRealTo As String = pGetRealStation(oShot.To)

            If sRealFrom = sRealTo Then
                Call oShotsToDelete.Add(oShot)
            Else
                If sRealFrom <> oShot.From Or sRealTo <> oShot.To Then
                    oShot.From = sRealFrom
                    oShot.To = sRealTo
                End If
            End If
        Next
        For Each oShot In oShotsToDelete
            Call oShots.Remove(oShot)
        Next

        Dim oNewShots As cResurvey.cShots = New cResurvey.cShots
        For Each oShot In oShots
            Dim oExistingShot As cResurvey.cShot = oNewShots.GetShot(oShot.From, oShot.To)
            If Not oExistingShot Is Nothing Then
                If oExistingShot.Distance = 0 And oShot.Distance <> 0 Then oExistingShot.Distance = oShot.Distance Else oShot.Distance = oExistingShot.Distance
                If oExistingShot.Bearing = 0 And oShot.Bearing <> 0 Then oExistingShot.Bearing = oShot.Bearing Else oShot.Bearing = oExistingShot.Bearing
                If oExistingShot.Inclination = 0 And oShot.Inclination <> 0 Then oExistingShot.Inclination = oShot.Inclination Else oShot.Inclination = oExistingShot.Inclination
                If oExistingShot.Drop = 0 And oShot.Drop <> 0 Then oExistingShot.Drop = oShot.Drop Else oShot.Drop = oExistingShot.Drop
                If oExistingShot.PlanimetricDistance = 0 And oShot.PlanimetricDistance <> 0 Then oExistingShot.PlanimetricDistance = oShot.PlanimetricDistance Else oShot.PlanimetricDistance = oExistingShot.PlanimetricDistance

                If oExistingShot.Drop < 0 Then
                    oExistingShot.Drop = Math.Abs(oExistingShot.Drop)
                    oExistingShot.Distance = Math.Sqrt(oExistingShot.Drop ^ 2 + oExistingShot.PlanimetricDistance ^ 2)
                    oExistingShot.Inclination = -modPaint.RadiansToDegree(Math.Acos(oExistingShot.PlanimetricDistance / oExistingShot.Distance)) ' ß =  Arcsen (b/a)
                ElseIf oExistingShot.Drop = 0 Then
                    oExistingShot.Distance = oExistingShot.PlanimetricDistance
                Else
                    oExistingShot.Distance = Math.Sqrt(oExistingShot.Drop ^ 2 + oExistingShot.PlanimetricDistance ^ 2)
                    oExistingShot.Inclination = modPaint.RadiansToDegree(Math.Acos(oExistingShot.PlanimetricDistance / oExistingShot.Distance)) ' ß =  Arcsen (b/a)
                End If
            Else
                Call oNewShots.Add(oShot)
                If oOptions.UseDropForInclination Then
                    If oShot.Drop < 0 Then
                        oShot.Drop = Math.Abs(oShot.Drop)
                        oShot.Distance = Math.Sqrt(oShot.Drop ^ 2 + oShot.PlanimetricDistance ^ 2)
                        oShot.Inclination = -modPaint.RadiansToDegree(Math.Acos(oShot.PlanimetricDistance / oShot.Distance)) ' ß =  Arcsen (b/a)
                    ElseIf oShot.Drop = 0 Then
                        oShot.Distance = oShot.PlanimetricDistance
                    Else
                        oShot.Distance = Math.Sqrt(oShot.Drop ^ 2 + oShot.PlanimetricDistance ^ 2)
                        oShot.Inclination = modPaint.RadiansToDegree(Math.Acos(oShot.PlanimetricDistance / oShot.Distance)) ' ß =  Arcsen (b/a)
                    End If
                End If
            End If
        Next
        oShots = oNewShots
    End Sub

    Private Sub pCalculateFromPlan(FromStation As String, Scale As Single)
        'Dim sRealFromStation As String = pGetRealStation(FromStation)
        For Each sToStation As String In pGetNextStation(0, FromStation)
            sToStation = "" & sToStation
            If sToStation <> "" Then
                Dim sImageBearing As Single
                If oShots.GetShot(FromStation, sToStation) Is Nothing Then
                    Dim oShot As cResurvey.cShot = New cResurvey.cShot
                    oShot.From = FromStation
                    oShot.To = sToStation
                    Dim oPlanFromPoint As PointF = pGetPoint(FromStation, 0)
                    Dim oPlanToPoint As PointF = pGetPoint(sToStation, 0)
                    If oOptions.CalculateMode = cResurvey.cOptions.CalculateModeEnum.Full AndAlso Not oOptions.UseDropForInclination Then
                        Dim sBearing As Single = modPaint.GetBearing(oPlanFromPoint, oPlanToPoint)
                        sImageBearing = sBearing
                        sBearing = modNumbers.MathRound(modPaint.NormalizeAngle(sBearing + oOptions.NordCorrection), 1)
                        oShot.Bearing = sBearing
                        oShot.PlanProcessed = True
                    Else
                        Dim sDistance As Single = modPaint.DistancePointToPoint(oPlanFromPoint, oPlanToPoint)
                        Dim sBearing As Single = modPaint.GetBearing(oPlanFromPoint, oPlanToPoint)
                        sImageBearing = sBearing
                        Dim sInclination As Single = 0
                        sDistance = sDistance * Scale
                        sDistance = modNumbers.MathRound(sDistance, 2)
                        sBearing = modNumbers.MathRound(modPaint.NormalizeAngle(sBearing + oOptions.NordCorrection), 1)
                        sInclination = modNumbers.MathRound(sInclination, 1)
                        If oOptions.CalculateMode = cResurvey.cOptions.CalculateModeEnum.Full AndAlso oOptions.UseDropForInclination Then
                            oShot.PlanimetricDistance = sDistance
                        Else
                            oShot.Distance = sDistance
                        End If
                        oShot.Bearing = sBearing
                        oShot.Inclination = sInclination
                        oShot.PlanProcessed = True
                    End If
                    Call oShots.Add(oShot)
                    If oOptions.CalculateLRUD Then pFillLR(oShot, oPlanToPoint, sImageBearing, Scale)
                    Call pCalculateFromPlan(sToStation, Scale)
                End If
            End If
        Next
    End Sub

    Private Sub pCalculateFromProfile(FromStation As String, Scale As Single)
        'Dim sRealFromStation As String = pGetRealStation(FromStation)
        For Each sToStation As String In pGetNextStation(1, FromStation)
            sToStation = "" & sToStation
            If sToStation <> "" Then
                Dim oShot As cResurvey.cShot = oShots.GetShot(FromStation, sToStation)
                If oShot Is Nothing Then
                    oShot = New cResurvey.cShot
                    oShot.From = FromStation
                    oShot.To = sToStation
                    oShot.Bearing = 0
                    oShot.PlanProcessed = True
                    oShot.ProfileProcessed = False
                    Call oShots.Add(oShot)
                End If
                If Not oShot.ProfileProcessed Then
                    If oOptions.UseDropForInclination Then
                        Dim oProfileFromPoint As PointF = pGetPoint(FromStation, 1)
                        Dim oProfileToPoint As PointF = pGetPoint(sToStation, 1)
                        Dim sDrop As Single = oProfileFromPoint.Y - oProfileToPoint.Y
                        sDrop = sDrop * Scale
                        sDrop = modNumbers.MathRound(sDrop, 2)
                        oShot.Drop = sDrop
                        'If sDrop < 0 Then
                        '    sDrop = Math.Abs(sDrop)
                        '    oShot.Distance = Math.Sqrt(sDrop ^ 2 + oShot.PlanimetricDistance ^ 2)
                        '    oShot.Inclination = -modPaint.RadiansToDegree(Math.Acos(oShot.PlanimetricDistance / oShot.Distance)) ' ß =  Arcsen (b/a)
                        'ElseIf sDrop = 0 Then
                        '    oShot.Distance = oShot.PlanimetricDistance
                        'Else
                        '    oShot.Distance = Math.Sqrt(sDrop ^ 2 + oShot.PlanimetricDistance ^ 2)
                        '    oShot.Inclination = modPaint.RadiansToDegree(Math.Acos(oShot.PlanimetricDistance / oShot.Distance)) ' ß =  Arcsen (b/a)
                        'End If
                        oShot.ProfileProcessed = True
                        If oOptions.CalculateLRUD Then pFillUD(oShot, oProfileToPoint, Scale)
                    Else
                        Dim oProfileFromPoint As PointF = pGetPoint(FromStation, 1)
                        Dim oProfileToPoint As PointF = pGetPoint(sToStation, 1)
                        Dim sDistance As Single = modPaint.DistancePointToPoint(oProfileFromPoint, oProfileToPoint)
                        sDistance = sDistance * Scale
                        Dim sInclination As Single = modPaint.GetBearing(oProfileFromPoint, oProfileToPoint)
                        If sInclination >= 0 And sInclination <= 90 Then
                            sInclination = 90 - sInclination
                        End If
                        If sInclination > 90 And sInclination <= 180 Then
                            sInclination = 90 - sInclination
                        End If
                        If sInclination > 180 And sInclination <= 270 Then
                            sInclination = sInclination - 270
                        End If
                        If sInclination > 270 And sInclination < 360 Then
                            sInclination = sInclination - 270
                        End If
                        sDistance = modNumbers.MathRound(sDistance, 2)
                        sInclination = modNumbers.MathRound(sInclination, 2)
                        oShot.Distance = sDistance
                        oShot.Inclination = sInclination
                        oShot.ProfileProcessed = True
                        If oOptions.CalculateLRUD Then pFillUD(oShot, oProfileToPoint, Scale)
                    End If
                    Call pCalculateFromProfile(sToStation, Scale)
                End If
            End If
        Next
    End Sub

    Private Sub pFillLR(Shot As cResurvey.cShot, Point As PointF, Bearing As Single, Scale As Single)
        Dim iBorderPenWidth As Integer = oOptions.LRUDBorderWidth
        Dim iMaxWidth As Integer = oOptions.LRMaxValue
        Dim iColorPivot As Integer = 100
        Dim iMaxValue As Integer = 200
        Dim oImage As Bitmap = picPlan.Image
        Dim oBounds As RectangleF = oImage.GetBounds(System.Drawing.GraphicsUnit.Pixel)
        Dim oPoint As Point
        Dim oColor As Color
        Dim sD As Single
        Dim iD As Integer
        Dim bBorderFound As Boolean
        Dim bFirst As Boolean

        oPoint = New Point(Point.X, Point.Y)
        iD = 0
        sD = 0
        bFirst = True
        'scorro finchè il valore è scuro
        Try
            Do
                Dim iLocalD As Integer = 0
                Do
                    iD += 1
                    iLocalD += 1
                    Dim oDiff As SizeF = modPaint.Trigo(iD, modPaint.AddAngle(Bearing, -90))
                    oPoint.X = Point.X + oDiff.Width
                    oPoint.Y = Point.Y + oDiff.Height
                    If oBounds.Contains(oPoint) Then
                        oColor = oImage.GetPixel(oPoint.X, oPoint.Y)
                        oColor = modPaint.GrayColor(oColor)
                        If Math.Abs(iLocalD) >= iBorderPenWidth Then
                            bBorderFound = True And Not bFirst
                            Exit Do
                        End If
                    Else
                        Exit Do
                    End If
                Loop While oColor.R < iColorPivot And oBounds.Contains(oPoint) And ((Math.Abs(iD) * Scale) < iMaxWidth)
                bFirst = False
                'scorro finchè il valore è chiaro
                If Not bBorderFound Then
                    Do
                        iD += 1
                        Dim oDiff As SizeF = modPaint.Trigo(iD, modPaint.AddAngle(Bearing, -90))
                        oPoint.X = Point.X + oDiff.Width
                        oPoint.Y = Point.Y + oDiff.Height
                        If oBounds.Contains(oPoint) Then
                            oColor = oImage.GetPixel(oPoint.X, oPoint.Y)
                            'oImage.SetPixel(oPoint.X, oPoint.Y, Color.Blue)
                            oColor = modPaint.GrayColor(oColor)
                            If Not oBounds.Contains(oPoint) Then
                                iD = 0
                                bBorderFound = True
                                Exit Do
                            End If
                        Else
                            Exit Do
                        End If
                    Loop While (oColor.R >= iColorPivot) And ((Math.Abs(iD) * Scale) < iMaxWidth)
                End If
                If ((Math.Abs(iD) * Scale) >= iMaxWidth) Then
                    iD = 0
                    bBorderFound = True
                    Exit Do
                End If
            Loop Until bBorderFound
            sD = CSng(iD) * Scale
        Catch
            sD = 0
        End Try
        Shot.Left = sD

        bBorderFound = False
        oPoint = New Point(Point.X, Point.Y)
        iD = 0
        sD = 0
        bFirst = True
        'scorro finchè il valore è scuro
        Try
            Do
                Dim iLocalD As Integer = 0
                Do
                    iD -= 1
                    iLocalD -= 1
                    Dim oDiff As SizeF = modPaint.Trigo(iD, modPaint.AddAngle(Bearing, 90))
                    oPoint.X = Point.X - oDiff.Width
                    oPoint.Y = Point.Y - oDiff.Height
                    If oBounds.Contains(oPoint) Then
                        oColor = oImage.GetPixel(oPoint.X, oPoint.Y)
                        'oImage.SetPixel(oPoint.X, oPoint.Y, Color.LightGreen)
                        oColor = modPaint.GrayColor(oColor)
                        If Math.Abs(iLocalD) >= iBorderPenWidth Then
                            bBorderFound = True And Not bFirst
                            Exit Do
                        End If
                    Else
                        Exit Do
                    End If
                Loop While oColor.R < iColorPivot And oBounds.Contains(oPoint) And ((Math.Abs(iD) * Scale) < iMaxWidth)
                bFirst = False
                'scorro finchè il valore è chiaro
                If Not bBorderFound Then
                    Do
                        iD -= 1
                        Dim oDiff As SizeF = modPaint.Trigo(iD, modPaint.AddAngle(Bearing, 90))
                        oPoint.X = Point.X - oDiff.Width
                        oPoint.Y = Point.Y - oDiff.Height
                        If oBounds.Contains(oPoint) Then
                            oColor = oImage.GetPixel(oPoint.X, oPoint.Y)
                            'oImage.SetPixel(oPoint.X, oPoint.Y, Color.Green)
                            oColor = modPaint.GrayColor(oColor)
                            If Not oBounds.Contains(oPoint) Then
                                iD = 0
                                bBorderFound = True
                                Exit Do
                            End If
                        Else
                            Exit Do
                        End If
                    Loop While (oColor.R >= iColorPivot) And ((Math.Abs(iD) * Scale) < iMaxWidth)
                End If
                If ((Math.Abs(iD) * Scale) >= iMaxWidth) Then
                    iD = 0
                    bBorderFound = True
                    Exit Do
                End If
            Loop Until bBorderFound
            'converto il valore in pixel in valore reale
            sD = CSng(iD) * Scale
        Catch
            sD = 0
        End Try
        Shot.Right = Math.Abs(sD)
    End Sub

    Private Sub pFillUD(Shot As cResurvey.cShot, Point As PointF, Scale As Single)
        Dim iBorderPenWidth As Integer = oOptions.LRUDBorderWidth
        Dim iMaxWidth As Integer = oOptions.LRMaxValue
        Dim iColorPivot As Integer = 100
        Dim iMaxValue As Integer = 200
        Dim oImage As Bitmap = picPlan.Image
        Dim oBounds As RectangleF = oImage.GetBounds(System.Drawing.GraphicsUnit.Pixel)
        Dim oPoint As Point
        Dim oColor As Color
        Dim sD As Single
        Dim iD As Integer
        Dim bBorderFound As Boolean
        Dim bFirst As Boolean

        oPoint = New Point(Point.X, Point.Y)
        iD = 0
        sD = 0
        bFirst = True
        'scorro finchè il valore è scuro
        Try
            Do
                Dim iLocalD As Integer = 0
                Do
                    iD += 1
                    iLocalD += 1
                    'Dim oDiff As SizeF = modPaint.Trigo(iD, modPaint.AddAngle(Bearing, -90))
                    'oPoint.X = Point.X + oDiff.Width
                    'oPoint.Y = Point.Y + oDiff.Height
                    oPoint.Y += 1
                    If oBounds.Contains(oPoint) Then
                        oColor = oImage.GetPixel(oPoint.X, oPoint.Y)
                        'oImage.SetPixel(oPoint.X, oPoint.Y, Color.LightBlue)
                        oColor = modPaint.GrayColor(oColor)
                        If Math.Abs(iLocalD) >= iBorderPenWidth Then
                            bBorderFound = True And Not bFirst
                            Exit Do
                        End If
                    Else
                        Exit Do
                    End If
                Loop While oColor.R < iColorPivot And oBounds.Contains(oPoint) And ((Math.Abs(iD) * Scale) < iMaxWidth)
                bFirst = False
                'scorro finchè il valore è chiaro
                If Not bBorderFound Then
                    Do
                        iD += 1
                        'Dim oDiff As SizeF = modPaint.Trigo(iD, modPaint.AddAngle(Bearing, -90))
                        'oPoint.X = Point.X + oDiff.Width
                        'oPoint.Y = Point.Y + oDiff.Height
                        oPoint.Y += 1
                        If oBounds.Contains(oPoint) Then
                            oColor = oImage.GetPixel(oPoint.X, oPoint.Y)
                            'oImage.SetPixel(oPoint.X, oPoint.Y, Color.Blue)
                            oColor = modPaint.GrayColor(oColor)
                            If Not oBounds.Contains(oPoint) Then
                                iD = 0
                                bBorderFound = True
                                Exit Do
                            End If
                        Else
                            Exit Do
                        End If
                    Loop While (oColor.R >= iColorPivot) And ((Math.Abs(iD) * Scale) < iMaxWidth)
                End If
                If ((Math.Abs(iD) * Scale) >= iMaxWidth) Then
                    iD = 0
                    bBorderFound = True
                    Exit Do
                End If
            Loop Until bBorderFound
            sD = CSng(iD) * Scale
        Catch
            sD = 0
        End Try
        Shot.Down = sD

        bBorderFound = False
        oPoint = New Point(Point.X, Point.Y)
        iD = 0
        sD = 0
        bFirst = True
        'scorro finchè il valore è scuro
        Try
            Do
                Dim iLocalD As Integer = 0
                Do
                    iD -= 1
                    iLocalD -= 1
                    'Dim oDiff As SizeF = modPaint.Trigo(iD, modPaint.AddAngle(Bearing, 90))
                    'oPoint.X = Point.X - oDiff.Width
                    'oPoint.Y = Point.Y - oDiff.Height
                    oPoint.Y -= 1
                    If oBounds.Contains(oPoint) Then
                        oColor = oImage.GetPixel(oPoint.X, oPoint.Y)
                        'oImage.SetPixel(oPoint.X, oPoint.Y, Color.LightGreen)
                        oColor = modPaint.GrayColor(oColor)
                        If Math.Abs(iLocalD) >= iBorderPenWidth Then
                            bBorderFound = True And Not bFirst
                            Exit Do
                        End If
                    Else
                        Exit Do
                    End If
                Loop While oColor.R < iColorPivot And oBounds.Contains(oPoint) And ((Math.Abs(iD) * Scale) < iMaxWidth)
                bFirst = False
                'scorro finchè il valore è chiaro
                If Not bBorderFound Then
                    Do
                        iD -= 1
                        'Dim oDiff As SizeF = modPaint.Trigo(iD, modPaint.AddAngle(Bearing, 90))
                        'oPoint.X = Point.X - oDiff.Width
                        'oPoint.Y = Point.Y - oDiff.Height
                        oPoint.Y -= 1
                        If oBounds.Contains(oPoint) Then
                            oColor = oImage.GetPixel(oPoint.X, oPoint.Y)
                            'oImage.SetPixel(oPoint.X, oPoint.Y, Color.Green)
                            oColor = modPaint.GrayColor(oColor)
                            If Not oBounds.Contains(oPoint) Then
                                iD = 0
                                bBorderFound = True
                                Exit Do
                            End If
                        Else
                            Exit Do
                        End If
                    Loop While (oColor.R >= iColorPivot) And ((Math.Abs(iD) * Scale) < iMaxWidth)
                End If
                If ((Math.Abs(iD) * Scale) >= iMaxWidth) Then
                    iD = 0
                    bBorderFound = True
                    Exit Do
                End If
            Loop Until bBorderFound
            'converto il valore in pixel in valore reale
            sD = CSng(iD) * Scale
        Catch
            sD = 0
        End Try
        Shot.Up = Math.Abs(sD)
    End Sub

    'Private Sub pFillUD(Shot As cResurvey.cShot, Point As PointF, Scale As Single)
    '    Dim iPivot As Integer = 128
    '    Dim iMaxValue As Integer = 200
    '    Dim oImage As Bitmap = picProfile.Image
    '    Dim oPoint As Point
    '    Dim oColor As Color
    '    Dim sD As Single
    '    Dim iD As Integer

    '    oPoint = New Point(Point.X, Point.Y)
    '    iD = 0
    '    sD = 0
    '    'scorro finchè il valore è scuro
    '    Try
    '        Do
    '            iD += 1
    '            oPoint.Y += 1
    '            oColor = oImage.GetPixel(oPoint.X, oPoint.Y)
    '            oColor = modPaint.GrayColor(oColor)
    '        Loop While oColor.R < iPivot Or oPoint.Y > oImage.Height

    '        'scorro finchè il valore è chiaro
    '        Do
    '            iD += 1
    '            oPoint.Y += 1
    '            oColor = oImage.GetPixel(oPoint.X, oPoint.Y)
    '            oColor = modPaint.GrayColor(oColor)
    '            If oPoint.Y > oImage.Height Then
    '                sD = 0
    '                Exit Do
    '            End If
    '        Loop While oColor.R >= iPivot
    '        'converto il valore in pixel in valore reale
    '        sD = CSng(iD) * Scale
    '    Catch
    '        sD = 0
    '    End Try
    '    Shot.Down = sD

    '    oPoint = New Point(Point.X, Point.Y)
    '    iD = 0
    '    sD = 0
    '    'scorro finchè il valore è scuro
    '    Try
    '        Do
    '            iD -= 1
    '            oPoint.Y -= 1
    '            oColor = oImage.GetPixel(oPoint.X, oPoint.Y)
    '            oColor = modPaint.GrayColor(oColor)
    '        Loop While oColor.R < iPivot Or oPoint.Y < 0

    '        'scorro finchè il valore è chiaro
    '        Do
    '            iD -= 1
    '            oPoint.Y -= 1
    '            oColor = oImage.GetPixel(oPoint.X, oPoint.Y)
    '            oColor = modPaint.GrayColor(oColor)
    '            If oPoint.Y < 0 Then
    '                sD = 0
    '                Exit Do
    '            End If
    '        Loop While oColor.R >= iPivot
    '        'converto il valore in pixel in valore reale
    '        sD = CSng(iD) * Scale
    '    Catch
    '        sD = 0
    '    End Try
    '    Shot.Up = Math.Abs(sD)
    'End Sub

    Private Sub btnPopupClose_Click(sender As System.Object, e As System.EventArgs) Handles btnPopupClose.Click
        Call pPopupHide()
    End Sub

    Private Sub pPopupHide()
        Call pnlPopup.Hide()
    End Sub

    Private Sub pPopupShow(ByVal Type As String, ByVal Text As String)
        With pnlPopup
            Dim bShow As Boolean
            Select Case Type.ToLower
                Case "error"
                    picPopupWarning.Image = imlPopup.Images("error")
                    .BackColor = Color.PeachPuff
                    bShow = True
                Case "warning"
                    picPopupWarning.Image = imlPopup.Images("warning")
                    .BackColor = Color.LightYellow
                    bShow = True
            End Select
            If bShow Then
                lblPopupWarning.Text = Text
                .Visible = True
            End If
        End With
    End Sub

    Private Sub pDelayedPerformPaint()
        oPaintThread = New Threading.Thread(AddressOf pPerformPaint)
        oPaintThread.IsBackground = True
        Call oPaintThread.Start()
    End Sub

    Private Sub pPerformPaint()
        Cursor = Cursors.AppStarting
        Try
            'oShots = New List(Of cResurvey.cShot)
            Dim oProcessed As List(Of String) = New List(Of String)

            Dim sStation As String = pGetFirstStation()

            '--------------------------------------------------------------------------
            oPlanStationPath = New GraphicsPath
            oPlanShotsPath = New GraphicsPath
            oProfileStationPath = New GraphicsPath
            oProfileShotsPath = New GraphicsPath

            oPlanScalePath = New GraphicsPath
            oProfileScalePath = New GraphicsPath
            oProfileDropScalePath = New GraphicsPath
            oPlanScaleRealPath = New GraphicsPath
            oProfileScaleRealPath = New GraphicsPath
            oProfileDropScaleRealPath = New GraphicsPath
            '--------------------------------------------------------------------------

            Dim sFirstScalePoint As String = pGetFirstScalePoint()
            Dim sSecondScalePoint As String = pGetSecondScalePoint()

            Try
                If oStations.Count > 0 And sFirstScalePoint <> "" And sSecondScalePoint <> "" Then
                    Dim oScaleBeginPoint As PointF = oStations(sFirstScalePoint).ProfilePoint
                    Dim oScaleEndPoint As PointF = oStations(sSecondScalePoint).ProfilePoint
                    Call oProfileScalePath.StartFigure()
                    Select Case oOptions.PlanScaleType
                        Case cOptions.ScaleTypeEnum.DeltaX
                            Call oProfileScalePath.AddLine(oScaleBeginPoint, oScaleEndPoint)
                            Call oProfileScalePath.AddLine(oScaleEndPoint, New PointF(oScaleEndPoint.X, oScaleBeginPoint.Y))
                            Call oProfileScaleRealPath.AddLine(New PointF(oScaleEndPoint.X, oScaleBeginPoint.Y), oScaleBeginPoint)
                        Case cOptions.ScaleTypeEnum.DeltaY
                            Call oProfileScalePath.AddLine(oScaleBeginPoint, oScaleEndPoint)
                            Call oProfileScaleRealPath.AddLine(oScaleEndPoint, New PointF(oScaleEndPoint.X, oScaleBeginPoint.Y))
                            Call oProfileScalePath.AddLine(New PointF(oScaleEndPoint.X, oScaleBeginPoint.Y), oScaleBeginPoint)
                        Case cOptions.ScaleTypeEnum.Distance
                            Call oProfileScalePath.AddLine(oScaleBeginPoint, oScaleEndPoint)
                            Call oProfileScalePath.AddLine(oScaleEndPoint, New PointF(oScaleEndPoint.X, oScaleBeginPoint.Y))
                            Call oProfileScaleRealPath.AddLine(New PointF(oScaleEndPoint.X, oScaleBeginPoint.Y), oScaleBeginPoint)
                    End Select
                End If
            Catch
            End Try

            Try
                If oStations.Count > 0 And sFirstScalePoint <> "" And sSecondScalePoint <> "" Then
                    Dim oScaleBeginPoint As PointF = oStations(sFirstScalePoint).PlanPoint
                    Dim oScaleEndPoint As PointF = oStations(sSecondScalePoint).PlanPoint
                    Call oPlanScalePath.StartFigure()
                    Select Case oOptions.PlanScaleType
                        Case cOptions.ScaleTypeEnum.DeltaX
                            Call oPlanScalePath.AddLine(oScaleBeginPoint, oScaleEndPoint)
                            Call oPlanScalePath.AddLine(oScaleEndPoint, New PointF(oScaleEndPoint.X, oScaleBeginPoint.Y))
                            Call oPlanScaleRealPath.AddLine(New PointF(oScaleEndPoint.X, oScaleBeginPoint.Y), oScaleBeginPoint)
                        Case cOptions.ScaleTypeEnum.DeltaY
                            Call oPlanScalePath.AddLine(oScaleBeginPoint, oScaleEndPoint)
                            Call oPlanScaleRealPath.AddLine(oScaleEndPoint, New PointF(oScaleEndPoint.X, oScaleBeginPoint.Y))
                            Call oPlanScalePath.AddLine(New PointF(oScaleEndPoint.X, oScaleBeginPoint.Y), oScaleBeginPoint)
                        Case cOptions.ScaleTypeEnum.Distance
                            Call oPlanScaleRealPath.AddLine(oScaleBeginPoint, oScaleEndPoint)
                            Call oPlanScalePath.AddLine(oScaleEndPoint, New PointF(oScaleEndPoint.X, oScaleBeginPoint.Y))
                            Call oPlanScalePath.AddLine(New PointF(oScaleEndPoint.X, oScaleBeginPoint.Y), oScaleBeginPoint)
                    End Select
                End If
            Catch
            End Try

            '--------------------------------------------------------------------------
            oProfileDropScalePath = New GraphicsPath
            '--------------------------------------------------------------------------

            Dim sFirstDropScalePoint As String = pGetFirstDropScalePoint()
            Dim sSecondDropScalePoint As String = pGetSecondDropScalePoint()

            Try
                If oStations.Count > 0 And sFirstDropScalePoint <> "" And sSecondDropScalePoint <> "" Then
                    Dim oDropScaleBeginPoint As PointF = oStations(sFirstDropScalePoint).ProfilePoint
                    Dim oDropScaleEndPoint As PointF = oStations(sSecondDropScalePoint).ProfilePoint
                    Call oProfileDropScalePath.StartFigure()
                    Select Case oOptions.DropScaleType
                        Case cOptions.ScaleTypeEnum.DeltaX
                            Call oProfileDropScalePath.AddLine(oDropScaleBeginPoint, oDropScaleEndPoint)
                            Call oProfileDropScalePath.AddLine(oDropScaleEndPoint, New PointF(oDropScaleEndPoint.X, oDropScaleBeginPoint.Y))
                            Call oProfileDropScaleRealPath.AddLine(New PointF(oDropScaleEndPoint.X, oDropScaleBeginPoint.Y), oDropScaleBeginPoint)
                        Case cOptions.ScaleTypeEnum.DeltaY
                            Call oProfileDropScalePath.AddLine(oDropScaleBeginPoint, oDropScaleEndPoint)
                            Call oProfileDropScaleRealPath.AddLine(oDropScaleEndPoint, New PointF(oDropScaleEndPoint.X, oDropScaleBeginPoint.Y))
                            Call oProfileDropScalePath.AddLine(New PointF(oDropScaleEndPoint.X, oDropScaleBeginPoint.Y), oDropScaleBeginPoint)
                        Case cOptions.ScaleTypeEnum.Distance
                            Call oProfileDropScaleRealPath.AddLine(oDropScaleBeginPoint, oDropScaleEndPoint)
                            Call oProfileDropScalePath.AddLine(oDropScaleEndPoint, New PointF(oDropScaleEndPoint.X, oDropScaleBeginPoint.Y))
                            Call oProfileDropScalePath.AddLine(New PointF(oDropScaleEndPoint.X, oDropScaleBeginPoint.Y), oDropScaleBeginPoint)
                    End Select

                    'If oDropScaleBeginPoint.X < oDropScaleEndPoint.X Then
                    '    Call oProfileDropScalePath.AddLine(oDropScaleBeginPoint, New PointF(oDropScaleBeginPoint.X, oDropScaleEndPoint.Y))
                    '    Call oProfileDropScalePath.AddLine(New PointF(oDropScaleBeginPoint.X, oDropScaleEndPoint.Y), oDropScaleEndPoint)
                    'ElseIf oDropScaleBeginPoint.X > oDropScaleEndPoint.X Then
                    '    Call oProfileDropScalePath.AddLine(oDropScaleBeginPoint, New PointF(oDropScaleEndPoint.X, oDropScaleBeginPoint.Y))
                    '    Call oProfileDropScalePath.AddLine(New PointF(oDropScaleEndPoint.X, oDropScaleBeginPoint.Y), oDropScaleEndPoint)
                    'Else
                    '    Call oProfileDropScalePath.AddLine(oDropScaleBeginPoint, oDropScaleEndPoint)
                    'End If
                End If
            Catch
            End Try

            '--------------------------------------------------------------------------
            For Each oStation As cResurvey.cStation In oStations.Values
                If oStation.Type <> "SB" And oStation.Type <> "SE" And oStation.Type <> "DSB" And oStation.Type <> "DSE" Then
                    If Not oStation.PlanPoint.IsEmpty Then
                        Dim oPoint As Point = oStation.PlanPoint
                        Call oPlanStationPath.StartFigure()
                        Call oPlanStationPath.AddLine(oPoint.X - 4, oPoint.Y, oPoint.X, oPoint.Y)
                        Call oPlanStationPath.AddLine(oPoint.X + 4, oPoint.Y, oPoint.X, oPoint.Y)
                        Call oPlanStationPath.AddLine(oPoint.X, oPoint.Y - 4, oPoint.X, oPoint.Y)
                        Call oPlanStationPath.AddLine(oPoint.X, oPoint.Y + 4, oPoint.X, oPoint.Y)
                    End If
                    If Not oStation.ProfilePoint.IsEmpty Then
                        Dim oPoint As Point = oStation.ProfilePoint
                        Call oProfileStationPath.StartFigure()
                        Call oProfileStationPath.AddLine(oPoint.X - 4, oPoint.Y, oPoint.X, oPoint.Y)
                        Call oProfileStationPath.AddLine(oPoint.X + 4, oPoint.Y, oPoint.X, oPoint.Y)
                        Call oProfileStationPath.AddLine(oPoint.X, oPoint.Y - 4, oPoint.X, oPoint.Y)
                        Call oProfileStationPath.AddLine(oPoint.X, oPoint.Y + 4, oPoint.X, oPoint.Y)
                    End If
                End If
            Next

            Call oProcessed.Clear()
            Call pPaintShots(0, oProcessed, sStation)

            Call oProcessed.Clear()
            Call pPaintShots(1, oProcessed, sStation)
        Catch
        End Try

        Call pInvalidateCurrentView()

        Cursor = Cursors.Default
    End Sub

    Private Sub pSettingsLoad()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
                iDefaultCalculateMode = oReg.GetValue("resurvey.options.calculatemode", cResurvey.cOptions.CalculateModeEnum.Full)
                btnShowRulers.Checked = oReg.GetValue("resurvey.options.showrulers", 0)
                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Private Sub pSettingsSave()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
                Call oReg.SetValue("resurvey.options.calculatemode", Convert.ToInt32(iDefaultCalculateMode))
                Call oReg.SetValue("resurvey.options.showrulers", If(btnShowRulers.Checked, 1, 0))
                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Private Sub pNew()
        Cursor = Cursors.WaitCursor

        oOptions.CalculateMode = iDefaultCalculateMode
        oOptions.NordCorrection = 0

        Call pSetCalculateMode()

        sPlanImage = ""
        sProfileImage = ""
        picPlan.Image = Nothing
        picPlan.Visible = False
        picProfile.Image = Nothing
        picProfile.Visible = False

        Call pBindScrollbars()

        Call oPlanTrigpointsPlaceholders.Clear()
        Call oProfileTrigpointsPlaceholders.Clear()

        Call oShots.Clear()

        Call oStations.Clear()

        Call grdStations.Rows.Clear()
        Call grdPlot.Rows.Clear()

        sFilename = ""
        Text = "cResurvey"
        Cursor = Cursors.Default
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Call pNew()
    End Sub

    Private Sub mnuPreviewHide_Click(sender As System.Object, e As System.EventArgs) Handles mnuPreviewHide.Click
        oLastPlaceHolder.Visible = False
        Call pDelayedPerformPaint()
    End Sub

    Private Sub mnuPreviewShowHidden_Click(sender As System.Object, e As System.EventArgs) Handles mnuPreviewShowHidden.Click
        If pGetCurrentProjection() = 0 Then
            Call pShowHiddenTrigPoints(0)
        Else
            Call pShowHiddenTrigPoints(1)
        End If
    End Sub

    Private Sub picPlan_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles picPlan.Paint
        Try
            Dim oGraphics As Graphics = e.Graphics
            oGraphics.SmoothingMode = SmoothingMode.AntiAlias
            oGraphics.CompositingQuality = CompositingQuality.HighQuality
            oGraphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

            Call oGraphics.ScaleTransform(sPlanZoom, sPlanZoom)

            If Not oPlanScalePath Is Nothing Then
                Using oScalePen As Pen = New Pen(Color.FromArgb(200, Color.Orange), 2)
                    oScalePen.StartCap = LineCap.Round
                    oScalePen.EndCap = LineCap.Round
                    Call oGraphics.DrawPath(oScalePen, oPlanScalePath)
                End Using
            End If

            Using oStationPen As Pen = New Pen(Color.FromArgb(200, Color.Red))
                Call oGraphics.DrawPath(oStationPen, oPlanStationPath)
            End Using

            Using oShotsPen As Pen = New Pen(Color.FromArgb(220, Color.Coral))
                oShotsPen.EndCap = LineCap.ArrowAnchor
                Call oGraphics.DrawPath(oShotsPen, oPlanShotsPath)
            End Using

            Using oSF As StringFormat = New StringFormat(Drawing.StringFormatFlags.NoWrap)
                oSF.Alignment = StringAlignment.Center
                oSF.LineAlignment = StringAlignment.Center
                For Each oTPH As cResurvey.cTrigpointPlaceholder In oPlanTrigpointsPlaceholders.Values
                    If oTPH.Visible Then
                        Dim oProfileTPH As cTrigpointPlaceholder = If(oProfileTrigpointsPlaceholders.ContainsKey(pGetRealStation(oTPH.Name)), oProfileTrigpointsPlaceholders(pGetRealStation(oTPH.Name)), Nothing)
                        Dim oStation As cStation = If(oStations.ContainsKey(oTPH.Name), oStations(oTPH.Name), Nothing)

                        Dim oNameSize As SizeF = oGraphics.MeasureString(oTPH.Name, Font)

                        Using oPath As GraphicsPath = New GraphicsPath
                            Call oPath.AddLine(oTPH.Area.Left, oTPH.Area.Top, oTPH.Area.Left, oTPH.Area.Top + oTPH.Area.Height \ 2)
                            Call oPath.AddArc(oTPH.Area, 180, -90)
                            Call oPath.AddLine(oTPH.Area.Left + oTPH.Area.Width \ 2, oTPH.Area.Bottom, oTPH.Area.Left + oTPH.Area.Width \ 2 + oNameSize.Width, oTPH.Area.Bottom)

                            Call oPath.AddArc(oTPH.Area.Left + oNameSize.Width, oTPH.Area.Top, oTPH.Area.Width, oTPH.Area.Height, 90, -180)
                            Call oPath.AddLine(oTPH.Area.Left + oNameSize.Width, oTPH.Area.Top, oTPH.Area.Left + oTPH.Area.Width \ 2, oTPH.Area.Top)
                            Call oPath.AddLine(oTPH.Area.Left + oTPH.Area.Width \ 2, oTPH.Area.Top, oTPH.Area.Left, oTPH.Area.Top)

                            Using oPlaceholderSelectedPen As Pen = New Pen(Color.FromArgb(210, oTPH.BackColor), 2)
                                Using oPlaceholderSelectedbrush As Brush = New SolidBrush(Color.FromArgb(210, oTPH.BackColor))
                                    Using oPlaceholderPen As Pen = New Pen(Color.FromArgb(140, oTPH.BackColor), 1)
                                        Using oPlaceholderbrush As Brush = New SolidBrush(Color.FromArgb(140, oTPH.BackColor))
                                            If oTPH Is oLastPlaceHolder Then
                                                Call oGraphics.FillPath(oPlaceholderSelectedbrush, oPath)
                                                Call oGraphics.DrawPath(oPlaceholderSelectedPen, oPath)
                                                Call oGraphics.DrawString(oTPH.Name, Font, Brushes.White, oTPH.HotSpot, oSF)

                                                'check connected stations and if there are planimetric distance draw line for each stations
                                                If Not IsNothing(oProfileTPH) AndAlso btnShowRulers.Checked Then
                                                    Dim oScale As cScale = pGetScale()
                                                    If Not (oScale.PlanError OrElse oScale.ProfileError) Then
                                                        Dim iIndex As Integer = 0
                                                        Dim oConnectedTPHs As List(Of cTrigpointPlaceholder) = New List(Of cTrigpointPlaceholder)
                                                        Call oConnectedTPHs.AddRange(oProfileTrigpointsPlaceholders.Where(Function(item) cResurvey.cStation.GetConnectedToCollection(oStation.ProfileConnectedTo).Contains(item.Key)).Select(Function(item) item.Value))
                                                        Call oConnectedTPHs.AddRange(oProfileTrigpointsPlaceholders.Where(Function(item) cResurvey.cStation.GetConnectedToCollection(oStations(item.Key).ProfileConnectedTo).Contains(oStation.Name)).Select(Function(item) item.Value))
                                                        For Each oConnectedTPH As cTrigpointPlaceholder In    oConnectedTPHs.Distinct.ToList
                                                            iIndex -= 10
                                                            'If oProfileTrigpointsPlaceholders.ContainsKey(oConnectedTPH.Name) Then
                                                            Dim oConnectedProfileTPH As cTrigpointPlaceholder = oProfileTrigpointsPlaceholders(oConnectedTPH.Name)
                                                            Dim sDistance As Single = Math.Abs(oProfileTPH.Point.X - oConnectedProfileTPH.Point.X)
                                                            sDistance = sDistance * oScale.ProfileScale / oScale.PlanScale
                                                            Dim sText As String = oConnectedTPH.Name '& " - " & Strings.Format(modNumbers.MathRound(sDistance * oScale.ProfileScale, 2), "0.00") & " m"
                                                            Dim oLabelSize As SizeF = oGraphics.MeasureString(sText, Font, 64, oSF)
                                                            oLabelSize.Width += 2
                                                            oLabelSize.Height += 2
                                                            Using oRotateMatrix As Matrix = New Matrix
                                                                Call oRotateMatrix.RotateAt(iIndex, oTPH.Point)
                                                                oGraphics.Transform = oRotateMatrix
                                                                Call oGraphics.DrawEllipse(oRulesPen, New RectangleF(oTPH.Point.X - sDistance, oTPH.Point.Y - sDistance, sDistance * 2, sDistance * 2))
                                                                Dim oLabelBox As Rectangle = New Rectangle(oTPH.Point.X + sDistance - oLabelSize.Width / 2, oTPH.Point.Y - oLabelSize.Height / 2, oLabelSize.Width, oLabelSize.Height)
                                                                Call oGraphics.FillRectangle(oRulesLabelBrush, oLabelBox)
                                                                Call oGraphics.DrawRectangle(oRulesLabelPen, oLabelBox)
                                                                Call oGraphics.DrawString(sText, Font, oRulesBrush, oLabelBox, oSF) 'New Rectangle(oTPH.Point.X + sDistance - oLabelSize.Width / 2 + 1, oTPH.Point.Y - oLabelSize.Height / 2 + 1, oLabelSize.Width, oLabelSize.Height), oSF)
                                                                Call oGraphics.ResetTransform()
                                                            End Using
                                                        Next
                                                    End If
                                                End If
                                            Else
                                                Call oGraphics.FillPath(oPlaceholderbrush, oPath)
                                                Call oGraphics.DrawPath(oPlaceholderPen, oPath)
                                                Call oGraphics.DrawString(oTPH.Name, Font, Brushes.White, oTPH.HotSpot, oSF)
                                            End If
                                        End Using
                                    End Using
                                End Using
                            End Using
                        End Using
                    End If
                Next
            End Using

            If btnShowRulers.Checked AndAlso Not oLastPlaceHolder Is Nothing Then
                Call oGraphics.DrawLine(oRulesSecondaryPen, New Point(oGraphics.VisibleClipBounds.Left, oLastPlaceHolder.Point.Y), New Point(oGraphics.VisibleClipBounds.Right, oLastPlaceHolder.Point.Y))
                Call oGraphics.DrawLine(oRulesSecondaryPen, New Point(oLastPlaceHolder.Point.X, oGraphics.VisibleClipBounds.Top), New Point(oLastPlaceHolder.Point.X, oGraphics.VisibleClipBounds.Bottom))
            End If

            If Not oLastLine Is Nothing Then
                Using oSelectedShotsPen As Pen = New Pen(Color.FromArgb(220, Color.Coral), 3)
                    oSelectedShotsPen.EndCap = LineCap.ArrowAnchor
                    Call oGraphics.DrawLine(oSelectedShotsPen, oLastLine(0).Point, oLastLine(1).Point)
                End Using
            End If
        Catch
        End Try
    End Sub

    Private Sub picProfile_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles picProfile.Paint
        Try
            Dim oGraphics As Graphics = e.Graphics
            oGraphics.SmoothingMode = SmoothingMode.AntiAlias
            oGraphics.CompositingQuality = CompositingQuality.HighQuality
            oGraphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

            Call oGraphics.ScaleTransform(sProfileZoom, sProfileZoom)

            If Not oProfileScalePath Is Nothing Then
                Using oScalePen As Pen = New Pen(Color.FromArgb(200, Color.Orange), 2)
                    oScalePen.StartCap = LineCap.Round
                    oScalePen.EndCap = LineCap.Round
                    Call oGraphics.DrawPath(oScalePen, oProfileScalePath)
                End Using
            End If

            If Not oProfileDropScalePath Is Nothing Then
                Using oDropScalePen As Pen = New Pen(Color.FromArgb(120, Color.OrangeRed), 1)
                    oDropScalePen.StartCap = LineCap.Round
                    oDropScalePen.EndCap = LineCap.Round
                    Call oGraphics.DrawPath(oDropScalePen, oProfileDropScalePath)
                End Using
            End If
            If Not oProfileDropScaleRealPath Is Nothing Then
                Using oDropScaleRealPen As Pen = New Pen(Color.FromArgb(200, Color.OrangeRed), 2)
                    oDropScaleRealPen.StartCap = LineCap.ArrowAnchor
                    oDropScaleRealPen.EndCap = LineCap.ArrowAnchor
                    Call oGraphics.DrawPath(oDropScaleRealPen, oProfileDropScaleRealPath)
                End Using
            End If

            Using oStationPen As Pen = New Pen(Color.FromArgb(200, Color.Red))
                Call oGraphics.DrawPath(oStationPen, oProfileStationPath)
            End Using

            Using oShotsPen As Pen = New Pen(Color.FromArgb(220, Color.Coral))
                Call oGraphics.DrawPath(oShotsPen, oProfileShotsPath)
            End Using

            Using oSF As StringFormat = New StringFormat(Drawing.StringFormatFlags.NoWrap)
                oSF.Alignment = StringAlignment.Center
                oSF.LineAlignment = StringAlignment.Center
                For Each oTPH As cResurvey.cTrigpointPlaceholder In oProfileTrigpointsPlaceholders.Values
                    If oTPH.Visible Then
                        Dim oPlanTPH As cTrigpointPlaceholder = If(oPlanTrigpointsPlaceholders.ContainsKey(oTPH.Name), oPlanTrigpointsPlaceholders(oTPH.Name), Nothing)
                        Dim oStation As cStation = If(oStations.ContainsKey(oTPH.Name), oStations(oTPH.Name), Nothing)
                        Dim oNameSize As SizeF = oGraphics.MeasureString(oTPH.Name, Font)
                        Using oPath As GraphicsPath = New GraphicsPath
                            Call oPath.AddLine(oTPH.Area.Left, oTPH.Area.Top, oTPH.Area.Left, oTPH.Area.Top + oTPH.Area.Height \ 2)
                            Call oPath.AddArc(oTPH.Area, 180, -90)
                            Call oPath.AddLine(oTPH.Area.Left + oTPH.Area.Width \ 2, oTPH.Area.Bottom, oTPH.Area.Left + oTPH.Area.Width \ 2 + oNameSize.Width, oTPH.Area.Bottom)

                            Call oPath.AddArc(oTPH.Area.Left + oNameSize.Width, oTPH.Area.Top, oTPH.Area.Width, oTPH.Area.Height, 90, -180)
                            Call oPath.AddLine(oTPH.Area.Left + oNameSize.Width, oTPH.Area.Top, oTPH.Area.Left + oTPH.Area.Width \ 2, oTPH.Area.Top)
                            Call oPath.AddLine(oTPH.Area.Left + oTPH.Area.Width \ 2, oTPH.Area.Top, oTPH.Area.Left, oTPH.Area.Top)

                            Using oPlaceholderSelectedPen As Pen = New Pen(Color.FromArgb(210, oTPH.BackColor), 2)
                                Using oPlaceholderSelectedbrush As Brush = New SolidBrush(Color.FromArgb(210, oTPH.BackColor))
                                    Using oPlaceholderPen As Pen = New Pen(Color.FromArgb(140, oTPH.BackColor), 1)
                                        Using oPlaceholderbrush As Brush = New SolidBrush(Color.FromArgb(140, oTPH.BackColor))
                                            If oTPH Is oLastPlaceHolder Then
                                                Call oGraphics.FillPath(oPlaceholderSelectedbrush, oPath)
                                                Call oGraphics.DrawPath(oPlaceholderSelectedPen, oPath)
                                                Call oGraphics.DrawString(oTPH.Name, Font, Brushes.White, oTPH.HotSpot, oSF)

                                                'check connected stations and if there are planimetric distance draw line for each stations
                                                If Not IsNothing(oPlanTPH) AndAlso btnShowRulers.Checked Then
                                                    Dim oScale As cScale = pGetScale()
                                                    If Not (oScale.PlanError OrElse oScale.ProfileError) Then
                                                        Dim iIndex As Integer = 0
                                                        Dim oConnectedTPHs As List(Of cTrigpointPlaceholder) = New List(Of cTrigpointPlaceholder)
                                                        Call oConnectedTPHs.AddRange(oPlanTrigpointsPlaceholders.Where(Function(item) cResurvey.cStation.GetConnectedToCollection(oStation.PlanConnectedTo).Contains(item.Key)).Select(Function(item) item.Value))
                                                        Call oConnectedTPHs.AddRange(oPlanTrigpointsPlaceholders.Where(Function(item) cResurvey.cStation.GetConnectedToCollection(oStations(item.Key).PlanConnectedTo).Contains(oStation.Name)).Select(Function(item) item.Value))
                                                        For Each oConnectedTPH As cTrigpointPlaceholder In oConnectedTPHs.Distinct.ToList
                                                            iIndex += 16
                                                            Dim oConnectedPlanTPH As cTrigpointPlaceholder = oPlanTrigpointsPlaceholders(oConnectedTPH.Name)
                                                            Dim sDistance As Single = modPaint.DistancePointToPoint(oPlanTPH.Point, oConnectedPlanTPH.Point)
                                                            sDistance = sDistance * oScale.PlanScale / oScale.ProfileScale
                                                            Dim sText As String = oConnectedTPH.Name '& " - " & Strings.Format(modNumbers.MathRound(sDistance * oScale.ProfileScale, 2), "0.00") & " m"
                                                            Dim oLabelSize As SizeF = oGraphics.MeasureString(sText, Font, 64, oSF)
                                                            oLabelSize.Width += 2
                                                            oLabelSize.Height += 2

                                                            Call oGraphics.DrawLine(oRulesPen, New Point(oTPH.Point.X + sDistance, oGraphics.VisibleClipBounds.Bottom), New Point(oTPH.Point.X + sDistance, oGraphics.VisibleClipBounds.Top))
                                                            Dim oLabelBox As Rectangle = New Rectangle(oTPH.Point.X + sDistance - oLabelSize.Width / 2, oTPH.Point.Y - oLabelSize.Height / 2 + iIndex, oLabelSize.Width, oLabelSize.Height)
                                                            Call oGraphics.FillRectangle(oRulesLabelBrush, oLabelBox)
                                                            Call oGraphics.DrawRectangle(oRulesLabelPen, oLabelBox)                                                            'Call oGraphics.FillEllipse(oRulesFillBrush, New Rectangle(oTPH.Point.X + sDistance - sSize / 2, oTPH.Point.Y - sSize / 2 - sSize * iindex, sSize, sSize))
                                                            Call oGraphics.DrawString(sText, Font, oRulesBrush, oLabelBox, oSF) ' New Rectangle(oTPH.Point.X + sDistance - oLabelSize.Width / 2, oTPH.Point.Y - oLabelSize.Height / 2, oLabelSize.Width, oLabelSize.Height), oSF)

                                                            Call oGraphics.DrawLine(oRulesPen, New Point(oTPH.Point.X - sDistance, oGraphics.VisibleClipBounds.Bottom), New Point(oTPH.Point.X - sDistance, oGraphics.VisibleClipBounds.Top))
                                                            oLabelBox = New Rectangle(oTPH.Point.X - sDistance - oLabelSize.Width / 2, oTPH.Point.Y - oLabelSize.Height / 2 - iIndex, oLabelSize.Width, oLabelSize.Height)
                                                            Call oGraphics.FillRectangle(oRulesLabelBrush, oLabelBox)
                                                            Call oGraphics.DrawRectangle(oRulesLabelPen, oLabelBox)                                                            'Call oGraphics.FillEllipse(oRulesFillBrush, New Rectangle(oTPH.Point.X + sDistance - sSize / 2, oTPH.Point.Y - sSize / 2 - sSize * iindex, sSize, sSize))
                                                            Call oGraphics.DrawString(sText, Font, oRulesBrush, oLabelBox, oSF) ' New Rectangle(oTPH.Point.X - sDistance - oLabelSize.Width / 2 + 1, oTPH.Point.Y - oLabelSize.Height / 2 + 1, oLabelSize.Width, oLabelSize.Height), oSF)
                                                        Next
                                                    End If
                                                End If
                                            Else
                                                Call oGraphics.FillPath(oPlaceholderbrush, oPath)
                                                Call oGraphics.DrawPath(oPlaceholderPen, oPath)
                                                Call oGraphics.DrawString(oTPH.Name, Font, Brushes.White, oTPH.HotSpot, oSF)
                                            End If
                                        End Using
                                    End Using
                                End Using
                            End Using
                        End Using
                    End If
                Next
            End Using

            If btnShowRulers.Checked AndAlso Not oLastPlaceHolder Is Nothing Then
                Call oGraphics.DrawLine(oRulesSecondaryPen, New Point(oGraphics.VisibleClipBounds.Left, oLastPlaceHolder.Point.Y), New Point(oGraphics.VisibleClipBounds.Right, oLastPlaceHolder.Point.Y))
                Call oGraphics.DrawLine(oRulesSecondaryPen, New Point(oLastPlaceHolder.Point.X, oGraphics.VisibleClipBounds.Top), New Point(oLastPlaceHolder.Point.X, oGraphics.VisibleClipBounds.Bottom))
            End If

            If Not oLastLine Is Nothing Then
                Using oSelectedShotsPen As Pen = New Pen(Color.FromArgb(220, Color.Coral), 3)
                    oSelectedShotsPen.EndCap = LineCap.ArrowAnchor
                    Call oGraphics.DrawLine(oSelectedShotsPen, oLastLine(0).Point, oLastLine(1).Point)
                End Using
            End If
        Catch
        End Try
    End Sub

    Private Sub mnuPreviewHideAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuPreviewHideAll.Click
        If pGetCurrentProjection() = 0 Then
            Call pHideTrigPoints(0)
        Else
            Call pHideTrigPoints(1)
        End If
    End Sub

    Private Sub btnSaveResults_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        Dim oSFD As SaveFileDialog = New SaveFileDialog
        With oSFD
            If sFilename <> "" Then
                .FileName = Path.Combine(Path.GetDirectoryName(sFilename), Path.GetFileNameWithoutExtension(sFilename))
            End If
            '.Filter = GetLocalizedString("resurvey.filetypeCSX") & " (*.CSX)|*.CSX|" & GetLocalizedString("resurvey.filetypeCSV") & " (*.CSV)|*.CSV|" & GetLocalizedString("resurvey.filetypeTXT") & " (*.TXT)|*.TXT"
            .Filter = GetLocalizedString("resurvey.filetypeCSV") & " (*.CSV)|*.CSV|" & GetLocalizedString("resurvey.filetypeTXT") & " (*.TXT)|*.TXT"
            .FilterIndex = 1
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                sFilename = .FileName
                Select Case Path.GetExtension(sFilename).ToLower
                    Case ".txt"
                        Dim fi As FileInfo = New FileInfo(sFilename)
                        Dim oSw As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(sFilename, False)
                        For Each oShot As cResurvey.cShot In oShots
                            Call oSw.Write(oShot.From & vbTab)
                            Call oSw.Write(oShot.[To] & vbTab)
                            Call oSw.Write(modNumbers.NumberToString(oShot.Distance, "0.00") & vbTab)
                            Call oSw.Write(modNumbers.NumberToString(oShot.[Bearing], "0.0") & vbTab)
                            Call oSw.Write(modNumbers.NumberToString(oShot.[Inclination], "0.0"))
                            Call oSw.WriteLine()
                        Next
                        Call oSw.Close()
                        Call oSw.Dispose()
                        oSw = Nothing
                        Call GC.Collect()
                    Case ".csv"
                        Dim fi As FileInfo = New FileInfo(sFilename)
                        Dim oSw As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(sFilename, False)
                        For Each oShot As cResurvey.cShot In oShots
                            Call oSw.Write(Chr(34) & oShot.From & Chr(34) & ";")
                            Call oSw.Write(Chr(34) & oShot.[To] & Chr(34) & ";")
                            Call oSw.Write(Chr(34) & modNumbers.NumberToString(oShot.Distance, "0.00") & Chr(34) & ";")
                            Call oSw.Write(Chr(34) & modNumbers.NumberToString(oShot.[Bearing], "0.0") & Chr(34) & ";")
                            Call oSw.Write(Chr(34) & modNumbers.NumberToString(oShot.[Inclination], "0.0") & Chr(34))
                            Call oSw.WriteLine()
                        Next
                        Call oSw.Close()
                        Call oSw.Dispose()
                        oSw = Nothing
                        Call GC.Collect()
                        'Case ".csx"
                        '    Dim oXML As XmlDocument = New XmlDocument
                        '    Dim oXMLRoot As XmlElement = oXML.CreateElement("csurvey")
                        '    Call oXMLRoot.SetAttribute("version", "1.02")
                        '    Call oXMLRoot.SetAttribute("id", Guid.NewGuid.ToString)
                        '    Dim oXMLSegments As XmlElement = oXML.CreateElement("segments")
                        '    For Each oShot As cResurvey.cShot In oShots
                        '        Dim oXMLSegment As XmlElement = oXML.CreateElement("segment")
                        '        Call oXMLSegment.SetAttribute("id", Guid.NewGuid.ToString)
                        '        Call oXMLSegment.SetAttribute("from", oShot.[From])
                        '        Call oXMLSegment.SetAttribute("to", oShot.[To])
                        '        Call oXMLSegment.SetAttribute("distance", modNumbers.NumberToString(oShot.Distance, "0.00"))
                        '        Call oXMLSegment.SetAttribute("bearing", modNumbers.NumberToString(oShot.[Bearing], "0.0"))
                        '        Call oXMLSegment.SetAttribute("inclination", modNumbers.NumberToString(oShot.[Inclination], "0.0"))
                        '        Call oXMLSegment.SetAttribute("l", "0")
                        '        Call oXMLSegment.SetAttribute("r", "0")
                        '        Call oXMLSegment.SetAttribute("u", "0")
                        '        Call oXMLSegment.SetAttribute("d", "0")
                        '        Call oXMLSegment.SetAttribute("direction", "0")
                        '        Call oXMLSegment.SetAttribute("cave", "")
                        '        Call oXMLSegment.SetAttribute("session", "")
                        '        Call oXMLSegments.AppendChild(oXMLSegment)
                        '    Next
                        '    Call oXMLRoot.AppendChild(oXMLSegments)

                        '    Dim oXmlProperties As XmlElement = oXML.CreateElement("properties")
                        '    Call oXmlProperties.SetAttribute("id", "")
                        '    Call oXmlProperties.SetAttribute("name", Path.GetFileNameWithoutExtension(sFilename))
                        '    Call oXmlProperties.SetAttribute("description", "")
                        '    Call oXmlProperties.SetAttribute("club", "")
                        '    Call oXmlProperties.SetAttribute("team", "")
                        '    Call oXmlProperties.SetAttribute("author", "")
                        '    Call oXmlProperties.SetAttribute("designer", "")
                        '    Call oXmlProperties.SetAttribute("note", "")
                        '    Call oXmlProperties.SetAttribute("origin", pGetFirstStation)
                        '    Call oXMLRoot.AppendChild(oXmlProperties)

                        '    Call oXML.AppendChild(oXMLRoot)
                        '    Call oXML.Save(sFilename)
                        '    oXML = Nothing
                End Select
            End If
        End With
    End Sub

    Private Sub mnuPreview_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles mnuPreview.Opening
        Dim oColl As Dictionary(Of String, cResurvey.cTrigpointPlaceholder)
        If pGetCurrentProjection() = 0 Then
            oColl = oPlanTrigpointsPlaceholders
        Else
            oColl = oProfileTrigpointsPlaceholders
        End If
        If oLastPlaceHolder Is Nothing Then
            mnuPreviewRemove.Enabled = False
            mnuPreviewRemoveAll.Enabled = oColl.Count > 0
            mnuPreviewDelete.Enabled = False
            mnuPreviewDeleteAll.Enabled = oStations.Count > 0

            mnuPreviewSetOrigin.Enabled = False
            mnuPreviewProperties.Enabled = False
        Else
            Dim sType As String = ""
            Try : sType = oStations(oLastPlaceHolder.Name).Type : Catch : End Try

            mnuPreviewRemove.Enabled = (Not oLastPlaceHolder Is Nothing) And (sType <> "SB" And sType <> "SE")
            mnuPreviewRemoveAll.Enabled = oColl.Count > 0
            mnuPreviewDelete.Enabled = (Not oLastPlaceHolder Is Nothing)
            mnuPreviewDeleteAll.Enabled = oStations.Count > 0

            mnuPreviewSetOrigin.Enabled = sType = ""
            mnuPreviewProperties.Enabled = True
        End If
        If oLastLine Is Nothing Then
            mnuPreviewDeleteLink.Enabled = False
        Else
            mnuPreviewDeleteLink.Enabled = True
        End If
    End Sub

    Private Sub frmResurveyMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call pSettingsSave()
    End Sub

    Private Sub frmResurveyMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control Then
            If pGetCurrentProjection() = 0 Then
                picPlan.Cursor = oOpenHandCursor
            Else
                picProfile.Cursor = oOpenHandCursor
            End If
        Else
            If pGetCurrentProjection() = 0 Then
                picPlan.Cursor = Cursors.Cross
            Else
                picProfile.Cursor = Cursors.Cross
            End If
        End If
    End Sub

    Private Sub frmResurveyMain_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If pGetCurrentProjection() = 0 Then
            picPlan.Cursor = Cursors.Cross
        Else
            picProfile.Cursor = Cursors.Cross
        End If
    End Sub

    Private Sub frmResurveyMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Call pSettingsLoad()
        Call pNew()
    End Sub

    Private Sub mnuPreviewDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuPreviewDelete.Click
        Call pStationDelete()
    End Sub

    Private Sub pInvalidateCurrentView(Optional All As Boolean = False)
        If All Then
            Call picPlan.Invalidate()
            Call picProfile.Invalidate()
        Else
            If pGetCurrentProjection() = 0 Then
                Call picPlan.Invalidate()
            Else
                Call picProfile.Invalidate()
            End If
        End If
    End Sub

    Private Sub pStationDelete()
        If MsgBox(GetLocalizedString("resurvey.warning5"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("resurvey.warningtitle")) = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim sTrigpoint As String
            If oLastPlaceHolder Is Nothing Then
                sTrigpoint = grdStations.CurrentRow.Cells(1).Value
            Else
                sTrigpoint = oLastPlaceHolder.Name
            End If

            Dim oStation As cResurvey.cStation = oStations(sTrigpoint)
            Call grdStations.Rows.Remove(oStation.Row)

            If oPlanTrigpointsPlaceholders.ContainsKey(sTrigpoint) Then Call oPlanTrigpointsPlaceholders.Remove(sTrigpoint)
            If oProfileTrigpointsPlaceholders.ContainsKey(sTrigpoint) Then Call oProfileTrigpointsPlaceholders.Remove(sTrigpoint)

            For Each oOtherStation As cResurvey.cStation In oStations.Values
                Dim oColl As List(Of String) = cResurvey.cStation.GetConnectedToCollection(oOtherStation.PlanConnectedTo)
                If oColl.Contains(sTrigpoint) Then
                    Call oColl.Remove(sTrigpoint)
                    oOtherStation.PlanConnectedTo = cResurvey.cStation.SetConnectedToFromCollection(oColl)
                    oOtherStation.Row.Cells(4).Value = oOtherStation.PlanConnectedTo
                End If
            Next
            For Each oOtherStation As cResurvey.cStation In oStations.Values
                Dim oColl As List(Of String) = cResurvey.cStation.GetConnectedToCollection(oOtherStation.ProfileConnectedTo)
                If oColl.Contains(sTrigpoint) Then
                    Call oColl.Remove(sTrigpoint)
                    oOtherStation.ProfileConnectedTo = cResurvey.cStation.SetConnectedToFromCollection(oColl)
                    oOtherStation.Row.Cells(5).Value = oOtherStation.ProfileConnectedTo
                End If
            Next

            Call oStations.Remove(sTrigpoint)
            'oLastPlaceHolder = Nothing
            Call pDelayedPerformPaint()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Function pGetPlaceholdername(PlanOrProfile As Integer, Station As cResurvey.cStation) As String
        Dim sPicture As String
        If PlanOrProfile = 0 Then
            sPicture = "picPlan"
        Else
            sPicture = "picProfile"
        End If
        Return "btn_trigpoint_" & sPicture & "_" & Station.Name
    End Function

    Private Function pGetPlaceholdername(Picture As PictureBox, Station As String) As String
        Return "btn_trigpoint_" & Picture.Name & "_" & Station
    End Function

    Private Sub pStationSetOrigin()
        Cursor = Cursors.WaitCursor
        Try
            Dim sTrigpoint As String = oLastPlaceHolder.Name

            Dim oStation As cResurvey.cStation = oStations(sTrigpoint)
            oStation.Type = "O"
            oStation.Row.Cells(6).Value = oStation.Type
            If Not oStation.PlanPlaceholder Is Nothing Then oStation.PlanPlaceholder.BackColor = oOriginColor
            If Not oStation.ProfilePlaceholder Is Nothing Then oStation.ProfilePlaceholder.BackColor = oOriginColor
            oStation.Row.Cells(0).Style.BackColor = oOriginColor
            For Each oOtherStation As cResurvey.cStation In oStations.Values
                If Not oOtherStation Is oStation And oOtherStation.Type = "O" Then
                    oOtherStation.Type = ""
                    oOtherStation.Row.Cells(6).Value = oOtherStation.Type
                    If Not oOtherStation.PlanPlaceholder Is Nothing Then oOtherStation.PlanPlaceholder.BackColor = oGenericColor
                    If Not oOtherStation.ProfilePlaceholder Is Nothing Then oOtherStation.ProfilePlaceholder.BackColor = oGenericColor
                    oOtherStation.Row.Cells(0).Style.BackColor = grdStations.DefaultCellStyle.BackColor
                End If
            Next
            Call pDelayedPerformPaint()
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuPreviewSetOrigin_Click(sender As System.Object, e As System.EventArgs) Handles mnuPreviewSetOrigin.Click
        Call pStationSetOrigin()
    End Sub

    Private Sub tabPlan_Resize(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub tabMain_Resize(sender As Object, e As System.EventArgs)
        Call pDelayedPerformPaint()
    End Sub

    Private pnlPlan As Panel
    Private pnlProfile As Panel

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        CheckForIllegalCrossThreadCalls = False

        grdPlot.Dock = DockStyle.Fill
        grdStations.Dock = DockStyle.Fill

        pnlPlanOrProfile.Dock = DockStyle.Fill
        pnlMain.Dock = DockStyle.Fill

        btnStations.Checked = True

        oOptions = New cResurvey.cOptions

        oPlanTrigpointsPlaceholders = New Dictionary(Of String, cResurvey.cTrigpointPlaceholder)
        oProfileTrigpointsPlaceholders = New Dictionary(Of String, cResurvey.cTrigpointPlaceholder)
        oShots = New cResurvey.cShots
        oStations = New Dictionary(Of String, cResurvey.cStation)

        oRulesSecondaryPen = New Pen(oRulesColor, -1)
        oRulesSecondaryPen.DashStyle = DashStyle.Dash
        oRulesPen = New Pen(oRulesColor, -1)
        oRulesPen.DashStyle = DashStyle.Dot
        oRulesLabelPen = New Pen(oRulesColor, -1)
        oRulesLabelBrush = New SolidBrush(Color.FromArgb(180, Color.White))
        oRulesBrush = New SolidBrush(oRulesColor)
        oRulesFillBrush = New SolidBrush(Color.FromArgb(120, Color.WhiteSmoke))

        picPlan.AllowDrop = True
        picProfile.AllowDrop = True

        picPlan.AutoSize = False
        picPlan.SizeMode = PictureBoxSizeMode.Zoom
        picProfile.AutoSize = False
        picProfile.SizeMode = PictureBoxSizeMode.Zoom

        pnlPlan = pnlMain.Panel1
        pnlProfile = pnlMain.Panel2

        oPlanVSB = New VScrollBar
        pnlPlan.Controls.Add(oPlanVSB)
        oPlanVSB.Dock = DockStyle.Right
        oPlanVSB.SendToBack()
        oPlanVSB.SmallChange = 1
        oPlanVSB.LargeChange = 25

        oPlanHSB = New HScrollBar
        pnlPlan.Controls.Add(oPlanHSB)
        oPlanHSB.Dock = DockStyle.Bottom
        oPlanHSB.SendToBack()
        oPlanHSB.SmallChange = 1
        oPlanHSB.LargeChange = 25

        picPlan.SendToBack()

        oProfileVSB = New VScrollBar
        pnlProfile.Controls.Add(oProfileVSB)
        oProfileVSB.Dock = DockStyle.Right
        oProfileVSB.SendToBack()
        oProfileVSB.SmallChange = 1
        oProfileVSB.LargeChange = 25

        oProfileHSB = New HScrollBar
        pnlProfile.Controls.Add(oProfileHSB)
        oProfileHSB.Dock = DockStyle.Bottom
        oProfileHSB.SendToBack()
        oProfileHSB.SmallChange = 1
        oProfileHSB.LargeChange = 25

        picProfile.SendToBack()

        Call pSetViewMode(0)

        Dim sObjectsPath As String = modMain.GetApplicationPath & "\objects"
        'carico i cursori
        oOpenHandCursor = New Cursor(sObjectsPath & "\cursors\openhand.cur")
        oClosedHandCursor = New Cursor(sObjectsPath & "\cursors\closedhand.cur")
    End Sub

    Private Sub pBindScrollbars(Optional Resize As Boolean = False)
        If Resize Then
            Dim oScrollPoint As Point = New Point(picPlan.Location.X, picPlan.Location.Y)
            If Math.Abs(oScrollPoint.X) > (picPlan.Width - pnlPlan.Width) Then
                oScrollPoint.X = -(picPlan.Width - pnlPlan.Width)
            ElseIf oScrollPoint.X > 0 Then
                oScrollPoint.X = 0
            End If
            If Math.Abs(oScrollPoint.Y) > (picPlan.Height - pnlPlan.Height) Then
                oScrollPoint.Y = -(picPlan.Height - pnlPlan.Height)
            ElseIf oScrollPoint.Y > 0 Then
                oScrollPoint.Y = 0
            End If
            picPlan.Location = oScrollPoint

            oScrollPoint = New Point(picProfile.Location.X, picProfile.Location.Y)
            If Math.Abs(oScrollPoint.X) > (picProfile.Width - pnlProfile.Width) Then
                oScrollPoint.X = -(picProfile.Width - pnlProfile.Width)
            ElseIf oScrollPoint.X > 0 Then
                oScrollPoint.X = 0
            End If
            If Math.Abs(oScrollPoint.Y) > (picProfile.Height - pnlProfile.Height) Then
                oScrollPoint.Y = -(picProfile.Height - pnlProfile.Height)
            ElseIf oScrollPoint.Y > 0 Then
                oScrollPoint.Y = 0
            End If
            picProfile.Location = oScrollPoint
        End If

        Try
            Dim oPlanLocation As Point = picPlan.Location
            Dim oPlanSize As Size = picPlan.Size
            Dim iWidth As Integer = oPlanSize.Width ' * sPaintZoom * 2
            Dim iHeight As Integer = oPlanSize.Height '* sPaintZoom * 2
            Dim iCurrentX As Integer = -oPlanLocation.X
            Dim iCurrentY As Integer = -oPlanLocation.Y

            If iWidth < Math.Abs(iCurrentX) Then
                iWidth = Math.Abs(iCurrentX)
            End If
            If iHeight < Math.Abs(iCurrentY) Then
                iHeight = Math.Abs(iCurrentY)
            End If

            oPlanVSB.Minimum = 0
            If iHeight - pnlPlan.Height > 0 Then
                oPlanVSB.Maximum = iHeight - pnlPlan.Height
            Else
                oPlanVSB.Maximum = 0
            End If
            oPlanHSB.Minimum = 0
            If iWidth - pnlPlan.Width > 0 Then
                oPlanHSB.Maximum = iWidth - pnlPlan.Width
            Else
                oPlanHSB.Maximum = 0
            End If
            If iCurrentX >= oPlanHSB.Minimum And iCurrentX <= oPlanHSB.Maximum Then oPlanHSB.Value = iCurrentX Else oPlanHSB.Value = 0
            If iCurrentY >= oPlanVSB.Minimum And iCurrentY <= oPlanVSB.Maximum Then oPlanVSB.Value = iCurrentY Else oPlanVSB.Value = 0

            Dim oProfileLocation As Point = picProfile.Location
            Dim oProfileSize As Size = picProfile.Size
            iWidth = oProfileSize.Width ' * sPaintZoom * 2
            iHeight = oProfileSize.Height '* sPaintZoom * 2
            iCurrentX = -oProfileLocation.X
            iCurrentY = -oProfileLocation.Y
            If iWidth < Math.Abs(iCurrentX) Then
                iWidth = Math.Abs(iCurrentX)
            End If
            If iHeight < Math.Abs(iCurrentY) Then
                iHeight = Math.Abs(iCurrentY)
            End If
            oProfileVSB.Minimum = 0
            If iHeight - pnlProfile.Height > 0 Then
                oProfileVSB.Maximum = iHeight - pnlProfile.Height
            Else
                oProfileVSB.Maximum = 0
            End If
            oProfileHSB.Minimum = 0
            If iWidth - pnlProfile.Width > 0 Then
                oProfileHSB.Maximum = iWidth - pnlProfile.Width
            Else
                oProfileHSB.Maximum = 0
            End If
            If iCurrentX >= oProfileHSB.Minimum And iCurrentX <= oProfileHSB.Maximum Then oProfileHSB.Value = iCurrentX Else oProfileHSB.Value = 0
            If iCurrentY >= oProfileVSB.Minimum And iCurrentY <= oProfileVSB.Maximum Then oProfileVSB.Value = iCurrentY Else oProfileVSB.Value = 0
        Catch
        End Try
    End Sub

    Private Sub oPlanHSB_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles oPlanHSB.Scroll
        picPlan.Location = New Point(-e.NewValue, picPlan.Top)
    End Sub

    Private Sub oPlanVSB_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles oPlanVSB.Scroll
        picPlan.Location = New Point(picPlan.Left, -e.NewValue)
    End Sub

    Private Sub oProfileHSB_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles oProfileHSB.Scroll
        picProfile.Location = New Point(-e.NewValue, picProfile.Top)
    End Sub

    Private Sub oProfileVSB_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles oProfileVSB.Scroll
        picProfile.Location = New Point(picProfile.Left, -e.NewValue)
    End Sub

    Private Sub pStationProperties()
        Try
            Dim sTrigpoint As String = oLastPlaceHolder.Name
            If sTrigpoint <> "" Then
                Dim ostation As cResurvey.cStation = oStations(sTrigpoint)
                Dim frmP As frmResurveyProperties = New frmResurveyProperties(oStations, ostation)
                AddHandler frmP.OnApply, AddressOf frmP_OnApply
                If frmP.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Call pDelayedPerformPaint()
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub mnuPreviewProperties_Click(sender As System.Object, e As System.EventArgs) Handles mnuPreviewProperties.Click
        Call pStationProperties()
    End Sub

    Private Sub frmP_OnApply(Sender As frmResurveyProperties, Args As frmResurveyProperties.cResurveyPropertiesEventArgs)
        Call pDelayedPerformPaint()
    End Sub

    Private Sub btnPlot_Click(sender As System.Object, e As System.EventArgs) Handles btnPlot.Click
        grdPlot.Visible = True
        grdStations.Visible = False
        Call grdPlot.BringToFront()

        btnPlot.Checked = True
        btnStations.Checked = False
    End Sub

    Private Sub btnStations_Click(sender As System.Object, e As System.EventArgs) Handles btnStations.Click
        grdPlot.Visible = False
        grdStations.Visible = True
        Call grdStations.BringToFront()

        btnPlot.Checked = False
        btnStations.Checked = True
    End Sub

    Private Sub mnuPreviewDeleteAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuPreviewDeleteAll.Click
        If MsgBox(GetLocalizedString("resurvey.warning6"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("resurvey.warningtitle")) = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Call oPlanTrigpointsPlaceholders.Clear()
            Call oProfileTrigpointsPlaceholders.Clear()

            Call oStations.Clear()
            Call grdStations.Rows.Clear()
            oLastPlaceHolder = Nothing
            oLastLine = Nothing

            Call pDelayedPerformPaint()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub mnuGridStationDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuGridStationDelete.Click
        Call pStationDelete()
    End Sub

    Private Sub grdStations_SelectionChanged(sender As Object, e As System.EventArgs) Handles grdStations.SelectionChanged
        If grdStations.SelectedRows.Count > 0 Then
            Dim sTrigPoint As String = "" & grdStations.SelectedRows(0).Cells(1).Value
            Dim oNewPlaceHolder As cResurvey.cTrigpointPlaceholder
            If pGetCurrentProjection() = 0 Then
                If oPlanTrigpointsPlaceholders.ContainsKey(sTrigPoint) Then
                    oNewPlaceHolder = oPlanTrigpointsPlaceholders(sTrigPoint)
                Else
                    oNewPlaceHolder = Nothing
                End If
            Else
                If oProfileTrigpointsPlaceholders.ContainsKey(sTrigPoint) Then
                    oNewPlaceHolder = oProfileTrigpointsPlaceholders(sTrigPoint)
                Else
                    oNewPlaceHolder = Nothing
                End If
            End If

            If Not oNewPlaceHolder Is oLastPlaceHolder Then
                oLastPlaceHolder = oNewPlaceHolder
                oLastLine = Nothing
                Call pStationSelectRow()
            End If
        Else
            oLastPlaceHolder = Nothing
        End If
        Call pDelayedPerformPaint()
    End Sub

    Private Sub mnuGridStationRemove_Click(sender As System.Object, e As System.EventArgs) Handles mnuGridStationRemove.Click
        Call pPlaceHolderDelete()
    End Sub

    Private Sub mnuGridStationProprieties_Click(sender As System.Object, e As System.EventArgs) Handles mnuGridStationProperties.Click
        Call pStationProperties()
    End Sub

    Private Sub mnuGridStation_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles mnuGridStation.Opening
        If oLastPlaceHolder Is Nothing Then
            mnuGridStationRemove.Enabled = False
            mnuGridStationDelete.Enabled = Not grdStations.CurrentRow Is Nothing
            mnuGridStationProperties.Enabled = False
            mnuGridStationSetOrigin.Enabled = False
        Else
            mnuGridStationRemove.Enabled = True
            mnuGridStationDelete.Enabled = True
            mnuGridStationProperties.Enabled = True
            Dim sType As String = ""
            Try : sType = oStations(oLastPlaceHolder.Name).Type : Catch : End Try
            mnuGridStationSetOrigin.Enabled = sType = ""
        End If
    End Sub

    Private Sub mnuGridStationSetOrigin_Click(sender As System.Object, e As System.EventArgs) Handles mnuGridStationSetOrigin.Click
        Call pStationSetOrigin()
    End Sub

    Private Sub mnuTabsLoadImage_Click(sender As System.Object, e As System.EventArgs) Handles mnuTabsLoadImage.Click
        Call pImageLoad()
    End Sub

    Private Sub mnuTabs_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles mnuTabs.Opening
        If pGetCurrentProjection() = 0 Then
            mnuTabsLoadImage.Enabled = picPlan.Image Is Nothing
        Else
            mnuTabsLoadImage.Enabled = picProfile.Image Is Nothing
        End If
    End Sub

    Private Sub picPlan_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles picPlan.MouseMove
        If My.Computer.Keyboard.CtrlKeyDown Or (e.Button And Windows.Forms.MouseButtons.Middle) = Windows.Forms.MouseButtons.Middle Then
            If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Or (e.Button And Windows.Forms.MouseButtons.Middle) = Windows.Forms.MouseButtons.Middle Then
                picPlan.Cursor = oClosedHandCursor
                Dim oPoint As Point = e.Location
                Dim iDeltaX As Integer = oDragScreenOffset.X - oPoint.X
                Dim iDeltaY As Integer = oDragScreenOffset.Y - oPoint.Y
                Dim oScrollPoint As Point = New Point(picPlan.Location.X - iDeltaX, picPlan.Location.Y - iDeltaY)
                If Math.Abs(oScrollPoint.X) > (picPlan.Width - pnlPlan.Width) Then
                    oScrollPoint.X = -(picPlan.Width - pnlPlan.Width)
                ElseIf oScrollPoint.X > 0 Then
                    oScrollPoint.X = 0
                End If
                If Math.Abs(oScrollPoint.Y) > (picPlan.Height - pnlPlan.Height) Then
                    oScrollPoint.Y = -(picPlan.Height - pnlPlan.Height)
                ElseIf oScrollPoint.Y > 0 Then
                    oScrollPoint.Y = 0
                End If
                picPlan.Location = oScrollPoint
                Call pBindScrollbars()
            Else
                picPlan.Cursor = oOpenHandCursor
            End If
        Else
            Dim oPoint As Point = New Point(e.Location.X / sPlanZoom, e.Location.Y / sPlanZoom)
            pnlCoordinates.Text = "X: " & oPoint.X & " px; Y: " & oPoint.Y & " px"

            If Not pHitTestPlanPlaceholder(oPoint) Is Nothing Then
                picPlan.Cursor = Cursors.Hand
            ElseIf Not pHitTestPlanLine(oPoint) Is Nothing Then
                picPlan.Cursor = Cursors.Hand
            Else
                picPlan.Cursor = Cursors.Cross
            End If

            If Not oLastPlaceHolder Is Nothing Then
                Dim dDistance As Decimal = modPaint.DistancePointToPoint(oLastPlaceHolder.Point, oPoint)
                pnlDistance.Text = "Δ: " & dDistance & " px"
                Dim oScale As cScale = pGetScale()
                Dim dScaledDistance As Decimal
                If iCurrentProject = 0 Then
                    If Not oScale.PlanError Then
                        dScaledDistance = modNumbers.MathRound(dDistance * oScale.PlanScale, 2)
                        pnlDistance.Text &= " - " & dScaledDistance & " m"
                    End If
                Else
                    If Not oScale.ProfileError Then
                        dScaledDistance = modNumbers.MathRound(dDistance * oScale.ProfileScale, 2)
                        pnlDistance.Text &= " - " & dScaledDistance & " m"
                    End If
                End If
                pnlAngle.Text = "α:" & modPaint.GetBearing(oLastPlaceHolder.Point, oPoint) & " °"
                If ((e.Button And MouseButtons.Left) = MouseButtons.Left) Then
                    If (Rectangle.op_Inequality(oDragboxFromMouseDown, Rectangle.Empty) And Not oDragboxFromMouseDown.Contains(oPoint)) Then
                        oDragScreenOffset = SystemInformation.WorkingArea.Location
                        Dim oDropEffect As DragDropEffects = picPlan.DoDragDrop(oLastPlaceHolder, DragDropEffects.Link)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub picProfile_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles picProfile.MouseMove
        If My.Computer.Keyboard.CtrlKeyDown Or (e.Button And Windows.Forms.MouseButtons.Middle) = Windows.Forms.MouseButtons.Middle Then
            If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Or (e.Button And Windows.Forms.MouseButtons.Middle) = Windows.Forms.MouseButtons.Middle Then
                picProfile.Cursor = oClosedHandCursor
                Dim oPoint As Point = e.Location
                Dim iDeltaX As Integer = oDragScreenOffset.X - oPoint.X
                Dim iDeltaY As Integer = oDragScreenOffset.Y - oPoint.Y
                Dim oScrollPoint As Point = New Point(picProfile.Location.X - iDeltaX, picProfile.Location.Y - iDeltaY)
                If Math.Abs(oScrollPoint.X) > (picProfile.Width - pnlProfile.Width) Then
                    oScrollPoint.X = -(picProfile.Width - pnlProfile.Width)
                ElseIf oScrollPoint.X > 0 Then
                    oScrollPoint.X = 0
                End If
                If Math.Abs(oScrollPoint.Y) > (picProfile.Height - pnlProfile.Height) Then
                    oScrollPoint.Y = -(picProfile.Height - pnlProfile.Height)
                ElseIf oScrollPoint.Y > 0 Then
                    oScrollPoint.Y = 0
                End If
                picProfile.Location = oScrollPoint
                Call pBindScrollbars()
            Else
                picProfile.Cursor = oOpenHandCursor
            End If
        Else
            Dim oPoint As Point = New Point(e.Location.X / sProfileZoom, e.Location.Y / sProfileZoom)
            pnlCoordinates.Text = "X: " & oPoint.X & " px; Y: " & oPoint.Y & " px"

            If Not pHitTestProfilePlaceholder(oPoint) Is Nothing Then
                picProfile.Cursor = Cursors.Hand
            ElseIf Not pHitTestProfileLine(oPoint) Is Nothing Then
                picProfile.Cursor = Cursors.Hand
            Else
                picProfile.Cursor = Cursors.Cross
            End If

            If Not oLastPlaceHolder Is Nothing Then
                pnlDistance.Text = "Δ: " & modPaint.DistancePointToPoint(oLastPlaceHolder.Point, oPoint) & " px"
                pnlAngle.Text = "α: " & modPaint.GetInclination(oLastPlaceHolder.Point, oPoint) & " °"
                If ((e.Button And MouseButtons.Left) = MouseButtons.Left) Then
                    If (Rectangle.op_Inequality(oDragboxFromMouseDown, Rectangle.Empty) And Not oDragboxFromMouseDown.Contains(oPoint)) Then
                        oDragScreenOffset = SystemInformation.WorkingArea.Location
                        Dim oDropEffect As DragDropEffects = picProfile.DoDragDrop(oLastPlaceHolder, DragDropEffects.Link)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnConfirm_Click(sender As System.Object, e As System.EventArgs) Handles btnConfirm.Click
        If MsgBox(GetLocalizedString("resurvey.warning7"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("resurvey.warningtitle")) = MsgBoxResult.Yes Then
            DialogResult = Windows.Forms.DialogResult.OK
            Call Close()
        End If
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Call Close()
    End Sub

    Friend ReadOnly Property Shots As cResurvey.cShots
        Get
            Return oShots
        End Get
    End Property

    Friend ReadOnly Property Stations As Dictionary(Of String, cResurvey.cStation)
        Get
            Return oStations
        End Get
    End Property

    Private iCurrentProject As Integer

    Private Sub pSetCurrentProjection(Project As Integer)
        iCurrentProject = Project
        Select Case Project
            Case 0
                Call picPlan.Focus()
                pnlCurrentProjection.Text = GetLocalizedString("resurvey.textpart1")
            Case 1
                Call picProfile.Focus()
                pnlCurrentProjection.Text = GetLocalizedString("resurvey.textpart2")
        End Select

        pnlCoordinates.Text = ""
        oLastPlaceHolder = Nothing
        oLastLine = Nothing

        Call pDelayedPerformPaint()
        Call grdStations_SelectionChanged(Nothing, Nothing)
        Call pInvalidateCurrentView(True)
    End Sub

    Private Function pGetCurrentProjection() As Integer
        If oOptions Is Nothing Then
            Return 0
        Else
            If oOptions.CalculateMode = cResurvey.cOptions.CalculateModeEnum.OnlyPlan Then
                Return 0
            Else
                Return iCurrentProject
            End If
        End If
    End Function

    'Private Sub tabMain_SelectedIndexChanged(sender As Object, e As System.EventArgs)
    '    If pGetCurrentProjection() = 1 And oOptions.CalculateMode = cResurvey.cOptions.CalculateModeEnum.OnlyPlan Then
    '        Call MsgBox("Non è possibile impostare capisaldi e altri dati per questa proiezione in questa modalità operativa.", vbOKOnly Or MsgBoxStyle.Critical, "Attenzione:")
    '        tabMain.SelectedTab = tabPlan
    '    Else
    '        pnlCoordinates.Text = ""
    '        oLastPlaceHolder = Nothing
    '        oLastLine = Nothing

    '        Call pDelayedPerformPaint()
    '    End If
    '    Call grdStations_SelectionChanged(Nothing, Nothing)
    'End Sub

    Private Sub picPlan_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles picPlan.MouseUp
        oDragboxFromMouseDown = Rectangle.Empty
        Dim oPoint As Point = e.Location

        If (e.Button And Windows.Forms.MouseButtons.Right) = Windows.Forms.MouseButtons.Right Then
            Call mnuPreview.Show(picPlan.PointToScreen(oPoint))
        End If

        picPlan.Cursor = Cursors.Default
    End Sub

    Private Sub picProfile_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles picProfile.MouseUp
        oDragboxFromMouseDown = Rectangle.Empty
        Dim oPoint As Point = e.Location

        If (e.Button And Windows.Forms.MouseButtons.Right) = Windows.Forms.MouseButtons.Right Then
            Call mnuPreview.Show(picProfile.PointToScreen(oPoint))
        End If

        picProfile.Cursor = Cursors.Default
    End Sub

    Private Sub pSelectProfilePlaceholder(Point As Point)
        oLastPlaceHolder = pHitTestProfilePlaceholder(Point)
        If oLastPlaceHolder Is Nothing Then
            Call pSelectProfileLine(Point)
        Else
            Call pStationSelectRow()
            oLastLine = Nothing
        End If
    End Sub

    Private Function pHitTestProfilePlaceholder(Point As Point) As cResurvey.cTrigpointPlaceholder
        For Each oTPH As cResurvey.cTrigpointPlaceholder In oProfileTrigpointsPlaceholders.Values
            If oTPH.Visible Then
                If oTPH.HotSpot.Contains(Point) Then
                    Return oTPH
                End If
            End If
        Next
        Return Nothing
    End Function

    Private Function pHitTestPlanPlaceholder(Point As Point) As cResurvey.cTrigpointPlaceholder
        For Each oTPH As cResurvey.cTrigpointPlaceholder In oPlanTrigpointsPlaceholders.Values
            If oTPH.Visible Then
                If oTPH.HotSpot.Contains(Point) Then
                    Return oTPH
                End If
            End If
        Next
        Return Nothing
    End Function

    Private Sub pSelectPlanPlaceholder(Point As Point)
        oLastPlaceHolder = pHitTestPlanPlaceholder(Point)
        If oLastPlaceHolder Is Nothing Then
            Call pSelectPlanLine(Point)
        Else
            Call pStationSelectRow()
            oLastLine = Nothing
        End If
    End Sub

    Private Function pHitTestPlanLine(Point As Point) As cResurvey.cTrigpointPlaceholder()
        Dim oLine As cResurvey.cTrigpointPlaceholder() = Nothing
        Dim iMinDistance As Integer = Integer.MaxValue
        For Each oFromTPH As cResurvey.cTrigpointPlaceholder In oPlanTrigpointsPlaceholders.Values
            Dim oFromPoint As Point = oFromTPH.Point
            Dim oToConnectedTo As List(Of String) = cResurvey.cStation.GetConnectedToCollection(oStations(oFromTPH.Name).PlanConnectedTo)
            For Each sToConnectedTo As String In oToConnectedTo
                If oPlanTrigpointsPlaceholders.ContainsKey(sToConnectedTo) Then
                    Dim oToTPH As cResurvey.cTrigpointPlaceholder = oPlanTrigpointsPlaceholders(sToConnectedTo)
                    Dim oToPoint As Point = oToTPH.Point
                    Dim iDistance As Integer = modPaint.DistancePointToSegment(Point, CType(oFromPoint, PointF), CType(oToPoint, PointF))
                    If iDistance < iMinDistance And iDistance < iBaseMinDistance Then
                        iMinDistance = iDistance
                        oLine = {oFromTPH, oToTPH}
                    End If
                End If
            Next
        Next
        Return oLine
    End Function

    Private Function pHitTestProfileLine(Point As Point) As cResurvey.cTrigpointPlaceholder()
        Dim oLine As cResurvey.cTrigpointPlaceholder() = Nothing
        Dim iMinDistance As Integer = Integer.MaxValue
        For Each oFromTPH As cResurvey.cTrigpointPlaceholder In oProfileTrigpointsPlaceholders.Values
            Dim oFromPoint As Point = oFromTPH.Point
            Dim oToConnectedTo As List(Of String) = cResurvey.cStation.GetConnectedToCollection(oStations(oFromTPH.Name).ProfileConnectedTo)
            For Each sToConnectedTo As String In oToConnectedTo
                If oProfileTrigpointsPlaceholders.ContainsKey(sToConnectedTo) Then
                    Dim oToTPH As cResurvey.cTrigpointPlaceholder = oProfileTrigpointsPlaceholders(sToConnectedTo)
                    Dim oToPoint As Point = oToTPH.Point
                    Dim iDistance As Integer = modPaint.DistancePointToSegment(Point, CType(oFromPoint, PointF), CType(oToPoint, PointF))
                    If iDistance < iMinDistance And iDistance < iBaseMinDistance Then
                        iMinDistance = iDistance
                        oLine = {oFromTPH, oToTPH}
                    End If
                End If
            Next
        Next
        Return oLine
    End Function

    Private Sub pSelectPlanLine(Point As Point)
        oLastLine = pHitTestPlanLine(Point)
    End Sub

    Private Sub pSelectProfileLine(Point As Point)
        oLastLine = pHitTestProfileLine(Point)
    End Sub

    Private Sub btnOptions_Click(sender As System.Object, e As System.EventArgs) Handles btnOptions.Click
        Dim frmO As frmResurveyOptions = New frmResurveyOptions(oOptions, oStations.Count > 0)
        With frmO
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Call oOptions.CopyFrom(.CurrentOptions)
                If oOptions.CalculateMode <> .CurrentOptions.CalculateMode And oOptions.CalculateMode = cResurvey.cOptions.CalculateModeEnum.OnlyPlan Then
                    Call pSetCalculateMode()
                End If
            End If
        End With
    End Sub

    Private Sub pSetCalculateMode()
        Select Case oOptions.CalculateMode
            Case cResurvey.cOptions.CalculateModeEnum.Full
                btnPlan.Enabled = True
                btnProfile.Enabled = True
                btnBoth.Enabled = True
                If oOptions.UseDropForInclination Then
                    colPlotDrop.Visible = True
                    colPlotPlanimetricDistance.Visible = True
                Else
                    colPlotDrop.Visible = False
                    colPlotPlanimetricDistance.Visible = False
                End If
            Case cResurvey.cOptions.CalculateModeEnum.OnlyPlan
                btnPlan.Enabled = True
                btnProfile.Enabled = False
                btnBoth.Enabled = False
                colPlotDrop.Visible = False
                colPlotPlanimetricDistance.Visible = False
                Call pSetCurrentProjection(0)
        End Select
        iDefaultCalculateMode = oOptions.CalculateMode
    End Sub

    Private Sub mnuPreviewDeleteLink_Click(sender As Object, e As EventArgs) Handles mnuPreviewDeleteLink.Click
        Cursor = Cursors.WaitCursor

        Dim oFromTPH As cResurvey.cTrigpointPlaceholder = oLastLine(0)
        Dim oToTPH As cResurvey.cTrigpointPlaceholder = oLastLine(1)

        Dim iPlanOrProfile As Integer = pGetCurrentProjection()

        Dim oFromStation As cResurvey.cStation = oStations(oFromTPH.Name)
        Dim sFromConnectedTo As String
        If iPlanOrProfile = 0 Then
            sFromConnectedTo = oFromStation.PlanConnectedTo
        Else
            sFromConnectedTo = oFromStation.ProfileConnectedTo
        End If
        Dim oFromConnectedTo As List(Of String) = cResurvey.cStation.GetConnectedToCollection(sFromConnectedTo)
        Call oFromConnectedTo.Remove(oToTPH.Name)
        sFromConnectedTo = cResurvey.cStation.SetConnectedToFromCollection(oFromConnectedTo)
        If iPlanOrProfile = 0 Then
            oFromStation.PlanConnectedTo = sFromConnectedTo
            oFromStation.Row.Cells(4).Value = sFromConnectedTo
        Else
            oFromStation.ProfileConnectedTo = sFromConnectedTo
            oFromStation.Row.Cells(5).Value = sFromConnectedTo
        End If

        Dim otoStation As cResurvey.cStation = oStations(oToTPH.Name)
        Dim stoConnectedTo As String
        If iPlanOrProfile = 0 Then
            stoConnectedTo = otoStation.PlanConnectedTo
        Else
            stoConnectedTo = otoStation.ProfileConnectedTo
        End If
        Dim otoConnectedTo As List(Of String) = cResurvey.cStation.GetConnectedToCollection(stoConnectedTo)
        Call otoConnectedTo.Remove(oFromTPH.Name)
        stoConnectedTo = cResurvey.cStation.SetConnectedToFromCollection(otoConnectedTo)
        If iPlanOrProfile = 0 Then
            otoStation.PlanConnectedTo = stoConnectedTo
            otoStation.Row.Cells(4).Value = stoConnectedTo
        Else
            otoStation.ProfileConnectedTo = stoConnectedTo
            otoStation.Row.Cells(5).Value = stoConnectedTo
        End If

        oLastLine = Nothing

        Call pPerformCalculate(False)
        Call pPerformPaint()

        Cursor = Cursors.Default
    End Sub

    Private Sub picPlan_DragDrop(sender As Object, e As DragEventArgs) Handles picPlan.DragDrop
        If (e.Data.GetDataPresent(GetType(cResurvey.cTrigpointPlaceholder))) Then
            Dim oPoint As Point = picPlan.PointToClient(New Point(e.X, e.Y))
            Dim oToTPH As cResurvey.cTrigpointPlaceholder = pHitTestPlanPlaceholder(oPoint)
            If Not oToTPH Is Nothing Then
                Dim oFromTPH As cResurvey.cTrigpointPlaceholder = e.Data.GetData(GetType(cResurvey.cTrigpointPlaceholder))
                If oFromTPH.Projection = 0 Then
                    Dim oStation As cResurvey.cStation = oStations(oFromTPH.Name)

                    Dim iPlanOrProfile As Integer = pGetCurrentProjection()

                    Dim sConnectedTo As String = oStation.PlanConnectedTo
                    Dim oConnectedTo As List(Of String) = cResurvey.cStation.GetConnectedToCollection(sConnectedTo)
                    If Not oConnectedTo.Contains(oToTPH.Name) Then
                        Call oConnectedTo.Add(oToTPH.Name)
                        sConnectedTo = cResurvey.cStation.SetConnectedToFromCollection(oConnectedTo)
                        oStation.PlanConnectedTo = sConnectedTo
                        oStation.Row.Cells(4).Value = sConnectedTo

                        Call pPerformCalculate(False)
                        Call pPerformPaint()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub picPlan_DragOver(sender As Object, e As DragEventArgs) Handles picPlan.DragOver
        If (e.Data.GetDataPresent(GetType(cResurvey.cTrigpointPlaceholder))) Then
            Dim oFromTPH As cResurvey.cTrigpointPlaceholder = e.Data.GetData(GetType(cResurvey.cTrigpointPlaceholder))
            If oFromTPH.Projection = 0 Then
                Dim oPoint As Point = picPlan.PointToClient(New Point(e.X, e.Y))
                Dim oToTPH As cResurvey.cTrigpointPlaceholder = pHitTestPlanPlaceholder(oPoint)
                If oToTPH Is Nothing Or oFromTPH Is oToTPH Then
                    e.Effect = DragDropEffects.None
                Else
                    e.Effect = DragDropEffects.Link
                End If
            Else
                e.Effect = DragDropEffects.None
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub picProfile_DragDrop(sender As Object, e As DragEventArgs) Handles picProfile.DragDrop
        If (e.Data.GetDataPresent(GetType(cResurvey.cTrigpointPlaceholder))) Then
            Dim oPoint As Point = picProfile.PointToClient(New Point(e.X, e.Y))
            Dim oToTPH As cResurvey.cTrigpointPlaceholder = pHitTestProfilePlaceholder(oPoint)
            If Not oToTPH Is Nothing Then
                Dim oFromTPH As cResurvey.cTrigpointPlaceholder = e.Data.GetData(GetType(cResurvey.cTrigpointPlaceholder))
                If oFromTPH.Projection = 1 Then
                    Dim oStation As cResurvey.cStation = oStations(oFromTPH.Name)

                    Dim sConnectedTo As String = oStation.ProfileConnectedTo
                    Dim oConnectedTo As List(Of String) = cResurvey.cStation.GetConnectedToCollection(sConnectedTo)
                    If Not oConnectedTo.Contains(oToTPH.Name) Then
                        Call oConnectedTo.Add(oToTPH.Name)
                        sConnectedTo = cResurvey.cStation.SetConnectedToFromCollection(oConnectedTo)
                        oStation.ProfileConnectedTo = sConnectedTo
                        oStation.Row.Cells(5).Value = sConnectedTo

                        Call pPerformCalculate(False)
                        Call pPerformPaint()

                        Call pPerformCalculate(False)
                        Call pPerformPaint()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub picProfile_DragOver(sender As Object, e As DragEventArgs) Handles picProfile.DragOver
        If (e.Data.GetDataPresent(GetType(cResurvey.cTrigpointPlaceholder))) Then
            Dim oFromTPH As cResurvey.cTrigpointPlaceholder = e.Data.GetData(GetType(cResurvey.cTrigpointPlaceholder))
            If oFromTPH.Projection = 1 Then
                Dim oPoint As Point = picProfile.PointToClient(New Point(e.X, e.Y))
                Dim oToTPH As cResurvey.cTrigpointPlaceholder = pHitTestProfilePlaceholder(oPoint)
                If oToTPH Is Nothing Or oFromTPH Is oToTPH Then
                    e.Effect = DragDropEffects.None
                Else
                    e.Effect = DragDropEffects.Link
                End If
            Else
                e.Effect = DragDropEffects.None
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub mnuPreviewShowOnlySelected_Click(sender As System.Object, e As System.EventArgs) Handles mnuPreviewShowOnlySelected.Click
        If pGetCurrentProjection() = 0 Then
            Call pHideTrigPoints(0)
        Else
            Call pHideTrigPoints(1)
        End If
        oLastPlaceHolder.Visible = True

        Call pDelayedPerformPaint()
    End Sub

    Private Sub mnuPreviewShowHide_Click(sender As System.Object, e As System.EventArgs) Handles mnuPreviewShowHide.Click

    End Sub

    Private Sub mnuPreviewShowHide_DropDownOpening(sender As Object, e As System.EventArgs) Handles mnuPreviewShowHide.DropDownOpening
        If oLastPlaceHolder Is Nothing Then
            mnuPreviewHide.Enabled = False
            mnuPreviewShowOnlySelected.Enabled = False
        Else
            mnuPreviewHide.Enabled = True
            mnuPreviewShowOnlySelected.Enabled = True
        End If
    End Sub

    Private Sub btnZoomIn_Click(sender As Object, e As EventArgs) Handles btnZoomIn.Click
        If pGetCurrentProjection() = 0 Then
            sPlanZoom = sPlanZoom * 1.1
            picPlan.Size = New Size(picPlan.Image.Width * sPlanZoom, picPlan.Image.Height * sPlanZoom)
            Call picPlan.Invalidate()
        Else
            sProfileZoom = sProfileZoom * 1.1
            picProfile.Size = New Size(picProfile.Image.Width * sProfileZoom, picProfile.Image.Height * sProfileZoom)
            Call picProfile.Invalidate()
        End If
    End Sub

    Private Sub btnZoomout_Click(sender As Object, e As EventArgs) Handles btnZoomOut.Click
        If pGetCurrentProjection() = 0 Then
            sPlanZoom = sPlanZoom * 0.9
            picPlan.Size = New Size(picPlan.Image.Width * sPlanZoom, picPlan.Image.Height * sPlanZoom)
            Call picPlan.Invalidate()
        Else
            sProfileZoom = sProfileZoom * 0.9
            picProfile.Size = New Size(picProfile.Image.Width * sProfileZoom, picProfile.Image.Height * sProfileZoom)
            Call picProfile.Invalidate()
        End If
    End Sub

    Private Sub btnZoomFit_Click(sender As Object, e As EventArgs) Handles btnZoomFit.Click
        Call btnZoomToFit1_Click(Nothing, Nothing)
    End Sub

    Private Sub pZoom(Center As Point, Delta As Integer)
        Delta = Delta / 100
        If pGetCurrentProjection() = 0 Then
            For i As Integer = 0 To Math.Abs(Delta)
                If Delta > 0 Then
                    sPlanZoom = sPlanZoom * 1.1
                Else
                    sPlanZoom = sPlanZoom * 0.9
                End If
            Next
            Dim oNewCenter As Point = New Point(Center.X * sPlanZoom, Center.Y * sPlanZoom)
            Dim oOldSize As Size = picPlan.Size
            Dim oNewSize = New Size(picPlan.Image.Width * sPlanZoom, picPlan.Image.Height * sPlanZoom)
            picPlan.Size = oNewSize

            picPlan.Location = New Point(picPlan.Location.X - (oNewSize.Width - oOldSize.Width) / 2, picPlan.Location.Y - (oNewSize.Height - oOldSize.Height) / 2)
            Call picPlan.Invalidate()
        Else
            For i As Integer = 0 To Math.Abs(Delta)
                If Delta > 0 Then
                    sProfileZoom = sProfileZoom * 1.1
                Else
                    sProfileZoom = sProfileZoom * 0.9
                End If
            Next
            Dim oNewCenter As Point = New Point(Center.X * sProfileZoom, Center.Y * sProfileZoom)
            Dim oOldSize As Size = picProfile.Size
            Dim oNewSize = New Size(picProfile.Image.Width * sProfileZoom, picProfile.Image.Height * sProfileZoom)
            picProfile.Size = oNewSize

            picProfile.Location = New Point(picProfile.Location.X + (oNewCenter.X - Center.X), picProfile.Location.Y + (oNewCenter.Y - Center.Y))
            Call picProfile.Invalidate()
        End If
    End Sub

    Private Sub picProfile_MouseWheel(sender As Object, e As MouseEventArgs) Handles picProfile.MouseWheel
        'Call pZoom(e.Location, e.Delta)
    End Sub

    Private Sub picPlan_MouseWheel(sender As Object, e As MouseEventArgs) Handles picPlan.MouseWheel
        'Call pZoom(e.Location, e.Delta)
    End Sub

    Private Sub btnZoomToFit1_Click(sender As Object, e As EventArgs) Handles btnZoomToFit1.Click
        If pGetCurrentProjection() = 0 Then
            Dim oRect As Rectangle = pnlPlan.ClientRectangle
            Dim sScale As Single = modPaint.ScaleToFit(oRect, picPlan.Image.GetBounds(Drawing.GraphicsUnit.Pixel))
            sPlanZoom = sScale
            picPlan.Location = New Point(0, 0)
            picPlan.Size = New Size(picPlan.Image.Width * sPlanZoom, picPlan.Image.Height * sPlanZoom)
            Call picPlan.Invalidate()
        Else
            Dim oRect As Rectangle = pnlProfile.ClientRectangle
            Dim sScale As Single = modPaint.ScaleToFit(oRect, picPlan.Image.GetBounds(Drawing.GraphicsUnit.Pixel))
            sProfileZoom = sScale
            picProfile.Location = New Point(0, 0)
            picProfile.Size = New Size(picProfile.Image.Width * sProfileZoom, picProfile.Image.Height * sProfileZoom)
            Call picProfile.Invalidate()
        End If
    End Sub

    Private Sub btnZoomToFit2_Click(sender As Object, e As EventArgs) Handles btnZoomToFit2.Click
        If pGetCurrentProjection() = 0 Then
            sPlanZoom = 1
            picPlan.Location = New Point(0, 0)
            picPlan.Size = New Size(picPlan.Image.Width * sPlanZoom, picPlan.Image.Height * sPlanZoom)
            Call picPlan.Invalidate()
        Else
            sProfileZoom = 1
            picProfile.Location = New Point(0, 0)
            picProfile.Size = New Size(picProfile.Image.Width * sProfileZoom, picProfile.Image.Height * sProfileZoom)
            Call picProfile.Invalidate()
        End If
    End Sub

    Private Sub frmResurveyMain_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        Call pBindScrollbars(True)
    End Sub

    Private Sub picPlan_GotFocus(sender As Object, e As EventArgs) Handles picPlan.GotFocus
        Call pSetCurrentProjection(0)
    End Sub

    Private Sub picProfile_GotFocus(sender As Object, e As EventArgs) Handles picProfile.GotFocus
        Call pSetCurrentProjection(1)
    End Sub

    Private Sub btnPlan_Click(sender As Object, e As EventArgs) Handles btnPlan.Click
        Call pSetViewMode(0)
    End Sub

    Private Sub pSetViewMode(Mode As Integer, Optional PanelLayout As Integer = 0)
        Select Case Mode
            Case 0
                btnPlan.Checked = True
                btnProfile.Checked = False
                btnBoth.Checked = False

                pnlMain.Panel1Collapsed = False
                pnlMain.Panel2Collapsed = True

                Call pSetCurrentProjection(0)

                btnVerticalLayout.Enabled = False
                btnHorizontalLayout.Enabled = False
            Case 1
                btnPlan.Checked = False
                btnProfile.Checked = True
                btnBoth.Checked = False

                pnlMain.Panel1Collapsed = True
                pnlMain.Panel2Collapsed = False

                Call pSetCurrentProjection(1)

                btnVerticalLayout.Enabled = False
                btnHorizontalLayout.Enabled = False
            Case 2
                btnPlan.Checked = False
                btnProfile.Checked = False
                btnBoth.Checked = True

                pnlMain.Panel1Collapsed = False
                pnlMain.Panel2Collapsed = False

                btnVerticalLayout.Enabled = True
                btnHorizontalLayout.Enabled = True
                Select Case PanelLayout
                    Case 0
                        btnVerticalLayout.Checked = True
                        btnHorizontalLayout.Checked = False
                        pnlMain.Orientation = Orientation.Vertical
                    Case 1
                        btnVerticalLayout.Checked = False
                        btnHorizontalLayout.Checked = True
                        pnlMain.Orientation = Orientation.Horizontal
                End Select
        End Select
    End Sub

    Private Sub btnProfile_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        Call pSetViewMode(1)
    End Sub

    Private Sub btnBoth_Click(sender As Object, e As EventArgs) Handles btnBoth.Click
        Call pSetViewMode(2)
    End Sub

    Private Sub btnHorizontalLayout_Click(sender As Object, e As EventArgs) Handles btnHorizontalLayout.Click
        Call pSetViewMode(2, 1)
    End Sub

    Private Sub btnVerticalLayout_Click(sender As Object, e As EventArgs) Handles btnVerticalLayout.Click
        Call pSetViewMode(2, 0)
    End Sub

    Private Sub btnShowRulers_Click(sender As Object, e As EventArgs) Handles btnShowRulers.Click
        btnShowRulers.Checked = Not btnShowRulers.Checked
        Call pInvalidateCurrentView()
    End Sub
End Class
