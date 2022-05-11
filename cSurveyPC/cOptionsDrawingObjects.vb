Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Xml

Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design
    Friend Class cOptionsDrawingObjects
        Private WithEvents oSurvey As cSurvey
        Private oOptions As cOptions

        Private oPen As Pen
        Private oSelectedPen As Pen

        Private oSelectedRingPen As Pen

        Private oSelectedPointBrush As SolidBrush
        Private oSelectedPointPen As Pen
        Private oPointBrush As SolidBrush
        Private oPointPen As Pen

        Private oTranslationPen As Pen

        Private oInvalidPen As Pen

        Private oSurfaceProfilePen As Pen
        Private oSelectedSurfaceProfilePen As Pen

        Private oLRUDPen As Pen
        Private oLRUDSelectedPen As Pen
        Private oLRUDBrush As SolidBrush
        Private oLRUDSelectedBrush As SolidBrush
        Private sLRUDPenWidth As Single
        Private sLRUDSelectedPenWidth As Single
        Private iLRUDPenStyle As cPen.PenStylesEnum
        Private oLRUDPenColor As Color
        Private oLRUDBrushColor As SolidBrush

        Private oSplayPen As Pen
        Private oSplaySelectedPen As Pen
        Private oSplayBrush As SolidBrush
        Private oSplaySelectedBrush As SolidBrush
        Private sSplayPenWidth As Single
        Private sSplaySelectedPenWidth As Single
        Private iSplayPenStyle As cPen.PenStylesEnum
        Private oSplayPenColor As Color
        Private oSplayBrushColor As SolidBrush

        Private oCutSplayPen As Pen
        Private oCutSplaySelectedPen As Pen
        Private oCutSplayBrush As SolidBrush
        Private oCutSplaySelectedBrush As SolidBrush
        Private sCutSplayPenWidth As Single
        Private sCutSplaySelectedPenWidth As Single
        Private iCutSplayPenStyle As cPen.PenStylesEnum
        Private oCutSplayPenColor As Color
        Private oCutSplayBrushColor As SolidBrush

        Private oCrossSectionMarkerPenColor As Color
        Private oCrossSectionMarkerPen As Pen
        Private oCrossSectionMarkerBrush As SolidBrush
        Private sCrossSectionMarkerArrowSize As Single

        Private sSurfacePenWidth As Single
        Private sSurfaceSelectedPenWidth As Single
        Private oSurfacePenColor As Color

        Private oFont As Font
        Private oInfoFont As Font
        Private oBrush As SolidBrush
        Private oInfoBrush As SolidBrush
        Private oTextBrush As SolidBrush

        Private oSplayFont As Font

        Private sBaseFontSize As Single
        Private sBigFontSize As Single
        Private sSmallFontSize As Single
        Private sExtraSmallFontSize As Single

        Private sLineWidthScaleFactor As Single

        Private bEnableBrushes As Boolean
        Private bEnableTransparence As Boolean

        Private bCenterlineForceColor As Boolean

        Private sPointSize As Single
        Private sSelectedPointSize As Single
        Private oPointColor As Color

        Private oSelectedRingColor As Color

        Private sPenWidth As Single
        Private sSelectedPenWidth As Single
        Private iPenStyle As cPen.PenStylesEnum
        Private oPenColor As Color

        Private sTranslationLinePenWidth As Single
        Private iTranslationLinePenStyle As cPen.PenStylesEnum
        Private oTranslationLinePenColor As Color

        Private iDarkTransparentLevel As Integer = 250
        Private iLightTransparentLevel As Integer = 190

        Private oTextColor As Color

        Public ReadOnly Property CrossSectionMarkerArrowSize As Single
            Get
                Return sCrossSectionMarkerArrowSize
            End Get
        End Property

        Public ReadOnly Property DarkTransparentLevel As Integer
            Get
                Return iDarkTransparentLevel
            End Get
        End Property

        Public ReadOnly Property LightTransparentLevel As Integer
            Get
                Return iLightTransparentLevel
            End Get
        End Property

        Public ReadOnly Property PointBrush As Brush
            Get
                Return oPointBrush
            End Get
        End Property

        Public ReadOnly Property PointPen As Pen
            Get
                Return oPointPen
            End Get
        End Property

        Public ReadOnly Property SelectedPointBrush As Brush
            Get
                Return oSelectedPointBrush
            End Get
        End Property

        Public ReadOnly Property SelectedPointPen As Pen
            Get
                Return oSelectedPointPen
            End Get
        End Property

        Public ReadOnly Property SelectedPointSize As Single
            Get
                Return sSelectedPointSize
            End Get
        End Property

        Public ReadOnly Property PointSize As Single
            Get
                Return sPointSize
            End Get
        End Property

        Public ReadOnly Property EnableTransparence As Boolean
            Get
                Return bEnableTransparence
            End Get
        End Property

        Public ReadOnly Property EnableBrushes As Boolean
            Get
                Return bEnableBrushes
            End Get
        End Property

        Public ReadOnly Property Pen As Pen
            Get
                Return oPen
            End Get
        End Property

        Public ReadOnly Property TranslationPen As Pen
            Get
                Return oTranslationPen
            End Get
        End Property

        Public ReadOnly Property SelectedSurfaceProfilePen As Pen
            Get
                Return oSelectedSurfaceProfilePen
            End Get
        End Property

        Public ReadOnly Property InvalidPen As Pen
            Get
                Return oInvalidPen
            End Get
        End Property

        Public ReadOnly Property SurfaceProfilePen As Pen
            Get
                Return oSurfaceProfilePen
            End Get
        End Property

        Public ReadOnly Property SelectedPen As Pen
            Get
                Return oSelectedPen
            End Get
        End Property

        Public ReadOnly Property SelectedRingPen As Pen
            Get
                Return oSelectedRingPen
            End Get
        End Property

        Public ReadOnly Property SelectedRingColor As Color
            Get
                Return oSelectedRingColor
            End Get
        End Property

        Public ReadOnly Property LRUDSelectedPen As Pen
            Get
                Return oLRUDSelectedPen
            End Get
        End Property

        Public ReadOnly Property LRUDPen As Pen
            Get
                Return oLRUDPen
            End Get
        End Property

        Public ReadOnly Property LRUDBrush As SolidBrush
            Get
                Return oLRUDBrush
            End Get
        End Property

        Public ReadOnly Property LRUDSelectedBrush As SolidBrush
            Get
                Return oLRUDSelectedBrush
            End Get
        End Property

        Public ReadOnly Property SplaySelectedPen As Pen
            Get
                Return oSplaySelectedPen
            End Get
        End Property

        Public ReadOnly Property SplayPenColor As Color
            Get
                Return oSplayPenColor
            End Get
        End Property

        Public ReadOnly Property SplayPen As Pen
            Get
                Return oSplayPen
            End Get
        End Property

        Public ReadOnly Property SplayBrush As SolidBrush
            Get
                Return oSplayBrush
            End Get
        End Property

        Public ReadOnly Property SplaySelectedBrush As SolidBrush
            Get
                Return oSplaySelectedBrush
            End Get
        End Property

        Public ReadOnly Property Brush As Brush
            Get
                Return oBrush
            End Get
        End Property

        Public ReadOnly Property InfoBrush As Brush
            Get
                Return oInfoBrush
            End Get
        End Property

        Public ReadOnly Property TextBrush As Brush
            Get
                Return oTextBrush
            End Get
        End Property

        Public ReadOnly Property Font As Font
            Get
                Return oFont
            End Get
        End Property

        Public ReadOnly Property InfoFont As Font
            Get
                Return oInfoFont
            End Get
        End Property

        Public ReadOnly Property SplayFont As Font
            Get
                Return oSplayFont
            End Get
        End Property

        Public ReadOnly Property BaseFontSize As Single
            Get
                Return sBaseFontSize
            End Get
        End Property

        Public ReadOnly Property BigFontSize As Single
            Get
                Return sBigFontSize
            End Get
        End Property

        Public ReadOnly Property SmallFontSize As Single
            Get
                Return sSmallFontSize
            End Get
        End Property

        Public ReadOnly Property LineWidthScaleFactor As Single
            Get
                Return sLineWidthScaleFactor
            End Get
        End Property

        Public ReadOnly Property PointColor As Color
            Get
                Return oPointColor
            End Get
        End Property

        Public ReadOnly Property PenColor As Color
            Get
                Return oPenColor
            End Get
        End Property

        Public ReadOnly Property TextColor As Color
            Get
                Return oTextColor
            End Get
        End Property

        Public ReadOnly Property TranslationLinePenColor As Color
            Get
                Return oTranslationLinePenColor
            End Get
        End Property

        Public ReadOnly Property CrossSectionMarkerBrush As SolidBrush
            Get
                Return oCrossSectionMarkerBrush
            End Get
        End Property

        Public ReadOnly Property CrossSectionMarkerPen As Pen
            Get
                Return oCrossSectionMarkerPen
            End Get
        End Property

        Public ReadOnly Property CrossSectionMarkerPenColor As Color
            Get
                Return oCrossSectionMarkerPenColor
            End Get
        End Property

        Friend Sub Rebind()
            'Dim oDesignProperties As cPropertiesCollection = oOptions.CurrentRule.DesignProperties
            Dim sZoom As Single = 1

            Dim sTextScaleFactor As Single = oOptions.GetCurrentDesignPropertiesValue("PlotTextScaleFactor", 1)
            Dim oTextFont As cIFont = oOptions.GetCurrentDesignPropertiesValue("PlotTextFont", New cFont(oSurvey, "Tahoma", 8, Color.Black))

            sBaseFontSize = oTextFont.FontSize * sZoom / 15 * sTextScaleFactor
            sBigFontSize = oTextFont.FontSize * 1.2 * sZoom / 15 * sTextScaleFactor
            sSmallFontSize = oTextFont.FontSize * 0.8 * sZoom / 15 * sTextScaleFactor
            sExtraSmallFontSize = oTextFont.FontSize * 0.4 * sZoom / 15 * sTextScaleFactor
            If sBaseFontSize < 0.004 Then sBaseFontSize = 0.004
            If sBigFontSize < 0.006 Then sBigFontSize = 0.006
            If sSmallFontSize < 0.002 Then sSmallFontSize = 0.002
            If sExtraSmallFontSize < 0.001 Then sExtraSmallFontSize = 0.001

            sLineWidthScaleFactor = oOptions.GetCurrentDesignPropertiesValue("BaseLineWidthScaleFactor", 0.01)

            sPenWidth = oOptions.GetCurrentDesignPropertiesValue("PlotPenWidth", 2)
            sSelectedPenWidth = oOptions.GetCurrentDesignPropertiesValue("PlotSelectedPenWidth", 2)
            iPenStyle = oOptions.GetCurrentDesignPropertiesValue("PlotPenStyle", cPen.PenStylesEnum.Dash)
            oPenColor = oOptions.GetCurrentDesignPropertiesValue("PlotPenColor", Color.Black)

            sPointSize = oOptions.GetCurrentDesignPropertiesValue("PlotPointSize", 2) * sZoom / 15
            sSelectedPointSize = oOptions.GetCurrentDesignPropertiesValue("PlotSelectedPointSize", 8) * sZoom / 15
            oPointColor = oOptions.GetCurrentDesignPropertiesValue("PlotPointColor", Color.Red)

            oSelectedRingColor = oOptions.GetCurrentDesignPropertiesValue("PlotSelectedRingColor", Color.FromArgb(120, SystemColors.Highlight))

            sTranslationLinePenWidth = oOptions.GetCurrentDesignPropertiesValue("PlotTranslationLinePenWidth", 2)
            iTranslationLinePenStyle = oOptions.GetCurrentDesignPropertiesValue("PlotTranslationLinePenStyle", cPen.PenStylesEnum.Dot)
            oTranslationLinePenColor = oOptions.GetCurrentDesignPropertiesValue("PlotTranslationLinePenColor", Color.Black)

            sLRUDPenWidth = oOptions.GetCurrentDesignPropertiesValue("PlotLRUDPenWidth", 0.8)
            sLRUDSelectedPenWidth = oOptions.GetCurrentDesignPropertiesValue("PlotLRUDSelectedPenWidth", 1.2)
            iLRUDPenStyle = oOptions.GetCurrentDesignPropertiesValue("PlotLRUDPenStyle", cPen.PenStylesEnum.Dot)
            oLRUDPenColor = Color.Black

            sSplayPenWidth = oOptions.GetCurrentDesignPropertiesValue("PlotSplayPenWidth", 0.8)
            sSplaySelectedPenWidth = oOptions.GetCurrentDesignPropertiesValue("PlotSplaySelectedPenWidth", 1.2)
            iSplayPenStyle = oOptions.GetCurrentDesignPropertiesValue("PlotSplayPenStyle", cPen.PenStylesEnum.Dot)
            oSplayPenColor = Color.DimGray

            sCutSplayPenWidth = oOptions.GetCurrentDesignPropertiesValue("PlotCutSplayPenWidth", 0.9)
            sCutSplaySelectedPenWidth = oOptions.GetCurrentDesignPropertiesValue("PlotCutSplaySelectedPenWidth", 1.2)
            iCutSplayPenStyle = oOptions.GetCurrentDesignPropertiesValue("PlotCutSplayPenStyle", cPen.PenStylesEnum.Dot)
            oCutSplayPenColor = Color.DarkGray

            oCrossSectionMarkerPenColor = oOptions.GetCurrentDesignPropertiesValue("CrossSectionMarkerPenColor", Color.Black)
            oCrossSectionMarkerPen = New Pen(oCrossSectionMarkerPenColor, 0.01)
            oCrossSectionMarkerBrush = New SolidBrush(oCrossSectionMarkerPenColor)
            sCrossSectionMarkerArrowSize = oOptions.GetCurrentDesignPropertiesValue("CrossSectionMarkerArrowSize", 0.5)

            sSurfacePenWidth = oOptions.GetCurrentDesignPropertiesValue("SurfaceProfilePenWidth", 1)
            sSurfaceSelectedPenWidth = oOptions.GetCurrentDesignPropertiesValue("SurfaceProfileSelectedPenWidth", 2)
            oSurfacePenColor = oOptions.GetCurrentDesignPropertiesValue("SurfaceProfilePenColor", Color.Gray)
            oSurfaceProfilePen = New Pen(oSurfacePenColor, sLineWidthScaleFactor * sSurfacePenWidth)
            oSurfaceProfilePen.DashStyle = oOptions.GetCurrentDesignPropertiesValue("SurfaceProfilePenStyle", cPen.PenStylesEnum.Dot)
            oSelectedSurfaceProfilePen = New Pen(oSurfacePenColor, sLineWidthScaleFactor * sSurfaceSelectedPenWidth)
            oSelectedSurfaceProfilePen.DashStyle = oSurfaceProfilePen.DashStyle

            oInvalidPen = New Pen(Color.IndianRed, -1)
            oInvalidPen.DashStyle = DashStyle.Dot

            oTextColor = oOptions.GetCurrentDesignPropertiesValue("PlotTextColor", Color.Black)

            Select Case oOptions.DrawStyle
                Case cOptions.DrawStyleEnum.Solid, cOptions.DrawStyleEnum.OnlySegment
                    If oOptions.CenterlineColorGray Then
                        oPointColor = modPaint.GrayColor(oPointColor)
                        oPenColor = modPaint.GrayColor(oPenColor)
                        oTranslationLinePenColor = modPaint.GrayColor(oTranslationLinePenColor)
                        oLRUDPenColor = modPaint.GrayColor(oLRUDPenColor)
                        oTextColor = modPaint.GrayColor(oTextColor)
                    End If

                    oSelectedPointBrush = New SolidBrush(oPointColor)
                    oSelectedPointPen = New Pen(oPointColor, sLineWidthScaleFactor)

                    oPointBrush = New SolidBrush(oPointColor)
                    oPointPen = New Pen(oPointColor, sLineWidthScaleFactor)

                    oTranslationPen = New Pen(oTranslationLinePenColor, sLineWidthScaleFactor * sTranslationLinePenWidth)
                    oTranslationPen.DashStyle = iTranslationLinePenStyle

                    oLRUDPen = New Pen(oLRUDPenColor, sLineWidthScaleFactor * sLRUDPenWidth)
                    oLRUDPen.DashStyle = iLRUDPenStyle
                    oLRUDSelectedPen = New Pen(oLRUDPenColor, sLineWidthScaleFactor * sLRUDSelectedPenWidth)
                    oLRUDSelectedPen.DashStyle = iLRUDPenStyle
                    oLRUDBrush = New SolidBrush(oLRUDPenColor)
                    oLRUDSelectedBrush = New SolidBrush(oLRUDPenColor)

                    oSplayPen = New Pen(oSplayPenColor, sLineWidthScaleFactor * sSplayPenWidth)
                    oSplayPen.DashStyle = iSplayPenStyle
                    oSplaySelectedPen = New Pen(oSplayPenColor, sLineWidthScaleFactor * sSplaySelectedPenWidth)
                    oSplaySelectedPen.DashStyle = iSplayPenStyle
                    oSplayBrush = New SolidBrush(oSplayPenColor)
                    oSplaySelectedBrush = New SolidBrush(oSplayPenColor)

                    oCutSplayPen = New Pen(oCutSplayPenColor, sLineWidthScaleFactor * sCutSplayPenWidth)
                    oCutSplayPen.DashStyle = iCutSplayPenStyle
                    oCutSplaySelectedPen = New Pen(oCutSplayPenColor, sLineWidthScaleFactor * sCutSplaySelectedPenWidth)
                    oCutSplaySelectedPen.DashStyle = iCutSplayPenStyle
                    oCutSplayBrush = New SolidBrush(oCutSplayPenColor)
                    oCutSplaySelectedBrush = New SolidBrush(oCutSplayPenColor)

                    oFont = New Font(oTextFont.FontName, sBigFontSize, oTextFont.FontStyle)
                    oInfoFont = New Font(oTextFont.FontName, sSmallFontSize, FontStyle.Regular)
                    oSplayFont = New Font(oTextFont.FontName, sExtraSmallFontSize, FontStyle.Regular)
                    oBrush = New SolidBrush(Color.Black)
                    oInfoBrush = New SolidBrush(oTextColor)
                    oTextBrush = New SolidBrush(oTextColor)

                    oPen = New Pen(oPenColor, sLineWidthScaleFactor * sPenWidth)
                    oPen.DashStyle = iPenStyle
                    oSelectedPen = New Pen(oPenColor, sLineWidthScaleFactor * sSelectedPenWidth)
                    oSelectedPen.DashStyle = iPenStyle

                    oSelectedRingPen = New Pen(oSelectedRingColor, sLineWidthScaleFactor * sSelectedPenWidth * 10)
                    oSelectedRingPen.StartCap = LineCap.RoundAnchor Or LineCap.Round
                    oSelectedRingPen.EndCap = LineCap.RoundAnchor Or LineCap.Round

                    'oAreaPen = New Pen(Color.DarkGreen, sLineWidthScaleFactor)
                    'oAreaPen.DashStyle = DashStyle.Dot
                    'oAreaBrush = New SolidBrush(Color.LightGreen)
                    ''oLateralSegmentPen = New Pen(Color.DarkGreen, sLineWidthScaleFactor)
                    'oSelectedAreaPen = New Pen(Color.DarkGreen, sLineWidthScaleFactor)
                    'oSelectedAreaPen.DashStyle = DashStyle.Dot
                    'oSelectedAreaBrush = New SolidBrush(Color.LightGreen)

                    bEnableBrushes = True
                    bEnableTransparence = False
                Case cOptions.DrawStyleEnum.Transparent
                    If oOptions.CenterlineColorGray Then
                        oPointColor = modPaint.GrayColor(oPointColor)
                        oPenColor = modPaint.GrayColor(oPenColor)
                        oTranslationLinePenColor = modPaint.GrayColor(oTranslationLinePenColor)
                        oLRUDPenColor = modPaint.GrayColor(oLRUDPenColor)
                        oTextColor = modPaint.GrayColor(oTextColor)
                    End If

                    oSelectedPointBrush = New SolidBrush(oPointColor)
                    oSelectedPointPen = New Pen(oPointColor, sLineWidthScaleFactor)

                    oPointBrush = New SolidBrush(oPointColor)
                    oPointPen = New Pen(oPointColor, sLineWidthScaleFactor)

                    oTranslationPen = New Pen(oTranslationLinePenColor, sLineWidthScaleFactor * sTranslationLinePenWidth)
                    oTranslationPen.DashStyle = iTranslationLinePenStyle

                    oLRUDPen = New Pen(Color.FromArgb(200, oLRUDPenColor), sLineWidthScaleFactor * sLRUDPenWidth)
                    oLRUDPen.DashStyle = iLRUDPenStyle
                    oLRUDSelectedPen = New Pen(Color.FromArgb(200, oLRUDPenColor), sLineWidthScaleFactor * sLRUDSelectedPenWidth)
                    oLRUDSelectedPen.DashStyle = iLRUDPenStyle
                    oLRUDBrush = New SolidBrush(Color.FromArgb(200, modPaint.LightColor(oLRUDPenColor, 0.1)))
                    oLRUDSelectedBrush = New SolidBrush(Color.FromArgb(200, modPaint.LightColor(oLRUDPenColor, 0.1)))

                    oSplayPen = New Pen(Color.FromArgb(200, oSplayPenColor), sLineWidthScaleFactor * sSplayPenWidth)
                    oSplayPen.DashStyle = iSplayPenStyle
                    oSplaySelectedPen = New Pen(Color.FromArgb(200, oSplayPenColor), sLineWidthScaleFactor * sSplaySelectedPenWidth)
                    oSplaySelectedPen.DashStyle = iSplayPenStyle
                    oSplayBrush = New SolidBrush(Color.FromArgb(200, modPaint.LightColor(oSplayPenColor, 0.1)))
                    oSplaySelectedBrush = New SolidBrush(Color.FromArgb(200, modPaint.LightColor(oSplayPenColor, 0.1)))

                    oFont = New Font(oTextFont.FontName, sBigFontSize, oTextFont.FontStyle)
                    oInfoFont = New Font(oTextFont.FontName, sSmallFontSize, FontStyle.Regular)
                    oSplayFont = New Font(oTextFont.FontName, sExtraSmallFontSize, FontStyle.Regular)
                    oBrush = New SolidBrush(Color.Black)
                    oInfoBrush = New SolidBrush(oTextColor)
                    oTextBrush = New SolidBrush(oTextColor)

                    oPen = New Pen(oPenColor, sLineWidthScaleFactor * sPenWidth)
                    oPen.DashStyle = iPenStyle
                    oSelectedPen = New Pen(oPenColor, sLineWidthScaleFactor * sSelectedPenWidth)
                    oSelectedPen.DashStyle = iPenStyle

                    oSelectedRingPen = New Pen(oSelectedRingColor, sLineWidthScaleFactor * sSelectedPenWidth * 10)
                    oSelectedRingPen.StartCap = LineCap.RoundAnchor Or LineCap.Round
                    oSelectedRingPen.EndCap = LineCap.RoundAnchor Or LineCap.Round

                    'oAreaPen = New Pen(Color.FromArgb(228, Color.DarkGreen), sLineWidthScaleFactor)
                    'oAreaPen.DashStyle = DashStyle.Dot
                    'oAreaBrush = New SolidBrush(Color.FromArgb(100, Color.LightGreen))
                    ''oLateralSegmentPen = New Pen(Color.FromArgb(228, Color.DarkGreen), sLineWidthScaleFactor)
                    'oSelectedAreaPen = New Pen(Color.FromArgb(250, Color.DarkGreen), sLineWidthScaleFactor)
                    'oSelectedAreaPen.DashStyle = DashStyle.Dot
                    'oSelectedAreaBrush = New SolidBrush(Color.FromArgb(230, Color.LightGreen))

                    bEnableBrushes = True
                    bEnableTransparence = True
                    'End If
                Case cOptions.DrawStyleEnum.Light
                    If oOptions.CenterlineColorGray Then
                        oPointColor = modPaint.GrayColor(oPointColor)
                        oPenColor = modPaint.GrayColor(oPenColor)
                        oTranslationLinePenColor = modPaint.GrayColor(oTranslationLinePenColor)
                        oLRUDPenColor = modPaint.GrayColor(oLRUDPenColor)
                        oTextColor = modPaint.GrayColor(oTextColor)
                    End If

                    oSelectedPointBrush = New SolidBrush(oPointColor)
                    oSelectedPointPen = New Pen(oPointColor, sLineWidthScaleFactor)

                    oPointBrush = New SolidBrush(oPointColor)
                    oPointPen = New Pen(oPointColor, sLineWidthScaleFactor)

                    oTranslationPen = New Pen(oTranslationLinePenColor, sLineWidthScaleFactor * sTranslationLinePenWidth)
                    oTranslationPen.DashStyle = iTranslationLinePenStyle

                    oLRUDPen = New Pen(oLRUDPenColor, sLineWidthScaleFactor * sLRUDPenWidth)
                    oLRUDPen.DashStyle = iLRUDPenStyle
                    oLRUDSelectedPen = New Pen(oLRUDPenColor, sLineWidthScaleFactor * sLRUDSelectedPenWidth)
                    oLRUDSelectedPen.DashStyle = iLRUDPenStyle
                    oLRUDBrush = New SolidBrush(modPaint.LightColor(oLRUDPenColor, 0.1))
                    oLRUDSelectedBrush = New SolidBrush(modPaint.LightColor(oLRUDPenColor, 0.1))

                    oSplayPen = New Pen(oSplayPenColor, sLineWidthScaleFactor * sSplayPenWidth)
                    oSplayPen.DashStyle = iSplayPenStyle
                    oSplaySelectedPen = New Pen(oSplayPenColor, sLineWidthScaleFactor * sSplaySelectedPenWidth)
                    oSplaySelectedPen.DashStyle = iSplayPenStyle
                    oSplayBrush = New SolidBrush(modPaint.LightColor(oSplayPenColor, 0.1))
                    oSplaySelectedBrush = New SolidBrush(modPaint.LightColor(oSplayPenColor, 0.1))

                    oFont = New Font(oTextFont.FontName, sBigFontSize, oTextFont.FontStyle)
                    oInfoFont = New Font(oTextFont.FontName, sSmallFontSize, FontStyle.Regular)
                    oSplayFont = New Font(oTextFont.FontName, sExtraSmallFontSize, FontStyle.Regular)
                    oBrush = New SolidBrush(Color.FromArgb(130, Color.Black))
                    oInfoBrush = New SolidBrush(Color.FromArgb(130, oTextColor))
                    oTextBrush = New SolidBrush(Color.FromArgb(130, oTextColor))

                    oPen = New Pen(oPenColor, sLineWidthScaleFactor * sPenWidth)
                    oPen.DashStyle = iPenStyle
                    oSelectedPen = New Pen(oPenColor, sLineWidthScaleFactor * sSelectedPenWidth)
                    oSelectedPen.DashStyle = iPenStyle

                    oSelectedRingPen = New Pen(oPenColor, sLineWidthScaleFactor * sSelectedPenWidth * 10)
                    oSelectedRingPen.StartCap = LineCap.RoundAnchor Or LineCap.Round
                    oSelectedRingPen.EndCap = LineCap.RoundAnchor Or LineCap.Round

                    'oAreaPen = New Pen(Color.DarkGreen, sLineWidthScaleFactor)
                    'oAreaPen.DashStyle = Drawing2D.DashStyle.Dot
                    'oAreaBrush = Nothing
                    ''oLateralSegmentPen = New Pen(Color.DarkGreen, sLineWidthScaleFactor)
                    'oSelectedAreaPen = New Pen(Color.DarkGreen, sLineWidthScaleFactor)
                    'oSelectedAreaPen.DashStyle = Drawing2D.DashStyle.Dot
                    'oSelectedAreaBrush = Nothing

                    bEnableBrushes = False
                    bEnableTransparence = False
            End Select

            Dim bShowCenterlineVectors As Boolean = oOptions.GetCurrentDesignPropertiesValue("PlotCenterlineVector", 0)
            If bShowCenterlineVectors Then
                oPen.CustomEndCap = New AdjustableArrowCap(3, 3)
                oSelectedPen.CustomEndCap = New AdjustableArrowCap(4, 4)
            End If

            bCenterlineForceColor = oOptions.GetCurrentDesignPropertiesValue("PlotCenterlineForceColor", 0)
        End Sub

        Public ReadOnly Property CenterlineForceColor As Boolean
            Get
                Return bCenterlineForceColor
            End Get
        End Property


        Friend Sub New(ByVal Survey As cSurvey, ByVal Options As cOptions)
            oSurvey = Survey
            oOptions = Options
            Call Rebind()
        End Sub

        Private Sub oSurvey_OnPropertiesChanged(ByVal Sender As cSurvey, ByVal Args As cSurvey.OnPropertiesChangedEventArgs) Handles oSurvey.OnPropertiesChanged
            Call Rebind()
        End Sub
    End Class
End Namespace