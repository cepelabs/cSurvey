<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cDockJoinPoints
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDockJoinPoints))
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.BarMain = New DevExpress.XtraBars.Bar()
        Me.btnRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.btnLink = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCancel = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnSelect = New DevExpress.XtraBars.BarButtonItem()
        Me.tvPoints = New DevExpress.XtraTreeList.TreeList()
        Me.colX = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colY = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colJoin = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.mnuContext = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tvPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager
        '
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.BarMain})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnRemove, Me.btnLink, Me.btnCancel, Me.btnSelect})
        Me.BarManager.MaxItemId = 23
        '
        'BarMain
        '
        Me.BarMain.BarName = "Tools"
        Me.BarMain.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Me.BarMain.DockCol = 0
        Me.BarMain.DockRow = 0
        Me.BarMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.BarMain.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnRemove), New DevExpress.XtraBars.LinkPersistInfo(Me.btnLink, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCancel, True)})
        Me.BarMain.OptionsBar.AllowQuickCustomization = False
        Me.BarMain.OptionsBar.DisableCustomization = True
        Me.BarMain.OptionsBar.DrawDragBorder = False
        Me.BarMain.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.BarMain, "BarMain")
        '
        'btnRemove
        '
        resources.ApplyResources(Me.btnRemove, "btnRemove")
        Me.btnRemove.Id = 15
        Me.btnRemove.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.delete1
        Me.btnRemove.Name = "btnRemove"
        '
        'btnLink
        '
        resources.ApplyResources(Me.btnLink, "btnLink")
        Me.btnLink.Id = 16
        Me.btnLink.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.joinpoints_join
        Me.btnLink.Name = "btnLink"
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Id = 17
        Me.btnCancel.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.clearall
        Me.btnCancel.Name = "btnCancel"
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
        'btnSelect
        '
        resources.ApplyResources(Me.btnSelect, "btnSelect")
        Me.btnSelect.Id = 22
        Me.btnSelect.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources._select
        Me.btnSelect.Name = "btnSelect"
        '
        'tvPoints
        '
        Me.tvPoints.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.tvPoints.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colX, Me.colY, Me.colJoin})
        resources.ApplyResources(Me.tvPoints, "tvPoints")
        Me.tvPoints.MenuManager = Me.BarManager
        Me.tvPoints.Name = "tvPoints"
        Me.tvPoints.OptionsBehavior.Editable = False
        Me.tvPoints.OptionsBehavior.ReadOnly = True
        Me.tvPoints.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus
        Me.tvPoints.OptionsView.ShowIndentAsRowStyle = True
        Me.tvPoints.OptionsView.ShowIndicator = False
        Me.tvPoints.OptionsView.ShowRoot = False
        '
        'colX
        '
        resources.ApplyResources(Me.colX, "colX")
        Me.colX.FieldName = "X"
        Me.colX.Format.FormatString = "N2"
        Me.colX.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colX.Name = "colX"
        '
        'colY
        '
        resources.ApplyResources(Me.colY, "colY")
        Me.colY.FieldName = "Y"
        Me.colY.Format.FormatString = "N2"
        Me.colY.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colY.Name = "colY"
        '
        'colJoin
        '
        resources.ApplyResources(Me.colJoin, "colJoin")
        Me.colJoin.FieldName = "PointsJoin.Count"
        Me.colJoin.Format.FormatString = "N0"
        Me.colJoin.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colJoin.Name = "colJoin"
        '
        'mnuContext
        '
        Me.mnuContext.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnSelect), New DevExpress.XtraBars.LinkPersistInfo(Me.btnLink, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRemove, True)})
        Me.mnuContext.Manager = Me.BarManager
        Me.mnuContext.Name = "mnuContext"
        '
        'cDockJoinPoints
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.tvPoints)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "cDockJoinPoints"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tvPoints, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents BarMain As DevExpress.XtraBars.Bar
    Friend WithEvents btnRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnLink As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCancel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents tvPoints As DevExpress.XtraTreeList.TreeList
    Friend WithEvents colX As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colY As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colJoin As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents btnSelect As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuContext As DevExpress.XtraBars.PopupMenu
End Class
