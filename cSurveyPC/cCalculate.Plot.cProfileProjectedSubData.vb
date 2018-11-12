Imports cSurveyPC.cSurvey.cSurvey

Namespace cSurvey.Calculate.Plot
    Friend Class cProfileProjectedSubData
        'gestisce i capisaldi dell'oversampling della battuta di poligonale 'parent'
        'i dati LRUD SONO SEMPRE PERPENDICOLARI ALLA BATTUTA!!!!!!!!!!!
        Implements cISpatialData
        Implements cIProfileProjectedData

        Private oParent As cData

        Private [sFrom] As String
        Private [sTo] As String
        Private oFromPoint As PointF
        Private oToPoint As PointF

        Private oFromSidePointUp As PointD
        Private oFromSidePointDown As PointD
        Private oToSidePointUp As PointD
        Private oToSidePointDown As PointD
        Private dFromUp As Decimal
        Private dFromDown As Decimal
        Private dToUp As Decimal
        Private dToDown As Decimal

        Private dDistance As Decimal

        Public ReadOnly Property ToUp As Decimal
            Get
                Return dToUp
            End Get
        End Property

        Public ReadOnly Property ToDown As Decimal
            Get
                Return dToDown
            End Get
        End Property

        Public ReadOnly Property FromUp As Decimal
            Get
                Return dFromUp
            End Get
        End Property

        Public ReadOnly Property FromDown As Decimal
            Get
                Return dFromDown
            End Get
        End Property

        Public Function GetCenterPoint() As PointD Implements cIProfileProjectedData.GetCenterPoint
            Return New PointD(oFromPoint.X - (oFromPoint.X - oToPoint.X) / 2, oFromPoint.Y - (oFromPoint.Y - oToPoint.Y) / 2)
        End Function

        Public ReadOnly Property FromSidePointDown() As PointD Implements cIProfileProjectedData.FromSidePointDown
            Get
                Return oFromSidePointDown
            End Get
        End Property

        Public ReadOnly Property FromSidePointUp() As PointD Implements cIProfileProjectedData.FromSidePointUp
            Get
                Return oFromSidePointUp
            End Get
        End Property

        Public ReadOnly Property ToSidePointDown() As PointD Implements cIProfileProjectedData.ToSidePointDown
            Get
                Return oToSidePointDown
            End Get
        End Property

        Public ReadOnly Property ToSidePointUp() As PointD Implements cIProfileProjectedData.ToSidePointUp
            Get
                Return oToSidePointUp
            End Get
        End Property

        Public ReadOnly Property FromPoint() As PointD Implements cIProfileProjectedData.FromPoint
            Get
                Return oFromPoint
            End Get
        End Property

        Public ReadOnly Property ToPoint() As PointD Implements cIProfileProjectedData.ToPoint
            Get
                Return oToPoint
            End Get
        End Property

        Private Sub pUpdateSidePoints()
            'dati del caposaldo di inizio
            oFromSidePointDown = New PointF(oFromPoint.X, oFromPoint.Y + dFromDown)
            oFromSidePointUp = New PointF(oFromPoint.X, oFromPoint.Y - dFromUp)
            'e di fine
            oToSidePointDown = New PointF(oToPoint.X, oToPoint.Y + dToDown)
            oToSidePointUp = New PointF(oToPoint.X, oToPoint.Y - dToUp)
        End Sub

        Public ReadOnly Property Distance As Decimal Implements cISpatialData.Distance
            Get
                Return dDistance
            End Get
        End Property

        Public ReadOnly Property Inclination As Decimal Implements cISpatialData.Inclination
            Get
                Return oParent.Data.Inclination
            End Get
        End Property

        Public ReadOnly Property Bearing As Decimal Implements cISpatialData.Bearing
            Get
                Return oParent.Data.Bearing
            End Get
        End Property

        Public ReadOnly Property [To] As String Implements cISpatialData.To, cIProfileProjectedData.To
            Get
                Return sTo
            End Get
        End Property

        Public ReadOnly Property From As String Implements cISpatialData.From, cIProfileProjectedData.From
            Get
                Return sFrom
            End Get
        End Property

        Friend Sub SetUD(FromUp As Decimal, FromDown As Decimal, ToUp As Decimal, ToDown As Decimal)
            dFromUp = FromUp
            dFromDown = FromDown
            dToUp = ToUp
            dToDown = ToDown
            Call pUpdateSidePoints()
        End Sub

        Friend Sub New(Parent As cData, [From] As String, [To] As String, Distance As Decimal)
            oParent = Parent
            sFrom = [From]
            sTo = [To]
            dDistance = Distance
        End Sub

        Friend Sub New(Parent As cData, [From] As String, [To] As String, Distance As Decimal, FromUp As Decimal, FromDown As Decimal, ToUp As Decimal, ToDown As Decimal)
            oParent = Parent
            sFrom = [From]
            sTo = [To]
            dDistance = Distance
            dFromUp = FromUp
            dFromDown = FromDown
            dToUp = ToUp
            dToDown = ToDown
            Call pUpdateSidePoints()
        End Sub

        Public ReadOnly Property Reversed As Boolean Implements cISpatialData.Reversed, cIProfileProjectedData.Reversed
            Get
                Return oParent.Data.Reversed
            End Get
        End Property

        Public ReadOnly Property Direction As DirectionEnum Implements cISpatialData.Direction, cIProfileProjectedData.Direction
            Get
                Return oParent.Data.Direction
            End Get
        End Property
    End Class
End Namespace
