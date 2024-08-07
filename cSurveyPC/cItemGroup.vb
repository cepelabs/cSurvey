﻿Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace cSurvey.Design.Items
    Public Class cItemGroup
        Inherits cItem
        Implements IEnumerable(Of cItem)

        Private oItems As cItems

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

        Public Function First() As cItem
            Return oItems.First
        End Function

        Public Function Last() As cItem
            Return oItems.Last
        End Function

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
                For Each oItem As cItem In oItems
                    If Not oItem.HaveTransparency Then
                        Return False
                    End If
                Next
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeConverted As Boolean
            Get
                For Each oItem As cItem In oItems
                    If Not oItem.CanBeConverted Then
                        Return False
                    End If
                Next
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
            Call MyBase.Layer.Items.Remove(Item)
            Call oItems.Add(Item)
        End Sub

        Public Sub AddRange(ByVal Items As IEnumerable(Of cItem))
            For Each oItem As cItem In Items
                Call MyBase.Layer.Items.Remove(oItem)
            Next
            Call oItems.AddRange(Items)
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
                Call oItems.Remove(Index)
            End If
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal Index As Integer) As cItem
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
            Threading.Tasks.Parallel.ForEach(oItems, Sub(oItem As cItem)
                                                         Call oItem.Render(Graphics, PaintOptions, Options, Selected)
                                                     End Sub)
        End Sub

        Friend Overrides Sub Paint(ByVal Graphics As System.Drawing.Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            For Each oItem As cItem In oItems
                Call oItem.Paint(Graphics, PaintOptions, Options, Selected)
            Next
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.Group, Category)
            oItems = New cItems(Survey, Design, Layer)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As cFile, ByVal item As XmlElement)
            Call MyBase.New(Survey, Design, Layer, File, item)
            oItems = New cItems(Survey, Design, Layer, File, item.Item("items"))
        End Sub

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXMLItem As XmlElement = MyBase.SaveTo(File, Document, Parent, Options)
            Call oItems.SaveTo(File, Document, oXMLItem, Options)
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
            Threading.Tasks.Parallel.ForEach(oItems, Sub(oItem)
                                                         Call oItem.SetCave(Cave, Branch, BindSegment)
                                                     End Sub)
        End Sub

        Public Overrides Sub SetBindDesignType(ByVal BindDesignType As BindDesignTypeEnum, Optional CrossSection As cDesignCrossSection = Nothing, Optional ByVal BindSegment As Boolean = True)
            Threading.Tasks.Parallel.ForEach(oItems, Sub(oItem)
                                                         Call oItem.SetBindDesignType(BindDesignType, CrossSection, BindSegment)
                                                     End Sub)
        End Sub

        Friend Overrides Sub RenameCave(ByVal Cave As String, ByVal Branch As String)
            Threading.Tasks.Parallel.ForEach(oItems, Sub(oItem)
                                                         Call oItem.RenameCave(Cave, Branch)
                                                     End Sub)
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

        Friend Overrides Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
            Dim oSVGGroup As XmlElement = modSVG.CreateGroup(SVG, "_items")
            For Each oItem In oItems
                Dim oSVGItem As XmlElement = oItem.ToSvgItem(SVG, PaintOptions, Options)
                Call modSVG.AppendItem(SVG, oSVGGroup, oSVGItem)
            Next
            Return oSVGGroup
        End Function

        Friend Overrides Function ToSvg(ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.SVGOptionsEnum) As XmlDocument
            Dim oSVG As XmlDocument = modSVG.CreateSVG
            Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions, Options))
            Return oSVG
        End Function

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
            For Each oPoint As cPoint In MyBase.Design.PointsJoins.RemoveJoined(oItems.ToList)
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
            '            Call oitem.MoveBy(Size)
            '    End Select
        End Sub

        Public Overrides Sub MoveTo(ByVal X As Single, ByVal Y As Single)
            Dim oRect As RectangleF = GetBounds()
            Dim oOffset As SizeF = New SizeF(X - oRect.X, Y - oRect.Y)
            For Each oPoint As cPoint In MyBase.Design.PointsJoins.RemoveJoined(oItems.ToList)
                Call oPoint.MoveBy(oOffset)
            Next
            '    Select Case oitem.Type
            '        Case cIItem.cItemTypeEnum.CrossSection
            '            Dim bMoveBindedObjects As Boolean = oCrossSection.MoveBindedObjects
            '            oCrossSection.MoveBindedObjects = False
            '            oCrossSection.MoveBindedObjects = bMoveBindedObjects
            '        Case Else
            '            Call oitem.MoveBy(oOffset)
            '    End Select
            'Next
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

        'Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        '    Return oItems.GetEnumerator
        'End Function

        Public Function ToArray() As cItem()
            Return oItems.ToArray
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator(Of cItem) Implements IEnumerable(Of cItem).GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace
