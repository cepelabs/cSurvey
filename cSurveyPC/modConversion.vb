Module modConversion

    Public Function ConvertSegmentToBaseDistance(Value As Single, Segment As cSurvey.cSegment) As Single
        Select Case Segment.GetDistanceType
            Case cSurvey.cSegment.DistanceTypeEnum.Feet
                Return FeetToMeter(Value)
            Case cSurvey.cSegment.DistanceTypeEnum.Yards
                Return YardsToMeter(Value)
            Case Else
                Return Value
        End Select
    End Function

    Public Function ConvertSegmentToBaseBearing(Value As Single, Segment As cSurvey.cSegment) As Single
        Select Case Segment.GetDistanceType
            Case cSurvey.cSegment.BearingTypeEnum.CentesimalDegree
                Return GradToDegree(Value)
            Case Else
                Return Value
        End Select
    End Function

    Public Function ConvertSegmentToBaseInclination(Value As Single, Segment As cSurvey.cSegment) As Single
        Select Case Segment.GetDistanceType
            Case cSurvey.cSegment.BearingTypeEnum.CentesimalDegree
                Return GradToDegree(Value)
                'Case cSurvey.cSegment.InclinationTypeEnum.Percentage
                'Return DegreeTopercentag(Value)
            Case Else
                Return Value
        End Select
    End Function

    Public Function ConvertBaseToSegmentDistance(Value As Single, Segment As cSurvey.cSegment) As Single
        Select Case Segment.GetDistanceType
            Case cSurvey.cSegment.DistanceTypeEnum.Feet
                Return MetersToFeet(Value)
            Case cSurvey.cSegment.DistanceTypeEnum.Yards
                Return MetersToYards(Value)
            Case Else
                Return Value
        End Select
    End Function

    Public Function ConvertBaseToSegmentBearing(Value As Single, Segment As cSurvey.cSegment) As Single
        Select Case Segment.GetDistanceType
            Case cSurvey.cSegment.BearingTypeEnum.CentesimalDegree
                Return DegreeToGrad(Value)
            Case Else
                Return Value
        End Select
    End Function

    Public Function ConvertBaseToSegmentInclination(Value As Single, Segment As cSurvey.cSegment) As Single
        Select Case Segment.GetDistanceType
            Case cSurvey.cSegment.BearingTypeEnum.CentesimalDegree
                Return DegreeToGrad(Value)
                'Case cSurvey.cSegment.InclinationTypeEnum.Percentage
                'Return DegreeTopercentag(Value)
            Case Else
                Return Value
        End Select
    End Function

    Public Function GetDistanceTypeDecimalPlaces(DistanceType As cSurvey.cSegment.DistanceTypeEnum) As Single
        Select Case DistanceType
            Case cSurvey.cSegment.DistanceTypeEnum.Feet
                Return 0
            Case cSurvey.cSegment.DistanceTypeEnum.Yards
                Return 0
            Case Else
                Return 0
        End Select
    End Function

    Public Function ConvertBaseToDefaultDistance(Value As Single, Survey As cSurvey.cSurvey) As Single
        Select Case Survey.Properties.DistanceType
            Case cSurvey.cSegment.DistanceTypeEnum.Feet
                Return MetersToFeet(Value)
            Case cSurvey.cSegment.DistanceTypeEnum.Yards
                Return MetersToYards(Value)
            Case Else
                Return Value
        End Select
    End Function

    Public Function ConvertBaseToDefaultBearing(Value As Single, Survey As cSurvey.cSurvey) As Single
        Select Case Survey.Properties.BearingType
            Case cSurvey.cSegment.BearingTypeEnum.CentesimalDegree
                Return DegreeToGrad(Value)
            Case Else
                Return Value
        End Select
    End Function

    Public Function ConvertBaseToDefaultInclination(Value As Single, Survey As cSurvey.cSurvey) As Single
        Select Case Survey.Properties.InclinationType
            Case cSurvey.cSegment.BearingTypeEnum.CentesimalDegree
                Return DegreeToGrad(Value)
                'Case cSurvey.cSegment.InclinationTypeEnum.Percentage
                'Return DegreeTopercentag(Value)
            Case Else
                Return Value
        End Select
    End Function

    Public Function ConvertDefaultToBaseDistance(Value As Single, Survey As cSurvey.cSurvey) As Single
        Select Case Survey.Properties.DistanceType
            Case cSurvey.cSegment.DistanceTypeEnum.Feet
                Return FeetToMeter(Value)
            Case cSurvey.cSegment.DistanceTypeEnum.Yards
                Return YardsToMeter(Value)
            Case Else
                Return Value
        End Select
    End Function

    Public Function ConvertDefaultToBaseBearing(Value As Single, Survey As cSurvey.cSurvey) As Single
        Select Case Survey.Properties.BearingType
            Case cSurvey.cSegment.BearingTypeEnum.CentesimalDegree
                Return GradToDegree(Value)
            Case Else
                Return Value
        End Select
    End Function

    Public Function ConvertDefaultToBaseInclination(Value As Single, Survey As cSurvey.cSurvey) As Single
        Select Case Survey.Properties.InclinationType
            Case cSurvey.cSegment.BearingTypeEnum.CentesimalDegree
                Return GradToDegree(Value)
                'Case cSurvey.cSegment.InclinationTypeEnum.Percentage
                'Return DegreeTopercentag(Value)
            Case Else
                Return Value
        End Select
    End Function

    Public Function MetersToFeet(Value As Single) As Single
        Return modNumbers.MathRound(Value * 3.2808399, 3)
    End Function

    Public Function FeetToMeter(Value As Single) As Single
        Return modNumbers.MathRound(Value / 3.2808399, 3)
    End Function

    Public Function MetersToYards(Value As Single) As Single
        Return modNumbers.MathRound(Value * 1.0936133, 3)
    End Function

    Public Function YardsToMeter(Value As Single) As Single
        Return modNumbers.MathRound(Value / 1.0936133, 3)
    End Function

    Public Function DegreeToGrad(Value As Single) As Single
        Return modNumbers.MathRound(Value * 10 / 9, 3)
    End Function

    Public Function GradToDegree(Value As Single) As Single
        Return modNumbers.MathRound(Value * 9 / 10, 3)
    End Function
End Module
