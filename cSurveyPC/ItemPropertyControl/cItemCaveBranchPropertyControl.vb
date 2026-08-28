Imports System.ComponentModel
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraGrid.Views.Base
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
        Call MyBase.RebindBegin()

        MyBase.Rebind(Item)

        If Item.Survey IsNot oSurvey Then
            oSurvey = Item.Survey
            Call cboPropCaveList.Rebind(oSurvey, True)
        End If

        If Item.CaveValue Is Nothing OrElse Item.BranchValue Is Nothing Then
            Call pnlPropCaveBranchesColor.ResetBackColor()

            cboPropCaveList.Visible = False
            cboPropCaveBranchList.Visible = False

            cmdPropSetCaveBranch.Visible = False
            cmdPropSetCurrentCaveBranch.Visible = False

            chkCaveBranchNothing.Visible = True
            chkCaveBranchNothing.Checked = True
        Else
            chkCaveBranchNothing.Visible = False
            chkCaveBranchNothing.Checked = False

            cmdPropSetCaveBranch.Visible = True
            cmdPropSetCurrentCaveBranch.Visible = True

            cboPropCaveList.Visible = True
            cboPropCaveBranchList.Visible = True
            cboPropCaveList.EditValue = oSurvey.Properties.CaveInfos(Item.Cave)
            cboPropCaveBranchList.EditValue = If(cboPropCaveList.EditValue Is Nothing, Nothing, DirectCast(cboPropCaveList.EditValue, cCaveInfo).Branches(Item.Branch))
        End If

        If Item.BindDesignTypeValue.HasValue Then
            If Item.CanBeBinded And Item.Design.Type <= cIDesign.cDesignTypeEnum.Profile Then
                Call pRebindCrossSections()
            Else
                lblPropBindDesignType.Enabled = False
                cboPropBindDesignType.Enabled = False
                lblPropBindCrossSections.Enabled = False
                cboPropBindCrossSections.Enabled = False

                chkCaveBranchNothing.Visible = False
                chkCrossSectionsNothing.Visible = False
                chkLinkToNothing.Visible = False
            End If
        Else
            chkLinkToNothing.Visible = True
            chkLinkToNothing.Checked = True

            cboPropBindDesignType.Visible = False

            chkCrossSectionsNothing.Visible = True
            chkCrossSectionsNothing.Checked = True

            chkCrossSectionsNothing.Enabled = False
            cboPropBindCrossSections.Visible = False

        End If

        MyBase.Enabled = Point Is Nothing

        Call MyBase.RebindEnd()
    End Sub

    Private Sub pRebindCrossSections()
        cboPropBindCrossSections.Rebind(oSurvey, Item.Design, cCaveInfo.EditToString(cboPropCaveList.EditValue), cCaveInfoBranch.EditToString(cboPropCaveBranchList.EditValue), False, True)

        cboPropBindDesignType.SelectedIndex = Item.BindDesignType
        lblPropBindDesignType.Enabled = True
        cboPropBindDesignType.Enabled = True
        Dim bCrossSectionEnabled As Boolean = Item.BindDesignType = cItem.BindDesignTypeEnum.CrossSections
        lblPropBindCrossSections.Enabled = bCrossSectionEnabled
        cboPropBindCrossSections.Enabled = bCrossSectionEnabled
        If Item.CrossSectionValue Is Nothing Then
            chkCrossSectionsNothing.Visible = True
            chkCrossSectionsNothing.Checked = True

            cboPropBindCrossSections.Visible = False
        Else
            chkCrossSectionsNothing.Visible = False
            chkCrossSectionsNothing.Checked = False
            cboPropBindCrossSections.EditValue = oSurvey.CrossSections.GetBindItem(Item.CrossSection)

            cboPropBindCrossSections.Visible = True
        End If

        chkLinkToNothing.Visible = False
        chkLinkToNothing.Checked = False

        cboPropBindDesignType.Visible = True
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

    Private Sub cboPropCaveList_CustomRowFilter(sender As Object, e As RowFilterEventArgs) Handles cboPropCaveList.CustomRowFilter
        If cboPropCaveList.cboCaveListView.DataSource IsNot Nothing Then
            e.Visible = Not DirectCast(cboPropCaveList.cboCaveListView.DataSource(e.ListSourceRow), cCaveInfo).GetLocked()
            e.Handled = True
        End If
    End Sub

    Private Sub cboPropCaveList_EnabledChanged(sender As Object, e As EventArgs) Handles cboPropCaveList.EnabledChanged
        cboPropCaveList.cboCaveListView.RefreshData()
    End Sub

    Private Sub chkCaveBranchNothing_CheckedChanged(sender As Object, e As EventArgs) Handles chkCaveBranchNothing.CheckedChanged
        If Not MyBase.IsInRebind Then
            chkCaveBranchNothing.Visible = False
            chkCaveBranchNothing.Checked = False

            cboPropCaveList.Visible = True
            cboPropCaveBranchList.Visible = True

            cmdPropSetCaveBranch.Visible = True
            cmdPropSetCurrentCaveBranch.Visible = True
        End If
    End Sub

    Private Sub chkLinkToNothing_CheckedChanged(sender As Object, e As EventArgs) Handles chkLinkToNothing.CheckedChanged
        If Not MyBase.IsInRebind Then
            chkLinkToNothing.Visible = False
            chkLinkToNothing.Checked = False

            cboPropBindDesignType.Visible = True
            chkCrossSectionsNothing.Enabled = True

            Call pRebindCrossSections()

            If TypeOf Item Is cItemItems Then
                Dim oItems As cItemItems = Item
                cboPropBindDesignType.SelectedIndex = oItems.First.BindDesignType
            End If
        End If
    End Sub

    Private Sub chkCrossSectionsNothing_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrossSectionsNothing.CheckedChanged
        If Not MyBase.IsInRebind Then
            chkCrossSectionsNothing.Visible = False
            chkCrossSectionsNothing.Checked = False

            cboPropBindCrossSections.Visible = True
        End If
    End Sub
End Class
