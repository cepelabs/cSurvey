Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings

Namespace cSurvey.Design.Items
    Public Class cItemSign
        Inherits cItem
        Implements cIItemSign
        Implements cIItemRotable
        Implements cIItemSizable

        Private oSurvey As cSurvey

        Private oClipart As cClipart

        Private oDataBounds As RectangleF

        Private iSign As cIItemSign.SignEnum
        Private iSignSize As cIItemSizable.SizeEnum
        Private iSignRotateMode As cIItemRotable.RotateModeEnum
        Private iSignFlip As cIItemSign.SignFlipEnum

        Private sAngle As Single

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

        Friend Sub GetScaleAndRotateFactors(PaintOptions As cOptions, ByRef Scale As Single, ByRef Angle As Single)
            Scale = GetSignScaleFactor(PaintOptions)
            Angle = modPaint.NormalizeAngle(sAngle)
        End Sub

        Public Property SignRotationAngleDelta As Single Implements cIItemSign.SignRotationAngleDelta
            Get
                Return oClipart.Clipart.UserData.GetTypedValue(Data.cDataFields.TypeEnum.Single, "rotationangledelta", 0)
            End Get
            Set(value As Single)
                Call oClipart.Clipart.UserData.SetTypedValue(Data.cDataFields.TypeEnum.Single, "rotationangledelta", value)
            End Set
        End Property

        Public Overrides ReadOnly Property CanBeReduced As Boolean
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property Clipart As cClipart Implements cIItemSign.Clipart
            Get
                Return oClipart
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
                Return True
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

        Public Overrides ReadOnly Property CanBeRotated As Boolean
            Get
                Return iSignRotateMode = cIItemRotable.RotateModeEnum.Rotable
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
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.Sign, Category)
            oSurvey = Survey
            Select Case DataFormat
                Case cIItemClipartBase.cClipartDataFormatEnum.SVGFile
                    oClipart = oSurvey.Signs.Cliparts.Add(Data)
                Case cIItemClipartBase.cClipartDataFormatEnum.SVGData
                    oClipart = oSurvey.Signs.Cliparts.Add("", Data)
                Case Else
                    oClipart = oSurvey.Signs.Cliparts(Data)
            End Select
            If oClipart.Clipart.UserData.Contains("sign") Then
                Dim sSign As String = oClipart.Clipart.UserData.GetValue("sign", "")
                If sSign = "" Then
                    iSign = cIItemSign.SignEnum.Undefined
                Else
                    If Not Integer.TryParse(sSign, iSign) Then
                        iSign = DirectCast([Enum].Parse(GetType(cIItemSign.SignEnum), sSign), cIItemSign.SignEnum)
                    End If
                End If
            Else
                iSign = cIItemSign.SignEnum.Undefined
            End If
            iSignRotateMode = Survey.Properties.DesignProperties.GetValue("DesignSignRotateMode", cIItemRotable.RotateModeEnum.Rotable)
            Call pLoadData()
            Call FixBound()
        End Sub
        Public Overrides Sub Rotate(ByVal Angle As Single)
            sAngle += Angle
            Call MyBase.Caches.Invalidate()
        End Sub

        Public Overrides Sub RotateAt(ByVal Center As PointF, ByVal Angle As Single)
            sAngle += Angle
            Call MyBase.RotateAt(Center, Angle)
            Call MyBase.Caches.Invalidate()
        End Sub

        Friend Overrides Sub Render(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            Dim oCache As cDrawCache = MyBase.Caches(PaintOptions)
            With oCache
                If .Invalidated Then
                    Call .Clear()
                    Using oPaths As cDrawPaths = oClipart.Clipart.ClonePaths
                        'flip clipart
                        Select Case iSignFlip
                            Case cIItemSign.SignFlipEnum.None
                            Case cIItemSign.SignFlipEnum.Vertical
                                Using oFlipMatrix As Matrix = New Matrix
                                    Call oFlipMatrix.Scale(1, -1)
                                    Call oPaths.Transform(oFlipMatrix)
                                End Using
                            Case cIItemSign.SignFlipEnum.Horizontal
                                Using oFlipMatrix As Matrix = New Matrix
                                    Call oFlipMatrix.Scale(-1, 1)
                                    Call oPaths.Transform(oFlipMatrix)
                                End Using
                            Case cIItemSign.SignFlipEnum.Both
                                Using oFlipMatrix As Matrix = New Matrix
                                    Call oFlipMatrix.Scale(-1, -1)
                                    Call oPaths.Transform(oFlipMatrix)
                                End Using
                        End Select

                        'size clipart
                        Dim sScale As Single = GetSignScaleFactor(PaintOptions)
                        If sScale <> 1.0 Then
                            Using oScaleMatrix As Matrix = New Matrix
                                Call oScaleMatrix.Scale(sScale, sScale)
                                Call oPaths.Transform(oScaleMatrix)
                            End Using
                        End If

                        'move it to point
                        Dim oPathRect As RectangleF = oPaths.GetBounds
                        Dim oTranslatePoint As PointF = New PointF(MyBase.Points(0).Point.X - oPathRect.Width / 2, MyBase.Points(0).Point.Y - oPathRect.Height / 2)
                        If Not oTranslatePoint.IsEmpty Then
                            Using oTranslateMatrix As Matrix = New Matrix
                                Call oTranslateMatrix.Translate(oTranslatePoint.X, oTranslatePoint.Y)
                                Call oPaths.Transform(oTranslateMatrix)
                            End Using
                        End If

                        'and rotate
                        If iSignRotateMode = cIItemRotable.RotateModeEnum.Rotable AndAlso sAngle <> 0.0 Then
                            Dim oPathMovedRect As RectangleF = oPaths.GetBounds
                            Dim oMovedCenterPoint As PointF = New PointF(oPathMovedRect.Left + oPathMovedRect.Width / 2, oPathMovedRect.Top + oPathMovedRect.Height / 2)
                            Using oRotateMatrix As Matrix = New Matrix
                                Call oRotateMatrix.RotateAt(sAngle, oMovedCenterPoint)
                                Call oPaths.Transform(oRotateMatrix)
                            End Using
                        End If

                        Call oPaths.Render(Me, Graphics, PaintOptions, Options, SelectionModeEnum.Selected, oCache)
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
            If MyBase.Points.Count > 1 OrElse ForceBound Then
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
            If sData <> "" Then
                Dim iDataFormat As cIItemClipartBase.cClipartDataFormatEnum = modXML.GetAttributeValue(item, "dataformat", cIItemClipartBase.cClipartDataFormatEnum.SVGResource)
                Select Case iDataFormat
                    Case cIItemClipartBase.cClipartDataFormatEnum.SVGFile
                        oClipart = oSurvey.Signs.Cliparts.Add(sData)
                    Case cIItemClipartBase.cClipartDataFormatEnum.SVGData
                        oClipart = oSurvey.Signs.Cliparts.Add("", sData)
                    Case cIItemClipartBase.cClipartDataFormatEnum.SVGResource
                        oClipart = oSurvey.Signs.Cliparts(sData)
                End Select
            End If
            iSign = modXML.GetAttributeValue(item, "sign", Items.cIItemSign.SignEnum.Undefined)
            If IsNothing(oClipart) Then
                Dim iDataFormat As cIItemClipartBase.cClipartDataFormatEnum
                Call Survey.RaiseOnGetDefaultSignFromGallery(iSign, sData, iDataFormat)
                If sData <> "" Then
                    Select Case iDataFormat
                        Case cIItemClipartBase.cClipartDataFormatEnum.SVGFile
                            oClipart = oSurvey.Signs.Cliparts.Add(sData)
                        Case cIItemClipartBase.cClipartDataFormatEnum.SVGData
                            oClipart = oSurvey.Signs.Cliparts.Add("", sData)
                        Case cIItemClipartBase.cClipartDataFormatEnum.SVGResource
                            oClipart = oSurvey.Signs.Cliparts(sData)
                    End Select
                End If
                If IsNothing(oClipart) Then
                    oClipart = oSurvey.Signs.Cliparts.Add("", My.Resources.clipart_error)
                End If
            End If
            iSignSize = modXML.GetAttributeValue(item, "signsize", Items.cIItemSizable.SizeEnum.Default)
            iSignRotateMode = modXML.GetAttributeValue(item, "signrotatemode", Items.cIItemRotable.RotateModeEnum.Rotable)
            iSignFlip = modXML.GetAttributeValue(item, "signflip", Items.cIItemSign.SignFlipEnum.None)
            Call pLoadData()
            sAngle = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "angle", 0))
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
            If iSign <> cIItemSign.SignEnum.Undefined Then
                Call oItem.SetAttribute("sign", iSign.ToString("D"))
            End If
            If iSignSize <> cIItemSizable.SizeEnum.Default Then Call oItem.SetAttribute("signsize", iSignSize.ToString("D"))
            If iSignRotateMode <> cIItemRotable.RotateModeEnum.Rotable Then Call oItem.SetAttribute("signrotatemode", iSignRotateMode.ToString("D"))
            If iSignFlip <> cIItemSign.SignFlipEnum.None Then Call oItem.SetAttribute("signflip", iSignFlip.ToString("D"))
            If sAngle <> 0 Then Call oItem.SetAttribute("angle", modNumbers.NumberToString(sAngle))
            Return oItem
        End Function

        Private Sub pLoadData()
            oDataBounds = oClipart.Clipart.GetBounds
        End Sub

        Friend Overrides Function GetSignScaleFactor(PaintOptions As cOptionsCenterline) As Single
            Dim sDesignSignScaleFactor As Single = MyBase.GetSignScaleFactor(PaintOptions)
            Select Case iSignSize
                Case cIItemSizable.SizeEnum.Default
                    Return 1 * sDesignSignScaleFactor
                Case cIItemSizable.SizeEnum.VerySmall
                    Return 0.25 * sDesignSignScaleFactor
                Case cIItemSizable.SizeEnum.Small
                    Return 0.5 * sDesignSignScaleFactor
                Case cIItemSizable.SizeEnum.Medium
                    Return 1 * sDesignSignScaleFactor
                Case cIItemSizable.SizeEnum.Large
                    Return 2 * sDesignSignScaleFactor
                Case cIItemSizable.SizeEnum.VeryLarge
                    Return 4 * sDesignSignScaleFactor
                Case cIItemSizable.SizeEnum.x6
                    Return 6 * sDesignSignScaleFactor
                Case cIItemSizable.SizeEnum.x8
                    Return 8 * sDesignSignScaleFactor
                Case cIItemSizable.SizeEnum.x10
                    Return 10 * sDesignSignScaleFactor
                Case cIItemSizable.SizeEnum.x12
                    Return 12 * sDesignSignScaleFactor
                Case cIItemSizable.SizeEnum.x16
                    Return 16 * sDesignSignScaleFactor
                Case cIItemSizable.SizeEnum.x20
                    Return 20 * sDesignSignScaleFactor
                Case cIItemSizable.SizeEnum.x24
                    Return 24 * sDesignSignScaleFactor
                Case cIItemSizable.SizeEnum.x32
                    Return 32 * sDesignSignScaleFactor
            End Select
        End Function

        Public Property SignRotateMode() As cIItemRotable.RotateModeEnum Implements cIItemRotable.RotateMode ', cIItemSign.SignRotateMode
            Get
                Return iSignRotateMode
            End Get
            Set(ByVal value As cIItemRotable.RotateModeEnum)
                If iSignRotateMode <> value Then
                    iSignRotateMode = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property SignFlip() As cIItemSign.SignFlipEnum Implements cIItemSign.SignFlip
            Get
                Return iSignFlip
            End Get
            Set(ByVal value As cIItemSign.SignFlipEnum)
                If iSignFlip <> value Then
                    iSignFlip = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property SignSize() As cIItemSizable.SizeEnum Implements cIItemSizable.Size
            Get
                Return iSignSize
            End Get
            Set(ByVal value As cIItemSizable.SizeEnum)
                If iSignSize <> value Then
                    iSignSize = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
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
        '        If MyBase.Name <> "" Then Call oSVGItem.SetAttribute("name", MyBase.Name)
        '        Call modSVG.AppendItemStyle(SVG, oSVGItem, MyBase.Brush, MyBase.Pen)
        '        Return oSVGItem
        '    End Using
        'End Function

        Public Overrides ReadOnly Property CanImportGeneric As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Function FromGeneric(ByVal Item As cItemGeneric, Optional ByVal Clear As Boolean = False) As Boolean
            Return False
        End Function

        Public Property Sign As cIItemSign.SignEnum Implements cIItemSign.Sign
            Get
                Return iSign
            End Get
            Set(value As cIItemSign.SignEnum)
                iSign = value
            End Set
        End Property

        'Public Property SignCategory As cIItemSign.SignCategoryEnum Implements cIItemSign.SignCategory
        '    Get
        '        Return iSigncategory
        '    End Get
        '    Set(value As cIItemSign.SignCategoryEnum)
        '        isigncategory = value
        '    End Set
        'End Property

    End Class
End Namespace
