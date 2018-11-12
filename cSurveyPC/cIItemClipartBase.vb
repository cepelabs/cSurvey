Namespace cSurvey.Design.Items
    Public Interface cIItemClipartBase
        Enum cClipartDataFormatEnum
            SVGData = 0
            SVGFile = 1
            SVGResource = 2
            'Items=3
        End Enum

        ReadOnly Property Clipart As cClipart
    End Interface
End Namespace
