Imports cSurveyPC.cSurvey.cSurvey

Namespace cSurvey.Calculate.Plot
    Friend Class cPlanProjectedSubData
        Implements cISpatialData
        Implements cIPlanProjectedData
        'gestisce i capisaldi dell'oversampling della battuta di poligonale 'parent'
        'i dati LRUD SONO SEMPRE PERPENDICOLARI ALLA BATTUTA!!!!!!!!!!!

        Private oParent As cData

        Private [sFrom] As String
        Private [sTo] As String
        Private oFromPoint As PointD
        Private oToPoint As PointD

        Private oFromSidePointRight As PointD
        Private oFromSidePointLeft As PointD
        Private oToSidePointRight As PointD
        Private oToSidePointLeft As PointD
        Private dFromRight As Decimal
        Private dFromLeft As Decimal
        Private dToRight As Decimal
        Private dToLeft As Decimal

        Private bReversed As Boolean
        Private dDistance As Decimal

        Public ReadOnly Property ToLeft As Decimal
            Get
                Return dToLeft
            End Get
        End Property

        Public ReadOnly Property ToRight As Decimal
            Get
                Return dToRight
            End Get
        End Property

        Public ReadOnly Property FromLeft As Decimal
            Get
                Return dFromLeft
            End Get
        End Property

        Public ReadOnly Property FromRight As Decimal
            Get
                Return dFromRight
            End Get
        End Property

        Public ReadOnly Property FromPoint() As PointD Implements cIPlanProjectedData.FromPoint
            Get
                Return oFromPoint
            End Get
        End Property

        Public ReadOnly Property ToPoint() As PointD Implements cIPlanProjectedData.ToPoint
            Get
                Return oToPoint
            End Get
        End Property

        Public Function GetCenterPoint() As PointD Implements cIPlanProjectedData.GetCenterPoint
            Return New PointD(oFromPoint.X - (oFromPoint.X - oToPoint.X) / 2, oFromPoint.Y - (oFromPoint.Y - oToPoint.Y) / 2)
        End Function

        Public ReadOnly Property FromSidePointRight() As PointD Implements cIPlanProjectedData.FromSidePointRight
            Get
                Return oFromSidePointRight
            End Get
        End Property

        Public ReadOnly Property FromSidePointLeft() As PointD Implements cIPlanProjectedData.FromSidePointLeft
            Get
                Return oFromSidePointLeft
            End Get
        End Property

        Public ReadOnly Property ToSidePointRight() As PointD Implements cIPlanProjectedData.ToSidePointRight
            Get
                Return oToSidePointRight
            End Get
        End Property

        Public ReadOnly Property ToSidePointLeft() As PointD Implements cIPlanProjectedData.ToSidePointLeft
            Get
                Return oToSidePointLeft
            End Get
        End Property

        'Friend Sub SetToLRUDData(Left As Decimal, Right As Decimal, Up As Decimal, Down As Decimal)
        '    Call oToLRUD.SetData(Left, Right, Up, Down)
        'End Sub

        'Friend Sub SetFromLRUDData(Left As Decimal, Right As Decimal, Up As Decimal, Down As Decimal)
        '    Call oFromLRUD.SetData(Left, Right, Up, Down)
        'End Sub

        'Friend Sub UpdateSidePoints()
        '    Call pUpdatePlanSidePoints()
        '    Call pUpdateProfileSidePoints()
        'End Sub

        Private Sub pUpdateSidePoints()
            Dim dBearing As Decimal = oParent.Data.Bearing
            Dim oDiff As SizeD

            If dFromLeft = 0 Then
                oFromSidePointLeft = oFromPoint
            Else
                oDiff = modPaint.Trigo(dFromLeft, modPaint.AddAngle(dBearing, -90))
                oFromSidePointLeft = New PointD(oFromPoint.X + oDiff.Width, oFromPoint.Y + oDiff.Height)
            End If
            If dFromRight = 0 Then
                oFromSidePointRight = oFromPoint
            Else
                oDiff = modPaint.Trigo(dFromRight, modPaint.AddAngle(dBearing, +90))
                oFromSidePointRight = New PointD(oFromPoint.X + oDiff.Width, oFromPoint.Y + oDiff.Height)
            End If

            If dToLeft = 0 Then
                oToSidePointLeft = oToPoint
            Else
                oDiff = modPaint.Trigo(dToLeft, modPaint.AddAngle(dBearing, -90))
                oToSidePointLeft = New PointD(oToPoint.X + oDiff.Width, oToPoint.Y + oDiff.Height)
            End If
            If dToRight = 0 Then
                oToSidePointRight = oToPoint
            Else
                oDiff = modPaint.Trigo(dToRight, modPaint.AddAngle(dBearing, +90))
                oToSidePointRight = New PointD(oToPoint.X + oDiff.Width, oToPoint.Y + oDiff.Height)
            End If
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

        Public ReadOnly Property [To] As String Implements cISpatialData.To, cIPlanProjectedData.To
            Get
                Return sTo
            End Get
        End Property

        Public ReadOnly Property From As String Implements cISpatialData.From, cIPlanProjectedData.From
            Get
                Return sFrom
            End Get
        End Property

        Friend Sub SetLR(FromLeft As Decimal, FromRight As Decimal, ToLeft As Decimal, ToRight As Decimal)
            dFromLeft = FromLeft
            dFromRight = FromRight
            dToLeft = ToLeft
            dToRight = ToRight
            Call pUpdateSidePoints()
        End Sub

        Public Sub New(Parent As cData, [From] As String, [To] As String, Distance As Decimal)
            oParent = Parent
            sFrom = [From]
            sTo = [To]
            dDistance = Distance
        End Sub

        Public Sub New(Parent As cData, [From] As String, [To] As String, Distance As Decimal, FromLeft As Decimal, FromRight As Decimal, ToLeft As Decimal, ToRight As Decimal)
            oParent = Parent
            sFrom = [From]
            sTo = [To]
            dDistance = Distance
            dfromLeft = FromLeft
            dfromRight = FromRight
            dtoLeft = ToLeft
            dToRight = ToRight
            Call pUpdateSidePoints()
        End Sub

        Public ReadOnly Property Reversed As Boolean Implements cISpatialData.Reversed, cIPlanProjectedData.Reversed
            Get
                Return oParent.SourceData.Reversed
            End Get
        End Property

        Public ReadOnly Property Direction As DirectionEnum Implements cISpatialData.Direction
            Get
                Return oParent.SourceData.Direction
            End Get
        End Property
    End Class
End Namespace
