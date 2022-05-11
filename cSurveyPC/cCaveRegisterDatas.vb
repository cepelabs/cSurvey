Imports cSurveyPC.cSurvey
Imports System.Xml
Imports System.IO
Imports cSurveyPC.cSurvey.Storage

Namespace cSurvey.CaveRegister
    Public Class cCaveRegisterDatas
        Implements IEnumerable

        Private oSurvey As cSurvey
        Private oItems As Dictionary(Of String, cCaveRegisterData)

        Public Function Add(CaveRegisterSetting As cCaveRegisterSetting, CaveID As String, Name As String) As cCaveRegisterData
            If oItems.ContainsKey(CaveID) Then
                Return Nothing
            Else
                Dim oItem As cCaveRegisterData = New cCaveRegisterData(oSurvey, CaveRegisterSetting, CaveID, Name)
                Call oItems.Add(CaveID, oItem)
                Return oItem
            End If
        End Function

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Default Public ReadOnly Property Items(CaveID As String) As cCaveRegisterData
            Get
                If oItems.ContainsKey(CaveID) Then
                    Return oItems(CaveID)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Sub Remove(CaveID As String)
            If oItems.ContainsKey(CaveID) Then
                Call oItems.Remove(CaveID)
            End If
        End Sub

        Public Sub Clear()
            Call oItems.Clear()
        End Sub

        Public Sub New(Survey As cSurvey)
            oSurvey = Survey
            oItems = New Dictionary(Of String, cCaveRegisterData)(System.StringComparer.OrdinalIgnoreCase)
        End Sub

        Friend Sub New(Survey As cSurvey, ByVal File As cFile, ByVal CaveRegisterDatas As XmlElement)
            oSurvey = Survey
            oItems = New Dictionary(Of String, cCaveRegisterData)(System.StringComparer.OrdinalIgnoreCase)
            For Each oXMLItem As XmlElement In CaveRegisterDatas.ChildNodes
                Dim oItem As cCaveRegisterData = New cCaveRegisterData(oSurvey, File, oXMLItem)
                Call oItems.Add(oItem.CaveID, oItem)
            Next
        End Sub

        Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlCaveRegisterDatas As XmlElement = Document.CreateElement("caveregisterdatas")
            For Each oItem As cCaveRegisterData In oItems.Values
                Call oItem.SaveTo(File, Document, oXmlCaveRegisterDatas)
            Next
            Call Parent.AppendChild(oXmlCaveRegisterDatas)
            Return oXmlCaveRegisterDatas
        End Function

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function

        Public Function Contains(Data As cCaveRegisterData) As Boolean
            Return oItems.ContainsValue(Data)
        End Function

        Public Function Contains(CaveID As String) As Boolean
            Return oItems.ContainsKey(CaveID)
        End Function
    End Class
End Namespace