<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLochDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLochDialog))
        Me.lblElevationData = New System.Windows.Forms.Label()
        Me.lblOrthophoto = New System.Windows.Forms.Label()
        Me.chkDoNotShow = New DevExpress.XtraEditors.CheckEdit()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.linkedSurveys = New cSurveyPC.cLinkedSurveySelectorControl()
        Me.cmdOkOrSave = New DevExpress.XtraEditors.DropDownButton()
        Me.mnuOkOrSave = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.cmdMenuOk = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdMenuSave = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.cboOrthophoto = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.iml = New DevExpress.Utils.ImageCollection(Me.components)
        Me.cboElevationData = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.chkDoNotShow.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout
        CType(Me.mnuOkOrSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout
        Me.XtraTabPage1.SuspendLayout
        CType(Me.cboOrthophoto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboElevationData.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout
        Me.SuspendLayout
        '
        'lblElevationData
        '
        resources.ApplyResources(Me.lblElevationData, "lblElevationData")
        Me.lblElevationData.Name = "lblElevationData"
        '
        'lblOrthophoto
        '
        resources.ApplyResources(Me.lblOrthophoto, "lblOrthophoto")
        Me.lblOrthophoto.Name = "lblOrthophoto"
        '
        'chkDoNotShow
        '
        resources.ApplyResources(Me.chkDoNotShow, "chkDoNotShow")
        Me.chkDoNotShow.Name = "chkDoNotShow"
        Me.chkDoNotShow.Properties.AutoWidth = True
        Me.chkDoNotShow.Properties.Caption = resources.GetString("chkDoNotShow.Properties.Caption")
        '
        'lblDescription
        '
        resources.ApplyResources(Me.lblDescription, "lblDescription")
        Me.lblDescription.Name = "lblDescription"
        '
        'TabControl1
        '
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'TabPage1
        '
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'linkedSurveys
        '
        resources.ApplyResources(Me.linkedSurveys, "linkedSurveys")
        Me.linkedSurveys.Name = "linkedSurveys"
        '
        'cmdOkOrSave
        '
        resources.ApplyResources(Me.cmdOkOrSave, "cmdOkOrSave")
        Me.cmdOkOrSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOkOrSave.DropDownControl = Me.mnuOkOrSave
        Me.cmdOkOrSave.Name = "cmdOkOrSave"
        '
        'mnuOkOrSave
        '
        Me.mnuOkOrSave.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.cmdMenuOk), New DevExpress.XtraBars.LinkPersistInfo(Me.cmdMenuSave)})
        Me.mnuOkOrSave.Manager = Me.BarManager
        Me.mnuOkOrSave.Name = "mnuOkOrSave"
        '
        'cmdMenuOk
        '
        resources.ApplyResources(Me.cmdMenuOk, "cmdMenuOk")
        Me.cmdMenuOk.Id = 0
        Me.cmdMenuOk.Name = "cmdMenuOk"
        '
        'cmdMenuSave
        '
        resources.ApplyResources(Me.cmdMenuSave, "cmdMenuSave")
        Me.cmdMenuSave.Id = 1
        Me.cmdMenuSave.Name = "cmdMenuSave"
        '
        'BarManager
        '
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.cmdMenuOk, Me.cmdMenuSave})
        Me.BarManager.MaxItemId = 2
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
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'XtraTabControl1
        '
        resources.ApplyResources(Me.XtraTabControl1, "XtraTabControl1")
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.cboOrthophoto)
        Me.XtraTabPage1.Controls.Add(Me.cboElevationData)
        Me.XtraTabPage1.Controls.Add(Me.lblElevationData)
        Me.XtraTabPage1.Controls.Add(Me.lblOrthophoto)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        resources.ApplyResources(Me.XtraTabPage1, "XtraTabPage1")
        '
        'cboOrthophoto
        '
        resources.ApplyResources(Me.cboOrthophoto, "cboOrthophoto")
        Me.cboOrthophoto.MenuManager = Me.BarManager
        Me.cboOrthophoto.Name = "cboOrthophoto"
        Me.cboOrthophoto.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboOrthophoto.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboOrthophoto.Properties.LargeImages = Me.iml
        Me.cboOrthophoto.Properties.SmallImages = Me.iml
        '
        'iml
        '
        resources.ApplyResources(Me.iml, "iml")
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        '
        'cboElevationData
        '
        resources.ApplyResources(Me.cboElevationData, "cboElevationData")
        Me.cboElevationData.MenuManager = Me.BarManager
        Me.cboElevationData.Name = "cboElevationData"
        Me.cboElevationData.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboElevationData.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboElevationData.Properties.LargeImages = Me.iml
        Me.cboElevationData.Properties.SmallImages = Me.iml
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.linkedSurveys)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        resources.ApplyResources(Me.XtraTabPage2, "XtraTabPage2")
        '
        'frmLochDialog
        '
        Me.AcceptButton = Me.cmdOkOrSave
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.cmdOkOrSave)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.chkDoNotShow)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.Image = Global.cSurveyPC.My.Resources.Resources.loch_LOCHICON
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLochDialog"
        Me.SaveAndRestoreSettings = True
        Me.ShowInTaskbar = False
        CType(Me.chkDoNotShow.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        CType(Me.mnuOkOrSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage1.PerformLayout
        CType(Me.cboOrthophoto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboElevationData.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout

    End Sub
    Friend WithEvents lblElevationData As System.Windows.Forms.Label
    Friend WithEvents lblOrthophoto As System.Windows.Forms.Label
    Friend WithEvents chkDoNotShow As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents linkedSurveys As cLinkedSurveySelectorControl
    Friend WithEvents cmdOkOrSave As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents mnuOkOrSave As DevExpress.XtraBars.PopupMenu
    Friend WithEvents cmdMenuOk As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdMenuSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents cboElevationData As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents iml As DevExpress.Utils.ImageCollection
    Friend WithEvents cboOrthophoto As DevExpress.XtraEditors.ImageComboBoxEdit
End Class
