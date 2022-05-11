Public Class cElevationDropDown
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MyBase.Enabled = False
    End Sub

    Public Event SelectedIndexChanged(Sender As Object, e As EventArgs)

    Public Function SetSelectedElevation(Elevation As cSurvey.Surface.cElevation) As Boolean
        For Each oItem As DevExpress.XtraEditors.Controls.ImageComboBoxItem In cboElevationData.Properties.Items
            If oItem.Value Is Elevation Then
                cboElevationData.SelectedItem = oItem
                Return True
            End If
        Next
        Return False
    End Function

    Public Function GetSelectedElevation() As cSurvey.Surface.cElevation
        If cboElevationData.SelectedItem Is Nothing Then
            Return Nothing
        Else
            Return cboElevationData.SelectedItem.value
        End If
    End Function

    Public ReadOnly Property Count() As Integer
        Get
            Return cboElevationData.Properties.Items.Count
        End Get
    End Property

    Private Sub cElevationDropDown_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If MyBase.Height <> cboElevationData.Height Then
            MyBase.Height = cboElevationData.Height
        End If
    End Sub

    Public Function Rebind(Survey As cSurveyPC.cSurvey.cSurvey) As Boolean
        Dim iElevation As Integer = 0
        Call cboElevationData.Properties.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", Nothing, -1))
        For Each oElevation As cSurvey.Surface.cElevation In Survey.Surface.Elevations
            Call iml.AddImage(oElevation.GetImage(New Size(48, 32)))
            Dim iElevationIndex As Integer = cboElevationData.Properties.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(oElevation.Name, oElevation, iElevation))
            If oElevation.Default Then
                cboElevationData.SelectedIndex = iElevationIndex
            End If
            iElevation += 1
        Next
        Dim bEnabled As Boolean = iElevation > 0
        MyBase.Enabled = bEnabled
        Return bEnabled
    End Function

    Private Sub cboElevationData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboElevationData.SelectedIndexChanged
        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub
End Class
