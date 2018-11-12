Public Class frmItem3DEdit
    Private oHolos As cHolosItemEdit

    Private Sub btnLoadModel_Click(sender As Object, e As EventArgs) Handles btnLoadModel.Click
        Call oHolos.Import()
    End Sub

    Public Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oHolos = h3d.Child
    End Sub
End Class