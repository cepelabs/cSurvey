Imports cSurveyPC
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Drawings

Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports cSurveyPC.cSurvey.Design.cPen
Imports DevExpress.XtraTreeList.Nodes.Operations

Namespace cSurvey.Design

    Public Class cCustomPen
        Implements IDisposable

        Private WithEvents oSurvey As cSurvey

        Private sID As String

        Private sName As String
        Private iType As cPen.PenTypeEnum

        Private oColor As Color
        Private oAlternativeColor As Color
        Private sWidth As Single
        Private iStyle As cPen.PenStylesEnum
        Private sStylePattern As Single()
        Private iDecorationStyle As cPen.DecorationStylesEnum
        Private iDecorationPosition As cPen.DecorationPositionEnum
        Private iDecorationAlignment As cPen.DecorationAlignmentEnum
        Private sDecorationSpacePercentage As Single
        Private sDecorationScale As Single
        Private oClipart As cDrawClipArt
        Private iClipartPenMode As cPen.ClipartPenModeEnum
        Private sClipartPenWidth As Single
        Private iClipartPenStyle As cPen.PenStylesEnum
        Private sClipartStylePattern As Single()
        Private oClipartPenColor As Color

        Private oClipartPen As Pen
        Private oPen As Pen
        Private oBrush As SolidBrush
        Private oWireframePen As Pen

        Private sLocalLineWidth As Single
        Private sLocalZoomFactor As Single

        Private bInvalidated As Boolean

        Friend Event OnChanged(ByVal Sender As Object, e As EventArgs)

        Friend Event OnRender(sender As Object, RenderArgs As cPen.cRenderEventArgs)

        Public Function GetThumbnailSVG(ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal thumbWidth As Integer, ByVal thumbHeight As Integer, ByVal ForeColor As Color, ByVal Backcolor As Color) As XmlDocument
            Dim oBounds As RectangleF = New RectangleF(0, 0, thumbWidth, thumbHeight)
            Dim oSVG As XmlDocument = modSVG.CreateSVG("", New Size(thumbWidth, thumbHeight), SizeUnit.pixel, oBounds, SVGCreateFlagsEnum.None)
            Using oImage As Image = New Bitmap(thumbWidth, thumbHeight)
                Using oGr As Graphics = Graphics.FromImage(oImage)
                    Using oPath As GraphicsPath = New GraphicsPath
                        Dim oP0 As PointF = New PointF(oBounds.Left, oBounds.Top + oBounds.Height / 2)
                        Dim oP1 As PointF = New PointF(oBounds.Right, oBounds.Top + oBounds.Height / 2)
                        Call oPath.AddLine(oP0, oP1)
                        Using oCache As cDrawCache = New cDrawCache
                            Dim sBackupLocalZoomFactor As Single = sLocalZoomFactor
                            sLocalZoomFactor = 6
                            bInvalidated = True
                            Call Render(oGr, PaintOptions, cItem.PaintOptionsEnum.None, False, oPath, oCache)
                            sLocalZoomFactor = sBackupLocalZoomFactor
                            bInvalidated = True

                            Call oCache.Paint(oGr, PaintOptions, cItem.PaintOptionsEnum.None)

                            Dim oBoxBounds As RectangleF = New RectangleF(0, 0, thumbWidth - 0.5F, thumbHeight - 0.5F)

                            Using oBackgroundBrush As SolidBrush = New SolidBrush(Backcolor)
                                Using oForegroundPen As Pen = New Pen(ForeColor, 2)
                                    oForegroundPen.LineJoin = LineJoin.Miter
                                    Call modSVG.AppendRectangle(oSVG, oSVG.DocumentElement, oBounds, oBackgroundBrush, Nothing)
                                    Call oSVG.DocumentElement.AppendChild(oCache.ToSvgItem(oSVG, PaintOptions, cItem.SVGOptionsEnum.ClipartBrushes))
                                    If iType = cPen.PenTypeEnum.User Then
                                        Using oForegroundBrush As SolidBrush = New SolidBrush(Color.FromArgb(120, ForeColor))
                                            Call modSVG.AppendPolygon(oSVG, oSVG.DocumentElement, {New PointF(0, 0), New PointF(thumbWidth / 4.0F, 0), New PointF(0, thumbHeight / 4.0F)}, oForegroundBrush, Nothing)
                                        End Using
                                    End If
                                    Call modSVG.AppendRectangle(oSVG, oSVG.DocumentElement, oBoxBounds, Nothing, oForegroundPen)
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End Using
            Return oSVG
        End Function

        Public Function GetThumbnailImage(ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal thumbWidth As Integer, ByVal thumbHeight As Integer) As Image
            Return GetThumbnailImage(PaintOptions, Options, Selected, thumbHeight, thumbHeight, Color.Black, Color.White)
        End Function

        Public Function GetThumbnailImage(ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal thumbWidth As Integer, ByVal thumbHeight As Integer, ByVal ForeColor As Color, ByVal Backcolor As Color) As Image
            Try
                Dim oBounds As RectangleF = New RectangleF(0, 0, thumbWidth, thumbHeight)
                Dim oImage As Image = New Bitmap(thumbWidth, thumbHeight)
                Using oGr As Graphics = Graphics.FromImage(oImage)
                    oGr.SmoothingMode = SmoothingMode.AntiAlias
                    oGr.CompositingQuality = CompositingQuality.HighQuality
                    oGr.InterpolationMode = InterpolationMode.HighQualityBicubic
                    Call oGr.Clear(Backcolor)
                    Using oPath As GraphicsPath = New GraphicsPath
                        Dim oP0 As PointF = New PointF(oBounds.Left + 1, oBounds.Top + oBounds.Height / 2)
                        Dim oP1 As PointF = New PointF(oBounds.Right - 1, oBounds.Top + oBounds.Height / 2)
                        Call oPath.AddLine(oP0, oP1)
                        Using oCache As cDrawCache = New cDrawCache
                            Call Render(oGr, PaintOptions, cItem.PaintOptionsEnum.None, False, oPath, oCache)
                            Call oCache.Paint(oGr, PaintOptions, cItem.PaintOptionsEnum.None)
                        End Using
                    End Using
                End Using
                Return oImage
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Friend ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public Property ID As String
            Get
                If iType = cPen.PenTypeEnum.User Then
                    Return sID
                Else
                    Return "_" & iType.ToString("D")
                End If
            End Get
            Set(value As String)
                If value Is Nothing Then
                    Throw New Exception("Pen ID cannot be Nothing")
                Else
                    If value.StartsWith("_") Then
                        Dim iType As cPen.PenTypeEnum = Integer.Parse(value.Substring(1))
                        sID = ""
                        CopyFrom(oSurvey.Pens.FromType(iType))
                    Else
                        CopyFrom(oSurvey.Pens(value))
                    End If
                End If
            End Set
        End Property

        Friend Sub CopyFrom(ByVal Pen As cCustomPen)
            If iType <> cPen.PenTypeEnum.User Then iType = Pen.iType
            If Pen.iType = cPen.PenTypeEnum.User Then
                sID = Pen.sID
            Else
                sID = ""
            End If

            sName = Pen.sName
            oColor = Pen.oColor
            sWidth = Pen.sWidth
            iStyle = Pen.iStyle
            sStylePattern = Pen.sStylePattern
            If IsNothing(Pen.Clipart) Then
                oClipart = Nothing
            Else
                oClipart = Pen.oClipart.Clone
            End If
            iDecorationAlignment = Pen.iDecorationAlignment
            iDecorationPosition = Pen.iDecorationPosition
            iDecorationStyle = Pen.iDecorationStyle
            sDecorationSpacePercentage = Pen.sDecorationSpacePercentage
            sDecorationScale = Pen.sDecorationScale
            sLocalLineWidth = Pen.sLocalLineWidth

            iClipartPenMode = Pen.iClipartPenMode
            iClipartPenStyle = Pen.iClipartPenStyle
            sClipartStylePattern = Pen.sClipartStylePattern
            sClipartPenWidth = Pen.sClipartPenWidth
            oClipartPenColor = Pen.oClipartPenColor

            If iType = cPen.PenTypeEnum.User Then
                If sID Is Nothing OrElse sID = "" Then
                    sID = cCustomPen.CalculateHash(Me)
                Else
                    sID = ID
                End If
            End If

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
                    'If iType <> cPen.PenTypeEnum.Custom Then
                    '    Call CopyFrom(oSurvey.Pens.FromID(ID))
                    '    iType = cPen.PenTypeEnum.Custom
                    'End If
                    sName = value
                End If
            End Set
        End Property

        Public Shared Function CalculateHash(Pen As cCustomPen) As String
            Using oMs As MemoryStream = New MemoryStream
                Using oFile As cFile = New cFile(cFile.FileFormatEnum.CSX, "", cFile.FileOptionsEnum.EmbedResource)
                    Dim oXML As XmlDocument = oFile.Document
                    Dim oXMLRoot As XmlElement = oXML.CreateElement("cpen")
                    Dim oXMLItem As XmlElement = Pen.SaveTo(oFile, oXML, oXMLRoot)
                    'hash is calculate without name and type
                    Call oXMLItem.RemoveAttribute("type")
                    Call oXMLItem.RemoveAttribute("name")
                    Call oXMLRoot.AppendChild(oXMLItem)
                    Call oXML.AppendChild(oXMLRoot)
                    Call oFile.SaveTo(oMs)
                    Return modMain.CalculateHash(oMs)
                End Using
            End Using
        End Function

        Public ReadOnly Property Type() As cPen.PenTypeEnum
            Get
                Return iType
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Type As cPen.PenTypeEnum)
            oSurvey = Survey
            Call CopyFrom(Survey.Pens.FromType(iType))
            bInvalidated = True
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Pen As cPen)
            oSurvey = Survey
            Call CopyFrom(Pen.GetBasePen)
            bInvalidated = True
        End Sub

        Friend Shared Function CopyAsCustom(Survey As cSurvey, ByVal Pen As cCustomPen) As cCustomPen
            Dim oNewPen As cCustomPen = New cCustomPen(Survey, Pen)
            oNewPen.iType = cPen.PenTypeEnum.Custom
            oNewPen.sID = ""
            Return oNewPen
        End Function

        Friend Shared Function CopyAsUser(Survey As cSurvey, ByVal Pen As cCustomPen) As cCustomPen
            Dim oNewPen As cCustomPen = New cCustomPen(Survey, Pen)
            oNewPen.iType = cPen.PenTypeEnum.User
            oNewPen.sID = CalculateHash(oNewPen)
            Return oNewPen
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Pen As cCustomPen)
            oSurvey = Survey
            Call CopyFrom(Pen)
            bInvalidated = True
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Type As cPen.PenTypeEnum, ID As String, ByVal Name As String, ByVal Color As Color, Optional ByVal Width As Single = 1, Optional ByVal Style As cPen.PenStylesEnum = cPen.PenStylesEnum.Solid, Optional Clipart As cDrawClipArt = Nothing, Optional ByVal DecorationStyle As cPen.DecorationStylesEnum = cPen.DecorationStylesEnum.None, Optional ByVal DecorationSpacePercentage As Single = 100, Optional ByVal DecorationAlignment As cPen.DecorationAlignmentEnum = cPen.DecorationStylesEnum.None, Optional ByVal DecorationScale As Single = 1, Optional StylePattern As Single() = Nothing)
            oSurvey = Survey
            sName = Name
            iType = Type
            oColor = Color
            sWidth = Width
            iStyle = Style
            If iStyle = cPen.PenStylesEnum.Custom Then
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
            iDecorationPosition = DecorationPosition
            sDecorationScale = DecorationScale
            iClipartPenMode = cPen.ClipartPenModeEnum.AsParent
            oClipartPenColor = Color.Black

            If iType = cPen.PenTypeEnum.User Then
                If ID Is Nothing OrElse ID = "" Then
                    sID = cCustomPen.CalculateHash(Me)
                Else
                    sID = ID
                End If
            End If

            bInvalidated = True
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            iType = cPen.PenTypeEnum.Custom
            oColor = Color.Black
            sWidth = 1
            sDecorationSpacePercentage = 100
            sDecorationScale = 1
            iClipartPenMode = cPen.ClipartPenModeEnum.AsParent
            oClipartPenColor = Color.Black
            bInvalidated = True
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal item As XmlElement)
            oSurvey = Survey
            iType = modXML.GetAttributeValue(item, "type", cPen.PenTypeEnum.Custom)
            If iType = cPen.PenTypeEnum.User Then
                sID = item.GetAttribute("id")
            End If

            sName = modXML.GetAttributeValue(item, "name", "")
            oColor = modXML.GetAttributeColor(item, "color", Color.Black)
            iStyle = modXML.GetAttributeValue(item, "style")
            If iStyle = cPen.PenStylesEnum.Custom Then
                sStylePattern = modPaint.StringToPenStylePattern(modXML.GetAttributeValue(item, "stylepattern"))
            End If
            sWidth = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "width"))
            Dim oXMLClipart As XmlElement = item.Item("clipart")
            If oXMLClipart Is Nothing Then
                oClipart = New cDrawClipArt()
            Else
                oClipart = New cDrawClipArt(oXMLClipart)
            End If
            iDecorationStyle = modXML.GetAttributeValue(item, "decorationstyle")
            sDecorationSpacePercentage = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "decorationspacepercentage"))
            If sDecorationSpacePercentage = 0 Then sDecorationSpacePercentage = 100
            iDecorationAlignment = modXML.GetAttributeValue(item, "decorationalignment")
            iDecorationPosition = modXML.GetAttributeValue(item, "decorationposition")
            sDecorationScale = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "decorationscale"))
            If sDecorationScale = 0F Then sDecorationScale = 1.0F

            iClipartPenMode = modXML.GetAttributeValue(item, "clipartpenmode", cPen.ClipartPenModeEnum.AsParent)
            If iClipartPenMode = cPen.ClipartPenModeEnum.Custom Then
                sClipartPenWidth = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "clipartpenwidth"))
                iClipartPenStyle = modXML.GetAttributeValue(item, "clipartpenstyle")
                If iClipartPenStyle = cPen.PenStylesEnum.Custom Then
                    sClipartStylePattern = modPaint.StringToPenStylePattern(modXML.GetAttributeValue(item, "clipartstylepattern"))
                End If
                oClipartPenColor = modXML.GetAttributeColor(item, "clipartpencolor", Color.Black)
            Else
                oClipartPenColor = Color.Black
            End If

            Call Invalidate()
        End Sub

        Public Property Clipart() As cDrawClipArt
            Get
                Return oClipart
            End Get
            Set(ByVal Value As cDrawClipArt)
                If Not oClipart Is Value Then
                    oClipart = Value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public ReadOnly Property IsWriteable As Boolean
            Get
                Return iType = cPen.PenTypeEnum.User OrElse iType = cPen.PenTypeEnum.Custom
            End Get
        End Property

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oItem As XmlElement = Document.CreateElement("pen")
            Call oItem.SetAttribute("type", iType)
            If iType = cPen.PenTypeEnum.User Then
                Call oItem.SetAttribute("id", sID)
            End If

            If sName <> "" Then
                Call oItem.SetAttribute("name", sName)
            End If
            Call oItem.SetAttribute("color", oColor.ToArgb)
            Call oItem.SetAttribute("style", iStyle.ToString("D"))
            If iStyle = cPen.PenStylesEnum.Custom Then
                Call oItem.SetAttribute("stylepattern", modPaint.PenStylePatternToString(sStylePattern))
            End If
            Call oItem.SetAttribute("width", modNumbers.NumberToString(sWidth, "0.00"))
            If Not oClipart Is Nothing Then Call oClipart.SaveTo(File, Document, oItem)
            Call oItem.SetAttribute("decorationstyle", iDecorationStyle.ToString("D"))
            Call oItem.SetAttribute("decorationspacepercentage", modNumbers.NumberToString(sDecorationSpacePercentage, "0.0"))
            Call oItem.SetAttribute("decorationalignment", iDecorationAlignment.ToString("D"))
            If iDecorationPosition <> cPen.DecorationPositionEnum.Behind Then Call oItem.SetAttribute("decorationposition", iDecorationPosition.ToString("D"))
            Call oItem.SetAttribute("decorationscale", modNumbers.NumberToString(sDecorationScale, "0.00"))

            If iClipartPenMode = cPen.ClipartPenModeEnum.Custom Then
                Call oItem.SetAttribute("clipartpenmode", iClipartPenMode.ToString("D"))
                Call oItem.SetAttribute("clipartpenwidth", modNumbers.NumberToString(sClipartPenWidth, "0.00"))
                Call oItem.SetAttribute("clipartpenstyle", iClipartPenStyle.ToString("D"))
                If iClipartPenStyle = cPen.PenStylesEnum.Custom Then
                    Call oItem.SetAttribute("clipartstylepattern", modPaint.PenStylePatternToString(sClipartStylePattern))
                End If
                Call oItem.SetAttribute("clipartpencolor", oClipartPenColor.ToArgb)
            End If

            Call Parent.AppendChild(oItem)
            Return oItem
        End Function

        Public Property ClipartPenMode() As cPen.ClipartPenModeEnum
            Get
                Return iClipartPenMode
            End Get
            Set(value As cPen.ClipartPenModeEnum)
                If iClipartPenMode <> value Then
                    iClipartPenMode = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartPenStyle() As cPen.PenStylesEnum
            Get
                Return iClipartPenStyle
            End Get
            Set(value As cPen.PenStylesEnum)
                If iClipartPenStyle <> value Then
                    iClipartPenStyle = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartPenWidth() As Single
            Get
                Return sClipartPenWidth
            End Get
            Set(value As Single)
                If sClipartPenWidth <> value Then
                    sClipartPenWidth = value
                    Call Invalidate()
                End If
            End Set
        End Property
        Public Property Width() As Single
            Get
                Return sWidth
            End Get
            Set(ByVal value As Single)
                If sWidth <> value Then
                    sWidth = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property Style() As cPen.PenStylesEnum
            Get
                Return iStyle
            End Get
            Set(ByVal value As cPen.PenStylesEnum)
                If iStyle <> value Then
                    iStyle = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartPenColor() As Color
            Get
                Return oClipartPenColor
            End Get
            Set(ByVal value As Color)
                If oClipartPenColor <> value Then
                    oClipartPenColor = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property Color() As Color
            Get
                Return oColor
            End Get
            Set(ByVal value As Color)
                If oColor <> value Then
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
                If oAlternativeColor <> value Then
                    oAlternativeColor = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property DecorationStyle() As cPen.DecorationStylesEnum
            Get
                Return iDecorationStyle
            End Get
            Set(ByVal value As cPen.DecorationStylesEnum)
                If iDecorationStyle <> value Then
                    iDecorationStyle = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property DecorationPosition() As cPen.DecorationPositionEnum
            Get
                Return iDecorationPosition
            End Get
            Set(value As cPen.DecorationPositionEnum)
                If iDecorationPosition <> value Then
                    iDecorationPosition = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property DecorationAlignment() As cPen.DecorationAlignmentEnum
            Get
                Return iDecorationAlignment
            End Get
            Set(ByVal value As cPen.DecorationAlignmentEnum)
                If iDecorationAlignment <> value Then
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
                    sDecorationScale = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Friend ReadOnly Property Invalidated As Boolean
            Get
                Return bInvalidated
            End Get
        End Property

        Friend Sub Invalidate()
            bInvalidated = True
            RaiseEvent OnChanged(Me, EventArgs.Empty)
        End Sub

        Friend Function GetPaintZoomFactor(PaintOptions As cOptionsCenterline) As Single
            Dim sZoomFactor As Single
            If sLocalZoomFactor = 0 Then
                sZoomFactor = PaintOptions.GetCurrentDesignPropertiesValue("DesignTerrainLevelScaleFactor", 1)
            Else
                sZoomFactor = sLocalZoomFactor
            End If
            Return sZoomFactor
        End Function

        Friend Function GetPaintLineWidth(PaintOptions As cOptionsCenterline) As Single
            Dim sLineWidth As Single
            If sLocalLineWidth = 0 Then
                sLineWidth = PaintOptions.GetCurrentDesignPropertiesValue("BaseLineWidthScaleFactor", 0.01) * GetPaintZoomFactor(PaintOptions)
            Else
                sLineWidth = sLocalLineWidth * GetPaintZoomFactor(PaintOptions)
            End If
            Return sLineWidth
        End Function

        Friend Function GetPaintPenWidth(PaintOptions As cOptionsCenterline, BaseWidth As Single) As Single
            Dim sLineWidth As Single = GetPaintLineWidth(PaintOptions)
            Dim sPenWidth As Single = 0
            '20211014: due to a fix from microsoft pens with width <=1 are correctly scaled, before this fix pens with width<=1 or negative are not scaled
            If BaseWidth < 0 Then
                sPenWidth = BaseWidth
            ElseIf BaseWidth = 0 Then
                sPenWidth = PaintOptions.GetPenDefaultWidth(iType) * sLineWidth
            Else
                sPenWidth = BaseWidth * sLineWidth
            End If
            Return sPenWidth
        End Function

        Private Sub pRender(PaintOptions As cOptionsCenterline)
            'Dim oRenderArgs As cPen.cRenderArgs = New cPen.cRenderArgs
            'RaiseEvent OnRender(Me, oRenderArgs)

            Dim oTempPenColor As Color = If(oAlternativeColor.IsEmpty, oColor, oAlternativeColor)
            'oTempPenColor = Color.FromArgb((1 - oRenderArgs.Transparency) * 255, oTempPenColor)

            If iStyle = cPen.PenStylesEnum.None Then
                If oPen IsNot Nothing Then oPen.Dispose()
                oPen = Nothing
            Else
                Dim sTempPenWidth As Single = GetPaintPenWidth(PaintOptions, sWidth)
                oPen = New Pen(oTempPenColor, sTempPenWidth)
                Call oPen.SetLineCap(Drawing2D.LineCap.Round, Drawing2D.LineCap.Round, Drawing2D.DashCap.Round)
                oPen.LineJoin = Drawing2D.LineJoin.Round
                Select Case iStyle
                    Case cPen.PenStylesEnum.Solid
                        oPen.DashStyle = DashStyle.Solid
                    Case cPen.PenStylesEnum.Dot
                        oPen.DashStyle = DashStyle.Dot
                    Case cPen.PenStylesEnum.Dash
                        oPen.DashStyle = DashStyle.Dash
                    Case cPen.PenStylesEnum.DashDot
                        oPen.DashStyle = DashStyle.DashDot

                    Case cPen.PenStylesEnum.LargeDashLargeSpace
                        oPen.DashPattern = {6.0F, 6.0F}
                    Case cPen.PenStylesEnum.LargeDashMediumSpace
                        oPen.DashPattern = {6.0F, 4.0F}
                    Case cPen.PenStylesEnum.LargeDashSmallSpace
                        oPen.DashPattern = {6.0F, 2.0F}

                    Case cPen.PenStylesEnum.Custom
                        oPen.DashPattern = sStylePattern
                End Select
            End If

            If iClipartPenMode = cPen.ClipartPenModeEnum.Custom Then
                Dim oTempClipartPenColor As Color = If(oAlternativeColor.IsEmpty, oClipartPenColor, oAlternativeColor)
                'oTempClipartPenColor = Color.FromArgb((1 - oRenderArgs.Transparency) * 255, oTempClipartPenColor)
                If iClipartPenStyle <> cPen.PenStylesEnum.None Then
                    Dim sTempClipartPenWidth As Single = GetPaintPenWidth(PaintOptions, sClipartPenWidth)
                    oClipartPen = New Pen(oTempClipartPenColor, sTempClipartPenWidth)
                    Call oClipartPen.SetLineCap(Drawing2D.LineCap.Round, Drawing2D.LineCap.Round, Drawing2D.DashCap.Round)
                    oClipartPen.LineJoin = Drawing2D.LineJoin.Round
                    Select Case iClipartPenStyle
                        Case cPen.PenStylesEnum.Solid
                            oClipartPen.DashStyle = DashStyle.Solid
                        Case cPen.PenStylesEnum.Dot
                            oClipartPen.DashStyle = DashStyle.Dot
                        Case cPen.PenStylesEnum.Dash
                            oClipartPen.DashStyle = DashStyle.Dash
                        Case cPen.PenStylesEnum.DashDot
                            oClipartPen.DashStyle = DashStyle.DashDot

                        Case cPen.PenStylesEnum.LargeDashLargeSpace
                            oClipartPen.DashPattern = {6.0F, 6.0F}
                        Case cPen.PenStylesEnum.LargeDashMediumSpace
                            oClipartPen.DashPattern = {6.0F, 4.0F}
                        Case cPen.PenStylesEnum.LargeDashSmallSpace
                            oClipartPen.DashPattern = {6.0F, 2.0F}

                        Case cPen.PenStylesEnum.Custom
                            oClipartPen.DashPattern = sStylePattern
                    End Select
                End If
                'TODO: custom clipart brush
            Else
                If oPen Is Nothing Then
                    oClipartPen = Nothing
                Else
                    oClipartPen = oPen.Clone
                End If
            End If

            'TODO: see above
            oBrush = New SolidBrush(oTempPenColor)

            Dim oWireframePenColor As Color = If(oAlternativeColor.IsEmpty, Color.Black, oAlternativeColor)
            oWireframePen = New Pen(oWireframePenColor, cEditPaintObjects.FilettoPenWidth)
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

        Friend Sub Render(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As Boolean, ByVal Path As GraphicsPath, ByVal Cache As cDrawCache)
            If bInvalidated Then pRender(PaintOptions)
            If Path.PointCount > 1 Then
                If iType = cPen.PenTypeEnum.None Then
                    Call Cache.AddBorder(Path, Nothing, oWireframePen)
                Else
                    Dim oRenderArgs As cPen.cRenderEventArgs = New cPen.cRenderEventArgs
                    RaiseEvent OnRender(Me, oRenderArgs)

                    Dim oBackupColors(1) As Color
                    If oRenderArgs.Transparency <> 0 Then
                        oBackupColors(0) = oPen.Color
                        oPen.Color = Color.FromArgb((1 - oRenderArgs.Transparency) * 255, oPen.Color)
                        oBackupColors(1) = oBrush.Color
                        oBrush.Color = Color.FromArgb((1 - oRenderArgs.Transparency) * 255, oBrush.Color)
                    End If

                    Dim sZoomFactor As Single = GetPaintZoomFactor(PaintOptions)
                    If iDecorationPosition = cPen.DecorationPositionEnum.Above Then
                        Call Cache.AddBorder(Path, oPen, oWireframePen)
                    End If
                    If DecorationStyle <> cPen.DecorationStylesEnum.None Then
                        Dim oTmpClipart As cDrawClipArt
                        Dim bUsePen As Boolean = True
                        Dim bUseBrush As Boolean = True
                        Select Case DecorationStyle
                            Case cPen.DecorationStylesEnum.UpArrow
                                oTmpClipart = modPenClipart.ClipartArrowUp
                            Case cPen.DecorationStylesEnum.DownArrow
                                oTmpClipart = modPenClipart.ClipartArrowDown
                            Case cPen.DecorationStylesEnum.Dash
                                oTmpClipart = modPenClipart.ClipartDash
                                bUseBrush = False
                            Case cPen.DecorationStylesEnum.Triangle
                                oTmpClipart = modPenClipart.ClipartTriangleUp
                            Case cPen.DecorationStylesEnum.DownTriangle
                                oTmpClipart = modPenClipart.ClipartTriangleDown
                            Case cPen.DecorationStylesEnum.UpTriangle
                                oTmpClipart = modPenClipart.ClipartTriangleUp
                            Case cPen.DecorationStylesEnum.Ice
                                oTmpClipart = modPenClipart.Ice
                                bUseBrush = False
                            Case cPen.DecorationStylesEnum.EmptyDownTriangle
                                oTmpClipart = modPenClipart.ClipartTriangleDown
                                bUseBrush = False
                            Case cPen.DecorationStylesEnum.EmptyUpTriangle
                                oTmpClipart = modPenClipart.ClipartTriangleUp
                                bUseBrush = False
                            Case Else
                                oTmpClipart = oClipart
                        End Select
                        Using oPath As GraphicsPath = cClipartOnPath.ClipartOnPath(Graphics, Path.PathData, oTmpClipart, iDecorationAlignment, sDecorationSpacePercentage, oColor, oColor, sDecorationScale * sZoomFactor)
                            If Not oPath Is Nothing Then
                                Call Cache.AddBorder(oPath, If(bUsePen, oClipartPen, Nothing), Nothing, If(bUseBrush, oBrush, Nothing))
                            End If
                        End Using
                    End If
                    If iDecorationPosition = cPen.DecorationPositionEnum.Behind Then
                        Call Cache.AddBorder(Path, oPen, oWireframePen)
                    End If

                    If oRenderArgs.Transparency <> 0 Then
                        oPen.Color = oBackupColors(0)
                        oBrush.Color = oBackupColors(1)
                    End If
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
                    If Not oClipartPen Is Nothing Then
                        Call oClipartPen.Dispose()
                        oClipartPen = Nothing
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

    Public Interface cIPen

    End Interface

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

            User = 98
            Custom = 99
        End Enum

        Public Enum ClipartPenModeEnum
            AsParent = 0
            Custom = 1
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

        Public Enum DecorationPositionEnum
            Behind = 0
            Above = 1
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

        Friend Event OnChanged(ByVal Sender As Object, e As EventArgs)

        Private WithEvents oBasePen As cCustomPen

        Friend Class cRenderEventArgs
            Inherits EventArgs
            Public Transparency As Single
        End Class
        Friend Event OnRender(sender As Object, RenderArgs As cRenderEventArgs)

        Public Function GetThumbnailSVG(ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal thumbWidth As Integer, ByVal thumbHeight As Integer, ByVal ForeColor As Color, ByVal Backcolor As Color) As XmlDocument
            Return oBasePen.GetThumbnailSVG(PaintOptions, Options, cItem.SelectionModeEnum.Selected, thumbWidth, thumbHeight, ForeColor, Backcolor)
        End Function

        Public Function GetThumbnailImage(ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal thumbWidth As Integer, ByVal thumbHeight As Integer) As Image
            Return GetThumbnailImage(PaintOptions, Options, Selected, thumbHeight, thumbHeight, Color.Black, Color.White)
        End Function

        Public Function GetThumbnailImage(ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal thumbWidth As Integer, ByVal thumbHeight As Integer, ByVal ForeColor As Color, ByVal Backcolor As Color) As Image
            Return oBasePen.GetThumbnailImage(PaintOptions, Options, Selected, thumbWidth, thumbHeight)
        End Function

        Friend ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public Property ID As String
            Get
                Return oBasePen.ID
            End Get
            Set(value As String)
                If value <> oBasePen.ID Then
                    If value Is Nothing OrElse value = "" Then
                        Throw New Exception("Pen ID cannot be nothing or empty string")
                    Else
                        If value.StartsWith("_") Then
                            Dim iType As cPen.PenTypeEnum = Integer.Parse(value.Substring(1))
                            If iType = PenTypeEnum.Custom Then
                                oBasePen = cCustomPen.CopyAsCustom(oSurvey, oBasePen)
                                Call Invalidate()
                            ElseIf iType = PenTypeEnum.User Then
                                Throw New Exception("Pen type cannot be directly set to user")
                            Else
                                oBasePen = oSurvey.Pens.FromType(iType)
                                Call Invalidate()
                            End If
                        Else
                            oBasePen = oSurvey.Pens.FromID(value)
                            Call Invalidate()
                        End If
                    End If
                End If
            End Set
        End Property

        Public Sub CopyFrom(ByVal Pen As cPen)
            oBasePen = Pen.oBasePen
            Call Invalidate()
        End Sub

        Friend Function GetBasePen() As cCustomPen
            Return oBasePen
        End Function

        Public ReadOnly Property Name() As String
            Get
                Return oBasePen.Name
            End Get
        End Property

        Public Shared Function IsUserPenID(ID As String) As Boolean
            If ID Is Nothing OrElse ID = "" Then
                Return False
            Else
                Return Not ID.StartsWith("_")
            End If
        End Function

        Public Shared Function IsStandardPenID(ID As String) As Boolean
            If ID Is Nothing OrElse ID = "" Then
                Return False
            Else
                Return ID.StartsWith("_")
            End If
        End Function

        Public Shared Function CalculateHash(Pen As cPen) As String
            Using oMs As MemoryStream = New MemoryStream
                Using oFile As cFile = New cFile(cFile.FileFormatEnum.CSX, "", cFile.FileOptionsEnum.EmbedResource)
                    Dim oXML As XmlDocument = oFile.Document
                    Dim oXMLRoot As XmlElement = oXML.CreateElement("cpen")
                    Dim oXMLItem As XmlElement = Pen.GetBasePen.SaveTo(oFile, oXML, oXMLRoot)
                    'hash is calculate without name and type
                    Call oXMLItem.RemoveAttribute("type")
                    Call oXMLItem.RemoveAttribute("name")
                    Call oXML.AppendChild(oXMLRoot)
                    Call oFile.SaveTo(oMs)
                    Return modMain.CalculateHash(oMs)
                End Using
            End Using
        End Function

        Public Property Type() As PenTypeEnum
            Get
                Return oBasePen.Type
            End Get
            Set(value As PenTypeEnum)
                If value <> Type Then
                    If value = PenTypeEnum.User Then
                        'user pen cannot be created changing type
                        Throw New Exception("Pen type cannot be directly set to user")
                    Else
                        If value = PenTypeEnum.Custom Then
                            'create a custom copy of the current pen 
                            oBasePen = cCustomPen.CopyAsCustom(oSurvey, oBasePen)
                        Else
                            oBasePen = oSurvey.Pens.FromType(value)
                        End If
                    End If
                End If
            End Set
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Pen As cPen)
            oSurvey = Survey
            Call CopyFrom(Pen)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oBasePen = New cCustomPen(Survey)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal item As XmlElement)
            oSurvey = Survey
            Dim iType As PenTypeEnum = item.GetAttribute("type")
            If iType = PenTypeEnum.Custom Then
                'custom pen are saved in line
                oBasePen = New cCustomPen(oSurvey, item)
            Else
                If iType = PenTypeEnum.User Then
                    'user pen are saved in pens collection
                    Dim sID As String = item.GetAttribute("id")
                    oBasePen = oSurvey.Pens.FromID(sID)
                Else
                    oBasePen = oSurvey.Pens.FromType(iType)
                End If
            End If
        End Sub

        Public Property Clipart() As cDrawClipArt
            Get
                Return oBasePen.Clipart
            End Get
            Set(value As cDrawClipArt)
                If oBasePen.IsWriteable Then
                    oBasePen.Clipart = value
                End If
            End Set
        End Property

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            If oBasePen.Type = cPen.PenTypeEnum.Custom Then
                Return oBasePen.SaveTo(File, Document, Parent)
            Else
                Dim oItem As XmlElement = Document.CreateElement("pen")
                Call oItem.SetAttribute("type", oBasePen.Type)
                If oBasePen.Type = cPen.PenTypeEnum.User Then
                    Call oItem.SetAttribute("id", oBasePen.ID)
                End If
                Parent.AppendChild(oItem)
                Return oItem
            End If
        End Function
        Public Property ClipartPenMode() As cPen.ClipartPenModeEnum
            Get
                Return oBasePen.ClipartPenMode
            End Get
            Set(value As cPen.ClipartPenModeEnum)
                If oBasePen.IsWriteable Then
                    oBasePen.ClipartPenMode = value
                End If
            End Set
        End Property

        Public Property ClipartPenStyle() As cPen.PenStylesEnum
            Get
                Return oBasePen.ClipartPenStyle
            End Get
            Set(value As cPen.PenStylesEnum)
                If oBasePen.IsWriteable Then
                    oBasePen.ClipartPenStyle = value
                End If
            End Set
        End Property

        Public Property ClipartPenWidth() As Single
            Get
                Return oBasePen.ClipartPenWidth
            End Get
            Set(value As Single)
                If oBasePen.IsWriteable Then
                    oBasePen.ClipartPenWidth = value
                End If
            End Set
        End Property

        Public Property Width() As Single
            Get
                Return oBasePen.Width
            End Get
            Set(value As Single)
                If oBasePen.IsWriteable Then
                    oBasePen.Width = value
                End If
            End Set
        End Property

        Public Property Style() As PenStylesEnum
            Get
                Return oBasePen.Style
            End Get
            Set(value As PenStylesEnum)
                If oBasePen.IsWriteable Then
                    oBasePen.Style = value
                End If
            End Set
        End Property

        Public Property ClipartPenColor() As Color
            Get
                Return oBasePen.ClipartPenColor
            End Get
            Set(ByVal value As Color)
                If oBasePen.IsWriteable Then
                    oBasePen.ClipartPenColor = value
                End If
            End Set
        End Property
        Public Property Color() As Color
            Get
                Return oBasePen.Color
            End Get
            Set(value As Color)
                If oBasePen.IsWriteable Then
                    oBasePen.Color = value
                End If
            End Set
        End Property

        Public Property AlternativeColor() As Color
            Get
                Return oBasePen.AlternativeColor
            End Get
            Set(value As Color)
                If oBasePen.IsWriteable Then
                    oBasePen.AlternativeColor = value
                End If
            End Set
        End Property

        Public Property DecorationStyle() As DecorationStylesEnum
            Get
                Return oBasePen.DecorationStyle
            End Get
            Set(value As DecorationStylesEnum)
                If oBasePen.IsWriteable Then
                    oBasePen.DecorationStyle = value
                End If
            End Set
        End Property
        Public Property DecorationPosition() As DecorationPositionEnum
            Get
                Return oBasePen.DecorationPosition
            End Get
            Set(value As DecorationPositionEnum)
                If oBasePen.IsWriteable Then
                    oBasePen.DecorationPosition = value
                End If
            End Set
        End Property

        Public Property DecorationAlignment() As DecorationAlignmentEnum
            Get
                Return oBasePen.DecorationAlignment
            End Get
            Set(value As DecorationAlignmentEnum)
                If oBasePen.IsWriteable Then
                    oBasePen.DecorationAlignment = value
                End If
            End Set
        End Property

        Public Property DecorationSpacePercentage() As Single
            Get
                Return oBasePen.DecorationSpacePercentage
            End Get
            Set(value As Single)
                If oBasePen.IsWriteable Then
                    oBasePen.DecorationSpacePercentage = value
                End If
            End Set
        End Property

        Public Property DecorationScale() As Single
            Get
                Return oBasePen.DecorationScale
            End Get
            Set(value As Single)
                If oBasePen.IsWriteable Then
                    oBasePen.DecorationScale = value
                End If
            End Set
        End Property

        Friend ReadOnly Property Invalidated As Boolean
            Get
                Return oBasePen.Invalidated
            End Get
        End Property

        Friend Sub Invalidate()
            Call oBasePen.Invalidate()
        End Sub

        Private bIsRendering As Boolean

        Friend Sub Render(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As Boolean, ByVal Path As GraphicsPath, ByVal Cache As cDrawCache)
            bIsRendering = True
            Call oBasePen.Render(Graphics, PaintOptions, Options, Selected, Path, Cache)
            bIsRendering = False
        End Sub

        Private Sub oBasePen_OnChanged(Sender As Object, e As EventArgs) Handles oBasePen.OnChanged
            RaiseEvent OnChanged(Me, e)
        End Sub

        Private Sub oSurvey_OnPropertiesChanged(ByVal Sender As cSurvey, ByVal Args As cSurvey.OnPropertiesChangedEventArgs) Handles oSurvey.OnPropertiesChanged
            Call Invalidate()
        End Sub

        Private Sub oBasePen_OnRender(sender As Object, RenderArgs As cRenderEventArgs) Handles oBasePen.OnRender
            If bIsRendering Then
                RaiseEvent OnRender(Me, RenderArgs)
            End If
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    If Not oBasePen Is Nothing Then
                        Call oBasePen.Dispose()
                        oBasePen = Nothing
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