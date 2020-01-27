Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings

Namespace cSurvey.Design.Items
    Public Class cItemText
        Inherits cItem
        Implements cIItemText
        Implements cIItemLineableText
        Implements cIItemVerticalLineableText
        Implements cIItemRotable

        Private oSurvey As cSurvey

        Private sText As String
        Private WithEvents oFont As cItemFont

        Private iTextSize As cIItemSizable.SizeEnum
        Private iTextRotateMode As cIItemRotable.RotateModeEnum
        Private iTextAlignment As cIItemLineableText.TextAlignmentEnum
        Private iTextVerticalAlignment As cIItemVerticalLineableText.TextVerticalAlignmentEnum

        Private sAngle As Single

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

        Public Overridable ReadOnly Property AvaiableTextProperties As cIItemText.AvaiableTextPropertiesEnum Implements cIItemText.AvaiableTextProperties
            Get
                Return cIItemText.AvaiableTextPropertiesEnum.Rotable Or cIItemText.AvaiableTextPropertiesEnum.Lineable Or cIItemText.AvaiableTextPropertiesEnum.VerticalLineable
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

        Public Overrides ReadOnly Property CanBeReduced As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Property Transparency As Single
            Get
                Return MyBase.Transparency
            End Get
            Set(value As Single)
                If MyBase.Transparency <> value Then
                    MyBase.Transparency = value
                    Call oFont.Invalidate()
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

        Public Overrides ReadOnly Property HaveSketch As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveQuota As Boolean
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

        Public Overrides ReadOnly Property CanBeMoved As Boolean
            Get
                Return True
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

        Public Overrides ReadOnly Property BindMode As cItem.BindModeEnum
            Get
                Return BindModeEnum.CenterPoint
            End Get
        End Property

        Public Overrides Function GetCenterPoint() As PointF
            Return MyBase.Points(0).Point
        End Function

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
                Return iTextRotateMode = cIItemRotable.RotateModeEnum.Rotable
            End Get
        End Property

        Public Overrides ReadOnly Property HaveEditablePoints As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveBrush As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HavePen As Boolean
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

        Public Enum cItemTextTypes
            Text = 0
            InformationBox = 1
        End Enum

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, Type As cItemTextTypes, ByVal Category As cIItem.cItemCategoryEnum, ByVal Text As String)
            Call MyBase.New(Survey, Design, Layer, If(Type = cItemTextTypes.Text, cIItem.cItemTypeEnum.Text, cIItem.cItemTypeEnum.InformationBoxText), Category)
            oSurvey = Survey
            oFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.Generic)
            iTextRotateMode = Survey.Properties.DesignProperties.GetValue("DesignTextRotateMode", cIItemRotable.RotateModeEnum.Fixed)
            iTextAlignment = cIItemLineableText.TextAlignmentEnum.Center
            iTextVerticalAlignment = cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle
            sText = Text
            Call FixBound()
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum, ByVal Text As String)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.Text, Category)
            oSurvey = Survey
            oFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.Generic)
            iTextRotateMode = Survey.Properties.DesignProperties.GetValue("DesignTextRotateMode", cIItemRotable.RotateModeEnum.Fixed)
            iTextAlignment = cIItemLineableText.TextAlignmentEnum.Center
            iTextVerticalAlignment = cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle
            sText = Text
            Call FixBound()
        End Sub

        Friend Overrides Function GetTextScaleFactor(PaintOptions As cOptions) As Single
            Dim sTextScaleFactor As Single = MyBase.GetTextScaleFactor(PaintOptions)
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

        Public Overrides Sub Rotate(ByVal Angle As Single)
            sAngle += Angle
            'Call MyBase.Rotate(Angle)
            Call MyBase.Caches.Invalidate()
        End Sub

        Public Overrides Sub RotateAt(ByVal Center As PointF, ByVal Angle As Single)
            sAngle += Angle
            Call MyBase.RotateAt(Center, Angle)
            Call MyBase.Caches.Invalidate()
        End Sub

        Friend Overrides Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
            Using oMatrix As Matrix = New Matrix
                If PaintOptions.DrawTranslation Then
                    Dim oTranslation As SizeF = MyBase.Design.GetItemTranslation(Me)
                    Call oMatrix.Translate(oTranslation.Width, oTranslation.Height)
                End If
                Dim oSVGItem As XmlElement = MyBase.Caches(PaintOptions).ToSvgItem(SVG, PaintOptions, Options, oMatrix)
                Call oSVGItem.SetAttribute("name", MyBase.Name)
                Return oSVGItem
            End Using
        End Function

        Friend Overrides Function ToSvg(ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlDocument
            Dim oSVG As XmlDocument = modSVG.CreateSVG
            Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions, Options))
            Return oSVG
        End Function

        Friend Overrides Sub Render(ByVal Graphics As System.Drawing.Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            Dim oCache As cDrawCache = MyBase.Caches(PaintOptions)
            With oCache
                If .Invalidated Then
                    Call .Clear()

                    Using oPath As GraphicsPath = New GraphicsPath
                        Using oSF As StringFormat = New StringFormat
                            Select Case iTextAlignment
                                Case cIItemLineableText.TextAlignmentEnum.Center
                                    oSF.Alignment = StringAlignment.Center
                                Case cIItemLineableText.TextAlignmentEnum.Left
                                    oSF.Alignment = StringAlignment.Near
                                Case cIItemLineableText.TextAlignmentEnum.Right
                                    oSF.Alignment = StringAlignment.Far
                            End Select
                            Select Case iTextVerticalAlignment
                                Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Top
                                    oSF.LineAlignment = StringAlignment.Near
                                Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle
                                    oSF.LineAlignment = StringAlignment.Center
                                Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
                                    oSF.LineAlignment = StringAlignment.Far
                            End Select
                            Call oFont.AddToPath(PaintOptions, oPath, modPaint.ReplaceGlobalTags(oSurvey, Text), New PointF(0, 0), oSF)
                        End Using

                        Dim oPathRect As RectangleF = oPath.GetBounds

                        ''draw a ref for alignment in design mode (I do it here cause have to be aligned with text)
                        'If PaintOptions.IsDesign Then
                        '    Dim sRefX As Single
                        '    Dim sRefY As Single
                        '    Dim sRefWidth As Single = 2
                        '    Dim sRefHeight As Single = 2
                        '    Select Case iTextAlignment
                        '        Case cIItemLineableText.TextAlignmentEnum.Center
                        '            sRefX = oPathRect.Width / 2 - sRefWidth / 2
                        '        Case cIItemLineableText.TextAlignmentEnum.Left
                        '            sRefX = oPathRect.Left
                        '        Case cIItemLineableText.TextAlignmentEnum.Right
                        '            sRefX = oPathRect.Right - sRefWidth
                        '    End Select
                        '    Select Case iTextVerticalAlignment
                        '        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Top
                        '            sRefY = oPathRect.Top
                        '        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle
                        '            sRefY = oPathRect.Height / 2 - sRefHeight / 2
                        '        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
                        '            sRefY = oPathRect.Bottom - sRefHeight
                        '    End Select
                        '    Call oPath.AddRectangle(New RectangleF(sRefX, sRefY, sRefWidth, sRefHeight))
                        'End If

                        'riallineo il testo (se richiesto dall'allineamento)
                        Dim sX As Single
                        Dim sY As Single
                        Select Case iTextAlignment
                            Case cIItemLineableText.TextAlignmentEnum.Center
                                sX = oPathRect.Width / 2
                            Case cIItemLineableText.TextAlignmentEnum.Right
                                sX = oPathRect.Width
                        End Select
                        Select Case iTextVerticalAlignment
                            Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle
                                sY = oPathRect.Height / 2
                            Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
                                sY = oPathRect.Height
                        End Select
                        If sX <> 0 Or sY <> 0 Then
                            Using oTranslateMatrix As Matrix = New Matrix
                                Call oTranslateMatrix.Translate(sX, sY, MatrixOrder.Append)
                                Call oPath.Transform(oTranslateMatrix)
                            End Using
                        End If

                        'dimensiono il testo se rischiesto (il fattore di scala sarà da parametrizzare in qualche modo)
                        Using oScaleMatrix As Matrix = New Matrix
                            Dim sScale As Single = GetTextScaleFactor(PaintOptions)
                            Call oScaleMatrix.Scale(sScale, sScale, MatrixOrder.Append)
                            Call oPath.Transform(oScaleMatrix)
                        End Using

                        oPathRect = oPath.GetBounds

                        'sposto il testo scalato nel punto di disegno
                        Select Case iTextAlignment
                            Case cIItemLineableText.TextAlignmentEnum.Center
                                sX = MyBase.Points(0).Point.X - oPathRect.Width / 2 ', MyBase.Points(0).Point.Y - oPathRect.Height / 2)
                            Case cIItemLineableText.TextAlignmentEnum.Left
                                sX = MyBase.Points(0).Point.X ', MyBase.Points(0).Point.Y - oPathRect.Height / 2)
                            Case cIItemLineableText.TextAlignmentEnum.Right
                                sX = MyBase.Points(0).Point.X - oPathRect.Width ', MyBase.Points(0).Point.Y - oPathRect.Height / 2)
                        End Select
                        Select Case iTextVerticalAlignment
                            Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Top
                                sY = MyBase.Points(0).Point.Y
                            Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle
                                sY = MyBase.Points(0).Point.Y - oPathRect.Height / 2
                            Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
                                sY = MyBase.Points(0).Point.Y - oPathRect.Height
                        End Select
                        Using oTranslateMatrix = New Matrix
                            Call oTranslateMatrix.Translate(sX, sY, MatrixOrder.Append)
                            Call oPath.Transform(oTranslateMatrix)
                        End Using

                        'ruoto la clipart dell'angolo determinato da quanto sopra
                        If iTextRotateMode = cIItemRotable.RotateModeEnum.Rotable Then
                            Dim oMovedCenterPoint As PointF = MyBase.Points(0).Point
                            Using oRotateMatrix As Matrix = New Matrix
                                Call oRotateMatrix.RotateAt(sAngle, oMovedCenterPoint, MatrixOrder.Append)
                                Call oPath.Transform(oRotateMatrix)
                            End Using
                        End If
                        Call oFont.Render(Graphics, PaintOptions, Options, oPath, oCache)
                    End Using

                    Call .Rendered()
                End If
            End With
        End Sub

        Friend Overrides Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            If MyBase.Points.Count > 0 Then
                Call Render(Graphics, PaintOptions, Options, Selected)
                If Not PaintOptions.IsDesign Or (PaintOptions.IsDesign And Not MyBase.HiddenInDesign) Then '
                    MyBase.HavePaintProblem = Not MyBase.Caches(PaintOptions).Paint(Graphics, PaintOptions, Options)
                    If PaintOptions.ShowSegmentBindings Then
                        Call modPaint.PaintPointToSegmentBindings(Graphics, oSurvey, Me, Selected)
                    End If
                End If
            End If
        End Sub

        Public Sub FixBound(Optional ByVal ForceBound As Boolean = False)
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

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As Storage.cFile, ByVal item As XmlElement)
            Call MyBase.New(Survey, Design, Layer, File, item)
            oSurvey = Survey
            sText = modXML.GetAttributeValue(item, "text", "")
            Try
                oFont = New cItemFont(oSurvey, item.Item("font"))
            Catch ex As Exception
                oFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.Generic)
            End Try
            iTextSize = modXML.GetAttributeValue(item, "textsize")
            iTextRotateMode = modXML.GetAttributeValue(item, "textrotatemode")
            iTextAlignment = modXML.GetAttributeValue(item, "textalignment", cIItemLineableText.TextAlignmentEnum.Center)
            iTextVerticalAlignment = modXML.GetAttributeValue(item, "textverticalalignment", cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle)
            Call FixBound()
            sAngle = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "angle", 0))
        End Sub

        Friend Overrides Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oItem As XmlElement = MyBase.SaveTo(File, Document, Parent, Options)
            Call oItem.SetAttribute("text", sText)
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
            If iTextRotateMode <> cIItemRotable.RotateModeEnum.Rotable Then
                Call oItem.SetAttribute("textrotatemode", iTextRotateMode)
            End If
            If sAngle <> 0 Then
                Call oItem.SetAttribute("angle", modNumbers.NumberToString(sAngle))
            End If
            Return oItem
        End Function

        Public Overridable Property TextRotateMode() As cIItemRotable.RotateModeEnum Implements cIItemRotable.RotateMode
            Get
                Return iTextRotateMode
            End Get
            Set(ByVal value As cIItemRotable.RotateModeEnum)
                If iTextRotateMode <> value Then
                    iTextRotateMode = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Overridable Property TextSize() As cIItemSizable.SizeEnum Implements cIItemSizable.Size
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

        Public Overridable Property Text As String Implements cIItemText.Text
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

        Public Overrides ReadOnly Property CanImportGeneric As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Function FromGeneric(ByVal Item As cItemGeneric, Optional ByVal Clear As Boolean = False) As Boolean
            Return False
        End Function

        Private Sub oFont_OnChanged(ByVal Sender As cItemFont) Handles oFont.OnChanged
            Call MyBase.Caches.Invalidate()
        End Sub

        Public Property TextVerticalAlignment As cIItemVerticalLineableText.TextVerticalAlignmentEnum Implements cIItemVerticalLineableText.TextVerticalAlignment
            Get
                Return iTextVerticalAlignment
            End Get
            Set(value As cIItemVerticalLineableText.TextVerticalAlignmentEnum)
                If iTextVerticalAlignment <> value Then
                    iTextVerticalAlignment = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Private Sub oFont_OnRender(sender As cItemFont, RenderArgs As cItemFont.cRenderArgs) Handles oFont.OnRender
            If HaveTransparency Then
                RenderArgs.Transparency = MyBase.Transparency
            End If
        End Sub
    End Class

End Namespace
