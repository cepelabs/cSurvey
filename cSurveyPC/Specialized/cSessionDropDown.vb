Imports DevExpress.XtraGrid.Views.Base

Public Class cSessionDropDown
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(Me, False)
        MyBase.Enabled = False
    End Sub

    Private bAllowEmpty As Boolean

    Public Delegate Function FilterDelegate(Session As cSurvey.cSession) As Boolean

    Public Function Rebind(Survey As cSurvey.cSurvey, Reset As Boolean, AllowEmpty As Boolean, Filter As FilterDelegate) As Boolean
        Dim oSession As cSurvey.cSession = Nothing
        If Not Reset Then oSession = cboSessionList.EditValue
        bAllowEmpty = AllowEmpty

        Dim oItems As IEnumerable(Of cSurvey.cSession)
        If bAllowEmpty Then
            oItems = Survey.Properties.Sessions.GetWithEmpty.Select(Function(oitem) oitem.Value)
        Else
            oItems = Survey.Properties.Sessions.GetAllSessions.Select(Function(oitem) oitem.Value)
        End If

        cboSessionList.Properties.DataSource = If(Filter Is Nothing, oItems.ToList, oItems.Where(Function(oFilterSession)
                                                                                                     If (AllowEmpty AndAlso oFilterSession.ID = "") Then
                                                                                                         Return True
                                                                                                     Else
                                                                                                         Return Filter(oFilterSession)
                                                                                                     End If
                                                                                                 End Function).ToList)
        Try
            If oSession Is Nothing Then
                cboSessionList.EditValue = cboSessionList.Properties.DataSource(0)
            Else
                cboSessionList.EditValue = oSession
            End If
        Catch
            cboSessionList.EditValue = cboSessionList.Properties.DataSource(0)
        End Try

        Dim bEnabled As Boolean = Count > 0
        MyBase.Enabled = bEnabled
        Return bEnabled
    End Function

    Public Function Rebind(Survey As cSurvey.cSurvey, Reset As Boolean, AllowEmpty As Boolean) As Boolean
        Return Rebind(Survey, Reset, AllowEmpty, Nothing)
    End Function

    Public Function Rebind(Survey As cSurvey.cSurvey, Reset As Boolean) As Boolean
        Return Rebind(Survey, Reset, True, Nothing)
    End Function

    Public Property EditValue As cSurvey.cSession
        Get
            Return cboSessionList.EditValue
        End Get
        Set(value As cSurvey.cSession)
            If bAllowEmpty Then
                If value Is Nothing Then
                    cboSessionList.EditValue = cboSessionList.Properties.DataSource(0)
                Else
                    cboSessionList.EditValue = value
                End If
            Else
                If value IsNot Nothing Then
                    cboSessionList.EditValue = value
                End If
            End If
        End Set
    End Property

    Public Function SetSelected(Session As cSurvey.cSession) As Boolean
        EditValue = Session
        Return True
    End Function

    Public Function GetSelected() As cSurvey.cSession
        Return EditValue
    End Function

    Public ReadOnly Property Count() As Integer
        Get
            Return cboSessionList.Properties.DataSource.count
        End Get
    End Property

    Private Sub cSessionDropDown_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If MyBase.Height <> cboSessionList.Height Then
            MyBase.Height = cboSessionList.Height
        End If
    End Sub

    Public Event CustomRowFilter As RowFilterEventHandler

    Private Sub cboSessionListView_CustomRowFilter(sender As Object, e As RowFilterEventArgs) Handles cboSessionListView.CustomRowFilter
        RaiseEvent CustomRowFilter(Me, e)
    End Sub

    Public Event EditValueChanged As EventHandler

    Private Sub cboCaveList_EditValueChanged(sender As Object, e As EventArgs) Handles cboSessionList.EditValueChanged
        RaiseEvent EditValueChanged(Me, e)
    End Sub
End Class
