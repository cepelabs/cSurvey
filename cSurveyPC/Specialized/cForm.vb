Imports cSurveyPC.cSurvey.Helper.Editor

Friend Class cForm
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
        Private oSettings As cEnvironmentSettingsFolder

        Public Function GetSetting(Key As String, Optional DefaultValue As Object = Nothing) As Object
            Return oSettings.GetSetting("dialog." & sFormName & "." & Key, DefaultValue)
        End Function

        Public Sub SetSetting(Key As String, Value As Object)
            Call oSettings.SetSetting("dialog." & sFormName & "." & Key, Value)
        End Sub

        Friend Sub New(FormName As String, Settings As cEnvironmentSettingsFolder)
            sFormName = FormName
            oSettings = Settings
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
        RaiseEvent FormSettingsLoad(Me, New FormSettingsEventArgs(Name, My.Application.Settings))
    End Sub

    Private Sub pFormSettingsSave()
        RaiseEvent FormSettingsSave(Me, New FormSettingsEventArgs(Name, My.Application.Settings))
    End Sub

    Private Sub pSettingsLoad()
        Size = modWindow.GetSizeFromSettings(My.Application.Settings, "dialog." & Name & ".size", Size)
    End Sub

    Private Sub pSettingsSave()
        Call modWindow.SetSizeToSettings(My.Application.Settings, "dialog." & Name & ".size", Size)
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
