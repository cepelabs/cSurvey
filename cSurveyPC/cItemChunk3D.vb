Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Xml
Imports cSurveyPC.cSurvey.Design3D
Imports DevExpress.XtraEditors.TextEditController
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

        Private Sub pChangeMaterial(Brush As ImageBrush)
            If TypeOf Brush.ImageSource Is BitmapImage Then
                Dim oImage As BitmapImage = Brush.ImageSource
                Dim oUri = oImage.UriSource
                If oUri IsNot Nothing Then
                    Dim oNewImage As BitmapImage = New BitmapImage()
                    oNewImage.BeginInit()
                    oNewImage.CacheOption = BitmapCacheOption.OnLoad
                    oNewImage.StreamSource = New MemoryStream(My.Computer.FileSystem.ReadAllBytes(oUri.ToString))
                    oNewImage.EndInit()
                    Brush.ImageSource = oNewImage
                End If
            End If
        End Sub

        Private Sub pProcessMaterial(Material As Material)
            If TypeOf Material Is DiffuseMaterial Then
                Dim oBrush As Brush = DirectCast(Material, DiffuseMaterial).Brush
                If TypeOf oBrush Is ImageBrush Then
                    Call pChangeMaterial(DirectCast(oBrush, ImageBrush))
                End If
            ElseIf TypeOf Material Is SpecularMaterial Then
                Dim oBrush As Brush = DirectCast(Material, SpecularMaterial).Brush
                If TypeOf oBrush Is ImageBrush Then
                    Call pChangeMaterial(DirectCast(oBrush, ImageBrush))
                End If
            ElseIf TypeOf Material Is MaterialGroup Then
                For Each oMaterial In DirectCast(Material, MaterialGroup).Children
                    Call pProcessMaterial(oMaterial)
                Next
            End If
        End Sub

        Private oOriginalMaterialCache As Dictionary(Of GeometryModel3D, Material())


        ''' <summary>
        ''' Get model with provided paintoptions
        ''' </summary>
        ''' <param name="Options">Paintoptions with colors and other settings</param>
        ''' <returns></returns>
        Friend ReadOnly Property GetModel(Options As cOptions3D) As Model3DGroup
            Get
                Dim oModel As Model3DGroup = GetModel()

                If Options.DrawChunkColoringMode = cOptions3D.ChunkColoringMode.CavesAndBranches Then
                    For Each oSubModel As GeometryModel3D In oModel.Children
                        Dim oColor As System.Drawing.Color = MyBase.Survey.Properties.CaveInfos.GetColor(MyBase.Cave, MyBase.Branch, System.Drawing.Color.LightGray)
                        If Options.ChunkColorGray Then
                            oColor = modPaint.GrayColor(oColor)
                        End If
                        oSubModel.Material = MaterialHelper.CreateMaterial(oColor.ToMediaColor)
                        oSubModel.BackMaterial = oSubModel.Material
                    Next
                Else
                    For Each oSubModel As GeometryModel3D In oModel.Children
                        Dim oMaterials As Material() = oOriginalMaterialCache(oSubModel)
                        oSubModel.Material = oMaterials(0)
                        oSubModel.BackMaterial = oMaterials(1)
                    Next
                End If

                Return oModel
            End Get
        End Property


        ''' <summary>
        ''' Get last rendered model
        ''' </summary>
        ''' <returns></returns>
        Friend ReadOnly Property GetModel As Model3DGroup
            Get
                If oModel Is Nothing Then
                    Dim sTempPath As String = oModelFiles.WriteAll(IO.Path.GetTempPath)
                    Dim oM As ModelImporter = New ModelImporter
                    oModel = oM.Load(IO.Path.Combine(sTempPath, oModelFiles.MainFile))
                    'model use bitmap in materials
                    'bitmapsource have to be deleted but bitmap are loaded only when model is rendered and no event is raise or some else to detect if file is free to be deleted.
                    'So, to allow deleting now, I change bitmap with stream and, finally I delete all temp files.
                    'TODO: this is horrible...use a lot of diskspace and a lot of memory. At least have to be use only stream but I don't find a way without changing Helix source code.
                    For Each oChildModel As GeometryModel3D In oModel.Children
                        Call pProcessMaterial(oChildModel.Material)
                        Call pProcessMaterial(oChildModel.BackMaterial)
                    Next
                    My.Computer.FileSystem.DeleteDirectory(sTempPath, FileIO.DeleteDirectoryOption.DeleteAllContents)

                    oOriginalMaterialCache = New Dictionary(Of GeometryModel3D, Material())
                    For Each oSubModel As GeometryModel3D In oModel.Children
                        oOriginalMaterialCache.Add(oSubModel, {oSubModel.Material, oSubModel.BackMaterial})
                    Next
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
