friend Class frmNotifyUpdate
    Private bNightBuild As Boolean

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        If bNightBuild Then
            Call Process.Start("https://csurvey.it/site/nightbuild")
        Else
            Call Process.Start("https://csurvey.it/site/download")
        End If
    End Sub

    Public Sub New(NightBuild As Boolean)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        bNightBuild = NightBuild
    End Sub
End Class