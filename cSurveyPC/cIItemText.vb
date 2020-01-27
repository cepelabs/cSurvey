Namespace cSurvey.Design.Items
    Public Interface cIItemText
        Inherits cIItemFont
        Inherits cIItemSizable

        Property Text As String

        <Flags> Enum AvaiableTextPropertiesEnum
            None = &H0
            Rotable = &H1
            Lineable = &H10
            VerticalLineable = &H100
        End Enum

        ReadOnly Property AvaiableTextProperties As AvaiableTextPropertiesEnum
    End Interface

    Public Interface cIItemSizable
        Enum SizeEnum
            [Default] = 0
            VerySmall = 1
            Small = 2
            Medium = 3
            Large = 4
            VeryLarge = 5
            x6 = 6
            x8 = 7
            x10 = 8
            x12 = 9
            x16 = 10
            x20 = 11
            x24 = 12
            x32 = 13
        End Enum

        Property Size As SizeEnum
    End Interface

    Public Interface cIItemRotable
        Enum RotateModeEnum
            Rotable = 0
            Fixed = 1
        End Enum

        Property RotateMode As RotateModeEnum
    End Interface

    Public Interface cIItemLineableText
        Enum TextAlignmentEnum
            Center = 0
            Left = 1
            Right = 2
        End Enum

        Property TextAlignment As TextAlignmentEnum
    End Interface

    Public Interface cIItemVerticalLineableText
        Enum TextVerticalAlignmentEnum
            Middle = 0
            Top = 1
            Bottom = 2
        End Enum

        Property TextVerticalAlignment As TextVerticalAlignmentEnum

    End Interface
End Namespace