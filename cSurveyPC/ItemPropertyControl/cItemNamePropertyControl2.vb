Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Friend Class cItemNamePropertyControl2

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Shadows Sub Rebind(Item As cItem)
        MyBase.Rebind(Item)

        If TypeOf Item Is cItemItems Then
            txtPropName.Enabled = False
            txtPropName.Text = ""
        Else
            txtPropName.Enabled = True
            txtPropName.Text = Item.Name
        End If
        cmdItemNameRegen.Visible = Item.Survey.Properties.DesignProperties.GetValue("DesignItemNamePattern", "") <> ""
    End Sub

    Private Sub txtPropName_Validated(sender As Object, e As EventArgs) Handles txtPropName.Validated
        Try
            If Not DisabledObjectProperty() Then
                Item.Name = txtPropName.Text
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("Name")
            End If
        Catch
        End Try
    End Sub

    Private Sub cmdItemNameRegen_Click(sender As Object, e As EventArgs) Handles cmdItemNameRegen.Click
        If Not IsNothing(Item) Then
            Dim sPattern As String = Item.Survey.Properties.DesignProperties.GetValue("DesignItemNamePattern", "")
            If TypeOf Item Is cItemItems Then
                For Each oSubItem As cItem In DirectCast(Item, cItemItems)
                    oSubItem.Name = modPaint.ReplaceItemTags(Item.Survey, oSubItem, sPattern)
                Next
            Else
                Call txtPropName.Focus()
                txtPropName.Text = modPaint.ReplaceItemTags(Item.Survey, Item, sPattern)
            End If
        End If
    End Sub
End Class
