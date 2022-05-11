Imports System.IO
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Drawings
Imports System.Xml
Imports System.ComponentModel
Imports cSurveyPC.cSurvey.Design.Items
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized

Namespace cSurvey
    Public Class cGalleryMetadata
        Public Class cLocalizedCaption
            Private sCaption As String
            Private sLanguage As String

            Public Sub New()
                sLanguage = ""
                sCaption = ""
            End Sub

            Public Sub New(Language As String, Caption As String)
                sLanguage = Language
                sCaption = Caption
            End Sub

            <Category("General")>
            Public Property Caption As String
                Get
                    Return sCaption
                End Get
                Set(value As String)
                    If sCaption <> value Then
                        sCaption = value.Trim
                    End If
                End Set
            End Property

            <Category("General")>
            Public Property Language As String
                Get
                    Return sLanguage
                End Get
                Set(value As String)
                    If sLanguage <> value Then
                        sLanguage = value.Trim
                    End If
                End Set
            End Property
        End Class

        Private oClipart As cDrawClipArt
        Private sFilename As String

        Private sCaption As String

        Private sAuthor As String
        Private sNote As String
        Private iSign As Items.cIItemSign.SignEnum
        Private iCategory As Items.cIItemSign.SignCategoryEnum
        Private sRotationAngleDelta As Single
        Private sScale As Single

        Private WithEvents oCaptions As List(Of cLocalizedCaption)

        <Category("General"), Description("Filename"), RefreshProperties(RefreshProperties.All)>
        Public ReadOnly Property Filename As String
            Get
                Return sFilename
            End Get
        End Property

        <Category("General"), Description("Localized captions"), RefreshProperties(RefreshProperties.All)>
        Public ReadOnly Property Captions As List(Of cLocalizedCaption)
            Get
                Return oCaptions
            End Get
        End Property

        <Category("General"), Description("Generic caption")>
        Public Property Caption As String
            Get
                Return sCaption
            End Get
            Set(value As String)
                If sCaption <> value Then
                    sCaption = value
                    Call pSave()
                End If
            End Set
        End Property

        <Category("General")>
        Public Property Author As String
            Get
                Return sAuthor
            End Get
            Set(value As String)
                If sAuthor <> value Then
                    sAuthor = value
                    Call pSave()
                End If
            End Set
        End Property

        <Category("General")>
        Public Property Note As String
            Get
                Return sNote
            End Get
            Set(value As String)
                If sNote <> value Then
                    sNote = value
                    Call pSave()
                End If
            End Set
        End Property

        <Category("Sign")>
        Public Property Scale As Single
            Get
                Return sScale
            End Get
            Set(value As Single)
                If sScale <> value Then
                    sScale = value
                    Call pSave()
                End If
            End Set
        End Property

        <Category("Sign")>
        Public Property RotationAngleDelta As Single
            Get
                Return sRotationAngleDelta
            End Get
            Set(value As Single)
                If sRotationAngleDelta <> value Then
                    sRotationAngleDelta = value
                    Call pSave()
                End If
            End Set
        End Property

        <Category("Sign")>
        Public Property Sign As Items.cIItemSign.SignEnum
            Get
                Return iSign
            End Get
            Set(value As Items.cIItemSign.SignEnum)
                If iSign <> value Then
                    iSign = value
                    Call pSave()
                End If
            End Set
        End Property

        <Category("Sign")>
        Public Property Category As Items.cIItemSign.SignCategoryEnum
            Get
                Return iCategory
            End Get
            Set(value As Items.cIItemSign.SignCategoryEnum)
                If iCategory <> value Then
                    iCategory = value
                    Call pSave()
                End If
            End Set
        End Property

        Public Sub Save()
            Call pSave()
        End Sub

        Private Sub pSave()
            Call oClipart.UserData.SetTypedValue(Data.cDataFields.TypeEnum.Text, "caption", sCaption)
            Call oClipart.UserData.SetTypedValue(Data.cDataFields.TypeEnum.Text, "author", sAuthor)
            Call oClipart.UserData.SetTypedValue(Data.cDataFields.TypeEnum.Text, "note", sNote)
            Call oClipart.UserData.SetTypedValue(Data.cDataFields.TypeEnum.Enum, "sign", iSign)
            Call oClipart.UserData.SetTypedValue(Data.cDataFields.TypeEnum.Single, "rotationangledelta", sRotationAngleDelta)
            Call oClipart.UserData.SetTypedValue(Data.cDataFields.TypeEnum.Single, "scale", sScale)
            Call oClipart.UserData.SetTypedValue(Data.cDataFields.TypeEnum.Enum, "category", iCategory)

            For Each oCaption As cLocalizedCaption In oCaptions
                Call oClipart.UserData.SetTypedValue(Data.cDataFields.TypeEnum.Text, "caption." & oCaption.Language, oCaption.Caption)
            Next

            If sFilename <> "" Then
                If My.Computer.FileSystem.FileExists(sFilename) Then
                    Dim oXML As XmlDocument = New XmlDocument
                    oXML.XmlResolver = Nothing
                    Call oXML.Load(sFilename)
                    Dim oXMLRoot As XmlElement = oXML.Item("svg")
                    Dim sPrefix As String = "csurvey"
                    Dim sURI As String = "http://www.csurvey.it"

                    Dim oNSM As XmlNamespaceManager = New XmlNamespaceManager(oXML.NameTable)
                    If Not oNSM.HasNamespace(sPrefix) Then
                        Call oXMLRoot.SetAttribute("xmlns:" & sPrefix, sURI)
                    End If

                    Call oXMLRoot.SetAttribute("caption", sURI, sCaption)
                    Call oXMLRoot.SetAttribute("author", sURI, sAuthor)
                    Call oXMLRoot.SetAttribute("note", sURI, sNote)
                    Call oXMLRoot.SetAttribute("sign", sURI, iSign.ToString("D"))
                    If sRotationAngleDelta <> 0 Then Call oXMLRoot.SetAttribute("rotationangledelta", sURI, modNumbers.NumberToString(sRotationAngleDelta, "0.0"))
                    If sScale <> 1 Then Call oXMLRoot.SetAttribute("scale", sURI, modNumbers.NumberToString(sScale, "0.0"))
                    If iCategory <> cIItemSign.SignCategoryEnum.Undefined Then Call oXMLRoot.SetAttribute("category", iCategory.ToString("D"))
                    For Each oCaption As cLocalizedCaption In oCaptions
                        If oCaption.Language <> "" AndAlso oCaption.Caption <> "" Then
                            Call oXMLRoot.SetAttribute("caption." & oCaption.Language, sURI, oCaption.Caption)
                        End If
                    Next

                    'Try
                    'check why sometime crash here...
                    Call XMLAddDeclaration(oXML)
                    'Catch
                    'End Try

                    Call oXML.Save(sFilename)
                End If
            End If
        End Sub

        Public Sub New(Clipart As cDrawClipArt, Filename As String)
            oClipart = Clipart
            sFilename = Filename

            oCaptions = New List(Of cLocalizedCaption)

            sCaption = oClipart.UserData.GetTypedValue(Data.cDataFields.TypeEnum.Text, "caption", "")
            For Each oCaption As KeyValuePair(Of String, String) In oClipart.UserData.GetTypedValues(Data.cDataFields.TypeEnum.Text, "caption.*")
                Call oCaptions.Add(New cLocalizedCaption(oCaption.Key.Substring(oCaption.Key.IndexOf(".") + 1), oCaption.Value))
            Next
            sAuthor = oClipart.UserData.GetTypedValue(Data.cDataFields.TypeEnum.Text, "author", "")
            sNote = oClipart.UserData.GetTypedValue(Data.cDataFields.TypeEnum.Text, "note", "")
            iSign = oClipart.UserData.GetTypedValue(Data.cDataFields.TypeEnum.Enum, "sign", Items.cIItemSign.SignEnum.Undefined)
            sRotationAngleDelta = oClipart.UserData.GetTypedValue(Data.cDataFields.TypeEnum.Single, "rotationangledelta", 0)
            sScale = oClipart.UserData.GetTypedValue(Data.cDataFields.TypeEnum.Single, "scale", 1)
            iCategory = oClipart.UserData.GetTypedValue(Data.cDataFields.TypeEnum.Enum, "category", (iSign And Category.Mask))
        End Sub

    End Class

    Public Class cGallery
        Private sParentPath As String
        Private sName As String
        Private bGroupable As Boolean

        Private oGrid As DevExpress.XtraGrid.GridControl

        Public ReadOnly Property Grid As DevExpress.XtraGrid.GridControl
            Get
                Return oGrid
            End Get
        End Property

        Public ReadOnly Property Groupable As Boolean
            Get
                Return bGroupable
            End Get
        End Property

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public ReadOnly Property ParentPath As String
            Get
                Return sParentPath
            End Get
        End Property

        Public Sub New(ParentPath As String, Name As String, Groupable As Boolean, Grid As DevExpress.XtraGrid.GridControl)
            sParentPath = ParentPath
            sname = Name
            bGroupable = Groupable
            oGrid = Grid
        End Sub
    End Class

    Public Class cGalleryItem
        Implements IDisposable

        Private sFilename As String
        Private oFl As FileInfo
        Private sName As String
        Private oPreview As Image
        Private oClipart As cDrawClipArt
        Private oMetadata As cGalleryMetadata

        Public ReadOnly Property Filename As String
            Get
                Return sFilename
            End Get
        End Property

        Public ReadOnly Property Category As cIItemSign.SignCategoryEnum
            Get
                Return oMetadata.Category
            End Get
        End Property

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public ReadOnly Property Caption As String
            Get
                Return oMetadata.Caption
            End Get
        End Property

        Public ReadOnly Property Note As String
            Get
                Return oMetadata.Note
            End Get
        End Property

        Public ReadOnly Property Author As String
            Get
                Return oMetadata.Author
            End Get
        End Property

        Public ReadOnly Property Sign As cIItemSign.SignEnum
            Get
                Return oMetadata.Sign
            End Get
        End Property

        Public ReadOnly Property Clipart As cDrawClipArt
            Get
                Return oClipart
            End Get
        End Property

        Public ReadOnly Property Preview As Image
            Get
                Return oPreview
            End Get
        End Property

        Public ReadOnly Property Metadata As cGalleryMetadata
            Get
                Return oMetadata
            End Get
        End Property

        Public ReadOnly Property File As FileInfo
            Get
                Return oFl
            End Get
        End Property

        Public Sub New(Clipart As cClipart)
            oFl = Nothing
            sFilename = "id://" & Clipart.ID
            oClipart = Clipart.Clipart
            sName = oClipart.UserData.GetValue("caption" & "." & My.Application.CurrentLanguage, oClipart.UserData.GetValue("caption", IO.Path.GetFileNameWithoutExtension(Clipart.Name)))
            oPreview = oClipart.GetThumbnailImage(48, 48)
            oMetadata = New cGalleryMetadata(oClipart, Clipart.ID)
        End Sub

        Public Sub New(File As FileInfo)
            oFl = File
            sFilename = "file://" & oFl.FullName
            oClipart = New cDrawClipArt(oFl.FullName)
            sName = oClipart.UserData.GetValue("caption" & "." & My.Application.CurrentLanguage, oClipart.UserData.GetValue("caption", IO.Path.GetFileNameWithoutExtension(oFl.Name)))
            oPreview = oClipart.GetThumbnailImage(48, 48)
            oMetadata = New cGalleryMetadata(oClipart, oFl.FullName)
        End Sub

        Private disposedValue As Boolean

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    If Not oPreview Is Nothing Then
                        Call oPreview.Dispose()
                        oPreview = Nothing
                    End If
                End If
                disposedValue = True
            End If
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(disposing:=True)
            GC.SuppressFinalize(Me)
        End Sub
    End Class

    Public Class cSingsImportHelper
        Public Shared Function CreateIndex(Gallery As List(Of cGalleryItem)) As Dictionary(Of cIItemSign.SignEnum, String)
            Dim oResults As Dictionary(Of cIItemSign.SignEnum, String) = New Dictionary(Of cIItemSign.SignEnum, String)
            For Each oItem As cGalleryItem In Gallery
                Dim sFilename As String = oItem.Filename
                Dim oClipart As Drawings.cDrawClipArt = oItem.Clipart
                Dim iSign As cIItemSign.SignEnum = GetSignFromClipart(oClipart)
                If iSign <> cIItemSign.SignEnum.Undefined AndAlso Not oResults.ContainsKey(iSign) Then
                    Call oResults.Add(iSign, sFilename)
                End If
            Next
            Return oResults
        End Function

        Public Shared Function FindInIndex(Index As Dictionary(Of cIItemSign.SignEnum, Drawings.cDrawClipArt), Key As cIItemSign.SignEnum, Optional DefaultValue As Drawings.cDrawClipArt = Nothing) As Drawings.cDrawClipArt
            If Index.ContainsKey(Key) Then
                Return Index(Key)
            Else
                Return DefaultValue
            End If
        End Function

        Public Shared Function GetSignFromClipart(Clipart As Drawings.cDrawClipArt) As cIItemSign.SignEnum
            If Clipart.UserData.Contains("sign") Then
                Dim sSign As String = Clipart.UserData.GetValue("sign", "")
                If sSign = "" Then
                    Return cIItemSign.SignEnum.Undefined
                Else
                    Dim iSign As cIItemSign.SignEnum
                    If Integer.TryParse(sSign, iSign) Then
                        Return DirectCast([Enum].Parse(GetType(cIItemSign.SignEnum), iSign), cIItemSign.SignEnum)
                    Else
                        Return Design.Items.cIItemSign.SignEnum.Undefined
                    End If
                End If
            Else
                Return Design.Items.cIItemSign.SignEnum.Undefined
            End If
        End Function
    End Class
End Namespace
