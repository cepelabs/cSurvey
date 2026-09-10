Imports cSurveyPC.cSurvey.Design

Friend Class cItemVisibilityPropertyControl2
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        chkPropVisibleInDesignNothing.ToolTip = chkPropVisibleInDesign.ToolTip
        chkPropVisibleInPreviewNothing.ToolTip = chkPropVisibleInPreview.ToolTip

        chkPropVisibleInDesignNothing.Location = chkPropVisibleInDesign.Location
        chkPropVisibleInPreviewNothing.Location = chkPropVisibleInPreview.Location
    End Sub

    Public Shadows Sub Rebind(Item As cItem)
        MyBase.RebindBegin()

        MyBase.Rebind(Item)

        chkPropVisibleInDesign.Enabled = Item.CanBeHiddenInDesign
        If Item.CanBeHiddenInDesign Then
            If Item.HiddenInDesignValue.HasValue Then
                chkPropVisibleInDesignNothing.Visible = False
                chkPropVisibleInDesign.Checked = Not Item.HiddenInDesign
            Else
                chkPropVisibleInDesignNothing.Visible = True
                chkPropVisibleInDesignNothing.Checked = True
                chkPropVisibleInDesign.Checked = True
            End If
        Else
            chkPropVisibleInDesignNothing.Visible = False
        End If

        chkPropVisibleInPreview.Enabled = Item.CanBeHiddenInPreview
        If Item.CanBeHiddenInPreview Then
            If Item.HiddenInPreviewValue.HasValue Then
                chkPropVisibleInPreviewNothing.Visible = False
                chkPropVisibleInPreview.Checked = Not Item.HiddenInPreview
            Else
                chkPropVisibleInPreviewNothing.Visible = True
                chkPropVisibleInPreviewNothing.Checked = True
                chkPropVisibleInPreview.Checked = True
            End If
        Else
            chkPropVisibleInPreviewNothing.Visible = False
        End If

        If Item.HaveAffinity Then
            If Item.DesignAffinityValue.HasValue Then
                chkAffinityDesign.Checked = Item.DesignAffinity = cItem.DesignAffinityEnum.Design
                chkAffinityExtra.Checked = Item.DesignAffinity = cItem.DesignAffinityEnum.Extra
                chkAffinityDesign.Enabled = True
                chkAffinityExtra.Enabled = True
                chkAffinityNothing.Visible = False
            Else
                chkAffinityDesign.Checked = False
                chkAffinityExtra.Checked = False
                chkAffinityDesign.Enabled = True
                chkAffinityExtra.Enabled = True
                chkAffinityNothing.Visible = True
                chkAffinityNothing.Checked = True
            End If

            btnPropVisibleByProfile.Enabled = True
            btnPropVisibleByScale.Enabled = True
        Else
            chkAffinityDesign.Enabled = False
            chkAffinityExtra.Enabled = False
            btnPropVisibleByProfile.Enabled = False
            btnPropVisibleByScale.Enabled = False
        End If

        MyBase.RebindEnd()
    End Sub

    Private Sub chkVisibleInPreview_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropVisibleInPreview.CheckedChanged
        Try
            If Not MyBase.IsInRebind Then
                If Not DisabledObjectProperty() Then
                    Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo35"), "HiddenInPreview")
                    Item.HiddenInPreview = Not chkPropVisibleInPreview.Checked
                    Call MyBase.PropertyChanged("HiddenInPreview")
                    Call MyBase.MapInvalidate()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chkVisibleInDesign_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropVisibleInDesign.CheckedChanged
        Try
            If Not MyBase.IsInRebind Then
                If Not DisabledObjectProperty() Then
                    Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo36"), "HiddenInDesign")
                    Item.HiddenInDesign = Not chkPropVisibleInDesign.Checked
                    Call MyBase.PropertyChanged("HiddenInDesign")
                    Call MyBase.MapInvalidate()
                End If
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

    Private Sub chkPropVisibleByScale_Click(sender As Object, e As EventArgs) Handles btnPropVisibleByScale.Click
        Try
            If pScaleRulestemScaleVisibilityEdit(Item) Then
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub

    Private Sub chkAffinityDesign_CheckedChanged(sender As Object, e As EventArgs) Handles chkAffinityDesign.CheckedChanged
        Try
            If Not MyBase.IsInRebind Then
                If Not DisabledObjectProperty() Then
                    Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo37"), "DesignAffinity")
                    Item.DesignAffinity = If(chkAffinityDesign.Checked, cItem.DesignAffinityEnum.Design, cItem.DesignAffinityEnum.Extra)
                    Call MyBase.PropertyChanged("DesignAffinity")
                    Call MyBase.MapInvalidate()

                    chkAffinityNothing.Visible = False
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub chkAffinityExtra_CheckedChanged(sender As Object, e As EventArgs) Handles chkAffinityExtra.CheckedChanged
        Call chkAffinityDesign_CheckedChanged(sender, e)
    End Sub

    Private Sub chkPropVisibleByProfile_Click(sender As Object, e As EventArgs) Handles btnPropVisibleByProfile.Click
        If pProfileVisibilityEdit(Item) Then
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkPropVisibleInDesignNothing_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropVisibleInDesignNothing.CheckedChanged
        If Not MyBase.IsInRebind Then
            chkPropVisibleInDesignNothing.Visible = False
            Call chkVisibleInDesign_CheckedChanged(sender, e)
        End If
    End Sub

    Private Sub chkPropVisibleInPreviewNothing_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropVisibleInPreviewNothing.CheckedChanged
        If Not MyBase.IsInRebind Then
            chkPropVisibleInPreviewNothing.Visible = False
            Call chkVisibleInPreview_CheckedChanged(sender, e)
        End If
    End Sub
End Class
