Namespace cSurvey.Design.Items
    Public Interface cIItemLine
        Enum LineTypeEnum
            Undefined = -1
            Lines = &H0
            Splines = &H1
            Beziers = &H2
        End Enum

        Property LineType As LineTypeEnum
        Sub ReducePoints(Optional ByVal Factor As Single = 0.1)
    End Interface
End Namespace