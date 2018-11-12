Imports cSurveyPC.cSurvey

Public Class frmSegmentBrowser

    Public ReadOnly Property SegmentsCount As Integer
        Get
            Return cboSegments.Items.Count
        End Get
    End Property

    Public Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal CurrentSegment As cSegment, Optional AllowSplay As Boolean = False)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        For Each oSegment As cSegment In Survey.Segments.GetValidSegments
            If AllowSplay Or (Not AllowSplay And Not oSegment.Splay) Then
                Call cboSegments.Items.Add(oSegment)
            End If
        Next

        Try
            If CurrentSegment Is Nothing Then
                cboSegments.SelectedIndex = 0
            Else
                cboSegments.SelectedItem = CurrentSegment
            End If
        Catch
        End Try
    End Sub

    Private Sub cboSegments_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboSegments.Validating
        If IsNothing(cboSegments.SelectedItem) AndAlso cboSegments.Text <> "" Then
            e.Cancel = True
        End If
    End Sub
End Class