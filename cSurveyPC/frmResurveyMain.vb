Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports cSurveyPC.cResurvey
Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraBars.Docking
Imports DevExpress.XtraBars.Docking2010.Views
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors.Controls

Friend Class frmResurveyMain
    Private oOpenHandCursor As Cursor
    Private oClosedHandCursor As Cursor

    Private iBaseMinDistance As Integer = 16

    Private oOptions As cResurvey.cOptions

    Private oPlanLastMousePoint As Point
    Private oPlanLastPlaceHolder As cResurvey.cTrigpointPlaceholder
    Private oPlanLastLine As cResurvey.cTrigpointPlaceholder()

    Private oProfileLastMousePoint As Point
    Private oProfileLastPlaceHolder As cResurvey.cTrigpointPlaceholder
    Private oProfileLastLine As cResurvey.cTrigpointPlaceholder()

    Private sPlanImage As String
    Private sProfileImage As String

    Private sFilename As String = ""

    Private sPrevStation As String

    Private oShots As cResurvey.cShots
    Private oStations As cResurvey.cStations

    'Private oPlanStationPath As GraphicsPath
    'Private oPlanShotsPath As GraphicsPath
    'Private oPlanLRUDPath As GraphicsPath

    'Private oProfileStationPath As GraphicsPath
    'Private oProfileShotsPath As GraphicsPath
    'Private oProfileLRUDPath As GraphicsPath

    Private oScalePen As Pen
    Private oDropScalePen As Pen
    Private oDropScaleRealPen As Pen
    Private oNorthPen As Pen

    Private oPlanNorthPath As GraphicsPath

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
    Private oNorthColor As Color = Color.DarkRed

    Private oLRUDPen As Pen
    Private oSelectedLRUDPen As Pen
    Private oShotsPen As Pen
    Private oSelectedShotsPen As Pen
    Private oTranslationsPen As Pen
    Private oSelectedTranslationPen As Pen
    Private oActiveStationPen As Pen
    Private oLRUDAreaBrush As Brush

    Private oRulesColor As Color = Color.FromArgb(120, Color.Gray)
    Private oRulesPen As Pen
    Private oRulesSecondaryPen
    Private oRulesLabelPen As Pen
    Private oRulesLabelBrush As SolidBrush
    Private oRulesBrush As SolidBrush
    Private oRulesFillBrush As SolidBrush

    Private oRulerAngleFont As Font
    Private oRulerTickFont As Font
    Private oRulerFontBrush As SolidBrush
    Private oRulerForegroundPen As Pen
    Private oRulerCurrentAnglePen As Pen
    Private oRulerBackgroundBrush As SolidBrush

    Private iDefaultCalculateMode As cResurvey.cOptions.CalculateModeEnum

    Private sPlanZoom As Single = 1
    Private sProfileZoom As Single = 1

    'Private WithEvents oPlanVSB As VScrollBar
    'Private WithEvents oPlanHSB As HScrollBar

    'Private WithEvents oProfileVSB As VScrollBar
    'Private WithEvents oProfileHSB As HScrollBar

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

    Private Function pGetHashSet(HashSet As HashSet(Of String), Values As String) As HashSet(Of String)
        Call HashSet.Clear()
        Call Values.Split({";"c}).ToList.ForEach(Sub(oitem) HashSet.Add(oitem))
        Return HashSet
    End Function

    Private Function pImageLoad(BasePath As String, Filename As String) As Image
        Dim oFl As FileInfo = New FileInfo(Filename)
        If oFl.Exists Then
            Return modPaint.ImageExifRotate(New Bitmap(New Bitmap(Filename)))
        Else
            Dim sFilename As String = Path.Combine(BasePath, Path.GetFileName(Filename))
            oFl = New FileInfo(sFilename)
            If oFl.Exists Then
                Return modPaint.ImageExifRotate(New Bitmap(New Bitmap(sFilename)))
            Else
                Return Nothing
            End If
        End If
    End Function

    Private Sub pImageLoad()
        Using oOFD As OpenFileDialog = New OpenFileDialog
            With oOFD
                .Filter = GetLocalizedString("resurvey.filetypeIMAGES") & " (*.JPG;*.TIF;*.PNG)|*.JPG;*.TIF;*.PNG"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    If pGetCurrentProjection() = 0 Then
                        Try
                            sPlanImage = .FileName
                            Dim oplanImage As Image = pImageLoad("", sPlanImage)
                            picPlan.Image = oplanImage
                            If Not oplanImage Is Nothing Then
                                picPlan.AutoSize = False
                                picPlan.Size = picPlan.Image.Size
                                picPlan.SizeMode = PictureBoxSizeMode.Zoom
                                picPlan.Visible = True
                            End If
                            sPlanZoom = 1
                            Call pChangeCurrentProjection()
                        Catch ex As Exception
                            picPlan.Visible = False
                        End Try
                    Else
                        Try
                            sProfileImage = .FileName
                            Dim oprofileImage As Image = pImageLoad("", sProfileImage)
                            picProfile.Image = oprofileImage
                            If Not oprofileImage Is Nothing Then
                                picProfile.AutoSize = False
                                picProfile.Size = picProfile.Image.Size
                                picProfile.SizeMode = PictureBoxSizeMode.Zoom
                                picProfile.Visible = True
                            End If
                            sProfileZoom = 1
                            Call pChangeCurrentProjection()
                        Catch ex As Exception
                            picProfile.Visible = False
                        End Try
                    End If
                End If
            End With
        End Using
    End Sub

    Private Sub pLoad(Filename As String)
        If Filename = "" Then
            Using oOFD As OpenFileDialog = New OpenFileDialog
                With oOFD
                    .Filter = GetLocalizedString("resurvey.filetypeRESURVEY") & " (*.CRSZ;*.CRSX)|*.CRSZ;*.CRSX|" & GetLocalizedString("resurvey.filetypeCRSZ") & " (*.CRSZ)|*.CRSZ|" & GetLocalizedString("resurvey.filetypeCRSX") & " (*.CRSX)|*.CRSX|" & GetLocalizedString("main.filetypeALL") & " (*.*)|*.*"
                    .FilterIndex = 1
                    .DefaultExt = ".CRSZ"
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        Filename = .FileName
                    End If
                End With
            End Using
        End If

        If Filename <> "" Then
            Cursor = Cursors.WaitCursor

            sFilename = Filename

            Dim oFile As cResurvey.cFile = New cResurvey.cFile(sFilename)

            Dim oXML As XmlDocument = oFile.Document
            Dim oXMLRoot As XmlElement = oXML.Item("cresurvey")

            oOptions.CalculateMode = modXML.GetAttributeValue(oXMLRoot, "calculatemode", cResurvey.cOptions.CalculateModeEnum.Full)
            oOptions.ProfileType = modXML.GetAttributeValue(oXMLRoot, "profiletype", cResurvey.cOptions.ProfileTypeEnum.Extended)
            oOptions.NordCorrection = modNumbers.StringToSingle(modXML.GetAttributeValue(oXMLRoot, "nordcorrection", 0))
            oOptions.SkipInvalidStation = modXML.GetAttributeValue(oXMLRoot, "skipinvalidstation", True)
            oOptions.UseDropForInclination = modXML.GetAttributeValue(oXMLRoot, "usedropforinclination", False)
            oOptions.PlanScaleType = modXML.GetAttributeValue(oXMLRoot, "planscaletype", cResurvey.cOptions.ScaleTypeEnum.Distance)
            oOptions.DropScaleType = modXML.GetAttributeValue(oXMLRoot, "dropscaletype", cResurvey.cOptions.ScaleTypeEnum.DeltaY)

            oOptions.LRUDStation = modXML.GetAttributeValue(oXMLRoot, "lrudstation", 1)
            oOptions.CalculateLRUD = modXML.GetAttributeValue(oXMLRoot, "calculatelrud", 0)
            oOptions.LRUDBorderWidth = modXML.GetAttributeValue(oXMLRoot, "lrudborderwidth", 3)
            oOptions.LRMaxValue = modNumbers.StringToSingle(modXML.GetAttributeValue(oXMLRoot, "lrmaxvalue", 5))
            oOptions.UDMaxValue = modNumbers.StringToSingle(modXML.GetAttributeValue(oXMLRoot, "udmaxvalue", 10))

            Call pSetCalculateMode()

            Text = "cResurvey - " & sFilename

            sPlanZoom = 1
            sProfileZoom = 1
            If oFile.FileFormat = cFile.FileFormatEnum.CRSX Then
                Dim sBasepath As String = Path.GetDirectoryName(sFilename)
                sPlanImage = oXMLRoot.GetAttribute("planimage")
                If sPlanImage <> "" Then
                    Try
                        Dim oPlanImage As Image = pImageLoad(sBasepath, sPlanImage)
                        picPlan.Image = oPlanImage
                        If Not oPlanImage Is Nothing Then
                            picPlan.AutoSize = False
                            picPlan.Size = picPlan.Image.Size
                            picPlan.SizeMode = PictureBoxSizeMode.Zoom
                            picPlan.Visible = True
                        End If
                    Catch ex As Exception
                        picPlan.Visible = False
                    End Try
                End If
                sProfileImage = oXMLRoot.GetAttribute("profileimage")
                If sProfileImage <> "" Then
                    Try
                        Dim oprofileImage As Image = pImageLoad(sBasepath, sProfileImage)
                        picProfile.Image = oprofileImage
                        If Not oprofileImage Is Nothing Then
                            picProfile.AutoSize = False
                            picProfile.Size = picProfile.Image.Size
                            picProfile.SizeMode = PictureBoxSizeMode.Zoom
                            picProfile.Visible = True
                        End If
                    Catch ex As Exception
                        picProfile.Visible = False
                    End Try
                End If
            Else
                Try
                    sPlanImage = "plan.png"
                    Dim oPlanImage As Image = New Bitmap(DirectCast(oFile.Data(sPlanImage), cSurvey.Storage.cStorageItemFile).Stream)
                    picPlan.Image = oPlanImage
                    If Not oPlanImage Is Nothing Then
                        picPlan.Size = oPlanImage.Size
                        picPlan.SizeMode = PictureBoxSizeMode.Zoom
                        picPlan.Visible = True
                    End If
                Catch ex As Exception
                    sPlanImage = ""
                    picPlan.Visible = False
                End Try
                Try
                    sProfileImage = "profile.png"
                    Dim oprofileImage As Image = New Bitmap(DirectCast(oFile.Data(sProfileImage), cSurvey.Storage.cStorageItemFile).Stream)
                    picProfile.Image = oprofileImage
                    If Not oprofileImage Is Nothing Then
                        picProfile.Size = oprofileImage.Size
                        picProfile.SizeMode = PictureBoxSizeMode.Zoom
                        picProfile.Visible = True
                    End If
                Catch ex As Exception
                    sProfileImage = ""
                    picProfile.Visible = False
                End Try
            End If

            Call oShots.Clear()

            If modXML.ChildElementExist(oXMLRoot, "shots") Then
                For Each oXMLShot As XmlElement In oXMLRoot.Item("shots").ChildNodes
                    Dim oShot As cShot = New cShot(oXMLShot.GetAttribute("from"), oXMLShot.GetAttribute("to"))
                    If modXML.HasAttribute(oXMLShot, "l") Then oShot.UserLeft = modXML.GetAttributeValue(oXMLShot, "l")
                    If modXML.HasAttribute(oXMLShot, "r") Then oShot.UserRight = modXML.GetAttributeValue(oXMLShot, "r")
                    If modXML.HasAttribute(oXMLShot, "u") Then oShot.UserUp = modXML.GetAttributeValue(oXMLShot, "u")
                    If modXML.HasAttribute(oXMLShot, "d") Then oShot.UserDown = modXML.GetAttributeValue(oXMLShot, "d")
                Next
            End If

            Call grdShots.RefreshDataSource()

            Call oPlanTrigpointsPlaceholders.Clear()
            Call oProfileTrigpointsPlaceholders.Clear()

            Call oStations.Clear()
            Call grdStations.RefreshDataSource()

            Dim oXMLStations As XmlElement = oXMLRoot.Item("stations")
            For Each oXMLStation As XmlElement In oXMLStations.ChildNodes
                Dim oStation As cResurvey.cStation = New cResurvey.cStation
                oStation.Name = oXMLStation.GetAttribute("name")
                oStation.PlanPoint = pPointFromString(modXML.GetAttributeValue(oXMLStation, "planpoint", ""))
                oStation.ProfilePoint = pPointFromString(modXML.GetAttributeValue(oXMLStation, "profilepoint"))
                oStation.Type = modXML.GetAttributeValue(oXMLStation, "type", "")
                oStation.PlanVisible = modXML.GetAttributeValue(oXMLStation, "planvisible", 1)
                oStation.ProfileVisible = modXML.GetAttributeValue(oXMLStation, "profilevisible", 1)
                If oXMLStation.HasAttribute("nextname") Then
                    Dim sNextName As String = modXML.GetAttributeValue(oXMLStation, "nextname")
                    If oStation.Type = "SE" OrElse oStation.Type = "DSE" Then
                        oStation.Scale = modNumbers.StringToSingle(sNextName)
                    Else
                        oStation.PlanConnectedTo.Add(sNextName)
                        oStation.ProfileConnectedTo.Add(sNextName)
                    End If
                Else
                    Call pGetHashSet(oStation.PlanConnectedTo, modXML.GetAttributeValue(oXMLStation, "planconnectedto", ""))
                    Call pGetHashSet(oStation.ProfileConnectedTo, modXML.GetAttributeValue(oXMLStation, "profileconnectedto", ""))
                    If oStation.Type = "SE" OrElse oStation.Type = "DSE" Then
                        oStation.Scale = modNumbers.StringToSingle(modXML.GetAttributeValue(oXMLStation, "scale", 1))
                    End If
                End If
                Call oStations.Add(oStation)
            Next

            For Each oStation As cResurvey.cStation In oStations
                Dim oConnectionsToDelete As List(Of String) = New List(Of String)

                Call oConnectionsToDelete.Clear()
                For Each sConnectedTo As String In oStation.PlanConnectedTo
                    If Not pPointAsData(sConnectedTo, 0) Then
                        Call oConnectionsToDelete.Add(sConnectedTo)
                    End If
                Next
                For Each sConnectedTo As String In oConnectionsToDelete
                    Call oStation.PlanConnectedTo.Remove(sConnectedTo)
                Next

                Call oConnectionsToDelete.Clear()
                For Each sConnectedTo As String In oStation.ProfileConnectedTo
                    If Not pPointAsData(sConnectedTo, 1) Then
                        Call oConnectionsToDelete.Add(sConnectedTo)
                    End If
                Next
                For Each sConnectedTo As String In oConnectionsToDelete
                    Call oStation.ProfileConnectedTo.Remove(sConnectedTo)
                Next
            Next

            For Each oStation As cResurvey.cStation In oStations
                If Not oStation.PlanPoint.IsEmpty Then
                    oStation.PlanPlaceholder = pAddPoint(0, oStation, oStation.PlanPoint)
                End If
                If Not oStation.ProfilePoint.IsEmpty Then
                    oStation.ProfilePlaceholder = pAddPoint(1, oStation, oStation.ProfilePoint)
                End If
            Next

            Call pPerformCalculate(False)

            Cursor = Cursors.Default

            Call gridviewStations_FocusedRowChanged(Nothing, Nothing)
            Call pChangeCurrentProjection()
            Call pPerformPaint()
        End If
    End Sub

    Private Sub btnLoad_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnLoad.ItemClick
        Call pLoad("")
    End Sub

    Private Function pAddPoint(PlanOrProfile As Integer, Station As cStation, ByVal Location As Point) As cResurvey.cTrigpointPlaceholder
        Dim sStation As String = Station.Name
        Dim sType As String = Station.Type

        Dim oPicture As PictureBox
        If PlanOrProfile = 0 Then
            oPicture = picPlan
        Else
            oPicture = picProfile
        End If
        Using oGraphics As Graphics = oPicture.CreateGraphics
            Dim oNameSize As SizeF = oGraphics.MeasureString(sStation, Font)
            Dim oTPH As cResurvey.cTrigpointPlaceholder = New cResurvey.cTrigpointPlaceholder(PlanOrProfile, sStation, Location, oNameSize.Width)
            If sType <> "" Then
                Select Case sType
                    Case "O"
                        'origin
                        oTPH.BackColor = oOriginColor
                    Case "NB", "NE"
                        'north
                        oTPH.BackColor = oNorthColor
                    Case "SB", "SE"
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
        End Using
    End Function

    'Private Sub picPlan_Click(sender As Object, e As EventArgs) Handles picPlan.Click
    '    Call picPlan.Focus()
    'End Sub

    'Private Sub picProfile_Click(sender As Object, e As EventArgs) Handles picProfile.Click
    '    Call picProfile.Focus()
    'End Sub

    Private Sub pic_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles picPlan.DoubleClick, picProfile.DoubleClick
        Dim oPoint As Point = Cursor.Position
        If pGetCurrentProjection() = 0 Then
            oPoint = picPlan.PointToClient(oPoint)
            oPoint = New Point(oPoint.X / sPlanZoom, oPoint.Y / sPlanZoom)
            If pHitTestPlanRuler(oPoint) Then
                oPlanRulerPosition = oPoint
                pInvalidateCurrentView()
            Else
                Call pAddStation()
            End If
        Else
            oPoint = picProfile.PointToClient(oPoint)
            oPoint = New Point(oPoint.X / sProfileZoom, oPoint.Y / sProfileZoom)
            If pHitTestProfileRuler(oPoint) Then
                oProfileRulerPosition = oPoint
                pInvalidateCurrentView()
            Else
                Call pAddStation()
            End If
        End If

    End Sub

    Private oDragboxFromMouseDown As Rectangle
    Private oDragScreenOffset As Point

    Private bTPHSelected As Boolean
    Private bLineSelected As Boolean

    Private Sub picPlan_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picPlan.MouseDown
        Call dockPlan.Focus()

        If (My.Computer.Keyboard.CtrlKeyDown AndAlso (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left) OrElse (e.Button And Windows.Forms.MouseButtons.Middle) = Windows.Forms.MouseButtons.Middle Then
            oPlanStartPoint = e.Location
            oPlanStartPoint = picPlan.PointToScreen(oPlanStartPoint)
        Else
            picPlan.Cursor = Cursors.Cross

            Dim oPoint As Point = New Point(e.Location.X / sPlanZoom, e.Location.Y / sPlanZoom)
            pnlCoordinates.Caption = "X: " & oPoint.X & " px; Y: " & oPoint.Y & " px"

            oPlanLastMousePoint = oPoint
            Try
                If pHitTestPlanRuler(oPlanLastMousePoint) Then
                    picPlan.Cursor = oClosedHandCursor
                    oPlanRulerMovePoint = oPoint
                    bPlanRulerMovePoint = True
                Else
                    Dim oTPH As cResurvey.cTrigpointPlaceholder = pHitTestPlanPlaceholder(oPlanLastMousePoint)
                    Dim oLine As cResurvey.cTrigpointPlaceholder()
                    If oTPH Is Nothing Then
                        oDragboxFromMouseDown = Rectangle.Empty
                        oLine = pHitTestPlanLine(oPoint)
                    Else
                        Dim oDragSize As Size = SystemInformation.DragSize
                        oDragboxFromMouseDown = New Rectangle(New Point(oPoint.X - (oDragSize.Width / 2) / sPlanZoom, oPoint.Y - (oDragSize.Height / 2) / sPlanZoom), oDragSize)
                    End If

                    If Not oPlanLastPlaceHolder Is oTPH OrElse Not oPlanLastLine Is oLine Then
                        If oLine Is Nothing AndAlso Not oTPH Is Nothing Then
                            Call pSelectLine(Nothing)
                            Call pSelectPlaceholder(oTPH)
                            bTPHSelected = Not oTPH Is Nothing
                            Ribbon.SelectedPage = pageWorkflow
                        ElseIf Not oLine Is Nothing Then
                            Call pSelectLine(oLine)
                            bLineSelected = Not oLine Is Nothing
                            Ribbon.SelectedPage = pageWorkflow
                        Else
                            Call pSelectLine(Nothing)
                            Call pSelectPlaceholder(Nothing)
                        End If
                        Call pInvalidateCurrentView()
                    End If
                End If
            Catch
            End Try
        End If
    End Sub

    Private Sub picProfile_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picProfile.MouseDown
        Call dockProfile.Focus()

        If (My.Computer.Keyboard.CtrlKeyDown AndAlso (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left) OrElse (e.Button And Windows.Forms.MouseButtons.Middle) = Windows.Forms.MouseButtons.Middle Then
            oProfileStartPoint = e.Location
            oProfileStartPoint = picProfile.PointToScreen(oProfileStartPoint)
        Else
            picProfile.Cursor = Cursors.Cross

            Dim oPoint As Point = New Point(e.Location.X / sProfileZoom, e.Location.Y / sProfileZoom)
            pnlCoordinates.Caption = "X: " & oPoint.X & " px; Y: " & oPoint.Y & " px"

            oProfileLastMousePoint = oPoint
            Try
                If pHitTestProfileRuler(oProfileLastMousePoint) Then
                    picProfile.Cursor = oClosedHandCursor
                    oProfileRulerMovePoint = oPoint
                    bProfileRulerMovePoint = True
                Else
                    Dim oTPH As cResurvey.cTrigpointPlaceholder = pHitTestProfilePlaceholder(oProfileLastMousePoint)
                    Dim oLine As cResurvey.cTrigpointPlaceholder()
                    If oTPH Is Nothing Then
                        oDragboxFromMouseDown = Rectangle.Empty
                        oLine = pHitTestProfileLine(oPoint)
                    Else
                        Dim oDragSize As Size = SystemInformation.DragSize
                        oDragboxFromMouseDown = New Rectangle(New Point(oPoint.X - (oDragSize.Width / 2) / sProfileZoom, oPoint.Y - (oDragSize.Height / 2) / sProfileZoom), oDragSize)
                    End If

                    If Not oProfileLastPlaceHolder Is oTPH OrElse Not oProfileLastLine Is oLine Then
                        If oLine Is Nothing AndAlso Not oTPH Is Nothing Then
                            Call pSelectLine(Nothing)
                            Call pSelectPlaceholder(oTPH)
                            bTPHSelected = Not oTPH Is Nothing
                            Ribbon.SelectedPage = pageWorkflow
                        ElseIf Not oLine Is Nothing Then
                            Call pSelectLine(oLine)
                            bLineSelected = Not oLine Is Nothing
                            Ribbon.SelectedPage = pageWorkflow
                        Else
                            Call pSelectLine(Nothing)
                            Call pSelectPlaceholder(Nothing)
                        End If
                        Call pInvalidateCurrentView()
                    End If
                End If
            Catch
            End Try
        End If
    End Sub

    Private Sub pSelectLine(NewLine As cTrigpointPlaceholder(), Optional Force As Boolean = False)
        If Not oStations Is Nothing Then
            iEventDisabled += 1
            Select Case pGetCurrentProjection()
                Case 0
                    If Not oPlanLastLine Is NewLine OrElse Force Then
                        oPlanLastLine = NewLine
                        If oPlanLastLine Is Nothing Then
                            grpLinks.Enabled = False
                            btnDeleteLink.Enabled = False

                            Call tbPlan.Hide()
                        Else
                            grpLinks.Enabled = True
                            btnRulerAlignTo.Enabled = btnShowRuler.Enabled AndAlso btnShowRuler.Checked
                            btnDeleteLink.Enabled = True
                            Call pSelectPlaceholder(oPlanLastLine(0))
                        End If
                    End If
                Case 1
                    If Not oProfileLastLine Is NewLine OrElse Force Then
                        oProfileLastLine = NewLine
                        If oProfileLastLine Is Nothing Then
                            grpLinks.Enabled = False
                            btnDeleteLink.Enabled = False

                            Call tbProfile.Hide()
                        Else
                            grpLinks.Enabled = True
                            btnRulerAlignTo.Enabled = btnShowRuler.Enabled AndAlso btnShowRuler.Checked
                            btnDeleteLink.Enabled = True
                            Call pSelectPlaceholder(oProfileLastLine(0))
                        End If
                    End If
            End Select
            iEventDisabled -= 1
        End If
    End Sub

    Private Sub pSelectPlaceholder(NewPlaceholder As cTrigpointPlaceholder, Optional Force As Boolean = False)
        If Not oStations Is Nothing Then
            iEventDisabled += 1
            Dim iHighlightRowHandle As Integer = 0

            Call gridviewStations.BeginUpdate()

            If Not NewPlaceholder Is Nothing Then
                Dim iFocusedRowHandle As Integer = gridviewStations.FindRow(oStations(NewPlaceholder.Name))
                If iFocusedRowHandle <> gridviewStations.FocusedRowHandle Then
                    gridviewStations.FocusedRowHandle = iFocusedRowHandle
                    Call gridviewStations.ClearSelection()
                    Call gridviewStations.SelectRow(iFocusedRowHandle)
                    iHighlightRowHandle = iFocusedRowHandle
                End If
            End If
            Dim oStation As cStation = gridviewStations.GetFocusedRow

            btnDeleteAll2.Enabled = oStations.Count > 0
            If oStation Is Nothing Then
                grpStations.Enabled = False
                grpPlaceholders.Enabled = False
                grpLinks.Enabled = False
                btnDeleteLink.Enabled = False
            Else
                grpStations.Enabled = True
                Select Case pGetCurrentProjection()
                    Case 0
                        If Not oPlanLastPlaceHolder Is NewPlaceholder OrElse Force Then
                            btnRemoveAll2.Enabled = oPlanTrigpointsPlaceholders.Count > 0
                            btnProperties2.Enabled = True
                            btnSetOrigin2.Enabled = (oStation.Type = "")

                            oPlanLastPlaceHolder = NewPlaceholder
                            If oPlanLastPlaceHolder Is Nothing Then
                                grpPlaceholders.Enabled = False
                                btnRemove2.Enabled = False

                                Call tbPlan.Hide()
                            Else
                                grpPlaceholders.Enabled = True

                                btnRulerCenterHere.Enabled = btnShowRuler.Enabled AndAlso btnShowRuler.Checked
                                btnDelete2.Enabled = True
                                btnRemove2.Enabled = True
                                If pGetCurrentProjection() = 0 Then
                                    btnVisible.EditValue = oStation.PlanVisible
                                Else
                                    btnVisible.EditValue = oStation.ProfileVisible
                                End If
                                btnVisible.Enabled = True
                            End If
                        End If
                    Case 1
                        If Not oProfileLastPlaceHolder Is NewPlaceholder OrElse Force Then
                            btnRemoveAll2.Enabled = oProfileTrigpointsPlaceholders.Count > 0
                            btnProperties2.Enabled = True
                            btnSetOrigin2.Enabled = (oStation.Type = "")

                            oProfileLastPlaceHolder = NewPlaceholder
                            If oProfileLastPlaceHolder Is Nothing Then
                                grpPlaceholders.Enabled = False
                                btnRemove2.Enabled = False

                                tbProfile.Hide()
                            Else
                                grpPlaceholders.Enabled = True
                                btnRulerCenterHere.Enabled = btnShowRuler.Enabled AndAlso btnShowRuler.Checked
                                btnDelete2.Enabled = True
                                btnRemove2.Enabled = True
                                If pGetCurrentProjection() = 0 Then
                                    btnVisible.EditValue = oStation.PlanVisible
                                Else
                                    btnVisible.EditValue = oStation.ProfileVisible
                                End If
                                btnVisible.Enabled = True
                            End If
                        End If
                End Select
            End If
            If iHighlightRowHandle <> 0 Then Call gridviewStations.MakeRowVisible(iHighlightRowHandle)

            iEventDisabled -= 1
            Call gridviewStations.EndUpdate()
        End If
    End Sub

    Private Function pContainsType(Type As String) As Boolean
        For Each oStation As cResurvey.cStation In oStations
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

    Private Function pContainsFirstNorth() As Boolean
        Return pContainsType("NB")
    End Function

    Private Function pContainsSecondNorth() As Boolean
        Return pContainsType("NE")
    End Function

    Private Sub pAddStation()
        Dim iPlanOrProfile As Integer = pGetCurrentProjection()
        Dim oLastMousePoint As Point
        Select Case iPlanOrProfile
            Case 0
                oLastMousePoint = oPlanLastMousePoint
            Case 1
                oLastMousePoint = oProfileLastMousePoint
        End Select

        Dim oPreviousStation As cStation = pGetFocusedStation()

        Dim sPrevType As String = ""
        If Not oPreviousStation Is Nothing Then
            sPrevStation = oPreviousStation.Name
            sPrevType = oPreviousStation.Type
            If sPrevType = "SB" OrElse sPrevType = "SE" OrElse sPrevType = "DSB" OrElse sPrevType = "DSE" OrElse sPrevType = "NB" OrElse sPrevType = "NE" Then sPrevStation = ""
        Else
            sPrevStation = ""
            sPrevType = ""
        End If

        Using frmRAS As frmResurveyAddStation = New frmResurveyAddStation(iPlanOrProfile, oStations, sPrevStation, oLastMousePoint)
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
                    .optNorthBegin.Enabled = Not pContainsFirstNorth()
                    .optNorthEnd.Enabled = Not pContainsSecondNorth()
                Else
                    If oOptions.UseDropForInclination Then
                        .optFirstScale.Enabled = Not pContainsFirstDropScale()
                        .optSecondScale.Enabled = Not pContainsSecondDropScale()
                    Else
                        .optFirstScale.Enabled = Not pContainsFirstScale()
                        .optSecondScale.Enabled = Not pContainsSecondScale()
                    End If
                    .optNorthBegin.Enabled = False
                    .optNorthEnd.Enabled = False
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
                        Do While oStations.Contains(sStation)
                            sStation &= ">"
                        Loop
                        sPrevStation = pGetRealStation(sStation)
                        If oStations.Contains(sPrevStation) Then sPrevType = oStations(sPrevStation).Type
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

                    If .optNorthBegin.Checked Then
                        sStation = "_N1"
                        sType = "NB"
                    End If
                    If .optNorthEnd.Checked Then
                        sStation = "_N2"
                        sType = "NE"
                    End If

                    If oStations.Contains(sStation) Then
                        Dim oStation As cResurvey.cStation = oStations(sStation)
                        If iPlanOrProfile = 0 Then
                            oStation.PlanPoint = oLastMousePoint
                        Else
                            oStation.ProfilePoint = oLastMousePoint
                        End If

                        If iPlanOrProfile = 0 Then
                            oStation.PlanPlaceholder = pAddPoint(iPlanOrProfile, oStation, oLastMousePoint)

                            If sPrevStation <> "" AndAlso (sPrevType = "" OrElse sPrevType = "O") AndAlso (sType <> "SB" AndAlso sType <> "SE") AndAlso (sType <> "DSB" AndAlso sType <> "DSE") AndAlso (sType <> "NB" AndAlso sType <> "NE") Then
                                Dim oPrevStation As cResurvey.cStation = oStations(sPrevStation)
                                If Not oPrevStation.PlanConnectedTo.Contains(sStation) Then
                                    Call oPrevStation.PlanConnectedTo.Add(sStation)
                                End If
                            End If
                        Else
                            oStation.ProfilePlaceholder = pAddPoint(iPlanOrProfile, oStation, oLastMousePoint)

                            If sPrevStation <> "" AndAlso (sPrevType = "" OrElse sPrevType = "O") AndAlso (sType <> "SB" AndAlso sType <> "SE") AndAlso (sType <> "DSB" AndAlso sType <> "DSE") AndAlso (sType <> "NB" AndAlso sType <> "NE") Then
                                Dim oPrevStation As cResurvey.cStation = oStations(sPrevStation)
                                If Not oPrevStation.ProfileConnectedTo.Contains(sStation) Then
                                    Call oPrevStation.ProfileConnectedTo.Add(sStation)
                                End If
                            End If
                        End If
                    Else
                        If iPlanOrProfile = 0 Then
                            If sPrevStation <> "" AndAlso (sPrevType = "" OrElse sPrevType = "O") AndAlso (sType <> "SB" AndAlso sType <> "SE") AndAlso (sType <> "DSB" AndAlso sType <> "DSE") AndAlso (sType <> "NB" AndAlso sType <> "NE") Then
                                Dim oPrevStation As cResurvey.cStation = oStations(sPrevStation)
                                If Not oPrevStation.PlanConnectedTo.Contains(sStation) Then
                                    Call oPrevStation.PlanConnectedTo.Add(sStation)
                                End If
                            End If
                        Else
                            If sPrevStation <> "" AndAlso (sPrevType = "" OrElse sPrevType = "O") AndAlso (sType <> "SB" AndAlso sType <> "SE") AndAlso (sType <> "DSB" AndAlso sType <> "DSE") AndAlso (sType <> "NB" AndAlso sType <> "NE") Then
                                Dim oPrevStation As cResurvey.cStation = oStations(sPrevStation)
                                If Not oPrevStation.ProfileConnectedTo.Contains(sStation) Then
                                    Call oPrevStation.ProfileConnectedTo.Add(sStation)
                                End If
                            End If
                        End If

                        Dim oStation As cResurvey.cStation = New cResurvey.cStation
                        oStation.Name = sStation
                        If iPlanOrProfile = 0 Then
                            oStation.PlanPoint = oLastMousePoint
                        Else
                            oStation.ProfilePoint = oLastMousePoint
                        End If
                        If sType = "SE" Or sType = "DSE" Then
                            oStation.Scale = iScaleLen
                        End If
                        oStation.Type = sType

                        If iPlanOrProfile = 0 Then
                            oStation.PlanPlaceholder = pAddPoint(iPlanOrProfile, oStation, oLastMousePoint)
                        Else
                            oStation.ProfilePlaceholder = pAddPoint(iPlanOrProfile, oStation, oLastMousePoint)
                        End If

                        Call oStations.Add(oStation)

                        Call grdStations.RefreshDataSource()
                    End If

                    Call gridviewStations.BeginUpdate()
                    Dim iFocusedRowHandle As Integer = gridviewStations.FindRow(oStations)
                    gridviewStations.FocusedRowHandle = iFocusedRowHandle
                    Call gridviewStations.ClearSelection()
                    Call gridviewStations.SelectRow(iFocusedRowHandle)
                    Call gridviewStations_FocusedRowChanged(Nothing, Nothing)
                    Call gridviewStations.EndUpdate()
                    Call gridviewStations.MakeRowVisible(iFocusedRowHandle)
                    Call pDelayedPerformPaint()
                End If
            End With
        End Using
    End Sub

    Private Sub mnuPreviewAdd_Click(sender As System.Object, e As System.EventArgs)
        Call pAddStation()
    End Sub

    Private Sub mnuPreviewRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox(GetLocalizedString("resurvey.warning1"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, GetLocalizedString("resurvey.warningtitle")) = MsgBoxResult.Yes Then
            If pGetCurrentProjection() = 0 Then
                Call pRemoveTrigPoints(0)
            Else
                Call pRemoveTrigPoints(1)
            End If
        End If
    End Sub

    'Private Sub pHideTrigPoints(PlanOrProfile As Integer)
    '    If PlanOrProfile = 0 Then
    '        For Each oTPH As cResurvey.cTrigpointPlaceholder In oPlanTrigpointsPlaceholders.Values
    '            oTPH.Visible = False
    '        Next
    '    Else
    '        For Each oTPH As cResurvey.cTrigpointPlaceholder In oProfileTrigpointsPlaceholders.Values
    '            oTPH.Visible = False
    '        Next
    '    End If
    '    Call pInvalidateCurrentView()
    'End Sub

    'Private Sub pShowHiddenTrigPoints(PlanOrProfile As Integer)
    '    If PlanOrProfile = 0 Then
    '        For Each oTPH As cResurvey.cTrigpointPlaceholder In oPlanTrigpointsPlaceholders.Values
    '            oTPH.Visible = True
    '        Next
    '    Else
    '        For Each oTPH As cResurvey.cTrigpointPlaceholder In oProfileTrigpointsPlaceholders.Values
    '            oTPH.Visible = True
    '        Next
    '    End If
    '    Call pInvalidateCurrentView()
    'End Sub

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
        Call grdStations.RefreshDataSource()
        Call pPerformPaint()
        Call pInvalidateCurrentView()
    End Sub

    Private Sub mnuPreviewRemove_Click(sender As System.Object, e As System.EventArgs)
        Call pPlaceHolderDelete()
    End Sub

    Private Sub pPlaceHolderDelete()
        Select Case pGetCurrentProjection()
            Case 0
                pGetSelectedStations.ForEach(Sub(oItem)
                                                 oItem.PlanPoint = Nothing
                                                 oItem.PlanPlaceholder = Nothing
                                                 oPlanTrigpointsPlaceholders.Remove(oItem.Name)
                                                 Dim oStation As cStation = oStations(oItem.Name)
                                                 If oStation.Type = "DSB" OrElse oStation.Type = "DSE" Then
                                                     Call oStations.Remove(oStation)
                                                 ElseIf oStation.Type = "SB" OrElse oStation.Type = "SE" Then
                                                     Call oStations.Remove(oStation)
                                                 ElseIf oStation.Type = "NB" OrElse oStation.Type = "NE" Then
                                                     Call oStations.Remove(oStation)
                                                 End If
                                             End Sub)
            Case 1
                pGetSelectedStations.ForEach(Sub(oItem)
                                                 oItem.ProfilePoint = Nothing
                                                 oItem.ProfilePlaceholder = Nothing
                                                 oProfileTrigpointsPlaceholders.Remove(oItem.Name)
                                                 Dim oStation As cStation = oStations(oItem.Name)
                                                 If oStation.Type = "DSB" OrElse oStation.Type = "DSE" Then
                                                     Call oStations.Remove(oStation)
                                                 ElseIf oStation.Type = "SB" OrElse oStation.Type = "SE" Then
                                                     Call oStations.Remove(oStation)
                                                 ElseIf oStation.Type = "NB" OrElse oStation.Type = "NE" Then
                                                     Call oStations.Remove(oStation)
                                                 End If
                                             End Sub)
        End Select
        Call grdStations.RefreshDataSource()
        Call pSelectPlaceholder(Nothing)
        Call pDelayedPerformPaint()
    End Sub

    Private Sub pSetStatus(Text As String)
        pnlStatus.Caption = Text
    End Sub

    Private Sub btnLoadImage_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnLoadImage.ItemClick
        Call pImageLoad()
    End Sub

    Private Sub btnSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSave.ItemClick
        Call pSave(sFilename)
    End Sub

    Private Sub pSave(Filename As String)
        If Filename = "" Then
            Using oSFD As SaveFileDialog = New SaveFileDialog
                With oSFD
                    .OverwritePrompt = True
                    .Filter = GetLocalizedString("resurvey.filetypeCRSZ") & " (*.CRSZ)|*.CRSZ|" & GetLocalizedString("resurvey.filetypeCRSX") & " (*.CRSX)|*.CRSX"
                    .FilterIndex = 1
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        Filename = .FileName
                    End If
                End With
            End Using
        End If

        If Filename <> "" Then
            Cursor = Cursors.WaitCursor

            sFilename = Filename

            Text = "cResurvey - " & sFilename
            Dim oFile As cResurvey.cFile = New cResurvey.cFile(cFile.FileFormatEnum.Auto, sFilename)

            Dim oXML As XmlDocument = oFile.Document
            Dim oXMLRoot As XmlElement = oXML.CreateElement("cresurvey")
            oXMLRoot.SetAttribute("v", modMain.GetPackageVersion)

            Call oXMLRoot.SetAttribute("calculatemode", oOptions.CalculateMode.ToString("D"))
            Call oXMLRoot.SetAttribute("profiletype", oOptions.ProfileType.ToString("D"))
            Call oXMLRoot.SetAttribute("nordcorrection", modNumbers.NumberToString(oOptions.NordCorrection))
            Call oXMLRoot.SetAttribute("skipinvalidstation", If(oOptions.SkipInvalidStation, "1", "0"))
            Call oXMLRoot.SetAttribute("usedropforinclination", If(oOptions.UseDropForInclination, "1", "0"))
            If oOptions.PlanScaleType <> cOptions.ScaleTypeEnum.Distance Then Call oXMLRoot.SetAttribute("planscaletype", oOptions.PlanScaleType.ToString("D"))
            If oOptions.DropScaleType <> cOptions.ScaleTypeEnum.DeltaY Then Call oXMLRoot.SetAttribute("dropscaletype", oOptions.DropScaleType.ToString("D"))

            Call oXMLRoot.SetAttribute("lrudstation", oOptions.LRUDStation.ToString("D"))
            Call oXMLRoot.SetAttribute("calculatelrud", If(oOptions.CalculateLRUD, "1", "0"))
            Call oXMLRoot.SetAttribute("lrudborderwidth", oOptions.LRUDBorderWidth, oOptions.LRUDBorderWidth)
            Call oXMLRoot.SetAttribute("lrmaxvalue", oOptions.LRMaxValue, modNumbers.NumberToString(oOptions.LRMaxValue, "0.0"))
            Call oXMLRoot.SetAttribute("udmaxvalue", oOptions.UDMaxValue, modNumbers.NumberToString(oOptions.UDMaxValue, "0.0"))

            If oFile.FileFormat = cFile.FileFormatEnum.CRSX Then
                If picPlan.Image Is Nothing Then
                    Call oXMLRoot.SetAttribute("planimage", "")
                Else
                    sPlanImage = Path.Combine(Path.GetDirectoryName(sFilename), Path.GetFileNameWithoutExtension(sFilename) & "_plan.png")
                    If My.Computer.FileSystem.FileExists(sPlanImage) Then My.Computer.FileSystem.DeleteFile(sPlanImage)
                    Call picPlan.Image.Save(sPlanImage, Imaging.ImageFormat.Png)
                    Call oXMLRoot.SetAttribute("planimage", sPlanImage)
                End If
                If picProfile.Image Is Nothing Then
                    Call oXMLRoot.SetAttribute("profileimage", "")
                Else
                    sProfileImage = Path.Combine(Path.GetDirectoryName(sFilename), Path.GetFileNameWithoutExtension(sFilename) & "_profile.png")
                    Call picProfile.Image.Save(sProfileImage, Imaging.ImageFormat.Png)
                    If My.Computer.FileSystem.FileExists(sProfileImage) Then My.Computer.FileSystem.DeleteFile(sProfileImage)
                    Call oXMLRoot.SetAttribute("profileimage", sProfileImage)
                End If
            Else
                If Not picPlan.Image Is Nothing Then Call picPlan.Image.Save(oFile.Data.AddFile("plan.png").Stream, Imaging.ImageFormat.Png)
                If Not picProfile.Image Is Nothing Then Call picProfile.Image.Save(oFile.Data.AddFile("profile.png").Stream, Imaging.ImageFormat.Png)
            End If

            Dim oXMLStations As XmlElement = oXML.CreateElement("stations")
            For Each oStation As cResurvey.cStation In oStations
                Dim oXMLStation As XmlElement = oXML.CreateElement("station")
                Call oXMLStation.SetAttribute("name", oStation.Name)
                Call oXMLStation.SetAttribute("planpoint", pPointToString(oStation.PlanPoint))
                Call oXMLStation.SetAttribute("profilepoint", pPointToString(oStation.ProfilePoint))
                Call oXMLStation.SetAttribute("planconnectedto", oStation.PlanConnectedToString)
                Call oXMLStation.SetAttribute("profileconnectedto", oStation.ProfileConnectedToString)

                If Not oStation.PlanVisible Then Call oXMLStation.SetAttribute("planvisible", "0")
                If Not oStation.ProfileVisible Then Call oXMLStation.SetAttribute("profilevisible", "0")

                Call oXMLStation.SetAttribute("type", oStation.Type)
                If oStation.Type = "SE" OrElse oStation.Type = "DSE" Then
                    Call oXMLStation.SetAttribute("scale", modNumbers.NumberToString(oStation.Scale))
                End If
                Call oXMLStations.AppendChild(oXMLStation)
            Next
            Call oXMLRoot.AppendChild(oXMLStations)

            Dim oXMLShots As XmlElement = oXML.CreateElement("shots")
            For Each oShot As cShot In oShots
                If oShot.UserLeft.HasValue OrElse oShot.UserRight.HasValue OrElse oShot.UserUp.HasValue OrElse oShot.UserDown.HasValue Then
                    Dim oXMLShot As XmlElement = oXML.CreateElement("shot")
                    Call oXMLShot.SetAttribute("from", oShot.From)
                    Call oXMLShot.SetAttribute("to", oShot.To)
                    If oShot.UserLeft.HasValue Then oXMLShot.SetAttribute("l", modNumbers.NumberToString(oShot.UserLeft.Value, "0.00"))
                    If oShot.UserRight.HasValue Then oXMLShot.SetAttribute("r", modNumbers.NumberToString(oShot.UserRight.Value, "0.00"))
                    If oShot.UserUp.HasValue Then oXMLShot.SetAttribute("u", modNumbers.NumberToString(oShot.UserUp.Value, "0.00"))
                    If oShot.UserDown.HasValue Then oXMLShot.SetAttribute("d", modNumbers.NumberToString(oShot.UserDown.Value, "0.00"))
                    Call oXMLShots.AppendChild(oXMLShot)
                End If
            Next
            Call oXMLRoot.AppendChild(oXMLShots)

            Call oXML.AppendChild(oXMLRoot)

            Call oFile.Save()

            Cursor = Cursors.Default
        End If
    End Sub

    Private Function pGetPointByType([Type] As String) As String
        For Each oStation As cResurvey.cStation In oStations
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

    Private Function pGetSecondNorthPoint() As String
        Return pGetPointByType("NE")
    End Function

    Private Function pGetFirstNorthPoint() As String
        Return pGetPointByType("NB")
    End Function

    Private Function pGetFirstStation() As String
        Return pGetPointByType("O")
    End Function

    Private Function pGetNextStation(PlanOrProfile As Integer, Name As String) As List(Of String)
        Dim oConnectedTo As List(Of String) = New List(Of String)
        If oStations.Contains(Name) Then
            Dim oStation As cResurvey.cStation = oStations(Name)

            If oStation.Type = "" Or oStation.Type = "O" Then
                If PlanOrProfile = 0 Then
                    Call oConnectedTo.AddRange(oStation.PlanConnectedTo)
                Else
                    Call oConnectedTo.AddRange(oStation.ProfileConnectedTo)
                End If
            End If

            For Each oStation In oStations
                If oStation.Type = "" Or oStation.Type = "O" Then
                    If PlanOrProfile = 0 Then
                        If oStation.PlanConnectedTo.Contains(Name) Then
                            Call oConnectedTo.Add(oStation.Name)
                        End If
                    Else
                        If oStation.ProfileConnectedTo.Contains(Name) Then
                            Call oConnectedTo.Add(oStation.Name)
                        End If
                    End If
                End If
            Next

            Dim bOk As Boolean = False
            Dim oCheckConnectedTo As List(Of String) = New List(Of String)(oConnectedTo)
            For Each sStation As String In oCheckConnectedTo
                If oStations.Contains(sStation) Then
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

    'Private Sub pAppendConnection(Placeholders As Dictionary(Of String, cResurvey.cTrigpointPlaceholder), [From] As String, [To] As String)
    '    If Placeholders.ContainsKey([From]) And Placeholders.ContainsKey([To]) Then
    '        Call Placeholders([From]).Connections.Add(Placeholders([To]))
    '    End If
    'End Sub

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
        Dim sDirected As String = sFrom & vbTab & sTo ' cResurvey.cShots.GetKey(sFrom, [sTo])
        Dim sInverted As String = sTo & vbTab & sFrom ' cResurvey.cShots.GetKey([sTo], sFrom)
        Return Processed.Contains(sDirected) Or Processed.Contains(sInverted)
    End Function

    Private Sub pPaintShots(PlanOrProfile As Integer, Processed As List(Of String), Station As String, Scale As cScale)
        If Station <> "" Then
            Dim oNextStations As List(Of String) = pGetNextStation(PlanOrProfile, Station)
            For Each sNextStation As String In oNextStations
                If Not pJustProcessed(Processed, Station, sNextStation) Then
                    Call pPaintShot(PlanOrProfile, Processed, Station, sNextStation, Scale)
                End If
            Next
        End If
    End Sub

    Private iLRUDCapSize As Integer = 4

    Private Sub pPaintShot(PlanOrProfile As Integer, Processed As List(Of String), Station As String, NextStation As String, Scale As cScale)
        If NextStation <> "" Then
            Select Case PlanOrProfile
                Case 0
                    Dim oPlanFromPoint As PointF = pGetPoint(Station, 0)
                    Dim oPlanToPoint As Point = pGetPoint(NextStation, 0)
                    If Not oPlanFromPoint.IsEmpty And Not oPlanToPoint.IsEmpty Then
                        Dim oPlanShotPath As GraphicsPath = New GraphicsPath
                        Call oPlanShotPath.AddLine(oPlanFromPoint, oPlanToPoint)
                        Dim oItem As cCacheItem = oPlanTrigpointsPlaceholders(Station).Cache.AddPlanShot(NextStation, oPlanShotPath)

                        If oOptions.LRUDStation <> cOptions.LRUDStationEnum.NotManaged Then
                            Dim sKey As String = cShots.GetKey(Station, NextStation)
                            If oShots.Contains(sKey) Then
                                Dim oShot As cShot = oShots(sKey)
                                If Not oShot Is Nothing Then
                                    If oOptions.LRUDStation = cOptions.LRUDStationEnum.FromStation Then
                                        Using oPath As GraphicsPath = New GraphicsPath
                                            Using oAreaPath As GraphicsPath = New GraphicsPath
                                                If oShot.GetLeft > 0 Then
                                                    Call oPath.StartFigure()
                                                    Call oPath.AddLine(New Point(-iLRUDCapSize, -oShot.GetLeft / Scale.PlanScale), New Point(iLRUDCapSize, -oShot.GetLeft / Scale.PlanScale))
                                                End If
                                                Call oPath.StartFigure()
                                                Call oPath.AddLine(New Point(0, -oShot.GetLeft / Scale.PlanScale), New Point(0, oShot.GetRight / Scale.PlanScale))
                                                If oShot.GetRight > 0 Then
                                                    Call oPath.StartFigure()
                                                    Call oPath.AddLine(New Point(-iLRUDCapSize, oShot.GetRight / Scale.PlanScale), New Point(iLRUDCapSize, oShot.GetRight / Scale.PlanScale))
                                                End If
                                                Using oMatrix As Matrix = New Matrix
                                                    Call oMatrix.Translate(oPlanFromPoint.X, oPlanFromPoint.Y, MatrixOrder.Append)
                                                    Call oMatrix.RotateAt(oShot.Bearing - 90, oPlanFromPoint, MatrixOrder.Append)
                                                    Call oPath.Transform(oMatrix)
                                                    Call oAreaPath.Transform(oMatrix)
                                                End Using
                                                If oShot.GetLeft > 0 AndAlso oShot.GetRight > 0 Then
                                                    Call oAreaPath.AddLines({oPath.PathPoints(2), oPath.PathPoints(3), oPlanToPoint, oPath.PathPoints(2)})
                                                ElseIf oShot.GetLeft > 0 Then
                                                    Call oAreaPath.AddLines({oPath.PathPoints(2), oPath.PathPoints(3), oPlanToPoint, oPath.PathPoints(2)})
                                                ElseIf oShot.GetRight > 0 Then
                                                    Call oAreaPath.AddLines({oPath.PathPoints(0), oPath.PathPoints(1), oPlanToPoint, oPath.PathPoints(0)})
                                                End If
                                                Call oItem.SetPath(Nothing, oPath, oAreaPath)
                                            End Using
                                        End Using
                                    Else
                                        Using oPath As GraphicsPath = New GraphicsPath
                                            Using oAreaPath As GraphicsPath = New GraphicsPath
                                                If oShot.GetLeft > 0 Then
                                                    Call oPath.StartFigure()
                                                    Call oPath.AddLine(New Point(-iLRUDCapSize, -oShot.GetLeft / Scale.PlanScale), New Point(iLRUDCapSize, -oShot.GetLeft / Scale.PlanScale))
                                                End If
                                                Call oPath.StartFigure()
                                                Call oPath.AddLine(New Point(0, -oShot.GetLeft / Scale.PlanScale), New Point(0, oShot.GetRight / Scale.PlanScale))
                                                If oShot.GetRight > 0 Then
                                                    Call oPath.StartFigure()
                                                    Call oPath.AddLine(New Point(-iLRUDCapSize, oShot.GetRight / Scale.PlanScale), New Point(iLRUDCapSize, oShot.GetRight / Scale.PlanScale))
                                                End If
                                                Using oMatrix As Matrix = New Matrix
                                                    Call oMatrix.Translate(oPlanToPoint.X, oPlanToPoint.Y, MatrixOrder.Append)
                                                    Call oMatrix.RotateAt(oShot.Bearing - 90, oPlanToPoint, MatrixOrder.Append)
                                                    Call oPath.Transform(oMatrix)
                                                End Using
                                                If oShot.GetLeft > 0 AndAlso oShot.GetRight > 0 Then
                                                    Call oAreaPath.AddLines({oPath.PathPoints(2), oPath.PathPoints(3), oPlanFromPoint, oPath.PathPoints(2)})
                                                ElseIf oShot.GetLeft > 0 Then
                                                    Call oAreaPath.AddLines({oPath.PathPoints(2), oPath.PathPoints(3), oPlanFromPoint, oPath.PathPoints(2)})
                                                ElseIf oShot.GetRight > 0 Then
                                                    Call oAreaPath.AddLines({oPath.PathPoints(0), oPath.PathPoints(1), oPlanFromPoint, oPath.PathPoints(0)})
                                                End If
                                                Call oItem.SetPath(Nothing, oPath, oAreaPath)
                                            End Using
                                        End Using
                                    End If
                                End If
                            End If
                        End If
                    End If
                Case 1
                    Dim oProfileFromPoint As PointF = pGetPoint(Station, 1)
                    Dim oProfileToPoint As Point = pGetPoint(NextStation, 1)
                    If Not oProfileFromPoint.IsEmpty And Not oProfileToPoint.IsEmpty Then
                        Dim oProfileShotPath As GraphicsPath = New GraphicsPath
                        Call oProfileShotPath.AddLine(oProfileFromPoint, oProfileToPoint)
                        Dim oItem As cCacheItem = oProfileTrigpointsPlaceholders(Station).Cache.AddProfileShot(NextStation, oProfileShotPath)

                        If oOptions.LRUDStation <> cOptions.LRUDStationEnum.NotManaged Then
                            Dim sKey As String = cShots.GetKey(Station, NextStation)
                            If oShots.Contains(sKey) Then
                                Dim oShot As cShot = oShots(sKey)
                                If Not oShot Is Nothing Then
                                    Using oPath As GraphicsPath = New GraphicsPath
                                        Using oAreaPath As GraphicsPath = New GraphicsPath
                                            Dim oProfileUpPoint As PointF
                                            Dim oProfileDownPoint As PointF
                                            If oOptions.LRUDStation = cOptions.LRUDStationEnum.FromStation Then
                                                oProfileUpPoint = New PointF(oProfileFromPoint.X, oProfileFromPoint.Y - oShot.GetUp / Scale.ProfileScale)
                                                oProfileDownPoint = New PointF(oProfileFromPoint.X, oProfileFromPoint.Y + oShot.GetDown / Scale.ProfileScale)
                                                Call oAreaPath.AddLines({oProfileUpPoint, oProfileDownPoint, oProfileToPoint, oProfileUpPoint})
                                            Else
                                                oProfileUpPoint = New PointF(oProfileToPoint.X, oProfileToPoint.Y - oShot.GetUp / Scale.ProfileScale)
                                                oProfileDownPoint = New PointF(oProfileToPoint.X, oProfileToPoint.Y + oShot.GetDown / Scale.ProfileScale)
                                                Call oAreaPath.AddLines({oProfileUpPoint, oProfileDownPoint, oProfileFromPoint, oProfileUpPoint})
                                            End If
                                            If oShot.GetUp > 0 Then
                                                Call oPath.StartFigure()
                                                Call oPath.AddLine(New Point(oProfileUpPoint.X - iLRUDCapSize, oProfileUpPoint.Y), New Point(oProfileUpPoint.X + iLRUDCapSize, oProfileUpPoint.Y))
                                            End If
                                            Call oPath.StartFigure()
                                            Call oPath.AddLine(oProfileUpPoint, oProfileDownPoint)
                                            If oShot.GetDown > 0 Then
                                                Call oPath.StartFigure()
                                                Call oPath.AddLine(New Point(oProfileDownPoint.X - iLRUDCapSize, oProfileDownPoint.Y), New Point(oProfileDownPoint.X + iLRUDCapSize, oProfileDownPoint.Y))
                                            End If
                                            Call oItem.SetPath(Nothing, oPath, oAreaPath)
                                        End Using
                                    End Using
                                End If
                            End If
                        End If
                    End If
            End Select
            Call Processed.Add(Station & vbTab & NextStation)
            Station = NextStation
            Call pPaintShots(PlanOrProfile, Processed, Station, Scale)
        End If
    End Sub

    Private Sub btnCalculate_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCalculate.ItemClick
        Call pPerformCalculate()
        If oShots.Count > 0 Then
            Call dockPlot.BringToFront()
            Call dockPlot.Focus()
            btnConfirm.Enabled = True
            btnExport.Enabled = True
        Else
            btnConfirm.Enabled = False
            btnExport.Enabled = False
        End If
    End Sub

    Private Function pGetPoint(Name As String, PlanOrProfile As Integer) As Point
        If oStations.Contains(Name) Then
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
                If oStations.Contains(sSecondScalePoint) Then sScaleSize = oStations(sSecondScalePoint).Scale
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
                    If oStations.Contains(sSecondScalePoint) Then sScaleSize = oStations(sSecondScalePoint).Scale
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
                    If oStations.Contains(sSecondScalePoint) Then sScaleSize = oStations(sSecondScalePoint).Scale
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
            If oStations.Contains(sSecondDropScalePoint) Then sProfileScaleSize = oStations(sSecondDropScalePoint).Scale

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

        Call pSelectLine(Nothing)

        Call pReorderConnections()

        If pContainsFirstNorth() AndAlso pContainsSecondNorth() Then
            oOptions.NordCorrection = modPaint.GetBearing(pGetPoint(pGetFirstNorthPoint, 0), pGetPoint(pGetSecondNorthPoint, 0))
        ElseIf pContainsFirstNorth() OrElse pContainsSecondNorth() Then
            Call pPopupShow("warning", GetLocalizedString("resurvey.warning9"))
        End If

        Dim oBackupShots As cShots = New cShots(oShots)
        Call oShots.Clear()

        Dim oScale As cResurvey.cScale = pGetScale()
        If oScale.PlanError Then
            Call pPopupShow("warning", GetLocalizedString("resurvey.warning2"))
        End If
        If oScale.ProfileError Then
            Call pPopupShow("warning", GetLocalizedString("resurvey.warning2a"))
        End If

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
        End If

        'restore backup data
        For Each oBackupShot As cShot In oBackupShots
            If oShots.Contains(oBackupShot.Key) Then
                Call oShots(oBackupShot.Key).Restore(oBackupShot)
            End If
        Next

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

        grdShots.DataSource = oShots
        Call grdShots.RefreshDataSource()

        grdStations.DataSource = oStations
        Call grdStations.RefreshDataSource()
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
                        sBearing = modNumbers.MathRound(modPaint.NormalizeAngle(sBearing + oOptions.NordCorrection), 2)
                        oShot.Bearing = sBearing
                        oShot.PlanProcessed = True
                    Else
                        Dim sDistance As Single = modPaint.DistancePointToPoint(oPlanFromPoint, oPlanToPoint)
                        Dim sBearing As Single = modPaint.GetBearing(oPlanFromPoint, oPlanToPoint)
                        sImageBearing = sBearing
                        Dim sInclination As Single = 0
                        sDistance = sDistance * Scale
                        sDistance = modNumbers.MathRound(sDistance, 2)
                        sBearing = modNumbers.MathRound(modPaint.NormalizeAngle(sBearing + oOptions.NordCorrection), 2)
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
                    If oOptions.CalculateLRUD Then
                        If oOptions.LRUDStation = cOptions.LRUDStationEnum.ToStation Then
                            pFillLR(oShot, oPlanToPoint, sImageBearing, Scale)
                        ElseIf oOptions.LRUDStation = cOptions.LRUDStationEnum.FromStation Then
                            pFillLR(oShot, oPlanFromPoint, sImageBearing, Scale)
                        End If
                    End If
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
                        If oOptions.CalculateLRUD Then
                            If oOptions.LRUDStation = cOptions.LRUDStationEnum.ToStation Then
                                pFillUD(oShot, oProfileToPoint, Scale)
                            ElseIf oOptions.LRUDStation = cOptions.LRUDStationEnum.FromStation Then
                                pFillUD(oShot, oProfileFromPoint, Scale)
                            End If
                        End If
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
                        If oOptions.CalculateLRUD Then
                            If oOptions.LRUDStation = cOptions.LRUDStationEnum.ToStation Then
                                pFillUD(oShot, oProfileToPoint, Scale)
                            ElseIf oOptions.LRUDStation = cOptions.LRUDStationEnum.FromStation Then
                                pFillUD(oShot, oProfileFromPoint, Scale)
                            End If
                        End If
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
        'oPaintThread = New Threading.Thread(AddressOf pPerformPaint)
        'oPaintThread.IsBackground = True
        'Call oPaintThread.Start()
        Call pPerformPaint()
    End Sub

    Private Sub pPerformPaint()
        Cursor = Cursors.AppStarting

        Dim oScale As cScale = pGetScale()
        'Try
        Dim oProcessed As List(Of String) = New List(Of String)

        Dim sStation As String = pGetFirstStation()

        '--------------------------------------------------------------------------
        'oPlanStationPath = New GraphicsPath
        'oPlanShotsPath = New GraphicsPath
        'oPlanLRUDPath = New GraphicsPath
        'oProfileStationPath = New GraphicsPath
        'oProfileShotsPath = New GraphicsPath
        'oProfileLRUDPath = New GraphicsPath

        oPlanScalePath = New GraphicsPath
        oProfileScalePath = New GraphicsPath
        oProfileDropScalePath = New GraphicsPath
        oPlanScaleRealPath = New GraphicsPath
        oProfileScaleRealPath = New GraphicsPath
        oProfileDropScaleRealPath = New GraphicsPath
        oPlanNorthPath = New GraphicsPath
        '--------------------------------------------------------------------------

        Dim sFirstNorthPoint As String = pGetFirstNorthPoint()
        Dim sSecondNorthPoint As String = pGetSecondNorthPoint()
        Try
            If oStations.Count > 0 AndAlso sFirstNorthPoint <> "" AndAlso sSecondNorthPoint <> "" Then
                Dim oNorthBeginPoint As PointF = oStations(sFirstNorthPoint).PlanPoint
                Dim oNorthEndPoint As PointF = oStations(sSecondNorthPoint).PlanPoint
                Call oPlanNorthPath.AddLine(oNorthBeginPoint, oNorthEndPoint)
            End If
        Catch
        End Try
        '--------------------------------------------------------------------------

        Dim sFirstScalePoint As String = pGetFirstScalePoint()
        Dim sSecondScalePoint As String = pGetSecondScalePoint()

        Try
            If oStations.Count > 0 AndAlso sFirstScalePoint <> "" AndAlso sSecondScalePoint <> "" Then
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
            If oStations.Count > 0 AndAlso sFirstScalePoint <> "" AndAlso sSecondScalePoint <> "" Then
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
            End If
        Catch
        End Try

        '--------------------------------------------------------------------------
        If oStations.Count > 0 AndAlso picPlan.Visible Then
            Using oGraphics As Graphics = picPlan.CreateGraphics
                Using oSF As StringFormat = New StringFormat(Drawing.StringFormatFlags.NoWrap)
                    oSF.Alignment = StringAlignment.Center
                    oSF.LineAlignment = StringAlignment.Center

                    For Each oStation As cResurvey.cStation In oStations
                        If oStation.PlanVisible Then
                            If Not oStation.PlanPoint.IsEmpty Then
                                Dim oPoint As Point = oStation.PlanPoint
                                Dim oTPH As cTrigpointPlaceholder = oPlanTrigpointsPlaceholders(oStation.Name)
                                Dim oNameSize As SizeF = oGraphics.MeasureString(oTPH.Name, Font)
                                Using oPath As GraphicsPath = New GraphicsPath
                                    Call oPath.AddLine(oTPH.Area.Left, oTPH.Area.Top, oTPH.Area.Left, oTPH.Area.Top + oTPH.Area.Height \ 2)
                                    Call oPath.AddArc(oTPH.Area, 180, -90)
                                    Call oPath.AddLine(oTPH.Area.Left + oTPH.Area.Width \ 2, oTPH.Area.Bottom, oTPH.Area.Left + oTPH.Area.Width \ 2 + oNameSize.Width, oTPH.Area.Bottom)

                                    Call oPath.AddArc(oTPH.Area.Left + oNameSize.Width, oTPH.Area.Top, oTPH.Area.Width, oTPH.Area.Height, 90, -180)
                                    Call oPath.AddLine(oTPH.Area.Left + oNameSize.Width, oTPH.Area.Top, oTPH.Area.Left + oTPH.Area.Width \ 2, oTPH.Area.Top)
                                    Call oPath.AddLine(oTPH.Area.Left + oTPH.Area.Width \ 2, oTPH.Area.Top, oTPH.Area.Left, oTPH.Area.Top)

                                    Call oPlanTrigpointsPlaceholders(oStation.Name).Cache.SetPlanPath(oPath, Nothing)
                                End Using

                                Using oLabelPath As GraphicsPath = New GraphicsPath
                                    oLabelPath.AddString(oTPH.Name, Font.FontFamily, FontStyle.Regular, 8, oTPH.HotSpot, oSF)
                                    Call oPlanTrigpointsPlaceholders(oStation.Name).Cache.SetPlanPath(Nothing, oLabelPath)
                                End Using
                            End If
                        End If
                        If oStation.ProfileVisible Then
                            If Not oStation.ProfilePoint.IsEmpty Then
                                Dim oPoint As Point = oStation.ProfilePoint
                                Dim oTPH As cTrigpointPlaceholder = oProfileTrigpointsPlaceholders(oStation.Name)
                                Dim oNameSize As SizeF = oGraphics.MeasureString(oTPH.Name, Font)
                                Using oPath As GraphicsPath = New GraphicsPath
                                    Call oPath.AddLine(oTPH.Area.Left, oTPH.Area.Top, oTPH.Area.Left, oTPH.Area.Top + oTPH.Area.Height \ 2)
                                    Call oPath.AddArc(oTPH.Area, 180, -90)
                                    Call oPath.AddLine(oTPH.Area.Left + oTPH.Area.Width \ 2, oTPH.Area.Bottom, oTPH.Area.Left + oTPH.Area.Width \ 2 + oNameSize.Width, oTPH.Area.Bottom)

                                    Call oPath.AddArc(oTPH.Area.Left + oNameSize.Width, oTPH.Area.Top, oTPH.Area.Width, oTPH.Area.Height, 90, -180)
                                    Call oPath.AddLine(oTPH.Area.Left + oNameSize.Width, oTPH.Area.Top, oTPH.Area.Left + oTPH.Area.Width \ 2, oTPH.Area.Top)
                                    Call oPath.AddLine(oTPH.Area.Left + oTPH.Area.Width \ 2, oTPH.Area.Top, oTPH.Area.Left, oTPH.Area.Top)

                                    Call oProfileTrigpointsPlaceholders(oStation.Name).Cache.SetProfilePath(oPath, Nothing)
                                End Using

                                Using oLabelPath As GraphicsPath = New GraphicsPath
                                    oLabelPath.AddString(oTPH.Name, Font.FontFamily, FontStyle.Regular, 8, oTPH.HotSpot, oSF)
                                    Call oProfileTrigpointsPlaceholders(oStation.Name).Cache.SetProfilePath(Nothing, oLabelPath)
                                End Using
                            End If
                        End If
                        'End If
                    Next
                End Using
            End Using

            Call oProcessed.Clear()
            Call pPaintShots(0, oProcessed, sStation, oScale)

            Call oProcessed.Clear()
            Call pPaintShots(1, oProcessed, sStation, oScale)
        End If

        'Catch
        'End Try

        Call pInvalidateCurrentView()

        Cursor = Cursors.Default
    End Sub

    Private Sub pSettingsLoad()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
                iDefaultCalculateMode = oReg.GetValue("resurvey.options.calculatemode", cResurvey.cOptions.CalculateModeEnum.Full)
                btnShowRulers.Checked = oReg.GetValue("resurvey.options.showrulers", 0)
                btnShowRuler.Checked = oReg.GetValue("resurvey.options.showruler", 0)
                Dim oLayout As Byte() = oReg.GetValue("resurvey.workspaces.default", Nothing)
                If Not oLayout Is Nothing AndAlso oLayout.Length > 0 Then
                    Using oMs As MemoryStream = New MemoryStream(oLayout)
                        Call WorkspaceManager.LoadWorkspace("default", oMs)
                        Call WorkspaceManager.ApplyWorkspace("default")
                        'this dock is not visible after a restore...have to be showed manually
                        dockMagnifier.Visibility = DockVisibility.Hidden
                        Call dockMagnifier.MakeFloat()
                    End Using
                End If
                Call oReg.Close()
                'Call DockManager.RestoreLayoutFromRegistry("Software\Cepelabs\cSurvey\resurvey.docklayout")
                'Call DocumentManager.View.RestoreLayoutFromRegistry("Software\Cepelabs\cSurvey\resurvey.documentlayout")
            End Using
        Catch
        End Try
    End Sub

    Private Sub pSettingsSave()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
                Call oReg.SetValue("resurvey.options.calculatemode", Convert.ToInt32(iDefaultCalculateMode))
                Call oReg.SetValue("resurvey.options.showrulers", If(btnShowRulers.Checked, 1, 0))
                Call oReg.SetValue("resurvey.options.showruler", If(btnShowRuler.Checked, 1, 0))
                Using oMs As MemoryStream = New MemoryStream
                    Call WorkspaceManager.CaptureWorkspace("default", True)
                    Call WorkspaceManager.SaveWorkspace("default", oMs, True)
                    Call oReg.SetValue("resurvey.workspaces.default", oMs.ToArray, Microsoft.Win32.RegistryValueKind.Binary)
                End Using
                Call oReg.Close()
            End Using
            'Call DocumentManager.View.SaveLayoutToRegistry("Software\Cepelabs\cSurvey\resurvey.documentlayout")
            'Call DockManager.SaveLayoutToRegistry("Software\Cepelabs\cSurvey\resurvey.docklayout")
        Catch
        End Try
    End Sub

    Private Sub pNew()
        Cursor = Cursors.WaitCursor

        oOptions.CalculateMode = iDefaultCalculateMode
        oOptions.NordCorrection = 0

        Call pSetCalculateMode()

        oPlanLastLine = Nothing
        oPlanLastPlaceHolder = Nothing
        oProfileLastLine = Nothing
        oProfileLastPlaceHolder = Nothing

        sPlanImage = ""
        sProfileImage = ""
        picPlan.Image = Nothing
        picPlan.Visible = False
        picProfile.Image = Nothing
        picProfile.Visible = False

        'Call pBindScrollbars()

        Call oPlanTrigpointsPlaceholders.Clear()
        Call oProfileTrigpointsPlaceholders.Clear()

        Call oShots.Clear()
        Call grdShots.RefreshDataSource()

        Call oStations.Clear()
        Call grdStations.RefreshDataSource()

        'Call grdStationsOLD.Rows.Clear()
        'Call grdPlot.Rows.Clear()

        sFilename = ""
        Text = "cResurvey"
        Cursor = Cursors.Default
    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        Call pNew()
    End Sub

    'Private Sub mnuPreviewHide_Click(sender As System.Object, e As System.EventArgs) Handles mnuPreviewHide.Click
    '    oLastPlaceHolder.Visible = False
    '    Call pDelayedPerformPaint()
    'End Sub

    'Private Sub mnuPreviewShowHidden_Click(sender As System.Object, e As System.EventArgs) Handles mnuPreviewShowHidden.Click
    '    If pGetCurrentProjection() = 0 Then
    '        Call pShowHiddenTrigPoints(0)
    '    Else
    '        Call pShowHiddenTrigPoints(1)
    '    End If
    'End Sub

    Private Sub picPlan_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles picPlan.Paint
        'Try
        Dim oGraphics As Graphics = e.Graphics
        oGraphics.SmoothingMode = SmoothingMode.AntiAlias
        oGraphics.CompositingQuality = CompositingQuality.HighQuality
        oGraphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

        Call oGraphics.ScaleTransform(sPlanZoom, sPlanZoom)

        Dim oScale As cScale = pGetScale()

        If Not oPlanScalePath Is Nothing Then
            Call oGraphics.DrawPath(oScalePen, oPlanScalePath)
        End If

        If Not oPlanNorthPath Is Nothing Then
            Call oGraphics.DrawPath(oNorthPen, oPlanNorthPath)
        End If

        SyncLock oPlanTrigpointsPlaceholders
            For Each oPlaceholder As cTrigpointPlaceholder In oPlanTrigpointsPlaceholders.Values
                Dim oStation As cStation = oStations(oPlaceholder.Name)
                Dim bIsSelected As Boolean = oPlaceholder Is oPlanLastPlaceHolder

                If oStation.PlanVisible AndAlso Not oPlaceholder.Cache.PlanStationPath Is Nothing Then
                    If bIsSelected Then
                        Using oPlaceholderSelectedPen As Pen = New Pen(Color.FromArgb(210, oPlaceholder.BackColor), 2)
                            Using oPlaceholderSelectedbrush As Brush = New SolidBrush(Color.FromArgb(210, oPlaceholder.BackColor))
                                Call oGraphics.FillPath(oPlaceholderSelectedbrush, oPlaceholder.Cache.PlanStationPath)
                                Call oGraphics.DrawPath(oPlaceholderSelectedPen, oPlaceholder.Cache.PlanStationPath)
                                Call oGraphics.FillPath(Brushes.White, oPlaceholder.Cache.PlanLabelPath)
                            End Using
                        End Using
                    Else
                        Using oPlaceholderPen As Pen = New Pen(Color.FromArgb(140, oPlaceholder.BackColor), 1)
                            Using oPlaceholderbrush As Brush = New SolidBrush(Color.FromArgb(140, oPlaceholder.BackColor))
                                Call oGraphics.FillPath(oPlaceholderbrush, oPlaceholder.Cache.PlanStationPath)
                                Call oGraphics.DrawPath(oPlaceholderPen, oPlaceholder.Cache.PlanStationPath)
                                Call oGraphics.FillPath(Brushes.White, oPlaceholder.Cache.PlanLabelPath)
                            End Using
                        End Using
                    End If
                End If
                For Each sToStation In oPlaceholder.Cache.PlanShots.Keys
                    Dim bSelectedLine As Boolean
                    If oPlanLastLine Is Nothing Then
                        bSelectedLine = False
                    Else
                        bSelectedLine = oPlanLastLine(0).Name = oStation.Name AndAlso oPlanLastLine(1).Name = sToStation
                    End If
                    Dim oItem As cCacheItem = oPlaceholder.Cache.PlanShots(sToStation)
                    If sToStation.EndsWith(">") Then
                        If Not oItem.ShotPath Is Nothing Then Call oGraphics.DrawPath(If(bSelectedLine, oSelectedTranslationPen, oTranslationsPen), oItem.ShotPath)
                    Else
                        If Not oItem.ShotPath Is Nothing Then Call oGraphics.DrawPath(If(bSelectedLine, oSelectedShotsPen, oShotsPen), oItem.ShotPath)
                        If Not oItem.LRUDPath Is Nothing Then Call oGraphics.DrawPath(If(bIsSelected, oSelectedLRUDPen, oLRUDPen), oItem.LRUDPath)
                        If Not oItem.LRUDAreaPath Is Nothing Then Call oGraphics.FillPath(oLRUDAreaBrush, oItem.LRUDAreaPath)
                    End If
                Next

                If bIsSelected Then
                    'check connected stations And if there are planimetric distance draw line for each stations
                    Dim oProfileTPH As cTrigpointPlaceholder = If(oProfileTrigpointsPlaceholders.ContainsKey(pGetRealStation(oPlaceholder.Name)), oProfileTrigpointsPlaceholders(pGetRealStation(oPlaceholder.Name)), Nothing)
                    If Not IsNothing(oProfileTPH) AndAlso btnShowRulers.Checked AndAlso oOptions.ProfileType = cOptions.ProfileTypeEnum.Extended Then
                        If Not (oScale.PlanError OrElse oScale.ProfileError) Then
                            Using oSF As StringFormat = New StringFormat(Drawing.StringFormatFlags.NoWrap)
                                oSF.Alignment = StringAlignment.Center
                                oSF.LineAlignment = StringAlignment.Center
                                Dim iIndex As Integer = 0
                                Dim oConnectedTPHs As List(Of cTrigpointPlaceholder) = New List(Of cTrigpointPlaceholder)
                                Call oConnectedTPHs.AddRange(oProfileTrigpointsPlaceholders.Where(Function(item) oStation.ProfileConnectedTo.Contains(item.Key)).Select(Function(item) item.Value))
                                Call oConnectedTPHs.AddRange(oProfileTrigpointsPlaceholders.Where(Function(item) oStations(item.Key).ProfileConnectedTo.Contains(oStation.Name)).Select(Function(item) item.Value))
                                For Each oConnectedTPH As cTrigpointPlaceholder In oConnectedTPHs.Distinct.ToList
                                    iIndex -= 10
                                    'If oProfileTrigpointsPlaceholders.ContainsKey(oConnectedTPH.Name) Then
                                    Dim oConnectedProfileTPH As cTrigpointPlaceholder = oProfileTrigpointsPlaceholders(oConnectedTPH.Name)
                                    Dim sDistance As Single = Math.Abs(oProfileTPH.Point.X - oConnectedProfileTPH.Point.X)
                                    sDistance = sDistance * oScale.ProfileScale / oScale.PlanScale
                                    Dim sText As String = oConnectedTPH.Name '& " - " & Strings.Format(modNumbers.MathRound(sDistance * oScale.ProfileScale, 2), "0.00") & " m"
                                    Dim oLabelSize As SizeF = oGraphics.MeasureString(sText, Font, 64, oSF)
                                    oLabelSize.Width += 2
                                    oLabelSize.Height += 2
                                    Dim oState As GraphicsState = oGraphics.Save
                                    Call oGraphics.Transform.RotateAt(iIndex, oPlaceholder.Point, MatrixOrder.Append)
                                    Call oGraphics.DrawEllipse(oRulesPen, New RectangleF(oPlaceholder.Point.X - sDistance, oPlaceholder.Point.Y - sDistance, sDistance * 2, sDistance * 2))
                                    Dim oLabelBox As Rectangle = New Rectangle(oPlaceholder.Point.X + sDistance - oLabelSize.Width / 2, oPlaceholder.Point.Y - oLabelSize.Height / 2, oLabelSize.Width, oLabelSize.Height)
                                    Call oGraphics.FillRectangle(oRulesLabelBrush, oLabelBox)
                                    Call oGraphics.DrawRectangle(oRulesLabelPen, oLabelBox)
                                    Call oGraphics.DrawString(sText, Font, oRulesBrush, oLabelBox, oSF)
                                    Call oGraphics.Restore(oState)
                                Next
                            End Using
                        End If
                    End If
                End If

                If oStation Is gridviewStations.GetFocusedRow Then
                    Dim oBounds As Rectangle = oPlaceholder.HotSpot
                    Call oBounds.Inflate(2, 2)
                    oGraphics.DrawRectangle(oActiveStationPen, oBounds)
                End If
            Next
        End SyncLock

        If btnShowRulers.Checked AndAlso Not oPlanLastPlaceHolder Is Nothing Then
            Call oGraphics.DrawLine(oRulesSecondaryPen, New Point(oGraphics.VisibleClipBounds.Left, oPlanLastPlaceHolder.Point.Y), New Point(oGraphics.VisibleClipBounds.Right, oPlanLastPlaceHolder.Point.Y))
            Call oGraphics.DrawLine(oRulesSecondaryPen, New Point(oPlanLastPlaceHolder.Point.X, oGraphics.VisibleClipBounds.Top), New Point(oPlanLastPlaceHolder.Point.X, oGraphics.VisibleClipBounds.Bottom))
        End If

        If btnShowRulers.Checked AndAlso btnShowRuler.Checked And Not oScale.PlanError Then
            Dim oBound As RectangleF = oGraphics.VisibleClipBounds
            Using omatrix = New Matrix
                Call omatrix.Scale(sPlanZoom, sPlanZoom, MatrixOrder.Prepend)
                Call omatrix.RotateAt(sPlanRulerAngle, oPlanRulerPosition, MatrixOrder.Prepend)
                oGraphics.Transform = omatrix
                Dim oBackgroudRect As RectangleF = New RectangleF(oBound.Left - oBound.Width / 2, oPlanRulerPosition.Y - sRulerHeight / 2, oBound.Width * 2, sRulerHeight)
                Call oGraphics.FillRectangle(oRulerBackgroundBrush, oBackgroudRect)
                Call oGraphics.DrawRectangle(oRulerForegroundPen, oBackgroudRect.X, oBackgroudRect.Y, oBackgroudRect.Width, oBackgroudRect.Height)
                Call oGraphics.DrawLine(oRulerForegroundPen, oBackgroudRect.X, oPlanRulerPosition.Y, oBackgroudRect.Right, oPlanRulerPosition.Y)

                Dim sLeft As Single = oBound.Left

                Dim sStep As Single = 1 / oScale.PlanScale

                Dim sRulerBorderTop As Single = oPlanRulerPosition.Y - sRulerHeight / 2
                Dim sRulerBorderCenter As Single = oPlanRulerPosition.Y
                Dim sRulerBorderBottom As Single = oPlanRulerPosition.Y + sRulerHeight / 2
                Dim iMeters As Integer = 0
                For x As Single = oPlanRulerPosition.X To oBackgroudRect.Left Step -sStep
                    If (iMeters Mod 10) = 0 Then
                        Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderTop), New PointF(x, sRulerBorderTop + 24))
                        If iMeters > 2 Then Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderCenter + 12), New PointF(x, sRulerBorderCenter - 12))
                        Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderBottom), New PointF(x, sRulerBorderBottom - 24))

                        Call pRulerDrawPlanMeterUnit(oGraphics, x, sRulerBorderTop + 30, iMeters)
                        Call pRulerDrawPlanMeterUnit(oGraphics, x, sRulerBorderBottom - 30, iMeters)
                    Else
                        Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderTop), New PointF(x, sRulerBorderTop + 16))
                        If iMeters > 2 Then Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderCenter + 6), New PointF(x, sRulerBorderCenter - 6))
                        Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderBottom), New PointF(x, sRulerBorderBottom - 16))
                    End If
                    iMeters += 1
                Next
                iMeters = 0
                For x As Single = oPlanRulerPosition.X To oBackgroudRect.Right Step sStep
                    If (iMeters Mod 10) = 0 Then
                        Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderTop), New PointF(x, sRulerBorderTop + 24))
                        If iMeters > 2 Then Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderCenter + 12), New PointF(x, sRulerBorderCenter - 12))
                        Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderBottom), New PointF(x, sRulerBorderBottom - 24))

                        Call pRulerDrawPlanMeterUnit(oGraphics, x, sRulerBorderTop + 30, iMeters)
                        Call pRulerDrawPlanMeterUnit(oGraphics, x, sRulerBorderBottom - 30, iMeters)
                    Else
                        Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderTop), New PointF(x, sRulerBorderTop + 16))
                        If iMeters > 2 Then Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderCenter + 6), New PointF(x, sRulerBorderCenter - 6))
                        Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderBottom), New PointF(x, sRulerBorderBottom - 16))
                    End If
                    iMeters += 1
                Next
            End Using

            Dim oFontRect As RectangleF = New RectangleF(oPlanRulerPosition.X - iRulerClockRadio, oPlanRulerPosition.Y - iRulerClockRadio, iRulerClockRadio * 2, iRulerClockRadio * 2)
            Using oMatrix = New Matrix
                Call oMatrix.Scale(sPlanZoom, sPlanZoom, MatrixOrder.Prepend)
                Call oMatrix.RotateAt(0, oPlanRulerPosition)
                oGraphics.Transform = oMatrix
                Using oSF As StringFormat = New StringFormat(Drawing.StringFormatFlags.NoWrap)
                    oSF.Alignment = StringAlignment.Center
                    oSF.LineAlignment = StringAlignment.Center
                    Dim sText As String = ""
                    If oOptions.NordCorrection = 0 Then
                        sText = Strings.Format(sPlanRulerAngle - 90.0F, "0.00°")
                    Else
                        sText = Strings.Format(modPaint.NormalizeAngle(sPlanRulerAngle + oOptions.NordCorrection + 180.0F - 90.0F), "0.00°") & vbCrLf & "(" & Strings.Format(modPaint.NormalizeAngle(sPlanRulerAngle - 90.0F), "0.00°") & ")"
                    End If
                    Call oGraphics.DrawString(sText, oRulerAngleFont, oRulerFontBrush, oFontRect, oSF)
                End Using
            End Using

            Dim iAngleStep As Integer = 15
            For a As Integer = 0 To 360 Step iAngleStep
                Using oMatrix = New Matrix
                    Call oMatrix.Scale(sPlanZoom, sPlanZoom, MatrixOrder.Prepend)
                    Call oMatrix.RotateAt(a, oPlanRulerPosition)
                    oGraphics.Transform = oMatrix
                    If (a Mod 90) = 0 Then
                        Call oGraphics.DrawLine(oRulerForegroundPen, oPlanRulerPosition.X, oPlanRulerPosition.Y - iRulerClockRadio, oPlanRulerPosition.X, oPlanRulerPosition.Y - iRulerClockRadio + 24)
                    Else
                        Call oGraphics.DrawLine(oRulerForegroundPen, oPlanRulerPosition.X, oPlanRulerPosition.Y - iRulerClockRadio, oPlanRulerPosition.X, oPlanRulerPosition.Y - iRulerClockRadio + 16)
                    End If
                End Using
            Next

            Using oMatrix = New Matrix
                Call oMatrix.Scale(sPlanZoom, sPlanZoom, MatrixOrder.Prepend)
                Call oMatrix.RotateAt(sPlanRulerAngle + 90.0F, oPlanRulerPosition)
                oGraphics.Transform = oMatrix
                Call oGraphics.DrawLine(oRulerCurrentAnglePen, oPlanRulerPosition.X, oPlanRulerPosition.Y - iRulerClockRadio, oPlanRulerPosition.X, oPlanRulerPosition.Y - iRulerClockRadio + 24)
            End Using
            Using oMatrix = New Matrix
                Call oMatrix.Scale(sPlanZoom, sPlanZoom, MatrixOrder.Prepend)
                Call oMatrix.RotateAt(sPlanRulerAngle + 270.0F, oPlanRulerPosition)
                oGraphics.Transform = oMatrix
                Call oGraphics.DrawLine(oRulerCurrentAnglePen, oPlanRulerPosition.X, oPlanRulerPosition.Y - iRulerClockRadio, oPlanRulerPosition.X, oPlanRulerPosition.Y - iRulerClockRadio + 24)
            End Using
        End If
        'Catch
        'End Try
    End Sub

    Private Sub pRulerDrawPlanMeterUnit(Graphics As Graphics, X As Single, Y As Single, Meter As Integer)
        Dim oTickPoint As PointF = New PointF(X, Y)
        Using oMatrix = New Matrix
            Call oMatrix.Scale(sPlanZoom, sPlanZoom, MatrixOrder.Prepend)
            Call oMatrix.RotateAt(sPlanRulerAngle, oPlanRulerPosition, MatrixOrder.Prepend)
            Graphics.Transform = oMatrix
            Using oSF As StringFormat = New StringFormat(Drawing.StringFormatFlags.NoWrap)
                oSF.Alignment = StringAlignment.Center
                oSF.LineAlignment = StringAlignment.Center
                Call Graphics.DrawString(Strings.Format(Meter, "0"), oRulerTickFont, oRulerFontBrush, oTickPoint, oSF)
            End Using
        End Using
    End Sub

    Private Sub pRulerDrawProfileMeterUnit(Graphics As Graphics, X As Single, Y As Single, Meter As Integer)
        Dim oTickPoint As PointF = New PointF(X, Y)
        Using oMatrix = New Matrix
            Call oMatrix.Scale(sProfileZoom, sProfileZoom, MatrixOrder.Prepend)
            Call oMatrix.RotateAt(sProfileRulerAngle, oProfileRulerPosition, MatrixOrder.Prepend)
            Graphics.Transform = oMatrix
            Using oSF As StringFormat = New StringFormat(Drawing.StringFormatFlags.NoWrap)
                oSF.Alignment = StringAlignment.Center
                oSF.LineAlignment = StringAlignment.Center
                Call Graphics.DrawString(Strings.Format(Meter, "0"), oRulerTickFont, oRulerFontBrush, oTickPoint, oSF)
            End Using
        End Using
    End Sub

    Private bPlanRulerMovePoint As Boolean
    Private oPlanRulerMovePoint As PointF
    Private oPlanRulerPosition As PointF = New PointF(120, 120)
    Private sPlanRulerAngle As Single = 0

    Private sRulerHeight As Single = 240
    Private iRulerClockRadio As Integer = 64

    Private bProfileRulerMovePoint As Boolean
    Private oProfileRulerMovePoint As PointF
    Private oProfileRulerPosition As PointF = New PointF(120, 120)
    Private sProfileRulerAngle As Single = 0

    Private Sub picProfile_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles picProfile.Paint
        Try
            Dim oGraphics As Graphics = e.Graphics
            oGraphics.SmoothingMode = SmoothingMode.AntiAlias
            oGraphics.CompositingQuality = CompositingQuality.HighQuality
            oGraphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

            Call oGraphics.ScaleTransform(sProfileZoom, sProfileZoom)

            Dim oScale As cScale = pGetScale()

            If Not oProfileScalePath Is Nothing Then
                Call oGraphics.DrawPath(oScalePen, oProfileScalePath)
            End If

            If Not oProfileDropScalePath Is Nothing Then
                Call oGraphics.DrawPath(oDropScalePen, oProfileDropScalePath)
            End If
            If Not oProfileDropScaleRealPath Is Nothing Then
                Call oGraphics.DrawPath(oDropScaleRealPen, oProfileDropScaleRealPath)
            End If

            SyncLock oProfileTrigpointsPlaceholders
                For Each oPlaceholder As cTrigpointPlaceholder In oProfileTrigpointsPlaceholders.Values
                    Dim oStation As cStation = oStations(oPlaceholder.Name)
                    Dim bIsSelected As Boolean = oPlaceholder Is oProfileLastPlaceHolder

                    If oStation.ProfileVisible AndAlso Not oPlaceholder.Cache.ProfileStationPath Is Nothing Then
                        If bIsSelected Then
                            Using oPlaceholderSelectedPen As Pen = New Pen(Color.FromArgb(210, oPlaceholder.BackColor), 2)
                                Using oPlaceholderSelectedbrush As Brush = New SolidBrush(Color.FromArgb(210, oPlaceholder.BackColor))
                                    Call oGraphics.FillPath(oPlaceholderSelectedbrush, oPlaceholder.Cache.ProfileStationPath)
                                    Call oGraphics.DrawPath(oPlaceholderSelectedPen, oPlaceholder.Cache.ProfileStationPath)
                                    Call oGraphics.FillPath(Brushes.White, oPlaceholder.Cache.ProfileLabelPath)
                                End Using
                            End Using
                        Else
                            Using oPlaceholderPen As Pen = New Pen(Color.FromArgb(140, oPlaceholder.BackColor), 1)
                                Using oPlaceholderbrush As Brush = New SolidBrush(Color.FromArgb(140, oPlaceholder.BackColor))
                                    Call oGraphics.FillPath(oPlaceholderbrush, oPlaceholder.Cache.ProfileStationPath)
                                    Call oGraphics.DrawPath(oPlaceholderPen, oPlaceholder.Cache.ProfileStationPath)
                                    Call oGraphics.FillPath(Brushes.White, oPlaceholder.Cache.ProfileLabelPath)
                                End Using
                            End Using
                        End If
                    End If

                    For Each sToStation In oPlaceholder.Cache.ProfileShots.Keys
                        Dim bSelectedLine As Boolean
                        If oProfileLastLine Is Nothing Then
                            bSelectedLine = False
                        Else
                            bSelectedLine = oProfileLastLine(0).Name = oStation.Name AndAlso oProfileLastLine(1).Name = sToStation
                        End If
                        Dim oItem As cCacheItem = oPlaceholder.Cache.ProfileShots(sToStation)
                        If sToStation.EndsWith(">") Then
                            If Not oItem.ShotPath Is Nothing Then Call oGraphics.DrawPath(If(bSelectedLine, oSelectedTranslationPen, oTranslationsPen), oItem.ShotPath)
                        Else
                            If Not oItem.ShotPath Is Nothing Then Call oGraphics.DrawPath(If(bSelectedLine, oSelectedShotsPen, oShotsPen), oItem.ShotPath)
                            If Not oItem.LRUDPath Is Nothing Then Call oGraphics.DrawPath(If(bSelectedLine, oSelectedLRUDPen, oLRUDPen), oItem.LRUDPath)
                            If Not oItem.LRUDAreaPath Is Nothing Then Call oGraphics.FillPath(oLRUDAreaBrush, oItem.LRUDAreaPath)
                        End If
                    Next

                    If bIsSelected Then
                        Dim oPlanTPH As cTrigpointPlaceholder = If(oPlanTrigpointsPlaceholders.ContainsKey(oPlaceholder.Name), oPlanTrigpointsPlaceholders(oPlaceholder.Name), Nothing)
                        If Not IsNothing(oPlanTPH) AndAlso btnShowRulers.Checked AndAlso oOptions.ProfileType = cOptions.ProfileTypeEnum.Extended Then
                            If Not (oScale.PlanError OrElse oScale.ProfileError) Then
                                Using oSF As StringFormat = New StringFormat(Drawing.StringFormatFlags.NoWrap)
                                    oSF.Alignment = StringAlignment.Center
                                    oSF.LineAlignment = StringAlignment.Center
                                    Dim iIndex As Integer = 0
                                    Dim oConnectedTPHs As List(Of cTrigpointPlaceholder) = New List(Of cTrigpointPlaceholder)
                                    Call oConnectedTPHs.AddRange(oPlanTrigpointsPlaceholders.Where(Function(item) oStation.PlanConnectedTo.Contains(item.Key)).Select(Function(item) item.Value))
                                    Call oConnectedTPHs.AddRange(oPlanTrigpointsPlaceholders.Where(Function(item) oStations(item.Key).PlanConnectedTo.Contains(oStation.Name)).Select(Function(item) item.Value))
                                    For Each oConnectedTPH As cTrigpointPlaceholder In oConnectedTPHs.Distinct.ToList
                                        iIndex += 16
                                        Dim oConnectedPlanTPH As cTrigpointPlaceholder = oPlanTrigpointsPlaceholders(oConnectedTPH.Name)
                                        Dim sDistance As Single = modPaint.DistancePointToPoint(oPlanTPH.Point, oConnectedPlanTPH.Point)
                                        sDistance = sDistance * oScale.PlanScale / oScale.ProfileScale
                                        Dim sText As String = oConnectedTPH.Name '& " - " & Strings.Format(modNumbers.MathRound(sDistance * oScale.ProfileScale, 2), "0.00") & " m"
                                        Dim oLabelSize As SizeF = oGraphics.MeasureString(sText, Font, 64, oSF)
                                        oLabelSize.Width += 2
                                        oLabelSize.Height += 2

                                        Call oGraphics.DrawLine(oRulesPen, New Point(oPlaceholder.Point.X + sDistance, oGraphics.VisibleClipBounds.Bottom), New Point(oPlaceholder.Point.X + sDistance, oGraphics.VisibleClipBounds.Top))
                                        Dim oLabelBox As Rectangle = New Rectangle(oPlaceholder.Point.X + sDistance - oLabelSize.Width / 2, oPlaceholder.Point.Y - oLabelSize.Height / 2 + iIndex, oLabelSize.Width, oLabelSize.Height)
                                        Call oGraphics.FillRectangle(oRulesLabelBrush, oLabelBox)
                                        Call oGraphics.DrawRectangle(oRulesLabelPen, oLabelBox)                                                            'Call oGraphics.FillEllipse(oRulesFillBrush, New Rectangle(oTPH.Point.X + sDistance - sSize / 2, oTPH.Point.Y - sSize / 2 - sSize * iindex, sSize, sSize))
                                        Call oGraphics.DrawString(sText, Font, oRulesBrush, oLabelBox, oSF) ' New Rectangle(oTPH.Point.X + sDistance - oLabelSize.Width / 2, oTPH.Point.Y - oLabelSize.Height / 2, oLabelSize.Width, oLabelSize.Height), oSF)

                                        Call oGraphics.DrawLine(oRulesPen, New Point(oPlaceholder.Point.X - sDistance, oGraphics.VisibleClipBounds.Bottom), New Point(oPlaceholder.Point.X - sDistance, oGraphics.VisibleClipBounds.Top))
                                        oLabelBox = New Rectangle(oPlaceholder.Point.X - sDistance - oLabelSize.Width / 2, oPlaceholder.Point.Y - oLabelSize.Height / 2 - iIndex, oLabelSize.Width, oLabelSize.Height)
                                        Call oGraphics.FillRectangle(oRulesLabelBrush, oLabelBox)
                                        Call oGraphics.DrawRectangle(oRulesLabelPen, oLabelBox)                                                            'Call oGraphics.FillEllipse(oRulesFillBrush, New Rectangle(oTPH.Point.X + sDistance - sSize / 2, oTPH.Point.Y - sSize / 2 - sSize * iindex, sSize, sSize))
                                        Call oGraphics.DrawString(sText, Font, oRulesBrush, oLabelBox, oSF) ' New Rectangle(oTPH.Point.X - sDistance - oLabelSize.Width / 2 + 1, oTPH.Point.Y - oLabelSize.Height / 2 + 1, oLabelSize.Width, oLabelSize.Height), oSF)
                                    Next
                                End Using
                            End If
                        End If
                    End If

                    If oStation Is gridviewStations.GetFocusedRow Then
                        Dim oBounds As Rectangle = oPlaceholder.HotSpot
                        Call oBounds.Inflate(2, 2)
                        oGraphics.DrawRectangle(oActiveStationPen, oBounds)
                    End If
                Next
            End SyncLock

            If btnShowRulers.Checked AndAlso Not oProfileLastPlaceHolder Is Nothing Then
                Call oGraphics.DrawLine(oRulesSecondaryPen, New Point(oGraphics.VisibleClipBounds.Left, oProfileLastPlaceHolder.Point.Y), New Point(oGraphics.VisibleClipBounds.Right, oProfileLastPlaceHolder.Point.Y))
                Call oGraphics.DrawLine(oRulesSecondaryPen, New Point(oProfileLastPlaceHolder.Point.X, oGraphics.VisibleClipBounds.Top), New Point(oProfileLastPlaceHolder.Point.X, oGraphics.VisibleClipBounds.Bottom))
            End If

            If btnShowRulers.Checked AndAlso btnShowRuler.Checked And Not oScale.ProfileError Then
                Dim oBound As RectangleF = oGraphics.VisibleClipBounds
                Using omatrix = New Matrix
                    Call omatrix.Scale(sProfileZoom, sProfileZoom, MatrixOrder.Prepend)
                    Call omatrix.RotateAt(sProfileRulerAngle, oProfileRulerPosition, MatrixOrder.Prepend)
                    oGraphics.Transform = omatrix
                    Dim oBackgroudRect As RectangleF = New RectangleF(oBound.Left - oBound.Width / 2, oProfileRulerPosition.Y - sRulerHeight / 2, oBound.Width * 2, sRulerHeight)
                    Call oGraphics.FillRectangle(oRulerBackgroundBrush, oBackgroudRect)
                    Call oGraphics.DrawRectangle(oRulerForegroundPen, oBackgroudRect.X, oBackgroudRect.Y, oBackgroudRect.Width, oBackgroudRect.Height)
                    Call oGraphics.DrawLine(oRulerForegroundPen, oBackgroudRect.X, oProfileRulerPosition.Y, oBackgroudRect.Right, oProfileRulerPosition.Y)

                    Dim sLeft As Single = oBound.Left

                    Dim sStep As Single = 1 / oScale.ProfileScale

                    Dim sRulerBorderTop As Single = oProfileRulerPosition.Y - sRulerHeight / 2
                    Dim sRulerBorderCenter As Single = oProfileRulerPosition.Y
                    Dim sRulerBorderBottom As Single = oProfileRulerPosition.Y + sRulerHeight / 2
                    Dim iMeters As Integer = 0
                    For x As Single = oProfileRulerPosition.X To oBackgroudRect.Left Step -sStep
                        If (iMeters Mod 10) = 0 Then
                            Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderTop), New PointF(x, sRulerBorderTop + 24))
                            If iMeters > 2 Then Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderCenter + 12), New PointF(x, sRulerBorderCenter - 12))
                            Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderBottom), New PointF(x, sRulerBorderBottom - 24))

                            Call pRulerDrawProfileMeterUnit(oGraphics, x, sRulerBorderTop + 30, iMeters)
                            Call pRulerDrawProfileMeterUnit(oGraphics, x, sRulerBorderBottom - 30, iMeters)
                        Else
                            Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderTop), New PointF(x, sRulerBorderTop + 16))
                            If iMeters > 2 Then Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderCenter + 6), New PointF(x, sRulerBorderCenter - 6))
                            Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderBottom), New PointF(x, sRulerBorderBottom - 16))
                        End If
                        iMeters += 1
                    Next
                    iMeters = 0
                    For x As Single = oProfileRulerPosition.X To oBackgroudRect.Right Step sStep
                        If (iMeters Mod 10) = 0 Then
                            Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderTop), New PointF(x, sRulerBorderTop + 24))
                            If iMeters > 2 Then Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderCenter + 12), New PointF(x, sRulerBorderCenter - 12))
                            Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderBottom), New PointF(x, sRulerBorderBottom - 24))

                            Call pRulerDrawProfileMeterUnit(oGraphics, x, sRulerBorderTop + 30, iMeters)
                            Call pRulerDrawProfileMeterUnit(oGraphics, x, sRulerBorderBottom - 30, iMeters)
                        Else
                            Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderTop), New PointF(x, sRulerBorderTop + 16))
                            If iMeters > 2 Then Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderCenter + 6), New PointF(x, sRulerBorderCenter - 6))
                            Call oGraphics.DrawLine(oRulerForegroundPen, New PointF(x, sRulerBorderBottom), New PointF(x, sRulerBorderBottom - 16))
                        End If
                        iMeters += 1
                    Next
                End Using

                Dim oFontRect As RectangleF = New RectangleF(oProfileRulerPosition.X - iRulerClockRadio, oProfileRulerPosition.Y - iRulerClockRadio, iRulerClockRadio * 2, iRulerClockRadio * 2)
                Using oMatrix = New Matrix
                    Call oMatrix.Scale(sProfileZoom, sProfileZoom, MatrixOrder.Prepend)
                    Call oMatrix.RotateAt(0, oProfileRulerPosition)
                    oGraphics.Transform = oMatrix
                    Using oSF As StringFormat = New StringFormat(Drawing.StringFormatFlags.NoWrap)
                        oSF.Alignment = StringAlignment.Center
                        oSF.LineAlignment = StringAlignment.Center
                        Dim sText As String = Strings.Format(modPaint.BearingToInclination(sProfileRulerAngle + 90), "0.00°")
                        Call oGraphics.DrawString(sText, oRulerAngleFont, oRulerFontBrush, oFontRect, oSF)
                    End Using
                End Using

                Dim iAngleStep As Integer = 15
                For a As Integer = 0 To 360 Step iAngleStep
                    Using oMatrix = New Matrix
                        Call oMatrix.Scale(sProfileZoom, sProfileZoom, MatrixOrder.Prepend)
                        Call oMatrix.RotateAt(a, oProfileRulerPosition)
                        oGraphics.Transform = oMatrix
                        If (a Mod 90) = 0 Then
                            Call oGraphics.DrawLine(oRulerForegroundPen, oProfileRulerPosition.X, oProfileRulerPosition.Y - iRulerClockRadio, oProfileRulerPosition.X, oProfileRulerPosition.Y - iRulerClockRadio + 24)
                        Else
                            Call oGraphics.DrawLine(oRulerForegroundPen, oProfileRulerPosition.X, oProfileRulerPosition.Y - iRulerClockRadio, oProfileRulerPosition.X, oProfileRulerPosition.Y - iRulerClockRadio + 16)
                        End If
                    End Using
                Next

                Using oMatrix = New Matrix
                    Call oMatrix.Scale(sProfileZoom, sProfileZoom, MatrixOrder.Prepend)
                    Call oMatrix.RotateAt(sProfileRulerAngle + 90.0F, oProfileRulerPosition)
                    oGraphics.Transform = oMatrix
                    Call oGraphics.DrawLine(oRulerCurrentAnglePen, oProfileRulerPosition.X, oProfileRulerPosition.Y - iRulerClockRadio, oProfileRulerPosition.X, oProfileRulerPosition.Y - iRulerClockRadio + 24)
                End Using
                Using oMatrix = New Matrix
                    Call oMatrix.Scale(sProfileZoom, sProfileZoom, MatrixOrder.Prepend)
                    Call oMatrix.RotateAt(sProfileRulerAngle + 270.0F, oProfileRulerPosition)
                    oGraphics.Transform = oMatrix
                    Call oGraphics.DrawLine(oRulerCurrentAnglePen, oProfileRulerPosition.X, oProfileRulerPosition.Y - iRulerClockRadio, oProfileRulerPosition.X, oProfileRulerPosition.Y - iRulerClockRadio + 24)
                End Using
            End If
        Catch
        End Try
    End Sub

    'Private Sub mnuPreviewHideAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuPreviewHideAll.Click
    '    If pGetCurrentProjection() = 0 Then
    '        Call pHideTrigPoints(0)
    '    Else
    '        Call pHideTrigPoints(1)
    '    End If
    'End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        Dim oSFD As SaveFileDialog = New SaveFileDialog
        With oSFD
            If sFilename <> "" Then
                .FileName = Path.Combine(Path.GetDirectoryName(sFilename), Path.GetFileNameWithoutExtension(sFilename))
            End If
            .Filter = GetLocalizedString("resurvey.filetypeCSV") & " (*.CSV)|*.CSV|" & GetLocalizedString("resurvey.filetypeTXT") & " (*.TXT)|*.TXT"
            .FilterIndex = 1
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                sFilename = .FileName
                Select Case Path.GetExtension(sFilename).ToLower
                    Case ".txt"
                        Dim fi As FileInfo = New FileInfo(sFilename)
                        Using oSw As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(sFilename, False)
                            For Each oShot As cResurvey.cShot In oShots
                                Call oSw.Write(oShot.From & vbTab)
                                Call oSw.Write(oShot.[To] & vbTab)
                                Call oSw.Write(modNumbers.NumberToString(oShot.Distance, "0.00") & vbTab)
                                Call oSw.Write(modNumbers.NumberToString(oShot.[Bearing], "0.0") & vbTab)
                                Call oSw.Write(modNumbers.NumberToString(oShot.[Inclination], "0.0"))
                                Call oSw.WriteLine()
                            Next
                            Call oSw.Close()
                        End Using
                    Case ".csv"
                        Dim fi As FileInfo = New FileInfo(sFilename)
                        Using oSw As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(sFilename, False)
                            For Each oShot As cResurvey.cShot In oShots
                                Call oSw.Write(Chr(34) & oShot.From & Chr(34) & ";")
                                Call oSw.Write(Chr(34) & oShot.[To] & Chr(34) & ";")
                                Call oSw.Write(Chr(34) & modNumbers.NumberToString(oShot.Distance, "0.00") & Chr(34) & ";")
                                Call oSw.Write(Chr(34) & modNumbers.NumberToString(oShot.[Bearing], "0.0") & Chr(34) & ";")
                                Call oSw.Write(Chr(34) & modNumbers.NumberToString(oShot.[Inclination], "0.0") & Chr(34))
                                Call oSw.WriteLine()
                            Next
                            Call oSw.Close()
                        End Using
                End Select
            End If
        End With
    End Sub

    'Private Sub mnuPreview_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles mnuPreview.Opening
    '    Dim oColl As Dictionary(Of String, cResurvey.cTrigpointPlaceholder)
    '    If pGetCurrentProjection() = 0 Then
    '        oColl = oPlanTrigpointsPlaceholders
    '    Else
    '        oColl = oProfileTrigpointsPlaceholders
    '    End If

    '    Dim bThereIsPlaceHolder As Boolean = Not oLastPlaceHolder Is Nothing
    '    Dim bThereIsLine As Boolean = Not oLastLine Is Nothing

    '    If bThereIsPlaceHolder Then
    '        Dim sType As String = ""
    '        Try : sType = oStations(oLastPlaceHolder.Name).Type : Catch : End Try

    '        mnuPreviewRemove.Enabled = (bThereIsPlaceHolder) And (sType <> "SB" And sType <> "SE")
    '        mnuPreviewRemoveAll.Enabled = oColl.Count > 0
    '        mnuPreviewDelete.Enabled = (bThereIsPlaceHolder)
    '        mnuPreviewDeleteAll.Enabled = oStations.Count > 0

    '        mnuPreviewSetOrigin.Enabled = sType = ""
    '        mnuPreviewProperties.Enabled = True
    '    Else
    '        mnuPreviewRemove.Enabled = False
    '        mnuPreviewRemoveAll.Enabled = oColl.Count > 0
    '        mnuPreviewDelete.Enabled = False
    '        mnuPreviewDeleteAll.Enabled = oStations.Count > 0

    '        mnuPreviewSetOrigin.Enabled = False
    '        mnuPreviewProperties.Enabled = False

    '        mnuPreviewRuler.Visible = False
    '    End If
    '    If bThereIsLine Then
    '        mnuPreviewDeleteLink.Enabled = True
    '    Else
    '        mnuPreviewDeleteLink.Enabled = False
    '    End If
    '    If btnShowRulers.Checked Then
    '        mnuPreviewRuler.Visible = bThereIsPlaceHolder OrElse bThereIsLine
    '        mnuPreviewRulerCenterHere.Visible = bThereIsPlaceHolder
    '        mnuPreviewRulerAlignHere.Visible = bThereIsLine
    '    End If
    'End Sub

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
            Select Case e.KeyCode
                Case Keys.Left
                    If Not oPlanLastPlaceHolder Is Nothing Then
                        Call oPlanLastPlaceHolder.MovePoint(-If(e.Shift, 10, 1), 0)
                        Dim oStation As cStation = oStations(oPlanLastPlaceHolder.Name)
                        oStation.PlanPoint = oPlanLastPlaceHolder.Point
                        Call gridviewStations.RefreshRow(gridviewStations.FindRow(oStation))
                        Call pPerformPaint()
                    End If
                Case Keys.Right
                    If Not oPlanLastPlaceHolder Is Nothing Then
                        Call oPlanLastPlaceHolder.MovePoint(If(e.Shift, 10, 1), 0)
                        Dim oStation As cStation = oStations(oPlanLastPlaceHolder.Name)
                        oStation.PlanPoint = oPlanLastPlaceHolder.Point
                        Call gridviewStations.RefreshRow(gridviewStations.FindRow(oStation))
                        Call pPerformPaint()
                    End If
                Case Keys.Up
                    If Not oPlanLastPlaceHolder Is Nothing Then
                        Call oPlanLastPlaceHolder.MovePoint(0, -If(e.Shift, 10, 1))
                        Dim oStation As cStation = oStations(oPlanLastPlaceHolder.Name)
                        oStation.PlanPoint = oPlanLastPlaceHolder.Point
                        Call gridviewStations.RefreshRow(gridviewStations.FindRow(oStation))
                        Call pPerformPaint()
                    End If
                Case Keys.Down
                    If Not oPlanLastPlaceHolder Is Nothing Then
                        Call oPlanLastPlaceHolder.MovePoint(0, If(e.Shift, 10, 1))
                        Dim oStation As cStation = oStations(oPlanLastPlaceHolder.Name)
                        oStation.PlanPoint = oPlanLastPlaceHolder.Point
                        Call gridviewStations.RefreshRow(gridviewStations.FindRow(oStation))
                        Call pPerformPaint()
                    End If
            End Select
        Else
            picProfile.Cursor = Cursors.Cross
            Select Case e.KeyCode
                Case Keys.Left
                    If Not oProfileLastPlaceHolder Is Nothing Then
                        Call oProfileLastPlaceHolder.MovePoint(-If(e.Shift, 10, 1), 0)
                        Dim oStation As cStation = oStations(oProfileLastPlaceHolder.Name)
                        oStation.ProfilePoint = oProfileLastPlaceHolder.Point
                        Call gridviewStations.RefreshRow(gridviewStations.FindRow(oStation))
                        Call pPerformPaint()
                    End If
                Case Keys.Right
                    If Not oProfileLastPlaceHolder Is Nothing Then
                        Call oProfileLastPlaceHolder.MovePoint(If(e.Shift, 10, 1), 0)
                        Dim oStation As cStation = oStations(oProfileLastPlaceHolder.Name)
                        oStation.ProfilePoint = oProfileLastPlaceHolder.Point
                        Call gridviewStations.RefreshRow(gridviewStations.FindRow(oStation))
                        Call pPerformPaint()
                    End If
                Case Keys.Up
                    If Not oProfileLastPlaceHolder Is Nothing Then
                        Call oProfileLastPlaceHolder.MovePoint(0, -If(e.Shift, 10, 1))
                        Dim oStation As cStation = oStations(oProfileLastPlaceHolder.Name)
                        oStation.ProfilePoint = oProfileLastPlaceHolder.Point
                        Call gridviewStations.RefreshRow(gridviewStations.FindRow(oStation))
                        Call pPerformPaint()
                    End If
                Case Keys.Down
                    If Not oProfileLastPlaceHolder Is Nothing Then
                        Call oProfileLastPlaceHolder.MovePoint(0, If(e.Shift, 10, 1))
                        Dim oStation As cStation = oStations(oProfileLastPlaceHolder.Name)
                        oStation.ProfilePoint = oProfileLastPlaceHolder.Point
                        Call gridviewStations.RefreshRow(gridviewStations.FindRow(oStation))
                        Call pPerformPaint()
                    End If
            End Select
        End If
    End Sub

    Private Sub mnuPreviewDelete_Click(sender As System.Object, e As System.EventArgs)
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

            Dim oStation As cResurvey.cStation = gridviewStations.GetFocusedRow
            Dim sTrigpoint As String = oStation.Name

            If oPlanTrigpointsPlaceholders.ContainsKey(sTrigpoint) Then Call oPlanTrigpointsPlaceholders.Remove(sTrigpoint)
            If oProfileTrigpointsPlaceholders.ContainsKey(sTrigpoint) Then Call oProfileTrigpointsPlaceholders.Remove(sTrigpoint)

            For Each oOtherStation As cResurvey.cStation In oStations
                If oOtherStation.PlanConnectedTo.Contains(sTrigpoint) Then
                    Call oOtherStation.PlanConnectedTo.Remove(sTrigpoint)
                End If
            Next
            For Each oOtherStation As cResurvey.cStation In oStations
                If oOtherStation.ProfileConnectedTo.Contains(sTrigpoint) Then
                    Call oOtherStation.ProfileConnectedTo.Remove(sTrigpoint)
                End If
            Next

            Call oStations.Remove(sTrigpoint)

            Call grdStations.RefreshDataSource()

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
            Dim oStation As cResurvey.cStation = gridviewStations.GetFocusedRow
            Dim sTrigpoint As String = oStation.Name

            oStation.Type = "O"
            If Not oStation.PlanPlaceholder Is Nothing Then oStation.PlanPlaceholder.BackColor = oOriginColor
            If Not oStation.ProfilePlaceholder Is Nothing Then oStation.ProfilePlaceholder.BackColor = oOriginColor
            For Each oOtherStation As cResurvey.cStation In oStations
                If Not oOtherStation Is oStation And oOtherStation.Type = "O" Then
                    oOtherStation.Type = ""
                    If Not oOtherStation.PlanPlaceholder Is Nothing Then oOtherStation.PlanPlaceholder.BackColor = oGenericColor
                    If Not oOtherStation.ProfilePlaceholder Is Nothing Then oOtherStation.ProfilePlaceholder.BackColor = oGenericColor
                End If
            Next
            Call grdStations.RefreshDataSource()
            Call pDelayedPerformPaint()
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub tabMain_Resize(sender As Object, e As System.EventArgs)
        Call pDelayedPerformPaint()
    End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        'CheckForIllegalCrossThreadCalls = False

        'pnlPlanOrProfile.Dock = DockStyle.Fill
        'pnlMain.Dock = DockStyle.Fill

        Call dockStations.BringToFront()

        oOptions = New cResurvey.cOptions

        oPlanTrigpointsPlaceholders = New Dictionary(Of String, cResurvey.cTrigpointPlaceholder)
        oProfileTrigpointsPlaceholders = New Dictionary(Of String, cResurvey.cTrigpointPlaceholder)

        oShots = New cResurvey.cShots
        grdShots.DataSource = oShots
        Call grdShots.RefreshDataSource()

        oStations = New cResurvey.cStations
        grdStations.DataSource = oStations
        Call grdStations.RefreshDataSource()

        Dim oArrowCap As New AdjustableArrowCap(2, 2, True)
        oArrowCap.WidthScale = 2

        oNorthPen = New Pen(Color.FromArgb(200, Color.DarkRed), 2)
        oNorthPen.CustomEndCap = oArrowCap

        oScalePen = New Pen(Color.FromArgb(200, Color.Orange), 2)
        oScalePen.StartCap = LineCap.Round
        oScalePen.EndCap = LineCap.Round
        oDropScalePen = New Pen(Color.FromArgb(120, Color.OrangeRed), 1)
        oDropScalePen.StartCap = LineCap.Round
        oDropScalePen.EndCap = LineCap.Round

        oDropScaleRealPen = New Pen(Color.FromArgb(200, Color.OrangeRed), 2)
        oDropScaleRealPen.CustomStartCap = oArrowCap
        oDropScaleRealPen.CustomEndCap = oArrowCap

        oLRUDPen = New Pen(Color.FromArgb(220, Color.Green))
        oSelectedLRUDPen = New Pen(Color.FromArgb(220, Color.Green))
        oSelectedLRUDPen.Width = 3
        oShotsPen = New Pen(Color.FromArgb(220, Color.Coral), 1)
        oShotsPen.CustomEndCap = oArrowCap
        oSelectedShotsPen = New Pen(Color.FromArgb(220, Color.Coral), 3)
        oSelectedShotsPen.Width = 3
        oSelectedShotsPen.CustomEndCap = oArrowCap
        oTranslationsPen = New Pen(Color.FromArgb(240, Color.Blue))
        oTranslationsPen.DashStyle = DashStyle.Dot
        oSelectedTranslationPen = New Pen(Color.FromArgb(240, Color.Blue))
        oSelectedTranslationPen.DashStyle = DashStyle.Dot
        oSelectedTranslationPen.Width = 3
        oActiveStationPen = New Pen(Color.FromArgb(200, Color.Gray), -1)
        oActiveStationPen.DashStyle = DashStyle.Dot
        oLRUDAreaBrush = New SolidBrush(Color.FromArgb(50, Color.LightGreen))

        oRulesSecondaryPen = New Pen(oRulesColor, -1)
        oRulesSecondaryPen.DashStyle = DashStyle.Dash
        oRulesPen = New Pen(oRulesColor, -1)
        oRulesPen.DashStyle = DashStyle.Dot
        oRulesLabelPen = New Pen(oRulesColor, -1)
        oRulesLabelBrush = New SolidBrush(Color.FromArgb(180, Color.White))
        oRulesBrush = New SolidBrush(oRulesColor)
        oRulesFillBrush = New SolidBrush(Color.FromArgb(120, Color.WhiteSmoke))

        oRulerAngleFont = New Font(Me.Font.FontFamily, 12.0F, FontStyle.Bold)
        oRulerTickFont = New Font(Me.Font.FontFamily, 8.0F, FontStyle.Regular)
        oRulerFontBrush = New SolidBrush(Color.FromArgb(200, Color.DimGray))
        oRulerForegroundPen = New Pen(Color.FromArgb(200, Color.DimGray))
        oRulerCurrentAnglePen = New Pen(Color.FromArgb(200, Color.Red), 2)
        oRulerBackgroundBrush = New SolidBrush(Color.FromArgb(200, Color.LightGray))

        picPlan.AllowDrop = True
        picProfile.AllowDrop = True

        picPlan.AutoSize = False
        picPlan.SizeMode = PictureBoxSizeMode.Zoom
        picPlan.Visible = False

        picProfile.AutoSize = False
        picProfile.SizeMode = PictureBoxSizeMode.Zoom
        picProfile.Visible = False

        'pnlPlan = pnlMain.Panel1
        'pnlProfile = pnlMain.Panel2

        'oPlanVSB = New VScrollBar
        'pnlPlan.Controls.Add(oPlanVSB)
        'oPlanVSB.Dock = DockStyle.Right
        'oPlanVSB.SendToBack()
        'oPlanVSB.SmallChange = 1
        'oPlanVSB.LargeChange = 25

        'oPlanHSB = New HScrollBar
        'pnlPlan.Controls.Add(oPlanHSB)
        'oPlanHSB.Dock = DockStyle.Bottom
        'oPlanHSB.SendToBack()
        'oPlanHSB.SmallChange = 1
        'oPlanHSB.LargeChange = 25

        'picPlan.SendToBack()

        'oProfileVSB = New VScrollBar
        'pnlProfile.Controls.Add(oProfileVSB)
        'oProfileVSB.Dock = DockStyle.Right
        'oProfileVSB.SendToBack()
        'oProfileVSB.SmallChange = 1
        'oProfileVSB.LargeChange = 25

        'oProfileHSB = New HScrollBar
        'pnlProfile.Controls.Add(oProfileHSB)
        'oProfileHSB.Dock = DockStyle.Bottom
        'oProfileHSB.SendToBack()
        'oProfileHSB.SmallChange = 1
        'oProfileHSB.LargeChange = 25

        'picProfile.SendToBack()

        Dim sObjectsPath As String = modMain.GetApplicationPath & "\objects"
        'carico i cursori
        oOpenHandCursor = New Cursor(sObjectsPath & "\cursors\openhand.cur")
        oClosedHandCursor = New Cursor(sObjectsPath & "\cursors\closedhand.cur")
    End Sub

    Private Sub pStationProperties()
        Dim ostation As cResurvey.cStation = gridviewStations.GetFocusedRow
        If Not ostation Is Nothing Then
            Dim sTrigpoint As String = ostation.Name
            Using frmP As frmResurveyProperties = New frmResurveyProperties(oStations, ostation)
                Call tbPlan.Hide()
                Call tbProfile.Hide()
                AddHandler frmP.OnApply, AddressOf frmP_OnApply
                'AddHandler frmP.OnSelectionChanged, AddressOf frmP_OnSelectionChanged
                If frmP.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Call pPerformCalculate()
                End If
                RemoveHandler frmP.OnApply, AddressOf frmP_OnApply
                'RemoveHandler frmP.OnSelectionChanged, AddressOf frmP_OnSelectionChanged
            End Using
        End If
    End Sub

    Private Sub frmP_OnSelectionChanged(Sender As frmResurveyProperties, Args As frmResurveyProperties.cResurveyPropertiesEventArgs)
        Dim iFocusedRowHandle As Integer = gridviewStations.FindRow(Args.Station)
        gridviewStations.FocusedRowHandle = iFocusedRowHandle
        Call gridviewStations.ClearSelection()
        Call gridviewStations.SelectRow(iFocusedRowHandle)
        Call gridviewStations.MakeRowVisible(iFocusedRowHandle)
    End Sub

    Private Sub frmP_OnApply(Sender As frmResurveyProperties, Args As frmResurveyProperties.cResurveyPropertiesEventArgs)
        Call grdStations.RefreshDataSource()
        Call pDelayedPerformPaint()
    End Sub

    Private Sub mnuPreviewDeleteAll_Click(sender As System.Object, e As System.EventArgs)
        'If MsgBox(GetLocalizedString("resurvey.warning6"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("resurvey.warningtitle")) = MsgBoxResult.Yes Then
        '    Cursor = Cursors.WaitCursor
        '    Call oPlanTrigpointsPlaceholders.Clear()
        '    Call oProfileTrigpointsPlaceholders.Clear()

        '    Call oStations.Clear()
        '    Call grdStations.RefreshDataSource()

        '    Call pSelectPlaceholder(Nothing)
        '    Call pSelectLine(Nothing)

        '    Call pDelayedPerformPaint()
        '    Cursor = Cursors.Default
        'End If
    End Sub

    Private Sub mnuGridStationDelete_Click(sender As System.Object, e As System.EventArgs)
        Call pStationDelete()
    End Sub

    Private Function pGetFocusedStation() As cStation
        If gridviewStations.GetFocusedRow Is Nothing Then
            Return Nothing
        Else
            Return gridviewStations.GetFocusedRow
        End If
    End Function

    Private Sub mnuGridStationRemove_Click(sender As System.Object, e As System.EventArgs)
        Call pPlaceHolderDelete()
    End Sub

    Private Sub mnuGridStationProprieties_Click(sender As System.Object, e As System.EventArgs)
        Call pStationProperties()
    End Sub

    'Private Sub mnuGridStation_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles mnuGridStation.Opening
    '    If oLastPlaceHolder Is Nothing Then
    '        mnuGridStationRemove.Enabled = False
    '        mnuGridStationDelete.Enabled = Not pGetFocusedStation() Is Nothing
    '        mnuGridStationProperties.Enabled = False
    '        mnuGridStationSetOrigin.Enabled = False
    '    Else
    '        mnuGridStationRemove.Enabled = True
    '        mnuGridStationDelete.Enabled = True
    '        mnuGridStationProperties.Enabled = True
    '        Dim sType As String = ""
    '        Try : sType = oStations(oLastPlaceHolder.Name).Type : Catch : End Try
    '        mnuGridStationSetOrigin.Enabled = sType = ""
    '    End If
    'End Sub

    Private Sub mnuGridStationSetOrigin_Click(sender As System.Object, e As System.EventArgs)
        Call pStationSetOrigin()
    End Sub

    Private Sub mnuTabsLoadImage_Click(sender As System.Object, e As System.EventArgs)
        Call pImageLoad()
    End Sub

    'Private Sub mnuTabs_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
    '    If pGetCurrentProjection() = 0 Then
    '        mnuTabsLoadImage.Enabled = picPlan.Image Is Nothing
    '    Else
    '        mnuTabsLoadImage.Enabled = picProfile.Image Is Nothing
    '    End If
    'End Sub

    Private Sub picPlan_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles picPlan.MouseMove
        If (My.Computer.Keyboard.CtrlKeyDown And (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left) OrElse (e.Button And Windows.Forms.MouseButtons.Middle) = Windows.Forms.MouseButtons.Middle Then
            Call pPlanDoDragging(e)
            '    picPlan.Cursor = oClosedHandCursor
            '    Dim oPoint As Point = e.Location
            '    Dim iDeltaX As Integer = oDragScreenOffset.X - oPoint.X
            '    Dim iDeltaY As Integer = oDragScreenOffset.Y - oPoint.Y
            '    Dim oScrollPoint As Point = New Point(picPlan.Location.X - iDeltaX, picPlan.Location.Y - iDeltaY)
            '    If (picPlan.Width - pnlPlan.Width) > 0 Then
            '        If Math.Abs(oScrollPoint.X) > (picPlan.Width - pnlPlan.Width) Then
            '            oScrollPoint.X = -(picPlan.Width - pnlPlan.Width)
            '        ElseIf oScrollPoint.X > 0 Then
            '            oScrollPoint.X = 0
            '        End If
            '    Else
            '        oScrollPoint.X = 0
            '    End If
            '    If (picPlan.Height - pnlPlan.Height) > 0 Then
            '        If Math.Abs(oScrollPoint.Y) > (picPlan.Height - pnlPlan.Height) Then
            '            oScrollPoint.Y = -(picPlan.Height - pnlPlan.Height)
            '        ElseIf oScrollPoint.Y > 0 Then
            '            oScrollPoint.Y = 0
            '        End If 
            '    Else
            '        oScrollPoint.Y = 0
            '    End If
            '    picPlan.Location = oScrollPoint
            '    Call pBindScrollbars()
            'Else
            '    picPlan.Cursor = oOpenHandCursor
            'End If
        Else
            Dim oPoint As Point = New Point(e.Location.X / sPlanZoom, e.Location.Y / sPlanZoom)
            pnlCoordinates.Caption = "X: " & oPoint.X & " px; Y: " & oPoint.Y & " px"

            If bPlanRulerMovePoint Then
                If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
                    picPlan.Cursor = Cursors.Hand
                    oPlanRulerPosition.X += (oPoint.X - oPlanRulerMovePoint.X)
                    oPlanRulerPosition.Y += (oPoint.Y - oPlanRulerMovePoint.Y)
                    oPlanRulerMovePoint = oPoint
                    Call pInvalidateCurrentView()
                Else
                    picPlan.Cursor = oOpenHandCursor
                End If
            ElseIf Not pHitTestPlanPlaceholder(oPoint) Is Nothing Then
                picPlan.Cursor = Cursors.Hand
            ElseIf Not pHitTestPlanLine(oPoint) Is Nothing Then
                picPlan.Cursor = Cursors.Hand
            Else
                picPlan.Cursor = Cursors.Cross
            End If

            If Not oPlanLastPlaceHolder Is Nothing Then
                Dim dDistance As Decimal = modPaint.DistancePointToPoint(oPlanLastPlaceHolder.Point, oPoint)
                pnlDistance.Caption = "Δ: " & dDistance & " px"
                Dim oScale As cScale = pGetScale()
                Dim dScaledDistance As Decimal
                If pGetCurrentProjection() = 0 Then
                    If Not oScale.PlanError Then
                        dScaledDistance = modNumbers.MathRound(dDistance * oScale.PlanScale, 2)
                        pnlDistance.Caption &= " - " & dScaledDistance & " m"
                    End If
                ElseIf pGetCurrentProjection() = 1 Then
                    If Not oScale.ProfileError Then
                        dScaledDistance = modNumbers.MathRound(dDistance * oScale.ProfileScale, 2)
                        pnlDistance.Caption &= " - " & dScaledDistance & " m"
                    End If
                Else
                    pnlDistance.Caption = ""
                End If
                pnlAngle.Caption = "α:" & modPaint.GetBearing(oPlanLastPlaceHolder.Point, oPoint) & " °"
                If ((e.Button And MouseButtons.Left) = MouseButtons.Left) Then
                    If (Rectangle.op_Inequality(oDragboxFromMouseDown, Rectangle.Empty) And Not oDragboxFromMouseDown.Contains(oPoint)) Then
                        oDragScreenOffset = SystemInformation.WorkingArea.Location
                        Dim oDropEffect As DragDropEffects = picPlan.DoDragDrop(oPlanLastPlaceHolder, DragDropEffects.Link)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub picProfile_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles picProfile.MouseMove
        If (My.Computer.Keyboard.CtrlKeyDown And (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left) OrElse (e.Button And Windows.Forms.MouseButtons.Middle) = Windows.Forms.MouseButtons.Middle Then
            Call pProfileDoDragging(e)
            'picProfile.Cursor = oClosedHandCursor
            '    Dim oPoint As Point = e.Location
            '    Dim iDeltaX As Integer = oDragScreenOffset.X - oPoint.X
            '    Dim iDeltaY As Integer = oDragScreenOffset.Y - oPoint.Y
            '    Dim oScrollPoint As Point = New Point(picProfile.Location.X - iDeltaX, picProfile.Location.Y - iDeltaY)
            '    If (picProfile.Width - pnlProfile.Width) > 0 Then
            '        If Math.Abs(oScrollPoint.X) > (picProfile.Width - pnlProfile.Width) Then
            '            oScrollPoint.X = -(picProfile.Width - pnlProfile.Width)
            '        ElseIf oScrollPoint.X > 0 Then
            '            oScrollPoint.X = 0
            '        End If
            '    Else
            '        oScrollPoint.X = 0
            '    End If
            '    If (picProfile.Height - pnlProfile.Height) > 0 Then
            '        If Math.Abs(oScrollPoint.Y) > (picProfile.Height - pnlProfile.Height) Then
            '            oScrollPoint.Y = -(picProfile.Height - pnlProfile.Height)
            '        ElseIf oScrollPoint.Y > 0 Then
            '            oScrollPoint.Y = 0
            '        End If
            '    Else
            '        oScrollPoint.Y = 0
            '    End If
            '    picProfile.Location = oScrollPoint
            '    Call pBindScrollbars()
            'Else
            '    picProfile.Cursor = oOpenHandCursor
            'End If
        Else
            Dim oPoint As Point = New Point(e.Location.X / sProfileZoom, e.Location.Y / sProfileZoom)
            pnlCoordinates.Caption = "X: " & oPoint.X & " px; Y: " & oPoint.Y & " px"

            If bProfileRulerMovePoint Then
                If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
                    picProfile.Cursor = Cursors.Hand
                    oProfileRulerPosition.X += (oPoint.X - oProfileRulerMovePoint.X)
                    oProfileRulerPosition.Y += (oPoint.Y - oProfileRulerMovePoint.Y)
                    oProfileRulerMovePoint = oPoint
                    Call pInvalidateCurrentView()
                Else
                    picProfile.Cursor = oOpenHandCursor
                End If
            ElseIf Not pHitTestProfilePlaceholder(oPoint) Is Nothing Then
                picProfile.Cursor = Cursors.Hand
            ElseIf Not pHitTestProfileLine(oPoint) Is Nothing Then
                picProfile.Cursor = Cursors.Hand
            Else
                picProfile.Cursor = Cursors.Cross
            End If

            If Not oProfileLastPlaceHolder Is Nothing Then
                pnlDistance.Caption = "Δ: " & modPaint.DistancePointToPoint(oProfileLastPlaceHolder.Point, oPoint) & " px"
                pnlAngle.Caption = "α: " & modPaint.GetInclination(oProfileLastPlaceHolder.Point, oPoint) & " °"
                If ((e.Button And MouseButtons.Left) = MouseButtons.Left) Then
                    If (Rectangle.op_Inequality(oDragboxFromMouseDown, Rectangle.Empty) And Not oDragboxFromMouseDown.Contains(oPoint)) Then
                        oDragScreenOffset = SystemInformation.WorkingArea.Location
                        Dim oDropEffect As DragDropEffects = picProfile.DoDragDrop(oProfileLastPlaceHolder, DragDropEffects.Link)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnConfirm_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnConfirm.ItemClick
        If MsgBox(GetLocalizedString("resurvey.warning7"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("resurvey.warningtitle")) = MsgBoxResult.Yes Then
            DialogResult = Windows.Forms.DialogResult.OK
            Call Close()
        End If
    End Sub

    Private Sub btnClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClose.ItemClick
        DialogResult = Windows.Forms.DialogResult.Cancel
        Call Close()
    End Sub

    Friend ReadOnly Property Options As cResurvey.cOptions
        Get
            Return oOptions
        End Get
    End Property

    Friend ReadOnly Property Shots As cResurvey.cShots
        Get
            Return oShots
        End Get
    End Property

    Friend ReadOnly Property Stations As cResurvey.cStations
        Get
            Return oStations
        End Get
    End Property

    Private Sub pChangeCurrentProjection()
        Select Case pGetCurrentProjection()
            Case 0
                Dim bThereIsImage As Boolean = Not picPlan.Image Is Nothing
                grpImageColors.Enabled = bThereIsImage
                grpView.Enabled = bThereIsImage
                grpPlaceholders.Enabled = bThereIsImage
                grpLinks.Enabled = bThereIsImage

                pnlZoom.Enabled = bThereIsImage
                btnZoomToFit.Enabled = True
                btnZoomIn.Enabled = True
                btnZoomOut.Enabled = True
                btnZoom100.Enabled = True
                btnZoom200.Enabled = True
                btnZoom25.Enabled = True
                btnZoom50.Enabled = True

                btnSaveImage.Enabled = bThereIsImage
                btnClearImage.Enabled = bThereIsImage

                'NO...have to be taken from current proj
                pnlCoordinates.Caption = ""
                'if there is no current placeholder I create it from current row
                'If oPlanLastPlaceHolder Is Nothing Then
                '    Dim oStation As cStation = gridviewStations.GetFocusedRow
                '    If Not oStation Is Nothing Then
                '        oPlanLastPlaceHolder = oStation.PlanPlaceholder
                '    End If
                'End If
                If oPlanLastLine Is Nothing Then
                    'select the last placehoder (if there is one)
                    Call pSelectPlaceholder(oPlanLastPlaceHolder, True)
                Else
                    'select the last line (if there is one)
                    Call pSelectLine(oPlanLastLine, True)
                End If

                Call pUpdateZoomFactor()
                pnlCurrentProjection.Caption = GetLocalizedString("resurvey.textpart1")
            Case 1
                Dim bThereIsImage As Boolean = Not picProfile.Image Is Nothing
                grpImageColors.Enabled = bThereIsImage
                grpView.Enabled = bThereIsImage
                grpPlaceholders.Enabled = bThereIsImage
                grpLinks.Enabled = bThereIsImage

                pnlZoom.Enabled = bThereIsImage
                btnZoomToFit.Enabled = True
                btnZoomIn.Enabled = True
                btnZoomOut.Enabled = True
                btnZoom100.Enabled = True
                btnZoom200.Enabled = True
                btnZoom25.Enabled = True
                btnZoom50.Enabled = True

                btnSaveImage.Enabled = bThereIsImage
                btnClearImage.Enabled = bThereIsImage

                'NO...have to be taken from current proj
                pnlCoordinates.Caption = ""
                'if there is no current placeholder I create it from current row
                'If oProfileLastPlaceHolder Is Nothing Then
                '    Dim oStation As cStation = gridviewStations.GetFocusedRow
                '    If Not oStation Is Nothing Then
                '        oProfileLastPlaceHolder = oStation.ProfilePlaceholder
                '    End If
                'End If
                If oProfileLastLine Is Nothing Then
                    'select the last placehoder (if there is one)
                    Call pSelectPlaceholder(oProfileLastPlaceHolder, True)
                Else
                    'select the last line (if there is one)
                    Call pSelectLine(oProfileLastLine, True)
                End If

                Call pUpdateZoomFactor()
                pnlCurrentProjection.Caption = GetLocalizedString("resurvey.textpart2")
            Case Else
                grpImageColors.Enabled = False
                grpView.Enabled = False
                grpPlaceholders.Enabled = False
                grpLinks.Enabled = False

                pnlZoom.Enabled = False
                btnZoomToFit.Enabled = False
                btnZoomIn.Enabled = False
                btnZoomOut.Enabled = False
                btnZoom100.Enabled = False
                btnZoom200.Enabled = False
                btnZoom25.Enabled = False
                btnZoom50.Enabled = False

                pnlCoordinates.Caption = ""

                'clear selection cause I'm not in plan or in profile
                Call pSelectPlaceholder(Nothing, True)
                Call pSelectLine(Nothing, True)

                Call pUpdateZoomFactor()
                pnlCurrentProjection.Caption = "N/D"
        End Select
    End Sub

    Private Function pGetCurrentProjection() As Integer
        If DocumentManager.View Is Nothing Then
            Return -1
        Else
            If DocumentManager.View.ActiveDocument Is Nothing Then
                Return -1
            Else
                If DocumentManager.View.ActiveDocument.Control Is dockPlan Then
                    Return 0
                ElseIf DocumentManager.View.ActiveDocument.Control Is dockProfile Then
                    Return 1
                Else
                    Return -1
                End If
            End If
        End If
        'If oOptions Is Nothing Then
        '    Return 0
        'Else
        '    If oOptions.CalculateMode = cResurvey.cOptions.CalculateModeEnum.OnlyPlan Then
        '        Return 0
        '    Else
        '        Return iCurrentProject
        '    End If
        'End If
    End Function

    Private iStartDragDistance As Integer = 5

    Private oPlanStartPoint As Point = Point.Empty
    Private bPlanisDraggingImage As Boolean
    Private iPlanStartVScrollValue As Integer
    Private iPlanStartHScrollValue As Integer

    Private Sub pPlanStartDragging()
        picPlan.Cursor = Cursors.Hand
        bPlanisDraggingImage = True
        iPlanStartVScrollValue = pnlPlan.VerticalScroll.Value
        iPlanStartHScrollValue = pnlPlan.HorizontalScroll.Value
    End Sub

    Private Sub pPlanEndDragging()
        picPlan.Cursor = Cursors.Default
        bPlanisDraggingImage = False
    End Sub

    Private oProfileStartPoint As Point = Point.Empty
    Private bProfileisDraggingImage As Boolean
    Private iProfileStartVScrollValue As Integer
    Private iProfileStartHScrollValue As Integer

    Private Sub pProfileStartDragging()
        picProfile.Cursor = Cursors.Hand
        bProfileisDraggingImage = True
        iProfileStartVScrollValue = pnlProfile.VerticalScroll.Value
        iProfileStartHScrollValue = pnlProfile.HorizontalScroll.Value
    End Sub

    Private Sub pProfileEndDragging()
        picProfile.Cursor = Cursors.Default
        bProfileisDraggingImage = False
    End Sub

    Private Sub pPlanDoDragging(e As MouseEventArgs)
        Dim oP As Point = New Point(e.X, e.Y)
        oP = picPlan.PointToScreen(oP)
        Dim dx As Integer = oP.X - oPlanStartPoint.X
        Dim dy As Integer = oP.Y - oPlanStartPoint.Y
        If (bPlanisDraggingImage) Then
            Try
                pnlPlan.VerticalScroll.Value = iPlanStartVScrollValue - dy
                pnlPlan.HorizontalScroll.Value = iPlanStartHScrollValue - dx
            Catch ex As Exception
            End Try
        Else
            If (Math.Abs(dx) > iStartDragDistance OrElse Math.Abs(dy) > iStartDragDistance) Then
                Call pPlanStartDragging()
            End If
        End If
    End Sub

    Private Sub pProfileDoDragging(e As MouseEventArgs)
        Dim oP As Point = New Point(e.X, e.Y)
        oP = picProfile.PointToScreen(oP)
        Dim dx As Integer = oP.X - oProfileStartPoint.X
        Dim dy As Integer = oP.Y - oProfileStartPoint.Y
        If (bProfileisDraggingImage) Then
            Try
                pnlProfile.VerticalScroll.Value = iProfileStartVScrollValue - dy
                pnlProfile.HorizontalScroll.Value = iProfileStartHScrollValue - dx
            Catch ex As Exception
            End Try
        Else
            If (Math.Abs(dx) > iStartDragDistance OrElse Math.Abs(dy) > iStartDragDistance) Then
                Call pProfileStartDragging()
            End If
        End If
    End Sub

    Private Sub picPlan_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles picPlan.MouseUp
        oDragboxFromMouseDown = Rectangle.Empty
        bPlanRulerMovePoint = False
        If bPlanisDraggingImage Then
            Call pPlanEndDragging()
        Else
            picPlan.Cursor = Cursors.Default
            If (e.Button And Windows.Forms.MouseButtons.Right) = Windows.Forms.MouseButtons.Right Then
                If oPlanLastPlaceHolder Is Nothing Then
                    Call mnuDesignAdd.ShowPopup(picPlan.PointToScreen(e.Location))
                Else
                    If bLineSelected Then
                        Call mnuDesignLink.ShowPopup(picPlan.PointToScreen(e.Location))
                    Else
                        Call mnuDesign.ShowPopup(picPlan.PointToScreen(e.Location))
                    End If
                End If
            ElseIf e.Button And MouseButtons.Left = MouseButtons.Left Then
                If oPlanLastLine Is Nothing Then
                    If oPlanLastPlaceHolder Is Nothing Then
                        Call tbPlan.Hide()
                    Else
                        btnLeftEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                        btnRightEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                        Dim iPadding As Integer = 4
                        Dim oSelectionPoint As Point
                        Dim oBounds As RectangleF = oPlanLastPlaceHolder.HotSpot
                        oSelectionPoint = New Point(oBounds.Right, oBounds.Top)
                        tbPlan.Alignment = ContentAlignment.TopRight
                        oSelectionPoint = New Point(oSelectionPoint.X * sPlanZoom, oSelectionPoint.Y * sPlanZoom)
                        oSelectionPoint = picPlan.PointToScreen(oSelectionPoint)
                        Call tbPlan.Show(oSelectionPoint)
                    End If
                Else
                    If oShots.Contains(oPlanLastLine) Then
                        Dim oShot As cShot = oShots(oPlanLastLine)
                        btnLeftEdit.Tag = oShot
                        btnLeftEdit.EditValue = oShot.EditUserLeft
                        btnLeftEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                        btnRightEdit.Tag = oShot
                        btnRightEdit.EditValue = oShot.EditUserRight
                        btnRightEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    Else
                        btnLeftEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                        btnRightEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                    End If
                    Dim iPadding As Integer = 4
                    Dim oSelectionPoint As Point
                    Dim oBounds As RectangleF = cCache.GetPlanLineBound(oPlanLastLine)
                    Call oBounds.Inflate(iPadding, iPadding)
                    Select Case modPaint.GetQuadrant(oBounds, If(oOptions.LRUDStation = cOptions.LRUDStationEnum.FromStation, oPlanLastLine(0).Point, oPlanLastLine(1).Point))
                        Case modPaint.Quadrant.TopLeft
                            oSelectionPoint = New Point(oBounds.Left, oBounds.Top)
                            tbPlan.Alignment = ContentAlignment.TopLeft
                        Case modPaint.Quadrant.TopRight
                            oSelectionPoint = New Point(oBounds.Right, oBounds.Top)
                            tbPlan.Alignment = ContentAlignment.TopRight
                        Case modPaint.Quadrant.BottomRight
                            oSelectionPoint = New Point(oBounds.Right, oBounds.Bottom)
                            tbPlan.Alignment = ContentAlignment.BottomRight
                        Case modPaint.Quadrant.BottomLeft
                            oSelectionPoint = New Point(oBounds.Left, oBounds.Bottom)
                            tbPlan.Alignment = ContentAlignment.BottomLeft
                    End Select
                    oSelectionPoint = New Point(oSelectionPoint.X * sPlanZoom, oSelectionPoint.Y * sPlanZoom)
                    oSelectionPoint = picPlan.PointToScreen(oSelectionPoint)
                    Call tbPlan.Show(oSelectionPoint)
                End If
            End If
        End If
        bTPHSelected = False
        bLineSelected = False

    End Sub

    Private Sub picProfile_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles picProfile.MouseUp
        oDragboxFromMouseDown = Rectangle.Empty
        bProfileRulerMovePoint = False
        If bProfileisDraggingImage Then
            Call pProfileEndDragging()
        Else
            picProfile.Cursor = Cursors.Default
            If (e.Button And Windows.Forms.MouseButtons.Right) = Windows.Forms.MouseButtons.Right Then
                If oProfileLastPlaceHolder Is Nothing Then
                    Call mnuDesignAdd.ShowPopup(picProfile.PointToScreen(e.Location))
                Else
                    If bLineSelected Then
                        Call mnuDesignLink.ShowPopup(picProfile.PointToScreen(e.Location))
                    Else
                        Call mnuDesign.ShowPopup(picProfile.PointToScreen(e.Location))
                    End If
                End If
            ElseIf e.Button And MouseButtons.Left = MouseButtons.Left Then
                If oProfileLastLine Is Nothing Then
                    If oProfileLastPlaceHolder Is Nothing Then
                        Call tbProfile.Hide()
                    Else
                        btnUpEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                        btnDownEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                        Dim iPadding As Integer = 4
                        Dim oSelectionPoint As Point
                        Dim oBounds As RectangleF = oProfileLastPlaceHolder.HotSpot
                        oSelectionPoint = New Point(oBounds.Right, oBounds.Top)
                        tbProfile.Alignment = ContentAlignment.TopRight
                        oSelectionPoint = New Point(oSelectionPoint.X * sProfileZoom, oSelectionPoint.Y * sProfileZoom)
                        oSelectionPoint = picProfile.PointToScreen(oSelectionPoint)
                        Call tbProfile.Show(oSelectionPoint)
                    End If

                Else
                    If oShots.Contains(oProfileLastLine) Then
                        Dim oShot As cShot = oShots(oProfileLastLine)
                        btnUpEdit.Tag = oShot
                        btnUpEdit.EditValue = oShot.EditUserUp
                        btnUpEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                        btnDownEdit.Tag = oShot
                        btnDownEdit.EditValue = oShot.EditUserDown
                        btnDownEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    Else
                        btnUpEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                        btnDownEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                    End If
                    Dim iPadding As Integer = 4
                    Dim oSelectionPoint As Point
                    Dim oBounds As RectangleF = cCache.GetProfileLineBound(oProfileLastLine)
                    Call oBounds.Inflate(iPadding, iPadding)
                    Select Case modPaint.GetQuadrant(oBounds, If(oOptions.LRUDStation = cOptions.LRUDStationEnum.FromStation, oProfileLastLine(0).Point, oProfileLastLine(1).Point))
                        Case modPaint.Quadrant.TopLeft
                            oSelectionPoint = New Point(oBounds.Left, oBounds.Top)
                            tbProfile.Alignment = ContentAlignment.TopLeft
                        Case modPaint.Quadrant.TopRight
                            oSelectionPoint = New Point(oBounds.Right, oBounds.Top)
                            tbProfile.Alignment = ContentAlignment.TopRight
                        Case modPaint.Quadrant.BottomRight
                            oSelectionPoint = New Point(oBounds.Right, oBounds.Bottom)
                            tbProfile.Alignment = ContentAlignment.BottomRight
                        Case modPaint.Quadrant.BottomLeft
                            oSelectionPoint = New Point(oBounds.Left, oBounds.Bottom)
                            tbProfile.Alignment = ContentAlignment.BottomLeft
                    End Select
                    oSelectionPoint = New Point(oSelectionPoint.X * sProfileZoom, oSelectionPoint.Y * sProfileZoom)
                    oSelectionPoint = picProfile.PointToScreen(oSelectionPoint)
                    Call tbProfile.Show(oSelectionPoint)
                End If
            End If
        End If
        bTPHSelected = False
        bLineSelected = False


    End Sub

    'Private Sub pSelectProfilePlaceholder(Point As Point)
    '    Call pSelectPlaceholder(pHitTestProfilePlaceholder(Point))
    '    If oProfileLastPlaceHolder Is Nothing Then
    '        Call pSelectProfileLine(Point)
    '    Else
    '        Call pSelectLine(Nothing)
    '    End If
    'End Sub

    Private Function pHitTestProfilePlaceholder(Point As Point) As cResurvey.cTrigpointPlaceholder
        For Each oTPH As cResurvey.cTrigpointPlaceholder In oProfileTrigpointsPlaceholders.Values
            Dim oStation As cStation = oStations(oTPH.Name)
            If Not oStation Is Nothing AndAlso oStation.ProfileVisible Then
                If oTPH.HotSpot.Contains(Point) Then
                    Return oTPH
                End If
            End If
        Next
        Return Nothing
    End Function

    Private Function pHitTestPlanRuler(Point As PointF) As Boolean
        If btnShowRulers.Checked AndAlso btnShowRuler.Checked Then
            Using omatrix = New Matrix
                Call omatrix.RotateAt(sPlanRulerAngle, oPlanRulerPosition, MatrixOrder.Prepend)
                Dim oBackgroudRect As RectangleF = New RectangleF(oPlanRulerPosition.X - 10000, oPlanRulerPosition.Y - sRulerHeight / 2, 20000, sRulerHeight)
                Using oPath As GraphicsPath = New GraphicsPath
                    oPath.AddRectangle(oBackgroudRect)
                    oPath.Transform(omatrix)
                    Return oPath.IsVisible(Point)
                End Using
            End Using
        End If
    End Function

    Private Function pHitTestProfileRuler(Point As PointF) As Boolean
        If btnShowRulers.Checked AndAlso btnShowRuler.Checked Then
            Using omatrix = New Matrix
                Call omatrix.RotateAt(sProfileRulerAngle, oProfileRulerPosition, MatrixOrder.Prepend)
                Dim oBackgroudRect As RectangleF = New RectangleF(oProfileRulerPosition.X - 10000, oProfileRulerPosition.Y - sRulerHeight / 2, 20000, sRulerHeight)
                Using oPath As GraphicsPath = New GraphicsPath
                    oPath.AddRectangle(oBackgroudRect)
                    oPath.Transform(omatrix)
                    Return oPath.IsVisible(Point)
                End Using
            End Using
        End If
    End Function

    Private Function pHitTestPlanPlaceholder(Point As Point) As cResurvey.cTrigpointPlaceholder
        For Each oTPH As cResurvey.cTrigpointPlaceholder In oPlanTrigpointsPlaceholders.Values
            Dim oStation As cStation = oStations(oTPH.Name)
            If Not oStation Is Nothing AndAlso oStation.PlanVisible Then
                If oTPH.HotSpot.Contains(Point) Then
                    Return oTPH
                End If
            End If
        Next
        Return Nothing
    End Function

    Private Sub pReorderConnections()
        For Each oStation As cStation In oStations
            Dim sStation As String = oStation.Name
            For Each sNextStation As String In oStation.PlanConnectedTo.ToList
                Dim oNextStation As cStation = oStations(sNextStation)
                If Not pCompareStationName(sStation, sNextStation) Then
                    Call oNextStation.PlanConnectedTo.Add(sStation)
                    Call oStation.PlanConnectedTo.Remove(sNextStation)
                ElseIf sNextStation = sStation Then
                    Call oStation.PlanConnectedTo.Remove(sNextStation)
                End If
            Next
            For Each sNextStation As String In oStation.ProfileConnectedTo.ToList
                Dim oNextStation As cStation = oStations(sNextStation)
                If Not pCompareStationName(sStation, sNextStation) Then
                    Call oNextStation.ProfileConnectedTo.Add(sStation)
                    Call oStation.ProfileConnectedTo.Remove(sNextStation)
                ElseIf sNextStation = sStation Then
                    Call oStation.ProfileConnectedTo.Remove(sNextStation)
                End If
            Next
        Next

        Call grdStations.RefreshDataSource()
    End Sub

    Private Class cStationNameParts
        Private sPrefix As String
        Private sSuffix As String
        Private iNumber As Integer
        Private iTranslation As Integer

        Public Function GetFormattedStationName() As String
            Return sPrefix & Strings.Format(iNumber, "000000") & sSuffix & Strings.Format(iTranslation, "000")
        End Function

        Public ReadOnly Property Suffix As String
            Get
                Return sSuffix
            End Get
        End Property

        Public ReadOnly Property Prefix As String
            Get
                Return sPrefix
            End Get
        End Property

        Public ReadOnly Property Number As Integer
            Get
                Return iNumber
            End Get
        End Property

        Public ReadOnly Property Translation As Integer
            Get
                Return iTranslation
            End Get
        End Property

        Public Sub New(Prefix As String, Number As Integer, Suffix As String, Translation As Integer)
            sPrefix = Prefix
            iNumber = Number
            sSuffix = Suffix
            iTranslation = 0
        End Sub

        Public Shared Function Parse(Station As String) As cStationNameParts
            Dim sNumber As String = ""
            Dim sPrefix As String = ""
            Dim sSuffix As String = ""
            Dim iTranslation As Integer = 0

            Dim iIndex As Integer = 0
            If Station = "" Then
                Return New cStationNameParts("", 0, "", 0)
            Else
                Do While Station.EndsWith(">")
                    iTranslation += 1
                    Station = Station.Remove(Station.Count - 1)
                Loop
                If Char.IsDigit(Station(0)) Then
                    If iIndex < Station.Length Then
                        Do While Char.IsDigit(Station.Chars(iIndex))
                            sNumber = sNumber & Station.Chars(iIndex)
                            iIndex += 1
                            If iIndex >= Station.Length Then Exit Do
                        Loop
                    End If
                    If iIndex < Station.Length Then
                        Do While Char.IsLetter(Station.Chars(iIndex))
                            sSuffix = sSuffix & Station.Chars(iIndex)
                            iIndex += 1
                            If iIndex >= Station.Length Then Exit Do
                        Loop
                    End If
                    If iIndex = Station.Length Then
                        Dim sFormat As String = Strings.StrDup(Station.Length - sPrefix.Length, "0")
                        Dim iNumber As Integer
                        If Integer.TryParse(sNumber, iNumber) Then
                            Return New cStationNameParts(sPrefix, iNumber, sSuffix, iTranslation)
                        Else
                            Return New cStationNameParts("", 0, Station, iTranslation)
                        End If
                    Else
                        Return New cStationNameParts("", 0, Station, iTranslation)
                    End If
                Else
                    'A[A]0[0][A]
                    If iIndex < Station.Length Then
                        Do While Char.IsLetter(Station.Chars(iIndex))
                            sPrefix = sPrefix & Station.Chars(iIndex)
                            iIndex += 1
                            If iIndex >= Station.Length Then Exit Do
                        Loop
                    End If
                    If iIndex < Station.Length Then
                        Do While Char.IsDigit(Station.Chars(iIndex))
                            sNumber = sNumber & Station.Chars(iIndex)
                            iIndex += 1
                            If iIndex >= Station.Length Then Exit Do
                        Loop
                    End If
                    If iIndex < Station.Length Then
                        sSuffix = Station.Substring(iIndex)
                    End If
                    If iIndex = Station.Length Then
                        Dim sFormat As String = Strings.StrDup(Station.Length - sPrefix.Length, "0")
                        Dim iNumber As Integer
                        If Integer.TryParse(sNumber, iNumber) Then
                            Return New cStationNameParts(sPrefix, iNumber, sSuffix, iTranslation)
                        Else
                            Return New cStationNameParts(Station, 0, "", iTranslation)
                        End If
                    Else
                        Return New cStationNameParts(Station, 0, "", iTranslation)
                    End If
                End If
            End If
        End Function
    End Class

    Private Function pCompareStationName(Station1 As String, Station2 As String) As Boolean
        Dim oStation1Part As cStationNameParts = cStationNameParts.Parse(Station1)
        Dim oStation2Part As cStationNameParts = cStationNameParts.Parse(Station2)
        Return oStation1Part.GetFormattedStationName < oStation2Part.GetFormattedStationName
    End Function

    Private Function pHitTestPlanLine(Point As Point) As cResurvey.cTrigpointPlaceholder()
        Dim oLine As cResurvey.cTrigpointPlaceholder() = Nothing
        Dim iMinDistance As Integer = Integer.MaxValue
        For Each oFromTPH As cResurvey.cTrigpointPlaceholder In oPlanTrigpointsPlaceholders.Values
            Dim oFromPoint As Point = oFromTPH.Point
            For Each sToConnectedTo As String In oStations(oFromTPH.Name).PlanConnectedTo
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
            For Each sToConnectedTo As String In oStations(oFromTPH.Name).ProfileConnectedTo
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

    'Private Sub pSelectPlanLine(Point As Point)
    '    oPlanLastLine = pHitTestPlanLine(Point)
    'End Sub

    'Private Sub pSelectProfileLine(Point As Point)
    '    oProfileLastLine = pHitTestProfileLine(Point)
    'End Sub

    Private Sub btnOptions_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnOptions.ItemClick
        Using frmO As frmResurveyOptions = New frmResurveyOptions(oOptions, oStations.Count > 0)
            With frmO
                .txtNordCorrection.Enabled = Not (pContainsFirstNorth() OrElse pContainsSecondNorth())
                If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Call oOptions.CopyFrom(.CurrentOptions)
                    Call pSetCalculateMode()
                    Call pPerformCalculate()
                End If
            End With
        End Using
    End Sub

    Private Function pGetDocument(Name As String) As Tabbed.Document
        Dim sName As String = Name.ToLower
        For Each oDocument As Tabbed.Document In DocumentManager.View.Documents
            If oDocument.ControlName.ToLower = sName Then
                Return oDocument
            End If
        Next
    End Function

    Private Sub pSetCalculateMode()
        Select Case oOptions.CalculateMode
            Case cResurvey.cOptions.CalculateModeEnum.Full
                'docPlan.Control.Visible = True
                'docProfile.Control.Visible = True
                'docPlan = pGetDocument("dockplan")
                'docProfile = pGetDocument("dockprofile")
                'If Not DocumentManager.View.Documents.Contains(docProfile) Then Call DocumentManager.View.Documents.Add(docProfile)
                'docProfile.Control.Visible = True
                pnlProfile.Visible = True

                If oOptions.UseDropForInclination Then
                    colShotsDrop.Visible = True
                    colShotsPlanimetricDistance.Visible = True
                Else
                    colShotsDrop.Visible = False
                    colShotsPlanimetricDistance.Visible = False
                End If
            Case cResurvey.cOptions.CalculateModeEnum.OnlyPlan
                'docPlan.Control.Visible = True
                'docProfile.Control.Visible = False

                'docPlan = pGetDocument("dockplan")
                'docProfile = pGetDocument("dockprofile")
                'docPlan = DocumentManager.GetDocument(picPlan)
                'docProfile = DocumentManager.GetDocument(picProfile)
                'docProfile.Control.Visible = False
                'If DocumentManager.View.Documents.Contains(docProfile) Then Call DocumentManager.View.Documents.Remove(docProfile)
                pnlProfile.Visible = False

                'Call DocumentManager.View.Documents.Remove(docProfile)
                colShotsDrop.Visible = False
                colShotsPlanimetricDistance.Visible = False
                'Call pSetCurrentProjection(0)
        End Select
        iDefaultCalculateMode = oOptions.CalculateMode
        If oOptions.LRUDStation = cOptions.LRUDStationEnum.NotManaged Then
            colShotsLeft.Visible = False
            colShotsRight.Visible = False
            colShotsUp.Visible = False
            colShotsDown.Visible = False
            colShotsUserLeft.Visible = False
            colShotsUserRight.Visible = False
            colShotsUserUp.Visible = False
            colShotsUserDown.Visible = False
        Else
            If oOptions.CalculateLRUD Then
                colShotsLeft.Visible = True
                colShotsRight.Visible = True
                colShotsUp.Visible = True
                colShotsDown.Visible = True
                colShotsUserLeft.Visible = True
                colShotsUserRight.Visible = True
                colShotsUserUp.Visible = True
                colShotsUserDown.Visible = True
            Else
                colShotsLeft.Visible = False
                colShotsRight.Visible = False
                colShotsUp.Visible = False
                colShotsDown.Visible = False
                colShotsUserLeft.Visible = True
                colShotsUserRight.Visible = True
                colShotsUserUp.Visible = True
                colShotsUserDown.Visible = True
            End If
        End If
    End Sub

    'Private Sub mnuPreviewDeleteLink_Click(sender As Object, e As EventArgs) Handles mnuPreviewDeleteLink.Click
    '    Cursor = Cursors.WaitCursor

    '    Dim oFromTPH As cResurvey.cTrigpointPlaceholder = oLastLine(0)
    '    Dim oToTPH As cResurvey.cTrigpointPlaceholder = oLastLine(1)

    '    Dim iPlanOrProfile As Integer = pGetCurrentProjection()

    '    Dim oFromStation As cResurvey.cStation = oStations(oFromTPH.Name)
    '    Dim sFromConnectedTo As String
    '    If iPlanOrProfile = 0 Then
    '        sFromConnectedTo = oFromStation.PlanConnectedTo
    '    Else
    '        sFromConnectedTo = oFromStation.ProfileConnectedTo
    '    End If
    '    Dim oFromConnectedTo As List(Of String) = cResurvey.cStation.GetConnectedToCollection(sFromConnectedTo)
    '    Call oFromConnectedTo.Remove(oToTPH.Name)
    '    sFromConnectedTo = cResurvey.cStation.SetConnectedToFromCollection(oFromConnectedTo)
    '    If iPlanOrProfile = 0 Then
    '        oFromStation.PlanConnectedTo = sFromConnectedTo
    '    Else
    '        oFromStation.ProfileConnectedTo = sFromConnectedTo
    '    End If

    '    Dim otoStation As cResurvey.cStation = oStations(oToTPH.Name)
    '    Dim stoConnectedTo As String
    '    If iPlanOrProfile = 0 Then
    '        stoConnectedTo = otoStation.PlanConnectedTo
    '    Else
    '        stoConnectedTo = otoStation.ProfileConnectedTo
    '    End If
    '    Dim otoConnectedTo As List(Of String) = cResurvey.cStation.GetConnectedToCollection(stoConnectedTo)
    '    Call otoConnectedTo.Remove(oFromTPH.Name)
    '    stoConnectedTo = cResurvey.cStation.SetConnectedToFromCollection(otoConnectedTo)
    '    If iPlanOrProfile = 0 Then
    '        otoStation.PlanConnectedTo = stoConnectedTo
    '    Else
    '        otoStation.ProfileConnectedTo = stoConnectedTo
    '    End If

    '    Call grdStations.RefreshDataSource()

    '    oLastLine = Nothing

    '    Call pPerformCalculate(False)
    '    Call pPerformPaint()

    '    Cursor = Cursors.Default
    'End Sub

    Private Sub picPlan_DragDrop(sender As Object, e As DragEventArgs) Handles picPlan.DragDrop
        If (e.Data.GetDataPresent(GetType(cResurvey.cTrigpointPlaceholder))) Then
            Dim oPoint As Point = picPlan.PointToClient(New Point(e.X, e.Y))
            oPoint = New Point(oPoint.X / sPlanZoom, oPoint.Y / sPlanZoom)
            Dim oToTPH As cResurvey.cTrigpointPlaceholder = pHitTestPlanPlaceholder(oPoint)
            If Not oToTPH Is Nothing Then
                Dim oFromTPH As cResurvey.cTrigpointPlaceholder = e.Data.GetData(GetType(cResurvey.cTrigpointPlaceholder))
                If oFromTPH.Projection = 0 Then
                    If oFromTPH.Name > oToTPH.Name Then
                        Dim oTempTPH As cResurvey.cTrigpointPlaceholder = oToTPH
                        oToTPH = oFromTPH
                        oFromTPH = oTempTPH
                    End If
                    Dim oStation As cResurvey.cStation = oStations(oFromTPH.Name)
                    'If Not oStation.PlanConnectedTo.Contains(oToTPH.Name) AndAlso Not oStations(oToTPH.Name).PlanConnectedTo.Contains(oStation.Name) Then
                    'Call oStation.PlanConnectedTo.Add(oToTPH.Name)
                    If Not oStation.PlanConnectedTo.Contains(oToTPH.Name) Then
                        Call oStation.PlanConnectedTo.Add(oToTPH.Name)
                        Call oStations(oToTPH.Name).PlanConnectedTo.Remove(oStation.Name)

                        Call grdStations.RefreshDataSource()
                        Call pPerformCalculate(False)
                        Call pPerformPaint()
                        Call pInvalidateCurrentView()
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
                oPoint = New Point(oPoint.X / sPlanZoom, oPoint.Y / sPlanZoom)
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
            oPoint = New Point(oPoint.X / sProfileZoom, oPoint.Y / sProfileZoom)
            Dim oToTPH As cResurvey.cTrigpointPlaceholder = pHitTestProfilePlaceholder(oPoint)
            If Not oToTPH Is Nothing Then
                Dim oFromTPH As cResurvey.cTrigpointPlaceholder = e.Data.GetData(GetType(cResurvey.cTrigpointPlaceholder))
                If oFromTPH.Projection = 1 Then
                    If oFromTPH.Name > oToTPH.Name Then
                        'sort from and to
                        Dim oTempTPH As cResurvey.cTrigpointPlaceholder = oToTPH
                        oToTPH = oFromTPH
                        oFromTPH = oTempTPH
                    End If
                    Dim oStation As cResurvey.cStation = oStations(oFromTPH.Name)
                    'If Not oStation.ProfileConnectedTo.Contains(oToTPH.Name) AndAlso Not oStations(oToTPH.Name).ProfileConnectedTo.Contains(oStation.Name) Then
                    If Not oStation.ProfileConnectedTo.Contains(oToTPH.Name) Then
                        Call oStation.ProfileConnectedTo.Add(oToTPH.Name)
                        Call oStations(oToTPH.Name).ProfileConnectedTo.Remove(oStation.Name)

                        Call grdStations.RefreshDataSource()
                        Call pPerformCalculate(False)
                        Call pPerformPaint()
                        Call pInvalidateCurrentView()
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
                oPoint = New Point(oPoint.X / sProfileZoom, oPoint.Y / sProfileZoom)
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

    Private Sub btnZoomIn_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnZoomIn.ItemClick
        If pGetCurrentProjection() = 0 Then
            Dim sNewPlanZoom As Single = sPlanZoom * 1.1
            If sNewPlanZoom > 0.1 AndAlso sNewPlanZoom < 4 Then sPlanZoom = sNewPlanZoom
        Else
            Dim sNewProfileZoom As Single = sProfileZoom * 1.1
            If sNewProfileZoom > 0.1 AndAlso sNewProfileZoom < 4 Then sProfileZoom = sNewProfileZoom
        End If
        Call pZoomApply()
    End Sub

    Private Sub btnZoomOut_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnZoomOut.ItemClick
        If pGetCurrentProjection() = 0 Then
            Dim sNewPlanZoom As Single = sPlanZoom / 1.1
            If sNewPlanZoom > 0.1 AndAlso sNewPlanZoom < 4 Then sPlanZoom = sNewPlanZoom
        Else
            Dim sNewProfileZoom As Single = sProfileZoom / 1.1
            If sNewProfileZoom > 0.1 AndAlso sNewProfileZoom < 4 Then sProfileZoom = sNewProfileZoom
        End If
        Call pZoomApply()
    End Sub

    Private Sub pUpdateZoomFactor()
        If pGetCurrentProjection() = 0 Then
            pnlZoom.Caption = Strings.Format(sPlanZoom * 100, "0.00") & "%"
        ElseIf pGetCurrentProjection() = 1 Then
            pnlZoom.Caption = Strings.Format(sProfileZoom * 100, "0.00") & "%"
        Else
            pnlZoom.Caption = ""
        End If
    End Sub

    Private Sub pZoom(Center As Point, Delta As Integer)
        Delta = Delta / 100
        If pGetCurrentProjection() = 0 Then
            For i As Integer = 0 To Math.Abs(Delta)
                Dim sNewPlanZoom As Single
                If Delta > 0 Then
                    sNewPlanZoom = sPlanZoom * 1.1
                Else
                    sNewPlanZoom = sPlanZoom / 1.1
                End If
                If sNewPlanZoom > 0.1 AndAlso sNewPlanZoom < 4 Then sPlanZoom = sNewPlanZoom
            Next
            Call pZoomApply()
        Else
            For i As Integer = 0 To Math.Abs(Delta)
                Dim sNewProfileZoom As Single
                If Delta > 0 Then
                    sNewProfileZoom = sProfileZoom * 1.1
                Else
                    sNewProfileZoom = sProfileZoom / 1.1
                End If
                If sNewProfileZoom > 0.1 AndAlso sNewProfileZoom < 4 Then sProfileZoom = sNewProfileZoom
            Next
            Call pZoomApply()
        End If
    End Sub

    Private Sub pZoomApply()
        If pGetCurrentProjection() = 0 Then
            If picPlan.Visible Then
                picPlan.Size = New Size(picPlan.Image.Width * sPlanZoom, picPlan.Image.Height * sPlanZoom)
                Call tbPlan.Hide()
            End If
        Else
            If picProfile.Visible Then
                picProfile.Size = New Size(picProfile.Image.Width * sProfileZoom, picProfile.Image.Height * sProfileZoom)
                Call tbProfile.Hide()
            End If
        End If
        Call pUpdateZoomFactor()
        Call pInvalidateCurrentView()
    End Sub

    Private Sub picProfile_MouseWheel(sender As Object, e As MouseEventArgs) Handles picProfile.MouseWheel
        If My.Computer.Keyboard.CtrlKeyDown Then
            Call pZoom(e.Location, e.Delta)
            DirectCast(e, HandledMouseEventArgs).Handled = True
        Else
            Dim oPoint As Point = New Point(e.Location.X / sProfileZoom, e.Location.Y / sProfileZoom)
            If pHitTestProfileRuler(oPoint) Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    If My.Computer.Keyboard.AltKeyDown Then
                        sProfileRulerAngle += e.Delta / 12000.0F
                    Else
                        sProfileRulerAngle += e.Delta / 1200.0F
                    End If
                Else
                    sProfileRulerAngle += e.Delta / 120.0F
                End If
                Call pInvalidateCurrentView()
                DirectCast(e, HandledMouseEventArgs).Handled = True
            End If
        End If
    End Sub

    Private Sub picPlan_MouseWheel(sender As Object, e As MouseEventArgs) Handles picPlan.MouseWheel
        If My.Computer.Keyboard.CtrlKeyDown Then
            Call pZoom(e.Location, e.Delta)
            DirectCast(e, HandledMouseEventArgs).Handled = True
        Else
            Dim oPoint As Point = New Point(e.Location.X / sPlanZoom, e.Location.Y / sPlanZoom)
            If pHitTestPlanRuler(oPoint) Then
                If My.Computer.Keyboard.ShiftKeyDown Then
                    If My.Computer.Keyboard.AltKeyDown Then
                        sPlanRulerAngle += e.Delta / 12000.0F
                    Else
                        sPlanRulerAngle += e.Delta / 1200.0F
                    End If
                Else
                    sPlanRulerAngle += e.Delta / 120.0F
                End If
                Call pInvalidateCurrentView()
                DirectCast(e, HandledMouseEventArgs).Handled = True
            End If
        End If
    End Sub

    Private Sub btnZoom50_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnZoom50.ItemClick
        If pGetCurrentProjection() = 0 Then
            sPlanZoom = 0.5F
        Else
            sProfileZoom = 0.5F
        End If
        Call pZoomApply()
    End Sub

    Private Sub btnZoom100_Click(sender As Object, e As EventArgs)
        If pGetCurrentProjection() = 0 Then
            sPlanZoom = 1.0F
        Else
            sProfileZoom = 1.0F
        End If
        Call pZoomApply()
    End Sub

    'Private Sub frmResurveyMain_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
    '    Call pBindScrollbars(True)
    'End Sub

    Private Sub btnShowRulers_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShowRulers.ItemClick
        'btnShowRulers.Checked = Not btnShowRulers.Checked
        Call pInvalidateCurrentView()
    End Sub

    Private Sub btnZoom100_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnZoom100.ItemClick
        If pGetCurrentProjection() = 0 Then
            sPlanZoom = 1.0F
        Else
            sProfileZoom = 1.0F
        End If
        Call pZoomApply()
    End Sub

    Private Sub btnZoomToFit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnZoomToFit.ItemClick
        If pGetCurrentProjection() = 0 Then
            Dim oRect As Rectangle = pnlPlan.ClientRectangle
            Dim sScale As Single = modPaint.ScaleToFit(oRect, picPlan.Image.GetBounds(Drawing.GraphicsUnit.Pixel))
            sPlanZoom = sScale
        Else
            Dim oRect As Rectangle = pnlProfile.ClientRectangle
            Dim sScale As Single = modPaint.ScaleToFit(oRect, picPlan.Image.GetBounds(Drawing.GraphicsUnit.Pixel))
            sProfileZoom = sScale
        End If
        Call pZoomApply()
    End Sub

    Private Sub btnZoom200_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnZoom200.ItemClick
        If pGetCurrentProjection() = 0 Then
            sPlanZoom = 2.0F
        Else
            sProfileZoom = 2.0F
        End If
        Call pZoomApply()
    End Sub

    Private Sub btnZoom25_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnZoom25.ItemClick
        If pGetCurrentProjection() = 0 Then
            sPlanZoom = 0.25F
        Else
            sProfileZoom = 0.25F
        End If
        Call pZoomApply()
    End Sub

    Private Sub btnZoomFit_ButtonClick(sender As Object, e As EventArgs)
        Call btnZoomToFit.PerformClick()
    End Sub

    Private Sub mnuPreviewRulerCenterHere_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnShowRulers_checkedchanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShowRulers.CheckedChanged
        btnShowRuler.Enabled = btnShowRulers.Checked
    End Sub

    Private Sub btnShowRuler_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShowRuler.ItemClick
        'btnShowRuler.Checked = Not btnShowRuler.Checked
        Call pInvalidateCurrentView()
    End Sub

    Private Sub btnAdd2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAdd2.ItemClick
        Call pAddStation()
    End Sub

    Private Sub gridviewStations_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles gridviewStations.CustomUnboundColumnData
        If e.IsGetData Then
            Dim oStation As cStation = e.Row
            Select Case e.Column.Name
                Case "colPlaceholdersIcon"
                    e.Value = ""
                'Case "planvisible"
                '    e.Value = oStation.PlanVisible
                'Case "profilevisible"
                '    e.Value = oStation.ProfileVisible
                Case "colPlaceholdersPlanPoint"
                    If oStation.PlanPoint.IsEmpty Then
                        e.Value = ""
                    Else
                        e.Value = oStation.PlanPoint.X & ";" & oStation.PlanPoint.Y
                    End If
                Case "colPlaceholdersProfilePoint"
                    If oStation.ProfilePoint.IsEmpty Then
                        e.Value = ""
                    Else
                        e.Value = oStation.ProfilePoint.X & ";" & oStation.ProfilePoint.Y
                    End If
                    'Case "planconnectedto"
                    '    e.Value = oStation.PlanConnectedTo
                    'Case "profileconnectedto"
                    '    e.Value = oStation.ProfileConnectedTo
                    'Case "type"
                    '    e.Value = oStation.Type
            End Select
        End If
    End Sub

    Private Sub gridviewStations_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridviewStations.RowStyle
        Dim oStation As cStation = gridviewStations.GetRow(e.RowHandle)
        If Not oStation Is Nothing Then
            If oStation.Type = "O" Then
                e.Appearance.BackColor = Color.FromArgb(50, oOriginColor)
            ElseIf oStation.Type = "DSB" OrElse oStation.Type = "DSE" Then
                e.Appearance.BackColor = Color.FromArgb(50, oDropScaleColor)
            ElseIf oStation.Type = "SB" OrElse oStation.Type = "SE" Then
                e.Appearance.BackColor = Color.FromArgb(50, oScaleColor)
            ElseIf oStation.Type = "NB" OrElse oStation.Type = "NE" Then
                e.Appearance.BackColor = Color.FromArgb(50, oNorthColor)
            End If
        End If
    End Sub

    Private Sub gridviewStations_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles gridviewStations.RowCellStyle
        If e.Column Is colPlaceholdersIcon Then
            Dim oStation As cStation = gridviewStations.GetRow(e.RowHandle)
            If Not oStation Is Nothing Then
                If oStation.Type = "O" Then
                    e.Appearance.BackColor = oOriginColor
                ElseIf oStation.Type = "DSB" OrElse oStation.Type = "DSE" Then
                    e.Appearance.BackColor = oDropScaleColor
                ElseIf oStation.Type = "SB" OrElse oStation.Type = "SE" Then
                    e.Appearance.BackColor = oScaleColor
                ElseIf oStation.Type = "NB" OrElse oStation.Type = "NE" Then
                    e.Appearance.BackColor = oNorthColor
                End If
            End If
        End If
    End Sub

    Private Function pGetSelectedStations() As List(Of cStation)
        Dim oResults As List(Of cStation) = New List(Of cStation)
        For Each i As Integer In gridviewStations.GetSelectedRows
            Call oResults.Add(gridviewStations.GetRow(i))
        Next
        Return oResults
    End Function

    Private Sub btnSetOrigin2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSetOrigin2.ItemClick
        Call pStationSetOrigin()
    End Sub

    Private Sub btnProperties2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnProperties2.ItemClick
        Call pStationProperties()
    End Sub

    Private Sub gridviewStations_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles gridviewStations.CellValueChanged
        Call pInvalidateCurrentView()
    End Sub

    Private Sub btnRemove2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRemove2.ItemClick
        Call pPlaceHolderDelete()
    End Sub

    Private Sub btnRemoveAll2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRemoveAll2.ItemClick
        If MsgBox(GetLocalizedString("resurvey.warning1"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, GetLocalizedString("resurvey.warningtitle")) = MsgBoxResult.Yes Then
            If pGetCurrentProjection() = 0 Then
                Call pRemoveTrigPoints(0)
            Else
                Call pRemoveTrigPoints(1)
            End If
        End If
    End Sub

    Private Sub btnDelete2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete2.ItemClick
        Call pStationDelete()
    End Sub

    Private Sub btnDeleteAll2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDeleteAll2.ItemClick
        If MsgBox(GetLocalizedString("resurvey.warning6"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("resurvey.warningtitle")) = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Call oPlanTrigpointsPlaceholders.Clear()
            Call oProfileTrigpointsPlaceholders.Clear()

            Call oStations.Clear()
            Call grdStations.RefreshDataSource()

            Call pPerformPaint()
            Call pInvalidateCurrentView()

            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub DockManager_ActivePanelChanged(sender As Object, e As ActivePanelChangedEventArgs) Handles DockManager.ActivePanelChanged
        Call pChangeCurrentProjection()
    End Sub

    Private Sub DocumentManager1_DocumentActivate(sender As Object, e As DocumentEventArgs) Handles DocumentManager.DocumentActivate
        Call pChangeCurrentProjection()
    End Sub

    Private Sub pnlplan_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlPlan.MouseUp
        If (e.Button And MouseButtons.Right) = MouseButtons.Right Then
            Call dockPlan.Focus()
            Call mnuPanel.ShowPopup(pnlPlan.PointToScreen(e.Location))
        End If
    End Sub

    Private Sub pnlProfile_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlProfile.MouseUp
        If (e.Button And MouseButtons.Right) = MouseButtons.Right Then
            Call dockProfile.Focus()
            Call mnuPanel.ShowPopup(picProfile.PointToScreen(e.Location))
        End If
    End Sub

    Private Sub DocumentManager1_ViewChanged(sender As Object, args As ViewEventArgs) Handles DocumentManager.ViewChanged
        Call pChangeCurrentProjection()
    End Sub

    Private Sub DockManager_TabsPositionChanged(sender As Object, e As TabsPositionChangedEventArgs) Handles DockManager.TabsPositionChanged
        Call pChangeCurrentProjection()
    End Sub

    Private Sub docView_DocumentActivated(sender As Object, e As DocumentEventArgs) Handles docView.DocumentActivated
        Call pChangeCurrentProjection()
    End Sub

    Private Sub docView_EndDocking(sender As Object, e As DocumentEventArgs) Handles docView.EndDocking
        Call e.Document.Control.Focus()
    End Sub

    Private Sub gridviewStations_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles gridviewStations.PopupMenuShowing
        If (e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell) Then
            e.Allow = False
            Call mnuStations.ShowPopup(grdStations.PointToScreen(e.Point))
        End If
    End Sub

    Private Sub gridviewStations_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles gridviewStations.FocusedRowChanged
        If iEventDisabled = 0 Then
            If Not pGetFocusedStation() Is Nothing Then
                Dim oStation As cStation = pGetFocusedStation()
                Dim sTrigPoint As String = oStation.Name

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

                Call pSelectLine(Nothing)
                Call pSelectPlaceholder(oNewPlaceHolder)
            Else
                Call pSelectPlaceholder(Nothing)
            End If
            'Call pDelayedPerformPaint()
            Call pInvalidateCurrentView()
        End If
    End Sub

    Private Sub btnPlanHideAll_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPlanHideAll.ItemClick
        For Each oStation As cStation In oStations
            oStation.PlanVisible = False
        Next
        Call grdStations.RefreshDataSource()
        Call pInvalidateCurrentView()
    End Sub

    Private Sub btnPlanShowAll_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPlanShowAll.ItemClick
        For Each oStation As cStation In oStations
            oStation.PlanVisible = True
        Next
        Call grdStations.RefreshDataSource()
        Call pInvalidateCurrentView()
    End Sub

    Private Sub btnProfileShowAll_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnProfileShowAll.ItemClick
        For Each oStation As cStation In oStations
            oStation.ProfileVisible = True
        Next
        Call grdStations.RefreshDataSource()
        Call pInvalidateCurrentView()
    End Sub

    Private Sub btnProfileHideAll_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnProfileHideAll.ItemClick
        For Each oStation As cStation In oStations
            oStation.ProfileVisible = False
        Next
        Call grdStations.RefreshDataSource()
        Call pInvalidateCurrentView()
    End Sub

    Private Sub picPlan_MouseLeave(sender As Object, e As EventArgs) Handles picPlan.MouseLeave
        If bPlanisDraggingImage Then
            Call pPlanEndDragging()
        End If
    End Sub

    Private Sub picProfile_MouseLeave(sender As Object, e As EventArgs) Handles picProfile.MouseLeave
        If bProfileisDraggingImage Then
            Call pProfileEndDragging()
        End If
    End Sub

    Private iEventDisabled As Integer

    Private Sub btnVisible_EditValueChanged(sender As Object, e As EventArgs) Handles btnVisible.EditValueChanged
        If iEventDisabled = 0 Then
            Dim bChecked As Boolean? = btnVisible.EditValue
            If bChecked.HasValue Then
                Select Case pGetCurrentProjection()
                    Case 0
                        Call pGetSelectedStations.ForEach(Sub(oItem)
                                                              oItem.PlanVisible = bChecked.Value
                                                          End Sub)
                    Case 1
                        Call pGetSelectedStations.ForEach(Sub(oItem)
                                                              oItem.ProfileVisible = bChecked.Value
                                                          End Sub)
                End Select
                Call grdStations.RefreshDataSource()
                Call pDelayedPerformPaint()
            End If
        End If
    End Sub

    Private Sub btnImageInvertColor_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImageInvertColor.ItemClick
        Select Case pGetCurrentProjection()
            Case 0
                picPlan.Image = modPaint.InvertColors(picPlan.Image)
            Case 1
                picProfile.Image = modPaint.InvertColors(picProfile.Image)
        End Select
    End Sub

    Private Sub btnImageToGrayScale_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImageToGrayScale.ItemClick
        Select Case pGetCurrentProjection()
            Case 0
                picPlan.Image = modPaint.GrayScaleImage(picPlan.Image)
            Case 1
                picProfile.Image = modPaint.GrayScaleImage(picProfile.Image)
        End Select
    End Sub

    Private Sub btnImageBWThreshold_EditValueChanged(sender As Object, e As EventArgs) Handles btnImageBWThreshold.EditValueChanged

    End Sub

    Private Sub btnShowRuler_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShowRuler.CheckedChanged
        Dim bRulerEnabled As Boolean = btnShowRuler.Enabled AndAlso btnShowRuler.Checked
        btnRulerAlignTo.Enabled = bRulerEnabled AndAlso btnDelete2.Enabled
        btnRulerCenterHere.Enabled = bRulerEnabled AndAlso btnDeleteLink.Enabled
    End Sub

    Private Sub btnRulerCenterHere_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRulerCenterHere.ItemClick
        Select Case pGetCurrentProjection()
            Case 0
                If Not oPlanLastPlaceHolder Is Nothing Then
                    If pGetCurrentProjection() = 0 Then
                        oPlanRulerPosition = oPlanLastPlaceHolder.Point
                    Else
                        oProfileRulerPosition = oPlanLastPlaceHolder.Point
                    End If
                    Call pInvalidateCurrentView()
                End If
            Case 1
                If Not oProfileLastPlaceHolder Is Nothing Then
                    If pGetCurrentProjection() = 0 Then
                        oPlanRulerPosition = oProfileLastPlaceHolder.Point
                    Else
                        oProfileRulerPosition = oProfileLastPlaceHolder.Point
                    End If
                    Call pInvalidateCurrentView()
                End If
        End Select
    End Sub

    Private Sub btnRulerAlignTo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRulerAlignTo.ItemClick
        Select Case pGetCurrentProjection()
            Case 0
                If Not oPlanLastLine Is Nothing Then
                    If pGetCurrentProjection() = 0 Then
                        oPlanRulerPosition = oPlanLastLine(0).Point
                        sPlanRulerAngle = Math.Round(modPaint.GetBearing(oPlanLastLine(0).Point, oPlanLastLine(1).Point), 2) + 270.0F
                    Else
                        oProfileRulerPosition = oPlanLastLine(0).Point
                        sProfileRulerAngle = Math.Round(modPaint.GetBearing(oPlanLastLine(0).Point, oPlanLastLine(1).Point), 2) + 270.0F
                    End If
                    Call pInvalidateCurrentView()
                End If
            Case 1
                If Not oProfileLastLine Is Nothing Then
                    If pGetCurrentProjection() = 0 Then
                        oProfileRulerPosition = oProfileLastLine(0).Point
                        sProfileRulerAngle = Math.Round(modPaint.GetBearing(oProfileLastLine(0).Point, oProfileLastLine(1).Point), 2) + 270.0F
                    Else
                        oProfileRulerPosition = oProfileLastLine(0).Point
                        sProfileRulerAngle = Math.Round(modPaint.GetBearing(oProfileLastLine(0).Point, oProfileLastLine(1).Point), 2) + 270.0F
                    End If
                    Call pInvalidateCurrentView()
                End If
        End Select
    End Sub

    Private Sub btnDeleteLink_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDeleteLink.ItemClick
        Select Case pGetCurrentProjection()
            Case 0
                If Not oPlanLastLine Is Nothing Then
                    Call oStations(oPlanLastLine(0).Name).PlanConnectedTo.Remove(oPlanLastLine(1).Name)
                    Call oStations(oPlanLastLine(1).Name).PlanConnectedTo.Remove(oPlanLastLine(0).Name)
                    'Call oPlanLastLine(0).Connections.Remove(oPlanLastLine(1))
                    Call oPlanLastLine(0).Cache.PlanShots.Remove(oPlanLastLine(1).Name)
                    'Call oPlanLastLine(1).Connections.Remove(oPlanLastLine(0))
                    Call oPlanLastLine(1).Cache.PlanShots.Remove(oPlanLastLine(0).Name)
                    Call pSelectLine(Nothing)
                End If
            Case 1
                If Not oProfileLastLine Is Nothing Then
                    Call oStations(oProfileLastLine(0).Name).ProfileConnectedTo.Remove(oProfileLastLine(1).Name)
                    Call oStations(oProfileLastLine(1).Name).ProfileConnectedTo.Remove(oProfileLastLine(0).Name)
                    'Call oProfileLastLine(0).Connections.Remove(oProfileLastLine(1))
                    Call oProfileLastLine(0).Cache.ProfileShots.Remove(oProfileLastLine(1).Name)
                    'Call oProfileLastLine(1).Connections.Remove(oProfileLastLine(0))
                    Call oProfileLastLine(1).Cache.ProfileShots.Remove(oProfileLastLine(0).Name)
                    Call pSelectLine(Nothing)
                End If
        End Select
        Call pDelayedPerformPaint()
    End Sub

    Private Sub gridviewStations_DoubleClick(sender As Object, e As EventArgs) Handles gridviewStations.DoubleClick
        Dim oStation As cStation = gridviewStations.GetFocusedRow
        If Not oStation Is Nothing Then
            Call pStationProperties()
        End If
    End Sub

    Private Sub WorkspaceManager_AfterApplyWorkspace(sender As Object, e As EventArgs) Handles WorkspaceManager.AfterApplyWorkspace
        Call pSetCalculateMode()
    End Sub

    Private Sub frmResurveyMain_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Visible Then
            Call pSettingsLoad()
            Call pNew()
        End If
    End Sub

    Private Const sMagFactor As Single = 4

    Private Sub tmrMagnifier_Tick(sender As Object, e As EventArgs) Handles tmrMagnifier.Tick
        If picMagnifier.Visible Then
            Try
                If Not picMagnifier.Image Is Nothing Then
                    Dim oOldBackground As Bitmap = picMagnifier.Image
                    picMagnifier.Image = Nothing
                    Call oOldBackground.Dispose()
                End If
                Dim iWidth As Integer = picMagnifier.Width / sMagFactor
                Dim iHeight As Integer = picMagnifier.Height / sMagFactor
                Dim oNewBackground As Bitmap = New Bitmap(iWidth, iHeight)
                Using oGraphics As Graphics = Graphics.FromImage(oNewBackground)
                    Dim oLocation As Point = Cursor.Position
                    Dim oScreenBound As Rectangle = New Rectangle(oLocation.X - iWidth / 2, oLocation.Y + -iHeight / 2, iWidth, iHeight)
                    Call oGraphics.CopyFromScreen(oScreenBound.Location, New Point(0, 0), New Drawing.Size(iWidth, iHeight))
                    picMagnifier.Image = oNewBackground
                    'picMagnifier.SizeMode = PictureBoxSizeMode.StretchImage
                End Using
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnMagnifier_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMagnifier.CheckedChanged
        If btnMagnifier.Checked Then
            dockMagnifier.Visibility = DockVisibility.Visible
        Else
            dockMagnifier.Visibility = DockVisibility.Hidden
        End If
    End Sub

    Private Sub dockMagnifier_VisibilityChanged(sender As Object, e As VisibilityChangedEventArgs) Handles dockMagnifier.VisibilityChanged
        If e.Visibility = DockVisibility.Visible Then
            Call tmrMagnifier.Start()
        Else
            Call tmrMagnifier.Stop()
        End If
    End Sub

    Private Sub picMagnifier_Paint(sender As Object, e As PaintEventArgs) Handles picMagnifier.Paint
        Call e.Graphics.DrawLine(SystemPens.ControlDark, New Point(picMagnifier.Width / 2, 0), New Point(picMagnifier.Width / 2, picMagnifier.Height))
        Call e.Graphics.DrawLine(SystemPens.ControlDark, New Point(0, picMagnifier.Height / 2), New Point(picMagnifier.Width, picMagnifier.Height / 2))
    End Sub

    Private Sub DockManager_Sizing(sender As Object, e As SizingEventArgs) Handles DockManager.Sizing
        If e.Panel Is dockMagnifier Then
            Dim oMaxSize As Size = New Size(400, 400)
            If e.NewSize.Width > 400 OrElse e.NewSize.Height > 400 Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub gridviewShots_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles gridviewShots.CellValueChanged
        Call pDelayedPerformPaint()
    End Sub

    Private Sub btnRightEdit_EditValueChanged(sender As Object, e As EventArgs) Handles btnRightEdit.EditValueChanged
        Call pRightEditApply()
    End Sub

    Private Sub btnLeftEdit_EditValueChanged(sender As Object, e As EventArgs) Handles btnLeftEdit.EditValueChanged
        Call pLeftEditApply()
    End Sub

    Private Sub pLeftEditApply()
        Dim oShot As cShot = btnLeftEdit.Tag
        Call Debug.Print("LEFT:" & btnLeftEdit.EditValue)
        oShot.EditUserLeft = btnLeftEdit.EditValue
        Call gridviewShots.RefreshRow(gridviewShots.FindRow(oShot))
        Call pPerformPaint()
    End Sub

    Private Sub pDownEditApply()
        Dim oShot As cShot = btnDownEdit.Tag
        oShot.EditUserDown = btnDownEdit.EditValue
        Call gridviewShots.RefreshRow(gridviewShots.FindRow(oShot))
        Call pPerformPaint()
    End Sub

    Private Sub pUpEditApply()
        Dim oShot As cShot = btnUpEdit.Tag
        oShot.EditUserUp = btnUpEdit.EditValue
        Call gridviewShots.RefreshRow(gridviewShots.FindRow(oShot))
        Call pPerformPaint()
    End Sub

    Private Sub pRightEditApply()
        Dim oShot As cShot = btnRightEdit.Tag
        Call Debug.Print("RIGHT:" & btnRightEdit.EditValue)
        oShot.EditUserRight = btnRightEdit.EditValue
        Call gridviewShots.RefreshRow(gridviewShots.FindRow(oShot))
        Call pPerformPaint()
    End Sub

    Private Sub btnUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles btnUpEdit.EditValueChanged
        Call pUpEditApply()
    End Sub

    Private Sub btnDownEdit_EditValueChanged(sender As Object, e As EventArgs) Handles btnDownEdit.EditValueChanged
        Call pDownEditApply()
    End Sub

    'Private Sub txtLeftEdit_Spin(sender As Object, e As SpinEventArgs) Handles txtLeftEdit.Spin
    '    Call pLeftEditApply()
    'End Sub

    Private Sub txtDownEdit_EditValueChanging(sender As Object, e As EventArgs) Handles txtDownEdit.EditValueChanged
        DirectCast(btnDownEdit.Links(0), DevExpress.XtraBars.BarEditItemLink).PostEditor()
    End Sub

    Private Sub txtUpEdit_EditValueChanging(sender As Object, e As EventArgs) Handles txtUpEdit.EditValueChanged
        DirectCast(btnUpEdit.Links(0), DevExpress.XtraBars.BarEditItemLink).PostEditor()
    End Sub

    Private Sub txtLeftEdit_EditValueChanging(sender As Object, e As EventArgs) Handles txtLeftEdit.EditValueChanged
        DirectCast(btnLeftEdit.Links(0), DevExpress.XtraBars.BarEditItemLink).PostEditor()
    End Sub

    Private Sub txtRightEdit_EditValueChanging(sender As Object, e As EventArgs) Handles txtRightEdit.EditValueChanged
        DirectCast(btnRightEdit.Links(0), DevExpress.XtraBars.BarEditItemLink).PostEditor()
    End Sub

    Private Sub btnSaveAs_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSaveAs.ItemClick
        Call pSave("")
        'Using oSFD As SaveFileDialog = New SaveFileDialog
        '    With oSFD
        '        .OverwritePrompt = True
        '        .Filter = GetLocalizedString("resurvey.filetypeCRSX") & " (*.CRSX)|*.CRSX"
        '        If .ShowDialog = Windows.Forms.DialogResult.OK Then

        '        End If
        '    End With
        'End Using
    End Sub

    Private Sub btnSaveImage_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSaveImage.ItemClick
        Select Case pGetCurrentProjection()
            Case 0
                Call modPaint.ShowImageExportDialog(Me, picPlan.Image)
            Case 1
                Call modPaint.ShowImageExportDialog(Me, picProfile.Image)
        End Select
    End Sub

    Private Sub WorkspaceManager_PropertyDeserializing(sender As Object, ea As DevExpress.Utils.PropertyCancelEventArgs) Handles WorkspaceManager.PropertyDeserializing
        If ea.PropertyName.ToLower = "text" Then
            ea.Cancel = True
        End If
    End Sub

    Private Sub btnClearImage_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClearImage.ItemClick
        If MsgBox(GetLocalizedString("resurvey.warning10"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, GetLocalizedString("resurvey.warningtitle")) = MsgBoxResult.Yes Then
            If pGetCurrentProjection() = 0 Then
                sPlanImage = ""
                picPlan.Image = Nothing
                picPlan.Visible = False
            Else
                sProfileImage = ""
                picProfile.Image = Nothing
                picProfile.Visible = False
            End If
        End If
    End Sub

End Class
