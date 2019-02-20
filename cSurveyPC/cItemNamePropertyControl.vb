Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Friend Class cItemNamePropertyControl
    Private oItem As cItem

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Overrides Sub Rebind(Item As cItem)
        oItem = Item

        If TypeOf Item Is cItemItems Then
            txtPropName.Enabled = False
            txtPropName.Text = ""
        Else
            txtPropName.Enabled = True
            txtPropName.Text = oItem.Name
        End If
        cmdItemNameRegen.Visible = Item.Survey.Properties.DesignProperties.GetValue("DesignItemNamePattern", "") <> ""
    End Sub

    Private Sub txtPropName_Validated(sender As Object, e As EventArgs) Handles txtPropName.Validated
        Try
            If Not DisabledObjectProperty() Then
                oItem.Name = txtPropName.Text
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("Name")
            End If
        Catch
        End Try
    End Sub

    Private Sub cmdItemNameRegen_Click(sender As Object, e As EventArgs) Handles cmdItemNameRegen.Click
        If Not IsNothing(oItem) Then
            Dim sPattern As String = oItem.Survey.Properties.DesignProperties.GetValue("DesignItemNamePattern", "")
            If TypeOf oItem Is cItemItems Then
                For Each oSubItem As cItem In DirectCast(oItem, cItemItems)
                    oSubItem.Name = modPaint.ReplaceItemTags(oItem.Survey, oSubItem, sPattern)
                Next
            Else
                Call txtPropName.Focus()
                txtPropName.Text = modPaint.ReplaceItemTags(oItem.Survey, oItem, sPattern)
            End If
        End If
    End Sub
End Class
