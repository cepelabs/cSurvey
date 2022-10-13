Imports System.Data
Imports DevExpress.XtraVerticalGrid.Rows
Imports DevExpress.XtraVerticalGrid.Events
Imports System.ComponentModel

Public Class cVerticalGrid
    Inherits DevExpress.XtraVerticalGrid.VGridControl

    Private oDataSource As DataTable

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overloads Property Datasource As Object
        Get
            Return MyBase.DataSource
        End Get
        Set(value As Object)
            MyBase.DataSource = value
        End Set
    End Property

    Public Sub New()
        oDataSource = New DataTable
        MyBase.DataSource = oDataSource
        MyBase.OptionsView.AllowHtmlText = True

        AddHandler MyBase.PopupMenuShowing, AddressOf mybase_PopupMenuShowing
    End Sub

    Public Sub SetValue(FieldName As String, Type As Type, Value As Object)
        If Not oDataSource.Columns.Contains(FieldName) Then
            Call oDataSource.Columns.Add(FieldName, Type)
        End If
        If oDataSource.Rows.Count = 0 Then
            Call CreateValueSet()
        End If
        oDataSource.Rows(oDataSource.Rows.Count - 1)(FieldName) = Value
        MyBase.RefreshDataSource()
    End Sub

    Public Sub ClearAll()
        Call MyBase.Rows.Clear()
        Call oDataSource.Rows.Clear()
    End Sub

    Public Sub ClearValues()
        Call oDataSource.Rows.Clear()
    End Sub

    Public Sub CreateValueSet()
        Call oDataSource.Rows.Add(oDataSource.NewRow)
    End Sub

    Public Function GetBaseObject(ValueSetIndex As Integer)
        If oDataSource.Columns.Contains("_baseobject") Then
            Return oDataSource.Rows(ValueSetIndex)("_baseobject")
        End If
    End Function

    Public Sub CreateValueSet(BaseObject As Object)
        If Not oDataSource.Columns.Contains("_baseobject") Then
            oDataSource.Columns.Add("_baseobject", GetType(System.Object))
        End If
        Call oDataSource.Rows.Add(oDataSource.NewRow)
        oDataSource.Rows(oDataSource.Rows.Count - 1)("_baseobject") = BaseObject
    End Sub

    Public Function RowAdd(FieldName As String, Caption As String, Value As Object) As EditorRow
        Return RowAdd(FieldName, Caption, GetType(System.String), Value)
    End Function

    Public Function RowAdd(ParentRow As EditorRow, FieldName As String, Caption As String, Value As Object) As EditorRow
        Return RowAdd(ParentRow, FieldName, Caption, GetType(System.String), Value)
    End Function

    Public Function SetAsButtonEdit(Row As EditorRow, ButtonClick As DevExpress.XtraEditors.Controls.ButtonPressedEventHandler) As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
        Dim oButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = MyBase.RepositoryItems.Add("ButtonEdit")
        oButtonEdit.Buttons.Clear()
        Row.Properties.RowEdit = oButtonEdit
        AddHandler oButtonEdit.ButtonClick, ButtonClick
        Return oButtonEdit
    End Function

    'Private oHTMLEdit As DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel

    Public Function RowAdd(ParentRow As EditorRow, FieldName As String, Caption As String, Type As Type, Value As Object) As EditorRow
        Dim oRow As EditorRow = MyBase.Rows.GetRowByFieldName(FieldName, True)
        If oRow Is Nothing Then
            oRow = New EditorRow(FieldName)
            oRow.Properties.Caption = Caption
            oRow.Properties.ReadOnly = True
            oRow.Properties.AllowEdit = True
            oRow.OptionsRow.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True
            'If oHTMLEdit Is Nothing Then
            '    oHTMLEdit = MyBase.RepositoryItems.Add("HypertextLabel")
            '    oHTMLEdit.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True
            'End If
            'oRow.Properties.RowEdit = oHTMLEdit
            ParentRow.ChildRows.Add(oRow)
        End If
        Call SetValue(FieldName, Type, Value)
        Return oRow
    End Function

    Public Function RowAdd(FieldName As String, Caption As String, Type As Type, Value As Object) As EditorRow
        Dim oRow As EditorRow = MyBase.Rows.GetRowByFieldName(FieldName, True)
        If oRow Is Nothing Then
            oRow = New EditorRow(FieldName)
            oRow.Properties.Caption = Caption
            oRow.Properties.ReadOnly = True
            oRow.Properties.AllowEdit = True
            oRow.OptionsRow.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True
            'If oHTMLEdit Is Nothing Then
            '    oHTMLEdit = MyBase.RepositoryItems.Add("HypertextLabel")
            '    oHTMLEdit.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True
            'End If
            'oRow.Properties.RowEdit = oHTMLEdit
            MyBase.Rows.Add(oRow)
        End If
        Call SetValue(FieldName, Type, Value)
        Return oRow
    End Function

    Private Sub mybase_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs)
        'e.Menu.Enabled = False
        e.Menu.Items.Remove(e.Menu.Items.FirstOrDefault(Function(oitem) oitem.Tag = DevExpress.XtraVerticalGrid.Localization.VGridStringId.MenuRowCustomization))
        'Call mnuContext.ShowPopup(Cursor.Position)
    End Sub
End Class
