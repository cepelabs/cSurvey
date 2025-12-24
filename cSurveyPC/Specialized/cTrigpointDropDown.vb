Imports System.ComponentModel
Imports cSurveyPC.cSurvey.UIHelpers
Imports DevExpress.XtraGrid.Views.Base

Public Class cTrigpointDropDown
    Private oSurvey As cSurvey.cSurvey
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(Me, False)
        cboTrigpoint.Enabled = False
    End Sub

    Private bAllowNull As Boolean
    Private bAllowSplay As Boolean
    ''' <summary>
    ''' Load station's list only with currenttrigpoint and with the specificated settings.
    ''' </summary>
    ''' <param name="Survey"></param>
    ''' <param name="CurrentTrigpoint">Selected station</param>
    ''' <param name="AllowNull">Allow empty value</param>
    ''' <param name="AllowSplay">Allow splay stations</param>
    ''' <returns></returns>
    Public Function FastRebind(Survey As cSurvey.cSurvey, ByVal CurrentTrigpoint As String, Optional AllowNull As Boolean = False, Optional AllowSplay As Boolean = False) As Boolean
        oSurvey = Survey

        Dim oCurrentTrigpoint As cSurvey.cTrigPoint = Nothing
        If "" & CurrentTrigpoint <> "" Then
            oCurrentTrigpoint = Survey.TrigPoints(CurrentTrigpoint)
        End If

        bAllowNull = AllowNull
        bAllowSplay = AllowSplay

        If bAllowNull Then
            cboTrigpoint.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
            cboTrigpoint.Properties.NullText = ""
            cboTrigpoint.Properties.ShowClearButton = True
        Else
            cboTrigpoint.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
            cboTrigpoint.Properties.ShowClearButton = False
        End If

        Dim oSourceTrigpoints As List(Of cSurvey.cTrigPoint) = New List(Of cSurvey.cTrigPoint)
        If bAllowNull Then oSourceTrigpoints.Add(Nothing)
        If oCurrentTrigpoint IsNot Nothing Then Call oSourceTrigpoints.Add(oCurrentTrigpoint)
        cboTrigpoint.Properties.DataSource = oSourceTrigpoints

        If bAllowNull Then
            cboTrigpoint.EditValue = CurrentTrigpoint
        Else
            If oCurrentTrigpoint Is Nothing Then
                If oSourceTrigpoints.Count > 0 Then
                    cboTrigpoint.EditValue = oSourceTrigpoints(0).Name
                End If
            Else
                cboTrigpoint.EditValue = CurrentTrigpoint
            End If
        End If

        Dim bEnabled As Boolean = bAllowNull OrElse oSourceTrigpoints.Count > 0
        cboTrigpoint.Enabled = bEnabled
        Return bEnabled
    End Function

    ''' <summary>
    ''' Load the entire station's list (like a standard combo)
    ''' </summary>
    ''' <param name="Survey"></param>
    ''' <param name="CurrentTrigpoint">Selected station</param>
    ''' <param name="AllowNull">Allow empty value</param>
    ''' <param name="AllowSplay">Allow splay stations</param>
    ''' <returns></returns>
    Public Function Rebind(Survey As cSurvey.cSurvey, ByVal CurrentTrigpoint As String, Optional AllowNull As Boolean = False, Optional AllowSplay As Boolean = False) As Boolean
        oSurvey = Survey

        Dim oCurrentTrigpoint As cSurvey.cTrigPoint = Nothing
        If "" & CurrentTrigpoint <> "" Then
            oCurrentTrigpoint = Survey.TrigPoints(CurrentTrigpoint)
        End If

        bAllowNull = AllowNull
        bAllowSplay = AllowSplay

        If bAllowNull Then
            cboTrigpoint.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
            cboTrigpoint.Properties.NullText = ""
            cboTrigpoint.Properties.ShowClearButton = True
        Else
            cboTrigpoint.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
            cboTrigpoint.Properties.ShowClearButton = False
        End If

        Dim oSourceTrigpoints As List(Of cSurvey.cTrigPoint) = New List(Of cSurvey.cTrigPoint)
        If bAllowNull Then oSourceTrigpoints.Add(Nothing)

        Dim oArgs As PopupEventArgs = New PopupEventArgs(oSourceTrigpoints, bAllowSplay)
        RaiseEvent Popup(Me, oArgs)

        'oSourceTrigpoints.AddRange(oSurvey.TrigPoints.GetStations(AllowSplay).ToList)
        'Call oSurvey.TrigPoints.GetStations(AllowSplay).ToList.ForEach(Function(oTrigpoint) oSourceTrigpoints.Add(oTrigpoint))
        cboTrigpoint.Properties.DataSource = oSourceTrigpoints

        If bAllowNull Then
            cboTrigpoint.EditValue = CurrentTrigpoint
        Else
            If oCurrentTrigpoint Is Nothing Then
                If oSourceTrigpoints.Count > 0 Then
                    cboTrigpoint.EditValue = oSourceTrigpoints(0).Name
                End If
            Else
                cboTrigpoint.EditValue = CurrentTrigpoint
            End If
        End If

        Dim bEnabled As Boolean = bAllowNull OrElse Count > 0
        cboTrigpoint.Enabled = bEnabled
        Return bEnabled
    End Function

    Public Function ContainsValue(Name As String) As Boolean
        Return pContains(Name)
    End Function

    Private Function pContains(Name As String) As Boolean
        Dim sName As String = ("" & Name).ToUpper
        If sName = "" Then
            If bAllowNull Then
                Return True
            Else
                Return False
            End If
        Else
            Dim oTrigpoints As List(Of cSurvey.cTrigPoint) = cboTrigpoint.Properties.DataSource
            Dim oFoundedTrigpoint As cSurvey.cTrigPoint = oTrigpoints.FirstOrDefault(Function(oTrigpoint) oTrigpoint IsNot Nothing AndAlso oTrigpoint.Name = sName)
            Return Not oFoundedTrigpoint Is Nothing
        End If
    End Function

    Public Property EditValue As String
        Get
            Return cboTrigpoint.EditValue
        End Get
        Set(value As String)
            If oSurvey IsNot Nothing Then
                Dim oTrigpoints As List(Of cSurvey.cTrigPoint) = cboTrigpoint.Properties.DataSource
                If pContains(value) Then
                    cboTrigpoint.EditValue = value
                Else
                    Dim oArgs As EditValueMissingEventArgs = New EditValueMissingEventArgs(value, cboTrigpoint.Properties.DataSource, bAllowSplay)
                    RaiseEvent EditValueMissing(Me, oArgs)
                    If pContains(value) Then
                        cboTrigpoint.EditValue = value
                    End If
                End If
            End If
        End Set
    End Property

    Public ReadOnly Property Count() As Integer
        Get
            Return cboTrigpoint.Properties.DataSource.count
        End Get
    End Property

    Private Sub cTrigpointDropDown_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If MyBase.Height <> cboTrigpoint.Height Then
            MyBase.Height = cboTrigpoint.Height
        End If
    End Sub

    Public Event CustomRowFilter As RowFilterEventHandler

    Private Sub cboTrigpointView_CustomRowFilter(sender As Object, e As RowFilterEventArgs)
        RaiseEvent CustomRowFilter(Me, e)
    End Sub

    Public Event EditValueChanged As EventHandler

    Private Sub cboTrigpoint_EditValueChanged(sender As Object, e As EventArgs) Handles cboTrigpoint.EditValueChanged
        RaiseEvent EditValueChanged(Me, e)
    End Sub

    Public Class CancelPopupEventArgs
        Inherits System.ComponentModel.CancelEventArgs

        Private bAllowSplay As Boolean
        Private oDataSource As List(Of cSurvey.cTrigPoint)

        Public Sub Add(Trigpoint As cSurvey.cTrigPoint)
            If Not oDataSource.Contains(Trigpoint) Then Call oDataSource.Add(Trigpoint)
        End Sub

        Public Sub AddRange(Trigpoints As List(Of cSurvey.cTrigPoint))
            Call oDataSource.AddRange(Trigpoints.Where(Function(oTrigpoint) Not oDataSource.Contains(oTrigpoint)))
        End Sub

        Public ReadOnly Property AllowSplay As Boolean
            Get
                Return bAllowSplay
            End Get
        End Property

        Public ReadOnly Property DataSource As List(Of cSurvey.cTrigPoint)
            Get
                Return oDataSource
            End Get
        End Property

        Friend Sub New(DataSource As List(Of cSurvey.cTrigPoint), AllowSplay As Boolean)
            MyBase.New()
            bAllowSplay = AllowSplay
            oDataSource = DataSource
        End Sub
    End Class

    Public Class EditValueMissingEventArgs
        Inherits PopupEventArgs

        Private sValue As String

        Public Sub New(Value As String, DataSource As List(Of cSurvey.cTrigPoint), AllowSplay As Boolean)
            MyBase.New(DataSource, AllowSplay)
            sValue = Value
        End Sub

        Public ReadOnly Property Value As String
            Get
                Return sValue
            End Get
        End Property
    End Class

    Public Class PopupEventArgs
        Inherits EventArgs

        Private bAllowSplay As Boolean
        Private oDataSource As List(Of cSurvey.cTrigPoint)

        Public ReadOnly Property AllowSplay As Boolean
            Get
                Return bAllowSplay
            End Get
        End Property

        Public Sub Add(Trigpoint As cSurvey.cTrigPoint)
            If Not oDataSource.Contains(Trigpoint) Then Call oDataSource.Add(Trigpoint)
        End Sub

        Public Sub AddRange(Trigpoints As List(Of cSurvey.cTrigPoint))
            Call oDataSource.AddRange(Trigpoints.Where(Function(oTrigpoint) Not oDataSource.Contains(oTrigpoint)))
        End Sub

        Public ReadOnly Property DataSource As List(Of cSurvey.cTrigPoint)
            Get
                Return oDataSource
            End Get
        End Property

        Friend Sub New(DataSource As List(Of cSurvey.cTrigPoint), AllowSplay As Boolean)
            MyBase.New()
            bAllowSplay = AllowSplay
            oDataSource = DataSource
        End Sub
    End Class


    Public Event QueryPopUp(sender As Object, e As CancelPopupEventArgs)
    Public Event Popup(sender As Object, e As PopupEventArgs)
    Public Event BeforePopup(sender As Object, e As PopupEventArgs)

    Public Event EditValueMissing(sender As Object, e As EditValueMissingEventArgs)

    Private Sub cboTrigpoint_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboTrigpoint.QueryPopUp
        Call cboTrigpointView.BeginUpdate()
        Dim oArgs As CancelPopupEventArgs = New CancelPopupEventArgs(cboTrigpoint.Properties.DataSource, bAllowSplay)
        RaiseEvent QueryPopUp(Me, oArgs)
        e.Cancel = oArgs.Cancel
        Call cboTrigpointView.RefreshData()
        Call cboTrigpointView.EndUpdate()
    End Sub

    Private Sub cboTrigpoint_Popup(sender As Object, e As EventArgs) Handles cboTrigpoint.Popup
        Call cboTrigpointView.BeginDataUpdate()
        Dim oArgs As PopupEventArgs = New PopupEventArgs(cboTrigpoint.Properties.DataSource, bAllowSplay)
        RaiseEvent Popup(Me, oArgs)
        Call cboTrigpointView.RefreshData()
        Call cboTrigpointView.EndDataUpdate()
    End Sub

    Private Sub cboTrigpoint_BeforePopup(sender As Object, e As EventArgs) Handles cboTrigpoint.BeforePopup
        Call cboTrigpointView.BeginUpdate()
        Dim oArgs As PopupEventArgs = New PopupEventArgs(cboTrigpoint.Properties.DataSource, bAllowSplay)
        RaiseEvent BeforePopup(Me, oArgs)
        Call cboTrigpointView.RefreshData()
        Call cboTrigpointView.EndUpdate()
    End Sub

    Private Sub cboTrigpointView_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs) Handles cboTrigpointView.CustomUnboundColumnData
        If e.IsGetData Then
            If e.Column Is colIsSplay Then
                If e.Row Is Nothing Then
                    e.Value = False
                Else
                    e.Value = DirectCast(e.Row, cSurvey.cTrigPoint).Data.IsSplay
                End If
            End If
        End If
    End Sub

    Public Overrides Property Text As String
        Get
            Return EditValue
        End Get
        Set(value As String)
            EditValue = value
        End Set
    End Property

End Class
