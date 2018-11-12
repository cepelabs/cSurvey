Namespace cSurvey.Design.Items
    Public Interface cIItemImage
        Inherits cIItemImageBase

        Enum ImageResizeModeEnum
            Scaled = 0
            Stretched = 1
        End Enum
        Property ImageResizeMode() As ImageResizeModeEnum
        Sub ImageRescale(ByVal Scale As Single)

    End Interface
End Namespace