Imports System.ComponentModel
Imports System.Xml
Imports cSurveyPC.cSurvey.cSegment

Namespace cSurvey
    Public Class cSegments
        Implements IEnumerable
        Implements cISegmentCollection

        Private oSurvey As cSurvey

        Private oSegments As cSegmentBaseCollection

        Private oTrigPoints As cTrigPoints

        Friend Class OnSegmentsEventArgs
            Inherits EventArgs
            Private oSegments As List(Of cSegment)
            Private oIndexes As List(Of Integer)

            Public ReadOnly Property Segments As List(Of cSegment)
                Get
                    Return oSegments
                End Get
            End Property

            Public ReadOnly Property Indexes As List(Of Integer)
                Get
                    Return oIndexes
                End Get
            End Property

            Friend Sub New(Segments As List(Of cSegment), Indexes As List(Of Integer))
                oSegments = Segments
                oIndexes = Indexes
            End Sub
        End Class

        Friend Class OnSegmentMoveEventArgs
            Inherits OnSegmentEventArgs

            Private iOldIndex As Integer

            Public ReadOnly Property OldIndex As Integer
                Get
                    Return iOldIndex
                End Get
            End Property

            Friend Sub New(ByVal Segment As cSegment, ByVal OldIndex As Integer, ByVal Index As Integer)
                MyBase.New(Segment, Index)
                iOldIndex = OldIndex
            End Sub
        End Class

        Friend Class OnSegmentEventArgs
            Inherits EventArgs
            Private oSegment As cSegment
            Private iIndex As Integer

            Public ReadOnly Property Segment() As cSegment
                Get
                    Return oSegment
                End Get
            End Property

            Public ReadOnly Property Index() As Integer
                Get
                    Return iIndex
                End Get
            End Property

            Friend Sub New(ByVal Segment As cSegment, ByVal Index As Integer)
                oSegment = Segment
                iIndex = Index
            End Sub
        End Class

        Friend Class OnSegmentLoadEventArgs
            Inherits OnSegmentEventArgs

            Private sText As String
            Private sProgress As Single

            Friend Sub New(ByVal Segment As cSegment, ByVal Index As Integer, ByVal Text As String, ByVal Progress As Single)
                Call MyBase.New(Segment, Index)
                sText = Text
                sProgress = Progress
            End Sub

            Public ReadOnly Property Text As String
                Get
                    Return sText
                End Get
            End Property

            Public ReadOnly Property Progress As Single
                Get
                    Return sProgress
                End Get
            End Property
        End Class

        Friend Event OnSegmentBeforeAppend(Sender As cSegments, ByVal e As OnSegmentEventArgs)
        Friend Event OnSegmentAppend(ByVal Sender As cSegments, ByVal e As OnSegmentEventArgs)
        Friend Event OnSegmentInsert(ByVal Sender As cSegments, ByVal e As OnSegmentEventArgs)
        Friend Event OnSegmentRemove(ByVal Sender As cSegments, ByVal e As OnSegmentEventArgs)
        Friend Event OnSegmentMove(ByVal Sender As cSegments, ByVal e As OnSegmentMoveEventArgs)
        Friend Event OnSegmentRemoveRange(ByVal Sender As cSegments, ByVal e As OnSegmentsEventArgs)
        Friend Event OnSegmentChange(ByVal Sender As cSegments, ByVal e As OnSegmentEventArgs)
        Friend Event OnSegmentChangeRange(ByVal Sender As cSegments, ByVal e As OnSegmentsEventArgs)
        Friend Event OnSegmentReassigned(ByVal Sender As cSegments, ByVal e As OnSegmentEventArgs)
        Friend Event OnSegmentSplayChange(ByVal Sender As cSegments, ByVal e As OnSegmentEventArgs)

        Friend Event OnClear(ByVal Sender As cSegments)

        Friend Event OnSegmentLoad(ByVal Sender As cSegments, ByVal e As OnSegmentLoadEventArgs)

        'Public Function GetPriorities() As List(Of Integer)
        '    Return oSegments.Cast(Of cSegment).Select(Function(segment) segment.Priority).Distinct.ToList
        'End Function

        'Public Function GetNewPriority() As Integer
        '    Return oSurvey.Calculate.GetNewPriority(oSegments.Cast(Of cSegment).ToList)
        'End Function

        Public Sub SaveAll(Optional RebindItem As Boolean = False)
            Dim oChangedIndexes As List(Of Integer) = New List(Of Integer)
            Dim oChangedSegments As List(Of cSegment) = oSegments.Where(Function(item) TypeOf item Is cSegment AndAlso DirectCast(item, cSegment).Changed).Cast(Of cSegment).ToList

            Dim oFirstChangedSegment As cSegment = Nothing
            For Each oSegment As cSegment In oSegments
                If oSegment.Changed Then
                    If oFirstChangedSegment Is Nothing Then oFirstChangedSegment = oSegment
                    Call oSegment.Save(RebindItem, cSegment.SaveOptionsEnum.EventRaisingDisable)
                    Call oChangedIndexes.Add(oSegment.Index)
                    Call oChangedSegments.Add(oSegment)
                End If
            Next
            If Not oFirstChangedSegment Is Nothing Then
                'RaiseEvent OnSegmentChange(Me, New OnSegmentEventArgs(oFirstChangedSegment, oFirstChangedSegment.Index))
                RaiseEvent OnSegmentChangeRange(Me, New OnSegmentsEventArgs(oChangedSegments, oChangedIndexes))
            End If
        End Sub

        Public Sub MoveTo(ByVal Index As Integer, ByVal Segment As cSegment)
            Try
                Dim iIndex As Integer = oSegments.IndexOf(Segment)
                If Index <> iIndex AndAlso Index >= 0 AndAlso Index < oSegments.Count Then
                    Call oSegments.Remove(Segment)
                    Call oSegments.Insert(Index, Segment)
                    RaiseEvent OnSegmentMove(Me, New OnSegmentMoveEventArgs(Segment, iIndex, Index))
                End If
            Catch
            End Try
        End Sub

        Default Public ReadOnly Property Item(ByVal ID As String) As cISegment Implements cISegmentCollection.Item
            Get
                Return oSegments(ID)
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oSegments = New cSegmentBaseCollection
        End Sub

        Public Function Contains(ByVal Segment As cISegment) As Boolean Implements cISegmentCollection.Contains
            Return oSegments.Contains(Segment)
        End Function

        Public Function Contains(ByVal ID As String) As Boolean Implements cISegmentCollection.Contains
            Return oSegments.Contains(ID)
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal Segments As XmlElement)
            oSurvey = Survey

            If oSurvey.Properties.CreatorID.ToLower = "topodroid" Then
                If Not oSurvey.Properties.DataTables.Segments.Contains("distox_g") Then
                    Dim oField As Data.cDataField = oSurvey.Properties.DataTables.Segments.Add("distox_g", Data.cDataFields.TypeEnum.Single)
                    oField.Category = "DistoX"
                End If
                If Not oSurvey.Properties.DataTables.Segments.Contains("distox_m") Then
                    Dim oField As Data.cDataField = oSurvey.Properties.DataTables.Segments.Add("distox_m", Data.cDataFields.TypeEnum.Single)
                    oField.Category = "DistoX"
                End If
                If Not oSurvey.Properties.DataTables.Segments.Contains("distox_dip") Then
                    Dim oField As Data.cDataField = oSurvey.Properties.DataTables.Segments.Add("distox_dip", Data.cDataFields.TypeEnum.Single)
                    oField.Category = "DistoX"
                End If
                If Not oSurvey.Properties.DataTables.Segments.Contains("distox") Then
                    Dim oField As Data.cDataField = oSurvey.Properties.DataTables.Segments.Add("distox", Data.cDataFields.TypeEnum.Text)
                    oField.Category = "DistoX"
                End If
            End If

            oSegments = New cSegmentBaseCollection
            Dim iIndex As Integer = 0
            Dim iCount As Integer = Segments.ChildNodes.Count
            Dim iStep As Integer = IIf(iCount > 20, iCount \ 20, 1)
            For Each oXmlSegment As XmlElement In Segments.ChildNodes
                iIndex += 1
                If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("load", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("segments.load"), iIndex / iCount)
                Dim oSegment As cSegment = New cSegment(oSurvey, File, oXmlSegment)
                AddHandler oSegment.OnChange, AddressOf oSegment_OnChange
                AddHandler oSegment.OnSplayChange, AddressOf oSegment_OnSplayChange
                AddHandler oSegment.OnReassigned, AddressOf oSegment_OnReassigned
                AddHandler oSegment.OnGetSplayName, AddressOf oSegment_OnGetSplayName
                Call oSegments.Add(oSegment)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum)
            Dim oXmlSegments As XmlElement = Document.CreateElement("segments")
            Dim iIndex As Integer = 0
            Dim iCount As Integer = oSegments.Count
            Dim iStep As Integer = IIf(iCount > 20, iCount \ 20, 1)
            For Each oSegment As cSegment In oSegments
                iIndex += 1
                If (Options And cSurvey.SaveOptionsEnum.Silent) = 0 Then If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("save", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("segments.save"), iIndex / iCount)
                Call oSegment.SaveTo(File, Document, oXmlSegments, Options)
            Next
            Call Parent.AppendChild(oXmlSegments)
            Return oXmlSegments
        End Function

        Public ReadOnly Property Last() As cSegment
            Get
                If oSegments.Count > 0 Then
                    Return oSegments.Last
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property First() As cSegment
            Get
                If oSegments.Count > 0 Then
                    Return oSegments.First
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Function Append() As cSegment
            Dim oSegment As cSegment = New cSegment(oSurvey)
            RaiseEvent OnSegmentBeforeAppend(Me, New cSegments.OnSegmentEventArgs(oSegment, -1))
            Call oSegments.Add(oSegment)
            AddHandler oSegment.OnChange, AddressOf oSegment_OnChange
            AddHandler oSegment.OnSplayChange, AddressOf oSegment_OnSplayChange
            AddHandler oSegment.OnReassigned, AddressOf oSegment_OnReassigned
            AddHandler oSegment.OnGetSplayName, AddressOf oSegment_OnGetSplayName
            RaiseEvent OnSegmentAppend(Me, New cSegments.OnSegmentEventArgs(oSegment, oSegments.Count - 1))
            Return oSegment
        End Function

        Public Function Append(ByVal Segment As cSegment) As cSegment
            Dim oSegment As cSegment = Segment 'New cSegment(oSurvey, Segment)
            RaiseEvent OnSegmentBeforeAppend(Me, New cSegments.OnSegmentEventArgs(oSegment, -1))
            Call oSegments.Add(oSegment)
            AddHandler oSegment.OnChange, AddressOf oSegment_OnChange
            AddHandler oSegment.OnSplayChange, AddressOf oSegment_OnSplayChange
            AddHandler oSegment.OnReassigned, AddressOf oSegment_OnReassigned
            AddHandler oSegment.OnGetSplayName, AddressOf oSegment_OnGetSplayName
            RaiseEvent OnSegmentAppend(Me, New cSegments.OnSegmentEventArgs(oSegment, oSegments.Count - 1))
            Return oSegment
        End Function

        Public Function Insert(ByVal Index As Integer) As cSegment
            Dim oSegment As cSegment = New cSegment(oSurvey)
            Call oSegments.Insert(Index, oSegment)
            AddHandler oSegment.OnChange, AddressOf oSegment_OnChange
            AddHandler oSegment.OnSplayChange, AddressOf oSegment_OnSplayChange
            AddHandler oSegment.OnReassigned, AddressOf oSegment_OnReassigned
            AddHandler oSegment.OnGetSplayName, AddressOf oSegment_OnGetSplayName
            RaiseEvent OnSegmentInsert(Me, New cSegments.OnSegmentEventArgs(oSegment, Index))
            Return oSegment
        End Function

        Public Function Insert(ByVal Index As Integer, ByVal Segment As cSegment) As cSegment
            Dim oSegment As cSegment = New cSegment(oSurvey, Segment)
            Call oSegments.Insert(Index, oSegment)
            AddHandler oSegment.OnChange, AddressOf oSegment_OnChange
            AddHandler oSegment.OnSplayChange, AddressOf oSegment_OnSplayChange
            AddHandler oSegment.OnReassigned, AddressOf oSegment_OnReassigned
            AddHandler oSegment.OnGetSplayName, AddressOf oSegment_OnGetSplayName
            RaiseEvent OnSegmentInsert(Me, New cSegments.OnSegmentEventArgs(oSegment, Index))
            Return oSegment
        End Function

        Private oLastSplayIndexes As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)

        Public Function GetSplayName(Name As String) As String
            Dim oArgs As cSegment.cGetSplayNameEventArgs = New cSegment.cGetSplayNameEventArgs(Name)
            Call oSegment_OnGetSplayName(Nothing, oArgs)
            Return oArgs.SplayName
        End Function

        Private Sub oSegment_OnGetSplayName(ByVal Sender As Object, Args As cSegment.cGetSplayNameEventArgs)
            Dim sBasename As String = Args.Basename
            Dim iSplayIndex As Integer
            If oLastSplayIndexes.ContainsKey(sBasename) Then
                iSplayIndex = oLastSplayIndexes(sBasename)
            End If
            Dim sSplayName As String
            Dim oTrigPoints As SortedSet(Of String) = GetTrigPointsNames()
            Do
                iSplayIndex += 1
                sSplayName = sBasename & "(" & iSplayIndex & ")"
            Loop While oTrigPoints.Contains(sSplayName)

            If oLastSplayIndexes.ContainsKey(sBasename) Then
                Call oLastSplayIndexes.Remove(sBasename)
            End If
            Call oLastSplayIndexes.Add(sBasename, iSplayIndex)

            Args.SplayName = sSplayName
        End Sub

        Private Sub oSegment_OnSplayChange(ByVal Sender As Object, e As EventArgs)
            RaiseEvent OnSegmentSplayChange(Me, New cSegments.OnSegmentEventArgs(Sender, oSegments.IndexOf(Sender)))
        End Sub

        Private Sub oSegment_OnChange(ByVal Sender As Object, e As EventArgs)
            Debug.Print(Sender.GetHashCode & " - " & Sender.GetHash)
            RaiseEvent OnSegmentChange(Me, New cSegments.OnSegmentEventArgs(Sender, oSegments.IndexOf(Sender)))
        End Sub

        Private Sub oSegment_OnReassigned(ByVal Sender As Object, e As EventArgs)
            RaiseEvent OnSegmentReassigned(Me, New cSegments.OnSegmentEventArgs(Sender, oSegments.IndexOf(Sender)))
        End Sub

        Public Function GetOrigin() As cSegment
            Dim sOrigin As String = oSurvey.Properties.Origin
            Dim oPseudoOrigin As cSegment = Nothing
            For Each oSegment As cSegment In oSegments
                If oSegment.IsValid Then
                    If (oSegment.[From] = sOrigin And oSegment.[To] = sOrigin) Then
                        Return oSegment
                    ElseIf (oSegment.[From] = sOrigin Or oSegment.[To] = sOrigin) And oPseudoOrigin Is Nothing Then
                        oPseudoOrigin = oSegment
                    End If
                End If
            Next
            Return oPseudoOrigin
        End Function

        Public Sub Remove(ByVal ID As String)
            Dim oSegment As cSegment = oSegments(ID)
            Dim iIndex As Integer = oSegment.Index
            Call oSegments.Remove(ID)
            Call oSegment.Attachments.Clear()
            RaiseEvent OnSegmentRemove(Me, New cSegments.OnSegmentEventArgs(oSegment, iIndex))
        End Sub

        Public Sub RemoveRange(Segments As IEnumerable(Of cSegment))
            Dim oRemovedIndexes As List(Of Integer) = New List(Of Integer)
            Dim oRemovedSegments As List(Of cSegment) = Segments.Where(Function(item) TypeOf item Is cSegment).ToList
            For Each oRemovedSegment As cSegment In oRemovedSegments
                If oSegments.Contains(oRemovedSegment) Then
                    Call oRemovedIndexes.Add(oRemovedSegment.Index)
                    Call oSegments.Remove(oRemovedSegment)
                    Call oRemovedSegment.Attachments.Clear()
                End If
            Next
            If oRemovedIndexes.Count > 0 Then
                RaiseEvent OnSegmentRemoveRange(Me, New cSegments.OnSegmentsEventArgs(oRemovedSegments, oRemovedIndexes))
            End If
        End Sub

        Public Function Remove(ByVal Segment As cSegment) As Boolean
            If oSegments.Contains(Segment) Then
                Dim iIndex As Integer = oSegments.IndexOf(Segment)
                Call oSegments.Remove(Segment)
                Call Segment.Attachments.Clear()
                RaiseEvent OnSegmentRemove(Me, New cSegments.OnSegmentEventArgs(Segment, iIndex))
                Return True
            End If
        End Function

        Public Sub Remove(ByVal Index As Integer)
            Dim oSegment As cSegment = oSegments(Index)
            Call oSegments.RemoveAt(Index)
            Call oSegment.Attachments.Clear()
            RaiseEvent OnSegmentRemove(Me, New cSegments.OnSegmentEventArgs(oSegment, Index))
        End Sub

        Friend Function GetTrigPointsNames() As SortedSet(Of String) Implements cISegmentCollection.GetTrigpointsNames
            Dim oTable As SortedSet(Of String) = New SortedSet(Of String)
            Dim sName As String
            For Each oSegment As cSegment In oSegments
                If oSegment.IsValid Then
                    sName = oSegment.From.ToUpper
                    If sName <> "" Then
                        If Not oTable.Contains(sName) Then
                            Call oTable.Add(sName)
                        End If
                    End If
                    sName = oSegment.To.ToUpper
                    If sName <> "" Then
                        If Not oTable.Contains(sName) Then
                            Call oTable.Add(sName)
                        End If
                    End If
                End If
            Next
            Return oTable
        End Function

        Public Function GetValidSegments() As cSegmentCollection
            Return New cSegmentCollection(oSurvey, oSegments.Where(Function(item) item.IsValid AndAlso Not item.IsSelfDefined AndAlso Not item.Splay AndAlso Not item.Calibration))
        End Function

        Public ReadOnly Property Count() As Integer Implements cISegmentCollection.Count
            Get
                Return oSegments.Count
            End Get
        End Property

        Public Function IndexOf(ByVal ID As String) As Integer Implements cISegmentCollection.IndexOf
            If oSegments.Contains(ID) Then
                Dim oSegment As cSegment = oSegments(ID)
                Return oSegments.IndexOf(oSegment)
            Else
                Return -1
            End If
        End Function

        Public Function IndexOf(ByVal Segment As cISegment) As Integer Implements cISegmentCollection.IndexOf
            Return oSegments.IndexOf(Segment)
        End Function

        Default Public ReadOnly Property Item(ByVal Index As Integer) As cISegment Implements cISegmentCollection.Item
            Get
                If Index >= 0 And Index < oSegments.Count Then
                    Return oSegments(Index)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Function GetVisibleSegments(PaintOptions As Design.cOptions) As cSegmentCollection Implements cISegmentCollection.GetVisibleSegments
            Return modSegmentsTools.GetVisibleSegments(oSurvey, Me, PaintOptions)
        End Function

        Public Function GetVisibleCaveSegments(PaintOptions As Design.cOptions, ByVal Cave As String, Optional ByVal Branch As String = "") As cSegmentCollection Implements cISegmentCollection.GetVisibleCaveSegments
            Return modSegmentsTools.GetVisibleCaveSegments(oSurvey, Me, PaintOptions, Cave, Branch)
        End Function

        Public Function GetCaveSegments(ByVal Cave As String, Optional ByVal Branch As String = "") As cSegmentCollection Implements cISegmentCollection.GetCaveSegments
            Return modSegmentsTools.GetCaveSegments(oSurvey, Me, Cave, Branch)
        End Function

        Public Function GetCaveSegments(ByVal CaveInfoBranch As cCaveInfoBranch) As cSegmentCollection Implements cISegmentCollection.GetCaveSegments
            Return modSegmentsTools.GetCaveSegments(oSurvey, Me, CaveInfoBranch)
        End Function

        Public Function GetCaveSegments(ByVal CaveInfo As cCaveInfo) As cSegmentCollection Implements cISegmentCollection.GetCaveSegments
            Return modSegmentsTools.GetCaveSegments(oSurvey, Me, CaveInfo)
        End Function

        Public Function GetCalibrationSegments() As cSegmentCollection Implements cISegmentCollection.GetCalibrationSegments
            Return New cSegmentCollection(oSurvey, oSegments.Where(Function(item) item.Calibration AndAlso item.IsValid))
        End Function

        Public Function GetSessionSegments(ByVal SessionID As String, Optional Flags As cISegmentCollection.SessionSegmentsFlagEnum = cISegmentCollection.SessionSegmentsFlagEnum.SurveyShots) As cSegmentCollection Implements cISegmentCollection.GetSessionSegments
            Return modSegmentsTools.GetSessionSegments(oSurvey, Me, SessionID, Flags)
        End Function

        Public Function GetSessionSegments(ByVal Session As cSession, Optional Flags As cISegmentCollection.SessionSegmentsFlagEnum = cISegmentCollection.SessionSegmentsFlagEnum.SurveyShots) As cSegmentCollection Implements cISegmentCollection.GetSessionSegments
            Return modSegmentsTools.GetSessionSegments(oSurvey, Me, Session, Flags)
        End Function

        Public Function GetBindedItems() As List(Of Design.cItem) Implements cISegmentCollection.GetBindedItems
            Return modSegmentsTools.GetBindedItems(oSurvey, Me)
        End Function

        Public Function GetBindedItems(Design As cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum) As List(Of Design.cItem) Implements cISegmentCollection.GetBindedItems
            Return modSegmentsTools.GetBindedItems(oSurvey, Me, Design)
        End Function

        Public Function GetBindedSegments() As cSegmentCollection Implements cISegmentCollection.GetBindedSegments
            Return modSegmentsTools.GetBindedSegments(oSurvey, Me)
        End Function

        Public Function GetBindedSegments(Design As cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum) As cSegmentCollection Implements cISegmentCollection.GetBindedSegments
            Return modSegmentsTools.GetBindedSegments(oSurvey, Me, Design)
        End Function

        Public Function Intersect(Segments As cISegmentCollection) As cISegmentCollection Implements cISegmentCollection.Intersect
            Return New cSegmentCollection(oSurvey, oSegments.Intersect(Segments))
        End Function

        Public Function GetSplaySegments(TrigPoint As cTrigPoint) As cSegmentCollection
            Return GetSplaySegments(TrigPoint.Name)
        End Function

        Public Function GetSplaySegments(TrigPoint As String) As cSegmentCollection
            Return New cSegmentCollection(oSurvey, oSegments.Where(Function(item As cSegment) item.IsValid AndAlso item.Splay AndAlso (item.From = TrigPoint))) ' OrElse item.To = TrigPoint)))
        End Function

        Public Function GetSplaySegments() As cSegmentCollection
            Return New cSegmentCollection(oSurvey, oSegments.Where(Function(item As cSegment) item.IsValid AndAlso item.Splay))
        End Function

        Friend Function GetChangedSegments(Design As cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum, ForWarping As Boolean) As cSegmentCollection
            Dim oSegmentColl As cSegmentCollection = New cSegmentCollection(oSurvey)
            For Each oSegment As cSegment In oSegments
                If oSegment.IsValid AndAlso Not oSegment.Unbindable AndAlso Not oSegment.Splay AndAlso Not oSegment.IsEquate Then
                    Select Case Design
                        Case cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum.Plan
                            If oSegment.Data.Plan.Changed AndAlso ((ForWarping AndAlso oSegment.Data.PlanWarpingFactor.IsChanged) OrElse Not ForWarping) Then
                                Call oSegmentColl.Append(oSegment)
                            End If
                        Case cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum.Profile
                            If oSegment.Data.Profile.Changed AndAlso ((ForWarping AndAlso oSegment.Data.ProfileWarpingFactor.IsChanged) OrElse Not ForWarping) Then
                                Call oSegmentColl.Append(oSegment)
                            End If
                    End Select
                End If
            Next
            Return oSegmentColl
        End Function

        Friend Function GetEmptySegment() As cSegment
            Return New cSegment(oSurvey)
        End Function

        Public Enum ClearFlags
            All = 0
            OnlySplays = 1
        End Enum

        Public Sub Clear(Optional Flags As ClearFlags = ClearFlags.All)
            If Flags = ClearFlags.All Then
                Call oSegments.Clear()
            ElseIf Flags = ClearFlags.OnlySplays Then
                Call RemoveRange(oSegments.Where(Function(osegment) osegment.Splay))
            End If
            RaiseEvent OnClear(Me)
        End Sub

        Public Function cISegment_GetEnumerator() As IEnumerator(Of cISegment) Implements cISegmentCollection.GetEnumerator
            Return oSegments.GetEnumerator
        End Function

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oSegments.GetEnumerator
        End Function

        Public Function FindDuplicate(Data As cSegment) As cSegmentCollection
            Dim oResult As cSegmentCollection = New cSegmentCollection(oSurvey)
            For Each oSegment As cSegment In oSegments
                If oSegment.From = Data.From AndAlso
                   (oSegment.Splay OrElse (Not oSegment.Splay AndAlso oSegment.To = Data.To)) AndAlso
                   modNumbers.MathRound(oSegment.Distance, 2) = modNumbers.MathRound(Data.Distance, 2) AndAlso
                    modNumbers.MathRound(oSegment.Inclination, 2) = modNumbers.MathRound(Data.Inclination, 2) AndAlso
                    modNumbers.MathRound(oSegment.Bearing, 2) = modNumbers.MathRound(Data.Bearing, 2) Then
                    Call oResult.Append(oSegment)
                End If
            Next
            'For Each osegment As cSegment In oSegments.OfType(Of cSegment).Where(Function(segment) segment.From = Data.From AndAlso
            '       (segment.Splay OrElse (Not segment.Splay AndAlso segment.To = Data.To)) AndAlso
            '        segment.Data.Data.Distance = Data.Data.Data.Distance AndAlso
            '        segment.Data.Data.Inclination = Data.Data.Data.Inclination AndAlso
            '        segment.Data.Data.Bearing = Data.Data.Data.Bearing)
            '    Call oResult.Append(osegment)
            'Next
            Return oResult
        End Function

        Public Function GetTrigpointSegments(ByVal Trigpoint As String) As cISegmentCollection Implements cISegmentCollection.GetTrigpointSegments
            Dim sTrigpoint As String = Trigpoint.ToUpper
            Return New cSegmentCollection(oSurvey, oSegments.Where(Function(Segment) Segment.From = sTrigpoint Or Segment.To = sTrigpoint))
        End Function

        Public Function Find(ByVal Text As String) As cISegmentCollection Implements cISegmentCollection.Find
            Dim sText As String = Text.ToUpper
            Return New cSegmentCollection(oSurvey, oSegments.Where(Function(Segment) Segment.From Like sText Or Segment.To Like sText))
        End Function

        Public Function Find(ByVal [FromText] As String, ByVal [ToText] As String, Optional ReverseSearch As Boolean = True) As cSegment
            If FromText Is Nothing Then
                Dim sToText As String = [ToText].ToUpper
                Return oSegments.FirstOrDefault(Function(Segment) (Segment.To Like sToText))
            ElseIf ToText Is Nothing Then
                Dim sFromText As String = FromText.ToUpper
                Return oSegments.FirstOrDefault(Function(Segment) (Segment.From Like sFromText))
            Else
                If ReverseSearch Then
                    Dim sFromText As String = FromText.ToUpper
                    Dim sToText As String = [ToText].ToUpper
                    Return oSegments.FirstOrDefault(Function(Segment) (Segment.From Like sFromText And Segment.To Like sToText) Or (Segment.From Like sToText And Segment.To Like sFromText))
                Else
                    Dim sFromText As String = FromText.ToUpper
                    Dim sToText As String = [ToText].ToUpper
                    Return oSegments.FirstOrDefault(Function(Segment) (Segment.From Like sFromText And Segment.To Like sToText))
                End If
            End If
        End Function

        Public Function GetTrigPoints() As cITrigPointCollection Implements cISegmentCollection.GetTrigpoints
            Return oSurvey.TrigPoints
        End Function

        Public Function ToCSV(Optional UseLocalFormat As Boolean = False) As String Implements cISegmentCollection.ToCSV
            Dim sSb As String = ""
            For Each oSegment As cSegment In oSegments
                sSb &= oSegment.ToCSV & vbCrLf
            Next
            Return sSb
        End Function

        Public Function ToTSV(Optional UseLocalFormat As Boolean = False) As String Implements cISegmentCollection.ToTSV
            Dim sSb As String = ""
            For Each oSegment As cSegment In oSegments
                sSb &= oSegment.ToTSV & vbCrLf
            Next
            Return sSb
        End Function

        Public Function ToBindingList() As BindingList(Of cSegment) 'cSegmentsBindinglist
            Dim oBindingList As BindingList(Of cSegment) = New BindingList(Of cSegment)
            For Each osegment As cSegment In oSegments
                Call oBindingList.Add(osegment)
            Next
            Return oBindingList
            'Return New cSegmentsBindinglist(Me)
        End Function

        Public Function ToList() As List(Of cISegment) Implements cISegmentCollection.ToList
            Return oSegments.ToList
        End Function

        Public Function ToArray() As cISegment() Implements cISegmentCollection.ToArray
            Return oSegments.ToArray
        End Function

        Public Function GetDistintSegments() As cSegmentCollection
            Dim oResult As Dictionary(Of String, cSegment) = New Dictionary(Of String, cSegment)
            For Each oSegment As cSegment In oSegments
                If oResult.ContainsKey(oSegment.GetHash) Then
                    Call Debug.Print(oSegment.ToString)
                Else
                    Call oResult.Add(oSegment.GetHash, oSegment)
                End If
            Next
            Return New cSegmentCollection(oSurvey, oResult.Values)
        End Function

        Public Function GetSurveySegments() As cSegmentCollection Implements cISegmentCollection.GetSurveySegments
            Return New cSegmentCollection(oSurvey, oSegments.Where(Function(item) Not item.Calibration AndAlso item.IsValid))
        End Function

        Public Sub CheckSplayFlags()
            Call oSurvey.RaiseOnProgressEvent("segments.checksplayflagsbegin", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, modMain.GetLocalizedString("segments.refreshsplaynamesbegin"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageCalculate Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow)
            Dim iIndex As Integer = 0
            Dim iCount As Integer = oSegments.Count
            Dim oSplayIndexes As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
            For Each osegment As cSegment In oSegments
                If osegment.IsValid Then
                    iIndex += 1
                    If (iIndex Mod 10) = 0 Then Call oSurvey.RaiseOnProgressEvent("segments.checksplayflagsnames", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("segments.checksplayflagsprogress"), iIndex / iCount)
                    If osegment.IsSelfDefined Then
                        If osegment.Splay AndAlso Not osegment.From Like "*(*)" Then
                            'splay with same from/to (from pockettopo or some other source)
                            Dim oArgs As cSegment.cGetSplayNameEventArgs = New cSegment.cGetSplayNameEventArgs(osegment.From)
                            Call oSegment_OnGetSplayName(osegment, oArgs)
                            osegment.To = oArgs.SplayName
                        End If
                    Else
                        If osegment.To Like "*(*)" OrElse osegment.From Like "*(*)" Then
                            osegment.Splay = True
                        Else
                            osegment.Splay = False
                        End If
                    End If
                End If
            Next
            Call SaveAll()
            Call oSurvey.RaiseOnProgressEvent("segments.checksplayflagsnames", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, modMain.GetLocalizedString("segments.checksplayflagsend"), 0)
        End Sub

        Public Sub RefreshSplayNames()
            Call oSurvey.RaiseOnProgressEvent("segments.refreshsplaynames", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, modMain.GetLocalizedString("segments.refreshsplaynamesbegin"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageCalculate Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow)
            Dim iIndex As Integer = 0
            Dim iCount As Integer = oSegments.Count
            Dim oSplayIndexes As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
            Dim iLastSplayIndex As Integer
            For Each osegment As cSegment In oSegments
                If osegment.IsValid AndAlso Not osegment.IsSelfDefined AndAlso osegment.Splay Then
                    iIndex += 1
                    If (iIndex Mod 10) = 0 Then Call oSurvey.RaiseOnProgressEvent("segments.refreshsplaynames", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("segments.refreshsplaynamesprogress"), iIndex / iCount)
                    If osegment.To Like "*(*)" Then
                        Dim oArgs As cSegment.cGetSplayNameEventArgs = New cSegment.cGetSplayNameEventArgs(osegment.From)
                        If oSplayIndexes.ContainsKey(osegment.From) Then
                            iLastSplayIndex = oSplayIndexes(osegment.From)
                            Call oSplayIndexes.Remove(osegment.From)
                        Else
                            iLastSplayIndex = 0
                        End If
                        iLastSplayIndex += 1
                        Call oSplayIndexes.Add(osegment.From, iLastSplayIndex)
                        If oLastSplayIndexes.ContainsKey(osegment.From) Then Call oLastSplayIndexes.Remove(osegment.From)
                        Call oLastSplayIndexes.Add(osegment.From, iLastSplayIndex)
                        osegment.To = osegment.From & "(" & iLastSplayIndex & ")"
                    ElseIf osegment.From Like "*(*)" Then
                        Dim oArgs As cSegment.cGetSplayNameEventArgs = New cSegment.cGetSplayNameEventArgs(osegment.To)
                        If oSplayIndexes.ContainsKey(osegment.To) Then
                            iLastSplayIndex = oSplayIndexes(osegment.To)
                            Call oSplayIndexes.Remove(osegment.To)
                        Else
                            iLastSplayIndex = 0
                        End If
                        iLastSplayIndex += 1
                        Call oSplayIndexes.Add(osegment.To, iLastSplayIndex)
                        If oLastSplayIndexes.ContainsKey(osegment.To) Then Call oLastSplayIndexes.Remove(osegment.To)
                        Call oLastSplayIndexes.Add(osegment.To, iLastSplayIndex)
                        osegment.From = osegment.To & "(" & iLastSplayIndex & ")"
                    End If
                End If
            Next
            Call SaveAll()
            Call oSurvey.RaiseOnProgressEvent("segments.refreshsplaynames", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, modMain.GetLocalizedString("segments.refreshsplaynamesend"), 0)
        End Sub

        Public Sub CleanUp()
            Call oSurvey.RaiseOnProgressEvent("segments.cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, modMain.GetLocalizedString("segments.cleanupbegin"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageCalculate Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow)
            Dim iIndex As Integer = 0
            Dim iCount As Integer = oSegments.Count
            For Each osegment As cSegment In oSegments
                iIndex += 1
                If (iIndex Mod 10) = 0 Then Call oSurvey.RaiseOnProgressEvent("segments.cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("segments.cleanupprogress"), iIndex / iCount)

                If osegment.Cave <> "" Then
                    If Not oSurvey.Properties.CaveInfos.Contains(osegment.Cave) Then
                        Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Warning, "segment " & osegment.ToString & " > invalid cave [" & osegment.Cave & "] resetted to: []")
                        Call osegment.SetCave("", "")
                    Else
                        If Not oSurvey.Properties.CaveInfos(osegment.Cave).Branches.Contains(osegment.Branch) Then
                            Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Warning, "segment " & osegment.ToString & " > invalid branch [" & osegment.Branch & "] resetted to: []")
                            Call osegment.SetCave(osegment.Cave, "")
                            osegment.Save()
                        End If
                    End If
                End If

                If osegment.Session <> "" Then
                    If Not oSurvey.Properties.Sessions.Contains(osegment.Session) Then
                        Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Warning, "segment " & osegment.ToString & " > invalid session [" & osegment.Session & "] resetted to: []")
                        Call osegment.SetSession("")
                    End If
                End If
            Next
            Call oSurvey.RaiseOnProgressEvent("segments.cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, modMain.GetLocalizedString("segments.cleanupend"), 0)
        End Sub

        Public Function GetSessions() As List(Of cSession) Implements cISegmentCollection.GetSessions
            Dim oEmptySession As cSession = oSurvey.Properties.Sessions.GetEmptySession
            Dim oSessions As List(Of String) = New List(Of String)
            For Each oSegment As cSegment In oSegments
                If Not oSessions.Contains(oSegment.Session) Then
                    Call oSessions.Add(oSegment.Session)
                End If
            Next
            Return oSessions.Select(Function(sSession) If(sSession = "", oEmptySession, oSurvey.Properties.Sessions(sSession))).ToList
        End Function
    End Class
End Namespace