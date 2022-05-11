Imports System.IO
Imports cSurveyPC.cSurvey.Storage

Namespace cSurvey
    Public Class cFile
        Implements IDisposable

        Private oStorage As cStorage
        Private oDocument As Xml.XmlDocument

        Public Enum FileFormatEnum
            Auto = -1
            CSZ = 0
            CSX = 1 'old format
        End Enum

        Public Enum FileOptionsEnum
            [Default] = 0
            [DontSaveBinary] = 1
            [EmbedResource] = 2
        End Enum

        Private sFilename As String
        Private iFileFormat As FileFormatEnum
        Private iOptions As FileOptionsEnum

        Public ReadOnly Property Filename As String
            Get
                Return sFilename
            End Get
        End Property

        Public Sub New(Optional ByVal FileFormat As FileFormatEnum = FileFormatEnum.Auto, Optional Filename As String = "", Optional ByVal Options As FileOptionsEnum = FileOptionsEnum.Default)
            sFilename = Filename
            If FileFormat = FileFormatEnum.Auto Then
                If IO.Path.GetExtension(sFilename).ToLower = ".csx" Then
                    iFileFormat = FileFormatEnum.CSX
                Else
                    iFileFormat = FileFormatEnum.CSZ
                End If
            Else
                iFileFormat = FileFormat
            End If
            iOptions = Options
            Select Case iFileFormat
                Case FileFormatEnum.CSX
                    oDocument = New Xml.XmlDocument
                Case FileFormatEnum.CSZ
                    oStorage = New cStorage
                    oDocument = New Xml.XmlDocument
            End Select
        End Sub

        Public ReadOnly Property FileFormat As FileFormatEnum
            Get
                Return iFileFormat
            End Get
        End Property

        Public ReadOnly Property Options As FileOptionsEnum
            Get
                Return iOptions
            End Get
        End Property

        Public Sub New(ByVal Filename As String)
            sFilename = Filename
            If IO.Path.GetExtension(sFilename).ToLower = ".csx" Then
                iFileFormat = FileFormatEnum.CSX
                oStorage = Nothing
                oDocument = New Xml.XmlDocument
                Call oDocument.Load(Filename)
            Else
                iFileFormat = FileFormatEnum.CSZ
                oStorage = New cStorage(sFilename)
                oDocument = New Xml.XmlDocument
                Dim oFile As cStorageItemFile = DirectCast(oStorage("_data.xml"), cStorageItemFile)
                oFile.Stream.Position = 0
                Call oDocument.Load(oFile.Stream)
            End If
        End Sub

        Public Sub Save()
            If sFilename <> "" Then
                Call SaveTo(sFilename)
            Else
                Throw New Exception("Filename is missing")
            End If
        End Sub

        Public Sub SaveTo(ByVal Filename As String)
            sFilename = Filename
            Select Case iFileFormat
                Case FileFormatEnum.CSX
                    Call oDocument.Save(sFilename)
                Case FileFormatEnum.CSZ
                    Dim oData As cStorageItemFile = oStorage.AddFile("_data.xml")
                    Call oDocument.Save(oData.Stream)
                    Call oStorage.SaveTo(sFilename)
            End Select
        End Sub

        Public Sub SaveTo(ByVal Stream As System.IO.Stream)
            Select Case iFileFormat
                Case FileFormatEnum.CSX
                    Call oDocument.Save(Stream)
                Case FileFormatEnum.CSZ
                    Dim oData As cStorageItemFile = oStorage.AddFile("_data.xml")
                    Call oDocument.Save(oData.Stream)
                    Call oStorage.SaveTo(Stream)
            End Select
        End Sub

        Public ReadOnly Property Data As cStorage
            Get
                Return oStorage
            End Get
        End Property

        Public ReadOnly Property Document As Xml.XmlDocument
            Get
                Return oDocument
            End Get
        End Property

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    If Not oStorage Is Nothing Then
                        Call oStorage.Dispose()
                        oStorage = Nothing
                    End If
                End If
            End If
            disposedValue = True
        End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
        End Sub
#End Region
    End Class
End Namespace

Namespace cSurvey.Storage
    Public Interface cIStorageItem
        Enum StorageItemTypeEnum
            File = 0
            Directory = 1
        End Enum
        ReadOnly Property Name As String
        ReadOnly Property Type As StorageItemTypeEnum
    End Interface

    Public MustInherit Class cStorageItem
        Implements cIStorageItem

        Private oStorage As cStorage
        Private sName As String
        Private sPath As String

        Friend Sub New(ByVal Storage As cStorage, ByVal Name As String)
            oStorage = Storage
            sName = Name
            sPath = IO.Path.GetDirectoryName(Name)
        End Sub

        Public ReadOnly Property Name As String Implements cIStorageItem.Name
            Get
                Return sName
            End Get
        End Property

        Public ReadOnly Property Path As String
            Get
                Return sPath
            End Get
        End Property

        Friend ReadOnly Property Storage As cStorage
            Get
                Return oStorage
            End Get
        End Property

        Public MustOverride ReadOnly Property Type As cIStorageItem.StorageItemTypeEnum Implements cIStorageItem.Type
    End Class

    Public Interface cIStorageItemDirectory
        Function GetFiles() As List(Of cStorageItemFile)
        Function GetDirectories() As List(Of cStorageItemDirectory)
    End Interface

    Public Class cStorageItemDirectory
        Inherits cStorageItem
        Implements cIStorageItemDirectory

        Friend Sub New(ByVal Storage As cStorage, ByVal Name As String)
            Call MyBase.New(Storage, Name)
        End Sub

        Public Overrides ReadOnly Property Type As cIStorageItem.StorageItemTypeEnum
            Get
                Return cIStorageItem.StorageItemTypeEnum.Directory
            End Get
        End Property

        Public Function GetFiles() As List(Of cStorageItemFile) Implements cIStorageItemDirectory.GetFiles
            Dim sPath As String = IO.Path.GetDirectoryName(MyBase.Name)
            Dim oFiles As List(Of cStorageItemFile) = New List(Of cStorageItemFile)(MyBase.Storage.GetFiles(MyBase.Path))
            Return oFiles
        End Function

        Public Function GetDirectories() As List(Of cStorageItemDirectory) Implements cIStorageItemDirectory.GetDirectories
            Dim sPath As String = IO.Path.GetDirectoryName(MyBase.Name)
            Dim oDirectories As List(Of cStorageItemDirectory) = New List(Of cStorageItemDirectory)(MyBase.Storage.GetDirectories(MyBase.Path))
            Return oDirectories
        End Function
    End Class

    Public Class cStorageItemFile
        Inherits cStorageItem
        Implements IDisposable

        Private oStream As MemoryStream

        Public ReadOnly Property Stream As MemoryStream
            Get
                Return oStream
            End Get
        End Property

        Friend Sub New(ByVal Storage As cStorage, ByVal Name As String, Capacity As Integer)
            Call MyBase.New(Storage, Name)
            oStream = New MemoryStream(Capacity)
        End Sub

        Friend Sub New(ByVal Storage As cStorage, ByVal Name As String)
            Call MyBase.New(Storage, Name)
            oStream = New MemoryStream(0)
        End Sub

        Public Overrides ReadOnly Property Type As cIStorageItem.StorageItemTypeEnum
            Get
                Return cIStorageItem.StorageItemTypeEnum.File
            End Get
        End Property

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    Call oStream.Dispose()
                    oStream = Nothing
                End If
            End If
            disposedValue = True
        End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
        End Sub
#End Region
    End Class

    Public Class cStorage
        Implements cIStorageItemDirectory
        Implements IDisposable

        Private oItems As Dictionary(Of String, cStorageItem)

        Default Public ReadOnly Property Item(ByVal Path As String) As cStorageItem
            Get
                If oItems.ContainsKey(Path) Then
                    Return oItems(Path)
                End If
            End Get
        End Property

        Public Function AddFile(ByVal Name As String) As cStorageItemFile
            Call Remove(Name)
            Dim oItem As cStorageItemFile = New cStorageItemFile(Me, Name)
            If oItem.Path <> "" Then
                If Not oItems.ContainsKey(oItem.Path) Then
                    Call AddDirectory(oItem.Path)
                End If
            End If
            Call oItems.Add(Name, oItem)
            Return oItem
        End Function

        Public Function AddDirectory(ByVal Name As String) As cStorageItemDirectory
            Call Remove(Name)
            Dim oItem As cStorageItemDirectory = New cStorageItemDirectory(Me, Name)
            If oItem.Path <> "" Then
                If Not oItems.ContainsKey(oItem.Path) Then
                    Call AddDirectory(oItem.Path)
                End If
            End If
            Call oItems.Add(Name, oItem)
            Return oItem
        End Function

        Public Sub Remove(ByVal Name As String)
            If oItems.ContainsKey(Name) Then
                Dim oItem As cStorageItem = oItems(Name)
                If TypeOf oItem Is cStorageItemFile Then
                    DirectCast(oItem, cStorageItemFile).Dispose()
                End If
                Call oItems.Remove(Name)
            End If
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Sub Clear()
            For Each oFileItem As cStorageItemFile In oItems.Values.Where(Function(oitem) TypeOf oitem Is cStorageItemFile)
                Call oFileItem.Dispose()
            Next
            Call oItems.Clear()
        End Sub

        Friend Sub SaveTo(ByVal Stream As IO.Stream)
            Using oZip As Ionic.Zip.ZipFile = New Ionic.Zip.ZipFile()
                oZip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestSpeed
                For Each oItem As cStorageItem In oItems.Values
                    If oItem.Type = cIStorageItem.StorageItemTypeEnum.Directory Then
                        Call oZip.AddDirectoryByName(oItem.Name)
                    End If
                Next
                For Each oItem As cStorageItem In oItems.Values
                    If oItem.Type = cIStorageItem.StorageItemTypeEnum.File Then
                        Dim oFileItem As cStorageItemFile = oItem
                        oFileItem.Stream.Position = 0
                        Call oZip.AddEntry(oFileItem.Name, oFileItem.Stream)
                    End If
                Next
                Call oZip.Save(Stream)
            End Using
        End Sub

        Friend Sub SaveTo(ByVal Filename As String)
            Using oZip As Ionic.Zip.ZipFile = New Ionic.Zip.ZipFile()
                oZip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestSpeed
                For Each oItem As cStorageItem In oItems.Values
                    If Not oItem Is Nothing Then
                        If oItem.Type = cIStorageItem.StorageItemTypeEnum.Directory Then
                            Call oZip.AddDirectoryByName(oItem.Name)
                        End If
                    End If
                Next
                For Each oItem As cStorageItem In oItems.Values
                    If Not oItem Is Nothing Then
                        If oItem.Type = cIStorageItem.StorageItemTypeEnum.File Then
                            Dim oFileItem As cStorageItemFile = oItem
                            oFileItem.Stream.Position = 0
                            Call oZip.AddEntry(oFileItem.Name, oFileItem.Stream)
                        End If
                    End If
                Next
                Call oZip.Save(Filename)
            End Using
        End Sub

        Friend Sub New()
            oItems = New Dictionary(Of String, cStorageItem)
        End Sub

        Friend Sub New(ByVal Filename As String)
            oItems = New Dictionary(Of String, cStorageItem)
            Using oZip As Ionic.Zip.ZipFile = New Ionic.Zip.ZipFile(Filename)
                For Each oEntry As Ionic.Zip.ZipEntry In oZip.Entries
                    Dim sName As String = oEntry.FileName
                    sName = sName.Replace("/", Path.DirectorySeparatorChar)
                    If oEntry.IsDirectory Then
                        Dim oDirectoryItem As cStorageItemDirectory = New cStorageItemDirectory(Me, sName)
                        Call oItems.Add(sName, oDirectoryItem)
                    Else
                        Dim oFileItem As cStorageItemFile = New cStorageItemFile(Me, sName, oEntry.UncompressedSize)
                        Call oEntry.Extract(oFileItem.Stream)
                        oFileItem.Stream.Position = 0
                        Call oItems.Add(sName, oFileItem)
                    End If
                Next
            End Using
        End Sub

        Public Function GetFiles() As List(Of cStorageItemFile) Implements cIStorageItemDirectory.GetFiles
            Dim oFiles As List(Of cStorageItemFile) = New List(Of cStorageItemFile)
            For Each oItem As cStorageItem In oItems.Values
                If oItem.Type = cIStorageItem.StorageItemTypeEnum.File Then
                    Call oFiles.Add(oItem)
                End If
            Next
            Return oFiles
        End Function

        Public Function GetDirectories() As List(Of cStorageItemDirectory) Implements cIStorageItemDirectory.GetDirectories
            Dim oDirectories As List(Of cStorageItemDirectory) = New List(Of cStorageItemDirectory)
            For Each oItem As cStorageItem In oItems.Values
                If oItem.Type = cIStorageItem.StorageItemTypeEnum.Directory Then
                    Call oDirectories.Add(oItem)
                End If
            Next
            Return oDirectories
        End Function

        Public Function GetFiles(ByVal Path As String) As List(Of cStorageItemFile)
            Dim oFiles As List(Of cStorageItemFile) = New List(Of cStorageItemFile)
            For Each oItem As cStorageItem In oItems.Values
                If oItem.Type = cIStorageItem.StorageItemTypeEnum.File And oItem.Path = Path Then
                    Call oFiles.Add(oItem)
                End If
            Next
            Return oFiles
        End Function

        Public Function GetDirectories(ByVal Path As String) As List(Of cStorageItemDirectory)
            Dim oDirectories As List(Of cStorageItemDirectory) = New List(Of cStorageItemDirectory)
            For Each oItem As cStorageItem In oItems.Values
                If oItem.Type = cIStorageItem.StorageItemTypeEnum.Directory And oItem.Path = Path Then
                    Call oDirectories.Add(oItem)
                End If
            Next
            Return oDirectories
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    Call Clear()
                End If
            End If
            disposedValue = True
        End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
        End Sub
#End Region
    End Class
End Namespace