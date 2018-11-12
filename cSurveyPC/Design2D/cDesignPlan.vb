Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Design.cLayers

Namespace cSurvey.Design
    Public Class cDesignPlan
        Inherits cDesign

        Private iType As cIDesign.cDesignTypeEnum

        Private oSurvey As cSurvey
        Private oPlot As cPlotPlan

        Public Overloads ReadOnly Property Layers As cLayers
            Get
                Return MyBase.Layers
            End Get
        End Property

        Public Overrides Sub Paint(Graphics As Graphics, PaintOptions As cOptions)
            MyBase.Paint(Graphics, PaintOptions)

            'Dim sArrowSize As Single = PaintOptions.DrawingObjects.CrossSectionMarkerArrowSize
            'Dim sRefLineLen As Single = sArrowSize * 4
            'For Each oItem As cItemCrossSection In oSurvey.Profile.Layers(LayerTypeEnum.Signs).Items.ToArray.Where(Function(item) item.Type = cIItem.cItemTypeEnum.CrossSection)
            '    If Not oItem.Segment Is Nothing AndAlso oItem.ShowMarker Then
            '        Dim oSegment As cSegment = oItem.Segment
            '        Dim iSegmentSign As Integer = IIf(oSegment.Direction = cSegment.DirectionEnum.Left, -1, 1) * IIf(oItem.Direction = cIItemCrossSection.DirectionEnum.Direct, 1, -1)
            '        Dim oFromPoint As PointF = oSegment.Data.Profile.FromPoint
            '        Dim oToPoint As PointF = oSegment.Data.Profile.ToPoint
            '        Dim oMarkerCenterPoint As PointF = modPaint.PointOnLineByPercentage(oFromPoint, oToPoint, oItem.MarkerPosition)
            '        Dim sU As Single = -1 * oItem.MarkerU
            '        Dim sD As Single = oItem.MarkerD
            '        'If sU = 0 Or sD = 0 Then
            '        '    Dim oUD As SizeF = modDesign.GetUDFromDesign(PaintOptions, oSegment, oMarkerCenterPoint, GetDesignStationEnum.From)
            '        '    If sU = 0 Then
            '        '        sU = oUD.Width * 1.1
            '        '    End If
            '        '    If sD = 0 Then
            '        '        sD = oUD.Height * 1.1
            '        '    End If
            '        'End If
            '        Dim oStartPointU As PointF = oMarkerCenterPoint + New SizeF(0, sU)
            '        Dim oEndPointU As PointF = oMarkerCenterPoint + New SizeF(0, sU - sRefLineLen)
            '        Dim oStartPointD As PointF = oMarkerCenterPoint + New SizeF(0, sD)
            '        Dim oEndPointD As PointF = oMarkerCenterPoint + New SizeF(0, sD + sRefLineLen)

            '        oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
            '        Call oCacheItem.SetPen(PaintOptions.DrawingObjects.CrossSectionMarkerPen)
            '        If oItem.MarkerProfileAlignment = cIItemCrossSection.MarkerProfileAlignmentEnum.Up Then
            '            Dim oArrowPoint As PointF = New PointF(oEndPointU.X + iSegmentSign * sArrowSize, oEndPointU.Y)
            '            Call oCacheItem.AddLines({oStartPointU, oEndPointU, oArrowPoint})
            '            oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Filler)
            '            Call oCacheItem.SetBrush(PaintOptions.DrawingObjects.CrossSectionMarkerBrush)
            '            Call oCacheItem.AddPolygon({oArrowPoint, New PointF(oArrowPoint.X, oArrowPoint.Y + sArrowSize / 2), New PointF(oArrowPoint.X + iSegmentSign * sArrowSize, oArrowPoint.Y), New PointF(oArrowPoint.X, oArrowPoint.Y - sArrowSize / 2), oArrowPoint})
            '        Else
            '            Call oCacheItem.AddLine(oStartPointU, oEndPointU)
            '        End If
            '        oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
            '        Call oCacheItem.SetPen(PaintOptions.DrawingObjects.CrossSectionMarkerPen)
            '        If oItem.MarkerProfileAlignment = cIItemCrossSection.MarkerProfileAlignmentEnum.Down Then
            '            Dim oArrowPoint As PointF = New PointF(oEndPointD.X + iSegmentSign * sArrowSize, oEndPointD.Y)
            '            Call oCacheItem.AddLines({oStartPointD, oEndPointD, oArrowPoint})
            '            oCacheItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Filler)
            '            Call oCacheItem.SetBrush(PaintOptions.DrawingObjects.CrossSectionMarkerBrush)
            '            Call oCacheItem.AddPolygon({oArrowPoint, New PointF(oArrowPoint.X, oArrowPoint.Y + sArrowSize / 2), New PointF(oArrowPoint.X + iSegmentSign * sArrowSize, oArrowPoint.Y), New PointF(oArrowPoint.X, oArrowPoint.Y - sArrowSize / 2), oArrowPoint})
            '        Else
            '            Call oCacheItem.AddLine(oStartPointD, oEndPointD)
            '        End If
            '    End If
            'Next
        End Sub

        Public Overrides ReadOnly Property Type As cIDesign.cDesignTypeEnum
            Get
                Return iType
            End Get
        End Property

        Public Sub New(ByVal Survey As cSurvey)
            Call MyBase.New(Survey)
            oSurvey = Survey
            iType = cIDesign.cDesignTypeEnum.Plan
            oPlot = New cPlotPlan(Survey)
        End Sub

        Friend Overrides Sub Redraw(Optional Options As cOptions = Nothing)
            Call MyBase.Redraw(Options)
            Call oPlot.Caches.Invalidate(Options)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As Storage.cFile, ByVal Design As XmlElement)
            Call MyBase.New(Survey, File, Design)
            oSurvey = Survey
            iType = cIDesign.cDesignTypeEnum.Plan
            Try
                oPlot = New cPlotPlan(Survey, Design.Item("plot"))
            Catch
                oPlot = New cPlotPlan(Survey)
            End Try
        End Sub

        Friend Overrides Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXmlDesign As XmlElement = Document.CreateElement("plan")
            Call DirectCast(MyBase.Layers, cLayer).SaveTo(File, Document, oXmlDesign, Options)
            Call MyBase.PointsJoins.SaveTo(File, Document, oXmlDesign)
            Call oPlot.SaveTo(File, Document, oXmlDesign)
            Call Parent.AppendChild(oXmlDesign)
            Return oXmlDesign
        End Function

        Public Overrides ReadOnly Property Plot() As cPlot
            Get
                Return oPlot
            End Get
        End Property

        Public Overrides Function GetNearestSegment(ByVal Cave As String, ByVal Branch As String, ByVal Point As PointF, ByVal BindDesignType As cItem.BindDesignTypeEnum) As cISegment
            Dim sMinDistance As Single = Single.MaxValue
            Dim oNearestSegment As cISegment = Nothing
            If BindDesignType = cItem.BindDesignTypeEnum.MainDesign Then
                For Each oSegment As cSegment In oSurvey.Segments.GetCaveSegments(Cave, Branch)
                    If Not oSegment.IsSelfDefined AndAlso oSegment.IsValid AndAlso Not oSegment.Unbindable AndAlso Not oSegment.Splay Then ' (bBindSplaySegment Or (Not bBindSplaySegment And Not oSegment.Splay)) Then
                        Dim sDistance As Single = Math.Abs(modPaint.DistancePointToSegment(Point, CType(oSegment.Data.Plan.FromPoint, PointF), CType(oSegment.Data.Plan.ToPoint, PointF)))
                        If sDistance < sMinDistance Then
                            sMinDistance = sDistance
                            oNearestSegment = oSegment
                        End If
                    End If
                Next
            End If
            Return oNearestSegment
        End Function

        Public Overrides Function GetNearestSegment(ByVal Cave As String, ByVal Branch As String, ByVal X As Single, ByVal Y As Single, ByVal BindDesignType As cItem.BindDesignTypeEnum) As cISegment
            Return GetNearestSegment(Cave, Branch, New PointF(X, Y), BindDesignType)
        End Function

        Friend Overrides Function GetSegmentPointData(ByVal Segment As cISegment) As Calculate.Plot.cIProjectedData
            Return Segment.Data.Plan
        End Function

        Public Overrides Function GetBounds(PaintOptions As cOptions) As System.Drawing.RectangleF
            Dim oDesignRect As RectangleF = MyBase.GetBounds(PaintOptions)
            Dim oSegmentsRect As RectangleF = oPlot.GetBounds(PaintOptions)
            If modPaint.IsRectangleEmpty(oDesignRect) And modPaint.IsRectangleEmpty(oSegmentsRect) Then
                Return oDesignRect
            Else
                If modPaint.IsRectangleEmpty(oDesignRect) Then
                    Return oSegmentsRect
                ElseIf modPaint.IsRectangleEmpty(oSegmentsRect) Then
                    Return oDesignRect
                Else
                    Return RectangleF.Union(oDesignRect, oSegmentsRect)
                End If
            End If
        End Function

        Public Overrides Function GetVisibleCaveBounds(ByVal PaintOptions As cOptions, ByVal Cave As String, Branch As String, ByVal IncludeDesign As Boolean) As RectangleF
            Dim oSegmentsRect As RectangleF = oPlot.GetVisibleCaveBounds(PaintOptions, Cave, Branch)
            If IncludeDesign Then
                Dim oDesignRect As RectangleF = MyBase.GetVisibleCaveBounds(PaintOptions, Cave, Branch, IncludeDesign)
                If modPaint.IsRectangleEmpty(oDesignRect) Then
                    Return oSegmentsRect
                Else
                    If modPaint.IsRectangleEmpty(oSegmentsRect) Then
                        Return oDesignRect
                    Else
                        Return RectangleF.Union(oDesignRect, oSegmentsRect)
                    End If
                End If
            Else
                Return oSegmentsRect
            End If
        End Function

        Public Overrides Function GetVisibleBounds(ByVal PaintOptions As cOptions) As System.Drawing.RectangleF
            Dim oDesignRect As RectangleF
            Dim oSegmentsRect As RectangleF
            If PaintOptions.DrawDesign Then
                oDesignRect = MyBase.GetVisibleBounds(PaintOptions)
            End If
            If PaintOptions.DrawPlot Then
                oSegmentsRect = oPlot.GetVisibleBounds(PaintOptions)
            End If
            If modPaint.IsRectangleEmpty(oDesignRect) And modPaint.IsRectangleEmpty(oSegmentsRect) Then
                Return oDesignRect
            Else
                If modPaint.IsRectangleEmpty(oDesignRect) Then
                    Return oSegmentsRect
                ElseIf modPaint.IsRectangleEmpty(oSegmentsRect) Then
                    Return oDesignRect
                Else
                    Return RectangleF.Union(oDesignRect, oSegmentsRect)
                End If
            End If
        End Function

        Public Overrides Function GetCaveBounds(Paintoptions As cOptions, ByVal Cave As String, ByVal Branch As String, ByVal IncludeDesign As Boolean) As System.Drawing.RectangleF
            Dim oSegmentsRect As RectangleF = oPlot.GetCaveBounds(Paintoptions, Cave, Branch)
            If IncludeDesign Then
                Dim oDesignRect As RectangleF = MyBase.GetCaveBounds(Paintoptions, Cave, Branch, IncludeDesign)
                If modPaint.IsRectangleEmpty(oDesignRect) Then
                    Return oSegmentsRect
                Else
                    Return RectangleF.Union(oDesignRect, oSegmentsRect)
                End If
            Else
                Return oSegmentsRect
            End If
        End Function

        Public Overrides Sub Clear()
            Call MyBase.Tool.Clear()
            Call MyBase.Layers.Clear()
        End Sub

        Friend Overrides Sub WarpItems(ByVal Segment As cISegment)
            'diff between current data and olddata
            'Dim oOldLine As PointF() = Segment.Data.Plan.GetOldLine
            'Dim oLine As PointF() = Segment.Data.Plan.GetLine
            'Dim sSize As Single = Math.Sqrt((oLine(0).X - oLine(1).X) ^ 2 + (oLine(0).Y - oLine(1).Y) ^ 2)
            'Dim sOldSize As Single = Math.Sqrt((oOldLine(0).X - oOldLine(1).X) ^ 2 + (oOldLine(0).Y - oOldLine(1).Y) ^ 2)
            'Dim sDeltaSize As Single
            'If sOldSize = 0 Then
            '    sDeltaSize = 1
            'Else
            '    sDeltaSize = modNumbers.MathRound(sSize / sOldSize, 4)
            'End If

            'Dim sDeltaX As Single = oLine(0).X - oOldLine(0).X
            'Dim sDeltaY As Single = oLine(0).Y - oOldLine(0).Y
            'Dim sNewLocationX As Single = oLine(0).X
            'Dim sNewLocationY As Single = oLine(0).Y

            'Dim sAngle As Single = Segment.Data.Data.Bearing
            'Dim sOldAngle As Single = Segment.Data.OldData.Bearing
            'Dim sDeltaAngle As Single = sAngle - sOldAngle

            'If sDeltaSize <> 1 Or sDeltaX <> 0 Or sDeltaY <> 0 Or sDeltaAngle <> 0 Then
            If Segment.Data.PlanWarpingFactor.IsChanged Then
                'creo 2 array, uno con i punti 'grotta' e uno con i punti grafici (che poi modificherò)
                Dim oDesignPointArray As List(Of cPoint) = New List(Of cPoint)
                Dim oPointArray As List(Of PointF) = New List(Of PointF)
                For Each oLayer As cLayer In MyBase.Layers
                    For Each oitem As cItem In oLayer.Items
                        If oitem.CanBeWarped Then
                            For Each oPoint As cPoint In oitem.Points
                                If oPoint.BindedSegment Is Segment Then
                                    Call oDesignPointArray.Add(oPoint)
                                    Call oPointArray.Add(New PointF(oPoint.X, oPoint.Y))
                                End If
                            Next
                        End If
                    Next
                Next

                'se ho trovato almeno un punto da sottoporre a trasformazione...procedo...
                If oDesignPointArray.Count > 0 Then
                    Dim oPoints() As PointF = oPointArray.ToArray

                    Using oMatrix As Matrix = New Matrix
                        Call oMatrix.Translate(-Segment.Data.PlanWarpingFactor.OldLocation.X, -Segment.Data.PlanWarpingFactor.OldLocation.Y, MatrixOrder.Append)
                        If Segment.Data.PlanWarpingFactor.OldAngle <> 0 Then
                            Call oMatrix.Rotate(-Segment.Data.PlanWarpingFactor.OldAngle, MatrixOrder.Append)
                        End If
                        If Segment.Data.PlanWarpingFactor.DeltaSize <> 1 Then
                            Call oMatrix.Scale(1, Segment.Data.PlanWarpingFactor.DeltaSize, MatrixOrder.Append)
                        End If
                        If Segment.Data.PlanWarpingFactor.NewAngle <> 0 Then
                            Call oMatrix.Rotate(Segment.Data.PlanWarpingFactor.NewAngle, MatrixOrder.Append)
                        End If
                        Call oMatrix.Translate(Segment.Data.PlanWarpingFactor.NewLocation.X, Segment.Data.PlanWarpingFactor.NewLocation.Y, MatrixOrder.Append)
                        Call oMatrix.TransformPoints(oPoints)
                    End Using

                    Dim iDesignPointIndex As Integer = 0
                    For Each oDesignpoint As cPoint In oDesignPointArray
                        Call oDesignpoint.MoveTo(oPoints(iDesignPointIndex).X, oPoints(iDesignPointIndex).Y)
                        iDesignPointIndex += 1
                    Next
                End If
            End If
        End Sub

        Friend Overrides Sub AppendSvgItem(ByVal SVG As XmlDocument, ByVal Parent As XmlElement, ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum, ByVal ViewArea As RectangleF, ByVal Zoom As Single, ByVal Translate As PointF)
            Dim oBound As RectangleF = GetBounds(PaintOptions)

            Dim sExportScaleFactor As Single = modNumbers.StringToSingle(oSurvey.GetGlobalSetting("svg.exportscale", 1))
            Dim sScale As Single = Zoom * sExportScaleFactor
            Call Parent.SetAttribute("transform", "translate(" & modNumbers.NumberToString(Translate.X) & "," & modNumbers.NumberToString(Translate.Y) & ") scale(" & modNumbers.NumberToString(sScale) & ")")

            If PaintOptions.DrawDesign Then
                If PaintOptions.DesignStyle = cOptions.DesignStyleEnum.Design Or PaintOptions.DesignStyle = cOptions.DesignStyleEnum.Combined Then
                    If (Options And cItem.SVGOptionsEnum.Clipping) = cItem.SVGOptionsEnum.Clipping Then
                        'determino le aree di clipping...
                        'creo varie collection di path per ogni grotta/ramo
                        'ogni collection verra trasformata in un gruppo i cui path verranno messi in merge nell'svg
                        Dim oClippingPaths As Dictionary(Of String, List(Of GraphicsPath)) = New Dictionary(Of String, List(Of GraphicsPath))
                        Dim oBorderLayer As Layers.cLayerBorders = MyBase.Layers.Item(cLayers.LayerTypeEnum.Borders)
                        Dim oMatrix As Matrix
                        Dim iBorderIndex As Integer = 0
                        Dim iBorderCount As Integer = oBorderLayer.Items.Count
                        For Each oItem As cItem In oBorderLayer.Items
                            Call oSurvey.RaiseOnProgressEvent("svg", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Creazione aree di ritaglio...", iBorderIndex / iBorderCount)
                            If oItem.Category = cIItem.cItemCategoryEnum.CaveBorder Then
                                Try
                                    Dim oCaveBorder As Design.Items.cItemInvertedFreeHandArea = oItem
                                    Dim oBorderPath As GraphicsPath = New GraphicsPath
                                    Dim oCache As cDrawCache = oCaveBorder.Caches(PaintOptions)
                                    If oCache.Count > 0 Then
                                        For Each oCacheItem As cDrawCacheItem In oCache
                                            Try
                                                Call oBorderPath.AddPath(oCacheItem.Path, True)
                                            Catch
                                            End Try
                                        Next
                                        Call oBorderPath.CloseAllFigures()

                                        If oBorderPath.PointCount > 0 Then
                                            If PaintOptions.DrawTranslation Then
                                                Dim oTranslation As SizeF = GetItemTranslation(oItem)
                                                oMatrix = New Matrix
                                                Call oMatrix.Translate(oTranslation.Width, oTranslation.Height)
                                                Call oBorderPath.Transform(oMatrix)
                                                Call oMatrix.Dispose()
                                            End If

                                            Dim sKey As String = modExport.FormatCaveBranchName(oItem.Cave, oItem.Branch)
                                            If oClippingPaths.ContainsKey(sKey) Then
                                                Dim oPaths As List(Of GraphicsPath) = oClippingPaths(sKey)
                                                Call oPaths.Add(oBorderPath)
                                            Else
                                                Dim oPaths As List(Of GraphicsPath) = New List(Of GraphicsPath)
                                                Call oPaths.Add(oBorderPath)
                                                Call oClippingPaths.Add(sKey, oPaths)
                                            End If
                                        End If
                                    End If
                                Catch
                                End Try
                            End If
                            iBorderIndex += 1
                        Next
                        iBorderIndex = 0
                        iBorderCount = oClippingPaths.Count
                        For Each sKey As String In oClippingPaths.Keys
                            Call oSurvey.RaiseOnProgressEvent("svg", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Esportazione aree di ritaglio...", iBorderIndex / iBorderCount)
                            Dim oSVGClipPath As XmlElement = modSVG.CreateClipPath(SVG, "clip_" & sKey)
                            Dim oPaths As List(Of GraphicsPath) = oClippingPaths(sKey)
                            For Each oPath As GraphicsPath In oPaths
                                Call modSVG.AppendItem(SVG, oSVGClipPath, PaintOptions, oPath)
                            Next
                            Call modSVG.AppendItem(SVG, Parent, oSVGClipPath)
                            iBorderIndex += 1
                        Next
                    End If
                    Dim iIndex As Integer = 0
                    Dim iCount As Integer = MyBase.Layers.Count
                    For Each oLayer As cLayer In MyBase.Layers
                        iIndex += 1
                        Call oSurvey.RaiseOnProgressEvent("svg", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Esportazione livelli...", iIndex / iCount)
                        Dim oSVGItem As XmlElement = oLayer.ToSvgItem(SVG, PaintOptions, Options)
                        Call modSVG.AppendItem(SVG, Parent, oSVGItem)
                    Next
                End If
            End If

            If PaintOptions.DesignStyle = cOptions.DesignStyleEnum.Areas Or PaintOptions.DesignStyle = cOptions.DesignStyleEnum.Combined Then
                Dim bDrawCaveBorder As Boolean
                Dim oBordersLayer As cSurveyPC.cSurvey.Design.Layers.cLayerBorders = MyBase.Layers(cLayers.LayerTypeEnum.Borders)
                Dim oSVGArea As XmlElement = modSVG.CreateGroup(SVG, "area")
                Dim iIndex As Integer = 0
                Dim iCount As Integer = oBordersLayer.Items.Count
                For Each oItem As cItem In oBordersLayer.Items
                    iIndex += 1
                    Call oSurvey.RaiseOnProgressEvent("svg", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Esportazione aree...", iIndex / iCount)

                    If oItem.Category = cIItem.cItemCategoryEnum.CaveBorder Then
                        Try
                            Dim oCaveBorder As cSurveyPC.cSurvey.Design.Items.cItemInvertedFreeHandArea = oItem
                            Dim oBorderPath As GraphicsPath = New GraphicsPath
                            Dim oCache As cDrawCache = oCaveBorder.Caches(PaintOptions)
                            If oCache.Count > 0 Then
                                bDrawCaveBorder = True
                                For Each oCacheItem As cDrawCacheItem In oCache
                                    Try
                                        Call oBorderPath.AddPath(oCacheItem.Path, True)
                                    Catch
                                    End Try
                                Next
                                Call oBorderPath.CloseAllFigures()
                            End If
                            If bDrawCaveBorder Then
                                Dim oColor As Color = oSurvey.Properties.CaveInfos.GetColor(oItem, Color.LightGray)
                                Dim oBrush As SolidBrush
                                If PaintOptions.DesignStyle = cOptions.DesignStyleEnum.Combined Then
                                    oBrush = New SolidBrush(Color.FromArgb(120, oColor))
                                Else
                                    oBrush = New SolidBrush(oColor)
                                End If

                                If Not PaintOptions.IsDesign And PaintOptions.DrawTranslation Then
                                    Dim oTranslationMatrix As Matrix = New Matrix
                                    Dim oTranslation As SizeF = GetItemTranslation(oItem)
                                    If Not oTranslation.IsEmpty Then
                                        oTranslationMatrix.Translate(oTranslation.Width, oTranslation.Height, Drawing2D.MatrixOrder.Prepend)
                                        Call oBorderPath.Transform(oTranslationMatrix)
                                    End If
                                    Call oTranslationMatrix.Dispose()
                                End If

                                Dim oSVGAreaItem As XmlElement = modSVG.CreateItem(SVG, PaintOptions, oBorderPath)
                                Call modSVG.AppendItemStyle(SVG, oSVGAreaItem, oBrush, Nothing)
                                Call modSVG.AppendItem(SVG, oSVGArea, oSVGAreaItem)
                                Call oBrush.Dispose()
                            End If
                            Call oBorderPath.Dispose()
                        Catch
                        End Try
                    End If
                Next
                Call modSVG.AppendItem(SVG, Parent, oSVGArea)
            End If

            'aggiungo la poligonale, se richiesta...
            If PaintOptions.DrawPlot Or PaintOptions.DrawSpecialPoints Then
                Call modSVG.AppendItem(SVG, Parent, oPlot.ToSvgItem(SVG, PaintOptions, Options))
            End If
        End Sub

        Friend Overrides Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum, ByVal ViewArea As RectangleF, ByVal Zoom As Single, ByVal Translate As PointF) As XmlElement
            Dim oSVGGroup As XmlElement = modSVG.CreateGroup(SVG, "plan")
            Call AppendSvgItem(SVG, oSVGGroup, PaintOptions, Options, ViewArea, Zoom, Translate)
            Return oSVGGroup
        End Function

        Friend Overrides Function ToSvg(ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum, ByVal ViewArea As RectangleF, ByVal Zoom As Single, ByVal Translate As PointF) As XmlDocument
            Call oSurvey.RaiseOnProgressEvent("svg", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, "Esportazione file SVG...", 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageExport Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage)

            Dim oSVG As XmlDocument = modSVG.CreateSVG(oSurvey.Name, ViewArea.Width, ViewArea.Height, SizeUnit.Pixel, SVGCreateFlagsEnum.AddInkScapeSettings)
            Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions, Options, ViewArea, Zoom, Translate))

            If PaintOptions.DrawPlot Or PaintOptions.DrawSpecialPoints Then
                Call modSVG.AppendItem(oSVG, Nothing, oPlot.ToSvgItem(oSVG, PaintOptions, Options))
            End If
            'questi oggetti sono scalati in funzione dell'area di rendering...
            'devo adattarli all'area di esportazione
            If PaintOptions.DrawScale Then
                Call modSVG.AppendItem(oSVG, Nothing, oPlot.Scale.ToSvgItem(oSVG, PaintOptions, Options))
            End If
            If PaintOptions.DrawCompass Then
                Call modSVG.AppendItem(oSVG, Nothing, oPlot.Compass.ToSvgItem(oSVG, PaintOptions, Options))
            End If
            If PaintOptions.DrawBox Then
                Call modSVG.AppendItem(oSVG, Nothing, oPlot.InfoBox.ToSvgItem(oSVG, PaintOptions, Options))
            End If

            Call oSurvey.RaiseOnProgressEvent("svg", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)

            Return oSVG
        End Function
    End Class
End Namespace
