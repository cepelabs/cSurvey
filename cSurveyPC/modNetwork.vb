Imports System.IO
Imports System.Text

Module modNetwork
    Public Function CreatePostParameters(ParamArray Parameters As String()) As Specialized.NameValueCollection
        Dim oParameters As Specialized.NameValueCollection = New Specialized.NameValueCollection()
        For i As Integer = 0 To Parameters.Length - 1 Step 2
            Call oParameters.Add(Parameters(i), Parameters(i + 1))
        Next
        Return oParameters
    End Function

    Public Function PostValues(Net As cSurvey.Net.cINetBase, Session As System.Net.CookieContainer, Address As String, Parameters As Specialized.NameValueCollection, Optional Debug As Boolean = False) As MemoryStream
        Dim oWC As cSurvey.Net.CookieWebClient = New cSurvey.Net.CookieWebClient(Session)
        If Not Net.Credentials Is Nothing Then oWC.Credentials = Net.Credentials
        If Not IsNothing(Parameters) Then oWC.QueryString.Add(Parameters)
        Dim oNullData() As Byte = {&H0}
        If Debug Then
            Dim oData As Byte() = oWC.UploadData(Net.URL & Address, "POST", oNullData)
            Call oWC.Dispose()

            Dim sResult As String = ASCIIEncoding.UTF8.GetString(oData)
            Call System.Diagnostics.Debug.Print(sResult)

            Dim oResult As MemoryStream = New MemoryStream(oData)
            Return oResult
        Else
            Dim oResult As MemoryStream = New MemoryStream(oWC.UploadData(Net.URL & Address, "POST", oNullData))
            Call oWC.Dispose()
            Return oResult
        End If
    End Function

    Public Function PostValues(Net As cSurvey.Net.cINetBase, Session As System.Net.CookieContainer, Address As String, Parameters As Specialized.NameValueCollection, Values As Specialized.NameValueCollection, Optional Debug As Boolean = False) As MemoryStream
        Dim oWC As cSurvey.Net.CookieWebClient = New cSurvey.Net.CookieWebClient(Session)
        If Not Net.Credentials Is Nothing Then oWC.Credentials = Net.Credentials
        If Not IsNothing(Parameters) Then Call oWC.QueryString.Add(Parameters)
        If Debug Then
            Dim oData As Byte() = oWC.UploadValues(Net.URL & Address, "POST", Values)
            Call oWC.Dispose()

            Dim sResult As String = ASCIIEncoding.ASCII.GetString(oData)
            Call System.Diagnostics.Debug.Print(sResult)

            Dim oResult As MemoryStream = New MemoryStream(oData)
            Return oResult
        Else
            Dim oResult As MemoryStream = New MemoryStream(oWC.UploadValues(Net.URL & Address, "POST", Values))
            Call oWC.Dispose()
            Return oResult
        End If

        'oSession = New CookieContainer
        'Dim oWC As CookieWebClient = New CookieWebClient(oSession)
        'If oCredentials Is Nothing Then oWC.Credentials = oCredentials
        'Dim oValues As Specialized.NameValueCollection = New Specialized.NameValueCollection
        'Call oValues.Add("username", Username)
        'Call oValues.Add("password", Password)
        'Dim oResult As MemoryStream = New MemoryStream(oWC.UploadValues(URL & "login.php", "POST", oValues))
        'Call oWC.Dispose()
    End Function
End Module
