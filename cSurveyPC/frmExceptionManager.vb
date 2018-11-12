Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Net

Public Class frmExceptionManager

    Private oSurvey As cSurvey.cSurvey
    Private sFilename As String

    Private sExceptionFilename As String

    Private Function pSaveAs() As Boolean
        Dim osfd As SaveFileDialog = New SaveFileDialog
        With osfd
            .FileName = sFilename
            .Filter = GetLocalizedString("settings.filetypeCSZ") & " (*.CSZ)|*.CSZ|" & GetLocalizedString("settings.filetypeCSX") & " (*.CSX)|*.CSX"
            .FilterIndex = 1
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                sFilename = .FileName
                Call oSurvey.SaveTo(sFilename, cSurvey.cSurvey.SaveOptionsEnum.Silent)
                Return True
            Else
                Return False
            End If
        End With
    End Function

    Private Sub cmdSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveAs.Click
        Call pSaveAs()
    End Sub

    Private sPackageVersion As String
    Private sReleaseVersion As String
    Private sReleaseDate As String
    Private sReleaseCPU As String
    Private sMessage As String
    Private sSource As String
    Private sStackTrace As String

    Private bSendException As Boolean

    Public Sub New(ByVal Survey As cSurvey.cSurvey, ByVal Filename As String, ByVal Exception As Exception)
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey
        sFilename = Filename

        Dim oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
        bSendException = oReg.GetValue("debug.sendexception", 0)

        sPackageVersion = modMain.GetPackageVersion()

        sReleaseVersion = modMain.GetreleaseVersion
        sReleaseDate = modMain.GetReleaseDate.ToString("d")
        sReleaseCPU = IIf(Environment.Is64BitProcess, "64bit", "32bit")
        sMessage = "" & Exception.Message
        sSource = "" & Exception.Source
        sStackTrace = "" & Exception.StackTrace

        Dim sText As String = "{\rtf1\ansi\ansicpg1252\deff0\deflang1040{\fonttbl{\f0\fswiss\fprq2\fcharset0 Tahoma;}}"
        sText = sText & "\viewkind4\uc1\pard\fi-1420\li1420\tx1420\f0\fs20"
        sText = sText & "\b " & GetLocalizedString("exceptionmanager.details.textpart1") & ":\b0\tab " & sPackageVersion & "\par"
        sText = sText & "\b " & GetLocalizedString("exceptionmanager.details.textpart2") & ":\b0\tab " & sReleaseVersion & " " & sReleaseDate & " (" & sReleaseCPU & ")" & "\par"
        sText = sText & "\b " & GetLocalizedString("exceptionmanager.details.textpart3") & ":\b0\tab " & modMain.sMachineID & "\par"
        sText = sText & "\b " & GetLocalizedString("exceptionmanager.details.textpart4") & ":\b0\tab " & sMessage.Replace(vbCrLf, "\line ") & "\par"
        sText = sText & "\b " & GetLocalizedString("exceptionmanager.details.textpart5") & ":\b0\tab " & sSource.Replace(vbCrLf, "\line ") & "\par"
        sText = sText & "\b " & GetLocalizedString("exceptionmanager.details.textpart6") & ":\b0\tab " & IIf(modMain.bIsInDebug, GetLocalizedString("exceptionmanager.details.textpart6a"), GetLocalizedString("exceptionmanager.details.textpart6b")) & "\par"
        sText = sText & "\b " & GetLocalizedString("exceptionmanager.details.textpart7") & ":\b0\tab " & sStackTrace.Replace(vbCrLf, "\line ") & "\par"
        sText = sText & "}"
        rtfException.Rtf = sText

        lblException.Text = sMessage

        sExceptionFilename = ""

        If bSendException Then
            Call tmrAskToSendException.Stop()
            Call pSendException()
        Else
            Call tmrAskToSendException.Start()
        End If
    End Sub

    Public Sub pSendException()
        If bSendException Then
            Dim sLastError As String = ""
            Dim bSendResult As Boolean = pExceptionSend(sLastError)
            If Not bSendResult Then
                'qua dovrei gestire l'eventuale errore di invio ma per ora glisso...
            End If
        End If
        cmdSendException.Enabled = True
    End Sub

    Private Sub cmdSaveAsAndExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveAsAndExit.Click
        If pSaveAs() Then
            Call pExit()
        End If
    End Sub

    Private Sub pExit()
        DialogResult = Windows.Forms.DialogResult.OK
        Call Close()
    End Sub

    Private Sub pClose()
        DialogResult = Windows.Forms.DialogResult.Cancel
        Call Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Call pExit()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Call pClose()
    End Sub

    Private Sub cmdSaveException_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveException.Click
        Dim sExceptionFilename As String = ""
        Dim osfd As SaveFileDialog = New SaveFileDialog
        With osfd
            .FileName = sExceptionFilename
            .Filter = GetLocalizedString("exceptionmanager.filetypeBUGX") & " (*.BUGX)|*.BUGX|" & GetLocalizedString("exceptionmanager.filetypeRTF") & " (*.RTF)|*.RTF|" & GetLocalizedString("exceptionmanager.filetypeTXT") & " (*.TXT)|*.TXT"
            .FilterIndex = 1
            .CheckFileExists = False
            .CheckPathExists = True
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                sExceptionFilename = .FileName
                Select Case .FilterIndex
                    Case 1
                        Call pExceptionSave(ExceptionFileFormatEnum.XML, sExceptionFilename)
                    Case 2
                        Call pExceptionSave(ExceptionFileFormatEnum.RTF, sExceptionFilename)
                    Case 3
                        Call pExceptionSave(ExceptionFileFormatEnum.Text, sExceptionFilename)
                End Select
            End If
        End With
    End Sub

    Private Function pGetExceptionXML() As XmlDocument
        Dim oXML As Xml.XmlDocument = New Xml.XmlDocument
        Dim oXmlRoot As Xml.XmlElement = oXML.CreateElement("bugreport")
        Call oXmlRoot.SetAttribute("machineid", modMain.sMachineID)
        Call oXmlRoot.SetAttribute("packageversion", sPackageVersion)
        Call oXmlRoot.SetAttribute("releaseversion", sReleaseVersion)
        Call oXmlRoot.SetAttribute("releasedate", sReleaseDate)
        Call oXmlRoot.SetAttribute("releasecpu", sReleaseCPU)
        Call oXmlRoot.SetAttribute("indebug", IIf(modMain.bIsInDebug, "1", "0"))
        Call oXmlRoot.SetAttribute("date", Strings.Format(Date.Now, "yyyyMMddHHmmss"))
        Call oXmlRoot.SetAttribute("lang", My.Application.CurrentLanguage)
        Call oXmlRoot.SetAttribute("message", sMessage)
        Call oXmlRoot.SetAttribute("source", sSource)
        oXmlRoot.InnerText = sStackTrace
        Call oXML.AppendChild(oXmlRoot)
        Return oXML
    End Function

    Private Sub cmdSendException_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendException.Click
        Call pExceptionSend()
    End Sub

    Public Enum ExceptionFileFormatEnum
        Text = 0
        RTF = 1
        XML = 2
    End Enum

    Private Sub pExceptionSave(Format As ExceptionFileFormatEnum, Filename As String)
        Cursor = Cursors.WaitCursor
        Select Case Format
            Case ExceptionFileFormatEnum.Text
                Dim oFi As FileInfo = New FileInfo(Filename)
                Dim oExStream As StreamWriter = oFi.CreateText()
                Call oExStream.WriteLine(rtfException.Text)
                Call oExStream.Close()
                Call oExStream.Dispose()
            Case ExceptionFileFormatEnum.RTF
                Dim oFi As FileInfo = New FileInfo(Filename)
                Dim oExStream As StreamWriter = oFi.CreateText()
                Call oExStream.WriteLine(rtfException.Rtf)
                Call oExStream.Close()
                Call oExStream.Dispose()
            Case ExceptionFileFormatEnum.XML
                Dim oXML As XmlDocument = pGetExceptionXML()
                Call XMLAddDeclaration(oXML)
                Call oXML.Save(Filename)
        End Select
        Cursor = Cursors.Default
    End Sub

    Private Function pExceptionSend(Optional ByRef LastError As String = "") As Boolean
        Dim bResult As Boolean
        Cursor = Cursors.WaitCursor
        Try
            'Dim oWebClient As Net.WebClient = New Net.WebClient
            Dim sTempFilename As String = IO.Path.Combine(IO.Path.GetTempPath, Guid.NewGuid.ToString & ".xml")
            Dim oXML As Xml.XmlDocument = pGetExceptionXML()
            Call XMLAddDeclaration(oXML)
            Call oXML.Save(sTempFilename)
            'call pUploadFile("file", sTempFilename, "http://cepestorage/csurvey/bugreport/post.php")
            Call pUploadFile("file", sTempFilename, "http://www.csurvey.it/bugreport/post.php")
            'Call pUploadFile("file", sTempFilename, "http://cepelabs.homeip.net/csurvey/bugreport/post.php")
            Call My.Computer.FileSystem.DeleteFile(sTempFilename)
            LastError = ""
            bResult = True
        Catch ex As Exception
            LastError = ex.Message
            bResult = False
        End Try
        Cursor = Cursors.Default
        Return bResult
    End Function

    Private Sub cmdShowDetails_Click(sender As System.Object, e As System.EventArgs) Handles cmdShowDetails.Click
        rtfException.Visible = True
        lblException.Visible = False
        cmdShowDetails.Visible = False
    End Sub

    Private Function pUploadFile(Name As String, File As String, URL As String) As String
        Dim sContentType As String = "text/xml"
        Dim sBoundary As String = "---------------------------" + DateTime.Now.Ticks.ToString("x")
        Dim oWR As HttpWebRequest = DirectCast(WebRequest.Create(URL), HttpWebRequest)
        oWR.ContentType = "multipart/form-data; boundary=" + sBoundary
        oWR.Method = "POST"

        Dim oSB As StringBuilder = New StringBuilder
        Call oSB.Append("--" & sBoundary & vbCrLf)
        Call oSB.Append("Content-Disposition: form-data; name=" & Chr(34) & Name & Chr(34) & "; " & "filename=" & Chr(34) & Path.GetFileName(File) & Chr(34) & vbCrLf)
        Call oSB.Append("Content-Type: " & sContentType & vbCrLf & vbCrLf)

        Dim sPostHeader As String = oSB.ToString()
        Dim bPostHeaderBytes As Byte() = Encoding.UTF8.GetBytes(sPostHeader)
        Dim bBoundaryBytes As Byte() = Encoding.ASCII.GetBytes(vbCrLf & "--" + sBoundary & vbCrLf)

        Dim oFS As FileStream = New FileStream(File, FileMode.Open, FileAccess.Read)
        Dim ilength As Integer = bPostHeaderBytes.Length + oFS.Length + bBoundaryBytes.Length
        oWR.ContentLength = ilength

        Dim oRequestStream As Stream = oWR.GetRequestStream()
        Call oRequestStream.Write(bPostHeaderBytes, 0, bPostHeaderBytes.Length)

        Dim bBuffer(Math.Min(4096, oFS.Length - 1)) As Byte
        Dim iBytesRead As Integer = 0
        Do
            iBytesRead = oFS.Read(bBuffer, 0, bBuffer.Length)
            If iBytesRead = 0 Then
                Exit Do
            Else
                Call oRequestStream.Write(bBuffer, 0, iBytesRead)
            End If
        Loop
        Call oFS.Close()
        Call oFS.Dispose()

        Call oRequestStream.Write(bBoundaryBytes, 0, bBoundaryBytes.Length)
        Dim oSR As StreamReader = New StreamReader(oWR.GetResponse.GetResponseStream())
        Return oSR.ReadToEnd
    End Function

    Private Sub frmExceptionManager_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub tmrAskToSendException_Tick(sender As Object, e As System.EventArgs) Handles tmrAskToSendException.Tick
        Call tmrAskToSendException.Stop()

        Dim iAskToSendException As Integer
        'se arrivo qui l'invio delle segnalazioni è spento...
        Dim oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
        iAskToSendException = oReg.GetValue("debug.asktosendexception", 0)
        iAskToSendException += 1
        Call oReg.SetValue("debug.asktosendexception", iAskToSendException)
        Call oReg.Close()

        If iAskToSendException < 4 Then
            If MsgBox(GetLocalizedString("exceptionmanager.dialog"), MsgBoxStyle.Question Or vbYesNo Or vbDefaultButton1, GetLocalizedString("exceptionmanager.warningtitle")) = MsgBoxResult.Yes Then
                bSendException = True
                Try
                    oReg = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
                    Call oReg.SetValue("debug.sendexception", 1)
                    Call oReg.Close()
                Catch
                End Try
            End If
            Call pSendException()
        End If
    End Sub
End Class