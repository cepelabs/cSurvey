Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Scale
Imports cSurveyPC.cSurvey.Design.Items

Imports System.Xml
Imports System.Collections.ObjectModel

Namespace cSurvey.Design.Options

    Public Interface cISurfaceBaseOptionsItem
        ReadOnly Property ID As String

    End Interface
    Public Interface cISurfaceOptionsItem
        Inherits cISurfaceBaseOptionsItem
        Property Transparency As Single
        Property Visible As Boolean
    End Interface
End Namespace
