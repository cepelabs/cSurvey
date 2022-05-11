<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cDockImageViewer
    Inherits DevExpress.XtraEditors.XtraUserControl

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                Call pDispose()
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImageViewer))
        Me.picImage = New System.Windows.Forms.PictureBox()
        Me.pnlContainer = New System.Windows.Forms.Panel()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barMain = New DevExpress.XtraBars.Bar()
        Me.btnExport = New DevExpress.XtraBars.BarButtonItem()
        Me.btnZoomOriginalSize = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSizeToFit = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRotateLeft = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRotateRight = New DevExpress.XtraBars.BarButtonItem()
        Me.btnFlipH = New DevExpress.XtraBars.BarButtonItem()
        Me.btnFlipV = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlContainer.SuspendLayout()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picImage
        '
        resources.ApplyResources(Me.picImage, "picImage")
        Me.picImage.Name = "picImage"
        Me.picImage.TabStop = False
        '
        'pnlContainer
        '
        resources.ApplyResources(Me.pnlContainer, "pnlContainer")
        Me.pnlContainer.Controls.Add(Me.picImage)
        Me.pnlContainer.Name = "pnlContainer"
        '
        'BarManager
        '
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.barMain})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnExport, Me.btnZoomOriginalSize, Me.btnSizeToFit, Me.btnRotateLeft, Me.btnRotateRight, Me.btnFlipH, Me.btnFlipV})
        Me.BarManager.MaxItemId = 22
        '
        'barMain
        '
        Me.barMain.BarName = "Tools"
        Me.barMain.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Me.barMain.DockCol = 0
        Me.barMain.DockRow = 0
        Me.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.barMain.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnExport), New DevExpress.XtraBars.LinkPersistInfo(Me.btnZoomOriginalSize, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnSizeToFit), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRotateLeft, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRotateRight), New DevExpress.XtraBars.LinkPersistInfo(Me.btnFlipH, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnFlipV)})
        Me.barMain.OptionsBar.AllowQuickCustomization = False
        Me.barMain.OptionsBar.DisableCustomization = True
        Me.barMain.OptionsBar.DrawDragBorder = False
        Me.barMain.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.barMain, "barMain")
        '
        'btnExport
        '
        resources.ApplyResources(Me.btnExport, "btnExport")
        Me.btnExport.Id = 15
        Me.btnExport.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.saveas
        Me.btnExport.Name = "btnExport"
        '
        'btnZoomOriginalSize
        '
        resources.ApplyResources(Me.btnZoomOriginalSize, "btnZoomOriginalSize")
        Me.btnZoomOriginalSize.Id = 16
        Me.btnZoomOriginalSize.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.zoom
        Me.btnZoomOriginalSize.Name = "btnZoomOriginalSize"
        '
        'btnSizeToFit
        '
        resources.ApplyResources(Me.btnSizeToFit, "btnSizeToFit")
        Me.btnSizeToFit.Id = 17
        Me.btnSizeToFit.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.marqueezoom
        Me.btnSizeToFit.Name = "btnSizeToFit"
        '
        'btnRotateLeft
        '
        resources.ApplyResources(Me.btnRotateLeft, "btnRotateLeft")
        Me.btnRotateLeft.Id = 18
        Me.btnRotateLeft.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.rotate_left90
        Me.btnRotateLeft.Name = "btnRotateLeft"
        '
        'btnRotateRight
        '
        resources.ApplyResources(Me.btnRotateRight, "btnRotateRight")
        Me.btnRotateRight.Id = 19
        Me.btnRotateRight.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.rotate_right90
        Me.btnRotateRight.Name = "btnRotateRight"
        '
        'btnFlipH
        '
        resources.ApplyResources(Me.btnFlipH, "btnFlipH")
        Me.btnFlipH.Id = 20
        Me.btnFlipH.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.flipimage_horizontal
        Me.btnFlipH.Name = "btnFlipH"
        '
        'btnFlipV
        '
        resources.ApplyResources(Me.btnFlipV, "btnFlipV")
        Me.btnFlipV.Id = 21
        Me.btnFlipV.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.flipimage_vertical
        Me.btnFlipV.Name = "btnFlipV"
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
        'frmImageViewer
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pnlContainer)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmImageViewer"
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlContainer.ResumeLayout(False)
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picImage As System.Windows.Forms.PictureBox
    Friend WithEvents pnlContainer As Panel
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barMain As DevExpress.XtraBars.Bar
    Friend WithEvents btnExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnZoomOriginalSize As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnSizeToFit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRotateLeft As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRotateRight As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnFlipH As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnFlipV As DevExpress.XtraBars.BarButtonItem
End Class
