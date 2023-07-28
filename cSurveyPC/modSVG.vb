Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Text

Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Drawings

Module modSVG

    Public Enum SVGPathStyleEnum
        Lines = 0
        Beziers = 1
        Splines = 2
    End Enum

    Public Function GetSVGDataFromClipboard() As String
        Try
            Using oMS As IO.MemoryStream = Clipboard.GetDataObject.GetData("image/svg+xml")
                'Dim oB(oMS.Length - 1) As Byte
                'Call oMS.Read(oB, 0, oMS.Length)
                'Call oMS.Close()
                'Call oMS.Dispose()
                Return System.Text.UnicodeEncoding.ASCII.GetString(oMS.ToArray)
            End Using
        Catch
            Return ""
        End Try
    End Function

    Public Function AppendPolygon(SVG As XmlDocument, ByVal Parent As XmlElement, ByVal Points As PointF(), Brush As Brush, Pen As Pen) As XmlElement
        Dim oItemRect As XmlElement = SVG.CreateElement("polygon", svgNamespace)

        Call oItemRect.SetAttribute("points", String.Join(" ", Points.Select(Function(oPoint) modNumbers.NumberToString(oPoint.X, "") & "," & modNumbers.NumberToString(oPoint.Y, ""))))

        Call AppendItemStyle(SVG, oItemRect, Brush, Pen)

        If Parent Is Nothing Then
            Call SVG.Item("svg").AppendChild(oItemRect)
        Else
            Call Parent.AppendChild(oItemRect)
        End If
        Return oItemRect
    End Function

    Public Function AppendRectangle(SVG As XmlDocument, ByVal Parent As XmlElement, ByVal Bounds As RectangleF, Brush As Brush, Pen As Pen) As XmlElement
        Dim oItemRect As XmlElement = SVG.CreateElement("rect", svgNamespace)

        Call oItemRect.SetAttribute("x", modNumbers.NumberToString(Bounds.Left, ""))
        Call oItemRect.SetAttribute("y", modNumbers.NumberToString(Bounds.Top, ""))
        Call oItemRect.SetAttribute("width", modNumbers.NumberToString(Bounds.Width, ""))
        Call oItemRect.SetAttribute("height", modNumbers.NumberToString(Bounds.Height, ""))

        Call AppendItemStyle(SVG, oItemRect, Brush, Pen)

        If Parent Is Nothing Then
            Call SVG.Item("svg").AppendChild(oItemRect)
        Else
            Call Parent.AppendChild(oItemRect)
        End If
        Return oItemRect
    End Function

    'Public Function DrawLine(ByVal XML As XmlDocument, ByVal Point1 As PointF, ByVal Point2 As PointF) As XmlElement
    '    Dim oXMLLine As XmlElement = XML.CreateElement("line", svgNamespace)
    '    Call oXMLLine.SetAttribute("x1", modNumbers.NumberToString(Point1.X, ""))
    '    Call oXMLLine.SetAttribute("y1", modNumbers.NumberToString(Point1.Y, ""))
    '    Call oXMLLine.SetAttribute("x2", modNumbers.NumberToString(Point2.X, ""))
    '    Call oXMLLine.SetAttribute("y2", modNumbers.NumberToString(Point2.Y, ""))
    '    Return oXMLLine
    'End Function

    Public Function PointToSVGString(ByVal X As Single, ByVal Y As Single) As String
        Return modNumbers.NumberToString(X, "") & " " & modNumbers.NumberToString(Y, "")
    End Function

    Public Function PointToSVGString(ByVal Point As PointF) As String
        Return PointToSVGString(Point.X, Point.Y)
    End Function

    Public Function LoadSVG(ByVal Filename As String) As XmlDocument
        Dim oXML As XmlDocument = New XmlDocument
        oXML.XmlResolver = Nothing
        oXML.Load(Filename)
        Return oXML
    End Function

    Public Function LoadSVGData(ByVal Data As String) As XmlDocument
        Dim oXML As XmlDocument = New XmlDocument
        oXML.XmlResolver = Nothing
        oXML.LoadXml(Data)
        Return oXML
    End Function

    Public Function ConvertRectangleToMeters(Rectangle As RectangleF, FromUnit As SizeUnit) As RectangleF
        Select Case FromUnit
            Case SizeUnit.cm
                Return New RectangleF(Rectangle.X / 100.0F, Rectangle.Y / 100.0F, Rectangle.Width / 100.0F, Rectangle.Height / 100.0F)
            Case SizeUnit.mm
                Return New RectangleF(Rectangle.X / 1000.0F, Rectangle.Y / 1000.0F, Rectangle.Width / 1000.0F, Rectangle.Height / 1000.0F)
            Case SizeUnit.inch
                Return New RectangleF(Rectangle.X * 0.0254F, Rectangle.Y * 0.0254F, Rectangle.Width * 0.0254F, Rectangle.Height * 0.0254F)
            Case SizeUnit.pixel
                Return New RectangleF((Rectangle.X / 96.0F) * 0.0254F, (Rectangle.Y / 96.0F) * 0.0254F, (Rectangle.Width / 96.0F) * 0.0254F, (Rectangle.Height / 96.0F) * 0.0254F)
        End Select
    End Function

    Public Enum SizeUnit
        none = -1
        pixel = 0
        percentage = 1
        cm = 2
        mm = 3
        inch = 4
    End Enum

    Public Enum SVGCreateFlagsEnum
        None = 0
        AddInkscapeSettings = 1
    End Enum

    Public Function CreateSVG() As XmlDocument
        Return CreateSVG("", New SizeF(100, 100), SizeUnit.percentage, New RectangleF(0, 0, 100, 100), SVGCreateFlagsEnum.None)
    End Function

    Public Function SizeUnitToUnit(Unit As SizeUnit) As String
        Select Case Unit
            Case SizeUnit.none
                Return ""
            Case SizeUnit.percentage
                Return "%"
            Case SizeUnit.inch
                Return "in"
            Case SizeUnit.mm
                Return "mm"
            Case SizeUnit.cm
                Return "cm"
            Case Else
                Return "px"
        End Select
    End Function

    Public Const sodipodiNamespace As String = "http://sodipodi.sourceforge.net/DTD/sodipodi-0.dtd"
    Public Const inkscapeNamespace As String = "http://www.inkscape.org/namespaces/inkscape"
    Public Const xlinkNamespace As String = "http://www.w3.org/1999/xlink"
    Public Const csurveyNamespace As String = "http://www.csurvey.it"
    Public Const svgNamespace As String = "http://www.w3.org/2000/svg"

    Public Sub AddSourceReference(Item As cItem, SvgItem As XmlElement, Options As cItem.SVGOptionsEnum)
        If Item.Name <> "" Then Call SvgItem.SetAttribute("name", Item.Name)
        If (Options And cItem.SVGOptionsEnum.AddSourceReference) = cItem.SVGOptionsEnum.AddSourceReference Then
            Call SvgItem.SetAttribute("type", "http://www.csurvey.it", Item.Type.ToString("D"))
            Call SvgItem.SetAttribute("category", "http://www.csurvey.it", Item.Category.ToString("D"))
            If Item.Cave <> "" Then Call SvgItem.SetAttribute("cave", "http://www.csurvey.it", Item.Cave)
            If Item.Branch <> "" Then Call SvgItem.SetAttribute("branch", "http://www.csurvey.it", Item.Branch)
            If Item.BindDesignType <> cItem.BindDesignTypeEnum.MainDesign Then Call SvgItem.SetAttribute("binddesigntype", "http://www.csurvey.it", Item.BindDesignType.ToString("D"))
            If Item.CrossSection <> "" Then Call SvgItem.SetAttribute("crosssection", "http://www.csurvey.it", Item.CrossSection)
        End If
    End Sub

    Public Function CreateSVG(ByVal Name As String, ByVal Size As SizeF, ByVal Unit As SizeUnit, ViewBox As RectangleF, ByVal Flags As SVGCreateFlagsEnum) As XmlDocument
        Dim oXML As XmlDocument = New XmlDocument

        Dim sUnit As String = SizeUnitToUnit(Unit)

        Dim oXMLRoot As XmlElement = oXML.CreateElement("svg", svgNamespace)
        Call oXMLRoot.SetAttribute("width", modNumbers.NumberToString(Size.Width, "") & sUnit)
        Call oXMLRoot.SetAttribute("height", modNumbers.NumberToString(Size.Height, "") & sUnit)
        Call oXMLRoot.SetAttribute("version", "1.1")

        Call oXMLRoot.SetAttribute("viewBox", modNumbers.NumberToString(ViewBox.Left, "") & " " & modNumbers.NumberToString(ViewBox.Top, "") & " " & modNumbers.NumberToString(ViewBox.Width, "") & " " & modNumbers.NumberToString(ViewBox.Height, ""))

        Call oXMLRoot.SetAttribute("xmlns", svgNamespace)
        Call oXMLRoot.SetAttribute("xmlns:svg", svgnamespace)
        Call oXMLRoot.SetAttribute("xmlns:xlink", XlinkNamespace)
        Call oXMLRoot.SetAttribute("xmlns:csurvey", cSurveyNamespace)

        If (Flags And SVGCreateFlagsEnum.AddInkScapeSettings) = SVGCreateFlagsEnum.AddInkScapeSettings Then
            Call oXMLRoot.SetAttribute("xmlns:sodipodi", SodipodiNamespace)
            Call oXMLRoot.SetAttribute("xmlns:inkscape", InkscapeNamespace)
            Call oXMLRoot.SetAttribute("docname", SodipodiNamespace, Name)
        End If

        Dim oXMLDefs As XmlElement = oXML.CreateElement("defs", svgNamespace)
        Call oXMLRoot.AppendChild(oXMLDefs)
        Call oXML.AppendChild(oXMLRoot)
        Return oXML
    End Function

    Public Function CreateMaskPath(ByVal SVG As XmlDocument, ByVal id As String) As XmlElement
        Dim oXMLMaskPath As XmlElement = SVG.CreateElement("mask", svgNamespace)
        If id <> "" Then
            Call oXMLMaskPath.SetAttribute("id", id)
        End If
        Return oXMLMaskPath
    End Function

    Public Function CreateClipPath(ByVal SVG As XmlDocument, ByVal id As String) As XmlElement
        Dim oXMLClipPath As XmlElement = SVG.CreateElement("clipPath", svgNamespace)
        If id <> "" Then
            Call oXMLClipPath.SetAttribute("id", id)
        End If
        Return oXMLClipPath
    End Function

    Public Function CreateLayer(ByVal SVG As XmlDocument, id As String, Label As String) As XmlElement
        Dim oXMLLayer As XmlElement = SVG.CreateElement("g", svgNamespace)
        If id <> "" Then
            Call oXMLLayer.SetAttribute("id", id)
        End If
        If modXML.HasAttribute(SVG.DocumentElement, "xmlns:inkscape") Then
            'inkscape:groupmode
            Call oXMLLayer.SetAttribute("groupmode", inkscapeNamespace, "layer")
            Call oXMLLayer.SetAttribute("label", inkscapeNamespace, Label)
        End If
        Return oXMLLayer
    End Function

    Public Function CreateSubSVG(ByVal SVG As XmlDocument, ByVal id As String, ByVal Bounds As RectangleF, ByVal Unit As SizeUnit, ViewBox As RectangleF) As XmlElement
        Dim sUnit As String = SizeUnitToUnit(Unit)

        Dim oXMLRoot As XmlElement = SVG.CreateElement("svg", svgNamespace)
        If id <> "" Then
            Call oXMLRoot.SetAttribute("id", id)
        End If
        Call oXMLRoot.SetAttribute("x", modNumbers.NumberToString(Bounds.Left, "") & sUnit)
        Call oXMLRoot.SetAttribute("y", modNumbers.NumberToString(Bounds.Top, "") & sUnit)
        Call oXMLRoot.SetAttribute("width", modNumbers.NumberToString(Bounds.Width, "") & sUnit)
        Call oXMLRoot.SetAttribute("height", modNumbers.NumberToString(Bounds.Height, "") & sUnit)

        Call oXMLRoot.SetAttribute("viewBox", modNumbers.NumberToString(ViewBox.Left, "") & " " & modNumbers.NumberToString(ViewBox.Top, "") & " " & modNumbers.NumberToString(ViewBox.Width, "") & " " & modNumbers.NumberToString(ViewBox.Height, ""))

        Return oXMLRoot
    End Function

    Public Function CreateGeneric(Svg As XmlDocument, Name As String, Optional ByVal id As String = "") As XmlElement
        Dim oXMLGeneric As XmlElement = Svg.CreateElement(Name, svgNamespace)
        If id <> "" Then
            Call oXMLGeneric.SetAttribute("id", id)
        End If
        Return oXMLGeneric
    End Function

    Public Function CreateGroup(ByVal SVG As XmlDocument, Optional ByVal id As String = "") As XmlElement
        Dim oXMLGroup As XmlElement = SVG.CreateElement("g", svgNamespace)
        If id <> "" Then
            Call oXMLGroup.SetAttribute("id", id)
        End If
        Return oXMLGroup
    End Function

    Public Sub AppendItem(ByVal SVG As XmlDocument, ByVal Parent As XmlElement, ByVal Item As XmlElement)
        If Parent Is Nothing Then
            Call SVG.Item("svg").AppendChild(Item)
        Else
            Call Parent.AppendChild(Item)
        End If
    End Sub

    Public Function AppendItem(ByVal SVG As XmlDocument, ByVal Parent As XmlElement, ByVal PaintOptions As cOptionsCenterline, ByVal Path As GraphicsPath, Optional ByVal id As String = "") As XmlElement
        Dim oXMLPath As XmlElement = SVG.CreateElement("path", svgNamespace)
        Dim sPath As StringBuilder = New StringBuilder
        Dim iLastType As PathPointType = PathPointType.Start
        For i As Integer = 0 To Path.PointCount - 1
            Dim oPaintPoint As PointF = Path.PathPoints(i)
            Dim iPaintType As PathPointType = Path.PathTypes(i)
            If iPaintType = PathPointType.Start Then
                Call sPath.Append("M " & PointToSVGString(oPaintPoint) & " ")
                iLastType = iPaintType
            Else
                Dim iPaintTypeLine As PathPointType = (iPaintType And PathPointType.PathTypeMask)
                If iLastType <> iPaintTypeLine Then
                    If iPaintTypeLine = PathPointType.Line Then
                        Call sPath.Append("L " & PointToSVGString(oPaintPoint) & " ")
                    Else
                        Call sPath.Append("C " & PointToSVGString(oPaintPoint) & " ")
                    End If
                Else
                    Call sPath.Append(" " & PointToSVGString(oPaintPoint) & " ")
                End If
                If (iPaintType And PathPointType.PathMarker) = PathPointType.PathMarker Then
                    Call sPath.Append("M " & PointToSVGString(oPaintPoint) & " ")
                End If
                If (iPaintType And PathPointType.CloseSubpath) = PathPointType.CloseSubpath Then
                    Call sPath.Append("Z ")
                End If
                iLastType = iPaintType
            End If
        Next
        Call oXMLPath.SetAttribute("d", sPath.ToString)
        Call Parent.AppendChild(oXMLPath)
        Return oXMLPath
    End Function

    Public Function FontUnitToStyle(FontUnit As GraphicsUnit) As String
        Select Case FontUnit
            Case GraphicsUnit.Point
                Return "pt"
            Case Else
                Return "px"
        End Select
    End Function

    Public Function CreateText(ByVal SVG As XmlDocument, Text As String, Point As PointF, FontFamily As String, FontStyle As FontStyle, FontSize As Single, FontUnit As GraphicsUnit, Optional ByVal id As String = "") As XmlElement
        Dim oXMLText As XmlElement = SVG.CreateElement("text", svgNamespace)
        oXMLText.InnerText = Text
        Call oXMLText.SetAttribute("x", modNumbers.NumberToString(Point.X, ""))
        Call oXMLText.SetAttribute("y", modNumbers.NumberToString(Point.Y, ""))
        Call oXMLText.SetAttribute("dominant-baseline", "hanging")
        Call oXMLText.SetAttribute("style", "font-family:" & FontFamily & ";font-size:" & modNumbers.NumberToString(FontSize, "") & FontUnitToStyle(FontUnit))
        Return oXMLText
    End Function

    Public Function CreateText(ByVal SVG As XmlDocument, Text As String, Point As PointF, Font As Font, Optional ByVal id As String = "") As XmlElement
        Return CreateText(SVG, Text, Point, Font.FontFamily.Name, Font.Style, Font.Size, Font.Unit, id)
    End Function

    Public Function CreateImage(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptionsCenterline, ByVal Bounds As RectangleF, Image As Bitmap, Optional RotationAngle As Single = 0, Optional KeepAspectRatio As Boolean = True, Optional ByVal id As String = "") As XmlElement
        If Not Image Is Nothing Then
            Dim oXMLImage As XmlElement = SVG.CreateElement("image", svgNamespace)
            Call oXMLImage.SetAttribute("x", modNumbers.NumberToString(Bounds.X, ""))
            Call oXMLImage.SetAttribute("y", modNumbers.NumberToString(Bounds.Y, ""))
            Call oXMLImage.SetAttribute("width", modNumbers.NumberToString(Bounds.Width, ""))
            Call oXMLImage.SetAttribute("height", modNumbers.NumberToString(Bounds.Height, ""))
            Call oXMLImage.SetAttribute("preserveAspectRatio", If(KeepAspectRatio, "meet", "none"))
            Dim oSB As StringBuilder = New StringBuilder
            Call oSB.Append("data:image/PNG;base64,")
            Call oSB.Append(Convert.ToBase64String(modPaint.BitmapToByteArray(Image, Drawing.Imaging.ImageFormat.Png)))
            Call oXMLImage.SetAttribute("href", "http://www.w3.org/1999/xlink", oSB.ToString)
            If RotationAngle <> 0 Then
                Call oXMLImage.SetAttribute("transform", "rotate(" & modNumbers.NumberToString(RotationAngle, "") & ")")
            End If
            Return oXMLImage
        End If
    End Function

    Public Function CreateItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptionsCenterline, ByVal Path As GraphicsPath, Optional ByVal id As String = "") As XmlElement
        Dim oXMLGroup As XmlElement = SVG.CreateElement("g", svgNamespace)
        Call AppendItem(SVG, oXMLGroup, PaintOptions, Path, id)
        Return oXMLGroup
    End Function

    Public Sub AppendItemStyle(ByVal SVG As XmlDocument, ByVal Item As XmlElement, ByVal Name As String, Value As String)
        Dim sStyle As String = "" & Item.GetAttribute("style")
        sStyle = pSVGAppendStyle(sStyle, Name, Value)
        Call Item.SetAttribute("style", sStyle)
    End Sub

    Public Sub AppendItemStyle(ByVal SVG As XmlDocument, ByVal Item As XmlElement, ByVal Brush As cBrush, ByVal Pen As cPen)
        Call Item.Attributes.Append(GetItemStyle(SVG, Brush, Pen))
    End Sub

    Public Sub AppendItemStyle(ByVal SVG As XmlDocument, ByVal Item As XmlElement, ByVal Brush As SolidBrush, ByVal Pen As Pen)
        Call Item.Attributes.Append(GetItemStyle(SVG, Brush, Pen))
    End Sub

    Public Function GetItemStyle(ByVal SVG As XmlDocument, ByVal Brush As SolidBrush, ByVal Pen As Pen) As XmlAttribute
        Dim sStyle As String = ""
        If (Not Brush Is Nothing) Then
            If Brush.Color = Color.Transparent Then
                sStyle = pSVGAppendStyle(sStyle, "fill", "none")
            Else
                sStyle = pSVGAppendStyle(sStyle, "fill", pGetHTMLColor(Brush.Color))
                Dim sOpacity As Single = pGetColorAlfaPercentage(Brush.Color)
                If sOpacity <> 100 Then
                    sStyle = pSVGAppendStyle(sStyle, "opacity", modNumbers.NumberToString(sOpacity, ""))
                End If
            End If
        Else
            sStyle = pSVGAppendStyle(sStyle, "fill", "none")
        End If
        If (Not Pen Is Nothing) Then
            sStyle = pSVGAppendStyle(sStyle, "stroke", pGetHTMLColor(Pen.Color)) ' ColorTranslator.ToHtml(Item.Pen.Color).ToLower)
            Dim sPenWidth As Single = modNumbers.MathRound(Pen.Width, 2)
            If sPenWidth <= 0 Then
                sPenWidth = 0.01
                sStyle = pSVGAppendStyle(sStyle, "vector-effect", "none")
            End If
            Select Case Pen.DashStyle
                Case DashStyle.Dash
                    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", modNumbers.NumberToString(sPenWidth * 2.2, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, "")) ' "0.1,0.1")
                Case DashStyle.DashDot
                    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", modNumbers.NumberToString(sPenWidth * 2.2, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, ""))' "0.1,0.01")
                Case DashStyle.Dot
                    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", modNumbers.NumberToString(sPenWidth * 1.8, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, ""))' "0.01,0.01")
                Case cPen.PenStylesEnum.DashDotDot
                    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", modNumbers.NumberToString(sPenWidth * 2.2, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, "")) ' "0.1,0.01")
                Case DashStyle.Custom
                    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", String.Join(",", Pen.DashPattern.Select(Function(value) NumberToString(sPenWidth * value, "")).ToArray))
                Case Else
            End Select
            sStyle = pSVGAppendStyle(sStyle, "stroke-width", modNumbers.NumberToString(sPenWidth, ""))
            Select Case Pen.StartCap
                Case LineCap.Flat
                    sStyle = pSVGAppendStyle(sStyle, "stroke-linecap", "butt ")
                Case LineCap.Round
                    sStyle = pSVGAppendStyle(sStyle, "stroke-linecap", "round")
                Case LineCap.Square
                    sStyle = pSVGAppendStyle(sStyle, "stroke-linecap", "square")
            End Select
            Select Case Pen.LineJoin
                Case LineJoin.Bevel
                    sStyle = pSVGAppendStyle(sStyle, "stroke-linejoin", "bevel")
                Case LineJoin.Miter
                    sStyle = pSVGAppendStyle(sStyle, "stroke-linejoin", "miter")
                Case LineJoin.MiterClipped
                    sStyle = pSVGAppendStyle(sStyle, "stroke-linejoin", "miter-clip")
                Case LineJoin.Round
                    sStyle = pSVGAppendStyle(sStyle, "stroke-linejoin", "round")
            End Select
            sStyle = pSVGAppendStyle(sStyle, "stroke-opacity", "1")
        Else
            sStyle = pSVGAppendStyle(sStyle, "stroke", "none")
        End If
        Dim oStyle As XmlAttribute = SVG.CreateAttribute("style")
        oStyle.Value = sStyle
        Return oStyle
    End Function

    Public Function GetItemStyle(ByVal SVG As XmlDocument, ByVal Brush As cBrush, ByVal Pen As cPen) As XmlAttribute
        Dim sStyle As String = ""
        If (Not Brush Is Nothing) Then
            Select Case Brush.Type
                Case cSurvey.Design.cBrush.BrushTypeEnum.Solid
                    sStyle = pSVGAppendStyle(sStyle, "fill", pGetHTMLColor(Brush.Color))
                Case cSurvey.Design.cBrush.BrushTypeEnum.SignSolid
                    sStyle = pSVGAppendStyle(sStyle, "fill", pGetHTMLColor(Color.White))
                    '---------------------------------------------------------------------
                Case cSurvey.Design.cBrush.BrushTypeEnum.Pebbles
                    sStyle = pSVGAppendStyle(sStyle, "fill", pGetHTMLColor(Color.SandyBrown))
                Case cSurvey.Design.cBrush.BrushTypeEnum.Sand
                    sStyle = pSVGAppendStyle(sStyle, "fill", pGetHTMLColor(Color.SandyBrown))
                    '---------------------------------------------------------------------
                Case Else
                    If Brush.Color = Color.Transparent Then
                        sStyle = pSVGAppendStyle(sStyle, "fill", "none")
                    Else
                        sStyle = pSVGAppendStyle(sStyle, "fill", pGetHTMLColor(Brush.Color))
                        Dim sOpacity As Single = pGetColorAlfaPercentage(Brush.Color)
                        If sOpacity <> 100 Then
                            sStyle = pSVGAppendStyle(sStyle, "opacity", modNumbers.NumberToString(sOpacity, ""))
                        End If
                    End If
            End Select
        Else
            sStyle = pSVGAppendStyle(sStyle, "fill", "none")
        End If
        If (Not Pen Is Nothing) Then
            Dim oDrawingPen As Drawing.Pen = Pen.GetBasePen.Pen
            sStyle = pSVGAppendStyle(sStyle, "stroke", pGetHTMLColor(Pen.Color)) ' ColorTranslator.ToHtml(Item.Pen.Color).ToLower)
            Dim sPenWidth As Single = modNumbers.MathRound(oDrawingPen.Width, 2)
            If sPenWidth = 0 Then
                sPenWidth = 0.01
                sStyle = pSVGAppendStyle(sStyle, "vector-effect", "none")
            End If
            Select Case Pen.Style
                Case cPen.PenStylesEnum.Solid
                Case DashStyle.Dash
                    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", modNumbers.NumberToString(sPenWidth * 2.2, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, "")) ' "0.1,0.1")
                Case DashStyle.DashDot
                    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", modNumbers.NumberToString(sPenWidth * 2.2, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, ""))' "0.1,0.01")
                Case DashStyle.Dot
                    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", modNumbers.NumberToString(sPenWidth * 1.8, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, "")) ' "0.01,0.01")
                Case cPen.PenStylesEnum.DashDotDot
                    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", modNumbers.NumberToString(sPenWidth * 2.2, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, "") & "," & modNumbers.NumberToString(sPenWidth * 1.8, "")) ' "0.1,0.01")
                    'Case cPen.PenStylesEnum.LargeDashLargeSpace
                    '    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", String.Join(",", oDrawingPen.DashPattern.Select(Function(sPatternItem) modNumbers.NumberToString(sPatternItem))))
                    'Case cPen.PenStylesEnum.LargeDashMediumSpace
                    '    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", String.Join(",", oDrawingPen.DashPattern.Select(Function(sPatternItem) modNumbers.NumberToString(sPatternItem))))
                    'Case cPen.PenStylesEnum.LargeDashSmallSpace
                    '    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", String.Join(",", oDrawingPen.DashPattern.Select(Function(sPatternItem) modNumbers.NumberToString(sPatternItem))))
                Case Else
                    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", String.Join(",", oDrawingPen.DashPattern.Select(Function(value) NumberToString(sPenWidth * value, "")).ToArray))
            End Select
            sStyle = pSVGAppendStyle(sStyle, "stroke-width", modNumbers.NumberToString(sPenWidth, ""))
            Select Case oDrawingPen.StartCap
                Case LineCap.Flat
                    sStyle = pSVGAppendStyle(sStyle, "stroke-linecap", "butt ")
                Case LineCap.Round
                    sStyle = pSVGAppendStyle(sStyle, "stroke-linecap", "round")
                Case LineCap.Square
                    sStyle = pSVGAppendStyle(sStyle, "stroke-linecap", "square")
            End Select
            Select Case oDrawingPen.LineJoin
                Case LineJoin.Bevel
                    sStyle = pSVGAppendStyle(sStyle, "stroke-linejoin", "bevel")
                Case LineJoin.Miter
                    sStyle = pSVGAppendStyle(sStyle, "stroke-linejoin", "miter")
                Case LineJoin.MiterClipped
                    sStyle = pSVGAppendStyle(sStyle, "stroke-linejoin", "miter-clip")
                Case LineJoin.Round
                    sStyle = pSVGAppendStyle(sStyle, "stroke-linejoin", "round")
            End Select
            sStyle = pSVGAppendStyle(sStyle, "stroke-opacity", "1")
        Else
            sStyle = pSVGAppendStyle(sStyle, "stroke", "none")
        End If
        Dim oStyle As XmlAttribute = SVG.CreateAttribute("style")
        oStyle.Value = sStyle
        Return oStyle
    End Function

    Private Function pGetColorAlfaPercentage(ByVal Color As System.Drawing.Color) As Single
        Return modNumbers.MathRound(Color.A / 255, 2)
    End Function

    Private Function pGetHTMLColor(ByVal Color As System.Drawing.Color) As String
        Dim sR As String = Hex(Color.R)
        If sR.Length < 2 Then sR = "0" & sR
        Dim sG As String = Hex(Color.G)
        If sG.Length < 2 Then sG = "0" & sG
        Dim sB As String = Hex(Color.B)
        If sB.Length < 2 Then sB = "0" & sB
        Return "#" & sR & sG & sB
    End Function

    Private Function pSVGAppendStyle(ByRef Style As String, ByVal Key As String, ByVal Value As String) As String
        If Style <> "" Then
            Style = Style & ";"
        End If
        Style = Style & Key & ":" & Value
        Return Style
    End Function
End Module

