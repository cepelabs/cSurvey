Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Drawings

Friend Class cItemCompassPropertyControl
    Public Shadows ReadOnly Property Item As cItemCompass
        Get
            Return MyBase.Item
        End Get
    End Property

    Public Shadows Sub Rebind(Item As cItemCompass)
        Call MyBase.Rebind(Item)

        picCompassClipartImage.Image = Me.Item.Clipart.Clipart.GetThumbnailImage(picCompassClipartImage.Width, picCompassClipartImage.Height)
        txtCompassClipartZoomFactor.Value = Me.Item.ClipartScale
        chkUseClipartScaleOnText.Checked = Me.Item.UseClipartScaleOnText
        chkUseTextScaleOnClipart.Checked = Me.Item.UseTextScaleOnClipart
        cboCompassMode.SelectedIndex = Me.Item.Mode
        cboCompassNorth.SelectedIndex = Me.Item.North
        If Me.Item.Year = 0 Then
            txtCompassYear.Value = Today.Year
        Else
            txtCompassYear.Value = Me.Item.Year
        End If
        chkHideNorthValue.Checked = Me.Item.HideNorthValue
        Call pSetEnabled()
    End Sub

    Private Sub cmdCompassBrowseClipart_Click(sender As Object, e As EventArgs) Handles cmdCompassBrowseClipart.Click
        Using oOfd As OpenFileDialog = New OpenFileDialog
            With oOfd
                .Title = GetLocalizedString("parameterscompass.openclipartdialog")
                .Filter = GetLocalizedString("parameterscompass.filetypeSVG") & " (*.SVG)|*.SVG|" & GetLocalizedString("parameterscompass.filetypeALL") & " (*.*)|*.*"
                .FilterIndex = 1
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Try
                        Item.Clipart = Item.Survey.Signs.Cliparts.Add(.FileName)
                        picCompassClipartImage.SvgImage = modDevExpress.SvgImageFromClipart(Item.Clipart.Clipart)
                    Catch
                        picCompassClipartImage.SvgImage = Nothing
                    End Try
                    Call MyBase.TakeUndoSnapshot()
                    Call MyBase.PropertyChanged("clipart")
                    Call MyBase.MapInvalidate()
                End If
            End With
        End Using
    End Sub

    Private Sub txtCompassClipartZoomFactor_ValueChanged(sender As Object, e As EventArgs) Handles txtCompassClipartZoomFactor.ValueChanged
        Try
            If Not DisabledObjectProperty() Then
                Item.ClipartScale = txtCompassClipartZoomFactor.Value
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("clipartscale")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub cboCompassNorth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCompassNorth.SelectedIndexChanged
        Try
            If Not DisabledObjectProperty() Then
                Item.North = cboCompassNorth.SelectedIndex
                Call pSetEnabled()
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("north")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub pSetEnabled()
        Dim bEnabled As Boolean = cboCompassMode.SelectedIndex = 1
        lblCompassNorth.Enabled = bEnabled
        cboCompassNorth.Enabled = bEnabled
        bEnabled = bEnabled And cboCompassNorth.SelectedIndex = 1
        lblCompassYear.Enabled = bEnabled
        txtCompassYear.Enabled = bEnabled
    End Sub

    Private Sub cboCompassMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCompassMode.SelectedIndexChanged
        Try
            If Not DisabledObjectProperty() Then
                Item.Mode = cboCompassMode.SelectedIndex
                Call pSetEnabled()
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("mode")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub txtCompassYear_ValueChanged(sender As Object, e As EventArgs) Handles txtCompassYear.ValueChanged
        Try
            If Not DisabledObjectProperty() Then
                Item.Year = txtCompassYear.Value
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("year")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub chkUseTextScaleOnClipart_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseTextScaleOnClipart.CheckedChanged
        Try
            If Not DisabledObjectProperty() Then
                Item.UseTextScaleOnClipart = chkUseTextScaleOnClipart.Checked
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("usetextscaleonclipart")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub chkUseClipartScaleOnText_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseClipartScaleOnText.CheckedChanged
        Try
            If Not DisabledObjectProperty() Then
                Item.UseClipartScaleOnText = chkUseClipartScaleOnText.Checked
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("useclipartscaleontext")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub chkHideNorthValue_CheckedChanged(sender As Object, e As EventArgs) Handles chkHideNorthValue.CheckedChanged
        Try
            If Not DisabledObjectProperty() Then
                Item.HideNorthValue = chkHideNorthValue.Checked
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("hidescalevalue")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub
End Class
