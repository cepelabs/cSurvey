Imports System.IO
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Drawings
Imports System.Xml
Imports System.ComponentModel
Imports cSurveyPC.cSurvey.Design.Items
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized

Public Class frmClipartPopup
    Private bLoaded As Boolean

    Private oSurvey As cSurvey.cSurvey

    Private bLoadItems As Boolean

    Private sPath As String
    Private sName As String

    Public Enum ViewModeEnum
        Gallery = 0
        Survey = 1
    End Enum

    Private iView As ViewModeEnum

    Public Class OnItemEventArgs
        Private oBag As Object
        Private sName As String
        Private sFilename As String

        Public ReadOnly Property Bag As Object
            Get
                Return oBag
            End Get
        End Property

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public ReadOnly Property Filename As String
            Get
                Return sFilename
            End Get
        End Property

        Friend Sub New(ByVal Bag As Object, ByVal Name As String, ByVal Filename As String)
            oBag = Bag
            sName = Name
            sFilename = Filename
        End Sub
    End Class

    Friend Event OnItemCreate(ByVal Sender As frmClipartPopup, ByVal e As OnItemEventArgs)

    Private oDragItem As OnItemEventArgs
    Private oDragboxFromMouseDown As Rectangle
    Private oDragScreenOffset As Point

    Private oCurrentLv As ListView

    Private oMousePointer As cMousePointer

    Private Class cMetadata
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
        'Private iSignCategory As Items.cIItemSign.SignCategoryEnum
        Private sRotationAngleDelta As Single
        Private sScale As Single

        Private WithEvents oCaptions As List(Of cLocalizedCaption)

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

        Public Sub Save()
            Call pSave()
        End Sub

        Private Sub pSave()
            Call oClipart.UserData.SetTypedValue(cSurvey.Data.cDataFields.TypeEnum.Text, "caption", sCaption)
            Call oClipart.UserData.SetTypedValue(cSurvey.Data.cDataFields.TypeEnum.Text, "author", sAuthor)
            Call oClipart.UserData.SetTypedValue(cSurvey.Data.cDataFields.TypeEnum.Text, "note", sNote)
            Call oClipart.UserData.SetTypedValue(cSurvey.Data.cDataFields.TypeEnum.Enum, "sign", iSign)
            Call oClipart.UserData.SetTypedValue(cSurvey.Data.cDataFields.TypeEnum.Single, "rotationangledelta", sRotationAngleDelta)
            Call oClipart.UserData.SetTypedValue(cSurvey.Data.cDataFields.TypeEnum.Single, "scale", sScale)

            For Each oCaption As cLocalizedCaption In oCaptions
                Call oClipart.UserData.SetTypedValue(cSurvey.Data.cDataFields.TypeEnum.Text, "caption." & oCaption.Language, oCaption.Caption)
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

            sCaption = oClipart.UserData.GetTypedValue(cSurvey.Data.cDataFields.TypeEnum.Text, "caption", "")
            For Each oCaption As KeyValuePair(Of String, String) In oClipart.UserData.GetTypedValues(cSurvey.Data.cDataFields.TypeEnum.Text, "caption.*")
                Call oCaptions.Add(New cLocalizedCaption(oCaption.Key.Substring(oCaption.Key.IndexOf(".") + 1), oCaption.Value))
            Next
            sAuthor = oClipart.UserData.GetTypedValue(cSurvey.Data.cDataFields.TypeEnum.Text, "author", "")
            sNote = oClipart.UserData.GetTypedValue(cSurvey.Data.cDataFields.TypeEnum.Text, "note", "")
            iSign = oClipart.UserData.GetTypedValue(cSurvey.Data.cDataFields.TypeEnum.Enum, "sign", Items.cIItemSign.SignEnum.Undefined)
            sRotationAngleDelta = oClipart.UserData.GetTypedValue(cSurvey.Data.cDataFields.TypeEnum.Single, "rotationangledelta", 0)
            sScale = oClipart.UserData.GetTypedValue(cSurvey.Data.cDataFields.TypeEnum.Single, "scale", 1)
        End Sub

    End Class

    Public Sub SetSurvey(ByVal Survey As cSurveyPC.cSurvey.cSurvey)
        oSurvey = Survey
    End Sub

    Friend Function GetGalleryCount() As Integer
        Return tabGallery.TabPages.Count
    End Function

    Friend Function GalleryIndexByCategory(Category As cIItem.cItemCategoryEnum) As Integer
        For i As Integer = 0 To tabGallery.TabPages.Count - 1
            If GetGalleryBag(i).category = Category Then
                Return i
            End If
        Next
        Return -1
    End Function

    Friend Function GetGalleryBag(Index As Integer) As Object
        Return tabGallery.TabPages(Index).Controls("listview_" & GetGalleryName(Index)).Tag
    End Function

    Friend Function GetGalleryText(Index As Integer) As String
        With tabGallery.TabPages(Index)
            Return .Text
        End With
    End Function

    Friend Function GetGalleryName(Index As Integer) As String
        With tabGallery.TabPages(Index)
            Return .Tag(1)
        End With
    End Function

    Friend Function GetGalleryPath(Index As Integer) As String
        With tabGallery.TabPages(Index)
            Dim sPath As String = .Tag(0)
            Dim sName As String = .Tag(1)
            Return IO.Path.Combine(sPath, sName)
        End With
    End Function

    Friend Sub AddGallery(ByVal ParentPath As String, ByVal Bag As Object, ByVal Name As String, ByVal Text As String, Groupable As Boolean)
        Dim oTabPage As TabPage = New TabPage
        oTabPage.Name = "tabpage_" & Name
        oTabPage.Text = Text
        oTabPage.Tag = {ParentPath, Name, Groupable}
        Call tabGallery.TabPages.Add(oTabPage)
        Dim oLv As ListView = New ListView
        oLv.Name = "listview_" & Name
        oLv.LargeImageList = iml
        oLv.SmallImageList = iml
        oLv.BorderStyle = BorderStyle.None
        oLv.Tag = Bag
        AddHandler oLv.DoubleClick, AddressOf lv_DoubleClick
        AddHandler oLv.MouseDown, AddressOf lv_MouseDown
        AddHandler oLv.MouseMove, AddressOf lv_MouseMove
        AddHandler oLv.MouseUp, AddressOf lv_MouseUp
        AddHandler oLv.SelectedIndexChanged, AddressOf lv_SelectedIndexChanged
        Call oTabPage.Controls.Add(oLv)
        oLv.MultiSelect = False
        oLv.HideSelection = False
        oLv.Dock = DockStyle.Fill
        oLv.ContextMenuStrip = mnuLvContext

        'bLoadItems = LoadItems
        'If bLoadItems Then
        'Dim oThread As Threading.Thread = New Threading.Thread(AddressOf oThread_callback)
        'Call oThread.Start({Path, Name})
        'End If

        If oCurrentLv Is Nothing Then oCurrentLv = oLv
    End Sub

    Private Sub lv_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Call pMetadataLoad()
    End Sub

    Private Sub pMetadataLoad()
        If oCurrentLv Is Nothing Then
            tableMetadata.Enabled = False
        Else
            If oCurrentLv.SelectedItems.Count < 1 Then
                tableMetadata.Enabled = False
            Else
                tableMetadata.Enabled = True
                Dim oItem As ListViewItem = oCurrentLv.SelectedItems(0)
                Dim oClipart As cDrawClipArt = oItem.Tag(1)
                'qua dovrei caricare i metadati...DA COMPLETARE
                PictureBox1.Image = iml.Images(oItem.ImageKey)
                txtMetadataClipartName.Text = oItem.Text
                txtMetadataClipartFilename.Text = oItem.Tag(0)
                Dim oMetadata As cMetadata = oItem.Tag(2)
                prpMetadataProperties.SelectedObject = oMetadata
            End If
        End If
    End Sub

    Private Sub pAddGroups(Lv As ListView)
        Call Lv.Groups.Clear()
        For Each oValue In System.Enum.GetValues(GetType(Items.cIItemSign.SignCategoryEnum))
            Dim oGroup As ListViewGroup = New ListViewGroup(oValue, GetLocalizedString("main.category" & oValue))
            Call Lv.Groups.Add(oGroup)
        Next
    End Sub

    Public Sub pClipboardLoadItems(ByVal Path As String, ByVal Name As String, Groupable As Boolean)
        Call oMousePointer.Push(Cursors.WaitCursor)
        Dim oLv As ListView = Controls.Find("listview_" & Name, True)(0)
        oLv.Enabled = False
        Call oLv.BeginUpdate()
        Call oLv.Items.Clear()
        Select Case iView
            Case ViewModeEnum.Gallery
                If Groupable Then Call pAddGroups(oLv)
                Dim fd As DirectoryInfo = New DirectoryInfo(IO.Path.Combine(Path, Name))
                If fd.Exists Then
                    For Each fl As FileInfo In fd.GetFiles("*.svg")
                        If Not fl.Name Like "_*" Then
                            Try
                                Dim oClipart As cDrawClipArt = New cDrawClipArt(fl.FullName)
                                Dim oPreview As Image = oClipart.GetThumbnailImage(48, 48)
                                Dim oMetadata As cMetadata = New cMetadata(oClipart, fl.FullName)

                                Dim oItem As ListViewItem = New ListViewItem
                                Dim sName As String = oClipart.UserData.GetValue("caption" & "." & My.Application.CurrentLanguage, oClipart.UserData.GetValue("caption", IO.Path.GetFileNameWithoutExtension(fl.Name)))
                                Dim sImageName As String = Name & "_" & sName
                                If iml.Images.ContainsKey(sImageName) Then
                                    Call iml.Images.RemoveByKey(sImageName)
                                End If
                                Call iml.Images.Add(sImageName, oPreview)

                                oItem.Text = sName
                                oItem.ImageKey = sImageName
                                oItem.Tag = {"file://" & fl.FullName, oClipart, oMetadata}
                                oItem.ToolTipText = fl.FullName
                                If Groupable Then
                                    Dim sGroup As String = oMetadata.Sign And Items.cIItemSign.SignCategoryEnum.Mask
                                    oItem.Group = oLv.Groups(sGroup)
                                End If
                                Call oLv.Items.Add(oItem)
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                End If
            Case ViewModeEnum.Survey
                If Groupable Then Call pAddGroups(oLv)
                Dim oBase As Object = oSurvey.GetType.InvokeMember(oLv.Tag.cliparts, Reflection.BindingFlags.GetProperty Or Reflection.BindingFlags.Public Or Reflection.BindingFlags.IgnoreCase Or Reflection.BindingFlags.Instance, Nothing, oSurvey, Nothing)
                Dim oCliparts As List(Of cSurvey.cClipart) = oBase.getcliparts(oLv.Tag.category)
                For Each oBaseItem As cSurvey.cClipart In oCliparts
                    Dim oClipart As cDrawClipArt = oBaseItem.Clipart
                    Dim oPreview As Image = oClipart.GetThumbnailImage(48, 48)
                    Dim oMetadata As cMetadata = New cMetadata(oClipart, oBaseItem.ID)

                    Dim oItem As ListViewItem = New ListViewItem
                    Dim sName As String = oClipart.UserData.GetValue("caption" & "." & My.Application.CurrentLanguage, oClipart.UserData.GetValue("caption", IO.Path.GetFileNameWithoutExtension(oBaseItem.Name)))
                    Dim sImageName As String = Name & "_" & oBaseItem.ID
                    If iml.Images.ContainsKey(sImageName) Then
                        Call iml.Images.RemoveByKey(sImageName)
                    End If
                    Call iml.Images.Add(sImageName, oPreview)

                    oItem.Text = sName
                    oItem.ImageKey = sImageName
                    oItem.Tag = {"id://" & oBaseItem.ID, oClipart, oMetadata}
                    oItem.ToolTipText = sName
                    If Groupable Then
                        Dim sGroup As String = oMetadata.Sign And Items.cIItemSign.SignCategoryEnum.Mask
                        oItem.Group = oLv.Groups(sGroup)
                    End If
                    Call oLv.Items.Add(oItem)
                Next
        End Select
        Call oLv.EndUpdate()
        oLv.Enabled = True
        Call oMousePointer.Pop()
    End Sub

    Private Sub lv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Call pItemCreate()
    End Sub

    Private Sub lv_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If Not oCurrentLv Is Nothing Then
            Dim oInfo As ListViewHitTestInfo = oCurrentLv.HitTest(e.X, e.Y)
            If Not oInfo.Item Is Nothing Then
                oDragItem = New OnItemEventArgs(oCurrentLv.Tag, oCurrentLv.Name, oInfo.Item.Tag(0))
                Dim oDragSize As Size = SystemInformation.DragSize
                oDragboxFromMouseDown = New Rectangle(New Point(e.X - (oDragSize.Width / 2), e.Y - (oDragSize.Height / 2)), oDragSize)
            Else
                oDragboxFromMouseDown = Rectangle.Empty
            End If
        End If
    End Sub

    Private Sub lv_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If ((e.Button And MouseButtons.Left) = MouseButtons.Left) Then
            If (Rectangle.op_Inequality(oDragboxFromMouseDown, Rectangle.Empty) And Not oDragboxFromMouseDown.Contains(e.X, e.Y)) Then
                oDragScreenOffset = SystemInformation.WorkingArea.Location
                Dim oDropEffect As DragDropEffects = oCurrentLv.DoDragDrop(oDragItem, DragDropEffects.Copy)
            End If
        End If
    End Sub

    Private Sub lv_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        oDragboxFromMouseDown = Rectangle.Empty
    End Sub

    Private Sub pItemRemove()
        If Not oCurrentLv Is Nothing Then
            If oCurrentLv.SelectedItems.Count > 0 Then
                If MsgBox("Rimuovere la clipart dall'elenco (il file verrà rinominato ma non verrà cancellato) in modo che non sia più visibile in questo elenco?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Attenzione") = vbYes Then
                    Dim oItem As ListViewItem = oCurrentLv.SelectedItems(0)
                    Dim sOldFilename As String = oItem.Tag(0)
                    If sOldFilename.StartsWith("file://") Then
                        sOldFilename = sOldFilename.Substring(7)
                    End If
                    Dim sNewFilename As String = Path.Combine(Path.GetDirectoryName(sOldFilename), "_" & Path.GetFileName(sOldFilename))
                    Call My.Computer.FileSystem.MoveFile(sOldFilename, sNewFilename, True)
                    Call oCurrentLv.Items.Remove(oItem)
                End If
            End If
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Call pItemRemove()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Call pItemCreate()
    End Sub

    Private Sub pItemCreate()
        If Not oCurrentLv Is Nothing Then
            If oCurrentLv.SelectedItems.Count > 0 Then
                Dim sName As String = oCurrentLv.Name
                Dim oBag As Object = oCurrentLv.Tag
                Dim sFilename As String = oCurrentLv.SelectedItems(0).Tag(0)
                RaiseEvent OnItemCreate(Me, New OnItemEventArgs(oBag, sName, sFilename))
            End If
        End If
    End Sub

    Private Sub frmClipartPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Visible = False
            e.Cancel = True
        End If
    End Sub

    Private Sub tabGallery_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabGallery.SelectedIndexChanged
        oCurrentLv = tabGallery.SelectedTab.Controls(0)
    End Sub

    Public Function IsGallery(ByVal Listview As ListView) As Boolean
        For Each oTab As TabPage In tabGallery.TabPages
            If oTab.Controls.IndexOf(Listview) <> -1 Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub mnuLvContextRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLvContextRefresh.Click
        Call pRefresh()
    End Sub

    Private Sub mnuLvContextRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLvContextRemove.Click
        Call pItemRemove()
    End Sub

    Private Sub pRefresh()
        Dim oTab As TabPage = tabGallery.SelectedTab
        Dim oData As Object = oTab.Tag
        Dim sPath As String = oData(0)
        Dim sName As String = oData(1)
        Dim bGroupable As Boolean = oData(2)
        Call pClipboardLoadItems(sPath, sName, bGroupable)
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Call pRefresh()
    End Sub

    Protected Overrides Function GetPersistString() As String
        Return "clipartpopup"
    End Function

    Public Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oMousePointer = New cMousePointer
        iView = ViewModeEnum.Gallery
        Call pSetViewState()

        Call pMetadataHide()
        Call pMetadataLoad()
    End Sub

    Private Sub pSetViewState()
        Select Case iView
            Case ViewModeEnum.Gallery
                btnViewGallery.Checked = True
                btnViewSurvey.Checked = False
                btnRemove.Enabled = True
                mnuLvContextRemove.Enabled = True
            Case ViewModeEnum.Survey
                btnViewGallery.Checked = False
                btnViewSurvey.Checked = True
                btnRemove.Enabled = False
                mnuLvContextRemove.Enabled = False
        End Select

        Call iml.Images.Clear()
        For Each oTab As TabPage In tabGallery.TabPages
            Dim oData As Object = oTab.Tag
            Dim sPath As String = oData(0)
            Dim sName As String = oData(1)
            Dim oLv As ListView = Controls.Find("listview_" & sName, True)(0)
            Call oLv.Items.Clear()
        Next
    End Sub

    Private Sub btnViewGallery_Click(sender As System.Object, e As System.EventArgs) Handles btnViewGallery.Click
        iView = ViewModeEnum.Gallery
        Call pSetViewState()
        Call pClipboardLoad()
    End Sub

    Private Sub btnViewSurvey_Click(sender As System.Object, e As System.EventArgs) Handles btnViewSurvey.Click
        iView = ViewModeEnum.Survey
        Call pSetViewState()
        Call pClipboardLoad()
    End Sub

    Private Sub pClipboardLoad()
        If Not modMain.bIsInDebug Then
            For Each oTab As TabPage In tabGallery.TabPages
                Dim oCurrentLv As ListView = oTab.Controls(0)
                If oCurrentLv.Items.Count = 0 Then
                    Dim oData As Object = oTab.Tag
                    Dim sPath As String = oData(0)
                    Dim sName As String = oData(1)
                    Dim bGroupable As Boolean = oData(2)
                    Call pClipboardLoadItems(sPath, sName, bGroupable)
                End If
            Next
        End If
    End Sub

    Private Sub frmClipartPopup_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Call pClipboardLoad()
    End Sub

    Private Sub mnuLvContextEditMetadata_Click(sender As Object, e As EventArgs) Handles mnuLvContextEditMetadata.Click
        SplitContainer1.Panel2Collapsed = False
    End Sub

    Private Sub pMetadataHide()
        SplitContainer1.Panel2Collapsed = True
        btnShowMetadata.Checked = False
    End Sub

    Private Sub pMetadataShow()
        SplitContainer1.Panel2Collapsed = False
        btnShowMetadata.Checked = True
    End Sub

    Private Sub btnShowMetadata_Click(sender As Object, e As EventArgs) Handles btnShowMetadata.Click
        If btnShowMetadata.Checked Then
            Call pMetadataHide()
        Else
            Call pMetadataShow()
        End If
    End Sub

    Private Sub mnuLvContextOpenFolder_Click(sender As Object, e As EventArgs) Handles mnuLvContextOpenFolder.Click
        Dim sPath As String = GetGalleryPath(tabGallery.SelectedIndex)
        Call Process.Start(sPath)
    End Sub

    Private Sub prpMetadataProperties_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles prpMetadataProperties.PropertyValueChanged
        Dim oMetadata As cMetadata = prpMetadataProperties.SelectedObject
        Call oMetadata.save
    End Sub
End Class
