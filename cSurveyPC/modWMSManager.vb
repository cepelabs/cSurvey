Imports System.Xml
Imports System.Net
Imports System.ComponentModel
Imports System.Net.Http
Imports System.IO

Module modWMSManager
    Public WMSCachePath As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "cSurvey\wmscache")
    Public WMSCache As Dictionary(Of String, Image) = New Dictionary(Of String, Image)(System.StringComparer.OrdinalIgnoreCase)
    Public MaxCacheSize As Long

    Public Function FormatURL(URL As String, QueryString As String) As String
        If URL.Contains("?") Then
            If URL.EndsWith("&") Then
                Return URL & QueryString
            Else
                Return URL & "&" & QueryString
            End If
        Else
            Return URL & "?" & QueryString
        End If
    End Function

    Public Function WMSDownloadLayerList(URL As String, System As Integer, List As List(Of cSurvey.Surface.cWMSLayer)) As Boolean
        Try
            Using oWC As WebClient = New WebClient
                Dim sURL As String = FormatURL(URL, "service=wms&request=getcapabilities")
                sURL = sURL.Replace("%SYSTEM%", modNumbers.NumberToString(System, "0"))
                Dim oXML As XmlDocument = New XmlDocument
                Call oXML.LoadXml(oWC.DownloadString(sURL))

                Dim oImageFormats As List(Of String) = New List(Of String)
                For Each oXMLImageFormat As XmlElement In oXML.DocumentElement.Item("Capability").Item("Request").Item("GetMap").GetElementsByTagName("Format")
                    Dim sImageFormat As String = oXMLImageFormat.InnerText
                    Call oImageFormats.Add(sImageFormat)
                Next

                For Each oXMLNode As XmlNode In oXML.DocumentElement.Item("Capability").ChildNodes
                    If TypeOf oXMLNode Is XmlElement AndAlso oXMLNode.Name = "Layer" Then
                        Call pWMSLayerProcess(List, oXMLNode, Nothing, oImageFormats)
                    End If
                Next
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub pWMSLayerProcess(List As List(Of cSurvey.Surface.cWMSLayer), XMLNode As XmlElement, ParentSRS As List(Of String), ImageFormats As List(Of String))
        Dim oSRS As List(Of String) = pWMSLayerGetSRS(XMLNode)
        If Not IsNothing(ParentSRS) Then
            For Each sParentSRS As String In ParentSRS
                If Not oSRS.Contains(sParentSRS) Then oSRS.Add(sParentSRS)
            Next
        End If
        If modXML.ChildElementExist(XMLNode, "Name") Then
            Dim sName As String = XMLNode.Item("Name").InnerText
            Dim oWMSLayer As cSurvey.Surface.cWMSLayer = New cSurvey.Surface.cWMSLayer(sName)
            Call oWMSLayer.AppendImageFormat(ImageFormats)
            Call oWMSLayer.AppendSRS(oSRS)
            Call List.Add(oWMSLayer)
        End If
        For Each oXMLChildNode As XmlNode In XMLNode.ChildNodes
            If TypeOf oXMLChildNode Is XmlElement AndAlso oXMLChildNode.Name = "Layer" Then
                Call pWMSLayerProcess(List, oXMLChildNode, oSRS, ImageFormats)
            End If
        Next
    End Sub

    Private Function pWMSLayerGetSRS(XMLNode As XmlElement) As List(Of String)
        Dim oSRS As List(Of String) = New List(Of String)
        For Each oXMLSRSNode As XmlNode In XMLNode.ChildNodes
            If TypeOf oXMLSRSNode Is XmlElement Then
                If oXMLSRSNode.Name = "SRS" Or oXMLSRSNode.Name = "CRS" Then
                    Call oSRS.Add(oXMLSRSNode.InnerText)
                End If
            End If
        Next
        Return oSRS
    End Function

    Public Function ReplaceTags(Text As String, System As Integer, X1 As Decimal, Y1 As Decimal, X2 As Decimal, Y2 As Decimal, Width As Decimal, Height As Decimal) As String
        Text = Text.Replace("%SYSTEM%", modNumbers.NumberToString(System, "0"))
        Text = Text.Replace("%X1%", modNumbers.NumberToString(X1, "0.000"))
        Text = Text.Replace("%Y1%", modNumbers.NumberToString(Y1, "0.000"))
        Text = Text.Replace("%X2%", modNumbers.NumberToString(X2, "0.000"))
        Text = Text.Replace("%Y2%", modNumbers.NumberToString(Y2, "0.000"))
        Text = Text.Replace("%WIDTH%", modNumbers.NumberToString(Width, "0"))
        Text = Text.Replace("%HEIGHT%", modNumbers.NumberToString(Height, "0"))
        Return Text
    End Function

    Private Class cWMSTileToDownload
        Private sFilename As String
        Private sURL As String
        Private sWMSName As String

        Public ReadOnly Property WMSName As String
            Get
                Return sWMSName
            End Get
        End Property

        Public ReadOnly Property URL As String
            Get
                Return sURL
            End Get
        End Property

        Public ReadOnly Property Filename As String
            Get
                Return sFilename
            End Get
        End Property

        Public Sub New(Filename As String, URL As String, WMSName As String)
            sFilename = Filename
            sURL = URL
            sWMSName = WMSName
        End Sub
    End Class

    Private oWMSTileToDownload As List(Of cWMSTileToDownload) = New List(Of cWMSTileToDownload)
    Private WithEvents oBWWMSTileDownloader As BackgroundWorker = New BackgroundWorker
    Private oBWWMSTileDownloaderDoneEvent As Threading.AutoResetEvent = New Threading.AutoResetEvent(False)

    Public Class cWMSDownloadAsyncProgressArgs
        Private sPercentage As Single
        Private sWMSName As String

        Public ReadOnly Property Percentage As Single
            Get
                Return sPercentage
            End Get
        End Property

        Public ReadOnly Property WMSName As String
            Get
                Return sWMSName
            End Get
        End Property

        Friend Sub New(Percentage As Single, WMSName As String)
            sPercentage = Percentage
            sWMSName = WMSName
        End Sub
    End Class

    Public Class cWMSDownloadAsyncCompletedArgs
        Private bCancelled As Boolean

        Public ReadOnly Property Cancelled As Boolean
            Get
                Return bCancelled
            End Get
        End Property

        Friend Sub New(Cancelled As Boolean)
            bCancelled = Cancelled
        End Sub
    End Class

    Public Class cWMSStateChangeArgs
        Private iOldState As WMSStateEnum
        Private iNewState As WMSStateEnum

        Friend Sub New(OldState As WMSStateEnum, NewState As WMSStateEnum)
            iOldState = OldState
            iNewState = NewState
        End Sub

        Public ReadOnly Property OldState As WMSStateEnum
            Get
                Return iOldState
            End Get
        End Property

        Public ReadOnly Property NewState As WMSStateEnum
            Get
                Return iNewState
            End Get
        End Property
    End Class

    Public Class cWMSLogArgs
        Inherits EventArgs

        Private iType As EventLogEntryType
        Private sText As String

        Public ReadOnly Property Type As EventLogEntryType
            Get
                Return iType
            End Get
        End Property

        Public ReadOnly Property Text As String
            Get
                Return sText
            End Get
        End Property

        Public Sub New(ByVal Type As EventLogEntryType, ByVal Text As String)
            iType = Type
            sText = Text
        End Sub

    End Class

    Public Delegate Sub WMSLog(Args As cWMSLogArgs)

    Public Delegate Sub WMSDownloadAsyncProgress(Args As cWMSDownloadAsyncProgressArgs)
    Public Delegate Sub WMSDownloadAsyncCompleted(Args As cWMSDownloadAsyncCompletedArgs)
    Public Delegate Sub WMSStateChange(Args As cWMSStateChangeArgs)

    Public Sub WMSSetDelegate(WMSStateChange As WMSStateChange, WMSDownloadAsyncProgress As WMSDownloadAsyncProgress, WMSDownloadAsyncCompleted As WMSDownloadAsyncCompleted, WMSLog As WMSLog)
        oWMSStateChange = WMSStateChange
        oWMSDownloadAsyncProgress = WMSDownloadAsyncProgress
        oWMSDownloadAsyncCompleted = WMSDownloadAsyncCompleted
        oWMSLog = WMSLog
    End Sub

    Private oWMSStateChange As WMSStateChange
    Private oWMSDownloadAsyncProgress As WMSDownloadAsyncProgress
    Private oWMSDownloadAsyncCompleted As WMSDownloadAsyncCompleted
    Private oWMSLog As WMSLog

    Public Function WMSDownloadTileAsync()
        If oWMSTileToDownload.Count > 0 Then
            oBWWMSTileDownloader.WorkerReportsProgress = True
            oBWWMSTileDownloader.WorkerSupportsCancellation = True
            If Not oBWWMSTileDownloader.IsBusy Then
                Call oBWWMSTileDownloader.RunWorkerAsync()
            End If
        End If
    End Function

    Public Sub WMSDownloadFileReset()
        If oWMSTileToDownload.Count > 0 Then oWMSTileToDownload.Clear()
    End Sub

    Public Function WMSDownloadFileCancelAsync(Optional Wait As Boolean = False)
        If oBWWMSTileDownloader.IsBusy Then
            Call oBWWMSTileDownloader.CancelAsync()
            If Wait Then Call oBWWMSTileDownloaderDoneEvent.WaitOne()
        End If
    End Function

    Public Function WMSDownloadFileIsBusy() As Boolean
        Return oBWWMSTileDownloader.IsBusy
    End Function

    Private Function pWMSDownloadTile(Filename As String, URL As String) As Boolean
        Try
            Using oWC As WebClient = New WebClient
                Call oWC.DownloadFile(URL, Filename)
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub WMSClearCache(WMS As cSurvey.Surface.cWMS)
        Call WMSCache.Clear()
        If Not My.Computer.FileSystem.DirectoryExists(WMSCachePath) Then
            Call My.Computer.FileSystem.CreateDirectory(WMSCachePath)
        Else
            For Each oFile As IO.FileInfo In My.Computer.FileSystem.GetDirectoryInfo(WMSCachePath).GetFiles()
                If oFile.Name.StartsWith(WMS.ID) Then
                    Try
                        Call oFile.Delete()
                    Catch ex As Exception
                    End Try
                End If
            Next
        End If
    End Sub

    Public Sub WMSClearCache()
        Call WMSCache.Clear()
        If Not My.Computer.FileSystem.DirectoryExists(WMSCachePath) Then
            Call My.Computer.FileSystem.CreateDirectory(WMSCachePath)
        Else
            For Each oFile As IO.FileInfo In My.Computer.FileSystem.GetDirectoryInfo(WMSCachePath).GetFiles()
                Try
                    Call oFile.Delete()
                Catch ex As Exception
                End Try
            Next
        End If
    End Sub

    Public Sub WMSClearCache(MaxSize As Long)
        If Not My.Computer.FileSystem.DirectoryExists(WMSCachePath) Then
            Call My.Computer.FileSystem.CreateDirectory(WMSCachePath)
        Else
            Dim oFiles As IO.FileInfo() = My.Computer.FileSystem.GetDirectoryInfo(WMSCachePath).GetFiles()
            Dim lSize As Long = oFiles.Sum(Function(fileinfo) fileinfo.Length)
            If lSize > MaxSize Then
                'delete oldest file until size limit
                For Each oFile As IO.FileInfo In oFiles.OrderBy(Function(fileinfo) fileinfo.LastWriteTime)
                    Dim lFileSize As Long
                    Try
                        lFileSize = oFile.Length
                        Call oFile.Delete()
                    Catch ex As Exception
                        'nothing...file size ignored...
                    Finally
                        lSize -= lFileSize
                    End Try
                    If lSize <= MaxSize Then Exit For
                Next
            End If
        End If
    End Sub

    Private Sub oWMSClearCache_DoWork()
        Call WMSClearCache(MaxCacheSize)
    End Sub

    Public Sub WMSResizeCache()
        If MaxCacheSize > 0 Then
            Dim oBW As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker()
            AddHandler oBW.DoWork, AddressOf oWMSClearCache_DoWork
            Call oBW.RunWorkerAsync()
        End If
    End Sub

    Friend Function GetFallbackETRSSystemFromUTM(UTM As modUTM.UTM) As Integer
        Dim iSystem As Integer
        If UTM.Band >= "R" And UTM.Band <= "W" Then
            iSystem = 25800 + UTM.Zone
        End If
        Return iSystem
    End Function

    Friend Function GetSystemFromUTM(WMS As cSurvey.Surface.cWMS, UTM As modUTM.UTM) As Integer
        Dim iSystem As Integer
        Select Case WMS.SRSOverride
            Case "ETRS89"
                'use WGS84/UTM...
                If UTM.Band >= "R" And UTM.Band <= "W" Then
                    iSystem = 25800 + UTM.Zone
                End If
            Case "NAD83"
                If UTM.Band >= "N" Then
                    iSystem = 26900 + UTM.Zone
                End If
            Case Else
                'use WGS84/UTM...
                If UTM.Band >= "N" Then
                    iSystem = 32600 + UTM.Zone
                Else
                    iSystem = 32700 + UTM.Zone
                End If
        End Select
        Return iSystem
    End Function

    Public Function WMSGetCacheSize() As Single
        If My.Computer.FileSystem.DirectoryExists(WMSCachePath) Then
            Dim oFiles As IO.FileInfo() = My.Computer.FileSystem.GetDirectoryInfo(WMSCachePath).GetFiles()
            Return oFiles.Sum(Function(fileinfo) fileinfo.Length)
        Else
            Return 0
        End If
    End Function

    Public Function WMSIsTileInCache(Survey As cSurvey.cSurvey, Filename As String, System As Integer, X1 As Decimal, Y1 As Decimal, X2 As Decimal, Y2 As Decimal, Width As Decimal, Height As Decimal) As Boolean
        Filename = ReplaceTags(Filename, System, X1, Y1, X2, Y2, Width, Height)
        If WMSCache.ContainsKey(Filename) Then
            Return True
        Else
            Filename = IO.Path.Combine(WMSCachePath, Filename & ".png")
            If My.Computer.FileSystem.FileExists(Filename) Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Enum WMSStateEnum
        Online = 0
        Offline = 1
        ForcedOffline = 2
    End Enum

    Private iState As WMSStateEnum

    Public ReadOnly Property State As WMSStateEnum
        Get
            Return iState
        End Get
    End Property

    Public Function WMSCheckState() As WMSStateEnum
        If iState = WMSStateEnum.ForcedOffline Then
            Return iState
        Else
            Dim req As System.Net.HttpWebRequest
            Dim res As System.Net.HttpWebResponse
            Try
                req = CType(System.Net.HttpWebRequest.Create("http://www.csurvey.it"), System.Net.HttpWebRequest)
                res = CType(req.GetResponse(), System.Net.HttpWebResponse)
                req.Abort()
                If res.StatusCode = System.Net.HttpStatusCode.OK Then
                    Call WMSSetState(WMSStateEnum.Online)
                End If
            Catch weberrt As System.Net.WebException
                Call oWMSLog(New cWMSLogArgs(EventLogEntryType.Warning, "WMS to offline: " & weberrt.Message))
                Call WMSSetState(WMSStateEnum.Offline)
            Catch except As Exception
                Call oWMSLog(New cWMSLogArgs(EventLogEntryType.Warning, "WMS to offline: " & except.Message))
                Call WMSSetState(WMSStateEnum.Offline)
            End Try
            'If My.Computer.Network.Ping("www.csurvey.it", 19000) Then
            '    Call WMSSetState(WMSStateEnum.Online)
            'Else
            '    Call WMSSetState(WMSStateEnum.Offline)
            'End If
        End If
        Return iState
    End Function

    Public Sub WMSSetState(State As WMSStateEnum)
        If iState <> State Then
            Dim iOldState As WMSStateEnum = iState
            iState = State
            Call oWMSStateChange.Invoke(New cWMSStateChangeArgs(iOldState, iState))

            If iState <> WMSStateEnum.Online Then
                Call WMSDownloadFileCancelAsync()
            End If
        End If
    End Sub

    Public Function WMSLoadTileAsync(Survey As cSurvey.cSurvey, WMSName As String, Filename As String, URL As String, System As Integer, X1 As Decimal, Y1 As Decimal, X2 As Decimal, Y2 As Decimal, Width As Decimal, Height As Decimal, StartDownload As Boolean) As Image
        Filename = ReplaceTags(Filename, System, X1, Y1, X2, Y2, Width, Height)
        URL = ReplaceTags(URL, System, X1, Y1, X2, Y2, Width, Height)
        If WMSCache.ContainsKey(Filename) Then
            Return WMSCache(Filename)
        Else
            Dim bdownload As Boolean = False
            If Not My.Computer.FileSystem.DirectoryExists(WMSCachePath) Then
                Call My.Computer.FileSystem.CreateDirectory(WMSCachePath)
            End If
            Dim sFilename As String = IO.Path.Combine(WMSCachePath, Filename & ".png")
            If My.Computer.FileSystem.FileExists(sFilename) Then
                Try
                    Dim oImage As Image = modPaint.SafeBitmapFromFileUnlocked(sFilename)
                    Call WMSCache.Add(Filename, oImage)
                    Return oImage
                Catch ex1 As Exception
                    Call oWMSLog(New cWMSLogArgs(EventLogEntryType.Warning, "WMS download tile warning: " & ex1.Message))
                    Call My.Computer.FileSystem.DeleteFile(sFilename)
                    bdownload = True
                End Try
            Else
                bdownload = True
            End If
            If bdownload AndAlso iState = WMSStateEnum.Online Then
                Call WMSResizeCache()
                Call oWMSTileToDownload.Add(New cWMSTileToDownload(sFilename, URL, WMSName))
                If StartDownload Then Call WMSDownloadTileAsync()
                Return pGetWaitForDownloadImage()
            Else
                Return pGetOfflineImage()
            End If
        End If
    End Function

    Private oOfflineImage As Image
    Private oWaitForDownloadImage As Image

    Private Function pGetOfflineImage() As Image
        If oOfflineImage Is Nothing Then
            oOfflineImage = New Bitmap(100, 100)
            Using oGr As Graphics = Graphics.FromImage(oOfflineImage)
                Call oGr.Clear(Color.DimGray)
            End Using
        End If
        Return oOfflineImage
    End Function

    Private Function pGetWaitForDownloadImage() As Image
        If oWaitForDownloadImage Is Nothing Then
            oWaitForDownloadImage = New Bitmap(100, 100)
            Using oGr As Graphics = Graphics.FromImage(oWaitForDownloadImage)
                Call oGr.Clear(Color.LightGray)
            End Using
        End If
        Return oWaitForDownloadImage
    End Function

    Private iWMSErrorCount As Integer

    Private Sub pCheckErrors()
        If iWMSErrorCount > 20 Then
            iWMSErrorCount = 0
            Call WMSCheckState()
        End If
    End Sub

    Public Function WMSLoadTile(Survey As cSurvey.cSurvey, WMSName As String, Filename As String, URL As String, System As Integer, X1 As Decimal, Y1 As Decimal, X2 As Decimal, Y2 As Decimal, Width As Decimal, Height As Decimal) As Image
        Filename = ReplaceTags(Filename, System, X1, Y1, X2, Y2, Width, Height)
        URL = ReplaceTags(URL, System, X1, Y1, X2, Y2, Width, Height)
        If WMSCache.ContainsKey(Filename) Then
            Return WMSCache(Filename)
        Else
            If Not My.Computer.FileSystem.DirectoryExists(WMSCachePath) Then
                Call My.Computer.FileSystem.CreateDirectory(WMSCachePath)
            End If
            Dim sFilename As String = IO.Path.Combine(WMSCachePath, Filename & ".png")
            If My.Computer.FileSystem.FileExists(sFilename) Then
                Dim oImage As Image = modPaint.SafeBitmapFromFileUnlocked(sFilename)
                Call WMSCache.Add(Filename, oImage)
                Return oImage
            Else
                Call WMSResizeCache()
                If iState = WMSStateEnum.Online Then
                    Dim sTempFilename As String = My.Computer.FileSystem.GetTempFileName
                    Try
                        Dim oResult As cDownloadResult = pDownload(URL, sTempFilename)
                        If oResult.Result Then
                            Call My.Computer.FileSystem.MoveFile(sTempFilename, Filename, True)
                            Dim oImage As Image = modPaint.SafeBitmapFromFileUnlocked(Filename)
                            Call WMSCache.Add(Filename, oImage)
                            Return oImage
                        Else
                            Call oWMSLog(New cWMSLogArgs(EventLogEntryType.Error, "WMS download tile error: " & oResult.Message))
                        End If
                        Call My.Computer.FileSystem.MoveFile(sTempFilename, Filename, True)
                    Catch ex As Exception
                        Call oWMSLog(New cWMSLogArgs(EventLogEntryType.Error, "WMS download tile error: " & ex.Message))
                        Return pGetOfflineImage()
                    End Try
                Else
                    Return pGetOfflineImage()
                End If
            End If
        End If
    End Function

    Private Class cDownloadResult
        Private bResult As Boolean
        Private sMessage As String

        Public Sub New(Result As Boolean, Optional Message As String = "")
            bResult = Result
            sMessage = Message
        End Sub

        Public ReadOnly Property Message As String
            Get
                Return sMessage
            End Get
        End Property

        Public ReadOnly Property Result As Boolean
            Get
                Return bResult
            End Get
        End Property
    End Class

    Private Function pDownload(URL As String, Filename As String) As cDownloadResult
        'download with request type check...if xml i try to read error...
        Dim oHttp As WebRequest = HttpWebRequest.Create(URL)
        Using oResponse As HttpWebResponse = oHttp.GetResponse
            If oResponse.ContentType.ToLower = "application/vnd.ogc.se_xml" Then ' Like "application/*xml" Then   'application/vnd.ogc.se_xml
                Dim oXML As Xml.XmlDocument = New Xml.XmlDocument
                Call oXML.Load(oResponse.GetResponseStream)
                Return New cDownloadResult(False, oXML.DocumentElement.ChildNodes(0).InnerText)
            ElseIf oResponse.ContentType.ToLower = "image/png" Then
                Using oFS As FileStream = File.OpenWrite(Filename)
                    Call oResponse.GetResponseStream.CopyTo(oFS)
                End Using
                Return New cDownloadResult(True)
            Else
                Return New cDownloadResult(False, "Unknow WMS contenttype response (" & oResponse.ContentType & ")")
            End If
        End Using
    End Function

    Private Class cWebClient
        Inherits System.Net.WebClient

        Private iTimeout As Integer = 0

        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal Timeout As Integer)
            MyBase.New()
            iTimeout = Timeout
        End Sub
        ''' <summary>
        ''' Set the web call timeout in Milliseconds
        ''' </summary>
        ''' <value></value>
        Public WriteOnly Property setTimeout() As Integer
            Set(ByVal value As Integer)
                iTimeout = value
            End Set
        End Property

        Protected Overrides Function GetWebRequest(ByVal address As System.Uri) As System.Net.WebRequest
            Dim w As System.Net.WebRequest = MyBase.GetWebRequest(address)
            If iTimeout <> 0 Then
                w.Timeout = iTimeout
            End If
            Return w
        End Function
    End Class

    Private Sub oBWWMSTileDownloader_DoWork(sender As Object, e As DoWorkEventArgs) Handles oBWWMSTileDownloader.DoWork
        If iState = WMSStateEnum.Online Then
            Dim iIndex As Integer
            Dim iCount As Integer = oWMSTileToDownload.Count
            If iCount > 0 Then
                Do While oWMSTileToDownload.Count AndAlso Not e.Cancel
                    Dim oItem As cWMSTileToDownload = oWMSTileToDownload(0)
                    If (iIndex Mod 5) = 0 Then oWMSDownloadAsyncProgress.Invoke(New cWMSDownloadAsyncProgressArgs(iIndex / iCount, oItem.WMSName))
                    Dim sTempFilename As String = My.Computer.FileSystem.GetTempFileName
                    Try
                        'due to some possibile parallelism (also with other cSurvey instance) I check if file exists...
                        If Not My.Computer.FileSystem.FileExists(oItem.Filename) Then
                            Dim oResult As cDownloadResult = pDownload(oItem.URL, sTempFilename)
                            If oResult.Result Then
                                Call My.Computer.FileSystem.MoveFile(sTempFilename, oItem.Filename, True)
                                'this is a strange check but some time (when cancel and restart work) this have to be checked...
                                If Not WMSCache.ContainsKey(oItem.Filename) Then
                                    Dim oImage As Image = modPaint.SafeBitmapFromFileUnlocked(oItem.Filename)
                                    Call WMSCache.Add(oItem.Filename, oImage)
                                End If
                            Else
                                Call oWMSLog(New cWMSLogArgs(EventLogEntryType.Error, "WMS download tile error: " & oResult.Message))
                                iWMSErrorCount += 1
                                Call pCheckErrors()
                            End If
                        End If
                    Catch ex As Exception
                        Call oWMSLog(New cWMSLogArgs(EventLogEntryType.Error, "WMS download tile error: " & ex.Message))
                        iWMSErrorCount += 1
                        Call pCheckErrors()
                    End Try
                    If oWMSTileToDownload.Count Then Call oWMSTileToDownload.RemoveAt(0)

                    If oBWWMSTileDownloader.CancellationPending Then
                        e.Cancel = True
                        Call oWMSTileToDownload.Clear()
                    End If

                    iIndex += 1

                    'verifico che l'insieme non sia cambiato...se si resetto il conteggio...
                    If oWMSTileToDownload.Count <> iCount - iIndex Then
                        iIndex = 0
                        iCount = oWMSTileToDownload.Count
                    End If
                Loop

                Call oWMSDownloadAsyncCompleted.Invoke(New cWMSDownloadAsyncCompletedArgs(e.Cancel))
                Call oBWWMSTileDownloaderDoneEvent.Set()
            End If
        End If
    End Sub

End Module
