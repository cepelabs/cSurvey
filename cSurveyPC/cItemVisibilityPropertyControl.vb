Imports cSurveyPC.cSurvey.Design

Public Class cItemVisibilityPropertyControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Overloads Sub Rebind(Item As cItem)
        MyBase.Rebind(Item)

        chkPropVisibleInDesign.Checked = Not Item.HiddenInDesign
        chkPropVisibleInPreview.Checked = Not Item.HiddenInPreview
        chkPropVisibleInDesign.Enabled = Item.CanBeHiddenInDesign
        chkPropVisibleInPreview.Enabled = Item.CanBeHiddenInPreview

        If TypeOf Item Is Items.cItemSegment Then
            cboPropAffinity.Enabled = False
            chkPropVisibleByProfile.Enabled = False
            chkPropVisibleByScale.Enabled = False
        Else
            cboPropAffinity.SelectedIndex = Item.DesignAffinity
            cboPropAffinity.Enabled = True
            chkPropVisibleByProfile.Enabled = True
            chkPropVisibleByScale.Enabled = True
        End If
    End Sub

    Private Sub chkVisibleInPreview_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropVisibleInPreview.CheckedChanged
        Try
            If Not DisabledObjectProperty() Then
                Item.HiddenInPreview = Not chkPropVisibleInPreview.Checked
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("HiddenInPreview")
                Call MyBase.MapInvalidate()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chkVisibleInDesign_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropVisibleInDesign.CheckedChanged
        Try
            If Not DisabledObjectProperty() Then
                Item.HiddenInDesign = Not chkPropVisibleInDesign.Checked
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("HiddenInDesign")
                Call MyBase.MapInvalidate()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cboPropAffinity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropAffinity.SelectedIndexChanged
        Try
            Item.DesignAffinity = cboPropAffinity.SelectedIndex
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("DesignAffinity")
            Call MyBase.MapInvalidate()
        Catch
        End Try
    End Sub

    Private Function pScaleRulestemScaleVisibilityEdit(Item As cItem) As Boolean
        Dim frmSR As frmItemScaleVisibility = New frmItemScaleVisibility(Item)
        If frmSR.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub chkPropVisibleByScale_Click(sender As Object, e As EventArgs) Handles chkPropVisibleByScale.Click
        Try
            If pScaleRulestemScaleVisibilityEdit(Item) Then
                Call MyBase.MapInvalidate()
            End If
        Catch
        End Try
    End Sub
End Class
