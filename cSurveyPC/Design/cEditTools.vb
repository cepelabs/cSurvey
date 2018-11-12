Imports System.Xml
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Editor

Namespace cSurvey.Design
    Friend MustInherit Class cEditTools
        Implements cIEditTools
        Private oSurvey As cSurvey
        Private oDesign As cIDesign

        Private bIsNewItem As Boolean

        Private bIsInPointEdit As Boolean
        Private bIsNewPoint As Boolean
        Private oNewPointRelative As cIPoint
        Private bIsInEdit As Boolean
        Private bIsInCombine As Boolean

        Private oCurrentLayer As cILayer
        Private oCurrentItem As cIItem
        Private oCurrentItemPoint As cIPoint

        Private sCurrentCave As String = ""
        Private sCurrentBranch As String = ""

        Event OnItemSelect(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs) Implements cIEditTools.OnItemSelect
        Event OnItemCombine(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs) Implements cIEditTools.OnItemCombine
        Event OnItemEdit(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs) Implements cIEditTools.OnItemEdit
        Event OnItemDelete(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs) Implements cIEditTools.OnItemDelete
        Event OnItemPointDelete(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs) Implements cIEditTools.OnItemPointDelete
        Event OnItemPointEdit(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs) Implements cIEditTools.OnItemPointEdit
        Event OnItemPointEnd(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs) Implements cIEditTools.OnItemPointEnd
        Event OnItemEnd(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs) Implements cIEditTools.OnItemEnd
        Event OnLayerSelect(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs) Implements cIEditTools.OnLayerSelect

        Event OnCaveBranchSelect(ByVal Sender As Object, ByVal ToolEventArgs As cCaveBranchSelectEventArgs) Implements cIEditTools.OnCaveBranchSelect

        Private Function pCreateEventArgs() As cEditToolsEventArgs
            Return New cEditToolsEventArgs(oCurrentLayer, oCurrentItem, oCurrentItemPoint, bIsNewItem)
        End Function

        Private oFilter As cFilter
        Private bIsFiltered As Boolean

        Event OnFilterApplied(ByVal Sender As Object, ByVal ToolEventArgs As EventArgs) Implements cIEditTools.OnFilterApplied
        Event OnFilterRemoved(ByVal Sender As Object, ByVal ToolEventArgs As EventArgs) Implements cIEditTools.OnFilterRemoved

        Public Sub FilterApply() Implements cIEditTools.FilterApply
            bIsFiltered = True
            RaiseEvent OnFilterApplied(Me, New EventArgs)
        End Sub

        Public Sub FilterRemove() Implements cIEditTools.FilterRemove
            bIsFiltered = False
            RaiseEvent OnFilterRemoved(Me, New EventArgs)
        End Sub

        Public Sub FilterToggle() Implements cIEditTools.FilterToggle
            If bIsFiltered Then
                Call FilterRemove()
            Else
                Call FilterApply()
            End If
        End Sub

        Public ReadOnly Property IsFiltered As Boolean Implements cIEditTools.IsFiltered
            Get
                Return bIsFiltered
            End Get
        End Property

        Public ReadOnly Property Filter As cFilter Implements cIEditTools.Filter
            Get
                Return oFilter
            End Get
        End Property

        Public Sub Refresh() Implements cIEditTools.Refresh
        End Sub

        Public Sub [SelectItem](ByVal Item As cIItem) Implements cIEditTools.SelectItem
            If Not oCurrentItem Is Item Then
                Call [EndItem]()
                oCurrentItem = Item
            End If
            Call Refresh()
            RaiseEvent OnItemSelect(Me, pCreateEventArgs)
        End Sub

        Public Sub [SelectCave](ByVal CaveBranch As cCaveInfoBranch) Implements cIEditTools.SelectCave
            If CaveBranch Is Nothing Then
                sCurrentCave = ""
                sCurrentBranch = ""
            Else
                If (sCurrentCave <> CaveBranch.Cave) And (sCurrentBranch <> CaveBranch.Name) Then
                    sCurrentCave = CaveBranch.Cave
                    sCurrentBranch = CaveBranch.Name
                End If
            End If
        End Sub

        Public Sub [SelectCave](ByVal Cave As cCaveInfo) Implements cIEditTools.SelectCave
            If Cave Is Nothing Then
                sCurrentCave = ""
                sCurrentBranch = ""
            Else
                If (sCurrentCave <> Cave.Name) Then
                    sCurrentCave = Cave.Name
                    sCurrentBranch = ""
                End If
            End If
        End Sub

        Public Sub [SelectCave](ByVal Cave As String, Optional ByVal CaveBranch As String = "") Implements cIEditTools.SelectCave
            If (Cave <> sCurrentCave) Or (CaveBranch <> sCurrentBranch) Then
                sCurrentCave = Cave
                If sCurrentCave <> "" Then
                    sCurrentBranch = CaveBranch
                Else
                    sCurrentBranch = ""
                End If
            End If
        End Sub

        Public Sub EndAndSelectItem() Implements cIEditTools.EndAndSelectItem
            Dim oItem As cIItem = oCurrentItem
            Call EndItem()
            If Not oItem Is Nothing Then
                If Not oItem.Deleted Then
                    Call SelectItem(oItem)
                End If
            End If
        End Sub

        Public Sub [EndItem]() Implements cIEditTools.EndItem
            Dim bRaiseEvent As Boolean
            If Not oCurrentItem Is Nothing Then
                bRaiseEvent = True
            End If
            If bRaiseEvent Then
                RaiseEvent OnItemEnd(Me, pCreateEventArgs)
            End If
            oCurrentItem = Nothing
        End Sub

        Public Overloads ReadOnly Property CurrentItem() As cIItem Implements cIEditTools.CurrentItem
            Get
                Return oCurrentItem
            End Get
        End Property

        Public ReadOnly Property CurrentCave() As String Implements cIEditTools.CurrentCave
            Get
                Return sCurrentCave
            End Get
        End Property

        Public ReadOnly Property CurrentBranch() As String Implements cIEditTools.CurrentBranch
            Get
                Return sCurrentBranch
            End Get
        End Property

        Public ReadOnly Property CurrentLayer As cILayer Implements cIEditTools.CurrentLayer
            Get
                Return oCurrentLayer
            End Get
        End Property

        Public ReadOnly Property CurrentItemPoint As cIPoint Implements cIEditTools.CurrentItemPoint
            Get
                Return oCurrentItemPoint
            End Get
        End Property

        Public ReadOnly Property IsInEdit As Boolean Implements cIEditTools.IsInEdit
            Get
                Return bIsInEdit
            End Get
        End Property

        Public ReadOnly Property IsNewPoint As Boolean Implements cIEditTools.IsNewPoint
            Get
                Return bIsNewPoint
            End Get
        End Property

        Public ReadOnly Property IsInPointEdit As Boolean Implements cIEditTools.IsInPointEdit
            Get
                Return bIsInPointEdit
            End Get
        End Property

        Public ReadOnly Property CurrentNewPointRelative As cIPoint Implements cIEditTools.CurrentNewPointRelative
            Get
                Return oNewPointRelative
            End Get
        End Property

        Public Overridable Sub Reset() Implements cIEditTools.Reset
            oCurrentLayer = Nothing
            oCurrentItem = Nothing
            oCurrentItemPoint = Nothing
            bIsInEdit = False
            bIsInCombine = False
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
        End Sub

        Public Sub SelectLayer(Layer As cILayer) Implements cIEditTools.SelectLayer
            oCurrentLayer = Layer
        End Sub

        Public ReadOnly Property HasCurrentLayer As Boolean Implements cIEditTools.HasCurrentLayer
            Get
                Return Not IsNothing(oCurrentLayer)
            End Get
        End Property

        Public ReadOnly Property HasCurrentItemPoint As Boolean Implements cIEditTools.HasCurrentItemPoint
            Get
                Return Not IsNothing(oCurrentItemPoint)
            End Get
        End Property

        Public ReadOnly Property HasCurrentItem As Boolean Implements cIEditTools.HasCurrentItem
            Get
                Return Not IsNothing(oCurrentItem)
            End Get
        End Property

        MustOverride Sub EditItem(Item As cIItem, Optional IsNewItem As Boolean = False) Implements cIEditTools.EditItem
        MustOverride Sub DeleteItem() Implements cIEditTools.DeleteItem
        MustOverride Sub EditPoint(Point As cIPoint, Optional IsNewPoint As Boolean = False, Optional NewPointRelative As cIPoint = Nothing) Implements cIEditTools.EditPoint
        MustOverride Sub SelectPoint(Point As cIPoint, Optional IsNewPoint As Boolean = False, Optional NewPointRelative As cIPoint = Nothing) Implements cIEditTools.SelectPoint
        MustOverride Sub EndPoint() Implements cIEditTools.EndPoint
    End Class
End Namespace

