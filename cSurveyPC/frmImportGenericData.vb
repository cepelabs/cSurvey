friend Class frmImportGenericData

    Private Sub pSettingsLoad()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
                txtPrefix.Text = oReg.GetValue("data.import.generic.prefix", "")
                txtCaveName.Text = oReg.GetValue("data.import.generic.cavename", "")

                chkFirstline.Checked = oReg.GetValue("data.import.generic.skipfirstline", 0)
                chkAutoSplay.Checked = oReg.GetValue("data.import.generic.autosplay", 0)
                cboSeparator.SelectedIndex = oReg.GetValue("data.import.generic.separator", 0)
                chkSplaySymbol.Checked = oReg.GetValue("data.import.generic.splaysymbol", 0)
                chkCutSplaySymbol.Checked = oReg.GetValue("data.import.generic.cutsplaysymbol", 0)
                chkZeroPlaceholders.Checked = oReg.GetValue("data.import.generic.zeroplaceholders", 0)
                chkCommentSymbols.Checked = oReg.GetValue("data.import.generic.comments", 0)

                txtSplayMarker.Text = oReg.GetValue("data.import.generic.splaysymboltxt", ".")
                txtCutSplayMarker.Text = oReg.GetValue("data.import.generic.cutsplaysymboltxt", "-")
                txtZeroPlaceholders.Text = oReg.GetValue("data.import.generic.zeroplaceholderstxt", "-")
                txtCommentSymbols.Text = oReg.GetValue("data.import.generic.commentsymbolstxt", "#%")

                Try
                    Dim sFields As String = oReg.GetValue("data.import.generic.fields", "")
                    If sFields <> "" Then
                        Dim sKeys() As String = sFields.Split(",")
                        For Each sKey As String In sKeys
                            Dim oData(2) As Object
                            Dim sData() As String = sKey.Split("|")
                            Dim iEnum As TextFieldIndexEnum
                            If [Enum].TryParse(sData(0), iEnum) Then
                                Dim oItem As cSourceField = pGetItem(iEnum)
                                oData(0) = oItem
                                oData(1) = Integer.Parse(sData(1))
                                oData(2) = sData(2)

                                Call grdDestField.Rows.Add(oData)
                                Call lstSourceFields.Items.Remove(oItem)
                            End If
                        Next
                    End If
                Catch
                End Try

                Call oReg.Close()
            End Using
        Catch
        End Try

        cmdOk.Enabled = pDestFieldValidate(True)
    End Sub

    Private Function pGetItem(Index As TextFieldIndexEnum) As cSourceField
        For Each oItem As cSourceField In lstSourceFields.Items
            If oItem.Index = Index Then
                Return oItem
            End If
        Next
        Return Nothing
    End Function

    Private Sub pSettingsSave()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
                Call oReg.SetValue("data.import.generic.prefix", txtPrefix.Text)
                Call oReg.SetValue("data.import.generic.cavename", txtCaveName.Text)

                Call oReg.SetValue("data.import.generic.skipfirstline", IIf(chkFirstline.Checked, 1, 0))
                Call oReg.SetValue("data.import.generic.autosplay", IIf(chkAutoSplay.Checked, 1, 0))
                Call oReg.SetValue("data.import.generic.separator", cboSeparator.SelectedIndex)
                Call oReg.SetValue("data.import.generic.cutsplaysymbol", IIf(chkAutoSplay.Checked, 1, 0))
                Call oReg.SetValue("data.import.generic.zeroplaceholders", IIf(chkZeroPlaceholders.Checked, 1, 0))
                Call oReg.SetValue("data.import.generic.comments", IIf(chkCommentSymbols.Checked, 1, 0))

                Call oReg.SetValue("data.import.generic.splaysymboltxt", txtSplayMarker.Text)
                Call oReg.SetValue("data.import.generic.cutsplaysymboltxt", txtCutSplayMarker.Text)
                Call oReg.SetValue("data.import.generic.zeroplaceholderstxt", txtZeroPlaceholders.Text)
                Call oReg.SetValue("data.import.generic.commentsymbolstxt", txtCommentSymbols.Text)

                Call oReg.SetValue("data.import.generic.fields", GetFields.ToString)

                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Public Class cDestFields
        Private oItems As Dictionary(Of TextFieldIndexEnum, cDestField)

        Public Function GetValue(Index As TextFieldIndexEnum, Sheet As OfficeOpenXml.ExcelWorksheet, Row As Integer, DefaultValue As Object) As Object
            If oItems.ContainsKey(Index) Then
                Dim oItem As cDestField = oItems(Index)
                If oItem.Type = 0 Then
                    Dim iIndex As Integer
                    If Integer.TryParse(oItem.Value, iIndex) Then
                        Try
                            Dim oValue As Object = Sheet.Cells(Row, iIndex + 1).Value
                            If IsNothing(oValue) Then
                                Return DefaultValue
                            Else
                                Return oValue
                            End If
                        Catch
                            Return DefaultValue
                        End Try
                    Else
                        Return DefaultValue
                    End If
                Else
                    Return oItem.Value
                End If
            Else
                Return DefaultValue
            End If
        End Function

        Public Function GetValue(Index As TextFieldIndexEnum, LineParts() As String, DefaultValue As String) As String
            If oItems.ContainsKey(Index) Then
                Dim oItem As cDestField = oItems(Index)
                If oItem.Type = 0 Then
                    Dim iIndex As Integer
                    If Integer.TryParse(oItem.Value, iIndex) Then
                        If iIndex < LineParts.Count Then
                            Return LineParts(iIndex)
                        Else
                            Return DefaultValue
                        End If
                    Else
                        Return DefaultValue
                    End If
                Else
                    Return oItem.Value
                End If
            Else
                Return DefaultValue
            End If
        End Function

        Public Sub New()
            oItems = New Dictionary(Of TextFieldIndexEnum, cDestField)
        End Sub

        Default Public ReadOnly Property Item(Index As TextFieldIndexEnum) As cDestField
            Get
                Return oItems(Index)
            End Get
        End Property

        Friend Sub Add(Value As cDestField)
            Call oItems.Add(Value.Index, Value)
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Overrides Function ToString() As String
            Dim sText As String = ""
            For Each oItem As cDestField In oItems.Values
                If sText <> "" Then sText = sText & ","
                sText = sText & oItem.Index & "|" & oItem.Type & "|" & oItem.Value
            Next
            Return sText
        End Function
    End Class

    Friend Function GetFields() As cDestFields
        Dim oItems As cDestFields = New cDestFields
        For Each oRow As DataGridViewRow In grdDestField.Rows
            Dim oSourceField As cSourceField = DirectCast(oRow.Cells(0).Value, cSourceField)
            Dim iIndex As TextFieldIndexEnum = oSourceField.Index
            Dim sName As String = oSourceField.Name
            Dim iType As Integer = oRow.Cells(1).Value
            Dim sValue As String = oRow.Cells(2).Value
            Dim oDestField As cDestField = New cDestField(iIndex, sName, iType, svalue)
            Call oItems.Add(oDestField)
        Next
        Return oItems
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

    Private Function pGetMaxIndex() As Integer
        Dim iMaxIndex As Integer = -1
        For Each oRow As DataGridViewRow In grdDestField.Rows
            Dim oCell As DataGridViewComboBoxCell = oRow.Cells(1)
            If oCell.Value = 0 Then
                Dim iIndex As Integer = oRow.Cells(2).Value
                If iIndex > iMaxIndex Then iMaxIndex = iIndex
            End If
        Next
        Return iMaxIndex
    End Function

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Try
            If lstSourceFields.Items.Count > 0 Then
                Dim iIndex As Integer = lstSourceFields.SelectedIndex
                Dim oItem As cSourceField = lstSourceFields.SelectedItem
                Dim iNewIndex As Integer = pGetMaxIndex + 1
                Dim oData(2) As Object
                oData(0) = oItem
                oData(1) = 0
                oData(2) = iNewIndex
                Dim iNewRowIndex As Integer = grdDestField.Rows.Add(oData)
                grdDestField.CurrentCell = grdDestField.Rows(iNewRowIndex).Cells(0)

                Call lstSourceFields.Items.RemoveAt(iIndex)
                If iIndex > lstSourceFields.Items.Count - 1 Then
                    lstSourceFields.SelectedIndex = iIndex - 1
                Else
                    lstSourceFields.SelectedIndex = iIndex
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        Try
            Dim oRow As DataGridViewRow = grdDestField.CurrentRow
            Dim iCurrentRowIndex As Integer = oRow.Index
            Dim oItem As cSourceField = DirectCast(oRow.Cells(0).Value, cSourceField)
            Dim iIndex As TextFieldIndexEnum = oItem.Index
            Call lstSourceFields.Items.Add(oItem)
            Call grdDestField.Rows.Remove(oRow)
            If iCurrentRowIndex < grdDestField.Rows.Count Then
                grdDestField.CurrentCell = grdDestField.Rows(iCurrentRowIndex).Cells(0)
            Else
                grdDestField.CurrentCell = grdDestField.Rows(grdDestField.Rows.Count - 1).Cells(0)
            End If
        Catch
        End Try
    End Sub

    Private Sub btnAddAll_Click(sender As System.Object, e As System.EventArgs) Handles btnAddAll.Click
        Do While lstSourceFields.Items.Count > 0
            Call btnAdd.PerformClick()
        Loop
    End Sub

    Private Sub btnRemoveAll_Click(sender As System.Object, e As System.EventArgs) Handles btnRemoveAll.Click
        Do While grdDestField.Rows.Count > 0
            Call btnRemove.PerformClick()
        Loop
    End Sub

    'Private Sub btnMoveUp_Click(sender As System.Object, e As System.EventArgs) Handles btnMoveUp.Click
    '    Try
    '        Dim iIndex As Integer = lstDestFields.SelectedIndex
    '        If iIndex > 0 Then
    '            Dim oItem As Object = lstDestFields.SelectedItem
    '            Call lstDestFields.Items.RemoveAt(iIndex)
    '            Call lstDestFields.Items.Insert(iIndex - 1, oItem)
    '            lstDestFields.SelectedIndex = iIndex - 1
    '        End If
    '    Catch
    '    End Try
    'End Sub

    'Private Sub btnMoveDown_Click(sender As System.Object, e As System.EventArgs) Handles btnMoveDown.Click
    '    Try
    '        Dim iIndex As Integer = lstDestFields.SelectedIndex
    '        If iIndex < lstDestFields.Items.Count - 1 Then
    '            Dim oItem As Object = lstDestFields.SelectedItem
    '            Call lstDestFields.Items.RemoveAt(iIndex)
    '            Call lstDestFields.Items.Insert(iIndex + 1, oItem)
    '            lstDestFields.SelectedIndex = iIndex + 1
    '        End If
    '    Catch
    '    End Try
    'End Sub

    Public Enum TextFieldIndexEnum
        [From] = 0
        [To] = 1
        [Distance] = 2
        Direction = 3
        Inclination = 4
        Left = 5
        Right = 6
        Up = 7
        Down = 8
        Note = 9
    End Enum

    Public Class cSourceField
        Public Name As String
        Public Index As TextFieldIndexEnum

        Public Overrides Function ToString() As String
            Return Name
        End Function

        Public Sub New(Index As TextFieldIndexEnum, Name As String)
            Me.Index = Index
            Me.Name = Name
        End Sub
    End Class

    Public Class cDestField
        Public Index As TextFieldIndexEnum
        Public Name As String
        Public Type As Integer
        Public Value As String

        Public Overrides Function ToString() As String
            Return Name
        End Function

        Public Sub New(Index As TextFieldIndexEnum, Name As String, Type As Integer, Value As String)
            Me.Index = Index
            Me.Name = Name
            Me.Type = Type
            Me.Value = Value
        End Sub
    End Class

    Private Class cDestFieldComboItemType
        Private sText As String
        Private iIndex As Integer

        Public ReadOnly Property Text As String
            Get
                Return stext
            End Get
        End Property

        Public ReadOnly Property Index As Integer
            Get
                Return iIndex
            End Get
        End Property

        Public Sub New(Text As String, Index As Integer)
            sText = Text
            iIndex = Index
        End Sub

        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Call lstSourceFields.Items.Add(New cSourceField(TextFieldIndexEnum.From, GetLocalizedString("importgenericdata.field1")))
        Call lstSourceFields.Items.Add(New cSourceField(TextFieldIndexEnum.To, GetLocalizedString("importgenericdata.field2")))
        Call lstSourceFields.Items.Add(New cSourceField(TextFieldIndexEnum.Distance, GetLocalizedString("importgenericdata.field3")))
        Call lstSourceFields.Items.Add(New cSourceField(TextFieldIndexEnum.Direction, GetLocalizedString("importgenericdata.field4")))
        Call lstSourceFields.Items.Add(New cSourceField(TextFieldIndexEnum.Inclination, GetLocalizedString("importgenericdata.field5")))
        Call lstSourceFields.Items.Add(New cSourceField(TextFieldIndexEnum.Left, GetLocalizedString("importgenericdata.field6")))
        Call lstSourceFields.Items.Add(New cSourceField(TextFieldIndexEnum.Right, GetLocalizedString("importgenericdata.field7")))
        Call lstSourceFields.Items.Add(New cSourceField(TextFieldIndexEnum.Up, GetLocalizedString("importgenericdata.field8")))
        Call lstSourceFields.Items.Add(New cSourceField(TextFieldIndexEnum.Down, GetLocalizedString("importgenericdata.field9")))
        Call lstSourceFields.Items.Add(New cSourceField(TextFieldIndexEnum.Note, GetLocalizedString("importgenericdata.field10")))
        lstSourceFields.SelectedIndex = 0

        Dim oFieldTypeColumn As DataGridViewComboBoxColumn = grdDestField.Columns(1)
        Dim oData As List(Of cDestFieldComboItemType) = New List(Of cDestFieldComboItemType)
        oFieldTypeColumn.DataSource = oData
        Call oData.Add(New cDestFieldComboItemType(GetLocalizedString("importgenericdata.itemtype1"), 0))
        Call oData.Add(New cDestFieldComboItemType(GetLocalizedString("importgenericdata.itemtype2"), 1))
        oFieldTypeColumn.DisplayMember = "Text"
        oFieldTypeColumn.ValueMember = "Index"

        Call pSettingsLoad()
    End Sub

    Private Sub lstSourceFields_DoubleClick(sender As Object, e As System.EventArgs) Handles lstSourceFields.DoubleClick
        Call btnAdd_Click(Nothing, Nothing)
    End Sub

    Private Sub lstDestFields_DoubleClick(sender As Object, e As System.EventArgs)
        Call btnRemove_Click(Nothing, Nothing)
    End Sub

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        Call pSettingsSave()
    End Sub

    Private Sub lstDestFields_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Function pDestFieldValidate(Row As Integer, Column As Integer) As Boolean
        Select Case Column
            Case 1, 2
                With grdDestField.Rows(Row)
                    Dim iValueType As Integer = .Cells(1).Value
                    Dim sValue As String = .Cells(2).Value
                    If iValueType = 0 Then
                        Dim iField As Integer
                        If Integer.TryParse(sValue, iField) Then
                            If iField < 0 Then
                                grdDestField.Rows(Row).Cells(2).ErrorText = GetLocalizedString("importgenericdata.warning1")
                            Else
                                grdDestField.Rows(Row).Cells(2).ErrorText = ""
                            End If
                        Else
                            grdDestField.Rows(Row).Cells(2).ErrorText = GetLocalizedString("importgenericdata.warning1")
                        End If
                    Else
                        grdDestField.Rows(Row).Cells(2).ErrorText = ""
                    End If
                End With
        End Select
    End Function

    Private Function pDestFieldValidate(Optional Force As Boolean = False) As Boolean
        Dim bCancel As Boolean
        If Force Then
            For Each oRow As DataGridViewRow In grdDestField.Rows
                Dim iRow As Integer = oRow.Index
                Dim iColumn As Integer = 2
                Call pDestFieldValidate(iRow, iColumn)
            Next
        End If
        For Each oRow As DataGridViewRow In grdDestField.Rows
            Dim sErrorText As String = oRow.Cells(2).ErrorText
            If sErrorText <> "" Then
                bCancel = True
                Exit For
            End If
        Next
        Return Not bCancel
    End Function

    Private Sub grdDestField_SelectionChanged(sender As Object, e As EventArgs) Handles grdDestField.SelectionChanged
        cmdOk.Enabled = pDestFieldValidate(True)
    End Sub

    Private Sub frmImportGenericData_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkSplaySymbol.CheckedChanged

    End Sub

    Private Sub txtCaveName_TextChanged(sender As Object, e As EventArgs) Handles txtCaveName.TextChanged

    End Sub

    Private Sub cboSeparator_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSeparator.SelectedIndexChanged

    End Sub
End Class