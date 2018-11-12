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

