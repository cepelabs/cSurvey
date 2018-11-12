Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Calculate.Plot

Namespace cSurvey.Design.Design3D
    Public Class cDesign3D
        Implements cIDesign

        Private oSurvey As cSurvey
        Private oLayers As cLayers3D
        Private WithEvents oTool As cEdit3DTools

        Public Sub New(Survey As cSurvey)
            oSurvey = Survey
            oLayers = New cLayers3D(oSurvey, Me)
            oTool = New cEdit3DTools(oSurvey)
        End Sub

        Public ReadOnly Property Layers() As cILayers Implements cIDesign.Layers
            Get
                Return oLayers
            End Get
        End Property

        Public ReadOnly Property Type As cIDesign.cDesignTypeEnum Implements cIDesign.Type
            Get
                Return cIDesign.cDesignTypeEnum.ThreeDModel
            End Get
        End Property

        Public ReadOnly Property Plot As cPlot
            Get
                Return Nothing
            End Get
        End Property

        Friend Overloads ReadOnly Property Tool() As cEdit3DTools
            Get
                Return oTool
            End Get
        End Property

        Public Sub Clear()
        End Sub

        Public Function IsEmpty() As Boolean Implements cIDesign.IsEmpty
            For Each oLayer As cLayer In oLayers
                If oLayer.Items.Count > 0 Then Return False
            Next
            Return True
        End Function
    End Class
End Namespace
