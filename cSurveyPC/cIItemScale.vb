Namespace cSurvey.Design.Items
    Public Interface cIItemScale
        Inherits cIItemText

        Property Steps As Integer
        Property StepLength As Integer
        Property Length As Integer
        Property HideScaleValue As Boolean
        Property ScaleHeightFactor As Single

        Enum ScaleFillStyleEnum
            Solid = 0
            Alternate = 1
        End Enum
        Property ScaleFillStyle As ScaleFillStyleEnum
    End Interface
End Namespace