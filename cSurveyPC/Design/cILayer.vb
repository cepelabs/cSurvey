Namespace cSurvey.Design
    Public Interface cILayer
        Enum LayerTypeEnum
            Base = 0
            Soil = 1
            WaterAndFloorMorphologies = 2
            RocksAndConcretion = 3
            CeilingMorphologies = 4
            Borders = 5
            Signs = 6
        End Enum

        ReadOnly Property Design() As cIDesign
        ReadOnly Property Name() As String
        ReadOnly Property Type() As cLayers.LayerTypeEnum
        Property HiddenInPreview As Boolean
        Property HiddenInDesign As Boolean
        Property Items As ciitems
    End Interface
End Namespace
