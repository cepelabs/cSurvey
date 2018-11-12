Imports System.Xml
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Calculate.Plot
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Editor

Namespace cSurvey.Editor
    Friend Interface cIEditTools
        Sub [SelectCave](ByVal CaveBranch As cCaveInfoBranch)
        Sub [SelectCave](ByVal Cave As cCaveInfo)
        Sub [SelectCave](ByVal Cave As String, Optional ByVal CaveBranch As String = "")

        ReadOnly Property CurrentCave() As String
        ReadOnly Property CurrentBranch() As String

        Sub EndAndSelectItem()
        Sub [EndItem]()
        Sub DeleteItem()

        ReadOnly Property HasCurrentItemPoint As Boolean
        ReadOnly Property HasCurrentItem As Boolean
        ReadOnly Property HasCurrentLayer As Boolean

        ReadOnly Property IsInEdit() As Boolean
        ReadOnly Property IsNewPoint() As Boolean
        ReadOnly Property IsInPointEdit() As Boolean

        Sub EndPoint()

        Sub FilterApply()
        Sub FilterRemove()
        Sub FilterToggle()
        ReadOnly Property IsFiltered As Boolean
        ReadOnly Property Filter As cFilter

        Event OnFilterApplied(ByVal Sender As Object, ByVal ToolEventArgs As EventArgs)
        Event OnFilterRemoved(ByVal Sender As Object, ByVal ToolEventArgs As EventArgs)

        Sub Refresh()
        Sub Reset()
        Sub Clear()

        Overloads Sub [SelectItem](ByVal Item As cIItem)
        Sub SelectLayer(ByVal Layer As cILayer)

        Overloads ReadOnly Property CurrentItem() As cIItem
        ReadOnly Property CurrentLayer() As cILayer
        ReadOnly Property CurrentItemPoint() As cIPoint

        Overloads Sub EditItem(ByVal Item As cIItem, Optional ByVal IsNewItem As Boolean = False)

        ReadOnly Property CurrentNewPointRelative As cIPoint
        Sub EditPoint(ByVal Point As cIPoint, Optional IsNewPoint As Boolean = False, Optional NewPointRelative As cIPoint = Nothing)
        Sub SelectPoint(ByVal Point As cIPoint, Optional IsNewPoint As Boolean = False, Optional NewPointRelative As cIPoint = Nothing)

        Event OnItemSelect(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs)
        Event OnItemCombine(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs)
        Event OnItemEdit(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs)
        Event OnItemDelete(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs)
        Event OnItemPointDelete(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs)
        Event OnItemPointEdit(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs)
        Event OnItemPointEnd(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs)
        Event OnItemEnd(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs)
        Event OnLayerSelect(ByVal Sender As Object, ByVal ToolEventArgs As cEditToolsEventArgs)

        Event OnCaveBranchSelect(ByVal Sender As Object, ByVal ToolEventArgs As cCaveBranchSelectEventArgs)
    End Interface

    Public Class cEditToolsEventArgs
        Inherits EventArgs

        Private oCurrentLayer As cILayer
        Private oCurrentItem As cIItem
        Private oCurrentItemPoint As cIPoint
        Private bIsNewItem As Boolean

        Friend Sub New(ByVal CurrentLayer As cILayer, ByVal CurrentItem As cIItem, ByVal CurrentItemPoint As cIPoint, ByVal IsNewItem As Boolean)
            oCurrentLayer = CurrentLayer
            oCurrentItem = CurrentItem
            oCurrentItemPoint = CurrentItemPoint
            bIsNewItem = IsNewItem
        End Sub

        Public ReadOnly Property IsNewItem As Boolean
            Get
                Return bIsNewItem
            End Get
        End Property

        Public ReadOnly Property CurrentLayer() As cILayer
            Get
                Return oCurrentLayer
            End Get
        End Property

        Public ReadOnly Property CurrentItem() As cIItem
            Get
                Return oCurrentItem
            End Get
        End Property

        Public ReadOnly Property CurrentItemPoint() As cIPoint
            Get
                Return oCurrentItemPoint
            End Get
        End Property
    End Class

    Public Class cCaveBranchSelectEventArgs
        Inherits EventArgs
    End Class
End Namespace
