﻿Friend Class cForm
    Inherits DevExpress.XtraEditors.XtraForm

    Private bSaveAndRestoreSettings As Boolean

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If My.Application.CurrentLanguage = "it" Then
            If My.Application.ChangeDecimalKey AndAlso keyData = Keys.Decimal Then
                SendKeys.Send(",")
                Return True
            ElseIf My.Application.ChangePeriodKey AndAlso keyData = Keys.OemPeriod Then
                SendKeys.Send(",")
                Return True
            Else
                Return MyBase.ProcessCmdKey(msg, keyData)
            End If
        End If
    End Function

    Public Class FormSettingsEventArgs
        Inherits EventArgs

        Private sFormName As String
        Private oReg As Microsoft.Win32.RegistryKey

        Public Function GetValue(Key As String, Optional DefaultValue As Object = Nothing) As Object
            Return oReg.GetValue("dialog." & sFormName & "." & Key, DefaultValue)
        End Function

        Public Sub SetValue(Key As String, Value As Object)
            Call oReg.SetValue("dialog." & sFormName & "." & Key, Value)
        End Sub

        Public ReadOnly Property RegistryKey As Microsoft.Win32.RegistryKey
            Get
                Return oReg
            End Get
        End Property

        Friend Sub New(FormName As String, Reg As Microsoft.Win32.RegistryKey)
            sFormName = FormName
            oReg = Reg
        End Sub
    End Class

    Public Event FormSettingsSave(Sender As Object, e As FormSettingsEventArgs)
    Public Event FormSettingsLoad(Sender As Object, e As FormSettingsEventArgs)

    Public Property SaveAndRestoreSettings As Boolean
        Get
            Return bSaveAndRestoreSettings
        End Get
        Set(value As Boolean)
            bSaveAndRestoreSettings = value
        End Set
    End Property

    Private Sub pFormSettingsLoad()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
                RaiseEvent FormSettingsLoad(Me, New FormSettingsEventArgs(Name, oReg))
                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Private Sub pFormSettingsSave()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
                RaiseEvent FormSettingsSave(Me, New FormSettingsEventArgs(Name, oReg))
                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

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

    Public Sub cForm_Load() Handles MyBase.Load
        If bSaveAndRestoreSettings Then pSettingsLoad()
        Call pFormSettingsLoad()
    End Sub

    Private Sub cForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bSaveAndRestoreSettings Then Call pSettingsSave()
        Call pFormSettingsSave()
    End Sub
End Class
