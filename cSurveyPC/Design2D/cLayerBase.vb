Imports System.Xml
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design.Layers
    Public Class cLayerBase
        Inherits cLayer

        Private oDesign As cDesign

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal File As Storage.cFile, ByVal Layer As XmlElement)
            MyBase.new(Survey, Design, File, Layer)
            oDesign = Design
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Name As String)
            MyBase.new(Survey, Design, Name, cLayers.LayerTypeEnum.Base)
            odesign = Design
        End Sub

        Public Function CreateImage(ByVal Cave As String, ByVal Branch As String, ByVal Image As Image) As cItemImage
            Dim oItem As cItemImage = MyBase.CreateItem(cIItem.cItemTypeEnum.Image, cIItem.cItemCategoryEnum.Image, Image)
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Public Function CreateSketch(ByVal Cave As String, ByVal Branch As String, ByVal Image As Image) As cItemSketch
            Dim oItem As cItemSketch = MyBase.CreateItem(cIItem.cItemTypeEnum.Sketch, cIItem.cItemCategoryEnum.Sketch, Image)
            Call oItem.SetCave(Cave, Branch)
            Return oItem
        End Function

        Friend Overrides Function GetAllVisibleItems(PaintOptions As cOptions, ByVal CurrentCave As String, ByVal CurrentBranch As String) As List(Of cItem)
            Dim oList As List(Of cItem) = New List(Of cItem)
            For Each oItem As cItem In MyBase.GetAllVisibleItems(PaintOptions, CurrentCave, CurrentBranch)
                Select Case oItem.Type
                    Case cIItem.cItemTypeEnum.Sketch
                        If PaintOptions.DrawSketches Then
                            Call oList.Add(oItem)
                        End If
                    Case cIItem.cItemTypeEnum.Image
                        If PaintOptions.DrawImages Then
                            Call oList.Add(oItem)
                        End If
                    Case Else
                        Call oList.Add(oItem)
                End Select
            Next
            Return oList
        End Function

        Friend Overrides Function GetAllVisibleItems(PaintOptions As cOptions) As List(Of cItem)
            Dim oList As List(Of cItem) = New List(Of cItem)
            For Each oItem As cItem In MyBase.GetAllVisibleItems(PaintOptions)
                Select Case oItem.Type
                    Case cIItem.cItemTypeEnum.Sketch
                        If PaintOptions.DrawSketches Then
                            Call oList.Add(oItem)
                        End If
                    Case cIItem.cItemTypeEnum.Image
                        If PaintOptions.DrawImages Then
                            Call oList.Add(oItem)
                        End If
                    Case Else
                        Call oList.Add(oItem)
                End Select
            Next
            Return oList
        End Function

        Friend Overrides Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Clipping As cClippingRegions, ByVal CurrentCave As String, ByVal CurrentBranch As String)
            'If PaintOptions.DrawDesign Then
            '    If (PaintOptions.IsDesign And Not MyBase.HiddenInDesign) Or (PaintOptions.IsPreview) Or (PaintOptions.IsViewer) Then
            '        Dim oCurrentItem As cItem = oDesign.Tool.CurrentItem
            '        For Each oItem As cItem In MyBase.Items
            '            If modDesign.GetIfItemMustBeDrawedByCaveAndBranch(PaintOptions, oItem, CurrentCave, CurrentBranch) And oItem.IsVisible(PaintOptions) Then
            '                Dim oBaseMatrix As Matrix = Graphics.Transform
            '                If Not PaintOptions.IsDesign And PaintOptions.DrawTranslation Then
            '                    Dim oTranslationMatrix As Matrix = oBaseMatrix.Clone
            '                    Dim oTranslation As SizeF = oDesign.GetItemTranslation(oItem)
            '                    If Not oTranslation.IsEmpty Then
            '                        oTranslationMatrix.Translate(oTranslation.Width, oTranslation.Height, Drawing2D.MatrixOrder.Prepend)
            '                        Graphics.Transform = oTranslationMatrix
            '                    End If
            '                    Call oTranslationMatrix.Dispose()
            '                End If
            '                If oItem.Type = cIItem.cItemTypeEnum.Image Or oItem.Type = cIItem.cItemTypeEnum.Sketch Then
            '                    If Graphics.VisibleClipBounds.IntersectsWith(oItem.GetBounds) Or oItem.IsInvalidated(PaintOptions) Or PaintOptions.IsPreview Or oItem Is oCurrentItem Then
            '                        Call oItem.Paint(Graphics, PaintOptions, Options, cItem.SelectionModeEnum.None)
            '                    End If
            '                Else
            '                    If Graphics.VisibleClipBounds.IntersectsWith(oItem.GetBounds) Or oItem.IsInvalidated(PaintOptions) Or PaintOptions.IsPreview Or oItem Is oCurrentItem Then
            '                        Call oItem.Paint(Graphics, PaintOptions, Options, cItem.SelectionModeEnum.None)
            '                    End If
            '                End If
            '                Graphics.Transform = oBaseMatrix
            '                Call oBaseMatrix.Dispose()
            '            End If
            '        Next
            '    End If
            'End If

            If PaintOptions.DrawDesign Then
                'If (PaintOptions.IsDesign And Not MyBase.HiddenInDesign) Or PaintOptions.IsPreview Or PaintOptions.IsViewer Then
                If (PaintOptions.IsDesign And Not MyBase.HiddenInDesign) Or ((PaintOptions.IsPreview Or PaintOptions.IsViewer) And Not MyBase.HiddenInPreview) Then
                    Dim oVisibleBounds As RectangleF
                    Dim oBaseVisibleBounds As RectangleF = Graphics.VisibleClipBounds
                    Dim bTraslation As Boolean = Not PaintOptions.IsDesign And PaintOptions.DrawTranslation
                    Dim iItemIndex As Integer = 0
                    Dim oBaseMatrix As Matrix = Graphics.Transform
                    Dim oLastTranslationMatrix As Matrix = oBaseMatrix

                    Dim oCurrentItem As cItem
                    Dim bCurrentItem As Boolean
                    Dim bCurrentItemIsInEdit As Boolean
                    If PaintOptions.IsDesign Then
                        oCurrentItem = oDesign.Tool.CurrentItem
                        bCurrentItemIsInEdit = oDesign.Tool.IsInEdit Or oDesign.Tool.IsInPointEdit Or oDesign.Tool.Started
                    End If

                    For Each oItem As cItem In GetAllVisibleItems(PaintOptions)
                        iItemIndex += 1
                        If (Not PaintOptions.IsDesign And Not oItem.HiddenInPreview) Or (PaintOptions.IsDesign And Not oItem.HiddenInDesign And Not oItem.FilteredInDesign) Then
                            If modDesign.GetIfItemMustBeDrawedByCaveAndBranch(PaintOptions, oItem, CurrentCave, CurrentBranch) Then
                                Dim iSelectionMode As cItem.SelectionModeEnum
                                If PaintOptions.IsDesign Then
                                    If TypeOf oCurrentItem Is cItemItems Then
                                        If DirectCast(oCurrentItem, cItemItems).Contains(oItem) Then
                                            iSelectionMode = cItem.SelectionModeEnum.Selected
                                            bCurrentItem = True
                                        Else
                                            iSelectionMode = cItem.SelectionModeEnum.None
                                            bCurrentItem = False
                                        End If
                                    Else
                                        If oItem Is oCurrentItem Then
                                            If bCurrentItemIsInEdit Then
                                                iSelectionMode = cItem.SelectionModeEnum.InEdit
                                            Else
                                                iSelectionMode = cItem.SelectionModeEnum.Selected
                                            End If
                                            bCurrentItem = True
                                        Else
                                            iSelectionMode = cItem.SelectionModeEnum.None
                                            bCurrentItem = False
                                        End If
                                    End If
                                End If

                                oVisibleBounds = oBaseVisibleBounds
                                If bTraslation Then
                                    Dim oTranslation As PointF = oDesign.GetItemTranslation(oItem)

                                    If oTranslation.IsEmpty Then
                                        Dim oTranslationMatrix As Matrix = oBaseMatrix
                                        If Not oLastTranslationMatrix Is oTranslationMatrix Then
                                            Graphics.Transform = oBaseMatrix
                                            oLastTranslationMatrix = oTranslationMatrix
                                        End If
                                    Else
                                        Dim oTranslationMatrix As Matrix = oBaseMatrix.Clone
                                        Call oTranslationMatrix.Translate(oTranslation.X, oTranslation.Y, Drawing2D.MatrixOrder.Prepend)
                                        If Not oLastTranslationMatrix Is oTranslationMatrix Then
                                            Graphics.Transform = oTranslationMatrix
                                            oLastTranslationMatrix = oTranslationMatrix
                                        End If
                                        Call oVisibleBounds.Offset(-oTranslation.X, -oTranslation.Y)
                                    End If
                                End If
                                If (oItem.Type = cIItem.cItemTypeEnum.Image) Then
                                    If PaintOptions.DrawImages Then
                                        If Graphics.VisibleClipBounds.IntersectsWith(oItem.GetBounds) Or oItem.IsInvalidated(PaintOptions) Or PaintOptions.IsPreview Or bCurrentItem Then
                                            Call oItem.Paint(Graphics, PaintOptions, Options, cItem.SelectionModeEnum.None)
                                        End If
                                    End If
                                ElseIf (oItem.Type = cIItem.cItemTypeEnum.Sketch) Then
                                    If PaintOptions.DrawSketches Then
                                        If Graphics.VisibleClipBounds.IntersectsWith(oItem.GetBounds) Or oItem.IsInvalidated(PaintOptions) Or PaintOptions.IsPreview Or bCurrentItem Then
                                            Call oItem.Paint(Graphics, PaintOptions, Options, cItem.SelectionModeEnum.None)
                                        End If
                                    End If
                                Else
                                    If Graphics.VisibleClipBounds.IntersectsWith(oItem.GetBounds) Or oItem.IsInvalidated(PaintOptions) Or PaintOptions.IsPreview Or bCurrentItem Then
                                        Call oItem.Paint(Graphics, PaintOptions, Options, cItem.SelectionModeEnum.None)
                                    End If
                                End If
                            End If
                        End If
                    Next
                    Graphics.Transform = oBaseMatrix
                    Call oBaseMatrix.Dispose()
                End If
            End If
        End Sub
    End Class
End Namespace
