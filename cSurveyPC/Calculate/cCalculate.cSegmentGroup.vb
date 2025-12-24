Imports cSurveyPC.cSurvey

Namespace cSurvey.Calculate
    Public Class cSegmentGroup
        Implements IComparable(Of cSegmentGroup), IComparer, IEquatable(Of cSegmentGroup), IEqualityComparer(Of String), IEqualityComparer(Of cSegmentGroup)

        Private sExtendStart As String
        Private iPriority As Integer
        Private sKey As String

        Private oParentConnection As cConnectionDef
        Private oConnection As cConnectionDef

        Private oSegments As List(Of cSegment)

        Public Function HaveParentConnection() As Boolean
            Return Not IsNothing(oParentConnection)
        End Function

        Public Function HaveConnection() As Boolean
            Return HaveParentConnection() AndAlso Not IsNothing(Connection)
        End Function

        Friend Function CloneDistinct() As cSegmentGroup
            Dim oGroup As cSegmentGroup = New cSegmentGroup(sExtendStart, iPriority, oParentConnection, oConnection)
            Dim oSegmentHash As List(Of String) = New List(Of String)
            For Each oSegment As cSegment In oSegments
                Dim sHash As String = oSegment.GetHash
                If Not oSegmentHash.Contains(sHash) Then
                    Call oGroup.oSegments.Add(oSegment)
                    Call oSegmentHash.Add(sHash)
                End If
            Next
            Return oGroup
        End Function

        Friend Function Validate(RaiseError As Boolean) As Boolean
            If sExtendStart = "" OrElse oSegments.Count = 0 Then
                Return True
            Else
                If oSegments.Select(Function(item) item.From).Distinct.Contains(sExtendStart) Then
                    Return True
                Else
                    If oSegments.Select(Function(item) item.To).Distinct.Contains(sExtendStart) Then
                        Return True
                    Else
                        If RaiseError Then
                            Throw New Exception(String.Format(modMain.GetLocalizedString("calculate.textpart7"), sExtendStart))
                        End If
                        Return False
                    End If
                End If
            End If
        End Function

        Public ReadOnly Property Segments As List(Of cSegment)
            Get
                Return oSegments
            End Get
        End Property

        Public Function GetSegments() As List(Of cSegment)
            Return New List(Of cSegment)(oSegments)
        End Function

        Friend Sub Remove(Segment As cSegment)
            Call oSegments.Remove(Segment)
        End Sub

        Friend Sub RemoveRange(Segments As IEnumerable(Of cSegment))
            For Each oSegment As cSegment In Segments
                Call oSegments.Remove(oSegment)
            Next
        End Sub

        Friend Sub Append(Segment As cSegment)
            Segment.Data.Group = Me
            If Not oSegments.Contains(Segment) Then Call oSegments.Add(Segment)
        End Sub

        'Public Function GetSegment(Segments As List(Of cSegment)) As List(Of cSegment)
        '    Return Segments.Where(Function(item) item.Data.Group Is Me).ToList
        'End Function

        'Public Function ExtractSegment(ByRef Segments As List(Of cSegment)) As List(Of cSegment)
        '    Dim oResult As List(Of cSegment) = Segments.Where(Function(item) item.Data.Group Is Me).ToList
        '    Segments = Segments.Except(oResult).ToList
        '    Return oResult
        'End Function

        Public Function GetKey() As String
            Return sKey
        End Function

        Friend Sub New(ExtendStart As String, Priority As Integer, ParentConnection As cConnectionDef, Connection As cConnectionDef)
            sExtendStart = ExtendStart
            iPriority = Priority
            oParentConnection = ParentConnection
            oConnection = Connection
            sKey = GetKey(sExtendStart, iPriority)
            oSegments = New List(Of cSegment)
        End Sub

        Friend Sub New(CaveInfo As cICaveInfoBranches)
            sExtendStart = CaveInfo.GetExtendStart
            iPriority = CaveInfo.GetPriority

            oParentConnection = CaveInfo.GetParentConnection
            oConnection = CaveInfo.GetConnection

            sKey = GetKey(sExtendStart, iPriority)
            oSegments = New List(Of cSegment)
        End Sub

        Public ReadOnly Property ParentConnection As cConnectionDef
            Get
                Return oParentConnection
            End Get
        End Property

        Public ReadOnly Property Connection As cConnectionDef
            Get
                Return oConnection
            End Get
        End Property

        Public Shared Function GetKey(ExtendStart As String, Priority As Integer) As String
            Return ExtendStart & "/" & Priority
        End Function

        Public ReadOnly Property Key As String
            Get
                Return sKey
            End Get
        End Property

        Public ReadOnly Property Priority As Integer
            Get
                Return iPriority
            End Get
        End Property

        Public ReadOnly Property ExtendStart As String
            Get
                Return sExtendStart
            End Get
        End Property

        Public Function CompareTo(other As cSegmentGroup) As Integer Implements IComparable(Of cSegmentGroup).CompareTo
            Return If(other.GetKey = GetKey(), 0, 1)
        End Function

        Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            Return If(x.GetKey = y.GetKey(), 0, 1)
        End Function

        Public Shadows Function Equals(other As cSegmentGroup) As Boolean Implements IEquatable(Of cSegmentGroup).Equals
            Return other.GetKey = GetKey()
        End Function

        Public Shadows Function Equals(x As String, y As String) As Boolean Implements IEqualityComparer(Of String).Equals
            Return x = y
        End Function

        Public Shadows Function GetHashCode(obj As String) As Integer Implements IEqualityComparer(Of String).GetHashCode
            Return obj.GetHashCode
        End Function

        Public Shadows Function Equals(x As cSegmentGroup, y As cSegmentGroup) As Boolean Implements IEqualityComparer(Of cSegmentGroup).Equals
            Return x Is y
        End Function

        Public Shadows Function GetHashCode(obj As cSegmentGroup) As Integer Implements IEqualityComparer(Of cSegmentGroup).GetHashCode
            Return obj.Key.GetHashCode
        End Function
    End Class
End Namespace
