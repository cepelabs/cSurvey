Imports System.ComponentModel
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraTreeList

Friend Class cItemPlanSplayPropertyControl
    Private oSurvey As cSurvey.cSurvey

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() 
    End Sub

    Public Shadows ReadOnly Property Item As cIItemPlanSplayBorder
        Get
            Return MyBase.Item
        End Get
    End Property

    Public Shadows Sub Rebind(Item As cIItemPlanSplayBorder)
        MyBase.Rebind(Item)

        Try
            cboPropPlanSplayPlanProjectionType.SelectedIndex = Me.Item.SplayBorderProjectionType
            If cboPropPlanSplayPlanProjectionType.SelectedIndex > 0 Then
                lblPropPlanSplayPlanDeltaZ.Enabled = True
                txtPropPlanSplayPlanDeltaZ.Enabled = True
                lblPropPlanSplayMaxVariationDelta.Enabled = True
                txtPropPlanSplayMaxVariationDelta.Enabled = True
            Else
                lblPropPlanSplayPlanDeltaZ.Enabled = False
                txtPropPlanSplayPlanDeltaZ.Enabled = False
                lblPropPlanSplayMaxVariationDelta.Enabled = False
                txtPropPlanSplayMaxVariationDelta.Enabled = False
            End If
            txtPropPlanSplayPlanDeltaZ.Value = Me.Item.SplayBorderProjectionDeltaZ
            txtPropPlanSplayMaxVariationDelta.Value = Me.Item.SplayBorderMaxDeltaVariation
            txtPropPlanSplayInclinationRangeMin.Value = Me.Item.SplayBorderInclinationRange.Width
            txtPropPlanSplayInclinationRangeMax.Value = Me.Item.SplayBorderInclinationRange.Height
        Catch
        End Try
    End Sub

    Private Sub cboPropPlanSplayPlanProjectionType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropPlanSplayPlanProjectionType.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo40"), "SplayBorderProjectionType")
            Me.Item.SplayBorderProjectionType = cboPropPlanSplayPlanProjectionType.SelectedIndex
            Call MyBase.PropertyChanged("PlanSplayPlanProjectionType")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropPlanSplayPlanDeltaZ_ValueChanged(sender As Object, e As EventArgs) Handles txtPropPlanSplayPlanDeltaZ.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo40"), "SplayBorderProjectionDeltaZ")
            Me.Item.SplayBorderProjectionDeltaZ = txtPropPlanSplayPlanDeltaZ.Value
            Call MyBase.PropertyChanged("PlanSplayPlanDeltaZ")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropPlanSplayMaxVariationDelta_ValueChanged(sender As Object, e As EventArgs) Handles txtPropPlanSplayMaxVariationDelta.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo40"), "SplayBorderMaxDeltaVariation")
            Me.Item.SplayBorderMaxDeltaVariation = txtPropPlanSplayMaxVariationDelta.Value
            Call MyBase.PropertyChanged("PlanSplayMaxVariationDelta")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropPlanSplayInclinationRangeMin_ValueChanged(sender As Object, e As EventArgs) Handles txtPropPlanSplayInclinationRangeMin.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo40"), "SplayBorderInclinationRange")
            Me.Item.SplayBorderInclinationRange = New SizeF(txtPropPlanSplayInclinationRangeMin.Value, Me.Item.SplayBorderInclinationRange.Height)
            Call MyBase.PropertyChanged("PlanSplayInclinationRangeMin")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropPlanSplayInclinationRangeMax_ValueChanged(sender As Object, e As EventArgs) Handles txtPropPlanSplayInclinationRangeMax.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo40"), "SplayBorderInclinationRange")
            Me.Item.SplayBorderInclinationRange = New SizeF(Me.Item.SplayBorderInclinationRange.Width, txtPropPlanSplayInclinationRangeMax.Value)
            Call MyBase.PropertyChanged("PlanSplayInclinationRangeMax")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cmdPropPlanSplay_Click(sender As Object, e As EventArgs) Handles cmdPropPlanSplay.Click
        Call MyBase.DoCommand("splayreplicatedata", Item)
    End Sub

End Class
