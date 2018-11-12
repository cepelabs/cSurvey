Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Scale
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Design.Options

Imports System.Xml
Imports System.Collections.ObjectModel

Imports DotNetCaveModel
Imports DotNetCaveModel.RenderMode
Imports DotNetCaveModel.ColoringMode

Namespace cSurvey.Design
    Public Interface cIOptions
        Enum ModeEnum
            Design = 0
            Preview = 1
            Viewer = 2
        End Enum

        ReadOnly Property Name() As String
        ReadOnly Property DefaultOptions As cOptions
        ReadOnly Property Mode() As ModeEnum
        Function IsViewer() As Boolean
        Function IsPreview() As Boolean
        Function IsDesign() As Boolean
        ReadOnly Property Survey As cSurvey
        Function GetParent() As cIProfile
        Function GetOption() As cIOptions
    End Interface

    Public Interface cIOptionLinkedSurveys
        Inherits cIOptions
        Property DrawLinkedSurveys As Boolean
    End Interface

    Public Interface cIOptionPrintAndExportArea
        Inherits cIOptions
        Function GetPrintOrExportProfile(CurrentDesign As cIDesign) As cIProfile
        Sub SetPrintOrExportProfile(Value As cIProfile)
        Property DrawPrintOrExportArea As Boolean
    End Interface

    Public Class cOptions
        Implements cIOptions
        Implements cITextStructure

        <Flags()> Public Enum DrawSegmentsOptionsEnum
            None = &H0
            Surface = &H1
            Duplicate = &H2
        End Enum

        Public Enum ShowSplayModeEnum
            OnlyInRange = 0
            All = 1
        End Enum

        Private WithEvents oSurvey As cSurvey

        Private sName As String

        Private bDrawPlot As Boolean
        Private bDrawSegments As Boolean
        Private iDrawSegmentsOptions As DrawSegmentsOptionsEnum
        Private bDrawPoints As Boolean
        Private bDrawPointNames As Boolean
        Private bDrawLRUD As Boolean
        Private bDrawSplay As Boolean
        Private iShowSplayMode As ShowSplayModeEnum
        Private bDrawRings As Boolean

        Private bDrawSurfaceProfile As Boolean

        Private bDrawDesign As Boolean
        Private bDrawSpecialPoints As Boolean

        Private bShowPointInformation As Boolean
        Private bShowPointText As Boolean
        Private bShowSplayText As Boolean

        Private bShowSegmentBindings As Boolean

        Private bShowAdvancedBrushes As Boolean

        Private bShowSurface As Boolean
        Private bShowElevation As Boolean

        Private oSurfaceOptions As cSurfaceOptions

        Private oTranslationsOptions As cTranslationsOptions
        Private bDrawTranslation As Boolean

        Private oHLsOptions As cHighlightsOptions
        Private bDrawHLs As Boolean

        Private sCurrentCaveVisibilityProfile As String

        Private oDrawingObjects As cOptionsDrawingObjects
        Private oPaintObjects As cPaintObjects

        Public Overridable Function GetOption() As cIOptions Implements cIOptions.GetOption
            Return Me
        End Function

        Public ReadOnly Property SurfaceOptions As cSurfaceOptions
            Get
                Return oSurfaceOptions
            End Get
        End Property

        Public Enum CombineColorModeEnum
            CavesAndBranches = 0
            OnlyCaves = 1
        End Enum

        Public Enum CenterlineColorModeEnum
            CavesAndBranches = 0
            OnlyCaves = 1
        End Enum

        Private iCenterlineColorMode As CenterlineColorModeEnum
        Private bCenterlineColorGray As Boolean

        Public Overridable Property CenterlineColorMode As CenterlineColorModeEnum
            Get
                Return iCenterlineColorMode
            End Get
            Set(value As CenterlineColorModeEnum)
                iCenterlineColorMode = value
            End Set
        End Property

        Public Overridable Property CenterlineColorGray As Boolean
            Get
                Return bCenterlineColorGray
            End Get
            Set(value As Boolean)
                If bCenterlineColorGray <> value Then
                    bCenterlineColorGray = value
                    Call Rebind()
                End If
            End Set
        End Property

        Friend Sub Rebind()
            Call oDrawingObjects.Rebind()
        End Sub

        Private iCombineColorMode As CombineColorModeEnum
        Private bCombineColorGray As Boolean

        Public Overridable Property CombineColorMode As CombineColorModeEnum
            Get
                Return iCombineColorMode
            End Get
            Set(value As CombineColorModeEnum)
                iCombineColorMode = value
            End Set
        End Property

        Public Overridable Property CombineColorGray As Boolean
            Get
                Return bCombineColorGray
            End Get
            Set(value As Boolean)
                bCombineColorGray = value
            End Set
        End Property

        Private iMode As cIOptions.ModeEnum

        Public Enum HighlightModeEnum
            [Default] = 0
            Hierarchic = 1
            ExactMatch = 2
        End Enum

        Public Enum AlignmentEnum
            TopLeft = 0
            TopRight = 1
            BottomLeft = 2
            BottomRight = 3
        End Enum

        Public Enum CompassStyleEnum
            Simple = 0
            Advanced = 1
        End Enum

        Public Enum ScaleStyleEnum
            Simple = 0
            Advanced = 1
        End Enum

        Public Enum UnselectedCaveDrawStyleEnum
            [Default] = 1
            Wireframe = 2
            Areas = 3
        End Enum

        Private oDefaultOptions As cOptions

        Private bDrawCompass As Boolean
        Private iCompassPosition As AlignmentEnum
        Private iCompassStyle As CompassStyleEnum

        Private bDrawScale As Boolean
        Private iScaleStyle As ScaleStyleEnum
        Private iScalePosition As AlignmentEnum

        Private bDrawBox As Boolean
        Private iBoxPosition As AlignmentEnum

        Private bDrawImages As Boolean
        Private bDrawSketches As Boolean

        Private bHighlightCurrentCave As Boolean
        Private iHighlightMode As HighlightModeEnum
        Private iUnselectedCaveDrawStyle As UnselectedCaveDrawStyleEnum
        Private bHighlightSegmentsAndTrigpoints As Boolean

        Private oCompassOptions As cCompassOptions
        Private oInfoboxOptions As cInfoBoxOptions
        Private oScaleOptions As cScaleOptions

        Private bUseDrawingZOrder As Boolean
        Public Enum zordermodeenum
            Free = 0
            Hierarchic = 1
        End Enum
        Private iZOrderMode As zordermodeenum

        Public Overridable Property ZOrderMode As zordermodeenum
            Get
                Return iZOrderMode
            End Get
            Set(value As zordermodeenum)
                iZOrderMode = value
            End Set
        End Property

        Public Overridable Property UseDrawingZOrder As Boolean
            Get
                Return bUseDrawingZOrder
            End Get
            Set(value As Boolean)
                bUseDrawingZOrder = value
            End Set
        End Property

        Public Enum DesignStyleEnum
            Design = &H0
            Areas = &H1
            Combined = &H2
        End Enum

        Public Enum DrawStyleEnum
            Solid = &H0
            Transparent = &H1
            Light = &H2
            OnlySegment = &H3
        End Enum

        'Public Enum ColorStyleEnum
        '    BN = 0
        '    Color = 1
        'End Enum

        Public Enum SplayStyleEnum
            Points = 0
            PointsAndRays = 1
            Rays = 2
        End Enum

        Private iSplayStyle As SplayStyleEnum
        Private iDesignStyle As DesignStyleEnum
        Private iDrawStyle As DrawStyleEnum 'da cambiare appena possibile...nome pessimo
        'Private iColorStyle As ColorStyleEnum

        Private iCurrentScale As Integer
        Private oCurrentRule As cIScaleRule

        '--------------------------------------------------------------------------------------------
        Private sPenHeavyWidth As Single
        Private sPenMediumWidth As Single
        Private sPenLightWidth As Single
        Private sPenUltralightWidth As Single
        Private sPenTightWidth As Single
        Private oDefaultTextFont As cIFont
        '--------------------------------------------------------------------------------------------

        Private sInfoBoxStructure As String
        Private sTrigpointStructure As String
        Private sSpecialTrigpointStructure As String
        '--------------------------------------------------------------------------------------------

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

        Public Function GetFormattedTrigpointText(Trigpoint As cTrigPoint) As String Implements cITextStructure.GetFormattedTrigpointText
            Return modPaint.GetFormattedTrigpointText(oSurvey, Me, Trigpoint)
        End Function

        Public Function GetFormattedSpecialTrigpointText(Trigpoint As cTrigPoint) As String Implements cITextStructure.GetFormattedSpecialTrigpointText
            Return modPaint.GetFormattedSpecialTrigpointText(oSurvey, Me, Trigpoint)
        End Function

        Public Function GetFormattedInfoBoxText() As String Implements cITextStructure.GetFormattedInfoBoxText
            Return modPaint.GetFormattedInfoBoxText(oSurvey, Me)
        End Function

        Public Overridable Property ShowAdvancedBrushes As Boolean
            Get
                Return bShowAdvancedBrushes
            End Get
            Set(value As Boolean)
                bShowAdvancedBrushes = value
            End Set
        End Property

        Public ReadOnly Property Survey As cSurvey Implements cIOptions.Survey
            Get
                Return oSurvey
            End Get
        End Property

        Public ReadOnly Property HighlightsOptions As cHighlightsOptions
            Get
                Return oHLsOptions
            End Get
        End Property

        Public ReadOnly Property TranslationsOptions As cTranslationsOptions
            Get
                Return oTranslationsOptions
            End Get
        End Property

        Public Overridable Property DrawHighlights() As Boolean
            Get
                Return bDrawHLs
            End Get
            Set(ByVal value As Boolean)
                bDrawHLs = value
            End Set
        End Property

        Public Overridable Property DrawTranslation() As Boolean
            Get
                Return bDrawTranslation
            End Get
            Set(ByVal value As Boolean)
                bDrawTranslation = value
            End Set
        End Property

        Public ReadOnly Property Name() As String Implements cIOptions.Name
            Get
                Return sName
            End Get
        End Property

        Public ReadOnly Property DefaultOptions As cOptions Implements cIOptions.DefaultOptions
            Get
                Return oDefaultOptions
            End Get
        End Property

        Public ReadOnly Property Mode() As cIOptions.ModeEnum Implements cIOptions.Mode
            Get
                Return iMode
            End Get
        End Property

        Public Overridable Function IsViewer() As Boolean Implements cIOptions.IsViewer
            Return iMode = cIOptions.ModeEnum.Viewer
        End Function

        Public Overridable Function IsPreview() As Boolean Implements cIOptions.IsPreview
            Return iMode = cIOptions.ModeEnum.Preview
        End Function

        Public Overridable Function IsDesign() As Boolean Implements cIOptions.IsDesign
            Return iMode = cIOptions.ModeEnum.Design
        End Function

        Public Property DrawBox() As Boolean
            Get
                Return bDrawBox
            End Get
            Set(ByVal value As Boolean)
                bDrawBox = value
            End Set
        End Property

        Public Property BoxPosition() As AlignmentEnum
            Get
                Return iBoxPosition
            End Get
            Set(ByVal value As AlignmentEnum)
                iBoxPosition = value
            End Set
        End Property

        Public Property HighlightSegmentsAndTrigpoints() As Boolean
            Get
                Return bHighlightSegmentsAndTrigpoints
            End Get
            Set(ByVal value As Boolean)
                bHighlightSegmentsAndTrigpoints = value
            End Set
        End Property

        Public Property HighlightCurrentCave() As Boolean
            Get
                Return bHighlightCurrentCave
            End Get
            Set(ByVal value As Boolean)
                bHighlightCurrentCave = value
            End Set
        End Property

        Public Property HighlightMode() As HighlightModeEnum
            Get
                Return iHighlightMode
            End Get
            Set(ByVal value As HighlightModeEnum)
                iHighlightMode = value
            End Set
        End Property

        Public Property UnselectedCaveDrawStyle As UnselectedCaveDrawStyleEnum
            Get
                Return iUnselectedCaveDrawStyle
            End Get
            Set(ByVal value As UnselectedCaveDrawStyleEnum)
                iUnselectedCaveDrawStyle = value
            End Set
        End Property

        Public Property DrawScale() As Boolean
            Get
                Return bDrawScale
            End Get
            Set(ByVal value As Boolean)
                bDrawScale = value
            End Set
        End Property

        Public Property ScaleStyle() As ScaleStyleEnum
            Get
                Return iScaleStyle
            End Get
            Set(ByVal value As ScaleStyleEnum)
                iScaleStyle = value
            End Set
        End Property

        Public Property ShowSegmentBindings As Boolean
            Get
                Return bShowSegmentBindings
            End Get
            Set(ByVal value As Boolean)
                bShowSegmentBindings = value
            End Set
        End Property

        Public Property ScalePosition() As AlignmentEnum
            Get
                Return iScalePosition
            End Get
            Set(ByVal value As AlignmentEnum)
                iScalePosition = value
            End Set
        End Property

        Public Property DrawCompass() As Boolean
            Get
                Return bDrawCompass
            End Get
            Set(ByVal value As Boolean)
                bDrawCompass = value
            End Set
        End Property

        Public Property CompassPosition() As AlignmentEnum
            Get
                Return iCompassPosition
            End Get
            Set(ByVal value As AlignmentEnum)
                iCompassPosition = value
            End Set
        End Property

        Public Property CompassStyle() As CompassStyleEnum
            Get
                Return iCompassStyle
            End Get
            Set(ByVal value As CompassStyleEnum)
                iCompassStyle = value
            End Set
        End Property

        Public Property DrawStyle() As DrawStyleEnum
            Get
                Return iDrawStyle
            End Get
            Set(ByVal value As DrawStyleEnum)
                iDrawStyle = value
            End Set
        End Property

        Public Property DesignStyle() As DesignStyleEnum
            Get
                Return iDesignStyle
            End Get
            Set(ByVal value As DesignStyleEnum)
                iDesignStyle = value
            End Set
        End Property

        Public Property SplayStyle() As SplayStyleEnum
            Get
                Return iSplayStyle
            End Get
            Set(ByVal value As SplayStyleEnum)
                iSplayStyle = value
            End Set
        End Property

        'Public Property ColorStyle() As ColorStyleEnum
        '    Get
        '        Return iColorStyle
        '    End Get
        '    Set(ByVal value As ColorStyleEnum)
        '        iColorStyle = value
        '    End Set
        'End Property

        'Public Overridable Property DrawRings() As Boolean
        '    Get
        '        Return bDrawRings
        '    End Get
        '    Set(ByVal value As Boolean)
        '        bDrawRings = value
        '    End Set
        'End Property

        Public Overridable Property DrawSplay() As Boolean
            Get
                Return bDrawSplay
            End Get
            Set(ByVal value As Boolean)
                bDrawSplay = value
            End Set
        End Property

        Public Overridable Property DrawLRUD() As Boolean
            Get
                Return bDrawLRUD
            End Get
            Set(ByVal value As Boolean)
                bDrawLRUD = value
            End Set
        End Property

        Public Overridable Property DrawPointNames() As Boolean
            Get
                Return bDrawPointNames
            End Get
            Set(ByVal value As Boolean)
                bDrawPointNames = value
            End Set
        End Property

        Public Overridable Property DrawPoints() As Boolean
            Get
                Return bDrawPoints
            End Get
            Set(ByVal value As Boolean)
                bDrawPoints = value
            End Set
        End Property

        Public Overridable Property DrawSurfaceProfile() As Boolean
            Get
                Return bDrawSurfaceProfile
            End Get
            Set(ByVal value As Boolean)
                bDrawSurfaceProfile = value
            End Set
        End Property

        Public Overridable Property DrawDesign() As Boolean
            Get
                Return bDrawDesign
            End Get
            Set(ByVal value As Boolean)
                bDrawDesign = value
            End Set
        End Property

        Public Overridable Property DrawSpecialPoints() As Boolean
            Get
                Return bDrawSpecialPoints
            End Get
            Set(ByVal value As Boolean)
                bDrawSpecialPoints = value
            End Set
        End Property

        Public Overridable Property DrawSketches() As Boolean
            Get
                Return bDrawSketches
            End Get
            Set(ByVal value As Boolean)
                bDrawSketches = value
            End Set
        End Property

        Public Overridable Property DrawImages() As Boolean
            Get
                Return bDrawImages
            End Get
            Set(ByVal value As Boolean)
                bDrawImages = value
            End Set
        End Property

        Public Overridable Property DrawPlot() As Boolean
            Get
                Return bDrawPlot
            End Get
            Set(ByVal value As Boolean)
                bDrawPlot = value
            End Set
        End Property

        Public Overridable Property DrawSegments() As Boolean
            Get
                Return bDrawSegments
            End Get
            Set(ByVal value As Boolean)
                bDrawSegments = value
            End Set
        End Property

        Public Overridable Property DrawSegmentsOptions() As DrawSegmentsOptionsEnum
            Get
                Return iDrawSegmentsOptions
            End Get
            Set(ByVal value As DrawSegmentsOptionsEnum)
                iDrawSegmentsOptions = value
            End Set
        End Property

        'Public Overridable Property LowerLayersDesignTransparencyThreshold() As Integer
        '    Get
        '        Return iLowerLayersDesignTransparencyThreshold
        '    End Get
        '    Set(ByVal value As Integer)
        '        iLowerLayersDesignTransparencyThreshold = value
        '    End Set
        'End Property

        Public ReadOnly Property CompassOptions As cCompassOptions
            Get
                Return oCompassOptions
            End Get
        End Property

        Public ReadOnly Property InfoBoxOptions As cInfoBoxOptions
            Get
                Return oInfoboxOptions
            End Get
        End Property

        Public ReadOnly Property ScaleOptions As cScaleOptions
            Get
                Return oScaleOptions
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Name As String, ByVal Mode As cIOptions.ModeEnum)
            oSurvey = Survey

            sName = Name
            iMode = Mode

            bDrawPlot = True
            bDrawDesign = True

            iSplayStyle = SplayStyleEnum.Points
            iDesignStyle = DesignStyleEnum.Design
            iDrawStyle = DrawStyleEnum.Transparent
            'iColorStyle = ColorStyleEnum.Color

            bDrawLRUD = True
            bDrawSplay = True
            bDrawRings = False
            bDrawSegments = True
            iDrawSegmentsOptions = DrawSegmentsOptionsEnum.None
            iShowSplayMode = ShowSplayModeEnum.OnlyInRange

            bDrawPointNames = True
            bDrawPoints = True
            bDrawSpecialPoints = False

            bDrawScale = True
            iScaleStyle = ScaleStyleEnum.Simple
            iScalePosition = AlignmentEnum.BottomRight

            bDrawBox = False
            iBoxPosition = AlignmentEnum.TopRight

            bDrawCompass = True
            iCompassStyle = CompassStyleEnum.Simple
            iCompassPosition = AlignmentEnum.BottomLeft

            bDrawImages = False
            bDrawSketches = False

            bHighlightCurrentCave = False
            iHighlightMode = HighlightModeEnum.Default
            iUnselectedCaveDrawStyle = UnselectedCaveDrawStyleEnum.Areas
            bHighlightSegmentsAndTrigpoints = True

            'LowerLayersDesignTransparencyThreshold = 120

            bShowPointInformation = False
            bShowPointText = True
            bShowSplayText = False

            bShowAdvancedBrushes = True

            bShowSurface = False
            bShowElevation = False

            iCombineColorMode = CombineColorModeEnum.CavesAndBranches
            bCombineColorGray = False

            iCenterlineColorMode = CenterlineColorModeEnum.CavesAndBranches
            bCenterlineColorGray = False

            sCurrentCaveVisibilityProfile = ""

            oCompassOptions = New cCompassOptions(oSurvey)
            oInfoboxOptions = New cInfoBoxOptions(oSurvey)
            oScaleOptions = New cScaleOptions(oSurvey)

            bDrawTranslation = True
            oTranslationsOptions = New cTranslationsOptions(oSurvey)

            bDrawHLs = False
            oHLsOptions = New cHighlightsOptions(oSurvey)

            oDrawingObjects = New cOptionsDrawingObjects(oSurvey, Me)
            oPaintObjects = New cPaintObjects(oSurvey)

            If sName <> "" Then
                oDefaultOptions = New cOptions(oSurvey, "", iMode)
            End If

            iCurrentScale = iDefaultDesignScale
            oCurrentRule = oSurvey.ScaleRules.FindRule(iCurrentScale)

            bUseDrawingZOrder = False

            Dim oDesignProperties As cPropertiesCollection = oCurrentRule.DesignProperties
            sPenHeavyWidth = oDesignProperties.GetValue("BaseHeavyLinesScaleFactor", 8)
            sPenMediumWidth = oDesignProperties.GetValue("BaseMediumLinesScaleFactor", 3)
            sPenLightWidth = oDesignProperties.GetValue("BaseLightLinesScaleFactor", 1)
            sPenUltralightWidth = oDesignProperties.GetValue("BaseUltraLightLinesScaleFactor", 0.3)
            oDefaultTextFont = oSurvey.Properties.DesignProperties.GetValue("DesignTextFont", New cFont(oSurvey, "Tahoma", 8, Color.Black))

            bDrawSurfaceProfile = True

            oSurfaceOptions = New cSurfaceOptions(oSurvey)
        End Sub

        Friend ReadOnly Property PaintObjects As cPaintObjects
            Get
                Return oPaintObjects
            End Get
        End Property

        Friend ReadOnly Property DrawingObjects As cOptionsDrawingObjects
            Get
                Return oDrawingObjects
            End Get
        End Property

        Public Overridable Property ShowPointInformation() As Boolean
            Get
                Return bShowPointInformation
            End Get
            Set(ByVal value As Boolean)
                bShowPointInformation = value
            End Set
        End Property

        Public Overridable Property ShowSplayMode() As ShowSplayModeEnum
            Get
                Return iShowSplayMode
            End Get
            Set(ByVal value As ShowSplayModeEnum)
                iShowSplayMode = value
            End Set
        End Property

        Public Overridable Property ShowSplayText() As Boolean
            Get
                Return bShowSplayText
            End Get
            Set(ByVal value As Boolean)
                bShowSplayText = value
            End Set
        End Property

        Public Overridable Property ShowPointText() As Boolean
            Get
                Return bShowPointText
            End Get
            Set(ByVal value As Boolean)
                bShowPointText = value
            End Set
        End Property

        Public Overridable Sub Import(Options As XmlElement)
            bDrawPlot = modXML.GetAttributeValue(Options, "drawplot", True)
            bDrawDesign = modXML.GetAttributeValue(Options, "drawdesign", True)
            bDrawSpecialPoints = modXML.GetAttributeValue(Options, "drawspecialpoints", False)

            iSplayStyle = modXML.GetAttributeValue(Options, "splaystyle")
            iDesignStyle = modXML.GetAttributeValue(Options, "designstyle", DesignStyleEnum.Design)
            iDrawStyle = modXML.GetAttributeValue(Options, "drawstyle")
            'iColorStyle = modXML.GetAttributeValue(Options, "colorstyle")

            bDrawLRUD = modXML.GetAttributeValue(Options, "drawlrud", True)
            bDrawSplay = modXML.GetAttributeValue(Options, "drawsplay", True)
            bDrawRings = modXML.GetAttributeValue(Options, "drawrings", False)
            bDrawSegments = modXML.GetAttributeValue(Options, "drawsegments")
            iDrawSegmentsOptions = modXML.GetAttributeValue(Options, "drawsegmentsoptions", DrawSegmentsOptionsEnum.None)
            iShowSplayMode = modXML.GetAttributeValue(Options, "showsplaymode", ShowSplayModeEnum.OnlyInRange)

            bDrawPointNames = modXML.GetAttributeValue(Options, "drawpointnames", True)
            bDrawPoints = modXML.GetAttributeValue(Options, "drawpoints", True)

            bDrawScale = modXML.GetAttributeValue(Options, "drawscale")
            iScaleStyle = modXML.GetAttributeValue(Options, "scalestyle")
            iScalePosition = modXML.GetAttributeValue(Options, "scaleposition")

            bDrawBox = modXML.GetAttributeValue(Options, "drawbox")
            iBoxPosition = modXML.GetAttributeValue(Options, "boxposition")

            bDrawCompass = modXML.GetAttributeValue(Options, "drawcompass")
            iCompassStyle = modXML.GetAttributeValue(Options, "compassstyle")
            iCompassPosition = modXML.GetAttributeValue(Options, "compassposition")

            bDrawImages = modXML.GetAttributeValue(Options, "drawimages", False)
            bDrawSketches = modXML.GetAttributeValue(Options, "drawsketches", False)

            bHighlightCurrentCave = modXML.GetAttributeValue(Options, "highlightcurrentcave")
            iHighlightMode = modXML.GetAttributeValue(Options, "highlightmode", HighlightModeEnum.Default)
            iUnselectedCaveDrawStyle = modXML.GetAttributeValue(Options, "unselectedcavedrawstyle")
            bHighlightSegmentsAndTrigpoints = modXML.GetAttributeValue(Options, "highlightsegmentsandtrigpoints")

            bShowPointInformation = modXML.GetAttributeValue(Options, "showpointinformation")
            bShowPointText = modXML.GetAttributeValue(Options, "showpointtext", True)
            bShowSplayText = modXML.GetAttributeValue(Options, "showsplaytext", False)

            bShowAdvancedBrushes = modXML.GetAttributeValue(Options, "showadvancedbrushes", True)
            bShowSurface = modXML.GetAttributeValue(Options, "showsurface", False)
            bShowElevation = modXML.GetAttributeValue(Options, "showelevation", False)

            sCurrentCaveVisibilityProfile = modXML.GetAttributeValue(Options, "currentcavevisibilityprofile", "")

            bUseDrawingZOrder = modXML.GetAttributeValue(Options, "usedrawingzorder", 0)
            iZOrderMode = modXML.GetAttributeValue(Options, "zordermode", zordermodeenum.Free)

            Try
                oCompassOptions = New cCompassOptions(oSurvey, Options.Item("compassoptions"))
            Catch ex As Exception
                oCompassOptions = New cCompassOptions(oSurvey)
            End Try
            Try
                oInfoboxOptions = New cInfoBoxOptions(oSurvey, Options.Item("infoboxoptions"))
            Catch ex As Exception
                oInfoboxOptions = New cInfoBoxOptions(oSurvey)
            End Try
            Try
                oScaleOptions = New cScaleOptions(oSurvey, Options.Item("scaleoptions"))
            Catch ex As Exception
                oScaleOptions = New cScaleOptions(oSurvey)
            End Try

            bDrawTranslation = modXML.GetAttributeValue(Options, "drawtranslation", True)
            Try
                oTranslationsOptions = New cTranslationsOptions(oSurvey, Options.Item("translationsoptions"))
            Catch ex As Exception
                oTranslationsOptions = New cTranslationsOptions(oSurvey)
            End Try

            bDrawHLs = modXML.GetAttributeValue(Options, "drawhls", False)
            Try
                oHLsOptions = New cHighlightsOptions(oSurvey, Options.Item("hlsoptions"))
            Catch ex As Exception
                oHLsOptions = New cHighlightsOptions(oSurvey)
            End Try

            iCombineColorMode = modXML.GetAttributeValue(Options, "combinecolormode")
            bCombineColorGray = modXML.GetAttributeValue(Options, "combinecolorgray")

            iCenterlineColorMode = modXML.GetAttributeValue(Options, "centerlinecolormode")
            bCenterlineColorGray = modXML.GetAttributeValue(Options, "centerlinecolorgray")

            oDrawingObjects = New cOptionsDrawingObjects(oSurvey, Me)
            oPaintObjects = New cPaintObjects(oSurvey)

            If sName <> "" Then
                oDefaultOptions = New cOptions(oSurvey, "", iMode)
            End If

            iCurrentScale = iDefaultDesignScale
            oCurrentRule = oSurvey.ScaleRules.FindRule(iCurrentScale)

            Dim oDesignProperties As cPropertiesCollection = oCurrentRule.DesignProperties
            sPenHeavyWidth = oDesignProperties.GetValue("BaseHeavyLinesScaleFactor", 8)
            sPenMediumWidth = oDesignProperties.GetValue("BaseMediumLinesScaleFactor", 3)
            sPenLightWidth = oDesignProperties.GetValue("BaseLightLinesScaleFactor", 1)
            sPenUltralightWidth = oDesignProperties.GetValue("BaseUltraLightLinesScaleFactor", 0.3)
            oDefaultTextFont = oSurvey.Properties.DesignProperties.GetValue("DesignTextFont", New cFont(oSurvey, "Tahoma", 8, Color.Black))

            bDrawSurfaceProfile = modXML.GetAttributeValue(Options, "drawsurfaceprofile", True)

            Try
                oSurfaceOptions = New cSurfaceOptions(oSurvey, Options.Item("surfaceoptions"))
            Catch ex As Exception
                oSurfaceOptions = New cSurfaceOptions(oSurvey)
            End Try
        End Sub

        Friend Class GetParentEventArgs
            Inherits EventArgs

            Public Parent As cIProfile
        End Class

        Friend Event OnGetParent(Sender As Object, Args As GetParentEventArgs)

        Public Overridable Function GetParent() As cIProfile Implements cIOptions.GetParent
            Dim oArgs As GetParentEventArgs = New GetParentEventArgs
            RaiseEvent OnGetParent(Me, oArgs)
            Return oArgs.Parent
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Options As XmlElement, ByVal Mode As cIOptions.ModeEnum)
            oSurvey = Survey

            sName = Options.Name
            iMode = Mode

            Call Import(Options)

            'bDrawPlot = modXML.GetAttributeValue(Options, "drawplot", True)
            'bDrawDesign = modXML.GetAttributeValue(Options, "drawdesign", True)
            'bDrawSpecialPoints = modXML.GetAttributeValue(Options, "drawspecialpoints", False)

            'iSplayStyle = modXML.GetAttributeValue(Options, "splaystyle")
            'iDesignStyle = modXML.GetAttributeValue(Options, "designstyle", DesignStyleEnum.Design)
            'iDrawStyle = modXML.GetAttributeValue(Options, "drawstyle")
            ''iColorStyle = modXML.GetAttributeValue(Options, "colorstyle")

            'bDrawLRUD = modXML.GetAttributeValue(Options, "drawlrud", True)
            'bDrawSplay = modXML.GetAttributeValue(Options, "drawsplay", True)
            'bDrawRings = modXML.GetAttributeValue(Options, "drawrings", False)
            'bDrawSegments = modXML.GetAttributeValue(Options, "drawsegments")
            'iDrawSegmentsOptions = modXML.GetAttributeValue(Options, "drawsegmentsoptions", DrawSegmentsOptionsEnum.None)

            'bDrawPointNames = modXML.GetAttributeValue(Options, "drawpointnames", True)
            'bDrawPoints = modXML.GetAttributeValue(Options, "drawpoints", True)

            'bDrawScale = modXML.GetAttributeValue(Options, "drawscale")
            'iScaleStyle = modXML.GetAttributeValue(Options, "scalestyle")
            'iScalePosition = modXML.GetAttributeValue(Options, "scaleposition")

            'bDrawBox = modXML.GetAttributeValue(Options, "drawbox")
            'iBoxPosition = modXML.GetAttributeValue(Options, "boxposition")

            'bDrawCompass = modXML.GetAttributeValue(Options, "drawcompass")
            'iCompassStyle = modXML.GetAttributeValue(Options, "compassstyle")
            'iCompassPosition = modXML.GetAttributeValue(Options, "compassposition")

            'bDrawImages = modXML.GetAttributeValue(Options, "drawimages", False)
            'bDrawSketches = modXML.GetAttributeValue(Options, "drawsketches", False)

            'bHighlightCurrentCave = modXML.GetAttributeValue(Options, "highlightcurrentcave")
            'iHighlightMode = modXML.GetAttributeValue(Options, "highlightmode", HighlightModeEnum.Default)
            'iUnselectedCaveDrawStyle = modXML.GetAttributeValue(Options, "unselectedcavedrawstyle")
            'bHighlightSegmentsAndTrigpoints = modXML.GetAttributeValue(Options, "highlightsegmentsandtrigpoints")

            'bShowPointInformation = modXML.GetAttributeValue(Options, "showpointinformation")
            'bShowPointText = modXML.GetAttributeValue(Options, "showpointtext", True)
            'bShowSplayText = modXML.GetAttributeValue(Options, "showsplaytext", False)

            'bShowAdvancedBrushes = modXML.GetAttributeValue(Options, "showadvancedbrushes", True)
            'bShowSurface = modXML.GetAttributeValue(Options, "showsurface", False)
            'bShowElevation = modXML.GetAttributeValue(Options, "showelevation", False)

            'sCurrentCaveVisibilityProfile = modXML.GetAttributeValue(Options, "currentcavevisibilityprofile", "")

            'bUseDrawingZOrder = modXML.GetAttributeValue(Options, "usedrawingzorder", 0)
            'iZOrderMode = modXML.GetAttributeValue(Options, "zordermode", zordermodeenum.Free)

            'Try
            '    oCompassOptions = New cCompassOptions(oSurvey, Options.Item("compassoptions"))
            'Catch ex As Exception
            '    oCompassOptions = New cCompassOptions(oSurvey)
            'End Try
            'Try
            '    oInfoboxOptions = New cInfoBoxOptions(oSurvey, Options.Item("infoboxoptions"))
            'Catch ex As Exception
            '    oInfoboxOptions = New cInfoBoxOptions(oSurvey)
            'End Try
            'Try
            '    oScaleOptions = New cScaleOptions(oSurvey, Options.Item("scaleoptions"))
            'Catch ex As Exception
            '    oScaleOptions = New cScaleOptions(oSurvey)
            'End Try

            'bDrawTranslation = modXML.GetAttributeValue(Options, "drawtranslation", True)
            'Try
            '    oTranslationsOptions = New cTranslationsOptions(oSurvey, Options.Item("translationsoptions"))
            'Catch ex As Exception
            '    oTranslationsOptions = New cTranslationsOptions(oSurvey)
            'End Try

            'bDrawHLs = modXML.GetAttributeValue(Options, "drawhls", False)
            'Try
            '    oHLsOptions = New cHighlightsOptions(oSurvey, Options.Item("hlsoptions"))
            'Catch ex As Exception
            '    oHLsOptions = New cHighlightsOptions(oSurvey)
            'End Try

            'iCombineColorMode = modXML.GetAttributeValue(Options, "combinecolormode")
            'bCombineColorGray = modXML.GetAttributeValue(Options, "combinecolorgray")

            'iCenterlineColorMode = modXML.GetAttributeValue(Options, "centerlinecolormode")
            'bCenterlineColorGray = modXML.GetAttributeValue(Options, "centerlinecolorgray")

            'oDrawingObjects = New cOptionsDrawingObjects(oSurvey, Me)
            'oPaintObjects = New cPaintObjects(oSurvey)

            'If sName <> "" Then
            '    oDefaultOptions = New cOptions(oSurvey, "", iMode)
            'End If

            'iCurrentScale = iDefaultDesignScale
            'oCurrentRule = oSurvey.ScaleRules.FindRule(iCurrentScale)

            'Dim oDesignProperties As cPropertiesCollection = oCurrentRule.DesignProperties
            'sPenHeavyWidth = oDesignProperties.GetValue("BaseHeavyLinesScaleFactor", 8)
            'sPenMediumWidth = oDesignProperties.GetValue("BaseMediumLinesScaleFactor", 3)
            'sPenLightWidth = oDesignProperties.GetValue("BaseLightLinesScaleFactor", 1)
            'sPenUltralightWidth = oDesignProperties.GetValue("BaseUltraLightLinesScaleFactor", 0.3)
            'oDefaultTextFont = oSurvey.Properties.DesignProperties.GetValue("DesignTextFont", New cFont(oSurvey, "Tahoma", 8, Color.Black))

            'bDrawSurfaceProfile = modXML.GetAttributeValue(Options, "drawsurfaceprofile", True)

            'Try
            '    oSurfaceOptions = New cSurfaceOptions(oSurvey, Options.Item("surfaceoptions"))
            'Catch ex As Exception
            '    oSurfaceOptions = New cSurfaceOptions(oSurvey)
            'End Try
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlOptions As XmlElement = Document.CreateElement(sName)

            oXmlOptions.SetAttribute("drawplot", IIf(bDrawPlot, 1, 0))
            oXmlOptions.SetAttribute("drawdesign", IIf(bDrawDesign, 1, 0))
            oXmlOptions.SetAttribute("drawspecialpoints", IIf(bDrawSpecialPoints, 1, 0))

            oXmlOptions.SetAttribute("splaystyle", iSplayStyle.ToString("D"))
            oXmlOptions.SetAttribute("designstyle", iDesignStyle.ToString("D"))
            oXmlOptions.SetAttribute("drawstyle", iDrawStyle.ToString("D"))
            'oXmlOptions.SetAttribute("colorstyle", iColorStyle.ToString("D"))

            oXmlOptions.SetAttribute("drawlrud", IIf(bDrawLRUD, 1, 0))
            oXmlOptions.SetAttribute("drawsplay", IIf(bDrawSplay, 1, 0))
            oXmlOptions.SetAttribute("drawrings", IIf(bDrawRings, 1, 0))
            oXmlOptions.SetAttribute("drawsegments", IIf(bDrawSegments, 1, 0))
            oXmlOptions.SetAttribute("drawsegmentsoptions", iDrawSegmentsOptions.ToString("D"))
            oXmlOptions.SetAttribute("showsplaymode", iShowSplayMode.ToString("D"))

            oXmlOptions.SetAttribute("drawpointnames", IIf(bDrawPointNames, 1, 0))
            oXmlOptions.SetAttribute("drawpoints", IIf(bDrawPoints, 1, 0))

            oXmlOptions.SetAttribute("drawscale", IIf(bDrawScale, 1, 0))
            oXmlOptions.SetAttribute("scalestyle", iScaleStyle.ToString("D"))
            oXmlOptions.SetAttribute("scaleposition", iScalePosition.ToString("D"))

            oXmlOptions.SetAttribute("drawbox", IIf(bDrawBox, 1, 0))
            oXmlOptions.SetAttribute("boxposition", iBoxPosition.ToString("D"))

            oXmlOptions.SetAttribute("drawcompass", IIf(bDrawCompass, 1, 0))
            oXmlOptions.SetAttribute("compassstyle", iCompassStyle.ToString("D"))
            oXmlOptions.SetAttribute("compassposition", iCompassPosition.ToString("D"))

            oXmlOptions.SetAttribute("drawimages", IIf(bDrawImages, 1, 0))
            oXmlOptions.SetAttribute("drawsketches", IIf(bDrawSketches, 1, 0))

            oXmlOptions.SetAttribute("highlightcurrentcave", IIf(bHighlightCurrentCave, 1, 0))
            oXmlOptions.SetAttribute("highlightmode", iHighlightMode.ToString("D"))
            oXmlOptions.SetAttribute("unselectedcavedrawstyle", iUnselectedCaveDrawStyle.ToString("D"))
            oXmlOptions.SetAttribute("highlightsegmentsandtrigpoints", IIf(bHighlightSegmentsAndTrigpoints, 1, 0))

            oXmlOptions.SetAttribute("showpointinformation", IIf(bShowPointInformation, 1, 0))
            oXmlOptions.SetAttribute("showpointtext", IIf(bShowPointText, 1, 0))
            oXmlOptions.SetAttribute("showsplaytext", IIf(bShowSplayText, 1, 0))

            oXmlOptions.SetAttribute("showadvancedbrushes", IIf(bShowAdvancedBrushes, 1, 0))

            oXmlOptions.SetAttribute("showsurface", IIf(bShowSurface, 1, 0))
            oXmlOptions.SetAttribute("showelevation", IIf(bShowElevation, 1, 0))

            oXmlOptions.SetAttribute("currentcavevisibilityprofile", sCurrentCaveVisibilityProfile)

            If bUseDrawingZOrder Then
                Call oXmlOptions.SetAttribute("usedrawingzorder", "1")
                Call oXmlOptions.SetAttribute("zordermode", iZOrderMode.ToString("D"))
            End If

            Call oInfoboxOptions.SaveTo(File, Document, oXmlOptions)
            Call oCompassOptions.SaveTo(File, Document, oXmlOptions)
            Call oScaleOptions.SaveTo(File, Document, oXmlOptions)

            Call oXmlOptions.SetAttribute("drawtranslation", IIf(bDrawTranslation, 1, 0))
            Call oTranslationsOptions.SaveTo(File, Document, oXmlOptions)

            Call oXmlOptions.SetAttribute("drawhls", IIf(bDrawHLs, 1, 0))
            Call oHLsOptions.SaveTo(File, Document, oXmlOptions)

            Call oXmlOptions.SetAttribute("combinecolormode", iCombineColorMode.ToString("D"))
            Call oXmlOptions.SetAttribute("combinecolorgray", IIf(bCombineColorGray, 1, 0))

            Call oXmlOptions.SetAttribute("centerlinecolormode", iCenterlineColorMode.ToString("D"))
            Call oXmlOptions.SetAttribute("centerlinecolorgray", IIf(bCenterlineColorGray, 1, 0))

            Call oXmlOptions.SetAttribute("drawsurfaceprofile", IIf(bDrawSurfaceProfile, 1, 0))

            Call oSurfaceOptions.SaveTo(File, Document, oXmlOptions)

            Call Parent.AppendChild(oXmlOptions)
            Return oXmlOptions
        End Function

        Public Overridable Property CurrentCaveVisibilityProfile As String
            Get
                Return sCurrentCaveVisibilityProfile
            End Get
            Set(value As String)
                sCurrentCaveVisibilityProfile = value
            End Set
        End Property

        Public Function CurrentRule() As cIScaleRule
            If oCurrentRule Is Nothing Then
                oCurrentRule = oSurvey.ScaleRules.FindRule(iCurrentScale)
            End If
            Return oCurrentRule
        End Function

        Public Property CurrentScale As Integer
            Get
                Return iCurrentScale
            End Get
            Set(ByVal value As Integer)
                If (value >= 5 And value <= 50000) And (value <> iCurrentScale) Then
                    iCurrentScale = value
                    Dim oNewScaleRule As cIScaleRule = oSurvey.ScaleRules.FindRule(iCurrentScale)
                    If Not oCurrentRule Is oNewScaleRule Then
                        oCurrentRule = oNewScaleRule

                        Call Rebind()
                        Call oSurvey.Plan.Redraw(Me)
                        Call oSurvey.Profile.Redraw(Me)

                        Call oSurvey.RaiseOnPropertiesChanged(cSurvey.OnPropertiesChangedEventArgs.PropertiesChangeSourceEnum.Scale)
                    End If
                End If
            End Set
        End Property

        Friend Function GetFontDefaultSize(ByVal Type As cItemFont.FontTypeEnum) As Single
            Select Case Type
                Case cItemFont.FontTypeEnum.Note
                    Return oDefaultTextFont.FontSize - 1
                Case cItemFont.FontTypeEnum.TrigPoint
                    Return oDefaultTextFont.FontSize
                Case cItemFont.FontTypeEnum.CaveComplexName
                    Return oDefaultTextFont.FontSize + 3
                Case cItemFont.FontTypeEnum.CaveName
                    Return oDefaultTextFont.FontSize + 2
                Case cItemFont.FontTypeEnum.Title
                    Return oDefaultTextFont.FontSize + 1
                Case cItemFont.FontTypeEnum.Generic
                    Return oDefaultTextFont.FontSize
                Case cItemFont.FontTypeEnum.Custom
                    Return oDefaultTextFont.FontSize
            End Select
        End Function

        Friend Function GetPenDefaultWidth(ByVal Type As cPen.PenTypeEnum) As Single
            Select Case Type
                Case cPen.PenTypeEnum.None
                    Return 0
                Case cPen.PenTypeEnum.GenericPen, cPen.PenTypeEnum.PresumedGenericPen
                    Return sPenUltralightWidth
                Case cPen.PenTypeEnum.CavePen, cPen.PenTypeEnum.PresumedCavePen, cPen.PenTypeEnum.TooNarrowCavePen, cPen.PenTypeEnum.UnderlyingCavePen
                    Return sPenHeavyWidth
                Case cPen.PenTypeEnum.Pen, cPen.PenTypeEnum.PresumedPen
                    Return sPenMediumWidth
                Case cPen.PenTypeEnum.TightPen, cPen.PenTypeEnum.PresumedTightPen
                    Return sPenTightWidth
                Case cPen.PenTypeEnum.GradientUpPen, cPen.PenTypeEnum.PresumedGradientUpPen
                    Return sPenMediumWidth
                Case cPen.PenTypeEnum.GradientDownPen, cPen.PenTypeEnum.PresumedGradientDownPen
                    Return sPenMediumWidth
                Case cPen.PenTypeEnum.CliffUpPen, cPen.PenTypeEnum.PresumedCliffUpPen
                    Return sPenMediumWidth
                Case cPen.PenTypeEnum.CliffDownPen, cPen.PenTypeEnum.PresumedCliffDownPen
                    Return sPenMediumWidth
                Case cPen.PenTypeEnum.OverhangUpPen, cPen.PenTypeEnum.PresumedOverhangUpPen
                    Return sPenMediumWidth
                Case cPen.PenTypeEnum.OverhangDownPen, cPen.PenTypeEnum.PresumedOverhangDownPen
                    Return sPenMediumWidth
                Case cPen.PenTypeEnum.Custom
                    Return 0
            End Select
        End Function

        Private Sub oSurvey_OnPropertiesChanged(Sender As cSurvey, Args As cSurvey.OnPropertiesChangedEventArgs) Handles oSurvey.OnPropertiesChanged
            If Not oCurrentRule Is Nothing Then
                Dim oDesignProperties As cPropertiesCollection = oCurrentRule.DesignProperties
                sPenHeavyWidth = oDesignProperties.GetValue("BaseHeavyLinesScaleFactor", 8)
                sPenMediumWidth = oDesignProperties.GetValue("BaseMediumLinesScaleFactor", 3)
                sPenLightWidth = oDesignProperties.GetValue("BaseLightLinesScaleFactor", 1)
                sPenUltralightWidth = oDesignProperties.GetValue("BaseUltraLightLinesScaleFactor", 0.3)
                oDefaultTextFont = oDesignProperties.GetValue("DesignTextFont", New cFont(oSurvey, "Tahoma", 8, Color.Black))
            End If
        End Sub
    End Class
End Namespace