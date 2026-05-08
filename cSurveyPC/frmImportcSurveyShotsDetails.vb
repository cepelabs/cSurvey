Imports System.ComponentModel
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Properties
Imports DevExpress.XtraGrid.Views.Base

Friend Class frmImportcSurveyShotsDetails

    Private oValues As Dictionary(Of String, Object)
    Private oPropertiesBag As BindingList(Of UIHelpers.Reflection.cObjectPropertyBag)
    Private bSuspendEvent As Boolean

    Public Sub New(Values As Dictionary(Of String, Object))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        bSuspendEvent = True

        oValues = Values
        If oValues Is Nothing Then
            oValues = New Dictionary(Of String, Object)
        End If

        chkSession.Checked = oValues.ContainsKey("Session") AndAlso CBool(oValues("Session"))
        chkCaveBranch.Checked = oValues.ContainsKey("CaveBranch") AndAlso CBool(oValues("CaveBranch"))

        chkDistance.Checked = oValues.ContainsKey("Distance") AndAlso CBool(oValues("Distance"))
        chkBearing.Checked = oValues.ContainsKey("Bearing") AndAlso CBool(oValues("Bearing"))
        chkInclination.Checked = oValues.ContainsKey("Inclination") AndAlso CBool(oValues("Inclination"))

        chkLRUD.Checked = oValues.ContainsKey("LRUD") AndAlso CBool(oValues("LRUD"))
        chkDirection.Checked = oValues.ContainsKey("Direction") AndAlso CBool(oValues("Direction"))
        chkNotes.Checked = oValues.ContainsKey("Notes") AndAlso CBool(oValues("Notes"))
        chkColor.Checked = oValues.ContainsKey("Color") AndAlso CBool(oValues("Color"))

        chkDataProperties.Checked = oValues.ContainsKey("DataProperties") AndAlso CBool(oValues("DataProperties"))

        oPropertiesBag = frmSegmentsReplicateDataFieldEditor.GetItems(1, Values)
        bSuspendEvent = False
    End Sub

    Private Sub cmdEditOtherProperties_Click(sender As Object, e As EventArgs) Handles cmdEditOtherProperties.Click
        Using frmR As frmSegmentsReplicateDataFieldEditor = New frmSegmentsReplicateDataFieldEditor(1, oPropertiesBag)
            If frmR.ShowDialog(Me) = DialogResult.OK Then
                oPropertiesBag = frmR.Items

                For Each oItem As UIHelpers.Reflection.cObjectPropertyBag In oPropertiesBag
                    If oValues.ContainsKey(oItem.Name) Then
                        oValues(oItem.Name) = oItem.Set
                    Else
                        oValues.Add(oItem.Name, oItem.Set)
                    End If
                Next
            End If
        End Using
    End Sub

    Private Sub chkDistance_CheckedChanged(sender As Object, e As EventArgs) Handles chkDistance.CheckedChanged
        If Not bSuspendEvent Then
            oValues.Remove("Distance")
            oValues.Add("Distance", chkDistance.Checked)
        End If
    End Sub

    Private Sub chkBearing_CheckedChanged(sender As Object, e As EventArgs) Handles chkBearing.CheckedChanged
        If Not bSuspendEvent Then
            oValues.Remove("Bearing")
            oValues.Add("Bearing", chkBearing.Checked)
        End If
    End Sub

    Private Sub chkInclination_CheckedChanged(sender As Object, e As EventArgs) Handles chkInclination.CheckedChanged
        If Not bSuspendEvent Then
            oValues.Remove("Inclination")
            oValues.Add("Inclination", chkInclination.Checked)
        End If
    End Sub

    Private Sub chkNotes_CheckedChanged(sender As Object, e As EventArgs) Handles chkNotes.CheckedChanged
        If Not bSuspendEvent Then
            oValues.Remove("Notes")
            oValues.Add("Notes", chkNotes.Checked)
        End If
    End Sub

    Private Sub chkDirection_CheckedChanged(sender As Object, e As EventArgs) Handles chkDirection.CheckedChanged
        If Not bSuspendEvent Then
            oValues.Remove("Direction")
            oValues.Add("Direction", chkDirection.Checked)
        End If
    End Sub

    Private Sub chkLRUD_CheckedChanged(sender As Object, e As EventArgs) Handles chkLRUD.CheckedChanged
        If Not bSuspendEvent Then
            oValues.Remove("LRUD")
            oValues.Add("LRUD", chkLRUD.Checked)
        End If
    End Sub

    Private Sub chkSession_CheckedChanged(sender As Object, e As EventArgs) Handles chkSession.CheckedChanged
        If Not bSuspendEvent Then
            oValues.Remove("Session")
            oValues.Add("Session", chkSession.Checked)
        End If
    End Sub

    Private Sub chkCaveBranch_CheckedChanged(sender As Object, e As EventArgs) Handles chkCaveBranch.CheckedChanged
        If Not bSuspendEvent Then
            oValues.Remove("CaveBranch")
            oValues.Add("CaveBranch", chkCaveBranch.Checked)
        End If
    End Sub

    Private Sub chkDataProperties_CheckedChanged(sender As Object, e As EventArgs) Handles chkDataProperties.CheckedChanged
        If Not bSuspendEvent Then
            oValues.Remove("DataProperties")
            oValues.Add("DataProperties ", chkDataProperties.Checked)
        End If
    End Sub

    Private Sub chkColor_CheckedChanged(sender As Object, e As EventArgs) Handles chkColor.CheckedChanged
        If Not bSuspendEvent Then
            oValues.Remove("Color")
            oValues.Add("Color", chkColor.Checked)
        End If
    End Sub
End Class