Public Class FrmTestLink

    Private Sub PropertyGrid1_Click(sender As Object, e As EventArgs) Handles PropertyGrid1.Click

    End Sub

    Public Sub New(Survey As cSurvey.cSurvey)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        PropertyGrid1.SelectedObject = Survey.Properties
    End Sub
End Class