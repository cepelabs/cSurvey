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
        picHueColorFrom.BackColor = oColors(0)
        picHueColorTo.BackColor = oColors(255)
    End Sub

    Private Sub pValidateHueAndHeight()
        Dim sMinHue As Single = picHueColorFrom.BackColor.GetHue
        Dim sMaxHue As Single = picHueColorTo.BackColor.GetHue
        If sMinHue = sMaxHue Then
            cmdOk.Enabled = False
        Else
            cmdOk.Enabled = True
        End If
        'Dim sMinAlt As Single = txtHueAltFrom.Value
        'Dim sMaxAlt As Single = txtHueAltTo.Value
    End Sub

    Private Sub btnHueColorFrom_Click(sender As Object, e As EventArgs) Handles btnHueColorFrom.Click
        Using oCD As ColorDialog = New ColorDialog
            With oCD
                .FullOpen = True
                .AnyColor = True
                .Color = picHueColorFrom.BackColor
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    picHueColorFrom.BackColor = .Color
                    Call pValidateHueAndHeight()
                End If
            End With
        End Using
    End Sub

    Private Sub btnHueColorTo_Click(sender As Object, e As EventArgs) Handles btnHueColorTo.Click
        Using oCD As ColorDialog = New ColorDialog
            With oCD
                .FullOpen = True
                .AnyColor = True
                .Color = picHueColorTo.BackColor
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    picHueColorTo.BackColor = .Color
                    Call pValidateHueAndHeight()
                End If
            End With
        End Using
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
        picHueColorFrom.BackColor = modPaint.HsvToRgb(oArgs.MInHue, 1, 1)
        picHueColorTo.BackColor = modPaint.HsvToRgb(oArgs.MaxHue, 1, 1)
    End Sub
End Class