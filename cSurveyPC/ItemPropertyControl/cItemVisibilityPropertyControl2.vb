﻿Imports cSurveyPC.cSurvey.Design

Friend Class cItemVisibilityPropertyControl2
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Shadows Sub Rebind(Item As cItem)
        MyBase.Rebind(Item)

        chkPropVisibleInDesign.Checked = Not Item.HiddenInDesign
        chkPropVisibleInPreview.Checked = Not Item.HiddenInPreview
        chkPropVisibleInDesign.Enabled = Item.CanBeHiddenInDesign
        chkPropVisibleInPreview.Enabled = Item.CanBeHiddenInPreview

        If Item.haveAffinity Then
            chkAffinityDesign.Checked = Item.DesignAffinity = cItem.DesignAffinityEnum.Design
            chkAffinityExtra.Checked = Item.DesignAffinity = cItem.DesignAffinityEnum.Extra
            chkAffinityDesign.Enabled = True
            chkAffinityExtra.Enabled = True
            chkPropVisibleByProfile.Enabled = True
            chkPropVisibleByScale.Enabled = True
        Else
            chkAffinityDesign.Enabled = False
            chkAffinityExtra.Enabled = False
            chkPropVisibleByProfile.Enabled = False
            chkPropVisibleByScale.Enabled = False
        End If
    End Sub

    Private Sub chkVisibleInPreview_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropVisibleInPreview.CheckedChanged
        Try
            If Not DisabledObjectProperty() Then
                Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo35"), "HiddenInPreview")
                Item.HiddenInPreview = Not chkPropVisibleInPreview.Checked
                Call MyBase.PropertyChanged("HiddenInPreview")
                Call MyBase.MapInvalidate()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chkVisibleInDesign_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropVisibleInDesign.CheckedChanged
        Try
            If Not DisabledObjectProperty() Then
                Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo36"), "HiddenInDesign")
                Item.HiddenInDesign = Not chkPropVisibleInDesign.Checked
                Call MyBase.PropertyChanged("HiddenInDesign")
                Call MyBase.MapInvalidate()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function pScaleRulestemScaleVisibilityEdit(Item As cItem) As Boolean
        Using frmSR As frmItemScaleVisibility = New frmItemScaleVisibility(Item)
            If frmSR.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Call MyBase.MapInvalidate()
                Return True
            Else
                Return False
            End If
        End Using
    End Function

    Private Function pProfileVisibilityEdit(Item As cItem) As Boolean
        Using frmSR As frmItemProfileVisibility = New frmItemProfileVisibility(Item)
            If frmSR.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Call MyBase.MapInvalidate()
                Return True
            Else
                Return False
            End If
        End Using
    End Function

    Private Sub chkPropVisibleByScale_Click(sender As Object, e As EventArgs) Handles chkPropVisibleByScale.Click
        Try
            If pScaleRulestemScaleVisibilityEdit(Item) Then
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub chkAffinityDesign_CheckedChanged(sender As Object, e As EventArgs) Handles chkAffinityDesign.CheckedChanged
        Try
            If Not DisabledObjectProperty() Then
                Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo37"), "DesignAffinity")
                Item.DesignAffinity = If(chkAffinityDesign.Checked, cItem.DesignAffinityEnum.Design, cItem.DesignAffinityEnum.Extra)
                Call MyBase.PropertyChanged("DesignAffinity")
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub chkAffinityExtra_CheckedChanged(sender As Object, e As EventArgs) Handles chkAffinityExtra.CheckedChanged
        Call chkAffinityDesign_CheckedChanged(sender, e)
    End Sub

    Private Sub chkPropVisibleByProfile_Click(sender As Object, e As EventArgs) Handles chkPropVisibleByProfile.Click
        If pProfileVisibilityEdit(Item) Then
            Call MyBase.MapInvalidate()
        End If
    End Sub
End Class
