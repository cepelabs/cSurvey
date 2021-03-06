﻿Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Friend Class cItemLegendPropertyControl
    Private oItem As cItemLegend

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            For Each iValue As Integer In [Enum].GetValues(GetType(cItemLegend.cLegendItem.ItemTypeEnum))
                Call colLegendType.Items.Add(modMain.GetLocalizedString("itemlegend.type" & iValue))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Public Overrides Sub Rebind(Item As cItem)
        oItem = Item

        txtPropLegendItemWidth.Value = oItem.ItemWidth
        txtPropLegendItemHeight.Value = oItem.ItemHeight
        txtPropLegendItemHPadding.Value = oItem.ItemHPadding
        txtPropLegendItemVPadding.Value = oItem.ItemVPadding

        txtPropLegendItemScale.Value = oItem.ItemScale

        txtPropLegendItemRowColMaxItems.Value = oItem.MaxItems
        cboPropLegendItemFlowDirection.SelectedIndex = oItem.FlowDirection
        cboPropLegendItemAlign.SelectedIndex = oItem.ItemAlignment

        Call Reload()
    End Sub

    Public Sub Reload()
        Call grdLegendItems.Rows.Clear()
        For Each olegendItem As cItemLegend.cLegendItem In oItem.Items
            Dim oData() As Object = {olegendItem.Item.ToString, modMain.GetLocalizedString("itemlegend.type" & olegendItem.Type.ToString("D")), olegendItem.Text, olegendItem.Scale}
            Call grdLegendItems.Rows.Add(oData)
        Next
        Call pRebindButtons()
    End Sub

    Private Sub cmdDeleteAll_Click(sender As Object, e As EventArgs) Handles cmdDeleteAll.Click
        Call grdLegendItems.Rows.Clear()
        Call oItem.ClearItems()
        Call MyBase.MapInvalidate()
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        Dim iRow As Integer = grdLegendItems.CurrentCellAddress.Y
        Call grdLegendItems.Rows.RemoveAt(iRow)
        Call oItem.RemoveItem(iRow)
        Call MyBase.MapInvalidate()
    End Sub

    Private Sub cmdUp_Click(sender As Object, e As EventArgs) Handles cmdUp.Click
        Call MyBase.MapInvalidate()
    End Sub

    Private Sub cmdDown_Click(sender As Object, e As EventArgs) Handles cmdDown.Click
        Call MyBase.MapInvalidate()
    End Sub

    Private Sub grdLegendItems_SelectionChanged(sender As Object, e As EventArgs) Handles grdLegendItems.SelectionChanged
        Call pRebindButtons()
    End Sub

    Private Sub pRebindButtons()
        cmdDeleteAll.Enabled = grdLegendItems.Rows.Count > 0
        If IsNothing(grdLegendItems.CurrentRow) Then
            cmdDelete.Enabled = False
            cmdUp.Enabled = False
            cmdDown.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdUp.Enabled = True
            cmdDown.Enabled = True
        End If
    End Sub

    Private Sub grdLegendItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles grdLegendItems.DataError
        e.ThrowException = False
    End Sub

    Private Sub grdLegendItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles grdLegendItems.CellEndEdit
        Select Case e.ColumnIndex
            Case 1
                Dim oComboCell As DataGridViewComboBoxCell = grdLegendItems.CurrentCell
                oItem.Items(e.RowIndex).Type = oComboCell.Items.IndexOf(oComboCell.Value)
            Case 2
                oItem.Items(e.RowIndex).Text = grdLegendItems.CurrentCell.Value
            Case 3
                oItem.Items(e.RowIndex).Scale = grdLegendItems.CurrentCell.Value
        End Select
        Call MyBase.MapInvalidate()
    End Sub

    Private Sub cmdAutofill_Click(sender As Object, e As EventArgs) Handles cmdAutofill.Click
        Call oItem.AutoFill(Not My.Computer.Keyboard.ShiftKeyDown, cIItemLegend.AutoFillFlagsEnum.None)
        Call MyBase.MapInvalidate()
        Call Reload()
    End Sub

    Private Sub txtPropLegendItemWidth_ValueChanged(sender As Object, e As EventArgs) Handles txtPropLegendItemWidth.ValueChanged
        Try
            If Not DisabledObjectProperty() Then
                oItem.ItemWidth = txtPropLegendItemWidth.Value
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("ItemWidth")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub txtPropLegendItemHeight_ValueChanged(sender As Object, e As EventArgs) Handles txtPropLegendItemHeight.ValueChanged
        Try
            If Not DisabledObjectProperty() Then
                oItem.ItemHeight = txtPropLegendItemHeight.Value
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("ItemHeight")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub txtPropLegendItemVPadding_ValueChanged(sender As Object, e As EventArgs) Handles txtPropLegendItemVPadding.ValueChanged
        Try
            If Not DisabledObjectProperty() Then
                oItem.ItemVPadding = txtPropLegendItemVPadding.Value
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("ItemVPadding")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub txtPropLegendItemHPadding_ValueChanged(sender As Object, e As EventArgs) Handles txtPropLegendItemHPadding.ValueChanged
        Try
            If Not DisabledObjectProperty() Then
                oItem.ItemHPadding = txtPropLegendItemHPadding.Value
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("ItemHPadding")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub txtPropLegendItemScale_ValueChanged(sender As Object, e As EventArgs) Handles txtPropLegendItemScale.ValueChanged
        Try
            If Not DisabledObjectProperty() Then
                oItem.ItemScale = txtPropLegendItemScale.Value
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("ItemScale")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub grdLegendItems_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles grdLegendItems.CellValidating
        Select Case e.ColumnIndex
            Case 3
                Dim oValue As Object = grdLegendItems.CurrentCell.Value
                If Not IsNothing(oValue) AndAlso Not IsDBNull(oValue) AndAlso Not oValue.ToString <> "" Then
                    If IsNumeric(oValue) Then
                        e.Cancel = oValue = 0
                    Else
                        e.Cancel = True
                    End If
                End If
        End Select
    End Sub

    Private Sub txtPropLegendItemRowColMaxItem_ValueChanged(sender As Object, e As EventArgs) Handles txtPropLegendItemRowColMaxItems.ValueChanged
        Try
            If Not DisabledObjectProperty() Then
                oItem.MaxItems = txtPropLegendItemRowColMaxItems.Value
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("MaxItems")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub cboPropLegendItemFlowDirection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropLegendItemFlowDirection.SelectedIndexChanged
        Try
            If Not DisabledObjectProperty() Then
                oItem.FlowDirection = cboPropLegendItemFlowDirection.SelectedIndex
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("FlowDirection")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub cboPropLegendItemAlign_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropLegendItemAlign.SelectedIndexChanged
        Try
            If Not DisabledObjectProperty() Then
                oItem.ItemAlignment = cboPropLegendItemAlign.SelectedIndex
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("ItemAlignment")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub
End Class
