<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmWarpingDetails
    Inherits cForm

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWarpingDetails))
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions2 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject8 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.cmdApply = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.chkDontShowWarpingDetails = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdCancelAndPause = New DevExpress.XtraEditors.SimpleButton()
        Me.grdDetails = New DevExpress.XtraGrid.GridControl()
        Me.gridviewDetails = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDetailsState = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.picDetailsState = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.colDetailsFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDetailsTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDetailsDeltaSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDetailsDeltaX = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDetailsDeltaY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDetailsDeltaAngle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDetailsOldSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDetailsNewSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDetailsOldX = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDetailsNewX = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDetailsOldY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDetailsNewY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDetailsOldAngle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDetailsNewAngle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnShowMoreDetails = New DevExpress.XtraBars.BarCheckItem()
        Me.txtReplacePath = New DevExpress.XtraEditors.Repository.RepositoryItemBreadCrumbEdit()
        Me.mnuDetails = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.chkDontShowWarpingDetails.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridviewDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDetailsState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReplacePath, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdApply.Name = "cmdApply"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdCancel.ImageOptions.Image = Global.cSurveyPC.My.Resources.Resources.control_stop_blue
        Me.cmdCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.cmdCancel.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.stop1
        Me.cmdCancel.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdCancel.Name = "cmdCancel"
        '
        'chkDontShowWarpingDetails
        '
        resources.ApplyResources(Me.chkDontShowWarpingDetails, "chkDontShowWarpingDetails")
        Me.chkDontShowWarpingDetails.Name = "chkDontShowWarpingDetails"
        Me.chkDontShowWarpingDetails.Properties.Caption = resources.GetString("chkDontShowWarpingDetails.Properties.Caption")
        '
        'cmdCancelAndPause
        '
        resources.ApplyResources(Me.cmdCancelAndPause, "cmdCancelAndPause")
        Me.cmdCancelAndPause.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdCancelAndPause.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.cmdCancelAndPause.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.pause
        Me.cmdCancelAndPause.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdCancelAndPause.Name = "cmdCancelAndPause"
        '
        'grdDetails
        '
        resources.ApplyResources(Me.grdDetails, "grdDetails")
        Me.grdDetails.MainView = Me.gridviewDetails
        Me.grdDetails.Name = "grdDetails"
        Me.grdDetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.picDetailsState})
        Me.grdDetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridviewDetails})
        '
        'gridviewDetails
        '
        Me.gridviewDetails.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDetailsState, Me.colDetailsFrom, Me.colDetailsTo, Me.colDetailsDeltaSize, Me.colDetailsDeltaX, Me.colDetailsDeltaY, Me.colDetailsDeltaAngle, Me.colDetailsOldSize, Me.colDetailsNewSize, Me.colDetailsOldX, Me.colDetailsNewX, Me.colDetailsOldY, Me.colDetailsNewY, Me.colDetailsOldAngle, Me.colDetailsNewAngle})
        Me.gridviewDetails.GridControl = Me.grdDetails
        Me.gridviewDetails.Name = "gridviewDetails"
        Me.gridviewDetails.OptionsBehavior.Editable = False
        Me.gridviewDetails.OptionsBehavior.ReadOnly = True
        Me.gridviewDetails.OptionsMenu.EnableColumnMenu = False
        Me.gridviewDetails.OptionsMenu.EnableFooterMenu = False
        Me.gridviewDetails.OptionsMenu.EnableGroupPanelMenu = False
        Me.gridviewDetails.OptionsMenu.ShowAutoFilterRowItem = False
        Me.gridviewDetails.OptionsMenu.ShowDateTimeGroupIntervalItems = False
        Me.gridviewDetails.OptionsMenu.ShowGroupSortSummaryItems = False
        Me.gridviewDetails.OptionsMenu.ShowSplitItem = False
        Me.gridviewDetails.OptionsView.ColumnAutoWidth = False
        Me.gridviewDetails.OptionsView.ShowGroupPanel = False
        Me.gridviewDetails.OptionsView.ShowIndicator = False
        '
        'colDetailsState
        '
        resources.ApplyResources(Me.colDetailsState, "colDetailsState")
        Me.colDetailsState.ColumnEdit = Me.picDetailsState
        Me.colDetailsState.FieldName = "state"
        Me.colDetailsState.MinWidth = 24
        Me.colDetailsState.Name = "colDetailsState"
        Me.colDetailsState.UnboundType = DevExpress.Data.UnboundColumnType.[Object]
        '
        'picDetailsState
        '
        Me.picDetailsState.Name = "picDetailsState"
        resources.ApplyResources(Me.picDetailsState, "picDetailsState")
        '
        'colDetailsFrom
        '
        resources.ApplyResources(Me.colDetailsFrom, "colDetailsFrom")
        Me.colDetailsFrom.FieldName = "Segment.From"
        Me.colDetailsFrom.Name = "colDetailsFrom"
        '
        'colDetailsTo
        '
        resources.ApplyResources(Me.colDetailsTo, "colDetailsTo")
        Me.colDetailsTo.FieldName = "Segment.To"
        Me.colDetailsTo.Name = "colDetailsTo"
        '
        'colDetailsDeltaSize
        '
        resources.ApplyResources(Me.colDetailsDeltaSize, "colDetailsDeltaSize")
        Me.colDetailsDeltaSize.DisplayFormat.FormatString = "N3"
        Me.colDetailsDeltaSize.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDetailsDeltaSize.FieldName = "Details.DeltaSize"
        Me.colDetailsDeltaSize.Name = "colDetailsDeltaSize"
        '
        'colDetailsDeltaX
        '
        resources.ApplyResources(Me.colDetailsDeltaX, "colDetailsDeltaX")
        Me.colDetailsDeltaX.DisplayFormat.FormatString = "N3"
        Me.colDetailsDeltaX.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDetailsDeltaX.FieldName = "Details.DeltaX"
        Me.colDetailsDeltaX.Name = "colDetailsDeltaX"
        '
        'colDetailsDeltaY
        '
        resources.ApplyResources(Me.colDetailsDeltaY, "colDetailsDeltaY")
        Me.colDetailsDeltaY.DisplayFormat.FormatString = "N3"
        Me.colDetailsDeltaY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDetailsDeltaY.FieldName = "Details.DeltaY"
        Me.colDetailsDeltaY.Name = "colDetailsDeltaY"
        '
        'colDetailsDeltaAngle
        '
        resources.ApplyResources(Me.colDetailsDeltaAngle, "colDetailsDeltaAngle")
        Me.colDetailsDeltaAngle.DisplayFormat.FormatString = "N3"
        Me.colDetailsDeltaAngle.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDetailsDeltaAngle.FieldName = "Details.DeltaAngle"
        Me.colDetailsDeltaAngle.Name = "colDetailsDeltaAngle"
        '
        'colDetailsOldSize
        '
        resources.ApplyResources(Me.colDetailsOldSize, "colDetailsOldSize")
        Me.colDetailsOldSize.DisplayFormat.FormatString = "N4"
        Me.colDetailsOldSize.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDetailsOldSize.FieldName = "Details.OldSize"
        Me.colDetailsOldSize.Name = "colDetailsOldSize"
        '
        'colDetailsNewSize
        '
        resources.ApplyResources(Me.colDetailsNewSize, "colDetailsNewSize")
        Me.colDetailsNewSize.DisplayFormat.FormatString = "N4"
        Me.colDetailsNewSize.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDetailsNewSize.FieldName = "Details.NewSize"
        Me.colDetailsNewSize.Name = "colDetailsNewSize"
        '
        'colDetailsOldX
        '
        resources.ApplyResources(Me.colDetailsOldX, "colDetailsOldX")
        Me.colDetailsOldX.DisplayFormat.FormatString = "N4"
        Me.colDetailsOldX.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDetailsOldX.FieldName = "Details.OldLocation.X"
        Me.colDetailsOldX.Name = "colDetailsOldX"
        '
        'colDetailsNewX
        '
        resources.ApplyResources(Me.colDetailsNewX, "colDetailsNewX")
        Me.colDetailsNewX.DisplayFormat.FormatString = "N4"
        Me.colDetailsNewX.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDetailsNewX.FieldName = "Details.NewLocation.X"
        Me.colDetailsNewX.Name = "colDetailsNewX"
        '
        'colDetailsOldY
        '
        resources.ApplyResources(Me.colDetailsOldY, "colDetailsOldY")
        Me.colDetailsOldY.DisplayFormat.FormatString = "N4"
        Me.colDetailsOldY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDetailsOldY.FieldName = "Details.OldLocation.X"
        Me.colDetailsOldY.Name = "colDetailsOldY"
        '
        'colDetailsNewY
        '
        resources.ApplyResources(Me.colDetailsNewY, "colDetailsNewY")
        Me.colDetailsNewY.DisplayFormat.FormatString = "N4"
        Me.colDetailsNewY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDetailsNewY.FieldName = "Details.NewLocation.Y"
        Me.colDetailsNewY.Name = "colDetailsNewY"
        '
        'colDetailsOldAngle
        '
        resources.ApplyResources(Me.colDetailsOldAngle, "colDetailsOldAngle")
        Me.colDetailsOldAngle.DisplayFormat.FormatString = "N4"
        Me.colDetailsOldAngle.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDetailsOldAngle.FieldName = "Details.OldAngle"
        Me.colDetailsOldAngle.Name = "colDetailsOldAngle"
        '
        'colDetailsNewAngle
        '
        resources.ApplyResources(Me.colDetailsNewAngle, "colDetailsNewAngle")
        Me.colDetailsNewAngle.DisplayFormat.FormatString = "N4"
        Me.colDetailsNewAngle.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDetailsNewAngle.FieldName = "Details.NewAngle"
        Me.colDetailsNewAngle.Name = "colDetailsNewAngle"
        '
        'BarManager
        '
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnShowMoreDetails})
        Me.BarManager.MaxItemId = 8
        Me.BarManager.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtReplacePath})
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
        'btnShowMoreDetails
        '
        resources.ApplyResources(Me.btnShowMoreDetails, "btnShowMoreDetails")
        Me.btnShowMoreDetails.Id = 3
        Me.btnShowMoreDetails.Name = "btnShowMoreDetails"
        '
        'txtReplacePath
        '
        Me.txtReplacePath.AllowEdit = False
        resources.ApplyResources(Me.txtReplacePath, "txtReplacePath")
        EditorButtonImageOptions1.Image = Global.cSurveyPC.My.Resources.Resources.arrow_undo
        EditorButtonImageOptions2.Image = Global.cSurveyPC.My.Resources.Resources.folder
        Me.txtReplacePath.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtReplacePath.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtReplacePath.Buttons1"), CType(resources.GetObject("txtReplacePath.Buttons2"), Integer), CType(resources.GetObject("txtReplacePath.Buttons3"), Boolean), CType(resources.GetObject("txtReplacePath.Buttons4"), Boolean), CType(resources.GetObject("txtReplacePath.Buttons5"), Boolean), EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, resources.GetString("txtReplacePath.Buttons6"), CType(resources.GetObject("txtReplacePath.Buttons7"), Object), CType(resources.GetObject("txtReplacePath.Buttons8"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtReplacePath.Buttons9"), DevExpress.Utils.ToolTipAnchor)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtReplacePath.Buttons10"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtReplacePath.Buttons11"), CType(resources.GetObject("txtReplacePath.Buttons12"), Integer), CType(resources.GetObject("txtReplacePath.Buttons13"), Boolean), CType(resources.GetObject("txtReplacePath.Buttons14"), Boolean), CType(resources.GetObject("txtReplacePath.Buttons15"), Boolean), EditorButtonImageOptions2, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, SerializableAppearanceObject6, SerializableAppearanceObject7, SerializableAppearanceObject8, resources.GetString("txtReplacePath.Buttons16"), CType(resources.GetObject("txtReplacePath.Buttons17"), Object), CType(resources.GetObject("txtReplacePath.Buttons18"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtReplacePath.Buttons19"), DevExpress.Utils.ToolTipAnchor))})
        Me.txtReplacePath.Name = "txtReplacePath"
        Me.txtReplacePath.ShowRootGlyph = False
        '
        'mnuDetails
        '
        Me.mnuDetails.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnShowMoreDetails)})
        Me.mnuDetails.Manager = Me.BarManager
        Me.mnuDetails.Name = "mnuDetails"
        '
        'frmWarpingDetails
        '
        Me.AcceptButton = Me.cmdApply
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cmdCancelAndPause)
        Me.Controls.Add(Me.chkDontShowWarpingDetails)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.grdDetails)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.Icon = CType(resources.GetObject("frmWarpingDetails.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.warping
        Me.MinimizeBox = False
        Me.Name = "frmWarpingDetails"
        CType(Me.chkDontShowWarpingDetails.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridviewDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDetailsState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReplacePath, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdApply As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkDontShowWarpingDetails As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cmdCancelAndPause As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdDetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridviewDetails As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colDetailsFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDetailsTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDetailsDeltaSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDetailsDeltaX As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDetailsDeltaY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDetailsDeltaAngle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDetailsOldSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDetailsNewSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDetailsOldX As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDetailsNewX As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDetailsOldY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDetailsNewY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDetailsOldAngle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDetailsNewAngle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnShowMoreDetails As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents txtReplacePath As DevExpress.XtraEditors.Repository.RepositoryItemBreadCrumbEdit
    Friend WithEvents mnuDetails As DevExpress.XtraBars.PopupMenu
    Friend WithEvents colDetailsState As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents picDetailsState As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
End Class
