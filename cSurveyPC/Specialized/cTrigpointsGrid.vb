Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Helper.Editor
Imports cSurveyPC.cSurvey.UIHelpers
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class cTrigpointsGrid
    Private oSurvey As cSurvey.cSurvey
    Public ReadOnly Property Survey As cSurveyPC.cSurvey.cSurvey
        Get
            Return oSurvey
        End Get
    End Property
    Public Class cTrigpointsGridParameters
        Public Enum SelectionStyleEnum
            [Single] = 1
            Multiple = 2
            MultipleWithCheckboxes = 3
        End Enum

        Private iSelectionStyle As SelectionStyleEnum

        Private bSplay As Boolean

        Public Property Splay As Boolean
            Get
                Return bSplay
            End Get
            Set(value As Boolean)
                bSplay = value
            End Set
        End Property

        Public Sub New()
            iSelectionStyle = SelectionStyleEnum.Single
        End Sub

        Public Sub New(SelectionStyle As SelectionStyleEnum)
            iSelectionStyle = SelectionStyle
        End Sub

        Public Sub New(SelectionStyle As SelectionStyleEnum, Splay As Boolean)
            iSelectionStyle = SelectionStyle
            bSplay = Splay
        End Sub

        Public ReadOnly Property SelectionStyle As SelectionStyleEnum
            Get
                Return iSelectionStyle
            End Get
        End Property
    End Class

    Public Sub Unbind()
        oSurvey = Nothing
        Call grdTrigpoints.BeginUpdate()
        grdTrigpoints.DataSource = Nothing
        oTrigpoints = Nothing
        Call grdTrigpoints.EndUpdate()
    End Sub

    Public Sub RefreshDataSource()
        Call grdTrigpoints.RefreshDataSource()
    End Sub

    Public Sub BeginUpdate()
        Call grdTrigpoints.BeginUpdate()
    End Sub

    Public Sub EndUpdate()
        Call grdTrigpoints.EndUpdate()
    End Sub

    Public Sub UnuseAll()
        Call grdTrigpoints.BeginUpdate()
        Call oTrigpoints.UnuseAll()
        Call grdTrigpoints.EndUpdate()
    End Sub

    Public Sub Unuse(Trigpoint As String)
        Call grdTrigpoints.BeginUpdate()
        Call oTrigpoints.Unuse(oSurvey.TrigPoints(Trigpoint))
        Call grdTrigpoints.EndUpdate()
    End Sub

    Public Sub Unuse(Trigpoint As cTrigPoint)
        Call grdTrigpoints.BeginUpdate()
        Call oTrigpoints.Unuse(Trigpoint)
        Call grdTrigpoints.EndUpdate()
    End Sub

    Public Sub Use(Trigpoint As String)
        Call grdTrigpoints.BeginUpdate()
        Call oTrigpoints.Use(oSurvey.TrigPoints(Trigpoint))
        Call grdTrigpoints.EndUpdate()
    End Sub

    Public Sub Use(Trigpoint As cTrigPoint)
        Call grdTrigpoints.BeginUpdate()
        Call oTrigpoints.Use(Trigpoint)
        Call grdTrigpoints.EndUpdate()
    End Sub

    Private oTrigpoints As UIHelpers.cTrigpointByCaveBindinglist
    Private oParameters As cTrigpointsGridParameters

    Public Sub Rebind(Survey As cSurvey.cSurvey, Trigpoints As UIHelpers.cTrigpointByCaveBindinglist, Parameters As cTrigpointsGridParameters)
        oSurvey = Survey
        Call grdTrigpoints.BeginUpdate()
        bSplay = Parameters.Splay
        oTrigpoints = Trigpoints
        oParameters = Parameters
        Select Case oTrigpoints.Style
            Case cTrigpointByCaveBindinglist.StyleEnum.Uniquelist
                grdViewTrigpoints.Columns.Item("CaveHTML").Visible = False
                grdViewTrigpoints.Columns.Item("BranchHTML").Visible = False
                grdViewTrigpoints.Columns.Item("CavesAndBranchesHTML").Visible = False
            Case cTrigpointByCaveBindinglist.StyleEnum.UniquelistWithCaveAndBranch
                grdViewTrigpoints.Columns.Item("CaveHTML").Visible = False
                grdViewTrigpoints.Columns.Item("BranchHTML").Visible = False
                grdViewTrigpoints.Columns.Item("CavesAndBranchesHTML").Visible = True
            Case Else
                grdViewTrigpoints.Columns.Item("CaveHTML").Visible = True
                grdViewTrigpoints.Columns.Item("BranchHTML").Visible = True
                grdViewTrigpoints.Columns.Item("CavesAndBranchesHTML").Visible = False
        End Select

        If Parameters.SelectionStyle = cTrigpointsGridParameters.SelectionStyleEnum.MultipleWithCheckboxes Then
            grdViewTrigpoints.Columns.Item("Selected").Visible = True
            grdViewTrigpoints.OptionsSelection.MultiSelect = True
        Else
            grdViewTrigpoints.Columns.Item("Selected").Visible = False
            If Parameters.SelectionStyle = cTrigpointsGridParameters.SelectionStyleEnum.Multiple Then
                grdViewTrigpoints.OptionsSelection.MultiSelect = True
            Else
                grdViewTrigpoints.OptionsSelection.MultiSelect = False
            End If
        End If
        grdTrigpoints.DataSource = oTrigpoints
        Call grdTrigpoints.EndUpdate()
    End Sub

    Public ReadOnly Property Count As Integer
        Get
            Return grdViewTrigpoints.RowCount
        End Get
    End Property

    Public ReadOnly Property CheckedItems As List(Of cTrigPoint)
        Get
            If oParameters.SelectionStyle = cTrigpointsGridParameters.SelectionStyleEnum.MultipleWithCheckboxes Then
                Return oTrigpoints.Where(Function(oitem) oitem.Selected).Select(Function(oitem) oitem.Trigpoint).Distinct.ToList
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property Items As List(Of cTrigPoint)
        Get
            Return oTrigpoints.Select(Function(oPlaceholder) oPlaceholder.Trigpoint).Distinct.ToList
        End Get
    End Property

    Public Sub Add(Item As cTrigPoint)
        Call grdTrigpoints.BeginUpdate()
        Call oTrigpoints.Add(Item, False)
        Call grdTrigpoints.EndUpdate()
    End Sub

    Public Sub AddRange(Items As List(Of cTrigPoint))
        Call grdTrigpoints.BeginUpdate()
        Call oTrigpoints.AddRange(Items, False)
        Call grdTrigpoints.EndUpdate()
    End Sub

    Public Sub RemoveRange(Items As List(Of cTrigPoint))
        Call grdTrigpoints.BeginUpdate()
        Call oTrigpoints.Removerange(Items)
        Call grdTrigpoints.EndUpdate()
    End Sub

    Public Sub Remove(Item As cTrigPoint)
        Call grdTrigpoints.BeginUpdate()
        Call oTrigpoints.Remove(Item)
        Call grdTrigpoints.EndUpdate()
    End Sub

    Public Sub UnuseRange(Items As List(Of cTrigPoint))
        Call grdTrigpoints.BeginUpdate()
        Call oTrigpoints.UnuseRange(Items)
        Call grdTrigpoints.EndUpdate()
    End Sub

    Public Sub UseRange(Items As List(Of cTrigPoint))
        Call grdTrigpoints.BeginUpdate()
        Call oTrigpoints.UseRange(Items)
        Call grdTrigpoints.EndUpdate()
    End Sub

    Public Sub Clear()
        Call oTrigpoints.Clear()
    End Sub

    Public ReadOnly Property SelectedItems As List(Of cTrigPoint)
        Get
            If oParameters.SelectionStyle = cTrigpointsGridParameters.SelectionStyleEnum.Multiple OrElse oParameters.SelectionStyle = cTrigpointsGridParameters.SelectionStyleEnum.MultipleWithCheckboxes Then
                Dim oItems As List(Of cTrigPoint) = grdViewTrigpoints.GetSelectedRows.Select(Function(iRowHandle As Integer) DirectCast(grdViewTrigpoints.GetRow(iRowHandle), cTrigpointByCavePlaceholder).Trigpoint).Distinct.ToList
                Dim oFocusedTrigpoint As cTrigPoint = FocusedItem
                If oFocusedTrigpoint IsNot Nothing AndAlso Not oItems.Contains(oFocusedTrigpoint) Then
                    Call oItems.Add(oFocusedTrigpoint)
                End If
                Return oItems
            Else
                Return New List(Of cTrigPoint)({FocusedItem})
            End If
        End Get
    End Property

    Public Property FocusedItem As cTrigPoint
        Get
            Dim oPlaceholder As cTrigpointByCavePlaceholder = grdViewTrigpoints.GetFocusedObject
            If oPlaceholder Is Nothing Then
                Return Nothing
            Else
                Return oPlaceholder.Trigpoint
            End If
        End Get
        Set(value As cTrigPoint)
            If oTrigpoints IsNot Nothing Then
                If value Is Nothing Then
                    Call grdViewTrigpoints.SetFocusedObject(Nothing)
                Else
                    Call grdViewTrigpoints.SetFocusedObject(oTrigpoints.Find(value))
                End If
            End If
        End Set
    End Property

    Public ReadOnly Property SelectedItem As cTrigPoint
        Get
            If oParameters.SelectionStyle = cTrigpointsGridParameters.SelectionStyleEnum.Multiple Then
                Return Nothing
            Else
                Return FocusedItem
            End If
        End Get
    End Property

    Public Class cSelectionChangedEventArgs
        Inherits EventArgs

        Private oSelectedItem As cTrigPoint

        Public Sub New(SelectedItem As cTrigPoint)
            oSelectedItem = SelectedItem
        End Sub

        Public ReadOnly Property SelectedItem As cTrigPoint
            Get
                Return oSelectedItem
            End Get
        End Property
    End Class

    Public Event SelectionChanged(sender As Object, e As cSelectionChangedEventArgs)

    Private Sub grdViewTrigpoints_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles grdViewTrigpoints.FocusedRowChanged
        Dim oTrigpoint As cTrigPoint = Nothing
        Dim oPlaceholder As cTrigpointByCavePlaceholder = grdViewTrigpoints.GetFocusedObject
        If oPlaceholder IsNot Nothing Then
            oTrigpoint = oPlaceholder.Trigpoint
        End If
        RaiseEvent SelectionChanged(Me, New cSelectionChangedEventArgs(oTrigpoint))
    End Sub

    'Private Sub grdViewTrigpoints_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs) Handles grdViewTrigpoints.CustomUnboundColumnData
    '    If e.IsGetData Then
    '        Dim oTrigpoint As UIHelpers.cTrigpointByCavePlaceholder = e.Row
    '        If Not oTrigpoint Is Nothing Then
    '            Select Case e.Column.FieldName
    '                Case "_Splay"
    '                    e.Value =  oTrigpoint.Splay
    '                Case "_Special"
    '                    e.Value = oTrigpoint.IsSpecial
    '                Case "_InExploration"
    '                    e.Value = oTrigpoint.IsInExploration
    '                Case "_Entrance"
    '                    e.Value = oTrigpoint.Entrance
    '                Case "_Cave"
    '                    e.Value = oTrigpoint.CaveHTML
    '                Case "_Branch"
    '                    e.Value = oTrigpoint.BranchHTML
    '            End Select
    '        End If
    '    End If
    'End Sub

    Public Event ContextMenuShowing(sender As Object, e As MouseEventArgs)

    Private Sub grdViewTrigpoints_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles grdViewTrigpoints.PopupMenuShowing
        If e.HitInfo.InRowCell OrElse e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.EmptyRow Then
            e.Allow = False
            Dim oScreenPoint As Point = grdTrigpoints.PointToScreen(e.Point)
            RaiseEvent ContextMenuShowing(sender, New MouseEventArgs(MouseButtons.Right, 1, oScreenPoint.X, oScreenPoint.Y, 0))
        End If
    End Sub

    Private Sub grdViewTrigpoints_FilterPopupExcelData(sender As Object, e As FilterPopupExcelDataEventArgs) Handles grdViewTrigpoints.FilterPopupExcelData

    End Sub

    Public Property Splay As Boolean
        Get
            Return bSplay
        End Get
        Set(value As Boolean)
            If bSplay <> value Then
                bSplay = value
                Call grdTrigpoints.RefreshDataSource()
            End If
        End Set
    End Property

    Private bSplay As Boolean
    Private Sub grdViewTrigpoints_CustomRowFilter(sender As Object, e As RowFilterEventArgs) Handles grdViewTrigpoints.CustomRowFilter
        If Not bSplay Then
            e.Visible = oTrigpoints(e.ListSourceRow).Splay
            e.Handled = True
        End If
    End Sub

    Private Sub grdViewTrigpoints_DoubleClick(sender As Object, e As EventArgs) Handles grdViewTrigpoints.DoubleClick
        RaiseEvent DoubleClick(Me, EventArgs.Empty)
    End Sub

    Public Shadows Event DoubleClick As EventHandler

End Class
