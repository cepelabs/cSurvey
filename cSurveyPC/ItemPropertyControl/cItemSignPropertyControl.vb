Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Drawings

Friend Class cItemSignPropertyControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        For Each iValue As Items.cIItemSign.SignEnum In System.Enum.GetValues(GetType(Items.cIItemSign.SignEnum))
            Call cboPropSign.Items.Add(GetLocalizedString("main.sign" & iValue.ToString("D")))
        Next
    End Sub

    Public Shadows ReadOnly Property Item As cItemSign
        Get
            Return MyBase.Item
        End Get
    End Property

    Public Shadows Sub Rebind(Item As cItemSign)
        Call MyBase.Rebind(Item)

        cboPropSignSize.SelectedIndex = Me.Item.SignSize
        cboPropSignRotateMode.SelectedIndex = Me.Item.SignRotateMode
        txtPropSignRotationAngleDelta.EditValue = Me.Item.SignRotationAngleDelta
        cboPropSignFlip.SelectedIndex = Me.Item.SignFlip
        cboPropSign.SelectedIndex = New List(Of Items.cIItemSign.SignEnum)(System.Enum.GetValues(GetType(Items.cIItemSign.SignEnum))).IndexOf(Me.Item.Sign)
    End Sub

    Private Sub cboPropSignRotateMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropSignRotateMode.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo50"), "SignRotateMode")
            Me.Item.SignRotateMode = cboPropSignRotateMode.SelectedIndex
            Call MyBase.PropertyChanged("SignRotateMode")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropSignFlip_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropSignFlip.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo50"), "SignFlip")
            Me.Item.SignFlip = cboPropSignFlip.SelectedIndex
            Call MyBase.PropertyChanged("SignFlip")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropSignSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropSignSize.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo50"), "SignSize")
            Me.Item.SignSize = cboPropSignSize.SelectedIndex
            Call MyBase.PropertyChanged("SignSize")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropSign_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropSign.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo50"), "Sign")
            Me.Item.Sign = New List(Of Items.cIItemSign.SignEnum)(System.Enum.GetValues(GetType(Items.cIItemSign.SignEnum))).Item(cboPropSign.SelectedIndex)
            Call MyBase.PropertyChanged("PropSign")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropSignRotationAngleDelta_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropSignRotationAngleDelta.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo50"), "SignRotationAngleDelta")
            Me.Item.SignRotationAngleDelta = txtPropSignRotationAngleDelta.EditValue
            Call MyBase.PropertyChanged("SignRotationAngleDelta")
            Call MyBase.MapInvalidate()
        End If
    End Sub
End Class
