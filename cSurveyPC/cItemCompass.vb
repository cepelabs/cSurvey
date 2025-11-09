Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings

Namespace cSurvey.Design.Items
    Public Class cItemCompass
        Inherits cItem
        Implements cIItemText
        Implements cIItemVerticalLineableText
        Implements cIItemLineableText
        Implements cIItemCompass
        Implements cIItemSizable

        Private oSurvey As cSurvey

        Private oClipart As cClipart
        Private oDataBounds As RectangleF
        Private sClipartScale As Single
        Private bUseClipartScaleOnText As Boolean
        Private bUseTextScaleOnClipart As Boolean

        Private iMode As cIItemCompass.CompassModeEnum
        Private iNorth As cIItemCompass.NorthTypeEnum
        Private iYear As Integer

        Private sText As String
        Private WithEvents oFont As cItemFont

        Private iTextSize As cIItemSizable.SizeEnum
        Private iTextVerticalAlignment As cIItemVerticalLineableText.TextVerticalAlignmentEnum
        Private iTextAlignment As cIItemLineableText.TextAlignmentEnum

        Private bHideNorthValue As Boolean

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

        Private Sub oFont_OnChanged(ByVal Sender As cItemFont) Handles oFont.OnChanged
            Call MyBase.Caches.Invalidate()
        End Sub

        Private Sub oFont_OnRender(sender As cItemFont, RenderArgs As cItemFont.cRenderArgs) Handles oFont.OnRender
            If HaveTransparency Then
                RenderArgs.Transparency = MyBase.Transparency
            End If
        End Sub

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

        Public Property Clipart As cClipart Implements cIItemCompass.Clipart
            Get
                Return oClipart
            End Get
            Set(value As cClipart)
                If Not oClipart Is value Then
                    oClipart = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartScale As Single
            Get
                Return sClipartScale
            End Get
            Set(value As Single)
                If sClipartScale <> value Then
                    sClipartScale = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property UseClipartScaleOnText As Boolean
            Get
                Return bUseClipartScaleOnText
            End Get
            Set(value As Boolean)
                If bUseClipartScaleOnText <> value Then
                    bUseClipartScaleOnText = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property UseTextScaleOnClipart As Boolean
            Get
                Return bUseTextScaleOnClipart
            End Get
            Set(value As Boolean)
                If bUseTextScaleOnClipart <> value Then
                    bUseTextScaleOnClipart = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Overrides ReadOnly Property HaveTransparency As Boolean
            Get
                Return True
            End Get
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

        Public Overrides ReadOnly Property HaveSketch As Boolean
            Get
                Return False
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

        Public Overrides ReadOnly Property HaveQuota As Boolean
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

        Public Overrides ReadOnly Property HaveImage As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeClipped As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HaveText As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HaveLineType As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveFont As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeRotated As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property BindMode As cItem.BindModeEnum
            Get
                Return BindModeEnum.CenterPoint
            End Get
        End Property

        Public Overrides ReadOnly Property HaveEditablePoints As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property MaxPointsCount As Integer
            Get
                Return 1
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
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HaveBrush As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HavePen As Boolean
            Get
                Return True
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum, ByVal Data As Object, ByVal DataFormat As cIItemClipartBase.cClipartDataFormatEnum)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.Compass, Category)
            oSurvey = Survey
            Select Case DataFormat
                Case cIItemClipartBase.cClipartDataFormatEnum.SVGFile
                    oClipart = oSurvey.Signs.Cliparts.Add(Data)
                Case cIItemClipartBase.cClipartDataFormatEnum.SVGData
                    oClipart = oSurvey.Signs.Cliparts.Add("", Data)
                Case Else
                    oClipart = oSurvey.Signs.Cliparts(Data)
            End Select
            sClipartScale = 1
            bUseTextScaleOnClipart = True
            bUseClipartScaleOnText = False

            iNorth = cIItemCompass.NorthTypeEnum.Geographic
            iMode = cIItemCompass.CompassModeEnum.Auto
            iYear = 0

            oFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.Title)
            sText = ""
            iTextSize = cIItemSizable.SizeEnum.Default
            iTextAlignment = cIItemLineableText.TextAlignmentEnum.Left
            iTextVerticalAlignment = cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle

            bHideNorthValue = False

            MyBase.DesignAffinity = DesignAffinityEnum.Extra

            Call pLoadData()
            Call FixBound()
        End Sub

        Friend Overrides Sub Render(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            Dim oCache As cDrawCache = MyBase.Caches(PaintOptions)
            With oCache
                If .Invalidated Then
                    Call .Clear()

                    Dim sTextScale As Single = GetTextScaleFactor(PaintOptions)
                    Dim sClipartScale As Single = GetClipartScaleFactor(PaintOptions)

                    Dim oBasePoint As PointF = MyBase.Points(0).Point

                    Using oPaths As cDrawPaths = oClipart.Clipart.ClonePaths
                        Using oScaleMatrix = New Matrix
                            Call oScaleMatrix.Scale(sClipartScale, sClipartScale)
                            Call oPaths.Transform(oScaleMatrix)
                        End Using
                        Call oPaths.Render(Me, Graphics, PaintOptions, Options, SelectionModeEnum.Selected, oCache)
                    End Using

                    Using oSF As StringFormat = New StringFormat
                        oSF.Alignment = StringAlignment.Center
                        oSF.LineAlignment = StringAlignment.Far
                        Using oPath As GraphicsPath = New GraphicsPath
                            'dimensiono il testo se rischiesto (il fattore di scala sarà da parametrizzare in qualche modo)
                            Dim sNorthText As String = modPaint.ReplaceGlobalTags(oSurvey, sText)
                            If Not bHideNorthValue Then
                                If sNorthText <> "" Then sNorthText = sNorthText & " "
                                If iMode = cIItemCompass.CompassModeEnum.Auto Then
                                    If Not MyBase.Survey.Properties.GPS.Enabled AndAlso MyBase.Survey.Properties.NordCorrectionMode = cSurvey.NordCorrectionModeEnum.None Then
                                        sNorthText &= "Nm"
                                        Dim oYears As List(Of Integer) = MyBase.Survey.Properties.Sessions.GetSurveyYears
                                        If oYears.Count = 1 Then
                                            sNorthText &= " " & oYears(0)
                                        ElseIf oYears.Count > 1 Then
                                            sNorthText &= " #error#"
                                        Else
                                            sNorthText &= " " & Today.Year
                                        End If
                                    Else
                                        sNorthText = "N"
                                    End If
                                Else
                                    Select Case iNorth
                                        Case cIItemCompass.NorthTypeEnum.Geographic
                                            sNorthText &= "N"
                                        Case cIItemCompass.NorthTypeEnum.Magnetic
                                            sNorthText &= "Nm"
                                            If iYear = 0 Then
                                                sNorthText &= " " & Today.Year
                                            Else
                                                sNorthText &= " " & iYear
                                            End If
                                    End Select
                                End If
                            End If
                            If sNorthText <> "" Then
                                Using oTextPath As GraphicsPath = oFont.GetPath(PaintOptions, sNorthText, oSF)
                                    Using oTextMatrix = New Matrix
                                        Call oTextMatrix.Scale(sTextScale, sTextScale, MatrixOrder.Append)
                                        Call oTextPath.Transform(oTextMatrix)
                                    End Using
                                    Dim oTextBound As RectangleF = oTextPath.GetBounds
                                    Using oTextMatrix = New Matrix
                                        Call oTextMatrix.Translate(oCache.GetBounds.Width / 2, oCache.GetBounds.Top, MatrixOrder.Append)
                                        Call oTextPath.Transform(oTextMatrix)
                                    End Using
                                    Call oPath.AddPath(oTextPath, False)
                                End Using
                            End If
                            Call MyBase.Brush.Render(Graphics, PaintOptions, Options, False, oPath, oCache)
                        End Using
                    End Using

                    '..................................................................................................................................................................................................................
                    Call oCache.ResetOffset()
                    '..................................................................................................................................................................................................................

                    Dim sY As Single
                    Dim sX As Single
                    Select Case iTextAlignment
                        Case cIItemLineableText.TextAlignmentEnum.Center
                            sX = oBasePoint.X - oCache.GetBounds.Width / 2
                        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
                            sX = oBasePoint.X - oCache.GetBounds.Width
                        Case Else
                            sX = oBasePoint.X
                    End Select
                    Select Case iTextVerticalAlignment
                        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle
                            sY = oBasePoint.Y - oCache.GetBounds.Height / 2
                        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
                            sY = oBasePoint.Y - oCache.GetBounds.Height
                        Case Else
                            sY = oBasePoint.Y
                    End Select
                    Using oTraslateMatix As Matrix = New Matrix
                        Call oTraslateMatix.Translate(sX, sY)
                        Call oCache.Trasform(oTraslateMatix)
                    End Using

                    Call .Rendered()
                End If
            End With
        End Sub

        Friend Overrides Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            If MyBase.Points.Count > 0 Then
                Call Render(Graphics, PaintOptions, Options, Selected)
                If Not PaintOptions.IsDesign OrElse (PaintOptions.IsDesign And Not MyBase.HiddenInDesign) Then '
                    MyBase.HavePaintProblem = Not MyBase.Caches(PaintOptions).Paint(Graphics, PaintOptions, Options)
                    If PaintOptions.ShowSegmentBindings Then
                        Call modPaint.PaintPointToSegmentBindings(Graphics, MyBase.Survey, Me, Selected)
                    End If
                End If
            End If
        End Sub

        Friend Sub FixBound(Optional ByVal ForceBound As Boolean = False)
            If MyBase.Points.Count > 1 Or ForceBound Then
                Dim oxPoints() As PointF = MyBase.Points.GetPoints()
                Dim oRect As RectangleF
                For Each oxPoint As PointF In oxPoints
                    If modPaint.IsRectangleEmpty(oRect) Then
                        oRect = New RectangleF(oxPoint.X, oxPoint.Y, 0, 0)
                    Else
                        oRect = RectangleF.Union(oRect, New RectangleF(oxPoint.X, oxPoint.Y, 0, 0))
                    End If
                Next
                Call MyBase.Points.BeginUpdate()
                Call MyBase.Points.Clear()
                Call MyBase.Points.AddFromPaintPoint(oRect.Left + oRect.Width / 2, oRect.Top + oRect.Height / 2)
                Call MyBase.Points.EndUpdate()
            End If
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As cFile, ByVal item As XmlElement)
            Call MyBase.New(Survey, Design, Layer, File, item)
            oSurvey = Survey

            Dim sData As String = modXML.GetAttributeValue(item, "data", "")
            Dim iDataFormat As cIItemClipartBase.cClipartDataFormatEnum = modXML.GetAttributeValue(item, "dataformat", cIItemClipartBase.cClipartDataFormatEnum.SVGResource)
            Select Case iDataFormat
                Case cIItemClipartBase.cClipartDataFormatEnum.SVGFile
                    oClipart = oSurvey.Signs.Cliparts.Add(sData)
                Case cIItemClipartBase.cClipartDataFormatEnum.SVGData
                    oClipart = oSurvey.Signs.Cliparts.Add("", sData)
                Case cIItemClipartBase.cClipartDataFormatEnum.SVGResource
                    oClipart = oSurvey.Signs.Cliparts(sData)
            End Select
            If IsNothing(oClipart) Then
                oClipart = oSurvey.Signs.Cliparts.Add("defaultcompass", My.Resources.clipart_defaultcompass)
            End If
            sClipartScale = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "cs", 1.0))
            If sClipartScale = 0 Then sClipartScale = 1
            bUseTextScaleOnClipart = modXML.GetAttributeValue(item, "utsc", 1)
            bUseClipartScaleOnText = modXML.GetAttributeValue(item, "ucst", 0)

            iMode = modXML.GetAttributeValue(item, "m", Items.cIItemCompass.CompassModeEnum.Auto)
            iNorth = modXML.GetAttributeValue(item, "n", Items.cIItemCompass.NorthTypeEnum.Geographic)
            iYear = modXML.GetAttributeValue(item, "ny", 0)

            sText = modXML.GetAttributeValue(item, "text", "")
            Try
                oFont = New cItemFont(oSurvey, item.Item("font"))
            Catch ex As Exception
                oFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.Generic)
            End Try
            iTextSize = modXML.GetAttributeValue(item, "textsize")
            iTextAlignment = modXML.GetAttributeValue(item, "textalignment", cIItemLineableText.TextAlignmentEnum.Center)
            iTextVerticalAlignment = modXML.GetAttributeValue(item, "textverticalalignment", cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle)

            bHideNorthValue = modXML.GetAttributeValue(item, "hnv", 0)

            Call pLoadData()
            Call FixBound()
        End Sub

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oItem As XmlElement = MyBase.SaveTo(File, Document, Parent, Options)
            If (File.Options And cFile.FileOptionsEnum.[EmbedResource]) = cFile.FileOptionsEnum.[EmbedResource] Then
                Call oItem.SetAttribute("data", oClipart.Clipart.Data)
                Call oItem.SetAttribute("dataformat", cIItemClipartBase.cClipartDataFormatEnum.SVGData.ToString("D"))
            Else
                Call oItem.SetAttribute("data", oClipart.ID)
                Call oItem.SetAttribute("dataformat", cIItemClipartBase.cClipartDataFormatEnum.SVGResource.ToString("D"))
            End If

            If sClipartScale <> 1 Then Call oItem.SetAttribute("cs", modNumbers.NumberToString(sClipartScale, "0.00"))
            If Not bUseTextScaleOnClipart Then Call oItem.SetAttribute("utsc", "0")
            If bUseClipartScaleOnText Then Call oItem.SetAttribute("ucst", "1")

            If iMode <> Items.cIItemCompass.CompassModeEnum.Auto Then Call oItem.SetAttribute("m", iMode.ToString("D"))
            If iNorth <> Items.cIItemCompass.NorthTypeEnum.Geographic Then Call oItem.SetAttribute("n", iNorth.ToString("D"))
            If iYear <> 0 Then Call oItem.SetAttribute("ny", iYear)

            If "" & sText <> "" Then Call oItem.SetAttribute("text", "" & sText)
            Call oFont.SaveTo(File, Document, oItem, "font")
            If iTextSize <> cIItemSizable.SizeEnum.Default Then
                Call oItem.SetAttribute("textsize", iTextSize)
            End If
            If iTextAlignment <> cIItemLineableText.TextAlignmentEnum.Center Then
                Call oItem.SetAttribute("textalignment", iTextAlignment)
            End If
            If iTextVerticalAlignment <> cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle Then
                Call oItem.SetAttribute("textverticalalignment", iTextVerticalAlignment)
            End If

            If bHideNorthValue Then Call oItem.SetAttribute("hnv", "1")

            Return oItem
        End Function

        Public Property HideNorthValue As Boolean Implements cIItemCompass.HideNorthValue
            Get
                Return bHideNorthValue
            End Get
            Set(value As Boolean)
                If bHideNorthValue <> value Then
                    bHideNorthValue = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Private Sub pLoadData()
            oDataBounds = oClipart.Clipart.GetBounds
        End Sub

        Friend Overrides Function GetClipartScaleFactor(PaintOptions As cOptionsCenterline) As Single
            Dim sDesignClipartScaleFactor As Single = sClipartScale * MyBase.GetClipartScaleFactor(PaintOptions)
            If bUseTextScaleOnClipart Then
                Select Case iTextSize
                    Case cIItemSizable.SizeEnum.Default
                        Return 1 * sDesignClipartScaleFactor
                    Case cIItemSizable.SizeEnum.VerySmall
                        Return 0.25 * sDesignClipartScaleFactor
                    Case cIItemSizable.SizeEnum.Small
                        Return 0.5 * sDesignClipartScaleFactor
                    Case cIItemSizable.SizeEnum.Medium
                        Return 1 * sDesignClipartScaleFactor
                    Case cIItemSizable.SizeEnum.Large
                        Return 2 * sDesignClipartScaleFactor
                    Case cIItemSizable.SizeEnum.VeryLarge
                        Return 4 * sDesignClipartScaleFactor
                    Case cIItemSizable.SizeEnum.x6
                        Return 6 * sDesignClipartScaleFactor
                    Case cIItemSizable.SizeEnum.x8
                        Return 8 * sDesignClipartScaleFactor
                    Case cIItemSizable.SizeEnum.x10
                        Return 10 * sDesignClipartScaleFactor
                    Case cIItemSizable.SizeEnum.x12
                        Return 12 * sDesignClipartScaleFactor
                    Case cIItemSizable.SizeEnum.x16
                        Return 16 * sDesignClipartScaleFactor
                    Case cIItemSizable.SizeEnum.x20
                        Return 20 * sDesignClipartScaleFactor
                    Case cIItemSizable.SizeEnum.x24
                        Return 24 * sDesignClipartScaleFactor
                    Case cIItemSizable.SizeEnum.x32
                        Return 32 * sDesignClipartScaleFactor
                End Select
            Else
                Return sDesignClipartScaleFactor
            End If
        End Function

        Friend Overrides Function GetTextScaleFactor(PaintOptions As cOptionsCenterline) As Single
            Dim sTextScaleFactor As Single = If(bUseClipartScaleOnText, sClipartScale, 1) * MyBase.GetTextScaleFactor(PaintOptions)
            Select Case iTextSize
                Case cIItemSizable.SizeEnum.Default
                    Return 1 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.VerySmall
                    Return 0.25 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.Small
                    Return 0.5 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.Medium
                    Return 1 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.Large
                    Return 2 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.VeryLarge
                    Return 4 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x6
                    Return 6 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x8
                    Return 8 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x10
                    Return 10 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x12
                    Return 12 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x16
                    Return 16 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x20
                    Return 20 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x24
                    Return 24 * sTextScaleFactor
                Case cIItemSizable.SizeEnum.x32
                    Return 32 * sTextScaleFactor
            End Select
        End Function

        Friend Overrides Sub BindSegments()
            If MyBase.Cave = "" Then
                For Each oPoint As cPoint In MyBase.Points
                    oPoint.SegmentLocked = False
                    Call oPoint.BindSegment(Nothing)
                Next
            Else
                If MyBase.Points.Count > 0 Then
                    Dim oCenterPoint As PointF = GetCenterPoint()
                    Dim oSegment As cISegment = MyBase.Design.GetNearestSegment(MyBase.Cave, MyBase.Branch, MyBase.CrossSection, oCenterPoint.X, oCenterPoint.Y, MyBase.BindDesignType)
                    For Each oPoint As cPoint In MyBase.Points
                        If Not oPoint.SegmentLocked Then
                            Call oPoint.BindSegment(oSegment)
                        End If
                    Next
                End If
            End If
        End Sub

        'Public Overrides Function GetBounds() As RectangleF
        '    If MyBase.Points.Count > 0 Then
        '        Return MyBase.Caches.GetBounds
        '    End If
        'End Function

        Public Overrides Function GetBounds() As RectangleF
            If MyBase.Points.Count > 0 Then
                Dim oDesignBounds As RectangleF = MyBase.Caches.GetBounds
                If modPaint.IsRectangleEmpty(oDesignBounds) Then
                    Return MyBase.GetBounds()
                Else
                    Return oDesignBounds
                End If
            End If
        End Function

        'Friend Overrides Function ToSvg(ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlDocument
        '    Dim oSVG As cSVGWriter = modSVG.CreateSVG
        '    Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions, Options))
        '    Return oSVG
        'End Function

        'Friend Overrides Function ToSvgItem(ByVal SVG As cSVGWriter, ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
        '    Using oMatrix As Matrix = New Matrix
        '        If PaintOptions.DrawTranslation Then
        '            Dim oTranslation As SizeF = MyBase.Design.GetItemTranslation(Me)
        '            Call oMatrix.Translate(oTranslation.Width, oTranslation.Height)
        '        End If
        '        Dim oSVGItem As XmlElement = MyBase.Caches(PaintOptions).ToSvgItem(SVG, PaintOptions, Options, oMatrix)
        '        Call oSVGItem.SetAttribute("name", MyBase.Name)
        '        Call modSVG.AppendItemStyle(SVG, oSVGItem, MyBase.Brush, MyBase.Pen)
        '        Return oSVGItem
        '    End Using
        'End Function

        Public Overrides ReadOnly Property CanImportGeneric As Boolean
            Get
                Return False
            End Get
        End Property

        Public Property Mode As cIItemCompass.CompassModeEnum Implements cIItemCompass.Mode
            Get
                Return iMode
            End Get
            Set(value As cIItemCompass.CompassModeEnum)
                If value <> iMode Then
                    iMode = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property North As cIItemCompass.NorthTypeEnum Implements cIItemCompass.North
            Get
                Return iNorth
            End Get
            Set(value As cIItemCompass.NorthTypeEnum)
                If value <> iNorth Then
                    iNorth = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property Year As Integer Implements cIItemCompass.Year
            Get
                Return iYear
            End Get
            Set(value As Integer)
                If value <> iYear Then
                    iYear = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public ReadOnly Property AvaiableTextProperties As cIItemText.AvaiableTextPropertiesEnum Implements cIItemText.AvaiableTextProperties
            Get
                Return cIItemText.AvaiableTextPropertiesEnum.VerticalLineable Or cIItemText.AvaiableTextPropertiesEnum.Lineable Or cIItemText.AvaiableTextPropertiesEnum.Text
            End Get
        End Property

        Public Property TextAlignment As cIItemLineableText.TextAlignmentEnum Implements cIItemLineableText.TextAlignment
            Get
                Return iTextAlignment
            End Get
            Set(value As cIItemLineableText.TextAlignmentEnum)
                If iTextAlignment <> value Then
                    iTextAlignment = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property TextVerticalAlignment As cIItemVerticalLineableText.TextVerticalAlignmentEnum Implements cIItemVerticalLineableText.TextVerticalAlignment
            Get
                Return iTextVerticalAlignment
            End Get
            Set(value As cIItemVerticalLineableText.TextVerticalAlignmentEnum)
                If value <> iTextVerticalAlignment Then
                    iTextVerticalAlignment = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property TextSize() As cIItemSizable.SizeEnum Implements cIItemSizable.Size
            Get
                Return iTextSize
            End Get
            Set(ByVal value As cIItemSizable.SizeEnum)
                If iTextSize <> value Then
                    iTextSize = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property Text As String Implements cIItemText.Text
            Get
                Return sText
            End Get
            Set(ByVal value As String)
                If value <> sText Then
                    sText = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public ReadOnly Property Font As cItemFont Implements cIItemText.Font
            Get
                Return oFont
            End Get
        End Property

        Public Overrides Function FromGeneric(ByVal Item As cItemGeneric, Optional ByVal Clear As Boolean = False) As Boolean
            Return False
        End Function
    End Class
End Namespace
