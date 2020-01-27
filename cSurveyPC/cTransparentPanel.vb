Public Class cTransparentPanel
    Inherits Panel

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStyle(ControlStyles.Opaque, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H20
            Return cp
        End Get
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Using oBrush As SolidBrush = New SolidBrush(Me.BackColor)
            Call e.Graphics.FillRectangle(oBrush, Me.ClientRectangle)
        End Using
        MyBase.OnPaint(e)
    End Sub
End Class
