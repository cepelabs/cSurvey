Namespace cSurvey
    Public Interface cISurfaceProfile
        Enum SurfaceProfileShowEnum
            [Default] = 0
            [Visible] = 1
            [Hidden] = 2
        End Enum

        Property SurfaceProfileShow As SurfaceProfileShowEnum
        Function GetSurfaceProfileShow() As Boolean
    End Interface


End Namespace
