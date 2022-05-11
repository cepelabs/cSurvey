﻿friend Class frmSurfaceAddOrthoPhotoFromWMS

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        If txtName.Text <> "" Then
            DialogResult = Windows.Forms.DialogResult.OK
        Else
            Call MsgBox(GetLocalizedString("surface.warning6"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("surface.warningtitle"))
        End If
    End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

    End Sub

    Public Sub New(Name As String)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        txtName.Text = Name
        picBackgroundColor.BackColor = Color.White
    End Sub

    Private Sub cmdBackgroundColor_Click(sender As Object, e As EventArgs) Handles cmdBackgroundColor.Click
        Using oCD As ColorDialog = New ColorDialog
            With oCD
                .FullOpen = True
                .AnyColor = True
                .Color = picBackgroundColor.BackColor
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    picBackgroundColor.BackColor = .Color
                End If
            End With
        End Using
    End Sub
End Class