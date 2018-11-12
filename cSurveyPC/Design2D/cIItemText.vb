Namespace cSurvey.Design.Items
    Public Interface cIItemText
        Inherits ciItemFont

        Enum TextSizeEnum
            [Default] = 0
            VerySmall = 1
            Small = 2
            Medium = 3
            Large = 4
            VeryLarge = 5
        End Enum

        Property Text As String
        Property TextSize As TextSizeEnum

        <Flags> Enum AvaiableTextPropertiesEnum
            None = &H0
            Rotable = &H1
            Lineable = &H10
            VerticalLineable = &H100
        End Enum
        ReadOnly Property AvaiableTextProperties As AvaiableTextPropertiesEnum
    End Interface

    Public Interface cIItemRotableText
        Enum TextRotateModeEnum
            Rotable = 0
            Fixed = 1
        End Enum

        Property TextRotateMode As TextRotateModeEnum
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