Imports cSurveyPC
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Drawings

Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace cSurvey.Design
    Public Class cItemFont
        Implements cIFont

        Public Enum FontTypeEnum
            Generic = 0
            Title = 1
            CaveName = 2
            CaveComplexName = 3
            TrigPoint = 4
            Note = 5
            Custom = 99
        End Enum

        Private WithEvents oSurvey As cSurvey

        Private sName As String
        Private iType As FontTypeEnum

        Private oColor As Color

        Private sFontName As String
        Private sFontSize As Single
        Private bFontBold As Boolean
        Private bFontItalic As Boolean
        Private bFontUnderline As Boolean

        Private oFont As Font
        Private oBrush As SolidBrush
        Private oWireframePen As Pen

        Private sLocalLineWidth As Single
        Private sLocalZoomFactor As Single

        Private bInvalidated As Boolean

        Friend Event OnChanged(ByVal Sender As cItemFont)

        Friend Class cRenderArgs
            Inherits EventArgs
            Public Transparency As Single
        End Class

        Friend Event OnRender(sender As cItemFont, RenderArgs As cRenderArgs)

        Public ReadOnly Property FontStyle As FontStyle Implements cIFont.FontStyle
            Get
                Dim iFontStyle As FontStyle
                iFontStyle = If(bFontBold, iFontStyle Or FontStyle.Bold, iFontStyle)
                iFontStyle = If(bFontItalic, iFontStyle Or FontStyle.Italic, iFontStyle)
                iFontStyle = If(bFontUnderline, iFontStyle Or FontStyle.Underline, iFontStyle)
                Return iFontStyle
            End Get
        End Property

        Public Function Clone() As cIFont Implements cIFont.Clone
            Return New cItemFont(Me)
        End Function

        Public Overrides Function ToString() As String
            Return sFontName & ", " & modNumbers.NumberToString(sFontSize) & "," & If(bFontBold, " " & GetLocalizedString("itemfont.textpart1"), "") & If(bFontItalic, " " & GetLocalizedString("itemfont.textpart2"), "") & If(FontUnderline, " " & GetLocalizedString("itemfont.textpart3"), "")
        End Function

        Friend Sub New(ByVal Font As cItemFont)
            oSurvey = Font.Survey
            Call CopyFrom(Font)
            Call pInvalidate()
        End Sub

        Friend ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public Sub CopyFrom(ByVal Font As cItemFont)
            sName = Font.Name
            iType = Font.Type
            oColor = Font.Color

            sFontName = Font.FontName
            sFontSize = Font.FontSize
            bFontBold = Font.FontBold
            bFontItalic = Font.FontItalic
            bFontUnderline = Font.FontUnderline

            sLocalLineWidth = Font.LocalLineWidth

            Call pInvalidate()
        End Sub

        Friend Property LocalZoomFactor As Single
            Get
                Return sLocalZoomFactor
            End Get
            Set(ByVal value As Single)
                If sLocalZoomFactor <> value Then
                    sLocalZoomFactor = value
                    Call pInvalidate()
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
                    Call pInvalidate()
                End If
            End Set
        End Property

        Public Property Name As String
            Get
                Return sName
            End Get
            Set(ByVal value As String)
                If sName <> value Then
                    iType = FontTypeEnum.Custom
                    sName = value
                    Call pInvalidate()
                End If
            End Set
        End Property

        Public Property Type() As FontTypeEnum
            Get
                Return iType
            End Get
            Set(ByVal value As FontTypeEnum)
                If iType <> value Then
                    iType = value
                    If iType <> FontTypeEnum.Custom Then
                        Call CopyFrom(Survey.EditPaintObjects.Fonts.FromType(Type))
                    End If
                    Call pInvalidate()
                End If
            End Set
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Type As FontTypeEnum)
            oSurvey = Survey
            Call CopyFrom(Survey.EditPaintObjects.Fonts.FromType(Type))
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Name As String, ByVal Type As FontTypeEnum, ByVal FontName As String, ByVal FontSize As Single, ByVal Color As Color, Optional ByVal Bold As Boolean = False, Optional ByVal Italic As Boolean = False, Optional ByVal Underline As Boolean = False)
            oSurvey = Survey
            sName = Name
            iType = Type
            oColor = Color
            sFontName = FontName
            sFontSize = FontSize
            bFontBold = Bold
            bFontItalic = Italic
            bFontUnderline = Underline
            Call pInvalidate()
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            sName = ""
            iType = FontTypeEnum.Generic
            sFontName = ""
            sFontSize = 8
            oColor = Color.Black
            Call pInvalidate()
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal item As XmlElement)
            oSurvey = Survey
            iType = modXML.GetAttributeValue(item, "type", FontTypeEnum.Custom)
            If iType = FontTypeEnum.Custom Then
                sName = modXML.GetAttributeValue(item, "name")
                oColor = modXML.GetAttributeColor(item, "color", Color.Black)
                sFontName = modXML.GetAttributeValue(item, "fontname")
                sFontSize = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "fontsize", "8"))
                bFontBold = modXML.GetAttributeValue(item, "fontbold")
                bFontItalic = modXML.GetAttributeValue(item, "fontitalic")
                bFontUnderline = modXML.GetAttributeValue(item, "fontunderline")
            Else
                Call CopyFrom(oSurvey.EditPaintObjects.Fonts.FromType(iType))
            End If
            Call pInvalidate()
        End Sub

        Friend Sub AddToPath(ByVal PaintOptions As cOptionsCenterline, ByVal Path As GraphicsPath, ByVal Text As String, ByVal Bounds As RectangleF, ByVal StringFormat As StringFormat)
            Try
                If Text <> "" Then
                    If bInvalidated Then pRender(PaintOptions)
                    Call Path.AddString(Text, oFont.FontFamily, oFont.Style, oFont.Size, Bounds, StringFormat)
                End If
            Catch
            End Try
        End Sub

        Friend Sub AddToPath(ByVal PaintOptions As cOptionsCenterline, ByVal Path As GraphicsPath, ByVal Text As String, ByVal Point As PointF, ByVal StringFormat As StringFormat)
            Try
                If Text <> "" Then
                    If bInvalidated Then pRender(PaintOptions)
                    Call Path.AddString(Text, oFont.FontFamily, oFont.Style, oFont.Size, Point, StringFormat)
                End If
            Catch
            End Try
        End Sub

        Friend Function MeasureString(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, Text As String) As SizeF
            If bInvalidated Then pRender(PaintOptions)
            Return Graphics.MeasureString(Text, oFont)
        End Function

        Friend Function GetPath(ByVal PaintOptions As cOptions, ByVal Text As String, ByVal StringFormat As StringFormat) As GraphicsPath
            Try
                If Text <> "" Then
                    If bInvalidated Then pRender(PaintOptions)
                    Dim oPath As GraphicsPath = New GraphicsPath
                    Call oPath.AddString(Text, oFont.FontFamily, oFont.Style, oFont.Size, New PointF(0, 0), StringFormat)
                    Return oPath
                End If
            Catch
            End Try
        End Function

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, ByVal Name As String) As XmlElement
            Dim oItem As XmlElement = Document.CreateElement(Name)
            Call oItem.SetAttribute("type", iType)
            If iType = FontTypeEnum.Custom Then
                If sName <> "" Then
                    Call oItem.SetAttribute("name", sName)
                End If
                Call oItem.SetAttribute("color", oColor.ToArgb)
                Call oItem.SetAttribute("fontname", sFontName)
                Call oItem.SetAttribute("fontsize", modNumbers.NumberToString(sFontSize))
                If bFontBold Then
                    Call oItem.SetAttribute("fontbold", If(bFontBold, "1", "0"))
                End If
                If bFontItalic Then
                    Call oItem.SetAttribute("fontitalic", If(bFontBold, "1", "0"))
                End If
                If bFontUnderline Then
                    Call oItem.SetAttribute("fontunderline", If(bFontBold, "1", "0"))
                End If
            End If
            Call Parent.AppendChild(oItem)
            Return oItem
        End Function

        Public Property FontUnderline() As Boolean Implements cIFont.FontUnderline
            Get
                Return bFontUnderline
            End Get
            Set(ByVal value As Boolean)
                If bFontUnderline <> value Then
                    iType = FontTypeEnum.Custom
                    bFontUnderline = value
                    Call pInvalidate()
                End If
            End Set
        End Property

        Public Property FontItalic() As Boolean Implements cIFont.FontItalic
            Get
                Return bFontItalic
            End Get
            Set(ByVal value As Boolean)
                If bFontItalic <> value Then
                    iType = FontTypeEnum.Custom
                    bFontItalic = value
                    Call pInvalidate()
                End If
            End Set
        End Property

        Public Property Color() As Color Implements cIFont.Color
            Get
                Return oColor
            End Get
            Set(ByVal value As Color)
                If Color <> value Then
                    iType = FontTypeEnum.Custom
                    oColor = value
                    Call pInvalidate()
                End If
            End Set
        End Property

        Public Property FontBold() As Boolean Implements cIFont.FontBold
            Get
                Return bFontBold
            End Get
            Set(ByVal value As Boolean)
                If bFontBold <> value Then
                    iType = FontTypeEnum.Custom
                    bFontBold = value
                    Call pInvalidate()
                End If
            End Set
        End Property

        Private Sub pInvalidate()
            bInvalidated = True
            RaiseEvent OnChanged(Me)
        End Sub

        Public Property FontName() As String Implements cIFont.FontName
            Get
                Return sFontName
            End Get
            Set(ByVal value As String)
                If sFontName <> value Then
                    iType = FontTypeEnum.Custom
                    sFontName = value
                    Call pInvalidate()
                End If
            End Set
        End Property

        Friend Sub Invalidate()
            bInvalidated = True
            RaiseEvent OnChanged(Me)
        End Sub

        Public Property FontSize() As Single Implements cIFont.FontSize
            Get
                Return sFontSize
            End Get
            Set(ByVal value As Single)
                If sFontSize <> value AndAlso value > 0F Then
                    iType = FontTypeEnum.Custom
                    sFontSize = value
                    Call pInvalidate()
                End If
            End Set
        End Property

        Public Function GetSampleFont() As Font Implements cIFont.GetSampleFont
            Dim sTempFontName As String = sFontName
            Dim sTempFontSize As Single = sFontSize
            If sTempFontName = "" Or sTempFontSize <= 0 Then
                Dim oDesignTextFont As cIFont = modPaint.GetDefaultFont
                If sTempFontName = "" Then
                    sTempFontName = oDesignTextFont.FontName
                End If
                If sTempFontSize <= 0F Then
                    sTempFontSize = 8.0F
                End If
            End If
            Dim iFontStyle As FontStyle = FontStyle
            Return New Font(sTempFontName, sTempFontSize, iFontStyle)
        End Function

        Friend Function GetFont(PaintOptions As cOptionsCenterline) As Font
            If bInvalidated Then pRender(PaintOptions)
            Return oFont
        End Function

        Friend Function GetBrush(PaintOptions As cOptionsCenterline) As Brush
            If bInvalidated Then pRender(PaintOptions)
            Return oBrush
        End Function

        Friend Function GetWireframePen(PaintOptions As cOptionsCenterline) As Pen
            If bInvalidated Then pRender(PaintOptions)
            Return oWireframePen
        End Function

        Public ReadOnly Property ToHTMLString(PaintOptions As cOptionsCenterline) As String
            Get
                Dim sTempFontName As String = sFontName
                Dim sTempFontSize As Single = sFontSize
                If sTempFontName = "" Or sTempFontSize <= 0 Then
                    Dim oDesignTextFont As cIFont = PaintOptions.GetCurrentDesignPropertiesValue("DesignTextFont", modPaint.GetDefaultFont)
                    If sTempFontName = "" Then
                        sTempFontName = oDesignTextFont.FontName
                    End If
                    If sTempFontSize <= 0 Then
                        sTempFontSize = PaintOptions.GetFontDefaultSize(iType)
                    End If
                End If
                Dim iFontStyle As FontStyle = FontStyle
                Return "<font='" & sTempFontName & "'><size=" & modNumbers.NumberToString(sTempFontSize, "0.00") & ">" & If(iFontStyle And FontStyle.Bold, "<b>", "") & If(iFontStyle And FontStyle.Italic, "<i>", "") & If(iFontStyle And FontStyle.Underline, "<u>", "") & If(iFontStyle And FontStyle.Strikeout, "<s>", "") & sName & If(iFontStyle And FontStyle.Strikeout, "</s>", "") & If(iFontStyle And FontStyle.Underline, "</u>", "") & If(iFontStyle And FontStyle.Italic, "</i>", "") & If(iFontStyle And FontStyle.Bold, "</b>", "") & "</size></font>"
            End Get
        End Property

        Friend Sub Render(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Path As GraphicsPath, ByVal Cache As cDrawCache)
            If bInvalidated Then pRender(PaintOptions)
            Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border, Path, Nothing, oWireframePen, oBrush)
        End Sub

        Friend Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Path As GraphicsPath)
            If bInvalidated Then pRender(PaintOptions)
            If (Options And cItem.PaintOptionsEnum.Wireframe) = cItem.PaintOptionsEnum.Wireframe Or (Options And cItem.PaintOptionsEnum.SchematicLayerDraw) = cItem.PaintOptionsEnum.SchematicLayerDraw Then
                Call Graphics.DrawPath(oWireframePen, Path)
            Else
                Call Graphics.FillPath(oBrush, Path)
            End If
        End Sub

        Private Sub pRender(ByVal PaintOptions As cOptionsCenterline)
            Dim oRenderArgs As cRenderArgs = New cRenderArgs
            RaiseEvent OnRender(Me, oRenderArgs)

            Dim sTempFontName As String = sFontName
            Dim sTempFontSize As Single = sFontSize
            If sTempFontName = "" OrElse sTempFontSize <= 0 Then
                Dim oDesignTextFont As cIFont = PaintOptions.GetCurrentDesignPropertiesValue("DesignTextFont", modPaint.GetDefaultFont)
                If sTempFontName = "" Then
                    sTempFontName = oDesignTextFont.FontName
                End If
                If sTempFontSize <= 0 Then
                    sTempFontSize = PaintOptions.GetFontDefaultSize(iType)
                End If
                If sTempFontSize <= 0 Then
                    sTempFontSize = 8
                End If
            End If

            Dim iFontStyle As FontStyle = FontStyle
            If Not IsNothing(oFont) Then oFont.Dispose()
            oFont = New Font(sTempFontName, sTempFontSize, iFontStyle)

            Dim oPaintColor As Color = Color.FromArgb((1 - oRenderArgs.Transparency) * 255, oColor)
            If Not IsNothing(oBrush) Then oBrush.Dispose()
            oBrush = New SolidBrush(oPaintColor)

            Dim sLineWidth As Single
            If sLocalLineWidth = 0 Then
                sLineWidth = PaintOptions.GetCurrentDesignPropertiesValue("BaseLineWidthScaleFactor", 0.01)
            Else
                sLineWidth = sLocalLineWidth
            End If

            If Not IsNothing(oWireframePen) Then oWireframePen.Dispose()
            oWireframePen = New Pen(oPaintColor, cEditPaintObjects.FilettoPenWidth)
            oWireframePen.SetLineCap(Drawing2D.LineCap.Round, Drawing2D.LineCap.Round, Drawing2D.DashCap.Round)
            oWireframePen.LineJoin = Drawing2D.LineJoin.Round
            oWireframePen.DashStyle = DashStyle.Dot

            bInvalidated = False
        End Sub

        Private Sub oSurvey_OnPropertiesChanged(ByVal Sender As cSurvey, ByVal Args As cSurvey.OnPropertiesChangedEventArgs) Handles oSurvey.OnPropertiesChanged
            Call pInvalidate()
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    If Not IsNothing(oFont) Then
                        Call oFont.Dispose()
                        oFont = Nothing
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

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
        End Sub
#End Region

    End Class
End Namespace
