Imports System.ComponentModel
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraTreeList

Friend Class cItemCategoryAndPropertiesControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() 
        Call cboPropCategories.Properties.Items.Clear()
        For Each iCategory As cIItem.cItemCategoryEnum In [Enum].GetValues(GetType(cIItem.cItemCategoryEnum))
            Call cboPropCategories.Properties.Items.Add(iCategory.ToString)
        Next
        cboPropCategories.Enabled = False
    End Sub

    Public Shadows Sub Rebind(Item As cItem)
        MyBase.Rebind(Item)

        cboPropCategories.SelectedIndex = Array.IndexOf([Enum].GetValues(GetType(cIItem.cItemCategoryEnum)), Item.Category)
    End Sub

    Private Sub prpPropDesignDataProperties_MouseUp(sender As Object, e As MouseEventArgs) Handles prpPropDesignDataProperties.MouseUp
        If (e.Button And MouseButtons.Right) = MouseButtons.Right Then
            MyBase.DoCommand("popupdatapropertiesmenu", prpPropDesignDataProperties.PointToScreen(e.Location), prpPropDesignDataProperties)
        End If
    End Sub

    Private Sub chkPropShowDataProperties_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropShowDataProperties.CheckedChanged
        Dim bChecked As Boolean = chkPropShowDataProperties.Checked
        If bChecked Then
            Height = 283 * Me.CurrentAutoScaleDimensions.Height / 96.0F
            prpPropDesignDataProperties.SelectedObject = MyBase.Item.DataProperties.GetClass
        Else
            Height = 32 * Me.CurrentAutoScaleDimensions.Height / 96.0F
        End If
        lblPropDesignDataProperties.Visible = bChecked
        prpPropDesignDataProperties.Visible = bChecked
    End Sub

    'Private Sub cmdPropSetCurrentCaveBranch_Click(sender As Object, e As EventArgs)
    '    Call MyBase.DoCommand("currentcaveandbranchsettocurrent")
    'End Sub

    'Private Sub pPropSetCaveBranchesColor()
    '    Dim sCave As String = cCaveInfo.EditToString(cboPropCaveList.EditValue)
    '    Dim sBranch As String = cCaveInfoBranch.EditToString(cboPropCaveBranchList.EditValue)
    '    Dim oColor As Color = oSurvey.Properties.CaveInfos.GetColor(sCave, sBranch, Color.LightGray)
    '    pnlPropCaveBranchesColor.BackColor = oColor
    'End Sub

    'Private Sub cmdPropSetCaveBranch_Click(sender As Object, e As EventArgs)
    '    If Not DisabledObjectProperty() Then
    '        Dim sCurrentCave As String = cCaveInfo.EditToString(cboPropCaveList.EditValue)
    '        Dim sCurrentBranch As String = cCaveInfoBranch.EditToString(cboPropCaveBranchList.EditValue)
    '        Call Item.SetCave(sCurrentCave, sCurrentBranch, True)
    '        Call Item.SetBindDesignType(cboPropBindDesignType.EditValue, Item.Survey.CrossSections.GetBindItem(cboPropBindCrossSections.EditValue), True)
    '        Call MyBase.TakeUndoSnapshot()
    '        Call MyBase.PropertyChanged("CaveBranch")
    '        Call MyBase.MapInvalidate()
    '    End If
    'End Sub

    'Private Sub cboPropCaveList_EditValueChanged(sender As Object, e As EventArgs)
    '    Call cboPropCaveBranchList.Rebind(oSurvey, cboPropCaveList, True)
    '    Call pPropSetCaveBranchesColor()
    '    If Not DisabledObjectProperty() Then
    '        Call Item.SetCave(cCaveInfo.EditToString(cboPropCaveList.EditValue), cCaveInfoBranch.EditToString(cboPropCaveBranchList.EditValue), True)
    '        Call MyBase.TakeUndoSnapshot()
    '        Call MyBase.PropertyChanged("CaveBranch")
    '        Call MyBase.MapInvalidate()
    '    End If
    'End Sub

    'Private Sub cboPropCaveBranchList_EditValueChanged(sender As Object, e As EventArgs)
    '    Call pPropSetCaveBranchesColor()
    '    If Not DisabledObjectProperty() Then
    '        Call Item.SetCave(cCaveInfo.EditToString(cboPropCaveList.EditValue), cCaveInfoBranch.EditToString(cboPropCaveBranchList.EditValue), True)
    '        Call MyBase.TakeUndoSnapshot()
    '        Call MyBase.PropertyChanged("CaveBranch")
    '        Call MyBase.MapInvalidate()
    '    End If
    'End Sub

    'Private Sub cboPropBindDesignType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Not DisabledObjectProperty() Then
    '        Call Item.SetBindDesignType(cboPropBindDesignType.SelectedIndex, oSurvey.CrossSections.GetBindItem(cboPropBindCrossSections.EditValue))
    '        cboPropBindCrossSections.Enabled = cboPropBindDesignType.SelectedIndex > 0
    '        Call MyBase.TakeUndoSnapshot()
    '        Call MyBase.PropertyChanged("BindDesignType")
    '        Call MyBase.MapInvalidate()
    '    End If
    'End Sub

    'Private Sub cboPropBindCrossSections_EditValueChanged(sender As Object, e As EventArgs)
    '    If Not DisabledObjectProperty() Then
    '        Call Item.SetBindDesignType(cboPropBindDesignType.SelectedIndex, oSurvey.CrossSections.GetBindItem(cboPropBindCrossSections.EditValue))
    '        Call MyBase.TakeUndoSnapshot()
    '        Call MyBase.PropertyChanged("BindCrossSections")
    '        Call MyBase.MapInvalidate()
    '    End If
    'End Sub
End Class
