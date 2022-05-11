Imports cSurveyPC.cSurvey

friend Class frmTrigpointBrowser

    Public Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal CurrentTrigpoint As String, Optional AllowNull As Boolean = False, Optional AllowSplay As Boolean = False, Optional ShowConnection As Boolean = False)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        If AllowNull Then
            Call cboTrigpoints.Items.Add("")
        End If

        If ShowConnection Then
            For Each oTrigPoint As cTrigPoint In Survey.TrigPoints
                If Not oTrigPoint.Data.IsCalibration AndAlso (AllowSplay OrElse (Not AllowSplay AndAlso Not oTrigPoint.Data.IsSplay)) Then
                    For Each sStation As String In oTrigPoint.Connections
                        Call cboTrigpoints.Items.Add(oTrigPoint.Name & " (<" & sStation & ")")
                    Next
                End If
            Next
        Else
            For Each oTrigPoint As cTrigPoint In Survey.TrigPoints
                If Not oTrigPoint.Data.IsCalibration AndAlso (AllowSplay OrElse (Not AllowSplay AndAlso Not oTrigPoint.Data.IsSplay)) Then
                    Call cboTrigpoints.Items.Add(oTrigPoint.Name)
                End If
            Next
        End If

        Try
            If CurrentTrigpoint Is Nothing Then
                cboTrigpoints.SelectedIndex = 0
            Else
                cboTrigpoints.SelectedItem = CurrentTrigpoint
            End If
        Catch
        End Try
    End Sub

    Private Sub cboTrigpoints_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboTrigpoints.Validating
        If IsNothing(cboTrigpoints.SelectedItem) AndAlso cboTrigpoints.Text <> "" Then
            e.Cancel = True
        End If
    End Sub
End Class