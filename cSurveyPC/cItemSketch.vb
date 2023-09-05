Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings

Namespace cSurvey.Design.Items
    Public Class cItemSketch
        Inherits cItem
        Implements cIItemSketch

        Public Class cExtraStation
            Inherits cStation

            Private sDistance As Single

            Friend Sub New(ByVal Survey As cSurvey, ByVal Point As Point, ByVal TrigPoint As cTrigPoint, Distance As Single)
                MyBase.New(Survey, Point, TrigPoint)
                sDistance = Distance
            End Sub

            Friend Sub New(ByVal Survey As cSurvey, ByVal Station As XmlElement)
                MyBase.New(Survey, Station)
                sDistance = modNumbers.StringToSingle(modXML.GetAttributeValue(Station, "d", 0))
            End Sub

            Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
                Dim oXmlStation As XmlElement = MyBase.SaveTo(File, Document, Parent)
                Call oXmlStation.SetAttribute("d", modNumbers.NumberToString(sDistance))
                Call Parent.AppendChild(oXmlStation)
                Return oXmlStation
            End Function

            Public Property Distance() As Single
                Get
                    Return sDistance
                End Get
                Set(value As Single)
                    sDistance = value
                End Set
            End Property
        End Class

        Public Class cStation
            Private oSurvey As cSurvey
            Private oPoint As Point
            Private oTrigPoint As cTrigPoint

            Public Function IsValid() As Boolean
                If oTrigPoint Is Nothing Then
                    Return False
                Else
                    If oSurvey.TrigPoints.Contains(oTrigPoint) Then
                        Return Not oTrigPoint.Data.IsOrphan
                    Else
                        Return False
                    End If
                End If
            End Function

            Public Function IsOrphan() As Boolean
                If Not oTrigPoint Is Nothing AndAlso oSurvey.TrigPoints.Contains(oTrigPoint) Then
                    Return oTrigPoint.Data.IsOrphan
                Else
                    Return True
                End If
            End Function

            Public Property Point As Point
                Get
                    Return oPoint
                End Get
                Set(ByVal value As Point)
                    oPoint = value
                End Set
            End Property

            Public ReadOnly Property Name As String
                Get
                    If IsValid() Then
                        Return oTrigPoint.Name
                    Else
                        Return modMain.GetLocalizedString("itemsketch.notvalidname")
                    End If
                End Get
            End Property

            Public Property TrigPoint As cTrigPoint
                Get
                    Return oTrigPoint
                End Get
                Set(value As cTrigPoint)
                    oTrigPoint = value
                End Set
            End Property

            Friend Sub New(ByVal Survey As cSurvey, ByVal Point As Point, ByVal TrigPoint As cTrigPoint)
                oSurvey = Survey
                oPoint = Point
                oTrigPoint = TrigPoint
            End Sub

            Friend Sub New(ByVal Survey As cSurvey, ByVal Station As XmlElement)
                oSurvey = Survey
                oPoint = New Point(Station.GetAttribute("x"), Station.GetAttribute("y"))
                oTrigPoint = oSurvey.TrigPoints(Station.GetAttribute("trigpoint"))
            End Sub

            Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
                Dim oXmlStation As XmlElement = Document.CreateElement("station")
                Call oXmlStation.SetAttribute("x", Point.X)
                Call oXmlStation.SetAttribute("y", Point.Y)
                Call oXmlStation.SetAttribute("trigpoint", oTrigPoint.Name)
                Call Parent.AppendChild(oXmlStation)
                Return oXmlStation
            End Function
        End Class

        Public Class cStations
            Implements IEnumerable
            Private oSurvey As cSurvey

            Private oItems As List(Of cStation)

            Public Function GetValidStations() As List(Of cStation)
                Return oItems.Where(Function(item) item.IsValid).ToList
            End Function

            Public Sub Rebind()
                Dim oStationsToRemove As List(Of cStation) = New List(Of cStation)(oItems.Where(Function(item) Not item.IsValid))
                For Each oStation As cStation In oStationsToRemove
                    Call oItems.Remove(oStation)
                Next
            End Sub

            Public Function Contains(Station As cStation) As Boolean
                Return oItems.Contains(Station)
            End Function

            Public Sub Clear()
                Call oItems.Clear()
            End Sub

            Public Sub Add(ByVal Point As Point, ByVal TrigPoint As cTrigPoint)
                Dim oStation As cStation = New cStation(oSurvey, Point, TrigPoint)
                Call oItems.Add(oStation)
            End Sub

            Public Sub Add(ByVal Point As Point, ByVal TrigPoint As cTrigPoint, Distance As Single)
                Dim oStation As cExtraStation = New cExtraStation(oSurvey, Point, TrigPoint, Distance)
                Call oItems.Add(oStation)
            End Sub

            Public Sub Remove(ByVal index As Integer)
                Call oItems.RemoveAt(index)
            End Sub

            Public Sub Remove(ByVal Item As cStation)
                Call oItems.Remove(Item)
            End Sub

            Default Public ReadOnly Property Items(ByVal Index As Integer) As cStation
                Get
                    Return oItems(Index)
                End Get
            End Property

            Public Function HasValidStations() As Boolean
                If oItems.Where(Function(item) TypeOf item Is cStation AndAlso item.IsValid).Count < 2 Then
                    Return False
                Else
                    Return True
                    'Return oItems.Select(Function(item) item.IsValid).Count > 1
                End If
            End Function

            Public ReadOnly Property Count As Integer
                Get
                    Return oItems.Count
                End Get
            End Property

            Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
                Return oItems.GetEnumerator
            End Function

            Friend Sub New(ByVal Survey As cSurvey)
                oSurvey = Survey
                oItems = New List(Of cStation)
            End Sub

            Friend Sub New(ByVal Survey As cSurvey, ByVal Stations As XmlElement)
                oSurvey = Survey
                oItems = New List(Of cStation)
                For Each oXMLStation As XmlElement In Stations.ChildNodes
                    Dim oStation As cStation
                    If oXMLStation.HasAttribute("d") Then
                        oStation = New cExtraStation(oSurvey, oXMLStation)
                    Else
                        oStation = New cStation(oSurvey, oXMLStation)
                    End If
                    If Not IsNothing(oStation.TrigPoint) Then
                        Call oItems.Add(oStation)
                    End If
                Next
            End Sub

            Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
                Dim oXmlStations As XmlElement = Document.CreateElement("stations")
                For Each oStation As cStation In GetValidStations()
                    Call oStation.SaveTo(File, Document, oXmlStations)
                Next
                Call Parent.AppendChild(oXmlStations)
                Return oXmlStations
            End Function
        End Class

        Private oSurvey As cSurvey

        Private oStations As cStations

        Private sImageID As String
        Private oImage As Bitmap
        Private sDesignImageID As String
        Private oDesignImage As Bitmap

        Private oTransparentColor As Color
        Private sTransparencyThreshold As Single
        Private sDefaultTransparencyThreshold As Single = 0.95

        Private bManualAdjust As Boolean
        Private bMorphingDisabled As Boolean

        Public Overrides ReadOnly Property CanBeCopied As Boolean
            Get
                Return False
            End Get
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
                Return False
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

        Public Overrides ReadOnly Property HaveTransparency As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeWarped As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeMoved As Boolean
            Get
                Return bManualAdjust
            End Get
        End Property

        Public Property MorphingDisabled As Boolean Implements cIItemSketch.MorphingDisabled
            Get
                Return bMorphingDisabled
            End Get
            Set(ByVal value As Boolean)
                If bMorphingDisabled <> value Then
                    bMorphingDisabled = value
                    If Not bMorphingDisabled Then
                        Call oSurvey.Invalidate()
                    End If
                End If
            End Set
        End Property

        Public Property ManualAdjust As Boolean Implements cIItemSketch.ManualAdjust
            Get
                Return bManualAdjust
            End Get
            Set(ByVal value As Boolean)
                If bManualAdjust <> value Then
                    bManualAdjust = value
                    If Not bManualAdjust Then
                        Call oSurvey.Invalidate()
                    End If
                End If
            End Set
        End Property

        Public Overrides ReadOnly Property HaveSketch As Boolean
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

        Public Overrides ReadOnly Property HaveImage As Boolean
            Get
                Return False
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

        Public ReadOnly Property Stations() As cStations
            Get
                Return oStations
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum, ByVal Image As Bitmap)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.Sketch, Category)
            oSurvey = Survey

            sImageID = Guid.NewGuid.ToString
            sDesignImageID = Guid.NewGuid.ToString

            oImage = New Bitmap(Image)
            oDesignImage = New Bitmap(Image)

            oTransparentColor = Color.Transparent
            sTransparencyThreshold = sDefaultTransparencyThreshold

            oStations = New cStations(Survey)
            Call oSurvey.Sketches.Add(Me)
        End Sub

        Public Overrides ReadOnly Property HaveBrush As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property BindMode As cItem.BindModeEnum
            Get
                Return BindModeEnum.Special
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
                Return False
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
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property MaxPointsCount As Integer
            Get
                Return 99999
            End Get
        End Property

        Friend Overrides Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
            If Options And SVGOptionsEnum.Images Then
                Dim oBounds As RectangleF = GetBounds()
                Dim oSVGItem As XmlElement = modSVG.CreateImage(SVG, PaintOptions, oBounds, oDesignImage, 0, True)
                Return oSVGItem
            End If
        End Function

        'Friend Overrides Function ToSvg(ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlDocument
        '    Dim oSVG As XmlDocument = modSVG.CreateSVG
        '    Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions, Options))
        '    Return oSVG
        'End Function

        Friend Overrides Sub Render(ByVal Graphics As System.Drawing.Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            With MyBase.Caches(PaintOptions)
                If .Invalidated Then
                    Call .Clear()
                    Using oPath As GraphicsPath = New GraphicsPath
                        Call oPath.AddLines(MyBase.Points.GetPoints)
                        Call .Add(cDrawCacheItem.cDrawCacheItemType.Border, oPath, Nothing, Nothing, Nothing)
                    End Using
                    Call .Rendered()
                End If
            End With
        End Sub

        Friend Overrides Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            If MyBase.Points.Count >= 1 Then
                Call Render(Graphics, PaintOptions, Options, Selected)
                Try
                    If Not PaintOptions.IsDesign OrElse (PaintOptions.IsDesign And Not MyBase.HiddenInDesign) Then
                        Dim oBounds As RectangleF = GetBounds()
                        If oTransparentColor = Color.Transparent Then
                            Call Graphics.DrawImage(oDesignImage, oBounds)
                        Else
                            Using oImageAttributes As System.Drawing.Imaging.ImageAttributes = New System.Drawing.Imaging.ImageAttributes
                                Call oImageAttributes.SetColorKey(modPaint.DarkColor(oTransparentColor, 1.0F - sTransparencyThreshold), modPaint.LightColor(oTransparentColor, 1.0F - sTransparencyThreshold))
                                Call modPaint.DrawStretchedImage(Graphics, oDesignImage, oBounds, oImageAttributes)
                            End Using
                        End If
                        If bMorphingDisabled Then
                            Call Graphics.DrawRectangle(New Pen(Color.FromArgb(100, Color.DimGray), cEditPaintObjects.FilettoPenWidth), oBounds.X, oBounds.Y, oBounds.Width, oBounds.Height)
                        End If
                    End If
                Catch
                End Try
            End If
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As cFile, ByVal item As XmlElement)
            Call MyBase.New(Survey, Design, Layer, File, item)
            oSurvey = Survey

            sImageID = modXML.GetAttributeValue(item, "imageid", Guid.NewGuid.ToString)
            sDesignImageID = modXML.GetAttributeValue(item, "designimageid", Guid.NewGuid.ToString)
            If sImageID = "" Then sImageID = Guid.NewGuid.ToString
            If sDesignImageID = "" Then sDesignImageID = Guid.NewGuid.ToString

            Select Case File.FileFormat
                Case cFile.FileFormatEnum.CSX
                    oImage = modPaint.ByteArrayToBitmap(Convert.FromBase64String(modXML.GetAttributeValue(item, "image")))
                    Try
                        oDesignImage = modPaint.ByteArrayToBitmap(Convert.FromBase64String(modXML.GetAttributeValue(item, "designimage")))
                    Catch
                        If Not oImage Is Nothing Then oDesignImage = New Bitmap(oImage)
                    End Try
                Case cFile.FileFormatEnum.CSZ
                    Dim sImagePath As String = modXML.GetAttributeValue(item, "image")
                    oImage = modPaint.ByteArrayToBitmap(DirectCast(File.Data(sImagePath), Storage.cStorageItemFile).Stream.ToArray)
                    Try
                        Dim sDesignImagePath As String = modXML.GetAttributeValue(item, "designimage")
                        oDesignImage = modPaint.ByteArrayToBitmap(DirectCast(File.Data(sDesignImagePath), Storage.cStorageItemFile).Stream.ToArray)
                    Catch
                        If Not oImage Is Nothing Then oDesignImage = New Bitmap(oImage)
                    End Try
            End Select

            Try
                oStations = New cStations(Survey, item.Item("stations"))
            Catch
                oStations = New cStations(Survey)
            End Try

            oTransparentColor = modXML.GetAttributeColor(item, "transparentcolor", Color.Transparent)
            sTransparencyThreshold = modXML.GetAttributeValue(item, "transparencythreshold", sDefaultTransparencyThreshold)

            bManualAdjust = modXML.GetAttributeValue(item, "manualadjust")
            If modOpeningFlags.OFMorphingDisabledEnabled Then
                bMorphingDisabled = modOpeningFlags.OFMorphingDisabled
            Else
                bMorphingDisabled = modXML.GetAttributeValue(item, "morphingdisabled")
            End If
        End Sub

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oItem As XmlElement = MyBase.SaveTo(File, Document, Parent, Options)

            Call oItem.SetAttribute("imageid", sImageID)
            Call oItem.SetAttribute("designimageid", sDesignImageID)

            If Not (File.Options And cFile.FileOptionsEnum.DontSaveBinary) = cFile.FileOptionsEnum.DontSaveBinary Then
                Select Case File.FileFormat
                    Case cFile.FileFormatEnum.CSX
                        Call oItem.SetAttribute("image", Convert.ToBase64String(modPaint.BitmapToByteArray(oImage, Drawing.Imaging.ImageFormat.Png)))
                        Call oItem.SetAttribute("designimage", Convert.ToBase64String(modPaint.BitmapToByteArray(oDesignImage, Drawing.Imaging.ImageFormat.Png)))
                    Case cFile.FileFormatEnum.CSZ
                        Dim sImagePath As String = "_data\design\" & sImageID & ".png"
                        Dim oImageStorage As Storage.cStorageItemFile = File.Data.AddFile(sImagePath)
                        Call oImageStorage.Write(modPaint.BitmapToByteArray(oImage, Drawing.Imaging.ImageFormat.Png))
                        Call oItem.SetAttribute("image", sImagePath)
                        Dim sDesignImagePath As String = "_data\design\" & sDesignImageID & ".png"
                        Dim oDesignImageStorage As Storage.cStorageItemFile = File.Data.AddFile(sDesignImagePath)
                        Call oDesignImageStorage.Write(modPaint.BitmapToByteArray(oDesignImage, Drawing.Imaging.ImageFormat.Png))
                        Call oItem.SetAttribute("designimage", sDesignImagePath)
                End Select
            End If

            If Not oTransparentColor = Color.Transparent Then Call oItem.SetAttribute("transparentcolor", oTransparentColor.ToArgb)
            If sTransparencyThreshold <> sDefaultTransparencyThreshold Then Call oItem.SetAttribute("transparencythreshold", sTransparencyThreshold)

            If bManualAdjust Then Call oItem.SetAttribute("manualadjust", "1")
            If bMorphingDisabled Then oItem.SetAttribute("morphingdisabled", "1")
            Call oStations.SaveTo(File, Document, oItem)
            Return oItem
        End Function

        Public ReadOnly Property ImageSize() As SizeF Implements cIItemSketch.ImageSize
            Get
                Return oImage.Size
            End Get
        End Property

        Public ReadOnly Property ImageResolution() As Point Implements cIItemSketch.ImageResolution
            Get
                Return New Point(modnumbers.mathround(oImage.HorizontalResolution, 0), modnumbers.mathround(oImage.VerticalResolution, 0))
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

        Public Property Image() As Image Implements cIItemSketch.Image
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

        Friend Property DesignImage() As Image
            Get
                Return oDesignImage
            End Get
            Set(ByVal value As Image)
                If Not value Is oDesignImage Then
                    sDesignImageID = Guid.NewGuid.ToString
                    oDesignImage = value
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
