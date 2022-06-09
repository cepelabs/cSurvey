Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Friend Class cItemLegendPropertyControl

    Public Shadows ReadOnly Property Item As cItemLegend
        Get
            Return MyBase.Item
        End Get
    End Property

    Private Class cLegendType
        Private iValue As cItemLegend.cLegendItem.ItemTypeEnum
        Private sText As String

        Public ReadOnly Property Value As cItemLegend.cLegendItem.ItemTypeEnum
            Get
                Return iValue
            End Get
        End Property

        Public ReadOnly Property Text As String
            Get
                Return sText
            End Get
        End Property

        Public Sub New(Value As cItemLegend.cLegendItem.ItemTypeEnum)
            iValue = Value
            sText = modMain.GetLocalizedString("itemlegend.type" & iValue)
        End Sub
    End Class

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() 
        Try
            For Each iValue As cItemLegend.cLegendItem.ItemTypeEnum In [Enum].GetValues(GetType(cItemLegend.cLegendItem.ItemTypeEnum))
                cboItemsType.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(modMain.GetLocalizedString("itemlegend.type" & iValue.ToString("D")), DirectCast(iValue, Object)))
            Next
        Catch ex As Exception
        End Try

        'Try
        '    For Each iValue As Integer In [Enum].GetValues(GetType(cItemLegend.cLegendItem.ItemTypeEnum))
        '        Call colLegendType.Items.Add(modMain.GetLocalizedString("itemlegend.type" & iValue))
        '    Next
        'Catch ex As Exception
        'End Try
    End Sub

    Public Shadows Sub Rebind(Item As cItemLegend)
        MyBase.Rebind(Item)

        txtPropLegendItemWidth.Value = Me.Item.ItemWidth
        txtPropLegendItemHeight.Value = Me.Item.ItemHeight
        txtPropLegendItemHPadding.Value = Me.Item.ItemHPadding
        txtPropLegendItemVPadding.Value = Me.Item.ItemVPadding

        txtPropLegendItemScale.Value = Me.Item.ItemScale

        txtPropLegendItemRowColMaxItems.Value = Me.Item.MaxItems
        cboPropLegendItemFlowDirection.SelectedIndex = Me.Item.FlowDirection
        cboPropLegendItemAlign.SelectedIndex = Me.Item.ItemAlignment

        Call Reload()
    End Sub

    Public Sub Reload()
        Call GridControl1.BeginUpdate()
        GridControl1.DataSource = Item.Items
        Call GridControl1.EndUpdate()
        Call pRebindButtons()
    End Sub

    Private Sub cmdDeleteAll_Click(sender As Object, e As EventArgs) Handles cmdDeleteAll.Click
        Call Item.ClearItems()
        Call GridView1.RefreshData()
        Call MyBase.MapInvalidate()

        'Call grdLegendItems.Rows.Clear()
        'Call Item.ClearItems()
        'Call MyBase.MapInvalidate()
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        Dim oItem As cItemLegend.cLegendItem = GridView1.GetFocusedObject
        If Not oItem Is Nothing Then
            Call Item.RemoveItem(oItem)
            Call GridView1.RefreshData()
        End If
        'Dim iRow As Integer = grdLegendItems.CurrentCellAddress.Y
        'Call grdLegendItems.Rows.RemoveAt(iRow)
        'Call Item.RemoveItem(iRow)
        Call MyBase.MapInvalidate()
    End Sub

    Private Sub cmdUp_Click(sender As Object, e As EventArgs) Handles cmdUp.Click
        Dim oItem As cItemLegend.cLegendItem = GridView1.GetFocusedObject
        If Not oItem Is Nothing Then
            Call Item.MoveItem(oItem, Item.Items.IndexOf(oItem) - 1)
            Call GridView1.RefreshData()
            Call GridView1.SetFocusedObject(oItem)
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cmdDown_Click(sender As Object, e As EventArgs) Handles cmdDown.Click
        Dim oItem As cItemLegend.cLegendItem = GridView1.GetFocusedObject
        If Not oItem Is Nothing Then
            Call Item.MoveItem(oItem, Item.Items.IndexOf(oItem) + 1)
            Call GridView1.RefreshData()
            Call GridView1.SetFocusedObject(oItem)
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub pRebindButtons()
        cmdDeleteAll.Enabled = GridView1.RowCount > 0
        If IsNothing(GridView1.GetFocusedObject) Then
            cmdDelete.Enabled = False
            cmdUp.Enabled = False
            cmdDown.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdUp.Enabled = True
            cmdDown.Enabled = True
        End If
    End Sub

    'Private Sub grdLegendItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
    '    e.ThrowException = False
    'End Sub

    'Private Sub grdLegendItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
    '    Select Case e.ColumnIndex
    '        Case 1
    '            Dim oComboCell As DataGridViewComboBoxCell = grdLegendItems.CurrentCell
    '            Item.Items(e.RowIndex).Type = oComboCell.Items.IndexOf(oComboCell.Value)
    '        Case 2
    '            Item.Items(e.RowIndex).Text = grdLegendItems.CurrentCell.Value
    '        Case 3
    '            Item.Items(e.RowIndex).Scale = grdLegendItems.CurrentCell.Value
    '    End Select
    '    Call MyBase.MapInvalidate()
    'End Sub

    Private Sub cmdAutofill_Click(sender As Object, e As EventArgs) Handles cmdAutofill.Click
        Call Item.AutoFill(Not My.Computer.Keyboard.ShiftKeyDown, cIItemLegend.AutoFillFlagsEnum.None)
        Call GridView1.RefreshData()
        Call MyBase.MapInvalidate()
        Call Reload()
    End Sub

    Private Sub txtPropLegendItemWidth_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropLegendItemWidth.EditValueChanged
        Try
            If Not DisabledObjectProperty() Then
                Item.ItemWidth = txtPropLegendItemWidth.Value
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("ItemWidth")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub txtPropLegendItemHeight_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropLegendItemHeight.EditValueChanged
        Try
            If Not DisabledObjectProperty() Then
                Item.ItemHeight = txtPropLegendItemHeight.Value
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("ItemHeight")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub txtPropLegendItemVPadding_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropLegendItemVPadding.EditValueChanged
        Try
            If Not DisabledObjectProperty() Then
                Item.ItemVPadding = txtPropLegendItemVPadding.Value
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("ItemVPadding")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub txtPropLegendItemHPadding_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropLegendItemHPadding.EditValueChanged
        Try
            If Not DisabledObjectProperty() Then
                Item.ItemHPadding = txtPropLegendItemHPadding.Value
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
                Item.ItemScale = txtPropLegendItemScale.Value
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("ItemScale")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    'Private Sub grdLegendItems_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs)
    '    Select Case e.ColumnIndex
    '        Case 3
    '            Dim oValue As Object = grdLegendItems.CurrentCell.Value
    '            If Not IsNothing(oValue) AndAlso Not IsDBNull(oValue) AndAlso Not oValue.ToString <> "" Then
    '                If IsNumeric(oValue) Then
    '                    e.Cancel = oValue = 0
    '                Else
    '                    e.Cancel = True
    '                End If
    '            End If
    '    End Select
    'End Sub

    Private Sub txtPropLegendItemRowColMaxItem_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropLegendItemRowColMaxItems.EditValueChanged
        Try
            If Not DisabledObjectProperty() Then
                Item.MaxItems = txtPropLegendItemRowColMaxItems.Value
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
                Item.FlowDirection = cboPropLegendItemFlowDirection.SelectedIndex
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
                Item.ItemAlignment = cboPropLegendItemAlign.SelectedIndex
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("ItemAlignment")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Call pRebindButtons()
    End Sub

    Private Sub txtItemsScale_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtItemsScale.Validating
        e.Cancel = DirectCast(sender, DevExpress.XtraEditors.SpinEdit).EditValue <= 0
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Call MyBase.MapInvalidate()
    End Sub
End Class
