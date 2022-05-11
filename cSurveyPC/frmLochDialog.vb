Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports DevExpress.XtraBars

Friend Class frmLochDialog
    Private oSurvey As cSurvey.cSurvey

    Public Sub New(Survey As cSurvey.cSurvey)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey

        If oSurvey.Properties.GPS.Enabled Then
            Dim iElevation As Integer = 0
            Call cboElevationData.Properties.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", Nothing, -1))
            For Each oElevation As cSurvey.Surface.cElevation In oSurvey.Surface.Elevations
                Call iml.AddImage(oElevation.GetImage(New Size(48, 32)))
                Dim iElevationIndex As Integer = cboElevationData.Properties.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(oElevation.Name, oElevation, iElevation))
                If oElevation.Default Then
                    cboElevationData.SelectedIndex = iElevationIndex
                End If
                iElevation += 1
            Next

            If iElevation > 0 Then
                cboElevationData.Enabled = True
                lblElevationData.Enabled = cboElevationData.Enabled
                Dim iOrthoPhoto As Integer = 0
                Call cboOrthophoto.Properties.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", Nothing, -1))
                For Each oOrthoPhoto As cSurvey.Surface.cOrthoPhoto In oSurvey.Surface.OrthoPhotos
                    Call iml.AddImage(oOrthoPhoto.GetImage(New Size(48, 32)))
                    Dim iOrthoPhotoIndex As Integer = cboOrthophoto.Properties.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(oOrthoPhoto.Name, oOrthoPhoto, iElevation))
                    If oOrthoPhoto.Default Then
                        cboOrthophoto.SelectedIndex = iOrthoPhotoIndex
                    End If
                    iOrthoPhoto += 1
                Next
                cboOrthophoto.Enabled = iOrthoPhoto > 0
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

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOkOrSave.Click
        Call oSurvey.SharedSettings.SetValue("loch.showdialog", If(chkDoNotShow.Checked, "0", "1"))
        If cboElevationData.SelectedIndex > 0 Then
            Dim oElevation As cSurvey.Surface.cElevation = cboElevationData.SelectedItem.value
            oElevation.Default = True

            If cboOrthophoto.SelectedIndex > 0 Then
                Dim oOrthoPhoto As cSurvey.Surface.cOrthoPhoto = cboOrthophoto.SelectedItem.value
                oOrthoPhoto.Default = True
            Else
                For Each oOrthoPhoto As cSurvey.Surface.cOrthoPhoto In oSurvey.Surface.OrthoPhotos
                    If oOrthoPhoto.Default Then
                        oOrthoPhoto.Default = False
                    End If
                Next
            End If
        Else
            For Each oElevation As cSurvey.Surface.cElevation In oSurvey.Surface.Elevations
                If oElevation.Default Then
                    oElevation.Default = False
                End If
            Next
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

    Private Sub cmdMenuOk_ItemClick(sender As Object, e As ItemClickEventArgs) Handles cmdMenuOk.ItemClick
        DialogResult = DialogResult.OK
        Call cmdOkOrSave.PerformClick()
    End Sub

    Private Sub cmdMenuSave_ItemClick(sender As Object, e As ItemClickEventArgs) Handles cmdMenuSave.ItemClick
        DialogResult = DialogResult.Retry
    End Sub

    Private Sub cboElevationData_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboElevationData.SelectedValueChanged
        cboOrthophoto.Enabled = cboElevationData.SelectedIndex > 0
        lblOrthophoto.Enabled = cboOrthophoto.Enabled
    End Sub
End Class