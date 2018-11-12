Module modOpacity
    Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" (ByVal hwnd As Integer, ByVal nIndex As Integer) As Integer
    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hwnd As Integer, ByVal nIndex As Integer, ByVal dwNewinteger As Integer) As Integer
    Private Declare Function SetLayeredWindowAttributes Lib "user32" (ByVal hwnd As Integer, ByVal crey As Byte, ByVal bAlpha As Byte, ByVal dwFlags As Integer) As Integer
    Private Const GWL_EXSTYLE = (-20)
    Private Const WS_EX_LAYERED = &H80000
    Private Const LWA_ALPHA = &H2&
    Private Declare Function SetParent Lib "user32" Alias "SetParent" (ByVal hWndChild As Integer, ByVal hWndNewParent As Integer) As Integer

    Public Sub SetParentWindow(hWndChild As Integer, hWndParent As Integer)
        Call SetParent(hWndChild, hWndParent)
    End Sub

    Public Sub SetOpacity(hWnd As Integer, Opacity As Byte)
        Call SetWindowLong(hWnd, GWL_EXSTYLE, GetWindowLong(hWnd, GWL_EXSTYLE) Or WS_EX_LAYERED)
        Call SetLayeredWindowAttributes(hWnd, 0, Opacity, LWA_ALPHA)
    End Sub

    Public Sub UnsetOpacity(hWnd As Integer)
        Call SetWindowLong(hWnd, GWL_EXSTYLE, GetWindowLong(hWnd, GWL_EXSTYLE) And (Not WS_EX_LAYERED))
    End Sub
End Module
