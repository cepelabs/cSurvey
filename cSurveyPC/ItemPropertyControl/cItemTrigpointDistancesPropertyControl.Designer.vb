<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemTrigpointDistancesPropertyControl
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemTrigpointDistancesPropertyControl))
        Me.chkPropTrigpointDistancesSplays = New DevExpress.XtraEditors.CheckEdit()
        Me.lblPropTrigpointsDistances = New DevExpress.XtraEditors.LabelControl()
        Me.cmdPropTrigpointDistancesCalculate = New DevExpress.XtraEditors.SimpleButton()
        Me.chkPropTrigpointDistancesLinkedSurveys = New DevExpress.XtraEditors.CheckEdit()
        Me.grdDistance = New DevExpress.XtraGrid.GridControl()
        Me.grdViewDistance = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDistanceFilename = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDistanceCave = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDistanceStation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDistanceValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCopyValue = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCopyValues = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCopyAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCopy = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSelectStation = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuContext = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.chkPropTrigpointDistancesSplays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPropTrigpointDistancesLinkedSurveys.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdViewDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkPropTrigpointDistancesSplays
        '
        resources.ApplyResources(Me.chkPropTrigpointDistancesSplays, "chkPropTrigpointDistancesSplays")
        Me.chkPropTrigpointDistancesSplays.Name = "chkPropTrigpointDistancesSplays"
        Me.chkPropTrigpointDistancesSplays.Properties.AutoWidth = True
        Me.chkPropTrigpointDistancesSplays.Properties.Caption = resources.GetString("chkPropTrigpointDistancesSplays.Properties.Caption")
        '
        'lblPropTrigpointsDistances
        '
        resources.ApplyResources(Me.lblPropTrigpointsDistances, "lblPropTrigpointsDistances")
        Me.lblPropTrigpointsDistances.Name = "lblPropTrigpointsDistances"
        '
        'cmdPropTrigpointDistancesCalculate
        '
        resources.ApplyResources(Me.cmdPropTrigpointDistancesCalculate, "cmdPropTrigpointDistancesCalculate")
        Me.cmdPropTrigpointDistancesCalculate.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropTrigpointDistancesCalculate.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_refresh
        Me.cmdPropTrigpointDistancesCalculate.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdPropTrigpointDistancesCalculate.Name = "cmdPropTrigpointDistancesCalculate"
        '
        'chkPropTrigpointDistancesLinkedSurveys
        '
        resources.ApplyResources(Me.chkPropTrigpointDistancesLinkedSurveys, "chkPropTrigpointDistancesLinkedSurveys")
        Me.chkPropTrigpointDistancesLinkedSurveys.Name = "chkPropTrigpointDistancesLinkedSurveys"
        Me.chkPropTrigpointDistancesLinkedSurveys.Properties.AutoWidth = True
        Me.chkPropTrigpointDistancesLinkedSurveys.Properties.Caption = resources.GetString("chkPropTrigpointDistancesLinkedSurveys.Properties.Caption")
        '
        'grdDistance
        '
        resources.ApplyResources(Me.grdDistance, "grdDistance")
        Me.grdDistance.MainView = Me.grdViewDistance
        Me.grdDistance.Name = "grdDistance"
        Me.grdDistance.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdViewDistance})
        '
        'grdViewDistance
        '
        Me.grdViewDistance.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDistanceFilename, Me.colDistanceCave, Me.colDistanceStation, Me.colDistanceValue})
        Me.grdViewDistance.GridControl = Me.grdDistance
        Me.grdViewDistance.Name = "grdViewDistance"
        Me.grdViewDistance.OptionsBehavior.Editable = False
        Me.grdViewDistance.OptionsBehavior.ReadOnly = True
        Me.grdViewDistance.OptionsView.ColumnAutoWidth = False
        Me.grdViewDistance.OptionsView.ShowGroupPanel = False
        Me.grdViewDistance.OptionsView.ShowIndicator = False
        Me.grdViewDistance.OptionsView.ShowViewCaption = True
        resources.ApplyResources(Me.grdViewDistance, "grdViewDistance")
        '
        'colDistanceFilename
        '
        resources.ApplyResources(Me.colDistanceFilename, "colDistanceFilename")
        Me.colDistanceFilename.FieldName = "Filename"
        Me.colDistanceFilename.MinWidth = 120
        Me.colDistanceFilename.Name = "colDistanceFilename"
        Me.colDistanceFilename.OptionsColumn.AllowEdit = False
        Me.colDistanceFilename.OptionsColumn.ReadOnly = True
        '
        'colDistanceCave
        '
        resources.ApplyResources(Me.colDistanceCave, "colDistanceCave")
        Me.colDistanceCave.FieldName = "Station.Survey.Properties.Name"
        Me.colDistanceCave.MinWidth = 90
        Me.colDistanceCave.Name = "colDistanceCave"
        Me.colDistanceCave.OptionsColumn.AllowEdit = False
        Me.colDistanceCave.OptionsColumn.ReadOnly = True
        '
        'colDistanceStation
        '
        resources.ApplyResources(Me.colDistanceStation, "colDistanceStation")
        Me.colDistanceStation.FieldName = "Station.Name"
        Me.colDistanceStation.Name = "colDistanceStation"
        Me.colDistanceStation.OptionsColumn.AllowEdit = False
        Me.colDistanceStation.OptionsColumn.ReadOnly = True
        '
        'colDistanceValue
        '
        Me.colDistanceValue.AppearanceCell.Options.UseTextOptions = True
        Me.colDistanceValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        resources.ApplyResources(Me.colDistanceValue, "colDistanceValue")
        Me.colDistanceValue.DisplayFormat.FormatString = "N2"
        Me.colDistanceValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDistanceValue.FieldName = "Value"
        Me.colDistanceValue.Name = "colDistanceValue"
        Me.colDistanceValue.OptionsColumn.AllowEdit = False
        Me.colDistanceValue.OptionsColumn.ReadOnly = True
        '
        'BarManager
        '
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnRefresh, Me.btnCopyValue, Me.btnCopyValues, Me.btnCopyAll, Me.btnCopy, Me.btnSelectStation})
        Me.BarManager.MaxItemId = 8
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
        'btnRefresh
        '
        Me.btnRefresh.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left
        resources.ApplyResources(Me.btnRefresh, "btnRefresh")
        Me.btnRefresh.Id = 2
        Me.btnRefresh.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_refresh
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
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
        'btnSelectStation
        '
        resources.ApplyResources(Me.btnSelectStation, "btnSelectStation")
        Me.btnSelectStation.Enabled = False
        Me.btnSelectStation.Id = 7
        Me.btnSelectStation.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources._select
        Me.btnSelectStation.Name = "btnSelectStation"
        '
        'mnuContext
        '
        Me.mnuContext.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnSelectStation), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopyValue, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopyValues), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopy, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopyAll), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRefresh, True)})
        Me.mnuContext.Manager = Me.BarManager
        Me.mnuContext.Name = "mnuContext"
        '
        'cItemTrigpointDistances
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.chkPropTrigpointDistancesLinkedSurveys)
        Me.Controls.Add(Me.chkPropTrigpointDistancesSplays)
        Me.Controls.Add(Me.cmdPropTrigpointDistancesCalculate)
        Me.Controls.Add(Me.lblPropTrigpointsDistances)
        Me.Controls.Add(Me.grdDistance)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "cItemTrigpointDistances"
        CType(Me.chkPropTrigpointDistancesSplays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPropTrigpointDistancesLinkedSurveys.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDistance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdViewDistance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkPropTrigpointDistancesSplays As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblPropTrigpointsDistances As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdPropTrigpointDistancesCalculate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkPropTrigpointDistancesLinkedSurveys As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents grdDistance As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdViewDistance As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colDistanceFilename As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDistanceStation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDistanceValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDistanceCave As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopyValue As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopyValues As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopyAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopy As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnSelectStation As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuContext As DevExpress.XtraBars.PopupMenu
End Class
