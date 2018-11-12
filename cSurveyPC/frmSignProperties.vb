Imports cSurveyPC.cSurvey.Design.Items

Public Class frmSignProperties
    Private oItem As cIItemSign

    Public Sub New(Item As cIItemSign)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oItem = Item

        txtSignRotationAngleDelta.Value = oItem.SignRotationAngleDelta

        'Select Case oItem.QuotaType
        '    Case cIItemQuota.QuotaTypeEnum.Horizontal, cIItemQuota.QuotaTypeEnum.Vertical
        '        cboQuotaCapDecoration.SelectedIndex = oItem.QuotaCapDecoration
        '        txtQuotaLeftRefPercent.Value = oItem.QuotaLeftRefPercent
        '        txtQuotaRightRefPercent.Value = oItem.QuotaRightRefPercent
        '        frmHVQuota.Visible = True
        '        frmScaleQuota.Visible = False
        '        frmHVQuota.Location = New Point(12, 12)
        '    Case cIItemQuota.QuotaTypeEnum.HorizontalScale, cIItemQuota.QuotaTypeEnum.VerticalScale, cIItemQuota.QuotaTypeEnum.GridScale
        '        txtQuotatickfrequency.Value = oItem.QuotaTickFrequency
        '        txtQuotaticklabelfrequency.Value = oItem.QuotaTickLabelFrequency
        '        txtQuotaticksize.Value = IIf(oItem.QuotaTickSize < txtQuotaticksize.Minimum, txtQuotaticksize.Minimum, oItem.QuotaTickSize)
        '        frmHVQuota.Visible = False
        '        frmScaleQuota.Visible = True
        '        frmScaleQuota.Location = New Point(12, 12)
        'End Select
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As System.EventArgs) Handles cmdOk.Click
        oItem.SignRotationAngleDelta = txtSignRotationAngleDelta.Value
        'Select Case oItem.QuotaType
        '    Case cIItemQuota.QuotaTypeEnum.Horizontal, cIItemQuota.QuotaTypeEnum.Vertical
        '        oItem.QuotaCapDecoration = cboQuotaCapDecoration.SelectedIndex
        '        oItem.QuotaLeftRefPercent = txtQuotaLeftRefPercent.Value
        '        oItem.QuotaRightRefPercent = txtQuotaRightRefPercent.Value
        '    Case cIItemQuota.QuotaTypeEnum.HorizontalScale, cIItemQuota.QuotaTypeEnum.VerticalScale, cIItemQuota.QuotaTypeEnum.GridScale
        '        oItem.QuotaTickFrequency = txtQuotatickfrequency.Value
        '        oItem.QuotaTickLabelFrequency = txtQuotaticklabelfrequency.Value
        '        oItem.QuotaTickSize = txtQuotaticksize.Value
        'End Select
    End Sub
End Class