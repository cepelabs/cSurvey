Imports cSurveyPC.cSurvey.cSurvey

Namespace cSurvey.Calculate

    Friend Class cSegmentPlotSubDataLRUD
        Private dLeft As Decimal
        Private dRight As Decimal
        Private dUp As Decimal
        Private dDown As Decimal

        Friend Sub SetData(Left As Decimal, Right As Decimal, Up As Decimal, Down As Decimal)
            dLeft = Left
            dRight = Right
            dUp = Up
            dDown = Down
        End Sub

        Friend Sub New()
            dLeft = 0
            dRight = 0
            dUp = 0
            dDown = 0
        End Sub

        Friend Sub New(Left As Decimal, Right As Decimal, Up As Decimal, Down As Decimal)
            dLeft = Left
            dRight = Right
            dUp = Up
            dDown = Down
        End Sub

        Public ReadOnly Property Left As Decimal
            Get
                Return dLeft
            End Get
        End Property

        Public ReadOnly Property Right As Decimal
            Get
                Return dRight
            End Get
        End Property

        Public ReadOnly Property Up As Decimal
            Get
                Return dUp
            End Get
        End Property

        Public ReadOnly Property Down As Decimal
            Get
                Return dDown
            End Get
        End Property
    End Class

    Friend Class cSegmentPlotSubDataSidePoints
        Private oFromSidePointRight As PointD
        Private oFromSidePointLeft As PointD
        Private oToSidePointRight As PointD
        Private oToSidePointLeft As PointD

        Public ReadOnly Property FromSidePointRight() As PointD
            Get
                Return oFromSidePointRight
            End Get
        End Property

        Public ReadOnly Property FromSidePointLeft() As PointD
            Get
                Return oFromSidePointLeft
            End Get
        End Property

        Public ReadOnly Property ToSidePointRight() As PointD
            Get
                Return oToSidePointRight
            End Get
        End Property

        Public ReadOnly Property ToSidePointLeft() As PointD
            Get
                Return oToSidePointLeft
            End Get
        End Property

        Friend Sub SetPoint(ByVal FromSidePointRight As PointD, ByVal FromSidePointLeft As PointD, ByVal ToSidePointRight As PointD, ByVal ToSidePointLeft As PointD)
            oFromSidePointRight = FromSidePointRight
            oFromSidePointLeft = FromSidePointLeft
            oToSidePointRight = ToSidePointRight
            oToSidePointLeft = ToSidePointLeft
        End Sub

        Friend Sub New(ByVal FromSidePointRight As PointD, ByVal FromSidePointLeft As PointD, ByVal ToSidePointRight As PointD, ByVal ToSidePointLeft As PointD)
            oFromSidePointRight = FromSidePointRight
            oFromSidePointLeft = FromSidePointLeft
            oToSidePointRight = ToSidePointRight
            oToSidePointLeft = ToSidePointLeft
        End Sub
    End Class

End Namespace
