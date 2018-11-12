Namespace cSurvey.Design
    Public Interface cIItem
        Enum cItemCategoryEnum As Integer
            None = &H0
            CaveBorder = &H1
            Border = &H2
            LevelLine = &H3

            Rock = &H20
            Concretion = &H21

            Soil = &H30

            WaterArea = &H40

            Sign = &H50
            Text = &H51
            Quota = &H52
            CrossSection = &H60

            Image = &H70
            Sketch = &H71
        End Enum

        Enum cItemTypeEnum As Integer
            Items = 0

            FreeHandLine = 1
            'Area = 2
            FreeHandArea = 3
            InvertedFreeHandArea = 4
            Clipart = 5
            Sign = 6
            Image = 7
            Text = 8
            CrossSection = 9
            Quota = 10
            Sketch = 11

            CrossSectionMarker = 29

            Group = 50

            Marker = 96
            Trigpoint = 97
            Segment = 98
            Generic = 99
        End Enum

        Property Name As String
        ReadOnly Property Cave As String
        ReadOnly Property Branch As String
        ReadOnly Property Type As cIItem.cItemTypeEnum
        ReadOnly Property Category As cIItem.cItemCategoryEnum

        Sub SetCave(ByVal Cave As String, Optional ByVal Branch As String = "", Optional ByVal BindSegment As Boolean = True)

        ReadOnly Property Layer As cILayer
        ReadOnly Property Design As cIDesign

        ReadOnly Property Deleted As Boolean
        Property HiddenInPreview As Boolean
        Property HiddenInDesign As Boolean
    End Interface
End Namespace
