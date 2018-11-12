Namespace cSurvey.Design.Items
    Public Interface cIItemCompass
        Inherits cIItemText
        Inherits cIItemClipartBase

        Enum CompassModeEnum
            Auto = 0
            Manual = 1
        End Enum

        Enum NorthTypeEnum
            Geographic = 0
            Magnetic = 1
        End Enum

        Property Mode As CompassModeEnum
        Property North As NorthTypeEnum
        Property Year As Integer

    End Interface
End Namespace