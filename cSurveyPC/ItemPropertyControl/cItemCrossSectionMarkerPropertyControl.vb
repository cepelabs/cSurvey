Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Helper.Editor

Friend Class cItemCrossSectionMarkerPropertyControl
    Private oCurrentOptions As cOptions

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Shadows ReadOnly Property Item As cIItemCrossSectionMarker
        Get
            Return MyBase.Item
        End Get
    End Property

    Public Shadows Sub Rebind(Item As cIItemCrossSectionMarker, CurrentOptions As cOptions)
        Call MyBase.Rebind(Item)

        oCurrentOptions = CurrentOptions

        If TypeOf Item Is cItemPlanCrossSectionMarker Then
            Dim oItemPlanCrossSectionMarker As cItemPlanCrossSectionMarker = Item

            txtPropCrossSectionMarkerPosition.Value = oItemPlanCrossSectionMarker.Position * 100

            txtPropCrossSectionMarkerL.Enabled = True
            txtPropCrossSectionMarkerL.Value = oItemPlanCrossSectionMarker.Left
            chkPropCrossSectionMarkerLW.Enabled = True
            chkPropCrossSectionMarkerLW.Checked = oItemPlanCrossSectionMarker.AutoLeftWidth
            txtPropCrossSectionMarkerLW.Enabled = Not chkPropCrossSectionMarkerLW.Checked
            txtPropCrossSectionMarkerLW.Value = oItemPlanCrossSectionMarker.LeftWidth

            txtPropCrossSectionMarkerR.Enabled = True
            txtPropCrossSectionMarkerR.Value = oItemPlanCrossSectionMarker.Right
            chkPropCrossSectionMarkerRW.Enabled = True
            chkPropCrossSectionMarkerRW.Checked = oItemPlanCrossSectionMarker.AutoRightWidth
            txtPropCrossSectionMarkerRW.Enabled = Not chkPropCrossSectionMarkerRW.Checked
            txtPropCrossSectionMarkerRW.Value = oItemPlanCrossSectionMarker.RightWidth

            txtPropCrossSectionMarkerU.Enabled = False
            chkPropCrossSectionMarkerUH.Enabled = False
            txtPropCrossSectionMarkerUH.Enabled = False
            txtPropCrossSectionMarkerD.Enabled = False
            chkPropCrossSectionMarkerDH.Enabled = False
            txtPropCrossSectionMarkerDH.Enabled = False

            lblPropCrossSectionMarkerAlign.Enabled = True
            cboPropCrossSectionMarkerAlign.Enabled = True
            cboPropCrossSectionMarkerAlign.SelectedIndex = oItemPlanCrossSectionMarker.PlanAlignment
            cboPropCrossSectionMarkerAlign.Visible = True

            lblPropCrossSectionMarkerArrowSize.Enabled = True
            chkPropCrossSectionMarkerArrowSizeEnabled.Checked = oItemPlanCrossSectionMarker.ArrowSizeEnabled
            cboPropCrossSectionMarkerArrowSize.Enabled = chkPropCrossSectionMarkerArrowSizeEnabled.Checked
            cboPropCrossSectionMarkerArrowSize.SelectedIndex = oItemPlanCrossSectionMarker.ArrowSize

            lblPropCrossSectionMarkerDeltaAngle.Enabled = True
            chkPropCrossSectionMarkerDeltaAngleEnabled.Checked = oItemPlanCrossSectionMarker.PlanDeltaAngleEnabled
            'txtPropCrossSectionMarkerDeltaAngle.Enabled = chkPropCrossSectionMarkerDeltaAngleEnabled.Checked
            txtPropCrossSectionMarkerDeltaAngle.Value = oItemPlanCrossSectionMarker.PlanDeltaAngle

            cboPropCrossSectionMarkerProfileAlign.Enabled = False
            cboPropCrossSectionMarkerProfileAlign.Visible = False

            cmdPropCrossSectionMarkerLRFromDesign.Enabled = True
            cmdPropCrossSectionMarkerUDFromDesign.Enabled = False

            cboPropCrossSectionMarkerLabelRotation.SelectedIndex = oItemPlanCrossSectionMarker.TextRotateMode
            cboPropCrossSectionMarkerLabelRotation.Enabled = True

            chkPropCrossSectionMarkerLabel.Checked = oItemPlanCrossSectionMarker.TextShow
            cboPropCrossSectionMarkerLabelPosition.SelectedIndex = oItemPlanCrossSectionMarker.TextPosition
            txtPropCrossSectionMarkerLabelDistance.Value = oItemPlanCrossSectionMarker.TextDistance
            cboPropCrossSectionMarkerDirection.SelectedIndex = oItemPlanCrossSectionMarker.CrossSectionItem.Direction
            chkPropCrossSectionMarkerScaleEnabled.Checked = oItemPlanCrossSectionMarker.TextSizeEnabled
            cboPropCrossSectionMarkerScale.Enabled = chkPropCrossSectionMarkerScaleEnabled.Checked
            cboPropCrossSectionMarkerScale.SelectedIndex = oItemPlanCrossSectionMarker.TextSize
        ElseIf TypeOf Item Is cItemProfileCrossSectionMarker Then
            Dim oItemProfileCrossSectionMarker As cItemProfileCrossSectionMarker = Item

            txtPropCrossSectionMarkerPosition.Value = oItemProfileCrossSectionMarker.Position * 100

            txtPropCrossSectionMarkerL.Enabled = False
            chkPropCrossSectionMarkerLW.Enabled = False
            txtPropCrossSectionMarkerLW.Enabled = False
            txtPropCrossSectionMarkerR.Enabled = False
            chkPropCrossSectionMarkerRW.Enabled = False
            txtPropCrossSectionMarkerRW.Enabled = False

            txtPropCrossSectionMarkerU.Enabled = True
            txtPropCrossSectionMarkerU.Value = oItemProfileCrossSectionMarker.Up
            chkPropCrossSectionMarkerUH.Enabled = True
            chkPropCrossSectionMarkerUH.Checked = oItemProfileCrossSectionMarker.AutoUpHeight
            txtPropCrossSectionMarkerUH.Enabled = Not chkPropCrossSectionMarkerUH.Checked
            txtPropCrossSectionMarkerUH.Value = oItemProfileCrossSectionMarker.UpHeight

            txtPropCrossSectionMarkerD.Enabled = True
            txtPropCrossSectionMarkerD.Value = oItemProfileCrossSectionMarker.Down
            chkPropCrossSectionMarkerDH.Enabled = True
            chkPropCrossSectionMarkerDH.Checked = oItemProfileCrossSectionMarker.AutoDownHeight
            txtPropCrossSectionMarkerDH.Enabled = Not chkPropCrossSectionMarkerDH.Checked
            txtPropCrossSectionMarkerDH.Value = oItemProfileCrossSectionMarker.DownHeight

            lblPropCrossSectionMarkerAlign.Enabled = True
            cboPropCrossSectionMarkerAlign.Enabled = False
            cboPropCrossSectionMarkerAlign.Visible = False

            lblPropCrossSectionMarkerArrowSize.Enabled = True
            chkPropCrossSectionMarkerArrowSizeEnabled.Checked = oItemProfileCrossSectionMarker.ArrowSizeEnabled
            cboPropCrossSectionMarkerArrowSize.Enabled = chkPropCrossSectionMarkerArrowSizeEnabled.Checked
            cboPropCrossSectionMarkerArrowSize.SelectedIndex = oItemProfileCrossSectionMarker.ArrowSize

            lblPropCrossSectionMarkerDeltaAngle.Enabled = True
            chkPropCrossSectionMarkerDeltaAngleEnabled.Checked = oItemProfileCrossSectionMarker.ProfileDeltaAngleEnabled
            'txtPropCrossSectionMarkerDeltaAngle.Enabled = chkPropCrossSectionMarkerDeltaAngleEnabled.Checked
            txtPropCrossSectionMarkerDeltaAngle.Value = oItemProfileCrossSectionMarker.ProfileDeltaAngle

            cboPropCrossSectionMarkerProfileAlign.Enabled = True
            cboPropCrossSectionMarkerProfileAlign.SelectedIndex = oItemProfileCrossSectionMarker.ProfileAlignment
            cboPropCrossSectionMarkerProfileAlign.Visible = True

            cmdPropCrossSectionMarkerLRFromDesign.Enabled = False
            cmdPropCrossSectionMarkerUDFromDesign.Enabled = True

            cboPropCrossSectionMarkerLabelRotation.SelectedIndex = oItemProfileCrossSectionMarker.TextRotateMode
            cboPropCrossSectionMarkerLabelRotation.Enabled = True

            chkPropCrossSectionMarkerLabel.Checked = oItemProfileCrossSectionMarker.TextShow
            cboPropCrossSectionMarkerLabelPosition.SelectedIndex = oItemProfileCrossSectionMarker.TextPosition
            txtPropCrossSectionMarkerLabelDistance.Value = oItemProfileCrossSectionMarker.TextDistance
            cboPropCrossSectionMarkerDirection.SelectedIndex = oItemProfileCrossSectionMarker.CrossSectionItem.Direction
            cboPropCrossSectionMarkerScale.SelectedIndex = oItemProfileCrossSectionMarker.TextSize
        End If
    End Sub

    Private Sub cmdPropCrossSectionItem_Click(sender As Object, e As EventArgs) Handles cmdPropCrossSectionItem.Click
        If Not DisabledObjectProperty() Then
            Call MyBase.DoCommand("selectitem", Me.Item.CrossSectionItem, True)
        End If
    End Sub

    Private Sub cboPropCrossSectionMarkerDirection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropCrossSectionMarkerDirection.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), "CrossSectionItem.Direction")
            Me.Item.CrossSectionItem.Direction = cboPropCrossSectionMarkerDirection.SelectedIndex
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("CrossSectionMarkerDirection")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkPropCrossSectionMarkerScaleEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropCrossSectionMarkerScaleEnabled.CheckedChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), "TextSizeEnabled")
            Me.Item.TextSizeEnabled = chkPropCrossSectionMarkerScaleEnabled.Checked
            cboPropCrossSectionMarkerScale.Enabled = chkPropCrossSectionMarkerScaleEnabled.Checked
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("CrossSectionMarkerScaleEnabled")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropCrossSectionMarkerScale_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropCrossSectionMarkerScale.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), "TextSize")
            Me.Item.TextSize = cboPropCrossSectionMarkerScale.SelectedIndex
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("CrossSectionMarkerScale")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropCrossSectionMarkerPosition_ValueChanged(sender As Object, e As EventArgs) Handles txtPropCrossSectionMarkerPosition.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), "CrossSectionItem.MarkerPosition")
            Me.Item.CrossSectionItem.MarkerPosition = txtPropCrossSectionMarkerPosition.Value / 100
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("CrossSectionMarkerPosition")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropCrossSectionMarkerU_ValueChanged(sender As Object, e As EventArgs) Handles txtPropCrossSectionMarkerU.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).Up), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).Up = value))
            DirectCast(Me.Item, cIItemProfileCrossSectionMarker).Up = txtPropCrossSectionMarkerU.Value
            Call MyBase.PropertyChanged("CrossSectionMarkerU")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cmdPropCrossSectionMarkerUDFromDesign_Click(sender As Object, e As EventArgs) Handles cmdPropCrossSectionMarkerUDFromDesign.Click
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo46"))
            Dim oItem As cIItemProfileCrossSectionMarker = Me.Item
            Call oItem.SetUDFromDesign(oCurrentOptions)
            txtPropCrossSectionMarkerU.Value = oItem.Up
            txtPropCrossSectionMarkerD.Value = oItem.Down
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("CrossSectionMarkerUDFromDesign")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cmdPropCrossSectionMarkerLRFromDesign_Click(sender As Object, e As EventArgs) Handles cmdPropCrossSectionMarkerLRFromDesign.Click
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo46"))
            Dim oItem As cIItemPlanCrossSectionMarker = Me.Item
            Call oItem.SetLRFromDesign(oCurrentOptions)
            txtPropCrossSectionMarkerL.Value = oItem.Left
            txtPropCrossSectionMarkerR.Value = oItem.Right
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("CrossSectionMarkerLRFromDesign")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkPropCrossSectionMarkerUH_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropCrossSectionMarkerUH.CheckedChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).AutoUpHeight), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).AutoUpHeight = value))
            DirectCast(Me.Item, cIItemProfileCrossSectionMarker).AutoUpHeight = chkPropCrossSectionMarkerUH.Checked
            txtPropCrossSectionMarkerUH.Enabled = Not chkPropCrossSectionMarkerUH.Checked
            Call MyBase.PropertyChanged("CrossSectionMarkerAutoUH")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropCrossSectionMarkerUH_ValueChanged(sender As Object, e As EventArgs) Handles txtPropCrossSectionMarkerUH.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).UpHeight), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).UpHeight = value))
            DirectCast(Me.Item, cIItemProfileCrossSectionMarker).UpHeight = txtPropCrossSectionMarkerUH.Value
            Call MyBase.PropertyChanged("CrossSectionMarkerUH")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropCrossSectionMarkerL_ValueChanged(sender As Object, e As EventArgs) Handles txtPropCrossSectionMarkerL.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).Left), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).Left = value))
            DirectCast(Me.Item, cIItemPlanCrossSectionMarker).Left = txtPropCrossSectionMarkerL.Value
            Call MyBase.PropertyChanged("CrossSectionMarkerL")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropCrossSectionMarkerR_ValueChanged(sender As Object, e As EventArgs) Handles txtPropCrossSectionMarkerR.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).Right), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).Right = value))
            DirectCast(Me.Item, cIItemPlanCrossSectionMarker).Right = txtPropCrossSectionMarkerR.Value
            Call MyBase.PropertyChanged("CrossSectionMarkerR")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkPropCrossSectionMarkerLW_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropCrossSectionMarkerLW.CheckedChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).AutoLeftWidth), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).AutoLeftWidth = value))
            DirectCast(Me.Item, cIItemPlanCrossSectionMarker).AutoLeftWidth = chkPropCrossSectionMarkerLW.Checked
            txtPropCrossSectionMarkerLW.Enabled = Not chkPropCrossSectionMarkerLW.Checked
            Call MyBase.PropertyChanged("CrossSectionMarkerAutoLW")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropCrossSectionMarkerLW_ValueChanged(sender As Object, e As EventArgs) Handles txtPropCrossSectionMarkerLW.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).LeftWidth), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).LeftWidth = value))
            DirectCast(Me.Item, cIItemPlanCrossSectionMarker).LeftWidth = txtPropCrossSectionMarkerLW.Value
            Call MyBase.PropertyChanged("CrossSectionMarkerLW")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkPropCrossSectionMarkerRW_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropCrossSectionMarkerRW.CheckedChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).AutoRightWidth), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).AutoRightWidth = value))
            DirectCast(Me.Item, cIItemPlanCrossSectionMarker).AutoRightWidth = chkPropCrossSectionMarkerRW.Checked
            txtPropCrossSectionMarkerRW.Enabled = Not chkPropCrossSectionMarkerRW.Checked
            Call MyBase.PropertyChanged("CrossSectionMarkerAutoRW")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropCrossSectionMarkerRW_ValueChanged(sender As Object, e As EventArgs) Handles txtPropCrossSectionMarkerRW.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).RightWidth), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).RightWidth = value))
            DirectCast(Me.Item, cIItemPlanCrossSectionMarker).RightWidth = txtPropCrossSectionMarkerRW.Value
            Call MyBase.PropertyChanged("CrossSectionMarkerRW")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropCrossSectionMarkerD_ValueChanged(sender As Object, e As EventArgs) Handles txtPropCrossSectionMarkerD.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).Down), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).Down = value))
            DirectCast(Me.Item, cIItemProfileCrossSectionMarker).Down = txtPropCrossSectionMarkerD.Value
            Call MyBase.PropertyChanged("CrossSectionMarkerD")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkPropCrossSectionMarkerDH_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropCrossSectionMarkerDH.CheckedChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).AutoDownHeight), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).AutoDownHeight = value))
            DirectCast(Me.Item, cIItemProfileCrossSectionMarker).AutoDownHeight = chkPropCrossSectionMarkerDH.Checked
            txtPropCrossSectionMarkerDH.Enabled = Not chkPropCrossSectionMarkerDH.Checked
            Call MyBase.PropertyChanged("CrossSectionMarkerAutoDH")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropCrossSectionMarkerDH_ValueChanged(sender As Object, e As EventArgs) Handles txtPropCrossSectionMarkerDH.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).DownHeight), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).DownHeight = value))
            DirectCast(Me.Item, cIItemProfileCrossSectionMarker).DownHeight = txtPropCrossSectionMarkerDH.Value
            Call MyBase.PropertyChanged("CrossSectionMarkerDH")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropCrossSectionMarkerAlign_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropCrossSectionMarkerAlign.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).PlanAlignment), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).PlanAlignment = value))
            DirectCast(Me.Item, cIItemPlanCrossSectionMarker).PlanAlignment = cboPropCrossSectionMarkerAlign.SelectedIndex
            Call MyBase.PropertyChanged("CrossSectionMarkerPlanAlignment")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkPropCrossSectionMarkerArrowSizeEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropCrossSectionMarkerArrowSizeEnabled.CheckedChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), "ArrowSizeEnabled")
            Me.Item.ArrowSizeEnabled = chkPropCrossSectionMarkerArrowSizeEnabled.Checked
            cboPropCrossSectionMarkerArrowSize.Enabled = chkPropCrossSectionMarkerArrowSizeEnabled.Checked
            Call MyBase.PropertyChanged("CrossSectionMarkerArrowSizeEnabled")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropCrossSectionMarkerArrowSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropCrossSectionMarkerArrowSize.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), "ArrowSize")
            Me.Item.ArrowSize = cboPropCrossSectionMarkerArrowSize.SelectedIndex
            Call MyBase.PropertyChanged("CrossSectionMarkerArrowSize")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkPropCrossSectionMarkerDeltaAngleEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropCrossSectionMarkerDeltaAngleEnabled.CheckedChanged
        If Not DisabledObjectProperty() Then
            If TypeOf Me.Item Is cIItemPlanCrossSectionMarker Then
                Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).PlanDeltaAngleEnabled), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).PlanDeltaAngleEnabled = value))
                Dim oItem As cIItemPlanCrossSectionMarker = Me.Item
                oItem.PlanDeltaAngleEnabled = chkPropCrossSectionMarkerDeltaAngleEnabled.Checked
            ElseIf TypeOf Me.Item Is cIItemProfileCrossSectionMarker Then
                Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).ProfileDeltaAngleEnabled), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).ProfileDeltaAngleEnabled = value))
                Dim oItem As cIItemProfileCrossSectionMarker = Me.Item
                oItem.ProfileDeltaAngleEnabled = chkPropCrossSectionMarkerDeltaAngleEnabled.Checked
            End If
            Call MyBase.PropertyChanged("CrossSectionMarkerDeltaAngleEnabled")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropCrossSectionMarkerDeltaAngle_ValueChanged(sender As Object, e As EventArgs) Handles txtPropCrossSectionMarkerDeltaAngle.ValueChanged
        If Not DisabledObjectProperty() Then
            If TypeOf Me.Item Is cIItemPlanCrossSectionMarker Then
                Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).PlanDeltaAngle), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).PlanDeltaAngle = value))
                Dim oItem As cIItemPlanCrossSectionMarker = Me.Item
                oItem.PlanDeltaAngle = txtPropCrossSectionMarkerDeltaAngle.Value
            ElseIf TypeOf Me.Item Is cIItemProfileCrossSectionMarker Then
                Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).ProfileDeltaAngle), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).ProfileDeltaAngle = value))
                Dim oItem As cIItemProfileCrossSectionMarker = Me.Item
                oItem.ProfileDeltaAngle = txtPropCrossSectionMarkerDeltaAngle.Value
            End If
            Call MyBase.PropertyChanged("CrossSectionMarkerDeltaAngle")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkPropCrossSectionMarkerLabel_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropCrossSectionMarkerLabel.CheckedChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), "TextShow")
            Me.Item.TextShow = chkPropCrossSectionMarkerLabel.Checked
            Call MyBase.PropertyChanged("CrossSectionMarkerLabel")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropCrossSectionMarkerLabelPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropCrossSectionMarkerLabelPosition.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), "TextPosition")
            Me.Item.TextPosition = cboPropCrossSectionMarkerLabelPosition.SelectedIndex
            Call MyBase.PropertyChanged("CrossSectionMarkerLabelPosition")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropCrossSectionMarkerLabelDistance_ValueChanged(sender As Object, e As EventArgs) Handles txtPropCrossSectionMarkerLabelDistance.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), "TextDistance")
            Me.Item.TextDistance = txtPropCrossSectionMarkerLabelDistance.Value
            Call MyBase.PropertyChanged("CrossSectionMarkerLabelDistance")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropCrossSectionMarkerLabelRotation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropCrossSectionMarkerLabelRotation.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            If TypeOf Me.Item Is cIItemPlanCrossSectionMarker Then
                Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).RotateMode), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemPlanCrossSectionMarker).RotateMode = value))
                Dim oItem As cIItemPlanCrossSectionMarker = Me.Item
                oItem.RotateMode = cboPropCrossSectionMarkerLabelRotation.SelectedIndex
            ElseIf TypeOf Me.Item Is cIItemProfileCrossSectionMarker Then
                Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).RotateMode), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).RotateMode = value))
                Dim oItem As cIItemProfileCrossSectionMarker = Me.Item
                oItem.RotateMode = cboPropCrossSectionMarkerLabelRotation.SelectedIndex
            End If
            Call MyBase.PropertyChanged("CrossSectionMarkerLabelRotation")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropCrossSectionMarkerProfileAlign_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropCrossSectionMarkerProfileAlign.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo46"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).ProfileAlignment), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemProfileCrossSectionMarker).ProfileAlignment = value))
            DirectCast(Me.Item, cIItemProfileCrossSectionMarker).ProfileAlignment = cboPropCrossSectionMarkerProfileAlign.SelectedIndex
            Call MyBase.PropertyChanged("CrossSectionMarkerProfileAlignment")
            Call MyBase.MapInvalidate()
        End If
    End Sub

End Class
