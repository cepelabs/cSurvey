Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Drawings

Friend Class cItemCrossSectionPropertyControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Shadows ReadOnly Property Item As cItemCrossSection
        Get
            Return MyBase.Item
        End Get
    End Property

    Public Shadows Sub Rebind(Item As cItemCrossSection)
        Call MyBase.Rebind(Item)

        cboPropCrossSectionRefStation.SelectedIndex = Me.Item.RefStation
        txtPropCrossSectionWidth.Value = Me.Item.CrossWidth
        txtPropCrossSectionHeight.Value = Me.Item.CrossHeight
        cboPropProfileTextPosition.SelectedIndex = Me.Item.TextPosition
        txtPropProfileTextDistance.Value = Me.Item.TextDistance
        cboPropProfileDirection.SelectedIndex = Me.Item.Direction
        If Me.Item.Segment Is Nothing Then
            txtPropCrossSectionSegment.Text = ""
        Else
            txtPropCrossSectionSegment.Text = Me.Item.Segment.ToString
        End If

        Dim oCrossSection As cDesignCrossSection = Me.Item.DesignCrossSection
        If oCrossSection Is Nothing Then
            chkPropCrossSectionPlanMarker.Enabled = False
            chkPropCrossSectionProfileMarker.Enabled = False
            cmdPropCrossSectionPlanMarker.Enabled = False
            cmdPropCrossSectionProfileMarker.Enabled = False
        Else
            chkPropCrossSectionPlanMarker.Enabled = True
            chkPropCrossSectionPlanMarker.Checked = oCrossSection.HavePlanMarker
            cmdPropCrossSectionPlanMarker.Enabled = chkPropCrossSectionPlanMarker.Checked
            chkPropCrossSectionProfileMarker.Enabled = True
            chkPropCrossSectionProfileMarker.Checked = oCrossSection.HaveProfileMarker
            cmdPropCrossSectionProfileMarker.Enabled = chkPropCrossSectionProfileMarker.Checked
        End If
    End Sub

    Private Sub cboPropProfileTextPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropProfileTextPosition.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Me.Item.TextPosition = cboPropProfileTextPosition.SelectedIndex
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("ProfileTextPosition")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropProfileTextDistance_ValueChanged(sender As Object, e As EventArgs) Handles txtPropProfileTextDistance.ValueChanged
        If Not DisabledObjectProperty() Then
            Me.Item.TextDistance = txtPropProfileTextDistance.Value
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("ProfileTextDistance")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropCrossSectionWidth_ValueChanged(sender As Object, e As EventArgs) Handles txtPropCrossSectionWidth.ValueChanged
        If Not DisabledObjectProperty() Then
            Me.Item.CrossWidth = txtPropCrossSectionWidth.Value
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("CrossSectionWidth")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropCrossSectionHeight_ValueChanged(sender As Object, e As EventArgs) Handles txtPropCrossSectionHeight.ValueChanged
        If Not DisabledObjectProperty() Then
            Me.Item.CrossHeight = txtPropCrossSectionHeight.Value
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("CrossSectionHeight")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropProfileDirection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropProfileDirection.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Me.Item.Direction = cboPropProfileDirection.SelectedIndex
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("ProfileDirection")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropCrossSectionRefStation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropCrossSectionRefStation.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Me.Item.RefStation = cboPropCrossSectionRefStation.SelectedIndex
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("CrossSectionRefStation")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropCrossSectionSegment_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtPropCrossSectionSegment.ButtonClick
        If Not DisabledObjectProperty() Then
            Using frmSB As frmSegmentBrowser = New frmSegmentBrowser(Me.Item.Survey, Me.Item.Segment)
                If frmSB.ShowDialog(Me) = vbOK Then
                    Dim bOk As Boolean
                    If IsNothing(frmSB.SelectedItem) AndAlso Me.Item.DesignCrossSection.HaveMarkers Then
                        bOk = MsgBox(modMain.GetLocalizedString("main.warning29"), MsgBoxStyle.YesNo Or MsgBoxStyle.Critical Or MsgBoxStyle.DefaultButton2, GetLocalizedString("main.warningtitle")) = MsgBoxResult.Yes
                    Else
                        bOk = True
                    End If
                    If bOk Then
                        Me.Item.Segment = frmSB.SelectedItem
                        Call MyBase.TakeUndoSnapshot()
                        Call MyBase.PropertyChanged("CrossSectionSegment")
                        Call MyBase.MapInvalidate()
                    End If
                End If
            End Using
        End If
    End Sub

    Private Sub chkPropCrossSectionPlanMarker_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropCrossSectionPlanMarker.CheckedChanged
        If Not DisabledObjectProperty() Then
            Dim oCrossSection As cDesignCrossSection = Me.Item.DesignCrossSection
            If Not oCrossSection Is Nothing Then
                If oCrossSection.HavePlanMarker Then
                    Call oCrossSection.DeletePlanMarker()
                    chkPropCrossSectionPlanMarker.Checked = False
                Else
                    Call oCrossSection.CreatePlanMarker()
                    chkPropCrossSectionPlanMarker.Checked = True
                End If
                cmdPropCrossSectionPlanMarker.Enabled = chkPropCrossSectionPlanMarker.Checked
            End If
            'todo: undo
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("CrossSectionPlanMarker")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkPropCrossSectionProfileMarker_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropCrossSectionProfileMarker.CheckedChanged
        If Not DisabledObjectProperty() Then
            Dim oCrossSection As cDesignCrossSection = Me.Item.DesignCrossSection 'oSurvey.CrossSections.Find(oItem)
            If Not oCrossSection Is Nothing Then
                If oCrossSection.HaveProfileMarker Then
                    Call oCrossSection.DeleteProfileMarker()
                    chkPropCrossSectionProfileMarker.Checked = False
                Else
                    Call oCrossSection.CreateProfileMarker()
                    chkPropCrossSectionProfileMarker.Checked = True
                End If
                cmdPropCrossSectionProfileMarker.Enabled = chkPropCrossSectionProfileMarker.Checked
            End If
            'todo: undo
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("CrossSectionProfileMarker")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cmdPropCrossSectionPlanMarker_Click(sender As Object, e As EventArgs) Handles cmdPropCrossSectionPlanMarker.Click
        If Not DisabledObjectProperty() Then
            Call MyBase.DoCommand("selectitem", Me.Item.DesignCrossSection.PlanMarker, True)
        End If
    End Sub

    Private Sub cmdPropCrossSectionProfileMarker_Click(sender As Object, e As EventArgs) Handles cmdPropCrossSectionProfileMarker.Click
        If Not DisabledObjectProperty() Then
            Call MyBase.DoCommand("selectitem", Me.Item.DesignCrossSection.ProfileMarker, True)
        End If
    End Sub

    'Private Sub cboPropQuotaType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropQuotaType.SelectedIndexChanged
    '    If Not DisabledObjectProperty() Then
    '        Me.Item.QuotaType = cboPropQuotaType.SelectedIndex
    '        Call MyBase.TakeUndoSnapshot()
    '        Call MyBase.PropertyChanged("QuotaType")
    '        Call MyBase.MapInvalidate()
    '    End If
    'End Sub

    'Private Sub cboPropQuotaAlign_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropQuotaAlign.SelectedIndexChanged
    '    If Not DisabledObjectProperty() Then
    '        Me.Item.QuotaAlign = cboPropQuotaAlign.SelectedIndex
    '        Call MyBase.TakeUndoSnapshot()
    '        Call MyBase.PropertyChanged("QuotaAlign")
    '        Call MyBase.MapInvalidate()
    '    End If
    'End Sub

    'Private Sub cboPropQuotaTextPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropQuotaTextPosition.SelectedIndexChanged
    '    If Not DisabledObjectProperty() Then
    '        Me.Item.QuotaTextPosition = cboPropQuotaTextPosition.SelectedIndex
    '        Call MyBase.TakeUndoSnapshot()
    '        Call MyBase.PropertyChanged("QuotaTextPosition")
    '        Call MyBase.MapInvalidate()
    '    End If
    'End Sub

    'Private Sub cboPropQuotaValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropQuotaValue.SelectedIndexChanged
    '    If Not DisabledObjectProperty() Then
    '        Me.Item.QuotaValue = cboPropQuotaValue.SelectedIndex
    '        Call MyBase.TakeUndoSnapshot()
    '        Call MyBase.PropertyChanged("QuotaValue")
    '        Call MyBase.MapInvalidate()
    '    End If
    'End Sub

    'Private Sub cboPropQuotaFormat_TextChanged(sender As Object, e As EventArgs) Handles cboPropQuotaFormat.TextChanged
    '    If Not DisabledObjectProperty() Then
    '        Me.Item.QuotaFormat = cboPropQuotaFormat.Text
    '        Call MyBase.TakeUndoSnapshot()
    '        Call MyBase.PropertyChanged("QuotaFormat")
    '        Call MyBase.MapInvalidate()
    '    End If
    'End Sub

    'Private Sub cboPropQuotaValueType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropQuotaValueType.SelectedIndexChanged
    '    If Not DisabledObjectProperty() Then
    '        Me.Item.QuotaValueType = cboPropQuotaValueType.SelectedIndex
    '        Call MyBase.TakeUndoSnapshot()
    '        Call MyBase.PropertyChanged("QuotaValueType")
    '        Call MyBase.MapInvalidate()
    '    End If
    'End Sub

    'Private Sub txtPropQuotaRelativeTrigpoint_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtPropQuotaRelativeTrigpoint.ButtonClick
    '    If Not DisabledObjectProperty() Then
    '        Using frmTB As frmTrigpointBrowser = New frmTrigpointBrowser(Me.Item.Survey, txtPropQuotaRelativeTrigpoint.Text, True)
    '            If frmTB.ShowDialog(Me) = vbOK Then
    '                Me.Item.QuotaRelativeTrigpoint = frmTB.SelectedItem
    '                Call MyBase.TakeUndoSnapshot()
    '                Call MyBase.PropertyChanged("QuotaTrigpoint")
    '                Call MyBase.MapInvalidate()
    '            End If
    '        End Using
    '    End If
    'End Sub

    'Private Sub cmdPropQuotaOtherOptions_Click(sender As Object, e As EventArgs) Handles cmdPropQuotaOtherOptions.Click
    '    If Not DisabledObjectProperty() Then
    '        Using frmQP As frmQuotaProperties = New frmQuotaProperties(Me.Item)
    '            If frmQP.ShowDialog(Me) = vbOK Then
    '                Call MyBase.TakeUndoSnapshot()
    '                Call MyBase.PropertyChanged("QuotaOtherOptions")
    '                Call MyBase.MapInvalidate()
    '            End If
    '        End Using
    '    End If
    'End Sub
End Class
