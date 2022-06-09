<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemMarkerPropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemMarkerPropertyControl))
        Me.grdMarkerInfo = New DevExpress.XtraVerticalGrid.VGridControl()
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
        Me.mnuContext = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.lblpropMarker = New DevExpress.XtraEditors.LabelControl()
        CType(Me.grdMarkerInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdMarkerInfo
        '
        resources.ApplyResources(Me.grdMarkerInfo, "grdMarkerInfo")
        Me.grdMarkerInfo.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdMarkerInfo.Name = "grdMarkerInfo"
        Me.grdMarkerInfo.OptionsBehavior.ResizeRowValues = False
        Me.grdMarkerInfo.OptionsFilter.AllowFilter = False
        Me.grdMarkerInfo.OptionsView.MinRowAutoHeight = 12
        '
        'BarManager
        '
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnRefresh, Me.btnCopyValue, Me.btnCopyValues, Me.btnCopyAll, Me.btnCopy})
        Me.BarManager.MaxItemId = 7
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
        'mnuContext
        '
        Me.mnuContext.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopyValue, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopyValues), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopy, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopyAll), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRefresh, True)})
        Me.mnuContext.Manager = Me.BarManager
        Me.mnuContext.Name = "mnuContext"
        '
        'lblpropMarker
        '
        resources.ApplyResources(Me.lblpropMarker, "lblpropMarker")
        Me.lblpropMarker.Name = "lblpropMarker"
        '
        'cItemMarkerPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.grdMarkerInfo)
        Me.Controls.Add(Me.lblpropMarker)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "cItemMarkerPropertyControl"
        CType(Me.grdMarkerInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdMarkerInfo As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuContext As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnCopyValue As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopyValues As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopyAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopy As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents lblpropMarker As DevExpress.XtraEditors.LabelControl
End Class
