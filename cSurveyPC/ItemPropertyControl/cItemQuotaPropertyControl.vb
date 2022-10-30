Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Drawings
Imports DevExpress.Utils

Friend Class cItemQuotaPropertyControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Shadows ReadOnly Property Item As cItemQuota
        Get
            Return MyBase.Item
        End Get
    End Property

    Public Shadows Sub Rebind(Item As cItemQuota)
        Call MyBase.Rebind(Item)

        cboPropQuotaType.SelectedIndex = Me.Item.QuotaType
        cboPropQuotaAlign.SelectedIndex = Me.Item.QuotaAlign
        cboPropQuotaValue.SelectedIndex = Me.Item.QuotaValue
        cboPropQuotaValueType.SelectedIndex = Me.Item.QuotaValueType
        cboPropQuotaTextPosition.SelectedIndex = Me.Item.QuotaTextPosition
        txtPropQuotaRelativeTrigpoint.EditValue = Me.Item.QuotaRelativeTrigpoint

        Select Case Me.Item.QuotaType
            Case cIItemQuota.QuotaTypeEnum.Drop
                lblPropQuotaAlign.Enabled = False
                cboPropQuotaAlign.Enabled = False
                lblPropQuotaRelativeTrigpoint.Enabled = True
                txtPropQuotaRelativeTrigpoint.Properties.Buttons(0).Enabled = True
                cmdPropQuotaOtherOptions.Enabled = False
                lblPropQuotaValue.Enabled = True
                cboPropQuotaValue.Enabled = True
                lblPropQuotaValueType.Enabled = True
                cboPropQuotaValueType.Enabled = True
                lblPropQuotaTextPosition.Enabled = False
                cboPropQuotaTextPosition.Enabled = False
                lblPropQuotaFormat.Enabled = False
                cboPropQuotaFormat.Enabled = False
            Case cIItemQuota.QuotaTypeEnum.VerticalScale, cIItemQuota.QuotaTypeEnum.HorizontalScale
                lblPropQuotaAlign.Enabled = True
                cboPropQuotaAlign.Enabled = True
                lblPropQuotaRelativeTrigpoint.Enabled = True
                txtPropQuotaRelativeTrigpoint.Properties.Buttons(0).Enabled = True
                cmdPropQuotaOtherOptions.Enabled = True
                lblPropQuotaValue.Enabled = False
                cboPropQuotaValue.Enabled = False
                lblPropQuotaValueType.Enabled = False
                cboPropQuotaValueType.Enabled = False
                lblPropQuotaTextPosition.Enabled = True
                cboPropQuotaTextPosition.Enabled = True
                lblPropQuotaFormat.Enabled = False
                cboPropQuotaFormat.Enabled = False
            Case cIItemQuota.QuotaTypeEnum.GridScale
                lblPropQuotaAlign.Enabled = False
                cboPropQuotaAlign.Enabled = False
                lblPropQuotaRelativeTrigpoint.Enabled = True
                txtPropQuotaRelativeTrigpoint.Properties.Buttons(0).Enabled = True
                cmdPropQuotaOtherOptions.Enabled = True
                lblPropQuotaValue.Enabled = False
                cboPropQuotaValue.Enabled = False
                lblPropQuotaValueType.Enabled = False
                cboPropQuotaValueType.Enabled = False
                lblPropQuotaTextPosition.Enabled = True
                cboPropQuotaTextPosition.Enabled = True
                lblPropQuotaFormat.Enabled = False
                cboPropQuotaFormat.Enabled = False
            Case cIItemQuota.QuotaTypeEnum.Altitude
                lblPropQuotaAlign.Enabled = False
                lblPropQuotaRelativeTrigpoint.Enabled = False
                txtPropQuotaRelativeTrigpoint.Properties.Buttons(0).Enabled = False
                cmdPropQuotaOtherOptions.Enabled = True
                lblPropQuotaValue.Enabled = True
                cboPropQuotaValue.Enabled = True
                lblPropQuotaValueType.Enabled = True
                cboPropQuotaValueType.Enabled = True
                lblPropQuotaTextPosition.Enabled = False
                cboPropQuotaTextPosition.Enabled = False
                lblPropQuotaFormat.Enabled = False
                cboPropQuotaFormat.Enabled = False
            Case cIItemQuota.QuotaTypeEnum.Horizontal, cIItemQuota.QuotaTypeEnum.Vertical
                lblPropQuotaAlign.Enabled = True
                cboPropQuotaAlign.Enabled = True
                lblPropQuotaRelativeTrigpoint.Enabled = False
                txtPropQuotaRelativeTrigpoint.Properties.Buttons(0).Enabled = False
                cmdPropQuotaOtherOptions.Enabled = True
                lblPropQuotaValue.Enabled = True
                cboPropQuotaValue.Enabled = True
                lblPropQuotaValueType.Enabled = True
                cboPropQuotaValueType.Enabled = True
                lblPropQuotaTextPosition.Enabled = False
                cboPropQuotaTextPosition.Enabled = False
                lblPropQuotaFormat.Enabled = True
                cboPropQuotaFormat.Enabled = True
            Case cIItemQuota.QuotaTypeEnum.Oblique
                lblPropQuotaAlign.Enabled = False
                cboPropQuotaAlign.Enabled = False
                lblPropQuotaRelativeTrigpoint.Enabled = False
                txtPropQuotaRelativeTrigpoint.Properties.Buttons(0).Enabled = False
                cmdPropQuotaOtherOptions.Enabled = False
                lblPropQuotaValue.Enabled = True
                cboPropQuotaValue.Enabled = True
                lblPropQuotaValueType.Enabled = True
                cboPropQuotaValueType.Enabled = True
                lblPropQuotaTextPosition.Enabled = False
                cboPropQuotaTextPosition.Enabled = False
                lblPropQuotaFormat.Enabled = True
                cboPropQuotaFormat.Enabled = True
            Case Else
                lblPropQuotaAlign.Enabled = True
                cboPropQuotaAlign.Enabled = True
                lblPropQuotaRelativeTrigpoint.Enabled = False
                txtPropQuotaRelativeTrigpoint.Properties.Buttons(0).Enabled = False
                cmdPropQuotaOtherOptions.Enabled = False
                lblPropQuotaValue.Enabled = True
                cboPropQuotaValue.Enabled = True
                lblPropQuotaValueType.Enabled = True
                cboPropQuotaValueType.Enabled = True
                lblPropQuotaTextPosition.Enabled = False
                cboPropQuotaTextPosition.Enabled = False
                lblPropQuotaFormat.Enabled = False
                cboPropQuotaFormat.Enabled = False
        End Select
    End Sub

    Private Sub cboPropQuotaType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropQuotaType.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo48"), "QuotaType")
            Me.Item.QuotaType = cboPropQuotaType.SelectedIndex
            Call MyBase.PropertyChanged("QuotaType")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropQuotaAlign_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropQuotaAlign.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo48"), "QuotaAlign")
            Me.Item.QuotaAlign = cboPropQuotaAlign.SelectedIndex
            Call MyBase.PropertyChanged("QuotaAlign")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropQuotaTextPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropQuotaTextPosition.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo48"), "QuotaTextPosition")
            Me.Item.QuotaTextPosition = cboPropQuotaTextPosition.SelectedIndex
            Call MyBase.PropertyChanged("QuotaTextPosition")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropQuotaValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropQuotaValue.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo48"), "QuotaValue")
            Me.Item.QuotaValue = cboPropQuotaValue.SelectedIndex
            Call MyBase.PropertyChanged("QuotaValue")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropQuotaFormat_TextChanged(sender As Object, e As EventArgs) Handles cboPropQuotaFormat.TextChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo48"), "QuotaFormat")
            Me.Item.QuotaFormat = cboPropQuotaFormat.Text
            Call MyBase.PropertyChanged("QuotaFormat")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropQuotaValueType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropQuotaValueType.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo48"), "QuotaValueType")
            Me.Item.QuotaValueType = cboPropQuotaValueType.SelectedIndex
            Call MyBase.PropertyChanged("QuotaValueType")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropQuotaRelativeTrigpoint_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtPropQuotaRelativeTrigpoint.ButtonClick
        If Not DisabledObjectProperty() Then
            Using frmTB As frmTrigpointBrowser = New frmTrigpointBrowser(Me.Item.Survey, txtPropQuotaRelativeTrigpoint.EditValue, True)
                If frmTB.ShowDialog(Me) = vbOK Then
                    Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo48"), "QuotaRelativeTrigpoint")
                    txtPropQuotaRelativeTrigpoint.EditValue = frmTB.SelectedItem
                    Me.Item.QuotaRelativeTrigpoint = txtPropQuotaRelativeTrigpoint.EditValue
                    Call MyBase.PropertyChanged("QuotaTrigpoint")
                    Call MyBase.MapInvalidate()
                End If
            End Using
        End If
    End Sub

    Private Sub oParameters_OnMapInvalidate(Sender As Object, e As EventArgs)
        Call MyBase.MapInvalidate()
    End Sub

    Private Sub cmdPropQuotaOtherOptions_Click(sender As Object, e As EventArgs) Handles cmdPropQuotaOtherOptions.Click
        If Not DisabledObjectProperty() Then
            Dim oParameters As frmQuotaProperties
            If pnlParameters.Controls.Count = 0 Then
                oParameters = New frmQuotaProperties()
                pnlParameters.Controls.Add(oParameters)
                AddHandler oParameters.OnMapInvalidate, AddressOf oParameters_OnMapInvalidate
                flyParameters.OwnerControl = cmdPropQuotaOtherOptions
            Else
                oParameters = pnlParameters.Controls(0)
            End If
            oParameters.Dock = DockStyle.None
            Call oParameters.Rebind(Me.Item)
            flyParameters.Size = oParameters.Size
            oParameters.Dock = DockStyle.Fill
            flyParameters.ShowBeakForm(True)
        End If
    End Sub

    Private Sub cItemQuotaPropertyControl_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        cmdPropQuotaOtherOptions.Location = New Point(Me.Width - cmdPropQuotaOtherOptions.Width - 8 * Me.CurrentAutoScaleDimensions.Height / 96.0F, cmdPropQuotaOtherOptions.Top)
    End Sub
End Class
