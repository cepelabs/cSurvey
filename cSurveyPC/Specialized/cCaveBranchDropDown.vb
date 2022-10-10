Imports cSurveyPC.cSurvey
Imports DevExpress.XtraGrid.Views.Base

Public Class cCaveBranchDropDown
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(Me, False)
        MyBase.Enabled = False
    End Sub

    Private iWorkmode As cCaveDropDown.WorkmodeEnum

    Public Property Workmode As cCaveDropDown.WorkmodeEnum
        Get
            Return iWorkmode
        End Get
        Set(value As cCaveDropDown.WorkmodeEnum)
            If value <> iWorkmode Then
                iWorkmode = value
                'Call Rebind(osurvey, False)
            End If
        End Set
    End Property

    Private bDisableEvent As Boolean

    Private bAllowEmpty As Boolean

    Public Sub Rebind(Survey As cSurvey.cSurvey, Cave As cCaveDropDown, Optional AllowEmpty As Boolean = True, Optional AllowLocked As cCaveDropDown.AllowLockedEnum = cCaveDropDown.AllowLockedEnum.True)
        Dim sCave As String = cCaveInfo.EditToString(Cave.EditValue)
        bAllowEmpty = AllowEmpty

        bDisableEvent = True
        If sCave = "" Then
            If bAllowEmpty Then
                cboCaveBranchList.Properties.DataSource = New List(Of cCaveInfoBranch)({Survey.Properties.CaveInfos.GetEmptyCaveInfoBranch(sCave)})
            Else
                cboCaveBranchList.Properties.DataSource = New List(Of cCaveInfoBranch)
            End If
            cboCaveBranchList.EditValue = cboCaveBranchList.Properties.DataSource(0)
            MyBase.Enabled = False
        Else
            Dim oCurrentBranch As cCaveInfoBranch = cboCaveBranchList.EditValue

            Dim oItems As IEnumerable(Of cSurvey.cCaveInfoBranch)
            If bAllowEmpty Then
                oItems = Survey.Properties.CaveInfos(sCave).Branches.GetAllBranchesWithEmpty.Select(Function(oitem) oitem.Value)
            Else
                oItems = Survey.Properties.CaveInfos(sCave).Branches.GetAllBranches.Select(Function(oitem) oitem.Value)
            End If
            If AllowLocked = cCaveDropDown.AllowLockedEnum.False Then
                oItems = oItems.Where(Function(oitem) Not oitem.GetLocked)
            ElseIf AllowLocked = cCaveDropDown.AllowLockedEnum.Default AndAlso iWorkmode = cCaveDropDown.WorkmodeEnum.Edit Then
                oItems = oItems.Where(Function(oitem) Not oitem.GetLocked)
            End If
            cboCaveBranchList.Properties.DataSource = oItems.ToList
            If cboCaveBranchList.Properties.DataSource.Count > 0 Then
                Try
                    If oCurrentBranch Is Nothing OrElse Not cboCaveBranchList.Properties.DataSource.contains(oCurrentBranch) Then
                        cboCaveBranchList.EditValue = cboCaveBranchList.Properties.DataSource(0)
                    Else
                        cboCaveBranchList.EditValue = oCurrentBranch
                    End If
                Catch
                    cboCaveBranchList.EditValue = cboCaveBranchList.Properties.DataSource(0)
                End Try
                MyBase.Enabled = True
            Else
                MyBase.Enabled = False
            End If
        End If
        bDisableEvent = False
    End Sub

    Public Property EditValue As cSurvey.cCaveInfoBranch
        Get
            Return cboCaveBranchList.EditValue
        End Get
        Set(value As cSurvey.cCaveInfoBranch)
            If bAllowEmpty Then
                If value Is Nothing Then
                    cboCaveBranchList.EditValue = cboCaveBranchList.Properties.DataSource(0)
                Else
                    cboCaveBranchList.EditValue = value
                End If
            Else
                If value IsNot Nothing Then
                    cboCaveBranchList.EditValue = value
                End If
            End If
        End Set
    End Property

    Public Function SetSelected(Session As cSurvey.cCaveInfoBranch) As Boolean
        EditValue = Session
        Return True
    End Function

    Public Function GetSelected() As cSurvey.cCaveInfoBranch
        Return EditValue
    End Function

    Public ReadOnly Property Count() As Integer
        Get
            Return cboCaveBranchList.Properties.DataSource.count
        End Get
    End Property

    Private Sub cCaveBranchDropDown_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If MyBase.Height <> cboCaveBranchList.Height Then
            MyBase.Height = cboCaveBranchList.Height
        End If
    End Sub

    Public Event CustomRowFilter As RowFilterEventHandler

    Private Sub cboCaveBranchListView_CustomRowFilter(sender As Object, e As RowFilterEventArgs) Handles cboCaveBranchListView.CustomRowFilter
        RaiseEvent CustomRowFilter(Me, e)
    End Sub

    Public Event EditValueChanged As EventHandler

    Private Sub cboCaveBranchList_EditValueChanged(sender As Object, e As EventArgs) Handles cboCaveBranchList.EditValueChanged
        If Not bDisableEvent Then
            RaiseEvent EditValueChanged(Me, e)
        End If
    End Sub

    Public Event EditRequest As EventHandler

    Private Sub cboCaveBranchList_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboCaveBranchList.ButtonClick
        If e.Button.Index = 1 Then
            RaiseEvent EditRequest(Me, EventArgs.Empty)
        End If
    End Sub
End Class
