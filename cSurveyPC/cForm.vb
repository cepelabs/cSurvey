Public Class cForm
    Inherits Windows.Forms.Form

    Private bSaveAndRestoreSettings As Boolean

    Public Property SaveAndRestoreSettings As Boolean
        Get
            Return bSaveAndRestoreSettings
        End Get
        Set(value As Boolean)
            bSaveAndRestoreSettings = value
        End Set
    End Property

    Private Sub pSettingsLoad()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
                Size = modWindow.GetSizeFromRegistry(oReg, "dialog." & Name & ".size", Size)
                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Private Sub pSettingsSave()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
                Call modWindow.SetSizeFromRegistry(oReg, "dialog." & Name & ".size", Size)
                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Public Sub New()
        Call MyBase.New
        If modControls.SystemDPIRatio = 0 Then
            Using oGr As Graphics = Graphics.FromHwnd(Handle)
                modControls.SystemDPIRatio = oGr.DpiX / 96.0F
            End Using
        End If
        Call AdjustThroughtDPI(modControls.SystemDPIRatio)
    End Sub

    Public ReadOnly Property DPIRatio As Single
        Get
            Return modControls.SystemDPIRatio
        End Get
    End Property

    Public Sub cForm_Load() Handles MyBase.Load
        'Call AdjustThroughtDPI(modControls.SystemDPIRatio)
        If bSaveAndRestoreSettings Then pSettingsLoad()
    End Sub

    Private Sub cForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bSaveAndRestoreSettings Then Call pSettingsSave()
    End Sub
End Class
