Imports System.Xml
Imports System.Drawing.Drawing2D

Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Imports cSurveyPC.XSystem.Linq.Dynamic
Imports System.Linq.Expressions

Namespace cSurvey.Design.Design3D
    Public Class cLayer3D
        Private oSurvey As cSurvey
        Private oDesign As cDesign3D

        Private sName As String
        Private iType As cILayers.LayerTypeEnum
        Private oItems As cItems3D

        Private bHiddenInDesign As Boolean
        Private bHiddenInPreview As Boolean


        Public Property HiddenInDesign As Boolean
            Get
                Return bHiddenInDesign
            End Get
            Set(ByVal value As Boolean)
                bHiddenInDesign = value
            End Set
        End Property

        Public Property HiddenInPreview As Boolean
            Get
                Return bHiddenInPreview
            End Get
            Set(ByVal value As Boolean)
                bHiddenInPreview = value
            End Set
        End Property

        Public ReadOnly Property Design() As cDesign3D
            Get
                Return oDesign
            End Get
        End Property

        Public ReadOnly Property Name() As String
            Get
                Return sName
            End Get
        End Property

        Public ReadOnly Property Type() As cILayers.LayerTypeEnum
            Get
                Return iType
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D, ByVal File As Storage.cFile, ByVal Layer As XmlElement)
            oSurvey = Survey
            oDesign = Design
            sName = modXML.GetAttributeValue(Layer, "name")
            iType = modXML.GetAttributeValue(Layer, "type")
            bHiddenInDesign = modXML.GetAttributeValue(Layer, "hiddenindesign")
            bHiddenInPreview = modXML.GetAttributeValue(Layer, "hiddeninpreview")
            oItems = New cItems3D(oSurvey, Design, Me, File, Layer.Item("items"))
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXmlLayer As XmlElement = Document.CreateElement("layer")
            Call oXmlLayer.SetAttribute("name", sName)
            Call oXmlLayer.SetAttribute("type", iType)
            If bHiddenInDesign Then Call oXmlLayer.SetAttribute("hiddenindesign", IIf(bHiddenInDesign, 1, 0))
            If bHiddenInPreview Then Call oXmlLayer.SetAttribute("hiddeninpreview", IIf(bHiddenInPreview, 1, 0))
            Call oItems.SaveTo(File, Document, oXmlLayer, Options)
            Call Parent.AppendChild(oXmlLayer)
            Return oXmlLayer
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D, ByVal Name As String, ByVal Type As cILayers.LayerTypeEnum)
            oSurvey = Survey
            oDesign = Design
            sName = Name
            iType = Type
            oItems = New cItems3D(oSurvey, Design, Me)
        End Sub

        Friend Function CreateItem(ByVal File As Storage.cFile, ByVal Item As XmlElement) As cItem3D
            Dim oItem As cItem3D = Nothing
            Select Case Item.GetAttribute("type")
            End Select
            If Not oItem Is Nothing Then
                Call oItems.Add(oItem)
            End If
            Return oItem
        End Function

        Friend Function CreateItem(ByVal Type As cIItem.cItemTypeEnum, ByVal Category As cIItem.cItemCategoryEnum, ByVal Segment As cSegment) As cItem3D
            Dim oItem As cItem3D = Nothing
            Select Case Type
            End Select
            If Not oItem Is Nothing Then
                Call oItems.Add(oItem)
            End If
            Return oItem
        End Function

        Friend Function CreateItem(ByVal Type As cIItem.cItemTypeEnum, ByVal Category As cIItem.cItemCategoryEnum) As cItem3D
            Dim oItem As cItem3D = Nothing
            Select Case Type
            End Select
            If Not oItem Is Nothing Then
                Call oItems.Add(oItem)
            End If
            Return oItem
        End Function

        Public ReadOnly Property Items() As cItems3D
            Get
                Return oItems
            End Get
        End Property

        Friend Function GetAllItems() As List(Of cItem3D)
            Return oItems.ToList
        End Function
    End Class
End Namespace