Imports cSurveyPC.cSurvey
Imports System.Xml
Imports System.IO
Imports cSurveyPC.cSurvey.Storage

Namespace cSurvey.CaveRegister
    Public Interface cICaveRegisterSetting
        ReadOnly Property ID As String
        Property Name As String

        Function IsInUse() As Boolean
    End Interface

    Public Class cCaveRegisterSettingBase
        Implements cICaveRegisterSetting

        Private oSurvey As cSurvey

        Private sID As String
        Private sName As String

        Public Function IsInUse() As Boolean Implements cICaveRegisterSetting.IsInUse
            For Each oData As cCaveRegisterData In oSurvey.CaveRegister.Datas
                If oData.GetSetting Is Me Then Return True
            Next
            Return False
        End Function

        Public Sub New(ByVal Survey As cSurvey, Name As String)
            oSurvey = Survey
            sID = Guid.NewGuid.ToString
            sName = Name
        End Sub

        Public ReadOnly Property ID As String Implements cICaveRegisterSetting.ID
            Get
                Return sID
            End Get
        End Property

        Public Property Name As String Implements cICaveRegisterSetting.Name
            Get
                Return sName
            End Get
            Set(value As String)
                sName = Name
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return sName
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal CaveRegisterSetting As XmlElement)
            oSurvey = Survey
            sID = CaveRegisterSetting.GetAttribute("id")
            sName = CaveRegisterSetting.GetAttribute("name")
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlCaveRegisterSetting As XmlElement = Document.CreateElement("caveregistersetting")
            Call oXmlCaveRegisterSetting.SetAttribute("id", sID)
            Call oXmlCaveRegisterSetting.SetAttribute("name", sName)
            Call Parent.AppendChild(oXmlCaveRegisterSetting)
            Return oXmlCaveRegisterSetting
        End Function
    End Class

    Public Class cCaveRegisterSetting
        Inherits cCaveRegisterSettingBase
        Private sURL As String
        Private sUsername As String
        Private sPassword As String

        Public Sub New(ByVal Survey As cSurvey, Name As String, URL As String)
            Call MyBase.New(Survey, Name)
            sURL = URL
            sUsername = ""
            sPassword = ""
        End Sub

        Public Sub New(ByVal Survey As cSurvey, Name As String, URL As String, Username As String, Password As String)
            Call MyBase.New(Survey, Name)
            sURL = URL
            sUsername = Username
            sPassword = Password
        End Sub

        Public Property URL As String
            Get
                Return sURL
            End Get
            Set(value As String)
                sURL = value
            End Set
        End Property

        Public Property Username As String
            Get
                Return sUsername
            End Get
            Set(value As String)
                sUsername = value
            End Set
        End Property

        Public Property Password As String
            Get
                Return sPassword
            End Get
            Set(value As String)
                sPassword = value
            End Set
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal CaveRegisterSetting As XmlElement)
            MyBase.New(Survey, CaveRegisterSetting)
            sURL = CaveRegisterSetting.GetAttribute("url")
            sUsername = modXML.GetAttributeValue(CaveRegisterSetting, "username")
            sPassword = modXML.GetAttributeValue(CaveRegisterSetting, "password")
        End Sub

        Friend Overrides Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlCaveRegisterSetting As XmlElement = MyBase.SaveTo(File, Document, Parent)
            Call oXmlCaveRegisterSetting.SetAttribute("url", sURL)
            If sUsername <> "" Then Call oXmlCaveRegisterSetting.SetAttribute("username", sUsername)
            If sPassword <> "" Then Call oXmlCaveRegisterSetting.SetAttribute("password", sPassword)
            Return oXmlCaveRegisterSetting
        End Function
    End Class
End Namespace