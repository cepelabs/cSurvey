Imports System.Xml
Imports cSurveyPC.cSurvey.Net
Imports cSurveyPC.cSurvey.CaveRegister
Imports cSurveyPC.cSurvey.Scripting

friend Class frmCaveRegister

    Private oSurvey As cSurvey.cSurvey
    Private oRegister As cCaveRegister

    Private Function pDataAdd(Data As cCaveRegisterData) As ListViewItem
        Dim sFormName As String = "form" & Data.CaveID
        Dim oItem As ListViewItem = New ListViewItem
        oItem.Name = Data.CaveID
        oItem.Text = "[" & Data.CaveID & "] " & Data.Name
        oItem.ImageKey = "form"
        Dim oCaveRegister As cCaveRegisterForm = New cCaveRegisterForm(oSurvey, Data)
        oCaveRegister.Name = sFormName
        SplitContainer1.Panel1.Controls.Add(oCaveRegister)
        oCaveRegister.Dock = DockStyle.Fill
        oItem.Tag = oCaveRegister
        Call lvDatas.Items.Add(oItem)
        Return oItem
    End Function

    Private Sub pDataSelect(Item As ListViewItem)
        Item.Selected = True
        lvDatas.FocusedItem = Item
        Call lvDatas_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Public Sub New(Survey As cSurvey.cSurvey, Register As cCaveRegister)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey
        oRegister = Register

        Dim bEnabled As Boolean = oRegister.Settings.Count > 0
        btnAdd.Enabled = bEnabled
        btnSaveAll.Enabled = lvDatas.Items.Count > 0
        lvDatas.Enabled = bEnabled
        SplitContainer1.Enabled = bEnabled

        For Each oData As cCaveRegisterData In oRegister.Datas
            Call pDataAdd(oData)
        Next

        If lvDatas.Items.Count > 0 Then
            Dim oItem As ListViewItem = lvDatas.Items(0)
            Call pDataSelect(oItem)
            Call pSelectItem(oItem)
        End If

        btnDatabindShowHide.Checked = False
        btnDatabindShowHide_CheckedChanged(Nothing, Nothing)
        Call pLoadData()
    End Sub

    Private Sub pLoadSubData(XMLItem As XmlElement, Parent As Object, ParentItem As ListViewItem)
        For Each oXMLSubItem As XmlElement In XMLItem.ChildNodes
            Dim sName As String = oXMLSubItem.GetAttribute("name")

            Dim oItem As ListViewItem = New ListViewItem
            If Not ParentItem Is Nothing Then
                oItem.IndentCount = ParentItem.IndentCount + 1
            End If
            oItem.Text = sName

            Dim sData As String = modXML.GetAttributeValue(oXMLSubItem, "data", "")
            If sData <> "" Then
                oItem.ImageKey = "bullet_database"
                Dim oValue As Object = pGetPropertyValue(Parent, sData)
                Dim sValue As String
                Dim sFormat As String = oXMLSubItem.GetAttribute("format")
                If sFormat <> "" Then
                    sValue = Strings.Format(oValue, sFormat)
                Else
                    If oValue Is Nothing Then
                        sValue = ""
                    Else
                        sValue = oValue.ToString
                    End If
                End If
                Call oItem.SubItems.Add(sValue)
            Else
                oItem.ImageKey = "folder"
            End If
            Call lvData.Items.Add(oItem)

            If oXMLSubItem.HasChildNodes Then
                Dim oXMLSubItems As XmlElement = oXMLSubItem.Item("items")
                Dim sItemsData As String = modXML.GetAttributeValue(oXMLSubItems, "data", "")
                If sItemsData <> "" Then
                    Dim oObject As Object = pGetPropertyValue(Parent, sItemsData)
                    If TypeOf oObject Is IEnumerable Then
                        For Each oSubObject As Object In oObject
                            Dim oSubItem As ListViewItem = New ListViewItem
                            oSubItem.ImageKey = "folder"
                            If Not ParentItem Is Nothing Then
                                oSubItem.IndentCount = ParentItem.IndentCount + 1
                            End If
                            Call lvData.Items.Add(oSubItem)
                            Call pLoadSubData(oXMLSubItems, oSubObject, oSubItem)
                        Next
                    Else
                        Call pLoadSubData(oXMLSubItems, oObject, oItem)
                    End If
                End If
            End If
        Next
    End Sub

    Private Function pGetPropertyValue(ByVal obj As Object, ByVal PropName As String) As Object
        Dim sCode As String = " function getvalue(Survey as object,Parent as object) as object" & vbCrLf & "return " & PropName & vbCrLf & "end function"
        Dim oScript As cScript = New cScript(oSurvey, sCode, LanguageEnum.VisualBasic)
        Return oScript.Eval("getvalue", {oSurvey, obj})

        'Dim objType As Type = obj.GetType()
        'Dim pInfo As System.Reflection.PropertyInfo = objType.GetProperty(PropName)
        'If pInfo Is Nothing Then
        '    Dim pFunctionInfo As System.Reflection.MethodInfo = objType.GetMethod(PropName)
        'Else
        '    Return pInfo.GetValue(obj, Reflection.BindingFlags.GetProperty, Nothing, Nothing, Nothing)
        'End If
    End Function

    Private Sub pLoadData()
        Call bwLoaddata.RunWorkerAsync()
    End Sub

    Private Sub btnDatabindShowHide_Click(sender As Object, e As EventArgs) Handles btnDatabindShowHide.Click
        btnDatabindShowHide.Checked = Not btnDatabindShowHide.Checked
    End Sub

    Private Sub btnDatabindShowHide_CheckedChanged(sender As Object, e As EventArgs) Handles btnDatabindShowHide.CheckedChanged
        SplitContainer1.Panel2Collapsed = Not btnDatabindShowHide.Checked
    End Sub

    Private Function pGetSelectedForm() As cCaveRegisterForm
        Return DirectCast(lvDatas.FocusedItem.Tag, cCaveRegisterForm)
    End Function

    Private Function pGetSelectedItem() As ListViewItem
        Return lvDatas.FocusedItem
    End Function

    Private Function pIsItemSelected() As Boolean
        Return Not lvDatas.FocusedItem Is Nothing
    End Function

    Private Sub pSelectItem(Item As ListViewItem)
        If Item Is Nothing Then
            btnSave.Enabled = False
            btnDelete.Enabled = False
            btnDownload.Enabled = False
            btnUpload.Enabled = False
        Else
            btnSave.Enabled = True
            btnDelete.Enabled = True
            btnDownload.Enabled = True
            btnUpload.Enabled = True

            Dim oCaveRegister As cCaveRegisterForm = DirectCast(Item.Tag, cCaveRegisterForm)
            Call oCaveRegister.BringToFront()
        End If
    End Sub

    Private Sub lvDatas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvDatas.SelectedIndexChanged
        Call pSelectItem(lvDatas.FocusedItem)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Call pSave()
    End Sub

    Private Sub pSave()
        If pIsItemSelected() Then
            Dim oCaveRegister As cCaveRegisterForm = pGetSelectedForm()
            Call oCaveRegister.Save()
        End If
    End Sub

    Private Sub pDownload()
        If pIsItemSelected() Then
            Cursor = Cursors.WaitCursor
            Dim oCaveRegister As cCaveRegisterForm = pGetSelectedForm()
            Call oCaveRegister.[Get]()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub pUpload()
        If pIsItemSelected() Then
            Dim oCaveRegister As cCaveRegisterForm = pGetSelectedForm()
            Call oCaveRegister.[Set]()
        End If
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        Call pDownload()
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Call pUpload()
    End Sub

    Private Sub pSaveAll()
        For Each oItem As ListViewItem In lvDatas.Items
            Dim oCaveRegister As cCaveRegisterForm = DirectCast(oItem.Tag, cCaveRegisterForm)
            Call oCaveRegister.Save()
        Next
    End Sub

    Private Sub btnSaveAll_Click(sender As Object, e As EventArgs) Handles btnSaveAll.Click
        Call pSaveAll()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Call Close()
    End Sub

    Private Sub pAdd()
        Dim frmCRA As frmCaveRegisterAdd = New frmCaveRegisterAdd(oSurvey, oRegister.Settings)
        With frmCRA
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                Dim sCaveID As String = .cboID.Text
                Dim sName As String = .txtName.Text
                Dim oSetting As cCaveRegisterSetting = .cboSetting.SelectedItem
                Dim oData As cCaveRegisterData = oRegister.Datas.Add(oSetting, sCaveID, sName)
                Cursor = Cursors.Default
                If Not oData Is Nothing Then
                    Dim oItem As ListViewItem = pDataAdd(oData)
                    Call pDataSelect(oItem)
                    Call lvDatas_SelectedIndexChanged(Nothing, Nothing)
                    btnSaveAll.Enabled = lvDatas.Items.Count > 0
                End If
            End If
        End With
    End Sub

    Private Sub pAddMulti()
        Dim frmCRAM As frmCaveRegisterAddMulti = New frmCaveRegisterAddMulti(oSurvey, oRegister.Settings)
        With frmCRAM
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                Dim oItem As ListViewItem
                For Each oIDItem As ListViewItem In .lvIDs.CheckedItems
                    Dim sCaveID As String = oIDItem.Text
                    Dim sName As String = oIDItem.SubItems(1).Text
                    Dim oSetting As cCaveRegisterSetting = .cboSetting.SelectedItem
                    Dim oData As cCaveRegisterData = oRegister.Datas.Add(oSetting, sCaveID, sName)
                    If Not oData Is Nothing Then
                        oItem = pDataAdd(oData)
                    End If
                Next
                Cursor = Cursors.Default
                If Not oItem Is Nothing Then
                    Call pDataSelect(oItem)
                    Call lvDatas_SelectedIndexChanged(Nothing, Nothing)
                End If
                btnSaveAll.Enabled = lvDatas.Items.Count > 0
            End If
        End With
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

    End Sub

    Private Sub frmCaveRegisterTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub pDelete()
        If pIsItemSelected() Then
            If MsgBox("Eliminare la scheda corrente?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Attenzione:") Then
                Dim oItem As ListViewItem = pGetSelectedItem()
                Dim oForm As cCaveRegisterForm = oItem.Tag
                Dim oData As cCaveRegisterData = oRegister.Datas(oItem.Name)
                Call oRegister.Datas.Remove(oData.CaveID)
                Call oItem.Remove()
                Call SplitContainer1.Panel1.Controls.Remove(oForm)

                btnSaveAll.Enabled = lvDatas.Items.Count > 0
                Call lvDatas_SelectedIndexChanged(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Call pDelete()
    End Sub

    Private Sub mnuDatas_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuDatas.Opening
        Dim bEnabled As Boolean = pIsItemSelected()
        mnuDatasAdd.Enabled = btnAdd.Enabled
        mnuDatasDownload.Enabled = btnDownload.Enabled
        mnuDatasDelete.Enabled = bEnabled
    End Sub

    Private Sub mnuDatasDownload_Click(sender As Object, e As EventArgs) Handles mnuDatasDownload.Click
        Call pDownload()
    End Sub

    Private Sub mnuDatasAdd_Click(sender As Object, e As EventArgs) Handles mnuDatasAdd.Click
        Call pAdd()
    End Sub

    Private Sub mnuDatasDelete_Click(sender As Object, e As EventArgs) Handles mnuDatasDelete.Click
        Call pDelete()
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Dim frmCRS As frmCaveRegisterSettings = New frmCaveRegisterSettings(oSurvey, oRegister.Settings)
        If frmCRS.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub btnAdd_ButtonClick(sender As Object, e As EventArgs) Handles btnAdd.ButtonClick
        Call pAdd()
    End Sub

    Private Sub btnAddSingle_Click(sender As Object, e As EventArgs) Handles btnAddSingle.Click
        Call pAdd()
    End Sub

    Private Sub btnAddMulti_Click(sender As Object, e As EventArgs) Handles btnAddMulti.Click
        Call pAddMulti()
    End Sub

    Private Sub bwLoaddata_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwLoaddata.DoWork
        Call lvData.BeginUpdate()
        lvData.Enabled = False
        Call lvData.Items.Clear()
        Dim oXML As XmlDocument = New XmlDocument
        Call oXML.Load("cCaveRegisterData.xml")
        Dim oXMLRoot As XmlElement = oXML.Item("data")
        Call pLoadSubData(oXMLRoot, oSurvey, Nothing)
        lvData.EndUpdate()
        lvData.Enabled = True

        btnDatabindShowHide.Enabled = True
    End Sub

    Private Sub btnAdd_DropDownOpening(sender As Object, e As EventArgs) Handles btnAdd.DropDownOpening
        Dim oIDs As List(Of String) = oRegister.getcaveids
    End Sub
End Class