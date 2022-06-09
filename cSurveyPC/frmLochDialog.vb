Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports DevExpress.XtraBars

Friend Class frmLochDialog
    Private oSurvey As cSurvey.cSurvey
    Private oOptions As cSurvey.Design.cOptionsTherion
    Public Sub New(Survey As cSurvey.cSurvey)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey
        oOptions = oSurvey.Options("_loch")

        Call iml.Images.Clear()
        iml.ImageSize = New Size(48 * Me.CurrentAutoScaleDimensions.Height / 96.0F, 32 * Me.CurrentAutoScaleDimensions.Height / 96.0F)

        If oSurvey.Properties.GPS.Enabled Then
            Dim iElevation As Integer = 0
            Call cboElevationData.Properties.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", Nothing, -1))
            For Each oElevation As cSurvey.Surface.cElevation In oSurvey.Surface.Elevations
                Call iml.AddImage(oElevation.GetImage(iml.ImageSize))
                Dim iElevationIndex As Integer = cboElevationData.Properties.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(oElevation.Name, oElevation, iElevation))
                If oOptions.SurfaceOptions.Elevation.ID = oElevation.ID Then
                    cboElevationData.SelectedIndex = iElevationIndex
                End If
                iElevation += 1
            Next

            If cboElevationData.Properties.Items.Count > 0 Then
                cboElevationData.Enabled = True
                lblElevationData.Enabled = cboElevationData.Enabled
                Dim iOrthoPhoto As Integer = 0
                Call cboOrthophoto.Properties.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", Nothing, -1))
                For Each oOrthoPhoto As cSurvey.Surface.cOrthoPhoto In oSurvey.Surface.OrthoPhotos
                    Call iml.AddImage(oOrthoPhoto.GetImage(iml.ImageSize))
                    Dim iOrthoPhotoIndex As Integer = cboOrthophoto.Properties.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(oOrthoPhoto.Name, oOrthoPhoto, iElevation + iOrthoPhoto))
                    If oOptions.SurfaceOptions.Orthophoto.ID = oOrthoPhoto.ID Then
                        cboOrthophoto.SelectedIndex = iOrthoPhotoIndex
                    End If
                    iOrthoPhoto += 1
                Next
                cboOrthophoto.Enabled = cboElevationData.SelectedIndex > 0
                lblOrthophoto.Enabled = cboOrthophoto.Enabled
            Else
                cboElevationData.Enabled = False
                lblElevationData.Enabled = cboElevationData.Enabled
                cboOrthophoto.Enabled = False
                lblOrthophoto.Enabled = cboOrthophoto.Enabled
            End If
            Call linkedSurveys.Rebind(oSurvey.LinkedSurveys, "loch")
            linkedSurveys.Enabled = True
        Else
            cboElevationData.Enabled = False
            lblElevationData.Enabled = cboElevationData.Enabled
            cboOrthophoto.Enabled = False
            lblOrthophoto.Enabled = cboOrthophoto.Enabled
            linkedSurveys.Enabled = False
        End If
    End Sub

    Private Sub cmdMenuOk_ItemClick(sender As Object, e As ItemClickEventArgs) Handles cmdMenuOk.ItemClick
        Call pSave()
        DialogResult = DialogResult.OK
    End Sub

    Private Sub cmdMenuSave_ItemClick(sender As Object, e As ItemClickEventArgs) Handles cmdMenuSave.ItemClick
        Call pSave()
        DialogResult = DialogResult.Retry
    End Sub
    Private Sub cmdOkOrSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdOkOrSave.Click
        Call pSave()
    End Sub

    Private Sub pSave()
        Call oSurvey.SharedSettings.SetValue("loch.showdialog", If(chkDoNotShow.Checked, "0", "1"))
        If cboElevationData.SelectedIndex > 0 Then
            Dim oElevation As cSurvey.Surface.cElevation = cboElevationData.SelectedItem.value
            Call oOptions.SurfaceOptions.Elevation.ChangeID(oElevation.ID)
            If cboOrthophoto.SelectedIndex > 0 Then
                Dim oOrthoPhoto As cSurvey.Surface.cOrthoPhoto = cboOrthophoto.SelectedItem.value
                Call oOptions.SurfaceOptions.Orthophoto.ChangeID(oOrthoPhoto.ID)
            Else
                Call oOptions.SurfaceOptions.Orthophoto.ChangeID("")
            End If
        Else
            Call oOptions.SurfaceOptions.Elevation.ChangeID("")
        End If
    End Sub

    Private Sub frmLochDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        chkDoNotShow.Checked = Integer.Parse(oSurvey.SharedSettings.GetValue("loch.showdialog", 1)) <> 1
        If My.Computer.Keyboard.ShiftKeyDown Then
            chkDoNotShow.Checked = False
        End If
        If chkDoNotShow.Checked OrElse (Not cboElevationData.Enabled AndAlso Not cboOrthophoto.Enabled AndAlso Not linkedSurveys.Enabled) Then
            DialogResult = Windows.Forms.DialogResult.OK
            Call Close()
        End If
    End Sub

    Private Sub cboElevationData_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboElevationData.SelectedValueChanged
        cboOrthophoto.Enabled = cboElevationData.SelectedIndex > 0 AndAlso cboOrthophoto.Properties.Items.Count > 0
        lblOrthophoto.Enabled = cboOrthophoto.Enabled
    End Sub

End Class