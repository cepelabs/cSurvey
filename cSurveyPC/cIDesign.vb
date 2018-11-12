Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design
    Public Interface cIDesign
        Enum cDesignTypeEnum
            Unknown = -1
            Plan = 0
            Profile = 1
            ThreeDModel = 2
        End Enum

        ReadOnly Property Type As cIDesign.cDesignTypeEnum


    End Interface
End Namespace
