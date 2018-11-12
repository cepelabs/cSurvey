Namespace cSurvey.Design.Items
    Public Interface cIItemCrossSectionSplayBorder
        Property SplayBorderLineStyle As cOptions.SplayStyleEnum
        Property ShowSplayBorder As Boolean
        Property ShowSplayText As Boolean
        Property ShowOnlyCutSplay As Boolean

        Property SplayBorderProjectionAngle As Integer
        Property SplayBorderMaxAngleVariation As Single
    End Interface

    Public Interface cIItemProfileSplayBorder
        Property SplayBorderProjectionAngle As Integer
        Property SplayBorderMaxAngleVariation As Single
        Property SplayBorderPosInclinationRange As SizeF
        Property SplayBorderNegInclinationRange As SizeF
    End Interface

    Public Interface cIItemPlanSplayBorder
        Enum PlanSplayBorderProjectionTypeEnum
            [All] = 0
            [ToCenterOfSegment] = 1
            [ToAltitude] = 2
        End Enum

        Property SplayBorderProjectionType As PlanSplayBorderProjectionTypeEnum
        Property SplayBorderProjectionDeltaZ As Single
        Property SplayBorderMaxDeltaVariation As Single
        Property SplayBorderInclinationRange As SizeF
    End Interface
End Namespace
