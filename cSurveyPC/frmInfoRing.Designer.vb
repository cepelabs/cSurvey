<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfoRing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInfoRing))
        Me.pnlSurveyRing = New DevExpress.XtraEditors.PanelControl()
        Me.txtSurveyRingAverageError = New DevExpress.XtraEditors.TextEdit()
        Me.lblAvgError = New DevExpress.XtraEditors.LabelControl()
        Me.grdRings = New DevExpress.XtraGrid.GridControl()
        Me.grdRingsView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colRingsSelect = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkRingsSelect = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colRingsColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtRingsColor = New DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit()
        Me.colRingsStation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRingsErrorPercent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRingsLinearError = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRingsX = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRingsY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRingsZ = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRingsLength = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRingsStationN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRingsStations = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdApply = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnCopyValue = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCopyValues = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCopyAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCopy = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExport = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSelectAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDeselectAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnInvertSelection = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuContext = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.pnlSurveyRing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSurveyRing.SuspendLayout()
        CType(Me.txtSurveyRingAverageError.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdRings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdRingsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkRingsSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRingsColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSurveyRing
        '
        resources.ApplyResources(Me.pnlSurveyRing, "pnlSurveyRing")
        Me.pnlSurveyRing.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlSurveyRing.Controls.Add(Me.txtSurveyRingAverageError)
        Me.pnlSurveyRing.Controls.Add(Me.lblAvgError)
        Me.pnlSurveyRing.Controls.Add(Me.grdRings)
        Me.pnlSurveyRing.Name = "pnlSurveyRing"
        '
        'txtSurveyRingAverageError
        '
        resources.ApplyResources(Me.txtSurveyRingAverageError, "txtSurveyRingAverageError")
        Me.txtSurveyRingAverageError.Name = "txtSurveyRingAverageError"
        Me.txtSurveyRingAverageError.Properties.Appearance.Options.UseTextOptions = True
        Me.txtSurveyRingAverageError.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtSurveyRingAverageError.Properties.ReadOnly = True
        '
        'lblAvgError
        '
        resources.ApplyResources(Me.lblAvgError, "lblAvgError")
        Me.lblAvgError.Name = "lblAvgError"
        '
        'grdRings
        '
        resources.ApplyResources(Me.grdRings, "grdRings")
        Me.grdRings.MainView = Me.grdRingsView
        Me.grdRings.Name = "grdRings"
        Me.grdRings.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtRingsColor, Me.chkRingsSelect})
        Me.grdRings.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdRingsView})
        '
        'grdRingsView
        '
        Me.grdRingsView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colRingsSelect, Me.colRingsColor, Me.colRingsStation, Me.colRingsErrorPercent, Me.colRingsLinearError, Me.colRingsX, Me.colRingsY, Me.colRingsZ, Me.colRingsLength, Me.colRingsStationN, Me.colRingsStations})
        Me.grdRingsView.GridControl = Me.grdRings
        Me.grdRingsView.Name = "grdRingsView"
        Me.grdRingsView.OptionsView.ColumnAutoWidth = False
        Me.grdRingsView.OptionsView.ShowGroupPanel = False
        Me.grdRingsView.OptionsView.ShowIndicator = False
        '
        'colRingsSelect
        '
        Me.colRingsSelect.ColumnEdit = Me.chkRingsSelect
        Me.colRingsSelect.FieldName = "Selected"
        Me.colRingsSelect.MaxWidth = 24
        Me.colRingsSelect.MinWidth = 24
        Me.colRingsSelect.Name = "colRingsSelect"
        resources.ApplyResources(Me.colRingsSelect, "colRingsSelect")
        '
        'chkRingsSelect
        '
        resources.ApplyResources(Me.chkRingsSelect, "chkRingsSelect")
        Me.chkRingsSelect.Name = "chkRingsSelect"
        '
        'colRingsColor
        '
        resources.ApplyResources(Me.colRingsColor, "colRingsColor")
        Me.colRingsColor.ColumnEdit = Me.txtRingsColor
        Me.colRingsColor.FieldName = "Color"
        Me.colRingsColor.Name = "colRingsColor"
        '
        'txtRingsColor
        '
        resources.ApplyResources(Me.txtRingsColor, "txtRingsColor")
        Me.txtRingsColor.AutomaticColor = System.Drawing.Color.Black
        Me.txtRingsColor.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtRingsColor.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtRingsColor.Name = "txtRingsColor"
        Me.txtRingsColor.ShowSystemColors = False
        Me.txtRingsColor.ShowWebColors = False
        '
        'colRingsStation
        '
        resources.ApplyResources(Me.colRingsStation, "colRingsStation")
        Me.colRingsStation.FieldName = "FirstStation"
        Me.colRingsStation.Name = "colRingsStation"
        Me.colRingsStation.OptionsColumn.AllowEdit = False
        Me.colRingsStation.OptionsColumn.ReadOnly = True
        '
        'colRingsErrorPercent
        '
        resources.ApplyResources(Me.colRingsErrorPercent, "colRingsErrorPercent")
        Me.colRingsErrorPercent.DisplayFormat.FormatString = "{0:0.00}%"
        Me.colRingsErrorPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colRingsErrorPercent.FieldName = "ErrorPercent"
        Me.colRingsErrorPercent.Name = "colRingsErrorPercent"
        Me.colRingsErrorPercent.OptionsColumn.AllowEdit = False
        Me.colRingsErrorPercent.OptionsColumn.ReadOnly = True
        '
        'colRingsLinearError
        '
        resources.ApplyResources(Me.colRingsLinearError, "colRingsLinearError")
        Me.colRingsLinearError.FieldName = "Error"
        Me.colRingsLinearError.Name = "colRingsLinearError"
        Me.colRingsLinearError.OptionsColumn.AllowEdit = False
        Me.colRingsLinearError.OptionsColumn.ReadOnly = True
        '
        'colRingsX
        '
        resources.ApplyResources(Me.colRingsX, "colRingsX")
        Me.colRingsX.FieldName = "X"
        Me.colRingsX.MaxWidth = 80
        Me.colRingsX.Name = "colRingsX"
        Me.colRingsX.OptionsColumn.AllowEdit = False
        Me.colRingsX.OptionsColumn.ReadOnly = True
        '
        'colRingsY
        '
        resources.ApplyResources(Me.colRingsY, "colRingsY")
        Me.colRingsY.FieldName = "Y"
        Me.colRingsY.MaxWidth = 80
        Me.colRingsY.Name = "colRingsY"
        Me.colRingsY.OptionsColumn.AllowEdit = False
        Me.colRingsY.OptionsColumn.ReadOnly = True
        '
        'colRingsZ
        '
        resources.ApplyResources(Me.colRingsZ, "colRingsZ")
        Me.colRingsZ.FieldName = "Z"
        Me.colRingsZ.MaxWidth = 80
        Me.colRingsZ.Name = "colRingsZ"
        Me.colRingsZ.OptionsColumn.AllowEdit = False
        Me.colRingsZ.OptionsColumn.ReadOnly = True
        '
        'colRingsLength
        '
        resources.ApplyResources(Me.colRingsLength, "colRingsLength")
        Me.colRingsLength.FieldName = "Length"
        Me.colRingsLength.Name = "colRingsLength"
        Me.colRingsLength.OptionsColumn.AllowEdit = False
        Me.colRingsLength.OptionsColumn.ReadOnly = True
        '
        'colRingsStationN
        '
        resources.ApplyResources(Me.colRingsStationN, "colRingsStationN")
        Me.colRingsStationN.FieldName = "Count"
        Me.colRingsStationN.Name = "colRingsStationN"
        Me.colRingsStationN.OptionsColumn.AllowEdit = False
        Me.colRingsStationN.OptionsColumn.ReadOnly = True
        '
        'colRingsStations
        '
        resources.ApplyResources(Me.colRingsStations, "colRingsStations")
        Me.colRingsStations.FieldName = "_stations"
        Me.colRingsStations.MinWidth = 200
        Me.colRingsStations.Name = "colRingsStations"
        Me.colRingsStations.OptionsColumn.AllowEdit = False
        Me.colRingsStations.OptionsColumn.ReadOnly = True
        Me.colRingsStations.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.Name = "cmdApply"
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'BarManager
        '
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnCopyValue, Me.btnCopyValues, Me.btnCopyAll, Me.btnCopy, Me.btnExport, Me.btnSelectAll, Me.btnDeselectAll, Me.btnInvertSelection})
        Me.BarManager.MaxItemId = 11
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
        'btnCopyValue
        '
        resources.ApplyResources(Me.btnCopyValue, "btnCopyValue")
        Me.btnCopyValue.Id = 3
        Me.btnCopyValue.Name = "btnCopyValue"
        '
        'btnCopyValues
        '
        resources.ApplyResources(Me.btnCopyValues, "btnCopyValues")
        Me.btnCopyValues.Id = 4
        Me.btnCopyValues.Name = "btnCopyValues"
        '
        'btnCopyAll
        '
        resources.ApplyResources(Me.btnCopyAll, "btnCopyAll")
        Me.btnCopyAll.Id = 5
        Me.btnCopyAll.Name = "btnCopyAll"
        '
        'btnCopy
        '
        resources.ApplyResources(Me.btnCopy, "btnCopy")
        Me.btnCopy.Id = 6
        Me.btnCopy.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.copy
        Me.btnCopy.Name = "btnCopy"
        '
        'btnExport
        '
        resources.ApplyResources(Me.btnExport, "btnExport")
        Me.btnExport.Id = 7
        Me.btnExport.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.exportfile
        Me.btnExport.Name = "btnExport"
        '
        'btnSelectAll
        '
        resources.ApplyResources(Me.btnSelectAll, "btnSelectAll")
        Me.btnSelectAll.Id = 8
        Me.btnSelectAll.Name = "btnSelectAll"
        '
        'btnDeselectAll
        '
        resources.ApplyResources(Me.btnDeselectAll, "btnDeselectAll")
        Me.btnDeselectAll.Id = 9
        Me.btnDeselectAll.Name = "btnDeselectAll"
        '
        'btnInvertSelection
        '
        resources.ApplyResources(Me.btnInvertSelection, "btnInvertSelection")
        Me.btnInvertSelection.Id = 10
        Me.btnInvertSelection.Name = "btnInvertSelection"
        '
        'mnuContext
        '
        Me.mnuContext.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnSelectAll, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDeselectAll), New DevExpress.XtraBars.LinkPersistInfo(Me.btnInvertSelection), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopyValue, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopyValues), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopy, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopyAll), New DevExpress.XtraBars.LinkPersistInfo(Me.btnExport, True)})
        Me.mnuContext.Manager = Me.BarManager
        Me.mnuContext.Name = "mnuContext"
        '
        'frmInfoRing
        '
        Me.AcceptButton = Me.cmdApply
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.pnlSurveyRing)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.bo_statemachine
        Me.MinimizeBox = False
        Me.Name = "frmInfoRing"
        CType(Me.pnlSurveyRing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSurveyRing.ResumeLayout(False)
        Me.pnlSurveyRing.PerformLayout()
        CType(Me.txtSurveyRingAverageError.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdRings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdRingsView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkRingsSelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRingsColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlSurveyRing As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtSurveyRingAverageError As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblAvgError As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdApply As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdRings As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdRingsView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colRingsSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRingsStation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRingsErrorPercent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRingsLinearError As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRingsX As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRingsY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRingsZ As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRingsLength As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRingsStationN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRingsStations As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRingsColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtRingsColor As DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnCopyValue As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopyValues As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopyAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopy As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuContext As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnSelectAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnDeselectAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnInvertSelection As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents chkRingsSelect As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
