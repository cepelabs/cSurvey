Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Design.Options
Imports cSurveyPC.cSurvey.Editor

Namespace cSurvey.Design
    Public MustInherit Class cDesign
        Implements cIDesign

        Public Enum cDesignPaintOptionsEnum
            Design = &H0
            Preview = &H16
        End Enum

        Public Enum UnselectedLevelDrawingModeEnum
            Wireframe = 0
            OnlyCaveBorders = 1
            None = 2
        End Enum

        Private oSurvey As cSurvey
        Private WithEvents oLayers As cLayers

        Public MustOverride ReadOnly Property Type As cIDesign.cDesignTypeEnum Implements cIDesign.Type
        Friend MustOverride Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
        Friend MustOverride Function ToSvg(ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.SVGOptionsEnum, Size As SizeF, PageBox As RectangleF, Unit As SizeUnit, ByVal ViewBox As RectangleF) As XmlDocument

        Private oPointsJoins As cPointsJoins

        Private oCaches As cDrawCaches

        Friend Class cMaskPaths
            Implements IDisposable
            Implements IEnumerable

            Private oMaskPaths As Dictionary(Of String, List(Of cMaskPath))

            Public Sub New()
                oMaskPaths = New Dictionary(Of String, List(Of cMaskPath))
            End Sub

            Public ReadOnly Property Keys As Dictionary(Of String, List(Of cMaskPath)).KeyCollection
                Get
                    Return oMaskPaths.Keys
                End Get
            End Property

            Public ReadOnly Property Count As Integer
                Get
                    Return oMaskPaths.Count
                End Get
            End Property

            Default Public ReadOnly Property Item(Key As String) As List(Of cMaskPath)
                Get
                    Return oMaskPaths(Key)
                End Get
            End Property

            Public Function GetPaths(Key As String) As List(Of cMaskPath)
                Return oMaskPaths(Key)
            End Function

            Public Function Contains(Key As String) As Boolean
                Return oMaskPaths.ContainsKey(Key)
            End Function

            Public Sub AppendPath(Key As String, Path As GraphicsPath, MergeMode As cIItemMergeableArea.MergeModeEnum)
                If oMaskPaths.ContainsKey(Key) Then
                    Call oMaskPaths(Key).Add(New cMaskPath(Path, MergeMode))
                Else
                    Dim oPaths As List(Of cMaskPath) = New List(Of cMaskPath)
                    Call oPaths.Add(New cMaskPath(Path, MergeMode))
                    Call oMaskPaths.Add(Key, oPaths)
                End If
            End Sub

            Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
                Return oMaskPaths.Values.GetEnumerator
            End Function

#Region "IDisposable Support"
            Private disposedValue As Boolean ' To detect redundant calls

            ' IDisposable
            Protected Overridable Sub Dispose(disposing As Boolean)
                If Not disposedValue Then
                    If disposing Then
                        For Each oItems As List(Of cMaskPath) In oMaskPaths.Values
                            For Each oItem As cMaskPath In oItems
                                Call oItem.Dispose()
                            Next
                        Next
                        Call oMaskPaths.Clear()
                    End If
                End If
                disposedValue = True
            End Sub

            ' This code added by Visual Basic to correctly implement the disposable pattern.
            Public Sub Dispose() Implements IDisposable.Dispose
                Dispose(True)
            End Sub
#End Region
        End Class

        Friend Class cMaskPath
            Implements IDisposable

            Private oPath As GraphicsPath
            Private iMergeMode As cIItemMergeableArea.MergeModeEnum

            Public ReadOnly Property Path As GraphicsPath
                Get
                    Return oPath
                End Get
            End Property

            Public ReadOnly Property MergeMode As cIItemMergeableArea.MergeModeEnum
                Get
                    Return iMergeMode
                End Get
            End Property

            Public Sub New(Path As GraphicsPath, MergeMode As cIItemMergeableArea.MergeModeEnum)
                oPath = Path
                iMergeMode = MergeMode
            End Sub

#Region "IDisposable Support"
            Private disposedValue As Boolean ' To detect redundant calls

            ' IDisposable
            Protected Overridable Sub Dispose(disposing As Boolean)
                If Not disposedValue Then
                    If disposing Then
                        If Not IsNothing(oPath) Then
                            oPath.Dispose()
                            oPath = Nothing
                        End If
                    End If
                End If
                disposedValue = True
            End Sub

            ' This code added by Visual Basic to correctly implement the disposable pattern.
            Public Sub Dispose() Implements IDisposable.Dispose
                Dispose(True)
            End Sub
#End Region
        End Class

        Friend Overridable Sub Redraw(Optional Options As cOptionsCenterline = Nothing)
            Call oCaches.Invalidate(Options)
            For Each oLayer As cLayer In oLayers
                For Each oItem As cItem In oLayer.Items
                    Call oItem.Caches.Invalidate(Options)
                Next
            Next
        End Sub

        Public Overridable ReadOnly Property Layers() As cLayers
            Get
                Return oLayers
            End Get
        End Property

        Public Overridable Function IsEmpty() As Boolean
            For Each oLayer As cLayer In oLayers
                If oLayer.Items.Count > 0 Then Return False
            Next
            Return True
        End Function

        Public Function GetItemsBounds(ByVal Items As List(Of cItem)) As RectangleF
            Dim oRect As RectangleF = New RectangleF
            For Each oItem As cItem In Items
                If oRect.IsEmpty Then
                    oRect = oItem.GetBounds
                Else
                    oRect = RectangleF.Union(oRect, oItem.GetBounds)
                End If
            Next
            Return oRect
        End Function

        Public Function HasItems() As Boolean
            For Each oLayer As cLayer In oLayers
                If oLayer.Items.Count > 0 Then
                    Return True
                End If
            Next
            Return False
        End Function

        Public Function HasBindedItems() As Boolean
            Dim oItems As List(Of cItem) = New List(Of cItem)
            For Each oLayer As cLayer In oLayers
                For Each oItem As cItem In oLayer.GetAllItems
                    For Each oPoint As cPoint In oItem.Points
                        If Not oPoint.BindedSegment Is Nothing Then
                            Return True
                        End If
                    Next
                Next
            Next
            Return False
        End Function

        Public Function GetBindedItems(Segment As cISegment) As List(Of cItem)
            Dim oItems As List(Of cItem) = New List(Of cItem)
            If Not Segment Is Nothing Then
                For Each oLayer As cLayer In oLayers
                    For Each oItem As cItem In oLayer.GetAllItems
                        For Each oPoint As cPoint In oItem.Points
                            If oPoint.BindedSegment Is Segment Then
                                Call oItems.Add(oItem)
                                Exit For
                            End If
                        Next
                    Next
                Next
            End If
            Return oItems
        End Function

        Friend Function GetItemsByRectangle(ByVal Rectangle As RectangleF, ByVal PaintOptions As cOptions, ByVal CurrentCave As String, ByVal CurrentBranch As String) As List(Of cItem)
            Dim oItems As List(Of cItem) = New List(Of cItem)
            For Each oLayer As cLayer In oLayers
                If Not oLayer.HiddenInDesign Then
                    For Each oItem As cItem In oLayer.GetAllItems
                        If GetIfItemMustBeDrawedByHiddenFlag(PaintOptions, oItem) Then
                            If GetIfItemMustBeDrawedByCaveAndBranch(PaintOptions, oItem, CurrentCave, CurrentBranch) Then
                                If Rectangle.Contains(oItem.GetBounds) Then
                                    Call oItems.Add(oItem)
                                End If
                            End If
                        End If
                    Next
                End If
            Next
            Return oItems
        End Function

        Friend Function GetItemsByRectangle(ByVal Rectangle As RectangleF) As List(Of cItem)
            Dim oItems As List(Of cItem) = New List(Of cItem)
            For Each oLayer As cLayer In oLayers
                If Not oLayer.HiddenInDesign Then
                    For Each oItem As cItem In oLayer.GetAllItems
                        If Not (oItem.HiddenInDesign) And Not oItem.FilteredInDesign Then
                            If Rectangle.Contains(oItem.GetBounds) Then
                                Call oItems.Add(oItem)
                            End If
                        End If
                    Next
                End If
            Next
            Return oItems
        End Function

        Friend Function GetAllVisibleItems(PaintOptions As cOptions, ByVal CurrentCave As String, ByVal CurrentBranch As String) As List(Of cItem)
            Dim oAllItems As List(Of cItem) = New List(Of cItem)
            For Each oLayer As cLayer In oLayers
                Call oAllItems.AddRange(oLayer.GetAllVisibleItems(PaintOptions, CurrentCave, CurrentBranch))
            Next
            Return oAllItems
        End Function

        Friend Function GetAllDesignVisibleItems(PaintOptions As cOptions, ByVal CurrentCave As String, ByVal CurrentBranch As String) As List(Of cItem)
            Dim oAllItems As List(Of cItem) = New List(Of cItem)
            For Each oLayer As cLayer In oLayers
                Call oAllItems.AddRange(oLayer.GetAllDesignVisibleItems(PaintOptions, CurrentCave, CurrentBranch))
            Next
            Return oAllItems
        End Function

        Friend Function GetAllVisibleItems(PaintOptions As cOptions) As List(Of cItem)
            Dim oAllItems As List(Of cItem) = New List(Of cItem)
            For Each oLayer As cLayer In oLayers
                Call oAllItems.AddRange(oLayer.GetAllVisibleItems(PaintOptions))
            Next
            Return oAllItems
        End Function

        Public ReadOnly Property Survey() As cSurvey Implements cIDesign.Survey
            Get
                Return oSurvey
            End Get
        End Property

        Friend Function GetAllDesignVisibleItems(PaintOptions As cOptions) As List(Of cItem)
            Dim oAllItems As List(Of cItem) = New List(Of cItem)
            For Each oLayer As cLayer In oLayers
                Call oAllItems.AddRange(oLayer.GetAllDesignVisibleItems(PaintOptions))
            Next
            Return oAllItems
        End Function

        Friend Function GetAllItems(Type As cIItem.cItemTypeEnum) As List(Of cItem)
            Dim oAllItems As List(Of cItem) = New List(Of cItem)
            For Each oLayer As cLayer In oLayers
                Call oAllItems.AddRange(oLayer.GetAllItems(Type))
            Next
            Return oAllItems
        End Function

        Friend Function GetAllItems() As List(Of cItem)
            Dim oAllItems As List(Of cItem) = New List(Of cItem)
            For Each oLayer As cLayer In oLayers
                Call oAllItems.AddRange(oLayer.GetAllItems)
            Next
            Return oAllItems
        End Function

        <Flags> Friend Enum ClippingPathsOptions
            All = 0
            OnlyVisiblePen = 1
            IncludeCrossSections = 2
        End Enum

        Friend Function GetCaveClippingPaths(Graphics As Graphics, PaintOptions As cOptions, Options As ClippingPathsOptions) As cClippingPaths
            Dim oClippingpaths As cClippingPaths = New cClippingPaths(oSurvey)
            Dim oLayer As Layers.cLayerBorders = oLayers.Item(cLayers.LayerTypeEnum.Borders)

            Dim bInclude As Boolean
            Dim bIncludeCrossSections As Boolean = (Options And ClippingPathsOptions.IncludeCrossSections) = ClippingPathsOptions.IncludeCrossSections
            Dim oAddItems As List(Of Design.Items.cItemInvertedFreeHandArea) = New List(Of Design.Items.cItemInvertedFreeHandArea)
            Dim oSubtractItems As List(Of Design.Items.cItemInvertedFreeHandArea) = New List(Of Design.Items.cItemInvertedFreeHandArea)
            For Each oItem As cItem In oLayer.GetAllVisibleItems(PaintOptions)
                If oItem.Type = cIItem.cItemTypeEnum.InvertedFreeHandArea Then
                    If oItem.BindDesignType = cItem.BindDesignTypeEnum.CrossSections Then
                        bInclude = bIncludeCrossSections
                    Else
                        bInclude = True
                    End If
                    If bInclude Then
                        Dim oCaveBorder As Design.Items.cItemInvertedFreeHandArea = oItem
                        If oCaveBorder.MergeMode = Items.cIItemMergeableArea.MergeModeEnum.Add Then
                            Call oAddItems.Add(oCaveBorder)
                        Else
                            Call oSubtractItems.Add(oCaveBorder)
                        End If
                    End If
                End If
            Next

            Dim oItems As List(Of Design.Items.cItemInvertedFreeHandArea) = oAddItems
            Call oItems.AddRange(oSubtractItems)

            Dim iAdvancedClippingMode As cIOptionsPreview.AdvancedClippingModeEnum
            If PaintOptions.IsPreview Then
                iAdvancedClippingMode = DirectCast(PaintOptions, cIOptionsPreview).AdvancedClippingMode
            Else
                iAdvancedClippingMode = cIOptionsPreview.AdvancedClippingModeEnum.Standard
            End If

            For Each oCaveBorder As Design.Items.cItemInvertedFreeHandArea In oItems
                Call oCaveBorder.Render(Graphics, PaintOptions, cItem.PaintOptionsEnum.Solid, False)
                Using oBorderPath As GraphicsPath = New GraphicsPath
                    Dim oCache As cDrawCache = oCaveBorder.Caches(PaintOptions)
                    If oCache.Count > 0 Then
                        For Each oCacheItem As cDrawCacheItem In oCache
                            'If oCacheItem.IsWireframeOutlined AndAlso oCacheItem.Path.PointCount > 1 Then
                            If oCacheItem.Path.PointCount > 1 Then
                                If (Options And ClippingPathsOptions.OnlyVisiblePen) = ClippingPathsOptions.OnlyVisiblePen Then
                                    If oCacheItem.IsWireframeOutlined AndAlso oCacheItem.Pen IsNot Nothing Then
                                        Call oBorderPath.AddPath(oCacheItem.Path, True)
                                    End If
                                Else
                                    Call oBorderPath.AddPath(oCacheItem.Path, True)
                                End If
                            End If
                        Next
                        Call oBorderPath.CloseAllFigures()
                        If oBorderPath.PointCount > 1 Then
                            If oCaveBorder.MergeMode = Items.cIItemMergeableArea.MergeModeEnum.Add Then
                                If iAdvancedClippingMode = cIOptionsPreview.AdvancedClippingModeEnum.HierarchicClipping Then
                                    Call oClippingpaths.Combine(oCaveBorder.Cave, "", oBorderPath)
                                    Dim sPathParts() As String = oCaveBorder.Branch.Split("\")
                                    Dim sBranch As String = ""
                                    For Each sPathPart In sPathParts
                                        If sBranch <> "" Then sBranch &= "\"
                                        sBranch &= sPathPart
                                        Call oClippingpaths.Combine(oCaveBorder.Cave, sBranch, oBorderPath)
                                    Next
                                Else
                                    Call oClippingpaths.Combine(oCaveBorder.Cave, oCaveBorder.Branch, oBorderPath)
                                End If
                            Else
                                If iAdvancedClippingMode = cIOptionsPreview.AdvancedClippingModeEnum.HierarchicClipping Then
                                    Call oClippingpaths.Exclude(oCaveBorder.Cave, "", oBorderPath)
                                    Dim sPathParts() As String = oCaveBorder.Branch.Split("\")
                                    Dim sBranch As String = ""
                                    For Each sPathPart In sPathParts
                                        If sBranch <> "" Then sBranch &= "\"
                                        sBranch &= sPathPart
                                        Call oClippingpaths.Exclude(oCaveBorder.Cave, sBranch, oBorderPath)
                                    Next
                                Else
                                    Call oClippingpaths.Exclude(oCaveBorder.Cave, oCaveBorder.Branch, oBorderPath)
                                End If
                            End If
                        End If
                    End If
                End Using
            Next
            Return oClippingpaths
        End Function

        Friend Function GetCaveClippingRegions(Graphics As Graphics, PaintOptions As cOptions) As cClippingRegions
            Dim oClippingRegions As cClippingRegions = New cClippingRegions(oSurvey)
            Dim oLayer As Layers.cLayerBorders = oLayers.Item(cLayers.LayerTypeEnum.Borders)

            Dim oAddItems As List(Of Design.Items.cItemInvertedFreeHandArea) = New List(Of Design.Items.cItemInvertedFreeHandArea)
            Dim oSubtractItems As List(Of Design.Items.cItemInvertedFreeHandArea) = New List(Of Design.Items.cItemInvertedFreeHandArea)
            For Each oItem As cItem In oLayer.GetAllVisibleItems(PaintOptions)
                If oItem.Type = cIItem.cItemTypeEnum.InvertedFreeHandArea Then
                    Dim oCaveBorder As Design.Items.cItemInvertedFreeHandArea = oItem
                    If oCaveBorder.MergeMode = Items.cIItemMergeableArea.MergeModeEnum.Add Then
                        Call oAddItems.Add(oCaveBorder)
                    Else
                        Call oSubtractItems.Add(oCaveBorder)
                    End If
                End If
            Next

            Dim oItems As List(Of Design.Items.cItemInvertedFreeHandArea) = oAddItems
            Call oItems.AddRange(oSubtractItems)

            Dim iAdvancedClippingMode As cIOptionsPreview.AdvancedClippingModeEnum
            If PaintOptions.IsPreview Then
                iAdvancedClippingMode = DirectCast(PaintOptions, cIOptionsPreview).AdvancedClippingMode
            Else
                iAdvancedClippingMode = cIOptionsPreview.AdvancedClippingModeEnum.Standard
            End If

            For Each oCaveBorder As Design.Items.cItemInvertedFreeHandArea In oItems
                Call oCaveBorder.Render(Graphics, PaintOptions, cItem.PaintOptionsEnum.Solid, False)
                Using oBorderPath As GraphicsPath = New GraphicsPath
                    Dim oCache As cDrawCache = oCaveBorder.Caches(PaintOptions)
                    If oCache.Count > 0 Then
                        For Each oCacheItem As cDrawCacheItem In oCache
                            If oCacheItem.IsWireframeOutlined AndAlso oCacheItem.Path.PointCount > 1 Then
                                Call oBorderPath.AddPath(oCacheItem.Path, True)
                            End If
                        Next
                        Call oBorderPath.CloseAllFigures()
                        If oBorderPath.PointCount > 1 Then
                            If oCaveBorder.MergeMode = Items.cIItemMergeableArea.MergeModeEnum.Add Then
                                If iAdvancedClippingMode = cIOptionsPreview.AdvancedClippingModeEnum.HierarchicClipping Then
                                    Call oClippingRegions.Combine(oCaveBorder.Cave, "", oBorderPath)
                                    Dim sPathParts() As String = oCaveBorder.Branch.Split("\")
                                    Dim sBranch As String = ""
                                    For Each sPathPart In sPathParts
                                        If sBranch <> "" Then sBranch &= "\"
                                        sBranch &= sPathPart
                                        Call oClippingRegions.Combine(oCaveBorder.Cave, sBranch, oBorderPath)
                                    Next
                                Else
                                    Call oClippingRegions.Combine(oCaveBorder.Cave, oCaveBorder.Branch, oBorderPath)
                                End If
                            Else
                                If iAdvancedClippingMode = cIOptionsPreview.AdvancedClippingModeEnum.HierarchicClipping Then
                                    Call oClippingRegions.Exclude(oCaveBorder.Cave, "", oBorderPath)
                                    Dim sPathParts() As String = oCaveBorder.Branch.Split("\")
                                    Dim sBranch As String = ""
                                    For Each sPathPart In sPathParts
                                        If sBranch <> "" Then sBranch &= "\"
                                        sBranch &= sPathPart
                                        Call oClippingRegions.Exclude(oCaveBorder.Cave, sBranch, oBorderPath)
                                    Next
                                Else
                                    Call oClippingRegions.Exclude(oCaveBorder.Cave, oCaveBorder.Branch, oBorderPath)
                                End If
                            End If
                        End If
                    End If
                End Using
            Next
            Return oClippingRegions
        End Function

        Friend Sub RemoveItem(ByVal Item As cItem)
            For Each oLayer As cLayer In oLayers
                If oLayer.Items.Contains(Item) Then
                    Call oLayer.Items.Remove(Item)
                    Exit For
                End If
            Next
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oCaches = New cDrawCaches
            oLayers = New cLayers(oSurvey, Me)
            oPointsJoins = New cPointsJoins(oSurvey, Me)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal Design As XmlElement)
            oSurvey = Survey
            oCaches = New cDrawCaches
            If modXML.ChildElementExist(Design, "layers") Then
                oLayers = New cLayers(oSurvey, Me, File, Design.Item("layers"))
                If modXML.ChildElementExist(Design, "pointsjoins") Then
                    oPointsJoins = New cPointsJoins(oSurvey, Me, File, Design.Item("pointsjoins"))
                Else
                    oPointsJoins = New cPointsJoins(oSurvey, Me)
                End If
            Else
                oLayers = New cLayers(oSurvey, Me)
                oPointsJoins = New cPointsJoins(oSurvey, Me)
            End If
        End Sub

        Public ReadOnly Property PointsJoins As cPointsJoins
            Get
                Return oPointsJoins
            End Get
        End Property

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXmlDesign As XmlElement = Document.CreateElement("design")
            Call oLayers.SaveTo(File, Document, oXmlDesign, Options)
            Call oPointsJoins.SaveTo(File, Document, oXmlDesign)
            Call Parent.AppendChild(oXmlDesign)
            Return oXmlDesign
        End Function

#Region "CleanUp"

        <Flags> Public Enum CleanUpFlagsEnum
            PointsReduction = 1
            PointsCleanUp = 2
            CaveBranchCheck = 4
        End Enum

        Public Class cCleanUpUndefinedCaveAndBranchItem
            Private sCave As String
            Private sBranch As String
            Private sNewCave As String
            Private sNewBranch As String

            Public Shared Function GetKey(Item As cItem) As String
                Return Item.Cave & "|" & Item.Branch
            End Function

            Public Shared Function GetKey(Cave As String) As String
                Return Cave & "|"
            End Function

            Public Shared Function GetKey(Cave As String, Branch As String) As String
                Return Cave & "|" & Branch
            End Function

            Public ReadOnly Property Key As String
                Get
                    Return sCave & "|" & sBranch
                End Get
            End Property

            Public ReadOnly Property Cave As String
                Get
                    Return sCave
                End Get
            End Property

            Public ReadOnly Property Branch As String
                Get
                    Return sBranch
                End Get
            End Property

            Public Property NewCave As String
                Get
                    Return sNewCave
                End Get
                Set(value As String)
                    sNewCave = value
                End Set
            End Property

            Public Property NewBranch As String
                Get
                    Return sNewBranch
                End Get
                Set(value As String)
                    sNewBranch = value
                End Set
            End Property

            Friend Sub New(Cave As String, Branch As String)
                sCave = Cave
                sBranch = Branch
                sNewCave = ""
                sNewBranch = ""
            End Sub
        End Class

        Friend Event OnCleanUpFoundUndefinedCavesEvent(Sender As cDesign, EventArgs As OnCleanUpUndefinedCaveEventArgs)

        Public Class OnCleanUpUndefinedCaveEventArgs
            Private oListOfUndefinedCaves As Dictionary(Of String, cCleanUpUndefinedCaveAndBranchItem) = New Dictionary(Of String, cCleanUpUndefinedCaveAndBranchItem)
            Private bCancel As Boolean

            Friend Sub New(ListOfUndefinedCaves As Dictionary(Of String, cCleanUpUndefinedCaveAndBranchItem))
                oListOfUndefinedCaves = ListOfUndefinedCaves
                bCancel = False
            End Sub

            Public Property Cancel As Boolean
                Get
                    Return bCancel
                End Get
                Set(value As Boolean)
                    bCancel = value
                End Set
            End Property

            Public ReadOnly Property ListOfUndefinedCaves As Dictionary(Of String, cCleanUpUndefinedCaveAndBranchItem)
                Get
                    Return oListOfUndefinedCaves
                End Get
            End Property
        End Class

        Friend Sub CleanUp(Optional CleanUpFlags As CleanUpFlagsEnum = CleanUpFlagsEnum.PointsReduction Or CleanUpFlagsEnum.PointsCleanUp Or CleanUpFlagsEnum.CaveBranchCheck, Optional ReducePointsFactor As Single = 0.05, Optional ByRef ListOfUndefinedCave As Dictionary(Of String, cCleanUpUndefinedCaveAndBranchItem) = Nothing)
            Dim oItems As List(Of cItem) = GetAllItems()
            Dim oItemsToDelete As List(Of cItem) = New List(Of cItem)
            Dim iIndex As Integer = 0
            Dim iCount As Integer = oItems.Count

            If CleanUpFlags And CleanUpFlagsEnum.PointsReduction Then
                Call oSurvey.RaiseOnProgressEvent("cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, "Pulizia punti", 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageCalculate Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow)
                For Each oItem As cItem In oItems
                    iIndex += 1
                    If (iIndex Mod 10) = 0 Then Call oSurvey.RaiseOnProgressEvent("cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Riduzione punti...", iIndex / iCount)
                    If oItem.CanBeReduced Then
                        Dim oLineItem As Items.cIItemLine = oItem
                        Call oLineItem.ReducePoints(ReducePointsFactor)
                    End If
                Next
            End If

            If CleanUpFlags And CleanUpFlagsEnum.PointsCleanUp Then
                iIndex = 0
                For Each oitem As cItem In oItems
                    iIndex += 1
                    If (iIndex Mod 10) = 0 Then Call oSurvey.RaiseOnProgressEvent("cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Pulizia punti...", iIndex / iCount)
                    Call oitem.Points.CleanUp()
                    If oitem.Points.Count = 0 Then
                        Call oItemsToDelete.Add(oitem)
                    End If
                Next

                iIndex = 0
                iCount = oItemsToDelete.Count
                For Each oItem As cItem In oItemsToDelete
                    iIndex += 1
                    If (iIndex Mod 10) = 0 Then Call oSurvey.RaiseOnProgressEvent("cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Eliminazione oggetti non validi...", iIndex / iCount)
                    Call oItem.Layer.Items.Remove(oItem)
                Next
            End If

            If CleanUpFlags And CleanUpFlagsEnum.CaveBranchCheck Then
                Dim bRaiseEvent As Boolean
                Dim bEventCancelled As Boolean

                Dim oListOfUndefinedCave As Dictionary(Of String, cCleanUpUndefinedCaveAndBranchItem) = ListOfUndefinedCave
                If oListOfUndefinedCave Is Nothing Then
                    oListOfUndefinedCave = New Dictionary(Of String, cCleanUpUndefinedCaveAndBranchItem)
                    ListOfUndefinedCave = oListOfUndefinedCave
                End If

                iIndex = 0
                iCount = oItems.Count
                For Each oItem As cItem In oItems
                    iIndex += 1
                    If (iIndex Mod 10) = 0 Then Call oSurvey.RaiseOnProgressEvent("cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Controllo associazione grotta/ramo per gli oggetti grafici...", iIndex / iCount)

                    If oItem.Cave <> "" Then
                        If Not oSurvey.Properties.CaveInfos.Contains(oItem.Cave) Then
                            Dim oUndefinedItem As cCleanUpUndefinedCaveAndBranchItem = New cCleanUpUndefinedCaveAndBranchItem(oItem.Cave, oItem.Branch)
                            If Not oListOfUndefinedCave.ContainsKey(oUndefinedItem.Key) Then
                                Call oListOfUndefinedCave.Add(oUndefinedItem.Key, oUndefinedItem)
                                bRaiseEvent = True
                            End If
                        Else
                            If oItem.Branch <> "" Then
                                If Not oSurvey.Properties.CaveInfos(oItem.Cave).Branches.Contains(oItem.Branch) Then
                                    Dim oUndefinedItem As cCleanUpUndefinedCaveAndBranchItem = New cCleanUpUndefinedCaveAndBranchItem(oItem.Cave, oItem.Branch)
                                    If Not oListOfUndefinedCave.ContainsKey(oUndefinedItem.Key) Then
                                        Call oListOfUndefinedCave.Add(oUndefinedItem.Key, oUndefinedItem)
                                        bRaiseEvent = True
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next

                If bRaiseEvent Then
                    Dim oArgs As OnCleanUpUndefinedCaveEventArgs = New OnCleanUpUndefinedCaveEventArgs(oListOfUndefinedCave)
                    RaiseEvent OnCleanUpFoundUndefinedCavesEvent(Me, oArgs)
                    bEventCancelled = oArgs.Cancel
                End If

                If Not bEventCancelled Then
                    iIndex = 0
                    iCount = oItems.Count
                    For Each oItem As cItem In oItems
                        iIndex += 1
                        If (iIndex Mod 10) = 0 Then Call oSurvey.RaiseOnProgressEvent("cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Correzione associazione grotta/ramo per gli oggetti grafici...", iIndex / iCount)
                        If oItem.Cave <> "" Then
                            If Not oSurvey.Properties.CaveInfos.Contains(oItem.Cave) Then
                                Dim sNewCave As String = oListOfUndefinedCave(cCleanUpUndefinedCaveAndBranchItem.GetKey(oItem)).NewCave
                                If oItem.Branch = "" Then
                                    Call oItem.SetCave(sNewCave, "", True)
                                Else
                                    If oSurvey.Properties.CaveInfos(sNewCave).Branches.Contains(oItem.Branch) Then
                                        Call oItem.SetCave(sNewCave, oItem.Branch, True)
                                    Else
                                        Dim sNewBranch As String = oListOfUndefinedCave(cCleanUpUndefinedCaveAndBranchItem.GetKey(oItem)).NewBranch
                                        Call oItem.SetCave(sNewCave, sNewBranch, True)
                                    End If
                                End If
                            Else
                                If oItem.Branch <> "" Then
                                    If Not oSurvey.Properties.CaveInfos(oItem.Cave).Branches.Contains(oItem.Branch) Then
                                        'Dim sNewCave As String = oListOfUndefinedCave(cCleanUpUndefinedCaveAndBranchItem.GetKey(oItem)).NewCave
                                        Dim sNewBranch As String = oListOfUndefinedCave(cCleanUpUndefinedCaveAndBranchItem.GetKey(oItem)).NewBranch
                                        Call oItem.SetCave(oItem.Cave, sNewBranch, True)
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If
            End If

            Call oSurvey.RaiseOnProgressEvent("cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "Pulizia terminata", 0)
        End Sub

#End Region

        Friend Function GetTranslation(ByVal Cave As String, ByVal Branch As String) As SizeF
            Try
                If Type = cIDesign.cDesignTypeEnum.Profile Then
                    If Branch = "" Then
                        If Cave = "" Then
                            Return SizeF.Empty
                        Else
                            Return oSurvey.Properties.CaveInfos(Cave).Translations.Profile.GetSize
                        End If
                    Else
                        Dim oSize As SizeF = oSurvey.Properties.CaveInfos(Cave).Translations.Profile.GetSize
                        Return SizeF.Add(oSize, oSurvey.Properties.CaveInfos(Cave).Branches(Branch).GetTranslations.Profile.GetSize)
                    End If
                Else
                    If Branch = "" Then
                        If Cave = "" Then
                            Return SizeF.Empty
                        Else
                            Return oSurvey.Properties.CaveInfos(Cave).Translations.Plan.GetSize
                        End If
                    Else
                        Dim oSize As SizeF = oSurvey.Properties.CaveInfos(Cave).Translations.Plan.GetSize
                        Return SizeF.Add(oSize, oSurvey.Properties.CaveInfos(Cave).Branches(Branch).GetTranslations.Plan.GetSize)
                    End If
                End If
            Catch
                Return SizeF.Empty
            End Try
        End Function

        Friend Function GetItemTranslation(ByVal Item As cItem) As SizeF
            Try
                If Item.DesignAffinity = cItem.DesignAffinityEnum.Design Then
                    If Item.Design.Type = cIDesign.cDesignTypeEnum.Profile Then
                        If Item.Branch = "" Then
                            If Item.Cave = "" Then
                                Return SizeF.Empty
                            Else
                                Return oSurvey.Properties.CaveInfos(Item.Cave).Translations.Profile.GetSize
                            End If
                        Else
                            Dim oSize As SizeF = oSurvey.Properties.CaveInfos(Item.Cave).Translations.Profile.GetSize
                            Return SizeF.Add(oSize, oSurvey.Properties.CaveInfos(Item.Cave).Branches(Item.Branch).GetTranslations.Profile.GetSize)
                        End If
                    Else
                        If Item.Branch = "" Then
                            If Item.Cave = "" Then
                                Return SizeF.Empty
                            Else
                                Return oSurvey.Properties.CaveInfos(Item.Cave).Translations.Plan.GetSize
                            End If
                        Else
                            Dim oSize As SizeF = oSurvey.Properties.CaveInfos(Item.Cave).Translations.Plan.GetSize
                            Return SizeF.Add(oSize, oSurvey.Properties.CaveInfos(Item.Cave).Branches(Item.Branch).GetTranslations.Plan.GetSize)
                        End If
                    End If
                Else
                    Return SizeF.Empty
                End If
            Catch
                Return SizeF.Empty
            End Try
        End Function

#Region "GetBounds"

        Public Overridable Function GetVisibleCaveBounds(ByVal PaintOptions As cOptionsCenterline, ByVal Cave As String, Branch As String, ByVal IncludeDesign As Boolean) As RectangleF
            Dim sCave As String = Cave.ToLower
            Dim oBaseRect As RectangleF = New RectangleF
            For Each oItem As cItem In GetAllVisibleItems(PaintOptions)
                If GetIfItemMustBeDrawedByCaveAndBranch(PaintOptions, oItem, Cave, Branch) Then
                    Dim oItemRect As RectangleF = oItem.GetBounds
                    If Not oItemRect.IsEmpty Then
                        If PaintOptions.DrawTranslation Then
                            Dim oTranslation As SizeF = GetItemTranslation(oItem)
                            If Not oTranslation.IsEmpty Then
                                oItemRect.Location = PointF.Add(oItemRect.Location, oTranslation)
                            End If
                        End If
                        If oBaseRect.IsEmpty Then
                            oBaseRect = oItemRect
                        Else
                            oBaseRect = RectangleF.Union(oBaseRect, oItemRect)
                        End If
                    End If
                End If
            Next
            Return oBaseRect
        End Function

        Public Overridable Function GetCaveBounds(ByVal PaintOptions As cOptionsCenterline, ByVal Cave As String, Branch As String, ByVal IncludeDesign As Boolean) As RectangleF
            Dim sCave As String = Cave.ToLower
            Dim oBaseRect As RectangleF = New RectangleF
            For Each oItem As cItem In GetAllItems()
                If GetIfItemMustBeDrawedByCaveAndBranch(PaintOptions, oItem, Cave, Branch) Then
                    Dim oItemRect As RectangleF = oItem.GetBounds
                    If Not oItemRect.IsEmpty Then
                        If PaintOptions.DrawTranslation Then
                            Dim oTranslation As SizeF = GetItemTranslation(oItem)
                            If Not oTranslation.IsEmpty Then
                                oItemRect.Location = PointF.Add(oItemRect.Location, oTranslation)
                            End If
                        End If
                        If oBaseRect.IsEmpty Then
                            oBaseRect = oItemRect
                        Else
                            oBaseRect = RectangleF.Union(oBaseRect, oItemRect)
                        End If
                    End If
                End If
            Next
            Return oBaseRect
        End Function

        Public Overridable Function GetBounds(PaintOptions As cOptionsCenterline) As RectangleF
            Dim oBaseRect As RectangleF = New RectangleF
            For Each oItem As cItem In GetAllItems()
                Dim oItemRect As RectangleF = oItem.GetBounds
                If Not oItemRect.IsEmpty Then
                    If PaintOptions.DrawTranslation Then
                        Dim oTranslation As SizeF = GetItemTranslation(oItem)
                        If Not oTranslation.IsEmpty Then
                            oItemRect.Location = PointF.Add(oItemRect.Location, oTranslation)
                        End If
                    End If
                    If Not Single.IsNaN(oItemRect.Width) And Not Single.IsNaN(oItemRect.Height) Then
                        If oBaseRect.IsEmpty Then
                            oBaseRect = oItemRect
                        Else
                            oBaseRect = RectangleF.Union(oBaseRect, oItemRect)
                        End If
                    End If
                End If
            Next
            Return oBaseRect
        End Function

        Public Overridable Function GetVisibleBounds(ByVal PaintOptions As cOptionsCenterline) As RectangleF
            Dim oBaseRect As RectangleF = New RectangleF
            For Each oItem As cItem In GetAllVisibleItems(PaintOptions)
                Dim oItemRect As RectangleF = oItem.GetBounds
                If Not oItemRect.IsEmpty Then
                    If PaintOptions.DrawTranslation Then
                        Dim oTranslation As SizeF = GetItemTranslation(oItem)
                        If Not oTranslation.IsEmpty Then
                            oItemRect.Location = PointF.Add(oItemRect.Location, oTranslation)
                        End If
                    End If
                    If Not Single.IsNaN(oItemRect.Width) And Not Single.IsNaN(oItemRect.Height) Then
                        If oBaseRect.IsEmpty Then
                            oBaseRect = oItemRect
                        Else
                            oBaseRect = RectangleF.Union(oBaseRect, oItemRect)
                        End If
                    End If
                End If
            Next
            Return oBaseRect
        End Function

        Public Overridable Function GetDesignVisibleBounds(ByVal PaintOptions As cOptionsCenterline) As RectangleF
            Dim oBaseRect As RectangleF = New RectangleF
            For Each oItem As cItem In GetAllDesignVisibleItems(PaintOptions)
                Dim oItemRect As RectangleF = oItem.GetBounds
                If Not oItemRect.IsEmpty Then
                    If PaintOptions.DrawTranslation Then
                        Dim oTranslation As SizeF = GetItemTranslation(oItem)
                        If Not oTranslation.IsEmpty Then
                            oItemRect.Location = PointF.Add(oItemRect.Location, oTranslation)
                        End If
                    End If
                    If Not Single.IsNaN(oItemRect.Width) And Not Single.IsNaN(oItemRect.Height) Then
                        If oBaseRect.IsEmpty Then
                            oBaseRect = oItemRect
                        Else
                            oBaseRect = RectangleF.Union(oBaseRect, oItemRect)
                        End If
                    End If
                End If
            Next
            Return oBaseRect
        End Function

#End Region

        Friend ReadOnly Property Caches As cDrawCaches
            Get
                Return oCaches
            End Get
        End Property

        Friend Sub Render(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions)

        End Sub

        Private Sub pDrawOriginalPosition(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, DrawingOrder As List(Of cCaveBranchPlaceholder))
            Dim iOriginalPositionTransparencyThreshold = oSurvey.Properties.DesignProperties.GetValue("DesignOriginalPositionTransparencyThreshold", 255)
            Using oClippingPaths As cClippingPaths = GetCaveClippingPaths(Graphics, PaintOptions, ClippingPathsOptions.OnlyVisiblePen)
                'attivo il filtro per grotta/ramo (non attivo nelle opzioni di stampa/esportazione)
                'e commissiono il disegno coppia per coppia
                Dim bClippingDraw As Boolean
                Dim oClippingColor As Color
                Dim oTranslation As SizeF = PaintOptions.TranslationsOptions.OriginalPositionTranslation.GetSize
                Dim oState As GraphicsState = Nothing
                If Not oTranslation.IsEmpty Then
                    oState = Graphics.Save
                    Call Graphics.TranslateTransform(oTranslation.Width, oTranslation.Height, Drawing2D.MatrixOrder.Prepend)
                End If
                For Each oCaveBranchPlaceholder As cCaveBranchPlaceholder In DrawingOrder
                    Dim oClippingPath As GraphicsPath = oClippingPaths(oCaveBranchPlaceholder.Cave, oCaveBranchPlaceholder.Branch)
                    If Not oClippingPath Is Nothing Then
                        If PaintOptions.TranslationsOptions.OriginalPositionOnlyTranslated Then
                            bClippingDraw = Not GetTranslation(oCaveBranchPlaceholder.Cave, oCaveBranchPlaceholder.Branch).IsEmpty
                        Else
                            bClippingDraw = True
                        End If
                        If bClippingDraw Then
                            Select Case PaintOptions.TranslationsOptions.OriginalPositionColorMode
                                Case 0
                                    oClippingColor = oSurvey.Properties.CaveInfos.GetColor(oCaveBranchPlaceholder.Cave, oCaveBranchPlaceholder.Branch, Color.LightGray)
                                Case 1
                                    oClippingColor = oSurvey.Properties.CaveInfos.GetColor(oCaveBranchPlaceholder.Cave, "", Color.LightGray)
                            End Select
                            If PaintOptions.TranslationsOptions.OriginalPositionColorGray Then
                                oClippingColor = modPaint.GrayColor(oClippingColor)
                            End If
                            'If PaintOptions.TranslationsOptions.OriginalPositionTransparency <> 0 Then
                            '    oClippingColor = Color.FromArgb(255 * PaintOptions.TranslationsOptions.OriginalPositionTransparency, oClippingColor)
                            'End If
                            Using oBrush As SolidBrush = New SolidBrush(Color.FromArgb(iOriginalPositionTransparencyThreshold, oClippingColor))
                                Graphics.FillPath(oBrush, oClippingPath)
                            End Using

                        End If
                    End If
                Next
                If Not IsNothing(oState) Then
                    Call Graphics.Restore(oState)
                End If
            End Using
        End Sub

        Public Overridable Sub Paint(Graphics As Graphics, PaintOptions As cOptionsCenterline, DrawOptions As cDrawOptions, Selection As Helper.Editor.cIEditDesignSelection)
            Try
                Dim sOrigin As String = oSurvey.Properties.Origin
                Dim bIsThisSurvey As Boolean = PaintOptions.Survey Is oSurvey
                Dim bSchematic As Boolean = (DrawOptions.DrawOptions And cDrawOptions.cdrawoptionsenum.Schematic) = cDrawOptions.cdrawoptionsenum.Schematic

                If bIsThisSurvey AndAlso Not bSchematic Then
                    If Type = cIDesign.cDesignTypeEnum.Plan AndAlso sOrigin <> "" AndAlso oSurvey.Properties.GPS.Enabled AndAlso PaintOptions.SurfaceOptions.DrawSurface Then
                        Dim iBackupSmoothingMode As SmoothingMode = Graphics.SmoothingMode
                        Graphics.SmoothingMode = SmoothingMode.None

                        Dim oState As GraphicsState = Nothing
                        oState = Graphics.Save()
                        Using oMatrix As Matrix = Graphics.Transform.Clone
                            Call oMatrix.RotateAt(-oSurvey.Calculate.GeoMagDeclinationData.MeridianConvergence, New PointF(0, 0))
                            Graphics.Transform = oMatrix

                            Dim iCurrentScale As Integer = PaintOptions.CurrentScale
                            Dim iIndex As Integer = 0
                            Dim iCount As Integer = PaintOptions.SurfaceOptions.Count
                            Call oSurvey.RaiseOnProgressEvent("paint.design.surface", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, "Rendering surface...", 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImagePaint)
                            For Each oSurfaceOptionItem As cSurfaceOptions.cSurfaceOptionsItem In PaintOptions.SurfaceOptions
                                If oSurfaceOptionItem.Visible Then
                                    Dim bVisible As Boolean
                                    If oSurfaceOptionItem.MinScale.HasValue AndAlso oSurfaceOptionItem.MaxScale.HasValue Then
                                        bVisible = iCurrentScale >= oSurfaceOptionItem.MinScale.Value And iCurrentScale <= oSurfaceOptionItem.MaxScale.Value
                                    ElseIf oSurfaceOptionItem.MinScale.HasValue AndAlso Not oSurfaceOptionItem.MaxScale.HasValue Then
                                        bVisible = iCurrentScale >= oSurfaceOptionItem.MinScale.Value
                                    ElseIf Not oSurfaceOptionItem.MinScale.HasValue AndAlso oSurfaceOptionItem.MaxScale.HasValue Then
                                        bVisible = iCurrentScale <= oSurfaceOptionItem.MaxScale.Value
                                    Else
                                        bVisible = True
                                    End If
                                    If bVisible Then

                                        Dim oSurfaceItem As Surface.cISurfaceItem = oSurvey.Surface(oSurfaceOptionItem.ID)
                                        Call oSurvey.RaiseOnProgressEvent("", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Rendering surface layer " & oSurfaceItem.Name & "...", iIndex / iCount, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImagePaint)
                                        If TypeOf oSurfaceItem Is Surface.cElevation Then
                                            Call modPaint.MapDrawElevation(Graphics, oSurvey, DirectCast(oSurfaceItem, Surface.cElevation), oSurfaceOptionItem)
                                        ElseIf TypeOf oSurfaceItem Is Surface.cOrthoPhoto Then
                                            Call modPaint.MapDrawOrthophoto(Graphics, oSurvey, DirectCast(oSurfaceItem, Surface.cOrthoPhoto), oSurfaceOptionItem)
                                        ElseIf TypeOf oSurfaceItem Is Surface.cWMS Then
                                            Call modPaint.MapDrawWMS(Graphics, oSurvey, DirectCast(oSurfaceItem, Surface.cWMS), oSurfaceOptionItem)
                                        End If

                                    End If
                                End If
                                iIndex += 1
                            Next
                        End Using
                        Graphics.Restore(oState)

                        Call oSurvey.RaiseOnProgressEvent("paint.design.surface", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)
                        Graphics.SmoothingMode = iBackupSmoothingMode
                    End If

                    If sOrigin <> "" AndAlso oSurvey.Properties.GPS.Enabled Then
                        'linked survey: for now are drawed before this survey...layer are drawed in correct order but by survey and not in correct sequence...
                        'check if owner of paintoptions is this survey (if not linked surveys are not drawed)
                        If PaintOptions.IsDesign AndAlso DirectCast(PaintOptions, cIOptionLinkedSurveys).DrawLinkedSurveys Then
                            For Each oLinkedsurvey As cLinkedSurvey In oSurvey.LinkedSurveys.GetSelected(If(Type = cIDesign.cDesignTypeEnum.Plan, "design.plan", "design.profile"))
                                If oLinkedsurvey.IsValid Then
                                    If oLinkedsurvey.IsGeoreferenced Then
                                        Dim oThis As Calculate.cTrigPointCoordinate = oSurvey.Calculate.TrigPoints(sOrigin).Coordinate
                                        Dim oLinked As Calculate.cTrigPointCoordinate = oLinkedsurvey.LinkedSurvey.Calculate.TrigPoints(oLinkedsurvey.LinkedSurvey.Properties.Origin).Coordinate
                                        Dim oThisOrigin As UTM = modUTM.WGS84ToUTM(oThis)
                                        Dim oLinkedOrigin As UTM = modUTM.WGS84ToUTM(oLinked)
                                        If Type = cIDesign.cDesignTypeEnum.Plan Then
                                            Dim oState As GraphicsState = Nothing
                                            Dim oSizePoint As SizeF = New SizeD(oLinkedOrigin.East - oThisOrigin.East, oLinkedOrigin.North - oThisOrigin.North)
                                            Dim oMovePoint As PointD = modPaint.RotatePointByRadians(New PointD(oSizePoint.Width, oSizePoint.Height), oSurvey.Calculate.GeoMagDeclinationData.MeridianConvergenceRadians)
                                            Dim oMoveBy As SizeF = oSizePoint ' New SizeF(oMovePoint)
                                            If Not oMoveBy.IsEmpty Then
                                                oState = Graphics.Save()
                                                Using oMatrix As Matrix = Graphics.Transform.Clone
                                                    Call oMatrix.RotateAt(-oSurvey.Calculate.GeoMagDeclinationData.MeridianConvergence, New PointF(0, 0))
                                                    Call oMatrix.Translate(oMoveBy.Width, -oMoveBy.Height)
                                                    Call oMatrix.RotateAt(oLinkedsurvey.LinkedSurvey.Calculate.GeoMagDeclinationData.MeridianConvergence, New PointF(0, 0))
                                                    Graphics.Transform = oMatrix
                                                End Using
                                            End If
                                            Try
                                                Call oLinkedsurvey.LinkedSurvey.Plan.Paint(Graphics, PaintOptions, cDrawOptions.Empty, Selection)
                                            Catch ex As Exception
                                                Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Error, ex.Message)
                                            End Try
                                            If Not IsNothing(oState) Then Call Graphics.Restore(oState)
                                        Else
                                            Dim oState As GraphicsState = Nothing
                                            Dim oMoveBy As SizeF = New SizeF(modPaint.DistancePointToPoint(New PointF(oLinkedOrigin.East, oLinkedOrigin.North), New Point(oThisOrigin.East, oThisOrigin.North)), oLinked.Altitude - oThis.Altitude)
                                            If Not oMoveBy.IsEmpty Then
                                                oState = Graphics.Save()
                                                Call Graphics.TranslateTransform(oMoveBy.Width, -oMoveBy.Height, MatrixOrder.Prepend)
                                            End If
                                            Try
                                                Call oLinkedsurvey.LinkedSurvey.Profile.Paint(Graphics, PaintOptions, cDrawOptions.Empty, Selection)
                                            Catch ex As Exception
                                                Debug.Print("cDesign.Paint[" & oLinkedsurvey.Filename & "]>" & ex.Message)
                                                Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Error, ex.Message)
                                            End Try
                                            If Not IsNothing(oState) Then Call Graphics.Restore(oState)
                                        End If
                                    End If
                                End If
                            Next
                            Dim iLowerLayersDesignTransparencyThreshold As Integer = My.Application.Settings.GetSetting("design.lowerlayersdesigntransparencythreshold", 120) 'oSurvey.Properties.DesignProperties.GetValue("LowerLayersDesignTransparencyThreshold", 120)
                            If iLowerLayersDesignTransparencyThreshold > 0 Then
                                Call Graphics.FillRectangle(New SolidBrush(Color.FromArgb(iLowerLayersDesignTransparencyThreshold, Color.White)), Graphics.ClipBounds)
                            End If
                        End If
                    End If
                End If

                If PaintOptions.DrawDesign Then
                    'cave/branch to be designes...ordered if needed
                    Dim oDrawingOrder As List(Of cCaveBranchPlaceholder) = New List(Of cCaveBranchPlaceholder)
                    If Not PaintOptions.IsDesign Then
                        Call modCaveAndBranch.AppendCaves(oSurvey, oDrawingOrder)
                        Dim bUsePaintZOrder As Boolean
                        If PaintOptions.IsPreview Then
                            bUsePaintZOrder = PaintOptions.UseDrawingZOrder
                        Else
                            bUsePaintZOrder = False
                        End If
                        If bUsePaintZOrder Then
                            'ordine l'elenco delle coppie grotta/ramo...come indicato custom altrimenti resta ordinato come da inserimento...
                            Call oDrawingOrder.Sort(New cCaveBranchPlaceHolderComparer)
                        End If
                    End If

                    'original position (if under design)
                    If PaintOptions.TranslationsOptions.DrawOriginalPosition AndAlso Not PaintOptions.TranslationsOptions.OriginalPositionOverDesign Then
                        Call pDrawOriginalPosition(Graphics, PaintOptions, oDrawingOrder)
                    End If

                    '----------------------------------------------------------------------
                    ''rock effect...
                    'not good, disabled
                    'If Not PaintOptions.IsDesign AndAlso Not PaintOptions.IsViewer Then
                    '    Dim oPreviewOptions As cIOptionsPreview = PaintOptions
                    '    If oPreviewOptions.DrawSolidRock Then
                    '        Dim sSize As Single = 10
                    '        Dim iBorderSteps As Integer = 15
                    '        Dim iSolidRockColorTransparency As Integer = 126
                    '        Dim oSolidRockColor As Color = Color.FromArgb(255, Color.DimGray)
                    '        Dim oSolidRockPen As Pen = New Pen(oSolidRockColor)
                    '        oSolidRockPen.SetLineCap(LineCap.Flat, LineCap.Flat, LineCap.Flat)

                    '        Using oClippingPathsForFill As cClippingPaths = GetCaveClippingPaths(Graphics, PaintOptions, ClippingPathsOptions.All)
                    '            Using oClippingPathsForEdge As cClippingPaths = GetCaveClippingPaths(Graphics, PaintOptions, ClippingPathsOptions.OnlyVisiblePen)
                    '                'attivo il filtro per grotta/ramo (non attivo nelle opzioni di stampa/esportazione)
                    '                'e commissiono il disegno coppia per coppia
                    '                For Each oCaveBranchPlaceholder As cCaveBranchPlaceholder In oDrawingOrder
                    '                    Dim oEdgePath As GraphicsPath = oClippingPathsForEdge(oCaveBranchPlaceholder.Cave, oCaveBranchPlaceholder.Branch)
                    '                    If Not oEdgePath Is Nothing Then
                    '                        Dim iOpacity As Integer = 0
                    '                        Dim iOpacityStep As Integer = 255 / iBorderSteps
                    '                        For iBorderStep As Integer = 1 To iBorderSteps
                    '                            oSolidRockPen.Width = sSize / Convert.ToSingle(iBorderStep)
                    '                            oSolidRockPen.Color = Color.FromArgb(iOpacity, oSolidRockColor)
                    '                            Using oExtPath As GraphicsPath = oEdgePath.Clone
                    '                                Call oExtPath.Widen(oSolidRockPen, Nothing, 0.1)
                    '                                oExtPath.FillMode = FillMode.Winding
                    '                                Call Graphics.FillPath(New SolidBrush(oSolidRockPen.Color), oExtPath)
                    '                            End Using
                    '                            iOpacity += iOpacityStep
                    '                        Next
                    '                    End If

                    '                    Dim oFillPath As GraphicsPath = oClippingPathsForFill(oCaveBranchPlaceholder.Cave, oCaveBranchPlaceholder.Branch)
                    '                    If Not oFillPath Is Nothing Then
                    '                        Call Graphics.FillPath(Brushes.White, oFillPath)
                    '                    End If
                    '                Next
                    '            End Using
                    '        End Using
                    '    End If
                    'End If
                    '----------------------------------------------------------------------

                    If PaintOptions.DesignStyle = cOptionsCenterline.DesignStyleEnum.Design OrElse PaintOptions.DesignStyle = cOptionsCenterline.DesignStyleEnum.Combined Then
                        If PaintOptions.IsDesign Then
                            'RENDERING for EDITOR (semplified and without clipping)
                            Dim oDesignOptions As cOptionsDesign = PaintOptions
                            Dim iLowerLayersDesignTransparencyThreshold As Integer = My.Application.Settings.GetSetting("design.lowerlayersdesigntransparencythreshold", 120) 'oSurvey.Properties.DesignProperties.GetValue("LowerLayersDesignTransparencyThreshold", 120)
                            Using oClippingRegions As cClippingRegions = New cClippingRegions(oSurvey)
                                Dim bLayerBeforeCurrent As Boolean = True
                                For Each oLayer As cLayer In oLayers
                                    If oLayer.Type = Selection.CurrentLayer.Type Then
                                        bLayerBeforeCurrent = False
                                        If oLayer.Type > cLayers.LayerTypeEnum.Base Then
                                            If oLayer.Survey Is Selection.CurrentSurvey Then
                                                If iLowerLayersDesignTransparencyThreshold > 0 Then
                                                    Call Graphics.FillRectangle(New SolidBrush(Color.FromArgb(iLowerLayersDesignTransparencyThreshold, My.Application.Settings.GetSetting("design.lowerlayersdesignbackcolor", Color.White))), Graphics.ClipBounds)
                                                End If
                                            End If
                                        End If
                                        Call oLayer.Paint(Graphics, PaintOptions, cItem.PaintOptionsEnum.Solid, oClippingRegions, Selection)
                                    Else
                                        Select Case oDesignOptions.UnselectedLevelDrawingMode
                                            Case cOptionsDesign.UnselectedLevelDrawingModeEnum.None
                                            Case cOptionsDesign.UnselectedLevelDrawingModeEnum.OnlyCaveBorders
                                                If oLayer.Type = cLayers.LayerTypeEnum.Base Or oLayer.Type = cLayers.LayerTypeEnum.Borders Then
                                                    If bLayerBeforeCurrent Then
                                                        Call oLayer.Paint(Graphics, PaintOptions, cItem.PaintOptionsEnum.Solid Or cItem.PaintOptionsEnum.SchematicLayerDraw, oClippingRegions, Selection)
                                                    Else
                                                        Call oLayer.Paint(Graphics, PaintOptions, cItem.PaintOptionsEnum.Wireframe, oClippingRegions, Selection)
                                                    End If
                                                End If
                                            Case cOptionsDesign.UnselectedLevelDrawingModeEnum.Wireframe
                                                If bLayerBeforeCurrent Then
                                                    Call oLayer.Paint(Graphics, PaintOptions, cItem.PaintOptionsEnum.Solid Or cItem.PaintOptionsEnum.SchematicLayerDraw, oClippingRegions, Selection)
                                                Else
                                                    Call oLayer.Paint(Graphics, PaintOptions, cItem.PaintOptionsEnum.Wireframe, oClippingRegions, Selection)
                                                End If
                                        End Select
                                    End If
                                Next
                            End Using
                        Else
                            'RENDERING for PREVIEW, EXPORT E VIEWER
                            'Backgrounds
                            Using oClippingPaths As cClippingPaths = GetCaveClippingPaths(Graphics, PaintOptions, ClippingPathsOptions.OnlyVisiblePen)
                                Dim iBackgroundTransparencyThreshold = oSurvey.Properties.DesignProperties.GetValue("DesignBackgroundTransparencyThreshold", 0)
                                Dim oBackcolor As Color = Color.White
                                If iBackgroundTransparencyThreshold > 0 Then
                                    Using oBackbrush As SolidBrush = New SolidBrush(Color.FromArgb(iBackgroundTransparencyThreshold, oBackcolor))
                                        For Each oCaveBranchPlaceholder As cCaveBranchPlaceholder In oDrawingOrder
                                            Dim oClippingPath As GraphicsPath = oClippingPaths(oCaveBranchPlaceholder.Cave, oCaveBranchPlaceholder.Branch)
                                            If Not oClippingPath Is Nothing Then
                                                Dim oState As GraphicsState = Graphics.Save
                                                If PaintOptions.DrawTranslation Then
                                                    Dim oTranslation As SizeF = GetTranslation(oCaveBranchPlaceholder.Cave, oCaveBranchPlaceholder.Branch)
                                                    If Not oTranslation.IsEmpty Then
                                                        Call Graphics.TranslateTransform(oTranslation.Width, oTranslation.Height, Drawing2D.MatrixOrder.Prepend)
                                                    End If
                                                End If
                                                Call Graphics.FillPath(oBackbrush, oClippingPath)
                                                Call Graphics.Restore(oState)
                                            End If
                                        Next
                                    End Using
                                End If
                            End Using

                            If bSchematic Then
                                Using oClippingRegions As cClippingRegions = GetCaveClippingRegions(Graphics, PaintOptions)
                                    'attivo il filtro per grotta/ramo (non attivo nelle opzioni di stampa/esportazione)
                                    'e commissiono il disegno coppia per coppia
                                    PaintOptions.HighlightCurrentCave = True
                                    PaintOptions.HighlightMode = cOptionsCenterline.HighlightModeEnum.ExactMatch
                                    For Each oCaveBranchPlaceholder As cCaveBranchPlaceholder In oDrawingOrder
                                        For Each oLayer As cLayer In oLayers
                                            Call oLayer.Paint(Graphics, PaintOptions, cItem.PaintOptionsEnum.Wireframe, oClippingRegions, New Helper.Editor.cEditDesignSelection(Selection, oCaveBranchPlaceholder.Cave, oCaveBranchPlaceholder.Branch))
                                        Next
                                    Next
                                    PaintOptions.HighlightCurrentCave = False
                                    PaintOptions.HighlightMode = cOptionsCenterline.HighlightModeEnum.Default
                                End Using
                            Else
                                Using oClippingRegions As cClippingRegions = GetCaveClippingRegions(Graphics, PaintOptions)
                                    'attivo il filtro per grotta/ramo (non attivo nelle opzioni di stampa/esportazione)
                                    'e commissiono il disegno coppia per coppia
                                    PaintOptions.HighlightCurrentCave = True
                                    PaintOptions.HighlightMode = cOptionsCenterline.HighlightModeEnum.ExactMatch
                                    Dim iIndex As Integer = 0
                                    Dim iCount As Integer = oDrawingOrder.Count
                                    Call oSurvey.RaiseOnProgressEvent("paint.design", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, "Rendering...", 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImagePaint)
                                    For Each oCaveBranchPlaceholder As cCaveBranchPlaceholder In oDrawingOrder
                                        Call oSurvey.RaiseOnProgressEvent("", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Rendering " & oCaveBranchPlaceholder.Cave & " " & oCaveBranchPlaceholder.Branch, iIndex / iCount, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImagePaint)
                                        For Each oLayer As cLayer In oLayers
                                            Call oLayer.Paint(Graphics, PaintOptions, cItem.PaintOptionsEnum.Solid, oClippingRegions, New Helper.Editor.cEditDesignSelection(Selection, oCaveBranchPlaceholder.Cave, oCaveBranchPlaceholder.Branch))
                                        Next
                                        iIndex += 1
                                    Next
                                    Call oSurvey.RaiseOnProgressEvent("paint.design", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)
                                    PaintOptions.HighlightCurrentCave = False
                                    PaintOptions.HighlightMode = cOptionsCenterline.HighlightModeEnum.Default
                                End Using
                            End If
                        End If
                    End If

                    'area or combined design
                    Dim iCombinedAreaTransparencyThreshold As Integer
                    If PaintOptions.IsDesign Then
                        iCombinedAreaTransparencyThreshold = oSurvey.Properties.DesignProperties.GetValue("DesignEditCombinedAreaTransparencyThreshold", 120)
                    Else
                        iCombinedAreaTransparencyThreshold = oSurvey.Properties.DesignProperties.GetValue("DesignCombinedAreaTransparencyThreshold", 120)
                    End If
                    If PaintOptions.DesignStyle = cOptionsCenterline.DesignStyleEnum.Areas OrElse (PaintOptions.DesignStyle = cOptionsCenterline.DesignStyleEnum.Combined AndAlso iCombinedAreaTransparencyThreshold > 0) Then
                        If PaintOptions.IsDesign Then
                            Dim oBordersLayer As cSurveyPC.cSurvey.Design.Layers.cLayerBorders = oLayers(cLayers.LayerTypeEnum.Borders)
                            For Each oItem As cItem In oBordersLayer.Items
                                If oItem.Type = cIItem.cItemTypeEnum.InvertedFreeHandArea Then
                                    If oItem.Points.Count > 1 Then
                                        If modDesign.GetIfItemMustBeDrawedByHiddenFlag(PaintOptions, oItem) Then
                                            Dim oBorderItem As Design.Items.cItemInvertedFreeHandArea = oItem
                                            Dim oColor As Color
                                            Select Case PaintOptions.CombineColorMode
                                                Case cOptionsCenterline.CombineColorModeEnum.CavesAndBranches
                                                    oColor = oSurvey.Properties.CaveInfos.GetColor(oBorderItem.Cave, oBorderItem.Branch, Color.LightGray)
                                                Case cOptionsCenterline.CombineColorModeEnum.OnlyCaves
                                                    oColor = oSurvey.Properties.CaveInfos.GetColor(oBorderItem.Cave, "", Color.LightGray)
                                                Case cOptionsCenterline.CombineColorModeEnum.ExtendStart
                                                    oColor = oSurvey.Properties.CaveInfos.GetOriginColor(oBorderItem.Cave, oBorderItem.Branch, Color.LightGray)
                                            End Select
                                            If PaintOptions.CombineColorGray Then
                                                oColor = modPaint.GrayColor(oColor)
                                            End If

                                            Using oBrush As SolidBrush = If(PaintOptions.DesignStyle = cOptionsCenterline.DesignStyleEnum.Combined, New SolidBrush(Color.FromArgb(iCombinedAreaTransparencyThreshold, oColor)), New SolidBrush(oColor))
                                                Dim oLastPoint As PointF
                                                Dim oSequences As List(Of cSequence) = oItem.Points.GetSequences
                                                Using oBorderPath As GraphicsPath = New GraphicsPath
                                                    oBorderPath.FillMode = FillMode.Winding
                                                    For Each oSequence As cSequence In oSequences
                                                        Dim oSequencePoints() As PointF = oSequence.GetPoints
                                                        If oSequencePoints.Length > 0 Then
                                                            If Not oLastPoint.IsEmpty Then
                                                                Call oBorderPath.AddLine(oLastPoint, oSequencePoints(0))
                                                            End If
                                                            If oSequencePoints.Length > 1 Then
                                                                Select Case oSequence.GetLineType(oBorderItem.LineType)
                                                                    Case Items.cIItemLine.LineTypeEnum.Beziers
                                                                        Call modPaint.PointsToBeziers(oSequencePoints, oBorderPath)
                                                                    Case Items.cIItemLine.LineTypeEnum.Splines
                                                                        Call oBorderPath.AddCurve(oSequencePoints, sDefaultSplineTension)
                                                                    Case Else
                                                                        Call oBorderPath.AddLines(oSequencePoints)
                                                                End Select
                                                            End If
                                                        End If
                                                    Next
                                                    Call Graphics.FillPath(oBrush, oBorderPath)
                                                End Using
                                            End Using
                                        End If
                                    End If
                                End If
                            Next
                        Else
                            Using oClippingRegions As cClippingRegions = GetCaveClippingRegions(Graphics, PaintOptions)
                                For Each oCaveBranchPlaceholder As cCaveBranchPlaceholder In oDrawingOrder
                                    Dim oRegion As Region = oClippingRegions(oCaveBranchPlaceholder.Cave, oCaveBranchPlaceholder.Branch)
                                    If Not oRegion Is Nothing Then
                                        If Not oRegion.IsEmpty(Graphics) Then
                                            Dim oColor As Color
                                            Select Case PaintOptions.CombineColorMode
                                                Case cOptionsCenterline.CombineColorModeEnum.CavesAndBranches
                                                    oColor = oSurvey.Properties.CaveInfos.GetColor(oCaveBranchPlaceholder.Cave, oCaveBranchPlaceholder.Branch, Color.LightGray)
                                                Case cOptionsCenterline.CombineColorModeEnum.OnlyCaves
                                                    oColor = oSurvey.Properties.CaveInfos.GetColor(oCaveBranchPlaceholder.Cave, "", Color.LightGray)
                                                Case cOptionsCenterline.CombineColorModeEnum.ExtendStart
                                                    oColor = oSurvey.Properties.CaveInfos.GetOriginColor(oCaveBranchPlaceholder.Cave, oCaveBranchPlaceholder.Branch, Color.LightGray)
                                            End Select
                                            If PaintOptions.CombineColorGray Then
                                                oColor = modPaint.GrayColor(oColor)
                                            End If
                                            If bSchematic Then
                                                oColor = modPaint.LightColor(oColor, 0.85)
                                            End If
                                            Using oBrush As Brush = If(bSchematic, New HatchBrush(HatchStyle.BackwardDiagonal, oColor, Color.Transparent), If(PaintOptions.DesignStyle = cOptionsCenterline.DesignStyleEnum.Combined, New SolidBrush(Color.FromArgb(iCombinedAreaTransparencyThreshold, oColor)), New SolidBrush(oColor)))
                                                Dim oState As GraphicsState = Graphics.Save
                                                If Not PaintOptions.IsDesign And PaintOptions.DrawTranslation Then
                                                    Dim oTranslation As SizeF = GetTranslation(oCaveBranchPlaceholder.Cave, oCaveBranchPlaceholder.Branch)
                                                    If Not oTranslation.IsEmpty Then
                                                        Call Graphics.TranslateTransform(oTranslation.Width, oTranslation.Height, Drawing2D.MatrixOrder.Prepend)
                                                    End If
                                                End If
                                                Call Graphics.FillRegion(oBrush, oRegion)
                                                Call Graphics.Restore(oState)
                                            End Using
                                        End If
                                    End If
                                Next
                            End Using
                            If PaintOptions.DesignStyle = cOptionsCenterline.DesignStyleEnum.Areas Then
                                'draw only affinity=extra objects
                                PaintOptions.DesignAffinity = cOptionsCenterline.DesignAffinityEnum.Extra
                                PaintOptions.HighlightCurrentCave = True
                                PaintOptions.HighlightMode = cOptionsCenterline.HighlightModeEnum.ExactMatch
                                If bSchematic Then
                                    Using oClippingRegions As cClippingRegions = GetCaveClippingRegions(Graphics, PaintOptions)
                                        'attivo il filtro per grotta/ramo (non attivo nelle opzioni di stampa/esportazione)
                                        'e commissiono il disegno coppia per coppia
                                        For Each oCaveBranchPlaceholder As cCaveBranchPlaceholder In oDrawingOrder
                                            For Each oLayer As cLayer In oLayers
                                                Call oLayer.Paint(Graphics, PaintOptions, cItem.PaintOptionsEnum.Wireframe, oClippingRegions, New Helper.Editor.cEditDesignSelection(Selection, oCaveBranchPlaceholder.Cave, oCaveBranchPlaceholder.Branch))
                                            Next
                                        Next
                                    End Using
                                Else
                                    Using oClippingRegions As cClippingRegions = GetCaveClippingRegions(Graphics, PaintOptions)
                                        'attivo il filtro per grotta/ramo (non attivo nelle opzioni di stampa/esportazione)
                                        'e commissiono il disegno coppia per coppia
                                        Dim iIndex As Integer = 0
                                        Dim iCount As Integer = oDrawingOrder.Count
                                        Call oSurvey.RaiseOnProgressEvent("paint.design", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, "Rendering...", 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImagePaint)
                                        For Each oCaveBranchPlaceholder As cCaveBranchPlaceholder In oDrawingOrder
                                            Call oSurvey.RaiseOnProgressEvent("", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Rendering " & oCaveBranchPlaceholder.Cave & " " & oCaveBranchPlaceholder.Branch, iIndex / iCount, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImagePaint)
                                            For Each oLayer As cLayer In oLayers
                                                Call oLayer.Paint(Graphics, PaintOptions, cItem.PaintOptionsEnum.Solid, oClippingRegions, New Helper.Editor.cEditDesignSelection(Selection, oCaveBranchPlaceholder.Cave, oCaveBranchPlaceholder.Branch))
                                            Next
                                            iIndex += 1
                                        Next
                                        Call oSurvey.RaiseOnProgressEvent("paint.design", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)
                                    End Using
                                End If
                                PaintOptions.HighlightCurrentCave = False
                                PaintOptions.HighlightMode = cOptionsCenterline.HighlightModeEnum.Default
                                PaintOptions.DesignAffinity = cOptionsCenterline.DesignAffinityEnum.All
                            End If
                        End If
                    End If

                    'original position (if over design)
                    If PaintOptions.TranslationsOptions.DrawOriginalPosition AndAlso PaintOptions.TranslationsOptions.OriginalPositionOverDesign Then
                        Call pDrawOriginalPosition(Graphics, PaintOptions, oDrawingOrder)
                    End If
                End If

                If Not bSchematic AndAlso (PaintOptions.DrawPlot OrElse PaintOptions.DrawSpecialPoints OrElse (PaintOptions.DrawTranslation AndAlso PaintOptions.TranslationsOptions.DrawTranslationsLine) OrElse PaintOptions.DrawSurfaceProfile) Then
                    Call Plot.Paint(Graphics, PaintOptions, Selection)
                End If
            Catch ex As Exception
                Debug.Print("cDesign.Paint>" & ex.Message)
                Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Error, ex.Message)
            End Try
        End Sub

        Public MustOverride ReadOnly Property Plot() As cPlot

        Friend MustOverride Sub WarpItems(ByVal Segment As cISegment)

        Public Function HitTest(ByVal PaintOptions As cOptions, ByVal Selection As Helper.Editor.cIEditDesignSelection, ByVal Point As PointF, ByVal Wide As Single, First As Boolean) As List(Of cItem)
            If Selection.CurrentLayer Is Nothing Then
                Return New List(Of cItem)
            Else
                Return Selection.CurrentLayer.HitTest(PaintOptions, Selection.CurrentCave, Selection.CurrentBranch, Point, Wide, First)
            End If
        End Function

        Public Function HitTest(ByVal PaintOptions As cOptions, ByVal Selection As Helper.Editor.cIEditDesignSelection, ByVal X As Single, ByVal Y As Single, ByVal Wide As Single, First As Boolean) As List(Of cItem)
            If Selection.CurrentLayer Is Nothing Then
                Return New List(Of cItem)
            Else
                Return HitTest(PaintOptions, Selection, New PointF(X, Y), Wide, First)
            End If
        End Function

        Public MustOverride Function GetNearestSegment(ByVal Cave As String, ByVal Branch As String, CrossSection As String, ByVal Point As PointF, ByVal BindDesignType As cItem.BindDesignTypeEnum) As cISegment
        Public MustOverride Function GetNearestSegment(ByVal Cave As String, ByVal Branch As String, CrossSection As String, ByVal X As Single, ByVal Y As Single, ByVal BindDesignType As cItem.BindDesignTypeEnum) As cISegment

        Friend MustOverride Function GetSegmentPointData(ByVal Segment As cISegment) As Calculate.Plot.cIProjectedData

        Public MustOverride Sub Clear()
    End Class
End Namespace