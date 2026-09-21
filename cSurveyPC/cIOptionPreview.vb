Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design
    Public Interface cIOptionsPreview
        Enum ScaleModeEnum
            sAutomatic = 0
            s100 = 1
            s200 = 2
            s250 = 3
            s500 = 4
            s1000 = 5
            sManual = 99
        End Enum

        Property ScaleMode() As ScaleModeEnum
        Property Scale() As Integer


        Enum AdvancedClippingModeEnum
            Standard = 0
            HierarchicClipping = 1
        End Enum

        Property AdvancedClippingMode As AdvancedClippingModeEnum

        Property UseCaveBranchColorAsDefaultItemColor As Boolean
    End Interface
End Namespace