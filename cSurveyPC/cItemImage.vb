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
                sTransparencyThreshold = value
            End Set
        End Property

        Public Overrides ReadOnly Property CanBeWarped As Boolean
            Get
                Return False
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
                Return False
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

            oImage = Image

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
                Return BindModeEnum.AllPoints
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

        Friend Overrides Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
            Dim oSVGGroup As XmlElement = modSVG.CreateGroup(SVG, MyBase.Layer.Type.ToString)
            Return oSVGGroup
        End Function

        Friend Overrides Function ToSvg(ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlDocument
            Dim oSVG As XmlDocument = modSVG.CreateSVG
            Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions, Options))
            Return oSVG
        End Function

        Public Overrides Sub ResizeBy(ByVal ScaleWidth As Single, ByVal ScaleHeight As Single)
            If ScaleWidth < 0 And ScaleHeight > 0 Then
                Call oImage.RotateFlip(RotateFlipType.RotateNoneFlipX)
            ElseIf ScaleWidth > 0 And ScaleHeight < 0 Then
                Call oImage.RotateFlip(RotateFlipType.RotateNoneFlipY)
            ElseIf ScaleWidth < 0 And ScaleHeight < 0 Then
                Call oImage.RotateFlip(RotateFlipType.RotateNoneFlipXY)
            End If
            Call MyBase.ResizeBy(ScaleWidth, ScaleHeight)
        End Sub

        Friend Overrides Sub Render(ByVal Graphics As System.Drawing.Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            With MyBase.Caches(PaintOptions)
                If .Invalidated Then
                    Call .Clear()
                    Using oPath As GraphicsPath = New GraphicsPath
                        Call oPath.AddLines(MyBase.Points.GetPoints)
                        Call .Add(Drawings.cDrawCacheItem.cDrawCacheItemType.Border, oPath, Nothing, Nothing, Nothing)
                    End Using
                    Call .Rendered()
                End If
            End With
        End Sub

        Friend Overrides Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            If MyBase.Points.Count > 1 Then
                Call Render(Graphics, PaintOptions, Options, Selected)
                Try
                    Dim oBounds As RectangleF = GetBounds()
                    If Not PaintOptions.IsDesign Or (PaintOptions.IsDesign And Not MyBase.HiddenInDesign) Then
                        Select Case iImageResizeMode
                            Case cIItemImage.ImageResizeModeEnum.Scaled
                                'in scala
                                modPaint.DrawScaledImage(Graphics, oImage, oBounds)
                            Case cIItemImage.ImageResizeModeEnum.Stretched
                                '"stirata"
                                Call Graphics.DrawImage(oImage, oBounds)
                        End Select
                        Call MyBase.Caches(PaintOptions).Paint(Graphics, PaintOptions, Options)
                    End If
                Catch
                End Try
            End If
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As Storage.cFile, ByVal item As XmlElement)
            Call MyBase.New(Survey, Design, Layer, File, item)
            sImageID = modXML.GetAttributeValue(item, "imageid", Guid.NewGuid.ToString)
            If sImageID = "" Then sImageID = Guid.NewGuid.ToString
            Select Case File.FileFormat
                Case Storage.cFile.FileFormatEnum.CSX
                    Try
                        Dim oms As IO.MemoryStream = New IO.MemoryStream(Convert.FromBase64String(modXML.GetAttributeValue(item, "image")))
                        oImage = New Bitmap(oms)
                        'Call oms.Dispose()
                    Catch
                    End Try
                Case Storage.cFile.FileFormatEnum.CSZ
                    Try
                        Dim sImagePath As String = modXML.GetAttributeValue(item, "image")
                        oImage = New Bitmap(DirectCast(File.Data(sImagePath), Storage.cStorageItemFile).Stream)
                    Catch
                    End Try
            End Select
            oTransparentColor = modXML.GetAttributeColor(item, "transparentcolor", Color.Transparent)
            sTransparencyThreshold = modXML.GetAttributeValue(item, "transparencythreshold", sDefaultTransparencyThreshold)
            iImageResizeMode = modXML.GetAttributeValue(item, "imageresizemode", cIItemImage.ImageResizeModeEnum.Scaled)
        End Sub

        Friend Overrides Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oItem As XmlElement = MyBase.SaveTo(File, Document, Parent, Options)
            Call oItem.SetAttribute("imageid", sImageID)
            If Not (File.Options And Storage.cFile.FileOptionsEnum.DontSaveBinary) = Storage.cFile.FileOptionsEnum.DontSaveBinary Then
                Select Case File.FileFormat
                    Case Storage.cFile.FileFormatEnum.CSX
                        Using oms As IO.MemoryStream = New IO.MemoryStream
                            Using oTemp As Bitmap = New Bitmap(oImage)
                                Call oTemp.Save(oms, Drawing.Imaging.ImageFormat.Png)
                                Call oItem.SetAttribute("image", Convert.ToBase64String(oms.ToArray()))
                                Call oms.Close()
                            End Using
                        End Using
                    Case Storage.cFile.FileFormatEnum.CSZ
                        Dim sImagePath As String = "_data\design\" & sImageID & ".png"
                        Dim oImageStorage As Storage.cStorageItemFile = File.Data.AddFile(sImagePath)
                        Using oTemp As Bitmap = New Bitmap(oImage)
                            Call oTemp.Save(oImageStorage.Stream, Drawing.Imaging.ImageFormat.Png)
                            Call oItem.SetAttribute("image", sImagePath)
                        End Using
                End Select
            End If
            If Not oTransparentColor = Color.Transparent Then Call oItem.SetAttribute("transparentcolor", oTransparentColor.ToArgb)
            If sTransparencyThreshold <> sDefaultTransparencyThreshold Then Call oItem.SetAttribute("transparencythreshold", sTransparencyThreshold)
            If iImageResizeMode <> cIItemImage.ImageResizeModeEnum.Scaled Then Call oItem.SetAttribute("imageresizemode", iImageResizeMode.ToString("D"))
            Return oItem
        End Function

        Public Sub ImageRescale(ByVal Scale As Single) Implements cIItemImage.ImageRescale
            Dim sNewWidth As Single = oImage.Width * Scale
            Dim sNewHeight As Single = oImage.Height * Scale
            Dim oNewImage As Image = New Bitmap(sNewWidth, sNewHeight, Imaging.PixelFormat.Format24bppRgb)
            Dim oGraphics As Graphics = Graphics.FromImage(oNewImage)
            Call oGraphics.DrawImage(oImage, 0, 0, sNewWidth, sNewHeight)
            oImage = oNewImage
            Call oGraphics.Dispose()
        End Sub

        Public ReadOnly Property ImageSize() As SizeF Implements cIItemImage.ImageSize
            Get
                Return oImage.Size
            End Get
        End Property

        Public ReadOnly Property ImageResolution() As Point Implements cIItemImage.ImageResolution
            Get
                Return New Point(modNumbers.MathRound(oImage.HorizontalResolution, 0), modNumbers.MathRound(oImage.VerticalResolution, 0))
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
                End If
            End Set
        End Property

        Public Property ImageResizeMode() As cIItemImage.ImageResizeModeEnum Implements cIItemImage.ImageResizeMode
            Get
                Return iImageResizeMode
            End Get
            Set(ByVal value As cIItemImage.ImageResizeModeEnum)
                iImageResizeMode = value
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
