Imports System.Drawing.Drawing2D
Imports System.Web.UI.WebControls
Imports System.Windows.Forms.VisualStyles
Imports System.Xml
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors.ButtonPanel

Namespace cSurvey.Drawings
    Public Class cDrawCache
        Implements IEnumerable
        Implements IDisposable

        Private bBounds As Boolean
        Private oBounds As RectangleF
        Private oItems As List(Of cDrawCacheItem)

        Private bInvalidaded As Boolean

        Private iMaxDrawItemCount As Integer

        Public Function Hittest(Graphics As Graphics, Point As PointF, Scale As Single, Precision As Single, Wide As Single) As Boolean
            Try
                Dim oPoint As PointF = Point ' New PointF(Point.X * Precision, Point.Y * Precision)
                SyncLock oItems
                    For Each oItem As cDrawCacheItem In oItems
                        If oItem.Type = cDrawCacheItem.cDrawCacheItemType.Filler Then
                            If oItem.Path.IsVisible(Point, Graphics) Then
                                Return True
                            End If
                        End If
                        If oItem.Type = cDrawCacheItem.cDrawCacheItemType.Filler OrElse oItem.Type = cDrawCacheItem.cDrawCacheItemType.Border Then
                            Using oPath As GraphicsPath = oItem.Path.Clone
                                Using oPen As Pen = If(IsNothing(oItem.Pen), Nothing, oItem.Pen.Clone)
                                    If Not IsNothing(oPen) Then oPen.Width = 0.2F * 25.0F / Scale 'If(oPen.Width <= 0, 0.1F, oPen.Width) * Scale * Wide * Precision
                                    oPath.FillMode = FillMode.Winding
                                    Call oPath.Widen(oPen)
                                    If oPath.IsVisible(Point, Graphics) Then
                                        Return True
                                    End If
                                End Using
                            End Using
                        End If
                    Next
                End SyncLock
                Return False
            Catch ex As Exception
                Return GetBounds.Contains(Point)
            End Try
        End Function

        Friend Sub New()
            oItems = New List(Of cDrawCacheItem)
            bInvalidaded = True
            iMaxDrawItemCount = modMain.GetMaxDrawItemCount
        End Sub

        Public Function AddString(ByVal Text As String, ByVal FontFamily As String, FontStyle As FontStyle, FontSize As Single, FontUnit As GraphicsUnit, ByVal Point As PointF, ByVal HorizontalAlign As cIItemLineableText.TextAlignmentEnum, ByVal VerticalAlign As cIItemVerticalLineableText.TextVerticalAlignmentEnum, RotationAngle As Single) As cDrawCacheItem
            Dim oItem As cDrawCacheItemText = New cDrawCacheItemText(Text, FontFamily, FontStyle, FontSize, FontUnit, Point, HorizontalAlign, VerticalAlign, RotationAngle)
            Call oItems.Add(oItem)
            bBounds = False
            Return oItem
        End Function

        Public Function AddString(ByVal Text As String, ByVal FontFamily As String, FontStyle As FontStyle, FontSize As Single, FontUnit As GraphicsUnit, ByVal Rectangle As RectangleF, ByVal HorizontalAlign As cIItemLineableText.TextAlignmentEnum, ByVal VerticalAlign As cIItemVerticalLineableText.TextVerticalAlignmentEnum, RotationAngle As Single) As cDrawCacheItem
            Dim oItem As cDrawCacheItemText = New cDrawCacheItemText(Text, FontFamily, FontStyle, FontSize, FontUnit, Rectangle, HorizontalAlign, VerticalAlign, RotationAngle)
            Call oItems.Add(oItem)
            bBounds = False
            Return oItem
        End Function

        Public Function AddSetClip(ClipPath As GraphicsPath) As cDrawCacheItem
            Dim oItem As cDrawCacheItem = New cDrawCacheItem(cDrawCacheItem.cDrawCacheItemType.SetClip)
            Call oItem.AddPath(ClipPath)
            Call oItems.Add(oItem)
            bBounds = False
            Return oItem
        End Function

        Public Function AddResetClip() As cDrawCacheItem
            Dim oItem As cDrawCacheItem = New cDrawCacheItem(cDrawCacheItem.cDrawCacheItemType.ResetClip)
            Call oItems.Add(oItem)
            bBounds = False
            Return oItem
        End Function

        Public Function AddBorder(Optional ByVal Path As GraphicsPath = Nothing, Optional ByVal Pen As Pen = Nothing, Optional ByVal WireframePen As Pen = Nothing, Optional ByVal Brush As Brush = Nothing) As cDrawCacheItem
            Dim oItem As cDrawCacheItem = New cDrawCacheItem(cDrawCacheItem.cDrawCacheItemType.Border, Path, Pen, WireframePen, Brush)
            Call oItems.Add(oItem)
            bBounds = False
            Return oItem
        End Function

        Public Function AddFiller(Optional ByVal Path As GraphicsPath = Nothing, Optional ByVal Pen As Pen = Nothing, Optional ByVal WireframePen As Pen = Nothing, Optional ByVal Brush As Brush = Nothing) As cDrawCacheItem
            Dim oItem As cDrawCacheItem = New cDrawCacheItem(cDrawCacheItem.cDrawCacheItemType.Filler, Path, Pen, WireframePen, Brush)
            Call oItems.Add(oItem)
            bBounds = False
            Return oItem
        End Function

        Public Function Add(Type As cDrawCacheItem.cDrawCacheItemType) As cDrawCacheItem
            Dim oItem As cDrawCacheItem = New cDrawCacheItem(Type)
            Call oItems.Add(oItem)
            bBounds = False
            Return oItem
        End Function

        Public Function Add(Type As cDrawCacheItem.cDrawCacheItemType, ByVal Path As GraphicsPath, Optional ByVal Pen As Pen = Nothing, Optional ByVal WireframePen As Pen = Nothing, Optional ByVal Brush As Brush = Nothing) As cDrawCacheItem
            Dim oItem As cDrawCacheItem = New cDrawCacheItem(Type, Path, Pen, WireframePen, Brush)
            Call oItems.Add(oItem)
            bBounds = False
            Return oItem
        End Function

        Default Public ReadOnly Property Item(ByVal Index As Integer) As cDrawCacheItem
            Get
                Return oItems(Index)
            End Get
        End Property

        Public ReadOnly Property Count() As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Sub Remove(ByVal Item As cDrawCacheItem)
            Call oItems.Remove(Item)
            bBounds = False
        End Sub

        Public Sub Remove(ByVal Index As Integer)
            Call oItems.RemoveAt(Index)
            bBounds = False
        End Sub

        Public Sub Clear()
            Call oItems.Clear()
            bBounds = False
        End Sub

        Public Sub Invalidate()
            If Not Invalidated Then
                bInvalidaded = True
                Call oItems.Clear()
                bBounds = False
            End If
        End Sub

        Public ReadOnly Property Invalidated As Boolean
            Get
                Return bInvalidaded
            End Get
        End Property

        Public Sub Rendered()
            bBounds = False
            Call GetBounds()
            bInvalidaded = False
        End Sub

        Public Sub ResetOffset()
            Dim oPoint As PointF = GetBounds.Location
            If Not oPoint.IsEmpty Then
                Using oTraslateMatix As Matrix = New Matrix
                    Call oTraslateMatix.Translate(-oPoint.X, -oPoint.Y)
                    Call Trasform(oTraslateMatix)
                End Using
                bBounds = False
            End If
        End Sub

        Public Sub Trasform(Matrix As Matrix)
            SyncLock oItems
                For Each oItem As cDrawCacheItem In oItems
                    Call oItem.Transform(Matrix)
                Next
            End SyncLock
            bBounds = False
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Public Function GetBounds() As RectangleF
            If Not bBounds Then
                Dim oRect As RectangleF
                SyncLock oItems
                    For Each oItem As cDrawCacheItem In oItems.Where(Function(item) item.Type = cDrawCacheItem.cDrawCacheItemType.Border OrElse item.Type = cDrawCacheItem.cDrawCacheItemType.SetClip)
                        Dim oNewRect As RectangleF = oItem.GetBounds
                        If Not modPaint.IsRectangleEmpty(oNewRect) Then
                            If modPaint.IsRectangleEmpty(oRect) Then
                                oRect = oNewRect
                            Else
                                oRect = RectangleF.Union(oRect, oNewRect)
                            End If
                        End If
                    Next
                End SyncLock
                oBounds = oRect
                bBounds = True
            End If
            Return oBounds
        End Function

        Friend Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.SVGOptionsEnum, Optional ByVal Matrix As Matrix = Nothing) As XmlElement
            Dim oSVGGroup As XmlElement = modSVG.CreateGroup(SVG)
            Dim sKey As String = ""

            SyncLock oItems
                If (Options And cItem.SVGOptionsEnum.ClipartBrushes) = cItem.SVGOptionsEnum.ClipartBrushes Then
                    For Each oItem As cDrawCacheItem In oItems.Where(Function(Item) Item.Type <= cDrawCacheItem.cDrawCacheItemType.ResetClip)
                        If oItem.Type = cDrawCacheItem.cDrawCacheItemType.SetClip Then
                            sKey = "clip_" & Guid.NewGuid.ToString
                            Dim oSVGClipPath As XmlElement = modSVG.CreateClipPath(SVG, sKey)
                            Call modSVG.AppendItem(SVG, oSVGClipPath, PaintOptions, oItem.Path)
                            Call modSVG.AppendItem(SVG, oSVGGroup, oSVGClipPath)
                        ElseIf oItem.Type = cDrawCacheItem.cDrawCacheItemType.Filler Then
                            Dim oSVGItem As XmlElement = oItem.AppendSvgItem(SVG, oSVGGroup, PaintOptions, Options, Matrix)
                            If Not oSVGItem Is Nothing AndAlso sKey <> "" Then
                                Call oSVGItem.SetAttribute("clip-path", "url(#" & sKey & ")")
                            End If
                        Else
                            sKey = ""
                        End If
                    Next
                End If

                For Each oItem As cDrawCacheItem In oItems
                    If oItem.Type = cDrawCacheItem.cDrawCacheItemType.Border OrElse oItem.Type = cDrawCacheItem.cDrawCacheItemType.Text Then
                        Call oItem.AppendSvgItem(SVG, oSVGGroup, PaintOptions, Options, Matrix)
                    End If
                Next
            End SyncLock

            Return oSVGGroup
        End Function

        Public Function Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum) As Boolean
            Try
                If oItems.Count > 0 Then
                    If (Options And cItem.PaintOptionsEnum.Wireframe) = cItem.PaintOptionsEnum.Wireframe OrElse (Options And cItem.PaintOptionsEnum.SchematicLayerDraw) = cItem.PaintOptionsEnum.SchematicLayerDraw Then
                        'Dim sVisibleScaleFactor As Single = (39.37008F * Graphics.DpiX) / PaintOptions.CurrentScale
                        Dim oItemsToDraw As IEnumerable(Of cDrawCacheItem) = oItems.Where(Function(item) item.IsWireframeOutlined)
                        If Not (Options And cItem.PaintOptionsEnum.IgnoreMaxDrawItemCount) = cItem.PaintOptionsEnum.IgnoreMaxDrawItemCount AndAlso oItemsToDraw.Count > iMaxDrawItemCount Then
                            Dim oItem As cDrawCacheItem = oItemsToDraw.First
                            Dim oRect As RectangleF = GetBounds()
                            Call Graphics.DrawRectangle(oItem.WireframePen, oRect.X, oRect.Y, oRect.Width, oRect.Height)
                        Else
                            SyncLock oItemsToDraw
                                For Each oItem As cDrawCacheItem In oItemsToDraw
                                    'there is a strange gdi behaviour: when and object is very small (< some pixels of screen bounds)
                                    'gdi, with wireframe pen, raise out of memory error
                                    'to avoid this I found 2 ways: 
                                    '-Calculate the real bounds of the object but this require a great overload during scaling
                                    '-use a try catch
                                    'testing performace the final result is that try catch is faster that scaling a rect and checking is size so I follow this way
                                    'Dim oBounds As RectangleF = oItem.Path.GetBounds
                                    'oBounds = modPaint.ScaleRectangle(oBounds, sVisibleScaleFactor)
                                    'If oBounds.Width > 2.0F AndAlso oBounds.Height > 2.0F Then
                                    '    Call Graphics.DrawPath(oItem.WireframePen, oItem.Path)
                                    'End If
                                    Try
                                        Call Graphics.DrawPath(oItem.WireframePen, oItem.Path)
                                    Catch ex As Exception
                                        'Call PaintOptions.Survey.RaiseOnLogEvent(cSurvey.LogEntryType.Warning, "cache paint warning: " & ex.Message, True)
                                    End Try
                                Next
                            End SyncLock
                        End If
                    Else
                        Dim oRestores As Stack(Of Boolean) = New Stack(Of Boolean)
                        Dim oStates As Stack(Of GraphicsState) = New Stack(Of GraphicsState)
                        SyncLock oItems
                            For Each oItem As cDrawCacheItem In oItems
                                If oItem.Type = cDrawCacheItem.cDrawCacheItemType.SetClip Then
                                    Using oClip As Region = New Region(oItem.Path)
                                        If Not oClip Is Nothing AndAlso Not (Options And cItem.PaintOptionsEnum.SchematicLayerDraw) = cItem.PaintOptionsEnum.SchematicLayerDraw Then
                                            If Not (oClip.IsEmpty(Graphics) OrElse oClip.IsInfinite(Graphics)) Then
                                                Call oRestores.Push(True)
                                                Call oStates.Push(Graphics.Save)
                                                If Graphics.Clip.IsEmpty(Graphics) OrElse Graphics.Clip.IsInfinite(Graphics) Then
                                                    Call Graphics.SetClip(oClip, CombineMode.Replace)
                                                Else
                                                    Call Graphics.SetClip(oClip, CombineMode.Intersect)
                                                End If
                                            Else
                                                'mark graphic as not be restored
                                                Call oRestores.Push(False)
                                            End If
                                        Else
                                            'mark graphic as not be restored
                                            Call oRestores.Push(False)
                                        End If
                                    End Using
                                ElseIf oItem.Type = cDrawCacheItem.cDrawCacheItemType.Filler Then
                                    If oItem.IsFilled Then
                                        Call Graphics.FillPath(oItem.Brush, oItem.Path)
                                    End If
                                    If oItem.IsOutlined Then
                                        Call Graphics.DrawPath(oItem.Pen, oItem.Path)
                                    End If
                                ElseIf oItem.Type = cDrawCacheItem.cDrawCacheItemType.Border OrElse oItem.Type = cDrawCacheItem.cDrawCacheItemType.Text Then
                                    If oItem.IsFilled Then
                                        Call Graphics.FillPath(oItem.Brush, oItem.Path)
                                    End If
                                    If oItem.IsOutlined Then
                                        Call Graphics.DrawPath(oItem.Pen, oItem.Path)
                                    End If
                                Else
                                    If oRestores.Pop() Then
                                        'restore graphic state
                                        Call Graphics.Restore(oStates.Pop())
                                    End If
                                End If
                            Next
                        End SyncLock
                    End If
                End If
                Return True
            Catch ex As Exception
                Call PaintOptions.Survey.RaiseOnLogEvent(cSurvey.LogEntryType.Error, "cache paint error: " & ex.Message)
                Return False
            End Try
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    'If Not oClip Is Nothing Then oClip.Dispose()
                    'If Not oClipPath Is Nothing Then oClipPath.Dispose()
                    For Each oItem As cDrawCacheItem In oItems
                        Call oItem.Dispose()
                    Next
                    Call oItems.Clear()
                End If
                'oClip = Nothing
                'oClipPath = Nothing
                oItems = Nothing
            End If
            Me.disposedValue = True
        End Sub

        ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(disposing As Boolean).
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Public Class cDrawCacheItemText
        Inherits cDrawCacheItem

        Private sText As String
        Private sFontFamily As String
        Private iFontStyle As FontStyle
        Private sFontSize As Single
        Private iFontUnit As GraphicsUnit
        Private oPoint As PointF
        Private oSize As SizeF
        Private iHorizontalAlign As cIItemLineableText.TextAlignmentEnum
        Private iVerticalAlign As cIItemVerticalLineableText.TextVerticalAlignmentEnum
        Private sRotationAngle As Single

        Public Sub New(ByVal Text As String, ByVal FontFamily As String, FontStyle As FontStyle, FontSize As Single, FontUnit As GraphicsUnit, ByVal Rectangle As RectangleF, ByVal HorizontalAlign As cIItemLineableText.TextAlignmentEnum, ByVal VerticalAlign As cIItemVerticalLineableText.TextVerticalAlignmentEnum, RotationAngle As Single)
            MyBase.New(cDrawCacheItemType.Text)
            sText = Text
            sFontFamily = FontFamily
            iFontStyle = FontStyle
            sFontSize = FontSize
            iFontUnit = FontUnit
            oPoint = Rectangle.Location
            oSize = Rectangle.Size
            iHorizontalAlign = HorizontalAlign
            iVerticalAlign = VerticalAlign
            sRotationAngle = RotationAngle
            Call pRender()
        End Sub

        Public Sub New(ByVal Text As String, ByVal FontFamily As String, FontStyle As FontStyle, FontSize As Single, FontUnit As GraphicsUnit, ByVal Point As PointF, ByVal HorizontalAlign As cIItemLineableText.TextAlignmentEnum, ByVal VerticalAlign As cIItemVerticalLineableText.TextVerticalAlignmentEnum, RotationAngle As Single)
            MyBase.New(cDrawCacheItemType.Text)
            sText = Text
            sFontFamily = FontFamily
            iFontStyle = FontStyle
            sFontSize = FontSize
            iFontUnit = FontUnit
            oPoint = Point
            oSize = New Size(0, 0)
            iHorizontalAlign = HorizontalAlign
            iVerticalAlign = VerticalAlign
            sRotationAngle = RotationAngle
            Call pRender()
        End Sub

        Private Sub pRender()
            'TODO
            'Call MyBase.AddString(sText, Font, oPoint, oFormat)

            Using oPath As GraphicsPath = New GraphicsPath

                Using oSF As StringFormat = New StringFormat
                    Select Case iHorizontalAlign
                        Case cIItemLineableText.TextAlignmentEnum.Center
                            oSF.Alignment = StringAlignment.Center
                        Case cIItemLineableText.TextAlignmentEnum.Left
                            oSF.Alignment = StringAlignment.Near
                        Case cIItemLineableText.TextAlignmentEnum.Right
                            oSF.Alignment = StringAlignment.Far
                    End Select
                    Select Case iVerticalAlign
                        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Top
                            oSF.LineAlignment = StringAlignment.Near
                        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle
                            oSF.LineAlignment = StringAlignment.Center
                        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
                            oSF.LineAlignment = StringAlignment.Far
                    End Select
                    oPath.AddString(sText, New FontFamily(sFontFamily), iFontStyle, sFontSize, New PointF(0, 0), oSF)

                    Dim oPathRect As RectangleF = oPath.GetBounds

                    'text align
                    Dim sX As Single
                    Dim sY As Single
                    Select Case iHorizontalAlign
                        Case cIItemLineableText.TextAlignmentEnum.Center
                            sX = oPathRect.Width / 2
                        Case cIItemLineableText.TextAlignmentEnum.Right
                            sX = oPathRect.Width
                    End Select
                    Select Case iVerticalAlign
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

                    'text size
                    'Using oScaleMatrix As Matrix = New Matrix
                    '    Dim sScale As Single = GetTextScaleFactor(PaintOptions)
                    '    Call oScaleMatrix.Scale(sScale, sScale, MatrixOrder.Append)
                    '    Call oPath.Transform(oScaleMatrix)
                    'End Using

                    oPathRect = oPath.GetBounds

                    'move to final point
                    Select Case iHorizontalAlign
                        Case cIItemLineableText.TextAlignmentEnum.Center
                            sX = oPoint.X - oPathRect.Width / 2 ', MyBase.Points(0).Point.Y - oPathRect.Height / 2)
                        Case cIItemLineableText.TextAlignmentEnum.Left
                            sX = oPoint.X ', MyBase.Points(0).Point.Y - oPathRect.Height / 2)
                        Case cIItemLineableText.TextAlignmentEnum.Right
                            sX = oPoint.X - oPathRect.Width ', MyBase.Points(0).Point.Y - oPathRect.Height / 2)
                    End Select
                    Select Case iVerticalAlign
                        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Top
                            sY = oPoint.Y
                        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle
                            sY = oPoint.Y - oPathRect.Height / 2
                        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
                            sY = oPoint.Y - oPathRect.Height
                    End Select
                    Using oTranslateMatrix = New Matrix
                        Call oTranslateMatrix.Translate(sX, sY, MatrixOrder.Append)
                        Call oPath.Transform(oTranslateMatrix)
                    End Using

                    'and rotate
                    If sRotationAngle <> 0F Then
                        Dim oMovedCenterPoint As PointF = oPoint
                        Using oRotateMatrix As Matrix = New Matrix
                            Call oRotateMatrix.RotateAt(sRotationAngle, oMovedCenterPoint, MatrixOrder.Append)
                            Call oPath.Transform(oRotateMatrix)
                        End Using
                    End If

                    MyBase.Path.AddPath(oPath, False)

                    'Call oFont.Render(Graphics, PaintOptions, Options, oPath, oCache)

                End Using
            End Using
        End Sub

        Friend Overrides Function AppendSvgItem(ByVal SVG As XmlDocument, ByVal Parent As XmlElement, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.SVGOptionsEnum, Optional ByVal Matrix As Matrix = Nothing) As XmlElement
            If sText <> "" Then
                'Dim oPoints As PointF() = {oPoint}
                'If Not Matrix Is Nothing Then
                '    Matrix.TransformPoints(oPoints)
                'End If
                'Dim oItem As XmlElement = modSVG.CreateText(SVG, sText, oPoints(0), sFontFamily, iFontStyle, sFontSize, iFontUnit)
                'Call modSVG.AppendItem(SVG, Parent, oItem)
                'Return oItem

                Dim oPoints As PointF() = {oPoint}
                If Not Matrix Is Nothing Then
                    Matrix.TransformPoints(oPoints)
                End If

                Using oPath As GraphicsPath = New GraphicsPath
                    Dim sRealFontSize As Single = sFontSize * 100.0F / 96.0F '/ 19.5819258

                    oPath.AddString(sText, New FontFamily(sFontFamily), iFontStyle, sRealFontSize, oPoint, Nothing) 'oFormat)
                    Dim oPathRect As RectangleF = oPath.GetBounds

                    Dim sX As Single = oPoints(0).X
                    Dim sY As Single = oPoints(0).Y

                    Select Case iVerticalAlign
                        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle
                            sY = sY - oPathRect.Height / 2
                        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
                            sY = sY - oPathRect.Height
                    End Select

                    Dim oXMLText As XmlElement = modSVG.CreateGeneric(SVG, "text")
                    Call modSVG.AppendItemStyle(SVG, oXMLText, If(MyBase.IsFilled, MyBase.Brush, Nothing), If(MyBase.IsOutlined, MyBase.Pen, Nothing))

                    Dim iLineCount As Integer = 0
                    Dim sLineY As Single = sY
                    Dim sDY As Single = 0
                    For Each sRealTextLine In sText.Split(vbCrLf)
                        Dim oXMLTextLine As XmlElement = modSVG.CreateGeneric(SVG, "tspan")
                        If modXML.HasAttribute(SVG.DocumentElement, "xmlns:inkscape") Then
                            Call oXMLTextLine.SetAttribute("role", modSVG.sodipodiNamespace, "line")
                        End If
                        'Call oXMLTextLine.SetAttribute("x", modNumbers.NumberToString(sX, ""))
                        Call oXMLTextLine.SetAttribute("dy", modNumbers.NumberToString(-sDY, ""))

                        Select Case iHorizontalAlign
                            Case cIItemLineableText.TextAlignmentEnum.Center
                                Call oXMLTextLine.SetAttribute("text-anchor", "middle")
                            Case cIItemLineableText.TextAlignmentEnum.Right
                                Call oXMLTextLine.SetAttribute("text-anchor", "end")
                        End Select

                        oXMLTextLine.InnerText = sRealTextLine.Replace(vbCr, "").Replace(vbLf, "")
                        oXMLText.AppendChild(oXMLTextLine)
                        sDY += 0.03F
                    Next

                    Call oXMLText.SetAttribute("x", modNumbers.NumberToString(sX, ""))
                    Call oXMLText.SetAttribute("y", modNumbers.NumberToString(sY, ""))
                    Call oXMLText.SetAttribute("dominant-baseline", "hanging")

                    Call oXMLText.SetAttribute("style", "font-family:" & sFontFamily & ";font-size:" & modNumbers.NumberToString(sRealFontSize, "") & "px")
                    If (iFontStyle And FontStyle.Bold) = FontStyle.Bold Then
                        Call modSVG.AppendItemStyle(SVG, oXMLText, "font-weight", "bold")
                    End If
                    If (iFontStyle And FontStyle.Italic) = FontStyle.Italic Then
                        Call modSVG.AppendItemStyle(SVG, oXMLText, "font-style", "italic")
                    End If
                    If (iFontStyle And FontStyle.Underline) = FontStyle.Underline Then
                        Call modSVG.AppendItemStyle(SVG, oXMLText, "text-decoration", "underline")
                    End If

                    Select Case iHorizontalAlign
                        Case cIItemLineableText.TextAlignmentEnum.Center
                            Call modSVG.AppendItemStyle(SVG, oXMLText, "text-anchor", "middle")
                        Case cIItemLineableText.TextAlignmentEnum.Right
                            Call modSVG.AppendItemStyle(SVG, oXMLText, "text-anchor", "end")
                    End Select

                    'Call oXMLText.SetAttribute("transform", "rotate(" & modNumbers.NumberToString(sRotationAngle, "0.00") & ", " & modNumbers.NumberToString(sX, "") & ", " & modNumbers.NumberToString(sY, "") & ")")

                    Call modSVG.AppendItem(SVG, Parent, oXMLText)

                    Return oXMLText

                    'Dim sTransform As String = ""
                    'If PaintOptions.DrawTranslation Then
                    '    Dim oTranslation As SizeF = MyBase.Design.GetItemTranslation(Me)
                    '    If Not oTranslation.IsEmpty Then
                    '        sTransform &= " translate(" & modSVG.PointToSVGString(oTranslation.ToPointF) & ")"
                    '    End If
                    'End If
                    'If iTextRotateMode = cIItemRotable.RotateModeEnum.Rotable Then
                    '    Dim oMovedCenterPoint As PointF = MyBase.Points(0).Point
                    '    sTransform &= " rotate(" & modNumbers.NumberToString(sAngle, "") & " " & modSVG.PointToSVGString(oMovedCenterPoint) & ")"
                    'End If
                    'If sTransform <> "" Then
                    '    Call oXMLText.SetAttribute("transform", sTransform.Trim)
                    'End If

                    'Call modSVG.AddSourceReference(Me, oXMLText, Options)

                    'Call oXMLGroup.AppendChild(oXMLText)

                    'Return oXMLGroup
                End Using
            End If
        End Function
    End Class

    Public Class cDrawCacheItem
        Implements IDisposable

        Public Enum cDrawCacheItemType
            Filler = 0
            SetClip = 1
            ResetClip = 2
            Border = 9
            Text = 10
        End Enum

        Private iType As cDrawCacheItemType
        Private oPath As GraphicsPath

        Private bIsFilled As Boolean
        Private bIsOutlined As Boolean
        Private bIsWireframeOutlined As Boolean

        Private oPen As Pen
        Private oWireframePen As Pen
        Private oBrush As Brush

        Public Overrides Function ToString() As String
            Return MyBase.ToString() & " {" & iType.ToString & "}"
        End Function

        Friend ReadOnly Property Type As cDrawCacheItemType
            Get
                Return iType
            End Get
        End Property

        Friend ReadOnly Property Brush As Brush
            Get
                Return oBrush
            End Get
        End Property

        Friend ReadOnly Property Pen As Pen
            Get
                Return oPen
            End Get
        End Property

        Friend ReadOnly Property WireframePen As Pen
            Get
                Return oWireframePen
            End Get
        End Property

        Friend ReadOnly Property Path As GraphicsPath
            Get
                Return oPath
            End Get
        End Property

        Friend Sub New(Type As cDrawCacheItemType)
            iType = Type

            oPath = New GraphicsPath
            bIsFilled = False
            bIsOutlined = False
            bIsWireframeOutlined = False
        End Sub

        Friend Sub New(Type As cDrawCacheItemType, ByVal Path As GraphicsPath, ByVal Pen As Pen, ByVal WireframePen As Pen, ByVal Brush As Brush)
            iType = Type

            If Path Is Nothing Then
                oPath = New GraphicsPath
            Else
                oPath = Path.Clone
            End If
            If Pen Is Nothing Then
                bIsOutlined = False
            Else
                oPen = Pen.Clone
                bIsOutlined = True
            End If
            If WireframePen Is Nothing Then
                bIsWireframeOutlined = False
            Else
                oWireframePen = WireframePen.Clone
                bIsWireframeOutlined = True
            End If
            If Brush Is Nothing Then
                bIsFilled = False
            Else
                oBrush = Brush.Clone
                bIsFilled = True
            End If
        End Sub

        Public Sub Transform(ByVal Matrix As Matrix)
            If Not Matrix Is Nothing Then
                Call oPath.Transform(Matrix)
            End If
        End Sub

        Public Function GetBounds() As RectangleF
            Return oPath.GetBounds
        End Function

        Public Sub StartFigure()
            Call oPath.StartFigure()
        End Sub

        Public Overridable Sub AddString(ByVal Text As String, ByVal Font As Font, ByVal Point As PointF, Optional ByVal Format As StringFormat = Nothing)
            Call oPath.AddString(Text, Font.FontFamily, Font.Style, Font.Size, Point, Format)
        End Sub

        Public Overridable Sub AddString(ByVal Text As String, ByVal Font As Font, ByVal Rectangle As RectangleF, Optional ByVal Format As StringFormat = Nothing)
            Call oPath.AddString(Text, Font.FontFamily, Font.Style, Font.Size, Rectangle, Format)
        End Sub

        Public Sub AddPolygon(ByVal Points() As PointF)
            Call oPath.AddPolygon(Points)
        End Sub

        Public Sub AddPath(ByVal Path As GraphicsPath)
            Call oPath.AddPath(Path, False)
        End Sub

        Public Sub AddLine(ByVal X1 As Single, ByVal Y1 As Single, ByVal X2 As Single, ByVal Y2 As Single)
            Call oPath.AddLine(X1, Y1, X2, Y2)
        End Sub

        Public Sub AddLine(ByVal Point1 As PointF, ByVal Point2 As PointF)
            Call oPath.AddLine(Point1, Point2)
        End Sub

        Public Sub AddCurve(ByVal Points() As PointF, ByVal Tension As Single)
            Call oPath.AddCurve(Points, Tension)
        End Sub

        Public Sub AddLines(ByVal Points() As PointF)
            Call oPath.AddLines(Points)
        End Sub

        Public Sub AddBezier(ByVal Point1 As PointF, ByVal Point2 As PointF, ByVal Point3 As PointF, ByVal Point4 As PointF)
            Call oPath.AddBezier(Point1, Point2, Point3, Point4)
        End Sub

        Public Sub AddRectangle(ByVal X As Single, ByVal Y As Single, ByVal Width As Single, ByVal Height As Single)
            Call oPath.AddRectangle(New RectangleF(X, Y, Width, Height))
        End Sub

        Public Sub AddRectangle(ByVal Rectangle As RectangleF)
            Call oPath.AddRectangle(Rectangle)
        End Sub

        Public Sub AddEllipse(ByVal X As Single, ByVal Y As Single, ByVal Width As Single, ByVal Height As Single)
            Call oPath.AddEllipse(New RectangleF(X, Y, Width, Height))
        End Sub

        Public Sub AddEllipse(ByVal Rectangle As RectangleF)
            Call oPath.AddEllipse(Rectangle)
        End Sub

        Friend Sub SetBrush(ByVal Brush As Brush)
            If Brush Is Nothing Then
                oBrush = Nothing
                bIsFilled = False
            Else
                oBrush = Brush.Clone
                bIsFilled = True
            End If
        End Sub

        Friend Sub SetPen(ByVal Pen As Pen)
            If Pen Is Nothing Then
                oPen = Nothing
                bIsOutlined = False
            Else
                oPen = Pen.Clone
                bIsOutlined = True
            End If
        End Sub

        Friend Sub SetWireframePen(ByVal WireframePen As Pen)
            If WireframePen Is Nothing Then
                oWireframePen = Nothing
                bIsWireframeOutlined = False
            Else
                oWireframePen = WireframePen.Clone
                bIsWireframeOutlined = True
            End If
        End Sub

        Friend ReadOnly Property IsFilled As Boolean
            Get
                Return bIsFilled
            End Get
        End Property

        Friend ReadOnly Property IsOutlined As Boolean
            Get
                Return bIsOutlined
            End Get
        End Property

        Friend ReadOnly Property IsWireframeOutlined As Boolean
            Get
                Return bIsWireframeOutlined
            End Get
        End Property

        Friend Overridable Function AppendSvgItem(ByVal SVG As XmlDocument, ByVal Parent As XmlElement, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.SVGOptionsEnum, Optional ByVal Matrix As Matrix = Nothing) As XmlElement
            If bIsFilled OrElse bIsOutlined Then
                Using oSvgPath As GraphicsPath = oPath.Clone
                    If Not Matrix Is Nothing Then
                        Call oSvgPath.Transform(Matrix)
                    End If
                    Dim oItem As XmlElement = modSVG.CreateItem(SVG, PaintOptions, oSvgPath)
                    Call modSVG.AppendItemStyle(SVG, oItem, If(bIsFilled, oBrush, Nothing), If(bIsOutlined, oPen, Nothing))
                    Call modSVG.AppendItem(SVG, Parent, oItem)
                    Return oItem
                End Using
            End If
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    If Not oPath Is Nothing Then oPath.Dispose()
                    If Not oPen Is Nothing Then oPen.Dispose()
                    If Not oWireframePen Is Nothing Then oWireframePen.Dispose()
                    If Not oBrush Is Nothing Then oBrush.Dispose()
                End If
                oPath = Nothing
                oPen = Nothing
                oWireframePen = Nothing
                oBrush = Nothing
            End If
            Me.disposedValue = True
        End Sub

        ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(disposing As Boolean).
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class
End Namespace