﻿Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design

Public Class cDesignPrintOrExportAreaControl
    Public Shadows ReadOnly Property Options As cIOptionPrintAndExportArea
        Get
            Return MyBase.Options
        End Get
    End Property

    Public Shadows Sub Rebind(Design As cIDesign, Options As cOptions)
        MyBase.Rebind(Design, Options)

        chkDesignPrintOrExportArea.Checked = Me.Options.DrawPrintOrExportArea
        Call pRefreshSize()
        pnlDesignPrintOrExportArea.Enabled = chkDesignPrintOrExportArea.Checked

        cboDesignPrintOrExportAreaProfile.Properties.BeginUpdate()
        Call cboDesignPrintOrExportAreaProfile.Properties.Items.Clear()
        For Each oProfile As cPreviewProfile In Me.Options.Survey.PreviewProfiles.ToList.Where(Function(item) item.Design = MyBase.Design.Type)
            Dim oItem As DevExpress.XtraEditors.Controls.ImageComboBoxItem = New DevExpress.XtraEditors.Controls.ImageComboBoxItem(oProfile.Name, oProfile, 1)
            Call cboDesignPrintOrExportAreaProfile.Properties.Items.Add(oItem)
        Next
        For Each oProfile As cExportProfile In Me.Options.Survey.ExportProfiles.ToList.Where(Function(item) item.Design = MyBase.Design.Type)
            Dim oItem As DevExpress.XtraEditors.Controls.ImageComboBoxItem = New DevExpress.XtraEditors.Controls.ImageComboBoxItem(oProfile.Name, oProfile, 0)
            Call cboDesignPrintOrExportAreaProfile.Properties.Items.Add(oItem)
        Next
        cboDesignPrintOrExportAreaProfile.EditValue = Me.Options.GetPrintOrExportProfile(MyBase.Design)
        cboDesignPrintOrExportAreaProfile.Properties.EndUpdate()

        cboDesignPrintOrExportAreaProfileDesignStyle.SelectedIndex = Me.Options.DrawPrintOrExportAreaDesignStyle
    End Sub

    Private Sub pRefreshSize()
        Dim bChecked As Boolean = chkDesignPrintOrExportArea.Checked
        If bChecked Then
            Height = 86 * Me.CurrentAutoScaleDimensions.Height / 96.0F
        Else
            Height = 32 * Me.CurrentAutoScaleDimensions.Height / 96.0F
        End If
    End Sub

    Private Sub chkDesignPrintOrExportArea_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignPrintOrExportArea.CheckedChanged
        If Not DisabledObjectProperty() Then
            Me.Options.DrawPrintOrExportArea = chkDesignPrintOrExportArea.Checked
            pnlDesignPrintOrExportArea.Enabled = chkDesignPrintOrExportArea.Checked
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("DrawPrintOrExportArea")
            Call MyBase.DrawInvalidate()
        End If
        Call pRefreshSize()
    End Sub

    Private Sub cboDesignPrintOrExportAreaProfileDesignStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDesignPrintOrExportAreaProfileDesignStyle.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Me.Options.DrawPrintOrExportAreaDesignStyle = cboDesignPrintOrExportAreaProfileDesignStyle.SelectedIndex
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("PrintOrExportProfile")
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    Private Sub cmdDesignBaseRule_Click(sender As Object, e As EventArgs) Handles cmdDesignBaseRule.Click
        Using frmSR As frmScaleRules = New frmScaleRules(MyBase.Design.Survey, frmScaleRules.EditStyleEnum.BaseRule, Me.Options.GetOption)
            If frmSR.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Call MyBase.DrawInvalidate()
            End If
        End Using
    End Sub

    Private Sub cboDesignPrintOrExportAreaProfile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDesignPrintOrExportAreaProfile.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call Me.Options.SetPrintOrExportProfile(cboDesignPrintOrExportAreaProfile.EditValue)
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("PrintOrExportProfile")
            Call MyBase.DrawInvalidate()
        End If
    End Sub

    Private Sub cboDesignPrintOrExportAreaProfile_Resize(sender As Object, e As EventArgs) Handles cboDesignPrintOrExportAreaProfile.Resize
        cboDesignPrintOrExportAreaProfile.Width = cboDesignPrintOrExportAreaProfile.Parent.Width - 127 * Me.CurrentAutoScaleDimensions.Height / 96.0F
    End Sub
End Class
