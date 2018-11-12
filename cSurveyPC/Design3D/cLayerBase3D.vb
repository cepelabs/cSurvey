Imports System.Xml
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design.Design3D.Layers
    Public Class cLayerBase3D
        Inherits cLayer3D

        Private oDesign As cDesign3D

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D, ByVal File As Storage.cFile, ByVal Layer As XmlElement)
            MyBase.New(Survey, Design, File, Layer)
            oDesign = Design
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D, ByVal Name As String)
            MyBase.New(Survey, Design, Name, cLayers3D.LayerTypeEnum.Base)
            oDesign = Design
        End Sub

        Public Function CreateAbsolutePositionedItem(ByVal Cave As String, ByVal Branch As String, ByVal Model As Object) As cItem3D
            'Dim oItem As cItem3D = MyBase.CreateItem(cIItem.cItemTypeEnum.Image, cIItem.cItemCategoryEnum.Image, Image)
            'Call oItem.SetCave(Cave, Branch)
            'Return oItem
        End Function
    End Class
End Namespace
