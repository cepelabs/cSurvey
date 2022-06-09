friend Class frmSurfaceAddElevationFromOrthoPhoto

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        If txtName.Text <> "" Then
            DialogResult = Windows.Forms.DialogResult.OK
        Else
            Call MsgBox(GetLocalizedString("surface.warning6"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("surface.warningtitle"))
        End If
    End Sub

    Private oColors As List(Of Color)

    Public Sub New(Name As String)
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        txtName.Text = Name
        oColors = modPaint.GetRainbowColors(256)
        cboMode.SelectedIndex = 0
        txtHueColorFrom.Color = oColors(0)
        txtHueColorTo.Color = oColors(255)
    End Sub

    Private Sub pValidateHueAndHeight()
        Dim sMinHue As Single = DirectCast(txtHueColorFrom.EditValue, Color).GetHue
        Dim sMaxHue As Single = DirectCast(txtHueColorTo.EditValue, Color).GetHue
        If sMinHue = sMaxHue Then
            cmdOk.Enabled = False
        Else
            cmdOk.Enabled = True
        End If
    End Sub

    Private Sub cboMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMode.SelectedIndexChanged
        Select Case cboMode.SelectedIndex
            Case 0
                picHue.Visible = True
        End Select
    End Sub

    Friend Class GetHueEventArgs
        Inherits EventArgs

        Public MaxHue As Single
        Public MinHue As Single

        Public Sub New()
            Me.MinHue = Single.MaxValue
            Me.MaxHue = Single.MinValue
        End Sub
    End Class

    Friend Event GetHue(Sender As Object, e As GetHueEventArgs)

    Private Sub btnHueRange_Click(sender As Object, e As EventArgs) Handles btnHueRange.Click
        Dim oArgs As GetHueEventArgs = New GetHueEventArgs
        RaiseEvent GetHue(Me, oArgs)
        txtHueColorFrom.Color = modPaint.HsvToRgb(oArgs.MinHue, 1, 1)
        txtHueColorTo.Color = modPaint.HsvToRgb(oArgs.MaxHue, 1, 1)
    End Sub

    Private Sub txtName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtName.Validating
        e.Cancel = Not txtName.ValidateIfNull
    End Sub
End Class