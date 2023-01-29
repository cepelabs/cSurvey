Imports System.ComponentModel
Imports cSurveyPC.cSurvey.UIHelpers.Import
Imports DevExpress.XtraTreeList

Friend Class frmImportGenericData

    Private Sub pSettingsLoad()
        txtPrefix.Text = My.Application.Settings.GetSetting("data.import.generic.prefix", "")
        txtCaveName.Text = My.Application.Settings.GetSetting("data.import.generic.cavename", "")

        chkFirstline.Checked = My.Application.Settings.GetSetting("data.import.generic.skipfirstline", 0)
        chkAutoSplay.Checked = My.Application.Settings.GetSetting("data.import.generic.autosplay", 0)
        cboSeparator.SelectedIndex = My.Application.Settings.GetSetting("data.import.generic.separator", 0)
        chkSplaySymbol.Checked = My.Application.Settings.GetSetting("data.import.generic.splaysymbol", 0)
        chkCutSplaySymbol.Checked = My.Application.Settings.GetSetting("data.import.generic.cutsplaysymbol", 0)
        chkZeroPlaceholders.Checked = My.Application.Settings.GetSetting("data.import.generic.zeroplaceholders", 0)
        chkCommentSymbols.Checked = My.Application.Settings.GetSetting("data.import.generic.comments", 0)

        txtSplayMarker.Text = My.Application.Settings.GetSetting("data.import.generic.splaysymboltxt", ".")
        txtCutSplayMarker.Text = My.Application.Settings.GetSetting("data.import.generic.cutsplaysymboltxt", "-")
        txtZeroPlaceholders.Text = My.Application.Settings.GetSetting("data.import.generic.zeroplaceholderstxt", "-")
        txtCommentSymbols.Text = My.Application.Settings.GetSetting("data.import.generic.commentsymbolstxt", "#%")

        Try
            Dim sFields As String = My.Application.Settings.GetSetting("data.import.generic.fields", "")
            If sFields <> "" Then
                Dim oDestFields As cDestFields = tvDestField.DataSource

                Dim sKeys() As String = sFields.Split(",")
                For Each sKey As String In sKeys
                    Dim oData(2) As Object
                    Dim sData() As String = sKey.Split("|")
                    Dim iEnum As cSourceField.TextFieldIndexEnum
                    If [Enum].TryParse(sData(0), iEnum) Then
                        Dim oSourceItem As cSourceField = pGetItem(iEnum)
                        Dim oDestItem As cDestField = oDestFields.Add(oSourceItem, Integer.Parse(sData(1)), sData(2))
                        If oSourceItem.Index <> cSourceField.TextFieldIndexEnum.Empty Then
                            Call lstSourceFields.DataSource.Remove(oSourceItem)
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
        End Try

        cmdOk.Enabled = pDestFieldValidate()
    End Sub

    Private Function pGetItem(Index As cSourceField.TextFieldIndexEnum) As cSourceField
        For Each oItem As cSourceField In lstSourceFields.DataSource
            If oItem.Index = Index Then
                Return oItem
            End If
        Next
        Return Nothing
    End Function

    Private Sub pSettingsSave()
        Call My.Application.Settings.SetSetting("data.import.generic.prefix", txtPrefix.Text)
        Call My.Application.Settings.SetSetting("data.import.generic.cavename", txtCaveName.Text)

        Call My.Application.Settings.SetSetting("data.import.generic.skipfirstline", If(chkFirstline.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.generic.autosplay", If(chkAutoSplay.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.generic.separator", cboSeparator.SelectedIndex)
        Call My.Application.Settings.SetSetting("data.import.generic.cutsplaysymbol", If(chkAutoSplay.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.generic.zeroplaceholders", If(chkZeroPlaceholders.Checked, 1, 0))
        Call My.Application.Settings.SetSetting("data.import.generic.comments", If(chkCommentSymbols.Checked, 1, 0))

        Call My.Application.Settings.SetSetting("data.import.generic.splaysymboltxt", txtSplayMarker.Text)
        Call My.Application.Settings.SetSetting("data.import.generic.cutsplaysymboltxt", txtCutSplayMarker.Text)
        Call My.Application.Settings.SetSetting("data.import.generic.zeroplaceholderstxt", txtZeroPlaceholders.Text)
        Call My.Application.Settings.SetSetting("data.import.generic.commentsymbolstxt", txtCommentSymbols.Text)

        Call My.Application.Settings.SetSetting("data.import.generic.fields", GetFields.ToString)
    End Sub

    Friend Function GetFields() As cDestFields
        Return tvDestField.DataSource
    End Function

    Public Function GetSeparator() As String()
        Select Case cboSeparator.SelectedIndex
            Case 0
                Return {" "}
            Case 1
                Return {vbTab}
            Case 2
                Return {" ", vbTab}
            Case Else
                Return {cboSeparator.Text}
        End Select
    End Function

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If lstSourceFields.DataSource.Count > 0 Then
            Dim iIndex As Integer = lstSourceFields.SelectedIndex
            Dim oSourceItem As cSourceField = lstSourceFields.SelectedItem

            Dim oDestFields As cDestFields = tvDestField.DataSource
            Dim oDestItem As cDestField = oDestFields.Add(oSourceItem, cDestField.DestinationFieldTypeEnum.SourceFieldIndex)
            Call tvDestField.SetFocusedObject(oDestItem)

            If oSourceItem.Index <> cSourceField.TextFieldIndexEnum.Empty Then
                Call lstSourceFields.DataSource.RemoveAt(iIndex)
            End If
        End If
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        Dim oDestItem As cDestField = tvDestField.GetFocusedObject
        Dim oSourceItem As cSourceField = oDestItem.Source
        If oSourceItem.Index <> cSourceField.TextFieldIndexEnum.Empty Then
            lstSourceFields.DataSource.Add(oSourceItem)
        End If

        Dim oDestFields As cDestFields = tvDestField.DataSource
        Call oDestFields.Remove(oDestItem)
    End Sub

    Private Sub btnAddAll_Click(sender As System.Object, e As System.EventArgs) Handles btnAddAll.Click
        Do While lstSourceFields.DataSource.Count > 0
            Call btnAdd.PerformClick()
        Loop
    End Sub

    Private Sub btnRemoveAll_Click(sender As System.Object, e As System.EventArgs) Handles btnRemoveAll.Click
        Dim oDestFields As cDestFields = tvDestField.DataSource
        Do While oDestFields.Count > 0
            Call btnRemove.PerformClick()
        Loop
    End Sub

    Private oSurvey As cSurvey.cSurvey

    Private WithEvents oSourceFields As cSourceFields

    Public Sub New(Survey As cSurvey.cSurvey)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey

        oSourceFields = New cSourceFields
        lstSourceFields.DataSource = oSourceFields
        lstSourceFields.DisplayMember = "Name"
        lstSourceFields.ValueMember = "Name"

        'Call lstSourceFields.Items.Add(New cSourceField(cSourceField.TextFieldIndexEnum.From, GetLocalizedString("importgenericdata.field1")))
        'Call lstSourceFields.Items.Add(New cSourceField(cSourceField.TextFieldIndexEnum.To, GetLocalizedString("importgenericdata.field2")))
        'Call lstSourceFields.Items.Add(New cSourceField(cSourceField.TextFieldIndexEnum.Distance, GetLocalizedString("importgenericdata.field3")))
        'Call lstSourceFields.Items.Add(New cSourceField(cSourceField.TextFieldIndexEnum.Direction, GetLocalizedString("importgenericdata.field4")))
        'Call lstSourceFields.Items.Add(New cSourceField(cSourceField.TextFieldIndexEnum.Inclination, GetLocalizedString("importgenericdata.field5")))
        'Call lstSourceFields.Items.Add(New cSourceField(cSourceField.TextFieldIndexEnum.Left, GetLocalizedString("importgenericdata.field6")))
        'Call lstSourceFields.Items.Add(New cSourceField(cSourceField.TextFieldIndexEnum.Right, GetLocalizedString("importgenericdata.field7")))
        'Call lstSourceFields.Items.Add(New cSourceField(cSourceField.TextFieldIndexEnum.Up, GetLocalizedString("importgenericdata.field8")))
        'Call lstSourceFields.Items.Add(New cSourceField(cSourceField.TextFieldIndexEnum.Down, GetLocalizedString("importgenericdata.field9")))
        'Call lstSourceFields.Items.Add(New cSourceField(cSourceField.TextFieldIndexEnum.Note, GetLocalizedString("importgenericdata.field10")))
        'Call lstSourceFields.Items.Add(New cSourceField(cSourceField.TextFieldIndexEnum.CustomProperty, GetLocalizedString("importgenericdata.field98")))
        'Call lstSourceFields.Items.Add(New cSourceField(cSourceField.TextFieldIndexEnum.Empty, GetLocalizedString("importgenericdata.field99")))
        lstSourceFields.SelectedIndex = 0

        Dim oData As List(Of cDestFieldComboItemType) = New List(Of cDestFieldComboItemType)
        Call oData.Add(New cDestFieldComboItemType(GetLocalizedString("importgenericdata.itemtype1"), cDestField.DestinationFieldTypeEnum.SourceFieldIndex))
        Call oData.Add(New cDestFieldComboItemType(GetLocalizedString("importgenericdata.itemtype2"), cDestField.DestinationFieldTypeEnum.FixedValue))

        cboFieldsType.DataSource = oData
        cboFieldsType.DisplayMember = "Text"
        cboFieldsType.ValueMember = "Index"

        tvDestField.DataSource = New cDestFields
        Call tvDestField_FocusedNodeChanged(tvDestField, New FocusedNodeChangedEventArgs(Nothing, Nothing))

        Call cboSession.Rebind(oSurvey, True, True)

        Call pSettingsLoad()
    End Sub

    Private Sub lstSourceFields_DoubleClick(sender As Object, e As System.EventArgs)
        Call btnAdd_Click(Nothing, Nothing)
    End Sub

    Private Sub lstDestFields_DoubleClick(sender As Object, e As System.EventArgs)
        Call btnRemove_Click(Nothing, Nothing)
    End Sub

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        Call pSettingsSave()
    End Sub

    Private Function pDestFieldValidate() As Boolean
        Dim oDestFields As cDestFields = tvDestField.DataSource
        For Each oDestField As cDestField In oDestFields
            If oDestField.IsInError Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub chkSplaySymbol_CheckedChanged(sender As Object, e As EventArgs) Handles chkSplaySymbol.CheckedChanged
        txtSplayMarker.Enabled = chkSplaySymbol.Checked
    End Sub

    Private Sub chkCutSplaySymbol_CheckedChanged(sender As Object, e As EventArgs) Handles chkCutSplaySymbol.CheckedChanged
        txtCutSplayMarker.Enabled = chkCutSplaySymbol.Checked
    End Sub

    Private Sub chkZeroPlaceholders_CheckedChanged(sender As Object, e As EventArgs) Handles chkZeroPlaceholders.CheckedChanged
        txtZeroPlaceholders.Enabled = chkZeroPlaceholders.Checked
    End Sub

    Private Sub chkCommentSymbols_CheckedChanged(sender As Object, e As EventArgs) Handles chkCommentSymbols.CheckedChanged
        txtCommentSymbols.Enabled = chkCommentSymbols.Checked
    End Sub

    Private Sub tvDestField_FocusedNodeChanged(sender As Object, e As FocusedNodeChangedEventArgs) Handles tvDestField.FocusedNodeChanged
        cmdOk.Enabled = pDestFieldValidate()
        Dim oDestFields As cDestFields = tvDestField.DataSource
        Dim oItem As cDestField = tvDestField.GetFocusedObject
        If oItem Is Nothing Then
            btnMoveDown.Enabled = False
            btnMoveUp.Enabled = False
            btnRemove.Enabled = False
            btnRemoveAll.Enabled = False
        Else
            btnRemove.Enabled = True
            btnRemoveAll.Enabled = True
            btnMoveDown.Enabled = oDestFields.IndexOf(oItem) < oDestFields.Count - 1
            btnMoveUp.Enabled = oDestFields.IndexOf(oItem) > 0
        End If
    End Sub

    Private Sub tvDestField_CustomDrawNodeCell(sender As Object, e As CustomDrawNodeCellEventArgs) Handles tvDestField.CustomDrawNodeCell
        If e.Column Is colFieldsValue Then
            Dim oDestField As cDestField = tvDestField.GetRow(e.Node.Id)
            If oDestField IsNot Nothing Then
                If oDestField.IsInError Then
                    e.EditViewInfo.ErrorIconText = oDestField.ErrorText
                    e.EditViewInfo.ShowErrorIcon = True
                    e.EditViewInfo.FillBackground = True
                    e.EditViewInfo.ErrorIcon = DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider.GetErrorIconInternal(DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)
                End If
            End If
            e.EditViewInfo.CalcViewInfo(e.Graphics)
        End If
    End Sub

    Private Sub btnMoveUp_Click(sender As Object, e As EventArgs) Handles btnMoveUp.Click
        Call tvDestField.BeginUpdate()
        Dim oDestFields As cDestFields = tvDestField.DataSource
        Dim oItem As cDestField = tvDestField.GetFocusedObject
        Call oDestFields.MoveUp(oItem)
        Call tvDestField.RefreshDataSource()
        Call tvDestField.SetFocusedObject(oItem)
        Call tvDestField.EndUpdate()
    End Sub

    Private Sub btnMoveDown_Click(sender As Object, e As EventArgs) Handles btnMoveDown.Click
        Call tvDestField.BeginUpdate()
        Dim oDestFields As cDestFields = tvDestField.DataSource
        Dim oItem As cDestField = tvDestField.GetFocusedObject
        Call oDestFields.MoveDown(oItem)
        Call tvDestField.RefreshDataSource()
        Call tvDestField.SetFocusedObject(oItem)
        Call tvDestField.EndUpdate()
    End Sub

    Private Sub lstSourceFields_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSourceFields.SelectedIndexChanged
        Dim bEnabled As Boolean = lstSourceFields.SelectedItem IsNot Nothing
        btnAdd.Enabled = bEnabled
        btnAddAll.Enabled = bEnabled
    End Sub
    Private Sub tvDestField_ShowingEditor(sender As Object, e As CancelEventArgs) Handles tvDestField.ShowingEditor
        Dim oItem As cDestField = tvDestField.GetFocusedObject
        e.Cancel = oItem.Source.Index = cSourceField.TextFieldIndexEnum.Empty
    End Sub

    Private Sub oSourceFields_OnGetName(sender As Object, e As cSourceField.cGetNameEventArgs) Handles oSourceFields.OnGetName
        Dim iIndex As cSourceField.TextFieldIndexEnum = DirectCast(sender, cSourceField).Index
        If iIndex = cSourceField.TextFieldIndexEnum.Distance OrElse iIndex = cSourceField.TextFieldIndexEnum.Direction OrElse iIndex = cSourceField.TextFieldIndexEnum.Inclination Then
            Dim oSession As cSurvey.cSession = cboSession.EditValue
            e.Name = GetLocalizedString("importgenericdata.field" & iIndex.ToString("D") & "_" & oSession.DataFormat.ToString("D"))
        Else
            e.Name = GetLocalizedString("importgenericdata.field" & iIndex.ToString("D"))
        End If
    End Sub

    Private Sub cboSession_EditValueChanged(sender As Object, e As EventArgs) Handles cboSession.EditValueChanged
        Call lstSourceFields.Refresh()
        Call tvDestField.Refresh()
    End Sub
End Class