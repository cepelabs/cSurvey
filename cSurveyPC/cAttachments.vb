Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports cSurveyPC.cSurvey.Drawings
Imports System.Collections.ObjectModel
Imports System.IO

Namespace cSurvey
    Public Class cAttachment
        Implements cICleanUpItem
        Implements IDisposable

        Private sID As String
        Private sName As String
        Private sNote As String
        Private sMimetype As String

        Private oData As Byte()

        Friend Event OnCleanUpOwnerRequest(Sender As Object, Args As cCleanUpItemOwnersRequestargs) Implements cICleanUpItem.OnCleanUpOwnerRequest

        Friend Sub CleanUpOwnersRequest(Owners As List(Of Object)) Implements cICleanUpItem.CleanUpOwnersRequest
            RaiseEvent OnCleanUpOwnerRequest(Me, New cCleanUpItemOwnersRequestargs(Owners))
        End Sub

        Public Function GetName() As String
            Dim sTempName As String = "" & sName
            If sTempName = "" Then
                sTempName = Guid.NewGuid.ToString & "." & FTTLib.FTT.GetMimeTypeFileExtensions(sMimetype)(0)
            End If
            Return sTempName
        End Function

        Private sTempFilename As String = Nothing

        Public Sub OpenInShell()
            'save temp file and open it (locking csurvey for removing temp file on closing)
            Try
                If IsNothing(sTempFilename) Then
                    Dim sTempPath As String = My.Computer.FileSystem.SpecialDirectories.Temp
                    Dim sTempName As String = GetName()
                    sTempFilename = IO.Path.Combine(sTempPath, sTempName)
                    Call My.Computer.FileSystem.WriteAllBytes(sTempFilename, oData, False)
                End If
                Try
                    Call Process.Start(sTempFilename)
                Catch ex2 As Exception
                    sTempFilename = Nothing
                End Try
            Catch ex1 As Exception
                sTempFilename = Nothing
            End Try
        End Sub

        Public ReadOnly Property Data As Byte()
            Get
                Return oData
            End Get
        End Property

        Public ReadOnly Property Size As Long
            Get
                Return oData.LongLength
            End Get
        End Property

        Friend Function GetCategory() As FTTLib.FileCategory
            Return FTTLib.FTT.GetFileCategory(GetMimeTypeFileExtensions(sMimetype))
        End Function

        Private oThumbnail As Image
        Private oGrayscaleThumbnail As Image

        Private Sub pRefreshThumbnail(Grayscale As Boolean)
            Try
                Using oMs As MemoryStream = New MemoryStream(oData)
                    Using oImage As Bitmap = New Bitmap(oMs)
                        If Grayscale Then
                            oGrayscaleThumbnail = modPaint.GrayScaleImage(modPaint.GetImageThumbnail(oImage, 32, 32))
                        Else
                            oThumbnail = modPaint.GetImageThumbnail(oImage, 32, 32)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                If Grayscale Then
                    oGrayscaleThumbnail = My.Resources.image1
                Else
                    oThumbnail = My.Resources.image
                End If
            End Try
        End Sub

        Public Function GetThumbnail(Optional Grayscale As Boolean = False) As Bitmap
            If Grayscale Then
                Select Case GetCategory()
                    Case FTTLib.FileCategory.Audio
                        Return My.Resources.sound1
                    Case FTTLib.FileCategory.Image
                        'Return My.Resources.image1
                        If IsNothing(oGrayscaleThumbnail) Then
                            Call pRefreshThumbnail(Grayscale)
                        End If
                        Return oGrayscaleThumbnail
                    Case Else
                        Return My.Resources.document_image1
                End Select
            Else
                Select Case GetCategory()
                    Case FTTLib.FileCategory.Audio
                        Return My.Resources.sound
                    Case FTTLib.FileCategory.Image
                        'Return My.Resources.image
                        If IsNothing(oThumbnail) Then
                            Call pRefreshThumbnail(Grayscale)
                        End If
                        Return oThumbnail
                    Case Else
                        Return My.Resources.document_image
                End Select
            End If
        End Function

        Public Sub New(Attachment As cAttachment)
            sMimetype = Attachment.sMimetype
            oData = Attachment.oData.Clone
            sID = Attachment.sID
            sName = Attachment.sName
            sNote = Attachment.sNote
        End Sub

        Public Shared Function GetMimeTypeFileExtensions(MimeType As String) As String
            Dim oExts As String() = FTTLib.FTT.GetMimeTypeFileExtensions(MimeType)
            If IsNothing(oExts) OrElse oExts.Length = 0 Then
                Return "dat"
            Else
                Return oExts(0)
            End If
        End Function

        Public Shared Function GetMimetype(Filename As String) As String
            Return FTTLib.FTT.GetMimeType(Filename)
            'application/octet-stream
        End Function

        Public Sub New(Filename As String)
            sMimetype = GetMimetype(Filename)
            sName = IO.Path.GetFileName(Filename)
            oData = My.Computer.FileSystem.ReadAllBytes(Filename)
            sID = modMain.CalculateHash(oData)
            sNote = ""
        End Sub

        Public Sub New(MimeType As String, Data As Byte(), Optional Name As String = "", Optional Note As String = "")
            sMimetype = MimeType
            oData = Data
            sID = modMain.CalculateHash(oData)
            sName = Name
            sNote = Note
        End Sub

        Public Sub New(MimeType As String, Data As String, Optional Name As String = "", Optional Note As String = "")
            sMimetype = MimeType
            oData = Convert.FromBase64String(Data)
            sID = modMain.CalculateHash(oData)
            sName = Name
            sNote = Note
        End Sub

        Friend Sub New(ByVal File As Storage.cFile, ByVal Attachment As XmlElement)
            sID = modXML.GetAttributeValue(Attachment, "id", "")
            sMimetype = modXML.GetAttributeValue(Attachment, "type", "")
            sName = modXML.GetAttributeValue(Attachment, "name", "")
            sNote = modXML.GetAttributeValue(Attachment, "note", "")
            Select Case File.FileFormat
                Case Storage.cFile.FileFormatEnum.CSX
                    oData = Convert.FromBase64String(modXML.GetAttributeValue(Attachment, "data"))
                Case Storage.cFile.FileFormatEnum.CSZ
                    Dim sDataPath As String = modXML.GetAttributeValue(Attachment, "data")
                    oData = DirectCast(File.Data(sDataPath), Storage.cStorageItemFile).Stream.ToArray
            End Select
            If sID = "" Then
                sID = modMain.CalculateHash(oData)
            End If
        End Sub

        Public Property Name As String
            Get
                Return sName
            End Get
            Set(value As String)
                If sName <> value Then
                    sName = value
                End If
            End Set
        End Property

        Public Property Note As String
            Get
                Return sNote
            End Get
            Set(value As String)
                If sNote <> value Then
                    sNote = value
                End If
            End Set
        End Property

        Public ReadOnly Property ID As String
            Get
                Return sID
            End Get
        End Property

        Public ReadOnly Property MimeType() As String
            Get
                Return sMimetype
            End Get
        End Property

        Public Function IsEmpty() As Boolean
            Return (IsNothing(oData)) OrElse (oData.Length = 0)
        End Function

        Friend Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oItem As XmlElement = Document.CreateElement("attachment")
            Call oItem.SetAttribute("id", sID)
            Call oItem.SetAttribute("type", sMimetype)
            If sName <> "" Then Call oItem.SetAttribute("name", sName)
            If sNote <> "" Then Call oItem.SetAttribute("note", sNote)
            If Not (File.Options And Storage.cFile.FileOptionsEnum.DontSaveBinary) = Storage.cFile.FileOptionsEnum.DontSaveBinary Then
                Select Case File.FileFormat
                    Case Storage.cFile.FileFormatEnum.CSX
                        Call oItem.SetAttribute("data", Convert.ToBase64String(oData))
                    Case Storage.cFile.FileFormatEnum.CSZ
                        Dim sDataPath As String = "_data\attachments\" & sID & "." & GetMimeTypeFileExtensions(sMimetype)
                        Dim oDataStorage As Storage.cStorageItemFile = File.Data.AddFile(sDataPath)
                        Call oDataStorage.Stream.Write(oData, 0, oData.Length)
                        Call oItem.SetAttribute("data", sDataPath)
                End Select
            End If
            Call Parent.AppendChild(oItem)
            Return oItem
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    If Not IsNothing(sTempFilename) Then
                        Try
                            Call My.Computer.FileSystem.DeleteFile(sTempFilename)
                        Catch ex As Exception
                        End Try
                    End If
                    oData = Nothing
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

    Friend Class cAttachmentsBaseCollection
        Inherits KeyedCollection(Of String, cAttachment)

        Protected Overrides Function GetKeyForItem(ByVal item As cAttachment) As String
            Return item.ID
        End Function
    End Class

    Public Class cAttachmentsLink
        Implements cICleanUpSubItem

        Private oSurvey As cSurvey
        Private oOwner As Object
        Private WithEvents oAttachment As cAttachment
        Friend Event OnCleanUp(Sender As Object, e As EventArgs)

        Friend Function GetCategory() As FTTLib.FileCategory
            Return oAttachment.GetCategory
        End Function

        Friend Sub New(ByVal Survey As cSurvey, Owner As Object, Attachment As cAttachment)
            oSurvey = Survey
            oOwner = Owner
            oAttachment = Attachment
        End Sub

        Private Sub oAttachment_OnCleanUpOwnerRequest(Sender As Object, Args As cCleanUpItemOwnersRequestargs) Handles oAttachment.OnCleanUpOwnerRequest
            Call Args.Append(Me)
        End Sub

        Friend Sub PerformCleanUp() Implements cICleanUpSubItem.PerformCleanUp
            Dim oTempAttachment As cAttachment = oAttachment
            oAttachment = Nothing
            oSurvey.Attachments.CleanUp(oTempAttachment)
            RaiseEvent OnCleanUp(Me, New EventArgs)
        End Sub

        Friend ReadOnly Property Survey() As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public ReadOnly Property Owner() As Object
            Get
                Return oOwner
            End Get
        End Property

        Public ReadOnly Property Attachment As cAttachment
            Get
                Return oAttachment
            End Get
        End Property

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement)
            Dim oXmlAttachment As XmlElement = Document.CreateElement("attachment")
            If (File.Options And Storage.cFile.FileOptionsEnum.EmbedResource) = Storage.cFile.FileOptionsEnum.EmbedResource Then
                Call oXmlAttachment.SetAttribute("type", oAttachment.MimeType)
                If oAttachment.Name <> "" Then Call oXmlAttachment.SetAttribute("name", oAttachment.Name)
                If oAttachment.Note <> "" Then Call oXmlAttachment.SetAttribute("note", oAttachment.Note)
                Call oXmlAttachment.SetAttribute("data", Convert.ToBase64String(oAttachment.Data))
                Call oXmlAttachment.SetAttribute("dataformat", cAttachmentLinks.cAttachmentDataFormatEnum.Data.ToString("D"))
            Else
                Call oXmlAttachment.SetAttribute("data", oAttachment.ID)
                Call oXmlAttachment.SetAttribute("dataformat", cAttachmentLinks.cAttachmentDataFormatEnum.Resource.ToString("D"))
            End If
            Call Parent.AppendChild(oXmlAttachment)
            Return oXmlAttachment
        End Function

        Friend Sub New(ByVal Survey As cSurvey, Owner As Object, ByVal Attachment As XmlElement)
            oSurvey = Survey
            oOwner = Owner
            Dim sData As String = modXML.GetAttributeValue(Attachment, "data", "")
            Dim iDataFormat As cAttachmentLinks.cAttachmentDataFormatEnum = modXML.GetAttributeValue(Attachment, "dataformat", cAttachmentLinks.cAttachmentDataFormatEnum.Resource)
            Select Case iDataFormat
                Case cAttachmentLinks.cAttachmentDataFormatEnum.File
                    oAttachment = oSurvey.Attachments.Add(sData)
                    Dim sNote As String = modXML.GetAttributeValue(Attachment, "note", "")
                    oAttachment.Note = sNote
                Case cAttachmentLinks.cAttachmentDataFormatEnum.Data
                    Dim sMimetype As String = modXML.GetAttributeValue(Attachment, "type", "")
                    Dim sName As String = modXML.GetAttributeValue(Attachment, "name", "")
                    Dim sNote As String = modXML.GetAttributeValue(Attachment, "note", "")
                    oAttachment = oSurvey.Attachments.Add(sMimetype, sData, sName, sNote)
                Case cAttachmentLinks.cAttachmentDataFormatEnum.Resource
                    oAttachment = oSurvey.Attachments(sData)
            End Select
        End Sub
    End Class

    Public Class cAttachmentLinks
        Implements IEnumerable
        Implements IEnumerable(Of cAttachmentsLink)

        Private oSurvey As cSurvey
        Private oOwner As Object
        Private oItems As List(Of cAttachmentsLink)

        Public Enum cAttachmentDataFormatEnum
            Data = 0
            File = 1
            Resource = 2
        End Enum

        Public ReadOnly Property Owner() As Object
            Get
                Return oOwner
            End Get
        End Property

        Public Sub New(ByVal Survey As cSurvey, Owner As Object)
            oSurvey = Survey
            oOwner = Owner
            oItems = New List(Of cAttachmentsLink)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, Owner As Object, Attanchments As cAttachmentLinks)
            oSurvey = Survey
            oOwner = Owner
            oItems = New List(Of cAttachmentsLink)
            For Each oAttachment As cAttachmentsLink In Attanchments
                Dim oitem As cAttachmentsLink = New cAttachmentsLink(oSurvey, oOwner, oAttachment.Attachment)
                Call oItems.Add(oitem)
            Next
        End Sub

        Public Function Add(Filename As String) As cAttachmentsLink
            Dim oItem As cAttachmentsLink = New cAttachmentsLink(oSurvey, oOwner, oSurvey.Attachments.Add(Filename))
            Call oItems.Add(oItem)
            Return oItem
        End Function

        Public Sub Clear()
            For Each oAttachment As cAttachmentsLink In oItems
                Call oAttachment.PerformCleanUp()
            Next
            Call oItems.Clear()
        End Sub

        Public Sub Remove(Attachment As cAttachmentsLink)
            If oItems.Contains(Attachment) Then
                Call oItems.Remove(Attachment)
                Call Attachment.PerformCleanUp()
            End If
        End Sub

        Public Sub Remove(Index As Integer)
            If Index >= 0 And Index < oItems.Count Then
                Dim oAttachment As cAttachmentsLink = oItems(Index)
                Call oItems.RemoveAt(Index)
                Call oAttachment.PerformCleanUp()
            End If
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Default Public ReadOnly Property Item(Index As Integer) As cAttachmentsLink
            Get
                If Index >= 0 And Index < oItems.Count Then
                    Return oItems(Index)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, Owner As Object, ByVal Attachments As XmlElement)
            oSurvey = Survey
            oOwner = Owner
            oItems = New List(Of cAttachmentsLink)
            For Each oXMLAttachment As XmlElement In Attachments.ChildNodes
                Dim oItem As cAttachmentsLink = New cAttachmentsLink(oSurvey, oOwner, oXMLAttachment)
                Call oItems.Add(oItem)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement)
            Dim oXmlAttachments As XmlElement = Document.CreateElement("attachments")
            For Each oItem As cAttachmentsLink In oItems
                Call oItem.SaveTo(File, Document, oXmlAttachments)
            Next
            Call Parent.AppendChild(oXmlAttachments)
            Return oXmlAttachments
        End Function

        Friend ReadOnly Property Survey() As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Public Function ToArray() As cAttachmentsLink()
            Return oItems.ToArray
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator(Of cAttachmentsLink) Implements IEnumerable(Of cAttachmentsLink).GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class

    Public Class cAttachments
        Implements IEnumerable
        Implements cICleanUpParent(Of cAttachment)

        Private oSurvey As cSurvey
        Private oItems As cAttachmentsBaseCollection

        Friend Event OnAdd(Sender As Object, File As cAttachment)

        Public Sub CleanUp(Attachment As cAttachment) Implements cICleanUpParent(Of cAttachment).CleanUp
            Dim oOwners As List(Of Object) = New List(Of Object)
            Call Attachment.CleanUpOwnersRequest(oOwners)
            If oOwners.Count = 0 Then
                Call oItems.Remove(Attachment)
            End If
        End Sub

        Public Sub CleanUp() Implements cICleanUpParent(Of cAttachment).CleanUp
            Call oSurvey.RaiseOnProgressEvent("cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, modMain.GetLocalizedString("attachments.cleanup"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageCalculate Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow)
            'Dim oUsedClipartIDs As List(Of String) = New List(Of String)
            'Dim oDeletedClipartIDs As List(Of String) = New List(Of String)
            'Dim oDesignItems As List(Of cItem) = oSurvey.GetAllDesignItems
            'Dim iIndex As Integer = 0
            'Dim iCount As Integer = oDesignItems.Count
            'For Each oItem As cItem In oDesignItems
            '    iIndex += 1
            '    If (iIndex Mod 10) = 0 Then Call oSurvey.RaiseOnProgressEvent("cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Ricerca clipart utilizzate...", iIndex / iCount)
            '    If oItem.Type = cIItem.cItemTypeEnum.Clipart Then
            '        Dim oItemClipart As Items.cItemClipart = oItem
            '        Call oUsedClipartIDs.Add(oItemClipart.Clipart.ID)
            '    End If
            '    If oItem.Type = cIItem.cItemTypeEnum.Sign Then
            '        Dim oItemSign As Items.cItemSign = oItem
            '        Call oUsedClipartIDs.Add(oItemSign.Clipart.ID)
            '    End If
            'Next
            'iIndex = 0
            'iCount = oItems.Count
            'For Each oItem As cClipart In oItems
            '    iIndex += 1
            '    If (iIndex Mod 10) = 0 Then Call oSurvey.RaiseOnProgressEvent("cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Ricerca clipart da eliminare...", iIndex / iCount)
            '    If Not oUsedClipartIDs.Contains(oItem.ID) Then
            '        Call oDeletedClipartIDs.Add(oItem.ID)
            '    End If
            'Next
            'iIndex = 0
            'iCount = oDeletedClipartIDs.Count
            'For Each sID As String In oDeletedClipartIDs
            '    iIndex += 1
            '    If (iIndex Mod 10) = 0 Then Call oSurvey.RaiseOnProgressEvent("cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Eliminazione clipart...", iIndex / iCount)
            '    Call oItems.Remove(sID)
            'Next
            Call oSurvey.RaiseOnProgressEvent("cleanup", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)
        End Sub

        Public Function IndexOf(Item As cAttachment) As Integer
            Return oItems.IndexOf(Item)
        End Function

        Friend ReadOnly Property Survey() As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, Attachments As cAttachments)
            oSurvey = Survey
            oItems = New cAttachmentsBaseCollection
            For Each oAttachment As cAttachment In Attachments
                Dim oItem As cAttachment = New cAttachment(oAttachment)
                Call oItems.Add(oItem)
            Next
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oItems = New cAttachmentsBaseCollection
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As Storage.cFile, ByVal Attachments As XmlElement)
            oSurvey = Survey
            oItems = New cAttachmentsBaseCollection
            Dim iIndex As Integer = 0
            Dim iCount As Integer = Attachments.ChildNodes.Count
            For Each oXMLAttachment As XmlElement In Attachments.ChildNodes
                iIndex += 1
                Dim oItem As cAttachment = New cAttachment(File, oXMLAttachment)
                If Not oItem.IsEmpty Then
                    Call oItems.Add(oItem)
                End If
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum)
            Dim oXmlAttachments As XmlElement = Document.CreateElement("attachments")
            For Each oItem As cAttachment In oItems
                Call oItem.SaveTo(File, Document, oXmlAttachments)
            Next
            Call Parent.AppendChild(oXmlAttachments)
            Return oXmlAttachments
        End Function

        Public Overridable Function Add(Filename As String) As cAttachment
            Dim oItem As cAttachment = New cAttachment(Filename)
            oItem = Add(oItem)
            RaiseEvent OnAdd(Me, oItem)
            Return oItem
        End Function

        Public Overridable Function Add(MimeType As String, Data As Byte(), Optional Name As String = "", Optional Note As String = "") As cAttachment
            Dim oItem As cAttachment = New cAttachment(MimeType, Data, Name, Note)
            oItem = Add(oItem)
            RaiseEvent OnAdd(Me, oItem)
            Return oItem
        End Function

        Public Overridable Function Add(MimeType As String, Data As String, Optional Name As String = "", Optional Note As String = "") As cAttachment
            Dim oItem As cAttachment = New cAttachment(MimeType, Data, Name, Note)
            oItem = Add(oItem)
            RaiseEvent OnAdd(Me, oItem)
            Return oItem
        End Function

        Friend Function Add(Item As cAttachment) As cAttachment
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

        Public Function Contains(Item As cAttachment, Optional CheckByID As Boolean = True) As Boolean
            If CheckByID Then
                Return oItems.Contains(Item.ID)
            Else
                Return oItems.Contains(Item)
            End If
        End Function

        Public Function Contains(ID As String) As Boolean
            Return oItems.Contains(ID)
        End Function

        Default ReadOnly Property Item(ID As String) As cAttachment
            Get
                If oItems.Contains(ID) Then
                    Return oItems(ID)
                End If
            End Get
        End Property

        Default ReadOnly Property Item(Index As Integer) As cAttachment
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

        Public Sub Remove(Item As cAttachment)
            If oItems.Contains(Item) Then
                Call oItems.Remove(Item)
            Else
                Call Remove(Item.ID)
            End If
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace