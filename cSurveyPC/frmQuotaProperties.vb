Imports cSurveyPC.cSurvey.Design.Items

friend Class frmQuotaProperties
    Public Shadows ReadOnly Property Item As cItemQuota
        Get
            Return MyBase.Item
        End Get
    End Property

    Public Shadows Sub Rebind(Item As cItemQuota)
        Call MyBase.Rebind(Item)

        Select Case Item.QuotaType
            Case cIItemQuota.QuotaTypeEnum.Horizontal, cIItemQuota.QuotaTypeEnum.Vertical
                cboQuotaCapDecoration.SelectedIndex = Item.QuotaCapDecoration
                txtQuotaLeftRefPercent.Value = Item.QuotaLeftRefPercent
                txtQuotaRightRefPercent.Value = Item.QuotaRightRefPercent
                frmHVQuota.Visible = True
                frmScaleQuota.Visible = False
                frmHVQuota.Location = New Point(12, 12)
                Me.Height = frmHVQuota.Height + frmHVQuota.Top * 2
            Case cIItemQuota.QuotaTypeEnum.HorizontalScale, cIItemQuota.QuotaTypeEnum.VerticalScale, cIItemQuota.QuotaTypeEnum.GridScale
                txtQuotatickfrequency.Value = Item.QuotaTickFrequency
                txtQuotaticklabelfrequency.Value = Item.QuotaTickLabelFrequency
                txtQuotaticksize.Value = If(Item.QuotaTickSize < txtQuotaticksize.Minimum, txtQuotaticksize.Minimum, Item.QuotaTickSize)
                frmHVQuota.Visible = False
                frmScaleQuota.Visible = True
                frmScaleQuota.Location = New Point(12, 12)
                Me.Height = frmScaleQuota.Height + frmScaleQuota.Top * 2
        End Select
    End Sub

    'Private Sub cmdOk_Click(sender As Object, e As System.EventArgs) Handles cmdOk.Click
    '    Select Case Item.QuotaType
    '        Case cIItemQuota.QuotaTypeEnum.Horizontal, cIItemQuota.QuotaTypeEnum.Vertical
    '            oItem.QuotaCapDecoration = cboQuotaCapDecoration.SelectedIndex
    '            oItem.QuotaLeftRefPercent = txtQuotaLeftRefPercent.Value
    '            oItem.QuotaRightRefPercent = txtQuotaRightRefPercent.Value
    '        Case cIItemQuota.QuotaTypeEnum.HorizontalScale, cIItemQuota.QuotaTypeEnum.VerticalScale, cIItemQuota.QuotaTypeEnum.GridScale
    '            oItem.QuotaTickFrequency = txtQuotatickfrequency.Value
    '            oItem.QuotaTickLabelFrequency = txtQuotaticklabelfrequency.Value
    '            oItem.QuotaTickSize = txtQuotaticksize.Value
    '    End Select
    'End Sub

    Private Sub txtQuotatickfrequency_ValueChanged(sender As Object, e As EventArgs) Handles txtQuotatickfrequency.ValueChanged
        If Not DisabledObjectProperty() Then
            Me.Item.QuotaTickFrequency = txtQuotatickfrequency.Value
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("QuotaTickFrequency")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboQuotaCapDecoration_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboQuotaCapDecoration.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Me.Item.QuotaCapDecoration = cboQuotaCapDecoration.SelectedIndex
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("QuotaCapDecoration")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtQuotaticklabelfrequency_ValueChanged(sender As Object, e As EventArgs) Handles txtQuotaticklabelfrequency.ValueChanged
        If Not DisabledObjectProperty() Then
            Me.Item.QuotaTickLabelFrequency = txtQuotaticklabelfrequency.Value
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("QuotaTickLabelFrequency")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtQuotaLeftRefPercent_ValueChanged(sender As Object, e As EventArgs) Handles txtQuotaLeftRefPercent.ValueChanged
        If Not DisabledObjectProperty() Then
            Me.Item.QuotaLeftRefPercent = txtQuotaLeftRefPercent.Value
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("QuotaLeftRefPercent")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtQuotaRightRefPercent_ValueChanged(sender As Object, e As EventArgs) Handles txtQuotaRightRefPercent.ValueChanged
        If Not DisabledObjectProperty() Then
            Me.Item.QuotaRightRefPercent = txtQuotaRightRefPercent.Value
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("QuotaRightRefPercent")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtQuotaticksize_ValueChanged(sender As Object, e As EventArgs) Handles txtQuotaticksize.ValueChanged
        If Not DisabledObjectProperty() Then
            Me.Item.QuotaTickSize = txtQuotaticksize.Value
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("QuotaTickSize")
            Call MyBase.MapInvalidate()
        End If
    End Sub
End Class