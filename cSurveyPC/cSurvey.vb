Imports System.Xml
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Scale
Imports cSurveyPC.cSurvey.Calculate
Imports cSurveyPC.cSurvey.CaveRegister

Namespace cSurvey
    Public Class cSurvey
        Public Const Version As String = "1.14"

        Private sID As String

        'Private oTool As cEditBaseTools

        Private oGrades As cGrades
        Private oProperties As cProperties
        Private WithEvents oSegments As cSegments
        Private WithEvents oTrigPoints As cTrigPoints

        Private oAttachments As cAttachments
        Private oCliparts As cCliparts
        Private oSigns As cSigns
        Private oPens As cPens
        Private oBrushes As cBrushes

        Private WithEvents oPlan As cDesignPlan
        Private WithEvents oProfile As cDesignProfile
        Private WithEvents oCrossSections As cDesignCrossSections
        Private oSketches As cDesignSketches

        Private WithEvents oCalc As cCalculate

        Private oEditPaintObjects As cEditPaintObjects

        Private oScaleRules As cScaleRules
        Private oOptions As cOptionsCollection

        Private oPreviewProfiles As cPreviewProfiles
        Private oExportProfiles As cExportProfiles
        Private oViewerProfiles As cViewerProfiles

        Private oLinkedSurveys As cLinkedSurveys

        Private iInvalidated As cCalculate.InvalidateEnum

        Private oSharedSettings As cSharedSettings

        Private WithEvents oSurface As cSurface

        'Private oCaveRegister As cCaveRegister

        Private oTexts As cTexts

        Public ReadOnly Property Texts As cTexts
            Get
                Return oTexts
            End Get
        End Property

        Public Enum SaveOptionsEnum
            None = 0
            Silent = &H1
            ForClipboard = &H2
            ForImport = &H4
            NoHistory = &H10
        End Enum

        Public Enum DirectionEnum
            Right = 0
            Left = 1
            Vertical = 2
        End Enum

        Public Enum IgnoreEnum
            NotSet = 0
            Ignore = 1
            Process = 2
        End Enum

        Public Enum DesignBindingModeEnum
            [Automatic] = 0
            [OnEndEdit] = 1
            [Manual] = 2
        End Enum

        Public Enum DesignWarpingStateEnum
            [Active] = 0
            [Paused] = 1
        End Enum

        Public Enum DesignWarpingModeEnum
            [None] = 0
            [Default] = 1
        End Enum

        Public Enum SplayModeEnum
            [None] = 0
            [Automatic] = 1
        End Enum

        Public Enum CalculateModeEnum
            Manual = 0
            Automatic = 1
        End Enum

        Public Enum PriorityModeEnum
            [Default] = 0
            [AllowEdit] = 1
        End Enum

        Public Enum CalculateTypeEnum
            None = 0
            Internal = 1
            Therion = 2
        End Enum

        Public Enum NordCorrectionModeEnum
            None = 0
            DeclinationBySession = 1
        End Enum

        Public Enum RingCorrectionModeEnum
            None = 0
            Dummy = 1
            Simple = 2
        End Enum

        Public Enum InversioneModeEnum
            Relative = 0
            Absolute = 1
        End Enum

        Public Enum CrossSectionsChangeActionEnum
            Add = 0
            Remove = 1
        End Enum

        Public Enum SegmentsChangeActionEnum
            Add = 0
            Remove = 1
            RemoveRange = 2
            Change = 3
            ChangeRange = 4
            Clear = 5
            Reassigned = 6
            BeforeAdd = 10
            Splay = 20
        End Enum

        Public Enum TrigpointsChangeActionEnum
            Rebind = 0
            Change = 1
        End Enum

        Public Class cFileConversionEventArgs
            Inherits EventArgs

            Public Cancel As Boolean
            Private sCurrentVersion As String
            Private sRequestedVersion As String

            Public ReadOnly Property CurrentVersion As String
                Get
                    Return sCurrentVersion
                End Get
            End Property

            Public ReadOnly Property RequestedVersion As String
                Get
                    Return sRequestedVersion
                End Get
            End Property

            Friend Sub New(CurrentVersion As String, RequestedVersion As String)
                sCurrentVersion = CurrentVersion
                sRequestedVersion = RequestedVersion
            End Sub
        End Class
        Public Event OnFileConversionRequest(ByVal Sender As Object, ByVal Args As cFileConversionEventArgs)

        Public Class OnSegmentChangeEventArgs
            Inherits EventArgs

            Friend Sub New(ByVal Action As SegmentsChangeActionEnum)
                Action = Action
            End Sub

            Friend Sub New(ByVal Action As SegmentsChangeActionEnum, ByVal Segment As cSegment, ByVal Index As Integer)
                iAction = Action
                oSegment = Segment
                iIndex = Index
            End Sub

            Friend Sub New(ByVal Action As SegmentsChangeActionEnum, ByVal OnSegmentEventArgs As cSegments.OnSegmentEventArgs)
                iAction = Action
                If IsNothing(OnSegmentEventArgs) Then
                    iIndex = -1
                Else
                    oSegment = OnSegmentEventArgs.Segment
                    iIndex = OnSegmentEventArgs.Index
                End If
            End Sub

            Friend Sub New(ByVal Action As SegmentsChangeActionEnum, ByVal OnSegmentsEventArgs As cSegments.OnSegmentsEventArgs)
                iAction = Action
                iIndex = -1
            End Sub

            Private iAction As SegmentsChangeActionEnum
            Private oSegment As cSegment
            Private iIndex As Integer

            Public ReadOnly Property Action() As SegmentsChangeActionEnum
                Get
                    Return iAction
                End Get
            End Property

            Public ReadOnly Property Segment() As cSegment
                Get
                    Return oSegment
                End Get
            End Property

            Public ReadOnly Property Index() As Integer
                Get
                    Return iIndex
                End Get
            End Property
        End Class
        Public Event OnSegmentsChange(ByVal Sender As Object, ByVal Args As OnSegmentChangeEventArgs)

        Public Class OnCrossSectionChangeEventArgs
            Inherits EventArgs

            Friend Sub New(ByVal Action As CrossSectionsChangeActionEnum)
                Action = Action
            End Sub

            Friend Sub New(ByVal Action As CrossSectionsChangeActionEnum, ByVal CrossSection As cDesignCrossSection, ByVal Index As Integer)
                iAction = Action
                oCrossSection = CrossSection
                iIndex = Index
            End Sub

            Friend Sub New(ByVal Action As SegmentsChangeActionEnum, ByVal OnCrossSectionEventArgs As cDesignCrossSections.OnDesignCrossSectionEventArgs)
                iAction = Action
                oCrossSection = OnCrossSectionEventArgs.CrossSection
                iIndex = OnCrossSectionEventArgs.Index
            End Sub

            Private iAction As CrossSectionsChangeActionEnum
            Private oCrossSection As cDesignCrossSection
            Private iIndex As Integer

            Public ReadOnly Property Action() As CrossSectionsChangeActionEnum
                Get
                    Return iAction
                End Get
            End Property

            Public ReadOnly Property CrossSection() As cDesignCrossSection
                Get
                    Return oCrossSection
                End Get
            End Property

            Public ReadOnly Property Index() As Integer
                Get
                    Return iIndex
                End Get
            End Property
        End Class
        Public Event OnCrossSectionsChange(ByVal Sender As Object, ByVal Args As OnCrossSectionChangeEventArgs)

        Public Class OnTrigpointChangeEventArgs
            Inherits EventArgs

            Friend Sub New(ByVal Action As TrigpointsChangeActionEnum)
                Action = Action
            End Sub

            Friend Sub New(ByVal Action As TrigpointsChangeActionEnum, ByVal Trigpoint As cTrigPoint, ByVal Index As Integer)
                iAction = Action
                oTrigpoint = Trigpoint
            End Sub

            Friend Sub New(ByVal Action As TrigpointsChangeActionEnum, ByVal OnTrigpointEventArgs As cTrigPoints.OnTrigpointEventArgs)
                iAction = Action
                oTrigpoint = OnTrigpointEventArgs.Trigpoint
            End Sub

            Private iAction As TrigpointsChangeActionEnum
            Private oTrigpoint As cTrigPoint

            Public ReadOnly Property Action() As TrigpointsChangeActionEnum
                Get
                    Return iAction
                End Get
            End Property

            Public ReadOnly Property Trigpoint() As cTrigPoint
                Get
                    Return oTrigpoint
                End Get
            End Property
        End Class
        Public Event OnTrigpointsChange(ByVal Sender As Object, ByVal Args As OnTrigpointChangeEventArgs)

        Public Class OnPropertiesChangedEventArgs
            Inherits EventArgs

            Public Enum PropertiesChangeSourceEnum
                DefaultProperties = 0
                ScaleProperties = 1
                Scale = 2
                MainProperties = 3
                MasterSlaveSettings = 4
                DesignWarpingState = 5
                ElevationProfile = 6
            End Enum

            Private iSource As PropertiesChangeSourceEnum

            Public ReadOnly Property Source As PropertiesChangeSourceEnum
                Get
                    Return iSource
                End Get
            End Property

            Friend Sub New(ByVal Source As PropertiesChangeSourceEnum)
                iSource = Source
            End Sub
        End Class
        Public Event OnBeforePropertiesChange(ByVal Sender As Object, ByVal Args As OnPropertiesChangedEventArgs)
        Public Event OnPropertiesChanged(ByVal Sender As Object, ByVal Args As OnPropertiesChangedEventArgs)

        Public Class OnGetDefaultSignFromGalleryEventArgs
            Inherits EventArgs

            Private iSign As Items.cIItemSign.SignEnum
            Private sFilename As String = Nothing
            Private iDataFormat As Items.cIItemClipartBase.cClipartDataFormatEnum

            Public ReadOnly Property Sign As Items.cIItemSign.SignEnum
                Get
                    Return iSign
                End Get
            End Property

            Public Property DataFormat As Items.cIItemClipartBase.cClipartDataFormatEnum
                Get
                    Return iDataFormat
                End Get
                Set(value As Items.cIItemClipartBase.cClipartDataFormatEnum)
                    iDataFormat = value
                End Set
            End Property

            Public Property Filename As String
                Get
                    Return sFilename
                End Get
                Set(value As String)
                    sFilename = value
                End Set
            End Property

            Friend Sub New(ByVal Sign As Items.cIItemSign.SignEnum)
                iSign = Sign
            End Sub
        End Class
        Public Event OnGetDefaultSignFromGallery(Sender As Object, Args As OnGetDefaultSignFromGalleryEventArgs)

        Public Class OnSurfaceChangedEventArgs
            Inherits EventArgs

            Public Enum SurfaceChangeSourceEnum
                Surface = 0
                Elevation = 1
            End Enum

            Private iSource As SurfaceChangeSourceEnum

            Public ReadOnly Property Source As SurfaceChangeSourceEnum
                Get
                    Return iSource
                End Get
            End Property

            Friend Sub New(ByVal Source As SurfaceChangeSourceEnum)
                iSource = Source
            End Sub
        End Class
        Public Event OnSurfaceChanged(ByVal Sender As Object, ByVal Args As OnSurfaceChangedEventArgs)

        Public Class OnWarpingDetailsEventArgs
            Inherits EventArgs

            Private oSegmentsToProcess As cISegmentCollection
            Private iDesignType As cIDesign.cDesignTypeEnum

            Private iResult As DialogResult

            Public ReadOnly Property SegmentsToProcess As cISegmentCollection
                Get
                    Return oSegmentsToProcess
                End Get
            End Property

            Public ReadOnly Property DesignType As cIDesign.cDesignTypeEnum
                Get
                    Return iDesignType
                End Get
            End Property

            Public Property Result As DialogResult
                Get
                    Return iResult
                End Get
                Set(value As DialogResult)
                    iResult = value
                End Set
            End Property

            Sub New(SegmentsToProcess As cISegmentCollection, DesignType As cIDesign.cDesignTypeEnum)
                oSegmentsToProcess = SegmentsToProcess
                iDesignType = DesignType
            End Sub
        End Class
        Public Event OnWarpingDetails(Sender As Object, Args As OnWarpingDetailsEventArgs)

        Public Class OnCleanUpFoundUndefinedCavesEventArgs
            Inherits EventArgs

            Private oSource As cDesign
            Private oListOfUndefinedCaves As Dictionary(Of String, cDesign.cCleanUpUndefinedCaveAndBranchItem) = New Dictionary(Of String, cDesign.cCleanUpUndefinedCaveAndBranchItem)
            Private bCancel As Boolean

            Friend Sub New(Source As cDesign, ListOfUndefinedCaves As Dictionary(Of String, cDesign.cCleanUpUndefinedCaveAndBranchItem))
                oSource = Source
                oListOfUndefinedCaves = ListOfUndefinedCaves
            End Sub

            Public ReadOnly Property Source As cDesign
                Get
                    Return oSource
                End Get
            End Property

            Public Property Cancel As Boolean
                Get
                    Return bCancel
                End Get
                Set(value As Boolean)
                    bCancel = value
                End Set
            End Property

            Public ReadOnly Property ListOfUndefinedCaves As Dictionary(Of String, cDesign.cCleanUpUndefinedCaveAndBranchItem)
                Get
                    Return oListOfUndefinedCaves
                End Get
            End Property
        End Class
        Public Event OnCleanUpFoundUndefinedCavesEvent(ByVal Sender As Object, ByVal Args As OnCleanUpFoundUndefinedCavesEventArgs)

        Public Class OnProgressEventArgs
            Inherits EventArgs

            Public Enum ProgressActionEnum
                [Progress] = &H0
                [Begin] = &H1
                [End] = &H2
                [Reset] = &HF
            End Enum

            Public Enum ProgressOptionsEnum
                None = &H0
                ShowPercentage = &H10
                ShowProgressWindow = &H100
                ImageMask = &HF000
                ImageLoad = &H1000
                ImageSave = &H2000
                ImageExport = &H3000
                ImageCalculate = &H4000
                ImagePaint = &H5000
                ImageConvert = &H6000
                ImageImport = &H7000
                ImageDownload = &H8000
                ImageFilter = &H9000
                ImageWarping = &HA000
                Image3D = &HB000
            End Enum

            Private iAction As ProgressActionEnum
            Private sText As String
            Private sProgress As Single
            Private iOptions As ProgressOptionsEnum
            Private sTask As String

            Friend Sub New(Task As String, Action As ProgressActionEnum, ByVal Text As String, ByVal Progress As Single, Optional Options As ProgressOptionsEnum = ProgressOptionsEnum.None)
                iAction = Action
                sText = Text
                sProgress = Progress
                iOptions = Options
                sTask = Task
            End Sub

            Public ReadOnly Property Task As String
                Get
                    Return sTask
                End Get
            End Property

            Public ReadOnly Property Options As ProgressOptionsEnum
                Get
                    Return iOptions
                End Get
            End Property

            Public ReadOnly Property Action As ProgressActionEnum
                Get
                    Return iAction
                End Get
            End Property

            Public ReadOnly Property Text As String
                Get
                    Return sText
                End Get
            End Property

            Public ReadOnly Property Progress As Single
                Get
                    Return sProgress
                End Get
            End Property
        End Class
        Public Event OnProgress(ByVal Sender As Object, ByVal Args As OnProgressEventArgs)

        Public Class OnDebugEventArgs
            Inherits EventArgs

            Public Key As String
            Public Value As Object

            Public Sub New(ByVal Key As String, Value As Object)
                Me.Key = Key
                Me.Value = Value
            End Sub
        End Class

        Public Enum LogEntryType
            [Unknown] = &H0
            [Error] = &H1
            [Warning] = &H2
            [Information] = &H4
            [Important] = &H16
        End Enum

        Public Class OnLogEventArgs
            Public Type As LogEntryType
            Public Text As String
            Public Sub New(ByVal Type As LogEntryType, ByVal Text As String)
                Me.Type = Type
                Me.Text = Text
            End Sub
        End Class

        Public Class OnErrorLogEventArgs
            Inherits OnLogEventArgs

            Private oException As Exception

            Public ReadOnly Property Exception As Exception
                Get
                    Return oException
                End Get
            End Property
            Public Sub New(Text As String, Exception As Exception)
                MyBase.New(LogEntryType.Error, Text)
                oException = Exception
            End Sub
        End Class

        Public Event OnLog(ByVal Sender As Object, ByVal Args As OnLogEventArgs)
        Public Event OnDebug(ByVal Sender As Object, ByVal Args As OnDebugEventArgs)

        Public Class OnCalculateEventArgs
            Inherits EventArgs
        End Class
        Public Event OnCalculate(Sender As Object, Args As OnCalculateEventArgs)
        Public Class OnArrangePriorityEventArgs
            Inherits EventArgs
        End Class
        Public Event OnArrangePriority(sender As Object, Args As OnArrangePriorityEventArgs)
        '---------------------------------------------------------------------------------------------------------------------------------------------------------

        Public Sub New()
            sID = Guid.NewGuid.ToString

            oTexts = New cTexts(Me)
            oGrades = New cGrades(Me)
            oProperties = New cProperties(Me)
            oAttachments = New cAttachments(Me)
            oSegments = New cSegments(Me)
            oTrigPoints = New cTrigPoints(Me)
            oCliparts = New cCliparts(Me)
            oSigns = New cSigns(Me)
            oPens = New cPens(Me)
            oBrushes = New cBrushes(Me)

            oPlan = New cDesignPlan(Me)
            oProfile = New cDesignProfile(Me)
            oCrossSections = New cDesignCrossSections(Me)
            oSketches = New cDesignSketches(Me)
            oCalc = New cCalculate(Me)

            oScaleRules = New cScaleRules(Me)

            oEditPaintObjects = New cEditPaintObjects(Me)
            oOptions = New cOptionsCollection(Me)

            oPreviewProfiles = New cPreviewProfiles(Me)
            oExportProfiles = New cExportProfiles(Me)
            oViewerProfiles = New cViewerProfiles(Me)

            oLinkedSurveys = New cLinkedSurveys(Me)

            oSharedSettings = New cSharedSettings(Me)

            oSurface = New cSurface(Me)

            'oCaveRegister = New cCaveRegister(Me)

            oMasterSlave = New Master.cMasterSlave(Me)

            'oTool = New cEditBaseTools(Me)
        End Sub

        'Public ReadOnly Property CaveRegister As cCaveRegister
        '    Get
        '        Return oCaveRegister
        '    End Get
        'End Property

        Public ReadOnly Property Surface As cSurface
            Get
                Return oSurface
            End Get
        End Property

        Public ReadOnly Property ScaleRules As cScaleRules
            Get
                Return oScaleRules
            End Get
        End Property

        Friend ReadOnly Property EditPaintObjects() As cEditPaintObjects
            Get
                Return oEditPaintObjects
            End Get
        End Property

        Public ReadOnly Property ID As String
            Get
                Return sID
            End Get
        End Property

        Friend Sub NewID()
            sID = Guid.NewGuid.ToString
        End Sub

        Public ReadOnly Property SharedSettings() As cSharedSettings
            Get
                Return oSharedSettings
            End Get
        End Property

        Public Class OnLinkedSurveysEventargs
            Inherits EventArgs

            Private oItem As cLinkedSurvey

            Public ReadOnly Property Item As cLinkedSurvey
                Get
                    Return oItem
                End Get
            End Property

            Public Sub New(Item As cLinkedSurvey)
                oItem = Item
            End Sub
        End Class

        Public Class OnLinkedSurveysAddEventargs
            Inherits OnLinkedSurveysEventargs

            Private bRecursiveLoad As Boolean
            Private bPrioritizeChildren As Boolean

            Public ReadOnly Property NewItem As cLinkedSurvey
                Get
                    Return Item
                End Get
            End Property

            Public Property PrioritizeChildren As Boolean
                Get
                    Return bPrioritizeChildren
                End Get
                Set(value As Boolean)
                    bPrioritizeChildren = value
                End Set
            End Property


            Public Property RecursiveLoad As Boolean
                Get
                    Return bRecursiveLoad
                End Get
                Set(value As Boolean)
                    bRecursiveLoad = value
                End Set
            End Property

            Public Sub New(Item As cLinkedSurvey)
                Call MyBase.New(Item)
            End Sub
        End Class
        Public Class OnLinkedSurveysLoadEventargs
            Inherits OnLinkedSurveysEventargs

            Private bRefreshOnLoad As Boolean

            Public Property RefreshOnLoad As Boolean
                Get
                    Return bRefreshOnLoad
                End Get
                Set(value As Boolean)
                    bRefreshOnLoad = value
                End Set
            End Property

            Public Sub New(Item As cLinkedSurvey)
                Call MyBase.New(Item)
            End Sub
        End Class
        Public Event OnLinkedSurveysAdd(Sender As cSurvey, Args As OnLinkedSurveysAddEventargs)
        Public Event OnLinkedSurveysLoad(Sender As cSurvey, Args As OnLinkedSurveysLoadEventargs)
        Public Event OnLinkedSurveysRefresh(Sender As cSurvey, Args As EventArgs)

        Friend Sub RaiseOnLinkedSurveysRefresh()
            RaiseEvent OnLinkedSurveysRefresh(Me, EventArgs.Empty)
        End Sub

        Friend Sub RaiseOnLinkedSurveysLoad(Item As cLinkedSurvey, ByRef RefreshOnLoad As Boolean)
            Dim oArg As OnLinkedSurveysLoadEventargs = New OnLinkedSurveysLoadEventargs(Item)
            RaiseEvent OnLinkedSurveysLoad(Me, oArg)
            RefreshOnLoad = oArg.RefreshOnLoad
        End Sub

        Friend Sub RaiseOnLinkedSurveysAdd(Item As cLinkedSurvey, ByRef RecursiveLoad As Boolean, ByRef PrioritizeChildren As Boolean)
            Dim oArg As OnLinkedSurveysAddEventargs = New OnLinkedSurveysAddEventargs(Item)
            RaiseEvent OnLinkedSurveysAdd(Me, oArg)
            RecursiveLoad = oArg.RecursiveLoad
            PrioritizeChildren = oArg.PrioritizeChildren
        End Sub

        Friend Function RaiseOnWarpingDetailsEvent(SegmentToProcess As cISegmentCollection, DesignType As cIDesign.cDesignTypeEnum) As DialogResult
            Dim oArg As OnWarpingDetailsEventArgs = New OnWarpingDetailsEventArgs(SegmentToProcess, DesignType)
            RaiseEvent OnWarpingDetails(Me, oArg)
            Return oArg.Result
        End Function

        Friend Sub RaiseDebugEvent(Key As String, Optional Value As Object = Nothing)
            RaiseEvent OnDebug(Me, New OnDebugEventArgs(Key, Value))
        End Sub

        Friend Sub RaiseOnLogEvent(ByVal Type As LogEntryType, Optional ByVal Text As String = "")
            RaiseEvent OnLog(Me, New OnLogEventArgs(Type, Text))
        End Sub

        Friend Sub RaiseOnErrorLogEvent(ByVal Text As String, Exception As Exception)
            RaiseEvent OnLog(Me, New OnErrorLogEventArgs(Text, Exception))
        End Sub

        Public Sub Redraw(Optional Options As cOptions = Nothing)
            Call oPlan.Redraw(Options)
            Call oProfile.Redraw(Options)
        End Sub

        Friend Sub RaiseOnGetDefaultSignFromGallery(Sign As Items.cIItemSign.SignEnum, ByRef Filename As String, ByRef DataFormat As Items.cIItemClipartBase.cClipartDataFormatEnum)
            Dim oArgs As OnGetDefaultSignFromGalleryEventArgs = New OnGetDefaultSignFromGalleryEventArgs(Sign)
            RaiseEvent OnGetDefaultSignFromGallery(Me, oArgs)
            Filename = oArgs.Filename
            DataFormat = oArgs.DataFormat
        End Sub

        Friend Sub RaiseOnPropertiesChanged(ByVal Source As OnPropertiesChangedEventArgs.PropertiesChangeSourceEnum)
            RaiseEvent OnBeforePropertiesChange(Me, New OnPropertiesChangedEventArgs(Source))
            'Call oPlan.Plot.Caches.Invalidate()
            'Call oProfile.Plot.Caches.Invalidate()
            RaiseEvent OnPropertiesChanged(Me, New OnPropertiesChangedEventArgs(Source))
        End Sub

        'Friend Sub Lock()
        '    Call oLockState.Push(bLockState)
        '    If Not bLockState Then
        '        bLockState = True
        '        RaiseEvent OnLock(Me, New OnLockEventArgs)
        '    End If
        'End Sub

        'Friend Sub Unlock()
        '    bLockState = oLockState.Pop
        '    If Not bLockState Then
        '        RaiseEvent OnUnlock(Me, New OnLockEventArgs)
        '    End If
        'End Sub

        Friend Sub RaiseOnProgressEvent(Task As String, Action As cSurvey.OnProgressEventArgs.ProgressActionEnum, ByVal Text As String, ByVal Progress As Single, Optional Options As cSurvey.OnProgressEventArgs.ProgressOptionsEnum = OnProgressEventArgs.ProgressOptionsEnum.None)
            RaiseEvent OnProgress(Me, New OnProgressEventArgs(Task, Action, Text, Progress, Options))
        End Sub

        Public Shared Function Check(ByVal filename As String) As cActionResult
            Try
                If My.Computer.FileSystem.FileExists(filename) Then
                    Using oFile As cFile = New cFile(filename)
                        Dim oXml As XmlDocument = oFile.Document
                        Dim oXmlRoot As XmlElement = oXml.Item("csurvey")
                        Try
                            Dim oXmlProperties As XmlElement = oXmlRoot.Item("properties")
                            Dim iCalculateMode As CalculateTypeEnum = oXmlProperties.GetAttribute("calculatemode")
                            If iCalculateMode = CalculateTypeEnum.Therion Then
                                Dim sThProcess As String = My.Application.Settings.GetSetting("therion.path", "")
                                If sThProcess = "" Then
                                    Return New cActionResult(False, "survey.check", modMain.GetLocalizedString("csurvey.textpart101"))
                                End If
                            End If
                            Dim iInversionMode As InversioneModeEnum = oXmlProperties.GetAttribute("inversionmode")
                            If iInversionMode <> InversioneModeEnum.Absolute Then
                                If Not (My.Computer.Keyboard.ShiftKeyDown And My.Computer.Keyboard.CtrlKeyDown) Then
                                    Return New cActionResult(False, "survey.check", modMain.GetLocalizedString("csurvey.textpart123"))
                                End If
                            End If
                        Catch
                        End Try
                    End Using
                    'more future controls here....
                Else
                    Return New cActionResult(False, "survey.check", String.Format(modMain.GetLocalizedString("csurvey.textpart102a"), filename))
                End If
            Catch ex As Exception
                Return New cActionResult(False, "survey.check", String.Format(modMain.GetLocalizedString("csurvey.textpart102"), filename, ex.Message))
            End Try
            Return New cActionResult
        End Function

        Private oMasterSlave As Master.cMasterSlave

        Public ReadOnly Property MasterSlave As Master.cMasterSlave
            Get
                Return oMasterSlave
            End Get
        End Property

        <Flags> Public Enum LoadOptionsEnum
            None = &H0
            IsLinkedSurvey = &H1
            FixTopoDroid = &H100
            Update = &H10
        End Enum

        Public Function Load(ByVal Filename As String, Optional LoadOptions As LoadOptionsEnum = LoadOptionsEnum.None) As cActionResult
            Call RaiseOnLogEvent(LogEntryType.Information, "loading: " & Filename)
            Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Begin, String.Format(modMain.GetLocalizedString("csurvey.textpart100"), Filename), 0, OnProgressEventArgs.ProgressOptionsEnum.ImageLoad Or OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow)

            Using oFile As cFile = New cFile(Filename)
                Dim oXml As XmlDocument = oFile.Document

                If ((pGetFileCreatID(oXml) = "topodroid" AndAlso Not pGetFileCreatPostProcessed(oXml)) OrElse (LoadOptions And LoadOptionsEnum.FixTopoDroid) = LoadOptionsEnum.FixTopoDroid) OrElse modOpeningFlags.OFRegenerateSegmentsID Then
                    Call modImport.FixTopodroidCSX(oXml)
                End If

                Dim bOk As Boolean
                Dim bCancel As Boolean
                Dim bRequested As Boolean = (LoadOptions And LoadOptionsEnum.Update) = LoadOptionsEnum.Update
                Dim sCurrentVersion As String = pGetFileVersion(oXml)
                Do
                    Select Case sCurrentVersion
                        Case Version, "-1"  '-1 is meta version for file generated from other software that does not include calculate data...
                            bOk = True
                        Case "1.00"
                            Dim oArgs As cFileConversionEventArgs = New cFileConversionEventArgs(sCurrentVersion, Version)
                            If Not bRequested Then
                                RaiseEvent OnFileConversionRequest(Me, oArgs)
                            End If
                            If oArgs.Cancel Then
                                bCancel = True
                            Else
                                bRequested = True
                                Dim oSegments As XmlElement = oXml.Item("csurvey").Item("segments")
                                Dim iIndex As Integer = 0
                                Dim iCount As Integer = oSegments.ChildNodes.Count
                                For Each oSegment As XmlElement In oSegments
                                    iIndex += 1
                                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("csurvey.textpart10"), iIndex / iCount)
                                    Dim dDirection As Decimal = modNumbers.StringToDecimal(modXML.GetAttributeValue(oSegment, "direction", 0))
                                    Call oSegment.SetAttribute("bearing", modNumbers.NumberToString(dDirection))
                                    Dim bDirection As Boolean = modXML.GetAttributeValue(oSegment, "inverted", False)
                                    Call oSegment.SetAttribute("direction", IIf(bDirection, "1", "0"))
                                Next
                                sCurrentVersion = "1.01"
                            End If
                        Case "1.01"
                            Dim oArgs As cFileConversionEventArgs = New cFileConversionEventArgs(sCurrentVersion, Version)
                            If Not bRequested Then
                                RaiseEvent OnFileConversionRequest(Me, oArgs)
                            End If
                            If oArgs.Cancel Then
                                bCancel = True
                            Else
                                bRequested = True
                                Dim oSegments As XmlElement = oXml.Item("csurvey").Item("segments")
                                Dim iIndex As Integer = 0
                                Dim iCount As Integer = oSegments.ChildNodes.Count
                                For Each oSegment As XmlElement In oSegments
                                    iIndex += 1
                                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("csurvey.textpart11"), iIndex / iCount)
                                    Dim dLeft As Decimal = modNumbers.StringToDecimal(modXML.GetAttributeValue(oSegment, "sx", 0))
                                    Call oSegment.SetAttribute("l", modNumbers.NumberToString(dLeft))
                                    Dim dRight As Decimal = modNumbers.StringToDecimal(modXML.GetAttributeValue(oSegment, "dx", 0))
                                    Call oSegment.SetAttribute("r", modNumbers.NumberToString(dRight))
                                    Dim dUp As Decimal = modNumbers.StringToDecimal(modXML.GetAttributeValue(oSegment, "top", 0))
                                    Call oSegment.SetAttribute("u", modNumbers.NumberToString(dUp))
                                    Dim dDown As Decimal = modNumbers.StringToDecimal(modXML.GetAttributeValue(oSegment, "bottom", 0))
                                    Call oSegment.SetAttribute("d", modNumbers.NumberToString(dDown))
                                Next
                                sCurrentVersion = "1.02"
                            End If
                        Case "1.02"
                            Dim oArgs As cFileConversionEventArgs = New cFileConversionEventArgs(sCurrentVersion, Version)
                            If Not bRequested Then
                                RaiseEvent OnFileConversionRequest(Me, oArgs)
                            End If
                            If oArgs.Cancel Then
                                bCancel = True
                            Else
                                bRequested = True
                                Dim oProperties As XmlElement = oXml.Item("csurvey").Item("properties")
                                Dim sGrade As String = modXML.GetAttributeValue(oProperties, "grade", "")
                                Dim sAccuracy As String = modXML.GetAttributeValue(oProperties, "accuracy", "")
                                If sGrade <> "" Then
                                    Call oProperties.SetAttribute("defgrade", sGrade)
                                    Call oProperties.RemoveAttribute("grade")
                                End If
                                If sAccuracy <> "" Then
                                    Call oProperties.SetAttribute("defaccuracy", sAccuracy)
                                    Call oProperties.RemoveAttribute("accuracy")
                                End If
                                sCurrentVersion = "1.03"
                            End If
                        Case "1.03"
                            Dim oArgs As cFileConversionEventArgs = New cFileConversionEventArgs(sCurrentVersion, Version)
                            If Not bRequested Then
                                RaiseEvent OnFileConversionRequest(Me, oArgs)
                            End If
                            If oArgs.Cancel Then
                                bCancel = True
                            Else
                                bRequested = True

                                Dim iLineType As Items.cIItemLine.LineTypeEnum
                                Dim iNewLineType As Items.cIItemLine.LineTypeEnum

                                Dim oDesignProperties As XmlElement = oXml.Item("csurvey").Item("properties").Item("designproperties")
                                If Not oDesignProperties Is Nothing AndAlso Not oDesignProperties.Item("linetype") Is Nothing Then
                                    iLineType = Integer.Parse(oDesignProperties.InnerText)
                                    If iLineType = 2 Then iNewLineType = Items.cIItemLine.LineTypeEnum.Splines
                                    If iLineType = 1 Then iNewLineType = Items.cIItemLine.LineTypeEnum.Beziers
                                    If iLineType <> iNewLineType Then
                                        oDesignProperties.InnerText = modNumbers.NumberToString(iNewLineType)
                                    End If
                                End If

                                Dim iIndex As Integer = 0
                                Dim iCount As Integer = 0

                                Dim oPlanLayers As XmlElement
                                If Not oXml.Item("csurvey").Item("plan") Is Nothing Then
                                    oPlanLayers = oXml.Item("csurvey").Item("plan").Item("layers")
                                    For Each oLayer As XmlElement In oPlanLayers.ChildNodes
                                        iCount += oLayer.Item("items").ChildNodes.Count
                                    Next
                                End If
                                Dim oProfileLayers As XmlElement
                                If Not oXml.Item("csurvey").Item("profile") Is Nothing Then
                                    oProfileLayers = oXml.Item("csurvey").Item("profile").Item("layers")
                                    For Each oLayer As XmlElement In oProfileLayers.ChildNodes
                                        iCount += oLayer.Item("items").ChildNodes.Count
                                    Next
                                End If

                                If Not oPlanLayers Is Nothing Then
                                    For Each oLayer As XmlElement In oPlanLayers.ChildNodes
                                        For Each oitem As XmlElement In oLayer.Item("items").ChildNodes
                                            If iIndex Mod 20 = 0 Then Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("csurvey.textpart12"), iIndex / iCount)
                                            If oitem.HasAttribute("linetype") Then
                                                iLineType = modXML.GetAttributeValue(oitem, "linetype", Items.cIItemLine.LineTypeEnum.Lines)
                                                If iLineType = 2 Then iNewLineType = Items.cIItemLine.LineTypeEnum.Splines
                                                If iLineType = 1 Then iNewLineType = Items.cIItemLine.LineTypeEnum.Beziers
                                                If iLineType <> iNewLineType Then
                                                    Call oitem.SetAttribute("linetype", iNewLineType.ToString("D"))
                                                End If
                                            End If
                                            If oitem.HasAttribute("binddesigntype") Then
                                                Dim iBindDesignType As cItem.BindDesignTypeEnum = modXML.GetAttributeValue(oitem, "binddesigntype", cItem.BindDesignTypeEnum.MainDesign)
                                                If iBindDesignType = 1 Then
                                                    Call oitem.SetAttribute("binddesigntype", cItem.BindDesignTypeEnum.MainDesign)
                                                End If
                                                If iBindDesignType = 2 Then
                                                    Call oitem.SetAttribute("binddesigntype", cItem.BindDesignTypeEnum.CrossSections)
                                                End If
                                            End If
                                            iIndex += 1
                                        Next
                                    Next
                                End If

                                If Not oProfileLayers Is Nothing Then
                                    For Each oLayer As XmlElement In oProfileLayers.ChildNodes
                                        For Each oitem As XmlElement In oLayer.Item("items").ChildNodes
                                            If iIndex Mod 20 = 0 Then Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("csurvey.textpart12"), iIndex / iCount)
                                            If oitem.HasAttribute("linetype") Then
                                                iLineType = modXML.GetAttributeValue(oitem, "linetype", Items.cIItemLine.LineTypeEnum.Lines)
                                                If iLineType = 2 Then iNewLineType = Items.cIItemLine.LineTypeEnum.Splines
                                                If iLineType = 1 Then iNewLineType = Items.cIItemLine.LineTypeEnum.Beziers
                                                If iLineType <> iNewLineType Then
                                                    Call oitem.SetAttribute("linetype", iNewLineType.ToString("D"))
                                                End If
                                            End If
                                            If oitem.HasAttribute("binddesigntype") Then
                                                Dim iBindDesignType As cItem.BindDesignTypeEnum = modXML.GetAttributeValue(oitem, "binddesigntype", cItem.BindDesignTypeEnum.MainDesign)
                                                If iBindDesignType = 2 Then
                                                    Call oitem.SetAttribute("binddesigntype", cItem.BindDesignTypeEnum.CrossSections)
                                                End If
                                            End If
                                            iIndex += 1
                                        Next
                                    Next
                                End If

                                sCurrentVersion = "1.04"
                            End If
                        Case "1.04"
                            Dim oArgs As cFileConversionEventArgs = New cFileConversionEventArgs(sCurrentVersion, Version)
                            If Not bRequested Then
                                RaiseEvent OnFileConversionRequest(Me, oArgs)
                            End If
                            If oArgs.Cancel Then
                                bCancel = True
                            Else
                                bRequested = True
                                'this is a proforma version...to stabilize file format...
                                sCurrentVersion = "1.05"
                            End If
                        Case "1.05"
                            Dim oArgs As cFileConversionEventArgs = New cFileConversionEventArgs(sCurrentVersion, Version)
                            If Not bRequested Then
                                RaiseEvent OnFileConversionRequest(Me, oArgs)
                            End If
                            If oArgs.Cancel Then
                                bCancel = True
                            Else
                                bRequested = True
                                'the file structure is basically the same but in 1.06 crosssection could be designed in plan and in profile (not only in profile as in the previous versions)
                                sCurrentVersion = "1.06"
                            End If
                        Case "1.06"
                            Dim oArgs As cFileConversionEventArgs = New cFileConversionEventArgs(sCurrentVersion, Version)
                            If Not bRequested Then
                                RaiseEvent OnFileConversionRequest(Me, oArgs)
                            End If
                            If oArgs.Cancel Then
                                bCancel = True
                            Else
                                bRequested = True
                                'the file structure is basically the same but in 1.07 there are supports for attachments
                                sCurrentVersion = "1.07"
                            End If
                        Case "1.07"
                            Dim oArgs As cFileConversionEventArgs = New cFileConversionEventArgs(sCurrentVersion, Version)
                            If Not bRequested Then
                                RaiseEvent OnFileConversionRequest(Me, oArgs)
                            End If
                            If oArgs.Cancel Then
                                bCancel = True
                            Else
                                bRequested = True
                                Call oXml.Item("csurvey").Item("properties").SetAttribute("slpeo", "1")
                                sCurrentVersion = "1.08"
                            End If
                        Case "1.08"
                            Dim oArgs As cFileConversionEventArgs = New cFileConversionEventArgs(sCurrentVersion, Version)
                            If Not bRequested Then
                                RaiseEvent OnFileConversionRequest(Me, oArgs)
                            End If
                            If oArgs.Cancel Then
                                bCancel = True
                            Else
                                bRequested = True
                                'the file structure is basically the same but in 1.08 there are supports for extendstart in cave/branch...
                                sCurrentVersion = "1.09"
                            End If
                        Case "1.09"
                            Dim oArgs As cFileConversionEventArgs = New cFileConversionEventArgs(sCurrentVersion, Version)
                            If Not bRequested Then
                                RaiseEvent OnFileConversionRequest(Me, oArgs)
                            End If
                            If oArgs.Cancel Then
                                bCancel = True
                            Else
                                bRequested = True
                                'the file structure is basically the same but in 1.09 there are supports for items visibility for profiles...
                                sCurrentVersion = "1.10"
                            End If
                        Case "1.10"
                            Dim oArgs As cFileConversionEventArgs = New cFileConversionEventArgs(sCurrentVersion, Version)
                            If Not bRequested Then
                                RaiseEvent OnFileConversionRequest(Me, oArgs)
                            End If
                            If oArgs.Cancel Then
                                bCancel = True
                            Else
                                bRequested = True
                                'the file structure is basically the same but in 1.10 there are supports for profile direction vertical
                                sCurrentVersion = "1.11"
                            End If
                        Case "1.11"
                            Dim oArgs As cFileConversionEventArgs = New cFileConversionEventArgs(sCurrentVersion, Version)
                            If Not bRequested Then
                                RaiseEvent OnFileConversionRequest(Me, oArgs)
                            End If
                            If oArgs.Cancel Then
                                bCancel = True
                            Else
                                bRequested = True
                                'the file structure is basically the same but in 1.11 there are supports for common/shared texts...
                                sCurrentVersion = "1.12"
                            End If
                        Case "1.12"
                            Dim oArgs As cFileConversionEventArgs = New cFileConversionEventArgs(sCurrentVersion, Version)
                            If Not bRequested Then
                                RaiseEvent OnFileConversionRequest(Me, oArgs)
                            End If
                            If oArgs.Cancel Then
                                bCancel = True
                            Else
                                bRequested = True
                                'the file structure is basically the same but in 1.11 there are supports for new pens...
                                sCurrentVersion = "1.13"
                            End If
                        Case "1.13"
                            Dim oArgs As cFileConversionEventArgs = New cFileConversionEventArgs(sCurrentVersion, Version)
                            If Not bRequested Then
                                RaiseEvent OnFileConversionRequest(Me, oArgs)
                            End If
                            If oArgs.Cancel Then
                                bCancel = True
                            Else
                                bRequested = True
                                'the file structure is basically the same but in 1.11 there are supports for new pens and brushes options...
                                sCurrentVersion = "1.14"
                            End If
                        Case Else
                            bOk = False
                            bCancel = False
                            Exit Do
                    End Select
                Loop Until bOk Or bCancel

                If bOk Then
                    Dim oXmlRoot As XmlElement = oXml.Item("csurvey")

                    sID = oXmlRoot.GetAttribute("id")
                    If sID = "" Then
                        sID = Guid.NewGuid.ToString
                    End If

                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("csurvey.textpart103"), 0)
                    Try
                        If modXML.ChildElementExist(oXmlRoot, "grades") Then
                            oGrades = New cGrades(Me, oXmlRoot.Item("grades"))
                        Else
                            oGrades = New cGrades(Me)
                        End If
                    Catch
                        oGrades = New cGrades(Me)
                    End Try

                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("csurvey.textpart104"), 0)
                    Try
                        If modXML.ChildElementExist(oXmlRoot, "properties") Then
                            oProperties = New cProperties(Me, oXmlRoot.Item("properties"))
                        Else
                            oProperties = New cProperties(Me)
                        End If
                    Catch
                        oProperties = New cProperties(Me)
                    End Try

                    Try
                        If modXML.ChildElementExist(oXmlRoot, "txts") Then
                            oTexts = New cTexts(Me, oXmlRoot.Item("txts"))
                        Else
                            oTexts = New cTexts(Me)
                        End If
                    Catch
                        oTexts = New cTexts(Me)
                    End Try

                    'Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("csurvey.textpart110"), 0)
                    Try
                        If ChildElementExist(oXmlRoot, "attachments") Then
                            oAttachments = New cAttachments(Me, oFile, oXmlRoot.Item("attachments"))
                        Else
                            oAttachments = New cAttachments(Me)
                        End If
                    Catch
                        oAttachments = New cAttachments(Me)
                    End Try

                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("csurvey.textpart105"), 0)
                    oSegments = New cSegments(Me, oFile, oXmlRoot.Item("segments"))

                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("csurvey.textpart106"), 0)
                    If modXML.ChildElementExist(oXmlRoot, "trigpoints") Then
                        oTrigPoints = New cTrigPoints(Me, oXmlRoot.Item("trigpoints"))
                    Else
                        oTrigPoints = New cTrigPoints(Me)
                    End If

                    oEditPaintObjects = New cEditPaintObjects(Me)

                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("csurvey.textpart107"), 0)
                    Try
                        If modXML.ChildElementExist(oXmlRoot, "options") Then
                            oOptions = New cOptionsCollection(Me, oXmlRoot.Item("options"))
                        Else
                            oOptions = New cOptionsCollection(Me)
                        End If
                    Catch
                        oOptions = New cOptionsCollection(Me)
                    End Try

                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("csurvey.textpart108"), 0)
                    Try
                        If modXML.ChildElementExist(oXmlRoot, "crosssections") Then
                            oCrossSections = New cDesignCrossSections(Me, oFile, oXmlRoot.Item("crosssections"))
                        Else
                            oCrossSections = New cDesignCrossSections(Me)
                        End If
                    Catch
                        oCrossSections = New cDesignCrossSections(Me)
                    End Try

                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("csurvey.textpart109"), 0)
                    Try
                        If modXML.ChildElementExist(oXmlRoot, "sketches") Then
                            oSketches = New cDesignSketches(Me, oXmlRoot.Item("sketches"))
                        Else
                            oSketches = New cDesignSketches(Me)
                        End If
                    Catch
                        oSketches = New cDesignSketches(Me)
                    End Try

                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("csurvey.textpart110"), 0)
                    Try
                        If ChildElementExist(oXmlRoot, "cliparts") Then
                            oCliparts = New cCliparts(Me, oFile, oXmlRoot.Item("cliparts"))
                        Else
                            oCliparts = New cCliparts(Me)
                        End If
                    Catch
                        oCliparts = New cCliparts(Me)
                    End Try

                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("csurvey.textpart111"), 0)
                    Try
                        If ChildElementExist(oXmlRoot, "signs") Then
                            oSigns = New cSigns(Me, oFile, oXmlRoot.Item("signs"))
                        Else
                            oSigns = New cSigns(Me)
                        End If
                    Catch
                        oSigns = New cSigns(Me)
                    End Try

                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("csurvey.textpart124"), 0)
                    Try
                        If ChildElementExist(oXmlRoot, "pens") Then
                            oPens = New cPens(Me, oFile, oXmlRoot.Item("pens"))
                        Else
                            oPens = New cPens(Me)
                        End If
                    Catch
                        oPens = New cPens(Me)
                    End Try

                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("csurvey.textpart125"), 0)
                    Try
                        If ChildElementExist(oXmlRoot, "brushes") Then
                            oBrushes = New cBrushes(Me, oFile, oXmlRoot.Item("brushes"))
                        Else
                            oBrushes = New cBrushes(Me)
                        End If
                    Catch
                        oBrushes = New cBrushes(Me)
                    End Try

                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("csurvey.textpart112"), 0)
                    Call RaiseOnProgressEvent("load.design.plan", OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("csurvey.textpart113"), 0, OnProgressEventArgs.ProgressOptionsEnum.ImagePaint)
                    If ChildElementExist(oXmlRoot, "plan") Then
                        oPlan = New cDesignPlan(Me, oFile, oXmlRoot.Item("plan"))
                    Else
                        oPlan = New cDesignPlan(Me)
                    End If
                    'If (pGetFileCreatID(oXml) = "topodroid" OrElse (LoadOptions And LoadOptionsEnum.FixTopoDroid) = LoadOptionsEnum.FixTopoDroid) Then
                    '    Call modImport.FixTopodroidDesign(Me, oPlan, oXmlRoot.Item("plan"))
                    'End If
                    Call RaiseOnProgressEvent("load.design.plan", OnProgressEventArgs.ProgressActionEnum.End, "", 0)

                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("csurvey.textpart112"), 0.5)
                    Call RaiseOnProgressEvent("load.design.profile", OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("csurvey.textpart114"), 0, OnProgressEventArgs.ProgressOptionsEnum.ImagePaint)
                    If ChildElementExist(oXmlRoot, "profile") Then
                        oProfile = New cDesignProfile(Me, oFile, oXmlRoot.Item("profile"))
                    Else
                        oProfile = New cDesignProfile(Me)
                    End If
                    'If (pGetFileCreatID(oXml) = "topodroid" OrElse (LoadOptions And LoadOptionsEnum.FixTopoDroid) = LoadOptionsEnum.FixTopoDroid) Then
                    '    Call modImport.FixTopodroidDesign(Me, oProfile, oXmlRoot.Item("profile"))
                    'End If
                    Call RaiseOnProgressEvent("load.design.profile", OnProgressEventArgs.ProgressActionEnum.End, "", 0)

                    Call RaiseOnProgressEvent("load.design.crosssection", OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("csurvey.textpart115"), 0)
                    Call oCrossSections.RebindCrossSections()
                    Call oCrossSections.Rebind(True)
                    Call RaiseOnProgressEvent("load.design.crosssection", OnProgressEventArgs.ProgressActionEnum.End, GetLocalizedString("csurvey.textpart115a"), 0)

                    Call RaiseOnProgressEvent("load.design.sketches", OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("csurvey.textpart116"), 0)
                    Call oSketches.RebindSketches()
                    Call oSketches.Rebind(True)
                    Call RaiseOnProgressEvent("load.design.sketches", OnProgressEventArgs.ProgressActionEnum.End, GetLocalizedString("csurvey.textpart116a"), 0)

                    Try
                        If modXML.ChildElementExist(oXmlRoot, "scalerules") Then
                            oScaleRules = New cScaleRules(Me, oXmlRoot.Item("scalerules"))
                        Else
                            oScaleRules = New cScaleRules(Me)
                        End If
                    Catch
                        oScaleRules = New cScaleRules(Me)
                    End Try

                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("csurvey.textpart117"), 0)
                    Call RaiseOnProgressEvent("load.profile.preview", OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("csurvey.textpart118"), 0)
                    Try
                        If modXML.ChildElementExist(oXmlRoot, "previewprofiles") Then
                            oPreviewProfiles = New cPreviewProfiles(Me, oFile, oXmlRoot.Item("previewprofiles"))
                        Else
                            oPreviewProfiles = New cPreviewProfiles(Me)
                        End If
                    Catch
                        oPreviewProfiles = New cPreviewProfiles(Me)
                    End Try
                    Call RaiseOnProgressEvent("load.profile.preview", OnProgressEventArgs.ProgressActionEnum.End, GetLocalizedString("csurvey.textpart118a"), 0)

                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("csurvey.textpart117"), 0.33)
                    Call RaiseOnProgressEvent("load.profile.export", OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("csurvey.textpart119"), 0)
                    Try
                        If modXML.ChildElementExist(oXmlRoot, "exportprofiles") Then
                            oExportProfiles = New cExportProfiles(Me, oFile, oXmlRoot.Item("exportprofiles"))
                        Else
                            oExportProfiles = New cExportProfiles(Me)
                        End If
                    Catch
                        oExportProfiles = New cExportProfiles(Me)
                    End Try
                    Call RaiseOnProgressEvent("load.profile.export", OnProgressEventArgs.ProgressActionEnum.End, GetLocalizedString("csurvey.textpart119a"), 0)

                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("csurvey.textpart117"), 0.66)
                    Call RaiseOnProgressEvent("load.profile.view", OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("csurvey.textpart120"), 0)
                    Try
                        If modXML.ChildElementExist(oXmlRoot, "viewerprofiles") Then
                            oViewerProfiles = New cViewerProfiles(Me, oFile, oXmlRoot.Item("viewerprofiles"))
                        Else
                            oViewerProfiles = New cViewerProfiles(Me)
                        End If
                    Catch
                        oViewerProfiles = New cViewerProfiles(Me)
                    End Try
                    Call RaiseOnProgressEvent("load.profile.view", OnProgressEventArgs.ProgressActionEnum.End, GetLocalizedString("csurvey.textpart120a"), 0)

                    'If (LoadOptions And LoadOptionsEnum.IsLinkedSurvey) = LoadOptionsEnum.None Then
                    Try
                        If modXML.ChildElementExist(oXmlRoot, "linkedsurveys") Then
                            oLinkedSurveys = New cLinkedSurveys(Me, oFile, oXmlRoot.Item("linkedsurveys"))
                        Else
                            oLinkedSurveys = New cLinkedSurveys(Me)
                        End If
                    Catch ex As Exception
                        oLinkedSurveys = New cLinkedSurveys(Me)
                    End Try
                    'End If

                    Try
                        If modXML.ChildElementExist(oXmlRoot, "sharedsettings") Then
                            oSharedSettings = New cSharedSettings(Me, oXmlRoot.Item("sharedsettings"))
                        Else
                            oSharedSettings = New cSharedSettings(Me)
                        End If
                    Catch
                        oSharedSettings = New cSharedSettings(Me)
                    End Try

                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("csurvey.textpart121"), 0)
                    Try
                        If modXML.ChildElementExist(oXmlRoot, "surface") Then
                            oSurface = New cSurface(Me, oFile, oXmlRoot.Item("surface"))
                        Else
                            oSurface = New cSurface(Me)
                        End If
                    Catch
                        oSurface = New cSurface(Me)
                    End Try
                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("csurvey.textpart121a"), 0)

                    If (LoadOptions And LoadOptionsEnum.IsLinkedSurvey) = LoadOptionsEnum.None Then
                        Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("csurvey.textpart122"), 0)
                        Try
                            If modXML.ChildElementExist(oXmlRoot, "masterslave") Then
                                oMasterSlave = New Master.cMasterSlave(Me, oFile, oXmlRoot.Item("masterslave"))
                            Else
                                oMasterSlave = New Master.cMasterSlave(Me)
                            End If
                        Catch
                            oMasterSlave = New Master.cMasterSlave(Me)
                        End Try
                        Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("csurvey.textpart122a"), 0)
                    End If

                    'If (LoadOptions And LoadOptionsEnum.IsLinkedSurvey) = LoadOptionsEnum.None Then
                    '    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("csurvey.textpart122"), 0)
                    '    Try
                    '        If modXML.ChildElementExist(oXmlRoot, "caveregister") Then
                    '            oCaveRegister = New cCaveRegister(Me, oFile, oXmlRoot.Item("caveregister"))
                    '        Else
                    '            oCaveRegister = New cCaveRegister(Me)
                    '        End If
                    '    Catch
                    '        oCaveRegister = New cCaveRegister(Me)
                    '    End Try
                    '    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("csurvey.textpart122a"), 0)
                    'End If

                    Dim bDoCalculate As Boolean
                    If modXML.ChildElementExist(oXmlRoot, "calculate") Then
                        oCalc = New cCalculate(Me, oXmlRoot.Item("calculate"))
                        bDoCalculate = False
                    Else
                        oCalc = New cCalculate(Me)
                        bDoCalculate = True
                    End If

                    If oProperties.Origin = "" Then
                        Call oProperties.AutoSetOrigin()
                    End If

                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.End, "", 0)

                    If bDoCalculate Then
                        Call Invalidate()
                        Call oCalc.Calculate(False)
                        Call oCalc.ResetChanges()
                    Else
                        iInvalidated = cCalculate.InvalidateEnum.None
                    End If

                    'Call oUndo.Clear()

                    'oTool = New cEditBaseTools(Me)

                    If modOpeningFlags.OFUpgradeCalculateVersion Then
                        Call oProperties.UpgradeCalculateVersion()
                    End If
                    If modOpeningFlags.OFUpgradeInversionMode Then
                        Call oProperties.UpgradeInversionMode()
                    End If

                    If ((pGetFileCreatID(oXml) = "topodroid" AndAlso Not pGetFileCreatPostProcessed(oXml)) OrElse (LoadOptions And LoadOptionsEnum.FixTopoDroid) = LoadOptionsEnum.FixTopoDroid) OrElse modOpeningFlags.OFRegenerateSegmentsID Then
                        Call modImport.FixTopodroidDesign(Me, oPlan, oXmlRoot.Item("plan"))
                        Call modImport.FixTopodroidDesign(Me, oProfile, oXmlRoot.Item("profile"))
                        Call modImport.FixTopodroidSurvey(Me, oXmlRoot)
                    End If

                    Return New cActionResult(True, "", "")
                Else
                    Call RaiseOnProgressEvent("load", OnProgressEventArgs.ProgressActionEnum.End, "", 0)

                    If bCancel Then
                        Return New cActionResult(False, "survey.load", modMain.GetLocalizedString("csurvey.textpart2"))
                    Else
                        Return New cActionResult(False, "survey.load", modMain.GetLocalizedString("csurvey.textpart3"))
                    End If
                End If
            End Using
        End Function

        Friend Function GetSegment(ByVal ID As String) As cISegment
            If oSegments.Contains(ID) Then
                Return oSegments(ID)
            Else
                If oCrossSections.Contains(ID) Then
                    Return oCrossSections(ID)
                Else
                    Return Nothing
                End If
            End If
        End Function

        'Friend ReadOnly Property Tool() As cEditBaseTools
        '    Get
        '        Return oTool
        '    End Get
        'End Property

        Public ReadOnly Property Segments() As cSegments
            Get
                Return oSegments
            End Get
        End Property

        Public ReadOnly Property TrigPoints() As cTrigPoints
            Get
                Return oTrigPoints
            End Get
        End Property

        Public ReadOnly Property Grades As cGrades
            Get
                Return oGrades
            End Get
        End Property

        Public ReadOnly Property [Properties]() As cProperties
            Get
                Return oProperties
            End Get
        End Property

        Public ReadOnly Property Plan() As cDesignPlan
            Get
                Return oPlan
            End Get
        End Property

        Public ReadOnly Property Profile() As cDesignProfile
            Get
                Return oProfile
            End Get
        End Property

        Public ReadOnly Property CrossSections() As cDesignCrossSections
            Get
                Return oCrossSections
            End Get
        End Property

        Public ReadOnly Property Signs As cSigns
            Get
                Return oSigns
            End Get
        End Property

        Public ReadOnly Property Brushes As cBrushes
            Get
                Return oBrushes
            End Get
        End Property

        Public ReadOnly Property Pens As cPens
            Get
                Return oPens
            End Get
        End Property

        Public ReadOnly Property Attachments As cAttachments
            Get
                Return oAttachments
            End Get
        End Property

        Public ReadOnly Property Cliparts As cCliparts
            Get
                Return oCliparts
            End Get
        End Property

        Public ReadOnly Property Sketches() As cDesignSketches
            Get
                Return oSketches
            End Get
        End Property

        Public ReadOnly Property PreviewProfiles As cPreviewProfiles
            Get
                Return oPreviewProfiles
            End Get
        End Property

        Public ReadOnly Property ExportProfiles As cExportProfiles
            Get
                Return oExportProfiles
            End Get
        End Property

        Public ReadOnly Property ViewerProfiles As cViewerProfiles
            Get
                Return oViewerProfiles
            End Get
        End Property

        Public ReadOnly Property LinkedSurveys As cLinkedSurveys
            Get
                Return oLinkedSurveys
            End Get
        End Property

        Friend Function GetAllDesignItems(LayerType As cLayers.LayerTypeEnum, ItemType As Items.cIItem.cItemTypeEnum) As List(Of cItem)
            Dim oAllItems As List(Of cItem) = New List(Of cItem)
            Call oAllItems.AddRange(oPlan.Layers(LayerType).GetAllItems(ItemType))
            Call oAllItems.AddRange(oProfile.Layers(LayerType).GetAllItems(ItemType))
            Return oAllItems
        End Function

        Friend Function GetAllDesignItems(ItemType As Items.cIItem.cItemTypeEnum) As List(Of cItem)
            Dim oAllItems As List(Of cItem) = New List(Of cItem)
            Call oAllItems.AddRange(oPlan.GetAllItems(ItemType))
            Call oAllItems.AddRange(oProfile.GetAllItems(ItemType))
            Return oAllItems
        End Function

        Friend Function GetAllDesignItems() As List(Of cItem)
            Dim oAllItems As List(Of cItem) = New List(Of cItem)
            Call oAllItems.AddRange(oPlan.GetAllItems)
            Call oAllItems.AddRange(oProfile.GetAllItems)
            Return oAllItems
        End Function

        Public ReadOnly Property Options() As cOptionsCollection
            Get
                Return oOptions
            End Get
        End Property

        Public Property Name() As String
            Get
                Return oProperties.Name
            End Get
            Set(ByVal value As String)
                oProperties.Name = value
            End Set
        End Property

        Private Function pGetFileCreatPostProcessed(ByVal XML As XmlDocument) As Boolean
            Try
                Return modXML.GetAttributeValue(XML.Item("csurvey").Item("properties"), "creat_postprocessed", 0)
            Catch
                Return True
            End Try
        End Function

        Private Function pGetFileCreatID(ByVal XML As XmlDocument) As String
            Try
                Return XML.Item("csurvey").Item("properties").GetAttribute("creatid").ToString.ToLower
            Catch
                Return ""
            End Try
        End Function

        Private Function pGetFileVersion(ByVal XML As XmlDocument) As String
            Try
                Return XML.Item("csurvey").GetAttribute("version")
            Catch
                Return "1.00"
            End Try
        End Function

        'Private Function pGetFileVersion(ByVal Filename As String) As String
        '    Try
        '        Dim oXML As XmlDocument = New XmlDocument
        '        Call oXML.Load(Filename)
        '        Return pGetFileVersion(oXML)
        '    Catch
        '        Return "1.00"
        '    End Try
        'End Function

        Private Sub pSaveTo(ByVal File As cFile, ByVal Document As XmlDocument, Options As SaveOptionsEnum)
            Dim sTextPart1 As String = modMain.GetLocalizedString("csurvey.textpart1")

            Dim bSilent As Boolean = (Options And cSurvey.SaveOptionsEnum.Silent) = 0
            If Not bSilent Then Call RaiseOnProgressEvent("save", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, sTextPart1, 0)
            Dim oXmlRoot As XmlElement = Document.CreateElement("csurvey")
            Call oXmlRoot.SetAttribute("version", Version)
            Call oXmlRoot.SetAttribute("id", sID)

            If oGrades.Count <> 0 Then Call oGrades.SaveTo(File, Document, oXmlRoot)
            Call oProperties.SaveTo(File, Document, oXmlRoot)
            If oTexts.Count <> 0 Then Call oTexts.SaveTo(File, Document, oXmlRoot)

            If Not bSilent Then Call RaiseOnProgressEvent("save.attachments", OnProgressEventArgs.ProgressActionEnum.Begin, sTextPart1, 0, OnProgressEventArgs.ProgressOptionsEnum.ImagePaint)
            Call oAttachments.SaveTo(File, Document, oXmlRoot, Options)
            If Not bSilent Then Call RaiseOnProgressEvent("save.attachments", OnProgressEventArgs.ProgressActionEnum.End, "", 0)

            If Not bSilent Then Call RaiseOnProgressEvent("save.segments", OnProgressEventArgs.ProgressActionEnum.Begin, sTextPart1, 0, OnProgressEventArgs.ProgressOptionsEnum.ImagePaint)
            Call oSegments.SaveTo(File, Document, oXmlRoot, Options)
            If Not bSilent Then Call RaiseOnProgressEvent("save.segments", OnProgressEventArgs.ProgressActionEnum.End, "", 0)

            If Not bSilent Then Call RaiseOnProgressEvent("save.trigpoints", OnProgressEventArgs.ProgressActionEnum.Begin, sTextPart1, 1, OnProgressEventArgs.ProgressOptionsEnum.ImagePaint)
            Call oTrigPoints.SaveTo(File, Document, oXmlRoot, Options)
            If Not bSilent Then Call RaiseOnProgressEvent("save.trigpoints", OnProgressEventArgs.ProgressActionEnum.End, "", 0)

            Call oOptions.SaveTo(File, Document, oXmlRoot)

            If Not bSilent Then Call RaiseOnProgressEvent("save.cliparts", OnProgressEventArgs.ProgressActionEnum.Begin, sTextPart1, 0, OnProgressEventArgs.ProgressOptionsEnum.ImagePaint)
            Call oCliparts.SaveTo(File, Document, oXmlRoot, Options)
            If Not bSilent Then Call RaiseOnProgressEvent("save.cliparts", OnProgressEventArgs.ProgressActionEnum.End, "", 0)

            If Not bSilent Then Call RaiseOnProgressEvent("save.signs", OnProgressEventArgs.ProgressActionEnum.Begin, sTextPart1, 1, OnProgressEventArgs.ProgressOptionsEnum.ImagePaint)
            Call oSigns.SaveTo(File, Document, oXmlRoot, Options)
            If Not bSilent Then Call RaiseOnProgressEvent("save.signs", OnProgressEventArgs.ProgressActionEnum.End, "", 0)

            If Not bSilent Then Call RaiseOnProgressEvent("save.pens", OnProgressEventArgs.ProgressActionEnum.Begin, sTextPart1, 1, OnProgressEventArgs.ProgressOptionsEnum.ImagePaint)
            Call oPens.SaveTo(File, Document, oXmlRoot, Options)
            If Not bSilent Then Call RaiseOnProgressEvent("save.pens", OnProgressEventArgs.ProgressActionEnum.End, "", 0)

            If Not bSilent Then Call RaiseOnProgressEvent("save.brushes", OnProgressEventArgs.ProgressActionEnum.Begin, sTextPart1, 1, OnProgressEventArgs.ProgressOptionsEnum.ImagePaint)
            Call oBrushes.SaveTo(File, Document, oXmlRoot, Options)
            If Not bSilent Then Call RaiseOnProgressEvent("save.brushes", OnProgressEventArgs.ProgressActionEnum.End, "", 0)

            If Not bSilent Then Call RaiseOnProgressEvent("save.design.plan", OnProgressEventArgs.ProgressActionEnum.Begin, sTextPart1, 0, OnProgressEventArgs.ProgressOptionsEnum.ImagePaint)
            Call oPlan.SaveTo(File, Document, oXmlRoot, Options)
            If Not bSilent Then Call RaiseOnProgressEvent("save.design.plan", OnProgressEventArgs.ProgressActionEnum.End, "", 0)

            If Not bSilent Then Call RaiseOnProgressEvent("save.design.profile", OnProgressEventArgs.ProgressActionEnum.Begin, sTextPart1, 1, OnProgressEventArgs.ProgressOptionsEnum.ImagePaint)
            Call oProfile.SaveTo(File, Document, oXmlRoot, Options)
            If Not bSilent Then Call RaiseOnProgressEvent("save.design.profile", OnProgressEventArgs.ProgressActionEnum.End, "", 0)

            If oCrossSections.Count <> 0 Then
                Call oCrossSections.Rebind(True)
                Call oCrossSections.SaveTo(File, Document, oXmlRoot)
            End If

            If oSketches.Count <> 0 Then
                Call oSketches.Rebind(True)
                Call oSketches.SaveTo(File, Document, oXmlRoot)
            End If

            If oScaleRules.Count <> 0 Then Call oScaleRules.SaveTo(File, Document, oXmlRoot)
            If oPreviewProfiles.Count <> 0 Then Call oPreviewProfiles.SaveTo(File, Document, oXmlRoot)
            If oExportProfiles.Count <> 0 Then Call oExportProfiles.SaveTo(File, Document, oXmlRoot)

            Call oLinkedSurveys.SaveTo(File, Document, oXmlRoot, Options)

            If oSharedSettings.Count <> 0 Then Call oSharedSettings.SaveTo(File, Document, oXmlRoot)

            Call oSurface.SaveTo(File, Document, oXmlRoot)

            'Call oCaveRegister.SaveTo(File, Document, oXmlRoot)

            Call oMasterSlave.SaveTo(File, Document, oXmlRoot)

            Call oCalc.SaveTo(File, Document, oXmlRoot)

            Call Document.AppendChild(oXmlRoot)

            If Not bSilent Then Call RaiseOnProgressEvent("save", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)
        End Sub

        Public Sub SaveTo(ByVal File As cFile, Optional Options As SaveOptionsEnum = SaveOptionsEnum.None)
            Call pSaveTo(File, File.Document, Options)
        End Sub

        Public Sub SaveTo(ByVal Stream As System.IO.Stream, Optional Options As SaveOptionsEnum = SaveOptionsEnum.None)
            Using oFile As cFile = New cFile(cFile.FileFormatEnum.CSZ)
                Call pSaveTo(oFile, oFile.Document, Options)
                Call oFile.SaveTo(Stream)
            End Using
        End Sub

        Public Sub SaveTo(ByVal Filename As String, Optional Options As SaveOptionsEnum = SaveOptionsEnum.None)
            Dim iFileFormat As cFile.FileFormatEnum = cFile.FileFormatEnum.CSZ
            If IO.Path.GetExtension(Filename).ToLower = ".csx" Then iFileFormat = cFile.FileFormatEnum.CSX
            Using oFile As cFile = New cFile(iFileFormat, Filename)
                Call pSaveTo(oFile, oFile.Document, Options)
                Call oFile.Save()
            End Using
        End Sub

        Private Sub oSegments_OnSegmentAppend(ByVal Sender As cSegments, ByVal Args As cSegments.OnSegmentEventArgs) Handles oSegments.OnSegmentAppend
            If Args.Segment.IsValid Then 'And Not Args.Segment.IsSelfDefined Then
                iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate
            End If
            RaiseEvent OnSegmentsChange(Me, New cSurvey.OnSegmentChangeEventArgs(SegmentsChangeActionEnum.Add, Args))
        End Sub

        Private Sub oSegments_OnSegmentClear(ByVal Sender As cSegments) Handles oSegments.OnClear
            iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate
            RaiseEvent OnSegmentsChange(Me, New cSurvey.OnSegmentChangeEventArgs(SegmentsChangeActionEnum.Clear))
        End Sub

        Private Sub oSegments_OnSegmentInsert(ByVal Sender As cSegments, ByVal Args As cSegments.OnSegmentEventArgs) Handles oSegments.OnSegmentInsert
            If Args.Segment.IsValid Then 'And Not Args.Segment.IsSelfDefined Then
                iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate
            End If
            RaiseEvent OnSegmentsChange(Me, New cSurvey.OnSegmentChangeEventArgs(SegmentsChangeActionEnum.Add, Args))
        End Sub

        Private Sub oSegments_OnSegmentRemoveRange(ByVal Sender As cSegments, ByVal Args As cSegments.OnSegmentsEventArgs) Handles oSegments.OnSegmentRemoveRange
            iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate
            RaiseEvent OnSegmentsChange(Me, New cSurvey.OnSegmentChangeEventArgs(SegmentsChangeActionEnum.RemoveRange, Args))
        End Sub

        Private Sub oSegments_OnSegmentRemove(ByVal Sender As cSegments, ByVal Args As cSegments.OnSegmentEventArgs) Handles oSegments.OnSegmentRemove
            If Args.Segment.IsValid Then
                iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate
            End If
            RaiseEvent OnSegmentsChange(Me, New cSurvey.OnSegmentChangeEventArgs(SegmentsChangeActionEnum.Remove, Args))
        End Sub

        Private Sub oSegments_OnSegmentBeforeAppend(Sender As cSegments, Args As cSegments.OnSegmentEventArgs) Handles oSegments.OnSegmentBeforeAppend
            RaiseEvent OnSegmentsChange(Me, New cSurvey.OnSegmentChangeEventArgs(SegmentsChangeActionEnum.BeforeAdd, Args))
        End Sub

        Private Sub oSegments_OnSegmentChange(ByVal Sender As cSegments, ByVal Args As cSegments.OnSegmentEventArgs) Handles oSegments.OnSegmentChange
            If Args.Segment.IsValid Then
                iInvalidated = iInvalidated Or Args.Segment.Invalidated
            End If
            RaiseEvent OnSegmentsChange(Me, New cSurvey.OnSegmentChangeEventArgs(SegmentsChangeActionEnum.Change, Args))
        End Sub

        Private Sub oTrigpoints_OnTrigPointChange(ByVal Sender As cTrigPoints, ByVal Args As cTrigPoints.OnTrigpointEventArgs) Handles oTrigPoints.OnTrigPointChange
            iInvalidated = iInvalidated Or Args.Trigpoint.Invalidated
            RaiseEvent OnTrigpointsChange(Me, New cSurvey.OnTrigpointChangeEventArgs(TrigpointsChangeActionEnum.Change, Args))
        End Sub

        Private Sub oTrigPoints_OnTrigPointRebind(ByVal Sender As cTrigPoints, ByVal Args As cTrigPoints.OnTrigpointEventArgs) Handles oTrigPoints.OnTrigPointRebind
            RaiseEvent OnTrigpointsChange(Me, New cSurvey.OnTrigpointChangeEventArgs(TrigpointsChangeActionEnum.Rebind, Args))
        End Sub

        Private Sub oSegments_OnSegmentLoad(ByVal Sender As cSegments, ByVal Args As cSegments.OnSegmentLoadEventArgs) Handles oSegments.OnSegmentLoad
            RaiseEvent OnProgress(Me, New OnProgressEventArgs(OnProgressEventArgs.ProgressActionEnum.Progress, Args.Text, Args.Progress, OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage))
        End Sub

        Public Sub Invalidate()
            iInvalidated = cCalculate.InvalidateEnum.FullCalculate
        End Sub

        Friend Sub Invalidate(Invalidated As cCalculate.InvalidateEnum)
            iInvalidated = Invalidated
        End Sub

        Public ReadOnly Property Invalidated As cCalculate.InvalidateEnum
            Get
                Return iInvalidated
            End Get
        End Property

        Public ReadOnly Property Calculate As cSurveyPC.cSurvey.Calculate.cCalculate
            Get
                Return oCalc
            End Get
        End Property

        Private Sub oCalc_OnArrangePriorityComplete(Sender As cCalculate, Args As EventArgs) Handles oCalc.OnArrangePriorityComplete
            RaiseEvent OnArrangePriority(Me, New OnArrangePriorityEventArgs)
        End Sub

        Private Sub oCalc_OnCalculateComplete(ByVal Sender As Calculate.cCalculate, Args As EventArgs) Handles oCalc.OnCalculateComplete
            iInvalidated = cCalculate.InvalidateEnum.None
            Call oPlan.Plot.Caches.Invalidate()
            Call oProfile.Plot.Caches.Invalidate()
            RaiseEvent OnCalculate(Me, New OnCalculateEventArgs)
        End Sub

        Private Sub oSurface_OnSurfaceChange(Sender As cSurface, Args As cSurface.OnSurfaceEventArgs) Handles oSurface.OnSurfaceChange
            iInvalidated = cCalculate.InvalidateEnum.FullCalculate
            RaiseEvent OnSurfaceChanged(Me, New OnSurfaceChangedEventArgs(Args.Source))
        End Sub

        Private Sub oPlanCleanUpFoundUndefinedCavesEvent(Sender As cDesign, EventArgs As cDesign.OnCleanUpUndefinedCaveEventArgs) Handles oPlan.OnCleanUpFoundUndefinedCavesEvent
            Dim oArgs As OnCleanUpFoundUndefinedCavesEventArgs = New OnCleanUpFoundUndefinedCavesEventArgs(Sender, EventArgs.ListOfUndefinedCaves)
            RaiseEvent OnCleanUpFoundUndefinedCavesEvent(Me, oArgs)
            EventArgs.Cancel = oArgs.Cancel
        End Sub

        Private Sub oProfile_OnCleanUpFoundUndefinedCavesEvent(Sender As cDesign, EventArgs As cDesign.OnCleanUpUndefinedCaveEventArgs) Handles oProfile.OnCleanUpFoundUndefinedCavesEvent
            Dim oArgs As OnCleanUpFoundUndefinedCavesEventArgs = New OnCleanUpFoundUndefinedCavesEventArgs(Sender, EventArgs.ListOfUndefinedCaves)
            RaiseEvent OnCleanUpFoundUndefinedCavesEvent(Me, oArgs)
            EventArgs.Cancel = oArgs.Cancel
        End Sub

        Private Sub oSegments_OnSegmentSplayChange(Sender As cSegments, Args As cSegments.OnSegmentEventArgs) Handles oSegments.OnSegmentSplayChange
            If Args.Segment.IsValid Then
                iInvalidated = iInvalidated Or Args.Segment.Invalidated
            End If
            RaiseEvent OnSegmentsChange(Me, New cSurvey.OnSegmentChangeEventArgs(SegmentsChangeActionEnum.Splay, Args))
        End Sub

        Private Sub oCrossSections_OnCrossSectionAdd(Sender As Object, Args As cDesignCrossSections.OnDesignCrossSectionEventArgs) Handles oCrossSections.OnCrossSectionAdd
            RaiseEvent OnCrossSectionsChange(Me, New cSurvey.OnCrossSectionChangeEventArgs(CrossSectionsChangeActionEnum.Add, Args))
        End Sub

        Private Sub oCrossSections_OnCrossSectionRemove(Sender As Object, Args As cDesignCrossSections.OnDesignCrossSectionEventArgs) Handles oCrossSections.OnCrossSectionRemove
            RaiseEvent OnCrossSectionsChange(Me, New cSurvey.OnCrossSectionChangeEventArgs(CrossSectionsChangeActionEnum.Remove, Args))
        End Sub

        Private Sub oSegments_OnSegmentReassigned(Sender As cSegments, e As cSegments.OnSegmentEventArgs) Handles oSegments.OnSegmentReassigned
            If e.Segment.IsValid Then
                iInvalidated = iInvalidated Or e.Segment.Invalidated
            End If
            RaiseEvent OnSegmentsChange(Me, New cSurvey.OnSegmentChangeEventArgs(SegmentsChangeActionEnum.Reassigned, e))
        End Sub

        Private Sub oSegments_OnSegmentChangeRange(Sender As cSegments, e As cSegments.OnSegmentsEventArgs) Handles oSegments.OnSegmentChangeRange
            RaiseEvent OnSegmentsChange(Me, New cSurvey.OnSegmentChangeEventArgs(SegmentsChangeActionEnum.ChangeRange, e))
        End Sub
    End Class
End Namespace