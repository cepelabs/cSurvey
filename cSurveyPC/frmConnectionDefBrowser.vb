Imports cSurveyPC.cSurvey

friend Class frmConnectionDefBrowser
    Private bAllowNull As Boolean

    Public Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal CurrentConnectionDef As cConnectionDef, Optional AllowNull As Boolean = False, Optional Station As String = Nothing, Optional FromStation As String = Nothing, Optional Exclusions As List(Of cConnectionDef) = Nothing)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        bAllowNull = AllowNull
        If bAllowNull Then
            cboTrigpoints.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
            cboTrigpoints.Properties.NullText = ""
        Else
            cboTrigpoints.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
        End If

        Dim oItems As List(Of cConnectionDef) = New List(Of cConnectionDef)
        For Each oTrigPoint As cTrigPoint In Survey.TrigPoints
            If IsNothing(Station) OrElse (Not IsNothing(Station) AndAlso oTrigPoint.Name = Station) Then
                If Not oTrigPoint.Data.IsCalibration AndAlso Not oTrigPoint.Data.IsSplay Then
                    For Each sFromTrigpoint As String In oTrigPoint.Connections
                        If IsNothing(FromStation) OrElse (Not IsNothing(FromStation) AndAlso sFromTrigpoint = FromStation) Then
                            Dim oItem As cConnectionDef = New cConnectionDef(oTrigPoint.Name, sFromTrigpoint)
                            If IsNothing(Exclusions) OrElse (Not IsNothing(Exclusions) AndAlso Exclusions.Where(Function(oExclusionItem) oItem = oExclusionItem).Count = 0) Then
                                Call oItems.Add(oItem)
                            End If
                        End If
                    Next
                End If
            End If
        Next

        cboTrigpoints.Properties.DataSource = oItems

        cboTrigpoints.EditValue = CurrentConnectionDef
    End Sub

    Public ReadOnly Property SelectedItem As cConnectionDef
        Get
            If IsNothing(cboTrigpoints.EditValue) Then
                Return Nothing
            Else
                If cboTrigpoints.EditValue.ToString = "" Then
                    Return Nothing
                Else
                    Return cboTrigpoints.EditValue
                End If
            End If
        End Get
    End Property

    Private Sub cboTrigpoints_CustomDisplayText(sender As Object, e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs) Handles cboTrigpoints.CustomDisplayText
        If e.Value Is Nothing Then
            e.DisplayText = ""
        Else
            e.DisplayText = DirectCast(e.Value, cConnectionDef).ToString
        End If
    End Sub

    'Private Sub cboTrigpoints_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboTrigpoints.Validating
    '    If IsNothing(cboTrigpoints.SelectedItem) AndAlso cboTrigpoints.Text <> "" Then
    '        e.Cancel = True
    '    End If
    'End Sub
End Class