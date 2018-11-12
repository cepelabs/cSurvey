Imports System.Xml
Imports cSurveyPC.cSurvey.Calculate
Imports cSurveyPC.cSurvey.cSurvey

Namespace cSurvey
    Public Interface cITextStructure
        Property InfoBoxStructure() As String
        Property TrigPointStructure() As String
        Property SpecialTrigPointStructure() As String

        Function GetFormattedTrigpointText(Trigpoint As cTrigPoint) As String
        Function GetFormattedSpecialTrigpointText(Trigpoint As cTrigPoint) As String
        Function GetFormattedInfoBoxText() As String
    End Interface

    Public Class cProperties
        Implements cIMeasure
        Implements cITextStructure
        Implements cICaveInfo
        Implements cISurveyInfo

        Private oSurvey As cSurvey

        Private sName As String
        Private sID As String

        Private sDescription As String
        Private sClub As String

        Private sAuthor As String
        Private sTeam As String
        Private sDesigner As String
        Private sNote As String

        Private sCreatorID As String
        Private sCreatorVersion As String
        Private dCreationDate As Date?

        Private sDefGrade As String
        Private sDefAccuracy As String

        Private oSessions As cSessions
        Private oCaveInfos As cCaveInfos
        Private oCaveVisibilityProfiles As cCaveVisibilityProfiles

        Private iDesignWarpingMode As cSurvey.DesignWarpingModeEnum = cSurvey.DesignWarpingModeEnum.Default
        Private iDesignBindingMode As cSurvey.DesignBindingModeEnum = cSurvey.DesignBindingModeEnum.OnEndEdit
        Private bPlanWarpingDisabled As Boolean
        Private bProfileWarpingDisabled As Boolean
        Private bShowWarpingDetails As Boolean

        Private iSplayMode As cSurvey.SplayModeEnum
        'Private bBindSplaySegment As Boolean
        Private bBindCrossSection As Boolean

        Private iCalculateMode As cSurvey.CalculateModeEnum
        Private iCalculateType As cSurvey.CalculateTypeEnum
        Private iCalculateVersion As Integer
        Private iRingCorrectionMode As cSurvey.RingCorrectionModeEnum
        Private iNordCorrectionMode As cSurvey.NordCorrectionModeEnum
        Private iInversionMode As cSurvey.InversioneModeEnum

        Private iDataFormat As cSegment.DataFormatEnum
        Private iDistanceType As cSegment.DistanceTypeEnum
        Private iBearingType As cSegment.BearingTypeEnum
        Private iBearingDirection As cSegment.MeasureDirectionEnum
        Private iInclinationType As cSegment.InclinationTypeEnum
        Private iInclinationDirection As cSegment.MeasureDirectionEnum
        Private iDepthType As cSegment.DepthTypeEnum

        Private sGrade As String

        Private iNordType As cSegment.NordTypeEnum

        Private sDeclination As Single
        Private bDeclinationEnabled As Boolean
        Private sGlobalDeclination As Single
        Private bGlobalDeclinationEnabled As Boolean

        Private sVThreshold As Single
        Private bVThresholdEnabled As Boolean
        Private sGlobalVThreshold As Single
        Private bGlobalVThresholdEnabled As Boolean

        Private iSideMeasuresType As cSegment.SideMeasuresTypeEnum
        Private iSideMeasuresReferTo As cSegment.SideMeasuresReferToEnum

        Private sInfoBoxStructure As String
        Private sTrigpointStructure As String
        Private sSpecialTrigpointStructure As String

        Private oDesignProperties As cPropertiesCollection

        Private sOrigin As String

        Private oGPSProperties As cGPSProperties

        Private iDefaultCalculateMode As cSurvey.CalculateTypeEnum = cSurvey.CalculateModeEnum.Manual
        Private iDefaultCalculateType As cSurvey.CalculateTypeEnum = cSurvey.CalculateTypeEnum.Therion
        Private iDefaultRingCorrectionMode As cSurvey.RingCorrectionModeEnum = cSurvey.RingCorrectionModeEnum.Simple
        Private iDefaultDesignWarpingMode As cSurvey.DesignWarpingModeEnum = cSurvey.DesignWarpingModeEnum.Default
        Private iDefaultBindingMode As cSurvey.DesignBindingModeEnum = cSurvey.DesignBindingModeEnum.OnEndEdit
        Private iDefaultNordCorrectionMode As cSurvey.NordCorrectionModeEnum = cSurvey.NordCorrectionModeEnum.None
        Private iDefaultInversionMode As cSurvey.InversioneModeEnum = cSurvey.InversioneModeEnum.Absolute

        'Private bThreeDLochUseCaveBorder As Boolean
        Private iThreeDModelMode As ThreeDModelModeEnum
        Private sThreeDNormalizationFactor As Single
        Private sThreeDOversamplingFactor As Single
        Private bThreeDLochShowSplay As Boolean

        Private iThreeDSurfaceModelLod As Integer
        Private sThreeDSurfaceTextureLod As Single

        Private iVerticalLRUDThreshold As Integer

        Private oDataTables As Data.cDataTables

        Private bSurfaceProfile As Boolean
        Private sSurfaceProfileElevation As String
        Private bSurfaceProfileShow As Boolean

        Private bHistoryEnabled As Boolean

        Private bShowLegacyPrintAndExportObjects As Boolean

        Private oHLs As Properties.cHighlightsDetails

        Friend Sub SetCalculateVersion(Version As Integer)
            iCalculateVersion = Version
        End Sub

        Public Sub UpgradeInversionMode()
            'If iInversionMode <> cSurvey.InversioneModeEnum.Absolute Then
            iInversionMode = cSurvey.InversioneModeEnum.Absolute

                Dim iIndex As Integer = 0
                Dim iCount As Integer = oSurvey.Segments.Count
                Call oSurvey.RaiseOnProgressEvent("properties.changedirections", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("properties.progressbegin1"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageCalculate)
                For Each oSegment As cSegment In oSurvey.Segments
                    iIndex += 1
                    If iIndex Mod 20 = 0 Then oSurvey.RaiseOnProgressEvent("properties.changedirections", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, String.Format(GetLocalizedString("properties.progress1"), iIndex, iCount), iIndex / iCount)

                    If Not oSegment.Splay Then
                        Dim sFrom As String = oSegment.Data.SourceData.From
                        Dim sTo As String = oSegment.Data.SourceData.To
                        Dim oFromPoint As PointF
                        Dim oToPoint As PointF
                        If oSegment.Data.Data.Reversed Then
                            oFromPoint = oSegment.Data.Profile.ToPoint
                            oToPoint = oSegment.Data.Profile.FromPoint
                        Else
                            oFromPoint = oSegment.Data.Profile.FromPoint
                            oToPoint = oSegment.Data.Profile.ToPoint
                        End If
                        Dim iDirection As cSegment.DirectionEnum
                        If oFromPoint.X <= oToPoint.X Then
                            iDirection = cSegment.DirectionEnum.Right
                        Else
                            iDirection = cSegment.DirectionEnum.Left
                        End If

                        If oSegment.Direction <> iDirection Then
                            Call oSegment.SetDirection(iDirection)
                        End If
                    End If
                Next
                Call oSurvey.Segments.SaveAll()
                Call oSurvey.RaiseOnProgressEvent("properties.changedirections", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)

                Call oSurvey.Invalidate()
            'End If
        End Sub

        Public Sub UpgradeCalculateVersion()
            If iCalculateVersion < cCalculate.CalculateVersion Then
                If iCalculateVersion < 2 Then
                    Dim iCalculateModeBackup As CalculateModeEnum = iCalculateMode
                    iCalculateMode = CalculateModeEnum.Manual
                    iCalculateVersion = cCalculate.CalculateVersion

                    Call UpgradeInversionMode()

                    Call oSurvey.Invalidate(cCalculate.InvalidateEnum.FullCalculate)
                    Call oSurvey.Calculate.Calculate(False)
                    Call oSurvey.Invalidate(cCalculate.InvalidateEnum.FullCalculate)
                    Call oSurvey.Calculate.Calculate()

                    iCalculateMode = iCalculateModeBackup
                End If
                Call oSurvey.Invalidate()
            Else
                Call UpgradeInversionMode()
            End If
        End Sub

        Public ReadOnly Property CalculateVersion As Integer
            Get
                Return iCalculateVersion
            End Get
        End Property

        Public Property HistoryEnabled As Boolean
            Get
                Return bHistoryEnabled
            End Get
            Set(value As Boolean)
                bHistoryEnabled = value
            End Set
        End Property

        Public ReadOnly Property DataTables As Data.cDataTables
            Get
                Return oDataTables
            End Get
        End Property

        Public Property Grade As String Implements cIMeasure.Grade
            Get
                Return sGrade
            End Get
            Set(value As String)
                sGrade = value
            End Set
        End Property

        'Public Property xBindSplaySegment As Boolean
        '    Get
        '        Return bBindSplaySegment
        '    End Get
        '    Set(value As Boolean)
        '        bBindSplaySegment = value
        '    End Set
        'End Property

        Public Property BindCrossSection As Boolean
            Get
                Return bBindCrossSection
            End Get
            Set(value As Boolean)
                bBindCrossSection = value
            End Set
        End Property

        Friend Sub AutoSetOrigin()
            If sOrigin = "" Then
                For Each oSegment As cSegment In oSurvey.Segments
                    If oSegment.IsSelfDefined And oSegment.IsValid Then
                        sOrigin = oSegment.[From]
                        Exit For
                    End If
                Next
            End If
        End Sub

        Friend Sub RenameOrigin(NewName As String)
            sOrigin = NewName
        End Sub

        Public Property Origin As String
            Get
                Return sOrigin
            End Get
            Set(value As String)
                Dim sValue As String = value.ToUpper
                If (sValue <> sOrigin) Then
                    If oSurvey.Properties.DesignWarpingMode = cSurvey.DesignWarpingModeEnum.None Or (oSurvey.Properties.DesignWarpingMode <> cSurvey.DesignWarpingModeEnum.None And iInversionMode = cSurvey.InversioneModeEnum.Absolute) Then
                        sOrigin = sValue
                    End If
                End If
            End Set
        End Property

        Public Property DesignBindingMode As cSurvey.DesignBindingModeEnum
            Get
                Return iDesignBindingMode
            End Get
            Set(ByVal value As cSurvey.DesignBindingModeEnum)
                If value <> iDesignBindingMode Then
                    iDesignBindingMode = value
                End If
            End Set
        End Property

        Public Property ShowWarpingDetails As Boolean
            Get
                Return bShowWarpingDetails
            End Get
            Set(value As Boolean)
                If bShowWarpingDetails <> value Then
                    bShowWarpingDetails = value
                End If
            End Set
        End Property

        Public Property ProfileWarpingDisabled As Boolean
            Get
                Return bProfileWarpingDisabled
            End Get
            Set(value As Boolean)
                If bProfileWarpingDisabled <> value Then
                    bProfileWarpingDisabled = value
                End If
            End Set
        End Property

        Public Property PlanWarpingDisabled As Boolean
            Get
                Return bPlanWarpingDisabled
            End Get
            Set(value As Boolean)
                If bPlanWarpingDisabled <> value Then
                    bPlanWarpingDisabled = value
                End If
            End Set
        End Property

        Public Property DesignWarpingMode As cSurvey.DesignWarpingModeEnum
            Get
                Return iDesignWarpingMode
            End Get
            Set(ByVal value As cSurvey.DesignWarpingModeEnum)
                If value <> iDesignWarpingMode Then
                    iDesignWarpingMode = value
                End If
            End Set
        End Property

        Public Property SplayMode As cSurvey.SplayModeEnum
            Get
                Return iSplayMode
            End Get
            Set(ByVal value As cSurvey.SplayModeEnum)
                iSplayMode = value
            End Set
        End Property

        Public Property Name() As String Implements cICaveInfo.Name
            Get
                Return sName
            End Get
            Set(ByVal value As String)
                sName = value
            End Set
        End Property

        Public Property Description() As String Implements cICaveInfo.Description
            Get
                Return sDescription
            End Get
            Set(ByVal value As String)
                sDescription = value
            End Set
        End Property

        Public Property Designer() As String Implements cISurveyInfo.Designer
            Get
                Return sDesigner
            End Get
            Set(ByVal value As String)
                sDesigner = value
            End Set
        End Property

        Public ReadOnly Property CreationDate() As Date?
            Get
                Return dCreationDate
            End Get
        End Property

        Public ReadOnly Property CreatorID() As String
            Get
                Return sCreatorID
            End Get
        End Property

        Public ReadOnly Property CreatorVersion() As String
            Get
                Return sCreatorVersion
            End Get
        End Property

        Public Property Note() As String Implements cISurveyInfo.Note
            Get
                Return sNote
            End Get
            Set(ByVal value As String)
                sNote = value
            End Set
        End Property

        Public Property DefGrade() As String
            Get
                Return sDefGrade
            End Get
            Set(ByVal value As String)
                sDefGrade = value
            End Set
        End Property

        Public Property DefAccuracy() As String
            Get
                Return sDefAccuracy
            End Get
            Set(ByVal value As String)
                sDefAccuracy = value
            End Set
        End Property

        Public Property ID() As String Implements cICaveInfo.ID
            Get
                Return sID
            End Get
            Set(ByVal value As String)
                sID = value
            End Set
        End Property

        Public Property Author() As String
            Get
                Return sAuthor
            End Get
            Set(ByVal value As String)
                sAuthor = value
            End Set
        End Property

        Public Property Team() As String Implements cISurveyInfo.Team
            Get
                Return sTeam
            End Get
            Set(ByVal value As String)
                sTeam = value
            End Set
        End Property

        Public Function GetFormattedTrigpointText(Trigpoint As cTrigPoint) As String Implements cITextStructure.GetFormattedTrigpointText
            Return modPaint.GetFormattedTrigpointText(oSurvey, Me, Trigpoint)
        End Function

        Public Function GetFormattedSpecialTrigpointText(Trigpoint As cTrigPoint) As String Implements cITextStructure.GetFormattedSpecialTrigpointText
            Return modPaint.GetFormattedSpecialTrigpointText(oSurvey, Me, Trigpoint)
        End Function

        Public Function GetFormattedInfoBoxText() As String Implements cITextStructure.GetFormattedInfoBoxText
            Return modPaint.GetFormattedInfoBoxText(oSurvey, Me)
        End Function

        Public ReadOnly Property GPS As cGPSProperties
            Get
                Return oGPSProperties
            End Get
        End Property

        Public Property InfoBoxStructure() As String Implements cITextStructure.InfoBoxStructure
            Get
                Return sInfoBoxStructure
            End Get
            Set(ByVal value As String)
                sInfoBoxStructure = value
            End Set
        End Property

        Public Property TrigPointStructure() As String Implements cITextStructure.TrigPointStructure
            Get
                Return sTrigpointStructure
            End Get
            Set(ByVal value As String)
                sTrigpointStructure = value
            End Set
        End Property

        Public Property SpecialTrigPointStructure() As String Implements cITextStructure.SpecialTrigPointStructure
            Get
                Return sSpecialTrigpointStructure
            End Get
            Set(ByVal value As String)
                sSpecialTrigpointStructure = value
            End Set
        End Property

        Public Property CalculateMode As cSurvey.CalculateModeEnum
            Get
                Return iCalculateMode
            End Get
            Set(ByVal value As cSurvey.CalculateModeEnum)
                iCalculateMode = value
            End Set
        End Property

        Public Property CalculateType() As cSurvey.CalculateTypeEnum
            Get
                Return iCalculateType
            End Get
            Set(ByVal Value As cSurvey.CalculateTypeEnum)
                iCalculateType = Value
            End Set
        End Property

        Public Property RingCorrectionMode() As cSurvey.RingCorrectionModeEnum
            Get
                Return iRingCorrectionMode
            End Get
            Set(ByVal Value As cSurvey.RingCorrectionModeEnum)
                iRingCorrectionMode = Value
            End Set
        End Property

        Public Property SideMeasuresType() As cSegment.SideMeasuresTypeEnum Implements cIMeasure.SideMeasuresType
            Get
                Return iSideMeasuresType
            End Get
            Set(ByVal Value As cSegment.SideMeasuresTypeEnum)
                iSideMeasuresType = Value
            End Set
        End Property

        Public Property SideMeasuresReferTo() As cSegment.SideMeasuresReferToEnum Implements cIMeasure.SideMeasuresReferTo
            Get
                Return iSideMeasuresReferTo
            End Get
            Set(ByVal Value As cSegment.SideMeasuresReferToEnum)
                iSideMeasuresReferTo = Value
            End Set
        End Property

        Public Property DataFormat() As cSegment.DataFormatEnum Implements cIMeasure.DataFormat
            Get
                Return iDataFormat
            End Get
            Set(ByVal Value As cSegment.DataFormatEnum)
                iDataFormat = Value
            End Set
        End Property

        Public Property DistanceType() As cSegment.DistanceTypeEnum Implements cIMeasure.DistanceType
            Get
                Return iDistanceType
            End Get
            Set(ByVal Value As cSegment.DistanceTypeEnum)
                iDistanceType = Value
            End Set
        End Property

        Public Property InclinationType() As cSegment.InclinationTypeEnum Implements cIMeasure.InclinationType
            Get
                Return iInclinationType
            End Get
            Set(ByVal Value As cSegment.InclinationTypeEnum)
                iInclinationType = Value
            End Set
        End Property

        Public Property DepthType() As cSegment.DepthTypeEnum Implements cIMeasure.DepthType
            Get
                Return iDepthType
            End Get
            Set(ByVal Value As cSegment.DepthTypeEnum)
                iDepthType = Value
            End Set
        End Property

        Public Property BearingType() As cSegment.BearingTypeEnum Implements cIMeasure.BearingType
            Get
                Return iBearingType
            End Get
            Set(ByVal Value As cSegment.BearingTypeEnum)
                iBearingType = Value
            End Set
        End Property

        Public Property NordCorrectionMode() As cSurvey.NordCorrectionModeEnum
            Get
                Return iNordCorrectionMode
            End Get
            Set(ByVal Value As cSurvey.NordCorrectionModeEnum)
                iNordCorrectionMode = Value
            End Set
        End Property

        Public Property InversionMode() As cSurvey.InversioneModeEnum
            Get
                Return iInversionMode
            End Get
            Set(ByVal Value As cSurvey.InversioneModeEnum)
                iInversionMode = Value
            End Set
        End Property

        Public Property GlobalVThresholdEnabled() As Boolean
            Get
                Return bGlobalVThresholdEnabled
            End Get
            Set(ByVal Value As Boolean)
                bGlobalVThresholdEnabled = Value
            End Set
        End Property

        Public Property GlobalVThreshold() As Single
            Get
                Return sGlobalVThreshold
            End Get
            Set(ByVal Value As Single)
                sGlobalVThreshold = Value
            End Set
        End Property

        Public Function GetDeclination() As Single
            If bDeclinationEnabled Then
                Return sDeclination
            Else
                If bGlobalDeclinationEnabled Then
                    Return sGlobalDeclination
                Else
                    Return 0
                End If
            End If
        End Function

        Public Property GlobalDeclinationEnabled() As Boolean
            Get
                Return bGlobalDeclinationEnabled
            End Get
            Set(ByVal Value As Boolean)
                bGlobalDeclinationEnabled = Value
            End Set
        End Property

        Public Property GlobalDeclination() As Single
            Get
                Return sGlobalDeclination
            End Get
            Set(ByVal Value As Single)
                sGlobalDeclination = Value
            End Set
        End Property

        Public Property DeclinationEnabled() As Boolean Implements cIMeasure.DeclinationEnabled
            Get
                Return bDeclinationEnabled
            End Get
            Set(ByVal Value As Boolean)
                bDeclinationEnabled = Value
            End Set
        End Property

        Public Property Declination() As Single Implements cIMeasure.Declination
            Get
                Return sDeclination
            End Get
            Set(ByVal Value As Single)
                sDeclination = Value
            End Set
        End Property

        Public Property NordType() As cSegment.NordTypeEnum Implements cIMeasure.NordType
            Get
                Return iNordType
            End Get
            Set(ByVal Value As cSegment.NordTypeEnum)
                iNordType = Value
            End Set
        End Property

        Public Property Club() As String Implements cISurveyInfo.Club
            Get
                Return sClub
            End Get
            Set(ByVal value As String)
                sClub = value
            End Set
        End Property

        Public ReadOnly Property Sessions() As cSessions
            Get
                Return oSessions
            End Get
        End Property

        Public Function GetCaveInfo(CaveBranch As cICaveBranch) As cICaveInfoBranches
            Return GetCaveInfo(CaveBranch.Cave, CaveBranch.Branch)
        End Function

        Public Function GetCaveInfo(Cave As String, Branch As String) As cICaveInfoBranches
            If Cave = "" Then
                Return Nothing
            Else
                If Branch = "" Then
                    Return oCaveInfos(Cave)
                Else
                    Dim oCaveInfo As cCaveInfo = oCaveInfos(Cave)
                    If IsNothing(oCaveInfo) Then
                        Return Nothing
                    Else
                        Return oCaveInfo.Branches(Branch)
                    End If
                End If
            End If
        End Function

        Public ReadOnly Property CaveInfos() As cCaveInfos
            Get
                Return oCaveInfos
            End Get
        End Property

        Public ReadOnly Property CaveVisibilityProfiles() As cCaveVisibilityProfiles
            Get
                Return oCaveVisibilityProfiles
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey

            sID = ""
            sName = ""
            sDescription = ""

            sClub = ""
            sTeam = ""
            sAuthor = ""
            sDesigner = ""

            sCreatorID = "cSurvey"
            sCreatorVersion = oSurvey.Version
            dCreationDate = Date.Now

            sNote = ""

            sDefGrade = ""
            sDefAccuracy = ""

            sNote = ""

            oSessions = New cSessions(oSurvey)
            oCaveInfos = New cCaveInfos(oSurvey)
            oCaveVisibilityProfiles = New cCaveVisibilityProfiles(oSurvey)

            oGPSProperties = New cGPSProperties(oSurvey)

            iDataFormat = cSegment.DataFormatEnum.Normal
            iDistanceType = cSegment.BearingTypeEnum.DecimalDegree
            iInclinationType = cSegment.InclinationTypeEnum.DecimalDegree
            iBearingType = cSegment.BearingTypeEnum.DecimalDegree
            iDepthType = cSegment.DepthTypeEnum.AbsoluteAtEnd

            sGrade = ""

            sGlobalDeclination = 0
            bGlobalDeclinationEnabled = False

            iNordType = cSegment.NordTypeEnum.Magnetic
            sDeclination = 0
            iSideMeasuresType = cSegment.SideMeasuresTypeEnum.PerpendicularToPrevious
            iSideMeasuresReferTo = cSegment.SideMeasuresReferToEnum.EndPoint

            iCalculateMode = iDefaultCalculateMode
            iCalculateType = iDefaultCalculateType
            iCalculateVersion = cCalculate.CalculateVersion
            iRingCorrectionMode = iDefaultRingCorrectionMode
            iDesignBindingMode = iDefaultBindingMode
            iDesignWarpingMode = iDefaultDesignWarpingMode
            bPlanWarpingDisabled = False
            bProfileWarpingDisabled = False
            bShowWarpingDetails = True

            iInversionMode = iDefaultInversionMode

            iSplayMode = cSurvey.SplayModeEnum.None
            'bBindSplaySegment = False
            bBindCrossSection = True

            'sBaseSignScaleFactor = 1
            'sBaseTextScaleFactor = 0.05
            sOrigin = ""

            oDesignProperties = New cPropertiesCollection(oSurvey)

            oDataTables = New Data.cDataTables(oSurvey)

            iVerticalLRUDThreshold = 90

            iThreeDSurfaceModelLod = 1
            sThreeDSurfaceTextureLod = 1.5

            iThreeDModelMode = ThreeDModelModeEnum.Simple
            sThreeDNormalizationFactor = 1.5
            sThreeDOversamplingFactor = 1

            bSurfaceProfile = False
            sSurfaceProfileElevation = ""
            bSurfaceProfileShow = False

            bHistoryEnabled = True

            bShowLegacyPrintAndExportObjects = False

            oHLs = New Properties.cHighlightsDetails(oSurvey)
        End Sub

        Public ReadOnly Property HighlightsDetails As Properties.cHighlightsDetails
            Get
                Return oHLs
            End Get
        End Property

        Public Property SurfaceProfileElevation As Surface.cElevation
            Get
                If sSurfaceProfileElevation = "" Then
                    Return Nothing
                Else
                    Return oSurvey.Surface(sSurfaceProfileElevation)
                End If
            End Get
            Set(value As Surface.cElevation)
                If value Is Nothing Then
                    sSurfaceProfileElevation = ""
                    bSurfaceProfile = False
                Else
                    sSurfaceProfileElevation = value.ID
                End If
            End Set
        End Property

        Public Property SurfaceProfile As Boolean
            Get
                Return bSurfaceProfile
            End Get
            Set(value As Boolean)
                bSurfaceProfile = value
            End Set
        End Property

        Public Property SurfaceProfileShow As Boolean
            Get
                Return bSurfaceProfileShow
            End Get
            Set(value As Boolean)
                bSurfaceProfileShow = value
            End Set
        End Property

        Public Property ShowLegacyPrintAndExportObjects As Boolean
            Get
                Return bShowLegacyPrintAndExportObjects
            End Get
            Set(value As Boolean)
                bShowLegacyPrintAndExportObjects = value
            End Set
        End Property

        Public Property ThreeDLochShowSplay As Boolean
            Get
                Return bThreeDLochShowSplay
            End Get
            Set(value As Boolean)
                bThreeDLochShowSplay = value
            End Set
        End Property

        'Public Property ThreeDLochUseCaveBorder As Boolean
        '    Get
        '        Return bThreeDLochUseCaveBorder
        '    End Get
        '    Set(value As Boolean)
        '        bThreeDLochUseCaveBorder = value
        '    End Set
        'End Property

        Public Enum ThreeDModelModeEnum
            [Simple] = 0
            [Oversample] = 1
            [AdvancedOversample] = 2
        End Enum

        Public Function GetVThreshold() As Single
            If bVThresholdEnabled Then
                Return sVThreshold
            Else
                If bGlobalVThresholdEnabled Then
                    Return sGlobalVThreshold
                Else
                    Return 90.0F
                End If
            End If
        End Function

        Public Property VThreshold As Single Implements cIMeasure.VThreshold
            Get
                Return sVThreshold
            End Get
            Set(value As Single)
                sVThreshold = value
            End Set
        End Property

        Public Property VThresholdEnabled As Boolean Implements cIMeasure.VThresholdEnabled
            Get
                Return bVThresholdEnabled
            End Get
            Set(value As Boolean)
                bVThresholdEnabled = value
            End Set
        End Property

        Public Property ThreeDModelMode As ThreeDModelModeEnum
            Get
                Return iThreeDModelMode
            End Get
            Set(value As ThreeDModelModeEnum)
                iThreeDModelMode = value
            End Set
        End Property

        Public Property ThreeDNormalizationFactor As Single
            Get
                Return sThreeDNormalizationFactor
            End Get
            Set(value As Single)
                sThreeDNormalizationFactor = value
            End Set
        End Property

        Public Property ThreeDOversamplingFactor As Single
            Get
                Return sThreeDOversamplingFactor
            End Get
            Set(value As Single)
                sThreeDOversamplingFactor = value
            End Set
        End Property

        Public Property ThreeDSurfaceModelLod As Integer
            Get
                Return iThreeDSurfaceModelLod
            End Get
            Set(value As Integer)
                iThreeDSurfaceModelLod = value
            End Set
        End Property

        Public Property ThreeDSurfaceTextureLod As Single
            Get
                Return sThreeDSurfaceTextureLod
            End Get
            Set(value As Single)
                sThreeDSurfaceTextureLod = value
            End Set
        End Property

        Public ReadOnly Property DesignProperties As cPropertiesCollection
            Get
                Return oDesignProperties
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal [Properties] As XmlElement)
            oSurvey = Survey
            sID = modXML.GetAttributeValue([Properties], "id", "")
            sName = modXML.GetAttributeValue([Properties], "name", "")
            sDescription = modXML.GetAttributeValue([Properties], "description", "")

            sClub = modXML.GetAttributeValue([Properties], "club", "")
            sTeam = modXML.GetAttributeValue([Properties], "team", "")
            sAuthor = modXML.GetAttributeValue([Properties], "author", "")
            sDesigner = modXML.GetAttributeValue([Properties], "designer", "")

            Try
                sCreatorID = modXML.GetAttributeValue([Properties], "creatid", "")
                sCreatorVersion = modXML.GetAttributeValue([Properties], "creatversion", "")
                dCreationDate = New Date?(modXML.GetAttributeValue([Properties], "creatdate", Nothing))
            Catch
            End Try

            sNote = modXML.GetAttributeValue([Properties], "note", "")

            sDefGrade = modXML.GetAttributeValue([Properties], "defgrade", "")
            sDefAccuracy = modXML.GetAttributeValue([Properties], "defaccuracy", "")

            sOrigin = modXML.GetAttributeValue([Properties], "origin", "")

            If modOpeningFlags.OFCalculateModeEnabled Then
                iCalculateMode = modOpeningFlags.OFCalculateMode
            Else
                iCalculateMode = modXML.GetAttributeValue([Properties], "calculatemode", iDefaultCalculateMode)
            End If

            iCalculateType = modXML.GetAttributeValue([Properties], "calculatetype", iDefaultCalculateType)
            iCalculateVersion = modNumbers.StringToInteger(modXML.GetAttributeValue([Properties], "calculateversion", 0))
            If iCalculateVersion < 0 Then iCalculateVersion = cCalculate.CalculateVersion
            iRingCorrectionMode = modXML.GetAttributeValue([Properties], "ringcorrectionmode", iDefaultRingCorrectionMode)
            iNordCorrectionMode = modXML.GetAttributeValue([Properties], "nordcorrectionmode", iDefaultNordCorrectionMode)
            iInversionMode = modXML.GetAttributeValue([Properties], "inversionmode", iDefaultInversionMode)

            iDataFormat = modXML.GetAttributeValue([Properties], "dataformat", cSegment.DataFormatEnum.Normal)
            iDistanceType = modXML.GetAttributeValue([Properties], "distancetype", cSegment.DistanceTypeEnum.Meters)
            iBearingType = modXML.GetAttributeValue([Properties], "Bearingtype", cSegment.BearingTypeEnum.DecimalDegree)
            iBearingDirection = modXML.GetAttributeValue([Properties], "bearingdirection", cSegment.MeasureDirectionEnum.Direct)
            iInclinationType = modXML.GetAttributeValue([Properties], "inclinationtype", cSegment.InclinationTypeEnum.DecimalDegree)
            iInclinationDirection = modXML.GetAttributeValue([Properties], "inclinationdirection", cSegment.MeasureDirectionEnum.Direct)
            iDepthType = modXML.GetAttributeValue([Properties], "depthtype", cSegment.DepthTypeEnum.AbsoluteAtEnd)

            sGrade = modXML.GetAttributeValue([Properties], "grade", "")

            bGlobalDeclinationEnabled = modXML.GetAttributeValue([Properties], "globaldeclinationenabled", False)
            sGlobalDeclination = modNumbers.StringToSingle(modXML.GetAttributeValue([Properties], "globaldeclination", "0"))

            bGlobalVThresholdEnabled = modXML.GetAttributeValue([Properties], "globalvthresholdenabled", False)
            sGlobalVThreshold = modNumbers.StringToSingle(modXML.GetAttributeValue([Properties], "globalvthreshold", "0"))

            iNordType = modXML.GetAttributeValue([Properties], "nordtype", cSegment.NordTypeEnum.Magnetic)
            bDeclinationEnabled = modXML.GetAttributeValue([Properties], "declinationenabled", False)
            sDeclination = modNumbers.StringToSingle(modXML.GetAttributeValue([Properties], "declination", "0"))

            iSideMeasuresType = modXML.GetAttributeValue([Properties], "sidemeasurestype", cSegment.SideMeasuresTypeEnum.PerpendicularToPrevious)
            iSideMeasuresReferTo = modXML.GetAttributeValue([Properties], "sidemeasuresreferto", cSegment.SideMeasuresReferToEnum.EndPoint)

            sInfoBoxStructure = modXML.GetAttributeValue([Properties], "infoboxstructure", "")
            sTrigpointStructure = modXML.GetAttributeValue([Properties], "trigpointstructure", "")
            sSpecialTrigpointStructure = modXML.GetAttributeValue([Properties], "specialtrigpointstructure", "")

            iDesignBindingMode = modXML.GetAttributeValue([Properties], "designbindingmode", cSurvey.DesignBindingModeEnum.OnEndEdit)
            If modOpeningFlags.OFDesignWarpingModeEnabled Then
                iDesignWarpingMode = modOpeningFlags.OFDesignWarpingMode
                bPlanWarpingDisabled = modOpeningFlags.OFDesignWarlingPlanDisable
                bProfileWarpingDisabled = modOpeningFlags.OFDesignWarlingProfileDisable
            Else
                iDesignWarpingMode = modXML.GetAttributeValue([Properties], "designwarpingmode", cSurvey.DesignWarpingModeEnum.Default)
                bPlanWarpingDisabled = modXML.GetAttributeValue([Properties], "planwarpingdisabled", False)
                bProfileWarpingDisabled = modXML.GetAttributeValue([Properties], "profilewarpingdisabled", False)
            End If
            bShowWarpingDetails = modXML.GetAttributeValue([Properties], "showwarpingdetails", True)

            iSplayMode = modXML.GetAttributeValue([Properties], "splaymode", cSurvey.SplayModeEnum.None)
            'bBindSplaySegment = modXML.GetAttributeValue([Properties], "bindsplaysegment", False)
            bBindCrossSection = modXML.GetAttributeValue([Properties], "bindcrosssection", False)

            iThreeDModelMode = modXML.GetAttributeValue([Properties], "threedmodelmode", 0)
            sThreeDNormalizationFactor = modNumbers.StringToSingle(modXML.GetAttributeValue([Properties], "threednormalizationfactor", "1.5"))
            sThreeDOversamplingFactor = modNumbers.StringToSingle(modXML.GetAttributeValue([Properties], "threedoversamplingfactor", "1"))

            bThreeDLochShowSplay = modXML.GetAttributeValue([Properties], "threedlochshowsplay", True)

            iThreeDSurfaceModelLod = modXML.GetAttributeValue([Properties], "threedsurfacemodellod", 1)
            sThreeDSurfaceTextureLod = modNumbers.StringToSingle(modXML.GetAttributeValue([Properties], "threedsurfacetexturelod", "1.5"))

            iVerticalLRUDThreshold = modXML.GetAttributeValue([Properties], "VerticalLRUDThreshold", 90)

            bSurfaceProfile = modXML.GetAttributeValue([Properties], "surfaceprofile", False)
            sSurfaceProfileElevation = modXML.GetAttributeValue([Properties], "surfaceprofileelevation", "")
            bSurfaceProfileShow = modXML.GetAttributeValue([Properties], "surfaceprofileshow", False)

            bHistoryEnabled = modXML.GetAttributeValue([Properties], "historyenabled", True)

            bShowLegacyPrintAndExportObjects = modXML.GetAttributeValue([Properties], "slpeo", False)

            Try
                oSessions = New cSessions(oSurvey, [Properties].Item("sessions"))
            Catch
                oSessions = New cSessions(oSurvey)
            End Try

            Try
                oCaveInfos = New cCaveInfos(oSurvey, [Properties].Item("caveinfos"))
            Catch
                oCaveInfos = New cCaveInfos(oSurvey)
            End Try

            Try
                oCaveVisibilityProfiles = New cCaveVisibilityProfiles(oSurvey, [Properties].Item("cavevisibilityprofiles"))
            Catch
                oCaveVisibilityProfiles = New cCaveVisibilityProfiles(oSurvey)
            End Try

            Try
                oGPSProperties = New cGPSProperties(oSurvey, [Properties].Item("gps"))
            Catch
                oGPSProperties = New cGPSProperties(oSurvey)
            End Try

            Try
                oDesignProperties = New cPropertiesCollection(oSurvey, [Properties].Item("designproperties"))
            Catch
                oDesignProperties = New cPropertiesCollection(oSurvey)
            End Try

            Try
                oDataTables = New Data.cDataTables(oSurvey, [Properties].Item("datatables"))
            Catch
                oDataTables = New Data.cDataTables(oSurvey)
            End Try

            Try
                oHLs = New Properties.cHighlightsDetails(oSurvey, [Properties].Item("hlsds"))
            Catch
                oHLs = New Properties.cHighlightsDetails(oSurvey)
            End Try
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlProperties As XmlElement = document.CreateElement("properties")

            Call oXmlProperties.SetAttribute("id", sID)
            Call oXmlProperties.SetAttribute("name", sName)
            If sDescription <> "" Then Call oXmlProperties.SetAttribute("description", sDescription)
            If sClub <> "" Then Call oXmlProperties.SetAttribute("club", sClub)
            If sTeam <> "" Then Call oXmlProperties.SetAttribute("team", sTeam)
            If sAuthor <> "" Then Call oXmlProperties.SetAttribute("author", sAuthor)
            If sDesigner <> "" Then Call oXmlProperties.SetAttribute("designer", sDesigner)

            If sDefGrade <> "" Then Call oXmlProperties.SetAttribute("defgrade", sDefGrade)
            If sDefAccuracy <> "" Then Call oXmlProperties.SetAttribute("defaccuracy", sDefAccuracy)

            If sCreatorID <> "" Then Call oXmlProperties.SetAttribute("creatid", sCreatorID)
            If sCreatorVersion <> "" Then Call oXmlProperties.SetAttribute("creatversion", sCreatorVersion)
            If dCreationDate.HasValue Then Call oXmlProperties.SetAttribute("creatdate", dCreationDate.Value.ToString("O"))

            If sNote <> "" Then Call oXmlProperties.SetAttribute("note", sNote)

            Call oXmlProperties.SetAttribute("origin", sOrigin)

            Call oXmlProperties.SetAttribute("calculatemode", iCalculateMode.ToString("D"))
            Call oXmlProperties.SetAttribute("calculatetype", iCalculateType.ToString("D"))
            Call oXmlProperties.SetAttribute("calculateversion", iCalculateVersion)
            Call oXmlProperties.SetAttribute("ringcorrectionmode", iRingCorrectionMode.ToString("D"))
            Call oXmlProperties.SetAttribute("nordcorrectionmode", iNordCorrectionMode.ToString("D"))
            Call oXmlProperties.SetAttribute("inversionmode", iInversionMode.ToString("D"))
            Call oXmlProperties.SetAttribute("designwarpingmode", iDesignWarpingMode.ToString("D"))
            If bPlanWarpingDisabled Then
                Call oXmlProperties.SetAttribute("planwarpingdisabled", "1")
            End If
            If bProfileWarpingDisabled Then
                Call oXmlProperties.SetAttribute("profilewarpingdisabled", "1")
            End If
            If Not bShowWarpingDetails Then
                Call oXmlProperties.SetAttribute("showwarpingdetails", "0")
            End If

            If iDataFormat <> cSegment.DataFormatEnum.Normal Then Call oXmlProperties.SetAttribute("dataformat", iDataFormat.ToString("D"))
            If iDistanceType <> cSegment.DistanceTypeEnum.Meters Then Call oXmlProperties.SetAttribute("distancetype", iDistanceType.ToString("D"))
            If iBearingType <> cSegment.BearingTypeEnum.DecimalDegree Then Call oXmlProperties.SetAttribute("Bearingtype", iBearingType.ToString("D"))
            If iBearingDirection <> cSegment.MeasureDirectionEnum.Direct Then Call oXmlProperties.SetAttribute("bearingdirection", iBearingDirection.ToString("D"))
            If iInclinationType <> cSegment.InclinationTypeEnum.DecimalDegree Then Call oXmlProperties.SetAttribute("inclinationtype", iInclinationType.ToString("D"))
            If iInclinationDirection <> cSegment.MeasureDirectionEnum.Direct Then Call oXmlProperties.SetAttribute("inclinationdirection", iInclinationDirection.ToString("D"))
            If iDepthType <> cSegment.DepthTypeEnum.AbsoluteAtEnd Then Call oXmlProperties.SetAttribute("depthtype", iDepthType.ToString("D"))

            If sGrade <> "" Then Call oXmlProperties.SetAttribute("grade", sGrade)

            If sGlobalDeclination <> 0 Then oXmlProperties.SetAttribute("globaldeclination", modNumbers.NumberToString(sGlobalDeclination))
            If bGlobalDeclinationEnabled Then oXmlProperties.SetAttribute("globaldeclinationenabled", IIf(bGlobalDeclinationEnabled, 1, 0))

            If iNordType <> cSegment.NordTypeEnum.Magnetic Then oXmlProperties.SetAttribute("nordtype", iNordType.ToString("D"))
            If sDeclination <> 0 Then oXmlProperties.SetAttribute("declination", modNumbers.NumberToString(sDeclination))
            If bDeclinationEnabled Then oXmlProperties.SetAttribute("declinationenabled", IIf(bDeclinationEnabled, 1, 0))

            If iSideMeasuresType <> cSegment.SideMeasuresTypeEnum.PerpendicularToPrevious Then Call oXmlProperties.SetAttribute("sidemeasurestype", iSideMeasuresType.ToString("D"))
            If iSideMeasuresReferTo <> cSegment.SideMeasuresReferToEnum.EndPoint Then Call oXmlProperties.SetAttribute("sidemeasuresreferto", iSideMeasuresReferTo.ToString("D"))

            If sInfoBoxStructure <> "" Then oXmlProperties.SetAttribute("infoboxstructure", sInfoBoxStructure)
            If sTrigpointStructure <> "" Then Call oXmlProperties.SetAttribute("trigpointstructure", sTrigpointStructure)
            If sSpecialTrigpointStructure <> "" Then Call oXmlProperties.SetAttribute("specialtrigpointstructure", sSpecialTrigpointStructure)

            If iSplayMode <> cSurvey.SplayModeEnum.None Then oXmlProperties.SetAttribute("splaymode", iSplayMode)
            'If bBindSplaySegment Then oXmlProperties.SetAttribute("bindsplaysegment", "1")
            If bBindCrossSection Then oXmlProperties.SetAttribute("bindcrosssection", "1")

            Call oSessions.SaveTo(File, document, oXmlProperties)
            Call oCaveInfos.SaveTo(File, document, oXmlProperties)
            Call oCaveVisibilityProfiles.SaveTo(File, document, oXmlProperties)
            Call oGPSProperties.SaveTo(File, document, oXmlProperties)

            Call oDesignProperties.SaveTo(File, document, "designproperties", oXmlProperties)

            If iThreeDModelMode <> ThreeDModelModeEnum.Simple Then Call oXmlProperties.SetAttribute("threedmodelmode", iThreeDModelMode)
            If sThreeDNormalizationFactor <> 1.5 Then Call oXmlProperties.SetAttribute("threednormalizationfactor", modNumbers.NumberToString(sThreeDNormalizationFactor, "0.0"))
            If sThreeDOversamplingFactor <> 1 Then Call oXmlProperties.SetAttribute("threedoversamplingfactor", modNumbers.NumberToString(sThreeDOversamplingFactor, "0.0"))

            If Not bThreeDLochShowSplay Then Call oXmlProperties.SetAttribute("threedlochshowsplay", "0")

            If iThreeDSurfaceModelLod <> 1 Then oXmlProperties.SetAttribute("threedsurfacemodellod", iThreeDSurfaceModelLod)
            If sThreeDSurfaceTextureLod <> 1.5 Then oXmlProperties.SetAttribute("threedsurfacetexturelod", modNumbers.NumberToString(sThreeDSurfaceTextureLod, "0.0"))

            If iVerticalLRUDThreshold <> 90 Then Call oXmlProperties.SetAttribute("VerticalLRUDThreshold", iVerticalLRUDThreshold)

            If bSurfaceProfile Then Call oXmlProperties.SetAttribute("surfaceprofile", "1")
            If sSurfaceProfileElevation <> "" Then Call oXmlProperties.SetAttribute("surfaceprofileelevation", sSurfaceProfileElevation)
            If bSurfaceProfileShow Then Call oXmlProperties.SetAttribute("surfaceprofileshow", "1")

            If Not bHistoryEnabled Then Call oXmlProperties.SetAttribute("historyenabled", "0")

            If bShowLegacyPrintAndExportObjects Then oXmlProperties.SetAttribute("slpeo", "1")

            Call oDataTables.SaveTo(File, document, oXmlProperties)

            Call oHLs.SaveTo(File, document, oXmlProperties)

            Call Parent.AppendChild(oXmlProperties)
            Return oXmlProperties
        End Function

        Public Sub Clear()
            sID = ""
            sName = ""
            sDescription = ""
            sClub = ""
            sTeam = ""
            sAuthor = ""
            sDesigner = ""

            sNote = ""

            sDefGrade = ""
            sDefAccuracy = ""

            iCalculateMode = iDefaultCalculateMode
            iCalculateType = iDefaultCalculateType
            iRingCorrectionMode = iDefaultRingCorrectionMode
            iNordCorrectionMode = iDefaultNordCorrectionMode

            iDistanceType = cSegment.DistanceTypeEnum.Meters
            iBearingType = cSegment.BearingTypeEnum.DecimalDegree
            iInclinationType = cSegment.InclinationTypeEnum.DecimalDegree
            iDepthType = cSegment.DepthTypeEnum.AbsoluteAtEnd

            sGlobalDeclination = 0
            bGlobalDeclinationEnabled = False

            iNordType = cSegment.NordTypeEnum.Magnetic

            sDeclination = 0
            iSideMeasuresType = cSegment.SideMeasuresTypeEnum.PerpendicularToPrevious
            iSideMeasuresReferTo = cSegment.SideMeasuresReferToEnum.EndPoint

            iDesignWarpingMode = iDefaultDesignWarpingMode

            Call oSessions.Clear()
            Call oCaveInfos.Clear()
            Call oCaveVisibilityProfiles.Clear()
            Call oGPSProperties.Clear()

            Call oDesignProperties.Clear()

            Call oHLs.Clear()
            'sBaseSignScaleFactor = 1
            'sBaseTextScaleFactor = 0.05
        End Sub

        Public Property BearingDirection As cSegment.MeasureDirectionEnum Implements cIMeasure.BearingDirection
            Get
                Return iBearingDirection
            End Get
            Set(value As cSegment.MeasureDirectionEnum)
                If iBearingDirection <> value Then
                    iBearingDirection = value
                End If
            End Set
        End Property

        Public Property InclinationDirection As cSegment.MeasureDirectionEnum Implements cIMeasure.InclinationDirection
            Get
                Return iInclinationDirection
            End Get
            Set(value As cSegment.MeasureDirectionEnum)
                If iInclinationDirection <> value Then
                    iInclinationDirection = value
                End If
            End Set
        End Property
    End Class
End Namespace