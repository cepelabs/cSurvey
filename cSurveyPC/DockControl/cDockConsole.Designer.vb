<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cDockConsole
    Inherits DevExpress.XtraEditors.XtraUserControl

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDockConsole))
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barConsole = New DevExpress.XtraBars.Bar()
        Me.btnExport = New DevExpress.XtraBars.BarButtonItem()
        Me.btnClear = New DevExpress.XtraBars.BarButtonItem()
        Me.btnOpenFileLog = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnCopy = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuConsole = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colLogDateTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLogText = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtLogText = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuConsole, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLogText, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager
        '
        Me.BarManager.AllowCustomization = False
        Me.BarManager.AllowQuickCustomization = False
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.barConsole})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnExport, Me.btnClear, Me.btnCopy, Me.btnOpenFileLog})
        Me.BarManager.MaxItemId = 7
        Me.BarManager.ShowCloseButton = True
        '
        'barConsole
        '
        Me.barConsole.BarName = "Console"
        Me.barConsole.DockCol = 0
        Me.barConsole.DockRow = 0
        Me.barConsole.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.barConsole.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnExport, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnClear, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnOpenFileLog, True)})
        Me.barConsole.OptionsBar.AllowQuickCustomization = False
        Me.barConsole.OptionsBar.DisableClose = True
        Me.barConsole.OptionsBar.DisableCustomization = True
        Me.barConsole.OptionsBar.DrawDragBorder = False
        Me.barConsole.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.barConsole, "barConsole")
        '
        'btnExport
        '
        resources.ApplyResources(Me.btnExport, "btnExport")
        Me.btnExport.Id = 3
        Me.btnExport.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.exportfile
        Me.btnExport.Name = "btnExport"
        '
        'btnClear
        '
        resources.ApplyResources(Me.btnClear, "btnClear")
        Me.btnClear.Id = 4
        Me.btnClear.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.clearall
        Me.btnClear.Name = "btnClear"
        '
        'btnOpenFileLog
        '
        resources.ApplyResources(Me.btnOpenFileLog, "btnOpenFileLog")
        Me.btnOpenFileLog.Id = 6
        Me.btnOpenFileLog.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.open2
        Me.btnOpenFileLog.Name = "btnOpenFileLog"
        Me.btnOpenFileLog.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
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
        'btnCopy
        '
        resources.ApplyResources(Me.btnCopy, "btnCopy")
        Me.btnCopy.Id = 5
        Me.btnCopy.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.copy
        Me.btnCopy.Name = "btnCopy"
        '
        'mnuConsole
        '
        Me.mnuConsole.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopy), New DevExpress.XtraBars.LinkPersistInfo(Me.btnExport, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnClear, True)})
        Me.mnuConsole.Manager = Me.BarManager
        Me.mnuConsole.Name = "mnuConsole"
        '
        'GridControl1
        '
        resources.ApplyResources(Me.GridControl1, "GridControl1")
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.MenuManager = Me.BarManager
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtLogText})
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.DetailTip.Options.UseTextOptions = True
        Me.GridView1.Appearance.DetailTip.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.GridView1.Appearance.Row.Font = CType(resources.GetObject("GridView1.Appearance.Row.Font"), System.Drawing.Font)
        Me.GridView1.Appearance.Row.Options.UseFont = True
        Me.GridView1.Appearance.Row.Options.UseTextOptions = True
        Me.GridView1.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.GridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colLogDateTime, Me.colLogText})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.RowAutoHeight = True
        Me.GridView1.OptionsView.ShowColumnHeaders = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsView.ShowIndicator = False
        Me.GridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.[False]
        '
        'colLogDateTime
        '
        resources.ApplyResources(Me.colLogDateTime, "colLogDateTime")
        Me.colLogDateTime.DisplayFormat.FormatString = "dd/MM/yy HH:mm:ss"
        Me.colLogDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colLogDateTime.FieldName = "LogDateTime"
        Me.colLogDateTime.MaxWidth = 160
        Me.colLogDateTime.MinWidth = 160
        Me.colLogDateTime.Name = "colLogDateTime"
        '
        'colLogText
        '
        resources.ApplyResources(Me.colLogText, "colLogText")
        Me.colLogText.ColumnEdit = Me.txtLogText
        Me.colLogText.FieldName = "HTMLText"
        Me.colLogText.MinWidth = 1000
        Me.colLogText.Name = "colLogText"
        '
        'txtLogText
        '
        Me.txtLogText.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtLogText.Name = "txtLogText"
        Me.txtLogText.WordWrap = False
        '
        'cDockConsole
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "cDockConsole"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuConsole, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLogText, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barConsole As DevExpress.XtraBars.Bar
    Friend WithEvents btnExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnClear As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuConsole As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnCopy As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colLogDateTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLogText As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtLogText As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents btnOpenFileLog As DevExpress.XtraBars.BarButtonItem
End Class
