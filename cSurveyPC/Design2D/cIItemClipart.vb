Namespace cSurvey.Design.Items
    Public Interface cIItemClipart
        Enum ClipartResizeModeEnum
            Stretched = 0
            Scaled = 1
        End Enum

        Property ClipartResizeMode() As cIItemClipart.ClipartResizeModeEnum

        ReadOnly Property Clipart As cClipart
    End Interface
End Namespace
