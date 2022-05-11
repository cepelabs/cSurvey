Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Data
Imports cSurveyPC.cSurvey.CaveRegister

Friend Class frmCaveRegisterSettings
    Private oSurvey As cSurvey.cSurvey
    Private oSettings As cCaveRegisterSettings

    Private Class cSettingPlaceHolder
        Public ID As String
        Public Name As String
        Public URL As String
        Public Username As String
        Public Password As String

        Public Source As cCaveRegisterSetting

        Public Created As Boolean
        Public Deleted As Boolean
    End Class

    Public Sub New(Survey As cSurvey.cSurvey, Settings As cCaveRegisterSettings)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey
        oSettings = Settings

        For Each oSetting As cCaveRegisterSetting In oSettings
            Dim oPH As cSettingPlaceHolder = New cSettingPlaceHolder
            oPH.ID = oSetting.ID
            oPH.Name = oSetting.Name
            oPH.URL = oSetting.URL
            oPH.Username = oSetting.Username
            oPH.Password = oSetting.Password
            oPH.Source = oSetting

            Dim oNode As TreeNode = tvSettings.Nodes.Add(oPH.ID, oPH.Name)
            oNode.Tag = oPH
            oNode.SelectedImageKey = "setting"
            oNode.ImageKey = "setting"
        Next
    End Sub

    Private Sub btnServiceAdd_Click(sender As Object, e As EventArgs) Handles btnServiceAdd.Click
        Call tvSettings.Focus()

        Dim oPH As cSettingPlaceHolder = New cSettingPlaceHolder
        With oPH
            .ID = Guid.NewGuid.ToString
            .Name = "Nuovo servizio " & tvSettings.Nodes.Count + 1
            .URL = ""
            .Username = ""
            .Password = ""

            .Created = True
            .Source = Nothing
        End With

        Dim oNode As TreeNode = tvSettings.Nodes.Add(oPH.ID, oPH.Name)
        oNode.Text = oPH.Name
        oNode.Tag = oPH
        oNode.SelectedImageKey = "datafield"
        oNode.ImageKey = "datafield"

        tvSettings.SelectedNode = oNode
        Call oNode.EnsureVisible()
    End Sub

    Private Sub tvSettings_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvSettings.AfterSelect
        Try
            Dim oPH As cSettingPlaceHolder = e.Node.Tag
            pnlDataField.Enabled = Not oPH.Deleted

            txtID.Text = oPH.ID
            txtName.Text = oPH.Name
            e.Node.Text = oPH.Name
            txtURL.Text = oPH.URL
            txtUsername.Text = oPH.Username
            txtPassword.Text = oPH.Password

            btnServiceAdd.Enabled = True
            If tvSettings.Nodes.Count > 0 Then
                If oPH.Created Then
                    btnServiceDelete.Enabled = True
                Else
                    btnServiceDelete.Enabled = Not oPH.Source.IsInUse
                End If
            Else
                btnServiceDelete.Enabled = False
            End If
        Catch
            pnlDataField.Enabled = False

            btnServiceAdd.Enabled = True
            btnServiceDelete.Enabled = tvSettings.Nodes.Count > 0
        End Try
    End Sub

    Private Sub btnServiceDelete_Click(sender As Object, e As EventArgs) Handles btnServiceDelete.Click
        Try
            Dim oNode As TreeNode = tvSettings.SelectedNode
            If Not oNode Is Nothing Then
                Dim oPH As cSettingPlaceHolder = oNode.Tag

                If oSettings.Contains(oPH.Source) Then
                    oNode.ForeColor = SystemColors.InactiveCaptionText
                    oNode.SelectedImageKey = "deleted"
                    oNode.ImageKey = "deleted"
                    oPH.Deleted = True

                    tvSettings.SelectedNode = Nothing
                    tvSettings.SelectedNode = oNode
                Else
                    Call tvSettings.Nodes.Remove(oNode)
                End If

                If tvSettings.Nodes.Count = 0 Then
                    Call tvSettings_AfterSelect(Nothing, Nothing)
                End If
            End If
        Catch
        End Try
    End Sub

    Private Function pValidate() As Boolean
        For Each oNode As TreeNode In tvSettings.Nodes
            Dim oPH As cSettingPlaceHolder = oNode.Tag
            If oPH.Name = "" Or oPH.URL = "" Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        If pValidate() Then
            Cursor = Cursors.WaitCursor
            For Each oNode As TreeNode In tvSettings.Nodes
                Dim oPH As cSettingPlaceHolder = oNode.Tag
                If oPH.Deleted Then
                    If oSettings.Contains(oPH.Source) Then
                        oSettings.Remove(oPH.Source)
                    End If
                Else
                    If oPH.Created Then
                        Dim oSetting As cCaveRegisterSetting = New cCaveRegisterSetting(oSurvey, txtName.Text, txtURL.Text, txtUsername.Text, txtPassword.Text)
                        Call oSettings.Append(oSetting)
                    Else
                        Dim oSetting As cCaveRegisterSetting = oPH.Source
                        oSetting.Name = txtName.Text
                        oSetting.URL = txtURL.Text
                        oSetting.Username = txtUsername.Text
                        oSetting.Password = txtPassword.Text
                    End If
                End If
            Next
            Cursor = Cursors.Default
        Else
            Call MsgBox("Ci sono dei servizi che non presentano un nome o un URL valido.", vbOKOnly Or MsgBoxStyle.Critical, "Attenzione:")
        End If
    End Sub
End Class