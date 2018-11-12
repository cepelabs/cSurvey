Friend Class cCleanUpItemOwnersRequestargs
    Private oOwners As List(Of Object)

    Public ReadOnly Property Owners As List(Of Object)
        Get
            Return oOwners
        End Get
    End Property

    Public Sub Append(Owner As Object)
        'add only if not just in collection...is not necessary but usefull to have exact count of object using a cleanup-able item...
        If Not oOwners.Contains(Owner) Then
            Call oOwners.Add(Owner)
        End If
    End Sub

    Public Sub New(Owners As List(Of Object))
        oOwners = Owners
    End Sub
End Class

Friend Interface cICleanUpItem
    Event OnCleanUpOwnerRequest(Sender As Object, Args As cCleanUpItemOwnersRequestargs)
    Sub CleanUpOwnersRequest(Owners As List(Of Object))
End Interface

Friend Interface cICleanUpSubItem
    Sub PerformCleanUp()
End Interface

Friend Interface cICleanUpParent(Of T)
    Sub CleanUp(Item As T)
    Sub CleanUp()   'for legacy... 
End Interface
