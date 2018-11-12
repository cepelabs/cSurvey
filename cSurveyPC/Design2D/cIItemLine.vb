Namespace cSurvey.Design.Items
    Public Interface cIItemLine
        Enum LineTypeEnum
            Undefined = -1
            Lines = 0
            Splines = 1
            Beziers = 2
        End Enum

        Property LineType As LineTypeEnum
        Sub ReducePoints(Optional ByVal Factor As Single = 0.1)
    End Interface
End Namespace