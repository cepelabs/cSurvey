friend Class frmImportExcel

    Private Sub pSettingsLoad()
        Try
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
                txtPrefix.Text = oReg.GetValue("data.import.xlsx.prefix", "")
                txtCaveName.Text = oReg.GetValue("data.import.xlsx.cavename", "")

                chkFirstline.Checked = oReg.GetValue("data.import.xlsx.skipfirstline", 0)
                chkAutoSplay.Checked = oReg.GetValue("data.import.xlsx.autosplay", 0)
                chkSplaySymbol.Checked = oReg.GetValue("data.import.xlsx.splaysymbol", 0)
                chkCutSplaySymbol.Checked = oReg.GetValue("data.import.xlsx.cutsplaysymbol", 0)
                chkZeroPlaceholders.Checked = oReg.GetValue("data.import.xlsx.zeroplaceholders", 0)
                chkCommentSymbols.Checked = oReg.GetValue("data.import.xlsx.comments", 0)

                txtSplayMarker.Text = oReg.GetValue("data.import.xlsx.splaysymboltxt", ".")
                txtCutSplayMarker.Text = oReg.GetValue("data.import.xlsx.cutsplaysymboltxt", "-")
                txtZeroPlaceholders.Text = oReg.GetValue("data.import.xlsx.zeroplaceholderstxt", "-")
                txtCommentSymbols.Text = oReg.GetValue("data.import.xlsx.commentsymbolstxt", "#%")

                Try
                    Dim sFields As String = oReg.GetValue("data.import.xlsx.fields", "")
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
                Call oReg.SetValue("data.import.xlsx.prefix", txtPrefix.Text)
                Call oReg.SetValue("data.import.xlsx.cavename", txtCaveName.Text)

                Call oReg.SetValue("data.import.xlsx.skipfirstline", IIf(chkFirstline.Checked, 1, 0))
                Call oReg.SetValue("data.import.xlsx.autosplay", IIf(chkAutoSplay.Checked, 1, 0))
                Call oReg.SetValue("data.import.xlsx.cutsplaysymbol", IIf(chkAutoSplay.Checked, 1, 0))
                Call oReg.SetValue("data.import.xlsx.zeroplaceholders", IIf(chkZeroPlaceholders.Checked, 1, 0))
                Call oReg.SetValue("data.import.xlsx.comments", IIf(chkCommentSymbols.Checked, 1, 0))

                Call oReg.SetValue("data.import.xlsx.splaysymboltxt", txtSplayMarker.Text)
                Call oReg.SetValue("data.import.xlsx.cutsplaysymboltxt", txtCutSplayMarker.Text)
                Call oReg.SetValue("data.import.xlsx.zeroplaceholderstxt", txtZeroPlaceholders.Text)
                Call oReg.SetValue("data.import.xlsx.commentsymbolstxt", txtCommentSymbols.Text)

                Call oReg.SetValue("data.import.xlsx.fields", GetFields.ToString)

                Call oReg.Close()
            End Using
        Catch
        End Try
    End Sub

    Friend Function GetFields() As frmImportGenericData.cDestFields
        Dim oItems As frmImportGenericData.cDestFields = New frmImportGenericData.cDestFields
        For Each oRow As DataGridViewRow In grdDestField.Rows
            Dim oSourceField As cSourceField = DirectCast(oRow.Cells(0).Value, cSourceField)
            Dim iIndex As TextFieldIndexEnum = oSourceField.Index
            Dim sName As String = oSourceField.Name
            Dim iType As Integer = oRow.Cells(1).Value
            Dim sValue As String = oRow.Cells(2).Value
            Dim oDestField As frmImportGenericData.cDestField = New frmImportGenericData.cDestField(iIndex, sName, iType, sValue)
            Call oItems.Add(oDestField)
        Next
        Return oItems
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
                Dim iNewIndex As Integer = pGetMaxIndex() + 1
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
                Return sText
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

    Private Sub cboSeparator_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class