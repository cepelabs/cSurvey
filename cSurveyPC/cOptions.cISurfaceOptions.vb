Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Scale
Imports cSurveyPC.cSurvey.Design.Items

Imports System.Xml
Imports System.Collections.ObjectModel

Namespace cSurvey.Design.Options
    Public Interface cISurfaceOptionsItem
        Property Transparency As Single
        Property Visible As Boolean
        ReadOnly Property ID As String
    End Interface
End Namespace
