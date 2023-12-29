Imports System.Xml
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design
    Public Class cLayer3D
        Inherits cLayer

        Public Shadows ReadOnly Property Design As cDesign3D
            Get
                Return MyBase.Design
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D, ByVal File As cFile, ByVal Layer As XmlElement)
            MyBase.New(Survey, Design, File, Layer)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D, ByVal Name As String, ByVal Type As cLayers.LayerTypeEnum)
            MyBase.New(Survey, Design, Name, Type)
        End Sub

        ''' <summary>
        ''' Create a design item from xml
        ''' </summary>
        ''' <param name="File">File container</param>
        ''' <param name="Item">XML Element</param>
        ''' <returns>The new design item</returns>
        Friend Shadows Function CreateItem(ByVal File As cFile, ByVal Item As XmlElement) As cItem
            Dim oItem As cItem = CreateItem(Survey, Design, Me, File, Item)
            If Not oItem Is Nothing Then
                Call MyBase.Items.Add(oItem)
            End If
            Return oItem
        End Function

        Friend Shadows Function CreateItem(ByVal Type As cIItem.cItemTypeEnum, ByVal Category As cIItem.cItemCategoryEnum, Filename As String) As cItem
            Dim oItem As cItem = Nothing
            Select Case Type
                Case cIItem.cItemTypeEnum.Chunk3D
                    oItem = New cItemChunk3D(Survey, Design, Me, Category, Filename)
            End Select
            If Not oItem Is Nothing Then
                Call MyBase.Items.Add(oItem)
            End If
            Return oItem
        End Function

        Friend Shared Shadows Function CreateItem(Survey As cSurvey, Design As cDesign3D, Layer As cLayer3D, File As cFile, Item As XmlElement) As cItem
            Dim oItem As cItem = Nothing
            Select Case Item.GetAttribute("type")
                Case cIItem.cItemTypeEnum.Chunk3D
                    oItem = New cItemChunk3D(Survey, Design, Layer, File, Item)
            End Select
            Return oItem
        End Function
    End Class
End Namespace
