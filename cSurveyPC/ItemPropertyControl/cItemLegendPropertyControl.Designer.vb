<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemLegendPropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemLegendPropertyControl))
        Me.cmdAutofill = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdDeleteAll = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdDown = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdUp = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPropLegendItems = New DevExpress.XtraEditors.LabelControl()
        Me.Label9 = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropCrossSectionCrossX = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropLegendItemHeight = New DevExpress.XtraEditors.SpinEdit()
        Me.txtPropLegendItemWidth = New DevExpress.XtraEditors.SpinEdit()
        Me.lblPropLegendItemSize = New DevExpress.XtraEditors.LabelControl()
        Me.Label1 = New DevExpress.XtraEditors.LabelControl()
        Me.Label2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropLegendItemVPadding = New DevExpress.XtraEditors.SpinEdit()
        Me.txtPropLegendItemHPadding = New DevExpress.XtraEditors.SpinEdit()
        Me.lblPropLegendItemPadding = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropLegendItemScale = New DevExpress.XtraEditors.SpinEdit()
        Me.lblBaseLineWidthScaleFactor = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropLegendItemFlowDirection = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropLegendItemFlowDirection = New System.Windows.Forms.ComboBox()
        Me.cboPropLegendItemAlign = New System.Windows.Forms.ComboBox()
        Me.lblPropLegendItemAlign = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropLegendItemRowColMaxItems = New DevExpress.XtraEditors.SpinEdit()
        Me.lblPropLegendItemRowColMaxItems = New DevExpress.XtraEditors.LabelControl()
        Me.txtItemsScale = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.cboItemsType = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colItemsObject = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colItemsType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colItemsText = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colItemsScale = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        CType(Me.txtPropLegendItemHeight.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropLegendItemWidth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropLegendItemVPadding.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropLegendItemHPadding.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropLegendItemScale.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropLegendItemRowColMaxItems.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtItemsScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboItemsType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdAutofill
        '
        resources.ApplyResources(Me.cmdAutofill, "cmdAutofill")
        Me.cmdAutofill.ImageOptions.Image = Global.cSurveyPC.My.Resources.Resources.fill
        Me.cmdAutofill.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdAutofill.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.automaticupdates
        Me.cmdAutofill.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdAutofill.Name = "cmdAutofill"
        '
        'cmdDeleteAll
        '
        resources.ApplyResources(Me.cmdDeleteAll, "cmdDeleteAll")
        Me.cmdDeleteAll.ImageOptions.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.cmdDeleteAll.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdDeleteAll.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.clearall
        Me.cmdDeleteAll.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdDeleteAll.Name = "cmdDeleteAll"
        '
        'cmdDelete
        '
        resources.ApplyResources(Me.cmdDelete, "cmdDelete")
        Me.cmdDelete.ImageOptions.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.cmdDelete.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdDelete.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.delete1
        Me.cmdDelete.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdDelete.Name = "cmdDelete"
        '
        'cmdDown
        '
        resources.ApplyResources(Me.cmdDown, "cmdDown")
        Me.cmdDown.ImageOptions.Image = CType(resources.GetObject("cmdDown.ImageOptions.Image"), System.Drawing.Image)
        Me.cmdDown.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdDown.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.movedown
        Me.cmdDown.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdDown.Name = "cmdDown"
        '
        'cmdUp
        '
        resources.ApplyResources(Me.cmdUp, "cmdUp")
        Me.cmdUp.ImageOptions.Image = CType(resources.GetObject("cmdUp.ImageOptions.Image"), System.Drawing.Image)
        Me.cmdUp.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdUp.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.moveup
        Me.cmdUp.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdUp.Name = "cmdUp"
        '
        'lblPropLegendItems
        '
        resources.ApplyResources(Me.lblPropLegendItems, "lblPropLegendItems")
        Me.lblPropLegendItems.Name = "lblPropLegendItems"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Appearance.Font = CType(resources.GetObject("Label9.Appearance.Font"), System.Drawing.Font)
        Me.Label9.Appearance.Options.UseFont = True
        Me.Label9.Name = "Label9"
        '
        'lblPropCrossSectionCrossX
        '
        resources.ApplyResources(Me.lblPropCrossSectionCrossX, "lblPropCrossSectionCrossX")
        Me.lblPropCrossSectionCrossX.Appearance.Font = CType(resources.GetObject("lblPropCrossSectionCrossX.Appearance.Font"), System.Drawing.Font)
        Me.lblPropCrossSectionCrossX.Appearance.Options.UseFont = True
        Me.lblPropCrossSectionCrossX.Name = "lblPropCrossSectionCrossX"
        '
        'txtPropLegendItemHeight
        '
        resources.ApplyResources(Me.txtPropLegendItemHeight, "txtPropLegendItemHeight")
        Me.txtPropLegendItemHeight.Name = "txtPropLegendItemHeight"
        Me.txtPropLegendItemHeight.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropLegendItemHeight.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropLegendItemHeight.Properties.DisplayFormat.FormatString = "N2"
        Me.txtPropLegendItemHeight.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropLegendItemHeight.Properties.EditFormat.FormatString = "N2"
        Me.txtPropLegendItemHeight.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropLegendItemHeight.Properties.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.txtPropLegendItemHeight.Properties.MaxValue = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'txtPropLegendItemWidth
        '
        resources.ApplyResources(Me.txtPropLegendItemWidth, "txtPropLegendItemWidth")
        Me.txtPropLegendItemWidth.Name = "txtPropLegendItemWidth"
        Me.txtPropLegendItemWidth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropLegendItemWidth.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropLegendItemWidth.Properties.DisplayFormat.FormatString = "N2"
        Me.txtPropLegendItemWidth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropLegendItemWidth.Properties.EditFormat.FormatString = "N2"
        Me.txtPropLegendItemWidth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropLegendItemWidth.Properties.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.txtPropLegendItemWidth.Properties.MaxValue = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'lblPropLegendItemSize
        '
        resources.ApplyResources(Me.lblPropLegendItemSize, "lblPropLegendItemSize")
        Me.lblPropLegendItemSize.Appearance.Font = CType(resources.GetObject("lblPropLegendItemSize.Appearance.Font"), System.Drawing.Font)
        Me.lblPropLegendItemSize.Appearance.Options.UseFont = True
        Me.lblPropLegendItemSize.Name = "lblPropLegendItemSize"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Appearance.Font = CType(resources.GetObject("Label1.Appearance.Font"), System.Drawing.Font)
        Me.Label1.Appearance.Options.UseFont = True
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Appearance.Font = CType(resources.GetObject("Label2.Appearance.Font"), System.Drawing.Font)
        Me.Label2.Appearance.Options.UseFont = True
        Me.Label2.Name = "Label2"
        '
        'txtPropLegendItemVPadding
        '
        resources.ApplyResources(Me.txtPropLegendItemVPadding, "txtPropLegendItemVPadding")
        Me.txtPropLegendItemVPadding.Name = "txtPropLegendItemVPadding"
        Me.txtPropLegendItemVPadding.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropLegendItemVPadding.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropLegendItemVPadding.Properties.DisplayFormat.FormatString = "N2"
        Me.txtPropLegendItemVPadding.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropLegendItemVPadding.Properties.EditFormat.FormatString = "N2"
        Me.txtPropLegendItemVPadding.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropLegendItemVPadding.Properties.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        '
        'txtPropLegendItemHPadding
        '
        resources.ApplyResources(Me.txtPropLegendItemHPadding, "txtPropLegendItemHPadding")
        Me.txtPropLegendItemHPadding.Name = "txtPropLegendItemHPadding"
        Me.txtPropLegendItemHPadding.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropLegendItemHPadding.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropLegendItemHPadding.Properties.DisplayFormat.FormatString = "N2"
        Me.txtPropLegendItemHPadding.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropLegendItemHPadding.Properties.EditFormat.FormatString = "N2"
        Me.txtPropLegendItemHPadding.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropLegendItemHPadding.Properties.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        '
        'lblPropLegendItemPadding
        '
        resources.ApplyResources(Me.lblPropLegendItemPadding, "lblPropLegendItemPadding")
        Me.lblPropLegendItemPadding.Appearance.Font = CType(resources.GetObject("lblPropLegendItemPadding.Appearance.Font"), System.Drawing.Font)
        Me.lblPropLegendItemPadding.Appearance.Options.UseFont = True
        Me.lblPropLegendItemPadding.Name = "lblPropLegendItemPadding"
        '
        'txtPropLegendItemScale
        '
        resources.ApplyResources(Me.txtPropLegendItemScale, "txtPropLegendItemScale")
        Me.txtPropLegendItemScale.Name = "txtPropLegendItemScale"
        Me.txtPropLegendItemScale.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropLegendItemScale.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropLegendItemScale.Properties.DisplayFormat.FormatString = "N3"
        Me.txtPropLegendItemScale.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropLegendItemScale.Properties.EditFormat.FormatString = "N3"
        Me.txtPropLegendItemScale.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropLegendItemScale.Properties.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.txtPropLegendItemScale.Properties.MaxValue = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.txtPropLegendItemScale.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 196608})
        '
        'lblBaseLineWidthScaleFactor
        '
        resources.ApplyResources(Me.lblBaseLineWidthScaleFactor, "lblBaseLineWidthScaleFactor")
        Me.lblBaseLineWidthScaleFactor.Name = "lblBaseLineWidthScaleFactor"
        '
        'lblPropLegendItemFlowDirection
        '
        resources.ApplyResources(Me.lblPropLegendItemFlowDirection, "lblPropLegendItemFlowDirection")
        Me.lblPropLegendItemFlowDirection.Name = "lblPropLegendItemFlowDirection"
        '
        'cboPropLegendItemFlowDirection
        '
        resources.ApplyResources(Me.cboPropLegendItemFlowDirection, "cboPropLegendItemFlowDirection")
        Me.cboPropLegendItemFlowDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropLegendItemFlowDirection.FormattingEnabled = True
        Me.cboPropLegendItemFlowDirection.Items.AddRange(New Object() {resources.GetString("cboPropLegendItemFlowDirection.Items"), resources.GetString("cboPropLegendItemFlowDirection.Items1")})
        Me.cboPropLegendItemFlowDirection.Name = "cboPropLegendItemFlowDirection"
        '
        'cboPropLegendItemAlign
        '
        resources.ApplyResources(Me.cboPropLegendItemAlign, "cboPropLegendItemAlign")
        Me.cboPropLegendItemAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropLegendItemAlign.FormattingEnabled = True
        Me.cboPropLegendItemAlign.Items.AddRange(New Object() {resources.GetString("cboPropLegendItemAlign.Items"), resources.GetString("cboPropLegendItemAlign.Items1")})
        Me.cboPropLegendItemAlign.Name = "cboPropLegendItemAlign"
        '
        'lblPropLegendItemAlign
        '
        resources.ApplyResources(Me.lblPropLegendItemAlign, "lblPropLegendItemAlign")
        Me.lblPropLegendItemAlign.Name = "lblPropLegendItemAlign"
        '
        'txtPropLegendItemRowColMaxItems
        '
        resources.ApplyResources(Me.txtPropLegendItemRowColMaxItems, "txtPropLegendItemRowColMaxItems")
        Me.txtPropLegendItemRowColMaxItems.Name = "txtPropLegendItemRowColMaxItems"
        Me.txtPropLegendItemRowColMaxItems.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropLegendItemRowColMaxItems.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropLegendItemRowColMaxItems.Properties.DisplayFormat.FormatString = "N0"
        Me.txtPropLegendItemRowColMaxItems.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropLegendItemRowColMaxItems.Properties.EditFormat.FormatString = "N0"
        Me.txtPropLegendItemRowColMaxItems.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropLegendItemRowColMaxItems.Properties.IsFloatValue = False
        Me.txtPropLegendItemRowColMaxItems.Properties.MaskSettings.Set("mask", "N00")
        Me.txtPropLegendItemRowColMaxItems.Properties.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtPropLegendItemRowColMaxItems.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblPropLegendItemRowColMaxItems
        '
        resources.ApplyResources(Me.lblPropLegendItemRowColMaxItems, "lblPropLegendItemRowColMaxItems")
        Me.lblPropLegendItemRowColMaxItems.Name = "lblPropLegendItemRowColMaxItems"
        '
        'txtItemsScale
        '
        resources.ApplyResources(Me.txtItemsScale, "txtItemsScale")
        Me.txtItemsScale.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtItemsScale.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtItemsScale.DisplayFormat.FormatString = "N3"
        Me.txtItemsScale.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtItemsScale.EditFormat.FormatString = "N3"
        Me.txtItemsScale.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtItemsScale.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtItemsScale.MaskSettings.Set("mask", "N3")
        Me.txtItemsScale.MaxValue = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtItemsScale.MinValue = New Decimal(New Integer() {1, 0, 0, 262144})
        Me.txtItemsScale.Name = "txtItemsScale"
        '
        'cboItemsType
        '
        resources.ApplyResources(Me.cboItemsType, "cboItemsType")
        Me.cboItemsType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboItemsType.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboItemsType.Name = "cboItemsType"
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colItemsObject, Me.colItemsType, Me.colItemsText, Me.colItemsScale})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OptionsView.ShowIndicator = False
        '
        'colItemsObject
        '
        resources.ApplyResources(Me.colItemsObject, "colItemsObject")
        Me.colItemsObject.FieldName = "Item"
        Me.colItemsObject.Name = "colItemsObject"
        Me.colItemsObject.OptionsColumn.AllowEdit = False
        Me.colItemsObject.OptionsColumn.ReadOnly = True
        '
        'colItemsType
        '
        resources.ApplyResources(Me.colItemsType, "colItemsType")
        Me.colItemsType.ColumnEdit = Me.cboItemsType
        Me.colItemsType.FieldName = "Type"
        Me.colItemsType.MinWidth = 70
        Me.colItemsType.Name = "colItemsType"
        '
        'colItemsText
        '
        resources.ApplyResources(Me.colItemsText, "colItemsText")
        Me.colItemsText.FieldName = "Text"
        Me.colItemsText.MinWidth = 150
        Me.colItemsText.Name = "colItemsText"
        '
        'colItemsScale
        '
        resources.ApplyResources(Me.colItemsScale, "colItemsScale")
        Me.colItemsScale.ColumnEdit = Me.txtItemsScale
        Me.colItemsScale.FieldName = "Scale"
        Me.colItemsScale.MaxWidth = 60
        Me.colItemsScale.Name = "colItemsScale"
        '
        'GridControl1
        '
        resources.ApplyResources(Me.GridControl1, "GridControl1")
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtItemsScale, Me.cboItemsType})
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'cItemLegendPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.txtPropLegendItemRowColMaxItems)
        Me.Controls.Add(Me.lblPropLegendItemRowColMaxItems)
        Me.Controls.Add(Me.cboPropLegendItemFlowDirection)
        Me.Controls.Add(Me.cboPropLegendItemAlign)
        Me.Controls.Add(Me.txtPropLegendItemScale)
        Me.Controls.Add(Me.lblBaseLineWidthScaleFactor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPropLegendItemVPadding)
        Me.Controls.Add(Me.txtPropLegendItemHPadding)
        Me.Controls.Add(Me.lblPropLegendItemPadding)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblPropCrossSectionCrossX)
        Me.Controls.Add(Me.txtPropLegendItemHeight)
        Me.Controls.Add(Me.txtPropLegendItemWidth)
        Me.Controls.Add(Me.lblPropLegendItemSize)
        Me.Controls.Add(Me.lblPropLegendItems)
        Me.Controls.Add(Me.cmdAutofill)
        Me.Controls.Add(Me.cmdDeleteAll)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdUp)
        Me.Controls.Add(Me.lblPropLegendItemFlowDirection)
        Me.Controls.Add(Me.lblPropLegendItemAlign)
        Me.Controls.Add(Me.GridControl1)
        Me.Name = "cItemLegendPropertyControl"
        CType(Me.txtPropLegendItemHeight.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropLegendItemWidth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropLegendItemVPadding.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropLegendItemHPadding.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropLegendItemScale.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropLegendItemRowColMaxItems.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtItemsScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboItemsType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdDown As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdUp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdDeleteAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdAutofill As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPropLegendItems As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropCrossSectionCrossX As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropLegendItemHeight As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtPropLegendItemWidth As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblPropLegendItemSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropLegendItemVPadding As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtPropLegendItemHPadding As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblPropLegendItemPadding As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropLegendItemScale As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblBaseLineWidthScaleFactor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropLegendItemFlowDirection As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropLegendItemFlowDirection As ComboBox
    Friend WithEvents cboPropLegendItemAlign As ComboBox
    Friend WithEvents lblPropLegendItemAlign As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropLegendItemRowColMaxItems As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblPropLegendItemRowColMaxItems As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtItemsScale As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents cboItemsType As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colItemsObject As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colItemsType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colItemsText As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colItemsScale As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
End Class
