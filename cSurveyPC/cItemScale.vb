Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings
Imports System.ComponentModel

Namespace cSurvey.Design.Items
    Public Class cItemScale
        Inherits cItem
        Implements cIItemText
        Implements cIItemVerticalLineableText
        Implements cIItemLineableText
        Implements cIItemScale

        Private oSurvey As cSurvey

        Private sText As String
        Private WithEvents oFont As cItemFont

        Private iLength As Integer
        Private iSteps As Integer
        Private iStepLength As Integer

        Private bHideScaleValue As Boolean

        Private iTextSize As cIItemText.TextSizeEnum
        Private iTextVerticalAlignment As cIItemVerticalLineableText.TextVerticalAlignmentEnum
        Private iTextAlignment As cIItemLineableText.TextAlignmentEnum

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
                Return False
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
                Return False ' iTextRotateMode = TextRotateModeEnum.Rotable
            End Get
        End Property

        Public Overrides ReadOnly Property HaveEditablePoints As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveBrush As Boolean
            Get
                Return False
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

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum, ByVal Text As String)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.Scale, Category)
            oSurvey = Survey
            oFont = New cItemFont(oSurvey, cItemFont.FontTypeEnum.Generic)
            sText = "" & Text
            iTextSize = cIItemText.TextSizeEnum.Default
            iTextAlignment = cIItemLineableText.TextAlignmentEnum.Left
            iTextVerticalAlignment = cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle

            iLength = 10
            iSteps = 5
            iStepLength = 1
            sText = ""
            bHideScaleValue = False

            MyBase.DesignAffinity = DesignAffinityEnum.Extra
        End Sub

        Friend Overrides Function GetTextScaleFactor(PaintOptions As cOptions) As Single
            Dim sTextScaleFactor As Single = MyBase.GetTextScaleFactor(PaintOptions)
            Select Case iTextSize
                Case cIItemText.TextSizeEnum.Default
                    Return 1 * sTextScaleFactor
                Case cIItemText.TextSizeEnum.VerySmall
                    Return 0.25 * sTextScaleFactor
                Case cIItemText.TextSizeEnum.Small
                    Return 0.5 * sTextScaleFactor
                Case cIItemText.TextSizeEnum.Medium
                    Return 1 * sTextScaleFactor
                Case cIItemText.TextSizeEnum.Large
                    Return 2 * sTextScaleFactor
                Case cIItemText.TextSizeEnum.VeryLarge
                    Return 4 * sTextScaleFactor
            End Select
        End Function

        Friend Overrides Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
            Dim oMatrix As Matrix = New Matrix
            If PaintOptions.DrawTranslation Then
                Dim oTranslation As SizeF = MyBase.Design.GetItemTranslation(Me)
                Call oMatrix.Translate(oTranslation.Width, oTranslation.Height)
            End If
            Dim oSVGItem As XmlElement = MyBase.Caches(PaintOptions).ToSvgItem(SVG, PaintOptions, Options, oMatrix)
            Call oSVGItem.SetAttribute("name", MyBase.Name)
            Call oMatrix.Dispose()
            Return oSVGItem
        End Function

        Public Overrides Sub ResizeTo(ByVal Size As SizeF)
            Call ResizeTo(Size.Width, Size.Height)
        End Sub

        Public Overrides Sub ResizeBy(ByVal Size As SizeF)
            Call ResizeBy(Size.Width, Size.Height)
        End Sub

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

                    Dim sScale As Single = GetTextScaleFactor(PaintOptions)

                    Dim oBasePoint As PointF = MyBase.Points(0).Point

                    Dim sScaleText As String = modPaint.ReplaceGlobalTags(oSurvey, sText)
                    If Not bHideScaleValue Then
                        If sScaleText = "" Then sScaleText = modMain.GetLocalizedString("itemscale.defaultscaletext")
                        If sScaleText <> "" Then sScaleText = sScaleText & " "
                        If PaintOptions.IsPreview OrElse PaintOptions.IsViewer Then
                            sScaleText = sScaleText & "1:" & PaintOptions.CurrentScale
                        Else
                            sScaleText = sScaleText & "1:*"
                        End If
                    End If

                    Dim oTextFont As Font = oFont.GetFont(PaintOptions)
                    Dim oScaleValueSize As SizeF = Graphics.MeasureString(sScaleText, oTextFont)
                    Dim oScaledScaleValueSize As SizeF = New SizeF(oScaleValueSize.Width * sScale, oScaleValueSize.Height * sScale)
                    Using oScaleMeterFont As cItemFont = oFont.Clone
                        oScaleMeterFont.FontSize = oTextFont.Size * 0.6!
                        Using oSF As StringFormat = New StringFormat
                            oSF.Alignment =StringAlignment.Center 
                            'Dim oScalePen As Pen = New Pen(PaintOptions.ScaleOptions.Color, -1)
                            'Dim oScaleBrush1 As Brush = New SolidBrush(PaintOptions.ScaleOptions.Color)
                            'Dim oScalebrush2 As Brush = New SolidBrush(Color.White)
                            Dim oBorderPen As cPen = PaintOptions.PaintObjects.GenericPens.GenericPen
                            Dim oBorderBrush As cBrush = PaintOptions.PaintObjects.GenericBrushes.SignSolid

                            Dim iDetailedSteps As Integer = iLength / (iLength / iSteps)
                            Dim sScaleStepLeftX As Single = 0
                            Dim sScaleLeftX As Single = 0
                            Dim sScaleLeftY As Single = oScaledScaleValueSize.Height * 1.05!
                            Dim sScaleWidth As Single = iLength '* Zoom
                            Dim sScaleStepWidth As Single = sScaleWidth / iSteps
                            Dim bFilled As Boolean = False
                            Dim iMeter As Integer = 0
                            Dim sMeter As String = ""
                            Dim sScaleHeight As Single = oScaledScaleValueSize.Height
                            Dim sHalfScaleHeight As Single = sScaleHeight / 2
                            For iScaleStepIndex As Integer = 0 To (iLength / iSteps) - 1
                                If iScaleStepIndex = 0 Then
                                    Dim iScaleSubStepWidth As Single = sScaleWidth * iStepLength / iLength
                                    For iSubScaleStepIndex = 0 To iDetailedSteps - iStepLength Step iStepLength
                                        bFilled = Not bFilled
                                        If bFilled Then
                                            Using oPath As GraphicsPath = New GraphicsPath
                                                Call oPath.AddRectangle(New RectangleF(sScaleStepLeftX, sScaleLeftY, iScaleSubStepWidth, sHalfScaleHeight))
                                                Call oBorderBrush.Render(Graphics, PaintOptions, Options, False, oPath, oCache)
                                                Call oBorderPen.Render(Graphics, PaintOptions, Options, False, oPath, oCache)
                                            End Using
                                        Else
                                            Using oPath As GraphicsPath = New GraphicsPath
                                                Call oPath.AddRectangle(New RectangleF(sScaleStepLeftX, sScaleLeftY, iScaleSubStepWidth, sHalfScaleHeight))
                                                Call oBorderPen.Render(Graphics, PaintOptions, Options, False, oPath, oCache)
                                            End Using
                                        End If
                                        Using oPath As GraphicsPath = New GraphicsPath
                                            Call oPath.AddLine(sScaleStepLeftX, sScaleLeftY + sHalfScaleHeight, sScaleStepLeftX, sScaleLeftY + sScaleHeight)
                                            Call oBorderPen.Render(Graphics, PaintOptions, Options, False, oPath, oCache)
                                        End Using
                                        Using oPath As GraphicsPath = New GraphicsPath
                                            sMeter = iMeter & "m"
                                            Using oTextPath As GraphicsPath = oScaleMeterFont.GetPath(PaintOptions, sMeter, oSF)
                                                Using oTextMatrix = New Matrix
                                                    Call oTextMatrix.Scale(sScale, sScale, MatrixOrder.Append)
                                                    Call oTextMatrix.Translate(sScaleStepLeftX, sScaleLeftY + sScaleHeight, MatrixOrder.Append)
                                                    Call oTextPath.Transform(oTextMatrix)
                                                End Using
                                                Call oPath.AddPath(oTextPath, False)
                                            End Using
                                            Call oBorderBrush.Render(Graphics, PaintOptions, Options, False, oPath, oCache)
                                        End Using
                                        iMeter = iMeter + iStepLength
                                        sScaleStepLeftX += iScaleSubStepWidth
                                    Next
                                Else
                                    bFilled = Not bFilled
                                    If bFilled Then
                                        Using oPath As GraphicsPath = New GraphicsPath
                                            Call oPath.AddRectangle(New RectangleF(sScaleStepLeftX, sScaleLeftY, iDetailedSteps, sHalfScaleHeight))
                                            Call oBorderBrush.Render(Graphics, PaintOptions, Options, False, oPath, oCache)
                                            Call oBorderPen.Render(Graphics, PaintOptions, Options, False, oPath, oCache)
                                        End Using
                                    Else
                                        Using oPath As GraphicsPath = New GraphicsPath
                                            Call oPath.AddRectangle(New RectangleF(sScaleStepLeftX, sScaleLeftY, iDetailedSteps, sHalfScaleHeight))
                                            Call oBorderPen.Render(Graphics, PaintOptions, Options, False, oPath, oCache)
                                        End Using
                                    End If
                                    Using oPath As GraphicsPath = New GraphicsPath
                                        Call oPath.AddLine(sScaleStepLeftX, sScaleLeftY + sHalfScaleHeight, sScaleStepLeftX, sScaleLeftY + sScaleHeight)
                                        Call oBorderPen.Render(Graphics, PaintOptions, Options, False, oPath, oCache)
                                    End Using
                                    Using oPath As GraphicsPath = New GraphicsPath
                                        'dimensiono il testo se rischiesto (il fattore di scala sarà da parametrizzare in qualche modo)
                                        sMeter = iMeter & "m"
                                        Using oTextPath As GraphicsPath = oScaleMeterFont.GetPath(PaintOptions, sMeter, oSF)
                                            Using oTextMatrix = New Matrix
                                                Call oTextMatrix.Scale(sScale, sScale, MatrixOrder.Append)
                                                Call oTextMatrix.Translate(sScaleStepLeftX, sScaleLeftY + sScaleHeight, MatrixOrder.Append)
                                                Call oTextPath.Transform(oTextMatrix)
                                            End Using
                                            Call oPath.AddPath(oTextPath, False)
                                        End Using
                                        Call oBorderBrush.Render(Graphics, PaintOptions, Options, False, oPath, oCache)
                                    End Using
                                    iMeter = iMeter + iDetailedSteps
                                    sScaleStepLeftX += iDetailedSteps
                                End If
                            Next
                            Using oPath As GraphicsPath = New GraphicsPath
                                'dimensiono il testo se rischiesto (il fattore di scala sarà da parametrizzare in qualche modo)
                                sMeter = iMeter & "m"
                                Using oTextPath As GraphicsPath = oScaleMeterFont.GetPath(PaintOptions, sMeter, oSF)
                                    Using oTextMatrix = New Matrix
                                        Call oTextMatrix.Scale(sScale, sScale, MatrixOrder.Append)
                                        Call oTextMatrix.Translate(sScaleStepLeftX, sScaleLeftY + sScaleHeight, MatrixOrder.Append)
                                        Call oTextPath.Transform(oTextMatrix)
                                    End Using
                                    Call oPath.AddPath(oTextPath, False)
                                End Using
                                Call oBorderBrush.Render(Graphics, PaintOptions, Options, False, oPath, oCache)
                            End Using

                            Dim sScaleRightX As Single = sScaleStepLeftX
                            Using oPath As GraphicsPath = New GraphicsPath
                                Call oPath.AddLine(sScaleStepLeftX, sScaleLeftY + sHalfScaleHeight, sScaleStepLeftX, sScaleLeftY + sScaleHeight)
                                Call oBorderPen.Render(Graphics, PaintOptions, Options, False, oPath, oCache)
                            End Using
                            Using oPath As GraphicsPath = New GraphicsPath
                                Using oTextPath As GraphicsPath = oFont.GetPath(PaintOptions, sScaleText, oSF)
                                    Using oTextMatrix = New Matrix
                                        Call oTextMatrix.Scale(sScale, sScale, MatrixOrder.Append)
                                        Call oTextMatrix.Translate(sScaleLeftX + sScaleWidth / 2, 0, MatrixOrder.Append)
                                        Call oTextPath.Transform(oTextMatrix)
                                    End Using
                                    Call oPath.AddPath(oTextPath, False)
                                End Using
                                Call oBorderBrush.Render(Graphics, PaintOptions, Options, False, oPath, oCache)
                            End Using
                        End Using
                    End Using

                    '..................................................................................................................................................................................................................
                    Dim sY As Single
                    Dim sX As Single
                    Select Case iTextAlignment
                        Case cIItemLineableText.TextAlignmentEnum.Center
                            sX = oBasePoint.X - oCache.GetBounds.Width / 2
                        Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
                            sX = oBasePoint.X - oCache.GetBounds.Right
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
            iTextAlignment = modXML.GetAttributeValue(item, "textalignment", cIItemLineableText.TextAlignmentEnum.Center)
            iTextVerticalAlignment = modXML.GetAttributeValue(item, "textverticalalignment", cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle)

            iLength = modXML.GetAttributeValue(item, "l", 10)
            iSteps = modXML.GetAttributeValue(item, "s", 5)
            iStepLength = modXML.GetAttributeValue(item, "sl", 1)

            bHideScaleValue = modXML.GetAttributeValue(item, "hsv", 0)
        End Sub

        Friend Overrides Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oItem As XmlElement = MyBase.SaveTo(File, Document, Parent, Options)
            If "" & sText <> "" Then Call oItem.SetAttribute("text", "" & sText)
            Call oFont.SaveTo(File, Document, oItem, "font")
            If iTextSize <> cIItemText.TextSizeEnum.Default Then
                Call oItem.SetAttribute("textsize", iTextSize)
            End If
            If iTextAlignment <> cIItemLineableText.TextAlignmentEnum.Center Then
                Call oItem.SetAttribute("textalignment", iTextAlignment)
            End If
            If iTextVerticalAlignment <> cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle Then
                Call oItem.SetAttribute("textverticalalignment", iTextVerticalAlignment)
            End If

            Call oItem.SetAttribute("l", iLength)
            Call oItem.SetAttribute("s", iSteps)
            Call oItem.SetAttribute("sl", iStepLength)

            If bHideScaleValue Then Call oItem.SetAttribute("hsv", "1")

            Return oItem
        End Function

        Public Property TextSize() As cIItemText.TextSizeEnum Implements cIItemText.TextSize
            Get
                Return iTextSize
            End Get
            Set(ByVal value As cIItemText.TextSizeEnum)
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

        Friend Overrides Sub BindSegments()
            If MyBase.Cave = "" Then
                For Each oPoint As cPoint In MyBase.Points
                    oPoint.SegmentLocked = False
                    Call oPoint.BindSegment(Nothing)
                Next
            Else
                Dim oCenterPoint As PointF = GetCenterPoint()
                Dim oSegment As cISegment = MyBase.Design.GetNearestSegment(MyBase.Cave, MyBase.Branch, MyBase.CrossSection, oCenterPoint.X, oCenterPoint.Y, MyBase.BindDesignType)
                For Each oPoint As cPoint In MyBase.Points
                    If Not oPoint.SegmentLocked Then
                        Call oPoint.BindSegment(oSegment)
                    End If
                Next
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

        Public ReadOnly Property AvaiableTextProperties As cIItemText.AvaiableTextPropertiesEnum Implements cIItemText.AvaiableTextProperties
            Get
                Return cIItemText.AvaiableTextPropertiesEnum.VerticalLineable Or cIItemText.AvaiableTextPropertiesEnum.Lineable
            End Get
        End Property

        Public Property Steps As Integer Implements cIItemScale.Steps
            Get
                Return iSteps
            End Get
            Set(value As Integer)
                If iSteps <> value AndAlso iSteps > 0 Then
                    iSteps = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property StepLength As Integer Implements cIItemScale.StepLength
            Get
                Return iStepLength
            End Get
            Set(value As Integer)
                If iStepLength <> value AndAlso iStepLength > 0 Then
                    iStepLength = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property Length As Integer Implements cIItemScale.Length
            Get
                Return iLength
            End Get
            Set(value As Integer)
                If iLength <> value AndAlso iLength > 0 Then
                    iLength = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property HideScaleValue As Boolean Implements cIItemScale.HideScaleValue
            Get
                Return bHideScaleValue
            End Get
            Set(value As Boolean)
                If bHideScaleValue <> value Then
                    bHideScaleValue = value
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



