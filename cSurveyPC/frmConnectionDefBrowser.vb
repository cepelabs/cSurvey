Imports cSurveyPC.cSurvey

friend Class frmConnectionDefBrowser

    Public Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal CurrentConnectionDef As cConnectionDef, Optional AllowNull As Boolean = False, Optional Station As String = Nothing, Optional FromStation As String = Nothing, Optional Exclusions As List(Of cConnectionDef) = Nothing)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        If AllowNull Then
            Call cboTrigpoints.Items.Add("")
        End If

        For Each oTrigPoint As cTrigPoint In Survey.TrigPoints
            If IsNothing(Station) OrElse (Not IsNothing(Station) AndAlso oTrigPoint.Name = Station) Then
                If Not oTrigPoint.Data.IsCalibration AndAlso Not oTrigPoint.Data.IsSplay Then
                    For Each sFromTrigpoint As String In oTrigPoint.Connections
                        If IsNothing(FromStation) OrElse (Not IsNothing(FromStation) AndAlso sFromTrigpoint = FromStation) Then
                            Dim oItem As cConnectionDef = New cConnectionDef(oTrigPoint.Name, sFromTrigpoint)
                            If IsNothing(Exclusions) OrElse (Not IsNothing(Exclusions) AndAlso Exclusions.Where(Function(oExclusionItem) oItem = oExclusionItem).Count = 0) Then
                                Call cboTrigpoints.Items.Add(oItem)
                                If Not IsNothing(CurrentConnectionDef) AndAlso oItem = CurrentConnectionDef Then
                                    cboTrigpoints.SelectedItem = oItem
                                End If
                            End If
                        End If
                    Next
                End If
            End If
        Next
    End Sub

    Public ReadOnly Property Connection As cConnectionDef
        Get
            If IsNothing(cboTrigpoints.SelectedItem) Then
                Return Nothing
            Else
                If cboTrigpoints.SelectedItem.ToString = "" Then
                    Return Nothing
                Else
                    Return cboTrigpoints.SelectedItem
                End If
            End If
        End Get
    End Property

    Private Sub cboTrigpoints_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboTrigpoints.Validating
        If IsNothing(cboTrigpoints.SelectedItem) AndAlso cboTrigpoints.Text <> "" Then
            e.Cancel = True
        End If
    End Sub
End Class