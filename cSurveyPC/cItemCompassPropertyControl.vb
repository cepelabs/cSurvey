Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Drawings

Friend Class cItemCompassPropertyControl
    Private oItem As cItemCompass

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Overrides Sub Rebind(Item As cItem)
        oItem = Item

        picCompassClipartImage.Image = oItem.Clipart.Clipart.GetThumbnailImage(picCompassClipartImage.Width, picCompassClipartImage.Height)
        txtCompassClipartZoomFactor.Value = oItem.ClipartScale

        cboCompassMode.SelectedIndex = oItem.Mode
        cboCompassNorth.SelectedIndex = oItem.North
        If oItem.Year = 0 Then
            txtCompassYear.Value = Today.Year
        Else
            txtCompassYear.Value = oItem.Year
        End If
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
                        oItem.Clipart = oItem.Survey.Signs.Cliparts.Add(.FileName)
                        picCompassClipartImage.Image = oItem.Clipart.Clipart.GetThumbnailImage(picCompassClipartImage.Width, picCompassClipartImage.Height)
                    Catch
                        picCompassClipartImage.Image = Nothing
                    End Try
                    Call MyBase.PropertyChanged("clipart")
                    Call MyBase.MapInvalidate()
                End If
            End With
        End Using
    End Sub

    Private Sub txtCompassClipartZoomFactor_ValueChanged(sender As Object, e As EventArgs) Handles txtCompassClipartZoomFactor.ValueChanged
        Try
            If Not DisabledObjectProperty() Then
                oItem.ClipartScale = txtCompassClipartZoomFactor.Value
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
                oItem.North = cboCompassNorth.SelectedIndex
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
                oItem.Mode = cboCompassMode.SelectedIndex
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
                oItem.Year = txtCompassYear.Value
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("year")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub
End Class
