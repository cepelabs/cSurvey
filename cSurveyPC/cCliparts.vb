Imports System.Xml
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey
    Friend Class cClipartsBaseCollection
        Inherits KeyedCollection(Of String, cClipart)

        Protected Overrides Function GetKeyForItem(ByVal item As cClipart) As String
            Return item.ID
        End Function
    End Class

    Public Class cSigns
        Private oSurvey As cSurvey
        Private WithEvents oCliparts As cClipartsCollection

        Public ReadOnly Property Cliparts() As cClipartsCollection
            Get
                Return oCliparts
            End Get
        End Property

        Public Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oCliparts = New cClipartsCollection(oSurvey)
        End Sub

        Public Function GetCliparts(Category As cIItem.cItemCategoryEnum) As List(Of cClipart)
            Dim oList As List(Of cClipart) = New List(Of cClipart)
            Dim oItems As List(Of cIItemClipartBase) = GetDesignItems(Category)
            Dim oIDs As List(Of String) = New List(Of String)
            For Each oItem As cIItemClipartBase In oItems
                Call oIDs.Add(oItem.Clipart.ID)
            Next
            For Each oClipart As cClipart In oCliparts
                If oIDs.Contains(oClipart.ID) Then
                    Call oList.Add(oClipart)
                End If
            Next
            Return oList
        End Function

        Public Function GetDesignItems(Category As cIItem.cItemCategoryEnum, Item As cClipart) As List(Of cIItemClipartBase)
            Return GetDesignItems(Category, Item.ID)
        End Function

        Public Function GetDesignItems(Category As cIItem.cItemCategoryEnum, Optional ID As String = "") As List(Of cIItemClipartBase)
            Return oSurvey.GetAllDesignItems.Where(Function(item) item.Category = Category AndAlso TypeOf item Is cIItemClipartBase AndAlso If(ID = "", True, DirectCast(item, cIItemClipartBase).Clipart.ID = ID)).Cast(Of cIItemClipartBase).ToList
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As Storage.cFile, ByVal Signs As XmlElement)
            oSurvey = Survey
            oCliparts = New cClipartsCollection(oSurvey, File, Signs.Item("cliparts"))
            For Each oClipart As cClipart In oCliparts
                Call pApplyDefaultTransformation(oClipart)
            Next
        End Sub

        Friend Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oItem As XmlElement = Document.CreateElement("signs")
            Call oCliparts.SaveTo(File, Document, oItem, Options)
            Call Parent.AppendChild(oItem)
            Return oItem
        End Function

        Private Sub oCliparts_OnAdd(Sender As cClipartsCollection, Clipart As cClipart) Handles oCliparts.OnAdd
            Call pApplyDefaultTransformation(Clipart)
        End Sub

        'check if could be defined a default scale inside svg-xml
        Private Sub pApplyDefaultTransformation(Clipart As cClipart)
            Dim oRect As RectangleF = Clipart.Clipart.GetBounds

            Dim sScale As Single = Clipart.Clipart.UserData.GetTypedValue(Data.cDataFields.TypeEnum.Single, "scale", 1)

            Dim sDX As Single = oRect.Width / sScale
            Dim sDY As Single = oRect.Height / sScale
            Dim sD As Single = 1 / IIf(sDX > sDY, sDX, sDY)
            Dim oMatrix As Matrix = New Matrix
            Call oMatrix.Scale(sD, sD)
            Call Clipart.Clipart.Transform(oMatrix)
        End Sub
    End Class

    Public Class cCliparts
        Private oSurvey As cSurvey
        Private WithEvents oCliparts As cClipartsCollection

        Public ReadOnly Property Cliparts() As cClipartsCollection
            Get
                Return oCliparts
            End Get
        End Property

        Public Function GetCliparts(Category As cIItem.cItemCategoryEnum) As List(Of cClipart)
            Dim oList As List(Of cClipart) = New List(Of cClipart)
            Dim oItems As List(Of Items.cItemClipart) = GetDesignItems(Category)
            Dim oIDs As List(Of String) = New List(Of String)
            For Each oItem As Items.cItemClipart In oItems
                Call oIDs.Add(oItem.Clipart.ID)
            Next
            For Each oClipart As cClipart In oCliparts
                If oIDs.Contains(oClipart.ID) Then
                    Call oList.Add(oClipart)
                End If
            Next
            Return oList
        End Function

        Public Function GetDesignItems(Category As cIItem.cItemCategoryEnum, Item As cClipart) As List(Of Items.cItemClipart)
            Return GetDesignItems(Category, Item.ID)
        End Function

        Public Function GetDesignItems(Category As cIItem.cItemCategoryEnum, Optional ID As String = "") As List(Of Items.cItemClipart)
            Dim oList As List(Of Items.cItemClipart) = New List(Of Items.cItemClipart)
            For Each oItem As cItem In oSurvey.Plan.Layers(cLayers.LayerTypeEnum.RocksAndConcretion).Items
                If oItem.Type = cIItem.cItemTypeEnum.Clipart Then
                    Dim oItemClipart As Items.cItemClipart = oItem
                    If oItemClipart.Category = Category And (oItemClipart.Clipart.ID = ID Or ID = "") Then
                        Call oList.Add(oItemClipart)
                    End If
                End If
            Next
            For Each oItem As cItem In oSurvey.Profile.Layers(cLayers.LayerTypeEnum.RocksAndConcretion).Items
                If oItem.Type = cIItem.cItemTypeEnum.Clipart Then
                    Dim oItemClipart As Items.cItemClipart = oItem
                    If oItemClipart.Category = Category And (oItemClipart.Clipart.ID = ID Or ID = "") Then
                        Call oList.Add(oItemClipart)
                    End If
                End If
            Next
            Return oList
        End Function

        Public Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oCliparts = New cClipartsCollection(oSurvey)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As Storage.cFile, ByVal Cliparts As XmlElement)
            oSurvey = Survey
            oCliparts = New cClipartsCollection(oSurvey, File, Cliparts.Item("cliparts"))
            For Each oClipart As cClipart In oCliparts
                Call pApplyDefaultTransformation(oClipart)
            Next
        End Sub

        Friend Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oItem As XmlElement = Document.CreateElement("cliparts")
            Call oCliparts.SaveTo(File, Document, oItem, Options)
            Call Parent.AppendChild(oItem)
            Return oItem
        End Function

        Private Sub oCliparts_OnAdd(Sender As cClipartsCollection, Clipart As cClipart) Handles oCliparts.OnAdd
            Call pApplyDefaultTransformation(Clipart)
        End Sub

        Private Sub pApplyDefaultTransformation(Clipart As cClipart)
            'flatten the clipart...cliparts are different from signs, cliparts can be free resized so have to be flatten to use warp function without bad results...
            'in future warp in clipart have to be replaced with a dedicated resize code and this code removed
            For Each oDrawPath As cDrawPath In Clipart.Clipart.Paths
                Call oDrawPath.Path.Flatten(Nothing, 0.01)
            Next

            Dim oRect As RectangleF = Clipart.Clipart.GetBounds
            Dim sDX As Single = oRect.Width / 1
            Dim sDY As Single = oRect.Height / 1
            Dim sD As Single = 1 / IIf(sDX > sDY, sDX, sDY)
            Dim oMatrix As Matrix = New Matrix
            Call oMatrix.Scale(sD, sD)
            Call Clipart.Clipart.Transform(oMatrix)
        End Sub
    End Class

    Public Class cClipartsCollection
        Implements IEnumerable

        Private oSurvey As cSurvey
        Private oItems As cClipartsBaseCollection

        Friend Event OnAdd(Sender As cClipartsCollection, Clipart As cClipart)

        Public Function IndexOf(Item As cClipart) As Integer
            Return oItems.IndexOf(Item)
        End Function

        Friend ReadOnly Property Survey() As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oItems = New cClipartsBaseCollection
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As Storage.cFile, ByVal Cliparts As XmlElement)
            oSurvey = Survey
            oItems = New cClipartsBaseCollection
            Dim iIndex As Integer = 0
            Dim iCount As Integer = Cliparts.ChildNodes.Count
            For Each oXMLClipart As XmlElement In Cliparts.ChildNodes
                iIndex += 1
                Call oSurvey.RaiseOnProgressEvent("", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("cliparts.load"), iIndex / iCount)
                Dim oItem As cClipart = New cClipart(File, oXMLClipart)
                If Not oItem.Clipart Is Nothing Then
                    Call oItems.Add(oItem)
                End If
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum)
            Dim oXmlCliparts As XmlElement = Document.CreateElement("cliparts")
            For Each oItem As cClipart In oItems
                Call oItem.SaveTo(File, Document, oXmlCliparts)
            Next
            Call Parent.AppendChild(oXmlCliparts)
            Return oXmlCliparts
        End Function

        Public Overridable Function Add(Filename As String) As cClipart
            Dim oItem As cClipart = New cClipart(Filename)
            oItem = Add(oItem)
            RaiseEvent OnAdd(Me, oItem)
            Return oItem
        End Function

        Public Overridable Function Add(Name As String, Data As Byte()) As cClipart
            Dim oItem As cClipart = New cClipart(Name, Data)
            oItem = Add(oItem)
            RaiseEvent OnAdd(Me, oItem)
            Return oItem
        End Function

        Public Overridable Function Add(Name As String, Data As String) As cClipart
            Dim oItem As cClipart = New cClipart(Name, Data)
            oItem = Add(oItem)
            RaiseEvent OnAdd(Me, oItem)
            Return oItem
        End Function

        Friend Function Add(Item As cClipart) As cClipart
            If oItems.Contains(Item.ID) Then
                Return oItems(Item.ID)
            Else
                Call oItems.Add(Item)
                Return Item
            End If
        End Function

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Function Contains(Item As cClipart, Optional CheckByID As Boolean = True) As Boolean
            If CheckByID Then
                Return oItems.Contains(Item.ID)
            Else
                Return oItems.Contains(Item)
            End If
        End Function

        Public Function Contains(ID As String) As Boolean
            Return oItems.Contains(ID)
        End Function

        Default ReadOnly Property Item(ID As String) As cClipart
            Get
                If oItems.Contains(ID) Then
                    Return oItems(ID)
                End If
            End Get
        End Property

        Default ReadOnly Property Item(Index As Integer) As cClipart
            Get
                If Index >= 0 And Index < oItems.Count Then
                    Return oItems(Index)
                End If
            End Get
        End Property

        Public Sub Remove(Index As Integer)
            If Index >= 0 And Index < oItems.Count Then
                Call oItems.RemoveAt(Index)
            End If
        End Sub

        Public Sub Remove(ID As String)
            If oItems.Contains(ID) Then
                Call oItems.Remove(ID)
            End If
        End Sub

        Public Sub Remove(Item As cClipart)
            If oItems.Contains(Item) Then
                Call oItems.Remove(Item)
            Else
                Call Remove(Item.ID)
            End If
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Public Sub CleanUp()
            Call oSurvey.RaiseOnProgressEvent("cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, modMain.GetLocalizedString("cliparts.cleanup"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageCalculate Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow)
            Dim oUsedClipartIDs As List(Of String) = New List(Of String)
            Dim oDeletedClipartIDs As List(Of String) = New List(Of String)
            Dim oDesignItems As List(Of cItem) = oSurvey.GetAllDesignItems
            Dim iIndex As Integer = 0
            Dim iCount As Integer = oDesignItems.Count
            For Each oItem As cItem In oDesignItems
                iIndex += 1
                If (iIndex Mod 10) = 0 Then Call oSurvey.RaiseOnProgressEvent("cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("cliparts.cleanup1"), iIndex / iCount)
                If oItem.Type = cIItem.cItemTypeEnum.Clipart Then
                    Dim oItemClipart As Items.cItemClipart = oItem
                    Call oUsedClipartIDs.Add(oItemClipart.Clipart.ID)
                End If
                If oItem.Type = cIItem.cItemTypeEnum.Sign Then
                    Dim oItemSign As Items.cItemSign = oItem
                    Call oUsedClipartIDs.Add(oItemSign.Clipart.ID)
                End If
            Next
            iIndex = 0
            iCount = oItems.Count
            For Each oItem As cClipart In oItems
                iIndex += 1
                If (iIndex Mod 10) = 0 Then Call oSurvey.RaiseOnProgressEvent("cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("cliparts.cleanup2"), iIndex / iCount)
                If Not oUsedClipartIDs.Contains(oItem.ID) Then
                    Call oDeletedClipartIDs.Add(oItem.ID)
                End If
            Next
            iIndex = 0
            iCount = oDeletedClipartIDs.Count
            For Each sID As String In oDeletedClipartIDs
                iIndex += 1
                If (iIndex Mod 10) = 0 Then Call oSurvey.RaiseOnProgressEvent("cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("cliparts.cleanup3"), iIndex / iCount)
                Call oItems.Remove(sID)
            Next
            Call oSurvey.RaiseOnProgressEvent("cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)
        End Sub
    End Class

    Public Class cClipart
        Private sID As String
        Private sName As String
        Private oData As MemoryStream

        Private oClipart As Drawings.cDrawClipArt

        Public ReadOnly Property ID As String
            Get
                Return sID
            End Get
        End Property

        Public Property Name As String
            Get
                Return sName
            End Get
            Set(value As String)
                sName = value
            End Set
        End Property

        Friend ReadOnly Property Stream As MemoryStream
            Get
                Return oData
            End Get
        End Property

        Public ReadOnly Property Clipart() As Drawings.cDrawClipArt
            Get
                Return oClipart
            End Get
        End Property

        Friend Sub New(ByVal File As Storage.cFile, ByVal Clipart As XmlElement)
            sID = modXML.GetAttributeValue(Clipart, "id", "")
            sName = modXML.GetAttributeValue(Clipart, "name", "")
            Select Case File.FileFormat
                Case Storage.cFile.FileFormatEnum.CSX
                    oData = New IO.MemoryStream(Convert.FromBase64String(modXML.GetAttributeValue(Clipart, "data")))
                    oClipart = New Drawings.cDrawClipArt(oData)
                Case Storage.cFile.FileFormatEnum.CSZ
                    oData = New IO.MemoryStream()
                    Dim sDataPath As String = modXML.GetAttributeValue(Clipart, "data")
                    Call DirectCast(File.Data(sDataPath), Storage.cStorageItemFile).Stream.CopyTo(oData)
                    Call oData.Seek(0, SeekOrigin.Begin)
                    oClipart = New Drawings.cDrawClipArt(oData)
            End Select
        End Sub

        Friend Sub New(Filename As String)
            sName = Path.GetFileName(Filename)
            Using oFs As FileStream = File.OpenRead(Filename)
                oData = New MemoryStream(oFs.Length)
                Call oFs.CopyTo(oData)
                Call oData.Seek(0, SeekOrigin.Begin)
            End Using
            oClipart = New Drawings.cDrawClipArt(oData)
            sID = modMain.CalculateHash(oData)
        End Sub

        Friend Sub New(Name As String, Data As Byte())
            sName = Name
            oData = New MemoryStream()
            Call oData.Write(Data, 0, Data.Length)
            Call oData.Seek(0, SeekOrigin.Begin)
            oClipart = New Drawings.cDrawClipArt(oData)
            sID = modMain.CalculateHash(oData)
        End Sub

        Friend Sub New(Name As String, Data As String)
            sName = Name
            oData = New MemoryStream()
            Dim bBuffer() As Byte = UTF8Encoding.UTF8.GetBytes(Data)
            Call oData.Write(bBuffer, 0, bBuffer.Length)
            Call oData.Seek(0, SeekOrigin.Begin)
            oClipart = New Drawings.cDrawClipArt(oData)
            sID = modMain.CalculateHash(oData)
        End Sub

        Friend Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oItem As XmlElement = Document.CreateElement("clipart")
            Call oItem.SetAttribute("id", sID)
            Call oItem.SetAttribute("name", sName)
            If Not (File.Options And Storage.cFile.FileOptionsEnum.DontSaveBinary) = Storage.cFile.FileOptionsEnum.DontSaveBinary Then
                Select Case File.FileFormat
                    Case Storage.cFile.FileFormatEnum.CSX
                        Call oItem.SetAttribute("data", Convert.ToBase64String(oData.ToArray))
                    Case Storage.cFile.FileFormatEnum.CSZ
                        Dim sDataPath As String = "_data\cliparts\" & sID & ".svg"
                        Dim oDataStorage As Storage.cStorageItemFile = File.Data.AddFile(sDataPath)
                        Call oData.Seek(0, SeekOrigin.Begin)
                        Call oData.CopyTo(oDataStorage.Stream)
                        Call oItem.SetAttribute("data", sDataPath)
                End Select
            End If
            Call Parent.AppendChild(oItem)
            Return oItem
        End Function
    End Class
End Namespace