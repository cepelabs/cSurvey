Imports System.Xml
Imports cSurveyPC.cSurvey.Design

Namespace cSurvey
    Public Class cCaveInfos
        Implements IEnumerable
        Private oSurvey As cSurvey
        Private oCaveInfos As Dictionary(Of String, cCaveInfo)

        Friend Class cCaveAndBranch
            Private sCave As String
            Private sBranch As String

            Public ReadOnly Property Cave As String
                Get
                    Return sCave
                End Get
            End Property

            Public ReadOnly Property Branch As String
                Get
                    Return sBranch
                End Get
            End Property

            Friend Sub New(ByVal Cave As String, ByVal Branch As String)
                sCave = Cave
                sBranch = Branch
            End Sub
        End Class


        Public Function ByOrdinalPosition() As List(Of cCaveInfo)
            Return oCaveInfos.Values.OrderBy(Function(oItem) oItem.OrdinalPosition).ToList
        End Function

        Public Function GetUniqueName(Basename As String) As String
            Dim iindex As Integer = 1
            Dim sBasename As String = Basename
            Dim sUniqueName As String = sBasename
            Do While oCaveInfos.ContainsKey(sUniqueName)
                sUniqueName = sBasename & "_" & iindex
                iindex += 1
            Loop
            Return sUniqueName
        End Function

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oCaveInfos = New Dictionary(Of String, cCaveInfo)(StringComparer.CurrentCultureIgnoreCase)
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oCaveInfos.Values.GetEnumerator
        End Function

        Public ReadOnly Property Count() As Integer
            Get
                Return oCaveInfos.Count
            End Get
        End Property

        Public Function Rename(ByVal CaveInfo As cCaveInfo, ByVal NewName As String, Optional ByVal CheckBindings As Boolean = True) As Boolean
            If oCaveInfos.ContainsValue(CaveInfo) Then
                Call Rename(CaveInfo.Name, NewName, CheckBindings)
            Else
                Return False
            End If
        End Function

        'Public Function xMove(CaveInfo As cICaveInfoBranches, Parent As cICaveInfoBranches)
        '    If IsNothing(Parent) Then
        '        'branch to cave
        '    Else
        '        'cave/branch to branch
        '        If Not Parent.Branches.Contains(CaveInfo.Name) Then
        '            Dim oNewCaveInfo As cCaveInfoBranch = Parent.Branches.Add(CaveInfo.Name)
        '            Call oNewCaveInfo.MergeWith(CaveInfo)

        '        End If
        '    End If
        'End Function

        Friend Shared Sub CheckBindings(Survey As cSurvey, Cave As String, NewCave As String)
            For Each oSegment As cSegment In Survey.Segments
                If oSegment.Cave.ToLower = Cave.ToLower Then
                    Call oSegment.RenameCave(NewCave)
                End If
            Next
            For Each oItem As cItem In Survey.Plan.GetAllItems
                If oItem.Cave.ToLower = Cave.ToLower Then
                    Call oItem.RenameCave(NewCave)
                End If
            Next
            For Each oItem As cItem In Survey.Profile.GetAllItems
                If oItem.Cave.ToLower = Cave.ToLower Then
                    Call oItem.RenameCave(NewCave)
                End If
            Next
        End Sub

        Friend Shared Sub CheckBindings(Survey As cSurvey, Cave As String, Path As String, NewCave As String, NewPath As String)
            For Each oSegment As cSegment In Survey.Segments
                If oSegment.Cave.ToLower = Cave.ToLower Then
                    If Path = "" AndAlso oSegment.Branch = "" Then
                        Call oSegment.RenameCave(NewCave, NewPath)
                    ElseIf Path = "" AndAlso oSegment.Branch <> "" Then
                        Call oSegment.RenameCave(NewCave, NewPath & cCaveInfoBranches.sBranchSeparator & oSegment.Branch)
                    ElseIf oSegment.Branch.ToLower = Path.ToLower Then
                        Call oSegment.RenameCave(NewCave, NewPath)
                    ElseIf oSegment.Branch.ToLower.StartsWith(Path.ToLower & cCaveInfoBranches.sBranchSeparator) Then
                        Call oSegment.RenameCave(NewCave, oSegment.Branch.Replace(Path & cCaveInfoBranches.sBranchSeparator, NewPath & cCaveInfoBranches.sBranchSeparator))
                    End If
                End If
            Next
            For Each oItem As cItem In Survey.Plan.GetAllItems
                If oItem.Cave.ToLower = Cave.ToLower Then
                    If Path = "" AndAlso oItem.Branch = "" Then
                        Call oItem.RenameCave(NewCave, NewPath)
                    ElseIf Path = "" AndAlso oItem.Branch <> "" Then
                        Call oItem.RenameCave(NewCave, NewPath & cCaveInfoBranches.sBranchSeparator & oItem.Branch)
                    ElseIf oItem.Branch.ToLower = Path.ToLower Then
                        Call oItem.RenameCave(NewCave, NewPath)
                    ElseIf oItem.Branch.ToLower.StartsWith(Path.ToLower & cCaveInfoBranches.sBranchSeparator) Then
                        Call oItem.RenameCave(NewCave, oItem.Branch.Replace(Path & cCaveInfoBranches.sBranchSeparator, NewPath & cCaveInfoBranches.sBranchSeparator))
                    End If
                End If
            Next
            For Each oItem As cItem In Survey.Profile.GetAllItems
                If oItem.Cave.ToLower = Cave.ToLower Then
                    If Path = "" AndAlso oItem.Branch = "" Then
                        Call oItem.RenameCave(NewCave, NewPath)
                    ElseIf Path = "" AndAlso oItem.Branch <> "" Then
                        Call oItem.RenameCave(NewCave, NewPath & cCaveInfoBranches.sBranchSeparator & oItem.Branch)
                    ElseIf oItem.Branch.ToLower = Path.ToLower Then
                        Call oItem.RenameCave(NewCave, NewPath)
                    ElseIf oItem.Branch.ToLower.StartsWith(Path.ToLower & cCaveInfoBranches.sBranchSeparator) Then
                        Call oItem.RenameCave(NewCave, oItem.Branch.Replace(Path & cCaveInfoBranches.sBranchSeparator, NewPath & cCaveInfoBranches.sBranchSeparator))
                    End If
                End If
            Next
        End Sub

        Public Function Rename(ByVal Name As String, ByVal NewName As String, Optional ByVal CheckBindings As Boolean = True) As Boolean
            Dim sName As String = Name.ToLower
            Dim sNewName As String = NewName.ToLower
            If oCaveInfos.ContainsKey(sName) And Not oCaveInfos.ContainsKey(sNewName) Then
                Dim oCaveInfo As cCaveInfo = oCaveInfos(sName)
                Call oCaveInfos.Remove(sName)
                Call oCaveInfo.SetName(NewName)
                Call oCaveInfos.Add(sNewName, oCaveInfo)
                If CheckBindings Then
                    Call cCaveInfos.CheckBindings(oSurvey, sName, sNewName)
                End If
                Return True
            Else
                Return False
            End If
        End Function

        Default Public ReadOnly Property Item(ByVal Name As String) As cCaveInfo
            Get
                Dim sName As String = Name.ToLower
                If oCaveInfos.ContainsKey(sName) Then
                    Return oCaveInfos(sName)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Function Add(ByVal Name As String) As cCaveInfo
            If Name <> "" Then
                Dim sName As String = Name.ToLower
                If Not oCaveInfos.ContainsKey(sName) Then
                    Dim oCaveInfo As cCaveInfo = New cCaveInfo(oSurvey, Name)
                    Call oCaveInfos.Add(sName, oCaveInfo)
                    Return oCaveInfo
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        End Function

        Public Function Contains(Name As String, Path As String) As Boolean
            If Contains(Name) Then
                Return oCaveInfos(Name).Branches.Contains(Path)
            Else
                Return False
            End If
        End Function

        Public Function Contains(ByVal Name As String) As Boolean
            Dim sName As String = Name.ToLower
            Return oCaveInfos.ContainsKey(sName)
        End Function

        Public Function Contains(ByVal Item As cCaveInfo) As Boolean
            Return oCaveInfos.ContainsValue(Item)
        End Function

        Public Sub Remove(ByVal Name As String, Optional ByVal CheckBindings As Boolean = True)
            Dim sName As String = Name.ToLower
            If oCaveInfos.ContainsKey(sName) Then
                Call oCaveInfos.Remove(sName)
                If CheckBindings Then
                    For Each oSegment As cSegment In oSurvey.Segments
                        If oSegment.Cave.ToLower = sName Then Call oSegment.RenameCave("", "")
                    Next
                    For Each oLayer As cLayer In oSurvey.Plan.Layers
                        For Each oItem As cItem In oLayer.Items
                            If oItem.Cave.ToLower = sName Then Call oItem.RenameCave("", "")
                        Next
                    Next
                End If
            End If
        End Sub

        Friend Function GetEmptyCaveInfo(Optional ByVal Name As String = "") As cCaveInfo
            Return New cCaveInfo(oSurvey, Name)
        End Function

        Friend Function GetEmptyCaveInfoBranch(ByVal Cave As String, Optional ByVal Name As String = "") As cCaveInfoBranch
            Return New cCaveInfoBranch(oSurvey, Cave, Nothing, Nothing, Name)
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal CaveInfos As XmlElement)
            oSurvey = Survey
            oCaveInfos = New Dictionary(Of String, cCaveInfo)(StringComparer.CurrentCultureIgnoreCase)
            For Each oXmlCaveInfo As XmlElement In CaveInfos.ChildNodes
                Dim oCaveInfo As cCaveInfo = New cCaveInfo(oSurvey, oXmlCaveInfo)
                Dim sName As String = oCaveInfo.Name.ToLower
                Call oCaveInfos.Add(sName, oCaveInfo)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlCaveInfos As XmlElement = Document.CreateElement("caveinfos")
            For Each oCaveInfo As cCaveInfo In oCaveInfos.Values
                Call oCaveInfo.SaveTo(File, Document, oXmlCaveInfos)
            Next
            Call Parent.AppendChild(oXmlCaveInfos)
            Return oXmlCaveInfos
        End Function

        Friend Sub Clear()
            Call oCaveInfos.Clear()
        End Sub

        Public Function GetOriginColor(ByVal Segment As cISegment, ByVal DefaultColor As Color) As Color
            Return GetOriginColor(Segment.Cave, Segment.Branch, DefaultColor)
        End Function

        Public Function GetOriginColor(ByVal Cave As String, ByVal Branch As String, ByVal DefaultColor As Color) As Color
            Dim sCave As String = ("" & Cave).ToLower
            Dim sBranch As String = ("" & Branch).ToLower
            Dim oColor As Color = Color.Empty

            If sCave = "" Then
                Return DefaultColor
            Else
                If sBranch = "" Then
                    If oCaveInfos.ContainsKey(sCave) Then
                        Return oCaveInfos(sCave).GetOriginColor(DefaultColor)
                    Else
                        Return DefaultColor
                    End If
                Else
                    If oCaveInfos.ContainsKey(sCave) Then
                        If oCaveInfos(sCave).Branches.Contains(sBranch) Then
                            Return oCaveInfos(sCave).Branches(sBranch).GetOriginColor(DefaultColor)
                        Else
                            oColor = oCaveInfos(sCave).GetOriginColor(DefaultColor)
                        End If
                    Else
                        Return DefaultColor
                    End If
                End If
            End If
            Return oColor
        End Function

        Public Function GetColor(ByVal Item As Design.cItem, ByVal DefaultColor As Color) As Color
            Return GetColor(Item.Cave, Item.Branch, DefaultColor)
        End Function

        Public Function GetColor(ByVal Segment As cISegment, ByVal DefaultColor As Color) As Color
            Return GetColor(Segment.Cave, Segment.Branch, DefaultColor)
        End Function

        Public Function GetColor(ByVal Cave As String, ByVal Branch As String, ByVal DefaultColor As Color) As Color
            Dim sCave As String = ("" & Cave).ToLower
            Dim sBranch As String = ("" & Branch).ToLower
            Dim oColor As Color = Color.Empty

            If sCave = "" Then
                Return DefaultColor
            Else
                If sBranch = "" Then
                    If oCaveInfos.ContainsKey(sCave) Then
                        oColor = oCaveInfos(sCave).Color
                        If modPaint.IsNullColor(oColor) Then
                            Return DefaultColor
                        End If
                    Else
                        Return DefaultColor
                    End If
                Else
                    If oCaveInfos.ContainsKey(sCave) Then
                        If oCaveInfos(sCave).Branches.Contains(sBranch) Then
                            oColor = oCaveInfos(sCave).Branches(sBranch).GetColor(DefaultColor)
                            If modPaint.IsNullColor(oColor) Then
                                oColor = oCaveInfos(sCave).Color
                                If modPaint.IsNullColor(oColor) Then
                                    Return DefaultColor
                                End If
                            End If
                        Else
                            oColor = oCaveInfos(sCave).Color
                            If modPaint.IsNullColor(oColor) Then
                                Return DefaultColor
                            End If
                        End If
                    Else
                        Return DefaultColor
                    End If
                End If
            End If
            Return oColor
        End Function

        Public Function GetAllCaves() As SortedDictionary(Of String, cCaveInfo)
            Dim oAllCaves As SortedDictionary(Of String, cCaveInfo) = New SortedDictionary(Of String, cCaveInfo)(StringComparer.CurrentCultureIgnoreCase)
            For Each oCaveInfo As cCaveInfo In oCaveInfos.Values
                Call oAllCaves.Add(oCaveInfo.Name, oCaveInfo)
            Next
            Return oAllCaves
        End Function

        Public Function GetAll() As List(Of cICaveInfoBranches)
            Dim oAll As List(Of cICaveInfoBranches) = New List(Of cICaveInfoBranches)
            For Each oCaveInfo As cICaveInfoBranches In oCaveInfos.Values
                Call oAll.Add(oCaveInfo)
                Call oAll.AddRange(oCaveInfo.Branches.GetAllBranches.Values)
            Next
            Return oAll
        End Function

        Public Function GetAllWithEmpty() As List(Of cICaveInfoBranches)
            Dim oAll As List(Of cICaveInfoBranches) = New List(Of cICaveInfoBranches)
            For Each oCaveInfo As cICaveInfoBranches In GetWithEmpty.Values
                'Call oAll.Add(oCaveInfo)   'this is ambiguous...empty value and this are basically the same but empty branch is a branch...this is a cave...for not I don't add this...
                Call oAll.AddRange(oCaveInfo.Branches.GetAllBranchesWithEmpty.Values)
            Next
            Return oAll
        End Function

        Public Function GetWithEmpty() As SortedDictionary(Of String, cCaveInfo)
            Dim oCaveInfosWithEmpty As SortedDictionary(Of String, cCaveInfo) = New SortedDictionary(Of String, cCaveInfo)(oCaveInfos, StringComparer.CurrentCultureIgnoreCase)
            Dim oCaveInfo As cCaveInfo = GetEmptyCaveInfo()
            Call oCaveInfosWithEmpty.Add("", oCaveInfo)
            Return oCaveInfosWithEmpty
        End Function

        Public Function GetSurfaceProfileShow(ByVal Segment As cISegment) As Boolean
            Return GetSurfaceProfileShow(Segment.Cave, Segment.Branch)
        End Function

        Public Function GetSurfaceProfileShow(ByVal Cave As String, ByVal Branch As String) As Boolean
            Dim sCave As String = ("" & Cave).ToLower
            Dim sBranch As String = ("" & Branch).ToLower
            Dim oColor As Color = Color.Empty

            If sCave = "" Then
                Return oSurvey.Properties.SurfaceProfileShow
            Else
                If sBranch = "" Then
                    If oCaveInfos.ContainsKey(sCave) Then
                        Return oCaveInfos(sCave).GetSurfaceProfileShow
                    Else
                        Return oSurvey.Properties.SurfaceProfileShow
                    End If
                Else
                    If oCaveInfos.ContainsKey(sCave) Then
                        If oCaveInfos(sCave).Branches.Contains(sBranch) Then
                            Return oCaveInfos(sCave).Branches(sBranch).GetSurfaceProfileShow
                        Else
                            Return oCaveInfos(sCave).GetSurfaceProfileShow
                        End If
                    Else
                        Return oSurvey.Properties.SurfaceProfileShow
                    End If
                End If
            End If
        End Function
    End Class
End Namespace
