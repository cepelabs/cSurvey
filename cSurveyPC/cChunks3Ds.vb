Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports System.Windows.Markup
Imports System.Windows.Media.Media3D
Imports System.Xml
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.cLayers
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Design.Layers
Imports DevExpress.Data.ODataLinq
Imports DevExpress.Utils.Behaviors
Imports DevExpress.Utils.Design
Imports DevExpress.XtraGauges.Core.Model
Imports DevExpress.XtraRichEdit
Imports HelixToolkit.Wpf

Namespace cSurvey.Design3D
    Public Class cTransform3D
        Private dXScale As Double
        Private dYScale As Double
        Private dZScale As Double

        Private dXRotate As Double
        Private dYRotate As Double
        Private dZRotate As Double

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLTransform As XmlElement = Document.CreateElement("t")

            Call oXMLTransform.SetAttribute("xs", modNumbers.NumberToString(dXScale, "0.000"))
            Call oXMLTransform.SetAttribute("ys", modNumbers.NumberToString(dYScale, "0.000"))
            Call oXMLTransform.SetAttribute("zs", modNumbers.NumberToString(dZScale, "0.000"))

            Call oXMLTransform.SetAttribute("xr", modNumbers.NumberToString(dXRotate, "0.000"))
            Call oXMLTransform.SetAttribute("yr", modNumbers.NumberToString(dYRotate, "0.000"))
            Call oXMLTransform.SetAttribute("zr", modNumbers.NumberToString(dZRotate, "0.000"))

            Call Parent.AppendChild(oXMLTransform)
            Return oXMLTransform
        End Function

        Public Sub New(ByVal Survey As cSurvey)
            dXScale = 1
            dYScale = 1
            dZScale = 1
            dXRotate = 0
            dYRotate = 0
            dZRotate = 0
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Transform As XmlElement)
            dXScale = modNumbers.StringToDouble(Transform.GetAttribute("xs"))
            dYScale = modNumbers.StringToDouble(Transform.GetAttribute("ys"))
            dZScale = modNumbers.StringToDouble(Transform.GetAttribute("zs"))

            dXRotate = modNumbers.StringToDouble(Transform.GetAttribute("xr"))
            dYRotate = modNumbers.StringToDouble(Transform.GetAttribute("yr"))
            dZRotate = modNumbers.StringToDouble(Transform.GetAttribute("zr"))

        End Sub

        Public Property XRotate As Double
            Get
                Return dXRotate
            End Get
            Set(value As Double)
                If dXRotate <> value Then
                    dXRotate = value
                End If
            End Set
        End Property

        Public Property YRotate As Double
            Get
                Return dYRotate
            End Get
            Set(value As Double)
                If dYRotate <> value Then
                    dYRotate = value
                End If
            End Set
        End Property

        Public Property ZRotate As Double
            Get
                Return dZRotate
            End Get
            Set(value As Double)
                If dZRotate <> value Then
                    dZRotate = value
                End If
            End Set
        End Property

        Public Property XScale As Double
            Get
                Return dXScale
            End Get
            Set(value As Double)
                If dXScale <> value Then
                    dXScale = value
                End If
            End Set
        End Property

        Public Property YScale As Double
            Get
                Return dYScale
            End Get
            Set(value As Double)
                If dYScale <> value Then
                    dYScale = value
                End If
            End Set
        End Property

        Public Property ZScale As Double
            Get
                Return dZScale
            End Get
            Set(value As Double)
                If dZScale <> value Then
                    dZScale = value
                End If
            End Set
        End Property
    End Class

    Public Class cStation3D
        Private oSurvey As cSurvey
        Private oPoint As Point3D
        Private oTrigPoint As cTrigPoint

        Public Function IsValid() As Boolean
            If oTrigPoint Is Nothing Then
                Return False
            Else
                If oSurvey.TrigPoints.Contains(oTrigPoint) Then
                    Return Not oTrigPoint.Data.IsOrphan
                Else
                    Return False
                End If
            End If
        End Function

        Public Function IsOrphan() As Boolean
            If Not oTrigPoint Is Nothing AndAlso oSurvey.TrigPoints.Contains(oTrigPoint) Then
                Return oTrigPoint.Data.IsOrphan
            Else
                Return True
            End If
        End Function

        Public Property Point As Point3D
            Get
                Return oPoint
            End Get
            Set(ByVal value As Point3D)
                oPoint = value
            End Set
        End Property

        Public ReadOnly Property Name As String
            Get
                If IsValid() Then
                    Return oTrigPoint.Name
                Else
                    Return modMain.GetLocalizedString("itemsketch.notvalidname")
                End If
            End Get
        End Property

        Public Property TrigPoint As cTrigPoint
            Get
                Return oTrigPoint
            End Get
            Set(value As cTrigPoint)
                oTrigPoint = value
            End Set
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Point As Point3D, ByVal TrigPoint As cTrigPoint)
            oSurvey = Survey
            oPoint = Point
            oTrigPoint = TrigPoint
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Station As XmlElement)
            oSurvey = Survey
            oPoint = New Point3D(Station.GetAttribute("x"), Station.GetAttribute("y"), Station.GetAttribute("z"))
            oTrigPoint = oSurvey.TrigPoints(Station.GetAttribute("trigpoint"))
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Name As String) As XmlElement
            Dim oXmlStation As XmlElement = Document.CreateElement(Name)
            Call oXmlStation.SetAttribute("x", Point.X)
            Call oXmlStation.SetAttribute("y", Point.Y)
            Call oXmlStation.SetAttribute("z", Point.Z)
            Call oXmlStation.SetAttribute("trigpoint", oTrigPoint.Name)
            Call Parent.AppendChild(oXmlStation)
            Return oXmlStation
        End Function
    End Class

    Public Class cModelStations3D
        Private oSurvey As cSurvey
        Private oStation1 As cStation3D
        Private oStation2 As cStation3D

        Public Sub SetStation1(Point As Point3D, Trigpoint As cTrigPoint)
            oStation1.Point = Point
            oStation1.TrigPoint = Trigpoint
        End Sub

        Public Sub SetStation2(Point As Point3D, Trigpoint As cTrigPoint)
            oStation2.Point = Point
            oStation2.TrigPoint = Trigpoint
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlStations As XmlElement = Document.CreateElement("stations")
            Call oStation1.SaveTo(File, Document, oXmlStations, "s1")
            Call oStation2.SaveTo(File, Document, oXmlStations, "s2")
            Call Parent.AppendChild(oXmlStations)
            Return oXmlStations
        End Function

        Public Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oStation1 = New cStation3D(oSurvey, New Point3D(0, 0, 0), Nothing)
            oStation2 = New cStation3D(oSurvey, New Point3D(0, 0, 0), Nothing)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Stations As XmlElement)
            oSurvey = Survey
            oStation1 = New cStation3D(oSurvey, Stations.Item("s1"))
            oStation2 = New cStation3D(oSurvey, Stations.Item("s2"))
        End Sub

        Public ReadOnly Property Station2 As cStation3D
            Get
                Return oStation2
            End Get
        End Property

        Public ReadOnly Property Station1 As cStation3D
            Get
                Return oStation1
            End Get
        End Property

        Public Function IsValid() As Boolean
            Return oStation1.IsValid AndAlso oStation2.IsValid
        End Function
    End Class

    Public Class cModelFile3D
        Private oData As Byte()
        Private sName As String

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public ReadOnly Property Data As Byte()
            Get
                Return oData
            End Get
        End Property

        Public Sub New(Name As String, Data As Byte())
            sName = Name
            oData = Data
        End Sub
    End Class

    Public Class cModelFiles3D
        Private Class cModelFiles3DBase
            Inherits KeyedCollection(Of String, cModelFile3D)

            Protected Overrides Function GetKeyForItem(item As cModelFile3D) As String
                Return item.Name
            End Function
        End Class

        Private oItems As cModelFiles3DBase

        Private oParent As cItemChunk3D
        Private sMainFile As String = ""

        Public Function IsValid() As Boolean
            Return oItems.Count > 0
        End Function

        Public ReadOnly Property MainFile As String
            Get
                Return sMainFile
            End Get
        End Property

        Public Sub Load(Filename As String)
            Call oItems.Clear()
            sMainFile = IO.Path.GetFileName(Filename)
            Dim oFiles As List(Of String) = New List(Of String)
            For Each sFilename As String In cModel3DHelper.GetObjFilenames(Filename)
                Dim sName As String = IO.Path.GetFileName(sFilename)
                Call oItems.Add(New cModelFile3D(sName, My.Computer.FileSystem.ReadAllBytes(sFilename)))
            Next
        End Sub

        ''' <summary>
        ''' Write all model files to a temporary subfolder in path
        ''' </summary>
        ''' <param name="Path">Path of the temporary subfolder</param>
        Friend Function WriteAll(Path As String) As String
            Dim sTempFolder As String = IO.Path.Combine(Path, Guid.NewGuid.ToString)
            Call My.Computer.FileSystem.CreateDirectory(sTempFolder)
            For Each oFile As cModelFile3D In oItems
                Dim sFilename As String = IO.Path.Combine(sTempFolder, oFile.Name)
                Call My.Computer.FileSystem.WriteAllBytes(sFilename, oFile.Data, False)
            Next
            Return sTempFolder
        End Function

        Friend Sub New(Parent As cItemChunk3D)
            MyBase.New
            oItems = New cModelFiles3DBase
            oParent = Parent
            sMainFile = ""
        End Sub

        Friend Sub New(Parent As cItemChunk3D, Filename As String)
            MyBase.New
            oItems = New cModelFiles3DBase
            oParent = Parent
            Call Load(Filename)
        End Sub

        Friend Sub New(Parent As cItemChunk3D, ByVal File As cFile, ByVal Item As XmlElement)
            MyBase.New
            oItems = New cModelFiles3DBase
            oParent = Parent
            sMainFile = Item.GetAttribute("mainfile")
            For Each oXMLFile As XmlElement In Item.ChildNodes
                Dim sName As String = oXMLFile.GetAttribute("name")
                Dim oData As Byte()
                Select Case File.FileFormat
                    Case cFile.FileFormatEnum.CSX
                        oData = Convert.FromBase64String(modXML.GetAttributeValue(oXMLFile, "data"))
                    Case cFile.FileFormatEnum.CSZ
                        Dim sDataPath As String = modXML.GetAttributeValue(oXMLFile, "data")
                        oData = DirectCast(File.Data(sDataPath), Storage.cStorageItemFile).Stream.ToArray
                End Select
                Call oItems.Add(New cModelFile3D(sName, oData))
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum)
            Dim oItem As XmlElement = Document.CreateElement("files")
            Call oItem.SetAttribute("mainfile", sMainFile)
            For Each oFile As cModelFile3D In oItems
                Dim oXMLFile As XmlElement = Document.CreateElement("file")
                Call oXMLFile.SetAttribute("name", oFile.Name)
                If Not (File.Options And cFile.FileOptionsEnum.DontSaveBinary) = cFile.FileOptionsEnum.DontSaveBinary Then
                    Select Case File.FileFormat
                        Case cFile.FileFormatEnum.CSX
                            Call oXMLFile.SetAttribute("data", Convert.ToBase64String(oFile.Data))
                        Case cFile.FileFormatEnum.CSZ
                            Dim sDataPath As String = "_data\design3d\" & oParent.ID & "\" & oFile.Name
                            Dim oDataStorage As Storage.cStorageItemFile = File.Data.AddFile(sDataPath)
                            Call oDataStorage.Write(oFile.Data)
                            Call oXMLFile.SetAttribute("data", sDataPath)
                    End Select
                End If
                Call oItem.AppendChild(oXMLFile)
            Next

            Call Parent.AppendChild(oItem)
            Return oItem
        End Function
    End Class

    'Public Class cChunk3D
    '    Private oSurvey As cSurvey
    '    Private oDesign As cDesign3D
    '    Private oChunks As cChunks3D

    '    Private sID As String

    '    Private oModelFiles As cModelFiles3D

    '    Private oStations As cModelStations3D

    '    Private oModel As Model3DGroup
    '    Private oModelTransform As cTransform3D

    '    Private sName As String

    '    Private sCave As String
    '    Private sBranch As String

    '    Public Property Name As String
    '        Get
    '            Return sName
    '        End Get
    '        Set(value As String)
    '            sName = value
    '        End Set
    '    End Property

    '    Public Function IsValid() As Boolean
    '        Return oStations.IsValid
    '    End Function

    '    Public ReadOnly Property ModelFiles As cModelFiles3D
    '        Get
    '            Return oModelFiles
    '        End Get
    '    End Property

    '    Public ReadOnly Property Stations As cModelStations3D
    '        Get
    '            Return oStations
    '        End Get
    '    End Property

    '    Friend Sub SetModel(Filename As String)
    '        oModelFiles.Load(Filename)
    '        oModel = Nothing
    '    End Sub

    '    Friend ReadOnly Property GetModel As Model3DGroup
    '        Get
    '            If oModel Is Nothing Then
    '                Dim sTempPath As String = oModelFiles.WriteAll(IO.Path.GetTempPath)
    '                Dim oM As ModelImporter = New ModelImporter
    '                oModel = oM.Load(IO.Path.Combine(sTempPath, oModelFiles.MainFile))
    '            End If
    '            Return oModel
    '        End Get
    '    End Property

    '    Public ReadOnly Property ID As String
    '        Get
    '            Return sID
    '        End Get
    '    End Property

    '    Public ReadOnly Property Survey() As cSurvey
    '        Get
    '            Return oSurvey
    '        End Get
    '    End Property

    '    Public ReadOnly Property Design As cDesign3D
    '        Get
    '            Return oDesign
    '        End Get
    '    End Property

    '    Public ReadOnly Property Chunks As cChunks3D
    '        Get
    '            Return oChunks
    '        End Get
    '    End Property

    '    Public ReadOnly Property ModelTransform() As cTransform3D
    '        Get
    '            Return oModelTransform
    '        End Get
    '    End Property

    '    Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D, ByVal Chunks As cChunks3D, Filename As String)
    '        oSurvey = Survey
    '        oDesign = Design
    '        oChunks = Chunks

    '        sID = Guid.NewGuid.ToString
    '        sName = ""
    '        sCave = ""
    '        sBranch = ""

    '        oModelFiles = New cModelFiles3D(Me, Filename)

    '        oStations = New cModelStations3D(oSurvey)
    '        oModelTransform = New cTransform3D(oSurvey)
    '    End Sub

    '    Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D, ByVal Chunks As cChunks3D, ByVal File As cFile, ByVal Item As XmlElement)
    '        oSurvey = Survey
    '        oDesign = Design
    '        oChunks = Chunks

    '        sID = Item.GetAttribute("id")
    '        sName = modXML.GetAttributeValue(Item, "name", "")
    '        sCave = modXML.GetAttributeValue(Item, "cave", "")
    '        sBranch = modXML.GetAttributeValue(Item, "branch", "")

    '        oModelFiles = New cModelFiles3D(Me, File, Item.Item("files"))

    '        oStations = New cModelStations3D(oSurvey, Item.Item("stations"))
    '        oModelTransform = New cTransform3D(oSurvey, Item.Item("t"))
    '    End Sub

    '    Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum)
    '        Dim oXmlItem As XmlElement = Document.CreateElement("model")

    '        oXmlItem.SetAttribute("id", sID)
    '        If "" & sName <> "" Then oXmlItem.SetAttribute("name", sName)
    '        If sCave <> "" Then Call oXmlItem.SetAttribute("cave", sCave)
    '        If sBranch <> "" Then Call oXmlItem.SetAttribute("branch", sBranch)

    '        Call oModelFiles.SaveTo(File, Document, oXmlItem, Options)
    '        Call oStations.SaveTo(File, Document, oXmlItem)
    '        Call oModelTransform.SaveTo(File, Document, oXmlItem)

    '        Call Parent.AppendChild(oXmlItem)
    '        Return oXmlItem
    '    End Function

    '    Public Sub SetCave(ByVal Cave As cCaveInfo, Optional ByVal Branch As cCaveInfoBranch = Nothing, Optional ByVal BindSegment As Boolean = True)
    '        If Cave Is Nothing Then
    '            Call SetCave("", "", BindSegment)
    '        Else
    '            Call SetCave(Cave.Name, If(Branch Is Nothing, "", Branch.Path), BindSegment)
    '        End If
    '    End Sub

    '    Public Sub SetCave(ByVal Cave As String, Optional ByVal Branch As String = "", Optional ByVal BindSegment As Boolean = True)
    '        Dim sNewCave As String = "" & Cave
    '        Dim sNewBranch As String = "" & Branch
    '        If (sNewCave <> sCave) Or (sNewBranch <> sBranch) Then
    '            sCave = sNewCave
    '            If sNewCave <> "" Then
    '                sBranch = sNewBranch
    '            Else
    '                sBranch = ""
    '            End If
    '        End If
    '    End Sub

    '    Public ReadOnly Property Cave As String
    '        Get
    '            Return sCave
    '        End Get
    '    End Property

    '    Public ReadOnly Property Branch As String
    '        Get
    '            Return sBranch
    '        End Get
    '    End Property
    'End Class

    'Public Class cChunks3D
    '    Implements IEnumerable
    '    Implements IEnumerable(Of cChunk3D)

    '    Private oSurvey As cSurvey
    '    Private oDesign As cDesign3D

    '    Private oItems As BindingList(Of cChunk3D)

    '    Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D)
    '        oSurvey = Survey
    '        oDesign = Design
    '        oItems = New BindingList(Of cChunk3D)
    '    End Sub

    '    Public Function Add(Filename As String) As cChunk3D
    '        Dim oItem As cChunk3D = New cChunk3D(oSurvey, oDesign, Me, Filename)
    '        oItems.Add(oItem)
    '        Return oItem
    '    End Function

    '    Public Sub Clear()
    '        Call oItems.Clear()
    '    End Sub

    '    Public Sub Remove(Index As Integer)
    '        Call oItems.RemoveAt(Index)
    '    End Sub

    '    Public Sub Remove(Item As cChunk3D)
    '        Call oItems.Remove(Item)
    '    End Sub

    '    Default Public ReadOnly Property Item(ByVal Index As Integer) As cChunk3D
    '        Get
    '            Return oItems(Index)
    '        End Get
    '    End Property

    '    Public Function IndexOf(ByVal Layer As cChunk3D) As Integer
    '        Return oItems.IndexOf(Layer)
    '    End Function

    '    Public ReadOnly Property Count() As Integer
    '        Get
    '            Return oItems.Count
    '        End Get
    '    End Property

    '    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
    '        Return oItems.GetEnumerator
    '    End Function

    '    Public Function ToArray() As cChunk3D()
    '        Return oItems.ToArray
    '    End Function

    '    Private Function cLayer_GetEnumerator() As IEnumerator(Of cChunk3D) Implements IEnumerable(Of cChunk3D).GetEnumerator
    '        Return oItems.GetEnumerator
    '    End Function

    '    Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D, ByVal File As cFile, ByVal Models As XmlElement)
    '        oSurvey = Survey
    '        oDesign = Design
    '        oItems = New BindingList(Of cChunk3D)

    '        For Each oXMLModel As XmlElement In Models.ChildNodes
    '            Dim oItem As cChunk3D = New cChunk3D(oSurvey, oDesign, Me, File, oXMLModel)
    '            Call oItems.Add(oItem)
    '        Next
    '    End Sub

    '    Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum)
    '        Dim oXmlModels As XmlElement = Document.CreateElement("models")
    '        For Each oModel As cChunk3D In oItems
    '            Call oModel.SaveTo(File, Document, oXmlModels, Options)
    '        Next
    '        Call Parent.AppendChild(oXmlModels)
    '        Return oXmlModels
    '    End Function
    'End Class
End Namespace
