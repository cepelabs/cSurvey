Imports cSurveyPC.cSurvey
Imports System.Xml
Imports System.IO
Imports cSurveyPC.cSurvey.Storage
Imports cSurveyPC.cSurvey.Net

Namespace cSurvey.CaveRegister
    Public Class cCaveRegister
        Private oSurvey As cSurvey

        Private oDatas As cCaveRegisterDatas
        Private oSettings As cCaveRegisterSettings

        Public ReadOnly Property Datas() As cCaveRegisterDatas
            Get
                Return oDatas
            End Get
        End Property

        Public ReadOnly Property Settings() As cCaveRegisterSettings
            Get
                Return oSettings
            End Get
        End Property

        Friend Sub New(Survey As cSurvey)
            oSurvey = Survey
            oDatas = New cCaveRegisterDatas(oSurvey)
            oSettings = New cCaveRegisterSettings(oSurvey)
        End Sub

        Friend Sub New(Survey As cSurvey, ByVal File As cFile, ByVal CaveRegister As XmlElement)
            oSurvey = Survey
            oDatas = New cCaveRegisterDatas(Survey, File, CaveRegister.Item("caveregisterdatas"))
            oSettings = New cCaveRegisterSettings(Survey, File, CaveRegister.Item("caveregistersettings"))
        End Sub

        Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlCaveRegister As XmlElement = Document.CreateElement("caveregister")
            Call oDatas.SaveTo(File, Document, oXmlCaveRegister)
            Call oSettings.SaveTo(File, Document, oXmlCaveRegister)
            Call Parent.AppendChild(oXmlCaveRegister)
            Return oXmlCaveRegister
        End Function

        Friend Function GetDataName(Setting As cCaveRegisterSetting, CaveID As String) As String
            Try
                Dim oNetCaveRegister As cNetCaveRegister = New cNetCaveRegister(Setting.URL)
                If oNetCaveRegister.Login(Setting.Username, Setting.Password) Then
                    Dim oData As XmlDocument = New XmlDocument
                    Dim oStructure As XmlDocument = New XmlDocument
                    Call oNetCaveRegister.Get(CaveID, oData, oStructure)
                    Return oData.DocumentElement.GetAttribute("name")
                Else
                    Return ""
                End If
            Catch ex As Exception
                Return ""
            End Try
        End Function

        Friend Function GetCaveIDs(Optional All As Boolean = True) As List(Of String)
            Dim oIDs As List(Of String) = New List(Of String)
            If All Then
                If oSurvey.Properties.ID <> "" Then oIDs.Add(oSurvey.Properties.ID)
                For Each oCaveInfo As cCaveInfo In oSurvey.Properties.CaveInfos
                    If oCaveInfo.ID <> "" AndAlso Not oIDs.Contains(oCaveInfo.ID) Then oIDs.Add(oCaveInfo.ID)
                Next
            Else
                If oSurvey.Properties.ID <> "" AndAlso Not oSurvey.CaveRegister.Datas.Contains(oSurvey.Properties.ID) Then oIDs.Add(oSurvey.Properties.ID)
                For Each oCaveInfo As cCaveInfo In oSurvey.Properties.CaveInfos
                    If oCaveInfo.ID <> "" AndAlso Not oIDs.Contains(oCaveInfo.ID) AndAlso Not oSurvey.CaveRegister.Datas.Contains(oCaveInfo.ID) Then oIDs.Add(oCaveInfo.ID)
                Next
            End If
            Return oIDs
        End Function

    End Class
End Namespace