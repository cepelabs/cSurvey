Imports cSurveyPC.cSurvey

Friend Class frmTrigpointBrowser
    Private oSurvey As cSurveyPC.cSurvey.cSurvey

    Private bAllowNull As Boolean

    Public ReadOnly Property Count As Integer
        Get
            Return cboTrigpoints.Count
        End Get
    End Property

    Public ReadOnly Property SelectedItem As String
        Get
            If (cboTrigpoints.EditValue Is Nothing) Then
                Return ""
            Else
                Return cboTrigpoints.EditValue
            End If
        End Get
    End Property

    Public Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal CurrentTrigpoint As String, Optional AllowNull As Boolean = False, Optional AllowSplay As Boolean = False) ', Optional ShowConnection As Boolean = False)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey
        Call cboTrigpoints.Rebind(Survey, CurrentTrigpoint, AllowNull, AllowSplay)

        If CurrentTrigpoint = "" Then
            cboTrigpoints.EditValue = Nothing
        Else
            cboTrigpoints.EditValue = CurrentTrigpoint
        End If
    End Sub

    Private Sub cboTrigpoints_Popup(sender As Object, e As cTrigpointDropDown.PopupEventArgs) Handles cboTrigpoints.Popup
        Cursor = Cursors.WaitCursor
        Call e.AddRange(oSurvey.TrigPoints.GetStations(e.AllowSplay).ToList)
        Cursor = Cursors.Default
    End Sub
End Class