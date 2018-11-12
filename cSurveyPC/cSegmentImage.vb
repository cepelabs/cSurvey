Namespace cSurvey
    Public Class cSegmentImage
        Private oImage As Image

        Private sNote As String
        Private sDescription As String
        Private sAuthor As String

        Private dDate As Date

        Public Sub New(Image As Image, [Date] As Date, Description As String, Note As String, Author As String)
            oImage = Image
            dDate = [Date]
            sDescription = Description
            sNote = Note
            sAuthor = Author
        End Sub

        Public Property [Date] As Date
            Get
                Return dDate
            End Get
            Set(value As Date)
                dDate = value
            End Set
        End Property

        Public Property Note As String
            Get
                Return sNote
            End Get
            Set(value As String)
                sNote = value
            End Set
        End Property

        Public Property Author As String
            Get
                Return sAuthor
            End Get
            Set(value As String)
                sAuthor = value
            End Set
        End Property

        Public Property Description As String
            Get
                Return sDescription
            End Get
            Set(value As String)
                sDescription = value
            End Set
        End Property

        Public Property Image As Image
            Get
                Return oImage
            End Get
            Set(value As Image)
                oImage = value
            End Set
        End Property
    End Class
End Namespace
