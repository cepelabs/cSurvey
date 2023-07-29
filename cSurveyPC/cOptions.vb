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
    Public Class PropertyChangeEventArgs
        Inherits EventArgs

        Private sName As String

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public Sub New(Name As String)
            sName = Name
        End Sub
    End Class

    Public Interface cIUIBaseInteractions
        Sub PropertyChanged(Name As String)
        Event OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs)
    End Interface

    Public Interface cIUIInteractions
        Inherits cIUIBaseInteractions
        Sub MapInvalidate()
        Event OnMapInvalidate(Sender As Object, e As EventArgs)
    End Interface
    Public Interface cIOptionLinkedSurveys
        Inherits cIOptions
        Property DrawLinkedSurveys As Boolean
    End Interface

    Public Interface cIOptionPrintAndExportArea
        Inherits cIOptions
        Enum DesignStyleEnum
            None = 0
            Schematics = 1
        End Enum
        Function GetPrintOrExportProfile(CurrentDesign As cIDesign) As cIProfile
        Sub SetPrintOrExportProfile(Value As cIProfile)
        Property DrawPrintOrExportArea As Boolean
        Property DrawPrintOrExportAreaDesignStyle As DesignStyleEnum
    End Interface

    Public Interface cIOptions
        Inherits cIUIInteractions

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

    Public Class cOptions
        Implements cIOptions

        Private WithEvents oSurvey As cSurvey

        Private sName As String

        Private oDefaultOptions As cOptions
        Private iMode As cIOptions.ModeEnum

        Friend Class GetParentEventArgs
            Inherits EventArgs

            Public Parent As cIProfile
        End Class

        Friend Event OnGetParent(sender As Object, e As GetParentEventArgs)

        Public Overridable Function GetParent() As cIProfile Implements cIOptions.GetParent
            Dim oArgs As GetParentEventArgs = New GetParentEventArgs
            RaiseEvent OnGetParent(Me, oArgs)
            Return oArgs.Parent
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Name As String, ByVal Mode As cIOptions.ModeEnum)
            oSurvey = Survey

            sName = Name
            iMode = Mode
        End Sub
        Public Overridable ReadOnly Property Name() As String Implements cIOptions.Name
            Get
                Return sName
            End Get
        End Property

        Public Overridable ReadOnly Property DefaultOptions As cOptions Implements cIOptions.DefaultOptions
            Get
                Return oDefaultOptions
            End Get
        End Property

        Public Overridable ReadOnly Property Mode() As cIOptions.ModeEnum Implements cIOptions.Mode
            Get
                Return iMode
            End Get
        End Property

        Public ReadOnly Property Survey As cSurvey Implements cIOptions.Survey
            Get
                Return oSurvey
            End Get
        End Property

        Public Event OnMapInvalidate(Sender As Object, e As EventArgs) Implements cIUIInteractions.OnMapInvalidate
        Public Event OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Implements cIUIBaseInteractions.OnPropertyChanged

        Public Overridable Sub MapInvalidate() Implements cIOptions.MapInvalidate
            RaiseEvent OnMapInvalidate(Me, EventArgs.Empty)
        End Sub

        Public Overridable Sub PropertyChanged(Name As String) Implements cIOptions.PropertyChanged
            RaiseEvent OnPropertyChanged(Me, New PropertyChangeEventArgs(Name))
        End Sub

        Public Overridable Function IsViewer() As Boolean Implements cIOptions.IsViewer
            Return iMode = cIOptions.ModeEnum.Viewer
        End Function

        Public Overridable Function IsPreview() As Boolean Implements cIOptions.IsPreview
            Return iMode = cIOptions.ModeEnum.Preview
        End Function

        Public Overridable Function IsDesign() As Boolean Implements cIOptions.IsDesign
            Return iMode = cIOptions.ModeEnum.Design
        End Function

        Public Overridable Function GetOption() As cIOptions Implements cIOptions.GetOption
            Return Me
        End Function

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlOptions As XmlElement = Document.CreateElement(sName)
            Call Parent.AppendChild(oXmlOptions)
            Return oXmlOptions
        End Function
    End Class

    Public Class cOptionsCenterline
        Inherits cOptions
        Implements cITextStructure
        Implements cIDesignProperties

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

        Private WithEvents oSurfaceOptions As cSurfaceOptions

        Private WithEvents oTranslationsOptions As cTranslationsOptions
        Private bDrawTranslation As Boolean

        Private WithEvents oHLsOptions As cHighlightsOptions
        Private bDrawHLs As Boolean

        Private sCurrentCaveVisibilityProfile As String

        Private oDrawingObjects As cOptionsDrawingObjects
        Private oPaintObjects As cPaintObjects

        Public Enum DesignAffinityEnum
            All = 0
            Design = 1
            Extra = 2
        End Enum

        Private iDesignAffinity As DesignAffinityEnum

        Public Overridable Property DesignAffinity As DesignAffinityEnum
            Get
                Return iDesignAffinity
            End Get
            Set(value As DesignAffinityEnum)
                If iDesignAffinity <> value Then
                    iDesignAffinity = value
                    Call PropertyChanged("DesignAffinity")
                End If
            End Set
        End Property

        Public Overrides Function GetOption() As cIOptions
            Return Me
        End Function

        Public Overridable ReadOnly Property SurfaceOptions As cSurfaceOptions
            Get
                Return oSurfaceOptions
            End Get
        End Property

        Public Enum CombineColorModeEnum
            CavesAndBranches = 0
            OnlyCaves = 1
            ExtendStart = 2
        End Enum

        Public Enum CenterlineColorModeEnum
            CavesAndBranches = 0
            OnlyCaves = 1
            ExtendStart = 2
        End Enum

        Private iCenterlineColorMode As CenterlineColorModeEnum
        Private bCenterlineColorGray As Boolean

        Public Overridable Property CenterlineColorMode As CenterlineColorModeEnum
            Get
                Return iCenterlineColorMode
            End Get
            Set(value As CenterlineColorModeEnum)
                If iCenterlineColorMode <> value Then
                    iCenterlineColorMode = value
                    Call PropertyChanged("CenterlineColorMode")
                End If
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
                    Call PropertyChanged("CenterlineColorGray")
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
                If iCombineColorMode <> value Then
                    iCombineColorMode = value
                    Call PropertyChanged("CombineColorMode")
                End If
            End Set
        End Property

        Public Overridable Property CombineColorGray As Boolean
            Get
                Return bCombineColorGray
            End Get
            Set(value As Boolean)
                If bCombineColorGray <> value Then
                    bCombineColorGray = value
                    Call PropertyChanged("CombineColorGray")
                End If
            End Set
        End Property
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

        Private WithEvents oCompassOptions As cCompassOptions
        Private WithEvents oInfoboxOptions As cInfoBoxOptions
        Private WithEvents oScaleOptions As cScaleOptions

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
                If iZOrderMode <> value Then
                    iZOrderMode = value
                    Call PropertyChanged("ZOrderMode")
                End If
            End Set
        End Property

        Public Overridable Property UseDrawingZOrder As Boolean
            Get
                Return bUseDrawingZOrder
            End Get
            Set(value As Boolean)
                If bUseDrawingZOrder <> value Then
                    bUseDrawingZOrder = value
                    Call PropertyChanged("UseDrawingZOrder")
                End If
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

        Private WithEvents oDesignProperties As cPropertiesCollection

        '--------------------------------------------------------------------------------------------
        'Private sPenHeavyWidth As Single
        'Private sPenMediumWidth As Single
        'Private sPenLightWidth As Single
        'Private sPenUltralightWidth As Single
        'Private sPenTightWidth As Single
        'Private oDefaultTextFont As cIFont
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
                If sInfoBoxStructure <> value Then
                    sInfoBoxStructure = value
                    Call PropertyChanged("InfoBoxStructure")
                End If
            End Set
        End Property

        Public Property TrigPointStructure() As String Implements cITextStructure.TrigPointStructure
            Get
                Return sTrigpointStructure
            End Get
            Set(ByVal value As String)
                If sTrigpointStructure <> value Then
                    sTrigpointStructure = value
                    Call PropertyChanged("TrigPointStructure")
                End If
            End Set
        End Property

        Public Property SpecialTrigPointStructure() As String Implements cITextStructure.SpecialTrigPointStructure
            Get
                Return sSpecialTrigpointStructure
            End Get
            Set(ByVal value As String)
                If sSpecialTrigpointStructure <> value Then
                    sSpecialTrigpointStructure = value
                    Call PropertyChanged("SpecialTrigPointStructure")
                End If
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
                If bShowAdvancedBrushes <> value Then
                    bShowAdvancedBrushes = value
                    Call PropertyChanged("ShowAdvancedBrushes")
                End If
            End Set
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
                If bDrawHLs <> value Then
                    bDrawHLs = value
                    Call PropertyChanged("DrawHighlights")
                End If
            End Set
        End Property

        Public Overridable Property DrawTranslation() As Boolean
            Get
                Return bDrawTranslation
            End Get
            Set(ByVal value As Boolean)
                If bDrawTranslation <> value Then
                    bDrawTranslation = value
                    Call PropertyChanged("DrawTranslation")
                End If
            End Set
        End Property

        Public Property DrawBox() As Boolean
            Get
                Return bDrawBox
            End Get
            Set(ByVal value As Boolean)
                If bDrawBox <> value Then
                    bDrawBox = value
                    Call PropertyChanged("DrawBox")
                End If
            End Set
        End Property

        Public Property BoxPosition() As AlignmentEnum
            Get
                Return iBoxPosition
            End Get
            Set(ByVal value As AlignmentEnum)
                If iBoxPosition <> value Then
                    iBoxPosition = value
                    Call PropertyChanged("BoxPosition")
                End If
            End Set
        End Property

        Public Property HighlightSegmentsAndTrigpoints() As Boolean
            Get
                Return bHighlightSegmentsAndTrigpoints
            End Get
            Set(ByVal value As Boolean)
                If bHighlightSegmentsAndTrigpoints <> value Then
                    bHighlightSegmentsAndTrigpoints = value
                    Call PropertyChanged("HighlightSegmentsAndTrigpoints")
                End If
            End Set
        End Property

        Public Property HighlightCurrentCave() As Boolean
            Get
                Return bHighlightCurrentCave
            End Get
            Set(ByVal value As Boolean)
                If bHighlightCurrentCave <> value Then
                    bHighlightCurrentCave = value
                    Call PropertyChanged("HighlightCurrentCave")
                End If
            End Set
        End Property

        Public Property HighlightMode() As HighlightModeEnum
            Get
                Return iHighlightMode
            End Get
            Set(ByVal value As HighlightModeEnum)
                If iHighlightMode <> value Then
                    iHighlightMode = value
                    Call PropertyChanged("HighlightMode")
                End If
            End Set
        End Property

        Public Property UnselectedCaveDrawStyle As UnselectedCaveDrawStyleEnum
            Get
                Return iUnselectedCaveDrawStyle
            End Get
            Set(ByVal value As UnselectedCaveDrawStyleEnum)
                If iUnselectedCaveDrawStyle <> value Then
                    iUnselectedCaveDrawStyle = value
                    Call PropertyChanged("UnselectedCaveDrawStyle")
                End If
            End Set
        End Property

        Public Property DrawScale() As Boolean
            Get
                Return bDrawScale
            End Get
            Set(ByVal value As Boolean)
                If bDrawScale <> value Then
                    bDrawScale = value
                    Call PropertyChanged("DrawScale")
                End If
            End Set
        End Property

        Public Property ScaleStyle() As ScaleStyleEnum
            Get
                Return iScaleStyle
            End Get
            Set(ByVal value As ScaleStyleEnum)
                If iScaleStyle <> value Then
                    iScaleStyle = value
                    Call PropertyChanged("ScaleStyle")
                End If
            End Set
        End Property

        Public Property ShowSegmentBindings As Boolean
            Get
                Return bShowSegmentBindings
            End Get
            Set(ByVal value As Boolean)
                If bShowSegmentBindings <> value Then
                    bShowSegmentBindings = value
                    Call PropertyChanged("ShowSegmentBindings")
                End If
            End Set
        End Property

        Public Property ScalePosition() As AlignmentEnum
            Get
                Return iScalePosition
            End Get
            Set(ByVal value As AlignmentEnum)
                If iScalePosition <> value Then
                    iScalePosition = value
                    Call PropertyChanged("ScalePosition")
                End If
            End Set
        End Property

        Public Property DrawCompass() As Boolean
            Get
                Return bDrawCompass
            End Get
            Set(ByVal value As Boolean)
                If bDrawCompass <> value Then
                    bDrawCompass = value
                    Call PropertyChanged("DrawCompass")
                End If
            End Set
        End Property

        Public Property CompassPosition() As AlignmentEnum
            Get
                Return iCompassPosition
            End Get
            Set(ByVal value As AlignmentEnum)
                If iCompassPosition <> value Then
                    iCompassPosition = value
                    Call PropertyChanged("CompassPosition")
                End If
            End Set
        End Property

        Public Property CompassStyle() As CompassStyleEnum
            Get
                Return iCompassStyle
            End Get
            Set(ByVal value As CompassStyleEnum)
                If iCompassStyle <> value Then
                    iCompassStyle = value
                    Call PropertyChanged("CompassStyle")
                End If
            End Set
        End Property

        Public Property DrawStyle() As DrawStyleEnum
            Get
                Return iDrawStyle
            End Get
            Set(ByVal value As DrawStyleEnum)
                If iDrawStyle <> value Then
                    iDrawStyle = value
                    Call PropertyChanged("DrawStyle")
                End If
            End Set
        End Property

        Public Property DesignStyle() As DesignStyleEnum
            Get
                Return iDesignStyle
            End Get
            Set(ByVal value As DesignStyleEnum)
                If iDesignStyle <> value Then
                    iDesignStyle = value
                    Call PropertyChanged("DesignStyle")
                End If
            End Set
        End Property

        Public Property SplayStyle() As SplayStyleEnum
            Get
                Return iSplayStyle
            End Get
            Set(ByVal value As SplayStyleEnum)
                If iSplayStyle <> value Then
                    iSplayStyle = value
                    Call PropertyChanged("SplayStyle")
                End If
            End Set
        End Property

        Public Overridable Property DrawSplay() As Boolean
            Get
                Return bDrawSplay
            End Get
            Set(ByVal value As Boolean)
                If bDrawSplay <> value Then
                    bDrawSplay = value
                    Call PropertyChanged("DrawSplay")
                End If
            End Set
        End Property

        Public Overridable Property DrawLRUD() As Boolean
            Get
                Return bDrawLRUD
            End Get
            Set(ByVal value As Boolean)
                If bDrawLRUD <> value Then
                    bDrawLRUD = value
                    Call PropertyChanged("DrawLRUD")
                End If
            End Set
        End Property

        'TODO: is redundant?
        Public Overridable Property DrawPointNames() As Boolean
            Get
                Return bDrawPointNames
            End Get
            Set(ByVal value As Boolean)
                If bDrawPointNames <> value Then
                    bDrawPointNames = value
                    Call PropertyChanged("DrawPointNames")
                End If
            End Set
        End Property

        Public Overridable Property DrawPoints() As Boolean
            Get
                Return bDrawPoints
            End Get
            Set(ByVal value As Boolean)
                If bDrawPoints <> value Then
                    bDrawPoints = value
                    Call PropertyChanged("DrawPoints")
                End If
            End Set
        End Property

        Public Overridable Property DrawSurfaceProfile() As Boolean
            Get
                Return bDrawSurfaceProfile
            End Get
            Set(ByVal value As Boolean)
                If bDrawSurfaceProfile <> value Then
                    bDrawSurfaceProfile = value
                    Call PropertyChanged("DrawSurfaceProfile")
                End If
            End Set
        End Property

        Public Overridable Property DrawDesign() As Boolean
            Get
                Return bDrawDesign
            End Get
            Set(ByVal value As Boolean)
                If bDrawDesign <> value Then
                    bDrawDesign = value
                    Call PropertyChanged("DrawDesign")
                End If
            End Set
        End Property

        Public Overridable Property DrawSpecialPoints() As Boolean
            Get
                Return bDrawSpecialPoints
            End Get
            Set(ByVal value As Boolean)
                If bDrawSpecialPoints <> value Then
                    bDrawSpecialPoints = value
                    Call PropertyChanged("DrawSpecialPoints")
                End If
            End Set
        End Property

        Public Overridable Property DrawSketches() As Boolean
            Get
                Return bDrawSketches
            End Get
            Set(ByVal value As Boolean)
                If bDrawSketches <> value Then
                    bDrawSketches = value
                    Call PropertyChanged("DrawSketches")
                End If
            End Set
        End Property

        Public Overridable Property DrawImages() As Boolean
            Get
                Return bDrawImages
            End Get
            Set(ByVal value As Boolean)
                If bDrawImages <> value Then
                    bDrawImages = value
                    Call PropertyChanged("DrawImages")
                End If
            End Set
        End Property

        Public Overridable Property DrawPlot() As Boolean
            Get
                Return bDrawPlot
            End Get
            Set(ByVal value As Boolean)
                If bDrawPlot <> value Then
                    bDrawPlot = value
                    Call PropertyChanged("DrawPlot")
                End If
            End Set
        End Property

        Public Overridable Property DrawSegments() As Boolean
            Get
                Return bDrawSegments
            End Get
            Set(ByVal value As Boolean)
                If bDrawSegments <> value Then
                    bDrawSegments = value
                    Call PropertyChanged("DrawSegments")
                End If
            End Set
        End Property

        Public Overridable Property DrawSegmentsOptions() As DrawSegmentsOptionsEnum
            Get
                Return iDrawSegmentsOptions
            End Get
            Set(ByVal value As DrawSegmentsOptionsEnum)
                If iDrawSegmentsOptions <> value Then
                    iDrawSegmentsOptions = value
                    Call PropertyChanged("DrawSegmentsOptions")
                End If
            End Set
        End Property

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
            MyBase.New(Survey, Name, Mode)
            oSurvey = Survey

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

            If MyBase.Name <> "" Then
                oDefaultOptions = New cOptions(oSurvey, "", MyBase.Mode)
            End If

            iCurrentScale = iDefaultDesignScale
            oCurrentRule = oSurvey.ScaleRules.FindRule(iCurrentScale)

            bUseDrawingZOrder = False

            'Dim oDefaultDesignProperties As cPropertiesCollection = oCurrentRule.DesignProperties
            'sPenHeavyWidth = oDefaultDesignProperties.GetValue("BaseHeavyLinesScaleFactor", 8.0)
            'sPenMediumWidth = oDefaultDesignProperties.GetValue("BaseMediumLinesScaleFactor", 3.0)
            'sPenLightWidth = oDefaultDesignProperties.GetValue("BaseLightLinesScaleFactor", 0.5)
            'sPenUltralightWidth = oDefaultDesignProperties.GetValue("BaseUltraLightLinesScaleFactor", 0.1)
            'sPenTightWidth = cEditPaintObjects.FilettoPenWidth
            'oDefaultTextFont = oSurvey.Properties.DesignProperties.GetValue("DesignTextFont", New cFont(oSurvey, "Tahoma", 8, Color.Black))

            bDrawSurfaceProfile = True

            oSurfaceOptions = New cSurfaceOptions(oSurvey)

            oDesignProperties = New cPropertiesCollection(oSurvey)

            oDrawingObjects = New cOptionsDrawingObjects(oSurvey, Me)
            oPaintObjects = New cPaintObjects(oSurvey)
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
                If bShowPointInformation <> value Then
                    bShowPointInformation = value
                    Call PropertyChanged("ShowPointInformation")
                End If
            End Set
        End Property

        Public Overridable Property ShowSplayMode() As ShowSplayModeEnum
            Get
                Return iShowSplayMode
            End Get
            Set(ByVal value As ShowSplayModeEnum)
                If iShowSplayMode <> value Then
                    iShowSplayMode = value
                    Call PropertyChanged("ShowSplayMode")
                End If
            End Set
        End Property

        Public Overridable Property ShowSplayText() As Boolean
            Get
                Return bShowSplayText
            End Get
            Set(ByVal value As Boolean)
                If bShowSplayText <> value Then
                    bShowSplayText = value
                    Call PropertyChanged("ShowSplayText")
                End If
            End Set
        End Property

        Public Overridable Property ShowPointText() As Boolean
            Get
                Return bShowPointText
            End Get
            Set(ByVal value As Boolean)
                If bShowPointText <> value Then
                    bShowPointText = value
                    Call PropertyChanged("ShowPointText")
                End If
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

            If MyBase.Name <> "" Then
                oDefaultOptions = New cOptions(oSurvey, "", MyBase.Mode)
            End If

            iCurrentScale = iDefaultDesignScale
            oCurrentRule = oSurvey.ScaleRules.FindRule(iCurrentScale)

            'Dim oDefaultDesignProperties As cPropertiesCollection = oCurrentRule.DesignProperties
            'sPenHeavyWidth = oDefaultDesignProperties.GetValue("BaseHeavyLinesScaleFactor", 8)
            'sPenMediumWidth = oDefaultDesignProperties.GetValue("BaseMediumLinesScaleFactor", 3)
            'sPenLightWidth = oDefaultDesignProperties.GetValue("BaseLightLinesScaleFactor", 0.5)
            'sPenUltralightWidth = oDefaultDesignProperties.GetValue("BaseUltraLightLinesScaleFactor", 0.1)
            'sPenTightWidth = cEditPaintObjects.FilettoPenWidth
            'oDefaultTextFont = oSurvey.Properties.DesignProperties.GetValue("DesignTextFont", New cFont(oSurvey, "Tahoma", 8, Color.Black))

            bDrawSurfaceProfile = modXML.GetAttributeValue(Options, "drawsurfaceprofile", True)

            Try
                If modXML.ChildElementExist(Options, "surfaceoptions") Then
                    oSurfaceOptions = New cSurfaceOptions(oSurvey, Options.Item("surfaceoptions"))
                Else
                    oSurfaceOptions = New cSurfaceOptions(oSurvey)
                End If
            Catch ex As Exception
                oSurfaceOptions = New cSurfaceOptions(oSurvey)
            End Try

            Try
                If modXML.ChildElementExist(Options, "designproperties") Then
                    oDesignProperties = New cPropertiesCollection(oSurvey, Options.Item("designproperties"))
                Else
                    oDesignProperties = New cPropertiesCollection(oSurvey)
                End If
            Catch
                oDesignProperties = New cPropertiesCollection(oSurvey)
            End Try

            oDrawingObjects = New cOptionsDrawingObjects(oSurvey, Me)
            oPaintObjects = New cPaintObjects(oSurvey)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Options As XmlElement, ByVal Mode As cIOptions.ModeEnum)
            Call MyBase.New(Survey, Options.Name, Mode)
            oSurvey = Survey
            Call Import(Options)
        End Sub

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlOptions As XmlElement = MyBase.SaveTo(File, Document, Parent)

            oXmlOptions.SetAttribute("drawplot", If(bDrawPlot, 1, 0))
            oXmlOptions.SetAttribute("drawdesign", If(bDrawDesign, 1, 0))
            oXmlOptions.SetAttribute("drawspecialpoints", If(bDrawSpecialPoints, 1, 0))

            oXmlOptions.SetAttribute("splaystyle", iSplayStyle.ToString("D"))
            oXmlOptions.SetAttribute("designstyle", iDesignStyle.ToString("D"))
            oXmlOptions.SetAttribute("drawstyle", iDrawStyle.ToString("D"))
            'oXmlOptions.SetAttribute("colorstyle", iColorStyle.ToString("D"))

            oXmlOptions.SetAttribute("drawlrud", If(bDrawLRUD, 1, 0))
            oXmlOptions.SetAttribute("drawsplay", If(bDrawSplay, 1, 0))
            oXmlOptions.SetAttribute("drawrings", If(bDrawRings, 1, 0))
            oXmlOptions.SetAttribute("drawsegments", If(bDrawSegments, 1, 0))
            oXmlOptions.SetAttribute("drawsegmentsoptions", iDrawSegmentsOptions.ToString("D"))
            oXmlOptions.SetAttribute("showsplaymode", iShowSplayMode.ToString("D"))

            oXmlOptions.SetAttribute("drawpointnames", If(bDrawPointNames, 1, 0))
            oXmlOptions.SetAttribute("drawpoints", If(bDrawPoints, 1, 0))

            oXmlOptions.SetAttribute("drawscale", If(bDrawScale, 1, 0))
            oXmlOptions.SetAttribute("scalestyle", iScaleStyle.ToString("D"))
            oXmlOptions.SetAttribute("scaleposition", iScalePosition.ToString("D"))

            oXmlOptions.SetAttribute("drawbox", If(bDrawBox, 1, 0))
            oXmlOptions.SetAttribute("boxposition", iBoxPosition.ToString("D"))

            oXmlOptions.SetAttribute("drawcompass", If(bDrawCompass, 1, 0))
            oXmlOptions.SetAttribute("compassstyle", iCompassStyle.ToString("D"))
            oXmlOptions.SetAttribute("compassposition", iCompassPosition.ToString("D"))

            oXmlOptions.SetAttribute("drawimages", If(bDrawImages, 1, 0))
            oXmlOptions.SetAttribute("drawsketches", If(bDrawSketches, 1, 0))

            oXmlOptions.SetAttribute("highlightcurrentcave", If(bHighlightCurrentCave, 1, 0))
            oXmlOptions.SetAttribute("highlightmode", iHighlightMode.ToString("D"))
            oXmlOptions.SetAttribute("unselectedcavedrawstyle", iUnselectedCaveDrawStyle.ToString("D"))
            oXmlOptions.SetAttribute("highlightsegmentsandtrigpoints", If(bHighlightSegmentsAndTrigpoints, 1, 0))

            oXmlOptions.SetAttribute("showpointinformation", If(bShowPointInformation, 1, 0))
            oXmlOptions.SetAttribute("showpointtext", If(bShowPointText, 1, 0))
            oXmlOptions.SetAttribute("showsplaytext", If(bShowSplayText, 1, 0))

            oXmlOptions.SetAttribute("showadvancedbrushes", If(bShowAdvancedBrushes, 1, 0))

            oXmlOptions.SetAttribute("showsurface", If(bShowSurface, 1, 0))
            oXmlOptions.SetAttribute("showelevation", If(bShowElevation, 1, 0))

            oXmlOptions.SetAttribute("currentcavevisibilityprofile", sCurrentCaveVisibilityProfile)

            If bUseDrawingZOrder Then
                Call oXmlOptions.SetAttribute("usedrawingzorder", "1")
                Call oXmlOptions.SetAttribute("zordermode", iZOrderMode.ToString("D"))
            End If

            Call oInfoboxOptions.SaveTo(File, Document, oXmlOptions)
            Call oCompassOptions.SaveTo(File, Document, oXmlOptions)
            Call oScaleOptions.SaveTo(File, Document, oXmlOptions)

            Call oXmlOptions.SetAttribute("drawtranslation", If(bDrawTranslation, 1, 0))
            Call oTranslationsOptions.SaveTo(File, Document, oXmlOptions)

            Call oXmlOptions.SetAttribute("drawhls", If(bDrawHLs, 1, 0))
            Call oHLsOptions.SaveTo(File, Document, oXmlOptions)

            Call oXmlOptions.SetAttribute("combinecolormode", iCombineColorMode.ToString("D"))
            Call oXmlOptions.SetAttribute("combinecolorgray", If(bCombineColorGray, 1, 0))

            Call oXmlOptions.SetAttribute("centerlinecolormode", iCenterlineColorMode.ToString("D"))
            Call oXmlOptions.SetAttribute("centerlinecolorgray", If(bCenterlineColorGray, 1, 0))

            Call oXmlOptions.SetAttribute("drawsurfaceprofile", If(bDrawSurfaceProfile, 1, 0))

            Call oSurfaceOptions.SaveTo(File, Document, oXmlOptions)

            Call oDesignProperties.SaveTo(File, Document, "designproperties", oXmlOptions)

            Return oXmlOptions
        End Function

        Public Overridable Property CurrentCaveVisibilityProfile As String
            Get
                Return sCurrentCaveVisibilityProfile
            End Get
            Set(value As String)
                If sCurrentCaveVisibilityProfile <> value Then
                    sCurrentCaveVisibilityProfile = value
                    Call PropertyChanged("CurrentCaveVisibilityProfile")
                End If
            End Set
        End Property

        Friend Function CurrentRule() As cIScaleRule
            If oCurrentRule Is Nothing Then
                oCurrentRule = oSurvey.ScaleRules.FindRule(iCurrentScale)
            End If
            Return oCurrentRule
        End Function

        Friend Property CurrentScale As Integer
            Get
                Return iCurrentScale
            End Get
            Set(ByVal value As Integer)
                If (value <> iCurrentScale) AndAlso (value >= 5 And value <= 50000) Then
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

        Public Overridable ReadOnly Property DesignProperties As cPropertiesCollection Implements cIDesignProperties.DesignProperties
            Get
                Return oDesignProperties
            End Get
        End Property

        Friend Overridable Function GetCurrentScale() As Integer
            Return CurrentRule.Scale
        End Function

        Public Overridable Function GetCurrentCategories() As cIScaleCategoriesVisibility
            Return CurrentRule.Categories
        End Function

        Public Overridable Function GetCurrentItems() As cVisibilityItems
            Return CurrentRule.Items
        End Function

        Public Overridable Function GetCurrentDesignPropertiesValue(Name As String, DefaultValue As Object)
            Return oDesignProperties.GetValue(Name, CurrentRule.DesignProperties.GetValue(Name, oSurvey.Properties.DesignProperties.GetValue(Name, DefaultValue)))
        End Function

        Public Function GetPenGeologyLineWidth() As Single
            Return oDesignProperties.GetValue("BaseGeologyLinesScaleFactor", 10.0)
        End Function

        Public Function GetPenHeavyWidth() As Single
            Return oDesignProperties.GetValue("BaseHeavyLinesScaleFactor", 8.0)
        End Function

        Public Function GetPenMediumWidth() As Single
            Return oDesignProperties.GetValue("BaseMediumLinesScaleFactor", 3.0)
        End Function

        Public Function GetPenLightWidth() As Single
            Return oDesignProperties.GetValue("BaseLightLinesScaleFactor", 0.5)
        End Function

        Public Function GetPenUltralightWidth() As Single
            Return oDesignProperties.GetValue("BaseUltraLightLinesScaleFactor", 0.1)
        End Function

        Public Function GetDefaultTextFont() As cFont
            Return oDesignProperties.GetValue("DesignTextFont", New cFont(oSurvey, "Tahoma", 8, Color.Black))
        End Function

        Friend Function GetFontDefaultSize(ByVal Type As cItemFont.FontTypeEnum) As Single
            Select Case Type
                Case cItemFont.FontTypeEnum.Note
                    Return GetDefaultTextFont.FontSize - 1
                Case cItemFont.FontTypeEnum.TrigPoint
                    Return GetDefaultTextFont.FontSize
                Case cItemFont.FontTypeEnum.CaveComplexName
                    Return GetDefaultTextFont.FontSize + 3
                Case cItemFont.FontTypeEnum.CaveName
                    Return GetDefaultTextFont.FontSize + 2
                Case cItemFont.FontTypeEnum.Title
                    Return GetDefaultTextFont.FontSize + 1
                Case cItemFont.FontTypeEnum.Generic
                    Return GetDefaultTextFont.FontSize
                Case cItemFont.FontTypeEnum.Custom
                    Return GetDefaultTextFont.FontSize
            End Select
        End Function

        Friend Function GetPenDefaultWidth(ByVal Type As cPen.PenTypeEnum) As Single
            Select Case Type
                Case cPen.PenTypeEnum.None
                    Return cEditPaintObjects.FilettoPenWidth
                Case cPen.PenTypeEnum.GenericPen, cPen.PenTypeEnum.PresumedGenericPen
                    Return GetPenUltralightWidth()
                Case cPen.PenTypeEnum.CavePen, cPen.PenTypeEnum.PresumedCavePen, cPen.PenTypeEnum.TooNarrowCavePen, cPen.PenTypeEnum.UnderlyingCavePen
                    Return GetPenHeavyWidth()
                Case cPen.PenTypeEnum.Pen, cPen.PenTypeEnum.PresumedPen
                    Return GetPenMediumWidth()
                Case cPen.PenTypeEnum.TightPen, cPen.PenTypeEnum.PresumedTightPen
                    Return cEditPaintObjects.FilettoPenWidth
                Case cPen.PenTypeEnum.GradientUpPen, cPen.PenTypeEnum.PresumedGradientUpPen
                    Return GetPenMediumWidth()
                Case cPen.PenTypeEnum.GradientDownPen, cPen.PenTypeEnum.PresumedGradientDownPen
                    Return GetPenMediumWidth()
                Case cPen.PenTypeEnum.CliffUpPen, cPen.PenTypeEnum.PresumedCliffUpPen
                    Return GetPenMediumWidth()
                Case cPen.PenTypeEnum.CliffDownPen, cPen.PenTypeEnum.PresumedCliffDownPen
                    Return GetPenMediumWidth()
                Case cPen.PenTypeEnum.OverhangUpPen, cPen.PenTypeEnum.PresumedOverhangUpPen
                    Return GetPenMediumWidth()
                Case cPen.PenTypeEnum.OverhangDownPen, cPen.PenTypeEnum.PresumedOverhangDownPen
                    Return GetPenMediumWidth()
                Case cPen.PenTypeEnum.MeanderPen, cPen.PenTypeEnum.PresumedMeanderPen
                    Return GetPenMediumWidth()
                Case cPen.PenTypeEnum.IcePen, cPen.PenTypeEnum.PresumedIcePen
                    Return GetPenMediumWidth()
                Case cPen.PenTypeEnum.AnticlinePen, cPen.PenTypeEnum.SynclinePen, cPen.PenTypeEnum.GenericFaultPen, cPen.PenTypeEnum.ReverseFaultpen, cPen.PenTypeEnum.GenericPresumedFaultPen, cPen.PenTypeEnum.NormalFaultPen, cPen.PenTypeEnum.StrikeFaultDxPen, cPen.PenTypeEnum.StrikeFaultSxPen, cPen.PenTypeEnum.StrikeFaultUnknownPen, cPen.PenTypeEnum.VerticalFaultPen
                    Return GetPenGeologyLineWidth()
                Case cPen.PenTypeEnum.Custom
                    Return cEditPaintObjects.FilettoPenWidth
            End Select
        End Function

        'Private Sub oSurvey_OnPropertiesChanged(Sender As cSurvey, Args As cSurvey.OnPropertiesChangedEventArgs) Handles oSurvey.OnPropertiesChanged
        '    If Not oCurrentRule Is Nothing Then
        '        'Dim oDesignProperties As cPropertiesCollection = oCurrentRule.DesignProperties
        '        sPenHeavyWidth = oDesignProperties.GetValue("BaseHeavyLinesScaleFactor", 8)
        '        sPenMediumWidth = oDesignProperties.GetValue("BaseMediumLinesScaleFactor", 3)
        '        sPenLightWidth = oDesignProperties.GetValue("BaseLightLinesScaleFactor", 0.5)
        '        sPenUltralightWidth = oDesignProperties.GetValue("BaseUltraLightLinesScaleFactor", 0.1)
        '        sPenTightWidth = cEditPaintObjects.FilettoPenWidth
        '        oDefaultTextFont = oDesignProperties.GetValue("DesignTextFont", New cFont(oSurvey, "Tahoma", 8, Color.Black))
        '    End If
        'End Sub

        Private Sub oTranslationsOptions_OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Handles oTranslationsOptions.OnPropertyChanged
            Call PropertyChanged("Translations." & e.Name)
        End Sub

        Private Sub oHLsOptions_OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Handles oHLsOptions.OnPropertyChanged
            Call PropertyChanged("HLs." & e.Name)
        End Sub

        Private Sub oSurfaceOptions_OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Handles oSurfaceOptions.OnPropertyChanged
            Call PropertyChanged("Surface." & e.Name)
        End Sub

        Private Sub oScaleOptions_OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Handles oScaleOptions.OnPropertyChanged
            Call PropertyChanged("Scale." & e.Name)
        End Sub

        Private Sub oInfoboxOptions_OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Handles oInfoboxOptions.OnPropertyChanged
            Call PropertyChanged("Infobox." & e.Name)
        End Sub

        Private Sub oCompassOptions_OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Handles oCompassOptions.OnPropertyChanged
            Call PropertyChanged("CompassOptions." & e.Name)
        End Sub

        Private Sub oDesignProperties_OnGetParent(sender As Object, e As cPropertiesCollection.cGetParentEventArgs) Handles oDesignProperties.OnGetParent
            e.Parent = CurrentRule.DesignProperties
        End Sub
    End Class

    Namespace Options
        Public Class cSurfaceBaseOptionsItem
            Implements cISurfaceBaseOptionsItem

            Private sID As String

            Public Sub New(ID As String)
                sID = ID
            End Sub
            Friend Sub ChangeID(ID As String)
                If sID <> ID Then
                    sID = ID
                End If
            End Sub

            Public ReadOnly Property ID As String Implements cISurfaceBaseOptionsItem.ID
                Get
                    Return sID
                End Get
            End Property

            Friend Overridable Function SaveTo(Name As String, ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
                Dim oXMLSurfaceOptionsItem As XmlElement = Document.CreateElement(Name)
                Call oXMLSurfaceOptionsItem.SetAttribute("id", sID)
                Call Parent.AppendChild(oXMLSurfaceOptionsItem)
                Return oXMLSurfaceOptionsItem
            End Function

            Friend Sub New(Item As XmlElement)
                sID = Item.GetAttribute("id")
            End Sub
        End Class

    End Namespace
End Namespace