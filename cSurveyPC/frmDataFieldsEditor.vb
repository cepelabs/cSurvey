Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Data

Public Class frmDataFieldsEditor
    Private oDataFields As cDataFields

    Private Class cDataFieldPlaceHolder
        Public Name As String
        Public Type As cDataFields.TypeEnum
        Public Description As String
        Public Category As String
        Public EnumValues As String

        Public Source As cDataField

        Public Created As Boolean
        Public Deleted As Boolean
    End Class

    Public Sub New(DataFields As cDataFields)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oDataFields = DataFields

        For Each oDataField As cDataField In oDataFields
            Dim oPH As cDataFieldPlaceHolder = New cDataFieldPlaceHolder
            With oPH
                .Name = oDataField.Name
                .Type = oDataField.Type
                .Description = oDataField.Description
                .Category = oDataField.Category
                Select Case .Type
                    Case cDataFields.TypeEnum.Enum
                        Dim oEnumDataField As cEnumDataField = oDataField
                        For Each sValue As String In oEnumDataField.Values.Values
                            If .EnumValues <> "" Then .EnumValues = .EnumValues & vbCrLf
                            .EnumValues = .EnumValues & sValue
                        Next
                End Select
                .Source = oDataField
            End With

            Dim oNode As TreeNode = tvDataFields.Nodes.Add(oPH.Name, oPH.Name)
            oNode.Tag = oPH
            oNode.SelectedImageKey = "datafield"
            oNode.ImageKey = "datafield"
        Next
    End Sub

    Private Sub cboDataFieldType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDataFieldType.SelectedIndexChanged
        pnlDataFieldEnum.Visible = cboDataFieldType.SelectedIndex = 8
    End Sub

    Private Function pGetFieldUniqueName() As String
        Dim sBaseName As String = "field"
        Dim iIndex As Integer = 0
        Dim sName As String
        Do
            iIndex += 1
            sName = sBaseName & iIndex
        Loop While tvDataFields.Nodes.ContainsKey(sName)
        Return sName
    End Function

    Private Sub btnDataFieldAdd_Click(sender As Object, e As EventArgs) Handles btnDataFieldAdd.Click
        Call tvDataFields.Focus()

        Dim sName As String = pGetFieldUniqueName()
        Dim oPH As cDataFieldPlaceHolder = New cDataFieldPlaceHolder
        With oPH
            .Name = sName
            .Type = cDataFields.TypeEnum.Text
            .Description = ""

            .Created = True
            .Source = Nothing
        End With

        Dim oNode As TreeNode = tvDataFields.Nodes.Add(sName, sName)
        oNode.Text = oPH.Name
        oNode.Tag = oPH
        oNode.SelectedImageKey = "datafield"
        oNode.ImageKey = "datafield"

        tvDataFields.SelectedNode = oNode
        Call oNode.EnsureVisible()
    End Sub

    Private Sub txtDataFieldName_TextChanged(sender As Object, e As EventArgs) Handles txtDataFieldName.TextChanged

    End Sub

    Private Function pFormatDataFieldName(Name As String) As String
        Dim sName As String = Name.Trim
        sName = sName.Replace(" ", "_")
        Dim sNewName As String = ""
        For Each sChar As Char In sName
            If (sChar >= "A" And sChar <= "Z") Or (sChar >= "a" And sChar <= "z") Or (sChar >= "0" And sChar <= "9") Or (sChar = "_") Then
                sNewName = sNewName & sChar
            End If
        Next
        Return sNewName
    End Function

    Private Sub txtDataFieldName_Validated(sender As Object, e As EventArgs) Handles txtDataFieldName.Validated
        Try
            Dim sName As String = txtDataFieldName.Text.Trim
            sName = pFormatDataFieldName(sName)
            txtDataFieldName.Text = sName
            Dim oPH As cDataFieldPlaceHolder = tvDataFields.SelectedNode.Tag
            oPH.Name = sName
            With tvDataFields.SelectedNode
                .Name = oPH.Name
                .Text = oPH.Name
            End With
        Catch
        End Try
    End Sub

    Private Sub txtDataFieldName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDataFieldName.Validating
        Dim sNewName As String = txtDataFieldName.Text.Trim
        sNewName = pFormatDataFieldName(sNewName)
        txtDataFieldName.Text = sNewName
        If sNewName = "" Then
            e.Cancel = True
        Else
            Dim oNode As TreeNode = tvDataFields.SelectedNode
            If oNode.Text <> sNewName Then
                e.Cancel = tvDataFields.Nodes.ContainsKey(sNewName)
            End If
        End If
    End Sub

    Private Sub tvDataFields_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvDataFields.AfterSelect
        Try
            Dim oPH As cDataFieldPlaceHolder = e.Node.Tag
            pnlDataField.Enabled = Not oPH.Deleted

            txtDataFieldName.Text = oPH.Name
            txtDataFieldDescription.Text = oPH.Description
            txtDataFieldCategory.Text = oPH.Category
            cboDataFieldType.SelectedIndex = oPH.Type
            txtDataFieldEnumValues.Text = oPH.EnumValues

            btnDataFieldAdd.Enabled = True
            btnDataFieldDelete.Enabled = tvDataFields.Nodes.Count > 0
        Catch
            pnlDataField.Enabled = False

            btnDataFieldAdd.Enabled = True
            btnDataFieldDelete.Enabled = tvDataFields.Nodes.Count > 0
        End Try
    End Sub

    Private Sub cboDataFieldType_Validated(sender As Object, e As EventArgs) Handles cboDataFieldType.Validated
        Try
            Dim iType As cDataFields.TypeEnum = cboDataFieldType.SelectedIndex
            Dim oPH As cDataFieldPlaceHolder = tvDataFields.SelectedNode.Tag
            oPH.Type = iType
        Catch
        End Try
    End Sub

    Private Sub txtDataFieldDescription_Validated(sender As Object, e As EventArgs) Handles txtDataFieldDescription.Validated
        Try
            Dim sDescription As String = txtDataFieldDescription.Text
            Dim oPH As cDataFieldPlaceHolder = tvDataFields.SelectedNode.Tag
            oPH.Description = sDescription
        Catch
        End Try
    End Sub

    Private Sub txtDataFieldEnumValues_Validated(sender As Object, e As EventArgs) Handles txtDataFieldEnumValues.Validated
        Try
            Dim sEnumValues As String = txtDataFieldEnumValues.Text
            Dim oPH As cDataFieldPlaceHolder = tvDataFields.SelectedNode.Tag
            oPH.EnumValues = sEnumValues
        Catch
        End Try
    End Sub

    Private Sub btnDataFieldDelete_Click(sender As Object, e As EventArgs) Handles btnDataFieldDelete.Click
        Try
            Dim oNode As TreeNode = tvDataFields.SelectedNode
            If Not oNode Is Nothing Then
                Dim oPH As cDataFieldPlaceHolder = oNode.Tag

                If oDataFields.Contains(oPH.Source) Then
                    oNode.ForeColor = SystemColors.InactiveCaptionText
                    oNode.SelectedImageKey = "deleted"
                    oNode.ImageKey = "deleted"
                    oPH.Deleted = True

                    tvDataFields.SelectedNode = Nothing
                    tvDataFields.SelectedNode = oNode
                Else
                    Call tvDataFields.Nodes.Remove(oNode)
                End If

                If tvDataFields.Nodes.Count = 0 Then
                    Call tvDataFields_AfterSelect(Nothing, Nothing)
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Cursor = Cursors.WaitCursor
        For Each oNode As TreeNode In tvDataFields.Nodes
            Dim oPH As cDataFieldPlaceHolder = oNode.Tag
            If oPH.Deleted Then
                If oDataFields.Contains(oPH.Source) Then
                    oDataFields.Remove(oPH.Source)
                End If
            Else
                If oPH.Created Then
                    Dim oDataField As cDataField = oDataFields.Add(oPH.Name, oPH.Type)
                    oDataField.Description = oPH.Description
                    oDataField.Category = oPH.Category
                    Select Case oPH.Type
                        Case cDataFields.TypeEnum.Enum
                            Dim oEnumDataField As cEnumDataField = oDataField
                            Dim sLines() As String = Strings.Split(oPH.EnumValues, vbCrLf)
                            Dim iIndex As Integer = 0
                            For Each sLine As String In sLines
                                Call oEnumDataField.Values.Add(iIndex, sLine)
                                iIndex += 1
                            Next
                    End Select
                Else
                    Dim oDataField As cDataField = oPH.Source
                    If oDataField.Name <> oPH.Name Then
                        oDataField = oDataFields.Rename(oDataField.Name, oPH.Name)
                    End If
                    If oDataField.Type <> oPH.Type Then
                        oDataField = oDataFields.Retype(oDataField.Name, oPH.Type)
                    End If
                    oDataField.Description = oPH.Description
                    oDataField.Category = oPH.Category
                    Select Case oPH.Type
                        Case cDataFields.TypeEnum.Enum
                            Dim oEnumDataField As cEnumDataField = oDataField
                            Dim sLines() As String = Strings.Split(oPH.EnumValues, vbCrLf)
                            Dim iIndex As Integer = 0
                            Call oEnumDataField.Values.Clear()
                            For Each sLine As String In sLines
                                Call oEnumDataField.Values.Add(iIndex, sLine)
                                iIndex += 1
                            Next
                    End Select
                End If
            End If
        Next
        Call oDataFields.InvalidateClass()
        Cursor = Cursors.Default
    End Sub

    Private Sub txtDataFieldCategory_Validated(sender As Object, e As System.EventArgs) Handles txtDataFieldCategory.Validated
        Try
            Dim sCategory As String = txtDataFieldCategory.Text
            Dim oPH As cDataFieldPlaceHolder = tvDataFields.SelectedNode.Tag
            oPH.Category = sCategory
        Catch
        End Try
    End Sub

End Class