Imports cSurveyPC
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Drawings

Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace cSurvey.Design
    Public Class cBrush
        Implements IDisposable

        Public Enum BrushTypeEnum
            None = 0
            Solid = 1
            Water = 2
            Sand = 3
            Pebbles = 4
            Flow = 5
            NotStandardWater = 6
            SignSolid = 7
            SmallDebrits = 8
            BigDebrits = 9
            SnowOrIce = 10
            Custom = 99
        End Enum

        Public Enum HatchTypeEnum
            None = 0
            Solid = 1
            Clipart = 2
            Pattern = 3
            Texture = 4
        End Enum

        Public Enum PatternTypeEnum
            Lines = 0
            CrossedLines = 1
        End Enum

        Public Enum ClipartAngleModeEnum
            Random = 0
            Fixed = 1
        End Enum

        Public Enum ClipartCropEnum
            None = 0
            Full = 1
            Subitems = 2
        End Enum

        Public Enum ClipartPositionEnum
            Random = 0
            Fixed = 1
        End Enum

        Private WithEvents oSurvey As cSurvey

        Private sName As String
        Private iType As BrushTypeEnum

        Private iHatchType As HatchTypeEnum

        Private oColor As Color
        Private oAlternativeColor As Color

        Private WithEvents oSeed As cBrushSeed

        Private oTexture As Image
        Private sTextureID As String
        Private iTextureWrapMode As System.Drawing.Drawing2D.WrapMode

        Private oClipart As cDrawClipArt
        Private sClipartDensity As Single
        Private sClipartZoomFactor As Single
        Private iClipartAngleMode As ClipartAngleModeEnum
        Private iClipartAngle As Integer
        Private iClipartCrop As ClipartCropEnum
        Private iClipartPosition As ClipartPositionEnum
        Private oClipartAlternativeColor As Color
        Private oClipartAlternativeBrush1 As SolidBrush
        Private oClipartAlternativeBrush2 As SolidBrush
        Private oTextureBrush As TextureBrush

        Private oPen As Pen
        Private oBrush As Brush
        Private oSchematicBrush As HatchBrush

        Private oPatternPen As Pen
        Private iPatternType As PatternTypeEnum
        Private iPatternPenStyle As cPen.PenStylesEnum

        Private sLocalLineWidth As Single
        Private sLocalZoomFactor As Single

        Private bInvalidated As Boolean

        Friend Event OnChanged(ByVal Sender As cBrush)

        Friend Class cRenderArgs
            Public Transparency As Single
        End Class
        Friend Event OnRender(sender As cBrush, RenderArgs As cRenderArgs)

        Public Function GetThumbnailSVG(ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal thumbWidth As Integer, ByVal thumbHeight As Integer, ByVal ForeColor As Color, ByVal Backcolor As Color) As XmlDocument
            Dim oBounds As RectangleF = New RectangleF(0, 0, thumbWidth, thumbHeight)
            Dim oSVG As XmlDocument = modSVG.CreateSVG("", New Size(thumbWidth, thumbHeight), SizeUnit.pixel, oBounds, SVGCreateFlagsEnum.None)
            Using oImage As Image = New Bitmap(thumbWidth, thumbHeight)
                Using oGr As Graphics = Graphics.FromImage(oImage)
                    'oGr.SmoothingMode = SmoothingMode.AntiAlias
                    'oGr.CompositingQuality = CompositingQuality.HighQuality
                    'oGr.InterpolationMode = InterpolationMode.HighQualityBicubic
                    Using oBackBrush As SolidBrush = New SolidBrush(Backcolor)
                        Call oGr.FillRectangle(oBackBrush, oBounds)
                        Dim sZoom As Single = 0.1
                        Using oPath As GraphicsPath = New GraphicsPath
                            Dim oBrushRect As RectangleF = New RectangleF(oBounds.Left, oBounds.Top, oBounds.Width, oBounds.Height)
                            Call oPath.AddRectangle(oBrushRect)
                            Using oMatrix As Matrix = New Matrix
                                Call oMatrix.Scale(sZoom, sZoom)
                                Call oPath.Transform(oMatrix)
                            End Using
                            Call oGr.ScaleTransform(1 / sZoom, 1 / sZoom)
                            Using oCache As cDrawCache = New cDrawCache
                                Using oMatrix As Matrix = New Matrix
                                    Call Render(oGr, PaintOptions, cItem.PaintOptionsEnum.None, False, oPath, oCache)
                                    oMatrix.Scale(10, 10)
                                    oCache.Trasform(oMatrix)
                                    Call oCache.Paint(oGr, PaintOptions, cItem.PaintOptionsEnum.None)
                                    Call modSVG.AppendRectangle(oSVG, oSVG.DocumentElement, oBounds, New SolidBrush(Backcolor), Nothing)
                                    Call oSVG.DocumentElement.AppendChild(oCache.ToSvgItem(oSVG, PaintOptions, cItem.SVGOptionsEnum.ClipartBrushes))
                                    Call modSVG.AppendRectangle(oSVG, oSVG.DocumentElement, oBounds, Nothing, New Pen(ForeColor))
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End Using
            Return oSVG
        End Function

        Public Function GetThumbnailImage(ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal thumbWidth As Integer, ByVal thumbHeight As Integer) As Image
            Return GetThumbnailImage(PaintOptions, Options, Selected, thumbHeight, thumbHeight, Color.Black, Color.White)
        End Function

        Public Function GetThumbnailImage(ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal thumbWidth As Integer, ByVal thumbHeight As Integer, ByVal ForeColor As Color, ByVal Backcolor As Color) As Image
            Try
                Dim oBounds As RectangleF = New RectangleF(0, 0, thumbWidth, thumbHeight)
                Dim oImage As Image = New Bitmap(thumbWidth, thumbHeight)
                Using oGr As Graphics = Graphics.FromImage(oImage)
                    oGr.SmoothingMode = SmoothingMode.AntiAlias
                    oGr.CompositingQuality = CompositingQuality.HighQuality
                    oGr.InterpolationMode = InterpolationMode.HighQualityBicubic
                    Using oBackBrush As SolidBrush = New SolidBrush(Backcolor)
                        Call oGr.FillRectangle(oBackBrush, oBounds)
                        Dim sZoom As Single = 0.1
                        Using oPath As GraphicsPath = New GraphicsPath
                            Dim oBrushRect As RectangleF = New RectangleF(oBounds.Left, oBounds.Top, oBounds.Width, oBounds.Height)
                            Call oPath.AddRectangle(oBrushRect)
                            Using oMatrix As Matrix = New Matrix
                                Call oMatrix.Scale(sZoom, sZoom)
                                Call oPath.Transform(oMatrix)
                            End Using
                            Call oGr.ScaleTransform(1 / sZoom, 1 / sZoom)
                            Using oCache As cDrawCache = New cDrawCache
                                Call Invalidate()
                                Call Render(oGr, PaintOptions, cItem.PaintOptionsEnum.None, False, oPath, oCache)
                                Call oCache.Paint(oGr, PaintOptions, cItem.PaintOptionsEnum.None)
                            End Using
                        End Using
                    End Using
                End Using
                Return oImage
            Catch
                Return Nothing
            End Try
        End Function

        Public Property Name() As String
            Get
                Return sName
            End Get
            Set(ByVal value As String)
                If sName <> value Then
                    iType = BrushTypeEnum.Custom
                    sName = value
                End If
            End Set
        End Property

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

        Friend ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public Sub CopyFrom(ByVal Brush As cBrush)
            sName = Brush.sName
            Call oSeed.CopyFrom(Brush.oSeed)
            iType = Brush.iType
            oColor = Brush.oColor
            iHatchType = Brush.iHatchType

            If IsNothing(Brush.oClipart) Then
                oClipart = Nothing
            Else
                oClipart = Brush.oClipart.Clone
            End If
            sClipartDensity = Brush.sClipartDensity
            sClipartZoomFactor = Brush.sClipartZoomFactor
            iClipartAngleMode = Brush.iClipartAngleMode
            iClipartAngle = Brush.iClipartAngle
            iClipartCrop = Brush.iClipartCrop
            iClipartPosition = Brush.iClipartPosition
            oClipartAlternativeColor = Brush.oClipartAlternativeColor

            oTexture = Brush.oTexture
            iTextureWrapMode = Brush.iTextureWrapMode

            oPatternPen = Brush.oPatternPen
            iPatternType = Brush.iPatternType
            iPatternPenStyle = Brush.iPatternPenStyle

            sLocalLineWidth = Brush.sLocalLineWidth
            Call Invalidate()
        End Sub

        Public Property HatchType() As HatchTypeEnum
            Get
                Return iHatchType
            End Get
            Set(ByVal value As HatchTypeEnum)
                If iHatchType <> value Then
                    iType = BrushTypeEnum.Custom
                    iHatchType = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Friend ReadOnly Property Pen As Pen
            Get
                Return oPen
            End Get
        End Property

        Friend ReadOnly Property Brush As Brush
            Get
                Return oBrush
            End Get
        End Property

        Public Property PatternPenStyle() As cPen.PenStylesEnum
            Get
                Return iPatternPenStyle
            End Get
            Set(ByVal value As cPen.PenStylesEnum)
                If iPatternPenStyle <> value Then
                    iType = BrushTypeEnum.Custom
                    iPatternPenStyle = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property PatternType() As PatternTypeEnum
            Get
                Return iPatternType
            End Get
            Set(ByVal value As PatternTypeEnum)
                If iPatternType <> value Then
                    iType = BrushTypeEnum.Custom
                    iPatternType = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartPosition() As ClipartPositionEnum
            Get
                Return iClipartPosition
            End Get
            Set(ByVal value As ClipartPositionEnum)
                If iClipartPosition <> value Then
                    iType = BrushTypeEnum.Custom
                    iClipartPosition = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartCrop() As ClipartCropEnum
            Get
                Return iClipartCrop
            End Get
            Set(ByVal value As ClipartCropEnum)
                If iClipartCrop <> value Then
                    iType = BrushTypeEnum.Custom
                    iClipartCrop = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartAngle() As Integer
            Get
                Return iClipartAngle
            End Get
            Set(ByVal value As Integer)
                If iClipartAngle <> value Then
                    iType = BrushTypeEnum.Custom
                    iClipartAngle = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property TextureWrapmode() As System.Drawing.Drawing2D.WrapMode
            Get
                Return iTextureWrapMode
            End Get
            Set(ByVal value As System.Drawing.Drawing2D.WrapMode)
                If iTextureWrapMode <> value Then
                    iType = BrushTypeEnum.Custom
                    iTextureWrapMode = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartAngleMode() As ClipartAngleModeEnum
            Get
                Return iClipartAngleMode
            End Get
            Set(ByVal value As ClipartAngleModeEnum)
                If iClipartAngleMode <> value Then
                    iType = BrushTypeEnum.Custom
                    iClipartAngleMode = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartDensity() As Single
            Get
                Return sClipartDensity
            End Get
            Set(ByVal value As Single)
                If sClipartDensity <> value And sClipartDensity > 0 Then
                    iType = BrushTypeEnum.Custom
                    sClipartDensity = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartZoomFactor() As Single
            Get
                Return sClipartZoomFactor
            End Get
            Set(ByVal value As Single)
                If sClipartZoomFactor <> value And sClipartZoomFactor > 0 Then
                    iType = BrushTypeEnum.Custom
                    sClipartZoomFactor = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public ReadOnly Property Seed() As cBrushSeed
            Get
                Return oSeed
            End Get
        End Property

        Public Property Texture() As Image
            Get
                Return oTexture
            End Get
            Set(ByVal Value As Image)
                If Not oTexture Is Value Then
                    iType = BrushTypeEnum.Custom
                    sTextureID = Guid.NewGuid.ToString
                    oTexture = Value
                    'oTexture = modPaint.ScaleImage(value, New Size(256, 256), Color.White)
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property Clipart() As cDrawClipArt
            Get
                Return oClipart
            End Get
            Set(ByVal Value As cDrawClipArt)
                If Not oClipart Is Value Then
                    iType = BrushTypeEnum.Custom
                    oClipart = Value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property Type() As BrushTypeEnum
            Get
                Return iType
            End Get
            Set(ByVal value As BrushTypeEnum)
                If iType <> value Then
                    If iType <> BrushTypeEnum.Custom AndAlso value = BrushTypeEnum.Custom Then
                        Call CopyFrom(oSurvey.EditPaintObjects.Brushes.FromType(iType))
                    Else
                        Call CopyFrom(oSurvey.EditPaintObjects.Brushes.FromType(value))
                    End If
                    iType = value
                End If
            End Set
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Brush As cBrush)
            oSurvey = Survey
            Call CopyFrom(Brush)
            bInvalidated = True
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Type As BrushTypeEnum)
            oSurvey = Survey
            oSeed = New cBrushSeed
            Call CopyFrom(Survey.EditPaintObjects.Brushes.FromType(iType))
            bInvalidated = True
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Name As String, ByVal Type As BrushTypeEnum, ByVal Color As Color, Optional ByVal HatchType As HatchTypeEnum = HatchTypeEnum.None, Optional ByVal Clipart As cDrawClipArt = Nothing, Optional ByVal ClipartDensity As Single = 1, Optional ByVal ClipartZoomFactor As Single = 1, Optional ClipartAlternativeColor As Color = Nothing, Optional ClipartAngleMode As ClipartAngleModeEnum = ClipartAngleModeEnum.Random, Optional ClipartAngle As Integer = 0, Optional ClipartCrop As ClipartCropEnum = ClipartCropEnum.Full, Optional ClipartPosition As ClipartPositionEnum = ClipartPositionEnum.Random)
            oSurvey = Survey
            oSeed = New cBrushSeed
            sName = Name
            iType = Type
            oColor = Color
            iHatchType = HatchType

            oClipart = Clipart
            sClipartDensity = ClipartDensity
            If sClipartDensity <= 0 Then sClipartDensity = 1
            sClipartZoomFactor = ClipartZoomFactor
            If sClipartZoomFactor <= 0 Then sClipartZoomFactor = 1
            oClipartAlternativeColor = ClipartAlternativeColor
            iClipartAngleMode = ClipartAngleMode
            iClipartAngle = ClipartAngle
            iClipartCrop = ClipartCrop
            iClipartPosition = ClipartPosition

            bInvalidated = True
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oSeed = New cBrushSeed
            iType = BrushTypeEnum.Custom
            oColor = Color.LightGray
            HatchType = HatchTypeEnum.None

            sClipartDensity = 1
            sClipartZoomFactor = 1
            oClipartAlternativeColor = Nothing

            bInvalidated = True
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal item As XmlElement)
            oSurvey = Survey
            oSeed = New cBrushSeed()
            iType = modXML.GetAttributeValue(item, "type", BrushTypeEnum.Custom)
            If iType = BrushTypeEnum.Custom Then
                sName = modXML.GetAttributeValue(item, "name", "")
                oColor = modXML.GetAttributeColor(item, "color", Color.Black)
                iHatchType = modXML.GetAttributeValue(item, "hatchtype")

                If iHatchType = HatchTypeEnum.Texture Then
                    sTextureID = modXML.GetAttributeValue(item, "textureid", Guid.NewGuid.ToString)
                    If sTextureID = "" Then sTextureID = Guid.NewGuid.ToString
                    Select Case File.FileFormat
                        Case cFile.FileFormatEnum.CSX
                            oTexture = modPaint.ByteArrayToBitmap(Convert.FromBase64String(modXML.GetAttributeValue(item, "texture")))
                        Case cFile.FileFormatEnum.CSZ
                            Dim sImagePath As String = modXML.GetAttributeValue(item, "texture")
                            oTexture = modPaint.ByteArrayToBitmap(DirectCast(File.Data(sImagePath), Storage.cStorageItemFile).Stream.ToArray)
                    End Select
                    iTextureWrapMode = modXML.GetAttributeValue(item, "texturewrapmode")
                ElseIf iHatchType = HatchTypeEnum.Clipart Then
                    Dim oXMLClipart As XmlElement = item.Item("clipart")
                    If oXMLClipart Is Nothing Then
                        oClipart = New cDrawClipArt()
                    Else
                        oClipart = New cDrawClipArt(oXMLClipart)
                    End If
                    sClipartDensity = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "clipartdensity"))
                    sClipartZoomFactor = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "clipartzoomfactor"))
                    iClipartAngleMode = modXML.GetAttributeValue(item, "clipartanglemode")
                    If iClipartAngleMode = ClipartAngleModeEnum.Fixed Then
                        iClipartAngle = modXML.GetAttributeValue(item, "clipartangle")
                    End If
                    iClipartCrop = modXML.GetAttributeValue(item, "clipartcrop")
                    iClipartPosition = modXML.GetAttributeValue(item, "clipartposition")
                    Dim oXMLSeed As XmlElement = item.Item("seed")
                    If Not oXMLSeed Is Nothing Then
                        oSeed = New cBrushSeed(oXMLSeed)
                    End If
                    oClipartAlternativeColor = modXML.GetAttributeColor(item, "clipartalternativecolor", Drawing.Color.Gray)
                ElseIf iHatchType = HatchTypeEnum.Pattern Then
                    iPatternType = modXML.GetAttributeValue(item, "patterntype")
                    iPatternPenStyle = modXML.GetAttributeValue(item, "patternpenstyle")
                    sClipartDensity = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "clipartdensity"))
                    iClipartAngleMode = modXML.GetAttributeValue(item, "clipartanglemode")
                    If iClipartAngleMode = ClipartAngleModeEnum.Fixed Then
                        iClipartAngle = modXML.GetAttributeValue(item, "clipartangle")
                    End If
                End If
            Else
                Call CopyFrom(oSurvey.EditPaintObjects.Brushes.FromType(iType))
            End If

            If sClipartDensity <= 0 Then sClipartDensity = 1
            If sClipartZoomFactor <= 0 Then sClipartZoomFactor = 1

            bInvalidated = True
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oItem As XmlElement = Document.CreateElement("brush")
            Call oItem.SetAttribute("type", iType)

            If iType = BrushTypeEnum.Custom Then
                If sName <> "" Then
                    Call oItem.SetAttribute("name", sName)
                End If
                Call oItem.SetAttribute("color", oColor.ToArgb)
                Call oItem.SetAttribute("hatchtype", iHatchType)

                If iHatchType = HatchTypeEnum.Texture Then
                    If Not oTexture Is Nothing Then
                        Call oItem.SetAttribute("textureid", sTextureID)
                        If Not (File.Options And cFile.FileOptionsEnum.DontSaveBinary) = cFile.FileOptionsEnum.DontSaveBinary Then
                            Select Case File.FileFormat
                                Case cFile.FileFormatEnum.CSX
                                    Call oItem.SetAttribute("texture", Convert.ToBase64String(modPaint.BitmapToByteArray(oTexture, Drawing.Imaging.ImageFormat.Png)))
                                Case cFile.FileFormatEnum.CSZ
                                    Dim sImagePath As String = "_data\texture\" & sTextureID & ".png"
                                    Dim oImageStorage As Storage.cStorageItemFile = File.Data.AddFile(sImagePath)
                                    Call oImageStorage.Write(modPaint.BitmapToByteArray(oTexture, Drawing.Imaging.ImageFormat.Png))
                                    Call oItem.SetAttribute("texture", sImagePath)
                            End Select
                        End If
                    End If
                    Call oItem.SetAttribute("texturewrapmode", iTextureWrapMode.ToString("D"))
                ElseIf iHatchType = HatchTypeEnum.Clipart Then
                    If Not oClipart Is Nothing Then Call oClipart.SaveTo(File, Document, oItem)
                    Call oItem.SetAttribute("clipartdensity", modNumbers.NumberToString(sClipartDensity))
                    Call oItem.SetAttribute("clipartzoomfactor", modNumbers.NumberToString(sClipartZoomFactor, "0.0000"))
                    Call oItem.SetAttribute("clipartanglemode", iClipartAngleMode.ToString("D"))
                    If iClipartAngleMode = ClipartAngleModeEnum.Fixed Then
                        Call oItem.SetAttribute("clipartangle", iClipartAngle)
                    End If
                    If iClipartCrop <> ClipartCropEnum.None Then
                        Call oItem.SetAttribute("clipartcrop", iClipartCrop.ToString("D"))
                    End If
                    If iClipartPosition <> ClipartPositionEnum.Random Then
                        Call oItem.SetAttribute("clipartposition", iClipartPosition.ToString("D"))
                    End If
                    Call oItem.SetAttribute("clipartalternativecolor", oClipartAlternativeColor.ToArgb)
                    Call oSeed.SaveTo(File, Document, oItem)
                ElseIf iHatchType = HatchTypeEnum.Pattern Then
                    Call oItem.SetAttribute("patterntype", iPatternType.ToString("D"))
                    Call oItem.SetAttribute("patternpenstyle", iPatternPenStyle.ToString("D"))
                    Call oItem.SetAttribute("clipartdensity", modNumbers.NumberToString(sClipartDensity))
                    Call oItem.SetAttribute("clipartanglemode", iClipartAngleMode.ToString("D"))
                    If iClipartAngleMode = ClipartAngleModeEnum.Fixed Then
                        Call oItem.SetAttribute("clipartangle", iClipartAngle)
                    End If
                    Call oItem.SetAttribute("clipartalternativecolor", oClipartAlternativeColor.ToArgb)
                End If
            End If

            Call Parent.AppendChild(oItem)
            Return oItem
        End Function

        Public Property AlternativeColor() As Color
            Get
                Return oAlternativeColor
            End Get
            Set(ByVal value As Color)
                If oAlternativeColor <> value Then
                    iType = BrushTypeEnum.Custom
                    oAlternativeColor = value
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
                    iType = BrushTypeEnum.Custom
                    oColor = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartAlternativeColor() As Color
            Get
                Return oClipartAlternativeColor
            End Get
            Set(ByVal value As Color)
                If oClipartAlternativeColor <> value Then
                    iType = BrushTypeEnum.Custom
                    oClipartAlternativeColor = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Friend Function GetPaintZoomFactor(PaintOptions As cOptionsCenterline) As Single
            Dim sZoomFactor As Single
            If sLocalZoomFactor = 0 Then
                Select Case iHatchType
                    Case HatchTypeEnum.Texture
                        sZoomFactor = PaintOptions.GetCurrentDesignPropertiesValue("DesignTextureScaleFactor", 0.2)
                    Case HatchTypeEnum.Clipart
                        sZoomFactor = PaintOptions.GetCurrentDesignPropertiesValue("DesignSoilScaleFactor", 1)
                    Case Else
                        sZoomFactor = PaintOptions.GetCurrentDesignPropertiesValue("DesignSoilScaleFactor", 1)
                End Select
            Else
                sZoomFactor = sLocalZoomFactor
            End If
            Return sZoomFactor
        End Function

        Friend Function GetPaintLineWidth(PaintOptions As cOptionsCenterline) As Single
            Dim sLineWidth As Single
            If sLocalLineWidth = 0 Then
                sLineWidth = PaintOptions.GetCurrentDesignPropertiesValue("BaseLineWidthScaleFactor", 0.01)
            Else
                sLineWidth = sLocalLineWidth
            End If
            Return sLineWidth
        End Function

        'Friend Function GetPaintPenWidth(PaintOptions As cOptions) As Single
        '    Dim sLineWidth As Single = GetPaintLineWidth(PaintOptions)
        '    Dim sPenWidth As Single = 0
        '    If sWidth < 0 Then
        '        sPenWidth = sWidth
        '    ElseIf sWidth = 0 Then
        '        sPenWidth = PaintOptions.GetPenDefaultWidth(iType) * sLineWidth
        '    Else
        '        sPenWidth = sWidth * sLineWidth
        '    End If
        '    Return sPenWidth
        'End Function

        Private Sub pRender(ByVal PaintOptions As cOptionsCenterline)
            If iHatchType = HatchTypeEnum.Solid Or iHatchType = HatchTypeEnum.Clipart Or iHatchType = HatchTypeEnum.Pattern Or iHatchType = HatchTypeEnum.Texture Then
                Dim oRenderArgs As cRenderArgs = New cRenderArgs
                RaiseEvent OnRender(Me, oRenderArgs)

                Dim sLineWidth As Single = GetPaintLineWidth(PaintOptions)
                Dim oPaintColor As Color = If(oAlternativeColor.IsEmpty, oColor, oAlternativeColor)
                oPaintColor = Color.FromArgb((1 - oRenderArgs.Transparency) * 255, oPaintColor)
                oPen = New Pen(oPaintColor, sLineWidth / 10)
                oBrush = New SolidBrush(oPaintColor)
                oSchematicBrush = New HatchBrush(HatchStyle.Percent10, oPaintColor, Color.White)
                oClipartAlternativeBrush1 = New SolidBrush(oClipartAlternativeColor)
                oClipartAlternativeBrush2 = New SolidBrush(Color.FromArgb(180, oClipartAlternativeColor))
                If iHatchType = HatchTypeEnum.Texture Then
                    Dim oRect As RectangleF = New RectangleF(0, 0, oTexture.Width, oTexture.Height)
                    oTextureBrush = New TextureBrush(oTexture, iTextureWrapMode, oRect)
                End If

                oPatternPen = New Pen(oPaintColor, sLineWidth / 10)
                oPatternPen.SetLineCap(Drawing2D.LineCap.Round, Drawing2D.LineCap.Round, Drawing2D.DashCap.Round)
                oPatternPen.LineJoin = Drawing2D.LineJoin.Round
                Select Case iPatternPenStyle
                    Case cPen.PenStylesEnum.Solid
                        oPatternPen.DashStyle = DashStyle.Solid
                    Case cPen.PenStylesEnum.Dot
                        oPatternPen.DashStyle = DashStyle.Dot
                    Case cPen.PenStylesEnum.Dash
                        oPatternPen.DashStyle = DashStyle.Dash
                    Case cPen.PenStylesEnum.DashDot
                        oPatternPen.DashStyle = DashStyle.DashDot
                End Select

                bInvalidated = False
            End If
        End Sub

        Private Sub pRenderTexture(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal Path As GraphicsPath, ByVal Cache As cDrawCache)
            If PaintOptions.ShowAdvancedBrushes Then
                If Selected = cItem.SelectionModeEnum.InEdit Then
                    Call Cache.AddFiller(Path, Nothing, Nothing, oClipartAlternativeBrush2)
                Else
                    Dim sZoomFactor As Single = GetPaintZoomFactor(PaintOptions)
                    Call oTextureBrush.ResetTransform()
                    Call oTextureBrush.ScaleTransform(sZoomFactor, sZoomFactor)
                    Call Cache.AddFiller(Path, Nothing, Nothing, oTextureBrush)
                End If
            Else
                Call Cache.AddFiller(Path, Nothing, Nothing, oClipartAlternativeBrush1)
            End If
        End Sub

        Private Function pCreateRegion(Path As GraphicsPath) As cIRegion
            If oSurvey.Properties.DesignProperties.GetValue("ClippingForAdvancedBrush", 0) = 0 Then
                Return New cGDIRegion(Path)
            Else
                Return New cClipperRegion(Path, 1000, 10)
            End If
        End Function

        Private Sub pRenderClipart(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal Path As GraphicsPath, ByVal Cache As cDrawCache)
            If PaintOptions.ShowAdvancedBrushes Then
                If Selected = cItem.SelectionModeEnum.InEdit Then
                    Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Filler, Path, Nothing, Nothing, oClipartAlternativeBrush2)
                Else
                    If sClipartDensity > 0 AndAlso Not oClipart Is Nothing AndAlso Path.PointCount > 2 Then
                        Dim sZoomFactor As Single = GetPaintZoomFactor(PaintOptions)
                        Dim sCurrentDensity As Single = sClipartDensity * sZoomFactor
                        Call Cache.AddSetClip(Path)
                        Using oClipRegion As cIRegion = pCreateRegion(Path)
                            Using oPenPath As GraphicsPath = New GraphicsPath
                                Using oFillWhitePath As GraphicsPath = New GraphicsPath
                                    oFillWhitePath.FillMode = FillMode.Winding
                                    Using oFillPath As GraphicsPath = New GraphicsPath
                                        oFillPath.FillMode = FillMode.Winding

                                        If iClipartCrop = ClipartCropEnum.Subitems Then
                                            Dim oBasePenPathColl As List(Of GraphicsPath) = New List(Of GraphicsPath)
                                            Dim oBaseFillWhitePathColl As List(Of GraphicsPath) = New List(Of GraphicsPath)
                                            Dim oBaseFillPathColl As List(Of GraphicsPath) = New List(Of GraphicsPath)

                                            Dim oItemPenPathColl As List(Of GraphicsPath) = New List(Of GraphicsPath)
                                            Dim oItemFillWhitePathColl As List(Of GraphicsPath) = New List(Of GraphicsPath)
                                            Dim oItemFillPathColl As List(Of GraphicsPath) = New List(Of GraphicsPath)

                                            Dim oPaths As cDrawPaths = oClipart.Paths
                                            For Each oDrawPath As cDrawPath In oPaths
                                                Dim oClipartPath As GraphicsPath = oDrawPath.Path
                                                If oClipartPath.PointCount > 1 Then
                                                    If oClipartPath.PointCount > 2 Then
                                                        Dim sFill As String = oDrawPath.GetStyle("fill", "none")
                                                        If sFill <> "none" Then
                                                            Dim oColor As Color
                                                            If sFill = "" Then
                                                                oColor = Color.Transparent
                                                            Else
                                                                oColor = ColorTranslator.FromHtml(sFill)
                                                            End If
                                                            If oColor.ToArgb = Color.White.ToArgb Then
                                                                Call oBaseFillWhitePathColl.Add(oClipartPath)
                                                            Else
                                                                Call oBaseFillPathColl.Add(oClipartPath)
                                                            End If
                                                        End If
                                                    End If
                                                    Call oBasePenPathColl.Add(oClipartPath)
                                                End If
                                            Next

                                            Dim bBasePenPath As Boolean = oBasePenPathColl.Count > 0
                                            If bBasePenPath Then
                                                Dim bBaseFillWhitePath As Boolean = oBaseFillWhitePathColl.Count > 0
                                                Dim bBaseFillPath As Boolean = oBaseFillPathColl.Count > 0

                                                Dim oBounds As RectangleF = Path.GetBounds
                                                Dim oClipartBounds As RectangleF = oClipart.GetBounds
                                                Dim sLeft As Single = oBounds.Left - sCurrentDensity
                                                Dim sRight As Single = oBounds.Right + sCurrentDensity
                                                Call oSeed.Restart()
                                                For x As Single = sLeft To sRight Step sCurrentDensity
                                                    Dim [sTop] As Single = oBounds.Top - sCurrentDensity * Math.Abs(oSeed.CurrentBase) / 100 * 2
                                                    Dim sBottom As Single = oBounds.Bottom + sCurrentDensity * Math.Abs(oSeed.CurrentBase) / 100 * 2
                                                    For y As Single = [sTop] To sBottom Step sCurrentDensity
                                                        Dim oPoint As PointF
                                                        If iClipartPosition = ClipartPositionEnum.Fixed Then
                                                            oPoint = New PointF(x, y)
                                                        Else
                                                            Call oSeed.Next()
                                                            Dim sSideFactor As Single = sCurrentDensity * oSeed.CurrentBase / 200
                                                            oPoint = New PointF(x + sSideFactor, y)
                                                        End If

                                                        Using oMatrix As Matrix = New Matrix
                                                            Dim oCenterPoint As PointF = New PointF(oClipartBounds.Left + oClipartBounds.Width / 2, oClipartBounds.Top + oClipartBounds.Height / 2)
                                                            If iClipartAngleMode = ClipartAngleModeEnum.Random Then
                                                                Call oMatrix.RotateAt(359 * oSeed.CurrentBase / 100, oCenterPoint, MatrixOrder.Append)
                                                            Else
                                                                If iClipartAngle <> 0 Then
                                                                    Call oMatrix.RotateAt(iClipartAngle, oCenterPoint, MatrixOrder.Append)
                                                                End If
                                                            End If
                                                            Dim sTempZoomFactor As Single = sClipartZoomFactor * sZoomFactor
                                                            If sTempZoomFactor <> 1 Then
                                                                Call oMatrix.Scale(sTempZoomFactor, sTempZoomFactor, MatrixOrder.Append)
                                                            End If
                                                            Call oMatrix.Translate(oPoint.X, oPoint.Y, MatrixOrder.Append)

                                                            If bBaseFillWhitePath Then
                                                                Call oItemFillWhitePathColl.Clear()
                                                                For Each oPath As GraphicsPath In oBaseFillWhitePathColl
                                                                    Dim oNewPath As GraphicsPath = oPath.Clone
                                                                    Call oNewPath.Transform(oMatrix)
                                                                    Call oItemFillWhitePathColl.Add(oNewPath)
                                                                Next
                                                            End If

                                                            If bBaseFillPath Then
                                                                Call oItemFillPathColl.Clear()
                                                                For Each oPath As GraphicsPath In oBaseFillPathColl
                                                                    Dim oNewPath As GraphicsPath = oPath.Clone
                                                                    Call oNewPath.Transform(oMatrix)
                                                                    Call oItemFillPathColl.Add(oNewPath)
                                                                Next
                                                            End If

                                                            Call oItemPenPathColl.Clear()
                                                            For Each oPath As GraphicsPath In oBasePenPathColl
                                                                Dim oNewPath As GraphicsPath = oPath.Clone
                                                                Call oNewPath.Transform(oMatrix)
                                                                Call oItemPenPathColl.Add(oNewPath)
                                                            Next

                                                            For Each oPath As GraphicsPath In oItemFillWhitePathColl
                                                                Using oWidenedPath As GraphicsPath = oPath
                                                                    If oClipRegion.Contains(Graphics, oWidenedPath) Then
                                                                        Call Cache.AddFiller(oPath, Nothing, Nothing, Brushes.White)
                                                                    End If
                                                                End Using
                                                            Next

                                                            For Each oPath As GraphicsPath In oItemFillPathColl
                                                                'Try
                                                                Using oWidenedPath As GraphicsPath = oPath
                                                                    If oClipRegion.Contains(Graphics, oWidenedPath) Then
                                                                        Call Cache.AddFiller(oPath, Nothing, Nothing, oBrush)
                                                                    End If
                                                                End Using
                                                            Next

                                                            For Each oPath As GraphicsPath In oItemPenPathColl
                                                                Using oWidenedPath As GraphicsPath = oPath
                                                                    If oClipRegion.Contains(Graphics, oWidenedPath) Then
                                                                        Call Cache.AddFiller(oPath, oPen, Nothing)
                                                                    End If
                                                                End Using
                                                            Next

                                                        End Using

                                                        If Not PaintOptions.IsDesign AndAlso modMain.Is32Bit Then
                                                            Call GC.Collect()
                                                        End If
                                                    Next
                                                Next
                                            End If
                                        Else
                                            Using oBasePenPath As GraphicsPath = New GraphicsPath
                                                Using oBaseFillWhitePath As GraphicsPath = New GraphicsPath
                                                    Using oBaseFillPath As GraphicsPath = New GraphicsPath

                                                        Dim oItemFillWhitePath As GraphicsPath = Nothing
                                                        Dim oItemFillPath As GraphicsPath = Nothing

                                                        Dim oPaths As cDrawPaths = oClipart.Paths
                                                        For Each oDrawPath As cDrawPath In oPaths
                                                            Dim oClipartPath As GraphicsPath = oDrawPath.Path
                                                            Dim sFill As String = oDrawPath.GetStyle("fill", "none")
                                                            If sFill <> "none" Then
                                                                Dim oColor As Color
                                                                If sFill = "" Then
                                                                    oColor = Color.Transparent
                                                                Else
                                                                    oColor = ColorTranslator.FromHtml(sFill)
                                                                End If
                                                                If oColor.ToArgb = Color.White.ToArgb Then
                                                                    Call oBaseFillWhitePath.AddPath(oClipartPath, False)
                                                                Else
                                                                    Call oBaseFillPath.AddPath(oClipartPath, False)
                                                                End If
                                                            End If
                                                            Call oBasePenPath.AddPath(oClipartPath, False)
                                                        Next

                                                        Dim bBasePenPath As Boolean = oBasePenPath.PointCount > 1
                                                        If bBasePenPath Then
                                                            Dim bBaseFillWhitePath As Boolean = oBaseFillWhitePath.PointCount > 1
                                                            Dim bBaseFillPath As Boolean = oBaseFillPath.PointCount > 1

                                                            Dim oBounds As RectangleF = Path.GetBounds
                                                            Dim oClipartBounds As RectangleF = oClipart.GetBounds
                                                            Dim sLeft As Single = oBounds.Left - sCurrentDensity
                                                            Dim sRight As Single = oBounds.Right + sCurrentDensity
                                                            Call oSeed.Restart()
                                                            For x As Single = sLeft To sRight Step sCurrentDensity
                                                                Dim [sTop] As Single = oBounds.Top - sCurrentDensity * Math.Abs(oSeed.CurrentBase) / 100 * 2
                                                                Dim sBottom As Single = oBounds.Bottom + sCurrentDensity * Math.Abs(oSeed.CurrentBase) / 100 * 2
                                                                For y As Single = [sTop] To sBottom Step sCurrentDensity
                                                                    Dim oPoint As PointF
                                                                    If iClipartPosition = ClipartPositionEnum.Fixed Then
                                                                        oPoint = New PointF(x, y)
                                                                    Else
                                                                        Call oSeed.Next()
                                                                        Dim sSideFactor As Single = sCurrentDensity * oSeed.CurrentBase / 200
                                                                        oPoint = New PointF(x + sSideFactor, y)
                                                                    End If

                                                                    Using oMatrix As Matrix = New Matrix
                                                                        Dim oCenterPoint As PointF = New PointF(oClipartBounds.Left + oClipartBounds.Width / 2, oClipartBounds.Top + oClipartBounds.Height / 2)
                                                                        If iClipartAngleMode = ClipartAngleModeEnum.Random Then
                                                                            Call oMatrix.RotateAt(359 * oSeed.CurrentBase / 100, oCenterPoint, MatrixOrder.Append)
                                                                        Else
                                                                            If iClipartAngle <> 0 Then
                                                                                Call oMatrix.RotateAt(iClipartAngle, oCenterPoint, MatrixOrder.Append)
                                                                            End If
                                                                        End If
                                                                        Dim sTempZoomFactor As Single = sClipartZoomFactor * sZoomFactor
                                                                        If sTempZoomFactor <> 1 Then
                                                                            Call oMatrix.Scale(sTempZoomFactor, sTempZoomFactor, MatrixOrder.Append)
                                                                        End If
                                                                        Call oMatrix.Translate(oPoint.X, oPoint.Y, MatrixOrder.Append)

                                                                        Using oItemPenPath As GraphicsPath = oBasePenPath.Clone
                                                                            Call oItemPenPath.Transform(oMatrix)

                                                                            Dim bDo As Boolean
                                                                            Using oWidenedPath As GraphicsPath = oItemPenPath.Clone
                                                                                oWidenedPath.Widen(oPen)
                                                                                If iClipartCrop = ClipartCropEnum.Full Then
                                                                                    bDo = oClipRegion.Contains(Graphics, oWidenedPath)
                                                                                Else
                                                                                    bDo = True
                                                                                End If
                                                                            End Using
                                                                            If bDo Then
                                                                                If bBaseFillWhitePath Then
                                                                                    oItemFillWhitePath = oBaseFillWhitePath.Clone
                                                                                    Call oItemFillWhitePath.Transform(oMatrix)
                                                                                End If
                                                                                If bBaseFillPath Then
                                                                                    oItemFillPath = oBaseFillPath.Clone
                                                                                    Call oItemFillPath.Transform(oMatrix)
                                                                                End If

                                                                                If bBaseFillWhitePath Then
                                                                                    Call Cache.AddFiller(oItemFillWhitePath, Nothing, Nothing, Brushes.White)
                                                                                    Call oItemFillWhitePath.Dispose()
                                                                                End If
                                                                                If bBaseFillPath Then
                                                                                    Call Cache.AddFiller(oItemFillPath, Nothing, Nothing, oBrush)
                                                                                    Call oItemFillPath.Dispose()
                                                                                End If
                                                                                Call Cache.AddFiller(oItemPenPath, oPen, Nothing)
                                                                            End If
                                                                        End Using
                                                                    End Using
                                                                Next
                                                            Next
                                                            'If bBaseFillWhitePath Then Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Filler, oFillWhitePath, Nothing, Nothing, Brushes.White)
                                                            'If bBaseFillPath Then Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Filler, oFillPath, Nothing, Nothing, oBrush)
                                                            'Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Filler, oPenPath, oPen, Nothing)
                                                        End If
                                                    End Using
                                                End Using
                                            End Using
                                        End If
                                    End Using
                                End Using
                            End Using
                        End Using
                        Call Cache.AddResetclip()
                    End If
                End If
            Else
                Call Cache.AddFiller(Path, Nothing, Nothing, oClipartAlternativeBrush1)
            End If
        End Sub

        Private Sub pRenderPattern(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal Path As GraphicsPath, ByVal Cache As cDrawCache)
            If PaintOptions.ShowAdvancedBrushes Then
                If Selected = cItem.SelectionModeEnum.InEdit Then
                    Call Cache.AddFiller(Path, Nothing, Nothing, oClipartAlternativeBrush2)
                Else
                    Dim sZoomFactor As Single = GetPaintZoomFactor(PaintOptions)
                    If sClipartDensity > 0 And Path.PointCount > 2 Then
                        Dim sCurrentDensity As Single = sClipartDensity * sZoomFactor
                        Call Cache.AddSetClip(Path)
                        Using oPatternPath As GraphicsPath = New GraphicsPath
                            Dim oBounds As RectangleF = Path.GetBounds
                            Using oMatrix As Matrix = New Matrix
                                Call oMatrix.RotateAt(iClipartAngle, modPaint.GetCenterPoint(oBounds))
                                Using oBoundPath As GraphicsPath = New GraphicsPath
                                    Call oBoundPath.AddRectangle(oBounds)
                                    Call oBoundPath.Transform(oMatrix)
                                    oBounds = oBoundPath.GetBounds
                                End Using
                                Select Case iPatternType
                                    Case PatternTypeEnum.Lines
                                        For r = oBounds.Top To oBounds.Bottom Step sCurrentDensity
                                            Call oPatternPath.StartFigure()
                                            Call oPatternPath.AddLine(New PointF(oBounds.Left, r), New PointF(oBounds.Right, r))
                                        Next
                                    Case PatternTypeEnum.CrossedLines
                                        For r = oBounds.Top To oBounds.Bottom Step sCurrentDensity
                                            Call oPatternPath.StartFigure()
                                            Call oPatternPath.AddLine(New PointF(oBounds.Left, r), New PointF(oBounds.Right, r))
                                        Next
                                        For r = oBounds.Left To oBounds.Right Step sCurrentDensity
                                            Call oPatternPath.StartFigure()
                                            Call oPatternPath.AddLine(New PointF(r, oBounds.Top), New PointF(r, oBounds.Bottom))
                                        Next
                                End Select
                                Call oPatternPath.Transform(oMatrix)
                            End Using
                            Call Cache.AddFiller(oPatternPath, oPatternPen, Nothing)
                        End Using
                        Call Cache.AddResetclip()
                    End If
                End If
            Else
                Call Cache.AddFiller(Path, Nothing, Nothing, oClipartAlternativeBrush1)
            End If
        End Sub

        Private Sub pRenderSolid(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal Path As GraphicsPath, ByVal Cache As cDrawCache)
            Call Cache.AddBorder(Path, Nothing, Nothing, oBrush)
        End Sub

        Friend Sub Render(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal Path As GraphicsPath, ByVal Cache As cDrawCache)
            If bInvalidated Then Call pRender(PaintOptions)
            If iType <> BrushTypeEnum.None Then
                If Path.PointCount > 1 Then
                    Select Case iHatchType
                        Case HatchTypeEnum.None
                                'nulla...
                        Case HatchTypeEnum.Solid
                            Call pRenderSolid(Graphics, PaintOptions, Options, Selected, Path, Cache)
                        Case HatchTypeEnum.Pattern
                            Call pRenderPattern(Graphics, PaintOptions, Options, Selected, Path, Cache)
                        Case HatchTypeEnum.Clipart
                            Call pRenderClipart(Graphics, PaintOptions, Options, Selected, Path, Cache)
                        Case HatchTypeEnum.Texture
                            Call pRenderTexture(Graphics, PaintOptions, Options, Selected, Path, Cache)
                    End Select
                End If
            End If
        End Sub

        Friend ReadOnly Property Invalidated As Boolean
            Get
                Return bInvalidated
            End Get
        End Property

        Friend Sub Invalidate()
            bInvalidated = True
            RaiseEvent OnChanged(Me)
        End Sub

        Private Sub oSurvey_OnPropertiesChanged(ByVal Sender As cSurvey, ByVal Args As cSurvey.OnPropertiesChangedEventArgs) Handles oSurvey.OnPropertiesChanged
            Call Invalidate()
        End Sub

        Private Sub oSeed_OnReseed(ByVal Sender As cBrushSeed) Handles oSeed.OnReseed
            Call Invalidate()
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
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
                    If Not oPatternPen Is Nothing Then
                        Call oPatternPen.Dispose()
                        oPatternPen = Nothing
                    End If
                    If Not oBrush Is Nothing Then
                        Call oBrush.Dispose()
                        oBrush = Nothing
                    End If
                    If Not oSchematicBrush Is Nothing Then
                        Call oSchematicBrush.Dispose()
                        oSchematicBrush = Nothing
                    End If
                    If Not oTexture Is Nothing Then
                        Call oTexture.Dispose()
                        oTexture = Nothing
                    End If
                    If Not oTextureBrush Is Nothing Then
                        Call oTextureBrush.Dispose()
                        oTextureBrush = Nothing
                    End If
                    If Not oClipartAlternativeBrush1 Is Nothing Then
                        Call oClipartAlternativeBrush1.Dispose()
                        oClipartAlternativeBrush1 = Nothing
                    End If
                    If Not oClipartAlternativeBrush2 Is Nothing Then
                        Call oClipartAlternativeBrush2.Dispose()
                        oClipartAlternativeBrush2 = Nothing
                    End If
                    If Not oSchematicBrush Is Nothing Then
                        Call oSchematicBrush.Dispose()
                        oSchematicBrush = Nothing
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