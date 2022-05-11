friend Class frmPrefixTrigPoints

    Private oSurvey As cSurvey.cSurvey

    Public Sub New(ByVal Survey As cSurvey.cSurvey, Optional SelectedTrigpoints As List(Of String) = Nothing)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey

        If Not SelectedTrigpoints Is Nothing Then chkShowSplay.Checked = True

        Call pLoadTrigpoints()

        'se ci sono dei valori da preselezionare...li preseleziono
        If Not SelectedTrigpoints Is Nothing Then
            For Each sTrigpoint In SelectedTrigpoints
                If ListBox1.Items.Contains(sTrigpoint) Then
                    Call ListBox2.Items.Add(sTrigpoint)
                    Call ListBox1.Items.Remove(sTrigpoint)
                End If
            Next
        End If
    End Sub

    Private Sub pLoadTrigpoints()
        Cursor = Cursors.WaitCursor
        Call ListBox1.Items.Clear()
        For Each oTrigpoint As cSurvey.cTrigPoint In oSurvey.TrigPoints
            If (chkShowSplay.Checked) Or (Not chkShowSplay.Checked And Not oTrigpoint.Data.IsSplay) Then
                Dim sTrigpoint As String = oTrigpoint.Name
                If Not ListBox2.Items.Contains(sTrigpoint) Then
                    Call ListBox1.Items.Add(sTrigpoint)
                End If
            End If
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            For Each sTrigpoint As String In ListBox1.SelectedItems
                Call ListBox2.Items.Add(sTrigpoint)
                Call ListBox1.Items.Remove(sTrigpoint)
            Next
        Catch
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            For Each sTrigpoint As String In ListBox2.SelectedItems
                Call ListBox1.Items.Add(sTrigpoint)
                Call ListBox2.Items.Remove(sTrigpoint)
            Next
        Catch
        End Try
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If txtPrefix.Text <> "" Then
            Dim sPrefix As String = txtPrefix.Text
            If ListBox2.Items.Count = 0 Then
                Call MsgBox(GetLocalizedString("prefixstation.warning1"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("prefixstation.warningtitle"))
            Else
                Cursor = Cursors.WaitCursor
                If optAdd.Checked Then
                    For Each sTrigpoint As String In ListBox2.Items
                        Call oSurvey.TrigPoints.RenameTrigPoint(sTrigpoint, sPrefix & sTrigpoint)
                        'If oSurvey.Properties.Origin = sTrigpoint Then
                        '    Call oSurvey.Properties.RenameOrigin(sPrefix & sTrigpoint)
                        'End If
                    Next
                Else
                    For Each sTrigpoint As String In ListBox2.Items
                        If sTrigpoint.StartsWith(sPrefix) Then
                            Dim sNewTrigpoint As String = sTrigpoint.Substring(sPrefix.Length)
                            Call oSurvey.TrigPoints.RenameTrigPoint(sTrigpoint, sNewTrigpoint)
                            'If oSurvey.Properties.Origin = sTrigpoint Then
                            '    Call oSurvey.Properties.RenameOrigin(sNewTrigpoint)
                            'End If
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
            For Each sTrigpoint As String In ListBox1.Items
                Call ListBox2.Items.Add(sTrigpoint)
            Next
            Call ListBox1.Items.Clear()
        Catch
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            For Each sTrigpoint As String In ListBox2.Items
                Call ListBox1.Items.Add(sTrigpoint)
            Next
            Call ListBox2.Items.Clear()
        Catch
        End Try
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        Call Button1_Click(Nothing, Nothing)
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        Call Button2_Click(Nothing, Nothing)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub chkShowSplay_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkShowSplay.CheckedChanged
        Call pLoadTrigpoints()
    End Sub

    Private Sub frmPrefixTrigPoints_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class