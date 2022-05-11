Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Design.cLayers
Imports cSurveyPC.cSurvey.Calculate.Plot.cData

Namespace cSurvey.Design
    Public Class cDesignPlan
        Inherits cDesign

        Private iType As cIDesign.cDesignTypeEnum

        Private oSurvey As cSurvey
        Private oPlot As cPlotPlan

        Public Overrides Sub Paint(Graphics As Graphics, PaintOptions As cOptions, DrawOptions As cDrawOptions, Selection As Helper.Editor.cIEditDesignSelection)
            MyBase.Paint(Graphics, PaintOptions, DrawOptions, Selection)
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
            If Options.Survey Is oSurvey Then
                Call Threading.Tasks.Parallel.ForEach(Of cSurvey)(oSurvey.LinkedSurveys.GetUsable.Select(Function(oitem) oitem.LinkedSurvey), Sub(oLinkedSurvey)
                                                                                                                                                  Call oLinkedSurvey.Plan.Redraw(Options)
                                                                                                                                              End Sub)
            End If
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal Design As XmlElement)
            Call MyBase.New(Survey, File, Design)
            oSurvey = Survey
            iType = cIDesign.cDesignTypeEnum.Plan
            If modXML.ChildElementExist(Design, "plot") Then
                oPlot = New cPlotPlan(Survey, Design.Item("plot"))
            Else
                oPlot = New cPlotPlan(Survey)
            End If
        End Sub

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXmlDesign As XmlElement = Document.CreateElement("plan")
            Call MyBase.Layers.SaveTo(File, Document, oXmlDesign, Options)
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

        Public Overrides Function GetNearestSegment(ByVal Cave As String, ByVal Branch As String, CrossSection As String, ByVal Point As PointF, ByVal BindDesignType As cItem.BindDesignTypeEnum) As cISegment
            Dim sMinDistance As Single = Single.MaxValue
            Dim oNearestSegment As cISegment = Nothing
            If BindDesignType = cItem.BindDesignTypeEnum.MainDesign Then
                For Each oSegment As cSegment In oSurvey.Segments.GetCaveSegments(Cave, Branch)
                    If Not oSegment.IsUnbindable Then ' Not oSegment.IsSelfDefined AndAlso oSegment.IsValid AndAlso Not oSegment.IsEquate AndAlso Not oSegment.Unbindable AndAlso Not oSegment.Splay Then
                        Dim sDistance As Single = Math.Abs(modPaint.DistancePointToSegment(Point, CType(oSegment.Data.Plan.FromPoint, PointF), CType(oSegment.Data.Plan.ToPoint, PointF)))
                        If sDistance < sMinDistance Then
                            sMinDistance = sDistance
                            oNearestSegment = oSegment
                        End If
                    End If
                Next
            ElseIf BindDesignType = cItem.BindDesignTypeEnum.CrossSections Then
                If CrossSection = "" Then
                    For Each oCrossSection As cDesignCrossSection In oSurvey.CrossSections.GetCaveSegments(Cave, Branch)
                        If oCrossSection.Design.Type = iType Then
                            Dim oSegment As cISegment = oCrossSection
                            Dim sDistance As Single = Math.Abs(modPaint.DistancePointToSegment(Point, CType(oSegment.Data.Plan.FromPoint, PointF), CType(oSegment.Data.Plan.ToPoint, PointF)))
                            If sDistance < sMinDistance Then
                                sMinDistance = sDistance
                                oNearestSegment = oSegment
                            End If
                        End If
                    Next
                Else
                    oNearestSegment = oSurvey.CrossSections(CrossSection)
                End If
            End If
            Return oNearestSegment
        End Function

        Public Overrides Function GetNearestSegment(ByVal Cave As String, ByVal Branch As String, CrossSection As String, ByVal X As Single, ByVal Y As Single, ByVal BindDesignType As cItem.BindDesignTypeEnum) As cISegment
            Return GetNearestSegment(Cave, Branch, CrossSection, New PointF(X, Y), BindDesignType)
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

        Public Overrides Function GetDesignVisibleBounds(ByVal PaintOptions As cOptions) As System.Drawing.RectangleF
            Dim oDesignRect As RectangleF
            Dim oSegmentsRect As RectangleF
            If PaintOptions.DrawDesign Then
                oDesignRect = MyBase.GetDesignVisibleBounds(PaintOptions)
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
            Call MyBase.Layers.Clear()
        End Sub

        Friend Sub WarpItemsEx(ByVal Segment As cISegment, PlanWarpingFactor As cPlanWarpingFactor, Force As Boolean)
            If Not PlanWarpingFactor.IsCritical Then
                If PlanWarpingFactor.IsChanged OrElse Force Then
                    Dim oDesignPointArray As List(Of cPoint) = New List(Of cPoint)
                    Dim oPointArray As List(Of PointF) = New List(Of PointF)
                    For Each oLayer As cLayer In MyBase.Layers
                        For Each oitem As cItem In oLayer.Items
                            If oitem.CanBeWarped AndAlso oitem.DesignAffinity = cItem.DesignAffinityEnum.Design Then
                                For Each oPoint As cPoint In oitem.Points
                                    If oPoint.BindedSegment Is Segment Then
                                        Call oDesignPointArray.Add(oPoint)
                                        Call oPointArray.Add(New PointF(oPoint.X, oPoint.Y))
                                    End If
                                Next
                            End If
                        Next
                    Next

                    If oDesignPointArray.Count > 0 Then
                        Dim oPoints() As PointF = oPointArray.ToArray

                        Using oMatrix As Matrix = New Matrix
                            If Not -PlanWarpingFactor.OldLocation.IsEmpty Then
                                Call oMatrix.Translate(-PlanWarpingFactor.OldLocation.X, -PlanWarpingFactor.OldLocation.Y, MatrixOrder.Append)
                            End If
                            If PlanWarpingFactor.OldAngle <> 0 Then
                                Call oMatrix.Rotate(-PlanWarpingFactor.OldAngle, MatrixOrder.Append)
                            End If
                            If PlanWarpingFactor.DeltaSize <> 1 Then
                                Call oMatrix.Scale(1, PlanWarpingFactor.DeltaSize, MatrixOrder.Append)
                            End If
                            If PlanWarpingFactor.NewAngle <> 0 Then
                                Call oMatrix.Rotate(PlanWarpingFactor.NewAngle, MatrixOrder.Append)
                            End If
                            If Not PlanWarpingFactor.NewLocation.IsEmpty Then
                                Call oMatrix.Translate(PlanWarpingFactor.NewLocation.X, PlanWarpingFactor.NewLocation.Y, MatrixOrder.Append)
                            End If
                            Call oMatrix.TransformPoints(oPoints)
                        End Using

                        Dim iDesignPointIndex As Integer = 0
                        Dim oJoins As List(Of cPoint) = New List(Of cPoint)
                        For Each oDesignpoint As cPoint In oDesignPointArray
                            If oJoins.Contains(oDesignpoint) Then
                                Debug.Print("skipped joined point")
                            Else
                                Call oDesignpoint.MoveTo(oPoints(iDesignPointIndex).X, oPoints(iDesignPointIndex).Y)
                                'Call oDesignpoint.MoveToFromJoin(oPoints(iDesignPointIndex))
                                'If oDesignpoint.IsJoined Then
                                '    Call oJoins.Add(oDesignpoint)
                                '    For Each oJoinedPoint As cPoint In oDesignpoint.PointsJoin.ToArray(oDesignpoint)
                                '        Call oJoinedPoint.MoveToFromJoin(oPoints(iDesignPointIndex))
                                '        Call oJoins.Add(oJoinedPoint)
                                '    Next
                                'End If
                                If oDesignpoint.IsJoined Then
                                    Call oJoins.AddRange(oDesignpoint.PointsJoin.ToArray)
                                End If
                            End If
                            iDesignPointIndex += 1
                        Next
                    End If
                End If
            End If
        End Sub

        Friend Overrides Sub WarpItems(ByVal Segment As cISegment)
            Call WarpItemsEx(Segment, Segment.Data.PlanWarpingFactor, False)
        End Sub

        Private Sub pAppendSvgItem(ByVal SVG As XmlDocument, ByVal Parent As XmlElement, ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum)
            Dim oBound As RectangleF = GetBounds(PaintOptions)

            'Dim sExportScaleFactor As Single = modNumbers.StringToSingle(oSurvey.GetGlobalSetting("svg.exportscale", 1))
            'Dim sScale As Single = Zoom * sExportScaleFactor
            'Call Parent.SetAttribute("transform", "translate(" & modNumbers.NumberToString(Translate.X) & "," & modNumbers.NumberToString(Translate.Y) & ") scale(" & modNumbers.NumberToString(sScale) & ")")

            If PaintOptions.DrawDesign Then
                If PaintOptions.DesignStyle = cOptions.DesignStyleEnum.Design OrElse PaintOptions.DesignStyle = cOptions.DesignStyleEnum.Combined Then
                    If (Options And cItem.SVGOptionsEnum.Clipping) = cItem.SVGOptionsEnum.Clipping Then
                        Using oMaskPaths As cMaskPaths = New cMaskPaths
                            Dim oBorderLayer As Layers.cLayerBorders = MyBase.Layers.Item(cLayers.LayerTypeEnum.Borders)
                            Dim iBorderIndex As Integer = 0
                            Dim iBorderCount As Integer = oBorderLayer.Items.Count
                            For Each oItem As cItem In oBorderLayer.Items
                                Call oSurvey.RaiseOnProgressEvent("svg", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("design.svgexport.progress1"), iBorderIndex / iBorderCount)
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
                                                    If Not oTranslation.IsEmpty Then
                                                        Using oTranslationMatrix = New Matrix
                                                            Call oTranslationMatrix.Translate(oTranslation.Width, oTranslation.Height)
                                                            Call oBorderPath.Transform(oTranslationMatrix)
                                                        End Using
                                                    End If
                                                End If

                                                Dim sKey As String = modExport.FormatCaveBranchNameForSVG(oItem.Cave, oItem.Branch)
                                                Call oMaskPaths.AppendPath(sKey, oBorderPath, oCaveBorder.MergeMode)
                                            End If
                                        End If
                                    Catch
                                    End Try
                                End If
                                iBorderIndex += 1
                            Next
                            iBorderIndex = 0
                            iBorderCount = oMaskPaths.Count
                            For Each sKey As String In oMaskPaths.Keys
                                Call oSurvey.RaiseOnProgressEvent("svg", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("design.svgexport.progress2"), iBorderIndex / iBorderCount)

                                Dim oSVGMaskPath As XmlElement = modSVG.CreateMaskPath(SVG, "mask_" & sKey)
                                Dim oDirectMaskPaths As List(Of cMaskPath) = oMaskPaths(sKey)
                                For Each oDirectMaskPath As cMaskPath In oDirectMaskPaths
                                    Dim oSVGItem As XmlElement = modSVG.AppendItem(SVG, oSVGMaskPath, PaintOptions, oDirectMaskPath.Path)
                                    Select Case oDirectMaskPath.MergeMode
                                        Case cIItemMergeableArea.MergeModeEnum.Add
                                            Call oSVGItem.SetAttribute("fill", "white")
                                        Case cIItemMergeableArea.MergeModeEnum.Subtract
                                            Call oSVGItem.SetAttribute("fill", "black")
                                    End Select
                                Next
                                Call modSVG.AppendItem(SVG, Parent, oSVGMaskPath)

                                'inverted mask may be usefull only if used in the draw...in future have to be created only in this case...
                                Dim oSVGInvertedMaskPath As XmlElement = modSVG.CreateMaskPath(SVG, "invmask_" & sKey)
                                Dim oInvertedMaskPaths As List(Of cMaskPath) = oMaskPaths(sKey)
                                Dim oSVGRectAll As XmlElement = SVG.CreateElement("rect")
                                Call oSVGRectAll.SetAttribute("x", modNumbers.NumberToString(oBound.X))
                                Call oSVGRectAll.SetAttribute("y", modNumbers.NumberToString(oBound.Y))
                                Call oSVGRectAll.SetAttribute("width", modNumbers.NumberToString(oBound.Width))
                                Call oSVGRectAll.SetAttribute("height", modNumbers.NumberToString(oBound.Height))
                                Call oSVGRectAll.SetAttribute("fill", "white")
                                oSVGInvertedMaskPath.AppendChild(oSVGRectAll)
                                For Each oInvertedMaskPath As cMaskPath In oInvertedMaskPaths
                                    Dim oSVGItem As XmlElement = modSVG.AppendItem(SVG, oSVGInvertedMaskPath, PaintOptions, oInvertedMaskPath.Path)
                                    Select Case oInvertedMaskPath.MergeMode
                                        Case cIItemMergeableArea.MergeModeEnum.Add
                                            Call oSVGItem.SetAttribute("fill", "black")
                                        Case cIItemMergeableArea.MergeModeEnum.Subtract
                                            Call oSVGItem.SetAttribute("fill", "white")
                                    End Select
                                Next
                                Call modSVG.AppendItem(SVG, Parent, oSVGInvertedMaskPath)

                                iBorderIndex += 1
                            Next
                        End Using
                    End If

                    Dim iIndex As Integer = 0
                    Dim iCount As Integer = MyBase.Layers.Count
                    For Each oLayer As cLayer In MyBase.Layers
                        iIndex += 1
                        Call oSurvey.RaiseOnProgressEvent("svg", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("design.svgexport.progress3"), iIndex / iCount)
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
                    Call oSurvey.RaiseOnProgressEvent("svg", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("design.svgexport.progress4"), iIndex / iCount)

                    If oItem.Category = cIItem.cItemCategoryEnum.CaveBorder Then
                        Try
                            Dim oCaveBorder As cSurveyPC.cSurvey.Design.Items.cItemInvertedFreeHandArea = oItem
                            Using oBorderPath As GraphicsPath = New GraphicsPath
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
                                    Using oBrush As SolidBrush = If(PaintOptions.DesignStyle = cOptions.DesignStyleEnum.Combined, New SolidBrush(Color.FromArgb(120, oColor)), New SolidBrush(oColor))
                                        If Not PaintOptions.IsDesign And PaintOptions.DrawTranslation Then
                                            Dim oTranslation As SizeF = GetItemTranslation(oItem)
                                            If Not oTranslation.IsEmpty Then
                                                Using oTranslationMatrix = New Matrix
                                                    Call oTranslationMatrix.Translate(oTranslation.Width, oTranslation.Height, Drawing2D.MatrixOrder.Prepend)
                                                    Call oBorderPath.Transform(oTranslationMatrix)
                                                End Using
                                            End If
                                        End If
                                        Dim oSVGAreaItem As XmlElement = modSVG.CreateItem(SVG, PaintOptions, oBorderPath)
                                        Call modSVG.AppendItemStyle(SVG, oSVGAreaItem, oBrush, Nothing)
                                        Call modSVG.AppendItem(SVG, oSVGArea, oSVGAreaItem)
                                    End Using
                                End If
                            End Using
                        Catch
                        End Try
                    End If
                Next
                Call modSVG.AppendItem(SVG, Parent, oSVGArea)
            End If
        End Sub

        Friend Overrides Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
            Dim oSVGGroup As XmlElement = modSVG.CreateLayer(SVG, "design", "design")
            Call pAppendSvgItem(SVG, oSVGGroup, PaintOptions, Options)
            Return oSVGGroup
        End Function

        Friend Overrides Function ToSvg(ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum, Size As SizeF, PageBox As RectangleF, Unit As SizeUnit, ByVal ViewBox As RectangleF) As XmlDocument
            Call oSurvey.RaiseOnProgressEvent("svg", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, modMain.GetLocalizedString("design.svgexport.progressbegin1"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageExport Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage)

            Dim oBounds As RectangleF = New RectangleF(0, 0, Size.Width, Size.Height)

            Dim bLegacyObjects As Boolean = PaintOptions.DrawScale OrElse PaintOptions.DrawCompass OrElse PaintOptions.DrawBox

            Dim oSVG As XmlDocument
            Dim oDesign As XmlElement
            If bLegacyObjects Then
                oSVG = modSVG.CreateSVG(oSurvey.Name, Size, Unit, oBounds, SVGCreateFlagsEnum.AddInkScapeSettings)
                oDesign = modSVG.CreateSubSVG(oSVG, "plan", PageBox, SizeUnit.none, ViewBox)
            Else
                oSVG = modSVG.CreateSVG(oSurvey.Name, Size, Unit, ViewBox, SVGCreateFlagsEnum.AddInkScapeSettings)
                oDesign = modSVG.CreateLayer(oSVG, "plan", "plan")
            End If
            'Call modSVG.AppendRectangle(oSVG, oDesign, ViewBox, Nothing, PaintOptions.DrawingObjects.TranslationPen)
            Call modSVG.AppendItem(oSVG, oDesign, ToSvgItem(oSVG, PaintOptions, Options))
            If PaintOptions.DrawPlot OrElse PaintOptions.DrawSpecialPoints Then
                Call modSVG.AppendItem(oSVG, oDesign, oPlot.ToSvgItem(oSVG, PaintOptions, Options))
            End If
            Call modSVG.AppendItem(oSVG, Nothing, oDesign)

            If bLegacyObjects Then
                Dim oGadget As XmlElement = modSVG.CreateSubSVG(oSVG, "legacyobjects", oBounds, SizeUnit.none, oBounds)
                If PaintOptions.DrawScale Then
                    Call modSVG.AppendItem(oSVG, oGadget, oPlot.Scale.ToSvgItem(oSVG, PaintOptions, Options))
                End If
                If PaintOptions.DrawCompass Then
                    Call modSVG.AppendItem(oSVG, oGadget, oPlot.Compass.ToSvgItem(oSVG, PaintOptions, Options))
                End If
                If PaintOptions.DrawBox Then
                    Call modSVG.AppendItem(oSVG, oGadget, oPlot.InfoBox.ToSvgItem(oSVG, PaintOptions, Options))
                End If
                Call modSVG.AppendItem(oSVG, Nothing, oGadget)
            End If

            Call oSurvey.RaiseOnProgressEvent("svg", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, modMain.GetLocalizedString("design.svgexport.progressend1"), 0)

            Return oSVG
        End Function
    End Class
End Namespace
