Imports System.ComponentModel
Imports cSurveyPC.cSurvey
Imports DevExpress.XtraGrid.Views.Base

Friend Class frmPrefixTrigPoints

    Private oSurvey As cSurvey.cSurvey

    'Public Sub New(ByVal Survey As cSurvey.cSurvey, Optional SelectedTrigpoints As List(Of String) = Nothing)

    '    ' Chiamata richiesta dalla finestra di progettazione.
    '    InitializeComponent()

    '    ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
    '    oSurvey = Survey

    '    If Not SelectedTrigpoints Is Nothing Then chkShowSplay.Checked = True

    '    listbox1.DataSource = oList1
    '    listbox2.DataSource = oList2

    '    Call pLoadTrigpoints()

    '    'se ci sono dei valori da preselezionare...li preseleziono
    '    If Not SelectedTrigpoints Is Nothing Then
    '        listbox1.BeginUpdate()
    '        listbox2.BeginUpdate()
    '        For Each sTrigpoint In SelectedTrigpoints
    '            If oList1.Contains(sTrigpoint) Then
    '                Call oList2.Add(sTrigpoint)
    '                Call oList1.Remove(sTrigpoint)
    '            End If
    '        Next
    '        listbox1.EndUpdate()
    '        listbox2.EndUpdate()
    '    End If
    'End Sub

    Public Sub New(ByVal Survey As cSurvey.cSurvey, Optional SelectedTrigpoints As List(Of cTrigPoint) = Nothing)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey

        'If Not SelectedTrigpoints Is Nothing Then chkShowSplay.Checked = True

        listbox1.DataSource = oList1
        listbox2.DataSource = oList2

        Call pLoadTrigpoints()

        'se ci sono dei valori da preselezionare...li preseleziono
        If Not SelectedTrigpoints Is Nothing Then
            listbox1.BeginUpdate()
            listbox2.BeginUpdate()
            For Each sTrigpoint In SelectedTrigpoints
                If oList1.Contains(sTrigpoint) Then
                    Call oList2.Add(sTrigpoint)
                    Call oList1.Remove(sTrigpoint)
                End If
            Next
            listbox1.EndUpdate()
            listbox2.EndUpdate()
        End If
    End Sub

    Private oList1 As BindingList(Of cSurvey.cTrigPoint) = New BindingList(Of cSurvey.cTrigPoint)
    Private oList2 As BindingList(Of cSurvey.cTrigPoint) = New BindingList(Of cSurvey.cTrigPoint)

    Private Sub pLoadTrigpoints()
        Cursor = Cursors.WaitCursor
        listbox1.BeginUpdate()
        listbox2.BeginUpdate()
        oList1.Clear()
        For Each oTrigpoint As cSurvey.cTrigPoint In oSurvey.TrigPoints
            'If (chkShowSplay.Checked) OrElse (Not chkShowSplay.Checked AndAlso Not oTrigpoint.Data.IsSplay) Then
            'Dim sTrigpoint As String = oTrigpoint.Name
            If Not oList2.Contains(oTrigpoint) Then
                    Call oList1.Add(oTrigpoint)
                End If
            'End If
        Next
        listbox1.EndUpdate()
        listbox2.EndUpdate()
        Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            listbox1.BeginUpdate()
            listbox2.BeginUpdate()
            For Each i As Integer In grdView1.GetSelectedAndFocusedRow
                Dim oTrigpoint As cTrigPoint = grdView1.GetRow(i)
                oList2.Add(oTrigpoint)
                oList1.Remove(oTrigpoint)
            Next
            listbox1.EndUpdate()
            listbox2.EndUpdate()
        Catch
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            listbox1.BeginUpdate()
            listbox2.BeginUpdate()
            For Each i As Integer In grdView2.GetSelectedAndFocusedRow
                Dim oTrigpoint As cTrigPoint = grdView2.GetRow(i)
                oList1.Add(oTrigpoint)
                oList2.Remove(oTrigpoint)
            Next
            listbox1.EndUpdate()
            listbox2.EndUpdate()
        Catch
        End Try
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If txtPrefix.Text <> "" Then
            Dim sPrefix As String = txtPrefix.Text
            If oList2.Count = 0 Then
                Call MsgBox(GetLocalizedString("prefixstation.warning1"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("prefixstation.warningtitle"))
            Else
                Cursor = Cursors.WaitCursor
                If optAdd.Checked Then
                    For Each oTrigpoint As cTrigPoint In oList2
                        If (chkShowSplay.Checked) OrElse (Not chkShowSplay.Checked AndAlso Not oTrigpoint.Data.IsSplay) Then
                            Call oSurvey.TrigPoints.RenameTrigPoint(oTrigpoint.Name, sPrefix & oTrigpoint.Name)
                        End If
                    Next
                Else
                    For Each oTrigpoint As cTrigPoint In oList2
                        If (chkShowSplay.Checked) OrElse (Not chkShowSplay.Checked AndAlso Not oTrigpoint.Data.IsSplay) Then
                            If oTrigpoint.Name.StartsWith(sPrefix) Then
                                Dim sNewTrigpoint As String = oTrigpoint.Name.Substring(sPrefix.Length)
                                Call oSurvey.TrigPoints.RenameTrigPoint(oTrigpoint.Name, sNewTrigpoint)
                            End If
                        End If
                    Next
                End If
                Cursor = Cursors.Default
                DialogResult = Windows.Forms.DialogResult.OK
                Call Close()
            End If
        Else
            Call MsgBox(GetLocalizedString("prefixstation.warning2"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("prefixstation.warningtitle"))
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            listbox1.BeginUpdate()
            listbox2.BeginUpdate()

            For Each oTrigpoint As cTrigPoint In oList1
                Call oList2.Add(oTrigpoint)
            Next
            oList1.Clear()

            listbox1.EndUpdate()
            listbox2.EndUpdate()
        Catch
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            listbox1.BeginUpdate()
            listbox2.BeginUpdate()
            For Each oTrigpoint As cTrigPoint In oList2
                Call oList1.Add(oTrigpoint)
            Next
            oList2.Clear()
            listbox1.EndUpdate()
            listbox2.EndUpdate()
        Catch
        End Try
    End Sub

    Private Sub grdView1_DoubleClick(sender As Object, e As EventArgs) Handles grdView1.DoubleClick
        Call Button1_Click(Nothing, Nothing)
    End Sub

    Private Sub grdView2_DoubleClick(sender As Object, e As EventArgs) Handles grdView2.DoubleClick
        Call Button2_Click(Nothing, Nothing)
    End Sub

    Private Sub chkShowSplay_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkShowSplay.CheckedChanged
        'Call pLoadTrigpoints()
        Call grdView1.RefreshData()
        Call grdView2.RefreshData()
    End Sub

    Private Sub grdView2_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs) Handles grdView2.CustomUnboundColumnData
        If e.IsGetData Then
            e.Value = e.Row
        End If
    End Sub

    Private Sub grdView1_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs) Handles grdView1.CustomUnboundColumnData
        If e.IsGetData Then
            e.Value = e.Row
        End If
    End Sub

    Private Sub grdView2_CustomRowFilter(sender As Object, e As RowFilterEventArgs) Handles grdView2.CustomRowFilter
        Dim oTrigpoint As cTrigPoint = oList2(e.ListSourceRow)
        If oTrigpoint Is Nothing Then
            e.Visible = False
        Else
            e.Visible = (chkShowSplay.Checked) OrElse (Not chkShowSplay.Checked AndAlso Not oTrigpoint.Data.IsSplay)
        End If
        e.Handled = True
    End Sub

    Private Sub grdView1_CustomRowFilter(sender As Object, e As RowFilterEventArgs) Handles grdView1.CustomRowFilter
        Dim oTrigpoint As cTrigPoint = oList1(e.ListSourceRow)
        If oTrigpoint Is Nothing Then
            e.Visible = False
        Else
            e.Visible = (chkShowSplay.Checked) OrElse (Not chkShowSplay.Checked AndAlso Not oTrigpoint.Data.IsSplay)
        End If
        e.Handled = True
    End Sub

    'Private Sub grdView2_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles grdView2.FocusedRowChanged
    '    If e.FocusedRowHandle >= 0 Then
    '        Call grdView2.SelectRow(e.FocusedRowHandle)
    '    End If
    'End Sub

    'Private Sub grdView1_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles grdView1.FocusedRowChanged
    '    If e.FocusedRowHandle >= 0 Then
    '        Call grdView1.SelectRow(e.FocusedRowHandle)
    '    End If
    'End Sub
End Class