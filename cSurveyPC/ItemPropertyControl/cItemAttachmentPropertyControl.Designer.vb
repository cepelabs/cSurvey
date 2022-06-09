<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemAttachmentPropertyControl
    Inherits cItemPropertyControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemAttachmentPropertyControl))
        Me.cmdPropAttachmentBrowse = New DevExpress.XtraEditors.SimpleButton()
        Me.txtPropAttachmentName = New DevExpress.XtraEditors.TextEdit()
        Me.lblPropAttachmentName = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropAttachmentNote = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropAttachmentNote = New DevExpress.XtraEditors.MemoEdit()
        Me.cmdPropAttachmentOpen = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPropAttachment = New DevExpress.XtraEditors.LabelControl()
        Me.picPropAttachmentPreview = New DevExpress.XtraEditors.PictureEdit()
        CType(Me.txtPropAttachmentName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropAttachmentNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPropAttachmentPreview.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdPropAttachmentBrowse
        '
        Me.cmdPropAttachmentBrowse.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropAttachmentBrowse.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.open
        Me.cmdPropAttachmentBrowse.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdPropAttachmentBrowse, "cmdPropAttachmentBrowse")
        Me.cmdPropAttachmentBrowse.Name = "cmdPropAttachmentBrowse"
        '
        'txtPropAttachmentName
        '
        resources.ApplyResources(Me.txtPropAttachmentName, "txtPropAttachmentName")
        Me.txtPropAttachmentName.Name = "txtPropAttachmentName"
        '
        'lblPropAttachmentName
        '
        resources.ApplyResources(Me.lblPropAttachmentName, "lblPropAttachmentName")
        Me.lblPropAttachmentName.Name = "lblPropAttachmentName"
        '
        'lblPropAttachmentNote
        '
        resources.ApplyResources(Me.lblPropAttachmentNote, "lblPropAttachmentNote")
        Me.lblPropAttachmentNote.Name = "lblPropAttachmentNote"
        '
        'txtPropAttachmentNote
        '
        resources.ApplyResources(Me.txtPropAttachmentNote, "txtPropAttachmentNote")
        Me.txtPropAttachmentNote.Name = "txtPropAttachmentNote"
        '
        'cmdPropAttachmentOpen
        '
        Me.cmdPropAttachmentOpen.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropAttachmentOpen.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.open2
        Me.cmdPropAttachmentOpen.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdPropAttachmentOpen, "cmdPropAttachmentOpen")
        Me.cmdPropAttachmentOpen.Name = "cmdPropAttachmentOpen"
        '
        'lblPropAttachment
        '
        resources.ApplyResources(Me.lblPropAttachment, "lblPropAttachment")
        Me.lblPropAttachment.Name = "lblPropAttachment"
        '
        'picPropAttachmentPreview
        '
        resources.ApplyResources(Me.picPropAttachmentPreview, "picPropAttachmentPreview")
        Me.picPropAttachmentPreview.Name = "picPropAttachmentPreview"
        Me.picPropAttachmentPreview.Properties.ReadOnly = True
        Me.picPropAttachmentPreview.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.[False]
        Me.picPropAttachmentPreview.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        '
        'cItemAttachmentPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cmdPropAttachmentBrowse)
        Me.Controls.Add(Me.txtPropAttachmentName)
        Me.Controls.Add(Me.lblPropAttachmentName)
        Me.Controls.Add(Me.lblPropAttachmentNote)
        Me.Controls.Add(Me.txtPropAttachmentNote)
        Me.Controls.Add(Me.cmdPropAttachmentOpen)
        Me.Controls.Add(Me.lblPropAttachment)
        Me.Controls.Add(Me.picPropAttachmentPreview)
        Me.Name = "cItemAttachmentPropertyControl"
        CType(Me.txtPropAttachmentName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropAttachmentNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPropAttachmentPreview.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboPropCaveBranchListView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPropCaveBranchListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtPropCaveBranchListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents cboPropCaveListView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPropCaveListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtPropCaveListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents cmdPropAttachmentBrowse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtPropAttachmentName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPropAttachmentName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropAttachmentNote As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropAttachmentNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents cmdPropAttachmentOpen As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPropAttachment As DevExpress.XtraEditors.LabelControl
    Friend WithEvents picPropAttachmentPreview As DevExpress.XtraEditors.PictureEdit
End Class
