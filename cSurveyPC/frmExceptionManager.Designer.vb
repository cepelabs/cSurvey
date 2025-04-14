<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExceptionManager
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.cmdSaveAs = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdSaveAsAndExit = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdSaveException = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdSendException = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdClose = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdShowDetails = New DevExpress.XtraEditors.SimpleButton()
        Me.lblException = New DevExpress.XtraEditors.LabelControl()
        Me.tmrAskToSendException = New System.Windows.Forms.Timer(Me.components)
        Me.cmdCopyException = New DevExpress.XtraEditors.SimpleButton()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnSaveException = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCopyException = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSelectAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCopy = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuError = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.txtException = New DevExpress.XtraRichEdit.RichEditControl()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.lblException.AllowHtmlString = True
        resources.ApplyResources(Me.lblException, "lblException")
        Me.lblException.Appearance.Font = CType(resources.GetObject("lblException.Appearance.Font"), System.Drawing.Font)
        Me.lblException.Appearance.Options.UseFont = True
        Me.lblException.Appearance.Options.UseTextOptions = True
        Me.lblException.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
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
        'BarManager
        '
        Me.BarManager.AllowCustomization = False
        Me.BarManager.AllowQuickCustomization = False
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnSaveException, Me.btnCopyException, Me.btnSelectAll, Me.btnCopy})
        Me.BarManager.MaxItemId = 8
        Me.BarManager.ShowCloseButton = True
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        resources.ApplyResources(Me.barDockControlTop, "barDockControlTop")
        Me.barDockControlTop.Manager = Me.BarManager
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        resources.ApplyResources(Me.barDockControlBottom, "barDockControlBottom")
        Me.barDockControlBottom.Manager = Me.BarManager
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        resources.ApplyResources(Me.barDockControlLeft, "barDockControlLeft")
        Me.barDockControlLeft.Manager = Me.BarManager
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        resources.ApplyResources(Me.barDockControlRight, "barDockControlRight")
        Me.barDockControlRight.Manager = Me.BarManager
        '
        'btnSaveException
        '
        resources.ApplyResources(Me.btnSaveException, "btnSaveException")
        Me.btnSaveException.Id = 3
        Me.btnSaveException.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.save
        Me.btnSaveException.Name = "btnSaveException"
        '
        'btnCopyException
        '
        resources.ApplyResources(Me.btnCopyException, "btnCopyException")
        Me.btnCopyException.Id = 5
        Me.btnCopyException.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.copy
        Me.btnCopyException.Name = "btnCopyException"
        '
        'btnSelectAll
        '
        resources.ApplyResources(Me.btnSelectAll, "btnSelectAll")
        Me.btnSelectAll.Id = 6
        Me.btnSelectAll.Name = "btnSelectAll"
        '
        'btnCopy
        '
        resources.ApplyResources(Me.btnCopy, "btnCopy")
        Me.btnCopy.Id = 7
        Me.btnCopy.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.copy
        Me.btnCopy.Name = "btnCopy"
        '
        'mnuError
        '
        Me.mnuError.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnSelectAll), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopy), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopyException, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnSaveException)})
        Me.mnuError.Manager = Me.BarManager
        Me.mnuError.Name = "mnuError"
        '
        'txtException
        '
        Me.txtException.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple
        resources.ApplyResources(Me.txtException, "txtException")
        Me.txtException.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel
        Me.txtException.MenuManager = Me.BarManager
        Me.txtException.Name = "txtException"
        Me.txtException.ReadOnly = True
        Me.txtException.Views.SimpleView.AdjustColorsToSkins = True
        Me.txtException.Views.SimpleView.WordWrap = False
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
        Me.Controls.Add(Me.txtException)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.security_bug
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExceptionManager"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSaveAs As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSaveAsAndExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdSaveException As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSendException As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdShowDetails As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblException As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tmrAskToSendException As System.Windows.Forms.Timer
    Friend WithEvents cmdCopyException As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents btnSaveException As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnCopyException As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuError As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnSelectAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopy As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents txtException As DevExpress.XtraRichEdit.RichEditControl
End Class
