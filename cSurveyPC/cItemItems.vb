Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Design.Layers
Imports cSurveyPC.cSurvey.Design.cLayers
Imports cSurveyPC.cSurvey.Data
Imports DevExpress.Office
Imports DevExpress.Pdf

Namespace cSurvey.Design.Items
    Public Class cItemItems
        Inherits cItem
        Implements IEnumerable
        Implements IEnumerable(Of cItem)
        Implements IReadOnlyList(Of cItem)

        Private oItems As List(Of cItem)
        Private WithEvents oDataProperties As Data.cDataProperties

        Public Overrides ReadOnly Property HaveAffinity As Boolean
            Get
                For Each oItem As cItem In oItems
                    If oItem.HaveAffinity Then
                        'if only one item haveaffinity...return true
                        Return True
                    End If
                Next
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeCopied As Boolean
            Get
                For Each oItem As cItem In oItems
                    If oItem.CanBeCopied Then
                        'if only one item is copiable...return true
                        Return True
                    End If
                Next
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property DataProperties As Data.cDataProperties
            Get
                For Each ofield As cDataField In oDataProperties.Fields
                    Dim bEgual As Boolean = True
                    Dim bFirst As Boolean = True
                    Dim oValue As Object = Nothing
                    For Each oItem As cItem In oItems
                        If bFirst Then
                            oValue = oItem.DataProperties.GetValue(ofield.Name)
                            bFirst = False
                        Else
                            Dim oNewValue As Object = oItem.DataProperties.GetValue(ofield.Name)
                            If Not (IsNothing(oValue) AndAlso IsNothing(oNewValue)) Then
                                If (oValue <> oNewValue) Then
                                    bEgual = False
                                    Exit For
                                End If
                            End If
                        End If
                    Next
                    If bEgual Then
                        Call oDataProperties.SetValue(ofield.Name, oValue)
                    End If
                Next
                Return oDataProperties
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

        Public Function First() As cItem
            Return oItems.First
        End Function

        Public Function Last() As cItem
            Return oItems.Last
        End Function

        Public Overrides Property DesignAffinity As DesignAffinityEnum
            Get
                If oItems.Count > 0 Then
                    Dim iDesignAffinity As cItem.DesignAffinityEnum
                    Dim bFirst As Boolean = True
                    For Each oItem As cItem In oItems
                        If bFirst Then
                            iDesignAffinity = oItem.DesignAffinity
                            bFirst = False
                        Else
                            If iDesignAffinity <> oItem.DesignAffinity Then
                                Return DesignAffinityEnum.Undefined
                            End If
                        End If
                    Next
                    Return iDesignAffinity
                Else
                    Return False
                End If
            End Get
            Set(value As DesignAffinityEnum)
                If value <> DesignAffinityEnum.Undefined Then
                    For Each oItem As cItem In oItems
                        oItem.DesignAffinity = value
                    Next
                End If
            End Set
        End Property

        Public Overrides Property FilteredInDesign As Boolean
            Get
                If oItems.Count > 0 Then
                    Dim bFilteredInDesign As Boolean
                    Dim bFirst As Boolean = True
                    For Each oItem As cItem In oItems
                        If bFirst Then
                            bFilteredInDesign = oItem.FilteredInDesign
                            bFirst = False
                        Else
                            If bFilteredInDesign <> oItem.FilteredInDesign Then
                                Return False
                            End If
                        End If
                    Next
                    Return bFilteredInDesign
                Else
                    Return False
                End If
            End Get
            Set(value As Boolean)
                For Each oItem As cItem In oItems
                    oItem.FilteredInDesign = value
                Next
            End Set
        End Property

        Public Overrides Property HiddenInPreview As Boolean
            Get
                If oItems.Count > 0 Then
                    Dim bHiddenInPreview As Boolean
                    Dim bFirst As Boolean = True
                    For Each oItem As cItem In oItems
                        If bFirst Then
                            bHiddenInPreview = oItem.HiddenInPreview
                            bFirst = False
                        Else
                            If bHiddenInPreview <> oItem.HiddenInPreview Then
                                Return False
                            End If
                        End If
                    Next
                    Return bHiddenInPreview
                Else
                    Return False
                End If
            End Get
            Set(value As Boolean)
                For Each oItem As cItem In oItems
                    oItem.HiddenInPreview = value
                Next
            End Set
        End Property

        Public Overrides Property HiddenInDesign As Boolean
            Get
                If oItems.Count > 0 Then
                    Dim bHiddenInDesign As Boolean
                    Dim bFirst As Boolean = True
                    For Each oItem As cItem In oItems
                        If bFirst Then
                            bHiddenInDesign = oItem.HiddenInDesign
                            bFirst = False
                        Else
                            If bHiddenInDesign <> oItem.HiddenInDesign Then
                                Return False
                            End If
                        End If
                    Next
                    Return bHiddenInDesign
                Else
                    Return False
                End If
            End Get
            Set(value As Boolean)
                For Each oItem As cItem In oItems
                    oItem.HiddenInDesign = value
                Next
            End Set
        End Property

        Friend Overrides Sub Invalidate(PaintOptions As cOptions)
            For Each oitem As cItem In oItems
                Call oitem.Invalidate(PaintOptions)
            Next
        End Sub

        Public Function Contains(Item As cItem) As Boolean
            Return oItems.Contains(Item)
        End Function

        Public Overrides ReadOnly Property CanBeReduced As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeWarped As Boolean
            Get
                Return False
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

        Public Overrides ReadOnly Property HaveTransparency As Boolean
            Get
                If oItems Is Nothing Then
                    Return False
                Else
                    For Each oItem As cItem In oItems
                        If Not oItem.HaveTransparency Then
                            Return False
                        End If
                    Next
                    Return True
                End If
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeConverted As Boolean
            Get
                If oItems Is Nothing Then
                    Return False
                Else
                    For Each oItem As cItem In oItems
                        If Not oItem.CanBeConverted Then
                            Return False
                        End If
                    Next
                    Return True
                End If
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
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveFont As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveEditablePoints As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeRotated As Boolean
            Get
                Return True
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

        Public Overrides ReadOnly Property CanBeBinded As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property BindMode As cItem.BindModeEnum
            Get
                Return BindModeEnum.AllPoints
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeCombined As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeDivided As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeResized As Boolean
            Get
                Return True
            End Get
        End Property

        Public Sub Add(ByVal Item As cItem)
            If Not IsNothing(Item) AndAlso Not oItems.Contains(Item) Then
                Call oItems.Add(Item)
            End If
        End Sub

        Public Sub AddRange(ByVal Items As IEnumerable(Of cItem))
            Call oItems.AddRange(Items.Where(Function(oItem) Not IsNothing(oItem) AndAlso Not oItems.Contains(oItem)))
        End Sub

        Public Sub Clear()
            Call oItems.Clear()
        End Sub

        Public Function Remove(ByVal Item As cItem) As Boolean
            If oItems.Contains(Item) Then
                Call oItems.Remove(Item)
                Return True
            Else
                Return False
            End If
        End Function

        Public Sub RemoveAt(ByVal Index As Integer)
            If Index >= 0 And Index < oItems.Count Then
                Call oItems.RemoveAt(Index)
            End If
        End Sub

        Public ReadOnly Property Count As Integer Implements IReadOnlyList(Of cItem).Count
            Get
                Return oItems.Count
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal Index As Integer) As cItem Implements IReadOnlyList(Of cItem).Item
            Get
                Return oItems(Index)
            End Get
        End Property

        Public Overrides ReadOnly Property MaxPointsCount As Integer
            Get
                Return 0
            End Get
        End Property

        Friend Overrides Sub Render(ByVal Graphics As System.Drawing.Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            'do nothing...items is a UI element only for editor, item inside will be rendered
        End Sub

        Friend Overrides Sub Paint(ByVal Graphics As System.Drawing.Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            'do nothing...items is a UI element only for editor, item inside will be painted
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.Items, Category)
            oItems = New List(Of cItem)
            oDataProperties = New Data.cDataProperties(Survey, Survey.Properties.DataTables.DesignItems)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As cFile, ByVal item As XmlElement)
            Call MyBase.New(Survey, Design, Layer, File, item)
            oItems = New List(Of cItem)
            oDataProperties = New Data.cDataProperties(Survey, Survey.Properties.DataTables.DesignItems)
            For Each oXMLItem As XmlElement In item.Item("items")
                Dim iLayer As cLayers.LayerTypeEnum = oXMLItem.GetAttribute("layer")
                Dim oItem As cItem = cLayer.CreateItem(Survey, Design, Design.Layers.Item(iLayer), File, oXMLItem)
                Call oItems.Add(oitem)
                If oItem.Type = cIItem.cItemTypeEnum.CrossSection Then
                    Call MyBase.Survey.CrossSections.Add(oItem)
                End If
            Next
        End Sub

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXMLItem As XmlElement = MyBase.SaveTo(File, Document, Parent, Options)
            Dim oXMLItems As XmlElement = Document.CreateElement("items")
            For Each oItem As cItem In oItems
                Call oItem.SaveTo(File, Document, oXMLItems, Options)
            Next
            Call oXMLItem.AppendChild(oXMLItems)
            Return oXMLItem
        End Function

        Public Overrides Function GetBounds() As System.Drawing.RectangleF
            Dim oRect As RectangleF
            For Each oItem As cItem In oItems
                Dim oNewRect As RectangleF = oItem.GetBounds()
                If Not modPaint.IsRectangleEmpty(oNewRect) Then
                    If oRect.IsEmpty Then
                        oRect = oNewRect
                    Else
                        oRect = RectangleF.Union(oRect, oNewRect)
                    End If
                End If
            Next
            Return oRect
        End Function

        Public Overrides Sub ResizeBy(ByVal ScaleWidth As Single, ByVal ScaleHeight As Single)
            Dim oBounds As RectangleF = GetBounds()
            Dim dScaleX As Single = ScaleWidth
            Dim dScaleY As Single = ScaleHeight
            If Not (modNumbers.MathRound(dScaleX, 5) = 1 And modNumbers.MathRound(dScaleY, 5) = 1) Then
                Dim oLocation As PointF = oBounds.Location
                Dim oItemsPoints As List(Of cPoint) = New List(Of cPoint)
                Dim oItemsPointF As List(Of PointF) = New List(Of PointF)
                For Each oItem As cItem In oItems
                    If (oItem.CanBeResized And oItem.Points.Count > 0) Or (Not oItem.CanBeResized And oItem.Points.Count = 1) Then
                        Call oItemsPoints.AddRange(oItem.Points.ToArray)
                        Call oItemsPointF.AddRange(oItem.Points.GetPoints)
                    End If
                Next
                Using oMatrix As Matrix = New Matrix
                    oMatrix.Translate(-oLocation.X, -oLocation.Y, MatrixOrder.Append)
                    Call oMatrix.Scale(dScaleX, dScaleY, MatrixOrder.Append)
                    oMatrix.Translate(oLocation.X, oLocation.Y, MatrixOrder.Append)
                    Dim oItemsPointsArray() As PointF = oItemsPointF.ToArray
                    Call oMatrix.TransformPoints(oItemsPointsArray)
                    For i As Integer = 0 To oItemsPointsArray.Count - 1
                        oItemsPoints(i).MoveTo(oItemsPointsArray(i))
                    Next
                End Using
            End If

            'For Each oItem As cItem In oItems
            '    If (oItem.CanBeResized And oItem.Points.Count > 0) Or (Not oItem.CanBeResized And oItem.Points.Count = 1) Then
            '        Dim oxPoints() As PointF = oItem.Points.GetPoints()
            '        Dim oMatrix As Matrix = New Matrix
            '        oMatrix.Translate(-oLocation.X, -oLocation.Y, MatrixOrder.Append)
            '        Call oMatrix.Scale(dScaleX, dScaleY, MatrixOrder.Append)
            '        oMatrix.Translate(oLocation.X, oLocation.Y, MatrixOrder.Append)
            '        Call oMatrix.TransformPoints(oxPoints)
            '        Call oMatrix.Dispose()
            '        For i As Integer = 0 To oItem.Points.Count - 1
            '            oItem.Points(i).MoveTo(oxPoints(i))
            '        Next
            '    End If
            'Next
        End Sub

        Public Overrides Sub SetCave(ByVal Cave As String, Optional ByVal Branch As String = "", Optional ByVal BindSegment As Boolean = True)
            For Each oItem As cItem In oItems
                Call oItem.SetCave(Cave, Branch, BindSegment)
            Next
        End Sub

        Public Overrides Sub SetBindDesignType(ByVal BindDesignType As BindDesignTypeEnum, Optional CrossSection As cDesignCrossSection = Nothing, Optional ByVal BindSegment As Boolean = True)
            For Each oItem As cItem In oItems
                Call oItem.SetBindDesignType(BindDesignType, CrossSection, BindSegment)
            Next
        End Sub

        Friend Overrides Sub RenameCave(ByVal Cave As String, ByVal Branch As String)
            For Each oItem As cItem In oItems
                Call oItem.RenameCave(Cave, Branch)
            Next
        End Sub

        Public Overrides ReadOnly Property BindDesignType As BindDesignTypeEnum
            Get
                If oItems.Count > 0 Then
                    Dim iBindDesignType As BindDesignTypeEnum = BindDesignTypeEnum.MainDesign
                    Dim bFirst As Boolean = True
                    For Each oItem As cItem In oItems
                        If oItem.CanBeBinded Then
                            If bFirst Then
                                iBindDesignType = oItem.BindDesignType
                                bFirst = False
                            Else
                                If iBindDesignType <> oItem.BindDesignType Then Return BindDesignTypeEnum.MainDesign
                            End If
                        End If
                    Next
                    Return iBindDesignType
                Else
                    Return BindDesignTypeEnum.MainDesign
                End If
            End Get
        End Property

        Public Overrides Property Transparency As Single
            Get
                If oItems.Count > 0 Then
                    Dim sTransparency As Single
                    Dim bFirst As Boolean = True
                    For Each oItem As cItem In oItems
                        If oItem.HaveTransparency Then
                            If bFirst Then
                                sTransparency = oItem.Transparency
                                bFirst = False
                            Else
                                If sTransparency <> oItem.Transparency Then
                                    Return 0
                                End If
                            End If
                        End If
                    Next
                    Return sTransparency
                Else
                    Return 0
                End If
            End Get
            Set(value As Single)
                For Each oItem As cItem In oItems
                    If oItem.HaveTransparency Then
                        oItem.Transparency = value
                    End If
                Next
            End Set
        End Property

        Public Overrides ReadOnly Property CrossSection As String
            Get
                If oItems.Count > 0 Then
                    Dim sCrossSection As String = oItems(0).CrossSection
                    For Each oItem As cItem In oItems
                        If sCrossSection <> oItem.CrossSection Then Return ""
                    Next
                    Return sCrossSection
                Else
                    Return ""
                End If
            End Get
        End Property

        Public Overrides ReadOnly Property Cave As String
            Get
                If oItems.Count > 0 Then
                    Dim sCave As String = oItems(0).Cave
                    For Each oItem As cItem In oItems
                        If sCave <> oItem.Cave Then Return ""
                    Next
                    Return sCave
                Else
                    Return ""
                End If
            End Get
        End Property

        Public Overrides ReadOnly Property Branch As String
            Get
                If oItems.Count > 0 Then
                    Dim sBranch As String = oItems(0).Branch
                    For Each oItem As cItem In oItems
                        If sBranch <> oItem.Branch Then Return ""
                    Next
                    Return sBranch
                Else
                    Return ""
                End If
            End Get
        End Property

        Public Overrides Sub ResizeBy(ByVal Size As System.Drawing.SizeF)
            Call ResizeBy(Size.Width, Size.Height)
        End Sub

        Public Overrides Property Locked As Boolean
            Get
                If oItems.Count > 0 Then
                    Dim bLocked As Boolean = oItems(0).Locked
                    For Each oItem As cItem In oItems
                        If bLocked <> oItem.Locked Then Return False
                    Next
                    Return bLocked
                Else
                    Return False
                End If
            End Get
            Set(ByVal value As Boolean)
                For Each oItem As cItem In oItems
                    oItem.Locked = value
                Next
            End Set
        End Property

        Public Overrides ReadOnly Property HaveText As Boolean
            Get
                Return False
            End Get
        End Property

        Friend Overrides Function ToSvgItem(ByVal SVG As cSVGWriter, ByVal PaintOptions As cOptionsCenterline) As XmlElement
            Dim oSVGGroup As XmlElement = modSVG.CreateGroup(SVG, "_items")
            For Each oItem As cItem In oItems
                Dim oSVGItem As XmlElement = oItem.ToSvgItem(SVG, PaintOptions)
                Call modSVG.AppendItem(SVG, oSVGGroup, oSVGItem)
            Next
            Return oSVGGroup
        End Function

        'Friend Overrides Function ToSvg(ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlDocument
        '    Dim oSVG As cSVGWriter = modSVG.CreateSVG
        '    Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions, Options))
        '    Return oSVG
        'End Function

        Public Overrides Sub ResizeTo(ByVal Width As Single, ByVal Height As Single)
            Dim oBounds As RectangleF = GetBounds()
            Dim dScaleX As Single = Width / oBounds.Width
            Dim dScaleY As Single = Height / oBounds.Height
            If Not (modNumbers.MathRound(dScaleX, 5) = 1 And modNumbers.MathRound(dScaleY, 5) = 1) Then

                Dim oLocation As PointF = oBounds.Location
                Dim oItemsPoints As List(Of cPoint) = New List(Of cPoint)
                Dim oItemsPointF As List(Of PointF) = New List(Of PointF)
                For Each oItem As cItem In oItems
                    If (oItem.CanBeResized And oItem.Points.Count > 0) Or (Not oItem.CanBeResized And oItem.Points.Count = 1) Then
                        Call oItemsPoints.AddRange(oItem.Points.ToArray)
                        Call oItemsPointF.AddRange(oItem.Points.GetPoints)
                    End If
                Next

                Dim oMatrix As Matrix = New Matrix
                oMatrix.Translate(-oLocation.X, -oLocation.Y, MatrixOrder.Append)
                Call oMatrix.Scale(dScaleX, dScaleY, MatrixOrder.Append)
                oMatrix.Translate(oLocation.X, oLocation.Y, MatrixOrder.Append)
                Dim oItemsPointsArray() As PointF = oItemsPointF.ToArray
                Call oMatrix.TransformPoints(oItemsPointsArray)
                Call oMatrix.Dispose()

                For i As Integer = 0 To oItemsPointsArray.Count - 1
                    oItemsPoints(i).MoveTo(oItemsPointsArray(i))
                Next

                'Dim oLocation As PointF = oBounds.Location
                'For Each oItem As cItem In oItems
                '    If (oItem.CanBeResized And oItem.Points.Count > 0) Or (Not oItem.CanBeResized And oItem.Points.Count = 1) Then
                '        Dim oxPoints() As PointF = oItem.Points.GetPoints()
                '        Dim oMatrix As Matrix = New Matrix
                '        oMatrix.Translate(-oLocation.X, -oLocation.Y, MatrixOrder.Append)
                '        Call oMatrix.Scale(dScaleX, dScaleY, MatrixOrder.Append)
                '        oMatrix.Translate(oLocation.X, oLocation.Y, MatrixOrder.Append)
                '        Call oMatrix.TransformPoints(oxPoints)
                '        Call oMatrix.Dispose()
                '        For i As Integer = 0 To oItem.Points.Count - 1
                '            oItem.Points(i).MoveTo(oxPoints(i))
                '        Next
                '    End If
                'Next
            End If
        End Sub

        Public Overrides Sub ResizeTo(ByVal Size As System.Drawing.SizeF)
            Call ResizeTo(Size.Width, Size.Height)
        End Sub

        Public Enum SpaceEnum
            ToMinimum = 0
            ToMaximum = 1
        End Enum

        Public Sub HorizontalSpace(Space As SpaceEnum)
            Dim sDistance As Single
            Select Case Space
                Case SpaceEnum.ToMinimum
                    sDistance = Single.MaxValue
                Case SpaceEnum.ToMaximum
                    sDistance = Single.MinValue
            End Select

            Dim oSortedList As SortedList(Of Single, cItem) = New SortedList(Of Single, cItem)
            For Each oitem As cItem In oItems
                Dim oRect As RectangleF = oitem.GetBounds
                oSortedList.Add(oRect.Left, oitem)
            Next
            Dim [sLeft] As Single = oSortedList.First.Value.GetBounds.Left

            Dim oLastRect As RectangleF
            For Each oitem As cItem In oSortedList.Values
                Dim oRect As RectangleF = oitem.GetBounds
                If Not oLastRect.IsEmpty Then
                    Select Case Space
                        Case SpaceEnum.ToMinimum
                            Dim sCurrentDistance As Single = Math.Abs(oLastRect.Right - oRect.Left)
                            If sCurrentDistance < sDistance Then sDistance = sCurrentDistance
                        Case SpaceEnum.ToMaximum
                            Dim sCurrentDistance As Single = Math.Abs(oLastRect.Right - oRect.Left)
                            If sCurrentDistance > sDistance Then sDistance = sCurrentDistance
                    End Select
                End If
                oLastRect = oRect
            Next
            For Each oItem As cItem In oSortedList.Values
                Dim oRect As RectangleF = oItem.GetBounds
                Select Case oItem.Type
                    Case cIItem.cItemTypeEnum.CrossSection
                        Dim oCrossSection As cItemCrossSection = oItem
                        Dim bMoveBindedObjects As Boolean = oCrossSection.MoveBindedObjects
                        oCrossSection.MoveBindedObjects = False
                        Call oItem.MoveTo(New PointF(sLeft, oRect.Top))
                        oCrossSection.MoveBindedObjects = bMoveBindedObjects
                    Case Else
                        Call oItem.MoveTo(New PointF(sLeft, oRect.Top))
                End Select
                sLeft = sLeft + oRect.Width + sDistance
            Next
        End Sub

        Public Sub VerticalSpace(Space As SpaceEnum)
            Dim sDistance As Single
            Select Case Space
                Case SpaceEnum.ToMinimum
                    sDistance = Single.MaxValue
                Case SpaceEnum.ToMaximum
                    sDistance = Single.MinValue
            End Select

            Dim oSortedList As SortedList(Of Single, cItem) = New SortedList(Of Single, cItem)
            For Each oitem As cItem In oItems
                Dim oRect As RectangleF = oitem.GetBounds
                oSortedList.Add(oRect.Top, oitem)
            Next
            Dim [sTop] As Single = oSortedList.First.Value.GetBounds.Top

            Dim oLastRect As RectangleF
            For Each oitem As cItem In oSortedList.Values
                Dim oRect As RectangleF = oitem.GetBounds
                If Not oLastRect.IsEmpty Then
                    Select Case Space
                        Case SpaceEnum.ToMinimum
                            Dim sCurrentDistance As Single = Math.Abs(oLastRect.Bottom - oRect.Top)
                            If sCurrentDistance < sDistance Then sDistance = sCurrentDistance
                        Case SpaceEnum.ToMaximum
                            Dim sCurrentDistance As Single = Math.Abs(oLastRect.Bottom - oRect.Top)
                            If sCurrentDistance > sDistance Then sDistance = sCurrentDistance
                    End Select
                End If
                oLastRect = oRect
            Next
            For Each oItem As cItem In oSortedList.Values
                Dim oRect As RectangleF = oItem.GetBounds
                Select Case oItem.Type
                    Case cIItem.cItemTypeEnum.CrossSection
                        Dim oCrossSection As cItemCrossSection = oItem
                        Dim bMoveBindedObjects As Boolean = oCrossSection.MoveBindedObjects
                        oCrossSection.MoveBindedObjects = False
                        Call oItem.MoveTo(New PointF(oRect.Left, [sTop]))
                        oCrossSection.MoveBindedObjects = bMoveBindedObjects
                    Case Else
                        Call oItem.MoveTo(New PointF(oRect.Left, [sTop]))
                End Select
                [sTop] = [sTop] + oRect.Height + sDistance
            Next
        End Sub

        Public Enum HorizontalAlignmentEnum
            Left = 0
            Center = 1
            Right = 2
        End Enum

        Public Enum VerticalAlignmentEnum
            Top = 0
            Middle = 1
            Bottom = 2
        End Enum

        Public Sub VerticalAlign(Alignment As VerticalAlignmentEnum)
            'qua non gestisco i punti collegati...
            Dim oRect As RectangleF = GetBounds()
            For Each oitem As cItem In oItems
                Dim oItemRect As RectangleF = oitem.GetBounds
                Dim oOffset As SizeF
                Select Case Alignment
                    Case VerticalAlignmentEnum.Top
                        oOffset = New SizeF(0, oRect.Top - oItemRect.Top)
                    Case VerticalAlignmentEnum.Middle
                        oOffset = New SizeF(0, (oRect.Top - oItemRect.Top) + (oRect.Height - oItemRect.Height) / 2)
                    Case VerticalAlignmentEnum.Bottom
                        oOffset = New SizeF(0, oRect.Bottom - oItemRect.Bottom)
                End Select
                Select Case oitem.Type
                    Case cIItem.cItemTypeEnum.CrossSection
                        Dim oCrossSection As cItemCrossSection = oitem
                        Dim bMoveBindedObjects As Boolean = oCrossSection.MoveBindedObjects
                        oCrossSection.MoveBindedObjects = False
                        Call oitem.MoveBy(oOffset)
                        oCrossSection.MoveBindedObjects = bMoveBindedObjects
                    Case Else
                        Call oitem.MoveBy(oOffset)
                End Select
            Next
        End Sub

        Public Sub HorizontalAlign(Alignment As HorizontalAlignmentEnum)
            'qua non gestisco i punti collegati...
            Dim oRect As RectangleF = GetBounds()
            For Each oitem As cItem In oItems
                Dim oItemRect As RectangleF = oitem.GetBounds
                Dim oOffset As SizeF
                Select Case Alignment
                    Case HorizontalAlignmentEnum.Left
                        oOffset = New SizeF(oRect.Left - oItemRect.Left, 0)
                    Case HorizontalAlignmentEnum.Center
                        oOffset = New SizeF((oRect.Left - oItemRect.Left) + (oRect.Width - oItemRect.Width) / 2, 0)
                    Case HorizontalAlignmentEnum.Right
                        oOffset = New SizeF(oRect.Right - oItemRect.Right, 0)
                End Select
                Select Case oitem.Type
                    Case cIItem.cItemTypeEnum.CrossSection
                        Dim oCrossSection As cItemCrossSection = oitem
                        Dim bMoveBindedObjects As Boolean = oCrossSection.MoveBindedObjects
                        oCrossSection.MoveBindedObjects = False
                        Call oitem.MoveBy(oOffset)
                        oCrossSection.MoveBindedObjects = bMoveBindedObjects
                    Case Else
                        Call oitem.MoveBy(oOffset)
                End Select
            Next
        End Sub

        Public Overrides Sub MoveBy(ByVal OffsetX As Single, ByVal OffsetY As Single)
            For Each oitem As cItem In oItems
                Select Case oitem.Type
                    Case cIItem.cItemTypeEnum.CrossSection
                        Dim oCrossSection As cItemCrossSection = oitem
                        Dim bMoveBindedObjects As Boolean = oCrossSection.MoveBindedObjects
                        oCrossSection.MoveBindedObjects = False
                        Call oitem.MoveBy(OffsetX, OffsetY)
                        oCrossSection.MoveBindedObjects = bMoveBindedObjects
                    Case Else
                        Call oitem.MoveBy(OffsetX, OffsetY)
                End Select
            Next
        End Sub

        Public Overrides Sub MoveBy(ByVal Size As System.Drawing.SizeF)
            For Each oPoint As cPoint In MyBase.Design.PointsJoins.RemoveJoined(oItems)
                Call oPoint.MoveBy(Size)
            Next
            'For Each oitem As cItem In oItems
            '    Select Case oitem.Type
            '        Case cIItem.cItemTypeEnum.CrossSection
            '            Dim oCrossSection As cItemCrossSection = oitem
            '            Dim bMoveBindedObjects As Boolean = oCrossSection.MoveBindedObjects
            '            oCrossSection.MoveBindedObjects = False
            '            Call oitem.MoveBy(Size)
            '            oCrossSection.MoveBindedObjects = bMoveBindedObjects
            '        Case Else
            '            Call oitem.MoveBy(Size)
            '    End Select
            'Next
        End Sub

        Public Overrides Sub MoveTo(ByVal X As Single, ByVal Y As Single)
            Dim oRect As RectangleF = GetBounds()
            Dim oOffset As SizeF = New SizeF(X - oRect.X, Y - oRect.Y)
            If Not oOffset.IsEmpty Then
                For Each oPoint As cPoint In MyBase.Design.PointsJoins.RemoveJoined(oItems)
                    Call oPoint.MoveBy(oOffset)
                Next
                'For Each oitem As cItem In oItems
                '    Select Case oitem.Type
                '        Case cIItem.cItemTypeEnum.CrossSection
                '            Dim oCrossSection As cItemCrossSection = oitem
                '            Dim bMoveBindedObjects As Boolean = oCrossSection.MoveBindedObjects
                '            oCrossSection.MoveBindedObjects = False
                '            Call oCrossSection.MoveBy(oOffset)
                '            oCrossSection.MoveBindedObjects = bMoveBindedObjects
                '        Case Else
                '            Call oitem.MoveBy(oOffset)
                '    End Select
                'Next
            End If
        End Sub

        Public Overrides Sub MoveTo(ByVal Point As System.Drawing.PointF)
            Call MoveTo(Point.X, Point.Y)
        End Sub

        Public Overrides Sub Rotate(ByVal Angle As Single)
            Dim oCenter As PointF = GetCenterPoint()
            For Each oPoint As cPoint In MyBase.Design.PointsJoins.RemoveJoined(oItems.Where(Function(item) item.CanBeRotated).ToList)
                Call oPoint.MoveTo(modPaint.RotatePointAt(Angle, oCenter, oPoint.Point))
            Next
        End Sub

        Public Overrides Property ClippingType As cItemClippingTypeEnum
            Get
                If oItems.Count > 0 Then
                    Dim iClippingType As cItemClippingTypeEnum = oItems(0).ClippingType
                    For Each oItem As cItem In oItems
                        If iClippingType <> oItem.ClippingType Then Return cItemClippingTypeEnum.Default
                    Next
                    Return iClippingType
                Else
                    Return cItemClippingTypeEnum.Default
                End If
            End Get
            Set(ByVal value As cItemClippingTypeEnum)
                For Each oItem As cItem In oItems
                    oItem.ClippingType = value
                Next
            End Set
        End Property

        Public Overrides Sub RotateAt(ByVal Center As System.Drawing.PointF, ByVal Angle As Single)
            For Each oPoint As cPoint In MyBase.Design.PointsJoins.RemoveJoined(oItems.Where(Function(item) item.CanBeRotated).ToList)
                Call oPoint.MoveTo(modPaint.RotatePointAt(Angle, Center, oPoint.Point))
            Next
        End Sub

        Public Overrides Function GetCenterPoint() As System.Drawing.PointF
            Dim oBounds As RectangleF = GetBounds()
            Return New PointF(oBounds.Location.X + oBounds.Size.Width / 2, oBounds.Location.Y + oBounds.Size.Height / 2)
        End Function

        Friend Overrides Sub BindSegments()
            For Each oItem As cItem In oItems
                Call oItem.BindSegments()
            Next
        End Sub

        Public Overrides Sub LockSegments()
            For Each oItem As cItem In oItems
                Call oItem.LockSegments()
            Next
        End Sub

        Public Overrides Sub unLockSegments()
            For Each oItem As cItem In oItems
                Call oItem.UnlockSegments()
            Next
        End Sub

        Public Overrides ReadOnly Property CanImportGeneric As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Function FromGeneric(ByVal Item As cItemGeneric, Optional ByVal Clear As Boolean = False) As Boolean
            Return False
        End Function

        Public Function ToArray() As cItem()
            Return oItems.ToArray
        End Function

        Private Function pToClipart(Category As cIItem.cItemCategoryEnum) As cItem
            Dim oPaintOptions As cOptions = MyBase.Survey.Options("_design.plan")
            Dim oOptions As cSVGWriter.SVGOptionsEnum = cSVGWriter.SVGOptionsEnum.Silent
            Dim oSVG As cSVGWriter = modSVG.CreateSVG(oOptions)
            For Each oItem As cItem In oItems
                Call modSVG.AppendItem(oSVG, Nothing, oItem.ToSvgItem(oSVG, oPaintOptions))
            Next
            Select Case Category
                Case cIItem.cItemCategoryEnum.Rock
                    Dim oItemClipart As cItemClipart = DirectCast(MyBase.Design.Layers(LayerTypeEnum.RocksAndConcretion), cLayerRocks).CreateRockFromClipart(Cave, Branch, oSVG.InnerXml, cIItemClipartBase.cClipartDataFormatEnum.SVGData)
                    Call oItemClipart.FixBound(True)
                    Dim oBounds As RectangleF = GetBounds()
                    Dim oCurrentCenter As PointF = modPaint.GetCenterPoint(oBounds)
                    oCurrentCenter.X -= oBounds.Width / 2
                    oCurrentCenter.Y -= oBounds.Height / 2
                    Call oItemClipart.MoveTo(oCurrentCenter)
                    Call oItemClipart.ResizeTo(oBounds.Size)
                    Return oItemClipart
                Case cIItem.cItemCategoryEnum.Concretion
                    Dim oItemClipart As cItemClipart = DirectCast(MyBase.Design.Layers(LayerTypeEnum.RocksAndConcretion), cLayerRocks).CreateConcretionFromClipart(Cave, Branch, oSVG.InnerXml, cIItemClipartBase.cClipartDataFormatEnum.SVGData)
                    Call oItemClipart.FixBound(True)
                    Dim oBounds As RectangleF = GetBounds()
                    Dim oCurrentCenter As PointF = modPaint.GetCenterPoint(oBounds)
                    oCurrentCenter.X -= oBounds.Width / 2
                    oCurrentCenter.Y -= oBounds.Height / 2
                    Call oItemClipart.MoveTo(oCurrentCenter)
                    Call oItemClipart.ResizeTo(oBounds.Size)
                    Return oItemClipart
                Case cIItem.cItemCategoryEnum.Sign
                    Dim oItemSign As cItemSign = DirectCast(MyBase.Design.Layers(LayerTypeEnum.Signs), cLayerSigns).CreateSign(Cave, Branch, oSVG.InnerXml, cIItemClipartBase.cClipartDataFormatEnum.SVGData)
                    Call oItemSign.FixBound(True)
                    Dim oBounds As RectangleF = GetBounds()
                    Dim oCurrentCenter As PointF = modPaint.GetCenterPoint(oBounds)
                    Call oItemSign.MoveTo(oCurrentCenter)
                    Return oItemSign
            End Select
        End Function

        Public Function ToConcretion() As cItemClipart
            Return pToClipart(cIItem.cItemCategoryEnum.Concretion)
        End Function

        Public Function ToSign() As cItemSign
            Return pToClipart(cIItem.cItemCategoryEnum.Sign)
        End Function

        Public Function ToRock() As cItemClipart
            Return pToClipart(cIItem.cItemCategoryEnum.Rock)
        End Function

        Public Function SelfCombine() As cItem
            Dim oCombineItems As List(Of cItem) = New List(Of cItem)
            For Each oCombineItem As cItem In oItems
                Call oCombineItems.Add(oCombineItem)
            Next
            Dim oBaseItem As cItem = oCombineItems.First
            For Each oCombineItem As cItem In oCombineItems
                If Not oCombineItem Is oBaseItem Then
                    Call oBaseItem.Combine(oCombineItem)
                End If
            Next
            Return oBaseItem
        End Function

        Public Function IsSelfCombinable() As Boolean
            Dim bIsCombinable As Boolean = True
            Dim oBaseItem As cItem = oItems.First
            For Each oItem As cItem In oItems
                If Not oItem Is oBaseItem Then
                    bIsCombinable = bIsCombinable And oBaseItem.IsCombinable(oItem)
                    If Not bIsCombinable Then Exit For
                End If
            Next
            Return bIsCombinable
        End Function

        Public Function IsConvertibleToConcretion() As Boolean
            Return oItems.All(Function(oitem) oitem.Category = cIItem.cItemCategoryEnum.Concretion AndAlso (oitem.Type = cIItem.cItemTypeEnum.FreeHandArea OrElse oitem.Type = cIItem.cItemTypeEnum.FreeHandLine))
        End Function

        Public Function IsConvertibleToRock() As Boolean
            Return oItems.All(Function(oitem) oitem.Category = cIItem.cItemCategoryEnum.Rock AndAlso (oitem.Type = cIItem.cItemTypeEnum.FreeHandArea OrElse oitem.Type = cIItem.cItemTypeEnum.FreeHandLine))
        End Function

        Public Function IsConvertibleToSign() As Boolean
            Return oItems.All(Function(oitem) oitem.Category = cIItem.cItemCategoryEnum.Sign AndAlso (oitem.Type = cIItem.cItemTypeEnum.FreeHandArea OrElse oitem.Type = cIItem.cItemTypeEnum.FreeHandLine))
        End Function

        Public Function ToGroup() As cItemGroup
            Dim oItemGroup As cItemGroup = New cItemGroup(MyBase.Survey, MyBase.Design, MyBase.Layer, MyBase.Category)
            Call oItemGroup.AddRange(oItems)
            Call MyBase.Layer.Items.Add(oItemGroup)
            Return oItemGroup
        End Function

        Private Sub oDataProperties_OnChange(Sender As cDataProperties, Args As cDataProperties.cDataPropertiesEventArgs) Handles oDataProperties.OnChange
            For Each oItem As cItem In oItems
                Call oItem.DataProperties.SetValue(Args.Name, Args.Value)
            Next
        End Sub

        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Public Function GetEnumerator() As IEnumerator(Of cItem) Implements IEnumerable(Of cItem).GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace
