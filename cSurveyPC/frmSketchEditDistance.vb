friend Class frmSketchEditDistance
    Public Sub New(PlanOrProfile As Boolean, Optional Value As Single = 0.1)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtDistance.Value = Value
    End Sub

    Public Function GetDistance() As Single
        Return txtDistance.Value
    End Function

End Class