Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Data
Imports DevExpress.XtraTreeList

Friend Class frmDataFieldsEditor
    Private oDataFields As cDataFields

    'Private Class cDataFieldPlaceHolder
    '    Public Name As String
    '    Public Type As cDataFields.TypeEnum
    '    Public Description As String
    '    Public Category As String
    '    Public EnumValues As String

    '    Public Source As cDataField

    '    Public Created As Boolean
    '    Public Deleted As Boolean
    'End Class

    Public Sub New(DataFields As cDataFields)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oDataFields = DataFields

        tvDataFields.DataSource = New UIHelpers.cDataFieldsBindingList(oDataFields)
    End Sub

    Private Sub cboDataFieldType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDataFieldType.SelectedIndexChanged
        pnlDataFieldEnum.Visible = cboDataFieldType.SelectedIndex = 8
    End Sub

    Private Sub txtDataFieldName_Validated(sender As Object, e As EventArgs) Handles txtDataFieldName.Validated
        Try
            Dim oDataFields As UIHelpers.cDataFieldsBindingList = DirectCast(tvDataFields.DataSource, UIHelpers.cDataFieldsBindingList)
            Dim sNewName As String = oDataFields.FormatName(txtDataFieldName.Text)
            txtDataFieldName.Text = sNewName

            Dim oPH As UIHelpers.cDataFieldPlaceHolder = tvDataFields.GetFocusedObject
            oPH.Name = sNewName
            Call tvDataFields.RefreshDataSource()
        Catch
        End Try
    End Sub

    Private Sub txtDataFieldName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDataFieldName.Validating
        Dim oDataFields As UIHelpers.cDataFieldsBindingList = DirectCast(tvDataFields.DataSource, UIHelpers.cDataFieldsBindingList)
        Dim sNewName As String = oDataFields.FormatName(txtDataFieldName.Text)
        txtDataFieldName.Text = sNewName
        If sNewName = "" Then
            e.Cancel = True
        Else
            e.Cancel = DirectCast(tvDataFields.DataSource, UIHelpers.cDataFieldsBindingList).Contains(sNewName)
        End If
    End Sub

    Private Sub cboDataFieldType_Validated(sender As Object, e As EventArgs) Handles cboDataFieldType.Validated
        Try
            Dim iType As cDataFields.TypeEnum = cboDataFieldType.SelectedIndex
            Dim oPH As UIHelpers.cDataFieldPlaceHolder = tvDataFields.GetFocusedObject
            oPH.Type = iType
        Catch
        End Try
    End Sub

    Private Sub txtDataFieldDescription_Validated(sender As Object, e As EventArgs) Handles txtDataFieldDescription.Validated
        Try
            Dim sDescription As String = txtDataFieldDescription.Text
            Dim oPH As UIHelpers.cDataFieldPlaceHolder = tvDataFields.GetFocusedObject
            oPH.Description = sDescription
        Catch
        End Try
    End Sub

    Private Sub txtDataFieldEnumValues_Validated(sender As Object, e As EventArgs) Handles txtDataFieldEnumValues.Validated
        Try
            Dim sEnumValues As String = txtDataFieldEnumValues.Text
            Dim oPH As UIHelpers.cDataFieldPlaceHolder = tvDataFields.GetFocusedObject
            oPH.EnumValues = sEnumValues
        Catch
        End Try
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Cursor = Cursors.WaitCursor
        Call DirectCast(tvDataFields.DataSource, UIHelpers.cDataFieldsBindingList).Save()
        Cursor = Cursors.Default
    End Sub

    Private Sub txtDataFieldCategory_Validated(sender As Object, e As System.EventArgs) Handles txtDataFieldCategory.Validated
        Try
            Dim sCategory As String = txtDataFieldCategory.Text
            Dim oPH As UIHelpers.cDataFieldPlaceHolder = tvDataFields.GetFocusedObject
            oPH.Category = sCategory
        Catch
        End Try
    End Sub

    Private Sub btnDataFieldDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDataFieldDelete.ItemClick
        Dim oDataField As UIHelpers.cDataFieldPlaceHolder = tvDataFields.GetFocusedObject
        If Not oDataField Is Nothing Then
            If Not DirectCast(tvDataFields.DataSource, UIHelpers.cDataFieldsBindingList).Remove(oDataField) Then
                Call tvDataFields.RefreshDataSource()
            End If
            Call pRefreshData()
        End If
    End Sub

    Private Sub btnDataFieldAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDataFieldAdd.ItemClick
        Call tvDataFields.Focus()
        Dim oDataField As UIHelpers.cDataFieldPlaceHolder = DirectCast(tvDataFields.DataSource, UIHelpers.cDataFieldsBindingList).Add()
        tvDataFields.SetFocusedObject(oDataField)
        Call pRefreshData()
    End Sub

    Private Sub pRefreshData()
        Try
            Dim oPH As UIHelpers.cDataFieldPlaceHolder = tvDataFields.GetFocusedObject
            pnlDataField.Enabled = Not oPH.Deleted

            txtDataFieldName.Text = oPH.Name
            txtDataFieldDescription.Text = oPH.Description
            txtDataFieldCategory.Text = oPH.Category
            cboDataFieldType.SelectedIndex = oPH.Type
            txtDataFieldEnumValues.Text = oPH.EnumValues

            btnDataFieldAdd.Enabled = True
            btnDataFieldDelete.Enabled = Not oPH.Deleted
        Catch ex As Exception
            pnlDataField.Enabled = False

            btnDataFieldAdd.Enabled = True
            btnDataFieldDelete.Enabled = False
        End Try
    End Sub

    Private Sub tvDataFields_FocusedNodeChanged(sender As Object, e As FocusedNodeChangedEventArgs) Handles tvDataFields.FocusedNodeChanged
        Call pRefreshData
    End Sub
End Class