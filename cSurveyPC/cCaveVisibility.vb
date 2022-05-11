Imports System.Xml
Imports cSurveyPC.cSurvey.Design

Namespace cSurvey
    Public Class cCaveVisibilityProfiles
        Implements IEnumerable
        Private oSurvey As cSurvey

        Private oColl As Dictionary(Of String, cCaveVisibilityProfile)

        Private oDefaultProfile As cCaveVisibileDefaultProfile

        Public Sub Clear()
            Call oColl.Clear()
        End Sub

        Friend Sub CopyFrom(CaveVisibilityProfiles As cCaveVisibilityProfiles)
            Call oColl.Clear()
            For Each oCaveVisibilityProfile As cCaveVisibilityProfile In CaveVisibilityProfiles
                Dim oCopiedCaveVisibilityProfile As cCaveVisibilityProfile = New cCaveVisibilityProfile(oSurvey, oCaveVisibilityProfile.Name)
                Call oCopiedCaveVisibilityProfile.CopyFrom(oCaveVisibilityProfile)
                Call oColl.Add(oCopiedCaveVisibilityProfile.Name.ToLower, oCopiedCaveVisibilityProfile)
            Next
        End Sub

        Public Function Contains(Name As String) As Boolean
            Return oColl.ContainsKey(Name)
        End Function

        Public Function Contains(CaveVisibilityProfile As cCaveVisibilityProfile) As Boolean
            Return oColl.ContainsValue(CaveVisibilityProfile)
        End Function

        Public Sub Import(ByVal CaveVisibilityProfiles As XmlElement)
            Call oColl.Clear()
            For Each oXMLCaveVisiblityProfile As XmlElement In CaveVisibilityProfiles.ChildNodes
                Dim oCaveVisibilityProfile As cCaveVisibilityProfile = New cCaveVisibilityProfile(oSurvey, oXMLCaveVisiblityProfile)
                Call oColl.Add(oCaveVisibilityProfile.Name.ToLower, oCaveVisibilityProfile)
            Next
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal CaveVisibilityProfiles As XmlElement)
            oSurvey = Survey
            oDefaultProfile = New cCaveVisibileDefaultProfile(oSurvey, "")
            oColl = New Dictionary(Of String, cCaveVisibilityProfile)
            For Each oXMLCaveVisiblityProfile As XmlElement In CaveVisibilityProfiles.ChildNodes
                Dim oCaveVisibilityProfile As cCaveVisibilityProfile = New cCaveVisibilityProfile(oSurvey, oXMLCaveVisiblityProfile)
                Call oColl.Add(oCaveVisibilityProfile.Name.ToLower, oCaveVisibilityProfile)
            Next
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oDefaultProfile = New cCaveVisibileDefaultProfile(oSurvey, "")
            oColl = New Dictionary(Of String, cCaveVisibilityProfile)
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oColl.Values.GetEnumerator
        End Function

        Public Sub Remove(Name As String)
            Dim sName As String = Name.ToLower
            If oColl.ContainsKey(sName) Then
                Call oColl.Remove(sName)
            End If
        End Sub

        Public Sub Remove(CaveVisibilityProfile As cCaveVisibilityProfile)
            If oColl.ContainsValue(CaveVisibilityProfile) Then
                Call oColl.Remove(CaveVisibilityProfile.Name.ToLower)
            End If
        End Sub

        Public Function Add(Name As String) As cCaveVisibilityProfile
            Dim sName As String = Name.ToLower
            If Not oColl.ContainsKey(sName) Then
                Dim oCaveVisibilityProfile As cCaveVisibilityProfile = New cCaveVisibilityProfile(oSurvey, Name)
                Call oColl.Add(sName, oCaveVisibilityProfile)
                Return oCaveVisibilityProfile
            Else
                Return Nothing
            End If
        End Function

        Public Function AddAsCopy(SourceName As String, Name As String) As cCaveVisibilityProfile
            Dim sName As String = Name.ToLower
            Dim sSourceName As String = SourceName.ToLower
            If Not oColl.ContainsKey(sName) And oColl.ContainsKey(sSourceName) Then
                Dim oCaveVisibilityProfile As cCaveVisibilityProfile = New cCaveVisibilityProfile(oSurvey, sName)
                Call oColl.Add(sName, oCaveVisibilityProfile)
                Call oCaveVisibilityProfile.CopyFrom(oColl(sSourceName))
                Return oCaveVisibilityProfile
            Else
                Return Nothing
            End If
        End Function

        Default Public ReadOnly Property Item(Name As String) As cCaveVisibilityProfile
            Get
                Dim sName As String = Name.ToLower
                If oColl.ContainsKey(sName) Then
                    Return oColl(sName)
                Else
                    Return oDefaultProfile
                End If
            End Get
        End Property

        Public ReadOnly Property DefaultProfile As cCaveVisibilityProfile
            Get
                Return oDefaultProfile
            End Get
        End Property

        Public Sub Rebind()
            For Each oCaveVisibilityProfile In oColl.Values
                Call oCaveVisibilityProfile.rebind()
            Next
        End Sub

        Public Function GetSegmentsQuery(Name As String) As String
            Dim sName As String = Name.ToLower
            If oColl.ContainsKey(sName) Then
                Return oColl(sName).SegmentsQuery
            Else
                Return ""
            End If
        End Function

        Public Function GetItemsQuery(Name As String) As String
            Dim sName As String = Name.ToLower
            If oColl.ContainsKey(sName) Then
                Return oColl(sName).ItemsQuery
            Else
                Return ""
            End If
        End Function

        Public Function GetVisible(Name As String, CaveInfo As cCaveInfo) As Boolean
            Dim sName As String = Name.ToLower
            If oColl.ContainsKey(sName) Then
                Return oColl(sName).GetVisible(CaveInfo)
            Else
                Return True
            End If
        End Function

        Public Function GetVisible(Name As String, CaveInfoBranch As cCaveInfoBranch) As Boolean
            Dim sName As String = Name.ToLower
            If oColl.ContainsKey(sName) Then
                Return oColl(sName).GetVisible(CaveInfoBranch)
            Else
                Return True
            End If
        End Function

        Public Function GetVisible(Name As String, CaveInfo As String, CaveInfoBranch As String) As Boolean
            Dim sName As String = Name.ToLower
            If oColl.ContainsKey(sName) Then
                Return oColl(sName).GetVisible("" & CaveInfo, "" & CaveInfoBranch)
            Else
                Return True
            End If
        End Function

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlCaveVisibilityProfiles As XmlElement = Document.CreateElement("cavevisibilityprofiles")
            For Each oCaveVisibilityProfile As cCaveVisibilityProfile In oColl.Values
                Call oCaveVisibilityProfile.SaveTo(File, Document, oXmlCaveVisibilityProfiles)
            Next
            Call Parent.AppendChild(oXmlCaveVisibilityProfiles)
            Return oXmlCaveVisibilityProfiles
        End Function
    End Class

    Public Class cCaveVisibileDefaultProfile
        Inherits cCaveVisibilityProfile

        Friend Sub New(ByVal Survey As cSurvey, Name As String)
            Call MyBase.new(Survey, Name)
        End Sub

        Public Overrides Function GetVisible(CaveInfo As cCaveInfo) As Boolean
            Return True
        End Function

        Public Overrides Function GetVisible(CaveInfoBranch As cCaveInfoBranch) As Boolean
            Return True
        End Function

        Public Overrides Function GetVisible(CaveInfo As String, CaveInfoBranch As String) As Boolean
            Return True
        End Function

        Public Overrides Sub SetVisible(CaveInfo As cCaveInfo, Visible As Boolean)
            'nulla
        End Sub

        Public Overrides Sub SetVisible(CaveInfoBranch As cCaveInfoBranch, Visible As Boolean)
            'nulla
        End Sub

        Public Overrides Sub SetVisible(CaveInfo As String, CaveInfoBranch As String, Visible As Boolean)
            'nulla
        End Sub

        Public Overrides ReadOnly Property IsDefault As Boolean
            Get
                Return True
            End Get
        End Property

        Friend Overrides Sub Rebind()
            'nulla
        End Sub
    End Class

    Public Class cCaveVisibilityProfile
        Implements IEnumerable
        Private oSurvey As cSurvey

        Private sName As String
        Private oColl As List(Of String)

        Private sSegmentsQuery As String
        Private sItemsQuery As String

        Public Property SegmentsQuery As String
            Get
                Return sSegmentsQuery
            End Get
            Set(value As String)
                sSegmentsQuery = value
            End Set
        End Property

        Public Property ItemsQuery As String
            Get
                Return sItemsQuery
            End Get
            Set(value As String)
                sItemsQuery = value
            End Set
        End Property

        Friend Sub CopyFrom(CaveVisibilityProfile As cCaveVisibilityProfile)
            Call oColl.Clear()
            For Each sKey As String In CaveVisibilityProfile
                Call oColl.Add(sKey)
            Next
            sSegmentsQuery = CaveVisibilityProfile.SegmentsQuery
            sItemsQuery = CaveVisibilityProfile.ItemsQuery
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, Name As String)
            oSurvey = Survey
            sName = Name
            oColl = New List(Of String)
        End Sub

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public Overridable ReadOnly Property IsDefault As Boolean
            Get
                Return False
            End Get
        End Property

        Friend Overridable Sub Rebind()
            Dim oCheckColl As List(Of String) = New List(Of String)
            Dim sKey As String
            For Each oCaveInfo As cCaveInfo In oSurvey.Properties.CaveInfos
                sKey = oCaveInfo.Name.ToLower & "|"
                Call oCheckColl.Add(sKey)
                For Each oCaveInfoBranch As cCaveInfoBranch In oCaveInfo.Branches.GetAllBranches.Values
                    sKey = oCaveInfo.Name.ToLower & "|" & oCaveInfoBranch.Name.ToLower
                    Call oCheckColl.Add(sKey)
                Next
            Next
            Dim oKeysToDelete As List(Of String) = New List(Of String)
            For Each sKey In oColl
                If Not oCheckColl.Contains(sKey) Then
                    Call oKeysToDelete.Add(sKey)
                End If
            Next
            For Each sKey In oKeysToDelete
                Call oCheckColl.Remove(sKey)
            Next
        End Sub

        Public Overridable Sub SetVisible(CaveInfo As cCaveInfo, Visible As Boolean)
            Call SetVisible(CaveInfo.Name, "", Visible)
        End Sub

        Public Overridable Sub SetVisible(CaveInfoBranch As cCaveInfoBranch, Visible As Boolean)
            Call SetVisible(CaveInfoBranch.Cave, CaveInfoBranch.Path, Visible)
        End Sub

        Public Overridable Sub SetVisible(CaveInfo As String, CaveInfoBranch As String, Visible As Boolean)
            Dim sCaveInfo As String = CaveInfo.ToLower
            Dim sCaveInfoBranch As String = CaveInfoBranch.ToLower
            Dim sKey As String = sCaveInfo & "|" & sCaveInfoBranch
            If Visible Then
                Call oColl.Remove(sKey)
            Else
                If Not oColl.Contains(sKey) Then
                    Call oColl.Add(sKey)
                End If
            End If
        End Sub

        Public Overridable Function GetVisible(CaveInfo As cCaveInfo) As Boolean
            Return GetVisible(CaveInfo.Name, "")
        End Function

        Public Overridable Function GetVisible(CaveInfoBranch As cCaveInfoBranch) As Boolean
            Return GetVisible(CaveInfoBranch.Cave, CaveInfoBranch.Path)
        End Function

        Public Overridable Function GetVisible(CaveInfo As String, CaveInfoBranch As String) As Boolean
            Dim sCaveInfo As String = CaveInfo.ToLower
            Dim sCaveInfoBranch As String = CaveInfoBranch.ToLower
            Dim sKey As String = sCaveInfo & "|" & sCaveInfoBranch
            If oColl.Contains(sKey) Then
                Return False
            Else
                Return True
            End If
        End Function

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oColl.GetEnumerator
        End Function

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement)
            Dim oXmlCaveVisibilityProfile As XmlElement = Document.CreateElement("cavevisibilityprofile")
            Call oXmlCaveVisibilityProfile.SetAttribute("name", sName)
            If sSegmentsQuery <> "" Then Call oXmlCaveVisibilityProfile.SetAttribute("segmentsquery", sSegmentsQuery)
            If sItemsQuery <> "" Then Call oXmlCaveVisibilityProfile.SetAttribute("itemsquery", sItemsQuery)
            Dim sKeys As String = Strings.Join(oColl.ToArray, ";")
            Call oXmlCaveVisibilityProfile.SetAttribute("keys", sKeys)
            Call Parent.AppendChild(oXmlCaveVisibilityProfile)
            Return oXmlCaveVisibilityProfile
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal CaveVisibilityProfile As XmlElement)
            oSurvey = Survey
            sName = CaveVisibilityProfile.GetAttribute("name")
            Try : sSegmentsQuery = CaveVisibilityProfile.GetAttribute("segmentsquery") : Catch : End Try
            Try : sItemsQuery = CaveVisibilityProfile.GetAttribute("itemsquery") : Catch : End Try
            Dim sKeys() As String = CaveVisibilityProfile.GetAttribute("keys").Split(";")
            oColl = New List(Of String)(sKeys)
        End Sub
    End Class
End Namespace
