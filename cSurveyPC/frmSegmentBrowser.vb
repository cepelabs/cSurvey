Imports cSurveyPC.cSurvey

Friend Class frmSegmentBrowser
    Private bAllowNull As Boolean

    Public ReadOnly Property Count As Integer
        Get
            Return cboSegments.Properties.DataSource.count
        End Get
    End Property

    Public ReadOnly Property SelectedItem As cSegment
        Get
            Return cboSegments.EditValue
        End Get
    End Property

    Public Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal CurrentSegment As cSegment, Optional AllowNull As Boolean = False, Optional AllowSplay As Boolean = False)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        bAllowNull = AllowNull
        If bAllowNull Then
            cboSegments.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
            cboSegments.Properties.NullText = ""
        Else
            cboSegments.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
        End If

        cboSegments.Properties.DataSource = Survey.Segments.GetValidSegments.Cast(Of cSegment).Where(Function(oitem) AllowSplay Or (Not AllowSplay And Not oitem.Splay))

        cboSegments.EditValue = CurrentSegment
    End Sub

    Private Sub cboSegments_CustomDisplayText(sender As Object, e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs) Handles cboSegments.CustomDisplayText
        If e.Value Is Nothing Then
            e.DisplayText = ""
        Else
            With DirectCast(e.Value, cSegment)
                e.DisplayText = .From & " > " & .To
            End With
        End If
    End Sub

    'Private Sub cboSegments_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboSegments.Validating
    '    If IsNothing(cboSegments.SelectedItem) AndAlso cboSegments.Text <> "" Then
    '        e.Cancel = True
    '    End If
    'End Sub
End Class