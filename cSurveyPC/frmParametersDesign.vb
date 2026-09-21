Imports cSurveyPC.cSurvey.Design

friend Class frmParametersDesign
    Private oOptions As cIOptionsPreview
    Private bEventDisabled As Boolean

    Public Sub New(ByVal Options As cOptions)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oOptions = Options

        bEventDisabled = True

        cboAdvancedClippingMode.SelectedIndex = oOptions.AdvancedClippingMode
        chkUseCaveBranchColorAsDefaultItemColor.Checked = oOptions.UseCaveBranchColorAsDefaultItemColor

        bEventDisabled = False
    End Sub

    Private Sub cboAdvancedClippingMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAdvancedClippingMode.SelectedIndexChanged
        If Not oOptions Is Nothing AndAlso Not bEventDisabled Then
            oOptions.AdvancedClippingMode = cboAdvancedClippingMode.SelectedIndex
        End If
    End Sub

    Private Sub chkUseCaveBranchColorAsDefaultItemColor_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseCaveBranchColorAsDefaultItemColor.CheckedChanged
        If Not oOptions Is Nothing AndAlso Not bEventDisabled Then
            oOptions.UseCaveBranchColorAsDefaultItemColor = chkUseCaveBranchColorAsDefaultItemColor.Checked
        End If
    End Sub
End Class