Imports cSurveyPC.cSurvey.Design

Public Class frmParametersDesign
    Friend Event OnChangeOptions(ByVal Sender As Object, ByVal Options As cIOptionsPreview)

    Private oOptions As cIOptionsPreview
    Private bDisabledEvent As Boolean

    Public Sub New(ByVal Options As cOptions)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oOptions = Options

        bDisabledEvent = True

        cboAdvancedClippingMode.SelectedIndex = oOptions.AdvancedClippingMode
        'chkDrawSolidRock.Checked = oOptions.DrawSolidRock

        bDisabledEvent = False
    End Sub

    Private Sub pSave()
        oOptions.AdvancedClippingMode = cboAdvancedClippingMode.SelectedIndex
        'oOptions.DrawSolidRock = chkDrawSolidRock.Checked
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Call pSave()
        RaiseEvent OnChangeOptions(Me, oOptions)
        Call Close()
        Call Dispose()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Call Close()
        Call Dispose()
    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Call pSave()
        RaiseEvent OnChangeOptions(Me, oOptions)
    End Sub
End Class