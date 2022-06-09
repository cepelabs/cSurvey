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

        bEventDisabled = False
    End Sub

    Private Sub cboAdvancedClippingMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAdvancedClippingMode.SelectedIndexChanged
        If Not oOptions Is Nothing AndAlso Not bEventDisabled Then
            oOptions.AdvancedClippingMode = cboAdvancedClippingMode.SelectedIndex
        End If
    End Sub
End Class