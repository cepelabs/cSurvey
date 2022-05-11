Public Class cDockContent
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    Private sPersistString As String

    Public Sub New(PersistString As String)
        sPersistString = PersistString
        If modControls.SystemDPIRatio = 0 Then
            Using oGr As Graphics = Graphics.FromHwnd(Handle)
                modControls.SystemDPIRatio = oGr.DpiX / 96.0F
            End Using
        End If
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        Call MyBase.OnLoad(e)
        Call AdjustThroughtDPI(modControls.SystemDPIRatio)
    End Sub

    Protected Overrides Sub SetBoundsCore(x As Integer, y As Integer, width As Integer, height As Integer, specified As BoundsSpecified)
        If sPersistString <> "" Then
            If IsFloat Then
                Debug.Print(FloatPane.FloatWindow.DesktopBounds.ToString)
                Dim oScreen As Screen = Screen.FromRectangle(FloatPane.FloatWindow.DesktopBounds)
                Dim oIntersectRect As Rectangle = Rectangle.Intersect(oScreen.Bounds, FloatPane.FloatWindow.DesktopBounds)
                If oIntersectRect.IsEmpty OrElse oIntersectRect.Width < 12 OrElse oIntersectRect.Height < 12 Then
                    FloatPane.FloatWindow.Location = New Point(Screen.PrimaryScreen.Bounds.Location)
                End If
            End If
        End If
        MyBase.SetBoundsCore(x, y, width, height, specified)
    End Sub

    Protected Overrides Function GetPersistString() As String
        Return sPersistString
    End Function
End Class

Public Class cDockContentWindow
    Inherits cDockContent

    Public Sub New()
        MyBase.New("")
    End Sub

End Class

