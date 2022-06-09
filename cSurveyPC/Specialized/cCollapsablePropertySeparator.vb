Public Class cCollapsablePropertySeparator
    Inherits DevExpress.XtraEditors.LabelControl

    Public Sub New()
        MyBase.New

        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(Me, False)

        LineVisible = True
        LineLocation = DevExpress.XtraEditors.LineLocation.Center
        AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Height = 4
        Visible = False
    End Sub

    Public Sub UpdateVisibility()
        Dim bVisible As Boolean
        For Each oControl As cCollapsablePropertyControlContainer In oControls
            If oControl.Visible Then
                bVisible = True
                Exit For
            End If
        Next
        Me.Visible = bVisible
    End Sub

    Private oControls As HashSet(Of cCollapsablePropertyControlContainer) = New HashSet(Of cCollapsablePropertyControlContainer)

    Public Sub AppendControl(Control As cCollapsablePropertyControlContainer)
        Call oControls.Add(Control)
    End Sub
End Class
