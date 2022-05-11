Imports System.Xml
Imports cSurveyPC.cSurvey.Design

Namespace cSurvey
    Public Class cCaveInfoBranches
        Implements IEnumerable

        Public Const sBranchSeparator As Char = "\"

        Private oSurvey As cSurvey
        Private sCave As String
        Private oParent As cCaveInfoBranch

        Private oCaveInfo As cCaveInfo
        Private oBranches As Dictionary(Of String, cCaveInfoBranch)

        Public Function GetUniqueName(Basename As String) As String
            Dim iindex As Integer = 1
            Dim sBasename As String = Basename
            Dim sUniqueName As String = sBasename
            Do While oBranches.ContainsKey(sUniqueName)
                sUniqueName = sBasename & "_" & iindex
                iindex += 1
            Loop
            Return sUniqueName
        End Function

        Public Sub Clear()
            Call oBranches.Clear()
        End Sub

        Private Sub pGetAllBranches(Branches As cCaveInfoBranches, AllBranches As SortedDictionary(Of String, cCaveInfoBranch), Recursive As Boolean)
            For Each oBranch As cCaveInfoBranch In Branches
                Call AllBranches.Add(oBranch.Path, oBranch)
                If Recursive Then
                    Call pGetAllBranches(oBranch.Branches, AllBranches, Recursive)
                End If
            Next
        End Sub

        Public Function GetAllBranches(Optional Recursive As Boolean = True) As SortedDictionary(Of String, cCaveInfoBranch)
            Dim oAllBranches As SortedDictionary(Of String, cCaveInfoBranch) = New SortedDictionary(Of String, cCaveInfoBranch)(StringComparer.CurrentCultureIgnoreCase)
            Call pGetAllBranches(Me, oAllBranches, Recursive)
            Return oAllBranches
        End Function

        Public Function GetAllBranchesWithEmpty(Optional Recursive As Boolean = True) As SortedDictionary(Of String, cCaveInfoBranch)
            Dim oAllBranches As SortedDictionary(Of String, cCaveInfoBranch) = New SortedDictionary(Of String, cCaveInfoBranch)(StringComparer.CurrentCultureIgnoreCase)
            Call pGetAllBranches(Me, oAllBranches, Recursive)
            Dim oCaveInfoBranch As cCaveInfoBranch = GetEmptyCaveInfoBranch()
            Call oAllBranches.Add("", oCaveInfoBranch)
            Return oAllBranches
        End Function

        Public Function GetWithEmpty() As SortedDictionary(Of String, cCaveInfoBranch)
            Dim oCaveInfosWithEmpty As SortedDictionary(Of String, cCaveInfoBranch) = New SortedDictionary(Of String, cCaveInfoBranch)(oBranches, StringComparer.CurrentCultureIgnoreCase)
            Dim oCaveInfoBranch As cCaveInfoBranch = GetEmptyCaveInfoBranch()
            Call oCaveInfosWithEmpty.Add("", oCaveInfoBranch)
            Return oCaveInfosWithEmpty
        End Function

        Friend Function GetEmptyCaveInfoBranch(Optional ByVal Name As String = "") As cCaveInfoBranch
            Return New cCaveInfoBranch(oSurvey, sCave, oCaveInfo, oParent, Name)
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Cave As String, CaveInfo As cCaveInfo, Parent As cCaveInfoBranch)
            oSurvey = Survey
            sCave = Cave
            oCaveInfo = CaveInfo
            oParent = Parent
            oBranches = New Dictionary(Of String, cCaveInfoBranch)(StringComparer.CurrentCultureIgnoreCase)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Cave As String, CaveInfo As cCaveInfo, Parent As cCaveInfoBranch, ByVal CaveInfoBranches As XmlElement)
            oSurvey = Survey
            sCave = Cave
            oCaveInfo = CaveInfo
            oParent = Parent
            oBranches = New Dictionary(Of String, cCaveInfoBranch)(StringComparer.CurrentCultureIgnoreCase)
            For Each oXmlBranch As XmlElement In CaveInfoBranches.ChildNodes
                Dim oBranch As cCaveInfoBranch = New cCaveInfoBranch(oSurvey, sCave, oCaveInfo, oParent, oXmlBranch)
                Dim sName As String = oBranch.Name.ToLower
                Call oBranches.Add(sName, oBranch)
            Next
        End Sub

        Public ReadOnly Property Cave As String
            Get
                Return sCave
            End Get
        End Property

        Friend Sub SetCave(ByVal Cave As String)
            sCave = Cave
            For Each oBranch As cCaveInfoBranch In oBranches.Values
                Call oBranch.SetCaveName(sCave)
            Next
        End Sub

        Public ReadOnly Property Count() As Integer
            Get
                Return oBranches.Count
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal Path As String) As cCaveInfoBranch
            Get
                'Try
                Dim sPath As String = Path.ToLower
                Dim sName As String
                If sPath.Contains(sBranchSeparator) Then
                    Dim iSeparatorPos As Integer = sPath.IndexOf(sBranchSeparator)
                    sName = sPath.Substring(0, iSeparatorPos)
                    sPath = sPath.Substring(iSeparatorPos + 1)
                Else
                    sName = sPath
                    sPath = ""
                End If
                If oBranches.ContainsKey(sName) Then
                    If sPath = "" Then
                        Return oBranches(sName)
                    Else
                        Return oBranches(sName).Branches(sPath)
                    End If
                Else
                    Return Nothing
                End If
                'Catch
                '    Return Nothing
                'End Try
            End Get
        End Property

        Public Function Add(ByVal Name As String) As cCaveInfoBranch
            If Name <> "" Then
                Dim sName As String = Name.ToLower
                If Not oBranches.ContainsKey(sName) Then
                    Dim oBranch As cCaveInfoBranch = New cCaveInfoBranch(oSurvey, sCave, oCaveInfo, oParent, Name)
                    Call oBranches.Add(sName, oBranch)
                    Return oBranch
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        End Function

        Public Function Contains(ByVal Path As String)
            Dim sPath As String = Path.ToLower
            Dim sName As String
            If sPath.Contains(sBranchSeparator) Then
                Dim iSeparatorPos As Integer = sPath.IndexOf(sBranchSeparator)
                sName = sPath.Substring(0, iSeparatorPos)
                sPath = sPath.Substring(iSeparatorPos + 1)
            Else
                sName = sPath
                sPath = ""
            End If
            If oBranches.ContainsKey(sName) Then
                If sPath = "" Then
                    Return True
                Else
                    Return oBranches(sName).Branches.Contains(sPath)
                End If
            Else
                Return False
            End If
        End Function

        Public Function Contains(ByVal Item As cCaveInfoBranch, Optional LookInChild As Boolean = False)
            If LookInChild Then
                If oBranches.ContainsValue(Item) Then
                    Return True
                Else
                    For Each oBranch As cCaveInfoBranch In oBranches.Values
                        Dim bContains As Boolean = oBranch.Branches.Contains(Item, True)
                        If bContains Then
                            Return True
                        End If
                    Next
                    Return False
                End If
            Else
                Return oBranches.ContainsValue(Item)
            End If
        End Function

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oBranches.Values.GetEnumerator
        End Function

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlBranches As XmlElement = Document.CreateElement("branches")
            For Each oBranch As cCaveInfoBranch In oBranches.Values
                Call oBranch.SaveTo(File, Document, oXmlBranches)
            Next
            Call Parent.AppendChild(oXmlBranches)
            Return oXmlBranches
        End Function

        Public Function Rename(ByVal CaveInfoBranch As cCaveInfoBranch, ByVal NewName As String, Optional ByVal CheckBindings As Boolean = True) As Boolean
            If oBranches.ContainsValue(CaveInfoBranch) Then
                Call Rename(CaveInfoBranch.Name, NewName, CheckBindings)
            Else
                Return False
            End If
        End Function

        Public Function Rename(ByVal Name As String, ByVal NewName As String, Optional ByVal CheckBindings As Boolean = True) As Boolean
            Dim sName As String = Name.ToLower
            Dim sNewName As String = NewName.ToLower
            If oBranches.ContainsKey(sName) And Not oBranches.ContainsKey(sNewName) Then
                Dim oBranch As cCaveInfoBranch = oBranches(sName)
                Dim sPath As String = oBranch.Path '(cCaveInfoBranch.PathDirectionEnum.ParentToChild)
                Call oBranches.Remove(sName)
                Call oBranch.SetName(NewName)
                Dim sNewPath As String = oBranch.Path '(cCaveInfoBranch.PathDirectionEnum.ParentToChild)
                Call oBranches.Add(sNewName, oBranch)
                If CheckBindings Then
                    Call cCaveInfos.CheckBindings(oSurvey, sCave, sPath, sCave, sNewPath)
                End If
                Return True
            Else
                Return False
            End If
        End Function

        Public Sub Remove(ByVal Name As String, Optional ByVal CheckBindings As Boolean = True)
            Try
                Dim sName As String = Name.ToLower
                Call oBranches.Remove(sName)
                If CheckBindings Then
                    For Each oSegment As cSegment In oSurvey.Segments
                        If oSegment.Cave.ToLower = sCave.ToLower Then
                            If oSegment.Branch.ToLower = sName Then Call oSegment.RenameCave(sCave, "")
                        End If
                    Next
                    For Each oLayer As cLayer In oSurvey.Plan.Layers
                        For Each oItem As cItem In oLayer.Items
                            If oItem.Cave.ToLower = sCave.ToLower Then
                                If oItem.Branch.ToLower = sName Then Call oItem.RenameCave(sCave, "")
                            End If
                        Next
                    Next
                End If
            Catch
            End Try
        End Sub
    End Class
End Namespace

