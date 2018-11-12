Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey
    Public Interface cIDesignCrossSectionsCollection
        Inherits IEnumerable

        ReadOnly Property Count() As Integer
        Function IndexOf(ByVal CrossSection As cdesigncrosssection) As Integer
        Function IndexOf(ByVal ID As String) As Integer
        Default ReadOnly Property Item(ByVal Index As Integer) As cDesignCrossSection
        Default ReadOnly Property Item(ByVal ID As String) As cDesignCrossSection
        Function Contains(ByVal CrossSection As cDesignCrossSection) As Boolean
        Function Contains(ByVal ID As String) As Boolean
        'Function Contains(ByVal CrossSection As cItemCrossSection) As Boolean
        'Function Find(ByVal CrossSection As cItemCrossSection) As cDesignCrossSection

        Function ToArray() As cDesignCrossSection()
    End Interface
End Namespace