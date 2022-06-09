Public Class cElevationDropDown
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(Me, False)
        MyBase.Enabled = False
    End Sub

    Public Event SelectedIndexChanged(Sender As Object, e As EventArgs)

    Public Function ContainsElevation(ID As String) As Boolean
        For Each oItem As DevExpress.XtraEditors.Controls.ImageComboBoxItem In cboElevationData.Properties.Items
            If DirectCast(oItem.Value, cSurvey.Surface.cElevation).ID = ID Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function ContainsElevation(Elevation As cSurvey.Surface.cElevation) As Boolean
        Return ContainsElevation(Elevation.ID)
    End Function

    Public Function SetSelectedElevation(ID As String) As Boolean
        For Each oItem As DevExpress.XtraEditors.Controls.ImageComboBoxItem In cboElevationData.Properties.Items
            If DirectCast(oItem.Value, cSurvey.Surface.cElevation).ID = ID Then
                cboElevationData.SelectedItem = oItem
                Return True
            End If
        Next
        Return False
    End Function

    Public Function SetSelectedElevation(Elevation As cSurvey.Surface.cElevation) As Boolean
        Return SetSelectedElevation(Elevation.ID)
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

    Public Function Rebind(Elevations As cSurvey.Surface.cElevations, Reset As Boolean, Optional AllowNull As Boolean = False) As Boolean
        Dim oCurrentValue As cSurvey.Surface.cElevation = Nothing
        If Not Reset Then oCurrentValue = cboElevationData.EditValue
        Call iml.Images.Clear()
        iml.ImageSize = New Size(48 * Me.CurrentAutoScaleDimensions.Height / 96.0F, 32 * Me.CurrentAutoScaleDimensions.Height / 96.0F)
        Call cboElevationData.Properties.Items.Clear()

        Call cElevationDropDown_Resize(Me, EventArgs.Empty)

        Dim iElevation As Integer = 0
        If AllowNull Then cboElevationData.Properties.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", Nothing, -1))
        For Each oElevation As cSurvey.Surface.cElevation In Elevations
            If Not oElevation.IsEmpty Then
                Call iml.AddImage(oElevation.GetImage(iml.ImageSize))
                Dim iElevationIndex As Integer = cboElevationData.Properties.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(oElevation.Name, oElevation, iElevation))
                iElevation += 1
            End If
        Next
        If iElevation > 0 Then
            If oCurrentValue Is Nothing Then
                cboElevationData.EditValue = cboElevationData.Properties.Items(0)
            Else
                If ContainsElevation(oCurrentValue) Then
                    Call SetSelectedElevation(oCurrentValue)
                Else
                    cboElevationData.EditValue = cboElevationData.Properties.Items(0)
                End If
            End If
            MyBase.Enabled = True
            Return True
        Else
            MyBase.Enabled = False
            Return False
        End If
    End Function

    Public Function Rebind(Survey As cSurveyPC.cSurvey.cSurvey, Reset As Boolean, Optional AllowNull As Boolean = False) As Boolean
        Call Rebind(Survey.Surface.Elevations, Reset, AllowNull)
    End Function

    Private Sub cboElevationData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboElevationData.SelectedIndexChanged
        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub
End Class
