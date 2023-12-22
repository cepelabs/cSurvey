Imports System.ComponentModel
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraTreeList

Friend Class cItemCaveBranchPropertyControl
    Private oSurvey As cSurvey.cSurvey

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() 

    End Sub

    Public Sub RefreshCavesAndBranches()
        If oSurvey IsNot Nothing Then
            Call cboPropCaveList.Rebind(oSurvey, False)
            Call cboPropCaveBranchList.Rebind(oSurvey, cboPropCaveList, True)
        End If
    End Sub

    Public Shadows Sub Rebind(Item As cItem, Point As cPoint)
        MyBase.Rebind(Item)

        If Item.Survey IsNot oSurvey Then
            oSurvey = Item.Survey
            Call cboPropCaveList.Rebind(oSurvey, True)
        End If

        cboPropCaveList.EditValue = oSurvey.Properties.CaveInfos(Item.Cave)
        cboPropCaveBranchList.EditValue = If(cboPropCaveList.EditValue Is Nothing, Nothing, DirectCast(cboPropCaveList.EditValue, cCaveInfo).Branches(Item.Branch))

        If Item.CanBeBinded And Item.Design.Type <= cIDesign.cDesignTypeEnum.Profile Then
            cboPropBindCrossSections.Rebind(oSurvey, Item.Design, cCaveInfo.EditToString(cboPropCaveList.EditValue), cCaveInfoBranch.EditToString(cboPropCaveBranchList.EditValue), False, True)

            cboPropBindDesignType.SelectedIndex = Item.BindDesignType
            lblPropBindDesignType.Enabled = True
            cboPropBindDesignType.Enabled = True
            Dim bCrossSectionEnabled As Boolean = Item.BindDesignType = cItem.BindDesignTypeEnum.CrossSections
            lblPropBindCrossSections.Enabled = bCrossSectionEnabled
            cboPropBindCrossSections.Enabled = bCrossSectionEnabled
            cboPropBindCrossSections.EditValue = oSurvey.CrossSections.GetBindItem(Item.CrossSection)
        Else
            lblPropBindDesignType.Enabled = False
            cboPropBindDesignType.Enabled = False
            lblPropBindCrossSections.Enabled = False
            cboPropBindCrossSections.Enabled = False
        End If

        MyBase.Enabled = Point Is Nothing
    End Sub

    Private Sub cmdPropSetCurrentCaveBranch_Click(sender As Object, e As EventArgs) Handles cmdPropSetCurrentCaveBranch.Click
        Call MyBase.DoCommand("currentcaveandbranchsettocurrent")
    End Sub

    Private Sub pPropSetCaveBranchesColor()
        Dim sCave As String = cCaveInfo.EditToString(cboPropCaveList.EditValue)
        Dim sBranch As String = cCaveInfoBranch.EditToString(cboPropCaveBranchList.EditValue)
        Dim oColor As Color = oSurvey.Properties.CaveInfos.GetColor(sCave, sBranch, Color.LightGray)
        pnlPropCaveBranchesColor.BackColor = oColor
    End Sub

    Private Sub cmdPropSetCaveBranch_Click(sender As Object, e As EventArgs) Handles cmdPropSetCaveBranch.Click
        Call MyBase.DoCommand("currentcaveandbranchgettocurrent")
    End Sub

    Private Sub cboPropCaveList_EditValueChanged(sender As Object, e As EventArgs) Handles cboPropCaveList.EditValueChanged
        Call cboPropCaveBranchList.Rebind(oSurvey, cboPropCaveList, True)
        Call pPropSetCaveBranchesColor()
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo29"))
            Call Item.SetCave(cCaveInfo.EditToString(cboPropCaveList.EditValue), cCaveInfoBranch.EditToString(cboPropCaveBranchList.EditValue), True)
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("CaveBranch")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropCaveBranchList_EditValueChanged(sender As Object, e As EventArgs) Handles cboPropCaveBranchList.EditValueChanged
        Call pPropSetCaveBranchesColor()
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo29"))
            Call Item.SetCave(cCaveInfo.EditToString(cboPropCaveList.EditValue), cCaveInfoBranch.EditToString(cboPropCaveBranchList.EditValue), True)
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("CaveBranch")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropBindDesignType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPropBindDesignType.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo30"))
            Call Item.SetBindDesignType(cboPropBindDesignType.SelectedIndex, oSurvey.CrossSections.GetBindItem(cboPropBindCrossSections.EditValue))
            cboPropBindCrossSections.Enabled = cboPropBindDesignType.SelectedIndex > 0
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("BindDesignType")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropBindCrossSections_EditValueChanged(sender As Object, e As EventArgs) Handles cboPropBindCrossSections.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo31"))
            Call Item.SetBindDesignType(cboPropBindDesignType.SelectedIndex, oSurvey.CrossSections.GetBindItem(cboPropBindCrossSections.EditValue))
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("BindCrossSections")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropCaveList_EditRequest(sender As Object, e As EventArgs) Handles cboPropCaveList.EditRequest, cboPropCaveBranchList.EditRequest
        MyBase.DoCommand("editproperties", {7, sender.editvalue})
    End Sub
End Class
