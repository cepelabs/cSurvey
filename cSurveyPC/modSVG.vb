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
            Dim oMS As IO.MemoryStream = Clipboard.GetDataObject.GetData("image/svg+xml")
            Dim oB(oMS.Length - 1) As Byte
            Call oMS.Read(oB, 0, oMS.Length)
            Call oMS.Close()
            Call oMS.Dispose()
            Return System.Text.UnicodeEncoding.ASCII.GetString(oB)
        Catch
            Return ""
        End Try
    End Function

    Public Function DrawLine(ByVal XML As XmlDocument, ByVal Point1 As PointF, ByVal Point2 As PointF) As XmlElement
        Dim oXMLLine As XmlElement = XML.CreateElement("line")
        Call oXMLLine.SetAttribute("x1", modNumbers.NumberToString(Point1.X))
        Call oXMLLine.SetAttribute("y1", modNumbers.NumberToString(Point1.Y))
        Call oXMLLine.SetAttribute("x2", modNumbers.NumberToString(Point2.X))
        Call oXMLLine.SetAttribute("y2", modNumbers.NumberToString(Point2.Y))
        Return oXMLLine
    End Function

    Private Function pPointToSVGString(ByVal X As Single, ByVal Y As Single) As String
        Return modNumbers.NumberToString(X) & " " & modNumbers.NumberToString(Y)
    End Function

    Private Function pPointToSVGString(ByVal Point As PointF) As String
        Return pPointToSVGString(Point.X, Point.Y)
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

    Public Enum SizeUnit
        Pixel = 0
        Percentage = 1
    End Enum

    Public Enum SVGCreateFlagsEnum
        None = 0
        AddInkScapeSettings = 1
    End Enum

    Public Function CreateSVG() As XmlDocument
        Return CreateSVG("", 100, 100, SizeUnit.Percentage, SVGCreateFlagsEnum.None)
    End Function

    Public Function CreateSVG(ByVal Name As String, ByVal Width As Single, ByVal Height As Single, ByVal Unit As SizeUnit, ByVal Flags As SVGCreateFlagsEnum) As XmlDocument
        Dim oXML As XmlDocument = New XmlDocument

        Dim sUnit As String
        Select Case Unit
            Case SizeUnit.Percentage
                sUnit = "%"
            Case SizeUnit.Pixel
                sunit = "px"
        End Select

        Dim oXMLRoot As XmlElement = oXML.CreateElement("svg")
        Call oXMLRoot.SetAttribute("height", Height & sUnit)
        Call oXMLRoot.SetAttribute("width", Width & sUnit)
        Call oXMLRoot.SetAttribute("version", "1.1")

        Call oXMLRoot.SetAttribute("xmlns", "http://www.w3.org/2000/svg")
        Call oXMLRoot.SetAttribute("xmlns:svg", "http://www.w3.org/2000/svg")

        If (Flags And SVGCreateFlagsEnum.AddInkScapeSettings) = SVGCreateFlagsEnum.AddInkScapeSettings Then
            Call oXMLRoot.SetAttribute("xmlns:inkscape", "http://www.inkscape.org/namespaces/inkscape")
            Call oXMLRoot.SetAttribute("sodipodi:docname", Name)
        End If

        Dim oXMLDefs As XmlElement = oXML.CreateElement("defs")
        Call oXMLRoot.AppendChild(oXMLDefs)
        Call oXML.AppendChild(oXMLRoot)
        Return oXML
    End Function

    Public Function CreateMaskPath(ByVal SVG As XmlDocument, ByVal id As String) As XmlElement
        Dim oXMLMaskPath As XmlElement = SVG.CreateElement("mask")
        If id <> "" Then
            Call oXMLMaskPath.SetAttribute("id", id)
        End If
        Return oXMLMaskPath
    End Function

    Public Function CreateClipPath(ByVal SVG As XmlDocument, ByVal id As String) As XmlElement
        Dim oXMLClipPath As XmlElement = SVG.CreateElement("clipPath")
        If id <> "" Then
            Call oXMLClipPath.SetAttribute("id", id)
        End If
        Return oXMLClipPath
    End Function

    Public Function CreateLayer(ByVal SVG As XmlDocument, Optional ByVal id As String = "", Optional ByVal Label As String = "") As XmlElement
        Dim oXMLLayer As XmlElement = SVG.CreateElement("g")
        If id <> "" Then
            Call oXMLLayer.SetAttribute("id", id)
        End If
        Return oXMLLayer
    End Function

    Public Function CreateGroup(ByVal SVG As XmlDocument, Optional ByVal id As String = "") As XmlElement
        Dim oXMLGroup As XmlElement = SVG.CreateElement("g")
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

    Public Function AppendItem(ByVal SVG As XmlDocument, ByVal Parent As XmlElement, ByVal PaintOptions As cOptions, ByVal Path As GraphicsPath, Optional ByVal id As String = "") As XmlElement
        Dim oXMLPath As XmlElement = SVG.CreateElement("path")
        Dim sPath As StringBuilder = New StringBuilder
        Dim iLastType As PathPointType = PathPointType.Start
        For i As Integer = 0 To Path.PointCount - 1
            Dim oPaintPoint As PointF = Path.PathPoints(i)
            Dim iPaintType As PathPointType = Path.PathTypes(i)
            If iPaintType = PathPointType.Start Then
                Call sPath.Append("M " & pPointToSVGString(oPaintPoint) & " ")
                iLastType = iPaintType
            Else
                Dim iPaintTypeLine As PathPointType = (iPaintType And PathPointType.PathTypeMask)
                If iLastType <> iPaintTypeLine Then
                    If iPaintTypeLine = PathPointType.Line Then
                        Call sPath.Append("L " & pPointToSVGString(oPaintPoint) & " ")
                    Else
                        Call sPath.Append("C " & pPointToSVGString(oPaintPoint) & " ")
                    End If
                Else
                    Call sPath.Append(" " & pPointToSVGString(oPaintPoint) & " ")
                End If
                If (iPaintType And PathPointType.PathMarker) = PathPointType.PathMarker Then
                    Call sPath.Append("M " & pPointToSVGString(oPaintPoint) & " ")
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

    Public Function CreateItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptions, ByVal Path As GraphicsPath, Optional ByVal id As String = "") As XmlElement
        Dim oXMLGroup As XmlElement = SVG.CreateElement("g")
        Call AppendItem(SVG, oXMLGroup, PaintOptions, Path, id)
        Return oXMLGroup
    End Function

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
                    sStyle = pSVGAppendStyle(sStyle, "opacity", modNumbers.NumberToString(sOpacity))
                End If
            End If
        Else
            sStyle = pSVGAppendStyle(sStyle, "fill", "none")
        End If
        If (Not Pen Is Nothing) Then
            Select Case Pen.DashStyle
                Case DashStyle.Dash
                    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", "0.1,0.1")
                Case DashStyle.DashDot
                    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", "0.1,0.01")
                Case DashStyle.Dot
                    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", "0.01,0.01")
                Case DashStyle.Custom
                    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", String.Join(",", Pen.DashPattern.Select(Function(value) NumberToString(value/10)).ToArray))
                Case Else
            End Select
            sStyle = pSVGAppendStyle(sStyle, "stroke", pGetHTMLColor(Pen.Color)) ' ColorTranslator.ToHtml(Item.Pen.Color).ToLower)
            Dim sPenWidth As Single = modNumbers.MathRound(Pen.Width, 2)
            If sPenWidth <= 0 Then
                sPenWidth = 0.01
                sStyle = pSVGAppendStyle(sStyle, "vector-effect", "none")
            End If
            sStyle = pSVGAppendStyle(sStyle, "stroke-width", modNumbers.NumberToString(sPenWidth) & "")
            sStyle = pSVGAppendStyle(sStyle, "stroke-linejoin", "round")
            sStyle = pSVGAppendStyle(sStyle, "stroke-linecap", "butt")
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
                            sStyle = pSVGAppendStyle(sStyle, "opacity", modNumbers.NumberToString(sOpacity))
                        End If
                    End If
            End Select
        Else
            sStyle = pSVGAppendStyle(sStyle, "fill", "none")
        End If
        If (Not Pen Is Nothing) Then
            Select Case Pen.Style
                Case cSurvey.Design.cPen.PenStylesEnum.Dash
                    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", "0.1,0.1")
                Case cSurvey.Design.cPen.PenStylesEnum.DashDot
                    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", "0.1,0.01")
                Case cSurvey.Design.cPen.PenStylesEnum.Dot
                    sStyle = pSVGAppendStyle(sStyle, "stroke-dasharray", "0.01,0.01")
                Case Else
            End Select
            sStyle = pSVGAppendStyle(sStyle, "stroke", pGetHTMLColor(Pen.Color)) ' ColorTranslator.ToHtml(Item.Pen.Color).ToLower)
            Dim sPenWidth As Single = modNumbers.MathRound(Pen.Pen.Width, 2)
            If sPenWidth = 0 Then
                sPenWidth = 0.01
                sStyle = pSVGAppendStyle(sStyle, "vector-effect", "none")
            End If
            sStyle = pSVGAppendStyle(sStyle, "stroke-width", modNumbers.NumberToString(sPenWidth) & "")
            sStyle = pSVGAppendStyle(sStyle, "stroke-linejoin", "round")
            sStyle = pSVGAppendStyle(sStyle, "stroke-linecap", "butt")
            sStyle = pSVGAppendStyle(sStyle, "stroke-opacity", "1")
        Else
            sStyle = pSVGAppendStyle(sStyle, "stroke", "none")
        End If
        Dim oStyle As XmlAttribute = SVG.CreateAttribute("style")
        oStyle.Value = sStyle
        Return oStyle
    End Function

    Private Function pGetColorAlfaPercentage(ByVal Color As System.Drawing.Color) As Single
        Return modnumbers.mathround(Color.A / 255, 2)
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

    Public Function pSVGAppendStyle(ByRef Style As String, ByVal Key As String, ByVal Value As String) As String
        If Style <> "" Then
            Style = Style & ";"
        End If
        Style = Style & Key & ":" & Value
        Return Style
    End Function
End Module

