Imports System.Xml
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Scale
Imports cSurveyPC.cSurvey.Calculate

Namespace cSurvey
    Public Interface cIProfiles
        Function AddAsCopy(Profile As cIProfile, Name As String) As cIProfile
        Function Add(Name As String, Design As cIDesign.cDesignTypeEnum) As cIProfile
        Sub Remove(Index As Integer)
        Sub Remove(Item As cIProfile)
        Function Contains(Item As cIProfile) As Boolean
        Function IndexOf(Item As cIProfile) As Integer
        Sub Clear()
        Default ReadOnly Property Item(Index As Integer) As cIProfile
        ReadOnly Property Count As Integer

        Function ToArray() As cIProfile()
        Function ToList() As List(Of cIProfile)
    End Interface

    Public Interface cIProfile
        Property Name As String
        Property Note As String
        ReadOnly Property IsSystem As Boolean
        ReadOnly Property Design As cIDesign.cDesignTypeEnum
        ReadOnly Property Options As cOptionsCenterline

        Function IsPlan() As Boolean
        Function IsProfile() As Boolean

        ReadOnly Property Items As cVisibilityItems

        Event OnDelete(Sender As Object, e As EventArgs)
        Sub OnDeleting()
    End Interface
End Namespace
