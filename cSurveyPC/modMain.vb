Imports System.Collections.Specialized
Imports System.IO
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports System.Web.Management
Imports System.Xml

Module modMain
    Public sMachineID As String
    Public bIsInDebug As Boolean
    Public bIsModernOS As Boolean

    Public sBaseVersion As String = "2"

    Public DefaultCoordinateFormat As String = "0.0000000"
    Public DefaultAltitudeFormat As String = "0.000"
    Public DefaultPointFormat As String = "0.00"
    Public DefaultDataFormat As String = "0.00"

    Public iMaxDrawItemCount As Integer

    Private sApplicationPath As String = ""
    Private sUserApplicationPath As String = ""

    Public Function IsPrintEnabled()
        Try
            Return Printing.PrinterSettings.InstalledPrinters.Count > 0
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetUserApplicationPath() As String
        If sUserApplicationPath = "" Then
            sUserApplicationPath = IO.Path.GetDirectoryName(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData)
        End If
        Return sUserApplicationPath
    End Function

    Public Function GetApplicationPath() As String
        If sApplicationPath = "" Then
            sApplicationPath = IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName)
        End If
        Return sApplicationPath
    End Function

    Public Function GetMaxDrawItemCount() As Integer
        Return iMaxDrawItemCount
    End Function

    Public Function Is32Bit() As Boolean
        Return Not Environment.Is64BitProcess
    End Function

    Public Function Is64Bit() As Boolean
        Return Environment.Is64BitProcess
    End Function

    Public Sub SetGridDefaultValueForColumnImage(Grid As DataGridView, Row As DataGridViewRow)
        For Each oColumn As DataGridViewColumn In Grid.Columns
            If TypeOf oColumn Is DataGridViewImageColumn Then
                Row.Cells(oColumn.Index).Value = Nothing
            End If
        Next
    End Sub

    Public Sub SetGridDefaultValueForColumnImage(Grid As DataGridView)
        For Each oColumn As DataGridViewColumn In Grid.Columns
            If TypeOf oColumn Is DataGridViewImageColumn Then
                DirectCast(oColumn, DataGridViewImageColumn).DefaultCellStyle.NullValue = Nothing
                DirectCast(oColumn, DataGridViewImageColumn).CellTemplate.Value = Nothing
            End If
        Next
    End Sub

    Function GetWindowsVersion() As Decimal
        Return Convert.ToDecimal(Environment.OSVersion.Version.Major) + Convert.ToDecimal(Environment.OSVersion.Version.Minor) / 10
    End Function

    'Public Function GetReleaseDate() As Date
    '    Dim oFi As FileInfo = New FileInfo(Application.ExecutablePath)
    '    Return oFi.LastWriteTime
    'End Function

    'Public Function GetReleaseVersion() As String
    '    Dim oFi As FileInfo = New FileInfo(Application.ExecutablePath)
    '    Dim dDate As Date = oFi.LastWriteTime
    '    Return sBaseVersion & "." & Strings.Format(dDate.Year - 2010, "0") & "." & Strings.Format(dDate.DayOfYear, "000") & Strings.Format((10 * (dDate.Hour * 60 + dDate.Minute) / 1440), "0")
    'End Function

    Public Function SplitVersion(Version As String) As Integer()
        Dim oVersionItems() As String = Version.Split(".")
        Return {Integer.Parse(oVersionItems(0)), Integer.Parse(oVersionItems(1)), Integer.Parse(oVersionItems(2))}
    End Function

    Public Function FilterRestoreLast(Filter As String, Value As Integer) As Integer
        Return My.Application.Settings.GetSetting(Filter, Value)
        'Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey\Filters", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
        '    Return oReg.GetValue(Filter, Value)
        'End Using
    End Function

    Public Sub FilterSaveLast(Filter As String, Value As Integer)
        Call My.Application.Settings.SetSetting(Filter, Value.ToString)
        'Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey\Filters", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
        '    Call oReg.SetValue(Filter, Value, Microsoft.Win32.RegistryValueKind.String)
        '    Call oReg.Flush()
        '    Call oReg.Close()
        'End Using
    End Sub

    Public Function GetPackageDate() As Date
        Dim oXML As XmlDocument = New XmlDocument
        oXML.Load(Path.Combine(modMain.GetApplicationPath, "version.xml"))
        Dim sDate As String = oXML.Item("csurvey").GetAttribute("date")
        If sDate = "" Then
            Return Date.Now
        Else
            Return New Date(sDate.Substring(0, 4), sDate.Substring(4, 2), sDate.Substring(6, 2), sDate.Substring(8, 2), sDate.Substring(10, 2), 0)
        End If
    End Function

    Public Function GetPackageVersion() As String
        Dim oXML As XmlDocument = New XmlDocument
        oXML.Load(Path.Combine(modMain.GetApplicationPath, "version.xml"))
        Return oXML.Item("csurvey").GetAttribute("version")
    End Function

    Public Function CompareVersion(Version1 As String, Version2 As String) As Boolean
        If Version1 = "" OrElse Version2 = "" Then
            Return False
        Else
            Dim oVersion1() As Integer = SplitVersion(Version1)
            Dim oVersion2() As Integer = SplitVersion(Version2)
            Dim dVersion1 As Decimal = oVersion1(2) + oVersion1(1) * 10000 + oVersion1(0) * 10000000
            Dim dVersion2 As Decimal = oVersion2(2) + oVersion2(1) * 10000 + oVersion2(0) * 10000000
            Return dVersion1 > dVersion2
        End If
    End Function

    Public Sub KillProcessTree(Root As Process)
        If Not Root Is Nothing Then
            Dim oProcesses As List(Of Process) = New List(Of Process)(Process.GetProcesses)
            Dim bKill As Boolean
            For Each oProcess In oProcesses
                If oProcess.Id <> Root.Id Then
                    Dim iParentProcessID As Integer = oProcess.Id
                    Do
                        iParentProcessID = GetParentProcessID(iParentProcessID)
                        If iParentProcessID = Root.Id Then
                            bKill = True
                            Exit Do
                        End If
                        If iParentProcessID = 0 Then
                            bKill = False
                            Exit Do
                        End If
                    Loop
                    If bKill Then
                        Dim oChildProcess As Process = Process.GetProcessById(oProcess.Id)
                        If Not oChildProcess.HasExited Then
                            Debug.Print("KILL CHILDID " & oProcess.Id)
                            Call oChildProcess.Kill()
                        End If
                    End If
                End If
            Next
            If Not Root.HasExited Then
                Debug.Print("KILL ID " & Root.Id)
                Call Root.Kill()
            End If
        End If
    End Sub

    Public Function GetParentProcessID(ProcessID As Integer) As Integer
        Try
            Dim oMO As ManagementObject = New ManagementObject("win32_process.handle='" & ProcessID & "'")
            Call oMO.Get()
            Return Convert.ToInt32(oMO("ParentProcessId"))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    'Public Class DataReceivedStringEventArgs
    '    Inherits EventArgs

    '    Private sData As String

    '    Public ReadOnly Property Data As String
    '        Get
    '            Return sData
    '        End Get
    '    End Property

    '    Public Sub New(Data As String)
    '        sData = Data
    '    End Sub
    'End Class

    'Public Delegate Sub DataReceivedStringEventHandler(sender As Object, e As DataReceivedStringEventArgs)

    'Public Function ExecuteProcess(ByVal Filename As String, ByVal Arguments As String, ByVal Background As Boolean, OutputHandler As DataReceivedStringEventHandler) As Integer
    '    Dim iTimeout As Integer = 120000
    '    Dim iWaitForExit As Integer = 500 '120000 ' Integer.MaxValue
    '    Using oProcess As Process = New Process
    '        With oProcess
    '            .StartInfo.WorkingDirectory = My.Computer.FileSystem.SpecialDirectories.Temp
    '            .StartInfo.FileName = Filename
    '            .StartInfo.Arguments = Arguments
    '            If Background Then
    '                'If Not OutputHandler Is Nothing Then AddHandler .OutputDataReceived, OutputHandler
    '                .StartInfo.CreateNoWindow = True
    '                .StartInfo.WindowStyle = ProcessWindowStyle.Hidden
    '                .StartInfo.RedirectStandardInput = True
    '                .StartInfo.RedirectStandardOutput = True
    '                .StartInfo.UseShellExecute = False
    '                'usefull to allow special settings for therion launced from csurvey
    '                Dim sCustomTherionIniPath As String = My.Application.Settings.GetSetting("therion.inipath", "")
    '                If sCustomTherionIniPath <> "" Then
    '                    .StartInfo.EnvironmentVariables.Add("THERION", sCustomTherionIniPath)
    '                Else
    '                    .StartInfo.EnvironmentVariables.Add("THERION", modMain.GetUserApplicationPath)
    '                End If
    '            End If
    '            Call .Start()
    '            If Background Then
    '                Call .StandardInput.WriteLine()
    '            End If
    '            Dim iWait As Integer = 0
    '            Do
    '                If Not OutputHandler Is Nothing Then
    '                    Try
    '                        Call OutputHandler(oProcess, New DataReceivedStringEventArgs(oProcess.StandardOutput.ReadToEnd))
    '                    Catch ex As Exception
    '                    End Try
    '                End If
    '                Call .WaitForExit(iWaitForExit)
    '                iWait += iWaitForExit
    '                If Not .HasExited AndAlso iWait >= iTimeout Then
    '                    If MsgBox(GetLocalizedString("process.warning1"), MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical, GetLocalizedString("process.warningtitle")) = MsgBoxResult.Cancel Then
    '                        Call KillProcessTree(oProcess)
    '                        Call Err.Raise(vbObjectError + 200, "process.aborted", GetLocalizedString("process.textpart1"), Nothing, Nothing)
    '                    End If
    '                End If
    '            Loop Until .HasExited
    '            Return .ExitCode
    '        End With
    '    End Using
    'End Function

    'Public Function ExecuteProcess(ByVal Filename As String, ByVal Arguments As String, ByVal Background As Boolean, OutputHandler As System.Diagnostics.DataReceivedEventHandler) As Integer
    '    Dim iTimeout As Integer = 120000
    '    'Dim iWaitForExit As Integer = 500 '120000 ' Integer.MaxValue
    '    Using oProcess As Process = New Process
    '        With oProcess
    '            .StartInfo.WorkingDirectory = My.Computer.FileSystem.SpecialDirectories.Temp
    '            .StartInfo.FileName = Filename
    '            .StartInfo.Arguments = Arguments
    '            If Background Then
    '                If Not OutputHandler Is Nothing Then AddHandler .OutputDataReceived, OutputHandler
    '                .StartInfo.CreateNoWindow = True
    '                .StartInfo.WindowStyle = ProcessWindowStyle.Hidden
    '                .StartInfo.RedirectStandardInput = True
    '                .StartInfo.RedirectStandardOutput = True
    '                .StartInfo.UseShellExecute = False
    '                'usefull to allow special settings for therion launced from csurvey
    '                Dim sCustomTherionIniPath As String = My.Application.Settings.GetSetting("therion.inipath", "")
    '                If sCustomTherionIniPath <> "" Then
    '                    .StartInfo.EnvironmentVariables.Add("THERION", sCustomTherionIniPath)
    '                Else
    '                    .StartInfo.EnvironmentVariables.Add("THERION", modMain.GetUserApplicationPath)
    '                End If
    '            End If
    '            Call .Start()
    '            If Background Then
    '                Call .BeginOutputReadLine()
    '            End If
    '            Call .StandardInput.WriteLine()
    '            'Dim iWait As Integer = 0
    '            Do
    '                Call .WaitForExit(iTimeout)
    '                'iWait += iWaitForExit
    '                If Not .HasExited Then ' AndAlso iWait >= iTimeout Then
    '                    If MsgBox(GetLocalizedString("process.warning1"), MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical, GetLocalizedString("process.warningtitle")) = MsgBoxResult.Cancel Then
    '                        Call KillProcessTree(oProcess)
    '                        Call Err.Raise(vbObjectError + 200, "process.aborted", GetLocalizedString("process.textpart1"), Nothing, Nothing)
    '                    End If
    '                End If
    '            Loop Until .HasExited
    '            Return .ExitCode
    '        End With
    '    End Using
    'End Function

    Public Function ExecuteTherion(TherionExecutable As String, TherionIni As String, ByVal Arguments As String, ByVal Background As Boolean, OutputHandler As System.Diagnostics.DataReceivedEventHandler) As Integer
        Dim iTimeout As Integer = 120000
        'Dim iWaitForExit As Integer = 500 '120000 ' Integer.MaxValue
        Using oProcess As Process = New Process
            With oProcess
                .StartInfo.WorkingDirectory = My.Computer.FileSystem.SpecialDirectories.Temp
                .StartInfo.FileName = TherionExecutable
                .StartInfo.Arguments = Arguments
                If Background Then
                    If Not OutputHandler Is Nothing Then AddHandler .OutputDataReceived, OutputHandler
                    .StartInfo.CreateNoWindow = True
                    .StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    .StartInfo.RedirectStandardInput = True
                    .StartInfo.RedirectStandardOutput = True
                    .StartInfo.UseShellExecute = False
                    'usefull to allow special settings for therion launced from csurvey
                    Dim sCustomTherionIniPath As String = TherionIni
                    If sCustomTherionIniPath <> "" Then
                        .StartInfo.EnvironmentVariables.Add("THERION", sCustomTherionIniPath)
                    Else
                        .StartInfo.EnvironmentVariables.Add("THERION", modMain.GetUserApplicationPath)
                    End If
                End If
                Call .Start()
                If Background Then
                    Call .BeginOutputReadLine()
                End If
                Call .StandardInput.WriteLine()
                'Dim iWait As Integer = 0
                Do
                    Call .WaitForExit(iTimeout)
                    'iWait += iWaitForExit
                    If Not .HasExited Then ' AndAlso iWait >= iTimeout Then
                        If MsgBox(GetLocalizedString("process.warning1"), MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical, GetLocalizedString("process.warningtitle")) = MsgBoxResult.Cancel Then
                            Call KillProcessTree(oProcess)
                            Call Err.Raise(vbObjectError + 200, "process.aborted", GetLocalizedString("process.textpart1"), Nothing, Nothing)
                        End If
                    End If
                Loop Until .HasExited
                Return .ExitCode
            End With
        End Using
    End Function

    Private oRM As System.Resources.ResourceManager

    Public Sub LoadLocalizedStrings(Language As String)
        oRM = System.Resources.ResourceManager.CreateFileBasedResourceManager("resources", modMain.GetApplicationPath, Nothing)
    End Sub

    Public Function GetLocalizedString(Name As String) As String
        'Try
        Return oRM.GetString(Name).Replace("{br}", vbCrLf)
        'Catch
        '    'I don't know if is usefull...resource have to be readed with fallback...if not in oRm-> read from default resourcemanager
        '    'if is sure that is not usefull...remove it and try catch
        '    Return oDefaultRM.GetString(Name).Replace("{br}", vbCrLf)
        'End Try
    End Function

    Public Function CalculateHash(Text As String) As String
        Dim oSW As StreamWriter = New StreamWriter(New MemoryStream)
        Call oSW.Write(Text)
        Return CalculateHash(oSW.BaseStream)
    End Function

    Public Function CalculateHash(Data As Byte()) As String
        Dim oCSP As System.Security.Cryptography.SHA1CryptoServiceProvider = New System.Security.Cryptography.SHA1CryptoServiceProvider
        Dim oHash() As Byte = oCSP.ComputeHash(Data, 0, Data.Length)
        Dim sHash As System.Text.StringBuilder = New System.Text.StringBuilder
        For Each oHashItem As Byte In oHash
            Call sHash.Append(String.Format("{0:X1}", oHashItem))
        Next
        Return sHash.ToString
    End Function

    Public Function CalculateHash(Stream As Stream) As String
        Call Stream.Seek(0, SeekOrigin.Begin)
        Dim oCSP As System.Security.Cryptography.SHA1CryptoServiceProvider = New System.Security.Cryptography.SHA1CryptoServiceProvider
        Dim oHash() As Byte = oCSP.ComputeHash(Stream)
        Dim sHash As System.Text.StringBuilder = New System.Text.StringBuilder
        For Each oHashItem As Byte In oHash
            Call sHash.Append(String.Format("{0:X1}", oHashItem))
        Next
        Return sHash.ToString
    End Function

    Public Sub DeleteFiles(Files As List(Of String))
        With My.Computer.FileSystem
            For Each sFile As String In Files
                If .FileExists(sFile) Then
                    Call My.Computer.FileSystem.DeleteFile(sFile)
                End If
            Next
        End With
    End Sub

    Public Function MakeRelative(ByVal FullPath As String, ByVal BaseDir As String) As String
        Dim pathSep As String = Path.DirectorySeparatorChar
        Dim itemPath As String = Path.GetFullPath(FullPath)
        Dim baseDirPath As String = Path.GetFullPath(BaseDir)
        Dim p1 As String() = Regex.Split(itemPath, "\" & pathSep).Where(Function(x) x.Length <> 0).ToArray()
        Dim p2 As String() = Regex.Split(BaseDir, "\" & pathSep).Where(Function(x) x.Length <> 0).ToArray()
        Dim i As Integer = 0

        While i < p1.Length AndAlso i < p2.Length
            If String.Compare(p1(i), p2(i), True) <> 0 Then Exit While
            i += 1
        End While

        If i = 0 Then Return itemPath
        Dim r As String = String.Join(pathSep, Enumerable.Repeat("..", p2.Length - i).Concat(p1.Skip(i).Take(p1.Length - i)))
        Return r
    End Function

    Public Class cComboItem
        Public Source As Object
        Public Text As String

        Public Overrides Function ToString() As String
            Return Text
        End Function

        Public Sub New(Source As Object, Text As String)
            Me.Source = Source
            Me.Text = Text
        End Sub
    End Class
End Module
