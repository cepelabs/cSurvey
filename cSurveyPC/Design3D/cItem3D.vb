Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design.Design3D
    Public MustInherit Class cItem3D
        Implements cIItem

        Private oSurvey As cSurvey
        Private oDesign As cDesign3D
        Private oLayer As cLayer3D

        Private iType As cIItem.cItemTypeEnum
        Private iCategory As cIItem.cItemCategoryEnum

        Private sName As String
        Private sCave As String
        Private sBranch As String

        Private oModel As Object

        Private WithEvents oPoints As cPoints3D

        Private bLocked As Boolean

        Private bHiddenInDesign As Boolean
        Private bHiddenInPreview As Boolean
        Private bFilteredInDesign As Boolean

        Private bDeleted As Boolean

        Friend Overridable Sub SetDeleted()
            bDeleted = True
        End Sub

        Private sTransparency As Single

        Private oDataProperties As Data.cDataProperties

        Public ReadOnly Property DataProperties As Data.cDataProperties
            Get
                Return oDataProperties
            End Get
        End Property

        Public ReadOnly Property Deleted As Boolean
            Get
                Return bDeleted
            End Get
        End Property

        Public Overridable Property HiddenInDesign As Boolean
            Get
                Return bHiddenInDesign
            End Get
            Set(ByVal value As Boolean)
                If bHiddenInDesign <> value Then
                    bHiddenInDesign = value
                End If
            End Set
        End Property

        Public Overridable Property FilteredInDesign As Boolean
            Get
                Return bFilteredInDesign
            End Get
            Set(ByVal value As Boolean)
                bFilteredInDesign = value
            End Set
        End Property

        Public Overridable Property HiddenInPreview As Boolean
            Get
                Return bHiddenInPreview
            End Get
            Set(ByVal value As Boolean)
                If bHiddenInPreview <> value Then
                    bHiddenInPreview = value
                End If
            End Set
        End Property

        Public ReadOnly Property Type() As cIItem.cItemTypeEnum Implements cIItem.Type
            Get
                Return iType
            End Get
        End Property

        Public ReadOnly Property Category() As cIItem.cItemCategoryEnum Implements cIItem.Category
            Get
                Return iCategory
            End Get
        End Property

        Public Overridable Property Locked() As Boolean
            Get
                Return bLocked
            End Get
            Set(ByVal value As Boolean)
                bLocked = value
            End Set
        End Property

        Public Property Name() As String Implements cIItem.Name
            Get
                Return sName
            End Get
            Set(ByVal value As String)
                sName = value
            End Set
        End Property

        Public ReadOnly Property Model() As Object
            Get
                Return oModel
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D, ByVal Layer As cLayer3D, ByVal Type As cIItem.cItemTypeEnum, ByVal Category As cIItem.cItemCategoryEnum)
            oSurvey = Survey
            oDesign = Design
            oLayer = Layer

            sName = ""

            sCave = ""
            sBranch = ""

            iType = Type
            iCategory = Category
            bLocked = False

            oPoints = New cPoints3D(oSurvey, Me)

            oDataProperties = New Data.cDataProperties(oSurvey, oSurvey.Properties.DataTables.DesignItems)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D, ByVal Layer As cLayer3D, ByVal File As Storage.cFile, ByVal Item As XmlElement)
            oSurvey = Survey
            oDesign = Design
            oLayer = Layer

            iType = modXML.GetAttributeValue(Item, "type")
            iCategory = modXML.GetAttributeValue(Item, "category")

            sName = modXML.GetAttributeValue(Item, "name", "")
            sCave = modXML.GetAttributeValue(Item, "cave", "")
            sBranch = modXML.GetAttributeValue(Item, "branch", "")

            bHiddenInDesign = modXML.GetAttributeValue(Item, "hiddenindesign")
            bHiddenInPreview = modXML.GetAttributeValue(Item, "hiddeninpreview")
            bLocked = modXML.GetAttributeValue(Item, "locked")

            oPoints = New cPoints3D(oSurvey, Me, Item.Item("points"))

            If modXML.ChildElementExist(Item, "datarow") Then
                oDataProperties = New Data.cDataProperties(oSurvey, oSurvey.Properties.DataTables.DesignItems, Item.Item("datarow"))
            Else
                oDataProperties = New Data.cDataProperties(oSurvey, oSurvey.Properties.DataTables.DesignItems)
            End If
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXmlItem As XmlElement = Document.CreateElement("item")
            Call oXmlItem.SetAttribute("layer", oLayer.Type.ToString("D"))

            If sName <> "" Then Call oXmlItem.SetAttribute("name", sName)
            If sCave <> "" Then Call oXmlItem.SetAttribute("cave", sCave)
            If sBranch <> "" Then Call oXmlItem.SetAttribute("branch", sBranch)

            Call oXmlItem.SetAttribute("type", iType.ToString("D"))
            Call oXmlItem.SetAttribute("category", iCategory.ToString("D"))

            If bHiddenInDesign Then Call oXmlItem.SetAttribute("hiddenindesign", "1")
            If bHiddenInPreview Then Call oXmlItem.SetAttribute("hiddeninpreview", "1")
            If bLocked Then Call oXmlItem.SetAttribute("locked", "1")

            Call oPoints.SaveTo(File, Document, oXmlItem)

            If oDataProperties.Count <> 0 Then Call oDataProperties.SaveTo(File, Document, oXmlItem)

            Call Parent.AppendChild(oXmlItem)
            Return oXmlItem
        End Function

        Public ReadOnly Property Points() As cPoints3D
            Get
                Return oPoints
            End Get
        End Property

        Friend Overridable Sub RenameCave(ByVal Cave As String, ByVal Branch As String)
            sCave = Cave
            sBranch = Branch
        End Sub

        Public Overridable Sub SetCave(ByVal Cave As String, Optional ByVal Branch As String = "", Optional ByVal BindSegment As Boolean = True) Implements cIItem.SetCave
            Dim sNewCave As String = "" & Cave
            Dim sNewBranch As String = "" & Branch
            If (sNewCave <> sCave) Or (sNewBranch <> sBranch) Then
                sCave = sNewCave
                If sNewCave <> "" Then
                    sBranch = sNewBranch
                Else
                    sBranch = ""
                End If
            End If
        End Sub

        Public Overridable ReadOnly Property Cave As String Implements cIItem.Cave
            Get
                Return sCave
            End Get
        End Property

        Public Overridable ReadOnly Property Branch As String Implements cIItem.Branch
            Get
                Return sBranch
            End Get
        End Property

        Public ReadOnly Property Survey() As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public ReadOnly Property Design As cIDesign Implements cIItem.Design
            Get
                Return oDesign
            End Get
        End Property

        Public ReadOnly Property Layer As cILayer Implements cIItem.Layer
            Get
                Return oLayer
            End Get
        End Property

        Public MustOverride ReadOnly Property CanBeBinded() As Boolean
        Public MustOverride ReadOnly Property CanBeWarped() As Boolean
        Public MustOverride ReadOnly Property CanBeLocked() As Boolean

        Public MustOverride ReadOnly Property CanBeDeleted() As Boolean
        Public MustOverride ReadOnly Property CanBeMoved() As Boolean
        Public MustOverride ReadOnly Property CanBeResized() As Boolean
        Public MustOverride ReadOnly Property CanBeRotated() As Boolean

        Public MustOverride ReadOnly Property CanBeHiddenInDesign() As Boolean
        Public MustOverride ReadOnly Property CanBeHiddenInPreview() As Boolean

        Public MustOverride ReadOnly Property MaxPointsCount() As Integer
        Public MustOverride ReadOnly Property HaveEditablePoints As Boolean

        Public MustOverride ReadOnly Property HaveTransparency As Boolean
    End Class

End Namespace