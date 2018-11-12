Imports System.Collections.ObjectModel

Namespace cSurvey.Calculate
    Friend Class cSegmentGroupCollection
        Inherits KeyedCollection(Of String, cSegmentGroup)

        Public Sub New()
            Call MyBase.New()
        End Sub

        Friend Function Validate(RaiseError As Boolean) As Boolean
            For Each oGroup As cSegmentGroup In MyBase.Items
                Call oGroup.Validate(RaiseError)
            Next
        End Function

        Public Function ToCalculateList(ExtendStart As String, Priority As Integer) As List(Of cSegmentGroup)
            Dim oResult As List(Of cSegmentGroup) = New List(Of cSegmentGroup)
            Dim oDefaultGroup As cSegmentGroup = MyBase.Item(cSegmentGroup.GetKey(ExtendStart, Priority))
            Call oResult.Add(oDefaultGroup.CloneDistinct)
            For Each oGroup As cSegmentGroup In MyBase.Items
                If Not oGroup Is oDefaultGroup Then
                    Call oResult.Add(oGroup.CloneDistinct)
                End If
            Next
            Return oResult
        End Function

        Protected Overrides Function GetKeyForItem(ByVal item As cSegmentGroup) As String
            Return item.Key
        End Function

        Public Function GetDistinctSegments() As List(Of cSegment)
            Dim oResult As List(Of cSegment) = New List(Of cSegment)
            Dim oSegmentHash As List(Of String) = New List(Of String)
            For Each oGroup As cSegmentGroup In Me
                For Each oSegment As cSegment In oGroup.Segments
                    Dim sHash As String = oSegment.GetHash
                    If Not oSegmentHash.Contains(sHash) Then
                        Call oResult.Add(oSegment)
                        Call oSegmentHash.Add(oSegment.GetHash)
                    End If
                Next
            Next
            Return oResult
        End Function

        Public Function GetSegments() As List(Of cSegment)
            Dim oResult As List(Of cSegment) = New List(Of cSegment)
            For Each oGroup As cSegmentGroup In Me
                Call oResult.AddRange(oGroup.Segments)
            Next
            Return oResult
        End Function

        Public Function NewOrExist(CaveInfo As cICaveInfoBranches) As cSegmentGroup
            Dim sExtendStart As String = CaveInfo.GetExtendStart
            Dim iPriority As Integer = CaveInfo.GetPriority
            Dim sKey As String = cSegmentGroup.GetKey(sExtendStart, iPriority)
            If Contains(sKey) Then
                Return Item(sKey)
            Else
                Dim oNewItem As cSegmentGroup = New cSegmentGroup(CaveInfo)
                Call Add(oNewItem)
                Return oNewItem
            End If
        End Function
    End Class
End Namespace
