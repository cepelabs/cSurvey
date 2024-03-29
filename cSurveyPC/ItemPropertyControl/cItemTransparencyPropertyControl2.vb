﻿Imports cSurveyPC.cSurvey.Design

Friend Class cItemTransparencyPropertyControl2
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Shadows Sub Rebind(Item As cItem)
        MyBase.Rebind(Item)
        trkTransparency.EditValue = Item.Transparency * 255.0F
    End Sub

    Private Sub trkTransparency_EditValueChanged(sender As Object, e As EventArgs) Handles trkTransparency.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo38"), "Transparency")
            Item.Transparency = trkTransparency.EditValue / 255.0F
            Call MyBase.PropertyChanged("Transparency")
            Call MyBase.MapInvalidate()
        End If
    End Sub

End Class
