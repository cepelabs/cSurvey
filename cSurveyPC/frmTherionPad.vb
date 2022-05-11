Imports cSurveyPC.cSurvey

friend Class frmTherionPad
    'Private oSurvey As cSurvey.cSurvey

    Friend Class cOnTherionPadEventArgs
        Private bError As Boolean
        Private bCancel As Boolean
        Private sFilename As String
        Private sOutput As String

        Public Property Output As String
            Get
                Return sOutput
            End Get
            Set(ByVal value As String)
                sOutput = value
            End Set
        End Property

        Public Property Cancel As Boolean
            Get
                Return bCancel
            End Get
            Set(ByVal value As Boolean)
                bCancel = value
            End Set
        End Property

        Public Property [Error] As Boolean
            Get
                Return bError
            End Get
            Set(ByVal value As Boolean)
                bError = value
            End Set
        End Property

        Public Property Filename As String
            Get
                Return sfilename
            End Get
            Set(ByVal value As String)
                sfilename = value
            End Set
        End Property
    End Class

    Friend Event OnExportPlan(ByVal Sender As frmTherionPad, ByVal Args As cOnTherionPadEventArgs)
    Friend Event OnExportProfile(ByVal Sender As frmTherionPad, ByVal Args As cOnTherionPadEventArgs)
    Friend Event OnExport3D(ByVal Sender As frmTherionPad, ByVal Args As cOnTherionPadEventArgs)

    Private Sub pAfterCommand(ByVal Args As cOnTherionPadEventArgs)
        'Call rtfConsole.AppendText(Args.Output)
        'Call rtfConsole.Select(rtfConsole.TextLength - 1, 0)
        If Args.Error Then
            'qua dovrei indicare il possibile messaggio di errore...
        Else
            If chkCloseAfterAction.Checked And Not Args.Cancel Then Close()
        End If
    End Sub

    Private Sub cmdExportPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportPlan.Click
        Dim oArgs As cOnTherionPadEventArgs = New cOnTherionPadEventArgs
        RaiseEvent OnExportPlan(Me, oArgs)
        Call pAfterCommand(oArgs)
    End Sub

    Private Sub cdmExport3D_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdmExport3D.Click
        Dim oArgs As cOnTherionPadEventArgs = New cOnTherionPadEventArgs
        RaiseEvent OnExport3D(Me, oArgs)
        Call pAfterCommand(oArgs)
    End Sub

    Private Sub cmdExportProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportProfile.Click
        Dim oArgs As cOnTherionPadEventArgs = New cOnTherionPadEventArgs
        RaiseEvent OnExportProfile(Me, oArgs)
        Call pAfterCommand(oArgs)
    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
            chkCloseAfterAction.Checked = oReg.GetValue("therion.closepadafteraction", 1)
            Call oReg.Close()
        End Using
        'btnConsole.Checked = oReg.GetValue("therion.showconsoleonpad", 0)
    End Sub

    Private Sub frmTherionPad_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
            Call oReg.SetValue("therion.closepadafteraction", IIf(chkCloseAfterAction.Checked, "1", "0"))
            'Call oReg.SetValue("therion.showconsoleonpad", IIf(btnConsole.Checked, "1", "0"))
            Call oReg.Close()
        End Using
    End Sub
End Class