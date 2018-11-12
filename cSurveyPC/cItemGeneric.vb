Imports cSurveyPC.cSurvey.Drawings

Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design.Items
    Public Class cItemGeneric
        Inherits cItem
        Implements cIItemLine

        Public Enum cItemGenericDataFormatEnum
            SVGData = 0
            SVGFile = 1
        End Enum

        Private iLineType As cIItemLine.LineTypeEnum

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
                Return True
            End Get
        End Property

        Public Sub ReducePoints(Optional ByVal Factor As Single = 0.1) Implements cIItemLine.ReducePoints
            If MyBase.Points.Count > 2 Then
                Call modPaint.ReducePoints(MyBase.Points, Factor, iLineType)
            End If
        End Sub

        Public Overrides ReadOnly Property CanBeMoved As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HaveTransparency As Boolean
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

        Public Overrides ReadOnly Property HaveText As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeRotated() As Boolean
            Get
                Return True
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

        Public Overrides ReadOnly Property BindMode As cItem.BindModeEnum
            Get
                Return BindModeEnum.AllPoints
            End Get
        End Property

        Friend Overrides Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
            Dim oMatrix As Matrix = New Matrix
            If PaintOptions.DrawTranslation Then
                Dim oTranslation As SizeF = MyBase.Design.GetItemTranslation(Me)
                Call oMatrix.Translate(oTranslation.Width, oTranslation.Height)
            End If
            Dim oSVGItem As XmlElement = MyBase.Caches(PaintOptions).ToSvgItem(SVG, PaintOptions, Options, oMatrix)
            Call oSVGItem.SetAttribute("name", MyBase.Name)
            Call modSVG.AppendItemStyle(SVG, oSVGItem, MyBase.Brush, MyBase.Pen)
            Return oSVGItem
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
                    'For Each oSequence As cSequence In MyBase.Points.GetSequences()
                    '    Dim oPath As GraphicsPath = New GraphicsPath
                    '    Dim oSequencePoints() As PointF = oSequence.GetPoints
                    '    Try
                    '        Select Case iLineType
                    '            Case cIItemLine.LineTypeEnum.Beziers
                    '                Call modPaint.PointsToBeziers(oSequencePoints, oPath)
                    '            Case cIItemLine.LineTypeEnum.Splines
                    '                Call oPath.AddCurve(oSequencePoints, sDefaultSplineTension)
                    '            Case Else
                    '                Call oPath.AddLines(oSequencePoints)
                    '        End Select
                    '    Catch
                    '    End Try
                    '    Call oSequence.GetPen(MyBase.Pen).Render(Graphics, PaintOptions, Options, Selected, oPath, oCache)
                    'Next

                    If MyBase.Points.Count > 1 Then
                        For Each oSequence As cSequence In MyBase.Points.GetSequences()
                            Using oPath As GraphicsPath = New GraphicsPath
                                If SequenceToPath(oSequence, iLineType, oPath) Then
                                    Call oSequence.GetPen(MyBase.Pen).Render(Graphics, PaintOptions, Options, Selected, oPath, oCache)
                                End If
                            End Using
                        Next
                    End If

                    Call .Rendered()
                End If
            End With
        End Sub

        Friend Overrides Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            If MyBase.Points.Count > 0 Then
                Call Render(Graphics, PaintOptions, Options, Selected)
                If (Graphics.VisibleClipBounds.IntersectsWith(MyBase.GetBounds) Or Not PaintOptions.IsDesign) And Not MyBase.HiddenInDesign Then
                    Call MyBase.Caches(PaintOptions).Paint(Graphics, PaintOptions, Options)
                    If PaintOptions.ShowSegmentBindings Then
                        Call modPaint.PaintPointToSegmentBindings(Graphics, MyBase.Survey, Me, Selected)
                    End If
                End If
            End If
        End Sub

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

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum, ByVal Clipart As cDrawClipArt, Optional ByVal Options As cItemGenericOptions = Nothing)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.Generic, Category)
            Dim oOptions As cItemGenericOptions = Options
            If oOptions Is Nothing Then oOptions = New cItemGenericOptions(Survey)
            Call pLoadData(Clipart, oOptions)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.Generic, Category)
            iLineType = Survey.Properties.DesignProperties.GetValue("LineType", Survey.GetGlobalSetting("design.linetype", cIItemLine.LineTypeEnum.Splines))
        End Sub

        Public Class cItemGenericOptions
            Private oSurvey As cSurvey

            Private iLineType As cIItemLine.LineTypeEnum
            Private sScale As Single
            Private bDivide As Boolean
            Private iMaxPathLen As Integer

            Public Sub New(ByVal Survey As cSurvey)
                oSurvey = Survey
                iMaxPathLen = oSurvey.GetGlobalSetting("svg.importmaxpathlen", 2000)
                sScale = modNumbers.StringToSingle(oSurvey.GetGlobalSetting("svg.importscale", 0.05))
                iLineType = oSurvey.GetGlobalSetting("svg.importlinetype", cIItemLine.LineTypeEnum.Splines)
                bDivide = oSurvey.GetGlobalSetting("svg.importautodivide", False)
            End Sub

            Public Sub New(ByVal LineType As cIItemLine.LineTypeEnum, ByVal Scale As Single)
                iLineType = LineType
                sScale = Scale
            End Sub

            Public Property MaxPathLen As Integer
                Get
                    Return iMaxPathLen
                End Get
                Set(ByVal value As Integer)
                    iMaxPathLen = value
                End Set
            End Property

            Public Property Scale() As Single
                Get
                    Return sScale
                End Get
                Set(ByVal value As Single)
                    sScale = value
                End Set
            End Property

            Public Property LineType As cIItemLine.LineTypeEnum
                Get
                    Return iLineType
                End Get
                Set(ByVal value As cIItemLine.LineTypeEnum)
                    iLineType = value
                End Set
            End Property

            Public Property Divide As Boolean
                Get
                    Return bDivide
                End Get
                Set(ByVal value As Boolean)
                    bDivide = value
                End Set
            End Property
        End Class

        Private Sub pLoadData(ByVal Clipart As cDrawClipArt, ByVal Options As cItemGenericOptions)
            Call MyBase.Points.BeginUpdate()
            Using oMatrix As Matrix = New Matrix
                Call oMatrix.Scale(Options.Scale, Options.Scale)
                Call Clipart.Transform(oMatrix)
            End Using
            Dim iSVGMaxPathLen As Integer = Options.MaxPathLen
            Call MyBase.Points.Clear()
            Dim iCount As Integer = Clipart.Paths.Count
            Dim iCurrent As Integer = 0
            Call MyBase.Survey.RaiseOnProgressEvent("item.import", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, modMain.GetLocalizedString("itemgeneric.progressbegin1"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageLoad Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow)
            For Each opath As cDrawPath In Clipart.Paths
                Call MyBase.Survey.RaiseOnProgressEvent("item.import", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("itemgeneric.progress1"), iCurrent / iCount)
                Try
                    Dim bFirst As Boolean = True
                    Dim oLastFirstDrawingPoint As PointF

                    Dim oLastFirstPoint As cPoint
                    Dim oLastPoint As cPoint

                    Dim iLastLineType As cIItemLine.LineTypeEnum = cIItemLine.LineTypeEnum.Undefined

                    If (opath.Path.PathPoints.LongLength < iSVGMaxPathLen) Or (iSVGMaxPathLen = 0) Then
                        For i As Long = 0 To opath.Path.PathPoints.LongLength - 1
                            Dim iType As PathPointType = opath.Path.PathTypes(i)
                            Dim iLineType As cIItemLine.LineTypeEnum
                            If (iType And PathPointType.Bezier) = PathPointType.Bezier Then
                                iLineType = cIItemLine.LineTypeEnum.Beziers
                            ElseIf (iType And PathPointType.Line) = PathPointType.Line Then
                                iLineType = cIItemLine.LineTypeEnum.Lines
                            Else
                                iLineType = cIItemLine.LineTypeEnum.Splines
                            End If
                            Dim oDrawingPoint As PointF = opath.Path.PathPoints(i)
                            Dim oPoint As cPoint = MyBase.Points.AddFromPaintPoint(oDrawingPoint)
                            If (iType And PathPointType.CloseSubpath) = PathPointType.CloseSubpath Then
                                oPoint = MyBase.Points.AddFromPaintPoint(oLastFirstDrawingPoint)
                            Else
                                If iType = PathPointType.Start Or bFirst Then
                                    oLastFirstDrawingPoint = oDrawingPoint
                                    oPoint.BeginSequence = True
                                    oLastFirstPoint = oPoint
                                    bFirst = False
                                Else
                                    If iLineType <> iLastLineType AndAlso Not IsNothing(oLastFirstPoint) Then
                                        oLastFirstPoint.LineType = iLineType
                                        iLastLineType = iLineType
                                    End If
                                End If
                            End If
                            oLastPoint = oPoint
                        Next
                    End If
                Catch
                End Try
                iCurrent += 1
            Next
            Call MyBase.Points.EndUpdate()
            Call MyBase.Survey.RaiseOnProgressEvent("item.import", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, modMain.GetLocalizedString("itemgeneric.progressend1"), 0)
            iLineType = Options.LineType
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum, ByVal Data As Object, ByVal DataFormat As cItemGenericDataFormatEnum)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.Generic, Category)
            Select Case DataFormat
                Case cItemGenericDataFormatEnum.SVGFile
                    Dim oClipart As cDrawClipArt = New cDrawClipArt(DirectCast(Data, String))
                    Call pLoadData(oClipart, New cItemGenericOptions(Survey))
                Case cItemGenericDataFormatEnum.SVGData
                    Dim oXML As Xml.XmlDocument = New Xml.XmlDocument
                    oXML.XmlResolver = Nothing
                    oXML.LoadXml(Data)
                    Data = oXML.InnerXml
                    DataFormat = cItemGenericDataFormatEnum.SVGData
                    Dim oClipart As cDrawClipArt = New cDrawClipArt(oXML)
                    Call pLoadData(oClipart, New cItemGenericOptions(Survey))
            End Select
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As Storage.cFile, ByVal item As XmlElement)
            Call MyBase.New(Survey, Design, Layer, File, item)
            iLineType = modXML.GetAttributeValue(item, "linetype", Items.cIItemLine.LineTypeEnum.Splines)
        End Sub

        Friend Overrides Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
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
            iLineType = Item.LineType
            Call Pen.CopyFrom(Item.Pen)
            Call Brush.CopyFrom(Item.Brush)
            If Clear Then
                Call MyBase.Points.Clear()
            End If
            For Each oPoint As cPoint In Item.Points
                Call MyBase.Points.Add(oPoint.Clone)
            Next
            Call MyBase.Points.EndUpdate()
            Return True
        End Function
    End Class
End Namespace

