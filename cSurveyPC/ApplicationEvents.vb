Imports Microsoft.VisualBasic.ApplicationServices

Namespace My

    ' I seguenti eventi sono disponibili per MyApplication:
    ' 
    ' Startup: generato all'avvio dell'applicazione, prima della creazione del form di avvio.
    ' Shutdown: generato dopo la chiusura di tutti i form dell'applicazione. L'evento non è generato se l'applicazione termina in modo anormale.
    ' UnhandledException: generato se l'applicazione rileva un'eccezione non gestita.
    ' StartupNextInstance: generato quando si avvia un'applicazione istanza singola e l'applicazione è già attiva. 
    ' NetworkAvailabilityChanged: generato quando la connessione di rete è connessa o disconnessa.
    Partial Friend Class MyApplication
        Private oSurvey As cSurveyPC.cSurvey.cSurvey
        Private sFilename As String

        Private sCurrentLanguage As String
        'Private oRM As System.Resources.ResourceManager

        Public ReadOnly Property CurrentLanguage As String
            Get
                Return sCurrentLanguage
            End Get
        End Property

        Public Sub SetCurrent(ByVal Survey As cSurvey.cSurvey, ByVal Filename As String)
            oSurvey = Survey
            sFilename = Filename
        End Sub

        Public Function ManageUnhandledException(ByVal Exception As Exception) As Boolean
            Try
                Dim frmEM As frmExceptionManager = New frmExceptionManager(oSurvey, sFilename, Exception)
                Return frmEM.ShowDialog = DialogResult.OK
            Catch
                Return True
            End Try
        End Function

        Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Call pLanguageSet()
        End Sub

        Private Sub pLanguageSet()
            sCurrentLanguage = Threading.Thread.CurrentThread.CurrentCulture.Parent.Name
            Try
                Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
                    sCurrentLanguage = oReg.GetValue("language", sCurrentLanguage)
                End Using
            Catch
            End Try
            If sCurrentLanguage <> "" Then
                'If bIsInDebug Then
                ''in debug...force this process to run with the culture's settings of the selected language...
                Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(sCurrentLanguage)
                Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(sCurrentLanguage)
                'End If
            End If
            Call modMain.LoadLocalizedStrings(sCurrentLanguage)
        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            e.ExitApplication = ManageUnhandledException(e.Exception)
        End Sub
    End Class


End Namespace

