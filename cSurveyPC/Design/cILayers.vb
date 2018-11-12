Imports cSurveyPC.cSurvey.Design

Public Interface cILayers
    Inherits IEnumerable

    Enum LayerTypeEnum
        Base = 0
        Soil = 1
        WaterAndFloorMorphologies = 2
        RocksAndConcretion = 3
        CeilingMorphologies = 4
        Borders = 5
        Signs = 6
    End Enum

    Sub Clear()
    Default ReadOnly Property Item(ByVal Index As LayerTypeEnum) As cILayer
    ReadOnly Property Count() As Integer
    Function ToArray() As cILayer()
    Function IndexOf(ByVal Layer As cILayer) As Integer
End Interface
