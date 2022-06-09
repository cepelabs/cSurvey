Public Class cColorSelector
    Inherits DevExpress.XtraEditors.ColorPickEdit

    Private oDefaultColor As Color = Color.Transparent

    Protected Overrides Sub OnLoaded()
        MyBase.OnLoaded()
        MyBase.Properties.AutomaticColor = oDefaultColor
    End Sub

    Private Sub cColorSelector_CustomDisplayText(sender As Object, e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs) Handles Me.CustomDisplayText
        e.DisplayText = ""
    End Sub

    Public Property DefaultColor As Color
        Get
            Return oDefaultColor
        End Get
        Set(value As Color)
            If oDefaultColor <> value Then
                oDefaultColor = value
                MyBase.Properties.AutomaticColor = oDefaultColor
            End If
        End Set
    End Property
End Class
