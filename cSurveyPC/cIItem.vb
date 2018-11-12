Namespace cSurvey.Design.Items
    Public Interface cIItem
        Inherits cICaveBranch

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
            Compass = &H53
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
            Attachment = 12
            Legend = 13
            Scale = 14
            Compass = 15
            InformationBoxText = 16

            CrossSectionMarker = 29


            Group = 50

            Marker = 96
            Trigpoint = 97
            Segment = 98
            Generic = 99
        End Enum

        Property Name As String
        ReadOnly Property CrossSection As String
        ReadOnly Property Type As cIItem.cItemTypeEnum
        ReadOnly Property Category As cIItem.cItemCategoryEnum

        Sub SetCave(ByVal Cave As String, Optional ByVal Branch As String = "", Optional ByVal BindSegment As Boolean = True)
    End Interface
End Namespace
