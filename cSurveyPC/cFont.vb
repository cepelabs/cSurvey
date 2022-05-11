Imports cSurveyPC
Imports cSurveyPC.cSurvey

Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace cSurvey
    Public Class cFont
        Implements cIFont

        Private WithEvents oSurvey As cSurvey

        Private oColor As Color

        Private sFontName As String
        Private sFontSize As Single
        Private bFontBold As Boolean
        Private bFontItalic As Boolean
        Private bFontUnderline As Boolean

        Private oFont As Font
        Private oBrush As SolidBrush
        Private oWireframePen As Pen

        Public Function Clone() As cIFont Implements cIFont.Clone
            Return New cFont(Me)
        End Function

        Public Overrides Function ToString() As String
            Return sFontName & ", " & modNumbers.NumberToString(sFontSize) & "," & IIf(bFontBold, " " & GetLocalizedString("itemfont.textpart1"), "") & IIf(bFontItalic, " " & GetLocalizedString("itemfont.textpart2"), "") & IIf(FontUnderline, " " & GetLocalizedString("itemfont.textpart3"), "")
        End Function

        Public Sub CopyFrom(ByVal Font As cFont)
            sFontName = Font.sFontName
            sFontSize = Font.sFontSize
            bFontBold = Font.bFontBold
            bFontItalic = Font.bFontItalic
            bFontUnderline = Font.bFontUnderline
            oColor = Font.oColor
            Call pBindFont()
        End Sub

        Friend Sub New(ByVal Font As cFont)
            Call CopyFrom(Font)
        End Sub

        Friend ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal FontName As String, ByVal FontSize As Single, ByVal Color As Color, Optional ByVal Bold As Boolean = False, Optional ByVal Italic As Boolean = False, Optional ByVal Underline As Boolean = False)
            oSurvey = Survey
            sFontName = FontName
            sFontSize = FontSize
            bFontBold = Bold
            bFontItalic = Italic
            bFontUnderline = Underline
            oColor = Color
            Call pBindFont()
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            sFontName = oSurvey.Properties.DesignProperties.GetValue("DefaultFontName", "Tahoma")
            sFontSize = oSurvey.Properties.DesignProperties.GetValue("DefaultFontSize", 8)
            oColor = Color.Black
            Call pBindFont()
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal item As XmlElement)
            oSurvey = Survey
            oColor = Color.FromArgb(item.GetAttribute("color"))
            sFontName = modXML.GetAttributeValue(item, "fontname")
            sFontSize = modXML.GetAttributeValue(item, "fontsize")
            bFontBold = modXML.GetAttributeValue(item, "fontbold", False)
            bFontItalic = modXML.GetAttributeValue(item, "fontitalic", False)
            bFontUnderline = modXML.GetAttributeValue(item, "fontunderline", False)
            Call pBindFont()
        End Sub

        Friend Sub AddToPath(ByVal Path As GraphicsPath, ByVal Text As String, ByVal Point As PointF, ByVal StringFormat As StringFormat)
            Call Path.AddString(Text, oFont.FontFamily, oFont.Style, oFont.Size, Point, StringFormat)
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, ByVal Name As String) As XmlElement
            Dim oItem As XmlElement = Document.CreateElement(Name)
            Call oItem.SetAttribute("color", oColor.ToArgb)
            Call oItem.SetAttribute("fontname", sFontName)
            Call oItem.SetAttribute("fontsize", sFontSize)
            If bFontBold Then
                Call oItem.SetAttribute("fontbold", IIf(bFontBold, 1, 0))
            End If
            If bFontItalic Then
                Call oItem.SetAttribute("fontitalic", IIf(bFontBold, 1, 0))
            End If
            If bFontUnderline Then
                Call oItem.SetAttribute("fontunderline", IIf(bFontBold, 1, 0))
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
                    bFontUnderline = value
                    Call pBindFont()
                End If
            End Set
        End Property

        Public Property FontItalic() As Boolean Implements cIFont.FontItalic
            Get
                Return bFontItalic
            End Get
            Set(ByVal value As Boolean)
                If bFontItalic <> value Then
                    bFontItalic = value
                    Call pBindFont()
                End If
            End Set
        End Property

        Public Property Color() As Color Implements cIFont.Color
            Get
                Return oColor
            End Get
            Set(ByVal value As Color)
                If Color <> value Then
                    oColor = value
                    Call pBindFont()
                End If
            End Set
        End Property

        Public Property FontBold() As Boolean Implements cIFont.FontBold
            Get
                Return bFontBold
            End Get
            Set(ByVal value As Boolean)
                If bFontBold <> value Then
                    bFontBold = value
                    Call pBindFont()
                End If
            End Set
        End Property

        Public Property FontName() As String Implements cIFont.FontName
            Get
                Return sFontName
            End Get
            Set(ByVal value As String)
                If sFontName <> value Then
                    sFontName = value
                    Call pBindFont()
                End If
            End Set
        End Property

        Public Property FontSize() As Single Implements cIFont.FontSize
            Get
                Return sFontSize
            End Get
            Set(ByVal value As Single)
                If sFontSize <> value Then
                    sFontSize = value
                    Call pBindFont()
                End If
            End Set
        End Property

        Function GetSampleFont() As Font Implements cIFont.GetSampleFont
            Return oFont
        End Function

        Public ReadOnly Property Font() As Font
            Get
                Return oFont
            End Get
        End Property

        Friend ReadOnly Property Brush() As Brush
            Get
                Return oBrush
            End Get
        End Property

        Public ReadOnly Property FontStyle As FontStyle Implements cIFont.FontStyle
            Get
                Dim iFontStyle As FontStyle
                iFontStyle = IIf(bFontBold, iFontStyle Or FontStyle.Bold, iFontStyle)
                iFontStyle = IIf(bFontItalic, iFontStyle Or FontStyle.Italic, iFontStyle)
                iFontStyle = IIf(bFontUnderline, iFontStyle Or FontStyle.Underline, iFontStyle)
                Return iFontStyle
            End Get
        End Property

        Private Sub pBindFont()
            If sFontName = "" Then
                sFontName = oSurvey.Properties.DesignProperties.GetValue("DefaultFontName", "Tahoma")
            End If
            If sFontSize <= 0 Then
                sFontSize = oSurvey.Properties.DesignProperties.GetValue("DefaultFontSize", 8)
            End If
            Dim iFontStyle As FontStyle = FontStyle
            oFont = New Font(sFontName, sFontSize, iFontStyle)
            oBrush = New SolidBrush(oColor)
            oWireframePen = New Pen(oColor, 1)
            oWireframePen.SetLineCap(Drawing2D.LineCap.Round, Drawing2D.LineCap.Round, Drawing2D.DashCap.Round)
            oWireframePen.LineJoin = Drawing2D.LineJoin.Round
            oWireframePen.DashStyle = DashStyle.Dot
        End Sub

        Private Sub oSurvey_OnPropertiesChanged(ByVal Sender As cSurvey, ByVal Args As cSurvey.OnPropertiesChangedEventArgs) Handles oSurvey.OnPropertiesChanged
            Call pBindFont()
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
                    If Not IsNothing(oBrush) Then
                        Call oBrush.Dispose()
                        oBrush = Nothing
                    End If
                    If Not IsNothing(oWireframePen) Then
                        Call oWireframePen.Dispose()
                        oWireframePen = Nothing
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
