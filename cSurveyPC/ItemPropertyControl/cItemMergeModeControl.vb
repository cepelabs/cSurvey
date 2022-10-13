Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Friend Class cItemMergeModeControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Shadows ReadOnly Property Item As cIItemMergeableArea
        Get
            Return MyBase.Item
        End Get
    End Property

    Public Shadows Sub Rebind(Item As cIItemMergeableArea)
        MyBase.Rebind(Item)
        chkMergeMode0.Checked = Me.Item.MergeMode = cIItemMergeableArea.MergeModeEnum.Add
        chkMergeMode1.Checked = Me.Item.MergeMode = cIItemMergeableArea.MergeModeEnum.Subtract
    End Sub

    Private Sub chkMergeMode0_CheckedChanged(sender As Object, e As EventArgs) Handles chkMergeMode0.CheckedChanged
        Try
            If Not DisabledObjectProperty() Then
                Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo41"), "MergeMode")
                Item.MergeMode = cIItemMergeableArea.MergeModeEnum.Add
                Call MyBase.PropertyChanged("MergeMode")
                Call MyBase.MapInvalidate()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chkMergeMode1_CheckedChanged(sender As Object, e As EventArgs) Handles chkMergeMode1.CheckedChanged
        Try
            If Not DisabledObjectProperty() Then
                Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo41"), "MergeMode")
                Item.MergeMode = cIItemMergeableArea.MergeModeEnum.Subtract
                Call MyBase.PropertyChanged("MergeMode")
                Call MyBase.MapInvalidate()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
