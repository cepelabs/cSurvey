Imports cSurveyPC.cSurvey
Imports System.Xml
Imports System.IO
Imports cSurveyPC.cSurvey.Storage

Namespace cSurvey.CaveRegister
    Public Class cCaveRegisterSettings
        Implements IEnumerable

        Private oSurvey As cSurvey
        Private oItems As Dictionary(Of String, cICaveRegisterSetting)

        Public Function Contains(ID As String) As Boolean
            Return oItems.ContainsKey(ID)
        End Function

        Public Function Contains(Item As cICaveRegisterSetting) As Boolean
            Return oItems.ContainsValue(Item)
        End Function

        Public Function Append(Item As cICaveRegisterSetting) As Boolean
            If oItems.ContainsKey(Item.ID) Then
                Return False
            Else
                Call oItems.Add(Item.ID, Item)
                Return True
            End If
        End Function

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Default Public ReadOnly Property Items(ID As String) As cICaveRegisterSetting
            Get
                If oItems.ContainsKey(ID) Then
                    Return oItems(ID)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Function Remove(Item As cICaveRegisterSetting) As Boolean
            If oItems.ContainsValue(Item) Then
                If Not Item.IsInUse Then
                    Call oItems.Remove(Item.ID)
                    Return True
                End If
            End If
        End Function

        Public Function Remove(ID As String) As Boolean
            If oItems.ContainsKey(ID) Then
                If Not oItems(ID).IsInUse Then
                    Call oItems.Remove(ID)
                    Return True
                End If
            End If
            Return False
        End Function

        Friend Sub New(Survey As cSurvey)
            oSurvey = Survey
            oItems = New Dictionary(Of String, cICaveRegisterSetting)(System.StringComparer.OrdinalIgnoreCase)
        End Sub

        Friend Sub New(Survey As cSurvey, ByVal File As Storage.cFile, ByVal CaveRegisterSettings As XmlElement)
            oSurvey = Survey
            oItems = New Dictionary(Of String, cICaveRegisterSetting)(System.StringComparer.OrdinalIgnoreCase)
            For Each oXMLItem As XmlElement In CaveRegisterSettings.ChildNodes
                Dim oItem As cCaveRegisterSetting = New cCaveRegisterSetting(oSurvey, oXMLItem)
                Call oItems.Add(oItem.ID, oItem)
            Next
        End Sub

        Friend Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlCaveRegisterSettings As XmlElement = Document.CreateElement("caveregistersettings")
            For Each oItem As cCaveRegisterSetting In oItems.Values
                Call oItem.SaveTo(File, Document, oXmlCaveRegisterSettings)
            Next
            Call Parent.AppendChild(oXmlCaveRegisterSettings)
            Return oXmlCaveRegisterSettings
        End Function

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function
    End Class
End Namespace