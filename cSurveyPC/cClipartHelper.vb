Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Drawings

Public Class cClipartHelper
    Private Shared oGalleries As Dictionary(Of String, List(Of cClipartPlaceholder))

    Public Shared Function GetGallery(Name As String) As List(Of cClipartPlaceholder)
        Dim sName As String = Name.ToLower
        If oGalleries Is Nothing Then
            oGalleries = New Dictionary(Of String, List(Of cClipartPlaceholder))
        End If
        If Not oGalleries.ContainsKey(sName) Then
            Call oGalleries.Add(sName, pLoadGallery(sName))
        End If
        Return oGalleries(sName)
    End Function

    Public Shared Function FindByAttribute(Gallery As List(Of cClipartPlaceholder), AttributeName As String, AttributeValue As String) As List(Of cClipartPlaceholder)
        Dim oResults As List(Of cClipartPlaceholder) = New List(Of cClipartPlaceholder)
        Dim sAttributeName As String = AttributeName.ToLower
        Dim sAttributeValue As String = AttributeValue.ToLower
        For Each oClipart As cClipartPlaceholder In Gallery
            For Each oKV As KeyValuePair(Of String, String) In oClipart.UserData
                If oKV.Key.ToLower = sAttributeName AndAlso oKV.Value = sAttributeValue Then
                    Call oResults.Add(oClipart)
                End If
            Next
        Next
        Return oResults
    End Function

    Private Shared Function pLoadGallery(Name As String) As List(Of cClipartPlaceholder)
        Dim sName As String = Name.ToLower
        Dim sPath As String = IO.Path.Combine(IO.Path.Combine(IO.Path.Combine(modMain.GetApplicationPath, "objects"), "cliparts"), sName)
        Dim oResults As List(Of cClipartPlaceholder) = New List(Of cClipartPlaceholder)
        For Each sFile As String In My.Computer.FileSystem.GetFiles(sPath, FileIO.SearchOption.SearchTopLevelOnly, "*.svg")
            Dim sFIlename As String = IO.Path.GetFileName(sFile)
            If Not sFIlename Like "_*" Then
                Dim oClipart As cClipartPlaceholder = New cClipartPlaceholder(sFile)
                Call oResults.Add(oClipart)
            End If
        Next
        Return oResults
    End Function
End Class
