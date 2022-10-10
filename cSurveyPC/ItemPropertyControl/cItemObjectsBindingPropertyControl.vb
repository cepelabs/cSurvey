Imports System.ComponentModel
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraTreeList

Friend Class cItemObjectsBindingPropertyControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() 

    End Sub

    Public Shadows Sub Rebind(Item As cItem)
        MyBase.Rebind(Item)

        btnPropObjectsSelect.Enabled = False
        Call tvLayers.BeginUpdate()
        tvLayers.DataSource = Nothing
        Call tvLayers.EndUpdate()
    End Sub

    Private Sub pRefresh()
        Dim oItemSegment As cItemSegment = MyBase.Item
        Dim oItems As BindingList(Of cItem) = New BindingList(Of cItem)(oItemSegment.Design.GetBindedItems(oItemSegment.Segment))
        Call tvLayers.BeginUpdate()
        tvLayers.DataSource = oItems
        Call tvLayers.ForceInitialize()
        Call tvLayers.BestFitColumns()
        Call tvLayers.EndUpdate()
    End Sub

    Private Sub tvLayers_CustomUnboundColumnData(sender As Object, e As TreeListCustomColumnDataEventArgs) Handles tvLayers.CustomUnboundColumnData
        If Not e.Row Is Nothing Then
            If e.IsGetData Then
                Select Case e.Column.Name
                    Case "colTreeLayersType"
                        If TypeOf e.Row Is cLayer Then
                            e.Value = DirectCast(e.Row, cLayer).Type.ToString
                        Else
                            Dim oItem As cItem = DirectCast(e.Row, cItem)
                            Dim sText As String = oItem.Type.ToString
                            If oItem.HaveText Then
                                Dim oItemText As cIItemText = oItem
                                sText = sText & " " & Chr(34) & oItemText.Text & Chr(34)
                            End If
                            e.Value = sText
                        End If
                    Case "colTreeLayersName"
                        If TypeOf e.Row Is cLayer Then
                            e.Value = ""
                        Else
                            Dim oItem As cItem = DirectCast(e.Row, cItem)
                            e.Value = oItem.Name
                        End If
                    Case "colTreeLayersCave"
                        If TypeOf e.Row Is cLayer Then
                            e.Value = ""
                        Else
                            Dim oItem As cItem = DirectCast(e.Row, cItem)
                            e.Value = oItem.Cave
                        End If
                    Case "colTreeLayersBranch"
                        If TypeOf e.Row Is cLayer Then
                            e.Value = ""
                        Else
                            Dim oItem As cItem = DirectCast(e.Row, cItem)
                            e.Value = oItem.Branch
                        End If
                    Case "colTreeLayersHiddenInDesign"
                        If TypeOf e.Row Is cLayer Then
                            e.Value = Not DirectCast(e.Row, cLayer).HiddenInDesign
                        Else
                            e.Value = Not DirectCast(e.Row, cItem).HiddenInDesign
                        End If
                    Case "colTreeLayersHiddenInPreview"
                        If TypeOf e.Row Is cLayer Then
                            e.Value = Not DirectCast(e.Row, cLayer).HiddenInPreview
                        Else
                            e.Value = Not DirectCast(e.Row, cItem).HiddenInPreview
                        End If
                End Select
            End If
        End If
    End Sub

    Private Sub tvLayers_NodeCellStyle(sender As Object, e As GetCustomNodeCellStyleEventArgs) Handles tvLayers.NodeCellStyle
        If e.Column.Name = "colTreeLayersCaveBranchColor" Then
            Dim oElement As Object = tvLayers.GetRow(e.Node.Id)
            If TypeOf oElement Is cItem Then
                Dim oItem As cItem = oElement
                e.Appearance.BackColor = Item.Survey.Properties.CaveInfos.GetColor(oItem, Color.LightGray)
            End If
        End If
    End Sub

    Private Sub tvLayers_GetSelectImage(sender As Object, e As GetSelectImageEventArgs) Handles tvLayers.GetSelectImage
        Dim oElement As Object = tvLayers.GetRow(e.Node.Id)
        If TypeOf oElement Is cLayer Then
            e.NodeImageIndex = 0
        Else
            e.NodeImageIndex = 1
        End If
    End Sub

    Private Sub btnPropObjectsSelect_Click(sender As Object, e As EventArgs) Handles btnPropObjectsSelect.Click
        Call DoCommand("selectitem", tvLayers.GetRow(tvLayers.FocusedNode.Id))
    End Sub

    Private Sub btnPropObjectsRefresh_Click(sender As Object, e As EventArgs) Handles btnPropObjectsRefresh.Click
        Call pRefresh
    End Sub

    Private Sub tvLayers_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles tvLayers.FocusedNodeChanged
        If tvLayers.FocusedNode Is Nothing Then
            btnPropObjectsSelect.Enabled = False
        Else
            btnPropObjectsSelect.Enabled = True
        End If
    End Sub

    Private Sub tvLayers_DoubleClick(sender As Object, e As EventArgs) Handles tvLayers.DoubleClick
        Call btnPropObjectsSelect.PerformClick()
    End Sub

    Private Sub tvLayers_CustomDrawEmptyArea(sender As Object, e As CustomDrawEmptyAreaEventArgs) Handles tvLayers.CustomDrawEmptyArea
        If tvLayers.Nodes.Count = 0 Then
            Dim s As String = "Press refresh to update"
            Using oSF As StringFormat = New StringFormat
                oSF.Alignment = StringAlignment.Center
                e.Cache.DrawString(s, e.Appearance.Font, e.Appearance.GetForeBrush(e.Cache), e.Bounds, New DevExpress.Utils.StringFormatInfo(oSF))
            End Using
            e.Handled = True
        End If
    End Sub

End Class
