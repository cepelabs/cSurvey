Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports ClipperLib

Namespace cSurvey.Drawings
    Public Interface cIRegion
        Inherits IDisposable

        Enum RegionTypeEnum
            GDI = 0
            Clipper = 1
        End Enum

        Function Contains(Graphics As Graphics, Path As GraphicsPath) As Boolean
    End Interface
End Namespace