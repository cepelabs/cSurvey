Imports cSurveyPC
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Drawings

Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace cSurvey.Design
    Public Class cPen
        Implements IDisposable

        Public Enum PenTypeEnum
            None = 0

            CavePen = 1
            PresumedCavePen = 8
            TooNarrowCavePen = 25
            UnderlyingCavePen = 26

            Pen = 2
            PresumedPen = 3

            CliffUpPen = 4
            PresumedCliffUpPen = 13
            CliffDownPen = 5
            PresumedCliffDownPen = 14
            GradientUpPen = 6
            PresumedGradientUpPen = 15
            GradientDownPen = 7
            PresumedGradientDownPen = 16

            GenericPen = 9
            PresumedGenericPen = 17
            TightPen = 10
            PresumedTightPen = 18

            OverhangUpPen = 11
            PresumedOverhangUpPen = 19
            OverhangDownPen = 12
            PresumedOverhangDownPen = 20

            MeanderPen = 21
            PresumedMeanderPen = 22

            IcePen = 23
            PresumedIcePen = 24

            Custom = 99
        End Enum

        Public Enum PenStylesEnum
            Solid = 0
            Dash = 1
            Dot = 2
            DashDot = 3
            DashDotDot = 4

            LargeDashSmallSpace = 5
            LargeDashMediumSpace = 6
            LargeDashLargeSpace = 7

            None = 98
            Custom = 99
        End Enum

        Public Enum DecorationStylesEnum
            None = 0
            Dash = 1
            Triangle = 2
            UpArrow = 3
            DownArrow = 4
            UpTriangle = 5
            DownTriangle = 6
            Ice = 7
            EmptyUpTriangle = 8
            EmptyDownTriangle = 9

            Custom = 99
        End Enum

        Public Enum DecorationAlignmentEnum
            Outer = 0
            Center = 1
            Inner = 2
        End Enum

        Private WithEvents oSurvey As cSurvey

        Private sName As String
        Private iType As PenTypeEnum

        Private oColor As Color
        Private oAlternativeColor As Color
        Private sWidth As Single
        Private iStyle As PenStylesEnum
        Private sStylePattern As Single()
        Private iDecorationStyle As DecorationStylesEnum
        Private iDecorationAlignment As DecorationAlignmentEnum
        Private sDecorationSpacePercentage As Single
        Private sDecorationScale As Single

        Private oClipart As cDrawClipArt

        Private oPen As Pen
        Private oBrush As SolidBrush
        Private oWireframePen As Pen

        Private sLocalLineWidth As Single
        Private sLocalZoomFactor As Single

        Private bInvalidated As Boolean

        Friend Event OnChanged(ByVal Sender As cPen)

        Friend Class cRenderArgs
            Public Transparency As Single
        End Class
        Friend Event OnRender(sender As cPen, RenderArgs As cRenderArgs)

        Public Function GetThumbnailImage(ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal thumbWidth As Integer, ByVal thumbHeight As Integer) As Image
            Return GetThumbnailImage(PaintOptions, Options, Selected, thumbHeight, thumbHeight, Color.Black, Color.White)
        End Function

        Public Function GetThumbnailImage(ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal thumbWidth As Integer, ByVal thumbHeight As Integer, ByVal ForeColor As Color, ByVal Backcolor As Color) As Image
            Try
                Dim oBounds As RectangleF = New RectangleF(0, 0, thumbWidth, thumbHeight)
                Dim oImage As Image = New Bitmap(thumbWidth, thumbHeight)
                Dim oGr As Graphics = Graphics.FromImage(oImage)
                oGr.SmoothingMode = SmoothingMode.AntiAlias
                oGr.CompositingQuality = CompositingQuality.HighQuality
                oGr.InterpolationMode = InterpolationMode.HighQualityBicubic

                Dim oBackBrush As SolidBrush = New SolidBrush(Backcolor)
                Call oGr.FillRectangle(oBackBrush, oBounds)

                Dim oPath As GraphicsPath = New GraphicsPath
                Dim oP0 As PointF = New PointF(oBounds.Left + 1, oBounds.Top + oBounds.Height / 2)
                Dim oP1 As PointF = New PointF(oBounds.Right - 1, oBounds.Top + oBounds.Height / 2)
                Call oPath.AddLine(oP0, oP1)

                Dim oCache As cDrawCache = New cDrawCache
                Call Render(oGr, PaintOptions, cItem.PaintOptionsEnum.None, False, oPath, oCache)
                Call oCache.Paint(oGr, PaintOptions, cItem.PaintOptionsEnum.None)

                Call oPath.Dispose()
                Call oBackBrush.Dispose()
                Call oGr.Dispose()

                Return oImage
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End Function

        Friend ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public Sub CopyFrom(ByVal Pen As cPen)
            sName = Pen.sName
            iType = Pen.iType
            oColor = Pen.oColor
            sWidth = Pen.sWidth
            iStyle = Pen.iStyle
            If IsNothing(Pen.Clipart) Then
                oClipart = Nothing
            Else
                oClipart = Pen.oClipart.Clone
            End If
            iDecorationAlignment = Pen.iDecorationAlignment
            iDecorationStyle = Pen.iDecorationStyle
            sDecorationSpacePercentage = Pen.sDecorationSpacePercentage
            sDecorationScale = Pen.sDecorationScale
            sLocalLineWidth = Pen.sLocalLineWidth
            Call Invalidate()
        End Sub

        Friend Property LocalZoomFactor As Single
            Get
                Return sLocalZoomFactor
            End Get
            Set(ByVal value As Single)
                If sLocalZoomFactor <> value Then
                    sLocalZoomFactor = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Friend Property LocalLineWidth As Single
            Get
                Return sLocalLineWidth
            End Get
            Set(ByVal value As Single)
                If sLocalLineWidth <> value Then
                    sLocalLineWidth = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property Name() As String
            Get
                Return sName
            End Get
            Set(ByVal value As String)
                If sName <> value Then
                    iType = PenTypeEnum.Custom
                    sName = value
                End If
            End Set
        End Property

        Public Property Type() As PenTypeEnum
            Get
                Return iType
            End Get
            Set(ByVal value As PenTypeEnum)
                If iType <> value Then
                    If iType <> PenTypeEnum.Custom AndAlso value = PenTypeEnum.Custom Then
                        Call CopyFrom(oSurvey.EditPaintObjects.Pens.FromType(iType))
                    Else
                        Call CopyFrom(oSurvey.EditPaintObjects.Pens.FromType(value))
                    End If
                    iType = value
                End If
            End Set
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Type As PenTypeEnum)
            oSurvey = Survey
            Call CopyFrom(Survey.EditPaintObjects.Pens.FromType(iType))
            bInvalidated = True
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Pen As cPen)
            oSurvey = Survey
            Call CopyFrom(Pen)
            bInvalidated = True
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Name As String, ByVal Type As PenTypeEnum, ByVal Color As Color, Optional ByVal Width As Single = 1, Optional ByVal Style As PenStylesEnum = PenStylesEnum.Solid, Optional Clipart As cDrawClipArt = Nothing, Optional ByVal DecorationStyle As DecorationStylesEnum = DecorationStylesEnum.None, Optional ByVal DecorationSpacePercentage As Single = 100, Optional ByVal DecorationAlignment As DecorationAlignmentEnum = DecorationStylesEnum.None, Optional ByVal DecorationScale As Single = 1, Optional StylePattern As Single() = Nothing)
            oSurvey = Survey
            sName = Name
            iType = Type
            oColor = Color
            sWidth = Width
            iStyle = Style
            If iStyle = PenStylesEnum.Custom Then
                If StylePattern Is Nothing Then
                    sStylePattern = {2, 2}
                Else
                    sStylePattern = StylePattern
                End If
            End If
            oClipart = Clipart
            iDecorationStyle = DecorationStyle
            sDecorationSpacePercentage = DecorationSpacePercentage
            iDecorationAlignment = DecorationAlignment
            sDecorationScale = DecorationScale
            bInvalidated = True
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            iType = PenTypeEnum.Custom
            oColor = Color.Black
            sWidth = 1
            sDecorationSpacePercentage = 100
            sDecorationScale = 1
            bInvalidated = True
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal item As XmlElement)
            oSurvey = Survey
            iType = modXML.GetAttributeValue(item, "type", PenTypeEnum.Custom)
            If iType = PenTypeEnum.Custom Then
                sName = modXML.GetAttributeValue(item, "name", "")
                oColor = modXML.GetAttributeColor(item, "color", Color.Black)
                iStyle = modXML.GetAttributeValue(item, "style")
                If iStyle = PenStylesEnum.Custom Then
                    sStylePattern = modPaint.StringToPenStylePattern(modXML.GetAttributeValue(item, "stylepattern"))
                End If
                sWidth = modXML.GetAttributeValue(item, "width")
                Dim oXMLClipart As XmlElement = item.Item("clipart")
                If oXMLClipart Is Nothing Then
                    oClipart = New cDrawClipArt()
                Else
                    oClipart = New cDrawClipArt(oXMLClipart)
                End If
                iDecorationStyle = modXML.GetAttributeValue(item, "decorationstyle")
                sDecorationSpacePercentage = modXML.GetAttributeValue(item, "decorationspacepercentage")
                If sDecorationSpacePercentage = 0 Then sDecorationSpacePercentage = 100
                iDecorationAlignment = modXML.GetAttributeValue(item, "decorationalignment")
                sDecorationScale = modXML.GetAttributeValue(item, "decorationscale")
                If sDecorationScale = 0 Then sDecorationScale = 1
            Else
                Call CopyFrom(oSurvey.EditPaintObjects.Pens.FromType(iType))
            End If
            Call Invalidate()
        End Sub

        Public Property Clipart() As cDrawClipArt
            Get
                Return oClipart
            End Get
            Set(ByVal Value As cDrawClipArt)
                If Not oClipart Is Value Then
                    iType = PenTypeEnum.Custom
                    oClipart = Value
                    Call Invalidate()
                End If
            End Set
        End Property

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oItem As XmlElement = Document.CreateElement("pen")
            Call oItem.SetAttribute("type", iType)

            If iType = PenTypeEnum.Custom Then
                If sName <> "" Then
                    Call oItem.SetAttribute("name", sName)
                End If
                Call oItem.SetAttribute("color", oColor.ToArgb)
                Call oItem.SetAttribute("style", iStyle)
                If iStyle = PenStylesEnum.Custom Then
                    Call oItem.SetAttribute("stylepattern", modPaint.PenStylePatternToString(sStylePattern))
                End If
                Call oItem.SetAttribute("width", sWidth)
                If Not oClipart Is Nothing Then Call oClipart.SaveTo(File, Document, oItem)
                Call oItem.SetAttribute("decorationstyle", iDecorationStyle)
                Call oItem.SetAttribute("decorationspacepercentage", sDecorationSpacePercentage)
                Call oItem.SetAttribute("decorationalignment", iDecorationAlignment)
                Call oItem.SetAttribute("decorationscale", sDecorationScale)
            End If

            Call Parent.AppendChild(oItem)
            Return oItem
        End Function

        Public Property Width() As Single
            Get
                Return sWidth
            End Get
            Set(ByVal value As Single)
                If sWidth <> value Then
                    iType = PenTypeEnum.Custom
                    sWidth = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property Style() As PenStylesEnum
            Get
                Return iStyle
            End Get
            Set(ByVal value As PenStylesEnum)
                If iStyle <> value Then
                    iType = PenTypeEnum.Custom
                    iStyle = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property Color() As Color
            Get
                Return oColor
            End Get
            Set(ByVal value As Color)
                If Color <> value Then
                    iType = PenTypeEnum.Custom
                    oColor = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property AlternativeColor() As Color
            Get
                Return oAlternativeColor
            End Get
            Set(ByVal value As Color)
                oAlternativeColor = value
                Call Invalidate()
            End Set
        End Property

        Public Property DecorationStyle() As DecorationStylesEnum
            Get
                Return iDecorationStyle
            End Get
            Set(ByVal value As DecorationStylesEnum)
                If iDecorationStyle <> value Then
                    iType = PenTypeEnum.Custom
                    iDecorationStyle = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property DecorationAlignment() As DecorationAlignmentEnum
            Get
                Return iDecorationAlignment
            End Get
            Set(ByVal value As DecorationAlignmentEnum)
                If iDecorationAlignment <> value Then
                    iType = PenTypeEnum.Custom
                    iDecorationAlignment = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property DecorationSpacePercentage() As Single
            Get
                Return sDecorationSpacePercentage
            End Get
            Set(ByVal value As Single)
                If sDecorationSpacePercentage <> value Then
                    iType = PenTypeEnum.Custom
                    sDecorationSpacePercentage = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property DecorationScale() As Single
            Get
                Return sDecorationScale
            End Get
            Set(ByVal value As Single)
                If sDecorationScale <> value Then
                    iType = PenTypeEnum.Custom
                    sDecorationScale = value
                    Call Invalidate()
                End If
            End Set
        End Property

        'Friend Function IsInvalidated(Options As cItem.PaintOptionsEnum) As Boolean
        '    If (Options And cItem.PaintOptionsEnum.Wireframe) = cItem.PaintOptionsEnum.Wireframe Or (Options And cItem.PaintOptionsEnum.SchematicLayerDraw) = cItem.PaintOptionsEnum.SchematicLayerDraw Then
        '        Return bInvalidatedWireframe
        '    Else
        '        Return bInvalidatedFull
        '    End If
        'End Function

        Friend ReadOnly Property Invalidated As Boolean
            Get
                Return bInvalidated
            End Get
        End Property

        Friend Sub Invalidate()
            bInvalidated = True
            RaiseEvent OnChanged(Me)
        End Sub

        Friend Function GetPaintZoomFactor(PaintOptions As cOptions) As Single
            Dim sZoomFactor As Single
            If sLocalZoomFactor = 0 Then
                sZoomFactor = PaintOptions.CurrentRule.DesignProperties.GetValue("DesignTerrainLevelScaleFactor", oSurvey.Properties.DesignProperties.GetValue("DesignTerrainLevelScaleFactor", 1))
            Else
                sZoomFactor = sLocalZoomFactor
            End If
            Return sZoomFactor
        End Function

        Friend Function GetPaintLineWidth(PaintOptions As cOptions) As Single
            Dim sLineWidth As Single
            If sLocalLineWidth = 0 Then
                sLineWidth = PaintOptions.CurrentRule.DesignProperties.GetValue("BaseLineWidthScaleFactor", oSurvey.Properties.DesignProperties.GetValue("BaseLineWidthScaleFactor", 0.01))
            Else
                sLineWidth = sLocalLineWidth
            End If
            Return sLineWidth
        End Function

        Friend Function GetPaintPenWidth(PaintOptions As cOptions) As Single
            Dim sLineWidth As Single = GetPaintLineWidth(PaintOptions)
            Dim sPenWidth As Single = 0
            If sWidth < 0 Then
                sPenWidth = sWidth
            ElseIf sWidth = 0 Then
                sPenWidth = PaintOptions.GetPenDefaultWidth(iType) * sLineWidth
            Else
                sPenWidth = sWidth * sLineWidth
            End If
            Return sPenWidth
        End Function

        Private Sub pRender(PaintOptions As cOptions)
            Dim oRenderArgs As cRenderArgs = New cRenderArgs
            RaiseEvent OnRender(Me, oRenderArgs)

            Dim oPaintColor As Color = IIf(oAlternativeColor.IsEmpty, oColor, oAlternativeColor)
            oPaintColor = Color.FromArgb((1 - oRenderArgs.Transparency) * 255, oPaintColor)
            Dim sPenWidth As Single = GetPaintPenWidth(PaintOptions)
            oPen = New Pen(oPaintColor, sPenWidth)
            Call oPen.SetLineCap(Drawing2D.LineCap.Round, Drawing2D.LineCap.Round, Drawing2D.DashCap.Round)
            oPen.LineJoin = Drawing2D.LineJoin.Round
            Select Case iStyle
                Case PenStylesEnum.Solid
                    oPen.DashStyle = DashStyle.Solid
                Case PenStylesEnum.Dot
                    oPen.DashStyle = DashStyle.Dot
                Case PenStylesEnum.Dash
                    oPen.DashStyle = DashStyle.Dash
                Case PenStylesEnum.DashDot
                    oPen.DashStyle = DashStyle.DashDot

                Case PenStylesEnum.LargeDashLargeSpace
                    oPen.DashPattern = {6.0F, 6.0F}
                Case PenStylesEnum.LargeDashMediumSpace
                    oPen.DashPattern = {6.0F, 4.0F}
                Case PenStylesEnum.LargeDashSmallSpace
                    oPen.DashPattern = {6.0F, 2.0F}

                Case PenStylesEnum.Custom
                    oPen.DashPattern = sStylePattern
            End Select

            oBrush = New SolidBrush(oPaintColor)

            oPaintColor = IIf(oAlternativeColor.IsEmpty, Color.Black, oAlternativeColor)
            oWireframePen = New Pen(oPaintColor, -1 * sLineWidth)
            oWireframePen.SetLineCap(Drawing2D.LineCap.Round, Drawing2D.LineCap.Round, Drawing2D.DashCap.Round)
            oWireframePen.LineJoin = Drawing2D.LineJoin.Round
            oWireframePen.DashStyle = DashStyle.Dot

            bInvalidated = True
        End Sub

        Friend ReadOnly Property Pen As Pen
            Get
                Return oPen
            End Get
        End Property

        Friend ReadOnly Property WireframePen As Pen
            Get
                Return oWireframePen
            End Get
        End Property

        Friend ReadOnly Property Brush As Brush
            Get
                Return oBrush
            End Get
        End Property

        Friend Sub Render(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As Boolean, ByVal Path As GraphicsPath, ByVal Cache As cDrawCache)
            If bInvalidated Then pRender(PaintOptions)
            If Path.PointCount > 1 Then
                If iType = PenTypeEnum.None Then
                    Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, Path, Nothing, oWireframePen)
                Else
                    Dim sZoomFactor As Single = GetPaintZoomFactor(PaintOptions)
                    Select Case DecorationStyle
                        Case DecorationStylesEnum.None
                            Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, Path, oPen, oWireframePen)
                        Case DecorationStylesEnum.UpArrow
                            Using oPath As GraphicsPath = cClipartOnPath.ClipartOnPath(Graphics, Path.PathData, modPenClipart.ClipartArrowUp, iDecorationAlignment, sDecorationSpacePercentage * sZoomFactor, oColor, oColor, sDecorationScale * sZoomFactor)
                                If Not oPath Is Nothing Then
                                    Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oPath, oPen, Nothing, oBrush)
                                End If
                            End Using
                            Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, Path, oPen, oWireframePen)
                        Case DecorationStylesEnum.DownArrow
                            Using oPath As GraphicsPath = cClipartOnPath.ClipartOnPath(Graphics, Path.PathData, modPenClipart.ClipartArrowDown, iDecorationAlignment, sDecorationSpacePercentage * sZoomFactor, oColor, oColor, sDecorationScale * sZoomFactor)
                                If Not oPath Is Nothing Then
                                    Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oPath, oPen, Nothing, oBrush)
                                End If
                            End Using
                            Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, Path, oPen, oWireframePen)
                        Case DecorationStylesEnum.Dash
                            Using oPath As GraphicsPath = cClipartOnPath.ClipartOnPath(Graphics, Path.PathData, modPenClipart.ClipartDash, iDecorationAlignment, sDecorationSpacePercentage * sZoomFactor, oColor, oColor, sDecorationScale * sZoomFactor)
                                If Not oPath Is Nothing Then
                                    Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oPath, oPen, Nothing, oBrush)
                                End If
                            End Using
                            Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, Path, oPen, oWireframePen)
                        Case DecorationStylesEnum.Triangle
                            Using oPath As GraphicsPath = cClipartOnPath.ClipartOnPath(Graphics, Path.PathData, modPenClipart.ClipartTriangleUp, iDecorationAlignment, sDecorationSpacePercentage * sZoomFactor, oColor, oColor, sDecorationScale * sZoomFactor)
                                If Not oPath Is Nothing Then
                                    Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oPath, oPen, Nothing, oBrush)
                                End If
                            End Using
                            Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, Path, oPen, oWireframePen)
                        Case DecorationStylesEnum.DownTriangle
                            Using oPath As GraphicsPath = cClipartOnPath.ClipartOnPath(Graphics, Path.PathData, modPenClipart.ClipartTriangleDown, iDecorationAlignment, sDecorationSpacePercentage * sZoomFactor, oColor, oColor, sDecorationScale * sZoomFactor)
                                If Not oPath Is Nothing Then
                                    Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oPath, oPen, Nothing, oBrush)
                                End If
                            End Using
                            Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, Path, oPen, oWireframePen)
                        Case DecorationStylesEnum.UpTriangle
                            Using oPath As GraphicsPath = cClipartOnPath.ClipartOnPath(Graphics, Path.PathData, modPenClipart.ClipartTriangleUp, iDecorationAlignment, sDecorationSpacePercentage * sZoomFactor, oColor, oColor, sDecorationScale * sZoomFactor)
                                If Not oPath Is Nothing Then
                                    Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oPath, oPen, Nothing, oBrush)
                                End If
                            End Using
                            Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, Path, oPen, oWireframePen)
                        Case DecorationStylesEnum.Ice
                            Using oPath As GraphicsPath = cClipartOnPath.ClipartOnPath(Graphics, Path.PathData, modPenClipart.Ice, iDecorationAlignment, sDecorationSpacePercentage * sZoomFactor, oColor, oColor, sDecorationScale * sZoomFactor)
                                If Not oPath Is Nothing Then
                                    Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oPath, oPen, Nothing, Nothing)
                                End If
                            End Using
                            Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, Path, oPen, oWireframePen)
                        Case DecorationStylesEnum.EmptyDownTriangle
                            Using oPath As GraphicsPath = cClipartOnPath.ClipartOnPath(Graphics, Path.PathData, modPenClipart.ClipartTriangleDown, iDecorationAlignment, sDecorationSpacePercentage * sZoomFactor, oColor, oColor, sDecorationScale * sZoomFactor)
                                If Not oPath Is Nothing Then
                                    Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oPath, oPen, Nothing, Nothing)
                                End If
                            End Using
                            Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, Path, oPen, oWireframePen)
                        Case DecorationStylesEnum.EmptyUpTriangle
                            Using oPath As GraphicsPath = cClipartOnPath.ClipartOnPath(Graphics, Path.PathData, modPenClipart.ClipartTriangleUp, iDecorationAlignment, sDecorationSpacePercentage * sZoomFactor, oColor, oColor, sDecorationScale * sZoomFactor)
                                If Not oPath Is Nothing Then
                                    Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oPath, oPen, Nothing, Nothing)
                                End If
                            End Using
                            Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, Path, oPen, oWireframePen)
                        Case DecorationStylesEnum.Custom
                            Using oPath As GraphicsPath = cClipartOnPath.ClipartOnPath(Graphics, Path.PathData, oClipart, iDecorationAlignment, sDecorationSpacePercentage * sZoomFactor, oColor, oColor, sDecorationScale * sZoomFactor)
                                If Not oPath Is Nothing Then
                                    Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, oPath, oPen, Nothing, Nothing)
                                End If
                            End Using
                            Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, Path, Nothing, oWireframePen)
                    End Select
                End If
            End If
        End Sub

        Private Sub oSurvey_OnPropertiesChanged(ByVal Sender As cSurvey, ByVal Args As cSurvey.OnPropertiesChangedEventArgs) Handles oSurvey.OnPropertiesChanged
            Call Invalidate()
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    If Not oPen Is Nothing Then
                        Call oPen.Dispose()
                        oPen = Nothing
                    End If
                    If Not oWireframePen Is Nothing Then
                        Call oWireframePen.Dispose()
                        oWireframePen = Nothing
                    End If
                    If Not oBrush Is Nothing Then
                        Call oBrush.Dispose()
                        oBrush = Nothing
                    End If
                End If
            End If
            disposedValue = True
        End Sub

        ' Questo codice viene aggiunto da Visual Basic per implementare in modo corretto il criterio Disposable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Non modificare questo codice. Inserire sopra il codice di pulizia in Dispose(disposing As Boolean).
            Dispose(True)
        End Sub
#End Region
    End Class
End Namespace