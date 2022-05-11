Imports cSurveyPC.cSurvey.Design.Options

friend Class frmSurfaceLayerProperties
    Private oItem As cSurfaceOptions.cSurfaceOptionsItem

    Public Sub New(Item As cSurfaceOptions.cSurfaceOptionsItem)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oItem = Item

        txtTransparency.Value = oItem.Transparency * 255
        If oItem.MinScale.HasValue Then
            chkMinScale.Checked = True
            txtMinScale.Value = oItem.MinScale
        Else
            chkMinScale.Checked = False
        End If
        If oItem.MaxScale.HasValue Then
            chkMaxScale.Checked = True
            txtMaxScale.Value = oItem.MaxScale
        Else
            chkMaxScale.Checked = False
        End If
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As System.EventArgs) Handles cmdOk.Click
        oItem.Transparency = txtTransparency.Value / 255
        If chkMinScale.Checked Then
            oItem.MinScale = txtMinScale.Value
        Else
            oItem.MinScale = Nothing
        End If
        If chkMaxScale.Checked Then
            oItem.MaxScale = txtMaxScale.Value
        Else
            oItem.MaxScale = Nothing
        End If
    End Sub

    Private Sub chkMinScale_CheckedChanged(sender As Object, e As EventArgs) Handles chkMinScale.CheckedChanged
        Dim bEnabled As Boolean = chkMinScale.Checked
        txtMinScale.Enabled = bEnabled
        lblMinScale.Enabled = bEnabled
    End Sub

    Private Sub chkMaxScale_CheckedChanged(sender As Object, e As EventArgs) Handles chkMaxScale.CheckedChanged
        Dim bEnabled As Boolean = chkMaxScale.Checked
        txtMaxScale.Enabled = bEnabled
        lblMaxScale.Enabled = bEnabled
    End Sub

End Class