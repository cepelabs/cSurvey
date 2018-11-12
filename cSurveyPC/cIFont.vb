Namespace cSurvey
    Public Interface cIFont
        Inherits IDisposable

        Function Clone() As cIFont

        Property FontName As String
        Property FontSize As Single
        Property FontUnderline As Boolean
        Property FontItalic As Boolean
        Property FontBold As Boolean

        ReadOnly Property FontStyle As FontStyle

        Property Color As Color

        Function GetSampleFont() As Font
    End Interface
End Namespace