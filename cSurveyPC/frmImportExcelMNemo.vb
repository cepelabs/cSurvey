Imports System.ComponentModel
Imports cSurveyPC.cSurvey.UIHelpers.Import
Imports DevExpress.XtraTreeList

Friend Class frmImportExcelMNemo

    Private Sub pSettingsLoad()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
                txtPrefix.Text = oReg.GetValue("data.import.xlsx.mnemo.prefix", "")
                txtCaveName.Text = oReg.GetValue("data.import.xlsx.mnemo.cavename", "")

                cboBearingPolicy.SelectedIndex = oReg.GetValue("data.import.xlsx.mnemo.bearingpolicy", 0)
                cboDepthPolicy.SelectedIndex = oReg.GetValue("data.import.xlsx.mnemo.depthpolicy", 0)

                Call oReg.Close()
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub pSettingsSave()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
                Call oReg.SetValue("data.import.xlsx.mnemo.prefix", txtPrefix.Text)
                Call oReg.SetValue("data.import.xlsx.mnemo.cavename", txtCaveName.Text)

                Call oReg.SetValue("data.import.xlsx.mnemo.bearingpolicy", cboBearingPolicy.SelectedIndex)
                Call oReg.SetValue("data.import.xlsx.mnemo.depthpolicy", cboDepthPolicy.SelectedIndex)

                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Private oSurvey As cSurvey.cSurvey

    Private WithEvents oSourceFields As cSourceFields

    Public Sub New(Survey As cSurvey.cSurvey)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey

        Call cboSession.Rebind(oSurvey, True, True, AddressOf pFilterSession)

        Call pSettingsLoad()
    End Sub

    Private Function pFilterSession(Session As cSurvey.cSession) As Boolean
        Return Session.DataFormat = cSurvey.cSegment.DataFormatEnum.Diving AndAlso Session.DepthType = cSurvey.cSegment.DepthTypeEnum.AbsoluteAtEnd AndAlso Session.InclinationDirection = cSurvey.cSegment.MeasureDirectionEnum.Inverted
    End Function

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        Call pSettingsSave()
    End Sub

End Class