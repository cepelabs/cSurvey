﻿Namespace cSurvey.Design.Items
    Public Interface cIItemQuota
        Inherits cIItemText

        Enum QuotaTypeEnum
            Vertical = 0
            Horizontal = 1
            Oblique = 2
            Drop = 3
            Altitude = 4
            VerticalScale = 5
            HorizontalScale = 6
            GridScale = 7
        End Enum

        Enum QuotaAlignEnum
            Left = 0
            Right = 1
            Center = 2
        End Enum

        Enum QuotaValueEnum
            Automatic = 0
            Manual = 1
        End Enum

        Enum QuotaCapDecorationEnum
            None = 0
            Arrow = 1
            Circle = 2
        End Enum

        Enum QuotaValueTypeEnum
            [Default] = 0
            Meters = 1
            Feet = 2
            Yards = 3
        End Enum

        Enum QuotaTextPositionEnum
            LeftTop = 0
            RightBottom = 1
        End Enum

        Property QuotaType As QuotaTypeEnum
        Property QuotaAlign As QuotaAlignEnum
        Property QuotaTextPosition As QuotaTextPositionEnum

        Property QuotaValue As QuotaValueEnum
        Property QuotaFormat As String

        Property QuotaValueType As QuotaValueTypeEnum

        Property QuotaRelativeTrigPoint As String

        Property QuotaTickFrequency As Integer
        Property QuotaTickLabelFrequency As Integer
        Property QuotaTickSize As Single

        Property QuotaCapDecoration As QuotaCapDecorationEnum
        Property QuotaLeftRefPercent As Single
        Property QuotaRightRefPercent As Single
    End Interface
End Namespace
