Imports System.ComponentModel
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraTreeList

Friend Class cItemAttachmentPropertyControl
    Private oSurvey As cSurvey.cSurvey

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() 
    End Sub

    Public Shadows ReadOnly Property Item As cItemAttachment
        Get
            Return MyBase.Item
        End Get
    End Property

    Public Shadows Sub Rebind(Item As cItemAttachment)
        MyBase.Rebind(Item)

        Call pRefreshPreview()
        txtPropAttachmentName.EditValue = Me.Item.Attachment.Attachment.Name
        txtPropAttachmentNote.EditValue = Me.Item.Attachment.Attachment.Note
    End Sub

    Private Sub pRefreshPreview()
        Dim oAttachment As cAttachment = Me.Item.Attachment.Attachment
        If oAttachment.GetCategory = FTTLib.FileCategory.Image Then
            picPropAttachmentPreview.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
            picPropAttachmentPreview.Properties.PictureAlignment = ContentAlignment.MiddleCenter
            picPropAttachmentPreview.Image = modPaint.ImageExifRotate(modPaint.ByteArrayToBitmap(oAttachment.Data))
        Else
            picPropAttachmentPreview.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Clip
            picPropAttachmentPreview.Properties.PictureAlignment = ContentAlignment.MiddleCenter
            picPropAttachmentPreview.Image = oAttachment.GetThumbnail
        End If
    End Sub

    Private Sub cmdPropAttachmentBrowse_Click(sender As Object, e As EventArgs) Handles cmdPropAttachmentBrowse.Click
        Using oOFD As OpenFileDialog = New OpenFileDialog
            oOFD.Filter = modMain.GetLocalizedString("main.filetypeALL") & " (*.*)|*.*"
            oOFD.FilterIndex = 1
            If oOFD.ShowDialog(Me) = DialogResult.OK Then
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo25"))
                Item.SetAttachment(oOFD.FileName)
                Call pRefreshPreview()
                Call MyBase.CommitUndoSnapshot()
                Call MyBase.PropertyChanged("Attachment")
                Call MyBase.MapInvalidate()
            End If
        End Using
    End Sub

    Private Sub cmdPropAttachmentOpen_Click(sender As Object, e As EventArgs) Handles cmdPropAttachmentOpen.Click
        Call MyBase.DoCommand("openattachment", Item)
    End Sub

    Private Sub txtPropAttachmentName_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropAttachmentName.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo25"), "Attachment.Attachment.Name")
            Item.Attachment.Attachment.Name = txtPropAttachmentName.EditValue
            Call MyBase.PropertyChanged("AttachmentName")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropAttachmentNote_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropAttachmentNote.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo25"), "Attachment.Attachment.Note")
            Item.Attachment.Attachment.Note = txtPropAttachmentNote.EditValue
            Call MyBase.PropertyChanged("AttachmentNote")
            Call MyBase.MapInvalidate()
        End If
    End Sub
End Class
