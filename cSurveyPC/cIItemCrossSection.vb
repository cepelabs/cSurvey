Namespace cSurvey.Design.Items
    Public Interface cIItemCrossSection
        Enum DirectionEnum
            Direct = 0
            Inverted = 1
        End Enum

        Enum TextPositionEnum
            TopLeft = 0
            TopMiddle = 1
            TopRight = 2
            CenterLeft = 3
            Center = 4
            CenterRight = 5
            BottomLeft = 6
            BottomCenter = 7
            BottomRight = 8
        End Enum

        Enum RefStationEnum
            Automatic = 0
            NearStation = 1
            FarStation = 2
        End Enum

        Property RefStation As RefStationEnum

        Property CrossWidth As Single
        Property CrossHeight As Single
        Property CrossSize As SizeF

        Property TextDistance() As Single
        Property TextPosition() As TextPositionEnum

        Property MoveBindedObjects As Boolean

        Property Direction As DirectionEnum

        'Property ShowMarker As Boolean
        'Property MarkerPlanDeltaAngle As Single
        'Property MarkerL As Single
        'Property MarkerR As Single
        'Property MarkerU As Single
        'Property MarkerD As Single
        Property MarkerPosition As Single

        'Sub SetMarkerUDFromDesign(ByVal PaintOptions As cOptions)
        'Sub SetMarkerLRFromDesign(ByVal PaintOptions As cOptions)

        'Enum MarkerPlanAlignmentEnum
        '    Left = 0
        '    Right = 1
        'End Enum

        'Enum MarkerProfileAlignmentEnum
        '    Up = 0
        '    Down = 1
        'End Enum

        'Property MarkerPlanAlignment As MarkerPlanAlignmentEnum
        'Property MarkerProfileAlignment As MarkerProfileAlignmentEnum

        ReadOnly Property DesignCrossSection As cDesignCrossSection
    End Interface

    'Public Interface cIItemCrossSectionMarker
    '    Enum TextPositionEnum
    '        Left = 0
    '        Middle = 1
    '        Right = 2
    '    End Enum

    '    Property MarkerTextPosition As cIItemCrossSectionMarker.TextPositionEnum
    '    Property MarkerTextDistance As Single

    '    Property ShowMarker As Boolean
    '    Property MarkerPlanDeltaAngle As Single
    '    Property MarkerL As Single
    '    Property MarkerR As Single
    '    Property MarkerU As Single
    '    Property MarkerD As Single
    '    Property MarkerPosition As Single

    '    Sub SetMarkerUDFromDesign(ByVal PaintOptions As cOptions)
    '    Sub SetMarkerLRFromDesign(ByVal PaintOptions As cOptions)

    '    Enum MarkerPlanAlignmentEnum
    '        Left = 0
    '        Right = 1
    '    End Enum

    '    Enum MarkerProfileAlignmentEnum
    '        Up = 0
    '        Down = 1
    '    End Enum

    '    Property MarkerPlanAlignment As MarkerPlanAlignmentEnum
    '    Property MarkerProfileAlignment As MarkerProfileAlignmentEnum
    'End Interface

    Public Interface cIItemCrossSectionMarker
        Enum TextPositionEnum
            AsArrow = 0
            Middle = 1
            OppositeSide = 2
        End Enum

        Property ArrowSizeEnabled As Boolean
        Property ArrowSize As cIItemText.TextSizeEnum

        Property TextShow As Boolean
        Property TextPosition As cIItemCrossSectionMarker.TextPositionEnum
        Property TextDistance As Single
        Property TextSize As cIItemText.TextSizeEnum
        Property TextSizeEnabled As Boolean

        Property Position As Single

        ReadOnly Property DesignCrossSection As cDesignCrossSection
        ReadOnly Property CrossSectionItem As cItemCrossSection
    End Interface

    Public Interface cIItemPlanCrossSectionMarker
        Inherits cIItemCrossSectionMarker
        Inherits cIItemRotableText

        Property PlanDeltaAngleEnabled As Boolean
        Property PlanDeltaAngle As Single
        Property Left As Single
        Property Right As Single
        Property LeftWidth As Single
        Property RightWidth As Single
        Property AutoLeftWidth As Boolean
        Property AutoRightWidth As Boolean

        Sub SetLRFromDesign(ByVal PaintOptions As cOptions)

        Enum PlanAlignmentEnum
            Left = 0
            Right = 1
        End Enum

        Property PlanAlignment As PlanAlignmentEnum
    End Interface

    Public Interface cIItemProfileCrossSectionMarker
        Inherits cIItemCrossSectionMarker
        Inherits cIItemRotableText

        Property Up As Single
        Property Down As Single
        Property UpHeight As Single
        Property DownHeight As Single
        Property AutoUpHeight As Boolean
        Property AutoDownHeight As Boolean

        Sub SetUDFromDesign(ByVal PaintOptions As cOptions)

        Enum ProfileAlignmentEnum
            Up = 0
            Down = 1
        End Enum

        Property ProfileAlignment As ProfileAlignmentEnum
        Property ProfileDeltaAngleEnabled As Boolean
        Property ProfileDeltaAngle As Single
    End Interface
End Namespace