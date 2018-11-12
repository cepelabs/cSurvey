Imports cSurveyPC.cSurvey

Namespace cSurvey.Helper.Editor
    Public Class cMarkedDesktopPoint
        Private bSet As Boolean
        Private oCoordinate As Calculate.cTrigPointCoordinate
        Private oPoint As PointF

        Friend Class cMoveEventArgs
            Inherits EventArgs

            Private oNewPoint As PointF

            Public Property NewPoint() As PointF
                Get
                    Return oNewPoint
                End Get
                Set(value As PointF)
                    oNewPoint = value
                End Set
            End Property

            Public Sub New(NewPoint As PointF)
                oNewPoint = NewPoint
            End Sub
        End Class

        Friend Class cPaintInfoEventArgs
            Inherits EventArgs

            Private sScale As Single

            Public Property Scale() As Single
                Get
                    Return sScale
                End Get
                Set(value As Single)
                    sScale = value
                End Set
            End Property
        End Class

        Friend Event OnMove(Sender As cMarkedDesktopPoint, Args As cMoveEventArgs)
        Friend Event OnSet(Sender As cMarkedDesktopPoint, Args As EventArgs)
        Friend Event OnGetPaintInfo(Sender As cMarkedDesktopPoint, Args As cPaintInfoEventArgs)

        Public Sub Move(NewPoint As PointF)
            Dim oArgs As cMoveEventArgs = New cMoveEventArgs(NewPoint)
            RaiseEvent OnMove(Me, oArgs)
        End Sub

        Friend Sub GetPaintInfo(ByRef Scale As Single)
            Dim oArgs As cPaintInfoEventArgs = New cPaintInfoEventArgs
            RaiseEvent OnGetPaintInfo(Me, oArgs)
            Scale = oArgs.Scale
        End Sub

        Public ReadOnly Property IsSet As Boolean
            Get
                Return bSet
            End Get
        End Property

        Public ReadOnly Property Point As PointF
            Get
                Return oPoint
            End Get
        End Property

        Public ReadOnly Property Coordinate As Calculate.cTrigPointCoordinate
            Get
                Return oCoordinate
            End Get
        End Property

        Public Sub [Set](Point As PointF, Coordinate As Calculate.cTrigPointCoordinate)
            bSet = True
            oPoint = Point
            oCoordinate = Coordinate
            RaiseEvent OnSet(Me, New EventArgs)
        End Sub

        Public Sub Unset()
            bSet = False
            oPoint = Nothing
            oCoordinate = Nothing
        End Sub
    End Class
End Namespace
