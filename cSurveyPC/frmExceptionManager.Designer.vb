<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExceptionManager
    Inherits cForm

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExceptionManager))
        Me.rtfException = New System.Windows.Forms.RichTextBox()
        Me.mnuError = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuExceptionSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExceptionCopyText = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExceptionCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExceptionSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdSaveAs = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdSaveAsAndExit = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdSaveException = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdSendException = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdClose = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdShowDetails = New DevExpress.XtraEditors.SimpleButton()
        Me.lblException = New System.Windows.Forms.Label()
        Me.tmrAskToSendException = New System.Windows.Forms.Timer(Me.components)
        Me.cmdCopyException = New DevExpress.XtraEditors.SimpleButton()
        Me.mnuError.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtfException
        '
        resources.ApplyResources(Me.rtfException, "rtfException")
        Me.rtfException.ContextMenuStrip = Me.mnuError
        Me.rtfException.DetectUrls = False
        Me.rtfException.HideSelection = False
        Me.rtfException.Name = "rtfException"
        Me.rtfException.ReadOnly = True
        Me.rtfException.ShortcutsEnabled = False
        '
        'mnuError
        '
        resources.ApplyResources(Me.mnuError, "mnuError")
        Me.mnuError.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExceptionSelectAll, Me.mnuExceptionCopyText, Me.ToolStripMenuItem1, Me.mnuExceptionCopy, Me.mnuExceptionSave})
        Me.mnuError.Name = "mnuError"
        '
        'mnuExceptionSelectAll
        '
        Me.mnuExceptionSelectAll.Name = "mnuExceptionSelectAll"
        resources.ApplyResources(Me.mnuExceptionSelectAll, "mnuExceptionSelectAll")
        '
        'mnuExceptionCopyText
        '
        Me.mnuExceptionCopyText.Image = Global.cSurveyPC.My.Resources.Resources.page_copy
        Me.mnuExceptionCopyText.Name = "mnuExceptionCopyText"
        resources.ApplyResources(Me.mnuExceptionCopyText, "mnuExceptionCopyText")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuExceptionCopy
        '
        Me.mnuExceptionCopy.Image = Global.cSurveyPC.My.Resources.Resources.page_copy
        Me.mnuExceptionCopy.Name = "mnuExceptionCopy"
        resources.ApplyResources(Me.mnuExceptionCopy, "mnuExceptionCopy")
        '
        'mnuExceptionSave
        '
        Me.mnuExceptionSave.Image = Global.cSurveyPC.My.Resources.Resources.script_save
        Me.mnuExceptionSave.Name = "mnuExceptionSave"
        resources.ApplyResources(Me.mnuExceptionSave, "mnuExceptionSave")
        '
        'cmdSaveAs
        '
        resources.ApplyResources(Me.cmdSaveAs, "cmdSaveAs")
        Me.cmdSaveAs.Appearance.Options.UseTextOptions = True
        Me.cmdSaveAs.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.cmdSaveAs.ImageOptions.Image = Global.cSurveyPC.My.Resources.Resources.save_as
        Me.cmdSaveAs.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.cmdSaveAs.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.saveas
        Me.cmdSaveAs.Name = "cmdSaveAs"
        '
        'cmdSaveAsAndExit
        '
        resources.ApplyResources(Me.cmdSaveAsAndExit, "cmdSaveAsAndExit")
        Me.cmdSaveAsAndExit.Appearance.Options.UseTextOptions = True
        Me.cmdSaveAsAndExit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.cmdSaveAsAndExit.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.cmdSaveAsAndExit.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.saveas
        Me.cmdSaveAsAndExit.Name = "cmdSaveAsAndExit"
        '
        'cmdExit
        '
        resources.ApplyResources(Me.cmdExit, "cmdExit")
        Me.cmdExit.Appearance.Options.UseTextOptions = True
        Me.cmdExit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.cmdExit.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.cmdExit.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.close
        Me.cmdExit.Name = "cmdExit"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'cmdSaveException
        '
        resources.ApplyResources(Me.cmdSaveException, "cmdSaveException")
        Me.cmdSaveException.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.save
        Me.cmdSaveException.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdSaveException.Name = "cmdSaveException"
        '
        'cmdSendException
        '
        resources.ApplyResources(Me.cmdSendException, "cmdSendException")
        Me.cmdSendException.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.email
        Me.cmdSendException.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdSendException.Name = "cmdSendException"
        '
        'cmdClose
        '
        resources.ApplyResources(Me.cmdClose, "cmdClose")
        Me.cmdClose.Appearance.Options.UseTextOptions = True
        Me.cmdClose.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.cmdClose.ImageOptions.SvgImage = CType(resources.GetObject("cmdClose.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.cmdClose.Name = "cmdClose"
        '
        'cmdShowDetails
        '
        resources.ApplyResources(Me.cmdShowDetails, "cmdShowDetails")
        Me.cmdShowDetails.Name = "cmdShowDetails"
        '
        'lblException
        '
        resources.ApplyResources(Me.lblException, "lblException")
        Me.lblException.ContextMenuStrip = Me.mnuError
        Me.lblException.Name = "lblException"
        '
        'tmrAskToSendException
        '
        '
        'cmdCopyException
        '
        resources.ApplyResources(Me.cmdCopyException, "cmdCopyException")
        Me.cmdCopyException.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.copy
        Me.cmdCopyException.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdCopyException.Name = "cmdCopyException"
        '
        'frmExceptionManager
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdClose
        Me.Controls.Add(Me.cmdCopyException)
        Me.Controls.Add(Me.lblException)
        Me.Controls.Add(Me.cmdShowDetails)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdSendException)
        Me.Controls.Add(Me.cmdSaveException)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdSaveAsAndExit)
        Me.Controls.Add(Me.cmdSaveAs)
        Me.Controls.Add(Me.rtfException)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.security_bug
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExceptionManager"
        Me.mnuError.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rtfException As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdSaveAs As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSaveAsAndExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdSaveException As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSendException As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdShowDetails As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblException As System.Windows.Forms.Label
    Friend WithEvents tmrAskToSendException As System.Windows.Forms.Timer
    Friend WithEvents cmdCopyException As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents mnuError As ContextMenuStrip
    Friend WithEvents mnuExceptionCopy As ToolStripMenuItem
    Friend WithEvents mnuExceptionSave As ToolStripMenuItem
    Friend WithEvents mnuExceptionSelectAll As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents mnuExceptionCopyText As ToolStripMenuItem
End Class
