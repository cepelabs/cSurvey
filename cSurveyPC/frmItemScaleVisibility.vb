Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Scale

Public Class frmItemScaleVisibility
    Private oItem As cItem

    Public Sub New(Item As cItem)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oItem = Item

        Try
            For Each iValue As Integer In [Enum].GetValues(GetType(cVisibilityItems.VisibilityEnum))
                Call colVisibility.Items.Add(modMain.GetLocalizedString("visibilityitems.visibility" & iValue))
            Next
        Catch ex As Exception
        End Try

        For Each oScaleRule As cScaleRule In oItem.Survey.ScaleRules
            Dim oData() As Object = {"1:" & oScaleRule.Scale.ToString, modMain.GetLocalizedString("visibilityitems.visibility" & oScaleRule.Items.GetVisibility(oItem).ToString("D"))}
            Dim oRow As DataGridViewRow = grdVisibility.Rows(grdVisibility.Rows.Add(oData))
            oRow.Tag = oScaleRule
        Next
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        For Each oRow As DataGridViewRow In grdVisibility.Rows
            Dim oScaleRule As cScaleRule = oRow.Tag
            Dim oComboCell As DataGridViewComboBoxCell = oRow.Cells(1)
            Call oScaleRule.Items.SetVisibility(oItem, oComboCell.Items.IndexOf(oComboCell.Value))
        Next
    End Sub

    Private Sub grdVisibility_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles grdVisibility.DataError
        e.ThrowException = False
    End Sub

    Private Sub grdVisibility_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles grdVisibility.CellValidating
        If e.ColumnIndex = 1 Then
            If e.FormattedValue = modMain.GetLocalizedString("visibilityitems.visibility" & cVisibilityItems.VisibilityEnum.Multiple.ToString("D")) Then
                e.Cancel = True
                grdVisibility.Rows(e.RowIndex).ErrorText = modMain.GetLocalizedString("visibilityitems.textpart1")
            Else
                grdVisibility.Rows(e.RowIndex).ErrorText = ""
            End If
        End If
    End Sub
End Class