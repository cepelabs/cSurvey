Namespace cSurvey.Design
    Public Class cDrawOptions

        <Flags>
        Public Enum cdrawoptionsenum
            Empty = 0
            Schematic = 1
        End Enum

        Private iDrawOptions As cdrawoptionsenum

        Public ReadOnly Property DrawOptions As cdrawoptionsenum
            Get
                Return iDrawOptions
            End Get
        End Property

        Public Sub New(DrawOptions As cdrawoptionsenum)
            iDrawOptions = DrawOptions
        End Sub

        Public Shared Function Empty() As cDrawOptions
            Return New cDrawOptions(cdrawoptionsenum.Empty)
        End Function

        Public Shared Function Schematic() As cDrawOptions
            Return New cDrawOptions(cdrawoptionsenum.Schematic)
        End Function


    End Class
End Namespace
