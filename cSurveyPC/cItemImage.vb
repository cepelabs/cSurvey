Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace cSurvey.Design.Items
    Public Class cItemImage
        Inherits cItem
        Implements cIItemImage

        Private sImageID As String
        Private oImage As Bitmap
        Private iImageResizeMode As cIItemImage.ImageResizeModeEnum

        Private oTransparentColor As Color
        Private sTransparencyThreshold As Single
        Private sDefaultTransparencyThreshold As Single = 0.95

        Private sRotateBy As Single
        Private oRotatedImage As Bitmap

        Public Overrides ReadOnly Property HaveAffinity As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeCopied As Boolean
            Get
                Return True
            End Get
        End Property

        Public Property RotateBy As Single Implements cIItemImage.RotateBy
            Get
                Return sRotateBy
            End Get
            Set(value As Single)
                If sRotateBy <> value Then
                    sRotateBy = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Overrides ReadOnly Property CanBeHiddenInDesign As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeHiddenInPreview As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeLocked As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeSendedToOtherDesign As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeDeleted As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeReduced As Boolean
            Get
                Return False
            End Get
        End Property

        Public Property TransparentColor As Color
            Get
                Return oTransparentColor
            End Get
            Set(ByVal value As Color)
                oTransparentColor = value
                Call MyBase.Caches.Invalidate()
            End Set
        End Property

        Public Overrides ReadOnly Property HaveTransparency As Boolean
            Get
                Return False
            End Get
        End Property

        Public Property TransparencyThreshold As Single
            Get
                Return sTransparencyThreshold
            End Get
            Set(ByVal value As Single)
                If sTransparencyThreshold <> value Then
                    sTransparencyThreshold = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Overrides ReadOnly Property CanBeWarped As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeMoved As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HaveCrossSection As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveSplayBorder As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeConverted As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HaveSign As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveQuota As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveSketch As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveImage As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeClipped As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveLineType As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveFont As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveText As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeRotated() As Boolean
            Get
                Return False
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum, ByVal Image As Bitmap)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.Image, Category)
            sImageID = Guid.NewGuid.ToString

            oImage = New Bitmap(Image)

            oTransparentColor = Color.Transparent
            sTransparencyThreshold = sDefaultTransparencyThreshold
        End Sub

        Public Overrides ReadOnly Property HaveBrush As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property BindMode As cItem.BindModeEnum
            Get
                Return BindModeEnum.CenterPoint
            End Get
        End Property

        Public Overrides ReadOnly Property HavePen As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveEditablePoints As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeResized() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeDivided() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeCombined() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeBinded() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property MaxPointsCount As Integer
            Get
                Return 2
            End Get
        End Property

        'Friend Overrides Function ToSvg(ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlDocument
        '    Dim oSVG As XmlDocument = modSVG.CreateSVG
        '    Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions, Options))
        '    Return oSVG
        'End Function

        Public Overrides Sub ResizeBy(ByVal ScaleWidth As Single, ByVal ScaleHeight As Single)
            If ScaleWidth < 0 And ScaleHeight > 0 Then
                Call oImage.RotateFlip(RotateFlipType.RotateNoneFlipX)
            ElseIf ScaleWidth > 0 And ScaleHeight < 0 Then
                Call oImage.RotateFlip(RotateFlipType.RotateNoneFlipY)
            ElseIf ScaleWidth < 0 And ScaleHeight < 0 Then
                Call oImage.RotateFlip(RotateFlipType.RotateNoneFlipXY)
            End If
            Call MyBase.ResizeBy(ScaleWidth, ScaleHeight)
            Call MyBase.Caches.Invalidate()
        End Sub

        Friend Overrides Sub Render(ByVal Graphics As System.Drawing.Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            With MyBase.Caches(PaintOptions)
                If .Invalidated Then
                    Call .Clear()
                    Using oPath As GraphicsPath = New GraphicsPath
                        Call oPath.AddLines(MyBase.Points.GetPoints)
                        Call .Add(Drawings.cDrawCacheItem.cDrawCacheItemType.Border, oPath, Nothing, Nothing, Nothing)
                        If Not oRotatedImage Is Nothing AndAlso Not oRotatedImage Is oImage Then
                            Call oRotatedImage.Dispose()
                        End If
                        Select Case modPaint.NormalizeAngle(sRotateBy)
                            Case 0.0F
                                oRotatedImage = oImage
                            Case 90.0F
                                oRotatedImage = oImage.Clone
                                Call oRotatedImage.RotateFlip(RotateFlipType.Rotate90FlipNone)
                            Case 180.0F
                                oRotatedImage = oImage.Clone
                                Call oRotatedImage.RotateFlip(RotateFlipType.Rotate180FlipNone)
                            Case 270.0F
                                oRotatedImage = oImage.Clone
                                Call oRotatedImage.RotateFlip(RotateFlipType.Rotate270FlipNone)
                            Case Else
                                oRotatedImage = modPaint.RotateImage(oImage, sRotateBy, True, Color.Transparent)
                        End Select
                    End Using
                    Call .Rendered()
                End If
            End With
        End Sub

        Friend Overrides Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            If MyBase.Points.Count > 1 Then
                Call Render(Graphics, PaintOptions, Options, Selected)
                Try
                    If Not PaintOptions.IsDesign OrElse (PaintOptions.IsDesign And Not MyBase.HiddenInDesign) Then
                        Dim oBounds As RectangleF = GetBounds()
                        If oTransparentColor = Color.Transparent Then
                            Select Case iImageResizeMode
                                Case cIItemImage.ImageResizeModeEnum.Scaled
                                    Call modPaint.DrawScaledImage(Graphics, oRotatedImage, oBounds)
                                Case cIItemImage.ImageResizeModeEnum.Stretched
                                    Call Graphics.DrawImage(oRotatedImage, oBounds)
                            End Select
                        Else
                            Using oImageAttributes As System.Drawing.Imaging.ImageAttributes = New System.Drawing.Imaging.ImageAttributes
                                Call oImageAttributes.SetColorKey(modPaint.DarkColor(oTransparentColor, 1.0F - sTransparencyThreshold), modPaint.LightColor(oTransparentColor, 1.0F - sTransparencyThreshold))
                                Select Case iImageResizeMode
                                    Case cIItemImage.ImageResizeModeEnum.Scaled
                                        Call modPaint.DrawScaledImage(Graphics, oRotatedImage, oBounds, oImageAttributes)
                                    Case cIItemImage.ImageResizeModeEnum.Stretched
                                        Call modPaint.DrawStretchedImage(Graphics, oRotatedImage, oBounds, oImageAttributes)
                                End Select
                            End Using
                        End If
                        Call MyBase.Caches(PaintOptions).Paint(Graphics, PaintOptions, Options)
                    End If
                Catch
                End Try
                If PaintOptions.ShowSegmentBindings Then
                    Call modPaint.PaintPointToSegmentBindings(Graphics, MyBase.Survey, Me, Selected)
                End If
            End If
        End Sub

        Friend Overrides Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
            If Options And SVGOptionsEnum.Images Then
                Dim oBounds As RectangleF = GetBounds()
                Dim oSVGItem As XmlElement = modSVG.CreateImage(SVG, PaintOptions, oBounds, oRotatedImage, sRotateBy, iImageResizeMode = cIItemImage.ImageResizeModeEnum.Scaled)
                Return oSVGItem
            End If
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As cFile, ByVal item As XmlElement)
            Call MyBase.New(Survey, Design, Layer, File, item)
            sImageID = modXML.GetAttributeValue(item, "imageid", Guid.NewGuid.ToString)
            If sImageID = "" Then sImageID = Guid.NewGuid.ToString
            Select Case File.FileFormat
                Case cFile.FileFormatEnum.CSX
                    oImage = modPaint.ByteArrayToBitmap(Convert.FromBase64String(modXML.GetAttributeValue(item, "image")))
                Case cFile.FileFormatEnum.CSZ
                    Dim sImagePath As String = modXML.GetAttributeValue(item, "image")
                    oImage = modPaint.ByteArrayToBitmap(DirectCast(File.Data(sImagePath), Storage.cStorageItemFile).Stream.ToArray)
            End Select
            sRotateBy = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "rby", 0))
            oTransparentColor = modXML.GetAttributeColor(item, "transparentcolor", Color.Transparent)
            sTransparencyThreshold = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "transparencythreshold", sDefaultTransparencyThreshold))
            iImageResizeMode = modXML.GetAttributeValue(item, "imageresizemode", cIItemImage.ImageResizeModeEnum.Scaled)
        End Sub

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oItem As XmlElement = MyBase.SaveTo(File, Document, Parent, Options)
            Call oItem.SetAttribute("imageid", sImageID)
            If Not (File.Options And cFile.FileOptionsEnum.DontSaveBinary) = cFile.FileOptionsEnum.DontSaveBinary Then
                Select Case File.FileFormat
                    Case cFile.FileFormatEnum.CSX
                        Call oItem.SetAttribute("image", Convert.ToBase64String(modPaint.BitmapToByteArray(oImage, Drawing.Imaging.ImageFormat.Png)))
                    Case cFile.FileFormatEnum.CSZ
                        Dim sImagePath As String = "_data\design\" & sImageID & ".png"
                        Dim oImageStorage As Storage.cStorageItemFile = File.Data.AddFile(sImagePath)
                        Call oImageStorage.Write(modPaint.BitmapToByteArray(oImage, Drawing.Imaging.ImageFormat.Png))
                        Call oItem.SetAttribute("image", sImagePath)
                End Select
            End If
            If sRotateBy <> 0.0F Then Call oItem.SetAttribute("rby", modNumbers.NumberToString(sRotateBy))
            If Not oTransparentColor = Color.Transparent Then Call oItem.SetAttribute("transparentcolor", oTransparentColor.ToArgb)
            If sTransparencyThreshold <> sDefaultTransparencyThreshold Then Call oItem.SetAttribute("transparencythreshold", modNumbers.NumberToString(sTransparencyThreshold, "0.00"))
            If iImageResizeMode <> cIItemImage.ImageResizeModeEnum.Scaled Then Call oItem.SetAttribute("imageresizemode", iImageResizeMode.ToString("D"))
            Return oItem
        End Function

        Public Sub ImageRescale(ByVal Scale As Single) Implements cIItemImage.ImageRescale
            Dim sNewWidth As Single = oImage.Width * Scale
            Dim sNewHeight As Single = oImage.Height * Scale
            Dim oNewImage As Image = New Bitmap(sNewWidth, sNewHeight, Imaging.PixelFormat.Format24bppRgb)
            Using oGraphics As Graphics = Graphics.FromImage(oNewImage)
                Call oGraphics.DrawImage(oImage, 0, 0, sNewWidth, sNewHeight)
                oImage = oNewImage
                Call MyBase.Caches.Invalidate()
            End Using
        End Sub

        Public ReadOnly Property ImageSize() As SizeF Implements cIItemImage.ImageSize
            Get
                If oImage Is Nothing Then
                    Return New SizeF(-1, -1)
                Else
                    Return oImage.Size
                End If
            End Get
        End Property

        Public ReadOnly Property ImageResolution() As Point Implements cIItemImage.ImageResolution
            Get
                If oImage Is Nothing Then
                    Return New Point(-1, -1)
                Else
                    Return New Point(modNumbers.MathRound(oImage.HorizontalResolution, 0), modNumbers.MathRound(oImage.VerticalResolution, 0))
                End If
            End Get
        End Property

        Public Property Image() As Image Implements cIItemImage.Image
            Get
                Return oImage
            End Get
            Set(ByVal value As Image)
                If Not value Is oImage Then
                    sImageID = Guid.NewGuid.ToString
                    oImage = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property ImageResizeMode() As cIItemImage.ImageResizeModeEnum Implements cIItemImage.ImageResizeMode
            Get
                Return iImageResizeMode
            End Get
            Set(ByVal value As cIItemImage.ImageResizeModeEnum)
                If iImageResizeMode <> value Then
                    iImageResizeMode = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Overrides ReadOnly Property CanImportGeneric As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Function FromGeneric(ByVal Item As cItemGeneric, Optional ByVal Clear As Boolean = False) As Boolean
            Return False
        End Function

    End Class
End Namespace
