Imports System.Runtime.CompilerServices
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes

Public Module modDevExpress

    <Extension>
    Public Sub ClearItems(Item As DevExpress.XtraBars.BarSubItem)
        For Each oLink As DevExpress.XtraBars.BarItemLink In Item.ItemLinks.ToList
            Call Item.Manager.Items.Remove(oLink.Item)
        Next
    End Sub

    <Extension>
    Public Function FindByName(Items As DevExpress.XtraBars.Ribbon.RibbonBarItems, Name As String) As DevExpress.XtraBars.BarItem
        Dim sName As String = Name.ToLower
        Return Items.Where(Function(oitem) oitem.Name.ToLower = sName).FirstOrDefault
    End Function

    <Extension> Public Function GetFocusedObject(Control As DevExpress.XtraGrid.Views.Grid.GridView) As Object
        Return Control.GetFocusedRow
    End Function

    <Extension> Public Function SetFocusedRow(Control As DevExpress.XtraGrid.Views.Grid.GridView, FocusedObject As Object) As Boolean
        Return SetFocusedObject(Control, FocusedObject)
    End Function

    <Extension> Public Function SetFocusedObject(Control As DevExpress.XtraGrid.Views.Grid.GridView, FocusedObject As Object) As Boolean
        Dim iHandle As Integer = Control.FindRow(FocusedObject)
        If iHandle >= 0 Then
            Control.FocusedRowHandle = iHandle
            Return True
        Else
            Return False
        End If
    End Function

    <Extension> Public Function [Objects](Control As TreeList) As Object
        Return Control.DataSource
    End Function

    <Extension> Public Function SelectedObjects(Control As TreeList) As Object
        Dim oResult As List(Of Object) = New List(Of Object)
        For Each oNode As TreeListNode In Control.Selection
            oResult.Add(Control.GetDataRecordByNode(oNode))
        Next
        Return oResult
    End Function

    <Extension> Public Function SetFocusedObject(Control As TreeList, FocusedObject As Object) As Boolean
        Dim oFoundNode As TreeListNode = Control.FindNode(Function(oNode)
                                                              Return Control.GetRow(oNode.Id) Is FocusedObject
                                                          End Function)
        If oFoundNode Is Nothing Then
            Return False
        Else
            Control.FocusedNode = oFoundNode
            'Control.MakeNodeVisible(oFoundNode)
            Return True
        End If
    End Function

    <Extension> Public Function GetFocusedObject(Control As TreeList) As Object
        Return Control.GetFocusedRow()
    End Function

    <Extension> Public Sub RefreshFocusedObject(Control As TreeList)
        If Not Control.FocusedNode Is Nothing Then
            Control.RefreshNode(Control.FocusedNode)
        End If
    End Sub

    <Extension> Public Sub DeselectAll(Control As TreeList)
        Call Control.BeginUpdate()
        Call Control.Selection.UnselectAll()
        Call Control.EndUpdate()
    End Sub

    <Extension> Public Sub SelectObjects(Control As TreeList, items As IList)
        Call Control.BeginUpdate()
        For Each oNode As TreeListNode In Control.Nodes
            If items.Contains(Control.GetDataRecordByNode(oNode)) Then
                Control.SelectNode(oNode)
            End If
        Next
        Call Control.EndUpdate()
    End Sub
End Module
