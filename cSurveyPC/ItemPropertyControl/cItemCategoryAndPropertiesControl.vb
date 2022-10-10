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
End Class
