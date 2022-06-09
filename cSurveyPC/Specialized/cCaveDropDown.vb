Imports DevExpress.XtraGrid.Views.Base

Public Class cCaveDropDown
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(Me, False)
        MyBase.Enabled = False
    End Sub

    Public Enum WorkmodeEnum
        View = 0    'show and allow selection of locked item
        Edit = 1    'hide locked item
    End Enum

    Private iWorkmode As WorkmodeEnum

    Public Property Workmode As WorkmodeEnum
        Get
            Return iWorkmode
        End Get
        Set(value As WorkmodeEnum)
            If value <> iWorkmode Then
                iWorkmode = value
                'Call Rebind(osurvey, False)
            End If
        End Set
    End Property

    Public Enum AllowLockedEnum
        [Default] = 0
        [True] = 1
        [False] = 2
    End Enum

    Private bAllowEmpty As Boolean

    Public Function Rebind(Survey As cSurvey.cSurvey, Reset As Boolean, Optional AllowEmpty As Boolean = True, Optional AllowLocked As AllowLockedEnum = AllowLockedEnum.True) As Boolean
        Dim oCave As cSurvey.cCaveInfo = Nothing
        If Not Reset Then oCave = cboCaveList.EditValue
        bAllowEmpty = AllowEmpty

        Dim oItems As IEnumerable(Of cSurvey.cCaveInfo)
        If bAllowEmpty Then
            oItems = Survey.Properties.CaveInfos.GetWithEmpty.Select(Function(oitem) oitem.Value)
        Else
            oItems = Survey.Properties.CaveInfos.GetAllCaves.Select(Function(oitem) oitem.Value)
        End If
        If AllowLocked = AllowLockedEnum.False Then
            oItems = oItems.Where(Function(oitem) Not oitem.GetLocked)
        ElseIf AllowLocked = AllowLockedEnum.Default AndAlso iWorkmode = WorkmodeEnum.Edit Then
            oItems = oItems.Where(Function(oitem) Not oitem.GetLocked)
        End If
        cboCaveList.Properties.DataSource = oItems.ToList
        Try
            If oCave Is Nothing Then
                If cboCaveList.Properties.DataSource.count > 0 Then
                    cboCaveList.EditValue = cboCaveList.Properties.DataSource(0)
                End If
            Else
                cboCaveList.EditValue = oCave
            End If
        Catch
            If cboCaveList.Properties.DataSource.count > 0 Then
                cboCaveList.EditValue = cboCaveList.Properties.DataSource(0)
            End If
        End Try

        Dim bEnabled As Boolean = Count > 0
        MyBase.Enabled = bEnabled
        Return bEnabled
    End Function

    Public Property EditValue As cSurvey.cCaveInfo
        Get
            Return cboCaveList.EditValue
        End Get
        Set(value As cSurvey.cCaveInfo)
            If bAllowEmpty Then
                If value Is Nothing Then
                    cboCaveList.EditValue = cboCaveList.Properties.DataSource(0)
                Else
                    cboCaveList.EditValue = value
                End If
            Else
                If value IsNot Nothing Then
                    cboCaveList.EditValue = value
                End If
            End If
        End Set
    End Property

    Public Function SetSelected(Session As cSurvey.cCaveInfo) As Boolean
        EditValue = Session
        Return True
    End Function

    Public Function GetSelected() As cSurvey.cCaveInfo
        Return EditValue
    End Function

    Public ReadOnly Property Count() As Integer
        Get
            Return cboCaveList.Properties.DataSource.count
        End Get
    End Property

    Private Sub cCaveDropDown_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If MyBase.Height <> cboCaveList.Height Then
            MyBase.Height = cboCaveList.Height
        End If
    End Sub

    Public Event CustomRowFilter As RowFilterEventHandler

    Private Sub cboCaveListView_CustomRowFilter(sender As Object, e As RowFilterEventArgs) Handles cboCaveListView.CustomRowFilter
        RaiseEvent CustomRowFilter(Me, e)
    End Sub

    Public Event EditValueChanged As EventHandler

    Private Sub cboCaveList_EditValueChanged(sender As Object, e As EventArgs) Handles cboCaveList.EditValueChanged
        RaiseEvent EditValueChanged(Me, e)
    End Sub
End Class
