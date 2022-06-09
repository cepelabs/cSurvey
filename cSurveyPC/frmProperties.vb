Imports cSurveyPC.cSurvey
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Scripting
Imports System.ComponentModel
Imports cSurveyPC.cSurvey.Helper.Editor
Imports cSurveyPC.cSurvey.UIHelpers
Imports DevExpress.XtraBars.Navigation
Imports System.Text
Imports System.Xml
Imports cSurveyPC.cSurvey.Surface
Imports cSurveyPC.cTrigpointDropDown

Friend Class frmProperties
    Private oSurvey As cSurvey.cSurvey

    Friend Event OnSegmentSelect(Sender As frmProperties, Segment As cSegment)
    Friend Event OnApply(ByVal Sender As frmProperties)

    Private Sub pUTMLoad()
        For i As Integer = 1 To 60
            Call cboCoordinateZone.Items.Add(i)
        Next
        For i As Integer = Asc("A") To Asc("Z")
            Call cboCoordinateBand.Items.Add(Chr(i))
        Next
    End Sub

    Private iFunctionLanguage As LanguageEnum

    Public Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Optional SelectedTabIndex As Integer? = Nothing, Optional FunctionLanguage As LanguageEnum = LanguageEnum.VisualBasic)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Cursor = Cursors.WaitCursor

        iFunctionLanguage = FunctionLanguage

        Call tabMain.BeginUpdate()
        tabMain.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False
        For Each oTabControl As DevExpress.XtraTab.XtraTabPage In tabMain.TabPages
            Dim oPanel As DevExpress.XtraEditors.PanelControl = New DevExpress.XtraEditors.PanelControl
            Me.Controls.Add(oPanel)
            oPanel.Name = "_" & oTabControl.Name
            oPanel.Size = oTabControl.ClientSize
            Dim oControls As List(Of Control) = New List(Of Control)
            For Each oControl As Control In oTabControl.Controls
                Call oControls.Add(oControl)
            Next
            For Each oControl As Control In oControls
                Try
                    oPanel.Controls.Add(oControl)
                Catch ex As Exception
                End Try
            Next
            oPanel.Tag = tabMain.TabPages.IndexOf(oTabControl)
            oPanel.Dock = DockStyle.Fill
            oPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            oPanel.Visible = False
        Next
        tabMain.Visible = False
        Call tabMain.EndUpdate()

        'pnlDepth.Location = pnlInclination.Location
        pnlSessionDepth.Location = pnlSessionInclination.Location

        oSurvey = Survey
        With oSurvey.Properties
            Call pGradesLoad()
            Call pUTMLoad()

            btnCaveInfoSelectSegment.Enabled = Owner Is frmMain2

            txtID.Text = oSurvey.ID

            txtName.Text = .Name
            txtDescrizione.Text = .Description
            txtTeam.Text = .Team
            txtClub.Text = .Club
            txtCatasto.Text = .ID
            txtDesigner.Text = .Designer

            txtCreatorID.Text = .CreatorID
            txtCreatorVersion.Text = .CreatorVersion
            If .CreationDate.HasValue Then
                txtCreationDate.Text = .CreationDate.Value
            End If

            txtNote.Text = .Note

            'cboDefGrade.Text = .DefGrade
            'cboDefAccuracy.Text = .DefAccuracy

            Call pOriginsLoad()

            cboCalculateType.SelectedIndex = .CalculateType
            cboRingCorrectionMode.SelectedIndex = .RingCorrectionMode

            cboNordCorrection.SelectedIndex = .NordCorrectionMode

            txtInfoBoxStructure.Text = .InfoBoxStructure
            txtTrigPointStructure.Text = .TrigPointStructure
            txtSpecialTrigPointStructure.Text = .SpecialTrigPointStructure

            'cboDataFormat.SelectedIndex = .DataFormat
            'cboDistanceType.SelectedIndex = .DistanceType
            'cboBearingType.SelectedIndex = .BearingType
            'chkBearingDirection.Checked = .BearingDirection = cSegment.MeasureDirectionEnum.Inverted
            'cboInclinationType.SelectedIndex = .InclinationType
            'chkInclinationDirection.Checked = .InclinationDirection = cSegment.MeasureDirectionEnum.Inverted
            'cboDepthType.SelectedIndex = .DepthType

            'If .Grade = "" Then
            '    cboGrade.SelectedIndex = 0
            'Else
            '    cboGrade.SelectedIndex = oSurvey.Grades.IndexOf(oSurvey.Grades(.Grade)) + 1
            'End If

            'cboNordType.SelectedIndex = .NordType
            'chkDecMag.Checked = .DeclinationEnabled
            'txtDecMag.Text = .Declination

            chkGlobalDecMag.Checked = .GlobalDeclinationEnabled
            txtGlobalDecMag.Text = .GlobalDeclination

            'cboSideMeasuresType.SelectedIndex = .SideMeasuresType
            'cboSideMeasuresReferTo.SelectedIndex = .SideMeasuresReferTo

            chkGlobalVthreshold.Checked = .GlobalVThresholdEnabled
            txtGlobalVthreshold.Value = .GlobalVThreshold

            'chkVthreshold.Checked = .VThresholdEnabled
            'txtVthreshold.Value = .VThreshold

            chkGPSEnabled.Checked = .GPS.Enabled

            optGPSRefPointOnOrigin.EditValue = .GPS.RefPointOnOrigin
            optGPSCustomRefPoint.EditValue = Not optGPSRefPointOnOrigin.EditValue

            cboGPSCustomRefPoint.Text = .GPS.CustomRefPoint
            cboCoordinateGeo.Text = .GPS.System
            Call cboCoordinateGeo_SelectedIndexChanged(Nothing, Nothing)
            If .GPS.Format <> "" Then cboCoordinateFormat.Text = .GPS.Format
            If .GPS.Band <> "" Then cboCoordinateBand.Text = .GPS.Band
            If .GPS.Zone <> "" Then cboCoordinateZone.Text = .GPS.Zone
            chkGPSSendToTherion.Checked = .GPS.SendToTherion
            chkGPSAllowManualDeclinations.Checked = .GPS.AllowManualDeclinations

            cboCalculateVersion.SelectedIndex = .CalculateVersion
            chkCalculateMode.Checked = .CalculateMode = cSurvey.cSurvey.CalculateModeEnum.Automatic
            cboDesignBindingMode.SelectedIndex = .DesignBindingMode
            cboDesignWarpingMode.SelectedIndex = .DesignWarpingMode
            optWarpingActive.Checked = .DesignWarpingState = cSurvey.cSurvey.DesignWarpingStateEnum.Active
            optWarpingPaused.Checked = .DesignWarpingState = cSurvey.cSurvey.DesignWarpingStateEnum.Paused

            chkPlanWarpingEnabled.Checked = Not .PlanWarpingDisabled
            chkProfileWarpingEnabled.Checked = Not .ProfileWarpingDisabled
            chkShowWarpingDetails.Checked = .ShowWarpingDetails

            cboInversionMode.SelectedIndex = .InversionMode

            cboClipBorder.SelectedIndex = .DesignProperties.GetValue("clipborder", cEditDesignEnvironment.GetSetting("design.clipborder", cSurvey.Design.cClippingRegions.ClipBorderEnum.ClipBorder))
            cboClipAdvancedClipart.SelectedIndex = .DesignProperties.GetValue("clippingforadvancedbrush", cEditDesignEnvironment.GetSetting("clippingforadvancedbrush", cSurvey.Drawings.cIRegion.RegionTypeEnum.GDI))

            cboLineType.SelectedIndex = .DesignProperties.GetValue("LineType", cEditDesignEnvironment.GetSetting("design.linetype", cSurvey.Design.Items.cIItemLine.LineTypeEnum.Splines))

            cboSplayMode.SelectedIndex = .SplayMode
            'chkBindSplaySegment.Checked = .BindSplaySegment
            chkBindCrossSection.Checked = .BindCrossSection

            'design
            txtBaseLineWidthScaleFactor.Value = .DesignProperties.GetValue("BaseLineWidthScaleFactor", 0.01)
            txtBaseHeavyLinesScaleFactor.Value = .DesignProperties.GetValue("BaseHeavyLinesScaleFactor", 8.0)
            txtBaseMediumLinesScaleFactor.Value = .DesignProperties.GetValue("BaseMediumLinesScaleFactor", 3.0)
            txtBaseLightLinesScaleFactor.Value = .DesignProperties.GetValue("BaseLightLinesScaleFactor", 0.5)
            txtBaseUltraLightLinesScaleFactor.Value = .DesignProperties.GetValue("BaseUltraLightLinesScaleFactor", 0.1)
            'clipart, simboli e testo
            txtDesignSoilScaleFactor.Value = .DesignProperties.GetValue("DesignSoilScaleFactor", 1)
            txtDesignTextureScaleFactor.Value = .DesignProperties.GetValue("DesignTextureScaleFactor", 0.2)
            txtDesignTerrainLevelScaleFactor.Value = .DesignProperties.GetValue("DesignTerrainLevelScaleFactor", 1)
            txtDesignSignScaleFactor.Value = .DesignProperties.GetValue("DesignSignScaleFactor", 1)
            txtDesignExtraScaleFactor.Value = .DesignProperties.GetValue("DesignExtraScaleFactor", 1)
            txtDesignExtraTextScaleFactor.Value = .DesignProperties.GetValue("DesignExtraTextScaleFactor", 1)
            txtDesignClipartScaleFactor.Value = .DesignProperties.GetValue("DesignClipartScaleFactor", 1)
            txtDesignTextScaleFactor.Value = .DesignProperties.GetValue("DesignTextScaleFactor", 0.05)
            Dim oDesignTextFont As cIFont = .DesignProperties.GetValue("DesignTextFont", modPaint.GetDefaultFont)
            txtDesignTextFont.Tag = oDesignTextFont
            txtDesignTextFont.Text = oDesignTextFont.ToString
            cboTextRotateMode.SelectedIndex = .DesignProperties.GetValue("DesignTextRotateMode", 1)
            cboSignRotateMode.SelectedIndex = .DesignProperties.GetValue("DesignSignRotateMode", 0)

            txtDesignCrossSectionTextScaleFactor.Value = .DesignProperties.GetValue("DesignCrossSectionTextScaleFactor", 1)
            txtDesignCrossSectionMarkerTextScaleFactor.Value = .DesignProperties.GetValue("DesignCrossSectionMarkerTextScaleFactor", 1)
            txtDesignCrossSectionMarkerArrowScaleFactor.Value = .DesignProperties.GetValue("DesignCrossSectionMarkerArrowScaleFactor", 1)

            'centerline
            txtPlotPointSize.Value = .DesignProperties.GetValue("PlotPointSize", 2)
            txtPlotSelectedPointSize.Value = .DesignProperties.GetValue("PlotSelectedPointSize", 8)
            cboPlotPointSymbol.SelectedIndex = .DesignProperties.GetValue("PlotPointSymbol", 7) - 1
            picPlotPointColor.BackColor = .DesignProperties.GetValue("PlotPointColor", Color.Red)

            txtPlotPenWidth.Value = .DesignProperties.GetValue("PlotPenWidth", 2)
            txtPlotSelectedPenWidth.Value = .DesignProperties.GetValue("PlotSelectedPenWidth", 8)
            cboPlotPenStyle.SelectedIndex = .DesignProperties.GetValue("PlotPenStyle", Design.cPen.PenStylesEnum.Dash)
            picPlotPenColor.BackColor = .DesignProperties.GetValue("PlotPenColor", Color.Black)

            txtPlotTextScaleFactor.Value = .DesignProperties.GetValue("PlotTextScaleFactor", 1)
            Dim oPlotTextFont As cIFont = .DesignProperties.GetValue("PlotTextFont", modPaint.GetDefaultFont)
            txtPlotTextFont.Tag = oPlotTextFont
            txtPlotTextFont.Text = oPlotTextFont.ToString
            picPlotTextColor.BackColor = .DesignProperties.GetValue("PlotTextColor", Color.Black)

            txtPlotNoteTextScaleFactor.Value = .DesignProperties.GetValue("PlotNoteTextScaleFactor", 0.5)
            Dim oPlotNoteTextFont As cIFont = .DesignProperties.GetValue("PlotNoteTextFont", modPaint.GetDefaultFont)
            txtPlotNoteTextFont.Tag = oPlotNoteTextFont
            txtPlotNoteTextFont.Text = oPlotNoteTextFont.ToString
            txtPlotNoteTextColor.Color = .DesignProperties.GetValue("PlotNoteTextColor", Color.Black)

            txtPlotTranslationLinePenWidth.Value = .DesignProperties.GetValue("PlotTranslationLinePenWidth", 2)
            cboPlotTranslationLinePenStyle.SelectedIndex = .DesignProperties.GetValue("PlotTranslationLinePenStyle", Design.cPen.PenStylesEnum.Dot)
            picPlotTranslationLinePenColor.BackColor = .DesignProperties.GetValue("PlotTranslationLinePenColor", Color.Black)

            txtPlotLRUDPenWidth.Value = .DesignProperties.GetValue("PlotLRUDPenWidth", 0.8)
            txtPlotLRUDSelectedPenWidth.Value = .DesignProperties.GetValue("PlotLRUDSelectedPenWidth", 1.2)
            cboPlotLRUDPenStyle.SelectedIndex = .DesignProperties.GetValue("PlotLRUDPenStyle", Design.cPen.PenStylesEnum.Dot)

            txtPlotSplayPenWidth.Value = .DesignProperties.GetValue("PlotSplayPenWidth", 0.8)
            txtPlotSplaySelectedPenWidth.Value = .DesignProperties.GetValue("PlotSplaySelectedPenWidth", 1.2)
            cboPlotSplayPenStyle.SelectedIndex = .DesignProperties.GetValue("PlotSplayPenStyle", Design.cPen.PenStylesEnum.Dot)

            chkPlotCenterlineVectors.Checked = .DesignProperties.GetValue("PlotCenterlineVector", 0)
            chkPlotCenterlineForceSegmentColor.Checked = .DesignProperties.GetValue("PlotCenterlineForceColor", 0)

            txtSurfacePenWidth.Value = .DesignProperties.GetValue("SurfaceProfilePenWidth", 1)
            txtSurfaceSelectedPenWidth.Value = .DesignProperties.GetValue("SurfaceProfileSelectedPenWidth", 2)
            cboSurfacePenStyle.SelectedIndex = .DesignProperties.GetValue("SurfaceProfilePenStyle", Design.cPen.PenStylesEnum.Dot)
            picSurfacePenColor.BackColor = .DesignProperties.GetValue("SurfaceProfilePenColor", Color.Gray)

            'sketch
            txtDesignSketchPlanCorrectionX.Value = .DesignProperties.GetValue("DesignSketchPlanCorrectionX", 0)
            txtDesignSketchPlanCorrectionY.Value = .DesignProperties.GetValue("DesignSketchPlanCorrectionY", 0)
            txtDesignSketchPlanCorrectionScale.Value = .DesignProperties.GetValue("DesignSketchPlanCorrectionScale", 1)
            txtDesignSketchProfileCorrectionX.Value = .DesignProperties.GetValue("DesignSketchProfileCorrectionX", 0)
            txtDesignSketchProfileCorrectionY.Value = .DesignProperties.GetValue("DesignSketchProfileCorrectionY", 0)
            txtDesignSketchProfileCorrectionScale.Value = .DesignProperties.GetValue("DesignSketchProfileCorrectionScale", 1)

            'txtDesignEditCombinedAreaTransparencyThreshold.Value = .DesignProperties.GetValue("DesignCombinedAreaTransparencyThreshold", 120)
            txtDesignEditLowerLayersTransparencyThreshold.Value = .DesignProperties.GetValue("LowerLayersDesignTransparencyThreshold", 120)
            txtDesignEditCombinedAreaTransparencyThreshold.Value = .DesignProperties.GetValue("DesignEditCombinedAreaTransparencyThreshold", 120)
            txtDesignCombinedAreaTransparencyThreshold.Value = .DesignProperties.GetValue("DesignCombinedAreaTransparencyThreshold", 120)
            txtDesignBackgroundTransparencyThreshold.Value = .DesignProperties.GetValue("DesignBackgroundTransparencyThreshold", 0)
            txtDesignOriginalPositionTransparencyThreshold.Value = .DesignProperties.GetValue("DesignOriginalPositionTransparencyThreshold", 255)

            txtDesignItemNamePattern.Text = .DesignProperties.GetValue("DesignItemNamePattern", "")

            chkShowLegacyExtraPrintAndExportObjects.Checked = .ShowLegacyPrintAndExportObjects

            '3D
            'chk3DLochUseCaveBorder.Checked = .ThreeDLochUseCaveBorder
            chk3DLochShowSplay.Checked = .ThreeDLochShowSplay
            cbo3DModelMode.SelectedIndex = .ThreeDModelMode
            chk3dLochShowDialog.Checked = Integer.Parse(oSurvey.SharedSettings.GetValue("loch.showdialog", 1))
            txt3DNormalizationFactor.Value = .ThreeDNormalizationFactor
            txt3DOversamplingFactor.Value = .ThreeDOversamplingFactor
            txt3DExportAsImageOversampling.Value = .ThreeDExportAsImageOversamplingFactor

            txt3DSurfaceModelLOD.Value = .ThreeDSurfaceModelLod
            txt3DSurfaceTextureLOD.Value = .ThreeDSurfaceTextureLod

            'revisioni
            chkHistoryEnabled.Checked = .HistoryEnabled

            'superficie
            chksurfaceprofile.Checked = .SurfaceProfile
            chkSurfaceProfileShow.Checked = .SurfaceProfileShow

            Call pSessionsLoad()
            Call pCavesLoad()
            Call pHighlightsLoad()
            Call pElevationsLoad()
            Call pOrthophotosLoad()
            Call pWMSsLoad()
            'Call pGradesLoad()

            Call pElevationRebindSurfaceProfileCombo(.SurfaceProfileElevation)
        End With

        'If SelectedTabIndex Is Nothing Then
        '    Call pSelectTabByIndex(0)
        'Else
        '    Call pSelectTabByIndex(SelectedTabIndex)
        'End If
        AddHandler Me.Shown, Sub(sender As Object, e As EventArgs)
                                 If SelectedTabIndex Is Nothing Then
                                     Call pSelectTabByIndex(0)
                                 Else
                                     Call pSelectTabByIndex(SelectedTabIndex)
                                 End If
                             End Sub



        Cursor = Cursors.Default
    End Sub

    Private Sub pGradesLoad()
        tvGrades.BeginUpdate()
        tvGrades.DataSource = New cGradeEditBindingList(oSurvey)
        tvGrades.ExpandAll()

        If tvGrades.Nodes.Count > 0 Then
            tvGrades.SelectNode(tvGrades.Nodes(0))
        End If

        btnGradesAdd.Enabled = True
        'btnGradesDelete.Enabled = tvGrades.Nodes.Count > 0

        tvGrades.EndUpdate()

        'Call cboSessionGrade.Items.Clear()
        'Call cboSessionGrade.Items.Add("")
        'For Each oGrade As UIHelpers.cGradePlaceHolder In DirectCast(tvGrades.DataSource, UIHelpers.cGradeEditBindingList)
        '    Call cboSessionGrade.Items.Add(oGrade.Description)
        'Next
    End Sub

    Private Sub pWMSsLoad()
        tvWMSs.BeginUpdate()
        tvWMSs.DataSource = New cWMSsBindingList(oSurvey)
        tvWMSs.ExpandAll()

        If tvWMSs.Nodes.Count > 0 Then
            tvWMSs.SelectNode(tvWMSs.Nodes(0))
        End If

        btnWMSAdd.Enabled = True
        btnWMSDelete.Enabled = tvWMSs.Nodes.Count > 0

        tvWMSs.EndUpdate()
    End Sub

    Private Sub pOrthophotosLoad()
        tvOrthophotos.BeginUpdate()
        tvOrthophotos.DataSource = New cOrthophotosBindingList(oSurvey)
        tvOrthophotos.ExpandAll()

        If tvOrthophotos.Nodes.Count > 0 Then
            tvOrthophotos.SelectNode(tvOrthophotos.Nodes(0))
        End If

        btnOrthophotoAdd.Enabled = True
        btnOrthophotoDelete.Enabled = tvOrthophotos.Nodes.Count > 0

        tvOrthophotos.EndUpdate()
    End Sub

    Private Sub pElevationsLoad()
        tvElevations.BeginUpdate()
        tvElevations.DataSource = New cElevationsBindingList(oSurvey)
        tvElevations.ExpandAll()

        If tvElevations.Nodes.Count > 0 Then
            tvElevations.SelectNode(tvElevations.Nodes(0))
        End If

        btnElevationAdd.Enabled = True
        btnElevationDelete.Enabled = tvElevations.Nodes.Count > 0

        tvElevations.EndUpdate()
    End Sub

    Private Function pSelectTabByIndex(TabIndex As Integer) As Boolean
        Try
            Dim sName As String = tabMain.TabPages(TabIndex).Name
            For Each oElement In AccordionControl1.GetElements
                If oElement.Tag IsNot Nothing AndAlso oElement.Tag.tolower = sName.ToLower Then
                    Call AccordionControl1.SelectElement(oElement)
                    Call AccordionControl1.MakeElementVisible(oElement)
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Private Sub pGradesLoad()
    '    Call cboSessionGrade.Items.Add("")
    '    For Each oGrade As cGrade In oSurvey.Grades
    '        Call cboSessionGrade.Items.Add(oGrade.Description)
    '    Next
    'End Sub

    Private Sub pOriginsLoad()
        'For Each oTrigPoint As cTrigPoint In oSurvey.TrigPoints
        '    If Not (oTrigPoint.Data.IsSplay Or oTrigPoint.IsSystem) Then
        '        Call cboOrigin.Items.Add(oTrigPoint.Name)
        '        Call cboCaveInfoExtendStart.Items.Add(oTrigPoint.Name)
        '    End If
        'Next
        'cboOrigin.SelectedItem = oSurvey.Properties.Origin
        cboOrigin.FastRebind(oSurvey, oSurvey.Properties.Origin, False, False)
        If cboOrigin.Enabled Then
            cboOrigin.Enabled = oSurvey.Properties.DesignWarpingMode = cSurvey.cSurvey.DesignWarpingModeEnum.None Or (oSurvey.Properties.DesignWarpingMode <> cSurvey.cSurvey.DesignWarpingModeEnum.None And oSurvey.Properties.InversionMode = cSurvey.cSurvey.InversioneModeEnum.Absolute)
        End If
        cboCaveInfoExtendStart.FastRebind(oSurvey, "", False, False)
    End Sub

    Private Sub pOriginsEnabled()
        Try
            'cboOrigin.Enabled = cboDesignWarpingMode.SelectedIndex = cSurvey.cSurvey.DesignWarpingModeEnum.None Or (cboDesignWarpingMode.SelectedIndex <> cSurvey.cSurvey.DesignWarpingModeEnum.None And oSurvey.Profile.GetBindedItems > 0)
            'If cboDesignWarpingMode.SelectedIndex = cSurvey.cSurvey.DesignWarpingModeEnum.None Then
            'no warping
            cboOrigin.Enabled = True
            'Else
            'ok warping
            'If cboInversionMode.SelectedIndex = cSurvey.cSurvey.InversioneModeEnum.Relative Then
            '    If oSurvey.Profile.IsEmpty Then
            '        cboOrigin.Enabled = True
            '    Else
            '        If oSurvey.Profile.HasBindedItems Then
            '            cboOrigin.Enabled = False
            '        Else
            '            cboOrigin.Enabled = True
            '        End If
            '    End If
            'Else
            cboOrigin.Enabled = True
            'End If
            'End If
            'cboInversionMode.Enabled = cboOrigin.Enabled
        Catch
        End Try
    End Sub

    Private Class cTypeComboItem(Of Type)
        Private oValue As Type
        Private sText As String

        Public ReadOnly Property Text As String
            Get
                Return sText
            End Get
        End Property

        Public ReadOnly Property Value As Type
            Get
                Return oValue
            End Get
        End Property

        Public Sub New(ByVal Text As String, ByVal Value As Type)
            sText = Text
            oValue = Value
        End Sub
    End Class

    'Private Sub pCaveBranchesLoad(ParentBranches As cCaveInfoBranches, ParentNodes As TreeNodeCollection)
    '    For Each oBranch As cCaveInfoBranch In ParentBranches
    '        Dim oBranchNode As TreeNode = ParentNodes.Add(oBranch.Name)
    '        oBranchNode.Name = oBranch.Name
    '        Dim oCIB As cCaveInfoBranchPlaceHolder = New cCaveInfoBranchPlaceHolder
    '        oCIB.Name = oBranch.Name
    '        oCIB.Color = oBranch.Color
    '        oCIB.Description = oBranch.Description
    '        oCIB.SurfaceProfileShow = oBranch.SurfaceProfileShow
    '        oCIB.Locked = oBranch.Locked
    '        oCIB.ExtendStart = oBranch.ExtendStart
    '        oCIB.Priority = oBranch.Priority
    '        oCIB.ParentConnection = oBranch.ParentConnection
    '        oCIB.Connection = oBranch.Connection
    '        oCIB.Source = oBranch
    '        oBranchNode.Tag = oCIB
    '        If oCIB.ExtendStart = "" Then
    '            oBranchNode.SelectedImageKey = "branch"
    '            oBranchNode.ImageKey = "branch"
    '        Else
    '            oBranchNode.SelectedImageKey = "origin"
    '            oBranchNode.ImageKey = "origin"
    '        End If

    '        Call pCaveBranchesLoad(oBranch.Branches, oBranchNode.Nodes)
    '    Next
    'End Sub

    Private Sub pCavesLoad()
        tvCaveInfos.BeginUpdate()
        tvCaveInfos.DataSource = New cCaveInfoBranchEditBindingList(oSurvey)
        tvCaveInfos.ExpandAll()

        If tvCaveInfos.Nodes.Count > 0 Then
            tvCaveInfos.SelectNode(tvCaveInfos.Nodes(0))
        End If

        btnCaveInfoAddCave.Enabled = True
        btnCaveInfoAddBranch.Enabled = tvCaveInfos.Nodes.Count > 0
        btnCaveInfoDelete.Enabled = tvCaveInfos.Nodes.Count > 0

        tvCaveInfos.EndUpdate()
    End Sub

    Private Sub pHighlightsLoad()
        tvHighlights.BeginUpdate()
        tvHighlights.DataSource = New cHighlightEditBindingList(oSurvey)
        tvHighlights.EndUpdate()

        'Call tvHighlights.Nodes.Clear()
        'For Each oHighlight As Properties.cHighlightsDetail In oSurvey.Properties.HighlightsDetails
        '    Dim oHighlightNode As TreeNode = tvHighlights.Nodes.Add(oHighlight.ID)
        '    oHighlightNode.Name = oHighlight.ID
        '    oHighlightNode.Text = oHighlight.Name
        '    Dim oCI As cHighlightPlaceholder = New cHighlightPlaceholder
        '    oCI.ID = oHighlight.ID
        '    oCI.Name = oHighlight.Name
        '    oCI.Color = oHighlight.Color
        '    oCI.Size = oHighlight.Size
        '    oCI.Opacity = oHighlight.Opacity
        '    oCI.ApplyTo = oHighlight.ApplyTo
        '    oCI.Condition = oHighlight.Condition
        '    oCI.System = oHighlight.System

        '    oCI.Source = oHighlight
        '    oHighlightNode.Tag = oCI
        '    oHighlightNode.SelectedImageKey = "hl"
        '    oHighlightNode.ImageKey = "hl"
        'Next

        If tvHighlights.Nodes.Count > 0 Then
            tvHighlights.FocusedNode = tvHighlights.Nodes(0)
        End If

        btnAddHighlight.Enabled = True
        btnDeleteHighlight.Enabled = tvHighlights.Nodes.Count > 0 AndAlso tvHighlights.GetFocusedObject IsNot Nothing AndAlso DirectCast(tvHighlights.GetFocusedObject, cHighlightPlaceholder).System
    End Sub

    Private Sub pSessionsLoad()
        tvSessions.BeginUpdate()
        tvSessions.DataSource = New cSessionsEditBindingList(oSurvey)

        btnSessionAdd.Enabled = True
        If tvSessions.Nodes.Count > 0 Then
            tvSessions.SelectNode(tvSessions.Nodes(0))
        Else
            btnSessionDelete.Enabled = False
        End If

        tvSessions.EndUpdate()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Call pSave()

        DialogResult = Windows.Forms.DialogResult.OK
        Call Close()
    End Sub

    Private Sub pSave()
        With oSurvey.Properties
            .ID = txtCatasto.Text
            .Name = txtName.Text
            .Description = txtDescrizione.Text
            .Team = txtTeam.Text
            .Club = txtClub.Text
            .Designer = txtDesigner.Text

            '.DefGrade = cboDefGrade.Text
            '.DefAccuracy = cboDefAccuracy.Text

            .Note = txtNote.Text

            .Origin = cboOrigin.Text

            .CalculateMode = If(chkCalculateMode.Checked, cSurvey.cSurvey.CalculateModeEnum.Automatic, cSurvey.cSurvey.CalculateModeEnum.Manual)
            .CalculateType = cboCalculateType.SelectedIndex
            .RingCorrectionMode = cboRingCorrectionMode.SelectedIndex
            .NordCorrectionMode = cboNordCorrection.SelectedIndex
            '.InversionMode = cboInversionMode.SelectedIndex

            '.DataFormat = cboDataFormat.SelectedIndex
            '.DistanceType = cboDistanceType.SelectedIndex
            '.BearingType = cboBearingType.SelectedIndex
            '.BearingDirection = if(chkBearingDirection.Checked, cSegment.MeasureDirectionEnum.Inverted, cSegment.MeasureDirectionEnum.Direct)
            '.InclinationType = cboInclinationType.SelectedIndex
            '.InclinationDirection = if(chkInclinationDirection.Checked, cSegment.MeasureDirectionEnum.Inverted, cSegment.MeasureDirectionEnum.Direct)
            '.DepthType = cboDepthType.SelectedIndex

            'If cboGrade.SelectedIndex = 0 Then
            '    .Grade = ""
            'Else
            '    .Grade = oSurvey.Grades(cboGrade.SelectedIndex - 1).ID
            'End If

            .GlobalDeclinationEnabled = chkGlobalDecMag.Checked
            .GlobalDeclination = txtGlobalDecMag.Text

            '.NordType = cboNordType.SelectedIndex
            '.DeclinationEnabled = chkDecMag.Checked
            '.Declination = txtDecMag.Text

            '.VThresholdEnabled = chkVthreshold.Checked
            '.VThreshold = txtVthreshold.Value

            '.SideMeasuresType = cboSideMeasuresType.SelectedIndex
            '.SideMeasuresReferTo = cboSideMeasuresReferTo.SelectedIndex

            .GlobalVThresholdEnabled = chkGlobalVthreshold.Checked
            .GlobalVThreshold = txtGlobalVthreshold.Value

            .InfoBoxStructure = txtInfoBoxStructure.Text
            .TrigPointStructure = txtTrigPointStructure.Text
            .SpecialTrigPointStructure = txtSpecialTrigPointStructure.Text

            .DesignBindingMode = cboDesignBindingMode.SelectedIndex
            .DesignWarpingMode = cboDesignWarpingMode.SelectedIndex
            .DesignWarpingState = If(optWarpingActive.Checked, cSurvey.cSurvey.DesignWarpingStateEnum.Active, cSurvey.cSurvey.DesignWarpingStateEnum.Paused)
            .PlanWarpingDisabled = Not chkPlanWarpingEnabled.Checked
            .ProfileWarpingDisabled = Not chkProfileWarpingEnabled.Checked
            .ShowWarpingDetails = chkShowWarpingDetails.Checked

            .SplayMode = cboSplayMode.SelectedIndex
            .BindCrossSection = chkBindCrossSection.Checked

            .SurfaceProfile = chksurfaceprofile.Checked
            .SurfaceProfileShow = chkSurfaceProfileShow.Checked

            Call DirectCast(tvSessions.DataSource, cSessionsEditBindingList).Save()
            Call pSessionsLoad()

            'For Each oCaveNode As TreeNode In tvCaveInfos.Nodes
            '    Dim oCI As cCaveInfoPlaceHolder = oCaveNode.Tag
            '    If oCI.Deleted And Not oCI.Created Then
            '        Call .CaveInfos.Remove(oCI.Name, True)
            '    ElseIf oCI.Created Then
            '        Dim oCaveInfo As cCaveInfo = .CaveInfos.Add(oCI.Name)
            '        oCaveInfo.ID = oCI.ID
            '        oCaveInfo.Color = oCI.Color
            '        oCaveInfo.Description = oCI.Description
            '        oCaveInfo.SurfaceProfileShow = oCI.SurfaceProfileShow
            '        oCaveInfo.Locked = oCI.Locked
            '        oCaveInfo.ExtendStart = oCI.ExtendStart
            '        oCaveInfo.Priority = oCI.Priority
            '        oCaveInfo.ParentConnection = oCI.ParentConnection
            '        oCaveInfo.Connection = oCI.Connection
            '        oCI.Source = oCaveInfo
            '    Else
            '        oCI.Source.ID = oCI.ID
            '        oCI.Source.Color = oCI.Color
            '        oCI.Source.Description = oCI.Description
            '        oCI.Source.SurfaceProfileShow = oCI.SurfaceProfileShow
            '        oCI.Source.Locked = oCI.Locked
            '        oCI.Source.ExtendStart = oCI.ExtendStart
            '        oCI.Source.Priority = oCI.Priority
            '        oCI.Source.ParentConnection = oCI.ParentConnection
            '        oCI.Source.Connection = oCI.Connection
            '        Dim sNewName As String = oCI.Name
            '        Dim sOldName As String = oCI.Source.Name
            '        If sNewName.ToLower <> sOldName.ToLower Then
            '            Call .CaveInfos.Rename(sOldName, sNewName, True)
            '        End If
            '    End If
            'Next

            'For Each oCaveNode As TreeNode In tvCaveInfos.Nodes
            '    Dim oCI As cCaveInfoPlaceHolder = oCaveNode.Tag
            '    Call pCaveBranchesSave(oCI.Source.Branches, oCaveNode.Nodes)
            'Next
            Call DirectCast(tvCaveInfos.DataSource, cCaveInfoBranchEditBindingList).Save()
            Call pCavesLoad()

            Call DirectCast(tvHighlights.DataSource, cHighlightEditBindingList).Save()
            Call pHighlightsLoad()

            With .GPS
                .Enabled = chkGPSEnabled.Checked
                .RefPointOnOrigin = optGPSRefPointOnOrigin.EditValue
                .CustomRefPoint = cboGPSCustomRefPoint.Text
                .System = cboCoordinateGeo.Text
                Select Case .System
                    Case "WGS84/UTM"
                        .Band = cboCoordinateBand.Text
                        .Zone = cboCoordinateZone.Text
                    Case Else
                        .Format = cboCoordinateFormat.Text
                End Select
                .SendToTherion = chkGPSSendToTherion.Checked
                .AllowManualDeclinations = chkGPSAllowManualDeclinations.Checked
            End With

            Call .DesignProperties.SetValue("clipborder", cboClipBorder.SelectedIndex)
            Call .DesignProperties.SetValue("clippingforadvancedbrush", cboClipAdvancedClipart.SelectedIndex)

            Call .DesignProperties.SetValue("LineType", cboLineType.SelectedIndex)

            Call .DesignProperties.SetValue("BaseLineWidthScaleFactor", txtBaseLineWidthScaleFactor.Value)
            Call .DesignProperties.SetValue("BaseHeavyLinesScaleFactor", txtBaseHeavyLinesScaleFactor.Value)
            Call .DesignProperties.SetValue("BaseMediumLinesScaleFactor", txtBaseMediumLinesScaleFactor.Value)
            Call .DesignProperties.SetValue("BaseLightLinesScaleFactor", txtBaseLightLinesScaleFactor.Value)
            Call .DesignProperties.SetValue("BaseUltraLightLinesScaleFactor", txtBaseUltraLightLinesScaleFactor.Value)

            Call .DesignProperties.SetValue("DesignSoilScaleFactor", txtDesignSoilScaleFactor.Value)
            Call .DesignProperties.SetValue("DesignTextureScaleFactor", txtDesignTextureScaleFactor.Value)
            Call .DesignProperties.SetValue("DesignTerrainLevelScaleFactor", txtDesignTerrainLevelScaleFactor.Value)
            Call .DesignProperties.SetValue("DesignClipartScaleFactor", txtDesignClipartScaleFactor.Value)
            Call .DesignProperties.SetValue("DesignSignScaleFactor", txtDesignSignScaleFactor.Value)
            Call .DesignProperties.SetValue("DesignExtraScaleFactor", txtDesignExtraScaleFactor.Value)
            Call .DesignProperties.SetValue("DesignExtraTextScaleFactor", txtDesignExtraTextScaleFactor.Value)
            Call .DesignProperties.SetValue("DesignTextScaleFactor", txtDesignTextScaleFactor.Value)
            Call .DesignProperties.SetValue("DesignTextFont", txtDesignTextFont.Tag)
            Call .DesignProperties.SetValue("DesignTextRotateMode", cboTextRotateMode.SelectedIndex)
            Call .DesignProperties.SetValue("DesignSignRotateMode", cboSignRotateMode.SelectedIndex)

            Call .DesignProperties.SetValue("DesignCrossSectionTextScaleFactor", txtDesignCrossSectionTextScaleFactor.Value)
            Call .DesignProperties.SetValue("DesignCrossSectionMarkerTextScaleFactor", txtDesignCrossSectionMarkerTextScaleFactor.Value)
            Call .DesignProperties.SetValue("DesignCrossSectionMarkerArrowScaleFactor", txtDesignCrossSectionMarkerArrowScaleFactor.Value)

            Call .DesignProperties.SetValue("PlotPointSize", txtPlotPointSize.Value)
            Call .DesignProperties.SetValue("PlotSelectedPointSize", txtPlotSelectedPointSize.Value)
            Call .DesignProperties.SetValue("PlotPointSymbol", cboPlotPointSymbol.SelectedIndex + 1)
            Call .DesignProperties.SetValue("PlotPointColor", picPlotPointColor.BackColor)

            Call .DesignProperties.SetValue("PlotPenWidth", txtPlotPenWidth.Value)
            Call .DesignProperties.SetValue("PlotSelectedPenWidth", txtPlotSelectedPenWidth.Value)
            Call .DesignProperties.SetValue("PlotPenStyle", cboPlotPenStyle.SelectedIndex)
            Call .DesignProperties.SetValue("PlotPenColor", picPlotPenColor.BackColor)

            Call .DesignProperties.SetValue("PlotTranslationLinePenWidth", txtPlotTranslationLinePenWidth.Value)
            Call .DesignProperties.SetValue("PlotTranslationLinePenStyle", cboPlotTranslationLinePenStyle.SelectedIndex)
            Call .DesignProperties.SetValue("PlotTranslationLinePenColor", picPlotTranslationLinePenColor.BackColor)

            Call .DesignProperties.SetValue("PlotLRUDPenWidth", txtPlotLRUDPenWidth.Value)
            Call .DesignProperties.SetValue("PlotLRUDSelectedPenWidth", txtPlotLRUDSelectedPenWidth.Value)
            Call .DesignProperties.SetValue("PlotLRUDPenStyle", cboPlotLRUDPenStyle.SelectedIndex)

            Call .DesignProperties.SetValue("PlotSplayPenWidth", txtPlotSplayPenWidth.Value)
            Call .DesignProperties.SetValue("PlotSplaySelectedPenWidth", txtPlotSplaySelectedPenWidth.Value)
            Call .DesignProperties.SetValue("PlotSplayPenStyle", cboPlotSplayPenStyle.SelectedIndex)

            Call .DesignProperties.SetValue("PlotTextScaleFactor", txtPlotTextScaleFactor.Value)
            Call .DesignProperties.SetValue("PlotTextFont", txtPlotTextFont.Tag)
            Call .DesignProperties.SetValue("PlotTextColor", picPlotTextColor.BackColor)

            Call .DesignProperties.SetValue("PlotNoteTextScaleFactor", txtPlotNoteTextScaleFactor.Value)
            Call .DesignProperties.SetValue("PlotNoteTextFont", txtPlotNoteTextFont.Tag)
            Call .DesignProperties.SetValue("PlotNoteTextColor", txtPlotNoteTextColor.Color)

            Call .DesignProperties.SetValue("PlotCenterlineVector", If(chkPlotCenterlineVectors.Checked, 1, 0))
            Call .DesignProperties.SetValue("PlotCenterlineForceColor", If(chkPlotCenterlineForceSegmentColor.Checked, 1, 0))

            Call .DesignProperties.SetValue("SurfaceProfilePenWidth", txtSurfacePenWidth.Value)
            Call .DesignProperties.SetValue("SurfaceProfileSelectedPenWidth", txtSurfaceSelectedPenWidth.Value)
            Call .DesignProperties.SetValue("SurfaceProfilePenStyle", cboSurfacePenStyle.SelectedIndex)
            Call .DesignProperties.SetValue("SurfaceProfilePenColor", picSurfacePenColor.BackColor)

            Call .DesignProperties.SetValue("DesignSketchPlanCorrectionX", txtDesignSketchPlanCorrectionX.Value)
            Call .DesignProperties.SetValue("DesignSketchPlanCorrectionY", txtDesignSketchPlanCorrectionY.Value)
            Call .DesignProperties.SetValue("DesignSketchPlanCorrectionScale", txtDesignSketchPlanCorrectionScale.Value)
            Call .DesignProperties.SetValue("DesignSketchProfileCorrectionX", txtDesignSketchProfileCorrectionX.Value)
            Call .DesignProperties.SetValue("DesignSketchProfileCorrectionY", txtDesignSketchProfileCorrectionY.Value)
            Call .DesignProperties.SetValue("DesignSketchProfileCorrectionScale", txtDesignSketchProfileCorrectionScale.Value)

            Call .DesignProperties.SetValue("LowerLayersDesignTransparencyThreshold", txtDesignEditLowerLayersTransparencyThreshold.Value)
            Call .DesignProperties.SetValue("DesignEditCombinedAreaTransparencyThreshold", txtDesignEditCombinedAreaTransparencyThreshold.Value)
            Call .DesignProperties.SetValue("DesignCombinedAreaTransparencyThreshold", txtDesignCombinedAreaTransparencyThreshold.Value)
            Call .DesignProperties.SetValue("DesignBackgroundTransparencyThreshold", txtDesignBackgroundTransparencyThreshold.Value)
            Call .DesignProperties.SetValue("DesignOriginalPositionTransparencyThreshold", txtDesignOriginalPositionTransparencyThreshold.Value)

            Call .DesignProperties.SetValue("DesignItemNamePattern", txtDesignItemNamePattern.Text)

            .ShowLegacyPrintAndExportObjects = chkShowLegacyExtraPrintAndExportObjects.Checked

            '3D
            .ThreeDLochShowSplay = chk3DLochShowSplay.Checked
            .ThreeDModelMode = cbo3DModelMode.SelectedIndex
            .ThreeDNormalizationFactor = txt3DNormalizationFactor.Value
            .ThreeDOversamplingFactor = txt3DOversamplingFactor.Value
            .ThreeDExportAsImageOversamplingFactor = txt3DExportAsImageOversampling.Value

            .ThreeDSurfaceModelLod = txt3DSurfaceModelLOD.Value
            .ThreeDSurfaceTextureLod = txt3DSurfaceTextureLOD.Value

            'superfice
            .SurfaceProfile = chksurfaceprofile.Checked
            .SurfaceProfileShow = chkSurfaceProfileShow.Checked

            Call pElevationRebindSurfaceProfileCombo()
            .SurfaceProfileElevation = cbosurfaceprofileelevation.GetSelectedElevation

            Call oSurvey.SharedSettings.SetValue("loch.showdialog", If(chk3dLochShowDialog.Checked, "1", "0"))

            .HistoryEnabled = chkHistoryEnabled.Checked

            Call DirectCast(tvElevations.DataSource, cElevationsBindingList).Save()
            Call DirectCast(tvOrthophotos.DataSource, cOrthophotosBindingList).Save()
            Call DirectCast(tvWMSs.DataSource, cWMSsBindingList).Save()
            Call DirectCast(tvGrades.DataSource, cGradeEditBindingList).Save()
            Call pElevationsLoad()
            Call pOrthophotosLoad()
            Call pWMSsLoad()
            Call pGradesLoad()
        End With

        Call oSurvey.RaiseOnPropertiesChanged(cSurvey.cSurvey.OnPropertiesChangedEventArgs.PropertiesChangeSourceEnum.DefaultProperties)
    End Sub

    'Private Sub pCaveBranchesSave(ParentBranches As cCaveInfoBranches, ParentNodes As TreeNodeCollection)
    '    For Each oBranchNode As TreeNode In ParentNodes
    '        Dim oCIB As cCaveInfoBranchPlaceHolder = oBranchNode.Tag
    '        If oCIB.Deleted And Not oCIB.Created Then
    '            Call ParentBranches.Remove(oCIB.Name, True)
    '        ElseIf oCIB.Created Then
    '            Dim oCaveInfoBranch As cCaveInfoBranch = ParentBranches.Add(oCIB.Name)
    '            oCaveInfoBranch.Color = oCIB.Color
    '            oCaveInfoBranch.Description = oCIB.Description
    '            oCaveInfoBranch.SurfaceProfileShow = oCIB.SurfaceProfileShow
    '            oCaveInfoBranch.Locked = oCIB.Locked
    '            oCaveInfoBranch.ExtendStart = oCIB.ExtendStart
    '            oCaveInfoBranch.Priority = oCIB.Priority
    '            oCaveInfoBranch.ParentConnection = oCIB.ParentConnection
    '            oCaveInfoBranch.Connection = oCIB.Connection
    '            oCIB.Source = oCaveInfoBranch
    '        Else
    '            oCIB.Source.Color = oCIB.Color
    '            oCIB.Source.Description = oCIB.Description
    '            oCIB.Source.SurfaceProfileShow = oCIB.SurfaceProfileShow
    '            oCIB.Source.Locked = oCIB.Locked
    '            oCIB.Source.ExtendStart = oCIB.ExtendStart
    '            oCIB.Source.Priority = oCIB.Priority
    '            oCIB.Source.ParentConnection = oCIB.ParentConnection
    '            oCIB.Source.Connection = oCIB.Connection
    '            Dim sNewName As String = oCIB.Name
    '            Dim sOldName As String = oCIB.Source.Name
    '            If sNewName.ToLower <> sOldName.ToLower Then
    '                Call ParentBranches.Rename(sOldName, sNewName, True)
    '            End If
    '        End If
    '        Call pCaveBranchesSave(oCIB.Source.Branches, oBranchNode.Nodes)
    '    Next
    'End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Call Close()
    End Sub

    Private Sub cmdInfoBoxAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInfoBoxStructureTagAdd.Click
        Call mnuInfoBoxTags.Show(Cursor.Position)
    End Sub

    Private Sub mnuInfoBoxTags_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtInfoBoxStructure.SelectedText = sender.tag
    End Sub

    Private Sub mnuTrigpointTags_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtTrigPointStructure.SelectedText = sender.tag
    End Sub

    Private Sub mnuItemNamePatternTags_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtDesignItemNamePattern.SelectedText = sender.tag
    End Sub

    Private Sub mnuSpecialTrigpointTags_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtSpecialTrigPointStructure.SelectedText = sender.tag
    End Sub

    Private Sub cboCalculateMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCalculateType.SelectedIndexChanged
        Select Case cboCalculateType.SelectedIndex
            Case 0
                cboRingCorrectionMode.Enabled = False
                cboRingCorrectionMode.SelectedIndex = 0

                optGPSRefPointOnOrigin.Enabled = True
                optGPSCustomRefPoint.Enabled = True
                cboGPSCustomRefPoint.Enabled = True
                lblGPSCustomRefPoint.Enabled = True
                chkGPSSendToTherion.Enabled = False

                lblNordCorrection.Enabled = False
                cboNordCorrection.Enabled = False

                lblCalculateVersion.Visible = False
                cboCalculateVersion.Visible = False
            Case 1
                cboRingCorrectionMode.Enabled = True

                optGPSRefPointOnOrigin.Enabled = False
                optGPSCustomRefPoint.Enabled = False

                cboGPSCustomRefPoint.Enabled = False
                lblGPSCustomRefPoint.Enabled = False
                chkGPSSendToTherion.Enabled = False

                lblNordCorrection.Enabled = False
                cboNordCorrection.Enabled = False

                lblCalculateVersion.Visible = False
                cboCalculateVersion.Visible = False
            Case 2
                cboRingCorrectionMode.Enabled = False
                cboRingCorrectionMode.SelectedIndex = 0

                optGPSRefPointOnOrigin.Enabled = True
                optGPSCustomRefPoint.Enabled = True

                cboGPSCustomRefPoint.Enabled = True
                lblGPSCustomRefPoint.Enabled = True
                chkGPSSendToTherion.Enabled = True

                lblNordCorrection.Enabled = True
                cboNordCorrection.Enabled = True

                lblCalculateVersion.Visible = True
                cboCalculateVersion.Visible = True
        End Select
    End Sub

    'Private Sub cmdCaveInfoColorChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim oCD As ColorDialog = New ColorDialog
    '    With oCD
    '        .FullOpen = True
    '        .AnyColor = True
    '        .Color = picCaveInfoColor.BackColor
    '        If .ShowDialog = Windows.Forms.DialogResult.OK Then
    '            picCaveInfoColor.BackColor = .Color
    '            Try
    '                Select Case tvCaveInfos.SelectedNode.Tag.type
    '                    Case "cave"
    '                        Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
    '                        oCI.Color = .Color
    '                    Case "branch"
    '                        Dim oCIB As cCaveInfoBranchPlaceHolder = tvCaveInfos.SelectedNode.Tag
    '                        oCIB.Color = .Color
    '                End Select
    '            Catch
    '            End Try
    '        End If
    '    End With
    'End Sub

    'Private Sub cmdCaveInfoColorReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    picCaveInfoColor.BackColor = Color.Transparent
    '    Try
    '        Select Case tvCaveInfos.SelectedNode.Tag.type
    '            Case "cave"
    '                Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
    '                oCI.Color = Color.Transparent
    '            Case "branch"
    '                Dim oCIB As cCaveInfoBranchPlaceHolder = tvCaveInfos.SelectedNode.Tag
    '                oCIB.Color = Color.Transparent
    '        End Select
    '    Catch
    '    End Try
    'End Sub

    Private Sub txtCaveInfoName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCaveInfoName.Validated
        Try
            Dim sName As String = txtCaveInfoName.Text
            Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetFocusedObject
            oItem.Name = sName
        Catch
        End Try
    End Sub

    Private Sub txtCaveInfoID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCaveInfoID.Validated
        Try
            Dim sID As String = txtCaveInfoID.Text
            Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetFocusedObject
            oItem.ID = sID
        Catch
        End Try
    End Sub

    Private Sub txtCaveInfoName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCaveInfoName.Validating
        Dim sNewName As String = txtCaveInfoName.Text.Trim
        If sNewName = "" Then
            e.Cancel = True
        Else
            Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetFocusedObject
            e.Cancel = DirectCast(tvCaveInfos.DataSource, cCaveInfoBranchEditBindingList).ContainsName(sNewName)
        End If
    End Sub

    Private Function pGetNewNodeName(ByVal Prefix As String, ByVal Items As cCaveInfoBranchEditBindingList)
        Dim iCount As Integer = 1
        Do
            Dim sName As String = Prefix & " " & iCount
            If Not Items.ContainsName(sName) Then
                Return sName
            End If
            iCount += 1
        Loop
    End Function

    Private Function pCaveInfoGetFirstLevelNode(Node As TreeNode) As TreeNode
        If Node.Parent Is Nothing Then
            Return Node
        Else
            Return pCaveInfoGetFirstLevelNode(Node.Parent)
        End If
    End Function

    'Private Sub pCaveInfoDeleteChildNode(Node As TreeNode)
    '    For Each oChildNode As TreeNode In Node.Nodes
    '        oChildNode.SelectedImageKey = "deleted"
    '        oChildNode.ImageKey = "deleted"
    '        oChildNode.Tag.deleted = True
    '        Call pCaveInfoDeleteChildNode(oChildNode)
    '    Next
    'End Sub

    Private Sub cboGPSCustomRefPoint_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGPSCustomRefPoint.DropDown
        Call cboGPSCustomRefPoint.Items.Clear()
        For Each oTrigPoint As cTrigPoint In oSurvey.TrigPoints.GetGPSReferencedPoint
            cboGPSCustomRefPoint.Items.Add(oTrigPoint.Name)
        Next
    End Sub

    'Private Sub btnSessionsAddSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call tvSessions.Focus()

    '    Dim sNewID As String
    '    Dim sNewDescriptionBase As String = GetLocalizedString("properties.textpart1")
    '    Dim iNewCount As Integer = 0
    '    Do
    '        iNewCount += 1
    '        sNewID = Strings.Format(Today, "yyyyMMdd") & "_" & (sNewDescriptionBase & " " & iNewCount).Replace(" ", "_").ToLower
    '    Loop While tvSessions.Nodes.ContainsKey(sNewID)
    '    Dim oSession As cSession = oSurvey.Properties.Sessions.GetEmptySession(Today, sNewDescriptionBase & " " & iNewCount)
    '    Dim oSessionNode As TreeNode = tvSessions.Nodes.Add(oSession.ID, oSession.FormattedID)
    '    Dim oCI As cSessionEditPlaceHolder = New cSessionEditPlaceHolder
    '    oCI.Date = oSession.Date
    '    oCI.Description = oSession.Description
    '    oCI.Team = oSession.Team
    '    oCI.Club = oSession.Club
    '    oCI.Designer = oSession.Designer
    '    oCI.DistanceType = oSession.DistanceType
    '    oCI.BearingType = oSession.BearingType
    '    oCI.BearingDirection = oSession.BearingDirection
    '    oCI.InclinationType = oSession.InclinationType
    '    oCI.InclinationDirection = oSession.InclinationDirection
    '    oCI.DepthType = oSession.DepthType

    '    oCI.Grade = oSession.Grade

    '    oCI.NordType = oSession.NordType
    '    oCI.SideMeasuresType = oSession.SideMeasuresType
    '    oCI.SideMeasuresReferTo = oSession.SideMeasuresReferTo

    '    oCI.Source = oSession
    '    oCI.Created = True
    '    oSessionNode.Tag = oCI
    '    oSessionNode.SelectedImageKey = "session"
    '    oSessionNode.ImageKey = "session"

    '    tvSessions.SelectedNode = oSessionNode
    '    Call oSessionNode.EnsureVisible()
    'End Sub

    'Private Sub btnSessionsDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim oNode As TreeNode = tvSessions.SelectedNode
    '        If Not oNode Is Nothing Then
    '            Select Case oNode.Tag.type
    '                Case "session"
    '                    Dim oCI As cSessionEditPlaceHolder = oNode.Tag
    '                    If oSurvey.Properties.Sessions.Contains(oCI.Source) Then
    '                        oNode.ForeColor = SystemColors.InactiveCaptionText
    '                        oNode.SelectedImageKey = "deleted"
    '                        oNode.ImageKey = "deleted"
    '                        oCI.Deleted = True

    '                        tvSessions.SelectedNode = Nothing
    '                        tvSessions.SelectedNode = oNode
    '                    Else
    '                        Call tvSessions.Nodes.Remove(oNode)
    '                    End If
    '            End Select
    '            If tvSessions.Nodes.Count = 0 Then
    '                Call tvSessions_AfterSelect(Nothing, Nothing)
    '            End If
    '        End If
    '    Catch
    '    End Try
    'End Sub

    Private Sub txtSessionDescription_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSessionDescription.Validated
        Try
            Dim sDescription As String = txtSessionDescription.Text
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            oCI.Description = sDescription
            tvSessions.RefreshFocusedObject
        Catch
        End Try
    End Sub

    Private Sub txtSessionDescription_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSessionDescription.Validating
        Dim sNewDescription As String = txtSessionDescription.Text.Trim
        If sNewDescription = "" Then
            e.Cancel = True
        Else
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session"
                    Dim sNewID As String = Strings.Format(oCI.Date, "yyyyMMdd") & "_" & sNewDescription.Replace(" ", "_").ToLower
                    If sNewID <> oCI.ID Then
                        e.Cancel = DirectCast(tvSessions.DataSource, cSessionsEditBindingList).ContainsID(sNewID)
                    End If
            End Select
        End If
    End Sub

    Private Sub txtSessionClub_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSessionClub.Validated
        Try
            Dim sClub As String = txtSessionClub.Text
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session"
                    oCI.Club = sClub
            End Select
        Catch
        End Try
    End Sub

    Private Sub txtSessionTeam_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSessionTeam.Validated
        Try
            Dim sTeam As String = txtSessionTeam.Text
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session"
                    oCI.Team = sTeam
            End Select
        Catch
        End Try
    End Sub

    Private Sub txtSessionDesigner_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSessionDesigner.Validated
        Try
            Dim sDesigner As String = txtSessionDesigner.Text
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session"
                    oCI.Designer = sDesigner
            End Select
        Catch
        End Try
    End Sub

    Private Sub cboSessionDistanceType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSessionDistanceType.Validated
        Try
            Dim iDistanceType As cSegment.DistanceTypeEnum = cboSessionDistanceType.SelectedIndex
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session", "defaultsession"
                    oCI.DistanceType = iDistanceType
            End Select
        Catch
        End Try
    End Sub

    Private Sub cboSessionInclinationType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSessionInclinationType.Validated
        Try
            Dim iInclinationType As cSegment.DistanceTypeEnum = cboSessionInclinationType.SelectedIndex
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session", "defaultsession"
                    oCI.InclinationType = iInclinationType
            End Select
        Catch
        End Try
    End Sub

    Private Sub cboSessionDepthType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSessionDepthType.Validated
        Try
            Dim iDepthType As cSegment.DistanceTypeEnum = cboSessionDepthType.SelectedIndex
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session", "defaultsession"
                    oCI.DepthType = iDepthType
            End Select
        Catch
        End Try
    End Sub

    Private Sub cboSessionNordType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSessionNordType.Validated
        Try
            Dim iNordType As cSegment.DistanceTypeEnum = cboSessionNordType.SelectedIndex
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session", "defaultsession"
                    oCI.NordType = iNordType
            End Select
        Catch
        End Try
    End Sub

    Private Sub cboSessionSideMeasureType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSessionSideMeasuresType.Validated
        Try
            Dim iSideMeasuresType As cSegment.SideMeasuresTypeEnum = cboSessionSideMeasuresType.SelectedIndex
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session", "defaultsession"
                    oCI.SideMeasuresType = iSideMeasuresType
            End Select
        Catch
        End Try
    End Sub

    Private Sub cboSessionBearingType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSessionBearingType.Validated
        Try
            Dim iBearingType As cSegment.DistanceTypeEnum = cboSessionBearingType.SelectedIndex
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session", "defaultsession"
                    oCI.BearingType = iBearingType
            End Select
        Catch
        End Try
    End Sub

    Private Sub txtSessionDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSessionDate.Validated
        Try
            Dim dDate As Date = txtSessionDate.EditValue
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            oCI.Date = dDate
            tvSessions.RefreshFocusedObject
        Catch
        End Try
    End Sub

    'Private Sub cboNordType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim bEnabled As Boolean = (cboNordType.SelectedIndex = 0) And oSurvey.Properties.CalculateVersion >= 2 'And Not chkGPSEnabled.Checked
    '    chkDecMag.Enabled = bEnabled
    '    txtDecMag.Enabled = bEnabled And chkDecMag.Checked
    'End Sub

    Private Sub cboSessionNordType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSessionNordType.SelectedIndexChanged
        Dim bEnabled As Boolean = (cboSessionNordType.SelectedIndex = 0) And ((Not chkGPSEnabled.Checked) Or (chkGPSEnabled.Checked And chkGPSAllowManualDeclinations.Checked))
        chkSessionDecMag.Enabled = bEnabled
        txtSessionDecMag.Enabled = bEnabled And chkSessionDecMag.Checked

        chkGlobalDecMag.Enabled = bEnabled
        txtGlobalDecMag.Enabled = bEnabled And chkGlobalDecMag.Checked
    End Sub

    Private Sub cmdPlotPenColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlotPenColor.Click
        Using oCD As ColorDialog = New ColorDialog
            With oCD
                .FullOpen = True
                .AnyColor = True
                .Color = picPlotPenColor.BackColor
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    picPlotPenColor.BackColor = .Color
                End If
            End With
        End Using
    End Sub

    Private Sub cmdPlotTextColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlotTextColor.Click
        Using oCD As ColorDialog = New ColorDialog
            With oCD
                .FullOpen = True
                .AnyColor = True
                .Color = picPlotTextColor.BackColor
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    picPlotTextColor.BackColor = .Color
                End If
            End With
        End Using
    End Sub

    Private Sub frmProperties_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        For Each oMenuItem As ToolStripItem In mnuInfoBoxTags.Items
            If Not TypeOf oMenuItem Is ToolStripSeparator Then
                AddHandler oMenuItem.Click, AddressOf mnuInfoBoxTags_Click
            End If
        Next

        For Each oMenuItem As ToolStripItem In mnuTrigPointTags.Items
            If Not TypeOf oMenuItem Is ToolStripSeparator Then
                AddHandler oMenuItem.Click, AddressOf mnuTrigpointTags_Click
            End If
        Next

        For Each oMenuItem As ToolStripItem In mnuSpecialTrigPointTags.Items
            If Not TypeOf oMenuItem Is ToolStripSeparator Then
                AddHandler oMenuItem.Click, AddressOf mnuSpecialTrigpointTags_Click
            End If
        Next

        For Each oMenuItem As ToolStripItem In mnuItemNamePatternTags.Items
            If Not TypeOf oMenuItem Is ToolStripSeparator Then
                AddHandler oMenuItem.Click, AddressOf mnuItemNamePatternTags_Click
            End If
        Next

        chkCaveInfoLocked.Visible = bIsInDebug
    End Sub

    Private Sub cmdPlotTextFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlotTextFont.Click
        Using oFD As frmFontDialog = New frmFontDialog(CType(txtPlotTextFont.Tag, cIFont))
            With oFD
                If .ShowDialog = vbOK Then
                    txtPlotTextFont.Tag = .CurrentFont
                    txtPlotTextFont.Text = .CurrentFont.ToString
                End If
            End With
        End Using
    End Sub

    Private Sub cmdDesignTextFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDesignTextFont.Click
        Using oFD As frmFontDialog = New frmFontDialog(CType(txtDesignTextFont.Tag, cIFont))
            With oFD
                If .ShowDialog = vbOK Then
                    txtDesignTextFont.Tag = .CurrentFont
                    txtDesignTextFont.Text = .CurrentFont.ToString
                End If
            End With
        End Using
    End Sub

    Private Sub cmdCaveInfoSegments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub chkGPSSendToTherion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGPSSendToTherion.CheckedChanged
        'Dim bEnabled As Boolean = Not chkGPSSendToTherion.Checked
        'chkGPSRefPointOnOrigin.Enabled = bEnabled
        'cboGPSCustomRefPoint.Enabled = bEnabled
        'lblGPSCustomRefPoint.Enabled = bEnabled
    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Call pSave()
        RaiseEvent OnApply(Me)
    End Sub

    'Private Sub chkDecMag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim bEnabled As Boolean = (cboNordType.SelectedIndex = 0)
    '    txtDecMag.Enabled = bEnabled And chkDecMag.Checked
    'End Sub

    Private Sub chkSessionDecMag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSessionDecMag.CheckedChanged
        Dim bEnabled As Boolean = ((cboSessionNordType.SelectedIndex = 0) And (Not chkGPSEnabled.Checked)) Or (chkGPSEnabled.Checked And chkGPSAllowManualDeclinations.Checked)
        txtSessionDecMag.Enabled = bEnabled And chkSessionDecMag.Checked
    End Sub

    Private Sub txtSessionDecMag_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSessionDecMag.Validated
        Try
            Dim sDeclination As Single = txtSessionDecMag.Text
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session", "defaultsession"
                    oCI.Declination = sDeclination
            End Select
        Catch
        End Try
    End Sub

    Private Sub chkSessionDecMag_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSessionDecMag.Validated
        Try
            Dim bdeclinationenabled As Boolean = chkSessionDecMag.Checked
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session", "defaultsession"
                    oCI.declinationenabled = bdeclinationenabled
            End Select
        Catch
        End Try
    End Sub

    Private Sub txtSessionNote_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim sNote As String = txtSessionNote.Text
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session"
                    oCI.Note = sNote
            End Select
        Catch
        End Try
    End Sub

    Private Sub cboSessionSideMeasuresReferTo_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSessionSideMeasuresReferTo.Validated
        Try
            Dim iSideMeasuresreferto As cSegment.SideMeasuresReferToEnum = cboSessionSideMeasuresReferTo.SelectedIndex
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session", "defaultsession"
                    oCI.SideMeasuresReferTo = iSideMeasuresreferto
            End Select
        Catch
        End Try
    End Sub

    Private Sub cmdNewID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewID.Click
        If cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("properties.warning1"), MsgBoxStyle.YesNo Or MsgBoxStyle.Critical, GetLocalizedString("properties.warningtitle")) = MsgBoxResult.Yes Then
            Call oSurvey.NewID()
            txtID.Text = oSurvey.ID
        End If
    End Sub

    Private Sub cboDesignWarpingMode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDesignWarpingMode.SelectedIndexChanged
        Call pOriginsEnabled()
        Select Case DirectCast(cboDesignWarpingMode.SelectedIndex, cSurvey.cSurvey.DesignWarpingModeEnum)
            Case cSurvey.cSurvey.DesignWarpingModeEnum.None
                lblDesignWarpingModeEnabledIn.Enabled = False
                chkPlanWarpingEnabled.Enabled = False
                chkProfileWarpingEnabled.Enabled = False
                chkShowWarpingDetails.Enabled = False
                optWarpingActive.Enabled = False
                optWarpingPaused.Enabled = False
            Case cSurvey.cSurvey.DesignWarpingModeEnum.Default
                lblDesignWarpingModeEnabledIn.Enabled = True
                chkPlanWarpingEnabled.Enabled = True
                chkProfileWarpingEnabled.Enabled = True
                chkShowWarpingDetails.Enabled = True
                optWarpingActive.Enabled = True
                optWarpingPaused.Enabled = True
        End Select
    End Sub

    Private Sub cmdChangeInversionModeAndSetDirections_Click(sender As System.Object, e As System.EventArgs) Handles cmdChangeInversionModeAndSetDirections.Click
        If cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("properties.warning2"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, GetLocalizedString("properties.warningtitle")) = MsgBoxResult.Yes Then
            Call cmdApply.PerformClick()
            Call oSurvey.Properties.UpgradeInversionMode()
            cboInversionMode.SelectedIndex = cSurvey.cSurvey.InversioneModeEnum.Absolute
        End If
    End Sub

    Private Sub cboInversionMode_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboInversionMode.SelectedIndexChanged
        Select Case cboInversionMode.SelectedIndex
            Case cSurvey.cSurvey.InversioneModeEnum.Absolute
                cmdChangeInversionModeAndSetDirections.Enabled = False
            Case cSurvey.cSurvey.InversioneModeEnum.Relative
                cmdChangeInversionModeAndSetDirections.Enabled = True
        End Select
    End Sub

    Private Sub cmdTrigPointStructureTagAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdTrigPointStructureTagAdd.Click
        Call mnuTrigPointTags.Show(Cursor.Position)
    End Sub

    Private Sub cmdSpecialTrigPointStructureTagAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdSpecialTrigPointStructureTagAdd.Click
        Call mnuSpecialTrigPointTags.Show(Cursor.Position)
    End Sub

    Private Sub cmdPlotTranslationLinePenColor_Click(sender As System.Object, e As System.EventArgs) Handles cmdPlotTranslationLinePenColor.Click
        Using oCD As ColorDialog = New ColorDialog
            With oCD
                .FullOpen = True
                .AnyColor = True
                .Color = picPlotTranslationLinePenColor.BackColor
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    picPlotTranslationLinePenColor.BackColor = .Color
                End If
            End With
        End Using
    End Sub

    Private Sub chkGPSEnabled_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkGPSEnabled.CheckedChanged
        Dim bEnabled As Boolean = chkGPSEnabled.Checked
        pnlGPS.Enabled = bEnabled

        lblNordCorrection.Enabled = Not bEnabled
        cboNordCorrection.Enabled = Not bEnabled

        Call cboSessionNordType_SelectedIndexChanged(Nothing, Nothing)

        lblNordCorrectionWarning.Visible = bEnabled

        pnlSurfaceProfile.Enabled = bEnabled AndAlso cbosurfaceprofileelevation.Count > 0
    End Sub

    Private Sub cboSessionGrade_Validated(sender As Object, e As System.EventArgs) Handles cboSessionGrade.Validated
        Try
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session", "defaultsession"
                    If cboSessionGrade.SelectedIndex = 0 Then
                        oCI.Grade = ""
                    Else
                        oCI.Grade = oSurvey.Grades(cboSessionGrade.SelectedIndex - 1).ID
                    End If
            End Select
        Catch
        End Try
    End Sub

    Private Sub btnCaveInfoSegmentsRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnCaveInfoSegmentsRefresh.Click
        Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetFocusedObject
        If Not oItem Is Nothing Then
            Call lvCaveInfoSegments.Rebind(oSurvey, oSurvey.Segments.GetCaveSegments(oItem.GetSource).ToSegments, New cSegmentsGrid.cSegmentGridParameters(True, False, False, True))
            Dim bEnabled As Boolean = lvCaveInfoSegments.Count > 0
            lvCaveInfoSegments.Enabled = bEnabled
            btnCaveInfoSelectSegment.Enabled = bEnabled
        End If
        'Dim oSegments As cSegmentCollection = Nothing
        'Call lvCaveInfoSegments.Items.Clear()
        'If Not tvCaveInfos.SelectedNode Is Nothing Then
        '    Select Case tvCaveInfos.SelectedNode.Tag.type
        '        Case "cave"
        '            Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
        '            oSegments = oSurvey.Segments.GetCaveSegments(oCI.Source)
        '        Case "branch"
        '            Dim oCIB As cCaveInfoBranchPlaceHolder = tvCaveInfos.SelectedNode.Tag
        '            oSegments = oSurvey.Segments.GetCaveSegments(oCIB.Source)
        '    End Select
        '    If Not oSegments Is Nothing Then
        '        For Each oSegment As cSegment In oSegments
        '            Dim oItem As ListViewItem = lvCaveInfoSegments.Items.Add(oSegment.ToString)
        '            oItem.Tag = oSegment
        '        Next
        '        Dim bEnabled As Boolean = lvCaveInfoSegments.Items.Count > 0
        '        btnCaveInfoSelectSegment.Enabled = bEnabled
        '        If bEnabled Then
        '            lvCaveInfoSegments.Items(0).Selected = True
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub btnCaveInfoSelectSegment_Click(sender As System.Object, e As System.EventArgs) Handles btnCaveInfoSelectSegment.Click
        If lvCaveInfoSegments.SelectedItem IsNot Nothing Then
            Dim oSegment As cSegment = lvCaveInfoSegments.SelectedItem
            RaiseEvent OnSegmentSelect(Me, oSegment)
        End If
    End Sub

    Private Sub txtCaveInfoDescription_Validated(sender As Object, e As System.EventArgs) Handles txtCaveInfoDescription.Validated
        Try
            Dim sDescription As String = txtCaveInfoDescription.Text
            Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetFocusedObject
            oItem.Description = sDescription
        Catch
        End Try
    End Sub

    Private Sub chkSessionBearingDirection_CheckedChanged(sender As Object, e As EventArgs) Handles chkSessionBearingDirection.CheckedChanged
        Try
            Dim iBearingDirection As cSegment.MeasureDirectionEnum = If(chkSessionBearingDirection.Checked, cSegment.MeasureDirectionEnum.Inverted, cSegment.MeasureDirectionEnum.Direct)
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session", "defaultsession"
                    oCI.BearingDirection = iBearingDirection
            End Select
        Catch
        End Try
    End Sub

    Private Sub chkSessionInclinationDirection_CheckedChanged(sender As Object, e As EventArgs) Handles chkSessionInclinationDirection.CheckedChanged
        Try
            Dim iInclinationDirection As cSegment.MeasureDirectionEnum = If(chkSessionInclinationDirection.Checked, cSegment.MeasureDirectionEnum.Inverted, cSegment.MeasureDirectionEnum.Direct)
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session", "defaultsession"
                    oCI.InclinationDirection = iInclinationDirection
            End Select
        Catch
        End Try
    End Sub

    Private Sub cboCoordinateGeo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCoordinateGeo.SelectedIndexChanged
        Dim bWGS84 As Boolean = cboCoordinateGeo.SelectedIndex = 0
        cboCoordinateFormat.Visible = bWGS84
        lblCoordinateFormat.Visible = bWGS84

        Dim bUTM As Boolean = Not bWGS84
        cboCoordinateZone.Visible = bUTM
        lblCoordinateZone.Visible = bUTM
        lblCoordinateBand.Visible = bUTM
        cboCoordinateBand.Visible = bUTM
    End Sub

    'Private Sub cboDataFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDataFormat.SelectedIndexChanged
    '    Select Case cboDataFormat.SelectedIndex
    '        Case 0  'normali
    '            pnlBearing.Enabled = True
    '            pnlBearing.Visible = True
    '            pnlInclination.Enabled = True
    '            pnlInclination.Visible = True
    '            pnlDepth.Enabled = False
    '            pnlDepth.Visible = False
    '            pnlNorth.Enabled = True
    '            lblDistanceType.Text = modMain.GetLocalizedString("main.textpart34") & ":"
    '        Case 1  'cartesiane
    '            pnlBearing.Enabled = False
    '            pnlBearing.Visible = False
    '            pnlInclination.Enabled = False
    '            pnlInclination.Visible = False
    '            pnlDepth.Enabled = False
    '            pnlDepth.Visible = False
    '            pnlNorth.Enabled = False
    '            lblDistanceType.Text = modMain.GetLocalizedString("main.textpart70") & ":"
    '        Case 2  'diving
    '            pnlBearing.Enabled = True
    '            pnlBearing.Visible = True
    '            pnlInclination.Enabled = False
    '            pnlInclination.Visible = False
    '            pnlDepth.Enabled = True
    '            pnlDepth.Visible = True
    '            pnlNorth.Enabled = True
    '            lblDistanceType.Text = modMain.GetLocalizedString("main.textpart69") & ":"
    '    End Select
    'End Sub

    Private Sub cboSessionDataFormat_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSessionDataFormat.SelectedIndexChanged
        Select Case cboSessionDataFormat.SelectedIndex
            Case 0  'default
                pnlSessionBearing.Enabled = True
                pnlSessionBearing.Visible = True
                pnlSessionInclination.Enabled = True
                pnlSessionInclination.Visible = True
                pnlSessionDepth.Enabled = False
                pnlSessionDepth.Visible = False
                pnlSessionNorth.Enabled = True
                lblSessionDistanceType.Text = modMain.GetLocalizedString("main.textpart34") & ":"
                chkSessionInclinationDirection.Parent = pnlSessionInclination
                chkSessionInclinationDirection.Location = New Point(cboSessionInclinationType.Location.X + cboSessionInclinationType.Width + 8 * Me.CurrentAutoScaleDimensions.Height / 96.0F, chkSessionInclinationDirection.Location.Y)
            Case 1  'xyz
                pnlSessionBearing.Enabled = False
                pnlSessionBearing.Visible = False
                pnlSessionInclination.Enabled = False
                pnlSessionInclination.Visible = False
                pnlSessionDepth.Enabled = False
                pnlSessionDepth.Visible = False
                pnlSessionNorth.Enabled = False
                lblSessionDistanceType.Text = modMain.GetLocalizedString("main.textpart70") & ":"
            Case 2  'diving
                pnlSessionBearing.Enabled = True
                pnlSessionBearing.Visible = True
                pnlSessionInclination.Enabled = False
                pnlSessionInclination.Visible = False
                pnlSessionDepth.Enabled = True
                pnlSessionDepth.Visible = True
                pnlSessionNorth.Enabled = True
                lblSessionDistanceType.Text = modMain.GetLocalizedString("main.textpart69") & ":"
                chkSessionInclinationDirection.Parent = pnlSessionDepth
                chkSessionInclinationDirection.Location = New Point(cboSessionDepthType.Location.X + cboSessionDepthType.Width + 8 * Me.CurrentAutoScaleDimensions.Height / 96.0F, chkSessionInclinationDirection.Location.Y)
        End Select
    End Sub

    Private Sub cboSessionDataFormat_Validated(sender As Object, e As System.EventArgs) Handles cboSessionDataFormat.Validated
        Try
            Dim iDataFormat As cSegment.DataFormatEnum = cboSessionDataFormat.SelectedIndex
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session", "defaultsession"
                    oCI.DataFormat = iDataFormat
            End Select
        Catch
        End Try
    End Sub

    Private Sub chkGlobalDecMag_CheckedChanged(sender As Object, e As EventArgs) Handles chkGlobalDecMag.CheckedChanged
        txtGlobalDecMag.Enabled = chkGlobalDecMag.Checked
    End Sub

    Private Sub chkGlobalVthreshold_CheckedChanged(sender As Object, e As EventArgs) Handles chkGlobalVthreshold.CheckedChanged
        txtGlobalVthreshold.Enabled = chkGlobalVthreshold.Checked
    End Sub

    'Private Sub chkVthreshold_CheckedChanged(sender As Object, e As EventArgs)
    '    txtVthreshold.Enabled = chkVthreshold.Checked
    'End Sub

    Private Sub chkSessionVthreshold_CheckedChanged(sender As Object, e As EventArgs) Handles chkSessionVthreshold.CheckedChanged
        txtSessionVthreshold.Enabled = chkSessionVthreshold.Checked
    End Sub

    Private Sub cmdPlotNoteTextFont_Click(sender As Object, e As EventArgs) Handles cmdPlotNoteTextFont.Click
        Using oFD As frmFontDialog = New frmFontDialog(CType(txtPlotNoteTextFont.Tag, cIFont))
            With oFD
                If .ShowDialog = vbOK Then
                    txtPlotNoteTextFont.Tag = .CurrentFont
                    txtPlotNoteTextFont.Text = .CurrentFont.ToString
                End If
            End With
        End Using
    End Sub

    'Private Sub cmdPlotNoteTextColor_Click(sender As Object, e As EventArgs)
    '    Using oCD As ColorDialog = New ColorDialog
    '        With oCD
    '            .FullOpen = True
    '            .AnyColor = True
    '            .Color = picPlotNoteTextColor.BackColor
    '            If .ShowDialog = Windows.Forms.DialogResult.OK Then
    '                picPlotNoteTextColor.BackColor = .Color
    '            End If
    '        End With
    '    End Using
    'End Sub

    Private Sub chkSessionVthreshold_Validated(sender As Object, e As EventArgs) Handles chkSessionVthreshold.Validated
        Try
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session", "defaultsession"
                    oCI.VThresholdEnabled = chkSessionVthreshold.Checked
            End Select
        Catch
        End Try
    End Sub

    Private Sub txtSessionVthreshold_Validated(sender As Object, e As EventArgs) Handles txtSessionVthreshold.Validated
        Try
            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
            Select Case oCI.Type
                Case "session", "defaultsession"
                    oCI.VThreshold = txtSessionVthreshold.Value
            End Select
        Catch
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub cbo3DModelMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo3DModelMode.SelectedIndexChanged
        Dim bEnabled As Boolean = cbo3DModelMode.SelectedIndex > 0
        lbl3DNormalizationFactor.Enabled = bEnabled
        txt3DNormalizationFactor.Enabled = bEnabled
        lbl3DOversamplingFactor.Enabled = bEnabled
        txt3DOversamplingFactor.Enabled = bEnabled

        chk3DLochShowSplay.Enabled = Not bEnabled
    End Sub

    Private Sub cboCaveInfoSurfaceProfileShow_Validated(sender As Object, e As EventArgs) Handles cboCaveInfoSurfaceProfileShow.Validated
        Try
            Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetFocusedObject
            oItem.SurfaceProfileShow = cboCaveInfoSurfaceProfileShow.SelectedIndex
        Catch
        End Try
    End Sub

    Private Sub chksurfaceprofile_CheckedChanged(sender As Object, e As EventArgs) Handles chksurfaceprofile.CheckedChanged
        Dim bEnabled As Boolean = chksurfaceprofile.Checked
        pnlsurfaceprofileelevation.Enabled = bEnabled

        lblCaveInfoSurfaceProfileShow.Enabled = bEnabled
        cboCaveInfoSurfaceProfileShow.Enabled = bEnabled
    End Sub

    ''Private Sub btnDeleteHighlight_Click(sender As Object, e As EventArgs) Handles btnDeleteHighlight.Click
    ''    Try
    ''        Dim oNode As TreeNode = tvHighlights.SelectedNode
    ''        If Not oNode Is Nothing Then
    ''            Select Case oNode.Tag.type
    ''                Case "highlight"
    ''                    Dim oCI As cHighlightPlaceholder = oNode.Tag
    ''                    If oSurvey.Properties.HighlightsDetails.Contains(oCI.Source) Then
    ''                        oNode.ForeColor = SystemColors.InactiveCaptionText
    ''                        oNode.SelectedImageKey = "deleted"
    ''                        oNode.ImageKey = "deleted"
    ''                        oCI.Deleted = True

    ''                        tvHighlights.SelectedNode = Nothing
    ''                        tvHighlights.SelectedNode = oNode
    ''                    Else
    ''                        Call tvHighlights.Nodes.Remove(oNode)
    ''                    End If
    ''            End Select
    ''            If tvHighlights.Nodes.Count = 0 Then
    ''                Call tvHighlights_AfterSelect(Nothing, Nothing)
    ''            End If
    ''        End If
    ''    Catch
    ''    End Try
    ''End Sub

    Private Sub txtHighlightName_Validated(sender As Object, e As EventArgs) Handles txtHighlightName.Validated
        Try
            'Dim sName As String = txtHighlightName.Text
            'If tvHighlights.SelectedNode.Name <> sName Then
            '    tvHighlights.SelectedNode.Name = sName
            '    tvHighlights.SelectedNode.Text = sName
            '    Select Case tvHighlights.SelectedNode.Tag.type
            '        Case "hightlight"
            Dim oCI As cHighlightPlaceholder = tvHighlights.GetFocusedObject
            oCI.Name = txtHighlightName.Text
            '    End Select
            'End If
        Catch
        End Try
    End Sub

    'Private Sub cmdHighlightColorChange_Click(sender As Object, e As EventArgs)
    '    Dim oCD As ColorDialog = New ColorDialog
    '    With oCD
    '        .FullOpen = True
    '        .AnyColor = True
    '        .Color = picHighlightColor.BackColor
    '        If .ShowDialog = Windows.Forms.DialogResult.OK Then
    '            picHighlightColor.BackColor = .Color
    '            Try
    '                Select Case tvHighlights.SelectedNode.Tag.type
    '                    Case "highlight"
    '                        Dim oCI As cHighlightPlaceholder = tvHighlights.SelectedNode.Tag
    '                        oCI.Color = .Color
    '                End Select
    '            Catch
    '            End Try
    '        End If
    '    End With
    'End Sub

    Private Sub txtHighlightSize_Validated(sender As Object, e As EventArgs)
        Try
            Dim oCI As cHighlightPlaceholder = tvHighlights.GetFocusedObject
            oCI.Size = txtHighlightSize.Value
        Catch
        End Try
    End Sub

    Private Sub frmF_OnFormulaCodeRequest(Sender As frmScriptFormulaEditor, ByRef Args As frmScriptFormulaEditor.cFormulaCodeRequestEvent)
        Try
            Dim oCI As cHighlightPlaceholder = tvHighlights.GetFocusedObject
            Args.FullCode = cSurvey.Properties.cHighlightsDetail.GetScriptCode(Args.ScriptBag, oCI.ApplyTo)
        Catch
        End Try
    End Sub

    Private Sub cmdHighlightCondition_Click(sender As Object, e As EventArgs) Handles cmdHighlightCondition.Click
        Try
            Dim oCI As cHighlightPlaceholder = tvHighlights.GetFocusedObject
            Using frmF As frmScriptFormulaEditor = New frmScriptFormulaEditor(oSurvey, New cScriptBag(oCI.Condition, iFunctionLanguage))
                AddHandler frmF.OnFormulaCodeRequest, AddressOf frmF_OnFormulaCodeRequest
                If frmF.ShowDialog(Me) = DialogResult.OK Then
                    oCI.Condition = frmF.GetScriptBag.ToString
                    txtHighlightCondition.Text = oCI.Condition
                End If
            End Using
        Catch
        End Try
    End Sub

    Private Function pHighlightAdd(ApplyTo As Properties.cHighlightsDetail.ApplyToEnum) As cHighlightPlaceholder
        Call tvHighlights.Focus()
        Call tvHighlights.BeginUpdate()
        Dim oItem As cHighlightPlaceholder = DirectCast(tvHighlights.DataSource, cHighlightEditBindingList).Add(ApplyTo)
        Dim oNode As DevExpress.XtraTreeList.Nodes.TreeListNode = tvHighlights.GetNodeByDataRecord(oItem)
        tvHighlights.FocusedNode = oNode
        Call tvHighlights.EndUpdate()
        Return oItem
    End Function

    Private Sub cboCalculateVersion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCalculateVersion.SelectedIndexChanged
        cmdUpdateCalculateVersion.Enabled = cboCalculateVersion.SelectedIndex < cboCalculateVersion.Items.Count - 1
    End Sub

    Private Sub cmdUpdateCalculateVersion_Click(sender As Object, e As EventArgs) Handles cmdUpdateCalculateVersion.Click
        If cSurvey.UIHelpers.Dialogs.Msgbox(modMain.GetLocalizedString("properties.warning3"), vbYesNo Or MsgBoxStyle.Critical, modMain.GetLocalizedString("properties.warningtitle")) = MsgBoxResult.Yes Then
            Call cmdApply.PerformClick()
            Call oSurvey.Properties.UpgradeCalculateVersion()
            cboCalculateVersion.SelectedIndex = oSurvey.Properties.CalculateVersion
        End If
    End Sub

    Private Sub btnSessionSegmentsRefresh_Click(sender As Object, e As EventArgs) Handles btnSessionSegmentsRefresh.Click
        Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
        If Not oCI Is Nothing AndAlso TypeOf oCI IsNot cDefaultSessionEditPlaceHolder Then
            Call lvSessionSegments.Rebind(oSurvey, oSurvey.Segments.GetSessionSegments(oCI.Source).Cast(Of cSegment).ToList, New cSegmentsGrid.cSegmentGridParameters(False, True, True, True))
            Dim bEnabled As Boolean = lvSessionSegments.Count > 0
            lvSessionSegments.Enabled = bEnabled
            btnCaveInfoSelectSegment.Enabled = bEnabled
        End If
    End Sub

    Private Sub btnSessionSelectSegment_Click(sender As Object, e As EventArgs) Handles btnSessionSelectSegment.Click
        If lvSessionSegments.SelectedItem IsNot Nothing Then
            Dim oSegment As cSegment = lvSessionSegments.SelectedItem
            RaiseEvent OnSegmentSelect(Me, oSegment)
        End If
    End Sub

    'Private Sub btnSessionCalibrationSegmentsRefresh_Click(sender As Object, e As EventArgs) Handles btnSessionCalibrationSegmentsRefresh.Click
    '    Call lvSessionSegments.Items.Clear()
    '    Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
    '    If Not oCI Is Nothing AndAlso TypeOf oCI IsNot cDefaultSessionEditPlaceHolder Then
    '        Dim oSegments As cSegmentCollection = oSurvey.Segments.GetSessionSegments(oCI.Source, cISegmentCollection.SessionSegmentsFlagEnum.CalibrationShots)
    '        For Each oSegment As cSegment In oSegments
    '            Dim oItem As ListViewItem = lvSessionCalibrationSegments.Items.Add(oSegment.ToString)
    '            oItem.Tag = oSegment
    '        Next
    '        Dim bEnabled As Boolean = lvSessionCalibrationSegments.Items.Count > 0
    '        btnCaveInfoSelectSegment.Enabled = bEnabled
    '        If bEnabled Then
    '            lvSessionCalibrationSegments.Items(0).Selected = True
    '        End If
    '    End If
    'End Sub

    Private Sub chkCaveInfoLocked_Validated(sender As Object, e As EventArgs) Handles chkCaveInfoLocked.Validated
        Try
            Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetFocusedObject
            oItem.Locked = chkCaveInfoLocked.Checked
        Catch
        End Try
    End Sub

    Private Sub cboCaveInfoExtendStart_Validated(sender As Object, e As EventArgs) Handles cboCaveInfoExtendStart.Validated
        Try
            If chkCaveInfoExtendStart.Checked Then
                Dim sExtendStart As String = cboCaveInfoExtendStart.Text
                Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetFocusedObject
                oItem.ExtendStart = sExtendStart
                If Not sender Is chkCaveInfoExtendStart Then chkCaveInfoExtendStart.Checked = sExtendStart <> ""
            Else
                Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetFocusedObject
                oItem.ExtendStart = ""
            End If
        Catch
        End Try
    End Sub

    Private Function pGetNewCaveInfoPriority(Nodes As TreeNodeCollection, MaxPriority As Integer) As Integer
        Dim iMaxPriority As Integer = MaxPriority
        For Each oNode As TreeNode In Nodes
            Select Case oNode.Tag.type
                Case "cave"
                    Dim oCI As cCaveInfoPlaceHolder = oNode.Tag
                    If oCI.Priority.HasValue Then
                        If iMaxPriority < oCI.Priority.Value Then
                            iMaxPriority = oCI.Priority.Value
                        End If
                    End If
                Case "branch"
                    Dim oCIB As cCaveInfoBranchPlaceHolder = oNode.Tag
                    If oCIB.Priority.HasValue Then
                        If iMaxPriority < oCIB.Priority.Value Then
                            iMaxPriority = oCIB.Priority.Value
                        End If
                    End If
            End Select
            iMaxPriority = pGetNewCaveInfoPriority(oNode.Nodes, iMaxPriority)
        Next
        Return iMaxPriority
    End Function

    Private Function pGetCaveInfoPriority(Nodes As TreeNodeCollection, Optional List As List(Of Integer) = Nothing) As List(Of Integer)
        Dim oList As List(Of Integer) = If(IsNothing(List), New List(Of Integer), List)
        For Each oNode As TreeNode In Nodes
            Select Case oNode.Tag.type
                Case "cave"
                    Dim oCI As cCaveInfoPlaceHolder = oNode.Tag
                    If oCI.Priority.HasValue AndAlso Not oList.Contains(oCI.Priority.Value) Then
                        Call oList.Add(oCI.Priority.Value)
                    End If
                Case "branch"
                    Dim oCIB As cCaveInfoBranchPlaceHolder = oNode.Tag
                    If oCIB.Priority.HasValue AndAlso Not oList.Contains(oCIB.Priority.Value) Then
                        Call oList.Add(oCIB.Priority.Value)
                    End If
            End Select
            Call pGetCaveInfoPriority(oNode.Nodes, oList)
        Next
        Return oList
    End Function

    'Private Sub cmdCaveInfoPriorityNew_Click(sender As Object, e As EventArgs)
    '    Dim iMaxPriority As Integer = pGetNewCaveInfoPriority(tvCaveInfos.Nodes, 0)
    '    Try
    '        cboCaveInfoPriority.Text = iMaxPriority + 1 'integer.minvalue? very horrible...
    '        Call cboCaveInfoPriority.Focus()
    '    Catch ex As Exception
    '        cboCaveInfoPriority.Text = iMaxPriority
    '        Call cboCaveInfoPriority.Focus()
    '    End Try
    'End Sub

    'Private Sub cboCaveInfoPriority_DropDown(sender As Object, e As EventArgs)
    '    Dim oList As List(Of Integer) = pGetCaveInfoPriority(tvCaveInfos.Nodes)
    '    Call oList.Sort()
    '    Call cboCaveInfoPriority.Items.Clear()
    '    Call cboCaveInfoPriority.Items.AddRange(oList.Cast(Of Object).ToArray)
    'End Sub

    'Private Sub cboCaveInfoPriority_Validated(sender As Object, e As EventArgs)
    '    Try
    '        Dim iPriority As Integer? = Nothing
    '        If cboCaveInfoPriority.Text.Trim <> "" Then
    '            iPriority = cboCaveInfoPriority.Text.Trim
    '        End If
    '        Select Case tvCaveInfos.SelectedNode.Tag.type
    '            Case "cave"
    '                Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
    '                oCI.Priority = iPriority
    '            Case "branch"
    '                Dim oCIB As cCaveInfoBranchPlaceHolder = tvCaveInfos.SelectedNode.Tag
    '                oCIB.Priority = iPriority
    '        End Select
    '    Catch
    '    End Try
    'End Sub

    'Private Sub cboCaveInfoPriority_Validating(sender As Object, e As CancelEventArgs)
    '    Dim sPriority As String = cboCaveInfoPriority.Text
    '    If sPriority.Trim <> "" Then
    '        Dim iPriority As Integer
    '        e.Cancel = Not Integer.TryParse(sPriority, iPriority)
    '    End If
    'End Sub

    Private Sub chkCaveInfoPriority_CheckedChanged(sender As Object, e As EventArgs) Handles chkCaveInfoPriority.CheckedChanged
        txtCaveInfoPriority.Enabled = chkCaveInfoPriority.Checked
        If Not txtCaveInfoPriority.Enabled Then
            txtCaveInfoPriority.Value = pGetPriority(tvCaveInfos.FocusedNode).GetValueOrDefault(0)
        End If
        Call txtCaveInfoPriority_Validated(chkCaveInfoPriority, EventArgs.Empty)
        pnlCaveInfoConnections.Enabled = chkCaveInfoExtendStart.Checked OrElse chkCaveInfoPriority.Checked
    End Sub

    Private Sub chkCaveInfoExtendStart_CheckedChanged(sender As Object, e As EventArgs) Handles chkCaveInfoExtendStart.CheckedChanged
        cboCaveInfoExtendStart.Enabled = chkCaveInfoExtendStart.Checked
        If cboCaveInfoExtendStart.Enabled Then
            cboCaveInfoExtendStart.Rebind(oSurvey, Nothing, False, False)
        Else
            cboCaveInfoExtendStart.FastRebind(oSurvey, "" & pGetExtendStart(tvCaveInfos.FocusedNode), False, False)
            'cboCaveInfoExtendStart.Text = "" & pGetExtendStart(tvCaveInfos.FocusedNode)
        End If
        Call cboCaveInfoExtendStart_Validated(chkCaveInfoExtendStart, EventArgs.Empty)
        pnlCaveInfoConnections.Enabled = chkCaveInfoExtendStart.Checked OrElse chkCaveInfoPriority.Checked
    End Sub

    Private Function pGetExtendStart(Node As DevExpress.XtraTreeList.Nodes.TreeListNode) As String
        Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetDataRecordByNode(Node)
        If oItem Is Nothing Then
            Return ""
        Else
            Select Case oItem.Type
                Case "cave"
                    Dim oCI As cCaveInfoPlaceHolder = oItem
                    If oCI.ExtendStart = "" Then
                        Return cboOrigin.Text
                    Else
                        Return oCI.ExtendStart
                    End If
                Case "branch"
                    Dim oCIB As cCaveInfoBranchPlaceHolder = oItem
                    If oCIB.ExtendStart = "" Then
                        Return pGetExtendStart(Node.ParentNode)
                    Else
                        Return oCIB.ExtendStart
                    End If
            End Select
        End If
    End Function

    Private Function pGetPriority(Node As DevExpress.XtraTreeList.Nodes.TreeListNode) As Integer?
        Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetDataRecordByNode(Node)
        If oItem Is Nothing Then
            Return Nothing
        Else
            Select Case oItem.Type
                Case "cave"
                    Dim oCI As cCaveInfoPlaceHolder = oItem
                    If oCI.Priority.HasValue Then
                        Return oCI.Priority
                    Else
                        Return Nothing
                    End If
                Case "branch"
                    Dim oCIB As cCaveInfoBranchPlaceHolder = oItem
                    If oCIB.Priority.HasValue Then
                        Return oCIB.Priority
                    Else
                        Return pGetPriority(Node.ParentNode)
                    End If
            End Select
        End If
    End Function

    Private Sub txtCaveInfoPriority_Validated(sender As Object, e As EventArgs) Handles txtCaveInfoPriority.Validated
        Try
            Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetFocusedObject
            If chkCaveInfoPriority.Checked Then
                Dim iPriority As Integer = txtCaveInfoPriority.Value
                oItem.Priority = iPriority
            Else
                oItem.Priority = Nothing
            End If
        Catch
        End Try
    End Sub

    Private Sub cboCaveInfoExtendStart_Popup(sender As Object, e As PopupEventArgs) Handles cboCaveInfoExtendStart.Popup
        Cursor = Cursors.WaitCursor
        Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetFocusedObject
        Select Case oItem.Type
            Case "cave"
                Dim oCI As cCaveInfoPlaceHolder = oItem
                'If e.Grid.Count <= 1 Then
                Call e.AddRange(oCI.Source.GetSegments.GetTrigpoints.GetStations(e.AllowSplay).ToList)
                'End If
                'Call cboCaveInfoExtendStart.Items.Clear()
                'Call cboCaveInfoExtendStart.Items.Add("")
                'Call cboCaveInfoExtendStart.Items.AddRange(oCI.Source.GetSegments.GetTrigpointsNames().Cast(Of Object).ToArray)
            Case "branch"
                Dim oCIB As cCaveInfoBranchPlaceHolder = oItem
                'If e.Grid.Count <= 1 Then
                Call e.AddRange(oCIB.Source.GetSegments.GetTrigpoints.GetStations(e.AllowSplay).ToList)
                'End If
                'Call cboCaveInfoExtendStart.Items.Clear()
                'Call cboCaveInfoExtendStart.Items.Add("")
                'Call cboCaveInfoExtendStart.Items.AddRange(oCIB.Source.GetSegments.GetTrigpointsNames().Cast(Of Object).ToArray)
        End Select
        Cursor = Cursors.Default
    End Sub

    Private Sub chkCaveInfoExtendStart_Validated(sender As Object, e As EventArgs) Handles chkCaveInfoExtendStart.Validated
        Dim sExtendStart As String = ""
        Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetFocusedObject
        Select Case oItem.Type
            Case "cave"
                Dim oCI As cCaveInfoPlaceHolder = oItem
                sExtendStart = oCI.ExtendStart
            Case "branch"
                Dim oCIB As cCaveInfoBranchPlaceHolder = oItem
                sExtendStart = oCIB.ExtendStart
        End Select
        tvCaveInfos.RefreshFocusedObject
    End Sub

    Private Sub cmdCaveInfoParentConnection_Click(sender As Object, e As EventArgs) Handles cmdCaveInfoParentConnection.Click
        Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetFocusedObject
        Select Case oItem.Type
            Case "cave"
                Dim oCI As cCaveInfoPlaceHolder = oItem
                Using frmT As frmConnectionDefBrowser = New frmConnectionDefBrowser(oSurvey, oCI.ParentConnection, True)
                    If frmT.ShowDialog() = DialogResult.OK Then
                        With oCI
                            .ParentConnection = frmT.SelectedItem
                            txtCaveInfoParentConnection.Text = If(IsNothing(.ParentConnection), "", .ParentConnection.ToString)
                            Dim bEditConnection As Boolean
                            If IsNothing(.ParentConnection) Then
                                .Connection = Nothing
                                txtCaveInfoConnection.Text = ""
                                bEditConnection = False
                            Else
                                If IsNothing(.Connection) Then
                                    bEditConnection = True
                                Else
                                    If .Connection.Station <> .ParentConnection.Station Then
                                        .Connection = Nothing
                                        txtCaveInfoConnection.Text = ""
                                        bEditConnection = True
                                    ElseIf .Connection = .ParentConnection Then
                                        .Connection = Nothing
                                        txtCaveInfoConnection.Text = ""
                                        bEditConnection = True
                                    End If
                                End If
                            End If
                            Dim bEnabled As Boolean = Not IsNothing(.ParentConnection)
                            txtCaveInfoConnection.Enabled = bEnabled
                            cmdCaveInfoConnection.Enabled = bEnabled
                            If bEnabled AndAlso bEditConnection Then Call cmdCaveInfoConnection.PerformClick()
                        End With
                    End If
                End Using
            Case "branch"
                Dim oCIB As cCaveInfoBranchPlaceHolder = oItem
                Using frmT As frmConnectionDefBrowser = New frmConnectionDefBrowser(oSurvey, oCIB.ParentConnection, True)
                    If frmT.ShowDialog() = DialogResult.OK Then
                        With oCIB
                            .ParentConnection = frmT.SelectedItem
                            txtCaveInfoParentConnection.Text = If(IsNothing(.ParentConnection), "", .ParentConnection.ToString)
                            Dim bEditConnection As Boolean
                            If IsNothing(.ParentConnection) Then
                                .Connection = Nothing
                                txtCaveInfoConnection.Text = ""
                                bEditConnection = False
                            Else
                                If IsNothing(.Connection) Then
                                    bEditConnection = True
                                Else
                                    If .Connection.Station <> .ParentConnection.Station Then
                                        .Connection = Nothing
                                        txtCaveInfoConnection.Text = ""
                                        bEditConnection = True
                                    ElseIf .Connection = .ParentConnection Then
                                        .Connection = Nothing
                                        txtCaveInfoConnection.Text = ""
                                        bEditConnection = True
                                    End If
                                End If
                            End If
                            Dim bEnabled As Boolean = Not IsNothing(.ParentConnection)
                            txtCaveInfoConnection.Enabled = bEnabled
                            cmdCaveInfoConnection.Enabled = bEnabled
                            If bEnabled AndAlso bEditConnection Then Call cmdCaveInfoConnection.PerformClick()
                        End With
                    End If
                End Using
        End Select
    End Sub

    Private Sub cmdCaveInfoConnection_Click(sender As Object, e As EventArgs) Handles cmdCaveInfoConnection.Click
        Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetFocusedObject
        Select Case oItem.Type
            Case "cave"
                Dim oCI As cCaveInfoPlaceHolder = oItem
                Using frmT As frmConnectionDefBrowser = New frmConnectionDefBrowser(oSurvey, oCI.Connection, True, oCI.ParentConnection.Station, Nothing, New List(Of cConnectionDef)({oCI.ParentConnection}))
                    If frmT.ShowDialog() = DialogResult.OK Then
                        With oCI
                            .Connection = frmT.SelectedItem
                            If IsNothing(.Connection) Then
                                .ParentConnection = Nothing
                                txtCaveInfoParentConnection.Text = ""
                                txtCaveInfoConnection.Text = ""
                                txtCaveInfoConnection.Enabled = False
                                cmdCaveInfoConnection.Enabled = False
                            Else
                                txtCaveInfoConnection.Text = .Connection.ToString
                            End If
                        End With
                    End If
                End Using
            Case "branch"
                Dim oCIB As cCaveInfoBranchPlaceHolder = oItem
                Using frmT As frmConnectionDefBrowser = New frmConnectionDefBrowser(oSurvey, oCIB.Connection, True, oCIB.ParentConnection.Station, Nothing, New List(Of cConnectionDef)({oCIB.ParentConnection}))
                    If frmT.ShowDialog() = DialogResult.OK Then
                        With oCIB
                            .Connection = frmT.SelectedItem
                            If IsNothing(.Connection) Then
                                .ParentConnection = Nothing
                                txtCaveInfoParentConnection.Text = ""
                                txtCaveInfoConnection.Text = ""
                                txtCaveInfoConnection.Enabled = False
                                cmdCaveInfoConnection.Enabled = False
                            Else
                                txtCaveInfoConnection.Text = .Connection.ToString
                            End If
                        End With
                    End If
                End Using
        End Select
    End Sub

    Private Sub cmdPlotSurfaceLinePenColor_Click(sender As Object, e As EventArgs) Handles cmdSurfacePenColor.Click
        Using oCD As ColorDialog = New ColorDialog
            With oCD
                .FullOpen = True
                .AnyColor = True
                .Color = picSurfacePenColor.BackColor
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    picSurfacePenColor.BackColor = .Color
                End If
            End With
        End Using
    End Sub

    Private Sub cmdPlotPointColor_Click(sender As Object, e As EventArgs) Handles cmdPlotPointColor.Click
        Using oCD As ColorDialog = New ColorDialog
            With oCD
                .FullOpen = True
                .AnyColor = True
                .Color = picPlotPointColor.BackColor
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    picPlotPointColor.BackColor = .Color
                End If
            End With
        End Using
    End Sub

    Private Sub cmdItemNamePatternAdd_Click(sender As Object, e As EventArgs) Handles cmdItemNamePatternAdd.Click
        Call mnuItemNamePatternTags.Show(Cursor.Position)
    End Sub

    Private Sub optWarpingActive_CheckedChanged(sender As Object, e As EventArgs) Handles optWarpingActive.CheckedChanged

    End Sub

    Private Sub cmdGPSCustomRefPointRefreshStations_Click(sender As Object, e As EventArgs) Handles cmdGPSCustomRefPointRefreshStations.Click
        Call pRefreshStations()
    End Sub

    Private Sub pRefreshStations()
        Call oSurvey.TrigPoints.Rebind()
    End Sub

    Private Sub cboGPSCustomRefPoint_EnabledChanged(sender As Object, e As EventArgs) Handles cboGPSCustomRefPoint.EnabledChanged
        cmdGPSCustomRefPointRefreshStations.Enabled = cboGPSCustomRefPoint.Enabled
    End Sub

    Private Sub cboOrigin_EnabledChanged(sender As Object, e As EventArgs)
        cmdOriginRefreshStations.Enabled = cboOrigin.Enabled
    End Sub

    Private Sub cboNordCorrection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNordCorrection.SelectedIndexChanged
        Call cboSessionNordType_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub chkGPSAllowManualDeclinations_CheckedChanged(sender As Object, e As EventArgs) Handles chkGPSAllowManualDeclinations.CheckedChanged
        Call cboSessionNordType_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    'Private Sub btnCaveInfoRemoveAllSubOrigins_Click(sender As Object, e As EventArgs)
    '    Call pCaveBranchRemoveSuborigin(tvCaveInfos.Nodes)
    'End Sub

    'Private Sub pCaveBranchRemoveSuborigin(Nodes As TreeNodeCollection)
    '    For Each oNode As TreeNode In Nodes
    '        If TypeOf oNode.Tag Is cCaveInfoPlaceHolder Then
    '            Dim oCI As cCaveInfoPlaceHolder = oNode.Tag
    '            If oCI.ExtendStart <> "" Then
    '                oCI.ExtendStart = ""
    '            End If
    '        Else
    '            Dim oCI As cCaveInfoBranchPlaceHolder = oNode.Tag
    '            If oCI.ExtendStart <> "" Then
    '                oCI.ExtendStart = ""
    '            End If
    '        End If
    '        If oNode.Nodes.Count > 0 Then
    '            Call pCaveBranchRemoveSuborigin(oNode.Nodes)
    '        End If
    '    Next
    'End Sub

    Private Sub btnSessionAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSessionAdd.ItemClick
        Call tvSessions.Focus()

        Dim oItem As cSessionEditPlaceHolder = DirectCast(tvSessions.DataSource, cSessionsEditBindingList).Add()
        Dim oNode As DevExpress.XtraTreeList.Nodes.TreeListNode = tvSessions.GetNodeByDataRecord(oItem)
        tvSessions.FocusedNode = oNode
        'Call tvSessions.MakeNodeVisible(oNode)

        'Dim sNewID As String
        'Dim sNewDescriptionBase As String = GetLocalizedString("properties.textpart1")
        'Dim iNewCount As Integer = 0
        'Do
        '    iNewCount += 1
        '    sNewID = Strings.Format(Today, "yyyyMMdd") & "_" & (sNewDescriptionBase & " " & iNewCount).Replace(" ", "_").ToLower
        'Loop While tvSessions.Nodes.ContainsKey(sNewID)

        'Dim oSession As cSession = oSurvey.Properties.Sessions.GetEmptySession(Today, sNewDescriptionBase & " " & iNewCount)
        'Dim oSessionNode As TreeNode = tvSessions.Nodes.Add(oSession.ID, oSession.FormattedID)

        'Dim oCI As cSessionEditPlaceHolder = New cSessionEditPlaceHolder
        'oCI.Date = oSession.Date
        'oCI.Description = oSession.Description
        'oCI.Team = oSession.Team
        'oCI.Club = oSession.Club
        'oCI.Designer = oSession.Designer
        'oCI.DistanceType = oSession.DistanceType
        'oCI.BearingType = oSession.BearingType
        'oCI.BearingDirection = oSession.BearingDirection
        'oCI.InclinationType = oSession.InclinationType
        'oCI.InclinationDirection = oSession.InclinationDirection
        'oCI.DepthType = oSession.DepthType

        'oCI.Grade = oSession.Grade

        'oCI.NordType = oSession.NordType
        'oCI.SideMeasuresType = oSession.SideMeasuresType
        'oCI.SideMeasuresReferTo = oSession.SideMeasuresReferTo

        'oCI.Source = oSession
        'oCI.Created = True
        'oSessionNode.Tag = oCI
        'oSessionNode.SelectedImageKey = "session"
        'oSessionNode.ImageKey = "session"

        'tvSessions.SelectedNode = oSessionNode
        'Call oSessionNode.EnsureVisible()
    End Sub

    Private Sub btnSessionDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSessionDelete.ItemClick
        Dim oItem As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
        If Not oItem Is Nothing Then
            tvSessions.BeginUpdate()
            DirectCast(tvSessions.DataSource, cSessionsEditBindingList).Remove(oItem)
            tvSessions.EndUpdate()
        End If
    End Sub

    Private Sub pSessionRebindGrades(Optional GradeID As String = Nothing)
        If GradeID Is Nothing Then
            If cboSessionGrade.SelectedIndex <= 0 Then
                GradeID = ""
            Else
                GradeID = DirectCast(tvGrades.DataSource, UIHelpers.cGradeEditBindingList).Item(cboSessionGrade.SelectedIndex - 1).ID
            End If
        End If
        cboSessionGrade.Items.Clear()
        Call cboSessionGrade.Items.Add("")
        Call cboSessionGrade.Items.AddRange(DirectCast(tvGrades.DataSource, UIHelpers.cGradeEditBindingList).Select(Function(oitem) oitem.Description).Cast(Of Object).ToArray)
        If GradeID = "" Then
            cboSessionGrade.SelectedIndex = 0
        Else
            cboSessionGrade.SelectedIndex = DirectCast(tvGrades.DataSource, UIHelpers.cGradeEditBindingList).IndexOf(GradeID) + 1
        End If
    End Sub

    Private Sub tvSessions_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles tvSessions.FocusedNodeChanged
        tabSession.BeginUpdate()
        Try
            tabSessionMain1.PageVisible = False
            tabSessionNote1.PageVisible = False
            tabSessionDefault1.PageVisible = False

            Dim oCI As cSessionEditPlaceHolder = tvSessions.GetDataRecordByNode(e.Node)
            Select Case oCI.Type
                Case "defaultsession"
                    lblSessionDate.Enabled = False
                    txtSessionDate.Enabled = False
                    If oSurvey.Properties.CalculateVersion >= 2 Then
                        txtSessionDate.Visible = False
                        pnlSessionDate.Visible = True
                    Else
                        txtSessionDate.Visible = True
                        pnlSessionDate.Visible = False
                    End If
                    lblSessionDescription.Enabled = False
                    txtSessionDescription.Enabled = False
                    lblSessionColor.Enabled = False
                    txtSessionColor.Enabled = False

                    txtSessionDate.EditValue = Now
                    txtSessionDescription.Text = ""
                    txtSessionColor.EditValue = Nothing

                    cboSessionDataFormat.SelectedIndex = oCI.DataFormat
                    cboSessionDistanceType.SelectedIndex = oCI.DistanceType
                    cboSessionBearingType.SelectedIndex = oCI.BearingType
                    chkSessionBearingDirection.Checked = oCI.BearingDirection = cSegment.MeasureDirectionEnum.Inverted
                    cboSessionInclinationType.SelectedIndex = oCI.InclinationType
                    chkSessionInclinationDirection.Checked = oCI.InclinationDirection = cSegment.MeasureDirectionEnum.Inverted
                    cboSessionDepthType.SelectedIndex = oCI.DepthType

                    Call pSessionRebindGrades(oCI.Grade)

                    cboSessionNordType.SelectedIndex = oCI.NordType
                    chkSessionDecMag.Checked = oCI.declinationenabled
                    txtSessionDecMag.Text = oCI.Declination

                    cboSessionSideMeasuresType.SelectedIndex = oCI.SideMeasuresType
                    cboSessionSideMeasuresReferTo.SelectedIndex = oCI.SideMeasuresReferTo

                    chkSessionVthreshold.Checked = oCI.VThresholdEnabled
                    txtSessionVthreshold.Text = oCI.VThreshold

                    tabSession.Enabled = True

                    tabSessionDefault1.PageVisible = True
                    'tabSession.SelectedTabPage = tabSessionMeasure1

                    btnSessionDelete.Enabled = False

                    lvSessionSegments.Unbind()
                    btnSessionSelectSegment.Enabled = False

                    lvSessionCalibartionSegments.Unbind()
                    btnSessionCalibrationSegmentsRefresh.Enabled = True
                Case "session"
                    lblSessionDate.Enabled = True
                    txtSessionDate.Enabled = True
                    pnlSessionDate.Visible = False
                    txtSessionDate.Visible = True

                    lblSessionDescription.Enabled = True
                    txtSessionDescription.Enabled = True
                    lblSessionColor.Enabled = True
                    txtSessionColor.Enabled = True

                    txtSessionDate.Enabled = True
                    txtSessionDate.EditValue = oCI.Date
                    txtSessionDescription.Text = oCI.Description
                    txtSessionClub.Text = oCI.Club
                    txtSessionTeam.Text = oCI.Team
                    txtSessionDesigner.Text = oCI.Designer
                    txtSessionNote.Text = oCI.Note
                    txtSessionColor.EditValue = oCI.Color

                    cboSessionDataFormat.SelectedIndex = oCI.DataFormat
                    cboSessionDistanceType.SelectedIndex = oCI.DistanceType
                    cboSessionBearingType.SelectedIndex = oCI.BearingType
                    chkSessionBearingDirection.Checked = oCI.BearingDirection = cSegment.MeasureDirectionEnum.Inverted
                    cboSessionInclinationType.SelectedIndex = oCI.InclinationType
                    chkSessionInclinationDirection.Checked = oCI.InclinationDirection = cSegment.MeasureDirectionEnum.Inverted
                    cboSessionDepthType.SelectedIndex = oCI.DepthType

                    Call pSessionRebindGrades(oCI.Grade)

                    cboSessionNordType.SelectedIndex = oCI.NordType
                    chkSessionDecMag.Checked = oCI.declinationenabled
                    txtSessionDecMag.Text = oCI.Declination

                    cboSessionSideMeasuresType.SelectedIndex = oCI.SideMeasuresType
                    cboSessionSideMeasuresReferTo.SelectedIndex = oCI.SideMeasuresReferTo

                    chkSessionVthreshold.Checked = oCI.VThresholdEnabled
                    txtSessionVthreshold.Text = oCI.VThreshold

                    Dim bEnabled As Boolean = Not oCI.Deleted
                    lblSessionColor.Enabled = bEnabled
                    txtSessionColor.Enabled = bEnabled
                    lblSessionDate.Enabled = bEnabled
                    txtSessionDate.Enabled = bEnabled
                    lblSessionDescription.Enabled = bEnabled
                    txtSessionDescription.Enabled = bEnabled
                    tabSession.Enabled = bEnabled

                    tabSessionMain1.PageVisible = True
                    tabSessionNote1.PageVisible = True
                    'tabSession.SelectedTabPage = tabSessionMain1

                    btnSessionDelete.Enabled = True

                    lvSessionSegments.Unbind()
                    btnSessionSelectSegment.Enabled = False

                    lvSessionCalibartionSegments.Unbind()
                    btnSessionCalibrationSegmentsRefresh.Enabled = True
            End Select
            btnSessionAdd.Enabled = True
        Catch ex As Exception
            lblSessionDate.Enabled = False
            txtSessionDate.Enabled = False
            lblSessionDescription.Enabled = False
            txtSessionDescription.Enabled = False
            tabSession.Enabled = False
            btnSessionDelete.Enabled = False
        End Try
        tabSession.EndUpdate()
    End Sub

    Private Sub txtSessionColor_EditValueChanged(sender As Object, e As EventArgs) Handles txtSessionColor.EditValueChanged
        Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
        If oCI IsNot Nothing Then
            If txtSessionColor.EditValue = Nothing Then
                oCI.Color = Color.Transparent
            Else
                oCI.Color = txtSessionColor.EditValue
            End If
        End If
    End Sub

    Private Sub btnSessionCalibrationSegmentsRefresh_Click(sender As Object, e As EventArgs) Handles btnSessionCalibrationSegmentsRefresh.Click
        Dim oCI As cSessionEditPlaceHolder = tvSessions.GetFocusedObject
        If Not oCI Is Nothing Then
            Call lvSessionSegments.Rebind(oSurvey, oSurvey.Segments.GetSessionSegments(oCI.Source, cISegmentCollection.SessionSegmentsFlagEnum.CalibrationShots).Cast(Of cSegment).ToList, New cSegmentsGrid.cSegmentGridParameters(False, True, True, True))
            Dim bEnabled As Boolean = lvSessionSegments.Count > 0
            lvSessionSegments.Enabled = bEnabled
            btnCaveInfoSelectSegment.Enabled = bEnabled
        End If
    End Sub

    Private Sub lvSessionSegments_SelectionChanged(sender As Object, e As cSegmentsGrid.cSelectionChangedEventArgs) Handles lvSessionSegments.SelectionChanged
        btnSessionSelectSegment.Enabled = e.SelectedItem IsNot Nothing
    End Sub

    Private Sub txtCaveInfoColor_EditValueChanged(sender As Object, e As EventArgs) Handles txtCaveInfoColor.EditValueChanged
        Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetFocusedObject
        If oItem IsNot Nothing Then
            oItem.Color = txtCaveInfoColor.Color
        End If
    End Sub

    Private Sub btnCaveInfoAddBranch_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCaveInfoAddBranch.ItemClick
        Dim oItems As cCaveInfoBranchEditBindingList = tvCaveInfos.DataSource
        Dim oCurrentItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetFocusedObject
        If oCurrentItem IsNot Nothing Then
            tvCaveInfos.BeginUpdate()
            Dim sCave As String = oCurrentItem.Name
            Dim oBranches As cCaveInfoBranches = oCurrentItem.GetSource.branches
            Dim oCaveInfoBranch As cCaveInfoBranch = oBranches.GetEmptyCaveInfoBranch(pGetNewNodeName(modMain.GetLocalizedString("properties.textpart5"), oItems))
            Dim oItem As cCaveInfoBranchPlaceHolder = oItems.Add(oCurrentItem, oCaveInfoBranch)
            Dim oNode As DevExpress.XtraTreeList.Nodes.TreeListNode = tvCaveInfos.GetNodeByDataRecord(oItem)
            oNode.Expanded = True
            tvCaveInfos.FocusedNode = oNode

            tvCaveInfos.EndUpdate()
        End If

        'Try
        '    Dim oParentNode As TreeNode = tvCaveInfos.SelectedNode
        '    If Not oParentNode Is Nothing Then
        '        Call tvCaveInfos.Focus()

        '        Dim sCave As String = oParentNode.Tag.name
        '        Dim oBranches As cCaveInfoBranches = oParentNode.Tag.source.branches
        '        Dim oCaveInfoBranch As cCaveInfoBranch = oBranches.GetEmptyCaveInfoBranch(pGetNewNodeName(modMain.GetLocalizedString("properties.textpart5"), oParentNode.Nodes))
        '        Dim oBranchNode As TreeNode = oParentNode.Nodes.Add(oCaveInfoBranch.Name, oCaveInfoBranch.Name)
        '        Dim oCIB As cCaveInfoBranchPlaceHolder = New cCaveInfoBranchPlaceHolder
        '        oCIB.Name = oCaveInfoBranch.Name
        '        oCIB.Color = oCaveInfoBranch.Color
        '        oCIB.Description = oCaveInfoBranch.Description
        '        oCIB.SurfaceProfileShow = oCaveInfoBranch.SurfaceProfileShow
        '        oCIB.Locked = oCaveInfoBranch.Locked
        '        oCIB.ExtendStart = oCaveInfoBranch.ExtendStart
        '        oCIB.Source = oCaveInfoBranch
        '        oCIB.Created = True
        '        oBranchNode.Tag = oCIB
        '        oBranchNode.SelectedImageKey = "branch"
        '        oBranchNode.ImageKey = "branch"

        '        tvCaveInfos.SelectedNode = oBranchNode
        '        Call oBranchNode.EnsureVisible()
        '    End If
        'Catch
        'End Try
    End Sub

    Private Sub btnCaveInfoAddCave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCaveInfoAddCave.ItemClick
        tvCaveInfos.BeginUpdate()
        Dim oItems As cCaveInfoBranchEditBindingList = tvCaveInfos.DataSource
        Dim oCaveInfo As cCaveInfo = oSurvey.Properties.CaveInfos.GetEmptyCaveInfo(pGetNewNodeName(modMain.GetLocalizedString("properties.textpart4"), oItems))
        Dim oItem As cCaveInfoPlaceHolder = oItems.Add(oCaveInfo)
        Dim oNode As DevExpress.XtraTreeList.Nodes.TreeListNode = tvCaveInfos.GetNodeByDataRecord(oItem)
        tvCaveInfos.FocusedNode = oNode
        tvCaveInfos.EndUpdate()

        'Call tvCaveInfos.Focus()

        '
        'Dim oCaveNode As TreeNode = tvCaveInfos.Nodes.Add(oCaveInfo.Name, oCaveInfo.Name)
        'Dim oCI As cCaveInfoPlaceHolder = New cCaveInfoPlaceHolder
        'oCI.Name = oCaveInfo.Name
        'oCI.ID = oCaveInfo.ID
        'oCI.Color = oCaveInfo.Color
        'oCI.ExtendStart = oCaveInfo.ExtendStart
        'oCI.Source = oCaveInfo
        'oCI.Created = True
        'oCaveNode.Tag = oCI
        'oCaveNode.SelectedImageKey = "cave"
        'oCaveNode.ImageKey = "cave"

        'tvCaveInfos.SelectedNode = oCaveNode
        'Call oCaveNode.EnsureVisible()
    End Sub

    Private Sub btnCaveInfoDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCaveInfoDelete.ItemClick
        Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetFocusedObject
        If Not oItem Is Nothing Then
            tvCaveInfos.BeginUpdate()
            DirectCast(tvCaveInfos.DataSource, cCaveInfoBranchEditBindingList).Remove(oItem)
            tvCaveInfos.EndUpdate()
        End If
    End Sub

    Private Sub tvCaveInfos_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles tvCaveInfos.FocusedNodeChanged
        Call tabCaveAndBranch.BeginUpdate()
        Try
            Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetFocusedObject
            Select Case oItem.Type
                Case "cave"
                    Dim oCI As cCaveInfoPlaceHolder = oItem
                    txtCaveInfoID.Enabled = True
                    txtCaveInfoName.Text = oCI.Name
                    txtCaveInfoID.Text = oCI.ID
                    txtCaveInfoDescription.Text = oCI.Description
                    txtCaveInfoColor.Color = oCI.Color
                    If oCI.ExtendStart = "" Then
                        chkCaveInfoExtendStart.Checked = False
                        Call chkCaveInfoExtendStart_CheckedChanged(chkCaveInfoExtendStart, EventArgs.Empty)
                    Else
                        cboCaveInfoExtendStart.FastRebind(oSurvey, oCI.ExtendStart, False, False)
                        chkCaveInfoExtendStart.Checked = True
                    End If
                    If oCI.Priority.HasValue Then
                        txtCaveInfoPriority.Value = oCI.Priority.GetValueOrDefault(0)
                        chkCaveInfoPriority.Checked = True
                    Else
                        chkCaveInfoPriority.Checked = False
                        Call chkCaveInfoPriority_CheckedChanged(chkCaveInfoPriority, EventArgs.Empty)
                    End If
                    If IsNothing(oCI.ParentConnection) Then
                        txtCaveInfoParentConnection.Text = ""
                        txtCaveInfoConnection.Enabled = False
                        cmdCaveInfoConnection.Enabled = False
                    Else
                        txtCaveInfoParentConnection.Text = oCI.ParentConnection.ToString
                        txtCaveInfoConnection.Enabled = True
                        cmdCaveInfoConnection.Enabled = True
                    End If
                    txtCaveInfoConnection.Text = If(IsNothing(oCI.Connection), "", oCI.Connection.ToString)

                    Dim bEnabled As Boolean = Not oCI.Deleted
                    lblCaveInfoName.Enabled = bEnabled
                    txtCaveInfoName.Enabled = bEnabled
                    lblCaveInfoID.Enabled = bEnabled
                    txtCaveInfoID.Enabled = bEnabled
                    lblCaveInfoColor.Enabled = bEnabled
                    txtCaveInfoColor.Enabled = bEnabled
                    lblCaveInfoDescription.Enabled = bEnabled
                    txtCaveInfoDescription.Enabled = bEnabled
                    chkCaveInfoLocked.Enabled = bEnabled
                    tabCaveAndBranch.Enabled = bEnabled

                    If oCI.Deleted Then
                        btnCaveInfoAddBranch.Enabled = False
                        btnCaveInfoDelete.Enabled = False
                    Else
                        btnCaveInfoAddBranch.Enabled = True
                        btnCaveInfoDelete.Enabled = True
                    End If

                    cboCaveInfoSurfaceProfileShow.SelectedIndex = oCI.SurfaceProfileShow
                    chkCaveInfoLocked.Checked = oCI.Locked
                Case "branch"
                    Dim oCIB As cCaveInfoBranchPlaceHolder = oItem
                    txtCaveInfoID.Enabled = False
                    txtCaveInfoName.Text = oCIB.Name
                    txtCaveInfoColor.Color = oCIB.Color
                    txtCaveInfoDescription.Text = oCIB.Description
                    If oCIB.ExtendStart = "" Then
                        chkCaveInfoExtendStart.Checked = False
                        Call chkCaveInfoExtendStart_CheckedChanged(chkCaveInfoExtendStart, EventArgs.Empty)
                    Else
                        'cboCaveInfoExtendStart.Text = oCIB.ExtendStart
                        cboCaveInfoExtendStart.FastRebind(oSurvey, oCIB.ExtendStart, False, False)
                        chkCaveInfoExtendStart.Checked = True
                    End If
                    If oCIB.Priority.HasValue Then
                        txtCaveInfoPriority.Value = oCIB.Priority.GetValueOrDefault(0)
                        chkCaveInfoPriority.Checked = True
                    Else
                        chkCaveInfoPriority.Checked = False
                        Call chkCaveInfoPriority_CheckedChanged(chkCaveInfoPriority, EventArgs.Empty)
                    End If
                    If IsNothing(oCIB.ParentConnection) Then
                        txtCaveInfoParentConnection.Text = ""
                        txtCaveInfoConnection.Enabled = False
                        cmdCaveInfoConnection.Enabled = False
                    Else
                        txtCaveInfoParentConnection.Text = oCIB.ParentConnection.ToString
                        txtCaveInfoConnection.Enabled = True
                        cmdCaveInfoConnection.Enabled = True
                    End If
                    txtCaveInfoConnection.Text = If(IsNothing(oCIB.Connection), "", oCIB.Connection.ToString)

                    Dim bEnabled As Boolean = Not oCIB.Deleted
                    lblCaveInfoName.Enabled = bEnabled
                    txtCaveInfoName.Enabled = bEnabled
                    lblCaveInfoID.Enabled = False
                    txtCaveInfoID.Enabled = False
                    lblCaveInfoColor.Enabled = bEnabled
                    txtCaveInfoColor.Enabled = bEnabled
                    lblCaveInfoDescription.Enabled = bEnabled
                    txtCaveInfoDescription.Enabled = bEnabled
                    chkCaveInfoLocked.Enabled = bEnabled
                    tabCaveAndBranch.Enabled = bEnabled

                    If oCIB.Deleted Then
                        btnCaveInfoAddBranch.Enabled = False
                        btnCaveInfoDelete.Enabled = False
                    Else
                        btnCaveInfoAddBranch.Enabled = True
                        btnCaveInfoDelete.Enabled = True
                    End If

                    cboCaveInfoSurfaceProfileShow.SelectedIndex = oCIB.SurfaceProfileShow
                    chkCaveInfoLocked.Checked = oCIB.Locked
            End Select
            btnCaveInfoAddCave.Enabled = True

            lvCaveInfoSegments.Enabled = True
            btnCaveInfoSegmentsRefresh.Enabled = True

            Call lvCaveInfoSegments.Unbind()
            btnCaveInfoSelectSegment.Enabled = False
        Catch ex As Exception
            lblCaveInfoName.Enabled = False
            txtCaveInfoName.Enabled = False
            lblCaveInfoID.Enabled = False
            txtCaveInfoID.Enabled = False
            lblCaveInfoColor.Enabled = False
            txtCaveInfoColor.Enabled = False
            lblCaveInfoDescription.Enabled = False
            txtCaveInfoDescription.Enabled = False
            chkCaveInfoLocked.Enabled = False
            tabCaveAndBranch.Enabled = False

            lvCaveInfoSegments.Enabled = False
            btnCaveInfoSegmentsRefresh.Enabled = False

            Call lvCaveInfoSegments.Unbind()
            btnCaveInfoSelectSegment.Enabled = False

            btnCaveInfoAddCave.Enabled = True
            btnCaveInfoAddBranch.Enabled = False
            btnCaveInfoDelete.Enabled = False
        End Try
        Call tabCaveAndBranch.EndUpdate()
    End Sub

    Private Sub tvCaveInfos1_NodeCellStyle(sender As Object, e As DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs) Handles tvCaveInfos.NodeCellStyle
        If e.Column Is colCaveInfosColor Then
            Dim oItem As cICaveInfoBasePlaceHolder = tvCaveInfos.GetDataRecordByNode(e.Node)
            e.Appearance.BackColor = oItem.Color
        End If
    End Sub

    Private Sub txtHighlightColor_EditValueChanged(sender As Object, e As EventArgs) Handles txtHighlightColor.EditValueChanged
        Try
            Dim oCI As cHighlightPlaceholder = tvHighlights.GetFocusedObject
            oCI.Color = txtHighlightColor.Color
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAddHighlightStations_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAddHighlightStations.ItemClick
        Call pHighlightAdd(Properties.cHighlightsDetail.ApplyToEnum.Stations)
    End Sub

    Private Sub btnAddHighlightShots_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAddHighlightShots.ItemClick
        Call pHighlightAdd(Properties.cHighlightsDetail.ApplyToEnum.Shots)
    End Sub

    Private Sub btnDeleteHighlight_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDeleteHighlight.ItemClick
        Dim oItem As cHighlightPlaceholder = tvHighlights.GetFocusedObject
        If Not oItem Is Nothing Then
            tvHighlights.BeginUpdate()
            DirectCast(tvHighlights.DataSource, cHighlightEditBindingList).Remove(oItem)
            tvHighlights.EndUpdate()
        End If
    End Sub

    Private Sub btnResetHighlight_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnResetHighlight.ItemClick
        Call oSurvey.Properties.HighlightsDetails.Clear()
        Call pHighlightsLoad()
    End Sub

    Private Sub tvHighlights_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles tvHighlights.FocusedNodeChanged
        Dim oCI As cHighlightPlaceholder = tvHighlights.GetFocusedObject
        If oCI Is Nothing Then
            btnAddHighlight.Enabled = True
            btnDeleteHighlight.Enabled = False
            btnHighlightExport.Enabled = False
        Else
            Dim bSystem As Boolean
            If oCI.Source Is Nothing Then
                bSystem = False
            Else
                bSystem = oCI.Source.System
            End If
            txtHighlightName.Text = oCI.Name
            txtHighlightSize.Value = oCI.Size
            trkHighlightOpacity.EditValue = oCI.Opacity
            txtHighlightColor.Color = oCI.Color
            txtHighlightApplyTo.Text = If(oCI.ApplyTo, modMain.GetLocalizedString("main.textpart94"), modMain.GetLocalizedString("main.textpart95"))
            txtHighlightCondition.Text = oCI.Condition

            Dim bEnabled As Boolean = Not oCI.Deleted
            txtHighlightName.Enabled = bEnabled
            txtHighlightSize.Enabled = bEnabled
            trkHighlightOpacity.Enabled = bEnabled
            txtHighlightColor.Enabled = bEnabled
            txtHighlightApplyTo.Enabled = bEnabled
            'cmdHighlightColorChange.Enabled = bEnabled
            cmdHighlightCondition.Enabled = bEnabled And Not bSystem
            'End Select
            btnAddHighlight.Enabled = True
            btnDeleteHighlight.Enabled = tvHighlights.Nodes.Count > 0 AndAlso Not bSystem
            btnHighlightExport.Enabled = Not oCI.System
        End If
    End Sub

    Private Sub trkHighlightOpacity_EditValueChanged(sender As Object, e As EventArgs) Handles trkHighlightOpacity.EditValueChanged
        Try
            Dim oCI As cHighlightPlaceholder = tvHighlights.GetFocusedObject
            oCI.Opacity = trkHighlightOpacity.EditValue
        Catch
        End Try
    End Sub

    Private Sub tvHighlights_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraTreeList.TreeListCustomColumnDataEventArgs) Handles tvHighlights.CustomUnboundColumnData
        If e.IsGetData Then
            If e.Column Is colHighlightsApplyTo Then
                If e.Row Is Nothing Then
                    e.Value = ""
                Else
                    e.Value = If(DirectCast(e.Row, cHighlightPlaceholder).ApplyTo, modMain.GetLocalizedString("main.textpart94"), modMain.GetLocalizedString("main.textpart95"))
                End If
            End If
        End If
    End Sub

    Private Function pGetVisibleChildElementCount(ParentElement As AccordionControlElement) As Integer
        Return ParentElement.Elements.Where(Function(oitem) oitem.Visible).Count
    End Function

    Private Function pGetFirstVisibleChildElement(ParentElement As AccordionControlElement) As AccordionControlElement
        Return ParentElement.Elements.FirstOrDefault(Function(oitem) oitem.Visible)
    End Function

    Private Sub AccordionControl1_SelectedElementChanged(sender As Object, e As DevExpress.XtraBars.Navigation.SelectedElementChangedEventArgs) Handles AccordionControl1.SelectedElementChanged
        Dim sControlName As String = "" & e.Element.Tag
        If sControlName <> "" Then
            If Controls.ContainsKey("_" & sControlName) Then
                Call Controls("_" & sControlName).BringToFront()
                Controls("_" & sControlName).Visible = True
            End If
        End If
        Select Case sControlName
            Case "tabInfoSessions1"
                Call pSessionRebindGrades()
            Case "tabInfoSurface1"
                Call pElevationRebindSurfaceProfileCombo()
            Case "tabInfoSurfaceElevation1"
                Call pElevationRebindOrthophotoFromWMSMenu()
            Case "tabInfoDataPrecision1"
                Call pGradesRebindUsedBy()
        End Select
    End Sub

    Private Sub pElevationRebindSurfaceProfileCombo(Optional Elevation As Surface.cElevation = Nothing)
        Call cbosurfaceprofileelevation.Rebind(DirectCast(tvElevations.DataSource, UIHelpers.cElevationsBindingList).Elevations, False, False)
        If Elevation IsNot Nothing Then Call cbosurfaceprofileelevation.SetSelectedElevation(Elevation)

        pnlSurfaceProfile.Enabled = chkGPSEnabled.Checked AndAlso cbosurfaceprofileelevation.Count > 0
    End Sub

    Private Sub AccordionControl1_ElementClick(sender As Object, e As ElementClickEventArgs) Handles AccordionControl1.ElementClick
        If pGetVisibleChildElementCount(e.Element) > 0 Then
            Dim oParentElement As AccordionControlElement = e.Element
            Do
                Dim oElement As AccordionControlElement = pGetFirstVisibleChildElement(oParentElement)
                If oElement.Elements.Count = 0 Then
                    AccordionControl1.SelectedElement = oElement
                    Exit Do
                Else
                    oParentElement = oElement
                End If
            Loop
        Else
            AccordionControl1.SelectedElement = e.Element
        End If
        e.Handled = True
    End Sub

    Private Sub tvElevations_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles tvElevations.FocusedNodeChanged
        Dim oElevation As UIHelpers.cElevationPlaceHolder = tvElevations.GetFocusedObject
        If oElevation Is Nothing Then
            lblElevationName.Enabled = False
            txtElevationName.Enabled = False
            lblElevationPreview.Enabled = False
            picElevationPreview.Enabled = False
            lblElevationInformation.Enabled = False
            txtElevationInformation.Enabled = False
            lblElevationColorSchema.Enabled = False
            cboElevationColorSchema.Enabled = False

            btnElevationDelete.Enabled = False
            btnElevationExport.Enabled = False
            btnElevationsPreviewNewReduced.Enabled = False
            btnElevationsPreviewRemoveNODATA.Enabled = False

            txtElevationName.EditValue = ""
            picElevationPreview.EditValue = Nothing
            txtElevationInformation.EditValue = ""
            cboElevationColorSchema.SelectedIndex = cElevation.ColorSchemaEnum.WhiteToBlack

            btnElevationCreateOrthophotoFromWMS.Enabled = False
        Else
            lblElevationName.Enabled = True
            txtElevationName.Enabled = True
            lblElevationPreview.Enabled = True
            picElevationPreview.Enabled = True
            lblElevationInformation.Enabled = True
            txtElevationInformation.Enabled = True
            lblElevationColorSchema.Enabled = True
            cboElevationColorSchema.Enabled = True

            btnElevationDelete.Enabled = True
            btnElevationExport.Enabled = True
            btnElevationsPreviewNewReduced.Enabled = True
            btnElevationsPreviewRemoveNODATA.Enabled = True

            txtElevationName.EditValue = oElevation.Name
            picElevationPreview.EditValue = oElevation.Image
            txtElevationInformation.EditValue = oElevation.Information
            cboElevationColorSchema.SelectedIndex = oElevation.ColorSchema

            btnElevationCreateOrthophotoFromWMS.Enabled = DirectCast(tvWMSs.DataSource, UIHelpers.cWMSsBindingList).Where(Function(oitem) oitem.IsValid).Count > 0
        End If

        btnElevationClear.Enabled = tvElevations.Nodes.Count > 0
    End Sub

    Private Sub txtElevationName_Validated(sender As Object, e As EventArgs) Handles txtElevationName.Validated
        Try
            Dim oItem As cElevationPlaceHolder = tvElevations.GetFocusedObject
            oItem.Name = txtElevationName.EditValue
        Catch
        End Try
    End Sub

    Private Sub cboElevationColorSchema_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboElevationColorSchema.SelectedIndexChanged
        Try
            Dim oItem As cElevationPlaceHolder = tvElevations.GetFocusedObject
            oItem.ColorSchema = cboElevationColorSchema.SelectedIndex
            Call tvElevations.RefreshDataSource()
            picElevationPreview.EditValue = oItem.Image
        Catch
        End Try
    End Sub

    Private Sub btnElevationDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnElevationDelete.ItemClick
        Dim oItem As cElevationPlaceHolder = tvElevations.GetFocusedObject
        If oItem IsNot Nothing Then
            If cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("surface.warning1"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("surface.warningtitle")) = MsgBoxResult.Yes Then
                Call DirectCast(tvElevations.DataSource, UIHelpers.cElevationsBindingList).Remove(oItem)
            End If
        End If
    End Sub

    Private Sub btnElevationClear_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnElevationClear.ItemClick
        Call DirectCast(tvElevations.DataSource, UIHelpers.cElevationsBindingList).Clear()
    End Sub

    Private Sub btnElevationExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnElevationExport.ItemClick
        Try
            Dim oItem As cElevationPlaceHolder = tvElevations.GetFocusedObject
            If oItem IsNot Nothing Then
                'Try
                '    Using oSFD As SaveFileDialog = New SaveFileDialog
                '        With oSFD
                '            .Title = GetLocalizedString("surface.exportelevationdatadialog")
                '            .Filter = GetLocalizedString("surface.filetypeHOLOS") & " (*.elevation.xml)|*.elevation.xml"
                '            .FilterIndex = 1
                '            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                '                Select Case .FilterIndex
                '                    Case 1
                '                        Dim oXML As XmlDocument = New XmlDocument
                '                        Dim oXMLRoot As XmlElement = oXML.CreateElement("holos")
                '                        Dim oXMLElevation As XmlElement = oXML.CreateElement("elevation")
                '                        Dim oElevation As Surface.cElevation = oItem.Elevation
                '                        Dim oTopLeft As modUTM.UTM = modUTM.WGS84ToUTM(oElevation.GetCoordinate(Surface.cElevation.GetCoordinateCornerEnum.TopLeft))
                '                        Call oXMLElevation.SetAttribute("pos", modNumbers.NumberToString(oTopLeft.East) & ";" & modNumbers.NumberToString(oTopLeft.North) & ";0")
                '                        'Call oXMLElevation.SetAttribute("tr", modUTM.WGS84ToUTM(oElevation.GetCoordinate(cElevation.GetCoordinateCornerEnum.TopRight)).ToString)
                '                        'Call oXMLElevation.SetAttribute("bl", modUTM.WGS84ToUTM(oElevation.GetCoordinate(cElevation.GetCoordinateCornerEnum.BottomLeft)).ToString)
                '                        'Call oXMLElevation.SetAttribute("br", modUTM.WGS84ToUTM(oElevation.GetCoordinate(cElevation.GetCoordinateCornerEnum.BottomRight)).ToString)
                '                        Call oXMLElevation.SetAttribute("rows", oElevation.Rows)
                '                        Call oXMLElevation.SetAttribute("cols", oElevation.Columns)
                '                        Call oXMLElevation.SetAttribute("sizex", modNumbers.NumberToString(oElevation.XSize))
                '                        Call oXMLElevation.SetAttribute("sizey", modNumbers.NumberToString(oElevation.YSize))
                '                        Call oXMLElevation.SetAttribute("nodatavalue", modNumbers.NumberToString(Surface.cElevation.NoDataValue))
                '                        Dim odata As StringBuilder = New StringBuilder
                '                        For iy As Integer = 0 To oElevation.Rows - 1
                '                            For ix As Integer = 0 To oElevation.Columns - 1
                '                                Dim iAlt As Integer = oElevation.Data(iy, ix)   'rounded to meters
                '                                Call odata.Append(modNumbers.NumberToString(iAlt, "0") & " ")
                '                            Next
                '                            Call odata.Append(vbCrLf)
                '                        Next
                '                        oXMLElevation.InnerText = odata.ToString
                '                        Call oXMLRoot.AppendChild(oXMLElevation)
                '                        Call oXML.AppendChild(oXMLRoot)
                '                        Call oXML.Save(.FileName)
                '                End Select
                '            End If
                '        End With
                '    End Using
                'Catch ex As Exception
                '    Call oSurvey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Error, ex.Message, True)
                'End Try
            End If
        Catch ex As Exception
            Call oSurvey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Error, ex.Message)
        End Try
    End Sub

    Private Sub btnElevationAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnElevationAdd.ItemClick
        Using oOfd As OpenFileDialog = New OpenFileDialog
            With oOfd
                .Title = GetLocalizedString("surface.openelevationdialog")
                .Filter = GetLocalizedString("surface.filetypeASC") & " (*.ASC;*.TXT)|*.ASC;*.TXT"
                .FilterIndex = 1
                If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Try
                        Using frmSIASCOptions As frmSurfaceImportASCOptions = New frmSurfaceImportASCOptions
                            Dim oOptions As Surface.cElevation.cElevationImportOptions = New Surface.cElevation.cElevationImportOptions
                            If frmSIASCOptions.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                                oOptions.System = frmSIASCOptions.cboCoordinateSystem.SelectedIndex
                                Select Case DirectCast(frmSIASCOptions.cboCoordinateSystem.SelectedIndex, Surface.cElevation.cElevationImportOptions.CoordinateSystemEnum)
                                    Case Surface.cElevation.cElevationImportOptions.CoordinateSystemEnum.UTMWGS84
                                        Call oOptions.Parameters.Add("utmzone", frmSIASCOptions.cboUTMZone.Text)
                                        Call oOptions.Parameters.Add("utmband", frmSIASCOptions.cboUTMBand.Text)
                                End Select
                                Dim oNewItem As UIHelpers.cElevationPlaceHolder = DirectCast(tvElevations.DataSource, UIHelpers.cElevationsBindingList).Add(.FilterIndex - 1, .FileName, oOptions)
                                Call tvElevations.SetFocusedObject(oNewItem)
                            End If
                        End Using
                    Catch ex As Exception
                        Call cSurvey.UIHelpers.Dialogs.Msgbox(String.Format(GetLocalizedString("surface.warning2"), ex.Message), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("surface.warningtitle"))
                        Call oSurvey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Error, ex.Message)
                    End Try
                End If
            End With
        End Using
    End Sub

    Private Sub btnElevationsPreviewNewReduced50_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnElevationsPreviewNewReduced50.ItemClick
        Dim oItem As cElevationPlaceHolder = tvElevations.GetFocusedObject
        If oItem IsNot Nothing Then
            Cursor = Cursors.WaitCursor
            Dim oNewItem As UIHelpers.cElevationPlaceHolder = DirectCast(tvElevations.DataSource, UIHelpers.cElevationsBindingList).Add(oItem, 50)
            Cursor = Cursors.Default
            Call tvElevations.SetFocusedObject(oNewItem)
        End If
    End Sub

    Private Sub btnElevationsPreviewNewReduced33_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnElevationsPreviewNewReduced33.ItemClick
        Dim oItem As cElevationPlaceHolder = tvElevations.GetFocusedObject
        If oItem IsNot Nothing Then
            Cursor = Cursors.WaitCursor
            Dim oNewItem As UIHelpers.cElevationPlaceHolder = DirectCast(tvElevations.DataSource, UIHelpers.cElevationsBindingList).Add(oItem, 33)
            Cursor = Cursors.Default
            Call tvElevations.SetFocusedObject(oNewItem)
        End If
    End Sub

    Private Sub btnElevationsPreviewNewReduced25_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnElevationsPreviewNewReduced25.ItemClick
        Dim oItem As cElevationPlaceHolder = tvElevations.GetFocusedObject
        If oItem IsNot Nothing Then
            Cursor = Cursors.WaitCursor
            Dim oNewItem As UIHelpers.cElevationPlaceHolder = DirectCast(tvElevations.DataSource, UIHelpers.cElevationsBindingList).Add(oItem, 25)
            Cursor = Cursors.Default
            Call tvElevations.SetFocusedObject(oNewItem)
        End If
    End Sub

    Private Sub btnElevationsPreviewRemoveNODATA_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnElevationsPreviewRemoveNODATA.ItemClick
        Dim oItem As cElevationPlaceHolder = tvElevations.GetFocusedObject
        If oItem IsNot Nothing Then
            Call oItem.RemoveNodata()
            Call tvElevations.RefreshDataSource()
            picElevationPreview.EditValue = oItem.Image
        End If
    End Sub

    Private Sub tvOrthophotos_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles tvOrthophotos.FocusedNodeChanged
        Dim oOrthophoto As UIHelpers.cOrthophotoPlaceHolder = tvOrthophotos.GetFocusedObject
        If oOrthophoto Is Nothing Then
            lblOrthophotoName.Enabled = False
            txtOrthophotoName.Enabled = False
            lblOrthophotoPreview.Enabled = False
            picOrthophotoPreview.Enabled = False
            lblOrthophotoInformation.Enabled = False
            txtOrthophotoInformation.Enabled = False

            btnOrthophotoDelete.Enabled = False
            btnOrthophotoExport.Enabled = False
            btnOrthophotosPreviewNewReduced.Enabled = False
            btnOrthophotoPreviewInvertColors.Enabled = False
            btnElevationFromOrthophoto.Enabled = False

            txtOrthophotoName.EditValue = ""
            picOrthophotoPreview.EditValue = Nothing
            txtOrthophotoInformation.EditValue = ""
        Else
            lblOrthophotoName.Enabled = True
            txtOrthophotoName.Enabled = True
            lblOrthophotoPreview.Enabled = True
            picOrthophotoPreview.Enabled = True
            lblOrthophotoInformation.Enabled = True
            txtOrthophotoInformation.Enabled = True

            btnOrthophotoDelete.Enabled = True
            btnOrthophotoExport.Enabled = True
            btnOrthophotosPreviewNewReduced.Enabled = True
            btnOrthophotoPreviewInvertColors.Enabled = True
            btnElevationFromOrthophoto.Enabled = True

            txtOrthophotoName.EditValue = oOrthophoto.Name
            picOrthophotoPreview.EditValue = oOrthophoto.Image
            txtOrthophotoInformation.EditValue = oOrthophoto.Information
        End If

        btnOrthophotoClear.Enabled = tvOrthophotos.Nodes.Count > 0
    End Sub

    Private Sub btnOrthophotoAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnOrthophotoAdd.ItemClick
        Using oOfd As OpenFileDialog = New OpenFileDialog
            With oOfd
                .Title = GetLocalizedString("surface.openorthophotodialog")
                .Filter = GetLocalizedString("surface.filetypeIMAGES") & " (*.JPG;*.TIF;*.PNG)|*.JPG;*.TIF;*.PNG"
                .FilterIndex = 1
                If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Try
                        Using frmSIASCOptions As frmSurfaceImportASCOptions = New frmSurfaceImportASCOptions
                            Dim oOptions As Surface.cOrthoPhoto.cOrthoPhotoImportOptions = New Surface.cOrthoPhoto.cOrthoPhotoImportOptions
                            If frmSIASCOptions.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                                oOptions.System = frmSIASCOptions.cboCoordinateSystem.SelectedIndex
                                Select Case DirectCast(frmSIASCOptions.cboCoordinateSystem.SelectedIndex, Surface.cElevation.cElevationImportOptions.CoordinateSystemEnum)
                                    Case Surface.cOrthoPhoto.cOrthoPhotoImportOptions.CoordinateSystemEnum.UTMWGS84
                                        Call oOptions.Parameters.Add("utmzone", frmSIASCOptions.cboUTMZone.Text)
                                        Call oOptions.Parameters.Add("utmband", frmSIASCOptions.cboUTMBand.Text)
                                End Select
                                Dim oNewItem As UIHelpers.cOrthophotoPlaceHolder = DirectCast(tvOrthophotos.DataSource, UIHelpers.cOrthophotosBindingList).Add(.FilterIndex - 1, .FileName, oOptions)
                                Call tvOrthophotos.SetFocusedObject(oNewItem)
                            End If
                        End Using
                    Catch ex As Exception
                        Call cSurvey.UIHelpers.Dialogs.Msgbox(String.Format(GetLocalizedString("surface.warning2"), ex.Message), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("surface.warningtitle"))
                        Call oSurvey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Error, ex.Message)
                    End Try
                End If
            End With
        End Using
    End Sub

    Private Sub btnOrthophotoDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnOrthophotoDelete.ItemClick
        Dim oItem As cOrthophotoPlaceHolder = tvOrthophotos.GetFocusedObject
        If oItem IsNot Nothing Then
            If cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("surface.warning3"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("surface.warningtitle")) = MsgBoxResult.Yes Then
                Call DirectCast(tvOrthophotos.DataSource, UIHelpers.cOrthophotosBindingList).Remove(oItem)
            End If
        End If
    End Sub

    Private Sub btnOrthophotoClear_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnOrthophotoClear.ItemClick
        Call DirectCast(tvOrthophotos.DataSource, UIHelpers.cOrthophotosBindingList).Clear()
    End Sub

    Private Sub btnOrthophotoPreviewInvertColors_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnOrthophotoPreviewInvertColors.ItemClick
        Dim oItem As cOrthophotoPlaceHolder = tvOrthophotos.GetFocusedObject
        If oItem IsNot Nothing Then
            Call oItem.InvertColors()
            Call tvOrthophotos.RefreshDataSource()
            picOrthophotoPreview.EditValue = oItem.Image
        End If
    End Sub

    Private Sub tvWMSs_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles tvWMSs.FocusedNodeChanged
        Dim oWMS As UIHelpers.cWMSPlaceHolder = tvWMSs.GetFocusedObject
        If oWMS Is Nothing Then
            lblWMSName.Enabled = False
            txtWMSName.Enabled = False
            lblWMSURL.Enabled = False
            txtWMSURL.Enabled = False
            lblWMSLayer.Enabled = False
            tvWMSLayer.Enabled = False
            lblWMSSRSOverride.Enabled = False
            cboWMSSRSOverride.Enabled = False

            btnWMSDelete.Enabled = False
            btnWMSLayerRefresh.Enabled = False

            txtWMSName.EditValue = ""
            txtWMSURL.EditValue = ""
            tvWMSLayer.DataSource = Nothing
            Call tvWMSLayer_Validating(tvWMSLayer, New CancelEventArgs)
            cboWMSSRSOverride.SelectedIndex = 0
        Else
            lblWMSName.Enabled = True
            txtWMSName.Enabled = True
            lblWMSURL.Enabled = True
            txtWMSURL.Enabled = True
            lblWMSLayer.Enabled = True
            tvWMSLayer.Enabled = True
            lblWMSSRSOverride.Enabled = True
            cboWMSSRSOverride.Enabled = True

            btnWMSDelete.Enabled = True
            btnWMSLayerRefresh.Enabled = True

            txtWMSName.EditValue = oWMS.Name
            txtWMSURL.EditValue = oWMS.URL
            tvWMSLayer.DataSource = oWMS.GetLayers
            Call tvWMSLayer_Validating(tvWMSLayer, New CancelEventArgs)
            If oWMS.SRSOverrides = "" Then
                cboWMSSRSOverride.SelectedIndex = 0
            Else
                cboWMSSRSOverride.EditValue = oWMS.SRSOverrides
            End If
        End If

        btnWMSClear.Enabled = tvWMSs.Nodes.Count > 0
    End Sub

    Private Sub txtOrthophotoName_Validated(sender As Object, e As EventArgs) Handles txtOrthophotoName.Validated
        Try
            Dim oItem As cOrthophotoPlaceHolder = tvOrthophotos.GetFocusedObject
            oItem.Name = txtOrthophotoName.EditValue
            Call tvOrthophotos.RefreshDataSource()
        Catch
        End Try
    End Sub

    Private Sub txtWMSName_Validated(sender As Object, e As EventArgs) Handles txtWMSName.Validated
        Try
            Dim oItem As cWMSPlaceHolder = tvWMSs.GetFocusedObject
            oItem.Name = txtWMSName.EditValue
            Call tvWMSs.RefreshDataSource()
        Catch
        End Try
    End Sub

    Private Sub btnWMSLayerRefresh_Click(sender As Object, e As EventArgs) Handles btnWMSLayerRefresh.Click
        Dim oItem As cWMSPlaceHolder = tvWMSs.GetFocusedObject
        tvWMSLayer.DataSource = oItem.GetRefreshedLayers
        Call tvWMSLayer_Validating(tvWMSLayer, New CancelEventArgs)
    End Sub

    Private Sub tvWMSLayer_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraTreeList.TreeListCustomColumnDataEventArgs) Handles tvWMSLayer.CustomUnboundColumnData
        If e.IsGetData Then
            If e.Column Is colWMSLayerCRSs Then
                e.Value = String.Join(","c, DirectCast(e.Row, Surface.cWMSLayer).SRS)
            ElseIf e.Column Is colWMSImageFormat Then
                e.Value = String.Join(","c, DirectCast(e.Row, Surface.cWMSLayer).ImageFormats)
            End If
        End If
    End Sub

    Private Sub cboWMSSRSOverride_Validated(sender As Object, e As EventArgs) Handles cboWMSSRSOverride.Validated
        Try
            Dim oItem As cWMSPlaceHolder = tvWMSs.GetFocusedObject
            If cboWMSSRSOverride.SelectedIndex = 0 Then
                oItem.SRSOverrides = ""
            Else
                oItem.SRSOverrides = cboWMSSRSOverride.EditValue
            End If
        Catch
        End Try
    End Sub

    Private Sub txtWMSURL_Validated(sender As Object, e As EventArgs) Handles txtWMSURL.Validated
        Try
            Dim oItem As cWMSPlaceHolder = tvWMSs.GetFocusedObject
            oItem.URL = txtWMSURL.EditValue
            tvWMSLayer.DataSource = oItem.GetLayers
            Call tvWMSLayer_Validating(tvWMSLayer, New CancelEventArgs)
        Catch
        End Try
    End Sub

    Private Sub tvWMSLayer_Validated(sender As Object, e As EventArgs) Handles tvWMSLayer.Validated
        Try
            Dim oItem As cWMSPlaceHolder = tvWMSs.GetFocusedObject
            Call oItem.SetLayers(tvWMSLayer.DataSource)
        Catch
        End Try
    End Sub

    Private Sub txtWMSURL_Validating(sender As Object, e As CancelEventArgs) Handles txtWMSURL.Validating
        If txtWMSURL.ValidateIfNull() Then
            Dim sURL As String = ("" & txtWMSURL.EditValue).trim
        End If
    End Sub

    Private Sub txtWMSName_Validating(sender As Object, e As CancelEventArgs) Handles txtWMSName.Validating
        e.Cancel = Not txtWMSName.ValidateIfNull()
    End Sub

    Private Sub tvWMSLayer_Validating(sender As Object, e As CancelEventArgs) Handles tvWMSLayer.Validating
        If tvWMSLayer.GetAllCheckedNodes.Count = 0 AndAlso tvWMSLayer.AllNodesCount > 0 Then
            tvWMSLayer.SetColumnError(colWMSLayerName, "invalid", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default)
        Else
            tvWMSLayer.SetColumnError(colWMSLayerName, "")
        End If
    End Sub

    Private Sub btnWMSAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnWMSAdd.ItemClick
        Dim sName As String = ("" & UIHelpers.Dialogs.TextInputBox(Me, modMain.GetLocalizedString("surface.addwms.prompt"), modMain.GetLocalizedString("surface.addwms.title"))).trim
        If sName <> "" Then
            Dim oNewItem As UIHelpers.cWMSPlaceHolder = DirectCast(tvWMSs.DataSource, UIHelpers.cWMSsBindingList).Add(sName)
            Call tvWMSs.SetFocusedObject(oNewItem)
        End If
    End Sub

    Private Sub btnWMSDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnWMSDelete.ItemClick
        Dim oItem As cWMSPlaceHolder = tvWMSs.GetFocusedObject
        If oItem IsNot Nothing Then
            If cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("surface.warning5"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("surface.warningtitle")) = MsgBoxResult.Yes Then
                Call DirectCast(tvWMSs.DataSource, UIHelpers.cWMSsBindingList).Remove(oItem)
            End If
        End If
    End Sub

    Private Sub btnWMSClear_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnWMSClear.ItemClick
        Call DirectCast(tvWMSs.DataSource, UIHelpers.cWMSsBindingList).Clear()
    End Sub

    Private Sub txtOrthophotoName_Validating(sender As Object, e As CancelEventArgs) Handles txtOrthophotoName.Validating
        e.Cancel = Not txtOrthophotoName.ValidateIfNull
    End Sub

    Private Sub txtElevationName_Validating(sender As Object, e As CancelEventArgs) Handles txtElevationName.Validating
        e.Cancel = Not txtElevationName.ValidateIfNull
    End Sub

    Private Sub btnElevationCreateOrthophotoFromWMSItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim oWMSItem As UIHelpers.cWMSPlaceHolder = e.Item.Tag(0)
        Using frmAOPWMS As frmSurfaceAddOrthoPhotoFromWMS = New frmSurfaceAddOrthoPhotoFromWMS(oWMSItem.WMS.Name)
            With frmAOPWMS
                If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    Dim sName As String = "" & .txtName.EditValue
                    Dim oBackground As Color = .txtBackgroundColor.EditValue
                    Dim iRatio As Integer = .txtRatio.Value
                    Dim oElevationItem As UIHelpers.cElevationPlaceHolder = e.Item.Tag(1)
                    Dim oTL As cCoordinate = oElevationItem.Elevation.GetCoordinate(cElevation.GetCoordinateCornerEnum.TopLeft)
                    Dim oBR As cCoordinate = oElevationItem.Elevation.GetCoordinate(cElevation.GetCoordinateCornerEnum.BottomRight)
                    Try
                        Using oImage As Image = oWMSItem.WMS.GetImage(oTL, oBR, iRatio, oBackground)
                            Call pSelectTabByIndex(14)
                            Dim oOrthophotoItem As UIHelpers.cOrthophotoPlaceHolder = DirectCast(tvOrthophotos.DataSource, UIHelpers.cOrthophotosBindingList).Add(oImage, sName, oTL, iRatio, iRatio)
                            Call tvOrthophotos.SetFocusedObject(oOrthophotoItem)
                            Call tvOrthophotos.Focus()
                        End Using
                    Catch ex As Exception
                        'Call pPopupShow("warning", modMain.GetLocalizedString("surface.textpart11"), "")
                    End Try
                    Cursor = Cursors.Default
                End If
            End With
        End Using
    End Sub

    Private Sub pElevationRebindOrthophotoFromWMSMenu()
        Call btnElevationCreateOrthophotoFromWMS.ClearItems
        For Each oWMSItem As UIHelpers.cWMSPlaceHolder In DirectCast(tvWMSs.DataSource, UIHelpers.cWMSsBindingList)
            If oWMSItem.IsValid Then
                Dim oItem As DevExpress.XtraBars.BarButtonItem = New DevExpress.XtraBars.BarButtonItem
                oItem.Caption = oWMSItem.Name
                oItem.ImageOptions.SvgImage = My.Resources.map_wms
                oItem.Tag = {oWMSItem, tvElevations.GetFocusedObject}
                AddHandler oItem.ItemClick, AddressOf btnElevationCreateOrthophotoFromWMSItem_ItemClick
                Call btnElevationCreateOrthophotoFromWMS.AddItem(oItem)
            End If
        Next
        'btnElevationCreateOrthophotoFromWMS.Enabled = btnElevationCreateOrthophotoFromWMS.ItemLinks.Count > 0
    End Sub

    Private Sub tvWMSLayer_AfterCheckNode(sender As Object, e As DevExpress.XtraTreeList.NodeEventArgs) Handles tvWMSLayer.AfterCheckNode
        DirectCast(tvWMSLayer.GetFocusedObject, cWMSLayer).Selected = e.Node.Checked
        Dim oItem As cWMSPlaceHolder = tvWMSs.GetFocusedObject
        Call oItem.SetLayers(tvWMSLayer.DataSource)
        tvWMSLayer_Validating(sender, New CancelEventArgs)
    End Sub

    Private Sub btnOrthophotoExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnOrthophotoExport.ItemClick
        Dim oItem As cOrthophotoPlaceHolder = tvOrthophotos.GetFocusedObject
        If oItem IsNot Nothing Then
            Call UIHelpers.Dialogs.SaveImage(Me, oItem.Orthophoto.Photo)
        End If
    End Sub

    Private Sub btnElevationFromOrthophoto_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnElevationFromOrthophoto.ItemClick
        Cursor = Cursors.WaitCursor
        Dim oOrthophoto As cOrthoPhoto = DirectCast(tvOrthophotos.GetFocusedObject, UIHelpers.cOrthophotoPlaceHolder).Orthophoto
        Using frmEFO As frmSurfaceAddElevationFromOrthoPhoto = New frmSurfaceAddElevationFromOrthoPhoto(oOrthophoto.Name)
            AddHandler frmEFO.GetHue, AddressOf frmEFO_GetHue
            If frmEFO.ShowDialog(Me) = DialogResult.OK Then
                Dim sName As String = frmEFO.txtName.EditValue

                Dim oImage As Bitmap = oOrthophoto.Photo
                Dim iRows As Integer = oImage.Height
                Dim iColumns As Integer = oImage.Width
                Dim oData(iRows, iColumns) As Single

                Select Case frmEFO.cboMode.SelectedIndex
                    Case 0  'hue
                        'red=0
                        'green=120...see paint net for scale...use scale on ui and add a reverse flag
                        Dim bCounterclockwise As Boolean = frmEFO.chkHueCounterclockwise.Checked
                        Dim sMinHue As Single = frmEFO.txtHueColorFrom.Color.GetHue
                        Dim sMinAlt As Single = frmEFO.txtHueAltFrom.EditValue
                        Dim sMaxHue As Single = frmEFO.txtHueColorTo.Color.GetHue
                        Dim sMaxAlt As Single = frmEFO.txtHueAltTo.EditValue
                        Dim sDeltaAlt As Single = sMaxAlt - sMinAlt
                        Dim sDeltaHue As Single = modPaint.GetAngleDiff(sMinHue, sMaxHue, bCounterclockwise)
                        If bCounterclockwise Then
                            If sMinHue < sMaxHue Then
                                sMinHue += 260
                            End If
                        Else
                            If sMinHue > sMaxHue Then
                                sMaxHue += 360
                            End If
                        End If

                        Dim iProgressIndex As Integer = 0
                        Dim iProgressCount As Integer = iRows * iColumns
                        Call oSurvey.RaiseOnProgressEvent("elevation.fromorthophoto", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, modMain.GetLocalizedString("surface.progressbegin5"), 0, cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageLoad)
                        For iRow As Integer = 0 To iRows - 1
                            For icolumn As Integer = 0 To iColumns - 1
                                iProgressIndex += 1
                                If iProgressIndex Mod 2000 = 0 Then Call oSurvey.RaiseOnProgressEvent("elevation.fromorthophoto", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("surface.progress5"), iProgressIndex / iProgressCount)
                                Dim sPseutoHeight As Single = oImage.GetPixel(icolumn, iRow).GetHue '  modPaint.GrayColor(oImage.GetPixel(icolumn, iRow)).R * 10
                                Dim sAlt As Single
                                If bCounterclockwise Then
                                    sAlt = sMinAlt + (((sMaxHue - sPseutoHeight) / sDeltaHue) * sDeltaAlt)
                                Else
                                    sAlt = sMinAlt + (((sPseutoHeight - sMinHue) / sDeltaHue) * sDeltaAlt)
                                End If
                                oData(iRow, icolumn) = sAlt
                            Next
                        Next
                        Call oSurvey.RaiseOnProgressEvent("elevation.fromorthophoto", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.End, modMain.GetLocalizedString("surface.progressend5"), 0)
                End Select

                Call pSelectTabByIndex(13)
                Dim oNewItem As UIHelpers.cElevationPlaceHolder = DirectCast(tvElevations.DataSource, UIHelpers.cElevationsBindingList).Add(sName, oOrthophoto.GetCoordinate(cOrthoPhoto.GetCoordinateCornerEnum.BottomLeft), iRows, iColumns, oOrthophoto.XSize, oOrthophoto.YSize, oOrthophoto.System, oData, cElevation.ColorSchemaEnum.BlackToWhite)
                Call tvElevations.SetFocusedObject(oNewItem)
                Call tvElevations.Focus()
            End If
            RemoveHandler frmEFO.GetHue, AddressOf frmEFO_GetHue
        End Using

        Cursor = Cursors.Default
    End Sub

    Private Sub frmEFO_GetHue(sender As Object, e As frmSurfaceAddElevationFromOrthoPhoto.GetHueEventArgs)
        Cursor = Cursors.WaitCursor
        Dim oOrthophoto As cOrthoPhoto = DirectCast(tvOrthophotos.GetFocusedObject, UIHelpers.cOrthophotoPlaceHolder).Orthophoto
        Dim oImage As Bitmap = oOrthophoto.Photo
        Dim iRows As Integer = oImage.Height
        Dim iColumns As Integer = oImage.Width

        Dim iProgressIndex As Integer = 0
        Dim iProgressCount As Integer = iRows * iColumns
        Call oSurvey.RaiseOnProgressEvent("elevation.fromorthophoto", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, modMain.GetLocalizedString("surface.progressbegin5"), 0, cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageCalculate)
        For iRow As Integer = 0 To iRows - 1
            For icolumn As Integer = 0 To iColumns - 1
                iProgressIndex += 1
                If iProgressIndex Mod 2000 = 0 Then Call oSurvey.RaiseOnProgressEvent("elevation.fromorthophoto", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("surface.progress5"), iProgressIndex / iProgressCount)
                Dim sHue As Single = oImage.GetPixel(icolumn, iRow).GetHue
                If sHue < e.MinHue Then e.MinHue = sHue
                If sHue > e.MaxHue Then e.MaxHue = sHue
            Next
        Next
        Call oSurvey.RaiseOnProgressEvent("elevation.fromorthophoto", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.End, modMain.GetLocalizedString("surface.progressend5"), 0)
        Cursor = Cursors.Default
    End Sub

    Private Sub chkGradesDistance_CheckedChanged(sender As Object, e As EventArgs) Handles chkGradesDistance.CheckedChanged
        Dim bEnabled As Boolean = chkGradesDistance.Checked
        txtGradesDistance.Enabled = bEnabled
        cboGradesDistanceType.Enabled = bEnabled

        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.DistanceEnabled = chkGradesDistance.EditValue
        Catch
        End Try
    End Sub

    Private Sub chkGradesBearing_CheckedChanged(sender As Object, e As EventArgs) Handles chkGradesBearing.CheckedChanged
        Dim bEnabled As Boolean = chkGradesBearing.Checked
        txtGradesBearing.Enabled = bEnabled
        cboGradesBearingType.Enabled = bEnabled

        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.BearingEnabled = chkGradesBearing.EditValue
        Catch
        End Try
    End Sub

    Private Sub chkGradesInclination_CheckedChanged(sender As Object, e As EventArgs) Handles chkGradesInclination.CheckedChanged
        Dim bEnabled As Boolean = chkGradesInclination.Checked
        txtGradesInclination.Enabled = bEnabled
        cboGradesInclinationType.Enabled = bEnabled

        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.InclinationEnabled = chkGradesInclination.EditValue
        Catch
        End Try
    End Sub

    Private Sub chkGradesDepth_CheckedChanged(sender As Object, e As EventArgs) Handles chkGradesDepth.CheckedChanged
        Dim bEnabled As Boolean = chkGradesDepth.Checked
        txtGradesDepth.Enabled = bEnabled
        cboGradesDepthType.Enabled = bEnabled

        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.DepthEnabled = chkGradesDepth.EditValue
        Catch
        End Try
    End Sub

    Private Sub chkGradesX_CheckedChanged(sender As Object, e As EventArgs) Handles chkGradesX.CheckedChanged
        Dim bEnabled As Boolean = chkGradesX.Checked
        txtGradesX.Enabled = bEnabled
        cboGradesXType.Enabled = bEnabled

        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.XEnabled = chkGradesX.EditValue
        Catch
        End Try
    End Sub

    Private Sub chkGradesY_CheckedChanged(sender As Object, e As EventArgs) Handles chkGradesY.CheckedChanged
        Dim bEnabled As Boolean = chkGradesY.Checked
        txtGradesY.Enabled = bEnabled
        cboGradesYType.Enabled = bEnabled

        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.YEnabled = chkGradesY.EditValue
        Catch
        End Try
    End Sub

    Private Sub chkGradesZ_CheckedChanged(sender As Object, e As EventArgs) Handles chkGradesZ.CheckedChanged
        Dim bEnabled As Boolean = chkGradesZ.Checked
        txtGradesZ.Enabled = bEnabled
        cboGradesZType.Enabled = bEnabled

        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.ZEnabled = chkGradesZ.EditValue
        Catch
        End Try
    End Sub

    Private Sub tvGrades_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles tvGrades.FocusedNodeChanged
        Dim oGrade As UIHelpers.cGradePlaceHolder = tvGrades.GetFocusedObject
        If oGrade Is Nothing Then
            lblGradesID.Enabled = False
            txtGradesID.Enabled = False
            lblGradesDescription.Enabled = False
            txtGradesDescription.Enabled = False

            chkGradesDistance.Enabled = False
            chkGradesBearing.Enabled = False
            chkGradesDepth.Enabled = False
            chkGradesInclination.Enabled = False
            chkGradesX.Enabled = False
            chkGradesY.Enabled = False
            chkGradesZ.Enabled = False
            tabGradesDetails.Enabled = False

            btnGradesDelete.Enabled = False
        Else
            lblGradesID.Enabled = True
            txtGradesID.Enabled = True
            lblGradesDescription.Enabled = True
            txtGradesDescription.Enabled = True

            chkGradesDistance.Enabled = True
            chkGradesBearing.Enabled = True
            chkGradesDepth.Enabled = True
            chkGradesInclination.Enabled = True
            chkGradesX.Enabled = True
            chkGradesY.Enabled = True
            chkGradesZ.Enabled = True
            tabGradesDetails.Enabled = True

            txtGradesID.EditValue = oGrade.ID
            txtGradesDescription.EditValue = oGrade.Description

            chkGradesBearing.EditValue = oGrade.BearingEnabled
            txtGradesBearing.EditValue = oGrade.Bearing
            cboGradesBearingType.SelectedIndex = oGrade.BearingType
            chkGradesInclination.EditValue = oGrade.InclinationEnabled
            txtGradesInclination.EditValue = oGrade.Inclination
            cboGradesInclinationType.SelectedIndex = oGrade.InclinationType
            chkGradesDistance.EditValue = oGrade.DistanceEnabled
            txtGradesDistance.EditValue = oGrade.Distance
            cboGradesDistanceType.SelectedIndex = oGrade.DistanceType
            chkGradesDepth.EditValue = oGrade.DepthEnabled
            txtGradesDepth.EditValue = oGrade.Depth
            cboGradesDepthType.SelectedIndex = oGrade.DepthType
            chkGradesX.EditValue = oGrade.XEnabled
            txtGradesX.EditValue = oGrade.X
            cboGradesXType.SelectedIndex = oGrade.XType
            chkGradesY.EditValue = oGrade.YEnabled
            txtGradesY.EditValue = oGrade.Y
            cboGradesYType.SelectedIndex = oGrade.YType
            chkGradesZ.EditValue = oGrade.ZEnabled
            txtGradesZ.EditValue = oGrade.Z
            cboGradesZType.SelectedIndex = oGrade.ZType

            Call pGradesRebindUsedBy(oGrade)
        End If

        'btngradesdeleteall.Enabled = tvGrades.Nodes.Count > 0
    End Sub

    Private Sub pGradesRebindUsedBy(Optional Grade As UIHelpers.cGradePlaceHolder = Nothing)
        If Grade Is Nothing Then
            Grade = tvGrades.GetFocusedObject
        End If
        tvGradesUsedBy.DataSource = DirectCast(tvSessions.DataSource, UIHelpers.cSessionsEditBindingList).Where(Function(oSession) Grade IsNot Nothing AndAlso oSession.Grade = Grade.ID).ToList
        btnGradesDelete.Enabled = Grade IsNot Nothing AndAlso tvGradesUsedBy.DataSource.count = 0
    End Sub

    Private Sub txtGradesDescription_Validated(sender As Object, e As EventArgs) Handles txtGradesDescription.Validated
        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.Description = txtGradesDescription.EditValue
            Call tvGrades.RefreshFocusedObject
        Catch
        End Try
    End Sub

    Private Sub txtGradesDistance_Validated(sender As Object, e As EventArgs) Handles txtGradesDistance.Validated
        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.Distance = txtGradesDistance.EditValue
        Catch
        End Try
    End Sub

    Private Sub txtGradesBearing_Validated(sender As Object, e As EventArgs) Handles txtGradesBearing.Validated
        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.Bearing = txtGradesBearing.EditValue
        Catch
        End Try
    End Sub

    Private Sub txtGradesInclination_Validated(sender As Object, e As EventArgs) Handles txtGradesInclination.Validated
        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.Inclination = txtGradesInclination.EditValue
        Catch
        End Try
    End Sub

    Private Sub txtGradesDepth_Validated(sender As Object, e As EventArgs) Handles txtGradesDepth.Validated
        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.Depth = txtGradesDepth.EditValue
        Catch
        End Try
    End Sub

    Private Sub txtGradesX_Validated(sender As Object, e As EventArgs) Handles txtGradesX.Validated
        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.X = txtGradesX.EditValue
        Catch
        End Try
    End Sub

    Private Sub txtGradesY_Validated(sender As Object, e As EventArgs) Handles txtGradesY.Validated
        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.Y = txtGradesY.EditValue
        Catch
        End Try
    End Sub

    Private Sub txtGradesZ_Validated(sender As Object, e As EventArgs) Handles txtGradesZ.Validated
        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.Z = txtGradesZ.EditValue
        Catch
        End Try
    End Sub

    Private Sub cboGradesDistanceType_Validated(sender As Object, e As EventArgs) Handles cboGradesDistanceType.Validated
        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.DistanceType = cboGradesDistanceType.SelectedIndex
        Catch
        End Try
    End Sub

    Private Sub cboGradesBearingType_Validated(sender As Object, e As EventArgs) Handles cboGradesBearingType.Validated
        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.BearingType = cboGradesBearingType.SelectedIndex
        Catch
        End Try
    End Sub

    Private Sub cboGradesInclinationType_Validated(sender As Object, e As EventArgs) Handles cboGradesInclinationType.Validated
        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.InclinationType = cboGradesInclinationType.SelectedIndex
        Catch
        End Try
    End Sub

    Private Sub cboGradesDepthType_Validated(sender As Object, e As EventArgs) Handles cboGradesDepthType.Validated
        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.DepthType = cboGradesDepthType.SelectedIndex
        Catch
        End Try
    End Sub

    Private Sub cboGradesXType_Validated(sender As Object, e As EventArgs) Handles cboGradesXType.Validated
        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.XType = cboGradesXType.SelectedIndex
        Catch
        End Try
    End Sub

    Private Sub cboGradesYType_Validated(sender As Object, e As EventArgs) Handles cboGradesYType.Validated
        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.YType = cboGradesYType.SelectedIndex
        Catch
        End Try
    End Sub

    Private Sub cboGradesZType_Validated(sender As Object, e As EventArgs) Handles cboGradesZType.Validated
        Try
            Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
            oItem.ZType = cboGradesZType.SelectedIndex
        Catch
        End Try
    End Sub

    Private Sub btnGradesAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnGradesAdd.ItemClick
        Dim oNewItem As UIHelpers.cGradePlaceHolder = DirectCast(tvGrades.DataSource, UIHelpers.cGradeEditBindingList).Add
        Call tvGrades.SetFocusedObject(oNewItem)
    End Sub

    Private Sub btnGradesDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnGradesDelete.ItemClick
        Dim oItem As cGradePlaceHolder = tvGrades.GetFocusedObject
        If oItem IsNot Nothing Then
            If cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("grades.warning1"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("grades.warningtitle")) = MsgBoxResult.Yes Then
                Call DirectCast(tvGrades.DataSource, UIHelpers.cGradeEditBindingList).Remove(oItem)
            End If
        End If
    End Sub

    Private Sub tvGradesUsedBy_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles tvGradesUsedBy.FocusedNodeChanged
        btnGradesUsedBySelectSession.Enabled = e.Node IsNot Nothing
    End Sub

    Private Sub btnGradesUsedBySelectSession_Click(sender As Object, e As EventArgs) Handles btnGradesUsedBySelectSession.Click
        Dim oSession As UIHelpers.cSessionEditPlaceHolder = tvGradesUsedBy.GetFocusedObject
        If oSession IsNot Nothing Then
            Call tvSessions.SetFocusedObject(oSession)
            Call pSelectTabByIndex(6)
        End If
    End Sub

    Private Sub cboSessionDepthType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSessionDepthType.SelectedIndexChanged
        chkSessionInclinationDirection.Visible = (cboSessionDepthType.SelectedIndex = 0 OrElse cboSessionDepthType.SelectedIndex = 1)
    End Sub

    Private Sub btnHighlightExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnHighlightExport.ItemClick
        Try
            Dim oCI As cHighlightPlaceholder = tvHighlights.GetFocusedObject
            Using oSFD As SaveFileDialog = New SaveFileDialog
                With oSFD
                    .OverwritePrompt = True
                    .Filter = GetLocalizedString("main.filetypeCHIGHLIGHTX") & " (*.CHighlightX)|*.CHighlightX"
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        Dim oXML As XmlDocument = New XmlDocument
                        Dim oXMLRoot As XmlElement = oXML.CreateElement("chighlight")

                        Call oXMLRoot.SetAttribute("name", oCI.Name)
                        Call oXMLRoot.SetAttribute("color", oCI.Color.ToArgb)
                        Call oXMLRoot.SetAttribute("size", modNumbers.NumberToString(oCI.Size))
                        Call oXMLRoot.SetAttribute("opacity", oCI.Opacity)
                        Call oXMLRoot.SetAttribute("applyto", oCI.ApplyTo.ToString("D"))
                        oXMLRoot.InnerText = oCI.Condition
                        Call oXML.AppendChild(oXMLRoot)
                        Call oXML.Save(oSFD.FileName)
                    End If
                End With
            End Using
        Catch
        End Try
    End Sub

    Private Sub btnHighlightImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnHighlightImport.ItemClick
        Using oOFD As OpenFileDialog = New OpenFileDialog
            With oOFD
                .Filter = GetLocalizedString("main.filetypeCHIGHLIGHTX") & " (*.CHighlightX)|*.CHighlightX"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim oXML As XmlDocument = New XmlDocument
                    Call oXML.Load(oOFD.FileName)
                    Dim oXMLRoot As XmlElement = oXML.Item("chighlight")

                    Dim iApplyTo As Properties.cHighlightsDetail.ApplyToEnum = oXMLRoot.GetAttribute("applyto")
                    Dim oItem As cHighlightPlaceholder = pHighlightAdd(iApplyTo)

                    oItem.Name = oXMLRoot.GetAttribute("name")
                    oItem.Color = Color.FromArgb(oXMLRoot.GetAttribute("color"))
                    oItem.Size = modNumbers.StringToSingle(oXMLRoot.GetAttribute("size"))
                    oItem.Opacity = oXMLRoot.GetAttribute("opacity")
                    oItem.Condition = oXMLRoot.InnerText

                    Call tvHighlights.RefreshFocusedObject
                End If
            End With
        End Using
    End Sub

    Private Sub btnOrthophotosPreviewNewReduced25_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnOrthophotosPreviewNewReduced25.ItemClick
        Dim oItem As cOrthophotoPlaceHolder = tvOrthophotos.GetFocusedObject
        If oItem IsNot Nothing Then
            Cursor = Cursors.WaitCursor
            Dim oNewItem As UIHelpers.cOrthophotoPlaceHolder = DirectCast(tvOrthophotos.DataSource, UIHelpers.cOrthophotosBindingList).Add(oItem, 25)
            Cursor = Cursors.Default
            Call tvOrthophotos.SetFocusedObject(oNewItem)
        End If
    End Sub

    Private Sub btnOrthophotosPreviewNewReduced33_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnOrthophotosPreviewNewReduced33.ItemClick
        Dim oItem As cOrthophotoPlaceHolder = tvOrthophotos.GetFocusedObject
        If oItem IsNot Nothing Then
            Cursor = Cursors.WaitCursor
            Dim oNewItem As UIHelpers.cOrthophotoPlaceHolder = DirectCast(tvOrthophotos.DataSource, UIHelpers.cOrthophotosBindingList).Add(oItem, 33)
            Cursor = Cursors.Default
            Call tvOrthophotos.SetFocusedObject(oNewItem)
        End If
    End Sub

    Private Sub btnOrthophotosPreviewNewReduced50_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnOrthophotosPreviewNewReduced50.ItemClick
        Dim oItem As cOrthophotoPlaceHolder = tvOrthophotos.GetFocusedObject
        If oItem IsNot Nothing Then
            Cursor = Cursors.WaitCursor
            Dim oNewItem As UIHelpers.cOrthophotoPlaceHolder = DirectCast(tvOrthophotos.DataSource, UIHelpers.cOrthophotosBindingList).Add(oItem, 50)
            Cursor = Cursors.Default
            Call tvOrthophotos.SetFocusedObject(oNewItem)
        End If
    End Sub

    Private Sub optGPSRefPointOnOrigin_CheckedChanged(sender As Object, e As EventArgs) Handles optGPSRefPointOnOrigin.CheckedChanged
        If optGPSRefPointOnOrigin.Checked Then
            cboGPSCustomRefPoint.Enabled = False
        Else
            cboGPSCustomRefPoint.Enabled = True
        End If
    End Sub

    Private Sub optGPSCustomRefPoint_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optGPSCustomRefPoint.CheckedChanged
        If optGPSRefPointOnOrigin.Checked Then
            cboGPSCustomRefPoint.Enabled = False
        Else
            cboGPSCustomRefPoint.Enabled = True
        End If
    End Sub

    Private Sub cboOrigin_Popup(sender As Object, e As PopupEventArgs) Handles cboOrigin.Popup
        Cursor = Cursors.WaitCursor
        Call e.AddRange(oSurvey.TrigPoints.GetStations(e.AllowSplay).ToList)
        Cursor = Cursors.Default
    End Sub

    Private Sub cboCaveInfoExtendStart_EditValueMissing(sender As Object, e As EditValueMissingEventArgs) Handles cboCaveInfoExtendStart.EditValueMissing
        Dim oTrigpoint As cSurvey.cTrigPoint = oSurvey.TrigPoints(e.Value)
        If oTrigpoint IsNot Nothing Then
            Call e.Add(oTrigpoint)
        End If
    End Sub
End Class