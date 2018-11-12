Public Class cItemProperties
    Private oValues As Dictionary(Of String, Object)

    Default Public Property Item(Key As String) As Object
        Get
            Return oValues(Key)
        End Get
        Set(value As Object)
            value(Key) = value
        End Set
    End Property

End Class