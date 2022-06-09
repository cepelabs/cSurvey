Imports BrightIdeasSoftware
Imports cSurveyPC.cSurvey
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Base

Friend Class frmTemplates

    Private oTemplates As UIHelpers.cTemplatesBindingList

    Public Sub New(Templates As UIHelpers.cTemplatesBindingList, Optional SaveAs As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oTemplates = Templates

        grdTemplates.DataSource = oTemplates

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
    Private Function pDropExtensionCheck(Filename As String) As Boolean
        Select Case IO.Path.GetExtension(Filename).ToLower
            Case ".csz", ".csx"
                Return True
        End Select
    End Function

    Private Sub lvTemplates_DragOver(sender As Object, e As DragEventArgs)
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

    Private Sub grdViewTemplates_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles grdViewTemplates.PopupMenuShowing
        If e.HitInfo.InRowCell OrElse e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.EmptyRow Then
            e.Allow = False
            Call mnuTemplates.ShowPopup(grdTemplates.PointToScreen(e.Point))
        End If
    End Sub
    Private Sub grdViewTemplates_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles grdViewTemplates.FocusedRowChanged
        Dim oTemplate As UIHelpers.cTemplateEntry = grdViewTemplates.GetFocusedObject
        If oTemplate Is Nothing Then
            txtName.Text = ""
            btnTemplateDelete.Enabled = False
            btnTemplateSetAsDefault.Enabled = False
        Else
            txtName.Text = oTemplate.Name
            btnTemplateDelete.Enabled = True
            btnTemplateSetAsDefault.Enabled = True
            btnTemplateSetAsDefault.Checked = oTemplate.Default
        End If
    End Sub

    Private Sub chkTemplatesDefault_EditValueChanged(sender As Object, e As EventArgs) Handles chkTemplatesDefault.EditValueChanged
        Call grdViewTemplates.PostEditor()
        Call grdViewTemplates.RefreshData()
    End Sub

    Private Sub btnTemplateSetAsDefault_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnTemplateSetAsDefault.ItemClick
        Dim oTemplate As UIHelpers.cTemplateEntry = grdViewTemplates.GetFocusedObject
        If oTemplate IsNot Nothing Then
            oTemplate.Default = btnTemplateSetAsDefault.Checked
            Call grdViewTemplates.RefreshData()
        End If
    End Sub

    Private Sub btnTemplateDelete_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnTemplateDelete.ItemClick
        If MsgBox(modMain.GetLocalizedString("templates.warning1"), MsgBoxStyle.YesNo Or MsgBoxStyle.Critical, modMain.GetLocalizedString("templates.warningtitle")) = MsgBoxResult.Yes Then
            Dim oTemplate As UIHelpers.cTemplateEntry = grdViewTemplates.GetFocusedObject
            Call My.Computer.FileSystem.DeleteFile(oTemplate.File.FullName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
            Call oTemplates.Remove(oTemplate)
        End If
    End Sub

    Private Sub grdTemplates_DragDrop(sender As Object, e As DragEventArgs) Handles grdTemplates.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim sFilePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            For Each sFilepath As String In sFilePaths
                Dim sDestFilePath As String = IO.Path.Combine(oTemplates.TemplatePath, IO.Path.GetFileName(sFilepath))
                If Not My.Computer.FileSystem.FileExists(sDestFilePath) Then
                    Call My.Computer.FileSystem.CopyFile(sFilepath, sDestFilePath, True)
                    Call oTemplates.Refresh()
                    'Dim oNewTemplate As cTemplateEntry = New cTemplateEntry(New IO.FileInfo(sDestFilePath))
                    'Call oTemplates.Add(oNewTemplate)
                End If
            Next
        End If
    End Sub

    Private Sub grdTemplates_DragOver(sender As Object, e As DragEventArgs) Handles grdTemplates.DragOver
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
End Class