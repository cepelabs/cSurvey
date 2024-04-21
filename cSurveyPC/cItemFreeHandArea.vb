Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings

Namespace cSurvey.Design.Items
    Public Class cItemFreeHandArea
        Inherits cItem
        Implements cIItemLine

        Private iLineType As cIItemLine.LineTypeEnum

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

        Public Overrides ReadOnly Property CanBeReduced As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeDeleted As Boolean
            Get
                Return True
            End Get
        End Property

        Public Sub ReducePoints(Optional ByVal Factor As Single = 0.1) Implements cIItemLine.ReducePoints
            If MyBase.Points.Count > 2 Then
                Call modPaint.ReducePoints(MyBase.Points, Factor, iLineType)
            End If
        End Sub

        Public Overrides ReadOnly Property HaveTransparency As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeMoved As Boolean
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
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeWarped As Boolean
            Get
                Return True
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

        Public Overrides ReadOnly Property HaveSketch As Boolean
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

        Public Overrides ReadOnly Property HaveLineType As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HaveFont As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property BindMode As cItem.BindModeEnum
            Get
                Return BindModeEnum.AllPoints
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeRotated() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HaveText As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveEditablePoints As Boolean
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

        'Friend Overrides Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
        '    Using oMatrix As Matrix = New Matrix
        '        If PaintOptions.DrawTranslation Then
        '            Dim oTranslation As SizeF = MyBase.Design.GetItemTranslation(Me)
        '            Call oMatrix.Translate(oTranslation.Width, oTranslation.Height)
        '        End If
        '        Dim oSVGItem As XmlElement = MyBase.Caches(PaintOptions).ToSvgItem(SVG, PaintOptions, Options, oMatrix)
        '        If MyBase.Name <> "" Then Call oSVGItem.SetAttribute("name", MyBase.Name)
        '        Return oSVGItem
        '    End Using
        'End Function

        'Friend Overrides Function ToSvg(ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlDocument
        '    Dim oSVG As XmlDocument = modSVG.CreateSVG
        '    Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions, Options))
        '    Return oSVG
        'End Function

        Friend Overrides Sub Render(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            Dim oCache As cDrawCache = MyBase.Caches(PaintOptions)
            With oCache
                If .Invalidated Then
                    Call .Clear()
                    If MyBase.Points.Count > 1 Then
                        Dim oLastPoint As PointF
                        Dim oSequences As List(Of cSequence) = MyBase.Points.GetSequences
                        Using oBorderPath As GraphicsPath = New GraphicsPath
                            For Each oSequence As cSequence In oSequences
                                Dim oSequencePoints() As PointF = oSequence.GetPoints
                                If oSequencePoints.Length > 0 Then
                                    If Not oLastPoint.IsEmpty Then
                                        Call oBorderPath.AddLine(oLastPoint, oSequencePoints(0))
                                    End If
                                    If oSequencePoints.Length > 1 Then
                                        Select Case oSequence.GetLineType(iLineType)
                                            Case cIItemLine.LineTypeEnum.Beziers
                                                Call modPaint.PointsToBeziers(oSequencePoints, oBorderPath)
                                            Case cIItemLine.LineTypeEnum.Splines
                                                Call oBorderPath.AddCurve(oSequencePoints, sDefaultSplineTension)
                                            Case Else
                                                Call oBorderPath.AddLines(oSequencePoints)
                                        End Select
                                    End If
                                    oLastPoint = oSequencePoints(oSequencePoints.Length - 1)
                                End If
                            Next
                            Call MyBase.Brush.Render(Graphics, PaintOptions, Options, Selected, oBorderPath, oCache)
                        End Using
                        For Each oSequence As cSequence In oSequences
                            Dim oSequencePoints() As PointF = oSequence.GetPoints
                            If oSequencePoints.Length > 1 Then
                                Using oPath As GraphicsPath = New GraphicsPath
                                    Select Case oSequence.GetLineType(iLineType)
                                        Case cIItemLine.LineTypeEnum.Beziers
                                            Call modPaint.PointsToBeziers(oSequencePoints, oPath)
                                        Case cIItemLine.LineTypeEnum.Splines
                                            Call oPath.AddCurve(oSequencePoints, sDefaultSplineTension)
                                        Case Else
                                            Call oPath.AddLines(oSequencePoints)
                                    End Select
                                    Call oSequence.GetPen(MyBase.Pen).Render(Graphics, PaintOptions, Options, Selected, oPath, oCache)
                                End Using
                            End If
                        Next
                    End If
                    Call .Rendered()
                End If
            End With
        End Sub

        Friend Overrides Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            If MyBase.Points.Count > 1 Then
                Call Render(Graphics, PaintOptions, Options, Selected)
                If Not PaintOptions.IsDesign OrElse (PaintOptions.IsDesign And Not MyBase.HiddenInDesign) Then
                    MyBase.HavePaintProblem = Not MyBase.Caches(PaintOptions).Paint(Graphics, PaintOptions, Options)
                    If PaintOptions.ShowSegmentBindings Then
                        Call modPaint.PaintPointToSegmentBindings(Graphics, MyBase.Survey, Me, Selected)
                    End If
                End If
            End If
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.FreeHandArea, Category)
            iLineType = GetDefaultLineType(Survey, Category)
            AddHandler MyBase.Points.OnGetLineType, AddressOf oPoints_OnGetLineType
        End Sub

        Private Sub oPoints_OnGetLineType(sender As cPoints, ByRef LineType As Items.cIItemLine.LineTypeEnum)
            LineType = iLineType
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As cFile, ByVal item As XmlElement)
            Call MyBase.New(Survey, Design, Layer, File, item)
            iLineType = modXML.GetAttributeValue(item, "linetype", cIItemLine.LineTypeEnum.Undefined)
            AddHandler MyBase.Points.OnGetLineType, AddressOf oPoints_OnGetLineType
        End Sub

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oItem As XmlElement = MyBase.SaveTo(File, Document, Parent, Options)
            Call oItem.SetAttribute("linetype", iLineType.ToString("D"))
            Return oItem
        End Function

        Public Property LineType() As cIItemLine.LineTypeEnum Implements cIItemLine.LineType
            Get
                Return iLineType
            End Get
            Set(ByVal value As cIItemLine.LineTypeEnum)
                If iLineType <> value Then
                    iLineType = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Overrides ReadOnly Property CanBeResized() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeDivided() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeCombined() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeBinded() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property MaxPointsCount As Integer
            Get
                Return Integer.MaxValue
            End Get
        End Property

        Public Overrides ReadOnly Property CanImportGeneric As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides Function FromGeneric(ByVal Item As cItemGeneric, Optional ByVal Clear As Boolean = False) As Boolean
            Call MyBase.Points.BeginUpdate()
            If Clear Then
                Call MyBase.Points.Clear()
            End If
            iLineType = Item.LineType
            For Each oPoint As cPoint In Item.Points
                Call MyBase.Points.Add(oPoint.Clone)
            Next
            Call MyBase.Points.EndUpdate()
            Return True
        End Function

    End Class
End Namespace