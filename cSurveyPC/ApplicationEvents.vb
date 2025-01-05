Imports System.Xml
Imports cSurveyPC.cSurvey.Helper.Editor
Imports DevExpress.LookAndFeel
Imports DevExpress.Office
Imports DevExpress.Utils.Svg
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
                Using frmEM As frmExceptionManager = New frmExceptionManager(oSurvey, sFilename, Exception)
                    Return frmEM.ShowDialog = DialogResult.OK
                End Using
            Catch
                Return True
            End Try
        End Function

        Public ReadOnly Property CurrentDPIRatio As Single
            Get
                Return sCurrentDPIRatio
            End Get
        End Property

        Private sCurrentDPIRatio As Single

        Public Sub ReloadSettings()
            oSettings = New cEnvironmentSettings("Software\Cepelabs\cSurvey")
            'oRuntimeSettings = New cEnvironmentSettings
            sCurrentLanguage = oSettings.GetSetting("language", sCurrentLanguage)
            bChangeDecimalKey = oSettings.GetSetting("keys.changedecimalkey", "1")
            bChangePeriodKey = oSettings.GetSetting("keys.changeperiodkey", "0")
        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Call DevExpress.XtraEditors.WindowsFormsSettings.LoadApplicationSettings()

            sCurrentLanguage = Threading.Thread.CurrentThread.CurrentCulture.Parent.Name
            Call ReloadSettings()
            oRuntimeSettings = New cEnvironmentSettings

            If sCurrentLanguage <> "" Then
                If bIsInDebug Then
                    ''in debug...force this process to run with the culture's settings of the selected language...
                    Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(sCurrentLanguage)
                End If
                Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(sCurrentLanguage)
            End If
            Call modMain.LoadLocalizedStrings(sCurrentLanguage)

            Using oGr As Graphics = Graphics.FromHwnd(IntPtr.Zero)
                sCurrentDPIRatio = oGr.DpiX / 96.0F
            End Using
        End Sub

        Public Sub CreateCustomSkinAndPalette()
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("The Bezier")
            Dim oCommonSkin = DevExpress.Skins.CommonSkins.GetSkin(UserLookAndFeel.Default)

            Dim oXML As XmlDocument = New XmlDocument
            oXML.LoadXml(My.Resources.custompalettes)
            For Each oXMLPalette As XmlElement In oXML.DocumentElement.ChildNodes
                Dim oSvgPalette As New DevExpress.Utils.Svg.SvgPalette()
                Dim sPaletteName As String = oXMLPalette.GetAttribute("Name")
                For Each oXMLColor As XmlElement In oXMLPalette.ChildNodes
                    Dim sName As String = oXMLColor.GetAttribute("Name")
                    Dim iValues As Integer() = oXMLColor.GetAttribute("Value").Split({","c}).Select(Function(sValue) Integer.Parse(sValue)).ToArray
                    Dim oColor As Color = Color.FromArgb(iValues(0), iValues(1), iValues(2))
                    oSvgPalette.Colors.Add(New DevExpress.Utils.Svg.SvgColor(sName, oColor))
                Next
                If oCommonSkin.CustomSvgPalettes.FindPalette(sPaletteName) Is Nothing Then
                    oCommonSkin.CustomSvgPalettes.Add(New SvgPaletteKey(oCommonSkin.CustomSvgPalettes.Count, sPaletteName), oSvgPalette)
                End If
            Next
            LookAndFeelHelper.ForceDefaultLookAndFeelChanged()
        End Sub

        Private bChangeDecimalKey As Boolean
        Private bChangePeriodKey As Boolean

        Public ReadOnly Property ChangePeriodKey As Boolean
            Get
                Return bChangePeriodKey
            End Get
        End Property

        Public ReadOnly Property ChangeDecimalKey As Boolean
            Get
                Return bChangeDecimalKey
            End Get
        End Property

        Private oRuntimeSettings As cEnvironmentSettings
        Private oSettings As cEnvironmentSettings

        Public ReadOnly Property RuntimeSettings As cEnvironmentSettings
            Get
                Return oRuntimeSettings
            End Get
        End Property

        Public ReadOnly Property Settings As cEnvironmentSettings
            Get
                Return oSettings
            End Get
        End Property

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            e.ExitApplication = ManageUnhandledException(e.Exception)
        End Sub

    End Class


End Namespace

