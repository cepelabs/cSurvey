Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Options

friend Class frmSurface3DLayerProperties
    Private oItem As cSurface3DOptions.cSurface3DOptionsItem

    Public Sub New(Item As cSurface3DOptions.cSurface3DOptionsItem)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oItem = Item

        trkTransparency.EditValue = oItem.Transparency * 255
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As System.EventArgs) Handles cmdOk.Click
        oItem.Transparency = trkTransparency.EditValue / 255
    End Sub
End Class