Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports System.Windows.Media.Media3D
Imports System.Xml
Imports cSurveyPC.cSurvey.Design3D
Imports HelixToolkit.Wpf

Namespace cSurvey.Design.Items
    Public Class cItemChunk3D
        Inherits cItem

        Private sID As String

        Private oModelFiles As cModelFiles3D

        Private oStations As cModelStations3D

        Private oModel As Model3DGroup
        Private oModelTransform As cTransform3D

        Public Function IsValid() As Boolean
            Return oStations.IsValid
        End Function

        Public ReadOnly Property ModelTransform() As cTransform3D
            Get
                Return oModelTransform
            End Get
        End Property

        Public ReadOnly Property ModelFiles As cModelFiles3D
            Get
                Return oModelFiles
            End Get
        End Property

        Public ReadOnly Property Stations As cModelStations3D
            Get
                Return oStations
            End Get
        End Property

        Friend ReadOnly Property GetModel As Model3DGroup
            Get
                If oModel Is Nothing Then
                    Dim sTempPath As String = oModelFiles.WriteAll(IO.Path.GetTempPath)
                    Dim oM As ModelImporter = New ModelImporter
                    oModel = oM.Load(IO.Path.Combine(sTempPath, oModelFiles.MainFile))
                End If
                Return oModel
            End Get
        End Property

        Public ReadOnly Property ID As String
            Get
                Return sID
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D, ByVal Layer As cLayer3D, ByVal File As cFile, ByVal Item As XmlElement)
            Call MyBase.New(Survey, Design, Layer, File, Item)
            sID = Item.GetAttribute("id")

            oModelFiles = New cModelFiles3D(Me, File, Item.Item("files"))

            oStations = New cModelStations3D(MyBase.Survey, Item.Item("stations"))
            oModelTransform = New cTransform3D(MyBase.Survey, Item.Item("t"))
        End Sub

        Public Sub New(Survey As cSurvey, Design As cDesign3D, ByVal Layer As cLayer3D, Category As cIItem.cItemCategoryEnum, Filename As String)
            Call MyBase.New(Survey, Design, Design.Layers(cLayers.LayerTypeEnum.Base), cIItem.cItemTypeEnum.Chunk3D, Category)

            sID = Guid.NewGuid.ToString

            oModelFiles = New cModelFiles3D(Me, Filename)

            oStations = New cModelStations3D(MyBase.Survey)
            oModelTransform = New cTransform3D(MyBase.Survey)
        End Sub

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXmlItem As XmlElement = MyBase.SaveTo(File, Document, Parent, Options)

            oXmlItem.SetAttribute("id", sID)

            Call oModelFiles.SaveTo(File, Document, oXmlItem, Options)
            Call oStations.SaveTo(File, Document, oXmlItem)
            Call oModelTransform.SaveTo(File, Document, oXmlItem)

            Call Parent.AppendChild(oXmlItem)
            Return oXmlItem
        End Function

        Public Overrides ReadOnly Property CanBeCopied As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Property DesignAffinity As DesignAffinityEnum
            Get
                Return DesignAffinityEnum.Design
            End Get
            Set(ByVal value As DesignAffinityEnum)
                'readonly....
            End Set
        End Property

        Public Overrides Property HiddenInDesign As Boolean
            Get
                Return False
            End Get
            Set(ByVal value As Boolean)

            End Set
        End Property

        Public Overrides Property HiddenInPreview As Boolean
            Get
                Return False
            End Get
            Set(ByVal value As Boolean)

            End Set
        End Property

        Public Overrides ReadOnly Property CanBeHiddenInDesign As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeHiddenInPreview As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeLocked As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeSendedToOtherDesign As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeDeleted As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeReduced As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Sub SetCave(ByVal Cave As cCaveInfo, Optional ByVal Branch As cCaveInfoBranch = Nothing, Optional ByVal BindSegment As Boolean = True)
            If Cave Is Nothing Then
                Call SetCave("", "", BindSegment)
            Else
                Call SetCave(Cave.Name, If(Branch Is Nothing, "", Branch.Path), BindSegment)
            End If
        End Sub

        Public Overrides ReadOnly Property HaveTransparency As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property BindMode As cItem.BindModeEnum
            Get
                Return BindModeEnum.None
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeBinded As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeClipped As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeCombined As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeConverted As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeDivided As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeMoved As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeResized As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeRotated As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeWarped As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanImportGeneric As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Function FromGeneric(Item As cItemGeneric, Optional Clear As Boolean = False) As Boolean

        End Function

        Public Overrides ReadOnly Property HaveBrush As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveEditablePoints As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveFont As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveImage As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveLineType As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HavePen As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveCrossSection As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveSplayBorder As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveQuota As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveSign As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveSketch As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveText As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property MaxPointsCount As Integer
            Get
                Return 0
            End Get
        End Property

        Friend Overrides Sub Paint(Graphics As System.Drawing.Graphics, PaintOptions As cOptionsCenterline, Options As cItem.PaintOptionsEnum, Selected As SelectionModeEnum)

        End Sub

        Friend Overrides Sub Render(Graphics As System.Drawing.Graphics, PaintOptions As cOptionsCenterline, Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)

        End Sub

        Friend Overrides Function ToSvg(PaintOptions As cOptionsCenterline, Options As cItem.SVGOptionsEnum) As System.Xml.XmlDocument
            Return Nothing
        End Function

        Friend Overrides Function ToSvgItem(SVG As System.Xml.XmlDocument, PaintOptions As cOptionsCenterline, Options As cItem.SVGOptionsEnum) As System.Xml.XmlElement
            Return Nothing
        End Function

    End Class
End Namespace
