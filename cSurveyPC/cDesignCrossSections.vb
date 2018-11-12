Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Collections.ObjectModel

Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design
    Public Class cDesignCrossSections
        Implements IEnumerable
        Implements cIDesignCrossSectionsCollection

        Private oSurvey As cSurvey
        Private oItems As cDesignCrossSectionBaseCollection

        Public Class OnDesignCrossSectionEventArgs
            Private oCrossSection As cDesignCrossSection
            Private iIndex As Integer

            Public ReadOnly Property CrossSection() As cDesignCrossSection
                Get
                    Return oCrossSection
                End Get
            End Property

            Public ReadOnly Property Index() As Integer
                Get
                    Return iIndex
                End Get
            End Property

            Friend Sub New(ByVal CrossSection As cDesignCrossSection, ByVal Index As Integer)
                oCrossSection = CrossSection
                iIndex = Index
            End Sub
        End Class

        Friend Event OnCrossSectionAdd(ByVal Sender As Object, ByVal Args As OnDesignCrossSectionEventArgs)
        Friend Event OnCrossSectionRemove(ByVal Sender As Object, ByVal Args As OnDesignCrossSectionEventArgs)

        Friend Function GetEmptyCrossSection() As cDesignCrossSection
            Dim oCrossSection As cItemCrossSection = Nothing
            Return New cDesignCrossSection(oSurvey, oCrossSection)
        End Function

        Public Function GetCaveSegments(ByVal Cave As String, Optional ByVal Branch As String = "") As cSegmentCollection
            Dim oSegmentColl As cSegmentCollection = New cSegmentCollection(oSurvey)
            Dim sCave As String = ("" & Cave).ToLower
            Dim sBranch As String = ("" & Branch).ToLower
            If sBranch = "" Then
                For Each oSegment As cISegment In oItems
                    If oSegment.Cave.ToLower = sCave Then
                        Call oSegmentColl.Append(oSegment)
                    End If
                Next
            Else
                For Each oSegment As cISegment In oItems
                    If oSegment.Cave.ToLower = sCave And (oSegment.Branch.ToLower = sBranch Or oSegment.Branch.ToLower.StartsWith(sBranch & cCaveInfoBranches.sBranchSeparator)) Then
                        Call oSegmentColl.Append(oSegment)
                    End If
                Next
            End If
            Return oSegmentColl
        End Function

        Public Function GetCaveSegments(ByVal CaveInfoBranch As cCaveInfoBranch) As cSegmentCollection
            If CaveInfoBranch Is Nothing Then
                Return GetCaveSegments("")
            Else
                Return GetCaveSegments(CaveInfoBranch.Cave, CaveInfoBranch.Path)
            End If
        End Function

        Public Function GetCaveSegments(ByVal CaveInfo As cCaveInfo) As cSegmentCollection
            If CaveInfo Is Nothing Then
                Return GetCaveSegments("")
            Else
                Return GetCaveSegments(CaveInfo.Name)
            End If
        End Function

        Public ReadOnly Property Count As Integer Implements cIDesignCrossSectionsCollection.Count
            Get
                Return oItems.Count
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal Index As Integer) As cDesignCrossSection Implements cIDesignCrossSectionsCollection.Item
            Get
                Return oItems(Index)
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal ID As String) As cDesignCrossSection Implements cIDesignCrossSectionsCollection.Item
            Get
                Return oItems(ID)
            End Get
        End Property

        Public Function ToArray() As cDesignCrossSection() Implements cIDesignCrossSectionsCollection.ToArray
            Return oItems.ToArray
        End Function

        Friend Function GetBindItem(ID As String) As cDesignCrossSection
            If oItems.Contains(ID) Then
                Return oItems(ID)
            Else
                Return Nothing
            End If
        End Function

        Friend Function GetBindItem(Item As Object) As cDesignCrossSection
            If IsNothing(Item) Then
                Return Nothing
            Else
                If oItems.Contains(DirectCast(Item, cDesignCrossSection)) Then
                    Return Item
                Else
                    Return Nothing
                End If
            End If
        End Function

        Friend Function GetBindItem(Item As cDesignCrossSection) As cDesignCrossSection
            If oItems.Contains(Item) Then
                Return Item
            Else
                Return Nothing
            End If
        End Function

        Friend Function GetAllItems(Type As cIDesign.cDesignTypeEnum) As List(Of cDesignCrossSection)
            Dim oAllItems As List(Of cDesignCrossSection) = New List(Of cDesignCrossSection)
            For Each oCrossSection As cDesignCrossSection In oItems
                If oCrossSection.Design.Type = Type AndAlso Not IsNothing(oCrossSection.CrossSection) AndAlso Not oCrossSection.CrossSection.Deleted Then
                    Call oAllItems.Add(oCrossSection)
                End If
            Next
            Return oAllItems
        End Function

        Public Function Contains(ByVal ID As String) As Boolean Implements cIDesignCrossSectionsCollection.Contains
            Return oItems.Contains(ID)
        End Function

        Public Function Contains(ByVal CrossSection As cDesignCrossSection) As Boolean Implements cIDesignCrossSectionsCollection.Contains
            Return oItems.Contains(CrossSection)
        End Function

        Friend Function Add(ByVal CrossSection As cItemCrossSection) As cDesignCrossSection
            Dim oItem As cDesignCrossSection = New cDesignCrossSection(oSurvey, CrossSection)
            Call oItems.Add(oItem)
            RaiseEvent OnCrossSectionAdd(Me, New cDesignCrossSections.OnDesignCrossSectionEventArgs(oItem, oItems.Count - 1))
            Return oItem
        End Function

        Friend Function GetChangedCrossSections(Design As cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum, ForWarping As Boolean) As cDesignCrossSectionsCollection
            Dim oCrossSectionColl As cDesignCrossSectionsCollection = New cDesignCrossSectionsCollection(oSurvey)
            For Each oCrossSection As cDesignCrossSection In oItems
                Select Case Design
                    Case cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum.Plan
                        If oCrossSection.Design.Type = Design AndAlso oCrossSection.Data.Plan.Changed AndAlso ((ForWarping AndAlso oCrossSection.Data.PlanWarpingFactor.IsChanged) OrElse Not ForWarping) Then
                            Call oCrossSectionColl.Append(oCrossSection)
                        End If
                    Case cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum.Profile
                        If oCrossSection.Design.Type = Design AndAlso oCrossSection.Data.Profile.Changed AndAlso ((ForWarping AndAlso oCrossSection.Data.ProfileWarpingFactor.IsChanged) OrElse Not ForWarping) Then
                            Call oCrossSectionColl.Append(oCrossSection)
                        End If
                End Select
            Next
            Return oCrossSectionColl
        End Function

        Public Sub Rebind(Optional ByVal RemoveOrphans As Boolean = True)
            Dim oDesignItems As List(Of cItem) = New List(Of cItem)
            Call oDesignItems.AddRange(oSurvey.GetAllDesignItems(cLayers.LayerTypeEnum.Signs, cIItem.cItemTypeEnum.CrossSection))

            'verifico gli elementi da eliminare e quelli già presenti nella collection
            Dim oItemsToCheck As List(Of cItemCrossSection) = New List(Of cItemCrossSection)
            Dim oItemsToDelete As List(Of cDesignCrossSection) = New List(Of cDesignCrossSection)
            Dim oDuplicatedItems As Dictionary(Of cItem, cDesignCrossSection) = New Dictionary(Of cItem, cDesignCrossSection)
            For Each oItem As cDesignCrossSection In oItems
                If IsNothing(oItem.CrossSection) Then
                    Call oItemsToDelete.Add(oItem)
                Else
                    If Not oDesignItems.Contains(oItem.CrossSection) Then
                        If Not oItemsToDelete.Contains(oItem) Then Call oItemsToDelete.Add(oItem)
                    Else
                        Call oItemsToCheck.Add(oItem.CrossSection)
                    End If
                    If oDuplicatedItems.ContainsKey(oItem.CrossSection) Then
                        If Not oItemsToDelete.Contains(oItem) Then Call oItemsToDelete.Add(oItem)
                    Else
                        Call oDuplicatedItems.Add(oItem.CrossSection, oItem)
                    End If
                End If
            Next

            'cerco gli elementi grafici NON già presenti nella collection (quelli da aggiungere)
            For Each oDesignItem As cItem In oDesignItems
                If Not oItemsToCheck.Contains(oDesignItem) Then
                    Dim oItem As cDesignCrossSection = New cDesignCrossSection(oSurvey, oDesignItem)
                    Call oItems.Add(oItem)
                End If
            Next

            'elimino gli elementi che sono stati individuati come da cancellare
            If RemoveOrphans Then
                For Each oItemToDelete As cDesignCrossSection In oItemsToDelete
                    If oItems.Contains(oItemToDelete) Then
                        Call oItems.Remove(oItemToDelete)
                    End If
                Next
            End If

            Call RebindCrossSections()
        End Sub

        Friend Sub Remove(CrossSection As cDesignCrossSection)
            Dim iIndex As Integer = CrossSection.Index
            Call oItems.Remove(CrossSection)
            RaiseEvent OnCrossSectionRemove(Me, New OnDesignCrossSectionEventArgs(CrossSection, iIndex))
        End Sub

        Friend Sub RebindCrossSections()
            For Each oItem As cDesignCrossSection In oItems
                Call oItem.RebindCrossSection()
            Next
        End Sub

        Friend Sub CollectGarbage()
            Dim oItemsToDelete As List(Of cDesignCrossSection) = New List(Of cDesignCrossSection)
            For Each oItem As cDesignCrossSection In oItems
                If oItem.CrossSection.Deleted Then
                    Call oItemsToDelete.Add(oItem)
                End If
            Next
            For Each oitem As cDesignCrossSection In oItemsToDelete
                Call oItems.Remove(oitem)
            Next
        End Sub

        'Friend Sub Calculate(Optional ByVal PerformWarping As Boolean = True)
        '    Call CollectGarbage()
        '    For Each oCrossSection As cDesignCrossSection In oItems
        '        Dim oFromSidePointRight As PointF
        '        Dim oFromSidePointLeft As PointF
        '        Dim oToSidePointRight As PointF
        '        Dim oToSidePointLeft As PointF

        '        Try
        '            Dim oFromPoint As PointF = oCrossSection.CrossSection.Points(0).Point
        '            Dim oToPoint As PointF = oFromPoint
        '            Call oCrossSection.Data.Profile.SetPoints("", "", oFromPoint, oToPoint, oFromSidePointRight, oFromSidePointLeft, oToSidePointRight, oToSidePointLeft)
        '        Catch ex As Exception
        '        End Try
        '    Next

        '    'e fare la warp per i punti associati ai segmenti cambiati...
        '    If PerformWarping Then
        '        If oSurvey.Properties.DesignWarpingMode = cSurvey.DesignWarpingModeEnum.Default Then
        '            Dim oCrossSections As cDesignCrossSectionsCollection = GetChangedCrossSections(cIDesign.cDesignTypeEnum.Profile, True)
        '            Dim iIndex As Integer = 0
        '            Dim iCount As Integer = oCrossSections.Count
        '            If iCount > 0 Then
        '                Call oSurvey.RaiseOnProgressEvent("warping.crosssection", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, "Warping crosssections...", 0)
        '                For Each oCrossSection As cDesignCrossSection In oCrossSections
        '                    If (iIndex Mod 20) = 0 Then Call oSurvey.RaiseOnProgressEvent("warping.crosssection", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Warping crosssections...", iIndex / iCount)
        '                    If oCrossSection.Data.Profile.Changed Then
        '                        'Call oSurvey.Profile.WarpItems(oCrossSection)
        '                        Call oCrossSection.WarpItems()
        '                        Call oCrossSection.Data.Profile.ResetChange()
        '                    End If
        '                    iIndex += 1
        '                Next
        '                Call oSurvey.RaiseOnProgressEvent("warping.crosssection", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)
        '            End If
        '        End If
        '    End If
        'End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As Storage.cFile, ByVal CrossSections As XmlElement)
            oSurvey = Survey
            oItems = New cDesignCrossSectionBaseCollection
            For Each oXMLItem As XmlElement In CrossSections.ChildNodes
                Dim oCrossSection As cDesignCrossSection = New cDesignCrossSection(oSurvey, File, oXMLItem)
                Call oItems.Add(oCrossSection)
            Next
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oItems = New cDesignCrossSectionBaseCollection
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Call CollectGarbage()
            Dim oXmlCrossSections As XmlElement = Document.CreateElement("crosssections")
            For Each oItem As cDesignCrossSection In oItems
                Call oItem.SaveTo(File, Document, oXmlCrossSections)
            Next
            Call Parent.AppendChild(oXmlCrossSections)
            Return oXmlCrossSections
        End Function

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Public Function IndexOf(CrossSection As cDesignCrossSection) As Integer Implements cIDesignCrossSectionsCollection.IndexOf
            Return oItems.IndexOf(CrossSection)
        End Function

        Public Function IndexOf(ID As String) As Integer Implements cIDesignCrossSectionsCollection.IndexOf
            If oItems.Contains(ID) Then
                Dim oCrossSection As cDesignCrossSection = oItems(ID)
                Return oItems.IndexOf(oCrossSection)
            Else
                Return -1
            End If
        End Function
    End Class
End Namespace
