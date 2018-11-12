Imports cSurveyPC.cSurvey
Imports System.Xml
Imports System.IO
Imports cSurveyPC.cSurvey.Storage
Imports cSurveyPC.cSurvey.Net

Namespace cSurvey.CaveRegister
    Public Class cCaveRegisterData
        Private oSurvey As cSurvey

        Private sCaveID As String
        Private sName As String
        Private oSetting As cCaveRegisterSetting
        Private sSettingID As String
        Private oData As XmlDocument
        Private oStructure As XmlDocument

        Private oFiles As Dictionary(Of String, MemoryStream)

        Private bHasData As Boolean

        Friend Sub CopyFrom(CaveRegisterData As cCaveRegisterData)
            sCaveID = CaveRegisterData.CaveID
            oSetting = CaveRegisterData.oSetting
            sSettingID = CaveRegisterData.sSettingID
            oData = CaveRegisterData.oData.Clone
            oStructure = CaveRegisterData.oStructure.Clone
            oFiles.Clear()
            For Each sFilename As String In CaveRegisterData.oFiles.Keys
                Dim oSourceStream As MemoryStream = CaveRegisterData.oFiles(sFilename)
                Dim oStream As MemoryStream = New MemoryStream(oSourceStream.Length)
                oSourceStream.Position = 0
                oSourceStream.CopyTo(oStream)
                Call oFiles.Add(sFilename, oStream)
            Next
            bHasData = CaveRegisterData.bHasData
        End Sub

        Public ReadOnly Property HasData As Boolean
            Get
                Return bHasData
            End Get
        End Property

        Public ReadOnly Property SettingID As String
            Get
                Return sSettingID
            End Get
        End Property

        Public Function GetSetting() As cCaveRegisterSetting
            If oSetting Is Nothing Then
                oSetting = oSurvey.CaveRegister.Settings(sSettingID)
            End If
            Return oSetting
        End Function

        Public Property Name As String
            Get
                Return sName
            End Get
            Set(value As String)
                sName = value
            End Set
        End Property

        Public ReadOnly Property CaveID As String
            Get
                Return sCaveID
            End Get
        End Property

        Public ReadOnly Property [Data] As XmlDocument
            Get
                Return oData
            End Get
        End Property

        Public ReadOnly Property [Structure] As XmlDocument
            Get
                Return oStructure
            End Get
        End Property

        Public ReadOnly Property Files As Dictionary(Of String, MemoryStream)
            Get
                Return oFiles
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, CaveRegisterData As cCaveRegisterData)
            oSurvey = Survey
            oData = New XmlDocument
            oStructure = New XmlDocument
            oFiles = New Dictionary(Of String, MemoryStream)
            Call CopyFrom(CaveRegisterData)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, CaveRegisterSetting As cCaveRegisterSetting, CaveID As String, Name As String)
            oSurvey = Survey
            oData = New XmlDocument
            oStructure = New XmlDocument
            oFiles = New Dictionary(Of String, MemoryStream)

            sCaveID = CaveID
            sName = Name
            sSettingID = CaveRegisterSetting.ID
            oSetting = CaveRegisterSetting

            bHasData = False
        End Sub

        Public Sub [Get]()
            Try
                Dim oNetCaveRegister As cNetCaveRegister = New cNetCaveRegister(oSetting.URL)
                If oNetCaveRegister.Login(oSetting.Username, oSetting.Password) Then
                    Call oNetCaveRegister.Get(sCaveID, oData, oStructure)
                    bHasData = True
                End If
            Catch ex As Exception
            End Try
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As Storage.cFile, ByVal CaveRegisterData As XmlElement)
            oSurvey = Survey
            oData = New XmlDocument
            oStructure = New XmlDocument
            oFiles = New Dictionary(Of String, MemoryStream)

            sCaveID = CaveRegisterData.GetAttribute("caveid")
            sName = CaveRegisterData.GetAttribute("name")
            sSettingID = CaveRegisterData.GetAttribute("settingid")
            bHasData = modXML.GetAttributeValue(CaveRegisterData, "hasdata", 0)
            If bHasData Then
                Dim sBasePath As String = "_data\caveregister\" & sCaveID
                Call oData.Load(DirectCast(File.Data(sBasePath & "\data.xml"), Storage.cStorageItemFile).Stream)
                Call oStructure.Load(DirectCast(File.Data(sBasePath & "\structure.xml"), Storage.cStorageItemFile).Stream)
                For Each oStorageFile As Storage.cStorageItemFile In File.Data.GetFiles(sBasePath & "\files")
                    Dim oStream As MemoryStream = New MemoryStream()
                    oStorageFile.Stream.Position = 0
                    Call oStorageFile.Stream.CopyTo(oStream)
                    Call oFiles.Add(Path.GetFileName(oStorageFile.Name), oStream)
                Next
            End If
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim sBasePath As String = "_data\caveregister\" & sCaveID
            Dim oXmlCaveRegisterData As XmlElement = Document.CreateElement("caveregisterdata")
            Call oXmlCaveRegisterData.SetAttribute("caveid", sCaveID)
            Call oXmlCaveRegisterData.SetAttribute("name", sName)
            Call oXmlCaveRegisterData.SetAttribute("settingid", sSettingID)
            If bHasData Then
                Call oXmlCaveRegisterData.SetAttribute("hasdata", "1")
                Dim oDataFile As cStorageItemFile = File.Data.AddFile(sBasePath & "\data.xml")
                Call oData.Save(oDataFile.Stream)
                Dim oStructureFile As cStorageItemFile = File.Data.AddFile(sBasePath & "\structure.xml")
                Call oStructure.Save(oStructureFile.Stream)
                For Each sFilename As String In oFiles.Keys
                    Dim oStream As MemoryStream = oFiles(sFilename)
                    Dim oStreamFile As cStorageItemFile = File.Data.AddFile(sBasePath & "\files\" & sFilename)
                    oStream.Position = 0
                    Call oStream.CopyTo(oStreamFile.Stream)
                Next
            End If
            Call Parent.AppendChild(oXmlCaveRegisterData)
            Return oXmlCaveRegisterData
        End Function
    End Class
End Namespace
