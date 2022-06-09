Namespace cSurvey.Surface
    Public Class cSurfaceItemChanged
        Inherits EventArgs

        Private oItem As cISurfaceItem
        Public ReadOnly Property Item As cISurfaceItem
            Get
                Return oItem
            End Get
        End Property

        Friend Sub New(Item As cISurfaceItem)
            oItem = Item
        End Sub
    End Class

    Public Interface cISurfaceItem
        ReadOnly Property ID As String
        Property Name As String

        Function IsEmpty() As Boolean
    End Interface
End Namespace
