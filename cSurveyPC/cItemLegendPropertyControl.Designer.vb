<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemLegendPropertyControl
    Inherits cItemPropertyControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemLegendPropertyControl))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmdAutofill = New System.Windows.Forms.Button()
        Me.cmdDeleteAll = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUp = New System.Windows.Forms.Button()
        Me.lblPropLegendItems = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblPropCrossSectionCrossX = New System.Windows.Forms.Label()
        Me.txtPropLegendItemHeight = New System.Windows.Forms.NumericUpDown()
        Me.txtPropLegendItemWidth = New System.Windows.Forms.NumericUpDown()
        Me.lblPropLegendItemSize = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPropLegendItemVPadding = New System.Windows.Forms.NumericUpDown()
        Me.txtPropLegendItemHPadding = New System.Windows.Forms.NumericUpDown()
        Me.lblPropLegendItemPadding = New System.Windows.Forms.Label()
        Me.grdLegendItems = New cSurveyPC.cGrid()
        Me.colItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLegendType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colLegendText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLegendScale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtPropLegendItemScale = New System.Windows.Forms.NumericUpDown()
        Me.lblBaseLineWidthScaleFactor = New System.Windows.Forms.Label()
        Me.lblPropLegendItemFlowDirection = New System.Windows.Forms.Label()
        Me.cboPropLegendItemFlowDirection = New System.Windows.Forms.ComboBox()
        Me.cboPropLegendItemAlign = New System.Windows.Forms.ComboBox()
        Me.lblPropLegendItemAlign = New System.Windows.Forms.Label()
        Me.txtPropLegendItemRowColMaxItems = New System.Windows.Forms.NumericUpDown()
        Me.lblPropLegendItemRowColMaxItems = New System.Windows.Forms.Label()
        Me.tpMain = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.txtPropLegendItemHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropLegendItemWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropLegendItemVPadding, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropLegendItemHPadding, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdLegendItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropLegendItemScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropLegendItemRowColMaxItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdAutofill
        '
        resources.ApplyResources(Me.cmdAutofill, "cmdAutofill")
        Me.cmdAutofill.Image = Global.cSurveyPC.My.Resources.Resources.fill
        Me.cmdAutofill.Name = "cmdAutofill"
        Me.tpMain.SetToolTip(Me.cmdAutofill, resources.GetString("cmdAutofill.ToolTip"))
        Me.cmdAutofill.UseVisualStyleBackColor = True
        '
        'cmdDeleteAll
        '
        resources.ApplyResources(Me.cmdDeleteAll, "cmdDeleteAll")
        Me.cmdDeleteAll.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.cmdDeleteAll.Name = "cmdDeleteAll"
        Me.tpMain.SetToolTip(Me.cmdDeleteAll, resources.GetString("cmdDeleteAll.ToolTip"))
        Me.cmdDeleteAll.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        resources.ApplyResources(Me.cmdDelete, "cmdDelete")
        Me.cmdDelete.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.cmdDelete.Name = "cmdDelete"
        Me.tpMain.SetToolTip(Me.cmdDelete, resources.GetString("cmdDelete.ToolTip"))
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdDown
        '
        resources.ApplyResources(Me.cmdDown, "cmdDown")
        Me.cmdDown.Name = "cmdDown"
        Me.tpMain.SetToolTip(Me.cmdDown, resources.GetString("cmdDown.ToolTip"))
        Me.cmdDown.UseVisualStyleBackColor = True
        '
        'cmdUp
        '
        resources.ApplyResources(Me.cmdUp, "cmdUp")
        Me.cmdUp.Name = "cmdUp"
        Me.tpMain.SetToolTip(Me.cmdUp, resources.GetString("cmdUp.ToolTip"))
        Me.cmdUp.UseVisualStyleBackColor = True
        '
        'lblPropLegendItems
        '
        resources.ApplyResources(Me.lblPropLegendItems, "lblPropLegendItems")
        Me.lblPropLegendItems.Name = "lblPropLegendItems"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'lblPropCrossSectionCrossX
        '
        resources.ApplyResources(Me.lblPropCrossSectionCrossX, "lblPropCrossSectionCrossX")
        Me.lblPropCrossSectionCrossX.Name = "lblPropCrossSectionCrossX"
        '
        'txtPropLegendItemHeight
        '
        resources.ApplyResources(Me.txtPropLegendItemHeight, "txtPropLegendItemHeight")
        Me.txtPropLegendItemHeight.DecimalPlaces = 2
        Me.txtPropLegendItemHeight.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.txtPropLegendItemHeight.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtPropLegendItemHeight.Name = "txtPropLegendItemHeight"
        Me.tpMain.SetToolTip(Me.txtPropLegendItemHeight, resources.GetString("txtPropLegendItemHeight.ToolTip"))
        Me.txtPropLegendItemHeight.Value = New Decimal(New Integer() {5, 0, 0, 65536})
        '
        'txtPropLegendItemWidth
        '
        resources.ApplyResources(Me.txtPropLegendItemWidth, "txtPropLegendItemWidth")
        Me.txtPropLegendItemWidth.DecimalPlaces = 2
        Me.txtPropLegendItemWidth.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.txtPropLegendItemWidth.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtPropLegendItemWidth.Name = "txtPropLegendItemWidth"
        Me.tpMain.SetToolTip(Me.txtPropLegendItemWidth, resources.GetString("txtPropLegendItemWidth.ToolTip"))
        Me.txtPropLegendItemWidth.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'lblPropLegendItemSize
        '
        resources.ApplyResources(Me.lblPropLegendItemSize, "lblPropLegendItemSize")
        Me.lblPropLegendItemSize.Name = "lblPropLegendItemSize"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'txtPropLegendItemVPadding
        '
        resources.ApplyResources(Me.txtPropLegendItemVPadding, "txtPropLegendItemVPadding")
        Me.txtPropLegendItemVPadding.DecimalPlaces = 2
        Me.txtPropLegendItemVPadding.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.txtPropLegendItemVPadding.Name = "txtPropLegendItemVPadding"
        Me.tpMain.SetToolTip(Me.txtPropLegendItemVPadding, resources.GetString("txtPropLegendItemVPadding.ToolTip"))
        Me.txtPropLegendItemVPadding.Value = New Decimal(New Integer() {1, 0, 0, 131072})
        '
        'txtPropLegendItemHPadding
        '
        resources.ApplyResources(Me.txtPropLegendItemHPadding, "txtPropLegendItemHPadding")
        Me.txtPropLegendItemHPadding.DecimalPlaces = 2
        Me.txtPropLegendItemHPadding.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.txtPropLegendItemHPadding.Name = "txtPropLegendItemHPadding"
        Me.tpMain.SetToolTip(Me.txtPropLegendItemHPadding, resources.GetString("txtPropLegendItemHPadding.ToolTip"))
        Me.txtPropLegendItemHPadding.Value = New Decimal(New Integer() {1, 0, 0, 131072})
        '
        'lblPropLegendItemPadding
        '
        resources.ApplyResources(Me.lblPropLegendItemPadding, "lblPropLegendItemPadding")
        Me.lblPropLegendItemPadding.Name = "lblPropLegendItemPadding"
        '
        'grdLegendItems
        '
        Me.grdLegendItems.AllowUserToAddRows = False
        resources.ApplyResources(Me.grdLegendItems, "grdLegendItems")
        Me.grdLegendItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdLegendItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdLegendItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItem, Me.colLegendType, Me.colLegendText, Me.colLegendScale})
        Me.grdLegendItems.Name = "grdLegendItems"
        Me.grdLegendItems.RowHeadersVisible = False
        '
        'colItem
        '
        resources.ApplyResources(Me.colItem, "colItem")
        Me.colItem.Name = "colItem"
        Me.colItem.ReadOnly = True
        '
        'colLegendType
        '
        resources.ApplyResources(Me.colLegendType, "colLegendType")
        Me.colLegendType.Name = "colLegendType"
        '
        'colLegendText
        '
        resources.ApplyResources(Me.colLegendText, "colLegendText")
        Me.colLegendText.Name = "colLegendText"
        '
        'colLegendScale
        '
        DataGridViewCellStyle1.Format = "N3"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.colLegendScale.DefaultCellStyle = DataGridViewCellStyle1
        resources.ApplyResources(Me.colLegendScale, "colLegendScale")
        Me.colLegendScale.Name = "colLegendScale"
        '
        'txtPropLegendItemScale
        '
        resources.ApplyResources(Me.txtPropLegendItemScale, "txtPropLegendItemScale")
        Me.txtPropLegendItemScale.DecimalPlaces = 3
        Me.txtPropLegendItemScale.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.txtPropLegendItemScale.Minimum = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.txtPropLegendItemScale.Name = "txtPropLegendItemScale"
        Me.tpMain.SetToolTip(Me.txtPropLegendItemScale, resources.GetString("txtPropLegendItemScale.ToolTip"))
        Me.txtPropLegendItemScale.Value = New Decimal(New Integer() {1, 0, 0, 0})
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
        Me.tpMain.SetToolTip(Me.cboPropLegendItemFlowDirection, resources.GetString("cboPropLegendItemFlowDirection.ToolTip"))
        '
        'cboPropLegendItemAlign
        '
        resources.ApplyResources(Me.cboPropLegendItemAlign, "cboPropLegendItemAlign")
        Me.cboPropLegendItemAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropLegendItemAlign.FormattingEnabled = True
        Me.cboPropLegendItemAlign.Items.AddRange(New Object() {resources.GetString("cboPropLegendItemAlign.Items"), resources.GetString("cboPropLegendItemAlign.Items1")})
        Me.cboPropLegendItemAlign.Name = "cboPropLegendItemAlign"
        Me.tpMain.SetToolTip(Me.cboPropLegendItemAlign, resources.GetString("cboPropLegendItemAlign.ToolTip"))
        '
        'lblPropLegendItemAlign
        '
        resources.ApplyResources(Me.lblPropLegendItemAlign, "lblPropLegendItemAlign")
        Me.lblPropLegendItemAlign.Name = "lblPropLegendItemAlign"
        '
        'txtPropLegendItemRowColMaxItems
        '
        resources.ApplyResources(Me.txtPropLegendItemRowColMaxItems, "txtPropLegendItemRowColMaxItems")
        Me.txtPropLegendItemRowColMaxItems.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtPropLegendItemRowColMaxItems.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtPropLegendItemRowColMaxItems.Name = "txtPropLegendItemRowColMaxItems"
        Me.tpMain.SetToolTip(Me.txtPropLegendItemRowColMaxItems, resources.GetString("txtPropLegendItemRowColMaxItems.ToolTip"))
        Me.txtPropLegendItemRowColMaxItems.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblPropLegendItemRowColMaxItems
        '
        resources.ApplyResources(Me.lblPropLegendItemRowColMaxItems, "lblPropLegendItemRowColMaxItems")
        Me.lblPropLegendItemRowColMaxItems.Name = "lblPropLegendItemRowColMaxItems"
        '
        'cItemLegendPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
        Me.Controls.Add(Me.grdLegendItems)
        Me.Controls.Add(Me.lblPropLegendItemFlowDirection)
        Me.Controls.Add(Me.lblPropLegendItemAlign)
        Me.Name = "cItemLegendPropertyControl"
        CType(Me.txtPropLegendItemHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropLegendItemWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropLegendItemVPadding, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropLegendItemHPadding, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdLegendItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropLegendItemScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropLegendItemRowColMaxItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grdLegendItems As cGrid
    Friend WithEvents cmdDelete As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUp As Button
    Friend WithEvents cmdDeleteAll As Button
    Friend WithEvents cmdAutofill As Button
    Friend WithEvents lblPropLegendItems As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblPropCrossSectionCrossX As Label
    Friend WithEvents txtPropLegendItemHeight As NumericUpDown
    Friend WithEvents txtPropLegendItemWidth As NumericUpDown
    Friend WithEvents lblPropLegendItemSize As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPropLegendItemVPadding As NumericUpDown
    Friend WithEvents txtPropLegendItemHPadding As NumericUpDown
    Friend WithEvents lblPropLegendItemPadding As Label
    Friend WithEvents txtPropLegendItemScale As NumericUpDown
    Friend WithEvents lblBaseLineWidthScaleFactor As Label
    Friend WithEvents colItem As DataGridViewTextBoxColumn
    Friend WithEvents colLegendType As DataGridViewComboBoxColumn
    Friend WithEvents colLegendText As DataGridViewTextBoxColumn
    Friend WithEvents colLegendScale As DataGridViewTextBoxColumn
    Friend WithEvents lblPropLegendItemFlowDirection As Label
    Friend WithEvents cboPropLegendItemFlowDirection As ComboBox
    Friend WithEvents cboPropLegendItemAlign As ComboBox
    Friend WithEvents lblPropLegendItemAlign As Label
    Friend WithEvents txtPropLegendItemRowColMaxItems As NumericUpDown
    Friend WithEvents lblPropLegendItemRowColMaxItems As Label
    Friend WithEvents tpMain As ToolTip
End Class
