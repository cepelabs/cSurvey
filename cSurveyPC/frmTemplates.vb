Imports BrightIdeasSoftware

Friend Class frmTemplates

    Private sTemplatePath As String
    Private oTemplates As List(Of frmMain.cTemplateEntry)

    Public Sub New(TemplatePath As String, Templates As List(Of frmMain.cTemplateEntry), Optional SaveAs As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        sTemplatePath = TemplatePath
        oTemplates = Templates

        colName.AspectGetter = Function(Value As Object)
                                   Return DirectCast(Value, frmMain.cTemplateEntry).Name
                               End Function
        colDefault.AspectGetter = Function(Value As Object)
                                      Return DirectCast(Value, frmMain.cTemplateEntry).Default
                                  End Function
        colDefault.AspectPutter = Function(rowObject As Object, newValue As Object)
                                      Call pSetDefault(DirectCast(rowObject, frmMain.cTemplateEntry), newValue)
                                  End Function


        Call lvTemplates.BeginUpdate()
        lvTemplates.VirtualMode = False
        Call lvTemplates.SetObjects(oTemplates)
        Call lvTemplates.BuildList(True)
        Call lvTemplates.EndUpdate()

        If SaveAs Then
            Text = modMain.GetLocalizedString("templates.title1")
            pnlName.Visible = True
            cmdOk.Visible = True
            cmdCancel.Visible = True
            cmdClose.Visible = False
        Else
            Text = modMain.GetLocalizedString("templates.title2")
            pnlName.Visible = False
            cmdOk.Visible = False
            cmdCancel.Visible = False
            cmdClose.Visible = True
        End If
    End Sub

    Private Sub pSetDefault(Template As frmMain.cTemplateEntry, Value As Boolean)
        If Value Then
            Dim oTemplate As frmMain.cTemplateEntry = oTemplates.FirstOrDefault(Function(oitem) oitem.Default AndAlso Not oitem Is Template)
            If Not oTemplate Is Nothing Then Call pSetDefault(oTemplate, False)

            Dim sOldFilename As String = Template.File.FullName
            Dim sNewFilename As String = IO.Path.GetFileNameWithoutExtension(Template.File.Name) & ".default" & IO.Path.GetExtension(Template.File.Name)
            Dim sNewFullFilename As String = IO.Path.Combine(Template.File.DirectoryName, sNewFilename)
            My.Computer.FileSystem.RenameFile(sOldFilename, sNewFilename)
            Dim oNewTemplate As frmMain.cTemplateEntry = New frmMain.cTemplateEntry(New IO.FileInfo(sNewFullFilename))
            Dim iIndex As Integer = oTemplates.IndexOf(Template)
            Call oTemplates.Remove(Template)
            Call oTemplates.Insert(iIndex, oNewTemplate)
        Else
            Dim sOldFilename As String = Template.File.FullName
            Dim sNewFilename As String = IO.Path.GetFileNameWithoutExtension(Template.File.Name).Replace(".default", "") & IO.Path.GetExtension(Template.File.Name)
            Dim sNewFullFilename As String = IO.Path.Combine(Template.File.DirectoryName, sNewFilename)
            My.Computer.FileSystem.RenameFile(sOldFilename, sNewFilename)
            Dim oNewTemplate As frmMain.cTemplateEntry = New frmMain.cTemplateEntry(New IO.FileInfo(sNewFullFilename))
            Dim iIndex As Integer = oTemplates.IndexOf(Template)
            Call oTemplates.Remove(Template)
            Call oTemplates.Insert(iIndex, oNewTemplate)
        End If

        Call lvTemplates.BeginUpdate()
        Call lvTemplates.BuildList(True)
        Call lvTemplates.EndUpdate()
    End Sub

    Private Sub lvTemplates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvTemplates.SelectedIndexChanged
        If lvTemplates.SelectedObject Is Nothing Then
            txtName.Text = ""
        Else
            txtName.Text = DirectCast(lvTemplates.SelectedObject, frmMain.cTemplateEntry).Name
        End If
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Dim sName As String = IO.Path.GetFileNameWithoutExtension(txtName.Text.ToLower)
        If sName = "" Then
            DialogResult = DialogResult.None
        Else
            If oTemplates.Where(Function(oitem) oitem.Name.ToLower = sName).Count > 0 Then
                If MsgBox(modMain.GetLocalizedString("templates.warning2"), MsgBoxStyle.YesNo Or MsgBoxStyle.Critical, modMain.GetLocalizedString("templates.warningtitle")) = MsgBoxResult.Yes Then
                    DialogResult = DialogResult.OK
                    Call Close()
                Else
                    DialogResult = DialogResult.None
                End If
            Else
                DialogResult = DialogResult.OK
                Call Close()
            End If
        End If
    End Sub

    Private Sub mnuTemplates_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuTemplates.Opening
        Dim bEnabled As Boolean = Not lvTemplates.SelectedObject Is Nothing
        mnuTemplatesDelete.Enabled = bEnabled
        mnuTemplatesSetAsDefault.Enabled = bEnabled
    End Sub

    Private Sub mnuTemplatesDelete_Click(sender As Object, e As EventArgs) Handles mnuTemplatesDelete.Click
        If MsgBox(modMain.GetLocalizedString("templates.warning1"), MsgBoxStyle.YesNo Or MsgBoxStyle.Critical, modMain.GetLocalizedString("templates.warningtitle")) = MsgBoxResult.Yes Then
            Dim oTemplate As frmMain.cTemplateEntry = lvTemplates.SelectedObject
            Call My.Computer.FileSystem.DeleteFile(oTemplate.File.FullName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
            Call oTemplates.Remove(oTemplate)
            Call lvTemplates.BuildList(True)
        End If
    End Sub

    Private Sub mnuTemplatesSetAsDefault_Click(sender As Object, e As EventArgs) Handles mnuTemplatesSetAsDefault.Click
        'copy selected template as default.cs*
        Dim oTemplate As frmMain.cTemplateEntry = lvTemplates.SelectedObject
        If Not oTemplate.Default Then Call pSetDefault(oTemplate, True)
    End Sub

    Private Function pDropExtensionCheck(Filename As String) As Boolean
        Select Case IO.Path.GetExtension(Filename).ToLower
            Case ".csz", ".csx"
                Return True
        End Select
    End Function

    Private Sub lvTemplates_DragOver(sender As Object, e As DragEventArgs) Handles lvTemplates.DragOver
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim sFilePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            Dim bOk As Boolean = True
            For Each sFilepath As String In sFilePaths
                If Not pDropExtensionCheck(sFilepath) AndAlso My.Computer.FileSystem.FileExists(sFilepath) Then
                    bOk = False
                    Exit For
                End If
            Next
            If bOk Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If
        End If
    End Sub

    Private Sub lvTemplates_DragDrop(sender As Object, e As DragEventArgs) Handles lvTemplates.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim sFilePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            For Each sFilepath As String In sFilePaths
                Dim sDestFilePath As String = IO.Path.Combine(sTemplatePath, IO.Path.GetFileName(sFilepath))
                If Not My.Computer.FileSystem.FileExists(sDestFilePath) Then
                    Call My.Computer.FileSystem.CopyFile(sFilepath, sDestFilePath, True)
                    Dim oNewTemplate As frmMain.cTemplateEntry = New frmMain.cTemplateEntry(New IO.FileInfo(sDestFilePath))
                    Call oTemplates.Add(oNewTemplate)
                End If
            Next

            Call lvTemplates.BeginUpdate()
            Call lvTemplates.BuildList(True)
            Call lvTemplates.EndUpdate()
        End If
    End Sub
End Class