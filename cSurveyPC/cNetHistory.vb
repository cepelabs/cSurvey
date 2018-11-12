Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Net

Imports cSurveyPC.cSurvey

Namespace cSurvey.Net
    Public Interface cINetBase
        Function Login(Username As String, Password As String) As Boolean
        Function SetCredential(Username As String, Password As String) As NetworkCredential
        Function IsLoggedIn() As Boolean
        ReadOnly Property URL As String
        ReadOnly Property LastMessage As String
        ReadOnly Property Credentials As NetworkCredential
    End Interface

    Friend Class CookieWebClient
        Inherits WebClient

        Private oSession As New CookieContainer()
        Private lastPage As String

        Protected Overrides Function GetWebRequest(ByVal address As System.Uri) As System.Net.WebRequest
            Dim R = MyBase.GetWebRequest(address)
            If TypeOf R Is HttpWebRequest Then
                With DirectCast(R, HttpWebRequest)
                    .CookieContainer = oSession
                    If Not lastPage Is Nothing Then
                        .Referer = lastPage
                    End If
                End With
            End If
            lastPage = address.ToString()
            Return R
        End Function

        Public Sub New(Session As CookieContainer)
            oSession = Session
        End Sub
    End Class

    Public Class cNetCaveRegister
        Implements cINetBase
        Implements cINetCaveRegister

        Private sLastMessage As String
        Private sURL As String
        Private oSession As CookieContainer

        Private oCredentials As ICredentials

        Public Overridable Function IsLoggedIn() As Boolean Implements cINetBase.IsLoggedIn
            Return Not oSession Is Nothing
        End Function

        Public Overridable ReadOnly Property LastMessage As String Implements cINetBase.LastMessage
            Get
                Return sLastMessage
            End Get
        End Property

        Public ReadOnly Property URL As String Implements cINetBase.URL
            Get
                Return sURL
            End Get
        End Property

        Public Function SetCredential(Username As String, Password As String) As NetworkCredential Implements cINetBase.SetCredential
            oCredentials = New NetworkCredential(Username, Password)
            Return oCredentials
        End Function

        Public Function Login(Username As String, Password As String) As Boolean Implements cINetBase.Login
            oSession = New CookieContainer
            Dim oResult As MemoryStream = modNetwork.PostValues(Me, oSession, "login.php", Nothing, modNetwork.CreatePostParameters("username", Username, "password", Password), True)
            Dim bResult As Boolean
            Dim oXML As XmlDocument = New XmlDocument
            Call oXML.Load(oResult)
            With oXML.Item("csurvey").Item("response")
                bResult = .GetAttribute("result")
                sLastMessage = .GetAttribute("message")
            End With
            If Not bResult Then
                oSession = Nothing
            End If
            Return bResult
        End Function

        Public ReadOnly Property Credentials As NetworkCredential Implements cINetBase.Credentials
            Get
                Return oCredentials
            End Get
        End Property

        Public Sub New(URL As String)
            sURL = URL
            If Not sURL.EndsWith("/") Then sURL = sURL & "/"
        End Sub

        Public Function [Get](CaveID As String, ByRef Data As XmlDocument, ByRef [Structure] As XmlDocument) As Boolean Implements cINetCaveRegister.Get
            Dim bResult As Boolean
            Try
                Dim oDataStream As MemoryStream = modNetwork.PostValues(Me, oSession, "get.php?numero=" & CaveID, Nothing, True)
                If Data Is Nothing Then Data = New XmlDocument
                Call Data.Load(oDataStream)
                Dim oStructureStream As MemoryStream = modNetwork.PostValues(Me, oSession, "structure.php", Nothing, True)
                If [Structure] Is Nothing Then [Structure] = New XmlDocument
                Call [Structure].Load(oStructureStream)
                bResult = True
            Catch ex As Exception
                bResult = False
                sLastMessage = ex.Message
            End Try
            Return bResult
        End Function
    End Class

    Public Interface cINetCaveRegister
        Function [Get](CaveID As String, ByRef [Data] As XmlDocument, ByRef [Structure] As XmlDocument) As Boolean
        'Function Edit(CaveID As String, ByRef EditID As Integer, ByRef Document As XmlDocument) As Boolean
        'Function Commit(EditID As Integer, Document As XmlDocument) As Boolean
        'Function Cancel(EditID As Integer) As Boolean
        ''Function Download(URL As Integer, ByRef Result As String) As Boolean
        'Function Upload(EditID As Integer, Filename As String, ByRef Result As Integer) As Boolean
    End Interface

    Public Class cNetHistorySet
        Public ID As Integer
        Public Name As String
        Public Origin As String
        Public DateStamp As DateTime
        Public Username As String
        Public Size As Integer
        Public PrevID As Integer
        Public NextID As Integer

        Public Sub New(ID As Integer, Name As String, Origin As String, DateStamp As DateTime, Username As String, Size As Integer, PrevID As Integer, NextID As Integer)
            Me.ID = ID
            Me.Name = Name
            Me.Origin = Origin
            Me.DateStamp = DateStamp
            Me.Username = Username
            Me.Size = Size
            Me.PrevID = PrevID
            Me.NextID = NextID
        End Sub
    End Class

    Public Class cNetHistoryItem
        Public ID As Integer
        Public ParentID As Integer
        Public Name As String
        Public Type As Integer
        Public DataID As Integer
        Public Size As Integer

        Public Sub New(ID As Integer, ParentID As Integer, Name As String, Type As Integer, DataID As Integer, Size As Integer)
            Me.ID = ID
            Me.ParentID = ParentID
            Me.Name = Name
            Me.Type = Type
            Me.DataID = DataID
            Me.Size = Size
        End Sub
    End Class

    Public Interface cINetHistory
        Function CreateFolder(SetID As Integer, ParentID As Integer, Name As String, ByRef Result As Integer) As Boolean
        Function GetFolder(SetID As Integer, ID As Integer, ByRef Result As List(Of cNetHistoryItem)) As Boolean
        Function DeleteFolder(SetID As Integer, ID As Integer, ByRef Result As Integer) As Boolean

        Function GetSets(CaveID As String, ByRef Result As List(Of cNetHistorySet)) As Boolean

        Function CreateSet(CaveID As String, Name As String, ByRef Result As Integer) As Boolean
        Function GetSet(SetID As Integer, ByRef Result As List(Of cNetHistoryItem)) As Boolean
        Function DeleteSet(SetID As Integer, ByRef Result As Integer) As Boolean

        Function Download(SetID As Integer, DataID As Integer, ByRef Result As String) As Boolean
        Function Upload(SetID As Integer, ParentID As Integer, Name As String, Filename As String, ContentType As String, DateStamp As DateTime, ByRef Result As Integer) As Boolean
    End Interface

    Public Class cNetHistory
        Implements cINetBase
        Implements cINetHistory

        Public Class cNetHistoryProgressEventArgs
            Public Enum ActionEnum
                Upload = &H0
                Download = &H1
                InProgress = &H10
            End Enum

            Private iAction As ActionEnum
            Private sCurrentBytes As Single
            Private sTotalBytes As Single

            Public Sub New(Action As ActionEnum, CurrentBytes As Single, TotalBytes As Single)
                iAction = Action
                sCurrentBytes = CurrentBytes
                sTotalBytes = TotalBytes
            End Sub

            Public ReadOnly Property Action As ActionEnum
                Get
                    Return iAction
                End Get
            End Property

            Public ReadOnly Property CurrentBytes As Single
                Get
                    Return sCurrentBytes
                End Get
            End Property

            Public ReadOnly Property TotalBytes As Single
                Get
                    Return sTotalBytes
                End Get
            End Property

            Public Function GetPercentage() As Single
                Return sCurrentBytes / sTotalBytes
            End Function
        End Class

        Public Event OnProgressChanged(Sender As cNetHistory, Args As cNetHistoryProgressEventArgs)

        Private iDailyCopies As Integer
        Private iMaxCopies As Integer

        Private sLastMessage As String
        Private sURL As String
        Private oSession As CookieContainer

        Private oCredentials As ICredentials

        Public Overridable Function IsLoggedIn() As Boolean Implements cINetBase.IsLoggedIn
            Return Not oSession Is Nothing
        End Function

        Public Overridable ReadOnly Property LastMessage As String Implements cINetBase.LastMessage
            Get
                Return sLastMessage
            End Get
        End Property

        Public ReadOnly Property URL As String Implements cINetBase.URL
            Get
                Return sURL
            End Get
        End Property

        Public Function SetCredential(Username As String, Password As String) As NetworkCredential Implements cINetBase.SetCredential
            Return New NetworkCredential(Username, Password)
        End Function

        Public Function Login(Username As String, Password As String) As Boolean Implements cINetBase.Login
            oSession = New CookieContainer

            Dim oResult As MemoryStream = modNetwork.PostValues(Me, oSession, "login.php", Nothing, modNetwork.CreatePostParameters("username", Username, "password", Password))

            Dim bResult As Boolean
            Dim oXML As XmlDocument = New XmlDocument
            Call oXML.Load(oResult)
            With oXML.Item("csurvey").Item("response")
                bResult = .GetAttribute("result")
                sLastMessage = .GetAttribute("message")
            End With

            If Not bResult Then
                oSession = Nothing
            End If

            Return bResult
        End Function

        Public Function GetSet(SetID As Integer, ByRef Result As List(Of cNetHistoryItem)) As Boolean Implements cINetHistory.GetSet
            Return GetFolder(SetID, 0, Result)
        End Function

        Public Function GetFolder(SetID As Integer, ID As Integer, ByRef Result As List(Of cNetHistoryItem)) As Boolean Implements cINetHistory.GetFolder
            Dim oResult As MemoryStream = modNetwork.PostValues(Me, oSession, "getfolder.php", modNetwork.CreatePostParameters("setid", SetID.ToString, "id", ID.ToString))

            Dim bResult As Boolean
            Dim oXML As XmlDocument = New XmlDocument
            Call oXML.Load(oResult)
            With oXML.Item("csurvey").Item("response")
                Result = New List(Of cNetHistoryItem)
                For Each oItem As XmlElement In oXML.Item("csurvey").Item("response").ChildNodes
                    Dim iID As Integer = oItem.GetAttribute("id")
                    Dim iParentID As Integer = ID
                    Dim sName As String = oItem.GetAttribute("name")
                    Dim sType As String = oItem.GetAttribute("type")
                    Dim iType As Integer = IIf(sType = "", 0, sType)
                    Dim iDataID As Integer = oItem.GetAttribute("dataid")
                    Dim iSize As Integer = oItem.GetAttribute("size")
                    Dim oNetItem As cNetHistoryItem = New cNetHistoryItem(iID, iParentID, sName, iType, iDataID, iSize)
                    Call Result.Add(oNetItem)
                Next
                bResult = .GetAttribute("result")
                sLastMessage = .GetAttribute("message")
            End With
            Return bResult
        End Function

        Public Function DeleteSet(SetID As Integer, ByRef Result As Integer) As Boolean Implements cINetHistory.DeleteSet
            Dim oResult As MemoryStream = modNetwork.PostValues(Me, oSession, "deleteset.php", modNetwork.CreatePostParameters("setid", SetID.ToString))

            Dim bResult As Boolean
            Dim oXML As XmlDocument = New XmlDocument
            Call oXML.Load(oResult)
            With oXML.Item("csurvey").Item("response")
                bResult = .GetAttribute("result")
                Result = .GetAttribute("value")
                sLastMessage = .GetAttribute("message")
            End With
            Return bResult
        End Function

        Public Function CreateFolder(SetID As Integer, ParentID As Integer, Name As String, ByRef Result As Integer) As Boolean Implements cINetHistory.CreateFolder
            Dim oResult As MemoryStream = modNetwork.PostValues(Me, oSession, "createfolder.php", modNetwork.CreatePostParameters("setid", SetID.ToString, "name", Name, "parentid", ParentID.ToString))

            Dim bResult As Boolean
            Dim oXML As XmlDocument = New XmlDocument
            Call oXML.Load(oResult)
            With oXML.Item("csurvey").Item("response")
                bResult = .GetAttribute("result")
                Result = .GetAttribute("value")
                sLastMessage = .GetAttribute("message")
            End With
            Return bResult
        End Function

        Public Function GetSets(CaveID As String, ByRef Result As List(Of cNetHistorySet)) As Boolean Implements cINetHistory.GetSets
            Dim oResult As MemoryStream = modNetwork.PostValues(Me, oSession, "getsets.php", modNetwork.CreatePostParameters("caveid", CaveID))

            Dim bResult As Boolean
            Dim oXML As XmlDocument = New XmlDocument
            Call oXML.Load(oResult)
            With oXML.Item("csurvey").Item("response")
                Result = New List(Of cNetHistorySet)
                For Each oItem As XmlElement In oXML.Item("csurvey").Item("response").ChildNodes
                    Dim iID As Integer = oItem.GetAttribute("id")
                    Dim sName As String = oItem.GetAttribute("name")
                    Dim sOrigin As String = oItem.GetAttribute("origin")
                    Dim dDateStamp As DateTime = oItem.GetAttribute("datestamp")
                    Dim sUsername As String = oItem.GetAttribute("username")
                    Dim sSize As String = oItem.GetAttribute("size")
                    Dim iSize As Integer = 0
                    Call Integer.TryParse(sSize, iSize)
                    Dim iPrevID As Integer = oItem.GetAttribute("previd")
                    Dim iNextID As Integer = oItem.GetAttribute("nextid")
                    Dim oNetSet As cNetHistorySet = New cNetHistorySet(iID, sName, sOrigin, dDateStamp, sUsername, iSize, iPrevID, iNextID)
                    Call Result.Add(oNetSet)
                Next
                bResult = .GetAttribute("result")
                sLastMessage = .GetAttribute("message")
            End With
            Return bResult
        End Function

        Public Function CreateSet(CaveID As String, Name As String, ByRef Result As Integer) As Boolean Implements cINetHistory.CreateSet
            Dim oResult As MemoryStream = modNetwork.PostValues(Me, oSession, "createset.php", modNetwork.CreatePostParameters("caveid", CaveID, "origin", My.Computer.Name, "name", Name))

            Dim bResult As Boolean
            Dim oXML As XmlDocument = New XmlDocument
            Call oXML.Load(oResult)
            With oXML.Item("csurvey").Item("response")
                bResult = .GetAttribute("result")
                Result = .GetAttribute("value")
                sLastMessage = .GetAttribute("message")
            End With
            Return bResult
        End Function

        Public Function Download(SetID As Integer, DataID As Integer, ByRef Result As String) As Boolean Implements cINetHistory.Download
            Dim oResult As MemoryStream = modNetwork.PostValues(Me, oSession, "download.php", modNetwork.CreatePostParameters("setid", SetID.ToString, "dataid", DataID.ToString))

            Try
                Dim bResult As Boolean
                Dim oXML As XmlDocument = New XmlDocument
                Call oXML.Load(oResult)
                With oXML.Item("csurvey").Item("response")
                    bResult = .GetAttribute("result")
                    Result = .GetAttribute("value")
                    sLastMessage = .GetAttribute("message")
                End With
                Return bResult
            Catch
                Dim sTempFilename As String = My.Computer.FileSystem.GetTempFileName
                Dim oFi As FileInfo = New FileInfo(sTempFilename)
                Dim oFs As FileStream = oFi.Create
                oResult.Position = 0
                Call oResult.WriteTo(oFs)
                Call oFs.Close()
                Call oFs.Dispose()
                Result = sTempFilename
                Return True
            End Try
        End Function

        Public Function Upload(SetID As Integer, ParentID As Integer, Name As String, Filename As String, ContentType As String, DateStamp As DateTime, ByRef Result As Integer) As Boolean Implements cINetHistory.Upload
            Dim oWC As CookieWebClient = New CookieWebClient(oSession)
            If oCredentials Is Nothing Then oWC.Credentials = oCredentials
            Call oWC.QueryString.Add("setid", SetID.ToString)
            Call oWC.QueryString.Add("name", Name)
            Call oWC.QueryString.Add("parentid", ParentID.ToString)
            Call oWC.QueryString.Add("contenttype", ContentType)
            Call oWC.QueryString.Add("datestamp", Strings.Format(DateStamp, "yyyy-MM-dd HH:mm:ss"))
            Call oWC.QueryString.Add("maxcopies", iMaxCopies)
            Call oWC.QueryString.Add("dailycopies", iDailyCopies)
            'AddHandler oWC.UploadProgressChanged, AddressOf oWC_UploadProgressChanged
            'AddHandler oWC.UploadFileCompleted, AddressOf oWC_UploadFileCompleted
            'AddHandler oWC.UploadFileCompleted, AddressOf oWC_UploadFileCompleted
            Dim bData As Byte() = oWC.UploadFile(New Uri(URL & "upload.php"), "POST", Filename)
            Dim oResult As MemoryStream = New MemoryStream(bData)
            Call oWC.Dispose()

            'Dim sResult As String = ASCIIEncoding.ASCII.GetString(bData)
            'Debug.Print(sResult)

            Dim bResult As Boolean
            Dim oXML As XmlDocument = New XmlDocument
            Call oXML.Load(oResult)
            With oXML.Item("csurvey").Item("response")
                bResult = .GetAttribute("result")
                Result = .GetAttribute("value")
                sLastMessage = .GetAttribute("message")
            End With
            Return bResult
        End Function

        Public Function Explode(SetID As Integer, DataID As Integer, ByRef Result As Integer) As Boolean 'Implements cINetHistory.Upload
            Dim oResult As MemoryStream = modNetwork.PostValues(Me, oSession, "explode.php", modNetwork.CreatePostParameters("setid", SetID, "dataid", DataID), True)
            'Dim sResult As String = ASCIIEncoding.ASCII.GetString(bData)
            'Debug.Print(sResult)

            Dim bResult As Boolean
            Dim oXML As XmlDocument = New XmlDocument
            Call oXML.Load(oResult)
            With oXML.Item("csurvey").Item("response")
                bResult = .GetAttribute("result")
                Result = .GetAttribute("value")
                sLastMessage = .GetAttribute("message")
            End With
            Return bResult
        End Function

        Public Function Implode(SetID As Integer, DataID As Integer, ByRef Result As String) As Boolean 'Implements cINetHistory.Upload
            Dim oResult As MemoryStream = modNetwork.PostValues(Me, oSession, "implode.php", modNetwork.CreatePostParameters("setid", SetID, "dataid", DataID), True)
            Try
                Dim bResult As Boolean
                Dim oXML As XmlDocument = New XmlDocument
                Call oXML.Load(oResult)
                With oXML.Item("csurvey").Item("response")
                    bResult = .GetAttribute("result")
                    Result = .GetAttribute("value")
                    sLastMessage = .GetAttribute("message")
                End With
                Return bResult
            Catch
                Dim sTempFilename As String = My.Computer.FileSystem.GetTempFileName & ".csz"
                Dim oFi As FileInfo = New FileInfo(sTempFilename)
                Dim oFs As FileStream = oFi.Create
                oResult.Position = 0
                Call oResult.WriteTo(oFs)
                Call oFs.Close()
                Call oFs.Dispose()
                Result = sTempFilename
                Return True
            End Try

            'oggetti item nel db...serve poi capire quali sono gli oggetti layer e relativi items per poter fare la merge...
            'Select Case* from(
            'SELECT id,
            '(select name from cs_dataitems as parentitems where id=cs_dataitems.parentid) As parent,
            '(select value from cs_dataitemsattr where cs_dataitemsattr.name='type' and itemsID=cs_dataitems.id) as type,
            '(select value from cs_dataitemsattr where cs_dataitemsattr.name='cave' and itemsID=cs_dataitems.id) as cave,
            '(select value from cs_dataitemsattr where cs_dataitemsattr.name='branch' and itemsID=cs_dataitems.id) as branch
            'From cs_dataitems
            'Where cs_dataitems.name ='item'
            ') as tmp Where parent ='items'

            'Dim sResult As String = ASCIIEncoding.ASCII.GetString(bData)
            'Debug.Print(sResult)

            'Dim bResult As Boolean
            'Dim oXML As XmlDocument = New XmlDocument
            'Call oXML.Load(oResult)
            'With oXML.Item("csurvey").Item("response")
            '    bResult = .GetAttribute("result")
            '    Result = .GetAttribute("value")
            '    sLastMessage = .GetAttribute("message")
            'End With
            'Return bResult
        End Function

        Public Sub New(URL As String, MaxCopies As Integer, DailyCopies As Integer)
            sURL = URL
            If Not sURL.EndsWith("/") Then sURL = sURL & "/"

            iMaxCopies = MaxCopies
            iDailyCopies = DailyCopies
        End Sub

        Public ReadOnly Property MaxCopies As Integer
            Get
                Return iMaxCopies
            End Get
        End Property

        Public ReadOnly Property DailyCopies As Integer
            Get
                Return iDailyCopies
            End Get
        End Property

        Public ReadOnly Property Credentials As NetworkCredential Implements cINetBase.Credentials
            Get
                Return oCredentials
            End Get
        End Property

        Public Function DeleteFolder(SetID As Integer, ID As Integer, ByRef Result As Integer) As Boolean Implements cINetHistory.DeleteFolder
            Dim oResult As MemoryStream = modNetwork.PostValues(Me, oSession, "deletefolder.php", modNetwork.CreatePostParameters("setid", SetID.ToString, "id", ID.ToString))

            Dim bResult As Boolean
            Dim oXML As XmlDocument = New XmlDocument
            Call oXML.Load(oResult)
            With oXML.Item("csurvey").Item("response")
                bResult = .GetAttribute("result")
                Result = .GetAttribute("value")
                sLastMessage = .GetAttribute("message")
            End With
            Return bResult
        End Function
    End Class
End Namespace