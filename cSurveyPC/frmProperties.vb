Imports cSurveyPC.cSurvey
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Scripting
Imports System.ComponentModel

Friend Class frmProperties
    Private oSurvey As cSurvey.cSurvey

    Friend Event OnSegmentSelect(Sender As frmProperties, Segment As cSegment)
    Friend Event OnApply(ByVal Sender As frmProperties)

    Private MustInherit Class PlaceHolder(Of SourceType)
        Public Source As SourceType
        Public Created As Boolean
        Public Deleted As Boolean
    End Class

    Private Class cHighlightPlaceholder
        Inherits PlaceHolder(Of Properties.cHighlightsDetail)
        Public Const Type As String = "highlight"

        Public ID As String
        Public Name As String
        Public Color As Color
        Public Size As Single
        Public Opacity As Byte
        Public ApplyTo As Integer
        Public Condition As String = ""
        Public System As Boolean
    End Class

    Private Class cDefaultSessionPlaceHolder
        Inherits cSessionPlaceHolder

        Private sType As String = "defaultsession"

        Public Overrides ReadOnly Property Type As String
            Get
                Return sType
            End Get
        End Property
    End Class

    Private Class cSessionPlaceHolder
        Inherits PlaceHolder(Of cSession)
        Private sType As String = "session"

        Public Overridable ReadOnly Property Type As String
            Get
                Return sType
            End Get
        End Property

        Public Name As String

        Public ReadOnly Property ID As String
            Get
                Return Strings.Format([Date], "yyyyMMdd") & "_" & Description.Replace(" ", "_").ToLower
            End Get
        End Property

        Public ReadOnly Property FormattedID As String
            Get
                Return Strings.Format([Date], "dd-MM-yyyy") & " " & Description
            End Get
        End Property

        Public [Date] As Date
        Public Description As String
        Public Club As String
        Public Note As String
        Public Team As String
        Public Designer As String

        Public DataFormat As cSegment.DataFormatEnum
        Public DistanceType As cSegment.DistanceTypeEnum
        Public BearingType As cSegment.BearingTypeEnum
        Public BearingDirection As cSegment.MeasureDirectionEnum
        Public InclinationType As cSegment.InclinationTypeEnum
        Public InclinationDirection As cSegment.MeasureDirectionEnum
        Public DepthType As cSegment.DepthTypeEnum

        Public Grade As String

        Public NordType As cSegment.NordTypeEnum
        Public Declination As Single
        Public declinationenabled As Boolean

        Public SideMeasuresType As cSegment.SideMeasuresTypeEnum
        Public SideMeasuresReferTo As cSegment.SideMeasuresReferToEnum

        Public VThreshold As Integer
        Public VThresholdEnabled As Boolean

        Public Color As Color
    End Class

    Private Class cCaveInfoPlaceHolder
        Inherits PlaceHolder(Of cCaveInfo)
        Public Const Type As String = "cave"
        Public Description As String
        Public Name As String
        Public ID As String
        Public Color As Color
        Public SurfaceProfileShow As cISurfaceProfile.SurfaceProfileShowEnum
        Public Locked As Boolean
        Public ExtendStart As String = ""
        Public Priority As Integer?
        Public ParentConnection As cConnectionDef
        Public Connection As cConnectionDef
    End Class

    Private Class cCaveInfoBranchPlaceHolder
        Inherits PlaceHolder(Of cCaveInfoBranch)
        Public Const Type As String = "branch"
        Public Name As String
        Public Color As Color
        Public Description As String
        Public SurfaceProfileShow As cISurfaceProfile.SurfaceProfileShowEnum
        Public Locked As Boolean
        Public ExtendStart As String = ""
        Public Priority As Integer?
        Public ParentConnection As cConnectionDef
        Public Connection As cConnectionDef
    End Class

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
        iFunctionLanguage = FunctionLanguage

        tabCaveInfoCalculateOptions.Visible = bIsInDebug

        'pnlDepth.Location = pnlInclination.Location
        pnlSessionDepth.Location = pnlSessionInclination.Location

        On Error Resume Next
        oSurvey = Survey
        With oSurvey.Properties
            Call pGradesLoad()
            Call pUTMLoad()

            btnCaveInfoSelectSegment.Enabled = Owner Is frmMain

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

            cboDefGrade.Text = .DefGrade
            cboDefAccuracy.Text = .DefAccuracy

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

            optGPSRefPointOnOrigin.Checked = .GPS.RefPointOnOrigin
            optGPSCustomRefPoint.Checked = Not optGPSRefPointOnOrigin.Checked

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

            cboClipBorder.SelectedIndex = .DesignProperties.GetValue("clipborder", oSurvey.GetGlobalSetting("design.clipborder", cSurvey.Design.cClippingRegions.ClipBorderEnum.ClipBorder))
            cboClipAdvancedClipart.SelectedIndex = .DesignProperties.GetValue("clippingforadvancedbrush", oSurvey.GetGlobalSetting("clippingforadvancedbrush", cSurvey.Drawings.cIRegion.RegionTypeEnum.GDI))

            cboLineType.SelectedIndex = .DesignProperties.GetValue("LineType", oSurvey.GetGlobalSetting("design.linetype", cSurvey.Design.Items.cIItemLine.LineTypeEnum.Splines))

            cboSplayMode.SelectedIndex = .SplayMode
            'chkBindSplaySegment.Checked = .BindSplaySegment
            chkBindCrossSection.Checked = .BindCrossSection

            'design
            txtBaseLineWidthScaleFactor.Value = .DesignProperties.GetValue("BaseLineWidthScaleFactor", 0.01)
            txtBaseHeavyLinesScaleFactor.Value = .DesignProperties.GetValue("BaseHeavyLinesScaleFactor", 8)
            txtBaseMediumLinesScaleFactor.Value = .DesignProperties.GetValue("BaseMediumLinesScaleFactor", 3)
            txtBaseLightLinesScaleFactor.Value = .DesignProperties.GetValue("BaseLightLinesScaleFactor", 1)
            txtBaseUltraLightLinesScaleFactor.Value = .DesignProperties.GetValue("BaseUltraLightLinesScaleFactor", 0.3)
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
            picPlotNoteTextColor.BackColor = .DesignProperties.GetValue("PlotNoteTextColor", Color.Black)

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
            For Each oElevation As cSurvey.Surface.cElevation In oSurvey.Surface.Elevations
                Call cbosurfaceprofileelevation.Items.Add(New cComboItem(oElevation, oElevation.Name))
                If oElevation Is .SurfaceProfileElevation Then
                    cbosurfaceprofileelevation.SelectedIndex = cbosurfaceprofileelevation.Items.Count - 1
                End If
            Next
            If cbosurfaceprofileelevation.Items.Count > 0 Then
                If cbosurfaceprofileelevation.SelectedItem Is Nothing Then
                    cbosurfaceprofileelevation.SelectedIndex = 0
                End If
                pnlSurfaceProfile.Enabled = .GPS.Enabled
            Else
                pnlSurfaceProfile.Enabled = False
            End If

            Call pSessionsLoad()
            Call pCavesLoad()
            Call pHighlightsLoad()
        End With

        If Not SelectedTabIndex Is Nothing Then
            tabInfo.SelectedIndex = SelectedTabIndex
        End If
    End Sub

    Private Sub pGradesLoad()
        'Call cboGrade.Items.Add("")
        Call cboSessionGrade.Items.Add("")
        For Each oGrade As cGrade In oSurvey.Grades
            'Call cboGrade.Items.Add(oGrade.Description)
            Call cboSessionGrade.Items.Add(oGrade.Description)
        Next
    End Sub

    Private Sub pOriginsLoad()
        For Each oTrigPoint As cTrigPoint In oSurvey.TrigPoints
            If Not (oTrigPoint.Data.IsSplay Or oTrigPoint.IsSystem) Then
                Call cboOrigin.Items.Add(oTrigPoint.Name)
                Call cboCaveInfoExtendStart.Items.Add(oTrigPoint.Name)
            End If
        Next
        cboOrigin.SelectedItem = oSurvey.Properties.Origin
        cboOrigin.Enabled = oSurvey.Properties.DesignWarpingMode = cSurvey.cSurvey.DesignWarpingModeEnum.None Or (oSurvey.Properties.DesignWarpingMode <> cSurvey.cSurvey.DesignWarpingModeEnum.None And oSurvey.Properties.InversionMode = cSurvey.cSurvey.InversioneModeEnum.Absolute)
        'cboInversionMode.Enabled = cboOrigin.Enabled
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

    Private Sub pCaveBranchesLoad(ParentBranches As cCaveInfoBranches, ParentNodes As TreeNodeCollection)
        For Each oBranch As cCaveInfoBranch In ParentBranches
            Dim oBranchNode As TreeNode = ParentNodes.Add(oBranch.Name)
            oBranchNode.Name = oBranch.Name
            Dim oCIB As cCaveInfoBranchPlaceHolder = New cCaveInfoBranchPlaceHolder
            oCIB.Name = oBranch.Name
            oCIB.Color = oBranch.Color
            oCIB.Description = oBranch.Description
            oCIB.SurfaceProfileShow = oBranch.SurfaceProfileShow
            oCIB.Locked = oBranch.Locked
            oCIB.ExtendStart = oBranch.ExtendStart
            oCIB.Priority = oBranch.Priority
            oCIB.ParentConnection = oBranch.ParentConnection
            oCIB.Connection = oBranch.Connection
            oCIB.Source = oBranch
            oBranchNode.Tag = oCIB
            If oCIB.ExtendStart = "" Then
                oBranchNode.SelectedImageKey = "branch"
                oBranchNode.ImageKey = "branch"
            Else
                oBranchNode.SelectedImageKey = "origin"
                oBranchNode.ImageKey = "origin"
            End If

            Call pCaveBranchesLoad(oBranch.Branches, oBranchNode.Nodes)
        Next
    End Sub

    Private Sub pCavesLoad()
        Call tvCaveInfos.Nodes.Clear()
        For Each oCaveInfo As cCaveInfo In oSurvey.Properties.CaveInfos
            Dim oCaveNode As TreeNode = tvCaveInfos.Nodes.Add(oCaveInfo.Name)
            oCaveNode.Name = oCaveInfo.Name
            Dim oCI As cCaveInfoPlaceHolder = New cCaveInfoPlaceHolder
            oCI.Description = oCaveInfo.Description
            oCI.Name = oCaveInfo.Name
            oCI.ID = oCaveInfo.ID
            oCI.Color = oCaveInfo.Color
            oCI.SurfaceProfileShow = oCaveInfo.SurfaceProfileShow
            oCI.Locked = oCaveInfo.Locked
            oCI.ExtendStart = oCaveInfo.ExtendStart
            oCI.Priority = oCaveInfo.Priority
            oCI.ParentConnection = oCaveInfo.ParentConnection
            oCI.Connection = oCaveInfo.Connection
            oCI.Source = oCaveInfo
            oCaveNode.Tag = oCI
            If oCI.ExtendStart = "" Then
                oCaveNode.SelectedImageKey = "cave"
                oCaveNode.ImageKey = "cave"
            Else
                oCaveNode.SelectedImageKey = "origin"
                oCaveNode.ImageKey = "origin"
            End If
            Call pCaveBranchesLoad(oCaveInfo.Branches, oCaveNode.Nodes)
            Call oCaveNode.ExpandAll()
        Next

        If tvCaveInfos.Nodes.Count > 0 Then
            tvCaveInfos.SelectedNode = tvCaveInfos.Nodes(0)
        End If

        btnCaveInfoAddCave.Enabled = True
        btnCaveInfoAddBranch.Enabled = tvCaveInfos.Nodes.Count > 0
        btnCaveInfoDelete.Enabled = tvCaveInfos.Nodes.Count > 0
    End Sub

    Private Sub pHighlightsLoad()
        Call tvHighlights.Nodes.Clear()
        For Each oHighlight As Properties.cHighlightsDetail In oSurvey.Properties.HighlightsDetails
            Dim oHighlightNode As TreeNode = tvHighlights.Nodes.Add(oHighlight.ID)
            oHighlightNode.Name = oHighlight.ID
            oHighlightNode.Text = oHighlight.Name
            Dim oCI As cHighlightPlaceholder = New cHighlightPlaceholder
            oCI.ID = oHighlight.ID
            oCI.Name = oHighlight.Name
            oCI.Color = oHighlight.Color
            oCI.Size = oHighlight.Size
            oCI.Opacity = oHighlight.Opacity
            oCI.ApplyTo = oHighlight.ApplyTo
            oCI.Condition = oHighlight.Condition
            oCI.System = oHighlight.System

            oCI.Source = oHighlight
            oHighlightNode.Tag = oCI
            oHighlightNode.SelectedImageKey = "hl"
            oHighlightNode.ImageKey = "hl"
        Next

        If tvHighlights.Nodes.Count > 0 Then
            tvHighlights.SelectedNode = tvHighlights.Nodes(0)
        End If

        btnAddHighlight.Enabled = True
        btnDeleteHighlight.Enabled = tvHighlights.Nodes.Count > 0 AndAlso Not tvHighlights.SelectedNode.Tag.system
    End Sub

    Private Sub pSessionsLoad()
        Call tvSessions.Nodes.Clear()

        Dim oDefaultSessionNode As TreeNode = tvSessions.Nodes.Add("")
        oDefaultSessionNode.Text = modMain.GetLocalizedString("properties.textpart3")

        Dim oDefaultCI As cDefaultSessionPlaceHolder = New cDefaultSessionPlaceHolder

        oDefaultCI.DataFormat = oSurvey.Properties.DataFormat
        oDefaultCI.DistanceType = oSurvey.Properties.DistanceType
        oDefaultCI.BearingType = oSurvey.Properties.BearingType
        oDefaultCI.BearingDirection = oSurvey.Properties.BearingDirection
        oDefaultCI.InclinationType = oSurvey.Properties.InclinationType
        oDefaultCI.InclinationDirection = oSurvey.Properties.InclinationDirection
        oDefaultCI.DepthType = oSurvey.Properties.DepthType

        oDefaultCI.Grade = oSurvey.Properties.Grade

        oDefaultCI.NordType = oSurvey.Properties.NordType
        oDefaultCI.Declination = oSurvey.Properties.Declination
        oDefaultCI.declinationenabled = oSurvey.Properties.DeclinationEnabled

        oDefaultCI.SideMeasuresType = oSurvey.Properties.SideMeasuresType
        oDefaultCI.SideMeasuresReferTo = oSurvey.Properties.SideMeasuresReferTo

        oDefaultCI.VThreshold = oSurvey.Properties.VThreshold
        oDefaultCI.VThresholdEnabled = oSurvey.Properties.VThresholdEnabled

        oDefaultCI.Source = Nothing
        oDefaultSessionNode.Tag = oDefaultCI
        oDefaultSessionNode.SelectedImageKey = "defaultsession"
        oDefaultSessionNode.ImageKey = "defaultsession"

        For Each oSession As cSession In oSurvey.Properties.Sessions
            Dim oSessionNode As TreeNode = tvSessions.Nodes.Add(oSession.ID)
            oSessionNode.Name = oSession.ID
            oSessionNode.Text = oSession.FormattedID
            Dim oCI As cSessionPlaceHolder = New cSessionPlaceHolder
            oCI.Date = oSession.Date
            oCI.Description = oSession.Description
            oCI.Color = oSession.Color

            oCI.Team = oSession.Team
            oCI.Club = oSession.Club
            oCI.Designer = oSession.Designer
            oCI.Note = oSession.Note

            oCI.DataFormat = oSession.DataFormat
            oCI.DistanceType = oSession.DistanceType
            oCI.BearingType = oSession.BearingType
            oCI.BearingDirection = oSession.BearingDirection
            oCI.InclinationType = oSession.InclinationType
            oCI.InclinationDirection = oSession.InclinationDirection
            oCI.DepthType = oSession.DepthType

            oCI.Grade = oSession.Grade

            oCI.NordType = oSession.NordType
            oCI.Declination = oSession.Declination
            oCI.declinationenabled = oSession.DeclinationEnabled

            oCI.SideMeasuresType = oSession.SideMeasuresType
            oCI.SideMeasuresReferTo = oSession.SideMeasuresReferTo

            oCI.VThreshold = oSession.VThreshold
            oCI.VThresholdEnabled = oSession.VThresholdEnabled

            oCI.Source = oSession
            oSessionNode.Tag = oCI
            oSessionNode.SelectedImageKey = "session"
            oSessionNode.ImageKey = "session"
        Next

        btnSessionsAddSession.Enabled = True
        If tvSessions.Nodes.Count > 0 Then
            tvSessions.SelectedNode = tvSessions.Nodes(0)
            Call tvSessions_AfterSelect(tvSessions, New TreeViewEventArgs(tvSessions.SelectedNode))
        Else
            btnSessionsDelete.Enabled = False
        End If
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

            .DefGrade = cboDefGrade.Text
            .DefAccuracy = cboDefAccuracy.Text

            .Note = txtNote.Text

            .Origin = cboOrigin.Text

            .CalculateMode = IIf(chkCalculateMode.Checked, cSurvey.cSurvey.CalculateModeEnum.Automatic, cSurvey.cSurvey.CalculateModeEnum.Manual)
            .CalculateType = cboCalculateType.SelectedIndex
            .RingCorrectionMode = cboRingCorrectionMode.SelectedIndex
            .NordCorrectionMode = cboNordCorrection.SelectedIndex
            '.InversionMode = cboInversionMode.SelectedIndex

            '.DataFormat = cboDataFormat.SelectedIndex
            '.DistanceType = cboDistanceType.SelectedIndex
            '.BearingType = cboBearingType.SelectedIndex
            '.BearingDirection = IIf(chkBearingDirection.Checked, cSegment.MeasureDirectionEnum.Inverted, cSegment.MeasureDirectionEnum.Direct)
            '.InclinationType = cboInclinationType.SelectedIndex
            '.InclinationDirection = IIf(chkInclinationDirection.Checked, cSegment.MeasureDirectionEnum.Inverted, cSegment.MeasureDirectionEnum.Direct)
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

            For Each oSessionNode As TreeNode In tvSessions.Nodes
                Dim oCI As cSessionPlaceHolder = oSessionNode.Tag
                If TypeOf oCI Is cDefaultSessionPlaceHolder Then
                    .DataFormat = oCI.DataFormat
                    .DistanceType = oCI.DistanceType
                    .BearingType = oCI.BearingType
                    .BearingDirection = oCI.BearingDirection
                    .InclinationType = oCI.InclinationType
                    .InclinationDirection = oCI.InclinationDirection
                    .DepthType = oCI.DepthType

                    .Grade = oCI.Grade

                    .NordType = oCI.NordType
                    .DeclinationEnabled = oCI.declinationenabled
                    .Declination = oCI.Declination

                    .SideMeasuresType = oCI.SideMeasuresType
                    .SideMeasuresReferTo = oCI.SideMeasuresReferTo

                    .VThresholdEnabled = oCI.VThresholdEnabled
                    .VThreshold = oCI.VThreshold
                Else
                    If oCI.Deleted And Not oCI.Created Then
                        Call .Sessions.Remove(oCI.ID)
                    ElseIf oCI.Created Then
                        Dim oSession As cSession = .Sessions.Add(oCI.Date, oCI.Description)
                        oSession.Club = oCI.Club
                        oSession.Team = oCI.Team
                        oSession.Designer = oCI.Designer
                        oSession.Note = oCI.Note
                        oSession.Color = oCI.Color

                        oSession.DataFormat = oCI.DataFormat
                        oSession.DistanceType = oCI.DistanceType
                        oSession.BearingType = oCI.BearingType
                        oSession.BearingDirection = oCI.BearingDirection
                        oSession.InclinationType = oCI.InclinationType
                        oSession.InclinationDirection = oCI.InclinationDirection
                        oSession.DepthType = oCI.DepthType

                        oSession.Grade = oCI.Grade

                        oSession.NordType = oCI.NordType
                        oSession.Declination = oCI.Declination
                        oSession.DeclinationEnabled = oCI.declinationenabled

                        oSession.SideMeasuresType = oCI.SideMeasuresType
                        oSession.SideMeasuresReferTo = oCI.SideMeasuresReferTo

                        oSession.VThresholdEnabled = oCI.VThresholdEnabled
                        oSession.VThreshold = oCI.VThreshold
                    Else
                        Dim oSession As cSession = oCI.Source
                        Dim sNewID As String = oCI.ID
                        Dim sOldID As String = oCI.Source.ID
                        If sNewID.ToLower <> sOldID.ToLower Then
                            Call .Sessions.Rename(sOldID, oCI.Date, oCI.Description)
                        End If

                        oSession.Club = oCI.Club
                        oSession.Team = oCI.Team
                        oSession.Designer = oCI.Designer
                        oSession.Note = oCI.Note
                        oSession.Color = oCI.Color

                        oSession.DataFormat = oCI.DataFormat
                        oSession.DistanceType = oCI.DistanceType
                        oSession.BearingType = oCI.BearingType
                        oSession.BearingDirection = oCI.BearingDirection
                        oSession.InclinationType = oCI.InclinationType
                        oSession.InclinationDirection = oCI.InclinationDirection
                        oSession.DepthType = oCI.DepthType

                        oSession.Grade = oCI.Grade

                        oSession.NordType = oCI.NordType
                        oSession.Declination = oCI.Declination
                        oSession.DeclinationEnabled = oCI.declinationenabled

                        oSession.SideMeasuresType = oCI.SideMeasuresType
                        oSession.SideMeasuresReferTo = oCI.SideMeasuresReferTo

                        oSession.VThresholdEnabled = oCI.VThresholdEnabled
                        oSession.VThreshold = oCI.VThreshold
                    End If
                End If
            Next
            Call pSessionsLoad()

            For Each oCaveNode As TreeNode In tvCaveInfos.Nodes
                Dim oCI As cCaveInfoPlaceHolder = oCaveNode.Tag
                If oCI.Deleted And Not oCI.Created Then
                    Call .CaveInfos.Remove(oCI.Name, True)
                ElseIf oCI.Created Then
                    Dim oCaveInfo As cCaveInfo = .CaveInfos.Add(oCI.Name)
                    oCaveInfo.ID = oCI.ID
                    oCaveInfo.Color = oCI.Color
                    oCaveInfo.Description = oCI.Description
                    oCaveInfo.SurfaceProfileShow = oCI.SurfaceProfileShow
                    oCaveInfo.Locked = oCI.Locked
                    oCaveInfo.ExtendStart = oCI.ExtendStart
                    oCaveInfo.Priority = oCI.Priority
                    oCaveInfo.ParentConnection = oCI.ParentConnection
                    oCaveInfo.Connection = oCI.Connection
                    oCI.Source = oCaveInfo
                Else
                    oCI.Source.ID = oCI.ID
                    oCI.Source.Color = oCI.Color
                    oCI.Source.Description = oCI.Description
                    oCI.Source.SurfaceProfileShow = oCI.SurfaceProfileShow
                    oCI.Source.Locked = oCI.Locked
                    oCI.Source.ExtendStart = oCI.ExtendStart
                    oCI.Source.Priority = oCI.Priority
                    oCI.Source.ParentConnection = oCI.ParentConnection
                    oCI.Source.Connection = oCI.Connection
                    Dim sNewName As String = oCI.Name
                    Dim sOldName As String = oCI.Source.Name
                    If sNewName.ToLower <> sOldName.ToLower Then
                        Call .CaveInfos.Rename(sOldName, sNewName, True)
                    End If
                End If
            Next

            For Each oCaveNode As TreeNode In tvCaveInfos.Nodes
                Dim oCI As cCaveInfoPlaceHolder = oCaveNode.Tag
                Call pCaveBranchesSave(oCI.Source.Branches, oCaveNode.Nodes)
            Next
            Call pCavesLoad()

            For Each oHighlightNode As TreeNode In tvHighlights.Nodes
                Dim oCI As cHighlightPlaceholder = oHighlightNode.Tag
                If oCI.Deleted And Not oCI.Created Then
                    Call .HighlightsDetails.Remove(oCI.ID)
                ElseIf oCI.Created Then
                    Dim oHighlight As Properties.cHighlightsDetail = .HighlightsDetails.Add(oCI.Name, oCI.ApplyTo, oCI.Condition)
                    oHighlight.Name = oCI.Name
                    oHighlight.Size = oCI.Size
                    oHighlight.Opacity = oCI.Opacity
                    oHighlight.Color = oCI.Color
                    oHighlight.ApplyTo = oCI.ApplyTo
                    oHighlight.Condition = oCI.Condition
                Else
                    Dim oHighlight As Properties.cHighlightsDetail = oCI.Source
                    oHighlight.Name = oCI.Name
                    oHighlight.Size = oCI.Size
                    oHighlight.Opacity = oCI.Opacity
                    oHighlight.Color = oCI.Color
                    oHighlight.ApplyTo = oCI.ApplyTo
                    oHighlight.Condition = oCI.Condition
                End If
            Next
            Call pHighlightsLoad()

            With .GPS
                .Enabled = chkGPSEnabled.Checked
                .RefPointOnOrigin = optGPSRefPointOnOrigin.Checked
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
            Call .DesignProperties.SetValue("PlotNoteTextColor", picPlotNoteTextColor.BackColor)

            Call .DesignProperties.SetValue("PlotCenterlineVector", IIf(chkPlotCenterlineVectors.Checked, 1, 0))
            Call .DesignProperties.SetValue("PlotCenterlineForceColor", IIf(chkPlotCenterlineForceSegmentColor.Checked, 1, 0))

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
            If cbosurfaceprofileelevation.SelectedItem Is Nothing Then
                .SurfaceProfileElevation = Nothing
            Else
                .SurfaceProfileElevation = cbosurfaceprofileelevation.SelectedItem.source
            End If

            Call oSurvey.SharedSettings.SetValue("loch.showdialog", IIf(chk3dLochShowDialog.Checked, "1", "0"))

            .HistoryEnabled = chkHistoryEnabled.Checked
        End With

        Call oSurvey.RaiseOnPropertiesChanged(cSurvey.cSurvey.OnPropertiesChangedEventArgs.PropertiesChangeSourceEnum.DefaultProperties)
    End Sub

    Private Sub pCaveBranchesSave(ParentBranches As cCaveInfoBranches, ParentNodes As TreeNodeCollection)
        For Each oBranchNode As TreeNode In ParentNodes
            Dim oCIB As cCaveInfoBranchPlaceHolder = oBranchNode.Tag
            If oCIB.Deleted And Not oCIB.Created Then
                Call ParentBranches.Remove(oCIB.Name, True)
            ElseIf oCIB.Created Then
                Dim oCaveInfoBranch As cCaveInfoBranch = ParentBranches.Add(oCIB.Name)
                oCaveInfoBranch.Color = oCIB.Color
                oCaveInfoBranch.Description = oCIB.Description
                oCaveInfoBranch.SurfaceProfileShow = oCIB.SurfaceProfileShow
                oCaveInfoBranch.Locked = oCIB.Locked
                oCaveInfoBranch.ExtendStart = oCIB.ExtendStart
                oCaveInfoBranch.Priority = oCIB.Priority
                oCaveInfoBranch.ParentConnection = oCIB.ParentConnection
                oCaveInfoBranch.Connection = oCIB.Connection
                oCIB.Source = oCaveInfoBranch
            Else
                oCIB.Source.Color = oCIB.Color
                oCIB.Source.Description = oCIB.Description
                oCIB.Source.SurfaceProfileShow = oCIB.SurfaceProfileShow
                oCIB.Source.Locked = oCIB.Locked
                oCIB.Source.ExtendStart = oCIB.ExtendStart
                oCIB.Source.Priority = oCIB.Priority
                oCIB.Source.ParentConnection = oCIB.ParentConnection
                oCIB.Source.Connection = oCIB.Connection
                Dim sNewName As String = oCIB.Name
                Dim sOldName As String = oCIB.Source.Name
                If sNewName.ToLower <> sOldName.ToLower Then
                    Call ParentBranches.Rename(sOldName, sNewName, True)
                End If
            End If
            Call pCaveBranchesSave(oCIB.Source.Branches, oBranchNode.Nodes)
        Next
    End Sub

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

    Private Sub cmdCaveInfoColorChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCaveInfoColorChange.Click
        Dim oCD As ColorDialog = New ColorDialog
        With oCD
            .FullOpen = True
            .AnyColor = True
            .Color = picCaveInfoColor.BackColor
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                picCaveInfoColor.BackColor = .Color
                Try
                    Select Case tvCaveInfos.SelectedNode.Tag.type
                        Case "cave"
                            Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
                            oCI.Color = .Color
                        Case "branch"
                            Dim oCIB As cCaveInfoBranchPlaceHolder = tvCaveInfos.SelectedNode.Tag
                            oCIB.Color = .Color
                    End Select
                Catch
                End Try
            End If
        End With
    End Sub

    Private Sub cmdCaveInfoColorReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCaveInfoColorReset.Click
        picCaveInfoColor.BackColor = Color.Transparent
        Try
            Select Case tvCaveInfos.SelectedNode.Tag.type
                Case "cave"
                    Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
                    oCI.Color = Color.Transparent
                Case "branch"
                    Dim oCIB As cCaveInfoBranchPlaceHolder = tvCaveInfos.SelectedNode.Tag
                    oCIB.Color = Color.Transparent
            End Select
        Catch
        End Try
    End Sub

    Private Sub tvCaveInfos_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvCaveInfos.AfterSelect
        Try
            Select Case e.Node.Tag.type
                Case "cave"
                    Dim oCI As cCaveInfoPlaceHolder = e.Node.Tag
                    txtCaveInfoID.Enabled = True
                    txtCaveInfoName.Text = oCI.Name
                    txtCaveInfoID.Text = oCI.ID
                    txtCaveInfoDescription.Text = oCI.Description
                    picCaveInfoColor.BackColor = oCI.Color
                    If oCI.ExtendStart = "" Then
                        chkCaveInfoExtendStart.Checked = False
                        Call chkCaveInfoExtendStart_CheckedChanged(chkCaveInfoExtendStart, EventArgs.Empty)
                    Else
                        cboCaveInfoExtendStart.Text = oCI.ExtendStart
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
                    cmdCaveInfoColorChange.Enabled = bEnabled
                    cmdCaveInfoColorReset.Enabled = bEnabled
                    lblCaveInfoDescription.Enabled = bEnabled
                    txtCaveInfoDescription.Enabled = bEnabled
                    chkCaveInfoLocked.Enabled = bEnabled

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
                    Dim oCIB As cCaveInfoBranchPlaceHolder = e.Node.Tag
                    txtCaveInfoID.Enabled = False
                    txtCaveInfoName.Text = oCIB.Name
                    picCaveInfoColor.BackColor = oCIB.Color
                    txtCaveInfoDescription.Text = oCIB.Description
                    If oCIB.ExtendStart = "" Then
                        chkCaveInfoExtendStart.Checked = False
                        Call chkCaveInfoExtendStart_CheckedChanged(chkCaveInfoExtendStart, EventArgs.Empty)
                    Else
                        cboCaveInfoExtendStart.Text = oCIB.ExtendStart
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
                    cmdCaveInfoColorChange.Enabled = bEnabled
                    cmdCaveInfoColorReset.Enabled = bEnabled
                    lblCaveInfoDescription.Enabled = bEnabled
                    txtCaveInfoDescription.Enabled = bEnabled
                    chkCaveInfoLocked.Enabled = bEnabled

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
            Call lvCaveInfoSegments.Items.Clear()
            btnCaveInfoSelectSegment.Enabled = False
        Catch ex As Exception
            lblCaveInfoName.Enabled = False
            txtCaveInfoName.Enabled = False
            lblCaveInfoID.Enabled = False
            txtCaveInfoID.Enabled = False
            lblCaveInfoColor.Enabled = False
            cmdCaveInfoColorChange.Enabled = False
            cmdCaveInfoColorReset.Enabled = False
            lblCaveInfoDescription.Enabled = False
            txtCaveInfoDescription.Enabled = False
            chkCaveInfoLocked.Enabled = False

            lvCaveInfoSegments.Enabled = False
            btnCaveInfoSegmentsRefresh.Enabled = False
            Call lvCaveInfoSegments.Items.Clear()
            btnCaveInfoSelectSegment.Enabled = False

            btnCaveInfoAddCave.Enabled = True
            btnCaveInfoAddBranch.Enabled = False
            btnCaveInfoDelete.Enabled = False
        End Try
    End Sub

    Private Sub txtCaveInfoName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCaveInfoName.Validated
        Try
            Dim sName As String = txtCaveInfoName.Text
            If tvCaveInfos.SelectedNode.Name <> sName Then
                tvCaveInfos.SelectedNode.Name = sName
                tvCaveInfos.SelectedNode.Text = sName
                Select Case tvCaveInfos.SelectedNode.Tag.type
                    Case "cave"
                        Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
                        oCI.Name = sName
                    Case "branch"
                        Dim oCIB As cCaveInfoBranchPlaceHolder = tvCaveInfos.SelectedNode.Tag
                        oCIB.Name = sName
                End Select
            End If
        Catch
        End Try
    End Sub

    Private Sub txtCaveInfoID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCaveInfoID.Validated
        Try
            Dim sID As String = txtCaveInfoID.Text
            Select Case tvCaveInfos.SelectedNode.Tag.type
                Case "cave"
                    Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
                    oCI.ID = sID
            End Select
        Catch
        End Try
    End Sub

    Private Sub txtCaveInfoName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCaveInfoName.Validating
        Dim sNewName As String = txtCaveInfoName.Text.Trim
        If sNewName = "" Then
            e.Cancel = True
        Else
            Dim oNode As TreeNode = tvCaveInfos.SelectedNode
            If Not oNode Is Nothing Then
                Select Case oNode.Tag.type
                    Case "cave"
                        Dim oCI As cCaveInfoPlaceHolder = oNode.Tag
                        If sNewName <> oCI.Name Then
                            e.Cancel = tvCaveInfos.Nodes.ContainsKey(sNewName)
                        End If
                    Case "branch"
                        Dim oCIB As cCaveInfoBranchPlaceHolder = oNode.Tag
                        If sNewName <> oCIB.Name Then
                            e.Cancel = oNode.Parent.Nodes.ContainsKey(sNewName)
                        End If
                End Select
            End If
        End If
    End Sub

    Private Sub btnCaveInfoAddCave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCaveInfoAddCave.Click
        Call tvCaveInfos.Focus()

        Dim oCaveInfo As cCaveInfo = oSurvey.Properties.CaveInfos.GetEmptyCaveInfo(pGetNewNodeName(modMain.GetLocalizedString("properties.textpart4"), tvCaveInfos.Nodes))
        Dim oCaveNode As TreeNode = tvCaveInfos.Nodes.Add(oCaveInfo.Name, oCaveInfo.Name)
        Dim oCI As cCaveInfoPlaceHolder = New cCaveInfoPlaceHolder
        oCI.Name = oCaveInfo.Name
        oCI.ID = oCaveInfo.ID
        oCI.Color = oCaveInfo.Color
        oCI.ExtendStart = oCaveInfo.ExtendStart
        oCI.Source = oCaveInfo
        oCI.Created = True
        oCaveNode.Tag = oCI
        oCaveNode.SelectedImageKey = "cave"
        oCaveNode.ImageKey = "cave"

        tvCaveInfos.SelectedNode = oCaveNode
        Call oCaveNode.EnsureVisible()
    End Sub

    Private Sub btnCaveInfoAddBranch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCaveInfoAddBranch.Click
        Try
            Dim oParentNode As TreeNode = tvCaveInfos.SelectedNode
            If Not oParentNode Is Nothing Then
                Call tvCaveInfos.Focus()

                Dim sCave As String = oParentNode.Tag.name
                Dim oBranches As cCaveInfoBranches = oParentNode.Tag.source.branches
                Dim oCaveInfoBranch As cCaveInfoBranch = oBranches.GetEmptyCaveInfoBranch(pGetNewNodeName(modMain.GetLocalizedString("properties.textpart5"), oParentNode.Nodes))
                Dim oBranchNode As TreeNode = oParentNode.Nodes.Add(oCaveInfoBranch.Name, oCaveInfoBranch.Name)
                Dim oCIB As cCaveInfoBranchPlaceHolder = New cCaveInfoBranchPlaceHolder
                oCIB.Name = oCaveInfoBranch.Name
                oCIB.Color = oCaveInfoBranch.Color
                oCIB.Description = oCaveInfoBranch.Description
                oCIB.SurfaceProfileShow = oCaveInfoBranch.SurfaceProfileShow
                oCIB.Locked = oCaveInfoBranch.Locked
                oCIB.ExtendStart = oCaveInfoBranch.ExtendStart
                oCIB.Source = oCaveInfoBranch
                oCIB.Created = True
                oBranchNode.Tag = oCIB
                oBranchNode.SelectedImageKey = "branch"
                oBranchNode.ImageKey = "branch"

                tvCaveInfos.SelectedNode = oBranchNode
                Call oBranchNode.EnsureVisible()
            End If
        Catch
        End Try
    End Sub

    Private Function pGetNewNodeName(ByVal Prefix As String, ByVal Parent As TreeNodeCollection)
        Dim iCount As Integer = 1
        Do
            Dim sName As String = Prefix & " " & iCount
            If Not Parent.ContainsKey(sName) Then
                Return sName
            End If
            iCount += 1
        Loop
    End Function

    Private Sub btnCaveInfoDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCaveInfoDelete.Click
        Try
            Dim oNode As TreeNode = tvCaveInfos.SelectedNode
            If Not oNode Is Nothing Then
                Select Case oNode.Tag.type
                    Case "cave"
                        Dim oCI As cCaveInfoPlaceHolder = oNode.Tag
                        If oSurvey.Properties.CaveInfos.Contains(oCI.Source) Then
                            oNode.ForeColor = SystemColors.InactiveCaptionText
                            oNode.SelectedImageKey = "deleted"
                            oNode.ImageKey = "deleted"
                            For Each oChildNode As TreeNode In oNode.Nodes
                                oChildNode.SelectedImageKey = "deleted"
                                oChildNode.ImageKey = "deleted"
                                oChildNode.Tag.deleted = True
                            Next
                            oCI.Deleted = True
                            tvCaveInfos.SelectedNode = Nothing
                            tvCaveInfos.SelectedNode = oNode
                        Else
                            Call tvCaveInfos.Nodes.Remove(oNode)
                        End If
                        If tvCaveInfos.Nodes.Count = 0 Then
                            Call tvCaveInfos_AfterSelect(Nothing, Nothing)
                        End If
                    Case "branch"
                        Dim oCI As cCaveInfoPlaceHolder = pCaveInfoGetFirstLevelNode(oNode).Tag
                        Dim oCIB As cCaveInfoBranchPlaceHolder = oNode.Tag
                        If oSurvey.Properties.CaveInfos.Contains(oCI.Source) Then
                            If oCI.Source.Branches.GetAllBranches.Values.Contains(oCIB.Source) Then
                                oNode.ForeColor = SystemColors.InactiveCaptionText
                                oNode.SelectedImageKey = "deleted"
                                oNode.ImageKey = "deleted"
                                Call pCaveInfoDeleteChildNode(oNode)
                                oCIB.Deleted = True
                                tvCaveInfos.SelectedNode = Nothing
                                tvCaveInfos.SelectedNode = oNode
                            Else
                                Call oNode.Parent.Nodes.Remove(oNode)
                            End If
                        Else
                            Call oNode.Parent.Nodes.Remove(oNode)
                        End If
                        If tvCaveInfos.Nodes.Count = 0 Then
                            Call tvCaveInfos_AfterSelect(Nothing, Nothing)
                        End If
                End Select
            End If
        Catch
        End Try
    End Sub

    Private Function pCaveInfoGetFirstLevelNode(Node As TreeNode) As TreeNode
        If Node.Parent Is Nothing Then
            Return Node
        Else
            Return pCaveInfoGetFirstLevelNode(Node.Parent)
        End If
    End Function

    Private Sub pCaveInfoDeleteChildNode(Node As TreeNode)
        For Each oChildNode As TreeNode In Node.Nodes
            oChildNode.SelectedImageKey = "deleted"
            oChildNode.ImageKey = "deleted"
            oChildNode.Tag.deleted = True
            Call pCaveInfoDeleteChildNode(oChildNode)
        Next
    End Sub

    Private Sub cboGPSCustomRefPoint_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGPSCustomRefPoint.DropDown
        Call cboGPSCustomRefPoint.Items.Clear()
        For Each oTrigPoint As cTrigPoint In oSurvey.TrigPoints.GetGPSReferencedPoint
            cboGPSCustomRefPoint.Items.Add(oTrigPoint.Name)
        Next
    End Sub

    Private Sub btnSessionsAddSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSessionsAddSession.Click
        Call tvSessions.Focus()

        Dim sNewID As String
        Dim sNewDescriptionBase As String = GetLocalizedString("properties.textpart1")
        Dim iNewCount As Integer = 0
        Do
            iNewCount += 1
            sNewID = Strings.Format(Today, "yyyyMMdd") & "_" & (sNewDescriptionBase & " " & iNewCount).Replace(" ", "_").ToLower
        Loop While tvSessions.Nodes.ContainsKey(sNewID)
        Dim oSession As cSession = oSurvey.Properties.Sessions.GetEmptySession(Today, sNewDescriptionBase & " " & iNewCount)
        Dim oSessionNode As TreeNode = tvSessions.Nodes.Add(oSession.ID, oSession.FormattedID)
        Dim oCI As cSessionPlaceHolder = New cSessionPlaceHolder
        oCI.Date = oSession.Date
        oCI.Description = oSession.Description
        oCI.Team = oSession.Team
        oCI.Club = oSession.Club
        oCI.Designer = oSession.Designer
        oCI.DistanceType = oSession.DistanceType
        oCI.BearingType = oSession.BearingType
        oCI.BearingDirection = oSession.BearingDirection
        oCI.InclinationType = oSession.InclinationType
        oCI.InclinationDirection = oSession.InclinationDirection
        oCI.DepthType = oSession.DepthType

        oCI.Grade = oSession.Grade

        oCI.NordType = oSession.NordType
        oCI.SideMeasuresType = oSession.SideMeasuresType
        oCI.SideMeasuresReferTo = oSession.SideMeasuresReferTo

        oCI.Source = oSession
        oCI.Created = True
        oSessionNode.Tag = oCI
        oSessionNode.SelectedImageKey = "session"
        oSessionNode.ImageKey = "session"

        tvSessions.SelectedNode = oSessionNode
        Call oSessionNode.EnsureVisible()
    End Sub

    Private Sub btnSessionsDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSessionsDelete.Click
        Try
            Dim oNode As TreeNode = tvSessions.SelectedNode
            If Not oNode Is Nothing Then
                Select Case oNode.Tag.type
                    Case "session"
                        Dim oCI As cSessionPlaceHolder = oNode.Tag
                        If oSurvey.Properties.Sessions.Contains(oCI.Source) Then
                            oNode.ForeColor = SystemColors.InactiveCaptionText
                            oNode.SelectedImageKey = "deleted"
                            oNode.ImageKey = "deleted"
                            oCI.Deleted = True

                            tvSessions.SelectedNode = Nothing
                            tvSessions.SelectedNode = oNode
                        Else
                            Call tvSessions.Nodes.Remove(oNode)
                        End If
                End Select
                If tvSessions.Nodes.Count = 0 Then
                    Call tvSessions_AfterSelect(Nothing, Nothing)
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub tvSessions_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvSessions.AfterSelect
        'workaround for forcing tabsession handle creation...so I can add tabs
        Dim oH As IntPtr = tabSession.Handle
        Dim bHaveFocus As Boolean = tvSessions.Focused
        tabSession.Enabled = False
        Try
            Call tabSession.TabPages.Remove(tabSessionMain)
            Call tabSession.TabPages.Remove(tabSessionNote)
            Call tabSession.TabPages.Remove(tabSessionDefault)

            Select Case e.Node.Tag.type
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
                    picSessionColor.Enabled = False
                    cmdSessionColorChange.Enabled = False
                    cmdSessionColorReset.Enabled = False

                    txtSessionDate.Value = Now
                    txtSessionDescription.Text = ""
                    picSessionColor.BackColor = PictureBox.DefaultBackColor

                    Dim oCI As cSessionPlaceHolder = e.Node.Tag

                    cboSessionDataFormat.SelectedIndex = oCI.DataFormat
                    cboSessionDistanceType.SelectedIndex = oCI.DistanceType
                    cboSessionBearingType.SelectedIndex = oCI.BearingType
                    chkSessionBearingDirection.Checked = oCI.BearingDirection = cSegment.MeasureDirectionEnum.Inverted
                    cboSessionInclinationType.SelectedIndex = oCI.InclinationType
                    chkSessionInclinationDirection.Checked = oCI.InclinationDirection = cSegment.MeasureDirectionEnum.Inverted
                    cboSessionDepthType.SelectedIndex = oCI.DepthType

                    If oCI.Grade = "" Then
                        cboSessionGrade.SelectedIndex = 0
                    Else
                        cboSessionGrade.SelectedIndex = oSurvey.Grades.IndexOf(oSurvey.Grades(oCI.Grade)) + 1
                    End If

                    cboSessionNordType.SelectedIndex = oCI.NordType
                    chkSessionDecMag.Checked = oCI.declinationenabled
                    txtSessionDecMag.Text = oCI.Declination

                    cboSessionSideMeasuresType.SelectedIndex = oCI.SideMeasuresType
                    cboSessionSideMeasuresReferTo.SelectedIndex = oCI.SideMeasuresReferTo

                    chkSessionVthreshold.Checked = oCI.VThresholdEnabled
                    txtSessionVthreshold.Text = oCI.VThreshold

                    tabSession.Enabled = True

                    Call tabSession.TabPages.Insert(1, tabSessionDefault)
                    tabSession.SelectedTab = tabSessionMeasure

                    btnSessionsDelete.Enabled = False
                Case "session"
                    lblSessionDate.Enabled = True
                    txtSessionDate.Enabled = True
                    pnlSessionDate.Visible = False
                    txtSessionDate.Visible = True

                    lblSessionDescription.Enabled = True
                    txtSessionDescription.Enabled = True
                    lblSessionColor.Enabled = True
                    picSessionColor.Enabled = True
                    cmdSessionColorChange.Enabled = True
                    cmdSessionColorReset.Enabled = True

                    Dim oCI As cSessionPlaceHolder = e.Node.Tag
                    txtSessionDate.Enabled = True
                    txtSessionDate.Value = oCI.Date
                    txtSessionDescription.Text = oCI.Description
                    txtSessionClub.Text = oCI.Club
                    txtSessionTeam.Text = oCI.Team
                    txtSessionDesigner.Text = oCI.Designer
                    txtSessionNote.Text = oCI.Note
                    picSessionColor.BackColor = oCI.Color

                    cboSessionDataFormat.SelectedIndex = oCI.DataFormat
                    cboSessionDistanceType.SelectedIndex = oCI.DistanceType
                    cboSessionBearingType.SelectedIndex = oCI.BearingType
                    chkSessionBearingDirection.Checked = oCI.BearingDirection = cSegment.MeasureDirectionEnum.Inverted
                    cboSessionInclinationType.SelectedIndex = oCI.InclinationType
                    chkSessionInclinationDirection.Checked = oCI.InclinationDirection = cSegment.MeasureDirectionEnum.Inverted
                    cboSessionDepthType.SelectedIndex = oCI.DepthType

                    If oCI.Grade = "" Then
                        cboSessionGrade.SelectedIndex = 0
                    Else
                        cboSessionGrade.SelectedIndex = oSurvey.Grades.IndexOf(oSurvey.Grades(oCI.Grade)) + 1
                    End If

                    cboSessionNordType.SelectedIndex = oCI.NordType
                    chkSessionDecMag.Checked = oCI.declinationenabled
                    txtSessionDecMag.Text = oCI.Declination

                    cboSessionSideMeasuresType.SelectedIndex = oCI.SideMeasuresType
                    cboSessionSideMeasuresReferTo.SelectedIndex = oCI.SideMeasuresReferTo

                    chkSessionVthreshold.Checked = oCI.VThresholdEnabled
                    txtSessionVthreshold.Text = oCI.VThreshold

                    Dim bEnabled As Boolean = Not oCI.Deleted
                    lblSessionColor.Enabled = bEnabled
                    cmdSessionColorChange.Enabled = bEnabled
                    cmdSessionColorReset.Enabled = bEnabled
                    lblSessionDate.Enabled = bEnabled
                    txtSessionDate.Enabled = bEnabled
                    lblSessionDescription.Enabled = bEnabled
                    txtSessionDescription.Enabled = bEnabled
                    tabSession.Enabled = bEnabled

                    Call tabSession.TabPages.Insert(0, tabSessionMain)
                    Call tabSession.TabPages.Insert(1, tabSessionNote)
                    tabSession.SelectedTab = tabSessionMain

                    btnSessionsDelete.Enabled = True
            End Select
            btnSessionsAddSession.Enabled = True
            tabSession.Enabled = True
        Catch ex As Exception
            lblSessionDate.Enabled = False
            txtSessionDate.Enabled = False
            lblSessionDescription.Enabled = False
            txtSessionDescription.Enabled = False
            tabSession.Enabled = False
            btnSessionsDelete.Enabled = False
        End Try
        If bHaveFocus Then tvSessions.Focus()
    End Sub

    Private Sub tvHighlights_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvHighlights.AfterSelect
        Try
            'Select Case e.Node.Tag.type
            '    Case "highlight"
            Dim bSystem As Boolean
            Dim oCI As cHighlightPlaceholder = e.Node.Tag
            If oCI.Source Is Nothing Then
                bSystem = False
            Else
                bSystem = oCI.Source.System
            End If
            txtHighlightName.Text = oCI.Name
            txtHighlightSize.Value = oCI.Size
            txtHighlightOpacity.Value = oCI.Opacity
            picHighlightColor.BackColor = oCI.Color
            txtHighlightApplyTo.Text = IIf(oCI.ApplyTo, modMain.GetLocalizedString("main.textpart94"), modMain.GetLocalizedString("main.textpart95"))
            txtHighlightCondition.Text = oCI.Condition

            Dim bEnabled As Boolean = Not oCI.Deleted
            txtHighlightName.Enabled = bEnabled
            txtHighlightSize.Enabled = bEnabled
            txtHighlightOpacity.Enabled = bEnabled
            picHighlightColor.Enabled = bEnabled
            txtHighlightApplyTo.Enabled = bEnabled
            cmdHighlightColorChange.Enabled = bEnabled
            cmdHighlightCondition.Enabled = bEnabled And Not bSystem
            'End Select
            btnAddHighlight.Enabled = True
            btnDeleteHighlight.Enabled = tvHighlights.Nodes.Count > 0 AndAlso Not bSystem
        Catch
            btnAddHighlight.Enabled = True
            btnDeleteHighlight.Enabled = False
        End Try
    End Sub

    Private Sub txtSessionDescription_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSessionDescription.Validated
        Try
            Dim sDescription As String = txtSessionDescription.Text
            Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
            oCI.Description = sDescription
            With tvSessions.SelectedNode
                .Name = oCI.ID
                .Text = oCI.FormattedID
            End With
        Catch
        End Try
    End Sub

    Private Sub txtSessionDescription_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSessionDescription.Validating
        Dim sNewDescription As String = txtSessionDescription.Text.Trim
        If sNewDescription = "" Then
            e.Cancel = True
        Else
            Dim oNode As TreeNode = tvSessions.SelectedNode
            Select Case oNode.Tag.type
                Case "session"
                    Dim oCI As cSessionPlaceHolder = oNode.Tag
                    Dim sNewID As String = Strings.Format(oCI.Date, "yyyyMMdd") & "_" & sNewDescription.Replace(" ", "_").ToLower
                    If sNewID <> oCI.ID Then
                        e.Cancel = tvSessions.Nodes.ContainsKey(sNewID)
                    End If
            End Select
        End If
    End Sub

    Private Sub txtSessionClub_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSessionClub.Validated
        Try
            Dim sClub As String = txtSessionClub.Text
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
                    oCI.Club = sClub
            End Select
        Catch
        End Try
    End Sub

    Private Sub txtSessionTeam_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSessionTeam.Validated
        Try
            Dim sTeam As String = txtSessionTeam.Text
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
                    oCI.Team = sTeam
            End Select
        Catch
        End Try
    End Sub

    Private Sub txtSessionDesigner_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSessionDesigner.Validated
        Try
            Dim sDesigner As String = txtSessionDesigner.Text
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
                    oCI.Designer = sDesigner
            End Select
        Catch
        End Try
    End Sub

    Private Sub cboSessionDistanceType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSessionDistanceType.Validated
        Try
            Dim iDistanceType As cSegment.DistanceTypeEnum = cboSessionDistanceType.SelectedIndex
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session", "defaultsession"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
                    oCI.DistanceType = iDistanceType
            End Select
        Catch
        End Try
    End Sub

    Private Sub cboSessionInclinationType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSessionInclinationType.Validated
        Try
            Dim iInclinationType As cSegment.DistanceTypeEnum = cboSessionInclinationType.SelectedIndex
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session", "defaultsession"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
                    oCI.InclinationType = iInclinationType
            End Select
        Catch
        End Try
    End Sub

    Private Sub cboSessionDepthType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSessionDepthType.Validated
        Try
            Dim iDepthType As cSegment.DistanceTypeEnum = cboSessionDepthType.SelectedIndex
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session", "defaultsession"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
                    oCI.DepthType = iDepthType
            End Select
        Catch
        End Try
    End Sub

    Private Sub cboSessionNordType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSessionNordType.Validated
        Try
            Dim iNordType As cSegment.DistanceTypeEnum = cboSessionNordType.SelectedIndex
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session", "defaultsession"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
                    oCI.NordType = iNordType
            End Select
        Catch
        End Try
    End Sub

    Private Sub cboSessionSideMeasureType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSessionSideMeasuresType.Validated
        Try
            Dim iSideMeasuresType As cSegment.SideMeasuresTypeEnum = cboSessionSideMeasuresType.SelectedIndex
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session", "defaultsession"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
                    oCI.SideMeasuresType = iSideMeasuresType
            End Select
        Catch
        End Try
    End Sub

    Private Sub cboSessionBearingType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSessionBearingType.Validated
        Try
            Dim iBearingType As cSegment.DistanceTypeEnum = cboSessionBearingType.SelectedIndex
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session", "defaultsession"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
                    oCI.BearingType = iBearingType
            End Select
        Catch
        End Try
    End Sub

    Private Sub txtSessionDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSessionDate.Validated
        Try
            Dim dDate As Date = txtSessionDate.Value
            Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
            oCI.Date = dDate
            With tvSessions.SelectedNode
                .Name = oCI.ID
                .Text = oCI.FormattedID
            End With
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
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session", "defaultsession"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
                    oCI.Declination = sDeclination
            End Select
        Catch
        End Try
    End Sub

    Private Sub chkSessionDecMag_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSessionDecMag.Validated
        Try
            Dim bdeclinationenabled As Boolean = chkSessionDecMag.Checked
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session", "defaultsession"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
                    oCI.declinationenabled = bdeclinationenabled
            End Select
        Catch
        End Try
    End Sub

    Private Sub txtSessionNote_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSessionNote.Validated
        Try
            Dim sNote As String = txtSessionNote.Text
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
                    oCI.Note = sNote
            End Select
        Catch
        End Try
    End Sub

    Private Sub cboSessionSideMeasuresReferTo_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSessionSideMeasuresReferTo.Validated
        Try
            Dim iSideMeasuresreferto As cSegment.SideMeasuresReferToEnum = cboSessionSideMeasuresReferTo.SelectedIndex
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session", "defaultsession"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
                    oCI.SideMeasuresReferTo = iSideMeasuresreferto
            End Select
        Catch
        End Try
    End Sub

    Private Sub cmdNewID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewID.Click
        If MsgBox(GetLocalizedString("properties.warning1"), MsgBoxStyle.YesNo Or MsgBoxStyle.Critical, GetLocalizedString("properties.warningtitle")) = MsgBoxResult.Yes Then
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
        If MsgBox(GetLocalizedString("properties.warning2"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, GetLocalizedString("properties.warningtitle")) = MsgBoxResult.Yes Then
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

    Private Sub optGPSRefPointOnOrigin_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optGPSRefPointOnOrigin.CheckedChanged
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
        picNordCorrectionWarning.Visible = bEnabled

        If cbosurfaceprofileelevation.Items.Count > 0 Then
            pnlSurfaceProfile.Enabled = bEnabled
        Else
            pnlSurfaceProfile.Enabled = False
        End If
    End Sub

    Private Sub cboSessionGrade_Validated(sender As Object, e As System.EventArgs) Handles cboSessionGrade.Validated
        Try
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session", "defaultsession"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
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
        Dim oSegments As cSegmentCollection = Nothing
        Call lvCaveInfoSegments.Items.Clear()
        If Not tvCaveInfos.SelectedNode Is Nothing Then
            Select Case tvCaveInfos.SelectedNode.Tag.type
                Case "cave"
                    Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
                    oSegments = oSurvey.Segments.GetCaveSegments(oCI.Source)
                Case "branch"
                    Dim oCIB As cCaveInfoBranchPlaceHolder = tvCaveInfos.SelectedNode.Tag
                    oSegments = oSurvey.Segments.GetCaveSegments(oCIB.Source)
            End Select
            If Not oSegments Is Nothing Then
                For Each oSegment As cSegment In oSegments
                    Dim oItem As ListViewItem = lvCaveInfoSegments.Items.Add(oSegment.ToString)
                    oItem.Tag = oSegment
                Next
                Dim bEnabled As Boolean = lvCaveInfoSegments.Items.Count > 0
                btnCaveInfoSelectSegment.Enabled = bEnabled
                If bEnabled Then
                    lvCaveInfoSegments.Items(0).Selected = True
                End If
            End If
        End If
    End Sub

    Private Sub btnCaveInfoSelectSegment_Click(sender As System.Object, e As System.EventArgs) Handles btnCaveInfoSelectSegment.Click
        If lvCaveInfoSegments.SelectedItems.Count > 0 Then
            Dim oSegment As cSegment = lvCaveInfoSegments.SelectedItems(0).Tag
            RaiseEvent OnSegmentSelect(Me, oSegment)
        End If
    End Sub

    Private Sub txtCaveInfoDescription_Validated(sender As Object, e As System.EventArgs) Handles txtCaveInfoDescription.Validated
        Try
            Dim sDescription As String = txtCaveInfoDescription.Text
            Select Case tvCaveInfos.SelectedNode.Tag.type
                Case "cave"
                    Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
                    oCI.Description = sDescription
                Case "branch"
                    Dim oCIB As cCaveInfoBranchPlaceHolder = tvCaveInfos.SelectedNode.Tag
                    oCIB.Description = sDescription
            End Select
        Catch
        End Try
    End Sub

    Private Sub tabInfoMeasure_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub chkSessionBearingDirection_CheckedChanged(sender As Object, e As EventArgs) Handles chkSessionBearingDirection.CheckedChanged
        Try
            Dim iBearingDirection As cSegment.MeasureDirectionEnum = IIf(chkSessionBearingDirection.Checked, cSegment.MeasureDirectionEnum.Inverted, cSegment.MeasureDirectionEnum.Direct)
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session", "defaultsession"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
                    oCI.BearingDirection = iBearingDirection
            End Select
        Catch
        End Try
    End Sub

    Private Sub chkSessionInclinationDirection_CheckedChanged(sender As Object, e As EventArgs) Handles chkSessionInclinationDirection.CheckedChanged
        Try
            Dim iInclinationDirection As cSegment.MeasureDirectionEnum = IIf(chkSessionInclinationDirection.Checked, cSegment.MeasureDirectionEnum.Inverted, cSegment.MeasureDirectionEnum.Direct)
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session", "defaultsession"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
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
        'Dim bEnabled As Boolean = cboSessionDataFormat.SelectedIndex = 0
        'cboSessionBearingType.Enabled = bEnabled
        'chkSessionBearingDirection.Enabled = bEnabled
        'cboSessionInclinationType.Enabled = bEnabled
        'chkSessionInclinationDirection.Enabled = bEnabled

        'pnlSessionNorth.Enabled = bEnabled

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
        End Select
    End Sub

    Private Sub cboSessionDataFormat_Validated(sender As Object, e As System.EventArgs) Handles cboSessionDataFormat.Validated
        Try
            Dim iDataFormat As cSegment.DataFormatEnum = cboSessionDataFormat.SelectedIndex
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session", "defaultsession"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
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

    Private Sub cmdPlotNoteTextColor_Click(sender As Object, e As EventArgs) Handles cmdPlotNoteTextColor.Click
        Using oCD As ColorDialog = New ColorDialog
            With oCD
                .FullOpen = True
                .AnyColor = True
                .Color = picPlotNoteTextColor.BackColor
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    picPlotNoteTextColor.BackColor = .Color
                End If
            End With
        End Using
    End Sub

    Private Sub chkSessionVthreshold_Validated(sender As Object, e As EventArgs) Handles chkSessionVthreshold.Validated
        Try
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session", "defaultsession"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
                    oCI.VThresholdEnabled = chkSessionVthreshold.Checked
            End Select
        Catch
        End Try
    End Sub

    Private Sub txtSessionVthreshold_Validated(sender As Object, e As EventArgs) Handles txtSessionVthreshold.Validated
        Try
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session", "defaultsession"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
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
            Dim sID As String = txtCaveInfoID.Text
            Select Case tvCaveInfos.SelectedNode.Tag.type
                Case "cave"
                    Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
                    oCI.SurfaceProfileShow = cboCaveInfoSurfaceProfileShow.SelectedIndex
                Case "branch"
                    Dim oCIB As cCaveInfoBranchPlaceHolder = tvCaveInfos.SelectedNode.Tag
                    oCIB.SurfaceProfileShow = cboCaveInfoSurfaceProfileShow.SelectedIndex
            End Select
        Catch
        End Try
    End Sub

    Private Sub chksurfaceprofile_CheckedChanged(sender As Object, e As EventArgs) Handles chksurfaceprofile.CheckedChanged
        Dim bEnabled As Boolean = chksurfaceprofile.Checked
        lblsurfaceprofileelevation.Enabled = bEnabled
        cbosurfaceprofileelevation.Enabled = bEnabled
        chkSurfaceProfileShow.Enabled = bEnabled

        lblCaveInfoSurfaceProfileShow.Enabled = bEnabled
        cboCaveInfoSurfaceProfileShow.Enabled = bEnabled
    End Sub

    Private Sub cbosurfaceprofileelevation_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cbosurfaceprofileelevation.DrawItem
        If e.Index >= 0 Then
            Dim oGr As Graphics = e.Graphics
            oGr.CompositingQuality = CompositingQuality.HighQuality
            oGr.InterpolationMode = InterpolationMode.HighQualityBicubic
            oGr.SmoothingMode = SmoothingMode.AntiAlias
            oGr.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
            Dim bSelected As Boolean = (e.State And DrawItemState.Selected) = DrawItemState.Selected
            Dim oBounds As RectangleF = e.Bounds
            If bSelected Then
                Call oGr.FillRectangle(SystemBrushes.Highlight, oBounds)
                Call oGr.DrawRectangle(SystemPens.Highlight, oBounds.Left, oBounds.Top, oBounds.Width, oBounds.Height)
            Else
                Call oGr.FillRectangle(SystemBrushes.Window, oBounds)
                Call oGr.DrawRectangle(SystemPens.Window, oBounds.Left, oBounds.Top, oBounds.Width, oBounds.Height)
            End If

            Dim oItem As cComboItem = cbosurfaceprofileelevation.Items(e.Index)
            Dim oElevation As cSurvey.Surface.cElevation = oItem.Source
            If Not oElevation Is Nothing Then
                Dim oImage As Image = oElevation.GetImage(New Size(48, 32))

                Call oGr.DrawImageUnscaled(oImage, e.Bounds.Left + 2, e.Bounds.Top + 2)
                Dim oBorderPen As Pen = New Pen(Brushes.DarkGray)
                Call oGr.DrawRectangle(oBorderPen, e.Bounds.Left + 2, e.Bounds.Top + 2, 48, e.Bounds.Height - 4)
                Call oBorderPen.Dispose()

                Dim oLabelRect As RectangleF = New RectangleF(e.Bounds.Left + 48 + 2, e.Bounds.Top, e.Bounds.Right - (e.Bounds.Left + 48 + 2), e.Bounds.Height)

                Dim oSF As StringFormat = New StringFormat
                oSF.LineAlignment = StringAlignment.Center
                oSF.Trimming = StringTrimming.EllipsisCharacter
                If bSelected Then
                    Call oGr.DrawString(oElevation.Name, cbosurfaceprofileelevation.Font, SystemBrushes.HighlightText, oLabelRect, oSF)
                Else
                    Call oGr.DrawString(oElevation.Name, cbosurfaceprofileelevation.Font, SystemBrushes.WindowText, oLabelRect, oSF)
                End If
                Call oSF.Dispose()
            End If
        End If
    End Sub

    Private Sub btnDeleteHighlight_Click(sender As Object, e As EventArgs) Handles btnDeleteHighlight.Click
        Try
            Dim oNode As TreeNode = tvHighlights.SelectedNode
            If Not oNode Is Nothing Then
                Select Case oNode.Tag.type
                    Case "highlight"
                        Dim oCI As cHighlightPlaceholder = oNode.Tag
                        If oSurvey.Properties.HighlightsDetails.Contains(oCI.Source) Then
                            oNode.ForeColor = SystemColors.InactiveCaptionText
                            oNode.SelectedImageKey = "deleted"
                            oNode.ImageKey = "deleted"
                            oCI.Deleted = True

                            tvHighlights.SelectedNode = Nothing
                            tvHighlights.SelectedNode = oNode
                        Else
                            Call tvHighlights.Nodes.Remove(oNode)
                        End If
                End Select
                If tvHighlights.Nodes.Count = 0 Then
                    Call tvHighlights_AfterSelect(Nothing, Nothing)
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub txtHighlightName_Validated(sender As Object, e As EventArgs) Handles txtHighlightName.Validated
        Try
            Dim sName As String = txtHighlightName.Text
            If tvHighlights.SelectedNode.Name <> sName Then
                tvHighlights.SelectedNode.Name = sName
                tvHighlights.SelectedNode.Text = sName
                Select Case tvHighlights.SelectedNode.Tag.type
                    Case "hightlight"
                        Dim oCI As cCaveInfoPlaceHolder = tvHighlights.SelectedNode.Tag
                        oCI.Name = sName
                End Select
            End If
        Catch
        End Try
    End Sub

    Private Sub cmdHighlightColorChange_Click(sender As Object, e As EventArgs) Handles cmdHighlightColorChange.Click
        Dim oCD As ColorDialog = New ColorDialog
        With oCD
            .FullOpen = True
            .AnyColor = True
            .Color = picHighlightColor.BackColor
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                picHighlightColor.BackColor = .Color
                Try
                    Select Case tvHighlights.SelectedNode.Tag.type
                        Case "highlight"
                            Dim oCI As cHighlightPlaceholder = tvHighlights.SelectedNode.Tag
                            oCI.Color = .Color
                    End Select
                Catch
                End Try
            End If
        End With
    End Sub

    Private Sub txtHighlightSize_Validated(sender As Object, e As EventArgs) Handles txtHighlightSize.Validated
        Try
            Select Case tvHighlights.SelectedNode.Tag.type
                Case "highlight"
                    Dim oCI As cHighlightPlaceholder = tvHighlights.SelectedNode.Tag
                    oCI.Size = txtHighlightSize.Value
            End Select
        Catch
        End Try
    End Sub

    Private Sub txtHighlightOpacity_Validated(sender As Object, e As EventArgs) Handles txtHighlightOpacity.Validated
        Try
            Select Case tvHighlights.SelectedNode.Tag.type
                Case "highlight"
                    Dim oCI As cHighlightPlaceholder = tvHighlights.SelectedNode.Tag
                    oCI.Opacity = txtHighlightOpacity.Value
            End Select
        Catch
        End Try
    End Sub

    Private Sub btnAddHighlight_Click(sender As Object, e As EventArgs) Handles btnAddHighlight.Click

    End Sub

    Private Sub frmF_OnFormulaCodeRequest(Sender As frmScriptFormulaEditor, ByRef Args As frmScriptFormulaEditor.cFormulaCodeRequestEvent)
        Try
            Select Case tvHighlights.SelectedNode.Tag.type
                Case "highlight"
                    Dim oCI As cHighlightPlaceholder = tvHighlights.SelectedNode.Tag
                    Args.FullCode = cSurvey.Properties.cHighlightsDetail.GetScriptCode(Args.ScriptBag, oCI.ApplyTo)
            End Select
        Catch
        End Try
    End Sub

    Private Sub cmdHighlightCondition_Click(sender As Object, e As EventArgs) Handles cmdHighlightCondition.Click
        Try
            Select Case tvHighlights.SelectedNode.Tag.type
                Case "highlight"
                    Dim oCI As cHighlightPlaceholder = tvHighlights.SelectedNode.Tag
                    Dim frmF As frmScriptFormulaEditor = New frmScriptFormulaEditor(oSurvey, New cScriptBag(oCI.Condition, iFunctionLanguage))
                    AddHandler frmF.OnFormulaCodeRequest, AddressOf frmF_OnFormulaCodeRequest
                    If frmF.ShowDialog(Me) = DialogResult.OK Then
                        oCI.Condition = frmF.GetScriptBag.ToString
                        txtHighlightCondition.Text = oCI.Condition
                    End If
            End Select
        Catch
        End Try
    End Sub

    Private Sub btnResetHighlight_Click(sender As Object, e As EventArgs) Handles btnResetHighlight.Click
        Call oSurvey.Properties.HighlightsDetails.Clear()
        Call pHighlightsLoad()
    End Sub

    Private Sub btnAddHighlight0_Click(sender As Object, e As EventArgs) Handles btnAddHighlight0.Click
        Call pHighlightAdd(0)
    End Sub

    Private Sub pHighlightAdd(ApplyTo As Integer)
        Call tvHighlights.Focus()

        Dim sID As String = Guid.NewGuid.ToString
        Dim sName As String = String.Format(modMain.GetLocalizedString("properties.textpart2"), tvHighlights.Nodes.Count + 1)
        Dim oHighlightNode As TreeNode = tvHighlights.Nodes.Add(sID, sName)
        Dim oCI As cHighlightPlaceholder = New cHighlightPlaceholder
        oCI.ID = ""
        oCI.Name = sName
        oCI.Color = Color.Red
        oCI.Size = 10
        oCI.Opacity = 140
        oCI.Source = Nothing
        oCI.ApplyTo = ApplyTo
        oCI.System = False
        oCI.Created = True
        oHighlightNode.Tag = oCI
        oHighlightNode.SelectedImageKey = "hl"
        oHighlightNode.ImageKey = "hl"

        tvHighlights.SelectedNode = oHighlightNode
        Call oHighlightNode.EnsureVisible()
    End Sub

    Private Sub btnAddHighlight1_Click(sender As Object, e As EventArgs) Handles btnAddHighlight1.Click
        Call pHighlightAdd(1)
    End Sub

    Private Sub cmdSessionColorReset_Click(sender As Object, e As EventArgs) Handles cmdSessionColorReset.Click
        picSessionColor.BackColor = Color.Transparent
        Try
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
                    oCI.Color = Color.Transparent
            End Select
        Catch
        End Try
    End Sub

    Private Sub cmdSessionColorChange_Click(sender As Object, e As EventArgs) Handles cmdSessionColorChange.Click
        Dim oCD As ColorDialog = New ColorDialog
        With oCD
            .FullOpen = True
            .AnyColor = True
            .Color = picSessionColor.BackColor
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                picSessionColor.BackColor = .Color
                Try
                    Select Case tvSessions.SelectedNode.Tag.type
                        Case "session"
                            Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
                            oCI.Color = .Color
                    End Select
                Catch
                End Try
            End If
        End With
    End Sub

    Private Sub cboCalculateVersion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCalculateVersion.SelectedIndexChanged
        cmdUpdateCalculateVersion.Enabled = cboCalculateVersion.SelectedIndex < cboCalculateVersion.Items.Count - 1
    End Sub

    Private Sub cmdUpdateCalculateVersion_Click(sender As Object, e As EventArgs) Handles cmdUpdateCalculateVersion.Click
        If MsgBox(modMain.GetLocalizedString("properties.warning3"), vbYesNo Or MsgBoxStyle.Critical, modMain.GetLocalizedString("properties.warningtitle")) = MsgBoxResult.Yes Then
            Call cmdApply.PerformClick()
            Call oSurvey.Properties.UpgradeCalculateVersion()
            cboCalculateVersion.SelectedIndex = oSurvey.Properties.CalculateVersion
        End If
    End Sub

    Private Sub btnSessionSegmentsRefresh_Click(sender As Object, e As EventArgs) Handles btnSessionSegmentsRefresh.Click
        Dim oSegments As cSegmentCollection = Nothing
        Call lvSessionSegments.Items.Clear()
        If Not tvSessions.SelectedNode Is Nothing Then
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
                    oSegments = oSurvey.Segments.GetSessionSegments(oCI.Source)
            End Select
            If Not oSegments Is Nothing Then
                For Each oSegment As cSegment In oSegments
                    Dim oItem As ListViewItem = lvSessionSegments.Items.Add(oSegment.ToString)
                    oItem.Tag = oSegment
                Next
                Dim bEnabled As Boolean = lvSessionSegments.Items.Count > 0
                btnCaveInfoSelectSegment.Enabled = bEnabled
                If bEnabled Then
                    lvSessionSegments.Items(0).Selected = True
                End If
            End If
        End If
    End Sub

    Private Sub btnSessionSelectSegment_Click(sender As Object, e As EventArgs) Handles btnSessionSelectSegment.Click
        If lvSessionSegments.SelectedItems.Count > 0 Then
            Dim oSegment As cSegment = lvSessionSegments.SelectedItems(0).Tag
            RaiseEvent OnSegmentSelect(Me, oSegment)
        End If
    End Sub

    Private Sub btnSessionCalibrationSegmentsRefresh_Click(sender As Object, e As EventArgs) Handles btnSessionCalibrationSegmentsRefresh.Click
        Dim oSegments As cSegmentCollection = Nothing
        Call lvSessionSegments.Items.Clear()
        If Not tvSessions.SelectedNode Is Nothing Then
            Select Case tvSessions.SelectedNode.Tag.type
                Case "session"
                    Dim oCI As cSessionPlaceHolder = tvSessions.SelectedNode.Tag
                    oSegments = oSurvey.Segments.GetSessionSegments(oCI.Source, cISegmentCollection.SessionSegmentsFlagEnum.CalibrationShots)
            End Select
            If Not oSegments Is Nothing Then
                For Each oSegment As cSegment In oSegments
                    Dim oItem As ListViewItem = lvSessionCalibrationSegments.Items.Add(oSegment.ToString)
                    oItem.Tag = oSegment
                Next
                Dim bEnabled As Boolean = lvSessionCalibrationSegments.Items.Count > 0
                btnCaveInfoSelectSegment.Enabled = bEnabled
                If bEnabled Then
                    lvSessionCalibrationSegments.Items(0).Selected = True
                End If
            End If
        End If
    End Sub

    Private Sub chkCaveInfoLocked_Validated(sender As Object, e As EventArgs) Handles chkCaveInfoLocked.Validated
        Try
            Dim sID As String = txtCaveInfoID.Text
            Select Case tvCaveInfos.SelectedNode.Tag.type
                Case "cave"
                    Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
                    oCI.Locked = chkCaveInfoLocked.Checked
                Case "branch"
                    Dim oCIB As cCaveInfoBranchPlaceHolder = tvCaveInfos.SelectedNode.Tag
                    oCIB.Locked = chkCaveInfoLocked.Checked
            End Select
        Catch
        End Try
    End Sub

    Private Sub cboCaveInfoExtendStart_Validated(sender As Object, e As EventArgs) Handles cboCaveInfoExtendStart.Validated
        Try
            If chkCaveInfoExtendStart.Checked Then
                Dim sExtendStart As String = cboCaveInfoExtendStart.Text
                Select Case tvCaveInfos.SelectedNode.Tag.type
                    Case "cave"
                        Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
                        oCI.ExtendStart = sExtendStart
                    Case "branch"
                        Dim oCIB As cCaveInfoBranchPlaceHolder = tvCaveInfos.SelectedNode.Tag
                        oCIB.ExtendStart = sExtendStart
                End Select
                If Not sender Is chkCaveInfoExtendStart Then chkCaveInfoExtendStart.Checked = sExtendStart <> ""
            Else
                Select Case tvCaveInfos.SelectedNode.Tag.type
                    Case "cave"
                        Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
                        oCI.ExtendStart = ""
                    Case "branch"
                        Dim oCIB As cCaveInfoBranchPlaceHolder = tvCaveInfos.SelectedNode.Tag
                        oCIB.ExtendStart = ""
                End Select
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
            txtCaveInfoPriority.Value = pGetPriority(tvCaveInfos.SelectedNode).GetValueOrDefault(0)
        End If
        Call txtCaveInfoPriority_Validated(chkCaveInfoPriority, EventArgs.Empty)
        pnlCaveInfoConnections.Enabled = chkCaveInfoExtendStart.Checked OrElse chkCaveInfoPriority.Checked
    End Sub

    Private Sub chkCaveInfoExtendStart_CheckedChanged(sender As Object, e As EventArgs) Handles chkCaveInfoExtendStart.CheckedChanged
        cboCaveInfoExtendStart.Enabled = chkCaveInfoExtendStart.Checked
        If Not cboCaveInfoExtendStart.Enabled Then
            cboCaveInfoExtendStart.Text = "" & pGetExtendStart(tvCaveInfos.SelectedNode)
        End If
        Call cboCaveInfoExtendStart_Validated(chkCaveInfoExtendStart, EventArgs.Empty)
        pnlCaveInfoConnections.Enabled = chkCaveInfoExtendStart.Checked OrElse chkCaveInfoPriority.Checked
    End Sub

    Private Function pGetExtendStart(Node As TreeNode) As String
        Select Case Node.Tag.type
            Case "cave"
                Dim oCI As cCaveInfoPlaceHolder = Node.Tag
                If oCI.ExtendStart = "" Then
                    Return cboOrigin.Text
                Else
                    Return oCI.ExtendStart
                End If
            Case "branch"
                Dim oCIB As cCaveInfoBranchPlaceHolder = Node.Tag
                If oCIB.ExtendStart = "" Then
                    Return pGetExtendStart(Node.Parent)
                Else
                    Return oCIB.ExtendStart
                End If
        End Select
    End Function

    Private Function pGetPriority(Node As TreeNode) As Integer?
        Select Case Node.Tag.type
            Case "cave"
                Dim oCI As cCaveInfoPlaceHolder = Node.Tag
                If oCI.Priority.HasValue Then
                    Return oCI.Priority
                Else
                    Return Nothing
                End If
            Case "branch"
                Dim oCIB As cCaveInfoBranchPlaceHolder = Node.Tag
                If oCIB.Priority.HasValue Then
                    Return oCIB.Priority
                Else
                    Return pGetPriority(Node.Parent)
                End If
        End Select
    End Function

    Private Sub txtCaveInfoPriority_Validated(sender As Object, e As EventArgs) Handles txtCaveInfoPriority.Validated
        Try
            If chkCaveInfoPriority.Checked Then
                Dim iPriority As Integer = txtCaveInfoPriority.Value
                Select Case tvCaveInfos.SelectedNode.Tag.type
                    Case "cave"
                        Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
                        oCI.Priority = iPriority
                    Case "branch"
                        Dim oCIB As cCaveInfoBranchPlaceHolder = tvCaveInfos.SelectedNode.Tag
                        oCIB.Priority = iPriority
                End Select
                'If Not sender Is chkCaveInfoPriority Then chkCaveInfoPriority.Checked = iPriority <> 0
            Else
                Select Case tvCaveInfos.SelectedNode.Tag.type
                    Case "cave"
                        Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
                        oCI.Priority = Nothing
                    Case "branch"
                        Dim oCIB As cCaveInfoBranchPlaceHolder = tvCaveInfos.SelectedNode.Tag
                        oCIB.Priority = Nothing
                End Select
            End If
            'chkCaveInfoPriority.Checked = iPriority.HasValue
        Catch
        End Try
    End Sub

    Private Sub cboCaveInfoExtendStart_DropDown(sender As Object, e As EventArgs) Handles cboCaveInfoExtendStart.DropDown
        Select Case tvCaveInfos.SelectedNode.Tag.type
            Case "cave"
                Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
                Call cboCaveInfoExtendStart.Items.Clear()
                Call cboCaveInfoExtendStart.Items.Add("")
                Call cboCaveInfoExtendStart.Items.AddRange(oCI.Source.GetSegments.GetTrigpointsNames().Cast(Of Object).ToArray)
            Case "branch"
                Dim oCIB As cCaveInfoBranchPlaceHolder = tvCaveInfos.SelectedNode.Tag
                Call cboCaveInfoExtendStart.Items.Clear()
                Call cboCaveInfoExtendStart.Items.Add("")
                Call cboCaveInfoExtendStart.Items.AddRange(oCIB.Source.GetSegments.GetTrigpointsNames().Cast(Of Object).ToArray)
        End Select
    End Sub

    Private Sub chkCaveInfoExtendStart_Validated(sender As Object, e As EventArgs) Handles chkCaveInfoExtendStart.Validated
        Dim sExtendStart As String = ""
        Select Case tvCaveInfos.SelectedNode.Tag.type
            Case "cave"
                Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
                sExtendStart = oCI.ExtendStart
            Case "branch"
                Dim oCIB As cCaveInfoBranchPlaceHolder = tvCaveInfos.SelectedNode.Tag
                sExtendStart = oCIB.ExtendStart
        End Select
        If sExtendStart = "" Then
            tvCaveInfos.SelectedNode.ImageKey = tvCaveInfos.SelectedNode.Tag.type
        Else
            tvCaveInfos.SelectedNode.ImageKey = "origin"
        End If
    End Sub

    Private Sub cmdCaveInfoParentConnection_Click(sender As Object, e As EventArgs) Handles cmdCaveInfoParentConnection.Click
        Select Case tvCaveInfos.SelectedNode.Tag.type
            Case "cave"
                Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
                Using frmT As frmConnectionDefBrowser = New frmConnectionDefBrowser(oSurvey, oCI.ParentConnection, True)
                    If frmT.ShowDialog() = DialogResult.OK Then
                        With oCI
                            .ParentConnection = frmT.Connection
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
                Dim oCIB As cCaveInfoBranchPlaceHolder = tvCaveInfos.SelectedNode.Tag
                Using frmT As frmConnectionDefBrowser = New frmConnectionDefBrowser(oSurvey, oCIB.ParentConnection, True)
                    If frmT.ShowDialog() = DialogResult.OK Then
                        With oCIB
                            .ParentConnection = frmT.Connection
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
        Select Case tvCaveInfos.SelectedNode.Tag.type
            Case "cave"
                Dim oCI As cCaveInfoPlaceHolder = tvCaveInfos.SelectedNode.Tag
                Using frmT As frmConnectionDefBrowser = New frmConnectionDefBrowser(oSurvey, oCI.Connection, True, oCI.ParentConnection.Station, Nothing, New List(Of cConnectionDef)({oCI.ParentConnection}))
                    If frmT.ShowDialog() = DialogResult.OK Then
                        With oCI
                            .Connection = frmT.Connection
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
                Dim oCIB As cCaveInfoBranchPlaceHolder = tvCaveInfos.SelectedNode.Tag
                Using frmT As frmConnectionDefBrowser = New frmConnectionDefBrowser(oSurvey, oCIB.Connection, True, oCIB.ParentConnection.Station, Nothing, New List(Of cConnectionDef)({oCIB.ParentConnection}))
                    If frmT.ShowDialog() = DialogResult.OK Then
                        With oCIB
                            .Connection = frmT.Connection
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

    Private Sub cboOrigin_EnabledChanged(sender As Object, e As EventArgs) Handles cboOrigin.EnabledChanged
        cmdOriginRefreshStations.Enabled = cboOrigin.Enabled
    End Sub

    Private Sub cboNordCorrection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNordCorrection.SelectedIndexChanged
        Call cboSessionNordType_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub chkGPSAllowManualDeclinations_CheckedChanged(sender As Object, e As EventArgs) Handles chkGPSAllowManualDeclinations.CheckedChanged
        Call cboSessionNordType_SelectedIndexChanged(Nothing, Nothing)
    End Sub
End Class