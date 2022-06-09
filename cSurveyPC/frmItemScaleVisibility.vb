Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Scale
Imports DevExpress.XtraEditors.Controls

Friend Class frmItemScaleVisibility
    Private oItem As cItem

    Public Sub New(Item As cItem)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oItem = Item

        cboVisibilityIcon.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(0, 0))

        For Each iValue As cVisibilityItems.VisibilityEnum In [Enum].GetValues(GetType(cVisibilityItems.VisibilityEnum))
            cboVisibiltyVisibility.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(modMain.GetLocalizedString("visibilityitems.visibility" & iValue), iValue, iValue))
        Next

        grdVisibility.DataSource = New UIHelpers.cScaleVisibilityEditBindingList(oItem)
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        DirectCast(grdVisibility.DataSource, UIHelpers.cScaleVisibilityEditBindingList).Save()
    End Sub

    Private Sub grdVisibilityView_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles grdVisibilityView.ValidatingEditor
        Dim oColumn As DevExpress.XtraGrid.Columns.GridColumn = If(TryCast(e, DevExpress.XtraGrid.Views.Grid.EditFormValidateEditorEventArgs)?.Column, grdVisibilityView.FocusedColumn)
        If oColumn Is colVisibiltyVisibility Then
            If e.Value = cVisibilityItems.VisibilityEnum.Multiple Then
                e.Valid = False
                e.ErrorText = modMain.GetLocalizedString("visibilityitems.textpart1")
            End If
        End If
    End Sub
End Class